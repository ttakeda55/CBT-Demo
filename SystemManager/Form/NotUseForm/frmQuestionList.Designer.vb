<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestionList
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
        Me.dgvQuestionList = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnBackQuestionManager = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.TESTNAME = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.UPDATE_DATE_DISPLAY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USECOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOCKTESTNO = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.USESTART = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USEEND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATE = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.UPDATE_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvQuestionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvQuestionList
        '
        Me.dgvQuestionList.AllowUserToAddRows = False
        Me.dgvQuestionList.AllowUserToDeleteRows = False
        Me.dgvQuestionList.AllowUserToResizeColumns = False
        Me.dgvQuestionList.AllowUserToResizeRows = False
        Me.dgvQuestionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuestionList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TESTNAME, Me.UPDATE_DATE_DISPLAY, Me.USECOUNT, Me.MOCKTESTNO, Me.USESTART, Me.USEEND, Me.STATE, Me.UPDATE_DATE})
        Me.dgvQuestionList.Location = New System.Drawing.Point(113, 180)
        Me.dgvQuestionList.MultiSelect = False
        Me.dgvQuestionList.Name = "dgvQuestionList"
        Me.dgvQuestionList.RowHeadersVisible = False
        Me.dgvQuestionList.RowTemplate.Height = 21
        Me.dgvQuestionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvQuestionList.Size = New System.Drawing.Size(783, 400)
        Me.dgvQuestionList.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "模擬テスト一覧"
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(799, 603)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(97, 30)
        Me.btnUpdate.TabIndex = 39
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnBackQuestionManager
        '
        Me.btnBackQuestionManager.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackQuestionManager.Location = New System.Drawing.Point(803, 663)
        Me.btnBackQuestionManager.Name = "btnBackQuestionManager"
        Me.btnBackQuestionManager.Size = New System.Drawing.Size(210, 30)
        Me.btnBackQuestionManager.TabIndex = 151
        Me.btnBackQuestionManager.Text = "問題確認メニューへ戻る"
        Me.btnBackQuestionManager.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(440, 12)
        Me.lblTree.TabIndex = 205
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 問題管理メニュー ＞ 問題確認メニュー ＞ 模擬テスト一覧"
        '
        'TESTNAME
        '
        Me.TESTNAME.DataPropertyName = "TESTNAME"
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.TESTNAME.DefaultCellStyle = DataGridViewCellStyle1
        Me.TESTNAME.HeaderText = "テスト名"
        Me.TESTNAME.Name = "TESTNAME"
        Me.TESTNAME.ReadOnly = True
        Me.TESTNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TESTNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TESTNAME.Width = 200
        '
        'UPDATE_DATE_DISPLAY
        '
        Me.UPDATE_DATE_DISPLAY.DataPropertyName = "UPDATE_DATE_DISPLAY"
        DataGridViewCellStyle2.Format = "d"
        Me.UPDATE_DATE_DISPLAY.DefaultCellStyle = DataGridViewCellStyle2
        Me.UPDATE_DATE_DISPLAY.HeaderText = "更新日"
        Me.UPDATE_DATE_DISPLAY.Name = "UPDATE_DATE_DISPLAY"
        Me.UPDATE_DATE_DISPLAY.ReadOnly = True
        Me.UPDATE_DATE_DISPLAY.Width = 80
        '
        'USECOUNT
        '
        Me.USECOUNT.DataPropertyName = "USECOUNT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "#人"
        DataGridViewCellStyle3.NullValue = "0"
        Me.USECOUNT.DefaultCellStyle = DataGridViewCellStyle3
        Me.USECOUNT.HeaderText = "利用者数"
        Me.USECOUNT.Name = "USECOUNT"
        Me.USECOUNT.ReadOnly = True
        Me.USECOUNT.Width = 80
        '
        'MOCKTESTNO
        '
        Me.MOCKTESTNO.DataPropertyName = "MOCKTESTNO"
        Me.MOCKTESTNO.HeaderText = "対応模擬テスト"
        Me.MOCKTESTNO.Name = "MOCKTESTNO"
        Me.MOCKTESTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MOCKTESTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MOCKTESTNO.Width = 120
        '
        'USESTART
        '
        Me.USESTART.DataPropertyName = "USESTART"
        DataGridViewCellStyle4.Format = "d"
        Me.USESTART.DefaultCellStyle = DataGridViewCellStyle4
        Me.USESTART.HeaderText = "利用開始日"
        Me.USESTART.Name = "USESTART"
        '
        'USEEND
        '
        Me.USEEND.DataPropertyName = "USEEND"
        DataGridViewCellStyle5.Format = "d"
        Me.USEEND.DefaultCellStyle = DataGridViewCellStyle5
        Me.USEEND.HeaderText = "利用終了日"
        Me.USEEND.Name = "USEEND"
        '
        'STATE
        '
        Me.STATE.DataPropertyName = "STATE"
        Me.STATE.HeaderText = "状態"
        Me.STATE.Items.AddRange(New Object() {"", "削除"})
        Me.STATE.Name = "STATE"
        Me.STATE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.STATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.STATE.Width = 80
        '
        'UPDATE_DATE
        '
        Me.UPDATE_DATE.DataPropertyName = "UPDATE_DATE"
        Me.UPDATE_DATE.HeaderText = "更新日_バインド"
        Me.UPDATE_DATE.Name = "UPDATE_DATE"
        Me.UPDATE_DATE.Visible = False
        '
        'frmQuestionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.dgvQuestionList)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnBackQuestionManager)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmQuestionList"
        Me.Text = "模擬テスト一覧"
        Me.Controls.SetChildIndex(Me.btnUpdate, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.btnBackQuestionManager, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.dgvQuestionList, 0)
        CType(Me.dgvQuestionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvQuestionList As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnBackQuestionManager As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents TESTNAME As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents UPDATE_DATE_DISPLAY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USECOUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOCKTESTNO As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents USESTART As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USEEND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATE As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents UPDATE_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
