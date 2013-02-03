Imports CST.CBT.eIPSTA.Common

Public Class BaseMainForm
    Inherits BaseForm
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    Private _MenuMode As Boolean
    Private _DialogMode As Boolean = True

    Public Property UserId
        Get
            Return lblUserId.Text
        End Get
        Set(ByVal value)
            dataBanker("USERID") = value
            lblUserId.Text = value
        End Set
    End Property

    Public Property UserName
        Get
            Return lblUserName.Text
        End Get
        Set(ByVal value)
            dataBanker("USERNAME") = value
            lblUserName.Text = value
        End Set
    End Property

    Public ReadOnly Property MailLabel As Label
        Get
            Return lblMail
        End Get
    End Property

    Public ReadOnly Property UserSetLabel As Label
        Get
            Return lblUserSet
        End Get
    End Property

    Public ReadOnly Property HelpLabel As Label
        Get
            Return lblHelp
        End Get
    End Property

    Public ReadOnly Property LogoutLabel As Label
        Get
            Return lblLogout
        End Get
    End Property

    ''' <summary>
    ''' メニューモードプロパティ
    ''' </summary>
    Public Property MenuMode As Boolean
        Get
            Return _MenuMode
        End Get
        Set(ByVal value As Boolean)
            _MenuMode = value
            menuDisply(value)
        End Set
    End Property

    ''' <summary>
    ''' ダイアログプロパティ
    ''' </summary>
    Public Property DialogMode As Boolean
        Get
            Return _DialogMode
        End Get
        Set(ByVal value As Boolean)
            _DialogMode = value
            chengeManuDialog(value)
        End Set
    End Property

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    Private Sub BaseMainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'メニューの表示を変更する
        If dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_SYSTEM Then
            chengeManu()
        End If
        If dataBanker("USERID") <> String.Empty Then
            UserId = dataBanker("USERID")
        End If
        If dataBanker("USERNAME") <> String.Empty Then
            UserName = dataBanker("USERNAME")
        End If
        Me.Activate()
    End Sub

    ''' <summary>
    ''' ログアウトクリックイベント
    ''' </summary>
    Private Sub lblLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLogout.Click
        OnLogout()
    End Sub


    ''' <summary>
    ''' メール画面が閉じた
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub mailClosed()
    End Sub

    ''' <summary>
    ''' ユーザクリックイベント
    ''' </summary>
    Private Sub lblUserSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUserSet.Click
        Dim f As Form = Form.ActiveForm
        Dim frm As New frmUser
        frm.ShowDialog(Me)
    End Sub

    ''' <summary>
    ''' ヘルプクリックイベント
    ''' </summary>
    Private Sub lblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHelp.Click
        Me.Cursor = Cursors.WaitCursor
        'If ftpDownLoadHelp() = String.Empty Then
        '    Exit Sub
        'End If
#If DEBUG Then
#Else
        If downLoadHelp() = String.Empty Then
            Exit Sub
        End If
#End If
        Me.Cursor = Cursors.Arrow
        For Each fileName As String In System.IO.Directory.GetFiles(Common.Constant.GetTempPath, "Help*", System.IO.SearchOption.TopDirectoryOnly)
            Help.ShowHelp(Me, "file://" & fileName)
            Exit For
        Next
    End Sub

    ''' <summary>
    ''' メニューの設定変更
    ''' </summary>
    Private Sub chengeManu()
        lblMail.Visible = False
    End Sub

    ''' <summary>
    ''' メニューの設定変更
    ''' </summary>
    Private Sub chengeManuDialog(ByVal value As Boolean)
        lblUserSet.Visible = False
        lblMail.Visible = False
        lblHelp.Visible = False
        lblLogout.Visible = value
    End Sub

    ''' <summary>
    ''' メニューの表示を変更する
    ''' </summary>
    Private Sub menuDisply(ByVal mode As Boolean)
        If mode Then
            dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_SYSTEM
            chengeManu()
        End If
    End Sub

    ''' <summary>
    ''' メニューの表示を変更する
    ''' </summary>
    Private Sub menuDialog(ByVal mode As Boolean)
        chengeManu()
    End Sub

    ''' <summary>
    ''' ログアウト共通処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnLogout()
    End Sub

#Region "-----　メソッド -----"

    ''' <summary>
    ''' ＦＴＰ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function downLoadHelp() As String
        downLoadHelp = String.Empty
#If DEBUG Then
#Else
        Try
            'ファイル名決定
            Dim FileName As String = String.Empty
            If dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_STUDENT Then
                FileName = Common.Constant.CST_STUDENT_HELP_FILENAME
            ElseIf dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_SYSTEM Then
                downLoadHelp = "HelpSystemManager.chm"
                Exit Function
            ElseIf dataBanker("MENUMODE") = Common.Constant.CST_MENUMODE_GROUP Then
                FileName = Common.Constant.CST_GROUP_HELP_FILENAME
            End If
            '
            If System.IO.File.Exists(Common.Constant.GetTempPath & FileName) Then
                downLoadHelp = FileName
                Exit Function
            End If

            'Dim WebService As New WebService.CBTService
            'WebService.Url = CBTCommon.DataBanker.GetInstance("WEBSERVICE_URL")
            Dim contents As Byte() = Nothing
            If Not WebServiceWrapper.GetInstance.FileDownLoad_SYTEMDATA(FileName, contents) Then
                Common.Message.MessageShow("E043")
                Exit Function
            Else
                downLoadHelp = FileName
                IO.File.WriteAllBytes(Common.Constant.GetTempPath & FileName, contents)
            End If
            'If Not Common.FTP.ReceiveFile(Common.Constant.CST_FTP_URL_SYSTEMDATA, Common.Constant.GetTempPath, FileName) Then
            '    Common.Message.MessageShow("E043")
            '    Exit Function
            'Else
            '    downLoadHelp = FileName
            'End If

        Catch ex As Exception
            writeErrorLog("downLoadHelp", ex.Message)
            Common.Message.MessageShow("E043")
            Exit Function
        End Try
#End If
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

#End Region
End Class