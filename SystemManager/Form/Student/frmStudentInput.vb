Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
''' <summary>
''' 受講者個別処理(TG08)<br/>
''' <img src="..\Images\TG08.png" />
''' </summary>
Public Class frmStudentInput
#Region "メンバ変数"
    Private dtStudent As New DataTable
    Private cellValue As String = String.Empty
    Private beforeRowState As New DataRowState
    Private tempDirectry As String = Common.Constant.GetTempPath & "StudentinputTemp\"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "イベンドハンドラ"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmImportCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Text = "受講者個別登録／修正"
            lblBottomCode.Text = "TG07"
            lblBottomName.Text = "受講者個別処理画面"

            'ファイルダウンロード
            If Not DataManager.GetInstance.DownLoadFile Then
                Me.DialogResult = DialogResult.OK
                Close()
            End If

            ''受講者をロードする
            loadStudent()

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' 更新修正ボタン押下
    ''' </summary>
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            logger.Start()
            '入力チェック
            If inputCheck() = False Then
                Exit Sub
            End If

            '更新確認
            If Message.MessageShow("Q007") = DialogResult.Cancel Then
                Exit Sub
            End If

            '更新処理
            If upDateStudent() = False Then
                Exit Sub
            End If

            btnSearch_Click(sender, e)
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' 検索ボタンボタン押下
    ''' </summary>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            logger.Start()
            If checkRowState() Then
                loadStudent()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' データ削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            logger.Start()
            '削除処理

            If Not delCheck() Then
                Exit Sub
            End If

            'データファイル削除
            If Not Message.MessageShow("Q005") = DialogResult.OK Then
                Exit Sub
            End If

            If Not delStudent() Then Exit Sub

            '受講者数設定
            setStudentCountAndUsePeriod()

            btnSearch_Click(sender, e)
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' システム管理画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            logger.Start()
            If checkRowState() Then
                Me.Close()
                Me.DialogResult = DialogResult.Cancel
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 受講者管理画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackStudent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackStudent.Click
        Try
            logger.Start()
            If checkRowState() Then
                Me.Close()
                Me.DialogResult = DialogResult.OK
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
    Private Sub dgvStudent_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStudent.CellEnter
        Try
            Dim dgv As DataGridView = CType(sender, DataGridView)

            If dgv.Columns(e.ColumnIndex).Name = colSection1.Name AndAlso _
                TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                SendKeys.Send("{F4}")
            End If
            If dgv.Columns(e.ColumnIndex).Name = colSection2.Name AndAlso _
                TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                SendKeys.Send("{F4}")
            End If
            '---- 列番号を調べて制御 ------
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case colUserName.Name, colNote.Name
                    'この列は日本語入力ON
                    dgvStudent.ImeMode = Windows.Forms.ImeMode.On
                Case Else
                    'この列はIME無効(半角英数のみ)
                    dgvStudent.ImeMode = Windows.Forms.ImeMode.Disable
            End Select
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 全チェック処理
    ''' </summary>
    Private Sub btnAllCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllCheck.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvStudent.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                Me.dgvStudent(0, i).Value = True
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
    Private Sub btnAllCheckCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllCheckCancell.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvStudent.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                Me.dgvStudent(0, i).Value = False
            Next
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
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
            For Each r As DataGridViewRow In dgvStudent.Rows
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
    ''' テキスト項目を一回のクリックで編集開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvGroupList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStudent.CellEnter
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
    ''' CSVファイル出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCSVExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSVExport.Click
        Try
            logger.Start()
            If Not checkFlg() Then
                Exit Sub
            End If

            Dim filePath As String = ""
            filePath = saveCsvFileDialog()

            If filePath = String.Empty Then
                Exit Sub
            End If

            makeStudentCsv(filePath)

            Message.MessageShow("I007")
            logger.End()
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
    Private Sub dgvGroupList_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStudent.CellEndEdit
        Try
            If Not dgvStudent.CurrentCell.Value Is Nothing Then
                dgvStudent.CurrentCell.Value = dgvStudent.CurrentCell.Value.ToString.Trim
                Dim colName As String = dgvStudent.Columns(dgvStudent.CurrentCell.ColumnIndex).Name

                If colName = colPassWord.Name Then
                    dgvStudent.CurrentCell.Value = dgvStudent.CurrentCell.Value.ToString.Replace(" ", "").Replace("　", "")
                End If
            End If

            If cellValue = dgvStudent.CurrentCell.Value And beforeRowState = DataRowState.Unchanged Then
                CType(dgvStudent.CurrentRow.DataBoundItem, DataRowView).Row.AcceptChanges()
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
    Private Sub dgvGroupList_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvStudent.CellBeginEdit
        Try
            If Not dgvStudent.CurrentCell.Value Is Nothing Then
                cellValue = dgvStudent.CurrentCell.Value.ToString
                beforeRowState = CType(dgvStudent.CurrentRow.DataBoundItem, DataRowView).Row.RowState
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グループを変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbGroupCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGroupCode.SelectedIndexChanged, cmbGroupName.SelectedIndexChanged
        Try
            '受講者数を設定
            setStudentCountAndUsePeriod()

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
    ''' 受講者ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadStudentFile() As DataTable
        Dim dt As New DataTable

        'For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_STUDENT_FILENAME & "*")
        '    dt.Merge(editDataTable(Serialize.XmlToDataTable(IO.Path.GetFileName(fileName)), dtGroup, fileName))
        'Next
        Return dt
    End Function

    ''' <summary>
    ''' 団体データ読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadStudent()
        '受講者ファイル読み込み
        dtStudent = loadStudentFile()

        'パスワード保持
        addOldPassWord(dtStudent)

        'バインド
        dgvStudent.AutoGenerateColumns = False
        Dim dtBind As New DataTable
        dtBind = dtStudent.Copy
        dgvStudent.DataSource = dtBind
        dtBind.AcceptChanges()
        If dtBind.Rows.Count > 0 Then
            dtBind.DefaultView.Sort = "USERID ASC"
        End If
    End Sub

    ''' <summary>
    ''' パスワードを保持
    ''' </summary>
    ''' <param name="student"></param>
    ''' <remarks></remarks>
    Private Sub addOldPassWord(ByRef student As DataTable)
        Dim dc As New DataColumn
        dc.ColumnName = "OLDPASSWORD"
        student.Columns.Add(dc)

        For Each dr As DataRow In student.Rows
            dr("OLDPASSWORD") = dr("PASSWORD").ToString
        Next
    End Sub

    ''' <summary>
    ''' コンボボックスにすべてを追加する
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addComboBrankItem(ByVal dt As DataTable) As DataTable
        Dim dtwk As New DataTable
        Dim dr As DataRow = dt.NewRow
        dtwk = dt.Clone
        dt.Rows.Add(dr)
        dtwk.ImportRow(dr)
        dt.Rows.Remove(dr)
        dtwk.Merge(dt)
        Return dtwk
    End Function

    ''' <summary>
    ''' 更新情報の確認
    ''' </summary>
    Private Function checkRowState() As Boolean
        checkRowState = True
        Dim dt As DataTable = CType(dgvStudent.DataSource, DataTable)
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
    ''' CSV出力用にデータを変更する。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function changeStudentCsvDate() As DataTable
        'CSVで保存するDataTable
        Dim dtwk As DataTable = CType(dgvStudent.DataSource, DataTable).Copy
        Dim dt As DataTable = dtwk.Clone
        For Each r As DataGridViewRow In dgvStudent.Rows
            If r.Cells(colCheck.Name).Value Then
                dt.ImportRow(DirectCast(r.DataBoundItem.Row, System.Data.DataRow))
            End If
        Next

        Dim dc As New DataColumn
        dc = dt.Columns("GROUPCODE")
        dt.Columns.Remove(dc)
        dc = dt.Columns("GROUPNAME")
        dt.Columns.Remove(dc)
        dc = dt.Columns("STUDENTCOUNT")
        dt.Columns.Remove(dc)
        dc = dt.Columns("TESTCOUNT")
        dt.Columns.Remove(dc)
        dt.Columns.Remove("UPLOADDATE")
        dt.Columns.Remove("TESTSTART")
        dt.Columns.Remove("TESTEND")
        dt.Columns.Remove("CREATE_DATE")
        dt.Columns.Remove("UPDATE_DATE")

        dt.Columns.Add("ADDPASSWORD")
        For Each dr As DataRow In dt.Rows
            dr.Item("ADDPASSWORD") = dr.Item("PASSWORD")
        Next

        dt.Columns.Remove(dt.Columns("PASSWORD"))
        dt.Columns.Remove(dt.Columns("OLDPASSWORD"))
        dt.Columns.Remove(dt.Columns("SECTION1"))
        dt.Columns.Remove(dt.Columns("SECTION2"))
        dt.Columns.Remove(dt.Columns("STUDENTSSTART"))
        dt.Columns.Remove(dt.Columns("STUDENTSEND"))

        For Each dr As DataColumn In dt.Columns
            If dr.Caption = "USERID" Then
                dr.Caption = "ユーザID"
            End If
            If dr.Caption = "NAME" Then
                dr.Caption = "氏名"
            End If
            'If dr.Caption = "SECTION1" Then
            '    dr.Caption = "区分１"
            'End If
            'If dr.Caption = "SECTION2" Then
            '    dr.Caption = "区分２"
            'End If
            'If dr.Caption = "STUDENTSSTART" Then
            '    dr.Caption = "受講開始日"
            'End If
            'If dr.Caption = "STUDENTSEND" Then
            '    dr.Caption = "受講終了日"
            'End If
            If dr.Caption = "NOTE" Then
                dr.Caption = "備考"
            End If
            If dr.Caption = "ADDPASSWORD" Then
                dr.Caption = "パスワード"
            End If
        Next
        dt.Columns("NOTE").SetOrdinal(2)

        Return dt
    End Function

    ''' <summary>
    ''' CSVファイルを作成する。
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Private Sub makeStudentCsv(ByVal filePath As String)
        '保存先のCSVファイルのパス
        Dim dt As DataTable = changeStudentCsvDate()

        'CSVファイルに書き込むときに使うEncoding
        Dim enc As System.Text.Encoding = _
            System.Text.Encoding.GetEncoding("Shift_JIS")

        '開く
        Dim sr As New System.IO.StreamWriter(filePath, False, enc)

        Dim colCount As Integer = dt.Columns.Count
        Dim lastColIndex As Integer = colCount - 1

        'ヘッダを書き込む
        Dim i As Integer
        For i = 0 To colCount - 1
            'ヘッダの取得
            Dim field As String = dt.Columns(i).Caption
            '"で囲む必要があるか調べる
            If field.IndexOf(ControlChars.Quote) > -1 OrElse _
                field.IndexOf(","c) > -1 OrElse _
                field.IndexOf(ControlChars.Cr) > -1 OrElse _
                field.IndexOf(ControlChars.Lf) > -1 OrElse _
                field.StartsWith(" ") OrElse _
                field.StartsWith(ControlChars.Tab) OrElse _
                field.EndsWith(" ") OrElse _
                field.EndsWith(ControlChars.Tab) Then
                If field.IndexOf(ControlChars.Quote) > -1 Then
                    '"を""とする
                    field = field.Replace("""", """""")
                End If
                field = """" + field + """"
            End If
            'フィールドを書き込む
            sr.Write(field)
            'カンマを書き込む
            If lastColIndex > i Then
                sr.Write(","c)
            End If
        Next i
        '改行する
        sr.Write(ControlChars.Cr + ControlChars.Lf)

        'レコードを書き込む
        Dim row As DataRow
        For Each row In dt.Rows
            For i = 0 To colCount - 1
                'フィールドの取得
                Dim field As String = row(i).ToString()
                '"で囲む必要があるか調べる
                If field.IndexOf(ControlChars.Quote) > -1 OrElse _
                    field.IndexOf(","c) > -1 OrElse _
                    field.IndexOf(ControlChars.Cr) > -1 OrElse _
                    field.IndexOf(ControlChars.Lf) > -1 OrElse _
                    field.StartsWith(" ") OrElse _
                    field.StartsWith(ControlChars.Tab) OrElse _
                    field.EndsWith(" ") OrElse _
                    field.EndsWith(ControlChars.Tab) Then
                    If field.IndexOf(ControlChars.Quote) > -1 Then
                        '"を""とする
                        field = field.Replace("""", """""")
                    End If
                    field = """" + field + """"
                End If
                'フィールドを書き込む
                sr.Write(field)
                'カンマを書き込む
                If lastColIndex > i Then
                    sr.Write(","c)
                End If
            Next i
            '改行する
            sr.Write(ControlChars.Cr + ControlChars.Lf)
        Next row

        '閉じる
        sr.Close()
    End Sub

    ''' <summary>
    ''' ファイル保存ダイアログを表示
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function saveCsvFileDialog() As String
        saveCsvFileDialog = String.Empty
        'SaveFileDialogクラスのインスタンスを作成
        Dim sfd As New SaveFileDialog()

        'はじめのファイル名を指定する
        sfd.FileName = "受講者CSVファイル.csv"
        'はじめに表示されるフォルダを指定する
        sfd.InitialDirectory = "C:\"
        '[ファイルの種類]に表示される選択肢を指定する
        sfd.Filter = _
         "受講者CSVファイル(*.csv;*.csv)|*.csv;*.csv"
        '[ファイルの種類]ではじめに
        '「すべてのファイル」が選択されているようにする
        sfd.FilterIndex = 2
        'タイトルを設定する
        sfd.Title = "保存先のファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき
            '選択されたファイル名を表示する
            Return sfd.FileName
        End If
    End Function

    ''' <summary>
    ''' チェックボックス確認
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkFlg() As Boolean
        checkFlg = False
        For i As Integer = 0 To dgvStudent.RowCount - 1
            If Me.dgvStudent(0, i).Value Then
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
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        inputCheck = True

        'チェック
        If Not checkFlg() Then
            Return False
        End If

        For Each r As DataGridViewRow In dgvStudent.Rows
            If r.Cells(colCheck.Name).Value Then
                '必須チェック
                For i = colUserId.Index To colUserName.Index
                    If changeDbNull(r.Cells(i).Value).ToString.Trim = "" Then
                        Message.MessageShow("E012", {dgvStudent.Columns(i).HeaderText, r.Index + 1})
                        Return False
                    End If
                Next

                '桁数チェック
                If changeDbNull(r.Cells(Me.colPassWord.Name).Value).ToString.Length < 6 Then
                    Message.MessageShow("E037", {dgvStudent.Columns(Me.colPassWord.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                '半角チェック
                If Utility.isHankaku(changeDbNull(r.Cells(Me.colPassWord.Name).Value)) = False Then
                    Message.MessageShow("E015", {dgvStudent.Columns(Me.colPassWord.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                'パスワード禁止文字チェック
                If Utility.IsNgChar(r.Cells(Me.colPassWord.Name).Value, Common.Constant.CST_PASSWORDCHARS_NG) Then
                    Dim chars As String = Common.Constant.CST_PASSWORDCHARS_NG
                    Dim str As String = ""
                    For Each chr As Char In chars
                        str &= "[" & chr.ToString & "]"
                    Next
                    Message.MessageShow("E050", {str})
                    Return False
                End If

                '半角英大文字チェック
                If Utility.IsUpperCase(r.Cells(Me.colPassWord.Name).Value) Then
                    Message.MessageShow("E051")
                    Return False
                End If

                '英数チェック
                If Utility.IsHalfAlphaNum(changeDbNull(r.Cells(Me.colPassWord.Name).Value)) = False Then
                    Message.MessageShow("E038", {dgvStudent.Columns(Me.colPassWord.Name).HeaderText, r.Index + 1})
                    Return False
                End If

                ''日付チェック
                'If checkDate(changeDbNull(r.Cells(Me.colStudentsStart.Name).Value)) = False Then
                '    Message.MessageShow("E014", {dgvStudent.Columns(Me.colStudentsStart.Name).HeaderText, r.Index + 1})
                '    Return False
                'End If
                'If Utility.isHankaku(changeDbNull(r.Cells(Me.colStudentsStart.Name).Value)) = False Then
                '    Message.MessageShow("E015", {dgvStudent.Columns(Me.colStudentsStart.Name).HeaderText, r.Index + 1})
                '    Return False
                'End If

                'If checkDate(changeDbNull(r.Cells(Me.colStudentsEnd.Name).Value)) = False Then
                '    Message.MessageShow("E014", {dgvStudent.Columns(Me.colStudentsEnd.Name).HeaderText, r.Index + 1})
                '    Return False
                'End If
                'If Utility.isHankaku(changeDbNull(r.Cells(Me.colStudentsEnd.Name).Value)) = False Then
                '    Message.MessageShow("E015", {dgvStudent.Columns(Me.colStudentsEnd.Name).HeaderText, r.Index + 1})
                '    Return False
                'End If

                ''受験期間大小チェック
                'If Date.Parse(changeDbNull(r.Cells(Me.colStudentsStart.Name).Value)) > Date.Parse(changeDbNull(r.Cells(Me.colStudentsEnd.Name).Value)) Then
                '    Message.MessageShow("E016", {r.Index + 1})
                '    Return False
                'End If

                ''受講期間が利用期間外の場合
                'Dim daterow As DataRow = r.DataBoundItem.Row
                'If Not (Date.Parse(daterow("TESTSTART")) <= r.Cells(Me.colStudentsStart.Name).Value _
                '        And r.Cells(Me.colStudentsEnd.Name).Value <= daterow("TESTEND")) Then
                '    Message.MessageShow("E060", {r.Index + 1})
                '    Return False
                'End If

            End If
        Next
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
    ''' 削除前のチェックを行う
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function delCheck() As Boolean
        delCheck = True
        'チェック
        If Not checkFlg() Then
            Return False
        End If

        If dgvStudent.Rows.Count = 0 Then
            Message.MessageShow("E021", {"データ"})
            Return False
        End If

        For Each r As DataGridViewRow In dgvStudent.Rows
            If r.Cells(colCheck.Name).Value Then
                If r.DataBoundItem.row.Item("TESTCOUNT").ToString > 0 Then
                    Message.MessageShow("E045", {r.Index + 1})
                    Return False
                End If
            End If
        Next
    End Function

    ''' <summary>
    ''' 更新処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Function upDateStudent() As Boolean
        upDateStudent = True

        '最新データ取得
        mekeTempDirectry()
        If Not DataManager.GetInstance.DownLoadFile(Common.Constant.CST_STUDENT_FILENAME, tempDirectry) Then Return False

        For Each r As DataGridViewRow In dgvStudent.Rows
            If r.Cells(colCheck.Name).Value Then
                If r.Cells(colPassWord.Name).Value = _
                    CType(r.DataBoundItem.row, DataRow).Item("OLDPASSWORD").ToString Then
                    loadNewPassWord(r)
                End If
                loadNewTestCount(r)
                updateStudentFile(r.Cells(colGroupCode.Name).Value, r.DataBoundItem.row)
            Else
                loadTempStudent(r)
            End If

        Next

        If Not DataManager.GetInstance.UpLoadFile() Then Return False

        dtStudent = dgvStudent.DataSource
        dtStudent.AcceptChanges()
        dgvStudent.DataSource = dtStudent

        Message.MessageShow("I004")
    End Function

    ''' <summary>
    ''' 新パスワード読み込み
    ''' </summary>
    ''' <param name="dgvr"></param>
    ''' <remarks></remarks>
    Private Sub loadNewPassWord(ByRef dgvr As DataGridViewRow)
        Dim dr As DataRow = CType(dgvr.DataBoundItem.row, DataRow)
        Dim fileName As String = tempDirectry & Common.Constant.CST_STUDENT_FILENAME & dr.Item("GROUPCODE").ToString() & Common.Constant.CST_EXTENSION_XML
        Dim dt As New DataTable

        If IO.File.Exists(fileName) Then
            dt = Serialize.XmlToDataTableFullPath(fileName)
        End If

        If dt.Rows.Count > 0 Then
            Dim foundDataRow As DataRow() = dt.Select("USERID = '" & dgvr.Cells(colUserId.Name).Value & "'")
            If foundDataRow.Length > 0 Then
                If dgvr.Cells(colPassWord.Name).Value <> foundDataRow(0).Item("PASSWORD").ToString Then
                    dgvr.Cells(colPassWord.Name).Value = foundDataRow(0).Item("PASSWORD").ToString
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 新パスワード読み込み
    ''' </summary>
    ''' <param name="dgvr"></param>
    ''' <remarks></remarks>
    Private Sub loadTempStudent(ByRef dgvr As DataGridViewRow)
        Dim dr As DataRow = CType(dgvr.DataBoundItem.row, DataRow)
        Dim fileName As String = tempDirectry & Common.Constant.CST_STUDENT_FILENAME & dr.Item("GROUPCODE").ToString() & Common.Constant.CST_EXTENSION_XML
        Dim dt As New DataTable

        If IO.File.Exists(fileName) Then
            dt = Serialize.XmlToDataTableFullPath(fileName)
        End If

        If dt.Rows.Count > 0 Then
            Dim foundDataRow As DataRow() = dt.Select("USERID = '" & dgvr.Cells(colUserId.Name).Value & "'")
            If foundDataRow.Length > 0 Then
                CType(dgvr.DataBoundItem.row, DataRow).ItemArray = foundDataRow(0).ItemArray
            End If
        End If
    End Sub

    ''' <summary>
    ''' テストカウント読み込み
    ''' </summary>
    ''' <param name="dgvr"></param>
    ''' <remarks></remarks>
    Private Sub loadNewTestCount(ByRef dgvr As DataGridViewRow)
        Dim dr As DataRow = dgvr.DataBoundItem.row
        Dim fileName As String = tempDirectry & Common.Constant.CST_STUDENT_FILENAME & dr.Item("GROUPCODE").ToString() & Common.Constant.CST_EXTENSION_XML
        Dim dt As New DataTable

        If IO.File.Exists(fileName) Then
            dt = Serialize.XmlToDataTableFullPath(fileName)
        End If

        If dt.Rows.Count > 0 Then
            Dim foundDataRow As DataRow() = dt.Select("USERID = '" & dgvr.Cells(colUserId.Name).Value & "'")
            If foundDataRow.Length > 0 Then
                If dr.Item("TESTCOUNT") <> foundDataRow(0).Item("TESTCOUNT").ToString Then
                    dr.Item("TESTCOUNT") = foundDataRow(0).Item("TESTCOUNT").ToString
                End If
                If dr.Item("UPLOADDATE") <> foundDataRow(0).Item("UPLOADDATE").ToString Then
                    dr.Item("UPLOADDATE") = foundDataRow(0).Item("UPLOADDATE").ToString
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 削除処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Function delStudent() As Boolean
        For Each r As DataGridViewRow In dgvStudent.Rows
            If r.Cells(colCheck.Name).Value Then
                delStudentFile(r.Cells(colGroupCode.Name).Value, r.DataBoundItem.row)
            End If
        Next
        dtStudent = dgvStudent.DataSource
        dtStudent.AcceptChanges()
        dgvStudent.DataSource = dtStudent

        If Not DataManager.GetInstance.UpLoadFile() Then Return False

        Message.MessageShow("I006")
        Return True

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
    ''' 文字を全角大文字に変更
    ''' </summary>
    Private Function changeToupperAndWide(ByVal section As String) As String
        changeToupperAndWide = StrConv(section.ToUpper, VbStrConv.Wide)
    End Function

    ''' <summary>
    ''' 受講者ファイルの更新
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <remarks></remarks>
    Private Sub updateStudentFile(ByVal groupCode As String, ByVal dr As DataRow)
        Dim dt As New DataTable
        Dim fileName As String = Common.Constant.CST_STUDENT_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML
        Dim Student As New Student
        dt = Student.GetAll(fileName)

        Dim foundDatarow As DataRow() = dt.Select("USERID = '" & dr.Item("USERID").ToString & "'")
        If foundDatarow.Length > 0 Then
            foundDatarow(0).Item(Student.ColumnIndex.UserId) = dr.Item(Student.ColumnIndex.UserId)
            foundDatarow(0).Item(Student.ColumnIndex.Name) = dr.Item(Student.ColumnIndex.Name)
            foundDatarow(0).Item(Student.ColumnIndex.Section1) = dr.Item(Student.ColumnIndex.Section1)
            foundDatarow(0).Item(Student.ColumnIndex.Section2) = dr.Item(Student.ColumnIndex.Section2)
            foundDatarow(0).Item(Student.ColumnIndex.Password) = dr.Item(Student.ColumnIndex.Password)
            foundDatarow(0).Item(Student.ColumnIndex.Note) = dr.Item(Student.ColumnIndex.Note)
            foundDatarow(0).Item(Student.ColumnIndex.TestCount) = dr.Item(Student.ColumnIndex.TestCount)
            foundDatarow(0).Item(Student.ColumnIndex.UpLoadDate) = dr.Item(Student.ColumnIndex.UpLoadDate)
            foundDatarow(0).Item(Student.ColumnIndex.StudentsStart) = dr.Item("STUDENTSSTART")
            foundDatarow(0).Item(Student.ColumnIndex.StudentsEnd) = dr.Item("STUDENTSEND")
            foundDatarow(0).Item(Student.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
        End If

        Serialize.DataTableToxml(dt, fileName)
    End Sub

    ''' <summary>
    ''' 学生ファイル削除
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <remarks></remarks>
    Private Sub delStudentFile(ByVal groupCode As String, ByVal dr As DataRow)
        ''学生削除
        Dim dt As New DataTable
        Dim fileName As String = Common.Constant.CST_STUDENT_FILENAME & groupCode & Common.Constant.CST_EXTENSION_XML
        Dim Student As New Student
        dt = Student.GetAll(fileName)

        Dim foundDatarow As DataRow() = dt.Select("USERID = '" & dr.Item("USERID").ToString & "'")
        If foundDatarow.Length > 0 Then
            dt.Rows.Remove(foundDatarow(0))
        End If

        If dt.Rows.Count > 0 Then
            Serialize.DataTableToxml(dt, fileName)
        Else
            logger.Info("Start:delStudentFile FileName:" & fileName)
            IO.File.Delete(Common.Constant.GetTempPath & fileName)
            'サーバのファイルを削除
            logger.Info("End:delStudentFile FileName:" & fileName)
        End If

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
    ''' 受講者数と利用期間を設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setStudentCountAndUsePeriod()
        'Dim drGroup As DataRow = CType(cmbGroupCode.SelectedItem.row, DataRow)
        'If Not drGroup.Item(Group.ColumnIndex.GroupCode) Is DBNull.Value And String.Compare(drGroup.Item(Group.ColumnIndex.GroupCode), Common.Constant.CST_ALL) <> 0 Then
        '    lblUsePeriod.Text = Format(Date.Parse(drGroup.Item(Group.ColumnIndex.TestStart)), "yyyy年MM月dd日") & "～" & Format(Date.Parse(drGroup.Item(Group.ColumnIndex.TestEnd)), "yyyy年MM月dd日")
        '    lblStudentCount.Text = drGroup.Item(Group.ColumnIndex.StudentCount)
        '    '受講者ファイル読み込み
        '    If IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_STUDENT_FILENAME & drGroup.Item(Group.ColumnIndex.GroupCode) & Common.Constant.CST_EXTENSION_XML) Then
        '        dtStudent = Student.GetAll(Common.Constant.CST_STUDENT_FILENAME & drGroup.Item(Group.ColumnIndex.GroupCode) & Common.Constant.CST_EXTENSION_XML)
        '        lblStudentSumCount.Text = dtStudent.Rows.Count
        '    Else
        '        lblStudentSumCount.Text = dtStudent.Rows.Count
        '    End If
        'Else
        '    lblUsePeriod.Text = ""
        '    lblStudentSumCount.Text = ""
        '    lblStudentCount.Text = ""
        'End If
        lblStudentSumCount.Text = dgvStudent.RowCount
    End Sub

#End Region

End Class