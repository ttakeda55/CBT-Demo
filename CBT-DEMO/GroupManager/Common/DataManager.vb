Imports System.Configuration

''' <summary>
''' データマネージャー
''' </summary>
Public Class DataManager

#Region "----- メンバ変数 -----"
    ''' <summary>インスタンス</summary>
    Private Shared _instance As New DataManager

    ''' <summary>ファイルリスト</summary>
    Private Shared _dtLocalFileList As New DataTable

    ''' <summary>サーバとローカルの時刻差分</summary>
    Private Shared _dateTimeSpan As New TimeSpan(0, 0, 0)

    ''' <summary>団体コード</summary>
    Private Shared _groupCode As String = ""

    ''' <summary>アップロードするかどうか</summary>
    Private Shared _UpLoad_Flg As Boolean = True

    ''' <summary>ダウンロードロードするかどうか</summary>
    Private Shared _DownLoad_Flg As Boolean = True
#End Region

#Region "----- コンストラクタ -----"
    Private Sub New()
    End Sub
#End Region

#Region "----- プロパティ -----"
    ''' <summary>団体コード</summary>
    Public Property groupCode As String
        Get
            Return _groupCode
        End Get
        Set(value As String)
            _groupCode = value
        End Set
    End Property

#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' インスタンスを取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As DataManager
        Return _instance
    End Function

    ''' <summary>
    ''' ファイルをアップロードする
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>更新前のローカルファイルと現在のローカルファイルをファイルを比較し最新情報でサーバを更新する。</remarks>
    Public Function UpLoadFile() As Boolean
        Try
            If _UpLoad_Flg Then
                UpLoadFile = False
                '現在のローカルファイルを取得
                Dim dtNewLocalFileList As DataTable = getLocalFileList()

                'ファイル一覧を比較する。
                '更新・削除
                For Each drLocal As DataRow In _dtLocalFileList.Rows
                    Dim contents As Byte() = Nothing
                    If checkUpLoadFileName(drLocal("FILENAME")) Then
                        Dim drsNewLocal As DataRow() = dtNewLocalFileList.Select("FILENAME = '" & drLocal("FILENAME") & "'")
                        If drsNewLocal.Length > 0 Then
                            If Date.Parse(drsNewLocal(0).Item("LASTWRITETIME")) > Date.Parse(drLocal("LASTWRITETIME")) Then '更新
                                Dim filePath As String = Common.Constant.GetTempPath & drLocal("FILENAME")
                                WebServiceWrapper.GetInstance.FileUpLoad_DATA(drLocal("FILENAME"), IO.File.ReadAllBytes(filePath))
                            End If
                        Else '削除
                        End If
                    End If
                Next

                '追加
                For Each drNewLocal As DataRow In dtNewLocalFileList.Rows
                    If checkUpLoadFileName(drNewLocal("FILENAME")) Then
                        Dim contents As Byte() = Nothing
                        Dim drsLocal As DataRow() = _dtLocalFileList.Select("FILENAME = '" & drNewLocal("FILENAME") & "'")
                        If drsLocal.Length = 0 Then
                            Dim filePath As String = Common.Constant.GetTempPath & drNewLocal("FILENAME")
                            WebServiceWrapper.GetInstance.FileUpLoad_DATA(drNewLocal("FILENAME"), IO.File.ReadAllBytes(filePath))
                        End If
                    End If
                Next

                'ファイル情報を更新
                _dtLocalFileList = getLocalFileList()
            End If

            Return True
        Catch ex As System.Net.WebException
            Common.Message.MessageShow("E043")
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' ログファイルをアップロードする
    ''' </summary>
    ''' 
    ''' <returns></returns>
    ''' <remarks>本日更新されたログファイルのみアップロードする</remarks>
    Public Function UpLoadLogFile() As Boolean
        Try
            If _UpLoad_Flg Then
                If IO.Directory.Exists(Common.Constant.GetTempPath & "log") Then
                    Dim files As String() = System.IO.Directory.GetFiles(Common.Constant.GetTempPath & "log", "*", System.IO.SearchOption.TopDirectoryOnly)
                    For Each filePath As String In files
                        If System.IO.File.GetLastWriteTime(filePath).ToShortDateString = System.DateTime.Now.ToShortDateString Then
                            IO.File.Delete(filePath & ".log")
                            IO.File.Copy(filePath, filePath & ".log")
                            WebServiceWrapper.GetInstance.UpLoadLogFile(_groupCode, IO.Path.GetFileName(filePath), IO.File.ReadAllBytes(filePath & ".log"))
                            IO.File.Delete(filePath & ".log")
                        End If
                    Next
                End If
            End If

            Return True
        Catch ex As Exception
            Return True
        End Try
    End Function

    ''' <summary>
    ''' ローカルのファイルの一覧を取得する
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getLocalFileList() As DataTable
        Dim files As String() = System.IO.Directory.GetFiles(Common.Constant.GetTempPath, "*", System.IO.SearchOption.TopDirectoryOnly)
        Dim dtLocalFileList As New DataTable
        dtLocalFileList.Columns.Add("FILENAME")
        dtLocalFileList.Columns.Add("LASTWRITETIME")
        For Each fileName As String In files
            Dim dr As DataRow = dtLocalFileList.NewRow
            dr("FILENAME") = IO.Path.GetFileName(fileName)
            dr("LASTWRITETIME") = System.IO.File.GetLastWriteTime(fileName)
            dtLocalFileList.Rows.Add(dr)
        Next
        Return dtLocalFileList
    End Function

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Initialize() As Boolean
        Initialize = True
        Try
            _dtLocalFileList = getLocalFileList()
            
            'ダウンロードするかどうか
            _DownLoad_Flg = IIf(ConfigurationManager.AppSettings("DOWNLOAD_FLG") = "0", True, False)
            CBTCommon.DataBanker.GetInstance.Item("DOWNLOAD_FLG") = _DownLoad_Flg
            'アップロードするかどうか
            _UpLoad_Flg = IIf(ConfigurationManager.AppSettings("UPLOAD_FLG") = "0", True, False)
            CBTCommon.DataBanker.GetInstance.Item("UPLOAD_FLG") = _UpLoad_Flg

        Catch ex As System.Net.WebException
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' サーバ時刻を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDateTime() As DateTime
        Return System.DateTime.Now.Add(_dateTimeSpan)
    End Function

    ''' <summary>
    ''' ダウンロード対象ファイルチェック
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkDownLoadFileName(ByVal fileName As Object) As Boolean
        Dim ret As Boolean = False
        If ret = False And fileName Like Common.Constant.CST_TESTHEAD_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_TESTDETAIL_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SERIALRESULTHEADER_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SERIALRESULTDETAIL_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_MINIRESULTHEADER_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_MINIRESULTDETAIL_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & "*" Then ret = True

        Return ret
    End Function

    ''' <summary>
    ''' アップロード対象ファイルチェック
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkUpLoadFileName(ByVal fileName As Object) As Boolean
        Dim ret As Boolean = False
        If ret = False And fileName Like Common.Constant.CST_SYNTHESISHEADER_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SYNTHESISDETAIL_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SPECIFICHEADER_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_SPECIFICDETAIL_FILENAME & "*" Then ret = True
        If ret = False And fileName Like Common.Constant.CST_GROUP_FILENAME & "*" Then ret = True

        Return ret
    End Function

    ''' <summary>
    ''' EXCELチェック
    ''' </summary>
    ''' <remarks></remarks>
    Public Function IsExcel() As Boolean
        Try
            Dim ExcelApp As Type = Type.GetTypeFromProgID("Excel.Application")
            If IsNothing(ExcelApp) Then
                Return False
            Else
                Return True
            End If
        Finally
        End Try
        Return False
    End Function
#End Region

End Class
