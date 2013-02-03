<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScoreAnalysis
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.udtpEnd = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.udtpStart = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.cmbPass = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmbSection2 = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbSection1 = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbInning = New System.Windows.Forms.ComboBox()
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
        Me.lblField2 = New System.Windows.Forms.Label()
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
        Me.lblField3 = New System.Windows.Forms.Label()
        Me.lblField1 = New System.Windows.Forms.Label()
        Me.ctpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.cmbGroup = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.grdResultList = New System.Windows.Forms.DataGridView()
        Me.CATEGORY1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORY2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AVEPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAXPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MINPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnQuestion = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.crtTotal = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.sfdExcel = New System.Windows.Forms.SaveFileDialog()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.lbl0 = New System.Windows.Forms.Label()
        Me.lbl110 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdResultList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.crtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 19)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "得点分析結果"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(27, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(104, 25)
        Me.Panel2.TabIndex = 45
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.udtpEnd)
        Me.Panel1.Controls.Add(Me.udtpStart)
        Me.Panel1.Controls.Add(Me.cmbPass)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.cmbSection2)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.cmbSection1)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.cmbInning)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.cmbCourse)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.txtTotalEnd)
        Me.Panel1.Controls.Add(Me.txtManagementEnd)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.txtTotalStart)
        Me.Panel1.Controls.Add(Me.txtManagementStart)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.lblField2)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txtTechnologyEnd)
        Me.Panel1.Controls.Add(Me.txtStrategyEnd)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtTechnologyStart)
        Me.Panel1.Controls.Add(Me.txtStrategyStart)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lblField3)
        Me.Panel1.Controls.Add(Me.lblField1)
        Me.Panel1.Controls.Add(Me.ctpEnd)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.dtpStart)
        Me.Panel1.Controls.Add(Me.cmbGroup)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(9, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 150)
        Me.Panel1.TabIndex = 15
        '
        'udtpEnd
        '
        Me.udtpEnd.IsNull = False
        Me.udtpEnd.Location = New System.Drawing.Point(318, 48)
        Me.udtpEnd.Name = "udtpEnd"
        Me.udtpEnd.Size = New System.Drawing.Size(143, 22)
        Me.udtpEnd.TabIndex = 7
        '
        'udtpStart
        '
        Me.udtpStart.IsNull = False
        Me.udtpStart.Location = New System.Drawing.Point(136, 48)
        Me.udtpStart.Name = "udtpStart"
        Me.udtpStart.Size = New System.Drawing.Size(143, 22)
        Me.udtpStart.TabIndex = 6
        '
        'cmbPass
        '
        Me.cmbPass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPass.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbPass.FormattingEnabled = True
        Me.cmbPass.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbPass.Location = New System.Drawing.Point(555, 49)
        Me.cmbPass.Name = "cmbPass"
        Me.cmbPass.Size = New System.Drawing.Size(121, 23)
        Me.cmbPass.TabIndex = 8
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label35.Location = New System.Drawing.Point(487, 52)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 15)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "【合否】"
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
        Me.cmbSection2.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbSection2.Location = New System.Drawing.Point(918, 16)
        Me.cmbSection2.Name = "cmbSection2"
        Me.cmbSection2.Size = New System.Drawing.Size(48, 23)
        Me.cmbSection2.TabIndex = 5
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
        Me.cmbSection1.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbSection1.Location = New System.Drawing.Point(809, 16)
        Me.cmbSection1.Name = "cmbSection1"
        Me.cmbSection1.Size = New System.Drawing.Size(48, 23)
        Me.cmbSection1.TabIndex = 4
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
        'cmbInning
        '
        Me.cmbInning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInning.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbInning.FormattingEnabled = True
        Me.cmbInning.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbInning.Location = New System.Drawing.Point(555, 16)
        Me.cmbInning.Name = "cmbInning"
        Me.cmbInning.Size = New System.Drawing.Size(121, 23)
        Me.cmbInning.TabIndex = 3
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label29.Location = New System.Drawing.Point(487, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(68, 15)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "【受験回】"
        '
        'cmbCourse
        '
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbCourse.Location = New System.Drawing.Point(352, 16)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(121, 23)
        Me.cmbCourse.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(278, 19)
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
        Me.btnSearch.TabIndex = 17
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
        Me.Label22.Text = "点以下"
        '
        'txtTotalEnd
        '
        Me.txtTotalEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTotalEnd.Location = New System.Drawing.Point(744, 119)
        Me.txtTotalEnd.MaxLength = 4
        Me.txtTotalEnd.Name = "txtTotalEnd"
        Me.txtTotalEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtTotalEnd.TabIndex = 16
        Me.txtTotalEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManagementEnd
        '
        Me.txtManagementEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtManagementEnd.Location = New System.Drawing.Point(744, 84)
        Me.txtManagementEnd.MaxLength = 4
        Me.txtManagementEnd.Name = "txtManagementEnd"
        Me.txtManagementEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtManagementEnd.TabIndex = 12
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
        Me.Label24.Text = "点以下"
        '
        'txtTotalStart
        '
        Me.txtTotalStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTotalStart.Location = New System.Drawing.Point(617, 119)
        Me.txtTotalStart.MaxLength = 4
        Me.txtTotalStart.Name = "txtTotalStart"
        Me.txtTotalStart.Size = New System.Drawing.Size(41, 22)
        Me.txtTotalStart.TabIndex = 15
        Me.txtTotalStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtManagementStart
        '
        Me.txtManagementStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtManagementStart.Location = New System.Drawing.Point(617, 84)
        Me.txtManagementStart.MaxLength = 4
        Me.txtManagementStart.Name = "txtManagementStart"
        Me.txtManagementStart.Size = New System.Drawing.Size(41, 22)
        Me.txtManagementStart.TabIndex = 11
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
        Me.Label26.Text = "点以上"
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
        Me.Label28.Text = "点以上"
        '
        'lblField2
        '
        Me.lblField2.AutoSize = True
        Me.lblField2.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lblField2.Location = New System.Drawing.Point(526, 87)
        Me.lblField2.Name = "lblField2"
        Me.lblField2.Size = New System.Drawing.Size(89, 15)
        Me.lblField2.TabIndex = 65
        Me.lblField2.Text = "マネジメント系"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label20.Location = New System.Drawing.Point(391, 122)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 15)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "点以下"
        '
        'txtTechnologyEnd
        '
        Me.txtTechnologyEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTechnologyEnd.Location = New System.Drawing.Point(344, 119)
        Me.txtTechnologyEnd.MaxLength = 4
        Me.txtTechnologyEnd.Name = "txtTechnologyEnd"
        Me.txtTechnologyEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtTechnologyEnd.TabIndex = 14
        Me.txtTechnologyEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStrategyEnd
        '
        Me.txtStrategyEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStrategyEnd.Location = New System.Drawing.Point(344, 84)
        Me.txtStrategyEnd.MaxLength = 4
        Me.txtStrategyEnd.Name = "txtStrategyEnd"
        Me.txtStrategyEnd.Size = New System.Drawing.Size(41, 22)
        Me.txtStrategyEnd.TabIndex = 10
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
        Me.Label23.Text = "点以下"
        '
        'txtTechnologyStart
        '
        Me.txtTechnologyStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTechnologyStart.Location = New System.Drawing.Point(217, 119)
        Me.txtTechnologyStart.MaxLength = 4
        Me.txtTechnologyStart.Name = "txtTechnologyStart"
        Me.txtTechnologyStart.Size = New System.Drawing.Size(41, 22)
        Me.txtTechnologyStart.TabIndex = 13
        Me.txtTechnologyStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStrategyStart
        '
        Me.txtStrategyStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStrategyStart.Location = New System.Drawing.Point(217, 84)
        Me.txtStrategyStart.MaxLength = 4
        Me.txtStrategyStart.Name = "txtStrategyStart"
        Me.txtStrategyStart.Size = New System.Drawing.Size(41, 22)
        Me.txtStrategyStart.TabIndex = 9
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
        Me.Label18.Text = "点以上"
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
        Me.Label16.Text = "総合評価点"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label15.Location = New System.Drawing.Point(263, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 15)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "点以上"
        '
        'lblField3
        '
        Me.lblField3.AutoSize = True
        Me.lblField3.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lblField3.Location = New System.Drawing.Point(134, 122)
        Me.lblField3.Name = "lblField3"
        Me.lblField3.Size = New System.Drawing.Size(76, 15)
        Me.lblField3.TabIndex = 50
        Me.lblField3.Text = "テクノロジ系"
        '
        'lblField1
        '
        Me.lblField1.AutoSize = True
        Me.lblField1.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lblField1.Location = New System.Drawing.Point(134, 87)
        Me.lblField1.Name = "lblField1"
        Me.lblField1.Size = New System.Drawing.Size(77, 15)
        Me.lblField1.TabIndex = 49
        Me.lblField1.Text = "ストラテジ系"
        '
        'ctpEnd
        '
        Me.ctpEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ctpEnd.Location = New System.Drawing.Point(318, 48)
        Me.ctpEnd.Name = "ctpEnd"
        Me.ctpEnd.Size = New System.Drawing.Size(143, 22)
        Me.ctpEnd.TabIndex = 48
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label12.Location = New System.Drawing.Point(290, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 15)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "～"
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dtpStart.Location = New System.Drawing.Point(137, 48)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(143, 22)
        Me.dtpStart.TabIndex = 46
        '
        'cmbGroup
        '
        Me.cmbGroup.DisplayMember = "GROUPNAME"
        Me.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroup.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroup.FormattingEnabled = True
        Me.cmbGroup.Items.AddRange(New Object() {"Ａ大学"})
        Me.cmbGroup.Location = New System.Drawing.Point(137, 16)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(121, 23)
        Me.cmbGroup.TabIndex = 1
        Me.cmbGroup.ValueMember = "GROUPCODE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(51, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 15)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "【得点】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(51, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "【受験日】"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(51, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "【団体名】"
        '
        'Label54
        '
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label54.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label54.Location = New System.Drawing.Point(574, 397)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(1, 210)
        Me.Label54.TabIndex = 124
        '
        'Label53
        '
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label53.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label53.Location = New System.Drawing.Point(483, 397)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(1, 210)
        Me.Label53.TabIndex = 123
        '
        'Label52
        '
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label52.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label52.Location = New System.Drawing.Point(393, 397)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(1, 210)
        Me.Label52.TabIndex = 122
        '
        'Label48
        '
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label48.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label48.Location = New System.Drawing.Point(303, 397)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(1, 210)
        Me.Label48.TabIndex = 118
        '
        'Label45
        '
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label45.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label45.Location = New System.Drawing.Point(44, 585)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(530, 1)
        Me.Label45.TabIndex = 117
        '
        'Label47
        '
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label47.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label47.Location = New System.Drawing.Point(143, 397)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(1, 189)
        Me.Label47.TabIndex = 115
        '
        'Label41
        '
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label41.Location = New System.Drawing.Point(145, 501)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(430, 1)
        Me.Label41.TabIndex = 114
        '
        'Label42
        '
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label42.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label42.Location = New System.Drawing.Point(44, 522)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(530, 1)
        Me.Label42.TabIndex = 113
        '
        'Label43
        '
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label43.Location = New System.Drawing.Point(145, 543)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(430, 1)
        Me.Label43.TabIndex = 112
        '
        'Label44
        '
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label44.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label44.Location = New System.Drawing.Point(145, 564)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(430, 1)
        Me.Label44.TabIndex = 111
        '
        'Label39
        '
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label39.Location = New System.Drawing.Point(44, 459)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(530, 1)
        Me.Label39.TabIndex = 110
        '
        'Label40
        '
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label40.Location = New System.Drawing.Point(145, 480)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(430, 1)
        Me.Label40.TabIndex = 109
        '
        'Label38
        '
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label38.Location = New System.Drawing.Point(145, 438)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(430, 1)
        Me.Label38.TabIndex = 108
        '
        'Label37
        '
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label37.Location = New System.Drawing.Point(145, 417)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(430, 1)
        Me.Label37.TabIndex = 107
        '
        'grdResultList
        '
        Me.grdResultList.AllowUserToAddRows = False
        Me.grdResultList.AllowUserToResizeColumns = False
        Me.grdResultList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdResultList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdResultList.ColumnHeadersHeight = 22
        Me.grdResultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdResultList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CATEGORY1, Me.CATEGORY2, Me.AVEPER, Me.MAXPER, Me.MINPER, Me.CATEGORYID})
        Me.grdResultList.EnableHeadersVisualStyles = False
        Me.grdResultList.Location = New System.Drawing.Point(43, 374)
        Me.grdResultList.Name = "grdResultList"
        Me.grdResultList.RowHeadersVisible = False
        Me.grdResultList.RowTemplate.Height = 21
        Me.grdResultList.Size = New System.Drawing.Size(533, 235)
        Me.grdResultList.TabIndex = 106
        Me.grdResultList.TabStop = False
        '
        'CATEGORY1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.CATEGORY1.DefaultCellStyle = DataGridViewCellStyle2
        Me.CATEGORY1.HeaderText = "分野"
        Me.CATEGORY1.Name = "CATEGORY1"
        '
        'CATEGORY2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.CATEGORY2.DefaultCellStyle = DataGridViewCellStyle3
        Me.CATEGORY2.HeaderText = "大分類"
        Me.CATEGORY2.Name = "CATEGORY2"
        Me.CATEGORY2.Width = 160
        '
        'AVEPER
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.AVEPER.DefaultCellStyle = DataGridViewCellStyle4
        Me.AVEPER.HeaderText = "平均正解率"
        Me.AVEPER.Name = "AVEPER"
        Me.AVEPER.Width = 90
        '
        'MAXPER
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.MAXPER.DefaultCellStyle = DataGridViewCellStyle5
        Me.MAXPER.HeaderText = "最高正解率"
        Me.MAXPER.Name = "MAXPER"
        Me.MAXPER.Width = 90
        '
        'MINPER
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 0, 30, 0)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.MINPER.DefaultCellStyle = DataGridViewCellStyle6
        Me.MINPER.HeaderText = "最低正解率"
        Me.MINPER.Name = "MINPER"
        Me.MINPER.Width = 90
        '
        'CATEGORYID
        '
        Me.CATEGORYID.HeaderText = "CATEGORYID"
        Me.CATEGORYID.Name = "CATEGORYID"
        Me.CATEGORYID.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label32.Location = New System.Drawing.Point(25, 356)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(113, 15)
        Me.Label32.TabIndex = 125
        Me.Label32.Text = "〔分野別正解率〕"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSave.Location = New System.Drawing.Point(923, 617)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 30)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnQuestion
        '
        Me.btnQuestion.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnQuestion.Location = New System.Drawing.Point(822, 663)
        Me.btnQuestion.Name = "btnQuestion"
        Me.btnQuestion.Size = New System.Drawing.Size(191, 30)
        Me.btnQuestion.TabIndex = 19
        Me.btnQuestion.Text = "テスト結果メニューへ戻る"
        Me.btnQuestion.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(821, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(191, 30)
        Me.btnBack.TabIndex = 20
        Me.btnBack.Text = "管理者メインメニューへ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label33.Location = New System.Drawing.Point(592, 321)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 15)
        Me.Label33.TabIndex = 131
        Me.Label33.Text = "〔総合評価分布〕"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label36.Location = New System.Drawing.Point(25, 322)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(83, 15)
        Me.Label36.TabIndex = 133
        Me.Label36.Text = "〔対象人数〕"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(131, 318)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(100, 22)
        Me.lblTotal.TabIndex = 134
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'crtTotal
        '
        ChartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal
        ChartArea1.AxisX.Title = "正解率（％）"
        ChartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        ChartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked
        ChartArea1.AxisY.Title = "人数"
        ChartArea1.Name = "ChartArea1"
        Me.crtTotal.ChartAreas.Add(ChartArea1)
        Me.crtTotal.Location = New System.Drawing.Point(595, 345)
        Me.crtTotal.Name = "crtTotal"
        Series1.ChartArea = "ChartArea1"
        Series1.IsVisibleInLegend = False
        Series1.Name = "Series1"
        Me.crtTotal.Series.Add(Series1)
        Me.crtTotal.Size = New System.Drawing.Size(405, 265)
        Me.crtTotal.TabIndex = 135
        Me.crtTotal.TabStop = False
        Me.crtTotal.Text = "chrTotal"
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(321, 12)
        Me.lblTree.TabIndex = 179
        Me.lblTree.Text = "管理者メインメニュー ＞ 試験結果分析メニュー ＞ 得点分析結果" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTree.Visible = False
        '
        'lbl0
        '
        Me.lbl0.BackColor = System.Drawing.Color.White
        Me.lbl0.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lbl0.Location = New System.Drawing.Point(645, 559)
        Me.lbl0.Name = "lbl0"
        Me.lbl0.Size = New System.Drawing.Size(27, 20)
        Me.lbl0.TabIndex = 180
        '
        'lbl110
        '
        Me.lbl110.BackColor = System.Drawing.Color.White
        Me.lbl110.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lbl110.Location = New System.Drawing.Point(966, 558)
        Me.lbl110.Name = "lbl110"
        Me.lbl110.Size = New System.Drawing.Size(20, 20)
        Me.lbl110.TabIndex = 181
        '
        'frmScoreAnalysis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lbl110)
        Me.Controls.Add(Me.lbl0)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.crtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.btnQuestion)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.grdResultList)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmScoreAnalysis"
        Me.Text = "得点分析結果画面"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.grdResultList, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.Label44, 0)
        Me.Controls.SetChildIndex(Me.Label43, 0)
        Me.Controls.SetChildIndex(Me.Label42, 0)
        Me.Controls.SetChildIndex(Me.Label41, 0)
        Me.Controls.SetChildIndex(Me.Label47, 0)
        Me.Controls.SetChildIndex(Me.Label45, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.Label52, 0)
        Me.Controls.SetChildIndex(Me.Label53, 0)
        Me.Controls.SetChildIndex(Me.Label54, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.btnQuestion, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.lblTotal, 0)
        Me.Controls.SetChildIndex(Me.crtTotal, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.lbl0, 0)
        Me.Controls.SetChildIndex(Me.lbl110, 0)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdResultList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.crtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbPass As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmbSection2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbSection1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbInning As System.Windows.Forms.ComboBox
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
    Friend WithEvents lblField2 As System.Windows.Forms.Label
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
    Friend WithEvents lblField3 As System.Windows.Forms.Label
    Friend WithEvents lblField1 As System.Windows.Forms.Label
    Friend WithEvents ctpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents grdResultList As System.Windows.Forms.DataGridView
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnQuestion As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents udtpEnd As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents udtpStart As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents crtTotal As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents sfdExcel As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents lbl0 As System.Windows.Forms.Label
    Friend WithEvents lbl110 As System.Windows.Forms.Label
    Friend WithEvents CATEGORY1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORY2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AVEPER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAXPER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MINPER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
