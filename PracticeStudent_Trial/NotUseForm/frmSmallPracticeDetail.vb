Public Class frmSmallPracticeDetail

#Region "----- 定数 ----- "

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "分類詳細"
    ''' <summary>画面表示ID(JG17)</summary>
    Private Const DISPLAY_ID_JG17 As String = "JG17"
    ''' <summary>画面表示ID(JG18)</summary>
    Private Const DISPLAY_ID_JG18 As String = "JG18"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "分類詳細画面"

    ''' <summary>データグリッドビューの列番定数</summary>
    Private Const INT_GRD_SENTAK As Integer = 0
    Private Const INT_GRD_GROUP As Integer = 1
    Private Const INT_GRD_KEYWORD As Integer = 2

#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    Dim _strBunyaU As String '上の行の分野データ(grdJhoken_Show[データグリッドビューの行追加])で使用
    Private vsBar As VScrollBar 'グリッド垂直スクロールバー
    Dim _dtCategory As DataTable = Nothing 'カテゴリーデータテーブル
    Dim _strKey As String '中分類キー文字
#End Region

#Region "----- コンストラクタ -----"

    ''' <summary>
    ''' コンストラクタ処理
    ''' </summary>
    ''' <param name="dt">カテゴリーデータテーブル</param>
    ''' <param name="strKeyName">中分類内容</param>
    ''' <param name="strLbl">ラベル文字</param>
    ''' <remarks></remarks> 
    Public Sub New(ByVal dt As DataTable, ByVal strKeyName As String, ByVal strLbl As String)

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        'データテーブルをセット
        _dtCategory = dt

        'ラベル文字をセット
        lblKeiretu.Text = strLbl

        '中分類キー文字をセット
        _strKey = strKeyName

    End Sub

#End Region

