<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionMenu
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvCategoryList = New System.Windows.Forms.DataGridView()
        Me.pnlTotal = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblMiddle = New System.Windows.Forms.Label()
        Me.lblMini = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnCollectionMiddle = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnBackCourse = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LabelLine = New System.Windows.Forms.Label()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.CATEGORY1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORY2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYNAME = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.SELECTNUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARENTCATEGORYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAPARENTCATEGORYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DISPLAYID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCategoryList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(50, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(209, 19)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "演習問題群登録メニュー"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(60, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 15)
        Me.Label9.TabIndex = 125
        Me.Label9.Text = "【小問】"
        '
        'dgvCategoryList
        '
        Me.dgvCategoryList.AllowUserToAddRows = False
        Me.dgvCategoryList.AllowUserToDeleteRows = False
        Me.dgvCategoryList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategoryList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCategoryList.ColumnHeadersHeight = 34
        Me.dgvCategoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCategoryList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CATEGORY1, Me.CATEGORY2, Me.CATEGORYNAME, Me.SELECTNUM, Me.TOTAL, Me.CATEGORYID, Me.PARENTCATEGORYID, Me.PAPARENTCATEGORYID, Me.DISPLAYID})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCategoryList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCategoryList.EnableHeadersVisualStyles = False
        Me.dgvCategoryList.Location = New System.Drawing.Point(73, 183)
        Me.dgvCategoryList.Name = "dgvCategoryList"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategoryList.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCategoryList.RowHeadersVisible = False
        Me.dgvCategoryList.RowTemplate.Height = 21
        Me.dgvCategoryList.Size = New System.Drawing.Size(664, 372)
        Me.dgvCategoryList.TabIndex = 126
        '
        'pnlTotal
        '
        Me.pnlTotal.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotal.Controls.Add(Me.Label15)
        Me.pnlTotal.Controls.Add(Me.Label14)
        Me.pnlTotal.Controls.Add(Me.Label5)
        Me.pnlTotal.Controls.Add(Me.Label13)
        Me.pnlTotal.Controls.Add(Me.lblTotal)
        Me.pnlTotal.Controls.Add(Me.lblMiddle)
        Me.pnlTotal.Controls.Add(Me.lblMini)
        Me.pnlTotal.Controls.Add(Me.Label6)
        Me.pnlTotal.Controls.Add(Me.Label11)
        Me.pnlTotal.Location = New System.Drawing.Point(756, 435)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.Size = New System.Drawing.Size(250, 120)
        Me.pnlTotal.TabIndex = 127
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(155, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 15)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "問"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(155, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 15)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "問 × ４設問"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(155, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 15)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "問"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(38, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "総数"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(88, 80)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(61, 22)
        Me.lblTotal.TabIndex = 129
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMiddle
        '
        Me.lblMiddle.BackColor = System.Drawing.Color.White
        Me.lblMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMiddle.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMiddle.Location = New System.Drawing.Point(88, 46)
        Me.lblMiddle.Name = "lblMiddle"
        Me.lblMiddle.Size = New System.Drawing.Size(61, 22)
        Me.lblMiddle.TabIndex = 128
        Me.lblMiddle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMini
        '
        Me.lblMini.BackColor = System.Drawing.Color.White
        Me.lblMini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMini.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMini.Location = New System.Drawing.Point(88, 13)
        Me.lblMini.Name = "lblMini"
        Me.lblMini.Size = New System.Drawing.Size(61, 22)
        Me.lblMini.TabIndex = 123
        Me.lblMini.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "中問合計"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "小問合計"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(60, 570)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 15)
        Me.Label16.TabIndex = 128
        Me.Label16.Text = "【中問】"
        '
        'btnCollectionMiddle
        '
        Me.btnCollectionMiddle.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnCollectionMiddle.Location = New System.Drawing.Point(88, 598)
        Me.btnCollectionMiddle.Name = "btnCollectionMiddle"
        Me.btnCollectionMiddle.Size = New System.Drawing.Size(160, 30)
        Me.btnCollectionMiddle.TabIndex = 129
        Me.btnCollectionMiddle.Text = "中問一覧表示"
        Me.btnCollectionMiddle.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnAdd.Location = New System.Drawing.Point(803, 598)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(210, 30)
        Me.btnAdd.TabIndex = 130
        Me.btnAdd.Text = "演習問題群登録"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnBackCourse
        '
        Me.btnBackCourse.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBackCourse.Location = New System.Drawing.Point(803, 662)
        Me.btnBackCourse.Name = "btnBackCourse"
        Me.btnBackCourse.Size = New System.Drawing.Size(210, 30)
        Me.btnBackCourse.TabIndex = 131
        Me.btnBackCourse.Text = "コース登録/確認へ戻る"
        Me.btnBackCourse.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(76, 187)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(350, 15)
        Me.Label17.TabIndex = 134
        Me.Label17.Text = "分類"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelLine
        '
        Me.LabelLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelLine.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelLine.Location = New System.Drawing.Point(75, 201)
        Me.LabelLine.Name = "LabelLine"
        Me.LabelLine.Size = New System.Drawing.Size(438, 1)
        Me.LabelLine.TabIndex = 135
        Me.LabelLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(380, 12)
        Me.lblTree.TabIndex = 185
        Me.lblTree.Text = "システム管理者メインメニュー ＞ コース登録/確認 ＞ 演習問題群登録メニュー"
        '
        'CATEGORY1
        '
        Me.CATEGORY1.DataPropertyName = "CATEGORY1"
        Me.CATEGORY1.HeaderText = "分野"
        Me.CATEGORY1.Name = "CATEGORY1"
        Me.CATEGORY1.ReadOnly = True
        Me.CATEGORY1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORY1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CATEGORY2
        '
        Me.CATEGORY2.DataPropertyName = "CATEGORY2"
        Me.CATEGORY2.HeaderText = "大分類"
        Me.CATEGORY2.Name = "CATEGORY2"
        Me.CATEGORY2.ReadOnly = True
        Me.CATEGORY2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORY2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CATEGORY2.Width = 140
        '
        'CATEGORYNAME
        '
        Me.CATEGORYNAME.DataPropertyName = "CATEGORYNAME"
        Me.CATEGORYNAME.HeaderText = "中分類"
        Me.CATEGORYNAME.Name = "CATEGORYNAME"
        Me.CATEGORYNAME.ReadOnly = True
        Me.CATEGORYNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CATEGORYNAME.Width = 200
        '
        'SELECTNUM
        '
        Me.SELECTNUM.DataPropertyName = "SELECTNUM"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SELECTNUM.DefaultCellStyle = DataGridViewCellStyle2
        Me.SELECTNUM.HeaderText = "選択数"
        Me.SELECTNUM.Name = "SELECTNUM"
        Me.SELECTNUM.ReadOnly = True
        Me.SELECTNUM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SELECTNUM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TOTAL
        '
        Me.TOTAL.DataPropertyName = "TOTAL"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TOTAL.DefaultCellStyle = DataGridViewCellStyle3
        Me.TOTAL.HeaderText = "全問題数"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        Me.TOTAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CATEGORYID
        '
        Me.CATEGORYID.DataPropertyName = "CATEGORYID"
        Me.CATEGORYID.HeaderText = "CATEGORYID"
        Me.CATEGORYID.Name = "CATEGORYID"
        Me.CATEGORYID.Visible = False
        '
        'PARENTCATEGORYID
        '
        Me.PARENTCATEGORYID.DataPropertyName = "PARENTCATEGORYID"
        Me.PARENTCATEGORYID.HeaderText = "PARENTCATEGORYID"
        Me.PARENTCATEGORYID.Name = "PARENTCATEGORYID"
        Me.PARENTCATEGORYID.Visible = False
        '
        'PAPARENTCATEGORYID
        '
        Me.PAPARENTCATEGORYID.DataPropertyName = "PAPARENTCATEGORYID"
        Me.PAPARENTCATEGORYID.HeaderText = "PAPARENTCATEGORYID"
        Me.PAPARENTCATEGORYID.Name = "PAPARENTCATEGORYID"
        Me.PAPARENTCATEGORYID.Visible = False
        '
        'DISPLAYID
        '
        Me.DISPLAYID.DataPropertyName = "DISPLAYID"
        Me.DISPLAYID.HeaderText = "DISPLAYID"
        Me.DISPLAYID.Name = "DISPLAYID"
        Me.DISPLAYID.Visible = False
        '
        'frmCollectionMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.LabelLine)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnBackCourse)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCollectionMiddle)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.pnlTotal)
        Me.Controls.Add(Me.dgvCategoryList)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Name = "frmCollectionMenu"
        Me.Text = "演習問題群登録メニュー"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dgvCategoryList, 0)
        Me.Controls.SetChildIndex(Me.pnlTotal, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.btnCollectionMiddle, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnBackCourse, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.LabelLine, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        CType(Me.dgvCategoryList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotal.ResumeLayout(False)
        Me.pnlTotal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvCategoryList As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTotal As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblMiddle As System.Windows.Forms.Label
    Friend WithEvents lblMini As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnCollectionMiddle As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnBackCourse As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LabelLine As System.Windows.Forms.Label
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents CATEGORY1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORY2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYNAME As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents SELECTNUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CATEGORYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARENTCATEGORYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAPARENTCATEGORYID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISPLAYID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
