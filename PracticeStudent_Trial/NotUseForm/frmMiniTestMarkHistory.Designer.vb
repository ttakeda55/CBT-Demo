<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiniTestMarkHistory
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
Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Me.lblTitle = New System.Windows.Forms.Label()
Me.Label6 = New System.Windows.Forms.Label()
Me.lblRight = New System.Windows.Forms.Label()
Me.Label8 = New System.Windows.Forms.Label()
Me.Label9 = New System.Windows.Forms.Label()
Me.lblTotal = New System.Windows.Forms.Label()
Me.lblPercentage = New System.Windows.Forms.Label()
Me.Label13 = New System.Windows.Forms.Label()
Me.Label14 = New System.Windows.Forms.Label()
Me.Label15 = New System.Windows.Forms.Label()
Me.Label16 = New System.Windows.Forms.Label()
Me.Label17 = New System.Windows.Forms.Label()
Me.btnBack = New System.Windows.Forms.Button()
Me.lblTestName = New System.Windows.Forms.Label()
Me.grdList = New System.Windows.Forms.DataGridView()
Me.colNo = New System.Windows.Forms.DataGridViewLinkColumn()
Me.colTheme = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
CType(Me.grdList, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'lblBottomCode
'
Me.lblBottomCode.Size = New System.Drawing.Size(9, 12)
Me.lblBottomCode.Text = " "
'
'lblBottomName
'
Me.lblBottomName.Size = New System.Drawing.Size(13, 16)
Me.lblBottomName.Text = " "
'
'lblTitle
'
Me.lblTitle.AutoSize = True
Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.lblTitle.Location = New System.Drawing.Point(22, 109)
Me.lblTitle.Name = "lblTitle"
Me.lblTitle.Size = New System.Drawing.Size(155, 19)
Me.lblTitle.TabIndex = 44
Me.lblTitle.Text = "小テスト採点結果"
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label6.Location = New System.Drawing.Point(48, 184)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(69, 19)
Me.Label6.TabIndex = 45
Me.Label6.Text = "正解数"
'
'lblRight
'
Me.lblRight.BackColor = System.Drawing.Color.White
Me.lblRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.lblRight.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.lblRight.Location = New System.Drawing.Point(129, 161)
Me.lblRight.Name = "lblRight"
Me.lblRight.Size = New System.Drawing.Size(120, 64)
Me.lblRight.TabIndex = 46
Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label8.Location = New System.Drawing.Point(259, 200)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(54, 19)
Me.Label8.TabIndex = 47
Me.Label8.Text = "問 / "
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label9.Location = New System.Drawing.Point(404, 200)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(29, 19)
Me.Label9.TabIndex = 48
Me.Label9.Text = "問"
'
'lblTotal
'
Me.lblTotal.BackColor = System.Drawing.Color.White
Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.lblTotal.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold)
Me.lblTotal.Location = New System.Drawing.Point(310, 194)
Me.lblTotal.Name = "lblTotal"
Me.lblTotal.Size = New System.Drawing.Size(78, 31)
Me.lblTotal.TabIndex = 49
Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'lblPercentage
'
Me.lblPercentage.BackColor = System.Drawing.Color.White
Me.lblPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.lblPercentage.Font = New System.Drawing.Font("MS UI Gothic", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.lblPercentage.Location = New System.Drawing.Point(597, 161)
Me.lblPercentage.Name = "lblPercentage"
Me.lblPercentage.Size = New System.Drawing.Size(130, 64)
Me.lblPercentage.TabIndex = 51
Me.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label13
'
Me.Label13.AutoSize = True
Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label13.Location = New System.Drawing.Point(515, 184)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(69, 19)
Me.Label13.TabIndex = 50
Me.Label13.Text = "正解率"
'
'Label14
'
Me.Label14.AutoSize = True
Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label14.Location = New System.Drawing.Point(745, 200)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(29, 19)
Me.Label14.TabIndex = 52
Me.Label14.Text = "％"
'
'Label15
'
Me.Label15.AutoSize = True
Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label15.Location = New System.Drawing.Point(23, 299)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(89, 19)
Me.Label15.TabIndex = 53
Me.Label15.Text = "問別正誤"
'
'Label16
'
Me.Label16.AutoSize = True
Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.Label16.Location = New System.Drawing.Point(125, 325)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(0, 19)
Me.Label16.TabIndex = 54
'
'Label17
'
Me.Label17.AutoSize = True
Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
Me.Label17.Location = New System.Drawing.Point(131, 344)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(242, 15)
Me.Label17.TabIndex = 55
Me.Label17.Text = "問番号を選択すると解説を表示します。"
'
'btnBack
'
Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.btnBack.BackColor = System.Drawing.SystemColors.Control
Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.btnBack.Location = New System.Drawing.Point(814, 662)
Me.btnBack.Name = "btnBack"
Me.btnBack.Size = New System.Drawing.Size(187, 30)
Me.btnBack.TabIndex = 2
Me.btnBack.UseVisualStyleBackColor = True
'
'lblTestName
'
Me.lblTestName.AutoSize = True
Me.lblTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
Me.lblTestName.Location = New System.Drawing.Point(183, 113)
Me.lblTestName.Name = "lblTestName"
Me.lblTestName.Size = New System.Drawing.Size(12, 15)
Me.lblTestName.TabIndex = 68
Me.lblTestName.Text = " "
'
'grdList
'
Me.grdList.AllowUserToAddRows = False
Me.grdList.AllowUserToDeleteRows = False
Me.grdList.AllowUserToResizeColumns = False
Me.grdList.AllowUserToResizeRows = False
DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grdList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
Me.grdList.ColumnHeadersHeight = 28
Me.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
Me.grdList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNo, Me.colTheme, Me.colRight, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
Me.grdList.EnableHeadersVisualStyles = False
Me.grdList.Location = New System.Drawing.Point(134, 362)
Me.grdList.MultiSelect = False
Me.grdList.Name = "grdList"
Me.grdList.ReadOnly = True
Me.grdList.RowHeadersVisible = False
Me.grdList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
Me.grdList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
Me.grdList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
Me.grdList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
Me.grdList.RowTemplate.Height = 21
Me.grdList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.grdList.Size = New System.Drawing.Size(450, 240)
Me.grdList.TabIndex = 1
Me.grdList.TabStop = False
'
'colNo
'
DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
Me.colNo.DefaultCellStyle = DataGridViewCellStyle12
Me.colNo.HeaderText = "問番号"
Me.colNo.Name = "colNo"
Me.colNo.ReadOnly = True
Me.colNo.Width = 80
'
'colTheme
'
Me.colTheme.HeaderText = "問題テーマ"
Me.colTheme.Name = "colTheme"
Me.colTheme.ReadOnly = True
Me.colTheme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
Me.colTheme.Width = 170
'
'colRight
'
DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
Me.colRight.DefaultCellStyle = DataGridViewCellStyle13
Me.colRight.HeaderText = "正解"
Me.colRight.Name = "colRight"
Me.colRight.ReadOnly = True
Me.colRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
Me.colRight.Width = 60
'
'DataGridViewTextBoxColumn1
'
DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle14
Me.DataGridViewTextBoxColumn1.HeaderText = "解答"
Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
Me.DataGridViewTextBoxColumn1.ReadOnly = True
Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
Me.DataGridViewTextBoxColumn1.Width = 60
'
'DataGridViewTextBoxColumn2
'
DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle15
Me.DataGridViewTextBoxColumn2.HeaderText = "正誤"
Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
Me.DataGridViewTextBoxColumn2.ReadOnly = True
Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
Me.DataGridViewTextBoxColumn2.Width = 60
'
'frmMiniTestMarkHistory
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1018, 697)
Me.Controls.Add(Me.lblTestName)
Me.Controls.Add(Me.btnBack)
Me.Controls.Add(Me.Label17)
Me.Controls.Add(Me.Label16)
Me.Controls.Add(Me.Label15)
Me.Controls.Add(Me.Label14)
Me.Controls.Add(Me.lblPercentage)
Me.Controls.Add(Me.lblTotal)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.lblRight)
Me.Controls.Add(Me.Label13)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.lblTitle)
Me.Controls.Add(Me.grdList)
Me.Name = "frmMiniTestMarkHistory"
Me.Text = "採点結果"
Me.Controls.SetChildIndex(Me.grdList, 0)
Me.Controls.SetChildIndex(Me.lblTitle, 0)
Me.Controls.SetChildIndex(Me.Label6, 0)
Me.Controls.SetChildIndex(Me.Label13, 0)
Me.Controls.SetChildIndex(Me.lblRight, 0)
Me.Controls.SetChildIndex(Me.Label8, 0)
Me.Controls.SetChildIndex(Me.Label9, 0)
Me.Controls.SetChildIndex(Me.lblTotal, 0)
Me.Controls.SetChildIndex(Me.lblPercentage, 0)
Me.Controls.SetChildIndex(Me.Label14, 0)
Me.Controls.SetChildIndex(Me.Label15, 0)
Me.Controls.SetChildIndex(Me.Label16, 0)
Me.Controls.SetChildIndex(Me.Label17, 0)
Me.Controls.SetChildIndex(Me.btnBack, 0)
Me.Controls.SetChildIndex(Me.lblTestName, 0)
Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
Me.Controls.SetChildIndex(Me.lblBottomName, 0)
CType(Me.grdList, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents grdList As System.Windows.Forms.DataGridView
    Friend WithEvents colNo As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colTheme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
