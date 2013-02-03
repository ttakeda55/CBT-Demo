Imports System.IO
Imports CST.CBT
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.QuestionShow

''' <summary>
''' 個人問別正誤画面
''' </summary>
''' <remarks>
''' 2011/09/05 NAKAMURA 新規作成
''' </remarks>
Public Class frmTrueFalseList

    Private cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
    Public QuestionBankCol As New QuestionBankCollection
    Public QBTable As New System.Data.DataTable

#Region "----- 定数 -----"

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "個人問別正誤"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "個人問別正誤画面"
    ''' <summary>btnBackテキスト</summary>
    Private Const BUTTON_BACK_TEXT As String = "メインメニューへ戻る"
    ''' <summary>画面表示ID(KG03-2)</summary>
    Private Const DISPLAY_ID_KG03_2 As String = "KG03-2"
    ''' <summary>画面表示ID(KG03-3)</summary>
    Private Const DISPLAY_ID_KG03_3 As String = "KG03-3"
    ''' <summary>画面表示ID(KG07)</summary>
    Private Const DISPLAY_ID_KG07 As String = "KG07"
    ''' <summary>画面表示ID(KG08)</summary>
    Private Const DISPLAY_ID_KG08 As String = "KG08"
    ''' <summary>画面表示ID(KG13)</summary>
    Private Const DISPLAY_ID_KG13 As String = "KG13"
    ''' <summary>画面表示ID(JG01)</summary>
    Private Const DISPLAY_ID_JG01 As String = "JG01"
    ''' <summary>画面表示ID(JG09-1)</summary>
    Private Const DISPLAY_ID_JG09_1 As String = "JG09-1"
    ''' <summary>画面表示ID(JG09-2)</summary>
    Private Const DISPLAY_ID_JG09_2 As String = "JG09-2"
    ''' <summary>画面表示ID(JG10-1)</summary>
    Private Const DISPLAY_ID_JG10_1 As String = "JG10-1"
    ''' <summary>画面表示ID(JG10-2)</summary>
    Private Const DISPLAY_ID_JG10_2 As String = "JG10-2"
    ''' <summary>画面表示ID(JG11-1)</summary>
    Private Const DISPLAY_ID_JG11_1 As String = "JG11-1"
    ''' <summary>画面表示ID(JG11-2)</summary>
    Private Const DISPLAY_ID_JG11_2 As String = "JG11-2"
    ''' <summary>画面表示ID(JG13)</summary>
    Private Const DISPLAY_ID_JG13 As String = "JG13"

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>個人試験結果ヘッダオブジェクト</summary>
    Private _TestResultDetail As Common.TestResultDetail
    ''' <summary>試験回数</summary>
    Private _TestCount As Integer
    ''' <summary>正解リスト</summary>
    Private _AnswerList As Generic.Dictionary(Of Integer, String)
    ''' <summary>フォームロードフラグ</summary>
    Private _FormLoad As Boolean = True
#End Region

#Region "----- プロパティ -----"

    ''' <summary>個人試験結果ヘッダオブジェクトの設定</summary>
    Public WriteOnly Property TestResultDetail As Common.TestResultDetail
        Set(ByVal value As Common.TestResultDetail)
            _TestResultDetail = value
        End Set
    End Property

    ''' <summary>試験回数の設定</summary>
    Public WriteOnly Property TestCount As Integer
        Set(ByVal value As Integer)
            _TestCount = value
        End Set
    End Property

    ''' <summary>正解リストの設定</summary>
    Public WriteOnly Property AnswerList As Generic.Dictionary(Of Integer, String)
        Set(ByVal value As Generic.Dictionary(Of Integer, String))
            _AnswerList = value
        End Set
    End Property

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
            '初期処理
            If Not init() Then
                Me.Close()
                Exit Sub
            End If

            'DataGridView初期化処理
            Call InitializeDataGridView()
            'データ設定処理
            Call SetDataGridView()
            '画面初期化処理
            Call InitializeDisplay()

            _FormLoad = False
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 個人詳細結果(メインメニュー)へ戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            If dataBanker("SHAREFORM") = DISPLAY_ID_KG08 Then
                dataBanker("FROMFORM") = DISPLAY_ID_KG08
                dataBanker("TOFORM") = DISPLAY_ID_KG07
            ElseIf dataBanker("SHAREFORM") = DISPLAY_ID_JG10_1 Then
                dataBanker("FROMFORM") = DISPLAY_ID_JG10_1
                dataBanker("TOFORM") = DISPLAY_ID_JG01
            ElseIf dataBanker("SHAREFORM") = DISPLAY_ID_JG10_2 Then
                dataBanker("FROMFORM") = DISPLAY_ID_JG10_2
                dataBanker("TOFORM") = DISPLAY_ID_JG01
            End If
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 受験結果確認へ戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            dataBanker("TOFORM") = DISPLAY_ID_JG13
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 合否結果へ戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = Me.lblBottomCode.Text
            If dataBanker("SHAREFORM") = DISPLAY_ID_JG10_1 Then
                dataBanker("TOFORM") = DISPLAY_ID_JG09_1
            Else
                dataBanker("TOFORM") = DISPLAY_ID_JG09_2
            End If
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題番号選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdLeftList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdLeftList.CellContentClick
        Try
            If TypeOf grdLeftList.Columns(e.ColumnIndex) Is DataGridViewLinkColumn AndAlso Not e.RowIndex = -1 Then
                Dim Qno As Integer = grdLeftList.Rows(e.RowIndex).Cells("QUESTIONNO").Tag
                Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                dataBanker("FROMFORM") = lblBottomCode.Text
                dataBanker("TOFORM") = "KG01"

                Dim GDataManager As GDataManager = GDataManager.GetInstance()
                Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
                If GDataManager.QuestionFileName <> cGroup.GetQuestionFileName(dataBanker("GROUPCODE")) Then
                    processMessage = True
                    Refresh()
                    GDataManager.ReadQuestionFile(cGroup.GetQuestionFileName(dataBanker("GROUPCODE")))
                End If
                Dim frmShow As QuestionShow.frmQuestionShow

                '問別解説画面を表示
                frmShow = New QuestionShow.frmQuestionShow(0, Qno)
                processMessage = False
                frmShow.ShowDialog(Me)
                If dataBanker("LOGOUT") Then
                    Close()
                Else
                    Me.Visible = True
                End If
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題番号選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdRightList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRightList.CellContentClick
        Try
            If TypeOf grdRightList.Columns(e.ColumnIndex) Is DataGridViewLinkColumn AndAlso Not e.RowIndex = -1 Then
                Dim Qno As Integer = grdRightList.Rows(e.RowIndex).Cells("QUESTIONNO2").Tag
                Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
                dataBanker("FROMFORM") = lblBottomCode.Text
                dataBanker("TOFORM") = "KG01"

                Dim GDataManager As GDataManager = GDataManager.GetInstance()
                Dim cGroup As eIPSTA.GroupManager.GroupClass = eIPSTA.GroupManager.GroupClass.GetInstance
                If GDataManager.QuestionFileName <> cGroup.GetQuestionFileName(dataBanker("GROUPCODE")) Then
                    processMessage = True
                    Refresh()
                    GDataManager.ReadQuestionFile(cGroup.GetQuestionFileName(dataBanker("GROUPCODE")))
                End If
                Dim frmShow As QuestionShow.frmQuestionShow

                '問別解説画面を表示
                frmShow = New QuestionShow.frmQuestionShow(0, Qno)
                processMessage = False
                frmShow.ShowDialog(Me)
                If dataBanker("LOGOUT") Then
                    Close()
                Else
                    Me.Visible = True
                End If
            End If
        Catch ex As Exception
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

