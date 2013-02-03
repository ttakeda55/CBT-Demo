<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategory
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvCategory = New System.Windows.Forms.DataGridView()
        Me.trvCategory = New System.Windows.Forms.TreeView()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnBackQuestionManager = New System.Windows.Forms.Button()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.txtKeyWord = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnRowAdd = New System.Windows.Forms.Button()
        Me.btnRowDelete = New System.Windows.Forms.Button()
        Me.lblTotalCount = New System.Windows.Forms.Label()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.colCategoryId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collevelQuestionCount1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collevelQuestionCount2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collevelQuestionCount3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colParentCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 19)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "グループ登録"
        '
        'dgvCategory
        '
        Me.dgvCategory.AllowUserToAddRows = False
        Me.dgvCategory.AllowUserToDeleteRows = False
        Me.dgvCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCategory.ColumnHeadersHeight = 34
        Me.dgvCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCategoryId, Me.colCategoryName, Me.collevelQuestionCount1, Me.collevelQuestionCount2, Me.collevelQuestionCount3, Me.colParentCategoryID})
        Me.dgvCategory.EnableHeadersVisualStyles = False
        Me.dgvCategory.Location = New System.Drawing.Point(307, 192)
        Me.dgvCategory.MultiSelect = False
        Me.dgvCategory.Name = "dgvCategory"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCategory.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCategory.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgvCategory.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCategory.RowTemplate.Height = 21
        Me.dgvCategory.Size = New System.Drawing.Size(588, 379)
        Me.dgvCategory.TabIndex = 20
        '
        'trvCategory
        '
        Me.trvCategory.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.trvCategory.HideSelection = False
        Me.trvCategory.Location = New System.Drawing.Point(51, 192)
        Me.trvCategory.Name = "trvCategory"
        Me.trvCategory.Size = New System.Drawing.Size(250, 379)
        Me.trvCategory.TabIndex = 10
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(797, 601)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(98, 30)
        Me.btnUpdate.TabIndex = 60
        Me.btnUpdate.Text = "登録／修正"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnBackQuestionManager
        '
        Me.btnBackQuestionManager.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackQuestionManager.Location = New System.Drawing.Point(803, 662)
        Me.btnBackQuestionManager.Name = "btnBackQuestionManager"
        Me.btnBackQuestionManager.Size = New System.Drawing.Size(210, 30)
        Me.btnBackQuestionManager.TabIndex = 70
        Me.btnBackQuestionManager.Text = "問題管理メニューへ戻る"
        Me.btnBackQuestionManager.UseVisualStyleBackColor = True
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(311, 12)
        Me.lblTree.TabIndex = 206
        Me.lblTree.Text = "システム管理者メインメニュー ＞ 問題管理メニュー ＞ 分類登録"
        Me.lblTree.Visible = False
        '
        'txtKeyWord
        '
        Me.txtKeyWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKeyWord.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtKeyWord.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtKeyWord.Location = New System.Drawing.Point(341, 129)
        Me.txtKeyWord.Multiline = True
        Me.txtKeyWord.Name = "txtKeyWord"
        Me.txtKeyWord.Size = New System.Drawing.Size(538, 37)
        Me.txtKeyWord.TabIndex = 50
        Me.txtKeyWord.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label16.Location = New System.Drawing.Point(247, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 15)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "キーワード"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Location = New System.Drawing.Point(341, 107)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(538, 23)
        Me.Panel5.TabIndex = 208
        Me.Panel5.Visible = False
        '
        'btnRowAdd
        '
        Me.btnRowAdd.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRowAdd.Location = New System.Drawing.Point(568, 601)
        Me.btnRowAdd.Name = "btnRowAdd"
        Me.btnRowAdd.Size = New System.Drawing.Size(98, 30)
        Me.btnRowAdd.TabIndex = 30
        Me.btnRowAdd.Text = "行追加"
        Me.btnRowAdd.UseVisualStyleBackColor = True
        '
        'btnRowDelete
        '
        Me.btnRowDelete.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnRowDelete.Location = New System.Drawing.Point(672, 601)
        Me.btnRowDelete.Name = "btnRowDelete"
        Me.btnRowDelete.Size = New System.Drawing.Size(98, 30)
        Me.btnRowDelete.TabIndex = 40
        Me.btnRowDelete.Text = "行削除"
        Me.btnRowDelete.UseVisualStyleBackColor = True
        '
        'lblTotalCount
        '
        Me.lblTotalCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCount.AutoSize = True
        Me.lblTotalCount.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lblTotalCount.Location = New System.Drawing.Point(838, 172)
        Me.lblTotalCount.Name = "lblTotalCount"
        Me.lblTotalCount.Size = New System.Drawing.Size(30, 15)
        Me.lblTotalCount.TabIndex = 209
        Me.lblTotalCount.Text = "0問"
        '
        'LabelHeader
        '
        Me.LabelHeader.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.LabelHeader.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LabelHeader.Location = New System.Drawing.Point(697, 174)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(115, 15)
        Me.LabelHeader.TabIndex = 210
        Me.LabelHeader.Text = "難易度別出題数"
        Me.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelHeader.Visible = False
        '
        'colCategoryId
        '
        Me.colCategoryId.DataPropertyName = "DISPLAYID"
        Me.colCategoryId.HeaderText = "グループID"
        Me.colCategoryId.Name = "colCategoryId"
        Me.colCategoryId.Width = 80
        '
        'colCategoryName
        '
        Me.colCategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colCategoryName.DataPropertyName = "CATEGORYNAME"
        Me.colCategoryName.HeaderText = "グループ名"
        Me.colCategoryName.Name = "colCategoryName"
        Me.colCategoryName.Width = 200
        '
        'collevelQuestionCount1
        '
        Me.collevelQuestionCount1.DataPropertyName = "LEVELQUESTIONCOUNT1"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.collevelQuestionCount1.DefaultCellStyle = DataGridViewCellStyle2
        Me.collevelQuestionCount1.HeaderText = "登録済数"
        Me.collevelQuestionCount1.Name = "collevelQuestionCount1"
        Me.collevelQuestionCount1.ReadOnly = True
        Me.collevelQuestionCount1.Width = 80
        '
        'collevelQuestionCount2
        '
        Me.collevelQuestionCount2.DataPropertyName = "LEVELQUESTIONCOUNT2"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.collevelQuestionCount2.DefaultCellStyle = DataGridViewCellStyle3
        Me.collevelQuestionCount2.HeaderText = "出題済数"
        Me.collevelQuestionCount2.Name = "collevelQuestionCount2"
        Me.collevelQuestionCount2.ReadOnly = True
        Me.collevelQuestionCount2.Width = 80
        '
        'collevelQuestionCount3
        '
        Me.collevelQuestionCount3.DataPropertyName = "LEVELQUESTIONCOUNT3"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.collevelQuestionCount3.DefaultCellStyle = DataGridViewCellStyle4
        Me.collevelQuestionCount3.HeaderText = "抽出基準"
        Me.collevelQuestionCount3.Name = "collevelQuestionCount3"
        Me.collevelQuestionCount3.Width = 80
        '
        'colParentCategoryID
        '
        Me.colParentCategoryID.DataPropertyName = "PARENTCATEGORYID"
        Me.colParentCategoryID.HeaderText = "親ID"
        Me.colParentCategoryID.Name = "colParentCategoryID"
        Me.colParentCategoryID.ReadOnly = True
        Me.colParentCategoryID.Visible = False
        '
        'frmCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.lblTotalCount)
        Me.Controls.Add(Me.trvCategory)
        Me.Controls.Add(Me.dgvCategory)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.txtKeyWord)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.btnBackQuestionManager)
        Me.Controls.Add(Me.btnRowDelete)
        Me.Controls.Add(Me.btnRowAdd)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmCategory"
        Me.Text = "グループ登録"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnUpdate, 0)
        Me.Controls.SetChildIndex(Me.btnRowAdd, 0)
        Me.Controls.SetChildIndex(Me.btnRowDelete, 0)
        Me.Controls.SetChildIndex(Me.btnBackQuestionManager, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.txtKeyWord, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.dgvCategory, 0)
        Me.Controls.SetChildIndex(Me.trvCategory, 0)
        Me.Controls.SetChildIndex(Me.lblTotalCount, 0)
        Me.Controls.SetChildIndex(Me.LabelHeader, 0)
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvCategory As System.Windows.Forms.DataGridView
    Friend WithEvents trvCategory As System.Windows.Forms.TreeView
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnBackQuestionManager As System.Windows.Forms.Button
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents txtKeyWord As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnRowAdd As System.Windows.Forms.Button
    Friend WithEvents btnRowDelete As System.Windows.Forms.Button
    Friend WithEvents lblTotalCount As System.Windows.Forms.Label
    Friend WithEvents LabelHeader As System.Windows.Forms.Label
    Friend WithEvents colCategoryId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collevelQuestionCount1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collevelQuestionCount2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collevelQuestionCount3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParentCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
