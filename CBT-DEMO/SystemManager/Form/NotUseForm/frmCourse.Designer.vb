<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCourse
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgvCourseList = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbMockTest = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl04 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.rdbCopy = New System.Windows.Forms.RadioButton()
        Me.rdbNon = New System.Windows.Forms.RadioButton()
        Me.rdbNew = New System.Windows.Forms.RadioButton()
        Me.lbl02 = New System.Windows.Forms.Label()
        Me.txtCourse = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.txtCourseNo = New System.Windows.Forms.TextBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBackSystemManager = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.lbl03 = New System.Windows.Forms.Label()
        Me.lblTitel = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.COURSENO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COURSE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOCKTESTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MINI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MIDDLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STUDENTCOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USESTART = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USEEND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATE = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.COLLECTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATE_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UPDATE_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCourseList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCourseList
        '
        Me.dgvCourseList.AllowUserToAddRows = False
        Me.dgvCourseList.AllowUserToDeleteRows = False
        Me.dgvCourseList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCourseList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCourseList.ColumnHeadersHeight = 34
        Me.dgvCourseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCourseList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COURSENO, Me.COURSE, Me.MOCKTESTNO, Me.MINI, Me.MIDDLE, Me.TOTAL, Me.STUDENTCOUNT, Me.USESTART, Me.USEEND, Me.STATE, Me.COLLECTION, Me.CREATE_DATE, Me.UPDATE_DATE})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCourseList.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvCourseList.EnableHeadersVisualStyles = False
        Me.dgvCourseList.Location = New System.Drawing.Point(38, 323)
        Me.dgvCourseList.Name = "dgvCourseList"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCourseList.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvCourseList.RowHeadersVisible = False
        Me.dgvCourseList.RowTemplate.Height = 21
        Me.dgvCourseList.Size = New System.Drawing.Size(943, 288)
        Me.dgvCourseList.TabIndex = 70
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbMockTest)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lbl04)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lbl02)
        Me.Panel1.Controls.Add(Me.txtCourse)
        Me.Panel1.Controls.Add(Me.lbl)
        Me.Panel1.Controls.Add(Me.txtCourseNo)
        Me.Panel1.Location = New System.Drawing.Point(38, 182)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(943, 130)
        Me.Panel1.TabIndex = 0
        '
        'cmbMockTest
        '
        Me.cmbMockTest.DisplayMember = "NAME"
        Me.cmbMockTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMockTest.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbMockTest.FormattingEnabled = True
        Me.cmbMockTest.Location = New System.Drawing.Point(125, 90)
        Me.cmbMockTest.Name = "cmbMockTest"
        Me.cmbMockTest.Size = New System.Drawing.Size(180, 23)
        Me.cmbMockTest.TabIndex = 30
        Me.cmbMockTest.ValueMember = "NAME"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 15)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "【模擬テスト名】"
        '
        'lbl04
        '
        Me.lbl04.BackColor = System.Drawing.Color.White
        Me.lbl04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl04.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl04.Location = New System.Drawing.Point(344, 8)
        Me.lbl04.Name = "lbl04"
        Me.lbl04.Size = New System.Drawing.Size(110, 25)
        Me.lbl04.TabIndex = 0
        Me.lbl04.Text = "【演習問題群】"
        Me.lbl04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(813, 90)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 60
        Me.btnAdd.Text = "コース追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbCourse)
        Me.Panel2.Controls.Add(Me.rdbCopy)
        Me.Panel2.Controls.Add(Me.rdbNon)
        Me.Panel2.Controls.Add(Me.rdbNew)
        Me.Panel2.Location = New System.Drawing.Point(331, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 100)
        Me.Panel2.TabIndex = 31
        '
        'cmbCourse
        '
        Me.cmbCourse.DisplayMember = "COURSE"
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(252, 60)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(180, 23)
        Me.cmbCourse.TabIndex = 50
        Me.cmbCourse.ValueMember = "COURSE"
        '
        'rdbCopy
        '
        Me.rdbCopy.AutoSize = True
        Me.rdbCopy.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbCopy.Location = New System.Drawing.Point(247, 28)
        Me.rdbCopy.Name = "rdbCopy"
        Me.rdbCopy.Size = New System.Drawing.Size(148, 19)
        Me.rdbCopy.TabIndex = 42
        Me.rdbCopy.TabStop = True
        Me.rdbCopy.Text = "登録済コースのコピー"
        Me.rdbCopy.UseVisualStyleBackColor = True
        '
        'rdbNon
        '
        Me.rdbNon.AutoSize = True
        Me.rdbNon.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbNon.Location = New System.Drawing.Point(128, 28)
        Me.rdbNon.Name = "rdbNon"
        Me.rdbNon.Size = New System.Drawing.Size(91, 19)
        Me.rdbNon.TabIndex = 41
        Me.rdbNon.TabStop = True
        Me.rdbNon.Text = "登録しない"
        Me.rdbNon.UseVisualStyleBackColor = True
        '
        'rdbNew
        '
        Me.rdbNew.AutoSize = True
        Me.rdbNew.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbNew.Location = New System.Drawing.Point(28, 28)
        Me.rdbNew.Name = "rdbNew"
        Me.rdbNew.Size = New System.Drawing.Size(85, 19)
        Me.rdbNew.TabIndex = 40
        Me.rdbNew.TabStop = True
        Me.rdbNew.Text = "新規登録"
        Me.rdbNew.UseVisualStyleBackColor = True
        '
        'lbl02
        '
        Me.lbl02.AutoSize = True
        Me.lbl02.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl02.Location = New System.Drawing.Point(18, 57)
        Me.lbl02.Name = "lbl02"
        Me.lbl02.Size = New System.Drawing.Size(71, 15)
        Me.lbl02.TabIndex = 82
        Me.lbl02.Text = "【コース名】"
        '
        'txtCourse
        '
        Me.txtCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCourse.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtCourse.Location = New System.Drawing.Point(125, 54)
        Me.txtCourse.Name = "txtCourse"
        Me.txtCourse.Size = New System.Drawing.Size(180, 22)
        Me.txtCourse.TabIndex = 20
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl.Location = New System.Drawing.Point(18, 25)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(86, 15)
        Me.lbl.TabIndex = 80
        Me.lbl.Text = "【コース番号】"
        '
        'txtCourseNo
        '
        Me.txtCourseNo.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCourseNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCourseNo.Location = New System.Drawing.Point(125, 22)
        Me.txtCourseNo.Name = "txtCourseNo"
        Me.txtCourseNo.Size = New System.Drawing.Size(120, 22)
        Me.txtCourseNo.TabIndex = 10
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(862, 617)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(119, 30)
        Me.btnEdit.TabIndex = 80
        Me.btnEdit.Text = "更　新"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(70, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 19)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "コース登録/確認"
        '
        'btnBackSystemManager
        '
        Me.btnBackSystemManager.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBackSystemManager.Location = New System.Drawing.Point(803, 662)
        Me.btnBackSystemManager.Name = "btnBackSystemManager"
        Me.btnBackSystemManager.Size = New System.Drawing.Size(210, 30)
        Me.btnBackSystemManager.TabIndex = 90
        Me.btnBackSystemManager.Text = "システム管理者メニューへ戻る"
        Me.btnBackSystemManager.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(241, 12)
        Me.lblTree.TabIndex = 184
        Me.lblTree.Text = "システム管理者メインメニュー ＞ コース登録/確認"
        '
        'lbl03
        '
        Me.lbl03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl03.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl03.Location = New System.Drawing.Point(54, 168)
        Me.lbl03.Name = "lbl03"
        Me.lbl03.Size = New System.Drawing.Size(105, 25)
        Me.lbl03.TabIndex = 0
        Me.lbl03.Text = "【コース登録】"
        Me.lbl03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitel
        '
        Me.lblTitel.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitel.Location = New System.Drawing.Point(372, 327)
        Me.lblTitel.Name = "lblTitel"
        Me.lblTitel.Size = New System.Drawing.Size(220, 13)
        Me.lblTitel.TabIndex = 187
        Me.lblTitel.Text = "演習問題数"
        '
        'lblLine
        '
        Me.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLine.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLine.Location = New System.Drawing.Point(370, 340)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(224, 1)
        Me.lblLine.TabIndex = 188
        '
        'COURSENO
        '
        Me.COURSENO.DataPropertyName = "COURSENO"
        DataGridViewCellStyle2.NullValue = "C001"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.COURSENO.DefaultCellStyle = DataGridViewCellStyle2
        Me.COURSENO.HeaderText = "コース番号"
        Me.COURSENO.Name = "COURSENO"
        Me.COURSENO.ReadOnly = True
        Me.COURSENO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COURSENO.Width = 90
        '
        'COURSE
        '
        Me.COURSE.DataPropertyName = "COURSE"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.COURSE.DefaultCellStyle = DataGridViewCellStyle3
        Me.COURSE.HeaderText = "コース名"
        Me.COURSE.Name = "COURSE"
        Me.COURSE.ReadOnly = True
        Me.COURSE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COURSE.Width = 140
        '
        'MOCKTESTNO
        '
        Me.MOCKTESTNO.DataPropertyName = "MOCKTESTNONAME"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.MOCKTESTNO.DefaultCellStyle = DataGridViewCellStyle4
        Me.MOCKTESTNO.HeaderText = "模擬テスト名"
        Me.MOCKTESTNO.Name = "MOCKTESTNO"
        Me.MOCKTESTNO.ReadOnly = True
        Me.MOCKTESTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'MINI
        '
        Me.MINI.DataPropertyName = "MINI"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.MINI.DefaultCellStyle = DataGridViewCellStyle5
        Me.MINI.HeaderText = "小問"
        Me.MINI.Name = "MINI"
        Me.MINI.ReadOnly = True
        Me.MINI.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MINI.Width = 75
        '
        'MIDDLE
        '
        Me.MIDDLE.DataPropertyName = "MIDDLE"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.MIDDLE.DefaultCellStyle = DataGridViewCellStyle6
        Me.MIDDLE.HeaderText = "中問"
        Me.MIDDLE.Name = "MIDDLE"
        Me.MIDDLE.ReadOnly = True
        Me.MIDDLE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MIDDLE.Width = 75
        '
        'TOTAL
        '
        Me.TOTAL.DataPropertyName = "TOTAL"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.TOTAL.DefaultCellStyle = DataGridViewCellStyle7
        Me.TOTAL.HeaderText = "総計"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        Me.TOTAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TOTAL.Width = 75
        '
        'STUDENTCOUNT
        '
        Me.STUDENTCOUNT.DataPropertyName = "STUDENTCOUNT"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.NullValue = "0"
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.STUDENTCOUNT.DefaultCellStyle = DataGridViewCellStyle8
        Me.STUDENTCOUNT.HeaderText = "利用者数"
        Me.STUDENTCOUNT.Name = "STUDENTCOUNT"
        Me.STUDENTCOUNT.ReadOnly = True
        Me.STUDENTCOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.STUDENTCOUNT.Width = 80
        '
        'USESTART
        '
        Me.USESTART.DataPropertyName = "USESTART"
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = "2012/03/29"
        Me.USESTART.DefaultCellStyle = DataGridViewCellStyle9
        Me.USESTART.HeaderText = "利用開始日"
        Me.USESTART.Name = "USESTART"
        Me.USESTART.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'USEEND
        '
        Me.USEEND.DataPropertyName = "USEEND"
        DataGridViewCellStyle10.Format = "d"
        DataGridViewCellStyle10.NullValue = "2012/03/29"
        Me.USEEND.DefaultCellStyle = DataGridViewCellStyle10
        Me.USEEND.HeaderText = "利用終了日"
        Me.USEEND.Name = "USEEND"
        Me.USEEND.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'STATE
        '
        Me.STATE.DataPropertyName = "STATE"
        DataGridViewCellStyle11.NullValue = "利用終了"
        Me.STATE.DefaultCellStyle = DataGridViewCellStyle11
        Me.STATE.HeaderText = "状態"
        Me.STATE.Items.AddRange(New Object() {"利用終了", "利用中", "準備中"})
        Me.STATE.Name = "STATE"
        Me.STATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.STATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.STATE.Width = 85
        '
        'COLLECTION
        '
        Me.COLLECTION.DataPropertyName = "COLLECTION"
        Me.COLLECTION.HeaderText = "COLLECTION"
        Me.COLLECTION.Name = "COLLECTION"
        Me.COLLECTION.ReadOnly = True
        Me.COLLECTION.Visible = False
        '
        'CREATE_DATE
        '
        Me.CREATE_DATE.DataPropertyName = "CREATE_DATE"
        Me.CREATE_DATE.HeaderText = "CREATE_DATE"
        Me.CREATE_DATE.Name = "CREATE_DATE"
        Me.CREATE_DATE.ReadOnly = True
        Me.CREATE_DATE.Visible = False
        '
        'UPDATE_DATE
        '
        Me.UPDATE_DATE.DataPropertyName = "UPDATE_DATE"
        Me.UPDATE_DATE.HeaderText = "UPDATE_DATE"
        Me.UPDATE_DATE.Name = "UPDATE_DATE"
        Me.UPDATE_DATE.ReadOnly = True
        Me.UPDATE_DATE.Visible = False
        '
        'frmCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.lblTitel)
        Me.Controls.Add(Me.lbl03)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnBackSystemManager)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvCourseList)
        Me.Name = "frmCourse"
        Me.Text = "コース登録/確認"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.dgvCourseList, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnBackSystemManager, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.lbl03, 0)
        Me.Controls.SetChildIndex(Me.lblTitel, 0)
        Me.Controls.SetChildIndex(Me.lblLine, 0)
        CType(Me.dgvCourseList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCourseList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdbCopy As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNon As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNew As System.Windows.Forms.RadioButton
    Friend WithEvents lbl02 As System.Windows.Forms.Label
    Friend WithEvents txtCourse As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtCourseNo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBackSystemManager As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents lbl04 As System.Windows.Forms.Label
    Friend WithEvents lbl03 As System.Windows.Forms.Label
    Friend WithEvents cmbMockTest As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTitel As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents COURSENO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COURSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOCKTESTNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MINI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MIDDLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STUDENTCOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USESTART As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USEEND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATE As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents COLLECTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATE_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UPDATE_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
