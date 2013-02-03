Public Class Student

    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>ユーザID</summary>
        UserId = 0
        ''' <summary>氏名</summary>
        Name
        ''' <summary>区分1</summary>
        Section1
        ''' <summary>区分2</summary>
        Section2
        ''' <summary>パスワード</summary>
        Password
        ''' <summary>備考</summary>
        Note
        ''' <summary>受験回数</summary>
        TestCount
        ''' <summary>アップロード日時</summary>
        UpLoadDate
        ''' <summary>受講開始日</summary>
        StudentsStart
        ''' <summary>受講終了日</summary>
        StudentsEnd
        ''' <summary>作成日</summary>
        CreateDate
        ''' <summary>更新日</summary>
        UpdateDate
    End Enum

#Region "----- メソッド -----"

    ''' <summary>
    ''' 受講者ファイル読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll() As DataTable
        Dim dtStudent As New DataTable
        For Each fileName As String In IO.Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_STUDENT_FILENAME & "*")
            dtStudent = GetAll(IO.Path.GetFileName(fileName))
            Exit For
        Next

        Return dtStudent
    End Function

    ''' <summary>
    ''' 受講者ファイル読込
    ''' </summary>
    ''' <param name="FileName">受講者ファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Dim studentListData As New DataTable
        Dim studentListSchema As New DataTable
        XmlSchema.GetStudentSchema(studentListSchema)

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            studentListData = Serialize.XmlToDataTable(FileName)
            studentListSchema.Merge(studentListData)
        End If
        Return studentListSchema
    End Function

    ''' <summary>
    ''' 受講者ファイル出力(受験回数更新)
    ''' </summary>
    ''' <param name="testCount">受験回数</param>
    ''' <param name="FileName">受講者ファイル名</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal testCount As String, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True
        Dim dt As DataTable = Nothing

        Try
            '受講者ファイル読込
            dt = GetAll(FileName)
            '受験回数設定
            dt.Rows(0).Item(ColumnIndex.TestCount) = testCount
            'アップロード日時設定
            dt.Rows(0).Item(ColumnIndex.UpLoadDate) = Now.ToString("yyyy/MM/dd HH:mm:dd")
            '受講者ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' 受講者ファイル出力(アップロード日時更新)
    ''' </summary>
    ''' <param name="UpLoadDate">アップロード日時</param>
    ''' <param name="FileName">受講者ファイル名</param>
    ''' <returns>True:正常終了, False:異常終了</returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal UpLoadDate As Date, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True
        Dim dt As DataTable = Nothing

        Try
            '受講者ファイル読込
            dt = GetAll(FileName)
            'アップロード時間設定
            dt.Rows(0).Item(ColumnIndex.UpLoadDate) = UpLoadDate.ToString("yyyy/MM/dd HH:mm:dd")
            '受講者ファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
