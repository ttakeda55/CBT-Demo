Imports CST.CBT.eIPSTA.Common
Imports System.Security.Cryptography.X509Certificates
Imports System.Net
Imports System.Net.Security

''' <summary>
''' データ管理クラス
''' </summary>
''' <remarks></remarks>
Public Class DataManager

    Enum EditionType As Integer
        Foram = 1
        Trial
    End Enum
#Region "----- メンバ変数 -----"

    ''' <summary>DataManagerインスタンス</summary>
    Private Shared _instance As New DataManager
    ''' <summary>団体コード</summary>
    Private _GroupCode As String
    ''' <summary>団体名</summary>
    Private _GroupName As String
    ''' <summary>ユーザーID</summary>
    Private _UserId As String = ""
    ''' <summary>ユーザー名</summary>
    Private _UserName As String = ""
    ''' <summary>問題種別</summary>
    Private _Syubetu As Integer = 30
    ''' <summary>受験者ファイル名</summary>
    Private _StudentFileName As String = ""
    ''' <summary>受験日</summary>
    Private _TestDate As String = ""
    ''' <summary>受験時間</summary>
    Private _TestTime As String = ""
    ''' <summary>受講開始日</summary>
    Private _SystemStart As String = ""
    ''' <summary>受講終了日</summary>
    Private _SystemEnd As String = ""
    ''' <summary>コース番号</summary>
    Private _CourseNo As String = ""
    ''' <summary>お知らせ</summary>
    Private _Infomation As String = ""
    ''' <summary>問題コードリスト</summary>
    Private _QuestionCodeList As Generic.Dictionary(Of Integer, QuestionCodeDefine)
    ''' <summary>問題定義コンテナオブジェクト</summary>
    Private _PracticeQuestionDefineContainer As QuestionDefineContainer = Nothing
    ''' <summary>解答データコンテナオブジェクト</summary>
    Private _ResultDataContainer As ResultDataContainer = Nothing
    ''' <summary>カテゴリー定義クラス</summary>
    Private _CategoryDefine As New CategoryDefine
    ''' <summary>演習問題定義クラス</summary>
    Private _PracticeQuestionDefine As New PracticeQuestionDefine
    ''' <summary>総合テスト結果定義クラス</summary>
    Private _SynthesisResultDefine As New SynthesisResultDefine
    ''' <summary>総合テスト定義クラス</summary>
    Private _SynthesisDefine As New SynthesisDefine
    ''' <summary>サーバーの日時</summary>
    Private _ServerDateTime As String = ""
    ''' <summary>サーバーとローカルPCとの時間差</summary>
    Private _DiffDateTime As TimeSpan = Nothing
    ''' <summary>1回のダウンロードでダウンロードするファイル数</summary>
    Private _FilePartitionCount As Integer = 0
    ''' <summary>ファイルダウンロード方式</summary>
    Private _FileDownloadType As Integer = 0
    ''' <summary>ファイルダウンロード失敗回数</summary>
    Private _FileDownloadFailed As Integer = 0
    ''' <summary>WebServiceUrl</summary>
    Private _WebServiceUrl As String = ""
    ''' <summary>ログアウト中かどうか</summary>
    Private _IsLogouting As Boolean = False
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>受講者が一括かどうか</summary>
    Private _IsAllStudent As Boolean = False
    ''' <summary>模擬テスト試験回数</summary>
    Private _TestCount As String = ""
    ''' <summary>WEBサービスオブジェクト</summary>
    Private _WebService As WebService.Student
    ''' <summary>アップロード日時</summary>
    Private _UpLoadDate As Date = Nothing
    ''' <summary>問題演習ボタン有効フラグ</summary>
    Private _BtnPracticeEnable As Boolean = False
    ''' <summary>ダウンロードスリープ時間</summary>
    Private _DownLoadInterval As Integer = 0
    Private _Edition As EditionType
    Private _TestResult_Share_Folder As String = ""
#End Region

