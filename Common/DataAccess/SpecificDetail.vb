Public Class SpecificDetail

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>テスト№</summary>
        TestNo = 0
        ''' <summary>問題コード</summary>
        QuestionCode
        ''' <summary>表示順</summary>
        ShowNo
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 指定テスト明細ファイル読込
    ''' </summary>
    ''' <param name="FileName">指定テスト明細ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Return Serialize.XmlToDataTable(FileName)
    End Function

    ''' <summary>
    ''' 指定テスト明細ファイル出力
    ''' </summary>
    ''' <param name="dt">指定テスト明細データ格納DataTable</param>
    ''' <param name="FileName">指定テスト明細ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '指定テスト明細ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
