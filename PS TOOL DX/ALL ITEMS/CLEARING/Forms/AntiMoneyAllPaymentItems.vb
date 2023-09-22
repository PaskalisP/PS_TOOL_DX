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
Public Class AntiMoneyAllPaymentItems


    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private objDataTable As New DataTable


    Dim Frd As Date
    Dim Frdsql As String = Nothing
    Dim Trd As Date
    Dim Trdsql As String = Nothing
    Dim cd As Date
    Dim cdsql As String = Nothing

    Dim CheckField1 As String = Nothing
    Dim CheckField2 As String = Nothing

    Dim SumIncoming As Double = 0
    Dim SumSEPADD As Double = 0
    Dim SumOutgoing As Double = 0
    

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Friend WithEvents BgwLoadCustomerPayments As BackgroundWorker

    Private bgws As New List(Of BackgroundWorker)()

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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    Private Sub DISABLE_BUTTONS()
        Me.DateFrom_BarEditItem.Enabled = False
        Me.DateTill_BarEditItem.Enabled = False
        Me.bbi_Load.Enabled = False
    End Sub

    Private Sub ENABLE_BUTTONS()
        Me.DateFrom_BarEditItem.Enabled = True
        Me.DateTill_BarEditItem.Enabled = True
        Me.bbi_Load.Enabled = True
    End Sub

    Private Sub AntiMoneyAllPaymentItems_Load(sender As Object, e As EventArgs) Handles Me.Load

        cmd.CommandText = "Select DPARAMETER1 from PARAMETER where PARAMETER1 in ('GMPS_PAYMENTS_OUT') and IdABTEILUNGSPARAMETER in ('MAX_DATES') and IdABTEILUNGSCODE_NAME in ('CLEARING')"
        OpenSqlConnections()
        Dim d As Date = cmd.ExecuteScalar
        CloseSqlConnections()

        Me.DateFrom_BarEditItem.EditValue = d
        Me.DateTill_BarEditItem.EditValue = d

    End Sub

    Private Sub bbi_Load_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Load.ItemClick
        If Me.DateFrom_BarEditItem.EditValue.ToString <> "" And Me.DateTill_BarEditItem.EditValue.ToString <> "" Then
            Frd = Me.DateFrom_BarEditItem.EditValue
            Frdsql = Frd.ToString("yyyyMMdd")
            Trd = Me.DateTill_BarEditItem.EditValue
            Trdsql = Trd.ToString("yyyyMMdd")
            If Frd <= Trd Then
                DISABLE_BUTTONS()
                Me.LayoutControlItem5.Visibility = LayoutVisibility.Always
                BgwLoadCustomerPayments = New BackgroundWorker
                bgws.Add(BgwLoadCustomerPayments)
                BgwLoadCustomerPayments.WorkerReportsProgress = True
                BgwLoadCustomerPayments.RunWorkerAsync()
            Else
                XtraMessageBox.Show("From Date must be less or equal Till Date", "Wrong Dates input", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

            End If

        End If
    End Sub


    Private Sub BgwLoadCustomerPayments_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadCustomerPayments.DoWork
        Try

            Me.BgwLoadCustomerPayments.ReportProgress(10, "Load all Customer Payments - (SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/CUSTOMER_PAYMENTS_Temp_Fill) from: " & Frd & " till " & Trd)

            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('CUSTOMER_PAYMENTS_Temp_Fill') and Status in ('Y')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", Frdsql).Replace("<TillDate>", Trdsql)
                'Data reader
                Using Sqlconn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                    Using Sqlcmd As New SqlCommand()
                        Sqlcmd.CommandText = SqlCommandText
                        Sqlcmd.Connection = Sqlconn
                        'Sqlcmd.CommandTimeout = 5000
                        Sqlconn.Open()

                        daSqlQueries = New SqlDataAdapter(SqlCommandText, Sqlconn)
                        daSqlQueries.SelectCommand.CommandTimeout = 50000
                        dtSqlQueries = New DataTable()
                        daSqlQueries.Fill(dtSqlQueries)

                        'Dim objDataReader As SqlDataReader = Sqlcmd.ExecuteReader()
                        'objDataTable.Clear()
                        'objDataTable.Load(objDataReader)

                        Sqlconn.Close()

                    End Using
                End Using

            Else
                MessageBox.Show("The SQL Command:SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/CUSTOMER_PAYMENTS_Temp_Fill is either deactivated or not present!", "NO SQL COMMAND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub

        Finally
            BgwLoadCustomerPayments.CancelAsync()

        End Try
    End Sub


    Private Sub BgwLoadCustomerPayments_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadCustomerPayments.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
    End Sub

    Private Sub BgwLoadCustomerPayments_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadCustomerPayments.RunWorkerCompleted
        Workers_Complete(BgwLoadCustomerPayments, e)
        ENABLE_BUTTONS()
        Me.LayoutControlItem5.Visibility = LayoutVisibility.Never

        'Results Datareader
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            'Me.GridControl4.BeginUpdate()
            Me.GridControl4.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl4.DataSource = dtSqlQueries
            Me.GridControl4.ForceInitialize()
            'Me.LCR_Details_GridView.PopulateColumns()
            'Me.LCR_Details_GridView.BestFitColumns()
            'Me.GridControl4.RefreshDataSource()
            Me.LayoutControlGroup2.Text = "Customer Payments  from: " & Frd & " till " & Trd
        Else
            XtraMessageBox.Show("There are no Data for the specified Pariod", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub bbi_PrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_PrintExport.ItemClick
        If Not GridControl4.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
        Dim reportfooter As String = "Customer Payments" & "  " & "from: " & Frd & " till " & Trd
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub

    Private Sub AntiMoneyAllPaymentItems_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False

        End If
    End Sub
End Class