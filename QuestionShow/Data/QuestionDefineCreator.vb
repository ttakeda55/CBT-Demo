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
    Public Shared Function Create(ByVal questionDataBankCollection As Common.QuestionBankCollection) As QuestionDefineContainer
        Dim questionDefineContainer As New QuestionDefineContainer

        Dim questionNumber As Integer = 0
        '中問番号と中問関連データのMAP
        Dim middleQuestionChasheDataMap As New Dictionary(Of String, MiddleQuestionCacheData)
        For Each questionBank As Common.QuestionBank In questionDataBankCollection
            Dim decorator As New QuestionBankDecorator(questionBank)

            If decorator.IsMiddleQuestionOnly() Then '中設問のみ
                If middleQuestionChasheDataMap.ContainsKey(decorator.GetMiddleNumber) = False Then
                    middleQuestionChasheDataMap.Add(decorator.GetMiddleNumber(), New MiddleQuestionCacheData())
                    middleQuestionChasheDataMap(decorator.GetMiddleNumber).Index = 0
                    middleQuestionChasheDataMap(decorator.GetMiddleNumber).FilePath = decorator.CreateMiddleQuestionFile()
                End If
                Continue For
            ElseIf decorator.IsSmallQuestionInMiddleQuestion() Then  '中問内小問
                middleQuestionChasheDataMap(decorator.GetMiddleNumber).Index += 1
            Else    '単独小問
            End If

            Dim defineData As New QuestionDefine

            '小問共通処理
            questionNumber += 1

            '問題番号
            defineData.QuestionNumber = questionNumber

            '中問かどうか
            defineData.IsMiddleQuestion = decorator.HasMiddleQuestionTag

            '中問番号
            defineData.MiddleQuestionNumber = decorator.GetMiddleNumber()

            '大分類
            Dim parentCategoryID As Integer = 0
            If String.IsNullOrEmpty(Common.CategoryMaster.GetParentCategoryID(decorator.GetCategoryID())) = False Then
                parentCategoryID = Common.CategoryMaster.GetParentCategoryID(decorator.GetCategoryID())
            End If
            defineData.ParentCategoryID = parentCategoryID

            defineData.LargeCategoryName = Common.CategoryMaster.GetCategoryName(defineData.ParentCategoryID)

            '中分類
            Dim categoryID As Integer = 0
            If String.IsNullOrEmpty(decorator.GetCategoryID()) = False Then
                categoryID = decorator.GetCategoryID()
            End If
            defineData.CategoryID = categoryID

            defineData.MiddleCategoryName = Common.CategoryMaster.GetCategoryName(decorator.GetCategoryID())

            'テーマ
            defineData.QuestionTheme = decorator.GetTheme()

            '中問リンク用データ
            If middleQuestionChasheDataMap.ContainsKey(decorator.GetMiddleNumber) Then
                defineData.MiddleQuestionFilePath = middleQuestionChasheDataMap(decorator.GetMiddleNumber).FilePath
                defineData.MiddleQuestionIndex = middleQuestionChasheDataMap(decorator.GetMiddleNumber).Index
            Else
                defineData.MiddleQuestionFilePath = String.Empty
                defineData.MiddleQuestionIndex = -1
            End If

            '解説ファイル
            Dim commentFilePaths As List(Of String) = decorator.CreateCommentFiles(questionNumber)
            If commentFilePaths.Count > 1 Then
                defineData.FirstCommentFilePath = commentFilePaths(0)
                defineData.SecondCommentFilePath = commentFilePaths(1)
            End If

            '小問＋選択肢ファイル
            Dim questionFilePaths As List(Of String) = decorator.CreateQuestionAndChoiceFiles(defineData.QuestionNumber)
            If questionFilePaths.Count > 1 Then
                defineData.FirstSmallQuestionFilePath = questionFilePaths(0)
                defineData.SecondSmallQuestionFilePath = questionFilePaths(1)
            End If

            '初回、再試験の正解答
            defineData.FirstAnswer = decorator.GetFirstAnswer()
            defineData.SecondAnswer = decorator.GetSecondAnswer()

            '問題定義オブジェクトの追加
            questionDefineContainer.AddQustionDefine(defineData.QuestionNumber, defineData)
        Next

        Return questionDefineContainer
    End Function
#End Region

#Region "解析用 inner データクラス"
    '同じ中問内で使用するデータ
    Private Class MiddleQuestionCacheData
        Public Index As Integer     '中問内インデックス
        Public FilePath As String   '中問ファイルのファイルパス
    End Class
#End Region
End Class
