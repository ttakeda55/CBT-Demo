<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits BaseControl.BaseForm

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassWord = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Patren = New System.Windows.Forms.GroupBox()
        Me.C60 = New System.Windows.Forms.RadioButton()
        Me.C15 = New System.Windows.Forms.RadioButton()
        Me.C30 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Patren.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(0, 27)
        Me.lblTitle01.Text = ""
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(169, 148)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(70, 19)
        Me.lblLogin.TabIndex = 21
        Me.lblLogin.Text = "ログイン"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(286, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(467, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "問題を選択し、ユーザーＩＤ、パスワードを入力してログインボタンを押して下さい。"
        Me.Label1.Visible = False
        '
        'btnLogin
        '
        Me.btnLogin.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(524, 303)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(105, 28)
        Me.btnLogin.TabIndex = 29
        Me.btnLogin.Text = "ログイン"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(-58, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "パスワード"
        '
        'txtPassWord
        '
        Me.txtPassWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPassWord.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassWord.Location = New System.Drawing.Point(463, 260)
        Me.txtPassWord.Name = "txtPassWord"
        Me.txtPassWord.Size = New System.Drawing.Size(149, 22)
        Me.txtPassWord.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(392, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "ユーザーＩＤ"
        '
        'txtUserId
        '
        Me.txtUserId.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtUserId.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtUserId.Location = New System.Drawing.Point(463, 221)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(149, 22)
        Me.txtUserId.TabIndex = 27
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnClose.Location = New System.Drawing.Point(842, 663)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(164, 30)
        Me.btnClose.TabIndex = 43
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(339, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(310, 183)
        Me.Label4.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(336, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(352, 15)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "※体験版では、ユーザＩＤ、パスワードのチェックはありません。"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(390, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "パスワード"
        '
        'Patren
        '
        Me.Patren.Controls.Add(Me.Label3)
        Me.Patren.Location = New System.Drawing.Point(787, 103)
        Me.Patren.Name = "Patren"
        Me.Patren.Size = New System.Drawing.Size(147, 86)
        Me.Patren.TabIndex = 25
        Me.Patren.TabStop = False
        Me.Patren.Visible = False
        '
        'C60
        '
        Me.C60.Location = New System.Drawing.Point(808, 156)
        Me.C60.Name = "C60"
        Me.C60.Size = New System.Drawing.Size(118, 22)
        Me.C60.TabIndex = 0
        Me.C60.Text = "６０分用　（50問）"
        Me.C60.UseVisualStyleBackColor = True
        Me.C60.Visible = False
        '
        'C15
        '
        Me.C15.Checked = True
        Me.C15.Location = New System.Drawing.Point(808, 112)
        Me.C15.Name = "C15"
        Me.C15.Size = New System.Drawing.Size(118, 16)
        Me.C15.TabIndex = 0
        Me.C15.TabStop = True
        Me.C15.Text = "１５分用　（15問）"
        Me.C15.UseVisualStyleBackColor = True
        Me.C15.Visible = False
        '
        'C30
        '
        Me.C30.Location = New System.Drawing.Point(808, 134)
        Me.C30.Name = "C30"
        Me.C30.Size = New System.Drawing.Size(118, 16)
        Me.C30.TabIndex = 0
        Me.C30.Text = "３０分用　（25問）"
        Me.C30.UseVisualStyleBackColor = True
        Me.C30.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(714, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "問題選択"
        Me.Label7.Visible = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblLogin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C30)
        Me.Controls.Add(Me.C15)
        Me.Controls.Add(Me.C60)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Patren)
        Me.Controls.Add(Me.txtPassWord)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmLogin"
        Me.Text = "ログイン"
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtUserId, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnLogin, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtPassWord, 0)
        Me.Controls.SetChildIndex(Me.Patren, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.C60, 0)
        Me.Controls.SetChildIndex(Me.C15, 0)
        Me.Controls.SetChildIndex(Me.C30, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblLogin, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Patren.ResumeLayout(False)
        Me.Patren.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Patren As System.Windows.Forms.GroupBox
    Friend WithEvents C60 As System.Windows.Forms.RadioButton
    Friend WithEvents C15 As System.Windows.Forms.RadioButton
    Friend WithEvents C30 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
