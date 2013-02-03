Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary


''' <summary>
''' 演習問題バンク
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class PracticeQuestionBank
    Implements System.ICloneable
#Region "----- メンバ変数 -----"
    ''' <summary>問題コード</summary>
    Private _questionCode As String = String.Empty
    ''' <summary>中問題コード</summary>
    Private _middleQuestionCode As String = String.Empty
    ''' <summary>中問フラグ</summary>
    Private _isMiddleQuestion As Boolean = False
    ''' <summary>中問主文フラグ</summary>
    Private _isMiddleMainQuestion As Boolean = False
    ''' <summary>カテゴリーID</summary>
    Private _categoryId As String = String.Empty
    ''' <summary>問題テーマ</summary>
    Private _theme As String = String.Empty
    ''' <summary>出題形式</summary>
    Private _format As String = String.Empty
    ''' <summary>設問</summary>
    Private _question As String = String.Empty
    ''' <summary>選択肢</summary>
    Private _choice As String = String.Empty
    ''' <summary>正解</summary>
    Private _Ansewr As String = String.Empty
    ''' <summary>解説</summary>
    Private _comment As String = String.Empty
    ''' <summary>画像</summary>
    Private _image As Hashtable = New Hashtable()
    ''' <summary>選択肢記号</summary>
    Private _choiceMark As New ArrayList
    ''' <summary>headタグ</summary>
    Private _headTag As String = String.Empty
    ''' <summary>bodyタグ</summary>
    Private _bodyTag As String = String.Empty
    ''' <summary>divタグ</summary>
    Private _divTag As String = String.Empty
#End Region

#Region "----- プロパティ -----"

#Region "問題コード"
    ''' <summary>
    ''' 問題コードを取得/設定します。
    ''' </summary>
    Public Property QuestionCode() As String
        Get
            Return _questionCode
        End Get
        Set(ByVal value As String)
            _questionCode = value
        End Set
    End Property
#End Region

#Region "中問"
    ''' <summary>
    ''' 中問情報
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Structure multiQuestion
        Dim Code As String
        Dim Count As Integer
    End Structure

    ''' <summary>
    ''' 中問コードを取得/設定します。
    ''' </summary>
    Public Property MiddleQuestionCode() As String
        Get
            Return _middleQuestionCode
        End Get
        Set(ByVal value As String)
            _middleQuestionCode = value
        End Set
    End Property

    ''' <summary>
    ''' 中問かどうか取得/設定します。
    ''' </summary>
    Public Property IsMiddleQuestion() As Boolean
        Get
            Return _isMiddleQuestion
        End Get
        Set(ByVal value As Boolean)
            _isMiddleQuestion = value
        End Set
    End Property

    ''' <summary>
    ''' 中問主文かどうか取得/設定します。
    ''' </summary>
    Public Property IsMiddleMainQuestion() As String
        Get
            Return _isMiddleMainQuestion
        End Get
        Set(ByVal value As String)
            _isMiddleMainQuestion = value
        End Set
    End Property
#End Region

#Region "カテゴリーID"
    ''' <summary>
    ''' カテゴリーIDを取得/設定します。
    ''' </summary>
    Public Property CategoryId() As String
        Get
            Return _categoryId
        End Get
        Set(ByVal value As String)
            _categoryId = value
        End Set
    End Property
#End Region

#Region "問題テーマ"
    ''' <summary>
    ''' 問題テーマを取得/設定します。
    ''' </summary>
    Public Property Theme() As String
        Get
            Return _theme
        End Get
        Set(ByVal value As String)
            _theme = value
        End Set
    End Property
#End Region

#Region "出題形式"
    ''' <summary>
    ''' 出題形式を取得/設定します。
    ''' </summary>
    Public Property Format() As String
        Get
            Return _format
        End Get
        Set(ByVal value As String)
            _format = value
        End Set
    End Property
#End Region

#Region "設問"
    ''' <summary>
    ''' 設問を取得/設定します。
    ''' </summary>
    Public Property Question() As String
        Get
            Return _question
        End Get
        Set(ByVal value As String)
            _question = value
        End Set
    End Property
#End Region

#Region "選択肢"
    ''' <summary>
    ''' 選択肢を取得/設定します。
    ''' </summary>
    Public Property Choice() As String
        Get
            Return _choice
        End Get
        Set(ByVal value As String)
            _choice = value
        End Set
    End Property

    ''' <summary>
    ''' 選択肢記号を取得/設定します。
    ''' </summary>
    Public Property ChoiceMark As ArrayList
        Get
            Return _ChoiceMark
        End Get
        Set(ByVal value As ArrayList)
            _ChoiceMark = value
        End Set
    End Property