#Region "----- メソッド -----"

    ''' <summary>
    ''' 画面初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDisplay()
        Try
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            Dim BtnLocation As System.Drawing.Point
            Me.Text = FORM_TEXT
            Me.lblBottomName.Text = DISPLAY_NAME
            If dataBanker("SHAREFORM") = DISPLAY_ID_KG08 Then
                Me.lblBottomCode.Text = DISPLAY_ID_KG08
                Me.btnBack.Visible = True
                dataBanker("SHARETO") = DISPLAY_ID_KG03_2
            ElseIf dataBanker("SHAREFORM") = DISPLAY_ID_KG13 Then
                Me.lblBottomCode.Text = DISPLAY_ID_KG13
                Me.btnBack.Visible = True
                Me.btnBack.Focus()
                dataBanker("SHARETO") = DISPLAY_ID_KG03_3
            ElseIf dataBanker("SHAREFORM") = DISPLAY_ID_JG10_1 Then
                Me.lblBottomCode.Text = DISPLAY_ID_JG10_1
                Me.btnBack.Visible = True
                BtnLocation.X = 624
                Me.btnBack.Text = BUTTON_BACK_TEXT
                dataBanker("SHARETO") = DISPLAY_ID_JG11_1
            ElseIf dataBanker("SHAREFORM") = DISPLAY_ID_JG10_2 Then
                Me.lblBottomCode.Text = DISPLAY_ID_JG10_2
                Me.btnBack.Visible = True
                Me.btnBack.Text = BUTTON_BACK_TEXT
                dataBanker("SHARETO") = DISPLAY_ID_JG11_2
            End If
            Me.btnBack.Focus()

            Owner.Hide()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub


    ''' <summary>
    ''' 初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Function init() As Boolean
        Dim TempPath As String = CST.CBT.eIPSTA.Common.Constant.GetTempPath
        Dim FileName As String
        Try
            FileName = cGroup.GetQuestionFileName(dataBanker("GROUPCODE"))
            If File.Exists(TempPath & FileName) Then
                QuestionBankCol = Common.Serialize.BinaryFileToObject(FileName)
            Else
                Common.Message.MessageShow("I002")
                Return False
            End If

            lblBottomCode.Text = DISPLAY_ID_KG08

            With grdLeftList
                'グリッド初期設定
                .ReadOnly = True
                .AllowUserToAddRows = False
                'grdResultListの列の幅をユーザーが変更できないようにする
                .AllowUserToResizeColumns = False
                'grdResultListの行の高さをユーザーが変更できないようにする
                .AllowUserToResizeRows = False
                'grdResultListでセル、行、列が複数選択されないようにする
                .MultiSelect = False
                'ソート不可
                For Each Col As DataGridViewColumn In .Columns
                    Col.SortMode = DataGridViewColumnSortMode.NotSortable
                Next Col

            End With
            With grdRightList
                'グリッド初期設定
                .ReadOnly = True
                .AllowUserToAddRows = False
                'grdResultListの列の幅をユーザーが変更できないようにする
                .AllowUserToResizeColumns = False
                'grdResultListの行の高さをユーザーが変更できないようにする
                .AllowUserToResizeRows = False
                'grdResultListでセル、行、列が複数選択されないようにする
                .MultiSelect = False
                'ソート不可
                For Each Col As DataGridViewColumn In .Columns
                    Col.SortMode = DataGridViewColumnSortMode.NotSortable
                Next Col

            End With

            '問題取得
            QBTable = GetOuestionBank(QuestionBankCol)
            Return True
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' 問題取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetOuestionBank(ByVal questionBankCol As QuestionBankCollection) As System.Data.DataTable
        Dim TmpTable As New System.Data.DataTable
        Dim Row As DataRow

        Dim Middle As Integer = 1
        Dim PreMiddle As Integer = 0
        Dim PreMiddleStr As String = ""
        Dim MiddleIndex As Integer = 0

        'カラム準備
        TmpTable.Columns.Add("QUESTIONNO", GetType(String))         '問題番号
        TmpTable.Columns.Add("ANSWER", GetType(String))             '解答
        TmpTable.Columns.Add("MIDDLE", GetType(Integer))            '中問INDEX
        TmpTable.Columns.Add("MIDDLENO", GetType(String))           '表示用　中問番号
        TmpTable.Columns.Add("QUESTIONTHEME", GetType(String))      'テーマ

        For i As Integer = 0 To questionBankCol.Count - 1
            '中問
            If IsNothing(questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI)) Then
                Row = TmpTable.NewRow()
                Row("QUESTIONNO") = i + 1
                Row("ANSWER") = questionBankCol.Item(i).FirstAnsewr.ToString
                Row("MIDDLE") = 0
                TmpTable.Rows.Add(Row)
                PreMiddle = 0
            Else
                If PreMiddleStr = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI) Then
                    Row = TmpTable.NewRow()
                    Row("QUESTIONNO") = i + 1
                    Row("ANSWER") = questionBankCol.Item(i).FirstAnsewr.ToString
                    Row("MIDDLE") = MiddleIndex
                    Row("MIDDLENO") = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI).ToString
                    If Not IsNothing(questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_THEME)) Then
                        Row("QUESTIONTHEME") = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_THEME).ToString
                    End If
                    TmpTable.Rows.Add(Row)
                Else
                    PreMiddle = Middle
                    PreMiddleStr = questionBankCol.Item(i).QuestionProperty(CST.CBT.eIPSTA.Common.Constant.CST_MULTI)
                    MiddleIndex = i
                End If
            End If
        Next i

        Return TmpTable
    End Function

    ''' <summary>
    ''' DataGridView初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDataGridView()
        Try
            grdLeftList.Rows.Clear()
            grdRightList.Rows.Clear()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' データ設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDataGridView()
        Dim Detail As DataTable
        Dim RankView As New DataView
        Dim detailDataRow As DataTable = Nothing
        Dim questionNo As String = ""
        Dim leftCount As Integer = 0
        Dim rightCount As Integer = 0
        Dim i As Integer = 0
        '

        Try

            Detail = cGroup.DetailSrorAdd(dataBanker("TestDetail"))
            detailDataRow = Detail.Clone()
            For Each Row As DataRow In Detail.Select("USERID = '" & dataBanker("TESTUSERID") & "' AND TESTCOUNT = '" & dataBanker("TESTCOUNT") & "'", "QUESTIONINT")
                detailDataRow.ImportRow(Row)
            Next

            Me.grdLeftList.SuspendLayout()
            Me.grdRightList.SuspendLayout()

            If Not IsNothing(detailDataRow) Then
                'For i = 0 To detailDataRow.Length - 1
                For i = 0 To detailDataRow.Rows.Count - 1
                    If i <= 49 Then
                        Me.grdLeftList.Rows.Add()
                        With Me.grdLeftList.Rows(leftCount)
                            questionNo = detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.QuestionNo)
                            .Cells(0).Value = "問" & questionNo
                            .Cells(0).Tag = questionNo
                            .Cells(1).Value = detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.QuestionTheme)
                            .Cells(2).Value = QBTable.Rows(i).Item("ANSWER")
                            .Cells(3).Value = detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.Answer)
                            .Cells(4).Value = IIf(detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.Errata) = "0", "×", "○")
                        End With
                        leftCount += 1
                    ElseIf i >= 50 Then
                        Me.grdRightList.Rows.Add()
                        With Me.grdRightList.Rows(rightCount)
                            questionNo = detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.QuestionNo)
                            .Cells(0).Value = "問" & questionNo
                            .Cells(0).Tag = questionNo
                            .Cells(1).Value = detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.QuestionTheme)
                            .Cells(2).Value = QBTable.Rows(i).Item("ANSWER")
                            .Cells(3).Value = detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.Answer)
                            .Cells(4).Value = IIf(detailDataRow.Rows(i).Item(Common.TestResultDetail.ColumnIndex.Errata) = "0", "×", "○")
                        End With
                        rightCount += 1
                    End If
                Next
            End If

            Me.grdLeftList.ResumeLayout()
            Me.grdRightList.ResumeLayout()

        Catch ex As Exception
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
            dataBanker("TOFORM") = dataBanker("SHARETO")
            dataBanker("QUESTIONNUMBER") = questionNo
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

End Class