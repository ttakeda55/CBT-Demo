﻿Public Class DataSetHelper
    Public ds As DataSet

    Public Sub New(ByVal DataSet As DataSet)
        ds = DataSet
    End Sub

    Public Sub New()
        ds = Nothing
    End Sub

    Private m_FieldInfo As ArrayList, m_FieldList As String
    Private GroupByFieldInfo As ArrayList, GroupByFieldList As String

    Private Class FieldInfo
        Public RelationName As String
        Public FieldName As String      ' source table field name
        Public FieldAlias As String     ' destination table field name
        Public Aggregate As String
    End Class

    Private Sub ParseFieldList(ByVal FieldList As String, Optional ByVal AllowRelation As Boolean = False)
        '
        ' Parses FieldList into FieldInfo objects and then adds them to the m_FieldInfo private member
        '
        ' FieldList syntax: [relationname.]fieldname[ alias],...
        '
        If m_FieldList = FieldList Then Exit Sub
        m_FieldInfo = New ArrayList()
        m_FieldList = FieldList
        Dim Field As FieldInfo, FieldParts() As String, Fields() As String = FieldList.Split(",")
        Dim I As Integer
        For I = 0 To Fields.Length - 1
            Field = New FieldInfo()
            '
            ' Parse FieldAlias
            '
            FieldParts = Fields(I).Trim().Split(" ")
            Select Case FieldParts.Length
                Case 1
                    ' To be set at the end of the loop
                Case 2
                    Field.FieldAlias = FieldParts(1)
                Case Else
                    Throw New ArgumentException("Too many spaces in field definition: '" & Fields(I) & "'.")
            End Select
            '
            ' Parse FieldName and RelationName
            '
            FieldParts = FieldParts(0).Split(".")
            Select Case FieldParts.Length
                Case 1
                    Field.FieldName = FieldParts(0)
                Case 2
                    If Not AllowRelation Then _
                        Throw New ArgumentException("Relation specifiers not allowed in field list: '" & Fields(I) & "'.")
                    Field.RelationName = FieldParts(0).Trim()
                    Field.FieldName = FieldParts(1).Trim()
                Case Else
                    Throw New ArgumentException("Invalid field definition: '" & Fields(I) & "'.")
            End Select
            If Field.FieldAlias = "" Then Field.FieldAlias = Field.FieldName
            m_FieldInfo.Add(Field)
        Next
    End Sub

    Private Sub ParseGroupByFieldList(ByVal FieldList As String)
        '
        ' Parses FieldList into FieldInfo objects and then adds them to the GroupByFieldInfo private member
        '
        ' FieldList syntax: fieldname[ alias]|operatorname(fieldname)[ alias],...
        '
        ' Supported Operators: count,sum,max,min,first,last
        '
        If GroupByFieldList = FieldList Then Exit Sub

        '未使用のためコメントアウト。
        'Const OperatorList As String = ",count,sum,max,min,first,last,"

        GroupByFieldInfo = New ArrayList()
        Dim Field As FieldInfo, FieldParts() As String, Fields() As String = FieldList.Split(",")
        Dim I As Integer
        For I = 0 To Fields.Length - 1
            Field = New FieldInfo()
            '
            ' Parse FieldAlias
            '
            FieldParts = Fields(I).Trim().Split(" ")
            Select Case FieldParts.Length
                Case 1
                    ' To be set at the end of the loop
                Case 2
                    Field.FieldAlias = FieldParts(1)
                Case Else
                    Throw New ArgumentException("Too many spaces in field definition: '" & Fields(I) & "'.")
            End Select
            '
            ' Parse FieldName and Aggregate
            '
            FieldParts = FieldParts(0).Split("(")
            Select Case FieldParts.Length
                Case 1
                    Field.FieldName = FieldParts(0)
                Case 2
                    Field.Aggregate = FieldParts(0).Trim().ToLower() ' You will do a case-sensitive comparison later.
                    Field.FieldName = FieldParts(1).Trim(" "c, ")"c)
                Case Else
                    Throw New ArgumentException("Invalid field definition: '" & Fields(I) & "'.")
            End Select
            If Field.FieldAlias = "" Then
                If Field.Aggregate = "" Then
                    Field.FieldAlias = Field.FieldName
                Else
                    Field.FieldAlias = Field.Aggregate & "Of" & Field.FieldName
                End If
            End If
            GroupByFieldInfo.Add(Field)
        Next
        GroupByFieldList = FieldList
    End Sub

    Public Function SelectDistinct(ByVal TableName As String, _
                               ByVal SourceTable As DataTable, _
                               ByVal FieldName As String) As DataTable
        Dim dt As New DataTable(TableName)
        dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)
        Dim dr As DataRow, LastValue As Object
        LastValue = Nothing
        For Each dr In SourceTable.Select("", FieldName)
            If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
                LastValue = dr(FieldName)
                dt.Rows.Add(New Object() {LastValue})
            End If
        Next
        If Not ds Is Nothing Then ds.Tables.Add(dt)
        Return dt
    End Function

    Public Function CreateGroupByTable(ByVal TableName As String, _
                                   ByVal SourceTable As DataTable, _
                                   ByVal FieldList As String) As DataTable
        '
        ' Creates a table based on aggregates of fields of another table
        '
        ' RowFilter affects rows before the GroupBy operation. No HAVING-type support
        ' although this can be emulated by later filtering of the resultant table.
        '
        ' FieldList syntax: fieldname[ alias]|aggregatefunction(fieldname)[ alias], ...
        '
        If FieldList = "" Then
            Throw New ArgumentException("You must specify at least one field in the field list.")
            ' Return CreateTable(TableName, SourceTable)
        Else
            Dim dt As New DataTable(TableName)
            ParseGroupByFieldList(FieldList)
            Dim Field As FieldInfo, dc As DataColumn
            For Each Field In GroupByFieldInfo
                dc = SourceTable.Columns(Field.FieldName)
                If Field.Aggregate = "" Then
                    dt.Columns.Add(Field.FieldAlias, dc.DataType, dc.Expression)
                Else
                    dt.Columns.Add(Field.FieldAlias, dc.DataType)
                End If
            Next
            If Not ds Is Nothing Then ds.Tables.Add(dt)
            Return dt
        End If
    End Function

    Public Sub InsertGroupByInto(ByVal DestTable As DataTable, _
                             ByVal SourceTable As DataTable, _
                             ByVal FieldList As String, _
                             Optional ByVal RowFilter As String = "", _
                             Optional ByVal GroupBy As String = "", _
                             Optional ByVal Rollup As Boolean = False)
        '
        ' Copies the selected rows and columns from SourceTable and inserts them into DestTable
        ' FieldList has same format as CreateGroupByTable
        '
        ParseGroupByFieldList(FieldList)  ' parse field list
        ParseFieldList(GroupBy)           ' parse field names to Group By into an arraylist
        Dim Field As FieldInfo
        Dim Rows() As DataRow = SourceTable.Select(RowFilter, GroupBy)
        Dim SourceRow, LastSourceRow As DataRow, SameRow As Boolean, I As Integer, J As Integer, K As Integer
        Dim DestRows(m_FieldInfo.Count) As DataRow, RowCount(m_FieldInfo.Count) As Integer

        LastSourceRow = Nothing
        '
        ' Initialize Grand total row
        '
        DestRows(0) = DestTable.NewRow()
        '
        ' Process source table rows
        '
        For Each SourceRow In Rows
            '
            ' Determine whether we've hit a control break
            '
            SameRow = False
            If Not (LastSourceRow Is Nothing) Then
                SameRow = True
                For I = 0 To m_FieldInfo.Count - 1 ' fields to Group By
                    Field = m_FieldInfo(I)
                    If ColumnEqual(LastSourceRow(Field.FieldName), SourceRow(Field.FieldName)) = False Then
                        SameRow = False
                        Exit For
                    End If
                Next I
                '
                ' Add previous totals to the destination table
                '
                If Not SameRow Then
                    For J = m_FieldInfo.Count To I + 1 Step -1
                        '
                        ' Make NULL the key values for levels that have been rolled up
                        '
                        For K = m_FieldInfo.Count - 1 To J Step -1
                            Field = LocateFieldInfoByName(GroupByFieldInfo, m_FieldInfo(K).FieldName)
                            If Not (Field Is Nothing) Then   ' Group By field does not have to be in field list
                                DestRows(J)(Field.FieldAlias) = DBNull.Value
                            End If
                        Next K
                        '
                        ' Make NULL any non-aggregate, non-group-by fields in anything other than
                        ' the lowest level.
                        '
                        If J <> m_FieldInfo.Count Then
                            For Each Field In GroupByFieldInfo
                                If Field.Aggregate <> "" Then Exit For
                                If LocateFieldInfoByName(m_FieldInfo, Field.FieldName) Is Nothing Then
                                    DestRows(J)(Field.FieldAlias) = DBNull.Value
                                End If
                            Next
                        End If
                        '
                        ' Add row
                        '
                        DestTable.Rows.Add(DestRows(J))
                        If Rollup = False Then Exit For ' only add most child row if not doing a roll-up
                    Next J
                End If
            End If
            '
            ' create new destination rows
            ' Value of I comes from previous If block
            '
            If Not SameRow Then
                For J = m_FieldInfo.Count To I + 1 Step -1
                    DestRows(J) = DestTable.NewRow()
                    RowCount(J) = 0
                    If Rollup = False Then Exit For
                Next J
            End If
            For J = 0 To m_FieldInfo.Count
                RowCount(J) += 1
                For Each Field In GroupByFieldInfo
                    Select Case Field.Aggregate  ' this test is case-sensitive - made lower-case by Build_GroupByFiledInfo
                        Case ""    ' implicit Last
                            DestRows(J)(Field.FieldAlias) = SourceRow(Field.FieldName)
                        Case "last"
                            DestRows(J)(Field.FieldAlias) = SourceRow(Field.FieldName)
                        Case "first"
                            If RowCount(J) = 1 Then DestRows(J)(Field.FieldAlias) = SourceRow(Field.FieldName)
                        Case "count"
                            DestRows(J)(Field.FieldAlias) = RowCount(J)
                        Case "sum"
                            DestRows(J)(Field.FieldAlias) = Add(DestRows(J)(Field.FieldAlias), SourceRow(Field.FieldName))
                        Case "max"
                            DestRows(J)(Field.FieldAlias) = Max(DestRows(J)(Field.FieldAlias), SourceRow(Field.FieldName))
                        Case "min"
                            If RowCount(J) = 1 Then
                                DestRows(J)(Field.FieldAlias) = SourceRow(Field.FieldName)  ' so we get by initial NULL
                            Else
                                DestRows(J)(Field.FieldAlias) = Min(DestRows(J)(Field.FieldAlias), SourceRow(Field.FieldName))
                            End If
                    End Select
                Next
            Next J
            LastSourceRow = SourceRow
        Next
        If Rows.Length > 0 Then
            '
            ' Make NULL the key values for levels that have been rolled up
            '
            For J = m_FieldInfo.Count To 0 Step -1
                For K = m_FieldInfo.Count - 1 To J Step -1
                    Field = LocateFieldInfoByName(GroupByFieldInfo, m_FieldInfo(K).FieldName)
                    If Not (Field Is Nothing) Then  ' Group By field does not have to be in field list
                        DestRows(J)(Field.FieldAlias) = DBNull.Value
                    End If
                Next K
                '
                ' Make NULL any non-aggregate, non-group-by fields in anything other than
                ' the lowest level.
                '
                If J <> m_FieldInfo.Count Then
                    For Each Field In GroupByFieldInfo
                        If Field.Aggregate <> "" Then Exit For
                        If LocateFieldInfoByName(m_FieldInfo, Field.FieldName) Is Nothing Then
                            DestRows(J)(Field.FieldAlias) = DBNull.Value
                        End If
                    Next
                End If
                '
                ' Add row
                '
                DestTable.Rows.Add(DestRows(J))
                If Rollup = False Then Exit For
            Next J
        End If
    End Sub

    Private Function LocateFieldInfoByName(ByVal FieldList As ArrayList, ByVal Name As String) As FieldInfo
        '
        ' Looks up a FieldInfo record based on FieldName
        '
        Dim Field As FieldInfo

        For Each Field In FieldList
            If Field.FieldName = Name Then Return Field
        Next

        Field = Nothing
        Return Field

    End Function

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
        '
        ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
        '
        ' NOTE: If your DataTable contains object fields, you must extend this
        ' function to handle them in a meaningful way if you intend to group on them.
        '
        If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
        If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DbNull.Value.
        Return A = B                                                ' Value type standard comparison
    End Function

    Private Function Min(ByVal A As Object, ByVal B As Object) As Object
        '
        ' Returns MIN of two values. DBNull is less than all others.
        '
        If A Is DBNull.Value Or B Is DBNull.Value Then Return DBNull.Value
        If A < B Then Return A Else Return B
    End Function

    Private Function Max(ByVal A As Object, ByVal B As Object) As Object
        '
        ' Returns Max of two values. DBNull is less than all others.
        '
        If A Is DBNull.Value Then Return B
        If B Is DBNull.Value Then Return A
        If A > B Then Return A Else Return B
    End Function

    Private Function Add(ByVal A As Object, ByVal B As Object) As Object
        '
        ' Adds two values. If one is DBNull, returns the other.
        '
        If A Is DBNull.Value Then Return B
        If B Is DBNull.Value Then Return A
        Return A + B
    End Function

    Public Function SelectGroupByInto(ByVal TableName As String, _
                                  ByVal SourceTable As DataTable, _
                                  ByVal FieldList As String, _
                                  ByVal RowFilter As String, _
                                  ByVal GroupBy As String, _
                                  ByVal Rollup As Boolean) As DataTable
        '
        ' Selects data from one DataTable to another and performs various aggregate functions
        ' along the way. See InsertGroupByInto and ParseGroupByFieldList for supported aggregate functions.
        '
        Dim dt As DataTable = CreateGroupByTable(TableName, SourceTable, FieldList)
        InsertGroupByInto(dt, SourceTable, FieldList, RowFilter, GroupBy, Rollup)
        Return dt
    End Function

    ''' <summary>
    ''' DataSetHelperでグルーピングする関数
    ''' </summary>
    ''' <param name="TableName"></param>
    ''' <param name="SourceTable"></param>
    ''' <param name="FieldList"></param>
    ''' <param name="RowFilter"></param>
    ''' <param name="GroupBy"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' RollUpしない場合にGroup句が複数使えないので、デフォルトでRollUpし集計行を削除する。
    ''' </remarks>
    Public Function SelectGroupByInto(ByVal TableName As String,
                              ByVal SourceTable As DataTable,
                              ByVal FieldList As String,
                              ByVal RowFilter As String,
                              ByVal GroupBy As String) As DataTable

        Dim DataSetHelper As DataSetHelper = New DataSetHelper()
        Dim GroupName As String() = Split(GroupBy, ",")
        Dim DeleteKey = GroupName(GroupName.Length - 1)
        Dim dtReturn As DataTable = New DataTable

        Dim dt As DataTable = DataSetHelper.SelectGroupByInto(TableName, SourceTable, FieldList, RowFilter, GroupBy, True)
        dtReturn = dt.Clone()

        For Each row As DataRow In dt.Select(DeleteKey & "<>''")
            dtReturn.ImportRow(row)
        Next
        Return dtReturn
    End Function
End Class



