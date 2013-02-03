Imports Microsoft.Office.Interop

''' <summary>
''' 総合テスト問別分析結果
''' </summary>
''' <remarks>
''' 2012/04/30 NOZAO 新規作成
''' </remarks>
Public Class frmSynthesisQuestionAnalysis
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
    Private Sub frmSynthesisResultList_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
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
    ''' グリッドセルクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSynthesisQuestionAnalysis_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSynthesisQuestionAnalysis.CellContentClick
        Try
            logger.Start()
            If e.ColumnIndex = QUESTIONCODE.Index And e.RowIndex <> -1 Then
                Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection
                Dim index As Integer = createPraciticeQuestionInfoCollection(dgvSynthesisQuestionAnalysis, PraciticeQuestionInfoCollection)
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(index, PraciticeQuestionInfoCollection, True)
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

            '検索
            search()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' EXCEL保存ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            logger.Start()
            If dgvSynthesisQuestionAnalysis.Rows.Count > 0 Then
                '出力ダイアログを表示
                Dim ofd As SaveFileDialog = New SaveFileDialog
                ofd.FileName = "総合テスト問別分析結果.xls"
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
                        My.Computer.FileSystem.WriteAllBytes(ofd.FileName, My.Resources.SynthesisQuestionAnalysisReport, False)
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
    ''' セルフォーマット
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSynthesisQuestionAnalysis_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvSynthesisQuestionAnalysis.CellFormatting
        If dgvSynthesisQuestionAnalysis.Rows.Count > 0 Then
            Dim dr As DataRow = CType(dgvSynthesisQuestionAnalysis.Rows(e.RowIndex).DataBoundItem.row, DataRow)
            Dim correctAnswer As String = dr("CORRECTANSWER")
            Select Case e.ColumnIndex
                Case SELECT1.Index
                    If correctAnswer = "Ａ" Then
                        e.CellStyle.BackColor = Color.Cyan
                        e.CellStyle.SelectionBackColor = Color.Cyan
                    End If
                Case SELECT2.Index
                    If correctAnswer = "Ｂ" Then
                        e.CellStyle.BackColor = Color.Cyan
                        e.CellStyle.SelectionBackColor = Color.Cyan
                    End If
                Case SELECT3.Index
                    If correctAnswer = "Ｃ" Then
                        e.CellStyle.BackColor = Color.Cyan
                        e.CellStyle.SelectionBackColor = Color.Cyan
                    End If
                Case SELECT4.Index
                    If correctAnswer = "Ｄ" Then
                        e.CellStyle.BackColor = Color.Cyan
                        e.CellStyle.SelectionBackColor = Color.Cyan
                    End If
                Case SELECT5.Index
                    If correctAnswer = "Ｅ" Then
                        e.CellStyle.BackColor = Color.Cyan
                        e.CellStyle.SelectionBackColor = Color.Cyan
                    End If
            End Select
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

