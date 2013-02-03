''' <summary>
''' 小テスト採点結果フォーム(JS27,JS40)
''' </summary>
''' <remarks></remarks>
Public Class frmMiniTestMarkHistory

#Region "----- 定数 -----"
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "採点結果"
    ''' <summary>小テスト採点用画面表示ID</summary>
    Private Const DISPLAY_ID_MINI_RESULT As String = "JG27"
    ''' <summary>小テスト採点用画面表示名</summary>
    Private Const DISPLAY_NAME_MINI_RESULT As String = "小テスト採点画面"
    ''' <summary>小テスト履歴詳細用画面表示ID</summary>
    Private Const DISPLAY_ID_MINI_HISTORY As String = "JG40"
    ''' <summary>小テスト履歴詳細用画面表示名</summary>
    Private Const DISPLAY_NAME_MINI_HISTORY As String = "小テスト履歴詳細画面"
    ''' <summary>小テストトップ画面表示ID</summary>
    Private Const DISPLAY_ID_MINI_TOP As String = "JG24"
    ''' <summary>小テスト実施履歴一覧画面表示ID</summary>
    Private Const DISPLAY_ID_MINI_HISTORYTOP As String = "JG39"
    ''' <summary>小テスト解説画面表示ID</summary>
    Private Const DISPLAY_ID_MINI_COMMENT As String = "JG28"
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>画面表示ID</summary>
    Private _DisplayId As String = ""
    ''' <summary>画面表示名</summary>
    Private _DisplayName As String = ""
    ''' <summary>トップ画面表示ID</summary>
    Private _DisplayBackId As String = ""
    ''' <summary>小テスト結果Datarow</summary>
    Private _MiniResultDataRow As DataRow = Nothing
    ''' <summary>小テスト問別正誤DataTable</summary>
    Private _MiniResultTrueFalseTbl As DataTable = Nothing
    ''' <summary>グリッド垂直スクロールバー</summary>
    Private _vsBar As VScrollBar

#End Region

#Region "----- プロパティ -----"
    ''' <summary>小テスト結果DataRowの設定</summary>
    Public WriteOnly Property MiniResultDataRow As DataRow
        Set(ByVal value As DataRow)
            _MiniResultDataRow = value
        End Set
    End Property

    ''' <summary>小テスト問別正誤DataTableの設定</summary>
    Public WriteOnly Property MiniResultTrueFalseTbl As DataTable
        Set(ByVal dt As DataTable)
            _MiniResultTrueFalseTbl = dt
        End Set
    End Property

#End Region

#Region "----- コンストラクタ -----"

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' コントロールの配置を設定する
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        If dataBanker("TOFORM") = DISPLAY_ID_MINI_RESULT Then
            ' 小テスト採点画面
            SetMiniControl()
        Else
            ' 小テスト履歴詳細画面
            SetMiniHistoryControl()
        End If
    End Sub

