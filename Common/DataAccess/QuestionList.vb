''' <summary>
''' 模擬テスト一覧
''' </summary>
''' <remarks></remarks>
Public Class QuestionList

#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>テスト名</summary>
        TestName = 0
        ''' <summary>対応模擬テスト</summary>
        MockTestNO
        ''' <summary>利用開始日</summary>
        UseStart
        ''' <summary>利用終了日</summary>
        UseEnd
        ''' <summary>状態</summary>
        Stats
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum
#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>模擬テスト一覧データ格納DataTable</summary>
    Private Shared _QuestionListData As New DataTable

#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>コンストラクタ</summary>
    Public Sub New()
        Try
            Call XmlSchema.GetQuestionListSchema(_QuestionListData)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 模擬テスト一覧ファイル読込
    ''' </summary>
    ''' <param name="FileName">模擬テスト一覧ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Common.XmlSchema.GetQuestionListSchema(_QuestionListData)

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            _QuestionListData = Serialize.XmlToDataTable(FileName)
        End If
        Return _QuestionListData
    End Function

    ''' <summary>
    ''' 模擬テスト一覧ファイル出力
    ''' </summary>
    ''' <param name="dt">模擬テスト一覧データ格納DataTable</param>
    ''' <param name="FileName">模擬テスト一覧ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '模擬テスト一覧ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 模擬テスト一覧から模擬テスト名を取得する。
    ''' </summary>
    ''' <param name="dtQuestionList">模擬テスト一覧</param>
    ''' <param name="mockTestNo">模擬テスト№</param>
    ''' <param name="courseUseStart">コースの利用開始日</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMockTestName(ByVal dtQuestionList As DataTable, ByVal mockTestNo As String, ByVal courseUseStart As String) As String
        GetMockTestName = ""
        '模擬テスト
        dtQuestionList.DefaultView.RowFilter = "MOCKTESTNO = '" & mockTestNo & "' AND USEEND <> ''"
        dtQuestionList.DefaultView.RowFilter &= "AND USESTART <= '" & courseUseStart & "' AND '" & courseUseStart & "' <=  USEEND"
        dtQuestionList.DefaultView.Sort = "STATE ASC,UPDATE_DATE DESC"
        Dim dtQeustionFilter As DataTable = dtQuestionList.DefaultView.ToTable
        If dtQeustionFilter.Rows.Count > 0 Then
            '対応模擬テストNO
            GetMockTestName = dtQeustionFilter.Rows(0).Item("TESTNAME")
        End If
    End Function
#End Region

End Class
