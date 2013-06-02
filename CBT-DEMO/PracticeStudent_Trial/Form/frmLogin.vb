Imports System.IO
Imports CST.CBT.eIPSTA
Imports CST.CBT.eIPSTA.Common
''' <summary>
''' ログイン
''' </summary>
Public Class frmLogin

#Region "メンバ変数"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "イベントハンドラ"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            Me.Text = "ログイン"
            lblBottomCode.Text = "CG01"
            lblBottomName.Text = "ログイン画面"

            writeResource()
            setTitle()
            logger.End()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub writeResource()
        'CBTCommon.Utility.DeleteDirectory(Common.Constant.GetTempPath)

        Dim path As String = IO.Path.GetDirectoryName(Common.Constant.GetTempPath)
        'If IO.Directory.Exists(path) Then
        '    CBTCommon.Utility.DeleteDirectory(path)
        'End If
        'IO.Directory.CreateDirectory(path)
        'For Each folder As String In IO.Directory.GetDirectories(path)
        '    For Each filePath As String In IO.Directory.GetFiles(folder)
        '        IO.File.Delete(filePath)
        '    Next
        '    IO.Directory.Delete(folder)
        'Next
        'For Each filePath As String In IO.Directory.GetFiles(path)
        '    IO.File.Delete(filePath)
        'Next
        My.Computer.FileSystem.WriteAllText(path & "..\Group.xml", My.Resources.Group, False)
        IO.Directory.CreateDirectory(path & "\Help")
        My.Computer.FileSystem.WriteAllBytes(path & "\Help" & "..\Help01.mht", My.Resources.Help01, False)
        My.Computer.FileSystem.WriteAllText(path & "..\StudentVETNurse.xml", My.Resources.Student, False)
        My.Computer.FileSystem.WriteAllText(path & "..\TestName.xml", My.Resources.TestName, False)

    End Sub

    ''' <summary>
    ''' ログイン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            logger.Start()

            'フォーラム版は認証する
            If DataManager.GetInstance.Edition = DataManager.EditionType.Foram Then
                If inputCheck() = False Then Exit Sub
            End If

            DataManager.GetInstance.Syubetu = 30     '３０分問題
            'DataManager.GetInstance.UserId = "999999"
            'DataManager.GetInstance.UserName = "体験版"

            '2012/12/16 T.takeda
            'Dim frm As New frmTestTop
            Dim frm As New frmInstruction

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance()
            dataBanker("LOGOUT") = Nothing
            dataBanker("SYTEMMANAGERINGROUP_LOGOUT") = Nothing
            Me.Hide()
            frm.ShowDialog(Me)
            If DataManager.GetInstance().IsLogouting Then
                Close()
            Else
                Me.Show()
                Exit Sub
            End If
            setTitle()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            logger.Start()
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ユーザIDLeave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtUserId_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserId.Leave
        Try
            txtUserId.Text = txtUserId.Text.ToUpper
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "メソッド"
    ''' <summary>
    ''' 入力クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        txtUserId.Text = ""
        txtPassWord.Text = ""
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean

        If txtUserId.Text = String.Empty Then
            Message.MessageShow("E002")
            Return False
        End If

        If txtPassWord.Text = String.Empty Then
            Message.MessageShow("E003")
            Return False
        End If

        '受講者データ取得
        Dim dtStudent As DataTable = Common.Student.GetAll()

        If checkUser(txtUserId.Text, txtPassWord.Text, dtStudent) = False Then
            Message.MessageShow("E001")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' ユーザをチェックする
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="password"></param>
    ''' <param name="dtStudent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkUser(ByVal userId As String, ByVal password As String, ByVal dtStudent As DataTable) As Boolean
        checkUser = True
        Dim dr As DataRow() = dtStudent.Select("USERID = '" & userId & "'")

        If dr.Length = 0 Then Return False
        If dr(0).Item("PASSWORD") <> password Then Return False
        'If Val(dr(0).Item("SECTION1")) <> DataManager.GetInstance.Syubetu Then Return False
        DataManager.GetInstance.UserId = dr(0).Item(Common.Student.ColumnIndex.UserId)
        DataManager.GetInstance.UserName = dr(0).Item(Common.Student.ColumnIndex.Name)
    End Function
#End Region

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub

End Class