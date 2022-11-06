Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class UpperCaseUTF8Encoding
    Inherits UTF8Encoding
   
    Public Overrides ReadOnly Property WebName() As String
        Get
            Return MyBase.WebName.ToUpper()
        End Get
    End Property

    Public Shared ReadOnly Property UpperCaseUTF8() As UpperCaseUTF8Encoding
        Get
            If upperCaseUtf8Encoding Is Nothing Then
                upperCaseUtf8Encoding = New UpperCaseUTF8Encoding()
            End If
            Return upperCaseUtf8Encoding
        End Get
    End Property

    Private Shared upperCaseUtf8Encoding As UpperCaseUTF8Encoding = Nothing
End Class
