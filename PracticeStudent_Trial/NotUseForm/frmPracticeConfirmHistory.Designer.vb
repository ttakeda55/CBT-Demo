<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPracticeConfirmHistory
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnBackHistoryMenu = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelHeader8 = New System.Windows.Forms.Label()
        Me.LabelHeader7 = New System.Windows.Forms.Label()
        Me.LabelHeader6 = New System.Windows.Forms.Label()
        Me.LabelHeader5 = New System.Windows.Forms.Label()
        Me.LabelHeader4 = New System.Windows.Forms.Label()
        Me.LabelHeader3 = New System.Windows.Forms.Label()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.LabelHeader2 = New System.Windows.Forms.Label()
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.grdJhoken = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblSeiRit = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblSeiSuu = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPraMonSuu = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblKaisu = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
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
        'btnBackHistoryMenu
        '
        Me.btnBackHistoryMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackHistoryMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackHistoryMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackHistoryMenu.Name = "btnBackHistoryMenu"
        Me.btnBackHistoryMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackHistoryMenu.TabIndex = 2
        Me.btnBackHistoryMenu.Text = "履歴確認メニューへ戻る"
        Me.btnBackHistoryMenu.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(52, 128)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 25)
        Me.Panel1.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 15)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "〔小問〕"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LabelHeader8)
        Me.Panel2.Controls.Add(Me.LabelHeader7)
        Me.Panel2.Controls.Add(Me.LabelHeader6)
        Me.Panel2.Controls.Add(Me.LabelHeader5)
        Me.Panel2.Controls.Add(Me.LabelHeader4)
        Me.Panel2.Controls.Add(Me.LabelHeader3)
        Me.Panel2.Controls.Add(Me.LabelLine)
        Me.Panel2.Controls.Add(Me.LabelHeader2)
        Me.Panel2.Controls.Add(Me.LabelHeader1)
        Me.Panel2.Controls.Add(Me.grdJhoken)
        Me.Panel2.Location = New System.Drawing.Point(32, 140)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(955, 350)
        Me.Panel2.TabIndex = 63
        '
        'LabelHeader8
        '
        Me.LabelHeader8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader8.Location = New System.Drawing.Point(816, 37)
        Me.LabelHeader8.Name = "LabelHeader8"
        Me.LabelHeader8.Size = New System.Drawing.Size(88, 13)
        Me.LabelHeader8.TabIndex = 79
        Me.LabelHeader8.Text = "正解率"
        Me.LabelHeader8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelHeader7
        '
        Me.LabelHeader7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader7.Location = New System.Drawing.Point(727, 37)
        Me.LabelHeader7.Name = "LabelHeader7"
        Me.LabelHeader7.Size = New System.Drawing.Size(88, 13)
        Me.LabelHeader7.TabIndex = 79
        Me.LabelHeader7.Text = "正解数"
        Me.LabelHeader7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelHeader6
        '
        Me.LabelHeader6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader6.Location = New System.Drawing.Point(637, 37)
        Me.LabelHeader6.Name = "LabelHeader6"
        Me.LabelHeader6.Size = New System.Drawing.Size(88, 13)
        Me.LabelHeader6.TabIndex = 79
        Me.LabelHeader6.Text = "演習問題数"
        Me.LabelHeader6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelHeader5
        '
        Me.LabelHeader5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader5.Location = New System.Drawing.Point(434, 37)
        Me.LabelHeader5.Name = "LabelHeader5"
        Me.LabelHeader5.Size = New System.Drawing.Size(144, 13)
        Me.LabelHeader5.TabIndex = 79
        Me.LabelHeader5.Text = "中分類"
        Me.LabelHeader5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelHeader4
        '
        Me.LabelHeader4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader4.Location = New System.Drawing.Point(206, 37)
        Me.LabelHeader4.Name = "LabelHeader4"
        Me.LabelHeader4.Size = New System.Drawing.Size(144, 13)
        Me.LabelHeader4.TabIndex = 79
        Me.LabelHeader4.Text = "大分類"
        Me.LabelHeader4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelHeader3
        '
        Me.LabelHeader3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader3.Location = New System.Drawing.Point(31, 37)
        Me.LabelHeader3.Name = "LabelHeader3"
        Me.LabelHeader3.Size = New System.Drawing.Size(144, 13)
        Me.LabelHeader3.TabIndex = 79
        Me.LabelHeader3.Text = "分野"
        Me.LabelHeader3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelLine
        '
        Me.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLine.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelLine.Location = New System.Drawing.Point(30, 34)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(875, 1)
        Me.LabelLine.TabIndex = 71
        '
        'LabelHeader2
        '
        Me.LabelHeader2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader2.Location = New System.Drawing.Point(637, 20)
        Me.LabelHeader2.Name = "LabelHeader2"
        Me.LabelHeader2.Size = New System.Drawing.Size(267, 14)
        Me.LabelHeader2.TabIndex = 79
        Me.LabelHeader2.Text = "                           演習履歴"
        Me.LabelHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelHeader1
        '
        Me.LabelHeader1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader1.Location = New System.Drawing.Point(32, 20)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(600, 14)
        Me.LabelHeader1.TabIndex = 79
        Me.LabelHeader1.Text = "     　　　　　　　　　                                               　分類"
        Me.LabelHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdJhoken
        '
        Me.grdJhoken.AllowUserToAddRows = False
        Me.grdJhoken.AllowUserToDeleteRows = False
        Me.grdJhoken.AllowUserToResizeColumns = False
        Me.grdJhoken.AllowUserToResizeRows = False
        Me.grdJhoken.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdJhoken.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdJhoken.ColumnHeadersHeight = 34
        Me.grdJhoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdJhoken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column6, Me.Column4})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdJhoken.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdJhoken.EnableHeadersVisualStyles = False
        Me.grdJhoken.Location = New System.Drawing.Point(28, 18)
        Me.grdJhoken.Name = "grdJhoken"
        Me.grdJhoken.RowHeadersVisible = False
        Me.grdJhoken.RowTemplate.Height = 21
        Me.grdJhoken.Size = New System.Drawing.Size(896, 309)
        Me.grdJhoken.TabIndex = 1
        Me.grdJhoken.TabStop = False
        '
        'Column1
        '
        Me.Column1.FillWeight = 146.0!
        Me.Column1.HeaderText = ""
        Me.Column1.MinimumWidth = 146
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Width = 146
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.Width = 260
        '
        'Column5
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(0, 0, 27, 0)
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column5.FillWeight = 90.0!
        Me.Column5.HeaderText = ""
        Me.Column5.MinimumWidth = 90
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.Width = 90
        '
        'Column6
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(0, 0, 27, 0)
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.Width = 90
        '
        'Column4
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Padding = New System.Windows.Forms.Padding(0, 0, 27, 0)
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.Width = 90
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblSeiRit)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.lblSeiSuu)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.lblPraMonSuu)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(32, 513)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(955, 57)
        Me.Panel3.TabIndex = 65
        '
        'lblSeiRit
        '
        Me.lblSeiRit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSeiRit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSeiRit.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSeiRit.Location = New System.Drawing.Point(685, 20)
        Me.lblSeiRit.Name = "lblSeiRit"
        Me.lblSeiRit.Size = New System.Drawing.Size(107, 25)
        Me.lblSeiRit.TabIndex = 62
        Me.lblSeiRit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(575, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 25)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "正解率"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeiSuu
        '
        Me.lblSeiSuu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSeiSuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSeiSuu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSeiSuu.Location = New System.Drawing.Point(469, 20)
        Me.lblSeiSuu.Name = "lblSeiSuu"
        Me.lblSeiSuu.Size = New System.Drawing.Size(107, 25)
        Me.lblSeiSuu.TabIndex = 60
        Me.lblSeiSuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(359, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 25)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "正解数"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPraMonSuu
        '
        Me.lblPraMonSuu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPraMonSuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPraMonSuu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPraMonSuu.Location = New System.Drawing.Point(138, 20)
        Me.lblPraMonSuu.Name = "lblPraMonSuu"
        Me.lblPraMonSuu.Size = New System.Drawing.Size(222, 25)
        Me.lblPraMonSuu.TabIndex = 58
        Me.lblPraMonSuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 25)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "演習問題数"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(52, 501)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(100, 25)
        Me.Panel4.TabIndex = 66
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "〔中問〕"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(169, 19)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "逐次演習履歴確認"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(292, 603)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 19)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "回"
        '
        'lblKaisu
        '
        Me.lblKaisu.BackColor = System.Drawing.Color.White
        Me.lblKaisu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKaisu.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKaisu.Location = New System.Drawing.Point(163, 585)
        Me.lblKaisu.Name = "lblKaisu"
        Me.lblKaisu.Size = New System.Drawing.Size(120, 54)
        Me.lblKaisu.TabIndex = 69
        Me.lblKaisu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(48, 603)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 19)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "【演習回数】"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(365, 603)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 19)
        Me.Label15.TabIndex = 68
        Me.Label15.Text = "【演習時間】"
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.Color.White
        Me.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTime.Font = New System.Drawing.Font("MS UI Gothic", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime.Location = New System.Drawing.Point(480, 585)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(120, 54)
        Me.lblTime.TabIndex = 69
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(609, 603)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 19)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "分"
        '
        'frmPracticeConfirmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblKaisu)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnBackHistoryMenu)
        Me.Name = "frmPracticeConfirmHistory"
        Me.Text = "frmPracticeConfirmHistory"
        Me.Controls.SetChildIndex(Me.btnBackHistoryMenu, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.lblKaisu, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.lblTime, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBackHistoryMenu As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSeiRit As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblSeiSuu As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPraMonSuu As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdJhoken As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblKaisu As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader1 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader2 As System.Windows.Forms.Label
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents LabelHeader8 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader7 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader6 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader5 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader4 As System.Windows.Forms.Label
    Friend WithEvents LabelHeader3 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
