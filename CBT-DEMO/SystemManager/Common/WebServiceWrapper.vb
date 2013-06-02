Imports CST.CBT.eIPSTA.SystemManager
Imports System.Security.Cryptography.X509Certificates
Imports System.Net
Imports System.Net.Security

Public Class WebServiceWrapper

#Region "----- メンバ変数 -----"
    ''' <summary>url</summary>
    Private _url As String
    ''' <summary>WEBサービスのインスタンス</summary>
    Private Shared _instance As New SystemManagerWebService.SystemManager
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
    Public Shared Function GetInstance() As SystemManagerWebService.SystemManager
        Return _instance
    End Function

    ''' <summary>
    ''' 初期処理でURLを設定する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Initialize()
        ServicePointManager.ServerCertificateValidationCallback = _
            New RemoteCertificateValidationCallback( _
            AddressOf OnRemoteCertificateValidationCallback)

#If DEBUG Then
        _instance.Url = Global.CST.CBT.eIPSTA.SystemManager.My.MySettings.Default.SystemManager_SystemManagerWebService_SystemManager
#Else
        _instance.Url = System.Configuration.ConfigurationManager.AppSettings("https")
#End If
        _instance.InitializeAsync()

    End Sub

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
