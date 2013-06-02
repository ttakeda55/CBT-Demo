
''' <summary>
''' 入力チェックを行う
''' </summary>
''' <remarks></remarks>
Public Class InputCheck

    ''' <summary>
    ''' 数値チェックを行う。
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="messageParam"></param>
    ''' <returns></returns>
    ''' <remarks>エラーメッセージを表示する。</remarks>
    Public Shared Function NumericCheck(ByVal value As String, ByVal messageParam As String) As Boolean
        NumericCheck = False

        If Not IsNumeric(value) Then
            Common.Message.MessageShow("E074", {messageParam})
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 正解率の範囲チェックを行う。
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="messageParam"></param>
    ''' <returns></returns>
    ''' <remarks>エラーメッセージを表示する。</remarks>
    Public Shared Function RateRangeCheck(ByVal value As String, ByVal messageParam As String) As Boolean
        RateRangeCheck = False

        If value = "" Then
            Return True
        End If

        If Not NumericCheck(value, messageParam) Then Return False

        If value > 100 Then
            Common.Message.MessageShow("E075", {messageParam, "100%"})
            Return False
        End If

        If value < 0 Then
            Common.Message.MessageShow("E076", {messageParam, "0%"})
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' 点数の範囲にチェックを行う
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="messageParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PointRangeCheck(ByVal value As String, ByVal messageParam As String) As Boolean
        PointRangeCheck = False

        If value.Trim = "" Then
            Return True
        End If

        If Not NumericCheck(value, messageParam) Then Return False

        If value > 1000 Then
            Common.Message.MessageShow("E075", {messageParam, "1000点"})
            Return False
        End If

        If value < 0 Then
            Common.Message.MessageShow("E076", {messageParam, "0点"})
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 最小値、最大値チェック
    ''' </summary>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <param name="messageParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MinAndMaxCheck(ByVal min As String, ByVal max As String, ByVal messageParam As String) As Boolean
        MinAndMaxCheck = False

        If min.Trim = "" Then
            Return True
        End If
        If max.Trim = "" Then
            Return True
        End If

        If Not NumericCheck(min, messageParam) Then Return False
        If Not NumericCheck(max, messageParam) Then Return False

        If Decimal.Parse(min) > Decimal.Parse(max) Then
            Common.Message.MessageShow("E074", {messageParam})
            Return False
        End If

        Return True
    End Function

End Class
