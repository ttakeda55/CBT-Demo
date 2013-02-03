Imports Microsoft.Office.Interop

''' <summary>
''' エクセルを作成する
''' </summary>
''' １．２ページ以上ある帳票は、２ページ目以降のテンプレートをエクセルの２シート目に作成しておく。
''' ２．抽出者平均行を出力する場合は、「average」シートを作成し、１行目に行を作成しておく。
''' ３．ページ番号には、「PageCount」の名前を付ける。
''' ４．１ページの行数は、１ページ目テンプレートと、２ページ目テンプレートを合わせる。
''' ５．改ページ行数は、常に同じ行数となるよう作成する。
''' ６．セル結合は１ページ目のみ。
''' <remarks>
''' エクセル作成の注事項
''' </remarks>
Public Class ExcelCreater
    Implements IDisposable
#Region "----- メンバ変数 -----"
    Dim xlApp As Excel.Application = Nothing
    Dim xlBooks As Excel.Workbooks = Nothing
    Dim xlBook As Excel.Workbook = Nothing
    Dim xlSheets As Excel.Sheets = Nothing
    Dim xlSheet As Excel.Worksheet = Nothing
    Dim xlSheet2ndPage As Excel.Worksheet = Nothing
    Dim xlSheetAvePage As Excel.Worksheet = Nothing
    Dim xlRange As Excel.Range = Nothing
    Dim xlRangeWk As Excel.Range = Nothing
    Dim xlCopyRowRange As Excel.Range = Nothing
    Dim xlPasteRowRange As Excel.Range = Nothing
    Dim _lastRowIndex As Integer = 0

#End Region

