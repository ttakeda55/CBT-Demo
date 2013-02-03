Imports System.IO

Imports CST.CBT
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.BaseControl

''' <summary>
''' 総合テスト確認画面（KG28）
''' </summary>
''' <remarks>
''' 2012/04/16 KAWASHIMA 初期作成
''' </remarks>
Public Class frmSynthesisList

#Region "メンバ変数"

    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    'xmlを読み込むdatatableを保持するメンバ変数を追加する。
    Dim m_dtSynthesisHeaderData As DataTable

#End Region

#Region "イベントハンドラ"

    Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'テスト一覧の表のフォーマットを整える
        SetDgvFormat()
    End Sub
    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmSynthesisList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            Me.lblBottomCode.Text = "KG25"
            Me.lblBottomName.Text = "テスト問題一覧"


            'SynthesisHeader[団体コード].xmlの内容をdatatableへ格納する。
            GetSynthesisHeaderData(m_dtSynthesisHeaderData)

            '画面出力用のdatatableの内容を画面へ出力する。
            dgvSynthesisList.DataSource = m_dtSynthesisHeaderData
            m_dtSynthesisHeaderData.AcceptChanges()

            Owner.Hide()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            btnBack_Click(sender, e)
        End Try
    End Sub

    ''' <summary>
    ''' 総合テスト一覧への描画時のイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSynthesisList_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvSynthesisList.CellFormatting
        Try

            If e.ColumnIndex = CREATE_DATE.Index Then
                e.Value = Format(e.Value, "Short Date")
            End If

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 状態変更ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' ボタンをクリックするたびに画面に表示されている内容と前回分の差分を確認し、差分があった場合は更新日を更新し、xmlファイルへ保存する。
    ''' </remarks>
    Private Sub btnStatusChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatusChange.Click
        Try
            logger.Start()

            If dgvSynthesisList.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim cDataManager As DataManager = DataManager.GetInstance()

            '各項目の状態が変更されていないか確認する。
            Dim iCount As Integer
            For iCount = 0 To m_dtSynthesisHeaderData.Rows.Count - 1
                '変更があった場合は更新日付を更新する。
                If m_dtSynthesisHeaderData.Rows(iCount).RowState = DataRowState.Modified Then
                    m_dtSynthesisHeaderData.Rows(iCount).Item(Common.SynthesisHeader.ColumnIndex.UpdateDate) = cDataManager.GetDateTime.ToString
                End If
            Next

            'datatableの内容をSynthesisHeader[団体コード].xmlへ書き込む。
            Dim strFileName As String() = Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_SYNTHESISHEADER_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)
            Serialize.DataTableToxml(m_dtSynthesisHeaderData, IO.Path.GetFileName(strFileName(0)))

            'ファイルへの書き込み完了後、変更完了のダイアログを表示する。
            Message.MessageShow("I008")

            '次回の更新に向けて現在の状態を保持する。
            m_dtSynthesisHeaderData.AcceptChanges()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 総合テスト一覧の内容をクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' テスト名をクリックした際に、総合テスト問題確認画面を表示する。
    ''' </remarks>
    Private Sub dgvQuestionMiniList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSynthesisList.CellContentClick
        Try
            logger.Start()

            'ヘッダーをクリックした場合は何もしない。
            If e.RowIndex >= 0 Then
                'クリックした列を判定
                Select Case e.ColumnIndex
                    Case TESTNAME.Index
                        'クリックした行番号をキーにテストNoを検索し、総合テスト問題確認画面（KG29）を表示する。
                        Dim strTestNo As String = CType(dgvSynthesisList.CurrentRow.DataBoundItem.row(), DataRow).Item("TESTNO")
                        Dim drSynthesis As DataRow = CType(dgvSynthesisList.Rows(e.RowIndex).DataBoundItem.row, DataRow)
                        Dim specificShowList = setSynthesisShowList(dgvSynthesisList.Rows(e.RowIndex).DataBoundItem("TESTNO"))
                        'Dim frm As New frmSpecificShow(specificShowList, drSynthesis(Common.SynthesisHeader.ColumnIndex.TestName),
                        '                                 Nothing, "", strTestNo)
                        Dim frm As New frmSynthesisInput
                        frm.Mode = Common.Constant.SpecificShowMode.ShowTestList
                        frm.specificShowList = specificShowList
                        frm.testno = strTestNo
                        frm.testname = drSynthesis(Common.SynthesisHeader.ColumnIndex.TestName)
                        frm.ShowDialog(Me)
                        If frm.DialogResult = DialogResult.Cancel Then
                            Me.Close()
                        Else
                            Show()
                        End If
                        frmSynthesisList_Load(Nothing, Nothing)
                        ''　総合テスト問題確認画面にてテスト名が変更されている可能性があるため、一時的に使用するdatatableを作成しxmlファイルを読み込む。
                        'Dim dtTemp As DataTable = New DataTable
                        'GetSynthesisHeaderData(dtTemp)

                        ''datatableの該当のテスト名、更新日を更新する。
                        ''画面のデータはm_dtSynthesisHeaderDataを更新することにより即時反映される。
                        'Dim iCount As Integer
                        'For iCount = 0 To m_dtSynthesisHeaderData.Rows.Count - 1
                        '    If Integer.Parse(dtTemp.Rows(iCount).Item("TESTNO")) = Integer.Parse(strTestNo) Then
                        '        CType(dgvSynthesisList.CurrentRow.DataBoundItem.row(), DataRow).Item("TESTNAME") = dtTemp.Rows(iCount).Item("TESTNAME")
                        '        CType(dgvSynthesisList.CurrentRow.DataBoundItem.row(), DataRow).Item("UPDATE_DATE") = dtTemp.Rows(iCount).Item("UPDATE_DATE")
                        '    End If
                        'Next
                End Select

            End If

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

            Me.DialogResult = DialogResult.OK
            Me.Close()

            logger.End()
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
    ''' 指定テスト登録確認用データ取得
    ''' </summary>
    ''' <param name="testNo"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' クリックされた指定テスト名から指定テスト明細を取得しする
    ''' </remarks>
    Public Function setSynthesisShowList(ByVal testNo As String) As DataTable
        Dim specificDetailDt As New DataTable
        Dim returnSpecificDetailDt As New DataTable
        Dim practiceQuestionListDt As New DataTable

        '指定テスト明細読み込み
        Dim fileName As String = Common.Constant.CST_SYNTHESISDETAIL_FILENAME & Common.Constant.CST_GROUPNAME & "_" & testNo & Common.Constant.CST_EXTENSION_XML
        specificDetailDt = Common.SpecificDetail.GetAll(fileName)

        'カテゴリー読み込み
        fileName = Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML
        practiceQuestionListDt = Common.PracticeQuestionList.GetAll(fileName)

        Dim KeyUserId(0) As DataColumn
        ''主キー設定
        KeyUserId(0) = specificDetailDt.Columns("QUESTIONCODE")
        specificDetailDt.PrimaryKey = KeyUserId
        KeyUserId(0) = practiceQuestionListDt.Columns("QUESTIONCODE")
        practiceQuestionListDt.PrimaryKey = KeyUserId

        'カテゴリカラム追加
        addCategoryColumns(practiceQuestionListDt)
        'カテゴリカラム設定
        setCategryListToSpecificDetail(practiceQuestionListDt)
        '難易度カラムの追加
        setLevel(practiceQuestionListDt)
        '指定テスト＆カテゴリーマージ
        specificDetailDt.Merge(practiceQuestionListDt)

        Dim showNoNum As New DataColumn
        showNoNum.ColumnName = "SHOWNONUM"
        showNoNum.DataType = GetType(Integer)
        specificDetailDt.Columns.Add(showNoNum)

        returnSpecificDetailDt = specificDetailDt.Clone
        For Each row As DataRow In specificDetailDt.Select("TESTNO = '" & testNo & "'")
            row.Item("SHOWNONUM") = CInt(row.Item("SHOWNO"))
            returnSpecificDetailDt.ImportRow(row)
        Next

        Return returnSpecificDetailDt
    End Function

    ''' <summary>
    ''' カテゴリカラム追加
    ''' </summary>
    ''' <param name="returnDt"></param>
    ''' <remarks></remarks>
    Private Sub addCategoryColumns(ByRef returnDt As DataTable)
        If returnDt.Columns.IndexOf("CATEGORYID1") <= 0 Then
            '分野・グループID
            returnDt.Columns.Add("CATEGORYID1")
            returnDt.Columns.Add("CATEGORYID2")
            returnDt.Columns.Add("CATEGORYID3")
            '分野・グループ名
            returnDt.Columns.Add("CATEGORYNAME1")
            returnDt.Columns.Add("CATEGORYNAME2")
            returnDt.Columns.Add("CATEGORYNAME3")
            returnDt.Columns.Add("CATEGORYNAME4")
        End If
    End Sub

    ''' <summary>
    ''' カテゴリーリスト設定
    ''' </summary>
    ''' 小問のカテゴリーリストを取得する。
    ''' また選択数、全問題数を設定する。
    ''' <remarks></remarks>   
    Private Sub setCategryListToSpecificDetail(ByVal dtSpecificDetail As DataTable)
        Dim dtCategoryTable As New DataTable

        Dim category As New Common.CategoryMaster(2)
        dtCategoryTable = category.GetCategoryTable
        For Each drSpecificDetail As DataRow In dtSpecificDetail.Rows
            If drSpecificDetail(Common.PracticeQuestionList.ColumnIndex.CategoryId) <> "" Then
                Dim founrdDataRow As DataRow() = dtCategoryTable. _
                                                 Select("DISPLAYID = " & _
                                                        drSpecificDetail(Common.PracticeQuestionList.ColumnIndex.CategoryId))
                If founrdDataRow.Length > 0 Then
                    drSpecificDetail("CATEGORYNAME1") = founrdDataRow(0).Item("CATEGORYNAME1")
                    drSpecificDetail("CATEGORYNAME2") = founrdDataRow(0).Item("CATEGORYNAME2")
                    drSpecificDetail("CATEGORYNAME3") = founrdDataRow(0).Item("CATEGORYNAME3")
                    drSpecificDetail("CATEGORYNAME4") = founrdDataRow(0).Item("CATEGORYNAME")
                    drSpecificDetail("CATEGORYID1") = founrdDataRow(0).Item("CATEGORYID1")
                    drSpecificDetail("CATEGORYID2") = founrdDataRow(0).Item("CATEGORYID2")
                    drSpecificDetail("CATEGORYID3") = founrdDataRow(0).Item("CATEGORYID3")
                End If
            End If

        Next
    End Sub

    ''' <summary>
    ''' 難易度カラムの追加
    ''' </summary>
    ''' <param name="dtPracticeQuestionList"></param>
    ''' <remarks></remarks>
    Private Sub setLevel(ByRef dtPracticeQuestionList As DataTable)
        dtPracticeQuestionList.Columns.Add("LEVEL_STR", GetType(String), "IIF(LEVEL = '1','低',IIF(LEVEL = '2','中','高'))")
    End Sub

    ''' <summary>
    ''' dgvPracticeListのフォーマットを整える
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDgvFormat()

        With dgvSynthesisList
            .Columns(TESTNAME.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(CREATE_DATE.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(VISIBLE.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            'タイトル行の折り返し禁止
            .Columns(TESTNAME.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(CREATE_DATE.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False
            .Columns(VISIBLE.Name).HeaderCell.Style.WrapMode = DataGridViewTriState.False

            'ヘッダのタイトルをセンタリングしたいが、ソート時に三角の記号が表示されるためきれいにセンタリングされない。
            'そのためスペースを入れ位置の調整を行う。
            .Columns(TESTNAME.Name).HeaderCell.Value = Space(45) & .Columns(TESTNAME.Name).HeaderCell.Value & Space(40)
            .Columns(CREATE_DATE.Name).HeaderCell.Value = Space(9) & .Columns(CREATE_DATE.Name).HeaderCell.Value & Space(8)

            .AutoGenerateColumns = False
        End With
    End Sub

    ''' <summary>
    ''' SynthesisHeaderからデータを取得する。
    ''' </summary>
    ''' <param name="dtReturnData"></param>
    ''' <remarks></remarks>
    Private Sub GetSynthesisHeaderData(ByRef dtReturnData As DataTable)
        Dim strFileName As String() = Directory.GetFiles(Common.Constant.GetTempPath, Common.Constant.CST_SYNTHESISHEADER_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML)
        Dim dtTemp As DataTable = New DataTable

        If strFileName.Length = 0 Then
            Common.XmlSchema.GetSynthesisHeaderSchema(dtTemp)
        Else
            dtTemp = Serialize.XmlToDataTable(IO.Path.GetFileName(strFileName(0)))
        End If

        '画面出力用のdatatableへテストNoの順で表示順を設定する。
        dtReturnData = dtTemp.Clone()
        Dim dvSynthesisHeaderData As DataView
        dvSynthesisHeaderData = New DataView(dtTemp)
        dvSynthesisHeaderData.Sort = "TESTNO"
        For Each drv As DataRowView In dvSynthesisHeaderData
            dtReturnData.ImportRow(drv.Row)
        Next
        'dtReturnData.Columns.Add("TESTSTART_DATETIME_CNV", GetType(DateTime), "TESTSTART_DATETIME")
        'dtReturnData.Columns.Add("TESTEND_DATETIME_CNV", GetType(DateTime), "TESTEND_DATETIME")
        'dtReturnData.DefaultView.Sort = "TESTSTART_DATETIME_CNV ASC"
    End Sub

#End Region


End Class