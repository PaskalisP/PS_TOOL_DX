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

Public Class CreditSpreadRiskCalc


    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim EAEG_C_Satz_ViewCaption As String = Nothing
    Dim ActiveTabGroup As Boolean = False


    Friend WithEvents BgwExcelLoad As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()

    Dim Sum_Calculation_Segment_Risk_MidVec As Double = 0


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

    Private Sub CreditSpreadRiskCalc_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.LayoutControl2.Visible = False Then
                Me.ViewDetails_SwitchItem.Checked = False
                Me.LayoutControl2.Visible = True
                Me.CreditSpreadRisk_TOTALSTableAdapter.Fill(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_TOTALS)
            End If

        End If
    End Sub

    Private Sub CreditSpreadRiskCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LayoutControl2.Dock = DockStyle.Fill
        Me.LayoutControl1.Dock = DockStyle.Fill
        Me.CreditSpreadRisk_TOTALSTableAdapter.Fill(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_TOTALS)
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()

    End Sub

    Private Sub BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RiskDate],104) as 'BusinessDate' from [CreditSpreadRisk_TOTALS] ORDER BY [ID] desc", conn)
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

    Private Sub LOAD_Calculation_Single_Asset_MidVec()
        QueryText = "SELECT 
                   [CalculationDescription]
                  ,[RowNr]
                  ,[ColNr]
                  ,[FieldName2] --ISINS
	              ,[FieldValue1] --SingleAssetRisk
                  ,[FieldName5] --ISIN_A
                  ,[FieldName7] --ISIN_B
	              ,[FieldValue2] --CorrelationValue
                  ,[ResultFieldValue] --MidVec
                  ,[RiskDate]
              FROM [CreditSpreadRisk_MatrixCorrelationCalculations]
              where [CalculationDescription] in ('Calculation_Single_Asset_MidVec')
              and [RiskDate]='" & rdsql & "'
              order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.Calculation_Single_Asset_MidVec_GridControl.DataSource = Nothing
        Me.Calculation_Single_Asset_MidVec_GridControl.DataSource = dt
    End Sub

    Private Sub LOAD_Calculation_Single_Segment_MidVec()
        QueryText = "SELECT [CalculationDescription]
                  ,[RowNr]
                  ,[ColNr]
                  ,[FieldName2] --as ISIN
                  ,[FieldValue1] --as SEGMENT
                  ,[FieldValue2] --as SingleAssetRisk
                  ,[FieldValue4] --as SumMidVec
                  ,[ResultFieldValue] --as SingleSegmentMidVec
                  ,[RiskDate]
              FROM [CreditSpreadRisk_MatrixCorrelationCalculations]
              where CalculationDescription in ('Calculation_Single_Segment_MidVec')
              and [RiskDate]='" & rdsql & "'
              order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.Calculation_Single_Segment_MidVec_GridControl.DataSource = Nothing
        Me.Calculation_Single_Segment_MidVec_GridControl.DataSource = dt
    End Sub

    Private Sub LOAD_Calculation_Segment_Risk_MidVec()
        QueryText = "SELECT [CalculationDescription]
                  ,[RowNr]
                  ,[ColNr]
                  ,[FieldValue1] --as SEGMENT_A
                  ,[FieldValue2] --as SEGMENT_B
                  ,[FieldValue3] --as Segment_Risk
				  ,[FieldValue6] --as Segment_Correlation
                  ,[ResultFieldValue] --as Segment_Risk_MidVec
                  ,[RiskDate]
              FROM [CreditSpreadRisk_MatrixCorrelationCalculations]
              where CalculationDescription in ('Calculation_Segment_Risk_MidVec')
              and [RiskDate]='" & rdsql & "'
              order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.Calculation_Segment_Risk_MidVec_GridControl.DataSource = Nothing
        Me.Calculation_Segment_Risk_MidVec_GridControl.DataSource = dt
    End Sub

    Private Sub Reload_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Reload_bbi.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Loading all Business Dates")
        Me.CreditSpreadRisk_TOTALSTableAdapter.Fill(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_TOTALS)
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub BusinessDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessDate_BarEditItem.EditValueChanged
        If Me.LayoutControl2.Visible = False Then
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Credit Spread Risk Data for: " & rd)

            Me.CreditSpreadRisk_SingleAssetsCorrelationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_SingleAssetsCorrelation, rd)
            Me.CreditSpreadRisk_SegmentsTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_Segments, rd)
            Me.CreditSpreadRisk_SegmentRiskCalculationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_SegmentRiskCalculation, rd)
            Me.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_PortfolioRiskCalculation, rd)
            Me.CreditSpreadRisk_MatrixCorrelationCalculationsTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_MatrixCorrelationCalculations, rd)
            Me.CreditSpreadRisk_BondPortfolioTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_BondPortfolio, rd)
            Me.CreditSpreadRisk_TOTALSTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_TOTALS, rd)
            LOAD_Calculation_Single_Asset_MidVec()
            LOAD_Calculation_Single_Segment_MidVec()
            LOAD_Calculation_Segment_Risk_MidVec()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub



    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub



#Region "GRIDVIEW STYLES and PRINT-EXPORT"

    Private Sub Print_Export_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Print_Export_bbi.ItemClick
        If Me.LayoutControl2.Visible = True Then
            If Not CSR_AllDates_GridControl.IsPrintingAvailable Then
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
        Dim reportfooter As String = "Portfolio Credit Spread Risks"
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
        Dim reportfooter As String = "Portfolio Credit Spread Risk" & "  " & "for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



#End Region

