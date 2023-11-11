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
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RiskDate],104) as 'BusinessDate' from [CreditSpreadRisk_TOTALS] ORDER BY [RiskDate] desc", conn)
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
        If XtraMessageBox.Show("Should the current data be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
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
        End If

    End Sub

    Private Sub BgwExcelLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad.DoWork

        Try
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_CREDIT_SPREAD_RISK' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('PortfolioCreditSpreadRisk_ExcelFile_creation') 
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
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/PortfolioCreditSpreadRisk_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            BgwExcelLoad.CancelAsync()
        End Try


    End Sub

    Private Sub BgwExcelLoad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad.RunWorkerCompleted
        If e.Cancelled = False Then
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