#Region "----- プロパティ -----"

    ''' <summary>団体コードの取得</summary>
    Public ReadOnly Property GroupCode As String
        Get
            Return _GroupCode
        End Get
    End Property

    ''' <summary>団体名の取得</summary>
    Public ReadOnly Property GroupName As String
        Get
            Return _GroupName
        End Get
    End Property

    ''' <summary>コース番号の取得</summary>
    Public ReadOnly Property CourseNo As String
        Get
            Return _CourseNo
        End Get
    End Property

    ''' <summary>ユーザーIDの取得</summary>
    Public Property UserId As String
        Get
            Return _UserId
        End Get
        Set(value As String)
            _UserId = value
        End Set
    End Property

    ''' <summary>ユーザー名の取得</summary>
    Public Property UserName As String
        Get
            Return _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property

    ''' <summary>問題種別の取得</summary>
    Public Property Syubetu As Integer
        Get
            Return _Syubetu
        End Get
        Set(ByVal value As Integer)
            _Syubetu = value
        End Set
    End Property

    ''' <summary>受験日の設定</summary>
    Public Property TestDate As String
        Get
            Return _TestDate
        End Get
        Set(ByVal value As String)
            _TestDate = value
        End Set
    End Property

    ''' <summary>受験時間の設定</summary>
    Public Property TestTime As String
        Get
            Return _TestTime
        End Get
        Set(ByVal value As String)
            _TestTime = value
        End Set
    End Property

    ''' <summary>受講開始日の取得</summary>
    Public ReadOnly Property SystemStart As String
        Get
            Return _SystemStart
        End Get
    End Property

    ''' <summary>受講終了日の取得</summary>
    Public ReadOnly Property SystemEnd As String
        Get
            Return _SystemEnd
        End Get
    End Property

    ''' <summary>お知らせの取得・設定</summary>
    Public Property Infomation As String
        Get
            Return _Infomation
        End Get
        Set(ByVal value As String)
            _Infomation = value
        End Set
    End Property

    ''' <summary>
    ''' 問題コードリストの取得・設定
    ''' </summary>
    ''' <value>問題コードリスト</value>
    ''' <returns>問題コードリスト</returns>
    ''' <remarks></remarks>
    Public Property QuestionCodeList As Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Get
            Return _QuestionCodeList
        End Get
        Set(ByVal value As Generic.Dictionary(Of Integer, QuestionCodeDefine))
            _QuestionCodeList = value
        End Set
    End Property

    ''' <summary>
    ''' カテゴリー定義の取得
    ''' </summary>
    ''' <returns>カテゴリー定義</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CategoryDefine As CategoryDefine
        Get
            Return _CategoryDefine
        End Get
    End Property

    ''' <summary>
    ''' 演習問題定義の取得
    ''' </summary>
    ''' <returns>演習問題定義</returns>
    ''' <remarks></remarks>
    : Public ReadOnly Property PracticeQuestionDefine As PracticeQuestionDefine
        Get
            Return _PracticeQuestionDefine
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト定義の取得
    ''' </summary>
    ''' <returns>総合テスト定義</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisDefine As SynthesisDefine
        Get
            Return _SynthesisDefine
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト結果定義の取得
    ''' </summary>
    ''' <returns>総合テスト結果定義</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisResultDefine As SynthesisResultDefine
        Get
            Return _SynthesisResultDefine
        End Get
    End Property

    ''' <summary>問題定義コンテナオブジェクトの取得</summary>
    Public ReadOnly Property PracticeQuestionDefineContainer As QuestionDefineContainer
        Get
            Return _PracticeQuestionDefineContainer
        End Get
    End Property

    ''' <summary>解答データコンテナオブジェクトの取得</summary>
    Public ReadOnly Property ResultDataContainer As ResultDataContainer
        Get
            Return _ResultDataContainer
        End Get
    End Property

    ''' <summary>サーバー側日時の取得・設定</summary>
    Public Property ServerDateTime As String
        Get
            Return _ServerDateTime
        End Get
        Set(ByVal value As String)
            _ServerDateTime = value
        End Set
    End Property

    Public Property DiffDateTime As TimeSpan
        Get
            Return _DiffDateTime
        End Get
        Set(ByVal value As TimeSpan)
            _DiffDateTime = value
        End Set
    End Property

    ''' <summary>ダウンロードするファイル数の取得</summary>
    Public ReadOnly Property FilePartitionCount As Integer
        Get
            Return _FilePartitionCount
        End Get
    End Property

    ''' <summary>ファイルダウンロード方式の取得</summary>
    Public ReadOnly Property FileDownloadType As Integer
        Get
            Return _FileDownloadType
        End Get
    End Property

    ''' <summary>ファイルダウンロード失敗回数の取得</summary>
    Public ReadOnly Property FileDownloadFailed As Integer
        Get
            Return _FileDownloadFailed
        End Get
    End Property

    ''' <summary>ログアウト中かどうか</summary>
    Public Property IsLogouting As Boolean
        Get
            Return _IsLogouting
        End Get
        Set(ByVal value As Boolean)
            _IsLogouting = value
        End Set
    End Property

    ''' <summary>現在日時の取得・設定</summary>
    Public ReadOnly Property Now As DateTime
        Get
            If _DiffDateTime = Nothing Then
                Return DateTime.Now
            Else
                Return DateTime.Now.Add(_DiffDateTime)
            End If
        End Get
    End Property

    ''' <summary>
    ''' 受講者が一括かどうかの取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsAllStudent As Boolean
        Get
            Return _IsAllStudent
        End Get
    End Property

    ''' <summary>
    ''' 模擬テスト試験回数の取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TestCount As String
        Get
            Return _TestCount
        End Get
    End Property

    ''' <summary>
    ''' WebServiceUrlの取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WebServiceUrl As String
        Get
            Return _WebServiceUrl
        End Get
    End Property

    ''' <summary>
    ''' WebServiceオブジェクトの取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WebService As WebService.Student
        Get
            Return _WebService
        End Get
    End Property

    ''' <summary>
    ''' 受験者ファイル名の取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property StudentFileName As String
        Get
            Return _StudentFileName
        End Get
    End Property

    ''' <summary>
    ''' 問題演習ボタン有効フラグの取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property BtnPracticeEnable As Boolean
        Get
            Return _BtnPracticeEnable
        End Get
    End Property

    ''' <summary>
    ''' ダウンロードスリープ時間の取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DownLoadInterval As Integer
        Get
            Return _DownLoadInterval
        End Get
    End Property

    ''' <summary>
    ''' エディション
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Edition As EditionType
        Get
            Return _Edition
        End Get
        Set(value As EditionType)
            _Edition = value
        End Set
    End Property

    ''' <summary>
    ''' 試験結果収集フォルダ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TestResult_Share_Folder As String
        Get
            Return _TestResult_Share_Folder
        End Get
    End Property
