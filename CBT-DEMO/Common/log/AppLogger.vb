Imports log4net
Imports log4net.Appender
Imports log4net.Config

''' ---------------------------------------------------------------------
''' <summary>
''' log4netラッパークラス
''' </summary>
''' <remarks>
''' log4netを利用して、ログトレース機能を提供する
''' </remarks>
''' ---------------------------------------------------------------------
<AppLoggerSkip()> _
Public Class AppLogger
#Region "----- メンバ変数 -----"
    ''' <summary>log4net</summary>
    Private logger As log4net.ILog
    ''' <summary>自分自身のインスタンス</summary>
    Private Shared appLog As AppLogger = Nothing
#End Region

#Region "----- コンストラクタ -----"
    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' パラメータを使用して、log4net.LogManager.GetLoogerメソッドの呼び出しを行うコンストラクタ
    ''' </summary>
    ''' <param name="obj">呼び出し元クラスのインスタンス</param>
    ''' <remarks>
    ''' 1.デフォルトコンストラクタの呼び出しを行う
    ''' 2.パラメータを引数にlog4net.LogManager.GetLoggerメソッドの呼び出しを行う
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub New(ByVal obj As Object)
        SettingLogCofig()
        logger = log4net.LogManager.GetLogger(obj.GetType)
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' パラメータを使用して、log4net.LogManager.GetLoogerメソッドの呼び出しを行うコンストラクタ
    ''' </summary>
    ''' <param name="obj">呼び出し元クラスのインスタンス</param>
    ''' <remarks>
    ''' 1.デフォルトコンストラクタの呼び出しを行う
    ''' 2.パラメータを引数にlog4net.LogManager.GetLoggerメソッドの呼び出しを行う
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub New(ByVal obj As Object, ByVal configPath As String)
        SettingLogCofig(configPath)
        logger = log4net.LogManager.GetLogger(obj.GetType)
    End Sub
    Public Sub New()
        SettingLogCofig()
    End Sub
#End Region

