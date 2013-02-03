Imports CST.CBT.eIPSTA.Common
Imports System.IO

''' <summary>
''' 団体管理共通クラス
''' </summary>
''' <remarks></remarks>
Public Class GroupClass

    Private Shared ReadOnly _instance As New GroupClass()

    ''' <summary>
    ''' 自身のインスタンスを取得します。
    ''' </summary>  
    ''' <returns></returns>
    Public Shared Function GetInstance() As GroupClass
        Return _instance
    End Function

    ''' <summary>指定した精度の数値に切り捨てします。</summary>
    ''' <param name="dValue">丸め対象の倍精度浮動小数点数。</param>
    ''' <param name="iDigits">戻り値の有効桁数の精度。</param>
    ''' <returns>iDigits に等しい精度の数値に切り捨てられた数値。</returns>
    Public Function ToRoundDown(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor(dValue * dCoef) / dCoef
        Else
            Return System.Math.Ceiling(dValue * dCoef) / dCoef
        End If
    End Function

    ''' <summary>
    ''' ファイル情報の取得
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub getFileInfo()
        Dim files As String() = System.IO.Directory.GetFiles(Common.Constant.GetTempPath, "*", System.IO.SearchOption.TopDirectoryOnly)
        Dim htFileInfo As New Hashtable
        For Each fileName As String In files
            htFileInfo.Add(fileName, System.IO.File.GetLastWriteTime(fileName))
        Next

        Dim dataBanker As CBTCommon.DataBanker = CBTCommon.DataBanker.GetInstance
        dataBanker("FILEINFO") = htFileInfo
    End Sub

    ''' <summary>
    ''' 得点範囲チェック
    ''' </summary>
    ''' <param name="start">得点（開始）</param>
    ''' <param name="ends">得点（終了）</param>
    ''' <returns>True:正常終了, False:チェックエラー</returns>
    Public Function RangeCheck(ByVal start As String, ByVal ends As String) As Boolean
        Dim tstart As Integer
        Dim tends As Integer
        If Not (start = "") Then
            If Not IsNumeric(start) Then
                Return False
            End If
        End If
        If Not (ends = "") Then
            If Not IsNumeric(ends) Then
                Return False
            End If
        End If
        If tstart > tends Or tstart > 1000 Or tends > 1000 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 得点範囲チェック
    ''' </summary>
    ''' <param name="txtStrategyStart"></param>
    ''' <param name="txtStrategyEnd"></param>
    ''' <param name="txtManagementStart"></param>
    ''' <param name="txtManagementEnd"></param>
    ''' <param name="txtTechnologyStart"></param>
    ''' <param name="txtTechnologyEnd"></param>
    ''' <param name="txtTotalStart"></param>
    ''' <param name="txtTotalEnd"></param>
    ''' <returns></returns>
    ''' <remarks>True:正常終了, False:チェックエラー</remarks>
    Public Function PointRangeCheck(ByVal txtStrategyStart As TextBox,
                               ByVal txtStrategyEnd As TextBox,
                               ByVal txtManagementStart As TextBox,
                               ByVal txtManagementEnd As TextBox,
                               ByVal txtTechnologyStart As TextBox,
                               ByVal txtTechnologyEnd As TextBox,
                               ByVal txtTotalStart As TextBox,
                               ByVal txtTotalEnd As TextBox) As Boolean
        'ストラテジ系
        If Not Common.InputCheck.PointRangeCheck(txtStrategyStart.Text, "ストラテジ系の得点(以上)") Then Return False
        If Not Common.InputCheck.PointRangeCheck(txtStrategyEnd.Text, "ストラテジ系の得点(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtStrategyStart.Text, txtStrategyEnd.Text, "ストラテジ系の得点") Then Return False
        'マネジメント系
        If Not Common.InputCheck.PointRangeCheck(txtManagementStart.Text, "マネジメント系の得点(以上)") Then Return False
        If Not Common.InputCheck.PointRangeCheck(txtManagementEnd.Text, "マネジメント系の得点(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtManagementStart.Text, txtManagementEnd.Text, "マネジメント系の得点") Then Return False
        'テクノロジ系
        If Not Common.InputCheck.PointRangeCheck(txtTechnologyStart.Text, "テクノロジ系の得点(以上)") Then Return False
        If Not Common.InputCheck.PointRangeCheck(txtTechnologyEnd.Text, "テクノロジ系の得点(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtTechnologyStart.Text, txtTechnologyEnd.Text, "テクノロジ系の得点") Then Return False
        '総合正解率
        If Not Common.InputCheck.PointRangeCheck(txtTotalStart.Text, "総合評価点(以上)") Then Return False
        If Not Common.InputCheck.PointRangeCheck(txtTotalEnd.Text, "総合評価点(以下)") Then Return False
        If Not Common.InputCheck.MinAndMaxCheck(txtTotalStart.Text, txtTotalEnd.Text, "総合評価点") Then Return False

        Return True
    End Function


    ''' <summary>
    ''' 率範囲チェック
    ''' </summary>
    ''' <param name="start">率（開始）</param>
    ''' <param name="ends">率（終了）</param>
    ''' <returns>True:正常終了, False:チェックエラー</returns>
    Public Function RateRangeCheck(ByVal start As String, ByVal ends As String) As Boolean
        Dim nstart As Single
        Dim nends As Single
        If Not (start = "") Then
            If Not IsNumeric(start) Then
                Return False
            Else
                nstart = CSng(start)
            End If
        End If
        If Not (ends = "") Then
            If Not IsNumeric(ends) Then
                Return False
            Else
                nends = CSng(ends)
            End If
        End If
        If nstart > 100 Or nends > 100 Or (start <> String.Empty And ends <> String.Empty AndAlso nstart > nends) Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 団体取得
    ''' </summary>
    ''' <param name="Mode">1:システム管理，0:団体管理</param>
    ''' <param name="Group">グループコード</param>
    ''' <returns>団体情報</returns>
    Public Function GetGroup(ByVal Mode As Integer, ByVal Group As String) As System.Data.DataTable
        Dim TempPath As String = Common.Constant.GetTempPath
        Dim GroupTbl As New System.Data.DataTable
        Dim TmpGroupTbl As New System.Data.DataTable
        Dim KeyUserId(0) As DataColumn

        Dim FileName As String

        ' 受講者 
        If Directory.Exists(TempPath) Then
            If Mode = 1 Then
                'システム管理
                FileName = Common.Constant.CST_GROUP_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML
            Else
                '団体管理
                FileName = Common.Constant.CST_GROUP_FILENAME & Group & Common.Constant.CST_EXTENSION_XML
            End If

            For Each FileList As String In Directory.GetFiles(TempPath, FileName)
                TmpGroupTbl = Common.Serialize.XmlToDataTable(FileList.Substring(TempPath.Length()))
                GroupTbl.Merge(TmpGroupTbl)
            Next
        End If

        ' ''主キー設定
        'KeyUserId(0) = Student.Columns("USERID")
        'Student.PrimaryKey = KeyUserId

        Return GroupTbl
    End Function

    ''' <summary>
    ''' 受講者取得
    ''' </summary>
    ''' <param name="Mode">1:システム管理、以外：団体</param>
    ''' <param name="Group"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStudent(ByVal Mode As Integer, ByVal Group As String) As System.Data.DataTable
        Dim TempPath As String = Common.Constant.GetTempPath
        Dim Student As New System.Data.DataTable
        Dim TmpStudent As New System.Data.DataTable
        Dim KeyUserId(0) As DataColumn

        Dim FileName As String
        Dim TmpFileName As String

        ' 受講者 
        If Directory.Exists(TempPath) Then
            If Mode = 1 Then
                'システム管理
                FileName = Common.Constant.CST_STUDENT_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML
            Else
                '団体管理
                FileName = Common.Constant.CST_STUDENT_FILENAME & Group & "*" & Common.Constant.CST_EXTENSION_XML
            End If

            For Each FileList As String In Directory.GetFiles(TempPath, FileName)
                TmpFileName = FileList.Substring(TempPath.Length())
                TmpStudent = Common.Serialize.XmlToDataTable(TmpFileName)
                If Mode = 1 Then
                    Group = GetGroupCode(TmpFileName, TmpStudent.Rows(0)("USERID"))
                End If
                TmpStudent = StudentGroupCodeAdd(TmpStudent, Group)
                Student.Merge(TmpStudent)
            Next
        End If

        ' ''主キー設定
        'KeyUserId(0) = Student.Columns("USERID")
        'Student.PrimaryKey = KeyUserId

        Return Student
    End Function

    ''' <summary>
    ''' グループコード取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGroupCode(ByVal TmpFileName As String, ByVal UserId As String) As String
        Dim Tmp As String = TmpFileName.Substring(Common.Constant.CST_STUDENT_FILENAME.Length)
        Return Tmp.Substring(0, Tmp.Length - Common.Constant.CST_EXTENSION_XML.Length)
    End Function

    ''' <summary>
    ''' 受講者テーブルにグループコード、コースを追加
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StudentGroupCodeAdd(ByVal InStudent As System.Data.DataTable, ByVal GroupCode As String) As System.Data.DataTable
        Dim Student As System.Data.DataTable
        Dim Group As System.Data.DataTable

        Student = InStudent.Copy
        '団体コード
        Student.Columns.Add("GROUPCODE", GetType(String))
        Student.Columns.Add("COURSE", GetType(String))
        For Each Row As DataRow In Student.Rows
            Row("GROUPCODE") = GroupCode
            Group = GetGroup(0, GroupCode)
            For Each GRow As DataRow In Group.Rows
                If GroupCode = GRow("GROUPCODE") Then
                    Row("COURSE") = GRow("COURSE")
                End If
            Next
        Next

        Return Student
    End Function

    ''' <summary>
    ''' 試験結果集計_ヘッダ取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTestResultHeaderSum(ByVal Mode As Integer, ByVal Group As String) As System.Data.DataTable
        Dim TempPath As String = Common.Constant.GetTempPath               'PATH 

        Dim TestHead As New System.Data.DataTable
        Dim TmpTestHead As New System.Data.DataTable
        Dim KeyUserId(1) As DataColumn

        Dim FileName As String

        If Directory.Exists(TempPath) Then
            If Mode = 1 Then
                'システム管理者 
                FileName = Common.Constant.CST_TESTHEADSUM_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML
            Else
                '試験結果集計_ヘッダ
                FileName = Common.Constant.CST_TESTHEADSUM_FILENAME & Group & Common.Constant.CST_EXTENSION_XML
            End If

            '試験結果集計_ヘッダ
            For Each FileList As String In Directory.GetFiles(TempPath, FileName)
                Debug.Print(FileList)
                TmpTestHead = Common.Serialize.XmlToDataTable(FileList.Substring(TempPath.Length()))
                TestHead.Merge(TmpTestHead)
            Next
        End If

        ' ''主キー設定
        'KeyUserId(0) = TestHead.Columns("USERID")
        'KeyUserId(1) = TestHead.Columns("TESTCOUNT")
        'TestHead.PrimaryKey = KeyUserId

        Return TestHead
    End Function

    ''' <summary>
    ''' 試験結果集計_明細取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTestResultDetailSum(ByVal Mode As Integer, ByVal Group As String) As System.Data.DataTable
        Dim TempPath As String = Common.Constant.GetTempPath

        Dim TestDetail As New System.Data.DataTable
        Dim TmpTestDetail As New System.Data.DataTable
        Dim KeyUserId(2) As DataColumn

        Dim FileName As String

        If Directory.Exists(TempPath) Then
            If Mode = 1 Then
                'システム管理者 
                FileName = Common.Constant.CST_TESTDETAILSUM_FILENAME & "*" & Common.Constant.CST_EXTENSION_XML
            Else
                '試験結果集計_明細
                FileName = Common.Constant.CST_TESTDETAILSUM_FILENAME & Group & Common.Constant.CST_EXTENSION_XML
            End If

            '試験結果集計_明細
            For Each FileList As String In Directory.GetFiles(TempPath, FileName)
                TmpTestDetail = Common.Serialize.XmlToDataTable(FileList.Substring(TempPath.Length()))
                TestDetail.Merge(TmpTestDetail)
            Next
        End If

        ' ''主キー設定
        'KeyUserId(0) = TestDetail.Columns("USERID")
        'KeyUserId(1) = TestDetail.Columns("TESTCOUNT")
        'KeyUserId(2) = TestDetail.Columns("QUESTIONNO")
        'TestDetail.PrimaryKey = KeyUserId

        Return TestDetail
    End Function

    ''' <summary>
    ''' 新着情報取得（メール）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMail() As System.Data.DataTable
        Dim TempPath As String = Common.Constant.GetTempPath
        Dim Mail As New System.Data.DataTable
        Dim FileName As String
        Dim MRow As DataRow
        Dim Message As String

        '
        Mail.Columns.Add("MESSAGE", GetType(String))
        Mail.Columns.Add("FILENAME", GetType(String))

        ' 受講者 
        If Directory.Exists(TempPath) Then
            'ファイル名
            FileName = Common.Constant.CST_MAIL_FILENAME & "*" & Common.Constant.CST_EXTENSION_TXT

            For Each FileList As String In Directory.GetFiles(TempPath, FileName)
                Message = File.ReadAllText(FileList)
                MRow = Mail.NewRow()
                MRow("MESSAGE") = Message
                MRow("FILENAME") = FileName
                Mail.Rows.Add(MRow)
            Next
        End If

        Return Mail
    End Function

    ''' <summary>
    ''' 順位設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetRank(ByVal Table As System.Data.DataTable, ByVal Item As String, ByVal Sort As String, ByVal Where As String) As System.Data.DataTable
        Dim TmpTable As System.Data.DataTable

        Dim PreTotalPoints As Integer = -1
        Dim PreRankNo As Integer = -1
        Dim RankNo As Integer = 0

        TmpTable = Table.Copy

        For Each row As DataRow In TmpTable.Select(Where, Item & " " & Sort)
            If IsNumeric(row(Item)) Then

                RankNo += 1
                If PreTotalPoints <> CInt(row(Item)) Then
                    PreTotalPoints = CInt(row(Item))
                    row(Item & "RANK") = RankNo
                    PreRankNo = RankNo
                Else
                    row(Item & "RANK") = PreRankNo
                End If
            End If
        Next

        Return TmpTable
    End Function

    ''' <summary>
    ''' 試験結果集計_明細マージ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestHeadDetailMergr(ByVal MainTbl As DataTable, ByVal SubTbl As DataTable) As DataTable
        Dim ReturnTbl As DataTable
        Dim ColName As Array = {"TESTDATE",
                                "TESTTIME",
                                "CATEGORYPOINT1_A",
                                "CATEGORYPOINT1_B",
                                "CATEGORYPOINT1_C",
                                "TOTALPOINTS",
                                "CATEGORYPOINT2_A",
                                "CATEGORYPOINT2_B",
                                "CATEGORYPOINT2_C",
                                "CATEGORYPOINT2_D",
                                "CATEGORYPOINT2_E",
                                "CATEGORYPOINT2_F",
                                "CATEGORYPOINT2_G",
                                "CATEGORYPOINT2_H",
                                "CATEGORYPOINT2_I",
                                "RESULT",
                                "NAME",
                                "SECTION1",
                                "SECTION2",
                                "GROUPCODE",
                                "COURSE"}

        ReturnTbl = MainTbl.Copy
        For Each col As DataColumn In SubTbl.Columns
            If Not ReturnTbl.Columns.Contains(col.ColumnName) Then
                ReturnTbl.Columns.Add(col.ColumnName, col.DataType)
            End If
        Next

        For Each row As DataRow In ReturnTbl.Rows
            For Each TRow As DataRow In SubTbl.Select("USERID = '" & row("USERID") & "' AND TESTCOUNT = '" & row("TESTCOUNT") & "'")
                For Each col As String In ColName
                    row(col) = TRow(col)
                Next
            Next
        Next

        Return ReturnTbl
    End Function

    ''' <summary>
    ''' 受講者_試験結果集計マージ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StudentTestHeadMergr(ByVal StuTbl As DataTable, ByVal HeadTbl As DataTable) As DataTable
        Dim ReturnTbl As DataTable
        Dim ColName As Array = {"NAME",
                                "SECTION1",
                                "SECTION2",
                                "GROUPCODE",
                                "COURSE"}

        ReturnTbl = HeadTbl.Copy

        For Each col As DataColumn In StuTbl.Columns
            If Not ReturnTbl.Columns.Contains(col.ColumnName) Then
                ReturnTbl.Columns.Add(col.ColumnName, col.DataType)
            End If
        Next
        For Each Row As DataRow In ReturnTbl.Rows
            For Each TRow As DataRow In StuTbl.Select("USERID = '" & Row("USERID") & "'")
                For Each col As String In ColName
                    Row(col) = TRow(col)
                Next
            Next
        Next
        ReturnTbl.Merge(StuTbl)

        Return ReturnTbl
    End Function

    ''' <summary>
    ''' 試験結果集計_受講者マージ
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestHeadStudentMergr(ByVal HeadTbl As DataTable, ByVal StuTbl As DataTable) As DataTable
        Dim ReturnTbl As DataTable
        Dim ColName As Array = {"NAME",
                                "SECTION1",
                                "SECTION2",
                                "GROUPCODE",
                                "COURSE"}

        ReturnTbl = HeadTbl.Copy
        For Each col As DataColumn In StuTbl.Columns
            If Not ReturnTbl.Columns.Contains(col.ColumnName) Then
                ReturnTbl.Columns.Add(col.ColumnName, col.DataType)
            End If
        Next

        For Each row As DataRow In ReturnTbl.Rows
            For Each TRow As DataRow In StuTbl.Select("USERID = '" & row("USERID") & "'")
                For Each col As String In ColName
                    row(col) = TRow(col)
                Next
            Next
        Next

        Return ReturnTbl
    End Function

    ''' <summary>
    ''' 問題ファイル名取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuestionFileName(ByVal Group As String) As String
        Dim FileName As String = ""

        Dim dtGroup As DataTable = GetGroup(0, Group)
        Dim dtCourse As New DataTable
        Dim dtQuestion As New DataTable
        Dim courseNo As String = ""
        Dim mockTestNo As String = ""
        Dim useStart As String = ""
        Dim mockTestName As String = ""


        If dtGroup.Rows.Count > 0 Then
            courseNo = dtGroup.Rows(0).Item(Common.Group.ColumnIndex.CourseNo)

            dtCourse = Common.Course.GetAll(Common.Constant.CST_COURSE_FILENAME & Common.Constant.CST_EXTENSION_XML)
            Dim drs As DataRow() = dtCourse.Select("COURSENO = '" & courseNo & "'")
            If drs.Length > 0 Then
                '対応模擬テストNO
                mockTestNo = drs(0).Item(Common.Course.ColumnIndex.MockTestNo)
                '利用開始日
                useStart = drs(0).Item(Common.Course.ColumnIndex.UseStart)

                '模擬テスト
                Dim dtQuestionList As DataTable = Common.QuestionList.GetAll(Common.Constant.CST_QUESTIONLIST_FILENAME & Common.Constant.CST_EXTENSION_XML)
                FileName = Common.Constant.CST_QUESTION_FILENAME & Common.QuestionList.GetMockTestName(dtQuestionList, mockTestNo, useStart)
            End If
        End If

        Return FileName
    End Function

    ''' <summary>
    ''' 模擬テスト配信
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDelivery(ByVal Course As String) As System.Data.DataTable
        Dim TempPath As String = Common.Constant.GetTempPath

        Dim Delivery As New System.Data.DataTable
        Dim FileName As String

        '模擬テスト配信
        FileName = Common.Constant.CST_DELIVERY_FILENAME & Course & Common.Constant.CST_EXTENSION_XML
        If File.Exists(TempPath & FileName) Then
            '模擬テスト配信
            Delivery = Common.Serialize.XmlToDataTable(FileName)
        End If

        Return Delivery
    End Function

    ''' <summary>
    ''' 受講者テーブルにグループコード、コースを追加
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DetailSrorAdd(ByVal Detail As System.Data.DataTable) As System.Data.DataTable
        Dim ReturnDetail As System.Data.DataTable

        If Not Detail.Columns.Contains("QUESTIONINT") Then
            Detail.Columns.Add("QUESTIONINT", GetType(Integer))
            For Each Row As DataRow In Detail.Rows
                Row("QUESTIONINT") = CInt(Row("QUESTIONNO"))
            Next
        End If
        ReturnDetail = Detail.Clone()
        For Each row As DataRow In Detail.Select("", "USERID,TESTCOUNT,QUESTIONINT")
            ReturnDetail.ImportRow(row)
        Next
        Return ReturnDetail
    End Function

    ''' <summary>
    ''' 指定のファイルをFTPUploadします。
    ''' </summary>
    ''' <param name="upFileList">Upload するファイル</param>
    ''' <returns>true : 全てのアップロード成功、false : いずれかのアップロード失敗</returns>
    ''' <remarks></remarks>
    Private Shared Function UploadFile(ByVal upFileList As List(Of String)) As Boolean
        Dim ret As Boolean = True


        Return ret
    End Function
End Class
