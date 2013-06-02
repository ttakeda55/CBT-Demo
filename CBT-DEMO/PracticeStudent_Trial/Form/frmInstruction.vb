Imports CST.CBT.eIPSTA.Common

Public Class frmInstruction

#Region "----- 定数 -----"
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "操作説明"
    ''' <summary>画面表示ID</summary>
    Private Const DISPLAY_ID As String = "JG02"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "ＣＢＴ操作説明画面"

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>模擬説明ファイルリスト</summary>
    Private _HelpFileList As New SortedList
    ''' <summary>模擬説明ファイルパス</summary>
    Private _HelpFilePath As String = Common.Constant.GetTempPath & "Help"
    ''' <summary>選択ページ</summary>
    Private _SelectPage As Integer = 0
#End Region

#Region "----- コンストラクタ -----"
    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        'Dim frm As New frmMainMenu
        'frm.Dispose()

        'メニューモード設定
        CBTCommon.DataBanker.GetInstance("MENUMODE") = Common.Constant.CST_MENUMODE_STUDENT
        '模擬テスト読込フラグ設定
        CBTCommon.DataBanker.GetInstance("READQUESTION") = False

        '初期化処理
        Dim errCode As Constant.ResultCode = DataManager.GetInstance.Initialize()
        If errCode <> Constant.ResultCode.NormalEnd Then
            Common.Message.MessageShow("E" & errCode)
            Close()
        End If

        DataManager.GetInstance.ServerDateTime = Date.Now
        DataManager.GetInstance.DiffDateTime = New TimeSpan(0, 0, 0)

    End Sub
#End Region

#Region "----- イベント -----"

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmInstruction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim blnRet As Boolean = False

        Try
            '初期化
            Me.webInstruction.AllowNavigation = True

            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME

            '操作説明ファイル取得
            Call InstructionCommon.GetHelpFile(_HelpFilePath, _HelpFileList)
            '次ボタン制御
            If _HelpFileList.Count > 1 Then btnNext.Enabled = True
            'Navigate設定
            Call InstructionCommon.SetNavigate(_SelectPage, _HelpFilePath, _HelpFileList, webInstruction)
            '現在時刻設定
            Call SetNowTime()
            'タイマー起動
            Panel1.Focus()
            '親フォーム非表示
            Owner.Hide()
            'タイトル設定
            setTitle()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' メインメニューボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        ShowTopForm()
        'Close()
    End Sub

    ''' <summary>
    ''' 模擬テスト開始画面へボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Try
            Dim frm As New frmTestTop

            frm.ShowDialog(Me)
            If DataManager.GetInstance().IsLogouting Then
                Close()
            Else
                Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                Me.Show()
                Exit Sub
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 次へボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            If _SelectPage + 1 <= _HelpFileList.Count - 1 Then
                _SelectPage += 1
                '模擬操作説明表示
                Call InstructionCommon.SetNavigate(_SelectPage, _HelpFilePath, _HelpFileList, webInstruction)
                '次へボタン押下不可設定
                If _SelectPage = _HelpFileList.Count - 1 Then btnNext.Enabled = False
                btnPre.Enabled = True
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 前へボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPre.Click
        Try
            If _SelectPage - 1 >= 0 Then
                _SelectPage -= 1
                '模擬操作説明表示
                Call InstructionCommon.SetNavigate(_SelectPage, _HelpFilePath, _HelpFileList, webInstruction)
                '次へボタン押下不可設定
                If _SelectPage = 0 Then btnPre.Enabled = False
                btnNext.Enabled = True
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

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
#End Region

#Region "----- メソッド -----"
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

    ''' <summary>
    ''' TOP画面に戻ります。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowTopForm()
        Me.Close()
    End Sub

#End Region
End Class