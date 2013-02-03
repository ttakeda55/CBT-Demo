<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiddlePracticeTop
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlMiddlePracticeTop = New System.Windows.Forms.Panel()
        Me.chkMienshuPractice = New System.Windows.Forms.CheckBox()
        Me.chkSaienshuPractice = New System.Windows.Forms.CheckBox()
        Me.chkChokkinPractice = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnMiddlePracticeStart = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBackPracticeMenu = New System.Windows.Forms.Button()
        Me.pnlMiddlePracticeTop.SuspendLayout()
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 19)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "中問逐次演習"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(249, 15)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "演習する問題の条件を指定してください。"
        '
        'pnlMiddlePracticeTop
        '
        Me.pnlMiddlePracticeTop.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlMiddlePracticeTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkMienshuPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkSaienshuPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.chkChokkinPractice)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label9)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label8)
        Me.pnlMiddlePracticeTop.Controls.Add(Me.Label7)
        Me.pnlMiddlePracticeTop.Location = New System.Drawing.Point(83, 222)
        Me.pnlMiddlePracticeTop.Name = "pnlMiddlePracticeTop"
        Me.pnlMiddlePracticeTop.Size = New System.Drawing.Size(439, 196)
        Me.pnlMiddlePracticeTop.TabIndex = 46
        '
        'chkMienshuPractice
        '
        Me.chkMienshuPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkMienshuPractice.Location = New System.Drawing.Point(50, 132)
        Me.chkMienshuPractice.Name = "chkMienshuPractice"
        Me.chkMienshuPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkMienshuPractice.TabIndex = 3
        Me.chkMienshuPractice.TabStop = False
        Me.chkMienshuPractice.Text = "chkMienshuPractice"
        Me.chkMienshuPractice.UseVisualStyleBackColor = True
        '
        'chkSaienshuPractice
        '
        Me.chkSaienshuPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkSaienshuPractice.Location = New System.Drawing.Point(50, 85)
        Me.chkSaienshuPractice.Name = "chkSaienshuPractice"
        Me.chkSaienshuPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkSaienshuPractice.TabIndex = 2
        Me.chkSaienshuPractice.TabStop = False
        Me.chkSaienshuPractice.Text = "chkSaienshuPractice"
        Me.chkSaienshuPractice.UseVisualStyleBackColor = True
        '
        'chkChokkinPractice
        '
        Me.chkChokkinPractice.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.chkChokkinPractice.Location = New System.Drawing.Point(50, 39)
        Me.chkChokkinPractice.Name = "chkChokkinPractice"
        Me.chkChokkinPractice.Size = New System.Drawing.Size(19, 24)
        Me.chkChokkinPractice.TabIndex = 1
        Me.chkChokkinPractice.TabStop = False
        Me.chkChokkinPractice.Text = "chkChokkinPractice"
        Me.chkChokkinPractice.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(87, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 15)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "未演習の問題"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(84, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(201, 15)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = """再演習""にチェックを入れた問題"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(84, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(224, 15)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "直近の出題時に不正解となった問題"
        '
        'btnMiddlePracticeStart
        '
        Me.btnMiddlePracticeStart.BackColor = System.Drawing.SystemColors.Control
        Me.btnMiddlePracticeStart.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMiddlePracticeStart.Location = New System.Drawing.Point(387, 493)
        Me.btnMiddlePracticeStart.Name = "btnMiddlePracticeStart"
        Me.btnMiddlePracticeStart.Size = New System.Drawing.Size(278, 126)
        Me.btnMiddlePracticeStart.TabIndex = 4
        Me.btnMiddlePracticeStart.Text = "中問逐次演習開始"
        Me.btnMiddlePracticeStart.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(560, 393)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(221, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "※該当問題がない場合は出題されません"
        '
        'btnBackPracticeMenu
        '
        Me.btnBackPracticeMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackPracticeMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackPracticeMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackPracticeMenu.Name = "btnBackPracticeMenu"
        Me.btnBackPracticeMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackPracticeMenu.TabIndex = 5
        Me.btnBackPracticeMenu.Text = "問題演習メニューへ戻る"
        Me.btnBackPracticeMenu.UseVisualStyleBackColor = True
        '
        'frmMiddlePracticeTop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.btnBackPracticeMenu)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnMiddlePracticeStart)
        Me.Controls.Add(Me.pnlMiddlePracticeTop)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmMiddlePracticeTop"
        Me.Text = "frmMiddlePracticeTop"
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.pnlMiddlePracticeTop, 0)
        Me.Controls.SetChildIndex(Me.btnMiddlePracticeStart, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnBackPracticeMenu, 0)
        Me.pnlMiddlePracticeTop.ResumeLayout(False)
        Me.pnlMiddlePracticeTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlMiddlePracticeTop As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnMiddlePracticeStart As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnBackPracticeMenu As System.Windows.Forms.Button
    Friend WithEvents chkChokkinPractice As System.Windows.Forms.CheckBox
    Friend WithEvents chkMienshuPractice As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaienshuPractice As System.Windows.Forms.CheckBox
End Class
