﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.261
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'このソース コードは Microsoft.VSDesigner、バージョン 4.0.30319.261 によって自動生成されました。
'
Namespace SystemManagerWebService
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="SystemManagerSoap", [Namespace]:="http://localhost/")>  _
    Partial Public Class SystemManager
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private InitializeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FileDownLoad_DATAOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FileDownLoad_SYTEMDATAOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FileUpLoad_DATAOperationCompleted As System.Threading.SendOrPostCallback
        
        Private FileDelete_DATAOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetFileListOperationCompleted As System.Threading.SendOrPostCallback
        
        Private UpLoadLogFileOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetServerDateTimeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.CST.CBT.eIPSTA.SystemManager.My.MySettings.Default.SystemManager_SystemManagerWebService_SystemManager
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event InitializeCompleted As InitializeCompletedEventHandler
        
        '''<remarks/>
        Public Event FileDownLoad_DATACompleted As FileDownLoad_DATACompletedEventHandler
        
        '''<remarks/>
        Public Event FileDownLoad_SYTEMDATACompleted As FileDownLoad_SYTEMDATACompletedEventHandler
        
        '''<remarks/>
        Public Event FileUpLoad_DATACompleted As FileUpLoad_DATACompletedEventHandler
        
        '''<remarks/>
        Public Event FileDelete_DATACompleted As FileDelete_DATACompletedEventHandler
        
        '''<remarks/>
        Public Event GetFileListCompleted As GetFileListCompletedEventHandler
        
        '''<remarks/>
        Public Event UpLoadLogFileCompleted As UpLoadLogFileCompletedEventHandler
        
        '''<remarks/>
        Public Event GetServerDateTimeCompleted As GetServerDateTimeCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/Initialize", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Initialize() As Boolean
            Dim results() As Object = Me.Invoke("Initialize", New Object(-1) {})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub InitializeAsync()
            Me.InitializeAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub InitializeAsync(ByVal userState As Object)
            If (Me.InitializeOperationCompleted Is Nothing) Then
                Me.InitializeOperationCompleted = AddressOf Me.OnInitializeOperationCompleted
            End If
            Me.InvokeAsync("Initialize", New Object(-1) {}, Me.InitializeOperationCompleted, userState)
        End Sub
        
        Private Sub OnInitializeOperationCompleted(ByVal arg As Object)
            If (Not (Me.InitializeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent InitializeCompleted(Me, New InitializeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/FileDownLoad_DATA", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FileDownLoad_DATA(ByVal fileName As String, <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> ByRef contents() As Byte) As Boolean
            Dim results() As Object = Me.Invoke("FileDownLoad_DATA", New Object() {fileName, contents})
            contents = CType(results(1),Byte())
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FileDownLoad_DATAAsync(ByVal fileName As String, ByVal contents() As Byte)
            Me.FileDownLoad_DATAAsync(fileName, contents, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FileDownLoad_DATAAsync(ByVal fileName As String, ByVal contents() As Byte, ByVal userState As Object)
            If (Me.FileDownLoad_DATAOperationCompleted Is Nothing) Then
                Me.FileDownLoad_DATAOperationCompleted = AddressOf Me.OnFileDownLoad_DATAOperationCompleted
            End If
            Me.InvokeAsync("FileDownLoad_DATA", New Object() {fileName, contents}, Me.FileDownLoad_DATAOperationCompleted, userState)
        End Sub
        
        Private Sub OnFileDownLoad_DATAOperationCompleted(ByVal arg As Object)
            If (Not (Me.FileDownLoad_DATACompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FileDownLoad_DATACompleted(Me, New FileDownLoad_DATACompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/FileDownLoad_SYTEMDATA", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FileDownLoad_SYTEMDATA(ByVal fileName As String, <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> ByRef contents() As Byte) As Boolean
            Dim results() As Object = Me.Invoke("FileDownLoad_SYTEMDATA", New Object() {fileName, contents})
            contents = CType(results(1),Byte())
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FileDownLoad_SYTEMDATAAsync(ByVal fileName As String, ByVal contents() As Byte)
            Me.FileDownLoad_SYTEMDATAAsync(fileName, contents, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FileDownLoad_SYTEMDATAAsync(ByVal fileName As String, ByVal contents() As Byte, ByVal userState As Object)
            If (Me.FileDownLoad_SYTEMDATAOperationCompleted Is Nothing) Then
                Me.FileDownLoad_SYTEMDATAOperationCompleted = AddressOf Me.OnFileDownLoad_SYTEMDATAOperationCompleted
            End If
            Me.InvokeAsync("FileDownLoad_SYTEMDATA", New Object() {fileName, contents}, Me.FileDownLoad_SYTEMDATAOperationCompleted, userState)
        End Sub
        
        Private Sub OnFileDownLoad_SYTEMDATAOperationCompleted(ByVal arg As Object)
            If (Not (Me.FileDownLoad_SYTEMDATACompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FileDownLoad_SYTEMDATACompleted(Me, New FileDownLoad_SYTEMDATACompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/FileUpLoad_DATA", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FileUpLoad_DATA(ByVal fileName As String, <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> ByVal contents() As Byte) As Boolean
            Dim results() As Object = Me.Invoke("FileUpLoad_DATA", New Object() {fileName, contents})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FileUpLoad_DATAAsync(ByVal fileName As String, ByVal contents() As Byte)
            Me.FileUpLoad_DATAAsync(fileName, contents, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FileUpLoad_DATAAsync(ByVal fileName As String, ByVal contents() As Byte, ByVal userState As Object)
            If (Me.FileUpLoad_DATAOperationCompleted Is Nothing) Then
                Me.FileUpLoad_DATAOperationCompleted = AddressOf Me.OnFileUpLoad_DATAOperationCompleted
            End If
            Me.InvokeAsync("FileUpLoad_DATA", New Object() {fileName, contents}, Me.FileUpLoad_DATAOperationCompleted, userState)
        End Sub
        
        Private Sub OnFileUpLoad_DATAOperationCompleted(ByVal arg As Object)
            If (Not (Me.FileUpLoad_DATACompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FileUpLoad_DATACompleted(Me, New FileUpLoad_DATACompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/FileDelete_DATA", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function FileDelete_DATA(ByVal fileName As String) As Boolean
            Dim results() As Object = Me.Invoke("FileDelete_DATA", New Object() {fileName})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub FileDelete_DATAAsync(ByVal fileName As String)
            Me.FileDelete_DATAAsync(fileName, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub FileDelete_DATAAsync(ByVal fileName As String, ByVal userState As Object)
            If (Me.FileDelete_DATAOperationCompleted Is Nothing) Then
                Me.FileDelete_DATAOperationCompleted = AddressOf Me.OnFileDelete_DATAOperationCompleted
            End If
            Me.InvokeAsync("FileDelete_DATA", New Object() {fileName}, Me.FileDelete_DATAOperationCompleted, userState)
        End Sub
        
        Private Sub OnFileDelete_DATAOperationCompleted(ByVal arg As Object)
            If (Not (Me.FileDelete_DATACompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent FileDelete_DATACompleted(Me, New FileDelete_DATACompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/GetFileList", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetFileList(ByRef dtFileList As System.Data.DataTable) As Boolean
            Dim results() As Object = Me.Invoke("GetFileList", New Object() {dtFileList})
            dtFileList = CType(results(1),System.Data.DataTable)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetFileListAsync(ByVal dtFileList As System.Data.DataTable)
            Me.GetFileListAsync(dtFileList, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetFileListAsync(ByVal dtFileList As System.Data.DataTable, ByVal userState As Object)
            If (Me.GetFileListOperationCompleted Is Nothing) Then
                Me.GetFileListOperationCompleted = AddressOf Me.OnGetFileListOperationCompleted
            End If
            Me.InvokeAsync("GetFileList", New Object() {dtFileList}, Me.GetFileListOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetFileListOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetFileListCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetFileListCompleted(Me, New GetFileListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/UpLoadLogFile", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function UpLoadLogFile(ByVal fileName As String, <System.Xml.Serialization.XmlElementAttribute(DataType:="base64Binary")> ByVal contents() As Byte) As Boolean
            Dim results() As Object = Me.Invoke("UpLoadLogFile", New Object() {fileName, contents})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub UpLoadLogFileAsync(ByVal fileName As String, ByVal contents() As Byte)
            Me.UpLoadLogFileAsync(fileName, contents, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub UpLoadLogFileAsync(ByVal fileName As String, ByVal contents() As Byte, ByVal userState As Object)
            If (Me.UpLoadLogFileOperationCompleted Is Nothing) Then
                Me.UpLoadLogFileOperationCompleted = AddressOf Me.OnUpLoadLogFileOperationCompleted
            End If
            Me.InvokeAsync("UpLoadLogFile", New Object() {fileName, contents}, Me.UpLoadLogFileOperationCompleted, userState)
        End Sub
        
        Private Sub OnUpLoadLogFileOperationCompleted(ByVal arg As Object)
            If (Not (Me.UpLoadLogFileCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent UpLoadLogFileCompleted(Me, New UpLoadLogFileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/GetServerDateTime", RequestNamespace:="http://localhost/", ResponseNamespace:="http://localhost/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetServerDateTime(ByRef datetime As Date) As Boolean
            Dim results() As Object = Me.Invoke("GetServerDateTime", New Object() {datetime})
            datetime = CType(results(1),Date)
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetServerDateTimeAsync(ByVal datetime As Date)
            Me.GetServerDateTimeAsync(datetime, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetServerDateTimeAsync(ByVal datetime As Date, ByVal userState As Object)
            If (Me.GetServerDateTimeOperationCompleted Is Nothing) Then
                Me.GetServerDateTimeOperationCompleted = AddressOf Me.OnGetServerDateTimeOperationCompleted
            End If
            Me.InvokeAsync("GetServerDateTime", New Object() {datetime}, Me.GetServerDateTimeOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetServerDateTimeOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetServerDateTimeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetServerDateTimeCompleted(Me, New GetServerDateTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub InitializeCompletedEventHandler(ByVal sender As Object, ByVal e As InitializeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class InitializeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub FileDownLoad_DATACompletedEventHandler(ByVal sender As Object, ByVal e As FileDownLoad_DATACompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FileDownLoad_DATACompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property contents() As Byte()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),Byte())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub FileDownLoad_SYTEMDATACompletedEventHandler(ByVal sender As Object, ByVal e As FileDownLoad_SYTEMDATACompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FileDownLoad_SYTEMDATACompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property contents() As Byte()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),Byte())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub FileUpLoad_DATACompletedEventHandler(ByVal sender As Object, ByVal e As FileUpLoad_DATACompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FileUpLoad_DATACompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property



    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub FileDelete_DATACompletedEventHandler(ByVal sender As Object, ByVal e As FileDelete_DATACompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class FileDelete_DATACompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property



    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub GetFileListCompletedEventHandler(ByVal sender As Object, ByVal e As GetFileListCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetFileListCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property dtFileList() As System.Data.DataTable
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),System.Data.DataTable)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub UpLoadLogFileCompletedEventHandler(ByVal sender As Object, ByVal e As UpLoadLogFileCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class UpLoadLogFileCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")>  _
    Public Delegate Sub GetServerDateTimeCompletedEventHandler(ByVal sender As Object, ByVal e As GetServerDateTimeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetServerDateTimeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property datetime() As Date
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),Date)
            End Get
        End Property
    End Class
End Namespace