#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMiniTestMarkHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _Log.Start()

            '画面表示設定
            Call SetDisply()

            'DataGridView初期化処理
            Call InitializeDataGridView()

            'データ設定処理
            Call SetData()

            ' 小テスト履歴問題コード作成
            If _DisplayId = DISPLAY_ID_MINI_HISTORY Then
                DataManager.GetInstance.QuestionCodeList = DataManager.GetInstance.PracticeQuestionDefine.GetMiniResultPracticeQuestion(_MiniResultTrueFalseTbl)
            End If

            '画面表示
            Owner.Hide()
            Show()
            'フォーカス設定
            Me.btnBack.Focus()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            _Log.Start()
            ShowTopForm()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 問題番号選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdList_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdList.CellContentClick
        Try
            _Log.Start()
            If TypeOf grdList.Columns(e.ColumnIndex) Is DataGridViewLinkColumn AndAlso e.RowIndex >= 0 Then
                Call SetQuestionNo(e.RowIndex)
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
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            _Log.Start()
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & resultCode)
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' データグリッドビュー縦スクロールバー表示変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub vsBar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            _Log.Start()
            If Not _vsBar.Visible Then
                '縦クロースバーを常に表示する。
                Dim borderWidth As Integer = 2

                _vsBar.Location = New Point(Me.grdList.ClientRectangle.Width - _vsBar.Width, 0)
                _vsBar.Size = New Size(_vsBar.Width, Me.grdList.ClientRectangle.Height - borderWidth)
                _vsBar.Show()
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' 小テスト採点用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMiniControl()
        Try
            _DisplayId = DISPLAY_ID_MINI_RESULT
            _DisplayName = DISPLAY_NAME_MINI_RESULT
            _DisplayBackId = DISPLAY_ID_MINI_TOP

            lblTitle.Text = "小テスト採点結果"
            lblTestName.Visible = False
            btnBack.Text = "小テストメニューへ戻る"

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 小テスト履歴詳細用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMiniHistoryControl()
        Try
            _DisplayId = DISPLAY_ID_MINI_HISTORY
            _DisplayName = DISPLAY_NAME_MINI_HISTORY
            _DisplayBackId = DISPLAY_ID_MINI_HISTORYTOP

            lblTitle.Text = "小テスト履歴詳細"
            lblTestName.Visible = True
            btnBack.Text = "小テスト履歴一覧へ戻る"

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 画面表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDisply()
        Try
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            '画面表示名設定
            Me.lblBottomName.Text = _DisplayName
            '画面表示ID設定
            Me.lblBottomCode.Text = _DisplayId

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' DataGridView初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDataGridView()
        Try
            grdList.Rows.Clear()

            '垂直スクロールバーを表示する
            For Each c As Control In grdList.Controls
                If TypeOf c Is VScrollBar Then
                    _vsBar = DirectCast(c, VScrollBar)

                    AddHandler _vsBar.VisibleChanged, AddressOf vsBar_VisibleChanged
                End If
            Next
            _vsBar.Show()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' データ設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetData()
        Dim cnt As Integer = 0
        Try
            'フォームのレイアウトロジックを中断する
            Me.grdList.SuspendLayout()

            ' コントロールにセット
            ' 正解数
            lblRight.Text = _MiniResultDataRow.Item(MiniResultDefine.MinResultHistTblIndex.CorrectAnswerCount)
            ' 問題数
            lblTotal.Text = _MiniResultDataRow.Item(MiniResultDefine.MinResultHistTblIndex.QuestionCount)
            ' 正解率
            lblPercentage.Text = _MiniResultDataRow.Item(MiniResultDefine.MinResultHistTblIndex.AccuracyRate)
            ' テスト名 + 実施日
            If lblBottomCode.Text = DISPLAY_ID_MINI_HISTORY Then
                lblTestName.Text = _MiniResultDataRow.Item(MiniResultDefine.MinResultHistTblIndex.TestName).ToString.Replace(vbCrLf, "　") _
                                    & " (" _
                                    & _MiniResultDataRow.Item(MiniResultDefine.MinResultHistTblIndex.TestDate).ToString.Replace("/", ".") _
                                    & "実施)"
            End If

            ' 問題・解答・正誤内容をセットする
            For Each rowData As DataRow In _MiniResultTrueFalseTbl.Rows
                Me.grdList.Rows.Add()
                With Me.grdList.Rows(cnt)
                    ' 問番号
                    .Cells(0).Value = "問" & rowData.Item(MiniResultDefine.MinTrueFalseTblIndex.QuestionNumber)
                    ' 問題テーマ
                    .Cells(1).Value = rowData.Item(MiniResultDefine.MinTrueFalseTblIndex.QuestionTheme)
                    ' 正解
                    .Cells(2).Value = rowData.Item(MiniResultDefine.MinTrueFalseTblIndex.CorrectansAnswer)
                    ' 解答
                    .Cells(3).Value = rowData.Item(MiniResultDefine.MinTrueFalseTblIndex.Answer)
                    ' 正誤
                    If rowData.Item(MiniResultDefine.MinTrueFalseTblIndex.Errata) = "1" Then
                        .Cells(4).Value = "○"
                    Else
                        .Cells(4).Value = "×"
                    End If
                End With
                cnt += 1
            Next
            'フォームのレイアウトロジックを再開する
            Me.grdList.ResumeLayout()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' TOP画面に戻ります。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowTopForm()
        Try
            '画面を閉じる
            Me.Close()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 選択問題番号設定処理
    ''' </summary>
    ''' <param name="questionNo">問題番号</param>
    ''' <remarks></remarks>
    Private Sub SetQuestionNo(ByVal questionNo As Integer)
        Try
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = DISPLAY_ID_MINI_COMMENT

            '小テスト解説画面を表示
            Dim frm As New frmQuestionComment(questionNo)
            frm.MiniResultTrueFalseTbl = _MiniResultTrueFalseTbl
            frm.ShowDialog(Me)

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' お知らせ再設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub mailClosed()
        Try
            'お知らせを削除する
            DataManager.GetInstance.Infomation = ""
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region
End Class