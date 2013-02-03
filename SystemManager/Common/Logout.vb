Imports System.IO

''' <summary>
''' ログアウト共通処理
''' </summary>
''' <remarks></remarks>
Public Class Logout
    ''' <summary>
    ''' ログアウト共通処理
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Logout() As Constant.ResultCode
        Dim ret As Integer = Constant.ResultCode.NormalEnd

        Try
            If DialogResult.OK = Common.Message.MessageShow("Q700") Then
                Common.DataManager.GetInstance.UpLoadLogFile()
                If Not Common.DataManager.GetInstance.UpLoadFile() Then
                    Logout = Constant.ResultCode.Cancel
                    Exit Function
                End If
                CBTCommon.DataBanker.GetInstance("LOGOUT") = True
            Else
                ret = Constant.ResultCode.Cancel
            End If
        Catch ex As Exception
            ret = Constant.ResultCode.UndefineError
        End Try
        Return ret

    End Function

    ''' <summary>
    ''' ファイル情報の取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function getFileInfo() As Hashtable
        Dim files As String() = System.IO.Directory.GetFiles(Common.Constant.GetTempPath, "*", System.IO.SearchOption.TopDirectoryOnly)
        Dim htFileInfo As New Hashtable
        For Each fileName As String In files
            htFileInfo.Add(fileName, System.IO.File.GetLastWriteTime(fileName))
        Next

        Return htFileInfo
    End Function
End Class
