Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class download
    Inherits System.Web.UI.Page

#Region "----- 定数 -----"
    Private Const CODESIGNING_PFK As String = "infotechserve.pfk"
    Private Const SIGNPASSWORD As String = "cstech"
    Private DELETE_INTERVAL As Integer = 1000
    Private Const CST_DOWNLOAD_FILENAME As String = "CBT.zip"
    Private Const CST_DOWNLOAD_FILENAME_ALL As String = "CBTALL.exe"
    ''' <summary>
    ''' 復号キーファイル名
    ''' </summary>
    ''' <remarks></remarks>
    Public Const CST_DECRYPTIONKEY_FILENAME As String = "Decryptionkey"

    ''' <summary>ログインモード</summary>
    Public Enum loginMode As Integer
        ''' <summary>団体管理者（個別、一括共通)</summary>
        Group = 0
        ''' <summary>受講者（一括）</summary>
        StudentAll
        ''' <summary>受講者（復号キー）</summary>
        StudentDecryptionkey
        ''' <summary>受講者（個別）</summary>
        Student
    End Enum
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>団体コード</summary>
    Private groupId As String = ""
    ''' <summary>コース</summary>
    Private courseNo As String = ""
    ''' <summary>受講者ID</summary>
    Private userId As String = ""
    ''' <summary>受講者ファイル名</summary>
    Private studentFileName As String = ""
    ''' <summary>ログイン受講者</summary>
    Private dtloginStudent As New DataTable
    ''' <summary>DATAフォルダパス</summary>
    Private centerServerPath As String = System.Configuration.ConfigurationManager.AppSettings("CST_CENTERSERVER_DATA").ToString()
    ''' <summary>DATAフォルダパス</summary>
    Private CST_CENTERSERVER_DATA As String = System.Configuration.ConfigurationManager.AppSettings("CST_CENTERSERVER_DATA").ToString()
    ''' <summary>インストーラフォルダパス</summary>
    Private CST_CENTERSERVER_INSTALLER As String = System.Configuration.ConfigurationManager.AppSettings("CST_CENTERSERVER_INSTALLER").ToString()
    ''' <summary>システムデータフォルダパス</summary>
    Private CST_CENTERSERVER_SYSTEMDATA As String = System.Configuration.ConfigurationManager.AppSettings("CST_CENTERSERVER_SYSTEMDATA").ToString()
    ''' <summary>カテゴリーフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_CATEGORY As String = CST_CENTERSERVER_DATA & Common.Constant.CST_CATEGORY_FILENAME & "\"
    ''' <summary>コースフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_COURSE As String = CST_CENTERSERVER_DATA & Common.Constant.CST_COURSE_FILENAME & "\"
    ''' <summary>問題群フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_COLLECTION As String = CST_CENTERSERVER_DATA & Common.Constant.CST_COLLECTION_FILENAME & "\"
    ''' <summary>団体フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_GROUP As String = CST_CENTERSERVER_DATA & Common.Constant.CST_GROUP_FILENAME & "\"
    ''' <summary>受講者フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_STUDENT As String = CST_CENTERSERVER_DATA & Common.Constant.CST_STUDENT_FILENAME & "\"
    ''' <summary>メールフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_MAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_MAIL_FILENAME & "\"
    ''' <summary>模擬テストフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_MOCKTEST As String = CST_CENTERSERVER_DATA & Common.Constant.CST_QUESTION_FILENAME & "\"
    ''' <summary>模擬テスト結果_ヘッダフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_TESTRESULT_HEADER As String = CST_CENTERSERVER_DATA & Common.Constant.CST_TESTHEAD_FILENAME & "\"
    ''' <summary>模擬テスト結果_明細フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_TESTRESULT_DETAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_TESTDETAIL_FILENAME & "\"
    ''' <summary>演習問題フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_PRACTICEQUESTION As String = CST_CENTERSERVER_DATA & Common.Constant.CST_PRACTICEQUESTION_FILENAME & "\"
    ''' <summary>総合テスト_ヘッダフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SYNTHESIS_HEADER As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SYNTHESISHEADER_FILENAME & "\"
    ''' <summary>総合テスト_明細フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SYNTHESIS_DETAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SYNTHESISDETAIL_FILENAME & "\"
    ''' <summary>指定テスト_ヘッダフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SPECIFIC_HEADER As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SPECIFICHEADER_FILENAME & "\"
    ''' <summary>指定テスト_明細フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SPECIFIC_DETAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SPECIFICDETAIL_FILENAME & "\"
    ''' <summary>逐次演習結果_ヘッダフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SERIALRESULT_HEADER As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SERIALRESULTHEADER_FILENAME & "\"
    ''' <summary>逐次演習結果_明細フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SERIALRESULT_DETAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SERIALRESULTDETAIL_FILENAME & "\"
    ''' <summary>小テスト結果_ヘッダフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_MINIRESULT_HEADER As String = CST_CENTERSERVER_DATA & Common.Constant.CST_MINIRESULTHEADER_FILENAME & "\"
    ''' <summary>小テスト結果_明細フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_MINIRESULT_DETAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_MINIRESULTDETAIL_FILENAME & "\"
    ''' <summary>総合テスト結果_ヘッダフォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SYNTHESISRESULT_HEADER As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & "\"
    ''' <summary>総合テスト結果_明細フォルダパス</summary>
    Private CST_CENTERSERVER_FOLDERPATH_SYNTHESISRESULT_DETAIL As String = CST_CENTERSERVER_DATA & Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & "\"
    ''' <summary>テスト名</summary>
    Private CST_CENTERSERVER_FOLDERPATH_TESTNAME As String = CST_CENTERSERVER_DATA & Common.Constant.CST_TESTNAME_FILENAME & "\"
    ''' <summary>再演習</summary>
    Private CST_CENTERSERVER_FOLDERPATH_REVIEW As String = CST_CENTERSERVER_DATA & Common.Constant.CST_REVIEW_FILENAME & "\"
    ''' <summary>ログインモード</summary>
    Private mode As Integer = 0
    ''' <summary>通信プロトコル</summary>
    Private protocol As String = ""
    ''' <summary>ユーザ毎のフォルダ</summary>
    Private _userFolderName As String = ""
    ''' <summary>ダウンロード対象のフォルダ</summary>
    Private _downLoadfolderName As String = ""

    ''' <summary>WebServiceUrl</summary>
    Private URL_WEBSERVICE_COMMON_HTTPS As String = ConfigurationManager.AppSettings("URL_WEBSERVICE_COMMON_HTTPS")
    Private URL_WEBSERVICE_COMMON_HTTP As String = ConfigurationManager.AppSettings("URL_WEBSERVICE_COMMON_HTTP")
    Private URL_WEBSERVICE_GROUP_HTTPS As String = ConfigurationManager.AppSettings("URL_WEBSERVICE_GROUP_HTTPS")
    Private URL_WEBSERVICE_GROUP_HTTP As String = ConfigurationManager.AppSettings("URL_WEBSERVICE_GROUP_HTTP")
    Private URL_WEBSERVICE_STUDENT_HTTPS As String = ConfigurationManager.AppSettings("URL_WEBSERVICE_STUDENT_HTTPS")
    Private URL_WEBSERVICE_STUDENT_HTTP As String = ConfigurationManager.AppSettings("URL_WEBSERVICE_STUDENT_HTTP")
