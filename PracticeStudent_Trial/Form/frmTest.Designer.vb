<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTest))
        Me.btnBackColor = New System.Windows.Forms.Button()
        Me.btnCodeColor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboDisplayMagnification = New System.Windows.Forms.ComboBox()
        Me.btmPre = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblQuestionHeader = New System.Windows.Forms.Label()
        Me.btnReview = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdbAnswer1 = New System.Windows.Forms.RadioButton()
        Me.rdbAnswer2 = New System.Windows.Forms.RadioButton()
        Me.rdbAnswer3 = New System.Windows.Forms.RadioButton()
        Me.rdbAnswer4 = New System.Windows.Forms.RadioButton()
        Me.chkReview = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SplQuestion = New System.Windows.Forms.SplitContainer()
        Me.webQuestionSingle = New CST.CBT.eIPSTA.BaseControl.UserWebBrowser()
        Me.wmpMovie = New AxWMPLib.AxWindowsMediaPlayer()
        Me.lblQuestionCode = New System.Windows.Forms.Label()
        Me.bgwDownload = New System.ComponentModel.BackgroundWorker()
        Me.bgwCreate = New System.ComponentModel.BackgroundWorker()
        Me.lblProcMsg = New System.Windows.Forms.Label()
        Me.lblQuestionCode2 = New System.Windows.Forms.Label()
        Me.bgwCheck = New System.ComponentModel.BackgroundWorker()
        Me.bgwUpload = New System.ComponentModel.BackgroundWorker()
        Me.lblRemainingTime = New System.Windows.Forms.Label()
        Me.RemainingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SplQuestion.Panel1.SuspendLayout()
        Me.SplQuestion.Panel2.SuspendLayout()
        Me.SplQuestion.SuspendLayout()
        CType(Me.wmpMovie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBottomCode
        '
        Me.lblBottomCode.Location = New System.Drawing.Point(3, 666)
        Me.lblBottomCode.Size = New System.Drawing.Size(9, 12)
        Me.lblBottomCode.Text = " "
        '
        'lblBottomName
        '
        Me.lblBottomName.Location = New System.Drawing.Point(24, 678)
        Me.lblBottomName.Size = New System.Drawing.Size(13, 16)
        Me.lblBottomName.Text = " "
        '
        'lblTitle01
        '
        Me.lblTitle01.Size = New System.Drawing.Size(369, 27)
        Me.lblTitle01.Text = "ＣＢＴコンピューター試験体験版"
        '
        'btnBackColor
        '
        Me.btnBackColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBackColor.Enabled = False
        Me.btnBackColor.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackColor.Location = New System.Drawing.Point(618, 99)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(104, 30)
        Me.btnBackColor.TabIndex = 1
        Me.btnBackColor.Text = "背景色変更"
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'btnCodeColor
        '
        Me.btnCodeColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCodeColor.Enabled = False
        Me.btnCodeColor.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnCodeColor.Location = New System.Drawing.Point(728, 99)
        Me.btnCodeColor.Name = "btnCodeColor"
        Me.btnCodeColor.Size = New System.Drawing.Size(104, 30)
        Me.btnCodeColor.TabIndex = 2
        Me.btnCodeColor.Text = "文字色変更"
        Me.btnCodeColor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(848, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "表示倍率："
        '
        'cboDisplayMagnification
        '
        Me.cboDisplayMagnification.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDisplayMagnification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDisplayMagnification.Enabled = False
        Me.cboDisplayMagnification.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.cboDisplayMagnification.FormattingEnabled = True
        Me.cboDisplayMagnification.Items.AddRange(New Object() {"100%", "110%", "120%", "130%", "140%", "150%", "160%", "170%", "180%", "190%", "200%"})
        Me.cboDisplayMagnification.Location = New System.Drawing.Point(921, 103)
        Me.cboDisplayMagnification.Name = "cboDisplayMagnification"
        Me.cboDisplayMagnification.Size = New System.Drawing.Size(85, 23)
        Me.cboDisplayMagnification.TabIndex = 3
        '
        'btmPre
        '
        Me.btmPre.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btmPre.Enabled = False
        Me.btmPre.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btmPre.Location = New System.Drawing.Point(318, 662)
        Me.btmPre.Name = "btmPre"
        Me.btmPre.Size = New System.Drawing.Size(120, 30)
        Me.btmPre.TabIndex = 12
        Me.btmPre.Text = "＜＜前の問題へ"
        Me.btmPre.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.Enabled = False
        Me.btnNext.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnNext.Location = New System.Drawing.Point(580, 662)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(120, 30)
        Me.btnNext.TabIndex = 14
        Me.btnNext.Text = "次の問題へ＞＞"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.Control
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(875, 662)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(126, 30)
        Me.btnBack.TabIndex = 15
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblQuestionHeader
        '
        Me.lblQuestionHeader.AutoSize = True
        Me.lblQuestionHeader.Font = New System.Drawing.Font("MS UI Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblQuestionHeader.Location = New System.Drawing.Point(13, 101)
        Me.lblQuestionHeader.Name = "lblQuestionHeader"
        Me.lblQuestionHeader.Size = New System.Drawing.Size(51, 29)
        Me.lblQuestionHeader.TabIndex = 54
        Me.lblQuestionHeader.Text = " 問"
        '
        'btnReview
        '
        Me.btnReview.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnReview.Enabled = False
        Me.btnReview.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnReview.Location = New System.Drawing.Point(449, 662)
        Me.btnReview.Name = "btnReview"
        Me.btnReview.Size = New System.Drawing.Size(120, 30)
        Me.btnReview.TabIndex = 13
        Me.btnReview.Text = "解答見直し"
        Me.btnReview.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Location = New System.Drawing.Point(302, 595)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(390, 45)
        Me.Label8.TabIndex = 55
        '
        'rdbAnswer1
        '
        Me.rdbAnswer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.rdbAnswer1.BackColor = System.Drawing.Color.White
        Me.rdbAnswer1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbAnswer1.Enabled = False
        Me.rdbAnswer1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbAnswer1.Location = New System.Drawing.Point(333, 603)
        Me.rdbAnswer1.Name = "rdbAnswer1"
        Me.rdbAnswer1.Size = New System.Drawing.Size(50, 30)
        Me.rdbAnswer1.TabIndex = 6
        Me.rdbAnswer1.Text = "Ａ"
        Me.rdbAnswer1.UseVisualStyleBackColor = False
        '
        'rdbAnswer2
        '
        Me.rdbAnswer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.rdbAnswer2.BackColor = System.Drawing.Color.White
        Me.rdbAnswer2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbAnswer2.Enabled = False
        Me.rdbAnswer2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbAnswer2.Location = New System.Drawing.Point(432, 603)
        Me.rdbAnswer2.Name = "rdbAnswer2"
        Me.rdbAnswer2.Size = New System.Drawing.Size(50, 30)
        Me.rdbAnswer2.TabIndex = 7
        Me.rdbAnswer2.Text = "Ｂ"
        Me.rdbAnswer2.UseVisualStyleBackColor = False
        '
        'rdbAnswer3
        '
        Me.rdbAnswer3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.rdbAnswer3.BackColor = System.Drawing.Color.White
        Me.rdbAnswer3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbAnswer3.Enabled = False
        Me.rdbAnswer3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbAnswer3.Location = New System.Drawing.Point(529, 603)
        Me.rdbAnswer3.Name = "rdbAnswer3"
        Me.rdbAnswer3.Size = New System.Drawing.Size(50, 30)
        Me.rdbAnswer3.TabIndex = 8
        Me.rdbAnswer3.Text = "Ｃ"
        Me.rdbAnswer3.UseVisualStyleBackColor = False
        '
        'rdbAnswer4
        '
        Me.rdbAnswer4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.rdbAnswer4.BackColor = System.Drawing.Color.White
        Me.rdbAnswer4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbAnswer4.Enabled = False
        Me.rdbAnswer4.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.rdbAnswer4.Location = New System.Drawing.Point(629, 603)
        Me.rdbAnswer4.Name = "rdbAnswer4"
        Me.rdbAnswer4.Size = New System.Drawing.Size(50, 30)
        Me.rdbAnswer4.TabIndex = 9
        Me.rdbAnswer4.Text = "Ｄ"
        Me.rdbAnswer4.UseVisualStyleBackColor = False
        '
        'chkReview
        '
        Me.chkReview.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkReview.AutoSize = True
        Me.chkReview.Enabled = False
        Me.chkReview.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkReview.Location = New System.Drawing.Point(740, 614)
        Me.chkReview.Name = "chkReview"
        Me.chkReview.Size = New System.Drawing.Size(107, 19)
        Me.chkReview.TabIndex = 10
        Me.chkReview.TabStop = False
        Me.chkReview.Text = "見直しチェック"
        Me.chkReview.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(215, 610)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "解答欄"
        '
        'SplQuestion
        '
        Me.SplQuestion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplQuestion.Location = New System.Drawing.Point(22, 137)
        Me.SplQuestion.Name = "SplQuestion"
        '
        'SplQuestion.Panel1
        '
        Me.SplQuestion.Panel1.AutoScroll = True
        Me.SplQuestion.Panel1.AutoScrollMinSize = New System.Drawing.Size(40, 0)
        Me.SplQuestion.Panel1.Controls.Add(Me.webQuestionSingle)
        '
        'SplQuestion.Panel2
        '
        Me.SplQuestion.Panel2.AutoScrollMargin = New System.Drawing.Size(40, 0)
        Me.SplQuestion.Panel2.Controls.Add(Me.wmpMovie)
        Me.SplQuestion.Size = New System.Drawing.Size(984, 446)
        Me.SplQuestion.SplitterDistance = 481
        Me.SplQuestion.TabIndex = 60
        Me.SplQuestion.TabStop = False
        '
        'webQuestionSingle
        '
        Me.webQuestionSingle.AllowNavigation = False
        Me.webQuestionSingle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webQuestionSingle.DocumentText = ""
        Me.webQuestionSingle.Location = New System.Drawing.Point(0, 0)
        Me.webQuestionSingle.Mode = CST.CBT.eIPSTA.BaseControl.UserWebBrowser.ZoomMode.[Auto]
        Me.webQuestionSingle.Name = "webQuestionSingle"
        Me.webQuestionSingle.Size = New System.Drawing.Size(481, 446)
        Me.webQuestionSingle.TabIndex = 54
        Me.webQuestionSingle.TabStop = False
        Me.webQuestionSingle.url = New System.Uri("about:blank", System.UriKind.Absolute)
        '
        'wmpMovie
        '
        Me.wmpMovie.Enabled = True
        Me.wmpMovie.Location = New System.Drawing.Point(48, 62)
        Me.wmpMovie.Name = "wmpMovie"
        Me.wmpMovie.OcxState = CType(resources.GetObject("wmpMovie.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpMovie.Size = New System.Drawing.Size(200, 62)
        Me.wmpMovie.TabIndex = 6
        '
        'lblQuestionCode
        '
        Me.lblQuestionCode.BackColor = System.Drawing.Color.White
        Me.lblQuestionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuestionCode.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblQuestionCode.Location = New System.Drawing.Point(69, 109)
        Me.lblQuestionCode.Name = "lblQuestionCode"
        Me.lblQuestionCode.Size = New System.Drawing.Size(118, 18)
        Me.lblQuestionCode.TabIndex = 61
        Me.lblQuestionCode.Visible = False
        '
        'bgwDownload
        '
        '
        'lblProcMsg
        '
        Me.lblProcMsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProcMsg.BackColor = System.Drawing.Color.White
        Me.lblProcMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcMsg.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblProcMsg.Location = New System.Drawing.Point(327, 293)
        Me.lblProcMsg.Name = "lblProcMsg"
        Me.lblProcMsg.Size = New System.Drawing.Size(365, 110)
        Me.lblProcMsg.TabIndex = 64
        Me.lblProcMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQuestionCode2
        '
        Me.lblQuestionCode2.BackColor = System.Drawing.Color.White
        Me.lblQuestionCode2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQuestionCode2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblQuestionCode2.Location = New System.Drawing.Point(193, 109)
        Me.lblQuestionCode2.Name = "lblQuestionCode2"
        Me.lblQuestionCode2.Size = New System.Drawing.Size(118, 18)
        Me.lblQuestionCode2.TabIndex = 65
        Me.lblQuestionCode2.Visible = False
        '
        'bgwCheck
        '
        '
        'bgwUpload
        '
        '
        'lblRemainingTime
        '
        Me.lblRemainingTime.AutoSize = True
        Me.lblRemainingTime.BackColor = System.Drawing.Color.White
        Me.lblRemainingTime.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblRemainingTime.Location = New System.Drawing.Point(409, 64)
        Me.lblRemainingTime.Name = "lblRemainingTime"
        Me.lblRemainingTime.Size = New System.Drawing.Size(206, 21)
        Me.lblRemainingTime.TabIndex = 66
        Me.lblRemainingTime.Text = "残り時間：000分00秒"
        '
        'RemainingTimer
        '
        Me.RemainingTimer.Interval = 1000
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblRemainingTime)
        Me.Controls.Add(Me.lblQuestionCode2)
        Me.Controls.Add(Me.lblProcMsg)
        Me.Controls.Add(Me.lblQuestionCode)
        Me.Controls.Add(Me.lblQuestionHeader)
        Me.Controls.Add(Me.rdbAnswer1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chkReview)
        Me.Controls.Add(Me.rdbAnswer2)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.rdbAnswer3)
        Me.Controls.Add(Me.cboDisplayMagnification)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.rdbAnswer4)
        Me.Controls.Add(Me.btnCodeColor)
        Me.Controls.Add(Me.btnReview)
        Me.Controls.Add(Me.btnBackColor)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btmPre)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.SplQuestion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = True
        Me.Name = "frmTest"
        Me.Text = "問題演習"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.SplQuestion, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btmPre, 0)
        Me.Controls.SetChildIndex(Me.btnNext, 0)
        Me.Controls.SetChildIndex(Me.btnBackColor, 0)
        Me.Controls.SetChildIndex(Me.btnReview, 0)
        Me.Controls.SetChildIndex(Me.btnCodeColor, 0)
        Me.Controls.SetChildIndex(Me.rdbAnswer4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.cboDisplayMagnification, 0)
        Me.Controls.SetChildIndex(Me.rdbAnswer3, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.rdbAnswer2, 0)
        Me.Controls.SetChildIndex(Me.chkReview, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.rdbAnswer1, 0)
        Me.Controls.SetChildIndex(Me.lblQuestionHeader, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblQuestionCode, 0)
        Me.Controls.SetChildIndex(Me.lblProcMsg, 0)
        Me.Controls.SetChildIndex(Me.lblQuestionCode2, 0)
        Me.Controls.SetChildIndex(Me.lblRemainingTime, 0)
        Me.SplQuestion.Panel1.ResumeLayout(False)
        Me.SplQuestion.Panel2.ResumeLayout(False)
        Me.SplQuestion.ResumeLayout(False)
        CType(Me.wmpMovie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBackColor As System.Windows.Forms.Button
    Friend WithEvents btnCodeColor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDisplayMagnification As System.Windows.Forms.ComboBox
    Friend WithEvents btmPre As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblQuestionHeader As System.Windows.Forms.Label
    Friend WithEvents btnReview As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdbAnswer1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAnswer2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAnswer3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAnswer4 As System.Windows.Forms.RadioButton
    Friend WithEvents chkReview As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SplQuestion As System.Windows.Forms.SplitContainer
    Friend WithEvents webQuestionSingle As CST.CBT.eIPSTA.BaseControl.UserWebBrowser
    Friend WithEvents lblQuestionCode As System.Windows.Forms.Label
    Friend WithEvents bgwDownload As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwCreate As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblProcMsg As System.Windows.Forms.Label
    Friend WithEvents lblQuestionCode2 As System.Windows.Forms.Label
    Friend WithEvents bgwCheck As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwUpload As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblRemainingTime As System.Windows.Forms.Label
    Friend WithEvents RemainingTimer As System.Windows.Forms.Timer
    Friend WithEvents wmpMovie As AxWMPLib.AxWindowsMediaPlayer
End Class
