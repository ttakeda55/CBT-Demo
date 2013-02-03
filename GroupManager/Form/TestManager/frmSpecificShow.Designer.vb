<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecificShow
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTestName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvPracticeQuestionList = New System.Windows.Forms.DataGridView()
        Me.QUESTIONNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONCODE = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.CATEGORYNAME1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.THEME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LEVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnTestNameEdit = New System.Windows.Forms.Button()
        Me.mskTestEnd_DateTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mskTestStart_DateTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnWord = New System.Windows.Forms.Button()
        Me.ChkQ = New System.Windows.Forms.CheckBox()
        Me.ChkT = New System.Windows.Forms.CheckBox()
        Me.BtnSrcS = New System.Windows.Forms.Button()
        Me.btnSrcQ = New System.Windows.Forms.Button()
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(535, 12)
        Me.lblTree.TabIndex = 203
        Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 指定テスト管理 ＞ 指定テスト作成 ＞ 指定テスト登録確認"
        Me.lblTree.Visible = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 125)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(135, 19)
        Me.lblTitle.TabIndex = 217
        Me.lblTitle.Text = "テスト登録確認"
        '
        'txtTestName
        '
        Me.txtTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTestName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtTestName.Location = New System.Drawing.Point(123, 158)
        Me.txtTestName.MaxLength = 100
        Me.txtTestName.Name = "txtTestName"
        Me.txtTestName.Size = New System.Drawing.Size(444, 22)
        Me.txtTestName.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(31, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 219
        Me.Label8.Text = "【テスト名】"
        '
        'dgvPracticeQuestionList
        '
        Me.dgvPracticeQuestionList.AllowUserToAddRows = False
        Me.dgvPracticeQuestionList.AllowUserToDeleteRows = False
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
        Me.dgvPracticeQuestionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONNO, Me.CATEGORYID, Me.QUESTIONCODE, Me.CATEGORYNAME1, Me.CATEGORYNAME2, Me.CATEGORYNAME3, Me.THEME, Me.CATEGORYNAME4, Me.FORMAT, Me.LEVEL, Me.QUESTIONTYPE})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPracticeQuestionList.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPracticeQuestionList.EnableHeadersVisualStyles = False
        Me.dgvPracticeQuestionList.Location = New System.Drawing.Point(34, 189)
        Me.dgvPracticeQuestionList.Name = "dgvPracticeQuestionList"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPracticeQuestionList.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPracticeQuestionList.RowHeadersVisible = False
        Me.dgvPracticeQuestionList.RowTemplate.Height = 21
        Me.dgvPracticeQuestionList.Size = New System.Drawing.Size(950, 414)
        Me.dgvPracticeQuestionList.TabIndex = 30
        '
        'QUESTIONNO
        '
        Me.QUESTIONNO.DataPropertyName = "QUESTIONNO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.QUESTIONNO.DefaultCellStyle = DataGridViewCellStyle2
        Me.QUESTIONNO.Frozen = True
        Me.QUESTIONNO.HeaderText = "問番号"
        Me.QUESTIONNO.MaxInputLength = 3
        Me.QUESTIONNO.Name = "QUESTIONNO"
        Me.QUESTIONNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QUESTIONNO.Width = 70
        '
        'CATEGORYID
        '
        Me.CATEGORYID.DataPropertyName = "CATEGORYID"
        Me.CATEGORYID.Frozen = True
        Me.CATEGORYID.HeaderText = "グループID"
        Me.CATEGORYID.Name = "CATEGORYID"
        Me.CATEGORYID.Visible = False
        '
        'QUESTIONCODE
        '
        Me.QUESTIONCODE.DataPropertyName = "QUESTIONCODE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QUESTIONCODE.DefaultCellStyle = DataGridViewCellStyle3
        Me.QUESTIONCODE.Frozen = True
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
        Me.CATEGORYNAME1.DefaultCellStyle = DataGridViewCellStyle4
        Me.CATEGORYNAME1.Frozen = True
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
        Me.CATEGORYNAME2.DefaultCellStyle = DataGridViewCellStyle5
        Me.CATEGORYNAME2.Frozen = True
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
        Me.CATEGORYNAME3.DefaultCellStyle = DataGridViewCellStyle6
        Me.CATEGORYNAME3.Frozen = True
        Me.CATEGORYNAME3.HeaderText = "小項目"
        Me.CATEGORYNAME3.Name = "CATEGORYNAME3"
        Me.CATEGORYNAME3.ReadOnly = True
        Me.CATEGORYNAME3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME3.Visible = False
        Me.CATEGORYNAME3.Width = 150
        '
        'THEME
        '
        Me.THEME.DataPropertyName = "THEME"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.NullValue = "ブレーンストーミングのルール"
        Me.THEME.DefaultCellStyle = DataGridViewCellStyle7
        Me.THEME.Frozen = True
        Me.THEME.HeaderText = "キーワード"
        Me.THEME.Name = "THEME"
        Me.THEME.ReadOnly = True
        Me.THEME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.THEME.Width = 320
        '
        'CATEGORYNAME4
        '
        Me.CATEGORYNAME4.DataPropertyName = "CATEGORYNAME4"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.Format = "d"
        Me.CATEGORYNAME4.DefaultCellStyle = DataGridViewCellStyle8
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FORMAT.DefaultCellStyle = DataGridViewCellStyle9
        Me.FORMAT.Frozen = True
        Me.FORMAT.HeaderText = "属性"
        Me.FORMAT.Name = "FORMAT"
        Me.FORMAT.ReadOnly = True
        Me.FORMAT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FORMAT.Visible = False
        Me.FORMAT.Width = 80
        '
        'LEVEL
        '
        Me.LEVEL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LEVEL.DataPropertyName = "LEVEL_STR"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LEVEL.DefaultCellStyle = DataGridViewCellStyle10
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
        Me.QUESTIONTYPE.Visible = False
        Me.QUESTIONTYPE.Width = 80
        '
        'LabelLine
        '
        Me.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelLine.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.LabelLine.Location = New System.Drawing.Point(206, 204)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(449, 1)
        Me.LabelLine.TabIndex = 223
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader.Location = New System.Drawing.Point(208, 191)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(445, 15)
        Me.LabelHeader.TabIndex = 222
        Me.LabelHeader.Text = "分類"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBack.Location = New System.Drawing.Point(886, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(120, 30)
        Me.btnBack.TabIndex = 50
        Me.btnBack.Text = "戻　る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnCancel.Location = New System.Drawing.Point(886, 614)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 30)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnAdd.Location = New System.Drawing.Point(746, 614)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 30)
        Me.btnAdd.TabIndex = 40
        Me.btnAdd.Text = "修　正"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnTestNameEdit
        '
        Me.btnTestNameEdit.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnTestNameEdit.Location = New System.Drawing.Point(573, 153)
        Me.btnTestNameEdit.Name = "btnTestNameEdit"
        Me.btnTestNameEdit.Size = New System.Drawing.Size(140, 30)
        Me.btnTestNameEdit.TabIndex = 20
        Me.btnTestNameEdit.Text = "テスト名変更"
        Me.btnTestNameEdit.UseVisualStyleBackColor = True
        '
        'mskTestEnd_DateTime
        '
        Me.mskTestEnd_DateTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mskTestEnd_DateTime.Location = New System.Drawing.Point(478, 121)
        Me.mskTestEnd_DateTime.Mask = "0000年00月00日00時00分"
        Me.mskTestEnd_DateTime.Name = "mskTestEnd_DateTime"
        Me.mskTestEnd_DateTime.Size = New System.Drawing.Size(187, 23)
        Me.mskTestEnd_DateTime.TabIndex = 229
        Me.mskTestEnd_DateTime.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(441, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 231
        Me.Label6.Text = "～"
        Me.Label6.Visible = False
        '
        'mskTestStart_DateTime
        '
        Me.mskTestStart_DateTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mskTestStart_DateTime.Location = New System.Drawing.Point(240, 122)
        Me.mskTestStart_DateTime.Mask = "0000年00月00日00時00分"
        Me.mskTestStart_DateTime.Name = "mskTestStart_DateTime"
        Me.mskTestStart_DateTime.Size = New System.Drawing.Size(187, 23)
        Me.mskTestStart_DateTime.TabIndex = 228
        Me.mskTestStart_DateTime.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label14.Location = New System.Drawing.Point(151, 126)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 15)
        Me.Label14.TabIndex = 230
        Me.Label14.Text = "【試験期間】"
        Me.Label14.Visible = False
        '
        'btnWord
        '
        Me.btnWord.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnWord.Location = New System.Drawing.Point(573, 614)
        Me.btnWord.Name = "btnWord"
        Me.btnWord.Size = New System.Drawing.Size(154, 30)
        Me.btnWord.TabIndex = 232
        Me.btnWord.Text = "WORDファイル出力"
        Me.btnWord.UseVisualStyleBackColor = True
        '
        'ChkQ
        '
        Me.ChkQ.AutoSize = True
        Me.ChkQ.Location = New System.Drawing.Point(373, 621)
        Me.ChkQ.Name = "ChkQ"
        Me.ChkQ.Size = New System.Drawing.Size(95, 16)
        Me.ChkQ.TabIndex = 233
        Me.ChkQ.Text = "問題コード有り"
        Me.ChkQ.UseVisualStyleBackColor = True
        '
        'ChkT
        '
        Me.ChkT.AutoSize = True
        Me.ChkT.Location = New System.Drawing.Point(487, 621)
        Me.ChkT.Name = "ChkT"
        Me.ChkT.Size = New System.Drawing.Size(68, 16)
        Me.ChkT.TabIndex = 234
        Me.ChkT.Text = "正解有り"
        Me.ChkT.UseVisualStyleBackColor = True
        '
        'BtnSrcS
        '
        Me.BtnSrcS.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.BtnSrcS.Location = New System.Drawing.Point(806, 110)
        Me.BtnSrcS.Name = "BtnSrcS"
        Me.BtnSrcS.Size = New System.Drawing.Size(162, 30)
        Me.BtnSrcS.TabIndex = 235
        Me.BtnSrcS.Text = "問番号シャッフル"
        Me.BtnSrcS.UseVisualStyleBackColor = True
        '
        'btnSrcQ
        '
        Me.btnSrcQ.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnSrcQ.Location = New System.Drawing.Point(806, 153)
        Me.btnSrcQ.Name = "btnSrcQ"
        Me.btnSrcQ.Size = New System.Drawing.Size(162, 30)
        Me.btnSrcQ.TabIndex = 236
        Me.btnSrcQ.Text = "問番号グループ順"
        Me.btnSrcQ.UseVisualStyleBackColor = True
        '
        'frmSpecificShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnSrcQ)
        Me.Controls.Add(Me.BtnSrcS)
        Me.Controls.Add(Me.ChkT)
        Me.Controls.Add(Me.ChkQ)
        Me.Controls.Add(Me.btnWord)
        Me.Controls.Add(Me.dgvPracticeQuestionList)
        Me.Controls.Add(Me.mskTestEnd_DateTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mskTestStart_DateTime)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnTestNameEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.LabelLine)
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.txtTestName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTree)
        Me.Name = "frmSpecificShow"
        Me.Text = "テスト登録確認"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtTestName, 0)
        Me.Controls.SetChildIndex(Me.LabelHeader, 0)
        Me.Controls.SetChildIndex(Me.LabelLine, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnTestNameEdit, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.mskTestStart_DateTime, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.mskTestEnd_DateTime, 0)
        Me.Controls.SetChildIndex(Me.dgvPracticeQuestionList, 0)
        Me.Controls.SetChildIndex(Me.btnWord, 0)
        Me.Controls.SetChildIndex(Me.ChkQ, 0)
        Me.Controls.SetChildIndex(Me.ChkT, 0)
        Me.Controls.SetChildIndex(Me.BtnSrcS, 0)
        Me.Controls.SetChildIndex(Me.btnSrcQ, 0)
        CType(Me.dgvPracticeQuestionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTestName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvPracticeQuestionList As System.Windows.Forms.DataGridView
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnTestNameEdit As System.Windows.Forms.Button
    Friend WithEvents mskTestEnd_DateTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mskTestStart_DateTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnWord As System.Windows.Forms.Button
    Friend WithEvents ChkQ As System.Windows.Forms.CheckBox
    Friend WithEvents ChkT As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSrcS As System.Windows.Forms.Button
    Friend WithEvents btnSrcQ As System.Windows.Forms.Button
    Friend WithEvents QUESTIONNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONCODE As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents CATEGORYNAME1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents THEME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LEVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
