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
Imports DevExpress.XtraReports.Parameters

Public Class ExchangeRatesOCBS

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New DataTable

    Dim MaxDate As Date

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

    Private Sub EXCHANGE_RATES_OCBSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EXCHANGE_RATES_OCBSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub ExchangeRatesOCBS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        'Max Exchange Rate
        Me.QueryText = "Select Max([EXCHANGE RATE DATE]) as 'RiskDate' from [EXCHANGE RATES OCBS]"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            MaxDate = dt1.Rows.Item(0).Item("RiskDate")
            Me.FromDateEdit.EditValue = MaxDate
            Me.TillDateEdit.EditValue = MaxDate
        End If

        Me.EXCHANGE_RATES_OCBSTableAdapter.FillByLastExchangeDate(Me.PSTOOLDataset.EXCHANGE_RATES_OCBS)

    End Sub

    Private Sub LoadExchangeRatesOCBS_btn_Click(sender As Object, e As EventArgs) Handles LoadExchangeRatesOCBS_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True AndAlso IsDate(Me.TillDateEdit.Text) = True Then
            Dim d1 As Date = Me.FromDateEdit.Text
            Dim d2 As Date = Me.TillDateEdit.Text
            If d1 <= d2 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Exchange Rate (Core System) from: " & d1 & " till " & d2)
                Me.EXCHANGE_RATES_OCBSTableAdapter.FillByExchangeDates(Me.PSTOOLDataset.EXCHANGE_RATES_OCBS, d1, d2)
                SplashScreenManager.CloseForm(False)
            Else
                MessageBox.Show("Field:Date Till must be higher or equal to Field:Date From", "INVALID DATES", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ExchangeRates_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles ExchangeRates_Print_Export_btn.Click

        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
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
        Dim reportfooter As String = "OCBS EXCHANGE RATES" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ExchangeRatesOCBSreport_btn_Click(sender As Object, e As EventArgs) Handles ExchangeRatesOCBSreport_btn.Click
        ' Create a report instance.
        Dim report As New ExchangeRatesOCBSXtraReport


        ' Create a parameter and specify its name.
        Dim param1 As New Parameter()
        param1.Name = "ExchangeRateDate"

        ' Specify other parameter properties.
        param1.Type = GetType(System.DateTime)
        param1.Value = MaxDate
        param1.Description = "Exchange Rate Date: "
        param1.Visible = True

        ' Add the parameter to the report.
        report.Parameters.Add(param1)

        ' Specify the report's filter string.
        report.FilterString = "[EXCHANGE RATE DATE] = [Parameters.ExchangeRateDate]"

        ' Force the report creation without previously 
        ' requesting the parameter value from end-users.
        report.RequestParameters = True


        ' Show the parameter's value on a Report Header band.
        'Dim label As New XRLabel()
        'label.DataBindings.Add(New XRBinding(param1, "Text", "Exchange Rate Date: {0}"))
        'Dim reportHeader As New ReportHeaderBand()
        'reportHeader.Controls.Add(label)
        'report.Bands.Add(reportHeader)

        ' Assign the report to a ReportPrintTool,
        ' to hide the Parameters panel,
        ' and show the report's print preview.
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = True
        pt.ShowRibbonPreview(UserLookAndFeel.Default)

    End Sub

    Private Sub ExchangeRatesOCBSBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExchangeRatesOCBSBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExchangeRatesOCBSBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExchangeRatesOCBSBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ExchangeRatesChart_btn_Click(sender As Object, e As EventArgs) Handles ExchangeRatesChart_btn.Click
        If Not ChartControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        CompositeLink1.CreateDocument()
        CompositeLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "EXCHANGE RATES Charts" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
End Class