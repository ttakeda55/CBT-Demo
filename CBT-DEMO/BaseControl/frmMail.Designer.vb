<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.txtMailLog = New System.Windows.Forms.TextBox()
        Me.txtMail = New System.Windows.Forms.TextBox()
        Me.btnSendMail = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblBottomName = New System.Windows.Forms.Label()
        Me.lblBottomCode = New System.Windows.Forms.Label()
        Me.dgvUser = New System.Windows.Forms.DataGridView()
        Me.colUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMessage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(22, 27)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(57, 19)
        Me.lblLogin.TabIndex = 36
        Me.lblLogin.Text = "メール"
        '
        'txtMailLog
        '
        Me.txtMailLog.BackColor = System.Drawing.Color.White
        Me.txtMailLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMailLog.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMailLog.Location = New System.Drawing.Point(318, 90)
        Me.txtMailLog.Multiline = True
        Me.txtMailLog.Name = "txtMailLog"
        Me.txtMailLog.ReadOnly = True
        Me.txtMailLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMailLog.Size = New System.Drawing.Size(443, 258)
        Me.txtMailLog.TabIndex = 39
        Me.txtMailLog.TabStop = False
        '
        'txtMail
        '
        Me.txtMail.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMail.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtMail.Location = New System.Drawing.Point(318, 386)
        Me.txtMail.Multiline = True
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Size = New System.Drawing.Size(443, 119)
        Me.txtMail.TabIndex = 30
        '
        'btnSendMail
        '
        Me.btnSendMail.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSendMail.Location = New System.Drawing.Point(686, 511)
        Me.btnSendMail.Name = "btnSendMail"
        Me.btnSendMail.Size = New System.Drawing.Size(75, 30)
        Me.btnSendMail.TabIndex = 40
        Me.btnSendMail.Text = "送信"
        Me.btnSendMail.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(315, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 15)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "メール送受信履歴"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnClose.Location = New System.Drawing.Point(686, 562)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 50
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblBottomName
        '
        Me.lblBottomName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBottomName.AutoSize = True
        Me.lblBottomName.BackColor = System.Drawing.SystemColors.Control
        Me.lblBottomName.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBottomName.Location = New System.Drawing.Point(27, 589)
        Me.lblBottomName.Name = "lblBottomName"
        Me.lblBottomName.Size = New System.Drawing.Size(110, 16)
        Me.lblBottomName.TabIndex = 42
        Me.lblBottomName.Text = "lblBottomName"
        Me.lblBottomName.Visible = False
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBottomCode.AutoSize = True
        Me.lblBottomCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBottomCode.Location = New System.Drawing.Point(6, 577)
        Me.lblBottomCode.Name = "lblBottomCode"
        Me.lblBottomCode.Size = New System.Drawing.Size(80, 12)
        Me.lblBottomCode.TabIndex = 41
        Me.lblBottomCode.Text = "lblBottomCode"
        Me.lblBottomCode.Visible = False
        '
        'dgvUser
        '
        Me.dgvUser.AllowUserToAddRows = False
        Me.dgvUser.AllowUserToDeleteRows = False
        Me.dgvUser.AllowUserToResizeColumns = False
        Me.dgvUser.AllowUserToResizeRows = False
        Me.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUser, Me.colSend, Me.colReceive, Me.colUserId, Me.colMessage})
        Me.dgvUser.Location = New System.Drawing.Point(37, 90)
        Me.dgvUser.MultiSelect = False
        Me.dgvUser.Name = "dgvUser"
        Me.dgvUser.RowHeadersVisible = False
        Me.dgvUser.RowTemplate.Height = 21
        Me.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUser.Size = New System.Drawing.Size(275, 415)
        Me.dgvUser.TabIndex = 10
        '
        'colUser
        '
        Me.colUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUser.DataPropertyName = "USER"
        Me.colUser.FillWeight = 158.3673!
        Me.colUser.HeaderText = "ユーザ"
        Me.colUser.Name = "colUser"
        Me.colUser.ReadOnly = True
        Me.colUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSend
        '
        DataGridViewCellStyle1.NullValue = "0"
        Me.colSend.DefaultCellStyle = DataGridViewCellStyle1
        Me.colSend.HeaderText = "送信"
        Me.colSend.Name = "colSend"
        Me.colSend.ReadOnly = True
        Me.colSend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSend.Width = 60
        '
        'colReceive
        '
        DataGridViewCellStyle2.NullValue = "0"
        Me.colReceive.DefaultCellStyle = DataGridViewCellStyle2
        Me.colReceive.FillWeight = 81.63265!
        Me.colReceive.HeaderText = "受信"
        Me.colReceive.Name = "colReceive"
        Me.colReceive.ReadOnly = True
        Me.colReceive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colReceive.Width = 60
        '
        'colUserId
        '
        Me.colUserId.HeaderText = "ユーザID"
        Me.colUserId.Name = "colUserId"
        Me.colUserId.ReadOnly = True
        Me.colUserId.Visible = False
        '
        'colMessage
        '
        Me.colMessage.HeaderText = "メッセージ"
        Me.colMessage.Name = "colMessage"
        Me.colMessage.ReadOnly = True
        Me.colMessage.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "ユーザ一覧"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(318, 368)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "メール作成"
        '
        'frmMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 614)
        Me.Controls.Add(Me.dgvUser)
        Me.Controls.Add(Me.lblBottomName)
        Me.Controls.Add(Me.lblBottomCode)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSendMail)
        Me.Controls.Add(Me.txtMail)
        Me.Controls.Add(Me.txtMailLog)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblLogin)
        Me.Name = "frmMail"
        Me.Text = "frmMailTop"
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents txtMailLog As System.Windows.Forms.TextBox
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents btnSendMail As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Protected Friend WithEvents lblBottomName As System.Windows.Forms.Label
    Protected Friend WithEvents lblBottomCode As System.Windows.Forms.Label
    Friend WithEvents dgvUser As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents colUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReceive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMessage As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
