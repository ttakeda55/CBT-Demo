''' <summary>
''' 中問逐次演習トップ画面(JG21)
''' </summary>
''' <remarks></remarks>
Public Class frmMiddlePracticeTop

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "中問逐次演習"
    ''' <summary>画面表示ID(JG21)</summary>
    Private Const DISPLAY_ID_JG21 As String = "JG21"
    ''' <summary>画面表示ID(JG15)</summary>
    Private Const DISPLAY_ID_JG15 As String = "JG15"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "中問逐次演習画面"
#End Region

#Region "----- メンバ変数 ----- "
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- メソッド ----- "

    ''' <summary>
    ''' お知らせ再設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub mailClosed()
        Try
            'お知らせを削除する
            DataManager.GetInstance.Infomation = ""
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

#Region "----- イベント ----- "

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMiddlePracticeTop_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG21
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            '親フォーム非表示
            Owner.Hide()
            Show()
            Refresh()
            'フォーカス設定
            Me.btnMiddlePracticeStart.Focus()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 「直近の出題時に不正解になった問題」チェックボックスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkChokkinPractice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkChokkinPractice.CheckedChanged
        Try
            _Log.Start()

            If chkChokkinPractice.Checked Then
                chkMienshuPractice.Checked = False
            Else
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 「再演習にチェックを入れた問題」チェックボックスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkSaienshuPractice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSaienshuPractice.CheckedChanged
        Try
            _Log.Start()

            If chkSaienshuPractice.Checked Then
                chkMienshuPractice.Checked = False
            Else
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 「未演習の問題」チェックボックスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkMienshuPractice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMienshuPractice.CheckedChanged
        Try
            _Log.Start()

            If chkMienshuPractice.Checked Then
                chkSaienshuPractice.Checked = False
                chkChokkinPractice.Checked = False
            Else
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 中問逐次演習開始ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMiddlePracticeStart_Click(sender As System.Object, e As System.EventArgs) Handles btnMiddlePracticeStart.Click
        Try
            _Log.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = "JG22" ' 中問逐次演習問題画面へ遷移

            '問題コードの取得
            Dim _GetMiddlePracticeQuestionList As Dictionary(Of Integer, QuestionCodeDefine) = DataManager.GetInstance.PracticeQuestionDefine.GetMiddlePracticeQuestionList(chkChokkinPractice.Checked, chkSaienshuPractice.Checked, chkMienshuPractice.Checked)

            If _GetMiddlePracticeQuestionList.Count = 0 Then
                MsgBox("条件に合う問題がありません。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "メッセージ")
            ElseIf _GetMiddlePracticeQuestionList.Count > 0 Then

                '問題コードリストに「中問逐次問題の問題コード」を設定
                DataManager.GetInstance.QuestionCodeList = _GetMiddlePracticeQuestionList

                '中問逐次演習問題画面へ遷移
                Dim frm As New frmTest(0)
                Me.Hide()
                frm.ShowDialog(Me)
                If DataManager.GetInstance.IsLogouting Then
                    Me.Close()
                Else
                    Me.Show()
                End If
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 逐次演習メニューへ戻るボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackPracticeMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnBackPracticeMenu.Click
        Try
            _Log.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG15

            Me.Close()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            'エラーメッセージ
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            'イベントログ出力
            _Log.Start()

            'ログアウト処理
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.UploadError, Integer).ToString.PadLeft(3, "0"))
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            _Log.End()
        End Try
    End Sub

#End Region

End Class