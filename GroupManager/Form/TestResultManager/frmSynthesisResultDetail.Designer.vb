<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisResultDetail
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblQuestionCount = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblErrataCount = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblAccuracyRate = New System.Windows.Forms.Label()
        Me.lblTestDate = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSection2 = New System.Windows.Forms.Label()
        Me.lblSection1 = New System.Windows.Forms.Label()
        Me.lblMainUserName = New System.Windows.Forms.Label()
        Me.lblMainUserId = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTree = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dgvErrataList1 = New System.Windows.Forms.DataGridView()
        Me.pnlErrata = New System.Windows.Forms.Panel()
        Me.dgvErrataList2 = New System.Windows.Forms.DataGridView()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.QUESTIONNO_LEFT = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.THEME_LEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CORRECTANSWER_LEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANSWER_LEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ERRATA_LEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUESTIONNO_RIGHT = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.THEME_RIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CORRECTANSWER_RIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ANSWER_RIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ERRATA_RIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvErrataList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlErrata.SuspendLayout()
        CType(Me.dgvErrataList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(29, 205)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(104, 25)
        Me.Panel3.TabIndex = 228
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 15)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "〔テスト情報〕"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.lblQuestionCount)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.lblErrataCount)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.lblAccuracyRate)
        Me.Panel4.Controls.Add(Me.lblTestDate)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.lblTestName)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Location = New System.Drawing.Point(9, 216)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(991, 101)
        Me.Panel4.TabIndex = 227
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(437, 68)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(34, 24)
        Me.Label20.TabIndex = 241
        Me.Label20.Text = "問"
        '
        'lblQuestionCount
        '
        Me.lblQuestionCount.BackColor = System.Drawing.Color.White
        Me.lblQuestionCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuestionCount.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblQuestionCount.Location = New System.Drawing.Point(361, 59)
        Me.lblQuestionCount.Name = "lblQuestionCount"
        Me.lblQuestionCount.Size = New System.Drawing.Size(70, 33)
        Me.lblQuestionCount.TabIndex = 240
        Me.lblQuestionCount.Text = "100"
        Me.lblQuestionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(297, 68)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 24)
        Me.Label18.TabIndex = 239
        Me.Label18.Text = "問／"
        '
        'lblErrataCount
        '
        Me.lblErrataCount.BackColor = System.Drawing.Color.White
        Me.lblErrataCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblErrataCount.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblErrataCount.Location = New System.Drawing.Point(221, 48)
        Me.lblErrataCount.Name = "lblErrataCount"
        Me.lblErrataCount.Size = New System.Drawing.Size(70, 44)
        Me.lblErrataCount.TabIndex = 238
        Me.lblErrataCount.Text = "61"
        Me.lblErrataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(100, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 24)
        Me.Label16.TabIndex = 237
        Me.Label16.Text = "【正解数】"
        '
        'lblAccuracyRate
        '
        Me.lblAccuracyRate.BackColor = System.Drawing.Color.White
        Me.lblAccuracyRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAccuracyRate.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblAccuracyRate.Location = New System.Drawing.Point(660, 48)
        Me.lblAccuracyRate.Name = "lblAccuracyRate"
        Me.lblAccuracyRate.Size = New System.Drawing.Size(90, 44)
        Me.lblAccuracyRate.TabIndex = 236
        Me.lblAccuracyRate.Text = "100.0"
        Me.lblAccuracyRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTestDate
        '
        Me.lblTestDate.BackColor = System.Drawing.Color.White
        Me.lblTestDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTestDate.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestDate.Location = New System.Drawing.Point(514, 16)
        Me.lblTestDate.Name = "lblTestDate"
        Me.lblTestDate.Size = New System.Drawing.Size(140, 22)
        Me.lblTestDate.TabIndex = 235
        Me.lblTestDate.Text = "2012/04/25"
        Me.lblTestDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(756, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 24)
        Me.Label17.TabIndex = 233
        Me.Label17.Text = "％"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(548, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 24)
        Me.Label19.TabIndex = 231
        Me.Label19.Text = "【正解率】"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label15.Location = New System.Drawing.Point(440, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 225
        Me.Label15.Text = "【実施日】"
        '
        'lblTestName
        '
        Me.lblTestName.BackColor = System.Drawing.Color.White
        Me.lblTestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestName.Location = New System.Drawing.Point(221, 16)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(140, 22)
        Me.lblTestName.TabIndex = 224
        Me.lblTestName.Text = "総合テスト１"
        Me.lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(116, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 15)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "【テスト名】"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(25, 141)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(117, 25)
        Me.Panel2.TabIndex = 226
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "〔受講者情報〕"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblSection2)
        Me.Panel1.Controls.Add(Me.lblSection1)
        Me.Panel1.Controls.Add(Me.lblMainUserName)
        Me.Panel1.Controls.Add(Me.lblMainUserId)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(9, 152)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 47)
        Me.Panel1.TabIndex = 225
        '
        'lblSection2
        '
        Me.lblSection2.BackColor = System.Drawing.Color.White
        Me.lblSection2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSection2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSection2.Location = New System.Drawing.Point(837, 16)
        Me.lblSection2.Name = "lblSection2"
        Me.lblSection2.Size = New System.Drawing.Size(50, 22)
        Me.lblSection2.TabIndex = 112
        Me.lblSection2.Text = "Ａ"
        Me.lblSection2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSection1
        '
        Me.lblSection1.BackColor = System.Drawing.Color.White
        Me.lblSection1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSection1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSection1.Location = New System.Drawing.Point(721, 16)
        Me.lblSection1.Name = "lblSection1"
        Me.lblSection1.Size = New System.Drawing.Size(50, 22)
        Me.lblSection1.TabIndex = 111
        Me.lblSection1.Text = "１"
        Me.lblSection1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMainUserName
        '
        Me.lblMainUserName.BackColor = System.Drawing.Color.White
        Me.lblMainUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMainUserName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMainUserName.Location = New System.Drawing.Point(337, 16)
        Me.lblMainUserName.Name = "lblMainUserName"
        Me.lblMainUserName.Size = New System.Drawing.Size(200, 22)
        Me.lblMainUserName.TabIndex = 110
        Me.lblMainUserName.Text = "ＣＳＴ　太郎"
        Me.lblMainUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMainUserId
        '
        Me.lblMainUserId.BackColor = System.Drawing.Color.White
        Me.lblMainUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMainUserId.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMainUserId.Location = New System.Drawing.Point(137, 16)
        Me.lblMainUserId.Name = "lblMainUserId"
        Me.lblMainUserId.Size = New System.Drawing.Size(100, 22)
        Me.lblMainUserId.TabIndex = 108
        Me.lblMainUserId.Text = "USER01"
        Me.lblMainUserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label34.Location = New System.Drawing.Point(674, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 15)
        Me.Label34.TabIndex = 86
        Me.Label34.Text = "区分１"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label31.Location = New System.Drawing.Point(784, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(47, 15)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "区分２"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label30.Location = New System.Drawing.Point(601, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 15)
        Me.Label30.TabIndex = 78
        Me.Label30.Text = "【区分】"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label6.Location = New System.Drawing.Point(278, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "【氏名】"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.Label8.Location = New System.Drawing.Point(51, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 15)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "【ユーザID】"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(8, 118)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(175, 19)
        Me.lblTitle.TabIndex = 224
        Me.lblTitle.Text = "総合テスト履歴詳細"
        '
        'lblTree
        '
        Me.lblTree.AutoSize = True
        Me.lblTree.Location = New System.Drawing.Point(5, 100)
        Me.lblTree.Name = "lblTree"
        Me.lblTree.Size = New System.Drawing.Size(781, 12)
        Me.lblTree.TabIndex = 223
        Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 演習履歴管理メニュー ＞ 総合テスト履歴管理メニュー ＞ 総合テスト受講者成績一覧 ＞ 総合テスト履歴詳細" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
    ""
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.Location = New System.Drawing.Point(14, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 19)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "問別正誤"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.Location = New System.Drawing.Point(38, 29)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(242, 15)
        Me.Label23.TabIndex = 230
        Me.Label23.Text = "問番号を選択すると解説を表示します。"
        '
        'dgvErrataList1
        '
        Me.dgvErrataList1.AllowUserToAddRows = False
        Me.dgvErrataList1.AllowUserToDeleteRows = False
        Me.dgvErrataList1.AllowUserToResizeColumns = False
        Me.dgvErrataList1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvErrataList1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvErrataList1.ColumnHeadersHeight = 28
        Me.dgvErrataList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvErrataList1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONNO_LEFT, Me.THEME_LEFT, Me.CORRECTANSWER_LEFT, Me.ANSWER_LEFT, Me.ERRATA_LEFT})
        Me.dgvErrataList1.EnableHeadersVisualStyles = False
        Me.dgvErrataList1.Location = New System.Drawing.Point(31, 49)
        Me.dgvErrataList1.MultiSelect = False
        Me.dgvErrataList1.Name = "dgvErrataList1"
        Me.dgvErrataList1.ReadOnly = True
        Me.dgvErrataList1.RowHeadersVisible = False
        Me.dgvErrataList1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvErrataList1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvErrataList1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvErrataList1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvErrataList1.RowTemplate.Height = 21
        Me.dgvErrataList1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvErrataList1.Size = New System.Drawing.Size(449, 1080)
        Me.dgvErrataList1.TabIndex = 30
        Me.dgvErrataList1.TabStop = False
        '
        'pnlErrata
        '
        Me.pnlErrata.AutoScroll = True
        Me.pnlErrata.BackColor = System.Drawing.Color.White
        Me.pnlErrata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlErrata.Controls.Add(Me.dgvErrataList2)
        Me.pnlErrata.Controls.Add(Me.Label23)
        Me.pnlErrata.Controls.Add(Me.Label22)
        Me.pnlErrata.Controls.Add(Me.dgvErrataList1)
        Me.pnlErrata.Location = New System.Drawing.Point(9, 323)
        Me.pnlErrata.Name = "pnlErrata"
        Me.pnlErrata.Size = New System.Drawing.Size(991, 314)
        Me.pnlErrata.TabIndex = 10
        Me.pnlErrata.TabStop = True
        '
        'dgvErrataList2
        '
        Me.dgvErrataList2.AllowUserToAddRows = False
        Me.dgvErrataList2.AllowUserToDeleteRows = False
        Me.dgvErrataList2.AllowUserToResizeColumns = False
        Me.dgvErrataList2.AllowUserToResizeRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvErrataList2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvErrataList2.ColumnHeadersHeight = 28
        Me.dgvErrataList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvErrataList2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUESTIONNO_RIGHT, Me.THEME_RIGHT, Me.CORRECTANSWER_RIGHT, Me.ANSWER_RIGHT, Me.ERRATA_RIGHT})
        Me.dgvErrataList2.EnableHeadersVisualStyles = False
        Me.dgvErrataList2.Location = New System.Drawing.Point(500, 49)
        Me.dgvErrataList2.MultiSelect = False
        Me.dgvErrataList2.Name = "dgvErrataList2"
        Me.dgvErrataList2.ReadOnly = True
        Me.dgvErrataList2.RowHeadersVisible = False
        Me.dgvErrataList2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.dgvErrataList2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvErrataList2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvErrataList2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvErrataList2.RowTemplate.Height = 21
        Me.dgvErrataList2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvErrataList2.Size = New System.Drawing.Size(449, 1080)
        Me.dgvErrataList2.TabIndex = 40
        Me.dgvErrataList2.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(773, 662)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(240, 30)
        Me.btnBack.TabIndex = 229
        Me.btnBack.Text = "総合テスト受講者成績一覧へ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'QUESTIONNO_LEFT
        '
        Me.QUESTIONNO_LEFT.DataPropertyName = "QUESTIONNO_NUM"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "問#"
        Me.QUESTIONNO_LEFT.DefaultCellStyle = DataGridViewCellStyle2
        Me.QUESTIONNO_LEFT.HeaderText = "問番号"
        Me.QUESTIONNO_LEFT.Name = "QUESTIONNO_LEFT"
        Me.QUESTIONNO_LEFT.ReadOnly = True
        Me.QUESTIONNO_LEFT.Width = 80
        '
        'THEME_LEFT
        '
        Me.THEME_LEFT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.THEME_LEFT.DataPropertyName = "THEME"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.THEME_LEFT.DefaultCellStyle = DataGridViewCellStyle3
        Me.THEME_LEFT.HeaderText = "問題テーマ"
        Me.THEME_LEFT.Name = "THEME_LEFT"
        Me.THEME_LEFT.ReadOnly = True
        Me.THEME_LEFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CORRECTANSWER_LEFT
        '
        Me.CORRECTANSWER_LEFT.DataPropertyName = "CORRECTANSWER"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CORRECTANSWER_LEFT.DefaultCellStyle = DataGridViewCellStyle4
        Me.CORRECTANSWER_LEFT.HeaderText = "正解"
        Me.CORRECTANSWER_LEFT.Name = "CORRECTANSWER_LEFT"
        Me.CORRECTANSWER_LEFT.ReadOnly = True
        Me.CORRECTANSWER_LEFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CORRECTANSWER_LEFT.Width = 60
        '
        'ANSWER_LEFT
        '
        Me.ANSWER_LEFT.DataPropertyName = "ANSWER"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ANSWER_LEFT.DefaultCellStyle = DataGridViewCellStyle5
        Me.ANSWER_LEFT.HeaderText = "解答"
        Me.ANSWER_LEFT.Name = "ANSWER_LEFT"
        Me.ANSWER_LEFT.ReadOnly = True
        Me.ANSWER_LEFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ANSWER_LEFT.Width = 60
        '
        'ERRATA_LEFT
        '
        Me.ERRATA_LEFT.DataPropertyName = "ERRATA_DISPLAY"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ERRATA_LEFT.DefaultCellStyle = DataGridViewCellStyle6
        Me.ERRATA_LEFT.HeaderText = "正誤"
        Me.ERRATA_LEFT.Name = "ERRATA_LEFT"
        Me.ERRATA_LEFT.ReadOnly = True
        Me.ERRATA_LEFT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ERRATA_LEFT.Width = 60
        '
        'QUESTIONNO_RIGHT
        '
        Me.QUESTIONNO_RIGHT.DataPropertyName = "QUESTIONNO_NUM"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "問#"
        Me.QUESTIONNO_RIGHT.DefaultCellStyle = DataGridViewCellStyle8
        Me.QUESTIONNO_RIGHT.HeaderText = "問番号"
        Me.QUESTIONNO_RIGHT.Name = "QUESTIONNO_RIGHT"
        Me.QUESTIONNO_RIGHT.ReadOnly = True
        Me.QUESTIONNO_RIGHT.Width = 80
        '
        'THEME_RIGHT
        '
        Me.THEME_RIGHT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.THEME_RIGHT.DataPropertyName = "THEME"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.THEME_RIGHT.DefaultCellStyle = DataGridViewCellStyle9
        Me.THEME_RIGHT.HeaderText = "問題テーマ"
        Me.THEME_RIGHT.Name = "THEME_RIGHT"
        Me.THEME_RIGHT.ReadOnly = True
        Me.THEME_RIGHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CORRECTANSWER_RIGHT
        '
        Me.CORRECTANSWER_RIGHT.DataPropertyName = "CORRECTANSWER"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CORRECTANSWER_RIGHT.DefaultCellStyle = DataGridViewCellStyle10
        Me.CORRECTANSWER_RIGHT.HeaderText = "正解"
        Me.CORRECTANSWER_RIGHT.Name = "CORRECTANSWER_RIGHT"
        Me.CORRECTANSWER_RIGHT.ReadOnly = True
        Me.CORRECTANSWER_RIGHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CORRECTANSWER_RIGHT.Width = 60
        '
        'ANSWER_RIGHT
        '
        Me.ANSWER_RIGHT.DataPropertyName = "ANSWER"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ANSWER_RIGHT.DefaultCellStyle = DataGridViewCellStyle11
        Me.ANSWER_RIGHT.HeaderText = "解答"
        Me.ANSWER_RIGHT.Name = "ANSWER_RIGHT"
        Me.ANSWER_RIGHT.ReadOnly = True
        Me.ANSWER_RIGHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ANSWER_RIGHT.Width = 60
        '
        'ERRATA_RIGHT
        '
        Me.ERRATA_RIGHT.DataPropertyName = "ERRATA_DISPLAY"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ERRATA_RIGHT.DefaultCellStyle = DataGridViewCellStyle12
        Me.ERRATA_RIGHT.HeaderText = "正誤"
        Me.ERRATA_RIGHT.Name = "ERRATA_RIGHT"
        Me.ERRATA_RIGHT.ReadOnly = True
        Me.ERRATA_RIGHT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ERRATA_RIGHT.Width = 60
        '
        'frmSynthesisResultDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.pnlErrata)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTree)
        Me.Name = "frmSynthesisResultDetail"
        Me.Text = "総合テスト履歴詳細"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTree, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.pnlErrata, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvErrataList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlErrata.ResumeLayout(False)
        Me.pnlErrata.PerformLayout()
        CType(Me.dgvErrataList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSection2 As System.Windows.Forms.Label
    Friend WithEvents lblSection1 As System.Windows.Forms.Label
    Friend WithEvents lblMainUserName As System.Windows.Forms.Label
    Friend WithEvents lblMainUserId As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTree As System.Windows.Forms.Label
    Friend WithEvents lblAccuracyRate As System.Windows.Forms.Label
    Friend WithEvents lblTestDate As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblQuestionCount As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblErrataCount As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dgvErrataList1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlErrata As System.Windows.Forms.Panel
    Friend WithEvents dgvErrataList2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents QUESTIONNO_LEFT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents THEME_LEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CORRECTANSWER_LEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANSWER_LEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ERRATA_LEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUESTIONNO_RIGHT As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents THEME_RIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CORRECTANSWER_RIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANSWER_RIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ERRATA_RIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
