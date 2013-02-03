
''' <summary>
''' 問題解答データのコンテナ
''' </summary>
''' <remarks></remarks>
Public Class ResultDataContainer

#Region "----- メンバ変数 -----"

    ''' <summary>問題コードと解答データのマップ</summary>
    Private _ResultDataMap As New Dictionary(Of String, ResultData)

#End Region

#Region "----- プロパティ -----"

    ''' <summary>
    ''' インデクサ
    ''' </summary>
    ''' <param name="questionCode">問題コード</param>
    ''' <value>問題解答オブジェクト</value>
    ''' <returns>問題解答オブジェクト</returns>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal questionCode As String) As ResultData
        Get
            Dim resultData As ResultData = Nothing
            If _ResultDataMap.ContainsKey(questionCode) Then
                resultData = _ResultDataMap(questionCode)
            End If
            Return resultData
        End Get
        Set(value As ResultData)
            If _ResultDataMap.ContainsKey(questionCode) Then
                _ResultDataMap(questionCode) = value
            Else
                _ResultDataMap.Add(questionCode, value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' 問題コードと解答データのマップの取得を行います。
    ''' キーは問題コード、値は結果データ
    ''' </summary>
    ''' <value>問題コードと解答データのマップ</value>
    ''' <returns>問題コードと解答データのマップ</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ResultDataMap As Dictionary(Of String, ResultData)
        Get
            Return _ResultDataMap
        End Get
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 結果データのクリアを行います。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        _ResultDataMap.Clear()
    End Sub

#End Region

End Class
