''' <summary>
''' 小テスト履歴一覧画面(JG39)
''' </summary>
''' <remarks></remarks>
Public Class frmSmallTestHistoryList

#Region "----- 定数 ----- "

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "小テスト履歴一覧"
    '2012/06/26 NOZAO ADD S
    ''' <summary>処理対象データキャプション</summary>
    Private Const DATA_TEXT As String = "小テスト実施履歴"
    '2012/06/26 NOZAO ADD E
    ''' <summary>画面表示ID(JG37)</summary>
    Private Const DISPLAY_ID_JG37 As String = "JG37"
    ''' <summary>画面表示ID(JG39)</summary>
    Private Const DISPLAY_ID_JG39 As String = "JG39"
    ''' <summary>画面表示ID(JG40)</summary>
    Private Const DISPLAY_ID_JG40 As String = "JG40"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "小テスト履歴一覧画面"
    ''' <summary>データグリッドビューの列番定数</summary>
    Private Const INT_GRD_TESTNAME As Integer = 0
    Private Const INT_GRD_BUNYA As Integer = 1
    Private Const INT_GRD_DAIBUN As Integer = 2
    Private Const INT_GRD_TYUBUN As Integer = 3
    Private Const INT_GRD_DATE As Integer = 4
    Private Const INT_GRD_TIME As Integer = 5
    Private Const INT_GRD_SEISUU As Integer = 6
    Private Const INT_GRD_MONSUU As Integer = 7
    Private Const INT_GRD_SEIRIT As Integer = 8

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>上の行の中分類データ(grdJhoken_Show[データグリッドビューの行追加])で使用</summary>
    Dim _strCyubunU As String
    ''' <summary>グリッド垂直スクロールバー</summary>
    Private _vsBar As VScrollBar
    ''' <summary>小テスト実施履歴データテーブル</summary>
    Dim _dtAllSmallTestHistory As DataTable = Nothing

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

    ''' <summary>
    ''' 検索条件を設定する(コンボボックスセット)
    ''' </summary>
    Private Sub setSeachCondition()

        Try

            'テスト名の読み込み
            Dim lstTestName As New List(Of String)
            '「すべて」付与
            lstTestName = AddSubete(lstTestName)
            'ランダムテストを付与
            lstTestName.Add("ランダムテスト")
            '指定テストを付与
            lstTestName.Add("指定テスト")
            '指定テスト名をListにセット
            For Each str As String In DataManager.GetInstance.SpecificDefine.GetSpecificTestNameList
                lstTestName.Add(str)
            Next
            'コンボボックスデータソースにListをセット
            cmbTestName.DataSource = lstTestName

            'カテゴリー1の読み込み
            Dim lstCategory1 As List(Of String) = DataManager.GetInstance.CategoryDefine.GetClassCategoryName
            '「すべて」付与
            lstCategory1 = AddSubete(lstCategory1)
            'コンボボックスデータソースにListをセット
            cmbCategory1.DataSource = lstCategory1

            'カテゴリー2の読み込み
            Dim lstCategory2 As List(Of String) = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName
            lstCategory2 = AddSubete(lstCategory2)
            cmbCategory2.DataSource = lstCategory2

            'カテゴリー3の読み込み
            Dim lstCategory3 As List(Of String) = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName
            lstCategory3 = AddSubete(lstCategory3)
            cmbCategory3.DataSource = lstCategory3

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' 入力データチェック
    ''' </summary>
    Private Function IsInputData() As Boolean

        IsInputData = Nothing

        Try
            ''日付チェック
            'If dtpTestStart.ToShortDateString <> "" Then
            '    If IsDate(dtpTestStart.ToShortDateString) = False Then

            '        Call MsgBox("実施日(開始)の日付を正しく入力してください", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            '        dtpTestStart.Focus()

            '    End If
            'End If
            'If dtpTestEnd.ToShortDateString <> "" Then
            '    If IsDate(dtpTestEnd.ToShortDateString) = False Then

            '        Call MsgBox("実施日(終了)の日付を正しく入力してください", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            '        dtpTestEnd.Focus()

            '    End If
            'End If

            '実施日の入力チェック
            If dtpTestStart.ToShortDateString <> "" And dtpTestEnd.ToShortDateString <> "" Then
                If dtpTestStart.ToShortDateString > dtpTestEnd.ToShortDateString Then
                    '2012/06/25 NOZAO CHG S
                    'Call MsgBox("実施日の開始が終了日を超えています", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("E070")
                    '2012/06/25 NOZAO CHG E
                    dtpTestStart.Focus()
                    Return False
                End If
            End If

            '正解率入力チェック
            If txtSeiOver.Text.Trim <> "" Then
                If txtSeiOver.Text > 100 Then
                    '2012/06/25 NOZAO CHG S
                    'Call MsgBox("正解率(以上)が101%を超えています", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("E075", {"正解率(以上)", "100%"})
                    '2012/06/25 NOZAO CHG E
                    txtSeiOver.Focus()
                    Return False
                End If
            End If
            If txtSeiUnder.Text.Trim <> "" Then
                If txtSeiUnder.Text > 100 Then
                    '2012/06/25 NOZAO CHG S
                    'Call MsgBox("正解率(以下)が101%を超えています", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("E075", {"正解率(以下)", "100%"})
                    '2012/06/25 NOZAO CHG S
                    txtSeiUnder.Focus()
                    Return False
                End If
            End If
            If txtSeiOver.Text.Trim <> "" And txtSeiUnder.Text.Trim <> "" Then
                If Decimal.Parse(txtSeiOver.Text.Trim) > Decimal.Parse(txtSeiUnder.Text.Trim) Then
                    '2012/06/25 NOZAO CHG S
                    'Call MsgBox("正解率(以上)が正解率(以下)超えています", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("E074", {"正解率"})
                    '2012/06/25 NOZAO CHG E
                    txtSeiOver.Focus()
                    Return False
                End If
            End If

            IsInputData = True

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Function

    ''' <summary>データグリッドビューの初期化</summary>
    Private Sub grdJhoken_init()

        Try

            'CELLを編集不可にする
            grdJhoken.Columns(INT_GRD_TESTNAME).ReadOnly = True
            grdJhoken.Columns(INT_GRD_BUNYA).ReadOnly = True
            grdJhoken.Columns(INT_GRD_DAIBUN).ReadOnly = True
            grdJhoken.Columns(INT_GRD_TYUBUN).ReadOnly = True
            grdJhoken.Columns(INT_GRD_DATE).ReadOnly = True
            grdJhoken.Columns(INT_GRD_TIME).ReadOnly = True
            grdJhoken.Columns(INT_GRD_SEISUU).ReadOnly = True
            grdJhoken.Columns(INT_GRD_MONSUU).ReadOnly = True
            grdJhoken.Columns(INT_GRD_SEIRIT).ReadOnly = True

            'ユーザーがすべての行を削除できないようにする
            grdJhoken.AllowUserToDeleteRows = False

            'ユーザーが新しい行を追加できないようにする
            grdJhoken.AllowUserToAddRows = False

            '列の幅をユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeColumns = False

            '行の高さをユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeRows = False

            '2行表示にする
            For Each tempCol As DataGridViewColumn In grdJhoken.Columns
                tempCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Next

            ''ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            'grdJhoken.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            ''行テンプレートの高さを設定する
            'grdJhoken.RowTemplate.Height = 50
            ''行の最低の高さを設定する
            'grdJhoken.RowTemplate.MinimumHeight = 50

            '並び替えができないようにする
            For Each c As DataGridViewColumn In grdJhoken.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c

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

    ''' <summary>データグリッドビューデータの絞込み</summary>
    Private Function grdDataSerch() As DataRow()

        grdDataSerch = Nothing

        Try

            Dim strFilter As String = ""
            Dim i As Integer = 0

            '検索条件select文を作成する
            ''テスト名
            'If cmbTestName.SelectedItem <> "すべて" Then
            '    'strFilter &= " AND TestName = '" & cmbTestName.SelectedItem & "'"
            '    strFilter &= " AND TestName LIKE '*" & cmbTestName.SelectedItem & "'"
            'End If
            'テスト名
            If cmbTestName.SelectedItem = "すべて" Then
            ElseIf cmbTestName.SelectedItem = "指定テスト" Then
                strFilter &= " AND TestName LIKE '" & cmbTestName.SelectedItem & "*'"
            Else
                strFilter &= " AND TestName LIKE '*" & cmbTestName.SelectedItem & "'"
            End If

            '分類
            If cmbCategory3.SelectedItem <> "すべて" Then
                strFilter &= " AND MiddleCategoryName = '" & cmbCategory3.SelectedItem & "'"
            Else
                If cmbCategory2.SelectedItem <> "すべて" Then
                    strFilter &= " AND LargeCategoryName = '" & cmbCategory2.SelectedItem & "'"
                Else
                    If cmbCategory1.SelectedItem <> "すべて" Then
                        strFilter &= " AND CategoryName = '" & cmbCategory1.SelectedItem & "'"
                    End If
                End If
            End If

            '実施日（開始）
            If dtpTestStart.ToShortDateString <> "" Then
                strFilter &= " AND TestDate >= '" & dtpTestStart.ToShortDateString & "'"
            End If

            '実施日（終了）
            If dtpTestEnd.ToShortDateString <> "" Then
                strFilter &= " AND TestDate <= '" & dtpTestEnd.ToShortDateString & "'"
            End If

            ''正解率(以上)
            'If txtSeiOver.Text <> "" Then
            '    'strFilter &= " AND AccuracyRate >= " & txtSeiOver.Text & ""
            '    If txtSeiOver.TextLength = 1 Then
            '        strFilter &= " AND AccuracyRate >= '00" & txtSeiOver.Text & "'"
            '    ElseIf txtSeiOver.TextLength = 2 Then
            '        strFilter &= " AND AccuracyRate >= '0" & txtSeiOver.Text & "'"
            '    Else
            '        strFilter &= " AND AccuracyRate >= '" & txtSeiOver.Text & "'"
            '    End If
            'End If

            ''正解率(以下)
            'If txtSeiUnder.Text <> "" Then
            '    'strFilter &= " AND AccuracyRate <= " & txtSeiUnder.Text & ""
            '    If txtSeiUnder.TextLength = 1 Then
            '        strFilter &= " AND AccuracyRate >= '00" & txtSeiUnder.Text & "'"
            '    ElseIf txtSeiUnder.TextLength = 2 Then
            '        strFilter &= " AND AccuracyRate >= '0" & txtSeiUnder.Text & "'"
            '    Else
            '        strFilter &= " AND AccuracyRate >= '" & txtSeiUnder.Text & "'"
            '    End If
            'End If

            'フィルター文字の最初がANDの場合は除去
            Dim wkDatas() As DataRow
            If strFilter <> "" Then
                If String.Compare("AND", strFilter.Trim.Substring(0, 3)) = 0 Then
                    'grdDataSerch = _dtAllSmallTestHistory.Select(strFilter.Trim.Substring(3).Trim, "")
                    wkDatas = _dtAllSmallTestHistory.Select(strFilter.Trim.Substring(3).Trim, "")
                Else
                    'grdDataSerch = _dtAllSmallTestHistory.Select(strFilter.Trim, "")
                    wkDatas = _dtAllSmallTestHistory.Select(strFilter.Trim, "")
                End If
            Else
                wkDatas = _dtAllSmallTestHistory.Select(strFilter.Trim, "")
            End If

            '正解率判定
            Dim retData() As DataRow = Nothing
            Dim Idx As Integer = 0
            Dim blnAdd As Boolean = False
            For i = 0 To wkDatas.Count - 1
                blnAdd = False
                If txtSeiOver.Text = "" And txtSeiUnder.Text = "" Then '正解率両方に入力なし
                    blnAdd = True
                ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text = "" Then '正解率以上に入力あり
                    If Decimal.Parse(wkDatas(i)("AccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) Then
                        blnAdd = True
                    End If
                ElseIf txtSeiOver.Text = "" And txtSeiUnder.Text <> "" Then '正解率以下に入力あり
                    If Decimal.Parse(wkDatas(i)("AccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                        blnAdd = True
                    End If
                ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text <> "" Then '正解率両方に入力あり
                    If Decimal.Parse(wkDatas(i)("AccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) And _
                       Decimal.Parse(wkDatas(i)("AccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                        blnAdd = True
                    End If
                End If
                If blnAdd Then
                    ReDim Preserve retData(Idx)
                    retData(Idx) = wkDatas(i)
                    Idx += 1
                End If
            Next
            grdDataSerch = retData
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Function

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

    ''' <summary>データグリッドビューの行追加</summary>
    ''' <param name="c1">分野</param>
    ''' <param name="c2">大分類</param>
    ''' <param name="c3">中分類</param>
    ''' <param name="c4">演習問題数</param>
    ''' <param name="c5">正解率</param>
    ''' <param name="c6">正解率</param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_Show(ByVal c1 As String, ByVal c2 As String, ByVal c3 As String, _
                               ByVal c4 As String, ByVal c5 As String, ByVal c6 As String, _
                               ByVal c7 As String, ByVal c8 As String, ByVal c9 As String)

        Try

            Dim item As New DataGridViewRow
            Dim blnRet As Boolean = True

            item.CreateCells(grdJhoken)

            ''前回と今回の中分類データが違うならグリッドに追加
            'If _strCyubunU <> c3 Then

            'セルの内容をセット
            With item

                .Cells(INT_GRD_TESTNAME).Value = c1
                .Cells(INT_GRD_BUNYA).Value = c2
                .Cells(INT_GRD_DAIBUN).Value = c3
                .Cells(INT_GRD_TYUBUN).Value = c4
                .Cells(INT_GRD_DATE).Value = c5
                .Cells(INT_GRD_TIME).Value = c6 & "分"
                .Cells(INT_GRD_SEISUU).Value = c7 & "問"
                .Cells(INT_GRD_MONSUU).Value = c8 & "問"
                .Cells(INT_GRD_SEIRIT).Value = c9 & "%"
                '行の高さを変更
                .Height = 30
            End With

            '行を追加
            grdJhoken.Rows.Add(item)
            'End If

            '現在の中分類データをセット
            _strCyubunU = c3

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' コンボボックス配列の最初にすべてを付与
    ''' </summary>
    Private Function AddSubete(ByVal lst As List(Of String)) As List(Of String)

        AddSubete = Nothing

        Try

            logger.Start()

            Dim lstInSubete As New List(Of String)

            lstInSubete.Add("すべて")

            For Each Str As String In lst
                lstInSubete.Add(Str)
            Next

            Return lstInSubete

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Function

    ''' <summary>
    ''' 配列の重複を除去
    ''' </summary>
    Private Function ArrayUniqe(ByVal List As List(Of String)) As List(Of String)

        ArrayUniqe = Nothing

        Try

            logger.Start()

            '重複を取り除いた配列をここに格納する
            Dim uniqe_list As New List(Of String)

            For Each str As String In List

                '要素が配列内に存在しないか？
                If uniqe_list.Contains(str) = False Then
                    '存在しなければ追加
                    uniqe_list.Add(str)
                End If

            Next

            '重複を始末した配列を返す
            Return uniqe_list

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Function

    ''' <summary>データグリッドビューソート</summary>
    ''' <param name="intRetu">データグリッドの列番号</param>
    ''' <remarks></remarks>
    Private Sub GrdSort(intRetu As Integer)

        'グリッドにデータがない場合は処理を抜ける
        If grdJhoken.Rows.Count <= 0 Then
            Return
        End If

        '並び替える列を決める
        Dim sortColumn As DataGridViewColumn = _
            grdJhoken(intRetu, 0).OwningColumn

        '並び替えの方向（昇順か降順か）を決める
        Dim sortDirection As System.ComponentModel.ListSortDirection = _
            System.ComponentModel.ListSortDirection.Ascending
        If Not (grdJhoken.SortedColumn Is Nothing) AndAlso _
                grdJhoken.SortedColumn.Equals(sortColumn) Then
            sortDirection = IIf(grdJhoken.SortOrder = SortOrder.Ascending, _
                System.ComponentModel.ListSortDirection.Descending, _
                System.ComponentModel.ListSortDirection.Ascending)
        End If

        '並び替えを行う
        grdJhoken.Sort(sortColumn, sortDirection)

    End Sub

    ''' <summary>NULLチェック</summary>
    ''' <param name="Data">NULLチェック対象データ</param>
    ''' <param name=" modoriti">NULL時の戻りデータ</param>
    ''' <remarks></remarks>
    Private Function IsNullChk(ByVal Data As Object, ByVal modoriti As Object) As Object

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
            IsNullChk = modoriti
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
    Private Sub frmPracticeConfirmHistory_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Dim blnRet As Boolean = False

            'イベントログ開始
            logger.Start()

            Me.processMessage = True
            Me.Show()
            Me.Refresh()

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            'Me.Text = DISPLAY_NAME
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG39
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME

            '検索条件(コンボボックス)を設定する
            setSeachCondition()

            'データグリッドビュー初期化処理
            grdJhoken_init()

            ''小テスト結果テーブル取得
            blnRet = DataManager.GetInstance.MiniResultDefine.GetMiniResultHistory(DataManager.GetInstance.CategoryDefine.CategoryDataTable, DataManager.GetInstance.SpecificDefine.SpecificHeaderDataTable)
            If blnRet = True Then
                _dtAllSmallTestHistory = DataManager.GetInstance.MiniResultDefine.MinResultHistoryDataTable  '《最終復活》
            Else
                Return
            End If

            If IsNothing(_dtAllSmallTestHistory) = True Then
                '2012/06/26 NOZAO CHG S
                'Call MsgBox("小テスト実施履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("I010", {DATA_TEXT})
                '2012/06/26 NOZAO CHG E

            Else
                If _dtAllSmallTestHistory.Rows.Count <= 0 Then
                    '2012/06/26 NOZAO CHG S
                    'Call MsgBox("小テスト実施履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I010", {DATA_TEXT})
                    '2012/06/26 NOZAO CHG E
                Else

                    'データグリッドビューに表示 '《最終復活》
                    For i = 0 To _dtAllSmallTestHistory.Rows.Count - 1
                        grdJhoken_Show(_dtAllSmallTestHistory(i)("TestName"), _dtAllSmallTestHistory(i)("CategoryName"), _
                                       _dtAllSmallTestHistory(i)("LargeCategoryName"), _dtAllSmallTestHistory(i)("MiddleCategoryName"), _
                                       _dtAllSmallTestHistory(i)("TestDate"), _dtAllSmallTestHistory(i)("TestTime"), _
                                       _dtAllSmallTestHistory(i)("CorrectAnswerCount"), _dtAllSmallTestHistory(i)("QuestionCount"), _
                                       _dtAllSmallTestHistory(i)("AccuracyRate"))
                    Next

                End If
            End If

            'コンボイベントを追加(イベント発動制御用)
            AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
            AddHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged
            AddHandler Me.cmbCategory3.SelectedIndexChanged, AddressOf Me.cmbCategory3_SelectedIndexChanged

            'フォーカス設定
            Me.btnBackHistoryMenu.Focus()
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
    ''' 分野コンボボックスIndex変更時処理(分野の親カテゴリでフィルター)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbCategory1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            'イベントログ開始
            logger.Start()

            If Not cmbCategory1.SelectedItem Is Nothing Then

                Dim categorId1 As String = cmbCategory1.SelectedItem
                Dim lstCategory2 As New List(Of String)
                Dim lstCategory3 As New List(Of String)
                Dim lstTmpCategory3 As New List(Of String)

                If categorId1 <> "すべて" Then

                    '大分類コンボボックスのLISTを変更(分野で絞込み)
                    lstCategory2 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(categorId1)
                    lstCategory2 = ArrayUniqe(lstCategory2)
                    lstCategory2 = AddSubete(lstCategory2)
                    cmbCategory2.DataSource = lstCategory2

                    'Dim categorId2 As String = cmbCategory2.SelectedItem
                    'If categorId2 <> 0 Then

                    '中分類コンボボックスのLISTを変更(分野で絞込み)
                    lstTmpCategory3 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName(categorId1)
                    For Each str2 As String In lstTmpCategory3
                        lstCategory3.Add(str2)
                    Next
                    lstCategory3 = ArrayUniqe(lstCategory3)
                    lstCategory3 = AddSubete(lstCategory3)
                    cmbCategory3.DataSource = lstCategory3

                    'Else
                    'End If
                Else

                    '大分類コンボボックスのLISTを変更(全件)
                    lstCategory2 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName
                    lstCategory2 = AddSubete(lstCategory2)
                    cmbCategory2.DataSource = lstCategory2

                    '中分類コンボボックスのLISTを変更(全件)
                    lstCategory3 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName
                    lstCategory3 = AddSubete(lstCategory3)
                    cmbCategory3.DataSource = lstCategory3

                End If
                cmbCategory2.SelectedIndex = 0
                cmbCategory3.SelectedIndex = 0
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
    ''' 大分類コンボボックスIndex変更時処理(大分類の親カテゴリでフィルター)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbCategory2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            'イベントログ開始
            logger.Start()

            Dim categorId1 As String = cmbCategory1.SelectedItem
            Dim categorId2 As String = cmbCategory2.SelectedItem
            Dim lstCategory1 As New List(Of String)
            Dim lstCategory2 As New List(Of String)
            Dim lstCategory3 As New List(Of String)
            Dim lstTmpCategory3 As New List(Of String)

            If categorId2 <> "すべて" Then

                '分野コンボボックスの表示を大分類の親分野に変更
                'lstCategory1 = DataManager.GetInstance.CategoryDefine.GetClassCategoryName(categorId2)
                'cmbCategory1.SelectedText = lstCategory1(0)
                RemoveHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
                cmbCategory1.Text = DataManager.GetInstance.CategoryDefine.GetClassCategoryName(categorId2)(0)
                AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged

                '分野コンボを再取得
                categorId1 = cmbCategory1.SelectedItem

                '中分類コンボボックスのLISTを変更(大分類で絞込み)
                lstCategory3 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName(categorId1, categorId2)
                'lstCategory3 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName("", categorId2)
                lstCategory3 = ArrayUniqe(lstCategory3)
                lstCategory3 = AddSubete(lstCategory3)
                cmbCategory3.DataSource = lstCategory3


                ''大分類コンボボックスのLISTを変更(分野で絞込み)
                'lstCategory2 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(cmbCategory1.SelectedItem)
                'lstCategory2 = ArrayUniqe(lstCategory2)
                'lstCategory2 = AddSubete(lstCategory2)
                'cmbCategory2.DataSource = lstCategory2

            Else

                If categorId1 <> "すべて" Then
                    '中分類コンボボックスのLISTを変更(分野で絞込み)
                    lstTmpCategory3 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName(categorId1)
                    For Each str2 As String In lstTmpCategory3
                        lstCategory3.Add(str2)
                    Next
                    lstCategory3 = ArrayUniqe(lstCategory3)
                    lstCategory3 = AddSubete(lstCategory3)
                    cmbCategory3.DataSource = lstCategory3
                Else
                    '中分類コンボボックスのLISTを変更(全件)
                    lstCategory3 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName
                    lstCategory3 = ArrayUniqe(lstCategory3)
                    lstCategory3 = AddSubete(lstCategory3)
                    cmbCategory3.DataSource = lstCategory3
                End If
            End If
            cmbCategory3.SelectedIndex = 0

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 中分類コンボボックスIndex変更時処理(中分類の親カテゴリでフィルター)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbCategory3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            'イベントログ開始
            logger.Start()

            Dim categorId3 As String = cmbCategory3.SelectedItem
            Dim lstCategory1 As New List(Of String)
            Dim lstCategory2 As New List(Of String)

            If categorId3 <> "すべて" Then

                '大分類コンボボックスの表示を中分類の親分野に変更
                RemoveHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged
                cmbCategory2.Text = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(categorId3, True)(0)
                AddHandler Me.cmbCategory2.SelectedIndexChanged, AddressOf Me.cmbCategory2_SelectedIndexChanged

                '分野コンボボックスの表示を大分類の親分野に変更
                RemoveHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged
                cmbCategory1.Text = DataManager.GetInstance.CategoryDefine.GetClassCategoryName(cmbCategory2.Text)(0)
                AddHandler Me.cmbCategory1.SelectedIndexChanged, AddressOf Me.cmbCategory1_SelectedIndexChanged

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
    ''' データグリッドビューセル内容クリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdJhoken.CellContentClick

        Try

            'イベントログ開始
            logger.Start()

            '[テスト名]リンク列の場合
            If e.ColumnIndex = INT_GRD_TESTNAME Then

                Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                dataBanker("TOFORM") = DISPLAY_ID_JG40

                Dim dtrSmallTestHistory() As DataRow
                Dim strFilter As String = ""
                Dim frm As New frmMiniTestMarkHistory

                '選択行のデータを取得しプロパティにセット
                strFilter = "TestName = '" & grdJhoken(INT_GRD_TESTNAME, e.RowIndex).Value & "'"
                strFilter &= " AND CategoryName = '" & grdJhoken(INT_GRD_BUNYA, e.RowIndex).Value & "'"
                strFilter &= " AND LargeCategoryName = '" & grdJhoken(INT_GRD_DAIBUN, e.RowIndex).Value & "'"
                strFilter &= " AND MiddleCategoryName = '" & grdJhoken(INT_GRD_TYUBUN, e.RowIndex).Value & "'"
                strFilter &= " AND TestDate = '" & grdJhoken(INT_GRD_DATE, e.RowIndex).Value & "'"
                strFilter &= " AND TestTime = '" & (grdJhoken(INT_GRD_TIME, e.RowIndex).Value).Replace("分", "") & "'"
                strFilter &= " AND CorrectAnswerCount = '" & (grdJhoken(INT_GRD_SEISUU, e.RowIndex).Value).Replace("問", "") & "'"
                strFilter &= " AND QuestionCount = '" & (grdJhoken(INT_GRD_MONSUU, e.RowIndex).Value).Replace("問", "") & "'"
                strFilter &= " AND AccuracyRate = '" & (grdJhoken(INT_GRD_SEIRIT, e.RowIndex).Value).Replace("%", "") & "'"
                dtrSmallTestHistory = _dtAllSmallTestHistory.Select(strFilter.Trim, "")
                frm.MiniResultDataRow = dtrSmallTestHistory(0)

                '問別正誤データを取得しプロパティにセット
                frm.MiniResultTrueFalseTbl = DataManager.GetInstance.GetTrueFalseDataTable(dtrSmallTestHistory(0)("TestCount"), dtrSmallTestHistory(0)("TestNo"), Constant.TestType.MiniResult)

                '小テスト履歴詳細画面表示
                'Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                'dataBanker("TOFORM") = DISPLAY_ID_JG40
                Me.Hide()
                frm.ShowDialog(Me)
                If DataManager.GetInstance.IsLogouting Then
                    Close()
                Else
                    Me.Show()
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
    ''' 履歴確認メニューへ戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackHistoryMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnBackHistoryMenu.Click

        Try
            'イベントログ開始
            logger.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = DISPLAY_ID_JG37

            Me.Close()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 正解率(以上)テキストキープレス処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub txtSeiOver_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeiOver.KeyPress

        Try
            'イベントログ開始
            logger.Start()

            '数字とBSきーの入力以外受け付けない()
            'If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And Not e.KeyChar = vbBack Then
            If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
                e.Handled = True
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
    ''' 正解率(以上)テキストロストフォーカス処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub txtSeiOver_LostFocus(sender As Object, e As System.EventArgs) Handles txtSeiOver.LostFocus

        Dim str As String = ""

        '文字入力なしの場合は処理を抜ける
        If txtSeiOver.Text.Trim = "" Then
            Return
        End If

        '数値判定
        If IsNumeric(txtSeiOver.Text) = False Then
            Call MsgBox("正解率(以上)が数値ではありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
            txtSeiOver.Focus()
            Return
        End If

        '小数第一位判定
        If txtSeiOver.Text.IndexOf(".") >= 0 Then
            If Strings.Left(txtSeiOver.Text, 1) = "." Then
                Call MsgBox("正解率(以上)が数値ではありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                txtSeiOver.Focus()
                Return
            End If
            str = Strings.Right(txtSeiOver.Text, 2)
            If Strings.Left(str, 1) <> "." Then
                Call MsgBox("小数第一位で入力してください", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                txtSeiOver.Focus()
                Return
            End If
        End If

    End Sub

    ''' <summary>
    ''' 正解率(以下)テキストキープレス処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub txtSeiUnder_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSeiUnder.KeyPress

        Try
            'イベントログ開始
            logger.Start()

            '数字とBSきーの入力以外受け付けない
            'If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And Not e.KeyChar = vbBack Then
            If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> "."c And e.KeyChar <> vbBack Then
                e.Handled = True
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
    ''' 正解率(以下)テキストロストフォーカス処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub txtSeiUnder_LostFocus(sender As Object, e As System.EventArgs) Handles txtSeiUnder.LostFocus

        Dim str As String = ""

        '文字入力なしの場合は処理を抜ける
        If txtSeiUnder.Text.Trim = "" Then
            Return
        End If

        '数値判定
        If IsNumeric(txtSeiUnder.Text) = False Then
            Call MsgBox("正解率(以下)が数値ではありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
            txtSeiUnder.Focus()
            Return
        End If

        '小数第一位判定
        If txtSeiUnder.Text.IndexOf(".") >= 0 Then
            If Strings.Left(txtSeiUnder.Text, 1) = "." Then
                Call MsgBox("正解率(以下)が数値ではありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                txtSeiUnder.Focus()
                Return
            End If
            str = Strings.Right(txtSeiUnder.Text, 2)
            If Strings.Left(str, 1) <> "." Then
                Call MsgBox("小数第一位で入力してください", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                txtSeiUnder.Focus()
                Return
            End If
        End If

    End Sub

    ''' <summary>
    ''' 抽出ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click

        Try

            'イベントログ開始
            logger.Start()

            '入力データチェック処理
            If IsInputData() = False Then
                Exit Sub
            End If

            If IsNothing(_dtAllSmallTestHistory) = True Then

                '2012/06/26 NOZAO CHG S
                'Call MsgBox("小テスト実施履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("I010", {DATA_TEXT})
                '2012/06/26 NOZAO CHG E

            Else

                'データグリッドビュー表示データ絞込み処理 '《最終復活》
                Dim dtTestRow() As DataRow = grdDataSerch()

                'データグリッドビューに表示 '《最終復活》
                If IsNothing(dtTestRow) = True Then
                    '2012/06/26 NOZAO CHG S
                    'Call MsgBox("指定の抽出条件では小テスト実施履歴が存在しません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I011", {DATA_TEXT})
                    '2012/06/26 NOZAO CHG E
                Else
                    If dtTestRow.Count <= 0 Then
                        '2012/06/26 NOZAO CHG S
                        'Call MsgBox("指定の抽出条件では小テスト実施履歴が存在しません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                        Common.Message.MessageShow("I011", {DATA_TEXT})
                        '2012/06/26 NOZAO CHG E
                    Else 'グリッド表示処理

                        grdJhoken.Rows.Clear()

                        For i = 0 To dtTestRow.Count - 1

                            grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("CategoryName"), dtTestRow(i)("LargeCategoryName"), _
                                            dtTestRow(i)("MiddleCategoryName"), dtTestRow(i)("TestDate"), dtTestRow(i)("TestTime"), _
                                            dtTestRow(i)("CorrectAnswerCount"), dtTestRow(i)("QuestionCount"), dtTestRow(i)("AccuracyRate"))

                            '    '正解率判定をここでする
                            '    If txtSeiOver.Text = "" And txtSeiUnder.Text = "" Then '正解率両方に入力なし
                            '        grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("CategoryName"), dtTestRow(i)("LargeCategoryName"), _
                            '                       dtTestRow(i)("MiddleCategoryName"), dtTestRow(i)("TestDate"), dtTestRow(i)("TestTime"), _
                            '                       dtTestRow(i)("CorrectAnswerCount"), dtTestRow(i)("QuestionCount"), dtTestRow(i)("AccuracyRate"))
                            '    ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text = "" Then '正解率以上に入力あり
                            '        If Decimal.Parse(dtTestRow(i)("AccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) Then
                            '            grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("CategoryName"), dtTestRow(i)("LargeCategoryName"), _
                            '                           dtTestRow(i)("MiddleCategoryName"), dtTestRow(i)("TestDate"), dtTestRow(i)("TestTime"), _
                            '                           dtTestRow(i)("CorrectAnswerCount"), dtTestRow(i)("QuestionCount"), dtTestRow(i)("AccuracyRate"))
                            '        End If
                            '    ElseIf txtSeiOver.Text = "" And txtSeiUnder.Text <> "" Then '正解率以下に入力あり
                            '        If Decimal.Parse(dtTestRow(i)("AccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                            '            grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("CategoryName"), dtTestRow(i)("LargeCategoryName"), _
                            '                           dtTestRow(i)("MiddleCategoryName"), dtTestRow(i)("TestDate"), dtTestRow(i)("TestTime"), _
                            '                           dtTestRow(i)("CorrectAnswerCount"), dtTestRow(i)("QuestionCount"), dtTestRow(i)("AccuracyRate"))
                            '        End If
                            '    ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text <> "" Then '正解率両方に入力あり
                            '        If Decimal.Parse(dtTestRow(i)("AccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) And _
                            '           Decimal.Parse(dtTestRow(i)("AccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                            '            grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("CategoryName"), dtTestRow(i)("LargeCategoryName"), _
                            '                           dtTestRow(i)("MiddleCategoryName"), dtTestRow(i)("TestDate"), dtTestRow(i)("TestTime"), _
                            '                           dtTestRow(i)("CorrectAnswerCount"), dtTestRow(i)("QuestionCount"), dtTestRow(i)("AccuracyRate"))
                            '        End If
                            '    End If
                        Next

                    End If
                End If
            End If

            '仮データ　'【最終削除】
            'grdJhoken_Show("ランダムテスト", "ストラテジ系", "経営戦略", "経営戦略マネジメント" _
            '               , "2012.04.19", "35分", "26問", "30問", "86％")

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 正解率ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblSeiRitu_Click(sender As Object, e As System.EventArgs) Handles lblSeiRitu.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_SEIRIT)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 問題数ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblMonsuu_Click(sender As System.Object, e As System.EventArgs) Handles lblMonsuu.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_MONSUU)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 正解数ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblSeisuu_Click(sender As System.Object, e As System.EventArgs) Handles lblSeisuu.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_SEISUU)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' テスト時間ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblTime_Click(sender As System.Object, e As System.EventArgs) Handles lblTime1.Click, lblTime2.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_TIME)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 実施日ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblDate_Click(sender As System.Object, e As System.EventArgs) Handles lblDate.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_DATE)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 中分類ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblTyuBun_Click(sender As System.Object, e As System.EventArgs) Handles lblTyuBun.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_TYUBUN)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 大分類ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblDaiBun_Click(sender As System.Object, e As System.EventArgs) Handles lblDaiBun.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_DAIBUN)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' 分野ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblBunya_Click(sender As System.Object, e As System.EventArgs) Handles lblBunya.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_BUNYA)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' テスト名ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblTestName_Click(sender As System.Object, e As System.EventArgs) Handles lblTestName.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_TESTNAME)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' データグリッドビューソート時比較処理(数値ソート用)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_SortCompare(sender As Object, e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles grdJhoken.SortCompare

        Try
            logger.Start()

            Select Case e.Column.Index
                Case INT_GRD_TIME
                    e.SortResult = CInt(e.CellValue1.replace("分", "")) - CInt(e.CellValue2.replace("分", ""))
                    e.Handled = True
                Case INT_GRD_SEISUU
                    e.SortResult = CInt(e.CellValue1.replace("問", "")) - CInt(e.CellValue2.replace("問", ""))
                    e.Handled = True
                Case INT_GRD_MONSUU
                    e.SortResult = CInt(e.CellValue1.replace("問", "")) - CInt(e.CellValue2.replace("問", ""))
                    e.Handled = True
                Case INT_GRD_SEIRIT
                    e.SortResult = CInt(e.CellValue1.replace("%", "")) - CInt(e.CellValue2.replace("%", ""))
                    e.Handled = True
            End Select

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