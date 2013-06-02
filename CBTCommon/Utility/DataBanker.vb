Public Class DataBanker
    Private Shared ReadOnly _instance As New DataBanker()

    Private _holder As IDictionary = New Hashtable()

    'シングルトン  
    Private Sub New()
    End Sub

    ''' <summary>  
    ''' 自身のインスタンスを取得します。  
    ''' </summary>  
    ''' <returns></returns>  
    Public Shared Function GetInstance() As DataBanker
        Return _instance
    End Function

    ''' <summary>  
    ''' インデクサ  
    ''' キーを元にデータを取得する  
    ''' </summary>  
    Default Public Property Item(ByVal key As Object) As Object
        Get
            Return _holder(key)
        End Get
        Set(ByVal value As Object)
            If _holder.Contains(key) Then
                ' 重複する場合は削除  
                _holder.Remove(key)
            End If
            _holder(key) = value
        End Set
    End Property

    ''' <summary>  
    ''' keyの情報を削除します。  
    ''' </summary>  
    ''' <param name="key"></param>  
    Public Sub Remove(ByVal key As String)
        _holder.Remove(key)
    End Sub

    ''' <summary>  
    ''' すべての情報を削除します。  
    ''' </summary>  
    Public Sub RemoveAll()
        _holder.Clear()
    End Sub

    ''' <summary>  
    '''　キーの情報を返します。  
    ''' </summary>  
    Public ReadOnly Property Keys() As ICollection
        Get
            Return _holder.Keys
        End Get
    End Property

    ''' <summary>  
    '''　キーの情報を返します。  
    ''' </summary>  
    Public ReadOnly Property count() As Integer
        Get
            Return _holder.Count
        End Get
    End Property
End Class