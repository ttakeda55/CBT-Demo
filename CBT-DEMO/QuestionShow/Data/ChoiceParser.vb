''' <summary>
''' 選択肢を解析するクラス
''' </summary>
''' <remarks></remarks>
Public Class ChoiceParser

#Region "----- メソッド -----"

#Region "解析"
    ''' <summary>
    ''' 指定の選択肢の混ざった html 文字列を解析し、選択肢を分解した文字列を返します。
    ''' </summary>
    ''' <param name="mixedChoiceHtml">選択肢の混ざった html 文字列</param>
    ''' <returns>選択肢を分解した文字列</returns>
    ''' <remarks></remarks>
    Public Shared Function Parse(ByVal mixedChoiceHtml As String) As List(Of String)

        Dim choiceHtmlList As New List(Of String)
        Dim dom As mshtml.IHTMLDocument2 = Nothing

        Try
            '解析元となる、選択肢の混ざった Html の dom オブジェクト生成
            dom = CreateDom(mixedChoiceHtml)

            '解析元となるトップの BODY ノード
            Dim bodyNode As mshtml.IHTMLDOMNode = CType(dom.body, mshtml.IHTMLDOMNode)

            '初回、再試験用解析データリストの作成
            Dim parsingDatas As New List(Of ParsingData)

            '内容物種別解析
            Dim hasTableTag As Boolean = HasTableTagNode(bodyNode)

            '内容物解析
            For testCount = Constant.TestCounts.FirstTest To Constant.TestCounts.Max - 1

                '内容を書き換えて、Html を生成するためにコピーして保持する。
                parsingDatas.Add(New ParsingData(bodyNode.cloneNode(True)))

                'テーブル無しの場合は、TOP ノードを BODY とする。(ソート用の親エレメント設定)
                If hasTableTag = False Then
                    parsingDatas(testCount).AddParentElement(parsingDatas(testCount).BodyElement)
                End If

                '実解析処理
                Dim targetNode As mshtml.IHTMLDOMNode = parsingDatas(testCount).BodyElement
                For Each topNode As mshtml.IHTMLDOMNode In targetNode.childNodes
                    If topNode.nodeType = 1 Then 'Element
                        Dim topElement As mshtml.IHTMLElement = CType(topNode, mshtml.IHTMLElement)
                        Select Case topElement.tagName
                            Case "P"
                                If hasTableTag = False Then
                                    ParseChoicePTag(topElement, testCount, parsingDatas(testCount))
                                End If
                            Case "TABLE"
                                parsingDatas(testCount).IsTable = True
                                ParseChoiceTableTag(topElement, testCount, parsingDatas(testCount))
                        End Select
                    End If
                Next topNode
            Next

            'ソートされたデータの作成
            For Each parsingData As ParsingData In parsingDatas
                parsingData.Sort()
            Next

            '戻り値作成
            For Each parsingData As ParsingData In parsingDatas
                choiceHtmlList.Add(parsingData.BodyElement.innerHTML)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If dom Is Nothing = False Then
                DisposeDom(dom)
            End If
        End Try

        Return choiceHtmlList
    End Function
#End Region

