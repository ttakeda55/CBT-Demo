Public Class UserDateTimePicker

    Private _isNull As Boolean
    Public Event TextChange(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Public Overloads Property Text() As String
        Get
            Return MaskedTextBox1.Text
        End Get
        Set(ByVal Text As String)
            MaskedTextBox1.Text = Text
        End Set
    End Property

    Property IsNull()
        Get
            Return _isNull
        End Get
        Set(ByVal value)
            _isNull = value
        End Set
    End Property

    Public Overloads ReadOnly Property ToShortDateString() As String
        Get
            If MaskCompleted Then
                Return Date.Parse(MaskedTextBox1.Text).ToShortDateString
            Else
                Return ""
            End If
        End Get
    End Property

    Public Overloads ReadOnly Property MaskCompleted() As Boolean
        Get
            Return MaskedTextBox1.MaskCompleted
        End Get
    End Property

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        MaskedTextBox1.Text = Format("yyyy/MM/dd", CDate(DateTimePicker1.Text))
    End Sub

    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged
        RaiseEvent TextChange(sender, e)
        If IsDate(MaskedTextBox1.Text) Then
            If DateTimePicker1.MinDate > Date.Parse(MaskedTextBox1.Text) Then
                MaskedTextBox1.Text = Format("yyyy/MM/dd", DateTimePicker1.MinDate)
            End If
            If DateTimePicker1.MaxDate < Date.Parse(MaskedTextBox1.Text) Then
                MaskedTextBox1.Text = Format("yyyy/MM/dd", DateTimePicker1.MaxDate)
            End If

            If MaskedTextBox1.MaskCompleted Then
                DateTimePicker1.Text = MaskedTextBox1.Text
            End If
        End If
    End Sub

    Private Structure NMHDR
        Public hwndFrom As IntPtr
        Public idFrom As Integer
        Public code As Integer
    End Structure

    Private Structure NMDATETIMECHANGE
        Public nmhdr As NMHDR
        Public dwFlags As Integer
        Public st As SYSTEMTIME
    End Structure

    Private Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure

    Private Const WM_NOTIFY As Integer = &H4E
    Private Const DTN_FIRST As Integer = (0 - 760)
    Private Const DTN_DATETIMECHANGE As Integer = (DTN_FIRST + 1)

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_NOTIFY AndAlso m.WParam.Equals(Me.DateTimePicker1.Handle) Then
            Dim nmh As NMHDR = CType(m.GetLParam(nmh.GetType()), NMHDR)
            If nmh.code = DTN_DATETIMECHANGE Then
                Dim nmdate As NMDATETIMECHANGE = _
                    CType(m.GetLParam(nmdate.GetType()), NMDATETIMECHANGE)
                MaskedTextBox1.Text = Format("yyyy/MM/dd", CDate(DateTimePicker1.Text))
            End If
        End If
        MyBase.WndProc(m)
    End Sub
End Class