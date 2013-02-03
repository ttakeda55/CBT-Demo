Imports System.IO

''' <summary>
''' 模擬説明共通処理
''' </summary>
''' <remarks></remarks>
Public Class InstructionCommon
    ''' <summary>
    ''' 模擬説明ファイル取得
    ''' </summary>
    ''' <param name="helpFilePath">模擬説明ファイルパス</param>
    ''' <param name="helpFileList">取得する模擬説明ファイルリスト</param>
    ''' <remarks></remarks>
    Public Shared Sub GetHelpFile(ByVal helpFilePath As String, ByRef helpFileList As SortedList)
        Dim filePath As String = ""
        Dim searchPattern As String = ""
        Dim fileNameList() As String = Nothing
        Dim i As Integer = 0

        Try
            '検索文字列作成
            searchPattern = "Help*"
            'ディレクトリ存在チェック
            If Not Directory.Exists(helpFilePath) Then
                Dim errCode As String = "E" & Constant.ResultCode.HelpDirectoryNotFoundError
                Common.Message.MessageShow(errCode)
                Exit Sub
            End If
            'ファイル検索
            fileNameList = Directory.GetFiles(helpFilePath, searchPattern)
            If Not IsNothing(fileNameList) Then
                For i = 0 To fileNameList.Length - 1
                    '操作説明ファイルリスト追加
                    helpFileList.Add(Path.GetFileNameWithoutExtension(fileNameList(i)), Path.GetFileName(fileNameList(i)))
                Next i
            Else
                Dim errCode As String = "E" & Constant.ResultCode.HelpFileNotFoundError
                Common.Message.MessageShow(errCode)
            End If
        Catch ex As Exception
            helpFileList.Clear()
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 模擬操作説明表示
    ''' </summary>
    ''' <param name="index">模擬説明ファイルリストのインデックス番号</param>
    ''' <param name="helpFilePath">模擬説明ファイルパス</param>
    ''' <param name="helpFileList">模擬説明ファイルリスト</param>
    ''' <param name="webInstruction">表示するウェブブラウザ</param>
    ''' <remarks></remarks>
    Public Shared Sub SetNavigate(ByVal index As Integer, ByVal helpFilePath As String, ByVal helpFileList As SortedList, ByRef webInstruction As BaseControl.UserWebBrowser)
        Dim path As String = ""

        Try
            If index >= 0 AndAlso index <= helpFileList.Count - 1 Then
                path = helpFilePath & "\" & helpFileList.GetByIndex(index).ToString
                '操作説明表示
                webInstruction.url = New Uri(path)
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub


End Class
