Public Class Encrypt
  
    ''' <summary>
    ''' ファイルを暗号化する
    ''' </summary>
    ''' <param name="sourceFile">暗号化するファイルパス</param>
    ''' <param name="destFile">暗号化されたデータを保存するファイルパス</param>
    ''' <param name="password">暗号化に使用するパスワード</param>
    Public Shared Sub EncryptFile(ByVal sourceFile As String, _
                                  ByVal destFile As String, _
                                  ByVal password As String)
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte() = Nothing, iv As Byte() = Nothing
        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '以下、前のコードと同じ
        Dim outFs As New System.IO.FileStream( _
            destFile, System.IO.FileMode.Create, System.IO.FileAccess.Write)
        Dim encryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateEncryptor()
        Dim cryptStrm As New System.Security.Cryptography.CryptoStream( _
            outFs, encryptor, System.Security.Cryptography.CryptoStreamMode.Write)

        Dim inFs As New System.IO.FileStream( _
            sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim bs As Byte() = New Byte(1023) {}
        Dim readLen As Integer
        While True
            readLen = inFs.Read(bs, 0, bs.Length)
            If readLen = 0 Then
                Exit While
            End If
            cryptStrm.Write(bs, 0, readLen)
        End While

        inFs.Close()
        cryptStrm.Close()
        encryptor.Dispose()
        outFs.Close()
    End Sub

    ''' <summary>
    ''' ファイルを復号化する
    ''' </summary>
    ''' <param name="sourceFile">復号化するファイルパス</param>
    ''' <param name="destFile">復号化されたデータを保存するファイルパス</param>
    ''' <param name="password">暗号化に使用したパスワード</param>
    Public Shared Sub DecryptFile(ByVal sourceFile As String, _
                                  ByVal destFile As String, _
                                  ByVal password As String)
        Dim rijndael As New System.Security.Cryptography.RijndaelManaged()

        'パスワードから共有キーと初期化ベクタを作成
        Dim key As Byte() = Nothing, iv As Byte() = Nothing
        GenerateKeyFromPassword(password, rijndael.KeySize, key, rijndael.BlockSize, iv)
        rijndael.Key = key
        rijndael.IV = iv

        '以下、前のコードと同じ
        Dim inFs As New System.IO.FileStream( _
            sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim decryptor As System.Security.Cryptography.ICryptoTransform = _
            rijndael.CreateDecryptor()
        Dim cryptStrm As New System.Security.Cryptography.CryptoStream( _
            inFs, decryptor, System.Security.Cryptography.CryptoStreamMode.Read)

        Dim outFs As New System.IO.FileStream( _
            destFile, System.IO.FileMode.Create, System.IO.FileAccess.Write)
        Dim bs As Byte() = New Byte(1023) {}
        Dim readLen As Integer
        While True
            readLen = cryptStrm.Read(bs, 0, bs.Length)
            If readLen = 0 Then
                Exit While
            End If
            outFs.Write(bs, 0, readLen)
        End While

        outFs.Close()
        cryptStrm.Close()
        decryptor.Dispose()
        inFs.Close()
    End Sub

    ''' <summary>
    ''' パスワードから共有キーと初期化ベクタを生成する
    ''' </summary>
    ''' <param name="password">基になるパスワード</param>
    ''' <param name="keySize">共有キーのサイズ（ビット）</param>
    ''' <param name="key">作成された共有キー</param>
    ''' <param name="blockSize">初期化ベクタのサイズ（ビット）</param>
    ''' <param name="iv">作成された初期化ベクタ</param>
    Private Shared Sub GenerateKeyFromPassword(ByVal password As String, _
                                               ByVal keySize As Integer, _
                                               ByRef key As Byte(), _
                                               ByVal blockSize As Integer, _
                                               ByRef iv As Byte())
        'パスワードから共有キーと初期化ベクタを作成する
        'saltを決める
        Dim salt As Byte() = System.Text.Encoding.UTF8.GetBytes("saltは必ず8バイト以上")
        'Rfc2898DeriveBytesオブジェクトを作成する
        Dim deriveBytes As New System.Security.Cryptography.Rfc2898DeriveBytes( _
            password, salt)
        '反復処理回数を指定する デフォルトで1000回
        deriveBytes.IterationCount = 1000

        '共有キーと初期化ベクタを生成する
        key = deriveBytes.GetBytes(keySize \ 8)
        iv = deriveBytes.GetBytes(blockSize \ 8)
    End Sub

End Class
