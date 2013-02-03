''' <summary>
''' 総合テストトップ画面(JG29)
''' </summary>
''' <remarks></remarks>
Public Class frmTestTop

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "テストトップ"
    ''' <summary>画面表示ID(JG29)</summary>
    Private Const DISPLAY_ID_JG29 As String = "JG29"
    ''' <summary>画面表示ID(JG15)</summary>
    Private Const DISPLAY_ID_JG15 As String = "JG15"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "テストトップ画面"
#End Region

#Region "----- メンバ変数 ----- "
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- メソッド ----- "

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

    End Sub
#End Region

#Region "----- イベント ----- "

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmTestTop_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()

            ''ユーザーID設定
            Me.UserId = "ID：" & DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = "氏名：" & DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG29
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            'テスト開始ボタン
            Me.btnTestStart.Enabled = DataManager.GetInstance.IsTested
            '親フォーム非表示
            Owner.Hide()
            Show()
            Refresh()
            lblTestTime.Text = DataManager.GetInstance.Syubetu & "分"
            tmNowTime.Enabled = True

            Dim questionCount As Integer = DataManager.GetInstance.SynthesisDefine.SynthesisDetailTblDic.Values(0).Rows.Count
            Label15.Text = "問1～問" & questionCount
            Label16.Text = questionCount & "問必須"
            'フォーカス設定
            Me.btnTestStart.Focus()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 総合テスト開始ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTestStart_Click(sender As System.Object, e As System.EventArgs) Handles btnTestStart.Click
        Try
            _Log.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = "JG30" ' 総合テスト演習問題画面へ遷移
            Dim Test_item As String = "体験版"

            '演習問題一覧DataTableの取得
            Dim _dt As DataTable = DataManager.GetInstance.PracticeQuestionDefine.PracticeQuestionListDataTable
            'テスト結果ヘッダの取得
            Dim _dt2 As DataTable = DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHeaderDataTable
            '問題コードリストの取得
            Dim _TestQuestionList As Dictionary(Of Integer, QuestionCodeDefine) = DataManager.GetInstance.SynthesisDefine.GetSynthesisQuestionCodeList(Test_item, _dt, _dt2)
            '問題コードリストを設定
            DataManager.GetInstance.QuestionCodeList = _TestQuestionList

            'テスト演習問題画面へ遷移する。
            Dim frm As New frmTest(0)
            Me.Hide()
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Me.Close()
            Else
                btnTestStart.Enabled = DataManager.GetInstance.IsTested
                frmTestTop_Load(Nothing, Nothing)
                Me.Show()
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
    ''' 問題演習メニューへ戻るボタンクリックイベント
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

    ''' <summary>
    ''' タイマーTickイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmNowTime_Tick(sender As Object, e As System.EventArgs) Handles tmNowTime.Tick
        Try
            '現在時刻設定
            Call SetNowTime()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    ''' <summary>
    ''' 現在時刻設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetNowTime()
        Try
            lblNow.Text = Now.ToString("HH時mm分ss秒")
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
End Class