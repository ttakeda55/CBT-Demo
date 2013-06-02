''' <summary>
''' Student 内定義値
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
        ''' <summary>問題ファイル未存在エラー</summary>
        QuestionFileNotFoundError
        ''' <summary>問題ファイル読み込みエラー</summary>
        QuestionFileReadError
        ''' <summary>問題ファイル内解析エラー</summary>
        QuestionFileParseError
        ''' <summary>団体ファイル未存在エラー</summary>
        GroupFileNotFoundError
        ''' <summary>団体ファイル読込エラー</summary>
        GroupFileReadError
        ''' <summary>受講者ファイル未存在エラー</summary>
        StudentFileNotFoundError
        ''' <summary>受講者ファイル読込エラー</summary>
        StudentFileReadError
        ''' <summary>Mailファイル未存在エラー</summary>
        MailFileNotFoundError
        ''' <summary>Mailファイル読込エラー</summary>
        MailFileReadError
        ''' <summary>個人試験結果ヘッダファイル読込エラー</summary>
        TestResultHeaderFileReadError
        ''' <summary>個人試験結果詳細ファイル読込エラー</summary>
        TestResultDetailFileReadError
        ''' <summary>Ftp送信エラー</summary>
        FtpSendError
        ''' <summary>プロセス起動エラー</summary>
        ProcessStartError
        ''' <summary>模擬説明ファイル未存在エラー</summary>
        HelpFileNotFoundError
        ''' <summary>個人試験結果ヘッダオブジェクト追加エラー</summary>
        AddTestResultHeader
        ''' <summary>個人試験結果詳細オブジェクト追加エラー</summary>
        AddTestResultDetail
        ''' <summary>帳票Ａファイル未存在エラー</summary>
        LedgerSheetAFileNotFoundError
        ''' <summary>個人試験結果ヘッダファイル未存在エラー</summary>
        TestResultHeaderFileNotFoundError
        ''' <summary>個人試験結果詳細ファイル未存在エラー</summary>
        TestResultDetailFileNotFoundError
        ''' <summary>Helpディレクトリ未存在エラー</summary>
        HelpDirectoryNotFoundError
    End Enum

    ''' <summary>
    ''' 確認ダイアログメッセージID(Common.MessageIdのQメッセージID)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum QuestionMessageCode
        ''' <summary>ログアウト確認</summary>
        LogoutConfirm = 700
    End Enum


    ''' <summary>
    ''' テスト回数
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TestCounts
        ''' <summary>初回試験</summary>
        FirstTest = 0
        ''' <summary>再試験</summary>
        SecondTest
        Max
    End Enum

    ''' <summary>
    ''' 本プロセス削除用プロセス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DeleteProcessName As String = "DeleteGroup"

    ''' <summary>
    ''' 残り時間(2時間45分=165分)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly InitialeRemainingTime As New TimeSpan(2, 45, 0)
End Class
