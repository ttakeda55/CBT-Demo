''' ---------------------------------------------------------------------
''' <summary>
''' ログ出力したくないクラスにつけるカスタム属性
''' </summary>
''' <remarks>
''' ログ出力したくないクラスにつけるこの属性をつける
''' </remarks>
''' ---------------------------------------------------------------------
<AttributeUsage(AttributeTargets.All)> _
Public Class AppLoggerSkipAttribute
    Inherits Attribute

    Public Sub New()

    End Sub
End Class