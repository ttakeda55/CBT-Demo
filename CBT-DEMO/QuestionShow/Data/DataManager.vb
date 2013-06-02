Imports CST.CBT.eIPSTA.Common

''' <summary>
''' 受講者機能で使用するデータを管理するクラス
''' </summary>
''' <remarks></remarks>
Public Class DataManager

#Region "----- 列挙子 -----"
    ''' <summary>合否基準評価点</summary>
    Public Enum JudgeBasePoint As Integer
        ''' <summary>カテゴリ合否基準評価点</summary>
        CategoryPoint = 300
        ''' <summary>総合合否基準評価点</summary>
        TotalPoint = 600
    End Enum

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>DataManagerインスタンス</summary>
    Private Shared _instance As New DataManager
    ''' <summary>団体コード</summary>
    Private _GroupCode As String = ""
    ''' <summary>団体名</summary>
    Private _GroupName As String = ""
    ''' <summary>コース名</summary>
    Private _Course As String = ""
    ''' <summary>ユーザーID</summary>
    Private _UserId As String = ""
    ''' <summary>ユーザー名</summary>
    Private _UserName As String = ""
    ''' <summary>受験回数</summary>
    Private _TestCount As Integer = 0
    ''' <summary>受験日</summary>
    Private _TestDate As String = ""
    ''' <summary>受験時間</summary>
    Private _TestTime As String = ""
    ''' <summary>受験開始日</summary>
    Private _TestStart As String = ""
    ''' <summary>受験終了日</summary>
    Private _TestEnd As String = ""
    ''' <summary>お知らせ</summary>
    Private _Infomation As String = ""
    ''' <summary>問題定義コンテナオブジェクト</summary>
    Public _QuestionDefineContainer As QuestionDefineContainer = Nothing
    ''' <summary>解答データコンテナオブジェクト</summary>
    Public _ResultDataContainer As ResultDataContainer = Nothing
    ''' <summary>個人試験結果ヘッダオブジェクト</summary>
    Private _TestResultHeader As TestResultHeader = Nothing
    ''' <summary>個人試験結果詳細オブジェクト</summary>
    Private _TestResultDetail As TestResultDetail = Nothing

    ''' <summary>受験者ファイル名</summary>
    Private _StudentFileName As String = String.Empty

    ''' <summary>ログアウト中かどうか</summary>
    Private _IsLogouting As Boolean = False

#End Region

