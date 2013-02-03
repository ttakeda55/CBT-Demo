
''' <summary>
''' 指定テスト定義クラス
''' </summary>
''' <remarks></remarks>
Public Class SpecificDefine

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>指定テストヘッダ格納DataTable</summary>
    Private _SpecificHeaderTbl As DataTable = Nothing
    ''' <summary>指定テスト明細格納Dictionary</summary>
    Private _SpecificDetailTblDic As Generic.Dictionary(Of String, DataTable)
    ''' <summary>実施テスト回数</summary>
    Private _TestCount As String = ""
    ''' <summary>実施テストNo.</summary>
    Private _TestNo As String = ""
    ''' <summary>指定テストヘッダファイル読込フラグ</summary>
    Private _ReadSpecificHeader As Boolean = False
    ''' <summary>指定テスト明細ファイル読込フラグ</summary>
    Private _ReadSpecificDetail As Boolean = False

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 実施テストNo.の取得を行います。
    ''' </summary>
    ''' <returns>実施テストNo.</returns>
    ''' <remarks></remarks>
    Public Property TestNo As String
        Get
            Return _TestNo
        End Get
        Set(ByVal value As String)
            _TestNo = value
        End Set
    End Property

    ''' <summary>
    ''' 実施テスト回数の取得を行います。
    ''' </summary>
    ''' <returns>実施テスト回数</returns>
    ''' <remarks></remarks>
    Public Property TestCount As String
        Get
            Return _TestCount
        End Get
        Set(ByVal value As String)
            _TestCount = value
        End Set
    End Property

#Region "----- 列挙体 -----"
    Public Enum SortOrder As Integer
        CREATE_DATE = 0
        TESTNAME_AND_RESULT
    End Enum
#End Region

    ''' <summary>
    ''' 指定テストヘッダ格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>指定テストヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SpecificHeaderDataTable As DataTable
        Get
            If IsNothing(_SpecificHeaderTbl) Then
                Return Nothing
            Else
                Return _SpecificHeaderTbl.Copy
            End If
            'Return _SpecificHeaderTbl.Copy
        End Get
    End Property

    ''' <summary>
    ''' 指定テストヘッダファイル読込チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsReadSpecificHeader As Boolean
        Get
            Return _ReadSpecificHeader
        End Get
    End Property

    ''' <summary>
    ''' 指定テスト明細ファイル読込チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsReadSpecificDetail As Boolean
        Get
            Return _ReadSpecificDetail
        End Get
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 指定テスト読込
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadSpecific() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '指定テストヘッダ読込
            errCode = ReadSpecificHeader()
            If errCode = Constant.ResultCode.NormalEnd Then
                '指定テスト明細読込
                errCode = ReadSpecificDetail()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 指定テストヘッダ読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSpecificHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SPECIFICHEADER_FILENAME & "*"
            '指定テストヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SpecificHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _SpecificHeaderTbl = Common.SpecificHeader.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _SpecificHeaderTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.SpecificHeaderFileReadError
                    End If
                    '指定テストヘッダファイル読込設定
                    If errCode = Constant.ResultCode.NormalEnd Then _ReadSpecificHeader = True
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 指定テスト明細読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSpecificDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SPECIFICDETAIL_FILENAME & "*"
            '指定テスト明細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If errCode = Constant.ResultCode.NormalEnd Then
                    _SpecificDetailTblDic = New Generic.Dictionary(Of String, DataTable)
                    For Each fileName In fileNameList
                        Dim wkTbl As New DataTable
                        'DataTable取得
                        wkTbl = Common.SpecificDetail.GetAll(IO.Path.GetFileName(fileName))
                        If wkTbl.Rows.Count < 1 Then
                            errCode = Constant.ResultCode.SpecificDetailFileReadError
                            Exit For
                        Else
                            _SpecificDetailTblDic.Add(wkTbl.Rows(0).Item(Common.SpecificDetail.ColumnIndex.TestNo), wkTbl)
                        End If
                    Next
                    '指定テスト明細ファイル読込設定
                    If errCode = Constant.ResultCode.NormalEnd AndAlso _SpecificDetailTblDic.Count > 0 Then _ReadSpecificDetail = True
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 指定テスト名リスト取得
    ''' </summary>
    ''' <returns>指定テスト名リスト</returns>
    ''' <remarks></remarks>
    Public Function GetSpecificTestNameList(Optional ByVal iSortOrder As Integer = SortOrder.CREATE_DATE) As Generic.List(Of String)
        Dim TestNameList As New Generic.List(Of String)
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing

        Try
            If Not IsNothing(_SpecificHeaderTbl) Then
                filterExpression = "VISIBLE = '1'"
                Select Case iSortOrder
                    Case SortOrder.CREATE_DATE
                        '2012/07/03 NOZAO CHG S
                        'rowDatas = _SpecificHeaderTbl.Select(filterExpression, "CREATE_DATE")
                        rowDatas = _SpecificHeaderTbl.Select(filterExpression, "TESTNAME")
                        '2012/07/03 NOZAO CHG E
                        If Not IsNothing(rowDatas) Then
                            '小テストを追加
                            '2012/07/03 NOZAO CHG S
                            'For Each rowData As DataRow In rowDatas
                            '    TestNameList.Add(rowData.Item(Common.SpecificHeader.ColumnIndex.TestName))
                            'Next
                            For Each rowData As DataRow In rowDatas
                                '指定テスト名追加
                                If CheckSpecificTestResult(rowData) = True Then TestNameList.Add(rowData.Item(Common.SpecificHeader.ColumnIndex.TestName))
                            Next
                            '演習済みの小テストを追加
                            For Each rowData As DataRow In rowDatas
                                '指定テスト名追加
                                If CheckSpecificTestResult(rowData) = False Then TestNameList.Add(rowData.Item(Common.SpecificHeader.ColumnIndex.TestName))
                            Next
                            '2012/07/03 NOZAO CHG S
                        End If
                    Case SortOrder.TESTNAME_AND_RESULT
                        rowDatas = _SpecificHeaderTbl.Select(filterExpression, "TESTNAME")
                        If Not IsNothing(rowDatas) Then
                            '未演習の小テストを追加
                            For Each rowData As DataRow In rowDatas
                                '指定テスト名追加
                                If CheckSpecificTestResult(rowData) = False Then TestNameList.Add(rowData.Item(Common.SpecificHeader.ColumnIndex.TestName))
                            Next
                            '演習済みの小テストを追加
                            For Each rowData As DataRow In rowDatas
                                '指定テスト名追加
                                If CheckSpecificTestResult(rowData) = True Then TestNameList.Add(rowData.Item(Common.SpecificHeader.ColumnIndex.TestName))
                            Next
                        End If
                End Select
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            TestNameList.Clear()
        End Try
        Return TestNameList
    End Function

    ''' <summary>
    ''' 指定テスト問題コード一覧取得
    ''' </summary>
    ''' <param name="TestName">指定テスト名</param>
    ''' <returns>指定テスト問題コード一覧</returns>
    ''' <remarks></remarks>
    Public Function GetSpecificQuestionCodeList(ByVal TestName As String, ByVal dt As DataTable) As Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim QuestionCodeList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim filterExpression As String = ""
        Dim Num As Integer = 0
        Dim rowDatas() As DataRow = Nothing

        Try
            '' 実施テスト回数取得
            '_TestCount = GetTestCount(dt)
            '指定テストNo.取得
            _TestNo = GetSpecificTestNo(TestName)
            ' 実施テスト回数取得
            _TestCount = GetTestCount(dt, _TestNo)

            If TestNo <> "" Then
                filterExpression = "TESTNO ='" & TestNo & "'"
                rowDatas = _SpecificDetailTblDic.Item(_TestNo).Select(filterExpression, "SHOWNO")
                If Not IsNothing(rowDatas) Then
                    For Each rowData As DataRow In rowDatas
                        '問題コード追加
                        Dim QuestionCodeDefine As New QuestionCodeDefine
                        QuestionCodeDefine.QuestionCode = rowData.Item(Common.SpecificDetail.ColumnIndex.QuestionCode)
                        QuestionCodeDefine.MiddleQuestionCode = ""
                        QuestionCodeList.Add(Num, QuestionCodeDefine)
                        Num += 1
                    Next
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            QuestionCodeList.Clear()
        End Try
        Return QuestionCodeList
    End Function

    ''' <summary>
    ''' 指定テストNo.取得
    ''' </summary>
    ''' <param name="TestName">指定テスト名</param>
    ''' <returns>指定テストNo.</returns>
    ''' <remarks></remarks>
    Private Function GetSpecificTestNo(ByVal TestName As String) As String
        Dim TestNo As String = ""
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing

        Try
            filterExpression = "TESTNAME = '" & TestName & "'"
            rowDatas = _SpecificHeaderTbl.Select(filterExpression)
            If Not IsNothing(rowDatas) AndAlso rowDatas.Length = 1 Then
                'テストNo.取得
                TestNo = rowDatas(0).Item(Common.SpecificHeader.ColumnIndex.TestNo)
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            TestNo = ""
        End Try
        Return TestNo
    End Function

    ''' <summary>
    '''  指定テスト実施回数取得
    ''' </summary>
    ''' <returns>指定テスト結果ヘッダDataTable</returns>
    ''' <remarks></remarks>
    Private Function GetTestCount(ByVal dt As DataTable, ByVal TestNo As String) As Integer
        Dim dataRows() As DataRow = Nothing
        Dim filterExpression As String = ""
        Dim TestCount As Integer = 0

        Try
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                filterExpression = "TESTNO = '" & TestNo & "'"

                'For Each rowData As DataRow In dt.Rows
                For Each rowData As DataRow In dt.Select(filterExpression)
                    If TestCount <= rowData.Item("TESTCOUNT") Then
                        TestCount = rowData.Item("TESTCOUNT")
                    End If
                Next
            End If
            TestCount += 1
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            TestCount = 0
        End Try
        Return TestCount
    End Function

    ''' <summary>
    ''' 分野カテゴリーIDの取得
    ''' </summary>
    ''' <param name="TestNo">指定テストNo.</param>
    ''' <returns>分野カテゴリーID</returns>
    ''' <remarks></remarks>
    Public Function GetCategoryID(ByVal TestNo As String) As String
        Dim CategoryID As String = ""
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing

        Try
            filterExpression = "TESTNO = '" & TestNo & "'"
            rowDatas = _SpecificHeaderTbl.Select(filterExpression)
            If Not IsNothing(rowDatas) AndAlso rowDatas.Length = 1 Then
                '分野カテゴリーID取得
                CategoryID = rowDatas(0).Item(Common.SpecificHeader.ColumnIndex.CategoryId)
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            TestNo = ""
        End Try
        Return CategoryID
    End Function

    ''' <summary>
    ''' 大分類カテゴリーIDの取得
    ''' </summary>
    ''' <param name="TestNo">指定テストNo.</param>
    ''' <returns>大分類カテゴリーID</returns>
    ''' <remarks></remarks>
    Public Function GetLargeCategoryId(ByVal TestNo As String) As String
        Dim LargeCategoryId As String = ""
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing

        Try
            filterExpression = "TESTNO = '" & TestNo & "'"
            rowDatas = _SpecificHeaderTbl.Select(filterExpression)
            If Not IsNothing(rowDatas) AndAlso rowDatas.Length = 1 Then
                '分野カテゴリーID取得
                LargeCategoryId = rowDatas(0).Item(Common.SpecificHeader.ColumnIndex.LargeCategoryId)
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            TestNo = ""
        End Try
        Return LargeCategoryId
    End Function

    ''' <summary>
    ''' 中分類カテゴリーIDの取得
    ''' </summary>
    ''' <param name="TestNo">指定テストNo.</param>
    ''' <returns>中分類カテゴリーID</returns>
    ''' <remarks></remarks>
    Public Function GetMiddleCategoryId(ByVal TestNo As String) As String
        Dim MiddleCategoryId As String = ""
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing

        Try
            filterExpression = "TESTNO = '" & TestNo & "'"
            rowDatas = _SpecificHeaderTbl.Select(filterExpression)
            If Not IsNothing(rowDatas) AndAlso rowDatas.Length = 1 Then
                '分野カテゴリーID取得
                MiddleCategoryId = rowDatas(0).Item(Common.SpecificHeader.ColumnIndex.MiddleCategoryId)
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            TestNo = ""
        End Try
        Return MiddleCategoryId
    End Function

    '2012/06/12 CST ADD S
    ''' <summary>
    ''' 指定の小テストが実施済みかチェックを行う。
    ''' </summary>
    ''' <param name="rowData"></param>
    ''' <returns>
    ''' TRUE：実施済み
    ''' FALSE：未実施
    ''' </returns>
    ''' <remarks></remarks>
    Private Function CheckSpecificTestResult(ByRef rowData As DataRow) As Boolean
        Dim bReturn As Boolean = False

        If Not IsNothing(DataManager.GetInstance.MiniResultDefine.MiniResultHeaderDataTable) Then
            For Each drMiniResultHeader As DataRow In DataManager.GetInstance.MiniResultDefine.MiniResultHeaderDataTable.Rows
                If rowData.Item(Common.SpecificHeader.ColumnIndex.TestNo) = drMiniResultHeader.Item(Common.MiniResultHeader.ColumnIndex.TestNo) Then bReturn = True
            Next
        End If

        Return bReturn
    End Function
    '2012/06/12 CST ADD S
#End Region

End Class
