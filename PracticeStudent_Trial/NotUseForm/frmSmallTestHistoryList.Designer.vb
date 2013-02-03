<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmallTestHistoryList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdJhoken = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dtpTestEnd = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.dtpTestStart = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.cmbCategory3 = New System.Windows.Forms.ComboBox()
        Me.cmbCategory2 = New System.Windows.Forms.ComboBox()
        Me.cmbCategory1 = New System.Windows.Forms.ComboBox()
        Me.txtSeiUnder = New System.Windows.Forms.TextBox()
        Me.txtSeiOver = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.cmbTestName = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBackHistoryMenu = New System.Windows.Forms.Button()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.LabelLine2 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblBunya = New System.Windows.Forms.Label()
        Me.lblDaiBun = New System.Windows.Forms.Label()
        Me.lblTyuBun = New System.Windows.Forms.Label()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime1 = New System.Windows.Forms.Label()
        Me.lblTime2 = New System.Windows.Forms.Label()
        Me.lblSeisuu = New System.Windows.Forms.Label()
        Me.lblMonsuu = New System.Windows.Forms.Label()
        Me.lblSeiRitu = New System.Windows.Forms.Label()
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        'grdJhoken
        '
        Me.grdJhoken.AllowUserToAddRows = False
        Me.grdJhoken.AllowUserToDeleteRows = False
        Me.grdJhoken.AllowUserToResizeColumns = False
        Me.grdJhoken.AllowUserToResizeRows = False
        Me.grdJhoken.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdJhoken.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdJhoken.ColumnHeadersHeight = 34
        Me.grdJhoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdJhoken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column1, Me.Column2, Me.Column3, Me.Column8, Me.Column9, Me.Column5, Me.Column6, Me.Column4})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdJhoken.DefaultCellStyle = DataGridViewCellStyle11
        Me.grdJhoken.EnableHeadersVisualStyles = False
        Me.grdJhoken.Location = New System.Drawing.Point(12, 285)
        Me.grdJhoken.Name = "grdJhoken"
        Me.grdJhoken.RowHeadersVisible = False
        Me.grdJhoken.RowTemplate.Height = 50
        Me.grdJhoken.RowTemplate.ReadOnly = True
        Me.grdJhoken.Size = New System.Drawing.Size(1001, 336)
        Me.grdJhoken.TabIndex = 9
        Me.grdJhoken.TabStop = False
        '
        'Column7
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column7.HeaderText = ""
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.Width = 140
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Width = 131
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.Width = 160
        '
        'Column3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.Width = 210
        '
        'Column8
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column8.HeaderText = ""
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column9
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column9.HeaderText = ""
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column9.Width = 60
        '
        'Column5
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.Width = 60
        '
        'Column6
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.Width = 60
        '
        'Column4
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(0, 0, 13, 0)
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.Width = 60
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(27, 129)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(100, 25)
        Me.Panel4.TabIndex = 82
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "〔抽出条件〕"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.dtpTestEnd)
        Me.Panel3.Controls.Add(Me.dtpTestStart)
        Me.Panel3.Controls.Add(Me.cmbCategory3)
        Me.Panel3.Controls.Add(Me.cmbCategory2)
        Me.Panel3.Controls.Add(Me.cmbCategory1)
        Me.Panel3.Controls.Add(Me.txtSeiUnder)
        Me.Panel3.Controls.Add(Me.txtSeiOver)
        Me.Panel3.Controls.Add(Me.btnExtract)
        Me.Panel3.Controls.Add(Me.cmbTestName)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(7, 140)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1006, 139)
        Me.Panel3.TabIndex = 81
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label30.Location = New System.Drawing.Point(231, 100)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(22, 15)
        Me.Label30.TabIndex = 92
        Me.Label30.Text = "～"
        '
        'dtpTestEnd
        '
        Me.dtpTestEnd.IsNull = False
        Me.dtpTestEnd.Location = New System.Drawing.Point(262, 96)
        Me.dtpTestEnd.Name = "dtpTestEnd"
        Me.dtpTestEnd.Size = New System.Drawing.Size(143, 22)
        Me.dtpTestEnd.TabIndex = 5
        '
        'dtpTestStart
        '
        Me.dtpTestStart.IsNull = False
        Me.dtpTestStart.Location = New System.Drawing.Point(77, 96)
        Me.dtpTestStart.Name = "dtpTestStart"
        Me.dtpTestStart.Size = New System.Drawing.Size(143, 22)
        Me.dtpTestStart.TabIndex = 4
        '
        'cmbCategory3
        '
        Me.cmbCategory3.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory3.FormattingEnabled = True
        Me.cmbCategory3.Location = New System.Drawing.Point(744, 58)
        Me.cmbCategory3.Name = "cmbCategory3"
        Me.cmbCategory3.Size = New System.Drawing.Size(220, 23)
        Me.cmbCategory3.TabIndex = 3
        Me.cmbCategory3.ValueMember = "CATEGORYID"
        '
        'cmbCategory2
        '
        Me.cmbCategory2.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory2.FormattingEnabled = True
        Me.cmbCategory2.Location = New System.Drawing.Point(407, 58)
        Me.cmbCategory2.Name = "cmbCategory2"
        Me.cmbCategory2.Size = New System.Drawing.Size(220, 23)
        Me.cmbCategory2.TabIndex = 2
        Me.cmbCategory2.ValueMember = "CATEGORYID"
        '
        'cmbCategory1
        '
        Me.cmbCategory1.DisplayMember = "CATEGORYNAME"
        Me.cmbCategory1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCategory1.FormattingEnabled = True
        Me.cmbCategory1.Location = New System.Drawing.Point(78, 58)
        Me.cmbCategory1.Name = "cmbCategory1"
        Me.cmbCategory1.Size = New System.Drawing.Size(221, 23)
        Me.cmbCategory1.TabIndex = 1
        Me.cmbCategory1.ValueMember = "CATEGORYID"
        '
        'txtSeiUnder
        '
        Me.txtSeiUnder.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSeiUnder.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSeiUnder.Location = New System.Drawing.Point(680, 96)
        Me.txtSeiUnder.MaxLength = 4
        Me.txtSeiUnder.Name = "txtSeiUnder"
        Me.txtSeiUnder.Size = New System.Drawing.Size(68, 26)
        Me.txtSeiUnder.TabIndex = 7
        Me.txtSeiUnder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSeiOver
        '
        Me.txtSeiOver.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSeiOver.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSeiOver.Location = New System.Drawing.Point(534, 96)
        Me.txtSeiOver.MaxLength = 4
        Me.txtSeiOver.Name = "txtSeiOver"
        Me.txtSeiOver.Size = New System.Drawing.Size(68, 26)
        Me.txtSeiOver.TabIndex = 6
        Me.txtSeiOver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExtract
        '
        Me.btnExtract.BackColor = System.Drawing.SystemColors.Control
        Me.btnExtract.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExtract.Location = New System.Drawing.Point(833, 90)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(132, 36)
        Me.btnExtract.TabIndex = 8
        Me.btnExtract.Text = "抽出"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'cmbTestName
        '
        Me.cmbTestName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTestName.FormattingEnabled = True
        Me.cmbTestName.Location = New System.Drawing.Point(78, 20)
        Me.cmbTestName.Name = "cmbTestName"
        Me.cmbTestName.Size = New System.Drawing.Size(221, 23)
        Me.cmbTestName.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(666, 61)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 15)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "【中分類】"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(332, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 15)
        Me.Label16.TabIndex = 63
        Me.Label16.Text = "【大分類】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(752, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "%以下"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 15)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "【分野】"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 15)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "【テスト名】"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(608, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 15)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "%以上　～"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 15)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "【実施日】"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(460, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "【正解率】"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(195, 19)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "小テスト実施履歴一覧"
        '
        'btnBackHistoryMenu
        '
        Me.btnBackHistoryMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackHistoryMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackHistoryMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackHistoryMenu.Name = "btnBackHistoryMenu"
        Me.btnBackHistoryMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackHistoryMenu.TabIndex = 10
        Me.btnBackHistoryMenu.Text = "履歴確認メニューへ戻る"
        Me.btnBackHistoryMenu.UseVisualStyleBackColor = True
        '
        'LabelLine
        '
        Me.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLine.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelLine.Location = New System.Drawing.Point(154, 301)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(500, 2)
        Me.LabelLine.TabIndex = 85
        '
        'LabelHeader1
        '
        Me.LabelHeader1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(155, 287)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(499, 15)
        Me.LabelHeader1.TabIndex = 86
        Me.LabelHeader1.Text = "分類"
        Me.LabelHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelLine2
        '
        Me.LabelLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLine2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelLine2.Location = New System.Drawing.Point(814, 301)
        Me.LabelLine2.Name = "LabelLine2"
        Me.LabelLine2.Size = New System.Drawing.Size(180, 2)
        Me.LabelLine2.TabIndex = 87
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(817, 287)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(175, 15)
        Me.Label31.TabIndex = 86
        Me.Label31.Text = "テスト結果"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBunya
        '
        Me.lblBunya.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblBunya.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBunya.Location = New System.Drawing.Point(154, 304)
        Me.lblBunya.Name = "lblBunya"
        Me.lblBunya.Size = New System.Drawing.Size(129, 13)
        Me.lblBunya.TabIndex = 86
        Me.lblBunya.Text = "分野"
        Me.lblBunya.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDaiBun
        '
        Me.lblDaiBun.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDaiBun.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDaiBun.Location = New System.Drawing.Point(286, 304)
        Me.lblDaiBun.Name = "lblDaiBun"
        Me.lblDaiBun.Size = New System.Drawing.Size(157, 14)
        Me.lblDaiBun.TabIndex = 86
        Me.lblDaiBun.Text = "大分類"
        Me.lblDaiBun.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTyuBun
        '
        Me.lblTyuBun.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTyuBun.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTyuBun.Location = New System.Drawing.Point(445, 304)
        Me.lblTyuBun.Name = "lblTyuBun"
        Me.lblTyuBun.Size = New System.Drawing.Size(208, 13)
        Me.lblTyuBun.TabIndex = 86
        Me.lblTyuBun.Text = "中分類"
        Me.lblTyuBun.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTestName
        '
        Me.lblTestName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTestName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestName.Location = New System.Drawing.Point(14, 289)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(139, 29)
        Me.lblTestName.TabIndex = 86
        Me.lblTestName.Text = "テスト名"
        Me.lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDate.Location = New System.Drawing.Point(655, 289)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(99, 29)
        Me.lblDate.TabIndex = 86
        Me.lblDate.Text = "実施日"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime1
        '
        Me.lblTime1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTime1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime1.Location = New System.Drawing.Point(755, 289)
        Me.lblTime1.Name = "lblTime1"
        Me.lblTime1.Size = New System.Drawing.Size(59, 13)
        Me.lblTime1.TabIndex = 86
        Me.lblTime1.Text = "テスト"
        Me.lblTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime2
        '
        Me.lblTime2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTime2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime2.Location = New System.Drawing.Point(755, 304)
        Me.lblTime2.Name = "lblTime2"
        Me.lblTime2.Size = New System.Drawing.Size(59, 13)
        Me.lblTime2.TabIndex = 86
        Me.lblTime2.Text = "時間"
        Me.lblTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeisuu
        '
        Me.lblSeisuu.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblSeisuu.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSeisuu.Location = New System.Drawing.Point(815, 304)
        Me.lblSeisuu.Name = "lblSeisuu"
        Me.lblSeisuu.Size = New System.Drawing.Size(59, 13)
        Me.lblSeisuu.TabIndex = 86
        Me.lblSeisuu.Text = "正解数"
        Me.lblSeisuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonsuu
        '
        Me.lblMonsuu.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblMonsuu.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMonsuu.Location = New System.Drawing.Point(875, 304)
        Me.lblMonsuu.Name = "lblMonsuu"
        Me.lblMonsuu.Size = New System.Drawing.Size(59, 13)
        Me.lblMonsuu.TabIndex = 86
        Me.lblMonsuu.Text = "問題数"
        Me.lblMonsuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeiRitu
        '
        Me.lblSeiRitu.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblSeiRitu.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSeiRitu.Location = New System.Drawing.Point(935, 304)
        Me.lblSeiRitu.Name = "lblSeiRitu"
        Me.lblSeiRitu.Size = New System.Drawing.Size(59, 13)
        Me.lblSeiRitu.TabIndex = 86
        Me.lblSeiRitu.Text = "正解率"
        Me.lblSeiRitu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSmallTestHistoryList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.LabelLine2)
        Me.Controls.Add(Me.LabelLine)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.lblTyuBun)
        Me.Controls.Add(Me.lblDaiBun)
        Me.Controls.Add(Me.lblSeiRitu)
        Me.Controls.Add(Me.lblMonsuu)
        Me.Controls.Add(Me.lblSeisuu)
        Me.Controls.Add(Me.lblTime2)
        Me.Controls.Add(Me.lblTime1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblTestName)
        Me.Controls.Add(Me.lblBunya)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Controls.Add(Me.btnBackHistoryMenu)
        Me.Controls.Add(Me.grdJhoken)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "frmSmallTestHistoryList"
        Me.Text = "frmSmallTestHistoryList"
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.grdJhoken, 0)
        Me.Controls.SetChildIndex(Me.btnBackHistoryMenu, 0)
        Me.Controls.SetChildIndex(Me.LabelHeader1, 0)
        Me.Controls.SetChildIndex(Me.lblBunya, 0)
        Me.Controls.SetChildIndex(Me.lblTestName, 0)
        Me.Controls.SetChildIndex(Me.lblDate, 0)
        Me.Controls.SetChildIndex(Me.lblTime1, 0)
        Me.Controls.SetChildIndex(Me.lblTime2, 0)
        Me.Controls.SetChildIndex(Me.lblSeisuu, 0)
        Me.Controls.SetChildIndex(Me.lblMonsuu, 0)
        Me.Controls.SetChildIndex(Me.lblSeiRitu, 0)
        Me.Controls.SetChildIndex(Me.lblDaiBun, 0)
        Me.Controls.SetChildIndex(Me.lblTyuBun, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.LabelLine, 0)
        Me.Controls.SetChildIndex(Me.LabelLine2, 0)
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdJhoken As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTestName As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnBackHistoryMenu As System.Windows.Forms.Button
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents txtSeiUnder As System.Windows.Forms.TextBox
    Friend WithEvents txtSeiOver As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCategory3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents dtpTestEnd As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents dtpTestStart As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents LabelHeader1 As System.Windows.Forms.Label
    Friend WithEvents LabelLine2 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblBunya As System.Windows.Forms.Label
    Friend WithEvents lblDaiBun As System.Windows.Forms.Label
    Friend WithEvents lblTyuBun As System.Windows.Forms.Label
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblTime1 As System.Windows.Forms.Label
    Friend WithEvents lblTime2 As System.Windows.Forms.Label
    Friend WithEvents lblSeisuu As System.Windows.Forms.Label
    Friend WithEvents lblMonsuu As System.Windows.Forms.Label
    Friend WithEvents lblSeiRitu As System.Windows.Forms.Label
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
