Imports CST.CBT.eIPSTA.Common
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports CST.CBT.eIPSTA.QuestionShow
Imports System.IO

''' <summary>
''' 問別分析結果
''' </summary>
''' <remarks>
''' 2011/09/08 NAKAMURA 新規作成
''' </remarks>
Public Class frmQuestionReport
#Region "----- メンバ変数 -----"

    ''' <summary>問題バンク</summary>
    Private questionBankCol As New QuestionBankCollection
    ''' <summary>データバンカー</summary>
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    ''' <summary>グループ関数</summary>
    Private cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    ''' <summary>
    ''' 分野名ID
    ''' </summary>
    Private CST_CATEGORY1 As String = Common.CategoryMaster.categoryId.fieldCategoryId_A
    Private CST_CATEGORY2 As String = Common.CategoryMaster.categoryId.fieldCategoryId_B
    Private CST_CATEGORY3 As String = Common.CategoryMaster.categoryId.fieldCategoryId_C

    '帳票

    ''' <summary>
    ''' 分野名
    ''' </summary>
    Private Const CST_FIELD1 As String = "Field1"
    Private Const CST_FIELD2 As String = "Field2"
    Private Const CST_FIELD3 As String = "Field3"
#End Region

#Region "イベントハンドラ"

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmbtnQuestionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    ''' 管理者メインメニューへ戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            'リソース削除
            ResourcesDel()
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = "KG01"
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 
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
    ''' 保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            logger.Start()
            sfdExcel.Filter = "Excel ファイル (*.xls)|*.xls"
            sfdExcel.FileName = "問別分析結果.xls"
            sfdExcel.FilterIndex = 2
            sfdExcel.RestoreDirectory = True

            If sfdExcel.ShowDialog() = DialogResult.OK Then
                Me.processMessageOutput = True

                btnSave.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                Me.Refresh()
                grdResultList.Sort(grdResultList.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

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
    ''' 再検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

            Dim TestDetail, TestResultSum As System.Data.DataTable
            Dim QBTable As New System.Data.DataTable
            Dim Where As String
            Dim MenuMode As Integer

            If dataBanker("SYSMODE") = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                MenuMode = 1
            End If

            '項目チェック # パラメータ設定
            If ItemCheck(MenuMode) Then

                TestDetail = dataBanker("TESTDETAIL")
                TestResultSum = dataBanker("TESTRESULTSUM")

                '受験取得
                Where = CreateWhere(MenuMode)

                '問題取得
                QBTable = GetOuestionBank(cmbGroup.SelectedValue)
                If QBTable.Rows.Count <= 0 Then
                    'データなし
                    Common.Message.MessageShow("I002")
                    Exit Sub
                Else
                    dataBanker("QBTable") = QBTable
                End If

                If TestDetail.Select(Where).Length > 0 Then
                    TestResultSum = GetTestResultSum(TestDetail, TestResultSum, Where)

                    SetDispData(TestResultSum, QBTable)
                    '抽出条件保存
                    SetSearchKey()
                Else
                    'データなし
                    Common.Message.MessageShow("I002")
                    Exit Sub
                End If
            End If

            '保存ボタン操作
                btnSave.Enabled = DataManager.GetInstance.IsExcel
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
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
        Catch ex As Exception
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
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        Dim GroupTbl As New System.Data.DataTable
        Dim CourseTbl As New System.Data.DataTable

        Dim Student As New System.Data.DataTable
        Dim TestHead As New System.Data.DataTable
        Dim TestDetail As New System.Data.DataTable
        Dim TestResultSum As New System.Data.DataTable
        Dim KeyUserId(0) As DataColumn

        Dim MenuMode As Integer = 0

        Me.lblBottomCode.Text = "KG13"
        Me.lblBottomName.Text = "問別分析結果画面"
        Me.UserId = "ID：" & dataBanker.Item("USERID")
        Me.UserName = "氏名：" & dataBanker.Item("USERNAME")

        lblField1.Text = CategoryMaster.GetCategoryName(CST_CATEGORY1)
        lblField2.Text = CategoryMaster.GetCategoryName(CST_CATEGORY2)
        lblField3.Text = CategoryMaster.GetCategoryName(CST_CATEGORY3)

        With grdResultList
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            For i As Int16 = 0 To 9
                If .Columns(i).DataPropertyName = "QUESTIONNO" Or .Columns(i).DataPropertyName = "ERRATA" Then
                    .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
                If .Columns(i).DataPropertyName = "SELECTNULL" Then
                    .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
                End If
                .Columns(i).DefaultCellStyle.SelectionBackColor = Color.White
                .Columns(i).DefaultCellStyle.SelectionForeColor = Color.Black
            Next
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

        grdResultList.Rows.Add(16)

        'データ取得
        GroupTbl = dataBanker.Item("GROUPTABLE")
        CourseTbl = dataBanker.Item("COURSETABLE")

        '団体コンボ
        cmbGroup.DataSource = GroupTbl
        If GroupTbl.Rows.Count > 0 Then
            cmbGroup.SelectedIndex = 0
        End If

        '受験回
        cmbInning.DataSource = CST.CBT.eIPSTA.Common.Constant.CST_TESTCOUNT2_CMB
        '区分１
        cmbSection1.DataSource = CST.CBT.eIPSTA.Common.Constant.CST_SECTION1_CMB
        '区分２
        cmbSection2.DataSource = CST.CBT.eIPSTA.Common.Constant.CST_SECTION2_CMB

        '日付
        Dim dStart As DateTime = DateTime.Now
        udtpStart.Text = ""
        udtpEnd.Text = ""

        '合否
        cmbPass.DataSource = CST.CBT.eIPSTA.Common.Constant.CST_PASS_CMB

        If dataBanker("SYSMODE") <> CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
            cmbInning.Select()
            cmbCourse.Text = dataBanker("COURSE")
            'コントロール使用不可
            cmbGroup.Enabled = False
            cmbCourse.Enabled = False
        Else
            cmbGroup.Select()
            MenuMode = 1
        End If

        '受講者
        Student = cGroup.GetStudent(MenuMode, dataBanker("GROUPCODE"))
        ''主キー設定
        KeyUserId(0) = Student.Columns("USERID")
        Student.PrimaryKey = KeyUserId

        '個人試験結果_ヘッダ取得
        TestHead = cGroup.GetTestResultHeaderSum(MenuMode, dataBanker("GROUPCODE"))
        If TestHead.Rows.Count = 0 Then
            'データなし
            Common.Message.MessageShow("E021", {"試験情報"})
            btnQuestion.PerformClick()
            Exit Sub
        End If
        'マージ
        TestHead = cGroup.TestHeadStudentMergr(TestHead, Student)

        '個人試験結果_明細取得
        TestDetail = cGroup.GetTestResultDetailSum(MenuMode, dataBanker("GROUPCODE"))
        If TestDetail.Rows.Count = 0 Then
            'データなし
            Common.Message.MessageShow("E021", {"試験情報"})
            btnQuestion.PerformClick()
            Exit Sub
        End If
        'マージ
        TestDetail = cGroup.TestHeadDetailMergr(TestDetail, TestHead)

        '問題別集計準備
        TestResultSum = GetTestResultSumInit(TestDetail)
        If TestResultSum.Rows.Count = 0 Then
            '
            Common.Message.MessageShow("E021", {"試験情報"})
            btnQuestion.PerformClick()
            Exit Sub
        End If

        '保存ボタン使用不可
        btnSave.Enabled = False

        'データ格納
        dataBanker("TESTDETAIL") = TestDetail
        dataBanker("TESTRESULTSUM") = TestResultSum

        '帳票用リソース保存
        ResourcesSave()

    End Sub


    ''' <summary>
    ''' 問題別集計準備
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetTestResultSumInit(ByVal TestDetail As System.Data.DataTable) As System.Data.DataTable
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        Dim TestResultSum As System.Data.DataTable
        Dim SumRow As DataRow
        Dim DRows() As DataRow
        Dim KeyUserId(0) As DataColumn

        TestResultSum = TestDetail.Clone
        KeyUserId(0) = TestResultSum.Columns("QUESTIONNO")
        TestResultSum.PrimaryKey = KeyUserId
        TestResultSum.Columns.Remove("USERID")
        TestResultSum.Columns.Remove("TESTCOUNT")
        TestResultSum.Columns.Add("SELECT1", GetType(Integer))
        TestResultSum.Columns.Add("SELECT2", GetType(Integer))
        TestResultSum.Columns.Add("SELECT3", GetType(Integer))
        TestResultSum.Columns.Add("SELECT4", GetType(Integer))
        TestResultSum.Columns.Add("SELECTNULL", GetType(Integer))

        '行の用意
        For i As Integer = 0 To 99
            SumRow = TestResultSum.NewRow
            SumRow("QUESTIONNO") = (i + 1).ToString
            DRows = TestDetail.Select("QUESTIONNO = '" & SumRow("QUESTIONNO") & "'")
            SumRow("CATEGORY1") = CategoryMaster.GetCategoryName(DRows(0)("CATEGORY1"))
            SumRow("CATEGORY2") = CategoryMaster.GetCategoryName(DRows(0)("CATEGORY2"))
            SumRow("QUESTIONTHEME") = DRows(0)("QUESTIONTHEME")
            For Each Col As DataColumn In TestResultSum.Columns
                If Col.ColumnName.Length < 6 Then
                ElseIf Col.ColumnName.Substring(0, 6) = "SELECT" Then
                    SumRow(Col.ColumnName) = 0
                End If
            Next
            SumRow("ERRATA") = 0
            TestResultSum.Rows.Add(SumRow)
        Next

        Return TestResultSum
    End Function

    ''' <summary>
    ''' 問題別集計再設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Function GetTestResultSum(ByVal TestDetail As System.Data.DataTable, ByVal TestResultSum As System.Data.DataTable, ByVal Where As String) As System.Data.DataTable
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        Dim ReturnTestResultSum As System.Data.DataTable
        Dim Num As Integer
        Dim ColName As String
        Dim Errata As Integer
        Dim SelectMark As String = "アイウエ"

        ReturnTestResultSum = TestResultSum.Copy
        For Each RRow As DataRow In ReturnTestResultSum.Rows
            For Each DRow As DataRow In TestDetail.Select(Where & " AND QUESTIONNO = '" & RRow("QUESTIONNO") & "'")
                RRow("CATEGORY1") = DRow("CATEGORY1")
                RRow("CATEGORY2") = DRow("CATEGORY2")
                RRow("QUESTIONTHEME") = DRow("QUESTIONTHEME")
                If Not IsDBNull(DRow("ANSWER")) Then
                    If DRow("ANSWER") <> "" Then
                        Num = CST.CBT.eIPSTA.Common.Constant.CST_SELECTMARK.IndexOf(DRow("ANSWER"))
                        If Num = -1 Then
                            Num = SelectMark.IndexOf(DRow("ANSWER"))
                        End If
                        If 0 <= Num Then
                            ColName = "SELECT" & (Num + 1).ToString
                            RRow(ColName) += 1
                        Else
                            RRow("SELECTNULL") += 1
                        End If
                    Else
                        RRow("SELECTNULL") += 1
                    End If
                Else
                    RRow("SELECTNULL") += 1
                End If
                If DRow("ERRATA") = "1" Then
                    Errata = CInt(RRow("ERRATA"))
                    RRow("ERRATA") = Errata + 1
                End If
            Next
        Next

        Return ReturnTestResultSum
    End Function

    ''' <summary>
    ''' 表示データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDispData(ByVal TestResultSum As System.Data.DataTable, ByVal QBTable As System.Data.DataTable)

        Dim i As Integer = 0
        Dim Errata As Decimal
        Dim Select1 As Decimal
        Dim Select2 As Decimal
        Dim Select3 As Decimal
        Dim Select4 As Decimal
        Dim SelectNull As Decimal
        Dim Total As Integer
        Dim Answer As Integer
        Dim QuestSelect As String = "アイウエオ"
        Dim QuestNo As Integer

        'カテゴリ
        Dim categoryMaster As New Common.CategoryMaster
        Dim categoryTable = categoryMaster.GetAll()
        If IsNothing(TestResultSum.DataSet) Then
            Dim tmpDataset As New DataSet
            tmpDataset.Tables.Add(TestResultSum)
        End If
        TestResultSum.DataSet.Tables.Add(categoryTable.Copy)
        Dim relation As DataRelation = New DataRelation("CATEGORY1R",
                                                 TestResultSum.DataSet.Tables("CATEGORY").Columns("CATEGORYID"),
                                                 TestResultSum.Columns("CATEGORY1"), False)
        TestResultSum.DataSet.Relations.Add(relation)
        Dim relation2 As DataRelation = New DataRelation("CATEGORY2R",
                                                 TestResultSum.DataSet.Tables("CATEGORY").Columns("CATEGORYID"),
                                                 TestResultSum.Columns("CATEGORY2"), False)
        TestResultSum.DataSet.Relations.Add(relation2)
        TestResultSum.Columns.Add("CATEGORYNAME1", GetType(String), "Parent(CATEGORY1R).CATEGORYNAME")
        TestResultSum.Columns.Add("CATEGORYNAME2", GetType(String), "Parent(CATEGORY2R).CATEGORYNAME")

        With grdResultList
            .Rows.Clear()

            For Each Row As DataRow In TestResultSum.Rows
                .Rows.Add()
                QuestNo = CInt(Row("QUESTIONNO").ToString)
                .Rows(i).Cells("QUESTIONNO").Value = QuestNo
                .Rows(i).Cells("CATEGORY1").Value = Row("CATEGORYNAME1")
                .Rows(i).Cells("CATEGORY2").Value = Row("CATEGORYNAME2")
                .Rows(i).Cells("QUESTIONTHEME").Value = Row("QUESTIONTHEME")

                Total = (Row("SELECT1")) + (Row("SELECT2")) + (Row("SELECT3")) + (Row("SELECT4")) + (Row("SELECTNULL"))
                If Total = 0 Then
                    Errata = Select1 = Select2 = Select3 = Select4 = SelectNull = 0
                Else
                    Errata = cGroup.ToRoundDown((Row("ERRATA")) / Total, 3)
                    Select1 = cGroup.ToRoundDown((Row("SELECT1")) / Total, 3)
                    Select2 = cGroup.ToRoundDown((Row("SELECT2")) / Total, 3)
                    Select3 = cGroup.ToRoundDown((Row("SELECT3")) / Total, 3)
                    Select4 = cGroup.ToRoundDown((Row("SELECT4")) / Total, 3)
                    SelectNull = cGroup.ToRoundDown((Row("SELECTNULL")) / Total, 3)
                End If
                .Rows(i).Cells("ERRATA").Value = Errata
                .Rows(i).Cells("SELECT1").Value = Select1
                .Rows(i).Cells("SELECT2").Value = Select2
                .Rows(i).Cells("SELECT3").Value = Select3
                .Rows(i).Cells("SELECT4").Value = Select4
                .Rows(i).Cells("SELECTNULL").Value = SelectNull
                '正解解答の背景色変更
                If QBTable.Rows(QuestNo - 1)("ANSWER").ToString <> "" Then
                    .Rows(i).Cells("MIDDLE").Value = QBTable.Rows(QuestNo - 1)("MIDDLE")
                    Answer = QuestSelect.IndexOf(QBTable.Rows(QuestNo - 1)("ANSWER").ToString)
                    Answer = Answer + 1
                    .Rows(i).Cells("SELECT" & Answer.ToString).Style.BackColor = Color.Cyan
                    .Rows(i).Cells("SELECT" & Answer.ToString).Style.SelectionBackColor = Color.Cyan
                End If
                i += 1
            Next

        End With

    End Sub


    ''' <summary>
    ''' 抽出条件、項目チェック
    ''' </summary>
    ''' <returns></returns>
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
    ''' 抽出条件退避
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSearchKey()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        dataBanker("cmbGroup") = cmbGroup.SelectedValue
        dataBanker("cmbGroupText") = cmbGroup.Text
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
    ''' 抽出条件取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateWhere(ByVal mode As Integer) As String
        Dim Where As String = ""

        Where = "1 = 1 "

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
        If Me.cmbInning.SelectedItem = CST.CBT.eIPSTA.Common.Constant.CST_TESTCOUNT_CMB(1) Then
            Where += "AND TESTCOUNT = '1' "
        ElseIf Me.cmbInning.SelectedItem = CST.CBT.eIPSTA.Common.Constant.CST_TESTCOUNT_CMB(2) Then
            Where += "AND TESTCOUNT = '2' "
        ElseIf Me.cmbInning.SelectedItem = CST.CBT.eIPSTA.Common.Constant.CST_TESTCOUNT_CMB(3) Then
            Where += "AND TESTCOUNT = '0' "
        End If
        '区分１ 
        If Me.cmbSection1.SelectedIndex <> 0 Then
            Where += "AND SECTION1 = '" & Me.cmbSection1.SelectedItem.ToString & "' "
        End If
        '区分２
        If Me.cmbSection2.SelectedIndex <> 0 Then
            Where += "AND SECTION2 = '" & Me.cmbSection2.SelectedItem.ToString & "' "
        End If
        '合否（"全て", "合格のみ", "不合格のみ"）
        If Me.cmbPass.SelectedItem = CST.CBT.eIPSTA.Common.Constant.CST_PASS_CMB(1) Then
            Where += "AND RESULT = '1' "
        ElseIf Me.cmbPass.SelectedItem = CST.CBT.eIPSTA.Common.Constant.CST_PASS_CMB(2) Then
            Where += "AND RESULT = '0' "
        End If
        'ストラテジ系
        If IsNumeric(txtStrategyStart.Text) Then
            Where += "AND convert(CATEGORYPOINT1_A, 'System.Int32') >= " & txtStrategyStart.Text & " "
        End If
        If IsNumeric(txtStrategyEnd.Text) Then
            Where += "AND convert(CATEGORYPOINT1_A, 'System.Int32') <= " & txtStrategyEnd.Text & " "
        End If
        'マネジメント系
        If IsNumeric(txtManagementStart.Text) Then
            Where += "AND convert(CATEGORYPOINT1_B, 'System.Int32') >= " & txtManagementStart.Text & " "
        End If
        If IsNumeric(txtManagementEnd.Text) Then
            Where += "AND convert(CATEGORYPOINT1_B, 'System.Int32') <= " & txtManagementEnd.Text & " "
        End If
        'テクノロジ系
        If IsNumeric(txtTechnologyStart.Text) Then
            Where += "AND convert(CATEGORYPOINT1_C, 'System.Int32') >= " & txtTechnologyStart.Text & " "
        End If
        If IsNumeric(txtTechnologyEnd.Text) Then
            Where += "AND convert(CATEGORYPOINT1_C, 'System.Int32') <= " & txtTechnologyEnd.Text & " "
        End If
        '総合
        If IsNumeric(txtTotalStart.Text) Then
            Where += "AND convert(TOTALPOINTS, 'System.Int32') >= " & txtTotalStart.Text & " "
        End If
        If IsNumeric(txtTotalEnd.Text) Then
            Where += "AND convert(TOTALPOINTS, 'System.Int32')  <= " & txtTotalEnd.Text & " "
        End If
        Return Where
    End Function

    ''' <summary>
    ''' 問題取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetOuestionBank(ByVal GroupCode As String) As System.Data.DataTable
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        Dim TmpTable As New System.Data.DataTable
        Dim Row As DataRow
        Dim QFName As String
        Dim Middle As Integer = 1
        Dim PreMiddle As Integer = 0
        Dim PreMiddleStr As String = ""
        Dim MiddleIndex As Integer = 0

        'カラム準備
        TmpTable.Columns.Add("QUESTIONNO", GetType(String))         '問題番号
        TmpTable.Columns.Add("ANSWER", GetType(String))             '解答
        TmpTable.Columns.Add("MIDDLE", GetType(Integer))            '中問INDEX
        TmpTable.Columns.Add("MIDDLENO", GetType(String))           '表示用　中問番号
        TmpTable.Columns.Add("QUESTIONTHEME", GetType(String))      'テーマ

        '問題ファイル名取得
        QFName = cGroup.GetQuestionFileName(GroupCode)
        If IsNothing(QFName) OrElse QFName = "" Then
            Return TmpTable
            Exit Function
        End If
        dataBanker("QUESTIONFILENAME") = QFName
        If File.Exists(Common.Constant.GetTempPath & QFName) Then
            questionBankCol = Common.Serialize.BinaryFileToObject(QFName)
        Else
            Return TmpTable
            Exit Function
        End If
        
        For i As Integer = 0 To questionBankCol.Count - 1
            '中問
            If IsNothing(questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI)) Then
                Row = TmpTable.NewRow()
                Row("QUESTIONNO") = i + 1
                Row("ANSWER") = questionBankCol.Item(i).FirstAnsewr.ToString
                If Middle = PreMiddle Then
                    Middle += 1
                End If
                Row("MIDDLE") = 0
                TmpTable.Rows.Add(Row)
                PreMiddle = 0
            Else
                If PreMiddleStr = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI) Then
                    Row = TmpTable.NewRow()
                    Row("QUESTIONNO") = i + 1
                    Row("ANSWER") = questionBankCol.Item(i).FirstAnsewr.ToString
                    Row("MIDDLE") = MiddleIndex
                    Row("MIDDLENO") = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI).ToString
                    If Not IsNothing(questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_THEME)) Then
                        Row("QUESTIONTHEME") = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_THEME).ToString
                    End If
                    TmpTable.Rows.Add(Row)
                Else
                    PreMiddle = Middle
                    PreMiddleStr = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI)
                    MiddleIndex = i
                End If
            End If
        Next i

        Return TmpTable
    End Function


    ''' <summary>
    ''' エクセル保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExcelSave(ByVal FileName As String)
        'データ挿入
        SetExcelData(FileName)
    End Sub

    ''' <summary>
    ''' リソース保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResourcesSave()
        '保存
        My.Computer.FileSystem.WriteAllBytes(CST.CBT.eIPSTA.Common.Constant.GetTempPath & "..\Base.xls", My.Resources.QuestionReport, True)

    End Sub

    ''' <summary>
    ''' テンポラリ削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResourcesDel()
        '削除
        If IO.File.Exists(CST.CBT.eIPSTA.Common.Constant.GetTempPath & "..\Base.xls") Then
            My.Computer.FileSystem.DeleteFile(CST.CBT.eIPSTA.Common.Constant.GetTempPath & "..\Base.xls")
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
        Dim xlLine(0, 36) As Object
        Dim xlMiddle(0, 24) As Object

        Dim QBTable As System.Data.DataTable

        Dim iRow As Integer = 23
        Dim Middle As Integer
        Dim PreMiddle As Integer
        Dim QuestSelect As String = "アイウエオ"
        Dim ColorPoint As Array = {"AC", "AE", "AG", "AI"}
        Dim Answer As Integer

        Dim st As Integer = System.Environment.TickCount

        QBTable = dataBanker("QBTable")

        xlApps = New Excel.Application
        xlBooks = xlApps.Workbooks.Open(CST.CBT.eIPSTA.Common.Constant.GetTempPath & "..\Base.xls")

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

        '団体名
        xlRange = xlSheet.Range("Z6")
        strDat(0, 0) = dataBanker("cmbGroupText").ToString
        xlRange.Value = strDat

        '抽出条件
        '団体名
        xlRange = xlSheet.Range("G10")
        strDat(0, 0) = dataBanker("cmbGroupText").ToString
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

        For i As Integer = 0 To Me.grdResultList.Rows.Count - 1

            '中問の場合
            Middle = CInt(grdResultList.Rows(i).Cells("MIDDLE").Value)
            If Middle <> 0 And Middle <> PreMiddle Then
                PreMiddle = Middle
                '問題番号
                xlRange = xlSheet.Cells(i + iRow, 3).Resize(1, 1)
                strDat(0, 0) = "中問" & QBTable.Rows(i)("MIDDLENO")
                xlRange.Borders.LineStyle = True
                xlRange.Interior.Color = RGB(255, 255, 153)
                xlRange.Value = strDat


                'テーマ
                xlRange = xlSheet.Cells(i + iRow, 5).Resize(1, 22)
                'xlLine(0, 0) = QBTable.Rows(i)("QUESTIONTHEME")
                xlLine(0, 0) = questionBankCol.Item(QBTable.Rows(i)("MIDDLE")).QuestionProperty(Common.Constant.CST_THEME)
                xlRange.HorizontalAlignment = XlHAlign.xlHAlignLeft
                xlRange.MergeCells = True
                xlRange.Borders.LineStyle = True
                xlRange.Interior.Color = RGB(255, 255, 153)
                xlRange.Value = xlLine

                iRow += 1
            End If

            xlRange = xlSheet.Cells(i + iRow, 3).Resize(1, 36)
            xlRange.Borders.LineStyle = True

            With grdResultList

                xlLine(0, 0) = .Rows(i).Cells("QUESTIONNO").Value
                xlLine(0, 2) = .Rows(i).Cells("CATEGORY1").Value
                xlLine(0, 7) = .Rows(i).Cells("CATEGORY2").Value
                xlLine(0, 15) = .Rows(i).Cells("QUESTIONTHEME").Value
                xlLine(0, 24) = .Rows(i).Cells("ERRATA").Value
                xlLine(0, 26) = .Rows(i).Cells("SELECT1").Value
                xlLine(0, 28) = .Rows(i).Cells("SELECT2").Value
                xlLine(0, 30) = .Rows(i).Cells("SELECT3").Value
                xlLine(0, 32) = .Rows(i).Cells("SELECT4").Value
                xlLine(0, 34) = .Rows(i).Cells("SELECTNULL").Value
                xlRange.Value = xlLine
            End With
            '色変え
            If QBTable.Rows(i)("ANSWER") <> "" Then
                Answer = QuestSelect.IndexOf(QBTable.Rows(i)("ANSWER").ToString)
                xlRange = xlSheet.Range(ColorPoint(Answer) & (i + iRow).ToString)
                xlRange.Interior.Color = RGB(0, 255, 255)
            End If

            If i + iRow = 52 Then
                iRow += 18
            ElseIf i + iRow = 110 Then
                iRow += 18
            End If
        Next

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