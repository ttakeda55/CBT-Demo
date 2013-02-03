''' <summary>
''' 演習問題群登録メニュー
''' </summary>
''' <remarks>
''' 2012/03/29 NAKAMURA 新規作成
''' </remarks>
'''  Public Class MyForm
Public Class frmCollectionMenu

#Region "メンバ変数"

    ''' <summary>
    ''' 問題群番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _CollectionNo As String = String.Empty

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
    ''' 演習問題一覧テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private PracticeQuestionListTable As New DataTable

    ''' <summary>
    ''' 問題群一覧テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private CollectionTable As New DataTable

    ''' <summary>
    ''' 問題群一覧（小問）テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiniCollection As New DataTable

    ''' <summary>
    ''' 問題群一覧（中問）テーブル
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleCollection As New DataTable

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
    Private Sub frmCollectionMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            '初期処理
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
    ''' コース登録/確認画面へ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>コース登録/確認画面に戻る。</remarks>
    Private Sub btnBackCourse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackCourse.Click
        Try
            logger.Start()
            '登録せずに戻る
            DataBanker("CollectionInput") = vbNo.ToString

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 中問一覧表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>演習問題群登録／中問一覧画面を表示する。</remarks>
    Private Sub btnCollectionMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollectionMiddle.Click
        Try
            logger.Start()
            '演習問題群登録/中問一覧へ
            Dim frm As New frmCollectionMiddle
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                '分類一覧作成
                'dgvCategoryList.DataSource = SetCategryList()
                '合計欄作成
                setTotal()
                Show()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    ''' <summary>
    ''' 演習問題群登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>演習問題群登録でチェックの付いた、演習問題を問題群として登録し、コース登録/確認画面に戻る。</remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            logger.Start()
            '登録しますか？
            If Common.Message.MessageShow("Q001") <> DialogResult.OK Then
                Exit Sub
            End If

            If lblTotal.Text <> "0" Then
                '問題群登録処理
                saveCollection()
                DataBanker("Collection") = "1"
            Else
                DataBanker("Collection") = "0"
            End If

            DataBanker("CollectionInput") = vbOK.ToString
            Me.DialogResult = Windows.Forms.DialogResult.OK
            'コース登録/確認に戻る
            Me.Close()
            '再描画指示
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グリッドクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>中分類クリック時、演習問題群登録／小問分野分類別一覧を表示する。</remarks>
    Private Sub dgvCategoryList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategoryList.CellContentClick
        Try
            logger.Start()

            '中分類クリックの時
            If dgvCategoryList.Columns.Item(e.ColumnIndex).Name <> "CATEGORYNAME" Or e.RowIndex = -1 Then Exit Sub

            '中分類を設定
            DataBanker("CategoryId") = dgvCategoryList(0, e.RowIndex).Value

            '演習問題群登録/小問分野分類別一覧へ
            Dim frm As New frmCollectionMini

            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                '分類一覧作成
                'dgvCategoryList.DataSource = SetCategryList()
                SetSelectNumber()

                '合計欄作成
                setTotal()

                Show()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' セルチェック
    ''' </summary>
    ''' <param name="column"></param>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks>指定したセルと1つ上のセルの値を比較</remarks>
    Function IsTheSameCellValue(ByVal column As Integer, ByVal row As Integer) As Boolean
        IsTheSameCellValue = False
        Try
            If row = 0 Then
                Return False
            End If
            If dgvCategoryList.Columns.Item(column).Name <> "CATEGORY1" And dgvCategoryList.Columns.Item(column).Name <> "CATEGORY2" Then
                Return False
            End If

            Dim cell1 As DataGridViewCell = dgvCategoryList(column, row)
            Dim cell2 As DataGridViewCell = dgvCategoryList(column, row - 1)

            If IsDBNull(cell1.Value) Or IsDBNull(cell2.Value) Then
                Return False
            End If

            ' ここでは文字列としてセルの値を比較
            If cell1.Value.ToString() = cell2.Value.ToString() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Function

    ''' <summary>
    ''' DataGridViewのCellFormattingイベント・ハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>セル表示時、前行と比較同じなら空白を設定</remarks>
    Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvCategoryList.CellFormatting
        Try
            ' 1行目については何もしない
            If e.RowIndex < 1 Then
                Return
            End If

            If IsTheSameCellValue(e.ColumnIndex, e.RowIndex) Then
                e.Value = ""
                e.FormattingApplied = True ' 以降の書式設定は不要
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' DataGridViewのCellPaintingイベント・ハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>セルの値が１つ上のセルと同じであれば、そのセルの上側の境界線を表示しない。</remarks>
    Sub dgvCategoryList_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles dgvCategoryList.CellPainting
        Try
            ' セルの下側の境界線を「境界線なし」に設定
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

            ' 1行目や列ヘッダ、行ヘッダの場合は何もしない
            If e.RowIndex < 1 Or e.ColumnIndex < 0 Then
                ' セルの上側の境界線を既定の境界線に設定
                e.AdvancedBorderStyle.Top = dgvCategoryList.AdvancedCellBorderStyle.Top
                Return
            End If

            If (dgvCategoryList.Columns.Item(e.ColumnIndex).Name = "CATEGORY1" Or
                dgvCategoryList.Columns.Item(e.ColumnIndex).Name = "CATEGORY2") AndAlso IsTheSameCellValue(e.ColumnIndex, e.RowIndex) Then
                ' セルの上側の境界線を「境界線なし」に設定
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
            Else
                ' セルの上側の境界線を既定の境界線に設定
                e.AdvancedBorderStyle.Top = dgvCategoryList.AdvancedCellBorderStyle.Top
            End If
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
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 初期処理
    ''' </summary>
    ''' <remarks>小問一覧及び合計欄を設定する。</remarks>
    Private Sub init()

        '問題群番号
        _CollectionNo = DataBanker("Course")
        _MiniCollection = DataBanker("SetMiniCollection")
        _MiddleCollection = DataBanker("SetMiddleCollection")

        'ラベル設定
        With dgvCategoryList
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        '分類一覧作成
        dgvCategoryList.DataSource = SetCategryList()

        '合計欄作成
        setTotal()

    End Sub

    ''' <summary>
    ''' カテゴリーリスト設定
    ''' </summary>
    ''' <returns></returns>
    ''' 小問のカテゴリーリストを取得する。
    ''' また選択数、全問題数を設定する。
    ''' <remarks></remarks>
    Private Function SetCategryList() As DataTable
        SetCategryList = Nothing
        Dim Dt As New DataTable
        '項目追加
        'カテゴリーID
        Dim CategoryId As New DataColumn
        CategoryId.ColumnName = "CATEGORYID"
        Dt.Columns.Add(CategoryId)
        '表示用ID
        Dim DisplayID As New DataColumn
        DisplayID.ColumnName = "DISPLAYID"
        Dt.Columns.Add(DisplayID)
        '分野
        Dim Category1 As New DataColumn
        Category1.ColumnName = "CATEGORY1"
        Dt.Columns.Add(Category1)
        '大分類
        Dim Category2 As New DataColumn
        Category2.ColumnName = "CATEGORY2"
        Dt.Columns.Add(Category2)
        'カテゴリー名（中分類）
        Dim CategoryName As New DataColumn
        CategoryName.ColumnName = "CATEGORYNAME"
        Dt.Columns.Add(CategoryName)
        '親カテゴリーID
        Dim ParentCategoryID As New DataColumn
        ParentCategoryID.ColumnName = "PARENTCATEGORYID"
        Dt.Columns.Add(ParentCategoryID)
        '親親カテゴリーID
        Dim PaParentCategoryID As New DataColumn
        PaParentCategoryID.ColumnName = "PAPARENTCATEGORYID"
        Dt.Columns.Add(PaParentCategoryID)
        '選択数
        Dim SelectNum As New DataColumn
        SelectNum.ColumnName = "SELECTNUM"
        Dt.Columns.Add(SelectNum)
        '計
        Dim Total As New DataColumn
        Total.ColumnName = "TOTAL"
        Dt.Columns.Add(Total)

        Dim Tmp As New DataTable
        'データ取得
        Tmp = GetCategryList()
        For Each Row As DataRow In Tmp.Rows
            Dt.ImportRow(Row)
        Next

        '親設定
        SetParent(Dt)

        '選択数、全問題数
        SetNumber(Dt)

        Return Dt
    End Function

    ''' <summary>
    ''' カテゴリーリスト取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 小問のカテゴリーリストを取得する。
    ''' </remarks>
    Private Function GetCategryList() As DataTable
        GetCategryList = Nothing
        Dim CategoryDt As New DataTable
        'カテゴリー取得
        CategoryDt = GetCategry()
        Dim Rows As DataRow() = CategoryDt.Select("CATEGORYCLASS = '3'")
        Dim ReturnDt As New DataTable
        ReturnDt = CategoryDt.Clone
        For Each Row As DataRow In Rows
            ReturnDt.ImportRow(Row)
        Next
        Return ReturnDt

    End Function

    ''' <summary>
    ''' 親カテゴリ名設定
    ''' </summary>
    ''' <param name="Dt"></param>
    ''' <remarks></remarks>
    Private Sub SetParent(ByVal Dt As DataTable)
        For Each Row As DataRow In Dt.Rows
            GetParent(Row, "PARENTCATEGORYID", "CATEGORY2")
        Next
    End Sub

    ''' <summary>
    ''' 親カテゴリ
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="Id"></param>
    ''' <param name="Name"></param>
    ''' <remarks>カテゴリーテーブルより、カテゴリー名と親カテゴリID</remarks>
    Private Sub GetParent(ByVal Row As DataRow, ByVal Id As String, ByVal Name As String)
        'Idで抽出
        Dim Rows As DataRow() = CategoryTable.Select("CATEGORYID = '" & Row.Item(Id) & "'")
        If Rows.Length > 0 Then
            'カテゴリー名称設定
            Row.Item(Name) = Rows(0).Item("CATEGORYNAME")
            '親カテゴリーID
            If Not IsDBNull(Rows(0).Item("PARENTCATEGORYID")) Then
                'ID設定
                Row.Item("PAPARENTCATEGORYID") = Rows(0).Item("PARENTCATEGORYID")
                '親カテゴリーID取得
                GetParent(Row, "PAPARENTCATEGORYID", "CATEGORY1")
            End If
        End If
    End Sub

    ''' <summary>
    ''' カテゴリーテーブル取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCategry() As DataTable
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
    ''' 選択数、全問題数
    ''' </summary>
    ''' <param name="Dt"></param>
    ''' <remarks></remarks>
    Private Sub SetNumber(ByVal Dt As DataTable)
        Dim PracticeQuestionList As New DataTable
        PracticeQuestionList = GetPracticeQuestionList()

        Dim Rows As DataRow()

        For Each Row As DataRow In Dt.Rows
            '選択数
            Rows = _MiniCollection.Select("PARENTCATEGORYID = '" & Row.Item("CATEGORYID") & "' AND CHECK = 1")
            Row.Item("SELECTNUM") = Rows.Length
            '総問題数
            Rows = PracticeQuestionList.Select("PARENTDISPLAYID = '" & Row.Item("DISPLAYID") & "' AND STATE = '0' AND QUESTIONCLASS = '1'")
            Row.Item("TOTAL") = Rows.Length
        Next
    End Sub

    ''' <summary>
    ''' 選択数のみ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSelectNumber()
        Dim dtCategoryList As DataTable = CType(dgvCategoryList.DataSource, DataTable)
        Dim selectCount As Object
        For Each Row As DataRow In dtCategoryList.Rows
            '選択数
            selectCount = _MiniCollection.Compute("COUNT(CHECK)", "PARENTCATEGORYID = '" & Row.Item("CATEGORYID") & "' AND CHECK = 1")
            Row.Item("SELECTNUM") = If(Not IsDBNull(selectCount), CInt(selectCount), 0)
        Next
    End Sub
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
            'QuestionListTable = Common.QuestionList.GetAll(Common.Constant.GetTempPath & fileName)
        End If
        '
        Dim Rows As DataRow()
        '親カテゴリーID
        If Not PracticeQuestionListTable.Columns.Contains("PARENTCATEGORYID") Then
            Dim ParentCategoryID As New DataColumn
            ParentCategoryID.ColumnName = "PARENTCATEGORYID"
            PracticeQuestionListTable.Columns.Add(ParentCategoryID)
        End If
        '親表示用ID
        If Not PracticeQuestionListTable.Columns.Contains("PARENTDISPLAYID") Then
            Dim ParentCategoryID As New DataColumn
            ParentCategoryID.ColumnName = "PARENTDISPLAYID"
            PracticeQuestionListTable.Columns.Add(ParentCategoryID)
        End If
        For Each Row As DataRow In PracticeQuestionListTable.Rows
            Rows = CategoryTable.Select("DISPLAYID = '" & Row.Item("CATEGORYID") & "'")
            If Rows.Length = 1 Then
                Row.Item("PARENTCATEGORYID") = Rows(0).Item("PARENTCATEGORYID")
                Rows = CategoryTable.Select("CATEGORYID = '" & Row.Item("PARENTCATEGORYID") & "'")
                If Rows.Length = 1 Then Row.Item("PARENTDISPLAYID") = Rows(0).Item("DISPLAYID")
            End If
        Next

        Return PracticeQuestionListTable
    End Function

    ''' <summary>
    ''' 問題群取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCollection() As DataTable
        GetCollection = Nothing
        '
        Dim fileName As String = Common.Constant.CST_COLLECTION_FILENAME & _CollectionNo & Common.Constant.CST_EXTENSION_XML
        '取得済か
        If CollectionTable.Rows.Count <> 0 Then
            Return CollectionTable
        End If
        '取得
        Dim TmpCollection As New DataTable
        If System.IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            TmpCollection = Common.Serialize.XmlToDataTable(fileName)
        End If

        Dim KeyUserId(0) As DataColumn
        '主キー設定
        KeyUserId(0) = TmpCollection.Columns("QUESTIONCODE")
        TmpCollection.PrimaryKey = KeyUserId

        Dim QuestionList As New DataTable
        QuestionList = GetPracticeQuestionList()
        '主キー設定
        KeyUserId(0) = QuestionList.Columns("QUESTIONCODE")
        QuestionList.PrimaryKey = KeyUserId

        TmpCollection.Merge(QuestionList)

        CollectionTable = TmpCollection.Clone
        For Each Row As DataRow In TmpCollection.Rows
            If Not IsDBNull(Row.Item("COLLECTIONNO")) Then CollectionTable.ImportRow(Row)
        Next
        For Each Row As DataRow In CollectionTable.Rows
            Debug.Print("COLLECTIONNO:" & Row.Item("COLLECTIONNO"))
            Debug.Print("QUESTIONCODE:" & Row.Item("QUESTIONCODE"))
            Debug.Print("PARENTCATEGORYID:" & Row.Item("PARENTCATEGORYID"))
            'PARENTCATEGORYID
        Next
        For Each Row As DataRow In QuestionList.Rows
            Debug.Print("PARENTCATEGORYID:" & Row.Item("PARENTCATEGORYID"))
        Next
        For Each Row As DataRow In TmpCollection.Rows
            Debug.Print("COLLECTIONNO:" & Row.Item("COLLECTIONNO"))
            Debug.Print("QUESTIONCODE:" & Row.Item("QUESTIONCODE"))
            Debug.Print("PARENTCATEGORYID:" & Row.Item("PARENTCATEGORYID"))
            'PARENTCATEGORYID
        Next
        Return CollectionTable
    End Function


    ''' <summary>
    ''' 合計欄設定
    ''' </summary>
    ''' <remarks>小問合計、中問合計、総計を表示する。</remarks>
    Private Sub setTotal()

        Dim Mini As Integer = _MiniCollection.Compute("COUNT(CHECK)", "CHECK = '1'")
        Dim Middle As Integer = _MiddleCollection.Compute("COUNT(CHECK)", "CHECK = '1' AND QUESTIONCODE = MAINCODE")
        Me.lblMini.Text = Mini.ToString
        Me.lblMiddle.Text = Middle.ToString
        Me.lblTotal.Text = Mini + (Middle * 4)

    End Sub

    ''' <summary>
    ''' 問題群登録
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub saveCollection()
        Dim Collection As New DataTable
        Dim FileName As String = Common.Constant.CST_COLLECTION_FILENAME & _CollectionNo & Common.Constant.CST_EXTENSION_XML
        Common.XmlSchema.GetCollectionSchema(Collection)
        '問題群（小問）
        For Each Row As DataRow In _MiniCollection.Rows
            If Not IsDBNull(Row.Item("CHECK")) AndAlso Row.Item("CHECK") = 1 Then
                Collection.ImportRow(setRowData(Row))
            End If
        Next
        '問題群（中問）
        For Each Row As DataRow In _MiddleCollection.Rows
            If Not IsDBNull(Row.Item("CHECK")) AndAlso Row.Item("CHECK") = 1 Then
                Collection.ImportRow(setRowData(Row))
            End If
        Next
        '書込み
        Common.Serialize.DataTableToxml(Collection, filename)
    End Sub

    ''' <summary>
    ''' 問題群、項目設定
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setRowData(ByVal Row As DataRow) As DataRow
        setRowData = Nothing
        Dim Collection As New DataTable
        Common.XmlSchema.GetCollectionSchema(Collection)
        Collection.Rows.Add()
        With Collection.Rows(0)
            .Item("COURSENO") = _CollectionNo
            .Item("QUESTIONCODE") = Row.Item("QUESTIONCODE")
            .Item("CREATE_DATE") = Format(Date.Now, "yyyy/MM/dd HH:mm:dd")
            .Item("UPDATE_DATE") = Format(Date.Now, "yyyy/MM/dd HH:mm:dd")
        End With
        Return Collection.Rows(0)
    End Function

#End Region

End Class




