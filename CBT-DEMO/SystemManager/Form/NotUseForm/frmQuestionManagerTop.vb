''' <summary>
''' 問題管理トップ
''' </summary>
''' <remarks>
''' 2011/09/07 NOZAO 新規作成
''' </remarks>
Public Class frmQuestionManagerTop

#Region "イベントハンドラ"
    ''' <summary>
    ''' システム管理者画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackSystemManager.Click
        Try
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmQuestionManagerTop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ''wordチェック
            btnImport.Enabled = IsWord()
            
            Owner.Hide()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題一覧
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        Try
            Dim frm As New frmPracticeQuestionList
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                Show()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Dim frm As New frmPracticeQuestionImport
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                Show()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 分類登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCategory.Click
        Try
            Dim frm As New frmCategory
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Cancel Then
                Me.Close()
            Else
                Show()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

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
#End Region

#Region "メソッド"
    ''' <summary>
    ''' EXCELチェック
    ''' </summary>
    ''' <remarks></remarks>
    Private Function IsWord() As Boolean
        Try
            Dim WordApp As Type = Type.GetTypeFromProgID("Word.Application")
            If IsNothing(WordApp) Then
                Return False
            Else
                Return True
            End If
        Finally
        End Try
        Return False
    End Function
#End Region
End Class