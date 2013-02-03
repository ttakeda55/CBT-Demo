Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary


''' <summary>
''' 問題バンク
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class QuestionBank
    Implements System.ICloneable
#Region "メンバ変数"
    Private _QuestionProperty As Hashtable = New Hashtable()
    Private _question As String = ""
    Private _choice As String = ""
    Private _comment As String = ""
    Private _reTestComment As String = ""
    Private _choiceMark As New ArrayList
    Private _image As Hashtable = New Hashtable()
    Private _firstAnsewr As String = ""
    Private _secondAnsewr As String = ""
    Private _headTag As String = ""
    Private _bodyTag As String = ""
    Private _divTag As String = ""
#End Region

#Region "プロパティ"
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
    ''' 属性のキーを元にデータを取得します。
    ''' </summary>
    Public Property QuestionProperty(ByVal key As Object) As Object
        Get
            Return _QuestionProperty(key)
        End Get
        Set(ByVal value As Object)
            If _QuestionProperty.Contains(key) Then
                ' 重複する場合は削除  
                _QuestionProperty.Remove(key)
            End If
            _QuestionProperty(key) = value
        End Set
    End Property

    ''' <summary>
    ''' 属性のキー情報を返します。
    ''' </summary>
    Public ReadOnly Property KeysQuestionProperty() As ICollection
        Get
            Return _QuestionProperty.Keys
        End Get
    End Property

    ''' <summary>
    ''' 属性のキー情報を返します。
    ''' </summary>
    Public ReadOnly Property CountQuestionProperty() As Integer
        Get
            Return _QuestionProperty.Count
        End Get
    End Property

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
    ''' 属性のキー情報を返します。
    ''' </summary>
    Public ReadOnly Property KeysImage() As ICollection
        Get
            Return _image.Keys
        End Get
    End Property

    ''' <summary>
    ''' 初回の正解を設定/取得します。
    ''' </summary>
    Public Property FirstAnsewr() As String
        Get
            Return _firstAnsewr
        End Get
        Set(ByVal value As String)
            _firstAnsewr = value
        End Set
    End Property

    ''' <summary>
    ''' 再受験の正解を設定/取得します。
    ''' </summary>
    Public Property SecondAnsewr() As String
        Get
            Return _secondAnsewr
        End Get
        Set(ByVal value As String)
            _secondAnsewr = value
        End Set
    End Property

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

    ''' <summary>
    ''' 再受験用解説を取得/設定します。
    ''' </summary>
    Public Property ReTestComment() As String
        Get
            Return _reTestComment
        End Get
        Set(ByVal value As String)
            _reTestComment = value
        End Set
    End Property

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

#Region "メソッド"
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
    Public Function DeepCopy() As QuestionBank
        Dim questionbank As QuestionBank = DirectCast(Me.Clone(), QuestionBank)

        questionbank._QuestionProperty = DirectCast(Me._QuestionProperty.Clone, Hashtable)
        questionbank._choiceMark = DirectCast(Me._choiceMark.Clone, ArrayList)
        questionbank._image = DirectCast(Me._image.Clone, Hashtable)

        Return questionbank
    End Function

    ''' <summary>
    ''' 属性のキー情報を削除します。
    ''' </summary>  
    ''' <param name="key"></param>
    Public Sub RemoveQuestionProperty(ByVal key As String)
        _QuestionProperty.Remove(key)
    End Sub

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
        _choiceMark.Add({StrConv(value.Substring(0, 1), VbStrConv.Wide), StrConv(value.Substring(1, 1), VbStrConv.Wide)})
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
            HtmlElement.InnerText, "(^[" & Constant.CST_SELECTMARK & "]{2}$)|(^[" & Constant.CST_SELECTMARK & "]$)")
            If mcsAnswer.Count > 0 Then
                AnswerText += mcsAnswer.Item(0).ToString
            End If
        Next

        If AnswerText.Length = 2 Then
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
            FirstAnsewr = StrConv(AnswerText.Substring(0, 1), VbStrConv.Wide)
            SecondAnsewr = StrConv(AnswerText.Substring(1, 1), VbStrConv.Wide)
        End If

        '選択肢
        Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches( _
        innterText, "^[" & Constant.CST_SELECTMARK & "]{2}")

        '選択肢記号
        If mcsSelect.Count > 0 Then
            AddChoiceMark(mcsSelect.Item(0).Value)
        End If

    End Function

    ''' <summary>
    ''' 再受験用解説を追加します。
    ''' </summary>
    Public Sub AddReTestComment(ByVal value As String)
        _reTestComment &= value
    End Sub

    ''' <summary>
    ''' すべての情報を削除します。
    ''' </summary>
    Public Sub RemoveAll()
        _QuestionProperty.Clear()
        _choiceMark.Clear()
        _question = String.Empty
        _choice = String.Empty
        _comment = String.Empty
        _reTestComment = String.Empty
        _image.Clear()
        _firstAnsewr = String.Empty
        _secondAnsewr = String.Empty
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
        strHtml &= Choice()
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

    ''' <summary>
    ''' 再受験用解説のHTMLを取得します。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetReTestCommentHtml() As String
        Dim strHtml As String = ""
        strHtml &= "<html onCopy=""return false"" onContextmenu=""return false"" onselectstart=""return false"">"
        strHtml &= HeadTag
        strHtml &= BodyTag
        strHtml &= DivTag
        strHtml &= ReTestComment()
        strHtml &= "</div>"
        strHtml &= "</body>"
        strHtml &= "</html>"
        Return strHtml
    End Function
#End Region

End Class
