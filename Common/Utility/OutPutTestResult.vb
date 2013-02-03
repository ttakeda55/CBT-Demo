Public Class OutPutTestResult

    Private _path As String
    Private _dtSynthesisResultHeader As New DataTable
    Private _dtSynthesisResultDetail As New DataTable

    Private _dtTestResultHeader As New DataTable
    Private _dtTestResultDetail As New DataTable

    Private _dtStudent As New DataTable
    Private _groupCode As String

    Sub New(path As String)
        _groupCode = Common.Constant.CST_GROUPNAME
        _path = path
    End Sub

    Sub ReadTestResult()
        Dim fileName As String = ""
        Dim userid As String = ""
        'ヘッダ取得
        For Each filePath As String In IO.Directory.GetFiles(_path, Common.Constant.CST_TESTHEAD_FILENAME & "*")
            fileName = IO.Path.GetFileName(filePath)
            Dim dtTestResultHeader As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            dtTestResultHeader.TableName = fileName
            _dtTestResultHeader.Merge(dtTestResultHeader)
        Next

        '明細取得
        For Each filePath As String In IO.Directory.GetFiles(_path, Common.Constant.CST_TESTDETAIL_FILENAME & "*")
            fileName = IO.Path.GetFileName(filePath)
            Dim dtTestResultDetail As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            dtTestResultDetail.TableName = fileName
            _dtTestResultDetail.Merge(dtTestResultDetail)
        Next
        ReadSynthesisResult()
        ReadStudent()
    End Sub
    Public Sub ReadSynthesisResult()
        Dim fileName As String = ""
        Dim userid As String = ""
        'ヘッダ取得
        For Each filePath As String In IO.Directory.GetFiles(_path, Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & "*")
            fileName = IO.Path.GetFileName(filePath)
            Dim dtSynthesisResultHeader As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            dtSynthesisResultHeader.TableName = fileName
            _dtSynthesisResultHeader.Merge(dtSynthesisResultHeader)
        Next

        '明細取得
        For Each filePath As String In IO.Directory.GetFiles(_path, Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & "*")
            fileName = IO.Path.GetFileName(filePath)
            Dim dtSynthesisResultDetail As DataTable = Serialize.XmlToDataTableFullPath(filePath)
            dtSynthesisResultDetail.TableName = fileName
            _dtSynthesisResultDetail.Merge(dtSynthesisResultDetail)
        Next
    End Sub

    Public Sub ReadStudent()
        Dim fileName As String = ""
        Dim userid As String = ""
        _dtStudent = Common.Student.GetAll()
    End Sub

End Class
