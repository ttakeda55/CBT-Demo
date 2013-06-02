Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Public Class frmMail
    Private dataBanker As DataBanker = dataBanker.GetInstance
    Private groupCode As String
    Private groupManagerId As String = ""
    Private loginUserId As String = dataBanker("USERID")
    Private loginUserName As String = dataBanker("USERNAME")
    Private fileNameUserId As String = ""
    Private dtGroup As New DataTable
    Private dtStudent As New DataTable

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "メール"
        lblBottomCode.Text = "CG02"
        lblBottomName.Text = "メール画面"

        dtGroup = loadGroupFile()
        dtStudent = loadStudentFile()

        'メール読み込み
        dgvUser.AutoGenerateColumns = False

        '画面設定
        setFrom()

    End Sub

    ''' <summary>
    ''' フォーム画面にメッセージを設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setFrom()
        'グリッドに設定
        If dtGroup.Rows.Count > 0 Then
            groupCode = dtGroup.Rows(0).Item("GROUPCODE")
            groupManagerId = dtGroup.Rows(0).Item("GROUPMANAGERID")
        End If

        If dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_GROUP Then
            dgvUser.Columns(colUser.Name).DataPropertyName = "NAME"
            dgvUser.Columns(colUserId.Name).DataPropertyName = "USERID"
            dtStudent.DefaultView.Sort = "USERID ASC"
            dgvUser.DataSource = dtStudent
        ElseIf dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_STUDENT Then
            dgvUser.Columns(colUser.Name).DataPropertyName = "GROUPMANAGERNAME"
            fileNameUserId = loginUserId
            dgvUser.DataSource = dtGroup
            For i = 0 To dgvUser.RowCount - 1
                dgvUser.Rows(i).Cells(colUserId.Name).Value = loginUserId
            Next
        End If

        For i = 0 To dgvUser.RowCount - 1
            'メッセージを表示
            If IO.File.Exists(makeFileName(dgvUser.Rows(i))) Then
                dgvUser.Rows(i).Cells(colMessage.Name).Value = IO.File.ReadAllText(makeFileName(dgvUser.Rows(i)))
            End If
        Next

        For i = 0 To dgvUser.RowCount - 1
            countSendAndReceive(dgvUser.Rows(i))
        Next

        If dgvUser.RowCount > 0 Then
            txtMailLog.Text = setMessage(dgvUser.CurrentRow)
        End If

    End Sub

    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' ファイル名の作成
    ''' </summary>
    ''' <param name="datarow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function makeFileName(ByRef datarow As DataGridViewRow) As String
        Return Constant.GetTempPath & Constant.CST_MAIL_FILENAME & groupCode & "_" & datarow.Cells(colUserId.Name).Value & Constant.CST_EXTENSION_TXT
    End Function

    ''' <summary>
    ''' 送信ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendMail.Click
        Try

            '０件チェック
            If dgvUser.RowCount = 0 Then Exit Sub

            '入力チェック
            If txtMail.Text = "" Then
                Message.MessageShow("E005", {"メッセージ"})
                Exit Sub
            End If

            'メールログ作成
            makeMessage()

            setFrom()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' メッセージを設定する
    ''' </summary>
    ''' <param name="datarow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setMessage(ByVal datarow As DataGridViewRow) As String
        Dim message As String = datarow.Cells(colMessage.Name).Value
        If message = Nothing Then
            Return String.Empty
        End If

        '新着チェック
        Dim machPattern As String = "^" & Constant.CST_NEWMAIL & loginUserId & "$"
        Dim mcs = System.Text.RegularExpressions.Regex.Matches( _
        message, machPattern, System.Text.RegularExpressions.RegexOptions.Multiline)

        If mcs.Count = 0 Then
            IO.File.WriteAllText(makeFileName(datarow), Split(message, Constant.CST_NEWMAIL, -1, CompareMethod.Binary)(0))
        End If

        datarow.Cells(colMessage.Name).Value = message
        message = countSendAndReceive(datarow)

        Return Split(message, Constant.CST_NEWMAIL, -1, CompareMethod.Binary)(0)

    End Function

    ''' <summary>
    ''' 送受信件数を取得する。
    ''' </summary>
    ''' <param name="datarow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function countSendAndReceive(ByRef datarow As DataGridViewRow) As String
        Dim message As String = datarow.Cells(colMessage.Name).Value
        If message Is Nothing Then
            Return String.Empty
        End If

        Dim mcs = System.Text.RegularExpressions.Regex.Matches(message, "count!.*?![0-9]*")
        Dim mcsCount = Nothing
        Dim sendCount As Integer = 0
        Dim ReceiveCount As Integer = 0
        Dim ar As New ArrayList
        For Each mc As System.Text.RegularExpressions.Match In mcs
            message = message.Replace(mc.Value & vbCrLf, "")
            ar.Add(mc.Value.ToString.Replace("count!", "").Split("!"))
        Next

        For Each Str As String() In ar
            If dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_GROUP Then
                If groupManagerId <> Str(0) Then
                    ReceiveCount = Str(1)
                Else
                    sendCount = Str(1)
                End If
            ElseIf dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_STUDENT Then
                If datarow.Cells(colUserId.Name).Value <> Str(0) Then
                    ReceiveCount = Str(1)
                Else
                    sendCount = Str(1)
                End If

            End If
        Next

        datarow.Cells(colSend.Name).Value = sendCount
        datarow.Cells(colReceive.Name).Value = ReceiveCount

        Return message
    End Function

    ''' <summary>
    ''' メッセージを作成する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub makeMessage()
        Dim message As String
        Dim newMail As String
        message = "===========================" & vbCrLf & _
                  "氏名：" & loginUserName & vbCrLf & _
                  "日時：" & System.DateTime.Now.ToShortDateString & " " & System.DateTime.Now.ToShortTimeString & vbCrLf & _
                  "===========================" & vbCrLf
        txtMailLog.Text = message & txtMail.Text & vbCrLf & vbCrLf & txtMailLog.Text

        txtMail.Text = ""

        If message.ToString.IndexOf(Constant.CST_NEWMAIL & loginUserId) > 0 Then
            newMail = ""
        Else
            newMail = Constant.CST_NEWMAIL & loginUserId
        End If

        'ファイル作成
        'ヘッダ作成
        message = makeHeader(txtMailLog.Text)

        IO.File.WriteAllText(makeFileName(dgvUser.CurrentRow), _
                             message & newMail)

        Dim fileName As String = System.IO.Path.GetFileName(makeFileName(dgvUser.CurrentRow))
        Try
            'If Not WebServiceWrapper.GetInstance.FileUpLoad_DATA(fileName, IO.File.ReadAllBytes(Common.Constant.GetTempPath & fileName)) Then
            '    Common.Message.MessageShow("E033")
            'End If
        Catch ex As Exception
            writeErrorLog("makeMessage", ex.Message)
            Common.Message.MessageShow("E043")
        End Try
    End Sub

    ''' <summary>
    ''' メッセージファイルのヘッダ作成
    ''' </summary>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function makeHeader(ByVal message As String) As String
        Dim sendCount As Integer = dgvUser.CurrentRow.Cells(colSend.Name).Value
        Dim ReceiveCount As Integer = dgvUser.CurrentRow.Cells(colReceive.Name).Value

        If dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_GROUP Then
            message = "count!" & groupManagerId & "!" & sendCount + 1 & vbCrLf & _
                      "count!" & dgvUser.CurrentRow.Cells(colUserId.Name).Value & "!" & ReceiveCount & vbCrLf & message
            fileNameUserId = dgvUser.CurrentRow.Cells(colUserId.Name).Value
        ElseIf dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_STUDENT Then
            message = "count!" & loginUserId & "!" & sendCount + 1 & vbCrLf & _
                      "count!" & groupManagerId & "!" & ReceiveCount & vbCrLf & message
            fileNameUserId = loginUserId
        End If

        Return message
    End Function

    ''' <summary>
    ''' 団体ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadGroupFile() As DataTable
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Constant.GetTempPath, Constant.CST_GROUP_FILENAME & "*")
            dt.Merge(Serialize.XmlToDataTable(IO.Path.GetFileName(fileName)))
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 受講者ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadStudentFile() As DataTable
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Constant.GetTempPath, Constant.CST_STUDENT_FILENAME & "*")
            dt.Merge(Serialize.XmlToDataTable(IO.Path.GetFileName(fileName)))
        Next
        Return dt
    End Function

    ''' <summary>
    ''' セルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvUser_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUser.CellClick
        changeCell()
    End Sub

    Private Sub dgvUser_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvUser.SelectionChanged
        changeCell()
    End Sub

    Private Sub changeCell()
        Dim rowIndex As Integer = dgvUser.CurrentRow.Index
        Dim datarow As DataRow = CType(dgvUser.Rows(rowIndex).DataBoundItem.row, DataRow)

        If dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_GROUP Then
            fileNameUserId = datarow("USERID")
            txtMailLog.Text = setMessage(dgvUser.CurrentRow)
        End If
    End Sub

    ''' <summary>
    ''' エラーログ出力
    ''' </summary>
    ''' <param name="eventName"></param>
    ''' <remarks></remarks>
    Private Shared Sub writeErrorLog(ByVal eventName As String, ByVal exMessage As String)
        Dim filename As String = Application.StartupPath.ToString & "\Error" & System.DateTime.Now.ToShortDateString.Replace("/", "") & ".log"
        Using sw As IO.StreamWriter = New IO.StreamWriter(filename, True)
            sw.Write(System.DateTime.Now & "." & Format(System.DateTime.Now.Millisecond, "000"))
            sw.Write(",")
            sw.Write(eventName)
            sw.Write(",")
            sw.Write(exMessage)
            sw.Write(",")
            sw.Write(Application.ProductVersion)
            sw.Write(vbCrLf)
        End Using
    End Sub
End Class