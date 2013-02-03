<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmallPracticeDetail
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAllChk = New System.Windows.Forms.Button()
        Me.btnBackPracticeMenu = New System.Windows.Forms.Button()
        Me.grdJhoken = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblKeiretu = New System.Windows.Forms.Label()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Size = New System.Drawing.Size(9, 12)
        Me.lblBottomCode.Text = " "
        '
        'lblBottomName
        '
        Me.lblBottomName.Size = New System.Drawing.Size(13, 16)
        Me.lblBottomName.Text = " "
        '
        'btnAllChk
        '
        Me.btnAllChk.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllChk.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAllChk.Location = New System.Drawing.Point(626, 131)
        Me.btnAllChk.Name = "btnAllChk"
        Me.btnAllChk.Size = New System.Drawing.Size(112, 25)
        Me.btnAllChk.TabIndex = 1
        Me.btnAllChk.UseVisualStyleBackColor = True
        '
        'btnBackPracticeMenu
        '
        Me.btnBackPracticeMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackPracticeMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackPracticeMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackPracticeMenu.Name = "btnBackPracticeMenu"
        Me.btnBackPracticeMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackPracticeMenu.TabIndex = 3
        Me.btnBackPracticeMenu.Text = "閉じる"
        Me.btnBackPracticeMenu.UseVisualStyleBackColor = True
        '
        'grdJhoken
        '
        Me.grdJhoken.AllowUserToAddRows = False
        Me.grdJhoken.AllowUserToDeleteRows = False
        Me.grdJhoken.AllowUserToResizeColumns = False
        Me.grdJhoken.AllowUserToResizeRows = False
        Me.grdJhoken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdJhoken.ColumnHeadersVisible = False
        Me.grdJhoken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdJhoken.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdJhoken.Location = New System.Drawing.Point(16, 182)
        Me.grdJhoken.Name = "grdJhoken"
        Me.grdJhoken.RowHeadersVisible = False
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(3)
        Me.grdJhoken.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grdJhoken.RowTemplate.Height = 21
        Me.grdJhoken.Size = New System.Drawing.Size(740, 444)
        Me.grdJhoken.TabIndex = 2
        Me.grdJhoken.TabStop = False
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(267, 158)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(471, 25)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "キーワード"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(67, 158)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(201, 25)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "グループ"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 25)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "選択"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(189, 19)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "小問逐次演習メニュー"
        '
        'lblKeiretu
        '
        Me.lblKeiretu.AutoSize = True
        Me.lblKeiretu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKeiretu.Location = New System.Drawing.Point(24, 136)
        Me.lblKeiretu.Name = "lblKeiretu"
        Me.lblKeiretu.Size = New System.Drawing.Size(12, 15)
        Me.lblKeiretu.TabIndex = 62
        Me.lblKeiretu.Text = " "
        '
        'Column6
        '
        Me.Column6.HeaderText = "選択"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column6.Width = 50
        '
        'Column1
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "グループ"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.Width = 200
        '
        'Column2
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3)
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "キーワード"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column2.Width = 470
        '
        'frmSmallPracticeDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblKeiretu)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grdJhoken)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnAllChk)
        Me.Controls.Add(Me.btnBackPracticeMenu)
        Me.Name = "frmSmallPracticeDetail"
        Me.Text = "frmSmallPracticeDetail"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.btnBackPracticeMenu, 0)
        Me.Controls.SetChildIndex(Me.btnAllChk, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.grdJhoken, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblKeiretu, 0)
        CType(Me.grdJhoken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAllChk As System.Windows.Forms.Button
    Friend WithEvents btnBackPracticeMenu As System.Windows.Forms.Button
    Friend WithEvents grdJhoken As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblKeiretu As System.Windows.Forms.Label
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
