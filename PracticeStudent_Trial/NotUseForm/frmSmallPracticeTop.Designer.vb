<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmallPracticeTop
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdJhoken = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSaienshuPractice = New System.Windows.Forms.CheckBox()
        Me.pnlMiddlePracticeTop = New System.Windows.Forms.Panel()
        Me.chkMienshuPractice = New System.Windows.Forms.CheckBox()
        Me.chkKeisanPractice = New System.Windows.Forms.CheckBox()
        Me.chkChokkinPractice = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBackPracticeMenu = New System.Windows.Forms.Button()
        Me.btnSmallPracticeStart = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnAllChk = New System.Windows.Forms.Button()
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMiddlePracticeTop.SuspendLayout()
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 19)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "小問逐次演習"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(178, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(245, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "演習する分野・条件を指定してください。"
        '
        'grdJhoken
        '
        Me.grdJhoken.AllowUserToAddRows = False
        Me.grdJhoken.AllowUserToDeleteRows = False
        Me.grdJhoken.AllowUserToResizeColumns = False
        Me.grdJhoken.AllowUserToResizeRows = False
        Me.grdJhoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdJhoken.ColumnHeadersVisible = False
        Me.grdJhoken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column7, Me.Column3, Me.Column4, Me.Column5, Me.Column8})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdJhoken.DefaultCellStyle = DataGridViewCellStyle12
        Me.grdJhoken.EnableHeadersVisualStyles = False
        Me.grdJhoken.Location = New System.Drawing.Point(16, 182)
        Me.grdJhoken.Name = "grdJhoken"
        Me.grdJhoken.RowHeadersVisible = False
        Me.grdJhoken.RowTemplate.Height = 21
        Me.grdJhoken.Size = New System.Drawing.Size(740, 444)
        Me.grdJhoken.TabIndex = 2
        Me.grdJhoken.TabStop = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "分野選択"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column6.Width = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "分野"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "大分類"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.Width = 160
        '
        'Column7
        '
        Me.Column7.HeaderText = "中分類選択"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column7.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "中分類"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 210
        '
        'Column4
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(0, 0, 18, 0)
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column4.HeaderText = "正解率"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.Width = 70
        '
        'Column5
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(0, 0, 23, 0)
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column5.HeaderText = "問題網羅"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column5.Width = 70
        '
        'Column8
        '
        Me.Column8.HeaderText = "中分類ID"
        Me.Column8.Name = "Column8"
        Me.Column8.Visible = False
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 25)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "選択"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkSaienshuPractice
        '
        Me.chkSaienshuPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkSaienshuPractice.Location = New System.Drawing.Point(28, 109)
        Me.chkSaienshuPractice.Name = "chkSaienshuPractice"
        Me.chkSaienshuPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkSaienshuPractice.TabIndex = 5
        Me.chkSaienshuPractice.TabStop = False
        Me.chkSaienshuPractice.Text = "chkSaienshuPractice"
        Me.chkSaienshuPractice.UseVisualStyleBackColor = True
        '
        'pnlMiddlePracticeTop
        '
        Me.pnlMiddlePracticeTop.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlMiddlePracticeTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkMienshuPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkSaienshuPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkKeisanPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkChokkinPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label9)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label15)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label8)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label12)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label14)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label11)
        Me.pnlMiddlePracticeTop.Location = New System.Drawing.Point(795, 182)
        Me.pnlMiddlePracticeTop.Name = "pnlMiddlePracticeTop"
        Me.pnlMiddlePracticeTop.Size = New System.Drawing.Size(211, 196)
        Me.pnlMiddlePracticeTop.TabIndex = 48
        '
        'chkMienshuPractice
        '
        Me.chkMienshuPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkMienshuPractice.Location = New System.Drawing.Point(28, 156)
        Me.chkMienshuPractice.Name = "chkMienshuPractice"
        Me.chkMienshuPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkMienshuPractice.TabIndex = 6
        Me.chkMienshuPractice.TabStop = False
        Me.chkMienshuPractice.Text = "chkMienshuPractice"
        Me.chkMienshuPractice.UseVisualStyleBackColor = True
        '
        'chkKeisanPractice
        '
        Me.chkKeisanPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkKeisanPractice.Location = New System.Drawing.Point(28, 14)
        Me.chkKeisanPractice.Name = "chkKeisanPractice"
        Me.chkKeisanPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkKeisanPractice.TabIndex = 3
        Me.chkKeisanPractice.TabStop = False
        Me.chkKeisanPractice.Text = "chkChokkinPractice"
        Me.chkKeisanPractice.UseVisualStyleBackColor = True
        '
        'chkChokkinPractice
        '
        Me.chkChokkinPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkChokkinPractice.Location = New System.Drawing.Point(28, 63)
        Me.chkChokkinPractice.Name = "chkChokkinPractice"
        Me.chkChokkinPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkChokkinPractice.TabIndex = 4
        Me.chkChokkinPractice.TabStop = False
        Me.chkChokkinPractice.Text = "chkChokkinPractice"
        Me.chkChokkinPractice.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(65, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 15)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "未演習の問題"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(62, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "入れた問題"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(62, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 15)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = """再演習""にチェックを"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(62, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 15)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "計算問題を除く"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(62, 81)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 15)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "不正解となった問題"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(62, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 15)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "直近の出題時に"
        '
        'btnBackPracticeMenu
        '
        Me.btnBackPracticeMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackPracticeMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackPracticeMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackPracticeMenu.Name = "btnBackPracticeMenu"
        Me.btnBackPracticeMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackPracticeMenu.TabIndex = 8
        Me.btnBackPracticeMenu.Text = "問題演習メニューへ戻る"
        Me.btnBackPracticeMenu.UseVisualStyleBackColor = True
        '
        'btnSmallPracticeStart
        '
        Me.btnSmallPracticeStart.BackColor = System.Drawing.SystemColors.Control
        Me.btnSmallPracticeStart.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSmallPracticeStart.Location = New System.Drawing.Point(795, 518)
        Me.btnSmallPracticeStart.Name = "btnSmallPracticeStart"
        Me.btnSmallPracticeStart.Size = New System.Drawing.Size(211, 108)
        Me.btnSmallPracticeStart.TabIndex = 7
        Me.btnSmallPracticeStart.Text = "小問逐次演習開始"
        Me.btnSmallPracticeStart.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(824, 390)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(162, 15)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "※該当問題がない場合は"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(839, 405)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 15)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "出題されません"
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(67, 158)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 25)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "分野"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(177, 158)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(161, 25)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "大分類"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(337, 158)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(261, 25)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "中分類"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(597, 158)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 25)
        Me.Label21.TabIndex = 46
        Me.Label21.Text = "正解率"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(667, 158)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 25)
        Me.Label22.TabIndex = 46
        Me.Label22.Text = "問題網羅"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(16, 134)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(582, 25)
        Me.Label23.TabIndex = 46
        Me.Label23.Text = "分類"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.Location = New System.Drawing.Point(597, 134)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(141, 25)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "演習履歴"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAllChk
        '
        Me.btnAllChk.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllChk.Font = New System.Drawing.Font("MS UI Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAllChk.Location = New System.Drawing.Point(513, 161)
        Me.btnAllChk.Name = "btnAllChk"
        Me.btnAllChk.Size = New System.Drawing.Size(78, 20)
        Me.btnAllChk.TabIndex = 1
        Me.btnAllChk.UseVisualStyleBackColor = True
        '
        'frmSmallPracticeTop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnAllChk)
        Me.Controls.Add(Me.btnSmallPracticeStart)
        Me.Controls.Add(Me.btnBackPracticeMenu)
        Me.Controls.Add(Me.pnlMiddlePracticeTop)
        Me.Controls.Add(Me.grdJhoken)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmSmallPracticeTop"
        Me.Text = "frmSmallPracticeTop"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.grdJhoken, 0)
        Me.Controls.SetChildIndex(Me.pnlMiddlePracticeTop, 0)
        Me.Controls.SetChildIndex(Me.btnBackPracticeMenu, 0)
        Me.Controls.SetChildIndex(Me.btnSmallPracticeStart, 0)
        Me.Controls.SetChildIndex(Me.btnAllChk, 0)
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMiddlePracticeTop.ResumeLayout(False)
        Me.pnlMiddlePracticeTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grdJhoken As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkSaienshuPractice As System.Windows.Forms.CheckBox
    Friend WithEvents pnlMiddlePracticeTop As System.Windows.Forms.Panel
    Friend WithEvents chkMienshuPractice As System.Windows.Forms.CheckBox
    Friend WithEvents chkKeisanPractice As System.Windows.Forms.CheckBox
    Friend WithEvents chkChokkinPractice As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnBackPracticeMenu As System.Windows.Forms.Button
    Friend WithEvents btnSmallPracticeStart As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnAllChk As System.Windows.Forms.Button
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
