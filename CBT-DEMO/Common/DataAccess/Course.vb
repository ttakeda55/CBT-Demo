''' <summary>
''' コース
''' </summary>
''' <remarks></remarks>
Public Class Course

#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>コース番号</summary>
        CourseNo = 0
        ''' <summary>コース名</summary>
        Course
        ''' <summary>対応模擬テスト</summary>
        MockTestNo
        ''' <summary>問題群NO</summary>
        CollectionNo
        ''' <summary>利用開始日</summary>
        UseStart
        ''' <summary>利用終了日</summary>
        UseEnd
        ''' <summary>状態</summary>
        State
        ''' <summary>作成日</summary>
        Create_Date
        ''' <summary>更新日</summary>
        Update_Date
    End Enum
#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>コースデータ格納DataTable</summary>
    Private Shared _CourseData As New DataTable

#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>コンストラクタ</summary>
    Public Sub New()
        Try
            Call XmlSchema.GetTestResultDetailSchema(_CourseData)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' コースファイル読込
    ''' </summary>
    ''' <param name="FileName">コースファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAll(ByVal FileName As String) As DataTable
        Common.XmlSchema.GetCourseSchema(_CourseData)

        If IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
            _CourseData = Serialize.XmlToDataTable(FileName)
        End If
        Return _CourseData
    End Function

    ''' <summary>
    ''' コースファイル出力
    ''' </summary>
    ''' <param name="dt">コースデータ格納DataTable</param>
    ''' <param name="FileName">コースファイル名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteXML(ByVal dt As DataTable, ByVal FileName As String) As Boolean
        Dim blnRet As Boolean = True

        Try
            'コースファイル出力
            Call Serialize.DataTableToxml(dt, FileName)
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

#End Region

End Class
