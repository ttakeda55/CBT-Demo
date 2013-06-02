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
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            Dim MenuMode As String = dataBanker("MENUMODE")
            If DialogResult.OK = Common.Message.MessageShow("Q700") Then
                If MenuMode = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then 'システム管理からの遷移
                    Common.DataManager.GetInstance.UpLoadLogFile()
                    If Not Common.DataManager.GetInstance.UpLoadFile() Then
                        Logout = Constant.ResultCode.Cancel
                        Exit Function
                    End If
                Else '団体管理
                    GroupManager.DataManager.GetInstance.UpLoadLogFile()
                    If Not GroupManager.DataManager.GetInstance.UpLoadFile() Then
                        Logout = Constant.ResultCode.Cancel
                        Exit Function
                    End If
                End If

                dataBanker("LOGOUT") = True
            Else
                ret = Constant.ResultCode.Cancel
            End If
        Catch ex As Exception
            writeErrorLog("logout", ex.Message)
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

    ''' <summary>
    ''' エラーログ出力
    ''' </summary>
    ''' <param name="eventName"></param>
    ''' <remarks></remarks>
    Private Shared Sub writeErrorLog(ByVal eventName As String, ByVal exMessage As String)
        Dim filename As String = Application.StartupPath.ToString & "\Error" & System.DateTime.Now.ToShortDateString.Replace("/", "") & ".log"
        Using sw As IO.StreamWriter = New IO.StreamWriter(filename, True)
            sw.Write(System.DateTime.Now & "." & Format(System.DateTime.Now.Millisecond, "000"))
            sw.Write(",")
            sw.Write(eventName)
            sw.Write(",")
            sw.Write(exMessage)
            sw.Write(",")
            sw.Write(Application.ProductVersion)
            sw.Write(vbCrLf)
        End Using
    End Sub
End Class
