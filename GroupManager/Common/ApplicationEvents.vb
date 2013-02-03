Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        ''' <summary>
        ''' 受講者アプリケーションメイン処理
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs)
            Try
                '二重起動をチェックする
                If Diagnostics.Process.GetProcessesByName( _
                    Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
                    'すでに起動していると判断する
                    e.Cancel = True
                End If

                Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                If dataBanker("MENUMODE") Is Nothing Then
                    dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_GROUP
                End If
                Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
                Dim MenuMode As String = dataBanker("MENUMODE")
                Dim GroupCode As String = "*"
                Dim GroupTbl As New DataTable

                'システム管理からの遷移
                If MenuMode <> CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                    '団体情報確認
                    GroupTbl = cGroup.GetGroup(0, GroupCode)
                    If GroupTbl.Rows.Count = 1 Then
                        '削除プロセス起動
                        Dim psInfo As New ProcessStartInfo()
                        psInfo.FileName = IO.Directory.GetCurrentDirectory() & "\..\" & Constant.DeleteProcessName ' 実行するファイル
                        'psInfo.FileName = System.Windows.Forms.Application.StartupPath & "\..\" & Constant.DeleteProcessName ' 実行するファイル
                        'Program Files 以下のファイルを消す場合は、管理者権限が必要
                        'psInfo.Verb = "RunAs"   '管理者権限で実行
                        Dim myProcessId As Integer = Process.GetCurrentProcess().Id
                        psInfo.Arguments = myProcessId.ToString()
#If DEBUG Then
                        'MsgBox(psInfo.FileName)
#Else

                        If System.Configuration.ConfigurationManager.AppSettings("DELETEGROUP_FLG") = "0" Then
                            Process.Start(psInfo)
                        End If

#End If
                    End If
                    '初期処理
                    DataManager.GetInstance.Initialize()
                End If
            Catch ex As Exception
                Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                e.Cancel = True
            End Try
        End Sub
    End Class


End Namespace

