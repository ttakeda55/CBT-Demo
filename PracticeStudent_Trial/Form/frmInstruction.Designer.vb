<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstruction
    Inherits BaseControl.BaseForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstruction))
        Me.btnPre = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tmNowTime = New System.Windows.Forms.Timer(Me.components)
        Me.lblNow = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.webInstruction = New CST.CBT.eIPSTA.BaseControl.UserWebBrowser()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Location = New System.Drawing.Point(3, 666)
        '
        'lblBottomName
        '
        Me.lblBottomName.Location = New System.Drawing.Point(24, 678)
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(0, 27)
        Me.lblTitle01.Text = ""
        '
        'btnPre
        '
        Me.btnPre.Enabled = False
        Me.btnPre.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnPre.Location = New System.Drawing.Point(404, 614)
        Me.btnPre.Name = "btnPre"
        Me.btnPre.Size = New System.Drawing.Size(120, 30)
        Me.btnPre.TabIndex = 50
        Me.btnPre.Text = "＜＜前ページへ"
        Me.btnPre.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnNext.Location = New System.Drawing.Point(530, 614)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(120, 30)
        Me.btnNext.TabIndex = 51
        Me.btnNext.Text = "次ページへ＞＞"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(810, 662)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(191, 30)
        Me.btnBack.TabIndex = 20
        Me.btnBack.Text = "戻　る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "操作説明"
        Me.Label6.Visible = False
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnStart.Location = New System.Drawing.Point(810, 614)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(191, 30)
        Me.btnStart.TabIndex = 10
        Me.btnStart.Text = "テスト開始画面へ"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(833, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "現在時刻："
        Me.Label7.Visible = False
        '
        'tmNowTime
        '
        Me.tmNowTime.Interval = 1000
        '
        'lblNow
        '
        Me.lblNow.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNow.Location = New System.Drawing.Point(906, 70)
        Me.lblNow.Name = "lblNow"
        Me.lblNow.Size = New System.Drawing.Size(100, 15)
        Me.lblNow.TabIndex = 55
        Me.lblNow.Text = "00時00分00秒"
        Me.lblNow.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnClose.Location = New System.Drawing.Point(810, 662)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(191, 30)
        Me.btnClose.TabIndex = 52
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'webInstruction
        '
        Me.webInstruction.AllowNavigation = False
        Me.webInstruction.DocumentText = ""
        Me.webInstruction.Location = New System.Drawing.Point(18, 92)
        Me.webInstruction.Mode = CST.CBT.eIPSTA.BaseControl.UserWebBrowser.ZoomMode.[Auto]
        Me.webInstruction.Name = "webInstruction"
        Me.webInstruction.Size = New System.Drawing.Size(983, 503)
        Me.webInstruction.TabIndex = 53
        Me.webInstruction.url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(20, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(910, 2252)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(284, 410)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 163)
        Me.Panel1.TabIndex = 56
        Me.Panel1.TabStop = True
        Me.Panel1.Visible = False
        '
        'frmInstruction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.webInstruction)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblNow)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPre)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmInstruction"
        Me.Text = "frmQuestionShow"
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnStart, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.btnPre, 0)
        Me.Controls.SetChildIndex(Me.btnNext, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblNow, 0)
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.webInstruction, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPre As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tmNowTime As System.Windows.Forms.Timer
    Friend WithEvents lblNow As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents webInstruction As CST.CBT.eIPSTA.BaseControl.UserWebBrowser
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
