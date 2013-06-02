Imports System.Runtime.Remoting
''' <summary>
''' メニュー
''' </summary>
''' <remarks>menu.xmlを基に画面遷移を行う</remarks>
Public Class frmMenu
    Inherits BaseControl.frmMenuBase
#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            logger.Start()
            processMessageLogout = True
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
            End Select
            processMessageLogout = False
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

End Class