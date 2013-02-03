Imports Microsoft.Office.Interop

''' <summary>
''' 総合テスト受講者一覧
''' </summary>
''' <remarks>
''' 2011/04/27 NOZAO 新規作成
''' </remarks>
Public Class frmSynthesisResultList
#Region "----- メンバ変数 -----"
    ''' <summary>
    ''' 総合テスト結果
    ''' </summary>
    ''' <remarks></remarks>
    Private _dsSynthesisResultHeader As New DataSet

    ''' <summary>グループコード</summary>
    Private _GroupCode As String = String.Empty

    ''' <summary>グループ情報</summary>
    Private _dtGroup As New DataTable

    ''' <summary>受講者</summary>
    Private _dtStudent As DataTable

    ''' <summary>コーステーブル</summary>
    Private _dtCourse As New DataTable

    ''' <summary>
    ''' 検索条件
    ''' </summary>
    ''' <remarks></remarks>
    Private _htSearchKeyFirstPage As New Hashtable

    ''' <summary>
    ''' 検索条件
    ''' </summary>
    ''' <remarks></remarks>
    Private _htSearchKeySecondPage As New Hashtable

    ''' <summary>
    ''' 検索条件
    ''' </summary>
    ''' <remarks></remarks>
    Private _htSearchKeyAveragePage As New Hashtable

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
    Private Sub frmSynthesisResultList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            'デザインを変更
            changeDesign()

            'ファイルダウンロード
            Common.DataManager.GetInstance.DownLoadFile()

            Owner.Hide()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' グリッドセルクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSynthesisResultList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSynthesisResultList.CellContentClick
        Try
            If e.ColumnIndex = USERID.Index And e.RowIndex <> -1 Then
                If dgvSynthesisResultList.CurrentRow.Cells(TOTALPOINTS.Name).Value Is DBNull.Value OrElse
                    dgvSynthesisResultList.CurrentRow.Cells(TOTALPOINTS.Name).Value Is Nothing Then
                    Exit Sub
                End If

                Dim frm As New frmSynthesisResultDetail
                setParameters(frm)
                frm.ShowDialog(Me)
                If frm.DialogResult = DialogResult.Cancel Then
                    Me.Close()
                Else
                    Show()
                    dgvSynthesisResultList.Cursor = Cursors.Arrow
                End If
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 抽出ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()

            '入力チェック
            If Not inputCheck() Then Exit Sub

            '受講者
            _dtStudent = getStudent()

            'グリッドデータ取得
            setGrid()

            '検索
            search()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 一覧のみ保存ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSaveList_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveList.Click
        Try
            logger.Start()
            If dgvSynthesisResultList.Rows.Count > 0 Then
                '出力ダイアログを表示
                Dim ofd As SaveFileDialog = New SaveFileDialog
                ofd.FileName = "総合テスト受講者別成績一覧.xls"
                ofd.InitialDirectory = ""
                ofd.Filter = "エクセルファイル(*.xls)|*.xls|すべてのファイル(*.*)|*.*"
                ofd.Title = "保存するファイルを選択してください"
                ofd.RestoreDirectory = False
                ofd.CheckFileExists = False
                If ofd.ShowDialog() = DialogResult.OK Then
                    processMessageOutput = True
                    'bkwPrint.RunWorkerAsync(ofd.FileName)

                    Dim excelCrater As New ExcelCreater
                    Try
                        processMessageOutput = True

                        'リソースをローカルに保存
                        My.Computer.FileSystem.WriteAllBytes(ofd.FileName, My.Resources.SynthesisResultReport, False)
                        CreateSynthesisList(ofd.FileName, excelCrater)

                        excelCrater.saveAs(ofd.FileName)

                        processMessageOutput = False

                        Common.Message.MessageShow("I007")
                    Catch ex As IO.IOException
                        Common.Message.MessageShow("E017")
                    Finally
                        processMessageOutput = False
                        excelCrater.Dispose()
                    End Try
                End If
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問別正誤含め保存ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveListAndErrata.Click
        Try
            logger.Start()
            If dgvSynthesisResultList.Rows.Count > 0 Then
                '出力ダイアログを表示
                Dim ofd As SaveFileDialog = New SaveFileDialog
                ofd.FileName = "総合テスト受講者別成績一覧.xls"
                ofd.InitialDirectory = ""
                ofd.Filter = "エクセルファイル(*.xls)|*.xls|すべてのファイル(*.*)|*.*"
                ofd.Title = "保存するファイルを選択してください"
                ofd.RestoreDirectory = False
                ofd.CheckFileExists = False
                If ofd.ShowDialog() = DialogResult.OK Then
                    Dim excelCrater As New ExcelCreater
                    Try
                        processMessageOutput = True

                        'リソースをローカルに保存
                        My.Computer.FileSystem.WriteAllBytes(ofd.FileName & ".temp1", My.Resources.SynthesisResultReport, False)
                        My.Computer.FileSystem.WriteAllBytes(ofd.FileName & ".temp2", My.Resources.SynthesisErrataList, False)
                        CreateSynthesisList(ofd.FileName & ".temp1", excelCrater)
                        CreateErrataList(ofd.FileName & ".temp2", excelCrater)

                        excelCrater.saveAs(ofd.FileName)

                        processMessageOutput = False

                        Common.Message.MessageShow("I007")
                    Catch ex As IO.IOException
                        Common.Message.MessageShow("E017")
                    Finally
                        processMessageOutput = False
                        excelCrater.Dispose()
                        If IO.File.Exists(ofd.FileName & ".temp1") Then IO.File.Delete(ofd.FileName & ".temp1")
                        If IO.File.Exists(ofd.FileName & ".temp2") Then IO.File.Delete(ofd.FileName & ".temp2")
                    End Try
                End If
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' コンボ変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbGroupCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGroupCode.SelectedIndexChanged
        '検索条件の設定
        Dim group As DataTable = cmbGroupCode.DataSource
        If group.Rows.Count > 0 Then
            setSearchCondition()
        End If
    End Sub

    ''' <summary>
    ''' 戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()

            Me.DialogResult = DialogResult.OK

            logger.End()
            Me.Close()
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
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
            End Select
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' グリッドデザインの変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changeDesign()
        '描画
        dgvSynthesisResultList.Columns(SECTION1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisResultList.Columns(SECTION2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisResultList.Columns(CATEGORY1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisResultList.Columns(CATEGORY2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisResultList.Columns(CATEGORY3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter

        dgvSynthesisResultList.AutoGenerateColumns = False

        If DataBanker.GetInstance("MENUMODE") <> Common.Constant.CST_MENUMODE_SYSTEM Then
            'コントロール使用不可
            cmbGroupCode.Enabled = False
            cmbGroupName.Enabled = False
            cmbCourse.Enabled = False
        End If

        'エクセルチェック
        btnSaveListAndErrata.Enabled = DataManager.GetInstance.IsExcel
        btnSaveList.Enabled = DataManager.GetInstance.IsExcel
    End Sub

    ''' <summary>
    ''' グリッドデータを設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setGrid()
        'データセット取得
        _dsSynthesisResultHeader = getSynthesisResultHeaderDataSet()

        'テーブル抽出
        Dim dtSynthesisResultHeader As DataTable = _dsSynthesisResultHeader.Tables("SynthesisResultHeader")
        Dim dtSynthesisResultDetail As DataTable = _dsSynthesisResultHeader.Tables("SynthesisResultDetail")
        Dim dtPracticeQuestionList As DataTable = _dsSynthesisResultHeader.Tables("PracticeQuestionList")
        Dim dtStudent As DataTable = _dsSynthesisResultHeader.Tables("Student")
        Dim dtCategory As DataTable = _dsSynthesisResultHeader.Tables("Category")

        '受講者リレーション
        Dim relStudent As DataRelation = New DataRelation("Student", dtStudent.Columns("USERID"), _
                                                               dtSynthesisResultHeader.Columns("USERID"), False)
        _dsSynthesisResultHeader.Relations.Add(relStudent)
        dtSynthesisResultHeader.Columns.Add("NAME", GetType(String), "Parent(Student).NAME")
        dtSynthesisResultHeader.Columns.Add("SECTION1", GetType(String), "Parent(Student).SECTION1")
        dtSynthesisResultHeader.Columns.Add("SECTION2", GetType(String), "Parent(Student).SECTION2")

        'テスト結果リレーション
        Dim pColumus(2) As DataColumn
        pColumus(0) = dtSynthesisResultHeader.Columns("USERID")
        pColumus(1) = dtSynthesisResultHeader.Columns("TESTNO")
        pColumus(2) = dtSynthesisResultHeader.Columns("TESTCOUNT")
        Dim cColumus(2) As DataColumn
        cColumus(0) = dtSynthesisResultDetail.Columns("USERID")
        cColumus(1) = dtSynthesisResultDetail.Columns("TESTNO")
        cColumus(2) = dtSynthesisResultDetail.Columns("TESTCOUNT")
        Dim relResult As DataRelation = New DataRelation("Result", pColumus, cColumus)
        _dsSynthesisResultHeader.Relations.Add(relResult)

        '演習問題一覧リレーション
        Dim relQuestionCode As DataRelation = New DataRelation("QuestionCode", dtPracticeQuestionList.Columns("QUESTIONCODE"), _
                                                               dtSynthesisResultDetail.Columns("QUESTIONCODE"), False)
        _dsSynthesisResultHeader.Relations.Add(relQuestionCode)
        dtSynthesisResultHeader.Columns.Add("TESTTIME_NUM", GetType(Integer))
        For iIndex = 0 To dtSynthesisResultHeader.Rows.Count - 1
            dtSynthesisResultHeader.Rows(iIndex).Item("TESTTIME_NUM") = Hour(dtSynthesisResultHeader.Rows(iIndex).Item(Common.SynthesisResultHeader.ColumnIndex.TestTime)) * 60 +
                                                                  Minute(dtSynthesisResultHeader.Rows(iIndex).Item(Common.SynthesisResultHeader.ColumnIndex.TestTime))
        Next
        dtSynthesisResultHeader.Columns.Remove("TESTTIME")
        dtSynthesisResultHeader.Columns.Add("TESTTIME", GetType(Integer), "TESTTIME_NUM")
        dtSynthesisResultDetail.Columns.Add("CATEGORYID", GetType(String), "Parent(QuestionCode).CATEGORYID")
        dtSynthesisResultDetail.Columns.Add("THEME", GetType(String), "Parent(QuestionCode).THEME")
        dtSynthesisResultDetail.Columns.Add("QUESTIONCLASS", GetType(String), "Parent(QuestionCode).QUESTIONCLASS")

        'カテゴリーリレーション
        Dim relCtegoryId As DataRelation = New DataRelation("CategoryId", dtCategory.Columns("DISPLAYID"), _
                                                       dtSynthesisResultDetail.Columns("CATEGORYID"), False)
        dtSynthesisResultHeader.DataSet.Relations.Add(relCtegoryId)
        dtSynthesisResultDetail.Columns.Add("PARENTCATEGORYID", GetType(String), "Parent(CategoryId).DISPLAYID1")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT_NUM", GetType(Integer), "CONVERT(ERRATA,'System.Int32')")

        '集計
        dtSynthesisResultDetail.Columns.Add("ERRATA1", GetType(Integer), "IIF(PARENTCATEGORYID = '1',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA2", GetType(Integer), "IIF(PARENTCATEGORYID = '2',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA3", GetType(Integer), "IIF(PARENTCATEGORYID = '3',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT1", GetType(Integer), "IIF(PARENTCATEGORYID = '1',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT2", GetType(Integer), "IIF(PARENTCATEGORYID = '2',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT3", GetType(Integer), "IIF(PARENTCATEGORYID = '3',1,0)")

        dtSynthesisResultHeader.Columns.Add("CATEGORY1VALUE", GetType(Single), "IIF(sum(Child(Result).ERRATACOUNT1) = 0,0,sum(Child(Result).ERRATA1) / sum(Child(Result).ERRATACOUNT1))")
        dtSynthesisResultHeader.Columns.Add("CATEGORY2VALUE", GetType(Single), "IIF(sum(Child(Result).ERRATACOUNT2) = 0,0,sum(Child(Result).ERRATA2) / sum(Child(Result).ERRATACOUNT2))")
        dtSynthesisResultHeader.Columns.Add("CATEGORY3VALUE", GetType(Single), "IIF(sum(Child(Result).ERRATACOUNT3) = 0,0,sum(Child(Result).ERRATA3) / sum(Child(Result).ERRATACOUNT3))")
        dtSynthesisResultHeader.Columns.Add("TOTALERRATA", GetType(Single), "sum(Child(Result).ERRATACOUNT_NUM)")
        dtSynthesisResultHeader.Columns.Add("TOTALERRATACOUNT", GetType(Single), "count(Child(Result).ERRATACOUNT_NUM)")
        dtSynthesisResultHeader.Columns.Add("TOTALPOINTSVALUE", GetType(Single), "sum(Child(Result).ERRATACOUNT_NUM) / count(Child(Result).ERRATACOUNT_NUM)")

        dtSynthesisResultDetail.Columns.Add("QUESTIONNO_NUM", GetType(Integer), "CONVERT(SHOWNO,'System.Int32')")
        dtSynthesisResultDetail.Columns.Add("ERRATA_DISPLAY", GetType(String), "IIF(ERRATA = '1','○','×')")
        dtSynthesisResultDetail.Columns.Add("ERRATA_PRINT", GetType(String), "IIF(ERRATA = '0',ANSWER,'○')")

        'テストNoでフィルター
        dtSynthesisResultHeader.DefaultView.RowFilter = "(TESTNO = '" & cmbTestName.SelectedValue & "' OR ISNULL(TESTNO,'') = '')"

        '未受験受講者追加
        setStudent(dtSynthesisResultHeader)

        'パーセントの切り捨て
        dtSynthesisResultHeader.Columns.Add("CATEGORY1", GetType(Single))
        dtSynthesisResultHeader.Columns.Add("CATEGORY2", GetType(Single))
        dtSynthesisResultHeader.Columns.Add("CATEGORY3", GetType(Single))
        dtSynthesisResultHeader.Columns.Add("TOTALPOINTS", GetType(Single))
        For Each dr As DataRow In dtSynthesisResultHeader.Rows
            If Not dr.Item("CATEGORY1VALUE") Is DBNull.Value Then
                dr.Item("CATEGORY1") = System.Math.Floor(dr.Item("CATEGORY1VALUE") * 1000) / 1000
                dr.Item("CATEGORY2") = System.Math.Floor(dr.Item("CATEGORY2VALUE") * 1000) / 1000
                dr.Item("CATEGORY3") = System.Math.Floor(dr.Item("CATEGORY3VALUE") * 1000) / 1000
                dr.Item("TOTALPOINTS") = System.Math.Floor(dr.Item("TOTALPOINTSVALUE") * 1000) / 1000
            End If
        Next

    End Sub

    ''' <summary>
    ''' 検索条件を設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setSearchCondition()
        '実施回
        If cmbTestCount.DataSource Is Nothing Then
            Dim DataSource As New DataTable("DataSource")
            DataSource.Columns.Add("Value", GetType(String))
            DataSource.Columns.Add("code", GetType(Integer))
            DataSource.Rows.Add(" ", 4)
            DataSource.Rows.Add("１回目実施のみ", 1)
            DataSource.Rows.Add("２回目実施のみ", 2)
            DataSource.Rows.Add("１回目と２回目", 3)

            cmbTestCount.DataSource = DataSource
            cmbTestCount.ValueMember = "code"
            cmbTestCount.DisplayMember = "Value"
        End If

        '区分
        cmbSection1.DataSource = Common.Constant.CST_SECTION1_CMB
        cmbSection2.DataSource = Common.Constant.CST_SECTION2_CMB
    End Sub

    ''' <summary>
    ''' コンボボックスに"すべて"を追加する
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addComboBrankItem(ByVal dt As DataTable) As DataTable
        Dim dtwk As New DataTable
        dtwk = dt.Clone
        dtwk.Rows.Add()
        With dtwk.Rows(0)
            .Item("GROUPNAME") = Common.Constant.CST_ALL
            .Item("GROUPCODE") = Common.Constant.CST_ALL
        End With
        dtwk.Merge(dt)
        Return dtwk
    End Function
    ''' <summary>
    ''' 受講者情報取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getStudent() As DataTable
        Dim fileName As String = Common.Constant.CST_STUDENT_FILENAME & _GroupCode & Common.Constant.CST_EXTENSION_XML
        Dim dtStudent As DataTable = Common.Student.GetAll(fileName)
        'テスト回数削除
        dtStudent.Columns.Remove("TESTCOUNT")
        dtStudent.Columns.Add("TESTCOUNT")

        Return dtStudent
    End Function

    ''' <summary>
    ''' 受講者情報を設定
    ''' </summary>
    ''' <param name="dtSynthesisResultHeader"></param>
    ''' <remarks></remarks>
    Private Sub setStudent(ByRef dtSynthesisResultHeader As DataTable)
        Dim dtParent As New DataTable
        Dim drNew As DataRow = Nothing

        For Each dr As DataRow In _dtStudent.Rows
            Dim foundDataRow As DataRow() = dtSynthesisResultHeader.DefaultView.ToTable.Select("USERID = '" & dr(Common.Student.ColumnIndex.UserId) & "'")
            If foundDataRow.Length = 0 Then
                drNew = dtSynthesisResultHeader.NewRow
                drNew(Common.SynthesisResultHeader.ColumnIndex.UserId) = dr(Common.SynthesisResultHeader.ColumnIndex.UserId)
                dtSynthesisResultHeader.Rows.Add(drNew)
            End If
        Next
    End Sub

    ''' <summary>
    ''' 総合テスト履歴のデータセットを取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getSynthesisResultHeaderDataSet() As DataSet
        Dim dataset As New DataSet
        '総合テスト結果ヘッダ
        Dim dtSynthesisResultHeader As New DataTable
        If IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & _GroupCode & Common.Constant.CST_EXTENSION_XML) Then
            dtSynthesisResultHeader = Common.SynthesisResultHeader.GetAll(Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & _GroupCode & Common.Constant.CST_EXTENSION_XML)
        Else
            Common.XmlSchema.GetSynthesisResultHeaderSchema(dtSynthesisResultHeader)
        End If

        '総合テスト結果明細
        Dim dtSynthesisResultDetail As New DataTable
        If IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & _GroupCode & Common.Constant.CST_EXTENSION_XML) Then
            dtSynthesisResultDetail = Common.SynthesisResultHeader.GetAll(Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & _GroupCode & Common.Constant.CST_EXTENSION_XML)
        Else
            Common.XmlSchema.GetSynthesisResultDetailSchema(dtSynthesisResultDetail)
        End If

        '演習問題一覧
        Dim dtPracticeQuestionList As DataTable = _
            Common.PracticeQuestionList.GetAll(Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)

        Dim category As New Common.CategoryMaster(4)
        Dim dtCategory As DataTable = category.GetCategoryTable()


        dataset.Tables.Add(dtSynthesisResultHeader.Copy)
        dataset.Tables.Add(dtSynthesisResultDetail.Copy)
        dataset.Tables.Add(dtPracticeQuestionList.Copy)
        dataset.Tables.Add(_dtStudent.Copy)
        dataset.Tables.Add(dtCategory.Copy)

        Return dataset
    End Function

    ''' <summary>
    ''' 検索する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub search()
        Dim dtSynthesisResultHeader As DataTable = _dsSynthesisResultHeader.Tables("SynthesisResultHeader")
        Dim rowFilter As String = getRowFilter()
        Dim averageFlg As Boolean = False

        ''フィルター
        dtSynthesisResultHeader.DefaultView.RowFilter = getRowFilter()
        dtSynthesisResultHeader.DefaultView.Sort = "USERID ASC"

        Dim dataView As New DataView(dtSynthesisResultHeader)
        dataView.RowFilter = "ISNULL(TESTCOUNT,'') <> ''"

        '平均
        If dtSynthesisResultHeader.DefaultView.Count > 0 Then
            dgvSynthesisResultList.DataSource = dtSynthesisResultHeader
            If dataView.Count > 0 AndAlso Not IsDBNull(dtSynthesisResultHeader.Compute("Avg(TESTTIME_NUM)", rowFilter)) Then
                lblTime.Text = System.Math.Floor(dtSynthesisResultHeader.Compute("Avg(TESTTIME_NUM)", rowFilter) * 10) / 10 & "分"
                lblStrategy.Text = Format(System.Math.Floor(dtSynthesisResultHeader.Compute("Avg(CATEGORY1)", rowFilter) * 1000) / 10, "#0.0") & "%"
                lblManagement.Text = Format(System.Math.Floor(dtSynthesisResultHeader.Compute("Avg(CATEGORY2)", rowFilter) * 1000) / 10, "#0.0") & "%"
                lblTechnology.Text = Format(System.Math.Floor(dtSynthesisResultHeader.Compute("Avg(CATEGORY3)", rowFilter) * 1000) / 10, "#0.0") & "%"
                lblTotal.Text = Format(System.Math.Floor(dtSynthesisResultHeader.Compute("Avg(TOTALPOINTS)", rowFilter) * 1000) / 10, "#0.0") & "%"
            Else
                lblTime.Text = ""
                lblStrategy.Text = ""
                lblManagement.Text = ""
                lblTechnology.Text = ""
                lblTotal.Text = ""
            End If

            '検索条件保持
            _htSearchKeyFirstPage(cmbGroupCode.Name) = cmbGroupCode.Text
            _htSearchKeyFirstPage(cmbGroupName.Name) = cmbGroupName.Text
            _htSearchKeyFirstPage(cmbCourse.Name) = cmbCourse.Text
            _htSearchKeyFirstPage(cmbSection1.Name) = cmbSection1.Text
            _htSearchKeyFirstPage(cmbSection2.Name) = cmbSection2.Text
            _htSearchKeyFirstPage(cmbTestName.Name) = cmbTestName.Text
            _htSearchKeyFirstPage(cmbTestCount.Name) = cmbTestCount.Text
            _htSearchKeyFirstPage(udtpStart.Name) = udtpStart.Text
            _htSearchKeyFirstPage(udtpEnd.Name) = udtpEnd.Text
            _htSearchKeyFirstPage(txtStrategyStart.Name) = txtStrategyStart.Text
            _htSearchKeyFirstPage(txtStrategyEnd.Name) = txtStrategyEnd.Text
            _htSearchKeyFirstPage(txtManagementStart.Name) = txtManagementStart.Text
            _htSearchKeyFirstPage(txtManagementEnd.Name) = txtManagementEnd.Text
            _htSearchKeyFirstPage(txtTechnologyStart.Name) = txtTechnologyStart.Text
            _htSearchKeyFirstPage(txtTechnologyEnd.Name) = txtTechnologyEnd.Text
            _htSearchKeyFirstPage(txtTotalStart.Name) = txtTotalStart.Text
            _htSearchKeyFirstPage(txtTotalEnd.Name) = txtTotalEnd.Text

            _htSearchKeySecondPage(cmbGroupName.Name & "2") = cmbGroupName.Text

            _htSearchKeyAveragePage(lblTime.Name) = lblTime.Text
            _htSearchKeyAveragePage(lblStrategy.Name) = lblStrategy.Text
            _htSearchKeyAveragePage(lblManagement.Name) = lblManagement.Text
            _htSearchKeyAveragePage(lblTechnology.Name) = lblTechnology.Text
            _htSearchKeyAveragePage(lblTotal.Name) = lblTotal.Text
        Else
            Common.Message.MessageShow("I002")
        End If


    End Sub

    ''' <summary>
    ''' RowFilterを取得する。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getRowFilter() As String
        Dim rowFilter As String = "1=1"
        '区分１
        If cmbSection1.Text <> "" Then rowFilter &= " AND SECTION1 = '" & cmbSection1.Text & "'"
        '区分２
        If cmbSection2.Text <> "" Then rowFilter &= " AND SECTION2 = '" & cmbSection2.Text & "'"

        'テスト名
        rowFilter &= " AND (TESTNO = '" & cmbTestName.SelectedValue & "' OR ISNULL(TESTNO,'') = '')"

        '実施回
        If cmbTestCount.SelectedValue = 1 Then rowFilter &= " AND TESTCOUNT = '1'"
        If cmbTestCount.SelectedValue = 2 Then rowFilter &= " AND TESTCOUNT = '2'"
        If cmbTestCount.SelectedValue = 3 Then rowFilter &= " AND (TESTCOUNT = '1' OR TESTCOUNT = '2')"

        '実施日
        If udtpStart.ToShortDateString <> "" Then rowFilter &= " AND TESTDATE >= '" & udtpStart.ToShortDateString & "'"
        If udtpEnd.ToShortDateString <> "" Then rowFilter &= " AND TESTDATE <= '" & udtpEnd.ToShortDateString & "'"

        '正解率
        If txtStrategyStart.Text <> "" Then rowFilter &= " AND CATEGORY1 >= '" & txtStrategyStart.Text / 100 & "'"
        If txtStrategyEnd.Text <> "" Then rowFilter &= " AND CATEGORY1 <= '" & txtStrategyEnd.Text / 100 & "'"
        If txtManagementStart.Text <> "" Then rowFilter &= " AND CATEGORY2 >= '" & txtManagementStart.Text / 100 & "'"
        If txtManagementEnd.Text <> "" Then rowFilter &= " AND CATEGORY2 <= '" & txtManagementEnd.Text / 100 & "'"
        If txtTechnologyStart.Text <> "" Then rowFilter &= " AND CATEGORY3 >= '" & txtTechnologyStart.Text / 100 & "'"
        If txtTechnologyEnd.Text <> "" Then rowFilter &= " AND CATEGORY3 <= '" & txtTechnologyEnd.Text / 100 & "'"
        If txtTotalStart.Text <> "" Then rowFilter &= " AND TOTALPOINTS >= '" & txtTotalStart.Text / 100 & "'"
        If txtTotalEnd.Text <> "" Then rowFilter &= " AND TOTALPOINTS <= '" & txtTotalEnd.Text / 100 & "'"

        Return rowFilter
    End Function

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
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
                Common.Message.MessageShow("E070")
                Return False
            End If
        End If

        'ストラテジ系
        If Not Common.InputCheck.RateRangeCheck(txtStrategyStart.Text, "ストラテジ系の正解率(以上)") Then Return False
        If Not Common.InputCheck.RateRangeCheck(txtStrategyEnd.Text, "ストラテジ系の正解率(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtStrategyStart.Text, txtStrategyEnd.Text, "ストラテジ系の正解率") Then Return False

        'マネジメント系
        If Not Common.InputCheck.RateRangeCheck(txtManagementStart.Text, "マネジメント系の正解率(以上)") Then Return False
        If Not Common.InputCheck.RateRangeCheck(txtManagementEnd.Text, "マネジメント系の正解率(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtManagementStart.Text, txtManagementEnd.Text, "マネジメント系の正解率") Then Return False
        'テクノロジ系
        If Not Common.InputCheck.RateRangeCheck(txtTechnologyStart.Text, "テクノロジ系の正解率(以上)") Then Return False
        If Not Common.InputCheck.RateRangeCheck(txtTechnologyEnd.Text, "テクノロジ系の正解率(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtTechnologyStart.Text, txtTechnologyEnd.Text, "テクノロジ系の正解率") Then Return False
        '総合正解率
        If Not Common.InputCheck.RateRangeCheck(txtTotalStart.Text, "総合正解率(以上)") Then Return False
        If Not Common.InputCheck.RateRangeCheck(txtTotalEnd.Text, "総合正解率(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtTotalStart.Text, txtTotalEnd.Text, "総合正解率") Then Return False

        Return True
    End Function

    ''' <summary>
    ''' 受講者履歴詳細画面のパラメータを設定する
    ''' </summary>
    ''' <param name="frm"></param>
    ''' <remarks></remarks>
    Private Sub setParameters(ByVal frm As frmSynthesisResultDetail)
        Dim rowValues As String = ""
        Dim relation As DataRelation = _dsSynthesisResultHeader.Relations("Result")
        Dim dtDetail As New DataTable

        Dim drCurrentRow As DataRow = CType(dgvSynthesisResultList.CurrentRow.DataBoundItem.row, DataRow)

        relation.ChildTable.DefaultView.RowFilter = "USERID = '" & drCurrentRow(Common.SynthesisResultHeader.ColumnIndex.UserId) & "'" &
                                                        "AND TESTNO = '" & drCurrentRow(Common.SynthesisResultHeader.ColumnIndex.TestNo) & "'" &
                                                        " AND TESTCOUNT = '" & drCurrentRow(Common.SynthesisResultHeader.ColumnIndex.TestCount) & "'"

        frm.lblMainUserId.Text = dgvSynthesisResultList.CurrentRow.Cells(USERID.Name).Value
        frm.lblMainUserName.Text = dgvSynthesisResultList.CurrentRow.Cells(USERNAME.Name).Value
        frm.lblSection1.Text = dgvSynthesisResultList.CurrentRow.Cells(SECTION1.Name).Value
        frm.lblSection2.Text = dgvSynthesisResultList.CurrentRow.Cells(SECTION2.Name).Value
        frm.lblTestName.Text = cmbTestName.Text
        frm.lblTestDate.Text = drCurrentRow(Common.SynthesisResultHeader.ColumnIndex.TestDate)
        frm.lblErrataCount.Text = drCurrentRow("TOTALERRATA")
        frm.lblQuestionCount.Text = drCurrentRow("TOTALERRATACOUNT")
        frm.lblAccuracyRate.Text = Format(CType(dgvSynthesisResultList.CurrentRow.Cells(TOTALPOINTS.Name).Value * 100, Integer), "##0.0")
        frm.SynthesisResultList = relation.ChildTable
    End Sub

    ''' <summary>
    ''' エクセルを保存
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub CreateSynthesisList(ByVal fileName As String, ByVal excelCrater As ExcelCreater)
        Try
            'OKボタンがクリックされたとき
            excelCrater.Create(fileName,
                                "総合テスト受講者別成績一覧",
                                _htSearchKeyFirstPage,
                                CType(dgvSynthesisResultList.DataSource, DataTable).DefaultView.ToTable(True, {USERID.Name,
                                                                                                                "NAME",
                                                                                                                SECTION1.Name,
                                                                                                                SECTION2.Name,
                                                                                                                TESTCOUNT.Name,
                                                                                                                TESTTIME.Name,
                                                                                                                CATEGORY1.Name,
                                                                                                                CATEGORY2.Name,
                                                                                                                CATEGORY3.Name,
                                                                                                                TOTALPOINTS.Name}),
                                _htSearchKeySecondPage,
                                51, 25, 33, 18, True, _htSearchKeyAveragePage)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' エクセルを保存
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub CreateErrataList(ByVal fileName As String, ByVal excelCrater As ExcelCreater)
        Try
            Dim dtSynthesisResultList As DataTable = makeErrataList()
            Dim ht As New Hashtable
            ht(cmbTestName.Name) = cmbTestName.Text & "　問別正誤一覧"
            If _dsSynthesisResultHeader.Tables("SynthesisResultDetail").Rows.Count > 0 Then
                For i = 1 To 50
                    ht("ANSWER" & i) = _dsSynthesisResultHeader.Tables("SynthesisResultDetail").Rows(i - 1).Item("CORRECTANSWER")
                Next
            End If
            excelCrater.Create(fileName, "総合テスト問別正誤一覧", ht, dtSynthesisResultList, False)
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    '''正誤一覧データを作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function makeErrataList() As DataTable
        Dim dataview As New DataView
        Dim dtSynthesisResultList As DataTable = CType(dgvSynthesisResultList.DataSource, DataTable).DefaultView.ToTable(True,
                                                                                                                         USERID.Name,
                                                                                                                         "TESTNO",
                                                                                                                         TESTCOUNT.Name,
                                                                                                                         "NAME",
                                                                                                                         SECTION1.Name,
                                                                                                                         SECTION2.Name)
        For i = 1 To 100
            dtSynthesisResultList.Columns.Add("ERRATA" & i)
        Next
        For Each dr As DataRow In dtSynthesisResultList.Rows
            Dim rowFilter As String = "USERID = '" & dr(Common.SynthesisResultHeader.ColumnIndex.UserId) & "'" &
                                                        "AND TESTNO = '" & dr(Common.SynthesisResultHeader.ColumnIndex.TestNo) & "'" &
                                                        " AND TESTCOUNT = '" & dr(Common.SynthesisResultHeader.ColumnIndex.TestCount) & "'"
            dataview.Table = _dsSynthesisResultHeader.Tables("SynthesisResultDetail")
            dataview.RowFilter = rowFilter
            For i = 1 To 100
                dataview.RowFilter = rowFilter & " AND SHOWNO = '" & i & "'"
                If dataview.ToTable.Rows.Count > 0 Then
                    dr("ERRATA" & i) = dataview.ToTable.Rows(0).Item("ERRATA_PRINT")
                End If
            Next
        Next
        dtSynthesisResultList.Columns.Remove("TESTNO")

        Return dtSynthesisResultList
    End Function
#End Region
End Class
