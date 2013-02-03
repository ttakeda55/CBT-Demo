''' <summary>
''' 分析トップ
''' </summary>
''' <remarks>
''' 2011/09/06 NAKAMURA 新規作成
''' </remarks>
Public Class frmAnalysisMenu
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
    Private Sub frmAnalysisMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            Me.lblBottomCode.Text = "KG09"
            Me.lblBottomName.Text = "分析トップ画面"
            Me.UserId = "ID：" & dataBanker.Item("USERID")
            Me.UserName = "氏名：" & dataBanker.Item("USERNAME")

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 管理者メインメニューへ戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 得点分析
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScore.Click
        Try
            logger.Start()
            Dim frmNext As New frmScoreAnalysis
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            '呼び出し設定
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = "KG11"
            'Me.Hide()
            frmNext.ShowDialog(Me)
            If dataBanker.Item("TOFORM") = "KG09" And Not dataBanker("LOGOUT") Then
                Me.Show()
            Else
                Me.Close()
            End If
            frmNext.Dispose()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問別分析
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuestion.Click
        Try
            logger.Start()
            Dim frmNext As New frmQuestionReport
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            '呼び出し設定
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = "KG13"
            'Me.Hide()
            frmNext.ShowDialog(Me)
            If dataBanker.Item("TOFORM") = "KG09" And Not dataBanker("LOGOUT") Then
                Me.Show()
            Else
                Me.Close()
            End If
            frmNext.Dispose()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            logger.Start()
            processMessageLogout = True
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
            End Select
            processMessageLogout = False
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

End Class