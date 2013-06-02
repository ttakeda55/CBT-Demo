Public Class UserWebBrowser

    Public Event Navigated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs)
    Public Event DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

#Region "---- 定数 ----"
    ''' <summary>
    ''' ズームのモード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ZoomMode
        Auto = 0    '自動(ズーム時にスクロールバーが太くなる場合がある。)
        Manual      '手動(手動でパネルの上に大きくしたWebBrowserを乗せて、スクロールを制御しているが、WebBrowserの再描画時にスクロール状態が0,0に戻る問題がある。
        ActiveX     'COMを使用(IE7以上でないと動作しない、IE6以下は詳細なズームの設定ができない問題がある。)
    End Enum
#End Region

#Region "---- 定数 ----"
    Private Const CONTROL_SIZE_MARJIN As Integer = 2
#End Region

#Region "---- メンバ変数 ----"

    ''' <summary>ドキュメント背景色</summary>
    Private _DocumentBackColor As Color = Color.White
    ''' <summary>ドキュメント文字色</summary>
    Private _DocumentCodeColor As Color = Color.Black
    ''' <summary>表示倍率</summary>
    Private _DisplayMagnification As String = "100%"

    ''' <summary>ボディのスタイル</summary>
    Private _BodyStyle As String

    ''' <summary>ズーム形式</summary>
    Private _Mode As ZoomMode
#End Region

#Region "----- プロパティ -----"
    ''' <summary>
    ''' ズームのモードを設定、取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mode As ZoomMode
        Get
            Return _Mode
        End Get
        Set(value As ZoomMode)
            _Mode = value
        End Set
    End Property



    Public WriteOnly Property Navigate As String
        Set(ByVal value As String)
            WebBrowser.Navigate(value)
        End Set
    End Property

    Public Property url As Object
        Get
            Return WebBrowser.Url
        End Get
        Set(ByVal value As Object)
            WebBrowser.Url = value
        End Set
    End Property

    Public Property DocumentText As String
        Get
            Return WebBrowser.DocumentText
        End Get
        Set(ByVal value As String)
            If WebBrowser.Document = Nothing Then
                WebBrowser.Navigate("about:blank") ' 空白ページを開く
            End If
            WebBrowser.Document.OpenNew(True)
            WebBrowser.DocumentText = value
        End Set
    End Property

    Public Property AllowNavigation As Boolean
        Get
            Return WebBrowser.AllowNavigation
        End Get
        Set(ByVal value As Boolean)
            WebBrowser.AllowNavigation = value
        End Set
    End Property

#End Region

#Region "----- イベント -----"
    Private Sub UserWebBrowser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Select Case _Mode
            Case ZoomMode.Auto
                WebBrowser.Dock = DockStyle.Fill
                WebBrowser.ScrollBarsEnabled = True
            Case ZoomMode.Manual
                WebBrowser.Dock = DockStyle.None
                WebBrowser.ScrollBarsEnabled = False
            Case ZoomMode.ActiveX
                WebBrowser.Dock = DockStyle.Fill
                WebBrowser.ScrollBarsEnabled = True
        End Select
    End Sub

    ''' <summary>
    ''' ドキュメント読込完了イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WebBrowser_DocumentCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser.DocumentCompleted
        Try
            'レイアウトロジックを中断
            Call WebBrowser.SuspendLayout()
            '背景色設定
            Call ChangeDocumentBackColor()
            '文字色設定
            Call ChangeDocumentCodeColor()
            'ズーム
            ChangeDisplayMagnification()
            'レイアウトロジックを再開
            Call WebBrowser.ResumeLayout(False)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' ユーザーコントロールのサイズ変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserWebBrowser_SizeChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.SizeChanged
        SetWebBrowserSizeOfDocumentSize()
    End Sub
#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 背景色設定
    ''' </summary>
    ''' <param name="backColor">設定背景色</param>
    ''' <remarks></remarks>
    Public Sub DocumentBackColor(ByVal backColor As Color)
        Try
            'メンバ変数格納
            _DocumentBackColor = backColor
            '背景色変更
            Call ChangeDocumentBackColor()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 背景色変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeDocumentBackColor()
        Try
            If Not IsNothing(_DocumentBackColor) Then
                WebBrowser.Document.BackColor = _DocumentBackColor
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 文字色設定
    ''' </summary>
    ''' <param name="codeColor">設定文字色</param>
    ''' <remarks></remarks>
    Public Sub DocumentCodeColor(ByVal codeColor As Color)
        Try
            'メンバ変数格納
            _DocumentCodeColor = codeColor
            '文字色変更
            Call ChangeDocumentCodeColor()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 文字色変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeDocumentCodeColor()
        Try
            If Not IsNothing(_DocumentCodeColor) Then
                WebBrowser.Document.ForeColor = _DocumentCodeColor
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 表示倍率設定
    ''' </summary>
    ''' <param name="value">設定倍率(%表記)</param>
    ''' <remarks></remarks>
    Public Sub DisplayMagnification(ByVal value As String)
        Try
            'メンバ変数格納
            _DisplayMagnification = value
            '表示倍率変更
            Call ChangeDisplayMagnification()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 表示倍率変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeDisplayMagnification()
        Try
            If Mode = ZoomMode.Auto OrElse Mode = ZoomMode.Manual Then
                If WebBrowser.Document.Body Is Nothing = False Then

                    Dim style As String = String.Empty
                    If String.IsNullOrEmpty(WebBrowser.Document.Body.Style) Then
                        _BodyStyle = String.Empty
                        WebBrowser.Document.Body.Style = String.Format("zoom:{0};", _DisplayMagnification)
                    Else
                        Dim mcs = System.Text.RegularExpressions.Regex.Matches( _
                            style, "{zoom:*%;}")
                        If mcs.Count = 0 Then
                            _BodyStyle = WebBrowser.Document.Body.Style
                        End If

                        Dim zoomStr As String = String.Format("; zoom:{0};", _DisplayMagnification)
                        WebBrowser.Document.Body.Style = _BodyStyle & zoomStr
                    End If

                    '指定の表示倍率のドキュメントを元に、WebBrowserのサイズを変更する
                    SetWebBrowserSizeOfDocumentSize()
                End If
            ElseIf Mode = ZoomMode.ActiveX Then
                'パーセント。10～1000 の範囲
                Dim pvaIn As Object = _DisplayMagnification

                '変更結果が返される
                Dim pvaOut As Object = Type.Missing

                Dim OLECMDID_OPTICAL_ZOOM As SHDocVw.OLECMDID = CType(63, SHDocVw.OLECMDID)
                CType(WebBrowser.ActiveXInstance, SHDocVw.IWebBrowser2).ExecWB(
                OLECMDID_OPTICAL_ZOOM,
                SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
                pvaIn,
                pvaOut)
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 指定の表示倍率のドキュメントを元に、WebBrowserのサイズを変更する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetWebBrowserSizeOfDocumentSize()

        If Mode = ZoomMode.Manual Then

            If WebBrowser.Document Is Nothing = False AndAlso _
                WebBrowser.Document.Body Is Nothing = False Then

                Dim width As Integer = Panel.Width - CONTROL_SIZE_MARJIN
                Dim height As Integer = Panel.Height - CONTROL_SIZE_MARJIN

                '初期計算サイズはパネルのサイズ
                WebBrowser.Size = New Size(width, height)

                If Panel.Width < WebBrowser.Document.Body.ScrollRectangle.Width * _DisplayMagnification / 100 Then
                    '画像などで横幅が収まりきらない場合

                    '横幅はドキュメントの幅に合わせる
                    width = WebBrowser.Document.Body.ScrollRectangle.Width * _DisplayMagnification / 100

                    '横幅を変更したサイズで高さを再計算する。
                    WebBrowser.Width = width

                    '高さは収まりきらない場合のみ、ドキュメントの高さにあわせる。
                    If Panel.Height < WebBrowser.Document.Body.ScrollRectangle.Height * _DisplayMagnification / 100 Then
                        height = WebBrowser.Document.Body.ScrollRectangle.Height * _DisplayMagnification / 100
                        width += SystemInformation.VerticalScrollBarWidth
                    End If
                Else
                    '横幅が収まりきっている場合
                    'まずドキュメントの高さが、表示部の高さより大きいかを判断する。
                    If Panel.Height < WebBrowser.Document.Body.ScrollRectangle.Height * _DisplayMagnification / 100 Then
                        '高さがオーバーしてスクロールバーが表示されるので、スクロールバーの幅を引く
                        width -= SystemInformation.VerticalScrollBarWidth

                        'スクロールバーの幅を引いたWebBrowserで再度取得する。
                        WebBrowser.Width = width

                        'スクロールバーを表示した状態で横幅が収まりきっていない場合は、ドキュメントの幅を使用する
                        If Me.Width < WebBrowser.Document.Body.ScrollRectangle.Width * _DisplayMagnification / 100 Then
                            width = WebBrowser.Document.Body.ScrollRectangle.Width * _DisplayMagnification / 100
                        End If

                        '高さはドキュメントの高さ
                        height = WebBrowser.Document.Body.ScrollRectangle.Height * _DisplayMagnification / 100
                    End If
                End If

                'ウェブブラウザー自体のサイズを変更し、パネルの自動スクロールに任せる。
                WebBrowser.Size = New Size(width, height)
            End If
        End If
    End Sub

#End Region

End Class
