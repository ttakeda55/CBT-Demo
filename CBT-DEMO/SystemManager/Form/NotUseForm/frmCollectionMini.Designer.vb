<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionMini
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvPracticeQuestionList = New System.Windows.Forms.DataGridView()
        Me.CHECK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GROUP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAINCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DISPLAYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.btnBackCourse = New System.Windows.Forms.Button()
        Me.btnCheckAllOn = New System.Windows.Forms.Button()
        Me.btnCheckAllOff = New System.Windows.Forms.Button()
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPracticeQuestionList
        '
        Me.dgvPracticeQuestionList.AllowUserToAddRows = False
        Me.dgvPracticeQuestionList.AllowUserToDeleteRows = False
        Me.dgvPracticeQuestionList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeQuestionList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPracticeQuestionList.ColumnHeadersHeight = 34
        Me.dgvPracticeQuestionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPracticeQuestionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHECK, Me.QUESTIONCODE, Me.THEME, Me.GROUP, Me.FORMAT, Me.MAINCODE, Me.DISPLAYID, Me.STATE})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPracticeQuestionList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPracticeQuestionList.EnableHeadersVisualStyles = False
        Me.dgvPracticeQuestionList.Location = New System.Drawing.Point(89, 201)
        Me.dgvPracticeQuestionList.Name = "dgvPracticeQuestionList"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeQuestionList.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPracticeQuestionList.RowHeadersVisible = False
        Me.dgvPracticeQuestionList.RowTemplate.Height = 21
        Me.dgvPracticeQuestionList.Size = New System.Drawing.Size(710, 392)
        Me.dgvPracticeQuestionList.TabIndex = 127
        '
        'CHECK
        '
        Me.CHECK.DataPropertyName = "CHECK"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CHECK.DefaultCellStyle = DataGridViewCellStyle2
        Me.CHECK.FalseValue = "0"
        Me.CHECK.Frozen = True
        Me.CHECK.HeaderText = ""
        Me.CHECK.Name = "CHECK"
        Me.CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHECK.TrueValue = "1"
        Me.CHECK.Width = 40
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        Me.QUESTIONCODE.HeaderText = "問題コード"
        Me.QUESTIONCODE.Name = "QUESTIONCODE"
        Me.QUESTIONCODE.ReadOnly = True
        Me.QUESTIONCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QUESTIONCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONCODE.Width = 140
        '
        'THEME
        '
        Me.THEME.DataPropertyName = "THEME"
        Me.THEME.HeaderText = "テーマ"
        Me.THEME.Name = "THEME"
        Me.THEME.ReadOnly = True
        Me.THEME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.THEME.Width = 200
        '
        'GROUP
        '
        Me.GROUP.DataPropertyName = "GROUP"
        Me.GROUP.HeaderText = "グループ"
        Me.GROUP.Name = "GROUP"
        Me.GROUP.ReadOnly = True
        Me.GROUP.Width = 200
        '
        'FORMAT
        '
        Me.FORMAT.DataPropertyName = "FORMAT"
        Me.FORMAT.HeaderText = "属性"
        Me.FORMAT.Name = "FORMAT"
        Me.FORMAT.ReadOnly = True
        '
        'MAINCODE
        '
        Me.MAINCODE.DataPropertyName = "MAINCODE"
        Me.MAINCODE.HeaderText = "MAINCODE"
        Me.MAINCODE.Name = "MAINCODE"
        Me.MAINCODE.Visible = False
        '
        'DISPLAYID
        '
        Me.DISPLAYID.DataPropertyName = "DISPLAYID"
        Me.DISPLAYID.HeaderText = "DISPLAYID"
        Me.DISPLAYID.Name = "DISPLAYID"
        Me.DISPLAYID.Visible = False
        '
        'STATE
        '
        Me.STATE.DataPropertyName = "STATE"
        Me.STATE.HeaderText = "STATE"
        Me.STATE.Name = "STATE"
        Me.STATE.Visible = False
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(592, 12)
        Me.lblTree.TabIndex = 187
        Me.lblTree.Text = "システム管理者メインメニュー ＞ コース登録/確認 ＞ 演習問題群登録メニュー ＞ 演習問題群登録／小問分野分類一覧"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(70, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(329, 19)
        Me.Label8.TabIndex = 186
        Me.Label8.Text = "演習問題群登録／小問分野分類一覧"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(85, 165)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(318, 16)
        Me.lblCategory.TabIndex = 188
        Me.lblCategory.Text = "ストラテジ系　－　企業と法務　－　企業活動"
        '
        'btnBackCourse
        '
        Me.btnBackCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBackCourse.Location = New System.Drawing.Point(803, 662)
        Me.btnBackCourse.Name = "btnBackCourse"
        Me.btnBackCourse.Size = New System.Drawing.Size(210, 30)
        Me.btnBackCourse.TabIndex = 189
        Me.btnBackCourse.Text = "演習問題群登録メニューへ戻る"
        Me.btnBackCourse.UseVisualStyleBackColor = True
        '
        'btnCheckAllOn
        '
        Me.btnCheckAllOn.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOn.Location = New System.Drawing.Point(12, 613)
        Me.btnCheckAllOn.Name = "btnCheckAllOn"
        Me.btnCheckAllOn.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOn.TabIndex = 190
        Me.btnCheckAllOn.Text = "全チェック"
        Me.btnCheckAllOn.UseVisualStyleBackColor = True
        '
        'btnCheckAllOff
        '
        Me.btnCheckAllOff.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOff.Location = New System.Drawing.Point(128, 613)
        Me.btnCheckAllOff.Name = "btnCheckAllOff"
        Me.btnCheckAllOff.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOff.TabIndex = 191
        Me.btnCheckAllOff.Text = "全チェック解除"
        Me.btnCheckAllOff.UseVisualStyleBackColor = True
        '
        'frmCollectionMini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnCheckAllOn)
        Me.Controls.Add(Me.btnCheckAllOff)
        Me.Controls.Add(Me.btnBackCourse)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvPracticeQuestionList)
        Me.Name = "frmCollectionMini"
        Me.Text = "演習問題群登録／小問分野分類一覧"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.dgvPracticeQuestionList, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.lblCategory, 0)
        Me.Controls.SetChildIndex(Me.btnBackCourse, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOff, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOn, 0)
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPracticeQuestionList As System.Windows.Forms.DataGridView
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents btnBackCourse As System.Windows.Forms.Button
    Friend WithEvents btnCheckAllOn As System.Windows.Forms.Button
    Friend WithEvents btnCheckAllOff As System.Windows.Forms.Button
    Friend WithEvents CHECK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GROUP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAINCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISPLAYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
