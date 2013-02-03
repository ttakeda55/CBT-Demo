Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' シリアライズ、デシリアライズを行う
''' </summary>
Public Class Serialize
    ''' <summary>ログオブジェクト</summary>
    Private Shared ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger("Serialize")

    Private Shared tempPath As String = Constant.GetTempPath
    ''' <summary>
    ''' オブジェクトからバイナリファイルに変換する
    ''' </summary>
    Public Shared Sub ObjectToBinaryFile(ByVal obj As Object, ByVal fileName As String)
        'オブジェクトの内容をファイルに保存する
        logger.Info("Start:ObjectToBinaryFile FileName" & fileName)
        SaveToBinaryFile(obj, tempPath & fileName)
        logger.Info("End:ObjectToBinaryFile FileName" & fileName)
    End Sub

    ''' <summary>
    ''' バイナリファイルからオブジェクトに変換する
    ''' </summary>
    Public Shared Function BinaryFileToObject(ByVal fileName As String) As Object
        'オブジェクトの内容をファイルから読み込み復元する
        Return LoadFromBinaryFile(tempPath & fileName)
    End Function

    ''' <summary>
    ''' xmlからDataTableに変換する
    ''' </summary>
    Public Shared Function XmlToDataTable(ByVal fileName As String) As DataTable
        Dim ds As New DataSet
        ds.ReadXml(tempPath & fileName)
        Return ds.Tables(0)
    End Function

    ''' <summary>
    ''' DataTableからxmlに変換する
    ''' </summary>
    Public Shared Sub DataTableToxml(ByVal dt As DataTable, ByVal fileName As String)
        logger.Info("Start:DataTableToxml FileName" & fileName)
        dt.WriteXml(tempPath & fileName)
        logger.Info("End:DataTableToxml FileName" & fileName)
    End Sub

    ''' <summary>
    ''' xmlからDataTableに変換する
    ''' </summary>
    Public Shared Function XmlToDataTableFullPath(ByVal filePath As String) As DataTable
        Dim ds As New DataSet
        ds.ReadXml(filePath)
        Return ds.Tables(0)
    End Function

    ''' <summary>
    ''' DataTableからxmlに変換する
    ''' </summary>
    Public Shared Sub DataTableToxmlFullPath(ByVal dt As DataTable, ByVal filePath As String)
        logger.Info("Start:DataTableToxmlFullPath FileName" & filePath)
        dt.WriteXml(filePath)
        logger.Info("End:DataTableToxmlFullPath FileName" & filePath)
    End Sub

    ''' <summary>
    ''' オブジェクトの内容をファイルから読み込み復元する
    ''' </summary>
    ''' <param name="path">読み込むファイル名</param>
    ''' <returns>復元されたオブジェクト</returns>
    Public Shared Function LoadFromBinaryFile(ByVal path As String) As Object
        Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read)
        Dim f As New BinaryFormatter
        '読み込んで逆シリアル化する
        Dim obj As Object = f.Deserialize(fs)
        fs.Close()

        Return obj
    End Function

    ''' <summary>
    ''' オブジェクトの内容をファイルに保存する
    ''' </summary>
    ''' <param name="obj">保存するオブジェクト</param>
    ''' <param name="path">保存先のファイル名</param>
    Public Shared Sub SaveToBinaryFile( _
        ByVal obj As Object, ByVal path As String)
        Dim fs As New FileStream( _
            path, FileMode.Create, FileAccess.Write)
        Dim bf As New BinaryFormatter
        'シリアル化して書き込む
        bf.Serialize(fs, obj)
        fs.Close()
    End Sub
End Class