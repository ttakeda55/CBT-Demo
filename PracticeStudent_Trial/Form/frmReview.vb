''' <summary>
''' 総合テスト解答見直し画面(JG32)
''' </summary>
''' <remarks></remarks>
Public Class frmReview

#Region "----- イベント定義 ----- "
    Public Event ChangeQuestion(ByVal questionNumber As Integer)
#End Region

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "解答見直し"
    ''' <summary>画面表示ID(JG30)</summary>
    Private Const DISPLAY_ID_JG30 As String = "JG30"
    ''' <summary>画面表示ID(JG31)</summary>
    Private Const DISPLAY_ID_JG31 As String = "JG31"
    ''' <summary>画面表示ID(JG32)</summary>
    Private Const DISPLAY_ID_JG32 As String = "JG32"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "解答見直し画面"

#End Region

#Region "----- メンバ変数 ----- "

    ''' <summary>
    ''' 全データグリッドの配列
    ''' </summary>
    ''' <remarks></remarks>
    Private DataGridViews() As DataGridView
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

#End Region

#Region "----- 列挙子 ----- "
    ''' <summary>
    ''' データグリッド列インデックス
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum ColumnIndex
        ReviewCheckBox = 0  '見直しチェック列
        QuestionLink        '問題番号リンク列
        Answer              '解答表示列
    End Enum
#End Region

#Region "----- メソッド ----- "

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        DataGridViews = {grdReview1, grdReview2, grdReview3, grdReview4, grdReview5}
    End Sub
    ''' <summary>
    ''' 残り時間を指定の時間に更新します。
    ''' </summary>
    ''' <param name="remainingTime">残り時間</param>
    ''' <remarks></remarks>
    Public Sub UpdateRemainingTime(ByVal remainingTime As TimeSpan)
        Try
            lblRemainingTime.Text = String.Format("残り時間：{0:D03}分{1:D02}秒", _
                remainingTime.Hours * 60 + remainingTime.Minutes, remainingTime.Seconds)
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    ''' <summary>
    ''' データグリッドビューにデータを設定する
    ''' </summary>
    ''' <param name="answer">解答</param>
    ''' <param name="quetion">問題</param>
    ''' <param name="grdview">データグリッドビュー</param>
    ''' <remarks></remarks>
    Private Sub _CreateGridView(ByVal quetion As String, ByVal answer As String, grdview As DataGridView)
        Try
            Dim item As New DataGridViewRow

            item.CreateCells(grdview)

            'セルの内容をセット
            With item

                .Cells(ColumnIndex.ReviewCheckBox).Value = 0
                .Cells(ColumnIndex.QuestionLink).Value = quetion
                .Cells(ColumnIndex.Answer).Value = answer

            End With

            '行を追加
            grdview.Rows.Add(item)

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' データグリッドビューの初期化処理を実行します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        Try
            For Each dgv As DataGridView In DataGridViews
                dgv.SuspendLayout()
            Next

            Dim cnt As Integer = 0          'カウンタを設定

            '全グリッド初期化
            For questionNumber As Integer = 0 To DataManager.GetInstance.QuestionCodeList.Count - 1                 'コードのカウント数分ループをまわす
                If DataManager.GetInstance.QuestionCodeList.Item(questionNumber).QuestionCode <> _
                    DataManager.GetInstance.QuestionCodeList.Item(questionNumber).MiddleQuestionCode Then   '小問と中問のコードが異なる場合

                    Dim gridIndex As Integer = Math.Floor(cnt / 20)                                         'ビューを20問ずつに分ける
                    Dim targetGrid As DataGridView = DataGridViews(gridIndex)                                       'ビューの設定
                    If targetGrid Is Nothing = False Then
                        Dim gridRowIndex As Integer = targetGrid.Rows.Add()
                        targetGrid.Rows(gridRowIndex).Cells(ColumnIndex.QuestionLink).Value = "問" & cnt + 1  '問番号を設定
                        targetGrid.Rows(gridRowIndex).Cells(ColumnIndex.QuestionLink).Tag = questionNumber
                        targetGrid.Rows(gridRowIndex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter    '中央揃え
                        Dim result As ResultData = DataManager.GetInstance().ResultDataContainer(DataManager.GetInstance.QuestionCodeList.Item(questionNumber).QuestionCode)    '問番号ごとの答えと見直しチェックフラグを取得
                        If result Is Nothing = False AndAlso targetGrid Is Nothing = False Then
                            targetGrid.Rows(gridRowIndex).Cells(ColumnIndex.ReviewCheckBox).Value = result.Check    '見直しチェックフラグの設定
                            targetGrid.Rows(gridRowIndex).Cells(ColumnIndex.Answer).Value = Unanswered(result.Answer)           '答えの設定
                        End If
                    End If

                    cnt += 1        'カウントアップ
                End If

            Next

            For Each dgv As DataGridView In DataGridViews
                dgv.CurrentCell = Nothing
                dgv.ResumeLayout()
            Next
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Function Unanswered(ByVal answer As String)
        Unanswered = ""
        If answer <> String.Empty Then
            Unanswered = "解答済"
        End If

    End Function
    ''' <summary>
    ''' 指定の問題番号にジャンプします。
    ''' 指定の問題番号が存在する場合、問題変更イベントを発行し、本画面を閉じます。
    ''' </summary>
    ''' <param name="questionNumber">ジャンプする問題番号</param>
    ''' <remarks></remarks>
    Private Sub JumpQuestion(ByVal questionNumber As Integer)
        Try
            If IsValidQuestionNumber(questionNumber) Then

                '問題変更イベントを発行
                RaiseEvent ChangeQuestion(questionNumber)

                'イベント発行後画面を閉じる
                Me.Close()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 指定の問題番号が有効かどうか
    ''' </summary>
    ''' <param name="questionNumber">問題番号</param>
    ''' <returns>True : 有効である、False : 有効でない</returns>
    ''' <remarks></remarks>
    Private Function IsValidQuestionNumber(ByVal questionNumber As Integer) As Boolean
        Dim ret As Boolean = False

        Try
            If DataManager.GetInstance.QuestionCodeList(questionNumber) Is Nothing = False Then
                ret = True
            End If

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return ret
    End Function

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
    Private Sub frmReview_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()

            Me.MailLabel.Visible = False        ' メール
            Me.UserSetLabel.Visible = False     ' ユーザ設定
            Me.HelpLabel.Visible = False        ' ヘルプ
            Me.LogoutLabel.Visible = False      ' ログアウト

            ''ユーザーID設定
            'Me.UserId = ”ID：" & DataManager.GetInstance.UserId
            ''ユーザー名設定
            'Me.UserName = "氏名：" & DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG32
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            '親フォーム非表示
            'Owner.Hide()
            Show()
            Refresh()

            'データグリッドビュー初期処理
            Me.init()
            'フォーカス設定
            Me.btnClose.Focus()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 全グリッド部の内容クリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdReview_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdReview1.CellContentClick, grdReview2.CellContentClick, grdReview3.CellContentClick, grdReview4.CellContentClick, grdReview5.CellContentClick
        Try
            _Log.Start()

            '問題リンク列の内容クリック時
            If e.ColumnIndex = ColumnIndex.QuestionLink And e.RowIndex >= 0 Then
                '対象のセルから問題番号の取得
                Dim senderGridView As DataGridView = CType(sender, DataGridView)
                Dim questionNumber As Integer = senderGridView.CurrentCell.Tag

                JumpQuestion(questionNumber)
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
    ''' 閉じるボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            _Log.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG30

            Me.Close()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
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