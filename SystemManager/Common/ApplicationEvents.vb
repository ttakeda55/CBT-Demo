Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Try

                '二重起動をチェックする
                If Diagnostics.Process.GetProcessesByName( _
                    Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
                    'すでに起動していると判断する
                    e.Cancel = True
                End If

                '初期処理
                CBTCommon.DataBanker.GetInstance().Item("MENUMODE") = Common.Constant.CST_MENUMODE_SYSTEM
                Common.DataManager.GetInstance.MenuMode = Common.DataManager.MenuModeType.SystemManager
                Common.DataManager.GetInstance.Initialize()

            Catch ex As Exception
                Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                e.Cancel = True
            End Try
        End Sub
    End Class
End Namespace

