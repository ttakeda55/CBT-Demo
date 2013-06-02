
''' <summary>
''' PracticeQuestionBank クラスのラッパークラス
''' 問題定義オブジェクトを生成するための利便性をあげるためのクラス
''' </summary>
''' <remarks></remarks>
Public Class QuestionBankDecorator

#Region "----- 定数 -----"

    ''' <summary>
    ''' 中問設問ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const PRACTICE_MIDDLE_QUESTION_DIRECTORY_NAME As String = "PracticeMiddleQuestion"
    ''' <summary>
    ''' 小問ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const PRACTICE_QUESTION_DIRECTORY_NAME As String = "PracticeQuestion"
    ''' <summary>
    ''' 解説ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const PRACTICE_COMMENT_DIRECTORY_NAME As String = "PracticeComment"

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>QuestionBank オブジェクト</summary>
    Private _PracticeQuestionBank As Common.VetNurseQuestionBank

#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="PracticeQuestionBank">ラップする QuestionBank オブジェクト</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal PracticeQuestionBank As Common.VetNurseQuestionBank)
        Debug.Assert(PracticeQuestionBank Is Nothing = False)
        _PracticeQuestionBank = PracticeQuestionBank
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 問題コードを取得します。
    ''' </summary>
    ''' <returns>問題コード</returns>
    ''' <remarks></remarks>
    Public Function GetQuestionNumber() As String
        Return _PracticeQuestionBank.QuestionCode
    End Function

    ''' <summary>
    ''' 選択肢があるかどうか
    ''' </summary>
    ''' <returns>True : 選択肢がある、false : 選択肢がない</returns>
    ''' <remarks></remarks>
    Public Function HasChoice() As Boolean
        Dim ret As Boolean = False

        If String.IsNullOrEmpty(_PracticeQuestionBank.Choice) = False Then
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
        Return _PracticeQuestionBank.MiddleQuestionCode
    End Function

    ''' <summary>
    ''' カテゴリIDを取得します。
    ''' </summary>
    ''' <returns>カテゴリID、カテゴリ定義がない場合空文字列</returns>
    ''' <remarks></remarks>
    Public Function GetCategoryID() As String
        Return _PracticeQuestionBank.CategoryId
    End Function

    ''' <summary>
    ''' 問題テーマを取得します。
    ''' </summary>
    ''' <returns>問題テーマ、問題テーマがない場合空文字列</returns>
    ''' <remarks></remarks>
    Public Function GetTheme() As String
        Return _PracticeQuestionBank.Theme
    End Function

    ''' <summary>
    ''' 中問設問ファイルを作成します。
    ''' </summary>
    ''' <returns>作成した中問設問ファイルのフルパス、生成していない場合は空文字列</returns>
    ''' <remarks></remarks>
    Public Function CreateMiddleQuestionFile() As String
        Dim middleQuestionFilePath As String = String.Empty


        'Dim directoryName = String.Format("{0}{1}", _
        '                                      Common.Constant.GetTempPath,
        '                                      PRACTICE_MIDDLE_QUESTION_DIRECTORY_NAME)
        Dim directoryName = String.Format("{0}{1}\{2}", _
                                      Common.Constant.GetTempPath,
                                      PRACTICE_MIDDLE_QUESTION_DIRECTORY_NAME,
                                      GetMiddleNumber())
        IO.Directory.CreateDirectory(directoryName)
        middleQuestionFilePath = String.Format("{0}\{1}.html", _
                                                  directoryName, _
                                                  GetMiddleNumber())

        CreateFile(middleQuestionFilePath, _PracticeQuestionBank.GetQuestionHtml())

        If _PracticeQuestionBank.ImageCount > 0 Then
            For Each fileName As String In _PracticeQuestionBank.KeysImage
                CreateImageFile(directoryName, fileName)
            Next
        End If

        Return middleQuestionFilePath
    End Function

    ''' <summary>
    ''' 解説ファイルを作成します。
    ''' </summary>
    ''' <param name="questionCode">解説ファイル名に使用する問題コード</param>
    ''' <returns>作成した解説ファイルのフルパス、生成していない場合は空文字列</returns>
    ''' <remarks></remarks>
    Public Function CreateCommentFiles(ByVal questionCode As String) As String
        Dim commentFilePath As String = ""


        If String.IsNullOrEmpty(_PracticeQuestionBank.Comment) = False Then
            'Dim directoryName = String.Format("{0}{1}", _
            '                                  Common.Constant.GetTempPath,
            '                                  PRACTICE_COMMENT_DIRECTORY_NAME)
            Dim directoryName = String.Format("{0}{1}\{2}", _
                                  Common.Constant.GetTempPath,
                                  PRACTICE_COMMENT_DIRECTORY_NAME,
                                  questionCode)
            IO.Directory.CreateDirectory(directoryName)

            commentFilePath = String.Format("{0}\Comment{1}.html", _
                                              directoryName, _
                                              questionCode)

            Dim commentHtml As String = _PracticeQuestionBank.GetCommentHtml()

            CreateFile(commentFilePath, commentHtml)

            'コメント部で使用する画像の保存
            If _PracticeQuestionBank.ImageCount > 0 Then
                For Each fileName As String In _PracticeQuestionBank.KeysImage
                    Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches(commentHtml, fileName)
                    If mcsSelect.Count > 0 Then
                        CreateImageFile(directoryName, fileName)
                    End If
                Next
            End If
        End If

        Return commentFilePath
    End Function

    ''' <summary>
    ''' 問題と選択肢を連結したファイルを作成します。
    ''' </summary>
    ''' <param name="questionCode">ファイル名に使用する問題コード</param>
    ''' <returns>作成したファイルのフルパスのリスト</returns>
    ''' <remarks></remarks>
    Public Function CreateQuestionAndChoiceFiles(ByVal questionCode As String) As String

        Dim questionFilePath As String = ""

        Try
            'Dim directoryName = String.Format("{0}{1}", _
            '                                      Common.Constant.GetTempPath,
            '                                      PRACTICE_QUESTION_DIRECTORY_NAME)
            Dim directoryName = String.Format("{0}{1}\{2}", _
                                      Common.Constant.GetTempPath,
                                      PRACTICE_QUESTION_DIRECTORY_NAME,
                                      questionCode)
            IO.Directory.CreateDirectory(directoryName)
            questionFilePath = String.Format("{0}\Question{1}.html", _
                                                  directoryName, _
                                                  questionCode)

            CreateFile(questionFilePath, _PracticeQuestionBank.GetQuestionHtml)

            '設問＋選択肢部で使用する画像の保存
            If _PracticeQuestionBank.ImageCount > 0 Then
                For Each fileName As String In _PracticeQuestionBank.KeysImage
                    Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches(_PracticeQuestionBank.GetQuestionHtml, fileName)
                    If mcsSelect.Count > 0 Then
                        CreateImageFile(directoryName, fileName)
                    End If
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return questionFilePath
    End Function

    ''' <summary>
    ''' 正解答を取得します。
    ''' </summary>
    ''' <returns>正解答</returns>
    ''' <remarks></remarks>
    Public Function GetAnswer() As String
        Return _PracticeQuestionBank.Ansewr
    End Function

    ''' <summary>
    ''' 中設問用の QuestionBank オブジェクトかどうか
    ''' </summary>
    ''' <returns>True : 中設問用の QuestionBank オブジェクトである、False : 中設問用の QuestionBank オブジェクトでない</returns>
    ''' <remarks></remarks>
    Public Function IsMiddleQuestionOnly() As Boolean
        Dim ret As Boolean = False

        If _PracticeQuestionBank.IsMiddleMainQuestion Then
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

        If _PracticeQuestionBank.IsMiddleQuestion Then
            ret = True
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 指定のファイル名のイメージを QuestionBank から取り出し保存します。
    ''' </summary>
    ''' <param name="directoryPath">保存するディレクトリ名</param>
    ''' <param name="fileName">保存するファイル名</param>
    ''' <remarks></remarks>
    Private Sub CreateImageFile(ByVal directoryPath As String, ByVal fileName As String)
        Try
            Dim image As Image = CType(CST.CBT.CBTCommon.Utility.ByteArrayToImage(_PracticeQuestionBank.Image(fileName)).Clone, Image)
            image.Save(directoryPath & "\" & fileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
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
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

End Class
