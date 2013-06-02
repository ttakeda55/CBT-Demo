Public Class SpecificHeader

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>テスト№</summary>
        TestNo = 0
        ''' <summary>テスト名</summary>
        TestName
        ''' <summary>分野カテゴリーID</summary>
        CategoryId
        ''' <summary>大分類カテゴリーID</summary>
        LargeCategoryId
        ''' <summary>中分類カテゴリーID</summary>
        MiddleCategoryId
        ''' <summary>問題数</summary>
        Amount
        ''' <summary>表示</summary>
        Visible
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum

    ''' <summary>表示/有効</summary>
    Public Const Validity As String = "1"

    ''' <summary>表示/無効</summary>
    Public Const Invalid = "0"

#Region "----- メソッド -----"

    ''' <summary>
    ''' 指定テストヘッダファイル読込
    ''' </summary>
    ''' <param name="FileName">指定テストヘッダファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Return Serialize.XmlToDataTable(FileName)
    End Function

    ''' <summary>
    ''' 指定テストヘッダファイル出力
    ''' </summary>
    ''' <param name="dt">指定テストヘッダデータ格納DataTable</param>
    ''' <param name="FileName">指定テストヘッダファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '指定テストヘッダファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
