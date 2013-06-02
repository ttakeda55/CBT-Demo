Imports System.IO
Imports CST.CBT
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.BaseControl
''' <summary>
''' 総合テスト作成画面（KG26）
''' </summary>
''' <remarks>
''' 2012/04/16 KAWASHIMA 初期作成
''' 受講者のモジュールリリースに合わせて、正解率、演習回数を表示する処理を追加する。
''' </remarks>
Public Class frmSynthesisInput

#Region "----- 定数 -----"
    Private Const SORT_ODER_ASC = 0
    Private Const SORT_ODER_DESC = 1
    Private Const MINIQUESTION_NUM = 20     '小問の問題数
    Private Const MIDDLEQUESTION_NUM = 0    '中問の問題数
    Private Const MIDDLEQUESTION_1GROUP_NUM = 5    '中問1かたまりの問題数

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>
    ''' ログオブジェクト
    ''' </summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    'xmlファイルから取得したデータを格納するdatatable型のメンバ変数を定義する。
    Private m_dtPracticeData As DataTable = New DataTable
    Private m_dtPracticeData_Copy As DataTable = New DataTable
    Private m_dvDataview As DataView
    Private m_iSortStatus As Integer = SORT_ODER_ASC
    Private m_strGroupCode As String
    Private Property _Mode As Common.Constant.SpecificShowMode

    ''' <summary>画面データ</summary>
    Private _specificShowList As DataTable
    Private m_dtSerialResultResultDetail As DataTable = New DataTable

    ''' <summary>テスト名</summary>
    Private _TestName As String = String.Empty

    ''' <summary>選択カテゴリー</summary>
    Private _CategoryDisplayArray As Array

    ''' <summary>問題数</summary>
    Private _Amount As String = String.Empty

    ''' <summary>指定テスト№</summary>
    Private _TestNo As String = String.Empty

    Private _practiceQuestionBankCollection As Common.VetnurseQuestionBankCollection

    ''' <summary>
    ''' 表示モード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mode As Common.Constant.SpecificShowMode
        Get
            Return _Mode
        End Get
        Set(ByVal value As Common.Constant.SpecificShowMode)
            _Mode = value
        End Set
    End Property

    ''' <summary>
    ''' 問題リスト
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property specificShowList As DataTable
        Get
            Return _specificShowList
        End Get
        Set(ByVal value As DataTable)
            _specificShowList = value
        End Set
    End Property

    ''' <summary>
    ''' テストＮＯ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property testno As String
        Get
            Return _TestNo
        End Get
        Set(ByVal value As String)
            _TestNo = value
        End Set
    End Property

    ''' <summary>
    ''' テスト名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property testname As String
        Get
            Return _TestName
        End Get
        Set(ByVal value As String)
            _TestName = value
        End Set
    End Property

#End Region

