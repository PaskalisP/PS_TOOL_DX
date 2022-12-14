Imports System
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
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports System.Globalization
Imports DevExpress.Spreadsheet
Public Class MultibankKontenPersonen

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim SqlCommandText As String = Nothing

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Double = 0

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

    Private Sub MultibankKontenPersonen_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Try

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Multibank Konten und Personen")

            Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('Multibank_Konten_Personen') and Status in ('Y')"
            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)

                Me.QueryText = SqlCommandText
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    'Me.GridControl4.BeginUpdate()
                    Me.GridControl4.DataSource = Nothing
                    'Me.GridControl1.Refresh()
                    Me.GridControl4.DataSource = dt
                    Me.GridControl4.ForceInitialize()
                    'Me.LCR_Details_GridView.PopulateColumns()
                    'Me.LCR_Details_GridView.BestFitColumns()
                    'Me.GridControl4.RefreshDataSource()
                    SplashScreenManager.CloseForm(False)
                Else
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show("There are no Data from Multibank", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Load_LCR_Details_btn_Click(sender As Object, e As EventArgs) Handles Load_LCR_Details_btn.Click


        Try

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Multibank Konten und Personen")

            Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('Multibank_Konten_Personen') and Status in ('Y')"
            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    
                    Me.QueryText = SqlCommandText
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        'Me.GridControl4.BeginUpdate()
                        Me.GridControl4.DataSource = Nothing
                        'Me.GridControl1.Refresh()
                        Me.GridControl4.DataSource = dt
                        Me.GridControl4.ForceInitialize()
                        'Me.LCR_Details_GridView.PopulateColumns()
                        'Me.LCR_Details_GridView.BestFitColumns()
                        'Me.GridControl4.RefreshDataSource()
                        SplashScreenManager.CloseForm(False)
                    Else
                        SplashScreenManager.CloseForm(False)
                    MessageBox.Show("There are no Data from Multibank", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    End If
                End If

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try



    End Sub


    Private Sub AESS_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs)
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AESS_Details_GridView_ShownEditor(sender As Object, e As EventArgs)
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub AdvBandedGridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AdvBandedGridView1.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AdvBandedGridView1_ShownEditor(sender As Object, e As EventArgs) Handles AdvBandedGridView1.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Print_Export_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_Gridview_btn.Click
        If Not GridControl4.IsPrintingAvailable Then
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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "Multibank - Konten und Personen"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


End Class