#Region "PTag解析"
    ''' <summary>
    ''' PTag の内容を解析します。
    ''' </summary>
    ''' <param name="element">PTag のエレメント</param>
    ''' <param name="testCount">テスト回数</param>
    ''' <param name="pData">[out] 解析結果データ</param>
    ''' <remarks></remarks>
    Private Shared Sub ParseChoicePTag(ByVal element As mshtml.IHTMLElement, ByVal testCount As Constant.TestCounts, ByRef pData As ParsingData)
        Dim mcsSelect As System.Text.RegularExpressions.MatchCollection = GetChoiceMarks(element)


        '選択肢が2個以上存在
        If mcsSelect Is Nothing = False AndAlso mcsSelect.Count > 1 Then

            Dim choiceMarks As String = String.Empty
            For i As Integer = 0 To mcsSelect.Count - 1
                choiceMarks &= mcsSelect.Item(i).ToString
            Next

            '選択肢
            pData.ParsingChoiceMark = StrConv(mcsSelect(testCount).ToString(), VbStrConv.Wide)

            '今回の選択肢のみでデータの構築
            element.innerHTML = element.innerHTML.Replace(choiceMarks, pData.ParsingChoiceMark)
            pData.AddBlockDataOfParsingChoiceMark(element)
        Else
            If IgnoreElement(element) = False Then
                pData.AddBlockDataOfParsingChoiceMark(element)
            End If
        End If
    End Sub


#End Region

#Region "TableTag解析"
    ''' <summary>
    ''' テーブルタグの解析を行います。
    ''' </summary>
    ''' <param name="element">TABLE タグのエレメント</param>
    ''' <param name="testCount">試験回数</param>
    ''' <param name="tableData">[out] 解析結果データ</param>
    ''' <remarks></remarks>
    Private Shared Sub ParseChoiceTableTag(ByRef element As mshtml.IHTMLElement, ByVal testCount As Constant.TestCounts, ByRef tableData As ParsingData)
        For Each tableNode As mshtml.IHTMLDOMNode In element.children 'TBodyループ
            Dim tBodyElement As mshtml.IHTMLElement = CastElementOfSafety(tableNode, "TBODY")
            If tBodyElement Is Nothing = False Then
                Dim isHeaderLine As Boolean = True

                For Each tBodyNode As mshtml.IHTMLDOMNode In tBodyElement.children 'TRループ
                    Dim trElement As mshtml.IHTMLElement = CastElementOfSafety(tBodyNode, "TR")
                    If trElement Is Nothing = False Then
                        '表の一行
                        If isHeaderLine Then
                            '1行目(ヘッダ行)
                            isHeaderLine = False
                            tableData.HeaderElement = trElement
                        Else
                            '2行目以降
                            Dim colmunCount As Integer = 1
                            For Each trNode As mshtml.IHTMLDOMNode In trElement.children
                                Dim tdElement As mshtml.IHTMLElement = CastElementOfSafety(trNode, "TD")
                                If tdElement Is Nothing = False Then

                                    Dim mcsSelect = System.Text.RegularExpressions.Regex.Matches( _
                                            tdElement.innerText, "[" & Common.Constant.CST_SELECTMARK & "]")
                                    '選択肢が2個以上存在
                                    If mcsSelect.Count > 1 Then
                                        Debug.Assert(colmunCount = 1)
                                        Dim choiceElement As mshtml.IHTMLElement = tdElement
                                        If tdElement.children.Length > 0 Then
                                            For Each tdNode As mshtml.IHTMLDOMNode In tdElement.children
                                                Dim tdPElement As mshtml.IHTMLElement = CastElementOfSafety(tdNode, "P")
                                                If tdPElement Is Nothing = False Then
                                                    choiceElement = tdPElement 
                                                End If
                                            Next
                                        End If

                                        '選択肢
                                        tableData.ParsingChoiceMark = StrConv(mcsSelect(testCount).ToString(), VbStrConv.Wide)

                                        Dim choiceMarks As String = String.Empty
                                        For i As Integer = 0 To mcsSelect.Count - 1
                                            choiceMarks &= mcsSelect.Item(i).ToString
                                        Next
                                        '今回の選択肢のみでデータの構築
                                        choiceElement.innerHTML = choiceElement.innerHTML.Replace(choiceMarks, tableData.ParsingChoiceMark)
                                    End If
                                End If
                                colmunCount += 1
                            Next
                            tableData.AddBlockDataOfParsingChoiceMark(CType(trElement, mshtml.IHTMLDOMNode).cloneNode(True))
                        End If
                    End If
                Next

                'ソートの親エレメントの設定
                tableData.AddParentElement(tBodyElement)
            End If
        Next
    End Sub
#End Region

