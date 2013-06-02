''' <summary>
''' 団体登録トップ(TG02)
''' <img src="..\Images\TG02.png" />
''' </summary>
''' <remarks>
''' 2011/09/07 NOZAO 新規作成
''' </remarks>
Public Class frmGroupManagerTop

#Region "イベントハンドラ"
    ''' <summary>
    ''' 団体登録画面に遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim frm As New frmGroupManagerAdd
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
    ''' システム管理者画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackSystemManager.Click
        Try
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 団体管理トップ画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmGroupManagerTop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "団体登録トップ"
            lblBottomCode.Text = "TG09"
            lblBottomName.Text = "団体登録トップ画面"

            btnAdd.Focus()
            Owner.Hide()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 団体更新修正画面に遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Dim frm As New frmGroupEdit
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