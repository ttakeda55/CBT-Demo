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
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            If DialogResult.OK = Common.Message.MessageShow("Q" & Constant.QuestionMessageCode.LogoutConfirm) Then
                DataManager.GetInstance().IsLogouting = True
            Else
                errCode = Constant.ResultCode.Cancel
            End If
        Catch ex As Exception
            'ログ出力
            Dim _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New Logout)
            _Log.Error(ex)
            errCode = Constant.ResultCode.UndefineError
        End Try
        Return errCode
    End Function

End Class
