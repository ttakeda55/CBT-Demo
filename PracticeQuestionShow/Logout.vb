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

        Dim ret As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            If DialogResult.OK = Common.Message.MessageShow("Q700") Then
                Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                Dim newFIleInfo As Hashtable = getFileInfo()
                Dim oldFileInfo As Hashtable = dataBanker("FILEINFO")
                Dim MenuMode As String = dataBanker("MENUMODE")

                '変更、追加
                For Each Str As String In oldFileInfo.Keys
                    '
                    If newFIleInfo.Contains(Str) Then
                        '更新確認
                        If newFIleInfo(Str) <> oldFileInfo(Str) Then
#If DEBUG Then
                            Debug.WriteLine("[SendFile:" & IO.Path.GetFileName(Str))
#Else

                            ''更新ファイルをアップロード
                            'If Common.FTP.SendFile(Common.Constant.CST_FTP_URL_DATA, IO.Path.GetFileName(Str)) = False Then
                            '    ret = Constant.ResultCode.FtpSendError
                            'End If
#End If
                        End If
                    Else
                        'システム管理からの遷移
                        If MenuMode = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
#If DEBUG Then
                            Debug.WriteLine("[DeleteFile:" & IO.Path.GetFileName(Str))
#Else
                            ''ファイル削除
                            'If Common.FTP.DeleteFile(Common.Constant.CST_FTP_URL_DATA, IO.Path.GetFileName(Str)) = False Then
                            '    ret = Constant.ResultCode.FtpSendError
                            'End If
#End If
                        End If
                    End If
                Next
                'ファイル追加
                For Each Str As String In newFIleInfo.Keys
                    If Not oldFileInfo.Contains(Str) Then
#If DEBUG Then
                        Debug.WriteLine("[SendFile:" & IO.Path.GetFileName(Str))
#Else
                        ''追加ファイルをアップロード確認
                        'If Common.FTP.SendFile(Common.Constant.CST_FTP_URL_DATA, IO.Path.GetFileName(Str)) = False Then
                        '    ret = Constant.ResultCode.FtpSendError
                        'End If
#End If
                    End If
                Next
                dataBanker("LOGOUT") = True
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
