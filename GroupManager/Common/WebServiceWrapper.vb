Imports CST.CBT.eIPSTA.GroupManager
Imports System.Security.Cryptography.X509Certificates
Imports System.Net
Imports System.Net.Security
Public Class WebServiceWrapper

#Region "----- メンバ変数 -----"
    ''' <summary>url</summary>
    Private Shared _url As String
    ''' <summary>WEBサービスのインスタンス</summary>
    Private Shared _instance As New GroupManagerWebService.GroupManager
#End Region

#Region "----- コンストラクタ -----"
    Private Sub New()
    End Sub
#End Region

#Region "----- メソッド -----"
    ''' <summary>
    ''' WEBサービスのインスタンスを取得する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As GroupManagerWebService.GroupManager
        Return _instance
    End Function

    ''' <summary>
    ''' SSL認証を常に問題なしとする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="certificate"></param>
    ''' <param name="chain"></param>
    ''' <param name="sslPolicyErrors"></param>
    ''' <returns>
    ''' ローカルPCのシステム日付が狂っている場合、
    ''' HTTPS通信のSSL認証の有効期限チェックでエラーが発生するので、
    ''' SSL認証は常に問題なしとする。
    ''' </returns>
    ''' <remarks></remarks>
    Private Shared Function OnRemoteCertificateValidationCallback( _
      ByVal sender As Object, _
      ByVal certificate As X509Certificate, _
      ByVal chain As X509Chain, _
      ByVal sslPolicyErrors As Net.Security.SslPolicyErrors _
    ) As Boolean

        Return True  ' 「SSL証明書の使用は問題なし」と示す

    End Function
#End Region
End Class
