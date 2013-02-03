''' <summary>
''' 試験結果
''' </summary>
''' <remarks></remarks>
Public Class ResultMaster
#Region "----- 列挙体 -----"

#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>逐次演習結果_明細</summary>
    Public Shared _serialResultDetail As New DataTable

    ''' <summary>小テスト結果_明細</summary>
    Public Shared _miniResultDetail As New DataTable

    ''' <summary>総合テスト結果_明細</summary>
    Public Shared _synthesisResultDetail As New DataTable

    ''' <summary>演習問題一覧</summary>
    Public Shared _practiceQuestionList As New DataTable

    ''' <summary>演習問題一覧(結果付与)</summary>
    Public Shared _practiceQuestionResultList As New DataTable

    ''' <summary>演習問題一覧(逐次演習結果付与)</summary>
    Public Shared _practiceQuestionserialResultList As New DataTable

#End Region

#Region "----- コンストラクタ -----"
    Public Sub New()
        '逐次演習結果_明細
        _serialResultDetail = getSerialResultDetail()
        '小テスト結果_明細
        _miniResultDetail = getMiniResultDetail()
        '総合テスト結果_明細
        _synthesisResultDetail = getSynthesisResultDetail()
        '演習問題一覧
        _practiceQuestionList = getPracticeQuestionList()
    End Sub
#End Region

#Region "----- メソッド -----"
#Region "----- 共有メンバ -----"
    ''' <summary>
    ''' 全行取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll() As DataTable
        GetAll = Nothing

        Dim returnDt As New DataTable
        returnDt = getSerialResultDetail.Clone

        returnDt.Merge(_serialResultDetail)
        returnDt.Merge(_miniResultDetail)
        returnDt.Merge(_synthesisResultDetail)

        Return returnDt
    End Function

    ''' <summary>
    ''' 集計取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SumAll() As DataTable
        SumAll = Nothing

        '作成済み
        If _practiceQuestionResultList.Rows.Count > 0 Then
            Return _practiceQuestionResultList
        End If

        _practiceQuestionResultList = _practiceQuestionList.Clone

        Dim resultDt As New DataTable
        resultDt = getSerialResultDetail()

        'カラム追加
        _practiceQuestionList.Columns.Add("PRACTICECOUNT")
        _practiceQuestionList.Columns.Add("CORRECTANSWERRATE")

        Dim KeyUserId(0) As DataColumn
        ''主キー設定
        KeyUserId(0) = _practiceQuestionList.Columns("QUESTIONCODE")
        _practiceQuestionList.PrimaryKey = KeyUserId

        _practiceQuestionResultList = _practiceQuestionList.Clone

        Dim questionCodeKeey As String
        Dim practiceCountNum As Integer
        Dim errataNum As Integer

        For Each row As DataRow In _practiceQuestionList.Rows
            questionCodeKeey = row.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
            practiceCountNum = resultDt.Compute("COUNT(QUESTIONCODE)", "QUESTIONCODE = '" & questionCodeKeey & "'")
            errataNum = resultDt.Compute("COUNT(ERRATA)", "QUESTIONCODE = '" & questionCodeKeey & "' AND ERRATA = '1'")
            row.Item("PRACTICECOUNT") = practiceCountNum.ToString
            row.Item("CORRECTANSWERRATE") = If(practiceCountNum = 0, "0", ((errataNum / practiceCountNum) * 100).ToString("00.0"))
            _practiceQuestionResultList.ImportRow(row)
        Next

        Return _practiceQuestionResultList
    End Function

    ''' <summary>
    ''' 逐次演習集計取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SumSerial() As DataTable
        SumSerial = Nothing

        '作成済み
        If _practiceQuestionserialResultList.Rows.Count > 0 Then
            Return _practiceQuestionserialResultList
        End If

        _practiceQuestionserialResultList = _practiceQuestionList.Clone

        Dim resultDt As New DataTable
        resultDt = _serialResultDetail

        'カラム追加
        _practiceQuestionList.Columns.Add("PRACTICECOUNT")
        _practiceQuestionList.Columns.Add("CORRECTANSWERRATE")

        Dim KeyUserId(0) As DataColumn
        ''主キー設定
        KeyUserId(0) = _practiceQuestionList.Columns("QUESTIONCODE")
        _practiceQuestionList.PrimaryKey = KeyUserId

        _practiceQuestionResultList = _practiceQuestionList.Clone

        Dim questionCodeKeey As String
        Dim practiceCountNum As Integer
        Dim errataNum As Integer
        Dim CorrectAnswerRate As Single

        For Each row As DataRow In _practiceQuestionList.Rows
            questionCodeKeey = row.Item(Common.PracticeQuestionList.ColumnIndex.QuestinCode)
            practiceCountNum = resultDt.Compute("COUNT(QUESTIONCODE)", "QUESTIONCODE = '" & questionCodeKeey & "'")
            errataNum = resultDt.Compute("COUNT(ERRATA)", "QUESTIONCODE = '" & questionCodeKeey & "' AND ERRATA = '1'")
            row.Item("PRACTICECOUNT") = practiceCountNum.ToString
            If practiceCountNum = 0 Then
                row.Item("CORRECTANSWERRATE") = "0.0"
            Else
                CorrectAnswerRate = errataNum / practiceCountNum
                row.Item("CORRECTANSWERRATE") = Format((System.Math.Floor((errataNum / practiceCountNum) * 1000) / 10), "0.0")
            End If
            'row.Item("CORRECTANSWERRATE") = If(practiceCountNum = 0, "0", ((errataNum / practiceCountNum) * 100).ToString("00.0"))
            _practiceQuestionResultList.ImportRow(row)
        Next

        Return _practiceQuestionResultList
    End Function
#End Region

#Region "----- 非共有メンバ -----"

    ''' <summary>
    ''' 逐次演習結果_明細
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getSerialResultDetail() As DataTable
        getSerialResultDetail = Nothing
        Dim serialResultDetailDt As New DataTable
        Common.XmlSchema.GetSerialResultDetailSchema(serialResultDetailDt)

        For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath,
                                                             Common.Constant.CST_SERIALRESULTDETAIL_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)
            serialResultDetailDt.Merge(Common.Serialize.XmlToDataTableFullPath(fileName))
        Next
        Return serialResultDetailDt
    End Function

    ''' <summary>
    ''' 小テスト結果_明細
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getMiniResultDetail() As DataTable
        getMiniResultDetail = Nothing
        Dim miniResultDetailDt As New DataTable
        Common.XmlSchema.GetMiniResultDetailSchema(miniResultDetailDt)

        For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath,
                                                             Common.Constant.CST_MINIRESULTDETAIL_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)
            miniResultDetailDt.Merge(Common.Serialize.XmlToDataTableFullPath(fileName))
        Next
        Return miniResultDetailDt
    End Function

    ''' <summary>
    ''' 総合テスト結果_明細
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getSynthesisResultDetail() As DataTable
        getSynthesisResultDetail = Nothing
        Dim synthesisResultDetailDt As New DataTable
        Common.XmlSchema.GetSynthesisResultDetailSchema(synthesisResultDetailDt)

        For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath,
                                                             Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)
            synthesisResultDetailDt.Merge(Common.Serialize.XmlToDataTableFullPath(fileName))
        Next
        Return synthesisResultDetailDt
    End Function

    ''' <summary>
    ''' 演習問題一覧
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getPracticeQuestionList() As DataTable
        getPracticeQuestionList = Nothing
        Dim practiceQuestionListDt As New DataTable
        practiceQuestionListDt =
            Common.PracticeQuestionList.GetAll(Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
        Return practiceQuestionListDt
    End Function

#End Region

#End Region


End Class
