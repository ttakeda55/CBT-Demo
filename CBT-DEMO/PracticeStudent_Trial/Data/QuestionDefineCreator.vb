
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class QuestionDefineCreator


    Public Shared Function Create(ByVal questionDataBankCollection As Common.VetnurseQuestionBankCollection _
                                , ByRef questionDefineContainer As QuestionDefineContainer) As Boolean
        Dim blnRet As Boolean = True

        Try
            'インスタンス生成
            If IsNothing(questionDefineContainer) Then questionDefineContainer = New QuestionDefineContainer
            Dim middleQuestionChasheDataMap As New Dictionary(Of String, MiddleQuestionCacheData)
            For Each questionBank As Common.VetNurseQuestionBank In questionDataBankCollection
                Dim decorator As New QuestionBankDecorator(questionBank)

                If decorator.IsMiddleQuestionOnly() Then
                    '中問設問のみ
                    If middleQuestionChasheDataMap.ContainsKey(decorator.GetMiddleNumber) = False Then
                        middleQuestionChasheDataMap.Add(decorator.GetMiddleNumber(), New MiddleQuestionCacheData())
                        middleQuestionChasheDataMap(decorator.GetMiddleNumber).Index = 0
                        middleQuestionChasheDataMap(decorator.GetMiddleNumber).Theme = decorator.GetTheme()
                        middleQuestionChasheDataMap(decorator.GetMiddleNumber).FilePath = decorator.CreateMiddleQuestionFile()
                    End If
                    Continue For
                ElseIf decorator.IsSmallQuestionInMiddleQuestion() Then
                    '中問内小問
                    middleQuestionChasheDataMap(decorator.GetMiddleNumber).Index += 1
                Else
                    '単独小問
                End If

                '問題定義インスタンス生成
                Dim defineData As New QuestionDefine
                '問題コード
                defineData.QuestionNumber = decorator.GetQuestionNumber
                '中問かどうか
                defineData.IsMiddleQuestion = decorator.IsMiddleQuestionOnly
                '中問問題コード
                defineData.MiddleQuestionNumber = decorator.GetMiddleNumber
                'テーマ
                defineData.QuestionTheme = decorator.GetTheme
                '中問リンク用データ
                If middleQuestionChasheDataMap.ContainsKey(decorator.GetMiddleNumber) Then
                    defineData.MiddleQuestionFilePath = middleQuestionChasheDataMap(decorator.GetMiddleNumber).FilePath
                    defineData.MiddleQuestionIndex = middleQuestionChasheDataMap(decorator.GetMiddleNumber).Index
                    defineData.MiddleQuestionTheme = middleQuestionChasheDataMap(decorator.GetMiddleNumber).Theme
                Else
                    defineData.MiddleQuestionFilePath = ""
                    defineData.MiddleQuestionIndex = -1
                    defineData.MiddleQuestionTheme = ""
                End If
                '解説ファイル
                defineData.CommentFilePath = decorator.CreateCommentFiles(defineData.QuestionNumber)
                '小問＋選択肢ファイル
                defineData.SmallQuestionFilePath = decorator.CreateQuestionAndChoiceFiles(defineData.QuestionNumber)
                '正解答
                defineData.Answer = decorator.GetAnswer
                '問題定義追加
                defineData.QuestionOrignal = questionBank
                If IsNothing(questionDefineContainer.Item(defineData.QuestionNumber)) Then
                    questionDefineContainer.AddQustionDefine(defineData.QuestionNumber, defineData)
                End If
            Next

        Catch ex As Exception
            'ログ出力
            Dim _Log As Common.AppLogger = Common.AppLogger.GetAppLogger(New QuestionDefineCreator)
            _Log.Error(ex)
            blnRet = False
        End Try
        Return blnRet
    End Function

#Region "解析用 inner データクラス"

    '同じ中問内で使用するデータ
    Private Class MiddleQuestionCacheData
        Public Index As Integer     '中問内インデックス
        Public Theme As String      '中問テーマ
        Public FilePath As String   '中問ファイルのファイルパス
    End Class

#End Region

End Class
