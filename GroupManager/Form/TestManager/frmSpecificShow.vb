''' <summary>
''' 指定テスト登録確認
''' </summary>
''' <remarks>
''' 2012/04/16 NAKAMURA 新規作成
''' </remarks>
Public Class frmSpecificShow

#Region "メンバ変数"

    ''' <summary>画面表示モード</summary>
    ''' <value>
    ''' 1：登録
    ''' 2：確認
    ''' </value>
    Private Property _Mode As Common.Constant.SpecificShowMode

    ''' <summary>画面データ</summary>
    Private _specificShowList As DataTable

    ''' <summary>テスト名</summary>
    Private _TestName As String = String.Empty

    ''' <summary>選択カテゴリー</summary>
    Private _CategoryDisplayArray As Array

    ''' <summary>問題数</summary>
    Private _Amount As String = String.Empty

    ''' <summary>指定テスト№</summary>
    Private _TestNo As String = String.Empty

    ''' <summary>試験開始日時</summary>
    Private _TestStartDateTime As String = String.Empty

    ''' <summary>試験終了日時</summary>
    Private _TestEndDateTime As String = String.Empty

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    ''' <summary>指定テストヘッダーテーブル</summary>
    Private _SpecificHeaderDt As New DataTable

    Private _practiceQuestionBankCollection As Common.VetnurseQuestionBankCollection
    Private Const QUESTION_DIRECTORY_NAME As String = "PracticeQuestion"

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 表示モード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mode As Common.Constant.SpecificShowMode
        Get
            Return _Mode
        End Get
        Set(ByVal value As Common.Constant.SpecificShowMode)
            _Mode = value
        End Set
    End Property

#End Region

#Region "----- イベントハンドラ----- "

    ''' <summary>
    ''' 初期表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmSpecificShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            'デザインを変更
            changeDesign()

            'グリッドデータ設定
            setGrid()

            Owner.Hide()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問番号をグループ順に並び変え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSrcQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSrcQ.Click
        Dim dgvPracticeQuestionListDt As DataTable = CType(dgvPracticeQuestionList.DataSource, DataTable)
        Dim indexNum As Integer

        indexNum = 0
        For Each row As DataRow In dgvPracticeQuestionListDt.Select("1=1", "[CATEGORYID] ASC")
            indexNum += 1
            row.Item(QUESTIONNO.Name) = indexNum
        Next

        dgvPracticeQuestionListDt.AcceptChanges()

    End Sub

    ''' <summary>
    ''' 登録クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            logger.Start()
            '入力チェック
            If Not specificTestCheck() Then
                logger.End()
                Exit Sub
            End If

            '登録処理
            insertSpecificTest()

            '更新メッセージ
            If Mode = Common.Constant.SpecificShowMode.ShowTestList Then
                Common.Message.MessageShow("I004")
            Else
                Common.Message.MessageShow("I001")
            End If

            '戻る
            Me.DialogResult = DialogResult.Yes
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' キャンセルクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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
    ''' 戻るクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()

            If Common.Message.MessageShow("Q011") = DialogResult.OK Then
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
    ''' 問題コードリンククリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>指定された問題コードを表示する</remarks>
    Private Sub dgvPracticeQuestionList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellContentClick
        Try
            logger.Start()

            If e.ColumnIndex = QUESTIONCODE.Index And e.RowIndex <> -1 Then
                Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection

                PraciticeQuestionInfoCollection = createPraciticeQuestionInfoCollection()
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(dgvPracticeQuestionList.CurrentRow.Index, PraciticeQuestionInfoCollection, True)
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
    ''' 問番号編集完了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 数値チェックを行い、ＯＫの場合、問番号を
    ''' 振りなおす
    ''' </remarks>
    Private Sub dgvPracticeQuestionList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellEndEdit
        Try
            If IsNumeric(dgvPracticeQuestionList(e.ColumnIndex, e.RowIndex).Value) Then
                setQuestionNo(e)
            Else
                dgvPracticeQuestionList.CancelEdit()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問番号設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>問番号の”問”を付加して表示する</remarks>
    Private Sub dgvPracticeQuestionList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPracticeQuestionList.CellFormatting
        Try
            If dgvPracticeQuestionList.Columns(e.ColumnIndex).Name = QUESTIONNO.Name Then
                e.Value = Common.Constant.CST_QUESTION_UNIT & dgvPracticeQuestionList(e.ColumnIndex, e.RowIndex).Value
                e.FormattingApplied = True
            End If
        Catch ex As Exception
            logger.Error(ex)
            Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
        End Try
    End Sub

    ''' <summary>
    ''' テキスト項目を一回のクリックで編集開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPracticeQuestionList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellClick
        Try
            '1回のクリックでエディットモードにする処置  
            Dim dgv As DataGridView = TryCast(sender, DataGridView)

            If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
                If dgvPracticeQuestionList.Columns(e.ColumnIndex).Name = QUESTIONNO.Name Then
                    SendKeys.Send("{F2}")
                    dgv.BeginEdit(True)
                    dgv(e.ColumnIndex, e.RowIndex).Value = dgvPracticeQuestionList(e.ColumnIndex, e.RowIndex).Value.ToString.Replace(Common.Constant.CST_QUESTION_UNIT, "")
                End If
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' セル編集初期表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 問番号の”問”を削除する
    ''' キープレスのイベント設定
    ''' </remarks>
    Private Sub dgvPracticeQuestionList_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPracticeQuestionList.EditingControlShowing
        Try
            '---restrict inputs on the fourth field---
            If dgvPracticeQuestionList.Columns(dgvPracticeQuestionList.CurrentCell.ColumnIndex).Name = QUESTIONNO.Name And Not e.Control Is Nothing Then
                '問番号　問を削除
                e.Control.Text = e.Control.Text.Replace(Common.Constant.CST_QUESTION_UNIT, "")
                Dim tb As TextBox = CType(e.Control, TextBox)
                tb.SelectAll()
                '---add an event handler to the TextBox control---
                AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
                tb.SelectAll()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グリッド問番号キープレスイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>数値のみ入力可能にする</remarks>
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            '---if textbox is empty and user pressed a decimal char---
            If CType(sender, TextBox).Text = String.Empty And e.KeyChar = Chr(46) Then
                e.Handled = True
                Return
            End If
            '---if textbox already has a decimal point---
            If CType(sender, TextBox).Text.Contains(Chr(46)) And e.KeyChar = Chr(46) Then
                e.Handled = True
                Return
            End If
            '---if the key pressed is not a valid decimal number---
            If (Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or (e.KeyChar = Chr(46)))) Then
                e.Handled = True
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' エラー時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPracticeQuestionList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPracticeQuestionList.DataError
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
    Private Sub addQuestionTypeColumns(ByRef dtPracticeQuestionList As DataTable)
        'チェックカラム
        Dim expression As String = "IIF(" & QUESTIONTYPE.Name & " = 0,'" &
                                           Common.Constant.CST_QUESTION_TYPE(0) &
                                           "',IIF(" & QUESTIONTYPE.Name & " = 1,'" &
                                           Common.Constant.CST_QUESTION_TYPE(1) & "','" &
                                           Common.Constant.CST_QUESTION_TYPE(2) & "'))"
        dtPracticeQuestionList.Columns.Add(QUESTIONTYPE.DataPropertyName, GetType(String), expression)
    End Sub
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="specificShowList"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal specificShowList As DataTable, Optional ByVal testName As String = "",
                    Optional ByVal categoryDisplayArray As Array = Nothing, Optional ByVal amount As String = "", Optional ByVal testno As String = "")

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        _specificShowList = specificShowList
        _TestName = testName
        _CategoryDisplayArray = categoryDisplayArray
        _Amount = amount
        _TestNo = testno
        '_TestStartDateTime = testStartDateTime
        '_TestEndDateTime = testEndDateTime


        logger.Debug("frmSpecificShow _Amount=" & _Amount)
        If Not IsNothing(_specificShowList) Then
            logger.Debug("frmSpecificShow _specificShowList.Rows.Count=" & _specificShowList.Rows.Count)
        End If

    End Sub

    ''' <summary>
    ''' 画面及びグリッドのデザインを変更する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changeDesign()
        Select Case _Mode
            Case Common.Constant.SpecificShowMode.CreateManualTest, Common.Constant.SpecificShowMode.CreateAutomaticTest
                'タイトル
                Me.Text = "テスト登録確認"
                Me.lblTitle.Text = "テスト登録確認"
                'パンくずリスト
                Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 手動テスト作成 ＞ テスト登録確認"
                'テスト変更欄
                Me.txtTestName.Visible = True
                'テスト名変更ボタン
                Me.btnTestNameEdit.Visible = False
                '登録ボタン
                Me.btnAdd.Visible = True
                btnAdd.Text = "登録"
                '出力ボタン
                Me.btnWord.Visible = False
                'キャンセルボタン
                Me.btnCancel.Visible = False
                Me.ChkQ.Visible = False
                Me.ChkT.Visible = False
                'ソートボタン
                Me.btnSrcQ.Visible = False
                Me.BtnSrcS.Visible = False
                'Case Common.Constant.SpecificShowMode.CreateAutomaticTest
                '    タイトル()
                '    Me.Text = "テスト登録確認"
                '    Me.lblTitle.Text = "テスト登録確認"
                '    パンくずリスト()
                '    Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ 自動テスト作成 ＞ テスト登録確認"
                '    テスト変更欄()
                '    Me.txtTestName.Visible = True
                '    テスト名変更ボタン()
                '    Me.btnTestNameEdit.Visible = False
                '    登録ボタン()
                '    Me.btnAdd.Visible = True
                '    btnAdd.Text = "登録"
                '    出力ボタン()
                '    Me.btnWord.Visible = False
                '    キャンセルボタン()
                '    Me.btnCancel.Visible = True
             Case Common.Constant.SpecificShowMode.ShowTestList
                'タイトル
                Me.Text = "テスト確認"
                Me.lblTitle.Text = "テスト確認"
                'パンくずリスト
                Me.lblTree.Text = "管理者メインメニュー ＞ 問題演習管理メニュー ＞ テスト問題一覧 ＞ テスト確認"
                '指定テスト変更欄
                Me.txtTestName.Visible = True
                '指定テスト名変更ボタン
                Me.btnTestNameEdit.Visible = False
                '登録ボタン
                Me.btnAdd.Visible = True
                btnAdd.Text = "修正"
                'キャンセルボタン
                Me.btnCancel.Visible = False
                '出力ボタン
                Me.btnWord.Visible = True
                Me.ChkQ.Visible = True
                Me.ChkT.Visible = True
                'ソートボタン
                Me.btnSrcQ.Visible = True
                Me.BtnSrcS.Visible = True
                '問番号
                'dgvPracticeQuestionList.Columns(QUESTIONNO.Name).ReadOnly = True
        End Select

        'テスト名
        Me.txtTestName.Text = _TestName
        ''試験開始日時
        'Me.mskTestStart_DateTime.Text = CType(_TestStartDateTime, DateTime).ToString("yyyy/MM/ddHH:mm")
        ''試験終了日時
        'Me.mskTestEnd_DateTime.Text = CType(_TestEndDateTime, DateTime).ToString("yyyy/MM/ddHH:mm")
        'グリッド
        With dgvPracticeQuestionList

            '描画
            .Columns(CATEGORYNAME1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(CATEGORYNAME2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            'ヘッダ微調整
            .Columns(QUESTIONNO.Name).HeaderCell.Value = Space(2) & .Columns(QUESTIONNO.Name).HeaderCell.Value & Space(2)
            .Columns(QUESTIONCODE.Name).HeaderCell.Value = Space(1) & .Columns(QUESTIONCODE.Name).HeaderCell.Value & Space(1)
            .Columns(CATEGORYNAME1.Name).HeaderCell.Value = Space(5) & .Columns(CATEGORYNAME1.Name).HeaderCell.Value & Space(5)
            .Columns(CATEGORYNAME2.Name).HeaderCell.Value = Space(11) & .Columns(CATEGORYNAME2.Name).HeaderCell.Value & Space(11)
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Value = Space(11) & .Columns(CATEGORYNAME3.Name).HeaderCell.Value & Space(11)
            .Columns(THEME.Name).HeaderCell.Value = Space(11) & .Columns(THEME.Name).HeaderCell.Value & Space(11)
            '.Columns(CATEGORYNAME4.Name).HeaderCell.Value = Space(10) & .Columns(CATEGORYNAME4.Name).HeaderCell.Value & Space(10)
            .Columns(FORMAT.Name).HeaderCell.Value = Space(5) & .Columns(FORMAT.Name).HeaderCell.Value & Space(5)

            .AutoGenerateColumns = False
        End With
    End Sub

    ''' <summary>
    ''' グリッドに演習問題一覧を設定する。
    ''' </summary>
    ''' <remarks>引き継いだデータを表示する</remarks>
    Private Sub setGrid()

        '選択
        If Common.Constant.SpecificShowMode.ShowTestList = Me.Mode Then
            dgvPracticeQuestionList.Columns.Item(QUESTIONNO.Name).DataPropertyName = "SHOWNONUM"
            '問題タイプカラム追加
            addQuestionTypeColumns(_specificShowList)
        End If

        If Not _specificShowList.Columns.Contains("QUESTIONNO") Then
            Dim questionNo As New DataColumn
            questionNo.ColumnName = "QUESTIONNO"
            questionNo.DataType = GetType(Integer)
            _specificShowList.Columns.Add(questionNo)
            '
            Dim index As Integer = 0
            For Each row As DataRow In _specificShowList.Rows
                index += 1
                row.Item("QUESTIONNO") = index.ToString
            Next
        End If
        _specificShowList.DefaultView.Sort = "SHOWNONUM ASC"
        dgvPracticeQuestionList.DataSource = _specificShowList
    End Sub

    ''' <summary>
    ''' 指定テスト登録
    ''' </summary>
    ''' <remarks>画面に表示している、小問を指定テストとして作成する</remarks>
    Private Sub insertSpecificTest()
        Dim dtSynthesisHeader As New DataTable
        Dim dtSynthesisDetail As New DataTable
        Dim fileName As String = String.Empty
        Dim testNo As String = String.Empty
        '更新確定
        dgvPracticeQuestionList.CommitEdit(DataGridViewDataErrorContexts.Commit)

        'ヘッダー
        Common.XmlSchema.GetSynthesisHeaderSchema(dtSynthesisHeader)

        'テスト番号取得
        testNo = setspecificTestNo()

        fileName = Common.Constant.CST_SYNTHESISHEADER_FILENAME & Common.Constant.CST_GROUPNAME & Common.Constant.CST_EXTENSION_XML
        If IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            dtSynthesisHeader = Common.SpecificHeader.GetAll(fileName)
        Else
            Common.XmlSchema.GetSynthesisHeaderSchema(dtSynthesisHeader)
        End If

        Dim inputRow As DataRow = Nothing
        If Mode = Common.Constant.SpecificShowMode.ShowTestList Then
            inputRow = dtSynthesisHeader.Select("TESTNO = '" & _TestNo & "'")(0)
        Else
            inputRow = dtSynthesisHeader.Rows.Add()
        End If

        With inputRow
            .Item(Common.SynthesisHeader.ColumnIndex.TestNo) = testNo
            .Item(Common.SynthesisHeader.ColumnIndex.TestName) = txtTestName.Text.Trim
            .Item(Common.SynthesisHeader.ColumnIndex.CreateDate) = DataManager.GetInstance.GetDateTime.ToString
            .Item(Common.SynthesisHeader.ColumnIndex.UpdateDate) = DataManager.GetInstance.GetDateTime.ToString
        End With
        Common.SynthesisHeader.WriteXML(dtSynthesisHeader, fileName)

        '明細
        fileName = Common.Constant.CST_SYNTHESISDETAIL_FILENAME & Common.Constant.CST_GROUPNAME & "_" & testNo & Common.Constant.CST_EXTENSION_XML
        Dim specificDetailRow As DataRow
        Common.XmlSchema.GetSynthesisDetailSchema(dtSynthesisDetail)
        For Each row As DataGridViewRow In dgvPracticeQuestionList.Rows
            specificDetailRow = dtSynthesisDetail.Rows.Add()
            specificDetailRow.Item(Common.SynthesisDetail.ColumnIndex.TestNo) = testNo
            specificDetailRow.Item(Common.SynthesisDetail.ColumnIndex.QuestionCode) = row.Cells(QUESTIONCODE.Name).Value
            specificDetailRow.Item(Common.SynthesisDetail.ColumnIndex.ShowNo) = row.Cells(QUESTIONNO.Name).Value
            specificDetailRow.Item(Common.SynthesisDetail.ColumnIndex.CreateDate) = DataManager.GetInstance.GetDateTime.ToString
            specificDetailRow.Item(Common.SynthesisDetail.ColumnIndex.UpdateDate) = DataManager.GetInstance.GetDateTime.ToString
        Next
        Common.SynthesisDetail.WriteXML(dtSynthesisDetail, fileName)

    End Sub

    ''' <summary>
    ''' 指定テスト、新テスト番号取得
    ''' </summary>
    ''' <returns>新テスト番号</returns>
    ''' <remarks>
    ''' 全指定テストヘッダーの最大テスト番号を取得し
    ''' 新テスト番号を取得する
    ''' </remarks>
    Private Function setspecificTestNo() As String
        setspecificTestNo = Nothing
        Dim specificHeaderDt As New DataTable
        specificHeaderDt = getSpecificHeaderAll()
        Dim maxTestNo = specificHeaderDt.Compute("MAX(TESTNO_NUM)", "")
        If Mode = Common.Constant.SpecificShowMode.ShowTestList Then Return _TestNo
        If Not IsNothing(maxTestNo) AndAlso Not IsDBNull(maxTestNo) AndAlso IsNumeric(maxTestNo) Then
            Return (CInt(maxTestNo) + 1).ToString
        Else
            Return "1"
        End If

    End Function
    ''' <summary>
    ''' 指定テスト名チェック
    ''' </summary>
    ''' <returns>
    ''' True：OK
    ''' False：エラー
    ''' </returns>
    ''' <remarks>必須チェック、重複チェックを行う</remarks>
    Private Function specificTestCheck() As Boolean
        specificTestCheck = True
        '名称チェック
        If txtTestName.Text.Trim = String.Empty Then
            Common.Message.MessageShow("E005", {"テスト名"})
            txtTestName.Focus()
            Return False
        End If
        ''期間開始
        'If mskTestStart_DateTime.MaskCompleted = False Then
        '    Common.Message.MessageShow("E042", {"試験開始日時"})
        '    txtTestName.Focus()
        '    Return False
        'End If
        ''期間終了
        'If mskTestEnd_DateTime.MaskComplet　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　ed = False Then
        '    Common.Message.MessageShow("E042", {"試験終了日時"})
        '    txtTestName.Focus()
        '    Return False
        'ファイル名で使用禁止文字チェック
        Dim ngChars As String = (Common.Constant.CST_FILENAMECHARS_NG & "'").Replace("\", "\\")
        If Utility.IsNgChar(txtTestName.Text, ngChars) Then
            Dim chars As String = Common.Constant.CST_FILENAMECHARS_NG & "'"
            Dim str As String = ""
            For Each chr As Char In chars
                str &= "[" & chr.ToString & "]"
            Next
            Common.Message.MessageShow("E063", {"テスト名", str, ""})
            Return False
        End If
        '重複チェック
        If Not redundantCheckSpecificTestName(txtTestName.Text.Trim, _TestNo) Then
            Common.Message.MessageShow("E052", {"テスト名", "(" & txtTestName.Text.Trim & ")"})
            txtTestName.Focus()
            Return False
        End If

        ''試験日時の大小チェック
        'If CDate(mskTestStart_DateTime.Text) > CDate(mskTestEnd_DateTime.Text) Then
        '    Common.Message.MessageShow("E082")
        '    txtTestName.Focus()
        '    Return False
        'End If

        ''試験期間重複チェック
        'If Not GroupClass.GetInstance.checkTestRange(mskTestStart_DateTime.Text, mskTestEnd_DateTime.Text, _TestNo) Then
        '    Common.Message.MessageShow("E052", {"試験期間", ""})
        '    Return False
        'End If
    End Function

    ''' <summary>
    ''' 指定テスト名重複チェック
    ''' </summary>
    ''' <param name="testName"></param>
    ''' <returns>
    ''' True：OK
    ''' False：エラー（重複）
    ''' </returns>
    ''' <remarks>
    ''' 全ての指定テストヘッダーを取得し
    ''' 同一テスト名の件数を取得し、０件
    ''' 以上の場合、エラーとする
    ''' ※変更時は、自テスト№と異なる
    ''' データの件数
    ''' </remarks>
    ''' 
    Private Function redundantCheckSpecificTestName(ByVal testName As String, Optional ByVal specificNo As String = "") As Boolean
        redundantCheckSpecificTestName = True
        Dim specificHeaderDt As New DataTable
        specificHeaderDt = getSpecificHeaderAll()
        If specificHeaderDt.Rows.Count < 1 Then
            Return True
        End If
        'オプション
        If specificNo = String.Empty Then
            If specificHeaderDt.Compute("COUNT(TESTNO)", "TESTNAME = '" & testName & "'") > 0 Then
                Return False
            End If
        Else
            If specificHeaderDt.Compute("COUNT(TESTNO)", "TESTNAME = '" & testName & "' AND TESTNO <> '" & specificNo & "'") > 0 Then
                Return False
            End If
        End If

    End Function

    ''' <summary>
    ''' 全指定テストヘッダー取得
    ''' </summary>
    ''' <returns>指定テストヘッダー</returns>
    ''' <remarks>全ての指定テストヘッダーを取得し</remarks>
    Private Function getSpecificHeaderAll() As DataTable
        getSpecificHeaderAll = Nothing
        '取得済か
        If _SpecificHeaderDt.Rows.Count <> 0 Then
            Return _SpecificHeaderDt
        End If
        Dim filterName As String = Common.Constant.CST_SYNTHESISHEADER_FILENAME & Common.Constant.CST_GROUPNAME & Common.Constant.CST_EXTENSION_XML
        Common.XmlSchema.GetSynthesisHeaderSchema(_SpecificHeaderDt)

        For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath, filterName)
            _SpecificHeaderDt.Merge(Common.Serialize.XmlToDataTableFullPath(fileName))
        Next
        If Not _SpecificHeaderDt.Columns.Contains("TESTNO_NUM") Then
            _SpecificHeaderDt.Columns.Add("TESTNO_NUM", GetType(Integer), "Convert(TESTNO, 'System.Int32')")
        End If
        Return _SpecificHeaderDt
    End Function

    ''' <summary>
    ''' 問題確認画面へ渡す演習問題情報を設定する。
    ''' </summary>
    ''' <returns>演習問題情報</returns>
    ''' <remarks></remarks>
    Private Function createPraciticeQuestionInfoCollection() As PracticeQuestionShow.PraciticeQuestionInfoCollection
        Dim praciticeQuestionInfoCollection = New PracticeQuestionShow.PraciticeQuestionInfoCollection
        Dim dtPracticeQuestionList As DataTable = dgvPracticeQuestionList.DataSource

        For Each dgvr As DataGridViewRow In dgvPracticeQuestionList.Rows
            Dim dr As DataRow = dgvr.DataBoundItem.Row
            Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
            praciticeQuestionInfo.QuestionCode = dr(QUESTIONCODE.Name)
            praciticeQuestionInfo.MiddleQuestionCode = ""
            praciticeQuestionInfo.QuestionNo = dgvr.Cells(QUESTIONNO.Name).Value.ToString
            praciticeQuestionInfo.IsMiddleQuestion = False
            praciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
        Next
        Return praciticeQuestionInfoCollection
    End Function

    ''' <summary>
    ''' 問番号振り直し
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>問番号振り直し</remarks>
    Private Sub setQuestionNo(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim dgvPracticeQuestionListDt As DataTable = CType(dgvPracticeQuestionList.DataSource, DataTable)
        '入力問番
        Dim editValue As String = dgvPracticeQuestionList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        '入力行問題コード
        Dim editQuestionCode As String = dgvPracticeQuestionList.Rows(e.RowIndex).Cells(QUESTIONCODE.Name).Value
        Dim editValueNum As Integer = CInt(editValue)
        Dim indexNum As Integer
        indexNum = 0
        '編集行以外をナンバリング
        For Each row As DataRow In dgvPracticeQuestionListDt.Select("QUESTIONCODE <> '" & editQuestionCode & "'", "QUESTIONNO ASC")
            indexNum += 1
            If indexNum = editValueNum Then
                indexNum += 1

            End If
            row.Item(QUESTIONNO.Name) = indexNum
        Next
        '編集行設定
        For Each row As DataRow In dgvPracticeQuestionListDt.Select("QUESTIONCODE = '" & editQuestionCode & "'")
            row.Item(QUESTIONNO.Name) = editValueNum
        Next
        dgvPracticeQuestionListDt.AcceptChanges()
        '編集行範囲外の場合考慮
        indexNum = 0
        For Each row As DataRow In dgvPracticeQuestionListDt.Select("1=1", "[QUESTIONNO] ASC")
            indexNum += 1
            row.Item(QUESTIONNO.Name) = indexNum
        Next
        dgvPracticeQuestionListDt.AcceptChanges()
    End Sub

    ''' <summary>
    ''' WORDファイル出力
    ''' </summary>

    Private Sub btnWord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWord.Click
        Dim dgvPracticeQuestionListDt As DataTable = CType(dgvPracticeQuestionList.DataSource, DataTable)
        Dim WordApp As New Microsoft.Office.Interop.Word.Application
        Dim Doc As Microsoft.Office.Interop.Word.Document
        Dim cnt As Integer = 1

        Try
            'OpenFileDialogクラスのインスタンスを作成
            Dim ofd As New OpenFileDialog()

            ofd.Filter = "WORDファイル(*.doc,*.docx)|*.doc;*.docx"
            ofd.FilterIndex = 1
            ofd.Title = "出力するファイル名を入力してください"
            ofd.FileName = Me.txtTestName.Text & ".doc"
            ofd.RestoreDirectory = True
            ofd.CheckFileExists = False
            ofd.CheckPathExists = True

            'ダイアログを表示する
            If ofd.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            For Each row As DataRow In dgvPracticeQuestionListDt.Select("1=1", "[QUESTIONNO] ASC")
                Call makePracticeQuestion(row.Item(QUESTIONCODE.Name), cnt, ofd.FileName)
                cnt += 1
            Next

            Call CreateQuestionWordTail(ofd.FileName)

            Doc = WordApp.Documents.Open(ofd.FileName)

            Doc.SaveAs(ofd.FileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault)

            Doc.Close()
            WordApp.Quit()

            Common.Message.MessageShow("I007")      '保存が完了しました。

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' テストのWORDファイルを作成する。
    ''' </summary>
    ''' <param name="practiceQuestionCode">表示する問題番号</param>
    ''' <remarks></remarks>
    Private Sub makePracticeQuestion(ByVal practiceQuestionCode As String, ByVal cnt As Integer, ByVal Filename As String)

        ReadQuestionFile(Common.Constant.CST_PRACTICEQUESTION_FILENAME & practiceQuestionCode)

        Dim questionDefine As Common.VetNurseQuestionBank = _practiceQuestionBankCollection.Item(0)

        Dim Header As String = "問" & cnt & IIf(Me.ChkQ.Checked, "　　　問題コード：" & practiceQuestionCode, "") & IIf(Me.ChkT.Checked, "　　　正解：" & _practiceQuestionBankCollection.Item(0).Ansewr, "")

        Call questionDefine.CreateQuestionWord(Filename, cnt, Header)

    End Sub
    ''' <summary>
    ''' 問題読み込み処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadQuestionFile(ByVal FileName As String) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), FileName)
            Select Case questionFileNameList.Length
                Case 0
                    errCode = Constant.ResultCode.QuestionFileNotFoundError
                Case 1
                    Dim questionFileName = questionFileNameList(0)
                    _practiceQuestionBankCollection = Common.Serialize.BinaryFileToObject(IO.Path.GetFileName(questionFileName))
                    If _practiceQuestionBankCollection Is Nothing Then
                        errCode = Constant.ResultCode.QuestionFileReadError
                    Else
                        'If QuestionDefineCreator.Create(_practiceQuestionBankCollection) Is Nothing Then
                        '    errCode = Constant.ResultCode.QuestionFileParseError
                        'End If
                    End If
                Case Else
                    errCode = Constant.ResultCode.QuestionFileReadError
            End Select
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try

        Return errCode
    End Function

    ''' <summary>
    ''' 問題と選択肢を連結したファイルを、初回試験用、再試験用で作成します。
    ''' </summary>
    ''' <param name="WordfileName">保存するファイル名</param>
    ''' <remarks></remarks>
    Public Sub CreateQuestionWordTail(ByVal WordfileName As String)


        'Dim questionFilePath As String = ""

        Try

            'Dim directoryName = String.Format("{0}{1}", _
            '                                    Common.Constant.GetTempPath,
            '                                    QUESTION_DIRECTORY_NAME)
            'IO.Directory.CreateDirectory(directoryName)

            'questionFilePath = String.Format("{0}\Question{1:D3}.doc", _
            '                                        directoryName, _
            '                                        WordfileName)

            '設問の文字列の取得
            Dim sw As New System.IO.StreamWriter(WordfileName, True, System.Text.Encoding.GetEncoding("shift_jis"))
            sw.Write(GetQuestionHtmlT)
            sw.Close()

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' 設問のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionHtmlT() As String
        Dim strHtml As String = ""
        strHtml &= "</html>"
        Return strHtml
    End Function

#End Region
End Class