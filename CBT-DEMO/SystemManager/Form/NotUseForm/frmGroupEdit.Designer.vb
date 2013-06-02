<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroupEdit
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvGroupList = New System.Windows.Forms.DataGridView()
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colGroupCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGroupName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApplicant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCourseNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colStudentCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGroupManagerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGroupManagerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGroupManagerPassWord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colState = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCourse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbGroupCode = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbGroupName = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmbState = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpTestEnd = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.dtpTestStart = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.btnCheckAllOn = New System.Windows.Forms.Button()
        Me.btnCheckAllOff = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBackGroup = New System.Windows.Forms.Button()
        Me.btnPassWord = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvGroupList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.Label5.Size = New System.Drawing.Size(169, 19)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "団体情報更新修正"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(30, 152)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(104, 25)
        Me.Panel2.TabIndex = 40
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "〔抽出条件〕"
        '
        'dgvGroupList
        '
        Me.dgvGroupList.AllowUserToAddRows = False
        Me.dgvGroupList.AllowUserToDeleteRows = False
        Me.dgvGroupList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGroupList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGroupList.ColumnHeadersHeight = 34
        Me.dgvGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvGroupList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.colGroupCode, Me.colGroupName, Me.colApplicant, Me.colCourseNo, Me.colStudentCount, Me.colTestStart, Me.colTestEnd, Me.colGroupManagerId, Me.colGroupManagerName, Me.colGroupManagerPassWord, Me.colState, Me.colCourse})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGroupList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvGroupList.EnableHeadersVisualStyles = False
        Me.dgvGroupList.Location = New System.Drawing.Point(12, 263)
        Me.dgvGroupList.Name = "dgvGroupList"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGroupList.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvGroupList.RowHeadersVisible = False
        Me.dgvGroupList.RowTemplate.Height = 21
        Me.dgvGroupList.Size = New System.Drawing.Size(991, 330)
        Me.dgvGroupList.TabIndex = 75
        '
        'colCheck
        '
        Me.colCheck.DataPropertyName = "CHECK"
        Me.colCheck.HeaderText = "チェック"
        Me.colCheck.Name = "colCheck"
        Me.colCheck.Width = 50
        '
        'colGroupCode
        '
        Me.colGroupCode.DataPropertyName = "GROUPCODE"
        Me.colGroupCode.HeaderText = "コード"
        Me.colGroupCode.Name = "colGroupCode"
        Me.colGroupCode.ReadOnly = True
        Me.colGroupCode.Width = 80
        '
        'colGroupName
        '
        Me.colGroupName.DataPropertyName = "GROUPNAME"
        Me.colGroupName.HeaderText = "団体名"
        Me.colGroupName.Name = "colGroupName"
        Me.colGroupName.Width = 90
        '
        'colApplicant
        '
        Me.colApplicant.DataPropertyName = "APPLICANT"
        Me.colApplicant.HeaderText = "申込者名"
        Me.colApplicant.Name = "colApplicant"
        Me.colApplicant.Width = 80
        '
        'colCourseNo
        '
        Me.colCourseNo.DataPropertyName = "COURSENO"
        Me.colCourseNo.HeaderText = "コース名"
        Me.colCourseNo.Name = "colCourseNo"
        Me.colCourseNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCourseNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colStudentCount
        '
        Me.colStudentCount.DataPropertyName = "STUDENTCOUNT"
        DataGridViewCellStyle2.NullValue = "0"
        Me.colStudentCount.DefaultCellStyle = DataGridViewCellStyle2
        Me.colStudentCount.HeaderText = "受講者数"
        Me.colStudentCount.Name = "colStudentCount"
        Me.colStudentCount.Width = 40
        '
        'colTestStart
        '
        Me.colTestStart.DataPropertyName = "TESTSTART"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colTestStart.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTestStart.HeaderText = "利用開始日"
        Me.colTestStart.Name = "colTestStart"
        Me.colTestStart.Width = 90
        '
        'colTestEnd
        '
        Me.colTestEnd.DataPropertyName = "TESTEND"
        Me.colTestEnd.HeaderText = "利用終了日"
        Me.colTestEnd.Name = "colTestEnd"
        Me.colTestEnd.Width = 90
        '
        'colGroupManagerId
        '
        Me.colGroupManagerId.DataPropertyName = "GROUPMANAGERID"
        Me.colGroupManagerId.HeaderText = "団体管理者（ユーザID)"
        Me.colGroupManagerId.Name = "colGroupManagerId"
        Me.colGroupManagerId.Width = 80
        '
        'colGroupManagerName
        '
        Me.colGroupManagerName.DataPropertyName = "GROUPMANAGERNAME"
        Me.colGroupManagerName.HeaderText = "管理者名"
        Me.colGroupManagerName.Name = "colGroupManagerName"
        Me.colGroupManagerName.Width = 90
        '
        'colGroupManagerPassWord
        '
        Me.colGroupManagerPassWord.DataPropertyName = "PASSWORD"
        Me.colGroupManagerPassWord.HeaderText = "パスワード"
        Me.colGroupManagerPassWord.Name = "colGroupManagerPassWord"
        Me.colGroupManagerPassWord.Width = 80
        '
        'colState
        '
        Me.colState.DataPropertyName = "STATE"
        Me.colState.HeaderText = "状態"
        Me.colState.Name = "colState"
        Me.colState.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colCourse
        '
        Me.colCourse.DataPropertyName = "COURSE"
        Me.colCourse.HeaderText = "COURSE"
        Me.colCourse.Name = "colCourse"
        Me.colCourse.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(51, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "【コード】"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(51, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 15)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "【利用期間】"
        '
        'cmbGroupCode
        '
        Me.cmbGroupCode.DisplayMember = "GROUPCODE"
        Me.cmbGroupCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupCode.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroupCode.FormattingEnabled = True
        Me.cmbGroupCode.Items.AddRange(New Object() {"すべて"})
        Me.cmbGroupCode.Location = New System.Drawing.Point(137, 24)
        Me.cmbGroupCode.Name = "cmbGroupCode"
        Me.cmbGroupCode.Size = New System.Drawing.Size(121, 23)
        Me.cmbGroupCode.TabIndex = 10
        Me.cmbGroupCode.ValueMember = "GROUPCODE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label12.Location = New System.Drawing.Point(290, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 15)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "～"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(882, 52)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 30)
        Me.btnSearch.TabIndex = 70
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(316, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "【団体名】"
        '
        'cmbGroupName
        '
        Me.cmbGroupName.DisplayMember = "GROUPNAME"
        Me.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroupName.FormattingEnabled = True
        Me.cmbGroupName.Items.AddRange(New Object() {"すべて"})
        Me.cmbGroupName.Location = New System.Drawing.Point(390, 24)
        Me.cmbGroupName.Name = "cmbGroupName"
        Me.cmbGroupName.Size = New System.Drawing.Size(121, 23)
        Me.cmbGroupName.TabIndex = 20
        Me.cmbGroupName.ValueMember = "GROUPNAME"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label29.Location = New System.Drawing.Point(577, 27)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(71, 15)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "【コース名】"
        '
        'cmbCourse
        '
        Me.cmbCourse.DisplayMember = "COURSE"
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Items.AddRange(New Object() {"すべて"})
        Me.cmbCourse.Location = New System.Drawing.Point(654, 24)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(121, 23)
        Me.cmbCourse.TabIndex = 30
        Me.cmbCourse.ValueMember = "COURSE"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label35.Location = New System.Drawing.Point(487, 60)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 15)
        Me.Label35.TabIndex = 87
        Me.Label35.Text = "【状態】"
        '
        'cmbState
        '
        Me.cmbState.DisplayMember = "DISP"
        Me.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbState.DropDownWidth = 151
        Me.cmbState.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbState.FormattingEnabled = True
        Me.cmbState.Items.AddRange(New Object() {"準備中", "稼働中", "稼働停止"})
        Me.cmbState.Location = New System.Drawing.Point(555, 57)
        Me.cmbState.Name = "cmbState"
        Me.cmbState.Size = New System.Drawing.Size(151, 23)
        Me.cmbState.TabIndex = 60
        Me.cmbState.ValueMember = "DISP"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbState)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.cmbCourse)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.cmbGroupName)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cmbGroupCode)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dtpTestEnd)
        Me.Panel1.Controls.Add(Me.dtpTestStart)
        Me.Panel1.Location = New System.Drawing.Point(12, 163)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 94)
        Me.Panel1.TabIndex = 39
        '
        'dtpTestEnd
        '
        Me.dtpTestEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpTestEnd.IsNull = False
        Me.dtpTestEnd.Location = New System.Drawing.Point(319, 58)
        Me.dtpTestEnd.Name = "dtpTestEnd"
        Me.dtpTestEnd.Size = New System.Drawing.Size(143, 22)
        Me.dtpTestEnd.TabIndex = 50
        '
        'dtpTestStart
        '
        Me.dtpTestStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpTestStart.IsNull = False
        Me.dtpTestStart.Location = New System.Drawing.Point(137, 58)
        Me.dtpTestStart.Name = "dtpTestStart"
        Me.dtpTestStart.Size = New System.Drawing.Size(143, 22)
        Me.dtpTestStart.TabIndex = 40
        '
        'btnCheckAllOn
        '
        Me.btnCheckAllOn.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOn.Location = New System.Drawing.Point(12, 613)
        Me.btnCheckAllOn.Name = "btnCheckAllOn"
        Me.btnCheckAllOn.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOn.TabIndex = 80
        Me.btnCheckAllOn.Text = "全チェック"
        Me.btnCheckAllOn.UseVisualStyleBackColor = True
        '
        'btnCheckAllOff
        '
        Me.btnCheckAllOff.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCheckAllOff.Location = New System.Drawing.Point(128, 613)
        Me.btnCheckAllOff.Name = "btnCheckAllOff"
        Me.btnCheckAllOff.Size = New System.Drawing.Size(110, 30)
        Me.btnCheckAllOff.TabIndex = 90
        Me.btnCheckAllOff.Text = "全チェック解除"
        Me.btnCheckAllOff.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(817, 613)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 30)
        Me.btnEdit.TabIndex = 130
        Me.btnEdit.Text = "修正"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(14, 596)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(325, 15)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "※□にチェックの付いた団体情報を処理対象とします。"
        '
        'btnBackGroup
        '
        Me.btnBackGroup.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackGroup.Location = New System.Drawing.Point(803, 662)
        Me.btnBackGroup.Name = "btnBackGroup"
        Me.btnBackGroup.Size = New System.Drawing.Size(210, 30)
        Me.btnBackGroup.TabIndex = 140
        Me.btnBackGroup.Text = "団体登録／修正メニューへ戻る"
        Me.btnBackGroup.UseVisualStyleBackColor = True
        '
        'btnPassWord
        '
        Me.btnPassWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPassWord.Location = New System.Drawing.Point(685, 613)
        Me.btnPassWord.Name = "btnPassWord"
        Me.btnPassWord.Size = New System.Drawing.Size(112, 30)
        Me.btnPassWord.TabIndex = 100
        Me.btnPassWord.Text = "パスワード生成"
        Me.btnPassWord.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(395, 12)
        Me.lblTree.TabIndex = 151
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 団体登録／修正メニュー ＞ 団体情報更新修正"
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDel.Location = New System.Drawing.Point(913, 613)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(90, 30)
        Me.btnDel.TabIndex = 135
        Me.btnDel.Text = "削除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'frmGroupEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnBackGroup)
        Me.Controls.Add(Me.btnCheckAllOn)
        Me.Controls.Add(Me.btnCheckAllOff)
        Me.Controls.Add(Me.btnPassWord)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dgvGroupList)
        Me.Name = "frmGroupEdit"
        Me.Text = "frmResultList"
        Me.Controls.SetChildIndex(Me.dgvGroupList, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDel, 0)
        Me.Controls.SetChildIndex(Me.btnPassWord, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOff, 0)
        Me.Controls.SetChildIndex(Me.btnCheckAllOn, 0)
        Me.Controls.SetChildIndex(Me.btnBackGroup, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvGroupList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvGroupList As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbGroupCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbGroupName As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbState As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCheckAllOn As System.Windows.Forms.Button
    Friend WithEvents btnCheckAllOff As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnBackGroup As System.Windows.Forms.Button
    Friend WithEvents btnPassWord As System.Windows.Forms.Button
    Friend WithEvents dtpTestEnd As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents dtpTestStart As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colGroupCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGroupName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApplicant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCourseNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colStudentCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGroupManagerId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGroupManagerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGroupManagerPassWord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colState As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCourse As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
