''' <summary>
''' 問題解答データのコンテナ
''' </summary>
''' <remarks></remarks>
Public Class ResultDataContainer

#Region "----- メンバ変数 -----"
    ''' <summary>
    ''' 問題番号と解答データのマップ
    ''' </summary>
    ''' <remarks></remarks>
    Private _ResultDataMap As New Dictionary(Of Integer, ResultData)
#End Region

#Region "----- プロパティ -----"
    ''' <summary>
    ''' インデクサ
    ''' </summary>
    ''' <param name="questionNumber">問題番号</param>
    ''' <value>問題解答オブジェクト</value>
    ''' <returns>問題解答オブジェクト</returns>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal questionNumber As Integer) As ResultData
        Get
            Dim resultData As ResultData = Nothing
            If _ResultDataMap.ContainsKey(questionNumber) Then
                resultData = _ResultDataMap(questionNumber)
            End If

            Return resultData
        End Get
        Set(value As ResultData)
            If _ResultDataMap.ContainsKey(questionNumber) Then
                _ResultDataMap(questionNumber) = value
            Else
                _ResultDataMap.Add(questionNumber, value)
            End If
        End Set
    End Property
#End Region

#Region "メソッド"
    ''' <summary>
    ''' 結果データのクリアを行います。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        _ResultDataMap.Clear()
    End Sub
#End Region



End Class
