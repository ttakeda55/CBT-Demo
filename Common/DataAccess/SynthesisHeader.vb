Public Class SynthesisHeader

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>テスト№</summary>
        TestNo = 0
        ''' <summary>テスト名</summary>
        TestName
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 総合テストヘッダファイル読込
    ''' </summary>
    ''' <param name="FileName">総合テストヘッダファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Dim SynthesisHeaderListData As New DataTable
        XmlSchema.GetSynthesisHeaderSchema(SynthesisHeaderListData)

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            SynthesisHeaderListData = Serialize.XmlToDataTable(FileName)
        End If
        Return SynthesisHeaderListData
    End Function

    ''' <summary>
    ''' 総合テストヘッダファイル出力
    ''' </summary>
    ''' <param name="dt">総合テストヘッダデータ格納DataTable</param>
    ''' <param name="FileName">総合テストヘッダファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '総合テストヘッダファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
