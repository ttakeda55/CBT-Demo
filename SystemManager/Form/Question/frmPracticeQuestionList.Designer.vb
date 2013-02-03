<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPracticeQuestionList
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.sfdExcel = New System.Windows.Forms.SaveFileDialog()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtQuestionCode = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbCategory1 = New System.Windows.Forms.ComboBox()
        Me.cmbCategory2 = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbCategory3 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtKeyWord = New System.Windows.Forms.TextBox()
        Me.rdbForwardMatch = New System.Windows.Forms.RadioButton()
        Me.rdbExactMatch = New System.Windows.Forms.RadioButton()
        Me.dgvPracticeQuestionList = New System.Windows.Forms.DataGridView()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.CATEGORYNAME1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LEVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UPDATE_DATE_DISPLAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONTYPE = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MOVIE_ADD = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.MOVIE_DEL = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Location = New System.Drawing.Point(3, 666)
        '
        'lblBottomName
        '
        Me.lblBottomName.Location = New System.Drawing.Point(24, 678)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 19)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "問題確認"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(30, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(128, 25)
        Me.Panel2.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "〔抽出条件指定〕"
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(821, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(191, 30)
        Me.btnBack.TabIndex = 100
        Me.btnBack.Text = "問題管理メニューへ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnUpdate.Location = New System.Drawing.Point(910, 612)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(93, 30)
        Me.btnUpdate.TabIndex = 90
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(438, 12)
        Me.lblTree.TabIndex = 182
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 問題管理メニュー ＞ 問題確認メニュー ＞ 演習問題一覧"
        Me.lblTree.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(10, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "【問題コード】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(27, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "【大分類】"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label12.Location = New System.Drawing.Point(320, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 15)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "【中分類】"
        '
        'txtQuestionCode
        '
        Me.txtQuestionCode.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtQuestionCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtQuestionCode.Location = New System.Drawing.Point(102, 23)
        Me.txtQuestionCode.MaxLength = 100
        Me.txtQuestionCode.Name = "txtQuestionCode"
        Me.txtQuestionCode.Size = New System.Drawing.Size(193, 22)
        Me.txtQuestionCode.TabIndex = 10
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(902, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 30)
        Me.btnSearch.TabIndex = 70
        Me.btnSearch.Text = "抽出"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbCategory1
        '
        Me.cmbCategory1.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory1.FormattingEnabled = True
        Me.cmbCategory1.Location = New System.Drawing.Point(99, 56)
        Me.cmbCategory1.Name = "cmbCategory1"
        Me.cmbCategory1.Size = New System.Drawing.Size(196, 23)
        Me.cmbCategory1.TabIndex = 40
        Me.cmbCategory1.ValueMember = "CATEGORYID"
        '
        'cmbCategory2
        '
        Me.cmbCategory2.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory2.FormattingEnabled = True
        Me.cmbCategory2.Location = New System.Drawing.Point(394, 56)
        Me.cmbCategory2.Name = "cmbCategory2"
        Me.cmbCategory2.Size = New System.Drawing.Size(196, 23)
        Me.cmbCategory2.TabIndex = 50
        Me.cmbCategory2.ValueMember = "CATEGORYID"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label35.Location = New System.Drawing.Point(618, 59)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 15)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "【キーワード】"
        '
        'cmbCategory3
        '
        Me.cmbCategory3.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory3.FormattingEnabled = True
        Me.cmbCategory3.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbCategory3.Location = New System.Drawing.Point(659, 18)
        Me.cmbCategory3.Name = "cmbCategory3"
        Me.cmbCategory3.Size = New System.Drawing.Size(196, 23)
        Me.cmbCategory3.TabIndex = 60
        Me.cmbCategory3.ValueMember = "CATEGORYID"
        Me.cmbCategory3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtKeyWord)
        Me.Panel1.Controls.Add(Me.rdbForwardMatch)
        Me.Panel1.Controls.Add(Me.rdbExactMatch)
        Me.Panel1.Controls.Add(Me.cmbCategory3)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.cmbCategory2)
        Me.Panel1.Controls.Add(Me.cmbCategory1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtQuestionCode)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(12, 166)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 95)
        Me.Panel1.TabIndex = 39
        '
        'txtKeyWord
        '
        Me.txtKeyWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKeyWord.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKeyWord.Location = New System.Drawing.Point(705, 54)
        Me.txtKeyWord.MaxLength = 100
        Me.txtKeyWord.Name = "txtKeyWord"
        Me.txtKeyWord.Size = New System.Drawing.Size(274, 22)
        Me.txtKeyWord.TabIndex = 88
        '
        'rdbForwardMatch
        '
        Me.rdbForwardMatch.AutoSize = True
        Me.rdbForwardMatch.Location = New System.Drawing.Point(418, 23)
        Me.rdbForwardMatch.Name = "rdbForwardMatch"
        Me.rdbForwardMatch.Size = New System.Drawing.Size(71, 16)
        Me.rdbForwardMatch.TabIndex = 30
        Me.rdbForwardMatch.TabStop = True
        Me.rdbForwardMatch.Text = "前方一致"
        Me.rdbForwardMatch.UseVisualStyleBackColor = True
        '
        'rdbExactMatch
        '
        Me.rdbExactMatch.AutoSize = True
        Me.rdbExactMatch.Location = New System.Drawing.Point(323, 23)
        Me.rdbExactMatch.Name = "rdbExactMatch"
        Me.rdbExactMatch.Size = New System.Drawing.Size(71, 16)
        Me.rdbExactMatch.TabIndex = 20
        Me.rdbExactMatch.TabStop = True
        Me.rdbExactMatch.Text = "完全一致"
        Me.rdbExactMatch.UseVisualStyleBackColor = True
        '
        'dgvPracticeQuestionList
        '
        Me.dgvPracticeQuestionList.AllowUserToAddRows = False
        Me.dgvPracticeQuestionList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvPracticeQuestionList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPracticeQuestionList.ColumnHeadersHeight = 34
        Me.dgvPracticeQuestionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONCODE, Me.CATEGORYNAME1, Me.CATEGORYNAME2, Me.CATEGORYNAME3, Me.THEME, Me.LEVEL, Me.UPDATE_DATE_DISPLAY, Me.QUESTIONTYPE, Me.MOVIE_ADD, Me.MOVIE_DEL})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPracticeQuestionList.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPracticeQuestionList.EnableHeadersVisualStyles = False
        Me.dgvPracticeQuestionList.Location = New System.Drawing.Point(12, 267)
        Me.dgvPracticeQuestionList.Name = "dgvPracticeQuestionList"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeQuestionList.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPracticeQuestionList.RowHeadersVisible = False
        Me.dgvPracticeQuestionList.RowTemplate.Height = 21
        Me.dgvPracticeQuestionList.Size = New System.Drawing.Size(991, 330)
        Me.dgvPracticeQuestionList.TabIndex = 80
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QUESTIONCODE.DefaultCellStyle = DataGridViewCellStyle2
        Me.QUESTIONCODE.Frozen = True
        Me.QUESTIONCODE.HeaderText = "問題コード"
        Me.QUESTIONCODE.Name = "QUESTIONCODE"
        Me.QUESTIONCODE.ReadOnly = True
        Me.QUESTIONCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONCODE.Width = 90
        '
        'CATEGORYNAME1
        '
        Me.CATEGORYNAME1.DataPropertyName = "CATEGORYNAME1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CATEGORYNAME1.DefaultCellStyle = DataGridViewCellStyle3
        Me.CATEGORYNAME1.Frozen = True
        Me.CATEGORYNAME1.HeaderText = "大項目"
        Me.CATEGORYNAME1.Name = "CATEGORYNAME1"
        Me.CATEGORYNAME1.ReadOnly = True
        Me.CATEGORYNAME1.Width = 120
        '
        'CATEGORYNAME2
        '
        Me.CATEGORYNAME2.DataPropertyName = "CATEGORYNAME2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CATEGORYNAME2.DefaultCellStyle = DataGridViewCellStyle4
        Me.CATEGORYNAME2.Frozen = True
        Me.CATEGORYNAME2.HeaderText = "中項目"
        Me.CATEGORYNAME2.Name = "CATEGORYNAME2"
        Me.CATEGORYNAME2.ReadOnly = True
        Me.CATEGORYNAME2.Width = 150
        '
        'CATEGORYNAME3
        '
        Me.CATEGORYNAME3.DataPropertyName = "CATEGORYNAME3"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CATEGORYNAME3.DefaultCellStyle = DataGridViewCellStyle5
        Me.CATEGORYNAME3.Frozen = True
        Me.CATEGORYNAME3.HeaderText = "小分類"
        Me.CATEGORYNAME3.Name = "CATEGORYNAME3"
        Me.CATEGORYNAME3.ReadOnly = True
        Me.CATEGORYNAME3.Visible = False
        Me.CATEGORYNAME3.Width = 150
        '
        'THEME
        '
        Me.THEME.DataPropertyName = "THEME"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.NullValue = "ブレーンストーミングのルール"
        Me.THEME.DefaultCellStyle = DataGridViewCellStyle6
        Me.THEME.Frozen = True
        Me.THEME.HeaderText = "キーワード"
        Me.THEME.Name = "THEME"
        Me.THEME.ReadOnly = True
        '
        'LEVEL
        '
        Me.LEVEL.DataPropertyName = "LEVEL_STR"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LEVEL.DefaultCellStyle = DataGridViewCellStyle7
        Me.LEVEL.Frozen = True
        Me.LEVEL.HeaderText = "難易度"
        Me.LEVEL.Name = "LEVEL"
        Me.LEVEL.ReadOnly = True
        Me.LEVEL.Visible = False
        Me.LEVEL.Width = 55
        '
        'UPDATE_DATE_DISPLAY
        '
        Me.UPDATE_DATE_DISPLAY.DataPropertyName = "UPDATE_DATE_DISPLAY"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.Format = "d"
        Me.UPDATE_DATE_DISPLAY.DefaultCellStyle = DataGridViewCellStyle8
        Me.UPDATE_DATE_DISPLAY.Frozen = True
        Me.UPDATE_DATE_DISPLAY.HeaderText = "更新日"
        Me.UPDATE_DATE_DISPLAY.Name = "UPDATE_DATE_DISPLAY"
        Me.UPDATE_DATE_DISPLAY.ReadOnly = True
        '
        'QUESTIONTYPE
        '
        Me.QUESTIONTYPE.DataPropertyName = "QUESTIONTYPE"
        Me.QUESTIONTYPE.Frozen = True
        Me.QUESTIONTYPE.HeaderText = "問題タイプ"
        Me.QUESTIONTYPE.Name = "QUESTIONTYPE"
        Me.QUESTIONTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QUESTIONTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONTYPE.Width = 70
        '
        'MOVIE_ADD
        '
        Me.MOVIE_ADD.Frozen = True
        Me.MOVIE_ADD.HeaderText = "動画登録変更"
        Me.MOVIE_ADD.Name = "MOVIE_ADD"
        Me.MOVIE_ADD.Width = 90
        '
        'MOVIE_DEL
        '
        Me.MOVIE_DEL.HeaderText = "動画削除"
        Me.MOVIE_DEL.Name = "MOVIE_DEL"
        Me.MOVIE_DEL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MOVIE_DEL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MOVIE_DEL.Width = 70
        '
        'frmPracticeQuestionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvPracticeQuestionList)
        Me.Name = "frmPracticeQuestionList"
        Me.Text = "問題確認"
        Me.Controls.SetChildIndex(Me.dgvPracticeQuestionList, 0)
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.btnUpdate, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents sfdExcel As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtQuestionCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbCategory1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory3 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbForwardMatch As System.Windows.Forms.RadioButton
    Friend WithEvents rdbExactMatch As System.Windows.Forms.RadioButton
    Friend WithEvents dgvPracticeQuestionList As System.Windows.Forms.DataGridView
    Friend WithEvents txtKeyWord As System.Windows.Forms.TextBox
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CATEGORYNAME1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LEVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UPDATE_DATE_DISPLAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONTYPE As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MOVIE_ADD As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents MOVIE_DEL As System.Windows.Forms.DataGridViewButtonColumn
End Class