#Region "----- メソッド -----"

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

    ''' <summary>
    ''' ログアウト処理
    ''' </summary>
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

    ''' <summary>データグリッドビューの行追加</summary>
    Private Sub grdJhoken_Show(ByVal c0 As Boolean, ByVal c1 As String, ByVal c2 As String)

        Try

            Dim item As New DataGridViewRow

            item.CreateCells(grdJhoken)

            'セルの内容をセット
            With item
                .Cells(INT_GRD_SENTAK).Value = c0
                .Cells(INT_GRD_GROUP).Value = c1
                .Cells(INT_GRD_KEYWORD).Value = c2

            End With

            '行を追加
            grdJhoken.Rows.Add(item)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>データグリッドビューの初期化</summary>
    Private Sub grdJhoken_init()

        Try

            'チェックボックス列をを編集可にする
            grdJhoken.Columns(INT_GRD_SENTAK).ReadOnly = False

            '[グループ][キーワード]を編集不可にする
            grdJhoken.Columns(INT_GRD_GROUP).ReadOnly = True
            grdJhoken.Columns(INT_GRD_KEYWORD).ReadOnly = True

            'ユーザーがすべての行を削除できないようにする
            grdJhoken.AllowUserToDeleteRows = False

            'ユーザーが新しい行を追加できないようにする
            grdJhoken.AllowUserToAddRows = False

            '列の幅をユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeColumns = False

            '行の高さをユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeRows = False

            '2行表示可にする
            For Each tempCol As DataGridViewColumn In grdJhoken.Columns
                tempCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Next

            'セルの内容に合わせて、行の高さを自動調整する
            grdJhoken.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

            '垂直スクロールバーを表示する
            For Each c As Control In grdJhoken.Controls
                If TypeOf c Is VScrollBar Then
                    vsBar = DirectCast(c, VScrollBar)

                    AddHandler vsBar.VisibleChanged, AddressOf vsBar_VisibleChanged
                End If
            Next
            vsBar.Show()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>カテゴリーデータテーブル値を渡す</summary>
    Public Function GetValue() As DataTable
        Return _dtCategory
    End Function

    ''' <summary>NULLチェック</summary>
    Private Function IsNullChk(ByVal Data As Object, ByVal modoriti As Object) As Object
        '2012/06/13 NOZAO ADD S
        IsNullChk = Nothing
        '2012/06/13 NOZAO ADD E
        Try
            If IsDBNull(Data) = True Then
                Return modoriti
            Else
                Return Data
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Function

#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    Private Sub frmSmallPracticeDetail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            'イベントログ開始
            logger.Start()

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            'Me.Text = DISPLAY_NAME
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG18
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            'ボタン名設定
            btnAllChk.Text = "全チェック"

            'データグリッドコントロールを初期化
            grdJhoken_init()

            'データグリッドビューの行追加(Keyと同一のグループのみ追加)
            For i = 0 To _dtCategory.Rows.Count - 1
                If _dtCategory.Rows(i)("MiddleCategoryName") = _strKey Then

                    grdJhoken_Show(IsNullChk(_dtCategory.Rows(i)("ChkBoxFlg"), False), _dtCategory.Rows(i)("GroupName"), _dtCategory.Rows(i)("Keyword"))

                End If
            Next

            '選択チェックボックスが全てONの場合全チェックボタンを「全チェック解除」に変更する
            Dim intMaxRows As Integer = grdJhoken.Rows.Count '最大行をセット
            Dim intChkOnCnt As Integer = 0 'チェックONの合計

            For i = 0 To intMaxRows - 1
                'チェックONの場合カウントアップ
                If grdJhoken(INT_GRD_SENTAK, i).Value = True Then
                    intChkOnCnt = intChkOnCnt + 1
                End If
            Next
            'グリッド最大行とチェックONの数が同じなら全チェックボタンを「全チェック解除」に変更する
            If intMaxRows = intChkOnCnt Then
                btnAllChk.Text = "全チェック解除"
            End If

            'フォーカス設定
            Me.btnBackPracticeMenu.Select()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' データグリッドビュー縦スクロールバー表示変更時処理
    ''' </summary>
    Private Sub vsBar_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'イベントログ開始
            logger.Start()

            If Not vsBar.Visible Then
                '縦クロースバーを常に表示する。
                Dim borderWidth As Integer = 2

                vsBar.Location = New Point(Me.grdJhoken.ClientRectangle.Width - vsBar.Width, 0)
                vsBar.Size = New Size(vsBar.Width, Me.grdJhoken.ClientRectangle.Height - borderWidth)
                vsBar.Show()
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' データグリッドビューセル内容変更時処理
    ''' </summary>
    Private Sub grdJhoken_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdJhoken.CellValueChanged

        Try

            'イベントログ開始
            logger.Start()

            If e.RowIndex >= 0 Then

                '中分類チェック変更時
                If e.ColumnIndex = INT_GRD_SENTAK Then

                    '中分類の文字をセット
                    Dim strKey As String = grdJhoken(INT_GRD_GROUP, e.RowIndex).Value
                    Dim i As Integer

                    'カテゴリーデータテーブルのチェックフラグを変更する
                    For i = 0 To _dtCategory.Rows.Count - 1
                        If _dtCategory(i)("GroupName") = strKey Then
                            _dtCategory(i)("ChkBoxFlg") = grdJhoken(INT_GRD_SENTAK, e.RowIndex).Value
                            'Trace.WriteLine(_dtCategory(i)("MiddleCategoryName") & "_" & _dtCategory(i)("GroupName") & "が" & _dtCategory(i)("ChkBoxFlg") & "になりましたよ")
                        End If
                    Next

                End If
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' データグリッドビューCurrentCellDirtyStateChanged処理(セル内容変更イベントでフォーカスを移動しなくても値がコミットされるようにする用)
    ''' </summary>
    Private Sub grdJhoken_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles grdJhoken.CurrentCellDirtyStateChanged

        Try

            'イベントログ開始
            logger.Start()

            If grdJhoken.CurrentCellAddress.X = INT_GRD_SENTAK AndAlso _
                                                        grdJhoken.IsCurrentCellDirty Then
                'コミットする
                grdJhoken.CommitEdit(DataGridViewDataErrorContexts.Commit)
                'Trace.WriteLine("コミットされたよ")
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' RowPrePaintイベントハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles grdJhoken.RowPrePaint
        'フォーカス枠を描画しない
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
    End Sub

    ''' <summary>
    ''' 全チェックボタンクリック処理
    ''' </summary>
    Private Sub btnAllChk_Click(sender As System.Object, e As System.EventArgs) Handles btnAllChk.Click

        Try

            'イベントログ開始
            logger.Start()

            Dim intGrdMaxCount As Integer = grdJhoken.RowCount 'データグリッドビューの最大行数
            Dim i As Integer

            If btnAllChk.Text = "全チェック" Then
                'チェックをすべてON
                For i = 0 To intGrdMaxCount - 1
                    grdJhoken(INT_GRD_SENTAK, i).Value = True
                Next

                'ボタンテキスト名を変更
                btnAllChk.Text = "全チェック解除"
            Else
                'チェックをすべてOFF
                For i = 0 To intGrdMaxCount - 1
                    grdJhoken(INT_GRD_SENTAK, i).Value = False
                Next

                'ボタンテキスト名を変更
                btnAllChk.Text = "全チェック"
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    Private Sub btnBackPracticeMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnBackPracticeMenu.Click

        Try
            'Dim frm As New frmSmallPracticeTop '小問逐次演習トップ画面

            'frm.Show()
            Me.Close()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub
#End Region

End Class