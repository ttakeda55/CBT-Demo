Public Class frmClear

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim path As String = IO.Path.GetDirectoryName(Common.Constant.GetTempPath)
        If IO.Directory.Exists(path) Then
            CBTCommon.Utility.DeleteDirectory(path)
        End If
        IO.Directory.CreateDirectory(path)
        My.Computer.FileSystem.WriteAllText(path & "..\Category.xml", My.Resources.Category, False)

        Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class