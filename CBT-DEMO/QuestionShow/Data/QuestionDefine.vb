''' <summary>
''' 問題定義クラス
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefine

#Region "----- メンバ変数 -----"
    ''' <summary>
    ''' 問題番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionNumber As Integer = 0

    ''' <summary>
    ''' 中問かどうか
    ''' </summary>
    ''' <remarks></remarks>
    Private _IsMiddleQuestion As Boolean = False

    ''' <summary>
    ''' 中問番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleQuestionNumber As String = String.Empty

    ''' <summary>
    ''' 親カテゴリID
    ''' </summary>
    ''' <remarks></remarks>
    Private _ParentCategoryID As Integer = 0

    ''' <summary>
    ''' 大分類名
    ''' </summary>
    ''' <remarks></remarks>
    Private _LargeCategoryName As String = String.Empty

    ''' <summary>
    ''' カテゴリID
    ''' </summary>
    ''' <remarks></remarks>
    Private _CategoryID As Integer = 0

    ''' <summary>
    ''' 中分類名
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleCategoryName As String = String.Empty

    ''' <summary>
    ''' 問題テーマ
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionTheme As String = String.Empty

    ''' <summary>
    ''' 中問用設問ファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleQuestionFilePath As String = String.Empty

    ''' <summary>
    ''' 中問内のインデックス
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleQuestionIndex As Integer = 0

    ''' <summary>
    ''' 初回用小問の設問＋選択肢のファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _FirstSmallQuestionFilePath As String = String.Empty

    ''' <summary>
    ''' 再試験用小問の設問＋選択肢のファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _SecondSmallQuestionFilePath As String = String.Empty

    ''' <summary>
    ''' 初回試験用の解説ファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _FirstCommentFilePath As String = String.Empty

    ''' <summary>
    ''' 再試験用の解説ファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _SecondCommentFilePath As String = String.Empty

    ''' <summary>
    ''' 初回正解答
    ''' </summary>
    ''' <remarks></remarks>
    Private _FirstAnswer As String = String.Empty

    ''' <summary>
    ''' 再試験正解答
    ''' </summary>
    ''' <remarks></remarks>
    Private _SecondAnswer As String = String.Empty
#End Region

#Region "----- プロパティ -----"
    ''' <summary>
    ''' 問題番号の取得、設定を行います。
    ''' </summary>
    ''' <value>問題番号</value>
    ''' <returns>問題番号</returns>
    ''' <remarks></remarks>
    Public Property QuestionNumber As Integer
        Get
            Return _QuestionNumber
        End Get
        Set(value As Integer)
            _QuestionNumber = value
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
    ''' 初回用小問の設問＋選択肢のファイルのパスの取得、設定を行います。
    ''' </summary>
    ''' <value>初回用小問の設問＋選択肢のファイルのパス</value>
    ''' <returns>初回用小問の設問＋選択肢のファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property FirstSmallQuestionFilePath As String
        Get
            Return _FirstSmallQuestionFilePath
        End Get
        Set(value As String)
            _FirstSmallQuestionFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 再試験用小問の設問＋選択肢のファイルのパスの取得、設定を行います。
    ''' </summary>
    ''' <value>再試験用小問の設問＋選択肢のファイルのパス</value>
    ''' <returns>再試験用小問の設問＋選択肢のファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property SecondSmallQuestionFilePath As String
        Get
            Return _SecondSmallQuestionFilePath
        End Get
        Set(value As String)
            _SecondSmallQuestionFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 初回用解説ファイルのパスを取得、設定を行います。
    ''' </summary>
    ''' <value>初回用解説ファイルのパス</value>
    ''' <returns>初回用解説ファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property FirstCommentFilePath As String
        Get
            Return _FirstCommentFilePath
        End Get
        Set(value As String)
            _FirstCommentFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 再試験用解説ファイルのパスを取得、設定を行います。
    ''' </summary>
    ''' <value>再試験用解説ファイルのパス</value>
    ''' <returns>再試験用解説ファイルのパス</returns>
    ''' <remarks></remarks>
    Public Property SecondCommentFilePath As String
        Get
            Return _SecondCommentFilePath
        End Get
        Set(value As String)
            _SecondCommentFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' 初回正解答の取得、設定を行います。
    ''' </summary>
    ''' <value>初回正解答</value>
    ''' <returns>初回正解答</returns>
    ''' <remarks></remarks>
    Public Property FirstAnswer As String
        Get
            Return _FirstAnswer
        End Get
        Set(value As String)
            _FirstAnswer = value
        End Set
    End Property

    ''' <summary>
    ''' 再試験正解答の取得、設定を行います。
    ''' </summary>
    ''' <value>再試験正解答</value>
    ''' <returns>再試験正解答</returns>
    ''' <remarks></remarks>
    Public Property SecondAnswer As String
        Get
            Return _SecondAnswer
        End Get
        Set(value As String)
            _SecondAnswer = value
        End Set
    End Property
#End Region

#Region "----- メソッド -----"

#Region "コンストラクタ"
    Public Sub New()
    End Sub
#End Region

#Region "デバッグ用文字列処理"
    ''' <summary>
    ''' データ列定義をカンマ区切りの文字列で取得します。(debug dump 用)
    ''' </summary>
    ''' <returns>データ列定義のカンマ区切りの文字列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetColmunNames() As String
        Return "問題番号,中問かどうか,中問番号,親分類コード,大分類名,分類コード,中分類名,問題テーマ,中問設問ファイル,中問内インデックス,初回用小問ファイル,再試験用小問ファイル,初回試験用解説ファイル,再試験用解説ファイル,正解答(初回),正解答(再試験)" & vbCrLf
    End Function

    ''' <summary>
    ''' 問題定義オブジェクトを文字列に変換します。(debug dump 用)
    ''' </summary>
    ''' <returns>問題定義オブジェクト文字列</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim ret As String = String.Empty

        ret &= _QuestionNumber.ToString() & ","
        ret &= _IsMiddleQuestion.ToString() & ","
        ret &= _MiddleQuestionNumber & ","
        ret &= _ParentCategoryID.ToString() & ","
        ret &= _LargeCategoryName & ","
        ret &= _CategoryID.ToString() & ","
        ret &= _MiddleCategoryName & ","
        ret &= _QuestionTheme & ","
        ret &= _MiddleQuestionFilePath & ","
        ret &= _MiddleQuestionIndex.ToString & ","
        ret &= _FirstSmallQuestionFilePath & ","
        ret &= _SecondSmallQuestionFilePath & ","
        ret &= _FirstCommentFilePath & ","
        ret &= _SecondCommentFilePath & ","
        ret &= _FirstAnswer & ","
        ret &= _SecondAnswer

        Return ret
    End Function
#End Region

#End Region

End Class
