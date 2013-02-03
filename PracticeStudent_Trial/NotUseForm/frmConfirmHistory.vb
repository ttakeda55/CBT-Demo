''' <summary>
''' 履歴確認画面(JG37)
''' </summary>
''' <remarks></remarks>
Public Class frmConfirmHistory

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "履歴確認"
    ''' <summary>画面表示ID(JG15)</summary>
    Private Const DISPLAY_ID_JG15 As String = "JG15"
    ''' <summary>画面表示ID(JG37)</summary>
    Private Const DISPLAY_ID_JG37 As String = "JG37"
    ''' <summary>画面表示ID(JG38)</summary>
    Private Const DISPLAY_ID_JG38 As String = "JG38"
    ''' <summary>画面表示ID(JG39)</summary>
    Private Const DISPLAY_ID_JG39 As String = "JG39"
    ''' <summary>画面表示ID(JG41)</summary>
    Private Const DISPLAY_ID_JG41 As String = "JG41"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "履歴確認画面"
#End Region

#Region "----- メンバ変数 ----- "

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

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

#End Region

#Region "-----　イベント -----"

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmConfirmHistory_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            'Me.Text = DISPLAY_NAME
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG37
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            '親フォーム非表示
            Owner.Hide()
            Show()
            Refresh()
            'フォーカス設定
            Me.btnMiddlePractice.Focus()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 逐次演習履歴ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMiddlePractice_Click(sender As System.Object, e As System.EventArgs) Handles btnMiddlePractice.Click

        Try

            'イベントログ開始
            logger.Start()

            Dim frm As New frmPracticeConfirmHistory
            Me.Hide()
            '逐次演習履歴画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 小テスト履歴ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSmallTest_Click(sender As System.Object, e As System.EventArgs) Handles btnSmallTest.Click

        Try

            'イベントログ開始
            logger.Start()

            Dim frm As New frmSmallTestHistoryList
            Me.Hide()
            '小テスト履歴一覧画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 総合テスト履歴ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnIntegrativeTest_Click(sender As System.Object, e As System.EventArgs) Handles btnIntegrativeTest.Click

        Try

            'イベントログ開始
            logger.Start()

            Dim frm As New frmSynthesisTestHistory
            Me.Hide()
            '総合テスト履歴一覧画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 問題演習メニューへ戻るボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackPracticeMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnBackPracticeMenu.Click
        Try
            logger.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG15

            Me.Close()
        Catch ex As Exception
            'ログ出力
            logger.Error(ex)
            'エラーメッセージ
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            logger.End()
        End Try
    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            'イベントログ出力
            logger.Start()

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
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            logger.End()
        End Try
    End Sub

#End Region

End Class