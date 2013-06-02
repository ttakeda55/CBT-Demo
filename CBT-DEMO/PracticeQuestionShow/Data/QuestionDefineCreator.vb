''' <summary>
''' 問題定義オブジェクト生成クラス
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefineCreator

#Region "----- メソッド -----"
    ''' <summary>
    ''' QuestionBank の内容を解析し、中設問、小問＋選択肢、解説のファイルを生成し、
    ''' 牽引が容易なように、問題番号と関連付いたデータとして保持します。
    ''' </summary>
    ''' <param name="questionDataBankCollection">問題定義オブジェクト生成元の QuestionBank オブジェクトのコレクション</param>
    ''' <returns>問題定義オブジェクトのコンテナ</returns>
    ''' <remarks></remarks>
    Public Shared Function Create(ByVal questionDataBankCollection As Common.PracticeQuestionBankCollection) As QuestionDefineContainer
        Dim questionDefineContainer As QuestionDefineContainer = questionDefineContainer.GetInstance

        '中問番号と中問関連データのMAP
        Dim middleQuestionChasheDataMap As New Dictionary(Of String, MiddleQuestionCacheData)
        For Each questionBank As Common.PracticeQuestionBank In questionDataBankCollection
            Dim decorator As New QuestionBankDecorator(questionBank)

            If questionBank.IsMiddleMainQuestion Then '中設問のみ
                If middleQuestionChasheDataMap.ContainsKey(questionBank.MiddleQuestionCode) = False Then
                    middleQuestionChasheDataMap.Add(questionBank.MiddleQuestionCode, New MiddleQuestionCacheData())
                    middleQuestionChasheDataMap(questionBank.MiddleQuestionCode).practiceQuestionCode = ""
                    middleQuestionChasheDataMap(questionBank.MiddleQuestionCode).FilePath = decorator.CreateMiddleQuestionFile()
                End If
                Continue For
            ElseIf questionBank.IsMiddleQuestion And questionBank.IsMiddleMainQuestion = False Then  '中問内小問
                middleQuestionChasheDataMap(questionBank.MiddleQuestionCode).practiceQuestionCode = questionBank.QuestionCode
            Else    '単独小問
            End If

            Dim defineData As New QuestionDefine

            '問題番号
            defineData.QuestionCode = questionBank.QuestionCode

            '中問かどうか
            defineData.IsMiddleQuestion = questionBank.IsMiddleQuestion

            '中問番号
            defineData.MiddleQuestionNumber = questionBank.MiddleQuestionCode

            '中問リンク用データ
            If middleQuestionChasheDataMap.ContainsKey(questionBank.MiddleQuestionCode) Then
                defineData.MiddleQuestionFilePath = middleQuestionChasheDataMap(questionBank.MiddleQuestionCode).FilePath
                defineData.QuestionCodeInMiddleQuestion = middleQuestionChasheDataMap(questionBank.MiddleQuestionCode).practiceQuestionCode
            Else
                defineData.MiddleQuestionFilePath = String.Empty
                defineData.QuestionCodeInMiddleQuestion = -1
            End If

            '解説ファイル
            Dim commentFilePaths As List(Of String) = decorator.CreateCommentFiles(defineData.QuestionCode)
            If commentFilePaths.Count > 0 Then
                defineData.CommentFilePath = commentFilePaths(0)
            End If

            '小問＋選択肢ファイル
            Dim questionFilePaths As List(Of String) = decorator.CreateQuestionAndChoiceFiles(defineData.QuestionCode)
            If questionFilePaths.Count > 0 Then
                defineData.SmallQuestionFilePath = questionFilePaths(0)
            End If

            '正解答
            defineData.Answer = decorator.GetAnswer()

            '問題定義オブジェクトの追加
            questionDefineContainer.AddQustionDefine(defineData.QuestionCode, defineData)
        Next

        Return questionDefineContainer
    End Function

    ''' <summary>
    ''' 問題読み込み処理
    ''' </summary>
    ''' <returns>初期化結果コード</returns>
    ''' <remarks></remarks>
    Public Shared Function ReadQuestionFile(ByVal FileName As String) As Constant.ResultCode
        Dim errCode As Constant.ResultCode = Constant.ResultCode.NormalEnd

        Try
            Dim questionFileNameList() As String = IO.Directory.GetFiles(Common.Constant.GetTempPath(), FileName)
            Select Case questionFileNameList.Length
                Case 0
                    errCode = Constant.ResultCode.QuestionFileNotFoundError
                Case 1
                    Dim questionFileName = questionFileNameList(0)
                    Dim questionDataBankCollection = Common.Serialize.BinaryFileToObject(IO.Path.GetFileName(questionFileName))
                    If questionDataBankCollection Is Nothing Then
                        errCode = Constant.ResultCode.QuestionFileReadError
                    Else
                        If QuestionDefineCreator.Create(questionDataBankCollection) Is Nothing Then
                            errCode = Constant.ResultCode.QuestionFileParseError
                        End If
                    End If
                Case Else
                    errCode = Constant.ResultCode.QuestionFileReadError
            End Select
        Catch ex As Exception
            errCode = Constant.ResultCode.UndefineError
        End Try

        Return errCode
    End Function
#End Region

#Region "解析用 inner データクラス"
    '同じ中問内で使用するデータ
    Private Class MiddleQuestionCacheData
        Public practiceQuestionCode As String     '中問内問題コード
        Public FilePath As String   '中問ファイルのファイルパス
    End Class
#End Region
End Class
