Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports System.IO

''' <summary>
''' 問題登録
''' </summary>
''' <remarks>
''' 2011/09/06 nozao 新規作成
''' </remarks>
Public Class frmQuestionImport

#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' 問題管理画面に戻る
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
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
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
            Me.DialogResult = DialogResult.Cancel
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
    Private Sub frmQuestionImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Text = "問題登録"
            lblBottomCode.Text = "TG11"
            lblBottomName.Text = "問題登録画面"

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' ファイルダイアログ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReference.Click
        Try
            'OpenFileDialogクラスのインスタンスを作成
            Dim ofd As New OpenFileDialog()

            ofd.Filter = "WORDファイル(*.doc)|*.doc|WORDファイル(*.docx)|*.docx"
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
    ''' ファイル取り込み処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            logger.Start()
            '入力チェック
            If Not inputCheck() Then
                Exit Sub
            End If

            '取り込み確認
            If Not Message.MessageShow("Q003") = DialogResult.OK Then
                Exit Sub
            End If

            'ファイルが開いてるかチェック
            If Not checkWordOpen() Then
                Exit Sub
            End If

            '重複チェック
            If Not checkExsist() Then
                Exit Sub
            End If

            Me.processMessage = True
            Refresh()

            '取り込み処理
            Dim questionBankCol As New QuestionBankCollection
            questionBankCol = ConvertWordToHtml.ImportWord(txtFilePath.Text)


            '取込ファイルエラーチェック
            If Not checkImportFile(questionBankCol) Then
                Message.MessageShow("E031")
                Exit Sub
            End If

            'ファイル取り込み
            Common.Serialize.ObjectToBinaryFile(questionBankCol, Common.Constant.CST_QUESTION_FILENAME & txtTestName.Text)

            '模擬テスト一覧作成
            makeQuestionList()
            Me.processMessage = False

            processMessageUpload = True
            If Not DataManager.GetInstance.UpLoadFile Then Exit Sub

            dgvError.Rows.Clear()

            Common.Message.MessageShow("I003")
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            processMessageUpload = False
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
    ''' ファイルが開いてるかチェック
    ''' </summary>
    Private Function checkWordOpen() As Boolean
        checkWordOpen = True
        Try
            Using br As New FileStream(txtFilePath.Text, FileMode.Open, FileAccess.Read, FileShare.None)
            End Using
        Catch ex As Exception
            MessageBox.Show("ファイルを閉じてください。")
            checkWordOpen = False
        End Try
    End Function

    ''' <summary>
    ''' インポートファイルチェック
    ''' </summary>
    ''' <param name="questionbank"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkImportFile(ByVal questionbank As QuestionBankCollection) As Boolean
        checkImportFile = True
        Dim multi As New QuestionBank.multiQuestion
        setMultiQuestionInfo(questionbank)

        Dim errorMessage As New ArrayList
        If questionbank.Count = 1 Then
            If questionbank.Item(0).Question = "" And questionbank.Item(0).Choice = "" Then
                errorMessage.Add(Common.Message.GetMessage("E021", {"問題"}))
                questionbank.Remove(0)
            End If
        ElseIf questionbank.Count = 0 Then
            errorMessage.Add(Common.Message.GetMessage("E054", {"模擬テスト", Common.Constant.CST_MOCKTEST}))
        End If

        '分類をロード
        CategoryMaster.GetCategoryName("")

        For i = 0 To questionbank.Count - 1
            '一問の中で属性領域、設問領域、選択肢領域の何れかが存在しない場合
            If Not questionbank.Item(i).QuestionProperty(Common.Constant.CST_PROPERTY) Then
                errorMessage.Add(Common.Message.GetMessage("E022", {"属性領域", "（" & i + 1 & "問目）"}))
            Else
                '属性の必須項目が記述されていない場合
                '分類
                If questionbank.Item(i).QuestionProperty(Common.Constant.CST_DISPLAYID) = "" Then
                    errorMessage.Add(Common.Message.GetMessage("E026", {"分類", "（" & i + 1 & "問目）"}))
                End If
                'テーマ
                If questionbank.Item(i).QuestionProperty(Common.Constant.CST_THEME) = "" Then
                    errorMessage.Add(Common.Message.GetMessage("E026", {"テーマ", "（" & i + 1 & "問目）"}))
                End If
                '中問
                If Not questionbank.Item(i).QuestionProperty(Common.Constant.CST_MULTI) Is Nothing Then
                    If questionbank.Item(i).QuestionProperty(Common.Constant.CST_MULTI) = "" Then
                        errorMessage.Add(Common.Message.GetMessage("E026", {"中問", "（" & i + 1 & "問目）"}))
                    End If
                End If
            End If
            If questionbank.Item(i).Question = "" Then
                errorMessage.Add(Common.Message.GetMessage("E022", {"設問領域", "（" & i + 1 & "問目）"}))
            End If


            '中問判定
            multi = CType(questionbank.Item(i).QuestionProperty("MultiQuestionInfo"), QuestionBank.multiQuestion)
            If multi.Code <> "" Then
                If multi.Count <> 5 Then
                    errorMessage.Add(Common.Message.GetMessage("E029", {"中問の問題数", "（中問：" & multi.Code & "）"}))
                End If
                '選択肢領域がある
                If questionbank.Item(i).Choice <> "" Then
                    errorMessage.Add(Common.Message.GetMessage("E030", {"中問主文に選択肢", "（中問：" & multi.Code & "）"}))
                End If
            Else
                '選択肢領域がない
                If questionbank.Item(i).Choice = "" Then
                    errorMessage.Add(Common.Message.GetMessage("E022", {"選択肢領域", "（" & i + 1 & "問目）"}))
                Else
                    '正解を識別できない場合
                    If questionbank.Item(i).FirstAnsewr = "" Or questionbank.Item(i).SecondAnsewr = "" Then
                        errorMessage.Add(Common.Message.GetMessage("E023", {"正解", "（" & i + 1 & "問目）"}))
                    End If
                    '選択肢の数が４つではない。
                    If questionbank.Item(i).ChoiceMark.Count <> 4 Then
                        errorMessage.Add(Common.Message.GetMessage("E024", {"選択肢の数", "（" & i + 1 & "問目）"}))
                    Else
                        '選択肢がｱｲｳｴが１文字づつ記述されていない。
                        If checkChoice(questionbank.Item(i)) = False Then
                            errorMessage.Add(Common.Message.GetMessage("E024", {"選択肢記号", "（" & i + 1 & "問目）"}))
                        End If
                    End If
                End If

                '解説領域が存在しない場合
                If questionbank.Item(i).Comment = "" Then
                    errorMessage.Add(Common.Message.GetMessage("E022", {"解説領域", "（" & i + 1 & "問目）"}))
                End If
            End If

            '分類コードがマスタに存在しない場合
            If CategoryMaster.existsDisplayId(questionbank.Item(i).QuestionProperty(Common.Constant.CST_DISPLAYID)) = False Then
                errorMessage.Add(Common.Message.GetMessage("E024", {"分類コード", "（" & i + 1 & "問目）"}))
            End If

            '解説がなくて、解説再のみの場合
            If questionbank.Item(i).ReTestComment <> "" And questionbank.Item(i).Comment = "" Then
                errorMessage.Add(Common.Message.GetMessage("E034", {"（" & i + 1 & "問目）"}))
            End If
        Next

        If errorMessage.Count > 0 Then
            dgvError.Rows.Clear()
            For i = 0 To errorMessage.Count - 1
                dgvError.Rows.Add()
                dgvError.Rows(i).Cells(0).Value = errorMessage.Item(i)
            Next
            checkImportFile = False
        End If
    End Function

    ''' <summary>
    ''' 選択肢がｱｲｳｴが１文字づつ記述されているか確認
    ''' </summary>
    ''' <param name="qb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkChoice(ByVal qb As QuestionBank) As Boolean
        checkChoice = True

        Dim choice As String = ""

        For i = 0 To 1
            choice = ""
            For j = 0 To qb.ChoiceMark.Count - 1
                choice &= StrConv(qb.ChoiceMark.Item(j)(i), VbStrConv.Narrow)
            Next
            For j = 0 To choice.Length - 1
                If CountChar(choice, Common.Constant.CST_SELECTMARK.Chars(j)) <> 1 Then
                    checkChoice = False
                End If
            Next
        Next
    End Function

    ''' <summary>
    ''' 文字の出現回数をカウント
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString(), "").Length
    End Function

    ''' <summary>
    ''' 中問の情報を設定する。
    ''' </summary>
    ''' <param name="questionbank"></param>
    ''' <remarks></remarks>
    Private Sub setMultiQuestionInfo(ByRef questionbank As QuestionBankCollection)
        Dim multi As New QuestionBank.multiQuestion
        Dim questionChangeFlg As Boolean = False
        Dim index As Integer = 0

        For i = 0 To questionbank.Count - 1
            If questionbank.Item(i).QuestionProperty(Common.Constant.CST_MULTI) <> "" Then
                multi.Code = questionbank.Item(i).QuestionProperty(Common.Constant.CST_MULTI)
                multi.Count += 1
                If questionChangeFlg = False Then
                    index = i
                    questionChangeFlg = True
                End If
                If i <> questionbank.Count - 1 Then
                    If questionbank.Item(i).QuestionProperty(Common.Constant.CST_MULTI) <> questionbank.Item(i + 1).QuestionProperty(Common.Constant.CST_MULTI) Then
                        questionChangeFlg = False
                        questionbank.Item(index).QuestionProperty("MultiQuestionInfo") = multi
                        multi = Nothing
                    End If
                Else
                    questionbank.Item(index).QuestionProperty("MultiQuestionInfo") = multi
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' 入力チェックを行う
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        Dim check As Boolean = True

        '必須チェック
        If txtTestName.Text = String.Empty Then
            Message.MessageShow("E005", {"テスト名"})
            Return False
        End If
        If txtFilePath.Text = String.Empty Then
            Message.MessageShow("E005", {"ファイルパス"})
            Return False
        End If

        'ファイル存在チェック
        If Not System.IO.File.Exists(txtFilePath.Text) Then
            Message.MessageShow("E018")
            Return False
        End If

        'ファイル名で使用禁止文字チェック
        Dim ngChars As String = Common.Constant.CST_FILENAMECHARS_NG.Replace("\", "\\")
        If Utility.IsNgChar(txtTestName.Text, ngChars) Then
            Dim chars As String = Common.Constant.CST_FILENAMECHARS_NG
            Dim str As String = ""
            For Each chr As Char In chars
                str &= "[" & chr.ToString & "]"
            Next
            Message.MessageShow("E063", {"テスト名", str, ""})
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 重複チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkExsist() As Boolean
        checkExsist = True
        Dim dtQuestionList As New DataTable
        If IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML) Then
            dtQuestionList = QuestionList.GetAll(Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
            Dim foundDataRow As DataRow() = dtQuestionList.Select("TESTNAME = '" & txtTestName.Text & "'")
            If foundDataRow.Length > 0 Then
                If Message.MessageShow("Q004") = DialogResult.OK Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If

    End Function

    ''' <summary>
    ''' 模擬テスト一覧を作成する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub makeQuestionList()
        Dim dtQuestionList As New DataTable
        Dim questionList As New QuestionList
        Dim fileName As String = Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML
        If IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            dtQuestionList = Serialize.XmlToDataTable(fileName)
        Else
            Common.XmlSchema.GetQuestionListSchema(dtQuestionList)
        End If

        Dim foundDataRow As DataRow() = dtQuestionList.Select("TESTNAME = '" & txtTestName.Text & "'")
        '上書き
        If foundDataRow.Length > 0 Then
            foundDataRow(0).Item(questionList.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
        Else '新規
            Dim drQuestionList As DataRow = dtQuestionList.NewRow
            '値の設定
            drQuestionList(questionList.ColumnIndex.TestName) = txtTestName.Text
            drQuestionList(questionList.ColumnIndex.MockTestNO) = ""
            drQuestionList(questionList.ColumnIndex.UseStart) = ""
            drQuestionList(questionList.ColumnIndex.UseEnd) = ""
            drQuestionList(questionList.ColumnIndex.Stats) = "0"
            drQuestionList(questionList.ColumnIndex.CreateDate) = System.DateTime.Now.ToString
            drQuestionList(questionList.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
            dtQuestionList.Rows.Add(drQuestionList)
        End If

        'ファイル書き込み
        questionList.WriteXML(dtQuestionList, Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
    End Sub

#End Region
End Class