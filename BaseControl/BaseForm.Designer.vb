<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseForm
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
        Me.lblTitle01 = New System.Windows.Forms.Label()
        Me.lblBackColor = New System.Windows.Forms.Label()
        Me.lblLine02 = New System.Windows.Forms.Label()
        Me.lblLine01 = New System.Windows.Forms.Label()
        Me.lblLine03 = New System.Windows.Forms.Label()
        Me.lblBottomCode = New System.Windows.Forms.Label()
        Me.lblBottomName = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.picTitle = New System.Windows.Forms.PictureBox()
        Me.lblProcessMessage = New System.Windows.Forms.Label()
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle01
        '
        Me.lblTitle01.AutoSize = True
        Me.lblTitle01.BackColor = System.Drawing.Color.Aqua
        Me.lblTitle01.Font = New System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle01.Location = New System.Drawing.Point(14, 17)
        Me.lblTitle01.Name = "lblTitle01"
        Me.lblTitle01.Size = New System.Drawing.Size(369, 27)
        Me.lblTitle01.TabIndex = 0
        Me.lblTitle01.Text = "ＣＢＴコンピューター試験体験版"
        '
        'lblBackColor
        '
        Me.lblBackColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBackColor.BackColor = System.Drawing.Color.Aqua
        Me.lblBackColor.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBackColor.Location = New System.Drawing.Point(0, 0)
        Me.lblBackColor.Name = "lblBackColor"
        Me.lblBackColor.Size = New System.Drawing.Size(1020, 60)
        Me.lblBackColor.TabIndex = 3
        Me.lblBackColor.Text = "　"
        '
        'lblLine02
        '
        Me.lblLine02.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblLine02.Location = New System.Drawing.Point(5, 52)
        Me.lblLine02.Name = "lblLine02"
        Me.lblLine02.Size = New System.Drawing.Size(395, 4)
        Me.lblLine02.TabIndex = 8
        Me.lblLine02.Text = "　"
        '
        'lblLine01
        '
        Me.lblLine01.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblLine01.Location = New System.Drawing.Point(5, 6)
        Me.lblLine01.Name = "lblLine01"
        Me.lblLine01.Size = New System.Drawing.Size(4, 43)
        Me.lblLine01.TabIndex = 9
        Me.lblLine01.Text = "　"
        '
        'lblLine03
        '
        Me.lblLine03.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLine03.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblLine03.Location = New System.Drawing.Point(0, 653)
        Me.lblLine03.Name = "lblLine03"
        Me.lblLine03.Size = New System.Drawing.Size(1022, 4)
        Me.lblLine03.TabIndex = 10
        Me.lblLine03.Text = "　"
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBottomCode.AutoSize = True
        Me.lblBottomCode.BackColor = System.Drawing.Color.White
        Me.lblBottomCode.Location = New System.Drawing.Point(3, 660)
        Me.lblBottomCode.Name = "lblBottomCode"
        Me.lblBottomCode.Size = New System.Drawing.Size(80, 12)
        Me.lblBottomCode.TabIndex = 11
        Me.lblBottomCode.Text = "lblBottomCode"
        Me.lblBottomCode.Visible = False
        '
        'lblBottomName
        '
        Me.lblBottomName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBottomName.AutoSize = True
        Me.lblBottomName.BackColor = System.Drawing.Color.White
        Me.lblBottomName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBottomName.Location = New System.Drawing.Point(24, 672)
        Me.lblBottomName.Name = "lblBottomName"
        Me.lblBottomName.Size = New System.Drawing.Size(110, 16)
        Me.lblBottomName.TabIndex = 12
        Me.lblBottomName.Text = "lblBottomName"
        Me.lblBottomName.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(-2, 657)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1022, 39)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "　"
        '
        'picTitle
        '
        Me.picTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picTitle.BackColor = System.Drawing.Color.LightCyan
        Me.picTitle.Image = Global.CST.CBT.eIPSTA.BaseControl.My.Resources.Resources.cst_logo_aqua
        Me.picTitle.Location = New System.Drawing.Point(806, 6)
        Me.picTitle.Name = "picTitle"
        Me.picTitle.Size = New System.Drawing.Size(200, 49)
        Me.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTitle.TabIndex = 2
        Me.picTitle.TabStop = False
        '
        'lblProcessMessage
        '
        Me.lblProcessMessage.BackColor = System.Drawing.Color.White
        Me.lblProcessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcessMessage.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblProcessMessage.Location = New System.Drawing.Point(323, 264)
        Me.lblProcessMessage.Name = "lblProcessMessage"
        Me.lblProcessMessage.Size = New System.Drawing.Size(365, 110)
        Me.lblProcessMessage.TabIndex = 14
        Me.lblProcessMessage.Text = "処理中です。しばらくおまちください。"
        Me.lblProcessMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblProcessMessage.Visible = False
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblProcessMessage)
        Me.Controls.Add(Me.lblBottomName)
        Me.Controls.Add(Me.lblBottomCode)
        Me.Controls.Add(Me.lblLine03)
        Me.Controls.Add(Me.lblLine01)
        Me.Controls.Add(Me.lblLine02)
        Me.Controls.Add(Me.picTitle)
        Me.Controls.Add(Me.lblTitle01)
        Me.Controls.Add(Me.lblBackColor)
        Me.Controls.Add(Me.Label10)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "BaseForm"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picTitle As System.Windows.Forms.PictureBox
    Friend WithEvents lblBackColor As System.Windows.Forms.Label
    Friend WithEvents lblLine02 As System.Windows.Forms.Label
    Friend WithEvents lblLine01 As System.Windows.Forms.Label
    Friend WithEvents lblLine03 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Protected Friend WithEvents lblBottomCode As System.Windows.Forms.Label
    Protected Friend WithEvents lblBottomName As System.Windows.Forms.Label
    Friend WithEvents lblProcessMessage As System.Windows.Forms.Label
    Public WithEvents lblTitle01 As System.Windows.Forms.Label

End Class
