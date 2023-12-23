Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports Bytescout.PDFExtractor
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
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
Imports DevExpress.Spreadsheet
Imports DevExpress.Utils
Imports DevExpress.Data
Imports DevExpress.XtraGrid

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.XtraPivotGrid

Public Class InterestRateRiskCalc2023

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Boolean = False

    Friend WithEvents BgwExcel_NII_Load As BackgroundWorker
    Friend WithEvents BgwExcel_EVE_Load As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()


    Private BS_BusinessDates As BindingSource

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

    Private Sub InterestRateRiskCalc2023_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.LayoutControl2.Visible = False Then
                Me.ViewDetails_SwitchItem.Checked = False
                Me.LayoutControl2.Visible = True
                Me.RATERISK_DATETableAdapter.FillByRiskDateFrom20231231(Me.InterestRateRiskDataSet.RATERISK_DATE)
            End If

        End If
    End Sub

    Private Sub InterestRateRiskCalc2023_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LayoutControl2.Dock = DockStyle.Fill
        Me.LayoutControl1.Dock = DockStyle.Fill
        Me.RATERISK_DATETableAdapter.FillByRiskDateFrom20231231(Me.InterestRateRiskDataSet.RATERISK_DATE)
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()

    End Sub

    Private Sub BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RateRiskDate],104) as 'BusinessDate' from [RATERISK DATE] where [RateRiskDate]>='20220930' ORDER BY [RateRiskDate] desc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "BusinessDate")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_BusinessDates = New BindingSource(ds, "BusinessDate")
    End Sub
    Private Sub BUSINESS_DATES_InitLookUp()
        Me.BusinessDate_SearchLookUpEdit.DataSource = BS_BusinessDates
        Me.BusinessDate_SearchLookUpEdit.DisplayMember = "BusinessDate"
        Me.BusinessDate_SearchLookUpEdit.ValueMember = "BusinessDate"
    End Sub

    Private Sub IRR_EVE_GeneralRatios()
        QueryText = "SELECT * FROM [RATERISK DATE] where [RateRiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.IRR_EVE_GeneralRatios_GridControl.DataSource = Nothing
        Me.IRR_EVE_GeneralRatios_GridControl.DataSource = dt
        Me.IRR_EVE_GerenarlRatios_BandedGridView.BestFitColumns()
    End Sub
    Private Sub LOAD_IRR_NII_TOTALS()
        'Create data adapters for retrieving data from the tables
        Dim NII_Totals_Adapter As New SqlDataAdapter("SELECT [Period]
                                                              ,[Principal Amount/Value Balance(EUR Equ)]
                                                              ,[In_CashFlow]
                                                              ,[In_AvgTermDays]
                                                              ,[In_NII_Change]
                                                              ,[Out_CashFlow]
                                                              ,[Out_AvgTermDays]
                                                              ,[Out_NII_Change]
                                                              ,[Net_CashFlow]
                                                              ,[Net_AvgTermDays]
                                                              ,[Net_NII_Change] 
                                                            FROM [RATERISK TOTALS] where CalculationMethod in (3) and [RISK DATE]='" & rdsql & "'
                                                                                                                order by PeriodNr asc", conn)
        Dim NII_Details_Adapter As New SqlDataAdapter("SELECT [CURRENCY]
                                                             ,[Period]
                                                              ,[Principal Amount/Value Balance(EUR Equ)]
                                                              ,[In_CashFlow]
                                                              ,[In_AvgTermDays]
                                                              ,[In_NII_Change]
                                                              ,[Out_CashFlow]
                                                              ,[Out_AvgTermDays]
                                                              ,[Out_NII_Change]
                                                              ,[Net_CashFlow]
                                                              ,[Net_AvgTermDays]
                                                              ,[Net_NII_Change] 
                                                            FROM [RATERISK TOTALS] where CalculationMethod in (2) and [RISK DATE]='" & rdsql & "'
                                                                                                                order by PeriodNr asc", conn)

        Dim NII_dataSet As New DataSet()
        'Create DataTable objects for representing database's tables
        NII_Totals_Adapter.Fill(NII_dataSet, "RateRisk_Totals")
        NII_Details_Adapter.Fill(NII_dataSet, "RateRisk_Details")

        'Set up a master-detail relationship between the DataTables
        Dim keyColumn As DataColumn = NII_dataSet.Tables("RateRisk_Totals").Columns("Period")
        Dim foreignKeyColumn As DataColumn = NII_dataSet.Tables("RateRisk_Details").Columns("Period")
        NII_dataSet.Relations.Add("NII Currency Details", keyColumn, foreignKeyColumn)

        'Bind the grid control to the data source
        Me.IRR_NII_Totals_GridControl.DataSource = NII_dataSet.Tables("RateRisk_Totals")
        Me.IRR_NII_Totals_GridControl.ForceInitialize()
        Me.IRR_NII_Totals_GridControl.LevelTree.Nodes.Add("NII Currency Details", Me.NII_TOTALS_DETAILS_BandedGridView)
        Me.NII_TOTALS_BandedGridView.BestFitColumns()
        Me.NII_TOTALS_DETAILS_BandedGridView.BestFitColumns()

        'QueryText = "SELECT * FROM [RATERISK TOTALS] where CalculationMethod=2 and [RISK DATE]='" & rdsql & "'
        '      order by ID asc"
        'da = New SqlDataAdapter(QueryText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)
        'Me.IRR_NII_Totals_GridControl.DataSource = Nothing
        'Me.IRR_NII_Totals_GridControl.DataSource = dt
    End Sub
    Private Sub LOAD_IRR_NII_EVE_DETAILS()
        QueryText = "SELECT * FROM [RATERISK DETAILS]
                where CalculationMethod=2 and [RISK DATE]='" & rdsql & "'
                ORDER BY PeriodNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.IRR_NII_Details_GridControl.DataSource = Nothing
        Me.IRR_NII_Details_GridControl.DataSource = dt
        Me.NII_Details_GridView.BestFitColumns()
        Me.IRR_EVE_Details_GridControl.DataSource = Nothing
        Me.IRR_EVE_Details_GridControl.DataSource = dt
        Me.IRR_EVE_Details_BandedGridView.BestFitColumns()
    End Sub


    Private Sub IRR_EVE_TOTALS()
        QueryText = "SELECT * FROM [RATERISK TOTALS] where [RISK DATE]='" & rdsql & "' and CalculationMethod in (4)
                     order by CURRENCY asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.IRR_EVE_Totals_GridControl.DataSource = Nothing
        Me.IRR_EVE_Totals_GridControl.DataSource = dt
        Me.IRR_EVE_Totals_BandedGridView.BestFitColumns()
    End Sub
    Private Sub FILL_ALL_DATA()
        Me.RATERISK_DATETableAdapter.FillByRiskDate(Me.InterestRateRiskDataSet.RATERISK_DATE, rd)
        IRR_EVE_GeneralRatios()
        LOAD_IRR_NII_TOTALS()
        LOAD_IRR_NII_EVE_DETAILS()
        IRR_EVE_TOTALS()
    End Sub

    Private Sub Reload_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Reload_bbi.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Loading all Business Dates")
        Me.RATERISK_DATETableAdapter.FillByRiskDateFrom20231231(Me.InterestRateRiskDataSet.RATERISK_DATE)
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()
        SplashScreenManager.CloseForm(False)



    End Sub

    Private Sub BusinessDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessDate_BarEditItem.EditValueChanged
        If Me.LayoutControl2.Visible = False Then
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Interest Rate Risk Data for: " & rd)
            FILL_ALL_DATA()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub



    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub



#Region "GRIDVIEW STYLES and PRINT-EXPORT"

    Private Sub Print_Export_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Print_Export_bbi.ItemClick
        If Me.LayoutControl2.Visible = True Then
            If Not IRR_AllDates_GridControl.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink_AllDates.CreateDocument()
            PrintableComponentLink_AllDates.ShowPreview()
            SplashScreenManager.CloseForm(False)
        ElseIf Me.LayoutControl2.Visible = False Then
            If Not LayoutControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
                Return
            End If
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink_SingleDate.CreateDocument()
            PrintableComponentLink_SingleDate.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub PrintableComponentLink_AllDates_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink_AllDates.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink_AllDates_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink_AllDates.CreateMarginalHeaderArea
        Dim reportfooter As String = "Interest Rate Risks"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintableComponentLink_SingleDate_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink_SingleDate.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink_SingleDate_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink_SingleDate.CreateMarginalHeaderArea
        Dim reportfooter As String = "Interest Rate Risk" & "  " & "for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



#End Region

#Region "REPORTS"
    Private Sub InterestRateRiskEVE_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles InterestRateRiskEVE_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Interest Rate Risk Report (Economic value of equity) for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString)
        rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim IRR_DATE_Da As New SqlDataAdapter("Select * from [RATERISK DATE] where RateRiskDate='" & rdsql & "' ", conn)
        Dim IRR_TOTALS_Da As New SqlDataAdapter("Select * from [RATERISK TOTALS] where CalculationMethod in (4) and [RISK DATE]='" & rdsql & "'", conn)

        Dim IRR_Dataset As New DataSet("IRR")
        IRR_DATE_Da.Fill(IRR_Dataset, "RATERISK DATE")
        IRR_TOTALS_Da.Fill(IRR_Dataset, "RATERISK TOTALS")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_EVE_REP.rpt")
        'Dim r As New INT_RATE_RISK_BC_REP
        CrRep.SetDataSource(IRR_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "INTEREST RATE RISK (Economic value of equity) from " & rd
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(90)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub InterestRateRisk_NII_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles InterestRateRisk_NII_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Interest Rate Risk Report" & vbNewLine & "(NII - Net Interest Income) for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString)
        rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim IRR_DATE_Da As New SqlDataAdapter("Select * from [RATERISK DATE] where RateRiskDate='" & rdsql & "' ", conn)
        Dim IRR_TOTALS_Da As New SqlDataAdapter("Select * from [RATERISK TOTALS] where [RISK DATE]='" & rdsql & "' and [CalculationMethod]=3", conn)

        Dim IRR_Dataset As New DataSet("IRR")
        IRR_DATE_Da.Fill(IRR_Dataset, "RATERISK DATE")
        IRR_TOTALS_Da.Fill(IRR_Dataset, "RATERISK TOTALS")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_NII_REP.rpt")
        'Dim r As New INT_RATE_RISK_REP
        CrRep.SetDataSource(IRR_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Interest Rate Risk report (NII) from " & rd
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(90)
        SplashScreenManager.CloseForm(False)
    End Sub



#End Region


    Private Sub IRR_AllDates_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles IRR_AllDates_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RateRiskDate")
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
        End If
    End Sub
    Private Sub IRR_AllDates_GridView_DoubleClick(sender As Object, e As EventArgs) Handles IRR_AllDates_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RateRiskDate")
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Interest Rate Risk Data for: " & rd)
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
            FILL_ALL_DATA()
            Me.LayoutControl2.Visible = False
            Me.ViewDetails_SwitchItem.Checked = True
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub IRR_NII_Excel_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles IRR_NII_Excel_BarbuttonItem.ItemClick
        If XtraMessageBox.Show("Should the current data for the IRR NII be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.BusinessDate_BarEditItem.EditValue.ToString)

                BgwExcel_NII_Load = New BackgroundWorker
                BgwExcel_NII_Load.WorkerReportsProgress = True
                BgwExcel_NII_Load.RunWorkerAsync()
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        End If

    End Sub

    Private Sub BgwExcel_NII_Load_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcel_NII_Load.DoWork

        Try
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_CREDIT_INTEREST_RISK_NII' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('InterestRateRisk_NII_ExcelFile_creation') 
                    and  Id_SQL_Parameters in ('EXCEL_FILES_CREATION'))"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For s = 0 To dt.Rows.Count - 1
                    ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                    If ScriptType = "SQL" Then
                        SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    ElseIf ScriptType = "VB" Then
                        Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<IMPORT_DIR_FILE>", ExcelFileName).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                        Dim entry As String = "VB_ScriptForExecution"
                        If code = "" Then Return
                        If entry = "" Then entry = "VB_ScriptForExecution"
                        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                        engine.Run()
                    End If
                Next
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/InterestRateRisk_NII_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            BgwExcel_NII_Load.CancelAsync()
        End Try



    End Sub

    Private Sub BgwExcel_NII_Load_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcel_NII_Load.RunWorkerCompleted
        If e.Cancelled = False Then
            Dim c As New ExcelForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "Interest Rate Risk (NII Method) for " & Me.BusinessDate_BarEditItem.EditValue.ToString
            c.SpreadsheetControl1.ReadOnly = True

            workbook = c.SpreadsheetControl1.Document
            Using stream As New FileStream(ExcelFileName, FileMode.Open)
                workbook.LoadDocument(stream, DocumentFormat.OpenXml)
            End Using

            'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub IRR_EVE_Excel_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles IRR_EVE_Excel_BarbuttonItem.ItemClick
        If XtraMessageBox.Show("Should the current data for the IRR EVE be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.BusinessDate_BarEditItem.EditValue.ToString)

                BgwExcel_EVE_Load = New BackgroundWorker
                BgwExcel_EVE_Load.WorkerReportsProgress = True
                BgwExcel_EVE_Load.RunWorkerAsync()
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        End If
    End Sub

    Private Sub BgwExcel_EVE_Load_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcel_EVE_Load.DoWork
        Try
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_CREDIT_INTEREST_RISK_EVE' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('InterestRateRisk_EVE_ExcelFile_creation') 
                    and  Id_SQL_Parameters in ('EXCEL_FILES_CREATION'))"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For s = 0 To dt.Rows.Count - 1
                    ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                    If ScriptType = "SQL" Then
                        SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                        cmd.CommandText = SqlCommandText
                        cmd.ExecuteNonQuery()
                    ElseIf ScriptType = "VB" Then
                        Dim code As String = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<IMPORT_DIR_FILE>", ExcelFileName).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                        Dim entry As String = "VB_ScriptForExecution"
                        If code = "" Then Return
                        If entry = "" Then entry = "VB_ScriptForExecution"
                        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                        engine.Run()
                    End If
                Next
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/InterestRateRisk_EVE_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            BgwExcel_EVE_Load.CancelAsync()
        End Try



    End Sub

    Private Sub BgwExcel_EVE_Load_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcel_EVE_Load.RunWorkerCompleted
        If e.Cancelled = False Then
            Dim c As New ExcelForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "Interest Rate Risk (EVE Method) for " & Me.BusinessDate_BarEditItem.EditValue.ToString
            c.SpreadsheetControl1.ReadOnly = True

            workbook = c.SpreadsheetControl1.Document
            Using stream As New FileStream(ExcelFileName, FileMode.Open)
                workbook.LoadDocument(stream, DocumentFormat.OpenXml)
            End Using

            'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub ViewDetails_SwitchItem_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles ViewDetails_SwitchItem.CheckedChanged
        If Me.ViewDetails_SwitchItem.Checked = False Then
            Me.LayoutControl2.Visible = True
            Me.ViewDetails_SwitchItem.Caption = "Show Details"
            Me.Reload_bbi.PerformClick()
        ElseIf Me.ViewDetails_SwitchItem.Checked = True Then
            If IsDate(rd) = True Then
                rdsql = rd.ToString("yyyyMMdd")
                FILL_ALL_DATA()
                Me.LayoutControl2.Visible = False
                Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
                Me.ViewDetails_SwitchItem.Caption = "Show List"
            End If
        End If

    End Sub

    Private Sub LayoutControl2_VisibleChanged(sender As Object, e As EventArgs) Handles LayoutControl2.VisibleChanged
        If Me.LayoutControl2.Visible = True Then
            Me.RibbonPageGroup3.Visible = False
            Me.RibbonPageGroup1.Visible = True
        ElseIf Me.LayoutControl2.Visible = False Then
            Me.RibbonPageGroup3.Visible = True
            Me.RibbonPageGroup1.Visible = False
        End If
    End Sub

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        'If e.SelectedControl IsNot IRR_Ratio_Totals_GridControl Then
        '    Return
        'End If

        'Dim info As ToolTipControlInfo = Nothing
        'Dim view As GridView = TryCast(IRR_Ratio_Totals_GridControl.GetViewAt(e.ControlMousePosition), GridView)
        'If view Is Nothing Then
        '    Return
        'End If
        'Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'If hi.HitTest = GridHitTest.Footer AndAlso hi.Column IsNot Nothing AndAlso hi.Column.SummaryItem.SummaryType = SummaryItemType.Custom Then

        '    If hi.Column.FieldName = "AM1" OrElse hi.Column.FieldName = "AM2" Then
        '        Dim o As Object = hi.Column.FieldName + hi.FooterCell.ToString()
        '        'Dim text As String = hi.FooterCell.SummaryItem.SummaryType.ToString() & " = " & hi.FooterCell.SummaryItem.SummaryValue.ToString()
        '        Dim text As String = "Sum amount is calculated as follows:" & vbNewLine & "Old Method:" &
        '            vbNewLine & "Sum Amount of each Currency for each Column (-200/+200 bps)" & vbNewLine &
        '            vbNewLine & "New Method:" & vbNewLine & "Currency:EURO Sum Amount" & vbNewLine & "+ Minimum Sum Amount of each Currency between +/- 200 bps"

        '        info = New ToolTipControlInfo(o, text)

        '    End If

        'End If
        'If info IsNot Nothing Then
        '    e.Info = info
        'End If
    End Sub

    Private Sub BusinessDate_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessDate_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 2 Then
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Interest Rate Risk Data for: " & rd)
            FILL_ALL_DATA()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub


End Class