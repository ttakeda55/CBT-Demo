Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports System.IO
Imports System.Text.RegularExpressions

''' <summary>
''' 問題登録
''' </summary>
''' <remarks>
''' 2011/09/06 nozao 新規作成
''' </remarks>
Public Class frmPracticeQuestionImport

#Region "----- メンバ変数 -----"
    Private middleQuestion As middleQuestionInfo
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    Structure middleQuestionInfo
        Public QuestionCode As ArrayList
        Public PracticeQuestionBank As ArrayList
        Public middleQuestionCodeCount As Integer
        Public middleMainQuestionCodeCount As Integer
    End Structure
#End Region

#Region "----- イベントハンドラ -----"
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

            ofd.Filter = "WORDファイル(*.doc,*.docx)|*.doc;*.docx"
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
            If Not inputCheck() Then Exit Sub

            ''取り込み確認
            'If Not Message.MessageShow("Q003") = DialogResult.OK Then Exit Sub

            'ファイルが開いてるかチェック
            If Not checkWordOpen() Then Exit Sub

            Me.processMessage = True
            Refresh()

            '取り込み処理
            Dim questionBankCol As New VetnurseQuestionBankCollection
            questionBankCol = importPracticeQuestion.ImportWord(txtFilePath.Text)

            '取込ファイルエラーチェック
            If Not checkImportFile(questionBankCol) Then Exit Sub

            '重複チェック
            Dim arQuestionCode As New ArrayList
            If Not checkExsist(questionBankCol, arQuestionCode) Then Exit Sub

            '演習問題一覧作成
            makePracticeQuestionList(questionBankCol, arQuestionCode)

            'ファイル書き込み
            writePracticeQuestionFile(questionBankCol)

            dgvError.Rows.Clear()
            Me.processMessage = False

            'ファイル更新
            If Not DataManager.GetInstance.UpLoadFile Then Exit Sub

            Common.Message.MessageShow("I003")
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
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
    Private Function checkImportFile(ByVal questionbank As VetnurseQuestionBankCollection) As Boolean
        checkImportFile = True
        Dim errorMessage As New ArrayList
        Dim arQuestionCodeList As New ArrayList
        Dim dtPracticeQuestionList As DataTable = PracticeQuestionList.GetAll(Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
        Dim ngChars As String = Common.Constant.CST_FILENAMECHARS_NG.Replace("\", "\\")

        '一件もデータが存在しない場合
        If questionbank.Count = 1 Then
            If questionbank.Item(0).Question = "" And questionbank.Item(0).Choice = "" Then
                errorMessage.Add(Common.Message.GetMessage("E021", {"問題"}))
                questionbank.Remove(0)
            End If
        End If

        '分類をロード
        CategoryMaster.GetCategoryName("")

        For i = 0 To questionbank.Count - 1
            '問題コード
            If questionbank.Item(i).QuestionCode = String.Empty Then
                errorMessage.Add(Common.Message.GetMessage("E026", {"問題コード", "（" & i + 1 & "問目）"}))
            Else
                '問題コード重複チェック
                If arQuestionCodeList.Contains(questionbank.Item(i).QuestionCode) Then
                    errorMessage.Add(Common.Message.GetMessage("E052", {"問題コード", "（問題コード：" & questionbank.Item(i).QuestionCode & "," & i + 1 & "問目）"}))
                Else
                    arQuestionCodeList.Add(questionbank.Item(i).QuestionCode)
                End If
                '使用禁止文字
                'ファイル名で使用禁止文字チェック

                If Utility.IsNgChar(questionbank.Item(i).QuestionCode, ngChars) Then
                    Dim chars As String = Common.Constant.CST_FILENAMECHARS_NG
                    Dim str As String = ""
                    For Each chr As Char In chars
                        str &= "[" & chr.ToString & "]"
                    Next
                    errorMessage.Add(Common.Message.GetMessage("E063", {"問題コード", str, "（" & i + 1 & "問目）"}))
                End If
            End If
            'カテゴリID
            If questionbank.Item(i).IsMiddleMainQuestion = False Then
                If questionbank.Item(i).CategoryId = String.Empty Then
                    errorMessage.Add(Common.Message.GetMessage("E026", {"グループID", "（" & i + 1 & "問目）"}))
                End If
            End If
            '正解
            If questionbank.Item(i).Ansewr = String.Empty Then
                errorMessage.Add(Common.Message.GetMessage("E022", {"正解", "（" & i + 1 & "問目）"}))
            Else
                Dim mcs = Regex.Matches(questionbank.Item(i).Ansewr, "[" & Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkString & "]")
                If mcs.Count <> 1 Then
                    errorMessage.Add(Common.Message.GetMessage("E024", {"正解", "（" & i + 1 & "問目）"}))
                End If
            End If
            '設問
            If questionbank.Item(i).Question = String.Empty Then
                errorMessage.Add(Common.Message.GetMessage("E022", {"設問領域", "（" & i + 1 & "問目）"}))
            End If

            '分類コードがマスタに存在しない場合
            If questionbank.Item(i).IsMiddleMainQuestion = False And questionbank.Item(i).CategoryId <> String.Empty Then
                If CategoryMaster.existsDisplayId(questionbank.Item(i).CategoryId) = False Then
                    errorMessage.Add(Common.Message.GetMessage("E024", {"グループID", "（" & i + 1 & "問目）"}))
                End If
            End If

            '重複チェック
            Dim foundDataRow As DataRow() = dtPracticeQuestionList.Select("QUESTIONCODE = '" & questionbank.Item(i).QuestionCode & "'")
            Dim drPracticeQuestionList As DataRow = Nothing
            '中問内の小問が、登録済単独小問の問題コードと重複する場合
            If questionbank.Item(i).IsMiddleQuestion And questionbank.Item(i).IsMiddleMainQuestion = False Then
                If foundDataRow.Length > 0 Then
                    For Each dr As DataRow In foundDataRow
                        If dr.Item("QUESTIONCLASS") = "1" Then
                            errorMessage.Add(Common.Message.GetMessage("E057", {"（" & i + 1 & "問目）"}))
                        End If
                    Next
                End If
            End If
        Next

        If errorMessage.Count > 0 Then
            dgvError.Rows.Clear()
            For i = 0 To errorMessage.Count - 1
                dgvError.Rows.Add()
                dgvError.Rows(i).Cells(0).Value = errorMessage.Item(i)
            Next
            checkImportFile = False
            Message.MessageShow("E031")
        End If

    End Function

    ''' <summary>
    ''' 選択肢がｱｲｳｴが１文字づつ記述されているか確認
    ''' </summary>
    ''' <param name="qb"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkChoice(ByVal qb As PracticeQuestionBank) As Boolean
        checkChoice = True

        Dim choice As String = ""

        choice = ""
        For j = 0 To qb.ChoiceMark.Count - 1
            choice &= qb.ChoiceMark.Item(j)
        Next
        For j = 0 To choice.Length - 1
            If CountChar(choice, Common.Constant.CST_SELECTMARK_PRACTICEQUESTION.Chars(j)) <> 1 Then
                checkChoice = False
            End If
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
    ''' 入力チェックを行います。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        Dim check As Boolean = True

        If txtFilePath.Text = String.Empty Then
            Message.MessageShow("E005", {"ファイルパス"})
            Return False
        End If

        'ファイル存在チェック
        If Not System.IO.File.Exists(txtFilePath.Text) Then
            Message.MessageShow("E018")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 重複チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkExsist(ByVal questionBankCol As VetnurseQuestionBankCollection, ByRef arQuestionCode As ArrayList) As Boolean
        checkExsist = True
        Dim dtPracticeQuestionList As DataTable = PracticeQuestionList.GetAll()
        'dtPracticeQuestionList.Columns.Add("QUESTIONMAKERCODE", GetType(String), "SUBSTRING(QUESTIONCODE,1,5)")
        For Each QuestionBank As PracticeQuestionBank In questionBankCol
            'Dim questionMakercode As String = QuestionBank.QuestionCode.Substring(0, 5)
            'Dim foundDataRow As DataRow() = dtPracticeQuestionList.Select("QUESTIONMAKERCODE = '" & questionMakercode & "'")
            Dim foundDataRow As DataRow() = dtPracticeQuestionList.Select("QUESTIONCODE = '" & QuestionBank.QuestionCode & "'")
            If foundDataRow.Length > 0 Then
                'If Not arQuestionCode.Contains(questionMakercode) Then
                '    arQuestionCode.Add(questionMakercode)
                If Not arQuestionCode.Contains(QuestionBank.QuestionCode) Then
                    arQuestionCode.Add(QuestionBank.QuestionCode)
                End If
            End If
        Next

        Dim errMessageQuestionCode As String = vbCrLf

        Dim i As Integer = 0
        For Each Str As String In arQuestionCode
            If i = 4 Then
                errMessageQuestionCode &= Str & "," & vbCrLf
                i = 0
            Else
                errMessageQuestionCode &= Str & ","
                i += 1
            End If
        Next

        If arQuestionCode.Count > 0 Then
            errMessageQuestionCode = errMessageQuestionCode.Substring(0, errMessageQuestionCode.Length - 1)
            If Common.Message.MessageShow("Q008", {errMessageQuestionCode}) = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                dgvError.Rows.Clear()
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' 演習問題一覧を作成する
    ''' </summary>
    Private Sub makePracticeQuestionList(ByVal questionBankCol As VetnurseQuestionBankCollection, ByVal arQuestionCode As ArrayList)
        Dim dtPracticeQuestionList As DataTable = PracticeQuestionList.GetAll()
        Dim createDate As String
        Dim htCreateDate As New Hashtable
        Dim htMiddleQuestionInfo As New Hashtable
        Dim middleQuestionInfo As New middleQuestionInfo

        '上書きする問題を削除する
        htCreateDate = delOverWritePracticeQuestion(arQuestionCode, dtPracticeQuestionList)

        For Each QuestionBank As VetNurseQuestionBank In questionBankCol
            'データ追加
            Dim drPracticeQuestionList As DataRow = Nothing
            drPracticeQuestionList = dtPracticeQuestionList.NewRow
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.QuestinCode) = QuestionBank.QuestionCode
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.MiddleQuestionIndex) = ""
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.QuestionClass) = "1"
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.MainCode) = QuestionBank.MiddleQuestionCode
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.Theme) = QuestionBank.Theme
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.Level) = QuestionBank.Level
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.CategoryId) = QuestionBank.CategoryId
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.Format) = QuestionBank.Format
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.CorrectAnswer) = QuestionBank.Ansewr
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.State) = "0"
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.QuestionType) = "0"
            If htCreateDate.ContainsKey(QuestionBank.QuestionCode) Then
                createDate = htCreateDate(QuestionBank.QuestionCode)
            Else
                createDate = System.DateTime.Now.ToString
            End If
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.CreateDate) = createDate.ToString
            drPracticeQuestionList(PracticeQuestionList.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
            dtPracticeQuestionList.Rows.Add(drPracticeQuestionList)
        Next

        'ファイル書き込み
        PracticeQuestionList.WriteXML(dtPracticeQuestionList)
    End Sub

    ''' <summary>
    ''' データを削除する
    ''' </summary>
    ''' <param name="arQuestionCode"></param>
    ''' <remarks></remarks>
    Private Function delOverWritePracticeQuestion(ByVal arQuestionCode As ArrayList, ByRef dtPracticeQuestionList As DataTable) As Hashtable
        Dim CreateDate As New DateTime
        Dim htCreateDate As New Hashtable
        Dim delPath As String = Common.Constant.GetTempPath & Common.Constant.CST_PRACTICEQUESTION_FILENAME
        'dtPracticeQuestionList.Columns.Add("QUESTIONMAKERCODE", GetType(String), "SUBSTRING(QUESTIONCODE,1,5)")
        For Each QuestionCode As String In arQuestionCode
            Dim foundDataRow As DataRow() = dtPracticeQuestionList.Select("QUESTIONCODE = '" & QuestionCode & "'")
            For Each dr As DataRow In foundDataRow
                If Not htCreateDate.ContainsKey(dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode)) Then
                    htCreateDate(dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode)) = dr(Common.PracticeQuestionList.ColumnIndex.CreateDate)
                End If

                If IO.File.Exists(delPath & dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode)) Then
                    logger.Info("Start:delOverWritePracticeQuestion FileName:" & delPath & dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode))
                    IO.File.Delete(delPath & dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode))
                    logger.Info("End:delOverWritePracticeQuestion FileName:" & delPath & dr(Common.PracticeQuestionList.ColumnIndex.QuestinCode))
                End If
                dtPracticeQuestionList.Rows.Remove(dr)
            Next
        Next

        'dtPracticeQuestionList.Columns.Remove("QUESTIONMAKERCODE")

        Return htCreateDate
    End Function

    ''' <summary>
    ''' 問題ファイルを書き込む
    ''' </summary>
    ''' <param name="questionBankCol"></param>
    ''' <remarks></remarks>
    Private Sub writePracticeQuestionFile(questionBankCol As VetnurseQuestionBankCollection)
        '小問
        Dim wkPracticeQuestionBankCollection As New VetnurseQuestionBankCollection
        For Each QuestionBank As VetNurseQuestionBank In questionBankCol
            If QuestionBank.IsMiddleQuestion = False Then
                wkPracticeQuestionBankCollection.Add(QuestionBank)
                Common.Serialize.ObjectToBinaryFile(wkPracticeQuestionBankCollection, Common.Constant.CST_PRACTICEQUESTION_FILENAME & QuestionBank.QuestionCode)
                '中問ファイル削除
                If IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME & QuestionBank.QuestionCode) Then
                    logger.Info("Start:writePracticeQuestionFile FileName:" & Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME & QuestionBank.QuestionCode)
                    IO.File.Delete(Common.Constant.GetTempPath & Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME & QuestionBank.QuestionCode)
                    logger.Info("End:writePracticeQuestionFile FileName:" & Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME & QuestionBank.QuestionCode)
                End If
                wkPracticeQuestionBankCollection.Clear()
            End If
        Next

    End Sub
#End Region

End Class