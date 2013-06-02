Imports CST.CBT.eIPSTA.Common

Public Class GDataManager
    Inherits DataManager
#Region "----- メンバ変数 -----"
    ' ''' <summary>GDataManagerインスタンス</summary>
    Public Shared _instance As New GDataManager

    ''' <summary>問題ファイル名</summary>
    Private _QuestionFileName As String = ""
#End Region
#Region "----- プロパティ -----"
    ''' <summary>問題ファイル名の取得・設定</summary>
    Public Property QuestionFileName As String
        Get
            Return _QuestionFileName
        End Get
        Set(ByVal value As String)
            _QuestionFileName = value
        End Set
    End Property
#End Region
#Region "----- コンストラクタ -----"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Private Sub New()
        '_instance = New DataManager
    End Sub

    ''' <summary>
    ''' インスタンス取得
    ''' </summary>
    ''' <returns>DataManager</returns>
    Public Overloads Shared Function GetInstance() As GDataManager
        Return _instance
    End Function
#End Region

#Region "----- メソッド -----"
    Public Overloads Function Initialize() As Integer
        Dim errCode As Integer = Constant.ResultCode.NormalEnd

        Try
            '団体ファイル読込
            'errCode = ReadGroup()
            ''受講者ファイル読込
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadStudent()
            ''Mailファイル読込
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadMail()
            ''問題ファイル読み込み
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadQuestion()
            ''個人試験結果ヘッダファイル読込
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadTestResultHeader()
            ''個人試験結果詳細ファイル読込
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadTestResultDetail()
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 問題読み込み処理 ファイル指定
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadQuestionFile(ByVal FileName As String) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), FileName)
            Select Case questionFileNameList.Length
                Case 0
                    errCode = Constant.ResultCode.QuestionFileNotFoundError
                Case 1
                    Dim questionFileName = questionFileNameList(0)
                    Dim questionDataBankCollection = Serialize.BinaryFileToObject(IO.Path.GetFileName(questionFileName))
                    If questionDataBankCollection Is Nothing Then
                        errCode = Constant.ResultCode.QuestionFileReadError
                    Else
                        _QuestionDefineContainer = QuestionDefineCreator.Create(questionDataBankCollection)
                        If _QuestionDefineContainer Is Nothing Then
                            errCode = Constant.ResultCode.QuestionFileParseError
                        Else
                            _QuestionFileName = FileName
                            CreateDefineFile()  'debug only
                        End If
                    End If
                Case Else
                    errCode = Constant.ResultCode.QuestionFileReadError
            End Select
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try

        Return errCode
    End Function

#End Region
End Class
