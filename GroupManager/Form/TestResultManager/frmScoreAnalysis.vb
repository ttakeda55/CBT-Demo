Imports System
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Imports Microsoft.Office.Interop

Imports CST.CBT
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common

''' <summary>
''' 得点分析結果
''' </summary>
''' <remarks>
''' 2011/09/07 NAKAMURA 新規作成
''' </remarks>
Public Class frmScoreAnalysis

#Region "----- メンバ変数 -----"
    ''' <summary>グループ関数</summary>
    Private cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
    ''' <summary>データバンカー</summary>
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>カラムコンスト</summary>
    Private Const CST_SCOREANALYSIS_COL As String = "COL"
    ''' <summary>ランクコンスト</summary>
    Private Const CST_SCOREANALYSIS_RANK As String = "RANK"

    ''' <summary>分野名ID１</summary>
    Private CST_CATEGORY1 As String = Common.CategoryMaster.categoryId.fieldCategoryId_A
    ''' <summary>分野名ID２</summary>
    Private CST_CATEGORY2 As String = Common.CategoryMaster.categoryId.fieldCategoryId_B
    ''' <summary>分野名ID３</summary>
    Private CST_CATEGORY3 As String = Common.CategoryMaster.categoryId.fieldCategoryId_C
    ''' <summary>分野名ID４</summary>
    Private CST_CATEGORY4 As String = Common.CategoryMaster.categoryId.fieldCategoryId_D
    ''' <summary>分野名ID５</summary>
    Private CST_CATEGORY5 As String = Common.CategoryMaster.categoryId.fieldCategoryId_E


    '帳票

    ''' <summary>分野名1</summary>
    Public Const CST_FIELD1 As String = "Field1"
    ''' <summary>分野名2</summary>
    Public Const CST_FIELD2 As String = "Field2"
    ''' <summary>分野名3</summary>
    Public Const CST_FIELD3 As String = "Field3"
    ''' <summary>分野名4</summary>
    Public Const CST_FIELD4 As String = "Field4"
    ''' <summary>分野名5</summary>
    Public Const CST_FIELD5 As String = "Field5"
    ''' <summary>分野名1</summary>
    Public Const CST_FIELDHEADER1 As String = "FieldHeader1"
    ''' <summary>分野名2</summary>
    Public Const CST_FIELDHEADER2 As String = "FieldHeader2"
    ''' <summary>分野名3</summary>
    Public Const CST_FIELDHEADER3 As String = "FieldHeader3"
    ''' <summary>分野名4</summary>
    Public Const CST_FIELDHEADER4 As String = "FieldHeader4"
    ''' <summary>分野名5</summary>
    Public Const CST_FIELDHEADER5 As String = "FieldHeader5"

#End Region

