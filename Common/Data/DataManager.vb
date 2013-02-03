Imports System.Configuration

Public Class DataManager

#Region "----- 定数 -----"
    ''' <summary>
    ''' メニューモード定数
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum MenuModeType As Integer
        SystemManager = 0
        Student
    End Enum
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>インスタンス</summary>
    Private Shared _instance As New DataManager

    ''' <summary>ファイルリスト</summary>
    Private Shared _dtLocalFileList As New DataTable

    ''' <summary>サーバとローカルの時刻差分</summary>
    Private Shared _dateTimeSpan As New TimeSpan(0, 0, 0)

    ''' <summary>アップロードするかどうか</summary>
    Private Shared _UpLoad_Flg As Boolean = True

    ''' <summary>ダウンロードロードするかどうか</summary>
    Private Shared _DownLoad_Flg As Boolean = True

    ''' <summary>tempフォルダパス</summary>
    Private Shared _tempPath As String = IO.Path.GetTempPath & ConfigurationManager.AppSettings("TEMP_FOLDER") & "\"
    Private Shared _tempSubPath As String = ""

#End Region

#Region "----- プロパティ -----"
    ''' <summary>tempフォルダパス</summary>
    Public Property TempPath As String
        Get
            Return _tempPath
        End Get
        Set(value As String)
            _tempPath = value
        End Set
    End Property

    ''' <summary>tempフォルダパス</summary>
    Public Property TempSubPath As String
        Get
            Return _tempSubPath
        End Get
        Set(ByVal value As String)
            _tempSubPath = value
        End Set
    End Property

    ''' <summary>
    ''' メニューモード
    ''' </summary>
    ''' <remarks></remarks>
    Private _menuMode As MenuModeType
    Public Property MenuMode As MenuModeType
        Get
            Return _menuMode
        End Get
        Set(value As MenuModeType)
            _menuMode = value
        End Set
    End Property

    ''' <summary>
    ''' 選択肢記号
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _choiceMark As ChoiceMark
    Public Property ChoiceMark As ChoiceMark
        Get
            Return _choiceMark
        End Get
        Set(value As ChoiceMark)
            _choiceMark = value
        End Set
    End Property
#End Region

#Region "----- コンストラクタ -----"
    Private Sub New()
        _tempPath = IO.Path.GetTempPath & ConfigurationManager.AppSettings("TEMP_FOLDER") & "\"
        If Not IO.Directory.Exists(_tempPath) Then
            IO.Directory.CreateDirectory(_tempPath)
        End If
    End Sub
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
    ''' 初期化
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Initialize() As Boolean
        Initialize = True
        _dtLocalFileList = getLocalFileList()

        Try
            'ダウンロードするかどうか
            _DownLoad_Flg = IIf(ConfigurationManager.AppSettings("DOWNLOAD_FLG") = "0", True, False)
            CBTCommon.DataBanker.GetInstance.Item("DOWNLOAD_FLG") = _DownLoad_Flg
            'アップロードするかどうか
            _UpLoad_Flg = IIf(ConfigurationManager.AppSettings("UPLOAD_FLG") = "0", True, False)
            CBTCommon.DataBanker.GetInstance.Item("UPLOAD_FLG") = _UpLoad_Flg

            If _DownLoad_Flg Or _UpLoad_Flg Then
                WebServiceWrapper.Initialize()
                Dim dateTime As New DateTime
                If WebServiceWrapper.GetInstance.GetServerDateTime(dateTime) Then
                    _dateTimeSpan = dateTime - System.DateTime.Now
                End If
            End If
            setChoiceMark()
        Catch ex As System.Net.WebException
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 選択肢記号を設定します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setChoiceMark()
        '選択肢記号
        ChoiceMark = New ChoiceMark(ConfigurationManager.AppSettings("CHOICEMARKTYPE"),
                                    CInt(ConfigurationManager.AppSettings("CHOICEMARKCOUNT")),
                                    CBool(ConfigurationManager.AppSettings("FULLWIDHCHARACTERS")),
                                    CBool(ConfigurationManager.AppSettings("UPPERCASE")))
    End Sub
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
                '更新
                For Each drLocal As DataRow In _dtLocalFileList.Rows
                    If OutsideScopeFileName(drLocal("FILENAME")) Then
                        Dim contents As Byte() = Nothing
                        Dim drsNewLocal As DataRow() = dtNewLocalFileList.Select("FILENAME = '" & drLocal("FILENAME") & "'")
                        If drsNewLocal.Length > 0 Then
                            If Date.Parse(drsNewLocal(0).Item("LASTWRITETIME")) > Date.Parse(drLocal("LASTWRITETIME")) Then '更新
                                Dim filePath As String = Common.Constant.GetTempPath & drLocal("FILENAME")
                                WebServiceWrapper.GetInstance.FileUpLoad_DATA(drLocal("FILENAME"), IO.File.ReadAllBytes(filePath))
                            End If
                        Else '削除
                            WebServiceWrapper.GetInstance.FileDelete_DATA(drLocal("FILENAME"))
                        End If
                    End If

                Next

                '追加
                For Each drNewLocal As DataRow In dtNewLocalFileList.Rows
                    If OutsideScopeFileName(drNewLocal("FILENAME")) Then
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
    ''' ファイルをダウンロードする
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>ローカルファイルとサーバのファイルを比較し、最新のファイルをダウンロードする</remarks>
    Public Function DownLoadFile() As Boolean
        Try
            'システム管理から遷移する場合のみダウンロード
            If CBTCommon.DataBanker.GetInstance("MENUMODE") = Common.Constant.CST_MENUMODE_SYSTEM Then
                If _DownLoad_Flg Then
                    '更新がある場合ダウンロードの前にアップロード
                    UpLoadFile()

                    'サーバのファイル一覧を取得
                    Dim dtServerFileList As New DataTable
                    dtServerFileList.TableName = "FILELIST"
                    If Not WebServiceWrapper.GetInstance.GetFileList(dtServerFileList) Then
                        Return False
                    End If

                    'ローカルのファイル情報を取得
                    Dim dtLocalFileList As DataTable = getLocalFileList()

                    'ファイル一覧を比較して、最新情報のみ取得
                    For Each drServer As DataRow In dtServerFileList.Rows
                        If OutsideScopeFileName(drServer("FILENAME")) Then
                            Dim contents As Byte() = Nothing
                            Dim drsLocal As DataRow() = dtLocalFileList.Select("FILENAME = '" & drServer("FILENAME") & "'")
                            If drsLocal.Length = 0 OrElse _
                                Date.Parse(drsLocal(0).Item("LASTWRITETIME")).Add(_dateTimeSpan) < Date.Parse(drServer("LASTWRITETIME")) Then
                                WebServiceWrapper.GetInstance.FileDownLoad_DATA(drServer("FILENAME"), contents)
                                IO.File.WriteAllBytes(Common.Constant.GetTempPath & drServer("FILENAME"), contents)
                            End If
                        End If
                    Next

                    _dtLocalFileList = getLocalFileList()
                End If
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
    ''' ファイルをダウンロードする
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>ローカルファイルとサーバのファイルを比較し、最新のファイルをダウンロードする</remarks>
    Public Function DownLoadFile(ByVal downLoadFileName As String, ByVal savePath As String) As Boolean
        Try
            If _DownLoad_Flg Then
                'サーバのファイル一覧を取得
                Dim dtServerFileList As New DataTable
                dtServerFileList.TableName = "FILELIST"
                If Not WebServiceWrapper.GetInstance.GetFileList(dtServerFileList) Then
                    Return False
                End If

                'ローカルのファイル情報を取得
                Dim dtLocalFileList As DataTable = getLocalFileList()

                'ファイル一覧を比較して、最新情報のみ取得
                For Each drServer As DataRow In dtServerFileList.Rows
                    If OutsideScopeFileName(drServer("FILENAME")) Then
                        Dim contents As Byte() = Nothing
                        If System.Text.RegularExpressions.Regex.IsMatch("^" & drServer("FILENAME"), downLoadFileName) Then
                            Dim drsLocal As DataRow() = dtLocalFileList.Select("FILENAME = '" & drServer("FILENAME") & "'")
                            If drsLocal.Length = 0 OrElse _
                                Date.Parse(drsLocal(0).Item("LASTWRITETIME")).Add(_dateTimeSpan) < Date.Parse(drServer("LASTWRITETIME")) Then
                                WebServiceWrapper.GetInstance.FileDownLoad_DATA(drServer("FILENAME"), contents)
                                IO.File.WriteAllBytes(savePath & drServer("FILENAME"), contents)
                            End If
                        End If
                    End If
                Next
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
                            WebServiceWrapper.GetInstance.UpLoadLogFile(IO.Path.GetFileName(filePath), IO.File.ReadAllBytes(filePath & ".log"))
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
    Public Shared Function getLocalFileList() As DataTable
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
    ''' サーバ時刻を取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDateTime() As DateTime
        Return System.DateTime.Now.Add(_dateTimeSpan)
    End Function

    ''' <summary>
    ''' 処理対象外ファイル
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OutsideScopeFileName(ByVal fileName As String) As Boolean
        Dim ret As Boolean = True
        If ret = True And fileName Like "Help*" Then ret = False
        If ret = True And fileName Like "HELP*" Then ret = False
        If ret = True And fileName Like "Infomation.txt" Then ret = False

        Return ret
    End Function
#End Region
End Class
