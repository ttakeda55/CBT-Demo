Public Class InputCheck
    ''' <summary>
    ''' 期間内かどうかチェックする
    ''' </summary>
    ''' <param name="outsideStartDate"></param>
    ''' <param name="outsideEndDate"></param>
    ''' <param name="insideStartDate"></param>
    ''' <param name="insideEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function withinPeriodCheck(ByVal outsideStartDate As Date, ByVal outsideEndDate As Date,
                                       ByVal insideStartDate As Date, ByVal insideEndDate As Date) As Boolean
        withinPeriodCheck = False

        If outsideStartDate <= insideStartDate And insideEndDate <= outsideEndDate Then
            withinPeriodCheck = True
        End If

    End Function

End Class
