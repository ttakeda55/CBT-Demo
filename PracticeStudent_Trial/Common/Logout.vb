Imports System.IO

''' <summary>
''' ログアウト共通処理
''' </summary>
''' <remarks></remarks>
Public Class Logout

    ''' <summary>
    ''' ログアウト共通処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Logout() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            If DialogResult.OK = Common.Message.MessageShow("Q" & Constant.QuestionMessageCode.LogoutConfirm) Then
                '受講者ファイルアップロード
                Dim upFile As New List(Of String)
                upFile.Add(IO.Path.GetFileName(DataManager.GetInstance.StudentFileName))
#If DEBUG Then
#Else
                'If Not UploadFile(upFile) Then Return Constant.ResultCode.UploadError
                ''ログファイルアップロード
                'Call LogFileUpLoad()
#End If
                '自プロセスを終了するように、ログアウトフラグを立てる
                DataManager.GetInstance().IsLogouting = True
                '削除プロセス起動
                errCode = ExecDeleteStudent()
            Else
                errCode = Constant.ResultCode.Cancel
            End If
        Catch ex As Exception
            'ログ出力
            Dim _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New Logout)
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    Private Shared Sub LogFileUpLoad()

        Try
            Dim searchPattern As String = "log*"
            For Each fromFileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath() & "log", searchPattern)
                Dim upLoadFileName As String = Path.GetFileName(fromFileName)
                Dim toFileName As String = Common.Constant.GetTempPath & "log\copy" & upLoadFileName
                'ファイルコピー
                File.Copy(fromFileName, toFileName, True)
                Dim fileData() As Byte = IO.File.ReadAllBytes(toFileName)
                'アップロード
                DataManager.GetInstance.WebService.LogFileUpLoad(upLoadFileName, fileData, DataManager.GetInstance.GroupCode, DataManager.GetInstance.UserId)
            Next
        Catch ex As Exception
            'ログ出力
            Dim _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New Logout)
            _Log.Error(ex)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 指定のファイルをUploadします。
    ''' </summary>
    ''' <param name="upFileList">Upload するファイル</param>
    ''' <returns>true : 全てのアップロード成功、false : いずれかのアップロード失敗</returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFile(ByVal upFileList As List(Of String)) As Boolean
        Dim ret As Boolean = True
        Dim result As Integer = 0
        Dim cntFailed As Integer = 0
        Dim errMsg As String = ""
        Dim _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New Logout)
        '#If DEBUG Then
        '#Else
        Dim wbs As New WebService.Student
        'wbs.Url = DataManager.GetInstance.WebServiceUrl
        'wbs = DataManager.GetInstance.WebService
        'UpLoad
        For Each upFile As String In upFileList
            If upFile <> "" Then
                cntFailed = 0
                While True
                    Try
                        If cntFailed = DataManager.GetInstance.FileDownloadFailed Then
                            ' 指定した回数分失敗した場合
                            result = 1
                            Exit While
                        ElseIf wbs.PracticeResultFileUpLoad(upFile, IO.File.ReadAllBytes(Common.Constant.GetTempPath & upFile)) Then
                            ' アップロードに成功した場合
                            Exit While
                        Else
                            ' 失敗回数の更新
                            cntFailed += 1
                        End If
                        Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)

                    Catch exWeb As Web.Services.Protocols.SoapException
                        ' WebServiceでの例外
                        cntFailed += 1
                        _Log.Error(exWeb)
                        Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)
                    Catch exNet As Net.WebException
                        ' Net.WebExceptionでの例外
                        cntFailed += 1
                        _Log.Error(exNet)
                        Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)
                    Catch ex As Exception
                        _Log.Error(ex)
                        errMsg = ex.Message
                        result = 2
                        Exit While
                    End Try
                End While

                Select Case result
                    Case 0

                    Case 1
                        Common.Message.MessageShow("E" & CType(Constant.ResultCode.UploadError, Integer).ToString.PadLeft(3, "0"))
                        ret = False
                        Exit For
                    Case 2
                        Call MsgBox(errMsg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                        ret = False
                        Exit For
                End Select
            End If
        Next
        '#End If
            Return ret
    End Function

    ''' <summary>
    ''' 削除プロセス起動
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecDeleteStudent() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '削除プロセス起動(処理タイプを削除にする)
            Dim psInfo As New ProcessStartInfo()
            psInfo.FileName = IO.Directory.GetCurrentDirectory() & "\..\" & Constant.DeleteProcessName ' 実行するファイル
            'Program Files 以下のファイルを消す場合は、管理者権限が必要
            'psInfo.Verb = "RunAs"   '管理者権限で実行
            Dim myProcessId As Integer = Process.GetCurrentProcess().Id
            psInfo.Arguments = myProcessId.ToString() & ", 1"
            Process.Start(psInfo)
        Catch ex As Exception
            'ログ出力
            Dim _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New Logout)
            _Log.Error(ex)
            errCode = Constant.ResultCode.ProcessStartError
        End Try
        Return errCode
    End Function

End Class
