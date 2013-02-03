Public Class BaseTestForm
    Inherits BaseForm

    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    Private _MenuMode As Boolean
    Public Property UserId
        Get
            Return lblUserId.Text
        End Get
        Set(ByVal value)
            dataBanker("USERID") = value
            lblUserId.Text = value
        End Set
    End Property

    Public Property UserName
        Get
            Return lblUserName.Text
        End Get
        Set(ByVal value)
            dataBanker("USERNAME") = value
            lblUserName.Text = value
        End Set
    End Property


    Private Sub lblUserSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class