#Region "イベントハンドラ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub frmSynthesisInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            Me.lblBottomCode.Text = "KG26"
            Me.lblBottomName.Text = "自動テスト作成画面"

            'グループコードを取得し、メンバ変数へ設定する。
            SetGroupCode()

            '問題一覧のフォーマットを整える
            SetDgvFormat()

            'データテーブルのフォーマットを整える
            SetPracticeDataFormat()

            If _Mode = Common.Constant.SpecificShowMode.ShowTestList Then
                btnSynthesisInput.Visible = False
                txtSynthesisName.Text = _TestName

                'グリッドデータ設定
                setGrid()
            End If

            Owner.Hide()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グリッドに演習問題一覧を設定する。
    ''' </summary>
    ''' <remarks>引き継いだデータを表示する</remarks>
    Private Sub setGrid()

        'メンバ変数のdatatableの保持している値をクリアし、Collection[問題群№].xmlから問題コードをdatatableにて取得
        m_dtPracticeData.Clear()

        'PracticeQuestionList.xmlから問題コードをキーに問題テーマ、問題種別、カテゴリーID、出題形式を取得しdatatableへ追加する。
        AddPracticeQuestionListData(m_dtPracticeData)

        'Category.xmlからカテゴリーIDをキーに分野、大分類、中分類、グループを取得し、datatableへ追加する。
        AddCategoryData(m_dtPracticeData)

        '制御フラグ等の初期化
        SetControlData(m_dtPracticeData)
        '難易度の追加
        setLevel(m_dtPracticeData)

        Dim Cnt As Integer = 0

        For Each row As DataRow In specificShowList.Select("1=1", "SHOWNONUM ASC")
            Dim QuestionCode = row.Item("QUESTIONCODE")
            Dim drMiniQuestion As DataRow = m_dtPracticeData.Select("QUESTIONCODE = '" & QuestionCode & "'")(0)
            If drMiniQuestion Is Nothing Then
                Continue For
            End If
            drMiniQuestion.Item(STATE.Name) = "STATUS_VIEW"
            Cnt += 1
            drMiniQuestion.Item(SHOWNO.Name) = Cnt
            drMiniQuestion.Item(INDEXNUMBER.Name) = Cnt.ToString
        Next

        m_dvDataview = m_dtPracticeData.DefaultView()
        m_dtPracticeData.AcceptChanges()
        m_dvDataview.RowFilter = STATE.Name & "='STATUS_VIEW'"
        m_dvDataview.Sort = SHOWNO.Name
        dgvPracticeList.DataSource = m_dvDataview

        dgvPracticeList.Focus()

    End Sub

    ''' <summary>
    ''' 総合テスト作成クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    Private Sub btnSynthesisInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSynthesisInput.Click
        Try
            logger.Start()

            '各xmlファイルを読み込む
            If GetFileData() = False Then
                Exit Sub
            End If

            m_dvDataview = m_dtPracticeData.DefaultView()
            m_dtPracticeData.AcceptChanges()
            m_dvDataview.RowFilter = STATE.Name & "='STATUS_VIEW'"
            m_dvDataview.Sort = SHOWNO.Name
            dgvPracticeList.DataSource = m_dvDataview

            dgvPracticeList.Focus()
            'dgvPracticeList.CurrentCell = dgvPracticeList(0, 0)
            btnSynthesisInput.Focus()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題一覧クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' チェック項目をクリックした場合は、クリックごとにチェックの状態をONとOFFで交互に変更する。
    ''' 問題コードをクリックした際に、問題確認画面（KG22/KG27）を表示する。
    ''' その他の場合は何もしない。
    ''' </remarks>
    Private Sub dgvPracticeList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeList.CellContentClick
        Try
            logger.Start()

            'DataGridVIewにデータがない場合は何もしない。
            If dgvPracticeList.Rows.Count = 0 Then
                Exit Sub
            End If

            If e.RowIndex = -1 Then
                '"問"をクリックした場合は、表示順でソートをかける。
                'DataGridViewのDataSourceが設定されているとSortCompareイベントなどが拾えないための対応
                Select Case e.ColumnIndex
                    Case INDEXNUMBER.Index
                        If m_iSortStatus = SORT_ODER_ASC Then
                            m_dvDataview.Sort = SHOWNO.Name & " DESC"
                            m_iSortStatus = SORT_ODER_DESC
                        Else
                            m_dvDataview.Sort = SHOWNO.Name & " ASC"
                            m_iSortStatus = SORT_ODER_ASC
                        End If
                    Case Else
                        m_iSortStatus = SORT_ODER_DESC
                End Select
            Else
                Select Case e.ColumnIndex
                    '問題コードをクリックした場合の処理
                    '　クリックした問題コードを取得し、問題確認画面（KG22/KG27）を表示する。
                    Case QUESTIONCODE.Index
                        Dim iIndex As Integer
                        Dim iCount As Integer = 0
                        Dim strQuestionCode As String
                        Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection

                        strQuestionCode = dgvPracticeList.CurrentRow.Cells(QUESTIONCODE_LINK.Name).Value

                        '問題画面に渡すリストの作成
                        For Each dgvr As DataGridViewRow In dgvPracticeList.Rows

                            Dim dr As DataRow = dgvr.DataBoundItem.Row
                            If String.Compare(dgvr.Cells(QUESTIONCODE.Name).Value, dgvr.Cells(MAINCODE.Name).Value) = 0 Then
                                '中問の設問はリストに入れない。
                            Else
                                Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
                                praciticeQuestionInfo.QuestionCode = dr(dgvPracticeList.Columns(QUESTIONCODE.Name).Index)
                                praciticeQuestionInfo.MiddleQuestionCode = dr(dgvPracticeList.Columns(MAINCODE.Name).Index)
                                praciticeQuestionInfo.IsMiddleQuestion = IIf(dr(dgvPracticeList.Columns(QUESTIONCLASS.Name).Index) = "2", True, False)
                                praciticeQuestionInfo.QuestionNo = dr(dgvPracticeList.Columns(INDEXNUMBER.Name).Index)
                                PraciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
                                If String.Compare(strQuestionCode, dr(dgvPracticeList.Columns(QUESTIONCODE.Name).Index)) = 0 Then
                                    iIndex = iCount
                                End If
                                iCount = iCount + 1
                            End If

                        Next

                        Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(iIndex, PraciticeQuestionInfoCollection, True)
                        frm.ShowDialog(Me)
                        Me.Show()

                End Select
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' チェックした問題を変更するクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' １．datatableのステータスフラグが”出力対象”に設定されている問題を表示順が若い順に変更対象チェックフラグの有無を評価する。
    ''' ２．チェックがついている問題が見つかった場合は、datatable内のステータスフラグが未設定の問題を検索し
    ''' 　　検索にて見つかった問題の変更対象チェックフラグ、ステータスフラグ、表示順の各値へ変更対象チェックフラグがついている問題の値を設定する。
    ''' ３．値設定後、変更対象チェックフラグがついている問題の変更対象フラグ、表示順の値をクリアし、ステータスフラグには”使用済み”を設定する。
    ''' ４．置き換えを行う問題数が足らない場合はステータスフラグが”使用済み”となっているフラグをクリアし、２の処理を再実行する。
    ''' ５．ステータスフラグが”出力対象”となっている問題を画面に出力する。
    ''' </remarks>
    Private Sub btnChangeQuestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeQuestion.Click
        Try
            logger.Start()

            '問題一覧が表示されていない場合は終了
            If dgvPracticeList.Rows.Count < 1 Then
                Exit Sub
            End If

            Dim drSelectItem As DataRow
            Dim iDataTableIndex As Integer
            Dim iCount As Integer
            Dim iCurrentCellRow As Integer
            Dim iCurrentCellCol As Integer
            Dim iScrollRow As Integer

            '現在の表示順とカーソルセルを保持する。
            For iCount = 0 To dgvPracticeList.Rows.Count - 1
                dgvPracticeList.Rows(iCount).Cells(TEMPSHOWNO.Index).Value = iCount
            Next
            iCurrentCellRow = dgvPracticeList.CurrentCell.RowIndex
            iCurrentCellCol = dgvPracticeList.CurrentCell.ColumnIndex
            iScrollRow = dgvPracticeList.FirstDisplayedScrollingRowIndex

            For iDataTableIndex = 0 To dgvPracticeList.RowCount - 1
                '小問の場合
                If String.Compare(dgvPracticeList.Rows(iDataTableIndex).Cells(CHECK.Name).Value, "1") = 0  Then
                    Dim drTarget As DataRow = dgvPracticeList.Rows(iDataTableIndex).DataBoundItem.row
                    drSelectItem = GetMiniQuestion(m_dtPracticeData, drTarget.Item(CATEGORYID.Name))
                    If Not drSelectItem Is Nothing Then
                        SetMiniQuestionCode(drSelectItem, drTarget)
                        dgvPracticeList.Rows(iDataTableIndex).Cells(CHECK.Name).Value = "0"
                    End If
                End If
            Next

            'ここでAcceptChangesを呼ばないとなぜかRowFillterがうまくかからない
            m_dtPracticeData.AcceptChanges()
            m_dvDataview.RowFilter = STATE.Name & "='STATUS_VIEW'" '状態がSTATUS_VIEWでフィルターをかける
            m_dvDataview.Sort = SHOWNO.Name & " ASC"

            dgvPracticeList.Focus()
            dgvPracticeList.CurrentCell = dgvPracticeList(iCurrentCellCol, iCurrentCellRow)
            btnChangeQuestion.Focus()
            dgvPracticeList.FirstDisplayedScrollingRowIndex = iScrollRow

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 登録ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' １．システムフォルダ配下のSynthesisHeader[団体コード].xmlの情報をdatatableにて取得し、テスト名の重複を確認する。
    ''' 　　テスト名が未入力、または重複がある場合はエラーダイアログを表示し、処理を中止する。
    ''' ２．datatableのテストNoを若い番号から順に確認し、使用されていないテストNoを特定する。
    ''' 　　使用されていない番号の一番若い番号を使用する。
    ''' ３．画面に出力されている問題の一覧を各情報ごとに以下のファイルに保存する。
    ''' 　　SynthesisHeader[団体コード].xml	
    ''' 　　　テストNo　：プログラムで付与
    ''' 　　　テスト名　：画面のテスト名より取得
    ''' 　　　有効　　　："0：有効"を固定で設定
    ''' 　　　作成日　　：システム日付を設定
    ''' 　　　更新日　　：システム日付を設定
    ''' 　　SynthesisDetail[団体コード][テスト№].xml
    ''' 　　　テストNo　：プログラムで付与
    ''' 　　　問題コード：画面に出力されている問題コードを設定
    ''' 　　　　　　　　　※中問の設問にあたる問題コードも設定する。
    ''' 　　　表示順　　：問題コードの若い順に番号を付与する。
    ''' 　　　　　　　　　※中問の設問にあたる問題コードに対しても表示順を付与する。
    ''' 　　　作成日　　：システム日付を設定
    ''' 　　　更新日　　：システム日付を設定
    ''' ４．ファイルへの保存完了後、登録完了のダイアログを表示する。
    ''' ５．ダイアログ終了後、画面のテスト名、問題一覧をクリアする。
    ''' </remarks>
    Private Sub btnRegistration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistration.Click
        Try
            logger.Start()

            '問題一覧が表示されていない場合は終了
            If dgvPracticeList.Rows.Count < 1 Then
                Exit Sub
            End If

            Dim dtSynthesisHeader As DataTable
            Dim dtSynthesisDetail As DataTable = New DataTable
            Dim dvCheck As DataView
            Dim drCheck As DataRow()
            Dim strTestName As String = txtSynthesisName.Text
            Dim iTestNo As Integer = 0
            Dim iCount As Integer

            If String.Compare(strTestName.Trim(), "") = 0 Then
                Message.MessageShow("E005", {"テスト名"})
                Exit Sub
            End If

            Dim strFileName As String() = Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_SYNTHESISHEADER_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)

            '総合テストのファイルがある場合の処理
            If strFileName.Length <> 0 Then

                dtSynthesisHeader = Serialize.XmlToDataTable(IO.Path.GetFileName(strFileName(0)))

                If _Mode = Common.Constant.SpecificShowMode.ShowTestList Then
                    dtSynthesisHeader.Rows.Remove(dtSynthesisHeader.Select("TESTNO = '" & _TestNo & "'")(0))
                    iTestNo = Val(_TestNo)
                Else
                    'テスト名の重複チェック
                    dvCheck = dtSynthesisHeader.DefaultView()
                    drCheck = dvCheck.Table.Select(dtSynthesisHeader.Columns(Common.SynthesisHeader.ColumnIndex.TestName).ColumnName & "='" & txtSynthesisName.Text & "'")
                    If drCheck.Length > 0 Then
                        Message.MessageShow("E049", {"テスト名""" & txtSynthesisName.Text & """"})
                        Exit Sub
                    End If

                    'テストNoの重複チェック
                    Do
                        iTestNo = iTestNo + 1
                        drCheck = dvCheck.Table.Select(dtSynthesisHeader.Columns(Common.SynthesisHeader.ColumnIndex.TestNo).ColumnName & "='" & iTestNo.ToString & "'")
                    Loop Until drCheck.Length = 0

                    '総合テストのファイルがない場合の処理
                End If
            Else
                iTestNo = 1

                dtSynthesisHeader = New DataTable
                Common.XmlSchema.GetSynthesisHeaderSchema(dtSynthesisHeader)
            End If

            Dim cDataManager As DataManager = DataManager.GetInstance()

            '総合テストヘッダファイルへのデータの追加
            dtSynthesisHeader.Rows.Add({iTestNo.ToString, txtSynthesisName.Text, cDataManager.GetDateTime.ToString, cDataManager.GetDateTime.ToString})
            dtSynthesisHeader.TableName = Common.Constant.CST_SYNTHESISHEADER_FILENAME
            Serialize.DataTableToxml(dtSynthesisHeader, Common.Constant.CST_SYNTHESISHEADER_FILENAME & m_strGroupCode & Common.Constant.CST_EXTENSION_XML)

            '総合テスト明細ファイルへのデータの追加
            dtSynthesisDetail = New DataTable
            Common.XmlSchema.GetSynthesisDetailSchema(dtSynthesisDetail)
            dtSynthesisDetail.TableName = Common.Constant.CST_SYNTHESISDETAIL_FILENAME
            m_dvDataview.RowFilter = STATE.Name & "='STATUS_VIEW'" '状態がSTATUS_VIEWでフィルターをかける
            m_dvDataview.Sort = SHOWNO.Name & " ASC"
            For iCount = 0 To dgvPracticeList.Rows.Count - 1
                dtSynthesisDetail.Rows.Add({iTestNo.ToString,
                                            dgvPracticeList.Rows(iCount).Cells(QUESTIONCODE.Name).Value,
                                            dgvPracticeList.Rows(iCount).Cells(SHOWNO.Name).Value.ToString,
                                            cDataManager.GetDateTime.ToString,
                                            cDataManager.GetDateTime.ToString})
                Dim drMiniQuestion As DataRow = m_dtPracticeData_Copy.Select("QUESTIONCODE = '" & dgvPracticeList.Rows(iCount).Cells(QUESTIONCODE.Name).Value & "'")(0)
                If drMiniQuestion Is Nothing Then
                    Continue For
                End If
                drMiniQuestion.Item(STATE.Name) = "1"
            Next
            Serialize.DataTableToxml(dtSynthesisDetail, Common.Constant.CST_SYNTHESISDETAIL_FILENAME & m_strGroupCode & "_" & iTestNo.ToString & Common.Constant.CST_EXTENSION_XML)

            Serialize.DataTableToxml(m_dtPracticeData_Copy, Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)

            Message.MessageShow("I001")

            'txtSynthesisName.Text = ""
            'm_dtPracticeData.Clear()

            Me.Close()

                logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' キャンセルボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 2012/04/16 KAWASHIMA 新規作成
    ''' 前の画面に戻る処理"btnBack_Click"と同じ動きのため、直接btnBack_Clickを呼び出して終了
    ''' </remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            logger.Start()

            btnBack_Click(sender, e)

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 総合テスト管理メニューへ戻るボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()

            If Common.Message.MessageShow("Q011") = DialogResult.OK Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問番号をシャッフルする。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BtnSrcS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSrcS.Click
        Dim iCurrentCellRow As Integer
        Dim iCurrentCellCol As Integer
        Dim iScrollRow As Integer

        iCurrentCellRow = dgvPracticeList.CurrentCell.RowIndex
        iCurrentCellCol = dgvPracticeList.CurrentCell.ColumnIndex
        iScrollRow = dgvPracticeList.FirstDisplayedScrollingRowIndex

        For Each row As DataRow In m_dtPracticeData.Select("STATE='STATUS_VIEW'")
            row.Item(COURSENO.Name) = CBTCommon.Utility.RollDice(1000)
        Next

        Dim Cnt As Integer = 0

        For Each row As DataRow In m_dtPracticeData.Select("STATE='STATUS_VIEW'", "[COURSENO] ASC")
            Cnt += 1
            row.Item(SHOWNO.Name) = Cnt
            row.Item(INDEXNUMBER.Name) = Cnt.ToString
        Next

        dgvPracticeList.Focus()
        dgvPracticeList.CurrentCell = dgvPracticeList(iCurrentCellCol, iCurrentCellRow)
        dgvPracticeList.FirstDisplayedScrollingRowIndex = iScrollRow

    End Sub

    ''' <summary>
    ''' 問番号をグループ順に振り直す。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnSrcQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSrcQ.Click
        Dim iCurrentCellRow As Integer
        Dim iCurrentCellCol As Integer
        Dim iScrollRow As Integer

        iCurrentCellRow = dgvPracticeList.CurrentCell.RowIndex
        iCurrentCellCol = dgvPracticeList.CurrentCell.ColumnIndex
        iScrollRow = dgvPracticeList.FirstDisplayedScrollingRowIndex

        Dim Cnt As Integer = 0

        For Each row As DataRow In m_dtPracticeData.Select("STATE='STATUS_VIEW'", "[CATEGORYID],[QUESTIONCODE] ASC")
            Cnt += 1
            row.Item(SHOWNO.Name) = Cnt
            row.Item(INDEXNUMBER.Name) = Cnt.ToString
        Next

        dgvPracticeList.Focus()
        dgvPracticeList.CurrentCell = dgvPracticeList(iCurrentCellCol, iCurrentCellRow)
        dgvPracticeList.FirstDisplayedScrollingRowIndex = iScrollRow

    End Sub
    ''' <summary>
    ''' セルの値が変更され、確定した場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPracticeList_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPracticeList.CellValueChanged
        Try
            logger.Start()

            '中問のチェックを変更した場合の処理
            '　関連する問題のチェック状態を同一状態にする
            If e.ColumnIndex = CHECK.Index And
               dgvPracticeList.Rows.Count > 0 Then

                Dim iCount As Integer
                Dim iScrollRow As Integer
                Dim iCheckValue As Integer = Integer.Parse(dgvPracticeList.Rows(e.RowIndex).Cells(CHECK.Name).Value)
                If String.Compare(dgvPracticeList.Rows(e.RowIndex).Cells(QUESTIONCLASS.Name).Value, "2") = 0 Then
                    iScrollRow = dgvPracticeList.FirstDisplayedScrollingRowIndex
                    For iCount = 0 To dgvPracticeList.Rows.Count - 1
                        If String.Compare(dgvPracticeList.Rows(iCount).Cells(MAINCODE.Name).Value, dgvPracticeList.Rows(e.RowIndex).Cells(MAINCODE.Name).Value) = 0 Then
                            dgvPracticeList.Rows(iCount).Cells(CHECK.Name).Value = iCheckValue.ToString
                        End If
                    Next
                    dgvPracticeList.FirstDisplayedScrollingRowIndex = iScrollRow
                End If
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題一覧の状態変更を確定させる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 問題一覧の値が変更された場合に値をコミットする。
    ''' セルの値が変更された場合に即座にdgvPracticeList_CellValueChangedを呼ぶための処理
    ''' </remarks>
    Private Sub dgvPracticeList_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvPracticeList.CurrentCellDirtyStateChanged
        Try
            logger.Start()

            If dgvPracticeList.CurrentCell.ColumnIndex = CHECK.Index And
                     dgvPracticeList.IsCurrentCellDirty Then
                dgvPracticeList.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub


    Private Sub dgvPracticeList_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPracticeList.CellFormatting
        Try

            If e.RowIndex >= 0 Then
                If Not e.Value Is DBNull.Value Then
                    Select Case e.ColumnIndex
                        Case QUESTIONCOUNT.Index
                            If String.Compare(e.Value, "-  ") <> 0 Then
                                e.Value = e.Value & "問"
                            End If
                        Case ANSWERS.Index
                            If String.Compare(e.Value, "-  ") <> 0 Then
                                e.Value = e.Value & "%"
                            End If
                    End Select
                End If
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            processMessageLogout = True
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
            End Select
            processMessageLogout = False
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "メソッド"

    ''' <summary>
    ''' 難易度カラムの追加
    ''' </summary>
    ''' <param name="dtPracticeQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setLevel(ByRef dtPracticeQuestionList As DataTable)
        If Not dtPracticeQuestionList.Columns.Contains("LEVEL_STR") Then
            dtPracticeQuestionList.Columns.Add("LEVEL_STR", GetType(String), "IIF(LEVEL = '1','低',IIF(LEVEL = '3','高','中'))")
        End If
    End Sub

    ''' <summary>
    ''' dgvPracticeListのフォーマットを整える
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDgvFormat()

        With dgvPracticeList
            .Columns(CHECK.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(INDEXNUMBER.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(QUESTIONCODE.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(CATEGORYNAME1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(CATEGORYNAME2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            .Columns(THEME.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(CATEGORYNAME.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(FORMAT.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(ANSWERS.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(QUESTIONCOUNT.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            'タイトル行の折り返し禁止
            .Columns(INDEXNUMBER.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(QUESTIONCODE.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(CATEGORYNAME1.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(CATEGORYNAME2.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(THEME.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(CATEGORYNAME.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(FORMAT.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(ANSWERS.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(QUESTIONCOUNT.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False

            'ヘッダのタイトルをセンタリングしたいが、ソート時に三角の記号が表示されるためきれいにセンタリングされない。
            'そのためスペースを入れ位置の調整を行う。
            .Columns(CHECK.Name).HeaderCell.Value = Space(1) & .Columns(CHECK.Name).HeaderCell.Value & Space(1)
            .Columns(INDEXNUMBER.Name).HeaderCell.Value = Space(1) & .Columns(INDEXNUMBER.Name).HeaderCell.Value & Space(1)
            .Columns(QUESTIONCODE.Name).HeaderCell.Value = Space(2) & .Columns(QUESTIONCODE.Name).HeaderCell.Value & Space(2)
            .Columns(CATEGORYNAME1.Name).HeaderCell.Value = Space(5) & .Columns(CATEGORYNAME1.Name).HeaderCell.Value & Space(5)
            .Columns(CATEGORYNAME2.Name).HeaderCell.Value = Space(11) & .Columns(CATEGORYNAME2.Name).HeaderCell.Value & Space(11)
            '.Columns(CATEGORYNAME3.Name).HeaderCell.Value = Space(11) & .Columns(CATEGORYNAME3.Name).HeaderCell.Value & Space(11)
            .Columns(THEME.Name).HeaderCell.Value = Space(11) & .Columns(THEME.Name).HeaderCell.Value & Space(11)
            .Columns(CATEGORYNAME.Name).HeaderCell.Value = Space(10) & .Columns(CATEGORYNAME.Name).HeaderCell.Value & Space(10)

            .AutoGenerateColumns = False
        End With

    End Sub

    ''' <summary>
    ''' メンバ変数dtsPracticeDataのフォーマットを整える。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPracticeDataFormat()

        m_dtPracticeData.Columns.Add(CHECK.Name, Type.GetType("System.String"))        '変更チェック
        m_dtPracticeData.Columns.Add(INDEXNUMBER.Name, Type.GetType("System.String")) '問
        m_dtPracticeData.Columns.Add(QUESTIONCODE.Name, Type.GetType("System.String")) '問題コード
        m_dtPracticeData.Columns.Add(CATEGORYNAME1.Name, Type.GetType("System.String")) '分類
        m_dtPracticeData.Columns.Add(CATEGORYNAME2.Name, Type.GetType("System.String")) '大分類
        'm_dtPracticeData.Columns.Add(CATEGORYNAME3.Name, Type.GetType("System.String")) '中分類
        m_dtPracticeData.Columns.Add(THEME.Name, Type.GetType("System.String"))        'テーマ
        m_dtPracticeData.Columns.Add(CATEGORYNAME.Name, Type.GetType("System.String")) 'グループ
        m_dtPracticeData.Columns.Add(FORMAT.Name, Type.GetType("System.String"))       '属性
        m_dtPracticeData.Columns.Add(ANSWERS.Name, Type.GetType("System.String"))       '正解率
        m_dtPracticeData.Columns.Add(QUESTIONCOUNT.Name, Type.GetType("System.String"))       '演習回数

        m_dtPracticeData.Columns.Add(COURSENO.Name, Type.GetType("System.String"))     'コースNo
        m_dtPracticeData.Columns.Add(CREATE_DATE.Name, Type.GetType("System.String"))  '作成日
        m_dtPracticeData.Columns.Add(UPDATE_DATE.Name, Type.GetType("System.String"))  '更新日
        m_dtPracticeData.Columns.Add(QUESTIONCLASS.Name, Type.GetType("System.String")) '問題レベル
        m_dtPracticeData.Columns.Add(MAINCODE.Name, Type.GetType("System.String"))     '中問コード
        m_dtPracticeData.Columns.Add(CATEGORYID.Name, Type.GetType("System.String"))   'カテゴリID
        m_dtPracticeData.Columns.Add(STATE.Name, Type.GetType("System.String"))        '状態
        m_dtPracticeData.Columns.Add(MIDDLEQUESTIONINDEX.Name, Type.GetType("System.String"))        '中問のINDEX
        m_dtPracticeData.Columns.Add(QUESTIONCODE_LINK.Name, Type.GetType("System.String")) '問題コードクリック時に使用する問題コード
        m_dtPracticeData.Columns.Add(SHOWNO.Name, Type.GetType("System.Int32")) '表示順
        m_dtPracticeData.Columns.Add(TEMPSHOWNO.Name, Type.GetType("System.Int32")) '内部操作で一時的に使用する表示順

    End Sub

    ''' <summary>
    ''' 各xmlファイルからデータを読み込む
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetFileData() As Boolean
        'メンバ変数のdatatableの保持している値をクリアし、Collection[問題群№].xmlから問題コードをdatatableにて取得
        m_dtPracticeData.Clear()

        'PracticeQuestionList.xmlから問題コードをキーに問題テーマ、問題種別、カテゴリーID、出題形式を取得しdatatableへ追加する。
        AddPracticeQuestionListData(m_dtPracticeData)

        'Category.xmlからカテゴリーIDをキーに分野、大分類、中分類、グループを取得し、datatableへ追加する。
        AddCategoryData(m_dtPracticeData)

        '制御フラグ等の初期化
        SetControlData(m_dtPracticeData)
        '難易度の追加
        setLevel(m_dtPracticeData)

        '問題数のチェック
        Dim drDatarow As DataRow()
        Dim iDataCount As Integer

        drDatarow = m_dtPracticeData.Select("QUESTIONCLASS='1' AND STATE='STATUS_NOT_USE'")
        iDataCount = drDatarow.Length
        Dim iCount1 As Integer

        Dim dtSynthesisQuestionCount As DataTable = GetSynthesisQuestionCountTable()
        Dim Cnt As Integer = 0

        For Each row As DataRow In dtSynthesisQuestionCount.Select
            For iCount1 = 1 To row.Item("SYNTHESISQUESTIONCOUNT")
                Dim strDisplayId = row.Item("DISPLAYID")
                Dim drMiniQuestion As DataRow = GetMiniQuestion(m_dtPracticeData, strDisplayId)
                If drMiniQuestion Is Nothing Then
                    Continue For
                End If

                drMiniQuestion.Item(STATE.Name) = "STATUS_VIEW"
                Cnt += 1
                drMiniQuestion.Item(SHOWNO.Name) = Cnt
                drMiniQuestion.Item(INDEXNUMBER.Name) = Cnt.ToString
            Next
        Next

        Return True
    End Function

    ''' <summary>
    ''' 問題入れ替え時の小問を設定する。
    ''' </summary>
    ''' <param name="drSelectItem"></param>
    ''' <param name="drPracticeData"></param>
    ''' <remarks></remarks>
    Private Sub SetMiniQuestionCode(ByRef drSelectItem As DataRow, ByRef drPracticeData As DataRow)
        drSelectItem.Item(CHECK.Name) = drPracticeData.Item(CHECK.Name)
        drSelectItem.Item(STATE.Name) = drPracticeData.Item(STATE.Name)
        drSelectItem.Item(INDEXNUMBER.Name) = drPracticeData.Item(INDEXNUMBER.Name)
        drSelectItem.Item(SHOWNO.Name) = drPracticeData.Item(SHOWNO.Name)
        drSelectItem.Item(TEMPSHOWNO.Name) = drPracticeData.Item(TEMPSHOWNO.Name)

        Dim dtQuestionCount As DataTable = GetQuestionCount(drSelectItem.Item(QUESTIONCODE.Name))
        drSelectItem.Item(ANSWERS.Name) = dtQuestionCount.Rows(0).Item(ANSWERS.Name)
        drSelectItem.Item(QUESTIONCOUNT.Name) = dtQuestionCount.Rows(0).Item(QUESTIONCOUNT.Name)

        drPracticeData.Item(CHECK.Name) = "0"
        drPracticeData.Item(STATE.Name) = "STATUS_USED"
        drPracticeData.Item(INDEXNUMBER.Name) = ""
        drPracticeData.Item(SHOWNO.Name) = 0
        drPracticeData.Item(TEMPSHOWNO.Name) = 0
        drPracticeData.AcceptChanges()
    End Sub

    ''' <summary>
    ''' 問題入れ替え時の中問の問題を設定する
    ''' </summary>
    ''' <param name="strNewMainCode"></param>
    ''' <param name="strOldMainCode"></param>
    ''' <remarks></remarks>
    Private Sub SetMiddleQuestionCode(ByVal strNewMainCode As String, ByRef strOldMainCode As String, ByRef strQuestionCode As String)

        Dim iSearchIndex1 As Integer
        Dim iSearchIndex2 As Integer

        For iSearchIndex1 = 0 To m_dtPracticeData.Rows.Count - 1
            '中問の置き換え先の設問１を探す
            If String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MAINCODE.Name), strNewMainCode) = 0 And
               String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MIDDLEQUESTIONINDEX.Name), "1") = 0 Then

                strQuestionCode = m_dtPracticeData.Rows(iSearchIndex1).Item(QUESTIONCODE.Name)

                '中問の置き換え元の設問１を探す
                iSearchIndex2 = 0
                Do Until String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MAINCODE.Name), strOldMainCode) = 0 And
                         String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MIDDLEQUESTIONINDEX.Name), "1") = 0
                    iSearchIndex2 = iSearchIndex2 + 1
                Loop

                SwitchTableValue(iSearchIndex1, iSearchIndex2)
            End If

            '中問の置き換え先の設問２を探す
            If String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MAINCODE.Name), strNewMainCode) = 0 And
               String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MIDDLEQUESTIONINDEX.Name), "2") = 0 Then

                '中問の置き換え元の設問２を探す
                iSearchIndex2 = 0
                Do Until String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MAINCODE.Name), strOldMainCode) = 0 And
                         String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MIDDLEQUESTIONINDEX.Name), "2") = 0
                    iSearchIndex2 = iSearchIndex2 + 1
                Loop

                SwitchTableValue(iSearchIndex1, iSearchIndex2)
            End If

            '中問の置き換え先の設問３を探す
            If String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MAINCODE.Name), strNewMainCode) = 0 And
               String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MIDDLEQUESTIONINDEX.Name), "3") = 0 Then

                '中問の置き換え元の設問３を探す
                iSearchIndex2 = 0
                Do Until String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MAINCODE.Name), strOldMainCode) = 0 And
                         String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MIDDLEQUESTIONINDEX.Name), "3") = 0
                    iSearchIndex2 = iSearchIndex2 + 1
                Loop

                SwitchTableValue(iSearchIndex1, iSearchIndex2)
            End If

            '中問の置き換え先の設問４を探す
            If String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MAINCODE.Name), strNewMainCode) = 0 And
               String.Compare(m_dtPracticeData.Rows(iSearchIndex1).Item(MIDDLEQUESTIONINDEX.Name), "4") = 0 Then

                '中問の置き換え元の設問４を探す
                iSearchIndex2 = 0
                Do Until String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MAINCODE.Name), strOldMainCode) = 0 And
                         String.Compare(m_dtPracticeData.Rows(iSearchIndex2).Item(MIDDLEQUESTIONINDEX.Name), "4") = 0
                    iSearchIndex2 = iSearchIndex2 + 1
                Loop

                SwitchTableValue(iSearchIndex1, iSearchIndex2)
            End If
        Next

    End Sub

    ''' <summary>
    ''' 問題入れ替え時の中問の設問を設定する。
    ''' </summary>
    ''' <param name="drSelectItem"></param>
    ''' <param name="drPracticeData"></param>
    ''' <param name="strQuestionCode"></param>
    ''' <remarks></remarks>
    Private Sub SetMiddleQuestionData(ByRef drSelectItem As DataRow, ByRef drPracticeData As DataRow, ByRef strQuestionCode As String)
        drSelectItem.Item(CHECK.Name) = drPracticeData.Item(CHECK.Name)
        drSelectItem.Item(STATE.Name) = drPracticeData.Item(STATE.Name)
        drSelectItem.Item(INDEXNUMBER.Name) = drPracticeData.Item(INDEXNUMBER.Name)
        drSelectItem.Item(SHOWNO.Name) = drPracticeData.Item(SHOWNO.Name)
        drSelectItem.Item(TEMPSHOWNO.Name) = drPracticeData.Item(TEMPSHOWNO.Name)
        drSelectItem.Item(FORMAT.Name) = "-"
        drSelectItem.Item(CATEGORYNAME1.Name) = "        -"
        drSelectItem.Item(CATEGORYNAME2.Name) = "               -"
        drSelectItem.Item(CATEGORYNAME3.Name) = "               -"
        drSelectItem.Item(CATEGORYNAME.Name) = "               -"
        drSelectItem.Item(QUESTIONCODE_LINK.Name) = strQuestionCode

        drPracticeData.Item(CHECK.Name) = "0"
        drPracticeData.Item(STATE.Name) = "STATUS_USED"
        drPracticeData.Item(INDEXNUMBER.Name) = ""
        drPracticeData.Item(SHOWNO.Name) = 0
        drPracticeData.Item(TEMPSHOWNO.Name) = 0
    End Sub

    ''' <summary>
    ''' メンバ変数"m_dtPracticeData"内の値を入れ替える
    ''' </summary>
    ''' <param name="iTargetIndex"></param>
    ''' <param name="iSourceIndex"></param>
    ''' <remarks></remarks>
    Private Sub SwitchTableValue(ByVal iTargetIndex As Integer, ByVal iSourceIndex As Integer)
        m_dtPracticeData.Rows(iTargetIndex).Item(CHECK.Name) = m_dtPracticeData.Rows(iSourceIndex).Item(CHECK.Name)
        m_dtPracticeData.Rows(iTargetIndex).Item(STATE.Name) = m_dtPracticeData.Rows(iSourceIndex).Item(STATE.Name)
        m_dtPracticeData.Rows(iTargetIndex).Item(INDEXNUMBER.Name) = m_dtPracticeData.Rows(iSourceIndex).Item(INDEXNUMBER.Name)
        m_dtPracticeData.Rows(iTargetIndex).Item(SHOWNO.Name) = m_dtPracticeData.Rows(iSourceIndex).Item(SHOWNO.Name)
        m_dtPracticeData.Rows(iTargetIndex).Item(TEMPSHOWNO.Name) = m_dtPracticeData.Rows(iSourceIndex).Item(TEMPSHOWNO.Name)

        Dim dtQuestionCount As DataTable = GetQuestionCount(m_dtPracticeData.Rows(iTargetIndex).Item(QUESTIONCODE.Name))
        m_dtPracticeData.Rows(iTargetIndex).Item(ANSWERS.Name) = dtQuestionCount.Rows(0).Item(ANSWERS.Name)
        m_dtPracticeData.Rows(iTargetIndex).Item(QUESTIONCOUNT.Name) = dtQuestionCount.Rows(0).Item(QUESTIONCOUNT.Name)

        m_dtPracticeData.Rows(iSourceIndex).Item(CHECK.Name) = "0"
        m_dtPracticeData.Rows(iSourceIndex).Item(STATE.Name) = "STATUS_USED"
        m_dtPracticeData.Rows(iSourceIndex).Item(INDEXNUMBER.Name) = ""
        m_dtPracticeData.Rows(iSourceIndex).Item(SHOWNO.Name) = 0
        m_dtPracticeData.Rows(iSourceIndex).Item(TEMPSHOWNO.Name) = 0
    End Sub

    ''' <summary>
    ''' Groupファイルからグループコードを取得する。
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private Sub SetGroupCode()

        'Dim strFileNameList As String()
        'Dim strFilename As String

        'strFileNameList = Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_GROUP_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)
        'strFilename = IO.Path.GetFileName(strFileNameList(0))
        'strFilename = strFilename.Remove(0, Common.Constant.CST_GROUP_FILENAME.Length)
        'strFilename = strFilename.Remove(strFilename.Length - Common.Constant.CST_EXTENSION_XML.Length, Common.Constant.CST_EXTENSION_XML.Length)
        m_strGroupCode = Common.Constant.CST_GROUPNAME

    End Sub

    ''' <summary>
    ''' 指定した問題コードの演習回数、正解率を取得する
    ''' </summary>
    ''' <param name="strQuestionCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetQuestionCount(ByRef strQuestionCode As String) As DataTable
        Dim dtReturn As DataTable = New DataTable
        Dim iQuestionCount As Integer = 0
        Dim iCorrectCount As Integer = 0

        For Each row As DataRow In m_dtSerialResultResultDetail.Rows
            If String.Compare(row.Item(Common.SerialResultDetail.ColumnIndex.QuestionCode), strQuestionCode) = 0 Then
                iQuestionCount = iQuestionCount + 1
                iCorrectCount = iCorrectCount + Integer.Parse(row.Item(Common.SerialResultDetail.ColumnIndex.ErrAta))
            End If
        Next

        dtReturn.Columns.Add(ANSWERS.Name, GetType(String))
        dtReturn.Columns.Add(QUESTIONCOUNT.Name, GetType(String))
        If iQuestionCount = 0 Or iCorrectCount = 0 Then
            dtReturn.Rows.Add("0.0", iQuestionCount.ToString)
        Else
            dtReturn.Rows.Add(Strings.Format(Fix(iCorrectCount / iQuestionCount * 1000) / 10, "0.0"), iQuestionCount.ToString)
        End If

        Return dtReturn
    End Function

    ''' <summary>
    ''' PracticeQuestionListの内容を付与する
    ''' </summary>
    ''' <param name="dtPracticeData"></param>
    ''' <remarks></remarks>
    Private Sub AddPracticeQuestionListData(ByRef dtPracticeData As DataTable)

        Dim dtDatatable As DataTable = New DataTable
        dtDatatable = Common.PracticeQuestionList.GetAll()
        m_dtPracticeData_Copy = dtDatatable.Copy
        dtPracticeData.Merge(dtDatatable)

    End Sub

    ''' <summary>
    ''' Categoryの内容を付与する
    ''' </summary>
    ''' <param name="dtPracticeData"></param>
    ''' <remarks></remarks>
    Private Sub AddCategoryData(ByRef dtPracticeData As DataTable)
        Dim cCategoryMaster As CategoryMaster = New CategoryMaster(2)
        Dim dtDatatable As DataTable = cCategoryMaster.GetCategoryTable()

        For iCount1 = 0 To dtPracticeData.Rows.Count - 1
            For iCount2 = 0 To dtDatatable.Rows.Count - 1
                If String.Compare(dtPracticeData.Rows(iCount1).Item(CATEGORYID.Name), dtDatatable.Rows(iCount2).Item(Common.CategoryMaster.CagoryTableColumnIndex.DISPLAYID)) = 0 Then
                    dtPracticeData.Rows(iCount1).Item(CATEGORYNAME1.Name) = dtDatatable.Rows(iCount2).Item(Common.CategoryMaster.CagoryTableColumnIndex.CATEGORYNAME1)
                    dtPracticeData.Rows(iCount1).Item(CATEGORYNAME2.Name) = dtDatatable.Rows(iCount2).Item(Common.CategoryMaster.CagoryTableColumnIndex.CATEGORYNAME2)
                    'dtPracticeData.Rows(iCount1).Item(CATEGORYNAME3.Name) = dtDatatable.Rows(iCount2).Item(Common.CategoryMaster.CagoryTableColumnIndex.CATEGORYNAME3)
                    dtPracticeData.Rows(iCount1).Item(CATEGORYNAME.Name) = dtDatatable.Rows(iCount2).Item(Common.CategoryMaster.CagoryTableColumnIndex.CATEGORYNAME)
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' 当画面で使用する制御データを設定する。
    ''' </summary>
    ''' <param name="dtPracticeData"></param>
    ''' <remarks></remarks>
    Private Sub SetControlData(ByRef dtPracticeData As DataTable)
        For iCount1 = 0 To dtPracticeData.Rows.Count - 1
            If dtPracticeData.Rows(iCount1).Item(STATE.Name) = "1" Then
                dtPracticeData.Rows(iCount1).Item(STATE.Name) = "STATUS_USED"
            Else
                dtPracticeData.Rows(iCount1).Item(STATE.Name) = "STATUS_NOT_USE"
            End If
            dtPracticeData.Rows(iCount1).Item(CHECK.Name) = "0"
            dtPracticeData.Rows(iCount1).Item(INDEXNUMBER.Name) = "0"
            dtPracticeData.Rows(iCount1).Item(SHOWNO.Name) = 0
            dtPracticeData.Rows(iCount1).Item(TEMPSHOWNO.Name) = 0
            dtPracticeData.Rows(iCount1).Item(QUESTIONCODE_LINK.Name) = dtPracticeData.Rows(iCount1).Item(QUESTIONCODE.Name)
            'If String.Compare(dtPracticeData.Rows(iCount1).Item(QUESTIONCLASS.Name), "2") = 0 And
            '   String.Compare(dtPracticeData.Rows(iCount1).Item(MIDDLEQUESTIONINDEX.Name), "0") = 0 Then
            '    dtPracticeData.Rows(iCount1).Item(ANSWERS.Name) = "-  "
            '    dtPracticeData.Rows(iCount1).Item(QUESTIONCOUNT.Name) = "-  "
            'End If
        Next
    End Sub

    ''' <summary>
    ''' カテゴリ（グループ）別の選出する小問の問題数のテーブルを取得する。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSynthesisQuestionCountTable() As DataTable
        Dim dtReturn As DataTable = New DataTable

        dtReturn.Columns.Add("DISPLAYID", GetType(String))
        dtReturn.Columns.Add("SYNTHESISQUESTIONCOUNT", GetType(System.Int32))
        dtReturn.Columns.Add("USECOUNT", GetType(System.Int32))
        dtReturn.Columns.Add("PARENTCATEGORYID", GetType(String))

        Dim cCategoryMaster As CategoryMaster = New CategoryMaster(1)
        Dim dtDatatable As DataTable = cCategoryMaster.GetCategoryTable()

        For Each drCategory As DataRow In dtDatatable.Rows
            If String.Compare(drCategory.Item(Common.CategoryMaster.ColumnIndex.CATEGORYCLASS), "1") = 0 And Integer.Parse(drCategory.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3)) > 0 Then
                dtReturn.Rows.Add(drCategory.Item(Common.CategoryMaster.ColumnIndex.DISPLAYID), Integer.Parse(drCategory.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3)), 0, drCategory.Item(Common.CategoryMaster.CagoryTableColumnIndex.DISPLAYID1))
            End If
        Next

        Return dtReturn
    End Function

    ''' <summary>
    ''' 問題が選択されていないカテゴリーをランダムに取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDisplayId(ByRef dtSynthesisQuestionCountTable As DataTable) As String
        GetDisplayId = ""
        Dim strReturn As String = Nothing
        Dim strSelect As String = ""

        GetDisplayId = dtSynthesisQuestionCountTable.Rows(CBTCommon.Utility.RollDice(dtSynthesisQuestionCountTable.Rows.Count)).Item("DISPLAYID")

    End Function

    ''' <summary>
    ''' 指定したカテゴリの小問をランダムに取得する。
    ''' </summary>
    ''' <param name="dtPracticeData"></param>
    ''' <param name="strDisplayId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMiniQuestion(ByRef dtPracticeData As DataTable, ByRef strDisplayId As String) As DataRow
        Dim drReturn As DataRow = Nothing
        Dim drSelectItem As DataRow()

        drSelectItem = dtPracticeData.Select(STATE.Name & "='STATUS_NOT_USE' AND " & CATEGORYID.Name & " LIKE '" & strDisplayId.Substring(0, 2) & "*'")

        'If drSelectItem.Length = 0 Then
        '    drSelectItem = dtPracticeData.Select(STATE.Name & "='STATUS_USED' AND " & QUESTIONCLASS.Name & "='1' AND " & CATEGORYID.Name & "= '" & strDisplayId & "'")
        '    For iCount = 0 To drSelectItem.Length - 1
        '        drSelectItem(iCount).Item(STATE.Name) = "STATUS_NOT_USE"
        '    Next
        '    drSelectItem = dtPracticeData.Select(STATE.Name & "='STATUS_NOT_USE' AND " & QUESTIONCLASS.Name & "='1' AND " & CATEGORYID.Name & "= '" & strDisplayId & "'")

        '    If drSelectItem.Length = 0 Then Return drReturn
        'End If
        'drSelectItem = dtPracticeData.Select(STATE.Name & "='STATUS_NOT_USE' AND " & QUESTIONCLASS.Name & "='1'")

        If drSelectItem.Length = 0 Then
            drSelectItem = dtPracticeData.Select(STATE.Name & "='STATUS_USED' AND " & CATEGORYID.Name & " LIKE '" & strDisplayId.Substring(0, 2) & "*'")
            For iCount = 0 To drSelectItem.Length - 1
                drSelectItem(iCount).Item(STATE.Name) = "STATUS_NOT_USE"
            Next
            drSelectItem = dtPracticeData.Select(STATE.Name & "='STATUS_NOT_USE' AND " & CATEGORYID.Name & " LIKE '" & strDisplayId.Substring(0, 2) & "*'")
            If drSelectItem.Length = 0 Then Return drReturn
        End If

        drReturn = drSelectItem(CBTCommon.Utility.RollDice(drSelectItem.Length))

        Return drReturn
    End Function

    ''' <summary>
    ''' 指定したカテゴリーの問題数をカウントアップする。
    ''' </summary>
    ''' <param name="dtSynthesisQuestionCount"></param>
    ''' <param name="strDisplayId"></param>
    ''' <remarks></remarks>
    Private Sub IncSynthesisQuestionCount(ByRef dtSynthesisQuestionCount As DataTable, ByRef strDisplayId As String)
        For Each drSynthesisQuestionCount As DataRow In dtSynthesisQuestionCount.Rows
            If String.Compare(drSynthesisQuestionCount.Item("DISPLAYID"), strDisplayId) = 0 Then
                drSynthesisQuestionCount.Item("USECOUNT") = Integer.Parse(drSynthesisQuestionCount.Item("USECOUNT")) + 1
            End If
        Next
    End Sub

    ''' <summary>
    ''' 中問の設問に対し問番号などを付与する
    ''' </summary>
    ''' <param name="drDatarow"></param>
    ''' <param name="iIndexNum"></param>
    ''' <remarks></remarks>
    Private Sub SetMiddleQuestionIndex(ByRef drDatarow As DataRow, ByRef iIndexNum As Integer)
        drDatarow.Item(STATE.Name) = "STATUS_VIEW"
        drDatarow.Item(SHOWNO.Name) = MINIQUESTION_NUM + 1 + (iIndexNum - 1) * MIDDLEQUESTION_1GROUP_NUM + Integer.Parse(drDatarow.Item(MIDDLEQUESTIONINDEX.Name))
        drDatarow.Item(INDEXNUMBER.Name) = (MINIQUESTION_NUM + (iIndexNum - 1) * MIDDLEQUESTION_NUM + Integer.Parse(drDatarow.Item(MIDDLEQUESTIONINDEX.Name))).ToString

        Dim dtQuestionCount As DataTable = GetQuestionCount(drDatarow.Item(QUESTIONCODE.Name))
        drDatarow.Item(ANSWERS.Name) = dtQuestionCount.Rows(0).Item(ANSWERS.Name)
        drDatarow.Item(QUESTIONCOUNT.Name) = dtQuestionCount.Rows(0).Item(QUESTIONCOUNT.Name)
    End Sub

#End Region

    ''' <summary>
    ''' ＷＯＲＤファイルを出力する。
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub btnWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWord.Click
        Dim dgvPracticeQuestionListDt As DataTable = m_dtPracticeData
        Dim WordApp As New Microsoft.Office.Interop.Word.Application
        Dim Doc As Microsoft.Office.Interop.Word.Document
        Dim cnt As Integer = 1

        Try
            'OpenFileDialogクラスのインスタンスを作成
            Dim ofd As New OpenFileDialog()

            ofd.Filter = "WORDファイル(*.doc,*.docx)|*.doc;*.docx"
            ofd.FilterIndex = 1
            ofd.Title = "出力するファイル名を入力してください"
            ofd.FileName = Me.txtSynthesisName.Text & ".doc"
            ofd.RestoreDirectory = True
            ofd.CheckFileExists = False
            ofd.CheckPathExists = True

            'ダイアログを表示する
            If ofd.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            For Each row As DataRow In dgvPracticeQuestionListDt.Select("STATE='STATUS_VIEW'", "[SHOWNO] ASC")
                Call makePracticeQuestion(row.Item(QUESTIONCODE.Name), cnt, ofd.FileName)
                cnt += 1
            Next

            Call CreateQuestionWordTail(ofd.FileName)

            Doc = WordApp.Documents.Open(ofd.FileName)

            Doc.SaveAs(ofd.FileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault)

            Doc.Close()
            WordApp.Quit()

            Common.Message.MessageShow("I007")      '保存が完了しました。

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' テストのWORDファイルを作成する。
    ''' </summary>
    ''' <param name="practiceQuestionCode">表示する問題番号</param>
    ''' <remarks></remarks>
    Private Sub makePracticeQuestion(ByVal practiceQuestionCode As String, ByVal cnt As Integer, ByVal Filename As String)

        ReadQuestionFile(Common.Constant.CST_PRACTICEQUESTION_FILENAME & practiceQuestionCode)

        Dim questionDefine As Common.VetNurseQuestionBank = _practiceQuestionBankCollection.Item(0)

        Dim Header As String = "問" & cnt & IIf(Me.ChkQ.Checked, "　　　問題コード：" & practiceQuestionCode, "") & IIf(Me.ChkT.Checked, "　　　正解：" & _practiceQuestionBankCollection.Item(0).Ansewr, "")

        Call questionDefine.CreateQuestionWord(Filename, cnt, Header)

    End Sub
    ''' <summary>
    ''' 問題読み込み処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Function ReadQuestionFile(ByVal FileName As String) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), FileName)
            Select Case questionFileNameList.Length
                Case 0
                    errCode = Constant.ResultCode.QuestionFileNotFoundError
                Case 1
                    Dim questionFileName = questionFileNameList(0)
                    _practiceQuestionBankCollection = Common.Serialize.BinaryFileToObject(IO.Path.GetFileName(questionFileName))
                    If _practiceQuestionBankCollection Is Nothing Then
                        errCode = Constant.ResultCode.QuestionFileReadError
                    Else
                        'If QuestionDefineCreator.Create(_practiceQuestionBankCollection) Is Nothing Then
                        '    errCode = Constant.ResultCode.QuestionFileParseError
                        'End If
                    End If
                Case Else
                    errCode = Constant.ResultCode.QuestionFileReadError
            End Select
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try

        Return errCode
    End Function

    ''' <summary>
    ''' 問題と選択肢を連結したファイルを、初回試験用、再試験用で作成します。
    ''' </summary>
    ''' <param name="WordfileName">保存するファイル名</param>
    ''' <remarks></remarks>
    Public Sub CreateQuestionWordTail(ByVal WordfileName As String)

        Try

            '設問の文字列の取得
            Dim sw As New System.IO.StreamWriter(WordfileName, True, System.Text.Encoding.GetEncoding("shift_jis"))
            sw.Write(GetQuestionHtmlT)
            sw.Close()

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' 設問のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionHtmlT() As String

        Dim strHtml As String = ""
        strHtml &= "</html>"
        Return strHtml
    End Function

    ''' <summary>
    ''' 試験実施に配信する。
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Try
            logger.Start()

            '問題一覧が表示されていない場合は終了
            If dgvPracticeList.Rows.Count < 1 Then
                Exit Sub
            End If

            Dim dtSpecificHeader As DataTable
            Dim dtSpecificDetail As DataTable = New DataTable
             Dim strTestName As String = txtSynthesisName.Text
            Dim iTestNo As Integer = 0
            Dim iCount As Integer

            If String.Compare(strTestName.Trim(), "") = 0 Then
                Message.MessageShow("E005", {"テスト名"})
                Exit Sub
            End If

            'Dim strFileName As String() = Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_SPECIFICHEADER_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)

            ''指定テストのファイルがある場合の処理
            'If strFileName.Length <> 0 Then
            '    System.IO.File.Delete(strFileName(0))
            'End If

            iTestNo = 1

            dtSpecificHeader = New DataTable
            Common.XmlSchema.GetSynthesisHeaderSchema(dtSpecificHeader)

            Dim cDataManager As DataManager = DataManager.GetInstance()

            '指定テストヘッダファイルへのデータの追加
            dtSpecificHeader.Rows.Add({iTestNo.ToString, txtSynthesisName.Text, cDataManager.GetDateTime.ToString, cDataManager.GetDateTime.ToString})
            dtSpecificHeader.TableName = Common.Constant.CST_SYNTHESISHEADER_FILENAME
            Serialize.DataTableToxml(dtSpecificHeader, Common.Constant.CST_SPECIFICHEADER_FILENAME & m_strGroupCode & Common.Constant.CST_EXTENSION_XML)

            '指定テスト明細ファイルへのデータの追加
            dtSpecificDetail = New DataTable
            Common.XmlSchema.GetSynthesisDetailSchema(dtSpecificDetail)
            dtSpecificDetail.TableName = Common.Constant.CST_SPECIFICDETAIL_FILENAME
            m_dvDataview.RowFilter = STATE.Name & "='STATUS_VIEW'" '状態がSTATUS_VIEWでフィルターをかける
            m_dvDataview.Sort = SHOWNO.Name & " ASC"
            For iCount = 0 To dgvPracticeList.Rows.Count - 1
                dtSpecificDetail.Rows.Add({iTestNo.ToString,
                                            dgvPracticeList.Rows(iCount).Cells(QUESTIONCODE.Name).Value,
                                            dgvPracticeList.Rows(iCount).Cells(SHOWNO.Name).Value.ToString,
                                            cDataManager.GetDateTime.ToString,
                                            cDataManager.GetDateTime.ToString})
                Dim drMiniQuestion As DataRow = m_dtPracticeData_Copy.Select("QUESTIONCODE = '" & dgvPracticeList.Rows(iCount).Cells(QUESTIONCODE.Name).Value & "'")(0)
                If drMiniQuestion Is Nothing Then
                    Continue For
                End If
                drMiniQuestion.Item(STATE.Name) = "1"
            Next
            Serialize.DataTableToxml(dtSpecificDetail, Common.Constant.CST_SPECIFICDETAIL_FILENAME & m_strGroupCode & "_" & iTestNo.ToString & Common.Constant.CST_EXTENSION_XML)

            Serialize.DataTableToxml(m_dtPracticeData_Copy, Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)

            Message.MessageShow("I016")

            Me.Close()

            logger.End()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub
End Class