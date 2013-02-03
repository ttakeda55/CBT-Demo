Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
''' <summary>
''' 団体登録(TG03)<br/>
''' <img src="..\Images\TG03.png" />
''' </summary>
''' <remarks>
''' 2011/09/07 NOZAO 新規作成
''' </remarks>
Public Class frmGroupManagerAdd
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
    Private Sub frmGroupManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Text = "団体新規登録"
            lblBottomCode.Text = "TG02"
            lblBottomName.Text = "団体新規登録画面"

            cmbCourse.DataSource = setCourseCmb()
            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' システム管理者メニューへ戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            logger.Start()
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 団体登録／修正メニューへ戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackGroup.Click
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
    ''' パスワード発行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPassWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassWord.Click
        Try
            logger.Start()
            txtGroupManagerPassWrod.Text = Utility.GeneratePassword(8, Common.Constant.CST_PASSWORDCHARS)
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 登録ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            logger.Start()
            '入力チェック
            If Not inputCheck() Then
                Exit Sub
            End If

            'ファイル出力
            If exportGroupFile() Then
                Message.MessageShow("I001")
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
    ''' コードLeaveイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>小文字を大文字に変換します。</remarks>
    Private Sub txtGroupCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroupCode.Leave
        Try
            txtGroupCode.Text = txtGroupCode.Text.ToUpper
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' フォーカスアウト時trimする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub trim_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtGroupCode.Leave, _
                txtGroupName.Leave, _
                txtApplicant.Leave, _
                txtGroupManagerId.Leave, _
                txtGroupManagerName.Leave, _
                txtGroupManagerPassWrod.Leave, _
                txtStudentCount.Leave
        Try
            sender.text = sender.text.ToString.Trim

            If CType(sender, TextBox).Name = txtGroupCode.Name Then
                txtGroupCode.Text = txtGroupCode.Text.Replace(" ", "").Replace("　", "")
            End If
            If CType(sender, TextBox).Name = txtGroupManagerId.Name Then
                txtGroupManagerId.Text = txtGroupManagerId.Text.Replace(" ", "").Replace("　", "")
            End If
            If CType(sender, TextBox).Name = txtStudentCount.Name Then
                txtStudentCount.Text = txtStudentCount.Text.Replace(" ", "").Replace("　", "")
            End If
            If CType(sender, TextBox).Name = txtGroupManagerPassWrod.Name Then
                txtGroupManagerPassWrod.Text = txtGroupManagerPassWrod.Text.Replace(" ", "").Replace("　", "")
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ユーザIDLeaveイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>小文字を大文字に変換します。</remarks>
    Private Sub txtGroupManagerId_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroupManagerId.Leave
        Try
            txtGroupManagerId.Text = txtGroupManagerId.Text.ToUpper
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' 受講終了日を３週間後に設定
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub dtpTestStart_TextChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTestStart.TextChange
    '    Try
    '        If IsDate(dtpTestStart.Text) Then
    '            If dtpTestStart.MaskCompleted Then
    '                dtpTestEnd.Text = Date.Parse(dtpTestStart.Text).AddDays(20)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        logger.Error(ex)
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

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
    ''' 登録内容をファイルにエクスポートします。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function exportGroupFile() As Boolean
        exportGroupFile = True

        Dim fileName As String = Common.Constant.CST_GROUP_FILENAME & txtGroupCode.Text.Trim & Common.Constant.CST_EXTENSION_XML

        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            Message.MessageShow("E008", {"コード"})
            Return False
        End If

        If Message.MessageShow("Q001") <> DialogResult.OK Then
            Return False
        End If

        Dim group As New DataTable
        Common.XmlSchema.GetGroupSchema(group)

        group.Rows.Add()
        group.Rows(0).Item("GROUPCODE") = txtGroupCode.Text.Trim
        group.Rows(0).Item("GROUPNAME") = txtGroupName.Text.Trim
        group.Rows(0).Item("APPLICANT") = txtApplicant.Text.Trim
        group.Rows(0).Item("COURSE") = cmbCourse.Text
        group.Rows(0).Item("STUDENTCOUNT") = CInt(txtStudentCount.Text.Trim)
        group.Rows(0).Item("TESTSTART") = dtpTestStart.ToShortDateString
        group.Rows(0).Item("TESTEND") = dtpTestEnd.ToShortDateString
        group.Rows(0).Item("GROUPMANAGERID") = txtGroupManagerId.Text.Trim
        group.Rows(0).Item("GROUPMANAGERNAME") = txtGroupManagerName.Text.Trim
        group.Rows(0).Item("PASSWORD") = txtGroupManagerPassWrod.Text.Trim
        group.Rows(0).Item("STATE") = ""
        group.Rows(0).Item("FIRSTSTSRTDAY") = ""
        group.Rows(0).Item("FIRSTENDDAY") = ""
        group.Rows(0).Item("SECONDSTSRTDAY") = ""
        group.Rows(0).Item("SECONDENDDAY") = ""
        group.Rows(0).Item("COURSENO") = cmbCourse.SelectedValue
        group.Rows(0).Item("CREATE_DATE") = System.DateTime.Now.ToString
        group.Rows(0).Item("UPDATE_DATE") = System.DateTime.Now.ToString

        Serialize.DataTableToxml(group, fileName)

        'ファイルアップロード
        processMessageUpload = True
        Common.DataManager.GetInstance.UpLoadFile()

    End Function

    ''' <summary>
    ''' 入力チェックを行います。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        Dim check As Boolean = True

        '必須チェック
        If txtGroupCode.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"コード"})
            Return False
        End If
        If txtGroupName.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"団体名"})
            Return False
        End If
        If txtApplicant.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"申込者"})
            Return False
        End If
        If cmbCourse.Text = String.Empty Then
            Message.MessageShow("E005", {"コース名"})
            Return False
        End If
        If txtStudentCount.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"受講者数"})
            Return False
        End If
        If dtpTestStart.MaskCompleted = False Then
            Message.MessageShow("E005", {"受講開始日"})
            Return False
        End If
        If dtpTestEnd.MaskCompleted = False Then
            Message.MessageShow("E005", {"受講終了日"})
            Return False
        End If
        If txtGroupManagerId.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"ユーザID"})
            Return False
        End If
        If txtGroupManagerName.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"管理者氏名"})
            Return False
        End If
        If txtGroupManagerPassWrod.Text.Trim = String.Empty Then
            Message.MessageShow("E005", {"パスワード"})
            Return False
        End If

        '桁数チェック
        If txtGroupManagerPassWrod.Text.Length < 6 Then
            Message.MessageShow("E035", {"パスワード"})
            Return False
        End If
        'パスワード禁止文字チェック
        If Utility.IsNgChar(txtGroupManagerPassWrod.Text, Common.Constant.CST_PASSWORDCHARS_NG) Then
            Dim chars As String = Common.Constant.CST_PASSWORDCHARS_NG
            Dim str As String = ""
            For Each chr As Char In chars
                str &= "[" & chr.ToString & "]"
            Next
            Message.MessageShow("E050", {str})
            Return False
        End If
        '半角英大文字チェック
        If Utility.IsUpperCase(txtGroupManagerPassWrod.Text) Then
            Message.MessageShow("E051")
            Return False
        End If

        '半角チェック
        If Utility.isHankaku(txtGroupCode.Text) = False Then
            Message.MessageShow("E009", {"コード"})
            Return False
        End If
        If Utility.isHankaku(txtGroupManagerId.Text) = False Then
            Message.MessageShow("E009", {"ユーザID"})
            Return False
        End If
        If Utility.isHankaku(txtGroupManagerPassWrod.Text) = False Then
            Message.MessageShow("E009", {"パスワード"})
            Return False
        End If

        '英数チェック
        If Utility.IsHalfAlphaNum(txtGroupCode.Text) = False Then
            Message.MessageShow("E036", {"コード"})
            Return False
        End If
        If Utility.IsHalfAlphaNum(txtGroupManagerId.Text) = False Then
            Message.MessageShow("E036", {"ユーザID"})
            Return False
        End If
        If Utility.IsHalfAlphaNum(txtGroupManagerPassWrod.Text) = False Then
            Message.MessageShow("E036", {"パスワード"})
            Return False
        End If

        '数値チェック
        If Not Utility.IsInteger(txtStudentCount.Text) Then
            Message.MessageShow("E006", {"受講者数"})
            Return False
        End If
        '受講者数0チェック
        If CInt(txtStudentCount.Text) = 0 Then
            Message.MessageShow("E042", {"受講者数"})
            Return False
        End If

        '日付チェック
        If IsDate(dtpTestStart.Text) = False Then
            Message.MessageShow("E007", {"受講開始日"})
            Return False
        End If
        If IsDate(dtpTestEnd.Text) = False Then
            Message.MessageShow("E007", {"受講終了日"})
            Return False
        End If

        '受験期間大小チェック
        If Date.Parse(dtpTestStart.Text) > Date.Parse(dtpTestEnd.Text) Then
            Message.MessageShow("E010")
            Return False
        End If

        '利用期間とコースの利用期間チェック
        If Not SystemManager.InputCheck.withinPeriodCheck(CDate(CType(cmbCourse.SelectedItem.row, DataRow).Item(Common.Course.ColumnIndex.UseStart)),
                                                   CDate(CType(cmbCourse.SelectedItem.row, DataRow).Item(Common.Course.ColumnIndex.UseEnd)),
                                                   CDate(dtpTestStart.ToShortDateString),
                                                   CDate(dtpTestEnd.ToShortDateString)) Then
            Message.MessageShow("E079", {String.Empty})
            Return False
        End If

        '重複チェック
        Dim dtGroup As DataTable = loadGroupFile()
        If dtGroup.Rows.Count > 0 Then
            Dim foundDataRow() As DataRow = dtGroup.Select("GROUPMANAGERID = '" & txtGroupManagerId.Text & "'")
            If foundDataRow.Length > 0 Then
                Message.MessageShow("E049", {"ユーザID"})
                Return False
            End If
        End If
        Return True
    End Function

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
    ''' コースコンボ設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setCourseCmb() As DataTable
        setCourseCmb = Nothing
        Dim dtCourse As DataTable = Course.GetAll(Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML)
        Dim dtCourseDisp As New DataTable
        Dim nowDay As String = Format(Date.Now, "yyyy/MM/dd")
        dtCourseDisp = dtCourse.Clone
        dtCourseDisp.Rows.Add()
        With dtCourseDisp.Rows(0)
            .Item("COURSENO") = ""
            .Item("COURSE") = ""
        End With
        For Each row As DataRow In dtCourse.Select("STATE = '1'  OR ( STATE = '2' AND USESTART <= '" & nowDay & "' AND USESTART <> '') ", "COURSE")
            dtCourseDisp.ImportRow(row)
        Next

        Return dtCourseDisp
    End Function
#End Region

End Class