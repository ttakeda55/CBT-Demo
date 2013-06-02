''' <summary>
''' SystemManager 内定義値
''' </summary>
''' <remarks></remarks>
Public Class Constant
    ''' <summary>
    ''' 戻り値用コード(Common.MessageIdにエラーコードは一致)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ResultCode
        ''' <summary>正常終了</summary>
        NormalEnd = 0
        ''' <summary>キャンセル</summary>
        Cancel

        ''' <summary>未定義エラー</summary>
        UndefineError = 700
        ''' <summary>Ftp送信エラー</summary>
        FtpSendError = 43
    End Enum

    Public Enum QuestionMessageCode
        LogoutConfirm = 700
    End Enum
End Class