#End Region

#Region "画像"
    ''' <summary>
    ''' 画像を取得/設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Image(ByVal key As String) As Object
        Get
            Return _image(key)
        End Get
        Set(ByVal value As Object)
            If _image.Contains(key) Then
                ' 重複する場合は削除  
                _image.Remove(key)
            End If
            _image(key) = value
        End Set
    End Property

    ''' <summary>
    ''' 画像の件数を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImageCount() As Integer
        Get
            Return _image.Count
        End Get
    End Property

    ''' <summary>
    ''' 画像のキー情報を返します。
    ''' </summary>
    Public ReadOnly Property KeysImage() As ICollection
        Get
            Return _image.Keys
        End Get
    End Property
#End Region

#Region "正解"
    ''' <summary>
    ''' 初回の正解を設定/取得します。
    ''' </summary>
    Public Property Ansewr() As String
        Get
            Return _Ansewr
        End Get
        Set(ByVal value As String)
            _Ansewr = StrConv(value, VbStrConv.Wide).ToUpper
        End Set
    End Property
#End Region

#Region "解説"
    ''' <summary>
    ''' 解説を取得/設定します。
    ''' </summary>
    Public Property Comment() As String
        Get
            Return _comment
        End Get
        Set(ByVal value As String)
            _comment = value
        End Set
    End Property

    ''' <summary>
    ''' 解説を追加します。
    ''' </summary>
    Public Sub AddComment(ByVal value As String)
        _comment &= value
    End Sub
#End Region

#Region "tag"
    ''' <summary>
    ''' headタグを取得/設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HeadTag() As String
        Get
            Return _headTag
        End Get
        Set(ByVal value As String)
            _headTag = value
        End Set
    End Property

    ''' <summary>
    ''' bodyタグを取得/設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BodyTag() As String
        Get
            Return _bodyTag
        End Get
        Set(ByVal value As String)
            _bodyTag = value
        End Set
    End Property

    ''' <summary>
    ''' divタグを取得/設定します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DivTag() As String
        Get
            Return _divTag
        End Get
        Set(ByVal value As String)
            _divTag = value
        End Set
    End Property
#End Region

