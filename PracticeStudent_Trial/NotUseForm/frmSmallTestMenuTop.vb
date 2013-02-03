''' <summary>
''' 小テストメニュー画面(JG24)
''' </summary>
''' <remarks></remarks>
Public Class frmSmallTestMenuTop

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "小テストメニュー"
    ''' <summary>画面表示ID(JG24)</summary>
    Private Const DISPLAY_ID_JG24 As String = "JG24"
    ''' <summary>画面表示ID(JG15)</summary>
    Private Const DISPLAY_ID_JG15 As String = "JG15"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "小テストメニュー画面"

    'コンボボックス「すべて」項目
    Private CombItem_Subete As String = "すべて"
    'ラジオボタンで指定した「問題数」
    Private QuetionValue As Integer = 0
#End Region

#Region "----- メンバ変数 ----- "
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- メソッド ----- "

    ''' <summary>
    ''' コンボボックスに取得したリストを追加します。
    ''' </summary>
    ''' <param name="Combo_Box">コンボボックス</param>
    ''' <param name="Combo_items">コンボボックスに追加するリスト</param>
    ''' <remarks></remarks>
    Private Sub _AddItemComboBox(ByVal Combo_Box As ComboBox, ByVal Combo_items As List(Of String))
        Try
            'データ取得前にクリア
            Combo_Box.Items.Clear()

            '取得したデータをコンボボックスに追加
            Combo_Box.Items.Add(CombItem_Subete)

            For Each bunrui As String In Combo_items
                Combo_Box.Items.Add(bunrui)
            Next

        Catch ex As Exception
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
    Private Sub frmSmallTestMenuTop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()

            'ユーザーID設定
            Me.UserId = DataManager.GetInstance.UserId
            'ユーザー名設定
            Me.UserName = DataManager.GetInstance.UserName
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID_JG24
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            '親フォーム非表示
            Owner.Hide()
            Show()
            Refresh()

            ''ランダムテストコンボボックスの初期処理
            'コンボイベント(分野)を追加
            AddHandler Me.ComboBoxBunya.SelectedIndexChanged, AddressOf Me.ComboBoxBunya_SelectedIndexChanged
            'コンボイベント(大分類)を追加
            AddHandler Me.ComboBoxBunrui1.SelectedIndexChanged, AddressOf Me.ComboBoxBunrui1_SelectedIndexChanged
            'コンボイベント(中分類)を追加
            AddHandler Me.ComboBoxBunrui2.SelectedIndexChanged, AddressOf Me.ComboBoxBunrui2_SelectedIndexChanged

            'コンボボックス「分野」にアイテムを追加する
            ComboBoxBunya.Items.Add(CombItem_Subete)
            ComboBoxBunya.SelectedIndex = 0         'デフォルトを「すべて」に設定

            'コンボボックス「大分類」にアイテムを追加する
            'ComboBoxBunrui1.Items.Add(CombItem_Subete)
            'ComboBoxBunrui1.SelectedIndex = 0       'デフォルトを「すべて」に設定

            'コンボボックス「中分類」にアイテムを追加する
            'ComboBoxBunrui2.Items.Add(CombItem_Subete)
            'ComboBoxBunrui2.SelectedIndex = 0       'デフォルトを「すべて」に設定

            ' ''指定テストコンボボックスの初期処理
            ''コンボボックスにアイテムを追加する。
            'For Each CombItem As String In DataManager.GetInstance.SpecificDefine.GetSpecificTestNameList()
            '    ComboBoxSiteiTest.Items.Add(CombItem)
            'Next
            '指定テストラジオボックスの制御
            If DataManager.GetInstance.SpecificDefine.IsReadSpecificHeader _
                    AndAlso DataManager.GetInstance.SpecificDefine.IsReadSpecificDetail Then
                Me.rdoSiteiTest.Enabled = True
                ''指定テストコンボボックスの初期処理
                'コンボボックスにアイテムを追加する。
                '2012/06/12 NOZAO ADD S
                ComboBoxSiteiTest.Items.Clear()
                '2012/06/12 NOZAO ADD E
                For Each CombItem As String In DataManager.GetInstance.SpecificDefine.GetSpecificTestNameList(SpecificDefine.SortOrder.TESTNAME_AND_RESULT)
                    ComboBoxSiteiTest.Items.Add(CombItem)
                Next
            End If

            'フォーカス設定
            Me.btnSmallTestStart.Focus()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 「指定テスト」ラジオボタン選択イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdoSiteiTest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSiteiTest.CheckedChanged
        Try
            _Log.Start()

            If rdoSiteiTest.Checked Then
                rdoRandomTest.Checked = False       'ランダムテストのチェックをはずす
                ComboBoxSiteiTest.Enabled = True    '指定テストのコンボボックスを使用可
            Else
                rdoRandomTest.Checked = True        'ランダムテストのチェックを付与
                ComboBoxSiteiTest.Enabled = False   '指定テストのコンボボックスを使用不可
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
    ''' 「ランダムテスト」ラジオボタン選択イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdoRandamTest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoRandomTest.CheckedChanged
        Try
            _Log.Start()

            If rdoRandomTest.Checked Then
                rdoSiteiTest.Checked = False        '指定テストのチェックをはずす
                ComboBoxBunya.Enabled = True        'ランダムテスト「分野」のコンボボックスを使用可
                ComboBoxBunrui1.Enabled = True      'ランダムテスト「大分類」のコンボボックスを使用可
                ComboBoxBunrui2.Enabled = True      'ランダムテスト「中分類」のコンボボックスを使用可
                rdoMondai10.Enabled = True          '問題数「10」のラジオボタンを使用可
                rdoMondai20.Enabled = True          '問題数「20」のラジオボタンを使用可
                rdoMondai30.Enabled = True          '問題数「30」のラジオボタンを使用可
                rdoMondai40.Enabled = True          '問題数「40」のラジオボタンを使用可
            Else
                rdoSiteiTest.Checked = True         '指定テストのチェックを付与
                ComboBoxBunya.Enabled = False       'ランダムテスト「分野」のコンボボックスを使用不可
                ComboBoxBunrui1.Enabled = False     'ランダムテスト「大分類」のコンボボックスを使用不可
                ComboBoxBunrui2.Enabled = False     'ランダムテスト「中分類」のコンボボックスを使用不可
                rdoMondai10.Enabled = False         '問題数「10」のラジオボタンを使用不可
                rdoMondai20.Enabled = False         '問題数「20」のラジオボタンを使用不可
                rdoMondai30.Enabled = False         '問題数「30」のラジオボタンを使用不可
                rdoMondai40.Enabled = False         '問題数「40」のラジオボタンを使用不可
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
    ''' 「分野」コンボボックス選択時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxBunya_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            _Log.Start()

            '「分野」の選択内容から「大分類」を指定
            Dim Bunya As List(Of String) = Nothing          '「分野」
            Dim Bunrui1 As List(Of String) = Nothing        '「大分類」

            If ComboBoxBunya.SelectedItem = "すべて" Then        '"すべて"を選択した場合
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName()
                Bunrui1 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName
            Else
                Bunrui1 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(ComboBoxBunya.SelectedItem)
            End If

            If Bunrui1.Count = 0 Then
                'メッセージ表示
                '2012/06/26 NOZAO CHG S
                'MsgBox("該当する分類がありません。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("E077")
                '2012/06/26 NOZAO CHG E
            Else

                '「分野」が「すべて」の場合、すべての項目を取得する
                If ComboBoxBunya.SelectedItem = "すべて" Then

                    'コンボボックス「分野」に、取得したリストを追加
                    _AddItemComboBox(ComboBoxBunya, Bunya)

                    'コンボイベント(分野)の削除
                    RemoveHandler ComboBoxBunya.SelectedIndexChanged, AddressOf ComboBoxBunya_SelectedIndexChanged
                    ComboBoxBunya.SelectedIndex = 0
                    'コンボイベント(分野)の追加
                    AddHandler ComboBoxBunya.SelectedIndexChanged, AddressOf ComboBoxBunya_SelectedIndexChanged

                End If

                'コンボボックス「大分類」に、取得したリストを追加
                _AddItemComboBox(ComboBoxBunrui1, Bunrui1)

                ComboBoxBunrui1.SelectedIndex = 0

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
    ''' 「大分類」コンボボックス選択時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxBunrui1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            _Log.Start()

            '「大分類」の選択内容から「分野」、「中分類」を指定
            Dim Bunya As List(Of String) = Nothing          '「分野」
            Dim Bunrui1 As List(Of String) = Nothing        '「大分類」
            Dim Bunrui2 As List(Of String) = Nothing        '「中分類」

            If ComboBoxBunya.SelectedItem = "すべて" And ComboBoxBunrui1.SelectedItem = "すべて" Then         '「分野」="すべて"、「大分類」="すべて"を選択した場合
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName()
                Bunrui2 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName()

            ElseIf ComboBoxBunya.SelectedItem <> "すべて" And ComboBoxBunrui1.SelectedItem = "すべて" Then    '「分野」="すべて"以外、「大分類」="すべて"を選択した場合
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName()
                Bunrui1 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(ComboBoxBunya.SelectedItem)
                Bunrui2 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName(ComboBoxBunya.SelectedItem)

            ElseIf ComboBoxBunya.SelectedItem = "すべて" And ComboBoxBunrui1.SelectedItem <> "すべて" Then    '「分野」="すべて"、「大分類」="すべて"以外を選択した場合
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName(ComboBoxBunrui1.SelectedItem)
                Bunrui2 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName(Bunya.Item(0), ComboBoxBunrui1.SelectedItem)

            Else                                                                                              '「分野」="すべて"以外、「大分類」="すべて"以外を選択した場合
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName(ComboBoxBunrui1.SelectedItem)
                Bunrui2 = DataManager.GetInstance.CategoryDefine.GetMiddleClassCategoryName(Bunya.Item(0), ComboBoxBunrui1.SelectedItem)
            End If

            If Bunya.Count = 0 Or Bunrui2.Count = 0 Then
                'メッセージ表示
                '2012/06/26 NOZAO CHG S
                'MsgBox("該当する分類がありません。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("E077")
                '2012/06/26 NOZAO CHG E
            Else
                '「大分類」に紐づいている「分野」の項目を選択する
                If ComboBoxBunrui1.SelectedItem <> "すべて" Then

                    For i As Integer = 0 To ComboBoxBunya.Items.Count - 1
                        If ComboBoxBunya.Items(i) = Bunya.Item(0) Then
                            'コンボイベント(分野)の削除
                            RemoveHandler ComboBoxBunya.SelectedIndexChanged, AddressOf ComboBoxBunya_SelectedIndexChanged
                            ComboBoxBunya.SelectedIndex = i
                            'コンボイベント(分野)の追加
                            AddHandler ComboBoxBunya.SelectedIndexChanged, AddressOf ComboBoxBunya_SelectedIndexChanged
                        End If
                    Next

                End If

                '「大分類」が「すべて」の場合に紐づく項目を取得する
                If ComboBoxBunya.SelectedItem <> "すべて" And ComboBoxBunrui1.SelectedItem = "すべて" Then
                    'Bunrui1 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(ComboBoxBunya.SelectedItem)

                    'コンボボックス「大分類」に、取得したリストを追加
                    _AddItemComboBox(ComboBoxBunrui1, Bunrui1)

                    'コンボイベント(分野)の削除
                    RemoveHandler ComboBoxBunrui1.SelectedIndexChanged, AddressOf ComboBoxBunrui1_SelectedIndexChanged
                    ComboBoxBunrui1.SelectedIndex = 0
                    'コンボイベント(分野)の追加
                    AddHandler ComboBoxBunrui1.SelectedIndexChanged, AddressOf ComboBoxBunrui1_SelectedIndexChanged

                End If

                'コンボボックス「中分類」に、取得したリストを追加
                _AddItemComboBox(ComboBoxBunrui2, Bunrui2)

                ComboBoxBunrui2.SelectedIndex = 0

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
    ''' 「中分類」コンボボックス選択時イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBoxBunrui2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            _Log.Start()

            '「中分類」の選択内容から「分野」、「大分類」を指定
            Dim Bunya As List(Of String) = Nothing          '「分野」
            Dim Bunrui1 As List(Of String) = Nothing        '「大分類」

            If ComboBoxBunrui2.SelectedItem = "すべて" Then       '"すべて"を選択した場合
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName()
                Bunrui1 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName()
            Else
                Bunrui1 = DataManager.GetInstance.CategoryDefine.GetLargeClassCategoryName(ComboBoxBunrui2.SelectedItem, True)
                Bunya = DataManager.GetInstance.CategoryDefine.GetClassCategoryName(CStr(Bunrui1.Item(0)))
            End If

            If Bunya.Count = 0 Or Bunrui1.Count = 0 Then
                'メッセージ表示
                '2012/06/26 NOZAO CHG S
                'MsgBox("該当する分類がありません。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                Common.Message.MessageShow("E077")
                '2012/06/26 NOZAO CHG E
            Else
                '「中分類」に紐づいる「大分類」項目を選択する
                'If ComboBoxBunrui1.SelectedItem = "すべて" And ComboBoxBunrui2.SelectedItem <> "すべて" Then
                If ComboBoxBunrui2.SelectedItem <> "すべて" Then

                    For i As Integer = 0 To ComboBoxBunrui1.Items.Count - 1
                        If ComboBoxBunrui1.Items(i) = Bunrui1.Item(0) Then
                            'コンボイベント(大分類)を削除
                            RemoveHandler Me.ComboBoxBunrui1.SelectedIndexChanged, AddressOf Me.ComboBoxBunrui1_SelectedIndexChanged
                            ComboBoxBunrui1.SelectedIndex = i
                            'コンボイベント(大分類)を追加
                            AddHandler Me.ComboBoxBunrui1.SelectedIndexChanged, AddressOf Me.ComboBoxBunrui1_SelectedIndexChanged
                        End If
                    Next

                End If

            '「中分類」に紐づいる「分野」項目を選択する
                If ComboBoxBunrui2.SelectedItem <> "すべて" Then

                    For i As Integer = 0 To ComboBoxBunya.Items.Count - 1
                        If ComboBoxBunya.Items(i) = Bunya.Item(0) Then
                            'コンボイベント(分野)の削除
                            RemoveHandler ComboBoxBunya.SelectedIndexChanged, AddressOf ComboBoxBunya_SelectedIndexChanged
                            ComboBoxBunya.SelectedIndex = i
                            'コンボイベント(分野)の追加
                            AddHandler ComboBoxBunya.SelectedIndexChanged, AddressOf ComboBoxBunya_SelectedIndexChanged
                        End If
                    Next

                End If

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
    ''' 問題数「10」ラジオボタンチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdoMondai10_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMondai10.CheckedChanged
        Try
            _Log.Start()

            If rdoMondai10.Checked Then
                QuetionValue = 10
            Else
            End If
            'MsgBox(QuetionValue)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 問題数「20」ラジオボタンチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdoMondai20_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMondai20.CheckedChanged
        Try
            _Log.Start()

            If rdoMondai20.Checked Then
                QuetionValue = 20
            Else
            End If
            'MsgBox(QuetionValue)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 問題数「30」ラジオボタンチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdoMondai30_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMondai30.CheckedChanged
        Try
            _Log.Start()

            If rdoMondai30.Checked Then
                QuetionValue = 30
            Else
            End If
            'MsgBox(QuetionValue)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 問題数「40」ラジオボタンチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdoMondai40_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMondai40.CheckedChanged
        Try
            _Log.Start()

            If rdoMondai40.Checked Then
                QuetionValue = 40
            Else
            End If
            'MsgBox(QuetionValue)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 小テスト開始ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSmallTestStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmallTestStart.Click
        Try
            _Log.Start()

            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("TOFORM") = "JG25" ' 小テスト演習問題画面へ遷移

            '小テスト結果ヘッダの取得
            Dim _dt As DataTable = DataManager.GetInstance.MiniResultDefine.MiniResultHeaderDataTable
            '小テストTestNoの初期化
            DataManager.GetInstance.SpecificDefine.TestNo = ""

            'ランダムテスト選択の場合
            If rdoRandomTest.Checked = True Then

                If QuetionValue = 0 Then                     '問題数未選択の場合
                    '2012/06/26 NOZAO CHG S
                    'MsgBox("問題数を選択してください。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I012")
                    '2012/06/26 NOZAO CHG E
                Else
                    Dim Bunya_item As String = ComboBoxBunya.SelectedItem           '「分野」の項目を取得
                    Dim Bunrui1_item As String = ComboBoxBunrui1.SelectedItem       '「大分類」の項目を取得
                    Dim Bunrui2_item As String = ComboBoxBunrui2.SelectedItem       '「中分類」の項目を取得

                    '取得項目が「すべて」の場合、空文字を設定
                    If Bunya_item = "すべて" Then
                        Bunya_item = ""
                    End If
                    If Bunrui1_item = "すべて" Then
                        Bunrui1_item = ""
                    End If
                    If Bunrui2_item = "すべて" Then
                        Bunrui2_item = ""
                    End If

                    ' 種別・分類の保持
                    DataManager.GetInstance.MiniResultDefine.TestClass = MiniResultDefine.QuestionClass.Random
                    DataManager.GetInstance.MiniResultDefine.CategoryId = DataManager.GetInstance.CategoryDefine.CategoryId(Bunya_item)
                    DataManager.GetInstance.MiniResultDefine.LargeCategoryId = DataManager.GetInstance.CategoryDefine.LargeCategoryId(Bunrui1_item)
                    DataManager.GetInstance.MiniResultDefine.MiddleCategoryId = DataManager.GetInstance.CategoryDefine.MiddleCategoryId(Bunrui2_item)

                    'グループカテゴリーIDの取得
                    Dim _GroupIDList As List(Of String) = DataManager.GetInstance.CategoryDefine.GetGroupIdList(Bunya_item, Bunrui1_item, Bunrui2_item)

                    'ランダムテスト問題コードリスト取得
                    Dim _RandomQuestionList As Dictionary(Of Integer, QuestionCodeDefine) = DataManager.GetInstance.PracticeQuestionDefine.GetRandomQuestionList(_GroupIDList, QuetionValue.ToString, _dt)
                    ' 小テスト実施回数のセット
                    DataManager.GetInstance.SpecificDefine.TestCount = DataManager.GetInstance.PracticeQuestionDefine.MiniResultTestCount

                    If _RandomQuestionList.Count = 0 Then
                        '2012/06/26 NOZAO CHG S
                        'MsgBox("条件に合う問題数が「出題数」に足りていません。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                        Common.Message.MessageShow("I013")
                        '2012/06/26 NOZAO CHG E
                    ElseIf _RandomQuestionList.Count > 0 Then
                        '問題コードリストに「ランダムテスト問題のコードリスト」を設定
                        DataManager.GetInstance.QuestionCodeList = _RandomQuestionList

                        '小テスト演習問題画面へ遷移する。
                        Dim frm As New frmTest(0)
                        Me.Hide()
                        frm.ShowDialog(Me)
                        If DataManager.GetInstance.IsLogouting Then
                            Me.Close()
                        Else
                            Me.Show()
                        End If

                    End If

                End If

            End If

            '指定テスト選択の場合
            If rdoSiteiTest.Checked = True Then

                If ComboBoxSiteiTest.SelectedItem = "" Then
                    '2012/06/26 NOZAO CHG S
                    'MsgBox("テスト項目を選択してください。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                    Common.Message.MessageShow("I014")
                    '2012/06/26 NOZAO CHG E
                Else
                    ' 種別の保持
                    DataManager.GetInstance.MiniResultDefine.TestClass = MiniResultDefine.QuestionClass.Specific

                    '指定問題コード一覧の取得
                    Dim _SpecificQuestionCodeList As Dictionary(Of Integer, QuestionCodeDefine) = DataManager.GetInstance.SpecificDefine.GetSpecificQuestionCodeList(ComboBoxSiteiTest.SelectedItem, _dt)

                    If _SpecificQuestionCodeList.Count = 0 Then
                        '2012/06/26 NOZAO CHG S
                        'MsgBox("条件に合う問題がありません。", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "情報")
                        Common.Message.MessageShow("I015")
                        '2012/06/26 NOZAO CHG E
                    ElseIf _SpecificQuestionCodeList.Count > 0 Then
                        '問題コードリストに「指定問題コード一覧」を設定
                        DataManager.GetInstance.QuestionCodeList = _SpecificQuestionCodeList

                        '小テスト演習問題画面へ遷移する。
                        Dim frm As New frmTest(0)
                        Me.Hide()
                        frm.ShowDialog(Me)
                        If DataManager.GetInstance.IsLogouting Then
                            Me.Close()
                        Else
                            '2012/06/12 NOZAO ADD S
                            frmSmallTestMenuTop_Load(Nothing, Nothing)
                            '2012/06/12 NOZAO ADD E
                            Me.Show()
                        End If

                    End If

                End If

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
    Private Sub btnBackPracticeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackPracticeMenu.Click
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
End Class