#Region "----- デストラクタ -----"
    Public Sub New()
        xlApp = New Excel.Application
    End Sub

    ''' <summary>
    ''' デストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose() Implements IDisposable.Dispose

        '解放
        If Not IsNothing(xlRangeWk) Then
            ReleaseComObject(xlRangeWk)
        End If
        If Not IsNothing(xlCopyRowRange) Then
            ReleaseComObject(xlCopyRowRange)
        End If
        If Not IsNothing(xlPasteRowRange) Then
            ReleaseComObject(xlPasteRowRange)
        End If
        If Not IsNothing(xlRange) Then
            ReleaseComObject(xlRange)
        End If
        If Not IsNothing(xlSheet) Then
            ReleaseComObject(xlSheet)
            xlSheet = Nothing
        End If
        If Not IsNothing(xlSheet2ndPage) Then
            ReleaseComObject(xlSheet2ndPage)
            xlSheet = Nothing
        End If
        If Not IsNothing(xlSheetAvePage) Then
            ReleaseComObject(xlSheetAvePage)
            xlSheet = Nothing
        End If
        If Not IsNothing(xlSheets) Then
            ReleaseComObject(xlSheets)
            xlSheets = Nothing
        End If
        If Not IsNothing(xlBook) Then
            xlBook.Close()
            ReleaseComObject(xlBook)
            xlBook = Nothing
        End If
        If Not IsNothing(xlBooks) Then
            xlBooks.Close()
            ReleaseComObject(xlBooks)
            xlBooks = Nothing
        End If
        If Not IsNothing(xlApp) Then
            xlApp.Quit()
            ReleaseComObject(xlApp)
            xlApp = Nothing
        End If

        GC.Collect()

    End Sub
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 改ページあり帳票用エクセルファイル作成
    ''' </summary>
    ''' <param name="filePath">テンプレートファイルパス</param>
    ''' <param name="sheetName">出力シート名</param>
    ''' <param name="firstPageData">１ページ目の設定データ項目</param>
    ''' <param name="secondPageData">２ページ目の設定データ項目</param>
    ''' <param name="dtReportList">リスト表示用データテーブル</param>
    ''' <param name="averagePageData">平均の設定データ項目</param>
    ''' <param name="rowCountInPage">１ページの行数</param>
    ''' <param name="listRowCountInFirstPage">１ページ目の表の行数</param>
    ''' <param name="listRowCountInAfterSecondPage">１ページ目の表の行数</param>
    ''' <param name="listRowCountInPagebreak">改ページするために挿入する行数</param>
    ''' <param name="isAverageRow">抽出者平均行を出力するか。出力する場合は
    ''' テンプレートに「average」シートを用意する。</param>
    ''' <remarks></remarks>
    Public Sub Create(ByVal filePath As String, _
                      ByVal sheetName As String, _
                      ByVal firstPageData As Hashtable, _
                      ByVal dtReportList As DataTable, _
                      ByVal secondPageData As Hashtable, _
                      ByVal rowCountInPage As Integer, _
                      ByVal listRowCountInFirstPage As Integer, _
                      ByVal listRowCountInAfterSecondPage As Integer, _
                      ByVal listRowCountInPagebreak As Integer, _
                      ByVal isAverageRow As Boolean, _
                      Optional ByVal averagePageData As Hashtable = Nothing)
        Create(filePath, _
               sheetName, _
               firstPageData, _
               dtReportList, _
               True, _
               secondPageData, _
               averagePageData, _
               rowCountInPage, _
               listRowCountInFirstPage, _
               listRowCountInAfterSecondPage, _
               listRowCountInPagebreak, _
               isAverageRow, _
               False, 0, 0, Nothing)
    End Sub

    ''' <summary>
    ''' 改ページなし帳票用エクセルファイル作成
    ''' </summary>
    ''' <param name="filePath">テンプレートファイルパス</param>
    ''' <param name="sheetName">出力シート名</param>
    ''' <param name="firstPageData">１ページ目の設定データ項目</param>
    ''' <param name="dtReportList">リスト表示用データテーブル
    ''' テンプレートに「average」シートを用意する。</param>
    ''' <param name="isBoldBorder">最終行を太字にするか</param>
    ''' <param name="bindingCellNameList">セル結合する表の項目名</param>
    ''' <param name="boldColNo"></param>
    ''' <param name="boldColLength"></param>
    ''' <remarks></remarks>
    Public Sub Create(ByVal filePath As String, _
                      ByVal sheetName As String, _
                      ByVal firstPageData As Hashtable, _
                      ByVal dtReportList As DataTable, _
                      ByVal isBoldBorder As Boolean, _
                      Optional ByVal bindingCellNameList As ArrayList = Nothing, _
                      Optional ByVal boldColNo As Integer = 0, _
                      Optional ByVal boldColLength As Integer = 0)
        Create(filePath, _
               sheetName, _
               firstPageData, _
               dtReportList, _
               False, _
               Nothing, _
               Nothing, _
               0, 0, 0, 0, _
               False, _
               isBoldBorder, _
               boldColNo, _
               boldColLength, _
               bindingCellNameList)
    End Sub

    ''' <summary>
    ''' エクセルファイル作成
    ''' </summary>
    ''' <param name="filePath">テンプレートファイルパス</param>
    ''' <param name="sheetName">出力シート名</param>
    ''' <param name="firstPageData">１ページ目の設定データ項目</param>
    ''' <param name="secondPageData">２ページ目の設定データ項目</param>
    ''' <param name="dtReportList">リスト表示用データテーブル</param>
    ''' <param name="isPageBreak">改ページするかどうか</param>
    ''' <param name="averagePageData">平均の設定データ項目</param>
    ''' <param name="rowCountInPage">１ページの行数</param>
    ''' <param name="listRowCountInFirstPage">１ページ目の表の行数</param>
    ''' <param name="listRowCountInAfterSecondPage">１ページ目の表の行数</param>
    ''' <param name="listRowCountInPagebreak">改ページするために挿入する行数</param>
    ''' <param name="isAverageRow">抽出者平均行を出力するか。出力する場合は
    ''' テンプレートに「average」シートを用意する。</param>
    ''' <param name="isBoldBorder">最終行を太字にするか</param>
    ''' <param name="bindingCellNameList">セル結合する表の項目名</param>
    ''' <param name="boldColNo"></param>
    ''' <param name="boldColLength"></param>
    ''' <remarks></remarks>
    Private Sub Create(ByVal filePath As String, _
                      ByVal sheetName As String, _
                      ByVal firstPageData As Hashtable, _
                      ByVal dtReportList As DataTable, _
                      ByVal isPageBreak As Boolean, _
                      ByVal secondPageData As Hashtable, _
                      ByVal averagePageData As Hashtable, _
                      ByVal rowCountInPage As Integer, _
                      ByVal listRowCountInFirstPage As Integer, _
                      ByVal listRowCountInAfterSecondPage As Integer, _
                      ByVal listRowCountInPagebreak As Integer, _
                      ByVal isAverageRow As Boolean, _
                      ByVal isBoldBorder As Boolean, _
                      ByVal boldColNo As Integer, _
                      ByVal boldColLength As Integer, _
                      ByVal bindingCellNameList As ArrayList)
        Try
            If IO.File.Exists(filePath) Then
                xlApp.Visible = False
                xlApp.DisplayAlerts = False
                xlBooks = xlApp.Workbooks
                Dim firstBookPage As Integer
                If xlBook Is Nothing Then
                    firstBookPage = 0
                    xlBook = xlBooks.Open(filePath)
                    xlSheets = xlBook.Worksheets
                    xlSheet = CType(xlSheets.Item(1), Excel.Worksheet)
                Else
                    firstBookPage = xlBook.Sheets.Count - 1
                    Dim xlBook2 = xlBooks.Open(filePath)
                    Dim xlSheets2 = xlBook2.Worksheets
                    For iCount As Integer = 1 To xlSheets2.Count
                        Dim xlSheet2 = CType(xlSheets2.Item(iCount), Excel.Worksheet)
                        xlSheet2.Copy(After:=xlSheet)
                    Next
                    xlSheet = CType(xlSheets.Item(xlSheets.Count), Excel.Worksheet)
                End If

                '検索条件設定
                For Each key As String In firstPageData.Keys
                    xlSheet.Range(key).Value = firstPageData(key)
                Next

                If isPageBreak And xlSheets.Count >= 2 Then
                    xlSheet2ndPage = CType(xlSheets.Item(2 + firstBookPage), Excel.Worksheet)
                    '検索条件設定
                    For Each key As String In secondPageData.Keys
                        xlSheet2ndPage.Range(key).Value = secondPageData(key)
                    Next
                End If

                '２ページ目以降テンプレートを追加
                If isPageBreak Then
                    createPage(xlSheet, xlSheet2ndPage, dtReportList, rowCountInPage, listRowCountInFirstPage, listRowCountInAfterSecondPage)
                End If

                '表の設定
                Dim i As Integer = 1
                Dim pageCounter As Integer = 0
                Dim IsFirstPage As Boolean = True
                Dim outPutRowIndex As Integer = 0
                Dim startListRowIndex As Integer = xlSheet.Range(dtReportList.Columns(0).ColumnName).Row
                Dim htColumns As New Hashtable
                Dim colLength As Integer = 150
                Dim range As Excel.Range = Nothing
                Dim range1 As Excel.Range = Nothing
                Dim range2 As Excel.Range = Nothing
                Dim dtWkReportList As DataTable = dtReportList.Clone
                Dim startPageListRow As Integer = startListRowIndex
                Dim rowIndex As Integer = 0
                Dim pageBreakCount As Integer = 1
                Dim pageBreakFlg As Boolean = False

                xlSheet.ResetAllPageBreaks()
                'カラム情報
                For Each col As DataColumn In dtReportList.Columns
                    htColumns(xlSheet.Range(col.ColumnName).Column) = col.ColumnName
                Next
                For Each dr As DataRow In dtReportList.Rows
                    If startListRowIndex + outPutRowIndex <> startListRowIndex Then
                        xlSheet.Range(startListRowIndex & ":" & startListRowIndex).Copy(Destination:=xlSheet.Range("A" & startListRowIndex + outPutRowIndex))
                    End If
                    Dim drWkReportList As DataRow = dtWkReportList.NewRow
                    For Each col As Integer In htColumns.Keys
                        drWkReportList.Item(htColumns(col)) = dr.Item(htColumns(col))
                    Next
                    dtWkReportList.Rows.Add(drWkReportList)
                    outPutRowIndex += 1
                    pageCounter += 1

                    'データ設定
                    If isPageBreak Then
                        If IsFirstPage Then
                            If listRowCountInFirstPage = pageCounter Then
                                writeRange(dtWkReportList, colLength, htColumns, startListRowIndex, outPutRowIndex, startPageListRow, pageCounter, listRowCountInPagebreak)
                                IsFirstPage = False
                                pageBreakFlg = True
                            Else
                                If dtReportList.Rows.Count - 1 = rowIndex Then
                                    writeRange(dtWkReportList, colLength, htColumns, startListRowIndex, outPutRowIndex, startPageListRow, pageCounter, listRowCountInPagebreak)
                                    Exit For
                                End If
                            End If
                        Else
                            If listRowCountInAfterSecondPage = pageCounter Then
                                writeRange(dtWkReportList, colLength, htColumns, startListRowIndex + startPageListRow, outPutRowIndex, startPageListRow, pageCounter, listRowCountInPagebreak)
                                pageBreakFlg = True
                            ElseIf dtReportList.Rows.Count - 1 = rowIndex Then
                                writeRange(dtWkReportList, colLength, htColumns, startListRowIndex + startPageListRow, outPutRowIndex, startPageListRow, pageCounter, listRowCountInPagebreak)
                                Exit For
                            End If
                        End If
                    Else
                        If dtReportList.Rows.Count - 1 = rowIndex Then
                            writeRange(dtWkReportList, colLength, htColumns, startListRowIndex, outPutRowIndex, startPageListRow, pageCounter, listRowCountInPagebreak)
                            Exit For
                        End If
                    End If
                    '改ページ
                    If isPageBreak And pageBreakFlg Then
                        xlSheet.Cells(rowCountInPage * pageBreakCount + 1, 1).PageBreak = Excel.XlPageBreak.xlPageBreakManual
                        pageBreakCount += 1
                        pageBreakFlg = False
                    End If

                    rowIndex += 1
                Next

                '線をボールド
                If isBoldBorder Then
                    For i = boldColNo To boldColLength
                        xlRange = xlSheet.Cells(_lastRowIndex, i)
                        xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium
                    Next
                End If

                '平均
                If isAverageRow Then
                    xlSheetAvePage = CType(xlSheets("average"), Excel.Worksheet)
                    '検索条件設定
                    For Each key As String In averagePageData.Keys
                        xlSheetAvePage.Range(key).Value = averagePageData(key)
                    Next
                    xlSheetAvePage.Range("1:1").Copy()
                    xlPasteRowRange = xlSheet.Range("A" & _lastRowIndex + 1)
                    xlPasteRowRange.PasteSpecial()
                    xlSheetAvePage.Delete()
                End If

                'セル結合
                Dim j As Integer = 0
                Dim colIndex As Integer = 0
                If Not bindingCellNameList Is Nothing AndAlso bindingCellNameList.Count > 0 Then
                    For Each bindingCellName As String In bindingCellNameList
                        colIndex = xlSheet.Range(bindingCellName).Column
                        i = xlSheet.Range(bindingCellName).Row
                        j = i + 1
                        Do While CType(xlSheet.Cells(j, colIndex).Value, String) <> ""
                            If xlSheet.Cells(i, colIndex).Value = xlSheet.Cells(j, colIndex).Value Then
                                '同一値では結合
                                xlSheet.Range(xlSheet.Cells(i, colIndex), xlSheet.Cells(j, colIndex)) _
                                        .MergeCells = True
                                j = j + 1
                            Else
                                i = j
                                j = j + 1
                            End If
                        Loop
                    Next
                End If

                xlSheet.Activate()
                xlSheet.Name = sheetName
                xlSheet.Range("A1").Select()
                If isPageBreak And xlSheets.Count >= 2 Then
                    xlSheet2ndPage.Delete()
                End If
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 書き込み
    ''' </summary>
    ''' <param name="dtWkReportList"></param>
    ''' <param name="colLength"></param>
    ''' <param name="htColumns"></param>
    ''' <param name="startListRowIndex"></param>
    ''' <param name="outPutRowIndex"></param>
    ''' <param name="startPageListRow"></param>
    ''' <param name="pageCounter"></param>
    ''' <param name="listRowCountInPagebreak"></param>
    ''' <remarks></remarks>
    Private Sub writeRange(ByRef dtWkReportList As DataTable, ByVal colLength As Integer, ByVal htColumns As Hashtable, ByVal startListRowIndex As Integer,
                          ByRef outPutRowIndex As Integer, ByRef startPageListRow As Integer, ByRef pageCounter As Integer, ByVal listRowCountInPagebreak As Integer)
        Dim startRange As Excel.Range
        Dim endRange As Excel.Range
        Dim range As Excel.Range
        Dim wkData(dtWkReportList.Rows.Count - 1, colLength) As Object
        For i = 0 To dtWkReportList.Rows.Count - 1
            For Each col As Integer In htColumns.Keys
                If dtWkReportList.Rows(i).Item(htColumns(col)) Is DBNull.Value Then
                    wkData(i, col - 1) = Nothing
                Else
                    wkData(i, col - 1) = dtWkReportList.Rows(i).Item(htColumns(col))
                End If

            Next
        Next
        '始点
        startRange = DirectCast(xlSheet.Cells(startListRowIndex, 1), Excel.Range)
        '終点
        endRange = DirectCast(xlSheet.Cells(startListRowIndex + UBound(wkData), colLength - 1), Excel.Range)
        'セル範囲
        range = xlSheet.Range(startRange, endRange)

        _lastRowIndex = endRange.Row

        range.Value = wkData
        dtWkReportList.Rows.Clear()

        outPutRowIndex += listRowCountInPagebreak
        startPageListRow = outPutRowIndex
        pageCounter = 0
    End Sub

    ''' <summary>
    ''' エクセルを保存する
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Sub saveAs(ByVal filePath)
        xlSheet = CType(xlBook.Sheets.Item(1), Excel.Worksheet)
        xlSheet.Activate()
        xlBook.SaveAs(filePath)
    End Sub

    ''' <summary>
    ''' Workbookオブジェクトの取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getWorkBook() As Excel.Workbook
        Return xlBook
    End Function

    ''' <summary>
    ''' ページ作成
    ''' </summary>
    ''' <param name="xlWorkSheet"></param>
    ''' <param name="xlWorkSheet2ndPage"></param>
    ''' <param name="dtReportList"></param>
    ''' <param name="listRowCountInFirstPage"></param>
    ''' <param name="rowCountInPage"></param>
    ''' <param name="listRowCountInAfterSecondPage"></param>
    ''' <remarks></remarks>
    Private Shared Sub createPage(ByRef xlWorkSheet As Excel.Worksheet, _
                                  ByRef xlWorkSheet2ndPage As Excel.Worksheet, _
                                  ByVal dtReportList As DataTable, _
                                  ByVal rowCountInPage As Integer, _
                                  ByVal listRowCountInFirstPage As Integer, _
                                  ByVal listRowCountInAfterSecondPage As Integer)
        'ページ数
        Dim pageCount As Integer = 0
        Dim dtRowCount As Integer = dtReportList.Rows.Count
        Dim colPageCount As Integer = xlWorkSheet.Range("PageCount").Column
        Dim rowPageCount As Integer = xlWorkSheet.Range("PageCount").Row
        If Not xlWorkSheet2ndPage Is Nothing And dtRowCount > listRowCountInFirstPage Then
            pageCount += 1
            dtRowCount -= listRowCountInFirstPage
            pageCount += System.Math.Ceiling(dtRowCount / listRowCountInAfterSecondPage)

            xlWorkSheet.Cells(rowPageCount, colPageCount).Value = "'1/" & pageCount

            'ページ追加
            For i = 1 To pageCount - 1
                rowPageCount += rowCountInPage
                xlWorkSheet2ndPage.Range("1:" & rowCountInPage).Copy()
                xlWorkSheet.Range("A" & rowCountInPage * i + 1).Insert(Excel.XlInsertShiftDirection.xlShiftDown)
                xlWorkSheet.Cells(rowPageCount, colPageCount).Value = "'" & i + 1 & "/" & pageCount
            Next
        Else
            pageCount = 1
            xlWorkSheet.Cells(rowPageCount, colPageCount).Value = "'1/1"
        End If
    End Sub

    ''' <summary>
    ''' COMオブジェクト解放
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReleaseComObject(Of T As Class)(ByRef objCom As T, Optional ByVal force As Boolean = False)
        If objCom Is Nothing Then
            Return
        End If
        Try
            If System.Runtime.InteropServices.Marshal.IsComObject(objCom) Then
                If force Then
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objCom)
                Else
                    Dim count As Integer = System.Runtime.InteropServices.Marshal.ReleaseComObject(objCom)
                End If
            End If
        Finally
            objCom = Nothing
        End Try
    End Sub
#End Region
End Class
