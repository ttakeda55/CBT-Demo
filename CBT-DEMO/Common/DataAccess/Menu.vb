''' <summary>
''' 試験名
''' </summary>
''' <remarks></remarks>
Public Class Menu
#Region "----- 定数 -----"
    Public Const FILENAME = "Menu.xml"
    Public Const CLASSNAME = "Menu"
#End Region

#Region "----- 列挙体 -----"
    ''' <summary>行インデックス</summary>
    Public Enum ColumnIndex As Integer
        ''' <summary>テスト名</summary>
        Index = 0
        MenuMode
        Id
        Name
        Caption
        Name_space
        FormName
        ParentId
    End Enum
#End Region

    Private _dtMenu As DataTable

    Public Sub New()
        _dtMenu = GetAll()
    End Sub

    Public Sub New(ByVal menuMode As Common.DataManager.MenuModeType)
        _dtMenu = GetAll(menuMode)
    End Sub


#Region "----- メソッド -----"
    ''' <summary>
    ''' ファイル読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAll() As DataTable
        Dim srMenuSchema As New IO.StringReader(My.Resources.MenuSchema)
        Dim srMenu As New IO.StringReader(My.Resources.Menu)
        Dim dt As New DataTable
        dt.ReadXmlSchema(srMenuSchema)
        dt.ReadXml(srMenu)
        Return dt
    End Function
    ''' <summary>
    ''' ファイル読込
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAll(ByVal menuMode As Common.DataManager.MenuModeType) As DataTable
        Dim srMenuSchema As New IO.StringReader(My.Resources.MenuSchema)
        Dim srMenu As New IO.StringReader(My.Resources.Menu)
        Dim dt As New DataTable
        dt.ReadXmlSchema(srMenuSchema)
        dt.ReadXml(srMenu)
        dt.DefaultView.RowFilter = "MENUMODE = '" & menuMode & "'"
        Return dt.DefaultView.ToTable()
    End Function

    ''' <summary>
    ''' 子メニューを検索
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChild(ByVal parentId As String) As DataRow()
        Return _dtMenu.Select("PARENTID = '" & parentId & "'")
    End Function

    ''' <summary>
    ''' メニューを検索
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMenu(ByVal menuId As String) As DataRow()
        Return _dtMenu.Select("ID = '" & menuId & "'")
    End Function

    ''' <summary>
    ''' メニューを検索
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetParent(ByVal parentId As String) As DataRow()
        Return _dtMenu.Select("ID = '" & parentId & "'")
    End Function

#End Region

End Class
