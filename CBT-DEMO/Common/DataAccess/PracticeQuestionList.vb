Public Class PracticeQuestionList
#Region "----- 定数 -----"
    Public Const FILENAME = "PracticeQuestionList.xml"
    Public Const CLASSNAME = "PracticeQuestionList"
#End Region

#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>問題コード</summary>
        QuestinCode = 0
        ''' <summary>問題種別</summary>
        QuestionClass
        ''' <summary>主文問題コード</summary>
        MainCode
        ''' <summary>中問表示順</summary>
        MiddleQuestionIndex
        ''' <summary>問題テーマ</summary>
        Theme
        ''' <summary>難易度</summary>
        Level
        ''' <summary>カテゴリーID</summary>
        CategoryId
        ''' <summary>出題形式</summary>
        Format
        ''' <summary>正解答</summary>
        CorrectAnswer
        ''' <summary>状態</summary>
        State
        ''' <summary>問題タイプ</summary>
        QuestionType
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum
#End Region

    Private _dtPracticeQuestionList As New DataTable
    Private _readPath As String
#Region "----- メソッド -----"

    Public Sub New(ByVal path As String)
        _dtPracticeQuestionList = Serialize.XmlToDataTableFullPath(path & "\" & Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & ".xml")
    End Sub

    Public Function getCategoryId(ByVal questinCode As String) As String
        getCategoryId = ""
        Dim drPracticeQuestionLis As DataRow() = _dtPracticeQuestionList.Select("QUESTIONCODE = '" & questinCode & "'")
        If drPracticeQuestionLis.Length > 0 Then
            Return drPracticeQuestionLis(0).Item(ColumnIndex.CategoryId)
        End If
    End Function
    ''' <summary>
    ''' 演習問題一覧のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.PracticeQuestionList)
        dt.ReadXmlSchema(ts)
    End Sub


    ''' <summary>
    ''' 演習問題一覧ファイル読込
    ''' </summary>
    ''' <param name="FileName">演習問題一覧ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Dim practiceQuestionListData As New DataTable
        GetSchema(practiceQuestionListData)

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            practiceQuestionListData = Serialize.XmlToDataTable(FileName)
        End If
        Return practiceQuestionListData
    End Function

    ''' <summary>
    ''' 演習問題一覧ファイル読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll() As DataTable
        Dim practiceQuestionListData As New DataTable
        GetSchema(practiceQuestionListData)

        If IO.File.Exists(Common.Constant.GetTempPath & FILENAME) Then
            practiceQuestionListData = Serialize.XmlToDataTable(FILENAME)
        End If
        Return practiceQuestionListData
    End Function

    ''' <summary>
    ''' 演習問題一覧ファイル出力
    ''' </summary>
    ''' <param name="dt">演習問題一覧データ格納DataTable</param>
    ''' <param name="FileName">演習問題一覧ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '演習問題一覧ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function
    ''' <summary>
    ''' 演習問題一覧ファイル出力
    ''' </summary>
    ''' <param name="dt">演習問題一覧データ格納DataTable</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable) As Boolean
        Dim blnRet As Boolean = True

        Try
            '演習問題一覧ファイル出力
            Call Serialize.DataTableToxml(dt, FILENAME)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
