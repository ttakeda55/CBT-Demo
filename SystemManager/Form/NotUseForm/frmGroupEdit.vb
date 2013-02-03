Imports System.IO

Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
''' <summary>
''' 団体情報更新修正(TG04)<br/>
''' <img src="..\Images\TG04.png" />
''' </summary>
''' <remarks>
''' 2011/09/05 NOZAO 新規作成
''' </remarks>
Public Class frmGroupEdit

#Region "メンバ変数"
    Private dtGroup As New DataTable
    Private cellValue As String = String.Empty
    Private beforeRowState As New DataRowState
    Private tempDirectry As String = Common.Constant.GetTempPath & "GroupEditTemp\"

    ' ''' <summary>
    ' ''' すべて
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly CST_ALL As String = "すべて"

    ' ''' <summary>
    ' ''' 状態
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Shared ReadOnly CST_STATE As String() = {CST_ALL, "稼働準備中", "稼働中", "稼働停止"}

    ''' <summary>
    ''' コーステーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private CourseTable As New DataTable
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
            Me.Text = "団体情報更新修正"
            Me.lblBottomCode.Text = "TG10"
            Me.lblBottomName.Text = "団体情報修正画面"

            'ファイルダウンロード
            processMessageDownload = True
            If Not DataManager.GetInstance.DownLoadFile Then
                Me.DialogResult = DialogResult.OK
                Close()
            End If

            'コンボ設定
            setdgvGroupListCombo()

            dgvGroupList.AutoGenerateColumns = False
            '団体情報をロードする
            loadGroup()

            '検索条件を設定
            If dtGroup.Rows.Count > 0 Then
                setSearchCondition(dtGroup)
            Else
                btnSearch.Enabled = False
            End If

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessageDownload = False
        End Try
    End Sub

    ''' <summary>
    ''' 検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()
            If checkRowState() Then
                loadGroup()
                searchData()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' システム管理者画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            logger.Start()
            If checkRowState() Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 団体管理画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackGroup.Click
        Try
            logger.Start()
            If checkRowState() Then
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
    ''' 運用停止ボタン押下
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'チェック
            If Not checkFlg() Then
                Exit Sub
            End If
            For Each r As DataGridViewRow In dgvGroupList.Rows
                If r.Cells(colCheck.Name).Value Then
                    r.DataBoundItem.row("STATE") = Common.Constant.CST_NEW_STATE(3)
                End If
            Next
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 全チェック処理
    ''' </summary>
    Private Sub btnCheckAllOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAllOn.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvGroupList.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                Me.dgvGroupList(0, i).Value = True
            Next
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 全チェック解除処理
    ''' </summary>
    Private Sub btnCheckAllOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAllOff.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvGroupList.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                Me.dgvGroupList(0, i).Value = False
            Next
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 運用再開ボタン押下
    ''' </summary>
    Private Sub btnReStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'チェック
            If Not checkFlg() Then
                Exit Sub
            End If

            For Each r In dgvGroupList.Rows
                If r.Cells(colCheck.Name).value Then
                    r.Cells(Me.colState.Name).value = Common.Constant.CST_NEW_STATE(2)
                End If
            Next
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' パスワード発行ボタン押下
    ''' </summary>
    Private Sub btnPassWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassWord.Click
        Try
            logger.Start()
            'チェック
            If Not checkFlg() Then
                Exit Sub
            End If
            Dim i As Integer = 0
            For Each r As DataGridViewRow In dgvGroupList.Rows
                If r.Cells(colCheck.Name).Value Then
                    r.DataBoundItem.row("PASSWORD") = Utility.GeneratePassword(8, Common.Constant.CST_PASSWORDCHARS & Common.Constant.CST_PASSWORDCHARS & Common.Constant.CST_PASSWORDCHARS)
                End If
                i += 10
            Next
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 更新修正ボタン押下
    ''' </summary>
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            logger.Start()
            'チェック
            If Not checkFlg() Then
                Exit Sub
            End If

            '入力チェック
            If inputCheck() = False Then
                Exit Sub
            End If

            '更新確認
            If Message.MessageShow("Q007") = DialogResult.Cancel Then
                Exit Sub
            End If

            '更新処理
            If upDateGroup() = False Then
                Exit Sub
            End If

            btnSearch_Click(sender, e)
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessageUpload = False
        End Try
    End Sub

    ''' <summary>
    ''' テキスト項目を一回のクリックで編集開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvGroupList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGroupList.CellClick
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
    Private Sub dgvGroupList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGroupList.CellEnter
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)
            If dgv.Columns(e.ColumnIndex).Name = Me.colCourseNo.Name Then
                Dim column As DataGridViewComboBoxColumn = dgvGroupList.Columns.Item(e.ColumnIndex)
                column.DataSource = addCourseCollection(dgvGroupList(e.ColumnIndex, e.RowIndex))
            End If
            If (dgv.Columns(e.ColumnIndex).Name = Me.colCourseNo.Name Or dgv.Columns(e.ColumnIndex).Name = Me.colState.Name) AndAlso _
                TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                SendKeys.Send("{F4}")
            End If
            '---- 列番号を調べて制御 ------
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case colGroupName.Name, colApplicant.Name, colGroupManagerName.Name
                    'この列は日本語入力ON
                    dgvGroupList.ImeMode = Windows.Forms.ImeMode.On
                Case Else
                    'この列はIME無効(半角英数のみ)
                    dgvGroupList.ImeMode = Windows.Forms.ImeMode.Disable
            End Select
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 編集後状態を保持
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvGroupList_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGroupList.CellEndEdit
        Try
            If Not dgvGroupList.CurrentCell.Value Is Nothing Then
                dgvGroupList.CurrentCell.Value = dgvGroupList.CurrentCell.Value.ToString.Trim
                Dim colName As String = dgvGroupList.Columns(dgvGroupList.CurrentCell.ColumnIndex).Name

                If colName = colGroupManagerId.Name Or _
                    colName = colTestStart.Name Or _
                    colName = colTestEnd.Name Or _
                    colName = colGroupManagerPassWord.Name Or _
                    colName = colStudentCount.Name Then
                    dgvGroupList.CurrentCell.Value = dgvGroupList.CurrentCell.Value.ToString.Replace(" ", "").Replace("　", "")
                End If
            End If

            If cellValue = dgvGroupList.CurrentCell.Value And beforeRowState = DataRowState.Unchanged Then
                CType(dgvGroupList.CurrentRow.DataBoundItem, DataRowView).Row.AcceptChanges()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 変数前状態を保持
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvGroupList_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvGroupList.CellBeginEdit
        Try
            If Not dgvGroupList.CurrentCell.Value Is Nothing Then
                cellValue = dgvGroupList.CurrentCell.Value.ToString
                beforeRowState = CType(dgvGroupList.CurrentRow.DataBoundItem, DataRowView).Row.RowState
            End If
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

    ''' <summary>
    ''' DataErrorイベントハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_DataError(ByVal sender As Object, _
            ByVal e As DataGridViewDataErrorEventArgs) _
            Handles dgvGroupList.DataError
        Try
            e.Cancel = False
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            logger.Start()
            'チェック
            If Not checkFlg() Then
                Exit Sub
            End If

            '入力チェック
            If delCheck() = False Then
                Exit Sub
            End If

            '削除処理
            If delDateGroup() = False Then
                Exit Sub
            End If

            btnSearch_Click(sender, e)
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessageUpload = False
        End Try
    End Sub

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Function upDateGroup() As Boolean
        upDateGroup = True
        'チェック
        If Not checkFlg() Then
            Return False
        End If

        '最新データ取得
        mekeTempDirectry()
        If Not DataManager.GetInstance.DownLoadFile(Common.Constant.CST_GROUP_FILENAME, tempDirectry) Then Return False

        For Each r As DataGridViewRow In dgvGroupList.Rows
            If r.Cells(colCheck.Name).Value Then
                If r.Cells(colGroupManagerPassWord.Name).Value = _
                     CType(r.DataBoundItem.row, DataRow).Item("OLDPASSWORD").ToString Then
                    loadNewPassWord(r)
                End If
                'コース項目
                r.Cells(colCourse.Name).Value = r.Cells(colCourseNo.Name).FormattedValue
                r.Cells(colStudentCount.Name).Value = CInt(r.Cells(colStudentCount.Name).Value)

                loadTestDate(r)
                updateGroupFile(r.DataBoundItem.row)
                processMessageUpload = True
                If Not DataManager.GetInstance.UpLoadFile() Then Return False

            End If
        Next

        dtGroup = dgvGroupList.DataSource
        dtGroup.AcceptChanges()
        dgvGroupList.DataSource = dtGroup

        Message.MessageShow("I004")
        loadGroup()
    End Function

    ''' <summary>
    ''' 新パスワード読み込み
    ''' </summary>
    ''' <param name="dgvr"></param>
    ''' <remarks></remarks>
    Private Sub loadNewPassWord(ByRef dgvr As DataGridViewRow)
        Dim dr As DataRow = CType(dgvr.DataBoundItem.row, DataRow)
        Dim fileName As String = tempDirectry & Common.Constant.CST_GROUP_FILENAME & dr.Item("GROUPCODE").ToString() & Common.Constant.CST_EXTENSION_XML
        Dim dt As New DataTable

        If IO.File.Exists(fileName) Then
            dt = Serialize.XmlToDataTableFullPath(fileName)
        End If

        If dt.Rows.Count > 0 Then
            If dgvr.Cells(colGroupManagerPassWord.Name).Value <> dt.Rows(0).Item("PASSWORD").ToString Then
                dgvr.Cells(colGroupManagerPassWord.Name).Value = dt.Rows(0).Item("PASSWORD").ToString
            End If
        End If

    End Sub

    ''' <summary>
    ''' チェックボックス確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkFlg() As Boolean
        checkFlg = False
        For i As Integer = 0 To dgvGroupList.RowCount - 1
            If Me.dgvGroupList(0, i).Value Then
                checkFlg = True
            End If
        Next
        If Not checkFlg Then
            Message.MessageShow("E011")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 検索処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub searchData()
        Dim filter As String = "1=1"
        Dim arrayBuf As Array
        Dim tmpOr As String = String.Empty

        '日付チェック
        If dtpTestStart.MaskCompleted = True And Not IsDate(dtpTestStart.Text) Then
            Common.Message.MessageShow("E007", {"利用開始日"})
            Return
        End If
        If dtpTestEnd.MaskCompleted = True And Not IsDate(dtpTestEnd.Text) Then
            Common.Message.MessageShow("E007", {"利用終了日"})
            Return
        End If
        If Not dtpTestStart.ToShortDateString = String.Empty And Not dtpTestEnd.ToShortDateString = String.Empty Then
            If dtpTestStart.ToShortDateString > dtpTestEnd.ToShortDateString Then
                Common.Message.MessageShow("E064")
            End If
        End If

        If Not cmbGroupCode.SelectedIndex = 0 Then
            filter += " AND GROUPCODE ='" & cmbGroupCode.Text & "'"
        End If
        If Not cmbCourse.SelectedIndex = 0 Then
            filter += " AND COURSENO ='" & cmbCourse.SelectedItem("COURSENO") & "'"
        End If
        If Not cmbState.SelectedIndex = 0 Then
            arrayBuf = cmbState.Items(cmbState.SelectedIndex).item("STATE").ToString.Split("／")
            If arrayBuf.Length = 1 Then
                filter += " AND STATE ='" & arrayBuf(0) & "'"
            Else
                filter += " AND ( "

                For Each tmp As String In arrayBuf
                    filter += tmpOr & " STATE ='" & tmp & "'"
                    tmpOr = " OR"
                Next
                filter += " ) "
            End If
        End If

        If Not dtpTestStart.ToShortDateString = String.Empty And Not dtpTestEnd.ToShortDateString = String.Empty Then
            filter += " AND (TESTSTART <='" & dtpTestEnd.ToShortDateString & "'"
            filter += " AND   TESTEND >='" & dtpTestStart.ToShortDateString & "')"
        ElseIf Not dtpTestStart.ToShortDateString = String.Empty And dtpTestEnd.ToShortDateString = String.Empty Then
            filter += " AND (TESTSTART <='" & dtpTestStart.ToShortDateString & "'"
            filter += " AND   TESTEND >='" & dtpTestStart.ToShortDateString & "')"
        ElseIf dtpTestStart.ToShortDateString = String.Empty And Not dtpTestEnd.ToShortDateString = String.Empty Then
            filter += " AND (TESTSTART <='" & dtpTestEnd.ToShortDateString & "'"
            filter += " AND   TESTEND >='" & dtpTestEnd.ToShortDateString & "')"
        End If

        Dim dt As DataTable = dgvGroupList.DataSource
        '項目追加
        '選択
        If Not dt.Columns.Contains("SHOW") Then
            Dim show As New DataColumn
            show.ColumnName = "SHOW"
            show.DataType = GetType(String)
            dt.Columns.Add(show)
        End If
        dt.DefaultView.RowFilter = filter
        If dt.DefaultView.Count > 0 Then
            '再描画対応
            filter = "1=1 AND ("
            For i As Integer = 0 To dt.DefaultView.Count - 1
                dt.DefaultView.Item(i).Row.Item("SHOW") = "1"
            Next
            filter = "1=1 AND SHOW = '1'"
        End If
        dt.DefaultView.RowFilter = filter
        dt.AcceptChanges()
    End Sub

    ''' <summary>
    ''' 団体ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadGroupFile() As DataTable
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_GROUP_FILENAME & "*")
            dt.Merge(Serialize.XmlToDataTable(IO.Path.GetFileName(fileName)))
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 受講者がテスト済みか
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkTestCount(ByVal groupCode As String) As Boolean
        checkTestCount = False
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_STUDENT_FILENAME & groupCode & "*")
            dt = Serialize.XmlToDataTable(IO.Path.GetFileName(fileName))
            Dim foundDataRow As DataRow() = dt.Select("TESTCOUNT > 0")
            If foundDataRow.Length > 0 Then
                Return True
            End If
        Next
    End Function

    ''' <summary>
    ''' 団体のDataTableを加工する
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub editDataTable(ByRef dt As DataTable)
        For Each r In dt.Rows
            '状態を設定
            If r("STATE") <> Common.Constant.CST_STATE(3) Then
                If Date.Parse(r("TESTSTART")) > Date.Now Then
                    r("STATE") = Common.Constant.CST_STATE(1)
                Else
                    r("STATE") = Common.Constant.CST_STATE(2)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' 検索情報を設定する
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub setSearchCondition(ByVal dt As DataTable)
        Dim group As New DataTable
        group = dt.Copy
        group = addComboBrankItem(group)

        'コンボボックス設定
        cmbGroupCode.DataSource = group
        cmbGroupName.DataSource = group
        cmbCourse.DataSource = setCourseCollection(True)
        cmbState.DataSource = setState(True)
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
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        inputCheck = True
        Dim dtGroupList As DataTable = CType(dgvGroupList.DataSource, DataTable)

        For Each r As DataGridViewRow In dgvGroupList.Rows
            If r.Cells(colCheck.Name).Value Then
                '必須チェック
                For i = 2 To 10
                    If Not i = 5 Then
                        If changeDbNull(r.Cells(i).Value) = "" Then
                            Message.MessageShow("E012", {dgvGroupList.Columns(i).HeaderText, r.Index + 1})
                            Return False
                        End If
                    Else
                        If changeDbNull(r.Cells(Me.colStudentCount.Name).Value) = "" Then
                            Message.MessageShow("E012", {dgvGroupList.Columns(Me.colStudentCount.Name).HeaderText, r.Index + 1})
                            Return False
                        End If
                        '数値チェック
                        If Not Utility.IsInteger(changeDbNull(r.Cells(Me.colStudentCount.Name).Value)) Then
                            Message.MessageShow("E013", {dgvGroupList.Columns(Me.colStudentCount.Name).HeaderText, r.Index + 1})
                            Return False
                        End If
                        If Not changeDbNull(r.Cells(Me.colStudentCount.Name).Value) > 0 Then
                            Message.MessageShow("E012", {dgvGroupList.Columns(Me.colStudentCount.Name).HeaderText, r.Index + 1})
                            Return False
                        End If
                    End If
                Next

                '受講数チェック
                Dim groupCode As String = CType(r.DataBoundItem.row, DataRow).Item(Common.Group.ColumnIndex.GroupCode)
                Dim groupStudentCount As String = CType(r.DataBoundItem.row, DataRow).Item(Common.Group.ColumnIndex.StudentCount)
                For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_STUDENT_FILENAME & groupCode & "*")
                    Dim dtStudent As New DataTable
                    dtStudent = Common.Group.GetAll(IO.Path.GetFileName(fileName))
                    If groupStudentCount < dtStudent.Rows.Count Then
                        Message.MessageShow("E072", {dgvGroupList.Columns(Me.colStudentCount.Name).HeaderText, r.Index + 1})
                        Return False
                    End If
                Next

                '日付チェック
                If checkDate(changeDbNull(r.Cells(Me.colTestStart.Name).Value)) = False Then
                    Message.MessageShow("E014", {dgvGroupList.Columns(Me.colTestStart.Name).HeaderText, r.Index + 1})
                    Return False
                End If
                If Utility.isHankaku(changeDbNull(r.Cells(Me.colTestStart.Name).Value)) = False Then
                    Message.MessageShow("E015", {dgvGroupList.Columns(Me.colTestStart.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                If checkDate(changeDbNull(r.Cells(Me.colTestEnd.Name).Value)) = False Then
                    Message.MessageShow("E014", {dgvGroupList.Columns(Me.colTestEnd.Name).HeaderText, r.Index + 1})
                    Return False
                End If
                If Utility.isHankaku(changeDbNull(r.Cells(Me.colTestEnd.Name).Value)) = False Then
                    Message.MessageShow("E015", {dgvGroupList.Columns(Me.colTestEnd.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                '利用終了日チェック
                If CheckEndDate(r.Cells(Me.colGroupCode.Name).Value, r.Cells(Me.colTestEnd.Name).Value) = False Then
                    Message.MessageShow("E068", {"利用終了日", "模擬テスト実施終了日より過去の日付"})
                    Return False
                End If

                '受験期間大小チェック
                If Date.Parse(changeDbNull(r.Cells(Me.colTestStart.Name).Value)) > Date.Parse(changeDbNull(r.Cells(Me.colTestEnd.Name).Value)) Then
                    Message.MessageShow("E016", {r.Index + 1})
                    Return False
                End If

                '利用期間とコースの利用期間チェック
                Dim useStart As Date
                Dim useEnd As Date
                getUseStartEnd(r.Cells(colCourseNo.Name).Value, useStart, useEnd)

                If Not SystemManager.InputCheck.withinPeriodCheck(useStart, useEnd,
                                                                  CDate(r.Cells(Me.colTestStart.Name).Value),
                                                                  CDate(r.Cells(Me.colTestEnd.Name).Value)) Then
                    Message.MessageShow("E079", {"（" & (r.Index + 1) & "行目）"})
                    Return False
                End If

                '団体の利用期間と受講者の受講期間チェック
                Dim minStart As String
                Dim maxEnd As String
                Dim student As DataTable = getStudent(r.Cells(colGroupCode.Name).Value)
                If student.DefaultView.Count > 0 Then
                    student.DefaultView.Sort = "STUDENTSSTART ASC"
                    minStart = student.DefaultView.ToTable.Rows(0).Item(Common.Student.ColumnIndex.StudentsStart)
                    student.DefaultView.Sort = "STUDENTSEND DESC"
                    maxEnd = student.DefaultView.ToTable.Rows(0).Item(Common.Student.ColumnIndex.StudentsEnd)

                    If Not SystemManager.InputCheck.withinPeriodCheck(CDate(r.Cells(Me.colTestStart.Name).Value),
                                                                      CDate(r.Cells(Me.colTestEnd.Name).Value),
                                                                      minStart, maxEnd) Then
                        Common.Message.MessageShow("E081", {vbCrLf & "（" & (r.Index + 1) & "行目）"})
                        Return False
                    End If
                End If

                '桁数チェック
                If changeDbNull(r.Cells(Me.colGroupManagerPassWord.Name).Value).ToString.Length < 6 Then
                    Message.MessageShow("E037", {dgvGroupList.Columns(Me.colGroupManagerPassWord.Name).HeaderText, r.Index + 1})
                    Return False
                End If
                'パスワード禁止文字チェック
                If Utility.IsNgChar(r.Cells(Me.colGroupManagerPassWord.Name).Value, Common.Constant.CST_PASSWORDCHARS_NG) Then
                    Dim chars As String = Common.Constant.CST_PASSWORDCHARS_NG
                    Dim str As String = ""
                    For Each chr As Char In chars
                        str &= "[" & chr.ToString & "]"
                    Next
                    Message.MessageShow("E050", {str})
                    Return False
                End If

                '半角英大文字チェック
                If Utility.IsUpperCase(r.Cells(Me.colGroupManagerPassWord.Name).Value) Then
                    Message.MessageShow("E051")
                    Return False
                End If

                '半角チェック
                If Utility.isHankaku(changeDbNull(r.Cells(Me.colGroupManagerId.Name).Value)) = False Then
                    Message.MessageShow("E015", {dgvGroupList.Columns(Me.colGroupManagerId.Name).HeaderText, r.Index + 1})
                    Return False
                End If
                If Utility.isHankaku(changeDbNull(r.Cells(Me.colGroupManagerPassWord.Name).Value)) = False Then
                    Message.MessageShow("E015", {dgvGroupList.Columns(Me.colGroupManagerPassWord.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                '英数チェック
                If Utility.IsHalfAlphaNum(changeDbNull(r.Cells(Me.colGroupManagerId.Name).Value)) = False Then
                    Message.MessageShow("E038", {dgvGroupList.Columns(Me.colGroupManagerId.Name).HeaderText, r.Index + 1})
                    Return False
                End If
                If Utility.IsHalfAlphaNum(changeDbNull(r.Cells(Me.colGroupManagerPassWord.Name).Value)) = False Then
                    Message.MessageShow("E038", {dgvGroupList.Columns(Me.colGroupManagerPassWord.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                'テスト回数チェック
                If r.DataBoundItem.row.Item("TESTCOUNT") AndAlso (r.Cells(colCourse.Name).Value <> r.DataBoundItem.row.Item("OLDCOURSE")) Then
                    Message.MessageShow("E046", {r.Index + 1})
                    Return False
                End If

                '重複チェック
                Dim selectString As String = "GROUPMANAGERID= '" & r.Cells(colGroupManagerId.Name).Value & "'"
                Dim foundDataRow() As DataRow = dtGroupList.Select(selectString)
                For Each dr As DataRow In foundDataRow
                    If r.Cells(colGroupCode.Name).Value <> dr.Item("GROUPCODE").ToString Then
                        Message.MessageShow("E048", {dgvGroupList.Columns(Me.colGroupManagerId.Name).HeaderText, r.Index + 1})
                        Return False
                    End If
                Next
            End If
        Next

    End Function

    ''' <summary>
    ''' 利用期間の終了日チェック
    ''' </summary>
    ''' <param name="strGroupCode"></param>
    ''' <param name="strTestEnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckEndDate(ByRef strGroupCode As String, ByRef strTestEnd As String) As Boolean

        Dim strFileNameList As String() = Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_GROUP_FILENAME & strGroupCode & Common.Constant.CST_EXTENSION_XML)
        Dim dtGroup As DataTable = New DataTable
        dtGroup.Merge(Serialize.XmlToDataTable(IO.Path.GetFileName(strFileNameList(0))))

        '1回目受験終了期間のチェック
        If String.Compare(dtGroup.Rows(0).Item(Common.Group.ColumnIndex.FirstEndDay), "") <> 0 Then
            If DateDiff("d", dtGroup.Rows(0).Item(Common.Group.ColumnIndex.FirstEndDay), strTestEnd) < 0 Then
                Return False
            End If
        End If

        '再試験受験終了期間のチェック
        If String.Compare(dtGroup.Rows(0).Item(Common.Group.ColumnIndex.SecondEndDay), "") <> 0 Then
            If DateDiff("d", dtGroup.Rows(0).Item(Common.Group.ColumnIndex.SecondEndDay), strTestEnd) < 0 Then
                Return False
            End If
        End If

        Return True
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
    ''' 団体ファイルの更新
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <remarks></remarks>
    Private Sub updateGroupFile(ByVal dr As DataRow)
        Dim dt As New DataTable
        XmlSchema.GetGroupSchema(dt)
        dt.ImportRow(dr)
        Serialize.DataTableToxml(dt, Common.Constant.CST_GROUP_FILENAME & dt.Rows(0).Item("GROUPCODE").ToString & Common.Constant.CST_EXTENSION_XML)
    End Sub

    ''' <summary>
    ''' 更新情報の確認
    ''' </summary>
    Private Function checkRowState() As Boolean
        checkRowState = True
        Dim dt As DataTable = CType(dgvGroupList.DataSource, DataTable)
        If IsNothing(dt) Then
            Return True
        End If
        For Each Rows In dt.Rows
            If Rows.RowState = DataRowState.Modified Then
                checkRowState = False
            End If
        Next

        If checkRowState = False Then
            If Message.MessageShow("Q002") = DialogResult.OK Then
                checkRowState = True
            End If
        End If
    End Function

    ''' <summary>
    ''' null値をブランクに変更
    ''' </summary>
    Private Function changeDbNull(ByVal obj As Object)
        If obj Is DBNull.Value Then
            Return ""
        Else
            Return obj
        End If
    End Function

    ''' <summary>
    ''' 団体データ読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadGroup()
        'グループファイル読み込み
        dtGroup = loadGroupFile()
        'データテーブルを加工
        editDataTable(dtGroup)
        'コース名保持
        addOldCorse(dtGroup)
        'パスワード保持
        addOldPassWord(dtGroup)
        'テストカウント取得
        addTestCount(dtGroup)

        'バインド
        Dim dtBind As New DataTable
        dtBind = dtGroup.Copy
        'dgvGroupList.DataSource = chengeStudentCountType(dtBind)
        dgvGroupList.DataSource = dtBind
        dtBind.AcceptChanges()
    End Sub

    ''' <summary>
    ''' 受講者数の型を変更
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function chengeStudentCountType(ByVal dt As DataTable) As DataTable
        Dim newDt As DataTable
        newDt = dt.Clone
        newDt.Columns("STUDENTCOUNT").DataType = GetType(Int32)
        For Each dr As DataRow In dt.Rows
            newDt.ImportRow(dr)
        Next

        Return newDt
    End Function

    ''' <summary>
    ''' コース名を保持
    ''' </summary>
    ''' <param name="group"></param>
    ''' <remarks></remarks>
    Private Sub addOldCorse(ByRef group As DataTable)
        Dim dc As New DataColumn
        dc.ColumnName = "OLDCOURSE"
        group.Columns.Add(dc)

        For Each dr As DataRow In group.Rows
            dr("OLDCOURSE") = dr("COURSE").ToString
        Next
    End Sub

    ''' <summary>
    ''' パスワードを保持
    ''' </summary>
    ''' <param name="group"></param>
    ''' <remarks></remarks>
    Private Sub addOldPassWord(ByRef group As DataTable)
        Dim dc As New DataColumn
        dc.ColumnName = "OLDPASSWORD"
        group.Columns.Add(dc)

        For Each dr As DataRow In group.Rows
            dr("OLDPASSWORD") = dr("PASSWORD").ToString
        Next
    End Sub

    ''' <summary>
    ''' テストカウントの取得
    ''' </summary>
    ''' <param name="group"></param>
    ''' <remarks></remarks>
    Private Sub addTestCount(ByRef group As DataTable)
        Dim dc As New DataColumn
        dc.ColumnName = "TESTCOUNT"
        group.Columns.Add(dc)

        For Each dr As DataRow In group.Rows
            dr("TESTCOUNT") = checkTestCount(dr("GROUPCODE").ToString)
        Next
    End Sub

    ''' <summary>
    ''' 団体修正一時フォルダ作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mekeTempDirectry()
        If IO.Directory.Exists(tempDirectry) Then
            CBTCommon.Utility.DeleteDirectory(tempDirectry)
        End If

        IO.Directory.CreateDirectory(tempDirectry)
    End Sub

    ''' <summary>
    ''' データグリッドのコンボ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setdgvGroupListCombo()
        'DataGridViewComboBoxColumnを作成
        Dim column As DataGridViewComboBoxColumn = dgvGroupList.Columns.Item(colState.Name)
        'ComboBoxのリストに表示する項目を指定する
        column.DataSource = setState(False)
        column.ValueMember = "STATE"
        column.DisplayMember = "DISP"

        'DataGridViewComboBoxColumnを作成
        column = dgvGroupList.Columns.Item(colCourseNo.Name)
        ''ComboBoxのリストに表示する項目を指定する
        column.DataSource = setCourseCollection(False)
        column.ValueMember = "COURSENO"
        column.DisplayMember = "COURSE"
    End Sub

    ''' <summary>
    ''' コースコンボ設定
    ''' </summary>
    ''' <param name="Flg"></param>
    ''' <returns></returns>
    ''' <remarks>コースの中から、利用中の情報を設定する。※利用停止でも団体に紐づくデータは表示する。</remarks>
    Private Function setCourseCollection(ByVal Flg As Boolean) As DataTable
        Dim CourseDt As New DataTable
        Dim nowDay As String = Format(Date.Now, "yyyy/MM/dd")
        Dim Dt As New DataTable
        CourseDt = getCourse()

        Dt = CourseDt.Clone
        If Flg Then
            'すべて
            Dt.Rows.Add()
            With Dt.Rows(0)
                .Item("COURSE") = Common.Constant.CST_ALL
            End With
        Else

        End If

        Dim where As String = "STATE = '1'"
        where += " OR STATE = '2' AND USESTART <= '" & nowDay & "'"
        Dim GroupCorse As New DataTable
        GroupCorse = getGroupCorse()
        If GroupCorse.Rows.Count > 0 Then
            For Each Row As DataRow In GroupCorse.Rows
                where += "OR COURSE = '" & Row.Item("COURSE") & "'"
            Next
        End If
        For Each Row As DataRow In CourseDt.Select(where, "COURSENO")
            Dt.ImportRow(Row)
        Next

        Return Dt
    End Function

    ''' <summary>
    ''' コース情報取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCourse() As DataTable
        Dim fileName As String = Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If CourseTable.Rows.Count <> 0 Then
            Return CourseTable
        End If

        If Not System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            Common.XmlSchema.GetCourseSchema(CourseTable)
            Return CourseTable
        End If
        'コース取得
        CourseTable = Common.Serialize.XmlToDataTable(Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML)
        Return CourseTable
    End Function

    ''' <summary>
    ''' 状態コンボ設定
    ''' </summary>
    ''' <param name="Flg">True：検索領域、False：一覧</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setState(ByVal Flg As Boolean) As DataTable
        setState = Nothing
        Dim Dt As New DataTable
        '項目
        Dim Column As New DataColumn
        Column.ColumnName = "DISP"
        Dt.Columns.Add(Column)
        Dim ColumnName As New DataColumn
        ColumnName.ColumnName = "STATE"
        Dt.Columns.Add(ColumnName)

        Dim Start As Integer = If(Flg, 0, 1)
        If Flg Then
            For i As Integer = Start To 4
                Dt.Rows.Add()
                Dt.Rows(i - Start).Item("STATE") = Common.Constant.CST_STATE_SEARCH(i)
                Dt.Rows(i - Start).Item("DISP") = Common.Constant.CST_NEW_STATE_SEARCH(i)
            Next
        Else
            For i As Integer = Start To 3
                Dt.Rows.Add()
                Dt.Rows(i - Start).Item("STATE") = Common.Constant.CST_STATE(i)
                Dt.Rows(i - Start).Item("DISP") = Common.Constant.CST_NEW_STATE(i)
            Next
        End If
        Return Dt
    End Function

    ''' <summary>
    ''' 削除チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function delCheck() As Boolean
        delCheck = False
        Dim dtGroupList As DataTable = CType(dgvGroupList.DataSource, DataTable)
        Dim Flg As Boolean = False

        For Each r As DataGridViewRow In dgvGroupList.Rows
            If r.Cells(colCheck.Name).Value Then
                '受験期間
                If Date.Parse(changeDbNull(r.Cells(Me.colTestEnd.Name).Value)) > Date.Now Then
                    Flg = True
                    Exit For
                End If
            End If
        Next

        Dim MsgNo As String = String.Empty
        If Flg Then
            MsgNo = "Q009"
        Else
            MsgNo = "Q005"
        End If
        If Message.MessageShow(MsgNo) = DialogResult.Cancel Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 削除処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function delDateGroup() As Boolean
        delDateGroup = True
        'チェック
        If Not checkFlg() Then
            Return False
        End If

        Dim dtGroup As DataTable = dgvGroupList.DataSource
        For Each r As DataGridViewRow In dgvGroupList.Rows
            If r.Cells(colCheck.Name).Value Then
                deletGroupFile(r.DataBoundItem.row)
                'dtGroup.Rows.Remove(r.DataBoundItem.row)
            End If
        Next

        'ファイルアップロード
        processMessageUpload = True
        Common.DataManager.GetInstance.UpLoadFile()

        Message.MessageShow("I006")

        dtGroup = dgvGroupList.DataSource
        dtGroup.AcceptChanges()
        dgvGroupList.DataSource = dtGroup

    End Function

    ''' <summary>
    ''' 削除実施
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    Private Sub deletGroupFile(ByVal row As DataRow)
        Dim groupCode As String
        Dim path As String = Common.Constant.GetTempPath
        Dim fileName As String = String.Empty
        groupCode = row.Item("GROUPCODE")

        Dim fileList As New ArrayList
        '団体情報ファイル
        fileList.Add(path & Common.Constant.CST_GROUP_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '受講者情報ファイル
        fileList.Add(path & Common.Constant.CST_STUDENT_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '試験結果ヘッダファイル
        fileList.Add(path & Common.Constant.CST_TESTHEADSUM_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '試験明細明細ファイル
        fileList.Add(path & Common.Constant.CST_TESTDETAILSUM_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)

        'メールファイル
        fileName = Common.Constant.CST_MAIL_FILENAME & groupCode & "*" & Common.Constant.CST_EXTENSION_TXT
        fileList.AddRange(System.IO.Directory.GetFiles(path, fileName))
        '再演習
        fileList.Add(path & Common.Constant.CST_REVIEW_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '逐次演習結果_ヘッダ
        fileList.Add(path & Common.Constant.CST_SERIALRESULTHEADER_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '逐次演習結果_明細
        fileList.Add(path & Common.Constant.CST_SERIALRESULTDETAIL_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '小テスト結果_ヘッダ
        fileList.Add(path & Common.Constant.CST_MINIRESULTHEADER_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '小テスト結果_明細
        fileList.Add(path & Common.Constant.CST_MINIRESULTDETAIL_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '総合テスト結果_ヘッダ
        fileList.Add(path & Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '総合テスト結果_明細
        fileList.Add(path & Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)

        '総合テスト_ヘッダ
        fileList.Add(path & Common.Constant.CST_SYNTHESISHEADER_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '総合テスト_明細
        fileName = Common.Constant.CST_SYNTHESISDETAIL_FILENAME & groupCode & "_*" & Common.Constant.CST_EXTENSION_XML
        fileList.AddRange(System.IO.Directory.GetFiles(path, fileName))
        '指定テスト_ヘッダ
        fileList.Add(path & Common.Constant.CST_SPECIFICHEADER_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML)
        '指定テスト_明細
        fileName = Common.Constant.CST_SPECIFICDETAIL_FILENAME & groupCode & "_*" & Common.Constant.CST_EXTENSION_XML
        fileList.AddRange(System.IO.Directory.GetFiles(path, fileName))
        '再演習
        fileName = Common.Constant.CST_REVIEW_FILENAME & groupCode & "_*" & Common.Constant.CST_EXTENSION_XML
        fileList.AddRange(System.IO.Directory.GetFiles(path, fileName))

        '削除
        For Each file As String In fileList
            If IO.File.Exists(file) Then
                Debug.Print(file)
                logger.Info("Start:deletGroupFile FileName:" & file)
                IO.File.Delete(file)
                logger.Info("End:deletGroupFile FileName:" & file)
            End If
        Next
    End Sub

    ''' <summary>
    ''' コースコンボ追加
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>コンボに現在のコースがなければ追加する</remarks>
    Private Function addCourseCollection(ByVal Course) As DataTable
        Dim CourseDt As New DataTable
        Dim nowDay As String = Format(Date.Now, "yyyy/MM/dd")
        Dim Dt As New DataTable
        CourseDt = getCourse()

        Dt = CourseDt.Clone

        Dim where As String = "STATE = '1'"
        where += " OR STATE = '2' AND USESTART <= '" & nowDay & "'"
        where += "OR COURSENO = '" & Course.value & "'"

        For Each Row As DataRow In CourseDt.Select(where, "COURSENO")
            Dt.ImportRow(Row)
        Next
        Return Dt
    End Function

    ''' <summary>
    ''' 既存団体のコース取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getGroupCorse() As DataTable
        Dim groupFile As New DataTable
        Dim tmpGroupCorse As New DataTable
        Dim tmp As String = String.Empty
        Common.XmlSchema.GetGroupSchema(tmpGroupCorse)
        groupFile = loadGroupFile()
        If groupFile.Rows.Count > 0 Then
            For Each row As DataRow In groupFile.Select("", "COURSENO")
                If tmp <> String.Empty Then
                    If tmp <> row.Item("COURSE") Then
                        tmpGroupCorse.ImportRow(row)
                        tmp = row.Item("COURSE")
                    End If
                Else
                    tmpGroupCorse.ImportRow(row)
                    tmp = row.Item("COURSE")
                End If
            Next
        End If
        Return tmpGroupCorse
    End Function

    ''' <summary>
    ''' テストの日付を保持
    ''' </summary>
    ''' <param name="dgvr"></param>
    ''' <remarks></remarks>
    Private Sub loadTestDate(ByVal dgvr As DataGridViewRow)
        Dim dr As DataRow = dgvr.DataBoundItem.row
        Dim fileName As String = tempDirectry & Common.Constant.CST_GROUP_FILENAME & dr.Item("GROUPCODE").ToString() & Common.Constant.CST_EXTENSION_XML
        Dim dt As New DataTable

        If IO.File.Exists(fileName) Then
            dt = Serialize.XmlToDataTableFullPath(fileName)
        End If

        If dt.Rows.Count > 0 Then
            If dr.Item(Group.ColumnIndex.FirstStartDay) <> dt.Rows(0).Item(Group.ColumnIndex.FirstStartDay) Then
                dr.Item(Group.ColumnIndex.FirstStartDay) = dt.Rows(0).Item(Group.ColumnIndex.FirstStartDay)
            End If
            If dr.Item(Group.ColumnIndex.FirstEndDay) <> dt.Rows(0).Item(Group.ColumnIndex.FirstEndDay) Then
                dr.Item(Group.ColumnIndex.FirstEndDay) = dt.Rows(0).Item(Group.ColumnIndex.FirstEndDay)
            End If
            If dr.Item(Group.ColumnIndex.SecondStartDay) <> dt.Rows(0).Item(Group.ColumnIndex.SecondStartDay) Then
                dr.Item(Group.ColumnIndex.SecondStartDay) = dt.Rows(0).Item(Group.ColumnIndex.SecondStartDay)
            End If
            If dr.Item(Group.ColumnIndex.SecondEndDay) <> dt.Rows(0).Item(Group.ColumnIndex.SecondEndDay) Then
                dr.Item(Group.ColumnIndex.SecondEndDay) = dt.Rows(0).Item(Group.ColumnIndex.SecondEndDay)
            End If
        End If
    End Sub
#End Region

    Private Sub getUseStartEnd(ByVal courseNo As String, ByRef useStart As Date, ByRef useEnd As Date)
        Dim dtCourse As DataTable = cmbCourse.DataSource
        Dim drCourse As DataRow() = dtCourse.Select("COURSENO = '" & courseNo & "'")

        If drCourse.Length > 0 Then
            useStart = CType(drCourse(0).Item(Common.Course.ColumnIndex.UseStart), Date)
            useEnd = CType(drCourse(0).Item(Common.Course.ColumnIndex.UseEnd), Date)
        End If
    End Sub

    Private Function getStudent(ByVal groupCode As String) As DataTable
        Dim dtStudent As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_STUDENT_FILENAME & groupCode & "*")
            dtStudent = Common.Group.GetAll(IO.Path.GetFileName(fileName))
        Next
        Return dtStudent
    End Function

End Class