''' <summary>
''' コース登録/確認
''' </summary>
''' <remarks>
''' 2012/03/28 NAKAMURA 新規作成
''' </remarks>
Public Class frmCourse

#Region "メンバ変数"

    ''' <summary>
    ''' 中問問題群
    ''' </summary>
    Private _MiddleCollection As DataTable

    ''' <summary>
    ''' 小問問題群
    ''' </summary>
    Private _MiniCollection As DataTable

    ' ''' <summary>
    ' ''' コース名
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly CST_COURSE_STATE As String() = {"利用終了", "利用中", "準備中"}

    ''' <summary>
    ''' データバンカー
    ''' </summary>
    ''' <remarks></remarks>
    Private DataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

    ''' <summary>
    ''' カテゴリテーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private CategoryTable As New DataTable

    ''' <summary>
    ''' 演習問題一覧テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private PracticeQuestionListTable As New DataTable

    ''' <summary>
    ''' 問題群一覧テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private CollectionTable As New DataTable

    ''' <summary>
    ''' グループテーブル（複数ファイル）
    ''' </summary>
    ''' <remarks></remarks>
    Private GroupTable As New DataTable

    ''' <summary>
    ''' 模擬テスト一覧テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private QuestionListTable As New DataTable

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "イベントハンドラ"

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>初期処理を行う。</remarks>
    Private Sub frmCourse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            '初期処理
            init()
            'オーナー非表示
            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessage = False
        End Try
    End Sub

    ''' <summary>
    ''' 更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' コース一覧の更新を行う。
    ''' 変更がある場合、必須チェック、重複チェックを行う。
    ''' </remarks>
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            logger.Start()
            '入力チェック
            If inputCheck() Then
                '更新処理
                saveCourse()

                'コース再表示
                dgvCourseList.DataSource = setCourse()
                dgvCourseList.DataSource.AcceptChanges()

                '画面クリア
                setInit()

            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessageUpload = False
        End Try
    End Sub

    ''' <summary>
    ''' コース新規登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' コースを新規登録する。
    ''' 演習問題群を登録する場合は演習問題群登録メニューを表示する。
    ''' </remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            logger.Start()
            Dim msgFlg As Boolean = False
            Dim CollectionNo As String = String.Empty
            '入力チェック
            If Not NewCourseCheck() Then
                Exit Sub
            End If

            If rdbNew.Checked = True Or rdbCopy.Checked = True Then

                If rdbNew.Checked = True Then
                    '新問題群準備
                    initCollection()
                ElseIf rdbCopy.Checked = True Then
                    '問題群準備コピー
                    copyCollection(cmbCourse.DataSource.rows(cmbCourse.SelectedIndex).item("COURSENO"))
                End If

                'コースを渡す
                DataBanker("Course") = txtCourseNo.Text.Trim

                '新規、演習問題群登録メニューへ
                Dim frm As New frmCollectionMenu

                '演習問題群登録メニューへ
                frm.ShowDialog(Me)

                'ログアウト
                If frm.DialogResult = DialogResult.Cancel Then
                    Me.Close()
                    Exit Sub
                Else
                    '登録判定
                    If DataBanker("CollectionInput") <> vbNo.ToString Then
                        'コース登録
                        insertCourse()
                        '画面表示
                        Show()
                        Refresh()
                        '登録完了メッセージ
                        msgFlg = True
                        'Common.Message.MessageShow("I001")
                    Else
                        '画面表示
                        Show()
                    End If
                End If
            Else
                '登録しますか？
                If Common.Message.MessageShow("Q001") <> DialogResult.OK Then
                    Exit Sub
                End If

                'コース登録
                insertCourse()

                '登録完了メッセージ
                msgFlg = True
                'Common.Message.MessageShow("I001")
            End If

            processMessage = True

            'コースコンボ設定
            setCourseCollection()

            'コース再表示
            dgvCourseList.DataSource = setCourse()

            '項目初期化
            setInit()

            If msgFlg Then
                processMessage = False
                'ファイルアップロード
                processMessageUpload = True
                If Not Common.DataManager.GetInstance.UpLoadFile() Then Exit Sub

                Common.Message.MessageShow("I001")
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessageUpload = False
            processMessage = False
        End Try
    End Sub

    ''' <summary>
    ''' システム管理画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackSystemManager.Click
        Try
            logger.Start()
            'システム管理画面に戻る
            Me.DialogResult = DialogResult.OK
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題群新規登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNew.CheckedChanged
        Try
            logger.Start()
            'コースコンボ使用設定
            setCourseEnabled()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題群登録しない
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbNon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNon.CheckedChanged
        Try
            logger.Start()
            'コースコンボ使用設定
            setCourseEnabled()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題群コピーチェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbCopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCopy.CheckedChanged
        Try
            logger.Start()
            'コースコンボ使用設定
            setCourseEnabled()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' テキスト項目を一回のクリックで編集開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvCourseList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCourseList.CellClick
        Try
            '1回のクリックでエディットモードにする処置  
            Dim dgv As DataGridView = TryCast(sender, DataGridView)

            If e.ColumnIndex >= 0 Then
                If TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn Then
                    SendKeys.Send("{F2}")
                End If
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' コンボボックスを一回のクリックで選択開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvCourseList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCourseList.CellEnter
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)

            If dgv.Columns(e.ColumnIndex).Name = "STATE" AndAlso _
                TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                SendKeys.Send("{F4}")
            End If
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case USESTART.Name, USEEND.Name
                    'この列は日本語入力ON
                    dgvCourseList.ImeMode = Windows.Forms.ImeMode.Disable
            End Select
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
    ''' <remarks>コース一覧及びコピー用のコースコンボを設定する。</remarks>
    Private Sub init()

        'グリッドレイアウト
        With dgvCourseList
            'ヘッダ名
            .Columns(.Columns(MINI.Name).Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns(.Columns(MIDDLE.Name).Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns(.Columns(TOTAL.Name).Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        dgvCourseList.AutoGenerateColumns = False
        Show()
        Refresh()
        processMessage = True
        '模擬テストコンボ設定
        cmbMockTest.DataSource = setMockTest()

        'コースコンボ設定
        setCourseCollection()

        'DataGridViewComboBoxColumnを作成
        Dim column As DataGridViewComboBoxColumn = dgvCourseList.Columns.Item(9)
        'ComboBoxのリストに表示する項目を指定する
        column.DataSource = setStateCmbData()
        column.ValueMember = "CODE"
        column.DisplayMember = "STATE"

        'コース表示
        dgvCourseList.DataSource = setCourse()
        dgvCourseList.DataSource.AcceptChanges()
        '項目クリア
        setInit()

    End Sub

    ''' <summary>
    ''' コースコンボ設定
    ''' </summary>
    ''' <remarks>コースの中から、演習問題群があるデータをコンボに設定する。</remarks>
    Private Sub setCourseCollection()
        Dim CourseDt As New DataTable
        Dim CmbDt As New DataTable
        CourseDt = getCourse()
        CmbDt = CourseDt.Clone
        For Each Row As DataRow In CourseDt.Select("COLLECTION = '1'") ' AND STATE NOT = '0'")
            CmbDt.ImportRow(Row)
        Next
        cmbCourse.DataSource = CmbDt
        If CmbDt.Rows.Count <= 0 Then
            Me.rdbCopy.Enabled = False
        Else
            Me.rdbCopy.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' 画面初期化
    ''' </summary>
    ''' <remarks>各項目クリア</remarks>
    Private Sub setInit()
        'コース名
        txtCourse.Clear()
        'コース№
        txtCourseNo.Clear()
        '模擬テストコンボ
        cmbMockTest.SelectedIndex = 0

        Dim Dt As DataTable
        Dt = getDispPracticeQuestionList()
        If Dt.Rows.Count > 0 Then
            '問題群、新規登録
            rdbNew.Checked = True
        Else
            '問題群、新規登録
            rdbNew.Enabled = False
            '問題群、登録しない
            rdbNon.Checked = True
        End If
        'コース№にフォーカス
        txtCourseNo.Focus()
        '更新ボタン
        btnEdit.Enabled = If(dgvCourseList.Rows.Count > 0, True, False)
    End Sub

    ''' <summary>
    ''' 問題群準備
    ''' </summary>
    ''' <remarks>演習問題一覧から、小問一覧、中問一覧を作成する。</remarks>
    Private Sub initCollection()

        '小問一覧設定
        DataBanker("SetMiniCollection") = SetMiniCollection()

        ''中問一覧設定
        DataBanker("SetMiddleCollection") = SetMiddleCollection()

    End Sub

    ''' <summary>
    ''' コース一覧取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>コースの情報を取得し、利用者数を設定する。</remarks>
    Private Function setCourse() As DataTable
        setCourse = Nothing
        Dim courseDt As New DataTable
        Dim TmpDt As New DataTable
        Dim KeyUserId(0) As DataColumn
        courseDt = getCourse()
        ''主キー設定
        KeyUserId(0) = courseDt.Columns("COURSENO")
        courseDt.PrimaryKey = KeyUserId

        For Each courseRow As DataRow In courseDt.Rows
            '問題数設定
            If courseRow.Item("COLLECTION") = "1" Then
                TmpDt = setCollectionRowData(courseRow.Item("COURSENO"))
                courseDt.Merge(TmpDt)
            End If
            '状態表示変更
            courseRow.Item("STATE") = setDispState(courseRow.Item("USESTART"), courseRow.Item("STATE"))
            '利用者数取得
            TmpDt = setUseNum(courseRow.Item("COURSENO"), courseRow.Item("STATE"))
            courseDt.Merge(TmpDt)
        Next

        Return courseDt
    End Function

    ''' <summary>
    ''' 問題群コピー
    ''' </summary>
    ''' <param name="SourceNo"></param>
    ''' <remarks>元となる問題群をコピーし、コース№を振りなおす。</remarks>
    Private Sub copyCollection(ByVal sourceNo As String)
        Dim sourceCollectionDt As New DataTable

        Dim miniCollectionDt As New DataTable
        Dim middleCollectionDt As New DataTable

        '小問一覧設定
        miniCollectionDt = SetMiniCollection()

        '中問一覧設定
        middleCollectionDt = SetMiddleCollection()

        '問題群取得
        sourceCollectionDt = getCollection(sourceNo)
        Dim KeyUserId(0) As DataColumn
        '主キー設定
        KeyUserId(0) = sourceCollectionDt.Columns("QUESTIONCODE")
        sourceCollectionDt.PrimaryKey = KeyUserId

        Dim Num As Integer = 0
        '小問抽出
        For Each row As DataRow In miniCollectionDt.Rows
            Num = sourceCollectionDt.Compute("COUNT(QUESTIONCODE)", "QUESTIONCODE = '" & row.Item("QUESTIONCODE") & "'")
            If Num > 0 Then
                row.Item("CHECK") = True
            End If
        Next

        '小問一覧設定
        DataBanker("SetMiniCollection") = miniCollectionDt

        '中問抽出
        For Each row As DataRow In middleCollectionDt.Rows
            Num = sourceCollectionDt.Compute("COUNT(QUESTIONCODE)", "QUESTIONCODE = '" & row.Item("QUESTIONCODE") & "'")
            If Num > 0 Then
                row.Item("CHECK") = True
            End If
        Next

        ''中問一覧設定
        DataBanker("SetMiddleCollection") = middleCollectionDt
    End Sub

    ''' <summary>
    ''' コース更新、入力チェック
    ''' </summary>
    ''' <returns>False：エラー有り</returns>
    ''' <remarks>コース一覧のチェック及びコースの更新処理を行う。</remarks>
    Private Function inputCheck() As Boolean
        inputCheck = False
        Dim msgId As String = "Q001"
        Dim QuestionListDt As New DataTable
        Dim flg As Boolean = False

        '模擬テスト一覧取得
        QuestionListDt = getQuestionList()

        For Each Row As DataGridViewRow In dgvCourseList.Rows
            '変更が有った行について処理を行う。
            If CType(Row.DataBoundItem, DataRowView).Row.RowState <> DataRowState.Unchanged Then
                flg = True
                '利用開始日
                If Row.Cells("USESTART").Value <> String.Empty AndAlso checkDate((Row.Cells("USESTART").Value)) = False Then
                    '
                    Common.Message.MessageShow("E007", {"利用開始日"})
                    Return False
                End If
                '利用終了日
                If Row.Cells("USEEND").Value <> String.Empty AndAlso checkDate((Row.Cells("USEEND").Value)) = False Then
                    '
                    Common.Message.MessageShow("E007", {"利用終了日"})
                    Return False
                End If
                '受験期間大小チェック
                If Row.Cells("USESTART").Value <> String.Empty And Row.Cells("USEEND").Value <> String.Empty AndAlso
                    Date.Parse(Row.Cells("USESTART").Value) > Date.Parse(Row.Cells("USEEND").Value) Then
                    Common.Message.MessageShow("E010")
                    Return False
                End If

                '団体の利用期間とコースの利用期間チェック
                Dim minStart As String
                Dim maxEnd As String
                GroupTable.DefaultView.RowFilter = "COURSENO = '" & CType(Row.DataBoundItem.Row, DataRow).Item(Common.Course.ColumnIndex.CourseNo) & "'"
                If GroupTable.DefaultView.Count > 0 Then
                    GroupTable.DefaultView.Sort = "TESTSTART ASC"
                    minStart = GroupTable.DefaultView.ToTable.Rows(0).Item(Common.Group.ColumnIndex.TestStart)
                    GroupTable.DefaultView.Sort = "TESTEND DESC"
                    maxEnd = GroupTable.DefaultView.ToTable.Rows(0).Item(Common.Group.ColumnIndex.TestEnd)

                    If Not SystemManager.InputCheck.withinPeriodCheck(Row.Cells("USESTART").Value, Row.Cells("USEEND").Value,
                                                                  minStart, maxEnd) Then
                        Common.Message.MessageShow("E080")
                        Return False
                    End If
                End If

                '利用状態、利用中
                If getStateCode(Row.Cells("STATE").FormattedValue) = "1" Then
                    If Row.Cells("USESTART").Value = String.Empty Then
                        '
                        Common.Message.MessageShow("E005", {"利用開始日"})
                        Return False
                    Else
                        If Row.Cells("USEEND").Value = String.Empty Then
                            '
                            Common.Message.MessageShow("E005", {"利用終了日"})
                            Return False
                        End If
                    End If
                End If

                '利用状態、利用中、準備中
                If getStateCode(Row.Cells("STATE").FormattedValue) = "1" Or getStateCode(Row.Cells("STATE").FormattedValue) = "2" Then
                    If Row.Cells("USESTART").Value <> String.Empty And Row.Cells("USEEND").Value <> String.Empty Then
                        '模擬テスト存在
                        Dim num As Integer
                        Dim where As String
                        where = "MOCKTESTNO = '" & getTestCode(Row.Cells("MOCKTESTNO").Value) & "'"
                        where += " AND USESTART <= '" & Row.Cells("USESTART").Value & "' AND USEEND >= '" & Row.Cells("USEEND").Value & "'"
                        where += " AND STATE<= '0'"
                        num = QuestionListDt.Compute("COUNT(MOCKTESTNO)", where)
                        If num <= 0 Then
                            Common.Message.MessageShow("E062")
                            Return False
                        End If
                    End If
                End If
                If getStateCode(Row.Cells("STATE").FormattedValue) = "0" Then
                    '利用停止、利用者数
                    If Row.Cells("STUDENTCOUNT").Value <> String.Empty AndAlso Row.Cells("STUDENTCOUNT").Value <> "0" Then
                        '登録しますか？
                        msgId = "Q010"
                    End If
                End If
            End If
        Next
        If flg Then
            '登録しますか？
            If Common.Message.MessageShow(msgId) <> DialogResult.OK Then
                Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' コース更新
    ''' </summary>
    ''' <remarks>コース一覧に変更があったコースのチェック処理及びコースの更新を行う。</remarks>
    Private Function saveCourse() As Boolean
        saveCourse = False
        Dim fileName As String = Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML
        Dim NewCourse As New DataTable
        Dim OldCourse As New DataTable
        Dim Idx As Integer = 0
        Dim Flg As Boolean = False

        '変更が有った行について処理を行う。
        For Each Row As DataGridViewRow In dgvCourseList.Rows
            If CType(Row.DataBoundItem, DataRowView).Row.RowState <> DataRowState.Unchanged Then
                Flg = True
            End If
        Next

        '元コース
        OldCourse = getCourse()

        Common.XmlSchema.GetCourseSchema(NewCourse)
        'Dim NewRow As DataRow

        For Each Row As DataGridViewRow In dgvCourseList.Rows
            '変更が発生している行
            If CType(Row.DataBoundItem, DataRowView).Row.RowState <> DataRowState.Unchanged Then
                NewCourse.ImportRow(Row.DataBoundItem.row)
                Idx = NewCourse.Rows.Count - 1
                With NewCourse.Rows(Idx)
                    .Item("MOCKTESTNO") = getTestCode(Row.Cells("MOCKTESTNO").Value)
                    .Item("STATE") = getStateCode(Row.Cells("STATE").FormattedValue)
                    .Item("UPDATE_DATE") = Format(Date.Now, "yyyy/MM/dd HH:mm:dd")
                End With
            Else
                Dim InRows As DataRow() = OldCourse.Select("COURSENO = '" & Row.Cells("COURSENO").Value & "'")
                For Each IRow As DataRow In InRows
                    NewCourse.ImportRow(IRow)
                Next
            End If
        Next
        dgvCourseList.DataSource.AcceptChanges()
        Common.Serialize.DataTableToxml(NewCourse, fileName)

        'ファイル更新
        processMessageUpload = True
        If Not Common.DataManager.GetInstance.UpLoadFile Then Exit Function

        '更新完了メッセージ
        Common.Message.MessageShow("I001")
        processMessageOutput = False
    End Function

    ''' <summary>
    ''' コース追加、入力チェック
    ''' </summary>
    ''' <returns>False：エラー有り</returns>
    ''' <remarks>新規コースの必須チェック、重複チェックを行う。</remarks>
    Private Function NewCourseCheck() As Boolean
        NewCourseCheck = False

        '必須チェック
        'コース番号
        If Me.txtCourseNo.Text = String.Empty Then
            Common.Message.MessageShow("E005", {"コース番号"})
            Return False
        End If
        'コース名
        If Me.txtCourse.Text = String.Empty Then
            Common.Message.MessageShow("E005", {"コース名"})
            Return False
        End If

        '英数チェック
        If CBTCommon.Utility.IsHalfAlphaNum(txtCourseNo.Text) = False Then
            Common.Message.MessageShow("E036", {"コース番号"})
            Return False
        End If

        '重複チェック
        'コース番号、コース名
        Dim Course As DataTable = getCourse()

        Dim selectString As String = "COURSENO= '" & txtCourseNo.Text.Trim & "'"
        Dim foundDataRow() As DataRow = Course.Select(selectString)
        For Each dr As DataRow In foundDataRow
            Common.Message.MessageShow("E049", {"入力された コース番号", ""})
            Return False
        Next
        selectString = "COURSE = '" & setSingleQuotationMark(txtCourse.Text.Trim) & "'"
        foundDataRow = Course.Select(selectString)
        For Each dr As DataRow In foundDataRow
            Common.Message.MessageShow("E049", {"入力された コース名", ""})
            Return False
        Next
        'コース名

        Return True
    End Function

    ''' <summary>
    ''' コースコンボ使用設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setCourseEnabled()

        If rdbCopy.Checked Then
            cmbCourse.Enabled = True
        Else
            cmbCourse.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' コース追加
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insertCourse() As Boolean
        insertCourse = True

        Dim fileName As String = Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML
        Dim Course As New DataTable

        '読み込み
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            Course = Common.Serialize.XmlToDataTable(fileName)
        Else
            Common.XmlSchema.GetCourseSchema(Course)
        End If

        '
        Dim NewDt As DataTable
        NewDt = Course.Clone
        NewDt.Rows.Add()
        With NewDt.Rows(0)

            .Item("COURSENO") = txtCourseNo.Text.Trim
            .Item("COURSE") = txtCourse.Text.Trim
            .Item("MOCKTESTNO") = cmbMockTest.SelectedItem("CODE")
            .Item("COLLECTION") = If(rdbNon.Checked, "0", DataBanker("Collection"))
            .Item("USESTART") = String.Empty
            .Item("USEEND") = String.Empty
            .Item("STATE") = "2"
            .Item("CREATE_DATE") = Format(Date.Now, "yyyy/MM/dd HH:mm:dd")
            .Item("UPDATE_DATE") = Format(Date.Now, "yyyy/MM/dd HH:mm:dd")
        End With
        Course.ImportRow(NewDt.Rows(0))

        Common.Serialize.DataTableToxml(Course, fileName)

    End Function

    ''' <summary>
    ''' コース情報取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCourse() As DataTable
        Dim fileName As String = Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML
        Dim CourseDt As New DataTable

        If Not System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            Common.XmlSchema.GetCourseSchema(CourseDt)
            Return CourseDt
        End If
        'コース取得
        CourseDt = Common.Serialize.XmlToDataTable(Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML)
        CourseDt.Columns.Add("MOCKTESTNONAME", GetType(String), "IIF(MOCKTESTNO = '1','" & Common.Constant.CST_COURSE(1) & "',IIF(MOCKTESTNO = '2','" & Common.Constant.CST_COURSE(2) & "',IIF(MOCKTESTNO = '3','" & Common.Constant.CST_COURSE(3) & "','')))")
        Return CourseDt
    End Function

    ''' <summary>
    ''' 日付の妥当性チェック
    ''' </summary>
    ''' <param name="strDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkDate(ByVal strDate As String) As Boolean
        checkDate = False
        If IsDate(strDate) Then
            Dim mc = System.Text.RegularExpressions.Regex.Match(strDate, "^[0-9]{4}/[0-9]{2}/[0-9]{2}$")
            If mc.Value <> "" Then
                Return True
            End If
        End If
    End Function

    ''' <summary>
    ''' 状態コード取得
    ''' </summary>
    ''' <param name="State"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getStateCode(ByVal State As String) As String
        getStateCode = "0"
        For I As Integer = 0 To Common.Constant.CST_COURSE_STATE.Length
            If Common.Constant.CST_COURSE_STATE(I) = State Then
                Return I.ToString
            End If
        Next
    End Function

    ''' <summary>
    ''' 模擬テストコード設定
    ''' </summary>
    ''' <param name="Test"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getTestCode(ByVal Test As String) As String
        getTestCode = String.Empty
        For I As Integer = 0 To Common.Constant.CST_COURSE.Length
            If Common.Constant.CST_COURSE(I) = Test Then
                Return I.ToString
            End If
        Next
    End Function

    ''' <summary>
    ''' テスト名設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setMockTest() As DataTable
        setMockTest = Nothing
        Dim Dt As New DataTable
        Dim Column As New DataColumn
        Column.ColumnName = "CODE"
        Dt.Columns.Add(Column)
        Dim ColumnName As New DataColumn
        ColumnName.ColumnName = "NAME"
        Dt.Columns.Add(ColumnName)
        For i As Integer = 1 To 3
            Dt.Rows.Add()
            Dt.Rows(i - 1).Item("CODE") = i.ToString
            Dt.Rows(i - 1).Item("NAME") = Common.Constant.CST_COURSE(i)
        Next
        Return Dt
    End Function

    ''' <summary>
    ''' 状態コンボ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setStateCmbData() As DataTable
        setStateCmbData = Nothing
        Dim Dt As New DataTable
        Dim Column As New DataColumn
        Column.ColumnName = "CODE"
        Dt.Columns.Add(Column)
        Dim ColumnName As New DataColumn
        ColumnName.ColumnName = "STATE"
        Dt.Columns.Add(ColumnName)
        For i As Integer = 0 To 2
            Dt.Rows.Add()
            Dt.Rows(i).Item("CODE") = i.ToString
            Dt.Rows(i).Item("STATE") = Common.Constant.CST_COURSE_STATE(i)
        Next
        Return Dt
    End Function

    ''' <summary>
    ''' 指定問題群取得
    ''' </summary>
    ''' <param name="Code"></param>
    ''' <returns></returns>
    ''' <remarks>問題群を取得、演習問題一覧と連結して。</remarks>
    Private Function getCollectionNo(ByVal Code As String) As DataTable
        getCollectionNo = Nothing
        Dim FileName As String = Common.Constant.CST_COLLECTION_FILENAME & Code & Common.Constant.CST_EXTENSION_XML
        Dim CollectionDt As New DataTable
        Dim PracticeQuestinListDt As New DataTable
        Dim KeyUserId(0) As DataColumn

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            CollectionDt = Common.Serialize.XmlToDataTable(FileName)
            ''主キー設定
            KeyUserId(0) = CollectionDt.Columns("QUESTIONCODE")
            CollectionDt.PrimaryKey = KeyUserId

            '演習問題一覧
            PracticeQuestinListDt = Common.PracticeQuestionList.GetAll(Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
            ''主キー設定
            KeyUserId(0) = PracticeQuestinListDt.Columns("QUESTIONCODE")
            PracticeQuestinListDt.PrimaryKey = KeyUserId

            'マージ
            CollectionDt.Merge(PracticeQuestinListDt)
        Else
            Return Nothing
        End If

        Return CollectionDt
    End Function

    ''' <summary>
    ''' 問題数取得
    ''' </summary>
    ''' <param name="CourseNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setCollectionRowData(ByVal courseNo As String) As DataTable
        setCollectionRowData = Nothing
        '項目追加
        Dim Dt As New DataTable
        Dim Course As New DataColumn
        Course.ColumnName = "COURSENO"
        Dt.Columns.Add(Course)
        Dim Mini As New DataColumn
        Mini.ColumnName = "MINI"
        Dt.Columns.Add(Mini)
        Dim Middle As New DataColumn
        Middle.ColumnName = "MIDDLE"
        Dt.Columns.Add(Middle)
        Dim Total As New DataColumn
        Total.ColumnName = "TOTAL"
        Dt.Columns.Add(Total)

        Dim MiniNum As Integer = 0
        Dim MiddleNum As Integer = 0
        Dim TotalNum As Integer = 0

        '問題群取得
        Dim CollectionDt As New DataTable
        CollectionDt = getCollectionNo(courseNo)
        If Not IsNothing(CollectionDt) Then
            MiniNum = CollectionDt.Compute("Count(QUESTIONCODE)", "COURSENO = '" & courseNo & "' AND QUESTIONCLASS = '1'")
            MiddleNum = CollectionDt.Compute("Count(QUESTIONCODE)", "COURSENO = '" & courseNo & "' AND QUESTIONCLASS = '2' AND MAINCODE = QUESTIONCODE")
            TotalNum = MiniNum + (MiddleNum * 4)
        End If

        Dt.Rows.Add()
        With Dt.Rows(0)
            .Item("COURSENO") = courseNo
            .Item("MINI") = MiniNum.ToString
            .Item("MIDDLE") = MiddleNum.ToString
            .Item("TOTAL") = TotalNum.ToString
        End With

        Return Dt
    End Function

    ''' <summary>
    ''' 問題群取得
    ''' </summary>
    ''' <param name="CourseNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCollection(ByVal CourseNo As String) As DataTable
        getCollection = Nothing
        Dim CollectionName As String = Common.Constant.CST_COLLECTION_FILENAME & CourseNo & Common.Constant.CST_EXTENSION_XML
        Return Common.Serialize.XmlToDataTable(CollectionName)
    End Function

    ''' <summary>
    ''' 演習問題群(小問）設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>演習問題を取得し、演習問題一覧（小問）を作成する</remarks>
    Private Function SetMiniCollection() As DataTable
        SetMiniCollection = Nothing

        Dim Dt As New DataTable
        Dt = getPracticeQuestionList()

        '項目追加
        '選択
        If Not Dt.Columns.Contains("CHECK") Then
            Dim Check As New DataColumn
            Check.ColumnName = "CHECK"
            Check.DataType = GetType(Integer)
            Dt.Columns.Add(Check)
        End If

        '小問抽出
        Dim MiniCollection As New DataTable
        MiniCollection = Dt.Clone
        For Each Row As DataRow In Dt.Rows
            If Row.Item("QUESTIONCLASS") = "1" And Row.Item(Common.PracticeQuestionList.ColumnIndex.State) = "0" Then
                Row.Item("CHECK") = False
                MiniCollection.ImportRow(Row)
            End If
        Next
        Return MiniCollection
    End Function

    ''' <summary>
    ''' 演習問題群(中問）設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>演習問題を取得し、演習問題一覧（中問）を作成する</remarks>
    Private Function SetMiddleCollection() As DataTable
        SetMiddleCollection = Nothing
        Dim Dt As New DataTable
        Dt = getPracticeQuestionList()

        '項目追加
        '選択
        If Not Dt.Columns.Contains("CHECK") Then
            Dim Check As New DataColumn
            Check.ColumnName = "CHECK"
            Check.DataType = GetType(Integer)
            Dt.Columns.Add(Check)
        End If
        '中問抽出
        Dim MiddleCollection As New DataTable
        MiddleCollection = Dt.Clone
        For Each Row As DataRow In Dt.Rows
            If Row.Item("QUESTIONCLASS") = "2" And Row.Item(Common.PracticeQuestionList.ColumnIndex.State) = "0" Then
                Row.Item("CHECK") = False
                MiddleCollection.ImportRow(Row)
            End If
        Next
        Return MiddleCollection

    End Function

    ''' <summary>
    ''' 演習問題一覧取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>演習問題を取得し、カテゴリーテーブルからグループ名を付加する</remarks>
    Private Function getPracticeQuestionList() As DataTable
        getPracticeQuestionList = Nothing
        '
        '取得済か
        If CollectionTable.Rows.Count <> 0 Then
            Return CollectionTable
        End If

        Dim PracticeQuestionList As New DataTable
        PracticeQuestionList = getDispPracticeQuestionList()
        'グループ名項目追加
        If Not PracticeQuestionList.Columns.Contains("GROUP") Then
            Dim Group As New DataColumn
            Group.ColumnName = "GROUP"
            PracticeQuestionList.Columns.Add(Group)
        End If

        CollectionTable = PracticeQuestionList.Clone
        For Each Row As DataRow In PracticeQuestionList.Select("STATE = '0'")
            If Not IsDBNull(Row.Item("CATEGORYID")) Then
                'グループ名項目追加
                Row.Item("GROUP") = getGroupName(Row.Item("CATEGORYID"))
                If Not IsDBNull(Row.Item("QUESTIONCODE")) Then CollectionTable.ImportRow(Row)
            End If
        Next

        Return CollectionTable
    End Function

    ''' <summary>
    ''' 表示用演習問題一覧取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getDispPracticeQuestionList() As DataTable
        getDispPracticeQuestionList = Nothing
        '
        Dim fileName As String = Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If PracticeQuestionListTable.Rows.Count <> 0 Then
            Return PracticeQuestionListTable
        End If
        '演習問題取得
        Common.XmlSchema.GetPracticeQuestionListSchema(PracticeQuestionListTable)
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            PracticeQuestionListTable = Common.Serialize.XmlToDataTable(fileName)
        End If
        '
        Dim Rows As DataRow()
        '親カテゴリーID
        '項目追加
        If Not PracticeQuestionListTable.Columns.Contains("PARENTCATEGORYID") Then
            Dim ParentCategoryID As New DataColumn
            ParentCategoryID.ColumnName = "PARENTCATEGORYID"
            PracticeQuestionListTable.Columns.Add(ParentCategoryID)
        End If
        '親表示用ID
        If Not PracticeQuestionListTable.Columns.Contains("PARENTDISPLAYID") Then
            Dim ParentCategoryID As New DataColumn
            ParentCategoryID.ColumnName = "PARENTDISPLAYID"
            PracticeQuestionListTable.Columns.Add(ParentCategoryID)
        End If
        'カテゴリ取得
        Dim categoryTable As New DataTable
        categoryTable = getCategory()
        For Each Row As DataRow In PracticeQuestionListTable.Rows
            Rows = categoryTable.Select("DISPLAYID = '" & Row.Item("CATEGORYID") & "'")
            If Rows.Length = 1 Then
                Row.Item("PARENTCATEGORYID") = Rows(0).Item("PARENTCATEGORYID")
                Rows = categoryTable.Select("CATEGORYID = '" & Row.Item("PARENTCATEGORYID") & "'")
                If Rows.Length = 1 Then Row.Item("PARENTDISPLAYID") = Rows(0).Item("DISPLAYID")
            End If
        Next

        Return PracticeQuestionListTable
    End Function

    ''' <summary>
    ''' カテゴリーテーブル取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCategory() As DataTable
        Dim fileName As String = Common.Constant.CST_CATEGORY_FILENAME & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If CategoryTable.Rows.Count <> 0 Then
            Return CategoryTable
        End If
        '取得
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            CategoryTable = Common.Serialize.XmlToDataTable(Common.Constant.CST_CATEGORY_FILENAME & Common.Constant.CST_EXTENSION_XML)
        End If

        Return CategoryTable
    End Function

    ''' <summary>
    ''' 模擬テスト一覧
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getQuestionList() As DataTable
        Dim fileName As String = Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If QuestionListTable.Rows.Count <> 0 Then
            Return QuestionListTable
        End If
        Common.XmlSchema.GetQuestionListSchema(QuestionListTable)
        '取得
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            QuestionListTable = Common.Serialize.XmlToDataTable(fileName)
        End If

        Return QuestionListTable
    End Function

    ''' <summary>
    ''' 名称取得
    ''' </summary>
    ''' <param name="categoryId"></param>
    ''' <returns></returns>
    ''' <remarks>カテゴリーIDからカテゴリー名を取得する</remarks>
    Private Function getGroupName(ByVal categoryId As String) As String
        getGroupName = Nothing
        Dim categoryDt As New DataTable
        categoryDt = getCategory()
        Dim Rows As DataRow() = categoryDt.Select("DISPLAYID = '" & categoryId & "'")

        If Rows.Length = 0 OrElse IsDBNull(Rows(0).Item("CATEGORYNAME")) Then
            Return String.Empty
        End If
        Return Rows(0).Item("CATEGORYNAME")
    End Function

    ''' <summary>
    ''' 利用者数
    ''' </summary>
    ''' <param name="courseNo"></param>
    ''' <param name="state"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setUseNum(ByVal courseNo As String, ByVal state As String) As DataTable
        setUseNum = Nothing
        '戻りテーブル
        Dim RetDt As New DataTable
        'コース№
        Dim CourseNoCol As New DataColumn
        CourseNoCol.ColumnName = "COURSENO"
        RetDt.Columns.Add(CourseNoCol)
        '利用者数
        Dim StudentCount As New DataColumn
        StudentCount.ColumnName = "STUDENTCOUNT"
        RetDt.Columns.Add(StudentCount)

        '状態　0：利用終了
        If state = "0" Then
            RetDt.Rows.Add()
            With RetDt.Rows(0)
                .Item("COURSENO") = courseNo
                .Item("STUDENTCOUNT") = 0
            End With
            Return RetDt
        End If

        'グループ取得
        Dim GroupDt As New DataTable
        GroupDt = getGroup()

        Dim Sum As Integer = 0
        Dim where As String = "COURSENO = '" & courseNo & "'"
        where += " AND STATE NOT = '" & Common.Constant.CST_STATE(3) & "'"
        where += " AND TESTSTART <= '" & Date.Now.ToString("yyyy/MM/dd") & "' AND TESTEND >= '" & Date.Now.ToString("yyyy/MM/dd") & "'"
        Dim tmpSum As Object = GroupDt.Compute("SUM(STUDENTCOUNT_NUM)", where)
        Sum = If(IsDBNull(tmpSum), 0, CInt(tmpSum))

        RetDt.Rows.Add()
        With RetDt.Rows(0)
            .Item("COURSENO") = courseNo
            .Item("STUDENTCOUNT") = Sum.ToString
        End With

        Return RetDt
    End Function

    ''' <summary>
    ''' 団体ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getGroup() As DataTable
        Dim FileName As String = Common.Constant.CST_GROUP_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If GroupTable.Rows.Count <> 0 Then
            Return GroupTable
        End If
        For Each FileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, FileName)
            GroupTable.Merge(Common.Serialize.XmlToDataTable(IO.Path.GetFileName(FileName)))
        Next
        If GroupTable.Rows.Count = 0 Then
            Common.XmlSchema.GetGroupSchema(GroupTable)
        End If
        If Not GroupTable.Columns.Contains("STUDENTCOUNT_NUM") Then
            GroupTable.Columns.Add("STUDENTCOUNT_NUM", GetType(Integer), "Convert(STUDENTCOUNT, 'System.Int32')")
        End If
        Return GroupTable
    End Function

    ''' <summary>
    ''' 状態の表示設定
    ''' </summary>
    ''' <param name="usestart"></param>
    ''' <param name="state"></param>
    ''' <returns></returns>
    ''' <remarks>準備中かつ利用開始日過ぎていたら、利用中にする。</remarks>
    Private Function setDispState(ByVal usestart As String, ByVal state As String) As String
        setDispState = state
        Dim nowDay As String = Format(Date.Now, "yyyy/MM/dd")
        If usestart <> String.Empty AndAlso usestart <= nowDay And state = "2" Then
            Return "1"
        End If
    End Function

    ''' <summary>
    ''' シングルクォーテーション対応
    ''' </summary>
    ''' <param name="selectString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setSingleQuotationMark(ByVal selectString As String) As String
        setSingleQuotationMark = Nothing
        Dim tmpArray As Array
        tmpArray = selectString.Split("'")
        Return String.Join("''", tmpArray)
    End Function
#End Region

End Class