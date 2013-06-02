<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStudentImport
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
        Me.btnDataCheck = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnReference = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBackStudent = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(0, 19)
        Me.lblTitle01.Text = ""
        '
        'btnDataCheck
        '
        Me.btnDataCheck.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDataCheck.Location = New System.Drawing.Point(219, 370)
        Me.btnDataCheck.Name = "btnDataCheck"
        Me.btnDataCheck.Size = New System.Drawing.Size(136, 51)
        Me.btnDataCheck.TabIndex = 60
        Me.btnDataCheck.Text = "データチェック"
        Me.btnDataCheck.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtFilePath.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFilePath.Location = New System.Drawing.Point(324, 267)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(380, 22)
        Me.txtFilePath.TabIndex = 40
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(217, 270)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 15)
        Me.Label12.TabIndex = 130
        Me.Label12.Text = "CSVファイル名"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 19)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "受講者一括登録"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(410, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(278, 15)
        Me.Label16.TabIndex = 125
        Me.Label16.Text = "①受講者を登録する団体を指定してください。"
        Me.Label16.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(178, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(208, 15)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "①CSVファイルを指定してください。"
        '
        'btnReference
        '
        Me.btnReference.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnReference.Location = New System.Drawing.Point(727, 262)
        Me.btnReference.Name = "btnReference"
        Me.btnReference.Size = New System.Drawing.Size(72, 30)
        Me.btnReference.TabIndex = 50
        Me.btnReference.Text = "参照"
        Me.btnReference.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(178, 327)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(264, 15)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "②CSVファイルのデータチェックをしてください。"
        '
        'btnBackStudent
        '
        Me.btnBackStudent.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackStudent.Location = New System.Drawing.Point(791, 663)
        Me.btnBackStudent.Name = "btnBackStudent"
        Me.btnBackStudent.Size = New System.Drawing.Size(222, 30)
        Me.btnBackStudent.TabIndex = 70
        Me.btnBackStudent.Text = "受講者登録／修正メニューへ戻る"
        Me.btnBackStudent.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(371, 12)
        Me.lblTree.TabIndex = 202
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 受講者登録／修正メニュー ＞ 受講者登録"
        Me.lblTree.Visible = False
        '
        'frmStudentImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnBackStudent)
        Me.Controls.Add(Me.btnReference)
        Me.Controls.Add(Me.btnDataCheck)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmStudentImport"
        Me.Text = "frmMenberImport"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtFilePath, 0)
        Me.Controls.SetChildIndex(Me.btnDataCheck, 0)
        Me.Controls.SetChildIndex(Me.btnReference, 0)
        Me.Controls.SetChildIndex(Me.btnBackStudent, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDataCheck As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnReference As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBackStudent As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
End Class
