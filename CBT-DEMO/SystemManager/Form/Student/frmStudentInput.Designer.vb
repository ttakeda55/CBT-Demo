<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudentInput
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvStudent = New System.Windows.Forms.DataGridView()
        Me.colCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colGroupCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGroupName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSection1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colSection2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPassWord = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStudentsStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStudentsEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnAllCheck = New System.Windows.Forms.Button()
        Me.btnAllCheckCancell = New System.Windows.Forms.Button()
        Me.lblStudentSumCount = New System.Windows.Forms.Label()
        Me.lblStudentCount = New System.Windows.Forms.Label()
        Me.btnBackStudent = New System.Windows.Forms.Button()
        Me.cmbGroupCode = New System.Windows.Forms.ComboBox()
        Me.cmbGroupName = New System.Windows.Forms.ComboBox()
        Me.btnPassWord = New System.Windows.Forms.Button()
        Me.btnCSVExport = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblUsePeriod = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Label5.Location = New System.Drawing.Point(70, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 19)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "受講者個別登録／修正"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(401, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "【コード】"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(600, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 15)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "【団体名】"
        Me.Label7.Visible = False
        '
        'dgvStudent
        '
        Me.dgvStudent.AllowUserToAddRows = False
        Me.dgvStudent.AllowUserToDeleteRows = False
        Me.dgvStudent.AllowUserToResizeRows = False
        Me.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheck, Me.colGroupCode, Me.colGroupName, Me.colUserId, Me.colUserName, Me.colSection1, Me.colSection2, Me.colPassWord, Me.colStudentsStart, Me.colStudentsEnd, Me.colNote})
        Me.dgvStudent.Location = New System.Drawing.Point(163, 206)
        Me.dgvStudent.Name = "dgvStudent"
        Me.dgvStudent.RowHeadersVisible = False
        Me.dgvStudent.RowTemplate.Height = 21
        Me.dgvStudent.Size = New System.Drawing.Size(720, 364)
        Me.dgvStudent.TabIndex = 40
        '
        'colCheck
        '
        Me.colCheck.HeaderText = " "
        Me.colCheck.Name = "colCheck"
        Me.colCheck.Width = 40
        '
        'colGroupCode
        '
        Me.colGroupCode.DataPropertyName = "GROUPCODE"
        Me.colGroupCode.HeaderText = "コード"
        Me.colGroupCode.Name = "colGroupCode"
        Me.colGroupCode.ReadOnly = True
        Me.colGroupCode.Visible = False
        '
        'colGroupName
        '
        Me.colGroupName.DataPropertyName = "GROUPNAME"
        Me.colGroupName.HeaderText = "団体名"
        Me.colGroupName.Name = "colGroupName"
        Me.colGroupName.ReadOnly = True
        Me.colGroupName.Visible = False
        '
        'colUserId
        '
        Me.colUserId.DataPropertyName = "USERID"
        Me.colUserId.HeaderText = "ユーザID"
        Me.colUserId.Name = "colUserId"
        Me.colUserId.ReadOnly = True
        Me.colUserId.Width = 150
        '
        'colUserName
        '
        Me.colUserName.DataPropertyName = "NAME"
        Me.colUserName.HeaderText = "受講者名"
        Me.colUserName.Name = "colUserName"
        Me.colUserName.Width = 200
        '
        'colSection1
        '
        Me.colSection1.DataPropertyName = "SECTION1"
        Me.colSection1.HeaderText = "区分１"
        Me.colSection1.Items.AddRange(New Object() {"１", "２", "３", "４", "５", "６", "７", "８", "９"})
        Me.colSection1.Name = "colSection1"
        Me.colSection1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSection1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSection1.Visible = False
        Me.colSection1.Width = 65
        '
        'colSection2
        '
        Me.colSection2.DataPropertyName = "SECTION2"
        Me.colSection2.HeaderText = "区分２"
        Me.colSection2.Items.AddRange(New Object() {"Ａ", "Ｂ", "Ｃ", "Ｄ", "Ｅ", "Ｆ", "Ｇ", "Ｈ", "Ｉ", "Ｊ", "Ｋ", "Ｌ", "Ｍ", "Ｎ", "Ｏ", "Ｐ", "Ｑ", "Ｒ", "Ｓ", "Ｔ", "Ｕ", "Ｖ", "Ｗ", "Ｘ", "Ｙ", "Ｚ"})
        Me.colSection2.Name = "colSection2"
        Me.colSection2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSection2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSection2.Visible = False
        Me.colSection2.Width = 65
        '
        'colPassWord
        '
        Me.colPassWord.DataPropertyName = "PASSWORD"
        Me.colPassWord.HeaderText = "パスワード"
        Me.colPassWord.Name = "colPassWord"
        Me.colPassWord.Width = 80
        '
        'colStudentsStart
        '
        Me.colStudentsStart.DataPropertyName = "STUDENTSSTART"
        Me.colStudentsStart.HeaderText = "受講開始日"
        Me.colStudentsStart.Name = "colStudentsStart"
        Me.colStudentsStart.Visible = False
        Me.colStudentsStart.Width = 90
        '
        'colStudentsEnd
        '
        Me.colStudentsEnd.DataPropertyName = "STUDENTSEND"
        Me.colStudentsEnd.HeaderText = "受講終了日"
        Me.colStudentsEnd.Name = "colStudentsEnd"
        Me.colStudentsEnd.Visible = False
        Me.colStudentsEnd.Width = 90
        '
        'colNote
        '
        Me.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNote.DataPropertyName = "NOTE"
        Me.colNote.HeaderText = "備考"
        Me.colNote.Name = "colNote"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(691, 593)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 30)
        Me.btnEdit.TabIndex = 90
        Me.btnEdit.Text = "修正"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(758, 100)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(99, 30)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "受講者表示"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(283, 183)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "名"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(162, 183)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "登録者数"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(387, 183)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 15)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "名"
        Me.Label11.Visible = False
        '
        'btnAllCheck
        '
        Me.btnAllCheck.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAllCheck.Location = New System.Drawing.Point(160, 593)
        Me.btnAllCheck.Name = "btnAllCheck"
        Me.btnAllCheck.Size = New System.Drawing.Size(110, 30)
        Me.btnAllCheck.TabIndex = 50
        Me.btnAllCheck.Text = "全チェック"
        Me.btnAllCheck.UseVisualStyleBackColor = True
        '
        'btnAllCheckCancell
        '
        Me.btnAllCheckCancell.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAllCheckCancell.Location = New System.Drawing.Point(276, 593)
        Me.btnAllCheckCancell.Name = "btnAllCheckCancell"
        Me.btnAllCheckCancell.Size = New System.Drawing.Size(110, 30)
        Me.btnAllCheckCancell.TabIndex = 60
        Me.btnAllCheckCancell.Text = "全チェック解除"
        Me.btnAllCheckCancell.UseVisualStyleBackColor = True
        '
        'lblStudentSumCount
        '
        Me.lblStudentSumCount.AutoSize = True
        Me.lblStudentSumCount.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStudentSumCount.Location = New System.Drawing.Point(245, 183)
        Me.lblStudentSumCount.Name = "lblStudentSumCount"
        Me.lblStudentSumCount.Size = New System.Drawing.Size(0, 15)
        Me.lblStudentSumCount.TabIndex = 126
        Me.lblStudentSumCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStudentCount
        '
        Me.lblStudentCount.AutoSize = True
        Me.lblStudentCount.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStudentCount.Location = New System.Drawing.Point(345, 183)
        Me.lblStudentCount.Name = "lblStudentCount"
        Me.lblStudentCount.Size = New System.Drawing.Size(0, 15)
        Me.lblStudentCount.TabIndex = 126
        Me.lblStudentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStudentCount.Visible = False
        '
        'btnBackStudent
        '
        Me.btnBackStudent.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackStudent.Location = New System.Drawing.Point(791, 662)
        Me.btnBackStudent.Name = "btnBackStudent"
        Me.btnBackStudent.Size = New System.Drawing.Size(222, 30)
        Me.btnBackStudent.TabIndex = 110
        Me.btnBackStudent.Text = "受講者登録／修正メニューへ戻る"
        Me.btnBackStudent.UseVisualStyleBackColor = True
        '
        'cmbGroupCode
        '
        Me.cmbGroupCode.DisplayMember = "GROUPCODE"
        Me.cmbGroupCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupCode.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroupCode.FormattingEnabled = True
        Me.cmbGroupCode.Location = New System.Drawing.Point(463, 136)
        Me.cmbGroupCode.Name = "cmbGroupCode"
        Me.cmbGroupCode.Size = New System.Drawing.Size(126, 23)
        Me.cmbGroupCode.TabIndex = 10
        Me.cmbGroupCode.ValueMember = "GROUPCODE"
        Me.cmbGroupCode.Visible = False
        '
        'cmbGroupName
        '
        Me.cmbGroupName.DisplayMember = "GROUPNAME"
        Me.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGroupName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbGroupName.FormattingEnabled = True
        Me.cmbGroupName.Location = New System.Drawing.Point(674, 136)
        Me.cmbGroupName.Name = "cmbGroupName"
        Me.cmbGroupName.Size = New System.Drawing.Size(183, 23)
        Me.cmbGroupName.TabIndex = 20
        Me.cmbGroupName.ValueMember = "GROUPNAME"
        Me.cmbGroupName.Visible = False
        '
        'btnPassWord
        '
        Me.btnPassWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPassWord.Location = New System.Drawing.Point(554, 593)
        Me.btnPassWord.Name = "btnPassWord"
        Me.btnPassWord.Size = New System.Drawing.Size(110, 30)
        Me.btnPassWord.TabIndex = 80
        Me.btnPassWord.Text = "パスワード生成"
        Me.btnPassWord.UseVisualStyleBackColor = True
        '
        'btnCSVExport
        '
        Me.btnCSVExport.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCSVExport.Location = New System.Drawing.Point(400, 593)
        Me.btnCSVExport.Name = "btnCSVExport"
        Me.btnCSVExport.Size = New System.Drawing.Size(123, 30)
        Me.btnCSVExport.TabIndex = 70
        Me.btnCSVExport.Text = "CSV形式で保存"
        Me.btnCSVExport.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDel.Location = New System.Drawing.Point(795, 593)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(90, 30)
        Me.btnDel.TabIndex = 100
        Me.btnDel.Text = "削除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(395, 12)
        Me.lblTree.TabIndex = 203
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 受講者登録／修正メニュー ＞ 受講者個別処理"
        Me.lblTree.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(46, 312)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 15)
        Me.Label12.TabIndex = 204
        Me.Label12.Text = "【利用期間】"
        Me.Label12.Visible = False
        '
        'lblUsePeriod
        '
        Me.lblUsePeriod.AutoSize = True
        Me.lblUsePeriod.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUsePeriod.Location = New System.Drawing.Point(193, 186)
        Me.lblUsePeriod.Name = "lblUsePeriod"
        Me.lblUsePeriod.Size = New System.Drawing.Size(0, 15)
        Me.lblUsePeriod.TabIndex = 205
        Me.lblUsePeriod.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(160, 575)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(340, 15)
        Me.Label13.TabIndex = 204
        Me.Label13.Text = "※□にチェックの付いた受講者情報を処理対象とします。"
        '
        'frmStudentInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblUsePeriod)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.cmbGroupName)
        Me.Controls.Add(Me.cmbGroupCode)
        Me.Controls.Add(Me.btnBackStudent)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnAllCheck)
        Me.Controls.Add(Me.dgvStudent)
        Me.Controls.Add(Me.btnAllCheckCancell)
        Me.Controls.Add(Me.btnCSVExport)
        Me.Controls.Add(Me.btnPassWord)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblStudentCount)
        Me.Controls.Add(Me.lblStudentSumCount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Name = "frmStudentInput"
        Me.Text = "frmImportCheck"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lblStudentSumCount, 0)
        Me.Controls.SetChildIndex(Me.lblStudentCount, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDel, 0)
        Me.Controls.SetChildIndex(Me.btnPassWord, 0)
        Me.Controls.SetChildIndex(Me.btnCSVExport, 0)
        Me.Controls.SetChildIndex(Me.btnAllCheckCancell, 0)
        Me.Controls.SetChildIndex(Me.dgvStudent, 0)
        Me.Controls.SetChildIndex(Me.btnAllCheck, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.btnBackStudent, 0)
        Me.Controls.SetChildIndex(Me.cmbGroupCode, 0)
        Me.Controls.SetChildIndex(Me.cmbGroupName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.lblUsePeriod, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvStudent As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnAllCheck As System.Windows.Forms.Button
    Friend WithEvents btnAllCheckCancell As System.Windows.Forms.Button
    Friend WithEvents lblStudentSumCount As System.Windows.Forms.Label
    Friend WithEvents lblStudentCount As System.Windows.Forms.Label
    Friend WithEvents btnBackStudent As System.Windows.Forms.Button
    Friend WithEvents cmbGroupCode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGroupName As System.Windows.Forms.ComboBox
    Friend WithEvents btnPassWord As System.Windows.Forms.Button
    Friend WithEvents btnCSVExport As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblUsePeriod As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents colCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colGroupCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGroupName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSection1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colSection2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPassWord As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStudentsStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStudentsEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNote As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
