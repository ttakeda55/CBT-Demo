<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisTestHistory
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dtpTestEnd = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.dtpTestStart = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.txtSeiUnder = New System.Windows.Forms.TextBox()
        Me.txtSeiOver = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.cmbTestName = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdJhoken = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBackHistoryMenu = New System.Windows.Forms.Button()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.lblTime2 = New System.Windows.Forms.Label()
        Me.lblTime1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblSeiRitu = New System.Windows.Forms.Label()
        Me.lblBunya1 = New System.Windows.Forms.Label()
        Me.lblBunya2 = New System.Windows.Forms.Label()
        Me.lblBunya3 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label30.Location = New System.Drawing.Point(224, 74)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(22, 15)
        Me.Label30.TabIndex = 92
        Me.Label30.Text = "～"
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
        Me.Panel3.Controls.Add(Me.txtSeiUnder)
        Me.Panel3.Controls.Add(Me.txtSeiOver)
        Me.Panel3.Controls.Add(Me.btnExtract)
        Me.Panel3.Controls.Add(Me.cmbTestName)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(7, 140)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1006, 110)
        Me.Panel3.TabIndex = 84
        '
        'dtpTestEnd
        '
        Me.dtpTestEnd.IsNull = False
        Me.dtpTestEnd.Location = New System.Drawing.Point(255, 70)
        Me.dtpTestEnd.Name = "dtpTestEnd"
        Me.dtpTestEnd.Size = New System.Drawing.Size(143, 22)
        Me.dtpTestEnd.TabIndex = 2
        '
        'dtpTestStart
        '
        Me.dtpTestStart.IsNull = False
        Me.dtpTestStart.Location = New System.Drawing.Point(70, 70)
        Me.dtpTestStart.Name = "dtpTestStart"
        Me.dtpTestStart.Size = New System.Drawing.Size(143, 22)
        Me.dtpTestStart.TabIndex = 1
        '
        'txtSeiUnder
        '
        Me.txtSeiUnder.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSeiUnder.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSeiUnder.Location = New System.Drawing.Point(680, 68)
        Me.txtSeiUnder.MaxLength = 4
        Me.txtSeiUnder.Name = "txtSeiUnder"
        Me.txtSeiUnder.Size = New System.Drawing.Size(68, 26)
        Me.txtSeiUnder.TabIndex = 4
        Me.txtSeiUnder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSeiOver
        '
        Me.txtSeiOver.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSeiOver.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSeiOver.Location = New System.Drawing.Point(534, 68)
        Me.txtSeiOver.MaxLength = 4
        Me.txtSeiOver.Name = "txtSeiOver"
        Me.txtSeiOver.Size = New System.Drawing.Size(68, 26)
        Me.txtSeiOver.TabIndex = 3
        Me.txtSeiOver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnExtract
        '
        Me.btnExtract.BackColor = System.Drawing.SystemColors.Control
        Me.btnExtract.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnExtract.Location = New System.Drawing.Point(833, 62)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(132, 36)
        Me.btnExtract.TabIndex = 5
        Me.btnExtract.Text = "抽出"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'cmbTestName
        '
        Me.cmbTestName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTestName.FormattingEnabled = True
        Me.cmbTestName.Location = New System.Drawing.Point(70, 20)
        Me.cmbTestName.Name = "cmbTestName"
        Me.cmbTestName.Size = New System.Drawing.Size(126, 23)
        Me.cmbTestName.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(752, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "%以下"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(253, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "～"
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
        Me.Label8.Location = New System.Drawing.Point(608, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 15)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "%以上　～"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 15)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "【実施日】"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(460, 73)
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
        Me.Label11.Size = New System.Drawing.Size(215, 19)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "総合テスト実施履歴一覧"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(27, 129)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(100, 25)
        Me.Panel4.TabIndex = 85
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
        Me.grdJhoken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8, Me.Column9, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdJhoken.DefaultCellStyle = DataGridViewCellStyle9
        Me.grdJhoken.EnableHeadersVisualStyles = False
        Me.grdJhoken.Location = New System.Drawing.Point(32, 264)
        Me.grdJhoken.Name = "grdJhoken"
        Me.grdJhoken.RowHeadersVisible = False
        Me.grdJhoken.RowTemplate.Height = 21
        Me.grdJhoken.Size = New System.Drawing.Size(710, 372)
        Me.grdJhoken.TabIndex = 96
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
        Me.Column7.Width = 130
        '
        'Column8
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column8.HeaderText = ""
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column9
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column9.HeaderText = ""
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column9.Width = 60
        '
        'Column1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(0, 0, 33, 0)
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 0, 33, 0)
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column3
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(0, 0, 33, 0)
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column4
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(0, 0, 33, 0)
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Column5
        '
        Me.Column5.HeaderText = "テストNo"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "実施回数"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'btnBackHistoryMenu
        '
        Me.btnBackHistoryMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackHistoryMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackHistoryMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackHistoryMenu.Name = "btnBackHistoryMenu"
        Me.btnBackHistoryMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackHistoryMenu.TabIndex = 6
        Me.btnBackHistoryMenu.Text = "履歴確認メニューへ戻る"
        Me.btnBackHistoryMenu.UseVisualStyleBackColor = True
        '
        'LabelLine
        '
        Me.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLine.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelLine.Location = New System.Drawing.Point(324, 280)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(300, 2)
        Me.LabelLine.TabIndex = 98
        '
        'lblTime2
        '
        Me.lblTime2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTime2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime2.Location = New System.Drawing.Point(264, 283)
        Me.lblTime2.Name = "lblTime2"
        Me.lblTime2.Size = New System.Drawing.Size(59, 13)
        Me.lblTime2.TabIndex = 100
        Me.lblTime2.Text = "時間"
        Me.lblTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTime1
        '
        Me.lblTime1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTime1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime1.Location = New System.Drawing.Point(264, 269)
        Me.lblTime1.Name = "lblTime1"
        Me.lblTime1.Size = New System.Drawing.Size(59, 13)
        Me.lblTime1.TabIndex = 99
        Me.lblTime1.Text = "テスト"
        Me.lblTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.Location = New System.Drawing.Point(324, 266)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(299, 14)
        Me.Label31.TabIndex = 101
        Me.Label31.Text = "分野別正解率"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTestName
        '
        Me.lblTestName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblTestName.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestName.Location = New System.Drawing.Point(34, 268)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(129, 29)
        Me.lblTestName.TabIndex = 102
        Me.lblTestName.Text = "テスト名"
        Me.lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDate.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDate.Location = New System.Drawing.Point(164, 268)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(99, 29)
        Me.lblDate.TabIndex = 103
        Me.lblDate.Text = "実施日"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeiRitu
        '
        Me.lblSeiRitu.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblSeiRitu.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSeiRitu.Location = New System.Drawing.Point(624, 268)
        Me.lblSeiRitu.Name = "lblSeiRitu"
        Me.lblSeiRitu.Size = New System.Drawing.Size(99, 29)
        Me.lblSeiRitu.TabIndex = 103
        Me.lblSeiRitu.Text = "総合正解率"
        Me.lblSeiRitu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBunya1
        '
        Me.lblBunya1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblBunya1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBunya1.Location = New System.Drawing.Point(324, 283)
        Me.lblBunya1.Name = "lblBunya1"
        Me.lblBunya1.Size = New System.Drawing.Size(99, 13)
        Me.lblBunya1.TabIndex = 101
        Me.lblBunya1.Text = "ストラテジ系"
        Me.lblBunya1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBunya2
        '
        Me.lblBunya2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblBunya2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBunya2.Location = New System.Drawing.Point(424, 283)
        Me.lblBunya2.Name = "lblBunya2"
        Me.lblBunya2.Size = New System.Drawing.Size(99, 13)
        Me.lblBunya2.TabIndex = 101
        Me.lblBunya2.Text = "マネジメント系"
        Me.lblBunya2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBunya3
        '
        Me.lblBunya3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblBunya3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBunya3.Location = New System.Drawing.Point(524, 283)
        Me.lblBunya3.Name = "lblBunya3"
        Me.lblBunya3.Size = New System.Drawing.Size(99, 13)
        Me.lblBunya3.TabIndex = 101
        Me.lblBunya3.Text = "テクノロジ系"
        Me.lblBunya3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmSynthesisTestHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblSeiRitu)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblTestName)
        Me.Controls.Add(Me.lblBunya3)
        Me.Controls.Add(Me.lblBunya2)
        Me.Controls.Add(Me.lblBunya1)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.lblTime2)
        Me.Controls.Add(Me.lblTime1)
        Me.Controls.Add(Me.LabelLine)
        Me.Controls.Add(Me.btnBackHistoryMenu)
        Me.Controls.Add(Me.grdJhoken)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label11)
        Me.Name = "frmSynthesisTestHistory"
        Me.Text = "frmSynthesisTestHistory"
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.grdJhoken, 0)
        Me.Controls.SetChildIndex(Me.btnBackHistoryMenu, 0)
        Me.Controls.SetChildIndex(Me.LabelLine, 0)
        Me.Controls.SetChildIndex(Me.lblTime1, 0)
        Me.Controls.SetChildIndex(Me.lblTime2, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.lblBunya1, 0)
        Me.Controls.SetChildIndex(Me.lblBunya2, 0)
        Me.Controls.SetChildIndex(Me.lblBunya3, 0)
        Me.Controls.SetChildIndex(Me.lblTestName, 0)
        Me.Controls.SetChildIndex(Me.lblDate, 0)
        Me.Controls.SetChildIndex(Me.lblSeiRitu, 0)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dtpTestEnd As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents dtpTestStart As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents txtSeiUnder As System.Windows.Forms.TextBox
    Friend WithEvents txtSeiOver As System.Windows.Forms.TextBox
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents cmbTestName As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents grdJhoken As System.Windows.Forms.DataGridView
    Friend WithEvents btnBackHistoryMenu As System.Windows.Forms.Button
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents lblTime2 As System.Windows.Forms.Label
    Friend WithEvents lblTime1 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblSeiRitu As System.Windows.Forms.Label
    Friend WithEvents lblBunya1 As System.Windows.Forms.Label
    Friend WithEvents lblBunya2 As System.Windows.Forms.Label
    Friend WithEvents lblBunya3 As System.Windows.Forms.Label
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
