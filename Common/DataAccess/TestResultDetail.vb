''' <summary>
''' 個人試験結果詳細を取り扱うクラス
''' </summary>
Public Class TestResultDetail

#Region "----- 列挙子 -----"

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>ユーザID</summary>
        UserId = 0
        ''' <summary>受験回数</summary>
        TestCount
        ''' <summary>問題番号</summary>
        QuestionNo
        ''' <summary>大分類</summary>
        Category1
        ''' <summary>中分類</summary>
        Category2
        ''' <summary>問題テーマ</summary>
        QuestionTheme
        ''' <summary>解答</summary>
        Answer
        ''' <summary>表示解答</summary>
        DisplyAnswer
        ''' <summary>正誤</summary>
        Errata
        ''' <summary>行インデックス最大値</summary>
        Max
    End Enum

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>個人試験結果詳細データ格納DataTable</summary>
    Private _DetailData As New DataTable

#End Region

#Region "----- プロパティ -----"

#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>コンストラクタ</summary>
    Public Sub New()
        Try
            Call XmlSchema.GetTestResultDetailSchema(_DetailData)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 個人試験結果詳細データ取込処理
    ''' </summary>
    ''' <param name="FileName">個人試験結果詳細XMLファイル名</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Public Function ReadXML(ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            'XMLファイルを読込、DataTableに設定する
            _DetailData = Serialize.XmlToDataTable(FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 個人結果詳細データ出力
    ''' </summary>
    ''' <param name="FileName">個人試験結果詳細XMLファイル名</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Public Function WriteXML(ByVal FileName As String, Optional ByVal blnBackup As Boolean = False) As Boolean
        Dim blnRet As Boolean = True

        Try
            If blnBackup Then
                Call Serialize.DataTableToxmlFullPath(_DetailData, FileName)
            Else
                Call Serialize.DataTableToxml(_DetailData, FileName)
            End If
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 個人試験結果詳細データ追加
    ''' </summary>
    ''' <param name="datas">追加データ配列</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    Public Function Add(ByVal datas() As String) As Boolean
        Dim blnRet As Boolean = False
        Dim dataRow As DataRow = Nothing
        Dim i As Integer = 0

        Try
            'カラム数と追加するデータ数が一致するかチェック
            If _DetailData.Columns.Count = datas.Length Then
                dataRow = _DetailData.NewRow
                For i = 0 To datas.Length - 1
                    dataRow(i) = datas(i)
                Next
                '追加
                Call _DetailData.Rows.Add(dataRow)
                blnRet = True
            End If
        Catch ex As Exception

        End Try

        Return blnRet
    End Function

    ''' <summary>
    ''' 個人試験結果詳細データ取得
    ''' </summary>
    ''' <param name="TestCount">試験回数</param>
    ''' <returns>成功：個人試験結果詳細データ、失敗：Nothing</returns>
    Public Function GetDataRow(ByVal TestCount As Integer) As DataRow()
        Dim dataRows() As DataRow = Nothing
        Dim filterExpression As String = ""

        Try
            filterExpression = "TESTCOUNT = '" & TestCount.ToString & "'"
            dataRows = _DetailData.Select(filterExpression)
        Catch ex As Exception
            dataRows = Nothing
        End Try
        Return dataRows
    End Function

    ''' <summary>
    ''' 個人試験結果詳細データ取得
    ''' </summary>
    ''' <param name="TestCount">試験回数</param>
    ''' <param name="QuestionNumber">問題番号</param>
    ''' <returns>成功：個人試験結果詳細データ、失敗：Nothing</returns>
    Public Function GetDataRow(ByVal TestCount As Integer, ByVal QuestionNumber As Integer) As DataRow
        Dim dataRow As DataRow = Nothing
        Dim dataRows() As DataRow = Nothing
        Dim filterExpression As String = ""

        Try
            filterExpression = "TESTCOUNT = '" & TestCount.ToString & "' AND QUESTIONNO = '" & QuestionNumber.ToString & "'"
            dataRows = _DetailData.Select(filterExpression)
            If dataRows.Length = 1 Then
                dataRow = dataRows(0)
            End If
        Catch ex As Exception
            dataRow = Nothing
        End Try
        Return dataRow
    End Function

    ''' <summary>
    ''' CSV出力
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteCsv()
        Dim writeData As String = ""
        Dim sw As IO.StreamWriter = Nothing

        Try
            Dim path As String = Common.Constant.GetTempPath & "Debug_TestResultDetail.csv"
            sw = New IO.StreamWriter(path, False)

            For Each DataRow As DataRow In _DetailData.Rows
                writeData = ""
                For i As Integer = 0 To _DetailData.Columns.Count - 1
                    If i > 0 Then writeData += ", "
                    writeData += DataRow.Item(i).ToString
                Next
                sw.WriteLine(writeData)
            Next
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            If Not IsNothing(sw) Then
                sw.Close()
                sw = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 個人試験結果詳細データ削除
    ''' </summary>
    ''' <param name="TestCount">試験回数</param>
    ''' <returns>True：成功, False：失敗</returns>
    ''' <remarks></remarks>
    Public Function DeleteDataRow(ByVal TestCount As Integer) As Boolean
        Dim blnRet As Boolean = True
        Dim filterExpression As String = ""

        Try
            filterExpression = "TESTCOUNT = '" & TestCount.ToString & "'"
            For Each rowData As DataRow In _DetailData.Select(filterExpression)
                _DetailData.Rows.Remove(rowData)
            Next
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet = True
    End Function

#End Region

End Class
