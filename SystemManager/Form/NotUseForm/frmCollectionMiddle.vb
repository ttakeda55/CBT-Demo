''' <summary>
''' 演習問題群登録／中問一覧
''' </summary>
''' <remarks>
''' 2012/03/29 NAKAMURA 新規作成
''' </remarks>
Public Class frmCollectionMiddle

#Region "メンバ変数"

    ''' <summary>
    ''' 問題群番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _CollectionNo As String = String.Empty

    ''' <summary>
    ''' カテゴリーID
    ''' </summary>
    ''' <remarks></remarks>
    Private _CategoryId As String = String.Empty

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
    ''' 問題群一覧（中問）テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleCollection As New DataTable

    ''' <summary>
    ''' 演習問題一覧テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private PracticeQuestionListTable As New DataTable

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
    Private Sub frmCollectionMiddle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            '初期設定
            init()
            'オーナー非表示
            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 演習問題群登録メニューへ戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>演習問題群登録メニューへ戻る</remarks>
    Private Sub btnBackCourse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackCourse.Click
        Try
            logger.Start()
            '設定値退避
            setMiddleList()

            '演習問題群登録メニューへ戻る
            Me.DialogResult = DialogResult.OK
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 全チェック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>全てのチェックを設定する。</remarks>
    Private Sub btnCheckAllOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAllOn.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvPracticeQuestionList.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                dgvPracticeQuestionList(0, i).Value = True
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
    ''' <remarks>全てのチェックを解除する。</remarks>
    Private Sub btnCheckAllOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAllOff.Click
        Try
            logger.Start()
            For i As Integer = 0 To dgvPracticeQuestionList.RowCount - 1
                ' チェックボックスの列番号を指定して、チェックをつける
                dgvPracticeQuestionList(0, i).Value = False
            Next
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題番号クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPracticeQuestionList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeQuestionList.CellContentClick
        Try
            logger.Start()
            If e.RowIndex <> -1 And dgvPracticeQuestionList.Columns(e.ColumnIndex).Name = QUESTIONCODE.Name Then
                Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection
                PraciticeQuestionInfoCollection = createPraciticeQuestionInfoCollection()
                Dim questionIndex As Integer = e.RowIndex * 4
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(questionIndex, PraciticeQuestionInfoCollection)
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
    ''' <remarks>中問一覧を設定する。</remarks>
    Private Sub init()
        '問題群番号
        _CollectionNo = DataBanker("CollectionNo")
        _MiddleCollection = DataBanker("SetMiddleCollection")

        '小問一覧取得
        dgvPracticeQuestionList.DataSource = getQuestionMiddleList()

        With dgvPracticeQuestionList
            'ラベルスタイル設定
            .Columns(.Columns("THEME1").Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(.Columns("THEME2").Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(.Columns("THEME3").Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(.Columns("THEME4").Index).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

    End Sub

    ''' <summary>
    ''' 中問一覧取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>中問一覧を取得する。</remarks>
    Private Function getQuestionMiddleList() As DataTable
        getQuestionMiddleList = Nothing
        '初回
        Dim middledt As New DataTable
        '項目追加
        '選択
        Dim checkCol As New DataColumn
        checkCol.ColumnName = CHECK.Name
        checkCol.DataType = GetType(Integer)
        middledt.Columns.Add(checkCol)
        '問題コード
        Dim questionCodeCol As New DataColumn
        questionCodeCol.ColumnName = QUESTIONCODE.Name
        middledt.Columns.Add(questionCodeCol)
        '親問題コード
        Dim mainCodeCol As New DataColumn
        mainCodeCol.ColumnName = MAINCODE.Name
        middledt.Columns.Add(mainCodeCol)
        '問題テーマ
        Dim themeCol As New DataColumn
        themeCol.ColumnName = THEME.Name
        middledt.Columns.Add(themeCol)
        '問題テーマ
        Dim theme1Col As New DataColumn
        theme1Col.ColumnName = THEME1.Name
        middledt.Columns.Add(theme1Col)
        '問題テーマ
        Dim theme2Col As New DataColumn
        theme2Col.ColumnName = THEME2.Name
        middledt.Columns.Add(theme2Col)
        '問題テーマ
        Dim theme3Col As New DataColumn
        theme3Col.ColumnName = THEME3.Name
        middledt.Columns.Add(theme3Col)
        '問題テーマ
        Dim theme4Col As New DataColumn
        theme4Col.ColumnName = THEME4.Name
        middledt.Columns.Add(theme4Col)

        Dim middlerows As DataRow()
        '抽出処理
        For Each colrow As DataRow In _MiddleCollection.Select("MAINCODE = QUESTIONCODE")
            '状態設定
            middledt.ImportRow(colrow)
        Next
        For Each middlerow As DataRow In middledt.Rows
            middlerows = _MiddleCollection.Select("MAINCODE = '" & middlerow.Item("QUESTIONCODE") & "' AND MAINCODE <> QUESTIONCODE", "MAINCODE,MIDDLEQUESTIONINDEX")
            If middlerows.Length <= 4 Then
                For i As Integer = 0 To 4 - 1
                    If i > middlerows.Length - 1 Then
                        Exit For
                    End If
                    middlerow.Item("THEME" & (i + 1).ToString) = middlerows(i).Item(THEME.Name)
                Next
            End If
        Next

        Return middledt
    End Function

    ''' <summary>
    ''' 中問一覧退避
    ''' </summary>
    ''' <remarks>中問一覧を退避する。</remarks>
    Private Sub setMiddleList()
        Dim tmpPracticeQuestionList As New DataTable

        tmpPracticeQuestionList = CType(Me.dgvPracticeQuestionList.DataSource, DataTable)

        '_MiniCollection.Merge(Tmp)
        Dim mainRows As DataRow()
        For Each Row As DataRow In _MiddleCollection.Rows
            mainRows = tmpPracticeQuestionList.Select("MAINCODE = '" & Row.Item(MAINCODE.Name) & "'")
            If mainRows.Length = 1 Then
                Row.Item(CHECK.Name) = mainRows(0).Item(CHECK.Name)
            End If
        Next

    End Sub

    ''' <summary>
    ''' 問題確認画面へ渡す演習問題情報を設定する。
    ''' </summary>
    ''' <returns>演習問題情報</returns>
    ''' <remarks></remarks>
    Private Function createPraciticeQuestionInfoCollection() As PracticeQuestionShow.PraciticeQuestionInfoCollection
        Dim praciticeQuestionInfoCollection = New PracticeQuestionShow.PraciticeQuestionInfoCollection
        Dim dtPracticeQuestionList As DataTable = dgvPracticeQuestionList.DataSource
        Dim practiceQuestionList As New DataTable
        Dim practiceRows As DataRow()
        '演習問題一覧取得
        practiceQuestionList = GetPracticeQuestionList()
        For Each dgvr As DataGridViewRow In dgvPracticeQuestionList.Rows
            Dim dr As DataRow = dgvr.DataBoundItem.Row

            '主文問題コードから設問を取得
            practiceRows = practiceQuestionList.Select("MAINCODE ='" & dr(QUESTIONCODE.Name) & "' AND MAINCODE <> QUESTIONCODE", "MAINCODE,MIDDLEQUESTIONINDEX")
            For Each practiceRow As DataRow In practiceRows
                Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
                praciticeQuestionInfo.QuestionCode = practiceRow.Item(QUESTIONCODE.Name)
                praciticeQuestionInfo.MiddleQuestionCode = dr(QUESTIONCODE.Name)
                praciticeQuestionInfo.IsMiddleQuestion = True
                praciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
            Next
        Next
        Return praciticeQuestionInfoCollection
    End Function

    ''' <summary>
    ''' 演習問題一覧取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPracticeQuestionList() As DataTable
        GetPracticeQuestionList = Nothing
        '
        Dim fileName As String = Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If PracticeQuestionListTable.Rows.Count <> 0 Then
            Return PracticeQuestionListTable
        End If
        '取得
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            PracticeQuestionListTable = Common.Serialize.XmlToDataTable(fileName)
        End If

        Return PracticeQuestionListTable
    End Function

#End Region

End Class