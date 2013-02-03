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
    Private _QuestionCode As String = ""

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
    ''' 中問用設問ファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleQuestionFilePath As String = String.Empty

    ''' <summary>
    ''' 中問内のインデックス
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionCodeInMiddleQuestion As String = String.Empty

    ''' <summary>
    ''' 小問の設問＋選択肢のファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _SmallQuestionFilePath As String = String.Empty

    ''' <summary>
    ''' 解説ファイルのパス
    ''' </summary>
    ''' <remarks></remarks>
    Private _CommentFilePath As String = String.Empty

    ''' <summary>
    ''' 正解答
    ''' </summary>
    ''' <remarks></remarks>
    Private _Answer As String = String.Empty

#End Region

#Region "----- プロパティ -----"
    ''' <summary>
    ''' 問題番号の取得、設定を行います。
    ''' </summary>
    ''' <value>問題番号</value>
    ''' <returns>問題番号</returns>
    ''' <remarks></remarks>
    Public Property QuestionCode As String
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
    Public Property QuestionCodeInMiddleQuestion As String
        Get
            Return _QuestionCodeInMiddleQuestion
        End Get
        Set(value As String)
            _QuestionCodeInMiddleQuestion = value
        End Set
    End Property

    ''' <summary>
    ''' 小問の設問＋選択肢のファイルのパスの取得、設定を行います。
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
    ''' <value>初回正解答</value>
    ''' <returns>初回正解答</returns>
    ''' <remarks></remarks>
    Public Property Answer As String
        Get
            Return _Answer
        End Get
        Set(value As String)
            _Answer = value
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

        ret &= _QuestionCode.ToString() & ","
        ret &= _IsMiddleQuestion.ToString() & ","
        ret &= _MiddleQuestionNumber & ","
        ret &= _MiddleQuestionFilePath & ","
        ret &= QuestionCodeInMiddleQuestion.ToString & ","
        ret &= _SmallQuestionFilePath & ","
        ret &= _CommentFilePath & ","
        ret &= _Answer

        Return ret
    End Function
#End Region

#End Region

End Class