#Region "イベントハンドラ"

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmScoreAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Show()
            Me.Refresh()
            'ファイルダウンロード
            Common.DataManager.GetInstance.DownLoadFile()

            Me.processMessage = True
            '初期処理
            init()

            Owner.Hide()
            Me.processMessage = False
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.processMessage = False
        End Try
    End Sub

    ''' <summary>
    ''' 管理メニューへ戻るクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = "KG01"
            ResourcesDel()
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 試験結果分析メニューへ戻るクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuestion.Click
        Try
            logger.Start()
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            'リソース削除
            ResourcesDel()
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = "KG09"
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 再分析クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()
            '項目チェック # パラメータ設定
            If ItemCheck(0) Then
                '再検索
                DataSearch()

            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 保存クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            logger.Start()
            Dim sfdExcel As New SaveFileDialog()

            sfdExcel.Filter = "Excel ファイル (*.xls)|*.xls"
            sfdExcel.FileName = "得点分析結果.xls"
            sfdExcel.FilterIndex = 2
            sfdExcel.RestoreDirectory = True

            If sfdExcel.ShowDialog() = DialogResult.OK Then
                Me.processMessageOutput = True
                btnSave.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Me.Refresh()

                'エクセル保存処理
                ExcelSave(sfdExcel.FileName)

                Me.Cursor = Cursors.Arrow
                btnSave.Enabled = True
                If dataBanker("PRINTERR") = True Then
                    Me.processMessageOutput = False
                    Common.Message.MessageShow("I007")
                End If
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.processMessageOutput = False
        End Try
    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            logger.Start()
            processMessageLogout = True
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    ResourcesDel()
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
            End Select
            processMessageLogout = False
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "メソッド"

    ''' <summary>
    ''' 初期処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        Dim TestDetail As System.Data.DataTable
        Dim GroupTbl As System.Data.DataTable

        Dim GroupCode As String
        Dim CourseName As String
        Dim MenuMode As Integer = 0

        Me.lblBottomCode.Text = "KG11"
        Me.lblBottomName.Text = "得点分析結果画面"
        Me.UserId = "ID：" & dataBanker.Item("USERID")
        Me.UserName = "氏名：" & dataBanker.Item("USERNAME")

        lblField1.Text = CategoryMaster.GetCategoryName(CST_CATEGORY1)
        lblField2.Text = CategoryMaster.GetCategoryName(CST_CATEGORY2)
        lblField3.Text = CategoryMaster.GetCategoryName(CST_CATEGORY3)

        With grdResultList
            'ソート不可
            For Each Col As DataGridViewColumn In .Columns
                Col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next Col

            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'グリッド初期設定
            .ReadOnly = True
            .AllowUserToAddRows = False
            'grdResultListの列の幅をユーザーが変更できないようにする
            .AllowUserToResizeColumns = False
            'grdResultListの行の高さをユーザーが変更できないようにする
            .AllowUserToResizeRows = False
            'grdResultListでセル、行、列が複数選択されないようにする
            .MultiSelect = False
            'セルを選択すると行全体が選択されるようにする
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '初期状態で背景が透けないように
            .CurrentCell = Nothing
        End With

        With crtTotal
            ' Set Back Color
            .BackColor = Color.White
            ' Set Border Color
            .BorderColor = Color.Black
            ' Set Border Style
            .BorderDashStyle = ChartDashStyle.Solid
            ' Set series point width
            .Series("Series1")("PointWidth") = "0.9"
            ' Set series points width to 20 pixels
            ' Draw the chart as embossed
            .Series("Series1")("DrawingStyle") = "Default"
            ' ラベルポインタ（値表示）
            .Series("Series1").IsValueShownAsLabel = True
            ' Set labels style (Auto, Horizontal, Circular or Radial)
            .Series("Series1")("CircularLabelsStyle") = "Horizontal"

            With .ChartAreas("ChartArea1")
                '
                .AxisX.Title = "正解率（％）"
                .AxisX.TextOrientation = TextOrientation.Horizontal

                .AxisY.Title = "人数"
                .AxisY.TextOrientation = TextOrientation.Horizontal
                .AxisY.TitleAlignment = StringAlignment.Far

                .BorderDashStyle = ChartDashStyle.Solid
                .BorderColor = Color.Gray

                .AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet
                .AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.None

                .AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
                .AxisY.MajorGrid.LineColor = Color.Gray
                .AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.None

            End With
        End With

        'データ取得
        GroupTbl = dataBanker.Item("GROUPTABLE")
        GroupCode = dataBanker.Item("GROUPCODE")
        CourseName = dataBanker.Item("COURSE")

        '団体コンボ
        cmbGroup.DataSource = GroupTbl

        '受験回
        cmbInning.DataSource = Common.Constant.CST_TESTCOUNT2_CMB
        '区分１
        cmbSection1.DataSource = Common.Constant.CST_SECTION1_CMB
        '区分２
        cmbSection2.DataSource = Common.Constant.CST_SECTION2_CMB

        '日付
        Dim dStart As DateTime = DateTime.Now
        udtpStart.Text = ""
        udtpEnd.Text = ""

        '合否
        cmbPass.DataSource = Common.Constant.CST_PASS_CMB

        If dataBanker("SYSMODE") <> Common.Constant.CST_MENUMODE_SYSTEM Then
            cmbCourse.Text = dataBanker("COURSE")
            'コントロール使用不可
            cmbGroup.Enabled = False
            cmbCourse.Enabled = False
        Else
            MenuMode = 1
        End If

        Dim Category1String As Array = {CategoryMaster.GetCategoryName(CST_CATEGORY1),
                                        CategoryMaster.GetCategoryName(CST_CATEGORY2),
                                        CategoryMaster.GetCategoryName(CST_CATEGORY3)}

        Dim Category2String As Array = {CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_1),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_2),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_3),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_1),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_2),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_3),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_1),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_2),
                                        CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_3)}
        With grdResultList
            .Rows.Add(10)
            '分野
            .Rows(1).Cells(0).Value = Category1String(0)
            .Rows(4).Cells(0).Value = Category1String(1)
            .Rows(7).Cells(0).Value = Category1String(2)
            .Rows(9).Cells(0).Value = Common.Constant.CST_TOTALASSESSMENT

            '大分類
            .Rows(0).Cells(1).Value = Category2String(0)
            .Rows(1).Cells(1).Value = Category2String(1)
            .Rows(2).Cells(1).Value = Category2String(2)
            .Rows(3).Cells(1).Value = Category2String(3)
            .Rows(4).Cells(1).Value = Category2String(4)
            .Rows(5).Cells(1).Value = Category2String(5)
            .Rows(6).Cells(1).Value = Category2String(6)
            .Rows(7).Cells(1).Value = Category2String(7)
            .Rows(8).Cells(1).Value = Category2String(8)

            '大分類ID
            .Rows(0).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY1_1
            .Rows(1).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY1_2
            .Rows(2).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY1_3
            .Rows(3).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY2_1
            .Rows(4).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY2_2
            .Rows(5).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY2_3
            .Rows(6).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY3_1
            .Rows(7).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY3_2
            .Rows(8).Cells(CATEGORYID.Index).Value = CST_SCOREANALYSIS_COL & CST_LARGE_CATEGORY3_3
        End With

        'データ取得
        '試験結果集計_明細取得 
        TestDetail = GetTestDetailSum(MenuMode, GroupCode)
        If TestDetail.Rows.Count = 0 Then
            'エラー
            Common.Message.MessageShow("E021", {"試験情報"})
            btnQuestion.PerformClick()
        End If

        btnSave.Enabled = False

        '格納
        dataBanker("TestResultDetailSum") = TestDetail

        '帳票用リソース保存
        ResourcesSave()

    End Sub

    ''' <summary>
    ''' 抽出条件、項目チェック
    ''' </summary>
    ''' <param name="mode">モード</param>
    ''' <returns>True：OK</returns>
    ''' <remarks></remarks>
    Public Function ItemCheck(ByVal mode As String) As Boolean
        '項目チェック
        '受験日チェック
        If Not udtpStart.Text.Equals("    年  月  日") And Not IsDate(udtpStart.Text) Then
            Common.Message.MessageShow("E042", {"受験日"})
            Return False
        End If
        If Not udtpEnd.Text.Equals("    年  月  日") And Not IsDate(udtpEnd.Text) Then
            Common.Message.MessageShow("E042", {"受験日"})
            Return False
        End If

        If IsDate(udtpStart.Text) And IsDate(udtpEnd.Text) Then
            If CDate(udtpStart.Text) > CDate(udtpEnd.Text) Then
                Common.Message.MessageShow("E078")
                Return False
            End If
        End If

        If Not GroupClass.GetInstance.PointRangeCheck(txtStrategyStart, txtStrategyEnd,
                                               txtManagementStart, txtManagementEnd,
                                               txtTechnologyStart, txtTechnologyEnd,
                                               txtTotalStart, txtTotalEnd) Then Return False

        Return True
    End Function

    ''' <summary>
    ''' 抽出条件取得
    ''' </summary>
    ''' <param name="mode">モード</param>
    ''' <returns>抽出条件</returns>
    ''' <remarks></remarks>
    Public Function CreateWhere(ByVal mode As Integer) As String
        Dim Where As String = ""

        Where = "USERID = USERID "

        '日付
        If IsDate(udtpStart.Text) Then
            Where += "AND TESTDATE >= '" & Format(CDate(udtpStart.Text), "yyyy/MM/dd") & "' "
        End If
        If IsDate(udtpEnd.Text) Then
            Where += "AND TESTDATE <= '" & Format(CDate(udtpEnd.Text), "yyyy/MM/dd") & "' "
        End If
        If mode = 1 Then
            '団体名
            If Me.cmbGroup.SelectedIndex >= 0 Then
                Where += "AND GROUPCODE = '" & Me.cmbGroup.SelectedValue & "' "
            End If
            'コース名
            If Me.cmbCourse.SelectedIndex > 0 Then
                Where += "AND COURSE = '" & Me.cmbCourse.SelectedItem.ToString & "' "
            End If
        End If
        '"全て", "初回受験のみ", "再受験のみ", "未受験"
        If Me.cmbInning.SelectedItem = Common.Constant.CST_TESTCOUNT_CMB(1) Then
            Where += "AND TESTCOUNT = '1' "
        ElseIf Me.cmbInning.SelectedItem = Common.Constant.CST_TESTCOUNT_CMB(2) Then
            Where += "AND TESTCOUNT = '2' "
        ElseIf Me.cmbInning.SelectedItem = Common.Constant.CST_TESTCOUNT_CMB(3) Then
            Where += "AND TESTCOUNT = '0' "
        End If        '区分１ 
        If Me.cmbSection1.SelectedIndex <> 0 Then
            Where += "AND SECTION1 = '" & Me.cmbSection1.SelectedItem.ToString & "' "
        End If
        '区分２
        If Me.cmbSection2.SelectedIndex <> 0 Then
            Where += "AND SECTION2 = '" & Me.cmbSection2.SelectedItem.ToString & "' "
        End If
        '合否（"全て", "合格のみ", "不合格のみ"）
        If Me.cmbPass.SelectedItem = Common.Constant.CST_PASS_CMB(1) Then
            Where += "AND RESULT = '1' "
        ElseIf Me.cmbPass.SelectedItem = Common.Constant.CST_PASS_CMB(2) Then
            Where += "AND RESULT = '0' "
        End If
        'ストラテジ系
        If IsNumeric(txtStrategyStart.Text) Then
            Where += "AND convert(CATEGORYPOINT1_A, 'System.Int32') >= " & txtStrategyStart.Text & " "
        End If
        If IsNumeric(txtStrategyEnd.Text) Then
            Where += "AND convert(CATEGORYPOINT1_A, 'System.Int32') <= " & txtStrategyEnd.Text & " "
        End If
        'テクノロジ系
        If IsNumeric(txtTechnologyStart.Text) Then
            Where += "AND convert(CATEGORYPOINT1_B, 'System.Int32') >= " & txtTechnologyStart.Text & " "
        End If
        If IsNumeric(txtTechnologyEnd.Text) Then
            Where += "AND convert(CATEGORYPOINT1_B, 'System.Int32') <= " & txtTechnologyEnd.Text & " "
        End If
        'マネジメント系
        If IsNumeric(txtManagementStart.Text) Then
            Where += "AND convert(CATEGORYPOINT1_C, 'System.Int32') >= " & txtManagementStart.Text & " "
        End If
        If IsNumeric(txtManagementEnd.Text) Then
            Where += "AND convert(CATEGORYPOINT1_C, 'System.Int32') <= " & txtManagementEnd.Text & " "
        End If
        '総合
        If IsNumeric(txtTotalStart.Text) Then
            Where += "AND convert(TOTALPOINTS, 'System.Int32') >= " & txtTotalStart.Text & " "
        End If
        If IsNumeric(txtTotalEnd.Text) Then
            Where += "AND convert(TOTALPOINTS, 'System.Int32') <= " & txtTotalEnd.Text & " "
        End If
        Return Where
    End Function

    ''' <summary>
    ''' 再検索処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataSearch()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        Dim TestDetail As System.Data.DataTable
        Dim TmpTestDetail() As DataRow
        Dim sumTest As New System.Data.DataTable

        Dim MenuMode As Integer = 0
        Dim KeyUserId(0) As DataColumn
        Dim Where As String

        If dataBanker("SYSMODE") = Common.Constant.CST_MENUMODE_SYSTEM Then
            MenuMode = 1
        End If

        '#抽出条件設定
        Where = CreateWhere(MenuMode)

        '抽出
        TestDetail = dataBanker("TestResultDetailSum")

        TmpTestDetail = TestDetail.Select(Where)
        If TmpTestDetail.Length = 0 Then
            'データなし
            Common.Message.MessageShow("I002")
            Exit Sub
        Else
            dataBanker("WHERE") = Where
        End If

        '分類別評価作成
        sumTest = ClassAssessment(TestDetail, Where)

        '画面表示
        SetDispData(sumTest)

        'グラフ表示
        SetChartData(sumTest)

        'ボタン有効

        btnSave.Enabled = DataManager.GetInstance.IsExcel
        
        '抽出条件保存
        SetSearchKey()
    End Sub

    ''' <summary>
    ''' 抽出条件退避
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSearchKey()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        dataBanker("cmbGroup") = cmbGroup.Text
        dataBanker("cmbCourse") = cmbCourse.SelectedItem
        dataBanker("udtpStart") = udtpStart.Text
        dataBanker("udtpEnd") = udtpEnd.Text
        dataBanker("cmbInning") = cmbInning.SelectedItem
        dataBanker("cmbSection1") = cmbSection1.SelectedItem
        dataBanker("cmbSection2") = cmbSection2.SelectedItem
        dataBanker("cmbPass") = cmbPass.SelectedItem
        dataBanker("txtStrategyStart") = txtStrategyStart.Text
        dataBanker("txtStrategyEnd") = txtStrategyEnd.Text
        dataBanker("txtManagementStart") = txtManagementStart.Text
        dataBanker("txtManagementEnd") = txtManagementEnd.Text
        dataBanker("txtTechnologyStart") = txtTechnologyStart.Text
        dataBanker("txtTechnologyEnd") = txtTechnologyEnd.Text
        dataBanker("txtTotalStart") = txtTotalStart.Text
        dataBanker("txtTotalEnd") = txtTotalEnd.Text

    End Sub

    ''' <summary>
    ''' 試験結果集計_明細取得
    ''' </summary>
    ''' <param name="Mode">モード</param>
    ''' <param name="Group">団体コード</param>
    ''' <returns>試験結果集計_明細</returns>
    ''' <remarks></remarks>
    Public Function GetTestDetailSum(ByVal Mode As Integer, ByVal Group As String) As System.Data.DataTable
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim cGroup As CBT.eIPSTA.GroupManager.GroupClass = CBT.eIPSTA.GroupManager.GroupClass.GetInstance
        Dim TempPath As String = Common.Constant.GetTempPath

        Dim Student As System.Data.DataTable
        Dim TestHead As New System.Data.DataTable
        Dim TestDetail As New System.Data.DataTable
        Dim KeyUserId(2) As DataColumn

        Dim ReturnTestDetail As New System.Data.DataTable

        '受講者データ
        Student = cGroup.GetStudent(Mode, Group)
        If IsNothing(Student) Then
            '
            Common.Message.MessageShow("E004")
            Return Student
        End If

        '試験結果集計_ヘッダ
        TestHead = cGroup.GetTestResultHeaderSum(Mode, Group)
        If IsNothing(TestHead) Then
            '
            Common.Message.MessageShow("E004")
            Return TestHead
        End If

        '試験結果集計_明細
        TestDetail = cGroup.GetTestResultDetailSum(Mode, Group)
        If IsNothing(TestDetail) Then
            '
            Common.Message.MessageShow("E004")
            Return TestDetail
        End If


        ''主キー設定
        KeyUserId(0) = Student.Columns("USERID")
        Student.PrimaryKey = KeyUserId

        dataBanker("Student") = Student

        'マージ
        TestHead = cGroup.TestHeadStudentMergr(TestHead, Student)
        dataBanker("TestResultHeaderSum") = TestHead

        ''主キー設定
        KeyUserId(0) = TestHead.Columns("USERID")
        KeyUserId(1) = TestHead.Columns("TESTCOUNT")
        TestHead.PrimaryKey = KeyUserId

        ''主キー設定
        KeyUserId(0) = TestDetail.Columns("USERID")
        KeyUserId(1) = TestDetail.Columns("TESTCOUNT")
        KeyUserId(2) = TestDetail.Columns("QUESTIONNO")
        TestDetail.PrimaryKey = KeyUserId

        'マージ
        ReturnTestDetail = cGroup.TestHeadDetailMergr(TestDetail, TestHead)


        Return ReturnTestDetail
    End Function

    ''' <summary>
    ''' 分類別評価作成
    ''' </summary>
    ''' <param name="TestDetail">個人試験結果_明細</param>
    ''' <param name="Where">抽出条件</param>
    ''' <returns>分野別評価抽出結果</returns>
    ''' <remarks></remarks>
    Private Function ClassAssessment(ByVal TestDetail As System.Data.DataTable, ByVal Where As String) As System.Data.DataTable
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        Dim TestHead As New System.Data.DataTable
        Dim sumTest As New System.Data.DataTable
        Dim sumTRow As DataRow
        Dim sumTRows() As DataRow
        Dim Category1 As Array = {(CST_CATEGORY1), (CST_CATEGORY2), (CST_CATEGORY3)}
        Dim Category2 As Array = {CST_LARGE_CATEGORY1_1, CST_LARGE_CATEGORY1_2, CST_LARGE_CATEGORY1_3,
                                  CST_LARGE_CATEGORY2_1, CST_LARGE_CATEGORY2_2, CST_LARGE_CATEGORY2_3,
                                  CST_LARGE_CATEGORY3_1, CST_LARGE_CATEGORY3_2, CST_LARGE_CATEGORY3_3}
        'カラム作成
        sumTest.Columns.Add("GROUPCODE", GetType(String))
        sumTest.Columns.Add("COURSE", GetType(String))
        sumTest.Columns.Add("USERID", GetType(String))
        sumTest.Columns.Add("TESTCOUNT", GetType(String))
        sumTest.Columns.Add(Common.Constant.CST_TOTALASSESSMENT, GetType(Integer))
        For Each Cate As String In Category1
            sumTest.Columns.Add(CST_SCOREANALYSIS_COL & Cate, GetType(Integer))
            sumTest.Columns.Add(CST_SCOREANALYSIS_COL & Cate & CST_SCOREANALYSIS_RANK, GetType(Integer))
        Next
        For Each Cate As String In Category2
            sumTest.Columns.Add(CST_SCOREANALYSIS_COL & Cate, GetType(Integer))
            sumTest.Columns.Add(CST_SCOREANALYSIS_COL & Cate & CST_SCOREANALYSIS_RANK, GetType(Integer))
        Next
        sumTest.Columns.Add(Common.Constant.CST_TOTALASSESSMENT & CST_SCOREANALYSIS_RANK, GetType(Integer))

        '分類
        TestHead = dataBanker("TestResultHeaderSum")
        Dim UserId As String = TestHead.Rows(0)("USERID").ToString


        For Each TRow As DataRow In TestHead.Select(Where & "AND TESTCOUNT > '0'")

            'ユーザ+テスト回数選択
            sumTRows = sumTest.Select("GROUPCODE = '" & TRow("GROUPCODE") & "' AND USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "'")
            If sumTRows.Length = 0 Then
                sumTRow = sumTest.NewRow()
                sumTRow.Item("GROUPCODE") = TRow("GROUPCODE")
                sumTRow.Item("USERID") = TRow("USERID")
                sumTRow.Item("TESTCOUNT") = TRow("TESTCOUNT")
                For Each col As DataColumn In sumTest.Columns
                    If col.ColumnName <> "USERID" And col.ColumnName <> "TESTCOUNT" Then
                        sumTRow.Item(col.ColumnName) = 0
                    End If
                Next
                sumTest.Rows.Add(sumTRow)
                sumTRows = sumTest.Select("USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "'")
            End If

            For Each Cate As String In Category1
                sumTRows(0).Item(CST_SCOREANALYSIS_COL & Cate) = TestDetail.Compute("COUNT(USERID)",
                Where & "AND USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "' AND CATEGORY1 = '" & Cate.ToString & "' AND ERRATA = '1'")
            Next
            For Each Cate As String In Category2
                sumTRows(0).Item(CST_SCOREANALYSIS_COL & Cate) = TestDetail.Compute("COUNT(USERID)",
                Where & "AND USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "' AND CATEGORY2 = '" & Cate.ToString & "' AND ERRATA = '1'")
            Next
            sumTRows(0).Item(Common.Constant.CST_TOTALASSESSMENT) = TestDetail.Compute("COUNT(USERID)",
            Where & "AND USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "' AND ERRATA = '1'")
        Next

        '総合行作成
        sumTRow = sumTest.NewRow()
        sumTRow.Item("USERID") = Common.Constant.CST_TOTALASSESSMENT
        For Each col As DataColumn In sumTest.Columns
            If col.ColumnName <> "USERID" And col.ColumnName <> "TESTCOUNT" Then
                sumTRow.Item(col.ColumnName) = 0
            End If
        Next
        sumTest.Rows.Add(sumTRow)
        sumTRows = sumTest.Select("USERID = '" & Common.Constant.CST_TOTALASSESSMENT & "'")

        For Each Cate As String In Category1
            sumTRows(0).Item(CST_SCOREANALYSIS_COL & Cate) =
                TestDetail.Compute("COUNT(USERID)", Where & "AND CATEGORY1 = '" & Cate.ToString & "'")
        Next
        For Each Cate As String In Category2
            sumTRows(0).Item(CST_SCOREANALYSIS_COL & Cate) =
                TestDetail.Compute("COUNT(USERID)", Where & "AND CATEGORY2 = '" & Cate.ToString & "'")
        Next
        sumTRows(0).Item(Common.Constant.CST_TOTALASSESSMENT) =
            TestDetail.Compute("COUNT(USERID)", Where)

        '順位設定
        For Each Cate As String In Category1
            '
            SetRank(sumTest, CST_SCOREANALYSIS_COL & Cate, "DESC")
        Next
        For Each Cate As String In Category2
            '
            SetRank(sumTest, CST_SCOREANALYSIS_COL & Cate, "DESC")
        Next
        Dim Total As Integer
        Total = SetRank(sumTest, Common.Constant.CST_TOTALASSESSMENT, "DESC")
        dataBanker("SELECTTOTAL") = Total

        Return sumTest
    End Function

    ''' <summary>
    ''' 順位設定
    ''' </summary>
    ''' <param name="TmpTable">元データ</param>
    ''' <param name="Item">ソートアイテム</param>
    ''' <param name="Sort">ソート順</param>
    ''' <returns>順位数</returns>
    ''' <remarks></remarks>
    Private Function SetRank(ByVal TmpTable As System.Data.DataTable, ByVal Item As String, ByVal Sort As String) As Integer

        Dim RankView As New DataView

        Dim PreTotalPoints As Integer = 0
        Dim PreRankNo As Integer = 0
        Dim RankNo As Integer = 0

        RankView = New DataView(TmpTable)

        RankView.RowFilter = "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "' AND TESTCOUNT > '0'"
        RankView.Sort = Item & " " & Sort

        For Each row As DataRowView In RankView
            If IsNumeric(row(Item)) Then
                RankNo += 1
                If PreTotalPoints <> CInt(row(Item)) Then
                    PreTotalPoints = CInt(row(Item))
                    row(Item & CST_SCOREANALYSIS_RANK) = RankNo
                    PreRankNo = RankNo
                Else
                    row(Item & CST_SCOREANALYSIS_RANK) = PreRankNo
                End If
            End If
        Next

        Return RankNo
    End Function

    ''' <summary>
    ''' 表示データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDispData(ByVal sumTest As System.Data.DataTable)
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        'Dim RankName As Array = {CategoryMaster.GetCategoryName("1"),
        '                         CategoryMaster.GetCategoryName("5"),
        '                         CategoryMaster.GetCategoryName("9"),
        '                         Common.Constant.CST_TOTALASSESSMENT}

        Dim SelectRow As New DataGridViewRow
        Dim MenuMode As Integer = 0
        Dim SelectTotal As Integer = dataBanker("SELECTTOTAL").ToString

        Dim TestDetail As New System.Data.DataTable

        If dataBanker("SYSMODE") = Common.Constant.CST_MENUMODE_SYSTEM Then
            MenuMode = 1
        End If

        ''個人試験結果_明細取得 ??
        'TestDetail = dataBanker("TestDetail")

        Dim sumTRows2() As DataRow
        Dim tmpObj As Object
        Dim QuestionCount As Integer

        lblTotal.Text = SelectTotal & "人"

        sumTRows2 = sumTest.Select("USERID = '" & Common.Constant.CST_TOTALASSESSMENT & "'")
        If sumTRows2.Length > 0 Then
            '分野別評価
            For Each GRow As DataGridViewRow In grdResultList.Rows
                For Each col As Object In sumTest.Columns
                    If GRow.Cells(CATEGORYID.Index).Value = col.ToString Then
                        QuestionCount = sumTRows2(0)(col.ToString)

                        '平均正解率(合計/人数/出題数）
                        tmpObj = sumTest.Compute("SUM(" & col.ToString & ")", "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "'")
                        If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                            GRow.Cells("AVEPER").Value =
                            cGroup.ToRoundDown((CLng(tmpObj) / QuestionCount), 3).ToString("0.0%")
                        Else
                            GRow.Cells("AVEPER").Value = "0.0%"
                        End If
                        '最高正解率(最高正回数/出題数)
                        tmpObj = sumTest.Compute("MAX(" & col.ToString & ")", "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "' AND USERID NOT = ''")
                        If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                            GRow.Cells("MAXPER").Value =
                                cGroup.ToRoundDown(CInt(tmpObj) / (QuestionCount / SelectTotal), 3).ToString("0.0%")
                        Else
                            GRow.Cells("MAXPER").Value = "0.0%"
                        End If
                        '最低正解率(最低正回数/出題数)
                        tmpObj = sumTest.Compute("MIN(" & col.ToString & ")", "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "' AND USERID NOT = ''")
                        If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                            GRow.Cells("MINPER").Value =
                                cGroup.ToRoundDown(CInt(tmpObj) / (QuestionCount / SelectTotal), 3).ToString("0.0%")
                        Else
                            GRow.Cells("MINPER").Value = "0.0%"
                        End If

                    End If
                Next
            Next

            '総合
            grdResultList.Rows(9).Cells(2).Value = (sumTRows2(0)(Common.Constant.CST_TOTALASSESSMENT)).ToString & Common.Constant.CST_QUESTION_UNIT
            QuestionCount = CInt(sumTRows2(0)(Common.Constant.CST_TOTALASSESSMENT))
            '平均正解率
            tmpObj = sumTest.Compute("SUM(" & Common.Constant.CST_TOTALASSESSMENT & ")", "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "'")
            If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                grdResultList.Rows(9).Cells("AVEPER").Value = cGroup.ToRoundDown((CLng(tmpObj) / QuestionCount), 3).ToString("0.0%")
            Else
                grdResultList.Rows(9).Cells("AVEPER").Value = "0.0%"
            End If
            '最高正解率
            tmpObj = sumTest.Compute("MAX(" & Common.Constant.CST_TOTALASSESSMENT & ")", "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "'")
            If IsNumeric(tmpObj.ToString) Then
                grdResultList.Rows(9).Cells("MAXPER").Value = cGroup.ToRoundDown(CInt(tmpObj) / 100, 3).ToString("0.0%")
            Else
                grdResultList.Rows(9).Cells("MAXPER").Value = "0.0%"
            End If
            '最低正解率
            tmpObj = sumTest.Compute("MIN(" & Common.Constant.CST_TOTALASSESSMENT & ")", "USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT & "'")
            If IsNumeric(tmpObj.ToString) Then
                grdResultList.Rows(9).Cells("MINPER").Value = cGroup.ToRoundDown(CInt(tmpObj) / 100, 3).ToString("0.0%")
            Else
                grdResultList.Rows(9).Cells("MINPER").Value = "0.0%"
            End If
        End If

    End Sub

    ''' <summary>
    ''' グラフ値設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetChartData(ByVal sumTest As System.Data.DataTable)
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim TestDetail As New System.Data.DataTable

        Dim xValues As Array = {0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100}
        Dim yValues As Array = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim Count As Integer

        'ユーザ毎に取得（総合を除く）
        For Each Row As DataRow In sumTest.Select("USERID NOT = '" & Common.Constant.CST_TOTALASSESSMENT.ToString & "'")
            For i As Integer = 0 To 10
                Count = (Row(Common.Constant.CST_TOTALASSESSMENT) \ 10) * 10
                If xValues(i) = Count Then
                    yValues(i) += 1
                    '#T
                    'Debug.WriteLine(Row("USERID") & ":" & Row(Common.Constant.CST_TOTALASSESSMENT))
                End If
            Next
        Next

        crtTotal.Series("Series1").Points.DataBindXY(xValues, yValues)
        dataBanker("CHARTTOTAL_Y") = yValues

    End Sub

    ''' <summary>
    ''' エクセル保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExcelSave(ByVal FileName As String)
        'リソースを保存
        'ResourcesSave()
        'データ挿入
        SetExcelData(FileName)
    End Sub

    ''' <summary>
    ''' リソース保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResourcesSave()
        '保存
        My.Computer.FileSystem.WriteAllBytes(Common.Constant.GetTempPath & "..\Base_C.xls", My.Resources.ScoreAnalysis, True)

    End Sub

    ''' <summary>
    ''' テンポラリ削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResourcesDel()
        '削除
        If IO.File.Exists(Common.Constant.GetTempPath & "..\Base_C.xls") Then
            My.Computer.FileSystem.DeleteFile(Common.Constant.GetTempPath & "..\Base_C.xls")
        End If
    End Sub

    ''' <summary>
    ''' 個人詳細受験結果表示用データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetExcelData(ByVal FileName As String)
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim xlApps As Excel.Application = Nothing
        Dim xlBooks As Excel.Workbook = Nothing
        Dim xlSheets As Excel.Sheets = Nothing
        Dim xlSheet As Excel.Worksheet = Nothing

        Dim xlRange As Excel.Range
        Dim strDat(0, 0) As Object
        Dim xlLine(0, 15) As Object
        Dim xlChart(0, 11) As Object

        Dim iRow As Integer = 24
        Dim ChartPoint() As Integer
        Dim st As Integer = System.Environment.TickCount

        Dim CategoryNameString As Array = {CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_1),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_2),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_3),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_1),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_2),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_3),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_1),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_2),
                                           CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_3)}

        Dim CategoryName As Array = {CST_FIELD_LARGE_CATEGORY1_1,
                                     CST_FIELD_LARGE_CATEGORY1_2,
                                     CST_FIELD_LARGE_CATEGORY1_3,
                                     CST_FIELD_LARGE_CATEGORY2_1,
                                     CST_FIELD_LARGE_CATEGORY2_2,
                                     CST_FIELD_LARGE_CATEGORY2_3,
                                     CST_FIELD_LARGE_CATEGORY3_1,
                                     CST_FIELD_LARGE_CATEGORY3_2,
                                     CST_FIELD_LARGE_CATEGORY3_3}

        xlApps = New Excel.Application
        xlBooks = xlApps.Workbooks.Open(Common.Constant.GetTempPath & "..\Base_C.xls")

        xlSheets = xlBooks.Worksheets
        xlSheet = CType(xlSheets.Item(1), Excel.Worksheet)
        xlApps.Visible = False

        '分野名
        xlRange = xlSheet.Range(CST_FIELD1)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY1) & "："
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELD2)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY2) & "："
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELD3)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY3) & "："
        xlRange.Value = strDat

        '分野別正解率
        '分野
        xlRange = xlSheet.Range(CST_FIELDHEADER1)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY1)
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELDHEADER2)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY2)
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELDHEADER3)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY3)
        xlRange.Value = strDat
        '大分類
        For i = 0 To 8
            xlRange = xlSheet.Range(CategoryName(i))
            strDat(0, 0) = CategoryNameString(i)
            xlRange.Value = strDat
        Next

        '団体名
        xlRange = xlSheet.Range("Z6")
        strDat(0, 0) = dataBanker("cmbGroup").ToString
        xlRange.Value = strDat

        '抽出条件
        '団体名
        xlRange = xlSheet.Range("G10")
        strDat(0, 0) = dataBanker("cmbGroup").ToString
        xlRange.Value = strDat
        '試験名
        xlRange = xlSheet.Range("Q10")
        strDat(0, 0) = dataBanker("cmbCourse").ToString
        xlRange.Value = strDat
        '受験回
        xlRange = xlSheet.Range("X10")
        strDat(0, 0) = dataBanker("cmbInning").ToString
        xlRange.Value = strDat
        '区分１
        xlRange = xlSheet.Range("AE10")
        strDat(0, 0) = dataBanker("cmbSection1").ToString
        xlRange.Value = strDat
        '区分２
        xlRange = xlSheet.Range("AJ10")
        strDat(0, 0) = dataBanker("cmbSection2").ToString
        xlRange.Value = strDat
        '受験日
        xlRange = xlSheet.Range("G12")
        strDat(0, 0) = dataBanker("udtpStart").ToString & " ～　" & dataBanker("udtpEnd").ToString
        xlRange.Value = strDat
        '合否
        xlRange = xlSheet.Range("W12")
        strDat(0, 0) = dataBanker("cmbPass")
        xlRange.Value = strDat
        'ストラテジ系
        If dataBanker("txtStrategyStart").ToString <> "" Or
           dataBanker("txtStrategyEnd").ToString <> "" Then
            xlRange = xlSheet.Range("K14")
            strDat(0, 0) = dataBanker("txtStrategyStart").ToString & "点以上　～ " &
                          dataBanker("txtStrategyEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        'マネジネント系
        If dataBanker("txtManagementStart").ToString <> "" Or
           dataBanker("txtManagementEnd").ToString <> "" Then
            xlRange = xlSheet.Range("Z14")
            strDat(0, 0) = dataBanker("txtManagementStart").ToString & "点以上　～ " &
                          dataBanker("txtManagementEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        'テクノロジ系
        If dataBanker("txtTechnologyStart").ToString <> "" Or
           dataBanker("txtTechnologyEnd").ToString <> "" Then
            xlRange = xlSheet.Range("K16")
            strDat(0, 0) = dataBanker("txtTechnologyStart").ToString & "点以上　～ " &
                          dataBanker("txtTechnologyEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        '総合評価
        If dataBanker("txtTotalStart").ToString <> "" Or
           dataBanker("txtTotalEnd").ToString <> "" Then
            xlRange = xlSheet.Range("Z16")
            strDat(0, 0) = dataBanker("txtTotalStart").ToString & "点以上　～ " &
                          dataBanker("txtTotalEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        '対象人数　
        xlRange = xlSheet.Range("J19")
        strDat(0, 0) = lblTotal.Text
        xlRange.Value = strDat

        '分野別正解率
        For i As Integer = 0 To Me.grdResultList.Rows.Count - 1
            xlRange = xlSheet.Cells(i + iRow, 18).Resize(1, 15)
            xlRange.Borders.LineStyle = True
            xlLine(0, 0) = grdResultList.Rows(i).Cells("AVEPER").Value
            xlLine(0, 5) = grdResultList.Rows(i).Cells("MAXPER").Value
            xlLine(0, 10) = grdResultList.Rows(i).Cells("MINPER").Value
            xlRange.Value = xlLine
        Next

        '対象人数　
        ChartPoint = dataBanker("CHARTTOTAL_Y")
        xlRange = xlSheet.Range("D41:N41")
        For i As Integer = 0 To 10
            xlChart(0, i) = ChartPoint(i)
        Next
        xlRange.Value = xlChart

        'ファイルの保存処理
        Dim xlFilePath As String = FileName  '保存ファイル名

        xlApps.DisplayAlerts = False    '保存時の問合せのダイアログを非表示に設定
        Try
            xlSheet.SaveAs(xlFilePath)
            dataBanker("PRINTERR") = True
        Catch
            Common.Message.MessageShow("E017")
            dataBanker("PRINTERR") = False
        End Try
        xlApps.DisplayAlerts = True     '元に戻す

        '終了処理
        MRComObject(xlSheet)            'xlSheet の解放
        MRComObject(xlSheets)           'xlSheets の解放
        xlBooks.Close(False)            'xlBook を閉じる
        MRComObject(xlBooks)            'xlBook の解放
        xlApps.Quit()                   'Excelを閉じる 
        MRComObject(xlApps)             'xlApps を解放

        '-------------------------------------------------------------------------
        Do While System.Environment.TickCount - st < 500
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(20)
            If Process.GetProcessesByName("Excel").Length = 0 Then
                'MessageBox.Show("Excel.EXE は解放されました。")
                Exit Do
            End If
        Loop
        If Process.GetProcessesByName("Excel").Length >= 1 Then
            'MessageBox.Show("まだ Excel.EXE が起動しています。")
            Debug.WriteLine("まだ Excel.EXE が起動しています。")
            '一度メッセージボックスを表示すると解放されるようなので再度確認
            If Process.GetProcessesByName("Excel").Length = 0 Then
                'MessageBox.Show("Excel.EXE は解放されました。")
            End If
        End If


    End Sub

    ''' <summary>
    ''' 解放
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub MRComObject(Of T As Class)(ByRef objCom As T, Optional ByVal force As Boolean = False)
        If objCom Is Nothing Then
            Return
        End If
        Try
            If System.Runtime.InteropServices.Marshal.IsComObject(objCom) Then
                If force Then
                    'FinalReleaseComObject は、.NET Framework version 2.0 で新しく追加されたもので
                    '一度の呼び出しで参照カウントを 0 に設定します。
                    '下記のように 0 を返すまでループ内で ReleaseComObject を呼び出すことと同じです。
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objCom)
                Else
                    Dim count As Integer = System.Runtime.InteropServices.Marshal.ReleaseComObject(objCom)
                    'Debug.WriteLine(count)  '0 以上が表示されたら、解放されていない分がある
                    '0 になる事を期待(使い終った)していたなら、force = True で試して見て下さい。
                End If
            End If
        Finally
            objCom = Nothing
        End Try
    End Sub

#End Region

End Class