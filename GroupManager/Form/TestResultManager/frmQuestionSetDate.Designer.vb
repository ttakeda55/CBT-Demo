<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestionSetDate
    Inherits BaseControl.BaseMainForm

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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSetDate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpSecondTestEndDate = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpSecondTestStartDate = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.dtpFirstTestEndDate = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.dtpFirstTestStartDate = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.lblSystemEnableDate = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(821, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(191, 30)
        Me.btnBack.TabIndex = 2
        Me.btnBack.Text = "模擬テスト管理メニューへ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(216, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 15)
        Me.Label9.TabIndex = 213
        Me.Label9.Text = "システム利用可能期間"
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(361, 12)
        Me.lblTree.TabIndex = 212
        Me.lblTree.Text = "管理者メインメニュー ＞ 模擬テスト管理メニュー ＞ 模擬テスト実施日設定"
        Me.lblTree.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 19)
        Me.Label5.TabIndex = 211
        Me.Label5.Text = "模擬テスト実施日設定"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSetDate)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dtpSecondTestEndDate)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtpSecondTestStartDate)
        Me.Panel1.Controls.Add(Me.dtpFirstTestEndDate)
        Me.Panel1.Controls.Add(Me.dtpFirstTestStartDate)
        Me.Panel1.Location = New System.Drawing.Point(219, 193)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 128)
        Me.Panel1.TabIndex = 1
        '
        'btnSetDate
        '
        Me.btnSetDate.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSetDate.Location = New System.Drawing.Point(477, 89)
        Me.btnSetDate.Name = "btnSetDate"
        Me.btnSetDate.Size = New System.Drawing.Size(77, 30)
        Me.btnSetDate.TabIndex = 4
        Me.btnSetDate.Text = "設定"
        Me.btnSetDate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(300, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 219
        Me.Label6.Text = "～"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label12.Location = New System.Drawing.Point(300, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 15)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "～"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(49, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 218
        Me.Label8.Text = "再受験実施日"
        '
        'dtpSecondTestEndDate
        '
        Me.dtpSecondTestEndDate.IsNull = False
        Me.dtpSecondTestEndDate.Location = New System.Drawing.Point(328, 62)
        Me.dtpSecondTestEndDate.Name = "dtpSecondTestEndDate"
        Me.dtpSecondTestEndDate.Size = New System.Drawing.Size(143, 22)
        Me.dtpSecondTestEndDate.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label7.Location = New System.Drawing.Point(49, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "１回目実施日"
        '
        'dtpSecondTestStartDate
        '
        Me.dtpSecondTestStartDate.IsNull = False
        Me.dtpSecondTestStartDate.Location = New System.Drawing.Point(151, 62)
        Me.dtpSecondTestStartDate.Name = "dtpSecondTestStartDate"
        Me.dtpSecondTestStartDate.Size = New System.Drawing.Size(143, 22)
        Me.dtpSecondTestStartDate.TabIndex = 2
        '
        'dtpFirstTestEndDate
        '
        Me.dtpFirstTestEndDate.IsNull = False
        Me.dtpFirstTestEndDate.Location = New System.Drawing.Point(328, 20)
        Me.dtpFirstTestEndDate.Name = "dtpFirstTestEndDate"
        Me.dtpFirstTestEndDate.Size = New System.Drawing.Size(143, 22)
        Me.dtpFirstTestEndDate.TabIndex = 1
        '
        'dtpFirstTestStartDate
        '
        Me.dtpFirstTestStartDate.IsNull = False
        Me.dtpFirstTestStartDate.Location = New System.Drawing.Point(151, 20)
        Me.dtpFirstTestStartDate.Name = "dtpFirstTestStartDate"
        Me.dtpFirstTestStartDate.Size = New System.Drawing.Size(143, 22)
        Me.dtpFirstTestStartDate.TabIndex = 0
        '
        'lblSystemEnableDate
        '
        Me.lblSystemEnableDate.BackColor = System.Drawing.Color.White
        Me.lblSystemEnableDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSystemEnableDate.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSystemEnableDate.Location = New System.Drawing.Point(365, 153)
        Me.lblSystemEnableDate.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSystemEnableDate.Name = "lblSystemEnableDate"
        Me.lblSystemEnableDate.Size = New System.Drawing.Size(296, 26)
        Me.lblSystemEnableDate.TabIndex = 1
        Me.lblSystemEnableDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmQuestionSetDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblSystemEnableDate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmQuestionSetDate"
        Me.Text = "模擬テスト実施日設定"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblSystemEnableDate, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpSecondTestEndDate As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpSecondTestStartDate As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents dtpFirstTestEndDate As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents dtpFirstTestStartDate As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents btnSetDate As System.Windows.Forms.Button
    Friend WithEvents lblSystemEnableDate As System.Windows.Forms.Label
End Class
