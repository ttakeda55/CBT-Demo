Public Class BaseForm
    Public WriteOnly Property processMessage()
        Set(ByVal value)
            lblProcessMessage.BringToFront()
            lblProcessMessage.Text = "処理中です。しばらくお待ちください。"
            lblProcessMessage.Visible = value
            Me.Refresh()
        End Set
    End Property
    Public WriteOnly Property processMessageLogout()
        Set(ByVal value)
            lblProcessMessage.BringToFront()
            lblProcessMessage.Text = "ログアウトしています。しばらくお待ちください。"
            lblProcessMessage.Visible = value
            Me.Refresh()
        End Set
    End Property
    Public WriteOnly Property processMessageOutput()
        Set(ByVal value)
            lblProcessMessage.BringToFront()
            lblProcessMessage.Text = "保存中です。しばらくお待ちください。"
            lblProcessMessage.Visible = value
            Me.Refresh()
        End Set
    End Property
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Me.Location = MyBase.Location
    End Sub


    ''' <summary>
    ''' 閉じるボタンの無効化
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides ReadOnly Property CreateParams() As  _
            System.Windows.Forms.CreateParams
        <System.Security.Permissions.SecurityPermission( _
            System.Security.Permissions.SecurityAction.LinkDemand, _
            Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
        Get
            Const CS_NOCLOSE As Integer = &H200
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE

            Return cp
        End Get
    End Property

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BaseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Activate()
    End Sub

    Private Sub BaseForm_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblTitle01.Text = "ＣＢＴコンピューター試験体験版"
    End Sub

    Public Sub setTitle()
        lblTitle01.Text = "ＣＢＴコンピューター試験体験版"
    End Sub

End Class
