
''' <summary>
''' 総合テスト結果定義クラス
''' </summary>
''' <remarks></remarks>
Public Class SynthesisResultDefine

#Region "----- 定数 -----"

    ''' <summary>総合テスト実施履歴一覧行インデックス</summary>
    Public Enum SynthesisResultHistTblIndex As Integer
        ''' <summary>テスト名</summary>
        TestName = 0
        ''' <summary>テストNo.</summary>
        TestNo
        ''' <summary>実施回数</summary>
        TestCount
        ''' <summary>実施日</summary>
        TestDate
        ''' <summary>実施時間(分)</summary>
        TestTime
        ''' <summary>国語正解率</summary>
        AccuracyRate1
        ''' <summary>社会正解率</summary>
        AccuracyRate2
        ''' <summary>数学正解率</summary>
        AccuracyRate3
        ''' <summary>理科正解率</summary>
        AccuracyRate4
        ''' <summary>英語正解率</summary>
        AccuracyRate5
        ''' <summary>総合問題数</summary>
        TotalQuestionCount
        ''' <summary>総合正解数</summary>
        TotalCorrectAnswerCount
        ''' <summary>総合正解率</summary>
        TotalAccuracyRate
    End Enum

    ''' <summary> 大分類別正解率取得行インデックス</summary>
    Public Enum LargeCategoryAccuracyRateTblIndex As Integer
        ''' <summary>分類名</summary>
        CategoryName = 0
        ''' <summary>大分類名</summary>
        LargeCategoryName
        ''' <summary>演習問題数</summary>
        QuestionCount
        ''' <summary>正解数</summary>
        CorrectAnswerCount
        ''' <summary>正解率</summary>
        AccuracyRate
    End Enum

    ''' <summary> 分類別正解率取得行インデックス</summary>
    Public Enum CategoryAccuracyRateTblIndex As Integer
        ''' <summary>分類名</summary>
        CategoryName = 0
        ''' <summary>正解率</summary>
        AccuracyRate
    End Enum

    ''' <summary>総合テスト問別正誤行インデックス</summary>
    Public Enum SynthesisTrueFalseTblIndex As Integer
        ''' <summary>問題コード</summary>
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

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>総合テスト結果ヘッダ格納DataTable</summary>
    Private _SynthesisResultHeaderTbl As DataTable = Nothing
    ''' <summary>総合テスト結果明細格納DataTable</summary>
    Private _SynthesisResultDetailTbl As DataTable = Nothing
    ''' <summary>総合テスト実施履歴一覧DataTable</summary>
    Private _SynthesisResultHistoryTbl As DataTable = Nothing
    ''' <summary>大分類別正解率DataTable</summary>
    Private _LargeCategoryAccuracyRateTbl As DataTable = Nothing
    ''' <summary>総合テスト問別正誤DataTable</summary>
    Private _SynthesisTrueFalseTbl As DataTable = Nothing
    ''' <summary>総合テスト結果ヘッダバックアップファイル名</summary>
    Private _SynthesisResultHeaderBackupFileName As String = ""
    ''' <summary>総合テスト結果詳細バックアップファイル名</summary>
    Private _SynthesisResultDetailBackupFileName As String = ""
    ''' <summary>総合テスト結果ヘッダファイル名</summary>
    Private _SynthesisResultHeaderFileName As String = ""
    ''' <summary>総合テスト結果詳細ファイル名</summary>
    Private _SynthesisResultDetailFileName As String = ""

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 総合テスト結果ヘッダ格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>総合テスト結果ヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisResultHeaderDataTable As DataTable
        Get
            If IsNothing(_SynthesisResultHeaderTbl) Then
                Return Nothing
            Else
                Return _SynthesisResultHeaderTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト結果明細格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>総合テスト結果明細格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisResultDetailDataTable As DataTable
        Get
            If IsNothing(_SynthesisResultDetailTbl) Then
                Return Nothing
            Else
                Return _SynthesisResultDetailTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト実施履歴一覧DataTableの取得
    ''' </summary>
    ''' <returns>総合テスト実施履歴一覧DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisResultHistoryDataTable As DataTable
        Get
            If IsNothing(_SynthesisResultHistoryTbl) Then
                Return Nothing
            Else
                Return _SynthesisResultHistoryTbl
            End If
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト結果ヘッダバックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>総合テスト結果ヘッダバックアップファイル名</value>
    ''' <returns>総合テスト結果ヘッダバックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property SynthesisResultHeaderBackupFileName As String
        Get
            Return _SynthesisResultHeaderBackupFileName
        End Get
        Set(ByVal value As String)
            _SynthesisResultHeaderBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 総合テスト結果詳細バックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>総合テスト結果詳細バックアップファイル名</value>
    ''' <returns>総合テスト結果詳細バックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property SynthesisResultDetailBackupFileName As String
        Get
            Return _SynthesisResultDetailBackupFileName
        End Get
        Set(ByVal value As String)
            _SynthesisResultDetailBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 総合テスト結果ヘッダファイル名の取得・設定
    ''' </summary>
    ''' <value>総合テスト結果ヘッダファイル名</value>
    ''' <returns>総合テスト結果ヘッダファイル名</returns>
    ''' <remarks></remarks>
    Public Property SynthesisResultHeaderFileName As String
        Get
            Return _SynthesisResultHeaderFileName
        End Get
        Set(ByVal value As String)
            _SynthesisResultHeaderFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 総合テスト結果詳細ファイル名の取得・設定
    ''' </summary>
    ''' <value>総合テスト結果詳細ファイル名</value>
    ''' <returns>総合テスト結果詳細ファイル名</returns>
    ''' <remarks></remarks>
    Public Property SynthesisResultDetailFileName As String
        Get
            Return _SynthesisResultDetailFileName
        End Get
        Set(ByVal value As String)
            _SynthesisResultDetailFileName = value
        End Set
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 総合テスト結果読込
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadSynthesisResult() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '総合テスト結果ヘッダ読込
            errCode = ReadSynthesisResultHeader()
            If errCode = Constant.ResultCode.NormalEnd Then
                '総合テスト結果明細読込
                errCode = ReadSynthesisResultDetail()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 総合テスト結果ヘッダ読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSynthesisResultHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & Common.Constant.CST_GROUPNAME & DataManager.GetInstance.UserId & "*"
            '総合テスト結果ヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SynthesisResultHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _SynthesisResultHeaderTbl = Common.SynthesisResultHeader.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _SynthesisResultHeaderTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.SynthesisResultHeaderFileReadError
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
    ''' 総合テスト結果明細読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSynthesisResultDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & Common.Constant.CST_GROUPNAME & DataManager.GetInstance.UserId & "*"
            '総合テスト結果明細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SynthesisResultDetailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _SynthesisResultDetailTbl = Common.SynthesisResultDetail.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _SynthesisResultDetailTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.SynthesisResultDetailFileReadError
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
    ''' 総合テスト実施履歴取得
    ''' </summary>
    ''' <param name="dtCategory">カテゴリーDataTable</param>
    ''' <param name="dtQuestionList">問題一覧DataTable</param>
    ''' <param name="dtSynthesisHeader">総合テストヘッダDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSynthesisResultHistory(ByVal dtCategory As DataTable, ByVal dtQuestionList As DataTable, ByVal dtSynthesisHeader As DataTable) As Boolean
        Dim blnRet As Boolean = False

        Try
            '総合テスト実施履歴一覧DataTable作成
            blnRet = CreateSynthesisResultHistoryDataTable()
            '総合テスト実施履歴一覧データ取得
            If blnRet Then blnRet = GetSynthesisResultHistoryDataTable(dtCategory, dtQuestionList, dtSynthesisHeader)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 総合テスト実施履歴DataTable作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateSynthesisResultHistoryDataTable() As Boolean
        Dim blnRet As Boolean = True

        Try
            'インスタンス生成
            _SynthesisResultHistoryTbl = New DataTable

            'フィールド追加
            With _SynthesisResultHistoryTbl.Columns
                'テスト名
                .Add("TestName", GetType(String))
                'テストNo.
                .Add("TestNo", GetType(String))
                '実施回数
                .Add("TestCount", GetType(String))
                '実施日
                .Add("TestDate", GetType(String))
                '実施時間(分)
                .Add("TestTime", GetType(String))
                '国語正解率
                .Add("AccuracyRate1", GetType(String))
                '社会正解率
                .Add("AccuracyRate2", GetType(String))
                '数学正解率
                .Add("AccuracyRate3", GetType(String))
                '理科正解率
                .Add("AccuracyRate4", GetType(String))
                '英語正解率
                .Add("AccuracyRate5", GetType(String))
                '総合問題数
                .Add("TotalQuestionCount", GetType(String))
                '総合正解数
                .Add("TotalCorrectAnswerCount", GetType(String))
                '総合正解率
                .Add("TotalAccuracyRate", GetType(String))
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
    ''' 総合テスト実施履歴一覧データ取得
    ''' </summary>
    ''' <param name="dtCategory">カテゴリーDataTable</param>
    ''' <param name="dtQuestionList">問題一覧DataTable</param>
    ''' <param name="dtSynthesisHeader">総合テストヘッダDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSynthesisResultHistoryDataTable(ByVal dtCategory As DataTable, ByVal dtQuestionList As DataTable, ByVal dtSynthesisHeader As DataTable) As Boolean
        Dim blnRet As Boolean = False
        Dim ds As New DataSet
        Dim GroupIdList As List(Of String) = Nothing
        Dim TestCount As String = ""
        Dim TestNo As String = ""
        Dim QuestionCount As Integer = 0
        Dim CorrectAnswerCount As Integer = 0
        Dim AccuracyRate As String = "0.0"
        Dim TotalQuestionCount As Integer = 0
        Dim TotalCorrectAnswerCount As Integer = 0
        Dim TotalAccuracyRate As String = "0.0"
        Dim Filter As String = ""
        Dim Filter2 As String = ""
        Try
            If Not IsNothing(_SynthesisResultHeaderTbl) AndAlso Not IsNothing(_SynthesisResultDetailTbl) Then
                For Each rowData As DataRow In _SynthesisResultHeaderTbl.Rows
                    '初期化
                    TotalQuestionCount = 0
                    TotalCorrectAnswerCount = 0
                    TotalAccuracyRate = "0.0"
                    Dim newData As DataRow = _SynthesisResultHistoryTbl.NewRow
                    With newData
                        'テストNo.
                        TestNo = rowData.Item(Common.SynthesisResultHeader.ColumnIndex.TestNo)
                        .Item(SynthesisResultHistTblIndex.TestNo) = TestNo
                        'テスト名
                        .Item(SynthesisResultHistTblIndex.TestName) = GetSynthesisTestName(.Item(SynthesisResultHistTblIndex.TestNo), dtSynthesisHeader)
                        '実施回数
                        TestCount = rowData.Item(Common.SynthesisResultHeader.ColumnIndex.TestCount)
                        .Item(SynthesisResultHistTblIndex.TestCount) = TestCount
                        '実施日
                        .Item(SynthesisResultHistTblIndex.TestDate) = rowData.Item(Common.SynthesisResultHeader.ColumnIndex.TestDate)
                        '実施時間
                        Dim wkBuff() As String = rowData.Item(Common.SynthesisResultHeader.ColumnIndex.TestTime).ToString.Split(":")
                        .Item(SynthesisResultHistTblIndex.TestTime) = CInt((Integer.Parse(wkBuff(0)) * 60) + Integer.Parse(wkBuff(1)))
                        ' カテゴリーIDリスト取得
                        Dim CategoryList As List(Of String) = GetCategoryList(dtCategory)

                        For i As Integer = 0 To CategoryList.Count - 1
                            '初期化
                            QuestionCount = 0
                            CorrectAnswerCount = 0
                            AccuracyRate = "0.0"
                            'グループID取得
                            blnRet = GetGroupList(CategoryList(i), dtCategory, GroupIdList)
                            For Each GroupId As String In GroupIdList
                                'Filter = "CATEGORYID = '" & GroupId & "' AND STATE = '0'"
                                Filter = "CATEGORYID = '" & GroupId & "'"
                                For Each rowData2 As DataRow In dtQuestionList.Select(Filter)
                                    'Filter2 = "TESTCOUNT = '" & TestCount & "' AND QUESTIONCODE = '" & rowData2.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "'"
                                    Filter2 = "TESTCOUNT = '" & TestCount & "' AND QUESTIONCODE = '" & rowData2.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "' AND TESTNO = '" & TestNo & "'"
                                    For Each rowData3 As DataRow In _SynthesisResultDetailTbl.Select(Filter2)
                                        '問題数
                                        QuestionCount += 1
                                        If rowData3.Item(Common.SynthesisResultDetail.ColumnIndex.ErrAta) = "1" Then
                                            '正解数
                                            CorrectAnswerCount += 1
                                        End If
                                    Next
                                Next
                            Next

                            Select Case i
                                Case 0  'ストラジ系正解率
                                    TotalQuestionCount += QuestionCount
                                    TotalCorrectAnswerCount += CorrectAnswerCount
                                    If QuestionCount > 0 Then
                                        AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                                    End If
                                    .Item(SynthesisResultHistTblIndex.AccuracyRate1) = AccuracyRate
                                Case 1  'マネジメント系正解率
                                    TotalQuestionCount += QuestionCount
                                    TotalCorrectAnswerCount += CorrectAnswerCount
                                    If QuestionCount > 0 Then
                                        AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                                    End If
                                    .Item(SynthesisResultHistTblIndex.AccuracyRate2) = AccuracyRate
                                Case 2  'テクノロジ系正解率
                                    TotalQuestionCount += QuestionCount
                                    TotalCorrectAnswerCount += CorrectAnswerCount
                                    If QuestionCount > 0 Then
                                        AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                                    End If
                                    .Item(SynthesisResultHistTblIndex.AccuracyRate3) = AccuracyRate
                                Case 3  'テクノロジ系正解率
                                    TotalQuestionCount += QuestionCount
                                    TotalCorrectAnswerCount += CorrectAnswerCount
                                    If QuestionCount > 0 Then
                                        AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                                    End If
                                    .Item(SynthesisResultHistTblIndex.AccuracyRate4) = AccuracyRate
                                Case 4  'テクノロジ系正解率
                                    TotalQuestionCount += QuestionCount
                                    TotalCorrectAnswerCount += CorrectAnswerCount
                                    If QuestionCount > 0 Then
                                        AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                                    End If
                                    .Item(SynthesisResultHistTblIndex.AccuracyRate5) = AccuracyRate
                            End Select
                        Next
                        '総合問題数
                        .Item(SynthesisResultHistTblIndex.TotalQuestionCount) = TotalQuestionCount
                        '総合正解数
                        .Item(SynthesisResultHistTblIndex.TotalCorrectAnswerCount) = TotalCorrectAnswerCount
                        '総合正解率
                        If TotalQuestionCount > 0 Then
                            TotalAccuracyRate = (Math.Floor((TotalCorrectAnswerCount / TotalQuestionCount) * 1000) / 10).ToString("0.0")
                        End If
                        .Item(SynthesisResultHistTblIndex.TotalAccuracyRate) = TotalAccuracyRate
                    End With
                    '追加
                    _SynthesisResultHistoryTbl.Rows.Add(newData)
                Next
            End If
            blnRet = True
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' グループIDリスト取得
    ''' </summary>
    ''' <param name="CategoryId">分野カテゴリーID</param>
    ''' <param name="dt">カテゴリーDataTable</param>
    ''' <param name="GroupList">グループIDリスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetGroupList(ByVal CategoryId As String, ByVal dt As DataTable, ByRef GroupList As List(Of String)) As Boolean
        Dim blnRet As Boolean = False
        Dim filter As String = ""

        Try
            GroupList = New List(Of String)
            filter = "DisplyId = '" & CategoryId & "'"
            For Each rowData As DataRow In dt.Select(filter)
                GroupList.Add(rowData.Item(CategoryDefine.ColumnIndex.GroupId))
            Next
            blnRet = True
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' カテゴリーIDリスト取得
    ''' </summary>
    ''' <param name="dt">カテゴリーDataTable</param>
    ''' <returns></returns>
    Private Function GetCategoryList(ByVal dt As DataTable) As List(Of String)
        Dim CategoryList As New List(Of String)
        Try
            For Each rowData As DataRow In dt.DefaultView.ToTable(True, "CategoryName", "DisplyId").Rows
                CategoryList.Add(rowData.Item(1))
            Next
        Catch ex As Exception

        End Try
        Return CategoryList
    End Function

    ''' <summary>
    ''' 総合テスト名取得
    ''' </summary>
    ''' <param name="TestNo">テストNo.</param>
    ''' <param name="dt">総合テストヘッダDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSynthesisTestName(ByVal TestNo As String, ByVal dt As DataTable) As String
        Dim retStr As String = ""
        Dim Filter As String = ""

        Try
            Filter = "TESTNO = '" & TestNo & "'"
            For Each rowData As DataRow In dt.Select(Filter)
                retStr = rowData.Item(Common.SynthesisHeader.ColumnIndex.TestName)
                Exit For
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return retStr
    End Function

    ''' <summary>
    '''  総合テスト結果ヘッダオブジェクトを追加します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AddSynthesisResultHeader(ByVal NowTime As Date, ByVal TestTime As String, ByVal TestNo As String, ByVal TestCount As String, ByVal UserId As String) As Boolean
        Dim ret As Boolean = True
        Dim Datas(Common.SynthesisResultHeader.ColumnIndex.Max - 1) As String
        Try
            ' DataRowの削除
            If Not DeleteHeaderDataRow(TestNo, TestCount) Then
                Return False
            End If
            ' ユーザID
            Datas(Common.SynthesisResultHeader.ColumnIndex.UserId) = UserId
            ' テスト№
            Datas(Common.SynthesisResultHeader.ColumnIndex.TestNo) = TestNo
            ' 実施回数
            Datas(Common.SynthesisResultHeader.ColumnIndex.TestCount) = TestCount
            ' 実施日
            Datas(Common.SynthesisResultHeader.ColumnIndex.TestDate) = NowTime.ToString("yyyy/MM/dd")
            ' 実施時間
            Datas(Common.SynthesisResultHeader.ColumnIndex.TestTime) = TestTime
            ' 作成日
            Datas(Common.SynthesisResultHeader.ColumnIndex.CreateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")
            ' 更新日
            Datas(Common.SynthesisResultHeader.ColumnIndex.UpdateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")

            '総合テスト結果ヘッダオブジェクト追加
            If Not AddHeaderDataRow(Datas) Then
                '追加エラー
                Dim errCode As String = "E" & Constant.ResultCode.AddSynthesisResultHeader
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
    '''  総合テスト結果明細オブジェクトを追加します。
    ''' </summary>
    ''' <param name="NowTime">現在日時</param>
    ''' <param name="TestCount">テスト実施回数</param>
    ''' <param name="QuestionCodeList">問題コードリスト</param>
    ''' <param name="ResultDataContainer">解答データコンテナオブジェクト</param>
    ''' <param name="questionDefineContainer">問題定義コンテナオブジェクト</param>
    ''' <param name="UserId">ユーザーID</param>
    ''' <remarks></remarks>
    Public Function AddSynthesisResultDetail(ByVal NowTime As Date, ByVal TestCount As String, ByVal TestNo As String, ByVal QuestionCodeList As Dictionary(Of Integer, QuestionCodeDefine), ByVal ResultDataContainer As ResultDataContainer, ByVal questionDefineContainer As QuestionDefineContainer, ByVal UserId As String, ByVal dtPractice As DataTable) As Boolean
        Dim ret As Boolean = True
        Dim Datas(Common.SynthesisResultDetail.ColumnIndex.Max - 1) As String
        Dim MiddleCnt As Integer = 0
        Try
            ' DataRowの削除
            If Not DeleteDetailDataRow(TestCount, TestNo) Then
                Return False
            End If

            For Each key As Integer In QuestionCodeList.Keys
                ' 中問コードと問題コードが異なる場合、データを作成
                If QuestionCodeList.Item(key).MiddleQuestionCode <> QuestionCodeList.Item(key).QuestionCode Then
                    ' ユーザID
                    Datas(Common.SynthesisResultDetail.ColumnIndex.UserId) = DataManager.GetInstance.UserId
                    ' テスト№
                    Datas(Common.SynthesisResultDetail.ColumnIndex.TestNo) = TestNo
                    ' 実施回数
                    Datas(Common.SynthesisResultDetail.ColumnIndex.TestCount) = TestCount
                    ' 表示順
                    If QuestionCodeList.Item(key).MiddleQuestionCode <> "" Then
                        ' 中問の場合
                        Datas(Common.SynthesisResultDetail.ColumnIndex.ShowNo) = key + 1 - MiddleCnt
                    Else
                        ' 小問の場合
                        Datas(Common.SynthesisResultDetail.ColumnIndex.ShowNo) = key + 1
                    End If
                    ' 問題コード
                    Datas(Common.SynthesisResultDetail.ColumnIndex.QuestionCode) = QuestionCodeList.Item(key).QuestionCode
                    ' 主文問題コード
                    Datas(Common.SynthesisResultDetail.ColumnIndex.MainCode) = QuestionCodeList.Item(key).MiddleQuestionCode
                    ' 正解
                    Dim filter As String = "QUESTIONCODE = '" & QuestionCodeList.Item(key).QuestionCode & "'"
                    Dim dataRow() As DataRow = dtPractice.Select(filter)
                    Datas(Common.SynthesisResultDetail.ColumnIndex.CorrectAnswer) = dataRow(0).Item(Common.PracticeQuestionList.ColumnIndex.CorrectAnswer)
                    ' 解答
                    Dim answer As String = ""
                    If Not IsNothing(ResultDataContainer.Item(QuestionCodeList.Item(key).QuestionCode)) Then
                        answer = ResultDataContainer.Item(QuestionCodeList.Item(key).QuestionCode).Answer
                    End If
                    Datas(Common.SynthesisResultDetail.ColumnIndex.Answer) = answer
                    ' 正誤
                    Datas(Common.SynthesisResultDetail.ColumnIndex.ErrAta) = _
                        IIf(Datas(Common.SynthesisResultDetail.ColumnIndex.CorrectAnswer) <> Datas(Common.SynthesisResultDetail.ColumnIndex.Answer), "0", "1")
                    ' 作成日
                    Datas(Common.SynthesisResultDetail.ColumnIndex.CreateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")
                    ' 更新日
                    Datas(Common.SynthesisResultDetail.ColumnIndex.UpdateDate) = NowTime.ToString("yyyy/MM/dd HH:mm:dd")

                    ' 総合テスト結果明細オブジェクト追加
                    If Not AddDetailDataRow(Datas) Then
                        '追加エラー
                        Dim errCode As String = "E" & Constant.ResultCode.AddSynthesisResultDetail
                        Common.Message.MessageShow(errCode)
                        ret = False
                        Exit For
                    End If
                Else
                    MiddleCnt += 1
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
    ''' 総合テスト結果ヘッダデータ追加
    ''' </summary>
    ''' <param name="datas">追加データ配列</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Private Function AddHeaderDataRow(ByVal datas() As String) As Boolean
        Dim blnRet As Boolean = False
        Dim dataRow As DataRow = Nothing
        Dim i As Integer = 0

        Try
            'DataTableの存在チェック
            If IsNothing(_SynthesisResultHeaderTbl) Then
                _SynthesisResultHeaderTbl = New DataTable
                Common.XmlSchema.GetSynthesisResultHeaderSchema(_SynthesisResultHeaderTbl)
            End If

            'カラム数と追加するデータ数が一致するかチェック
            If _SynthesisResultHeaderTbl.Columns.Count = datas.Length Then
                dataRow = _SynthesisResultHeaderTbl.NewRow
                For i = 0 To datas.Length - 1
                    dataRow(i) = datas(i)
                Next
                '追加
                Call _SynthesisResultHeaderTbl.Rows.Add(dataRow)
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
    ''' 総合テスト結果明細データ追加
    ''' </summary>
    ''' <param name="datas">追加データ配列</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Private Function AddDetailDataRow(ByVal datas() As String) As Boolean
        Dim blnRet As Boolean = False
        Dim dataRow As DataRow = Nothing
        Dim i As Integer = 0

        Try
            'DataTableの存在チェック
            If IsNothing(_SynthesisResultDetailTbl) Then
                _SynthesisResultDetailTbl = New DataTable
                Common.XmlSchema.GetSynthesisResultDetailSchema(_SynthesisResultDetailTbl)
            End If

            'カラム数と追加するデータ数が一致するかチェック
            If _SynthesisResultDetailTbl.Columns.Count = datas.Length Then
                dataRow = _SynthesisResultDetailTbl.NewRow
                For i = 0 To datas.Length - 1
                    dataRow(i) = datas(i)
                Next
                '追加
                Call _SynthesisResultDetailTbl.Rows.Add(dataRow)
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
    '''  総合テスト結果ヘッダデータ削除
    ''' </summary>
    ''' <param name="TestNo">実施テストNo.</param>
    ''' <param name="TestCount">実施テスト回数</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    ''' <remarks></remarks>
    Private Function DeleteHeaderDataRow(ByVal TestNo As String, ByVal TestCount As String) As Boolean
        Dim ret As Boolean = True
        Try
            If Not IsNothing(_SynthesisResultHeaderTbl) Then
                Dim Filter As String = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                For Each DataRow As DataRow In _SynthesisResultHeaderTbl.Select(Filter)
                    _SynthesisResultHeaderTbl.Rows.Remove(DataRow)
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
    '''  総合テスト結果明細データ削除
    ''' </summary>
    ''' <param name="TestCount">実施テスト回数</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    ''' <remarks></remarks>
    Private Function DeleteDetailDataRow(ByVal TestCount As String, ByVal TestNo As String) As Boolean
        Dim ret As Boolean = True
        Try
            If Not IsNothing(_SynthesisResultDetailTbl) Then
                Dim Filter As String = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                For Each DataRow As DataRow In _SynthesisResultDetailTbl.Select(Filter)
                    _SynthesisResultDetailTbl.Rows.Remove(DataRow)
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
    '''  総合テスト結果ヘッダデータ取得
    ''' </summary>
    ''' <param name="TestTime">日付</param>
    ''' <returns>総合テスト結果ヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetHeaderDataTable(ByVal TestTime As Date) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim filter As String = "CREATE_DATE >= '" & TestTime.ToString("yyyy/MM/dd 00:00:00") & "'"
            dt = _SynthesisResultHeaderTbl.Select(filter).CopyToDataTable
            dt.TableName = _SynthesisResultHeaderTbl.TableName
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    '''  総合テスト結果明細データ取得
    ''' </summary>
    ''' <param name="TestTime">日付</param>
    ''' <returns>総合テスト結果明細格納DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetDetailDataTable(ByVal TestTime As Date) As DataTable
        Dim dt As DataTable = Nothing
        Try
            Dim filter As String = "CREATE_DATE >= '" & TestTime.ToString("yyyy/MM/dd 00:00:00") & "'"
            dt = _SynthesisResultDetailTbl.Select(filter).CopyToDataTable
            dt.TableName = _SynthesisResultDetailTbl.TableName
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    '''  総合テストカテゴリ別正解率取得
    ''' </summary>
    ''' <returns>成功:True,失敗:False</returns>
    Public Function GetSeparateCategoryAccuracyRate(ByVal dtCategory As DataTable, ByVal dtQuestionList As DataTable, ByVal dtSynthesis As DataTable, ByVal TestCount As String, ByVal TestNo As String) As DataTable
        Dim ret As Boolean = False
        Dim dt As DataTable = Nothing
        Try
            ' 大分類別正解率DataTable作成
            ret = CreateLargeCategoryAccuracyRateDataTable()
            ' 大分類別正解率データ取得
            If ret Then ret = GetLargeCategoryData(dtCategory, dtQuestionList, dtSynthesis, TestCount, TestNo)
            dt = _LargeCategoryAccuracyRateTbl

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            dt = Nothing
        End Try
        Return dt
    End Function

    ''' <summary>
    '''  大分類別正解率DataTable作成
    ''' </summary>
    ''' <returns>成功:True,失敗:False</returns>
    Private Function CreateLargeCategoryAccuracyRateDataTable() As Boolean
        Dim ret As Boolean = True
        Try
            ' インスタンス作成
            _LargeCategoryAccuracyRateTbl = New DataTable

            ' フィールド追加
            With _LargeCategoryAccuracyRateTbl.Columns
                ' 分野名
                .Add("CategoryName", GetType(String))
                '大分類名
                .Add("LargeCategoryName", GetType(String))
                '演習問題数
                .Add("QuestionCount", GetType(String))
                '正解数
                .Add("CorrectAnswerCount", GetType(String))
                '正解率
                .Add("AccuracyRate", GetType(String))
            End With
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            ret = False
        End Try
        Return ret
    End Function

    ''' <summary>
    '''  大分類別正解率データ取得
    ''' </summary>
    ''' <returns>成功:True,失敗:False</returns>
    Private Function GetLargeCategoryData(ByVal dtCategory As DataTable, ByVal dtQuestionList As DataTable, ByVal dtSynthesis As DataTable, ByVal TestCount As String, ByVal TestNo As String) As Boolean
        Dim ret As Boolean = True
        Dim ds As New DataSet
        Dim QuestionCount As Integer = 0
        Dim CorrectAnswerCount As Integer = 0
        Dim AccuracyRate As Integer = 0
        Dim wkData As DataRow = Nothing
        Dim filter As String = ""
        Try
            If Not IsNothing(_LargeCategoryAccuracyRateTbl) Then
                ' 演習問題一覧DataTable追加
                ds.Tables.Add(dtQuestionList.Copy)
                ' 総合テスト明細格納DataTable追加
                filter = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                ds.Tables.Add(dtSynthesis.Select(filter).CopyToDataTable)

                ' リレーションの設定
                Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), _
                                                               ds.Tables(1).Columns(Common.SynthesisResultDetail.ColumnIndex.QuestionCode))
                For Each rowData As DataRow In dtCategory.Rows
                    If IsNothing(wkData) Then wkData = rowData
                    If Not IsNothing(wkData) AndAlso wkData.Item(CategoryDefine.ColumnIndex.LargeCategoryId) _
                        <> rowData.Item(CategoryDefine.ColumnIndex.LargeCategoryId) Then
                        ' 行追加
                        ret = AddLargeCategoryAccuracyRateRow(wkData, QuestionCount, CorrectAnswerCount)
                        ' 初期化
                        QuestionCount = 0
                        CorrectAnswerCount = 0
                        AccuracyRate = 0
                        wkData = rowData
                    End If

                    ' 問題種別="小問"、カテゴリーID="演習問題一覧のグループID"、状態="使用中"
                    'filter = "CATEGORYID = '" & rowData.Item(CategoryDefine.ColumnIndex.GroupId) & "' AND STATE = '0'"
                    filter = "CATEGORYID = '" & rowData.Item(CategoryDefine.ColumnIndex.GroupId) & "'"
                    ' 演習問題一覧DataTableからレコード取得する
                    For Each rowData1 As DataRow In ds.Tables(0).Select(filter)
                        ' 指定したDataRelationを使用して、レコード取得する
                        For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                            If rowData2.Item(Common.SynthesisResultDetail.ColumnIndex.ErrAta) = "1" Then
                                ' 正解数
                                CorrectAnswerCount += 1
                            End If
                            ' 問題数
                            QuestionCount += 1
                        Next
                    Next
                Next

                ' 最終列を追加
                If Not IsNothing(wkData) Then
                    ret = AddLargeCategoryAccuracyRateRow(wkData, QuestionCount, CorrectAnswerCount)
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            ret = False
        End Try
        Return ret
    End Function

    ''' <summary>
    '''  大分類別正解率データ行追加
    ''' </summary>
    ''' <returns>成功:True,失敗:False</returns>
    Private Function AddLargeCategoryAccuracyRateRow(ByVal wkData As DataRow, ByVal QuestionCount As Integer, ByVal CorrectAnswerCount As Integer) As Boolean
        Dim ret As Boolean = True
        Dim AccuracyRate As String = "0.0"
        Try
            Dim newData As DataRow = _LargeCategoryAccuracyRateTbl.NewRow

            ' 分類名
            newData.Item(LargeCategoryAccuracyRateTblIndex.CategoryName) = wkData.Item(CategoryDefine.ColumnIndex.CategoryName)
            ' 大分類名
            newData.Item(LargeCategoryAccuracyRateTblIndex.LargeCategoryName) = wkData.Item(CategoryDefine.ColumnIndex.LargeCategoryName)
            ' 演習問題数
            newData.Item(LargeCategoryAccuracyRateTblIndex.QuestionCount) = QuestionCount
            ' 正解数
            newData.Item(LargeCategoryAccuracyRateTblIndex.CorrectAnswerCount) = CorrectAnswerCount
            ' 正解率
            If QuestionCount > 0 Then
                'AccuracyRate = ((CorrectAnswerCount / QuestionCount) * 100).ToString("0.0")
                AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
            End If
            newData.Item(LargeCategoryAccuracyRateTblIndex.AccuracyRate) = AccuracyRate

            ' レコード追加
            _LargeCategoryAccuracyRateTbl.Rows.Add(newData)

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            ret = False
        End Try
        Return ret
    End Function


    ''' <summary>
    '''  問別正誤データ取得
    ''' </summary>
    ''' <param name="TestCount">テスト実施回数</param>
    ''' <param name="dtPractice">演習データテーブル</param>
    ''' <returns>総合テスト問別正誤DataTable</returns>
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

            If Not IsNothing(_SynthesisResultDetailTbl) Then
                ds.Tables.Add(_SynthesisResultDetailTbl.Copy)
                ds.Tables.Add(dtPractice.Copy)
                Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.SynthesisResultDetail.ColumnIndex.QuestionCode), ds.Tables(1).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), False)

                Dim Filter As String = "TESTCOUNT = '" & TestCount & "' AND TESTNO = '" & TestNo & "'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(Filter)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        ' データセット
                        dataRow = _SynthesisTrueFalseTbl.NewRow
                        dataRow(SynthesisTrueFalseTblIndex.QuestionNumber) = QuestionNumber
                        dataRow(SynthesisTrueFalseTblIndex.QuestionTheme) = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.Theme)
                        dataRow(SynthesisTrueFalseTblIndex.CorrectansAnswer) = rowData1.Item(Common.SynthesisResultDetail.ColumnIndex.CorrectAnswer)
                        dataRow(SynthesisTrueFalseTblIndex.Answer) = rowData1.Item(Common.SynthesisResultDetail.ColumnIndex.Answer)
                        dataRow(SynthesisTrueFalseTblIndex.Errata) = rowData1.Item(Common.SynthesisResultDetail.ColumnIndex.ErrAta)
                        dataRow(SynthesisTrueFalseTblIndex.QuestionCode) = rowData1.Item(Common.SynthesisResultDetail.ColumnIndex.QuestionCode)
                    Next
                    ' 問別正誤テーブルデータ追加
                    Call _SynthesisTrueFalseTbl.Rows.Add(dataRow)
                    QuestionNumber += 1
                Next
                dt = _SynthesisTrueFalseTbl.Copy
            End If
        Catch ex As Exception
            _Log.Error(ex)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' 総合テスト問別正誤DataTable作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTrueFalseListDataTable() As Boolean
        Dim ret As Boolean = True
        Try
            'インスタンス生成
            _SynthesisTrueFalseTbl = New DataTable

            'フィールド追加
            With _SynthesisTrueFalseTbl.Columns
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
    '''  総合テスト実施結果DataRow作成
    ''' </summary>
    ''' <param name="TestCount">テスト実施回数</param>
    ''' <param name="dtCategory">カテゴリデータテーブル</param>
    ''' <param name="dtQuestionList">問題コードリスト</param>
    ''' <param name="dtSynthesisHeader">演習データテーブル</param>
    ''' <returns>小テスト実施結果DataRow</returns>
    ''' <remarks></remarks>
    Public Function CreateResultDataRow(ByVal TestCount As String, ByVal TestNo As String, ByVal dtCategory As DataTable, ByVal dtQuestionList As DataTable, ByVal dtSynthesisHeader As DataTable) As DataRow
        Dim ret As Boolean = True
        Dim rowData() As DataRow = Nothing
        Dim filter As String = ""

        Try
            If Not IsNothing(_SynthesisResultHeaderTbl) AndAlso Not IsNothing(_SynthesisResultDetailTbl) Then
                ret = GetSynthesisResultHistory(dtCategory, dtQuestionList, dtSynthesisHeader)

                If ret Then
                    'filter = "TestCount = '" & TestCount & "'"
                    filter = "TestCount = '" & TestCount & "' AND TestNo = '" & TestNo & "'"
                    rowData = _SynthesisResultHistoryTbl.Select(filter)
                End If
            End If
        Catch ex As Exception
            rowData = Nothing
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
