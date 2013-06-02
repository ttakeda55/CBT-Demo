Public Class frmConfirmTestEnd

#Region "----- メンバ変数 -----"
    ''' <summary>ログ出力オブジェクト</summary>
    Private ReadOnly _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal testName As String)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        lblBody.Text = String.Format("{0}テストを終了して採点します。" + vbCrLf + "よろしいですか？", testName)

    End Sub
#End Region

#Region "----- イベント -----"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            _Log.Start()
            DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            'ログ出力
            _Log.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            _Log.End()
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            _Log.Start()
            DialogResult = Windows.Forms.DialogResult.Cancel

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