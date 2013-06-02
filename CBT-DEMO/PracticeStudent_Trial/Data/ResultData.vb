
''' <summary>
''' 結果データ
''' </summary>
''' <remarks></remarks>
Public Class ResultData

#Region "----- メンバ変数 -----"

    ''' <summary>解答</summary>
    Private _Answer As String
    ''' <summary>見直しチェック状態</summary>
    Private _Check As Boolean

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' 解答の取得、設定を行います。
    ''' </summary>
    ''' <value>解答</value>
    ''' <returns>解答</returns>
    ''' <remarks></remarks>
    Public Property Answer As String
        Get
            Return _Answer
        End Get
        Set(value As String)
            _Answer = value
        End Set
    End Property

    ''' <summary>
    ''' 見直しチェック状態の取得、設定を行います。
    ''' </summary>
    ''' <value>見直しチェック状態</value>
    ''' <returns>見直しチェック状態</returns>
    ''' <remarks></remarks>
    Public Property Check As Boolean
        Get
            Return _Check
        End Get
        Set(value As Boolean)
            _Check = value
        End Set
    End Property

#End Region

End Class
