Public Class Group

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>団体コード</summary>
        GroupCode = 0
        ''' <summary>団体名</summary>
        GroupName
        ''' <summary>申込者</summary>
        Applicant
        ''' <summary>コース名</summary>
        Course
        ''' <summary>受講者数</summary>
        StudentCount
        ''' <summary>受講開始日</summary>
        TestStart
        ''' <summary>受講終了日</summary>
        TestEnd
        ''' <summary>団体管理者ID</summary>
        GroupManagerId
        ''' <summary>団体管理者名</summary>
        GroupManagerName
        ''' <summary>パスワード</summary>
        Password
        ''' <summary>状態</summary>
        State
        'Add 2012/03/30 WITH21 2期開発 Start -----
        ''' <summary>初回試験開始日</summary>
        FirstStartDay
        ''' <summary>初回試験終了日</summary>
        FirstEndDay
        ''' <summary>再試験開始日</summary>
        SecondStartDay
        ''' <summary>再試験終了日</summary>
        SecondEndDay
        ''' <summary>コース番号</summary>
        CourseNo
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
        'Add 2012/03/30 WITH21 2期開発 End   -----
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 団体ファイル読込
    ''' </summary>
    ''' <param name="FileName">団体ファイル名</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Return Serialize.XmlToDataTable(FileName)
    End Function

    ''' <summary>
    ''' 受験期間取得
    ''' </summary>
    ''' <param name="FileName">団体ファイル名</param>
    ''' <param name="testStart">受験開始日</param>
    ''' <param name="testEnd">受験終了日</param>
    ''' <returns>成功：True、失敗：False</returns>
    ''' <remarks></remarks>
    Public Shared Function GetTestPeriod(ByVal FileName As String, ByRef testStart As String, ByRef testEnd As String) As Boolean
        Dim blnRet As Boolean = True
        Dim group As DataTable = Nothing

        Try
            '初期化
            testStart = ""
            testEnd = ""
            '団体ファイル読込
            group = GetAll(FileName)
            '受験開始日取得
            testStart = group.Rows(0).Item(ColumnIndex.TestStart)
            '受験終了日取得
            testEnd = group.Rows(0).Item(ColumnIndex.TestEnd)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    Public Shared Sub OutPutCategory()
        Dim dtGroup As New DataTable
        GetGroupSchema(dtGroup)
        Dim drGroup As DataRow = dtGroup.NewRow

        For Each col As DataColumn In drGroup.Table.Columns
            drGroup.Item(col) = ""
        Next
        drGroup.Item(ColumnIndex.GroupCode) = Common.Constant.CST_GROUPNAME
        drGroup.Item(ColumnIndex.GroupName) = "動物看護師認定試験"
        drGroup.Item(ColumnIndex.GroupManagerId) = "d"
        drGroup.Item(ColumnIndex.Password) = "d"
        dtGroup.Rows.Add(drGroup)
        WriteXML(dtGroup, Common.Constant.CST_GROUP_FILENAME & Common.Constant.CST_GROUPNAME & ".xml")
    End Sub

    ''' <summary>
    ''' 団体のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetGroupSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Group)
        dt.ReadXmlSchema(ts)
    End Sub
    ''' <summary>
    ''' 模擬テスト一覧ファイル出力
    ''' </summary>
    ''' <param name="dt">模擬テスト一覧データ格納DataTable</param>
    ''' <param name="FileName">模擬テスト一覧ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            '模擬テスト一覧ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function
#End Region

End Class
