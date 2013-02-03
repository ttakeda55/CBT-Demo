Imports CST.CBT.eIPSTA.Common
''' <summary>
''' システム管理者トップ(TG01)<br/>
''' <img src="..\Images\TG01.png" />
''' </summary>
''' <remarks>
''' 2011/09/07 NOZAO 新規作成
''' </remarks>
Public Class frmSystemManagerTop

#Region "メンバ変数"
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance()
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "イベントハンドラ"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmSystemManagerTop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            UserId = "SYSTEMUSER"
            UserName = "システム管理者"
            Show()
            Refresh()

            MyBase.MenuMode = True

            'btnGroup.Focus()

            Me.processMessageDownload = True
            Me.Refresh()

            'ファイルダウンロード
            If Not DataManager.GetInstance.DownLoadFile Then
                Me.DialogResult = DialogResult.OK
                Close()
            End If

            'カテゴリデータ出力
            CategoryMaster.outPutCategory()
            'ヘルプ保存
            HelpResourcesSave()

            Me.processMessageDownload = False
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 団体登録画面遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            logger.Start()
            Dim frm As New frmGroupManagerTop
            frm.ShowDialog(Me)

            If dataBanker("LOGOUT") Then
                Close()
            Else
                Show()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題管理画面遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuestion.Click
        Try
            Dim frm As New frmQuestionManagerTop
            frm.ShowDialog(Me)
            If dataBanker("LOGOUT") Then
                Close()
            Else
                Show()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 受講者登録画面遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStudent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStudent.Click
        Try
            Dim frm As New frmStudentTop
            frm.ShowDialog(Me)
            If dataBanker("LOGOUT") Then
                Close()
            Else
                Show()
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 団体管理者画面遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManager.Click
        Try
            Dim frm As New GroupManager.frmGroupManagerTop
            Me.Hide()
            frm.ShowDialog(Me)
            If dataBanker("LOGOUT") Then
                Close()
            Else
                Show()
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' コース管理画面遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCourse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New frmCourse
            frm.ShowDialog(Me)
            If dataBanker("LOGOUT") Then
                Close()
            Else
                Show()
            End If
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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "メソッド"
    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
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
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ヘルプのリソース保存
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HelpResourcesSave()
        '保存
        If Not IO.File.Exists(Common.Constant.GetTempPath & "\HelpSystemManager.chm") Then
            My.Computer.FileSystem.WriteAllBytes(Common.Constant.GetTempPath & "\HelpSystemManager.chm", My.Resources.HelpSystemManager, True)
        End If
    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmSetTestName.ShowDialog()
        setTitle()
    End Sub

    Private Sub btnInitialize_Click(sender As System.Object, e As System.EventArgs) Handles btnInitialize.Click
        Dim fileName As String = ""
        Dim length As Integer = Common.Constant.GetTempPath.ToString.Length
        Dim tempPath As String = Common.Constant.GetTempPath.ToString
        tempPath = tempPath.Substring(0, length - 1)


        If MessageBox.Show("試験問題・結果が全て削除されます。" & vbCrLf & "初期化してもよろしいでしょうか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            If MessageBox.Show("本当によろしいでしょうか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.CopyDirectory(tempPath, tempPath & "bk" & Format(System.DateTime.Now, "yyyyMMddHHmmss"))
                For Each filePath As String In IO.Directory.GetDirectories(tempPath, "*")
                    CBTCommon.Utility.DeleteDirectory(filePath)
                Next
                For Each filePath As String In IO.Directory.GetFiles(tempPath, "*")
                    fileName = IO.Path.GetFileName(filePath)
                    If fileName.IndexOf("Group") = -1 And fileName.IndexOf("Category") = -1 And fileName.IndexOf("SystemUser") = -1 Then
                        IO.File.Delete(filePath)
                    End If
                Next
                MessageBox.Show("初期化しました", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
