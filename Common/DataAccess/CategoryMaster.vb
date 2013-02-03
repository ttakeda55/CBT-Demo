
''' <summary>
''' カテゴリー
''' </summary>
''' <remarks></remarks>
Public Class CategoryMaster
#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>分類ID</summary>
        CATEGORYID = 0
        ''' <summary>分類名</summary>
        CATEGORYNAME
        ''' <summary>親ID</summary>
        PARENTCATEGORYID
        ''' <summary>表示用ID</summary>
        DISPLAYID
        ''' <summary>分類区分</summary>
        CATEGORYCLASS
        ''' <summary>キーワード</summary>
        KEYWORD
        ''' <summary>難易度別問題数1</summary>
        LEVELQUESTIONCOUNT1
        ''' <summary>難易度別問題数2</summary>
        LEVELQUESTIONCOUNT2
        ''' <summary>難易度別問題数3</summary>
        LEVELQUESTIONCOUNT3
        ''' <summary>作成日</summary>
        CREATE_DATE
        ''' <summary>更新日</summary>
        UPDATE_DATE
        ''' <summary>総合テスト問題数</summary>
        SYNTHESISQUESTIONCOUNT
    End Enum

    ''' <summary>カテゴリテーブルインデックス</summary>
    Public Enum CagoryTableColumnIndex As Integer
        '''<summary>第４階層カテゴリID</summary>
        CATEGORYID = 0
        '''<summary>第４階層表示カテゴリ名</summary>
        CATEGORYNAME
        ''' <summary>親ID</summary>
        PARENTCATEGORYID
        ''' <summary>第４階層カテゴリID表示用ID</summary>
        DISPLAYID
        ''' <summary>分類区分</summary>
        CATEGORYCLASS
        ''' <summary>キーワード</summary>
        KEYWORD
        ''' <summary>難易度別問題数1</summary>
        LEVELQUESTIONCOUNT1
        ''' <summary>難易度別問題数2</summary>
        LEVELQUESTIONCOUNT2
        ''' <summary>難易度別問題数3</summary>
        LEVELQUESTIONCOUNT3
        ''' <summary>作成日</summary>
        CREATE_DATE
        ''' <summary>更新日</summary>
        UPDATE_DATE
        ''' <summary>総合テスト問題数</summary>
        SYNTHESISQUESTIONCOUNT
        '''<summary>第１階層カテゴリID</summary>
        CATEGORYID1
        '''<summary>第２階層カテゴリID</summary>
        CATEGORYID2
        '''<summary>第３階層カテゴリID</summary>
        CATEGORYID3
        '''<summary>第１階層表示カテゴリID</summary>k
        DISPLAYID1
        '''<summary>第２階層表示カテゴリID</summary>
        DISPLAYID2
        '''<summary>第３階層表示カテゴリID</summary>
        DISPLAYID3
        '''<summary>第１階層表示カテゴリ名</summary>
        CATEGORYNAME1
        '''<summary>第２階層表示カテゴリ名</summary>
        CATEGORYNAME2
        '''<summary>第３階層表示カテゴリ名</summary>
        CATEGORYNAME3
    End Enum

    ''' <summary>
    ''' カテゴリーID
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure categoryId
        '''<summary>分野A</summary>
        Shared ReadOnly fieldCategoryId_A As String = "10"
        '''<summary>分野B</summary>
        Shared ReadOnly fieldCategoryId_B As String = "20"
        '''<summary>分野C</summary>
        Shared ReadOnly fieldCategoryId_C As String = "30"
        '''<summary>分野D</summary>
        Shared ReadOnly fieldCategoryId_D As String = "40"
        '''<summary>分野E</summary>
        Shared ReadOnly fieldCategoryId_E As String = "50"
        ' '''<summary>大分類A</summary>
        'Shared ReadOnly largeCategoryId_A As String = "13"
        ' '''<summary>大分類B</summary>
        'Shared ReadOnly largeCategoryId_B As String = "14"
        ' '''<summary>大分類C</summary>
        'Shared ReadOnly largeCategoryId_C As String = "15"
        ' '''<summary>大分類D</summary>
        'Shared ReadOnly largeCategoryId_D As String = "16"
        ' '''<summary>大分類E</summary>
        'Shared ReadOnly largeCategoryId_E As String = "17"
        ' '''<summary>大分類F</summary>
        'Shared ReadOnly largeCategoryId_F As String = "20"
        ' '''<summary>大分類G</summary>
        'Shared ReadOnly largeCategoryId_G As String = "21"
        ' '''<summary>大分類H</summary>
        'Shared ReadOnly largeCategoryId_H As String = "25"
        ' '''<summary>大分類I</summary>
        'Shared ReadOnly largeCategoryId_I As String = "79"
    End Structure
