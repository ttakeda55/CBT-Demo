Public Class frmSetTestName

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtTestName.Text = "" Then
            Common.Message.MessageShow("E005", {"テスト名"})
            Exit Sub
        End If
        'ファイル読込
        Common.TestName.WriteTestName(txtTestName.Text)
        Common.Message.MessageShow("I004")
        Close()
    End Sub

    Private Sub frmSetTestName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'ファイル読込
        txtTestName.Text = Common.TestName.GetTestName
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close
    End Sub
End Class