#Region "ユーティリティ関数"
    ''' <summary>
    ''' 無視するエレメントかどうか
    ''' note BRタグのみの行は無視
    ''' </summary>
    ''' <param name="element">無視するか検査するエレメント</param>
    ''' <returns>true : 無視するエレメントである。 false : 無視しないエレメントである。</returns>
    ''' <remarks></remarks>
    Private Shared Function IgnoreElement(ByVal element As mshtml.IHTMLElement) As Boolean
        Dim ret As Boolean = False

        If String.IsNullOrEmpty(Trim(element.innerText)) Then

            Dim brMatch As System.Text.RegularExpressions.MatchCollection =
                System.Text.RegularExpressions.Regex.Matches(element.innerHTML, "<BR>")

            Dim nbspMatch As System.Text.RegularExpressions.MatchCollection =
                System.Text.RegularExpressions.Regex.Matches(element.innerHTML, "&nbsp;")

            If brMatch.Count <> 0 OrElse nbspMatch.Count <> 0 Then
                ret = True
            End If
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 指定のエレメントのテキストから、選択肢部を抜き出し取得します。
    ''' </summary>
    ''' <param name="element">選択肢を取得するエレメント</param>
    ''' <returns>選択肢 見つからなかった場合は nothing</returns>
    ''' <remarks></remarks>
    Private Shared Function GetChoiceMarks(ByVal element As mshtml.IHTMLElement) As System.Text.RegularExpressions.MatchCollection
        Dim ret As System.Text.RegularExpressions.MatchCollection = Nothing

        If element.innerText Is Nothing = False Then
            ret = System.Text.RegularExpressions.Regex.Matches( _
                    element.innerText, "[" & Common.Constant.CST_SELECTMARK & "]")
        End If

        Return ret
    End Function

    ''' <summary>
    ''' 指定のノードの第1階層の子に「TABLE」タグが一つでもあるかどうか
    ''' </summary>
    ''' <param name="bodyNode">検索するノード</param>
    ''' <returns>true : 「TABLE」タグがある、 false : 「TABLE」タグがない</returns>
    ''' <remarks></remarks>
    Private Shared Function HasTableTagNode(ByVal bodyNode As mshtml.IHTMLDOMNode) As Boolean
        Dim ret As Boolean = False

        For Each topNode As mshtml.IHTMLDOMNode In bodyNode.childNodes
            If topNode.nodeType = 1 Then
                Dim topElement As mshtml.IHTMLElement = CType(topNode, mshtml.IHTMLElement)
                If topElement.tagName = "TABLE" Then
                    ret = True
                    Exit For
                End If
            End If
        Next topNode

        Return ret
    End Function

    ''' <summary>
    ''' 指定のノードのタイプがエレメントの場合エレメントにキャストし、指定のタグネームの場合にエレメントを返します。
    ''' </summary>
    ''' <param name="node">キャスト元となるノード</param>
    ''' <param name="tagName">取得するタグネーム</param>
    ''' <returns>指定のタグネームのエレメント. 存在しない場合は nothing</returns>
    ''' <remarks></remarks>
    Private Shared Function CastElementOfSafety(ByRef node As mshtml.IHTMLDOMNode, ByVal tagName As String) As mshtml.IHTMLElement
        Dim ret As mshtml.IHTMLElement = Nothing

        If node.nodeType = 1 Then
            Dim element As mshtml.IHTMLElement = node
            If element.tagName = tagName Then
                ret = element
            End If
        End If

        Return ret
    End Function

