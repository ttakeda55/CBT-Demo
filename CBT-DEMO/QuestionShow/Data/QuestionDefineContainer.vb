''' <summary>
''' 問題定義オブジェクト保持コンテナ
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefineContainer

#Region "----- メンバ変数 -----"
    ''' <summary>
    ''' 問題番号と問題定義のマップ
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionDefineMap As New Dictionary(Of Integer, QuestionDefine)
#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 全問題定義オブジェクトのマップの取得を行います。
    ''' キーは問題番号(1～100を想定)、値は問題定義オブジェクト
    ''' </summary>
    ''' <value>問題定義オブジェクトのマップ</value>
    ''' <returns>問題定義オブジェクトのマップ</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property QuestionDefineMap As Dictionary(Of Integer, QuestionDefine)
        Get
            Return _QuestionDefineMap
        End Get
    End Property

    ''' <summary>
    ''' インデクサ
    ''' </summary>
    ''' <param name="questionNumber">問題番号</param>
    ''' <value>問題定義オブジェクト</value>
    ''' <returns>問題定義オブジェクト</returns>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal questionNumber As Integer) As QuestionDefine
        Get
            Dim defineData As QuestionDefine = Nothing
            If _QuestionDefineMap.ContainsKey(questionNumber) Then
                defineData = _QuestionDefineMap(questionNumber)
            End If

            Return defineData
        End Get
        Set(value As QuestionDefine)
            If _QuestionDefineMap.ContainsKey(questionNumber) Then
                _QuestionDefineMap(questionNumber) = value
            Else
                _QuestionDefineMap.Add(questionNumber, value)
            End If
        End Set
    End Property
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' 問題定義オブジェクトを追加します。
    ''' </summary>
    ''' <param name="questionNumber">問題番号(key)</param>
    ''' <param name="questionDefine">問題定義オブジェクト(value)</param>
    ''' <remarks></remarks>
    Public Sub AddQustionDefine(ByVal questionNumber As Integer, ByVal questionDefine As QuestionDefine)
        _QuestionDefineMap.Add(questionNumber, questionDefine)
    End Sub

    ''' <summary>
    ''' 問題定義オブジェクトを削除します。
    ''' </summary>
    ''' <param name="questionNumber">削除する問題番号</param>
    ''' <remarks></remarks>
    Public Sub RemoveQustionDefine(ByVal questionNumber As Integer)
        _QuestionDefineMap.Remove(questionNumber)
    End Sub

    ''' <summary>
    ''' 問題定義オブジェクトを文字列に変換します。(debug dump 用)
    ''' </summary>
    ''' <returns>問題定義オブジェクトの文字列</returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim ret As String = QuestionDefine.GetColmunNames()

        For Each questionDefine In _QuestionDefineMap
            ret &= questionDefine.Value.ToString() & vbCrLf
        Next

        Return ret
    End Function
#End Region

End Class
