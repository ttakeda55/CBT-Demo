Imports CST.CBT.eIPSTA.Common
Imports CST.CBT.eIPSTA.SharedForm
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
''' <summary>
''' 採点結果画面
''' </summary>
''' <remarks></remarks>
Public Class frmSynthesisTestMarkHistory

#Region "----- 定数 -----"

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "採点結果"
    ''' <summary>総合テスト採点結果用画面表示ID</summary>
    Private Const DISPLAY_ID_SYNTHESIS_RESULT As String = "JG33"
    ''' <summary>総合テスト採点結果用画面表示名</summary>
    Private Const DISPLAY_NAME_SYNTHESIS_RESULT As String = "総合テスト採点結果画面"
    ''' <summary>総合テスト採点結果(履歴)用画面表示ID</summary>
    Private Const DISPLAY_ID_SYNTHESIS_HISTORY As String = "JG42"
    ''' <summary>中問逐次演習問題用画面表示名</summary>
    Private Const DISPLAY_NAME_SYNTHESIS_HISTORY As String = "総合テスト採点結果画面"
    ''' <summary>総合テストトップ画面表示ID</summary>
    Private Const DISPLAY_ID_SYNTHESIS_TOP As String = "JG29"
    ''' <summary>総合テスト実施履歴一覧画面表示ID</summary>
    Private Const DISPLAY_ID_SYNTHESIS_HISTORYTOP As String = "JG41"
    ''' <summary>総合テスト問別正誤一覧画面表示ID</summary>
    Private Const DISPLAY_ID_SYNTHESIS_LIST As String = "JG34"
    ''' <summary>総合テスト問別正誤一覧(履歴)画面表示ID</summary>
    Private Const DISPLAY_ID_SYNTHESIS_HISTORYLIST As String = "JG43"
    ''' <summary>総合テスト解説(小問)用画面表示ID</summary>
    Private Const DISPLAY_ID_SMALL_SYNTHESI As String = "JG35"
    ''' <summary>総合テスト解説(中問)用画面表示ID</summary>
    Private Const DISPLAY_ID_MIDDLE_SYNTHESI As String = "JG36"

#End Region

#Region "----- メンバ変数 -----"

    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>問別正誤画面</summary>
    Private WithEvents _FrmNext As frmSynthesisTrueFalseList
    ''' <summary>画面表示ID</summary>
    Private _DisplayId As String = ""
    ''' <summary>画面表示名</summary>
    Private _DisplayName As String = ""
    ''' <summary>トップ画面表示ID</summary>
    Private _DisplayBackId As String = ""
    ''' <summary>問別正誤一覧画面表示ID</summary>
    Private _DisplayListId As String = ""
    ''' <summary>総合テスト結果Datarow</summary>
    Private _SynthesisResultDataRow As DataRow = Nothing
    ''' <summary>総合テスト大分類正解率DataTable</summary>
    Private _LargeCategoryAccuracyRateTbl As DataTable = Nothing

#End Region

#Region "----- プロパティ -----"

    ''' <summary>総合テスト結果DataRowの設定</summary>
    Public WriteOnly Property SynthesisResultDataRow As DataRow
        Set(ByVal value As DataRow)
            _SynthesisResultDataRow = value
        End Set
    End Property

    ''' <summary>総合テスト大分類正解率DataTableの設定</summary>
    Public WriteOnly Property LargeCategoryAccuracyRateTbl As DataTable
        Set(ByVal dt As DataTable)
            _LargeCategoryAccuracyRateTbl = dt
        End Set
    End Property

#End Region

