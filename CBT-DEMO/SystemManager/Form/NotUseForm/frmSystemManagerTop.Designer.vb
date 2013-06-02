<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemManagerTop
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnStudent = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnManager = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnQuestion = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnInitialize = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Location = New System.Drawing.Point(2, 664)
        '
        'lblBottomName
        '
        Me.lblBottomName.Location = New System.Drawing.Point(23, 676)
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
        Me.Label5.Size = New System.Drawing.Size(113, 19)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "メインメニュー"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnStudent)
        Me.Panel2.Location = New System.Drawing.Point(196, 273)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 80)
        Me.Panel2.TabIndex = 110
        '
        'btnStudent
        '
        Me.btnStudent.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnStudent.Location = New System.Drawing.Point(24, 24)
        Me.btnStudent.Name = "btnStudent"
        Me.btnStudent.Size = New System.Drawing.Size(150, 30)
        Me.btnStudent.TabIndex = 20
        Me.btnStudent.Text = "受講者登録／修正"
        Me.btnStudent.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnManager)
        Me.Panel3.Location = New System.Drawing.Point(196, 431)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 80)
        Me.Panel3.TabIndex = 130
        '
        'btnManager
        '
        Me.btnManager.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnManager.Location = New System.Drawing.Point(24, 24)
        Me.btnManager.Name = "btnManager"
        Me.btnManager.Size = New System.Drawing.Size(150, 30)
        Me.btnManager.TabIndex = 40
        Me.btnManager.Text = "テスト管理"
        Me.btnManager.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnQuestion)
        Me.Panel4.Location = New System.Drawing.Point(196, 352)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 80)
        Me.Panel4.TabIndex = 120
        '
        'btnQuestion
        '
        Me.btnQuestion.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnQuestion.Location = New System.Drawing.Point(24, 24)
        Me.btnQuestion.Name = "btnQuestion"
        Me.btnQuestion.Size = New System.Drawing.Size(150, 30)
        Me.btnQuestion.TabIndex = 30
        Me.btnQuestion.Text = "問題管理"
        Me.btnQuestion.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Location = New System.Drawing.Point(395, 273)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(403, 80)
        Me.Panel6.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "システムの利用者の登録"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Location = New System.Drawing.Point(395, 431)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(403, 80)
        Me.Panel7.TabIndex = 41
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(254, 15)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "受講者の得点分布や問別正解率の確認"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Location = New System.Drawing.Point(395, 352)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(403, 80)
        Me.Panel8.TabIndex = 120
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(164, 30)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "テストの問題の登録、確認" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "グループの登録、修正"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(196, 194)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 80)
        Me.Panel1.TabIndex = 100
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(24, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "試験名登録"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Location = New System.Drawing.Point(395, 194)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(403, 80)
        Me.Panel5.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "試験名を登録します。"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Label11)
        Me.Panel9.Location = New System.Drawing.Point(395, 532)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(403, 80)
        Me.Panel9.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(337, 15)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "実施済みの試験を削除し、新たな試験の準備をします。"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.White
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.btnInitialize)
        Me.Panel10.Location = New System.Drawing.Point(196, 532)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(200, 80)
        Me.Panel10.TabIndex = 140
        '
        'btnInitialize
        '
        Me.btnInitialize.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnInitialize.ForeColor = System.Drawing.Color.Red
        Me.btnInitialize.Location = New System.Drawing.Point(24, 24)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(150, 30)
        Me.btnInitialize.TabIndex = 60
        Me.btnInitialize.Text = "試験初期化"
        Me.btnInitialize.UseVisualStyleBackColor = True
        '
        'frmSystemManagerTop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmSystemManagerTop"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Panel7, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel9, 0)
        Me.Controls.SetChildIndex(Me.Panel10, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel6, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel8, 0)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnStudent As System.Windows.Forms.Button
    Friend WithEvents btnManager As System.Windows.Forms.Button
    Friend WithEvents btnQuestion As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents btnInitialize As System.Windows.Forms.Button

End Class
