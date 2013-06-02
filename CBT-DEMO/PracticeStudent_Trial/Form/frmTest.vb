''' <summary>
''' 試験実施フォーム(小問、中問共用)(JS19,JS22,JS25,JS30,JS31)
''' </summary>
''' <remarks></remarks>
Public Class frmTest

#Region "----- 定数 ----- "
    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "問題演習"
    ' ''' <summary>小問逐次演習問題用画面表示ID</summary>
    'Private Const DISPLAY_ID_SMALL_SERIAL As String = "JG19"
    ' ''' <summary>小問逐次演習問題用画面表示名</summary>
    'Private Const DISPLAY_NAME_SMALL_SERIAL As String = "小問逐次演習問題画面"
    ' ''' <summary>中問逐次演習問題用画面表示ID</summary>
    'Private Const DISPLAY_ID_MIDDLE_SERIAL As String = "JG22"
    ' ''' <summary>中問逐次演習問題用画面表示名</summary>
    'Private Const DISPLAY_NAME_MIDDLE_SERIAL As String = "中問逐次演習問題画面"
    ' ''' <summary>小テスト問題用画面表示ID</summary>
    'Private Const DISPLAY_ID_MINI As String = "JG25"
    ' ''' <summary>小テスト問題用画面表示名</summary>
    'Private Const DISPLAY_NAME_MINI As String = "小テスト問題画面"
    ' ''' <summary>総合テスト問題(小問)用画面表示ID</summary>
    'Private Const DISPLAY_ID_SMALL_SYNTHESI As String = "JG30"
    ' ''' <summary>総合テスト問題(小問)用画面表示名</summary>
    'Private Const DISPLAY_NAME_SMALL_SYNTHESI As String = "テスト問題画面（小問）"
    ' ''' <summary>総合テスト問題(中問)用画面表示ID</summary>
    'Private Const DISPLAY_ID_MIDDLE_SYNTHESI As String = "JG31"
    ' ''' <summary>総合テスト問題(中問)用画面表示名</summary>
    'Private Const DISPLAY_NAME_MIDDLE_SYNTHESI As String = "テスト問題画面（中問）"

    ''' <summary>問題読み込み処理の返り値</summary>
    Public Enum CheckReadCompleteResult As Integer
        ''' <summary>読み込み成功</summary>
        ReadTrue = 0
        ''' <summary>読み込み失敗</summary>
        ReadError = 1
        ''' <summary>読み込み中</summary>
        ReadNot = 2
    End Enum
 
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
    ''' <summary>小問用画面表示ID</summary>
    Private _DisplayIdSmall As String = ""
    ''' <summary>中問用画面表示ID</summary>
    Private _DisplayIdMiddle As String = ""
    ''' <summary>小問用画面表示名</summary>
    Private _DisplayNameSmall As String = ""
    ''' <summary>中問用画面表示名</summary>
    Private _DisplayNameMiddle As String = ""
    ''' <summary>問題番号</summary>
    Private _QuestionNumber As Integer = 0
    ''' <summary>問題コード</summary>
    Private _QuestionCode As String = ""
    ''' <summary>ダウンロードのリスト</summary>
    Private _QuestionDownloadCodeList As New List(Of String)
    ''' <summary>結果データのリスト</summary>
    Private _ResultDataList As New List(Of String)
    ''' <summary>正解数</summary>
    Private _RightAnswer As Integer = 0
    ''' <summary>実施時間</summary>
    Private _StopWatch As Stopwatch
    ''' <summary>選択肢解答ラジオボタン</summary>
    Private _AnswerRadioButtons() As RadioButton
     ''' <summary>タブの選択変更イベントを無視するかどうか</summary>
    Private _IgnoreTabSelectIndexChangeEvent As Boolean
    ''' <summary>総合テスト見直し画面</summary>
    Private WithEvents _SynthesisTestReviewForm As frmReview = Nothing
    ''' <summary>現在表示中のサブフォームのリスト</summary>
    Private _SubFormList As New List(Of Form)
    ''' <summary>チェックボックス変更イベントを無視するかどうか</summary>
    Private _IsIgnoreCheckChangeEvent As Boolean
    ''' <summary>遷移先画面ID</summary>
    Private _ToDisplayId As String = ""
    ''' <summary>初期表示フラグ</summary>
    Private _QuestionViewFlg As Boolean = False
    ''' <summary>問題数</summary>
    Private _QuestionCount As Integer = 0
    ''' <summary>中問開始位置</summary>
    Private _MiddleQuestionStartNum As Integer = 0
    ''' <summary>最終中問開始位置</summary>
    Private _MiddleQuestionEndNum As Integer = 0
    ''' <summary>ダウンロード失敗メッセージ</summary>
    Private _DownloadFailedMessage As String = ""
    ''' <summary>ダウンロード強制終了フラグ</summary>
    Private _ForcedTerminationFlg As Boolean = False
    ''' <summary>ファイル読み込みチェックスレッドパラメーター１</summary>
    Private _checkParameter1 As String = ""
    ''' <summary>ファイル読み込みチェックスレッドパラメーター２</summary>
    Private _checkParameter2 As Boolean = False
    ''' <summary>ファイル読み込みチェック戻り値</summary>
    Private _checkRet As Integer = 0
    ''' <summary>ダウンロードメッセージ</summary>
    Private _downloadMsg As String = "ダウンロード中です。しばらくお待ちください。"
    ''' <summary>アップロードメッセージ</summary>
    Private _uploadMsg As String = "アップロード中です。しばらくお待ちください。"
    ''' <summary>アップロードファイルリスト</summary>
    Private _upFileList As New List(Of String)
    ''' <summary>アップロードファイル作成戻り値</summary>
    Private _CreateUploadFileRet As Boolean = False
    ''' <summary>
    ''' 残り時間
    ''' </summary>
    ''' <remarks></remarks>
    Private _RemainingTime As TimeSpan
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal questionNumber As Integer)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        rdbAnswer1.Text = Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(0)
        rdbAnswer2.Text = Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(1)
        rdbAnswer3.Text = Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(2)
        rdbAnswer4.Text = Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(3)
        rdbAnswer5.Text = Common.DataManager.GetInstance.ChoiceMark.GetChoiceMarkChar(4)
        _AnswerRadioButtons = {rdbAnswer1, rdbAnswer2, rdbAnswer3, rdbAnswer4, rdbAnswer5}

        ' 問題番号を取得
        _QuestionNumber = questionNumber

        ' コントロールの配置を設定する
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        _ToDisplayId = dataBanker("TOFORM")
        ' 総合テスト問題画面
        SetSynthesiQuestionControl()
        'For idx As Integer = DataManager.GetInstance.QuestionCodeList.Count - 1 To 0 Step -1
        '    If DataManager.GetInstance.QuestionCodeList.Item(idx).IsMiddleMainQuestion Then
        '        _MiddleQuestionEndNum = idx
        '        Exit For
        '    End If
        'Next

        ' コントロールの初期化
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        WindowState = FormWindowState.Maximized

        SetSmallQuestionViewMode(Nothing)

    End Sub

    ''' <summary>
    ''' 現在の問題を指定の問題番号に更新します。
    ''' </summary>
    ''' <param name="questionNumber">更新する問題番号</param>
    ''' <remarks></remarks>
    Private Sub UpdateQuestion(ByVal questionNumber As Integer)
        Dim ret As Boolean = True
        Try
            Dim nowQuestionNumber As Integer = _QuestionNumber

            _QuestionNumber = questionNumber
            ' 問題リストから問題コードを取得
            _QuestionCode = DataManager.GetInstance.QuestionCodeList.Item(_QuestionNumber).QuestionCode

            ' 解答状況を更新
            Dim UpdateResultStatusdlg As New UpdateResultStatusDelegate(AddressOf UpdateResultStatus)
            Me.Invoke(UpdateResultStatusdlg, New Object() {_QuestionCode})

            ' 問題を表示
            Dim ShowQuestiondlg As New ShowQuestionDelegate(AddressOf ShowQuestion)
            Me.Invoke(ShowQuestiondlg, New Object() {_QuestionCode})

            ' ボタンの有効/無効を設定
            Dim SetButtonEnabledlg As New SetButtonEnableDelegate(AddressOf SetButtonEnable)
            Me.Invoke(SetButtonEnabledlg, New Object() {})

            ' ストップウォッチスタート
            _StopWatch.Start()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 指定の問題ファイル読み込みが完了しているか確認します。
    ''' </summary>
    ''' <param name="questionNumber"></param>
    ''' <remarks></remarks>
    Private Function CheckReadComplete(ByVal questionNumber As Integer, Optional ByVal flgReview As Boolean = False) As Integer
        Dim ret As Integer = CheckReadCompleteResult.ReadTrue
        Dim isCheck As Boolean = False
        Dim state As Integer = 0

        Try
            While isCheck = False
                Dim questionDefineContainer As QuestionDefineContainer = DataManager.GetInstance.PracticeQuestionDefineContainer
                Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(questionNumber)
                Dim dlg As New ShowProcessMessageDelegate(AddressOf ShowProcessMessage)

                ' 終了ボタンがクリックされた場合、スレッドを終了する
                If _ForcedTerminationFlg Then
                    Exit While
                End If

                state = questionCodeDefine.DownloadState
                If state = questionCodeDefine.DownloadStateIndex.FixDownload Then
                    If IsNothing(questionDefineContainer) = False AndAlso IsNothing(questionDefineContainer(questionCodeDefine.QuestionCode)) = False Then
                        ' ファイルの読み込みが完了している場合
                        isCheck = True
                        Me.Invoke(dlg, New Object() {False, _downloadMsg})
                        Exit While
                    End If
                ElseIf state = questionCodeDefine.DownloadStateIndex.ErrorDownload Then
                    ' ダウンロードに失敗している場合
                    ret = CheckReadCompleteResult.ReadError
                    isCheck = True
                    Me.Invoke(dlg, New Object() {False, _downloadMsg})
                    Exit While

                ElseIf flgReview AndAlso state = questionCodeDefine.DownloadStateIndex.NotDownload Then
                    ' メッセージ表示
                    '2012/06/07 cst del s
                    'Common.Message.MessageShow("I" & Constant.InformationMessageCode.DownLoadWhileInfo)
                    '2012/06/07 cst del e
                    ret = CheckReadCompleteResult.ReadNot
                    Me.Invoke(dlg, New Object() {False, _downloadMsg})
                    Exit While
                End If
                Me.Invoke(dlg, New Object() {True, _downloadMsg})
                Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)
            End While
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            '2012/06/07 cst del s
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '2012/06/07 cst del e
            ret = CheckReadCompleteResult.ReadError
        End Try
        Return ret
    End Function

    Delegate Sub UpdateResultStatusDelegate(ByVal questionCode As String)
    ''' <summary>
    ''' 指定の問題番号の解答済みデータを元に、画面の解答状況を更新します。
    ''' </summary>
    ''' <param name="questionCode"></param>
    ''' <remarks></remarks>
    Private Sub UpdateResultStatus(ByVal questionCode)
        Try
            '指定の問題番号でチェック状況の復元
            Dim resultData As ResultData = DataManager.GetInstance.ResultDataContainer(questionCode)
            If resultData Is Nothing = False Then
                chkReview.Checked = resultData.Check
                For Each answerRadioButton As RadioButton In _AnswerRadioButtons
                    If answerRadioButton.Text = resultData.Answer Then
                        answerRadioButton.Checked = True
                    Else
                        answerRadioButton.Checked = False
                    End If
                Next
            Else
                '現在チェック状態のクリア
                ClearCheckStates()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 見直しチェック、ラジオボタンの選択状態をクリアします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearCheckStates()
        Try
            _IsIgnoreCheckChangeEvent = True
            chkReview.Checked = False
            For Each answerRadioButton As RadioButton In _AnswerRadioButtons
                answerRadioButton.Checked = False
            Next
            _IsIgnoreCheckChangeEvent = False
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Delegate Sub ShowQuestionDelegate(ByVal questionCode As String)
    ''' <summary>
    ''' 指定の問題を表示します。
    ''' </summary>
    ''' <param name="questionCode">表示する問題番号</param>
    ''' <remarks></remarks>
    Private Sub ShowQuestion(ByVal questionCode As String)
        Try
            Dim questionDefineContainer As QuestionDefineContainer = DataManager.GetInstance().PracticeQuestionDefineContainer
            Dim questionDefine As QuestionDefine = questionDefineContainer(questionCode)

            ShowSmallQuestion(questionDefine)
 
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Delegate Sub SetButtonEnableDelegate()
    ''' <summary>
    ''' ボタンの有効/無効を設定します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetButtonEnable()
        Try
            btmPre.Enabled = True
            btnNext.Enabled = True

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Delegate Sub SetControlEnableDelegate(ByVal flgEnable As Boolean)
    ''' <summary>
    ''' コントロールの有効を設定します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetControlEnable(ByVal flgEnable As Boolean)
        Try
            btnBackColor.Enabled = flgEnable             ' 背景色変更
            btnCodeColor.Enabled = flgEnable             ' 文字色変更
            cboDisplayMagnification.Enabled = flgEnable  ' 表示倍率
            btmPre.Enabled = flgEnable                   ' 前の問題へ
            btnReview.Enabled = flgEnable                ' 解答見直し
            btnNext.Enabled = flgEnable                  ' 次の問題へ
            'btnBack.Enabled = flgEnable                 ' XXX終了
            rdbAnswer1.Enabled = flgEnable               ' Ａ
            rdbAnswer2.Enabled = flgEnable               ' Ｂ
            rdbAnswer3.Enabled = flgEnable               ' Ｃ
            rdbAnswer4.Enabled = flgEnable               ' Ｄ
            rdbAnswer5.Enabled = flgEnable               ' Ｅ
            chkReview.Enabled = flgEnable                ' 見直しチェック
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#Region "小問問題関連"
    ''' <summary>
    ''' 指定の問題番号、試験回数で小問を表示します。
    ''' </summary>
    ''' <param name="questionDefine">問題定義オブジェクト</param>
    ''' <remarks></remarks>
    Private Sub ShowSmallQuestion(ByVal questionDefine As QuestionDefine)
        Try
            SetSmallQuestionViewMode(questionDefine)

            ' 問題番号を表示する
            lblQuestionHeader.Text = String.Format("問{0}", _QuestionNumber + 1)

            ' 総合テスト(中問)のみで表示されるlblQuestionCode2を非表示にする
            'If _ToDisplayId = DISPLAY_ID_SMALL_SYNTHESI Then
            '    lblQuestionCode2.Visible = False
            'End If

            ' 問題IDを表示する
            lblQuestionCode.Text = _QuestionCode

            Dim fileName As String = String.Empty
            fileName = questionDefine.SmallQuestionFilePath

            ' 問題を表示する
            webQuestionSingle.url = New System.Uri(fileName)

            '動画を表示
            If questionDefine.QuestionOrignal.IsMovie Then
                wmpMovie.URL = questionDefine.QuestionOrignal.WriteMovie(False)
                wmpMovie.Ctlcontrols.play()
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 小問問題用表示モードの設定を行います。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSmallQuestionViewMode(ByVal questionDefine As QuestionDefine)
        Try
            If SplQuestion.Panel2Collapsed = False Then
                SplQuestion.Panel2Collapsed = True
                SplQuestion.SplitterDistance = SplQuestion.Size.Width
            End If

            If Not questionDefine Is Nothing AndAlso questionDefine.QuestionOrignal.IsMovie Then
                SplQuestion.Panel2Collapsed = False
                SplQuestion.SplitterDistance = SplQuestion.Size.Width / 2
            End If
            wmpMovie.Dock = DockStyle.Fill
            lblBottomCode.Text = _DisplayIdSmall
            lblBottomName.Text = _DisplayNameSmall
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

    ''' <summary>
    ''' 総合テスト問題用コントロールの設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSynthesiQuestionControl()
        Try
            '_DisplayIdSmall = DISPLAY_ID_SMALL_SYNTHESI
            '_DisplayIdMiddle = DISPLAY_ID_MIDDLE_SYNTHESI
            '_DisplayNameSmall = DISPLAY_NAME_SMALL_SYNTHESI
            '_DisplayNameMiddle = DISPLAY_NAME_MIDDLE_SYNTHESI
            btnBack.Text = "テスト終了"

            Me.MailLabel.Visible = False        ' メール
            Me.UserSetLabel.Visible = False     ' ユーザ設定
            Me.HelpLabel.Visible = False        ' ヘルプ
            Me.LogoutLabel.Visible = False      ' ログアウト

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 現在チェックしている解答データを生成します。
    ''' </summary>
    ''' <returns>現在チェックしている解答データ</returns>
    ''' <remarks></remarks>
    Private Function CreateResultData() As ResultData
        Dim resultData As New ResultData

        Try
            resultData.Check = chkReview.Checked
            resultData.Answer = GetAnswerString()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return resultData
    End Function

    ''' <summary>
    ''' 現在選択されている解答文字列を取得します。
    ''' 選択されていない場合は、空文字
    ''' </summary>
    ''' <returns>現在選択されている解答文字列</returns>
    ''' <remarks></remarks>
    Private Function GetAnswerString() As String

        Dim answerString As String = String.Empty

        Try
            For Each answerRadioButton As RadioButton In _AnswerRadioButtons
                If answerRadioButton.Checked Then
                    answerString = answerRadioButton.Text
                    Exit For
                End If
            Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return answerString
    End Function

    ''' <summary>
    ''' テストを終了します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EndTest()
        Try
            ' テスト実行時間
            _StopWatch.Stop() ' ストップウォッチストップ
            Dim testTime As TimeSpan = _StopWatch.Elapsed
            RemainingTimer.Enabled = False
            Dim dlg As New ShowProcessMessageDelegate(AddressOf ShowProcessMessage)
            Me.Invoke(dlg, New Object() {True, _uploadMsg})
            ' コントロールの設定
            Me.btnBack.Enabled = False
            SetControlEnable(False)
            ' 最上位 z オーダー停止
            '2012/06/07 cst add s
            Me.TopMost = False
            '2012/06/07 cst add e

            Dim ret As Boolean = True

            _CreateUploadFileRet = CreateUpLoadFile(testTime, Constant.TestType.SynthesisResult)
            ' アップロード
            'Logout.UploadFile(_upFileList)
            bgwUpload.RunWorkerAsync()

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' アップロードファイル出力
    ''' </summary>
    ''' <param name="TestTime">実施時間</param>
    ''' <param name="TestType">テスト種別</param>
    ''' <returns>True:成功、False：失敗</returns>
    ''' <remarks></remarks>
    Private Function CreateUpLoadFile(ByVal TestTime As TimeSpan, ByVal TestType As Constant.TestType) As Boolean
        Dim blnRet As Boolean = False
        Dim fileName As String = ""
        Dim dt As DataTable = Nothing

        Try
            ' 実施時間のセット
            DataManager.GetInstance().TestTime = String.Format("{0:D02}:{1:D02}:{2:D02}", TestTime.Hours + TestTime.Days * 24, TestTime.Minutes, TestTime.Seconds)

            ' 受講者アップロードファイル出力
            blnRet = Common.Student.WriteXML(DataManager.GetInstance.Now, DataManager.GetInstance.StudentFileName)
            If Not blnRet Then Return blnRet

            Select Case TestType

                Case Constant.TestType.SynthesisResult      ' 総合テスト
                    ' ***　ヘッダ　***
                    ' ヘッダオブジェクトの追加
                    blnRet = DataManager.GetInstance.CreatePracticeResultDataTable(Constant.FileType.SynthesisResultHeader)
                    ' ヘッダデータテーブル取得
                    If blnRet Then
                        dt = DataManager.GetInstance.GetPracticeResultDataTable(Constant.FileType.SynthesisResultHeader)
                    End If
                    ' ヘッダアップロードファイルパスの取得
                    If Not IsNothing(dt) Then
                        fileName = CreateFileName(Constant.FileType.SynthesisResultHeader)
                    End If
                    ' ヘッダアップロードファイル出力
                    If fileName <> "" Then
                        Common.Serialize.DataTableToxml(dt, fileName)
                        'If IO.Directory.Exists(DataManager.GetInstance.TestResult_Share_Folder) Then
                        '    IO.File.Copy(Common.Constant.GetTempPath & fileName, DataManager.GetInstance.TestResult_Share_Folder & "\" & fileName, True)
                        'Else
                        '    MessageBox.Show("試験結果収集フォルダが見つかりません" & vbCrLf & "システム管理者に連絡してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                    End If

                    ' ***　明細　***
                    ' 明細オブジェクトの追加
                    blnRet = DataManager.GetInstance.CreatePracticeResultDataTable(Constant.FileType.SynthesisResultDetail)
                    ' 明細データテーブル取得
                    If blnRet Then
                        dt = DataManager.GetInstance.GetPracticeResultDataTable(Constant.FileType.SynthesisResultDetail)
                    End If
                    ' 明細アップロードファイルパスの取得
                    fileName = ""
                    If Not IsNothing(dt) Then
                        fileName = CreateFileName(Constant.FileType.SynthesisResultDetail)
                    End If
                    ' 明細アップロードファイル出力
                    If fileName <> "" Then
                        Common.Serialize.DataTableToxml(dt, fileName)
                        'If IO.Directory.Exists(DataManager.GetInstance.TestResult_Share_Folder) Then
                        '    IO.File.Copy(Common.Constant.GetTempPath & fileName, DataManager.GetInstance.TestResult_Share_Folder & "\" & fileName, True)
                        'End If
                    End If

            End Select

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            blnRet = False
        End Try
        Return blnRet
    End Function

    ''' <summary>
    ''' ファイルパス作成
    ''' </summary>
    ''' <param name="FileType">ファイル種別</param>
    ''' <returns>True:成功、False：失敗</returns>
    ''' <remarks></remarks>
    Private Function CreateFileName(ByVal FileType As Constant.FileType) As String
        Dim fileName As String = ""
        Dim BackupPath As String = ""
        Try
            Select Case FileType

                Case Constant.FileType.SynthesisResultHeader
                    ' 総合テスト結果_ヘッダ
                    If DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHeaderFileName = "" Then
                        fileName = Common.Constant.CST_SYNTHESISRESULTHEADER_FILENAME & DataManager.GetInstance().GroupCode & DataManager.GetInstance().UserId & Common.Constant.CST_EXTENSION_XML
                        DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHeaderFileName = fileName
                    Else
                        fileName = DataManager.GetInstance.SynthesisResultDefine.SynthesisResultHeaderFileName
                    End If

                Case Constant.FileType.SynthesisResultDetail
                    ' 総合テスト結果_明細
                    If DataManager.GetInstance.SynthesisResultDefine.SynthesisResultDetailFileName = "" Then
                        fileName = Common.Constant.CST_SYNTHESISRESULTDETAIL_FILENAME & DataManager.GetInstance().GroupCode & DataManager.GetInstance().UserId & Common.Constant.CST_EXTENSION_XML
                        DataManager.GetInstance.SynthesisResultDefine.SynthesisResultDetailFileName = fileName
                    Else
                        fileName = DataManager.GetInstance.SynthesisResultDefine.SynthesisResultDetailFileName
                    End If

            End Select
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            fileName = ""
        End Try
        Return fileName
    End Function

    ''' <summary>
    ''' 指定のフォームを開きます。
    ''' </summary>
    ''' <param name="form">開くフォーム</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ShowSubForm(ByVal form As Form) As DialogResult
        Dim dialogResult As DialogResult = Nothing
        Try
            _SubFormList.Add(form)
            '2012/06/07 cst chg s
            'dialogResult = form.ShowDialog()
            dialogResult = form.ShowDialog(Me)
            '2012/06/07 cst chg e
            _SubFormList.Remove(form)

            If DataManager.GetInstance.IsLogouting Then
                EndTest()
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return DialogResult
    End Function

    ''' <summary>
    ''' ファイルをダウンロードします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Function Download(ByVal downLoadCodeList As List(Of String)) As Boolean
        Dim ret As Boolean = False
        Dim qCode As String = ""
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd
        Try
            ' ダウンロードを実行
            'If DataManager.GetInstance.FileDownloadType = 1 Then
            '    ' 演習問題コレクションダウンロード
            '    ret = FileDownLoad.getQuestionCollection(downLoadCodeList)
            'Else
            '    ' 演習問題圧縮ファイルダウンロード
            '    ret = FileDownLoad.getQuestionZip(downLoadCodeList)
            'End If
            ret = True

            ' ダウンロードに成功した場合
            If ret = True Then
                For Each index As Integer In DataManager.GetInstance.QuestionCodeList.Keys
                    For Each fileName As String In downLoadCodeList
                        ' ファイル名から問題コードの取得
                        fileName = IO.Path.GetFileNameWithoutExtension(fileName)
                        If fileName.IndexOf(Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME) = 0 Then
                            qCode = fileName.Replace(Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME, "")
                        Else
                            qCode = fileName.Replace(Common.Constant.CST_PRACTICEQUESTION_FILENAME, "")
                        End If

                        If qCode = DataManager.GetInstance.QuestionCodeList.Item(index).QuestionCode Then
                            ' ダウンロードフラグをセット
                            DataManager.GetInstance.PracticeQuestionDefine.SetQuestionCodeDownLoad(qCode)
                            '' ダウンロード状態をセット
                            Call SetFixDownloadState(index)

                            ' 問題定義オブジェクト保持コンテナにセットする
                            errCode = DataManager.GetInstance.ReadQuestion(fileName)
                            If Not errCode = Constant.ResultCode.NormalEnd Then
                                ' 読み込みに失敗した場合、終了する
                                ret = False
                            End If
                            If Not ret = False AndAlso Not _QuestionViewFlg Then
                                ' 初期表示
                                Call Initialize()
                            End If
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            Throw ex
            ''ログ出力
            '_Log.Error(ex)
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' ダウンロード処理を呼び出します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CallDownLoadProcess(ByVal downLoadCodeList As List(Of String)) As Integer
        Dim cntFailed As Integer = 0
        Dim ret As Boolean = False
        While ret = False
            Try
                If _ForcedTerminationFlg Then
                    _DownloadFailedMessage = ""
                    Return 0
                End If
                If cntFailed = DataManager.GetInstance.FileDownloadFailed Then
                    ' 指定した回数分失敗した場合
                    Exit While
                ElseIf Download(downLoadCodeList) = True Then
                    ' ダウンロード処理に成功した場合
                    _DownloadFailedMessage = ""
                    ret = True
                    Exit While
                Else
                    ' 失敗回数の更新
                    cntFailed += 1
                End If
                Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)

            Catch exWeb As Web.Services.Protocols.SoapException
                ' WebServiceでの例外
                cntFailed += 1
                _Log.Error(exWeb)
                _DownloadFailedMessage = exWeb.Message
                Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)
            Catch exNet As Net.WebException
                ' Net.WebExceptionでの例外
                cntFailed += 1
                _Log.Error(exNet)
                _DownloadFailedMessage = exNet.Message
                Threading.Thread.Sleep(DataManager.GetInstance.DownLoadInterval)
            Catch ex As Exception
                _Log.Error(ex)
                '2012/06/07 cst chg s
                'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                _DownloadFailedMessage = ex.Message
                '2012/06/07 cst chg e
            End Try
        End While

        Return cntFailed
    End Function

    Delegate Sub ShowProcessMessageDelegate(ByVal val As Boolean, ByVal message As String)
    ''' <summary>
    ''' ダウンロードメッセージを表示します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowProcessMessage(ByVal val As Boolean, ByVal message As String)
        Me.lblProcMsg.Text = "処理中です"
        Me.lblProcMsg.Visible = val
    End Sub

    ''' <summary>
    ''' 問題番号をカウントアップします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Function QuestionNumberCountUp(ByVal questionNumber As Integer) As Integer
        While (True)
            Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(questionNumber)

            ' 中問の設問・小問の場合
            If Not questionCodeDefine.IsMiddleMainQuestion OrElse (questionCodeDefine.MiddleQuestionCode = "") Then
                Exit While
            Else
                questionNumber += 1
            End If
        End While
        Return questionNumber
    End Function

    ''' <summary>
    ''' 問題番号をカウントダウンします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Function QuestionNumberCountDown(ByVal questionNumber As Integer) As Integer
        While (True)
            Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(questionNumber)
            ' 中問の設問・小問の場合
            If Not questionCodeDefine.IsMiddleMainQuestion OrElse (questionCodeDefine.MiddleQuestionCode = "") Then
                Exit While
            Else
                questionNumber -= 1
            End If
        End While
        Return questionNumber
    End Function

    ''' <summary>
    ''' 次の中問の問題開始位置取得
    ''' </summary>
    ''' <param name="Num">現在の問題開始位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NextMiddleQuestionStart(ByVal Num As Integer) As Integer
        Dim Idx As Integer = Num + 1

        While (True)
            If Idx >= DataManager.GetInstance.QuestionCodeList.Count Then Return Num
            Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(Idx)
            '次の中問主文位置を探す
            If questionCodeDefine.IsMiddleMainQuestion Then
                Idx += 1
                Exit While
            End If
            Idx += 1
        End While

        Return Idx
    End Function

    ''' <summary>
    ''' 前の中問の問題開始位置取得
    ''' </summary>
    ''' <param name="Num">現在の問題開始位置</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PreMiddleQuestionStart(ByVal Num As Integer) As Integer
        Dim Idx As Integer = Num - 1
        Dim flgFirst As Boolean = True

        While (True)
            If Idx <= 0 Then Return Num
            Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(Idx)
            ' 小問の場合、処理を抜ける
            If questionCodeDefine.MiddleQuestionCode = "" Then
                Exit While
            End If

            '前の中問主文位置を探す
            If questionCodeDefine.IsMiddleMainQuestion Then
                If flgFirst Then
                    ' 現在の中問主文位置は無視する
                    flgFirst = False
                Else
                    Idx += 1
                    Exit While
                End If
            End If
            Idx -= 1
        End While

        Return Idx
    End Function

    Delegate Sub CloseFormDelegate()
    ''' <summary>
    ''' 画面を終了します。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseForm()
        Try
            Me.Close()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' ダウンロード完了状態をセットします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFixDownloadState(ByVal index As Integer)
        Try
            ' ダウンロード状態をセット
            DataManager.GetInstance.QuestionCodeList(index).DownloadState = QuestionCodeDefine.DownloadStateIndex.FixDownload
            '中問の各小問もダウンロード状態を設定
            If DataManager.GetInstance.QuestionCodeList(index).IsMiddleMainQuestion Then
                For Each Idx As Integer In DataManager.GetInstance.QuestionCodeList.Keys
                    If DataManager.GetInstance.QuestionCodeList(index).MiddleQuestionCode = DataManager.GetInstance.QuestionCodeList(Idx).MiddleQuestionCode Then
                        DataManager.GetInstance.PracticeQuestionDefine.SetQuestionCodeDownLoad(DataManager.GetInstance.QuestionCodeList(Idx).QuestionCode)
                        DataManager.GetInstance.QuestionCodeList(Idx).DownloadState = QuestionCodeDefine.DownloadStateIndex.FixDownload
                    End If
                Next
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            '2012/06/07 cst chg s
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            _DownloadFailedMessage = ex.Message
            '2012/06/07 cst chg e
        End Try
    End Sub

    ''' <summary>
    ''' 初期表示をします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize()
        Try
            ' 初期表示完了フラグの設定
            _QuestionViewFlg = True
            ' プロセスメッセージの終了設定
            Dim dlg As New ShowProcessMessageDelegate(AddressOf ShowProcessMessage)
            Me.Invoke(dlg, New Object() {False, _downloadMsg})

            ' 問題番号取得
            Dim quesionNumber As Integer = QuestionNumberCountUp(0)
            ' 中問開始位置設定
            _MiddleQuestionStartNum = quesionNumber

            '' コントロールの有効設定
            'Dim SetControlEnabledlg As New SetControlEnableDelegate(AddressOf SetControlEnable)
            'Me.Invoke(SetControlEnabledlg, New Object() {True})

            ' 問題表示
            'Dim ret As Integer = CheckReadComplete(quesionNumber)
            'If ret = CheckReadCompleteResult.ReadTrue Then
            '    UpdateQuestion(quesionNumber)
            'Else
            '    ExcFailedLoadQuestion()
            'End If
            _checkParameter1 = quesionNumber
            _checkParameter2 = False
            bgwCheck.RunWorkerAsync()


        Catch ex As Exception
            ' ログ出力
            _Log.Error(ex)
            '2012/06/07 cst chg s
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            _DownloadFailedMessage = ex.Message
            '2012/06/07 cst chg e
        End Try
    End Sub

    ''' <summary>
    ''' 問題情報読み込み失敗時の処理をします。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExcFailedLoadQuestion()
        Try
            _Log.Error("Failed to load Question:" & _QuestionCode)

            Dim testType As String = ""
            Dim messeg As String = ""
            Dim msgStyle As Microsoft.VisualBasic.MsgBoxStyle
            testType = "テスト"
            msgStyle = vbCritical + vbOKCancel
            messeg = String.Format(Common.Message.GetMessage("Q" & Constant.QuestionMessageCode.TestEndConfirm), testType)
            '2012/06/26 NOZAO CHG S
            'If DialogResult.OK = MsgBox(messeg, msgStyle, "情報") Then
            If DialogResult.OK = MsgBox(messeg, msgStyle, "メッセージ") Then
                '2012/06/26 NOZAO CHG E
                ' 終了処理
                EndTest()
            Else
                _QuestionNumber = QuestionNumberCountDown(_QuestionNumber)
                _QuestionCode = DataManager.GetInstance.QuestionCodeList.Item(_QuestionNumber).QuestionCode
            End If
        Catch ex As Exception
            ' ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

