<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrueFalseList
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdLeftList = New System.Windows.Forms.DataGridView()
        Me.QUESTIONNO = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.colTheme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAnswer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTrueFalse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdRightList = New System.Windows.Forms.DataGridView()
        Me.QUESTIONNO2 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.grdLeftList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRightList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Location = New System.Drawing.Point(3, 665)
        '
        'lblBottomName
        '
        Me.lblBottomName.Location = New System.Drawing.Point(24, 677)
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(821, 663)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(191, 30)
        Me.btnBack.TabIndex = 86
        Me.btnBack.Text = "個人詳細結果へ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.grdLeftList)
        Me.Panel1.Controls.Add(Me.grdRightList)
        Me.Panel1.Location = New System.Drawing.Point(27, 115)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 535)
        Me.Panel1.TabIndex = 90
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 19)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "問別正誤一覧"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(195, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "（問番号をクリックすると解説を表示します。）"
        '
        'grdLeftList
        '
        Me.grdLeftList.AllowUserToAddRows = False
        Me.grdLeftList.AllowUserToDeleteRows = False
        Me.grdLeftList.AllowUserToResizeColumns = False
        Me.grdLeftList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdLeftList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdLeftList.ColumnHeadersHeight = 28
        Me.grdLeftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdLeftList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONNO, Me.colTheme, Me.colRight, Me.colAnswer, Me.colTrueFalse})
        Me.grdLeftList.EnableHeadersVisualStyles = False
        Me.grdLeftList.Location = New System.Drawing.Point(33, 41)
        Me.grdLeftList.MultiSelect = False
        Me.grdLeftList.Name = "grdLeftList"
        Me.grdLeftList.ReadOnly = True
        Me.grdLeftList.RowHeadersVisible = False
        Me.grdLeftList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grdLeftList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLeftList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.grdLeftList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLeftList.RowTemplate.Height = 21
        Me.grdLeftList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdLeftList.Size = New System.Drawing.Size(449, 491)
        Me.grdLeftList.TabIndex = 3
        '
        'QUESTIONNO
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QUESTIONNO.DefaultCellStyle = DataGridViewCellStyle2
        Me.QUESTIONNO.HeaderText = "問番号"
        Me.QUESTIONNO.Name = "QUESTIONNO"
        Me.QUESTIONNO.ReadOnly = True
        Me.QUESTIONNO.Width = 80
        '
        'colTheme
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTheme.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTheme.HeaderText = "問題テーマ"
        Me.colTheme.Name = "colTheme"
        Me.colTheme.ReadOnly = True
        Me.colTheme.Width = 170
        '
        'colRight
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRight.DefaultCellStyle = DataGridViewCellStyle4
        Me.colRight.HeaderText = "正解"
        Me.colRight.Name = "colRight"
        Me.colRight.ReadOnly = True
        Me.colRight.Width = 60
        '
        'colAnswer
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colAnswer.DefaultCellStyle = DataGridViewCellStyle5
        Me.colAnswer.HeaderText = "解答"
        Me.colAnswer.Name = "colAnswer"
        Me.colAnswer.ReadOnly = True
        Me.colAnswer.Width = 60
        '
        'colTrueFalse
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTrueFalse.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTrueFalse.HeaderText = "正誤"
        Me.colTrueFalse.Name = "colTrueFalse"
        Me.colTrueFalse.ReadOnly = True
        Me.colTrueFalse.Width = 60
        '
        'grdRightList
        '
        Me.grdRightList.AllowUserToAddRows = False
        Me.grdRightList.AllowUserToDeleteRows = False
        Me.grdRightList.AllowUserToResizeColumns = False
        Me.grdRightList.AllowUserToResizeRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdRightList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdRightList.ColumnHeadersHeight = 28
        Me.grdRightList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdRightList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONNO2, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.grdRightList.EnableHeadersVisualStyles = False
        Me.grdRightList.Location = New System.Drawing.Point(488, 41)
        Me.grdRightList.MultiSelect = False
        Me.grdRightList.Name = "grdRightList"
        Me.grdRightList.ReadOnly = True
        Me.grdRightList.RowHeadersVisible = False
        Me.grdRightList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.grdRightList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdRightList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.grdRightList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.grdRightList.RowTemplate.Height = 21
        Me.grdRightList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdRightList.Size = New System.Drawing.Size(449, 491)
        Me.grdRightList.TabIndex = 2
        '
        'QUESTIONNO2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QUESTIONNO2.DefaultCellStyle = DataGridViewCellStyle8
        Me.QUESTIONNO2.HeaderText = "問番号"
        Me.QUESTIONNO2.Name = "QUESTIONNO2"
        Me.QUESTIONNO2.ReadOnly = True
        Me.QUESTIONNO2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QUESTIONNO2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QUESTIONNO2.Width = 80
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn1.HeaderText = "問題テーマ"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 170
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "正解"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "解答"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "正誤"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTree.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(442, 12)
        Me.lblTree.TabIndex = 180
        Me.lblTree.Text = "管理者メインメニュー ＞ 個人別受験結果一覧 ＞ 個人詳細受験結果  ＞ 問別正誤一覧" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTree.Visible = False
        '
        'frmTrueFalseList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblTree)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnBack)
        Me.Name = "frmTrueFalseList"
        Me.Text = "個人問題別正誤画面"
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdLeftList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRightList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grdLeftList As System.Windows.Forms.DataGridView
    Friend WithEvents grdRightList As System.Windows.Forms.DataGridView
    Friend WithEvents QUESTIONNO As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colTheme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAnswer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTrueFalse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONNO2 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTree As System.Windows.Forms.Label
End Class
