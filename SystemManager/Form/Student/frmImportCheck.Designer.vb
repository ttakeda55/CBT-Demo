<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportCheck
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgvStudent = New System.Windows.Forms.DataGridView()
        Me.colUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSection1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSection2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStudentsStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStudentsEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
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
        Me.Label5.Size = New System.Drawing.Size(149, 19)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "受講者一括登録"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(132, 174)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(166, 15)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "※次の内容で登録します。"
        '
        'dgvStudent
        '
        Me.dgvStudent.AllowUserToAddRows = False
        Me.dgvStudent.AllowUserToDeleteRows = False
        Me.dgvStudent.AllowUserToResizeColumns = False
        Me.dgvStudent.AllowUserToResizeRows = False
        Me.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudent.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUserId, Me.colUserName, Me.colSection1, Me.colSection2, Me.colStudentsStart, Me.colStudentsEnd, Me.colNote})
        Me.dgvStudent.Location = New System.Drawing.Point(135, 214)
        Me.dgvStudent.Name = "dgvStudent"
        Me.dgvStudent.RowHeadersVisible = False
        Me.dgvStudent.RowTemplate.Height = 21
        Me.dgvStudent.Size = New System.Drawing.Size(720, 392)
        Me.dgvStudent.TabIndex = 30
        '
        'colUserId
        '
        Me.colUserId.HeaderText = "ユーザID"
        Me.colUserId.Name = "colUserId"
        Me.colUserId.ReadOnly = True
        Me.colUserId.Width = 200
        '
        'colUserName
        '
        Me.colUserName.HeaderText = "受講者名"
        Me.colUserName.Name = "colUserName"
        Me.colUserName.ReadOnly = True
        Me.colUserName.Width = 300
        '
        'colSection1
        '
        Me.colSection1.HeaderText = "区分１"
        Me.colSection1.Name = "colSection1"
        Me.colSection1.ReadOnly = True
        Me.colSection1.Visible = False
        Me.colSection1.Width = 65
        '
        'colSection2
        '
        Me.colSection2.HeaderText = "区分２"
        Me.colSection2.Name = "colSection2"
        Me.colSection2.ReadOnly = True
        Me.colSection2.Visible = False
        Me.colSection2.Width = 65
        '
        'colStudentsStart
        '
        Me.colStudentsStart.HeaderText = "受講開始日"
        Me.colStudentsStart.Name = "colStudentsStart"
        Me.colStudentsStart.ReadOnly = True
        Me.colStudentsStart.Visible = False
        Me.colStudentsStart.Width = 90
        '
        'colStudentsEnd
        '
        Me.colStudentsEnd.HeaderText = "受講終了日"
        Me.colStudentsEnd.Name = "colStudentsEnd"
        Me.colStudentsEnd.ReadOnly = True
        Me.colStudentsEnd.Visible = False
        Me.colStudentsEnd.Width = 90
        '
        'colNote
        '
        Me.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNote.HeaderText = "備考"
        Me.colNote.Name = "colNote"
        Me.colNote.ReadOnly = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(381, 612)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 30)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(542, 612)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 30)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmImportCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvStudent)
        Me.Name = "frmImportCheck"
        Me.Text = "frmImportCheck"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.dgvStudent, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        CType(Me.dgvStudent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgvStudent As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents colUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSection1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSection2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStudentsStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStudentsEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNote As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
