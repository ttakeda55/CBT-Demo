<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisList
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvSynthesisList = New System.Windows.Forms.DataGridView()
        Me.TESTNAME = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.VISIBLE = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TESTSTART_DATETIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TESTEND_DATETIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATE_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnStatusChange = New System.Windows.Forms.Button()
        CType(Me.dgvSynthesisList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(919, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(93, 30)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = "戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(417, 12)
        Me.lblTree.TabIndex = 204
        Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 総合テスト管理 ＞ 総合テスト確認"
        Me.lblTree.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "テスト問題一覧"
        '
        'dgvSynthesisList
        '
        Me.dgvSynthesisList.AllowUserToAddRows = False
        Me.dgvSynthesisList.AllowUserToDeleteRows = False
        Me.dgvSynthesisList.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSynthesisList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSynthesisList.ColumnHeadersHeight = 34
        Me.dgvSynthesisList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TESTNAME, Me.VISIBLE, Me.TESTSTART_DATETIME, Me.TESTEND_DATETIME, Me.CREATE_DATE})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSynthesisList.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSynthesisList.EnableHeadersVisualStyles = False
        Me.dgvSynthesisList.Location = New System.Drawing.Point(52, 164)
        Me.dgvSynthesisList.Name = "dgvSynthesisList"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSynthesisList.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSynthesisList.RowHeadersVisible = False
        Me.dgvSynthesisList.RowTemplate.Height = 21
        Me.dgvSynthesisList.Size = New System.Drawing.Size(769, 450)
        Me.dgvSynthesisList.TabIndex = 1
        '
        'TESTNAME
        '
        Me.TESTNAME.DataPropertyName = "TESTNAME"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TESTNAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.TESTNAME.HeaderText = "テスト名"
        Me.TESTNAME.Name = "TESTNAME"
        Me.TESTNAME.ReadOnly = True
        Me.TESTNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TESTNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TESTNAME.Width = 389
        '
        'VISIBLE
        '
        Me.VISIBLE.DataPropertyName = "VISIBLE"
        Me.VISIBLE.FalseValue = "0"
        Me.VISIBLE.HeaderText = "有効"
        Me.VISIBLE.Name = "VISIBLE"
        Me.VISIBLE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VISIBLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.VISIBLE.TrueValue = "1"
        Me.VISIBLE.Visible = False
        Me.VISIBLE.Width = 50
        '
        'TESTSTART_DATETIME
        '
        Me.TESTSTART_DATETIME.DataPropertyName = "TESTSTART_DATETIME_CNV"
        DataGridViewCellStyle3.Format = "f"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TESTSTART_DATETIME.DefaultCellStyle = DataGridViewCellStyle3
        Me.TESTSTART_DATETIME.HeaderText = "試験開始日時"
        Me.TESTSTART_DATETIME.Name = "TESTSTART_DATETIME"
        Me.TESTSTART_DATETIME.ReadOnly = True
        Me.TESTSTART_DATETIME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TESTSTART_DATETIME.Visible = False
        Me.TESTSTART_DATETIME.Width = 120
        '
        'TESTEND_DATETIME
        '
        Me.TESTEND_DATETIME.DataPropertyName = "TESTEND_DATETIME_CNV"
        DataGridViewCellStyle4.Format = "f"
        Me.TESTEND_DATETIME.DefaultCellStyle = DataGridViewCellStyle4
        Me.TESTEND_DATETIME.HeaderText = "試験終了日時"
        Me.TESTEND_DATETIME.Name = "TESTEND_DATETIME"
        Me.TESTEND_DATETIME.ReadOnly = True
        Me.TESTEND_DATETIME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TESTEND_DATETIME.Visible = False
        Me.TESTEND_DATETIME.Width = 120
        '
        'CREATE_DATE
        '
        Me.CREATE_DATE.DataPropertyName = "CREATE_DATE"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CREATE_DATE.DefaultCellStyle = DataGridViewCellStyle5
        Me.CREATE_DATE.HeaderText = "作成日"
        Me.CREATE_DATE.Name = "CREATE_DATE"
        Me.CREATE_DATE.ReadOnly = True
        Me.CREATE_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CREATE_DATE.Width = 120
        '
        'btnStatusChange
        '
        Me.btnStatusChange.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnStatusChange.Location = New System.Drawing.Point(527, 620)
        Me.btnStatusChange.Name = "btnStatusChange"
        Me.btnStatusChange.Size = New System.Drawing.Size(104, 30)
        Me.btnStatusChange.TabIndex = 2
        Me.btnStatusChange.Text = "状態変更"
        Me.btnStatusChange.UseVisualStyleBackColor = True
        Me.btnStatusChange.Visible = False
        '
        'frmSynthesisList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnStatusChange)
        Me.Controls.Add(Me.dgvSynthesisList)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmSynthesisList"
        Me.Text = "テスト問題一覧"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.dgvSynthesisList, 0)
        Me.Controls.SetChildIndex(Me.btnStatusChange, 0)
        CType(Me.dgvSynthesisList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvSynthesisList As System.Windows.Forms.DataGridView
    Friend WithEvents btnStatusChange As System.Windows.Forms.Button
    Friend WithEvents TESTNAME As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents VISIBLE As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TESTSTART_DATETIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TESTEND_DATETIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATE_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
