''' <summary>
''' 演習問題群登録／小問分野分類一覧
''' </summary>
''' <remarks>
''' 2012/03/29 NAKAMURA 新規作成
''' </remarks>
Public Class frmCollectionMini

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
    ''' 問題群一覧（小問）テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiniCollection As New DataTable

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
    Private Sub frmCollectionMini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            setMiniList()
            'Debug.Print("CHECK:" & _MiniCollection.Compute("COUNT(QUESTIONCODE)", "CHECK = 1"))

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
                dgvPracticeQuestionList(dgvPracticeQuestionList.Columns("CHECK").Index, i).Value = True
            Next
            dgvPracticeQuestionList.CommitEdit(DataGridViewDataErrorContexts.Commit)

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
                dgvPracticeQuestionList(dgvPracticeQuestionList.Columns("CHECK").Index, i).Value = False
            Next
            dgvPracticeQuestionList.CommitEdit(DataGridViewDataErrorContexts.Commit)

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
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(e.RowIndex, PraciticeQuestionInfoCollection)
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
    ''' <remarks>小問一覧を設定する。</remarks>
    Private Sub init()
        '問題群番号
        _CollectionNo = DataBanker("CollectionNo")
        _MiniCollection = DataBanker("SetMiniCollection")

        'カテゴリー表示
        lblCategory.Text = setLblCategory()

        '小問一覧取得
        dgvPracticeQuestionList.DataSource = GetPracticeQuestionMiniList()

    End Sub

    ''' <summary>
    ''' ラベルカテゴリー名設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setLblCategory() As String
        setLblCategory = Nothing
        Dim categoryName As String = String.Empty
        Dim parentCategoryId As String = String.Empty

        'カテゴリID退避
        _CategoryId = DataBanker("CategoryId")

        'カテゴリーテーブル取得
        Dim category As New DataTable
        category = GetCategory()

        '中分類取得
        Dim rows As DataRow()
        rows = category.Select("CATEGORYID = '" & _CategoryId & "'")
        If rows.Length <> 1 Then
            Return Common.Message.GetMessage("E056", {_CategoryId})
        End If
        '名称
        categoryName = rows(0).Item("CATEGORYNAME")
        '親カテゴリーID
        parentCategoryId = rows(0).Item("PARENTCATEGORYID")

        '大分類取得
        rows = category.Select("CATEGORYID = '" & parentCategoryId & "'")
        If rows.Length <> 1 Then
            Return Common.Message.GetMessage("E056", {parentCategoryId})
        End If
        '名称
        categoryName = rows(0).Item("CATEGORYNAME") & "　－　" & categoryName
        '親カテゴリーID
        parentCategoryId = rows(0).Item("PARENTCATEGORYID")

        '分野取得
        rows = category.Select("CATEGORYID = '" & parentCategoryId & "'")
        If rows.Length <> 1 Then
            Return Common.Message.GetMessage("E056", {parentCategoryId})
        End If
        '名称
        categoryName = rows(0).Item("CATEGORYNAME") & "　－　" & categoryName
        Return categoryName
    End Function

    ''' <summary>
    ''' カテゴリーテーブル取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCategory() As DataTable
        Dim fileName As String = Common.Constant.CST_CATEGORY_FILENAME & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If CategoryTable.Rows.Count <> 0 Then
            Return CategoryTable
        End If
        '取得
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            CategoryTable = Common.Serialize.XmlToDataTable(Common.Constant.CST_CATEGORY_FILENAME & Common.Constant.CST_EXTENSION_XML)
        End If

        Return CategoryTable
    End Function

    ''' <summary>
    ''' 小問一覧取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>小問一覧を取得する。</remarks>
    Private Function GetPracticeQuestionMiniList() As DataTable
        GetPracticeQuestionMiniList = Nothing
        '初回
        Dim miniCollection As New DataTable
        '項目追加
        '選択
        Dim checkCol As New DataColumn
        checkCol.ColumnName = CHECK.Name
        checkCol.DataType = GetType(Integer)
        miniCollection.Columns.Add(checkCol)
        '問題コード
        Dim questionCodeCol As New DataColumn
        questionCodeCol.ColumnName = QUESTIONCODE.Name
        miniCollection.Columns.Add(questionCodeCol)
        '問題テーマ
        Dim themeCol As New DataColumn
        themeCol.ColumnName = THEME.Name
        miniCollection.Columns.Add(themeCol)
        'グループ
        Dim groupCol As New DataColumn
        groupCol.ColumnName = GROUP.Name
        miniCollection.Columns.Add(groupCol)
        '出題形式
        Dim formatCol As New DataColumn
        formatCol.ColumnName = FORMAT.Name
        miniCollection.Columns.Add(formatCol)

        '抽出処理
        For Each Row As DataRow In _MiniCollection.Select("PARENTCATEGORYID = '" & _CategoryId & "'")
            '状態設定
            miniCollection.ImportRow(Row)
        Next

        '表示順
        miniCollection.DefaultView.Sort = "QUESTIONCODE"

        Return miniCollection
    End Function

    ''' <summary>
    ''' 小問一覧退避
    ''' </summary>
    ''' <remarks>小問一覧を退避する。</remarks>
    Private Sub setMiniList()
        Dim Tmp As New DataTable

        Tmp = CType(dgvPracticeQuestionList.DataSource, DataTable)
        'Dim KeyUserId(0) As DataColumn
        ' ''主キー設定
        'KeyUserId(0) = Tmp.Columns("QUESTIONCODE")
        'Tmp.PrimaryKey = KeyUserId
        'For Each Row As DataRow In Tmp.Rows
        '    If Row.RowState = DataRowState.Unchanged Then Row.SetModified()
        '    Debug.Print(Row.Item("QUESTIONCODE") & ":" & Row.Item("CHECK").ToString)
        'Next

        '_MiniCollection.Merge(Tmp)
        Dim Rows As DataRow()
        For Each Row As DataRow In _MiniCollection.Rows
            Rows = Tmp.Select("QUESTIONCODE = '" & Row.Item("QUESTIONCODE") & "'")
            If Rows.Length = 1 Then
                Row.Item("CHECK") = Rows(0).Item("CHECK")
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

        For Each dgvr As DataGridViewRow In dgvPracticeQuestionList.Rows
            Dim dr As DataRow = dgvr.DataBoundItem.Row
            Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
            praciticeQuestionInfo.QuestionCode = dr(QUESTIONCODE.Name)
            praciticeQuestionInfo.MiddleQuestionCode = String.Empty
            praciticeQuestionInfo.IsMiddleQuestion = False
            praciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
        Next
        Return praciticeQuestionInfoCollection
    End Function
#End Region

End Class