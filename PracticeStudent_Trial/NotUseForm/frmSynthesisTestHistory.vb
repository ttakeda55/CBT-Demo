''' <summary>
''' 総合テスト実施履歴一覧画面(JG41)
''' </summary>
''' <remarks></remarks>
Public Class frmSynthesisTestHistory

#Region "----- 定数 ----- "

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "総合テスト実施履歴一覧"
    '2012/06/26 NOZAO ADD S
    ''' <summary>処理対象データキャプション</summary>
    Private Const DATA_TEXT As String = "総合テスト実施履歴"
    '2012/06/26 NOZAO ADD E
    ''' <summary>画面表示ID(JG37)</summary>
    Private Const DISPLAY_ID_JG37 As String = "JG37"
    ''' <summary>画面表示ID(JG41)</summary>
    Private Const DISPLAY_ID_JG41 As String = "JG41"
    ''' <summary>画面表示ID(JG42)</summary>
    Private Const DISPLAY_ID_JG42 As String = "JG42"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "総合テスト実施履歴一覧画面"
    ''' <summary>データグリッドビューの列番定数</summary>
    Private Const INT_GRD_TESTNAME As Integer = 0
    Private Const INT_GRD_DATE As Integer = 1
    Private Const INT_GRD_TIME As Integer = 2
    Private Const INT_GRD_BUNYA1 As Integer = 3
    Private Const INT_GRD_BUNYA2 As Integer = 4
    Private Const INT_GRD_BUNYA3 As Integer = 5
    Private Const INT_GRD_SEIRIT As Integer = 6
    Private Const INT_GRD_TESTNO As Integer = 7
    Private Const INT_GRD_JISSIKAI As Integer = 8
#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>上の行の中分類データ(grdJhoken_Show[データグリッドビューの行追加])で使用</summary>
    Dim _strCyubunU As String
    ''' <summary>グリッド垂直スクロールバー</summary>
    Private _vsBar As VScrollBar
    ''' <summary>総合テスト実施履歴データテーブル</summary>
    Dim _dtAllSogoTestHistory As DataTable = Nothing

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
    ''' 検索条件を設定する
    ''' </summary>
    Private Sub setSeachCondition()

        Try

            'テスト名の読み込み
            Dim lstTestName As New List(Of String)
            'すべて付与
            lstTestName = AddSubete(lstTestName)
            ''ランダムテストを付与
            'lstTestName.Add("ランダムテスト")
            '指定テスト名をListにセット
            For Each str As String In DataManager.GetInstance.SynthesisDefine.GetSynthesisTestNameList
                lstTestName.Add(str)
            Next
            'コンボボックスデータソースにListをセット
            cmbTestName.DataSource = lstTestName

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
                    '2012/06/25 NOZAO CHG E
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
            grdJhoken.Columns(INT_GRD_DATE).ReadOnly = True
            grdJhoken.Columns(INT_GRD_TIME).ReadOnly = True
            grdJhoken.Columns(INT_GRD_BUNYA1).ReadOnly = True
            grdJhoken.Columns(INT_GRD_BUNYA2).ReadOnly = True
            grdJhoken.Columns(INT_GRD_BUNYA3).ReadOnly = True
            grdJhoken.Columns(INT_GRD_SEIRIT).ReadOnly = True

            'ユーザーがすべての行を削除できないようにする
            grdJhoken.AllowUserToDeleteRows = False

            'ユーザーが新しい行を追加できないようにする
            grdJhoken.AllowUserToAddRows = False

            '列の幅をユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeColumns = False

            '行の高さをユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeRows = False

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
            'テスト名
            If cmbTestName.SelectedItem <> "すべて" Then
                strFilter &= " AND TestName = '" & cmbTestName.SelectedItem & "'"
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
            '    strFilter &= " AND TotalAccuracyRate >= " & txtSeiOver.Text & ""
            'End If

            ''正解率(以下)
            'If txtSeiUnder.Text <> "" Then
            '    strFilter &= " AND TotalAccuracyRate <= " & txtSeiUnder.Text & ""
            'End If

            'フィルター文字の最初がANDの場合は除去
            Dim wkDatas() As DataRow
            If strFilter <> "" Then
                If String.Compare("AND", strFilter.Trim.Substring(0, 3)) = 0 Then
                    'grdDataSerch = _dtAllSogoTestHistory.Select(strFilter.Trim.Substring(3).Trim, "")
                    wkDatas = _dtAllSogoTestHistory.Select(strFilter.Trim.Substring(3).Trim, "")
                Else
                    'grdDataSerch = _dtAllSogoTestHistory.Select(strFilter.Trim, "")
                    wkDatas = _dtAllSogoTestHistory.Select(strFilter.Trim, "")
                End If
            Else
                'grdDataSerch = _dtAllSogoTestHistory.Select(strFilter.Trim, "")
                wkDatas = _dtAllSogoTestHistory.Select(strFilter.Trim, "")
            End If

            '正解率判定
            Dim blnAdd As Boolean = False
            Dim Idx As Integer = 0
            Dim retData() As DataRow = Nothing
            For i = 0 To wkDatas.Count - 1
                blnAdd = False
                If txtSeiOver.Text = "" And txtSeiUnder.Text = "" Then '正解率両方に入力なし
                    blnAdd = True
                ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text = "" Then '正解率以上に入力あり
                    If Decimal.Parse(wkDatas(i)("TotalAccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) Then
                        blnAdd = True
                    End If
                ElseIf txtSeiOver.Text = "" And txtSeiUnder.Text <> "" Then '正解率以下に入力あり
                    If Decimal.Parse(wkDatas(i)("TotalAccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                        blnAdd = True
                    End If
                ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text <> "" Then '正解率両方に入力あり
                    If Decimal.Parse(wkDatas(i)("TotalAccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) And _
                       Decimal.Parse(wkDatas(i)("TotalAccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
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
    ''' <param name="c1">テスト名</param>
    ''' <param name="c2">実施日</param>
    ''' <param name="c3">テスト時間</param>
    ''' <param name="c4">ストラテジ系</param>
    ''' <param name="c5">マネジメント系</param>
    ''' <param name="c6">テクノロジ系</param>
    ''' <param name="c7">総合正解率</param>
    ''' <param name="c8">テストNo</param>
    ''' <param name="c9">実施回数</param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_Show(ByVal c1 As String, ByVal c2 As String, ByVal c3 As String, _
                               ByVal c4 As String, ByVal c5 As String, ByVal c6 As String, _
                               ByVal c7 As String, ByVal c8 As String, ByVal c9 As String)

        Try

            Dim item As New DataGridViewRow
            Dim blnRet As Boolean = True

            item.CreateCells(grdJhoken)

            'セルの内容をセット
            With item

                .Cells(INT_GRD_TESTNAME).Value = c1
                .Cells(INT_GRD_DATE).Value = c2
                .Cells(INT_GRD_TIME).Value = c3 & "分"
                .Cells(INT_GRD_BUNYA1).Value = c4 & "%"
                .Cells(INT_GRD_BUNYA2).Value = c5 & "%"
                .Cells(INT_GRD_BUNYA3).Value = c6 & "%"
                .Cells(INT_GRD_SEIRIT).Value = c7 & "%"
                .Cells(INT_GRD_TESTNO).Value = c8
                .Cells(INT_GRD_JISSIKAI).Value = c9

            End With

            '行を追加
            grdJhoken.Rows.Add(item)

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
        End Try
        IsNullChk = modoriti
    End Function


