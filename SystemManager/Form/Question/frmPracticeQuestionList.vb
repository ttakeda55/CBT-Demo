''' <summary>
''' 演習問題一覧
''' </summary>
''' <remarks>演習問題を一覧表示する</remarks>
Public Class frmPracticeQuestionList

#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmPracticeQuestionList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            'デザインを変更
            changeDesign()

            processMessage = True
            '検索条件を設定する
            setSeachCondition()

            'グリッドデータ設定
            setGrid()

            Owner.Hide()

            'コンボイベントを追加
            AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            AddHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged
            'AddHandler Me.cmbCategory3.SelectedIndexChanged, AddressOf Me.cmbCategory3_SelectedIndexChanged
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessage = False
        End Try
    End Sub

    ''' <summary>
    ''' 問題確認メニューに戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackQuestionManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()
            Me.DialogResult = DialogResult.OK
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題確認画面表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 「問題コード」のリンクをクリックし、
    ''' 問題確認画面の小問又は中問を表示する。
    ''' </remarks>
    Private Sub dgvPracticeQuestionList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellContentClick
        Try
            logger.Start()
            If e.RowIndex <> -1 Then
                If e.ColumnIndex = QUESTIONCODE.Index Then
                    Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection
                    PraciticeQuestionInfoCollection = createPraciticeQuestionInfoCollection()
                    Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(dgvPracticeQuestionList.CurrentRow.Index, PraciticeQuestionInfoCollection)
                    frm.ShowDialog(Me)
                    Me.Show()
                End If

                If e.ColumnIndex = MOVIE_ADD.Index Then
                    Dim importFileName = fileImport()
                    If importFileName <> "" Then
                        Dim code As String = dgvPracticeQuestionList.CurrentRow.Cells(QUESTIONCODE.Index).Value
                        Dim practiceQuestionCollection As Common.VetnurseQuestionBankCollection = Common.Serialize.BinaryFileToObject(Common.Constant.CST_PRACTICEQUESTION_FILENAME & code)
                        practiceQuestionCollection.Item(0).ReadMovie(importFileName)
                        Common.Serialize.ObjectToBinaryFile(practiceQuestionCollection, Common.Constant.CST_PRACTICEQUESTION_FILENAME & code)
                    End If
                End If
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    ''' <summary>
    ''' 参照ボタンクリック
    ''' </summary>
    ''' <remarks></remarks>
    Private Function fileImport() As String
        fileImport = ""
        Try
            'OpenFileDialogクラスのインスタンスを作成
            Dim ofd As New OpenFileDialog()

            'ofd.Filter = "WindowsMediaPlayerファイル(*.wmv)|*.wmv"
            ofd.FilterIndex = 1
            ofd.Title = "開くファイルを選択してください"
            ofd.RestoreDirectory = True
            ofd.CheckFileExists = True
            ofd.CheckPathExists = True

            'ダイアログを表示する
            If ofd.ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき
                '選択されたファイル名を表示する
                Return ofd.FileName.ToString
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Function
    ''' <summary>
    ''' 状態を更新する
    ''' </summary>
    ''' <remarks>「状態」プルダウンメニューの内容で更新する</remarks>
    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            logger.Start()
            '問題一覧更新
            '更新確認
            If dgvPracticeQuestionList.Rows.Count > 0 Then
                If Common.Message.MessageShow("Q007") = DialogResult.Cancel Then Exit Sub

                Dim dtQuestionList As DataTable = dgvPracticeQuestionList.DataSource

                '更新日付の更新
                For Each dr As DataRow In dtQuestionList.Rows
                    If dr.RowState = DataRowState.Modified Then
                        dr(Common.PracticeQuestionList.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
                        '中問の削除を連動させる
                        If dr(Common.PracticeQuestionList.ColumnIndex.MainCode) <> "" Then
                            Dim drMiddles As DataRow() = dtQuestionList.Select("MAINCODE = '" & dr(Common.PracticeQuestionList.ColumnIndex.MainCode) & "'")
                            For Each drMiddle As DataRow In drMiddles
                                drMiddle(Common.PracticeQuestionList.ColumnIndex.State) = dr(Common.PracticeQuestionList.ColumnIndex.State)
                                drMiddle.AcceptChanges()
                            Next
                        End If
                    End If
                Next

                Dim dtWriteQuestionList As DataTable = DirectCast(dgvPracticeQuestionList.DataSource, DataTable).Copy

                'カラム削除
                delColumns(dtWriteQuestionList)

                '模擬テスト一覧更新
                Common.PracticeQuestionList.WriteXML(dtWriteQuestionList, Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)

                'ファイル更新
                If Not Common.DataManager.GetInstance.UpLoadFile Then Exit Sub

                Common.Message.MessageShow("I004")
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' 演習問題一覧を抽出する
    ''' </summary>
    ''' <remarks>
    ''' 演習問題一覧を読み込み、抽出条件に一致する問題のみ表示する。
    ''' 小問、中問を混在した状態で表示する。
    ''' 状態には、（空白）と削除を表示する。
    ''' </remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()
            '検索する
            search()
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
    ''' <remarks></remarks>

    Private Sub cmbCategory1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            If Not cmbCategory1.SelectedItem Is Nothing Then

                Dim categorId1 As String = CType(cmbCategory1.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
                Dim dtCategory2 As DataTable = cmbCategory2.DataSource
                'Dim dtCategory3 As DataTable = cmbCategory3.DataSource

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
    ''' 
    Private Sub cmbCategory2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            'カテゴリーの読み込み
            Dim categorId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
            Dim parentCategoryId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
            Dim dtCategory1 As DataTable = cmbCategory1.DataSource
            'Dim dtCategory3 As DataTable = cmbCategory3.DataSource
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
    ''' 中分類の親カテゴリでフィルター
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
            Dim parentCategorId2 As String = CType(cmbCategory2.SelectedItem.row, DataRow).Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
            RemoveHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            cmbCategory1.SelectedValue = parentCategorId2
            AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
        End If
    End Sub

    ''' <summary>
    ''' コンボボックスを一回のクリックで選択開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvQuestionList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellEnter
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)

            If (dgv.Columns(e.ColumnIndex).Name = Me.QUESTIONTYPE.Name) AndAlso _
                TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                SendKeys.Send("{F4}")
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' 検索条件を設定する
    ''' </summary>
    Private Sub setSeachCondition()
        'カテゴリーの読み込み
        Dim dtCategory1 As DataTable = Common.CategoryMaster.GetAll
        cmbCategory1.DataSource = getCategoryComboboxDatasource(dtCategory1, "1")

        Dim dtCategory2 As DataTable = Common.CategoryMaster.GetAll
        cmbCategory2.DataSource = getCategoryComboboxDatasource(dtCategory2, "2")

        'Dim dtCategory3 As DataTable = Common.CategoryMaster.GetAll
        'cmbCategory3.DataSource = getCategoryComboboxDatasource(dtCategory3, "3")
    End Sub

    ''' <summary>
    ''' 検索する
    ''' </summary>
    ''' <remarks>
    ''' 問題一覧を読み込み
    ''' 検索条件でフィルターを掛ける
    ''' </remarks>
    Private Sub search()
        Dim filter As String = "1=1"
        '検索条件でフィルター
        Dim dtPracitceQuestionList As DataTable = dgvPracticeQuestionList.DataSource
        'If cmbCategory3.SelectedValue <> 0 Then
        '    filter &= " AND CATEGORYID3 = '" & cmbCategory3.SelectedValue & "'"
        'Else
        If cmbCategory2.SelectedValue <> 0 Then
            filter &= " AND CATEGORYID2 = '" & cmbCategory2.SelectedValue & "'"
        Else
            If cmbCategory1.SelectedValue <> 0 Then
                filter &= " AND CATEGORYID1 = '" & cmbCategory1.SelectedValue & "'"
            End If
        End If
        'End If
        'キーワード
        If Me.txtKeyWord.Text <> "" Then
            filter &= " AND THEME Like '*" & Me.txtKeyWord.Text & "*'"
        End If

        txtQuestionCode.Text = StrConv(txtQuestionCode.Text.ToUpper, VbStrConv.Narrow)

        If txtQuestionCode.Text <> String.Empty Then
            If rdbExactMatch.Checked Then
                filter &= " AND QUESTIONCODE = '" & txtQuestionCode.Text & "'"
            Else
                filter &= " AND QUESTIONCODE LIKE '" & txtQuestionCode.Text.Replace("%", "[%]").Replace("_", "[_]").Replace("*", "[*]") & "%'"
            End If
        End If
        '中問主文を除く
        filter &= " AND QUESTIONCODE <> MAINCODE"

        dtPracitceQuestionList.DefaultView.RowFilter = filter
    End Sub

    ''' <summary>
    ''' グリッドのデザインを変更する
    ''' </summary>
    ''' <remarks>分類のヘッダ文字を下に移動する</remarks>
    Private Sub changeDesign()
        '描画
        'dgvPracticeQuestionList.Columns(CATEGORYNAME1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        'dgvPracticeQuestionList.Columns(CATEGORYNAME2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        'dgvPracticeQuestionList.Columns(CATEGORYNAME3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter

        dgvPracticeQuestionList.AutoGenerateColumns = False

        rdbExactMatch.Checked = True
        Show()
        Refresh()
    End Sub

    ''' <summary>
    ''' グリッドに演習問題一覧を設定する。
    ''' </summary>
    ''' <remarks>演習問題一覧を読み込みグリッドに設定する</remarks>
    Private Sub setGrid()
        '問題を抽出
        Dim drPracticeQuestionList = Common.PracticeQuestionList.GetAll(Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME _
                                                                        & Common.Constant.CST_EXTENSION_XML)
        'カテゴリカラム追加
        addCategoryColumns(drPracticeQuestionList)
        'カテゴリカラム設定
        setCategryList(drPracticeQuestionList)
        '状態設定
        setStateDataSource(drPracticeQuestionList)
        'カテゴリカラム設定
        setLevel(drPracticeQuestionList)
        '利用者数設定
        'setStudentCount(drPracticeQuestionList)
        '中問主文を除く
        drPracticeQuestionList.DefaultView.RowFilter = "QUESTIONCODE <> MAINCODE"
        'ソート
        drPracticeQuestionList.DefaultView.Sort = "QUESTIONCODE"
        dgvPracticeQuestionList.DataSource = drPracticeQuestionList
        '更新日付設定
        formatUpdateDate()
        drPracticeQuestionList.AcceptChanges()
    End Sub

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
    ''' カテゴリーリスト設定
    ''' </summary>
    ''' <returns></returns>
    ''' 小問のカテゴリーリストを取得する。
    ''' また選択数、全問題数を設定する。
    ''' <remarks></remarks>
    Private Function setCategryList(ByRef dtPracticeQuestionList As DataTable)
        setCategryList = Nothing
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
                End If
            End If

        Next
    End Function

    ''' <summary>
    ''' カテゴリカラム追加
    ''' </summary>
    ''' <param name="returnDt"></param>
    ''' <remarks></remarks>
    Private Sub addCategoryColumns(ByRef returnDt As DataTable)
        '分野・グループID
        returnDt.Columns.Add("CATEGORYID1")
        returnDt.Columns.Add("CATEGORYID2")
        'returnDt.Columns.Add("CATEGORYID3")
        '分野・グループ名
        returnDt.Columns.Add("CATEGORYNAME1")
        returnDt.Columns.Add("CATEGORYNAME2")
        'returnDt.Columns.Add("CATEGORYNAME3")
        'returnDt.Columns.Add("CATEGORYNAME4")
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
    ''' 表示表更新日付列を追加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub formatUpdateDate()
        Dim dtQuestion As DataTable = dgvPracticeQuestionList.DataSource
        dtQuestion.Columns.Add("UPDATE_DATE_DISPLAY")

        For Each dr As DataRow In dtQuestion.Rows
            dr("UPDATE_DATE_DISPLAY") = CDate(dr(Common.PracticeQuestionList.ColumnIndex.UpdateDate)).ToShortDateString
        Next
    End Sub

    ''' <summary>
    ''' 状態のデータソースを設定する
    ''' </summary>
    ''' <param name="dtQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setStateDataSource(ByVal dtQuestionList As DataTable)
        Dim colState As DataColumn = dtQuestionList.Columns("STATE")

        Dim DataSource As New DataTable("DataSource")
        DataSource.Columns.Add("Value", GetType(String))
        DataSource.Columns.Add("code", GetType(String))
        DataSource.Rows.Add(Common.Constant.CST_QUESTION_TYPE(0), "0")
        DataSource.Rows.Add(Common.Constant.CST_QUESTION_TYPE(1), "1")
        DataSource.Rows.Add(Common.Constant.CST_QUESTION_TYPE(2), "2")

        Dim column As New DataGridViewComboBoxColumn()
        column = CType(dgvPracticeQuestionList.Columns(QUESTIONTYPE.Index), DataGridViewComboBoxColumn)
        column.DataSource = DataSource
        column.ValueMember = "code"
        column.DisplayMember = "Value"
    End Sub

    ''' <summary>
    ''' カラムを削除する
    ''' </summary>
    ''' <param name="dtQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub delColumns(ByVal dtQuestionList As DataTable)
        '更新日
        dtQuestionList.Columns.Remove("UPDATE_DATE_DISPLAY")
        '分野・グループID
        dtQuestionList.Columns.Remove("CATEGORYID1")
        dtQuestionList.Columns.Remove("CATEGORYID2")
        'dtQuestionList.Columns.Remove("CATEGORYID3")
        '分野・グループ名
        dtQuestionList.Columns.Remove("CATEGORYNAME1")
        dtQuestionList.Columns.Remove("CATEGORYNAME2")
        'dtQuestionList.Columns.Remove("CATEGORYNAME3")
        'dtQuestionList.Columns.Remove("CATEGORYNAME4")
        ''利用人数
        'dtQuestionList.Columns.Remove("USECOUNT")
        '難易度
        dtQuestionList.Columns.Remove("LEVEL_STR")
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

    ''' <summary>
    ''' 難易度カラムの追加
    ''' </summary>
    ''' <param name="dtPracticeQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setLevel(ByRef dtPracticeQuestionList As DataTable)
        dtPracticeQuestionList.Columns.Add("LEVEL_STR", GetType(String), "IIF(LEVEL = '1','低',IIF(LEVEL = '2','中','高'))")
    End Sub
#End Region
End Class