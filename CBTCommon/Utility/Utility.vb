Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Windows.Forms

Public NotInheritable Class Utility

    Shared imgconv As New ImageConverter()

    Private Sub New()
    End Sub

    ''' <summary>
    ''' boolean型を0,1に変換します。
    ''' True:1
    ''' False:0
    ''' </summary>
    ''' <param name="bln"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CnvBlntoInt(ByVal bln As Boolean) As Integer
        If bln Then
            Return 1
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cmb">コンボボックス</param>
    ''' <param name="dt">datatable</param>
    ''' <param name="strDisplayMember">DisplayMember</param>
    ''' <param name="strValueMember">ValueMember</param>
    ''' <remarks></remarks>
    Public Shared Sub setCombobox(ByRef cmb As System.Windows.Forms.ComboBox, ByVal dt As DataTable, ByVal strDisplayMember As String, ByVal strValueMember As String)
        Dim dr As DataRow = dt.NewRow
        dt.Rows.InsertAt(dr, 0)
        cmb.DisplayMember = strDisplayMember
        cmb.ValueMember = strValueMember
        cmb.DataSource = dt
    End Sub

    ''' <summary>
    ''' htmlタグを全て削除します。
    ''' </summary>
    ''' <param name="strAsk"></param>
    ''' <remarks></remarks>
    Public Shared Function delTagAll(ByRef strAsk As String) As String
        '選択肢
        Dim str As String
        str = System.Text.RegularExpressions.Regex.Replace(strAsk, _
            "<[^>]*>", "", System.Text.RegularExpressions.RegexOptions.Singleline)
        Return str
    End Function

    ''' <summary>
    ''' バイト配列をにImageオブジェクト変換
    ''' </summary>
    ''' <param name="b"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ByteArrayToImage(ByVal b As Byte()) As Image
        Dim imgconv As New ImageConverter()
        Dim img As Image = CType(imgconv.ConvertFrom(b), Image)
        Return img
    End Function

    ''' <summary>
    ''' Imageオブジェクトをバイト配列に変換
    ''' </summary>
    ''' <param name="img"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ImageToByteArray(ByVal img As Image) As Byte()
        Dim b As Byte() = CType(imgconv.ConvertTo(img, GetType(Byte())), Byte())
        img.Dispose()
        Return b
    End Function

    ''' <summary>
    ''' バイト配列をbase64形式に変換
    ''' </summary>
    ''' <param name="b"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convBase64(ByVal b As Byte()) As String
        convBase64 = System.Convert.ToBase64String(b)
    End Function

    ''' <summary>
    ''' DBNullをブランクに変換
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NullToString(ByVal obj As Object) As String
        If obj Is DBNull.Value Then
            Return String.Empty
        Else
            Return obj
        End If
    End Function

    ''' <summary>
    ''' Nothingをブランクに変換
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NothingToString(ByVal obj As Object) As String
        If obj Is Nothing Then
            Return String.Empty
        Else
            Return obj
        End If
    End Function

    ''' <summary>
    ''' パスワードを生成する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GeneratePassword(ByVal length As Integer, ByVal passwordChars As String) As String
        Dim i As Integer

        Dim passWord = New StringBuilder
        For i = 0 To length - 1
            passWord.Append(passwordChars.Chars(RollDice(passwordChars.Length)))
        Next i

        Return passWord.ToString
    End Function

    ''' <summary>
    ''' ランダムな数字を生成する
    ''' </summary>
    ''' <param name="NumSides"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RollDice(ByVal NumSides As Integer) As Integer
        Dim randomNumber(0) As Byte
        Dim Gen As New Security.Cryptography.RNGCryptoServiceProvider()

        Gen.GetBytes(randomNumber)

        Dim rand As Integer = Convert.ToUInt32(randomNumber(0))

        Return rand Mod NumSides
    End Function

    ''' <summary>
    ''' ランダムな数字を生成する
    ''' </summary>
    ''' <param name="NumSides"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RollDiceLarge(ByVal NumSides As Integer) As Integer
        Dim randomNumber(3) As Byte
        Dim Gen As New Security.Cryptography.RNGCryptoServiceProvider()

        Gen.GetNonZeroBytes(randomNumber)

        Dim rand As Integer
        rand = System.BitConverter.ToInt32(randomNumber, 0)

        Return Math.Abs(rand Mod NumSides)
    End Function

    ''' <summary>
    ''' 整数チェック
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsInteger(ByVal str As String) As Boolean
        IsInteger = True
        Dim mc = System.Text.RegularExpressions.Regex.Match(str, "^[0-9]+$")
        'Doubleに変換できるか確かめる
        If mc.Value = String.Empty Then
            Return False
        End If
    End Function

    Shared sjisEnc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

    ''' <summary>
    ''' 全角チェック
    ''' </summary>
    Public Shared Function isZenkaku(ByVal str As String) As Boolean
        Dim num As Integer = sjisEnc.GetByteCount(str)
        Return num = str.Length * 2
    End Function

    ''' <summary>
    ''' 半角チェック
    ''' </summary>
    Public Shared Function isHankaku(ByVal str As String) As Boolean
        Dim num As Integer = sjisEnc.GetByteCount(str)
        Return num = str.Length
    End Function

    ''' <summary>
    ''' フォルダを根こそぎ削除する（ReadOnlyでも削除）
    ''' </summary>
    ''' <param name="dir">削除するフォルダ</param>
    Public Shared Sub DeleteDirectory(ByVal dir As String)
        If Directory.Exists(dir) Then
            'DirectoryInfoオブジェクトの作成
            Dim di As New DirectoryInfo(dir)

            'フォルダ以下のすべてのファイル、フォルダの属性を削除
            RemoveReadonlyAttribute(di)

            'フォルダを根こそぎ削除
            di.Delete(True)
        End If
    End Sub

    Public Shared Sub RemoveReadonlyAttribute( _
            ByVal dirInfo As DirectoryInfo)
        '基のフォルダの属性を変更
        If (dirInfo.Attributes And FileAttributes.ReadOnly) =
            FileAttributes.ReadOnly Then
            dirInfo.Attributes = FileAttributes.Normal
        End If
        'フォルダ内のすべてのファイルの属性を変更
        Dim fi As FileInfo
        For Each fi In dirInfo.GetFiles()
            If (fi.Attributes And FileAttributes.ReadOnly) =
                FileAttributes.ReadOnly Then
                fi.Attributes = FileAttributes.Normal
            End If
        Next fi
        'サブフォルダの属性を回帰的に変更
        Dim di As DirectoryInfo
        For Each di In dirInfo.GetDirectories()
            RemoveReadonlyAttribute(di)
        Next di
    End Sub

    ''' <summary>
    ''' html文字列からHtmlDocumentを取得します。
    ''' </summary>
    ''' <param name="html"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetHtmlDocument(ByVal html As String) As HtmlDocument
        Using web As New System.Windows.Forms.WebBrowser
            If web.Document = Nothing Then
                web.Navigate("about:blank") ' 空白ページを開く
            End If
            web.Document.OpenNew(True) ' クリア
            web.Document.Write(html)
            GetHtmlDocument = web.Document
            web.Dispose()
        End Using
    End Function

    ''' <summary>
    ''' 英数字チェック
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsHalfAlphaNum(ByVal str As String) As Boolean
        IsHalfAlphaNum = True
        Dim mc = System.Text.RegularExpressions.Regex.Match(str, "^[0-9a-zA-Z]+$")
        If mc.Value = String.Empty Then
            Return False
        End If
    End Function

    ''' <summary>
    ''' 禁止文字チェック
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsNgChar(ByVal str As String, ByVal NgChar As String) As Boolean
        IsNgChar = True
        Dim mc = System.Text.RegularExpressions.Regex.Match(str, "[" & NgChar & "]")
        If mc.Value = String.Empty Then
            Return False
        End If
    End Function

    ''' <summary>
    ''' 英大文字存在チェック
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsUpperCase(ByVal str As String) As Boolean
        IsUpperCase = True
        Dim mc = System.Text.RegularExpressions.Regex.Match(str, "[A-Z]")
        If mc.Value = String.Empty Then
            Return False
        End If
    End Function
End Class
