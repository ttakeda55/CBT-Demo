<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisTrueFalseList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.grdLeftList = New System.Windows.Forms.DataGridView()
        Me.colNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAnswer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTrueFalse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdRightList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.grdLeftList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRightList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Location = New System.Drawing.Point(3, 665)
        Me.lblBottomCode.Size = New System.Drawing.Size(9, 12)
        Me.lblBottomCode.Text = " "
        '
        'lblBottomName
        '
        Me.lblBottomName.Location = New System.Drawing.Point(24, 677)
        Me.lblBottomName.Size = New System.Drawing.Size(13, 16)
        Me.lblBottomName.Text = " "
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(0, 19)
        Me.lblTitle01.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTestName)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.grdLeftList)
        Me.Panel1.Controls.Add(Me.grdRightList)
        Me.Panel1.Location = New System.Drawing.Point(27, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 524)
        Me.Panel1.TabIndex = 90
        '
        'lblTestName
        '
        Me.lblTestName.AutoSize = True
        Me.lblTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestName.Location = New System.Drawing.Point(252, 12)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(12, 15)
        Me.lblTestName.TabIndex = 69
        Me.lblTestName.Text = " "
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(20, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(16, 19)
        Me.lblTitle.TabIndex = 58
        Me.lblTitle.Text = " "
        '
        'grdLeftList
        '
        Me.grdLeftList.AllowUserToAddRows = False
        Me.grdLeftList.AllowUserToDeleteRows = False
        Me.grdLeftList.AllowUserToResizeColumns = False
        Me.grdLeftList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdLeftList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdLeftList.ColumnHeadersHeight = 28
        Me.grdLeftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdLeftList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNo, Me.colTheme, Me.colRight, Me.colAnswer, Me.colTrueFalse})
        Me.grdLeftList.EnableHeadersVisualStyles = False
        Me.grdLeftList.Location = New System.Drawing.Point(33, 53)
        Me.grdLeftList.MultiSelect = False
        Me.grdLeftList.Name = "grdLeftList"
        Me.grdLeftList.ReadOnly = True
        Me.grdLeftList.RowHeadersVisible = False
        Me.grdLeftList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grdLeftList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLeftList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.grdLeftList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLeftList.RowTemplate.Height = 21
        Me.grdLeftList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdLeftList.Size = New System.Drawing.Size(449, 471)
        Me.grdLeftList.TabIndex = 1
        Me.grdLeftList.TabStop = False
        '
        'colNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colNo.HeaderText = "問番号"
        Me.colNo.Name = "colNo"
        Me.colNo.ReadOnly = True
        Me.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colNo.Width = 80
        '
        'colTheme
        '
        Me.colTheme.HeaderText = "問題テーマ"
        Me.colTheme.Name = "colTheme"
        Me.colTheme.ReadOnly = True
        Me.colTheme.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colTheme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTheme.Width = 170
        '
        'colRight
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRight.DefaultCellStyle = DataGridViewCellStyle3
        Me.colRight.HeaderText = "正解"
        Me.colRight.Name = "colRight"
        Me.colRight.ReadOnly = True
        Me.colRight.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colRight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colRight.Width = 60
        '
        'colAnswer
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colAnswer.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAnswer.HeaderText = "解答"
        Me.colAnswer.Name = "colAnswer"
        Me.colAnswer.ReadOnly = True
        Me.colAnswer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colAnswer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colAnswer.Width = 60
        '
        'colTrueFalse
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTrueFalse.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTrueFalse.HeaderText = "正誤"
        Me.colTrueFalse.Name = "colTrueFalse"
        Me.colTrueFalse.ReadOnly = True
        Me.colTrueFalse.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colTrueFalse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTrueFalse.Width = 60
        '
        'grdRightList
        '
        Me.grdRightList.AllowUserToAddRows = False
        Me.grdRightList.AllowUserToDeleteRows = False
        Me.grdRightList.AllowUserToResizeColumns = False
        Me.grdRightList.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdRightList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdRightList.ColumnHeadersHeight = 28
        Me.grdRightList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdRightList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLinkColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.grdRightList.EnableHeadersVisualStyles = False
        Me.grdRightList.Location = New System.Drawing.Point(488, 53)
        Me.grdRightList.MultiSelect = False
        Me.grdRightList.Name = "grdRightList"
        Me.grdRightList.ReadOnly = True
        Me.grdRightList.RowHeadersVisible = False
        Me.grdRightList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grdRightList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdRightList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.grdRightList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.grdRightList.RowTemplate.Height = 21
        Me.grdRightList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdRightList.Size = New System.Drawing.Size(449, 471)
        Me.grdRightList.TabIndex = 2
        Me.grdRightList.TabStop = False
        '
        'DataGridViewLinkColumn1
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewLinkColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewLinkColumn1.HeaderText = "問番号"
        Me.DataGridViewLinkColumn1.Name = "DataGridViewLinkColumn1"
        Me.DataGridViewLinkColumn1.ReadOnly = True
        Me.DataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewLinkColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewLinkColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "問題テーマ"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 170
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn2.HeaderText = "正解"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn3.HeaderText = "解答"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn4.HeaderText = "正誤"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(814, 662)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(187, 30)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = " "
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'frmSynthesisTrueFalseList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSynthesisTrueFalseList"
        Me.Text = "個人問題別正誤画面"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdLeftList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRightList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents grdLeftList As System.Windows.Forms.DataGridView
    Friend WithEvents grdRightList As System.Windows.Forms.DataGridView
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents colNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAnswer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTrueFalse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
