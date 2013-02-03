''' <summary>
''' PracticeStudent 内定義値
''' </summary>
''' <remarks></remarks>
Public Class Constant

    ''' <summary>
    ''' 本プロセス削除用プロセス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DeleteProcessName As String = "DeleteStudent_Trial"

    ''' <summary>
    ''' ダウンロードディレクトリ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DownLoadDirectoryName As String = "DownLoad"

    ''' <summary>
    ''' ダウンロード圧縮ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DownLoadZipName As String = "DownLoadFile"

    ''' <summary>復号キーファイル名</summary>
    Public Const CST_DECRYPTIONKEY_FILENAME As String = "Decryptionkey"

    ''' <summary>
    ''' 戻り値用コード(Common.MessageIdにエラーコードは一致)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ResultCode
        ''' <summary>正常終了</summary>
        NormalEnd = 0
        ''' <summary>キャンセル</summary>
        Cancel
        ''' <summary>未定義エラー(800)</summary>
        UndefineError = 800
        ''' <summary>プロセス起動エラー(801)</summary>
        ProcessStartError
        ''' <summary>団体ファイル未存在エラー(802)</summary>
        GroupFileNotFoundError
        ''' <summary>団体ファイル読込エラー(803)</summary>
        GroupFileReadError
        ''' <summary>受講者ファイル未存在エラー(804)</summary>
        StudentFileNotFoundError
        ''' <summary>受講者ファイル読込エラー(805)</summary>
        StudentFileReadError
        ''' <summary>Mailファイル読込エラー(806)</summary>
        MailFileReadError
        ''' <summary>演習問題一覧ファイル未存在エラー(807)</summary>
        PracticeQuestionListFileNotFoundError
        ''' <summary>演習問題一覧ファイル読込エラー(808)</summary>
        PracticeQuestionListFileReadError
        ''' <summary>逐次演習結果ヘッダファイル読込エラー(809)</summary>
        SerialResultHeaderFileReadError
        ''' <summary>逐次演習結果明細ファイル読込エラー(810)</summary>
        SerialResultDetailFileReadError
        ''' <summary>小テスト結果ヘッダファイル読込エラー(811)</summary>
        MiniResultHeaderFileReadError
        ''' <summary>小テスト結果明細ファイル読込エラー(812)</summary>
        MiniResultDetailFileReadError
        ''' <summary>総合テスト結果ヘッダファイル読込エラー(813)</summary>
        SynthesisResultHeaderFileReadError
        ''' <summary>総合テスト結果明細ファイル読込エラー(814)</summary>
        SynthesisResultDetailFileReadError
        ''' <summary>指定テストヘッダファイル未存在エラー(815)</summary>
        SpecificHeaderFileNotFoundError
        ''' <summary>指定テストヘッダファイル読込エラー(816)</summary>
        SpecificHeaderFileReadError
        ''' <summary>指定テスト明細ファイル未存在エラー(817)</summary>
        SpecificDetailFileNotFoundError
        ''' <summary>指定テスト明細ファイル読込エラー(818)</summary>
        SpecificDetailFileReadError
        ''' <summary>総合テストヘッダファイル未存在エラー(819)</summary>
        SynthesisHeaderFileNotFoundError
        ''' <summary>総合テストヘッダファイル読込エラー(820)</summary>
        SynthesisHeaderFileReadError
        ''' <summary>総合テスト明細ファイル未存在エラー(821)</summary>
        SynthesisDetailFileNotFoundError
        ''' <summary>総合テスト明細ファイル読込エラー(822)</summary>
        SynthesisDetailFileReadError
        ''' <summary>問題群ファイル未存在エラー(823)</summary>
        CollectionFileNotFoundError
        ''' <summary>問題群ファイル読込エラー(824)</summary>
        CollectionFileReadError
        ''' <summary>再演習ファイル読込エラー(825)</summary>
        ReviewFileReadError
        ''' <summary>カテゴリーファイル未存在エラー(826)</summary>
        CategoryFileNotFoundError
        ''' <summary>カテゴリーファイル読込エラー(827)</summary>
        CategoryFileReadError
        ''' <summary>アップロードエラー(828)</summary>
        UploadError
        ''' <summary>問題ファイル未存在エラー(829)</summary>
        QuestionFileNotFoundError
        ''' <summary>問題ファイル内解析エラー(830)</summary>
        QuestionFileParseError
        ''' <summary>問題ファイル読み込みエラー(831)</summary>
        QuestionFileReadError
        ''' <summary>復号キー不正エラー(832)</summary>
        DecryptionkeyError
        ''' <summary>アプリケーション過去バージョンエラー(833)</summary>
        AppOldError
        ''' <summary>復号キー過去バージョンエラー(834)</summary>
        DecryptionkeyOldError
        ''' <summary>逐次演習結果ヘッダオブジェクト追加エラー(835)</summary>
        AddSerialResultHeader
        ''' <summary>逐次演習結果詳細オブジェクト追加エラー(836)</summary>
        AddSerialResultDetail
        ''' <summary>小テスト結果ヘッダオブジェクト追加エラー(837)</summary>
        AddMiniResultHeader
        ''' <summary>小テスト結果詳細オブジェクト追加エラー(838)</summary>
        AddMiniResultDetail
        ''' <summary>総合テスト結果ヘッダオブジェクト追加エラー(839)</summary>
        AddSynthesisResultHeader
        ''' <summary>総合テスト結果詳細オブジェクト追加エラー(840)</summary>
        AddSynthesisResultDetail
        ''' <summary>バックアップファイル作成エラー(841)</summary>
        CreateBackUpFile
        ''' <summary>演習問題読み込みエラー(842)</summary>
        CheckReadComplete
        ''' <summary>再演習オブジェクト追加エラー(843)</summary>
        AddReviewDataRow
        ''' <summary>ファイルダウンロードエラー(844)</summary>
        DownLoadFileError
        ''' <summary>団体アンマッチエラー(845)</summary>
        DecryptionkeyGroupError
        ''' <summary>Helpディレクトリ未存在エラー</summary>
        HelpDirectoryNotFoundError
        ''' <summary>模擬説明ファイル未存在エラー</summary>
        HelpFileNotFoundError
    End Enum

    ''' <summary>
    ''' 確認ダイアログメッセージID(Common.MessageIdのQメッセージID)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum QuestionMessageCode
        ''' <summary>ログアウト確認</summary>
        LogoutConfirm = 800
        ''' <summary>テスト終了確認</summary>
        TestEndConfirm = 801
    End Enum

    ''' <summary>
    ''' 情報ダイアログメッセージID(Common.MessageIdのIメッセージID)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum InformationMessageCode
        ''' <summary>ダウンロード中</summary>
        DownLoadWhileInfo = 800
    End Enum

    ''' <summary>ファイル種別</summary>
    Public Enum FileType As Integer
        ''' <summary>逐次演習結果_ヘッダ</summary>
        SerialResultHeader = 0
        ''' <summary>逐次演習結果_明細</summary>
        SerialResultDetail
        ''' <summary>小テスト結果_ヘッダ</summary>
        MiniResultHeader
        ''' <summary>小テスト結果_明細</summary>
        MiniResultDetail
        ''' <summary>総合テスト結果_ヘッダ</summary>
        SynthesisResultHeader
        ''' <summary>総合テスト結果_明細</summary>
        SynthesisResultDetail
        ''' <summary>再演習</summary>
        Review
    End Enum

    ''' <summary>テスト結果種別</summary>
    Public Enum TestType As Integer
        ''' <summary>逐次演習結果</summary>
        SerialResult = 1
        ''' <summary>小テスト結果</summary>
        MiniResult = 2
        ''' <summary>総合テスト結果</summary>
        SynthesisResult = 3
        ''' <summary>再演習結果</summary>
        ReviewResult = 4
    End Enum
    ''' <summary>
    ''' 残り時間(2時間45分=165分)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly InitialeRemainingTime As New TimeSpan(Configuration.ConfigurationManager.AppSettings("HOURS"),
                                                                 Configuration.ConfigurationManager.AppSettings("MINUTES"),
                                                                 Configuration.ConfigurationManager.AppSettings("SECONDS"))
End Class