#End Region

#Region "----- メンバ変数 -----"
    ''' <summary>カテゴリの階層構造を展開したテーブル</summary>
    Public _categoryTable As New DataTable
    Private _categoryClass As Integer = 4
    Public Structure CategoryClassValue
        Const CATEGORYCLASS1 As String = "1"
        Const CATEGORYCLASS2 As String = "2"
        Const CATEGORYCLASS3 As String = "3"
    End Structure

#End Region


#Region "----- コンストラクタ -----"
    Public Sub New()
        _categoryTable = getCategryTable()
    End Sub

    Public Sub New(ByVal categoryClass As Integer)
        _categoryClass = categoryClass
        _categoryTable = getCategryTable()
    End Sub

#End Region

#Region "----- メソッド -----"
#Region "----- 共有メンバ -----"
    ''' <summary>
    ''' 全てのカテゴリーを取得する
    ''' </summary>
    Public Shared Function GetAll() As DataTable
        Return Serialize.XmlToDataTable("Category.xml")
    End Function

    ''' <summary>
    ''' 指定したカテゴリーIdからカテゴリー名を取得する
    ''' </summary>
    Public Shared Function GetCategoryName(ByVal CategoryId As String) As String
        Dim category As DataTable = GetAll()

        Dim foundRows() As Data.DataRow
        foundRows = category.Select("CATEGORYID = '" & CategoryId & "'")

        If foundRows.Length = 0 Then
            GetCategoryName = ""
        Else
            GetCategoryName = foundRows(0).Item(1)
        End If

        Return GetCategoryName
    End Function

    ''' <summary>
    ''' 指定のカテゴリIDの親カテゴリIDを取得する
    ''' </summary>
    ''' <param name="categoryID">親カテゴリを取得するカテゴリID</param>
    ''' <returns>親カテゴリID、存在しない場合は空文字</returns>
    ''' <remarks></remarks>
    Public Shared Function GetParentCategoryID(ByVal categoryID As String) As String
        Dim category As DataTable = GetAll()

        Dim foundRows() As Data.DataRow
        foundRows = category.Select("CATEGORYID = '" & categoryID & "'")

        If foundRows.Length = 0 Then
            GetParentCategoryID = ""
        Else
            GetParentCategoryID = foundRows(0).Item(2)
        End If

        Return GetParentCategoryID
    End Function

    ''' <summary>
    ''' 指定した表示用Idの存在をチェックする。
    ''' </summary>
    Public Shared Function existsDisplayId(ByVal displayId As String) As Boolean
        Dim category As DataTable = GetAll()

        Dim foundRows() As Data.DataRow
        foundRows = category.Select("DISPLAYID = '" & displayId & "'")

        If foundRows.Length = 0 Then
            existsDisplayId = False
        Else
            existsDisplayId = True
        End If

        Return existsDisplayId
    End Function
#End Region

