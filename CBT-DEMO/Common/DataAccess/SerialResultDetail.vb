Public Class SerialResultDetail

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>ユーザID</summary>
        UserId = 0
        ''' <summary>実施回数</summary>
        TestCount
        ''' <summary>表示順</summary>
        ShowNo
        ''' <summary>問題コード</summary>
        QuestionCode
        ''' <summary>主文問題コード</summary>
        MainCode
        ''' <summary>正解答</summary>
        CorrectAnswer
        ''' <summary>解答</summary>
        Answer
        ''' <summary>正誤</summary>
        ErrAta
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
        ''' <summary>サイズ</summary>
        Max
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 逐次演習結果明細ファイル読込
    ''' </summary>
    ''' <param name="FileName">逐次演習結果明細ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Return Serialize.XmlToDataTable(FileName)
    End Function

    ''' <summary>
    ''' 逐次演習結果明細ファイル出力
    ''' </summary>
    ''' <param name="dt">逐次演習結果明細データ格納DataTable</param>
    ''' <param name="FileName">逐次演習結果明細ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '逐次演習結果明細ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
