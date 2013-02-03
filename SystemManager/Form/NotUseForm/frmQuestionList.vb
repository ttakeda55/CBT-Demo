Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.QuestionShow
Imports System.Linq
''' <summary>
''' 問題一覧
''' </summary>
''' <remarks>
''' 2011/09/08 noza 新規作成
''' </remarks>
Public Class frmQuestionList
#Region "----- メンバ変数 -----"
    ''' <summary>団体情報</summary>
    Private dtGroup As New DataTable
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- イベント -----"

    ''' <summary>
    ''' 問題確認メニュー画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackQuestionManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackQuestionManager.Click
        Try
            logger.Start()
            Me.DialogResult = DialogResult.OK
            Me.Close()
            logger.End()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmQuestionList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            dgvQuestionList.AutoGenerateColumns = False

            '問題一覧読み込み
            Dim dtQuestionList As DataTable = QuestionList.GetAll(Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
            If dtQuestionList.Rows.Count > 0 Then
                'データソースを設定
                setListNameDataSource(dtQuestionList)
                setStateDataSource(dtQuestionList)
                '利用者数を設定
                setStudentCount(dtQuestionList)
                'バインド
                dgvQuestionList.DataSource = dtQuestionList
                '更新日フォーマット
                formatUpdateDate()
                '変更を確定
                dtQuestionList.AcceptChanges()
            End If
            Owner.Hide()
            logger.End()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 模擬テスト一覧を更新する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 模擬テスト一覧を更新する
    ''' 更新項目
    ''' ・対応模擬テスト
    ''' ・利用開始日
    ''' ・利用終了日
    ''' ・状態を更新する
    ''' </remarks>
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            logger.Start()
            If dgvQuestionList.Rows.Count > 0 Then
                '入力チェック
                If Not inputCheck() Then Exit Sub

                '更新確認
                If Message.MessageShow("Q007") = DialogResult.Cancel Then Exit Sub

                Dim dtQuestionList As DataTable = dgvQuestionList.DataSource

                '更新日付の更新
                For Each dr As DataRow In dtQuestionList.Rows
                    If dr.RowState = DataRowState.Modified Then
                        dr(QuestionList.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
                    End If
                Next

                '更新日列削除
                dtQuestionList.Columns.Remove("UPDATE_DATE_DISPLAY")
                dtQuestionList.Columns.Remove("USECOUNT")

                'NULL値変換
                For Each dr As DataRow In dtQuestionList.Rows
                    If dr.Item(Common.QuestionList.ColumnIndex.UseStart) Is DBNull.Value Then dr.Item(Common.QuestionList.ColumnIndex.UseStart) = ""
                    If dr.Item(Common.QuestionList.ColumnIndex.UseEnd) Is DBNull.Value Then dr.Item(Common.QuestionList.ColumnIndex.UseEnd) = ""
                Next

                '模擬テスト一覧更新
                QuestionList.WriteXML(dtQuestionList, Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)

                'ファイル更新
                processMessageUpload = True
                Common.DataManager.GetInstance.UpLoadFile()

                frmQuestionList_Load(sender, e)

                Message.MessageShow("I004")
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
    ''' 問題確認画面へ遷移する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 「問題コード」のリンクをクリックし、
    ''' 問題確認画面の小問又は中問を表示する。
    ''' </remarks>
    Private Sub dgvQuestionList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuestionList.CellContentClick
        Try
            logger.Start()
            If e.ColumnIndex = TESTNAME.Index And e.RowIndex <> -1 Then
                Dim flg As Boolean = False
                If dgvQuestionList.CurrentRow.Index = 0 Then
                    flg = True
                Else
                    flg = False
                End If
                If e.ColumnIndex = TESTNAME.Index Then
                    processMessage = True
                    Refresh()
                    If dgvQuestionList.Rows.Count = 0 Then
                        Message.MessageShow("E021", {"データ"})
                        Exit Sub
                    End If

                    Dim SDataManager As GDataManager = GDataManager.GetInstance()
                    SDataManager.Initialize()
                    SDataManager.ReadQuestionFile(Common.Constant.CST_QUESTION_FILENAME & dgvQuestionList.CurrentRow.Cells(0).Value)

                    Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                    dataBanker("FROMFORM") = "TG12"
                    Dim frmNext As QuestionShow.frmQuestionShow

                    frmNext = New QuestionShow.frmQuestionShow(0, 1)
                    processMessage = False
                    frmNext.ShowDialog(Me)
                    Me.Visible = True
                End If
            End If

            logger.End()
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
    Private Sub dgvQuestionList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuestionList.CellEnter
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)

            If (dgv.Columns(e.ColumnIndex).Name = Me.MOCKTESTNO.Name Or _
                dgv.Columns(e.ColumnIndex).Name = Me.STATE.Name) AndAlso _
                TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                SendKeys.Send("{F4}")
            End If
            '---- 列番号を調べて制御 ------
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case USESTART.Name, USEEND.Name
                    'この列は日本語入力ON
                    dgvQuestionList.ImeMode = Windows.Forms.ImeMode.Disable
            End Select
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
    Private Sub dgvQuestionList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuestionList.CellClick
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
    ''' DataErrorイベントハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_DataError(ByVal sender As Object, _
            ByVal e As DataGridViewDataErrorEventArgs) _
            Handles dgvQuestionList.DataError
        Try
            e.Cancel = False
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
    ''' 団体を取得する。
    ''' </summary>
    ''' <returns>団体情報</returns>
    ''' <remarks></remarks>
    Private Function getGroup() As DataTable
        Dim group As New DataTable
        XmlSchema.GetGroupSchema(group)
        For Each fileName In System.IO.Directory.GetFiles(CST.CBT.eIPSTA.Common.Constant.GetTempPath, CST.CBT.eIPSTA.Common.Constant.CST_GROUP_FILENAME & "*")
            group.Merge(Serialize.XmlToDataTable(IO.Path.GetFileName(fileName)))
        Next
        getGroup = group
    End Function

    ''' <summary>
    ''' null値をブランクに変更
    ''' </summary>
    ''' <returns>文字列</returns>
    Private Function changeDbNull(ByVal obj As Object)
        If obj Is DBNull.Value Then
            Return ""
        Else
            Return obj
        End If
    End Function

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns>エラーがないかどうか</returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        inputCheck = True
        For Each r As DataGridViewRow In dgvQuestionList.Rows
            '日付チェック
            '利用開始日の妥当性チェック
            If changeDbNull(r.Cells(Me.USESTART.Name).Value) <> String.Empty Then
                If checkDate(changeDbNull(r.Cells(Me.USESTART.Name).Value)) = False Then
                    Message.MessageShow("E014", {dgvQuestionList.Columns(Me.USESTART.Name).HeaderText, r.Index + 1})
                    Return False
                End If
            End If
            '利用終了日の妥当性チェック
            If changeDbNull(r.Cells(Me.USEEND.Name).Value) <> String.Empty Then
                If checkDate(changeDbNull(r.Cells(Me.USEEND.Name).Value)) = False Then
                    Message.MessageShow("E014", {dgvQuestionList.Columns(Me.USEEND.Name).HeaderText, r.Index + 1})
                    Return False
                End If
            End If

            '未入力チェック
            '利用開始日
            If changeDbNull(r.Cells(Me.USESTART.Name).Value) <> String.Empty And _
                changeDbNull(r.Cells(Me.USEEND.Name).Value) = String.Empty Then
                Message.MessageShow("E012", {dgvQuestionList.Columns(Me.USEEND.Name).HeaderText, r.Index + 1})
                Return False
            End If
            '利用終了日
            If changeDbNull(r.Cells(Me.USESTART.Name).Value) = String.Empty And _
                changeDbNull(r.Cells(Me.USEEND.Name).Value) <> String.Empty Then
                Message.MessageShow("E012", {dgvQuestionList.Columns(Me.USESTART.Name).HeaderText, r.Index + 1})
                Return False
            End If

            '受験期間大小チェック
            If changeDbNull(r.Cells(Me.USESTART.Name).Value) <> String.Empty And _
                changeDbNull(r.Cells(Me.USEEND.Name).Value) <> String.Empty Then
                If Date.Parse(changeDbNull(r.Cells(Me.USESTART.Name).Value)) > Date.Parse(changeDbNull(r.Cells(Me.USEEND.Name).Value)) Then
                    Message.MessageShow("E053", {r.Index + 1})
                    Return False
                End If
            End If

            '重複チェック
            For i As Integer = r.Index + 1 To dgvQuestionList.RowCount - 1
                'ブランクチェック
                If changeDbNull(r.Cells(Me.MOCKTESTNO.Name).Value) <> "" And _
                    changeDbNull(r.Cells(Me.USESTART.Name).Value) <> "" And _
                    changeDbNull(r.Cells(Me.USEEND.Name).Value) <> "" Then
                    '対象模擬テストが重複
                    If changeDbNull(r.Cells(Me.MOCKTESTNO.Name).Value) = changeDbNull(dgvQuestionList.Rows(i).Cells(Me.MOCKTESTNO.Name).Value) Then
                        '期間が重複
                        If changeDbNull(r.Cells(Me.USESTART.Name).Value) <= changeDbNull(dgvQuestionList.Rows(i).Cells(Me.USEEND.Name).Value) And _
                            changeDbNull(r.Cells(Me.USEEND.Name).Value) >= changeDbNull(dgvQuestionList.Rows(i).Cells(Me.USESTART.Name).Value) Then
                            '状態がともに削除でない
                            If changeDbNull(r.Cells(Me.STATE.Name).Value) = 0 And changeDbNull(dgvQuestionList.Rows(i).Cells(Me.STATE.Name).Value) = 0 Then
                                Message.MessageShow("E048", {"対象模擬テストと期間", r.Index + 1})
                                Return False
                            End If
                        End If
                    End If
                End If
            Next
        Next

    End Function

    ''' <summary>
    ''' 日付の妥当性チェック
    ''' </summary>
    ''' <param name="strDate"></param>
    ''' <returns>妥当な日付かどうか</returns>
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
    ''' 表示表更新日付列を追加
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub formatUpdateDate()
        Dim dtQuestion As DataTable = dgvQuestionList.DataSource

        If Not dtQuestion.Columns.Contains("UPDATE_DATE_DISPLAY") Then
            dtQuestion.Columns.Add("UPDATE_DATE_DISPLAY")
        End If

        For Each dr As DataRow In dtQuestion.Rows
            dr("UPDATE_DATE_DISPLAY") = CDate(dr(QuestionList.ColumnIndex.UpdateDate)).ToShortDateString
        Next
    End Sub

    ''' <summary>
    ''' 利用者数を設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setStudentCount(ByVal dtQuestionList As DataTable)
        Try
            logger.Start()
            Dim dtGroup = getGroup()
            Dim dtCourse As DataTable = Course.GetAll(Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML)
            Dim studentCount As Integer = 0
            Dim sysDate As String = System.DateTime.Now.ToShortDateString
            Dim htStudentCount As New Hashtable

            '利用者数を取得
            For Each drQuestionList As DataRow In dtQuestionList.Rows
                If Not (drQuestionList("USESTART").ToString <= sysDate And sysDate <= drQuestionList("USEEND").ToString) Then
                    studentCount = 0
                    Continue For '利用期間外
                End If
                Dim drCourses As DataRow() = dtCourse.Select("MOCKTESTNO = '" & drQuestionList(QuestionList.ColumnIndex.MockTestNO) & "' AND " & _
                                                           "( STATE = '1' OR ( STATE = '2' AND USESTART <= '" & sysDate & "' AND USESTART <> ''))")
                For Each drCourse As DataRow In drCourses
                    'If drCourse("USESTART").ToString <= sysDate And sysDate <= drCourse("USEEND").ToString Or
                    If drCourse("USESTART").ToString <= sysDate Or
                                     drCourse("STATE").ToString = "1" Then
                        Dim drGroups As DataRow() = dtGroup.Select("COURSENO = '" & drCourse(Course.ColumnIndex.CourseNo) & "'")
                        For Each drGroup As DataRow In drGroups
                            If drGroup("TESTSTART").ToString <= sysDate And sysDate <= drGroup("TESTEND").ToString Then
                                If Not drGroup("STATE").ToString = "運用停止" Then
                                    studentCount += CInt(drGroup("STUDENTCOUNT"))
                                End If
                            Else
                                If drGroup("STATE").ToString = "運用中" Then
                                    studentCount += CInt(drGroup("STUDENTCOUNT"))
                                End If
                            End If
                        Next
                    End If
                Next

                If htStudentCount.ContainsKey(drQuestionList.Item("TESTNAME").ToString) Then
                    htStudentCount(drQuestionList.Item("TESTNAME").ToString) += studentCount
                Else
                    htStudentCount.Add(drQuestionList.Item("TESTNAME").ToString, studentCount)
                End If
                studentCount = 0
            Next

            If Not dtQuestionList.Columns.Contains("USECOUNT") Then
                dtQuestionList.Columns.Add("USECOUNT")
            End If

            '画面に設定
            For Each drQuestionList As DataRow In dtQuestionList.Rows
                If htStudentCount.ContainsKey(drQuestionList(Common.QuestionList.ColumnIndex.TestName)) Then
                    drQuestionList("USECOUNT") = htStudentCount(drQuestionList(Common.QuestionList.ColumnIndex.TestName))
                End If
            Next

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 対応模擬テストのデータソースを設定する
    ''' </summary>
    ''' <param name="dtQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setListNameDataSource(ByVal dtQuestionList As DataTable)
        Dim DataSource As New DataTable("DataSource")
        DataSource.Columns.Add("Value", GetType(String))
        DataSource.Columns.Add("code", GetType(String))
        DataSource.Rows.Add(Common.Constant.CST_COURSE(1), "1")
        DataSource.Rows.Add(Common.Constant.CST_COURSE(2), "2")
        DataSource.Rows.Add(Common.Constant.CST_COURSE(3), "3")

        Dim column As New DataGridViewComboBoxColumn()
        column = CType(dgvQuestionList.Columns("MOCKTESTNO"), DataGridViewComboBoxColumn)
        column.DataSource = DataSource
        column.ValueMember = "code"
        column.DisplayMember = "Value"
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
        DataSource.Rows.Add(" ", "0")
        DataSource.Rows.Add("削除", "1")

        Dim column As New DataGridViewComboBoxColumn()
        column = CType(dgvQuestionList.Columns(STATE.Index), DataGridViewComboBoxColumn)
        column.DataSource = DataSource
        column.ValueMember = "code"
        column.DisplayMember = "Value"
    End Sub
#End Region
End Class