#Region "----- 非共有メンバ -----"
    ''' <summary>
    ''' カテゴリの階層構造を展開したテーブル取得する
    ''' </summary>
    Public Function GetCategoryTable() As DataTable
        Return _categoryTable
    End Function

    ''' <summary>
    ''' グループのDISPLAYIDをキーに所属するカテゴリクラスの各DISPLAYIDを取得する。
    ''' </summary>
    ''' <param name="strDisplayId"></param>
    ''' <param name="strCategoryClass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetParentDisplayId(ByVal strDisplayId As String, ByVal strCategoryClass As String) As String
        Dim strReturn As String = Nothing
        Dim drCategory As DataRow() = _categoryTable.Select("DISPLAYID='" & strDisplayId & "'")

        If drCategory.Length > 0 Then
            Select Case strCategoryClass
                Case CategoryClassValue.CATEGORYCLASS1
                    strReturn = drCategory(0).Item("DISPLAYID1")

                Case CategoryClassValue.CATEGORYCLASS2
                    strReturn = drCategory(0).Item("DISPLAYID2")

                Case CategoryClassValue.CATEGORYCLASS3
                    strReturn = drCategory(0).Item("DISPLAYID3")

            End Select
        End If

        Return strReturn
    End Function

    ''' <summary>
    ''' カテゴリーリスト取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 小問のカテゴリーリストを取得する。
    ''' </remarks>
    Private Function getCategryTable() As DataTable
        _categoryTable = Common.CategoryMaster.GetAll()
        addCategoryColumns(_categoryTable)

        Dim rows As DataRow() = _categoryTable.Select("CATEGORYCLASS = '" & _categoryClass & "'")
        Dim returnDt As New DataTable
        returnDt = _categoryTable.Clone

        For Each row As DataRow In rows
            returnDt.ImportRow(row)
        Next

        For Each drCategory As DataRow In returnDt.Rows
            getParent(drCategory)
        Next

        Return returnDt
    End Function

    ''' <summary>
    ''' 親カテゴリ
    ''' </summary>
    ''' <param name="drCategory"></param>
    ''' <remarks>カテゴリーテーブルより、カテゴリー名と親カテゴリID</remarks>
    Private Sub getParent(ByRef drCategory As DataRow)

        Dim drCategoryCalssOwn As DataRow() = _categoryTable.Select("DISPLAYID = '" & drCategory.Item("DISPLAYID") & "'")
        If drCategoryCalssOwn.Length > 0 Then
            If _categoryClass = 3 Then
                drCategory.Item("CATEGORYID3") = drCategoryCalssOwn(0).Item("CATEGORYID")
                drCategory.Item("DISPLAYID3") = drCategoryCalssOwn(0).Item("DISPLAYID")
                drCategory.Item("CATEGORYNAME3") = drCategoryCalssOwn(0).Item("CATEGORYNAME")
            ElseIf _categoryClass = 2 Then
                drCategory.Item("CATEGORYID2") = drCategoryCalssOwn(0).Item("CATEGORYID")
                drCategory.Item("DISPLAYID2") = drCategoryCalssOwn(0).Item("DISPLAYID")
                drCategory.Item("CATEGORYNAME2") = drCategoryCalssOwn(0).Item("CATEGORYNAME")
            End If
        End If

        'Idで抽出
        Dim drCategoryCalss3 As DataRow() = _categoryTable.Select("CATEGORYID = '" & drCategory.Item("PARENTCATEGORYID") & "'")

        If drCategoryCalss3.Length > 0 Then
            'カテゴリー名称設定

            If _categoryClass = 4 Then
                drCategory.Item("CATEGORYID3") = drCategoryCalss3(0).Item("CATEGORYID")
                drCategory.Item("DISPLAYID3") = drCategoryCalss3(0).Item("DISPLAYID")
                drCategory.Item("CATEGORYNAME3") = drCategoryCalss3(0).Item("CATEGORYNAME")
            ElseIf _categoryClass = 3 Then
                drCategory.Item("CATEGORYID2") = drCategoryCalss3(0).Item("CATEGORYID")
                drCategory.Item("DISPLAYID2") = drCategoryCalss3(0).Item("DISPLAYID")
                drCategory.Item("CATEGORYNAME2") = drCategoryCalss3(0).Item("CATEGORYNAME")
            ElseIf _categoryClass = 2 Then
                drCategory.Item("CATEGORYID1") = drCategoryCalss3(0).Item("CATEGORYID")
                drCategory.Item("DISPLAYID1") = drCategoryCalss3(0).Item("DISPLAYID")
                drCategory.Item("CATEGORYNAME1") = drCategoryCalss3(0).Item("CATEGORYNAME")
            End If
            Dim drCategoryCalss2 As DataRow() = _categoryTable.Select("CATEGORYID = '" & drCategoryCalss3(0).Item("PARENTCATEGORYID") & "'")

            If drCategoryCalss2.Length > 0 Then
                If _categoryClass = 4 Then
                    drCategory.Item("CATEGORYID2") = drCategoryCalss2(0).Item("CATEGORYID")
                    drCategory.Item("DISPLAYID2") = drCategoryCalss2(0).Item("DISPLAYID")
                    drCategory.Item("CATEGORYNAME2") = drCategoryCalss2(0).Item("CATEGORYNAME")
                ElseIf _categoryClass = 3 Then
                    drCategory.Item("CATEGORYID1") = drCategoryCalss2(0).Item("CATEGORYID")
                    drCategory.Item("DISPLAYID1") = drCategoryCalss2(0).Item("DISPLAYID")
                    drCategory.Item("CATEGORYNAME1") = drCategoryCalss2(0).Item("CATEGORYNAME")
                End If

                Dim drCategoryCalss1 As DataRow() = _categoryTable.Select("CATEGORYID = '" & drCategoryCalss2(0).Item("PARENTCATEGORYID") & "'")
                If drCategoryCalss1.Length > 0 Then
                    drCategory.Item("CATEGORYID1") = drCategoryCalss1(0).Item("CATEGORYID")
                    drCategory.Item("DISPLAYID1") = drCategoryCalss1(0).Item("DISPLAYID")
                    drCategory.Item("CATEGORYNAME1") = drCategoryCalss1(0).Item("CATEGORYNAME")
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' カテゴリに列を追加
    ''' </summary>
    ''' <param name="returnDt"></param>
    ''' <remarks></remarks>
    Private Sub addCategoryColumns(ByRef returnDt As DataTable)
        '項目追加
        '分野・グループ名ID
        returnDt.Columns.Add("CATEGORYID1")
        returnDt.Columns.Add("CATEGORYID2")
        returnDt.Columns.Add("CATEGORYID3")
        '分野・グループ表示用ID
        returnDt.Columns.Add("DISPLAYID1")
        returnDt.Columns.Add("DISPLAYID2")
        returnDt.Columns.Add("DISPLAYID3")
        '分野・グループ名
        returnDt.Columns.Add("CATEGORYNAME1")
        returnDt.Columns.Add("CATEGORYNAME2")
        returnDt.Columns.Add("CATEGORYNAME3")
    End Sub

    ''' <summary>
    ''' 指定のカテゴリIDの親カテゴリIDを取得する
    ''' </summary>
    ''' <param name="displayID">親カテゴリを取得するカテゴリID</param>
    ''' <returns>親カテゴリID、存在しない場合は空文字</returns>
    ''' <remarks></remarks>
    Public Function GetGrandParentDisplayID(ByVal displayID As String) As String
        Dim category As DataTable = _categoryTable

        Dim foundRows() As Data.DataRow
        foundRows = category.Select("DISPLAYID = '" & displayID & "'")

        If foundRows.Length = 0 Then
            GetGrandParentDisplayID = ""
        Else
            GetGrandParentDisplayID = foundRows(0).Item(CagoryTableColumnIndex.DISPLAYID1)
        End If

        Return GetGrandParentDisplayID
    End Function
    ''' <summary>
    ''' 
    ''' 指定のカテゴリIDの親カテゴリIDを取得する
    ''' </summary>
    ''' <param name="displayID">親カテゴリを取得するカテゴリID</param>
    ''' <returns>親カテゴリID、存在しない場合は空文字</returns>
    ''' <remarks></remarks>
    Public Function GetParentDisplayID(ByVal displayID As String) As String
        Dim category As DataTable = _categoryTable

        Dim foundRows() As Data.DataRow
        foundRows = category.Select("DISPLAYID = '" & displayID & "'")

        If foundRows.Length = 0 Then
            GetParentDisplayID = ""
        Else
            GetParentDisplayID = foundRows(0).Item(CagoryTableColumnIndex.DISPLAYID2)
        End If

        Return GetParentDisplayID
    End Function
#End Region

#End Region

End Class
