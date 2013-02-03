﻿
''' <summary>
''' 受講者登録トップ
''' </summary>
''' <remarks>
''' 2011/09/07 NOZAO 新規作成
''' </remarks>
Public Class frmQuestionListTop

#Region "イベントハンドラ"


    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackSystemManager.Click
        Try
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMenberAddTop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnPracticeQuestionList.Focus()
            Owner.Hide()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 受講者一括登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPracticeQuestionList.Click
        Try
            Dim frm As New frmPracticeQuestionList
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                Show()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 受講者個別修正
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInput_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuestionList.Click
        Try
            Dim frm As New frmQuestionList
            frm.ShowDialog(Me)
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance()
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                If dataBanker("LOGOUT") Then
                    Me.Close()
                Else
                    Show()
                End If
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
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
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

End Class