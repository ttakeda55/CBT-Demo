Public Class WebServiceUrl


#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>URL</summary>
        Url = 0
        ''' <summary>共通Url</summary>
        CommonUrl
    End Enum
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' WebServiceUrlファイル出力
    ''' </summary>
    ''' <param name="dt">WebServiceUrlデータ格納DataTable</param>
    ''' <param name="FileName">WebServiceUrlファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            'WebServiceUrlファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
