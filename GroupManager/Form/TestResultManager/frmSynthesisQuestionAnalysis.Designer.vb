<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisQuestionAnalysis
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvSynthesisQuestionAnalysis = New System.Windows.Forms.DataGridView()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.sfdExcel = New System.Windows.Forms.SaveFileDialog()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.udtpEnd = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.udtpStart = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmbSection2 = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbSection1 = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbTestCount = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotalEnd = New System.Windows.Forms.TextBox()
        Me.txtManagementEnd = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTotalStart = New System.Windows.Forms.TextBox()
        Me.txtManagementStart = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTechnologyEnd = New System.Windows.Forms.TextBox()
        Me.txtStrategyEnd = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtTechnologyStart = New System.Windows.Forms.TextBox()
        Me.txtStrategyStart = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbGroupCode = New System.Windows.Forms.ComboBox()
        Me.cmbGroupName = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbTestName = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.QUESTIONNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.CATEGORY1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORY2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORY3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TESTCOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ERRATA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECT5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECTNULL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvSynthesisQuestionAnalysis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
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
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(0, 19)
        Me.lblTitle01.Text = ""
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(27, 149)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(104, 25)
        Me.Panel2.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "〔分析条件〕"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(215, 19)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "総合テスト問別分析結果"
        '
        'dgvSynthesisQuestionAnalysis
        '
        Me.dgvSynthesisQuestionAnalysis.AllowUserToAddRows = False
        Me.dgvSynthesisQuestionAnalysis.AllowUserToResizeColumns = False
        Me.dgvSynthesisQuestionAnalysis.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSynthesisQuestionAnalysis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSynthesisQuestionAnalysis.ColumnHeadersHeight = 34
        Me.dgvSynthesisQuestionAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSynthesisQuestionAnalysis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONNO, Me.QUESTIONCODE, Me.CATEGORY1, Me.CATEGORY2, Me.CATEGORY3, Me.THEME, Me.TESTCOUNT, Me.ERRATA, Me.SELECT1, Me.SELECT2, Me.SELECT3, Me.SELECT4, Me.SELECT5, Me.SELECTNULL})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSynthesisQuestionAnalysis.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvSynthesisQuestionAnalysis.EnableHeadersVisualStyles = False
        Me.dgvSynthesisQuestionAnalysis.Location = New System.Drawing.Point(14, 341)
        Me.dgvSynthesisQuestionAnalysis.Name = "dgvSynthesisQuestionAnalysis"
        Me.dgvSynthesisQuestionAnalysis.RowHeadersVisible = False
        Me.dgvSynthesisQuestionAnalysis.RowTemplate.Height = 21
        Me.dgvSynthesisQuestionAnalysis.Size = New System.Drawing.Size(989, 267)
        Me.dgvSynthesisQuestionAnalysis.TabIndex = 190
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label33.Location = New System.Drawing.Point(12, 323)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(158, 15)
        Me.Label33.TabIndex = 126
        Me.Label33.Text = "〔問別正解率／選択率〕"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnSave.Location = New System.Drawing.Point(862, 617)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(136, 30)
        Me.btnSave.TabIndex = 200
        Me.btnSave.Text = "Excel形式で保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label32.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.Location = New System.Drawing.Point(127, 344)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(348, 13)
        Me.Label32.TabIndex = 132
        Me.Label32.Text = "分類"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label39.Location = New System.Drawing.Point(125, 357)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(350, 1)
        Me.Label39.TabIndex = 133
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.Location = New System.Drawing.Point(705, 344)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(276, 13)
        Me.Label36.TabIndex = 134
        Me.Label36.Text = "解答選択率"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label37.Location = New System.Drawing.Point(704, 357)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(278, 1)
        Me.Label37.TabIndex = 135
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(651, 12)
        Me.lblTree.TabIndex = 178
        Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 演習履歴管理メニュー ＞ 総合テスト履歴管理メニュー ＞ 総合テスト問別分析結果"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.udtpEnd)
        Me.pnlSearch.Controls.Add(Me.udtpStart)
        Me.pnlSearch.Controls.Add(Me.Label34)
        Me.pnlSearch.Controls.Add(Me.cmbSection2)
        Me.pnlSearch.Controls.Add(Me.Label31)
        Me.pnlSearch.Controls.Add(Me.cmbSection1)
        Me.pnlSearch.Controls.Add(Me.Label30)
        Me.pnlSearch.Controls.Add(Me.cmbTestCount)
        Me.pnlSearch.Controls.Add(Me.Label29)
        Me.pnlSearch.Controls.Add(Me.cmbCourse)
        Me.pnlSearch.Controls.Add(Me.Label6)
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.Label22)
        Me.pnlSearch.Controls.Add(Me.txtTotalEnd)
        Me.pnlSearch.Controls.Add(Me.txtManagementEnd)
        Me.pnlSearch.Controls.Add(Me.Label24)
        Me.pnlSearch.Controls.Add(Me.txtTotalStart)
        Me.pnlSearch.Controls.Add(Me.txtManagementStart)
        Me.pnlSearch.Controls.Add(Me.Label25)
        Me.pnlSearch.Controls.Add(Me.Label26)
        Me.pnlSearch.Controls.Add(Me.Label27)
        Me.pnlSearch.Controls.Add(Me.Label28)
        Me.pnlSearch.Controls.Add(Me.Label21)
        Me.pnlSearch.Controls.Add(Me.Label20)
        Me.pnlSearch.Controls.Add(Me.txtTechnologyEnd)
        Me.pnlSearch.Controls.Add(Me.txtStrategyEnd)
        Me.pnlSearch.Controls.Add(Me.Label23)
        Me.pnlSearch.Controls.Add(Me.txtTechnologyStart)
        Me.pnlSearch.Controls.Add(Me.txtStrategyStart)
        Me.pnlSearch.Controls.Add(Me.Label19)
        Me.pnlSearch.Controls.Add(Me.Label18)
        Me.pnlSearch.Controls.Add(Me.Label17)
        Me.pnlSearch.Controls.Add(Me.Label16)
        Me.pnlSearch.Controls.Add(Me.Label15)
        Me.pnlSearch.Controls.Add(Me.Label14)
        Me.pnlSearch.Controls.Add(Me.Label13)
        Me.pnlSearch.Controls.Add(Me.Label12)
        Me.pnlSearch.Controls.Add(Me.cmbGroupCode)
        Me.pnlSearch.Controls.Add(Me.cmbGroupName)
        Me.pnlSearch.Controls.Add(Me.Label11)
        Me.pnlSearch.Controls.Add(Me.Label8)
        Me.pnlSearch.Controls.Add(Me.Label9)
        Me.pnlSearch.Controls.Add(Me.Label35)
        Me.pnlSearch.Controls.Add(Me.cmbTestName)
        Me.pnlSearch.Controls.Add(Me.Label40)
        Me.pnlSearch.Location = New System.Drawing.Point(12, 166)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(991, 149)
        Me.pnlSearch.TabIndex = 179
        '
        'udtpEnd
        '
        Me.udtpEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.udtpEnd.IsNull = False
        Me.udtpEnd.Location = New System.Drawing.Point(823, 51)
        Me.udtpEnd.Name = "udtpEnd"
        Me.udtpEnd.Size = New System.Drawing.Size(143, 22)
        Me.udtpEnd.TabIndex = 90
        '
        'udtpStart
        '
        Me.udtpStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.udtpStart.IsNull = False
        Me.udtpStart.Location = New System.Drawing.Point(636, 51)
        Me.udtpStart.Name = "udtpStart"
        Me.udtpStart.Size = New System.Drawing.Size(143, 22)
        Me.udtpStart.TabIndex = 80
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label34.Location = New System.Drawing.Point(756, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 15)
        Me.Label34.TabIndex = 86
        Me.Label34.Text = "区分１"
        '
        'cmbSection2
        '
        Me.cmbSection2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSection2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSection2.FormattingEnabled = True
        Me.cmbSection2.Location = New System.Drawing.Point(918, 16)
        Me.cmbSection2.Name = "cmbSection2"
        Me.cmbSection2.Size = New System.Drawing.Size(48, 23)
        Me.cmbSection2.TabIndex = 50
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label31.Location = New System.Drawing.Point(865, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(47, 15)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "区分２"
        '
        'cmbSection1
        '
        Me.cmbSection1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSection1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSection1.FormattingEnabled = True
        Me.cmbSection1.Location = New System.Drawing.Point(809, 16)
        Me.cmbSection1.Name = "cmbSection1"
        Me.cmbSection1.Size = New System.Drawing.Size(48, 23)
        Me.cmbSection1.TabIndex = 40
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label30.Location = New System.Drawing.Point(682, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 15)
        Me.Label30.TabIndex = 78
        Me.Label30.Text = "【区分】"
        '
        'cmbTestCount
        '
        Me.cmbTestCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTestCount.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTestCount.FormattingEnabled = True
        Me.cmbTestCount.Location = New System.Drawing.Point(384, 50)
        Me.cmbTestCount.Name = "cmbTestCount"
        Me.cmbTestCount.Size = New System.Drawing.Size(121, 23)
        Me.cmbTestCount.TabIndex = 70
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label29.Location = New System.Drawing.Point(310, 54)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 15)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "【実施回】"
        '
        'cmbCourse
        '
        Me.cmbCourse.DisplayMember = "COURSE"
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(541, 16)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(121, 23)
        Me.cmbCourse.TabIndex = 30
        Me.cmbCourse.ValueMember = "COURSE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(467, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "【コース名】"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(878, 97)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 30)
        Me.btnSearch.TabIndex = 180
        Me.btnSearch.Text = "分析"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label22.Location = New System.Drawing.Point(791, 122)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 15)
        Me.Label22.TabIndex = 75
        Me.Label22.Text = "％以下"
        '
        'txtTotalEnd
        '
        Me.txtTotalEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTotalEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTotalEnd.Location = New System.Drawing.Point(744, 119)
        Me.txtTotalEnd.MaxLength = 4
        Me.txtTotalEnd.Name = "txtTotalEnd"
        Me.txtTotalEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtTotalEnd.TabIndex = 170
        Me.txtTotalEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManagementEnd
        '
        Me.txtManagementEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtManagementEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtManagementEnd.Location = New System.Drawing.Point(744, 84)
        Me.txtManagementEnd.MaxLength = 4
        Me.txtManagementEnd.Name = "txtManagementEnd"
        Me.txtManagementEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtManagementEnd.TabIndex = 130
        Me.txtManagementEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label24.Location = New System.Drawing.Point(791, 87)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 15)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "％以下"
        '
        'txtTotalStart
        '
        Me.txtTotalStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTotalStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTotalStart.Location = New System.Drawing.Point(617, 119)
        Me.txtTotalStart.MaxLength = 4
        Me.txtTotalStart.Name = "txtTotalStart"
        Me.txtTotalStart.Size = New System.Drawing.Size(41, 22)
        Me.txtTotalStart.TabIndex = 160
        Me.txtTotalStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManagementStart
        '
        Me.txtManagementStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtManagementStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtManagementStart.Location = New System.Drawing.Point(617, 84)
        Me.txtManagementStart.MaxLength = 4
        Me.txtManagementStart.Name = "txtManagementStart"
        Me.txtManagementStart.Size = New System.Drawing.Size(41, 22)
        Me.txtManagementStart.TabIndex = 120
        Me.txtManagementStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label25.Location = New System.Drawing.Point(716, 122)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(22, 15)
        Me.Label25.TabIndex = 69
        Me.Label25.Text = "～"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label26.Location = New System.Drawing.Point(664, 122)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 15)
        Me.Label26.TabIndex = 68
        Me.Label26.Text = "％以上"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label27.Location = New System.Drawing.Point(716, 87)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(22, 15)
        Me.Label27.TabIndex = 67
        Me.Label27.Text = "～"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label28.Location = New System.Drawing.Point(663, 87)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(52, 15)
        Me.Label28.TabIndex = 66
        Me.Label28.Text = "％以上"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label21.Location = New System.Drawing.Point(526, 87)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(89, 15)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "マネジメント系"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label20.Location = New System.Drawing.Point(391, 122)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 15)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "％以下"
        '
        'txtTechnologyEnd
        '
        Me.txtTechnologyEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTechnologyEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTechnologyEnd.Location = New System.Drawing.Point(344, 119)
        Me.txtTechnologyEnd.MaxLength = 4
        Me.txtTechnologyEnd.Name = "txtTechnologyEnd"
        Me.txtTechnologyEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtTechnologyEnd.TabIndex = 150
        Me.txtTechnologyEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStrategyEnd
        '
        Me.txtStrategyEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStrategyEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtStrategyEnd.Location = New System.Drawing.Point(344, 84)
        Me.txtStrategyEnd.MaxLength = 4
        Me.txtStrategyEnd.Name = "txtStrategyEnd"
        Me.txtStrategyEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtStrategyEnd.TabIndex = 110
        Me.txtStrategyEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label23.Location = New System.Drawing.Point(391, 87)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 15)
        Me.Label23.TabIndex = 58
        Me.Label23.Text = "％以下"
        '
        'txtTechnologyStart
        '
        Me.txtTechnologyStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTechnologyStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtTechnologyStart.Location = New System.Drawing.Point(217, 119)
        Me.txtTechnologyStart.MaxLength = 4
        Me.txtTechnologyStart.Name = "txtTechnologyStart"
        Me.txtTechnologyStart.Size = New System.Drawing.Size(41, 22)
        Me.txtTechnologyStart.TabIndex = 140
        Me.txtTechnologyStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStrategyStart
        '
        Me.txtStrategyStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStrategyStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtStrategyStart.Location = New System.Drawing.Point(217, 84)
        Me.txtStrategyStart.MaxLength = 4
        Me.txtStrategyStart.Name = "txtStrategyStart"
        Me.txtStrategyStart.Size = New System.Drawing.Size(41, 22)
        Me.txtStrategyStart.TabIndex = 100
        Me.txtStrategyStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label19.Location = New System.Drawing.Point(316, 122)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(22, 15)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "～"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label18.Location = New System.Drawing.Point(264, 122)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 15)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "％以上"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label17.Location = New System.Drawing.Point(316, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 15)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "～"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label16.Location = New System.Drawing.Point(526, 122)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 15)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "総合正解率"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label15.Location = New System.Drawing.Point(263, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 15)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "％以上"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label14.Location = New System.Drawing.Point(134, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 15)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "テクノロジ系"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label13.Location = New System.Drawing.Point(134, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 15)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "ストラテジ系"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label12.Location = New System.Drawing.Point(795, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 15)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "～"
        '
        'cmbGroupCode
        '
        Me.cmbGroupCode.DisplayMember = "GROUPCODE"
        Me.cmbGroupCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupCode.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroupCode.FormattingEnabled = True
        Me.cmbGroupCode.Location = New System.Drawing.Point(113, 16)
        Me.cmbGroupCode.Name = "cmbGroupCode"
        Me.cmbGroupCode.Size = New System.Drawing.Size(121, 23)
        Me.cmbGroupCode.TabIndex = 10
        Me.cmbGroupCode.ValueMember = "GROUPCODE"
        '
        'cmbGroupName
        '
        Me.cmbGroupName.DisplayMember = "GROUPNAME"
        Me.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroupName.FormattingEnabled = True
        Me.cmbGroupName.Location = New System.Drawing.Point(326, 16)
        Me.cmbGroupName.Name = "cmbGroupName"
        Me.cmbGroupName.Size = New System.Drawing.Size(121, 23)
        Me.cmbGroupName.TabIndex = 20
        Me.cmbGroupName.ValueMember = "GROUPCODE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(36, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "【正解率】"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(36, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "【コード】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(562, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "【実施日】"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label35.Location = New System.Drawing.Point(252, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(68, 15)
        Me.Label35.TabIndex = 42
        Me.Label35.Text = "【団体名】"
        '
        'cmbTestName
        '
        Me.cmbTestName.DisplayMember = "TESTNAME"
        Me.cmbTestName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbTestName.FormattingEnabled = True
        Me.cmbTestName.Location = New System.Drawing.Point(113, 50)
        Me.cmbTestName.Name = "cmbTestName"
        Me.cmbTestName.Size = New System.Drawing.Size(162, 23)
        Me.cmbTestName.TabIndex = 60
        Me.cmbTestName.ValueMember = "TESTNO"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label40.Location = New System.Drawing.Point(36, 53)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(71, 15)
        Me.Label40.TabIndex = 87
        Me.Label40.Text = "【テスト名】"
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(791, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(221, 30)
        Me.btnBack.TabIndex = 210
        Me.btnBack.Text = "総合テスト履歴管理メニューへ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'QUESTIONNO
        '
        Me.QUESTIONNO.DataPropertyName = "SHOWNO_NUM"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QUESTIONNO.DefaultCellStyle = DataGridViewCellStyle2
        Me.QUESTIONNO.HeaderText = "問"
        Me.QUESTIONNO.Name = "QUESTIONNO"
        Me.QUESTIONNO.ReadOnly = True
        Me.QUESTIONNO.Width = 30
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = "M2009S001"
        Me.QUESTIONCODE.DefaultCellStyle = DataGridViewCellStyle3
        Me.QUESTIONCODE.HeaderText = "問題コード"
        Me.QUESTIONCODE.Name = "QUESTIONCODE"
        Me.QUESTIONCODE.ReadOnly = True
        Me.QUESTIONCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONCODE.Width = 80
        '
        'CATEGORY1
        '
        Me.CATEGORY1.DataPropertyName = "CATEGORY1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CATEGORY1.DefaultCellStyle = DataGridViewCellStyle4
        Me.CATEGORY1.HeaderText = "     分野      "
        Me.CATEGORY1.Name = "CATEGORY1"
        Me.CATEGORY1.ReadOnly = True
        Me.CATEGORY1.Width = 80
        '
        'CATEGORY2
        '
        Me.CATEGORY2.DataPropertyName = "CATEGORY2"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CATEGORY2.DefaultCellStyle = DataGridViewCellStyle5
        Me.CATEGORY2.HeaderText = "         大分類        "
        Me.CATEGORY2.Name = "CATEGORY2"
        Me.CATEGORY2.ReadOnly = True
        Me.CATEGORY2.Width = 130
        '
        'CATEGORY3
        '
        Me.CATEGORY3.DataPropertyName = "CATEGORY3"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CATEGORY3.DefaultCellStyle = DataGridViewCellStyle6
        Me.CATEGORY3.HeaderText = "           中分類           "
        Me.CATEGORY3.Name = "CATEGORY3"
        Me.CATEGORY3.ReadOnly = True
        Me.CATEGORY3.Width = 140
        '
        'THEME
        '
        Me.THEME.DataPropertyName = "THEME"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.THEME.DefaultCellStyle = DataGridViewCellStyle7
        Me.THEME.HeaderText = "         テーマ                "
        Me.THEME.Name = "THEME"
        Me.THEME.ReadOnly = True
        Me.THEME.Width = 123
        '
        'TESTCOUNT
        '
        Me.TESTCOUNT.DataPropertyName = "TESTCOUNT"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.NullValue = "10"
        Me.TESTCOUNT.DefaultCellStyle = DataGridViewCellStyle8
        Me.TESTCOUNT.HeaderText = "実施回"
        Me.TESTCOUNT.Name = "TESTCOUNT"
        Me.TESTCOUNT.ReadOnly = True
        Me.TESTCOUNT.Width = 53
        '
        'ERRATA
        '
        Me.ERRATA.DataPropertyName = "ERRATA_NUM"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "##0.0%"
        DataGridViewCellStyle9.NullValue = "100.0%"
        DataGridViewCellStyle9.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.ERRATA.DefaultCellStyle = DataGridViewCellStyle9
        Me.ERRATA.HeaderText = "正解率"
        Me.ERRATA.Name = "ERRATA"
        Me.ERRATA.ReadOnly = True
        Me.ERRATA.Width = 53
        '
        'SELECT1
        '
        Me.SELECT1.DataPropertyName = "SELECT1"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "##0.0%"
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SELECT1.DefaultCellStyle = DataGridViewCellStyle10
        Me.SELECT1.HeaderText = "   Ａ  "
        Me.SELECT1.Name = "SELECT1"
        Me.SELECT1.ReadOnly = True
        Me.SELECT1.Width = 45
        '
        'SELECT2
        '
        Me.SELECT2.DataPropertyName = "SELECT2"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "##0.0%"
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SELECT2.DefaultCellStyle = DataGridViewCellStyle11
        Me.SELECT2.HeaderText = "   Ｂ  "
        Me.SELECT2.Name = "SELECT2"
        Me.SELECT2.ReadOnly = True
        Me.SELECT2.Width = 45
        '
        'SELECT3
        '
        Me.SELECT3.DataPropertyName = "SELECT3"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "##0.0%"
        DataGridViewCellStyle12.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SELECT3.DefaultCellStyle = DataGridViewCellStyle12
        Me.SELECT3.HeaderText = "   Ｃ  "
        Me.SELECT3.Name = "SELECT3"
        Me.SELECT3.ReadOnly = True
        Me.SELECT3.Width = 45
        '
        'SELECT4
        '
        Me.SELECT4.DataPropertyName = "SELECT4"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "##0.0%"
        DataGridViewCellStyle13.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SELECT4.DefaultCellStyle = DataGridViewCellStyle13
        Me.SELECT4.HeaderText = "   Ｄ  "
        Me.SELECT4.Name = "SELECT4"
        Me.SELECT4.ReadOnly = True
        Me.SELECT4.Width = 45
        '
        'SELECT5
        '
        Me.SELECT5.DataPropertyName = "SELECT5"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "##0.0%"
        DataGridViewCellStyle14.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SELECT5.DefaultCellStyle = DataGridViewCellStyle14
        Me.SELECT5.HeaderText = "   Ｅ  "
        Me.SELECT5.Name = "SELECT5"
        Me.SELECT5.ReadOnly = True
        Me.SELECT5.Width = 45
        '
        'SELECTNULL
        '
        Me.SELECTNULL.DataPropertyName = "SELECTNULL"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "##0.0%"
        DataGridViewCellStyle15.NullValue = "100.0%"
        DataGridViewCellStyle15.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.SELECTNULL.DefaultCellStyle = DataGridViewCellStyle15
        Me.SELECTNULL.HeaderText = "未解答"
        Me.SELECTNULL.Name = "SELECTNULL"
        Me.SELECTNULL.ReadOnly = True
        Me.SELECTNULL.Width = 53
        '
        'frmSynthesisQuestionAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.dgvSynthesisQuestionAnalysis)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmSynthesisQuestionAnalysis"
        Me.Text = "総合テスト問別分析結果"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.dgvSynthesisQuestionAnalysis, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.pnlSearch, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvSynthesisQuestionAnalysis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvSynthesisQuestionAnalysis As System.Windows.Forms.DataGridView
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents sfdExcel As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents udtpEnd As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents udtpStart As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmbSection2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbSection1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbTestCount As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtManagementEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtTotalStart As System.Windows.Forms.TextBox
    Friend WithEvents txtManagementStart As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTechnologyEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtStrategyEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTechnologyStart As System.Windows.Forms.TextBox
    Friend WithEvents txtStrategyStart As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbGroupCode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGroupName As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbTestName As System.Windows.Forms.ComboBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents QUESTIONNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CATEGORY1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORY2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORY3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TESTCOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ERRATA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECT5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECTNULL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
