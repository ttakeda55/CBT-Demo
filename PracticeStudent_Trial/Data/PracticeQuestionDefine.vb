
''' <summary>
''' 逐次演習結果定義クラス
''' </summary>
''' <remarks></remarks>
Public Class PracticeQuestionDefine

#Region "----- 定数 -----"

    ''' <summary>問題種別</summary>
    Public Enum QuestionClass As Integer
        ''' <summary>小問</summary>
        Small = 1
        ''' <summary>中問</summary>
        Middle = 2
    End Enum

    ''' <summary>逐次演習履歴確認用小問履歴行インデックス</summary>
    Public Enum SmallHistTblIndex As Integer
        ''' <summary>分野名</summary>
        CategoryName = 0
        ''' <summary>大分類名</summary>
        LargeCategoryName
        ''' <summary>中分類名</summary>
        MiddleCategoryName
        ''' <summary>演習問題数</summary>
        QuestionCount
        ''' <summary>正解数</summary>
        CorrectAnswerCount
        ''' <summary>正解率</summary>
        AccuracyRate
    End Enum

    ''' <summary>逐次演習履歴確認用中問履歴行インデックス</summary>
    Public Enum MiddleHistTblIndex As Integer
        ''' <summary>演習問題数</summary>
        QuestionCount = 0
        ''' <summary>正解数</summary>
        CorrectAnswerCount
        ''' <summary>正解率</summary>
        AccuracyRate
    End Enum

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>演習問題一覧格納DataTable</summary>
    Private _PracticeQuestionListTbl As DataTable = Nothing
    ''' <summary>問題群格納DataTable</summary>
    Private _QuestionCollectionTbl As DataTable = Nothing
    ''' <summary>再演習格納DataTable</summary>
    Private _ReviewTbl As DataTable = Nothing
    ''' <summary>逐次演習結果ヘッダ格納DataTable</summary>
    Private _SerialResultHeaderTbl As DataTable = Nothing
    ''' <summary>逐次演習結果明細格納DataTable</summary>
    Private _SerialResultDetailTbl As DataTable = Nothing
    ''' <summary>逐次演習履歴確認用小問履歴DataTable</summary>
    Private _SamllQuestionHistoryTbl As DataTable = Nothing
    ''' <summary>逐次演習履歴確認用中問履歴DataTable</summary>
    Private _MiddleQuestionHistoryTbl As DataTable = Nothing
    ''' <summary>逐次演習履歴確認用演習回数</summary>
    Private _PracticeCount As Integer
    ''' <summary>逐次演習履歴確認用演習時間(分)</summary>
    Private _PracticeTime As Integer
    ''' <summary>実施テスト回数</summary>
    Private _TestCount As Integer = 0
    ''' <summary>小テスト実施テスト回数</summary>
    Private _MiniResultTestCount As Integer = 0
    ''' <summary>種別</summary>
    Private _TestClass As Integer = 0
    ''' <summary>逐次演習結果ヘッダバックアップファイル名</summary>
    Private _SerialResultHeaderBackupFileName As String = ""
    ''' <summary>逐次演習結果詳細バックアップファイル名</summary>
    Private _SerialResultDetailBackupFileName As String = ""
    ''' <summary>再演習バックアップファイル名</summary>
    Private _ReviewBackupFileName As String = ""
    ''' <summary>逐次演習結果ヘッダファイル名</summary>
    Private _SerialResultHeaderFileName As String = ""
    ''' <summary>逐次演習結果詳細ファイル名</summary>
    Private _SerialResultDetailFileName As String = ""
    ''' <summary>再演習ファイル名</summary>
    Private _ReviewFileName As String = ""
    ''' <summary>演習問題一覧ファイル読込フラグ</summary>
    Private _ReadPracticeQuestion As Boolean = False
    ''' <summary>問題群ファイル読込フラグ</summary>
    Private _ReadCollection As Boolean = False

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 演習問題一覧DataTableの取得
    ''' </summary>
    ''' <returns>逐次演習履歴確認用小問履歴DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PracticeQuestionListDataTable As DataTable
        Get
            If IsNothing(_PracticeQuestionListTbl) Then
                Return Nothing
            Else
                Return _PracticeQuestionListTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 逐次演習履歴確認用小問履歴DataTableの取得
    ''' </summary>
    ''' <returns>逐次演習履歴確認用小問履歴DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SamllQuestionHistoryDataTable As DataTable
        Get
            If IsNothing(_SamllQuestionHistoryTbl) Then
                Return Nothing
            Else
                Return _SamllQuestionHistoryTbl
            End If
        End Get
    End Property

    ''' <summary>
    ''' 逐次演習履歴確認用中問履歴DataTableの取得
    ''' </summary>
    ''' <returns>逐次演習履歴確認用中問履歴DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MiddleQuestionHistoryDataTable As DataTable
        Get
            If IsNothing(_MiddleQuestionHistoryTbl) Then
                Return Nothing
            Else
                Return _MiddleQuestionHistoryTbl
            End If
        End Get
    End Property

    ''' <summary>
    ''' 逐次演習履歴確認用演習回数の取得
    ''' </summary>
    ''' <returns>逐次演習履歴確認用演習回数</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PracticeCount As Integer
        Get
            Return _PracticeCount
        End Get
    End Property

    ''' <summary>
    ''' 逐次演習履歴確認用演習時間の取得
    ''' </summary>
    ''' <returns>逐次演習履歴確認用演習時間</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PracticeTime As Integer
        Get
            Return _PracticeTime
        End Get
    End Property

    ''' <summary>
    ''' 逐次演習結果ヘッダ格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>逐次演習結果ヘッダ格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SerialResultHeaderDataTable As DataTable
        Get
            If IsNothing(_SerialResultHeaderTbl) Then
                Return Nothing
            Else
                Return _SerialResultHeaderTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 逐次演習結果明細格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>逐次演習結果明細格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SerialResultDetailDataTable As DataTable
        Get
            If IsNothing(_SerialResultDetailTbl) Then
                Return Nothing
            Else
                Return _SerialResultDetailTbl.Copy
            End If
        End Get
    End Property

    ''' <summary>
    ''' 再演習格納格納DataTableの取得を行います。
    ''' </summary>
    ''' <returns>再演習格納格納DataTable</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ReviewDataTable As DataTable
        Get
            If IsNothing(_ReviewTbl) Then
                Return Nothing
            Else
                Return _ReviewTbl.Copy
            End If
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
    ''' 小テスト実施テスト回数の取得を行います。
    ''' </summary>
    ''' <returns>小テスト実施テスト回数</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MiniResultTestCount As String
        Get
            Return _MiniResultTestCount
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
    ''' 逐次演習結果ヘッダバックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>逐次演習結果ヘッダバックアップファイル名</value>
    ''' <returns>逐次演習結果ヘッダバックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property SerialResultHeaderBackupFileName As String
        Get
            Return _SerialResultHeaderBackupFileName
        End Get
        Set(ByVal value As String)
            _SerialResultHeaderBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 逐次演習結果詳細バックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>逐次演習結果詳細バックアップファイル名</value>
    ''' <returns>逐次演習結果詳細バックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property SerialResultDetailBackupFileName As String
        Get
            Return _SerialResultDetailBackupFileName
        End Get
        Set(ByVal value As String)
            _SerialResultDetailBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 再演習バックアップファイル名の取得・設定
    ''' </summary>
    ''' <value>再演習バックアップファイル名</value>
    ''' <returns>再演習バックアップファイル名</returns>
    ''' <remarks></remarks>
    Public Property ReviewBackupFileName As String
        Get
            Return _ReviewBackupFileName
        End Get
        Set(ByVal value As String)
            _ReviewBackupFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 逐次演習結果ヘッダファイル名の取得・設定
    ''' </summary>
    ''' <value>逐次演習結果ヘッダファイル名</value>
    ''' <returns>逐次演習結果ヘッダファイル名</returns>
    ''' <remarks></remarks>
    Public Property SerialResultHeaderFileName As String
        Get
            Return _SerialResultHeaderFileName
        End Get
        Set(ByVal value As String)
            _SerialResultHeaderFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 逐次演習結果詳細ファイル名の取得・設定
    ''' </summary>
    ''' <value>逐次演習結果詳細ファイル名</value>
    ''' <returns>逐次演習結果詳細ファイル名</returns>
    ''' <remarks></remarks>
    Public Property SerialResultDetailFileName As String
        Get
            Return _SerialResultDetailFileName
        End Get
        Set(ByVal value As String)
            _SerialResultDetailFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 再演習ファイル名の取得・設定
    ''' </summary>
    ''' <value>再演習ファイル名</value>
    ''' <returns>再演習ファイル名</returns>
    ''' <remarks></remarks>
    Public Property ReviewFileName As String
        Get
            Return _ReviewFileName
        End Get
        Set(ByVal value As String)
            _ReviewFileName = value
        End Set
    End Property

    ''' <summary>
    ''' 演習問題一覧ファイル読込チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsReadPracticeQuestion As Boolean
        Get
            Return _ReadPracticeQuestion
        End Get
    End Property

    ''' <summary>
    ''' 問題群ファイル読込チェック
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsReadCollection As Boolean
        Get
            Return _ReadCollection
        End Get
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 演習問題読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadPracticeQuestion() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '演習問題一覧読込
            errCode = ReadPracticeQuestionList()

            '再演習読込
            If errCode = Constant.ResultCode.NormalEnd Then
                errCode = ReadReview()
            End If

            '問題群読込
            If errCode = Constant.ResultCode.NormalEnd Then
                errCode = ReadCollection()
            End If

            If errCode = Constant.ResultCode.NormalEnd Then
                '逐次演習結果ヘッダ読込
                errCode = ReadSerialResultHeader()
            End If
            If errCode = Constant.ResultCode.NormalEnd Then
                '逐次演習結果明細読込
                errCode = ReadSerialResultDetail()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 演習問題一覧読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadPracticeQuestionList() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & "*"
            '演習問題一覧ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.PracticeQuestionListFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _PracticeQuestionListTbl = Common.PracticeQuestionList.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _PracticeQuestionListTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.PracticeQuestionListFileReadError
                    Else
                        '演習問題一覧ファイル読込フラグ設定
                        _ReadPracticeQuestion = True
                        'ダウンロードフィールド追加
                        errCode = AddDownLoadColumn()
                    End If
                    'CSV出力(DEBUG用)
                    DebugFile.DataTableOutPutCsv(_PracticeQuestionListTbl, DebugFile.FileType.PracticeQuestionList)
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
    ''' 問題群読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadCollection() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_COLLECTION_FILENAME & "*"
            '問題群ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.CollectionFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _QuestionCollectionTbl = Common.QuestionCollection.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _QuestionCollectionTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.CollectionFileReadError
                    End If
                    '問題群ファイル読込フラグ設定
                    If errCode = Constant.ResultCode.NormalEnd Then _ReadCollection = True
                    'CSV出力(DEBUG用)
                    DebugFile.DataTableOutPutCsv(_QuestionCollectionTbl, DebugFile.FileType.Collection)
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
    ''' 再演習読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadReview() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_REVIEW_FILENAME & "*"
            '再演習ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.ReviewFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _ReviewTbl = Common.Review.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _ReviewTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.ReviewFileReadError
                    End If
                    'CSV出力(DEBUG用)
                    DebugFile.DataTableOutPutCsv(_ReviewTbl, DebugFile.FileType.Review)
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
    ''' 逐次演習結果ヘッダ読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSerialResultHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SERIALRESULTHEADER_FILENAME & "*"
            '逐次演習結果ヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SerialResultHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _SerialResultHeaderTbl = Common.SerialResultHeader.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _SerialResultHeaderTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.SerialResultHeaderFileReadError
                    End If
                    'CSV出力(DEBUG用)
                    DebugFile.DataTableOutPutCsv(_SerialResultHeaderTbl, DebugFile.FileType.SerialResultHeader)
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
    ''' 逐次演習結果明細読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadSerialResultDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_SERIALRESULTDETAIL_FILENAME & "*"
            '逐次演習結果明細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.SerialResultDetailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'DataTable取得
                    _SerialResultDetailTbl = Common.SerialResultDetail.GetAll(IO.Path.GetFileName(fileNameList(0)))
                    If _SerialResultDetailTbl.Rows.Count < 1 Then
                        errCode = Constant.ResultCode.SerialResultDetailFileReadError
                    End If
                    'CSV出力(DEBUG用)
                    DebugFile.DataTableOutPutCsv(_SerialResultDetailTbl, DebugFile.FileType.SerialResultDetail)
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
    ''' ダウンロードフィールド追加
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AddDownLoadColumn() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            'フィールド追加
            _PracticeQuestionListTbl.Columns.Add("DownLoadFlg", GetType(String))

            'データ追加
            For Each rowData As DataRow In _PracticeQuestionListTbl.Rows
                rowData.Item(Common.PracticeQuestionList.ColumnIndex.UpdateDate + 1) = "0"
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 問題コードダウンロードチェック
    ''' </summary>
    ''' <param name="QuestionCode">問題コード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsQuestionCodeDownLoad(ByVal QuestionCode As String) As Boolean
        Dim blnRet As Boolean = False
        Dim filter As String = ""

        Try
            filter = "QUESTIONCODE = '" & QuestionCode & "'"
            For Each rowData As DataRow In _PracticeQuestionListTbl.Select(filter)
                If rowData.Item(Common.PracticeQuestionList.ColumnIndex.UpdateDate + 1) = "1" Then
                    blnRet = True
                End If
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 問題コードダウンロード済設定
    ''' </summary>
    ''' <param name="QuestionCode">問題コード</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetQuestionCodeDownLoad(ByVal QuestionCode As String) As Boolean
        Dim blnRet As Boolean = True
        Dim filter As String = ""

        Try
            filter = "QUESTIONCODE = '" & QuestionCode & "'"
            For Each rowData As DataRow In _PracticeQuestionListTbl.Select(filter)
                rowData.Item(Common.PracticeQuestionList.ColumnIndex.UpdateDate + 1) = "1"
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 演習履歴取得
    ''' </summary>
    ''' <param name="GroupIdList">登録問題数</param>
    ''' <param name="AccuracyRate">実施問題数</param>
    ''' <param name="PracticeCount">正解率</param>
    ''' <param name="EntryCount"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPracticeHistory(ByVal GroupIdList As Generic.Dictionary(Of String, Generic.List(Of String)) _
                                     , ByRef AccuracyRate As Generic.Dictionary(Of String, String) _
                                     , ByRef PracticeCount As Generic.Dictionary(Of String, Integer) _
                                     , ByRef EntryCount As Generic.Dictionary(Of String, Integer)) As Boolean
        Dim blnRet As Boolean = True
        Dim AccuracyCount As Integer = 0
        Dim QuestionCount As Integer = 0
        Dim Rate As String = "0.0"

        Try
            '初期化
            AccuracyRate = New Generic.Dictionary(Of String, String)
            PracticeCount = New Generic.Dictionary(Of String, Integer)
            EntryCount = New Generic.Dictionary(Of String, Integer)

            For Each MiddleId As String In GroupIdList.Keys
                AccuracyCount = 0
                QuestionCount = 0
                Rate = "0.0"
                For Each GroupId As String In GroupIdList.Item(MiddleId)
                    '登録問題数取得
                    blnRet = GetEntryQuestionCount(MiddleId, GroupId, EntryCount)
                    '実施問題数取得
                    If blnRet Then blnRet = GetPracticeQuestionCount(MiddleId, GroupId, PracticeCount)
                    '正解数(重複カウント)、実施問題数(重複カウント)取得
                    If blnRet Then blnRet = GetAccuracyAndQuestionCount(MiddleId, GroupId, AccuracyCount, QuestionCount)

                    If Not blnRet Then Exit For
                Next
                '正解率取得
                If QuestionCount > 0 Then
                    Rate = (Math.Floor((AccuracyCount / QuestionCount) * 1000) / 10).ToString("0.0")
                End If
                AccuracyRate.Add(MiddleId, Rate)
                If Not blnRet Then Exit For
            Next

            If Not blnRet Then
                AccuracyRate = Nothing
                PracticeCount = Nothing
                EntryCount = Nothing
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
    ''' 登録問題数取得
    ''' </summary>
    ''' <param name="MiddleId">中分類カテゴリーID</param>
    ''' <param name="GroupId">グループID</param>
    ''' <param name="EntryCount">登録問題数リスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEntryQuestionCount(ByVal MiddleId As String, ByVal GroupId As String _
                                         , ByRef EntryCount As Generic.Dictionary(Of String, Integer)) As Boolean
        Dim blnRet As Boolean = True
        Dim ds As New DataSet
        Dim filterExpression As String = ""
        Dim rowDatas() As DataRow = Nothing
        Dim count As Integer = 0

        Try
            ds.Tables.Add(_PracticeQuestionListTbl.Copy)
            ds.Tables.Add(_QuestionCollectionTbl.Copy)
            Dim dataRel As DataRelation = ds.Relations.Add("Relation", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode))
            'filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & GroupId & "' AND STATE = '0'"
            filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & GroupId & "'"
            For Each rowData1 As DataRow In ds.Tables(0).Select(filterExpression)
                For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                    count += 1
                Next
            Next
            If EntryCount.ContainsKey(MiddleId) Then
                EntryCount.Item(MiddleId) += count
            Else
                EntryCount.Add(MiddleId, count)
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 実施問題数取得
    ''' </summary>
    ''' <param name="MiddleId">中分類カテゴリーID</param>
    ''' <param name="GroupId">グループID</param>
    ''' <param name="PracticeCount">実施問題数リスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPracticeQuestionCount(ByVal MiddleId As String, ByVal GroupId As String _
                                            , ByRef PracticeCount As Generic.Dictionary(Of String, Integer))
        Dim blnRet As Boolean = True
        Dim filterExpression As String = ""
        Dim dt As DataTable = Nothing
        Dim count As Integer = 0

        Try
            If IsNothing(_SerialResultDetailTbl) Then
                count = 0
            Else
                dt = _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE")
                'filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & GroupId & "' AND STATE = '0'"
                filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & GroupId & "'"
                For Each rowData1 As DataRow In _PracticeQuestionListTbl.Select(filterExpression)
                    Dim Filter As String = "QUESTIONCODE = '" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "'"
                    For Each rowData2 As DataRow In dt.Select(Filter)
                        count += 1
                    Next
                Next
            End If
            If PracticeCount.ContainsKey(MiddleId) Then
                PracticeCount.Item(MiddleId) += count
            Else
                PracticeCount.Add(MiddleId, count)
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
    ''' 正解数、実施問題数取得
    ''' </summary>
    ''' <param name="MiddleId">中分類カテゴリーID</param>
    ''' <param name="GroupId">グループID</param>
    ''' <param name="AccuracyCount">正解数(重複含む)</param>
    ''' <param name="QuestionCount">実施問題数(重複含む)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAccuracyAndQuestionCount(ByVal MiddleId As String, ByVal GroupId As String, ByRef AccuracyCount As Integer, ByRef QuestionCount As Integer) As Boolean
        Dim blnRet As Boolean = True
        Dim filterExpression As String = ""

        Try
            If IsNothing(_SerialResultDetailTbl) Then
                AccuracyCount = 0
                QuestionCount = 0
            Else
                'filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & GroupId & "' AND STATE = '0'"
                filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & GroupId & "'"
                For Each rowData1 As DataRow In _PracticeQuestionListTbl.Select(filterExpression)
                    Dim Filter As String = "QUESTIONCODE = '" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "'"
                    For Each rowData2 As DataRow In _SerialResultDetailTbl.Select(Filter)
                        QuestionCount += 1
                        If rowData2.Item(Common.SerialResultDetail.ColumnIndex.ErrAta) = "1" Then
                            AccuracyCount += 1
                        End If
                    Next
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
    ''' グループIDに紐付く問題コードリスト取得
    ''' </summary>
    ''' <param name="GroupId">グループIDリスト</param>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSmallPracticeQuestionListForGroupId(ByVal GroupId As Generic.List(Of String), ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine)) As Boolean
        Dim blnRet As Boolean = True
        Dim num As Integer = 0
        Dim filterExpression As String = ""
        Dim ds As New DataSet

        Try
            'リレーション設定
            ds.Tables.Add(_PracticeQuestionListTbl.Copy)
            ds.Tables.Add(_QuestionCollectionTbl.Copy)
            Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode), False)

            '問題コード取得
            For Each Id As String In GroupId
                'filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & Id & "' AND STATE = '0'"
                filterExpression = "QUESTIONCLASS = '1' AND CATEGORYID = '" & Id & "'"
                For Each rowData As DataRow In ds.Tables(0).Select(filterExpression)
                    For Each rowData2 As DataRow In rowData.GetChildRows(dataRel)
                        '問題コード追加
                        Dim QuestionCodeDefine As New QuestionCodeDefine
                        QuestionCodeDefine.QuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                        QuestionCodeDefine.MiddleQuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                        QuestionList.Add(num, QuestionCodeDefine)
                        num += 1
                    Next
                Next
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 計算問題を除いた問題コードリスト取得
    ''' </summary>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNotCalcQuestion(ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine)) As Boolean
        Dim blnRet As Boolean = True
        Dim wkList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim num As Integer = 0
        Dim ds As New DataSet

        Try
            ds.Tables.Add(_PracticeQuestionListTbl.Copy)
            ds.Tables.Add(_QuestionCollectionTbl.Copy)
            Dim dataRel As DataRelation = ds.Relations.Add("Relation", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode))

            'For Each rowData1 As DataRow In ds.Tables(0).Select("QUESTIONCLASS = '1' AND FORMAT <> '計算' AND STATE = '0'")
            For Each rowData1 As DataRow In ds.Tables(0).Select("QUESTIONCLASS = '1' AND FORMAT <> '計算'")
                For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                    Dim QuestionCode As New QuestionCodeDefine
                    QuestionCode.QuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                    QuestionCode.MiddleQuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                    wkList.Add(num, QuestionCode)
                    num += 1
                Next
            Next

            If QuestionList.Count = 0 Then
                QuestionList = wkList
            Else
                Dim wkMarge As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
                num = 0
                For Each key1 As Integer In QuestionList.Keys
                    For Each key2 As Integer In wkList.Keys
                        If QuestionList.Item(key1).QuestionCode = wkList.Item(key2).QuestionCode Then
                            wkMarge.Add(num, QuestionList.Item(key1))
                            num += 1
                            Exit For
                        End If
                    Next
                Next
                QuestionList = wkMarge
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 直近の出題時に不正解となった問題コードリスト取得
    ''' </summary>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <param name="QuestionClass">問題種別</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetIncorrectAnswer(ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine), Optional ByVal QuestionClass As QuestionClass = QuestionClass.Small) As Boolean
        Dim blnRet As Boolean = True
        Dim InCorrectTbl As DataTable = Nothing
        Dim filterExpression As String = ""
        Dim wkList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim Num As Integer = 0
        Dim ds As New DataSet
        Dim AddMiddleQuestionCode As New List(Of String)

        Try
            '不正解となった問題の取得
            InCorrectTbl = GetIncorrectAnswerQuestionCode()
            If Not IsNothing(InCorrectTbl) AndAlso InCorrectTbl.Rows.Count > 0 Then
                ds.Tables.Add(_PracticeQuestionListTbl.Copy)
                ds.Tables.Add(_QuestionCollectionTbl.Copy)
                ds.Tables.Add(InCorrectTbl.Copy)

                Dim dataRel As DataRelation = ds.Relations.Add("REL1", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode), False)
                Dim dataRel2 As DataRelation = ds.Relations.Add("REL2", ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode), ds.Tables(2).Columns(0), False)


                'filterExpression = "QUESTIONCLASS = '" & QuestionClass & "' AND STATE = '0'"
                filterExpression = "QUESTIONCLASS = '" & QuestionClass & "'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(filterExpression)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        For Each rowData3 As DataRow In rowData2.GetChildRows(dataRel2)
                            If QuestionClass = PracticeQuestionDefine.QuestionClass.Middle Then
                                '中問
                                If Not AddMiddleQuestionCode.Contains(rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)) Then
                                    AddMiddleQuestionCode.Add(rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode))
                                    Dim Filter As String = "QUESTIONCLASS = '" & QuestionClass & "' AND MAINCODE ='" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) & "'"
                                    For Each rowData As DataRow In _PracticeQuestionListTbl.Select(Filter)
                                        Dim QuestionCodeDefine As New QuestionCodeDefine
                                        QuestionCodeDefine.QuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                        QuestionCodeDefine.MiddleQuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                        wkList.Add(Num, QuestionCodeDefine)
                                        Num += 1
                                    Next
                                End If
                            Else
                                '小問
                                Dim QuestionCodeDefine As New QuestionCodeDefine
                                QuestionCodeDefine.QuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                QuestionCodeDefine.MiddleQuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                wkList.Add(Num, QuestionCodeDefine)
                                Num += 1
                            End If
                        Next
                    Next
                Next

                If QuestionList.Count = 0 Then
                    QuestionList = wkList
                Else
                    Dim wkMarge As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
                    Num = 0
                    For Each key1 As Integer In QuestionList.Keys
                        For Each key2 As Integer In wkList.Keys
                            If QuestionList.Item(key1).QuestionCode = wkList.Item(key2).QuestionCode Then
                                wkMarge.Add(Num, QuestionList.Item(key1))
                                Num += 1
                                Exit For
                            End If
                        Next
                    Next
                    QuestionList = wkMarge
                End If
            Else
                QuestionList.Clear()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 不正解となった問題コードリスト取得
    ''' </summary>
    ''' <returns>問題コード格納DataTable</returns>
    ''' <remarks></remarks>
    Private Function GetIncorrectAnswerQuestionCode() As DataTable
        Dim QuestionTbl As New DataTable
        Dim CorrectTbl As DataTable = Nothing
        Dim InCorrectTbl As DataTable = Nothing
        Dim rowData As DataRow = Nothing
        Dim ds As New DataSet

        Try
            If Not IsNothing(_SerialResultDetailTbl) Then
                ''正解
                'If _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE", "ERRATA").Select("ERRATA = '1'").Count > 0 Then
                '    CorrectTbl = _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE", "ERRATA").Select("ERRATA = '1'").CopyToDataTable
                'Else
                '    CorrectTbl = _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE", "ERRATA").Clone
                'End If
                ''不正解
                'If _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE", "ERRATA").Select("ERRATA = '0'").Count > 0 Then
                '    InCorrectTbl = _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE", "ERRATA").Select("ERRATA = '0'").CopyToDataTable
                'Else
                '    InCorrectTbl = _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE", "ERRATA").Clone
                'End If
                'CorrectTbl.Columns.Add("Date")
                'InCorrectTbl.Columns.Add("Date")

                'For Each rowData In CorrectTbl.Rows
                '    Dim expr As String = "QUESTIONCODE = '" & rowData.Item(0) & "' AND ERRATA = '" & rowData.Item(1) & "'"
                '    rowData("Date") = _SerialResultDetailTbl.Compute("MAX(CREATE_DATE)", expr)
                'Next

                'For Each rowData In InCorrectTbl.Rows
                '    Dim expr As String = "QUESTIONCODE = '" & rowData.Item(0) & "' AND ERRATA = '" & rowData.Item(1) & "'"
                '    rowData("Date") = _SerialResultDetailTbl.Compute("MAX(CREATE_DATE)", expr)
                'Next

                'QuestionTbl = InCorrectTbl.Clone
                'For Each rowData In InCorrectTbl.Rows
                '    Dim Filter As String = "QUESTIONCODE = '" & rowData.Item(0) & "'"
                '    Dim rowDatas() As DataRow = CorrectTbl.Select(Filter)
                '    If rowDatas.Count = 0 Then
                '        QuestionTbl.ImportRow(rowData)
                '    Else
                '        For Each rowData1 As DataRow In rowDatas
                '            'If rowData.Item(2) >= rowData1.Item(2) Then
                '            If rowData.Item(2) > rowData1.Item(2) Then
                '                QuestionTbl.ImportRow(rowData)
                '            End If
                '        Next
                '    End If
                'Next
                Dim CodeList As New List(Of String)
                QuestionTbl.Columns.Add("QUESTIONCODE")
                QuestionTbl.Columns.Add("ERRATA")

                For Each rowData In _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE").Rows
                    Dim filter As String = "QUESTIONCODE = '" & rowData.Item(0) & "'"
                    Dim MaxTestCount As Integer = 0
                    For Each rowData1 As DataRow In _SerialResultDetailTbl.Select(filter)
                        If MaxTestCount < CInt(rowData1.Item(Common.SerialResultDetail.ColumnIndex.TestCount)) Then
                            MaxTestCount = CInt(rowData1.Item(Common.SerialResultDetail.ColumnIndex.TestCount))
                        End If
                    Next
                    Dim filter2 As String = "TESTCOUNT = '" & MaxTestCount & "' AND QUESTIONCODE = '" & rowData.Item(0) & "'"
                    For Each rowData2 As DataRow In _SerialResultDetailTbl.Select(filter2)
                        If rowData2.Item(Common.SerialResultDetail.ColumnIndex.ErrAta) = "0" AndAlso Not CodeList.Contains(rowData2.Item(Common.SerialResultDetail.ColumnIndex.QuestionCode)) Then
                            Dim newData As DataRow = QuestionTbl.NewRow
                            newData.Item("QUESTIONCODE") = rowData2.Item(Common.SerialResultDetail.ColumnIndex.QuestionCode)
                            newData.Item("ERRATA") = rowData2.Item(Common.SerialResultDetail.ColumnIndex.ErrAta)
                            QuestionTbl.Rows.Add(newData)
                            CodeList.Add(rowData2.Item(Common.SerialResultDetail.ColumnIndex.QuestionCode))
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return QuestionTbl
    End Function

    ''' <summary>
    ''' 再演習にチェックを入れた問題コードリスト取得
    ''' </summary>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <param name="QuestionClass">問題種別</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetReview(ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine), ByVal blnIncorrectAnswerFlg As Boolean, Optional ByVal QuestionClass As QuestionClass = QuestionClass.Small) As Boolean
        Dim blnRet As Boolean = True
        Dim wkList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim Num As Integer = 0
        Dim ds As New DataSet
        Dim AddMiddleQuestionCode As New List(Of String)

        Try
            If Not IsNothing(_ReviewTbl) Then
                Dim dt As DataTable = _ReviewTbl.DefaultView.ToTable(True, "QUESTIONCODE")
                ds.Tables.Add(_PracticeQuestionListTbl.Copy)
                ds.Tables.Add(_QuestionCollectionTbl.Copy)


                Dim dataRel As DataRelation = ds.Relations.Add("REL1", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode), False)


                'Dim filterExpression As String = "QUESTIONCLASS = '" & QuestionClass & "' AND STATE = '0'"
                Dim filterExpression As String = "QUESTIONCLASS = '" & QuestionClass & "'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(filterExpression)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        Dim Filter As String = "QUESTIONCODE = '" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "'"
                        For Each rowData3 As DataRow In dt.Select(Filter)
                            If QuestionClass = PracticeQuestionDefine.QuestionClass.Middle Then
                                '中問
                                If Not AddMiddleQuestionCode.Contains(rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)) Then
                                    AddMiddleQuestionCode.Add(rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode))
                                    Dim Filter2 As String = "QUESTIONCLASS = '" & QuestionClass & "' AND MAINCODE ='" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) & "'"
                                    For Each rowData As DataRow In _PracticeQuestionListTbl.Select(Filter2)
                                        Dim QuestionCodeDefine As New QuestionCodeDefine
                                        QuestionCodeDefine.QuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                        QuestionCodeDefine.MiddleQuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                        wkList.Add(Num, QuestionCodeDefine)
                                        Num += 1
                                    Next
                                End If
                            Else
                                '小問
                                Dim QuestionCodeDefine As New QuestionCodeDefine
                                QuestionCodeDefine.QuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                QuestionCodeDefine.MiddleQuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                wkList.Add(Num, QuestionCodeDefine)
                                Num += 1
                            End If
                        Next
                    Next
                Next

                If Not blnIncorrectAnswerFlg AndAlso QuestionList.Count = 0 Then
                    QuestionList = wkList
                Else
                    Dim wkMarge As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
                    Num = 0
                    For Each key1 As Integer In QuestionList.Keys
                        For Each key2 As Integer In wkList.Keys
                            If QuestionList.Item(key1).QuestionCode = wkList.Item(key2).QuestionCode Then
                                wkMarge.Add(Num, QuestionList.Item(key1))
                                Num += 1
                                Exit For
                            End If
                        Next
                    Next
                    QuestionList = wkMarge
                End If
            Else
                QuestionList.Clear()
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 未演習の問題コードリスト取得
    ''' </summary>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <param name="QuestionClass">問題種別</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNotPractice(ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine), Optional ByVal QuestionClass As QuestionClass = QuestionClass.Small) As Boolean
        Dim blnRet As Boolean = True
        Dim filterExpression As String = ""
        Dim wkList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim Num As Integer = 0
        Dim ds As New DataSet
        Dim AddMiddleQuestionCode As New List(Of String)

        Try
            If Not IsNothing(_SerialResultDetailTbl) Then
                Dim dt As DataTable = _SerialResultDetailTbl.DefaultView.ToTable(True, "QUESTIONCODE")
                ds.Tables.Add(_PracticeQuestionListTbl.Copy)
                ds.Tables.Add(_QuestionCollectionTbl.Copy)
                ds.Tables.Add(dt.Copy)

                Dim dataRel As DataRelation = ds.Relations.Add("REL1", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode), False)

                'filterExpression = "QUESTIONCLASS = '" & QuestionClass & "' AND STATE = '0'"
                filterExpression = "QUESTIONCLASS = '" & QuestionClass & "'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(filterExpression)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        Dim Filter As String = "QUESTIONCODE = '" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "'"
                        Dim rowDatas() As DataRow = dt.Select(Filter)
                        If rowDatas.Count = 0 Then
                            If QuestionClass = PracticeQuestionDefine.QuestionClass.Middle _
                                    AndAlso rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) <> rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) Then
                                '中問
                                If Not AddMiddleQuestionCode.Contains(rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)) Then
                                    AddMiddleQuestionCode.Add(rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode))
                                    Dim Filter2 As String = "QUESTIONCLASS = '" & QuestionClass & "' AND MAINCODE ='" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) & "'"
                                    For Each rowData As DataRow In _PracticeQuestionListTbl.Select(Filter2)
                                        Dim QuestionCodeDefine As New QuestionCodeDefine
                                        QuestionCodeDefine.QuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                        QuestionCodeDefine.MiddleQuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                        wkList.Add(Num, QuestionCodeDefine)
                                        Num += 1
                                    Next
                                End If
                            ElseIf QuestionClass = PracticeQuestionDefine.QuestionClass.Small Then
                                '小問
                                Dim QuestionCodeDefine As New QuestionCodeDefine
                                QuestionCodeDefine.QuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                QuestionCodeDefine.MiddleQuestionCode = rowData1.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                wkList.Add(Num, QuestionCodeDefine)
                                Num += 1
                            End If
                        End If
                    Next
                Next

                If QuestionList.Count = 0 Then
                    QuestionList = wkList
                Else
                    Dim wkMarge As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
                    Num = 0
                    For Each key1 As Integer In QuestionList.Keys
                        For Each key2 As Integer In wkList.Keys
                            If QuestionList.Item(key1).QuestionCode = wkList.Item(key2).QuestionCode Then
                                wkMarge.Add(Num, QuestionList.Item(key1))
                                Num += 1
                                Exit For
                            End If
                        Next
                    Next
                    QuestionList = wkMarge
                End If
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 中問演習問題コードリスト取得
    ''' </summary>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMiddlePracticeQuestion(ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine)) As Boolean
        Dim blnRet As Boolean = True
        Dim num As Integer = 0
        Dim filterExpression As String = ""
        Dim ds As New DataSet

        Try
            ds.Tables.Add(_PracticeQuestionListTbl.Copy)
            ds.Tables.Add(_QuestionCollectionTbl.Copy)
            Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.QuestionCollection.ColumnIndex.QuestionCode), False)

            'filterExpression = "QUESTIONCLASS = '2' AND STATE = '0'"
            filterExpression = "QUESTIONCLASS = '2'"
            For Each rowData As DataRow In ds.Tables(0).Select(filterExpression)
                For Each rowData2 As DataRow In rowData.GetChildRows(dataRel)
                    Dim QuestionCodeDefine As New QuestionCodeDefine
                    QuestionCodeDefine.QuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                    QuestionCodeDefine.MiddleQuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                    QuestionList.Add(num, QuestionCodeDefine)
                    num += 1
                Next
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 問題コード選択
    ''' </summary>
    ''' <param name="wkList">選択元問題コードリスト</param>
    ''' <param name="QuestionList">選択後問題コードリスト</param>
    ''' <param name="TestCount">出題数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectQuestionList(ByVal wkList As Generic.Dictionary(Of Integer, QuestionCodeDefine), ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine), ByVal TestCount As Integer) As Boolean
        Dim blnRet As Boolean = True
        Dim Codes As Generic.List(Of QuestionCodeDefine) = Nothing
        Dim Idx As Integer = 0
        Dim QuestionCode As QuestionCodeDefine = Nothing

        Try
            '問題コードリスト
            Codes = wkList.Values.ToList
            'ランダムに出題数分、問題コードを取得する
            Dim r As Random = New Random
            For i As Integer = 0 To Integer.Parse(TestCount) - 1
                'ランダムにIndexを取得
                Idx = r.Next(0, Codes.Count - 1)
                '問題コード取得
                QuestionCode = Codes(Idx)
                '問題コード追加
                QuestionList.Add(i, QuestionCode)
                '問題コードリストから問題コード削除
                Codes.Remove(QuestionCode)
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 逐次演習履歴確認用データ取得
    ''' </summary>
    ''' <param name="dt">カテゴリーDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetConfirmPracticeQuestionHistory(ByVal dt As DataTable) As Boolean
        Dim blnRet As Boolean = True

        Try
            '逐次演習履歴確認用小問履歴DataTable作成
            blnRet = CreateSamllQuestionHistoryDataTable()
            '逐次演習履歴確認用中問履歴DataTable作成
            If blnRet Then blnRet = CreateMiddleQuestionHistoryDataTable()
            '演習回数取得
            If blnRet Then blnRet = GetPracticeCount()
            '演習時間取得
            If blnRet Then blnRet = GetPracticeTime()
            '逐次演習履歴確認用小問履歴データ取得
            If blnRet Then blnRet = GetSamllQuestionHistory(dt)
            '逐次演習履歴確認用中問履歴データ取得
            If blnRet Then blnRet = GetMiddleQuestionHistory()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 逐次演習履歴確認用小問履歴DataTable作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateSamllQuestionHistoryDataTable() As Boolean
        Dim blnRet As Boolean = True

        Try
            'インスタンス生成
            _SamllQuestionHistoryTbl = New DataTable

            'フィールド追加
            With _SamllQuestionHistoryTbl.Columns
                '分野名
                .Add("CategoryName", GetType(String))
                '大分類名
                .Add("LargeCategoryName", GetType(String))
                '中分類名
                .Add("MiddleCategoryName", GetType(String))
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
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 逐次演習履歴確認用中問履歴DataTable作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateMiddleQuestionHistoryDataTable() As Boolean
        Dim blnRet As Boolean = True

        Try
            'インスタンス生成
            _MiddleQuestionHistoryTbl = New DataTable

            With _MiddleQuestionHistoryTbl.Columns
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
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 逐次演習履歴確認用演習回数取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPracticeCount() As Boolean
        Dim blnRet As Boolean = True
        Dim filter As String = ""

        Try
            '初期化
            _PracticeCount = 0
            If Not IsNothing(_SerialResultHeaderTbl) Then
                For Each rowData As DataRow In _SerialResultHeaderTbl.Rows
                    If _PracticeCount <= rowData.Item(Common.SerialResultHeader.ColumnIndex.TestCount) Then
                        _PracticeCount = rowData.Item(Common.SerialResultHeader.ColumnIndex.TestCount)
                    End If
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
    ''' 逐次演習履歴確認用演習時間(分)取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPracticeTime() As Boolean
        Dim blnRet As Boolean = True
        Dim hour As Integer = 0
        Dim minute As Integer = 0
        Dim second As Integer = 0

        Try
            '初期化
            _PracticeTime = 0
            If Not IsNothing(_SerialResultHeaderTbl) Then
                For Each rowData As DataRow In _SerialResultHeaderTbl.Rows
                    Dim wkBuff() As String = rowData.Item(Common.SerialResultHeader.ColumnIndex.TestTime).ToString.Split(":")
                    hour += Integer.Parse(wkBuff(0))
                    minute += Integer.Parse(wkBuff(1))
                    second += Integer.Parse(wkBuff(2))
                Next
                _PracticeTime = (hour * 60) + minute
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
    ''' 逐次演習履歴確認用小問履歴データ取得
    ''' </summary>
    ''' <param name="dt">カテゴリーDataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSamllQuestionHistory(ByVal dt As DataTable) As Boolean
        Dim blnRet As Boolean = True
        Dim filter As String = ""
        Dim ds As New DataSet
        Dim QuestionCount As Integer = 0
        Dim CorrectAnswerCount As Integer = 0
        Dim AccuracyRate As String = "0.0"
        Dim wkData As DataRow = Nothing

        Try
            For Each rowData As DataRow In dt.Rows
                If IsNothing(wkData) Then wkData = rowData
                If Not IsNothing(wkData) AndAlso wkData.Item(CategoryDefine.ColumnIndex.MiddleCategoryId) <> rowData.Item(CategoryDefine.ColumnIndex.MiddleCategoryId) Then
                    '逐次演習履歴確認用小問履歴DataTableに追加
                    Dim newData As DataRow = _SamllQuestionHistoryTbl.NewRow
                    newData.Item(SmallHistTblIndex.CategoryName) = wkData.Item(CategoryDefine.ColumnIndex.CategoryName)
                    newData.Item(SmallHistTblIndex.LargeCategoryName) = wkData.Item(CategoryDefine.ColumnIndex.LargeCategoryName)
                    newData.Item(SmallHistTblIndex.MiddleCategoryName) = wkData.Item(CategoryDefine.ColumnIndex.MiddleCategoryName)
                    newData.Item(SmallHistTblIndex.QuestionCount) = QuestionCount
                    newData.Item(SmallHistTblIndex.CorrectAnswerCount) = CorrectAnswerCount
                    If QuestionCount > 0 Then
                        AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                    End If
                    newData.Item(SmallHistTblIndex.AccuracyRate) = AccuracyRate
                    _SamllQuestionHistoryTbl.Rows.Add(newData)
                    '初期化
                    QuestionCount = 0
                    CorrectAnswerCount = 0
                    AccuracyRate = "0.0"
                    wkData = rowData
                End If
                If Not IsNothing(_SerialResultDetailTbl) Then
                    'filter = "QUESTIONCLASS = '1' AND CATEGORYID = '" & rowData.Item(CategoryDefine.ColumnIndex.GroupId) & "' AND STATE = '0'"
                    filter = "QUESTIONCLASS = '1' AND CATEGORYID = '" & rowData.Item(CategoryDefine.ColumnIndex.GroupId) & "'"
                    For Each rowData1 As DataRow In _PracticeQuestionListTbl.Select(filter)
                        Dim filter2 As String = "QUESTIONCODE = '" & rowData1.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode) & "'"
                        For Each rowData2 As DataRow In _SerialResultDetailTbl.Select(filter2)
                            If rowData2.Item(Common.SerialResultDetail.ColumnIndex.ErrAta) = "1" Then
                                '正解数
                                CorrectAnswerCount += 1
                            End If
                            '問題数
                            QuestionCount += 1
                        Next
                    Next
                End If
            Next
            '最後のデータが設定する
            Dim endData As DataRow = _SamllQuestionHistoryTbl.NewRow
            endData.Item(SmallHistTblIndex.CategoryName) = wkData.Item(CategoryDefine.ColumnIndex.CategoryName)
            endData.Item(SmallHistTblIndex.LargeCategoryName) = wkData.Item(CategoryDefine.ColumnIndex.LargeCategoryName)
            endData.Item(SmallHistTblIndex.MiddleCategoryName) = wkData.Item(CategoryDefine.ColumnIndex.MiddleCategoryName)
            endData.Item(SmallHistTblIndex.QuestionCount) = QuestionCount
            endData.Item(SmallHistTblIndex.CorrectAnswerCount) = CorrectAnswerCount
            If QuestionCount > 0 Then
                AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
            End If
            endData.Item(SmallHistTblIndex.AccuracyRate) = AccuracyRate
            _SamllQuestionHistoryTbl.Rows.Add(endData)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 逐次演習履歴確認用中問履歴データ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMiddleQuestionHistory() As Boolean
        Dim blnRet As Boolean = True
        Dim ds As New DataSet
        Dim filter As String = ""
        Dim QuestionCount As Integer = 0
        Dim CorrectAnswerCount As Integer = 0
        Dim AccuracyRate As String = "0.0"

        Try
            If Not IsNothing(_SerialResultDetailTbl) Then
                ds.Tables.Add(_PracticeQuestionListTbl.Copy)
                ds.Tables.Add(_SerialResultDetailTbl.Copy)
                Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), ds.Tables(1).Columns(Common.SerialResultDetail.ColumnIndex.QuestionCode), False)

                filter = "QUESTIONCLASS = '2'"
                For Each rowData1 As DataRow In ds.Tables(0).Select(filter)
                    For Each rowData2 As DataRow In rowData1.GetChildRows(dataRel)
                        If rowData2.Item(Common.SerialResultDetail.ColumnIndex.ErrAta) = "1" Then
                            '正解数取得
                            CorrectAnswerCount += 1
                        End If
                        '演習問題数取得
                        QuestionCount += 1
                    Next
                Next
                '正解率取得
                If QuestionCount > 0 Then
                    AccuracyRate = (Math.Floor((CorrectAnswerCount / QuestionCount) * 1000) / 10).ToString("0.0")
                End If
            End If

            Dim rowData As DataRow = _MiddleQuestionHistoryTbl.NewRow
            rowData.Item(MiddleHistTblIndex.QuestionCount) = QuestionCount
            rowData.Item(MiddleHistTblIndex.CorrectAnswerCount) = CorrectAnswerCount
            rowData.Item(MiddleHistTblIndex.AccuracyRate) = AccuracyRate
            _MiddleQuestionHistoryTbl.Rows.Add(rowData)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 総合テスト履歴問題コードリスト取得
    ''' </summary>
    ''' <param name="dt">問別正誤一覧テーブル</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSynthesisResultPracticeQuestion(ByVal dt As DataTable) As Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim SynthesisResultPracticeQuestionList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim num As Integer = 0
        Dim ds As New DataSet
        Dim MainCodeList As New List(Of String)

        Try
            ds.Tables.Add(dt.Copy)
            ds.Tables.Add(_PracticeQuestionListTbl.Copy)
            Dim dataRel As DataRelation = ds.Relations.Add("REL", ds.Tables(0).Columns(SynthesisResultDefine.SynthesisTrueFalseTblIndex.QuestionCode), ds.Tables(1).Columns(Common.PracticeQuestionList.ColumnIndex.QuestinCode), False)

            For Each rowData As DataRow In ds.Tables(0).Rows
                For Each rowData2 As DataRow In rowData.GetChildRows(dataRel)
                    If rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) <> "" Then
                        Dim filter As String = "QUESTIONCODE = '" & rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode) & "' AND QUESTIONCODE = MAINCODE"
                        Dim QuestionCodeDefine As QuestionCodeDefine
                        For Each rowData3 As DataRow In ds.Tables(1).Select(filter)
                            If Not MainCodeList.Contains(rowData3.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)) Then
                                QuestionCodeDefine = New QuestionCodeDefine
                                QuestionCodeDefine.QuestionCode = rowData3.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                                QuestionCodeDefine.MiddleQuestionCode = rowData3.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                                'リスト追加
                                SynthesisResultPracticeQuestionList.Add(num, QuestionCodeDefine)
                                num += 1
                                MainCodeList.Add(rowData3.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode))
                            End If
                        Next
                        QuestionCodeDefine = New QuestionCodeDefine
                        QuestionCodeDefine.QuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                        QuestionCodeDefine.MiddleQuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                        'リスト追加
                        SynthesisResultPracticeQuestionList.Add(num, QuestionCodeDefine)
                        num += 1
                    Else
                        Dim QuestionCodeDefine As New QuestionCodeDefine
                        QuestionCodeDefine.QuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                        QuestionCodeDefine.MiddleQuestionCode = rowData2.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                        SynthesisResultPracticeQuestionList.Add(num, QuestionCodeDefine)
                        num += 1
                    End If
                Next
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Return SynthesisResultPracticeQuestionList
    End Function

    '2012/06/11 CST ADD S
    ''' <summary>
    ''' 並び替えた問題コードリスト取得
    ''' </summary>
    ''' <param name="QuestionList">問題コードリスト</param>
    ''' <param name="QuestionClass"></param>
    ''' <returns></returns>
    ''' <remarks>並び替えた問題コードリスト取得</remarks>
    Private Function GetReshuffleSmallPracticeQuestionList(ByRef QuestionList As Generic.Dictionary(Of Integer, QuestionCodeDefine), Optional ByVal QuestionClass As QuestionClass = QuestionClass.Small) As Boolean
        Dim blnRet As Boolean = True
        Dim wkList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)
        Dim Num As Integer = 0
        Dim index As Integer
        Dim count As Integer = QuestionList.Keys.Count
        Dim mainCode As String
        Dim filter As String
        Dim delMiddleQuestionKey As New List(Of String)

        Try
            If QuestionList.Count = 0 Then
                QuestionList = wkList
            Else
                Num = 0
                If QuestionClass = PracticeQuestionDefine.QuestionClass.Small Then
                    '小問
                    For i As Integer = 0 To count - 1
                        index = CBTCommon.Utility.RollDiceLarge(QuestionList.Keys.Count)
                        wkList.Add(Num, QuestionList.Item(QuestionList.Keys(index)))
                        QuestionList.Remove(QuestionList.Keys(index))
                        Num += 1
                    Next
                Else
                    '中問
                    For i As Integer = 0 To (count / 5) - 1
                        index = CBTCommon.Utility.RollDiceLarge(QuestionList.Keys.Count / 5)
                        mainCode = QuestionList.Item(QuestionList.Keys(index * 5)).MiddleQuestionCode
                        filter = "QUESTIONCLASS = '" & QuestionClass & "' AND MAINCODE ='" & mainCode & "'"
                        For Each rowData As DataRow In _PracticeQuestionListTbl.Select(filter, "MIDDLEQUESTIONINDEX")
                            Dim QuestionCodeDefine As New QuestionCodeDefine
                            QuestionCodeDefine.QuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
                            QuestionCodeDefine.MiddleQuestionCode = rowData.Item(Common.PracticeQuestionList.ColumnIndex.MainCode)
                            wkList.Add(Num, QuestionCodeDefine)
                            Num += 1
                        Next
                        For j As Integer = 0 To QuestionList.Keys.Count - 1
                            If mainCode = QuestionList.Item(QuestionList.Keys(j)).MiddleQuestionCode Then
                                delMiddleQuestionKey.Add(QuestionList.Keys(j))
                            End If
                        Next
                        For Each key As String In delMiddleQuestionKey
                            QuestionList.Remove(key)
                        Next
                    Next
                End If
                QuestionList = wkList
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        Finally
        End Try
        Return blnRet
    End Function
    '2012/06/11 CST ADD E
#End Region

End Class
