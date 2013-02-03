
''' <summary>
''' 小テスト結果定義クラス
''' </summary>
''' <remarks></remarks>
Public Class MiniResultDefine

#Region "----- 定数 -----"

    ''' <summary>小テスト実施履歴一覧行インデックス</summary>
    Public Enum MinResultHistTblIndex As Integer
        ''' <summary>テスト名</summary>
        TestName = 0
        ''' <summary>テストNo.</summary>
        TestNo
        ''' <summary>実施回数</summary>
        TestCount
        ''' <summary>分野名</summary>
        CategoryName
        ''' <summary>大分類名</summary>
        LargeCategoryName
        ''' <summary>中分類名</summary>
        MiddleCategoryName
        ''' <summary>実施日</summary>
        TestDate
        ''' <summary>テスト時間(分)</summary>
        TestTime
        ''' <summary>正解数</summary>
        CorrectAnswerCount
        ''' <summary>問題数</summary>
        QuestionCount
        ''' <summary>正解率</summary>
        AccuracyRate
        ''' <summary>サイズ</summary>
        Max
    End Enum

    ''' <summary>小テスト問別正誤行インデックス</summary>
    Public Enum MinTrueFalseTblIndex As Integer
        ''' <summary>問題番号</summary>
        QuestionNumber = 0
        ''' <summary>問題テーマ</summary>
        QuestionTheme
        ''' <summary>正解</summary>
        CorrectansAnswer
        ''' <summary>解答</summary>
        Answer
        ''' <summary>正誤</summary>
        Errata
        ''' <summary>問題コード</summary>
        QuestionCode
        ''' <summary>サイズ</summary>
        Max
    End Enum

    ''' <summary>問題種別</summary>
    Public Enum QuestionClass As Integer
        ''' <summary>ランダム</summary>
        Random = 1
        ''' <summary>指定</summary>
        Specific = 2
    End Enum

    ''' <summary>分類区分</summary>
    Public Enum CategoryClass As Integer
        ''' <summary>分類</summary>
        Category = 0
        ''' <summary>大分類</summary>
        LargeCategory
        ''' <summary>中分類</summary>
        MiddleCategory
    End Enum

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>小テスト結果ヘッダ格納DataTable</summary>
    Private _MiniResultHeaderTbl As DataTable = Nothing
    ''' <summary>小テスト結果明細格納DataTable</summary>
    Private _MiniResultDetailTbl As DataTable = Nothing
    ''' <summary>小テスト実施履歴一覧DataTable</summary>
    Private _MinResultHistoryTbl As DataTable = Nothing
    ''' <summary>小テスト問別正誤DataTable</summary>
    Private _MinTrueFalseTbl As DataTable = Nothing
    ''' <summary>種別</summary>
    Private _TestClass As Integer = 0
    ''' <summary>分野カテゴリーID</summary>
    Private _CategoryId As String = ""
    ''' <summary>大分類カテゴリーID</summary>
    Private _LargeCategoryId As String = ""
    ''' <summary>中分類カテゴリーID</summary>
    Private _MiddleCategoryId As String = ""
    ''' <summary>小テスト結果ヘッダバックアップファイル名</summary>
    Private _MiniResultHeaderBackupFileName As String = ""
    ''' <summary>小テスト結果詳細バックアップファイル名</summary>
    Private _MiniResultDetailBackupFileName As String = ""
    ''' <summary>小テスト結果ヘッダファイル名</summary>
    Private _MiniResultHeaderFileName As String = ""
    ''' <summary>小テスト結果詳細ファイル名</summary>
    Private _MiniResultDetailFileName As String = ""
#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 小テスト結果ヘッダ格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>小テスト結果ヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MiniResultHeaderDataTable As DataTable
        Get
            If IsNothing(_MiniResultHeaderTbl) Then
                Return Nothing
            Else
                Return _MiniResultHeaderTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 小テスト結果明細格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>小テスト結果明細格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MiniResultDetailDataTable As DataTable
        Get
            If IsNothing(_MiniResultDetailTbl) Then
                Return Nothing
            Else
                Return _MiniResultDetailTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 種別の取得、設定を行います。
    ''' </summary>
    ''' <value>種別</value>
    ''' <returns>種別</returns>
    ''' <remarks></remarks>
    Public Property TestClass As Integer
        Get
            Return _TestClass
        End Get
        Set(ByVal value As Integer)
            _TestClass = value
        End Set
    End Property

    ''' <summary>
    ''' 分野カテゴリーIDの取得、設定を行います。
    ''' </summary>
    ''' <value>分野カテゴリーID</value>
    ''' <returns>分野カテゴリーID</returns>
    ''' <remarks></remarks>
    Public Property CategoryId As String
        Get
            Return _CategoryId
        End Get
        Set(ByVal value As String)
            _CategoryId = value
        End Set
    End Property

    ''' <summary>
    ''' 大分類カテゴリーIDの取得、設定を行います。
    ''' </summary>
    ''' <value>大分類カテゴリーID</value>
    ''' <returns>大分類カテゴリーID</returns>
    ''' <remarks></remarks>
    Public Property LargeCategoryId As String
        Get
            Return _LargeCategoryId
        End Get
        Set(ByVal value As String)
            _LargeCategoryId = value
        End Set
    End Property

    ''' <summary>
    ''' 中分類カテゴリーIDの取得、設定を行います。
    ''' </summary>
    ''' <value>中分類カテゴリーID</value>
    ''' <returns>中分類カテゴリーID</returns>
    ''' <remarks></remarks>
    Public Property MiddleCategoryId As String
        Get
            Return _MiddleCategoryId
        End Get
        Set(ByVal value As String)
            _MiddleCategoryId = value
        End Set
    End Property

    ''' <summary>
    ''' 小テスト結果ヘッダバックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>小テスト結果ヘッダバックアップファイル名</value>
    ''' <returns>小テスト結果ヘッダバックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property MiniResultHeaderBackupFileName As String
        Get
            Return _MiniResultHeaderBackupFileName
        End Get
        Set(ByVal value As String)
            _MiniResultHeaderBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 小テスト結果詳細バックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>小テスト結果詳細バックアップファイル名</value>
    ''' <returns>小テスト結果詳細バックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property MiniResultDetailBackupFileName As String
        Get
            Return _MiniResultDetailBackupFileName
        End Get
        Set(ByVal value As String)
            _MiniResultDetailBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 小テスト結果ヘッダファイル名の取得・設定
    ''' </summary>
    ''' <value>小テスト結果ヘッダファイル名</value>
    ''' <returns>小テスト結果ヘッダファイル名</returns>
    ''' <remarks></remarks>
    Public Property MiniResultHeaderFileName As String
        Get
            Return _MiniResultHeaderFileName
        End Get
        Set(ByVal value As String)
            _MiniResultHeaderFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 小テスト結果詳細ファイル名の取得・設定
    ''' </summary>
    ''' <value>小テスト結果詳細ファイル名</value>
    ''' <returns>小テスト結果詳細ファイル名</returns>
    ''' <remarks></remarks>
    Public Property MiniResultDetailFileName As String
        Get
            Return _MiniResultDetailFileName
        End Get
        Set(ByVal value As String)
            _MiniResultDetailFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 小テスト実施履歴一覧DataTableの取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MinResultHistoryDataTable As DataTable
        Get
            If IsNothing(_MinResultHistoryTbl) Then
                Return Nothing
            Else
                Return _MinResultHistoryTbl.Copy
            End If
        End Get
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 小テスト結果読込
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadMiniResult() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '小テスト結果ヘッダ読込           
            errCode = ReadMiniResultHeader()
            If errCode = Constant.ResultCode.NormalEnd Then
                '小テスト結果明細読込
                errCode = ReadMiniResultDetail()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 小テスト結果ヘッダ読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadMiniResultHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_MINIRESULTHEADER_FILENAME & "*"
            '小テスト結果ヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.MiniResultHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _MiniResultHeaderTbl = Common.MiniResultHeader.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _MiniResultHeaderTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.MiniResultHeaderFileReadError
                    End If
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
    ''' 小テスト結果明細読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadMiniResultDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_MINIRESULTDETAIL_FILENAME & "*"
            '小テスト結果明細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.MiniResultDetailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _MiniResultDetailTbl = Common.MiniResultDetail.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _MiniResultDetailTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.MiniResultDetailFileReadError
                    End If
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
    ''' 小テスト実施履歴取得
    ''' </summary>
    ''' <param name="dtCategory">カテゴリーDataTable</param>
    ''' <param name="dtSpecificHeader">指定テストヘッダDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMiniResultHistory(ByVal dtCategory As DataTable, ByVal dtSpecificHeader As DataTable) As Boolean
        Dim blnRet As Boolean = False

        Try
            '小テスト実施履歴DataTable作成
            blnRet = CreateMiniResultHistoryDataTable()
            '小テスト実施履歴データ取得
            If blnRet Then blnRet = GetMiniResultHistoryDataTable(dtCategory, dtSpecificHeader)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 小テスト実施履歴DataTable作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateMiniResultHistoryDataTable() As Boolean
        Dim blnRet As Boolean = True

        Try
            'インスタンス生成
            _MinResultHistoryTbl = New DataTable

            'フィールド追加
            With _MinResultHistoryTbl.Columns
                'テスト名
                .Add("TestName", GetType(String))
                'テストNo.
                .Add("TestNo", GetType(String))
                '実施回数
                .Add("TestCount", GetType(String))
                '分野名
                .Add("CategoryName", GetType(String))
                '大分類名
                .Add("LargeCategoryName", GetType(String))
                '中分類名
                .Add("MiddleCategoryName", GetType(String))
                '実施日
                .Add("TestDate", GetType(String))
                'テスト時間
                .Add("TestTime", GetType(String))
                '正解数
                .Add("CorrectAnswerCount", GetType(String))
                '問題数
                .Add("QuestionCount", GetType(String))
                '正解率
                .Add("AccuracyRate", GetType(String))
            End With

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 小テスト実施履歴データ取得
    ''' </summary>
    ''' <param name="dtCategory">カテゴリーDataTable</param>
    ''' <param name="dtSpecificHeader">指定テストヘッダDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMiniResultHistoryDataTable(ByVal dtCategory As DataTable, ByVal dtSpecificHeader As DataTable) As Boolean
        Dim blnRet As Boolean = True
        Dim filter As String = ""
        Dim QuestionCount As Integer = 0
        Dim CorrectAnswerCount As Integer = 0
        Dim AccuracyRate As String = "0.0"

        Try
            If Not IsNothing(_MiniResultHeaderTbl) AndAlso Not IsNothing(_MiniResultDetailTbl) Then
                For Each rowData As DataRow In _MiniResultHeaderTbl.Rows
                    '初期化
                    QuestionCount = 0
                    CorrectAnswerCount = 0
                    AccuracyRate = "0.0"
                    Dim newData As DataRow = _MinResultHistoryTbl.NewRow
                    With newData
                        'テスト名
                        If rowData.Item(Common.MiniResultHeader.ColumnIndex.TestNo) <> "" Then
                            '指定テスト
                            .Item(MinResultHistTblIndex.TestName) = "指定テスト" & vbCrLf & GetSpecificTestName(rowData.Item(Common.MiniResultHeader.ColumnIndex.TestNo), dtSpecificHeader)
                        Else
                            'ランダムテスト
                            .Item(MinResultHistTblIndex.TestName) = "ランダムテスト"
                        End If
                        'テストNo.
                        .Item(MinResultHistTblIndex.TestNo) = rowData.Item(Common.MiniResultHeader.ColumnIndex.TestNo)
                        '実施回数
                        .Item(MinResultHistTblIndex.TestCount) = rowData.Item(Common.MiniResultHeader.ColumnIndex.TestCount)
                        '分野名
                        .Item(MinResultHistTblIndex.CategoryName) = GetCategoryName(rowData.Item(Common.MiniResultHeader.ColumnIndex.CategoryId), dtCategory, CategoryClass.Category)
                        '大分類名
                        .Item(MinResultHistTblIndex.LargeCategoryName) = GetCategoryName(rowData.Item(Common.MiniResultHeader.ColumnIndex.LargeCategoryId), dtCategory, CategoryClass.LargeCategory)
                        '中分類名
                        .Item(MinResultHistTblIndex.MiddleCategoryName) = GetCategoryName(rowData.Item(Common.MiniResultHeader.ColumnIndex.MiddleCategoryId), dtCategory, CategoryClass.MiddleCategory)
                        '実施日
                        .Item(MinResultHistTblIndex.TestDate) = rowData.Item(Common.MiniResultHeader.ColumnIndex.TestDate)
                        'テスト時間
                        Dim wkBuff() As String = rowData.Item(Common.MiniResultHeader.ColumnIndex.TestTime).ToString.Split(":")
                        .Item(MinResultHistTblIndex.TestTime) = CInt((Integer.Parse(wkBuff(0)) * 60) + Integer.Parse(wkBuff(1)))
                        '問題数、正解数取得
                        'filter = "TESTCOUNT = '" & rowData.Item(Common.MiniResultHeader.ColumnIndex.TestCount) & "'"
                        filter = "TESTCOUNT = '" & rowData.Item(Common.MiniResultHeader.ColumnIndex.TestCount) & "' AND TESTNO = '" & rowData.Item(Common.MiniResultHeader.ColumnIndex.TestNo) & "'"
                        For Each rowData2 As DataRow In _MiniResultDetailTbl.Select(filter)
                            '問題数カウントアップ
                            QuestionCount += 1
                            If rowData2.Item(Common.MiniResultDetail.ColumnIndex.ErrAta) = "1" Then
                                '正解数
                                CorrectAnswerCount += 1
                            End If
                        Next
                        '問題数
                        .Item(MinResultHistTblIndex.QuestionCount) = QuestionCount
                        '正解数
                        .Item(MinResultHistTblIndex.CorrectAnswerCount) = CorrectAnswerCount
                        '正解率
                        If QuestionCount > 0 Then
                            AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                        End If
                        .Item(MinResultHistTblIndex.AccuracyRate) = AccuracyRate
                    End With
                    '追加
                    _MinResultHistoryTbl.Rows.Add(newData)
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 指定テスト名取得
    ''' </summary>
    ''' <param name="TestNo">テストNo.</param>
    ''' <param name="dt">指定テストヘッダDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSpecificTestName(ByVal TestNo As String, ByVal dt As DataTable) As String
        Dim retStr As String = ""
        Dim Filter As String = ""

        Try
            Filter = "TESTNO = '" & TestNo & "' AND VISIBLE = '1'"
            For Each rowData As DataRow In dt.Select(Filter)
                retStr = rowData.Item(Common.SpecificHeader.ColumnIndex.TestName)
                Exit For
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            retStr = ""
        End Try
        Return retStr
    End Function

    ''' <summary>
    ''' カテゴリー名取得
    ''' </summary>
    ''' <param name="Id">カテゴリー表示ID</param>
    ''' <param name="dt">カテゴリーDataTable</param>
    ''' <param name="CategoryClass">分類区分</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCategoryName(ByVal Id As String, ByVal dt As DataTable, ByVal CategoryClass As CategoryClass) As String
        Dim retStr = "すべて"
        Dim Filter As String = ""

        Try
            Select Case CategoryClass
                Case MiniResultDefine.CategoryClass.Category
                    Filter = "DisplyId = '" & Id & "'"
                Case MiniResultDefine.CategoryClass.LargeCategory
                    Filter = "LargeDisplyId = '" & Id & "'"
                Case MiniResultDefine.CategoryClass.MiddleCategory
                    Filter = "MiddleDisplyId = '" & Id & "'"
            End Select


            For Each rowData As DataRow In dt.Select(Filter)
                Select Case CategoryClass
                    Case MiniResultDefine.CategoryClass.Category
                        retStr = rowData.Item(CategoryDefine.ColumnIndex.CategoryName)
                    Case MiniResultDefine.CategoryClass.LargeCategory
                        retStr = rowData.Item(CategoryDefine.ColumnIndex.LargeCategoryName)
                    Case MiniResultDefine.CategoryClass.MiddleCategory
                        retStr = rowData.Item(CategoryDefine.ColumnIndex.MiddleCategoryName)
                End Select

                Exit For
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            retStr = ""
        End Try
        Return retStr
    End Function

    ''' <summary>
    '''  小テスト結果ヘッダオブジェクトを追加します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AddMiniResultHeader(ByVal NowTime As Date, ByVal TestTime As String, ByVal TestNo As String, ByVal TestCount As String, ByVal QuestionCodeList As Dictionary(Of Integer, QuestionCodeDefine), ByVal UserId As String) As Boolean
        Dim ret As Boolean = True
        Dim Datas(Common.MiniResultHeader.ColumnIndex.Max - 1) As String
        Try
            ' DataRowの削除
            If Not DataManager.GetInstance.MiniResultDefine.DeleteHeaderDataRow(TestNo, TestCount) Then
                Return False
            End If
            ' ユーザID
            Datas(Common.MiniResultHeader.ColumnIndex.UserId) = UserId
            ' テスト№
            Datas(Common.MiniResultHeader.ColumnIndex.TestNo) = TestNo
            ' 実施回数
            Datas(Common.MiniResultHeader.ColumnIndex.TestCount) = TestCount
            ' 種別
            Datas(Common.MiniResultHeader.ColumnIndex.QuestionClass) = _TestClass
            ' 分野カテゴリーID
            Datas(Common.MiniResultHeader.ColumnIndex.CategoryId) = _CategoryId
            ' 大分類カテゴリーID
            Datas(Common.MiniResultHeader.ColumnIndex.LargeCategoryId) = _LargeCategoryId
            ' 中分類カテゴリーID
            Datas(Common.MiniResultHeader.ColumnIndex.MiddleCategoryId) = _MiddleCategoryId
            ' 実施日
            Datas(Common.MiniResultHeader.ColumnIndex.TestDate) = NowTime.ToString("yyyy/MM/dd")
            ' 実施時間
            Datas(Common.MiniResultHeader.ColumnIndex.TestTime) = TestTime
            ' 問題数
            Datas(Common.MiniResultHeader.ColumnIndex.Count) = QuestionCodeList.Count
            ' 作成日
            Datas(Common.MiniResultHeader.ColumnIndex.CreateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")
            ' 更新日
            Datas(Common.MiniResultHeader.ColumnIndex.UpdateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")

            ' 小テスト結果ヘッダオブジェクト追加
            If Not DataManager.GetInstance.MiniResultDefine.AddHeaderDataRow(Datas) Then
                '追加エラー
                Dim errCode As String = "E" & Constant.ResultCode.AddMiniResultHeader
                Common.Message.MessageShow(errCode)
                ret = False
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            ret = False
        End Try
        Return ret
    End Function

    ''' <summary>
    '''  小テスト結果明細オブジェクトを追加します。
    ''' </summary>
    ''' <param name="NowTime">現在日時</param>
    ''' <param name="TestCount">テスト実施回数</param>
    ''' <param name="QuestionCodeList">問題コードリスト</param>
    ''' <param name="ResultDataContainer">解答データコンテナオブジェクト</param>
    ''' <param name="questionDefineContainer">問題定義コンテナオブジェクト</param>
    ''' <param name="UserId">ユーザーID</param>
    ''' <remarks></remarks>
    Public Function AddMiniResultDetail(ByVal NowTime As Date, ByVal TestCount As String, ByVal TestNo As String, ByVal QuestionCodeList As Dictionary(Of Integer, QuestionCodeDefine), ByVal ResultDataContainer As ResultDataContainer, ByVal questionDefineContainer As QuestionDefineContainer, ByVal UserId As String, ByVal dtPractice As DataTable) As Boolean
        Dim ret As Boolean = True
        Dim Datas(Common.MiniResultDetail.ColumnIndex.Max - 1) As String
        Try
            ' DataRowの削除
            If Not DataManager.GetInstance.MiniResultDefine.DeleteDetailDataRow(TestCount, TestNo) Then
                Return False
            End If

            For Each key As Integer In QuestionCodeList.Keys
                ' ユーザID
                Datas(Common.MiniResultDetail.ColumnIndex.UserId) = UserId
                ' テスト№
                Datas(Common.MiniResultDetail.ColumnIndex.TestNo) = TestNo
                ' 実施回数
                Datas(Common.MiniResultDetail.ColumnIndex.TestCount) = TestCount
                ' 表示順
                Datas(Common.MiniResultDetail.ColumnIndex.ShowNo) = key + 1
                ' 問題コード
                Datas(Common.MiniResultDetail.ColumnIndex.QuestionCode) = QuestionCodeList.Item(key).QuestionCode
                ' 主文問題コード
                Datas(Common.MiniResultDetail.ColumnIndex.MainCode) = QuestionCodeList.Item(key).MiddleQuestionCode
                ' 正解
                Dim filter As String = "QUESTIONCODE = '" & QuestionCodeList.Item(key).QuestionCode & "'"
                Dim dataRow() As DataRow = dtPractice.Select(filter)
                Datas(Common.MiniResultDetail.ColumnIndex.CorrectAnswer) = dataRow(0).Item(Common.PracticeQuestionList.ColumnIndex.CorrectAnswer)
                ' 解答
                Dim answer As String = ""
                If Not IsNothing(ResultDataContainer.Item(QuestionCodeList.Item(key).QuestionCode)) Then
                    answer = ResultDataContainer.Item(QuestionCodeList.Item(key).QuestionCode).Answer
                End If
                Datas(Common.MiniResultDetail.ColumnIndex.Answer) = answer
                ' 正誤
                Datas(Common.MiniResultDetail.ColumnIndex.ErrAta) = _
                    IIf(Datas(Common.MiniResultDetail.ColumnIndex.CorrectAnswer) <> Datas(Common.MiniResultDetail.ColumnIndex.Answer), "0", "1")
                ' 作成日
                Datas(Common.MiniResultDetail.ColumnIndex.CreateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")
                ' 更新日
                Datas(Common.MiniResultDetail.ColumnIndex.UpdateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")

                ' 小テスト結果明細オブジェクト追加
                If Not DataManager.GetInstance.MiniResultDefine.AddDetailDataRow(Datas) Then
                    '追加エラー
                    Dim errCode As String = "E" & Constant.ResultCode.AddMiniResultDetail
                    Common.Message.MessageShow(errCode)
                    ret = False
                    Exit For
                End If
            Next

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            ret = False
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' 小テスト結果ヘッダデータ追加
    ''' </summary>
    ''' <param name="datas">追加データ配列</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Private Function AddHeaderDataRow(ByVal datas() As String) As Boolean
        Dim blnRet As Boolean = False
        Dim dataRow As DataRow = Nothing
        Dim i As Integer = 0

        Try
            'DataTableの存在チェック
            If IsNothing(_MiniResultHeaderTbl) Then
                _MiniResultHeaderTbl = New DataTable
                Common.XmlSchema.GetMiniResultHeaderSchema(_MiniResultHeaderTbl)
            End If

            'カラム数と追加するデータ数が一致するかチェック
            If _MiniResultHeaderTbl.Columns.Count = datas.Length Then
                dataRow = _MiniResultHeaderTbl.NewRow
                For i = 0 To datas.Length - 1
                    dataRow(i) = datas(i)
                Next
                '追加
                Call _MiniResultHeaderTbl.Rows.Add(dataRow)
                blnRet = True
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 小テスト結果明細データ追加
    ''' </summary>
    ''' <param name="datas">追加データ配列</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Private Function AddDetailDataRow(ByVal datas() As String) As Boolean
        Dim blnRet As Boolean = False
        Dim dataRow As DataRow = Nothing
        Dim i As Integer = 0

        Try
            'DataTableの存在チェック
            If IsNothing(_MiniResultDetailTbl) Then
                _MiniResultDetailTbl = New DataTable
                Common.XmlSchema.GetMiniResultDetailSchema(_MiniResultDetailTbl)
            End If

            'カラム数と追加するデータ数が一致するかチェック
            If _MiniResultDetailTbl.Columns.Count = datas.Length Then
                dataRow = _MiniResultDetailTbl.NewRow
                For i = 0 To datas.Length - 1
                    dataRow(i) = datas(i)
                Next
                '追加
                Call _MiniResultDetailTbl.Rows.Add(dataRow)
                blnRet = True
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    '''  小テスト結果ヘッダデータ削除
    ''' </summary>
    ''' <param name="TestNo">実施テストNo.</param>
    ''' <param name="TestCount">実施テスト回数</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    ''' <remarks></remarks>
    Private Function DeleteHeaderDataRow(ByVal TestNo As String, ByVal TestCount As String) As Boolean
        Dim ret As Boolean = True
        Try
            If Not IsNothing(_MiniResultHeaderTbl) Then
                Dim Filter As String = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                For Each DataRow As DataRow In _MiniResultHeaderTbl.Select(Filter)
                    _MiniResultHeaderTbl.Rows.Remove(DataRow)
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            ret = False
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return ret
    End Function

    ''' <summary>
    '''  小テスト結果明細データ削除
    ''' </summary>
    ''' <param name="TestCount">実施テスト回数</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    ''' <remarks></remarks>
    Private Function DeleteDetailDataRow(ByVal TestCount As String, ByVal TestNo As String) As Boolean
        Dim ret As Boolean = True
        Try
            If Not IsNothing(_MiniResultDetailTbl) Then
                Dim Filter As String = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                For Each DataRow As DataRow In _MiniResultDetailTbl.Select(Filter)
                    _MiniResultDetailTbl.Rows.Remove(DataRow)
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            ret = False
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return ret
    End Function

    ''' <summary>
    '''  小テスト結果ヘッダデータ取得
    ''' </summary>
    ''' <param name="TestTime">日付</param>
    ''' <returns>小テスト結果ヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetHeaderDataTable(ByVal TestTime As Date) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim filter As String = "CREATE_DATE >= '" & TestTime.ToString("yyyy/MM/dd 00:00:00") & "'"
            dt = _MiniResultHeaderTbl.Select(filter).CopyToDataTable
            dt.TableName = _MiniResultHeaderTbl.TableName
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    '''  小テスト結果ヘッダデータ行取得
    ''' </summary>
    ''' <param name="testCount">テスト実施回数</param>
    ''' <returns>小テスト結果ヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetHeaderDataRow(ByVal testCount As String) As DataRow
        Dim dataRow As DataRow = Nothing
        Try
            Dim filter As String = "TESTCOUNT >= '" & testCount & "'"
            dataRow = _MiniResultHeaderTbl.Select(filter).CopyToDataTable.Rows(0)
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dataRow
    End Function

    ''' <summary>
    '''  小テスト結果明細データ取得
    ''' </summary>
    ''' <param name="TestTime">日付</param>
    ''' <returns>小テスト結果明細格納DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetDetailDataTable(ByVal TestTime As Date) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim filter As String = "CREATE_DATE >= '" & TestTime.ToString("yyyy/MM/dd 00:00:00") & "'"
            dt = _MiniResultDetailTbl.Select(filter).CopyToDataTable
            dt.TableName = _MiniResultDetailTbl.TableName
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    '''  問別正誤データ取得
    ''' </summary>
    ''' <param name="TestCount">テスト実施回数</param>
    ''' <returns>小テスト問別正誤DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetTrueFalseListDataTable(ByVal TestCount As String, ByVal TestNo As String, ByVal dtPractice As DataTable) As DataTable
        Dim ret As Boolean = True
        Dim ds As New DataSet
        Dim dt As DataTable = Nothing
        Dim dataRow As DataRow = Nothing
        Dim QuestionNumber As Integer = 1
        Try
            ' 問別正誤テーブル作成
            ret = CreateTrueFalseListDataTable()

            If Not IsNothing(_MiniResultDetailTbl) Then
                ds.Tables.Add(_MiniResultDetailTbl.Copy)
                ds.Tables.Add(dtPractice.Copy)
                Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.MiniResultDetail.ColumnIndex.QuestionCode), ds.Tables(1).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), False)

                'Dim Filter As String = "TESTCOUNT = '" & TestCount & "'"
                Dim Filter As String = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(Filter)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        ' データセット
                        dataRow = _MinTrueFalseTbl.NewRow
                        dataRow(MinTrueFalseTblIndex.QuestionNumber) = QuestionNumber
                        dataRow(MinTrueFalseTblIndex.QuestionTheme) = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.Theme)
                        dataRow(MinTrueFalseTblIndex.CorrectansAnswer) = rowData1.Item(Common.MiniResultDetail.ColumnIndex.CorrectAnswer)
                        dataRow(MinTrueFalseTblIndex.Answer) = rowData1.Item(Common.MiniResultDetail.ColumnIndex.Answer)
                        dataRow(MinTrueFalseTblIndex.Errata) = rowData1.Item(Common.MiniResultDetail.ColumnIndex.ErrAta)
                        dataRow(MinTrueFalseTblIndex.QuestionCode) = rowData1.Item(Common.MiniResultDetail.ColumnIndex.QuestionCode)
                    Next
                    ' 問別正誤テーブルデータ追加
                    Call _MinTrueFalseTbl.Rows.Add(dataRow)
                    QuestionNumber += 1
                Next
                dt = _MinTrueFalseTbl.Copy
            End If
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' 小テスト問別正誤DataTable作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTrueFalseListDataTable() As Boolean
        Dim ret As Boolean = True
        Try
            'インスタンス生成
            _MinTrueFalseTbl = New DataTable

            'フィールド追加
            With _MinTrueFalseTbl.Columns
                '問番号
                .Add("QuestionNumber", GetType(String))
                '問題テーマ
                .Add("QuestionTheme", GetType(String))
                '正解
                .Add("CorrectansAnswer", GetType(String))
                '解答
                .Add("Answer", GetType(String))
                '正誤
                .Add("Errata", GetType(String))
                '問題コード
                .Add("QuestionCode", GetType(String))
            End With
        Catch ex As Exception
            ret = False
            _Log.Error(ex)
        End Try
        Return ret
    End Function

    ''' <summary>
    '''  小テスト実施結果DataRow作成
    ''' </summary>
    ''' <param name="TestCount">テスト実施回数</param>
    ''' <param name="dtCategory">カテゴリデータテーブル</param>
    ''' <param name="dtSpecificHeader">演習データテーブル</param>
    ''' <returns>小テスト実施結果DataRow</returns>
    ''' <remarks></remarks>
    Public Function CreateResultDataRow(ByVal TestCount As String, ByVal TestNo As String, ByVal dtCategory As DataTable, ByVal dtSpecificHeader As DataTable) As DataRow
        Dim ret As Boolean = True
        Dim rowData() As DataRow = Nothing
        Dim filter As String = ""
        Try

            If Not IsNothing(_MiniResultHeaderTbl) AndAlso Not IsNothing(_MiniResultDetailTbl) Then

                ret = GetMiniResultHistory(dtCategory, dtSpecificHeader)

                If ret Then
                    'filter = "TestCount = '" & TestCount & "'"
                    filter = "TestCount = '" & TestCount & "' AND TestNo = '" & TestNo & "'"
                    rowData = _MinResultHistoryTbl.Select(filter)
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        If rowData.Length = 0 Then
            Return Nothing
        Else
            Return rowData(0)
        End If
    End Function
#End Region

End Class