#Region "----- メソッド -----"
    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' AppLoggerクラスのインスタンス化を行い、生成したインスタンスを返す
    ''' </summary>
    ''' <param name="obj">呼び出し元クラスのインスタンス</param>
    ''' <returns>AppLoggerのインスタンス</returns>
    ''' <remarks>
    ''' 1.パラメータを引数にAppLoggerのコンストラクタを呼び出す
    ''' 2.AppLoggerのインスタンスを呼び出し元に返す
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Shared Function GetAppLogger(ByVal obj As Object) As AppLogger
        appLog = New AppLogger(obj)
        Return appLog
    End Function

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' AppLoggerクラスのインスタンス化を行い、生成したインスタンスを返す
    ''' </summary>
    ''' <param name="obj">呼び出し元クラスのインスタンス</param>
    ''' <returns>AppLoggerのインスタンス</returns>
    ''' <remarks>
    ''' 1.パラメータを引数にAppLoggerのコンストラクタを呼び出す
    ''' 2.AppLoggerのインスタンスを呼び出し元に返す
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Shared Function GetAppLogger(ByVal obj As Object, ByVal configPath As String) As AppLogger
        appLog = New AppLogger(obj, configPath)
        Return appLog
    End Function
    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' AppLoggerクラスのインスタンス化を行い、生成したインスタンスを返す
    ''' </summary>
    ''' <returns>AppLoggerのインスタンス</returns>
    ''' <remarks>
    ''' 1.パラメータを引数にAppLoggerのコンストラクタを呼び出す
    ''' 2.AppLoggerのインスタンスを呼び出し元に返す
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Shared Function GetAppLogger() As AppLogger
        appLog = New AppLogger()
        Return appLog
    End Function
    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' メソッド開始のログを出力する
    ''' </summary>
    ''' <remarks>
    ''' 1.呼び出し元のメソッド名を取得する
    ''' 2.log4netのログレベルlnfoにて、下記のログを出力する
    ''' 「メソッド開始：呼び出し元メソッド名」
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub Start()
        logger.Info("Start:" + GetMethodName())
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' メソッド終了のログを出力する
    ''' </summary>
    ''' <remarks>
    ''' 1.呼び出し元のメソッド名を取得する
    ''' 2.log4netのログレベルlnfoにて、下記のログを出力する
    ''' 「メソッド終了：呼び出し元メソッド名」
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub [End]()
        logger.Info("End:" + GetMethodName())
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' ログレベルDebugのログを出力する
    ''' </summary>
    ''' <remarks>
    ''' <param name="obj">ログ出力対象のオブジェクト</param>
    ''' 1.log4netのログレベルDebugにて、パラメータのデータを出力する
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub Debug(ByVal obj As Object)
        logger.Debug(obj)
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' ログレベルInfoのログを出力する
    ''' </summary>
    ''' <remarks>
    ''' <param name="obj">ログ出力対象のオブジェクト</param>
    ''' 1.log4netのログレベルInfoにて、パラメータのデータを出力する
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub Info(ByVal obj As Object)
        logger.Info(obj)
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' ログレベルErrorのログを出力する
    ''' </summary>
    ''' <remarks>
    ''' <param name="obj">ログ出力対象のオブジェクト</param>
    ''' 1.log4netのログレベルErrorにて、パラメータのデータを出力する
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Sub [Error](ByVal obj As Object)
        logger.Error(obj)
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' コンフィグファイルよりlog4netコンフィグファイルパスを取得し、設定する
    ''' </summary>
    ''' <remarks>
    ''' 1.コンフィグファイルより”log4net.config”をキーに&lt;appSetting&gt;の値を取得する
    ''' 2.&lt;appSetting&gt;の値が取得できた場合
    ''' 2.1.log4netのコンフィグファイルとして1で取得した値を設定する
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Shared Sub SettingLogCofig()
        log4net.Config.XmlConfigurator.Configure(New System.IO.FileInfo("log4net.config"))
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' コンフィグファイルよりlog4netコンフィグファイルパスを取得し、設定する
    ''' </summary>
    ''' <remarks>
    ''' 1.コンフィグファイルより”log4net.config”をキーに&lt;appSetting&gt;の値を取得する
    ''' 2.&lt;appSetting&gt;の値が取得できた場合
    ''' 2.1.log4netのコンフィグファイルとして1で取得した値を設定する
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Public Shared Sub SettingLogCofig(ByVal webConfig As String)
        log4net.Config.XmlConfigurator.Configure(New System.IO.FileInfo(webConfig & "log4net.config"))
    End Sub

    ''' ---------------------------------------------------------------------
    ''' <summary>
    ''' スタックトレースより呼び出し元のメソッド名を取得し、メソッド名を返す
    ''' </summary>
    ''' <returns>メソッド名</returns>
    ''' <remarks>
    ''' スタックトレースクラスから呼び出し元（1つ前のクラス）を取得し、メソッド名を返す
    ''' </remarks>
    ''' ---------------------------------------------------------------------
    Private Function GetMethodName() As String
        Dim st As New StackTrace(False)
        Dim i As Integer = 0
        Dim stackF As StackFrame = Nothing
        For i = 0 To st.FrameCount - 1
            stackF = st.GetFrame(i)
            'カスタム属性が定義されている場合は、スキップする
            If stackF.GetMethod.GetCustomAttributes(GetType(AppLoggerSkipAttribute), True).Length = 0 _
                And stackF.GetMethod.DeclaringType.GetCustomAttributes(GetType(AppLoggerSkipAttribute), True).Length = 0 Then
                Exit For
            End If
        Next

        'カスタム属性を定義しない場合は、以下のようになる
        '呼び出し元のフレームを取得する
        'st.GetFrame(0)でフレームを取得し、sf.GetMethod.Nameを取得すると、
        'st.GetFrame(1)でフレームを取得し、sf.GetMethod.Nameを取得すると、
        'st.GetFrame(2)でフレームを取得し、sf.GetMethod.Nameを取得すると、
        'つまり、ラッパークラスのメソッドを呼んでいるメソッド名
        'Dim sf As StackFrame = st.GetFrame(2)

        Return stackF.GetMethod.Name
    End Function
#End Region
End Class
