''' <summary>
''' 問別解説フォーム(小問、中問共用)
''' </summary>
''' <remarks></remarks>
Public Class frmQuestionShow

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "模試"
    ''' <summary>画面表示ID(JG01)</summary>
    Private Const DISPLAY_ID_JG01 As String = "JG01"
    ''' <summary>小問用画面表示名</summary>
    Private Const DISPLAY_NAME_SMALL As String = "模擬小問画面"
    ''' <summary>中問用画面表示名</summary>
    Private Const DISPLAY_NAME_MIDDLE As String = "模擬中問画面"
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>小問用画面表示ID</summary>
    Private _DisplayIdSmall As String = "KG03"

    ''' <summary>中問用画面表示ID</summary>
    Private _DisplayIdMiddle As String = "KG04"

    ''' <summary>小問用画面表示ID</summary>
    Private _DisplayIdSYSSmall As String = "TG03-1"

    ''' <summary>中問用画面表示ID</summary>
    Private _DisplayIdSYSMiddle As String = "TG03-2"

    ''' <summary>画面表示IDモード１</summary>
    Private _DisplayIdMode1 As String = "-1"

    ''' <summary>画面表示IDモード２</summary>
    Private _DisplayIdMode2 As String = "-2"

    ''' <summary>画面表示IDモード３</summary>
    Private _DisplayIdMode3 As String = "-3"

    ''' <summary>
    ''' 画面遷移モード
    ''' </summary>
    ''' <remarks></remarks>
    Private _MenuIdMode As String = ""

    ''' <summary>
    ''' 問題番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _DisplayIdMode As String = ""

    ''' <summary>
    ''' 問題番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionNumber As Integer = 0

    ''' <summary>
    ''' 試験回数
    ''' </summary>
    ''' <remarks></remarks>
    Private _TestCount As Constant.TestCounts

    ''' <summary>
    ''' データバンカー
    ''' </summary>
    ''' <remarks></remarks>
    Private dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="questionNumber">問題番号ｖ</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal testCount As Integer, ByVal questionNumber As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        _TestCount = testCount
        _QuestionNumber = questionNumber
    End Sub
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

    End Sub
    ''' <summary>
    ''' ボタン制御
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ButtonControl()
        Try
            Dim QSize As System.Drawing.Size
            Select Case dataBanker("FROMFORM")
                Case "TG12"
                    '前へ、次へ
                    Me.btnNext.Visible = True
                    Me.btmPre.Visible = True
                    '閉じる
                    Me.btnBack.Visible = False
                    Me.btnExit.Visible = True
                    _DisplayIdMode = _DisplayIdMode1
                    _MenuIdMode = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM
                    Me.DialogMode = False
                Case "KG02"
                    '前へ、次へ
                    Me.btnNext.Visible = True
                    Me.btmPre.Visible = True
                    '閉じる
                    Me.btnBack.Visible = True
                    Me.btnExit.Visible = False
                    _DisplayIdMode = _DisplayIdMode1
                Case "KG08"
                    '前へ、次へ
                    Me.btnNext.Visible = False
                    Me.btmPre.Visible = False
                    QSize = Me.SplBase.Size
                    QSize.Height += 40
                    Me.SplBase.Size = QSize

                    '閉じる
                    Me.btnBack.Visible = False
                    Me.btnExit.Visible = True
                    _DisplayIdMode = _DisplayIdMode2
                    Me.DialogMode = False
                Case "KG13"
                    '前へ、次へ
                    Me.btnNext.Visible = False
                    Me.btmPre.Visible = False
                    QSize = Me.SplBase.Size
                    QSize.Height += 40
                    Me.SplBase.Size = QSize

                    '閉じる
                    Me.btnBack.Visible = False
                    Me.btnExit.Visible = True
                    _DisplayIdMode = _DisplayIdMode3
                    Me.DialogMode = False
                Case Else               'それ以外
                    Me.btnNext.Enabled = True
                    Me.btmPre.Enabled = True
                    _DisplayIdMode = _DisplayIdMode1
            End Select
            SplQuestion.Panel2Collapsed = True
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 現在の問題を指定の問題番号に更新します。
    ''' </summary>
    ''' <param name="questionNumber">更新する問題番号</param>
    ''' <remarks></remarks>
    Private Sub UpdateQuestion(ByVal questionNumber As Integer)
        Try
            _QuestionNumber = questionNumber
            ShowQuestion(questionNumber, _TestCount)
            ShowAnswer(questionNumber, _TestCount)
            ShowComment(questionNumber, _TestCount)
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#Region "問題関連"
    ''' <summary>
    ''' 指定の問題を表示します。
    ''' </summary>
    ''' <param name="questionNumber">表示する問題番号</param>
    ''' <param name="testCount">試験回数</param>
    ''' <remarks></remarks>
    Private Sub ShowQuestion(ByVal questionNumber As Integer, ByVal testCount As Constant.TestCounts)
        Try
            Dim questionDefineContainer As QuestionDefineContainer = GDataManager.GetInstance().QuestionDefineContainer
            Dim questionDefine As QuestionDefine = questionDefineContainer(questionNumber)

            If questionDefine.IsMiddleQuestion Then
                ShowMiddleQuestion(questionDefine, testCount)
            Else
                ShowSmallQuestion(questionDefine, testCount)
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#Region "小問関連"
    ''' <summary>
    ''' 指定の問題番号、試験回数で小問を表示します。
    ''' </summary>
    ''' <param name="questionDefine">問題定義オブジェクト</param>
    ''' <param name="testCount">試験回数</param>
    ''' <remarks></remarks>
    Private Sub ShowSmallQuestion(ByVal questionDefine As QuestionDefine, ByVal testCount As Constant.TestCounts)
        Try
            SetSamllQuestionViewMode()

            lblQuestionHeader.Text = String.Format("問{0}〔{1}〕", questionDefine.QuestionNumber, questionDefine.LargeCategoryName)
            Me.Text = "問別解説画面（小問形式）"

            Dim fileName As String = String.Empty
            Select Case testCount
                Case Constant.TestCounts.FirstTest
                    fileName = questionDefine.FirstSmallQuestionFilePath
                Case Constant.TestCounts.SecondTest
                    fileName = questionDefine.SecondSmallQuestionFilePath
            End Select

            webQuestionTop.Url = New System.Uri(fileName)
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 小問用表示モードの設定を行います。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSamllQuestionViewMode()
        Try
            If SplQuestion.Panel2Collapsed = False Then
                SplQuestion.Panel2Collapsed = True
                SplQuestion.SplitterDistance = SplQuestion.Height
                webQuestionBottom.Visible = False
            End If
            If _MenuIdMode = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                lblBottomCode.Text = _DisplayIdSYSSmall
            Else
                lblBottomCode.Text = _DisplayIdSmall & _DisplayIdMode
            End If
            lblBottomName.Text = DISPLAY_NAME_SMALL
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "中問関連"

    ''' <summary>
    ''' 指定の問題番号、試験回数で中問を表示します。
    ''' </summary>
    ''' <param name="questionDefine">問題定義オブジェクト</param>
    ''' <param name="testCount">試験回数</param>
    ''' <remarks></remarks>
    Private Sub ShowMiddleQuestion(ByVal questionDefine As QuestionDefine, ByVal testCount As Constant.TestCounts)
        Try
            SetMiddleQuestionViewMode()

            lblQuestionHeader.Text = String.Format("中問{0}/問{1}〔{2}〕", questionDefine.MiddleQuestionNumber, questionDefine.QuestionNumber, questionDefine.LargeCategoryName)
            Me.Text = "問別解説画面（中問形式）"

            webQuestionTop.Url = New Uri(questionDefine.MiddleQuestionFilePath)

            Dim fileName As String = String.Empty
            Select Case testCount
                Case Constant.TestCounts.FirstTest
                    fileName = questionDefine.FirstSmallQuestionFilePath
                Case Constant.TestCounts.SecondTest
                    fileName = questionDefine.SecondSmallQuestionFilePath
            End Select

            webQuestionBottom.Url = New System.Uri(fileName)

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

    ''' <summary>
    ''' 中問用表示モードの設定を行います。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMiddleQuestionViewMode()
        Try
            If SplQuestion.Panel2Collapsed Then
                SplQuestion.Panel2Collapsed = False
                SplQuestion.SplitterDistance = SplQuestion.Height / 2
                webQuestionBottom.Visible = True
            End If
            If _MenuIdMode = CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                lblBottomCode.Text = _DisplayIdSYSMiddle
            Else
                lblBottomCode.Text = _DisplayIdMiddle & _DisplayIdMode
            End If
            lblBottomName.Text = DISPLAY_NAME_MIDDLE
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region
#End Region

