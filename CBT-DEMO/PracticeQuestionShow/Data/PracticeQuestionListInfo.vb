Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' 演習問題リスト情報コレクション
''' </summary>
''' <remarks></remarks>
Public Class PraciticeQuestionInfoCollection
    Inherits System.Collections.CollectionBase
    Public Sub Add(ByVal questionbank As PraciticeQuestionInfo)
        List.Add(questionbank)
    End Sub
    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            List.RemoveAt(index)
        End If
    End Sub
    Public ReadOnly Property Item(ByVal index As Integer) As PraciticeQuestionInfo
        Get
            Return CType(List.Item(index), PraciticeQuestionInfo)
        End Get
    End Property
End Class

''' <summary>
''' 演習問題リスト情報
''' </summary>
''' <remarks></remarks>
Public Class PraciticeQuestionInfo

#Region "----- メンバ変数 -----"
    ''' <summary>
    ''' 問題コード
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionCode As String = ""
    ''' <summary>
    ''' 中問題番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _MiddleQuestionCode As String = ""
    ''' <summary>
    ''' 中問かどうか
    ''' </summary>
    ''' <remarks></remarks>
    Private _IsMiddleQuestion As Boolean = False
    ''' <summary>
    ''' 問番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _QuestionNo As String = ""
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
    Public Property MiddleQuestionCode As String
        Get
            Return _MiddleQuestionCode
        End Get
        Set(value As String)
            _MiddleQuestionCode = value
        End Set
    End Property

    ''' <summary>
    ''' 問番号の取得、設定を行います。
    ''' </summary>
    ''' <value>問番号</value>
    ''' <returns>問番号</returns>
    ''' <remarks></remarks>
    Public Property QuestionNo As String
        Get
            Return _QuestionNo
        End Get
        Set(value As String)
            _QuestionNo = value
        End Set
    End Property
#End Region

End Class
