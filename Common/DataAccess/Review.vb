Public Class Review

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>問題コード</summary>
        QuestionCode = 0
        ''' <summary>再演習</summary>
        Review
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 再演習ファイル読込
    ''' </summary>
    ''' <param name="FileName">再演習ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Return Serialize.XmlToDataTable(FileName)
    End Function

    ''' <summary>
    ''' 再演習ファイル出力
    ''' </summary>
    ''' <param name="dt">再演習データ格納DataTable</param>
    ''' <param name="FileName">再演習ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '再演習ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