#End Region

#Region "----- イベント -----"

    ''' <summary>
    ''' フォームロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub frmPracticeConfirmHistory_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            'イベントログ開始
            logger.Start()

            Me.processMessage = True
            Me.Show()
            Me.Refresh()

            Dim blnRet As Boolean = False

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            'Me.Text = DISPLAY_NAME
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG41
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME

            '検索条件(コンボボックス)を設定する
            setSeachCondition()

            'データグリッドビュー初期化処理
            grdJhoken_init()

            '総合テスト結果ヘッダテーブル取得　'《最終復活》
            blnRet = DataManager.GetInstance.SynthesisResultDefine.GetSynthesisResultHistory( _
                     DataManager.GetInstance.CategoryDefine.CategoryDataTable, _
                     DataManager.GetInstance.PracticeQuestionDefine.PracticeQuestionListDataTable, _
                     DataManager.GetInstance.SynthesisDefine.SynthesisHeaderDataTable)

            If blnRet = True Then
                _dtAllSogoTestHistory = DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHistoryDataTable
            Else
                Return
            End If
            If IsNothing(_dtAllSogoTestHistory) = True Then '《最終復活》

                '2012/06/25 NOZAO CHG S
                'Call MsgBox("総合テスト実施履歴一覧がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("I010", {FORM_TEXT})
                '2012/06/25 NOZAO CHG E

            Else
                If _dtAllSogoTestHistory.Rows.Count <= 0 Then
                    '2012/06/25 NOZAO CHG S
                    'Call MsgBox("総合テスト実施履歴一覧がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I010", {FORM_TEXT})
                    '2012/06/25 NOZAO CHG E

                Else

                    'データグリッドビューに表示　'《最終復活》
                    For i = 0 To _dtAllSogoTestHistory.Rows.Count - 1
                        grdJhoken_Show(_dtAllSogoTestHistory(i)("TestName"), _
                                       _dtAllSogoTestHistory(i)("TestDate"), _
                                       _dtAllSogoTestHistory(i)("TestTime"), _
                                       IsNullChk(_dtAllSogoTestHistory(i)("AccuracyRate1"), "0.0"), _
                                       IsNullChk(_dtAllSogoTestHistory(i)("AccuracyRate2"), "0.0"), _
                                       IsNullChk(_dtAllSogoTestHistory(i)("AccuracyRate3"), "0.0"), _
                                       IsNullChk(_dtAllSogoTestHistory(i)("TotalAccuracyRate"), "0.0"), _
                                       _dtAllSogoTestHistory(i)("TestNo"), _
                                       _dtAllSogoTestHistory(i)("TestCount"))
                    Next

                End If
            End If

            ''仮データ '【最終削除】
            'For i As Integer = 0 To 20

            '    grdJhoken_Show("総合テスト" & i, "2011.02.02", "150分", "52.7%" _
            '                   , "46.1%", "78.9%", "61%", "", "")
            'Next

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
                dataBanker("TOFORM") = DISPLAY_ID_JG42

                Dim dtrSynTestHistory() As DataRow
                Dim strFilter As String = ""
                Dim frm As New frmSynthesisTestMarkHistory

                '選択行のデータを取得しプロパティにセット
                strFilter = "TestName = '" & grdJhoken(INT_GRD_TESTNAME, e.RowIndex).Value & "'"
                strFilter &= " AND TestNo = '" & grdJhoken(INT_GRD_TESTNO, e.RowIndex).Value & "'"
                strFilter &= " AND TestCount = '" & grdJhoken(INT_GRD_JISSIKAI, e.RowIndex).Value & "'"
                dtrSynTestHistory = _dtAllSogoTestHistory.Select(strFilter.Trim, "")
                frm.SynthesisResultDataRow = dtrSynTestHistory(0)

                '問別正誤データを取得しプロパティにセット
                'frm.LargeCategoryAccuracyRateTbl = DataManager.GetInstance.GetTrueFalseDataTable(dtrSynTestHistory(0)("TestCount"), Constant.TestType.SynthesisResult)
                frm.LargeCategoryAccuracyRateTbl = DataManager.GetInstance.SynthesisResultDefine.GetSeparateCategoryAccuracyRate _
                                                        (DataManager.GetInstance.CategoryDefine.CategoryDataTable, _
                                                         DataManager.GetInstance.PracticeQuestionDefine.PracticeQuestionListDataTable, _
                                                         DataManager.GetInstance.SynthesisResultDefine.SynthesisResultDetailDataTable,
                                                         grdJhoken(INT_GRD_JISSIKAI, e.RowIndex).Value,
                                                         grdJhoken(INT_GRD_TESTNO, e.RowIndex).Value)

                '総合テスト祭典画面表示
                'Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                'dataBanker("TOFORM") = DISPLAY_ID_JG42
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

            If IsNothing(_dtAllSogoTestHistory) = True Then
                '2012/06/25 NOZAO CHG S
                'Call MsgBox("総合テスト実施履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("I010", {DATA_TEXT})
                '2012/06/25 NOZAO CHG E

            Else

                'データグリッドビュー表示データ絞込み処理 '《最終復活》
                Dim dtTestRow() As DataRow = grdDataSerch()

                If IsNothing(dtTestRow) = True Then
                    '2012/06/25 NOZAO CHG S
                    'Call MsgBox("指定の抽出条件では総合テスト実施履歴が存在しません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I011", {DATA_TEXT})
                    '2012/06/25 NOZAO CHG E

                Else
                    If dtTestRow.Count <= 0 Then
                        '2012/06/25 NOZAO CHG S
                        'Call MsgBox("指定の抽出条件では総合テスト実施履歴が存在しません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                        Common.Message.MessageShow("I011", {DATA_TEXT})
                        '2012/06/25 NOZAO CHG E
                    Else
                        'データグリッドビューに表示 '《最終復活》
                        grdJhoken.Rows.Clear()
                        For i = 0 To dtTestRow.Count - 1

                            grdJhoken_Show(dtTestRow(i)("TestName"), _
                                           dtTestRow(i)("TestDate"), _
                                           dtTestRow(i)("TestTime"), _
                                           IsNullChk(dtTestRow(i)("AccuracyRate1"), "0.0"), _
                                           IsNullChk(dtTestRow(i)("AccuracyRate2"), "0.0"), _
                                           IsNullChk(dtTestRow(i)("AccuracyRate3"), "0.0"), _
                                           IsNullChk(dtTestRow(i)("TotalAccuracyRate"), "0.0"), _
                                           dtTestRow(i)("TestNo"), _
                                           dtTestRow(i)("TestCount"))


                            ''正解率判定をここでする
                            'If txtSeiOver.Text = "" And txtSeiUnder.Text = "" Then '正解率両方に入力なし
                            '    grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("TestDate"), _
                            '    dtTestRow(i)("TestTime"), dtTestRow(i)("AccuracyRate1"), _
                            '    dtTestRow(i)("AccuracyRate2"), dtTestRow(i)("AccuracyRate3"), _
                            '    dtTestRow(i)("TotalAccuracyRate"), dtTestRow(i)("TestNo"), _
                            '    dtTestRow(i)("TestCount"))
                            'ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text = "" Then '正解率以上に入力あり
                            '    If Decimal.Parse(dtTestRow(i)("TotalAccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) Then
                            '        grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("TestDate"), _
                            '        dtTestRow(i)("TestTime"), dtTestRow(i)("AccuracyRate1"), _
                            '        dtTestRow(i)("AccuracyRate2"), dtTestRow(i)("AccuracyRate3"), _
                            '        dtTestRow(i)("TotalAccuracyRate"), dtTestRow(i)("TestNo"), _
                            '        dtTestRow(i)("TestCount"))
                            '    End If
                            'ElseIf txtSeiOver.Text = "" And txtSeiUnder.Text <> "" Then '正解率以下に入力あり
                            '    If Decimal.Parse(dtTestRow(i)("TotalAccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                            '        grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("TestDate"), _
                            '        dtTestRow(i)("TestTime"), dtTestRow(i)("AccuracyRate1"), _
                            '        dtTestRow(i)("AccuracyRate2"), dtTestRow(i)("AccuracyRate3"), _
                            '        dtTestRow(i)("TotalAccuracyRate"), dtTestRow(i)("TestNo"), _
                            '        dtTestRow(i)("TestCount"))
                            '    End If
                            'ElseIf txtSeiOver.Text <> "" And txtSeiUnder.Text <> "" Then '正解率両方に入力あり
                            '    If Decimal.Parse(dtTestRow(i)("TotalAccuracyRate")) >= Decimal.Parse(txtSeiOver.Text) And _
                            '       Decimal.Parse(dtTestRow(i)("TotalAccuracyRate")) <= Decimal.Parse(txtSeiUnder.Text) Then
                            '        grdJhoken_Show(dtTestRow(i)("TestName"), dtTestRow(i)("TestDate"), _
                            '        dtTestRow(i)("TestTime"), dtTestRow(i)("AccuracyRate1"), _
                            '        dtTestRow(i)("AccuracyRate2"), dtTestRow(i)("AccuracyRate3"), _
                            '        dtTestRow(i)("TotalAccuracyRate"), dtTestRow(i)("TestNo"), _
                            '        dtTestRow(i)("TestCount"))
                            '    End If
                            'End If


                        Next
                    End If
                End If
            End If

            '仮データ
            'grdJhoken_Show("総合テスト", "2011.02.02", "150分", "52.7%", _
            '               "46.1%", "78.9%", "61%", "", "")

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
    ''' ストラテジ系ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblBunya1_Click(sender As System.Object, e As System.EventArgs) Handles lblBunya1.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_BUNYA1)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' マネジメント系ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblBunya2_Click(sender As System.Object, e As System.EventArgs) Handles lblBunya2.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_BUNYA2)

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'イベントログ終了
            logger.End()
        End Try

    End Sub

    ''' <summary>
    ''' テクノロジ系ラベルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" e"></param>
    ''' <remarks></remarks>
    Private Sub lblBunya3_Click(sender As System.Object, e As System.EventArgs) Handles lblBunya3.Click

        Try
            logger.Start()

            'データグリッドをソート
            GrdSort(INT_GRD_BUNYA3)

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
            Case INT_GRD_BUNYA1, INT_GRD_BUNYA2, INT_GRD_BUNYA3, INT_GRD_SEIRIT
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
