<Serializable()> _
Public Class VetNurseQuestionBank
    Inherits Common.PracticeQuestionBank

#Region "----- メンバ変数 -----"
    ''' <summary>難易度</summary>
    Private _level As String = String.Empty
    ''' <summary>
    ''' 動画
    ''' </summary>
    Private _movie As FileContents
    ''' <summary>
    ''' 小問ファイル格納ディレクトリ名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const QUESTION_DIRECTORY_NAME As String = "PracticeQuestion"
 
#End Region

#Region "----- 定数 -----"
    Enum QuestionType As Integer
        a

    End Enum
#End Region
#Region "難易度"
    ''' <summary>
    ''' 難易度を取得/設定します。
    ''' </summary>
    Public Property Level() As String
        Get
            Return _level
        End Get
        Set(ByVal value As String)
            _level = StrConv(value, VbStrConv.Narrow)
        End Set
    End Property

#End Region
#Region "----- メソッド -----"

    ''' <summary>
    ''' 問題と選択肢を連結したファイルを、初回試験用、再試験用で作成します。
    ''' </summary>
    ''' <returns>作成したファイルのフルパスのリスト</returns>
    ''' <remarks></remarks>
    Public Function CreateQuestion() As String

        Dim questionFilePath As String = ""

        Try
            Dim directoryName = String.Format("{0}{1}", _
                                                Common.Constant.GetTempPath,
                                                QUESTION_DIRECTORY_NAME)
            IO.Directory.CreateDirectory(directoryName)

            questionFilePath = String.Format("{0}\Question{1:D3}.html", _
                                                    directoryName, _
                                                    QuestionCode)
            '設問＋選択肢部の文字列の取得
            CreateFile(questionFilePath, _
                            MyBase.GetQuestionHtml)

            '設問＋選択肢部で使用する画像の保存
            If MyBase.ImageCount > 0 Then
                For Each fileName As String In MyBase.KeysImage
                    Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches(MyBase.Question, fileName)
                    If mcsSelect.Count > 0 Then
                        CreateImageFile(directoryName, fileName)
                    End If
                Next
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return questionFilePath
    End Function

    ''' <summary>
    ''' 問題と選択肢を連結したファイルを、初回試験用、再試験用で作成します。
    ''' </summary>
    ''' <param name="WordfileName">保存するファイル名</param>
    ''' <remarks></remarks>
    Public Sub CreateQuestionWord(ByVal WordfileName As String, ByVal Cnt As Integer, ByVal Header As String)


        'Dim questionFilePath As String = ""

        Try

            'Dim directoryName = String.Format("{0}{1}", _
            '                                    Common.Constant.GetTempPath,
            '                                    QUESTION_DIRECTORY_NAME)

            Dim directoryName As String = System.IO.Path.GetDirectoryName(WordfileName)
            IO.Directory.CreateDirectory(directoryName)

            'questionFilePath = String.Format("{0}\Question{1:D3}.doc", _
            '                                        directoryName, _
            '                                        WordfileName)

            '設問の文字列の取得
            Dim sw As New System.IO.StreamWriter(WordfileName, IIf(Cnt = 1, False, True), System.Text.Encoding.GetEncoding("shift_jis"))
            If Cnt = 1 Then
                sw.Write(MyBase.GetQuestionHtmlH)
            End If
            sw.Write("<P class=MsoNormal><SPAN style=""FONT-FAMILY: 'ＭＳ ゴシック'; FONT-SIZE: 12pt"" lang=AR-SA>" & Header & "</SPAN></P>")
            sw.Write(MyBase.GetQuestionHtmlB)
            sw.Close()

            '設問＋選択肢部で使用する画像の保存
            If MyBase.ImageCount > 0 Then
                For Each fileName As String In MyBase.KeysImage
                    Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches(MyBase.Question, fileName)
                    If mcsSelect.Count > 0 Then
                        CreateImageFile(directoryName, fileName)
                    End If
                Next
            End If

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' 指定のファイル名のイメージを QuestionBank から取り出し保存します。
    ''' </summary>
    ''' <param name="directoryPath">保存するディレクトリ名</param>
    ''' <param name="fileName">保存するファイル名</param>
    ''' <remarks></remarks>
    Private Sub CreateImageFile(ByVal directoryPath As String, ByVal fileName As String)
        Try
            Dim image As Image = CType(CST.CBT.CBTCommon.Utility.ByteArrayToImage(MyBase.Image(fileName)).Clone, Image)
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

    ''' <summary>
    ''' 動画ファイルを読み込む
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Sub ReadMovie(ByVal filePath As String)
        If IO.File.Exists(filePath) Then
            _movie = New FileContents
            _movie.FileName = IO.Path.GetFileName(filePath)
            _movie.Contents = IO.File.ReadAllBytes(filePath)
        End If
    End Sub


    ''' <summary>
    ''' 動画ファイルを書きだす
    ''' </summary>
    ''' <param name="overWrite">
    ''' True:上書き
    ''' False:上書きしない
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WriteMovie(Optional ByVal overWrite As Boolean = False) As String
        Dim exportFilePath As String = ""
        If IsMovie() Then
            Dim directoryName As String = Common.Constant.GetTempPath & "Movie\" & QuestionCode & "\"
            If Not IO.Directory.Exists(directoryName) Then
                IO.Directory.CreateDirectory(directoryName)
            End If
            exportFilePath = directoryName & _movie.FileName

            If overWrite Or IO.File.Exists(exportFilePath) = False Then
                IO.File.WriteAllBytes(exportFilePath, _movie.Contents)
            End If
        End If

        Return exportFilePath
    End Function

    ''' <summary>
    ''' 動画が存在するかどうか
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsMovie() As Boolean
        If _movie Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region
    <Serializable()> _
    Public Class FileContents
        Private _fileName As String
        Private _contents As Byte()

        ''' <summary>
        ''' ファイル名を取得/設定します。
        ''' </summary>
        Public Property FileName() As String
            Get
                Return _fileName
            End Get
            Set(ByVal value As String)
                _fileName = value
            End Set
        End Property

        ''' <summary>
        ''' コンテンツを取得/設定します。
        ''' </summary>
        Public Property Contents() As Byte()
            Get
                Return _contents
            End Get
            Set(ByVal value As Byte())
                _contents = value
            End Set
        End Property
    End Class
End Class
