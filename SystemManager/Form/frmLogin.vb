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

            CBTCommon.DataBanker.GetInstance().Item("MENUMODE") = Common.Constant.CST_MENUMODE_SYSTEM

            Dim path As String = IO.Path.GetDirectoryName(Common.Constant.GetTempPath)
            My.Computer.FileSystem.WriteAllText(path & "..\Category.xml", My.Resources.Category, False)

            logger.End()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
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
            '必須チェック
            If Not inputCheck() Then
                Exit Sub
            End If

            'ユーザファイル読込
            Dim user As String()
            user = loadSystemUserFile()

            '認証
            If txtUserId.Text.ToLower <> user(0).ToLower Then
                Message.MessageShow("E001")
                Return
            End If

            If txtPassWord.Text.ToLower <> user(1).ToLower Then
                Message.MessageShow("E001")
                Return
            End If

            'Dim frm As New frmSystemManagerTop
            Dim frm As New frmMenu

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance()
            dataBanker("LOGOUT") = Nothing
            dataBanker("SYTEMMANAGERINGROUP_LOGOUT") = Nothing

            Me.Hide()
            If frm.ShowDialog(Me) = DialogResult.Cancel Then

                If dataBanker("LOGOUT") Then
                    Me.Hide()
                    If frmLogout.ShowDialog(Me) = DialogResult.OK Then
                        Show()
                        clearInput()
                    Else
                        Close()
                    End If
                Else
                    Me.Close()
                    frm.Dispose()
                End If
            Else
                Me.Visible = True
                clearInput()
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

        Return True
    End Function

    ''' <summary>
    ''' ユーザファイル読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadSystemUserFile() As String()
        Dim dtSysUser As New DataTable
        'ファイル存在チェック
        If Not IO.File.Exists(Common.Constant.GetTempPath & Common.Constant.CST_SYTEMUSER_FILENAME & Common.Constant.CST_EXTENSION_XML) Then
            XmlSchema.GetSystemUserSchema(dtSysUser)
            dtSysUser.Rows.Add()
            dtSysUser.Rows(0).Item(0) = "cbt"
            dtSysUser.Rows(0).Item(1) = "1234"
            Common.Serialize.DataTableToxml(dtSysUser, Common.Constant.CST_SYTEMUSER_FILENAME & Common.Constant.CST_EXTENSION_XML)
        Else
            dtSysUser = Common.Serialize.XmlToDataTable(Common.Constant.CST_SYTEMUSER_FILENAME & Common.Constant.CST_EXTENSION_XML)
        End If

        Dim user As String() = Nothing
        ReDim user(2)

        user(0) = dtSysUser.Rows(0).Item(0)
        user(1) = dtSysUser.Rows(0).Item(1)

        Return user
    End Function

#End Region


End Class