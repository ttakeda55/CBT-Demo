''' <summary>
''' 逐次演習履歴確認画面(JG38)
''' </summary>
''' <remarks></remarks>
Public Class frmPracticeConfirmHistory

#Region "----- 定数 ----- "

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "逐次演習履歴確認"
    ''' <summary>画面表示ID(JG37)</summary>
    Private Const DISPLAY_ID_JG37 As String = "JG37"
    ''' <summary>画面表示ID(JG38)</summary>
    Private Const DISPLAY_ID_JG38 As String = "JG38"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "逐次演習履歴確認画面"
    ''' <summary>データグリッドビューの列番定数</summary>
    Private Const INT_GRD_BUNYA As Integer = 0
    Private Const INT_GRD_DAIBUN As Integer = 1
    Private Const INT_GRD_TYUBUN As Integer = 2
    Private Const INT_GRD_MONSUU As Integer = 3
    Private Const INT_GRD_SEISUU As Integer = 4
    Private Const INT_GRD_SEIRIT As Integer = 5

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>上の行の中分類データ(grdJhoken_Show[データグリッドビューの行追加])で使用</summary>
    Dim _strCyubunU As String
    ''' <summary>グリッド垂直スクロールバー</summary>
    Private _vsBar As VScrollBar
    ''' <summary>データグリッドビューの表示データテーブル(小問履歴)</summary>
    Dim _dtHistoryS As DataTable = Nothing
    ''' <summary>データグリッドビューの表示データテーブル(中問履歴)</summary>
    Dim _dtHistoryM As DataTable = Nothing

    ''' <summary>Dammyデータ作成用</summary>
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

    ''' <summary>データグリッドビューの初期化</summary>
    Private Sub grdJhoken_init()

        Try

            'CELLを編集不可にする
            grdJhoken.Columns(INT_GRD_BUNYA).ReadOnly = True
            grdJhoken.Columns(INT_GRD_DAIBUN).ReadOnly = True
            grdJhoken.Columns(INT_GRD_TYUBUN).ReadOnly = True
            grdJhoken.Columns(INT_GRD_MONSUU).ReadOnly = True
            grdJhoken.Columns(INT_GRD_SEISUU).ReadOnly = True
            grdJhoken.Columns(INT_GRD_SEIRIT).ReadOnly = True


            'ユーザーがすべての行を削除できないようにする
            grdJhoken.AllowUserToDeleteRows = False

            'ユーザーが新しい行を追加できないようにする
            grdJhoken.AllowUserToAddRows = False

            '列の幅をユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeColumns = False

            '行の高さをユーザーが変更できないようにする
            grdJhoken.AllowUserToResizeRows = False

            'ヘッダのアレンジメントを変更
            For i As Integer = 0 To 5
                grdJhoken.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            Next

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
    Private Sub grdJhoken_Show(ByVal c1 As String, ByVal c2 As String, ByVal c3 As String, ByVal c4 As String, ByVal c5 As String, ByVal c6 As String)

        Try

            Dim item As New DataGridViewRow
            Dim blnRet As Boolean = True

            item.CreateCells(grdJhoken)

            '前回と今回の中分類データが違うならグリッドに追加
            If _strCyubunU <> c3 Then

                'セルの内容をセット
                With item

                    .Cells(INT_GRD_BUNYA).Value = c1
                    .Cells(INT_GRD_DAIBUN).Value = c2
                    .Cells(INT_GRD_TYUBUN).Value = c3
                    .Cells(INT_GRD_MONSUU).Value = c4 & "問"
                    .Cells(INT_GRD_SEISUU).Value = c5 & "問"
                    .Cells(INT_GRD_SEIRIT).Value = c6 & "%"

                End With

                '行を追加
                grdJhoken.Rows.Add(item)
            End If

            '現在の中分類データをセット
            _strCyubunU = c3

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

    ''' <summary>【最終削除】ダミー用テーブル作成</summary>
    ''' <param name="dt">カテゴリーデータテーブル</param>
    ''' <remarks></remarks>
    Private Sub CreateTable(ByRef dt As DataTable, ByVal blnSelect As Boolean)

        Try

            If blnSelect = True Then '小問用
                '分類名
                dt.Columns.Add("CategoryName", GetType(String))
                '大分類名
                dt.Columns.Add("LargeCategoryName", GetType(String))
                '中分類名
                dt.Columns.Add("MiddleCategoryName", GetType(String))
                '演習問題数
                dt.Columns.Add("QuestionCount", GetType(String))
                '正解数
                dt.Columns.Add("CorrectAnswerCount", GetType(String))
                '正解率
                dt.Columns.Add("AccuracyRate", GetType(String))
            Else '中問用
                '演習問題数
                dt.Columns.Add("QuestionCount", GetType(String))
                '正解数
                dt.Columns.Add("CorrectAnswerCount", GetType(String))
                '正解率
                dt.Columns.Add("AccuracyRate", GetType(String))
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>【最終削除】ダミーデータ呼び出し</summary>
    Private Sub dammyDataCaller(ByVal blnSelect As Boolean)

        Try
            If blnSelect = True Then
                grdJhoken_Show_dammy("ストラテジ系", "企業と法務", "企業活動", "10問", "6問", "80％", True)
                grdJhoken_Show_dammy("ストラテジ系", "企業と法務", "法務", "10問", "6問", "80％", True)
                grdJhoken_Show_dammy("ストラテジ系", "経営戦略", "経営戦略マネジメント", "18問", "15問", "60％", True)
                grdJhoken_Show_dammy("ストラテジ系", "経営戦略", "技術戦略マネジメント", "54問", "36問", "55％", True)
                grdJhoken_Show_dammy("ストラテジ系", "経営戦略", "ビジネスインダストリ", "4問", "3問", "0％", True)
                grdJhoken_Show_dammy("ストラテジ系", "システム戦略", "システム戦略", "10問", "8問", "25％", True)
                grdJhoken_Show_dammy("ストラテジ系", "システム戦略", "システム企画", "52問", "48問", "100％", True)

                grdJhoken_Show_dammy("マネジメント系", "開発技術", "ソフトウェア開発管理技術", "32問", "26問", "64％", True)
                grdJhoken_Show_dammy("マネジメント系", "プロジェクトマネジメント", "プロジェクトマネジメント", "10問", "6問", "36％", True)
                grdJhoken_Show_dammy("マネジメント系", "サービスマネジメント", "サービスマネジメント", "18問", "15問", "46％", True)
                grdJhoken_Show_dammy("マネジメント系", "サービスマネジメント", "システム監査", "54問", "36問", "75％", True)

                grdJhoken_Show_dammy("テクノロジ系", "基礎理論", "基礎理論", "4問", "3問", "50％", True)
                grdJhoken_Show_dammy("テクノロジ系", "基礎理論", "アルゴリズムとプログラミング", "10問", "8問", "85％", True)
                grdJhoken_Show_dammy("テクノロジ系", "コンピュータシステム", "コンピュータシステム", "52問", "48問", "75％", True)
                grdJhoken_Show_dammy("テクノロジ系", "コンピュータシステム", "システム構成要素", "32問", "26問", "88％", True)
                grdJhoken_Show_dammy("テクノロジ系", "コンピュータシステム", "ソフトウェア", "10問", "6問", "68％", True)
                grdJhoken_Show_dammy("テクノロジ系", "コンピュータシステム", "ハードウェア", "18問", "15問", "90％", True)
                grdJhoken_Show_dammy("テクノロジ系", "技術要素", "ヒューマンインタフェース", "54問", "36問", "90％", True)
                grdJhoken_Show_dammy("テクノロジ系", "技術要素", "マルチメディア", "4問", "3問", "84％", True)
                grdJhoken_Show_dammy("テクノロジ系", "技術要素", "データベース", "10問", "8問", "57％", True)
                grdJhoken_Show_dammy("テクノロジ系", "技術要素", "ネットワーク", "52問", "48問", "46％", True)
                grdJhoken_Show_dammy("テクノロジ系", "技術要素", "セキュリティ", "32問", "26問", "65％", True)
            Else
                grdJhoken_Show_dammy("32問（中問8問×4設問）", "25問", "78％", "", "", "", False)
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>【最終削除】ダミーデータテーブル作成</summary>
    ''' <param name="c1">分野</param>
    ''' <param name="c2">大分類</param>
    ''' <param name="c3">中分類</param>
    ''' <param name="c4">グループ</param>
    ''' <param name="c5">キーワード</param>
    ''' <remarks></remarks>
    Private Sub grdJhoken_Show_dammy(ByVal c1 As String, ByVal c2 As String, ByVal c3 As String, _
                                     ByVal c4 As String, ByVal c5 As String, ByVal c6 As String, _
                                     Optional ByVal blnSelect As Boolean = True)

        Try

            Dim newRowData As DataRow = Nothing

            If blnSelect = True Then

                newRowData = _dtHistoryS.NewRow
                newRowData.Item("CategoryName") = c1
                newRowData.Item("LargeCategoryName") = c2
                newRowData.Item("MiddleCategoryName") = c3
                newRowData.Item("QuestionCount") = c4
                newRowData.Item("CorrectAnswerCount") = c5
                newRowData.Item("AccuracyRate") = c6

                '行を追加
                _dtHistoryS.Rows.Add(newRowData)
            Else
                newRowData = _dtHistoryM.NewRow
                newRowData.Item("QuestionCount") = c1
                newRowData.Item("CorrectAnswerCount") = c2
                newRowData.Item("AccuracyRate") = c3

                '行を追加
                _dtHistoryM.Rows.Add(newRowData)
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

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

            Me.processMessage = True
            Me.Show()
            Me.Refresh()

            Dim blnRet As Boolean = False
            Dim intTyumonsu As Integer = 0

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
            Me.lblBottomCode.Text = DISPLAY_ID_JG38
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME

            'データグリッドビュー初期化処理
            grdJhoken_init()

            'データグリッドビューに表示するデータを取得(小問・演習履歴・分類)
            _dtHistoryS = New DataTable
            blnRet = DataManager.GetInstance.PracticeQuestionDefine.GetConfirmPracticeQuestionHistory(DataManager.GetInstance.CategoryDefine.CategoryDataTable)
            If blnRet = True Then
                _dtHistoryS = DataManager.GetInstance.PracticeQuestionDefine.SamllQuestionHistoryDataTable '《最終復活》
            Else
                Return
            End If


            ''ダミーデータ作成【最終削除】
            'CreateTable(_dtHistoryS, True) '【最終削除】
            'dammyDataCaller(True) '【最終削除】

            If IsNothing(_dtHistoryS) = True Then
                '2012/06/26 NOZAO CHG S
                'Call MsgBox("小問逐次演習履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("I010", {"小問逐次演習履歴"})
                '2012/06/26 NOZAO CHG S

            Else
                If _dtHistoryS.Rows.Count <= 0 Then
                    '2012/06/26 NOZAO CHG S
                    'Call MsgBox("小問逐次演習履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I010", {"小問逐次演習履歴"})
                    '2012/06/26 NOZAO CHG E
                Else
                    For Each Row As DataRow In _dtHistoryS.Rows
                        grdJhoken_Show(Row("CategoryName"), Row("LargeCategoryName"), Row("MiddleCategoryName"), _
                                       Row("QuestionCount"), Row("CorrectAnswerCount"), Row("AccuracyRate"))
                    Next
                End If

            End If


            '中問項目に表示するデータを取得
            _dtHistoryM = New DataTable
            _dtHistoryM = DataManager.GetInstance.PracticeQuestionDefine.MiddleQuestionHistoryDataTable '《最終復活》

            ''ダミーデータ作成【最終削除】
            'CreateTable(_dtHistoryM, False) '【最終削除】
            'dammyDataCaller(False) '【最終削除】

            If IsNothing(_dtHistoryM) = True Then
                '2012/06/26 NOZAO CHG S
                'Call MsgBox("中問逐次演習履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("I010", {"中問逐次演習履歴"})
                '2012/06/26 NOZAO CHG E

            Else
                If _dtHistoryM.Rows.Count <= 0 Then
                    '2012/06/26 NOZAO CHG S
                    'Call MsgBox("中問逐次演習履歴がありません", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I010", {"中問逐次演習履歴"})
                    '2012/06/26 NOZAO CHG E

                Else
                    '演習問題数
                    '中問数を算出
                    intTyumonsu = _dtHistoryM(0)("QuestionCount") / 4
                    lblPraMonSuu.Text = _dtHistoryM(0)("QuestionCount") & "問" & "　（中問" & intTyumonsu & "問×4設問）"
                    '正解数
                    lblSeiSuu.Text = _dtHistoryM(0)("CorrectAnswerCount") & "問"
                    '正解率
                    lblSeiRit.Text = _dtHistoryM(0)("AccuracyRate") & "%"
                End If

            End If

            '演習回数取得表示
            lblKaisu.Text = IsNullChk(DataManager.GetInstance.PracticeQuestionDefine.PracticeCount, 0) '《最終復活》
            'lblKaisu.Text = 10 '【最終削除】

            '演習時間取得表示
            lblTime.Text = IsNullChk(DataManager.GetInstance.PracticeQuestionDefine.PracticeTime, 0) '《最終復活》
            'lblTime.Text = 100 '【最終削除】

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
            ElseIf e.ColumnIndex = INT_GRD_MONSUU Then
                Return  '[演習問題数]列の時も何もしない
            ElseIf e.ColumnIndex = INT_GRD_SEISUU Then
                Return  '[正解数]列の時も何もしない
            ElseIf e.ColumnIndex = INT_GRD_SEIRIT Then
                Return  '[正解率]列の時も何もしない
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

#End Region



End Class