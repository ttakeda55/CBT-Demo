Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports Microsoft.Office.Interop
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common

Public Class importPracticeQuestion
    Private Shared WordApp As Microsoft.Office.Interop.Word.Application
    Private Shared Doc As Microsoft.Office.Interop.Word.Document
    Private Shared strParentName As String

    ''' <summary>
    ''' ワードファイルをQuestionBankCollectionに保持する。
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ImportWord(ByVal strPath As String) As VetnurseQuestionBankCollection
        WordApp = New Microsoft.Office.Interop.Word.Application
        strParentName = System.IO.Path.GetDirectoryName(strPath)

        'ワードファイルをhtml形式で保存する
        Dim HTMLFileName As String
        HTMLFileName = saveWordToHtml(strPath)

        ''htmlファイルをIHTMLDocument2形式に変換する
        Dim htmlDoc As HtmlDocument = getHtmlDocument(HTMLFileName)

        'DOMをQuestionBankCollectionに保持する
        Dim colQuestionbank As New VetnurseQuestionBankCollection
        saveDomToQuestionBank(htmlDoc, colQuestionbank)

        'ファイル削除
        System.IO.File.Delete(HTMLFileName)
        Utility.DeleteDirectory(HTMLFileName.Replace(".htm", "") & ".files")

        Return colQuestionbank

    End Function

    ''' <summary>
    ''' ワードファイルをhtml形式で保存する。
    ''' </summary>
    ''' <param name="filePath">ワードファイルのパス</param>
    ''' <returns>htmlファイルのパス</returns>
    ''' <remarks></remarks>
    Private Shared Function saveWordToHtml(ByVal filePath As String) As String
        saveWordToHtml = ""
        Dim HTMLFileName As String = IO.Path.ChangeExtension(Common.Constant.GetTempPath & IO.Path.GetFileName(filePath), ".htm")
        strParentName = System.IO.Path.GetDirectoryName(HTMLFileName)

        'ファイルフォーマットの識別子を取得
        Try
            Doc = WordApp.Documents.Open(filePath)

            '書籍を変更
            changeFormat(Doc, {"\!#上線*上線\!#"})
            delOverLineChar(Doc, "上線\!#")
            delOverLineChar(Doc, "\!#上線")

            'ワードファイルをhtml形式で保存
            Doc.SaveAs(HTMLFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML)

            Return HTMLFileName
        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        Finally
            Doc.Close()
            WordApp.Quit()
        End Try
    End Function

    ''' <summary>
    ''' 上線のフォーマットを変換
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="replaceStr"></param>
    ''' <remarks></remarks>
    Friend Shared Sub changeFormat(ByRef doc As Word.Document, ByVal replaceStr As String())
        Dim intFound As Integer = 0
        Dim rng As Word.Range = doc.Content

        rng.Find.ClearFormatting()
        rng.Find.Forward = True
        rng.Find.Text = replaceStr(0)
        rng.Find.MatchWildcards = True

        rng.Find.Execute()

        Do While rng.Find.Found = True
            rng.Underline = True
            rng.Font.StrikeThrough = True

            rng.Find.Execute()
        Loop
    End Sub

    ''' <summary>
    ''' 上線の識別記号を削除
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="delStr"></param>
    ''' <remarks></remarks>
    Friend Shared Sub delOverLineChar(ByRef doc As Word.Document, ByVal delStr As String)
        Dim intFound As Integer = 0
        Dim rng As Word.Range = doc.Content

        rng.Find.ClearFormatting()
        rng.Find.Forward = True
        rng.Find.Text = delStr
        rng.Find.MatchWildcards = True

        rng.Find.Execute()

        Do While rng.Find.Found = True
            rng.Text = ""
            rng.Find.Execute()
        Loop
    End Sub

    ''' <summary>
    ''' htmlファイルをIHTMLDocument2形式に変換する
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getHtmlDocument(ByVal filePath As String) As HtmlDocument
        Dim wc As New WebClient()
        wc.Proxy = Nothing
        wc.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim html As String = wc.DownloadString(filePath)

        '上線を変換
        html = changeOverLine(html)

        Return CBTCommon.Utility.GetHtmlDocument(html)

    End Function

    ''' <summary>
    ''' DOMをQuestionBankCollectionに保持する
    ''' </summary>
    ''' <param name="imsdoc"></param>
    ''' <param name="colQuestionbank"></param>
    ''' <remarks></remarks>
    Private Shared Sub saveDomToQuestionBank(ByVal imsdoc As HtmlDocument, ByRef colQuestionbank As VetnurseQuestionBankCollection)
        Dim blnPropertyFlg As Boolean = False
        Dim blnQestionFlg As Boolean = False
        Dim blnReTestCommnetFlg As Boolean = False
        Dim blnEndFlg As Boolean = False
        Dim strSplit As String()
        Dim nextPropertyFlg As Boolean = False

        Dim QuestionBank As New VetNurseQuestionBank

        For Each head As HtmlElement In imsdoc.GetElementsByTagName("HEAD")
            QuestionBank.HeadTag = head.OuterHtml
        Next
        For Each body As HtmlElement In imsdoc.GetElementsByTagName("BODY")
            QuestionBank.BodyTag = body.OuterHtml.ToString.Substring(0, body.OuterHtml.ToString.IndexOf(">") + 1)
            For Each div As HtmlElement In body.Children
                If div.TagName.ToLower = "div" Then
                    QuestionBank.DivTag = div.OuterHtml.ToString.Substring(0, div.OuterHtml.ToString.IndexOf(">") + 1)
                End If
            Next
        Next

        '!#{テスト名}が存在しない
        'If Common.Constant.CST_IDENTIFICATIONMARK & Common.TestName.GetTestName <> imsdoc.Body.Children(0).Children(0).InnerText Then
        '    Exit Sub
        'End If

        For Each body As HtmlElement In imsdoc.Body.Children
            For Each p As HtmlElement In body.Children
                If blnEndFlg Then
                    '画像の取得
                    setImage(QuestionBank, QuestionBank.Question)
                    colQuestionbank.Add(QuestionBank.DeepCopy())
                    QuestionBank.RemoveAll()
                    blnEndFlg = False
                    blnPropertyFlg = True
                End If

                If Common.Constant.CST_PROPERTY = delSpace(p.InnerText) Then
                    If blnPropertyFlg Or blnQestionFlg Then
                        blnEndFlg = True
                    End If
                    blnPropertyFlg = True
                    blnQestionFlg = False
                    nextPropertyFlg = True
                    Continue For
                End If
                If Common.Constant.CST_QUESTION = delSpace(p.InnerText) Then
                    If blnQestionFlg Then
                        blnEndFlg = True
                    End If
                    blnPropertyFlg = False
                    blnQestionFlg = True
                    Continue For
                End If
                '属性取得
                If blnPropertyFlg Then
                    If Not p.InnerText Is Nothing Then
                        If p.InnerText.IndexOf(Common.Constant.CST_IDENTIFICATIONMARK) = 0 Then
                            strSplit = delSpace(p.InnerText).Replace(":", "：").Split("：")
                            If UBound(strSplit) > 0 Then
                                '問題コード
                                If Common.Constant.CST_QUESTIONCODE = strSplit(0) Then
                                    QuestionBank.QuestionCode = strSplit(1)
                                End If
                                'カテゴリーID
                                If Common.Constant.CST_CATEGORYID = strSplit(0) Then
                                    QuestionBank.CategoryId = strSplit(1)
                                End If
                                '問題テーマ
                                If Common.Constant.CST_THEME = strSplit(0) Then
                                    QuestionBank.Theme = strSplit(1)
                                End If
                                '難易度
                                If Common.Constant.CST_LEVEL = strSplit(0) Then
                                    QuestionBank.Level = strSplit(1)
                                End If
                                '正解
                                If Common.Constant.CST_ANSWER = strSplit(0) Then
                                    QuestionBank.Ansewr = strSplit(1)
                                End If
                            End If
                        End If
                    End If
                End If
                '設問取得
                If blnQestionFlg Then
                    QuestionBank.AddQuestion(p.OuterHtml)
                End If
            Next
        Next

        '画像の取得
        setImage(QuestionBank, QuestionBank.Question)

        colQuestionbank.Add(QuestionBank.DeepCopy())

        imsdoc = Nothing

    End Sub

    ''' <summary>
    ''' 上線に変更
    ''' </summary>
    Private Shared Function changeOverLine(ByVal html As String) As String
        Dim str As String = ""
        html = System.Text.RegularExpressions.Regex.Replace(html, _
            "(<[suSU]>){2}", "<span style=""text-decoration:overline;"">", System.Text.RegularExpressions.RegexOptions.Singleline)

        html = System.Text.RegularExpressions.Regex.Replace(html, _
            "(</[suSU]>){2}", "</span>", System.Text.RegularExpressions.RegexOptions.Singleline)
        Return html
    End Function

    ''' <summary>
    ''' 画像ファイル名を変更し、QuestionBankに保持する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub setImage(ByVal questionBank As PracticeQuestionBank, ByRef html As String)
        Dim machPattern As String = "src="".*?/.*?"""
        Dim mcs = System.Text.RegularExpressions.Regex.Matches( _
        html, machPattern, System.Text.RegularExpressions.RegexOptions.Singleline)

        'ファイル名取得
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim htImage As New Hashtable
        For Each m As System.Text.RegularExpressions.Match In mcs
            j = m.Value.ToString.IndexOf("/")
            k = m.Value.ToString.IndexOf("""", j)
            htImage(i) = m.Value.Substring(j + 1, k - j - 1)
            i += 1
        Next

        If mcs.Count = 0 Then
            Return
        End If

        Dim folderName As String
        Dim folderPath As String
        j = mcs.Item(0).Value.IndexOf("""")
        k = mcs.Item(0).Value.IndexOf("/")
        folderName = mcs.Item(0).Value.Substring(j + 1, k - j - 1)

        folderPath = strParentName & "\" & folderName.Replace("%20", " ")

        'イメージファイルを読み込みコンバート
        i = 0
        Dim img As Image
        Dim replaceHtml As String = html
        Dim orgFileName As String = ""
        Dim changeExtFileName As String = ""
        For Each filename In htImage
            orgFileName = htImage(i)
            changeExtFileName = IO.Path.ChangeExtension(orgFileName, "jpg")
            img = Image.FromFile(folderPath & "\" & htImage(i))
            questionBank.Image(changeExtFileName) = Utility.ImageToByteArray(img)
            replaceHtml = replaceHtml.Replace(folderName & "/" & htImage(i), changeExtFileName)
            i += 1
            img.Dispose()
        Next

        '画像のaltを削除
        delAlt(replaceHtml)

        html = replaceHtml

    End Sub

    Private Shared Sub delAlt(ByRef html As String)
        Dim machPattern As String = "alt="".*?"""
        html = System.Text.RegularExpressions.Regex.Replace(html, machPattern, "alt=""""")
    End Sub
    ''' <summary>
    ''' 空白文字を削除する
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function delSpace(ByVal str As String) As String
        If str = Nothing Then
            delSpace = ""
        Else
            delSpace = str.Replace(" ", "").Replace("　", "")
        End If
    End Function

End Class
