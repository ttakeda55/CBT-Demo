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

            'If DateTime.Today.ToString <> "2012/12/19 0:00:00" Then
            '    Call MsgBox("有効期限切れで、実行出来ません", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '    Me.Close()
            '    logger.End()
            '    Exit Sub
            'End If

            '2012/12/17 T.Takeda
            writeResource()
            setTitle()
            '2012/12/16 T.takeda
            'Owner.Hide()
            logger.End()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub writeResource()
        'CBTCommon.Utility.DeleteDirectory(Common.Constant.GetTempPath)

        Dim path As String = IO.Path.GetDirectoryName(Common.Constant.GetTempPath)
        If IO.Directory.Exists(path) Then
            CBTCommon.Utility.DeleteDirectory(path)
        End If
        IO.Directory.CreateDirectory(path)
        'For Each folder As String In IO.Directory.GetDirectories(path)
        '    For Each filePath As String In IO.Directory.GetFiles(folder)
        '        IO.File.Delete(filePath)
        '    Next
        '    IO.Directory.Delete(folder)
        'Next
        'For Each filePath As String In IO.Directory.GetFiles(path)
        '    IO.File.Delete(filePath)
        'Next
        My.Computer.FileSystem.WriteAllText(path & "..\Category.xml", My.Resources.Category, False)
        My.Computer.FileSystem.WriteAllText(path & "..\GroupVETNurse.xml", My.Resources.GroupVETNurse, False)
        IO.Directory.CreateDirectory(path & "\Help")
        My.Computer.FileSystem.WriteAllBytes(path & "\Help" & "..\Help01.mht", My.Resources.Help01, False)
        My.Computer.FileSystem.WriteAllText(path & "..\PracticeQuestionList.xml", My.Resources.PracticeQuestionList, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000001", My.Resources.PracticeQuestionP0000001, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000002", My.Resources.PracticeQuestionP0000002, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000003", My.Resources.PracticeQuestionP0000003, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000004", My.Resources.PracticeQuestionP0000004, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000005", My.Resources.PracticeQuestionP0000005, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000006", My.Resources.PracticeQuestionP0000006, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000007", My.Resources.PracticeQuestionP0000007, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000008", My.Resources.PracticeQuestionP0000008, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000009", My.Resources.PracticeQuestionP0000009, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000010", My.Resources.PracticeQuestionP0000010, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000011", My.Resources.PracticeQuestionP0000011, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000012", My.Resources.PracticeQuestionP0000012, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000013", My.Resources.PracticeQuestionP0000013, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000014", My.Resources.PracticeQuestionP0000014, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000015", My.Resources.PracticeQuestionP0000015, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000016", My.Resources.PracticeQuestionP0000016, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000017", My.Resources.PracticeQuestionP0000017, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000018", My.Resources.PracticeQuestionP0000018, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000019", My.Resources.PracticeQuestionP0000019, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\PracticeQuestionP0000020", My.Resources.PracticeQuestionP0000020, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\Result.xls", My.Resources.Result, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\setup.exe", My.Resources.setup, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\CBT.msi", My.Resources.CBT, False)
        My.Computer.FileSystem.WriteAllBytes(path & "..\SpreadSheetSpecification.xls", My.Resources.SpreadSheetSpecification, False)
        My.Computer.FileSystem.WriteAllText(path & "..\StudentVETNurse.xml", My.Resources.StudentVETNurse, False)
        My.Computer.FileSystem.WriteAllText(path & "..\SynthesisDetail30VETNurse.xml", My.Resources.SynthesisDetail30VETNurse, False)
        My.Computer.FileSystem.WriteAllText(path & "..\SynthesisHeader30VETNurse.xml", My.Resources.SynthesisHeader30VETNurse, False)
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
            'If DataManager.GetInstance.Edition = DataManager.EditionType.Foram Then
            '    If inputCheck() = False Then Exit Sub
            'End If

            DataManager.GetInstance.Syubetu = 30     '１５分問題
            DataManager.GetInstance.UserId = "999999"
            DataManager.GetInstance.UserName = "体験版"

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
            dtSysUser.Rows(0).Item(0) = "SYSTEMUSER"
            dtSysUser.Rows(0).Item(1) = "abcd1234"
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