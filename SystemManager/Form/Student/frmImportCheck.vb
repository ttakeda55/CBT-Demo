Imports System.Text
Imports CST.CBT.CBTCommon
Imports CST.CBT.eIPSTA.Common
''' <summary>
''' データチェック(TG07)<br/>
''' <img src="..\Images\TG07.png" />
''' </summary>
''' <remarks>
''' 2011/09/06 nozao 新規作成
''' </remarks>
Public Class frmImportCheck
#Region "----- メンバ変数 -----"
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region
#Region "イベントハンドラ"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmImportCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()
            Me.Text = "データチェック"
            lblBottomCode.Text = "TG06"
            lblBottomName.Text = "データチェック画面"

            Dim databanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
            Dim arStudent As ArrayList = databanker("STUDENTCSV")
            'lblGroupCode.Text = databanker("GROUPCODE")
            'lblGroupName.Text = databanker("GROUPNAME")
            'lblUsePeriod.Text = databanker("TESTSTART") & "～" & databanker("TESTEND")


            Dim i As Integer = 0
            For i = 0 To arStudent.Count - 2
                dgvStudent.Rows.Add()
                dgvStudent.Item(colUserId.Index, i).Value = arStudent.Item(i + 1)(0)
                dgvStudent.Item(colUserName.Index, i).Value = arStudent.Item(i + 1)(1)
                'dgvStudent.Item(colSection1.Index, i).Value = arStudent.Item(i + 1)(2)
                'dgvStudent.Item(colSection2.Index, i).Value = arStudent.Item(i + 1)(3)
                'dgvStudent.Item(colStudentsStart.Index, i).Value = arStudent.Item(i + 1)(4)
                'dgvStudent.Item(colStudentsEnd.Index, i).Value = arStudent.Item(i + 1)(5)
                If UBound(arStudent.Item(i + 1)) > 5 Then
                    dgvStudent.Item(colNote.Index, i).Value = arStudent.Item(i + 1)(3)
                End If

            Next

            Owner.Hide()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 登録処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            logger.Start()
            If Common.Message.MessageShow("Q001") = DialogResult.OK Then
                Dim dtStudent As New DataTable
                Dim fileName As String = Common.Constant.CST_STUDENT_FILENAME & Common.Constant.CST_GROUPNAME & Common.Constant.CST_EXTENSION_XML

                If IO.File.Exists(Common.Constant.GetTempPath & fileName) Then
                    dtStudent = Serialize.XmlToDataTable(fileName)
                Else
                    Common.XmlSchema.GetStudentSchema(dtStudent)
                End If

                Dim datarow As DataRow
                For Each dr As DataGridViewRow In dgvStudent.Rows
                    datarow = dtStudent.NewRow
                    datarow.Item(Student.ColumnIndex.UserId) = dr.Cells(colUserId.Index).Value
                    datarow.Item(Student.ColumnIndex.Name) = dr.Cells(colUserName.Index).Value
                    datarow.Item(Student.ColumnIndex.Section1) = Utility.NothingToString(dr.Cells(colSection1.Index).Value)
                    datarow.Item(Student.ColumnIndex.Section2) = Utility.NothingToString(dr.Cells(colSection2.Index).Value)
                    datarow.Item(Student.ColumnIndex.Password) = Utility.GeneratePassword(8, Common.Constant.CST_PASSWORDCHARS)
                    datarow.Item(Student.ColumnIndex.Note) = Utility.NothingToString(dr.Cells(colNote.Index).Value)
                    datarow.Item(Student.ColumnIndex.TestCount) = 0
                    datarow.Item(Student.ColumnIndex.UpLoadDate) = System.DateTime.Now.ToString
                    datarow.Item(Student.ColumnIndex.StudentsStart) = Utility.NothingToString(dr.Cells(colStudentsStart.Index).Value)
                    datarow.Item(Student.ColumnIndex.StudentsEnd) = Utility.NothingToString(dr.Cells(colStudentsEnd.Index).Value)
                    datarow.Item(Student.ColumnIndex.CreateDate) = System.DateTime.Now.ToString
                    datarow.Item(Student.ColumnIndex.UpdateDate) = System.DateTime.Now.ToString
                    dtStudent.Rows.Add(datarow)
                Next

                'xml作成
                Common.XmlSchema.GetStudentSchema(dtStudent)
                Common.Serialize.DataTableToxml(dtStudent, Common.Constant.CST_STUDENT_FILENAME & Common.Constant.CST_GROUPNAME & Common.Constant.CST_EXTENSION_XML)

                'ファイルアップロード
                If Not DataManager.GetInstance.UpLoadFile Then
                    Close()
                End If
                
                Common.Message.MessageShow("I001")

                DialogResult = Windows.Forms.DialogResult.OK

                Me.Close()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Close()
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            logger.Start()
            Me.Close()
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
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
#End Region

End Class