Public Class Collection


#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>問題群コード</summary>
        CourseNo = 0
        ''' <summary>問題コード</summary>
        QuestionCode
        ''' <summary>作成日付</summary>
        CreateDate
        ''' <summary>更新日付</summary>
        UpdateDate
    End Enum
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 問題群ファイル読込
    ''' </summary>
    ''' <param name="FileName">問題群ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Dim collectionData As New DataTable
        XmlSchema.GetPracticeQuestionListSchema(collectionData)

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            collectionData = Serialize.XmlToDataTable(FileName)
        End If
        Return collectionData
    End Function

    ''' <summary>
    ''' 問題群ファイル出力
    ''' </summary>
    ''' <param name="dt">問題群データ格納DataTable</param>
    ''' <param name="FileName">問題群ファイル名</param>
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

#End Region

End Class
