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
        Private Sub MyApplication_Startup()
            'Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            Dim errCode As Constant.ResultCode = GDataManager.GetInstance().Initialize()
            Dim MenuMode As String = dataBanker("MENUMODE")

            If errCode <> Constant.ResultCode.NormalEnd Then
                Common.Message.MessageShow("E" & errCode)
                'e.Cancel = True
            Else
#If DEBUG Then
#Else
                Try
                    'システム管理からの遷移
                    If MenuMode <> CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                        '削除プロセス起動
                        Dim psInfo As New ProcessStartInfo()
                        psInfo.FileName = IO.Directory.GetCurrentDirectory() & "\..\" & Constant.DeleteProcessName ' 実行するファイル
                        psInfo.Verb = "RunAs"   '管理者権限で実行
                        Dim myProcessId As Integer = Process.GetCurrentProcess().Id
                        psInfo.Arguments = myProcessId.ToString()
                        Process.Start(psInfo)
                    End If
                Catch ex As Exception
                    Common.Message.MessageShow("E" & Constant.ResultCode.ProcessStartError)
                    'e.Cancel = True
                End Try
#End If
            End If
        End Sub
    End Class


End Namespace

