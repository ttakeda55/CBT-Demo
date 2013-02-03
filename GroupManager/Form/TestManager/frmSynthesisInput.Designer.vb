<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisInput
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSynthesisName = New System.Windows.Forms.TextBox()
        Me.btnSynthesisInput = New System.Windows.Forms.Button()
        Me.btnChangeQuestion = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dgvPracticeList = New System.Windows.Forms.DataGridView()
        Me.CHECK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.INDEXNUMBER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.CATEGORYNAME1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANSWERS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONCOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COURSENO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATE_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UPDATE_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONCLASS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAINCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEMPSHOWNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONCODE_LINK = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.MIDDLEQUESTIONINDEX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHOWNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LEVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChkT = New System.Windows.Forms.CheckBox()
        Me.ChkQ = New System.Windows.Forms.CheckBox()
        Me.btnWord = New System.Windows.Forms.Button()
        Me.btnSrcQ = New System.Windows.Forms.Button()
        Me.BtnSrcS = New System.Windows.Forms.Button()
        Me.btnTransfer = New System.Windows.Forms.Button()
        CType(Me.dgvPracticeList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(369, 27)
        Me.lblTitle01.Text = "ＣＢＴコンピューター試験体験版"
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(417, 12)
        Me.lblTree.TabIndex = 191
        Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 総合テスト管理 ＞ 総合テスト作成"
        Me.lblTree.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 190
        Me.Label5.Text = "自動テスト作成"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(43, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 15)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "【テスト名】"
        '
        'txtSynthesisName
        '
        Me.txtSynthesisName.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSynthesisName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtSynthesisName.Location = New System.Drawing.Point(116, 147)
        Me.txtSynthesisName.Multiline = True
        Me.txtSynthesisName.Name = "txtSynthesisName"
        Me.txtSynthesisName.Size = New System.Drawing.Size(416, 26)
        Me.txtSynthesisName.TabIndex = 0
        '
        'btnSynthesisInput
        '
        Me.btnSynthesisInput.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSynthesisInput.Location = New System.Drawing.Point(538, 146)
        Me.btnSynthesisInput.Name = "btnSynthesisInput"
        Me.btnSynthesisInput.Size = New System.Drawing.Size(150, 30)
        Me.btnSynthesisInput.TabIndex = 1
        Me.btnSynthesisInput.Text = "自動テスト作成"
        Me.btnSynthesisInput.UseVisualStyleBackColor = True
        '
        'btnChangeQuestion
        '
        Me.btnChangeQuestion.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnChangeQuestion.Location = New System.Drawing.Point(16, 620)
        Me.btnChangeQuestion.Name = "btnChangeQuestion"
        Me.btnChangeQuestion.Size = New System.Drawing.Size(195, 30)
        Me.btnChangeQuestion.TabIndex = 3
        Me.btnChangeQuestion.Text = "チェックした問題を変更する"
        Me.btnChangeQuestion.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(919, 619)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRegistration
        '
        Me.btnRegistration.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRegistration.Location = New System.Drawing.Point(826, 619)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(87, 30)
        Me.btnRegistration.TabIndex = 4
        Me.btnRegistration.Text = "登録"
        Me.btnRegistration.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(919, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(87, 30)
        Me.btnBack.TabIndex = 6
        Me.btnBack.Text = "戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvPracticeList
        '
        Me.dgvPracticeList.AllowUserToAddRows = False
        Me.dgvPracticeList.AllowUserToDeleteRows = False
        Me.dgvPracticeList.AllowUserToOrderColumns = True
        Me.dgvPracticeList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPracticeList.ColumnHeadersHeight = 34
        Me.dgvPracticeList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHECK, Me.INDEXNUMBER, Me.QUESTIONCODE, Me.CATEGORYNAME1, Me.CATEGORYNAME2, Me.CATEGORYNAME3, Me.THEME, Me.CATEGORYNAME, Me.FORMAT, Me.ANSWERS, Me.QUESTIONCOUNT, Me.COURSENO, Me.CREATE_DATE, Me.UPDATE_DATE, Me.QUESTIONCLASS, Me.MAINCODE, Me.CATEGORYID, Me.STATE, Me.TEMPSHOWNO, Me.QUESTIONCODE_LINK, Me.MIDDLEQUESTIONINDEX, Me.SHOWNO, Me.LEVEL})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPracticeList.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPracticeList.EnableHeadersVisualStyles = False
        Me.dgvPracticeList.Location = New System.Drawing.Point(15, 184)
        Me.dgvPracticeList.Name = "dgvPracticeList"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeList.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPracticeList.RowHeadersVisible = False
        Me.dgvPracticeList.RowTemplate.Height = 21
        Me.dgvPracticeList.Size = New System.Drawing.Size(991, 430)
        Me.dgvPracticeList.TabIndex = 2
        '
        'CHECK
        '
        Me.CHECK.DataPropertyName = "CHECK"
        Me.CHECK.FalseValue = "0"
        Me.CHECK.Frozen = True
        Me.CHECK.HeaderText = ""
        Me.CHECK.Name = "CHECK"
        Me.CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CHECK.TrueValue = "1"
        Me.CHECK.Width = 30
        '
        'INDEXNUMBER
        '
        Me.INDEXNUMBER.DataPropertyName = "INDEXNUMBER"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.INDEXNUMBER.DefaultCellStyle = DataGridViewCellStyle2
        Me.INDEXNUMBER.HeaderText = "問番号"
        Me.INDEXNUMBER.Name = "INDEXNUMBER"
        Me.INDEXNUMBER.ReadOnly = True
        Me.INDEXNUMBER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.INDEXNUMBER.Width = 70
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONCODE.DefaultCellStyle = DataGridViewCellStyle3
        Me.QUESTIONCODE.HeaderText = "問題コード"
        Me.QUESTIONCODE.Name = "QUESTIONCODE"
        Me.QUESTIONCODE.ReadOnly = True
        Me.QUESTIONCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CATEGORYNAME1
        '
        Me.CATEGORYNAME1.DataPropertyName = "CATEGORYNAME1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME1.DefaultCellStyle = DataGridViewCellStyle4
        Me.CATEGORYNAME1.HeaderText = "大項目"
        Me.CATEGORYNAME1.Name = "CATEGORYNAME1"
        Me.CATEGORYNAME1.ReadOnly = True
        Me.CATEGORYNAME1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME1.Width = 200
        '
        'CATEGORYNAME2
        '
        Me.CATEGORYNAME2.DataPropertyName = "CATEGORYNAME2"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME2.DefaultCellStyle = DataGridViewCellStyle5
        Me.CATEGORYNAME2.HeaderText = "中項目"
        Me.CATEGORYNAME2.Name = "CATEGORYNAME2"
        Me.CATEGORYNAME2.ReadOnly = True
        Me.CATEGORYNAME2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME2.Width = 250
        '
        'CATEGORYNAME3
        '
        Me.CATEGORYNAME3.DataPropertyName = "CATEGORYNAME3"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME3.DefaultCellStyle = DataGridViewCellStyle6
        Me.CATEGORYNAME3.HeaderText = "小項目"
        Me.CATEGORYNAME3.Name = "CATEGORYNAME3"
        Me.CATEGORYNAME3.ReadOnly = True
        Me.CATEGORYNAME3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME3.Visible = False
        Me.CATEGORYNAME3.Width = 143
        '
        'THEME
        '
        Me.THEME.DataPropertyName = "THEME"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME.DefaultCellStyle = DataGridViewCellStyle7
        Me.THEME.HeaderText = "キーワード"
        Me.THEME.Name = "THEME"
        Me.THEME.ReadOnly = True
        Me.THEME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME.Width = 320
        '
        'CATEGORYNAME
        '
        Me.CATEGORYNAME.DataPropertyName = "CATEGORYNAME"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME.DefaultCellStyle = DataGridViewCellStyle8
        Me.CATEGORYNAME.HeaderText = "グループ"
        Me.CATEGORYNAME.Name = "CATEGORYNAME"
        Me.CATEGORYNAME.ReadOnly = True
        Me.CATEGORYNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME.Visible = False
        Me.CATEGORYNAME.Width = 143
        '
        'FORMAT
        '
        Me.FORMAT.DataPropertyName = "FORMAT"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FORMAT.DefaultCellStyle = DataGridViewCellStyle9
        Me.FORMAT.HeaderText = "属性"
        Me.FORMAT.Name = "FORMAT"
        Me.FORMAT.ReadOnly = True
        Me.FORMAT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FORMAT.Visible = False
        Me.FORMAT.Width = 40
        '
        'ANSWERS
        '
        Me.ANSWERS.DataPropertyName = "ANSWERS"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(0, 0, 14, 0)
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ANSWERS.DefaultCellStyle = DataGridViewCellStyle10
        Me.ANSWERS.HeaderText = "正解率"
        Me.ANSWERS.Name = "ANSWERS"
        Me.ANSWERS.ReadOnly = True
        Me.ANSWERS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ANSWERS.Visible = False
        Me.ANSWERS.Width = 60
        '
        'QUESTIONCOUNT
        '
        Me.QUESTIONCOUNT.DataPropertyName = "QUESTIONCOUNT"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONCOUNT.DefaultCellStyle = DataGridViewCellStyle11
        Me.QUESTIONCOUNT.HeaderText = "演習回数"
        Me.QUESTIONCOUNT.Name = "QUESTIONCOUNT"
        Me.QUESTIONCOUNT.ReadOnly = True
        Me.QUESTIONCOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONCOUNT.Visible = False
        Me.QUESTIONCOUNT.Width = 63
        '
        'COURSENO
        '
        Me.COURSENO.DataPropertyName = "COURSENO"
        Me.COURSENO.HeaderText = "コースNo"
        Me.COURSENO.Name = "COURSENO"
        Me.COURSENO.Visible = False
        '
        'CREATE_DATE
        '
        Me.CREATE_DATE.DataPropertyName = "CREATE_DATE"
        Me.CREATE_DATE.HeaderText = "作成日"
        Me.CREATE_DATE.Name = "CREATE_DATE"
        Me.CREATE_DATE.Visible = False
        '
        'UPDATE_DATE
        '
        Me.UPDATE_DATE.DataPropertyName = "UPDATE_DATE"
        Me.UPDATE_DATE.HeaderText = "更新日"
        Me.UPDATE_DATE.Name = "UPDATE_DATE"
        Me.UPDATE_DATE.Visible = False
        '
        'QUESTIONCLASS
        '
        Me.QUESTIONCLASS.DataPropertyName = "QUESTIONCLASS"
        Me.QUESTIONCLASS.HeaderText = "問題レベル"
        Me.QUESTIONCLASS.Name = "QUESTIONCLASS"
        Me.QUESTIONCLASS.Visible = False
        '
        'MAINCODE
        '
        Me.MAINCODE.DataPropertyName = "MAINCODE"
        Me.MAINCODE.HeaderText = "中問コード"
        Me.MAINCODE.Name = "MAINCODE"
        Me.MAINCODE.Visible = False
        '
        'CATEGORYID
        '
        Me.CATEGORYID.DataPropertyName = "CATEGORYID"
        Me.CATEGORYID.HeaderText = "カテゴリID"
        Me.CATEGORYID.Name = "CATEGORYID"
        Me.CATEGORYID.Visible = False
        '
        'STATE
        '
        Me.STATE.DataPropertyName = "STATE"
        Me.STATE.HeaderText = "状態"
        Me.STATE.Name = "STATE"
        Me.STATE.Visible = False
        '
        'TEMPSHOWNO
        '
        Me.TEMPSHOWNO.DataPropertyName = "TEMPSHOWNO"
        Me.TEMPSHOWNO.HeaderText = "テンポラリ表示"
        Me.TEMPSHOWNO.Name = "TEMPSHOWNO"
        Me.TEMPSHOWNO.Visible = False
        '
        'QUESTIONCODE_LINK
        '
        Me.QUESTIONCODE_LINK.DataPropertyName = "QUESTIONCODE_LINK"
        Me.QUESTIONCODE_LINK.HeaderText = "リンク用問題コード"
        Me.QUESTIONCODE_LINK.Name = "QUESTIONCODE_LINK"
        Me.QUESTIONCODE_LINK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QUESTIONCODE_LINK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONCODE_LINK.Visible = False
        '
        'MIDDLEQUESTIONINDEX
        '
        Me.MIDDLEQUESTIONINDEX.DataPropertyName = "MIDDLEQUESTIONINDEX"
        Me.MIDDLEQUESTIONINDEX.HeaderText = "中問INDEX"
        Me.MIDDLEQUESTIONINDEX.Name = "MIDDLEQUESTIONINDEX"
        Me.MIDDLEQUESTIONINDEX.Visible = False
        '
        'SHOWNO
        '
        Me.SHOWNO.DataPropertyName = "SHOWNO"
        Me.SHOWNO.HeaderText = "表示順"
        Me.SHOWNO.Name = "SHOWNO"
        Me.SHOWNO.Visible = False
        '
        'LEVEL
        '
        Me.LEVEL.DataPropertyName = "LEVEL_STR"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LEVEL.DefaultCellStyle = DataGridViewCellStyle12
        Me.LEVEL.HeaderText = "難易度"
        Me.LEVEL.Name = "LEVEL"
        Me.LEVEL.ReadOnly = True
        Me.LEVEL.Visible = False
        '
        'ChkT
        '
        Me.ChkT.AutoSize = True
        Me.ChkT.Location = New System.Drawing.Point(386, 626)
        Me.ChkT.Name = "ChkT"
        Me.ChkT.Size = New System.Drawing.Size(68, 16)
        Me.ChkT.TabIndex = 237
        Me.ChkT.Text = "正解有り"
        Me.ChkT.UseVisualStyleBackColor = True
        '
        'ChkQ
        '
        Me.ChkQ.AutoSize = True
        Me.ChkQ.Location = New System.Drawing.Point(272, 626)
        Me.ChkQ.Name = "ChkQ"
        Me.ChkQ.Size = New System.Drawing.Size(95, 16)
        Me.ChkQ.TabIndex = 236
        Me.ChkQ.Text = "問題コード有り"
        Me.ChkQ.UseVisualStyleBackColor = True
        '
        'btnWord
        '
        Me.btnWord.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnWord.Location = New System.Drawing.Point(472, 620)
        Me.btnWord.Name = "btnWord"
        Me.btnWord.Size = New System.Drawing.Size(154, 30)
        Me.btnWord.TabIndex = 235
        Me.btnWord.Text = "WORDファイル出力"
        Me.btnWord.UseVisualStyleBackColor = True
        '
        'btnSrcQ
        '
        Me.btnSrcQ.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnSrcQ.Location = New System.Drawing.Point(814, 143)
        Me.btnSrcQ.Name = "btnSrcQ"
        Me.btnSrcQ.Size = New System.Drawing.Size(162, 30)
        Me.btnSrcQ.TabIndex = 239
        Me.btnSrcQ.Text = "問番号グループ順"
        Me.btnSrcQ.UseVisualStyleBackColor = True
        '
        'BtnSrcS
        '
        Me.BtnSrcS.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.BtnSrcS.Location = New System.Drawing.Point(814, 100)
        Me.BtnSrcS.Name = "BtnSrcS"
        Me.BtnSrcS.Size = New System.Drawing.Size(162, 30)
        Me.BtnSrcS.TabIndex = 238
        Me.BtnSrcS.Text = "問番号シャッフル"
        Me.BtnSrcS.UseVisualStyleBackColor = True
        '
        'btnTransfer
        '
        Me.btnTransfer.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnTransfer.Location = New System.Drawing.Point(650, 620)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(154, 30)
        Me.btnTransfer.TabIndex = 240
        Me.btnTransfer.Text = "ＣＢＴセンターに配信"
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'frmSynthesisInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.btnSrcQ)
        Me.Controls.Add(Me.BtnSrcS)
        Me.Controls.Add(Me.ChkT)
        Me.Controls.Add(Me.ChkQ)
        Me.Controls.Add(Me.btnWord)
        Me.Controls.Add(Me.dgvPracticeList)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnRegistration)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnChangeQuestion)
        Me.Controls.Add(Me.btnSynthesisInput)
        Me.Controls.Add(Me.txtSynthesisName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmSynthesisInput"
        Me.Text = "自動テスト作成"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtSynthesisName, 0)
        Me.Controls.SetChildIndex(Me.btnSynthesisInput, 0)
        Me.Controls.SetChildIndex(Me.btnChangeQuestion, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnRegistration, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.dgvPracticeList, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.btnWord, 0)
        Me.Controls.SetChildIndex(Me.ChkQ, 0)
        Me.Controls.SetChildIndex(Me.ChkT, 0)
        Me.Controls.SetChildIndex(Me.BtnSrcS, 0)
        Me.Controls.SetChildIndex(Me.btnSrcQ, 0)
        Me.Controls.SetChildIndex(Me.btnTransfer, 0)
        CType(Me.dgvPracticeList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSynthesisName As System.Windows.Forms.TextBox
    Friend WithEvents btnSynthesisInput As System.Windows.Forms.Button
    Friend WithEvents btnChangeQuestion As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRegistration As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents dgvPracticeList As System.Windows.Forms.DataGridView
    Friend WithEvents CHECK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents INDEXNUMBER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CATEGORYNAME1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANSWERS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONCOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COURSENO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATE_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UPDATE_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONCLASS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAINCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEMPSHOWNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONCODE_LINK As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents MIDDLEQUESTIONINDEX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHOWNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LEVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkT As System.Windows.Forms.CheckBox
    Friend WithEvents ChkQ As System.Windows.Forms.CheckBox
    Friend WithEvents btnWord As System.Windows.Forms.Button
    Friend WithEvents btnSrcQ As System.Windows.Forms.Button
    Friend WithEvents BtnSrcS As System.Windows.Forms.Button
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
End Class
