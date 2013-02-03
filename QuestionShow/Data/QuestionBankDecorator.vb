''' <summary>
''' QuestionBank クラスのラッパークラス
''' 問題定義オブジェクトを生成するための利便性をあげるためのクラス
''' </summary>
''' <remarks></remarks>
Public Class QuestionBankDecorator

#Region "----- 定数 -----"
    ''' <summary>
    ''' 中問用設問ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const MIDDLE_QUESTION_DIRECTORY_NAME As String = "MiddleQuestion"
    ''' <summary>
    ''' 小問ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const QUESTION_DIRECTORY_NAME As String = "Question"
    ''' <summary>
    ''' 解説ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const COMMENT_DIRECTORY_NAME As String = "Comment"
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>
    ''' QuestionBank オブジェクト
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionBank As Common.QuestionBank
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="QuestionBank">ラップする QuestionBank オブジェクト</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal QuestionBank As Common.QuestionBank)
        Debug.Assert(QuestionBank Is Nothing = False)
        _QuestionBank = QuestionBank
    End Sub

    ''' <summary>
    ''' 中問タグがあるかどうか。
    ''' </summary>
    ''' <returns>True : 中問タグがある、 false : 中問タグがない</returns>
    ''' <remarks></remarks>
    Public Function HasMiddleQuestionTag() As Boolean
        Dim ret As Boolean = True

        If _QuestionBank.QuestionProperty(Common.Constant.CST_MULTI) Is Nothing Then
            ret = False
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 選択肢があるかどうか
    ''' </summary>
    ''' <returns>True : 選択肢がある、false : 選択肢がない</returns>
    ''' <remarks></remarks>
    Public Function HasChoice() As Boolean
        Dim ret As Boolean = False

        If String.IsNullOrEmpty(_QuestionBank.Choice) = False Then
            ret = True
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 中問番号を取得します。
    ''' </summary>
    ''' <returns>中問番号、中問出ない場合は、空文字列</returns>
    ''' <remarks></remarks>
    Public Function GetMiddleNumber() As String
        Dim middleNumber As String = String.Empty

        If HasMiddleQuestionTag() Then
            middleNumber = _QuestionBank.QuestionProperty(Common.Constant.CST_MULTI)
        End If

        Return middleNumber
    End Function

    ''' <summary>
    ''' カテゴリIDを取得します。
    ''' @note QuestionBank に設定されているカテゴリIDはDisplayIdのため
    ''' DisplayId から CategoryId を検索して返します。
    ''' </summary>
    ''' <returns>カテゴリID、カテゴリ定義がない場合空文字列</returns>
    ''' <remarks></remarks>
    Public Function GetCategoryID() As String
        'Dim categoryID As String = String.Empty

        'If _QuestionBank.QuestionProperty(Common.Constant.CST_CATEGORY) Is Nothing = False Then
        '    categoryID = _QuestionBank.QuestionProperty(Common.Constant.CST_CATEGORY)

        '    Dim category As DataTable = Common.CategoryMaster.GetAll()

        '    Dim foundRows() As Data.DataRow
        '    foundRows = category.Select("DisplayId = '" & categoryID & "'")

        '    If foundRows.Length = 0 Then
        '        categoryID = String.Empty
        '    Else
        '        categoryID = foundRows(0).Item(0)
        '    End If
        'End If
        '
        'Return categoryID
        Return _QuestionBank.QuestionProperty(Common.Constant.CST_CATEGORY)
    End Function

    ''' <summary>
    ''' 問題テーマを取得します。
    ''' </summary>
    ''' <returns>問題テーマ、問題テーマがない場合空文字列</returns>
    ''' <remarks></remarks>
    Public Function GetTheme() As String
        Dim theme As String = String.Empty

        If _QuestionBank.QuestionProperty(Common.Constant.CST_THEME) Is Nothing = False Then
            theme = _QuestionBank.QuestionProperty(Common.Constant.CST_THEME)
        End If

        Return theme
    End Function

    ''' <summary>
    ''' 中問設問ファイルを作成します。
    ''' </summary>
    ''' <returns>作成した中問設問ファイルのフルパス、生成していない場合は空文字列</returns>
    ''' <remarks></remarks>
    Public Function CreateMiddleQuestionFile() As String
        Dim middleQuestionFilePath As String = String.Empty

        If HasMiddleQuestionTag() AndAlso String.IsNullOrEmpty(_QuestionBank.Choice) Then
            Dim directoryName = String.Format("{0}{1}", _
                                                  Common.Constant.GetTempPath,
                                                  MIDDLE_QUESTION_DIRECTORY_NAME)
            IO.Directory.CreateDirectory(directoryName)
            middleQuestionFilePath = String.Format("{0}\{1}.html", _
                                                      directoryName, _
                                                      GetMiddleNumber())

            CreateFile(middleQuestionFilePath, _QuestionBank.GetQuestionHtml())

            If _QuestionBank.ImageCount > 0 Then
                For Each fileName As String In _QuestionBank.KeysImage
                    CreateImageFile(directoryName, fileName)
                Next
            End If
        End If

        Return middleQuestionFilePath
    End Function

    ''' <summary>
    ''' 解説ファイルを初回試験用、再試験用で作成します。
    ''' </summary>
    ''' <param name="questionNumber">解説ファイル名に使用する問題番号</param>
    ''' <returns>作成した解説ファイルのフルパス、生成していない場合は空文字列</returns>
    ''' <remarks></remarks>
    Public Function CreateCommentFiles(ByVal questionNumber As Integer) As List(Of String)
        Dim commentFilePaths As New List(Of String)

        For testCount As Constant.TestCounts = Constant.TestCounts.FirstTest To Constant.TestCounts.Max - 1
            If String.IsNullOrEmpty(_QuestionBank.Comment) = False Then
                Dim directoryName = String.Format("{0}{1}{2}", _
                                                  Common.Constant.GetTempPath,
                                                  COMMENT_DIRECTORY_NAME,
                                                  testCount + 1)
                IO.Directory.CreateDirectory(directoryName)
                Dim commentFilePath = String.Format("{0}\Comment{1:D3}.html", _
                                                  directoryName, _
                                                  questionNumber)

                commentFilePaths.Add(commentFilePath)

                Dim commentHtml As String = _QuestionBank.GetCommentHtml()

                If testCount = Constant.TestCounts.SecondTest AndAlso String.IsNullOrEmpty(_QuestionBank.ReTestComment) = False Then
                    commentHtml = _QuestionBank.GetReTestCommentHtml()
                End If

                CreateFile(commentFilePath, commentHtml)

                'コメント部で使用する画像の保存
                If _QuestionBank.ImageCount > 0 Then
                    For Each fileName As String In _QuestionBank.KeysImage
                        Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches(commentHtml, fileName)
                        If mcsSelect.Count > 0 Then
                            CreateImageFile(directoryName, fileName)
                        End If
                    Next
                End If
            End If
        Next

        Return commentFilePaths
    End Function

    ''' <summary>
    ''' 問題と選択肢を連結したファイルを、初回試験用、再試験用で作成します。
    ''' </summary>
    ''' <param name="questionNumber">ファイル名に使用する問題番号</param>
    ''' <returns>作成したファイルのフルパスのリスト</returns>
    ''' <remarks></remarks>
    Public Function CreateQuestionAndChoiceFiles(ByVal questionNumber As Integer) As List(Of String)

        Dim questionFilePaths As New List(Of String)

        Try
            Dim sortedChoiceList As List(Of String) = ChoiceParser.Parse(_QuestionBank.Choice)
            For testCount As Constant.TestCounts = Constant.TestCounts.FirstTest To Constant.TestCounts.Max - 1
                Dim directoryName = String.Format("{0}{1}{2}", _
                                                  Common.Constant.GetTempPath,
                                                  QUESTION_DIRECTORY_NAME,
                                                  testCount + 1)
                IO.Directory.CreateDirectory(directoryName)

                questionFilePaths.Add(String.Format("{0}\Question{1:D3}.html", _
                                                      directoryName, _
                                                      questionNumber))

                '設問＋選択肢部の文字列の取得
                Dim questionAndChoiceHtmlString As String = CreateQuestionAndChoiceHtmlString(sortedChoiceList(testCount))
                CreateFile(questionFilePaths(testCount), _
                               questionAndChoiceHtmlString)

                '設問＋選択肢部で使用する画像の保存
                If _QuestionBank.ImageCount > 0 Then
                    For Each fileName As String In _QuestionBank.KeysImage
                        Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches(questionAndChoiceHtmlString, fileName)
                        If mcsSelect.Count > 0 Then
                            CreateImageFile(directoryName, fileName)
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return questionFilePaths
    End Function

    ''' <summary>
    ''' 初回試験用の正解答を取得します。
    ''' </summary>
    ''' <returns>初回試験用の正解答</returns>
    ''' <remarks></remarks>
    Public Function GetFirstAnswer() As String
        Return _QuestionBank.FirstAnsewr
    End Function

    ''' <summary>
    ''' 再試験用の正解答
    ''' </summary>
    ''' <returns>再試験用の正解答</returns>
    ''' <remarks></remarks>
    Public Function GetSecondAnswer() As String
        Return _QuestionBank.SecondAnsewr
    End Function

    ''' <summary>
    ''' 中設問用の QuestionBank オブジェクトかどうか
    ''' </summary>
    ''' <returns>True : 中設問用の QuestionBank オブジェクトである、False : 中設問用の QuestionBank オブジェクトでない</returns>
    ''' <remarks></remarks>
    Public Function IsMiddleQuestionOnly() As Boolean
        Dim ret As Boolean = False

        If HasMiddleQuestionTag() AndAlso HasChoice() = False Then
            ret = True
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 中設問内の小説問であるか。
    ''' </summary>
    ''' <returns>True : 中設問内の小説問である、False : 中設問内の小説問でない</returns>
    ''' <remarks></remarks>
    Public Function IsSmallQuestionInMiddleQuestion() As Boolean
        Dim ret As Boolean = False

        If HasMiddleQuestionTag() AndAlso HasChoice() Then
            ret = True
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 指定のソート済みで選択肢が一つの選択肢部のHTML文字列から、問題と選択肢を連結した文字列を生成し返します。
    ''' </summary>
    ''' <param name="choiceHtmlString">指定のソート済みで選択肢が一つの選択肢部のHTML文字列</param>
    ''' <returns>問題と選択肢を連結した文字列</returns>
    ''' <remarks></remarks>
    Private Function CreateQuestionAndChoiceHtmlString(ByVal choiceHtmlString As String) As String
        '元の QuestionBank オブジェクトの選択肢部文字列は変更しないようにコピーを使用する。
        Dim bufQuestionBank As Common.QuestionBank = _QuestionBank.DeepCopy()
        bufQuestionBank.Choice = choiceHtmlString
        Return bufQuestionBank.GetQuestionHtml
    End Function

    ''' <summary>
    ''' 指定のファイル名のイメージを QuestionBank から取り出し保存します。
    ''' </summary>
    ''' <param name="directoryPath">保存するディレクトリ名</param>
    ''' <param name="fileName">保存するファイル名</param>
    ''' <remarks></remarks>
    Private Sub CreateImageFile(ByVal directoryPath As String, ByVal fileName As String)
        Try
            Dim image As Image = CType(CST.CBT.CBTCommon.Utility.ByteArrayToImage(_QuestionBank.Image(fileName)).Clone, Image)
            image.Save(directoryPath & "\" & fileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 指定のファイルパスのファイルをUTF8で新規生成し、指定の内容を書き込み保存します。
    ''' </summary>
    ''' <param name="filePath">生成するファイルパス</param>
    ''' <param name="body">書き込む内容</param>
    ''' <remarks></remarks>
    Private Sub CreateFile(ByVal filePath As String, ByVal body As String)
        Try
            Dim sw As New System.IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
            sw.Write(body)
            sw.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

End Class
