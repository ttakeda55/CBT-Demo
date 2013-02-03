Public Class frmSpecifications

#Region "----- 定数 -----"

    ''' <summary>フォームキャプション</summary>
    Private Const FORM_TEXT As String = "表計算仕様"
    ''' <summary>画面表示ID</summary>
    Private Const DISPLAY_ID As String = "JG07"
    ''' <summary>画面表示名</summary>
    Private Const DISPLAY_NAME As String = "表計算仕様画面"
    ''' <summary>表計算仕様表示ファイル名</summary>
    Private Const HTML_FILE_NAME As String = "SpreadSheetSpecification.mht"

#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- イベント -----"

    Private Sub frmSpecifications_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            _Log.Start()
            '初期化
            Me.webQuestionTop.AllowNavigation = True
            '表示倍率は100%で開始
            cboDisplayMagnification.SelectedIndex = 0
            'フォームキャプション設定
            Me.Text = FORM_TEXT
            '表示画面ID設定
            Me.lblBottomCode.Text = DISPLAY_ID
            '表示画面名設定
            Me.lblBottomName.Text = DISPLAY_NAME
            'Navigate設定
            Dim path As String = Common.Constant.GetTempPath & HTML_FILE_NAME
            If IO.File.Exists(path) Then
                webQuestionTop.url = New Uri(path)
            End If
            'フォーカス設定
            Me.btnBack.Select()

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
            Call webQuestionTop.DisplayMagnification(cboDisplayMagnification.Text)
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            _Log.Start()
            Me.Close()
        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

#End Region

End Class