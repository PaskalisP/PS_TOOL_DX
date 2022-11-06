Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraSplashScreen
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins


Public Class PSTOOL_SplashScreen1
    Inherits SplashScreen
    Dim TimerTextEdit As New DevExpress.XtraEditors.TextEdit



    Sub New()
        InitSkins()
        InitializeComponent()
    End Sub

    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("Sharp Plus")

    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        If CType(cmd, SplashScreenCommand) = SplashScreenCommand.SetCaption Then
            Me.labelControl2.Text = arg.ToString()
        End If
        MyBase.ProcessCommand(cmd, arg)

    End Sub

    Public Enum SplashScreenCommand
        SetCaption
    End Enum


    Private Sub PSTOOL_SplashScreen1_Load(sender As Object, e As EventArgs) Handles Me.Load
      
        If My.Application.Info.Title <> "" Then
            ApplicationName_lbl.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationName_lbl.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.VersionInfo_lbl.Text = System.String.Format(VersionInfo_lbl.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Me.Copyright_lbl.Text = My.Application.Info.Copyright

       


    End Sub

  
End Class