#Region "dom"
    ''' <summary>
    ''' 指定の html 文字列から、dom オブジェクトを生成して返します。
    ''' </summary>
    ''' <param name="html">dom オブジェクトを取得する html 文字列</param>
    ''' <returns>dom オブジェクト</returns>
    ''' <remarks></remarks>
    Private Shared Function CreateDom(ByVal html As String) As mshtml.IHTMLDocument2
        Dim msdoc As New mshtml.HTMLDocument

        Dim imsdoc As mshtml.IHTMLDocument2

        imsdoc = CType(msdoc, mshtml.IHTMLDocument2)

        imsdoc.write(html)

        Return imsdoc
    End Function

    ''' <summary>
    ''' 指定の dom オブジェクトの後始末を行います。
    ''' </summary>
    ''' <param name="dom">後始末を行う dom オブジェクト</param>
    ''' <remarks></remarks>
    Private Shared Sub DisposeDom(ByRef dom As mshtml.IHTMLDocument2)
        dom.close()
    End Sub
#End Region

#End Region

#End Region

#Region "解析用 inner データクラス"
    ''' <summary>
    ''' 解析中のデータ
    ''' </summary>
    ''' <remarks></remarks>
    Private Class ParsingData
#Region "----- メンバ変数 -----"
        ''' <summary>
        ''' Top エレメント
        ''' </summary>
        ''' <remarks></remarks>
        Private _BodyElement As mshtml.IHTMLElement = Nothing

        ''' <summary>
        ''' ソート時に使用されるソート対象の親ノードのリスト
        ''' </summary>
        ''' <remarks></remarks>
        Private _ParentNodes As New List(Of mshtml.IHTMLElement)

        ''' <summary>
        ''' ヘッダーエレメント
        ''' ソートに関係なく、設定されている場合は、ソートデータの直前に挿入されます。
        ''' </summary>
        ''' <remarks></remarks>
        Private _HeaderElement As mshtml.IHTMLElement = Nothing

        ''' <summary>
        ''' 現在解析中の選択肢
        ''' </summary>
        ''' <remarks></remarks>
        Private _ParsingChoiceMark As String = String.Empty

        ''' <summary>
        ''' 選択肢と選択肢に関連するブロックデータのマップ(ソート用)
        ''' key 選択肢
        ''' value 選択肢に関連付いたエレメントのリスト
        ''' </summary>
        ''' <remarks></remarks>
        Private _ChoiceBlockMap As New SortedList(Of String, List(Of mshtml.IHTMLElement))

        ''' <summary>
        ''' テーブルかどうか
        ''' </summary>
        ''' <remarks></remarks>
        Private _IsTable As Boolean
#End Region

