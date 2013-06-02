Public Class ChoiceMark
    Enum ChoiceMarkType As Integer
        Alphabet = 0
        Number
        Hiragana
        Katakana
    End Enum

    Private Const ALPHABET = "ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ"
    Private Const NUMBER = "１２３４５６７８９"
    Private Const HIRAGANA = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワン"
    Private Const KATAKANA = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわん"

    Private _ChoiceMark As String = ""

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="markType"></param>
    ''' <param name="fullWidthCharacters"></param>
    ''' <param name="UpperCase"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal markType As ChoiceMarkType, ByVal choiceMarkCount As Integer, ByVal fullWidthCharacters As Boolean, ByVal UpperCase As Boolean)
        Select Case markType
            Case ChoiceMark.ChoiceMarkType.Alphabet
                _ChoiceMark = ALPHABET
            Case ChoiceMark.ChoiceMarkType.Number
                _ChoiceMark = NUMBER
            Case ChoiceMark.ChoiceMarkType.Hiragana
                _ChoiceMark = HIRAGANA
            Case ChoiceMark.ChoiceMarkType.Number
                _ChoiceMark = KATAKANA
        End Select

        _ChoiceMark = _ChoiceMark.Substring(0, choiceMarkCount)

        If fullWidthCharacters Then
            _ChoiceMark = StrConv(_ChoiceMark, VbStrConv.Wide)
        Else
            _ChoiceMark = StrConv(_ChoiceMark, VbStrConv.Narrow)
        End If

        If UpperCase Then
            _ChoiceMark = _ChoiceMark.ToUpper
        Else
            _ChoiceMark = _ChoiceMark.ToLower
        End If
    End Sub

    Public Function GetChoiceMarkString() As String
        Return _ChoiceMark
    End Function

    Public Function GetChoiceMarkChar(ByVal index As Integer) As String
        Return _ChoiceMark.ToString.Chars(index)
    End Function
End Class
