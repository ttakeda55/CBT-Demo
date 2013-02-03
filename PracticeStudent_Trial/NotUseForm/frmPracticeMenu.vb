''' <summary>
''' 問題演習メニュー画面(JG15)
''' </summary>
''' <remarks></remarks>
Public Class frmPracticeMenu

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "問題演習メニュー"
    ''' <summary>画面表示ID(JG15)</summary>
    Private Const DISPLAY_ID_JG15 As String = "JG15"
    ''' <summary>画面表示ID(JG14)</summary>
    Private Const DISPLAY_ID_JG14 As String = "JG14"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "問題演習メニュー画面"
#End Region

#Region "----- メンバ変数 ----- "
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "-----　メソッド -----"

    ''' <summary>
    ''' お知らせ再設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub mailClosed()
        Try
            'お知らせを削除する
            DataManager.GetInstance.Infomation = ""
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ボタン制御
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ButtonEnable()
        Try
            '小問演習、中問演習、小テスト
            If DataManager.GetInstance.PracticeQuestionDefine.IsReadPracticeQuestion AndAlso DataManager.GetInstance.PracticeQuestionDefine.IsReadCollection Then
                Me.btnSmallPractice.Enabled = True
                Me.btnMiddlePractice.Enabled = True
                Me.btnSmallTest.Enabled = True
            End If
            '小テスト
            'If DataManager.GetInstance.PracticeQuestionDefine.IsReadPracticeQuestion _
            '        AndAlso DataManager.GetInstance.PracticeQuestionDefine.IsReadCollection _
            '        AndAlso DataManager.GetInstance.SpecificDefine.IsReadSpecificHeader _
            '        AndAlso DataManager.GetInstance.SpecificDefine.IsReadSpecificDetail Then
            '    Me.btnSmallTest.Enabled = True
            'End If
            '総合テスト
            If DataManager.GetInstance.PracticeQuestionDefine.IsReadPracticeQuestion _
                    AndAlso DataManager.GetInstance.PracticeQuestionDefine.IsReadCollection _
                    AndAlso DataManager.GetInstance.SynthesisDefine.IsReadSynthesisHeader _
                    AndAlso DataManager.GetInstance.SynthesisDefine.IsReadSynthesisDetail Then
                Me.btnIntegrativeTest.Enabled = True
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

#Region "-----　イベント -----"

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmPracticeMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()

            'ボタン制御
            Call ButtonEnable()
            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG15
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            '親フォーム非表示
            Owner.Hide()
            Show()
            Refresh()
            'フォーカス設定
            Me.btnSmallPractice.Focus()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 小問演習ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSmallPractice_Click(sender As System.Object, e As System.EventArgs) Handles btnSmallPractice.Click
        Try
            'イベントログ出力
            _Log.Start()
            Dim frm As New frmSmallPracticeTop
            Me.Hide()
            '小問逐次演習メニュー画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 中問演習ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMiddlePractice_Click(sender As System.Object, e As System.EventArgs) Handles btnMiddlePractice.Click
        Try
            'イベントログ出力
            _Log.Start()
            Dim frm As New frmMiddlePracticeTop
            Me.Hide()
            '中問逐次演習メニュー画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 小テストボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSmallTest_Click(sender As System.Object, e As System.EventArgs) Handles btnSmallTest.Click
        Try
            'イベントログ出力
            _Log.Start()
            Dim frm As New frmSmallTestMenuTop
            Me.Hide()
            '小テスト演習メニュー画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 総合テストボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnIntegrativeTest_Click(sender As System.Object, e As System.EventArgs) Handles btnIntegrativeTest.Click
        Try
            'イベントログ出力
            _Log.Start()
            Dim frm As New frmTestTop
            Me.Hide()
            '総合テスト演習メニュー画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 演習履歴確認ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPracticeHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnPracticeHistory.Click
        Try
            'イベントログ出力
            _Log.Start()
            Dim frm As New frmConfirmHistory
            Me.Hide()
            '演習履歴確認メニュー画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
        
    End Sub

    ''' <summary>
    ''' メインメニューへ戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackMainMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnBackMainMenu.Click
        Try
            _Log.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG14

            Me.Close()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' ログアウト処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            'イベントログ出力
            _Log.Start()

            'ログアウト処理
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.UploadError, Integer).ToString.PadLeft(3, "0"))
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
    End Sub

#End Region

End Class