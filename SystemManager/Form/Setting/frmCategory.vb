Imports CST.CBT.eIPSTA.Common
''' <summary>
''' 分類・グループ登録
''' </summary>
''' <remarks>
''' 問題の分類、グループ、キーワードを登録する。
''' </remarks>
Public Class frmCategory
#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)

    ''' <summary>カテゴリ保持</summary>
    Private wkCategory As New DataTable

    ''' <summary>総合テスト小問 問題数</summary>
    Private questionCount As Integer = 80

    ''' <summary>日付初期値</summary>
    Private DATE_NULL_VALUE As String = "1900/01/01"

#End Region

#Region "----- イベンド -----"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            lblBottomCode.Text = "TG13"
            lblBottomName.Text = "グループＩＤ登録画面"

            'グリッドのデザイン変更
            changeDesign()

            setCategory()

            checkPracticeQuestionUse()

            setSynthesisQuestionCount()

            'グリッド入力制御
            InputControl()

            trvCategory.Focus()
            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 問題管理画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackQuestionManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackQuestionManager.Click
        Try
            logger.Start()
            Me.DialogResult = DialogResult.OK
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' システム管理画面に戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBackSystemManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            logger.Start()
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' TreeView選択イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub trvCategory_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvCategory.AfterSelect
        Try
            '総合テストカウント設定
            setSynthesisQuestionCount()

            Dim category As DataTable = CType(dgvCategory.DataSource, DataTable)
            category.DefaultView.RowFilter = "PARENTCATEGORYID = '" & trvCategory.SelectedNode.Name & "'"

            'グリッド入力制御
            InputControl()

        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' テキスト項目を一回のクリックで編集開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvGroupList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategory.CellEnter
        Try
            '1回のクリックでエディットモードにする処置  
            Dim dgv As DataGridView = TryCast(sender, DataGridView)

            If e.ColumnIndex >= 0 Then
                If TypeOf dgv.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn Then
                    SendKeys.Send("{F2}")
                End If
            End If
            '---- 列番号を調べて制御 ------
            Select Case dgv.Columns(e.ColumnIndex).Name
                Case colCategoryName.Name
                    'この列は日本語入力ON
                    dgvCategory.ImeMode = Windows.Forms.ImeMode.On
                Case Else
                    'この列はIME無効(半角英数のみ)
                    dgvCategory.ImeMode = Windows.Forms.ImeMode.Disable
            End Select
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 更新修正ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            logger.Start()
            '合計設定
            setSynthesisQuestionCount()

            '入力チェック
            If Not inputCheck() Then
                If dgvCategory.Rows.Count > 0 Then
                    searchNode(trvCategory.Nodes, dgvCategory.Rows(0).Cells(colParentCategoryID.Name).Value)
                End If
                InputControl()
                Exit Sub
            End If

            ''演習問題利用中チェック
            'If Not checkPracticeQuestionUse() Then
            '    Exit Sub
            'End If

            '更新確認
            If Message.MessageShow("Q007") = DialogResult.Cancel Then
                Exit Sub
            End If

            trvCategory.SelectedNode = trvCategory.Nodes(0)
            setSynthesisQuestionCount()

            Serialize.DataTableToxml(dgvCategory.DataSource, "Category.xml")

            'ファイル更新
            If Not DataManager.GetInstance.UpLoadFile Then Exit Sub

            frmCategory_Load(sender, e)

            Message.MessageShow("I004")
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' セルの編集終了後処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvCategory_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategory.CellEndEdit
        Try
            'If e.ColumnIndex = colQuestionCount.Index Then
            '    If Not IsNumeric(dgvCategory(e.ColumnIndex, e.RowIndex).Value) Then
            '        Common.Message.MessageShow("E006", {"出題数"})
            '        dgvCategory.CancelEdit()
            '        Exit Sub
            '    ElseIf CInt(dgvCategory(e.ColumnIndex, e.RowIndex).Value) < 0 OrElse
            '        CInt(dgvCategory(e.ColumnIndex, e.RowIndex).Value) > questionCount Then
            '        Common.Message.MessageShow("E007", {"出題数"})
            '        dgvCategory.CancelEdit()
            '        Exit Sub
            '    Else
            '        dgvCategory(e.ColumnIndex, e.RowIndex).Value = (CInt(dgvCategory(e.ColumnIndex, e.RowIndex).Value)).ToString
            '    End If
            'End If
            'dgvCategory.CurrentCell.Value = dgvCategory.CurrentCell.Value.ToString.Trim
            'キーワードをグリッドに設定する()
            'setKeyWord()

            '問題数設定()
            'setSynthesisQuestionCount()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' セル変更時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvCategory_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategory.CellValueChanged
        Try
            If Not IsNothing(dgvCategory.DataSource) Then
                If IsDBNull(dgvCategory.Rows(e.RowIndex).DataBoundItem("CREATE_DATE")) Then
                    dgvCategory.Rows(e.RowIndex).DataBoundItem("CREATE_DATE") = DATE_NULL_VALUE
                End If
                dgvCategory.Rows(e.RowIndex).DataBoundItem("UPDATE_DATE") = Date.Now.ToString
            End If
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 表に行を追加する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRowAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowAdd.Click
        Try
            logger.Start()
            Dim dtCategory As DataTable = dgvCategory.DataSource
            Dim row As DataRow = dtCategory.NewRow()
            '追加行の値を設定
            dtCategory.DefaultView.RowFilter = Nothing
            Dim maxCategoryId As Integer = getMaxCategoryId(dtCategory)
            maxCategoryId += 1
            row(CategoryMaster.ColumnIndex.CATEGORYID) = maxCategoryId
            row(CategoryMaster.ColumnIndex.PARENTCATEGORYID) = trvCategory.SelectedNode.Name
            row(CategoryMaster.ColumnIndex.KEYWORD) = String.Empty
            row(CategoryMaster.ColumnIndex.CATEGORYCLASS) = "4"
            row(CategoryMaster.ColumnIndex.SYNTHESISQUESTIONCOUNT) = "0"
            row(CategoryMaster.ColumnIndex.CREATE_DATE) = Date.Now.ToString
            row(CategoryMaster.ColumnIndex.UPDATE_DATE) = Date.Now.ToString

            dtCategory.Rows.Add(row)

            dtCategory.DefaultView.RowFilter = "PARENTCATEGORYID = '" & trvCategory.SelectedNode.Name & "'"

            dgvCategory.Rows(dgvCategory.RowCount - 1).Cells(0).Selected = True

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 表の行を削除する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRowDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowDelete.Click
        Try
            logger.Start()
            If dgvCategory.RowCount > 0 Then
                Dim datarow As DataRow = CType(dgvCategory.CurrentRow.DataBoundItem.ROW, DataRow)
                Dim dtCategory As DataTable = dgvCategory.DataSource
                dtCategory.Rows.Remove(datarow)
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' グリッドデザインの変更
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changeDesign()
        '描画
        dgvCategory.Columns(collevelQuestionCount1.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCategory.Columns(collevelQuestionCount2.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCategory.Columns(collevelQuestionCount3.Name).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvCategory.AutoGenerateColumns = False
    End Sub
    ''' <summary>
    ''' カテゴリーを設定する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setCategory()
        Dim category As New DataTable
        Common.XmlSchema.GetCategorySchema(category)

        category.Merge(CategoryMaster.GetAll())
        wkCategory = CategoryMaster.GetAll()

        trvCategory.Nodes.Clear()

        Dim node As New TreeNode
        node.Text = "グループ"
        node.Name = ""
        node.Tag = "0"
        trvCategory.Nodes.Add(node)

        CreateNode("", node.Nodes, category)
        dgvCategory.DataSource = category

        If trvCategory.Nodes.Count > 0 Then
            trvCategory.SelectedNode = trvCategory.Nodes(0)
            trvCategory.SelectedNode.Expand()
        End If
    End Sub

    ''' <summary>
    ''' TreeViewのNodeを作成
    ''' </summary>
    ''' <param name="parent"></param>
    ''' <param name="nodes"></param>
    ''' <param name="dtCategory"></param>
    ''' <remarks></remarks>
    Private Sub CreateNode(ByVal parent As String, ByVal nodes As TreeNodeCollection, ByVal dtCategory As DataTable)
        Dim datarow As DataRow()
        datarow = dtCategory.Select("ParentCategoryID = '" & parent & "'")

        For Each dr As DataRow In datarow
            Dim node As New TreeNode
            node.Text = dr(CategoryMaster.ColumnIndex.CATEGORYNAME).ToString
            node.Name = dr(CategoryMaster.ColumnIndex.CATEGORYID).ToString
            node.Tag = dr(CategoryMaster.ColumnIndex.CATEGORYCLASS).ToString
            Me.CreateNode(dr(CategoryMaster.ColumnIndex.CATEGORYID).ToString, node.Nodes, dtCategory)
            nodes.Add(node)
        Next
    End Sub

    ''' <summary>
    ''' TreeViewのNodeを検索
    ''' </summary>
    ''' <param name="nodes"></param>
    ''' <param name="categoryId"></param>
    ''' <remarks></remarks>
    Private Sub searchNode(ByVal nodes As TreeNodeCollection, ByVal categoryId As String)
        For Each node As TreeNode In nodes
            If node.Name = categoryId Then
                trvCategory.SelectedNode = node
            Else
                Me.searchNode(node.Nodes, categoryId)
            End If
        Next
    End Sub

    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        inputCheck = True
        Dim dtCategory As DataTable = dgvCategory.DataSource
        '必須チェック
        For Each dr As DataRow In dtCategory.Rows
            If dr(CategoryMaster.ColumnIndex.PARENTCATEGORYID) <> String.Empty Then
                'グループID
                If dr(CategoryMaster.ColumnIndex.DISPLAYID).ToString.Trim = String.Empty Then
                    dtCategory.DefaultView.RowFilter = "PARENTCATEGORYID = '" & dr(CategoryMaster.ColumnIndex.PARENTCATEGORYID) & "'"
                    Message.MessageShow("E005", {"グループID"})
                    Return False
                End If

                'グループ名
                If dr(CategoryMaster.ColumnIndex.CATEGORYNAME).ToString.Trim = String.Empty Then
                    dtCategory.DefaultView.RowFilter = "PARENTCATEGORYID = '" & dr(CategoryMaster.ColumnIndex.PARENTCATEGORYID) & "'"
                    Message.MessageShow("E005", {"グループ名"})
                    Return False
                End If
            End If
        Next

        '重複チェック
        For Each dr As DataRow In dtCategory.Rows
            If dr(CategoryMaster.ColumnIndex.DISPLAYID) <> String.Empty Then
                Dim selectString As String = "DISPLAYID = '" & dr(CategoryMaster.ColumnIndex.DISPLAYID) & "'"
                Dim foundDataRow() As DataRow = dtCategory.Select(selectString)

                If foundDataRow.Length > 1 Then
                    dtCategory.DefaultView.RowFilter = "PARENTCATEGORYID = '" & dr(CategoryMaster.ColumnIndex.PARENTCATEGORYID) & "'"
                    Message.MessageShow("E052", {"グループID", "(" & dr(CategoryMaster.ColumnIndex.DISPLAYID) & ")"})
                    Return False
                End If
            End If
        Next


        '数値チェック
        For Each dr As DataRow In dtCategory.Rows
            If Not IsNumeric(dr(CategoryMaster.ColumnIndex.SYNTHESISQUESTIONCOUNT)) OrElse CInt(dr(CategoryMaster.ColumnIndex.SYNTHESISQUESTIONCOUNT)) < 0 Then
                dtCategory.DefaultView.RowFilter = "PARENTCATEGORYID = '" & dr(CategoryMaster.ColumnIndex.PARENTCATEGORYID) & "'"
                Message.MessageShow("E006", {"出題数"})
                Return False
            End If
        Next

        '問題数チェック
        'Dim count As Integer = getTotal()
        'If count <> questionCount Then
        '    Message.MessageShow("E073")
        '    Return False
        'End If
    End Function

    ''' <summary>
    ''' 入力制御
    ''' </summary>
    ''' <remarks>
    ''' 階層を判定し、グループの場合のみ新規追加可能
    ''' グループ以外の場合は、名称のみ変更可能
    ''' </remarks>
    Private Sub InputControl(Optional ByVal errFlg As Boolean = False)
        Select Case trvCategory.SelectedNode.Tag
            Case "0"
                txtKeyWord.ReadOnly = True
                txtKeyWord.Text = String.Empty
                btnRowAdd.Enabled = True
                btnRowDelete.Enabled = True
                dgvCategory.Columns(colCategoryId.Index).ReadOnly = False
                dgvCategory.Columns(colCategoryName.Index).ReadOnly = False
                'dgvCategory.Columns(colQuestionCount.Index).ReadOnly = False
                dgvCategory.Columns(collevelQuestionCount1.Index).ReadOnly = True
                dgvCategory.Columns(collevelQuestionCount2.Index).ReadOnly = True
                dgvCategory.Columns(collevelQuestionCount3.Index).ReadOnly = False
            Case "1"
                txtKeyWord.ReadOnly = True
                txtKeyWord.Text = String.Empty
                btnRowAdd.Enabled = True
                btnRowDelete.Enabled = True
                dgvCategory.Columns(colCategoryId.Index).ReadOnly = False
                dgvCategory.Columns(colCategoryName.Index).ReadOnly = False
                'dgvCategory.Columns(colQuestionCount.Index).ReadOnly = False
                dgvCategory.Columns(collevelQuestionCount1.Index).ReadOnly = True
                dgvCategory.Columns(collevelQuestionCount2.Index).ReadOnly = True
                dgvCategory.Columns(collevelQuestionCount3.Index).ReadOnly = False
            Case "2"
                txtKeyWord.ReadOnly = True
                txtKeyWord.Text = String.Empty
                btnRowAdd.Enabled = True
                btnRowDelete.Enabled = True
                dgvCategory.Columns(colCategoryId.Index).ReadOnly = False
                dgvCategory.Columns(colCategoryName.Index).ReadOnly = False
                'dgvCategory.Columns(colQuestionCount.Index).ReadOnly = False
                dgvCategory.Columns(collevelQuestionCount1.Index).ReadOnly = False
                dgvCategory.Columns(collevelQuestionCount2.Index).ReadOnly = False
                dgvCategory.Columns(collevelQuestionCount3.Index).ReadOnly = False
            Case "3"
                txtKeyWord.ReadOnly = False
                btnRowAdd.Enabled = True
                btnRowDelete.Enabled = True
                dgvCategory.Columns(colCategoryId.Index).ReadOnly = False
                dgvCategory.Columns(colCategoryName.Index).ReadOnly = False
                'dgvCategory.Columns(colQuestionCount.Index).ReadOnly = False
                dgvCategory.Columns(collevelQuestionCount1.Index).ReadOnly = True
                dgvCategory.Columns(collevelQuestionCount2.Index).ReadOnly = True
                dgvCategory.Columns(collevelQuestionCount3.Index).ReadOnly = True
            Case "4"
                txtKeyWord.ReadOnly = True
                txtKeyWord.Text = String.Empty
                btnRowAdd.Enabled = True
                btnRowDelete.Enabled = True
                dgvCategory.Columns(colCategoryId.Index).ReadOnly = False
                dgvCategory.Columns(colCategoryName.Index).ReadOnly = False
                'dgvCategory.Columns(colQuestionCount.Index).ReadOnly = False
        End Select
    End Sub

    ''' <summary>
    ''' カテゴリーIDの最大値を取得する
    ''' </summary>
    Private Function getMaxCategoryId(ByVal dtCategory As DataTable) As Integer

        Dim maxCategoryId As Integer = 0
        For Each dr As DataRow In dtCategory.Rows
            If CInt(dr(CategoryMaster.ColumnIndex.CATEGORYID)) > maxCategoryId Then
                maxCategoryId = CInt(dr(CategoryMaster.ColumnIndex.CATEGORYID))
            End If
        Next

        Return maxCategoryId
    End Function

    ' ''' <summary>
    ' ''' キーワードをグリッドに設定する
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub setKeyWord()
    '    If Not dgvCategory.CurrentRow Is Nothing Then
    '        Dim datarow As DataRow = CType(dgvCategory.CurrentRow.DataBoundItem.ROW, DataRow)
    '        datarow.Item(CategoryMaster.ColumnIndex.KEYWORD) = txtKeyWord.Text
    '        txtKeyWord.Text = ""
    '    End If
    'End Sub

    ' ''' <summary>
    ' ''' キーワードをグリッドから読み取る
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub readKeyWord()
    '    If Not dgvCategory.CurrentRow Is Nothing Then
    '        Dim datarow As DataRow = CType(dgvCategory.CurrentRow.DataBoundItem.ROW, DataRow)
    '        If IsDBNull(datarow.Item(CategoryMaster.ColumnIndex.KEYWORD)) Then
    '            txtKeyWord.Text = String.Empty
    '        Else
    '            txtKeyWord.Text = datarow.Item(CategoryMaster.ColumnIndex.KEYWORD)
    '        End If
    '    End If
    'End Sub


    ''' <summary>
    ''' グループIDが演習問題で利用されている数を数える
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub checkPracticeQuestionUse()
        Dim dtCategory As DataTable = dgvCategory.DataSource
        Dim dtPracticeQuestionList As DataTable = Common.PracticeQuestionList.GetAll(Common.Constant.CST_PRACTICEQUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)

        If dtPracticeQuestionList.Rows.Count > 0 Then
            For Each row As DataRow In dtCategory.Rows
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1) = "0"
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2) = "0"
                Dim drPracticeQuestionList As DataRow() = dtPracticeQuestionList.Select("CATEGORYID = '" & row(Common.CategoryMaster.ColumnIndex.DISPLAYID) & "'")
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1) += drPracticeQuestionList.Length
                drPracticeQuestionList = dtPracticeQuestionList.Select("CATEGORYID = '" & row(Common.CategoryMaster.ColumnIndex.DISPLAYID) & "' AND STATE = '1'")
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2) += drPracticeQuestionList.Length
            Next
        End If

    End Sub

    ''' <summary>
    ''' ログアウトイベント
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnLogout()
        Try
            logger.Start()
            processMessageLogout = True
            Dim resultCode As Constant.ResultCode = Logout.Logout
            Select Case resultCode
                Case Constant.ResultCode.NormalEnd
                    Close()
                Case Constant.ResultCode.Cancel

                Case Else
                    Common.Message.MessageShow("E" & CType(Constant.ResultCode.FtpSendError, Integer).ToString.PadLeft(3, "0"))
            End Select
            processMessageLogout = False
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 小計設定
    ''' </summary>
    ''' <remarks>親カテゴリーに小計を設定する</remarks>
    Private Sub setSynthesisQuestionCount()
        Dim category As DataTable = CType(dgvCategory.DataSource, DataTable)
        If IsNothing(category) Then Exit Sub

        Dim tmpCategory As New DataTable
        tmpCategory = category.Copy
        'tmpCategory.Columns.Add("COUNT_NUM", GetType(Integer), "Convert(SYNTHESISQUESTIONCOUNT, 'System.Int32')")

        For Each row As DataRow In category.Rows
            If IsDBNull(row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1)) OrElse
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1) = String.Empty Then
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1) = "0"
            End If
        Next
        For Each row As DataRow In category.Rows
            If IsDBNull(row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2)) OrElse
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2) = String.Empty Then
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2) = "0"
            End If
        Next
        For Each row As DataRow In category.Rows
            If IsDBNull(row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3)) OrElse
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3) = String.Empty Then
                row.Item(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3) = "0"
            End If
        Next


        'Dim total As Object
        For Each row As DataRow In category.Select("CATEGORYCLASS = '1'")
            row.Item(CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1) =
             getTotal(CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1, "PARENTCATEGORYID = '" & row.Item(CategoryMaster.ColumnIndex.CATEGORYID) & "'")
            row.Item(CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2) =
             getTotal(CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2, "PARENTCATEGORYID = '" & row.Item(CategoryMaster.ColumnIndex.CATEGORYID) & "'")
            'row.Item(CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3) =
            ' getTotal(CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3, "PARENTCATEGORYID = '" & row.Item(CategoryMaster.ColumnIndex.CATEGORYID) & "'")
            'If IsDBNull(total) Then
            '    row.Item(Common.CategoryMaster.ColumnIndex.SYNTHESISQUESTIONCOUNT) = "0"
            'Else
            '    row.Item(Common.CategoryMaster.ColumnIndex.SYNTHESISQUESTIONCOUNT) = total.ToString
            'End If
        Next

        'Dim label As String = Common.Constant.CST_QUESTION_UNIT & "／" & questionCount.ToString & Common.Constant.CST_QUESTION_UNIT
        Dim label As String = Common.Constant.CST_QUESTION_UNIT
        lblTotalCount.Text = getTotal().ToString & label

    End Sub

    ''' <summary>
    ''' 合計取得
    ''' </summary>
    ''' <remarks>問題数合計を取得する</remarks>
    Private Function getTotal() As Integer
        Dim sum As Integer = 0

        For Each row As DataRow In dgvCategory.DataSource.Rows
            If row(Common.CategoryMaster.ColumnIndex.CATEGORYCLASS) = "2" Then
                'If IsNumeric(row(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1)) Then
                '    sum += CInt(row(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT1))
                'End If
                'If IsNumeric(row(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2)) Then
                '    sum += CInt(row(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT2))
                'End If
                If IsNumeric(row(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3)) Then
                    sum += CInt(row(Common.CategoryMaster.ColumnIndex.LEVELQUESTIONCOUNT3))
                End If
            End If
        Next

        Return sum
    End Function

    ''' <summary>
    ''' 合計取得
    ''' </summary>
    ''' <remarks>問題数合計を取得する</remarks>
    Private Function getTotal(ByVal colIndex As Common.CategoryMaster.ColumnIndex, ByVal filter As String) As Integer
        Dim sum As Integer = 0
        For Each row As DataRow In dgvCategory.DataSource.select(filter)
            If IsNumeric(row(colIndex)) Then
                sum += CInt(row(colIndex))
            End If
        Next
        Return sum
    End Function

#End Region

End Class