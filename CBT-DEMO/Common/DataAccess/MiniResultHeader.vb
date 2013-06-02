Public Class MiniResultHeader

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>ユーザID</summary>
        UserId = 0
        ''' <summary>テスト№</summary>
        TestNo
        ''' <summary>実施回数</summary>
        TestCount
        ''' <summary>種別</summary>
        QuestionClass
        ''' <summary>分野カテゴリーID</summary>
        CategoryId
        ''' <summary>大分類カテゴリーID</summary>
        LargeCategoryId
        ''' <summary>中分類カテゴリーID</summary>
        MiddleCategoryId
        ''' <summary>実施日</summary>
        TestDate
        ''' <summary>実施時間</summary>
        TestTime
        ''' <summary>問題数</summary>
        Count
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
        ''' <summary>サイズ</summary>
        Max
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 小テスト結果ヘッダファイル読込
    ''' </summary>
    ''' <param name="FileName">小テスト結果ヘッダファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Return Serialize.XmlToDataTable(FileName)
    End Function

    ''' <summary>
    ''' 小テスト結果ヘッダファイル出力
    ''' </summary>
    ''' <param name="dt">小テスト結果ヘッダデータ格納DataTable</param>
    ''' <param name="FileName">小テスト結果ヘッダファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '小テスト結果ヘッダファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
