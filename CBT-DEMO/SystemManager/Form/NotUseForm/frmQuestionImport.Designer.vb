<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestionImport
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
        Me.btnReference = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.dgvError = New System.Windows.Forms.DataGridView()
        Me.colError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBackQuestionManager = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.txtTestName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTree = New System.Windows.Forms.Label()
        CType(Me.dgvError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(80, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 19)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "模擬テスト登録"
        '
        'btnReference
        '
        Me.btnReference.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnReference.Location = New System.Drawing.Point(707, 208)
        Me.btnReference.Name = "btnReference"
        Me.btnReference.Size = New System.Drawing.Size(53, 25)
        Me.btnReference.TabIndex = 50
        Me.btnReference.Text = "参照"
        Me.btnReference.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFilePath.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFilePath.Location = New System.Drawing.Point(282, 211)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(419, 22)
        Me.txtFilePath.TabIndex = 40
        '
        'dgvError
        '
        Me.dgvError.AllowUserToAddRows = False
        Me.dgvError.AllowUserToDeleteRows = False
        Me.dgvError.AllowUserToResizeColumns = False
        Me.dgvError.AllowUserToResizeRows = False
        Me.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvError.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colError})
        Me.dgvError.Location = New System.Drawing.Point(181, 247)
        Me.dgvError.Name = "dgvError"
        Me.dgvError.RowHeadersVisible = False
        Me.dgvError.RowTemplate.Height = 21
        Me.dgvError.Size = New System.Drawing.Size(677, 375)
        Me.dgvError.TabIndex = 70
        '
        'colError
        '
        Me.colError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colError.HeaderText = "エラー内容"
        Me.colError.Name = "colError"
        Me.colError.ReadOnly = True
        '
        'btnBackQuestionManager
        '
        Me.btnBackQuestionManager.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackQuestionManager.Location = New System.Drawing.Point(803, 662)
        Me.btnBackQuestionManager.Name = "btnBackQuestionManager"
        Me.btnBackQuestionManager.Size = New System.Drawing.Size(210, 30)
        Me.btnBackQuestionManager.TabIndex = 80
        Me.btnBackQuestionManager.Text = "問題登録メニューへ戻る"
        Me.btnBackQuestionManager.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnImport.Location = New System.Drawing.Point(766, 200)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(95, 41)
        Me.btnImport.TabIndex = 60
        Me.btnImport.Text = "取込"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'txtTestName
        '
        Me.txtTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtTestName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtTestName.Location = New System.Drawing.Point(282, 173)
        Me.txtTestName.Name = "txtTestName"
        Me.txtTestName.Size = New System.Drawing.Size(144, 22)
        Me.txtTestName.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(181, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 15)
        Me.Label12.TabIndex = 144
        Me.Label12.Text = "Wordファイル名"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(179, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 144
        Me.Label6.Text = "テスト名"
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(444, 12)
        Me.lblTree.TabIndex = 204
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 問題管理メニュー ＞ 問題登録メニュー ＞  模擬テスト登録"
        '
        'frmQuestionImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnBackQuestionManager)
        Me.Controls.Add(Me.dgvError)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnReference)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTestName)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmQuestionImport"
        Me.Text = "frmQuestionImport"
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtTestName, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtFilePath, 0)
        Me.Controls.SetChildIndex(Me.btnReference, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnImport, 0)
        Me.Controls.SetChildIndex(Me.dgvError, 0)
        Me.Controls.SetChildIndex(Me.btnBackQuestionManager, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        CType(Me.dgvError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnReference As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents dgvError As System.Windows.Forms.DataGridView
    Friend WithEvents colError As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBackQuestionManager As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents txtTestName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTree As System.Windows.Forms.Label
End Class
