''' <summary>
''' 総合テスト履歴詳細
''' </summary>
''' <remarks>
''' 2012/04/25 NOZAO 新規作成
''' </remarks>
Public Class frmSynthesisResultDetail
#Region "----- メンバ変数 -----"
    ''' <summary>総合テスト結果_詳細</summary>
    Private _synthesisResultList As DataTable
    ''' <summary>ログオブジェクト</summary>
    Private ReadOnly logger As Common.AppLogger = Common.AppLogger.GetAppLogger(Me)
#End Region

#Region "----- プロパティ -----"
    ''' <summary>総合テスト結果_詳細</summary>
    Public WriteOnly Property SynthesisResultList As DataTable
        Set(value As DataTable)
            _synthesisResultList = value
        End Set
    End Property
#End Region

#Region "----- イベント -----"
    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMiniTestResultDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            logger.Start()

            dgvErrataList1.AutoGenerateColumns = False
            dgvErrataList2.AutoGenerateColumns = False
            setSynthesisRsultList()
            
            Owner.Hide()

            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub


    ''' <summary>
    ''' 正誤表クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvErrataList_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvErrataList1.CellContentClick
        Try
            logger.Start()
            If e.ColumnIndex = QUESTIONNO_LEFT.Index And e.RowIndex <> -1 Then
                Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection
                createPraciticeQuestionInfoCollection(dgvErrataList1, PraciticeQuestionInfoCollection)
                createPraciticeQuestionInfoCollection(dgvErrataList2, PraciticeQuestionInfoCollection)
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(dgvErrataList1.CurrentRow.Index, PraciticeQuestionInfoCollection, True)
                frm.ShowDialog(Me)
                Me.Show()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 正誤表クリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvErrataList2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvErrataList2.CellContentClick
        Try
            logger.Start()
            If e.ColumnIndex = QUESTIONNO_LEFT.Index And e.RowIndex <> -1 Then
                Dim PraciticeQuestionInfoCollection As New PracticeQuestionShow.PraciticeQuestionInfoCollection
                createPraciticeQuestionInfoCollection(dgvErrataList1, PraciticeQuestionInfoCollection)
                createPraciticeQuestionInfoCollection(dgvErrataList2, PraciticeQuestionInfoCollection)
                Dim frm As New PracticeQuestionShow.frmPracticeQuestionShow(dgvErrataList2.CurrentRow.Index + 50, PraciticeQuestionInfoCollection, True)
                frm.ShowDialog(Me)
                Me.Show()
            End If
            logger.End()
        Catch ex As Exception
            logger.Error(ex)
            Call MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    ''' <summary>
    ''' 戻る
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Try
            logger.Start()
            Me.DialogResult = DialogResult.OK
            logger.End()
            Me.Close()
        Catch ex As Exception
            logger.End()
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

    ''' <summary>
    ''' Enterイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>スクロール位置が一番上に移動するのを防ぐ</remarks>
    Private Sub dgvErrataList1_Enter(sender As System.Object, e As System.EventArgs) Handles dgvErrataList1.Enter
        pnlErrata.Focus()
    End Sub

    ''' <summary>
    ''' Enterイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>スクロール位置が一番上に移動するのを防ぐ</remarks>
    Private Sub dgvErrataList2_Enter(sender As System.Object, e As System.EventArgs) Handles dgvErrataList2.Enter
        pnlErrata.Focus()
    End Sub
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' 総合テスト結果_詳細を設定する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setSynthesisRsultList()
        '総合テスト結果_詳細
        '問番号設定
        Dim dataview As New DataView
        Dim dtLeft As New DataTable
        Dim dtRight As New DataTable
        Dim rowFilter As String = _synthesisResultList.DefaultView.RowFilter

        dataview.Table = _synthesisResultList
        dataview.Sort = "QUESTIONNO_NUM ASC"

        dataview.RowFilter = rowFilter & " AND QUESTIONNO_NUM <= 50"
        dgvErrataList1.DataSource = dataview.ToTable

        dataview.RowFilter = rowFilter & " AND QUESTIONNO_NUM > 50"
        dgvErrataList2.DataSource = dataview.ToTable
    End Sub

    ''' <summary>
    ''' 問題確認画面へ渡す演習問題情報を設定する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createPraciticeQuestionInfoCollection(ByVal dgrErrataList As DataGridView, ByRef praciticeQuestionInfoCollection As PracticeQuestionShow.PraciticeQuestionInfoCollection)
        For Each dgvr As DataGridViewRow In dgrErrataList.Rows
            Dim dr As DataRow = dgvr.DataBoundItem.Row
            Dim praciticeQuestionInfo As New PracticeQuestionShow.PraciticeQuestionInfo
            praciticeQuestionInfo.QuestionNo = dr("SHOWNO")
            praciticeQuestionInfo.QuestionCode = dr(Common.SynthesisResultDetail.ColumnIndex.QuestionCode)
            praciticeQuestionInfo.MiddleQuestionCode = dr(Common.SynthesisResultDetail.ColumnIndex.MainCode)
            praciticeQuestionInfo.IsMiddleQuestion = IIf(dr("QUESTIONCLASS") = "2", True, False)
            praciticeQuestionInfoCollection.Add(praciticeQuestionInfo)
        Next
    End Sub
#End Region
End Class