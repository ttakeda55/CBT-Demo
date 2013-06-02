Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports Microsoft.Office.Interop
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common

Public Class ConvertWordToHtml
    Private Shared WordApp As Microsoft.Office.Interop.Word.Application
    Private Shared Doc As Microsoft.Office.Interop.Word.Document
    Private Shared strParentName As String

    ''' <summary>
    ''' ワードファイルをQuestionBankCollectionに保持する。
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ImportWord(ByVal strPath As String) As QuestionBankCollection
        WordApp = New Microsoft.Office.Interop.Word.Application
        strParentName = System.IO.Path.GetDirectoryName(strPath)

        'ワードファイルをhtml形式で保存する
        Dim HTMLFileName As String
        HTMLFileName = saveWordToHtml(strPath)

        ''htmlファイルをIHTMLDocument2形式に変換する
        Dim htmlDoc As HtmlDocument = getHtmlDocument(HTMLFileName)

        'DOMをQuestionBankCollectionに保持する
        Dim colQuestionbank As New QuestionBankCollection
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
    Private Shared Sub saveDomToQuestionBank(ByVal imsdoc As HtmlDocument, ByRef colQuestionbank As QuestionBankCollection)
        Dim blnPropertyFlg As Boolean = False
        Dim blnQestionFlg As Boolean = False
        Dim blnSelectFlg As Boolean = False
        Dim blnCommnetFlg As Boolean = False
        Dim blnReTestCommnetFlg As Boolean = False
        Dim blnEndFlg As Boolean = False
        Dim strSplit As String()
        Dim strkeyWordSplit As String()
        Dim nextPropertyFlg As Boolean = False

        Dim QuestionBank As New QuestionBank


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

        '!#模擬テストが存在しない
        If Common.Constant.CST_MOCKTEST <> imsdoc.Body.Children(0).Children(0).InnerText Then
            Exit Sub
        End If

        For Each body As HtmlElement In imsdoc.Body.Children
            For Each p As HtmlElement In body.Children
                If blnEndFlg Then
                    '画像の取得
                    setImage(QuestionBank, QuestionBank.Question)
                    setImage(QuestionBank, QuestionBank.Choice)
                    setImage(QuestionBank, QuestionBank.Comment)
                    setImage(QuestionBank, QuestionBank.ReTestComment)
                    colQuestionbank.Add(QuestionBank.DeepCopy())
                    QuestionBank.RemoveAll()
                    blnEndFlg = False
                    blnPropertyFlg = True
                End If

                If Common.Constant.CST_PROPERTY = delSpace(p.InnerText) Then
                    If blnQestionFlg Or blnSelectFlg Or blnCommnetFlg Or blnReTestCommnetFlg Then
                        blnEndFlg = True
                    End If
                    blnPropertyFlg = True
                    blnQestionFlg = False
                    blnSelectFlg = False
                    blnCommnetFlg = False
                    blnReTestCommnetFlg = False
                    nextPropertyFlg = True
                    Continue For
                End If
                If Common.Constant.CST_QUESTION = delSpace(p.InnerText) Then
                    If blnSelectFlg Or blnCommnetFlg Or blnReTestCommnetFlg Then
                        blnEndFlg = True
                    End If
                    blnPropertyFlg = False
                    blnQestionFlg = True
                    blnSelectFlg = False
                    blnCommnetFlg = False
                    blnReTestCommnetFlg = False
                    Continue For
                End If
                If Common.Constant.CST_SELECT = delSpace(p.InnerText) Then
                    If blnCommnetFlg Or blnReTestCommnetFlg Then
                        blnEndFlg = True
                    End If
                    blnPropertyFlg = False
                    blnQestionFlg = False
                    blnSelectFlg = True
                    blnCommnetFlg = False
                    blnReTestCommnetFlg = False
                    Continue For
                End If
                If Common.Constant.CST_COMMENT = delSpace(p.InnerText) Then
                    If blnReTestCommnetFlg Then
                        blnEndFlg = True
                    End If
                    blnPropertyFlg = False
                    blnQestionFlg = False
                    blnSelectFlg = False
                    blnCommnetFlg = True
                    blnReTestCommnetFlg = False
                    Continue For
                End If
                If Common.Constant.CST_RETESTCOMMENT = delSpace(p.InnerText) Then
                    blnPropertyFlg = False
                    blnQestionFlg = False
                    blnSelectFlg = False
                    blnCommnetFlg = False
                    blnReTestCommnetFlg = True
                    Continue For
                End If
                '属性取得
                If blnPropertyFlg Then
                    If Not p.InnerText Is Nothing Then
                        If p.InnerText.IndexOf(Common.Constant.CST_IDENTIFICATIONMARK) = 0 Then
                            strSplit = delSpace(p.InnerText).Replace(":", "：").Split("：")
                            If UBound(strSplit) > 0 Then
                                strkeyWordSplit = strSplit(1).Split(",")
                                If UBound(strkeyWordSplit) > 0 Then
                                    QuestionBank.QuestionProperty(strSplit(0)) = strkeyWordSplit
                                Else
                                    QuestionBank.QuestionProperty(strSplit(0)) = strSplit(1)
                                    '分類ID設定
                                    If strSplit(0) = Common.Constant.CST_CATEGORY Then
                                        QuestionBank.QuestionProperty(Common.Constant.CST_DISPLAYID) = strSplit(1)
                                        QuestionBank.QuestionProperty(Common.Constant.CST_CATEGORY) = GetCategoryID(strSplit(1))
                                    End If
                                End If
                            End If

                            If nextPropertyFlg Then
                                QuestionBank.QuestionProperty(Common.Constant.CST_PROPERTY) = nextPropertyFlg
                                nextPropertyFlg = False
                            End If

                        End If
                    End If
                End If
                '設問取得
                If blnQestionFlg Then
                    QuestionBank.AddQuestion(p.OuterHtml)
                End If
                '選択肢取得
                If blnSelectFlg Then
                    QuestionBank.AddChoice(p.OuterHtml)
                End If
                '解説を取得
                If blnCommnetFlg Then
                    QuestionBank.AddComment(p.OuterHtml)
                End If
                '再受講用解説を取得
                If blnReTestCommnetFlg Then
                    QuestionBank.AddReTestComment(p.OuterHtml)
                End If
            Next
        Next

        '画像の取得
        setImage(QuestionBank, QuestionBank.Question)
        setImage(QuestionBank, QuestionBank.Choice)
        setImage(QuestionBank, QuestionBank.Comment)
        setImage(QuestionBank, QuestionBank.ReTestComment)

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
    Private Shared Sub setImage(ByVal questionBank As QuestionBank, ByRef html As String)
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
        For Each filename In htImage
            img = Image.FromFile(folderPath & "\" & htImage(i))
            questionBank.Image(htImage(i)) = Utility.ImageToByteArray(img)
            replaceHtml = replaceHtml.Replace(folderName & "/" & htImage(i), htImage(i))
            i += 1
            img.Dispose()
        Next

        html = replaceHtml

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

    ''' <summary>
    ''' 表示用分類IDからカテゴリIDを取得します。
    ''' </summary>
    ''' <returns>カテゴリID、カテゴリ定義がない場合空文字列</returns>
    ''' <remarks></remarks>
    Private Shared Function GetCategoryID(ByVal displayId As String) As String
        Dim categoryID As String = String.Empty

        If displayId <> "" Then
            Dim category As DataTable = Common.CategoryMaster.GetAll

            Dim foundRows() As Data.DataRow
            foundRows = category.Select("DisplayId = '" & displayId & "'")

            If foundRows.Length = 0 Then
                categoryID = String.Empty
            Else
                categoryID = foundRows(0).Item(0)
            End If
        End If

        Return categoryID
    End Function
End Class
