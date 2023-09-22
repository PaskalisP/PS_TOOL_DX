﻿Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Public Class SEPA_DIRECTORY


    Dim ActiveTabGroup As Double = 1


    Sub New()
        InitSkins()
        InitializeComponent()
        SkinManager.EnableMdiFormSkins()

    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(CurrentSkinName)
    End Sub



    Private Sub SEPA_DIRECTORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SEPA_DIRECTORY_FULLTableAdapter.Fill(Me.EXTERNALDataset.SEPA_DIRECTORY_FULL)

        'OpenSqlConnections()
        'cmd.CommandText = "SELECT DISTINCT [MessageID] from [SEPA DIRECTORY FULL]"
        'Me.SEPA_File_ID_BarEditItem.EditValue = cmd.ExecuteScalar
        'CloseSqlConnections()

        'Data reader
        Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
            Using Sqlcmd As New SqlCommand()
                Sqlcmd.CommandText = "SELECT DISTINCT [MessageID] from [SEPA DIRECTORY FULL]"
                Sqlcmd.Connection = Sqlconn
                Sqlcmd.CommandTimeout = 5000
                Sqlconn.Open()
                Me.SEPA_File_ID_BarEditItem.EditValue = Sqlcmd.ExecuteScalar
                Sqlconn.Close()
            End Using
        End Using


    End Sub

    Private Sub PrintExport_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintExport_bbi.ItemClick
        If Not GridControl3.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub


    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "SEPA DIRECTORY (FULL)" & " - " & "File ID: " & Me.SEPA_File_ID_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub
End Class