#Region "----- プロパティ -----"
        ''' <summary>
        ''' Top エレメントを取得します。
        ''' </summary>
        ''' <returns>Top エレメント</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property BodyElement As mshtml.IHTMLElement
            Get
                Return _BodyElement
            End Get
        End Property

        ''' <summary>
        ''' ソート時に使用されるソート対象の親ノードのリストを取得します。
        ''' </summary>
        ''' <returns>ソート時に使用されるソート対象の親ノードのリスト</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentNodes As List(Of mshtml.IHTMLElement)
            Get
                Return _ParentNodes
            End Get
        End Property

        ''' <summary>
        ''' ヘッダーエレメントの取得、設定を行います。
        ''' </summary>
        ''' <value>ヘッダーエレメント</value>
        ''' <returns>ヘッダーエレメント</returns>
        ''' <remarks></remarks>
        Public Property HeaderElement As mshtml.IHTMLElement
            Get
                Return _HeaderElement
            End Get
            Set(value As mshtml.IHTMLElement)
                _HeaderElement = value
            End Set
        End Property

        ''' <summary>
        ''' 現在解析中の選択肢の取得、設定を行います。
        ''' </summary>
        ''' <value>現在解析中の選択肢</value>
        ''' <returns>現在解析中の選択肢</returns>
        ''' <remarks></remarks>
        Public Property ParsingChoiceMark As String
            Get
                Return _ParsingChoiceMark
            End Get
            Set(value As String)
                _ParsingChoiceMark = value
            End Set
        End Property

        ''' <summary>
        ''' 選択肢と選択肢に関連するブロックデータのマップを取得します。
        ''' </summary>
        ''' <returns>選択肢と選択肢に関連するブロックデータのマップ</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ChoiceBlockMap As SortedList(Of String, List(Of mshtml.IHTMLElement))
            Get
                Return _ChoiceBlockMap
            End Get
        End Property

        ''' <summary>
        ''' テーブルかどうかを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns>テーブルかどうか</returns>
        ''' <remarks></remarks>
        Public Property IsTable As Boolean
            Get
                Return _IsTable
            End Get
            Set(value As Boolean)
                _IsTable = value
            End Set
        End Property
#End Region

#Region "----- メソッド -----"
        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="bodyElement">Top エレメント</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal bodyElement As mshtml.IHTMLElement)
            _BodyElement = bodyElement
        End Sub

        ''' <summary>
        ''' ソート時に使用されるソート対象の親ノードを追加します。
        ''' </summary>
        ''' <param name="parentNode">ソート時に使用されるソート対象の親ノード</param>
        ''' <remarks></remarks>
        Public Sub AddParentElement(ByVal parentNode As mshtml.IHTMLElement)
            _ParentNodes.Add(parentNode)
        End Sub

        ''' <summary>
        ''' 現在解析中の選択肢に関連付く、エレメントを追加します。
        ''' </summary>
        ''' <param name="choiceRelatedData">追加するエレメント</param>
        ''' <remarks></remarks>
        Public Sub AddBlockDataOfParsingChoiceMark(ByVal choiceRelatedData As mshtml.IHTMLElement)
            If _ChoiceBlockMap.ContainsKey(_ParsingChoiceMark) = False Then
                _ChoiceBlockMap.Add(_ParsingChoiceMark, New List(Of mshtml.IHTMLElement))
            End If
            _ChoiceBlockMap(_ParsingChoiceMark).Add(choiceRelatedData)
        End Sub

        ''' <summary>
        ''' 現在のデータをソートします。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Sort()
            If _IsTable Then
                'テーブル時のソート(元々はその他のソートと同様の処理でソートを行っていたが、
                '罫線のソートの都合上テーブルのソートは中身の文字列のみソートを行うように変更)
                For Each parentNode As mshtml.IHTMLDOMNode In ParentNodes
                    SortTable(parentNode)
                Next
            Else
                'ソートしたオブジェクトに変更する。
                For Each parentNode As mshtml.IHTMLDOMNode In ParentNodes

                    '既存のオブジェクトの削除
                    For Each removeNode In parentNode.children
                        parentNode.removeChild(removeNode)
                    Next

                    'ヘッダは最初に追加
                    If _HeaderElement Is Nothing = False Then
                        parentNode.appendChild(_HeaderElement)
                    End If

                    'ソートされたブロック毎にデータを追加
                    For Each sortedElementList As List(Of mshtml.IHTMLElement) In ChoiceBlockMap.Values
                        For Each sortedElement As mshtml.IHTMLElement In sortedElementList
                            parentNode.appendChild(sortedElement)
                        Next
                    Next
                Next
            End If
        End Sub

        ''' <summary>
        ''' テーブルのソートを行います。
        ''' </summary>
        ''' <param name="parentNode">ソートを行う親ノード</param>
        ''' <remarks></remarks>
        Private Sub SortTable(ByRef parentNode As mshtml.IHTMLDOMNode)

            Dim choiceCount As Integer = 0
            Dim trCount As Integer = 0
            Dim isHeaderLine As Boolean = True

            For Each tBodyNode As mshtml.IHTMLDOMNode In parentNode.children 'TRループ
                Dim trElement As mshtml.IHTMLElement = CastElementOfSafety(tBodyNode, "TR")
                Dim sortedElementList As List(Of mshtml.IHTMLElement) = ChoiceBlockMap.Values(choiceCount)

                If trElement Is Nothing = False Then
                    '表の一行
                    If isHeaderLine Then
                        '1行目(ヘッダ行はなにもしない)
                        isHeaderLine = False
                    Else
                        '2行目以降
                        'TR の内部データのみ変更する
                        copyTrElement(trElement, sortedElementList(trCount))
                        If trCount = sortedElementList.Count - 1 Then
                            trCount = 0
                            choiceCount += 1
                        Else
                            trCount += 1
                        End If
                    End If
                End If
            Next
        End Sub

        ''' <summary>
        ''' 指定の行エレメントの内容物だけをコピーします。
        ''' </summary>
        ''' <param name="trElement">コピーされる行オブジェクト</param>
        ''' <param name="sortedTrElement">コピーする内容を持つソートされた行オブジェクト</param>
        ''' <remarks></remarks>
        Private Sub copyTrElement(ByRef trElement As mshtml.IHTMLElement, ByVal sortedTrElement As mshtml.IHTMLElement)
            Dim tdCount As Integer = 0
            For Each trNode As mshtml.IHTMLDOMNode In trElement.children
                Dim tdElement As mshtml.IHTMLElement = CastElementOfSafety(trNode, "TD")
                Dim sortedTdElement As mshtml.IHTMLElement = sortedTrElement.children(tdCount)
                If tdElement Is Nothing = False AndAlso sortedTdElement Is Nothing = False Then
                    tdElement.innerHTML = sortedTdElement.innerHTML
                End If
                tdCount += 1
            Next
        End Sub
#End Region
    End Class
#End Region

End Class
