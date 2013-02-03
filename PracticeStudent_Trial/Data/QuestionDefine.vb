
''' <summary>
''' 問題定義クラス
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefine

#Region "----- メンバ変数 -----"

    ''' <summary>問題番号</summary>
    Private _QuestionCode As String = ""
    ''' <summary>中問かどうか</summary>
    Private _IsMiddleQuestion As Boolean = False
    ''' <summary>中問番号</summary>
    Private _MiddleQuestionNumber As String = String.Empty
    ''' <summary>中問テーマ</summary>
    Private _MiddleQuestionTheme As String = String.Empty
    ''' <summary>親カテゴリID</summary>
    Private _ParentCategoryID As Integer = 0
    ''' <summary>大分類名</summary>
    Private _LargeCategoryName As String = String.Empty
    ''' <summary>カテゴリID</summary>
    Private _CategoryID As Integer = 0
    ''' <summary>中分類名</summary>
    Private _MiddleCategoryName As String = String.Empty
    ''' <summary>問題テーマ</summary>
    Private _QuestionTheme As String = String.Empty
    ''' <summary>中問用設問ファイルのパス</summary>
    Private _MiddleQuestionFilePath As String = String.Empty
    ''' <summary>中問内のインデックス</summary>
    Private _MiddleQuestionIndex As Integer = 0
    ''' <summary>小問の設問＋選択肢のファイルのパス</summary>
    Private _SmallQuestionFilePath As String = String.Empty
    ''' <summary>解説ファイルのパス</summary>
    Private _CommentFilePath As String = String.Empty
    ''' <summary>正解答</summary>
    Private _Answer As String = String.Empty
    ''' <summary>再演習</summary>
    Private _Review As Boolean = False
    ''' <summary>動物看護師問題オリジナル</summary>
    Private _QuestionOrignal As Common.VetNurseQuestionBank

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 問題コードの取得、設定を行います。
    ''' </summary>
    ''' <value>問題番号</value>
    ''' <returns>問題番号</returns>
    ''' <remarks></remarks>
    Public Property QuestionNumber As String
        Get
            Return _QuestionCode
        End Get
        Set(value As String)
            _QuestionCode = value
        End Set
    End Property

    ''' <summary>
    ''' 中問かどうかを取得、設定を行います。
    ''' </summary>
    ''' <value>中問かどうか</value>
    ''' <returns>中問かどうか</returns>
    ''' <remarks></remarks>
    Public Property IsMiddleQuestion As Boolean
        Get
            Return _IsMiddleQuestion
        End Get
        Set(value As Boolean)
            _IsMiddleQuestion = value
        End Set
    End Property

    ''' <summary>
    ''' 中問番号の取得、設定を行います。
    ''' </summary>
    ''' <value>中問番号</value>
    ''' <returns>中問番号</returns>
    ''' <remarks></remarks>
    Public Property MiddleQuestionNumber As String
        Get
            Return _MiddleQuestionNumber
        End Get
        Set(value As String)
            _MiddleQuestionNumber = value
        End Set
    End Property

    ''' <summary>
    ''' 中問テーマの取得、設定を行います。
    ''' </summary>
    ''' <value>中問テーマ</value>
    ''' <returns>中問テーマ</returns>
    ''' <remarks></remarks>
    Public Property MiddleQuestionTheme As String
        Get
            Return _MiddleQuestionTheme
        End Get
        Set(ByVal value As String)
            _MiddleQuestionTheme = value
        End Set
    End Property

    ''' <summary>
    ''' 親カテゴリIDの取得、設定を行います。
    ''' </summary>
    ''' <value>親カテゴリID</value>
    ''' <returns>親カテゴリID</returns>
    ''' <remarks></remarks>
    Public Property ParentCategoryID As Integer
        Get
            Return _ParentCategoryID
        End Get
        Set(value As Integer)
            _ParentCategoryID = value
        End Set
    End Property

    ''' <summary>
    ''' 大分類名の取得、設定を行います。
    ''' </summary>
    ''' <value>大分類名</value>
    ''' <returns>大分類名</returns>
    ''' <remarks></remarks>
    Public Property LargeCategoryName As String
        Get
            Return _LargeCategoryName
        End Get
        Set(value As String)
            _LargeCategoryName = value
        End Set
    End Property

    ''' <summary>
    ''' カテゴリIDの取得、設定を行います。
    ''' </summary>
    ''' <value>カテゴリID</value>
    ''' <returns>カテゴリID</returns>
    ''' <remarks></remarks>
    Public Property CategoryID As Integer
        Get
            Return _CategoryID
        End Get
        Set(value As Integer)
            _CategoryID = value
        End Set
    End Property

    ''' <summary>
    ''' 中分類名の取得、設定を行います。
    ''' </summary>
    ''' <value>中分類名</value>
    ''' <returns>中分類名</returns>
    ''' <remarks></remarks>
    Public Property MiddleCategoryName As String
        Get
            Return _MiddleCategoryName
        End Get
        Set(value As String)
            _MiddleCategoryName = value
        End Set
    End Property

    ''' <summary>
    ''' 問題テーマの取得、設定を行います。
    ''' </summary>
    ''' <value>問題テーマ</value>
    ''' <returns>問題テーマ</returns>
    ''' <remarks></remarks>
    Public Property QuestionTheme As String
        Get
            Return _QuestionTheme
        End Get
        Set(value As String)
            _QuestionTheme = value
        End Set
    End Property

    ''' <summary>
    ''' 中問設問ファイルのパスを取得、設定を行います。
    ''' </summary>
    ''' <value>中問設問ファイルのパス</value>
    ''' <returns>中問設問ファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property MiddleQuestionFilePath As String
        Get
            Return _MiddleQuestionFilePath
        End Get
        Set(value As String)
            _MiddleQuestionFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 中問内インデックスの取得、設定を行います。
    ''' </summary>
    ''' <value>中問内インデックス</value>
    ''' <returns>中問内インデックス</returns>
    ''' <remarks></remarks>
    Public Property MiddleQuestionIndex As Integer
        Get
            Return _MiddleQuestionIndex
        End Get
        Set(value As Integer)
            _MiddleQuestionIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 小問設問＋選択肢のファイルのパスの取得、設定を行います。
    ''' </summary>
    ''' <value>小問の設問＋選択肢のファイルのパス</value>
    ''' <returns>小問の設問＋選択肢のファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property SmallQuestionFilePath As String
        Get
            Return _SmallQuestionFilePath
        End Get
        Set(value As String)
            _SmallQuestionFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 解説ファイルのパスを取得、設定を行います。
    ''' </summary>
    ''' <value>解説ファイルのパス</value>
    ''' <returns>解説ファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property CommentFilePath As String
        Get
            Return _CommentFilePath
        End Get
        Set(value As String)
            _CommentFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 正解答の取得、設定を行います。
    ''' </summary>
    ''' <value>正解答</value>
    ''' <returns>正解答</returns>
    ''' <remarks></remarks>
    Public Property Answer As String
        Get
            Return _Answer
        End Get
        Set(value As String)
            _Answer = value
        End Set
    End Property

    ''' <summary>
    ''' 再演習の取得、設定を行います。
    ''' </summary>
    ''' <value>再演習</value>
    ''' <returns>再演習</returns>
    ''' <remarks></remarks>
    Public Property Review As Boolean
        Get
            Return _Review
        End Get
        Set(value As Boolean)
            _Review = value
        End Set
    End Property

    ''' <summary>
    ''' 問題オリジナル
    ''' </summary>
    ''' <value>再演習</value>
    ''' <returns>再演習</returns>
    ''' <remarks></remarks>
    Public Property QuestionOrignal As Common.VetNurseQuestionBank
        Get
            Return _QuestionOrignal
        End Get
        Set(value As Common.VetNurseQuestionBank)
            _QuestionOrignal = value
        End Set
    End Property

#End Region

#Region "----- メソッド -----"

#Region "----- コンストラクタ  -----"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

#End Region

#End Region

End Class
