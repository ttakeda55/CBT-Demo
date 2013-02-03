<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPracticeQuestionShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPracticeQuestionShow))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btmPre = New System.Windows.Forms.Button()
        Me.cboDisplayMagnification = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCodeColor = New System.Windows.Forms.Button()
        Me.btnBackColor = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SplBase = New System.Windows.Forms.SplitContainer()
        Me.SplQuestion = New System.Windows.Forms.SplitContainer()
        Me.webQuestionTop = New CST.CBT.eIPSTA.BaseControl.UserWebBrowser()
        Me.wmpMovie = New AxWMPLib.AxWindowsMediaPlayer()
        Me.webQuestionBottom = New CST.CBT.eIPSTA.BaseControl.UserWebBrowser()
        Me.webComment = New CST.CBT.eIPSTA.BaseControl.UserWebBrowser()
        Me.lblCorrectAnswer = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.lblQuestionCodeLeft = New System.Windows.Forms.Label()
        Me.lblQuestionCodeRight = New System.Windows.Forms.Label()
        Me.lblAnswer = New System.Windows.Forms.Label()
        Me.SplBase.Panel1.SuspendLayout()
        Me.SplBase.Panel2.SuspendLayout()
        Me.SplBase.SuspendLayout()
        Me.SplQuestion.Panel1.SuspendLayout()
        Me.SplQuestion.Panel2.SuspendLayout()
        Me.SplQuestion.SuspendLayout()
        CType(Me.wmpMovie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(0, 19)
        Me.lblTitle01.Text = ""
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnExit.Location = New System.Drawing.Point(861, 662)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(120, 30)
        Me.btnExit.TabIndex = 110
        Me.btnExit.Text = "閉じる"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnNext.Location = New System.Drawing.Point(528, 615)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(120, 30)
        Me.btnNext.TabIndex = 100
        Me.btnNext.Text = "次の問題へ＞＞"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btmPre
        '
        Me.btmPre.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btmPre.Location = New System.Drawing.Point(402, 615)
        Me.btmPre.Name = "btmPre"
        Me.btmPre.Size = New System.Drawing.Size(120, 30)
        Me.btmPre.TabIndex = 90
        Me.btmPre.Text = "＜＜前の問題へ"
        Me.btmPre.UseVisualStyleBackColor = True
        '
        'cboDisplayMagnification
        '
        Me.cboDisplayMagnification.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.cboDisplayMagnification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDisplayMagnification.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.cboDisplayMagnification.FormattingEnabled = True
        Me.cboDisplayMagnification.Items.AddRange(New Object() {"100%", "110%", "120%", "130%", "140%", "150%", "160%", "170%", "180%", "190%", "200%"})
        Me.cboDisplayMagnification.Location = New System.Drawing.Point(920, 111)
        Me.cboDisplayMagnification.Name = "cboDisplayMagnification"
        Me.cboDisplayMagnification.Size = New System.Drawing.Size(85, 23)
        Me.cboDisplayMagnification.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(847, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "表示倍率："
        '
        'btnCodeColor
        '
        Me.btnCodeColor.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnCodeColor.Location = New System.Drawing.Point(721, 107)
        Me.btnCodeColor.Name = "btnCodeColor"
        Me.btnCodeColor.Size = New System.Drawing.Size(120, 30)
        Me.btnCodeColor.TabIndex = 20
        Me.btnCodeColor.Text = "文字色変更"
        Me.btnCodeColor.UseVisualStyleBackColor = True
        Me.btnCodeColor.Visible = False
        '
        'btnBackColor
        '
        Me.btnBackColor.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackColor.Location = New System.Drawing.Point(595, 107)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(120, 30)
        Me.btnBackColor.TabIndex = 10
        Me.btnBackColor.Text = "背景色変更"
        Me.btnBackColor.UseVisualStyleBackColor = True
        Me.btnBackColor.Visible = False
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(815, 662)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(191, 30)
        Me.btnBack.TabIndex = 120
        Me.btnBack.Text = "管理者メインメニューへ戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'SplBase
        '
        Me.SplBase.IsSplitterFixed = True
        Me.SplBase.Location = New System.Drawing.Point(7, 143)
        Me.SplBase.Name = "SplBase"
        '
        'SplBase.Panel1
        '
        Me.SplBase.Panel1.Controls.Add(Me.SplQuestion)
        Me.SplBase.Panel1MinSize = 0
        '
        'SplBase.Panel2
        '
        Me.SplBase.Panel2.Controls.Add(Me.webComment)
        Me.SplBase.Panel2MinSize = 0
        Me.SplBase.Size = New System.Drawing.Size(998, 466)
        Me.SplBase.SplitterDistance = 994
        Me.SplBase.TabIndex = 80
        '
        'SplQuestion
        '
        Me.SplQuestion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplQuestion.Location = New System.Drawing.Point(2, 2)
        Me.SplQuestion.Name = "SplQuestion"
        Me.SplQuestion.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplQuestion.Panel1
        '
        Me.SplQuestion.Panel1.Controls.Add(Me.webQuestionTop)
        Me.SplQuestion.Panel1MinSize = 0
        '
        'SplQuestion.Panel2
        '
        Me.SplQuestion.Panel2.Controls.Add(Me.wmpMovie)
        Me.SplQuestion.Panel2.Controls.Add(Me.webQuestionBottom)
        Me.SplQuestion.Panel2MinSize = 0
        Me.SplQuestion.Size = New System.Drawing.Size(989, 462)
        Me.SplQuestion.SplitterDistance = 246
        Me.SplQuestion.TabIndex = 60
        '
        'webQuestionTop
        '
        Me.webQuestionTop.AllowNavigation = False
        Me.webQuestionTop.DocumentText = ""
        Me.webQuestionTop.Location = New System.Drawing.Point(0, 0)
        Me.webQuestionTop.Mode = CST.CBT.eIPSTA.BaseControl.UserWebBrowser.ZoomMode.[Auto]
        Me.webQuestionTop.Name = "webQuestionTop"
        Me.webQuestionTop.Size = New System.Drawing.Size(422, 154)
        Me.webQuestionTop.TabIndex = 40
        Me.webQuestionTop.url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'wmpMovie
        '
        Me.wmpMovie.Enabled = True
        Me.wmpMovie.Location = New System.Drawing.Point(519, 30)
        Me.wmpMovie.Name = "wmpMovie"
        Me.wmpMovie.OcxState = CType(resources.GetObject("wmpMovie.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpMovie.Size = New System.Drawing.Size(245, 128)
        Me.wmpMovie.TabIndex = 41
        '
        'webQuestionBottom
        '
        Me.webQuestionBottom.AllowNavigation = False
        Me.webQuestionBottom.DocumentText = ""
        Me.webQuestionBottom.Location = New System.Drawing.Point(57, 43)
        Me.webQuestionBottom.Mode = CST.CBT.eIPSTA.BaseControl.UserWebBrowser.ZoomMode.[Auto]
        Me.webQuestionBottom.Name = "webQuestionBottom"
        Me.webQuestionBottom.Size = New System.Drawing.Size(343, 95)
        Me.webQuestionBottom.TabIndex = 50
        Me.webQuestionBottom.url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'webComment
        '
        Me.webComment.AllowNavigation = False
        Me.webComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webComment.DocumentText = ""
        Me.webComment.Location = New System.Drawing.Point(0, 45)
        Me.webComment.Mode = CST.CBT.eIPSTA.BaseControl.UserWebBrowser.ZoomMode.[Auto]
        Me.webComment.Name = "webComment"
        Me.webComment.Size = New System.Drawing.Size(0, 419)
        Me.webComment.TabIndex = 70
        Me.webComment.url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'lblCorrectAnswer
        '
        Me.lblCorrectAnswer.AutoSize = True
        Me.lblCorrectAnswer.BackColor = System.Drawing.Color.White
        Me.lblCorrectAnswer.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.lblCorrectAnswer.ForeColor = System.Drawing.Color.Black
        Me.lblCorrectAnswer.Location = New System.Drawing.Point(301, 112)
        Me.lblCorrectAnswer.Name = "lblCorrectAnswer"
        Me.lblCorrectAnswer.Size = New System.Drawing.Size(18, 15)
        Me.lblCorrectAnswer.TabIndex = 78
        Me.lblCorrectAnswer.Text = "ア"
        '
        'lblTitle2
        '
        Me.lblTitle2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle2.BackColor = System.Drawing.Color.White
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle2.Location = New System.Drawing.Point(266, 109)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(86, 23)
        Me.lblTitle2.TabIndex = 77
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuestion.Location = New System.Drawing.Point(6, 114)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(42, 16)
        Me.lblQuestion.TabIndex = 69
        Me.lblQuestion.Text = "問題"
        '
        'lblQuestionCodeLeft
        '
        Me.lblQuestionCodeLeft.BackColor = System.Drawing.Color.White
        Me.lblQuestionCodeLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuestionCodeLeft.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblQuestionCodeLeft.Location = New System.Drawing.Point(66, 109)
        Me.lblQuestionCodeLeft.Name = "lblQuestionCodeLeft"
        Me.lblQuestionCodeLeft.Size = New System.Drawing.Size(118, 23)
        Me.lblQuestionCodeLeft.TabIndex = 69
        Me.lblQuestionCodeLeft.Text = "M2011A_A"
        Me.lblQuestionCodeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuestionCodeRight
        '
        Me.lblQuestionCodeRight.BackColor = System.Drawing.Color.White
        Me.lblQuestionCodeRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuestionCodeRight.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblQuestionCodeRight.Location = New System.Drawing.Point(448, 113)
        Me.lblQuestionCodeRight.Name = "lblQuestionCodeRight"
        Me.lblQuestionCodeRight.Size = New System.Drawing.Size(118, 18)
        Me.lblQuestionCodeRight.TabIndex = 69
        Me.lblQuestionCodeRight.Text = "M2011A085"
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAnswer.Location = New System.Drawing.Point(216, 113)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(42, 16)
        Me.lblAnswer.TabIndex = 69
        Me.lblAnswer.Text = "正解"
        '
        'frmPracticeQuestionShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblCorrectAnswer)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblQuestionCodeRight)
        Me.Controls.Add(Me.lblQuestionCodeLeft)
        Me.Controls.Add(Me.lblAnswer)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btmPre)
        Me.Controls.Add(Me.cboDisplayMagnification)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCodeColor)
        Me.Controls.Add(Me.btnBackColor)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.SplBase)
        Me.Name = "frmPracticeQuestionShow"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.SplBase, 0)
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblTitle2, 0)
        Me.Controls.SetChildIndex(Me.btnBackColor, 0)
        Me.Controls.SetChildIndex(Me.btnCodeColor, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboDisplayMagnification, 0)
        Me.Controls.SetChildIndex(Me.btmPre, 0)
        Me.Controls.SetChildIndex(Me.btnNext, 0)
        Me.Controls.SetChildIndex(Me.lblQuestion, 0)
        Me.Controls.SetChildIndex(Me.lblAnswer, 0)
        Me.Controls.SetChildIndex(Me.lblQuestionCodeLeft, 0)
        Me.Controls.SetChildIndex(Me.lblQuestionCodeRight, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.btnExit, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblCorrectAnswer, 0)
        Me.SplBase.Panel1.ResumeLayout(False)
        Me.SplBase.Panel2.ResumeLayout(False)
        Me.SplBase.ResumeLayout(False)
        Me.SplQuestion.Panel1.ResumeLayout(False)
        Me.SplQuestion.Panel2.ResumeLayout(False)
        Me.SplQuestion.ResumeLayout(False)
        CType(Me.wmpMovie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btmPre As System.Windows.Forms.Button
    Friend WithEvents cboDisplayMagnification As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCodeColor As System.Windows.Forms.Button
    Friend WithEvents btnBackColor As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents SplBase As System.Windows.Forms.SplitContainer
    Friend WithEvents lblCorrectAnswer As System.Windows.Forms.Label
    Friend WithEvents lblTitle2 As System.Windows.Forms.Label
    Friend WithEvents webComment As CST.CBT.eIPSTA.BaseControl.UserWebBrowser
    Friend WithEvents SplQuestion As System.Windows.Forms.SplitContainer
    Friend WithEvents webQuestionTop As CST.CBT.eIPSTA.BaseControl.UserWebBrowser
    Friend WithEvents webQuestionBottom As CST.CBT.eIPSTA.BaseControl.UserWebBrowser
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents lblQuestionCodeLeft As System.Windows.Forms.Label
    Friend WithEvents lblQuestionCodeRight As System.Windows.Forms.Label
    Friend WithEvents lblAnswer As System.Windows.Forms.Label
    Friend WithEvents wmpMovie As AxWMPLib.AxWindowsMediaPlayer
End Class
