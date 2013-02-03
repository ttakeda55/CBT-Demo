Imports System
Imports System.IO
Imports System.Deployment
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Imports CST.CBT
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.GroupManager.GroupClass

''' <summary>
''' 個人別受験結果一覧
''' </summary>
''' <remarks>
''' 2011/09/05 NAKAMURA 新規作成
''' </remarks>
Public Class frmResultList

#Region "----- 定数 -----"
    ''' <summary>受験日</summary>
    Private Const LIST_COLUMN_TESTDATE As Integer = 5
    ''' <summary>受験時間</summary>
    Private Const LIST_COLUMN_TESTTIME As Integer = 6
    ''' <summary>ストラテジ系</summary>
    Private Const LIST_COLUMN_CATEGORY_A As Integer = 7
    ''' <summary>マネジメント系</summary>
    Private Const LIST_COLUMN_CATEGORY_B As Integer = 8
    ''' <summary>テクノロジ系</summary>
    Private Const LIST_COLUMN_CATEGORY_C As Integer = 9
    ''' <summary>総合評価点</summary>
    Private Const LIST_COLUMN_TOTAL As Integer = 10
    ''' <summary>順位</summary>
    Private Const LIST_COLUMN_RANK As Integer = 11
    ''' <summary>合否</summary>
    Private Const LIST_COLUMN_RESULT As Integer = 12
    ''' <summary>データバンカー</summary>
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

    ''' <summary>
    ''' 分野名ID
    ''' </summary>
    Private CST_CATEGORY1 As String = Common.CategoryMaster.categoryId.fieldCategoryId_A
    Private CST_CATEGORY2 As String = Common.CategoryMaster.categoryId.fieldCategoryId_B
    Private CST_CATEGORY3 As String = Common.CategoryMaster.categoryId.fieldCategoryId_C

    ''' <summary>
    ''' 分野名
    ''' </summary>
    Private Const CST_FIELD1 As String = "Field1"
    Private Const CST_FIELD2 As String = "Field2"
    Private Const CST_FIELD3 As String = "Field3"
    Private Const CST_FIELDHEADER1 As String = "FieldHeader1"
    Private Const CST_FIELDHEADER2 As String = "FieldHeader2"
    Private Const CST_FIELDHEADER3 As String = "FieldHeader3"

#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "イベントハンドラ"

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmResultList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            dataBanker("RESULTLIST") = ""

            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' グリッドクリック
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub grdResultList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdResultList.CellContentClick
    '    Try
    '        logger.Start()

    '        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    '        Dim frmNext As New frmResultDetail

    '        'UserIdクリック時
    '        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
    '            If Not ShowResultDetail(e) Then
    '                Common.Message.MessageShow("I002")
    '                Exit Sub
    '            End If
    '        Else
    '            Exit Sub
    '        End If

    '        frmNext.ShowDialog(Me)
    '        If dataBanker.Item("TOFORM") = "KG06" And Not dataBanker("LOGOUT") Then
    '            Me.Show()
    '        Else
    '            Me.Close()
    '        End If
    '        frmNext.Dispose()
    '        logger.End()
    '    Catch ex As Exception
    '        logger.Error(ex)
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    ''' <summary>
    ''' グリッドソート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdResultList_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles grdResultList.SortCompare

        Dim SortOrder As SortOrder = sender.SortOrder
        If e.Column.Index = LIST_COLUMN_TESTDATE Then
            '受験日
            '指定されたセルの値を文字列として取得する
            Dim str1 As String
            If e.CellValue1 Is Nothing Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    str1 = "9999/99/99"
                Else
                    str1 = String.Empty
                End If
            Else
                str1 = e.CellValue1.ToString
            End If
            Dim str2 As String
            If e.CellValue2 Is Nothing Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    str2 = "9999/99/99"
                Else
                    str2 = String.Empty
                End If
            Else
                str2 = e.CellValue2.ToString
            End If
            '結果を代入
                e.SortResult = System.String.Compare(str1, str2)
                '処理したことを知らせる
            ElseIf e.Column.Index = LIST_COLUMN_TESTTIME Or
                e.Column.Index = LIST_COLUMN_CATEGORY_A Or
                e.Column.Index = LIST_COLUMN_CATEGORY_B Or
                e.Column.Index = LIST_COLUMN_CATEGORY_C Or
                e.Column.Index = LIST_COLUMN_TOTAL Then
                '受験時間、ストラテジ系、マネジメント系、テクノロジ系
                '指定されたセルの値を数値として取得する
                Dim int1 As Integer
            If Not IsNumeric(e.CellValue1) Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    int1 = Integer.MaxValue
                Else
                    int1 = -1
                End If
            Else
                int1 = CInt(e.CellValue1)
            End If
                Dim int2 As Integer
            If Not IsNumeric(e.CellValue2) Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    int2 = Integer.MaxValue
                Else
                    int2 = -1
                End If
            Else
                int2 = CInt(e.CellValue2)
            End If

            '結果を代入
            e.SortResult = int1 - int2
            '処理したことを知らせる
            ElseIf e.Column.Index = LIST_COLUMN_RANK Then
                '指定されたセルの値を分割し数値として取得する
                Dim int1 As Integer
            If e.CellValue1 Is Nothing Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    int1 = Integer.MaxValue
                Else
                    int1 = -1
                End If

            Else
                Dim Cell1 As String = e.CellValue1.substring(0, e.CellValue1.IndexOf("/"))
                int1 = CInt(Cell1)
            End If
                Dim int2 As Integer
            If e.CellValue2 Is Nothing Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    int2 = Integer.MaxValue
                Else
                    int2 = -1
                End If
            Else
                Dim Cell2 As String = e.CellValue2.substring(0, e.CellValue2.IndexOf("/"))
                int2 = CInt(Cell2)
            End If

                '結果を代入
                e.SortResult = int1 - int2
                '処理したことを知らせる

            ElseIf e.Column.Index = LIST_COLUMN_RESULT Then
                '受験日
                '指定されたセルの値を文字列として取得する
                Dim str1 As String
            If e.CellValue1 Is Nothing Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    str1 = "熙熙熙熙"
                Else
                    str1 = String.Empty
                End If
            Else
                str1 = e.CellValue1.ToString
            End If
                Dim str2 As String
            If e.CellValue2 Is Nothing Then
                If SortOrder.Equals(SortOrder.Ascending) Then
                    str2 = "熙熙熙熙"
                Else
                    str2 = String.Empty
                End If
            Else
                str2 = e.CellValue2.ToString
            End If

            '結果を代入
            e.SortResult = System.String.Compare(str1, str2)
            '処理したことを知らせる
        ElseIf e.Column.Index >= 6 And e.Column.Index <= 10 Then
            '指定されたセルの値を数値として取得する
            Dim int1 As Integer
            If Not IsNumeric(e.CellValue1) Then
                int1 = -1
            Else
                int1 = CInt(e.CellValue1)
            End If
            Dim int2 As Integer
            If Not IsNumeric(e.CellValue2) Then
                int2 = -1
            Else
                int2 = CInt(e.CellValue2)
            End If

            '結果を代入
            e.SortResult = int1 - int2
            '処理したことを知らせる
        Else
            '指定されたセルの値を文字列として取得する
            Dim str1 As String
            If e.CellValue1 Is Nothing Then
                str1 = String.Empty
            Else
                str1 = e.CellValue1.ToString
            End If
            Dim str2 As String
            If e.CellValue2 Is Nothing Then
                str2 = String.Empty
            Else
                str2 = e.CellValue2.ToString
            End If

            '結果を代入
            e.SortResult = System.String.Compare(str1, str2)
            '処理したことを知らせる

        End If
        e.Handled = True

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

            '項目チェック # パラメータ設定
            If ItemCheck() Then
                '再検索
                DataSearch()
                '抽出条件保存
                'SetSearchKey()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 帳票保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            logger.Start()

            Dim sfdExcel As New SaveFileDialog()

            sfdExcel.Filter = "Excel ファイル (*.xls)|*.xls"
            sfdExcel.FileName = "個人別受験結果一覧.xls"
            sfdExcel.FilterIndex = 2
            sfdExcel.RestoreDirectory = True

            If sfdExcel.ShowDialog() = DialogResult.OK Then
                Me.processMessageOutput = True
                btnSave.Enabled = False
                Me.Refresh()
                ' DoWorkイベント発生
                ''エクセル保存処理
                ExcelSave(sfdExcel.FileName)

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
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        Dim TestHead As New System.Data.DataTable
        Dim Student As New System.Data.DataTable

        Dim GroupTbl As New System.Data.DataTable
        Dim CourseTbl As New System.Data.DataTable

        Dim GroupCode As String
        Dim CourseName As String
        Dim MenuMode As Integer = 0
        Dim iPadding As Padding
        iPadding.All = 0

        Me.lblBottomCode.Text = "KG06"
        Me.lblBottomName.Text = "個人結果一覧画面"
        Me.UserId = "ID：" & dataBanker.Item("USERID")
        Me.UserName = "氏名：" & dataBanker.Item("USERNAME")

        lblField1.Text = CategoryMaster.GetCategoryName(CST_CATEGORY1)
        lblField2.Text = CategoryMaster.GetCategoryName(CST_CATEGORY2)
        lblField3.Text = CategoryMaster.GetCategoryName(CST_CATEGORY3)

        With grdResultList
            'ヘッダ名
            .Columns(6).HeaderText = "受験" & vbCrLf & "時間"
            iPadding.Left = 10
            .Columns(6).HeaderCell.Style.Padding = iPadding
            .Columns(6).HeaderCell.Style.WrapMode = DataGridViewTriState.True
            .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(11).HeaderText = "順位" & vbCrLf & "位/人"
            iPadding.Left = 12
            .Columns(11).HeaderCell.Style.Padding = iPadding
            .Columns(11).HeaderCell.Style.WrapMode = DataGridViewTriState.True
            .Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(12).HeaderText = "合否" & vbCrLf & "判定"

            .Columns(12).HeaderCell.Style.Padding = iPadding
            .Columns(12).HeaderCell.Style.WrapMode = DataGridViewTriState.True
            .Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(7).HeaderText = " " & CategoryMaster.GetCategoryName(CST_CATEGORY1) & " "
            .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(8).HeaderText = " " & CategoryMaster.GetCategoryName(CST_CATEGORY2) & " "
            .Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(9).HeaderText = " " & CategoryMaster.GetCategoryName(CST_CATEGORY3) & "  "
            .Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter

            'グリッド初期設定
            .ReadOnly = True
            .AllowUserToAddRows = False
            'grdResultListの行の高さをユーザーが変更できないようにする
            .AllowUserToResizeRows = False
            'grdResultListでセル、行、列が複数選択されないようにする
            .MultiSelect = False
            'セルを選択すると行全体が選択されるようにする
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '初期状態で背景が透けないように
            .CurrentCell = Nothing
            'grdResultListの列の幅をユーザーが変更できないようにする
            .AllowUserToResizeColumns = False
        End With

        'データ取得
        GroupTbl = dataBanker.Item("GROUPTABLE")
        GroupCode = dataBanker.Item("GROUPCODE")

        CourseTbl = dataBanker.Item("COURSETABLE")
        CourseName = dataBanker.Item("COURSE")

        '団体コンボ
        cmbGroup.DataSource = GroupTbl

        'コース
        'cmbCourse.DataSource = Common.Constant.CST_COURSE
        '受験回
        cmbInning.DataSource = Common.Constant.CST_TESTCOUNT_CMB
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

        'If dataBanker("SYSMODE") <> Common.Constant.CST_MENUMODE_SYSTEM Then
        '    cmbInning.Select()
        '    cmbCourse.Text = dataBanker("COURSE")
        '    'コントロール使用不可
        '    cmbGroup.Enabled = False
        '    cmbCourse.Enabled = False
        'Else
        cmbGroup.Select()
        MenuMode = 1
        'End If

        ''
        ''初期表示
        ''
        '保存ボタンコントロール
        btnSave.Enabled = False

        '得点
        txtStrategyStart.Text = ""
        txtStrategyEnd.Text = ""
        txtManagementStart.Text = ""
        txtManagementEnd.Text = ""
        txtTechnologyStart.Text = ""
        txtTechnologyEnd.Text = ""

        'グリッド初期表示
        grdResultList.Rows.Add(11)

        'データ取得
        '受講者データ
        Student = cGroup.GetStudent(MenuMode, GroupCode)
        If Student.Rows.Count = 0 Then
            '
            Common.Message.MessageShow("E021", {"受講者情報"})
            Me.Close()
            Exit Sub
        End If

        dataBanker("Student") = Student

        '表示用データ作成
        TestHead = TestHeadRankAdd(TestHead, Student)

        '格納
        dataBanker("TestResultHeaderSum") = TestHead

        '帳票用リソース保存
        ResourcesSave()

    End Sub

    ''' <summary>
    ''' 順位追加
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TestHeadRankAdd(ByVal TestHead As System.Data.DataTable, ByVal Student As System.Data.DataTable) As System.Data.DataTable
        Dim KeyUserId(1) As DataColumn
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        'ランク追加
        TestHead.Columns.Add("TOTALPOINTS" & "INT", GetType(Integer))
        TestHead.Columns.Add("TOTALPOINTS" & "RANK", GetType(Integer))
        TestHead.Columns.Add("TOTALPOINTS" & "INT" & "RANK", GetType(Integer))
        For Each row As DataRow In TestHead.Rows
            If IsNumeric(row("TOTALPOINTS")) Then
                row("TOTALPOINTS" & "INT") = CInt(row("TOTALPOINTS"))
            End If
        Next

        cGroup.SetRank(TestHead, "TOTALPOINTS" & "INT", "DESC", "")
        For Each row As DataRow In TestHead.Rows
            If IsNumeric(row("TOTALPOINTS" & "INT" & "RANK")) Then
                row("TOTALPOINTS" & "RANK") = CInt(row("TOTALPOINTS" & "INT" & "RANK"))
            End If
        Next

        ''主キー設定
        KeyUserId(0) = Student.Columns("USERID")
        KeyUserId(1) = Student.Columns("TESTCOUNT")
        Student.PrimaryKey = KeyUserId

        'マージ
        TestHead = cGroup.StudentTestHeadMergr(Student, TestHead)

        Return TestHead
    End Function

    ''' <summary>
    ''' 抽出条件、項目チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ItemCheck() As Boolean
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
    ''' <returns></returns>
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
            Where += "AND GROUPCODE = '" & Me.cmbGroup.SelectedValue & "' "

            'コース名
            If cmbCourse.SelectedItem.ToString <> "" Then
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
        If Me.cmbPass.SelectedItem = Common.Constant.CST_PASS_CMB(1) Then
            Where += "AND RESULT = '1' "
        ElseIf Me.cmbPass.SelectedItem = Common.Constant.CST_PASS_CMB(2) Then
            Where += "AND RESULT = '0' "
        End If
        'ストラテジ系
        If IsNumeric(txtStrategyStart.Text) Then
            Where += "AND CATEGORYPOINT1_A >= " & txtStrategyStart.Text & " "
        End If
        If IsNumeric(txtStrategyEnd.Text) Then
            Where += "AND CATEGORYPOINT1_A <= " & txtStrategyEnd.Text & " "
        End If
        'マネジメント系
        If IsNumeric(txtManagementStart.Text) Then
            Where += "AND CATEGORYPOINT1_B >= " & txtManagementStart.Text & " "
        End If
        If IsNumeric(txtManagementEnd.Text) Then
            Where += "AND CATEGORYPOINT1_B <= " & txtManagementEnd.Text & " "
        End If
        'テクノロジ系
        If IsNumeric(txtTechnologyStart.Text) Then
            Where += "AND CATEGORYPOINT1_C >= " & txtTechnologyStart.Text & " "
        End If
        If IsNumeric(txtTechnologyEnd.Text) Then
            Where += "AND CATEGORYPOINT1_C <= " & txtTechnologyEnd.Text & " "
        End If
        '総合
        If IsNumeric(txtTotalStart.Text) Then
            Where += "AND TOTALPOINTS >= " & txtTotalStart.Text & " "
        End If
        If IsNumeric(txtTotalEnd.Text) Then
            Where += "AND TOTALPOINTS <= " & txtTotalEnd.Text & " "
        End If
        Return Where
    End Function

    ''' <summary>
    ''' 再検索処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DataSearch()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance

        Dim TestHead As New System.Data.DataTable
        'Dim KeyUserId(0) As DataColumn
        Dim TmpTestHeadRow() As DataRow

        Dim Where As String
        Dim TmpGridRow As DataGridViewRow

        Dim Total As Integer
        Dim aveTestTime As Integer = 0
        Dim aveStrategy As Integer = 0
        Dim aveTechnorogy As Integer = 0
        Dim aveManagement As Integer = 0
        Dim aveTotal As Integer = 0
        Dim Mode As Integer = 0

        TestHead = dataBanker("TestResultHeaderSum")

        If dataBanker("SYSMODE") = Common.Constant.CST_MENUMODE_SYSTEM Then
            Mode = 1
        End If

        '#抽出条件設定
        Where = CreateWhere(Mode)

        '抽出
        TmpTestHeadRow = TestHead.Select(Where)
        If TmpTestHeadRow.Length = 0 Then
            'データなし
            Common.Message.MessageShow("I002")
            Exit Sub
        Else
            dataBanker("WHERE") = Where
            dataBanker("GROUPCODE") = cmbGroup.SelectedValue
            '総人数取得
            Total = TestHead.Compute("COUNT(USERID)", Where & "AND TESTCOUNT > 0")
        End If

        '順位設定
        TestHead = cGroup.SetRank(TestHead, "TOTALPOINTSINT", "DESC", Where & "AND TESTCOUNT > 0")
        For Each row As DataRow In TestHead.Rows
            If IsNumeric(row("TOTALPOINTS" & "INT" & "RANK")) Then
                row("TOTALPOINTS" & "RANK") = CInt(row("TOTALPOINTS" & "INT" & "RANK"))
            End If
        Next

        dataBanker("SELECTTOTAL") = Total

        'データ表示
        grdResultList.Rows.Clear()
        For Each RowWork As DataRow In TestHead.Select(Where)
            '
            '平均用合計
            'If IsNumeric(RowWork("TESTTIME").ToString) Then aveTestTime += CInt(RowWork("TESTTIME").ToString)
            If IsDate(RowWork("TESTTIME").ToString) Then aveTestTime += ((CDate(RowWork("TESTTIME").ToString).Hour * 60) + (CDate(RowWork("TESTTIME").ToString).Minute))
            If IsNumeric(RowWork("CATEGORYPOINT1_A").ToString) Then aveStrategy += CInt(RowWork("CATEGORYPOINT1_A").ToString)
            If IsNumeric(RowWork("CATEGORYPOINT1_B").ToString) Then aveManagement += CInt(RowWork("CATEGORYPOINT1_B").ToString)
            If IsNumeric(RowWork("CATEGORYPOINT1_C").ToString) Then aveTechnorogy += CInt(RowWork("CATEGORYPOINT1_C").ToString)
            If IsNumeric(RowWork("TOTALPOINTS").ToString) Then aveTotal += CInt(RowWork("TOTALPOINTS").ToString)

            '
            '明細表示
            grdResultList.Rows.Add()
            TmpGridRow = grdResultList.Rows(grdResultList.Rows.Count - 1)
            With TmpGridRow
                'ユーザID
                .Cells("GUSERID").Value = RowWork("USERID")

                '氏名
                .Cells("GUSERNAME").Value = RowWork("NAME")

                '区分１
                .Cells("section1").Value = RowWork("SECTION1")

                '区分２
                .Cells("section2").Value = RowWork("SECTION2")

                '受験回
                If IsNumeric(RowWork("TESTCOUNT")) Then
                    .Cells("TestCount").Value = Common.Constant.CST_TESTCOUNT(RowWork("TESTCOUNT"))
                    .Cells("TestCount").Tag = RowWork("TESTCOUNT")
                Else
                    .Cells("TestCount").Value = Common.Constant.CST_TESTCOUNT(0)
                    .Cells("TestCount").Tag = RowWork("TESTCOUNT") = "0"
                End If
                '受験日
                If IsDate(RowWork("TESTDATE")) Then
                    .Cells("TestDate").Value = RowWork("TESTDATE")
                End If
                '受験時間
                If IsDate(RowWork("TESTTIME")) Then
                    .Cells("TestTime").Value = ((CDate(RowWork("TESTTIME").ToString).Hour * 60) + (CDate(RowWork("TESTTIME").ToString).Minute))
                End If
                'ストラテジ系
                If IsNumeric(RowWork("CATEGORYPOINT1_A")) Then
                    .Cells("Strategy").Value = CInt(RowWork("CATEGORYPOINT1_A"))
                Else
                    .Cells("Strategy").Value = ""
                End If
                'マネジメント系
                If IsNumeric(RowWork("CATEGORYPOINT1_B")) Then
                    .Cells("Management").Value = CInt(RowWork("CATEGORYPOINT1_B"))
                Else
                    .Cells("Management").Value = ""
                End If
                'テクノロジ系
                If IsNumeric(RowWork("CATEGORYPOINT1_C")) Then
                    .Cells("Technorogy").Value = CInt(RowWork("CATEGORYPOINT1_C"))
                Else
                    .Cells("Technorogy").Value = ""
                End If
                '総合評価点
                If IsNumeric(RowWork("TOTALPOINTS")) Then
                    .Cells("Totalpoints").Value = CInt(RowWork("TOTALPOINTS"))
                Else
                    .Cells("Totalpoints").Value = ""
                End If
                '順位
                If IsNumeric(RowWork("TOTALPOINTSRANK")) Then
                    .Cells("Rank").Value = CStr(RowWork("TOTALPOINTSRANK")) & "/" & CStr(Total)
                End If
                '合否判定
                If IsNumeric(RowWork("RESULT")) Then
                    .Cells("Result").Value = Common.Constant.CST_CONSTRESULT(RowWork("RESULT"))
                End If
            End With
        Next

        '平均算出
        If Total > 0 Then
            aveTestTime = aveTestTime \ Total
            aveStrategy = aveStrategy \ Total
            aveTechnorogy = aveTechnorogy \ Total
            aveManagement = aveManagement \ Total
            aveTotal = aveTotal \ Total

            '平均表示
            lblTime.Text = aveTestTime & Common.Constant.CST_MINUTE
            lblStrategy.Text = aveStrategy & Common.Constant.CST_SCORE
            lblManagement.Text = aveManagement & Common.Constant.CST_SCORE
            lblTechnology.Text = aveTechnorogy & Common.Constant.CST_SCORE
            lblTotal.Text = aveTotal & Common.Constant.CST_SCORE
            lblTime.Tag = aveTestTime
            lblStrategy.Tag = aveStrategy
            lblManagement.Tag = aveManagement
            lblTechnology.Tag = aveTechnorogy
            lblTotal.Tag = aveTotal
            dataBanker("AVETESTTIME") = aveTestTime
            dataBanker("AVESTRATEGY") = aveStrategy
            dataBanker("AVEMANAGEMENT") = aveManagement
            dataBanker("AVETECHNOROGY") = aveTechnorogy
            dataBanker("AVETOTAL") = aveTotal
        Else
            '平均表示
            lblTime.Text = ""
            lblStrategy.Text = ""
            lblManagement.Text = ""
            lblTechnology.Text = ""
            lblTotal.Text = ""
            lblTime.Tag = ""
            lblStrategy.Tag = ""
            lblManagement.Tag = ""
            lblTechnology.Tag = ""
            lblTotal.Tag = ""
        End If

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
    ''' 個人詳細受験結果表示用データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ShowResultDetail(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) As Boolean
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

        Dim TestHead As System.Data.DataTable
        Dim SelectTesthead() As DataRow
        Dim SelectRow As New DataGridViewRow

        Dim Where As String

        '
        '呼び出し設定

        'グリッドクリック 不正データ対応
        SelectRow = grdResultList.Rows(e.RowIndex)
        If CInt(SelectRow.Cells("TESTCOUNT").Tag) <= 0 Then
            Return False
        ElseIf IsDBNull(SelectRow.Cells("GUSERNAME").Value) Then
            '受講者データ無い場合
            Return False
        ElseIf IsNumeric(SelectRow.Cells("TESTCOUNT").Tag) Then
            If CInt(SelectRow.Cells("TESTCOUNT").Tag) > 0 Then
                If IsNothing(SelectRow.Cells("Result").Value) Then
                    '試験データ無い場合
                    Return False
                End If
            End If
        Else
            '受講者データ無い場合
            Return False
        End If
        dataBanker("SELECTROW") = SelectRow

        '試験結果集計＿ヘッダ
        TestHead = dataBanker("TestResultHeaderSum")
        Where = "USERID = '" & SelectRow.Cells("GUSERID").Value & "'"
        If SelectRow.Cells("TestCount").Tag = "1" Then
            Where += "AND TESTCOUNT = '1'"
            dataBanker("TESTCOUNT") = "1"
        ElseIf SelectRow.Cells("TestCount").Tag = "2" Then
            Where += "AND TESTCOUNT = '2'"
            dataBanker("TESTCOUNT") = "2"
        End If
        '
        SelectTesthead = TestHead.Select(Where)
        dataBanker("SELECTTESTHEADROW") = SelectTesthead

        'ユーザID
        dataBanker("TOUSERID") = grdResultList.Rows(e.RowIndex).Cells("GUSERID").Value

        dataBanker("FROMFORM") = "KG07"
        dataBanker("TOFORM") = "KG01"

        Return True
    End Function

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
        My.Computer.FileSystem.WriteAllBytes(Common.Constant.GetTempPath & "..\Base_B.xls", My.Resources.ResultList, True)

    End Sub

    ''' <summary>
    ''' テンポラリ削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResourcesDel()
        '保存
        If File.Exists(Common.Constant.GetTempPath & "..\Base_B.xls") Then
            My.Computer.FileSystem.DeleteFile(Common.Constant.GetTempPath & "..\Base_B.xls")
        End If

    End Sub

    ''' <summary>
    ''' 個人詳細受験結果表示用データ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetExcelData(ByVal FileName As String)
        'Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim xlApps As Excel.Application = Nothing
        Dim xlBooks As Excel.Workbook = Nothing
        Dim xlSheets As Excel.Sheets = Nothing
        Dim xlSheet As Excel.Worksheet = Nothing

        Dim xlRange As Excel.Range
        Dim strDat(0, 0) As Object

        Dim xlLine(0, 34) As Object
        Dim xlSum(0, 10) As Object
        Dim iRow As Integer = 22
        Dim MaxPage As Integer

        Dim st As Integer = System.Environment.TickCount

        xlApps = New Excel.Application
        xlBooks = xlApps.Workbooks.Open(Common.Constant.GetTempPath & "..\Base_B.xls")

        xlSheets = xlBooks.Worksheets
        xlSheet = CType(xlSheets.Item(1), Excel.Worksheet)
        xlApps.Visible = False

        '分野名
        xlRange = xlSheet.Range(CST_FIELD1)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY1) & "："
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELDHEADER1)
        strDat(0, 0) = StrConv(CategoryMaster.GetCategoryName(CST_CATEGORY1).Replace("系", ""), VbStrConv.Narrow)
        xlRange.Value = strDat

        xlRange = xlSheet.Range(CST_FIELD2)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY2) & "："
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELDHEADER2)
        strDat(0, 0) = StrConv(CategoryMaster.GetCategoryName(CST_CATEGORY2).Replace("系", ""), VbStrConv.Narrow)
        xlRange.Value = strDat

        xlRange = xlSheet.Range(CST_FIELD3)
        strDat(0, 0) = CategoryMaster.GetCategoryName(CST_CATEGORY3) & "："
        xlRange.Value = strDat
        xlRange = xlSheet.Range(CST_FIELDHEADER3)
        strDat(0, 0) = StrConv(CategoryMaster.GetCategoryName(CST_CATEGORY3).Replace("系", ""), VbStrConv.Narrow)
        xlRange.Value = strDat

        '団体名
        xlRange = xlSheet.Range("Z6")
        strDat(0, 0) = dataBanker("cmbGroup").ToString
        xlRange.Value = strDat

        '抽出条件
        '団体名
        xlRange = xlSheet.Range("G11")
        strDat(0, 0) = dataBanker("cmbGroup").ToString
        xlRange.Value = strDat
        '試験名
        xlRange = xlSheet.Range("Q11")
        strDat(0, 0) = dataBanker("cmbCourse").ToString
        xlRange.Value = strDat
        '受験回
        xlRange = xlSheet.Range("X11")
        strDat(0, 0) = dataBanker("cmbInning").ToString
        xlRange.Value = strDat
        '区分１
        xlRange = xlSheet.Range("AE11")
        strDat(0, 0) = dataBanker("cmbSection1").ToString
        xlRange.Value = strDat
        '区分２
        xlRange = xlSheet.Range("AJ11")
        strDat(0, 0) = dataBanker("cmbSection2").ToString
        xlRange.Value = strDat
        '受験日
        xlRange = xlSheet.Range("G13")
        strDat(0, 0) = dataBanker("udtpStart").ToString & " ～　" & dataBanker("udtpEnd").ToString
        xlRange.Value = strDat
        '合否
        xlRange = xlSheet.Range("W13")
        strDat(0, 0) = dataBanker("cmbPass")
        xlRange.Value = strDat
        'ストラテジ系
        If dataBanker("txtStrategyStart").ToString <> "" Or
           dataBanker("txtStrategyEnd").ToString <> "" Then
            xlRange = xlSheet.Range("K15")
            strDat(0, 0) = dataBanker("txtStrategyStart").ToString & "点以上　～ " &
                          dataBanker("txtStrategyEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        'マネジネント系
        If dataBanker("txtManagementStart").ToString <> "" Or
           dataBanker("txtManagementEnd").ToString <> "" Then
            xlRange = xlSheet.Range("Z15")
            strDat(0, 0) = dataBanker("txtManagementStart").ToString & "点以上　～ " &
                          dataBanker("txtManagementEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        'テクノロジ系
        If dataBanker("txtTechnologyStart").ToString <> "" Or
           dataBanker("txtTechnologyEnd").ToString <> "" Then
            xlRange = xlSheet.Range("K17")
            strDat(0, 0) = dataBanker("txtTechnologyStart").ToString & "点以上　～ " &
                          dataBanker("txtTechnologyEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If
        '総合評価
        If dataBanker("txtTotalStart").ToString <> "" Or
           dataBanker("txtTotalEnd").ToString <> "" Then
            xlRange = xlSheet.Range("Z17")
            strDat(0, 0) = dataBanker("txtTotalStart").ToString & "点以上　～ " &
                          dataBanker("txtTotalEnd").ToString & "点以下"
            xlRange.Value = strDat
        End If

        MaxPage = ((grdResultList.Rows.Count - 1) \ 25) + 1
        If grdResultList.Rows.Count > 25 Then
            ''次頁準備
            For i As Integer = 0 To ((Me.grdResultList.Rows.Count - 1) \ 25) - 1
                Dim row As Integer
                xlSheet.Range("1:50").Copy()
                row = ((i + 1) * 50) + 1
                xlSheet.Range(row.ToString & ":" & row.ToString).Insert(XlInsertShiftDirection.xlShiftDown)
                xlSheet.Range("A" & row.ToString).PageBreak = XlPageBreak.xlPageBreakManual
            Next
        End If

        For i As Integer = 0 To grdResultList.Rows.Count - 1
            xlRange = xlSheet.Cells(i + iRow, 4).Resize(1, 35)
            xlRange.Borders.LineStyle = True
            xlLine(0, 0) = grdResultList.Rows(i).Cells("GUserId").Value
            xlLine(0, 4) = grdResultList.Rows(i).Cells("GUserName").Value
            xlLine(0, 10) = grdResultList.Rows(i).Cells("section1").Value
            xlLine(0, 12) = grdResultList.Rows(i).Cells("section2").Value
            xlLine(0, 14) = grdResultList.Rows(i).Cells("TestCount").Value
            xlLine(0, 17) = grdResultList.Rows(i).Cells("TestDate").Value
            If IsNumeric(grdResultList.Rows(i).Cells("TestTime").Value) Then
                xlLine(0, 21) = grdResultList.Rows(i).Cells("TestTime").Value & Common.Constant.CST_MINUTE
            Else
                xlLine(0, 21) = ""
            End If
            If IsNumeric(grdResultList.Rows(i).Cells("Strategy").Value) Then
                xlLine(0, 23) = grdResultList.Rows(i).Cells("Strategy").Value & Common.Constant.CST_SCORE
            Else
                xlLine(0, 23) = ""
            End If
            If IsNumeric(grdResultList.Rows(i).Cells("Management").Value) Then
                xlLine(0, 25) = grdResultList.Rows(i).Cells("Management").Value & Common.Constant.CST_SCORE
            Else
                xlLine(0, 25) = ""
            End If
            If IsNumeric(grdResultList.Rows(i).Cells("Technorogy").Value) Then
                xlLine(0, 27) = grdResultList.Rows(i).Cells("Technorogy").Value & Common.Constant.CST_SCORE
            Else
                xlLine(0, 27) = ""
            End If
            If IsNumeric(grdResultList.Rows(i).Cells("Totalpoints").Value) Then
                xlLine(0, 29) = grdResultList.Rows(i).Cells("Totalpoints").Value & Common.Constant.CST_SCORE
            Else
                xlLine(0, 29) = ""
            End If
            xlLine(0, 31) = "'" & grdResultList.Rows(i).Cells("Rank").Value
            xlLine(0, 33) = grdResultList.Rows(i).Cells("Result").Value
            xlRange.Value = xlLine
            If (((i + 1) Mod 25) = 0 And i > 1) Or (Me.grdResultList.Rows.Count - 1) = i Then
                '抽出者平均
                xlRange = xlSheet.Cells(i + iRow + 1, 21).Resize(1, 1)
                strDat(0, 0) = "抽出者平均"
                xlRange.Value = strDat
                xlRange = xlSheet.Cells(i + iRow + 1, 25).Resize(1, 10)
                xlRange.Borders.LineStyle = True
                If lblTime.Tag.ToString = String.Empty Then
                    xlSum(0, 0) = String.Empty
                Else
                    xlSum(0, 0) = lblTime.Tag.ToString & Common.Constant.CST_MINUTE
                End If
                If lblStrategy.Tag.ToString = String.Empty Then
                    xlSum(0, 2) = String.Empty
                Else
                    xlSum(0, 2) = lblStrategy.Tag.ToString & Common.Constant.CST_SCORE
                End If
                If lblManagement.Tag.ToString = String.Empty Then
                    xlSum(0, 4) = String.Empty
                Else
                    xlSum(0, 4) = lblManagement.Tag.ToString & Common.Constant.CST_SCORE
                End If
                If lblTechnology.Tag.ToString = String.Empty Then
                    xlSum(0, 6) = String.Empty
                Else
                    xlSum(0, 6) = lblTechnology.Tag.ToString & Common.Constant.CST_SCORE
                End If
                If lblTotal.Tag.ToString = String.Empty Then
                    xlSum(0, 8) = String.Empty
                Else
                    xlSum(0, 8) = lblTotal.Tag.ToString & Common.Constant.CST_SCORE
                End If

                xlRange.Value = xlSum
                ''ページ番号

                xlRange = xlSheet.Cells((((i \ 25) + 1) * 50 - 1), 38)
                strDat(0, 0) = "'" & ((i \ 25) + 1).ToString & "/" & MaxPage.ToString
                xlRange.Value = strDat

                '行
                iRow += 25
            End If
        Next

        xlRange = xlSheet.Range("A1")
        strDat(0, 0) = ""
        xlRange.Value = strDat

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