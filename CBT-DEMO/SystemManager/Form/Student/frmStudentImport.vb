Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.CBTCommon
''' <summary>
''' 受講者一括登録(TG06)<br/>
''' <img src="..\Images\TG06.png" />
''' </summary>
''' <remarks>
''' 2011/09/06 nozao 新規作成
''' </remarks>
Public Class frmStudentImport
#Region "メンバ変数"
    Private dtGroup As New DataTable
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "イベントハンドラ"
    ''' <summary>
    ''' システム管理画面に戻る
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
    ''' 受講者画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackStudent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackStudent.Click
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
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMenberImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Text = "受講者一括登録"
            lblBottomCode.Text = "TG05"
            lblBottomName.Text = "一括登録画面"

            '団体ファイルのロード
            dtGroup = loadGroupFile()

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 参照ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReference.Click
        Try
            'OpenFileDialogクラスのインスタンスを作成
            Dim ofd As New OpenFileDialog()

            ofd.Filter = "CSVファイル(*.csv)|*.csv"
            ofd.FilterIndex = 1
            ofd.Title = "開くファイルを選択してください"
            ofd.RestoreDirectory = True
            ofd.CheckFileExists = True
            ofd.CheckPathExists = True

            'ダイアログを表示する
            If ofd.ShowDialog() = DialogResult.OK Then
                'OKボタンがクリックされたとき
                '選択されたファイル名を表示する
                Me.txtFilePath.Text = ofd.FileName.ToString
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 登録、データチェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataCheck.Click
        Try
            logger.Start()
            '入力チェック
            If Not inputCheck() Then
                Exit Sub
            End If

            'インポート処理
            Dim studentCSV As New ArrayList
            If Not importCSV(txtFilePath.Text, studentCSV) Then
                Message.MessageShow("E019")
                Exit Sub
            End If

            'インポート内容チェック
            If Not importCheck(studentCSV) Then
                Exit Sub
            End If

            Message.MessageShow("I005")

            'ユーザIDの変更
            changeUserId(studentCSV)
            ''区分の値変更
            'changeSection(studentCSV)
            ''受講期間の値の変更
            'changeStudentsDate(studentCSV)

            'パラメータ設定
            Dim databanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            databanker("STUDENTCSV") = studentCSV
            'Dim drGroup As DataRow = CType(cmbGroupCode.SelectedItem.row, DataRow)
            'databanker("TESTSTART") = Format(Date.Parse(drGroup.Item("TESTSTART")), "yyyy年MM月dd日")
            'databanker("TESTEND") = Format(Date.Parse(drGroup.Item("TESTEND")), "yyyy年MM月dd日")

            '画面遷移
            Dim frm As New frmImportCheck
            frm.ShowDialog(Me)
            If databanker.GetInstance().Item("LOGOUT") Then
                Close()
            End If

            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                txtFilePath.Text = ""
            End If

            Me.Visible = True
            logger.End()
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
    ''' インポート後チェック
    ''' </summary>
    ''' <param name="studentCSV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function importCheck(ByVal studentCSV As ArrayList) As Boolean
        importCheck = True
        Dim message As String = ""

        ''受講者数チェック
        'If Not cehckStudentCount(studentCSV) Then
        '    Return False
        'End If

        '不足項目チェック
        message += cehckBrank(studentCSV)

        'エラー
        If message <> "" Then
            MessageBox.Show(message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        'ユーザIDチェック
        message += checkUserId(studentCSV)

        ''区分チェック
        'message += checkSection(studentCSV)

        ''受講期間チェック
        'message += checkStudents(studentCSV)

        'ファイル内ユーザID重複チェック
        message += checkOverlap(studentCSV)

        '既存ファイルユーザID重複チェック
        message += checkExistStudent(studentCSV)

        'エラー
        If message <> "" Then
            MessageBox.Show(message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            importCheck = False
        End If
    End Function

    ' ''' <summary>
    ' ''' 受講者数チェック
    ' ''' </summary>
    'Private Function cehckStudentCount(ByVal studentCSV As ArrayList) As Boolean
    '    cehckStudentCount = True
    '    'If studentCSV.Count - 1 <> txtStudentCount.Text Then
    '    '    Common.Message.MessageShow("E020")
    '    '    Return False
    '    'End If

    '    Dim group As New DataTable
    '    group = Serialize.XmlToDataTable(Common.Constant.CST_GROUP_FILENAME & cmbGroupCode.Text & Common.Constant.CST_EXTENSION_XML)
    '    Dim student As New DataTable
    '    If IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_STUDENT_FILENAME & cmbGroupCode.Text & Common.Constant.CST_EXTENSION_XML) Then
    '        student = Serialize.XmlToDataTable(Common.Constant.CST_STUDENT_FILENAME & cmbGroupCode.Text & Common.Constant.CST_EXTENSION_XML)
    '    End If

    '    Dim studentCount As Integer = 0
    '    If group.Rows.Count > 0 Then
    '        studentCount = CInt(group.Rows(0).Item("STUDENTCOUNT").ToString)
    '    End If
    '    'Dim addStudentCount As Integer = CInt(txtStudentCount.Text) + Student.Rows.Count

    '    'If studentCount < addStudentCount Then
    '    '    Common.Message.MessageShow("E047")
    '    '    Return False
    '    'End If

    'End Function

    ''' <summary>
    ''' 不足項目チェック
    ''' </summary>
    Private Function cehckBrank(ByVal studentCSV As ArrayList) As String
        Dim Message As String = ""
        For i = 0 To studentCSV.Count - 1
            'ユーザID
            If studentCSV(i)(0) = "" Then
                Message += "ユーザIDが入力されていません。（" & i & "行目）" & vbCrLf
            End If
            '氏名
            If studentCSV(i)(1) = "" Then
                Message += "氏名が入力されていません。（" & i & "行目）" & vbCrLf
            End If
            ''区分１
            'If studentCSV(i)(2) = "" Then
            '    Message += "区分１が入力されていません。（" & i & "行目）" & vbCrLf
            'End If
            ''区分２
            'If studentCSV(i)(3) = "" Then
            '    Message += "区分２が入力されていません。（" & i & "行目）" & vbCrLf
            'End If
            ''受講開始日
            'If studentCSV(i)(4) = "" Then
            '    Message += "受講開始日が入力されていません。（" & i & "行目）" & vbCrLf
            'End If
            ''受講終了日
            'If studentCSV(i)(5) = "" Then
            '    Message += "受講終了日が入力されていません。（" & i & "行目）" & vbCrLf
            'End If
        Next
        Return Message
    End Function

    ''' <summary>
    ''' ファイル内ユーザID重複チェック
    ''' </summary>
    Private Function checkOverlap(ByVal studentCSV As ArrayList) As String
        Dim Message As String = ""
        For i = 0 To studentCSV.Count - 1
            For j = i + 1 To studentCSV.Count - 1
                If studentCSV(i)(0) = studentCSV(j)(0) Then
                    If Message.IndexOf(studentCSV(i)(0)) = -1 Then
                        If Message.IndexOf("ユーザIDがファイル内で重複しています。（") = -1 Then
                            Message += "ユーザIDがファイル内で重複しています。（" & studentCSV(i)(0)
                        Else
                            Message += "," & studentCSV(i)(0)
                        End If
                    End If
                End If
            Next
        Next

        If Message <> "" Then
            Message += "）" & vbCrLf
        End If

        Return Message
    End Function

    ''' <summary>
    ''' 既存ファイルユーザID重複チェック
    ''' </summary>
    Private Function checkExistStudent(ByVal studentCSV As ArrayList) As String
        Dim Message As String = ""
        Dim dtStudent As DataTable = loadStudentFile()
        Dim drStudent() As Data.DataRow
        If dtStudent.Rows.Count > 0 Then
            For i = 0 To studentCSV.Count - 1
                drStudent = dtStudent.Select("USERID = '" & studentCSV(i)(0) & "'")
                If drStudent.Length <> 0 Then
                    If Message.IndexOf(studentCSV(i)(0)) = -1 Then
                        If Message.IndexOf("ユーザIDは既に登録されています。（") = -1 Then
                            Message += "ユーザIDは既に登録されています。（" & studentCSV(i)(0)
                        Else
                            Message += "," & studentCSV(i)(0)
                        End If
                    End If
                End If
            Next
        End If

        If Message <> "" Then
            Message += "）" & vbCrLf
        End If

        Return Message
    End Function

    ''' <summary>
    ''' ユーザIDチェック
    ''' </summary>
    Private Function checkUserId(ByVal studentCSV As ArrayList) As String
        Dim Message As String = ""
        Dim mc As System.Text.RegularExpressions.Match

        For i = 1 To studentCSV.Count - 1
            mc = System.Text.RegularExpressions.Regex.Match(changeToupperAndNarrow(studentCSV(i)(0)), "^[a-zA-Z0-9]+$")
            If mc.Value = "" Then
                Message += "ユーザIDは半角英数字で入力してください。（" & i & "行目:" & studentCSV(i)(0) & "）" & vbCrLf
            End If
        Next

        Return Message
    End Function

    ''' <summary>
    ''' 区分チェック
    ''' </summary>
    Private Function checkSection(ByVal studentCSV As ArrayList) As String
        Dim Message As String = ""
        Dim mc As System.Text.RegularExpressions.Match
        Dim machSection1 As String = makePattern(Common.Constant.CST_SECTION1_CMB)
        Dim machSection2 As String = makePattern(Common.Constant.CST_SECTION2_CMB)

        For i = 1 To studentCSV.Count - 1
            mc = System.Text.RegularExpressions.Regex.Match(changeToupperAndWide(studentCSV(i)(2)), "^[" & machSection1 & "]$")
            If mc.Value = "" Then
                Message += "区分１は数字(１～９)１桁で入力してください。（" & i & "行目:" & studentCSV(i)(2) & "）" & vbCrLf
            End If
        Next

        For i = 1 To studentCSV.Count - 1
            mc = System.Text.RegularExpressions.Regex.Match(changeToupperAndWide(studentCSV(i)(3)), "^[" & machSection2 & "]$")
            If mc.Value = "" Then
                Message += "区分２はアルファベット(Ａ～Ｚ)１桁で入力してください。（" & i & "行目:" & studentCSV(i)(3) & "）" & vbCrLf
            End If
        Next

        Return Message
    End Function

    ''' <summary>
    ''' 受講期間チェック
    ''' </summary>
    ''' <param name="studentCSV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkStudents(studentCSV As ArrayList) As String
        Dim Message As String = ""
        Dim dateStudentsStart As Date
        Dim dateStudentsEnd As Date

        For i = 1 To studentCSV.Count - 1
            Dim errerMessage As String = ""
            '受講開始日
            If IsDate(studentCSV(i)(4)) = False Then
                errerMessage += "受講開始日が正しくありません。（" & i & "行目:" & studentCSV(i)(4) & "）" & vbCrLf
            Else
                dateStudentsStart = Date.Parse(studentCSV(i)(4))
            End If
            '受講終了日
            If IsDate(studentCSV(i)(5)) = False Then
                errerMessage += "受講終了日が正しくありません。（" & i & "行目:" & studentCSV(i)(5) & "）" & vbCrLf
            Else
                dateStudentsEnd = Date.Parse(studentCSV(i)(5))
            End If

            '受講期間の大小
            If errerMessage = String.Empty Then
                If Date.Parse(dateStudentsStart) > Date.Parse(dateStudentsEnd) Then
                    errerMessage += "受講終了日に、受講開始日より過去の日付を入力できません。（" & i & "行目:" & studentCSV(i)(4) & "-" & studentCSV(i)(5) & "）" & vbCrLf
                End If
            End If

            'Dim drGroup As DataRow = CType(cmbGroupCode.SelectedItem.row, DataRow)
            ''受講期間が利用期間外の場合
            'If errerMessage = String.Empty Then
            '    testStart = Date.Parse(drGroup.Item("TESTSTART"))
            '    testEnd = Date.Parse(drGroup.Item("TESTEND"))
            '    If Not (testStart <= dateStudentsStart And dateStudentsEnd <= testEnd) Then
            '        errerMessage += "受講期間が利用期間外です。（" & i & "行目:" & studentCSV(i)(4) & "-" & studentCSV(i)(5) & "）" & vbCrLf
            '    End If
            'End If

            Message &= errerMessage
        Next

        Return Message
    End Function

    ''' <summary>
    ''' ユーザIDの値を変更
    ''' </summary>
    ''' <param name="ar"></param>
    ''' <remarks></remarks>
    Private Sub changeUserId(ByVal ar As ArrayList)
        For Each Str As String() In ar
            Str(0) = changeToupperAndNarrow(Str(0))
        Next
    End Sub

    ''' <summary>
    ''' 区分の値を変更
    ''' </summary>
    ''' <param name="ar"></param>
    ''' <remarks></remarks>
    Private Sub changeSection(ByVal ar As ArrayList)
        For Each Str As String() In ar
            Str(2) = changeToupperAndWide(Str(2))
            Str(3) = changeToupperAndWide(Str(3))
        Next
    End Sub
    ''' <summary>
    ''' 区分の値を変更
    ''' </summary>
    ''' <param name="ar"></param>
    ''' <remarks></remarks>
    Private Sub changeStudentsDate(ByVal ar As ArrayList)
        For i = 1 To ar.Count - 1
            ar.Item(i)(4) = CDate(ar.Item(i)(4)).ToShortDateString
            ar.Item(i)(5) = CDate(ar.Item(i)(5)).ToShortDateString
        Next
    End Sub

    ''' <summary>
    ''' 文字を半角大文字に変更
    ''' </summary>
    Private Function changeToupperAndNarrow(ByVal section As String) As String
        changeToupperAndNarrow = StrConv(section.ToUpper, VbStrConv.Narrow)
    End Function

    ''' <summary>
    ''' 文字を全角大文字に変更
    ''' </summary>
    Private Function changeToupperAndWide(ByVal section As String) As String
        changeToupperAndWide = StrConv(section.ToUpper, VbStrConv.Wide)
    End Function

    ''' <summary>
    ''' 区分のマスタの文字列を生成
    ''' </summary>
    Private Function makePattern(ByVal section As String()) As String
        makePattern = ""
        For Each Str As String In section
            makePattern += Str
        Next
    End Function

    ''' <summary>
    ''' 受講者ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadStudentFile() As DataTable
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_STUDENT_FILENAME & "*")
            dt.Merge(Serialize.XmlToDataTable(IO.Path.GetFileName(fileName)))
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    Private Function inputCheck() As Boolean
        '必須チェック
        'If cmbGroupCode.Text = String.Empty Then
        '    Message.MessageShow("E005", {"コード"})
        '    Return False
        'End If
        'If cmbGroupName.Text = String.Empty Then
        '    Message.MessageShow("E005", {"団体名"})
        '    Return False
        'End If
        'If txtStudentCount.Text = String.Empty Then
        '    Message.MessageShow("E005", {"受験者数"})
        '    Return False
        'End If
        If txtFilePath.Text = String.Empty Then
            Message.MessageShow("E005", {"CSVファイル名"})
            Return False
        End If

        ''数値チェック
        'If Not Utility.IsInteger(txtStudentCount.Text) Then
        '    Message.MessageShow("E006", {"受講者数"})
        '    Return False
        'End If
        'If CInt(txtStudentCount.Text) = 0 Then
        '    Message.MessageShow("E005", {"受講者数"})
        '    Return False
        'End If

        'ファイル存在チェック
        If Not System.IO.File.Exists(txtFilePath.Text) Then
            Message.MessageShow("E018")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' CSVのインポート
    ''' </summary>
    ''' <param name="csvFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function importCSV(ByVal csvFileName As String, ByRef studentCSV As ArrayList) As Boolean
        importCSV = True

        Dim csvRecords As New System.Collections.ArrayList()
        Dim tfp As New FileIO.TextFieldParser(csvFileName, _
        System.Text.Encoding.GetEncoding(932))

        Try
            'Shift JISで読み込む

            'フィールドが文字で区切られているとする
            'デフォルトでDelimitedなので、必要なし
            tfp.TextFieldType = FileIO.FieldType.Delimited
            '区切り文字を,とする
            tfp.Delimiters = New String() {","}
            'フィールドを"で囲み、改行文字、区切り文字を含めることができるか
            'デフォルトでtrueなので、必要なし
            tfp.HasFieldsEnclosedInQuotes = True
            'フィールドの前後からスペースを削除する
            'デフォルトでtrueなので、必要なし
            tfp.TrimWhiteSpace = True

            While Not tfp.EndOfData
                'フィールドを読み込む
                Dim fields As String() = tfp.ReadFields()
                '保存
                csvRecords.Add(fields)
            End While

            studentCSV = csvRecords
        Catch ex As Exception
            importCSV = False
        Finally
            tfp.Close()
        End Try
    End Function

    ''' <summary>
    ''' 団体データ読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadGroup()
        'グループファイル読み込み
        dtGroup = loadGroupFile()
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
    ''' 検索情報を設定する
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub setSearchCondition(ByVal dt As DataTable)
        Dim group As New DataTable
        group = dt.Copy
        group = addComboBrankItem(group)

        'コンボボックス設定
        'cmbGroupCode.DataSource = group
        'cmbGroupName.DataSource = group
    End Sub

    ''' <summary>
    ''' コンボボックスに空白を追加する
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addComboBrankItem(ByVal dt As DataTable) As DataTable
        Dim dtwk As New DataTable
        dtwk = dt.Clone
        dtwk.Rows.Add()
        dtwk.Merge(dt)
        Return dtwk
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
#End Region


End Class