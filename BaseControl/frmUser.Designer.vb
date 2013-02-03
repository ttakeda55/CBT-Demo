<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCangePassWord = New System.Windows.Forms.Button()
        Me.txtNewPassWord2 = New System.Windows.Forms.TextBox()
        Me.txtNewPassWord1 = New System.Windows.Forms.TextBox()
        Me.txtOldPassWord = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBottomName = New System.Windows.Forms.Label()
        Me.lblBottomCode = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(54, 47)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(100, 19)
        Me.lblLogin.TabIndex = 22
        Me.lblLogin.Text = "ユーザ設定"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCangePassWord)
        Me.Panel1.Controls.Add(Me.txtNewPassWord2)
        Me.Panel1.Controls.Add(Me.txtNewPassWord1)
        Me.Panel1.Controls.Add(Me.txtOldPassWord)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Panel1.Location = New System.Drawing.Point(126, 85)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 191)
        Me.Panel1.TabIndex = 23
        '
        'btnCangePassWord
        '
        Me.btnCangePassWord.Location = New System.Drawing.Point(347, 143)
        Me.btnCangePassWord.Name = "btnCangePassWord"
        Me.btnCangePassWord.Size = New System.Drawing.Size(108, 30)
        Me.btnCangePassWord.TabIndex = 40
        Me.btnCangePassWord.Text = "パスワード変更"
        Me.btnCangePassWord.UseVisualStyleBackColor = True
        '
        'txtNewPassWord2
        '
        Me.txtNewPassWord2.Location = New System.Drawing.Point(129, 125)
        Me.txtNewPassWord2.Name = "txtNewPassWord2"
        Me.txtNewPassWord2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNewPassWord2.Size = New System.Drawing.Size(139, 22)
        Me.txtNewPassWord2.TabIndex = 30
        '
        'txtNewPassWord1
        '
        Me.txtNewPassWord1.Location = New System.Drawing.Point(129, 80)
        Me.txtNewPassWord1.Name = "txtNewPassWord1"
        Me.txtNewPassWord1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNewPassWord1.Size = New System.Drawing.Size(139, 22)
        Me.txtNewPassWord1.TabIndex = 20
        '
        'txtOldPassWord
        '
        Me.txtOldPassWord.Location = New System.Drawing.Point(129, 37)
        Me.txtOldPassWord.Name = "txtOldPassWord"
        Me.txtOldPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtOldPassWord.Size = New System.Drawing.Size(139, 22)
        Me.txtOldPassWord.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "（確認再入力）"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 15)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "【新パスワード】"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "【新パスワード】"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "【現パスワード】"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 15)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "☆パスワード変更"
        '
        'lblBottomName
        '
        Me.lblBottomName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBottomName.AutoSize = True
        Me.lblBottomName.BackColor = System.Drawing.SystemColors.Control
        Me.lblBottomName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBottomName.Location = New System.Drawing.Point(25, 380)
        Me.lblBottomName.Name = "lblBottomName"
        Me.lblBottomName.Size = New System.Drawing.Size(110, 16)
        Me.lblBottomName.TabIndex = 25
        Me.lblBottomName.Text = "lblBottomName"
        Me.lblBottomName.Visible = False
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBottomCode.AutoSize = True
        Me.lblBottomCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBottomCode.Location = New System.Drawing.Point(4, 368)
        Me.lblBottomCode.Name = "lblBottomCode"
        Me.lblBottomCode.Size = New System.Drawing.Size(80, 12)
        Me.lblBottomCode.TabIndex = 24
        Me.lblBottomCode.Text = "lblBottomCode"
        Me.lblBottomCode.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClose.Location = New System.Drawing.Point(647, 363)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(77, 30)
        Me.btnClose.TabIndex = 50
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 405)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblBottomName)
        Me.Controls.Add(Me.lblBottomCode)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblLogin)
        Me.Name = "frmUser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCangePassWord As System.Windows.Forms.Button
    Friend WithEvents txtNewPassWord2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPassWord1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOldPassWord As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected Friend WithEvents lblBottomName As System.Windows.Forms.Label
    Protected Friend WithEvents lblBottomCode As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
