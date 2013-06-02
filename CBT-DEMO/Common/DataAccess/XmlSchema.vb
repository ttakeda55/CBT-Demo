Public Class XmlSchema

    ''' <summary>
    ''' カテゴリーのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetCategorySchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Category)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 団体のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetGroupSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Group)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 受講者のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetStudentSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Student)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' テスト結果_ヘッダのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetTestResultHeaderSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.TestResultHeader)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' テスト結果_明細のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetTestResultDetailSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.TestResultDetail)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' システム管理者のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSystemUserSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SystemUser)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 配信日のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetDeliverySchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Delivery)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 復号キーのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetDecryptionkeySchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Decryptionkey)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 逐次演習結果ヘッダのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSerialResultHeaderSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SerialResultHeader)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 逐次演習結果明細のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSerialResultDetailSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SerialResultDetail)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 小テスト結果ヘッダのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetMiniResultHeaderSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.MiniResultHeader)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 小テスト結果明細のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetMiniResultDetailSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.MiniResultDetail)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 総合テスト結果ヘッダのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSynthesisResultHeaderSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SynthesisResultHeader)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 総合テスト結果明細のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSynthesisResultDetailSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SynthesisResultDetail)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 指定テストヘッダのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSpecificHeaderSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SpecificHeader)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 指定テスト明細のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSpecificDetailSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SpecificDetail)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 総合テストヘッダのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSynthesisHeaderSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SynthesisHeader)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 総合テスト明細のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetSynthesisDetailSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.SynthesisDetail)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 再演習のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetReviewSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Review)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' コースのスキーマを取得します
    ''' </summary>
    Public Shared Sub GetCourseSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Course)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 問題群のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetCollectionSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.Collection)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 模擬テスト一覧のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetQuestionListSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.QuestionList)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 模擬テスト一覧のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetPracticeQuestionListSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.PracticeQuestionList)
        dt.ReadXmlSchema(ts)
    End Sub

    ''' <summary>
    ''' 模擬テスト一覧のスキーマを取得します
    ''' </summary>
    Public Shared Sub GetWebServiceUrlSchema(ByRef dt As DataTable)
        Dim ts As New IO.StringReader(My.Resources.WebServiceUrl)
        dt.ReadXmlSchema(ts)
    End Sub
End Class
