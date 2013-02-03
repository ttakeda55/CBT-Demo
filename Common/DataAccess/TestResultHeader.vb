''' <summary>
''' 個人試験結果ヘッダを取り扱うクラス
''' </summary>
Public Class TestResultHeader

#Region "----- 列挙子 -----"

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>ユーザID</summary>
        UserId = 0
        ''' <summary>受験回数</summary>
        TestCount
        ''' <summary>受験日</summary>
        TestDate
        ''' <summary>受験時間</summary>
        TestTime
        ''' <summary>大分類点数A</summary>
        CategoryPoint1_A
        ''' <summary>大分類点数B</summary>
        CategoryPoint1_B
        ''' <summary>大分類点数C</summary>
        CategoryPoint1_C
        ''' <summary>大分類点数D</summary>
        CategoryPoint1_D
        ''' <summary>総合評価点</summary>
        TotalPoints
        ''' <summary>中分類点数A</summary>
        CategoryPoint2_A
        ''' <summary>中分類点数B</summary>
        CategoryPoint2_B
        ''' <summary>中分類点数C</summary>
        CategoryPoint2_C
        ''' <summary>中分類点数D</summary>
        CategoryPoint2_D
        ''' <summary>中分類点数E</summary>
        CategoryPoint2_E
        ''' <summary>中分類点数F</summary>
        CategoryPoint2_F
        ''' <summary>中分類点数G</summary>
        CategoryPoint2_G
        ''' <summary>中分類点数H</summary>
        CategoryPoint2_H
        ''' <summary>中分類点数I</summary>
        CategoryPoint2_I
        ''' <summary>合否</summary>
        Result
        ''' <summary>行インデックス最大値</summary>
        Max
    End Enum
#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>個人試験結果ヘッダデータ格納DataTable</summary>
    Private _HeaderData As New DataTable

#End Region

#Region "----- プロパティ -----"

#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>コンストラクタ</summary>
    Public Sub New()
        Try
            Call XmlSchema.GetTestResultHeaderSchema(_HeaderData)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 個人試験結果ヘッダデータ取込処理
    ''' </summary>
    ''' <param name="FileName">個人試験結果ヘッダXMLファイル名</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Public Function ReadXML(ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            'XMLファイルを読込、DataTableに設定する
            _HeaderData = Serialize.XmlToDataTable(FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 個人結果ヘッダデータ出力
    ''' </summary>
    ''' <param name="FileName">個人試験結果ヘッダXMLファイル名</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Public Function WriteXML(ByVal FileName As String, Optional ByVal blnBackup As Boolean = False) As Boolean
        Dim blnRet As Boolean = True

        Try
            If blnBackup Then
                Call Serialize.DataTableToxmlFullPath(_HeaderData, FileName)
            Else
                Call Serialize.DataTableToxml(_HeaderData, FileName)
            End If

        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 個人試験結果ヘッダデータ追加
    ''' </summary>
    ''' <param name="datas">追加データ配列</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Public Function Add(ByVal datas() As String) As Boolean
        Dim blnRet As Boolean = False
        Dim dataRow As DataRow = Nothing
        Dim i As Integer = 0

        Try
            'カラム数と追加するデータ数が一致するかチェック
            If _HeaderData.Columns.Count = datas.Length Then
                dataRow = _HeaderData.NewRow
                For i = 0 To datas.Length - 1
                    dataRow(i) = datas(i)
                Next
                '追加
                Call _HeaderData.Rows.Add(dataRow)
                blnRet = True
            End If
        Catch ex As Exception

        End Try

        Return blnRet
    End Function

    ''' <summary>
    ''' 個人試験結果ヘッダデータ取得
    ''' </summary>
    ''' <param name="TestCount">試験回数</param>
    ''' <returns>成功：個人試験結果ヘッダデータ、失敗：Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDataRow(ByVal TestCount As Integer) As DataRow()
        Dim dataRows() As DataRow = Nothing
        Dim filterExpression As String = ""

        Try
            filterExpression = "TESTCOUNT = '" & TestCount.ToString & "'"
            dataRows = _HeaderData.Select(filterExpression)
        Catch ex As Exception
            dataRows = Nothing
        End Try
        Return dataRows
    End Function

    ''' <summary>
    ''' 個人試験結果ヘッダデータ削除
    ''' </summary>
    ''' <param name="TestCount">試験回数</param>
    ''' <returns>True：成功, False：失敗</returns>
    ''' <remarks></remarks>
    Public Function DeleteDataRow(ByVal TestCount As Integer) As Boolean
        Dim blnRet As Boolean = True
        Dim filterExpression As String = ""

        Try
            filterExpression = "TESTCOUNT = '" & TestCount.ToString & "'"
            For Each rowData As DataRow In _HeaderData.Select(filterExpression)
                _HeaderData.Rows.Remove(rowData)
            Next
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
