Imports System
Imports System.IO

Imports CST.CBT
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.QuestionShow

''' <summary>
''' 個人詳細受験結果
''' </summary>
''' <remarks>
''' 2011/09/07 NAKAMURA 新規作成
''' </remarks>
Public Class frmResultDetail

#Region "----- メンバ変数 -----"

    ''' <summary>問別正誤画面</summary>
    Private WithEvents _FrmNext As frmTrueFalseList
    ''' <summary>正解リスト</summary>
    Private _AnswerList As Generic.Dictionary(Of Integer, String)
    ''' <summary>グループ関数</summary>
    Private cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    '
    Private Const CST_RESULTDETAIL_COL As String = "COL"
    Private Const CST_RESULTDETAIL_RANK As String = "RANK"

    ''' <summary>
    ''' 分野名ID
    ''' </summary>
    Private CST_CATEGORY1 As String = Common.CategoryMaster.categoryId.fieldCategoryId_A
    Private CST_CATEGORY2 As String = Common.CategoryMaster.categoryId.fieldCategoryId_B
    Private CST_CATEGORY3 As String = Common.CategoryMaster.categoryId.fieldCategoryId_C
    ''' <summary>
    ''' 大分類名ID
    ''' </summary>
    Private CST_LARGE_CATEGORY1_1 As String = Common.CategoryMaster.categoryId.largeCategoryId_A
    Private CST_LARGE_CATEGORY1_2 As String = Common.CategoryMaster.categoryId.largeCategoryId_B
    Private CST_LARGE_CATEGORY1_3 As String = Common.CategoryMaster.categoryId.largeCategoryId_C
    Private CST_LARGE_CATEGORY2_1 As String = Common.CategoryMaster.categoryId.largeCategoryId_D
    Private CST_LARGE_CATEGORY2_2 As String = Common.CategoryMaster.categoryId.largeCategoryId_E
    Private CST_LARGE_CATEGORY2_3 As String = Common.CategoryMaster.categoryId.largeCategoryId_F
    Private CST_LARGE_CATEGORY3_1 As String = Common.CategoryMaster.categoryId.largeCategoryId_G
    Private CST_LARGE_CATEGORY3_2 As String = Common.CategoryMaster.categoryId.largeCategoryId_H
    Private CST_LARGE_CATEGORY3_3 As String = Common.CategoryMaster.categoryId.largeCategoryId_I
#End Region

#Region "イベントハンドラ"

    ''' <summary>
    ''' 初期処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub frmResultDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            '初期処理
            init()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問別正誤を確認クリック
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnTrueFalse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrueFalse.Click
        Try
            logger.Start()
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            Dim GDataManager As GDataManager = GDataManager.GetInstance()
            Dim frmShow As frmTrueFalseList

            '問別解説画面を表示
            frmShow = New frmTrueFalseList
            frmShow.ShowDialog(Me)
            If dataBanker("LOGOUT") Then
                Close()
            Else
                Me.Visible = True
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 管理者メインメニューへ戻るクリック
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = "KG07"
            dataBanker("TOFORM") = "KG01"
            Me.Close()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 個人別受験結果一覧へ戻るクリック
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnResultForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResultForm.Click
        Try
            logger.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = "KG07"
            dataBanker("TOFORM") = "KG06"
            Me.Close()

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

        Me.lblBottomCode.Text = "KG07"
        Me.lblBottomName.Text = "個人詳細結果画面"
        Me.UserId = dataBanker.Item("USERID")
        Me.UserName = dataBanker.Item("USERNAME")

        lblField1.Text = CategoryMaster.GetCategoryName(CST_CATEGORY1)
        lblField2.Text = CategoryMaster.GetCategoryName(CST_CATEGORY2)
        lblField3.Text = CategoryMaster.GetCategoryName(CST_CATEGORY3)

        With grdResultList
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

            'ソート不可
            For Each Col As DataGridViewColumn In .Columns
                Col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next Col

            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .Rows.Add(10)
            .Rows(1).Cells(CATEGORY1.Index).Value = CategoryMaster.GetCategoryName(CST_CATEGORY1)   '"ストラテジ系"

            .Rows(0).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_1)   '"企業と法務"
            .Rows(0).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY1_1
            .Rows(1).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_2)   '"経営戦略"
            .Rows(1).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY1_2
            .Rows(2).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY1_3)   '"システム戦略"
            .Rows(2).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY1_3

            .Rows(4).Cells(CATEGORY1.Index).Value = CategoryMaster.GetCategoryName(CST_CATEGORY2)   '"マネジメント系"

            .Rows(3).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_1)   '"開発技術"
            .Rows(3).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY2_1
            .Rows(4).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_2)   '"プロジェクトマネジメント"
            .Rows(4).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY2_2
            .Rows(5).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY2_3)   '"サービスマネジメント"
            .Rows(5).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY2_3

            .Rows(7).Cells(CATEGORY1.Index).Value = CategoryMaster.GetCategoryName(CST_CATEGORY3)   '"テクノロジ系"

            .Rows(6).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_1)   '"基本理論"
            .Rows(6).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY3_1
            .Rows(7).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_2)   '"コンピュータシステム"
            .Rows(7).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY3_2
            .Rows(8).Cells(CATEGORY2.Index).Value = CategoryMaster.GetCategoryName(CST_LARGE_CATEGORY3_3)   '"技術要素"
            .Rows(8).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & CST_LARGE_CATEGORY3_3

            .Rows(9).Cells(0).Value = CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT
            .Rows(9).Cells(CATEGORYID.Index).Value = CST_RESULTDETAIL_COL & "0"

        End With

        '表示データ設定
        SetDispData()

        Owner.Hide()
    End Sub


    ''' <summary>
    ''' 表示データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDispData()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim Category1 As Array = {(CST_CATEGORY1),
                                  (CST_CATEGORY2),
                                  (CST_CATEGORY3)}

        Dim Rank As Array = {lblStrategyNo, lblManagementNo, lblTechnorogyNo, lblTotalpointsNo}
        Dim RankName As Array = {CST_RESULTDETAIL_COL & Category1(0),
                                 CST_RESULTDETAIL_COL & Category1(1),
                                 CST_RESULTDETAIL_COL & Category1(2),
                                 CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT}

        Dim SelectRow As New DataGridViewRow
        Dim SelectTestHeadRow() As DataRow

        Dim TmpHead As New DataTable
        Dim TestDetail As New DataTable
        Dim sumTest As New DataTable
        Dim sumTRows() As DataRow

        Dim Group As DataTable
        Dim SelectGroup() As DataRow

        Dim GUserId As String
        Dim MenuMode As Integer = 0
        Dim SelectTotal As Integer = dataBanker("SELECTTOTAL").ToString

        SelectRow = dataBanker("SELECTROW")
        SelectTestHeadRow = dataBanker("SELECTTESTHEADROW")
        Group = dataBanker("GROUPTABLE")
        GUserId = dataBanker("TOUSERID")

        SelectGroup = Group.Select("GROUPCODE = '" & dataBanker("GROUPCODE") & "'")

        lblMainUserId.Text = SelectRow.Cells("GUSERID").Value
        lblMainUserName.Text = SelectRow.Cells("GUSERNAME").Value

        lblSection1.Text = SelectRow.Cells("section1").Value
        lblSection2.Text = SelectRow.Cells("section2").Value
        lblCourse.Text = SelectGroup(0)("COURSE")   ' コース
        lblInning.Text = SelectRow.Cells("TestCount").Value
        lblTestDate.Text = SelectRow.Cells("TestDate").Value
        lblTestTime.Text = SelectRow.Cells("TestTime").Value & CST.CBT.eIPSTA.Common.Constant.CST_MINUTE

        '点数
        lblStrategy.Text = SelectRow.Cells("Strategy").Value & CST.CBT.eIPSTA.Common.Constant.CST_SCORE
        lblTechnorogy.Text = SelectRow.Cells("Technorogy").Value & CST.CBT.eIPSTA.Common.Constant.CST_SCORE
        lblManagement.Text = SelectRow.Cells("Management").Value & CST.CBT.eIPSTA.Common.Constant.CST_SCORE
        lblTotalpoints.Text = SelectRow.Cells("Totalpoints").Value & CST.CBT.eIPSTA.Common.Constant.CST_SCORE

        '平均点数
        lblAveStrategy.Text = dataBanker("AVESTRATEGY") & CST.CBT.eIPSTA.Common.Constant.CST_SCORE
        lblAveManagement.Text = dataBanker("AVEMANAGEMENT") & CST.CBT.eIPSTA.Common.Constant.CST_SCORE
        lblAveTechnorogy.Text = dataBanker("AVETECHNOROGY") & CST.CBT.eIPSTA.Common.Constant.CST_SCORE
        lblAveTotalpoints.Text = dataBanker("AVETOTAL") & CST.CBT.eIPSTA.Common.Constant.CST_SCORE

        lblPass.Text = SelectRow.Cells("Result").Value

        btnTrueFalse.Select()

        If dataBanker("SYSMODE") = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
            MenuMode = 1
        End If

        '個人試験結果_明細取得
        TmpHead = dataBanker("TestResultHeaderSum")
        TestDetail = GetTestResultDetailSumMergr(TmpHead, MenuMode, dataBanker("GROUPCODE"), dataBanker("WHERE"))
        dataBanker("TestDetail") = TestDetail
        dataBanker("TESTUSERID") = lblMainUserId.Text
        '分類別評価作成
        sumTest = ClassAssessment(TestDetail, dataBanker("WHERE"))

        Dim sumTRows2() As DataRow
        Dim tmpObj As Object
        Dim QuestionCount As Integer
        sumTRows = sumTest.Select("USERID = '" & lblMainUserId.Text & "' AND TESTCOUNT = '" & dataBanker("TESTCOUNT") & "'")
        '総合計
        sumTRows2 = sumTest.Select("USERID = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "' AND TESTCOUNT = '" & dataBanker("TESTCOUNT") & "'")
        If sumTRows.Length > 0 And sumTRows2.Length > 0 Then
            '総合評価
            For i As Integer = 0 To 3
                Rank(i).text = sumTRows(0)(RankName(i) & CST_RESULTDETAIL_RANK) & "位／" & SelectTotal & "人中"
            Next

            '分野別評価
            For Each GRow As DataGridViewRow In grdResultList.Rows
                For Each col As Object In sumTest.Columns
                    If GRow.Cells(CATEGORYID.Index).Value = col.ToString Then
                        GRow.Cells(2).Value = sumTRows2(0)(col.ToString) & CST.CBT.eIPSTA.Common.Constant.CST_QUESTION_UNIT
                        QuestionCount = sumTRows2(0)(col.ToString)
                        GRow.Cells(3).Value = sumTRows(0)(col.ToString) & CST.CBT.eIPSTA.Common.Constant.CST_QUESTION_UNIT
                        If 0 = CInt(CInt(sumTRows2(0)(col.ToString))) Or 0 = CInt(sumTRows(0)(col.ToString)) Then
                            GRow.Cells(4).Value = "0.0%"
                        Else
                            GRow.Cells(4).Value =
                                cGroup.ToRoundDown(CInt(sumTRows(0)(col.ToString)) /
                                                   CInt(sumTRows2(0)(col.ToString)), 3).ToString("0.0%")
                        End If
                        GRow.Cells(5).Value = sumTRows(0)(col.ToString & "RANK") & "/" & SelectTotal

                        '平均正解率(合計/人数/出題数）
                        tmpObj = sumTest.Compute("SUM(" & col.ToString & ")", "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "'")
                        If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                            GRow.Cells(6).Value =
                                cGroup.ToRoundDown(((CLng(tmpObj) / CInt(SelectTotal)) / QuestionCount), 3).ToString("0.0%")
                        Else
                            GRow.Cells(6).Value = "0.0%"
                        End If
                        '最高正解率(最高正回数/出題数)
                        tmpObj = sumTest.Compute("MAX(" & col.ToString & ")", "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "' AND USERID NOT = ''")
                        If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                            GRow.Cells(7).Value =
                                cGroup.ToRoundDown((CInt(tmpObj) / QuestionCount), 3).ToString("0.0%")
                        Else
                            GRow.Cells(7).Value = "0.0%"
                        End If
                        '最低正解率(最低正回数/出題数)
                        tmpObj = sumTest.Compute("MIN(" & col.ToString & ")", "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "' AND USERID NOT = ''")
                        If IsNumeric(tmpObj.ToString) And QuestionCount > 0 Then
                            GRow.Cells(8).Value = cGroup.ToRoundDown((CInt(tmpObj) / QuestionCount), 3).ToString("0.0%")
                        Else
                            GRow.Cells(8).Value = "0.0%"
                        End If

                    End If
                Next
            Next

            '総合
            '問題数
            grdResultList.Rows(9).Cells(2).Value = (sumTRows2(0)(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT)).ToString & CST.CBT.eIPSTA.Common.Constant.CST_QUESTION_UNIT
            QuestionCount = CInt(sumTRows2(0)(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT))
            '正解数
            grdResultList.Rows(9).Cells(3).Value = (sumTRows(0)(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT)).ToString & CST.CBT.eIPSTA.Common.Constant.CST_QUESTION_UNIT
            '正解率
            grdResultList.Rows(9).Cells(4).Value =
                cGroup.ToRoundDown(CInt(sumTRows(0)(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT)) /
                                    CInt(sumTRows2(0)(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT)), 3).ToString("0.0%")
            '順位
            grdResultList.Rows(9).Cells(5).Value = sumTRows(0)(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "RANK") & "/" & SelectTotal
            '平均正解率
            tmpObj = sumTest.Compute("SUM(" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & ")", "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "'")
            If IsNumeric(tmpObj.ToString) Then
                grdResultList.Rows(9).Cells(6).Value =
                    cGroup.ToRoundDown((CLng(tmpObj) / QuestionCount / SelectTotal), 3).ToString("0.0%")
            Else
                grdResultList.Rows(9).Cells(6).Value = "0.0%"
            End If
            '最高正解率
            tmpObj = sumTest.Compute("MAX(" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & ")", "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "'")
            If IsNumeric(tmpObj.ToString) Then
                grdResultList.Rows(9).Cells(7).Value =
                    cGroup.ToRoundDown((CInt(tmpObj) / QuestionCount), 3).ToString("0.0%")
            Else
                grdResultList.Rows(9).Cells(7).Value = "0.0%"
            End If
            '最低正解率
            tmpObj = sumTest.Compute("MIN(" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & ")", "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "'")
            If IsNumeric(tmpObj.ToString) Then
                grdResultList.Rows(9).Cells(8).Value =
                    cGroup.ToRoundDown((CInt(tmpObj) / QuestionCount), 3).ToString("0.0%")
            Else
                grdResultList.Rows(9).Cells(8).Value = "0.0%"
            End If
        End If

    End Sub

    ''' <summary>
    ''' 試験結果集計_明細取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTestResultDetailSumMergr(ByVal TmpHead As System.Data.DataTable, ByVal Mode As Integer, ByVal Group As String, ByVal Where As String) As System.Data.DataTable
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
        Dim TempPath As String = CST.CBT.eIPSTA.Common.Constant.GetTempPath

        Dim TestHead As New System.Data.DataTable
        Dim TestDetail As New System.Data.DataTable
        Dim ReturnTestDetail As New System.Data.DataTable

        '明細取得
        TestDetail = cGroup.GetTestResultDetailSum(Mode, Group)

        TestHead = TmpHead.Clone
        For Each row As DataRow In TmpHead.Select(Where & " AND TESTCOUNT > 0")
            TestHead.ImportRow(row)
        Next

        'マージ
        TestDetail = cGroup.TestHeadDetailMergr(TestDetail, TestHead)

        'Where = Where & " AND TESTCOUNT > '0'"

        '抽出
        ReturnTestDetail = TestDetail.Clone
        For Each row As DataRow In TestDetail.Select(Where)
            ReturnTestDetail.ImportRow(row)
        Next

        Return ReturnTestDetail
    End Function

    ''' <summary>
    ''' 分類別評価作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ClassAssessment(ByVal TestDetail As DataTable, ByVal Where As String) As DataTable
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        Dim TestHead As New DataTable
        Dim sumTest As New DataTable
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
        sumTest.Columns.Add(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT, GetType(Integer))
        For Each Cate As String In Category1
            sumTest.Columns.Add(CST_RESULTDETAIL_COL & Cate, GetType(Integer))
            sumTest.Columns.Add(CST_RESULTDETAIL_COL & Cate & CST_RESULTDETAIL_RANK, GetType(Integer))
        Next
        For Each Cate As String In Category2
            sumTest.Columns.Add(CST_RESULTDETAIL_COL & Cate, GetType(Integer))
            sumTest.Columns.Add(CST_RESULTDETAIL_COL & Cate & CST_RESULTDETAIL_RANK, GetType(Integer))
        Next
        sumTest.Columns.Add(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "RANK", GetType(Integer))

        '分類
        TestHead = dataBanker("TestResultHeaderSum")
        For Each TRow As DataRow In TestHead.Select(Where & "AND TESTCOUNT > '0'")
            'ユーザ+テスト回数選択
            sumTRows = sumTest.Select("USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "'")
            If sumTRows.Length = 0 Then
                sumTRow = sumTest.NewRow()
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
                sumTRows(0).Item(CST_RESULTDETAIL_COL & Cate) = TestDetail.Compute("COUNT(USERID)",
                "USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "' AND CATEGORY1 = '" & Cate.ToString & "' AND ERRATA = '1'")
            Next
            For Each Cate As String In Category2
                sumTRows(0).Item(CST_RESULTDETAIL_COL & Cate) = TestDetail.Compute("COUNT(USERID)",
                "USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "' AND CATEGORY2 = '" & Cate.ToString & "' AND ERRATA = '1'")
            Next
            sumTRows(0).Item(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT) =
                TestDetail.Compute("COUNT(USERID)", "USERID = '" & TRow("USERID") & "' AND TESTCOUNT = '" & TRow("TESTCOUNT") & "' AND ERRATA = '1'")
        Next

        '総合行作成
        For Idx As Integer = 1 To 2
            sumTRow = sumTest.NewRow()
            sumTRow.Item("USERID") = CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT
            sumTRow.Item("TESTCOUNT") = Idx.ToString
            For Each col As DataColumn In sumTest.Columns
                If col.ColumnName <> "USERID" And col.ColumnName <> "TESTCOUNT" Then
                    sumTRow.Item(col.ColumnName) = 0
                End If
            Next
            sumTest.Rows.Add(sumTRow)
            sumTRows = sumTest.Select("USERID = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "' AND TESTCOUNT = '" & Idx.ToString & "'")

            For Each Cate As String In Category1
                sumTRows(0).Item(CST_RESULTDETAIL_COL & Cate) =
                    TestDetail.Compute("COUNT(USERID)", "USERID = '" & lblMainUserId.Text & "' AND TESTCOUNT = '" & Idx.ToString & "' AND CATEGORY1 = '" & Cate.ToString & "'")
            Next
            For Each Cate As String In Category2
                sumTRows(0).Item(CST_RESULTDETAIL_COL & Cate) =
                    TestDetail.Compute("COUNT(USERID)", "USERID = '" & lblMainUserId.Text & "' AND TESTCOUNT = '" & Idx.ToString & "' AND CATEGORY2 = '" & Cate.ToString & "'")
            Next
            sumTRows(0).Item(CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT) =
                TestDetail.Compute("COUNT(USERID)", "USERID = '" & lblMainUserId.Text & "' AND TESTCOUNT = '" & Idx.ToString & "'")

            '順位設定
            Where = "USERID <> '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "'"
            For Each Cate As String In Category1
                '
                sumTest = cGroup.SetRank(sumTest, CST_RESULTDETAIL_COL & Cate, "DESC", Where)
            Next
            For Each Cate As String In Category2
                '
                sumTest = cGroup.SetRank(sumTest, CST_RESULTDETAIL_COL & Cate, "DESC", Where)
            Next
            sumTest = cGroup.SetRank(sumTest, CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT, "DESC", Where)
        Next Idx

        Return sumTest
    End Function


    ''' <summary>
    ''' 順位設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetRank(ByVal TmpTable As DataTable, ByVal Item As String, ByVal Sort As String) As Integer

        Dim RankView As New DataView

        Dim PreTotalPoints As Integer = 0
        Dim PreRankNo As Integer = 0
        Dim RankNo As Integer = 0

        RankView = New DataView(TmpTable)

        RankView.RowFilter = "USERID NOT = '" & CST.CBT.eIPSTA.Common.Constant.CST_TOTALASSESSMENT & "' AND TESTCOUNT > '0'"
        RankView.Sort = Item & " " & Sort

        For Each row As DataRowView In RankView
            If IsNumeric(row(Item)) Then
                RankNo += 1
                If PreTotalPoints <> CInt(row(Item)) Then
                    PreTotalPoints = CInt(row(Item))
                    row(Item & "RANK") = RankNo
                    PreRankNo = RankNo
                Else
                    row(Item & "RANK") = PreRankNo
                End If
            End If
        Next

        Return RankNo
    End Function

#End Region

End Class