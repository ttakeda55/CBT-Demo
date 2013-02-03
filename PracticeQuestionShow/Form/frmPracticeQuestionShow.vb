''' <summary>
''' 問別解説フォーム(小問、中問共用)
''' </summary>
''' <remarks></remarks>
Public Class frmPracticeQuestionShow

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const DISPLAY_ID_JG01 As String = "JG01"
#End Region

#Region "----- メンバ変数 -----"
    ''' <remarks></remarks>
    ''' <summary>演習問題コレクションのインデックス</summary>
    Private _questionIndex As Integer = 0
    ''' <summary>演習問題コード</summary>
    Private _practiceQuestionCode As String = String.Empty
    ''' <summary>演習中問番号</summary>
    Private _practiceMiddleQuestionCode As String = ""
    ''' <summary>演習中問番号情報</summary>
    Private _htPracticeMiddleQuestionCharacter As New Hashtable
    ''' <summary>中問かどうか</summary>
    Private _IsMiddleQuestion As Boolean = False
    ''' <summary>演習問題コレクション</summary>
    Private _praciticeQuestionInfoCollection As PraciticeQuestionInfoCollection
    ''' <summary>問番号を表示するかどうか</summary>
    Private _showQuestionNoFlg As Boolean = False
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    Private _practiceQuestionBankCollection As Common.VetnurseQuestionBankCollection
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
            logger.Start()
            Refresh()
            Show()
            '問題ファイルを確認する
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            If dataBanker("MENUMODE") <> CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                checkPracticeQuestion(_questionIndex, _praciticeQuestionInfoCollection)
            End If

            webQuestionTop.AllowNavigation = True
            webQuestionBottom.AllowNavigation = True
            webComment.AllowNavigation = True

            Me.DialogMode = False

            '表示倍率は100%スタート
            Me.cboDisplayMagnification.SelectedIndex = 0

            '問題を表示する
            displayPracticeQuestion(_questionIndex, _praciticeQuestionInfoCollection)

            logger.End()
        Catch ex As System.Net.WebException
            Common.Message.MessageShow("E043")
            Close()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Close()
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
            logger.Start()
            QuestionDefineContainer.GetInstance.Remove()
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
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
            logger.Start()
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
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
            logger.Start()
            '動画停止
            wmpMovie.Ctlcontrols.stop()
            wmpMovie.URL = ""
            _questionIndex = _questionIndex + 1

            '問題ファイルを確認する
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            If dataBanker("MENUMODE") <> CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                checkPracticeQuestion(_questionIndex, _praciticeQuestionInfoCollection)
            End If

            '問題を表示する
            displayPracticeQuestion(_questionIndex, _praciticeQuestionInfoCollection)

            logger.End()
        Catch ex As System.Net.WebException
            Common.Message.MessageShow("E043")
            Close()
        Catch ex As Exception
            logger.Error(ex)
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
            logger.Start()
            wmpMovie.Ctlcontrols.stop()
            wmpMovie.URL = ""
            _questionIndex = _questionIndex - 1

            '問題ファイルを確認する
            Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            If dataBanker("MENUMODE") <> CST.CBT.eIPSTA.Common.Constant.CST_MENUMODE_SYSTEM Then
                checkPracticeQuestion(_questionIndex, _praciticeQuestionInfoCollection)
            End If

            '問題を表示する
            displayPracticeQuestion(_questionIndex, _praciticeQuestionInfoCollection)

            logger.End()
        Catch ex As System.Net.WebException
            Common.Message.MessageShow("E043")
            Close()
        Catch ex As Exception
            logger.Error(ex)
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
            logger.Start()
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & resultCode)
            End Select
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' フォームクロージングイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmQuestionShow_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            logger.Start()
            webQuestionTop.Dispose()
            webQuestionBottom.Dispose()
            webComment.Dispose()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="questionIndex"></param>
    ''' <param name="praciticeQuestionInfoCollection"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal questionIndex As Integer, ByVal praciticeQuestionInfoCollection As PraciticeQuestionInfoCollection, Optional ByVal showQuestionNoFlg As Boolean = False)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        _praciticeQuestionInfoCollection = praciticeQuestionInfoCollection

        _questionIndex = questionIndex

        _showQuestionNoFlg = showQuestionNoFlg

        '中問コードの設定
        If showQuestionNoFlg Then
            For Each PraciticeQuestionInfo As PraciticeQuestionInfo In praciticeQuestionInfoCollection
                Select Case PraciticeQuestionInfo.QuestionNo
                    Case 85, 86, 87, 88
                        _htPracticeMiddleQuestionCharacter(PraciticeQuestionInfo.MiddleQuestionCode) = "Ａ"
                    Case 89, 90, 91, 92
                        _htPracticeMiddleQuestionCharacter(PraciticeQuestionInfo.MiddleQuestionCode) = "Ｂ"
                    Case 93, 94, 95, 96
                        _htPracticeMiddleQuestionCharacter(PraciticeQuestionInfo.MiddleQuestionCode) = "Ｃ"
                    Case 97, 98, 99, 100
                        _htPracticeMiddleQuestionCharacter(PraciticeQuestionInfo.MiddleQuestionCode) = "Ｄ"
                End Select
            Next
        End If

    End Sub

    ''' <summary>
    ''' 前、後の問題へ戻るボタンの制御
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub controlButtonPreAndNext()
        btmPre.Enabled = IIf(_questionIndex <= 0, False, True)
        btnNext.Enabled = IIf(_questionIndex = _praciticeQuestionInfoCollection.Count - 1, False, True)
    End Sub

    ''' <summary>
    ''' 現在の問題を指定の問題番号に更新します。
    ''' </summary>
    ''' <param name="QuestionCode">更新する問題番号</param>
    ''' <remarks></remarks>
    Private Sub UpdateQuestion(ByVal QuestionCode As String)
        _practiceQuestionCode = QuestionCode
        ShowQuestion(QuestionCode)
        ShowAnswer(QuestionCode)
        'ShowComment(QuestionCode)
    End Sub

    ''' <summary>
    ''' 表示する問題の情報を設定する
    ''' </summary>
    ''' <param name="questionIndex"></param>
    ''' <param name="praciticeQuestionInfoCollection"></param>
    ''' <remarks></remarks>
    Private Sub setDisplayPracticeQuestion(questionIndex As Integer, praciticeQuestionInfoCollection As PraciticeQuestionInfoCollection)
        _practiceQuestionCode = praciticeQuestionInfoCollection.Item(questionIndex).QuestionCode
        _practiceMiddleQuestionCode = praciticeQuestionInfoCollection.Item(questionIndex).MiddleQuestionCode
        _IsMiddleQuestion = praciticeQuestionInfoCollection.Item(questionIndex).IsMiddleQuestion
    End Sub

    ''' <summary>
    ''' 問題を表示する
    ''' </summary>
    ''' <param name="questionIndex">表示する演習問題コレクションのインデックス</param>
    ''' <param name="praciticeQuestionInfoCollection">演習問題コレクション</param>
    ''' <remarks></remarks>
    Private Sub displayPracticeQuestion(ByVal questionIndex As Integer, ByVal praciticeQuestionInfoCollection As PracticeQuestionShow.PraciticeQuestionInfoCollection)
        '表示する問題を設定
        setDisplayPracticeQuestion(questionIndex, praciticeQuestionInfoCollection)

        '問題ファイル作成
        If QuestionDefineContainer.GetInstance()(_practiceQuestionCode) Is Nothing Then
            makePracticeQuestion(_practiceQuestionCode)
        End If

        '問題表示
        UpdateQuestion(_practiceQuestionCode)

        'ボタン制御
        controlButtonPreAndNext()
    End Sub

    ''' <summary>
    ''' 問題ファイルを確認する
    ''' </summary>
    ''' <param name="questionIndex"></param>
    ''' <param name="praciticeQuestionInfoCollection"></param>
    ''' <remarks>問題ファイルを確認し、なければダウンロードする</remarks>
    Private Sub checkPracticeQuestion(ByVal questionIndex As Integer, ByVal praciticeQuestionInfoCollection As PracticeQuestionShow.PraciticeQuestionInfoCollection)

        Dim fileName As String = String.Empty
        If Not praciticeQuestionInfoCollection.Item(questionIndex).IsMiddleQuestion Then
            fileName = Common.Constant.CST_PRACTICEQUESTION_FILENAME & praciticeQuestionInfoCollection.Item(questionIndex).QuestionCode
        Else
            fileName = Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME & praciticeQuestionInfoCollection.Item(questionIndex).MiddleQuestionCode
        End If

        If IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
            Exit Sub
        End If

        If CBTCommon.DataBanker.GetInstance.Item("DOWNLOAD_FLG") Then
            Dim contents As Byte() = Nothing
            WebServiceWrapper.GetInstance().FileDownLoad_DATA(fileName, contents)
            IO.File.WriteAllBytes(Common.Constant.GetTempPath & fileName, contents)
        End If

    End Sub

