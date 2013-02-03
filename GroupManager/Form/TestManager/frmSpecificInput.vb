''' <summary>
''' 指定テスト作成
''' </summary>
''' <remarks>
''' 2012/04/16 NAKAMURA 新規作成
''' </remarks>
Public Class frmSpecificInput

#Region "メンバ変数"

    ''' <summary>グループコード</summary>
    Private GroupCode As String = String.Empty

    ''' <summary>選択数</summary>
    Private SelectCount As Integer = 0

    ''' <summary>総数</summary>
    Private TotalCount As Integer = 0

    ''' <summary>選択カテゴリー</summary>
    Private CategoryDisplayArray As Array = {"", "", ""}

    ''' <summary>演習問題一覧（）</summary>
    Private _PracticeQuestionDt As New DataTable

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
    Private Sub frmSpecificInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            'グループコード取得
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            GroupCode = dataBanker.Item("GROUPCODE")

            '検索条件を設定する
            setSeachCondition()

            'デザインを変更
            changeDesign()

            'グリッドデータ設定
            setGrid()

            setInit()

            Owner.Hide()

            'コンボイベントを追加
            AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            AddHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged
            AddHandler Me.cmbCategory3.SelectedIndexChanged, AddressOf Me.cmbCategory3_SelectedIndexChanged
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 抽出クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 演習問題一覧を読み込み、抽出条件に一致する問題のみ表示する。
    ''' 小問、中問を混在した状態で表示する。
    ''' ''' </remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()

            '検索する
            search()

            '全てのチェックを解除
            'ｃheckAllOff()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 全チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>全てのチェックを設定する</remarks>
    Private Sub btnCheckAllOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAllOn.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvPracticeQuestionList.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                dgvPracticeQuestionList(dgvPracticeQuestionList.Columns("CHECK").Index, i).Value = "1"
            Next
            dgvPracticeQuestionList.CommitEdit(DataGridViewDataErrorContexts.Commit)
            '選択数表示
            lblCount.Text = setCount()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbCount1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            logger.Start()

            '選択数表示
            lblCount.Text = setCount()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbCount2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            logger.Start()

            '選択数表示
            lblCount.Text = setCount()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbCount3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            logger.Start()

            '選択数表示
            lblCount.Text = setCount()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ラジオクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbCount4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            logger.Start()

            '選択数表示
            lblCount.Text = setCount()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 指定テスト登録クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' チェックした問題を引き継ぎ
    ''' 指定テスト登録登録確認に遷移し
    ''' </remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            logger.Start()
            '入力チェック
            If Not specificTestCheck() Then
                Exit Sub
            End If
            Dim specificShowList As New DataTable
            'チェックした演習問題を退避
            specificShowList = setSpecificShowList()

            '指定テスト登録確認を表示
            Dim frm As New frmSpecificShow(specificShowList, txtTestName.Text.Trim, CategoryDisplayArray, TotalCount)

            'モード設定
            frm.Mode = Common.Constant.SpecificShowMode.CreateManualTest

            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            ElseIf frm.DialogResult = DialogResult.Yes Then
                '検索条件を設定する
                setSeachCondition()
                'グリッドデータ設定
                setGrid()
                '項目初期化
                setInit()
                Show()
            Else
                Show()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 指定テスト管理メニューへ戻るクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSpecificTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackSpecificTop.Click
        Try
            logger.Start()

            If Common.Message.MessageShow("Q011") = DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

            logger.End()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題コードリンククリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>指定された問題コードを表示する</remarks>
    Private Sub dgvPracticeQuestionList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellContentClick
        Try
            logger.Start()
            If e.ColumnIndex = QUESTIONCODE.Index And e.RowIndex <> -1 Then
                Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection
                PraciticeQuestionInfoCollection = createPraciticeQuestionInfoCollection()
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(dgvPracticeQuestionList.CurrentRow.Index, PraciticeQuestionInfoCollection)
                frm.ShowDialog(Me)
                Me.Show()
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 大分類の親カテゴリでフィルター
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub cmbCategory1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            If Not cmbCategory1.SelectedItem Is Nothing Then

                Dim categorId1 As String = CType(cmbCategory1.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
                Dim dtCategory2 As DataTable = cmbCategory2.DataSource
                Dim dtCategory3 As DataTable = cmbCategory3.DataSource

                If categorId1 <> 0 Then
                    dtCategory2.DefaultView.RowFilter = "PARENTCATEGORYID = '" & categorId1 & "' OR CATEGORYID = '0'"

                    Dim categorId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
                    'If categorId2 <> 0 Then
                    '    dtCategory3.DefaultView.RowFilter = "PARENTCATEGORYID = '" & categorId2 & "' OR CATEGORYID = '0'"
                    'Else
                    '    Dim filter As String = "1=0"
                    '    For Each drv As DataRowView In cmbCategory2.Items
                    '        If drv(Common.CategoryMaster.ColumnIndex.CATEGORYID) <> 0 Then
                    '            filter &= " OR PARENTCATEGORYID = '" & drv(Common.CategoryMaster.ColumnIndex.CATEGORYID) & "' "
                    '        End If
                    '    Next
                    '    dtCategory3.DefaultView.RowFilter = filter & " OR CATEGORYID = '0'"
                    'End If
                Else
                    dtCategory2.DefaultView.RowFilter = "CATEGORYCLASS = '2'"
                    'dtCategory3.DefaultView.RowFilter = "CATEGORYCLASS = '3'"
                End If
                cmbCategory2.SelectedIndex = 0
                'cmbCategory3.SelectedIndex = 0
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 中分類の親カテゴリでフィルター
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbCategory2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'カテゴリーの読み込み
            Dim categorId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
            Dim parentCategoryId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
            Dim dtCategory1 As DataTable = cmbCategory1.DataSource
            Dim dtCategory3 As DataTable = cmbCategory3.DataSource
            'If categorId2 <> 0 Then
            '    RemoveHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            '    cmbCategory1.SelectedValue = parentCategoryId2
            '    AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            '    dtCategory3.DefaultView.RowFilter = "PARENTCATEGORYID = '" & categorId2 & "' OR CATEGORYID = '0'"
            'Else
            '    Dim filter As String = "1=0"
            '    For Each drv As DataRowView In cmbCategory2.Items
            '        If drv(Common.CategoryMaster.ColumnIndex.CATEGORYID) <> 0 Then
            '            filter &= " OR PARENTCATEGORYID = '" & drv(Common.CategoryMaster.ColumnIndex.CATEGORYID) & "' "
            '        End If
            '    Next
            '    dtCategory3.DefaultView.RowFilter = filter & " OR CATEGORYID = '0'"
            'End If
            'cmbCategory3.SelectedIndex = 0
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グループの親カテゴリでフィルター
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbCategory3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'カテゴリーの読み込み
        Dim categorId3 As String = CType(cmbCategory3.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
        Dim parentCategoryId3 As String = CType(cmbCategory3.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
        Dim dtCategory1 As DataTable = cmbCategory1.DataSource
        Dim dtCategory2 As DataTable = cmbCategory2.DataSource
        If categorId3 <> 0 Then
            RemoveHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged
            cmbCategory2.SelectedValue = parentCategoryId3
            AddHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged
            If Not IsNothing(cmbCategory2.SelectedItem) Then
                Dim parentCategorId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
                RemoveHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
                cmbCategory1.SelectedValue = parentCategorId2
                AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            End If
        End If
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
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グリッド編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPracticeQuestionList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPracticeQuestionList.CellFormatting
        Try
            If dgvPracticeQuestionList.Columns(e.ColumnIndex).Name = PRACTICECOUNT.Name Then
                e.Value = dgvPracticeQuestionList(e.ColumnIndex, e.RowIndex).Value & Common.Constant.CST_QUESTION_UNIT
                e.FormattingApplied = True
            ElseIf dgvPracticeQuestionList.Columns(e.ColumnIndex).Name = CORRECTANSWERRATE.Name Then
                e.Value = dgvPracticeQuestionList(e.ColumnIndex, e.RowIndex).Value & "%"
                e.FormattingApplied = True
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 選択編集
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>選択変更時、選択数を再表示する</remarks>
    Private Sub dgvPracticeQuestionList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellValueChanged
        Try
            logger.Start()
            '選択数表示
            If e.RowIndex <> -1 Then
                dgvPracticeQuestionList.CommitEdit(DataGridViewDataErrorContexts.Commit)
                lblCount.Text = setCount()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' セルの状態が変化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' チェックされた直後CellValueChangedイベントを走らす
    ''' </remarks>
    Private Sub dgvPracticeQuestionList_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPracticeQuestionList.CurrentCellDirtyStateChanged
        dgvPracticeQuestionList.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 検索クリック
    ''' </summary>
    ''' <remarks>
    ''' 問題一覧を読み込み
    ''' 検索条件でフィルターを掛ける
    ''' 同時にカテゴリーIDを取得
    ''' </remarks>
    Private Sub search()
        Dim dataView As New DataView
        Dim filter As String = "1=1"
        '検索条件でフィルター
        Dim dtPracitceQuestionList As DataTable = dgvPracticeQuestionList.DataSource

        If cmbQuestionType.SelectedValue <> 0 Then
            filter &= " AND QUESTIONTYPE = '" & cmbQuestionType.SelectedItem("CODE") & "'"
        End If
        'If cmbCategory3.SelectedValue <> 0 Then
        '    filter &= " AND CATEGORYID3 = '" & cmbCategory3.SelectedItem("CATEGORYID") & "'"
        'End If
        If cmbCategory2.SelectedValue <> 0 Then
            filter &= " AND CATEGORYID2 = '" & cmbCategory2.SelectedItem("CATEGORYID") & "'"
        End If
        If cmbCategory1.SelectedValue <> 0 Then
            filter &= " AND CATEGORYID1 = '" & cmbCategory1.SelectedItem("CATEGORYID") & "'"
        End If
        If Me.txtKeyWord.Text <> "" Then
            filter &= " AND THEME Like '*" & Me.txtKeyWord.Text & "*'"
        End If
        'チェックありは常に残す
        filter &= " OR CHECK = '1'"

        CategoryDisplayArray(0) = If(IsDBNull(cmbCategory1.SelectedItem("DISPLAYID")), "", cmbCategory1.SelectedItem("DISPLAYID"))
        CategoryDisplayArray(1) = If(IsDBNull(cmbCategory2.SelectedItem("DISPLAYID")), "", cmbCategory2.SelectedItem("DISPLAYID"))
        'CategoryDisplayArray(2) = If(IsDBNull(cmbCategory3.SelectedItem("DISPLAYID")), "", cmbCategory3.SelectedItem("DISPLAYID"))
        '小問を表示
        filter &= " AND QUESTIONCLASS = '1'"
        dtPracitceQuestionList.DefaultView.RowFilter = filter

        '選択チェック
        'selectCheck()
    End Sub

    ''' <summary>
    ''' 全てのチェックをオフ
    ''' </summary>
    ''' <remarks>全てのチェックをオフする</remarks>
    Private Sub ｃheckAllOff()
        Dim tmp = CType(dgvPracticeQuestionList.DataSource, DataTable)
        For Each row As DataRow In tmp.Rows
            row.Item(CHECK.Name) = "0"
        Next
        '再描画
        dgvPracticeQuestionList.Refresh()
        '選択数表示
        lblCount.Text = setCount()
    End Sub

    ''' <summary>
    ''' 検索条件を設定する
    ''' </summary>
    ''' <remarks>検索条件を設定する
    ''' 同時にカテゴリーIDを設定する
    ''' </remarks>
    Private Sub setSeachCondition()
        '問題タイプの設定
        setQuestionTypeDataSource()

        'カテゴリーの読み込み
        Dim dtCategory1 As DataTable = Common.CategoryMaster.GetAll
        cmbCategory1.DataSource = getCategoryComboboxDatasource(dtCategory1, "1")

        Dim dtCategory2 As DataTable = Common.CategoryMaster.GetAll
        cmbCategory2.DataSource = getCategoryComboboxDatasource(dtCategory2, "2")

        'Dim dtCategory3 As DataTable = Common.CategoryMaster.GetAll
        'cmbCategory3.DataSource = getCategoryComboboxDatasource(dtCategory3, "3")

        CategoryDisplayArray = {"", "", ""}
    End Sub

    ''' <summary>
    ''' 問題タイプのデータソースを設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setQuestionTypeDataSource()
        Dim DataSource As New DataTable("DataSource")
        DataSource.Columns.Add("Value", GetType(String))
        DataSource.Columns.Add("code", GetType(String))
        DataSource.Rows.Add(Common.Constant.CST_QUESTION_TYPE(0), "0")
        DataSource.Rows.Add(Common.Constant.CST_QUESTION_TYPE(1), "1")
        DataSource.Rows.Add(Common.Constant.CST_QUESTION_TYPE(2), "2")

        cmbQuestionType.DataSource = DataSource
        cmbQuestionType.ValueMember = "code"
        cmbQuestionType.DisplayMember = "Value"
    End Sub

    ''' <summary>
    ''' カテゴリのコンボ設定用データソースの取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Function getCategoryComboboxDatasource(ByVal dtCategory As DataTable, ByVal categoryClass As String) As DataTable
        dtCategory.DefaultView.RowFilter = "CATEGORYCLASS = '" & categoryClass & "'"
        dtCategory.DefaultView.Sort = "DISPLAYID ASC"
        Dim drCategory As DataRow = dtCategory.NewRow
        drCategory.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME) = "すべて"
        drCategory.Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID) = "0"
        drCategory.Item(Common.CategoryMaster.ColumnIndex.CATEGORYCLASS) = categoryClass
        drCategory.Item(Common.CategoryMaster.ColumnIndex.CATEGORYID) = "0"
        dtCategory.Rows.Add(drCategory)
        Return dtCategory
    End Function

    ''' <summary>
    ''' グリッドのデザインを変更する
    ''' </summary>
    ''' <remarks>分類のヘッダ文字を下に移動する</remarks>
    Private Sub changeDesign()

        '描画
        With dgvPracticeQuestionList
            '.Columns(CATEGORYNAME1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            '.Columns(CATEGORYNAME2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            ''ヘッダ微調整
            '.Columns(QUESTIONCODE.Name).HeaderCell.Value = Space(1) & .Columns(QUESTIONCODE.Name).HeaderCell.Value & Space(1)
            '.Columns(CATEGORYNAME1.Name).HeaderCell.Value = Space(5) & .Columns(CATEGORYNAME1.Name).HeaderCell.Value & Space(5)
            '.Columns(CATEGORYNAME2.Name).HeaderCell.Value = Space(11) & .Columns(CATEGORYNAME2.Name).HeaderCell.Value & Space(11)
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Value = Space(11) & .Columns(CATEGORYNAME3.Name).HeaderCell.Value & Space(11)
            '.Columns(THEME.Name).HeaderCell.Value = Space(11) & .Columns(THEME.Name).HeaderCell.Value & Space(11)
            '.Columns(CATEGORYNAME4.Name).HeaderCell.Value = Space(10) & .Columns(CATEGORYNAME4.Name).HeaderCell.Value & Space(10)

            .AutoGenerateColumns = False
        End With
    End Sub

    ''' <summary>
    ''' グリッドに問題群に登録されている演習問題一覧を設定する。
    ''' </summary>
    ''' <remarks>問題群に登録されている演習問題一覧を読み込みグリッドに設定する</remarks>
    Private Sub setGrid()
        '問題取得
        Dim dtPracticeQuestionList = setCollection()

        '問題タイプカラム追加
        addQuestionTypeColumns(dtPracticeQuestionList)
        'チェックカラム追加
        addCheckColumns(dtPracticeQuestionList)
        'カテゴリカラム追加
        addCategoryColumns(dtPracticeQuestionList)
        'カテゴリカラム設定
        setCategryList(dtPracticeQuestionList)
        '難易度カラムの追加
        setLevel(dtPracticeQuestionList)
        '小問を表示
        dgvPracticeQuestionList.DataSource = dtPracticeQuestionList
        '編集管理
        dtPracticeQuestionList.DefaultView.RowFilter = "QUESTIONCLASS = '1'"
        dtPracticeQuestionList.AcceptChanges()
    End Sub

    ''' <summary>
    ''' 難易度カラムの追加
    ''' </summary>
    ''' <param name="dtPracticeQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setLevel(ByRef dtPracticeQuestionList As DataTable)
        dtPracticeQuestionList.Columns.Add("LEVEL_STR", GetType(String), "IIF(LEVEL = '1','低',IIF(LEVEL = '2','中','高'))")
    End Sub

    ''' <summary>
    ''' 項目初期化
    ''' </summary>
    ''' <remarks>項目初期化</remarks>
    Private Sub setInit()
        'テスト名
        txtTestName.Text = String.Empty
        '選択数表示
        lblCount.Text = setCount()
    End Sub

    ''' <summary>
    ''' 問題群設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>問題群を取得し、問題群で演習問題を抽出する</remarks>
    Private Function setCollection() As DataTable
        Dim collectionDt = getCollection()
        ''問題取得
        Dim resultmaster As New Common.ResultMaster
        _PracticeQuestionDt = Common.ResultMaster.SumSerial

        Dim returnPracticeQuestionDt As New DataTable
        'Dim practiceQuestionRows() As DataRow

        '形式設定
        returnPracticeQuestionDt = _PracticeQuestionDt.Clone
        '問題群ループ

        Return _PracticeQuestionDt
    End Function

    ''' <summary>
    ''' 問題確認画面へ渡す演習問題情報を設定する。
    ''' </summary>
    ''' <returns>演習問題情報</returns>
    ''' <remarks></remarks>
    Private Function createPraciticeQuestionInfoCollection() As PracticeQuestionShow.PraciticeQuestionInfoCollection
        Dim praciticeQuestionInfoCollection = New PracticeQuestionShow.PraciticeQuestionInfoCollection
        Dim dtPracticeQuestionList As DataTable = dgvPracticeQuestionList.DataSource

        For Each dgvr As DataGridViewRow In dgvPracticeQuestionList.Rows
            Dim dr As DataRow = dgvr.DataBoundItem.Row
            Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
            praciticeQuestionInfo.QuestionCode = dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
            praciticeQuestionInfo.MiddleQuestionCode = dr(Common.PracticeQuestionList.ColumnIndex.MainCode)
            praciticeQuestionInfo.IsMiddleQuestion = IIf(dr(Common.PracticeQuestionList.ColumnIndex.QuestionClass) = "2", True, False)
            praciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
        Next
        Return praciticeQuestionInfoCollection
    End Function

    ''' <summary>
    ''' チェックカラム追加
    ''' </summary>
    ''' <param name="returnDt"></param>
    ''' <remarks></remarks>
    Private Sub addCheckColumns(ByRef returnDt As DataTable)
        'チェックカラム
        returnDt.Columns.Add("CHECK")
    End Sub

    ''' <summary>
    ''' カテゴリカラム追加
    ''' </summary>
    ''' <param name="returnDt"></param>
    ''' <remarks></remarks>
    Private Sub addCategoryColumns(ByRef returnDt As DataTable)
        '分野・グループID
        returnDt.Columns.Add("CATEGORYID1")
        returnDt.Columns.Add("CATEGORYID2")
        returnDt.Columns.Add("CATEGORYID3")
        '分野・グループ名
        returnDt.Columns.Add("CATEGORYNAME1")
        returnDt.Columns.Add("CATEGORYNAME2")
        returnDt.Columns.Add("CATEGORYNAME3")
        returnDt.Columns.Add("CATEGORYNAME4")
    End Sub

    ''' <summary>
    ''' 正解率、演習回数カラム追加
    ''' </summary>
    ''' <param name="returnDt"></param>
    ''' <remarks></remarks>
    Private Sub addResultColumns(ByRef returnDt As DataTable)
        'チェックカラム
        returnDt.Columns.Add("CORRECTANSWERRATE")
        'チェックカラム
        returnDt.Columns.Add("PRACTICECOUNT")
    End Sub

    ''' <summary>
    ''' カテゴリーリスト設定
    ''' </summary>
    ''' 小問のカテゴリーリストを取得する。
    ''' また選択数、全問題数を設定する。
    ''' <remarks></remarks>   
    Private Sub setCategryList(ByVal dtPracticeQuestionList As DataTable)
        Dim dtCategoryTable As New DataTable

        Dim category As New Common.CategoryMaster(2)
        dtCategoryTable = category.GetCategoryTable
        For Each drPracticeQuestionList As DataRow In dtPracticeQuestionList.Rows
            If drPracticeQuestionList(Common.PracticeQuestionList.ColumnIndex.CategoryId) <> "" Then
                Dim founrdDataRow As DataRow() = dtCategoryTable. _
                                                 Select("DISPLAYID = " & _
                                                        drPracticeQuestionList(Common.PracticeQuestionList.ColumnIndex.CategoryId))
                If founrdDataRow.Length > 0 Then
                    drPracticeQuestionList("CATEGORYNAME1") = founrdDataRow(0).Item("CATEGORYNAME1")
                    drPracticeQuestionList("CATEGORYNAME2") = founrdDataRow(0).Item("CATEGORYNAME2")
                    'drPracticeQuestionList("CATEGORYNAME3") = founrdDataRow(0).Item("CATEGORYNAME3")
                    'drPracticeQuestionList("CATEGORYNAME4") = founrdDataRow(0).Item("CATEGORYNAME")
                    drPracticeQuestionList("CATEGORYID1") = founrdDataRow(0).Item("CATEGORYID1")
                    drPracticeQuestionList("CATEGORYID2") = founrdDataRow(0).Item("CATEGORYID2")
                    'drPracticeQuestionList("CATEGORYID3") = founrdDataRow(0).Item("CATEGORYID3")
                Else
                    Debug.Print("founrdDataRow.Length")
                End If
            End If

        Next
    End Sub

    ''' <summary>
    ''' 指定テスト表示リスト設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 選択した演習問題群のリストを作成する
    ''' </remarks>
    Private Function setSpecificShowList() As DataTable
        Dim dgvPracticeQuestionListDt As New DataTable
        Dim selectPracticeQuestionListDt As New DataTable
        dgvPracticeQuestionListDt = CType(dgvPracticeQuestionList.DataSource, DataTable)
        'コミット
        dgvPracticeQuestionListDt.AcceptChanges()

        selectPracticeQuestionListDt = dgvPracticeQuestionListDt.Clone

        Dim showNoNum As New DataColumn
        showNoNum.ColumnName = "SHOWNONUM"
        showNoNum.DataType = GetType(Integer)
        selectPracticeQuestionListDt.Columns.Add(showNoNum)

        Dim drvDGV As DataRowView
        For iRowIndex As Integer = 0 To dgvPracticeQuestionList.RowCount - 1
            drvDGV = dgvPracticeQuestionList.Rows(iRowIndex).DataBoundItem
            If Not drvDGV.Item("CHECK") Is DBNull.Value AndAlso drvDGV.Item("CHECK") = "1" Then
                selectPracticeQuestionListDt.ImportRow(drvDGV.Row)
            End If
        Next

        Return selectPracticeQuestionListDt
    End Function

    ''' <summary>
    ''' 指定テストチェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>名称チェック及び件数のチェックを行う</remarks>
    Private Function specificTestCheck() As Boolean
        '名称チェック
        If txtTestName.Text.Trim = String.Empty Then
            Common.Message.MessageShow("E005", {"テスト名"})
            txtTestName.Focus()
            Return False
        End If
        ''期間開始
        'If mskTestStart_DateTime.MaskCompleted = False Then
        '    Common.Message.MessageShow("E042", {"試験開始日時"})
        '    txtTestName.Focus()
        '    Return False
        'End If
        ''期間終了
        'If mskTestEnd_DateTime.MaskCompleted = False Then
        '    Common.Message.MessageShow("E042", {"試験終了日時"})
        '    txtTestName.Focus()
        '    Return False
        'End If

        ''件数
        If SelectCount = 0 Then
            Common.Message.MessageShow("E011")
            txtTestName.Focus()
            Return False
        End If
        'ファイル名で使用禁止文字チェック
        Dim ngChars As String = (Common.Constant.CST_FILENAMECHARS_NG & "'").Replace("\", "\\")
        If Utility.IsNgChar(txtTestName.Text, ngChars) Then
            Dim chars As String = Common.Constant.CST_FILENAMECHARS_NG & "'"
            Dim str As String = ""
            For Each chr As Char In chars
                str &= "[" & chr.ToString & "]"
            Next
            Common.Message.MessageShow("E063", {"テスト名", str, ""})
            Return False
        End If
        '重複チェック
        If Not redundantCheckSpecificTestName(txtTestName.Text.Trim) Then
            Common.Message.MessageShow("E052", {"テスト名", "(" & txtTestName.Text.Trim & ")"})
            txtTestName.Focus()
            Return False
        End If

        ''試験日時の大小チェック
        'If CDate(mskTestStart_DateTime.Text) > CDate(mskTestEnd_DateTime.Text) Then
        '    Common.Message.MessageShow("E082")
        '    txtTestName.Focus()
        '    Return False
        'End If

        ''試験期間重複チェック
        'If Not GroupClass.GetInstance.checkTestRange(mskTestStart_DateTime.Text, mskTestEnd_DateTime.Text) Then
        '    Common.Message.MessageShow("E052", {"試験期間", ""})
        '    Return False
        'End If
        Return True
    End Function

    ''' <summary>
    ''' 指定テスト名重複チェック
    ''' </summary>
    ''' <param name="testName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 全ての指定テストヘッダーを取得し
    ''' 同一テスト名の件数を取得し、０件
    ''' 以上の場合、エラーとする
    ''' </remarks>
    Private Function redundantCheckSpecificTestName(ByVal testName As String) As Boolean
        redundantCheckSpecificTestName = True
        Dim specificHeaderDt As New DataTable
        specificHeaderDt = getSpecificHeaderAll()
        If specificHeaderDt.Rows.Count < 1 Then
            Return True
        End If
        If specificHeaderDt.Rows.Count <= 0 Then
            Return True
        End If
        If specificHeaderDt.Compute("COUNT(TESTNO)", "TESTNAME = '" & testName & "'") > 0 Then
            Return False
        End If

    End Function

    ''' <summary>
    ''' 全指定テストヘッダー取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>全ての指定テストヘッダーを取得し</remarks>
    Private Function getSpecificHeaderAll() As DataTable
        getSpecificHeaderAll = Nothing

        Dim filterName As String = Common.Constant.CST_SYNTHESISHEADER_FILENAME & Common.Constant.CST_GROUPNAME & Common.Constant.CST_EXTENSION_XML
        Dim specificHeaderDt As New DataTable
        Common.XmlSchema.GetSynthesisHeaderSchema(specificHeaderDt)

        For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath, filterName)
            specificHeaderDt.Merge(Common.Serialize.XmlToDataTableFullPath(fileName))
        Next
        Return specificHeaderDt
    End Function

    ''' <summary>
    ''' 件数取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>選択した問題数を表示する</remarks>
    Private Function setCount() As String
        '選択数
        SelectCount = 0
        For Each viewRow As System.Windows.Forms.DataGridViewRow In dgvPracticeQuestionList.Rows
            If Not IsDBNull(viewRow.Cells(CHECK.Name).Value) AndAlso viewRow.Cells(CHECK.Name).Value = "1" Then
                SelectCount += 1
            End If
        Next

        'Return SelectCount.ToString & "問／" & TotalCount.ToString & "問"
        Return SelectCount.ToString & "問"
    End Function

    ''' <summary>
    ''' 問題群取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>問題群のファイルを読み込む</remarks>
    Private Function getCollection() As DataTable
        getCollection = Nothing
        Dim CollectionName As String = Common.Constant.CST_COLLECTION_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML
        For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, CollectionName)
            Return Common.Collection.GetAll(IO.Path.GetFileName(fileName))
        Next
    End Function

    ''' <summary>
    ''' 選択チェック
    ''' </summary>
    ''' <remarks>
    ''' 抽出時エラーメッセージ
    ''' 抽出した問題が総問題数を下回る場合
    ''' エラーメッセージを表示する
    ''' </remarks>
    Private Sub selectCheck()
        If dgvPracticeQuestionList.Rows.Count < TotalCount Then
            Common.Message.MessageShow("E067", {dgvPracticeQuestionList.Rows.Count.ToString})
        End If
    End Sub

    ''' <summary>
    ''' 演習回数、正解率設定
    ''' </summary>
    ''' <param name="drPracticeQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setResultColumns(ByRef drPracticeQuestionList As DataTable)
        Dim ResultDt As New DataTable
        Dim resultmaster As New Common.ResultMaster
        ResultDt = Common.ResultMaster.SumSerial
        'drPracticeQuestionList.AcceptChanges()
        'drPracticeQuestionList.Merge(ResultDt)
        Dim dsPracticeQuestionList As New DataSet
        drPracticeQuestionList.TableName = "drPracticeQuestionList"
        dsPracticeQuestionList.Tables.Add(drPracticeQuestionList)
        dsPracticeQuestionList.Tables.Add(ResultDt.Copy)
        '演習問題リレーション
        Dim relation As DataRelation = New DataRelation("PracticeQuestionR",
                                                         dsPracticeQuestionList.Tables("PracticeQuestionList").Columns("QUESTIONCODE"),
                                                         dsPracticeQuestionList.Tables("drPracticeQuestionList").Columns("QUESTIONCODE"), False)
    End Sub

    ''' <summary>
    ''' 全チェック解除処理
    ''' </summary>
    Private Sub btnAllCheckCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllCheckCancel.Click
        Try
            logger.Start()
            Dim dtPracticeQuestionList As DataTable = dgvPracticeQuestionList.DataSource
            For Each dr As DataRow In dtPracticeQuestionList.Rows
                dr.Item("CHECK") = "0"
            Next
            Refresh()
            '選択数表示
            lblCount.Text = setCount()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub addQuestionTypeColumns(ByRef dtPracticeQuestionList As DataTable)
        'チェックカラム
        Dim expression As String = "IIF(" & QUESTIONTYPE.Name & " = 0,'" &
                                           Common.Constant.CST_QUESTION_TYPE(0) &
                                           "',IIF(" & QUESTIONTYPE.Name & " = 1,'" &
                                           Common.Constant.CST_QUESTION_TYPE(1) & "','" &
                                           Common.Constant.CST_QUESTION_TYPE(2) & "'))"
        dtPracticeQuestionList.Columns.Add(QUESTIONTYPE.DataPropertyName, GetType(String), expression)
    End Sub
#End Region
End Class