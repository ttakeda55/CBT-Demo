<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestTop
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBackPracticeMenu = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTestTime = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnTestStart = New System.Windows.Forms.Button()
        Me.lblNow = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tmNowTime = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(240, 15)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "演習する総合テストを指定してください。"
        Me.Label6.UseWaitCursor = True
        '
        'btnBackPracticeMenu
        '
        Me.btnBackPracticeMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnBackPracticeMenu.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnBackPracticeMenu.Location = New System.Drawing.Point(770, 660)
        Me.btnBackPracticeMenu.Name = "btnBackPracticeMenu"
        Me.btnBackPracticeMenu.Size = New System.Drawing.Size(212, 36)
        Me.btnBackPracticeMenu.TabIndex = 3
        Me.btnBackPracticeMenu.Text = "操作説明へ戻る"
        Me.btnBackPracticeMenu.UseVisualStyleBackColor = True
        Me.btnBackPracticeMenu.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lblTestTime)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.btnTestStart)
        Me.Panel1.Location = New System.Drawing.Point(22, 135)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(975, 466)
        Me.Panel1.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(259, 269)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(239, 21)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "テスト開始の指示が出たら"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(259, 218)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(271, 16)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "問題に関する質問にはお答えできません。"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(259, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(218, 16)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "次の表に従って解答してください。"
        '
        'lblTestTime
        '
        Me.lblTestTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTestTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestTime.Location = New System.Drawing.Point(489, 140)
        Me.lblTestTime.Name = "lblTestTime"
        Me.lblTestTime.Size = New System.Drawing.Size(117, 25)
        Me.lblTestTime.TabIndex = 51
        Me.lblTestTime.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTestTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(390, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 25)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "試験時間"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(489, 116)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 25)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "50問必須"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(390, 116)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 25)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "選択方法"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(489, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 25)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "問1～問50"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(390, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 25)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "問題番号"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(259, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(365, 16)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "指示があるまで「テスト開始」ボタンを押してはいけません。"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(259, 296)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(473, 21)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "「テスト開始」ボタンを押してテストを開始してください。"
        '
        'btnTestStart
        '
        Me.btnTestStart.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnTestStart.Location = New System.Drawing.Point(402, 331)
        Me.btnTestStart.Name = "btnTestStart"
        Me.btnTestStart.Size = New System.Drawing.Size(201, 96)
        Me.btnTestStart.TabIndex = 50
        Me.btnTestStart.Text = "テスト開始"
        Me.btnTestStart.UseVisualStyleBackColor = True
        '
        'lblNow
        '
        Me.lblNow.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNow.Location = New System.Drawing.Point(897, 106)
        Me.lblNow.Name = "lblNow"
        Me.lblNow.Size = New System.Drawing.Size(100, 15)
        Me.lblNow.TabIndex = 58
        Me.lblNow.Text = "00時00分00秒"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(824, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "現在時刻："
        '
        'tmNowTime
        '
        Me.tmNowTime.Interval = 1000
        '
        'frmTestTop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblNow)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnBackPracticeMenu)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmTestTop"
        Me.Text = "frmTestTop"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnBackPracticeMenu, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblNow, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBackPracticeMenu As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTestTime As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnTestStart As System.Windows.Forms.Button
    Friend WithEvents lblNow As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tmNowTime As System.Windows.Forms.Timer
End Class
