<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmTestEnd
    Inherits System.Windows.Forms.Form

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
Me.btnOK = New System.Windows.Forms.Button()
Me.lblBody = New System.Windows.Forms.Label()
Me.btnCancel = New System.Windows.Forms.Button()
Me.SuspendLayout()
'
'btnOK
'
Me.btnOK.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.btnOK.Location = New System.Drawing.Point(102, 104)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(91, 34)
Me.btnOK.TabIndex = 3
Me.btnOK.Text = "OK"
Me.btnOK.UseVisualStyleBackColor = True
'
'lblBody
'
Me.lblBody.AutoSize = True
Me.lblBody.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.lblBody.Location = New System.Drawing.Point(99, 31)
Me.lblBody.Name = "lblBody"
Me.lblBody.Size = New System.Drawing.Size(179, 30)
Me.lblBody.TabIndex = 2
Me.lblBody.Text = "テストを終了して採点します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "よろしいですか？"
Me.lblBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'btnCancel
'
Me.btnCancel.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.btnCancel.Location = New System.Drawing.Point(225, 104)
Me.btnCancel.Name = "btnCancel"
Me.btnCancel.Size = New System.Drawing.Size(91, 34)
Me.btnCancel.TabIndex = 3
Me.btnCancel.Text = "キャンセル"
Me.btnCancel.UseVisualStyleBackColor = True
'
'frmConfirmTestEnd
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(408, 163)
Me.Controls.Add(Me.btnCancel)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.lblBody)
Me.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.Margin = New System.Windows.Forms.Padding(4)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "frmConfirmTestEnd"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.TopMost = True
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblBody As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
