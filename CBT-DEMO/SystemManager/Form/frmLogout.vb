Public Class frmLogout
#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region
#Region "イベントハンドラ"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmLogout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Text = "ログアウト"
            lblBottomCode.Text = "CG05"
            lblBottomName.Text = "ログアウト画面"

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            logger.Start()
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ログイン画面に遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            logger.Start()
            Me.DialogResult = DialogResult.OK
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

End Class