''' <summary>
''' 分類結果集計データクラス
''' </summary>
''' <remarks></remarks>
Public Class ResultSummaryGroup

#Region "----- メンバ変数 -----"

    ''' <summary>カテゴリーID</summary>
    Private _CategoryId As String = Nothing
    ''' <summary>問題数</summary>
    Private _QuestionCount As Integer = 0
    ''' <summary>正解数</summary>
    Private _AnswerCount As Integer = 0

#End Region

#Region "----- プロパティ -----"

    ''' <summary>カテゴリーIDの取得・設定</summary>
    Public Property CategoryId As String
        Get
            Return _CategoryId
        End Get
        Set(ByVal value As String)
            _CategoryId = value
        End Set
    End Property

    ''' <summary>問題数の取得・設定</summary>
    Public Property QuestionCount As Integer
        Get
            Return _QuestionCount
        End Get
        Set(ByVal value As Integer)
            _QuestionCount = value
        End Set
    End Property

    ''' <summary>正解数の取得・設定</summary>
    Public Property AnswerCount As Integer
        Get
            Return _AnswerCount
        End Get
        Set(ByVal value As Integer)
            _AnswerCount = value
        End Set
    End Property

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 評価点取得
    ''' </summary>
    ''' <returns>評価点</returns>
    ''' <remarks></remarks>
    Public Function GetGradePoint() As Integer
        Dim gradePoint As Integer = 0

        Try
            If _QuestionCount > 0 AndAlso _AnswerCount > 0 Then
                gradePoint = Math.Floor((_AnswerCount / _QuestionCount) * 1000)
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return gradePoint
    End Function

    ''' <summary>
    ''' 正解率取得
    ''' </summary>
    ''' <returns>正解率</returns>
    Public Function GetAccuracyRate() As Double
        Dim accuracyRate As Double = 0

        Try
            If _QuestionCount > 0 AndAlso _AnswerCount > 0 Then
                accuracyRate = (_AnswerCount / _QuestionCount) * 100
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Return accuracyRate
    End Function

#End Region

End Class
