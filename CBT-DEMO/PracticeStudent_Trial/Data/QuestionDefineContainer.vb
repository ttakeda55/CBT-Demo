
''' <summary>
''' 問題定義オブジェクト保持コンテナ
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefineContainer

#Region "----- メンバ変数 -----"

    ''' <summary>問題コードと問題定義のマップ</summary>
    Private _QuestionDefineMap As New Generic.Dictionary(Of String, QuestionDefine)

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 全問題定義オブジェクトのマップの取得を行います。
    ''' キーは問題コード、値は問題定義オブジェクト
    ''' </summary>
    ''' <value>問題定義オブジェクトのマップ</value>
    ''' <returns>問題定義オブジェクトのマップ</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property QuestionDefineMap As Dictionary(Of String, QuestionDefine)
        Get
            Return _QuestionDefineMap
        End Get
    End Property

    ''' <summary>
    ''' インデクサ
    ''' </summary>
    ''' <param name="questionCode">問題コード</param>
    ''' <value>問題定義オブジェクト</value>
    ''' <returns>問題定義オブジェクト</returns>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal questionCode As String) As QuestionDefine
        Get
            Dim defineData As QuestionDefine = Nothing
            If _QuestionDefineMap.ContainsKey(questionCode) Then
                defineData = _QuestionDefineMap(questionCode)
            End If

            Return defineData
        End Get
        Set(value As QuestionDefine)
            If _QuestionDefineMap.ContainsKey(questionCode) Then
                _QuestionDefineMap(questionCode) = value
            Else
                _QuestionDefineMap.Add(questionCode, value)
            End If
        End Set
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 問題定義オブジェクトを追加します。
    ''' </summary>
    ''' <param name="questionCode">問題コード(key)</param>
    ''' <param name="questionDefine">問題定義オブジェクト(value)</param>
    ''' <remarks></remarks>
    Public Sub AddQustionDefine(ByVal questionCode As String, ByVal questionDefine As QuestionDefine)
        _QuestionDefineMap.Add(questionCode, questionDefine)
    End Sub

    ''' <summary>
    ''' 問題定義オブジェクトを削除します。
    ''' </summary>
    ''' <param name="questionCode">削除する問題コード</param>
    ''' <remarks></remarks>
    Public Sub RemoveQustionDefine(ByVal questionCode As String)
        _QuestionDefineMap.Remove(questionCode)
    End Sub

    ''' <summary>
    ''' 問題定義オブジェクトマップのクリアを行います。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        _QuestionDefineMap.Clear()
    End Sub

#End Region

End Class
