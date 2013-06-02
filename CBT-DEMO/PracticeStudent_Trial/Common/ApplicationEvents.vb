Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            '二重起動をチェックする
            If Diagnostics.Process.GetProcessesByName( _
                Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
                'すでに起動していると判断する
                e.Cancel = True
            End If
            Common.DataManager.GetInstance.MenuMode = Common.DataManager.MenuModeType.Student
            PracticeStudent_Trial.DataManager.GetInstance.Edition = CInt(System.Configuration.ConfigurationManager.AppSettings("EDITION"))
            Common.DataManager.GetInstance.setChoiceMark()
            'If IO.Directory.Exists(System.Configuration.ConfigurationManager.AppSettings("TESTRESULT_SHARE_FOLDER")) = False Then
            '    MessageBox.Show("試験結果収集フォルダが見つかりません。" & vbCrLf & "共有フォルダの設定を確認してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        End Sub

    End Class


End Namespace

