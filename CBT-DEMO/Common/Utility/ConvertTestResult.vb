Public Class ConvertTestResult
    Private _dsSynthesisResultHeader As New DataSet
    Private _dsSynthesisResultDetail As New DataSet

    Private _dtTestResultHeader As DataTable
    Private _dtTestResultDetail As DataTable

    Private _readPath As String
    Private _groupCode As String

    Public Sub New(ByVal path As String)
        _readPath = path
        _groupCode = Common.Constant.CST_GROUPNAME
    End Sub

    Public Sub ReadSynthesisResult()
        Dim fileName As String = ""
        Dim userid As String = ""
        'ヘッダ取得
        For Each filePath As String In IO.Directory.GetFiles(_readPath, Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & "*")
            fileName = IO.Path.GetFileName(filePath)
            Dim dtSynthesisResultHeader As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            dtSynthesisResultHeader.TableName = fileName
            _dsSynthesisResultHeader.Tables.Add(dtSynthesisResultHeader.Copy)
        Next

        '明細取得
        For Each filePath As String In IO.Directory.GetFiles(_readPath, Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & "*")
            fileName = IO.Path.GetFileName(filePath)
            Dim dtSynthesisResultDetail As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            dtSynthesisResultDetail.TableName = fileName
            _dsSynthesisResultDetail.Tables.Add(dtSynthesisResultDetail.Copy)
        Next
    End Sub

    Private Function getFieldPoint(ByVal dtDetail As DataTable, ByVal categoryId As Integer) As String
        Dim point As Double = 0.0
        Dim category As DataTable = Common.CategoryMaster.GetAll()
        Dim drCategory As DataRow() = category.Select("CATEGORYID = '" & categoryId & "'")
        Dim displayid As String = ""
        If drCategory.Length > 0 Then
            displayid = drCategory(0).Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
        End If
        Dim drChild As DataRow() = dtDetail.Select("CATEGORY1 = '" & displayid & "' AND ERRATA = 1")
        Dim drParent As DataRow() = dtDetail.Select("CATEGORY1 = '" & displayid & "'")
        If drParent.Length = 0 Then
            Return 0
        End If
        'point = Math.Floor(drChild.Length / drParent.Length * 100)
        point = drChild.Length
        Return point
    End Function

    Private Function getLargePoint(ByVal dtDetail As DataTable, ByVal categoryId As Integer) As String
        Dim point As Double = 0.0
        Dim category As DataTable = Common.CategoryMaster.GetAll()
        Dim drCategory As DataRow() = category.Select("CATEGORYID = '" & categoryId & "'")
        Dim displayid As String = ""
        If drCategory.Length > 0 Then
            displayid = drCategory(0).Item(Common.CategoryMaster.ColumnIndex.DISPLAYID)
        End If
        Dim drChild As DataRow() = dtDetail.Select("CATEGORY2 = '" & displayid & "' AND ERRATA = 1")
        Dim drParent As DataRow() = dtDetail.Select("CATEGORY2 = '" & displayid & "'")
        If drParent.Length = 0 Then
            Return 0
        End If
        'point = Math.Floor(drChild.Length / drParent.Length * 100)
        point = drChild.Length
        Return point
    End Function

    Private Sub keisan(heder As DataTable, detail As DataTable)
        For Each drHeader As DataRow In heder.Rows
            Dim dt As DataTable = heder.Clone
            Dim sutorate As Integer = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY1 = 'ストラテジ系' AND ERRATA = 1").Length / 36 * 1000)
            Dim manzimento As Integer = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY1 = 'マネジメント系' AND ERRATA = 1").Length / 24 * 1000)
            Dim tekunorozi As Integer = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY1 = 'テクノロジ系' AND ERRATA = 1").Length / 40 * 1000)
            Dim total As Integer = detail.Select("USERID = '" & drHeader("USERID") & "' AND ERRATA = 1").Length * 10
            drHeader("CATEGORYPOINT1_A") = sutorate
            drHeader("CATEGORYPOINT1_B") = manzimento
            drHeader("CATEGORYPOINT1_C") = tekunorozi
            drHeader("TOTALPOINTS") = total

            drHeader("CATEGORYPOINT2_A") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = '企業と法務' AND ERRATA = 1").Length / 17 * 1000)
            drHeader("CATEGORYPOINT2_B") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = '経営戦略' AND ERRATA = 1").Length / 9 * 1000)
            drHeader("CATEGORYPOINT2_C") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = 'システム戦略' AND ERRATA = 1").Length / 10 * 1000)
            drHeader("CATEGORYPOINT2_D") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = '開発技術' AND ERRATA = 1").Length / 8 * 1000)
            drHeader("CATEGORYPOINT2_E") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = 'プロジェクトマネジメント' AND ERRATA = 1").Length / 8 * 1000)
            drHeader("CATEGORYPOINT2_F") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = 'サービスマネジメント' AND ERRATA = 1").Length / 8 * 1000)
            drHeader("CATEGORYPOINT2_G") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = '基礎理論' AND ERRATA = 1").Length / 6 * 1000)
            drHeader("CATEGORYPOINT2_H") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = 'コンピュータシステム' AND ERRATA = 1").Length / 17 * 1000)
            drHeader("CATEGORYPOINT2_I") = Math.Floor(detail.Select("USERID = '" & drHeader("USERID") & "' AND CATEGORY2 = '技術要素' AND ERRATA = 1").Length / 17 * 1000)
            If sutorate >= 300 And manzimento >= 300 And tekunorozi >= 300 And total >= 600 Then
                drHeader("RESULT") = "1"
            Else
                drHeader("RESULT") = "0"
            End If

            dt.ImportRow(drHeader)

            Dim drs2 As DataRow() = detail.Select("USERID = '" & drHeader("USERID") & "'")
            Dim dt2 As DataTable = detail.Clone
            'For Each dr2 As DataRow In drs
            '    dt2.ImportRow(dr2)
            'Next
        Next

    End Sub
End Class