#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
        _ResultDataContainer = New ResultDataContainer
    End Sub

    ''' <summary>
    ''' インスタンス取得
    ''' </summary>
    ''' <returns>DataManager</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As DataManager
        Return _instance
    End Function

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function Initialize() As Integer
        Dim errCode As Integer = Constant.ResultCode.NormalEnd

        Try
            '設定ファイル読込(App.config)
            errCode = ReadAppConfig()
            'WEBサービス初期化
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = WebServiceInitialize()
            '復号処理
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = Decryption()
            'If errCode = Constant.ResultCode.NormalEnd AndAlso _IsAllStudent Then
            '    '受講者一括は各データファイル作成
            '    errCode = ExtractionFile()
            'End If
            'If errCode = Constant.ResultCode.NormalEnd AndAlso Edition = EditionType.Foram Then
            '    errCode = ExtractionFile()
            'End If
            '受講者ファイル読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadStudent()
            'カテゴリー
            If errCode = Constant.ResultCode.NormalEnd Then errCode = _CategoryDefine.ReadCategory
            '演習問題読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = _PracticeQuestionDefine.ReadPracticeQuestion
            '総合テスト結果読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = _SynthesisResultDefine.ReadSynthesisResult
            '総合テスト読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = _SynthesisDefine.ReadSynthesis
            '問題演習ボタン有効フラグ設定
            If errCode = Constant.ResultCode.NormalEnd AndAlso _SynthesisDefine.IsReadSynthesisHeader _
                    AndAlso _SynthesisDefine.IsReadSynthesisDetail Then
                _BtnPracticeEnable = True
            End If
            '問題ファイル出力
            'writeResource()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 復号処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Decryption() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim ds As DataSet = Nothing
        Dim dtDecryptionkey As DataTable = Nothing
        Dim dtStudent As DataTable = Nothing

        Try
            If IO.File.Exists(Common.Constant.GetTempPath & Constant.CST_DECRYPTIONKEY_FILENAME & ".enc") Then
                Try
                    '復号
                    Common.Encrypt.DecryptFile(Common.Constant.GetTempPath & Constant.CST_DECRYPTIONKEY_FILENAME & ".enc", _
                                               Common.Constant.GetTempPath & Constant.CST_DECRYPTIONKEY_FILENAME, "ITS")
                    ds = New DataSet
                    ds.ReadXml(Common.Constant.GetTempPath & Constant.CST_DECRYPTIONKEY_FILENAME)
                    dtDecryptionkey = ds.Tables("Decryptionkey")
                    dtStudent = ds.Tables("Student")
                    '暗号化チェック
                    If dtDecryptionkey.Rows.Count > 0 Then
                        Dim ServerNowDate As Date = Nothing
                        _WebService.GetServerNowDate(ServerNowDate)
                        'If CType(dtDecryptionkey.Rows(0).Item("DATE"), Date).AddDays(1) >= System.DateTime.Now _
                        If CType(dtDecryptionkey.Rows(0).Item("DATE"), Date).AddDays(1) >= ServerNowDate _
                                AndAlso dtDecryptionkey.Rows(0).Item("USERID").ToString <> "" Then
                            _GroupCode = dtDecryptionkey.Rows(0).Item("GROUPCODE").ToString
                            _UserId = dtDecryptionkey.Rows(0).Item("USERID").ToString
                            _IsAllStudent = True
                        Else
                            errCode = Constant.ResultCode.DecryptionkeyError
                        End If
                    Else
                        errCode = Constant.ResultCode.DecryptionkeyError
                    End If
                    '受験回数、アップロード日時取得
                    If dtStudent.Rows.Count > 0 Then
                        _TestCount = dtStudent.Rows(0).Item("TESTCOUNT")
                        _UpLoadDate = dtStudent.Rows(0).Item("UPLOADDATE")
                    End If
                Catch ex As Exception
                    errCode = Constant.ResultCode.DecryptionkeyError
                End Try
            Else
                errCode = Constant.ResultCode.NormalEnd
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' データファイル作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExtractionFile() As Constant.ResultCode
        Dim errCode As Integer = Constant.ResultCode.NormalEnd

        Try
            '個人受講者データファイル作成
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ExtractionStudent()
            '問題ファイル復号
            If errCode = Constant.ResultCode.NormalEnd Then errCode = DecryptionQuestion()
            '総合テスト結果ヘッダファイル作成
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ExtractionSynthesisResultHeader()
            '総合テスト結果明細ファイル作成
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ExtractionSynthesisResultDetail()
            '他ユーザーの再演習ファイル削除
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ExtractionDeleteReview()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 個人受講者データファイル作成
    ''' </summary>
    ''' <returns>作成結果コード</returns>
    ''' <remarks></remarks>
    Private Function ExtractionStudent() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim studentTbl As DataTable = Nothing

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_STUDENT_FILENAME & "*"
            '受講者ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If IsNothing(fileNameList) OrElse fileNameList.Length = 0 Then errCode = Constant.ResultCode.StudentFileNotFoundError
            If errCode = Constant.ResultCode.NormalEnd AndAlso fileNameList.Length <> 1 Then errCode = Constant.ResultCode.StudentFileReadError
            If errCode = Constant.ResultCode.NormalEnd Then
                'DataTable取得
                studentTbl = Common.Student.GetAll(IO.Path.GetFileName(fileNameList(0)))
                '全受講者から対象受講者を抽出しファイル作成
                If studentTbl.Rows.Count >= 1 Then
                    Dim founrdRow As DataRow() = studentTbl.Select("USERID = '" & UserId & "'")
                    If founrdRow.Length > 0 Then
                        ''受験回数チェック
                        'If founrdRow(0).Item("TESTCOUNT") = _TestCount Then
                        '    Dim dt As DataTable = studentTbl.Clone
                        '    dt.ImportRow(founrdRow(0))
                        '    studentTbl = dt
                        '    Common.Serialize.DataTableToxml(studentTbl, Common.Constant.CST_STUDENT_FILENAME & GroupCode & UserId & Common.Constant.CST_EXTENSION_XML)
                        '    If IO.Path.GetFileName(fileNameList(0)) = Common.Constant.CST_STUDENT_FILENAME & GroupCode & Common.Constant.CST_EXTENSION_XML Then
                        '        IO.File.Delete(fileNameList(0))
                        '    End If
                        'ElseIf studentTbl.Rows(0).Item("TESTCOUNT") < _TestCount Then
                        '    errCode = Constant.ResultCode.AppOldError
                        'Else
                        '    errCode = Constant.ResultCode.DecryptionkeyOldError
                        'End If
                        'アップロード日時チェック
                        If Date.Parse(founrdRow(0).Item("UPLOADDATE")) >= Date.Parse(_UpLoadDate) Then
                            Dim dt As DataTable = studentTbl.Clone
                            dt.ImportRow(founrdRow(0))
                            studentTbl = dt
                            Common.Serialize.DataTableToxml(studentTbl, Common.Constant.CST_STUDENT_FILENAME & GroupCode & UserId & Common.Constant.CST_EXTENSION_XML)
                            If IO.Path.GetFileName(fileNameList(0)) = Common.Constant.CST_STUDENT_FILENAME & GroupCode & Common.Constant.CST_EXTENSION_XML Then
                                IO.File.Delete(fileNameList(0))
                            End If
                        Else
                            errCode = Constant.ResultCode.AppOldError
                        End If
                    Else
                        '団体アンマッチ
                        errCode = Constant.ResultCode.DecryptionkeyGroupError
                    End If
                Else
                    errCode = Constant.ResultCode.StudentFileReadError
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 問題ファイル復号
    ''' </summary>
    ''' <returns>作成結果コード</returns>
    ''' <remarks></remarks>
    Private Function DecryptionQuestion() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), "Question*.enc")
            If questionFileNameList.Length = 1 Then
                Dim questionFileName = questionFileNameList(0).Replace(".enc", "")
                '復号化
                Try
                    Common.Encrypt.DecryptFile(questionFileNameList(0), questionFileName, "ITS")
                    IO.File.Delete(questionFileNameList(0))
                Catch ex As Exception
                    errCode = Constant.ResultCode.QuestionFileReadError
                End Try
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 総合テスト結果ヘッダ作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExtractionSynthesisResultHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim dtWk As DataTable = Nothing
        Dim dt As DataTable = Nothing

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & "*"
            '総合テスト結果ヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SynthesisResultHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    dtWk = Common.SynthesisResultHeader.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    '全受講者から対象受講者を抽出しファイル作成
                    If dtWk.Rows.Count >= 1 Then
                        dt = dtWk.Clone
                        For Each rowData As DataRow In dtWk.Select("USERID = '" & UserId & "'")
                            dt.ImportRow(rowData)
                        Next
                        If dt.Rows.Count >= 1 Then
                            Dim fileName As String = Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & GroupCode & UserId & Common.Constant.CST_EXTENSION_XML
                            Common.Serialize.DataTableToxml(dt, fileName)
                        End If
                        If IO.Path.GetFileName(fileNameList(0)) = Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & GroupCode & Common.Constant.CST_EXTENSION_XML Then
                            IO.File.Delete(fileNameList(0))
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 総合テスト結果明細作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExtractionSynthesisResultDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim dtWk As DataTable = Nothing
        Dim dt As DataTable = Nothing

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & "*"
            '総合テスト結果明細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SynthesisResultDetailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    dtWk = Common.SynthesisResultDetail.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    '全受講者から対象受講者を抽出しファイル作成
                    If dtWk.Rows.Count >= 1 Then
                        dt = dtWk.Clone
                        For Each rowData As DataRow In dtWk.Select("USERID = '" & UserId & "'")
                            dt.ImportRow(rowData)
                        Next
                        If dt.Rows.Count >= 1 Then
                            Dim fileName As String = Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & GroupCode & UserId & Common.Constant.CST_EXTENSION_XML
                            Common.Serialize.DataTableToxml(dt, fileName)
                        End If
                        If IO.Path.GetFileName(fileNameList(0)) = Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & GroupCode & Common.Constant.CST_EXTENSION_XML Then
                            IO.File.Delete(fileNameList(0))
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 他ユーザー再演習ファイル削除
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExtractionDeleteReview() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim UserReviewFile As String = Common.Constant.CST_REVIEW_FILENAME & _GroupCode & "_" & UserId
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_REVIEW_FILENAME & "*"
            For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
                Dim DelFileName As String = IO.Path.GetFileNameWithoutExtension(fileName)
                If DelFileName <> UserReviewFile Then
                    IO.File.Delete(fileName)
                End If
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 設定ファイル読込
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadAppConfig() As Integer
        Dim errCode As Integer = Constant.ResultCode.NormalEnd

        Try
            'ダウンロードファイル数取得
            _FilePartitionCount = System.Configuration.ConfigurationManager.AppSettings("FILE_PARTITION_COUNT")
            'ファイルダウンロード方式取得
            _FileDownloadType = System.Configuration.ConfigurationManager.AppSettings("FILE_DOWNLOAD_TYPE")
            'ファイルダウンロード失敗回数取得
            _FileDownloadFailed = System.Configuration.ConfigurationManager.AppSettings("FILE_DOWNLOAD_FAILED")
            'ファイルダウンロードスリープ時間取得
            _DownLoadInterval = System.Configuration.ConfigurationManager.AppSettings("FILE_DOWNLOAD_INTERVAL")
            '試験結果収集フォルダ
            _TestResult_Share_Folder = System.Configuration.ConfigurationManager.AppSettings("TESTRESULT_SHARE_FOLDER")

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 受講者ファイル読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadStudent() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim studentTbl As DataTable = Nothing

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_STUDENT_FILENAME & "*"
            '受講者ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If IsNothing(fileNameList) OrElse fileNameList.Length = 0 Then errCode = Constant.ResultCode.StudentFileNotFoundError
            If errCode = Constant.ResultCode.NormalEnd AndAlso fileNameList.Length <> 1 Then errCode = Constant.ResultCode.StudentFileReadError
            If errCode = Constant.ResultCode.NormalEnd Then
                'DataTable取得
                studentTbl = Common.Student.GetAll(IO.Path.GetFileName(fileNameList(0)))
                If studentTbl.Rows.Count >= 1 Then
                    'ユーザーID取得
                    '_UserId = studentTbl.Rows(0).Item(Common.Student.ColumnIndex.UserId)
                    'ユーザー名取得
                    '_UserName = studentTbl.Rows(0).Item(Common.Student.ColumnIndex.Name)
                    '受講開始日取得
                    _SystemStart = studentTbl.Rows(0).Item(Common.Student.ColumnIndex.StudentsStart)
                    '受講終了日取得
                    _SystemEnd = studentTbl.Rows(0).Item(Common.Student.ColumnIndex.StudentsEnd)
                    '読み込みを行った受験者ファイル名の登録
                    _StudentFileName = IO.Path.GetFileName(fileNameList(0))
                Else
                    errCode = Constant.ResultCode.StudentFileReadError
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' メールファイル読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadMail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim sr As IO.StreamReader = Nothing
        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_MAIL_FILENAME & "*"
            'Mailファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.MailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'Mailファイル読込
                    sr = New IO.StreamReader(fileNameList(0))
                    '内容を読む
                    Dim mailData As String = sr.ReadLine
                    While (sr.Peek > 0)
                        mailData = sr.ReadLine
                    End While
                    '最終行をチェックする
                    If mailData.LastIndexOf(Common.Constant.CST_NEWMAIL) >= 0 AndAlso mailData.LastIndexOf(_UserId) = -1 Then
                        _Infomation = "新着メールがあります。"
                    End If
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        Finally
            If Not IsNothing(sr) Then
                sr.Close()
                sr = Nothing
            End If
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 問題読込処理
    ''' </summary>
    ''' <param name="fileName">読込問題ファイル名</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadQuestion(ByVal fileName As String) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNmaeList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), fileName)
            Select Case questionFileNmaeList.Length
                Case 0
                    errCode = Constant.ResultCode.QuestionFileNotFoundError
                Case 1
                    Dim practiceQuestionDataBankCol = Serialize.BinaryFileToObject(fileName)
                    If practiceQuestionDataBankCol Is Nothing Then
                        errCode = Constant.ResultCode.QuestionFileReadError
                    Else
                        If Not QuestionDefineCreator.Create(practiceQuestionDataBankCol, _PracticeQuestionDefineContainer) Then
                            errCode = Constant.ResultCode.QuestionFileParseError
                        End If
                    End If
                Case Else
                    errCode = Constant.ResultCode.QuestionFileReadError
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 演習問題データテーブル追加処理
    ''' </summary>
    ''' <param name="filetype">ファイル種別</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function CreatePracticeResultDataTable(ByVal filetype As Constant.FileType, Optional ByVal questionCode As String = "", Optional ByVal questionCount As Integer = 0) As Boolean
        Dim ret As Boolean = True
        Dim testNo As String = ""
        Dim TestCount As String = ""
        Try
            Select Case filetype
                Case Constant.FileType.SynthesisResultHeader
                    ' 総合テスト結果_ヘッダ
                    ' 実施テスト回数・実施テストNo.取得
                    TestCount = DataManager.GetInstance.SynthesisDefine.TestCount
                    testNo = DataManager.GetInstance.SynthesisDefine.TestNo
                    ret = DataManager.GetInstance.SynthesisResultDefine.AddSynthesisResultHeader(Now, _TestTime, testNo, TestCount, _UserId)

                Case Constant.FileType.SynthesisResultDetail
                    ' 総合テスト結果_明細
                    TestCount = DataManager.GetInstance.SynthesisDefine.TestCount
                    testNo = DataManager.GetInstance.SynthesisDefine.TestNo
                    ret = DataManager.GetInstance.SynthesisResultDefine.AddSynthesisResultDetail(Now, TestCount, testNo, _QuestionCodeList, _ResultDataContainer, _PracticeQuestionDefineContainer, _UserId, _PracticeQuestionDefine.PracticeQuestionListDataTable)
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            ret = False
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' 演習問題データテーブル取得処理
    ''' </summary>
    ''' <param name="filetype">ファイル種別</param>
    ''' <returns>演習問題データテーブル</returns>
    ''' <remarks></remarks>
    Public Function GetPracticeResultDataTable(ByVal filetype As Constant.FileType) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Select Case filetype
                Case Constant.FileType.SynthesisResultHeader
                    ' 総合テスト結果_ヘッダ
                    dt = DataManager.GetInstance.SynthesisResultDefine.GetHeaderDataTable(_ServerDateTime)
                Case Constant.FileType.SynthesisResultDetail
                    ' 総合テスト結果_明細
                    dt = DataManager.GetInstance.SynthesisResultDefine.GetDetailDataTable(_ServerDateTime)
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            dt = Nothing
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' テスト実施結果データ行取得処理
    ''' </summary>
    ''' <param name="testtype">テスト種別</param>
    ''' <returns>テスト実施結果データ行</returns>
    ''' <remarks></remarks>
    Public Function GetResultDataRow(ByVal testtype As Constant.TestType) As DataRow
        Dim dataRow As DataRow = Nothing
        Dim TestCount As String = ""
        Dim TestNo As String = ""
        Try
            Select Case testtype
                Case Else
                    ' 総合テスト実施
                    TestCount = DataManager.GetInstance.SynthesisDefine.TestCount
                    TestNo = DataManager.GetInstance.SynthesisDefine.TestNo
                    dataRow = DataManager.GetInstance.SynthesisResultDefine.CreateResultDataRow(TestCount, TestNo, _CategoryDefine.CategoryDataTable, _PracticeQuestionDefine.PracticeQuestionListDataTable, _SynthesisResultDefine.SynthesisResultHeaderDataTable)
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            dataRow = Nothing
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return dataRow
    End Function

    ''' <summary>
    ''' 問別正誤データテーブル取得処理
    ''' </summary>
    ''' <param name="testtype">テスト種別</param>
    ''' <returns>問別正誤データテーブル</returns>
    ''' <remarks></remarks>
    Public Function GetTrueFalseDataTable(ByVal testCount As String, ByVal testNo As String, ByVal testType As Constant.TestType) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Select Case testType
                Case Else
                    ' 総合テスト実施
                    dt = DataManager.GetInstance.SynthesisResultDefine.GetTrueFalseListDataTable(testCount, testNo, _PracticeQuestionDefine.PracticeQuestionListDataTable)
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            dt = Nothing
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' WEBサービス初期化
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WebServiceInitialize() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Try
            ServicePointManager.ServerCertificateValidationCallback = _
                                New RemoteCertificateValidationCallback( _
                                AddressOf OnRemoteCertificateValidationCallback)
            _WebService = New WebService.Student
            _WebService.Url = _WebServiceUrl
            _WebService.InitializeAsync()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' SSL認証を常に問題なしとする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="certificate"></param>
    ''' <param name="chain"></param>
    ''' <param name="sslPolicyErrors"></param>
    ''' <returns>
    ''' ローカルPCのシステム日付が狂っている場合、
    ''' HTTPS通信のSSL認証の有効期限チェックでエラーが発生するので、
    ''' SSL認証は常に問題なしとする。
    ''' </returns>
    ''' <remarks></remarks>
    Private Shared Function OnRemoteCertificateValidationCallback( _
      ByVal sender As Object, _
      ByVal certificate As X509Certificate, _
      ByVal chain As X509Chain, _
      ByVal sslPolicyErrors As Net.Security.SslPolicyErrors _
    ) As Boolean

        Return True  ' 「SSL証明書の使用は問題なし」と示す

    End Function


    'Private Sub writeResource()
    '    'CBTCommon.Utility.DeleteDirectory(Common.Constant.GetTempPath)

    '    Dim path As String = IO.Path.GetDirectoryName(Common.Constant.GetTempPath)
    '    If IO.Directory.Exists(path) Then
    '        CBTCommon.Utility.DeleteDirectory(path)
    '    End If
    '    IO.Directory.CreateDirectory(path)

    '    My.Computer.FileSystem.WriteAllBytes(path & "..\Category.xml", My.Resources.Category, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\GroupVETNurse.xml", My.Resources.GroupVETNurse, False)
    '    IO.Directory.CreateDirectory(path & "\Help")
    '    My.Computer.FileSystem.WriteAllBytes(path & "\Help" & "..\Help01.mht", My.Resources.Help01, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionList.xml", My.Resources.PracticeQuestionList, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001001", My.Resources.PracticeQuestionVN001001, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001002", My.Resources.PracticeQuestionVN001002, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001003", My.Resources.PracticeQuestionVN001003, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001004", My.Resources.PracticeQuestionVN001004, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001005", My.Resources.PracticeQuestionVN001005, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001006", My.Resources.PracticeQuestionVN001006, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001007", My.Resources.PracticeQuestionVN001007, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001008", My.Resources.PracticeQuestionVN001008, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001009", My.Resources.PracticeQuestionVN001009, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionVN001010", My.Resources.PracticeQuestionVN001010, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\Result.xls", My.Resources.Result, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\setup.exe", My.Resources.setup, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\CBT.msi", My.Resources.CBT, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SpreadSheetSpecification.xls", My.Resources.SpreadSheetSpecification, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\StudentVETNurse.xml", My.Resources.StudentVETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SynthesisDetail15VETNurse.xml", My.Resources.SynthesisDetail15VETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SynthesisHeader15VETNurse.xml", My.Resources.SynthesisHeader15VETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SynthesisDetail30VETNurse.xml", My.Resources.SynthesisDetail30VETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SynthesisHeader30VETNurse.xml", My.Resources.SynthesisHeader30VETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SynthesisDetail60VETNurse.xml", My.Resources.SynthesisDetail60VETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\SynthesisHeader60VETNurse.xml", My.Resources.SynthesisHeader60VETNurse, False)
    '    My.Computer.FileSystem.WriteAllBytes(path & "..\TestName.xml", My.Resources.TestName, False)

    'End Sub
    ''' <summary>
    ''' テスト済みかどうか
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsTested() As Boolean
        IsTested = False
        If _SynthesisResultDefine.SynthesisResultHeaderDataTable Is Nothing OrElse
            _SynthesisResultDefine.SynthesisResultHeaderDataTable.Rows.Count = 0 Then
            Return True
        End If
    End Function
#End Region

End Class
