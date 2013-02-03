Imports System.Runtime.Remoting
''' <summary>
''' メニュー
''' </summary>
''' <remarks>menu.xmlを基に画面遷移を行う</remarks>
Public Class frmMenuBase

#Region "----- メンバ変数 -----"

    ''' <summary>
    ''' メニューデータ
    ''' </summary>
    ''' <remarks></remarks>
    Private _menu As New Common.Menu(Common.DataManager.GetInstance.MenuMode)

    ''' <summary>
    ''' メニュー項目
    ''' </summary>
    ''' <remarks></remarks>
    Private htMenu As New Hashtable

#End Region

#Region "----- 定数 -----"

    ''' <summary>
    ''' メニューの画面遷移モード
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum moveMode As Integer
        ''' <summary>次の画面へ遷移</summary>
        form_Next = 0
        ''' <summary>前の画面へ遷移</summary>
        form_back
    End Enum

#End Region

#Region "----- イベント -----"

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMenu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim forms As New Form
        htMenu.Add(1, New ArrayList({pnl11, pnl12, btnFormName1, lblCaption1}))
        htMenu.Add(2, New ArrayList({pnl21, pnl22, btnFormName2, lblCaption2}))
        htMenu.Add(3, New ArrayList({pnl31, pnl32, btnFormName3, lblCaption3}))
        htMenu.Add(4, New ArrayList({pnl41, pnl42, btnFormName4, lblCaption4}))
        htMenu.Add(5, New ArrayList({pnl51, pnl52, btnFormName5, lblCaption5}))

        Dim topRows As DataRow() = _menu.GetChild("")

        If topRows.Length = 0 Then Exit Sub

        setMenu(topRows(0), moveMode.form_Next)

        btnBack.Visible = False

    End Sub

    ''' <summary>
    ''' 次の画面へ遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Click(sender As System.Object, e As System.EventArgs) Handles btnFormName1.Click, btnFormName2.Click, btnFormName3.Click, btnFormName4.Click, btnFormName5.Click
        Dim dr As DataRow = CType(CType(sender, Button).Tag, DataRow)
        If Not OpenForm(dr.Item(Common.Menu.ColumnIndex.Name_space), dr.Item(Common.Menu.ColumnIndex.FormName)) Then
            setMenu(CType(sender, Button).Tag, moveMode.form_Next)
        End If
    End Sub

    ''' <summary>
    ''' 前の画面へ遷移
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        setMenu(CType(sender, Button).Tag, moveMode.form_back)
    End Sub

#End Region

#Region "----- メソッド -----"

    ''' <summary>
    ''' 画面を表示する
    ''' </summary>
    ''' <param name="name_Space"></param>
    ''' <param name="strFrmName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenForm(ByVal name_Space As String, ByVal strFrmName As String) As Boolean
        If strFrmName = "" Then Return False
        Try
            Dim objectHandle As ObjectHandle
            Dim splitIndex As Integer = name_Space.LastIndexOf("."c)
            Dim assemblyName As String = name_Space.Substring(splitIndex + 1, name_Space.Length - splitIndex - 1)
            objectHandle = _
            Activator.CreateInstance(assemblyName, _
            name_Space _
            & "." & strFrmName)
            CType(objectHandle.Unwrap, Form).ShowDialog(Me)
            If CBTCommon.DataBanker.GetInstance("LOGOUT") Then
                Me.Close()
            Else
                Show()
            End If
            Return True
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' メニュー項目を設定する
    ''' </summary>
    ''' <param name="drCurrent"></param>
    ''' <param name="moveMode"></param>
    ''' <remarks></remarks>
    Private Sub setMenu(ByVal drCurrent As DataRow, ByVal moveMode As moveMode)
        Select Case moveMode
            Case frmMenuBase.moveMode.form_Next
                btnBack.Tag = lblMenuTitle.Tag
                lblMenuTitle.Text = drCurrent.Item(Common.Menu.ColumnIndex.Name).ToString
                lblMenuTitle.Tag = drCurrent
            Case frmMenuBase.moveMode.form_back
                Dim drChild As DataRow() = _menu.GetChild(drCurrent.Item(Common.Menu.ColumnIndex.Id).ToString())
                If drChild.Length = 0 Then Exit Sub

                lblMenuTitle.Tag = btnBack.Tag
                lblMenuTitle.Text = CType(btnBack.Tag, DataRow).Item(Common.Menu.ColumnIndex.Name)
                Dim drParent As DataRow() = _menu.GetParent(drCurrent.Item(Common.Menu.ColumnIndex.ParentId).ToString())
                If drParent.Length <> 0 Then
                    btnBack.Tag = drParent(0)
                End If
        End Select
        Me.Text = lblMenuTitle.Text

        Dim CurrentId As String
        CurrentId = drCurrent.Item(Common.Menu.ColumnIndex.Id).ToString

        'メニューボタンの設定
        clearMenu()
        Dim childRows As DataRow() = _menu.GetChild(CurrentId)
        Dim index As Integer = 1
        For Each row As DataRow In childRows
            CType(CType(htMenu.Item(index), ArrayList).Item(0), Panel).Visible = True
            CType(CType(htMenu.Item(index), ArrayList).Item(1), Panel).Visible = True
            CType(CType(htMenu.Item(index), ArrayList).Item(2), Button).Text = row(Common.Menu.ColumnIndex.Name)
            CType(CType(htMenu.Item(index), ArrayList).Item(2), Button).Tag = row
            CType(CType(htMenu.Item(index), ArrayList).Item(3), Label).Text = row(Common.Menu.ColumnIndex.Caption)
            index += 1
        Next

        '戻るボタンの設定
        If drCurrent.Item(Common.Menu.ColumnIndex.ParentId).ToString = "" Then
            btnBack.Visible = False
        Else
            btnBack.Visible = True
            btnBack.Text = getParentCaption(drCurrent)
        End If
        btnFormName1.Focus()
    End Sub

    ''' <summary>
    ''' メニュー項目をクリアする
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearMenu()
        For Each key As Integer In htMenu.Keys
            CType(CType(htMenu.Item(key), ArrayList).Item(0), Panel).Visible = False
            CType(CType(htMenu.Item(key), ArrayList).Item(1), Panel).Visible = False
        Next
    End Sub

    ''' <summary>
    ''' 親のキャプションを取得する
    ''' </summary>
    ''' <param name="drCurrent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getParentCaption(ByVal drCurrent As DataRow) As String
        getParentCaption = ""

        Dim drParent As DataRow() = _menu.GetParent(drCurrent.Item(Common.Menu.ColumnIndex.ParentId).ToString())

        If drParent.Length = 0 Then Exit Function

        Return drParent(0).Item(Common.Menu.ColumnIndex.Name) & "へ戻る"

    End Function

#End Region

End Class