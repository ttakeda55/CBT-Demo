Public Class DebugFile


    ''' <summary>ファイル種別</summary>
    Public Enum FileType As Integer

        ''' <summary>カテゴリー</summary>
        Category = 0
        ''' <summary>演習問題一覧</summary>
        PracticeQuestionList
        ''' <summary>再演習</summary>
        Review
        ''' <summary>問題群</summary>
        Collection
        ''' <summary>逐次演習結果ヘッダ</summary>
        SerialResultHeader
        ''' <summary>逐次演習結果明細</summary>
        SerialResultDetail

    End Enum

    <System.Diagnostics.Conditional("Debug")>
    Public Shared Sub DataTableOutPutCsv(ByVal dt As DataTable, ByVal FileType As FileType)
        Dim FilePath As String = Common.Constant.GetTempPath & "DebugCsv\"
        Dim FileName As String = ""
        Dim data As String = ""
        Try
            If Not IsNothing(dt) Then

                If Not IO.Directory.Exists(FilePath) Then
                    IO.Directory.CreateDirectory(FilePath)
                End If
                'ファイル名取得
                FileName = GetFileName(FileType)
                If FileName = "" Then Exit Sub
                FilePath += FileName
                Dim sr As New IO.StreamWriter(FilePath, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
                'ヘッダ書き込み
                For Idx As Integer = 0 To dt.Columns.Count - 1
                    data = GetCsvData(dt.Columns(Idx).Caption)
                    sr.Write(data)
                    If Idx < dt.Columns.Count - 1 Then
                        sr.Write(","c)
                    End If
                Next
                '改行
                sr.Write(ControlChars.Cr + ControlChars.Lf)
                'データ書き込み
                For Each rowData As DataRow In dt.Rows
                    For Idx As Integer = 0 To dt.Columns.Count - 1
                        data = GetCsvData(rowData(Idx).ToString)
                        sr.Write(data)
                        If Idx < dt.Columns.Count - 1 Then
                            sr.Write(","c)
                        End If
                    Next
                    '改行
                    sr.Write(ControlChars.Cr + ControlChars.Lf)
                Next
                sr.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Shared Function GetFileName(ByVal FileType As FileType) As String
        Dim FileName As String = ""

        Try
            Select Case FileType
                Case DebugFile.FileType.Category
                    'カテゴリー
                    FileName = Common.Constant.CST_CATEGORY_FILENAME & ".csv"
                Case DebugFile.FileType.PracticeQuestionList
                    '演習問題一覧
                    FileName = Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & ".csv"
                Case DebugFile.FileType.Review
                    '再演習
                    FileName = Common.Constant.CST_REVIEW_FILENAME & ".csv"
                Case DebugFile.FileType.Collection
                    '問題群
                    FileName = Common.Constant.CST_COLLECTION_FILENAME & ".csv"
                Case DebugFile.FileType.SerialResultHeader
                    '逐次演習結果ヘッダ
                    FileName = Common.Constant.CST_SERIALRESULTHEADER_FILENAME & ".csv"
                Case DebugFile.FileType.SerialResultDetail
                    '逐次演習結果明細
                    FileName = Common.Constant.CST_SERIALRESULTDETAIL_FILENAME & ".csv"

            End Select
        Catch ex As Exception
            FileName = ""
        End Try
        Return FileName
    End Function


    Private Shared Function GetCsvData(ByVal field As String) As String
        Dim retStr As String = field

        Try
            '"で囲む必要があるか調べる
            If retStr.IndexOf(ControlChars.Quote) > -1 OrElse _
                retStr.IndexOf(","c) > -1 OrElse _
                retStr.IndexOf(ControlChars.Cr) > -1 OrElse _
                retStr.IndexOf(ControlChars.Lf) > -1 OrElse _
                retStr.StartsWith(" ") OrElse _
                retStr.StartsWith(ControlChars.Tab) OrElse _
                retStr.EndsWith(" ") OrElse _
                retStr.EndsWith(ControlChars.Tab) Then
                If retStr.IndexOf(ControlChars.Quote) > -1 Then
                    '"を""とする
                    retStr = retStr.Replace("""", """""")
                End If
                retStr = """" + retStr + """"
            End If
        Catch ex As Exception
            retStr = ""
        End Try
        Return retStr
    End Function
End Class
