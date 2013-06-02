''' <summary>
''' 総合テスト問別正誤一覧(JG34,JG43)
''' </summary>
''' <remarks></remarks>
Public Class frmSynthesisTrueFalseList

#Region "----- 定数 -----"

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "テスト問別正誤一覧"
    ''' <summary>画面表示ID(JG42)</summary>
    Private Const DISPLAY_ID_JG42 As String = "JG42"
    ''' <summary>画面表示ID(JG43)</summary>
    Private Const DISPLAY_ID_JG43 As String = "JG43"
    ''' <summary>画面表示NAME(JG43)</summary>
    Private Const DISPLAY_NAME_JG43 As String = "テスト問別正誤一覧画面"
    ''' <summary>画面表示ID(JG33)</summary>
    Private Const DISPLAY_ID_JG33 As String = "JG33"
    ''' <summary>画面表示ID(JG43)</summary>
    Private Const DISPLAY_ID_JG34 As String = "JG34"
    ''' <summary>画面表示NAME(JG43)</summary>
    Private Const DISPLAY_NAME_JG34 As String = "テスト問別正誤一覧画面"

    ''' <summary>データグリッドビューの列番定数</summary>
    Private Const INT_GRD_MONNO As Integer = 0
    Private Const INT_GRD_MONTHEME As Integer = 1
    Private Const INT_GRD_CORRECT As Integer = 2
    Private Const INT_GRD_ANSWER As Integer = 3
    Private Const INT_GRD_TRUEFALSE As Integer = 4

#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>上の行の中分類データ(grdJhoken_Show[データグリッドビューの行追加])で使用</summary>
    Dim _strCyubunU As String
    ''' <summary>グリッド垂直スクロールバー</summary>
    Private _vsBar As VScrollBar

    ''' <summary>画面表示ID</summary>
    Private _DisplayId As String = ""
    ''' <summary>画面表示名</summary>
    Private _DisplayName As String = ""
    ''' <summary>トップ画面表示ID</summary>
    Private _DisplayBackId As String = ""
    ''' <summary>総合テスト結果Datarow</summary>
    Private _SynthesisResultDataRow As DataRow = Nothing
    ''' <summary>総合テスト問別正誤DataTable</summary>
    Private _SynthesisResultTrueFalseTbl As DataTable = Nothing
#End Region

#Region "----- プロパティ -----"
    ''' <summary>総合テスト結果DataRowの設定</summary>
    Public WriteOnly Property SynthesisResultDataRow As DataRow
        Set(ByVal value As DataRow)
            _SynthesisResultDataRow = value
        End Set
    End Property

    ''' <summary>総合テスト問別正誤DataTableの設定</summary>
    Public WriteOnly Property SynthesisResultTrueFalseTbl As DataTable
        Set(ByVal dt As DataTable)
            _SynthesisResultTrueFalseTbl = dt
        End Set
    End Property

#End Region

#Region "----- コンストラクタ -----"

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' コントロールの配置を設定する
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        If dataBanker("TOFORM") = DISPLAY_ID_JG34 Then
            ' JG34画面
            SetControlJG34()
        Else
            ' JG43画面
            SetControlJG43()
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
    Private Sub frmTrueFalseList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            'イベントログ開始
            logger.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

            'フォームキャプション設定
            'Me.Text = FORM_TEXT
            Me.Text = _DisplayName
            ''ユーザーID設定
            'Me.UserId = ”ID：" & DataManager.GetInstance.UserId
            ''ユーザー名設定
            'Me.UserName = "氏名：" & DataManager.GetInstance.UserName
            '画面表示名設定
            Me.lblBottomName.Text = _DisplayName
            '画面表示ID設定
            Me.lblBottomCode.Text = _DisplayId

            'DataGridView初期化処理
            Call grdList_init()

            'データ設定処理
            Call SetData()

            ' 総合テスト履歴問題コード作成
            If _DisplayId = DISPLAY_ID_JG43 Then
                DataManager.GetInstance.QuestionCodeList = DataManager.GetInstance.PracticeQuestionDefine.GetSynthesisResultPracticeQuestion(_SynthesisResultTrueFalseTbl)
            End If

            'フォーカス設定
            Me.btnBack.Focus()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ' ''' <summary>
    ' ''' 問題番号選択処理
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub grdLeftList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLeftList.CellContentClick
    '    Try
    '        If TypeOf grdLeftList.Columns(e.ColumnIndex) Is DataGridViewLinkColumn AndAlso e.RowIndex >= 0 Then
    '            Call SetQuestionNo(e.RowIndex)
    '        End If
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    ' ''' <summary>
    ' ''' 問題番号選択処理
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub grdLeftList_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdLeftList.CellMouseDoubleClick
    '    Try
    '        If e.RowIndex < 0 Then Exit Sub
    '        Call SetQuestionNo(e.RowIndex)
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    ' ''' <summary>
    ' ''' 問題番号選択処理
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub grdRightList_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRightList.CellContentClick
    '    Try
    '        If TypeOf grdRightList.Columns(e.ColumnIndex) Is DataGridViewLinkColumn AndAlso e.RowIndex >= 0 Then
    '            Call SetQuestionNo(e.RowIndex + 50)
    '        End If
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    ' ''' <summary>
    ' ''' 問題番号選択処理
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub grdRightList_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdRightList.CellMouseDoubleClick
    '    Try
    '        If e.RowIndex < 0 Then Exit Sub
    '        Call SetQuestionNo(e.RowIndex + 50)
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    ''' <summary>
    ''' ログアウト処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()

        Try
            logger.Start()

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
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click

        Try
            logger.Start()
            '画面を閉じる
            Me.Close()

        Catch ex As Exception
            'ログ出力
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ出力
            logger.End()
        End Try

    End Sub

