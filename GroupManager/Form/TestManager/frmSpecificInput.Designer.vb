<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecificInput
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.dgvPracticeQuestionList = New System.Windows.Forms.DataGridView()
        Me.CHECK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.CATEGORYNAME1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CORRECTANSWERRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRACTICECOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LEVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBackSpecificTop = New System.Windows.Forms.Button()
        Me.btnCheckAllOn = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtKeyWord = New System.Windows.Forms.TextBox()
        Me.cmbCategory3 = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbCategory2 = New System.Windows.Forms.ComboBox()
        Me.cmbQuestionType = New System.Windows.Forms.ComboBox()
        Me.cmbCategory1 = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mskTestEnd_DateTime = New System.Windows.Forms.MaskedTextBox()
        Me.mskTestStart_DateTime = New System.Windows.Forms.MaskedTextBox()
        Me.txtTestName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnAllCheckCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(417, 12)
        Me.lblTree.TabIndex = 203
        Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 指定テスト管理 ＞ 指定テスト作成"
        Me.lblTree.Visible = False
        '
        'dgvPracticeQuestionList
        '
        Me.dgvPracticeQuestionList.AllowUserToAddRows = False
        Me.dgvPracticeQuestionList.AllowUserToOrderColumns = True
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
        Me.dgvPracticeQuestionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHECK, Me.QUESTIONCODE, Me.CATEGORYNAME1, Me.CATEGORYNAME2, Me.CATEGORYNAME3, Me.THEME, Me.CATEGORYNAME4, Me.FORMAT, Me.CORRECTANSWERRATE, Me.PRACTICECOUNT, Me.LEVEL, Me.QUESTIONTYPE})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPracticeQuestionList.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPracticeQuestionList.EnableHeadersVisualStyles = False
        Me.dgvPracticeQuestionList.Location = New System.Drawing.Point(7, 294)
        Me.dgvPracticeQuestionList.Name = "dgvPracticeQuestionList"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeQuestionList.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPracticeQuestionList.RowHeadersVisible = False
        Me.dgvPracticeQuestionList.RowTemplate.Height = 21
        Me.dgvPracticeQuestionList.Size = New System.Drawing.Size(996, 313)
        Me.dgvPracticeQuestionList.TabIndex = 80
        '
        'CHECK
        '
        Me.CHECK.DataPropertyName = "CHECK"
        Me.CHECK.FalseValue = "0"
        Me.CHECK.Frozen = True
        Me.CHECK.HeaderText = ""
        Me.CHECK.Name = "CHECK"
        Me.CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CHECK.TrueValue = "1"
        Me.CHECK.Width = 35
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "問#"
        DataGridViewCellStyle2.NullValue = Nothing
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
        Me.CATEGORYNAME1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME1.Width = 150
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
        Me.CATEGORYNAME2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
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
        Me.CATEGORYNAME3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
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
        Me.THEME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME.Width = 145
        '
        'CATEGORYNAME4
        '
        Me.CATEGORYNAME4.DataPropertyName = "CATEGORYNAME4"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Format = "d"
        Me.CATEGORYNAME4.DefaultCellStyle = DataGridViewCellStyle7
        Me.CATEGORYNAME4.Frozen = True
        Me.CATEGORYNAME4.HeaderText = "グループ"
        Me.CATEGORYNAME4.Name = "CATEGORYNAME4"
        Me.CATEGORYNAME4.ReadOnly = True
        Me.CATEGORYNAME4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME4.Visible = False
        Me.CATEGORYNAME4.Width = 145
        '
        'FORMAT
        '
        Me.FORMAT.DataPropertyName = "FORMAT"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FORMAT.DefaultCellStyle = DataGridViewCellStyle8
        Me.FORMAT.Frozen = True
        Me.FORMAT.HeaderText = "属性"
        Me.FORMAT.Name = "FORMAT"
        Me.FORMAT.ReadOnly = True
        Me.FORMAT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FORMAT.Visible = False
        Me.FORMAT.Width = 40
        '
        'CORRECTANSWERRATE
        '
        Me.CORRECTANSWERRATE.DataPropertyName = "CORRECTANSWERRATE"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        Me.CORRECTANSWERRATE.DefaultCellStyle = DataGridViewCellStyle9
        Me.CORRECTANSWERRATE.Frozen = True
        Me.CORRECTANSWERRATE.HeaderText = "正解率"
        Me.CORRECTANSWERRATE.Name = "CORRECTANSWERRATE"
        Me.CORRECTANSWERRATE.ReadOnly = True
        Me.CORRECTANSWERRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CORRECTANSWERRATE.Visible = False
        Me.CORRECTANSWERRATE.Width = 65
        '
        'PRACTICECOUNT
        '
        Me.PRACTICECOUNT.DataPropertyName = "PRACTICECOUNT"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        Me.PRACTICECOUNT.DefaultCellStyle = DataGridViewCellStyle10
        Me.PRACTICECOUNT.Frozen = True
        Me.PRACTICECOUNT.HeaderText = "演習回数"
        Me.PRACTICECOUNT.Name = "PRACTICECOUNT"
        Me.PRACTICECOUNT.ReadOnly = True
        Me.PRACTICECOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PRACTICECOUNT.Visible = False
        Me.PRACTICECOUNT.Width = 65
        '
        'LEVEL
        '
        Me.LEVEL.DataPropertyName = "LEVEL_STR"
        Me.LEVEL.HeaderText = "難易度"
        Me.LEVEL.Name = "LEVEL"
        Me.LEVEL.ReadOnly = True
        Me.LEVEL.Visible = False
        '
        'QUESTIONTYPE
        '
        Me.QUESTIONTYPE.DataPropertyName = "QUESTIONTYPE_STR"
        Me.QUESTIONTYPE.HeaderText = "問題タイプ"
        Me.QUESTIONTYPE.Name = "QUESTIONTYPE"
        Me.QUESTIONTYPE.ReadOnly = True
        Me.QUESTIONTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QUESTIONTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'btnBackSpecificTop
        '
        Me.btnBackSpecificTop.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackSpecificTop.Location = New System.Drawing.Point(803, 663)
        Me.btnBackSpecificTop.Name = "btnBackSpecificTop"
        Me.btnBackSpecificTop.Size = New System.Drawing.Size(210, 30)
        Me.btnBackSpecificTop.TabIndex = 200
        Me.btnBackSpecificTop.Text = "手動テスト管理へ戻る"
        Me.btnBackSpecificTop.UseVisualStyleBackColor = True
        '
        'btnCheckAllOn
        '
        Me.btnCheckAllOn.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOn.Location = New System.Drawing.Point(12, 613)
        Me.btnCheckAllOn.Name = "btnCheckAllOn"
        Me.btnCheckAllOn.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOn.TabIndex = 90
        Me.btnCheckAllOn.Text = "全チェック"
        Me.btnCheckAllOn.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnAdd.Location = New System.Drawing.Point(866, 613)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(140, 30)
        Me.btnAdd.TabIndex = 140
        Me.btnAdd.Text = "手動テスト登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(30, 189)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(134, 25)
        Me.Panel2.TabIndex = 211
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtKeyWord)
        Me.Panel1.Controls.Add(Me.cmbCategory3)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.cmbCategory2)
        Me.Panel1.Controls.Add(Me.cmbQuestionType)
        Me.Panel1.Controls.Add(Me.cmbCategory1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(8, 199)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 89)
        Me.Panel1.TabIndex = 30
        '
        'txtKeyWord
        '
        Me.txtKeyWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKeyWord.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtKeyWord.Location = New System.Drawing.Point(696, 55)
        Me.txtKeyWord.MaxLength = 100
        Me.txtKeyWord.Name = "txtKeyWord"
        Me.txtKeyWord.Size = New System.Drawing.Size(276, 22)
        Me.txtKeyWord.TabIndex = 88
        '
        'cmbCategory3
        '
        Me.cmbCategory3.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory3.FormattingEnabled = True
        Me.cmbCategory3.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbCategory3.Location = New System.Drawing.Point(682, 17)
        Me.cmbCategory3.Name = "cmbCategory3"
        Me.cmbCategory3.Size = New System.Drawing.Size(196, 23)
        Me.cmbCategory3.TabIndex = 60
        Me.cmbCategory3.ValueMember = "CATEGORYID"
        Me.cmbCategory3.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label35.Location = New System.Drawing.Point(611, 59)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 15)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "【キーワード】"
        '
        'cmbCategory2
        '
        Me.cmbCategory2.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory2.FormattingEnabled = True
        Me.cmbCategory2.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbCategory2.Location = New System.Drawing.Point(390, 55)
        Me.cmbCategory2.Name = "cmbCategory2"
        Me.cmbCategory2.Size = New System.Drawing.Size(196, 23)
        Me.cmbCategory2.TabIndex = 50
        Me.cmbCategory2.ValueMember = "CATEGORYID"
        '
        'cmbQuestionType
        '
        Me.cmbQuestionType.DisplayMember = "CATEGORYNAME"
        Me.cmbQuestionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuestionType.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbQuestionType.FormattingEnabled = True
        Me.cmbQuestionType.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbQuestionType.Location = New System.Drawing.Point(95, 20)
        Me.cmbQuestionType.Name = "cmbQuestionType"
        Me.cmbQuestionType.Size = New System.Drawing.Size(196, 23)
        Me.cmbQuestionType.TabIndex = 40
        Me.cmbQuestionType.ValueMember = "CATEGORYID"
        '
        'cmbCategory1
        '
        Me.cmbCategory1.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory1.FormattingEnabled = True
        Me.cmbCategory1.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbCategory1.Location = New System.Drawing.Point(95, 55)
        Me.cmbCategory1.Name = "cmbCategory1"
        Me.cmbCategory1.Size = New System.Drawing.Size(196, 23)
        Me.cmbCategory1.TabIndex = 40
        Me.cmbCategory1.ValueMember = "CATEGORYID"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(895, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 30)
        Me.btnSearch.TabIndex = 70
        Me.btnSearch.Text = "抽出"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label12.Location = New System.Drawing.Point(316, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 15)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "【中項目】"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label13.Location = New System.Drawing.Point(9, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 15)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "【問題タイプ】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(25, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "【大項目】"
        '
        'mskTestEnd_DateTime
        '
        Me.mskTestEnd_DateTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mskTestEnd_DateTime.Location = New System.Drawing.Point(718, 125)
        Me.mskTestEnd_DateTime.Mask = "0000年00月00日00時00分"
        Me.mskTestEnd_DateTime.Name = "mskTestEnd_DateTime"
        Me.mskTestEnd_DateTime.Size = New System.Drawing.Size(187, 23)
        Me.mskTestEnd_DateTime.TabIndex = 14
        Me.mskTestEnd_DateTime.Visible = False
        '
        'mskTestStart_DateTime
        '
        Me.mskTestStart_DateTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mskTestStart_DateTime.Location = New System.Drawing.Point(480, 126)
        Me.mskTestStart_DateTime.Mask = "0000年00月00日00時00分"
        Me.mskTestStart_DateTime.Name = "mskTestStart_DateTime"
        Me.mskTestStart_DateTime.Size = New System.Drawing.Size(187, 23)
        Me.mskTestStart_DateTime.TabIndex = 12
        Me.mskTestStart_DateTime.Visible = False
        '
        'txtTestName
        '
        Me.txtTestName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTestName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtTestName.Location = New System.Drawing.Point(108, 155)
        Me.txtTestName.MaxLength = 100
        Me.txtTestName.Multiline = True
        Me.txtTestName.Name = "txtTestName"
        Me.txtTestName.Size = New System.Drawing.Size(377, 29)
        Me.txtTestName.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(31, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 215
        Me.Label8.Text = "【テスト名】"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 216
        Me.Label5.Text = "手動テスト作成"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(669, 627)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 220
        Me.Label11.Text = "選択問題数"
        '
        'lblCount
        '
        Me.lblCount.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lblCount.Location = New System.Drawing.Point(757, 627)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(56, 15)
        Me.lblCount.TabIndex = 221
        Me.lblCount.Text = "999問"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAllCheckCancel
        '
        Me.btnAllCheckCancel.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAllCheckCancel.Location = New System.Drawing.Point(135, 613)
        Me.btnAllCheckCancel.Name = "btnAllCheckCancel"
        Me.btnAllCheckCancel.Size = New System.Drawing.Size(110, 30)
        Me.btnAllCheckCancel.TabIndex = 90
        Me.btnAllCheckCancel.Text = "全チェック解除"
        Me.btnAllCheckCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(681, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "～"
        Me.Label6.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label14.Location = New System.Drawing.Point(391, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 15)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "【試験期間】"
        Me.Label14.Visible = False
        '
        'frmSpecificInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.mskTestEnd_DateTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.mskTestStart_DateTime)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTestName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnAllCheckCancel)
        Me.Controls.Add(Me.btnCheckAllOn)
        Me.Controls.Add(Me.btnBackSpecificTop)
        Me.Controls.Add(Me.dgvPracticeQuestionList)
        Me.Controls.Add(Me.lblTree)
        Me.Name = "frmSpecificInput"
        Me.Text = "手動テスト作成"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.dgvPracticeQuestionList, 0)
        Me.Controls.SetChildIndex(Me.btnBackSpecificTop, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOn, 0)
        Me.Controls.SetChildIndex(Me.btnAllCheckCancel, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtTestName, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.mskTestStart_DateTime, 0)
        Me.Controls.SetChildIndex(Me.lblCount, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.mskTestEnd_DateTime, 0)
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents dgvPracticeQuestionList As System.Windows.Forms.DataGridView
    Friend WithEvents btnBackSpecificTop As System.Windows.Forms.Button
    Friend WithEvents btnCheckAllOn As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbCategory3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTestName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents btnAllCheckCancel As System.Windows.Forms.Button
    Friend WithEvents cmbQuestionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mskTestEnd_DateTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskTestStart_DateTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtKeyWord As System.Windows.Forms.TextBox
    Friend WithEvents CHECK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CATEGORYNAME1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CORRECTANSWERRATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRACTICECOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LEVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
