Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' 演習問題バンクのコレクション
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class VetnurseQuestionBankCollection
    Inherits System.Collections.CollectionBase
    ' ''' <summary>問題コードと問題定義のマップ</summary>
    'Private _QuestionDefineMap As New Generic.Dictionary(Of String, VetNurseQuestionBank)
    ' ''' <summary>
    ' ''' 全問題定義オブジェクトのマップの取得を行います。
    ' ''' キーは問題コード、値は問題定義オブジェクト
    ' ''' </summary>
    ' ''' <value>問題定義オブジェクトのマップ</value>
    ' ''' <returns>問題定義オブジェクトのマップ</returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property QuestionDefineMap As Dictionary(Of String, VetNurseQuestionBank)
    '    Get
    '        Return _QuestionDefineMap
    '    End Get
    'End Property
    Public Sub Add(ByVal questionbank As VetNurseQuestionBank)
        List.Add(questionbank)
    End Sub
    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            List.RemoveAt(index)
        End If
    End Sub
    Public ReadOnly Property Item(ByVal index As Integer) As VetNurseQuestionBank
        Get
            Return CType(List.Item(index), PracticeQuestionBank)
        End Get
    End Property
    ' ''' <summary>
    ' ''' インデクサ
    ' ''' </summary>
    ' ''' <param name="questionCode">問題コード</param>
    ' ''' <value>問題定義オブジェクト</value>
    ' ''' <returns>問題定義オブジェクト</returns>
    ' ''' <remarks></remarks>
    'Public Property Item(ByVal questionCode As String) As VetNurseQuestionBank
    '    Get
    '        Dim defineData As VetNurseQuestionBank = Nothing
    '        If _QuestionDefineMap.ContainsKey(questionCode) Then
    '            defineData = _QuestionDefineMap(questionCode)
    '        End If

    '        Return defineData
    '    End Get
    '    Set(value As VetNurseQuestionBank)
    '        If _QuestionDefineMap.ContainsKey(questionCode) Then
    '            _QuestionDefineMap(questionCode) = value
    '        Else
    '            _QuestionDefineMap.Add(questionCode, value)
    '        End If
    '    End Set
    'End Property

    'Public Sub makeMap()
    '    For Each QuestionBank As VetNurseQuestionBank In List
    '        _QuestionDefineMap.Add(QuestionBank.QuestionCode, QuestionBank)
    '    Next
    'End Sub
End Class