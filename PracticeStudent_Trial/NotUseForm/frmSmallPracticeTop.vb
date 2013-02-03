''' <summary>
''' 小問逐次演習トップ画面(JG17)
''' </summary>
''' <remarks></remarks>
Public Class frmSmallPracticeTop

#Region "----- 定数 ----- "

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "小問逐次演習トップ"
    ''' <summary>画面表示ID(JG15)</summary>
    Private Const DISPLAY_ID_JG15 As String = "JG15"
    ''' <summary>画面表示ID(JG17)</summary>
    Private Const DISPLAY_ID_JG17 As String = "JG17"
    ''' <summary>画面表示ID(JG18)</summary>
    Private Const DISPLAY_ID_JG18 As String = "JG18"
    ''' <summary>画面表示ID(JG19)</summary>
    Private Const DISPLAY_ID_JG19 As String = "JG19"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "小問逐次演習トップ画面"
    ''' <summary>データグリッドビューの列番定数</summary>
    Private Const INT_GRD_BUNSENTAK As Integer = 0
    Private Const INT_GRD_BUNYA As Integer = 1
    Private Const INT_GRD_DAIBUN As Integer = 2
    Private Const INT_GRD_TYUSENTAK As Integer = 3
    Private Const INT_GRD_TYUBUN As Integer = 4
    Private Const INT_GRD_SEIKAI As Integer = 5
    Private Const INT_GRD_MONMOU As Integer = 6
    Private Const INT_GRD_TYUID As Integer = 7
#End Region

#Region "----- 列挙子 ----- "

    ''' <summary>ダミー作成用Enum</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>分類名</summary>
        CategoryName = 0
        ''' <summary>分類カテゴリーID</summary>
        CategoryId
        ''' <summary>大分類名</summary>
        LargeCategoryName
        ''' <summary>大分類カテゴリーID</summary>
        LargeCategoryId
        ''' <summary>中分類名</summary>
        MiddleCategoryName
        ''' <summary>中分類カテゴリーID</summary>
        MiddleCategoryId
        ''' <summary>グループ名</summary>
        GroupName
        ''' <summary>グループID</summary>
        GroupId
        ''' <summary>キーワード</summary>
        Keyword
    End Enum