#Region "----- メソッド -----"
    ''' <summary>
    ''' 問題確認画面へ渡す演習問題情報を設定する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Function createPraciticeQuestionInfoCollection(ByVal dgrErrataList As DataGridView, ByRef praciticeQuestionInfoCollection As PracticeQuestionShow.PraciticeQuestionInfoCollection) As Integer
        Dim ht As New Hashtable
        Dim index As Integer = 0
        For Each dgvr As DataGridViewRow In dgrErrataList.Rows
            Dim dr As DataRow = dgvr.DataBoundItem.Row
            Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
            If Not ht.Contains(dr("QUESTIONCODE")) Then
                praciticeQuestionInfo.QuestionNo = dr("SHOWNO")
                praciticeQuestionInfo.QuestionCode = dr("QUESTIONCODE")
                praciticeQuestionInfo.MiddleQuestionCode = dr("MAINCODE")
                praciticeQuestionInfo.IsMiddleQuestion = IIf(dr("QUESTIONCLASS") = "2", True, False)
                praciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
                ht(dr("QUESTIONCODE")) = index
                index += 1
            End If
        Next

        Return ht(dgrErrataList.CurrentRow.Cells(QUESTIONCODE.Index).Value)
    End Function

    ''' <summary>
    ''' グリッドデザインの変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changeDesign()
        '描画
        dgvSynthesisQuestionAnalysis.Columns(CATEGORY1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(CATEGORY2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(CATEGORY3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(SELECT1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(SELECT2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(SELECT3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(SELECT4.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(SELECT5.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        dgvSynthesisQuestionAnalysis.Columns(SELECTNULL.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter

        dgvSynthesisQuestionAnalysis.AutoGenerateColumns = False

        If DataBanker.GetInstance("MENUMODE") <> Common.Constant.CST_MENUMODE_SYSTEM Then
            'コントロール使用不可
            cmbGroupCode.Enabled = False
            cmbGroupName.Enabled = False
            cmbCourse.Enabled = False
        End If
        'エクセルチェック
        btnSave.Enabled = DataManager.GetInstance.IsExcel
    End Sub

    ''' <summary>
    ''' グリッドデータを設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setSearchFirstFilterData()
        Dim categoryId_A As String = Common.CategoryMaster.categoryId.fieldCategoryId_A
        Dim categoryId_B As String = Common.CategoryMaster.categoryId.fieldCategoryId_B
        Dim categoryId_C As String = Common.CategoryMaster.categoryId.fieldCategoryId_C
        Dim categoryId_D As String = Common.CategoryMaster.categoryId.fieldCategoryId_D

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
        dtSynthesisResultDetail.Columns.Add("ERRATA1", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_A & "',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA2", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_B & "',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA3", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_C & "',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA4", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_D & "',ERRATACOUNT_NUM,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT1", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_A & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT2", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_B & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT3", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_C & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATACOUNT4", GetType(Integer), "IIF(PARENTCATEGORYID = '" & categoryId_D & "',1,0)")

        dtSynthesisResultHeader.Columns.Add("CATEGORY1VALUE", GetType(Single), "sum(Child(Result).ERRATA1) / sum(Child(Result).ERRATACOUNT1)")
        dtSynthesisResultHeader.Columns.Add("CATEGORY2VALUE", GetType(Single), "sum(Child(Result).ERRATA2) / sum(Child(Result).ERRATACOUNT2)")
        dtSynthesisResultHeader.Columns.Add("CATEGORY3VALUE", GetType(Single), "sum(Child(Result).ERRATA3) / sum(Child(Result).ERRATACOUNT3)")
        dtSynthesisResultHeader.Columns.Add("CATEGORY4VALUE", GetType(Single), "sum(Child(Result).ERRATA4) / sum(Child(Result).ERRATACOUNT4)")
        dtSynthesisResultHeader.Columns.Add("TOTALERRATA", GetType(Single), "sum(Child(Result).ERRATACOUNT_NUM)")
        dtSynthesisResultHeader.Columns.Add("TOTALERRATACOUNT", GetType(Single), "count(Child(Result).ERRATACOUNT_NUM)")
        dtSynthesisResultHeader.Columns.Add("TOTALPOINTSVALUE", GetType(Single), "sum(Child(Result).ERRATACOUNT_NUM) / count(Child(Result).ERRATACOUNT_NUM)")

        dtSynthesisResultDetail.Columns.Add("QUESTIONNO_NUM", GetType(Integer), "CONVERT(SHOWNO,'System.Int32')")
        dtSynthesisResultDetail.Columns.Add("ERRATA_DISPLAY", GetType(String), "IIF(ERRATA = '1','○','×')")
        dtSynthesisResultDetail.Columns.Add("ERRATA_PRINT", GetType(String), "IIF(ERRATA = '0',ANSWER,'○')")

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

        dtSynthesisResultHeader.DefaultView.RowFilter = getFirstRowFilter()
    End Sub

    ''' <summary>
    ''' グリッドデータを設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setGroupByData()
        'テーブル抽出
        Dim dtSynthesisResultHeader As DataTable = _dsSynthesisResultHeader.Tables("SynthesisResultHeader")
        Dim dtSynthesisResultDetail As DataTable = _dsSynthesisResultHeader.Tables("SynthesisResultDetail")
        Dim dtPracticeQuestionList As DataTable = _dsSynthesisResultHeader.Tables("PracticeQuestionList")
        Dim dtCategory As DataTable = _dsSynthesisResultHeader.Tables("Category")
        Dim dtStudent As DataTable = _dsSynthesisResultHeader.Tables("Student")

        Dim dtFilterSynthesisResultHeader As DataTable = dtSynthesisResultHeader.DefaultView.ToTable
        dtFilterSynthesisResultHeader.TableName = "FilterSynthesisResultHeader"
        _dsSynthesisResultHeader.Tables.Add(dtFilterSynthesisResultHeader)

        'テスト結果リレーション
        Dim pColumus(2) As DataColumn
        pColumus(0) = dtFilterSynthesisResultHeader.Columns("USERID")
        pColumus(1) = dtFilterSynthesisResultHeader.Columns("TESTNO")
        pColumus(2) = dtFilterSynthesisResultHeader.Columns("TESTCOUNT")
        Dim cColumus(2) As DataColumn
        cColumus(0) = dtSynthesisResultDetail.Columns("USERID")
        cColumus(1) = dtSynthesisResultDetail.Columns("TESTNO")
        cColumus(2) = dtSynthesisResultDetail.Columns("TESTCOUNT")
        Dim relResult As DataRelation = New DataRelation("ResultFilter", pColumus, cColumus, False)
        _dsSynthesisResultHeader.Relations.Add(relResult)

        dtSynthesisResultDetail.Columns.Add("PARENTUSERID", GetType(String), "Parent(ResultFilter).USERID")

        dtSynthesisResultDetail.Columns.Add("CATEGORY1", GetType(String), "Parent(CategoryId).CATEGORYNAME1")
        dtSynthesisResultDetail.Columns.Add("CATEGORY2", GetType(String), "Parent(CategoryId).CATEGORYNAME2")
        dtSynthesisResultDetail.Columns.Add("CATEGORY3", GetType(String), "Parent(CategoryId).CATEGORYNAME3")

        '集計

        dtSynthesisResultDetail.Columns.Add("ERRATA_SELECT1", GetType(Integer), "IIF(ANSWER = '" & Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(0) & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA_SELECT2", GetType(Integer), "IIF(ANSWER = '" & Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(1) & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA_SELECT3", GetType(Integer), "IIF(ANSWER = '" & Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(2) & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA_SELECT4", GetType(Integer), "IIF(ANSWER = '" & Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(3) & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA_SELECT5", GetType(Integer), "IIF(ANSWER = '" & Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(4) & "',1,0)")
        dtSynthesisResultDetail.Columns.Add("ERRATA_SELECTNULL", GetType(Integer), "IIF(ANSWER = '',1,0)")

        'フィルター
        dtSynthesisResultDetail.DefaultView.RowFilter = "PARENTUSERID <> ''"

        Dim dsHelper As New Common.DataSetHelper(_dsSynthesisResultHeader)
        Dim dt As New DataTable
        dsHelper.SelectGroupByInto("SynthesisResultDetailSummary", dtSynthesisResultDetail.DefaultView.ToTable,
                                   "QUESTIONCODE,TESTCOUNT," &
                                   "first(SHOWNO) SHOWNO," &
                                   "first(MAINCODE) MAINCODE," &
                                   "first(QUESTIONCLASS) QUESTIONCLASS," &
                                   "first(THEME) THEME," &
                                   "first(ANSWER) ANSWER," &
                                   "first(CORRECTANSWER) CORRECTANSWER," &
                                   "first(CATEGORY1) CATEGORY1," &
                                   "first(CATEGORY2) CATEGORY2," &
                                   "first(CATEGORY3) CATEGORY3," &
                                   "sum(ERRATACOUNT_NUM) ERRATA," &
                                   "count(ERRATACOUNT_NUM) COUNT_ERRATA," &
                                   "sum(ERRATA_SELECT1) ERRATA_SELECT1," &
                                   "count(ERRATA_SELECT1) COUNT_SELECT1," &
                                   "sum(ERRATA_SELECT2) ERRATA_SELECT2," &
                                   "count(ERRATA_SELECT2) COUNT_SELECT2," &
                                   "sum(ERRATA_SELECT3) ERRATA_SELECT3," &
                                   "count(ERRATA_SELECT3) COUNT_SELECT3," &
                                   "sum(ERRATA_SELECT4) ERRATA_SELECT4," &
                                   "count(ERRATA_SELECT4) COUNT_SELECT4," &
                                   "sum(ERRATA_SELECT5) ERRATA_SELECT5," &
                                   "count(ERRATA_SELECT5) COUNT_SELECT5," &
                                   "sum(ERRATA_SELECTNULL) ERRATA_SELECTNULL," &
                                   "count(ERRATA_SELECTNULL) COUNT_SELECTNULL",
                                   "", "QUESTIONCODE,TESTCOUNT", True)

        Dim synthesisResultDetailSummary As DataTable = dtSynthesisResultDetail.DataSet.Tables("SynthesisResultDetailSummary")
        synthesisResultDetailSummary.DefaultView.RowFilter = "TESTCOUNT <> ''"
        synthesisResultDetailSummary.Columns.Add("ERRATA_NUM", GetType(Single), "ERRATA / COUNT_ERRATA")
        synthesisResultDetailSummary.Columns.Add("SELECT1VALUE", GetType(Single), "ERRATA_SELECT1 / COUNT_SELECT1")
        synthesisResultDetailSummary.Columns.Add("SELECT2VALUE", GetType(Single), "ERRATA_SELECT2 / COUNT_SELECT2")
        synthesisResultDetailSummary.Columns.Add("SELECT3VALUE", GetType(Single), "ERRATA_SELECT3 / COUNT_SELECT3")
        synthesisResultDetailSummary.Columns.Add("SELECT4VALUE", GetType(Single), "ERRATA_SELECT4 / COUNT_SELECT4")
        synthesisResultDetailSummary.Columns.Add("SELECT5VALUE", GetType(Single), "ERRATA_SELECT5 / COUNT_SELECT5")
        synthesisResultDetailSummary.Columns.Add("SELECTNULLVALUE", GetType(Single), "ERRATA_SELECTNULL / COUNT_SELECTNULL")

        'パーセントの切り捨て
        synthesisResultDetailSummary.Columns.Add("SELECT1", GetType(Single))
        synthesisResultDetailSummary.Columns.Add("SELECT2", GetType(Single))
        synthesisResultDetailSummary.Columns.Add("SELECT3", GetType(Single))
        synthesisResultDetailSummary.Columns.Add("SELECT4", GetType(Single))
        synthesisResultDetailSummary.Columns.Add("SELECT5", GetType(Single))
        synthesisResultDetailSummary.Columns.Add("SELECTNULL", GetType(Single))
        For Each dr As DataRow In synthesisResultDetailSummary.Rows
            If Not dr.Item("SELECT1VALUE") Is DBNull.Value Then
                dr.Item("SELECT1") = System.Math.Floor(dr.Item("SELECT1VALUE") * 1000) / 1000
                dr.Item("SELECT2") = System.Math.Floor(dr.Item("SELECT2VALUE") * 1000) / 1000
                dr.Item("SELECT3") = System.Math.Floor(dr.Item("SELECT3VALUE") * 1000) / 1000
                dr.Item("SELECT4") = System.Math.Floor(dr.Item("SELECT4VALUE") * 1000) / 1000
                dr.Item("SELECT5") = System.Math.Floor(dr.Item("SELECT5VALUE") * 1000) / 1000
                dr.Item("SELECTNULL") = System.Math.Floor(dr.Item("SELECTNULLVALUE") * 1000) / 1000
            End If
        Next
        'ソート
        synthesisResultDetailSummary.Columns.Add("SHOWNO_NUM", GetType(Integer), "CONVERT(SHOWNO,'System.Int32')")
        synthesisResultDetailSummary.DefaultView.Sort = "SHOWNO_NUM ASC"
        'バインド
        If synthesisResultDetailSummary.DefaultView.Count > 0 Then
            dgvSynthesisQuestionAnalysis.DataSource = synthesisResultDetailSummary

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
        Else
            Common.Message.MessageShow("I002")
        End If
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
            Dim foundDataRow As DataRow() = dtSynthesisResultHeader.Select("USERID = '" & dr(Common.Student.ColumnIndex.UserId) & "'")
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

        Dim category As New Common.CategoryMaster(2)
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
        'グリッドデータ取得
        setSearchFirstFilterData()
        setGroupByData()

    End Sub

    ''' <summary>
    ''' RowFilterを取得する。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getFirstRowFilter() As String
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
    ''' RowFilterを取得する。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getSecndRowFilter() As String
        Dim rowFilter As String = "1=1"

        '正解率
        If txtStrategyStart.Text <> "" Then rowFilter &= " AND SELECT1 >= '" & txtStrategyStart.Text / 100 & "'"
        If txtStrategyEnd.Text <> "" Then rowFilter &= " AND SELECT1 <= '" & txtStrategyEnd.Text / 100 & "'"
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
    ''' エクセルを保存
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub CreateSynthesisList(ByVal fileName As String, ByVal excelCrater As ExcelCreater)
        Try
            'OKボタンがクリックされたとき
            excelCrater.Create(fileName,
                                "総合テスト問別分析結果",
                                _htSearchKeyFirstPage,
                                CType(dgvSynthesisQuestionAnalysis.DataSource, DataTable).DefaultView.ToTable(True, {"SHOWNO",
                                                                                                                QUESTIONCODE.Name,
                                                                                                                CATEGORY1.Name,
                                                                                                                CATEGORY2.Name,
                                                                                                                THEME.Name,
                                                                                                                "ERRATA_NUM",
                                                                                                                SELECT1.Name,
                                                                                                                SELECT2.Name,
                                                                                                                SELECT3.Name,
                                                                                                                SELECT4.Name,
                                                                                                                SELECT5.Name,
                                                                                                                SELECTNULL.Name,
                                                                                                                "CORRECTANSWER"}),
                                _htSearchKeySecondPage,
                               63, 36, 47, 16, False)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

End Class