Imports System.Xml
Public Class Message
    Public Shared Function MessageShow(ByVal MessageId As String, Optional ByVal MessageParam As String() = Nothing) As DialogResult
        Dim foundRows() As Data.DataRow = Nothing

        If Not readMessage(MessageId, foundRows) Then
            Return False
        End If

        Dim icon As Windows.Forms.MessageBoxIcon
        Dim caption As String = ""
        Dim button As Windows.Forms.MessageBoxButtons

        If foundRows(0).Item(0).ToString.Substring(0, 1) = "E" Then
            icon = MessageBoxIcon.Error
            caption = "エラー"
            button = MessageBoxButtons.OK
        ElseIf foundRows(0).Item(0).ToString.Substring(0, 1) = "Q" Then
            icon = MessageBoxIcon.Question
            caption = "確認"
            button = MessageBoxButtons.OKCancel
        ElseIf foundRows(0).Item(0).ToString.Substring(0, 1) = "I" Then
            icon = MessageBoxIcon.Information
            caption = "メッセージ"
            button = MessageBoxButtons.OK
        Else
            MessageBox.Show("メッセージIDが不正です")
            MessageShow = Nothing
            Return MessageShow
        End If

        replaceMessage(MessageParam, foundRows)

        Dim res As DialogResult = MessageBox.Show(foundRows(0).Item(1), caption, button, icon)

        Return res

    End Function

    Public Shared Function GetMessage(ByVal MessageId As String, Optional ByVal MessageParam As String() = Nothing) As String

        Dim foundRows() As Data.DataRow = Nothing

        If Not readMessage(MessageId, foundRows) Then
            Return False
        End If

        replaceMessage(MessageParam, foundRows)

        Return foundRows(0).Item(1)
    End Function

    Private Shared Function readMessage(ByVal MessageId As String, ByRef foundRows() As DataRow) As Boolean
        readMessage = True
        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim sr As New System.IO.StreamReader(asm.GetManifestResourceStream("CST.CBT.eIPSTA.Common.Message.xml"), System.Text.Encoding.GetEncoding("Shift_JIS"))
        Dim ds As New DataSet
        ds.ReadXml(sr)
        Dim dt As DataTable = ds.Tables("Message")

        foundRows = dt.Select("Id = '" & MessageId & "'")

        If foundRows.Length = 0 Then
            MessageBox.Show("メッセージが見つかりません")
            Return False
        End If
    End Function

    Private Shared Sub replaceMessage(ByVal messageParam As String(), ByRef foundRows() As DataRow)
        If Not messageParam Is Nothing Then
            Dim mcs = System.Text.RegularExpressions.Regex.Matches( _
            foundRows(0).Item(1), "{.}")

            Dim i As Integer = 0
            For Each m As System.Text.RegularExpressions.Match In mcs
                foundRows(0).Item(1) = foundRows(0).Item(1).Replace(m.Value, messageParam(i))
                i += 1
            Next
        End If
    End Sub

End Class
