<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynthesisTestMarkHistory
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTitleRight = New System.Windows.Forms.Label()
        Me.lblTitlePercentage = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblCategory_D = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblCategory_C = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCategory_B = New System.Windows.Forms.Label()
        Me.lblFieldCategoryName_D = New System.Windows.Forms.Label()
        Me.lblCategory_A = New System.Windows.Forms.Label()
        Me.lblFieldCategoryName_C = New System.Windows.Forms.Label()
        Me.lblFieldCategoryName_B = New System.Windows.Forms.Label()
        Me.lblFieldCategoryName_A = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnList = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.lblTestTotal = New System.Windows.Forms.Label()
        Me.lblPercentage = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCategory_E = New System.Windows.Forms.Label()
        Me.lblFieldCategoryName_E = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(49, 132)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(135, 19)
        Me.lblTitle.TabIndex = 45
        Me.lblTitle.Text = "テスト採点結果"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(50, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "正解数"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 16)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "分野別正解率"
        '
        'lblTitleRight
        '
        Me.lblTitleRight.BackColor = System.Drawing.Color.White
        Me.lblTitleRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleRight.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitleRight.Location = New System.Drawing.Point(52, 186)
        Me.lblTitleRight.Name = "lblTitleRight"
        Me.lblTitleRight.Size = New System.Drawing.Size(300, 60)
        Me.lblTitleRight.TabIndex = 48
        Me.lblTitleRight.Text = "　　　　 問 / 　　　　 問　　　"
        Me.lblTitleRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitlePercentage
        '
        Me.lblTitlePercentage.BackColor = System.Drawing.Color.White
        Me.lblTitlePercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitlePercentage.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitlePercentage.ForeColor = System.Drawing.Color.Black
        Me.lblTitlePercentage.Location = New System.Drawing.Point(331, 186)
        Me.lblTitlePercentage.Name = "lblTitlePercentage"
        Me.lblTitlePercentage.Size = New System.Drawing.Size(120, 60)
        Me.lblTitlePercentage.TabIndex = 49
        Me.lblTitlePercentage.Text = "       ％"
        Me.lblTitlePercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(113, 201)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 27)
        Me.lblTotal.TabIndex = 51
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblCategory_E)
        Me.Panel1.Controls.Add(Me.lblFieldCategoryName_E)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.lblCategory_D)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.lblCategory_C)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.lblCategory_B)
        Me.Panel1.Controls.Add(Me.lblFieldCategoryName_D)
        Me.Panel1.Controls.Add(Me.lblCategory_A)
        Me.Panel1.Controls.Add(Me.lblFieldCategoryName_C)
        Me.Panel1.Controls.Add(Me.lblFieldCategoryName_B)
        Me.Panel1.Controls.Add(Me.lblFieldCategoryName_A)
        Me.Panel1.Location = New System.Drawing.Point(53, 284)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 340)
        Me.Panel1.TabIndex = 52
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(292, 214)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 27)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "％"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(292, 155)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 27)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "％"
        '
        'lblCategory_D
        '
        Me.lblCategory_D.BackColor = System.Drawing.Color.White
        Me.lblCategory_D.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCategory_D.Location = New System.Drawing.Point(216, 214)
        Me.lblCategory_D.Name = "lblCategory_D"
        Me.lblCategory_D.Size = New System.Drawing.Size(78, 27)
        Me.lblCategory_D.TabIndex = 56
        Me.lblCategory_D.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(292, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 27)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "％"
        '
        'lblCategory_C
        '
        Me.lblCategory_C.BackColor = System.Drawing.Color.White
        Me.lblCategory_C.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCategory_C.Location = New System.Drawing.Point(216, 155)
        Me.lblCategory_C.Name = "lblCategory_C"
        Me.lblCategory_C.Size = New System.Drawing.Size(78, 27)
        Me.lblCategory_C.TabIndex = 56
        Me.lblCategory_C.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(292, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 27)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "％"
        '
        'lblCategory_B
        '
        Me.lblCategory_B.BackColor = System.Drawing.Color.White
        Me.lblCategory_B.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCategory_B.Location = New System.Drawing.Point(216, 96)
        Me.lblCategory_B.Name = "lblCategory_B"
        Me.lblCategory_B.Size = New System.Drawing.Size(78, 27)
        Me.lblCategory_B.TabIndex = 54
        Me.lblCategory_B.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFieldCategoryName_D
        '
        Me.lblFieldCategoryName_D.AutoSize = True
        Me.lblFieldCategoryName_D.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFieldCategoryName_D.Location = New System.Drawing.Point(50, 222)
        Me.lblFieldCategoryName_D.Name = "lblFieldCategoryName_D"
        Me.lblFieldCategoryName_D.Size = New System.Drawing.Size(76, 15)
        Me.lblFieldCategoryName_D.TabIndex = 50
        Me.lblFieldCategoryName_D.Text = "テクノロジ系"
        Me.lblFieldCategoryName_D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory_A
        '
        Me.lblCategory_A.BackColor = System.Drawing.Color.White
        Me.lblCategory_A.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCategory_A.Location = New System.Drawing.Point(216, 37)
        Me.lblCategory_A.Name = "lblCategory_A"
        Me.lblCategory_A.Size = New System.Drawing.Size(78, 27)
        Me.lblCategory_A.TabIndex = 53
        Me.lblCategory_A.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFieldCategoryName_C
        '
        Me.lblFieldCategoryName_C.AutoSize = True
        Me.lblFieldCategoryName_C.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFieldCategoryName_C.Location = New System.Drawing.Point(50, 162)
        Me.lblFieldCategoryName_C.Name = "lblFieldCategoryName_C"
        Me.lblFieldCategoryName_C.Size = New System.Drawing.Size(76, 15)
        Me.lblFieldCategoryName_C.TabIndex = 50
        Me.lblFieldCategoryName_C.Text = "テクノロジ系"
        Me.lblFieldCategoryName_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFieldCategoryName_B
        '
        Me.lblFieldCategoryName_B.AutoSize = True
        Me.lblFieldCategoryName_B.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFieldCategoryName_B.Location = New System.Drawing.Point(50, 102)
        Me.lblFieldCategoryName_B.Name = "lblFieldCategoryName_B"
        Me.lblFieldCategoryName_B.Size = New System.Drawing.Size(89, 15)
        Me.lblFieldCategoryName_B.TabIndex = 49
        Me.lblFieldCategoryName_B.Text = "マネジメント系"
        Me.lblFieldCategoryName_B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFieldCategoryName_A
        '
        Me.lblFieldCategoryName_A.AutoSize = True
        Me.lblFieldCategoryName_A.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFieldCategoryName_A.Location = New System.Drawing.Point(50, 42)
        Me.lblFieldCategoryName_A.Name = "lblFieldCategoryName_A"
        Me.lblFieldCategoryName_A.Size = New System.Drawing.Size(77, 15)
        Me.lblFieldCategoryName_A.TabIndex = 48
        Me.lblFieldCategoryName_A.Text = "ストラテジ系"
        Me.lblFieldCategoryName_A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.Location = New System.Drawing.Point(483, 164)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(110, 16)
        Me.Label39.TabIndex = 54
        Me.Label39.Text = "分野別正答率"
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnBack.Location = New System.Drawing.Point(765, 662)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(236, 30)
        Me.btnBack.TabIndex = 61
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnList
        '
        Me.btnList.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.btnList.Location = New System.Drawing.Point(841, 609)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(151, 30)
        Me.btnList.TabIndex = 63
        Me.btnList.Text = "問別正誤表示"
        Me.btnList.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 7
        ChartArea1.AxisY.Maximum = 100.0R
        ChartArea1.AxisY.Minimum = 0.0R
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Enabled = False
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(486, 186)
        Me.Chart1.Name = "Chart1"
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Radar
        Series1.Color = System.Drawing.Color.Cyan
        Series1.CustomProperties = "RadarDrawingStyle=Line"
        Series1.IsVisibleInLegend = False
        Series1.Legend = "Legend1"
        Series1.MarkerColor = System.Drawing.Color.Cyan
        Series1.MarkerSize = 7
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(506, 416)
        Me.Chart1.TabIndex = 65
        Me.Chart1.TabStop = False
        Me.Chart1.Text = "Chart1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(330, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 16)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "正解率"
        '
        'lblTestName
        '
        Me.lblTestName.AutoSize = True
        Me.lblTestName.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestName.Location = New System.Drawing.Point(230, 136)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(12, 15)
        Me.lblTestName.TabIndex = 67
        Me.lblTestName.Text = " "
        '
        'lblTestTotal
        '
        Me.lblTestTotal.BackColor = System.Drawing.Color.White
        Me.lblTestTotal.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTestTotal.Location = New System.Drawing.Point(225, 204)
        Me.lblTestTotal.Name = "lblTestTotal"
        Me.lblTestTotal.Size = New System.Drawing.Size(54, 21)
        Me.lblTestTotal.TabIndex = 68
        '
        'lblPercentage
        '
        Me.lblPercentage.BackColor = System.Drawing.Color.White
        Me.lblPercentage.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPercentage.Location = New System.Drawing.Point(336, 202)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(78, 27)
        Me.lblPercentage.TabIndex = 69
        Me.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(292, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 27)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "％"
        '
        'lblCategory_E
        '
        Me.lblCategory_E.BackColor = System.Drawing.Color.White
        Me.lblCategory_E.Font = New System.Drawing.Font("MS UI Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCategory_E.Location = New System.Drawing.Point(216, 273)
        Me.lblCategory_E.Name = "lblCategory_E"
        Me.lblCategory_E.Size = New System.Drawing.Size(78, 27)
        Me.lblCategory_E.TabIndex = 59
        Me.lblCategory_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFieldCategoryName_E
        '
        Me.lblFieldCategoryName_E.AutoSize = True
        Me.lblFieldCategoryName_E.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblFieldCategoryName_E.Location = New System.Drawing.Point(50, 282)
        Me.lblFieldCategoryName_E.Name = "lblFieldCategoryName_E"
        Me.lblFieldCategoryName_E.Size = New System.Drawing.Size(76, 15)
        Me.lblFieldCategoryName_E.TabIndex = 58
        Me.lblFieldCategoryName_E.Text = "テクノロジ系"
        Me.lblFieldCategoryName_E.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSynthesisTestMarkHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.lblPercentage)
        Me.Controls.Add(Me.lblTestTotal)
        Me.Controls.Add(Me.lblTestName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitlePercentage)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblTitleRight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "frmSynthesisTestMarkHistory"
        Me.Text = "採点結果画面"
        Me.Controls.SetChildIndex(Me.lblTitle01, 0)
        Me.Controls.SetChildIndex(Me.Chart1, 0)
        Me.Controls.SetChildIndex(Me.lblBottomCode, 0)
        Me.Controls.SetChildIndex(Me.lblBottomName, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblTitleRight, 0)
        Me.Controls.SetChildIndex(Me.lblTotal, 0)
        Me.Controls.SetChildIndex(Me.lblTitlePercentage, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.btnList, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.lblTestName, 0)
        Me.Controls.SetChildIndex(Me.lblTestTotal, 0)
        Me.Controls.SetChildIndex(Me.lblPercentage, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTitleRight As System.Windows.Forms.Label
    Friend WithEvents lblTitlePercentage As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblFieldCategoryName_A As System.Windows.Forms.Label
    Friend WithEvents lblFieldCategoryName_B As System.Windows.Forms.Label
    Friend WithEvents lblFieldCategoryName_C As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblCategory_C As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCategory_B As System.Windows.Forms.Label
    Friend WithEvents lblCategory_A As System.Windows.Forms.Label
   Friend WithEvents Label39 As System.Windows.Forms.Label
   Friend WithEvents btnBack As System.Windows.Forms.Button
   Friend WithEvents btnList As System.Windows.Forms.Button
   Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents lblTestName As System.Windows.Forms.Label
   Friend WithEvents lblTestTotal As System.Windows.Forms.Label
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCategory_D As System.Windows.Forms.Label
    Friend WithEvents lblFieldCategoryName_D As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCategory_E As System.Windows.Forms.Label
    Friend WithEvents lblFieldCategoryName_E As System.Windows.Forms.Label
End Class
