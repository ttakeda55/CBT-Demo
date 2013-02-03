Imports CST.CBT.eIPSTA.Common
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' ファイルダウンロード共通処理
''' </summary>
''' <remarks></remarks>
Public Class FileDownLoad

#Region "----- 定数 -----"
    ''' <summary>処理インターバル</summary>
    Private Const DELETE_INTERVAL As Integer = 1000
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ダウンロードリスト</summary>
    Private _DownLoadList As Generic.Dictionary(Of Integer, String)
    '2012/06/13 WITH21 ADD S
    ''' <summary>ログ出力オブジェクト</summary>
    Private Shared ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New FileDownLoad)
    '2012/06/13 WITH21 ADD E
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' 演習問題取得（コレクション）
    ''' </summary>
    ''' <param name="files">演習問題リスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getQuestionCollection(ByVal files As List(Of String)) As Boolean
        Dim ret As Boolean = False
        Dim wsv = New WebService.Student
        Dim contents As Byte() = Nothing
        Dim passName As String = ""

        Try
            Dim questionCollection As Object() = Nothing

            ' 演習問題コレクションダウンロード
            wsv = DataManager.GetInstance.WebService
            'wsv.Url = DataManager.GetInstance.WebServiceUrl
            'ret = wsv.QuestionCollectionDownLoad(files.ToArray, questionCollection)
            Dim data As Byte() = Nothing
            ret = wsv.QuestionCollectionDownLoad(files.ToArray, data)
            Dim mem As New IO.MemoryStream
            mem.Position = 0
            mem.Write(data, 0, data.Length)
            Dim bf As New BinaryFormatter
            mem.Position = 0
            Dim QuestionBanCol As List(Of Common.PracticeQuestionBankCollection) = CType(bf.Deserialize(mem), List(Of Common.PracticeQuestionBankCollection))
            ' オブジェクトの内容をファイルに保存
            Dim fileName As String = ""
            For Each Col As Common.PracticeQuestionBankCollection In QuestionBanCol
                For Each fileName In files
                    Dim qCode As String = fileName.Replace(Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME, "")
                    qCode = qCode.Replace(Common.Constant.CST_PRACTICEQUESTION_FILENAME, "")
                    If qCode = Col.Item(0).QuestionCode Then Exit For
                Next
                Dim path As String = Common.Constant.GetTempPath & fileName
                Serialize.SaveToBinaryFile(Col, path)
            Next
        Catch ex As Exception
            '2012/06/13 WITH21 ADD S
            _Log.Error(ex)
            '2012/06/13 WITH21 ADD E
            Throw ex
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' 演習問題取得（圧縮ファイル）
    ''' </summary>
    ''' <param name="files">演習問題リスト</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getQuestionZip(ByVal files As List(Of String)) As Boolean
        Dim ret As Boolean = False
        Dim wsv = New WebService.Student
        Dim fileName As String = ""
        Dim passName As String = ""
        Dim contents As Byte() = Nothing
        Dim downLoadZipName As String = ""

        Try
            ' 圧縮ファイル名の作成
            downLoadZipName = Constant.DownLoadZipName & DataManager.GetInstance().GroupCode & DataManager.GetInstance().UserId

            '演習問題圧縮ファイルダウンロード
            'wsv.Url = DataManager.GetInstance.WebServiceUrl
            wsv = DataManager.GetInstance.WebService
            ret = wsv.QuestionZipDownLoad(downLoadZipName, files.ToArray, contents)

            '圧縮ファイルを解凍
            passName = Common.Constant.GetTempPath + Constant.DownLoadDirectoryName & "\"
            '削除
            DeleteDirectory(passName)
            If Not IO.Directory.Exists(passName) Then
                IO.Directory.CreateDirectory(passName)
            End If
            fileName = passName + downLoadZipName + ".zip"
            IO.File.WriteAllBytes(fileName, contents)
            '解凍実行
            Extract(fileName, passName)
            'ファイルコピー
            CopyFile(passName, files)
        Catch ex As Exception
            '2012/06/13 WITH21 ADD S
            _Log.Error(ex)
            '2012/06/13 WITH21 ADD E
            Throw ex
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' 解凍処理
    ''' </summary>
    ''' <param name="zipFile">ZIPファイル</param>
    ''' <param name="dstPath">解凍するFolder</param>
    ''' <remarks></remarks>
    Public Shared Sub Extract(ByVal zipFile As String, ByVal dstPath As String)
        'ZipFileを作成する 
        Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(zipFile)

            '展開先に同名のファイルがあれば上書きする 
            zip.ExtractExistingFile = Ionic.Zip.ExtractExistingFileAction.OverwriteSilently

            'ZIP書庫内のエントリを取得 
            For Each entry As Ionic.Zip.ZipEntry In zip
                'エントリを展開する 
                entry.Extract(dstPath)
            Next
        End Using
    End Sub

    ''' <summary>
    ''' ディレクトリ削除処理
    ''' </summary>
    ''' <param name="dir"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteDirectory(ByVal dir As String)
        Try
            If IO.Directory.Exists(dir) Then
                'DirectoryInfoオブジェクトの作成
                Dim di As New IO.DirectoryInfo(dir)

                'フォルダ以下のすべてのファイル、フォルダの属性を削除
                RemoveReadonlyAttribute(di)

                'フォルダを根こそぎ削除
                di.Delete(True)
            End If
        Catch ex As Exception
            '2012/06/13 WITH21 CHG S
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            _Log.Error(ex)
            '例外処理
            Dim ret = DeleteZipFile(dir)
            'ディレクトリ削除処理
            If ret Then DeleteDirectory(dir)
            '2012/06/13 WITH21 CHG E
        End Try
    End Sub

    ''' <summary>
    ''' 属性削除処理
    ''' </summary>
    ''' <param name="dirInfo"></param>
    ''' <remarks></remarks>
    Public Shared Sub RemoveReadonlyAttribute(ByVal dirInfo As IO.DirectoryInfo)
        Try
            '基のフォルダの属性を変更
            If (dirInfo.Attributes And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                dirInfo.Attributes = IO.FileAttributes.Normal
            End If
            'フォルダ内のすべてのファイルの属性を変更
            Dim fi As IO.FileInfo
            For Each fi In dirInfo.GetFiles()
                If (fi.Attributes And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                    fi.Attributes = IO.FileAttributes.Normal
                End If
            Next fi
            'サブフォルダの属性を回帰的に変更
            Dim di As IO.DirectoryInfo
            For Each di In dirInfo.GetDirectories()
                RemoveReadonlyAttribute(di)
            Next di
        Catch ex As Exception
            '2012/06/13 WITH21 CHG S
            _Log.Error(ex)
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '2012/06/13 WITH21 CHG E
        End Try
    End Sub

    ''' <summary>
    ''' コピー処理
    ''' </summary>
    ''' <param name="directoryName">コピー先ディレクトリ</param>
    ''' <param name="files">ファイル名リスト</param>
    ''' <remarks></remarks>
    Public Shared Sub CopyFile(ByVal directoryName As String, ByVal files As List(Of String))
        For Each filename As String In files
            My.Computer.FileSystem.CopyFile(directoryName & filename, Common.Constant.GetTempPath & filename, True)
        Next
    End Sub

    '2012/06/13 WITH21 ADD S
    ''' <summary>
    ''' 圧縮ファイル削除処理（例外処理）
    ''' </summary>
    ''' <param name="dir"></param>
    ''' <remarks></remarks>
    Public Shared Function DeleteZipFile(ByVal dir As String) As Boolean
        Dim ret As Boolean = True
        Dim PathName As String = ""
        Dim ZipName As String = ""
        Dim FileName As String = ""

        Try
            '圧縮ファイル名
            ZipName = Constant.DownLoadZipName & DataManager.GetInstance().GroupCode & DataManager.GetInstance().UserId & ".zip"
            '圧縮ファイル存在チェック
            If Not IO.File.Exists(dir & ZipName) Then
                Return False
            End If

            '一時ディレクトリパス
            PathName = Common.Constant.GetTempPath & "temp"
            '一時圧縮ファイル名
            FileName = PathName & "\" & ZipName

            If Not Directory.Exists(PathName) Then Directory.CreateDirectory(PathName)
            'ダミーファイル作成
            Dim hsr As FileStream = File.Create(PathName & "\damy")
            If Not hsr Is Nothing Then
                hsr.Close()
                Dim cDisposable As System.IDisposable = hsr
                cDisposable.Dispose()
            End If
            'ダミーファイル圧縮
            Using zip As New Ionic.Zip.ZipFile
                '圧縮レベル変更
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
                'フォルダ追加
                zip.AddDirectory(PathName)
                'ZIP書庫作成
                zip.Save(FileName)
            End Using

            'ファイル移動
            My.Computer.FileSystem.MoveFile(dir & ZipName, FileName, True)
            'ファイル削除
            My.Computer.FileSystem.DeleteFile(FileName)
            'ディレクトリ削除
            My.Computer.FileSystem.DeleteDirectory(PathName, FileIO.DeleteDirectoryOption.DeleteAllContents)

        Catch ex As Exception
            _Log.Error(ex)
            ret = False
        End Try
        Return ret
    End Function
    '2012/06/13 WITH21 ADD E
#End Region
End Class

