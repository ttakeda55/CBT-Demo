''' <summary>
''' 問題定義オブジェクト保持コンテナ
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefineContainer

#Region "----- メンバ変数 -----"
    ''' <summary>DataManagerインスタンス</summary>
    Private Shared _instance As New QuestionDefineContainer
    ''' <summary>
    ''' 問題番号と問題定義のマップ
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionDefineMap As New Dictionary(Of String, QuestionDefine)
#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 全問題定義オブジェクトのマップの取得を行います。
    ''' キーは問題番号(1～100を想定)、値は問題定義オブジェクト
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
    ''' <param name="questionCode">問題番号</param>
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
    ''' <summary>  
    ''' 全問題定義オブジェクトのマップの取得を削除します。  
    ''' </summary>  
    Public Sub Remove()
        _QuestionDefineMap.Clear()
    End Sub
#End Region

#Region "----- メソッド -----"
    Public Shared Function GetInstance() As QuestionDefineContainer
        Return _instance
    End Function

    ''' <summary>
    ''' 問題定義オブジェクトを追加します。
    ''' </summary>
    ''' <param name="questionCode">問題番号(key)</param>
    ''' <param name="questionDefine">問題定義オブジェクト(value)</param>
    ''' <remarks></remarks>
    Public Sub AddQustionDefine(ByVal questionCode As String, ByVal questionDefine As QuestionDefine)
        _QuestionDefineMap.Add(questionCode, questionDefine)
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
