Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' 演習問題バンクのコレクション
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class PracticeQuestionBankCollection
    Inherits System.Collections.CollectionBase
    Public Sub Add(ByVal questionbank As PracticeQuestionBank)
        List.Add(questionbank)
    End Sub
    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            List.RemoveAt(index)
        End If
    End Sub
    Public ReadOnly Property Item(ByVal index As Integer) As PracticeQuestionBank
        Get
            Return CType(List.Item(index), PracticeQuestionBank)
        End Get
    End Property
End Class