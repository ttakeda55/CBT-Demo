<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionMiddle
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
        Me.btnCheckAllOn = New System.Windows.Forms.Button()
        Me.btnCheckAllOff = New System.Windows.Forms.Button()
        Me.btnBackCourse = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvPracticeQuestionList = New System.Windows.Forms.DataGridView()
        Me.CHECK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAINCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCheckAllOn
        '
        Me.btnCheckAllOn.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOn.Location = New System.Drawing.Point(12, 613)
        Me.btnCheckAllOn.Name = "btnCheckAllOn"
        Me.btnCheckAllOn.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOn.TabIndex = 20
        Me.btnCheckAllOn.Text = "全チェック"
        Me.btnCheckAllOn.UseVisualStyleBackColor = True
        '
        'btnCheckAllOff
        '
        Me.btnCheckAllOff.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOff.Location = New System.Drawing.Point(128, 613)
        Me.btnCheckAllOff.Name = "btnCheckAllOff"
        Me.btnCheckAllOff.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOff.TabIndex = 30
        Me.btnCheckAllOff.Text = "全チェック解除"
        Me.btnCheckAllOff.UseVisualStyleBackColor = True
        '
        'btnBackCourse
        '
        Me.btnBackCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBackCourse.Location = New System.Drawing.Point(803, 662)
        Me.btnBackCourse.Name = "btnBackCourse"
        Me.btnBackCourse.Size = New System.Drawing.Size(210, 30)
        Me.btnBackCourse.TabIndex = 40
        Me.btnBackCourse.Text = "演習問題群登録メニューへ戻る"
        Me.btnBackCourse.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(544, 12)
        Me.lblTree.TabIndex = 194
        Me.lblTree.Text = "システム管理者メインメニュー ＞ コース登録/確認 ＞ 演習問題群登録メニュー ＞ 演習問題群登録／中問一覧"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(70, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(249, 19)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "演習問題群登録／中問一覧"
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
        Me.dgvPracticeQuestionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHECK, Me.QUESTIONCODE, Me.THEME, Me.THEME1, Me.THEME2, Me.THEME3, Me.THEME4, Me.MAINCODE})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPracticeQuestionList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPracticeQuestionList.EnableHeadersVisualStyles = False
        Me.dgvPracticeQuestionList.Location = New System.Drawing.Point(12, 162)
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
        Me.dgvPracticeQuestionList.Size = New System.Drawing.Size(994, 392)
        Me.dgvPracticeQuestionList.TabIndex = 10
        '
        'CHECK
        '
        Me.CHECK.DataPropertyName = "CHECK"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CHECK.DefaultCellStyle = DataGridViewCellStyle2
        Me.CHECK.FalseValue = "0"
        Me.CHECK.HeaderText = ""
        Me.CHECK.Name = "CHECK"
        Me.CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHECK.TrueValue = "1"
        Me.CHECK.Width = 30
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        Me.QUESTIONCODE.HeaderText = "中問コード"
        Me.QUESTIONCODE.Name = "QUESTIONCODE"
        Me.QUESTIONCODE.ReadOnly = True
        Me.QUESTIONCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONCODE.Width = 110
        '
        'THEME
        '
        Me.THEME.DataPropertyName = "THEME"
        Me.THEME.HeaderText = "中問テーマ"
        Me.THEME.Name = "THEME"
        Me.THEME.ReadOnly = True
        Me.THEME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME.Width = 190
        '
        'THEME1
        '
        Me.THEME1.DataPropertyName = "THEME1"
        Me.THEME1.HeaderText = "１"
        Me.THEME1.Name = "THEME1"
        Me.THEME1.ReadOnly = True
        Me.THEME1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME1.Width = 160
        '
        'THEME2
        '
        Me.THEME2.DataPropertyName = "THEME2"
        Me.THEME2.HeaderText = "２"
        Me.THEME2.Name = "THEME2"
        Me.THEME2.ReadOnly = True
        Me.THEME2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME2.Width = 160
        '
        'THEME3
        '
        Me.THEME3.DataPropertyName = "THEME3"
        Me.THEME3.HeaderText = "３"
        Me.THEME3.Name = "THEME3"
        Me.THEME3.ReadOnly = True
        Me.THEME3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME3.Width = 160
        '
        'THEME4
        '
        Me.THEME4.DataPropertyName = "THEME4"
        Me.THEME4.HeaderText = "４"
        Me.THEME4.Name = "THEME4"
        Me.THEME4.ReadOnly = True
        Me.THEME4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME4.Width = 160
        '
        'MAINCODE
        '
        Me.MAINCODE.DataPropertyName = "MAINCODE"
        Me.MAINCODE.HeaderText = "MAINCODE"
        Me.MAINCODE.Name = "MAINCODE"
        Me.MAINCODE.ReadOnly = True
        Me.MAINCODE.Visible = False
        '
        'LabelLine
        '
        Me.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelLine.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelLine.Location = New System.Drawing.Point(345, 180)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(636, 1)
        Me.LabelLine.TabIndex = 200
        Me.LabelLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(346, 166)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(530, 15)
        Me.Label17.TabIndex = 199
        Me.Label17.Text = "問別テーマ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCollectionMiddle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.LabelLine)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnCheckAllOn)
        Me.Controls.Add(Me.btnCheckAllOff)
        Me.Controls.Add(Me.btnBackCourse)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvPracticeQuestionList)
        Me.Name = "frmCollectionMiddle"
        Me.Text = "演習問題群登録／中問一覧"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.dgvPracticeQuestionList, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.btnBackCourse, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOff, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOn, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.LabelLine, 0)
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCheckAllOn As System.Windows.Forms.Button
    Friend WithEvents btnCheckAllOff As System.Windows.Forms.Button
    Friend WithEvents btnBackCourse As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvPracticeQuestionList As System.Windows.Forms.DataGridView
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CHECK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAINCODE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
