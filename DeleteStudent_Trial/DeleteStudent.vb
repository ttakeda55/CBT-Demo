Imports System.IO
Imports System.Threading

''' <summary>
''' Student 監視、各種削除用モジュール
''' </summary>
''' <remarks></remarks>
Public Class DeleteStudent

    ''' <summary>
    ''' 各種処理インターバル
    ''' </summary>
    ''' <remarks></remarks>
    Private Const DELETE_INTERVAL As Integer = 1000

    ''' <summary>
    ''' セットアップファイル
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SETUP_FILE As String = "CBT.msi"
    ''' <summary>
    ''' ログファイル
    ''' </summary>
    ''' <remarks></remarks>
    Private Const MSIEXEC_LOG_FILE As String = "log.txt"

    ''' <summary>処理タイプ(0:クリップボード監視, 0以外:フォルダ削除)</summary>
    Private _ProcessType As Integer = 0

    Private Shared _ZipFile As String = ""

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        '処理タイプ取得
        _ProcessType = My.Application.CommandLineArgs(1)

        PolingTimer.Enabled = True

    End Sub

    ''' <summary>
    ''' 呼び出し元プロセス生存確認、クリップボードクリア用タイマー
    ''' @attention クリップボードクリア後に処理を続行すると、コピーとの衝突により
    ''' PCが固まりやすいので、余計な処理を入れないように注意すること。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PolingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolingTimer.Tick
        Try
            If Me.Visible Then
                Me.Hide()
            End If
            PolingTimer.Enabled = False
            If My.Application.CommandLineArgs.Count > 0 Then

                Dim processId As Integer = My.Application.CommandLineArgs(0)

                '呼び出し元プロセス生存確認
                If FindProcessById(processId) Then
                    If _ProcessType = 0 Then
                        Try
                            PolingTimer.Enabled = True
                            If System.Windows.Forms.Clipboard.GetDataObject Is Nothing = False Then
                                System.Windows.Forms.Clipboard.Clear()
                            End If
                        Catch ex As Exception
                            Console.WriteLine(ex.Message)
                        End Try
                    Else
                        PolingTimer.Enabled = True
                    End If
                Else
                    Close()
                End If
            Else
                Close()
            End If

        Catch ex As Exception
            Close()
        End Try
    End Sub

    ''' <summary>
    ''' フォーム閉じるイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DeleteStudent_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If _ProcessType <> 0 Then

            '削除前にカレントディレクトリを自身のパスにする(カレントが削除対象パスの場合の削除失敗を防ぐ)
            Directory.SetCurrentDirectory(Application.StartupPath)

            'インストールディレクトリの削除
            Dim filePath As String = Application.StartupPath & "\CBT-VetNurse_Trial"
            'なぜか環境によって Student ディレクトリの削除ができないので、ディレクトリが無いか、中身が空の場合正常終了とする。
            While Directory.Exists(filePath)
                Try
                    Dim di As New DirectoryInfo(filePath)
                    If di.GetFiles().Length = 0 AndAlso di.GetDirectories().Length = 0 Then
                        Exit While
                    End If

                    DeleteDirectory(filePath)

                    Thread.Sleep(DELETE_INTERVAL)
                Catch ex As Exception
                    Thread.Sleep(DELETE_INTERVAL)
                End Try
            End While

            Dim tempPath As String = GetTempPath()
            '前回のLogを削除
            If System.IO.File.Exists(tempPath & "..\" & MSIEXEC_LOG_FILE) Then
                Do
                    Try
                        System.IO.File.Delete(tempPath & "..\" & MSIEXEC_LOG_FILE)
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                        Thread.Sleep(DELETE_INTERVAL)
                    End Try
                Loop Until (Not System.IO.File.Exists(tempPath & "..\" & MSIEXEC_LOG_FILE))
            End If
            '前回のmsiを削除
            If System.IO.File.Exists(tempPath & "..\" & SETUP_FILE) Then
                Do
                    Try
                        System.IO.File.Delete(tempPath & "..\" & SETUP_FILE)
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                        Thread.Sleep(DELETE_INTERVAL)
                    End Try
                Loop Until (Not System.IO.File.Exists(tempPath & "..\" & SETUP_FILE))
            End If
            '新msiをコピー
            If System.IO.File.Exists(tempPath & SETUP_FILE) Then
                Do
                    Try
                        System.IO.File.Copy(tempPath & SETUP_FILE, tempPath & "..\" & SETUP_FILE)
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                        Thread.Sleep(DELETE_INTERVAL)
                    End Try
                Loop Until (System.IO.File.Exists(tempPath & "..\" & SETUP_FILE))
            End If

            'Tempデータディレクトリの削除
            While (System.IO.Directory.Exists(tempPath))
                Try
                    DeleteDirectory(tempPath)
                Catch ex As Exception
                    Thread.Sleep(DELETE_INTERVAL)
                End Try
            End While

            'DeletStudentの削除
            Try
                DelProcessBat(Application.ProductName)
            Catch ex As Exception
                Thread.Sleep(DELETE_INTERVAL)
            End Try

        End If


    End Sub


    ''' <summary>
    ''' 指定のプロセスIDが存在するかどうか
    ''' </summary>
    ''' <param name="processId">検索するプロセスID</param>
    ''' <returns>true : 存在する、 false : 存在しない</returns>
    ''' <remarks></remarks>
    Private Function FindProcessById(ByVal processId As Integer) As Boolean
        Dim ret As Boolean = False

        Dim processes() As Process = Process.GetProcesses()
        For Each Process As Process In processes
            If Process.Id = processId Then
                ret = True
                Exit For
            End If
        Next

        Return ret
    End Function

    '別DLLに依存した場合ファイルの削除に失敗するので自前で実装する
    ''' <summary>
    ''' フォルダを根こそぎ削除する（ReadOnlyでも削除）
    ''' </summary>
    ''' <param name="dir">削除するフォルダ</param>
    Private Shared Sub DeleteDirectory(ByVal dir As String)
        If Directory.Exists(dir) Then
            'DirectoryInfoオブジェクトの作成
            Dim di As New DirectoryInfo(dir)

            'フォルダ以下のすべてのファイル、フォルダの属性を削除
            RemoveReadonlyAttribute(di)

            'フォルダを根こそぎ削除
            Try
                di.Delete(True)
            Catch ex As Exception
                'Zipファイルを削除
                DeleteZipFile()
                'フォルダを根こそぎ削除
                di.Delete(True)
            End Try
        End If
    End Sub

    Private Shared Sub RemoveReadonlyAttribute( _
            ByVal dirInfo As DirectoryInfo)
        '基のフォルダの属性を変更
        If (dirInfo.Attributes And FileAttributes.ReadOnly) =
            FileAttributes.ReadOnly Then
            dirInfo.Attributes = FileAttributes.Normal
        End If
        'フォルダ内のすべてのファイルの属性を変更
        Dim fi As FileInfo
        For Each fi In dirInfo.GetFiles()
            If fi.Extension = ".zip" Then _ZipFile = fi.FullName
            If (fi.Attributes And FileAttributes.ReadOnly) =
                FileAttributes.ReadOnly Then
                fi.Attributes = FileAttributes.Normal
            End If
        Next fi
        'サブフォルダの属性を回帰的に変更
        Dim di As DirectoryInfo
        For Each di In dirInfo.GetDirectories()
            RemoveReadonlyAttribute(di)
        Next di
    End Sub

    ''' <summary>
    ''' 一時フォルダパスを取得する
    ''' </summary>
    Private Shared Function GetTempPath() As String
        If Not System.IO.Directory.Exists(Path.GetTempPath & "Student_VetNorse_demo\") Then
            System.IO.Directory.CreateDirectory(Path.GetTempPath & "Student_VetNorse_demo\")
        End If
        Return Path.GetTempPath & "Student_VetNorse_demo\"
    End Function

    ''' <summary>
    ''' Zipファイル削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub DeleteZipFile()
        Dim zipPath As String = Application.StartupPath & "\" & Path.GetFileNameWithoutExtension(_ZipFile)
        Dim zipFileName As String = Application.StartupPath & "\"
        zipFileName += Path.GetFileName(_ZipFile)

        If Not Directory.Exists(zipPath) Then Directory.CreateDirectory(zipPath)
        'ダミーファイル削除
        Dim hsr As FileStream = File.Create(zipPath & "\damy")
        If Not hsr Is Nothing Then
            hsr.Close()
            Dim cDisposable As System.IDisposable = hsr
            cDisposable.Dispose()
        End If
        Using zip As New Ionic.Zip.ZipFile
            '圧縮レベル変更
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression
            'フォルダ追加
            zip.AddDirectory(zipPath)
            'ZIP書庫作成
            zip.Save(zipFileName)
        End Using
        'ファイル移動
        My.Computer.FileSystem.MoveFile(_ZipFile, zipFileName, True)
        'ファイル削除
        My.Computer.FileSystem.DeleteFile(zipFileName)
        'ディレクトリ削除
        My.Computer.FileSystem.DeleteDirectory(zipPath, FileIO.DeleteDirectoryOption.DeleteAllContents)

    End Sub

    ''' <summary>
    ''' 削除バッチ起動
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DelProcessBat(ByVal processName As String)
        Dim Vbs As String = ""
        Vbs += "Option Explicit" + vbCrLf
        Vbs += "On Error Resume Next" + vbCrLf
        Vbs += "Dim objWshShell     ' WshShell オブジェクト" + vbCrLf
        Vbs += "Dim strCmdLine      ' 実行するコマンド" + vbCrLf
        Vbs += "Dim objExecCmd      ' 実行コマンド情報" + vbCrLf
        Vbs += "Dim myNum           ' カウント" + vbCrLf
        Vbs += "Dim objFSO          ' FileSystemObject" + vbCrLf
        Vbs += "Dim strDelFile      ' 削除するファイル名" + vbCrLf

        Vbs += "Set objWshShell = WScript.CreateObject(""WScript.Shell"")" + vbCrLf
        Vbs += "If Err.Number = 0 Then" + vbCrLf
        'Vbs += "    strCmdLine = ""msiexec /x """"" + Path.GetTempPath + SETUP_FILE + """""" + " /log " + Path.GetTempPath + MSIEXEC_LOG_FILE + """" + vbCrLf
        Vbs += "    strCmdLine = ""msiexec /x """"" + Path.GetTempPath + SETUP_FILE + """""" + " /qr /log """"" + Path.GetTempPath + MSIEXEC_LOG_FILE + """""""" + vbCrLf
        Vbs += "    objExecCmd = objWshShell.Run(strCmdLine)" + vbCrLf
        Vbs += "End If" + vbCrLf

        Vbs += "objFSO = Nothing" + vbCrLf
        Vbs += "objExecCmd = Nothing" + vbCrLf
        Vbs += "objWshShell = Nothing" + vbCrLf
        IO.File.WriteAllText(Path.GetTempPath + processName + ".vbs", Vbs)

        Dim content As String = ""
        content += "REM " + processName + vbCrLf
        content += """" + Path.GetTempPath + processName + ".vbs""" + vbCrLf
        content += "ECHO NEXT DELETE" + vbCrLf
        content += "DEl """ + Path.GetTempPath + processName + ".vbs""" + vbCrLf
        content += "DEl %0" + vbCrLf
        IO.File.WriteAllText(Path.GetTempPath + processName + ".BAT", content)
#If DEBUG Then
#Else
        Dim p As System.Diagnostics.Process = New System.Diagnostics.Process()
        p.StartInfo.CreateNoWindow = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.FileName = Path.GetTempPath + processName + ".BAT"
        p.Start()
#End If
    End Sub
End Class
