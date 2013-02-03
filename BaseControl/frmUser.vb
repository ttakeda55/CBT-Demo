Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
''' <summary>
''' ユーザ設定画面
''' </summary>
''' <remarks>
''' 2010/09/12 nozao 新規作成
''' </remarks>
Public Class frmUser

#Region "メンバ変数"
    Private dtGroup As DataTable
    Private dtStudent As DataTable
    Private dtSysUser As DataTable
    Private oldPassWord As String
    Private writeFileName As String
    Dim dataBanker As DataBanker = dataBanker.GetInstance
#End Region

#Region "イベンドハンドラ"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "ユーザ設定"
        lblBottomCode.Text = "CG03"
        lblBottomName.Text = "ユーザ設定画面"

        If dataBanker("MENUMODE") = Constant.CST_MENUMODE_SYSTEM Then
            dtSysUser = Common.Serialize.XmlToDataTable(Common.Constant.CST_SYTEMUSER_FILENAME & Common.Constant.CST_EXTENSION_XML)
            oldPassWord = dtSysUser.Rows(0).Item("PASSWORD").ToString.ToLower
            writeFileName = Constant.CST_SYTEMUSER_FILENAME & Constant.CST_EXTENSION_XML
        Else
            dtGroup = loadGroupFile()
            If dtGroup.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim groupCode As String = ""
            Dim userId As String = ""

            If dataBanker("MENUMODE") = Constant.CST_MENUMODE_GROUP Then
                oldPassWord = dtGroup.Rows(0).Item("PASSWORD").ToString.ToLower
                writeFileName = Constant.CST_GROUP_FILENAME & dtGroup.Rows(0).Item("GROUPCODE") & Constant.CST_EXTENSION_XML

            ElseIf dataBanker("MENUMODE") = Constant.CST_MENUMODE_STUDENT Then
                dtStudent = loadStudentFile()
                If dtStudent.Rows.Count > 0 Then
                    groupCode = dtGroup.Rows(0).Item("GROUPCODE")
                    userId = dtStudent.Rows(0).Item("USERID")
                    oldPassWord = dtStudent.Rows(0).Item("PASSWORD").ToString.ToLower
                    writeFileName = Constant.CST_STUDENT_FILENAME & groupCode & userId & Constant.CST_EXTENSION_XML
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' パスワード変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCangePassWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCangePassWord.Click
        '入力チェック
        If Not inputCheck() Then
            Exit Sub
        End If

        'パスワード変更処理
        If dataBanker("MENUMODE") = Constant.CST_MENUMODE_GROUP Then
            dtGroup.Rows(0).Item("PASSWORD") = txtNewPassWord1.Text
            Serialize.DataTableToxml(dtGroup, writeFileName)
        ElseIf dataBanker("MENUMODE") = Constant.CST_MENUMODE_STUDENT Then
            dtStudent.Rows(0).Item("PASSWORD") = txtNewPassWord1.Text
            Serialize.DataTableToxml(dtStudent, writeFileName)
        ElseIf dataBanker("MENUMODE") = Constant.CST_MENUMODE_SYSTEM Then
            dtSysUser.Rows(0).Item("PASSWORD") = txtNewPassWord1.Text
            Serialize.DataTableToxml(dtSysUser, writeFileName)
        End If

        Message.MessageShow("I008")

        Me.Close()
    End Sub
#End Region

#Region "メソッド"
    ''' <summary>
    ''' 団体ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadGroupFile() As DataTable
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Constant.GetTempPath, Constant.CST_GROUP_FILENAME & "*")
            dt = Serialize.XmlToDataTable(IO.Path.GetFileName(fileName))
            Return dt
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 受講者ファイル読み込み
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadStudentFile() As DataTable
        Dim dt As New DataTable
        For Each fileName In System.IO.Directory.GetFiles(Constant.GetTempPath, Constant.CST_STUDENT_FILENAME & "*")
            dt = Serialize.XmlToDataTable(IO.Path.GetFileName(fileName))
            Return dt
        Next
        Return dt
    End Function

    ''' <summary>
    ''' システムユーザファイル読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function loadSystemUserFile() As DataTable
        Dim dt As New DataTable
        Common.Serialize.DataTableToxml(dt, Common.Constant.CST_SYTEMUSER_FILENAME & Common.Constant.CST_EXTENSION_XML)
        Return dt
    End Function

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        inputCheck = True

        '必須チェック
        If txtOldPassWord.Text = "" Then
            Message.MessageShow("E005", {"現パスワード"})
            Return False
        End If
        If txtNewPassWord1.Text = "" Then
            Message.MessageShow("E005", {"新パスワード"})
            Return False
        End If
        If txtNewPassWord2.Text = "" Then
            Message.MessageShow("E005", {"確認パスワード"})
            Return False
        End If

        '旧パスワード確認
        If txtOldPassWord.Text.ToLower <> oldPassWord.ToLower Then
            Message.MessageShow("E007", {"現パスワード"})
            Return False
        End If

        '桁数チェック
        If txtNewPassWord1.Text.Length < 6 Then
            Message.MessageShow("E044", {"新パスワード"})
            Return False
        End If

        'パスワード禁止文字チェック
        If Utility.IsNgChar(txtNewPassWord1.Text, Common.Constant.CST_PASSWORDCHARS_NG) Then
            Dim chars As String = Common.Constant.CST_PASSWORDCHARS_NG
            Dim str As String = ""
            For Each chr As Char In chars
                str &= "[" & chr.ToString & "]"
            Next
            Message.MessageShow("E050", {str})
            Return False
        End If

        '半角英大文字チェック
        If Utility.IsUpperCase(txtNewPassWord1.Text) Then
            Message.MessageShow("E051")
            Return False
        End If
        '英数チェック
        If Utility.IsHalfAlphaNum(txtNewPassWord1.Text) = False Then
            Message.MessageShow("E036", {"パスワード"})
            Return False
        End If

        '確認パスワードの一致確認
        If txtNewPassWord1.Text <> txtNewPassWord2.Text Then
            Message.MessageShow("E032", {"確認パスワード"})
            Return False
        End If

    End Function
#End Region
End Class