#Region "REPORTS"
    Private Sub CreditSpreadRisk_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CreditSpreadRisk_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Portfolio Credit Spread Risk report for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString)
        rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\PortfolioCreditSpreadRisk.rpt")
        'Dim r As New LOAN_STRUCTURE_TABLE
        CrRep.SetDataSource(CreditSpreadRiskDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Portfolio Credit Spread Risk report for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(100)
        SplashScreenManager.CloseForm(False)
    End Sub



#End Region



    Private Sub CSR_AllDates_GridView_RowClick(sender As Object, e As RowClickEventArgs)
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
        End If
    End Sub

    Private Sub CSR_AllDates_GridView_DoubleClick(sender As Object, e As EventArgs) Handles CSR_AllDates_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Credit Spread Risk Data for: " & rd)
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
            Me.CreditSpreadRisk_SingleAssetsCorrelationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_SingleAssetsCorrelation, rd)
            Me.CreditSpreadRisk_SegmentsTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_Segments, rd)
            Me.CreditSpreadRisk_SegmentRiskCalculationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_SegmentRiskCalculation, rd)
            Me.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_PortfolioRiskCalculation, rd)
            Me.CreditSpreadRisk_MatrixCorrelationCalculationsTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_MatrixCorrelationCalculations, rd)
            Me.CreditSpreadRisk_BondPortfolioTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_BondPortfolio, rd)
            Me.CreditSpreadRisk_TOTALSTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_TOTALS, rd)
            LOAD_Calculation_Single_Asset_MidVec()
            LOAD_Calculation_Single_Segment_MidVec()
            LOAD_Calculation_Segment_Risk_MidVec()
            Me.LayoutControl2.Visible = False
            Me.ViewDetails_SwitchItem.Checked = True
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub CreditSpreadRiskExcel_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CreditSpreadRiskExcel_BarbuttonItem.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.BusinessDate_BarEditItem.EditValue.ToString)

            BgwExcelLoad = New BackgroundWorker
            BgwExcelLoad.WorkerReportsProgress = True
            BgwExcelLoad.RunWorkerAsync()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwExcelLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad.DoWork
        rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_CREDIT_SPREAD_RISK' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and IdABTEILUNGSCODE_NAME='EDP'  and [PARAMETER STATUS]='Y'"
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        CloseSqlConnections()

        'QueryText = "Select * from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EAEG_BILANZ_Differences')  and [Status] in ('Y') and Id_SQL_Parameters in ('EAEG')"
        'da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        'dt1 = New System.Data.DataTable()
        'da1.Fill(dt1)
        'SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
        'da = New SqlDataAdapter(SqlCommandText.Trim(), conn)
        'dt = New System.Data.DataTable()
        'da.Fill(dt)

        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with Data results")
        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument(ExcelFileName, DocumentFormat.OpenXml)
        Dim worksheets As WorksheetCollection = workbook.Worksheets
        Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Parameter")
        Dim WsCorl As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Correlations")
        Dim WsCalc As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Result")

        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel File Sheets")
        ' Delete the "MatrixCalculations" worksheet from the workbook. 
        workbook.Worksheets.Remove(workbook.Worksheets("MatrixCalculations"))
        workbook.Worksheets.Insert(1, "MatrixCalculations")
        Dim WsMatrixCalc As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("MatrixCalculations")

        worksheet.Clear(worksheet("A1:AZ10000"))
        worksheet.DefinedNames.Clear()

        WsCorl.Clear(WsCorl("A1:AZ10000"))
        WsCorl.DefinedNames.Clear()

        WsCalc.Clear(WsCalc("A1:AZ10000"))
        WsCalc.DefinedNames.Clear()

        WsMatrixCalc.Clear(WsMatrixCalc("A1:AZ10000"))
        WsMatrixCalc.Columns.UnGroup(0, 5000, True)
        WsMatrixCalc.Rows.UnGroup(0, 5000, True)
        WsMatrixCalc.DefinedNames.Clear()

        workbook.Worksheets.ActiveWorksheet = workbook.Worksheets("Result")

        SplashScreenManager.Default.SetWaitFormCaption("Load Parameters in Sheet:PARAMETER")
        'RISK WEIGHT PARAMETERS
        worksheet.MergeCells(worksheet.Range("A1:G1"))
        worksheet.Cells("A1").Value = "Risk Weight - Rating Class - Sector"
        Dim cell As Cell = worksheet.Cells("A1")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center


        QueryText = "SELECT [ParameterNr] as 'Nr.'
                    ,[ParameterNameGeneral] as 'General Parameter Name'
                    ,[ParameterName1] as 'Rating Class'
                    ,[ParameterName2] as 'Sector'
                    ,[ParameterValue1] as 'Segment'
                    ,[ParameterValue2] as 'Risk Weight'
                    ,[ParameterStatus] FROM [Parameter_CreditSpreadRisk_References] 
                    where [ParameterStatus] in ('Y') 
                    and ParameterNameGeneral in ('Risk_Weight_by_Issuer_Rating_Class_and_Sector') 
                    Order by ParameterNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, True, 1, 0)

        Dim RiskWeight_DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            RiskWeight_DETAILS_LastRow = dt.Rows.Count + 2
        End If


        Dim RiskWeightRange As CellRange = worksheet.Range("A3:G" & RiskWeight_DETAILS_LastRow)
        RiskWeightRange.Name = "RiskWeight_Parameters"

        Dim RiskWeightRangeBorders As CellRange = worksheet.Range("A1:G" & RiskWeight_DETAILS_LastRow)
        RiskWeightRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim RiskWeightHeaders As CellRange = worksheet.Range("A2:G2")
        RiskWeightHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim RiskWeightValues As CellRange = worksheet.Range("F3:F" & RiskWeight_DETAILS_LastRow)
        RiskWeightValues.NumberFormat = "#,##"

        dt.Reset()
        RiskWeight_DETAILS_LastRow = 0
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'TENOR PARAMETERS
        worksheet.MergeCells(worksheet.Range("I1:O1"))
        worksheet.Cells("I1").Value = "Tenor"
        cell = worksheet.Cells("I1")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center


        QueryText = "SELECT [ParameterNr] as 'Nr.'
                            ,[ParameterNameGeneral] as 'General Parameter Name'
                            ,[ParameterName1] as 'Tenor Period'
                            ,[ParameterName2] as 'Tenor Period Description'
                            ,[ParameterValue1] as 'Min'
                            ,[ParameterValue2] as 'Max'
                            ,[ParameterStatus] 
                            FROM [Parameter_CreditSpreadRisk_References] 
                            where [ParameterStatus] in ('Y') 
                            and ParameterNameGeneral in ('Tenor') 
                            Order by ParameterNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, True, 1, 8)

        Dim DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            DETAILS_LastRow = dt.Rows.Count + 2
        End If


        Dim TenorRange As CellRange = worksheet.Range("I3:O" & DETAILS_LastRow)
        TenorRange.Name = "Tenor_Parameters"

        Dim TenorRangeBorders As CellRange = worksheet.Range("I1:O" & DETAILS_LastRow)
        TenorRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim TenorHeaders As CellRange = worksheet.Range("I2:O2")
        TenorHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim TenorValues As CellRange = worksheet.Range("M3:N" & DETAILS_LastRow)
        TenorValues.NumberFormat = "0.00"


        dt.Reset()
        Dim TenorDetails_LastRow As Integer = DETAILS_LastRow
        DETAILS_LastRow = 0
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'CORRELATIONS BETWEEN 2 RISK POSITIONS
        worksheet.MergeCells(worksheet.Range("I" & TenorDetails_LastRow + 2 & ":O" & TenorDetails_LastRow + 2))
        worksheet.Cells("I" & TenorDetails_LastRow + 2).Value = "Correlation between two risk positions"
        cell = worksheet.Cells("I" & TenorDetails_LastRow + 2)
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

        QueryText = "SELECT [ParameterNr] as 'Nr.'
                            ,[ParameterNameGeneral] as 'General Parameter Name'
                            ,[ParameterName1] as 'Correlation Type'
                            ,[ParameterName2] as 'Correlation Type Description'
                            ,[ParameterValue1] as 'Same'
                            ,[ParameterValue2] as 'Not Same'
                            ,[ParameterStatus] 
                            FROM [Parameter_CreditSpreadRisk_References] 
                            where [ParameterStatus] in ('Y') 
                            and ParameterNameGeneral 
                            in ('Correlation_between_two_risk_positions') 
                            Order by ParameterNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, True, TenorDetails_LastRow + 2, 8)

        If dt.Rows.Count > 0 Then
            DETAILS_LastRow = TenorDetails_LastRow + 3 + dt.Rows.Count
        End If

        Dim CorrelationRiskPositionsRange As CellRange = worksheet.Range("I" & TenorDetails_LastRow + 4 & ":O" & DETAILS_LastRow)
        CorrelationRiskPositionsRange.Name = "CorrelationRiskPositions_Parameters"

        Dim CorrelationRiskPositionsBorders As CellRange = worksheet.Range("I" & TenorDetails_LastRow + 2 & ":O" & DETAILS_LastRow)
        CorrelationRiskPositionsBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim CorrelationRiskPositionsHeaders As CellRange = worksheet.Range("I10:O10")
        CorrelationRiskPositionsHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim CorrelationRiskPositionsValues As CellRange = worksheet.Range("M11:N" & DETAILS_LastRow)
        CorrelationRiskPositionsValues.NumberFormat = "0.00 %"


        dt.Reset()
        Dim CorrelationRiskPositions_LastRow As Integer = DETAILS_LastRow
        DETAILS_LastRow = 0

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'CURVE TYPES
        worksheet.MergeCells(worksheet.Range("I" & CorrelationRiskPositions_LastRow + 2 & ":M" & CorrelationRiskPositions_LastRow + 2))
        worksheet.Cells("I" & CorrelationRiskPositions_LastRow + 2).Value = "Curve Types"
        cell = worksheet.Cells("I" & CorrelationRiskPositions_LastRow + 2)
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

        QueryText = "SELECT [ParameterNr] as 'Nr.'
                            ,[ParameterNameGeneral] as 'General Parameter Name'
                            ,[ParameterName1] as 'Curve Type'
                            ,[ParameterName2] as 'Curve Type Description'
                            ,[ParameterStatus] 
                            FROM [Parameter_CreditSpreadRisk_References] 
                            where [ParameterStatus] in ('Y') 
                            and ParameterNameGeneral in ('Curve_Type') 
                            Order by ParameterNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, True, CorrelationRiskPositions_LastRow + 2, 8)

        If dt.Rows.Count > 0 Then
            DETAILS_LastRow = CorrelationRiskPositions_LastRow + 3 + dt.Rows.Count
        End If

        Dim CurveTypeRange As CellRange = worksheet.Range("I" & CorrelationRiskPositions_LastRow + 4 & ":M" & DETAILS_LastRow)
        CurveTypeRange.Name = "CurveType_Parameters"

        Dim CurveTypeRangeBorders As CellRange = worksheet.Range("I" & CorrelationRiskPositions_LastRow + 2 & ":M" & DETAILS_LastRow)
        CurveTypeRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim CurveTypeHeaders As CellRange = worksheet.Range("I16:M16")
        CurveTypeHeaders.Fill.BackgroundColor = Color.LightBlue


        dt.Reset()
        Dim CurveType_LastRow As Integer = DETAILS_LastRow
        DETAILS_LastRow = 0
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'SCALING PARAMETERS
        worksheet.MergeCells(worksheet.Range("I" & CurveType_LastRow + 2 & ":M" & CurveType_LastRow + 2))
        worksheet.Cells("I" & CurveType_LastRow + 2).Value = "Scaling Parameter Levels"
        cell = worksheet.Cells("I" & CurveType_LastRow + 2)
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

        QueryText = "SELECT [ParameterNr] as 'Nr.'
                            ,[ParameterNameGeneral] as 'General Parameter Name'
                            ,[ParameterName1] as 'Scaling Level'
                            ,[ParameterValue1] as 'Level Value'
                            ,[ParameterStatus] 
                            FROM [Parameter_CreditSpreadRisk_References] 
                            where [ParameterStatus] in ('Y') 
                            and ParameterNameGeneral in ('Scaling_Parameter_Levels') 
                            Order by ParameterNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, True, CurveType_LastRow + 2, 8)

        If dt.Rows.Count > 0 Then
            DETAILS_LastRow = CurveType_LastRow + 3 + dt.Rows.Count
        End If

        Dim ScalingParameterRange As CellRange = worksheet.Range("I" & CurveType_LastRow + 4 & ":M" & DETAILS_LastRow)
        ScalingParameterRange.Name = "Scaling_Level_Parameters"

        Dim ScalingParameterRangeBorders As CellRange = worksheet.Range("I" & CurveType_LastRow + 2 & ":M" & DETAILS_LastRow)
        ScalingParameterRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim ScalingHeaders As CellRange = worksheet.Range("I22:M22")
        ScalingHeaders.Fill.BackgroundColor = Color.LightBlue


        dt.Reset()
        DETAILS_LastRow = 0

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        worksheet.MergeCells(worksheet.Range("Q1:AG1"))
        worksheet.Cells("Q1").Value = "Segments Correlations"
        cell = worksheet.Cells("Q1")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

        QueryText = "SELECT [SeqNr] as 'Sequence Correlations'
                            ,[SeqNr1] as '1'
                            ,[SeqNr2] as '2'
                            ,[SeqNr3] as '3'
                            ,[SeqNr4] as '4'
                            ,[SeqNr5] as '5'
                            ,[SeqNr6] as '6'
                            ,[SeqNr7] as '7'
                            ,[SeqNr8] as '8'
                            ,[SeqNr9] as '9'
                            ,[SeqNr10] as '10'
                            ,[SeqNr11] as '11'
                            ,[SeqNr12] as '12'
                            ,[SeqNr13] as '13'
                            ,[SeqNr14] as '14'
                            ,[SeqNr15] as '15'
                            ,[SeqNr16] as '16' 
                            FROM [Parameter_CreditSpreadRisk_Correlations] 
                            ORDER BY SeqNr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        worksheet.Import(dt, True, 1, 16)

        worksheet.Cells("R2").SetValueFromText("1", True)
        worksheet.Cells("S2").SetValueFromText("2", True)
        worksheet.Cells("T2").SetValueFromText("3", True)
        worksheet.Cells("U2").SetValueFromText("4", True)
        worksheet.Cells("V2").SetValueFromText("5", True)
        worksheet.Cells("W2").SetValueFromText("6", True)
        worksheet.Cells("X2").SetValueFromText("7", True)
        worksheet.Cells("Y2").SetValueFromText("8", True)
        worksheet.Cells("Z2").SetValueFromText("9", True)
        worksheet.Cells("AA2").SetValueFromText("10", True)
        worksheet.Cells("AB2").SetValueFromText("11", True)
        worksheet.Cells("AC2").SetValueFromText("12", True)
        worksheet.Cells("AD2").SetValueFromText("13", True)
        worksheet.Cells("AE2").SetValueFromText("14", True)
        worksheet.Cells("AF2").SetValueFromText("15", True)
        worksheet.Cells("AG2").SetValueFromText("16", True)


        If dt.Rows.Count > 0 Then
            DETAILS_LastRow = dt.Rows.Count + 2
        End If


        Dim SegmentsCorrelationsRange As CellRange = worksheet.Range("Q2:AG" & DETAILS_LastRow)
        SegmentsCorrelationsRange.Name = "SegmentsCorrelations_Parameters"

        Dim SegmentCorrelationBorders As CellRange = worksheet.Range("Q1:AG" & DETAILS_LastRow)
        SegmentCorrelationBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim SegmentCorrelationHeaders As CellRange = worksheet.Range("Q2:AG2")
        SegmentCorrelationHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim SegmentCorrelationRows As CellRange = worksheet.Range("Q2:Q" & DETAILS_LastRow)
        SegmentCorrelationRows.Fill.BackgroundColor = Color.LightBlue

        Dim SegmentCorrelationValues As CellRange = worksheet.Range("R3:AG" & DETAILS_LastRow)
        SegmentCorrelationValues.NumberFormat = "0.00 %"


        dt.Reset()
        DETAILS_LastRow = 0

        Dim worksheet_TotalRange As CellRange = worksheet.Range("A1:AZ20000")
        worksheet_TotalRange.AutoFitColumns()


        SplashScreenManager.Default.SetWaitFormCaption("Load Correlations in Sheet:Correlations")
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'CORRELATIONS DATA
        WsCorl.MergeCells(WsCorl.Range("A1:N1"))
        WsCorl.Cells("A1").Value = "Correlation Data for " & rd
        cell = WsCorl.Cells("A1")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 14
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        Dim cellA1_Corl_Borders As DevExpress.Spreadsheet.Borders = cell.Borders
        cellA1_Corl_Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        QueryText = "SELECT [EMMITENT_A] 
                            ,[EMMITENT_B]
                            ,[ISIN_A]
                            ,[ISIN_B]
                            ,[TENOR_A]
                            ,[TENOR_B]
                            ,[CURVE_A]
                            ,[CURVE_B]
                            ,[SEGMENT_A]
                            ,[SEGMENT_B]
                            ,[Correlation_Name] as K_Name
                            ,[Correlation_Tenor] as K_Tenor
                            ,[Correlation_Basis] as K_Basis
                            ,[CorrelationValue] 
                            FROM [CreditSpreadRisk_SingleAssetsCorrelation] 
                            where RiskDate='" & rdsql & "' 
                            order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        WsCorl.Import(dt, True, 1, 0)

        Dim CorrelationsData_DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            CorrelationsData_DETAILS_LastRow = dt.Rows.Count + 2
        End If

        Dim CorrelationsDataRange As CellRange = WsCorl.Range("A3:N" & CorrelationsData_DETAILS_LastRow)
        CorrelationsDataRange.Name = "CorrelationData"

        Dim CorrelationsDataBorders As CellRange = WsCorl.Range("A1:N" & CorrelationsData_DETAILS_LastRow)
        CorrelationsDataBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim CorrelationsDataHeaders As CellRange = WsCorl.Range("A2:N2")
        CorrelationsDataHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim CorrelationsDataValues As CellRange = WsCorl.Range("K3:N" & CorrelationsData_DETAILS_LastRow)
        CorrelationsDataValues.NumberFormat = "0.00 %"


        dt.Reset()

        Dim WsCorl_TotalRange As CellRange = WsCorl.Range("A1:AZ20000")
        WsCorl_TotalRange.AutoFitColumns()


        SplashScreenManager.Default.SetWaitFormCaption("Load Matrix Calculations in Sheet:MatrixCalculations")
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'MATRIX CALCULATIONS
        'Single Asset x Correlation Value
        WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A1:H1"))
        WsMatrixCalc.Cells("A1").Value = "Single Asset x Correlation Value for " & rd
        cell = WsMatrixCalc.Cells("A1")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 14
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        Dim WsMatrixCalc_cellA1Borders As DevExpress.Spreadsheet.Borders = cell.Borders
        WsMatrixCalc_cellA1Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        QueryText = "SELECT [RowNr]
                            ,[ColNr]
                            ,[FieldName2] as ISINS
                            ,[FieldValue1] as SingleAssetRisk
                            ,[FieldName5] as ISIN_A
                            ,[FieldName7] as ISIN_B
                            ,[FieldValue2] as CorrelationValue
                            ,[ResultFieldValue] as MidVec 
                            FROM [CreditSpreadRisk_MatrixCorrelationCalculations] 
                            where [CalculationDescription] in ('Calculation_Single_Asset_MidVec') 
                            and [RiskDate]='" & rdsql & "' 
                            order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        WsMatrixCalc.Import(dt, True, 1, 0)

        Dim SingleAsset_CorrelationValue_DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            SingleAsset_CorrelationValue_DETAILS_LastRow = dt.Rows.Count + 2
        End If

        Dim SingleAsset_CorrelationValueRange As CellRange = WsMatrixCalc.Range("A2:H" & SingleAsset_CorrelationValue_DETAILS_LastRow)
        SingleAsset_CorrelationValueRange.Name = "SingleAsset_CorrelationValue"

        Dim SingleAsset_CorrelationValueBorders As CellRange = WsMatrixCalc.Range("A1:H" & SingleAsset_CorrelationValue_DETAILS_LastRow)
        SingleAsset_CorrelationValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim SingleAsset_CorrelationValueHeaders As CellRange = WsMatrixCalc.Range("A2:H2")
        SingleAsset_CorrelationValueHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim WsMatrixCalc_SingleAssetDataValues As CellRange = WsMatrixCalc.Range("D3:D" & SingleAsset_CorrelationValue_DETAILS_LastRow)
        WsMatrixCalc_SingleAssetDataValues.NumberFormat = "#,##"

        Dim WsMatrixCalc_CorrelationsDataValues As CellRange = WsMatrixCalc.Range("G3:G" & SingleAsset_CorrelationValue_DETAILS_LastRow)
        WsMatrixCalc_CorrelationsDataValues.NumberFormat = "0.00 %"

        Dim WsMatrixCalc_MidVecValues As CellRange = WsMatrixCalc.Range("H3:H" & SingleAsset_CorrelationValue_DETAILS_LastRow)
        WsMatrixCalc_MidVecValues.NumberFormat = "#,##"

        Dim subtotalColumnsList As New List(Of Integer)()
        subtotalColumnsList.Add(7)
        WsMatrixCalc.Subtotal(SingleAsset_CorrelationValueRange, 4, subtotalColumnsList, 9, "Total")

        Dim WsMatrixCalc_DataRange As CellRange = WsMatrixCalc.GetUsedRange()
        Dim WsMatrixCalc_LastRowIndex As Integer = WsMatrixCalc_DataRange.BottomRowIndex

        dt.Reset()

        'Single Segment x MidVec
        WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 3 & ":G" & WsMatrixCalc_LastRowIndex + 3))
        WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex + 3).Value = "Single Segment x MidVec for " & rd
        cell = WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex + 3)
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 14
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        Dim WsMatrixCalc_cellA2Borders As DevExpress.Spreadsheet.Borders = cell.Borders
        WsMatrixCalc_cellA2Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        QueryText = "SELECT [RowNr]
                            ,[ColNr]
                            ,[FieldName2] as ISIN
                            ,[FieldValue1] as SEGMENT
                            ,[FieldValue2] as SingleAssetRisk
                            ,[FieldValue4] as SumMidVec
                            ,[ResultFieldValue] as SingleSegmentMidVec 
                            FROM [CreditSpreadRisk_MatrixCorrelationCalculations] 
                            where CalculationDescription in ('Calculation_Single_Segment_MidVec') 
                            and [RiskDate]='" & rdsql & "' 
                            order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        WsMatrixCalc.Import(dt, True, WsMatrixCalc_LastRowIndex + 3, 0)

        Dim SingleSegment_MidVecValue_DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            SingleSegment_MidVecValue_DETAILS_LastRow = WsMatrixCalc_LastRowIndex + 3 + dt.Rows.Count + 2
        End If


        Dim SingleSegment_MidVecValueRange As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":G" & SingleSegment_MidVecValue_DETAILS_LastRow - 1)
        SingleSegment_MidVecValueRange.Name = "SingleSegment_MidVec"

        Dim SingleSegment_MidVecValueBorders As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":G" & SingleSegment_MidVecValue_DETAILS_LastRow - 1)
        SingleSegment_MidVecValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim SingleSegment_MidVecValueHeaders As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":G" & WsMatrixCalc_LastRowIndex + 4)
        SingleSegment_MidVecValueHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim WsMatrixCalc_SingleSegment_MidVecDataValues As CellRange = WsMatrixCalc.Range("E" & WsMatrixCalc_LastRowIndex + 4 & ":G" & SingleSegment_MidVecValue_DETAILS_LastRow - 1)
        WsMatrixCalc_SingleSegment_MidVecDataValues.NumberFormat = "#,##"

        Dim subtotalColumnsList1 As New List(Of Integer)()
        subtotalColumnsList1.Add(6) 'Subtotals claculated for column:G
        WsMatrixCalc.Subtotal(SingleSegment_MidVecValueBorders, 3, subtotalColumnsList1, 9, "Total")

        WsMatrixCalc_DataRange = WsMatrixCalc.GetUsedRange()
        WsMatrixCalc_LastRowIndex = WsMatrixCalc_DataRange.BottomRowIndex

        dt.Reset()

        'Segment Risk x MidVec
        WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 3 & ":G" & WsMatrixCalc_LastRowIndex + 3))
        WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex + 3).Value = "Segment Risk x MidVec for " & rd
        cell = WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex + 3)
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 14
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        Dim WsMatrixCalc_cellA3Borders As DevExpress.Spreadsheet.Borders = cell.Borders
        WsMatrixCalc_cellA3Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        QueryText = "SELECT [RowNr]
                            ,[ColNr]
                            ,[FieldValue1] as SEGMENT_A
                            ,[FieldValue2] as SEGMENT_B
                            ,[FieldValue3] as Segment_Risk
                            ,[FieldValue6] as Segment_Correlation
                            ,[ResultFieldValue] as Segment_Risk_MidVec 
                            FROM [CreditSpreadRisk_MatrixCorrelationCalculations] 
                            where CalculationDescription in ('Calculation_Segment_Risk_MidVec') 
                            and [RiskDate]='" & rdsql & "' 
                            order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        WsMatrixCalc.Import(dt, True, WsMatrixCalc_LastRowIndex + 3, 0)

        Dim SegmentRisk_MidVecValue_DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            SegmentRisk_MidVecValue_DETAILS_LastRow = WsMatrixCalc_LastRowIndex + 3 + dt.Rows.Count + 2
        End If

        Dim SegmentRisk_MidVecValueRange As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":G" & SegmentRisk_MidVecValue_DETAILS_LastRow - 1)
        SegmentRisk_MidVecValueRange.Name = "SegmentRisk_MidVec"

        Dim SegmentRisk_MidVecValueBorders As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":G" & SegmentRisk_MidVecValue_DETAILS_LastRow - 1)
        SegmentRisk_MidVecValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim SegmentRisk_MidVecValueHeaders As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":G" & WsMatrixCalc_LastRowIndex + 4)
        SegmentRisk_MidVecValueHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim WsMatrixCalc_SegmentRisk_MidVecDataValues As CellRange = WsMatrixCalc.Range("E" & WsMatrixCalc_LastRowIndex + 4 & ":G" & SegmentRisk_MidVecValue_DETAILS_LastRow - 1)
        WsMatrixCalc_SegmentRisk_MidVecDataValues.NumberFormat = "#,##"

        Dim WsMatrixCalc_SegmentRisk_SegmentDataValues As CellRange = WsMatrixCalc.Range("F" & WsMatrixCalc_LastRowIndex + 4 & ":F" & SegmentRisk_MidVecValue_DETAILS_LastRow - 1)
        WsMatrixCalc_SegmentRisk_SegmentDataValues.NumberFormat = "0.00 %"

        Dim subtotalColumnsList2 As New List(Of Integer)()
        subtotalColumnsList2.Add(6) 'Subtotals claculated for column:G
        WsMatrixCalc.Subtotal(SegmentRisk_MidVecValueBorders, 2, subtotalColumnsList1, 9, "Total")

        WsMatrixCalc_DataRange = WsMatrixCalc.GetUsedRange()
        WsMatrixCalc_LastRowIndex = WsMatrixCalc_DataRange.BottomRowIndex

        dt.Reset()

        'Final Calculation
        WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 3 & ":D" & WsMatrixCalc_LastRowIndex + 3))
        WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex + 3).Value = "Final calculation for " & rd
        cell = WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex + 3)
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 14
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        Dim WsMatrixCalc_cellA4Borders As DevExpress.Spreadsheet.Borders = cell.Borders
        WsMatrixCalc_cellA4Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        QueryText = "SELECT [Segment]
                            ,[SegmentRisk]
                            ,[SegmentRisk_MidVec]
                            ,Produkt=0 
                            FROM [CreditSpreadRisk_Segments] 
                            where RiskDate='" & rdsql & "' 
                            order by Segment asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        WsMatrixCalc.Import(dt, True, WsMatrixCalc_LastRowIndex + 3, 0)

        Dim FinalCalculation_DETAILS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            FinalCalculation_DETAILS_LastRow = WsMatrixCalc_LastRowIndex + 3 + dt.Rows.Count + 2
        End If

        Dim FinalCalculationValueRange As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":D" & FinalCalculation_DETAILS_LastRow - 1)
        FinalCalculationValueRange.Name = "FinalCalculation"

        Dim FinalCalculationValueBorders As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":D" & FinalCalculation_DETAILS_LastRow - 1)
        FinalCalculationValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim FinalCalculationValueHeaders As CellRange = WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex + 4 & ":D" & WsMatrixCalc_LastRowIndex + 4)
        FinalCalculationValueHeaders.Fill.BackgroundColor = Color.LightBlue

        Dim WsMatrixCalc_FinalCalculation_MidVecDataValues As CellRange = WsMatrixCalc.Range("B" & WsMatrixCalc_LastRowIndex + 4 & ":D" & FinalCalculation_DETAILS_LastRow - 1)
        WsMatrixCalc_FinalCalculation_MidVecDataValues.NumberFormat = "#,##"

        Dim WsMatrixCalc_TotalRange As CellRange = WsMatrixCalc.Range("A1:AZ20000")
        WsMatrixCalc_TotalRange.AutoFitColumns()

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'Product Calculation
        Dim FinalProduct_Range As CellRange = WsMatrixCalc.Range("D" & WsMatrixCalc_LastRowIndex + 5 & ":D" & FinalCalculation_DETAILS_LastRow - 1)
        FinalProduct_Range.Formula = "=B" & WsMatrixCalc_LastRowIndex + 5 & "*C" & WsMatrixCalc_LastRowIndex + 5 & ""
        FinalProduct_Range.NumberFormat = "#,##"

        'Product Sum Calculation
        WsMatrixCalc.Cells("D" & FinalCalculation_DETAILS_LastRow & "").Formula = "=SUM(D" & WsMatrixCalc_LastRowIndex + 5 & ":D" & FinalCalculation_DETAILS_LastRow - 1 & ")"
        cell = WsMatrixCalc.Cells("D" & FinalCalculation_DETAILS_LastRow & "")
        cell.Font.Size = 11
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        cell.NumberFormat = "#,##"
        cell.Name = "SEGMENT_RISK_TOTAL"


        SplashScreenManager.Default.SetWaitFormCaption("Load results in Sheet:Results")
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'RESULT
        WsCalc.MergeCells(WsCalc.Range("A1:Q1"))
        WsCalc.Cells("A1").Value = "Portfolio Credit Spread Risk Calculation for " & rd
        cell = WsCalc.Cells("A1")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 14
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        Dim cellA1Borders As DevExpress.Spreadsheet.Borders = cell.Borders
        cellA1Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)


        WsCalc.MergeCells(WsCalc.Range("A2:C2"))
        WsCalc.Cells("A2").Value = "Securities Market Value (Sum)"
        cell = WsCalc.Cells("A2")
        cell.Fill.BackgroundColor = Color.LightBlue
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 12
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        WsCalc.MergeCells(WsCalc.Range("A3:C3"))


        WsCalc.MergeCells(WsCalc.Range("D2:G2"))
        WsCalc.Cells("D2").Value = "Segment Risk x MidVec (Total)"
        cell = WsCalc.Cells("D2")
        cell.Fill.BackgroundColor = Color.LightBlue
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 12
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        WsCalc.MergeCells(WsCalc.Range("D3:G3"))
        WsCalc.Cells("D3").Formula = "=MatrixCalculations!SEGMENT_RISK_TOTAL"
        WsCalc.Cells("D3").NumberFormat = "#,##"


        Dim RangeA2_D3 As CellRange = WsCalc.Range("A2:G3")
        RangeA2_D3.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)


        WsCalc.MergeCells(WsCalc.Range("H2:L2"))
        WsCalc.Cells("H2").Value = "Credit Spread Risk (Level1)"
        cell = WsCalc.Cells("H2")
        cell.Fill.BackgroundColor = Color.LightBlue
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 12
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold

        WsCalc.MergeCells(WsCalc.Range("H3:L3"))
        WsCalc.Cells("H3").Formula = "=SQRT(D3)"
        WsCalc.Cells("H3").NumberFormat = "#,##"

        WsCalc.MergeCells(WsCalc.Range("H4:L4"))
        WsCalc.Cells("H4").Value = "relative to portfolio market value"
        cell = WsCalc.Cells("H4")
        cell.Fill.BackgroundColor = Color.LightBlue
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 12
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold
        WsCalc.MergeCells(WsCalc.Range("H5:L5"))
        WsCalc.Cells("H5").Formula = "=H3/A3"
        WsCalc.Cells("H5").NumberFormat = "0.00 %"


        WsCalc.MergeCells(WsCalc.Range("M2:Q2"))
        WsCalc.Cells("M2").Value = "Credit Spread Risk (Level2)"
        cell = WsCalc.Cells("M2")
        cell.Fill.BackgroundColor = Color.LightBlue
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 12
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold

        WsCalc.MergeCells(WsCalc.Range("M3:Q3"))
        WsCalc.Cells("M3").Formula = "=H3*INDEX(Parameter!Scaling_Level_Parameters;2;4)/INDEX(Parameter!Scaling_Level_Parameters;1;4)"
        WsCalc.Cells("M3").NumberFormat = "#,##"

        WsCalc.MergeCells(WsCalc.Range("M4:Q4"))
        WsCalc.Cells("M4").Value = "relative to portfolio market value"
        cell = WsCalc.Cells("M4")
        cell.Fill.BackgroundColor = Color.LightBlue
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 12
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold

        WsCalc.MergeCells(WsCalc.Range("M5:Q5"))
        WsCalc.Cells("M5").Formula = "=M3/A3"
        WsCalc.Cells("M5").NumberFormat = "0.00 %"


        Dim RangeH2_Q5 As CellRange = WsCalc.Range("H2:Q5")
        RangeH2_Q5.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        'Load Bond Portfolio
        WsCalc.MergeCells(WsCalc.Range("A7:M7"))
        WsCalc.Cells("A7").Value = "Bond Portfolio on " & rd
        cell = WsCalc.Cells("A7")
        cell.Fill.BackgroundColor = Color.Yellow
        cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
        cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        cell.Font.Size = 11
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold


        QueryText = "SELECT [ISIN]
                        ,[EmmitentNr]
                        ,[SecurityName]
                        ,[Nominal]
                        ,[MarketValueEUR]
                        ,[ModifiedDuration]
                        ,[CS01]=0
                        ,[Segment]
                        ,[SpreadMovement]
                        ,[Curve_Type]
                        ,[SingleAssetRisk]=0
                        ,[K_Tenor]
                        ,[MidVec] 
                        FROM [CreditSpreadRisk_BondPortfolio] 
                        where RiskDate='" & rdsql & "' 
                        order by ID asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        WsCalc.Import(dt, True, 7, 0)

        Dim BondPortfolio_LastRow As Integer = 0

        If dt.Rows.Count > 0 Then
            BondPortfolio_LastRow = dt.Rows.Count + 2
        End If


        Dim BondPortfolioRangeBorders As CellRange = WsCalc.Range("A7:M" & BondPortfolio_LastRow + 6)
        BondPortfolioRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

        Dim BondPortfolioHeaders As CellRange = WsCalc.Range("A8:M8")
        BondPortfolioHeaders.Fill.BackgroundColor = Color.LightBlue

        'Market Value
        WsCalc.Cells("E" & BondPortfolio_LastRow + 7 & "").Formula = "=SUM(E9:E" & BondPortfolio_LastRow + 6 & ")"
        cell = WsCalc.Cells("E" & BondPortfolio_LastRow + 7 & "")
        cell.Font.Size = 11
        cell.Font.FontStyle = SpreadsheetFontStyle.Bold

        Dim BondPortfolioTotalRange As CellRange = WsCalc.Range("D9:E" & BondPortfolio_LastRow + 7)
        BondPortfolioTotalRange.NumberFormat = "#,##"

        Dim MidVecTotalRange As CellRange = WsCalc.Range("M9:M" & BondPortfolio_LastRow + 7)
        MidVecTotalRange.NumberFormat = "#,##"

        WsCalc.Cells("A3").Formula = "=E" & BondPortfolio_LastRow + 7 & ""
        WsCalc.Cells("A3").NumberFormat = "#,##"


        'CS Calculation
        Dim CS_Range As CellRange = WsCalc.Range("G9:G" & BondPortfolio_LastRow + 6)
        CS_Range.Formula = "=E9*F9*0,01%"
        CS_Range.NumberFormat = "#,##"

        'Single Asset Risk
        Dim SingleAssetRisk_Range As CellRange = WsCalc.Range("K9:K" & BondPortfolio_LastRow + 6)
        SingleAssetRisk_Range.Formula = "=G9*I9"
        SingleAssetRisk_Range.NumberFormat = "#,##"

        Dim WsCalc_TotalRange As CellRange = WsCalc.Range("A1:AZ20000")
        WsCalc_TotalRange.AutoFitColumns()





        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)




    End Sub

    Private Sub BgwExcelLoad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized

        c.Text = "Portfolio Credit Spread Risk for " & Me.BusinessDate_BarEditItem.EditValue.ToString
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.OpenXml)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ViewDetails_SwitchItem_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles ViewDetails_SwitchItem.CheckedChanged
        If Me.ViewDetails_SwitchItem.Checked = False Then
            Me.LayoutControl2.Visible = True
            Me.ViewDetails_SwitchItem.Caption = "Show Details"
            Me.Reload_bbi.PerformClick()
        ElseIf Me.ViewDetails_SwitchItem.Checked = True Then
            If IsDate(rd) = True Then
                rdsql = rd.ToString("yyyyMMdd")
                Me.CreditSpreadRisk_SingleAssetsCorrelationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_SingleAssetsCorrelation, rd)
                Me.CreditSpreadRisk_SegmentsTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_Segments, rd)
                Me.CreditSpreadRisk_SegmentRiskCalculationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_SegmentRiskCalculation, rd)
                Me.CreditSpreadRisk_PortfolioRiskCalculationTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_PortfolioRiskCalculation, rd)
                Me.CreditSpreadRisk_MatrixCorrelationCalculationsTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_MatrixCorrelationCalculations, rd)
                Me.CreditSpreadRisk_BondPortfolioTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_BondPortfolio, rd)
                Me.CreditSpreadRisk_TOTALSTableAdapter.FillByRiskDate(Me.CreditSpreadRiskDataSet.CreditSpreadRisk_TOTALS, rd)
                LOAD_Calculation_Single_Asset_MidVec()
                LOAD_Calculation_Single_Segment_MidVec()
                LOAD_Calculation_Segment_Risk_MidVec()
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

    Private Sub Calculation_Single_Segment_MidVec_GridView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles Calculation_Single_Segment_MidVec_GridView.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            Sum_Calculation_Segment_Risk_MidVec = 0
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            If summaryID = 1 Then
                Dim SumField As Double = CDbl(View.GetRowCellValue(e.RowHandle, "ResultFieldValue"))
                Sum_Calculation_Segment_Risk_MidVec += Convert.ToDecimal(e.FieldValue)
            End If
        End If
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 1 Then
                e.TotalValue = Math.Sqrt(Sum_Calculation_Segment_Risk_MidVec)
            End If
        End If

    End Sub

    Private Sub PivotGridControl1_CellDoubleClick(sender As Object, e As PivotCellEventArgs) Handles PivotGridControl1.CellDoubleClick
        Dim c As New DetailsPivot
        c.Text = "Pivot Cell Details"
        Try
            c.GridControl2.BeginUpdate()
            c.GridControl2.DataSource = e.CreateDrillDownDataSource()
            c.GridControl1.ForceInitialize()
            c.PivotDetailsBaseView.PopulateColumns()
            c.PivotDetailsBaseView.BestFitColumns()
            c.GridControl2.RefreshDataSource()



            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub PivotGridControl2_CellDoubleClick(sender As Object, e As PivotCellEventArgs) Handles PivotGridControl2.CellDoubleClick
        Dim c As New DetailsPivot
        c.Text = "Pivot Cell Details"
        Try
            c.GridControl2.BeginUpdate()
            c.GridControl2.DataSource = e.CreateDrillDownDataSource()
            c.GridControl1.ForceInitialize()
            c.PivotDetailsBaseView.PopulateColumns()
            c.PivotDetailsBaseView.BestFitColumns()
            c.GridControl2.RefreshDataSource()



            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub PivotGridControl3_CellDoubleClick(sender As Object, e As PivotCellEventArgs) Handles PivotGridControl3.CellDoubleClick
        Dim c As New DetailsPivot
        c.Text = "Pivot Cell Details"
        Try
            c.GridControl2.BeginUpdate()
            c.GridControl2.DataSource = e.CreateDrillDownDataSource()
            c.GridControl1.ForceInitialize()
            c.PivotDetailsBaseView.PopulateColumns()
            c.PivotDetailsBaseView.BestFitColumns()
            c.GridControl2.RefreshDataSource()


            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


End Class