#End Region

#Region "----- イベント -----"

    ''' <summary>
    ''' フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()

            Me.TopMost = False

            'ユーザーコントロール初期化
            webQuestionSingle.AllowNavigation = True
            'For Each webQuestionMulti As BaseControl.UserWebBrowser In _WebQuestionMulties
            '    webQuestionMulti.AllowNavigation = True
            'Next

            'フォームキャプション設定
            Me.Text = FORM_TEXT

            ''ユーザーID設定
            Me.UserId = "ID：" & DataManager.GetInstance.UserId
            ''ユーザー名設定
            Me.UserName = "氏名：" & DataManager.GetInstance.UserName

            '表示倍率は100%スタート
            Me.cboDisplayMagnification.SelectedIndex = 0

            '解答データのクリア
            DataManager.GetInstance.ResultDataContainer.Clear()

            ' 問題定義のクリア
            If Not IsNothing(DataManager.GetInstance.PracticeQuestionDefineContainer) Then
                DataManager.GetInstance.PracticeQuestionDefineContainer.Clear()
            End If

            ' ファイルをダウンロードする(スレッドの開始)
            bgwDownload.RunWorkerAsync()

            '' ストップウォッチ設定
            _StopWatch = New Stopwatch()     ' ストップウォッチリセット

            '残り時間
            _RemainingTime = Constant.InitialeRemainingTime
            _RemainingTime = New TimeSpan(0, DataManager.GetInstance.Syubetu, 0)
            '残り時間タイマースタート
            RemainingTimer.Enabled = True
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Me.Close()
        Finally
            _Log.End()
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
            _Log.Start()
            '色設定ダイアログ表示
            Dim cd As New ColorDialog()
            If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '表示背景色設定
                Call webQuestionSingle.DocumentBackColor(cd.Color)
                'For Each webQuestionMulti As BaseControl.UserWebBrowser In _WebQuestionMulties
                '    Call webQuestionMulti.DocumentBackColor(cd.Color)
                'Next
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
    ''' 文字色変更ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCodeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodeColor.Click
        Try
            _Log.Start()
            '色設定ダイアログ表示
            Dim cd As New ColorDialog()
            If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '表示文字色設定
                Call webQuestionSingle.DocumentCodeColor(cd.Color)
                'For Each webQuestionMulti As BaseControl.UserWebBrowser In _WebQuestionMulties
                '    Call webQuestionMulti.DocumentCodeColor(cd.Color)
                'Next
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
    ''' 表示倍率変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboDisplayMagnification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDisplayMagnification.SelectedIndexChanged
        Try
            _Log.Start()
            Call webQuestionSingle.DisplayMagnification(cboDisplayMagnification.Text)
            'For Each webQuestionMulti As BaseControl.UserWebBrowser In _WebQuestionMulties
            '    Call webQuestionMulti.DisplayMagnification(cboDisplayMagnification.Text)
            'Next
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 終了ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            _Log.Start()

            ' テスト終了確認ダイアログを表示する
            Dim frmConfirmTestEnd As New frmConfirmTestEnd("")
            If DialogResult.OK = ShowSubForm(frmConfirmTestEnd) Then
                ' ダウンロード強制終了フラグの設定
                _ForcedTerminationFlg = True
                ' 終了処理
                EndTest()
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
    ''' 次の問題へボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim questionNumber As Integer = 0
        Try
            _Log.Start()

            ' ストップウォッチストップ
            _StopWatch.Stop()

            ' 問題番号のカウントアップ
            '2012/06/07 cst add s
            If _QuestionNumber = DataManager.GetInstance.QuestionCodeList.Count - 1 Then _QuestionNumber = -1
            '2012/06/07 cst add e
            questionNumber = QuestionNumberCountUp(_QuestionNumber + 1)
            _checkParameter1 = questionNumber
            _checkParameter2 = False

            While True
                If Not bgwCheck.IsBusy Then
                    bgwCheck.RunWorkerAsync()
                    Exit While
                End If
                Threading.Thread.Sleep(100)
                ' メッセージ・キューにあるWindowsメッセージをすべて処理する
                Application.DoEvents()
            End While

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 前の問題へボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btmPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btmPre.Click
        Dim questionNumber As Integer = 0
        Try
            _Log.Start()

            ' ストップウォッチストップ
            _StopWatch.Stop()

            ' 問題番号のカウントダウン
            If _QuestionNumber = 0 Then _QuestionNumber = DataManager.GetInstance.QuestionCodeList.Count
            questionNumber = QuestionNumberCountDown(_QuestionNumber - 1)
            _checkParameter1 = questionNumber
            _checkParameter2 = False

            While True
                If Not bgwCheck.IsBusy Then
                    bgwCheck.RunWorkerAsync()
                    Exit While
                End If
                Threading.Thread.Sleep(100)
                ' メッセージ・キューにあるWindowsメッセージをすべて処理する
                Application.DoEvents()
            End While

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 問題見直しボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReview.Click
        Try
            _Log.Start()

            ' 総合テスト画面の場合
            _SynthesisTestReviewForm = New frmReview
            ShowSubForm(_SynthesisTestReviewForm)
            _SynthesisTestReviewForm = Nothing
            
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 総合テスト見直し問題番号変更イベント
    ''' </summary>
    ''' <param name="questionNumber">変更する問題番号</param>
    ''' <remarks></remarks>
    Private Sub ChangeSynthesisQuestionNumber(ByVal questionNumber As Integer) Handles _SynthesisTestReviewForm.ChangeQuestion
        Try
            _checkParameter1 = questionNumber
            _checkParameter2 = True
            bgwCheck.RunWorkerAsync()

        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 解答選択ラジオボタンのチェック状態変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdbAnswer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAnswer1.CheckedChanged, rdbAnswer2.CheckedChanged, rdbAnswer3.CheckedChanged, rdbAnswer4.CheckedChanged, rdbAnswer5.CheckedChanged
        Try
            _Log.Start()
            If _IsIgnoreCheckChangeEvent = False Then
                If CType(sender, RadioButton).Checked Then

                    'チェックされたラジオボタンの状態を結果データとして保存する。
                    Dim resultData As ResultData = DataManager.GetInstance.ResultDataContainer(_QuestionCode)

                    If resultData Is Nothing Then
                        resultData = CreateResultData()
                    Else
                        resultData.Answer = GetAnswerString()
                    End If

                    DataManager.GetInstance.ResultDataContainer(_QuestionCode) = resultData

                    If _ResultDataList.IndexOf(_QuestionCode) = -1 Then
                        _ResultDataList.Add(_QuestionCode)
                        _QuestionCount += 1
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
    ''' 見直しチェックボックスチェック状態変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkReview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReview.CheckedChanged
        Try
            _Log.Start()
            If _IsIgnoreCheckChangeEvent = False Then
                'チェックされた見直しチェック状態を結果データとして保存する。
                Dim resultData As ResultData = DataManager.GetInstance().ResultDataContainer(_QuestionCode)

                If resultData Is Nothing Then
                    resultData = CreateResultData()
                Else
                    resultData.Check = chkReview.Checked
                End If

                DataManager.GetInstance().ResultDataContainer(_QuestionCode) = resultData
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
    ''' ウインドウプロシージャ
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            '_Log.Start()
            If IsIgnoreMessage(m) Then
                Return
            End If

            MyBase.WndProc(m)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            '_Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 無視するメッセージかどうか
    ''' </summary>
    ''' <param name="m"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsIgnoreMessage(ByRef m As Message)
        Dim ret As Boolean = False

        Try
            '_Log.Start()
            Const WM_SYSCOMMAND As Integer = &H112
            Const SC_MOVE As Integer = &HF010
            Const SC_MASK As Integer = &HFFF0

            ' フォームの移動を捕捉したら以降の制御をカットする
            If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And SC_MASK) = SC_MOVE Then
                ret = True
            End If

            Const WM_NCLBUTTONDBLCLK As Integer = &HA3
            If m.Msg = WM_NCLBUTTONDBLCLK Then
                ret = True
            End If
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            '_Log.End()
        End Try

        Return ret
    End Function

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

    ''' <summary>
    ''' ファイルダウンロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgwDownload_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwDownload.DoWork
        Try
            _Log.Start()

            'ファイルをダウンロードする()
            'BackgroundWorkerの取得(スレッドを作成したオブジェクト)
            Dim objWorker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
            Dim cntFile As Integer = 0
            Dim cntFailed As Integer = 0
            Dim downLoadCodeList As New List(Of String)
            Dim ret As Boolean = False
            Dim fileName As String = ""
            Dim staList As Integer = 0
            Dim cntTotal As Integer = 0
            Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

            ' エラーメッセージの初期化
            _DownloadFailedMessage = ""


            For Each key As Integer In DataManager.GetInstance.QuestionCodeList.Keys

                ' 終了ボタンがクリックされた場合、スレッドを終了する
                If _ForcedTerminationFlg Then
                    ' メッセージの非表示
                    'Dim dlg As New ShowProcessMessageDelegate(AddressOf ShowProcessMessage)
                    'Me.Invoke(dlg, New Object() {False, _downloadMsg})
                    Exit Sub
                End If

                Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(key)
                ' ダウンロードリストのスタートインデックスを保持
                If cntFile = 0 Then
                    staList = key
                End If

                ' ファイル名を作成する
                fileName = ""
                If questionCodeDefine.MiddleQuestionCode = questionCodeDefine.QuestionCode Then
                    ' 中問の場合
                    fileName = Common.Constant.CST_PRACTICEQUESTIONMIDDLE_FILENAME + questionCodeDefine.QuestionCode
                ElseIf questionCodeDefine.MiddleQuestionCode = "" AndAlso questionCodeDefine.QuestionCode <> questionCodeDefine.MiddleQuestionCode Then
                    ' 小問の場合
                    fileName = Common.Constant.CST_PRACTICEQUESTION_FILENAME + questionCodeDefine.QuestionCode
                End If

                cntTotal += 1

                ' 既にダウンロードしている場合は次のリストに進む
                If DataManager.GetInstance.PracticeQuestionDefine.IsQuestionCodeDownLoad(questionCodeDefine.QuestionCode) = False Then
                    If fileName <> "" Then
                        ' ダウンロードリストに追加
                        downLoadCodeList.Add(fileName)
                        cntFile += 1
                    End If
                    ' ダウンロードリスト数が指定したダウンロードファイル数になった場合
                    If cntFile = DataManager.GetInstance.FilePartitionCount Then
                        cntFailed = CallDownLoadProcess(downLoadCodeList)
                        cntFile = 0
                        ' ダウンロードリストをクリア
                        downLoadCodeList.Clear()
                    End If
                    ' ダウンロード失敗した場合、ループを抜ける
                    If cntFailed = DataManager.GetInstance.FileDownloadFailed Then
                        Exit For
                    End If
                Else
                    ' 問題ファイルを読み込む
                    If fileName <> "" Then
                        errCode = DataManager.GetInstance.ReadQuestion(fileName)
                        If Not errCode = Constant.ResultCode.NormalEnd Then
                            ' 読み込みに失敗した場合、終了する
                            Exit For
                        Else
                            ' ダウンロード状態をセット
                            Call SetFixDownloadState(key)
                            If key = 0 AndAlso Not _QuestionViewFlg Then
                                ' 初期表示
                                Call Initialize()
                            End If
                        End If
                    End If
                End If

                ' 残りのファイルをダウンロード
                If cntTotal = DataManager.GetInstance.QuestionCodeList.Count And downLoadCodeList.Count <> 0 Then
                    cntFailed = CallDownLoadProcess(downLoadCodeList)
                End If
            Next

            ' ダウンロード失敗した場合
            If cntFailed = DataManager.GetInstance.FileDownloadFailed Or Not errCode = Constant.ResultCode.NormalEnd Then
                For index As Integer = staList To DataManager.GetInstance.QuestionCodeList.Count - 1
                    Dim questionCodeDefine As QuestionCodeDefine = DataManager.GetInstance.QuestionCodeList.Item(index)
                    questionCodeDefine.DownloadState = questionCodeDefine.DownloadStateIndex.ErrorDownload
                    _Log.Error("Failed to download Question : " & questionCodeDefine.QuestionCode)
                Next
            End If

            If Not _QuestionViewFlg Then
                If cntFailed = DataManager.GetInstance.FileDownloadFailed Or Not errCode = Constant.ResultCode.NormalEnd Then
                    Dim ResultCode As String = "E" & Constant.ResultCode.CheckReadComplete
                    '2012/06/07 cst chg s
                    'Common.Message.MessageShow(ResultCode)
                    _DownloadFailedMessage = Common.Message.GetMessage(ResultCode)
                    '2012/06/07 cst chg e
                    ' 画面を閉じる
                    Dim dlg As New CloseFormDelegate(AddressOf CloseForm)
                    Me.Invoke(dlg, New Object() {})
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            '2012/06/07 cst chg s
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            _DownloadFailedMessage = ex.Message
            '2012/06/07 cst chg e
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' ファイルダウンロード完了イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgwDownload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwDownload.RunWorkerCompleted
        _Log.Start()
        If _DownloadFailedMessage <> "" Then
            'Call MsgBox(_DownloadFailedMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly + MsgBoxStyle.SystemModal, "情報")
            Common.Message.MessageShow("E" & Constant.ResultCode.DownLoadFileError)
        End If
        _Log.End()
    End Sub

    ''' <summary>
    ''' ファイル読み込みチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgwCheck_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwCheck.DoWork
        Dim SetControlEnabledlg As New SetControlEnableDelegate(AddressOf SetControlEnable)

        Try
            _Log.Start()
            ' コントロールの設定
            Me.Invoke(SetControlEnabledlg, New Object() {False})

            Dim ret As Integer = CheckReadCompleteResult.ReadTrue
            _checkRet = CheckReadComplete(_checkParameter1, _checkParameter2)

        Catch ex As Exception
            'ログ出力()
            _Log.Error(ex)
            '2012/06/07 cst del s
            'Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '2012/06/07 cst del e
        Finally
            Me.Invoke(SetControlEnabledlg, New Object() {True})
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' ファイル読み込みチェック完了イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgwCheck_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCheck.RunWorkerCompleted
        Try
            _Log.Start()

            ' 終了ボタンがクリックされた場合、スレッドを終了する
            If _ForcedTerminationFlg Then
                Exit Sub
            End If

            If _checkRet = CheckReadCompleteResult.ReadTrue Then
                ' 問題情報の読み込み成功
                UpdateQuestion(_checkParameter1)
            ElseIf _checkRet = CheckReadCompleteResult.ReadError Then
                ' 問題情報の読み込み失敗
                ExcFailedLoadQuestion()
                '2012/06/07 cst add s
            ElseIf _checkRet = CheckReadCompleteResult.ReadNot Then
                ' 問題情報の読み込み中
                Common.Message.MessageShow("I" & Constant.InformationMessageCode.DownLoadWhileInfo)
                '2012/06/07 cst add e
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
    ''' ファイルアップロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgwUpload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwUpload.DoWork
        'Dim dlg As New ShowProcessMessageDelegate(AddressOf ShowProcessMessage)
        'Dim SetControlEnabledlg As New SetControlEnableDelegate(AddressOf SetControlEnable)
        Try
            _Log.Start()

            While True
                If Not bgwDownload.IsBusy Then
                    Exit While
                End If
                Threading.Thread.Sleep(500)
            End While

            'Me.Invoke(dlg, New Object() {True, _uploadMsg})
            '' コントロールの設定
            'Me.Invoke(SetControlEnabledlg, New Object() {False})


        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            'Me.Invoke(dlg, New Object() {False, _uploadMsg})
            'Me.Invoke(SetControlEnabledlg, New Object() {True})
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' ファイルアップロード完了イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bgwUpload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwUpload.RunWorkerCompleted
        Dim ret As Boolean = True
        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        Dim frm As Object = Nothing
        Dim testCount As String = ""
        Dim testNo As String = ""
        Try
            _Log.Start()

            dataBanker("FROMFORM") = lblBottomCode.Text
            ' 総合テスト問題画面
            If Not DataManager.GetInstance.IsLogouting Then
                dataBanker("TOFORM") = "JG33"
                frm = New frmSynthesisTestMarkHistory
                ' 総合テスト実施結果（正解数・問題数・正解率）DataRowのセット
                frm.SynthesisResultDataRow = DataManager.GetInstance.GetResultDataRow(Constant.TestType.SynthesisResult)
                ' 総合テスト問別正誤DataTableのセット
                frm.LargeCategoryAccuracyRateTbl = DataManager.GetInstance.SynthesisResultDefine.GetSeparateCategoryAccuracyRate _
                                                    (DataManager.GetInstance.CategoryDefine.CategoryDataTable, _
                                                     DataManager.GetInstance.PracticeQuestionDefine.PracticeQuestionListDataTable, _
                                                     DataManager.GetInstance.SynthesisResultDefine.SynthesisResultDetailDataTable,
                                                     DataManager.GetInstance.SynthesisDefine.TestCount,
                                                     DataManager.GetInstance.SynthesisDefine.TestNo)

                ' 画面表示
                frm.ShowDialog(Me)
            End If
            
            ' 画面を閉じる
            Dim dlg2 As New CloseFormDelegate(AddressOf CloseForm)
            Me.Invoke(dlg2, New Object() {})

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' 残り時間表示更新タイマーイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RemainingTimer_Tick(sender As System.Object, e As System.EventArgs) Handles RemainingTimer.Tick
        Try
            '残り時間の更新
            _RemainingTime -= New TimeSpan(0, 0, (CType(sender, Timer).Interval / 1000))
            lblRemainingTime.Text = String.Format("残り時間：{0:D3}分{1:D2}秒", _RemainingTime.Hours * 60 + _RemainingTime.Minutes, _RemainingTime.Seconds)

            '問題見直し画面も表示されている場合は、問題見直し画面の残り時間も更新する。
            If _SynthesisTestReviewForm Is Nothing = False Then
                _SynthesisTestReviewForm.UpdateRemainingTime(_RemainingTime)
            End If

            '残り時間が0になった場合はテストを終了する。
            If _RemainingTime.Ticks = 0 Then
                For Each f As Form In _SubFormList
                    f.Hide()
                    f.Close()
                Next
                RemainingTimer.Enabled = False
                Dim frm As New frmTimeUp
                frm.ShowDialog()
                EndTest()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

End Class

