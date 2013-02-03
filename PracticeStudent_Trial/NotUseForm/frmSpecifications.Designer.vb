<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecifications
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
Me.lblBottomName = New System.Windows.Forms.Label()
Me.lblBottomCode = New System.Windows.Forms.Label()
Me.btnBack = New System.Windows.Forms.Button()
Me.webQuestionTop = New CST.CBT.eIPSTA.BaseControl.UserWebBrowser()
Me.Label5 = New System.Windows.Forms.Label()
Me.cboDisplayMagnification = New System.Windows.Forms.ComboBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.SuspendLayout()
'
'lblBottomName
'
Me.lblBottomName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.lblBottomName.AutoSize = True
Me.lblBottomName.BackColor = System.Drawing.SystemColors.Control
Me.lblBottomName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.lblBottomName.Location = New System.Drawing.Point(33, 544)
Me.lblBottomName.Name = "lblBottomName"
Me.lblBottomName.Size = New System.Drawing.Size(13, 16)
Me.lblBottomName.TabIndex = 14
Me.lblBottomName.Text = " "
Me.lblBottomName.Visible = False
'
'lblBottomCode
'
Me.lblBottomCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.lblBottomCode.AutoSize = True
Me.lblBottomCode.BackColor = System.Drawing.SystemColors.Control
Me.lblBottomCode.Location = New System.Drawing.Point(12, 532)
Me.lblBottomCode.Name = "lblBottomCode"
Me.lblBottomCode.Size = New System.Drawing.Size(9, 12)
Me.lblBottomCode.TabIndex = 13
Me.lblBottomCode.Text = " "
Me.lblBottomCode.Visible = False
'
'btnBack
'
Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.btnBack.Location = New System.Drawing.Point(780, 530)
Me.btnBack.Name = "btnBack"
Me.btnBack.Size = New System.Drawing.Size(100, 30)
Me.btnBack.TabIndex = 2
Me.btnBack.Text = "閉じる"
Me.btnBack.UseVisualStyleBackColor = True
'
'webQuestionTop
'
Me.webQuestionTop.AllowNavigation = False
Me.webQuestionTop.DocumentText = ""
Me.webQuestionTop.Location = New System.Drawing.Point(3, 32)
Me.webQuestionTop.Mode = CST.CBT.eIPSTA.BaseControl.UserWebBrowser.ZoomMode.[Auto]
Me.webQuestionTop.Name = "webQuestionTop"
Me.webQuestionTop.Size = New System.Drawing.Size(886, 494)
Me.webQuestionTop.TabIndex = 63
Me.webQuestionTop.TabStop = False
Me.webQuestionTop.url = New System.Uri("about:blank", System.UriKind.Absolute)
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label5.Location = New System.Drawing.Point(12, 5)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(109, 19)
Me.Label5.TabIndex = 64
Me.Label5.Text = "表計算仕様"
'
'cboDisplayMagnification
'
Me.cboDisplayMagnification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cboDisplayMagnification.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.cboDisplayMagnification.FormattingEnabled = True
Me.cboDisplayMagnification.Items.AddRange(New Object() {"100%", "110%", "120%", "130%", "140%", "150%", "160%", "170%", "180%", "190%", "200%"})
Me.cboDisplayMagnification.Location = New System.Drawing.Point(799, 4)
Me.cboDisplayMagnification.Name = "cboDisplayMagnification"
Me.cboDisplayMagnification.Size = New System.Drawing.Size(85, 23)
Me.cboDisplayMagnification.TabIndex = 1
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label1.Location = New System.Drawing.Point(726, 8)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(75, 15)
Me.Label1.TabIndex = 65
Me.Label1.Text = "表示倍率："
'
'frmSpecifications
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(892, 566)
Me.ControlBox = False
Me.Controls.Add(Me.cboDisplayMagnification)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.webQuestionTop)
Me.Controls.Add(Me.btnBack)
Me.Controls.Add(Me.lblBottomName)
Me.Controls.Add(Me.lblBottomCode)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "frmSpecifications"
Me.Text = "表計算仕様画面"
Me.TopMost = True
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Protected Friend WithEvents lblBottomName As System.Windows.Forms.Label
    Protected Friend WithEvents lblBottomCode As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents webQuestionTop As BaseControl.UserWebBrowser
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDisplayMagnification As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