#Region "問題関連"

    ''' <summary>
    ''' 指定の問題を作成する。
    ''' </summary>
    ''' <param name="practiceQuestionCode">表示する問題番号</param>
    ''' <remarks></remarks>
    Private Sub makePracticeQuestion(ByVal practiceQuestionCode As String)
        If _IsMiddleQuestion Then
            ReadQuestionFile(Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME & _practiceMiddleQuestionCode)
        Else
            ReadQuestionFile(Common.Constant.CST_PRACTICEQUESTION_FILENAME & practiceQuestionCode)
        End If

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
    ''' 指定の問題を表示します。
    ''' </summary>
    ''' <param name="questionCode">表示する問題番号</param>
    ''' <remarks></remarks>
    Private Sub ShowQuestion(ByVal questionCode As String)
        Dim question As Common.VetNurseQuestionBank = _practiceQuestionBankCollection.Item(0)
        ShowSmallQuestion(question)
    End Sub

#Region "小問関連"
    ''' <summary>
    ''' 指定の問題番号、試験回数で小問を表示します。
    ''' </summary>
    ''' <param name="questionDefine">問題定義オブジェクト</param>
    ''' <remarks></remarks>
    Private Sub ShowSmallQuestion(ByVal questionDefine As Common.VetNurseQuestionBank)
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        If questionDefine.IsMovie Then
            SetMovieQuestionViewMode()
            wmpMovie.URL = questionDefine.WriteMovie()
        Else
            SetSamllQuestionViewMode()
        End If


        lblQuestionCodeLeft.Text = questionDefine.QuestionCode
        lblQuestionCodeRight.Visible = False
        If _showQuestionNoFlg Then lblQuestion.Text = "問" & (_praciticeQuestionInfoCollection.Item(_questionIndex).QuestionNo)
        Me.Text = "問題確認画面"

        Dim fileName As String = String.Empty
        fileName = questionDefine.CreateQuestion()

        webQuestionTop.url = New System.Uri(fileName)
    End Sub

    ''' <summary>
    ''' 小問用表示モードの設定を行います。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMovieQuestionViewMode()
        'If SplQuestion.Panel2Collapsed = False Then
        'SplQuestion.Panel2Collapsed = True
        SplQuestion.SplitterDistance = SplQuestion.Height / 2
        webQuestionBottom.Visible = False
        webQuestionTop.Dock = DockStyle.Fill
        wmpMovie.Dock = DockStyle.Fill
        'End If
    End Sub

    ''' <summary>
    ''' 小問用表示モードの設定を行います。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSamllQuestionViewMode()
        'If SplQuestion.Panel2Collapsed = False Then
        'SplQuestion.Panel2Collapsed = True
        SplQuestion.SplitterDistance = SplQuestion.Height
        webQuestionBottom.Visible = False
        webQuestionTop.Dock = DockStyle.Fill
        'End If
    End Sub
#End Region
#End Region

#Region "解答関連"
    ''' <summary>
    ''' 解答(ユーザの解答＋正解答)の表示を行います。
    ''' </summary>
    ''' <param name="questionCode">問題番号</param>
    ''' <remarks></remarks>
    Private Sub ShowAnswer(ByVal questionCode As String)
        Dim questionDefine As Common.VetNurseQuestionBank = _practiceQuestionBankCollection.Item(0)

        lblCorrectAnswer.Text = String.Empty

        If questionDefine Is Nothing = False Then
            lblCorrectAnswer.Text = questionDefine.Ansewr
        End If
    End Sub

#End Region

#Region "解説関連"
    ''' <summary>
    ''' 指定の問題の解説を表示します。
    ''' </summary>
    ''' <param name="questionCode">表示する問題番号</param>
    ''' <remarks></remarks>
    Private Sub ShowComment(ByVal questionCode As String)
        Dim questionDefineContainer As QuestionDefineContainer = questionDefineContainer.GetInstance
        Dim questionDefine As QuestionDefine = questionDefineContainer(questionCode)

        Dim fileName As String = String.Empty
        fileName = questionDefine.CommentFilePath

        webComment.url = New System.Uri(fileName)
    End Sub
#End Region
#End Region

End Class