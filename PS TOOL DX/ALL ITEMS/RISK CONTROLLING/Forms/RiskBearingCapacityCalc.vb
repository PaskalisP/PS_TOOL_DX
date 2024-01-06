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

Public Class RiskBearingCapacityCalc

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Boolean = False

    Friend WithEvents BgwExcel_RBC_Load As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()


    Private BS_BusinessDates As BindingSource
    Dim UL_DetailsViewCaption As String = Nothing

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

    Private Sub RiskBearingCapacityCalc_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.LayoutControl2.Visible = False Then
                Me.ViewDetails_SwitchItem.Checked = False
                Me.LayoutControl2.Visible = True
                Me.RISK_BEARING_CAPACITY_DATESTableAdapter.Fill(Me.RiskBearingCapacityDataSet.RISK_BEARING_CAPACITY_DATES)
            End If

        End If
    End Sub

    Private Sub RiskBearingCapacityCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.RISK_BEARING_CAPACITY_DATESTableAdapter.Fill(Me.RiskBearingCapacityDataSet.RISK_BEARING_CAPACITY_DATES)

        Me.LayoutControl2.Dock = DockStyle.Fill
        Me.LayoutControl1.Dock = DockStyle.Fill
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()

    End Sub

    Private Sub BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RiskDate],104) as 'BusinessDate' from [RISK_BEARING_CAPACITY_DATES] ORDER BY [RiskDate] desc", conn)
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

    Private Sub SAVE_CHANGES()
        If Me.RiskBearingCapacityDataSet.HasChanges = True Then
            If XtraMessageBox.Show("Should the changes  be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    rd = Me.BusinessDate_BarEditItem.EditValue.ToString
                    rdsql = rd.ToString("yyyyMMdd")
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Updating Data for Risk Bearing Capacity")
                    Me.Validate()
                    Me.RISK_BEARING_CAPACITY_CALCULATIONSBindingSource.EndEdit()
                    OpenSqlConnections()
                    'cmd.CommandText = "ALTER TABLE RISK_BEARING_CAPACITY_DATES ENABLE TRIGGER [AuditRISK_BEARING_CAPACITY_DATES]"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "ALTER TABLE RISK_BEARING_CAPACITY_CALCULATIONS ENABLE TRIGGER [AuditRISK_BEARING_CAPACITY_CALCULATIONS]"
                    'cmd.ExecuteNonQuery()
                    Me.TableAdapterManager.UpdateAll(Me.RiskBearingCapacityDataSet)
                    QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('RISK_BEARING_CAPACITY_CALCULATION_Manual') 
                    and  Id_SQL_Parameters in ('SEVERAL SELECTIONS'))"
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
                        XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/RISK_BEARING_CAPACITY_CALCULATION_Manual", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    cmd.CommandText = "ALTER TABLE RISK_BEARING_CAPACITY_DATES DISABLE TRIGGER [AuditRISK_BEARING_CAPACITY_DATES]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE RISK_BEARING_CAPACITY_CALCULATIONS DISABLE TRIGGER [AuditRISK_BEARING_CAPACITY_CALCULATIONS]"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    FILL_ALL_DATA()
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            Else
                Me.RISK_BEARING_CAPACITY_CALCULATIONSBindingSource.CancelEdit()
            End If
        End If
    End Sub

    Private Sub RBC_NP_DETAILS()
        QueryText = "SELECT * FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where RBC_Type in ('NP') and RiskDate='" & rdsql & "' and RBC_Row_Nr<=8 
                     order by RBC_Row_Nr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.RBC_NP_Details_GridControl.DataSource = Nothing
        Me.RBC_NP_Details_GridControl.DataSource = dt
        Me.RBC_NP_Details_GridView.BestFitColumns()
    End Sub

    Private Sub RBC_NP_KEYS_DETAILS()
        QueryText = "SELECT * FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where RBC_Type in ('NP') and RiskDate='" & rdsql & "' and RBC_Row_Nr>=10 
                     order by RBC_Row_Nr asc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.RBC_NP_KeyRatios_GridControl.DataSource = Nothing
        Me.RBC_NP_KeyRatios_GridControl.DataSource = dt
        Me.RBC_NP_KeyRatios_GridView.BestFitColumns()
    End Sub

    Private Sub RBC_DATE()
        QueryText = "SELECT * FROM [RISK_BEARING_CAPACITY_DATES] where RiskDate='" & rdsql & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.RBC_Date_GridControl.DataSource = Nothing
        Me.RBC_Date_GridControl.DataSource = dt
        Me.RBC_Date_GridView.BestFitColumns()
    End Sub

    Private Sub FILL_ALL_DATA()
        Me.RISK_BEARING_CAPACITY_DATESTableAdapter.FillByRiskDate(Me.RiskBearingCapacityDataSet.RISK_BEARING_CAPACITY_DATES, rd)
        Me.RISK_BEARING_CAPACITY_CALCULATIONSTableAdapter.FillByRiskDate(Me.RiskBearingCapacityDataSet.RISK_BEARING_CAPACITY_CALCULATIONS, rd)
        RBC_NP_DETAILS()
        RBC_NP_KEYS_DETAILS()
    End Sub

    Private Sub Reload_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Reload_bbi.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Loading all Business Dates")
        Me.RISK_BEARING_CAPACITY_DATESTableAdapter.Fill(Me.RiskBearingCapacityDataSet.RISK_BEARING_CAPACITY_DATES)
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()
        SplashScreenManager.CloseForm(False)



    End Sub

    Private Sub BusinessDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessDate_BarEditItem.EditValueChanged
        If Me.LayoutControl2.Visible = False Then
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Expected, Unexpected Loss and Granularity Approach Data for: " & rd)
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
            If Not RBC_AllDates_GridControl.IsPrintingAvailable Then
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
        Dim reportfooter As String = "Risk Bearing Capacities"
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
        Dim reportfooter As String = "Risk Bearing Capacity" & "  " & "for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



