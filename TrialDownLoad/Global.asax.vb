Imports System.Web.SessionState

''' <summary>
''' 共通処理
''' </summary>
''' <remarks></remarks>
Public Class Global_asax
    Inherits System.Web.HttpApplication

#Region "イベント"
    ''' <summary>
    ''' 各要求開始時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>ダウンロードとログイン時にログを取得する</remarks>
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Try
            writeEventLog(System.Reflection.MethodBase.GetCurrentMethod().Name)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 要求終了時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub Application_OnEndRequest(ByVal sender As Object, ByVal e As EventArgs)
        Try
            writeEventLog(System.Reflection.MethodBase.GetCurrentMethod().Name)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' エラー発生時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        writeErrorLog(System.Reflection.MethodBase.GetCurrentMethod().Name)
    End Sub
#End Region

#Region "メソッド"
    ''' <summary>
    ''' イベントログ書き込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub writeEventLog(ByVal methodName As String)
        If Not IO.Directory.Exists(Request.PhysicalApplicationPath.ToString & "log") Then
            IO.Directory.CreateDirectory(Request.PhysicalApplicationPath.ToString & "log")
        End If
        Dim fileName As String = Request.PhysicalApplicationPath.ToString & "log\Event" & System.DateTime.Now.ToShortDateString.Replace("/", "") & ".csv"

        Application.Lock()
        Using sw As New System.IO.StreamWriter(fileName, True, Encoding.GetEncoding("Shift_JIS"))
            sw.Write(Format(System.DateTime.Now, "yyyy/MM/dd HH:mm:ss.fff"))
            sw.Write(",")
            sw.Write(methodName)
            sw.Write(",")
            sw.Write(",")
            sw.Write(",")
            sw.Write(Request.ServerVariables("REMOTE_ADDR"))
            sw.Write(",")
            sw.Write("""" & Request.UserAgent & """")
            sw.Write(",")
            sw.Write(Request.Url)
            sw.Write(",")
            sw.Write(Request.ServerVariables("REMOTE_USER"))
            sw.Write(vbCrLf)
        End Using
        Application.UnLock()
    End Sub

    ''' <summary>
    ''' エラーログ書き込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub writeErrorLog(ByVal methodName As String)
        If Not IO.Directory.Exists(Request.PhysicalApplicationPath.ToString & "log") Then
            IO.Directory.CreateDirectory(Request.PhysicalApplicationPath.ToString & "log")
        End If
        Dim fileName As String = Request.PhysicalApplicationPath.ToString & "log\Error" & System.DateTime.Now.ToShortDateString.Replace("/", "") & ".csv"
        Dim err As Exception = Server.GetLastError().InnerException

        Application.Lock()
        If Not err Is Nothing Then
            Using sw As New System.IO.StreamWriter(fileName, True, Encoding.GetEncoding("Shift_JIS"))
                sw.Write(Format(System.DateTime.Now, "yyyy/MM/dd HH:mm:ss.fff"))
                sw.Write(",")
                sw.Write("""" & err.StackTrace & """")
                sw.Write(",")
                sw.Write(err.Message)
                sw.Write(",")
                sw.Write(Request.ServerVariables("REMOTE_ADDR"))
                sw.Write(",")
                sw.Write(methodName)
                sw.Write(",")
                sw.Write("""" & Request.UserAgent & """")
                sw.Write(",")
                sw.Write(Request.Url)
                sw.Write(",")
                sw.Write(Request.ServerVariables("REMOTE_USER"))
                sw.Write(vbCrLf)
            End Using
        End If
        Application.UnLock()
    End Sub
#End Region

End Class