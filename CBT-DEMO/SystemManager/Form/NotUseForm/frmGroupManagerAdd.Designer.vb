<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroupManagerAdd
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
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtGroupCode = New System.Windows.Forms.TextBox()
        Me.txtGroupName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGroupManagerName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtApplicant = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGroupManagerId = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtGroupManagerPassWrod = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtStudentCount = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnPassWord = New System.Windows.Forms.Button()
        Me.btnBackGroup = New System.Windows.Forms.Button()
        Me.dtpTestStart = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.dtpTestEnd = New CST.CBT.eIPSTA.BaseControl.UserDateTimePicker()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 19)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "団体新規登録"
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCode.Location = New System.Drawing.Point(173, 203)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(56, 15)
        Me.lblCode.TabIndex = 38
        Me.lblCode.Text = "【コード】"
        '
        'txtGroupCode
        '
        Me.txtGroupCode.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGroupCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGroupCode.Location = New System.Drawing.Point(259, 200)
        Me.txtGroupCode.Name = "txtGroupCode"
        Me.txtGroupCode.Size = New System.Drawing.Size(204, 22)
        Me.txtGroupCode.TabIndex = 10
        '
        'txtGroupName
        '
        Me.txtGroupName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGroupName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtGroupName.Location = New System.Drawing.Point(259, 244)
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.Size = New System.Drawing.Size(204, 22)
        Me.txtGroupName.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(173, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "【団体名】"
        '
        'txtGroupManagerName
        '
        Me.txtGroupManagerName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGroupManagerName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtGroupManagerName.Location = New System.Drawing.Point(643, 389)
        Me.txtGroupManagerName.Name = "txtGroupManagerName"
        Me.txtGroupManagerName.Size = New System.Drawing.Size(204, 22)
        Me.txtGroupManagerName.TabIndex = 90
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(540, 392)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "【管理者名】"
        '
        'txtApplicant
        '
        Me.txtApplicant.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtApplicant.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtApplicant.Location = New System.Drawing.Point(643, 244)
        Me.txtApplicant.Name = "txtApplicant"
        Me.txtApplicant.Size = New System.Drawing.Size(204, 22)
        Me.txtApplicant.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(540, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 15)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "【申込者名】"
        '
        'txtGroupManagerId
        '
        Me.txtGroupManagerId.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGroupManagerId.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGroupManagerId.Location = New System.Drawing.Point(259, 389)
        Me.txtGroupManagerId.Name = "txtGroupManagerId"
        Me.txtGroupManagerId.Size = New System.Drawing.Size(204, 22)
        Me.txtGroupManagerId.TabIndex = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(173, 392)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "【管理者ID】"
        '
        'txtGroupManagerPassWrod
        '
        Me.txtGroupManagerPassWrod.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtGroupManagerPassWrod.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtGroupManagerPassWrod.Location = New System.Drawing.Point(259, 438)
        Me.txtGroupManagerPassWrod.Name = "txtGroupManagerPassWrod"
        Me.txtGroupManagerPassWrod.Size = New System.Drawing.Size(204, 22)
        Me.txtGroupManagerPassWrod.TabIndex = 100
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(173, 441)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 15)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "【パスワード】"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(173, 299)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 15)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "【コース名】"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(173, 344)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 15)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "【利用期間】"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(540, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 15)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "【受講者数】"
        '
        'cmbCourse
        '
        Me.cmbCourse.DisplayMember = "COURSE"
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(259, 296)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(204, 23)
        Me.cmbCourse.TabIndex = 40
        Me.cmbCourse.ValueMember = "COURSENO"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(436, 344)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 15)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "～"
        '
        'txtStudentCount
        '
        Me.txtStudentCount.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtStudentCount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtStudentCount.Location = New System.Drawing.Point(643, 297)
        Me.txtStudentCount.Name = "txtStudentCount"
        Me.txtStudentCount.Size = New System.Drawing.Size(56, 22)
        Me.txtStudentCount.TabIndex = 50
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(491, 526)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 42)
        Me.btnAdd.TabIndex = 120
        Me.btnAdd.Text = "新規登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnPassWord
        '
        Me.btnPassWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPassWord.Location = New System.Drawing.Point(491, 433)
        Me.btnPassWord.Name = "btnPassWord"
        Me.btnPassWord.Size = New System.Drawing.Size(113, 30)
        Me.btnPassWord.TabIndex = 110
        Me.btnPassWord.Text = "パスワード生成"
        Me.btnPassWord.UseVisualStyleBackColor = True
        '
        'btnBackGroup
        '
        Me.btnBackGroup.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackGroup.Location = New System.Drawing.Point(803, 662)
        Me.btnBackGroup.Name = "btnBackGroup"
        Me.btnBackGroup.Size = New System.Drawing.Size(210, 30)
        Me.btnBackGroup.TabIndex = 130
        Me.btnBackGroup.Text = "団体登録／修正メニューへ戻る"
        Me.btnBackGroup.UseVisualStyleBackColor = True
        '
        'dtpTestStart
        '
        Me.dtpTestStart.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpTestStart.IsNull = False
        Me.dtpTestStart.Location = New System.Drawing.Point(259, 344)
        Me.dtpTestStart.Name = "dtpTestStart"
        Me.dtpTestStart.Size = New System.Drawing.Size(144, 22)
        Me.dtpTestStart.TabIndex = 53
        '
        'dtpTestEnd
        '
        Me.dtpTestEnd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtpTestEnd.IsNull = False
        Me.dtpTestEnd.Location = New System.Drawing.Point(481, 344)
        Me.dtpTestEnd.Name = "dtpTestEnd"
        Me.dtpTestEnd.Size = New System.Drawing.Size(142, 22)
        Me.dtpTestEnd.TabIndex = 56
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(375, 12)
        Me.lblTree.TabIndex = 141
        Me.lblTree.Text = "システム管理者メインメニュー  ＞ 団体登録／修正メニュー ＞ 団体新規登録"
        '
        'frmGroupManagerAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.dtpTestStart)
        Me.Controls.Add(Me.dtpTestEnd)
        Me.Controls.Add(Me.btnBackGroup)
        Me.Controls.Add(Me.btnPassWord)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.txtGroupManagerPassWrod)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtGroupManagerId)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStudentCount)
        Me.Controls.Add(Me.txtApplicant)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtGroupManagerName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtGroupName)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtGroupCode)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmGroupManagerAdd"
        Me.Text = "frmGroupManager"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblCode, 0)
        Me.Controls.SetChildIndex(Me.txtGroupCode, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txtGroupName, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.txtGroupManagerName, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtApplicant, 0)
        Me.Controls.SetChildIndex(Me.txtStudentCount, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txtGroupManagerId, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtGroupManagerPassWrod, 0)
        Me.Controls.SetChildIndex(Me.cmbCourse, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnPassWord, 0)
        Me.Controls.SetChildIndex(Me.btnBackGroup, 0)
        Me.Controls.SetChildIndex(Me.dtpTestEnd, 0)
        Me.Controls.SetChildIndex(Me.dtpTestStart, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGroupManagerName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtApplicant As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGroupManagerId As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtGroupManagerPassWrod As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtStudentCount As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnPassWord As System.Windows.Forms.Button
    Friend WithEvents btnBackGroup As System.Windows.Forms.Button
    Friend WithEvents dtpTestStart As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents dtpTestEnd As CST.CBT.eIPSTA.BaseControl.UserDateTimePicker
    Friend WithEvents lblTree As System.Windows.Forms.Label
End Class