#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' System.ICloneable.Clone メソッド
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Clone() As Object Implements System.ICloneable.Clone
        Return (Me.MemberwiseClone())
    End Function

    ''' <summary>
    ''' ディープコピー
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeepCopy() As PracticeQuestionBank
        Dim questionbank As PracticeQuestionBank = DirectCast(Me.Clone(), PracticeQuestionBank)

        questionbank._choiceMark = DirectCast(Me._choiceMark.Clone, ArrayList)
        questionbank._image = DirectCast(Me._image.Clone, Hashtable)

        Return questionbank
    End Function

    ''' <summary>
    ''' 設問を追加します。
    ''' </summary>
    Public Sub AddQuestion(ByVal value As String)
        _question &= value
    End Sub

    ''' <summary>
    ''' 選択肢を追加します。
    ''' </summary>
    Public Sub AddChoice(ByVal value As String)
        setChoice(value)
        _choice &= value
    End Sub

    ''' <summary>
    ''' 選択記号を追加します。
    ''' </summary>
    Public Sub AddChoiceMark(ByVal value As String)
        _choiceMark.Add(value)
    End Sub

    ''' <summary>
    ''' 正解を設定します。
    ''' </summary>
    Private Sub setChoice(ByRef value As String)
        value = value.TrimEnd.Replace(vbCr, vbCrLf)

        Dim dom As System.Windows.Forms.HtmlDocument = CBTCommon.Utility.GetHtmlDocument(value)

        If dom.Body.GetElementsByTagName("table").Count > 0 Then
            For Each html As HtmlElement In dom.Body.GetElementsByTagName("tr")
                If html.GetElementsByTagName("td").Count > 0 Then
                    html.GetElementsByTagName("td").Item(0).InnerHtml = setAnsewr(html.GetElementsByTagName("td").Item(0).InnerHtml)
                End If
            Next
            value = dom.Body.GetElementsByTagName("table").Item(0).OuterHtml
        Else
            value = setAnsewr(value)
        End If

    End Sub

    ''' <summary>
    ''' 正解を設定します。
    ''' </summary>
    Private Function setAnsewr(ByVal value As String) As String
        setAnsewr = value
        Dim html As String = value.TrimEnd.Replace(vbCr, vbCrLf)

        Dim dom As System.Windows.Forms.HtmlDocument = CBTCommon.Utility.GetHtmlDocument(html)
        Dim innterText As String = dom.Body.InnerText
        Dim ansInnserText As String = dom.Body.InnerText
        If innterText = Nothing Then
            innterText = String.Empty
        End If

        '正解
        Dim uTag As String = ""
        Dim mcsAnswer As System.Text.RegularExpressions.MatchCollection
        Dim AnswerText As String = ""
        For Each HtmlElement As HtmlElement In dom.Body.GetElementsByTagName("U")
            mcsAnswer = System.Text.RegularExpressions.Regex.Matches( _
            HtmlElement.InnerText, "(^[" & Constant.CST_SELECTMARK_PRACTICEQUESTION & "]$)|(^[" & Constant.CST_SELECTMARK_PRACTICEQUESTION & "]$)")
            If mcsAnswer.Count > 0 Then
                AnswerText += mcsAnswer.Item(0).ToString
            End If
        Next

        If AnswerText.Length = 1 Then
            Dim i As Integer = 0
            '下線削除
            For i = 0 To 1
                dom.Body.GetElementsByTagName("U").Item(0).OuterHtml = dom.Body.GetElementsByTagName("U").Item(0).InnerHtml
                If dom.Body.GetElementsByTagName("U").Count = 0 Then
                    Exit For
                End If
            Next
            setAnsewr = dom.Body.InnerHtml
            '正解を設定
            Ansewr &= StrConv(AnswerText.Substring(0, 1), VbStrConv.Wide)
        End If

        '選択肢
        Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches( _
        innterText, "^[" & Constant.CST_SELECTMARK_PRACTICEQUESTION & "]")

        '選択肢記号
        If mcsSelect.Count > 0 Then
            AddChoiceMark(mcsSelect.Item(0).Value)
        End If

    End Function

    ''' <summary>
    ''' すべての情報を削除します。
    ''' </summary>
    Public Sub RemoveAll()
        _questionCode = String.Empty
        _middleQuestionCode = String.Empty
        _isMiddleQuestion = False
        _isMiddleMainQuestion = False
        _categoryId = String.Empty
        _theme = String.Empty
        _format = String.Empty
        _question = String.Empty
        _choice = String.Empty
        _Ansewr = String.Empty
        _comment = String.Empty
        _image = New Hashtable()
        _choiceMark.Clear()
    End Sub

    ''' <summary>
    ''' 設問のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionHtml() As String
        Dim strHtml As String = ""
        strHtml &= "<html onCopy=""return false"" onContextmenu=""return false"" onselectstart=""return false"">"
        strHtml &= HeadTag
        strHtml &= BodyTag
        strHtml &= DivTag
        strHtml &= Question()
        strHtml &= "</div>"
        strHtml &= "</body>"
        strHtml &= "</html>"
        Return strHtml
    End Function

    ''' <summary>
    ''' 設問のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionHtmlH() As String
        Dim strHtml As String = ""
        strHtml &= "<html onCopy=""return false"" onContextmenu=""return false"" onselectstart=""return false"">"
        strHtml &= HeadTag
        strHtml &= BodyTag
        strHtml &= DivTag
        Return strHtml
    End Function

    ''' <summary>
    ''' 設問のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionHtmlB() As String
        Dim strHtml As String = ""
        strHtml &= Question()
        Return strHtml
    End Function

    ''' <summary>
    ''' 設問のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionHtmlT() As String
        Dim strHtml As String = ""
        strHtml &= "</div>"
        strHtml &= "</body>"
        strHtml &= "</html>"
        Return strHtml
    End Function

    ''' <summary>
    ''' 解説のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCommentHtml() As String
        Dim strHtml As String = ""
        strHtml &= "<html onCopy=""return false"" onContextmenu=""return false"" onselectstart=""return false"">"
        strHtml &= HeadTag
        strHtml &= BodyTag
        strHtml &= DivTag
        strHtml &= Comment()
        strHtml &= "</div>"
        strHtml &= "</body>"
        strHtml &= "</html>"
        Return strHtml
    End Function

#End Region
End Class
