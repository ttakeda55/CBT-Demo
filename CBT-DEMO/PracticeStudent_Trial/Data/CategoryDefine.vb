
''' <summary>
''' カテゴリー定義クラス
''' </summary>
''' <remarks></remarks>
Public Class CategoryDefine

#Region "----- 定数 -----"

    ''' <summary>分類区分</summary>
    Private Enum CategoryClass As Integer
        ''' <summary>分類</summary>
        ClassCategory = 1
        ''' <summary>大分類</summary>
        LargeCategory = 2
        ''' <summary>中分類</summary>
        MiddleCategory = 3
        ''' <summary>グループ</summary>
        GroupCategory = 4
    End Enum

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>分類名</summary>
        CategoryName = 0
        ''' <summary>分類カテゴリーID</summary>
        CategoryId
        ''' <summary>分類表示ID</summary>
        DisplyId
        ''' <summary>大分類名</summary>
        LargeCategoryName
        ''' <summary>大分類カテゴリーID</summary>
        LargeCategoryId
        ''' <summary>大分類表示ID</summary>
        LargeDisplyId
        ''' <summary>中分類名</summary>
        MiddleCategoryName
        ''' <summary>中分類カテゴリーID</summary>
        MiddleCategoryId
        ''' <summary>中分類表示ID</summary>
        MiddleDisplyId
        ''' <summary>グループ名</summary>
        GroupName
        ''' <summary>グループID</summary>
        GroupId
        ''' <summary>キーワード</summary>
        Keyword
    End Enum

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>カテゴリー格納DataTable</summary>
    Private _CategoryTbl As New DataTable
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' カテゴリーDataTableの取得
    ''' </summary>
    ''' <returns>カテゴリーDataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CategoryDataTable As DataTable
        Get
            If IsNothing(_CategoryTbl) Then
                Return Nothing
            Else
                Return _CategoryTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 分野カテゴリーIDの取得
    ''' </summary>
    ''' <param name="CategoryName">分野カテゴリー名</param>
    ''' <returns>分野カテゴリーID</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CategoryId(ByVal CategoryName As String) As String
        Get
            Dim retId As String = ""
            Dim filter As String = "CategoryName = '" & CategoryName & "'"
            If CategoryName = "" Then Return retId
            For Each rowData As DataRow In _CategoryTbl.Select(filter)
                retId = rowData.Item(ColumnIndex.DisplyId)
                Exit For
            Next
            Return retId
        End Get
    End Property

    ''' <summary>
    ''' 大分類カテゴリーIDの取得
    ''' </summary>
    ''' <param name="LargeCategoryName">大分類カテゴリー名</param>
    ''' <returns>大分類カテゴリーID</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LargeCategoryId(ByVal LargeCategoryName As String) As String
        Get
            Dim retId As String = ""
            Dim filter As String = "LargeCategoryName = '" & LargeCategoryName & "'"
            If LargeCategoryName = "" Then Return retId
            For Each rowData As DataRow In _CategoryTbl.Select(filter)
                retId = rowData.Item(ColumnIndex.LargeDisplyId)
                Exit For
            Next
            Return retId
        End Get
    End Property

    ''' <summary>
    ''' 中分類カテゴリーIDの取得
    ''' </summary>
    ''' <param name="MiddleCategoryName">中分類カテゴリー名</param>
    ''' <returns>中分類カテゴリーID</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MiddleCategoryId(ByVal MiddleCategoryName As String) As String
        Get
            Dim retId As String = ""
            Dim filter As String = "MiddleCategoryName = '" & MiddleCategoryName & "'"
            If MiddleCategoryName = "" Then Return retId
            For Each rowData As DataRow In _CategoryTbl.Select(filter)
                retId = rowData.Item(ColumnIndex.MiddleDisplyId)
                Exit For
            Next
            Return retId
        End Get
    End Property


#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' カテゴリーファイル読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadCategory() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim WkTbl As DataTable = Nothing
        Try
            'DataTable取得
            WkTbl = Common.CategoryMaster.GetAll()
            If WkTbl.Rows.Count < 1 Then
                errCode = Constant.ResultCode.CategoryFileReadError
            Else
                errCode = CreateCategoryTable(WkTbl)
            End If
            'CSV出力(DEBUG用)
            DebugFile.DataTableOutPutCsv(_CategoryTbl, DebugFile.FileType.Category)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try

        Return errCode
    End Function

    ''' <summary>
    ''' カテゴリーDataTable作成
    ''' </summary>
    ''' <param name="wkTbl">読込カテゴリーDataTable</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function CreateCategoryTable(ByVal wkTbl As DataTable) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            'フィールド追加
            errCode = AddColumn()
            'グループ、キーワード設定
            If errCode = Constant.ResultCode.NormalEnd Then errCode = SetGroup(wkTbl)
            '中分類設定
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = SetMiddleClass(wkTbl)
            '大分類設定
            'If errCode = Constant.ResultCode.NormalEnd Then errCode = SetLargeClass(wkTbl)
            '分類設定
            If errCode = Constant.ResultCode.NormalEnd Then errCode = SetClass(wkTbl)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' フィールド追加
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function AddColumn() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            _CategoryTbl.Clear()
            _CategoryTbl.Columns.Clear()
            '分類名
            _CategoryTbl.Columns.Add("CategoryName", GetType(String))
            '分類カテゴリーID
            _CategoryTbl.Columns.Add("CategoryId", GetType(String))
            '分類表示ID
            _CategoryTbl.Columns.Add("DisplyId", GetType(String))
            '大分類名
            _CategoryTbl.Columns.Add("LargeCategoryName", GetType(String))
            '大分類カテゴリーID
            _CategoryTbl.Columns.Add("LargeCategoryId", GetType(String))
            '大分類表示ID
            _CategoryTbl.Columns.Add("LargeDisplyId", GetType(String))
            '中分類名
            _CategoryTbl.Columns.Add("MiddleCategoryName", GetType(String))
            '中分類カテゴリーID
            _CategoryTbl.Columns.Add("MiddleCategoryId", GetType(String))
            '中分類表示ID
            _CategoryTbl.Columns.Add("MiddleDisplyId", GetType(String))
            'グループ名
            _CategoryTbl.Columns.Add("GroupName", GetType(String))
            'グループID
            _CategoryTbl.Columns.Add("GroupId", GetType(String))
            'キーワード
            _CategoryTbl.Columns.Add("Keyword", GetType(String))
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode

    End Function

    ''' <summary>
    ''' グループ、キーワード設定
    ''' </summary>
    ''' <param name="dt">読込カテゴリーDataTable</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function SetGroup(ByVal dt As DataTable) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim filter As String = ""
        Dim newRowData As DataRow = Nothing

        Try
            'filter = "CATEGORYCLASS = '" & CategoryClass.MiddleCategory & "'"
            'For Each rowData As DataRow In dt.Select(filter, "DisplayID")
            '    newRowData = _CategoryTbl.NewRow
            '    newRowData.Item(ColumnIndex.CategoryName) = ""
            '    newRowData.Item(ColumnIndex.CategoryId) = ""
            '    newRowData.Item(ColumnIndex.DisplyId) = ""
            '    newRowData.Item(ColumnIndex.LargeCategoryName) = ""
            '    newRowData.Item(ColumnIndex.LargeCategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
            '    newRowData.Item(ColumnIndex.LargeDisplyId) = ""
            '    newRowData.Item(ColumnIndex.MiddleCategoryName) = ""
            '    newRowData.Item(ColumnIndex.MiddleCategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
            '    newRowData.Item(ColumnIndex.MiddleDisplyId) = ""
            '    newRowData.Item(ColumnIndex.GroupName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
            '    newRowData.Item(ColumnIndex.GroupId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
            '    newRowData.Item(ColumnIndex.Keyword) = rowData.Item(Common.CategoryMaster.ColumnIndex.KEYWORD)
            '    _CategoryTbl.Rows.Add(newRowData)
            'Next
            filter = "CATEGORYCLASS = '" & CategoryClass.LargeCategory & "'"
            For Each rowData As DataRow In dt.Select(filter, "DisplayID")
                newRowData = _CategoryTbl.NewRow
                newRowData.Item(ColumnIndex.CategoryName) = ""
                newRowData.Item(ColumnIndex.CategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
                newRowData.Item(ColumnIndex.DisplyId) = ""
                newRowData.Item(ColumnIndex.LargeCategoryName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
                newRowData.Item(ColumnIndex.LargeCategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
                newRowData.Item(ColumnIndex.LargeDisplyId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
                newRowData.Item(ColumnIndex.MiddleCategoryName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
                newRowData.Item(ColumnIndex.MiddleCategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYID)
                newRowData.Item(ColumnIndex.MiddleDisplyId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
                newRowData.Item(ColumnIndex.GroupName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
                newRowData.Item(ColumnIndex.GroupId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
                newRowData.Item(ColumnIndex.Keyword) = rowData.Item(Common.CategoryMaster.ColumnIndex.KEYWORD)
                _CategoryTbl.Rows.Add(newRowData)
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 中分類設定
    ''' </summary>
    ''' <param name="dt">読込カテゴリーDataTable</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function SetMiddleClass(ByVal dt As DataTable) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim filter As String = ""

        Try
            filter = "CATEGORYCLASS = '" & CategoryClass.MiddleCategory & "'"
            For Each rowData As DataRow In dt.Select(filter, "DisplayID")
                For Each dtRowData As DataRow In _CategoryTbl.Rows
                    If rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYID) = dtRowData.Item(ColumnIndex.MiddleCategoryId) Then
                        dtRowData.Item(ColumnIndex.LargeCategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
                        dtRowData.Item(ColumnIndex.MiddleCategoryName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
                        dtRowData.Item(ColumnIndex.MiddleDisplyId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
                    End If
                Next
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 大分類設定
    ''' </summary>
    ''' <param name="dt">読込カテゴリーDataTable</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function SetLargeClass(ByVal dt As DataTable) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim filter As String = ""

        Try
            filter = "CATEGORYCLASS = '" & CategoryClass.LargeCategory & "'"
            For Each rowData As DataRow In dt.Select(filter, "DisplayID")
                For Each dtRowData As DataRow In _CategoryTbl.Rows
                    If rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYID) = dtRowData.Item(ColumnIndex.LargeCategoryId) Then
                        dtRowData.Item(ColumnIndex.CategoryId) = rowData.Item(Common.CategoryMaster.ColumnIndex.PARENTCATEGORYID)
                        dtRowData.Item(ColumnIndex.LargeCategoryName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
                        dtRowData.Item(ColumnIndex.LargeDisplyId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
                    End If
                Next
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 分野設定
    ''' </summary>
    ''' <param name="dt">読込カテゴリーDataTable</param>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function SetClass(ByVal dt As DataTable) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim filter As String = ""

        Try
            filter = "CATEGORYCLASS = '" & CategoryClass.ClassCategory & "'"
            For Each rowData As DataRow In dt.Select(filter, "DisplayID")
                For Each dtRowData As DataRow In _CategoryTbl.Rows
                    If rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYID) = dtRowData.Item(ColumnIndex.CategoryId) Then
                        dtRowData.Item(ColumnIndex.CategoryName) = rowData.Item(Common.CategoryMaster.ColumnIndex.CATEGORYNAME)
                        dtRowData.Item(ColumnIndex.DisplyId) = rowData.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
                    End If
                Next
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 分類名取得
    ''' </summary>
    ''' <param name="largeClassCategoryName">大分類名</param>
    ''' <returns>分類名リスト</returns>
    ''' <remarks></remarks>
    Public Function GetClassCategoryName(Optional ByVal largeClassCategoryName As String = "") As List(Of String)
        Dim CategoryNames As New List(Of String)
        Dim filter As String = ""
        Dim CategoryName As String = ""

        Try
            If largeClassCategoryName = "" Then
                Dim dt As DataTable = _CategoryTbl.DefaultView.ToTable(True, "CategoryName")
                For Each rowData As DataRow In dt.Rows
                    CategoryNames.Add(rowData.Item(0))
                Next
            Else
                filter = "LargeCategoryName = '" & largeClassCategoryName & "'"
                For Each rowData As DataRow In _CategoryTbl.Select(filter)
                    If CategoryName <> rowData.Item(ColumnIndex.CategoryName) Then
                        CategoryNames.Add(rowData.Item(ColumnIndex.CategoryName))
                        CategoryName = rowData.Item(ColumnIndex.CategoryName).ToString
                    End If
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            CategoryNames.Clear()
        End Try
        Return CategoryNames
    End Function

    ''' <summary>
    ''' 大分類名取得
    ''' </summary>
    ''' <param name="CategoryName">カテゴリー名</param>
    ''' <param name="blnMiddle">中分類フラグ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLargeClassCategoryName(Optional ByVal CategoryName As String = "", Optional ByVal blnMiddle As Boolean = False) As List(Of String)
        Dim CategoryNames As New List(Of String)
        Dim filter As String = ""
        Dim LargeCategoryName As String = ""

        Try
            If CategoryName = "" Then
                Dim dt As DataTable = _CategoryTbl.DefaultView.ToTable(True, "LargeCategoryName")
                For Each rowData As DataRow In dt.Rows
                    CategoryNames.Add(rowData.Item(0))
                Next
            Else
                If blnMiddle Then
                    '中分類名が設定されている
                    filter = "MiddleCategoryName = '" & CategoryName & "'"
                Else
                    '分類名が設定されている
                    filter = "CategoryName = '" & CategoryName & "'"
                End If
                For Each rowData As DataRow In _CategoryTbl.Select(filter)
                    If LargeCategoryName <> rowData.Item(ColumnIndex.LargeCategoryName).ToString Then
                        CategoryNames.Add(rowData.Item(ColumnIndex.LargeCategoryName))
                        LargeCategoryName = rowData.Item(ColumnIndex.LargeCategoryName).ToString
                    End If
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            CategoryNames.Clear()
        End Try
        Return CategoryNames
    End Function

    ''' <summary>
    ''' 中分類名取得
    ''' </summary>
    ''' <param name="CategoryName">大分類名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMiddleClassCategoryName(Optional ByVal CategoryName As String = "", Optional ByVal LargeCategoryName As String = "") As List(Of String)
        Dim CategoryNames As New List(Of String)
        Dim filter As String = ""
        Dim MiddleCategoryName As String = ""

        Try
            If CategoryName = "" Then
                Dim dt As DataTable = _CategoryTbl.DefaultView.ToTable(True, "MiddleCategoryName")
                For Each rowData As DataRow In dt.Rows
                    CategoryNames.Add(rowData.Item(0))
                Next
            Else
                If LargeCategoryName = "" Then
                    filter = "CategoryName = '" & CategoryName & "'"
                Else
                    filter = "CategoryName = '" & CategoryName & "' AND LargeCategoryName = '" & LargeCategoryName & "'"
                End If

                For Each rowData As DataRow In _CategoryTbl.Select(filter)
                    If MiddleCategoryName <> rowData.Item(ColumnIndex.MiddleCategoryName).ToString Then
                        CategoryNames.Add(rowData.Item(ColumnIndex.MiddleCategoryName))
                        MiddleCategoryName = rowData.Item(ColumnIndex.MiddleCategoryName).ToString
                    End If
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            CategoryNames.Clear()
        End Try
        Return CategoryNames
    End Function

    ''' <summary>
    ''' 中分類カテゴリーIDとグループIDの紐付け取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGroupIdForMiddleCategory() As Generic.Dictionary(Of String, Generic.List(Of String))
        Dim dicGroupId As New Generic.Dictionary(Of String, Generic.List(Of String))
        Dim GroupIdList As Generic.List(Of String)

        Try
            Dim dt As DataTable = _CategoryTbl.DefaultView.ToTable(True, "MiddleCategoryId", "GroupId")
            For Each rowData As DataRow In dt.Rows
                If dicGroupId.ContainsKey(rowData.Item(0)) Then
                    dicGroupId.Item(rowData.Item(0)).Add(rowData.Item(1))
                Else
                    GroupIdList = New Generic.List(Of String)
                    GroupIdList.Add(rowData.Item(1))
                    dicGroupId.Add(rowData.Item(0), GroupIdList)
                End If
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return dicGroupId
    End Function

    ''' <summary>
    ''' グループカテゴリーID取得
    ''' </summary>
    ''' <param name="CategoryName">分類カテゴリー名</param>
    ''' <param name="LargeCategoryName">大分類カテゴリー名</param>
    ''' <param name="MiddleCategoryName">中分類カテゴリー名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGroupIdList(ByVal CategoryName As String, ByVal LargeCategoryName As String, ByVal MiddleCategoryName As String) As Generic.List(Of String)
        'Dim GroupIdList As Generic.List(Of String) = Nothing
        Dim GroupIdList As New Generic.List(Of String)
        Dim CategoryId As Generic.List(Of String) = Nothing
        Dim LargeCategoryId As Generic.List(Of String) = Nothing
        Dim MiddleCategoryId As Generic.List(Of String) = Nothing

        Try
            If CategoryName = "" Then
                Dim dt As DataTable = _CategoryTbl.DefaultView.ToTable(True, "GroupId")
                For Each rowData As DataRow In dt.Rows
                    GroupIdList.Add(rowData.Item(0))
                Next
            Else
                'グループカテゴリーID取得
                GroupIdList = GetCategoryIdList(CategoryName, LargeCategoryName, MiddleCategoryName)
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return GroupIdList
    End Function

    ''' <summary>
    ''' カテゴリーID取得
    ''' </summary>
    ''' <param name="CategoryName">分類カテゴリー名</param>
    ''' <param name="LargeCategoryName">大分類カテゴリー名</param>
    ''' <param name="MiddleCategoryName">中分類カテゴリー名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCategoryIdList(ByVal CategoryName As String, ByVal LargeCategoryName As String, ByVal MiddleCategoryName As String) As Generic.List(Of String)
        Dim CategoryIdList As New Generic.List(Of String)
        Dim filter As String = ""

        Try
            filter = "CategoryName = '" & CategoryName & "'"
            If LargeCategoryName <> "" Then
                filter += " AND LargeCategoryName = '" & LargeCategoryName & "'"
            End If
            If MiddleCategoryName <> "" Then
                filter += " AND MiddleCategoryName = '" & MiddleCategoryName & "'"
            End If

            For Each rowData As DataRow In _CategoryTbl.Select(filter)
                CategoryIdList.Add(rowData.Item(ColumnIndex.GroupId))
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return CategoryIdList
    End Function

#End Region

End Class