#Region "----- プロパティ -----"

    ''' <summary>団体コードの取得</summary>
    Public ReadOnly Property GroupCode As String
        Get
            Return _GroupCode
        End Get
    End Property

    ''' <summary>団体名の取得</summary>
    Public ReadOnly Property GroupName As String
        Get
            Return _GroupName
        End Get
    End Property

    ''' <summary>コース名の取得</summary>
    Public ReadOnly Property Course As String
        Get
            Return _Course
        End Get
    End Property

    ''' <summary>ユーザーIDの取得</summary>
    Public ReadOnly Property UserId As String
        Get
            Return _UserId
        End Get
    End Property

    ''' <summary>ユーザー名の取得</summary>
    Public ReadOnly Property UserName As String
        Get
            Return _UserName
        End Get
    End Property

    ''' <summary>受験回数の取得</summary>
    Public ReadOnly Property TestCount As Integer
        Get
            Return _TestCount
        End Get
    End Property

    ''' <summary>受験日の設定</summary>
    Public WriteOnly Property TestDate As String
        Set(ByVal value As String)
            _TestDate = value
        End Set
    End Property

    ''' <summary>受験時間の設定</summary>
    Public WriteOnly Property TestTime As String
        Set(ByVal value As String)
            _TestTime = value
        End Set
    End Property

    ''' <summary>受験開始日の取得</summary>
    Public ReadOnly Property TestSatrt As String
        Get
            Return _TestStart
        End Get
    End Property

    ''' <summary>受験終了日の取得</summary>
    Public ReadOnly Property TestEnd As String
        Get
            Return _TestEnd
        End Get
    End Property

    ''' <summary>お知らせの取得・設定</summary>
    Public Property Infomation As String
        Get
            Return _Infomation
        End Get
        Set(ByVal value As String)
            _Infomation = value
        End Set
    End Property

    ''' <summary>問題定義コンテナオブジェクトの取得</summary>
    Public ReadOnly Property QuestionDefineContainer As QuestionDefineContainer
        Get
            Return _QuestionDefineContainer
        End Get
    End Property

    ''' <summary>解答データコンテナオブジェクトの取得</summary>
    Public ReadOnly Property ResultDataContainer As ResultDataContainer
        Get
            Return _ResultDataContainer
        End Get
    End Property

    ''' <summary>個人試験結果詳細オブジェクトの取得</summary>
    Public ReadOnly Property TestResultDetail As TestResultDetail
        Get
            Return _TestResultDetail
        End Get
    End Property

    ''' <summary>個人試験結果ヘッダオブジェクトの取得</summary>
    Public ReadOnly Property TestResultHeader As TestResultHeader
        Get
            Return _TestResultHeader
        End Get
    End Property

    ''' <summary>受験者ファイル名の取得</summary>
    Public ReadOnly Property StudentFileName As String
        Get
            Return _StudentFileName
        End Get
    End Property

    ''' <summary>ログアウト中かどうか</summary>
    Public Property IsLogouting As Boolean
        Get
            Return _IsLogouting
        End Get
        Set(ByVal value As Boolean)
            _IsLogouting = value
        End Set
    End Property

#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Protected Sub New()
        _ResultDataContainer = New ResultDataContainer
    End Sub

    ''' <summary>
    ''' インスタンス取得
    ''' </summary>
    ''' <returns>DataManager</returns>
    Public Function GetInstance() As DataManager
        Return _instance
    End Function

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Initialize() As Integer
        Dim errCode As Integer = Constant.ResultCode.NormalEnd

        Try
            '団体ファイル読込
            errCode = ReadGroup()
            '受講者ファイル読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadStudent()
            'Mailファイル読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadMail()
            '問題ファイル読み込み
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadQuestion()
            '個人試験結果ヘッダファイル読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadTestResultHeader()
            '個人試験結果詳細ファイル読込
            If errCode = Constant.ResultCode.NormalEnd Then errCode = ReadTestResultDetail()
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 問題読み込み処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadQuestion() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), String.Format("Question{0}*", Course))
            Select Case questionFileNameList.Length
                Case 0
                    errCode = Constant.ResultCode.QuestionFileNotFoundError
                Case 1
                    Dim questionFileName = questionFileNameList(0)
                    Dim questionDataBankCollection = Serialize.BinaryFileToObject(IO.Path.GetFileName(questionFileName))
                    If questionDataBankCollection Is Nothing Then
                        errCode = Constant.ResultCode.QuestionFileReadError
                    Else
                        _QuestionDefineContainer = QuestionDefineCreator.Create(questionDataBankCollection)
                        If _QuestionDefineContainer Is Nothing Then
                            errCode = Constant.ResultCode.QuestionFileParseError
                        Else
                            CreateDefineFile()  'debug only
                        End If
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
    ''' 団体ファイル読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadGroup() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim groupTbl As DataTable = Nothing

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_GROUP_FILENAME & "*"
            '団体ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If IsNothing(fileNameList) OrElse fileNameList.Length = 0 Then errCode = Constant.ResultCode.GroupFileNotFoundError
            If errCode = Constant.ResultCode.NormalEnd AndAlso fileNameList.Length <> 1 Then errCode = Constant.ResultCode.GroupFileReadError
            If errCode = Constant.ResultCode.NormalEnd Then
                'DataTable取得
                groupTbl = Common.Group.GetAll(IO.Path.GetFileName(fileNameList(0)))
                If groupTbl.Rows.Count >= 1 Then
                    '団体コード取得
                    _GroupCode = groupTbl.Rows(0).Item(Common.Group.ColumnIndex.GroupCode)
                    '団体名取得
                    _GroupName = groupTbl.Rows(0).Item(Common.Group.ColumnIndex.GroupName)
                    'コース名取得
                    _Course = groupTbl.Rows(0).Item(Common.Group.ColumnIndex.Course)
                    '受講開始日取得
                    _TestStart = groupTbl.Rows(0).Item(Common.Group.ColumnIndex.TestStart)
                    '受講終了日取得
                    _TestEnd = groupTbl.Rows(0).Item(Common.Group.ColumnIndex.TestEnd)
                Else
                    errCode = Constant.ResultCode.GroupFileReadError
                End If
            End If
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 受講者ファイル読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadStudent() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim studentTbl As DataTable = Nothing

        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_STUDENT_FILENAME & "*"
            '受講者ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            If IsNothing(fileNameList) OrElse fileNameList.Length = 0 Then errCode = Constant.ResultCode.StudentFileNotFoundError
            If errCode = Constant.ResultCode.NormalEnd AndAlso fileNameList.Length <> 1 Then errCode = Constant.ResultCode.StudentFileReadError
            If errCode = Constant.ResultCode.NormalEnd Then
                'DataTable取得
                studentTbl = Common.Student.GetAll(IO.Path.GetFileName(fileNameList(0)))
                If studentTbl.Rows.Count >= 1 Then
                    'ユーザーID取得
                    _UserId = studentTbl.Rows(0).Item(Common.Student.ColumnIndex.UserId)
                    'ユーザー名取得
                    _UserName = studentTbl.Rows(0).Item(Common.Student.ColumnIndex.Name)
                    '受験回数取得
                    _TestCount = Integer.Parse(studentTbl.Rows(0).Item(Common.Student.ColumnIndex.TestCount))
                    '読み込みを行った受験者ファイル名の登録
                    _StudentFileName = IO.Path.GetFileName(fileNameList(0))
                Else
                    errCode = Constant.ResultCode.StudentFileReadError
                End If
            End If
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' メールファイル読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadMail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Dim sr As IO.StreamReader = Nothing
        Try
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_MAIL_FILENAME & "*"
            'Mailファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), searchPattern)
            'If IsNothing(fileNameList) OrElse fileNameList.Length = 0 Then errCode = Constant.ResultCode.MailFileNotFoundError
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.MailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    'Mailファイル読込
                    sr = New IO.StreamReader(fileNameList(0))
                    '内容を全て読む
                    Dim mailData As String = sr.ReadToEnd
                    If mailData.LastIndexOf(Common.Constant.CST_NEWMAIL) > 0 AndAlso mailData.LastIndexOf(_UserId) = -1 Then
                        _Infomation = "未読のメッセージが1件あります。"
                    End If
                End If
            End If
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        Finally
            If Not IsNothing(sr) Then
                sr.Close()
                sr = Nothing
            End If
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 個人試験結果ヘッダ読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadTestResultHeader() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            'インスタンス生成
            _TestResultHeader = New TestResultHeader
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_TESTHEAD_FILENAME & "*"
            '個人試験結果ヘッダファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath, searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.TestResultHeaderFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    '個人試験結果ヘッダファイル読込
                    If Not _TestResultHeader.ReadXML(IO.Path.GetFileName(fileNameList(0))) Then
                        errCode = Constant.ResultCode.TestResultHeaderFileReadError
                    End If
                End If
            ElseIf _TestCount >= 1 Then
                '再受験の時に個人試験結果ヘッダファイルが存在しないのは不正
                errCode = Constant.ResultCode.TestResultHeaderFileNotFoundError
            End If
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 個人試験結果詳細読込処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Private Function ReadTestResultDetail() As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            'インスタンス生成
            _TestResultDetail = New TestResultDetail
            '検索ファイル名作成
            Dim searchPattern As String = Common.Constant.CST_TESTDETAIL_FILENAME & "*"
            '個人試験結果詳細ファイル取得
            Dim fileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath, searchPattern)
            If Not IsNothing(fileNameList) AndAlso fileNameList.Length > 0 Then
                If fileNameList.Length > 1 Then errCode = Constant.ResultCode.TestResultDetailFileReadError
                If errCode = Constant.ResultCode.NormalEnd Then
                    '個人試験結果詳細ファイル読込
                    If Not _TestResultDetail.ReadXML(IO.Path.GetFileName(fileNameList(0))) Then
                        errCode = Constant.ResultCode.TestResultDetailFileReadError
                    End If
                End If
            ElseIf _TestCount >= 1 Then
                '再受験の時に個人試験結果詳細ファイルが存在しないのは不正
                errCode = Constant.ResultCode.TestResultDetailFileNotFoundError
            End If
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

    ''' <summary>
    ''' 試験結果集計処理
    ''' </summary>
    ''' <returns>正常:True, 異常:False </returns>
    ''' <remarks></remarks>
    Public Function ExecResultSummary() As Boolean
        Dim blnRet As Boolean = True
        Dim resultSummarySystemList As New Generic.Dictionary(Of Integer, ResultSummarySystem)

        Try
            '試験結果明細集計処理
            blnRet = ExecResultSummaryDetail(resultSummarySystemList)
            '試験結果ヘッダ集計処理
            If blnRet Then blnRet = ExecResultSummaryHeader(resultSummarySystemList)
            '試験回数カウントアップ
            If blnRet Then _TestCount += 1
        Catch ex As Exception
            blnRet = False
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 試験結果明細集計処理
    ''' </summary>
    ''' <param name="resultSummarySystemList">系統結果集計データリスト</param>
    ''' <returns>正常:True, 異常:False</returns>
    ''' <remarks></remarks>
    Private Function ExecResultSummaryDetail(ByRef resultSummarySystemList As Generic.Dictionary(Of Integer, ResultSummarySystem)) As Boolean
        Dim blnRet As Boolean = True
        Dim resultSummaryGroup As ResultSummaryGroup = Nothing
        Dim resultSummarySystem As ResultSummarySystem = Nothing
        Dim questionDefine As QuestionDefine = Nothing
        Dim resultData As ResultData = Nothing
        Dim errata As String = ""
        Dim testCount As Integer = _TestCount + 1

        Try
            For Each questionDefine In _QuestionDefineContainer.QuestionDefineMap.Values
                resultSummarySystem = Nothing
                resultSummaryGroup = Nothing
                errata = "0"
                '系統結果集計データリストに存在するかチェック
                If Not resultSummarySystemList.ContainsKey(questionDefine.ParentCategoryID) Then
                    resultSummarySystem = New ResultSummarySystem
                    'カテゴリID設定
                    resultSummarySystem.CategoryId = questionDefine.ParentCategoryID.ToString
                    '系統結果集計データリストに追加
                    resultSummarySystemList.Add(questionDefine.ParentCategoryID, resultSummarySystem)
                    resultSummarySystem = Nothing
                End If
                '系統結果集計データオブジェクト取得
                resultSummarySystem = resultSummarySystemList.Item(questionDefine.ParentCategoryID)
                '系統結果集計データオブジェクト問題数カウントアップ
                resultSummarySystem.QuestionCount += 1

                '系統結果集計データオブジェクトの分類結果集計データリストに存在するかチェック
                If Not resultSummarySystem.GetResultSummaryGroupList.ContainsKey(questionDefine.CategoryID) Then
                    resultSummaryGroup = New ResultSummaryGroup
                    'カテゴリID設定
                    resultSummaryGroup.CategoryId = questionDefine.CategoryID.ToString
                    '分類結果集計データリストに追加
                    resultSummarySystem.GetResultSummaryGroupList.Add(questionDefine.CategoryID, resultSummaryGroup)
                    resultSummaryGroup = Nothing
                End If
                '分類結果集計データオブジェクト取得
                resultSummaryGroup = resultSummarySystem.GetResultSummaryGroupList.Item(questionDefine.CategoryID)
                '分類結果集計データオブジェクト問題数カウントアップ
                resultSummaryGroup.QuestionCount += 1

                '解答データオブジェクト取得
                resultData = _ResultDataContainer.Item(questionDefine.QuestionNumber)
                If Not IsNothing(resultData) Then
                    '解答が正解かチェック
                    If IIf(testCount = 1, questionDefine.FirstAnswer, questionDefine.SecondAnswer).ToString = resultData.Answer Then
                        '系統結果集計データオブジェクト正解数カウントアップ
                        resultSummarySystem.AnswerCount += 1
                        '分類結果集計データオブジェクト正解数カウントアップ
                        resultSummaryGroup.AnswerCount += 1
                        '正誤設定
                        errata = "1"
                    End If
                End If

                '個人試験結果詳細データ作成
                Dim detailDatas(TestResultDetail.ColumnIndex.Max - 1) As String
                detailDatas(TestResultDetail.ColumnIndex.UserId) = _UserId
                detailDatas(TestResultDetail.ColumnIndex.TestCount) = testCount.ToString
                detailDatas(TestResultDetail.ColumnIndex.QuestionNo) = questionDefine.QuestionNumber.ToString
                detailDatas(TestResultDetail.ColumnIndex.Category1) = questionDefine.LargeCategoryName
                detailDatas(TestResultDetail.ColumnIndex.Category2) = questionDefine.MiddleCategoryName
                detailDatas(TestResultDetail.ColumnIndex.QuestionTheme) = questionDefine.QuestionTheme
                If Not IsNothing(resultData) Then
                    If testCount = 1 Then
                        '初回受験
                        detailDatas(TestResultDetail.ColumnIndex.Answer) = resultData.Answer
                        detailDatas(TestResultDetail.ColumnIndex.DisplyAnswer) = ""
                    Else
                        '再受験
                        Dim testResultDetailDataRow As DataRow = _TestResultDetail.GetDataRow(1, questionDefine.QuestionNumber)
                        '初回受験解答設定
                        If Not IsNothing(testResultDetailDataRow) Then
                            detailDatas(TestResultDetail.ColumnIndex.Answer) = testResultDetailDataRow.Item(TestResultDetail.ColumnIndex.Answer)
                        Else
                            detailDatas(TestResultDetail.ColumnIndex.Answer) = ""
                        End If
                        detailDatas(TestResultDetail.ColumnIndex.DisplyAnswer) = resultData.Answer
                    End If
                Else
                    If testCount = 1 Then
                        '初回受験
                        detailDatas(TestResultDetail.ColumnIndex.Answer) = ""
                        detailDatas(TestResultDetail.ColumnIndex.DisplyAnswer) = ""
                    Else
                        '再受験
                        Dim testResultDetailDataRow As DataRow = _TestResultDetail.GetDataRow(1, questionDefine.QuestionNumber)
                        '初回受験解答設定
                        If Not IsNothing(testResultDetailDataRow) Then
                            detailDatas(TestResultDetail.ColumnIndex.Answer) = testResultDetailDataRow.Item(TestResultDetail.ColumnIndex.Answer)
                        Else
                            detailDatas(TestResultDetail.ColumnIndex.Answer) = ""
                        End If
                        detailDatas(TestResultDetail.ColumnIndex.DisplyAnswer) = ""
                    End If
                End If
                detailDatas(TestResultDetail.ColumnIndex.Errata) = errata
                '個人試験結果詳細オブジェクト結果追加
                If Not _TestResultDetail.Add(detailDatas) Then
                    '追加エラー
                    Dim errCode As String = "E" & Constant.ResultCode.AddTestResultDetail
                    Common.Message.MessageShow(errCode)
                    blnRet = False
                    Exit For
                End If
            Next
        Catch ex As Exception
            blnRet = False
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 試験結果ヘッダ集計処理
    ''' </summary>
    ''' <param name="resultSummarySystemList">系統結果集計データリスト</param>
    ''' <returns>正常:True, 異常:False</returns>
    ''' <remarks></remarks>
    Private Function ExecResultSummaryHeader(ByVal resultSummarySystemList As Generic.Dictionary(Of Integer, ResultSummarySystem)) As Boolean
        Dim blnRet As Boolean = True
        Dim resultSummaryGroup As ResultSummaryGroup = Nothing
        Dim resultSummarySystem As ResultSummarySystem = Nothing
        Dim headerDatas(Common.TestResultHeader.ColumnIndex.Max - 1) As String
        Dim questionCount As Integer = 0
        Dim answerCount As Integer = 0
        Dim result As Boolean = True
        Dim testCount As Integer = _TestCount + 1

        Try
            'ユーザーID設定
            headerDatas(TestResultHeader.ColumnIndex.UserId) = _UserId
            '試験回数設定
            headerDatas(TestResultHeader.ColumnIndex.TestCount) = testCount
            '受験日
            headerDatas(TestResultHeader.ColumnIndex.TestDate) = _TestDate
            '受験時間
            headerDatas(TestResultHeader.ColumnIndex.TestTime) = _TestTime
            '評価点の初期化
            For i As Integer = TestResultHeader.ColumnIndex.CategoryPoint1_A To TestResultHeader.ColumnIndex.CategoryPoint2_I
                headerDatas(i) = "0"
            Next
            For Each resultSummarySystem In resultSummarySystemList.Values
                '総合問題数設定
                questionCount += resultSummarySystem.QuestionCount
                '総合正解数設定
                answerCount += resultSummarySystem.AnswerCount
                '大分類評価点設定
                Select Case resultSummarySystem.CategoryId
                    Case 1
                        headerDatas(TestResultHeader.ColumnIndex.CategoryPoint1_A) = resultSummarySystem.GetGradePoint.ToString
                    Case 5
                        headerDatas(TestResultHeader.ColumnIndex.CategoryPoint1_B) = resultSummarySystem.GetGradePoint.ToString
                    Case 9
                        headerDatas(TestResultHeader.ColumnIndex.CategoryPoint1_C) = resultSummarySystem.GetGradePoint.ToString
                End Select
                '系統単位での合否判定
                If resultSummarySystem.GetGradePoint < JudgeBasePoint.CategoryPoint Then result = False
                '中分類評価点設定
                For Each resultSummaryGroup In resultSummarySystem.GetResultSummaryGroupList.Values
                    Select Case resultSummaryGroup.CategoryId
                        Case 2
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_A) = resultSummaryGroup.GetGradePoint.ToString
                        Case 3
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_B) = resultSummaryGroup.GetGradePoint.ToString
                        Case 4
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_C) = resultSummaryGroup.GetGradePoint.ToString
                        Case 6
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_D) = resultSummaryGroup.GetGradePoint.ToString
                        Case 7
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_E) = resultSummaryGroup.GetGradePoint.ToString
                        Case 8
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_F) = resultSummaryGroup.GetGradePoint.ToString
                        Case 10
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_G) = resultSummaryGroup.GetGradePoint.ToString
                        Case 11
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_H) = resultSummaryGroup.GetGradePoint.ToString
                        Case 12
                            headerDatas(TestResultHeader.ColumnIndex.CategoryPoint2_I) = resultSummaryGroup.GetGradePoint.ToString
                    End Select
                Next
            Next

            '総合評価点算出(小数点切捨て)
            headerDatas(TestResultHeader.ColumnIndex.TotalPoints) = Math.Floor((answerCount / questionCount) * 1000)
            '総合合否判定
            If result Then
                If Integer.Parse(headerDatas(TestResultHeader.ColumnIndex.TotalPoints)) >= JudgeBasePoint.TotalPoint Then
                    '合格
                    headerDatas(TestResultHeader.ColumnIndex.Result) = "1"
                Else
                    '不合格
                    headerDatas(TestResultHeader.ColumnIndex.Result) = "0"
                End If
            Else
                '不合格
                headerDatas(TestResultHeader.ColumnIndex.Result) = "0"
            End If
            '個人試験結果ヘッダオブジェクト結果追加
            If Not _TestResultHeader.Add(headerDatas) Then
                '追加エラー
                Dim errCode As String = "E" & Constant.ResultCode.AddTestResultHeader
                Common.Message.MessageShow(errCode)
                blnRet = False
            End If
        Catch ex As Exception
            blnRet = False
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' デバッグ用ファイル作成処理
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.Conditional("Debug")>
    Public Sub CreateDefineFile()
        Try
            Dim filePath = Common.Constant.GetTempPath() & "DefineQuestion.csv"
            Dim sw As New System.IO.StreamWriter(filePath, False, System.Text.Encoding.GetEncoding("shift_jis"))
            sw.Write(_QuestionDefineContainer.ToString())
            sw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

End Class
