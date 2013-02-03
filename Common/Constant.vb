Imports System.IO
Public Class Constant

    Public Const CST_EXTENSION_XML As String = ".xml"
    Public Const CST_EXTENSION_TXT As String = ".txt"

    ''' <summary>
    ''' グループ名
    ''' </summary>
    Public Const CST_GROUPNAME As String = "VETNurse"

    ''' <summary>
    ''' システムユーザ
    ''' </summary>
    Public Const CST_SYTEMUSER_FILENAME As String = "SystemUser"

    ''' <summary>
    ''' 問題ファイル名
    ''' </summary>
    Public Const CST_QUESTION_FILENAME As String = "Question"

    ''' <summary>
    ''' 団体ファイル名
    ''' </summary>
    Public Const CST_GROUP_FILENAME As String = "Group"

    ''' <summary>
    ''' 受講者ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_STUDENT_FILENAME As String = "Student"

    ''' <summary>
    ''' 個人試験結果_ヘッダファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_TESTHEAD_FILENAME As String = "TestResultHeader"

    ''' <summary>
    ''' 個人試験結果_明細ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_TESTDETAIL_FILENAME As String = "TestResultDetail"

    ''' <summary>
    ''' 試験結果集計_ヘッダファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_TESTHEADSUM_FILENAME As String = "TestResultHeader"

    ''' <summary>
    ''' 試験結果集計_明細ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_TESTDETAILSUM_FILENAME As String = "TestResultDetail"

    ''' <summary>
    ''' 模擬テスト配信ファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_DELIVERY_FILENAME As String = "Delivery"

    ''' <summary>
    ''' メールファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MAIL_FILENAME As String = "Mail"

    ''' <summary>
    ''' メールファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CATEGORY_FILENAME As String = "Category"

    ''' <summary>
    '''演習問題
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_PRACTICEQUESTION_FILENAME As String = "PracticeQuestion"

    ''' <summary>
    '''演習問題（中問）
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_PRACTICEQUESTIONMIDDLE_FILENAME As String = "PracticeQuestionMiddle"

    ''' <summary>
    '''再演習
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_REVIEW_FILENAME As String = "Review"

    ''' <summary>
    '''逐次演習結果_ヘッダ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SERIALRESULTHEADER_FILENAME As String = "SerialResultHeader"

    ''' <summary>
    '''逐次演習結果_明細
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SERIALRESULTDETAIL_FILENAME As String = "SerialResultDetail"

    ''' <summary>
    '''小テスト結果_ヘッダ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MINIRESULTHEADER_FILENAME As String = "MiniResultHeader"

    ''' <summary>
    '''小テスト結果_明細
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MINIRESULTDETAIL_FILENAME As String = "MiniResultDetail"

    ''' <summary>
    '''総合テスト結果_ヘッダ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SYNTHESISRESULTHEADER_FILENAME As String = "SynthesisResultHeader"

    ''' <summary>
    '''総合テスト結果_明細
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SYNTHESISRESULTDETAIL_FILENAME As String = "SynthesisResultDetail"

    ''' <summary>
    '''総合テスト_ヘッダ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SYNTHESISHEADER_FILENAME As String = "SynthesisHeader"

    ''' <summary>
    '''総合テスト_明細
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SYNTHESISDETAIL_FILENAME As String = "SynthesisDetail"

    ''' <summary>
    '''指定テスト_ヘッダ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SPECIFICHEADER_FILENAME As String = "SpecificHeader"

    ''' <summary>
    '''指定テスト_明細
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SPECIFICDETAIL_FILENAME As String = "SpecificDetail"

    ''' <summary>
    '''コース
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_COURSE_FILENAME As String = "Course"

    ''' <summary>
    '''模擬テスト一覧
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_QUESTIONLIST_FILENAME As String = "QuestionList"

    ''' <summary>
    '''演習問題一覧
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_PRACTICEQUESTIONLIST_FILENAME As String = "PracticeQuestionList"

    ''' <summary>
    '''問題群
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_COLLECTION_FILENAME As String = "Collection"

    ''' <summary>
    '''WebServiceUrl
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_WEBSERVICEURL_FILENAME As String = "WebServiceUrl"

    ''' <summary>
    '''お知らせファイル
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_INFOMATION_FILENAME As String = "Information"

    ''' <summary>
    '''テスト名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_TESTNAME_FILENAME As String = "TestName"

    ''' <summary>
    ''' 属性識別記号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_IDENTIFICATIONMARK As String = "!#"
    Public Const CST_PROPERTY As String = "!#属性"
    Public Const CST_QUESTION As String = "!#設問"
    Public Const CST_SELECT As String = "!#選択肢"
    Public Const CST_COMMENT As String = "!#解説"
    Public Const CST_RETESTCOMMENT As String = "!#解説再"
    Public Const CST_CATEGORY As String = "!#分類"
    Public Const CST_DISPLAYID As String = "!#表示用分類ID"
    Public Const CST_THEME As String = "!#キーワード"
    Public Const CST_LEVEL As String = "!#難易度"
    Public Const CST_ANSWER As String = "!#正解"
    Public Const CST_MULTI As String = "!#中問"
    Public Const CST_CATEGORYID As String = "!#グループID"
    Public Const CST_QUESTIONCODE As String = "!#問題コード"
    Public Const CST_MIDDLEQUESTIONCODE As String = "!#中問コード"
    Public Const CST_FORMAT As String = "!#出題形式"
    Public Const CST_PRACTICEQUESTION As String = "!#演習問題"
    Public Const CST_MOCKTEST As String = "!#模擬テスト"
    Public Const CST_NEWMAIL As String = "<!#NewMail>"

    ''' <summary>
    ''' 選択肢記号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SELECTMARK As String = "ｱｲｳｴ"

    ''' <summary>
    ''' 選択肢記号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SELECTMARK_PRACTICEQUESTION As String = "アイエウ"

    ''' <summary>
    ''' 正解タグ
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_ANSEWR_TAG_STR As String = "<U>"
    Public Const CST_ANSEWR_TAG_END As String = "</U>"

    ''' <summary>
    ''' 総合評価
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_TOTALASSESSMENT As String = "総合評価"

    ''' <summary>
    ''' 分
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MINUTE As String = "分"

    ''' <summary>
    ''' 点
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_SCORE As String = "点"

    ''' <summary>
    ''' 問
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_QUESTION_UNIT As String = "問"

    ''' <summary>
    ''' コース名
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_COURSE As String() = {"", "模擬テスト１", "模擬テスト２", "模擬テスト３"}

    ''' <summary>
    ''' 状態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_STATE As String() = {"", "運用準備中", "運用中", "運用停止"}

    ''' <summary>
    ''' 受験回
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_TESTCOUNT As String() = {"未受験", "初回受験", "再受験"}

    ''' <summary>
    ''' 合否判定
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_CONSTRESULT As String() = {"不合格", "合格"}

    ''' <summary>
    ''' 受験回コンボ用
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_TESTCOUNT_CMB As String() = {"全て", "初回受験のみ", "再受験のみ", "未受験"}

    ''' <summary>
    ''' 受験回コンボ用(未受験なし)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_TESTCOUNT2_CMB As String() = {"全て", "初回受験のみ", "再受験のみ"}

    ''' <summary>
    '''区分１
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_SECTION1_CMB As String() = {"", "１", "２", "３", "４", "５", "６", "７", "８", "９"}

    ''' <summary>
    '''区分２
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_SECTION2_CMB As String() = {"", "Ａ", "Ｂ", "Ｃ", "Ｄ", "Ｅ", "Ｆ", "Ｇ", "Ｈ", "Ｉ", "Ｊ", "Ｋ", "Ｌ", "Ｍ", "Ｎ", "Ｏ", "Ｐ", "Ｑ", "Ｒ", "Ｓ", "Ｔ", "Ｕ", "Ｖ", "Ｗ", "Ｘ", "Ｙ", "Ｚ"}

    ''' <summary>
    ''' 合否
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_PASS_CMB As String() = {"全て", "合格のみ", "不合格のみ"}

    ''' <summary>
    ''' コース名
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_COURSE_STATE As String() = {"利用終了", "利用中", "準備中"}

    ''' <summary>
    ''' すべて
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_ALL As String = "すべて"

    ''' <summary>
    ''' 新状態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_NEW_STATE As String() = {CST_ALL, "準備中", "稼働中", "稼働停止"}

    ''' <summary>
    ''' 状態、検索用
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_STATE_SEARCH As String() = {"", "運用準備中", "運用中", "運用準備中／運用中", "運用停止"}

    ''' <summary>
    ''' 新状態、検索用
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_NEW_STATE_SEARCH As String() = {CST_ALL, "準備中", "稼働中", "準備中／稼働中", "稼働停止"}

    ''' <summary>
    ''' 問題タイプ
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_QUESTION_TYPE As String() = {"CBT1", "CBT2", "マーク"}

    ''' <summary>
    ''' パスワードに使用する文字
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_PASSWORDCHARS As String = "23456789abcdefghijkmnpqrstuvwxyz"

    ''' <summary>
    ''' パスワードに使用できない文字
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_PASSWORDCHARS_NG As String = "01ol"

    ''' <summary>
    ''' ファイル名に使用できない文字
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_FILENAMECHARS_NG As String = "\/:*?""<>|"

    ''' <summary>
    ''' 難易度記号
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_LEVELCHARS As String = "123"

    ''' <summary>
    ''' 正解記号
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly CST_ANSWERCHARS As String = "ＡＢＣＤＥ"

    ''' <summary>
    ''' センターサーバデータ格納パス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CENTERSERVER_DATA As String = "C:\inetpub\e-IPSTA\Data\"

    ''' <summary>
    ''' センターサーバアップロードデータ格納パス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CENTERSERVER_UPLOAD As String = "C:\inetpub\e-IPSTA\UpLoad\"

    ''' <summary>
    ''' センターサーバアップロードデータ格納パス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CENTERSERVER_UPLOADARCHIVE As String = "C:\inetpub\e-IPSTA\UpLoadArchive\"

    ''' <summary>
    ''' センターサーバインストーラ格納パス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CENTERSERVER_INSTALLER As String = "C:\inetpub\e-IPSTA\Installer\"

    ''' <summary>
    ''' センターサーバシステム用データ格納パス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CENTERSERVER_SYSTEMDATA As String = "C:\inetpub\e-IPSTA\SystemData\"


    ''' <summary>
    ''' センターサーバシステム用データ格納パス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_CENTERSERVER_DOWNLOAD As String = "C:\inetpub\e-IPSTA\DownLoad\"

    ''' <summary>
    ''' 団体管理者サブドメイン
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_URL_SUBDOMIN As String = "manager"

    ''' <summary>
    ''' メニューモード システム管理
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MENUMODE_SYSTEM As String = "SystemManager2_demo"

    ''' <summary>
    ''' メニューモード 団体管理
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MENUMODE_GROUP As String = "GroupManager2_demo"

    ''' <summary>
    ''' メニューモード 受講者
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_MENUMODE_STUDENT As String = "Student2_demo"

    ''' <summary>
    ''' 受講者ソフトインストールパス
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_STUDENT_INSTALL_PATH As String = "C:\Program Files\eIPSTA\"

    ''' <summary>
    ''' 受講者ヘルプファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_STUDENT_HELP_FILENAME As String = "HelpStudent.chm"

    ''' <summary>
    ''' 団体ヘルプファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_GROUP_HELP_FILENAME As String = "HelpGroup.chm"

    ''' <summary>
    ''' 一時フォルダパスを取得する
    ''' </summary>
    Public Shared Function GetTempPath() As String
        GetTempPath = DataManager.GetInstance().TempPath & DataManager.GetInstance().TempSubPath
    End Function

    ''' <summary>指定テスト確認画面表示モード</summary>
    Public Enum SpecificShowMode As Integer
        ''' <summary>手動テスト作成</summary>
        CreateManualTest = 1
        ''' <summary>自動テスト作成</summary>
        CreateAutomaticTest
        ''' <summary>テスト一覧</summary>
        ShowTestList
    End Enum

    ''' <summary>ランダム／指定テスト履歴詳細画面表示モード</summary>
    Public Enum MiniTestResultDetailMode As Integer
        ''' <summary>登録確認</summary>
        Random = 1
        ''' <summary>確認</summary>
        Specific = 2
    End Enum

End Class