#Region "解答関連"
    ''' <summary>
    ''' 解答(ユーザの解答＋正解答)の表示を行います。
    ''' </summary>
    ''' <param name="questionNumber">問題番号</param>
    ''' <param name="testCount">試験回数</param>
    ''' <remarks></remarks>
    Private Sub ShowAnswer(ByVal questionNumber As Integer, ByVal testCount As Integer)
        Try
            Dim testResultDetail As Common.TestResultDetail = GDataManager.GetInstance().TestResultDetail
            Dim questionDefine As QuestionDefine = GDataManager.GetInstance().QuestionDefineContainer(questionNumber)

            lblCorrectAnswer.Text = String.Empty

            If questionDefine Is Nothing = False Then
                lblCorrectAnswer.Text = questionDefine.FirstAnswer
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' TOP画面に戻ります。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowTopForm()
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        dataBanker("FROMFORM") = lblBottomCode.Text
        dataBanker("TOFORM") = DISPLAY_ID_JG01
        '画面を閉じる
        Me.Close()
    End Sub

#End Region

#Region "解説関連"
    ''' <summary>
    ''' 指定の問題の解説を表示します。
    ''' </summary>
    ''' <param name="questionNumber">表示する問題番号</param>
    ''' <param name="testCount">試験回数</param>
    ''' <remarks></remarks>
    Private Sub ShowComment(ByVal questionNumber As Integer, ByVal testCount As Integer)
        Try
            Dim questionDefineContainer As QuestionDefineContainer = GDataManager.GetInstance().QuestionDefineContainer
            Dim questionDefine As QuestionDefine = questionDefineContainer(questionNumber)

            Dim fileName As String = String.Empty
            Select Case testCount
                Case Constant.TestCounts.FirstTest
                    fileName = questionDefine.FirstCommentFilePath
                Case Constant.TestCounts.SecondTest
                    fileName = questionDefine.SecondCommentFilePath
            End Select

            webComment.Url = New System.Uri(fileName)
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region
#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmQuestionComment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Refresh()
            Show()
            
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance

            webQuestionTop.AllowNavigation = True
            webQuestionBottom.AllowNavigation = True
            webComment.AllowNavigation = True

            'ボタン制御
            Call ButtonControl()
            '表示倍率は100%スタート
            Me.cboDisplayMagnification.SelectedIndex = 0

            UpdateQuestion(_QuestionNumber)

            'ボタン制御
            controlButtonPreAndNext()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 閉じるボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Try
            dataBanker("TOFORM") = dataBanker("FROMFORM")
            dataBanker("FROMFORM") = lblBottomCode.Text
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 管理者メインメニューへ戻るボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            dataBanker("FROMFORM") = lblBottomCode.Text
            dataBanker("TOFORM") = "KG01"
            Me.Close()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 次の問題へボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            If _QuestionNumber = 100 Then
                _QuestionNumber = 0
            End If
            UpdateQuestion(_QuestionNumber + 1)

            'ボタン制御
            controlButtonPreAndNext()

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 前の問題へボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btmPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmPre.Click
        Try
            If _QuestionNumber = 1 Then
                _QuestionNumber = 101
            End If
            UpdateQuestion(_QuestionNumber - 1)
            'ボタン制御
            controlButtonPreAndNext()

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 背景色変更ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click
        Try
            '色設定ダイアログ表示
            Dim cd As New ColorDialog()
            If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '表示背景色設定
                Call webQuestionTop.DocumentBackColor(cd.Color)
                Call webQuestionBottom.DocumentBackColor(cd.Color)
                lblTitle2.BackColor = cd.Color
                lblCorrectAnswer.BackColor = cd.Color
                webComment.DocumentBackColor(cd.Color)
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 文字色変更ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCodeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodeColor.Click
        Try
            '色設定ダイアログ表示
            Dim cd As New ColorDialog()
            If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '表示背景色設定
                Call webQuestionTop.DocumentCodeColor(cd.Color)
                Call webQuestionBottom.DocumentCodeColor(cd.Color)
                lblTitle2.ForeColor = cd.Color
                lblCorrectAnswer.ForeColor = cd.Color
                webComment.DocumentCodeColor(cd.Color)
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 表示倍率変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboDisplayMagnification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDisplayMagnification.SelectedIndexChanged
        Try
            Call webQuestionTop.DisplayMagnification(cboDisplayMagnification.Text)
            Call webQuestionBottom.DisplayMagnification(cboDisplayMagnification.Text)
            Call webComment.DisplayMagnification(cboDisplayMagnification.Text)

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
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & resultCode)
            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 前、後の問題へ戻るボタンの制御
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub controlButtonPreAndNext()
        'Dim questionDefineContainer As QuestionDefineContainer = GDataManager.GetInstance().QuestionDefineContainer
        'btmPre.Enabled = IIf(_QuestionNumber <= 1, False, True)
        'btnNext.Enabled = IIf(_QuestionNumber = questionDefineContainer.QuestionDefineMap.Count, False, True)
    End Sub

    ''' <summary>
    ''' フォームクロージングイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmQuestionShow_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            webQuestionTop.Dispose()
            webQuestionBottom.Dispose()
            webComment.Dispose()
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region


End Class