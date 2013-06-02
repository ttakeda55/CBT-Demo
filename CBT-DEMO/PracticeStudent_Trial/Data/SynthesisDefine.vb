
''' <summary>
''' 総合テスト定義クラス
''' </summary>
''' <remarks></remarks>
Public Class SynthesisDefine

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>総合テストヘッダ格納DataTable</summary>
    Private _SynthesisHeaderTbl As DataTable = Nothing
    ''' <summary>総合テスト明細格納Dictionary</summary>
    Private _SynthesisDetailTblDic As Generic.Dictionary(Of String, DataTable)
    ''' <summary>実施テストNo.</summary>
    Private _TestNo As String = ""
    ''' <summary>実施テスト回数</summary>
    Private _TestCount As String = ""
    ''' <summary>総合テストヘッダファイル読込フラグ</summary>
    Private _ReadSynthesisHeader As Boolean = False
    ''' <summary>総合テスト明細ファイル読込フラグ</summary>
    Private _ReadSynthesisDetail As Boolean = False

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 実施テストNo.の取得を行います。
    ''' </summary>
    ''' <returns>実施テストNo.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TestNo As String
        Get
            Return _TestNo
        End Get
    End Property

    ''' <summary>
    ''' 実施テスト回数の取得を行います。
    ''' </summary>
    ''' <returns>実施テスト回数</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TestCount As String
        Get
            Return _TestCount
        End Get
    End Property

    ''' <summary>
    ''' 総合テストヘッダ格納DataTableの取得
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisHeaderDataTable As DataTable
        Get
            If Not IsNothing(_SynthesisHeaderTbl) Then
                Return _SynthesisHeaderTbl.Copy
            Else
                Return Nothing
            End If
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト明細格納Dictionaryの取得を行います。
    ''' </summary>
    ''' <returns>総合テスト明細格納Dictionary</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SynthesisDetailTblDic As Generic.Dictionary(Of String, DataTable)
        Get
            Return _SynthesisDetailTblDic
        End Get
    End Property

    ''' <summary>
    ''' 総合テストヘッダファイル読込チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsReadSynthesisHeader As Boolean
        Get
            Return _ReadSynthesisHeader
        End Get
    End Property

    ''' <summary>
    ''' 総合テスト明細ファイル読込チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsReadSynthesisDetail As Boolean
        Get
            Return _ReadSynthesisDetail
        End Get
    End Property

#End Region

#Region "----- 列挙体 -----"
    Public Enum SortOrder As Integer
        CREATE_DATE = 0
        TESTNAME_AND_RESULT
    End Enum
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 総合テスト読込
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadSynthesis() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '総合テストヘッダ読込
            errCode = ReadSynthesisHeader()
            If errCode = Constant.ResultCode.NormalEnd Then
                '総合テスト明細読込
                errCode = ReadSynthesisDetail()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 総合テストヘッダ読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSynthesisHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            '2012/12/16 T.Takeda
            'Dim searchPattern As String = Common.Constant.CST_SYNTHESISHEADER_FILENAME & "*"
            'Dim searchPattern As String = Common.Constant.CST_SYNTHESISHEADER_FILENAME & DataManager.GetInstance.Syubetu & "*"
            Dim searchPattern As String = Common.Constant.CST_SPECIFICHEADER_FILENAME & "*"
            '総合テストヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SynthesisHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _SynthesisHeaderTbl = Common.SynthesisHeader.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _SynthesisHeaderTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.SynthesisHeaderFileReadError
                    End If
                    '総合テストヘッダファイル読込設定
                    If errCode = Constant.ResultCode.NormalEnd Then _ReadSynthesisHeader = True
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
    ''' 総合テスト明細読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSynthesisDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim wkTbl As DataTable = Nothing
        Try
            '検索ファイル名作成
            'Dim searchPattern As String = Common.Constant.CST_SYNTHESISDETAIL_FILENAME & "*"
            'Dim searchPattern As String = Common.Constant.CST_SYNTHESISDETAIL_FILENAME & DataManager.GetInstance.Syubetu & "*"
            Dim searchPattern As String = Common.Constant.CST_SPECIFICDETAIL_FILENAME & "*"
            '総合テスト明細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If errCode = Constant.ResultCode.NormalEnd Then
                    _SynthesisDetailTblDic = New Generic.Dictionary(Of String, DataTable)
                    For Each fileName As String In fileNameList
                        'DataTable取得
                        wkTbl = New DataTable
                        wkTbl = Common.SynthesisDetail.GetAll(IO.Path.GetFileName(fileName))
                        If wkTbl.Rows.Count < 1 Then
                            errCode = Constant.ResultCode.SynthesisDetailFileReadError
                            Exit For
                        Else
                            _SynthesisDetailTblDic.Add(wkTbl.Rows(0).Item(Common.SpecificDetail.ColumnIndex.TestNo), wkTbl)
                        End If
                        '総合テスト明細ファイル読込設定
                        If errCode = Constant.ResultCode.NormalEnd AndAlso _SynthesisDetailTblDic.Count > 0 Then _ReadSynthesisDetail = True
                    Next
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
    ''' 総合テスト名リスト取得
    ''' </summary>
    ''' <returns>総合テスト名リスト</returns>
    ''' <remarks></remarks>
    Public Function GetSynthesisTestNameList(Optional ByVal iSortOrder As Integer = SortOrder.CREATE_DATE) As Generic.List(Of String)
        Dim TestNameList As New Generic.List(Of String)
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing
        Try

            If Not IsNothing(_SynthesisHeaderTbl) Then
                'filterExpression = "VISIBLE = '1'"
                Select Case iSortOrder
                    Case SortOrder.CREATE_DATE
                        '2012/07/03 NOZAO CHG S
                        'rowDatas = _SynthesisHeaderTbl.Select(filterExpression, "CREATE_DATE")
                        rowDatas = _SynthesisHeaderTbl.Select(filterExpression, "TESTNAME")
                        '2012/07/03 NOZAO CHG E
                        If Not IsNothing(rowDatas) Then
                            '    For Each rowData As DataRow In rowDatas
                            '        '総合テスト名追加
                            '        TestNameList.Add(rowData.Item(Common.SynthesisHeader.ColumnIndex.TestName))
                            '    Next
                            '実施済みのテスト名を追加
                            For Each rowData As DataRow In rowDatas
                                '総合テスト名追加
                                If CheckSynthesisTestResult(rowData) = True Then TestNameList.Add(rowData.Item(Common.SynthesisHeader.ColumnIndex.TestName))
                            Next
                            '未実施のテスト名を追加
                            For Each rowData As DataRow In rowDatas
                                '総合テスト名追加
                                If CheckSynthesisTestResult(rowData) = False Then TestNameList.Add(rowData.Item(Common.SynthesisHeader.ColumnIndex.TestName))
                            Next
                        End If

                    Case SortOrder.TESTNAME_AND_RESULT
                        rowDatas = _SynthesisHeaderTbl.Select(filterExpression, "TESTNAME")
                        If Not IsNothing(rowDatas) Then
                            '未実施のテスト名を追加
                            For Each rowData As DataRow In rowDatas
                                '総合テスト名追加
                                If CheckSynthesisTestResult(rowData) = False Then TestNameList.Add(rowData.Item(Common.SynthesisHeader.ColumnIndex.TestName))
                            Next
                            '実施済みのテスト名を追加
                            For Each rowData As DataRow In rowDatas
                                '総合テスト名追加
                                If CheckSynthesisTestResult(rowData) = True Then TestNameList.Add(rowData.Item(Common.SynthesisHeader.ColumnIndex.TestName))
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
    ''' 総合テスト問題コード一覧取得
    ''' </summary>
    ''' <param name="TestName">総合テスト名</param>
    ''' <param name="dt">問題一覧DataTable</param>
    ''' <param name="dt2">総合テスト結果ヘッダDataTable</param>
    ''' <returns>総合テスト問題コード一覧</returns>
    ''' <remarks></remarks>
    Public Function GetSynthesisQuestionCodeList(ByVal TestName As String, ByVal dt As DataTable, ByVal dt2 As DataTable) As Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim QuestionCodeList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim filterExpression As String = ""
        Dim MainCodeList As New List(Of String)
        Dim ds As New DataSet
        Dim Num As Integer = 0

        Try
            '' 実施テスト回数取得
            '_TestCount = GetTestCount(dt2)
            '総合テストNo.取得
            '_TestNo = GetSynthesisTestNo(TestName)
            _TestNo = "1"
            ' 実施テスト回数取得
            '_TestCount = GetTestCount(dt2, _TestNo)
            _TestCount = 1

            If _TestNo <> "" Then

                ds.Tables.Add(_SynthesisDetailTblDic.Item(_TestNo).Copy)
                ds.Tables.Add(dt.Copy)

                Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.SynthesisDetail.ColumnIndex.QuestionCode), ds.Tables(1).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), False)

                filterExpression = "TESTNO ='" & _TestNo & "'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(filterExpression)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        If rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) <> "" Then
                            Dim filter As String = "QUESTIONCODE = '" & rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) & "' AND QUESTIONCODE = MAINCODE"
                            Dim QuestionCodeDefine As QuestionCodeDefine
                            For Each rowData3 As DataRow In ds.Tables(1).Select(filter)
                                If Not MainCodeList.Contains(rowData3.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)) Then
                                    QuestionCodeDefine = New QuestionCodeDefine
                                    QuestionCodeDefine.QuestionCode = rowData3.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                    QuestionCodeDefine.MiddleQuestionCode = rowData3.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                    'リスト追加
                                    QuestionCodeList.Add(Num, QuestionCodeDefine)
                                    Num += 1
                                    MainCodeList.Add(rowData3.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode))
                                End If
                            Next
                            QuestionCodeDefine = New QuestionCodeDefine
                            QuestionCodeDefine.QuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                            QuestionCodeDefine.MiddleQuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                            'リスト追加
                            QuestionCodeList.Add(Num, QuestionCodeDefine)
                            Num += 1
                        Else
                            Dim QuestionCodeDefine As New QuestionCodeDefine
                            QuestionCodeDefine.QuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                            QuestionCodeDefine.MiddleQuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                            'リスト追加
                            QuestionCodeList.Add(Num, QuestionCodeDefine)
                            Num += 1
                        End If
                    Next
                Next
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
    ''' 総合テストNo.取得
    ''' </summary>
    ''' <param name="TestName">総合テスト名</param>
    ''' <returns>総合テストNo.</returns>
    ''' <remarks></remarks>
    Private Function GetSynthesisTestNo(ByVal TestName As String) As String
        Dim TestNo As String = ""
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing

        Try
            filterExpression = "TESTNAME = '" & TestName & "'"
            rowDatas = _SynthesisHeaderTbl.Select(filterExpression)
            If Not IsNothing(rowDatas) AndAlso rowDatas.Length = 1 Then
                'テストNo.取得
                TestNo = rowDatas(0).Item(Common.SynthesisHeader.ColumnIndex.TestNo)
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
    '''  総合テスト実施回数取得
    ''' </summary>
    ''' <returns>テスト実施回数</returns>
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
            'メッセージ表示
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            TestCount = 0
        End Try
        Return TestCount
    End Function

    '2012/06/12 CST ADD S
    ''' <summary>
    ''' 指定の総合テストが実施済みかチェックを行う。
    ''' </summary>
    ''' <param name="rowData"></param>
    ''' <returns>
    ''' TRUE：実施済み
    ''' FALSE：未実施
    ''' </returns>
    ''' <remarks></remarks>
    Private Function CheckSynthesisTestResult(ByRef rowData As DataRow) As Boolean
        Dim bReturn As Boolean = False

        If Not IsNothing(DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHeaderDataTable) Then
            For Each drSynthesisResultHeader As DataRow In DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHeaderDataTable.Rows
                If rowData.Item(Common.SynthesisHeader.ColumnIndex.TestNo) = drSynthesisResultHeader.Item(Common.SynthesisResultHeader.ColumnIndex.TestNo) Then bReturn = True
            Next
        End If

        Return bReturn
    End Function
    '2012/06/12 CST ADD E
#End Region

End Class