#End Region

#Region "----- イベントハンドラ -----"
    ''' <summary>
    ''' ページロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("folderName") = Nothing Then
        '    Response.Redirect("login.aspx")
        'End If

        'groupId = Session("groupId")
        'userId = Session("userId")
        'mode = Session("loginMode")
        'courseNo = Session("courseNo")

        ''プロトコル設定
        'If Request.Url.ToString.ToLower.IndexOf("https://") >= 0 Then
        '    protocol = "https"
        'Else
        '    protocol = "http"
        'End If

        'setScript()
    End Sub

    ''' <summary>
    ''' CBT-VetNurseダウンロードクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDownLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad.Click
        downLoad(CST_DOWNLOAD_FILENAME)
    End Sub

    ''' <summary>
    ''' Page_PreRenderCompleteイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        Dim cSM As ClientScriptManager = Page.ClientScript
        Me.btnDownLoad.Attributes.Item("OnClick") = cSM.GetPostBackEventReference(Me.btnDownLoad, "").ToString()

    End Sub
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 暗号化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub decryption()
        Dim dsDecryptionkey As New DataSet
        Dim dtDecryptionkey As New DataTable

        Common.XmlSchema.GetDecryptionkeySchema(dtDecryptionkey)
        dtDecryptionkey.Rows.Add()
        dtDecryptionkey.Rows(0).Item("GROUPCODE") = groupId
        dtDecryptionkey.Rows(0).Item("USERID") = userId
        dtDecryptionkey.Rows(0).Item("DATE") = System.DateTime.Now.ToString
        dsDecryptionkey.Tables.Add(dtloginStudent)
        dsDecryptionkey.Tables.Add(dtDecryptionkey)
        dsDecryptionkey.WriteXml(_userFolderName & CST_DECRYPTIONKEY_FILENAME)
        Encrypt.EncryptFile(_userFolderName & CST_DECRYPTIONKEY_FILENAME, _
                            _userFolderName & CST_DECRYPTIONKEY_FILENAME & ".enc", "ITS")
    End Sub


    ''' <summary>
    ''' 自己解凍形式の圧縮ファイル作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CompressZip()
        writeEventLog("CompressZip_S")
        Dim sfx As New Ionic.Zip.SelfExtractorSaveOptions
        '展開後実行するコマンド 
        sfx.PostExtractCommandLine = "!.vbs"
        'Windowsアプリケーションとするか、コンソールアプリケーションとするか 
        sfx.Flavor = Ionic.Zip.SelfExtractorFlavor.ConsoleApplication
        sfx.Quiet = True

        '作成する自己展開書庫のパス 
        Dim exeToGenerate As String = _userFolderName & CST_DOWNLOAD_FILENAME
        'ZipFileを作成する 
        Using zip As New Ionic.Zip.ZipFile()
            'IBM437でエンコードできないファイル名やコメントをUTF-8でエンコード 
            zip.UseUnicodeAsNecessary = True

            'フォルダを追加する 
            zip.AddDirectory(_userFolderName)

            '自己展開書庫を作成する 
            zip.SaveSelfExtractor(exeToGenerate, sfx)
        End Using
        writeEventLog("CompressZip_E")
    End Sub

    ''' <summary>
    ''' デジタル署名
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub sign(ByVal fileName As String)
        Try
            writeEventLog("sign_S")
            Dim psInfo As New ProcessStartInfo()
            psInfo.FileName = Context.Request.MapPath("~/App_Data/CustomSignTool.exe")
            psInfo.WorkingDirectory = Context.Request.MapPath("~/App_Data/")
            psInfo.Arguments = fileName

            Dim p As New System.Diagnostics.Process
            p.StartInfo = psInfo
            p.Start()
            p.WaitForExit()
            writeEventLog("sign_E")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' ログインユーザの試験結果ファイルを作成する。
    ''' </summary>
    ''' <param name="downLoadfolderName"></param>
    ''' <remarks></remarks>
    Private Sub loginStudentsExtraction(ByVal downLoadfolderName As String)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_STUDENT, Constant.CST_STUDENT_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_TESTRESULT_HEADER, Constant.CST_TESTHEAD_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_TESTRESULT_DETAIL, Constant.CST_TESTDETAIL_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_SERIALRESULT_HEADER, Constant.CST_SERIALRESULTHEADER_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_SERIALRESULT_DETAIL, Constant.CST_SERIALRESULTDETAIL_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_MINIRESULT_HEADER, Constant.CST_MINIRESULTHEADER_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_MINIRESULT_DETAIL, Constant.CST_MINIRESULTDETAIL_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_SYNTHESISRESULT_HEADER, Constant.CST_SYNTHESISRESULTHEADER_FILENAME, groupId, userId)
        makeTestResultData(downLoadfolderName, CST_CENTERSERVER_FOLDERPATH_SYNTHESISRESULT_DETAIL, Constant.CST_SYNTHESISRESULTDETAIL_FILENAME, groupId, userId)
    End Sub

    ''' <summary>
    ''' ダウンロード処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub downLoad(ByVal fileName As String)
        writeEventLog("downLoad_S")

        Response.ContentType = "application/zip"
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName)
        Response.Flush()
        Response.TransmitFile(fileName)
        Response.End()

        writeEventLog("downLoad_E")
    End Sub

    ''' <summary>
    ''' イベントログ出力
    ''' </summary>
    ''' <param name="eventName"></param>
    ''' <remarks></remarks>
    Private Sub writeEventLog(ByVal eventName As String)
        Dim filename As String = Request.PhysicalApplicationPath.ToString & "log\Event" & System.DateTime.Now.ToShortDateString.Replace("/", "") & ".csv"

        If Not IO.Directory.Exists(Request.PhysicalApplicationPath.ToString & "log") Then
            IO.Directory.CreateDirectory(Request.PhysicalApplicationPath.ToString & "log")
        End If
        Application.Lock()
        Using sw As IO.StreamWriter = New IO.StreamWriter(filename, True)
            sw.Write(Format(System.DateTime.Now, "yyyy/MM/dd HH:mm:ss.fff"))
            sw.Write(",")
            sw.Write(eventName)
            sw.Write(",")
            sw.Write(groupId)
            sw.Write(",")
            sw.Write(userId)
            sw.Write(",")
            sw.Write(Request.ServerVariables("REMOTE_ADDR"))
            sw.Write(",")
            sw.Write("""" & Request.UserAgent & """")
            sw.Write(",")
            sw.Write(Request.Url)
            sw.Write(",")
            sw.Write(User.Identity.Name)
            sw.Write(vbCrLf)
        End Using
        Application.UnLock()
    End Sub

    ''' <summary>
    ''' スクリプトを設定する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setScript()
        Dim scriptText As String = ""
        scriptText &= "$(document).ready(function () {"
        scriptText &= "     $(""#btnDownLoad"").click(function () {"
        scriptText &= "         $(""#btnDownLoad"").attr('disabled', true);"
        scriptText &= "         $(""#start"").text(' ');"
        If mode = loginMode.StudentDecryptionkey Then
            scriptText &= "         $(""#message"").html('" & _
                                    "ダウンロード処理を受け付けました。<br />" & _
                                    "ダウンロード完了後、管理者より配布されたアプリケーションファイルと、" & _
                                    "同じフォルダ内に復号キーを配置し、アプリケーションファイルを実行してください。" & _
                                    "自動的に、アプリケーションのインストールが開始されます。<br /><br />" & _
                                    "インストール完了後、ブラウザを閉じて、<br />" & _
                                    "デスクトップ上のアプリケーションを実行してください。<br />');"
        ElseIf mode = loginMode.StudentAll Then
            scriptText &= "         $(""#message"").html('" & _
                                    "ダウンロード処理を受け付けました。<br />" & _
                                    "ダウンロードにはしばらく時間が掛かる場合があります。<br /><br />" & _
                                    "ダウンロード完了後、ファイルを受講者に配布してください。<br />');"
        Else
            scriptText &= "         $(""#message"").html('" & _
                                    "ダウンロード処理を受け付けました。<br />" & _
                                    "ダウンロードにはしばらく時間が掛かる場合があります。<br /><br />" & _
                                    "ダウンロード完了後、ファイルを実行してください。<br />" & _
                                    "自動的に、アプリケーションのインストールが開始されます。<br /><br />" & _
                                    "インストール完了後、ブラウザを閉じて、<br />" & _
                                    "デスクトップ上のアプリケーションを実行してください。<br />');"
        End If
        scriptText &= "     });"
        scriptText &= "});"

        ClientScript.RegisterStartupScript(Me.GetType(), "key", scriptText, True)
    End Sub


    ''' <summary>
    ''' 受講者個別ファイル一覧作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function makeStudentFileList() As ArrayList
        Dim fileList As New ArrayList
        Dim dtCourse As New DataTable
        Dim mockTestNo As String = ""
        Dim mockTestName As String = ""
        Dim collectionNo As String = ""
        Dim downLoadfolderName As String = _userFolderName & "ITS\"

        '団体
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_GROUP, Constant.CST_GROUP_FILENAME & groupId & Constant.CST_EXTENSION_XML)
            fileList.Add(filePath)
        Next

        'コース
        Dim useStart As String = ""
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_COURSE, Constant.CST_COURSE_FILENAME & Constant.CST_EXTENSION_XML)
            dtCourse = Serialize.XmlToDataTableFullPath(filePath)
            Dim drs As DataRow() = dtCourse.Select("COURSENO = '" & courseNo & "'")
            If drs.Length > 0 Then
                '対応模擬テストNO
                mockTestNo = drs(0).Item(Common.Course.ColumnIndex.MockTestNo)
                '問題群№
                collectionNo = drs(0).Item(Common.Course.ColumnIndex.CollectionNo)
                '利用開始日
                useStart = drs(0).Item(Common.Course.ColumnIndex.UseStart)
                Dim loginUserCourse As DataTable = dtCourse.Clone
                For Each dr As DataRow In drs
                    loginUserCourse.ImportRow(dr)
                Next
                Serialize.DataTableToxmlFullPath(loginUserCourse, downLoadfolderName & Constant.CST_COURSE_FILENAME & Constant.CST_EXTENSION_XML)
            End If
        Next

        '模擬テスト一覧
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_MOCKTEST, Constant.CST_QUESTIONLIST_FILENAME & Constant.CST_EXTENSION_XML)
            '模擬テスト
            Dim dtQuestionList As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            mockTestName = Common.QuestionList.GetMockTestName(dtQuestionList, mockTestNo, useStart)
            If mockTestName <> "" Then
                '対応模擬テストNO
                For Each filePath2 In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_MOCKTEST, Constant.CST_QUESTION_FILENAME & mockTestName)
                    fileList.Add(filePath2)
                Next
            End If
        Next

        'テスト名
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_TESTNAME, Constant.CST_TESTNAME_FILENAME & "*")
            fileList.Add(filePath)
        Next

        '問題群
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_COLLECTION, Constant.CST_COLLECTION_FILENAME & courseNo & Constant.CST_EXTENSION_XML)
            fileList.Add(filePath)
        Next

        '演習問題一覧
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_PRACTICEQUESTION, Constant.CST_PRACTICEQUESTION_FILENAME & "*")
            fileList.Add(filePath)
        Next


        '指定テスト_ヘッダ
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_SPECIFIC_HEADER, Constant.CST_SPECIFICHEADER_FILENAME & groupId & "*")
            fileList.Add(filePath)
        Next

        '指定テスト_明細
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_SPECIFIC_DETAIL, Constant.CST_SPECIFICDETAIL_FILENAME & groupId & "_*")
            fileList.Add(filePath)
        Next

        '総合テスト_ヘッダ
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_SYNTHESIS_HEADER, Constant.CST_SYNTHESISHEADER_FILENAME & groupId & "*")
            fileList.Add(filePath)
        Next

        '総合テスト_明細
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_SYNTHESIS_DETAIL, Constant.CST_SYNTHESISDETAIL_FILENAME & groupId & "_*")
            fileList.Add(filePath)
        Next

        '再演習
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_REVIEW, Constant.CST_REVIEW_FILENAME & groupId & "_" & userId & "*")
            fileList.Add(filePath)
        Next

        'メール
        For Each fileName In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_MAIL, Constant.CST_MAIL_FILENAME & groupId & "_" & userId & "*")
            fileList.Add(fileName)
        Next
       

        'カテゴリー
        For Each filePath In System.IO.Directory.GetFiles(CST_CENTERSERVER_FOLDERPATH_CATEGORY, Constant.CST_CATEGORY_FILENAME & Constant.CST_EXTENSION_XML)
            fileList.Add(filePath)
        Next

        Return fileList
    End Function

    ''' <summary>
    ''' 受講者用試験結果データ作成
    ''' </summary>
    ''' <param name="downLoadfolderName"></param>
    ''' <param name="fileName"></param>
    ''' <param name="groupId"></param>
    ''' <param name="userId"></param>
    ''' <remarks></remarks>
    Private Sub makeTestResultData(ByVal downLoadfolderName As String, ByVal folderPath As String, ByVal fileName As String, ByVal groupId As String, ByVal userId As String)
        Dim readFilePath As String = folderPath & fileName & groupId & Constant.CST_EXTENSION_XML
        Dim writeFilePath As String = downLoadfolderName & fileName & groupId & userId & Constant.CST_EXTENSION_XML

        If IO.File.Exists(readFilePath) Then
            Dim dtRead As DataTable
            Dim dtWrite As New DataTable
            dtRead = Serialize.XmlToDataTableFullPath(readFilePath)
            If dtRead.Rows.Count > 0 Then
                dtRead.DefaultView.RowFilter = "USERID = '" & userId & "'"
                dtWrite = dtRead.DefaultView.ToTable
                If dtWrite.Rows.Count > 0 Then
                    Serialize.DataTableToxmlFullPath(dtWrite, writeFilePath)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' WebServiceUrlを書き込む
    ''' </summary>
    ''' <param name="downLoadfolderName"></param>
    ''' <remarks></remarks>
    Private Sub writeWebServiceUrlFile(downLoadfolderName As String)
        Dim dtWebServiceUrl As New DataTable
        Common.XmlSchema.GetWebServiceUrlSchema(dtWebServiceUrl)
        Dim dr As DataRow = dtWebServiceUrl.NewRow
        Select Case mode
            Case loginMode.Group
                If protocol = "https" Then
                    dr.Item(Common.WebServiceUrl.ColumnIndex.Url) = URL_WEBSERVICE_GROUP_HTTPS
                Else
                    dr.Item(Common.WebServiceUrl.ColumnIndex.Url) = URL_WEBSERVICE_GROUP_HTTP
                End If
            Case loginMode.Student, loginMode.StudentAll '団体 '受講者
                If protocol = "https" Then
                    dr.Item(Common.WebServiceUrl.ColumnIndex.Url) = URL_WEBSERVICE_STUDENT_HTTPS
                Else
                    dr.Item(Common.WebServiceUrl.ColumnIndex.Url) = URL_WEBSERVICE_STUDENT_HTTP
                End If
        End Select

        If protocol = "https" Then
            dr.Item(Common.WebServiceUrl.ColumnIndex.CommonUrl) = URL_WEBSERVICE_COMMON_HTTPS
        Else
            dr.Item(Common.WebServiceUrl.ColumnIndex.CommonUrl) = URL_WEBSERVICE_COMMON_HTTP
        End If
        dtWebServiceUrl.Rows.Add(dr)
        Common.Serialize.DataTableToxmlFullPath(dtWebServiceUrl, downLoadfolderName & Common.Constant.CST_WEBSERVICEURL_FILENAME & Common.Constant.CST_EXTENSION_XML)
    End Sub

#End Region


End Class