#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    Dim _strBunyaU As String '上の行の分野データ(grdJhoken_Show[データグリッドビューの行追加])で使用
    Dim _strCyubunU As String '上の行の中分類データ(grdJhoken_Show[データグリッドビューの行追加])で使用
    Private _vsBar As VScrollBar 'グリッド垂直スクロールバー
    Dim _blnComChk As Boolean = True 'コミットフラグ

    ''データグリッドビューの表示データテーブル(分類)
    Dim _dtCategory As DataTable = Nothing

    'データグリッドビューの表示データ変数(演習履歴)
    Dim _GroupIdList As Generic.Dictionary(Of String, Generic.List(Of String)) = Nothing 'グループIDリスト
    Dim _AccuracyRate As Generic.Dictionary(Of String, String) = Nothing '正解率
    Dim _PracticeCount As Generic.Dictionary(Of String, Integer) = Nothing '実施問題数
    Dim _EntryCount As Generic.Dictionary(Of String, Integer) = Nothing '登録問題数

    'Dammyデータ作成用
    Dim _strBunyaD As String '上の行の分野データ(grdJhoken_Show[データグリッドビューの行追加])で使用
    Dim _strBunyaC As String '上の行の分野データ(grdJhoken_Show[データグリッドビューの行追加])で使用
    Dim _a As Integer = -1
    Dim _b As Integer = 99
    Dim _c As Integer = 199
    Dim _d As Integer = 299

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
    ''' <param name="c1">分野</param>
    ''' <param name="c2">大分類</param>
    ''' <param name="c3">中分類</param>
    ''' <param name="c4">正解率</param>
    ''' <param name="c5">問題網羅1</param>
    ''' <param name="c6">問題網羅2</param>
    ''' <param name="c7">中分類ID</param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_Show(ByVal c1 As String, ByVal c2 As String, ByVal c3 As String, _
                               ByVal c4 As String, ByVal c5 As String, ByVal c6 As String, _
                               ByVal c7 As String)

        Try

            Dim item As New DataGridViewRow
            Dim blnRet As Boolean = True

            item.CreateCells(grdJhoken)

            '前回と今回の中分類データが違うならグリッドに追加
            If _strCyubunU <> c3 Then

                'セルの内容をセット
                With item

                    '上の行の分野データと同じならTagプロパティ=True
                    If _strBunyaU = c1 Then
                        .Cells(INT_GRD_BUNSENTAK).Tag = True
                        .Cells(INT_GRD_BUNSENTAK).ReadOnly = True
                    End If

                    .Cells(INT_GRD_BUNYA).Value = c1
                    .Cells(INT_GRD_DAIBUN).Value = c2
                    .Cells(INT_GRD_TYUBUN).Value = c3
                    .Cells(INT_GRD_SEIKAI).Value = c4 & "%"
                    .Cells(INT_GRD_MONMOU).Value = c5 & "/" & c6
                    .Cells(INT_GRD_TYUID).Value = c7

                End With

                '行を追加
                grdJhoken.Rows.Add(item)
            End If

            '現在の分野データをセット
            _strBunyaU = c1

            '現在の中分類データをセット
            _strCyubunU = c3

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>データグリッドビューの演習履歴データアップデート</summary>
    ''' <remarks></remarks>
    Private Sub grdJhoken_EnsyuHistUpdata()

        Try

            Dim item As New DataGridViewRow
            Dim blnRet As Boolean = True

            'データグリッドビューに表示するデータを取得(演習履歴)
            _GroupIdList = DataManager.GetInstance.CategoryDefine.GetGroupIdForMiddleCategory
            blnRet = DataManager.GetInstance.PracticeQuestionDefine.GetPracticeHistory(_GroupIdList, _AccuracyRate, _PracticeCount, _EntryCount)
            If blnRet = False Then
                Exit Sub
            End If

            For Each dgvRows As DataGridViewRow In grdJhoken.Rows

                dgvRows.Cells(INT_GRD_SEIKAI).Value = _AccuracyRate(dgvRows.Cells(INT_GRD_TYUID).Value) & "%"
                dgvRows.Cells(INT_GRD_MONMOU).Value = _PracticeCount(dgvRows.Cells(INT_GRD_TYUID).Value) & "/" & _EntryCount(dgvRows.Cells(INT_GRD_TYUID).Value)

            Next

            ''行を追加
            'grdJhoken.Rows.Add(item)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>データグリッドビューの初期化</summary>
    Private Sub grdJhoken_init()

        Try

            'チェックボックス列をを編集可にする
            grdJhoken.Columns(INT_GRD_BUNSENTAK).ReadOnly = False
            grdJhoken.Columns(INT_GRD_TYUSENTAK).ReadOnly = False
            '[分野][大分類][中分類][正解率][問題網羅]を編集不可にする
            grdJhoken.Columns(INT_GRD_BUNYA).ReadOnly = True
            grdJhoken.Columns(INT_GRD_DAIBUN).ReadOnly = True
            grdJhoken.Columns(INT_GRD_TYUBUN).ReadOnly = True
            grdJhoken.Columns(INT_GRD_SEIKAI).ReadOnly = True
            grdJhoken.Columns(INT_GRD_MONMOU).ReadOnly = True

            'ユーザーがすべての行を削除できないようにする
            grdJhoken.AllowUserToDeleteRows = False

            'ユーザーが新しい行を追加できないようにする
            grdJhoken.AllowUserToAddRows = False

            '列の幅をユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeColumns = False

            '行の高さをユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeRows = False

            '垂直スクロールバーを表示する
            For Each c As Control In grdJhoken.Controls
                If TypeOf c Is VScrollBar Then
                    _vsBar = DirectCast(c, VScrollBar)

                    AddHandler _vsBar.VisibleChanged, AddressOf vsBar_VisibleChanged
                End If
            Next
            _vsBar.Show()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
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

            If Not _vsBar.Visible Then
                '縦クロースバーを常に表示する。
                Dim borderWidth As Integer = 2

                _vsBar.Location = New Point(Me.grdJhoken.ClientRectangle.Width - _vsBar.Width, 0)
                _vsBar.Size = New Size(_vsBar.Width, Me.grdJhoken.ClientRectangle.Height - borderWidth)
                _vsBar.Show()
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>NULLチェック</summary>
    ''' <param name="Data">NULLチェック対象データ</param>
    ''' <param name=" modoriti">NULL時の戻りデータ</param>
    ''' <remarks></remarks>
    Private Function IsNullChk(ByVal Data As Object, ByVal modoriti As Object) As Object

        IsNullChk = Nothing

        Try

            If IsDBNull(Data) = True Then
                Return modoriti
            Else
                Return Data
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally

        End Try

    End Function

#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub frmSmallPracticeTop_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try

            'イベントログ開始
            logger.Start()

            Me.processMessage = True
            Me.Show()
            Me.Refresh()

            Dim i As Integer
            Dim blnRet As Boolean

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            'Me.Text = DISPLAY_NAME
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG17
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            'ボタンテキスト名を変更
            btnAllChk.Text = "全チェック"

            ' データグリッドビュー初期化処理
            grdJhoken_init()

            'データグリッドビューに表示するデータを取得(カテゴリー・分類)
            _dtCategory = New DataTable
            _dtCategory = DataManager.GetInstance.CategoryDefine.CategoryDataTable

            'データグリッドビューに表示するデータを取得(演習履歴)
            _GroupIdList = DataManager.GetInstance.CategoryDefine.GetGroupIdForMiddleCategory
            '《最終復活》
            blnRet = DataManager.GetInstance.PracticeQuestionDefine.GetPracticeHistory(_GroupIdList, _AccuracyRate, _PracticeCount, _EntryCount)
            If blnRet = False Then
                Exit Sub
            End If

            'カテゴリーデータテーブルにチェックボックスフラグ列を追加
            _dtCategory.Columns.Add("ChkBoxFlg", GetType(Boolean))

            'データグリッドビューの行追加()
            For i = 0 To _dtCategory.Rows.Count - 1
                grdJhoken_Show(_dtCategory.Rows(i)("CategoryName"), _
                               _dtCategory.Rows(i)("LargeCategoryName"), _
                               _dtCategory.Rows(i)("MiddleCategoryName"), _
                               _AccuracyRate(_dtCategory.Rows(i)("MiddleCategoryId")), _
                               _PracticeCount(_dtCategory.Rows(i)("MiddleCategoryId")), _
                               _EntryCount(_dtCategory.Rows(i)("MiddleCategoryId")), _
                               _dtCategory.Rows(i)("MiddleCategoryId"))
            Next

            'フォーカス設定
            Me.btnSmallPracticeStart.Focus()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.processMessage = False
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' データグリッドビューセルペインティング処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles grdJhoken.CellPainting

        Try

            ''イベントログ開始
            'logger.Start()

            If e.RowIndex < 0 Then
                Return  '行が0未満は何もしない
            ElseIf grdJhoken.Rows(e.RowIndex).IsNewRow Then
                Return  '新規行の時も何もしない


            ElseIf e.ColumnIndex = INT_GRD_BUNSENTAK Then '[選択]列

                Dim blnC As Boolean = grdJhoken(e.ColumnIndex, e.RowIndex).Tag '今回行のチェックボックスON、OFFをset
                Dim blnU As Boolean = Nothing '上行のチェックボックスTag
                Dim blnB As Boolean = Nothing '下行のチェックボックスTag

                If e.RowIndex > 0 Then
                    blnU = grdJhoken(e.ColumnIndex, e.RowIndex - 1).Tag '上行のチェックボックスTagON、TagOFFをset
                End If
                If e.RowIndex < grdJhoken.Rows.Count - 1 Then
                    blnB = grdJhoken(e.ColumnIndex, e.RowIndex + 1).Tag '下行のチェックボックスTagON、TagOFFをset
                End If


                '現在行＝下の行なら、現在行の下枠線を消す
                If Integer.Equals(blnC, blnB) Then
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                End If

                If blnC = True Then '今回行のチェックがTagONなら

                    '現在行のチェックボックスを隠す
                    Dim selected As Boolean = CBool(e.State And DataGridViewElementStates.Selected)
                    e.PaintBackground(e.CellBounds, selected)
                    e.Handled = True

                    Return
                Else
                    '現在行<>下の行なら、現在行の下枠線を消す
                    If blnC <> blnB Then
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                    End If
                End If

                Return

            ElseIf e.ColumnIndex = INT_GRD_BUNYA Then '分野列
            ElseIf e.ColumnIndex = INT_GRD_DAIBUN Then '大分類列
            ElseIf e.ColumnIndex = INT_GRD_TYUSENTAK Then '中分類チェックボックス列
                '中分類のチェックボックス右横の枠線を消す 
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
                Return
            Else
                Return
            End If

            '現在行の値をセット
            Dim C As Object = grdJhoken(e.ColumnIndex, e.RowIndex).Value

            '上の行の値をセット
            Dim U As Object = Nothing
            If e.RowIndex > 0 Then
                U = grdJhoken(e.ColumnIndex, e.RowIndex - 1).Value
            End If

            '下の行の値をセット
            Dim B As Object = Nothing
            If e.RowIndex < grdJhoken.Rows.Count - 1 Then
                B = grdJhoken(e.ColumnIndex, e.RowIndex + 1).Value
            End If

            '現在行＝下の行なら、現在行の下枠線を消す
            If Integer.Equals(C, B) Then
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
            End If

            '現在行＝上の行なら、現在行のテキストを消す
            If Integer.Equals(C, U) Then
                Dim selected As Boolean = CBool(e.State And DataGridViewElementStates.Selected)
                e.PaintBackground(e.CellBounds, selected)
                e.Handled = True
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            ''イベントログ終了
            'logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' データグリッドビューセル内容クリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdJhoken.CellContentClick

        Try

            'イベントログ開始
            logger.Start()

            Dim i As Integer
            Dim intMaxRow As Integer '同分野の最大行
            Dim strBunya As String 'カレント分野の文字

            Dim blnChk As Boolean 'クリック前のチェックボックスvalue

            '[選択]列の場合
            If e.ColumnIndex = INT_GRD_BUNSENTAK Then

                'カレント行を最大行カウンタ変数にセット
                intMaxRow = e.RowIndex

                'カレント分野の文字をセット
                strBunya = grdJhoken(INT_GRD_BUNYA, e.RowIndex).Value

                'チェックボックスが見えているセル以外は処理を抜ける
                For i = 0 To grdJhoken.RowCount - 1
                    If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then
                        If i = intMaxRow Then
                            Exit For
                        Else
                            Return
                        End If
                    End If
                Next

                '同じ分野文字の最大行を取得
                While strBunya = grdJhoken(INT_GRD_BUNYA, intMaxRow).Value

                    intMaxRow = intMaxRow + 1

                    'グリッドの最大行以上で処理を抜ける
                    If intMaxRow >= grdJhoken.RowCount Then
                        Exit While
                    End If
                End While

                'クリック前のチェックボックスvalueの逆をセット
                'blnChk = Not grdJhoken(e.ColumnIndex, e.RowIndex).Value
                blnChk = grdJhoken(e.ColumnIndex, e.RowIndex).EditedFormattedValue

                '同分野の中分類チェックボックスを変更
                For i = e.RowIndex To intMaxRow - 1

                    grdJhoken(INT_GRD_TYUSENTAK, i).Value = blnChk

                Next

            End If

            '[中分類]リンク列の場合
            If e.ColumnIndex = INT_GRD_TYUBUN Then

                Dim dtCyubun As New DataTable '該当中分類データ
                Dim newRowData As DataRow = Nothing
                Dim strB As String '分野文字
                Dim strD As String '大分類文字
                Dim strC As String '中分類文字
                Dim strTCon As Integer = 0

                '詳細画面表示ラベル文字の取得
                strB = grdJhoken(INT_GRD_BUNYA, e.RowIndex).Value
                strD = grdJhoken(INT_GRD_DAIBUN, e.RowIndex).Value
                strC = grdJhoken(INT_GRD_TYUBUN, e.RowIndex).Value

                '小問逐次演習詳細画面
                Dim frm As New frmSmallPracticeDetail(_dtCategory, strC, strB & "　－　" & strD & "　－　" & strC)
                Me.Hide()
                frm.ShowDialog(Me)
                If DataManager.GetInstance.IsLogouting Then
                    Close()
                Else
                    Me.Show()
                End If

                '詳細画面編集後のカテゴリーテーブルを取得
                _dtCategory = frm.GetValue

                '詳細編集後のチェックを確認
                For i = 0 To _dtCategory.Rows.Count - 1
                    If _dtCategory(i)("MiddleCategoryName") = strC Then
                        If IsNullChk(_dtCategory(i)("ChkBoxFlg"), False) = True Then
                            strTCon = strTCon + 1
                        End If
                    End If
                Next

                '詳細編集後のチェックを変更
                If strTCon > 0 Then
                    _blnComChk = False 'カテゴリテーブルのChkFlg更新を止める
                    grdJhoken(INT_GRD_TYUSENTAK, e.RowIndex).Value = True
                    _blnComChk = True 'カテゴリテーブルのChkFlg更新を再開
                Else
                    _blnComChk = False 'カテゴリテーブルのChkFlg更新を止める
                    grdJhoken(INT_GRD_TYUSENTAK, e.RowIndex).Value = False
                    _blnComChk = True 'カテゴリテーブルのChkFlg更新を再開
                End If
            End If

            '[中分類]チェックボックス列の場合(「中分類」の同分野チェックが全てONになった場合「分野」チェックをON)
            If e.ColumnIndex = INT_GRD_TYUSENTAK Then

                Dim intChkOn As Integer = 0

                'カレント行を最大行カウンタ変数にセット
                intMaxRow = 0

                'カレント分野の文字をセット
                strBunya = grdJhoken(INT_GRD_BUNYA, e.RowIndex).Value

                '同じ分野文字の最大数を取得
                For i = 0 To grdJhoken.RowCount - 1
                    If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then

                        'チェックONなら++
                        If grdJhoken(INT_GRD_TYUSENTAK, i).Value Then
                            intChkOn = intChkOn + 1
                        End If

                        intMaxRow = intMaxRow + 1

                    End If
                Next

                '同分野のチェックが全てONなら選択列のチェックをON
                If intMaxRow = intChkOn Then
                    For i = 0 To grdJhoken.RowCount - 1
                        If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then
                            grdJhoken(INT_GRD_BUNSENTAK, i).Value = True
                            Exit For
                        End If
                    Next
                Else
                    For i = 0 To grdJhoken.RowCount - 1
                        If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then
                            grdJhoken(INT_GRD_BUNSENTAK, i).Value = False
                            Exit For
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
    ''' データグリッドビューセル内容変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdJhoken.CellValueChanged

        Try

            'イベントログ開始
            logger.Start()

            '変更フラグがTRUEなら続行
            If _blnComChk = True Then
                If e.RowIndex >= 0 Then

                    '中分類チェック変更時
                    If e.ColumnIndex = INT_GRD_TYUSENTAK Then

                        '中分類の文字をセット
                        Dim strKey As String = grdJhoken(INT_GRD_TYUBUN, e.RowIndex).Value
                        Dim i As Integer

                        'カテゴリーデータテーブルのチェックフラグを変更する
                        For i = 0 To _dtCategory.Rows.Count - 1
                            If _dtCategory(i)("MiddleCategoryName") = strKey Then
                                _dtCategory(i)("ChkBoxFlg") = grdJhoken(INT_GRD_TYUSENTAK, e.RowIndex).Value
                                'Trace.WriteLine(_dtCategory(i)("MiddleCategoryName") & "_" & _dtCategory(i)("GroupName") & "が" & _dtCategory(i)("ChkBoxFlg") & "になりましたよ")
                            End If
                        Next

                    End If
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
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles grdJhoken.CurrentCellDirtyStateChanged

        Try

            'イベントログ開始
            logger.Start()

            If grdJhoken.CurrentCellAddress.X = INT_GRD_TYUSENTAK AndAlso _
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
    ''' データグリッドビューダブルクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdJhoken.CellContentDoubleClick
        Try

            'イベントログ開始
            logger.Start()

            Dim i As Integer
            Dim intMaxRow As Integer '同分野の最大行
            Dim strBunya As String 'カレント分野の文字

            Dim blnChk As Boolean 'クリック前のチェックボックスvalue

            'チェックボックスが選択列の場合
            If e.ColumnIndex = INT_GRD_BUNSENTAK Then

                'カレント行を最大行カウンタ変数にセット
                intMaxRow = e.RowIndex

                'カレント分野の文字をセット
                strBunya = grdJhoken(INT_GRD_BUNYA, e.RowIndex).Value

                'チェックボックスが見えているセル以外は処理を抜ける
                For i = 0 To grdJhoken.RowCount - 1
                    If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then
                        If i = intMaxRow Then
                            Exit For
                        Else
                            Return
                        End If
                    End If
                Next

                '同じ分野文字の最大行を取得
                While strBunya = grdJhoken(INT_GRD_BUNYA, intMaxRow).Value

                    intMaxRow = intMaxRow + 1

                    'グリッドの最大行以上で処理を抜ける
                    If intMaxRow >= grdJhoken.RowCount Then
                        Exit While
                    End If
                End While

                'クリック前のチェックボックスvalueの逆をセット
                'blnChk = Not grdJhoken(e.ColumnIndex, e.RowIndex).Value
                blnChk = grdJhoken(e.ColumnIndex, e.RowIndex).EditedFormattedValue
                'blnChk = grdJhoken(e.ColumnIndex, e.RowIndex).Value
                '同分野の中分類チェックボックスを変更
                For i = e.RowIndex To intMaxRow - 1

                    grdJhoken(INT_GRD_TYUSENTAK, i).Value = blnChk

                Next

                'grdJhoken.Focus()
                'grdJhoken.CurrentCell = grdJhoken(e.ColumnIndex + 1, e.RowIndex)
                'grdJhoken.CurrentCell = grdJhoken(e.ColumnIndex, e.RowIndex)
                'grdJhoken.Refresh()

            End If

            '[中分類]チェックボックス列の場合(「中分類」の同分野チェックが全てONになった場合「分野」チェックをON)
            If e.ColumnIndex = INT_GRD_TYUSENTAK Then

                Dim intChkOn As Integer = 0

                'カレント行を最大行カウンタ変数にセット
                intMaxRow = 0

                'カレント分野の文字をセット
                strBunya = grdJhoken(INT_GRD_BUNYA, e.RowIndex).Value

                '同じ分野文字の最大数を取得
                For i = 0 To grdJhoken.RowCount - 1
                    If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then

                        'チェックONなら++
                        If grdJhoken(INT_GRD_TYUSENTAK, i).Value Then
                            intChkOn = intChkOn + 1
                        End If

                        intMaxRow = intMaxRow + 1

                    End If
                Next

                '同分野のチェックが全てONなら選択列のチェックをON
                If intMaxRow = intChkOn Then
                    For i = 0 To grdJhoken.RowCount - 1
                        If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then
                            grdJhoken(INT_GRD_BUNSENTAK, i).Value = True
                            Exit For
                        End If
                    Next
                Else
                    For i = 0 To grdJhoken.RowCount - 1
                        If strBunya = grdJhoken(INT_GRD_BUNYA, i).Value Then
                            grdJhoken(INT_GRD_BUNSENTAK, i).Value = False
                            Exit For
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
    ''' 全チェックボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub btnAllChk_Click(sender As System.Object, e As System.EventArgs) Handles btnAllChk.Click

        Try

            'イベントログ開始
            logger.Start()

            Dim intGrdMaxCount As Integer = grdJhoken.RowCount 'データグリッドビューの最大行数
            Dim i As Integer

            If btnAllChk.Text = "全チェック" Then
                For i = 0 To intGrdMaxCount - 1
                    '中分類チェックをすべてON
                    grdJhoken(INT_GRD_TYUSENTAK, i).Value = True
                    '選択チェックをすべてON
                    grdJhoken(INT_GRD_BUNSENTAK, i).Value = True
                Next
                'ボタンテキスト名を変更
                btnAllChk.Text = "全チェック解除"
            Else

                For i = 0 To intGrdMaxCount - 1
                    '中分類チェックをすべてOFF
                    grdJhoken(INT_GRD_TYUSENTAK, i).Value = False
                    '選択チェックをすべてOFF
                    grdJhoken(INT_GRD_BUNSENTAK, i).Value = False
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
    ''' 未演習の問題チェックボックスチェック変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub chkMienshuPractice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMienshuPractice.CheckedChanged

        Try

            'イベントログ開始
            logger.Start()

            '未演習問題チェックON時
            If chkMienshuPractice.Checked = True Then

                '直近、再演習チェックボックスをOFF
                chkChokkinPractice.Checked = False
                chkSaienshuPractice.Checked = False

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
    ''' 直近の出題チェックボックスチェック変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub chkChokkinPractice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkChokkinPractice.CheckedChanged

        Try

            'イベントログ開始
            logger.Start()

            ' 直近の出題チェックON時
            If chkChokkinPractice.Checked = True Then

                '未演習チェックボックスをOFF
                chkMienshuPractice.Checked = False

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
    ''' 再演習チェックボックスチェック変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub chkSaienshuPractice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSaienshuPractice.CheckedChanged

        Try

            'イベントログ開始
            logger.Start()

            ' 再演習チェックON時
            If chkSaienshuPractice.Checked = True Then

                '未演習チェックボックスをOFF
                chkMienshuPractice.Checked = False

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
    ''' 逐次演習メニューへ戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackPracticeMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnBackPracticeMenu.Click

        Try
            logger.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG15

            Me.Close()
        Catch ex As Exception
            'ログ出力
            logger.Error(ex)
            'エラーメッセージ
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 小問逐次演習開始ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub btnSmallPracticeStart_Click(sender As System.Object, e As System.EventArgs) Handles btnSmallPracticeStart.Click

        Try

            'イベントログ開始
            logger.Start()

            Dim strArGroupID As New Generic.List(Of String)
            Dim QuestionCodeList As New Generic.Dictionary(Of Integer, QuestionCodeDefine)

            'チェックのあるグループID取得
            For i = 0 To _dtCategory.Rows.Count - 1
                If IsNullChk(_dtCategory(i)("ChkBoxFlg"), False) = True Then
                    strArGroupID.Add(_dtCategory(i)("GroupId"))
                End If
            Next

            'グループIDなしの場合
            If strArGroupID.Count <= 0 Then
                '2012/06/11 CST CHG S
                Call MsgBox("分類が選択されていません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "メッセージ")
                '2012/06/11 CST CHG E
                Exit Sub
            End If

            QuestionCodeList = DataManager.GetInstance.PracticeQuestionDefine.GetSmallPracticeQuestionList(strArGroupID, _
                                                                                                           chkKeisanPractice.Checked, _
                                                                                                           chkChokkinPractice.Checked, _
                                                                                                           chkSaienshuPractice.Checked, _
                                                                                                           chkMienshuPractice.Checked)

            'QuestionListがなしの場合
            If QuestionCodeList.Count <= 0 Then
                '2012/06/11 CST CHG S
                Call MsgBox("対象問題がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "メッセージ")
                '2012/06/11 CST CHG E
                Exit Sub
            End If

            'QuestionCodeListをセット
            DataManager.GetInstance.QuestionCodeList = QuestionCodeList

            '小問逐次演習問題画面表示
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG19

            Dim frm As New frmTest(0)
            Me.Hide()
            'テスト画面表示
            frm.ShowDialog(Me)
            If DataManager.GetInstance.IsLogouting Then
                Close()
            Else
                Me.Show()
                '2012/06/11 CST CHG S
                Me.Refresh()
                '2012/06/11 CST CHG E
                '演習履歴列を再描画する
                Call grdJhoken_EnsyuHistUpdata()
            End If

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

