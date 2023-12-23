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

Public Class UnexpectedLossCalc2023

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Boolean = False

    Friend WithEvents BgwExcel_UL_Load As BackgroundWorker
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

    Private Sub UnexpectedLossCalc2023_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Me.LayoutControl2.Visible = False Then
                Me.ViewDetails_SwitchItem.Checked = False
                Me.LayoutControl2.Visible = True
                Load_UL_Totals()
            End If

        End If
    End Sub

    Private Sub UnexpectedLossCalc2023_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LayoutControl2.Dock = DockStyle.Fill
        Me.LayoutControl1.Dock = DockStyle.Fill
        Load_UL_Totals()
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()

    End Sub

    Private Sub BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("Select CONVERT(VARCHAR(10),[RiskDate],104) as 'BusinessDate' from [UNEXPECTED_LOSS_DATE] ORDER BY [RiskDate] desc", conn)
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

    Private Sub Load_UL_Totals()
        QueryText = "SELECT * FROM [UNEXPECTED_LOSS_DATE] ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.UL_AllDates_GridControl.DataSource = Nothing
        Me.UL_AllDates_GridControl.DataSource = dt
        Me.UL_AllDates_GridView.BestFitColumns()

    End Sub


    Private Sub Load_UL_Totals_Details_OnRiskDate()
        'Bind Fields
        QueryText = "SELECT * FROM [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.LevelOfConfidence_SpinEdit.DataBindings.Clear()
        Me.nu_Value_SpinEdit.DataBindings.Clear()
        Me.p_alpha_value_SpinEdit.DataBindings.Clear()
        Me.b_beta_value_SpinEdit.DataBindings.Clear()
        Me.GAMMAINV_TextEdit.DataBindings.Clear()
        Me.Delta_TextEdit.DataBindings.Clear()
        Me.K_Value_TextEdit.DataBindings.Clear()
        Me.SumGArel_TextEdit.DataBindings.Clear()
        Me.EL_TextEdit.DataBindings.Clear()
        Me.UL_TextEdit.DataBindings.Clear()
        Me.GA_TextEdit.DataBindings.Clear()

        Me.LevelOfConfidence_SpinEdit.DataBindings.Add("EditValue", dt, "LevelOfConfidence")
        Me.nu_Value_SpinEdit.DataBindings.Add("EditValue", dt, "nu_Value")
        Me.p_alpha_value_SpinEdit.DataBindings.Add("EditValue", dt, "p_alpha_Value")
        Me.b_beta_value_SpinEdit.DataBindings.Add("EditValue", dt, "b_beta_value")
        Me.GAMMAINV_TextEdit.DataBindings.Add("Text", dt, "Gamma_inv")
        Me.Delta_TextEdit.DataBindings.Add("Text", dt, "Delta")
        Me.K_Value_TextEdit.DataBindings.Add("Text", dt, "K_Value")
        Me.SumGArel_TextEdit.DataBindings.Add("Text", dt, "SumGA_rel")
        Me.EL_TextEdit.DataBindings.Add("Text", dt, "SumEL")
        Me.UL_TextEdit.DataBindings.Add("Text", dt, "SumUL")
        Me.GA_TextEdit.DataBindings.Add("Text", dt, "SumGA_Total")


        'Create data adapters for retrieving data from the tables
        Dim UL_Totals_Adapter As New SqlDataAdapter("SELECT *
                                                     FROM [UNEXPECTED_LOSS]
                                                     where RiskDate='" & rdsql & "'", conn)
        Dim UL_Details_Adapter As New SqlDataAdapter("SELECT *
                                                      FROM [UNEXPECTED_LOSS_Details]
                                                      where RiskDate='" & rdsql & "'", conn)

        Dim UL_DataSet As New DataSet()
        'Create DataTable objects for representing database's tables
        UL_Totals_Adapter.Fill(UL_DataSet, "UNEXPECTED_LOSS")
        UL_Details_Adapter.Fill(UL_DataSet, "UNEXPECTED_LOSS_Details")

        'Set up a master-detail relationship between the DataTables
        Dim keyColumn As DataColumn = UL_DataSet.Tables("UNEXPECTED_LOSS").Columns("ClientGroup")
        Dim foreignKeyColumn As DataColumn = UL_DataSet.Tables("UNEXPECTED_LOSS_Details").Columns("ClientGroup")
        UL_DataSet.Relations.Add("UNEXPECTED_LOSS_Details", keyColumn, foreignKeyColumn)

        'Bind the grid control to the data source
        Me.UL_Totals_GridControl.DataSource = UL_DataSet.Tables("UNEXPECTED_LOSS")
        Me.UL_Totals_GridControl.ForceInitialize()
        Me.UL_Totals_GridControl.LevelTree.Nodes.Add("UNEXPECTED_LOSS_Details", Me.UL_Totals_Details_GridView)
        'Me.CR_INTERNAL_TOTALS_BandedGridView.BestFitColumns()
        Me.UL_Totals_Details_GridView.BestFitColumns()

    End Sub
    Private Sub Load_UL_Details_OnRiskDate()
        QueryText = "SELECT *
                           FROM [UNEXPECTED_LOSS_Details]
                          where RiskDate='" & rdsql & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.UL_Details_GridControl.DataSource = Nothing
        Me.UL_Details_GridControl.DataSource = dt
        Me.UL_Details_GridView.BestFitColumns()
    End Sub


    Private Sub FILL_ALL_DATA()
        Load_UL_Totals_Details_OnRiskDate()
        Load_UL_Details_OnRiskDate()
    End Sub

    Private Sub Reload_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Reload_bbi.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Loading all Business Dates")
        Load_UL_Totals()
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
            If Not UL_AllDates_GridControl.IsPrintingAvailable Then
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
        Dim reportfooter As String = "Currency Risks"
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
        Dim reportfooter As String = "Currency Risk" & "  " & "for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



#End Region

#Region "RESET UL PARAMETERS"
    Private Sub LevelOfConfidence_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelOfConfidence_SpinEdit.ButtonClick
        'Level Of Confidence
        If e.Button.Tag = "ChangeStandardValue" Then
            If XtraMessageBox.Show("Should the LEVEL OF CONFIDENCE default value be changed to " & Me.LevelOfConfidence_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelOfConfidence As Double = Me.LevelOfConfidence_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPTECTED_LOSS_DATE_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPTECTED_LOSS_DATE_LevelOfConfidence] default (" & Str(DefaultValueLevelOfConfidence) & ") for [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("LEVEL OF CONFIDENCE default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If


    End Sub

    Private Sub nu_Value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles nu_Value_SpinEdit.ButtonClick
        If e.Button.Tag = "nuChangeStandardValue" Then
            If XtraMessageBox.Show("Should the nu default value be changed to " & Me.nu_Value_SpinEdit.Text, "CHANGE NU DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueNU As Double = Me.nu_Value_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPECTED_LOSS_DATE_nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPECTED_LOSS_DATE_nu_Value] default (" & Str(DefaultValueNU) & ") for [nu_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("NU default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub p_alpha_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles p_alpha_value_SpinEdit.ButtonClick
        If e.Button.Tag = "pAlphaChangeStandardValue" Then
            If XtraMessageBox.Show("Should the p Alpha default value be changed to " & Me.p_alpha_value_SpinEdit.Text, "CHANGE P ALPHA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuepAlpha As Double = Me.p_alpha_value_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPECTED_LOSS_DATE_p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPECTED_LOSS_DATE_p_alpha_Value] default (" & Str(DefaultValuepAlpha) & ") for [p_alpha_Value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("p Alpha default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub b_beta_value_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles b_beta_value_SpinEdit.ButtonClick
        If e.Button.Tag = "bBetaChangeStandardValue" Then
            If XtraMessageBox.Show("Should the b Beta default value be changed to " & Me.b_beta_value_SpinEdit.Text, "CHANGE B BETA DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValuebBeta As Double = Me.b_beta_value_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] drop constraint [DF_UNEXPECTED_LOSS_DATE_b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [UNEXPECTED_LOSS_DATE] add constraint [DF_UNEXPECTED_LOSS_DATE_b_beta_value] default (" & Str(DefaultValuebBeta) & ") for [b_beta_value]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    XtraMessageBox.Show("b Beta default value has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub
#End Region

    Private Sub UL_AllDates_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles UL_AllDates_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
        End If
    End Sub

    Private Sub UL_AllDates_GridView_DoubleClick(sender As Object, e As EventArgs) Handles UL_AllDates_GridView.DoubleClick
        Dim view As GridView = DirectCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            rd = view.GetFocusedRowCellValue("RiskDate")
            rdsql = rd.ToString("yyyyMMdd")
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Expected, Unexpected Loss and Granularity Approach Data for: " & rd)
            Me.BusinessDate_BarEditItem.EditValue = rd.ToString("dd.MM.yyyy")
            FILL_ALL_DATA()
            Me.LayoutControl2.Visible = False
            Me.ViewDetails_SwitchItem.Checked = True
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub UL_Data_Excel_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UL_Data_Excel_BarbuttonItem.ItemClick
        XtraMessageBox.SmartTextWrap = True
        If XtraMessageBox.Show("Should the current data for the Expected-Unexpected Loss and Granularity Approach be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & Me.BusinessDate_BarEditItem.EditValue.ToString)

                BgwExcel_UL_Load = New BackgroundWorker
                BgwExcel_UL_Load.WorkerReportsProgress = True
                BgwExcel_UL_Load.RunWorkerAsync()
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        End If

    End Sub

    Private Sub BgwExcel_CR_Load_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcel_UL_Load.DoWork

        Try
            rd = Me.BusinessDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_EL_UL_GA' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('ExpectedUnexpectedGA_ExcelFile_creation') 
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
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/ExpectedUnexpectedGA_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            BgwExcel_UL_Load.CancelAsync()
        End Try



    End Sub

    Private Sub BgwExcel_CR_Load_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcel_UL_Load.RunWorkerCompleted
        If e.Cancelled = False Then
            Dim c As New ExcelForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "Expected-Unexpected Loss and Granularity Approach for " & Me.BusinessDate_BarEditItem.EditValue.ToString
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
            SplashScreenManager.Default.SetWaitFormCaption("Load Expected-Unexpected Loss and Granularity Approach Data for: " & rd)
            FILL_ALL_DATA()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub



    Private Sub UL_Totals_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles UL_Totals_GridView.MasterRowExpanded
        If Me.UL_Totals_GridControl.FocusedView.Name = "UL_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            UL_DetailsViewCaption = "Details for Client Group: " & view.GetFocusedRowCellValue("ClientGroup").ToString & " - " & view.GetFocusedRowCellValue("ClientGroupName").ToString
            Me.UL_Totals_Details_GridView.ViewCaption = UL_DetailsViewCaption
            Me.UL_Totals_Details_GridView.BestFitColumns()
        End If
    End Sub

    Private Sub UL_Totals_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles UL_Totals_GridView.MasterRowExpanding
        If Me.UL_Totals_GridControl.FocusedView.Name = "UL_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            UL_DetailsViewCaption = "Details for Client Group: " & view.GetFocusedRowCellValue("ClientGroup").ToString & " - " & view.GetFocusedRowCellValue("ClientGroupName").ToString
            Me.UL_Totals_Details_GridView.ViewCaption = UL_DetailsViewCaption
            Me.UL_Totals_Details_GridView.BestFitColumns()
        End If
    End Sub
End Class