#End Region



    Private Sub RBC_AllDates_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles RBC_AllDates_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
        End If
    End Sub

    Private Sub RBC_AllDates_GridView_DoubleClick(sender As Object, e As EventArgs) Handles RBC_AllDates_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Risk Bearing Capacity calculation Data for: " & rd)
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
            FILL_ALL_DATA()
            Me.LayoutControl2.Visible = False
            Me.ViewDetails_SwitchItem.Checked = True
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RBC_Data_Excel_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RBC_Data_Excel_BarbuttonItem.ItemClick
        XtraMessageBox.SmartTextWrap = True
        If XtraMessageBox.Show("Should the current data for the Risk Bearing Capacity be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.BusinessDate_BarEditItem.EditValue.ToString)

                BgwExcel_RBC_Load = New BackgroundWorker
                BgwExcel_RBC_Load.WorkerReportsProgress = True
                BgwExcel_RBC_Load.RunWorkerAsync()
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        End If

    End Sub

#Region "REPORTS"
    Private Sub RBC_EP_Rep_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RBC_EP_Rep_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Risk Bearing Capacity - Economic Perspective Report for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString)
        rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim RBC_DATE_Da As New SqlDataAdapter("Select * from [RISK_BEARING_CAPACITY_DATES] where RiskDate='" & rdsql & "' ", conn)
        Dim RBC_CALC_Da As New SqlDataAdapter("Select * from [RISK_BEARING_CAPACITY_CALCULATIONS] where RiskDate='" & rdsql & "' ORDER BY RBC_Row_Nr asc", conn)

        Dim RBC_Dataset As New DataSet("RBC")
        RBC_DATE_Da.Fill(RBC_Dataset, "RBC_DATE")
        RBC_CALC_Da.Fill(RBC_Dataset, "RBC_CALC")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\RBC_EconomicPerspective.rpt")
        'Dim r As New INT_RATE_RISK_BC_REP
        CrRep.SetDataSource(RBC_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "RISK BEARING CAPACITY - Economic Perspective on " & rd
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(90)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub RBC_NP_Rep_BarButtonItem_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles RBC_NP_Rep_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Risk Bearing Capacity - Normative Perspective Report for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString)
        rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        rdsql = rd.ToString("yyyyMMdd")
        Dim RBC_DATE_Da As New SqlDataAdapter("Select * from [RISK_BEARING_CAPACITY_DATES] where RiskDate='" & rdsql & "' ", conn)
        Dim RBC_CALC_Da As New SqlDataAdapter("Select * from [RISK_BEARING_CAPACITY_CALCULATIONS] where RiskDate='" & rdsql & "' ORDER BY RBC_Row_Nr asc", conn)

        Dim RBC_Dataset As New DataSet("RBC")
        RBC_DATE_Da.Fill(RBC_Dataset, "RBC_DATE")
        RBC_CALC_Da.Fill(RBC_Dataset, "RBC_CALC")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\RBC_NormativePerspective.rpt")
        'Dim r As New INT_RATE_RISK_BC_REP
        CrRep.SetDataSource(RBC_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = rd
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "RISK BEARING CAPACITY - Normative Perspective on " & rd
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(90)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BgwExcel_RBC_Load_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcel_RBC_Load.DoWork

        Try
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_RISK_BEARING_CAPACITY' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('RiskBearingCapacity_ExcelFile_creation') 
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
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/RiskBearingCapacity_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            BgwExcel_RBC_Load.CancelAsync()
        End Try



    End Sub

    Private Sub BgwExcel_RBC_Load_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcel_RBC_Load.RunWorkerCompleted
        If e.Cancelled = False Then
            Dim c As New ExcelForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "Risk Bearing Capacity for " & Me.BusinessDate_BarEditItem.EditValue.ToString
            c.SpreadsheetControl1.ReadOnly = True

            workbook = c.SpreadsheetControl1.Document
            Using stream As New FileStream(ExcelFileName, FileMode.Open)
                workbook.LoadDocument(stream, DocumentFormat.OpenXml)
            End Using

            'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

#End Region

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
            SplashScreenManager.Default.SetWaitFormCaption("Load Risk Bearing Capacity calculation Data for: " & rd)
            FILL_ALL_DATA()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISK_BEARING_CAPACITY_DATESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.RISK_BEARING_CAPACITY_DATESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskBearingCapacityDataSet)

    End Sub



    Private Sub RBC_Details_GridView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles RBC_Details_GridView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
    End Sub

    Private Sub RBC_Details_GridView_EditFormHidden(sender As Object, e As EditFormHiddenEventArgs) Handles RBC_Details_GridView.EditFormHidden
        If Me.RiskBearingCapacityDataSet.HasChanges = True Then
            SAVE_CHANGES()
        End If
    End Sub


End Class