#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' JG33総合テスト採点結果用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlJG34()
        Try
            _DisplayId = DISPLAY_ID_JG34
            _DisplayName = DISPLAY_NAME_JG34
            _DisplayBackId = DISPLAY_ID_JG33

            lblTitle.Text = "テスト問別正誤一覧"
            lblTestName.Visible = False
            btnBack.Text = "テスト採点結果へ戻る"

        Catch ex As Exception
            'ログ出力
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' JG42総合テスト採点結果用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlJG43()
        Try
            _DisplayId = DISPLAY_ID_JG43
            _DisplayName = DISPLAY_NAME_JG43
            _DisplayBackId = DISPLAY_ID_JG42

            lblTitle.Text = "テスト問別正誤一覧"
            lblTestName.Visible = True
            btnBack.Text = "テスト採点結果へ戻る"

        Catch ex As Exception
            'ログ出力
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>データグリッドビューの初期化</summary>
    Private Sub grdList_init()

        Try

            'CELLを編集不可にする
            grdLeftList.Columns(INT_GRD_MONNO).ReadOnly = True
            grdLeftList.Columns(INT_GRD_MONTHEME).ReadOnly = True
            grdLeftList.Columns(INT_GRD_CORRECT).ReadOnly = True
            grdLeftList.Columns(INT_GRD_ANSWER).ReadOnly = True
            grdLeftList.Columns(INT_GRD_TRUEFALSE).ReadOnly = True
            grdRightList.Columns(INT_GRD_MONNO).ReadOnly = True
            grdRightList.Columns(INT_GRD_MONTHEME).ReadOnly = True
            grdRightList.Columns(INT_GRD_CORRECT).ReadOnly = True
            grdRightList.Columns(INT_GRD_ANSWER).ReadOnly = True
            grdRightList.Columns(INT_GRD_TRUEFALSE).ReadOnly = True

            'ユーザーがすべての行を削除できないようにする
            grdLeftList.AllowUserToDeleteRows = False
            grdRightList.AllowUserToDeleteRows = False

            'ユーザーが新しい行を追加できないようにする
            grdLeftList.AllowUserToAddRows = False
            grdRightList.AllowUserToAddRows = False

            '列の幅をユーザーが変更できないようにする
            grdLeftList.AllowUserToResizeColumns = False
            grdRightList.AllowUserToResizeColumns = False

            '行の高さをユーザーが変更できないようにする
            grdLeftList.AllowUserToResizeRows = False
            grdRightList.AllowUserToResizeRows = False

            ''垂直スクロールバーを表示する
            'For Each c As Control In grdJhoken.Controls
            '    If TypeOf c Is VScrollBar Then
            '        _vsBar = DirectCast(c, VScrollBar)

            '        AddHandler _vsBar.VisibleChanged, AddressOf vsBar_VisibleChanged
            '    End If
            'Next
            '_vsBar.Show()

        Catch ex As Exception
            logger.Error(ex)
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

            Dim detailDataRow() As DataRow = Nothing
            Dim questionNo As String = ""
            Dim leftCount As Integer = 0
            Dim rightCount As Integer = 0
            Dim i As Integer = 0

            'フォームのレイアウトロジックを中断する
            Me.grdLeftList.SuspendLayout()
            Me.grdRightList.SuspendLayout()

            ' コントロールにセット
            ' テスト名 + 実施日
            If lblBottomCode.Text = DISPLAY_ID_JG43 Then
                lblTestName.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.TestName) _
                                    & " (" _
                                    & _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.TestDate).ToString.Replace("/", ".") _
                                    & ")実施"
            End If

            ' 問題・解答・正誤内容をセットする
            If Not IsNothing(_SynthesisResultTrueFalseTbl) Then
                detailDataRow = _SynthesisResultTrueFalseTbl.Select
                For i = 0 To detailDataRow.Length - 1
                    If i <= 49 Then
                        Me.grdLeftList.Rows.Add()
                        With Me.grdLeftList.Rows(leftCount)
                            ' 問番号
                            '.Cells(0).Value = "問" & detailDataRow(i).Item(MiniResultDefine.MinTrueFalseTblIndex.QuestionCode)
                            .Cells(0).Value = "問" & i + 1
                            ' 問題テーマ
                            .Cells(1).Value = detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.QuestionTheme)
                            ' 正解
                            .Cells(2).Value = detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.CorrectansAnswer)
                            ' 解答
                            .Cells(3).Value = detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.Answer)
                            ' 正誤
                            If detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.Errata) = "1" Then
                                .Cells(4).Value = "○"
                            Else
                                .Cells(4).Value = "×"
                            End If
                        End With
                        leftCount += 1
                    ElseIf i >= 50 Then
                        Me.grdRightList.Rows.Add()
                        With Me.grdRightList.Rows(rightCount)
                            ' 問番号
                            '.Cells(0).Value = "問" & detailDataRow(i).Item(MiniResultDefine.MinTrueFalseTblIndex.QuestionCode)
                            .Cells(0).Value = "問" & i + 1
                            ' 問題テーマ
                            .Cells(1).Value = detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.QuestionTheme)
                            ' 正解
                            .Cells(2).Value = detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.CorrectansAnswer)
                            ' 解答
                            .Cells(3).Value = detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.Answer)
                            ' 正誤
                            If detailDataRow(i).Item(SynthesisResultDefine.SynthesisTrueFalseTblIndex.Errata) = "1" Then
                                .Cells(4).Value = "○"
                            Else
                                .Cells(4).Value = "×"
                            End If
                        End With
                        rightCount += 1
                    End If
                Next
            End If

            'フォームのレイアウトロジックを再開する
            Me.grdLeftList.ResumeLayout()
            Me.grdRightList.ResumeLayout()

        Catch ex As Exception
            'ログ出力
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' 選択問題番号設定処理
    ' ''' </summary>
    ' ''' <param name="questionNo">問題番号</param>
    ' ''' <remarks></remarks>
    'Private Sub SetQuestionNo(ByVal questionNo As Integer)
    '    Try

    '        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    '        dataBanker("FROMFORM") = Me.lblBottomCode.Text

    '        'dataBanker("TOFORM") = DISPLAY_ID_JG34 '<=『小問』or『中問』の判断は？
    '        dataBanker("TOFORM") = "JG35"

    '        '総合テスト解説画面を表示
    '        Dim frm As New frmQuestionComment(questionNo)
    '        frm.SynthesisResultTrueFalseTbl = _SynthesisResultTrueFalseTbl
    '        frm.ShowDialog(Me)
    '        'DataManager.GetInstance.Infomation = frm.Infomation
    '        If DataManager.GetInstance().IsLogouting Then
    '            Me.Close()
    '        End If

    '    Catch ex As Exception
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    ' ''' <summary>
    ' ''' お知らせ再設定処理
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Protected Overrides Sub mailClosed()
    '    Try
    '        'お知らせを削除する
    '        DataManager.GetInstance.Infomation = ""
    '    Catch ex As Exception
    '        'ログ出力
    '        logger.Error(ex)
    '        Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

#End Region

End Class