#Region "----- コンストラクタ -----"

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' コントロールの配置を設定する
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        If dataBanker("TOFORM") = DISPLAY_ID_SYNTHESIS_RESULT Then
            ' 総合テスト採点結果画面
            SetSynthesisControl()
        Else
            ' 総合テスト採点結果(履歴)画面
            SetSynthesisHistoryControl()
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
    Private Sub frmSynthesisTestMarkHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()
            '画面表示設定
            Call SetDisply()
            'レーダーチャート作成
            Call CreateRadarChart()
            '画面表示
            Owner.Hide()
            Show()
            'フォーカス設定
            Me.btnBack.Focus()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            _Log.Start()
            ShowTopForm()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 問別正誤表示ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        Dim dataBanker As CBTCommon.DataBanker = Nothing
        Dim testCount As String = ""
        Dim testNo As String = ""

        Try
            _Log.Start()
            dataBanker = CBTCommon.DataBanker.GetInstance
            dataBanker("FROMFORM") = _DisplayId
            dataBanker("TOFORM") = _DisplayListId
            ' 画面を非表示
            Me.Hide()

            _FrmNext = New frmSynthesisTrueFalseList
            ' 総合テスト結果Datarowセット
            _FrmNext.SynthesisResultDataRow = _SynthesisResultDataRow
            ' 問別正誤DataTableセット
            'testCount = DataManager.GetInstance.SynthesisDefine.TestCount
            testCount = _SynthesisResultDataRow(SynthesisResultDefine.SynthesisResultHistTblIndex.TestCount)
            testNo = _SynthesisResultDataRow(SynthesisResultDefine.SynthesisResultHistTblIndex.TestNo)
            _FrmNext.SynthesisResultTrueFalseTbl = DataManager.GetInstance.GetTrueFalseDataTable(testCount, testNo, Constant.TestType.SynthesisResult)
            ' 問別正誤画面を表示
            _FrmNext.ShowDialog(Me)

            If DataManager.GetInstance.IsLogouting Then
                ' ログアウトした場合
                Close()
            Else
                ' 問別正誤画面で戻るボタンを押下した場合
                Me.Show()
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
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            _Log.Start()
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    If _FrmNext Is Nothing = False Then
                        _FrmNext.Close()
                    End If
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & resultCode)
            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 総合テスト採点結果用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSynthesisControl()
        Try
            _DisplayId = DISPLAY_ID_SYNTHESIS_RESULT
            _DisplayName = DISPLAY_NAME_SYNTHESIS_RESULT
            _DisplayBackId = DISPLAY_ID_SYNTHESIS_TOP
            _DisplayListId = DISPLAY_ID_SYNTHESIS_LIST
            lblTestName.Visible = False
            btnBack.Text = "テストトップへ戻る"

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 総合テスト採点結果(履歴)用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSynthesisHistoryControl()
        Try
            _DisplayId = DISPLAY_ID_SYNTHESIS_HISTORY
            _DisplayName = DISPLAY_NAME_SYNTHESIS_HISTORY
            _DisplayBackId = DISPLAY_ID_SYNTHESIS_HISTORYTOP
            _DisplayListId = DISPLAY_ID_SYNTHESIS_HISTORYLIST
            lblTestName.Visible = True
            btnBack.Text = "総合テスト実施履歴一覧へ戻る"

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 画面表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDisply()
        Try
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            ''ユーザーID設定
            'Me.UserId = ”ID：" & DataManager.GetInstance.UserId
            ''ユーザー名設定
            'Me.UserName = "氏名：" & DataManager.GetInstance.UserName
            '画面表示名設定
            Me.lblBottomName.Text = _DisplayName
            '画面表示ID設定
            Me.lblBottomCode.Text = _DisplayId

            '2012/06/07 nozao add s
            'カテゴリ名
            Call setCategoryName()
            '2012/06/07 nozao add e

            '評価点、正解率などを設定
            Call SetGradePoint()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 評価点設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGradePoint()
        Dim CorrectAnswerCount As String = ""
        Dim QuestionCount As String = ""
        Dim AccuracyRate As String = ""
        Try
            ' 正解数
            lblTotal.Text = _SynthesisResultDataRow.Item(synthesisResultDefine.SynthesisResultHistTblIndex.TotalCorrectAnswerCount)
            ' 問題数
            lblTestTotal.Text = _SynthesisResultDataRow.Item(synthesisResultDefine.SynthesisResultHistTblIndex.TotalQuestionCount)
            ' 正解率
            lblPercentage.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.TotalAccuracyRate)

            ' テスト名 + 実施日
            If lblBottomCode.Text = DISPLAY_ID_SYNTHESIS_HISTORY Then
                lblTestName.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.TestName) _
                                    & " (" _
                                    & _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.TestDate).ToString.Replace("/", ".") _
                                    & "実施)"
            End If

            ' 正解率の初期化
            lblCategory_A.Text = "0.0"          '国語
            lblCategory_B.Text = "0.0"          '社会
            lblCategory_C.Text = "0.0"          '数学
            lblCategory_D.Text = "0.0"          '理科
            lblCategory_E.Text = "0.0"          '英語

            ' 分類別正解率
            '国語
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate1)) Then
                lblCategory_A.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate1)
            End If

            '社会
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate2)) Then
                lblCategory_B.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate2)
            End If

            '数学
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate3)) Then
                lblCategory_C.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate3)
            End If

            '理科
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate4)) Then
                lblCategory_D.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate4)
            End If

            '英語
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate5)) Then
                lblCategory_E.Text = _SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate5)
            End If

            ' 大分類別正解率
            Dim NameIndex As Integer = SynthesisResultDefine.LargeCategoryAccuracyRateTblIndex.LargeCategoryName
            Dim AccuracyRateIndex As Integer = SynthesisResultDefine.LargeCategoryAccuracyRateTblIndex.AccuracyRate
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' レーダーチャート作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateRadarChart()
        Dim xVal As Generic.List(Of String)
        Dim yVal As Generic.List(Of Double)

        Try
            '初期化
            xVal = New Generic.List(Of String)
            yVal = New Generic.List(Of Double)
            'グラフ表示データ作成
            Call CreateChartData(xVal, yVal)
            'データ設定
            Me.Chart1.Series(0).Points.DataBindXY(xVal, yVal)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' グラフ表示データ作成
    ''' </summary>
    ''' <param name="xVal">X軸データ</param>
    ''' <param name="yVal">Y軸データ</param>
    ''' <remarks></remarks>
    Private Sub CreateChartData(ByVal xVal As Generic.List(Of String), ByVal yVal As Generic.List(Of Double))
        Try
            ' 大分類別正解率
            Dim NameIndex As Integer = synthesisResultDefine.LargeCategoryAccuracyRateTblIndex.LargeCategoryName
            Dim AccuracyRateIndex As Integer = SynthesisResultDefine.LargeCategoryAccuracyRateTblIndex.AccuracyRate

            '国語系
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate1)) Then
                xVal.Add(lblFieldCategoryName_A.Text)
                yVal.Add(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate1))
            End If

            '社会系
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate2)) Then
                xVal.Add(lblFieldCategoryName_B.Text)
                yVal.Add(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate2))
            End If

            '数学系
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate3)) Then
                xVal.Add(lblFieldCategoryName_C.Text)
                yVal.Add(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate3))
            End If

            '理科系
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate4)) Then
                xVal.Add(lblFieldCategoryName_D.Text)
                yVal.Add(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate4))
            End If

            '英語系
            If Not IsDBNull(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate5)) Then
                xVal.Add(lblFieldCategoryName_E.Text)
                yVal.Add(_SynthesisResultDataRow.Item(SynthesisResultDefine.SynthesisResultHistTblIndex.AccuracyRate5))
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' TOP画面に戻ります。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowTopForm()
        Try
            '画面を閉じる
            Me.Close()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    '2012/06/07 nozao add s
    ''' <summary>
    ''' カテゴリ名を設定する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setCategoryName()
        lblFieldCategoryName_A.Text = Common.CategoryMaster.GetCategoryName(Common.CategoryMaster.categoryId.fieldCategoryId_A)
        lblFieldCategoryName_B.Text = Common.CategoryMaster.GetCategoryName(Common.CategoryMaster.categoryId.fieldCategoryId_B)
        lblFieldCategoryName_C.Text = Common.CategoryMaster.GetCategoryName(Common.CategoryMaster.categoryId.fieldCategoryId_C)
        lblFieldCategoryName_D.Text = Common.CategoryMaster.GetCategoryName(Common.CategoryMaster.categoryId.fieldCategoryId_D)
        lblFieldCategoryName_E.Text = Common.CategoryMaster.GetCategoryName(Common.CategoryMaster.categoryId.fieldCategoryId_E)
    End Sub
    '2012/06/07 nozao add e

#End Region

End Class