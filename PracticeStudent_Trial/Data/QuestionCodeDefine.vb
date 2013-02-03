Public Class QuestionCodeDefine

#Region "----- メンバ変数 -----"

    ''' <summary>問題コード</summary>
    Private _QuestionCode As String = ""
    ''' <summary>中問コード</summary>
    Private _MiddleQuestionCode As String = ""
    ''' <summary>ダウンロード状態</summary>
    Private _DownloadState As Integer = 0
    ''' <summary>ダウンロード状態インデックス</summary>
    Public Enum DownloadStateIndex As Integer
        ''' <summary>ダウンロード未完了</summary>
        NotDownload = 0
        ''' <summary>ダウンロード完了</summary>
        FixDownload
        ''' <summary>ダウンロードエラー</summary>
        ErrorDownload
    End Enum
#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 問題コードの取得・設定
    ''' </summary>
    ''' <value>問題コード</value>
    ''' <returns>問題コード</returns>
    ''' <remarks></remarks>
    Public Property QuestionCode As String
        Get
            Return _QuestionCode
        End Get
        Set(ByVal value As String)
            _QuestionCode = value
        End Set
    End Property

    ''' <summary>
    ''' 中問コードの取得・設定
    ''' </summary>
    ''' <value>中問コード</value>
    ''' <returns>中問コード</returns>
    ''' <remarks></remarks>
    Public Property MiddleQuestionCode As String
        Get
            Return _MiddleQuestionCode
        End Get
        Set(ByVal value As String)
            _MiddleQuestionCode = value
        End Set
    End Property

    ''' <summary>
    ''' ダウンロード状態の取得・設定
    ''' </summary>
    ''' <value>ダウンロード状態</value>
    ''' <returns>ダウンロード状態</returns>
    ''' <remarks></remarks>
    Public Property DownloadState As Integer
        Get
            Return _DownloadState
        End Get
        Set(ByVal value As Integer)
            _DownloadState = value
        End Set
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 中問題の主文の問題コード
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsMiddleMainQuestion() As Boolean
        Dim blnRet As Boolean = False

        Try
            If _MiddleQuestionCode <> "" AndAlso _QuestionCode = _MiddleQuestionCode Then
                blnRet = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return blnRet
    End Function

#End Region

End Class
