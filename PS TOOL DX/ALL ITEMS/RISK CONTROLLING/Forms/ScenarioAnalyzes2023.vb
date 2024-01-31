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

Public Class ScenarioAnalyzes2023

    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim ActiveTabGroup As Boolean = False

    Friend WithEvents BgwExcel_UL_Load As BackgroundWorker
    Private bgws As New List(Of BackgroundWorker)()


    Private BS_BusinessDates As BindingSource
    Dim UL_DetailsViewCaption As String = Nothing
    Dim currentSqlcommandNr As Integer = 0

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


    Private Sub ScenarioAnalyzes2023_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LayoutControl1.Dock = DockStyle.Fill
        BUSINESS_DATES_initData()
        BUSINESS_DATES_InitLookUp()
        Me.BusinessDate_BarEditItem.EditValue = CType(BS_BusinessDates.Current, DataRowView).Item(0).ToString
        FILL_ALL_DATA()

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

    Private Sub Load_StressTestResults()
        QueryText = "SELECT * FROM [SCENARIO_ANALYZES_DATE]"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.StressTestResults_GridControl.DataSource = Nothing
        Me.StressTestResults_GridControl.DataSource = dt
        Me.StressTestResults_GridView.BestFitColumns()
        rd = CDate(dt.Rows.Item(0).Item("ScenarioAnalyzesDate").ToString)
        rdsql = rd.ToString("yyyyMMdd")
        Me.ScenarioDate_BarEditItem.EditValue = rd

    End Sub
    Private Sub Load_StressTestDate_OnRiskDate()
        'Bind Fields
        QueryText = "SELECT * FROM [ScenarioAnalyze_GeneralStressTest_Date] where [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.LGD_GST_SpinEdit.DataBindings.Clear()
        Me.Colleration_GST_SpinEdit.DataBindings.Clear()
        Me.ObligorRate_Mod_GST_SpinEdit.DataBindings.Clear()
        Me.LevelConfidence_General_SpinEdit.DataBindings.Clear()
        Me.GAMMAINV_TextEdit.DataBindings.Clear()
        Me.Delta_TextEdit.DataBindings.Clear()
        Me.K_Value_TextEdit.DataBindings.Clear()
        Me.SumGArel_TextEdit.DataBindings.Clear()

        Me.LGD_GST_SpinEdit.DataBindings.Add("EditValue", dt, "LGD_mod")
        Me.Colleration_GST_SpinEdit.DataBindings.Add("EditValue", dt, "R_Colleration_Mod")
        Me.ObligorRate_Mod_GST_SpinEdit.DataBindings.Add("EditValue", dt, "ObligorRate_Mod")
        Me.LevelConfidence_General_SpinEdit.DataBindings.Add("EditValue", dt, "LevelOfConfidence")
        Me.GAMMAINV_TextEdit.DataBindings.Add("Text", dt, "Gamma_inv")
        Me.Delta_TextEdit.DataBindings.Add("Text", dt, "Delta")
        Me.K_Value_TextEdit.DataBindings.Add("Text", dt, "K_Value")
        Me.SumGArel_TextEdit.DataBindings.Add("Text", dt, "SumGA_rel")


    End Sub
    Private Sub Load_GeneralStressTest_Totals_Details_OnRiskDate()

        'Create data adapters for retrieving data from the tables
        Dim UL_Totals_Adapter As New SqlDataAdapter("SELECT *
                                                     FROM [ScenarioAnalyze_GeneralStressTest_Totals]
                                                     where RiskDate='" & rdsql & "'", conn)
        Dim UL_Details_Adapter As New SqlDataAdapter("SELECT *
                                                      FROM [ScenarioAnalyze_GeneralStressTest_Details]
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
    Private Sub Load_GeneralStressTest_Details_OnRiskDate()
        QueryText = "SELECT *
                           FROM [ScenarioAnalyze_GeneralStressTest_Details]
                          where RiskDate='" & rdsql & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Me.UL_Details_GridControl.DataSource = Nothing
        Me.UL_Details_GridControl.DataSource = dt
        Me.UL_Details_GridView.BestFitColumns()
    End Sub

    Private Sub FILL_ALL_DATA()
        Load_StressTestResults()
        Load_StressTestDate_OnRiskDate()
        Load_GeneralStressTest_Totals_Details_OnRiskDate()
        Load_GeneralStressTest_Details_OnRiskDate()
    End Sub

    Private Sub BusinessDate_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessDate_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 2 Then
            If XtraMessageBox.Show("Should the production data for Business Date: " & Me.BusinessDate_BarEditItem.EditValue.ToString & " be loaded for the Stress scenario calculation?" & vbNewLine & vbNewLine & "ATTENTION! CURRENT ANALYSIS RESULTS WILL BE DELETED!", "PRODUCTION RESULTS DATA LOAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    rd = Me.BusinessDate_BarEditItem.EditValue.ToString
                    rdsql = rd.ToString("yyyyMMdd")
                    Me.ScenarioDate_BarEditItem.EditValue = rd
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Expected-Unexpected Loss and Granularity adjustment production data for: " & rd)
                    QueryText = "SELECT A.* from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B on A.Id_SQL_Parameters_Details=B.ID
                                INNER JOIN SQL_PARAMETER_DETAILS C on B.Id_SQL_Parameters_Details=C.ID
                                where B.SQL_Name_1 in ('STRESS_TEST_DATA_LOAD') and C.SQL_Name_1 in ('SCENARIO_ANALYZES')
                                and A.Status in ('Y') order by A.SQL_Float_1 asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        OpenSqlConnections()
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
                        CloseSqlConnections()
                    Else
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/SCENARIO_ANALYZES/STRESS_TEST_DATA_LOAD", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    FILL_ALL_DATA()
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    SplashScreenManager.CloseForm(False)
                    CloseSqlConnections()

                    Exit Sub
                End Try
            End If
        End If

    End Sub

    Private Sub Recalc_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Recalc_bbi.ItemClick

        If XtraMessageBox.Show("Should the Scenario Analyis for Business Date: " & CDate(Me.ScenarioDate_BarEditItem.EditValue.ToString) & " be executed?" & vbNewLine & vbNewLine & "ATTENTION! ALL SCENARIO ANALYSIS RESULTS WILL BE DELETED!", "EXECUTE SCENARIO ANALYSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                rd = Me.ScenarioDate_BarEditItem.EditValue.ToString
                rdsql = rd.ToString("yyyyMMdd")
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'Update Parameters for each Scenario
                OpenSqlConnections()
                SplashScreenManager.Default.SetWaitFormCaption("Update Parameters for each Scenario")
                cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Date] set [LGD_mod]=@LGD_mod, [R_Colleration_Mod]=@R_Colleration_Mod
                                         ,[ObligorRate_Mod]=@ObligorRate_Mod,LevelOfConfidence=@LevelOfConfidence
                                         ,[SumEL]=0,[SumUL]=0,[SumGA_rel]=0,[SumGA_Total]=0,DefaultRisk=0 where RiskDate='" & rdsql & "'"
                cmd.Parameters.Add("@LGD_mod", SqlDbType.Float).Value = Me.LGD_GST_SpinEdit.EditValue
                cmd.Parameters.Add("@R_Colleration_Mod", SqlDbType.Float).Value = Me.Colleration_GST_SpinEdit.EditValue
                cmd.Parameters.Add("@ObligorRate_Mod", SqlDbType.Float).Value = Me.ObligorRate_Mod_GST_SpinEdit.EditValue
                cmd.Parameters.Add("@LevelOfConfidence", SqlDbType.Float).Value = Me.LevelConfidence_General_SpinEdit.EditValue
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                CloseSqlConnections()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Calculate Expected-Unexpected Loss and Granularity adjustment" & vbNewLine & "stress test data for: " & rd)
                QueryText = "SELECT A.* from [SQL_PARAMETER_DETAILS_THIRD] A INNER JOIN SQL_PARAMETER_DETAILS_SECOND B on A.Id_SQL_Parameters_Details=B.ID
                                INNER JOIN SQL_PARAMETER_DETAILS C on B.Id_SQL_Parameters_Details=C.ID
                                where B.SQL_Name_1 in ('STRESS_TEST_DATA_CALCULATION') and C.SQL_Name_1 in ('SCENARIO_ANALYZES')
                                and A.Status in ('Y') order by A.SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    OpenSqlConnections()
                    For s = 0 To dt.Rows.Count - 1
                        ScriptType = dt.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                        If ScriptType = "SQL" Then
                            SqlCommandText = dt.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                            currentSqlcommandNr = CInt(dt.Rows.Item(s).Item("SQL_Float_1").ToString)
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
                    CloseSqlConnections()
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("There are no parameters in SEVERAL SELECTIONS/SCENARIO_ANALYZES/STRESS_TEST_DATA_LOAD", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                FILL_ALL_DATA()
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message & vbNewLine & "Current SQL Parameter Nr." & currentSqlcommandNr, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                FILL_ALL_DATA()
                Exit Sub
            End Try
        End If


    End Sub

    Private Sub BusinessDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles BusinessDate_BarEditItem.EditValueChanged


        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'SplashScreenManager.Default.SetWaitFormCaption("Load Expected, Unexpected Loss and Granularity Approach Data for: " & rd)
        'FILL_ALL_DATA()
        'SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub ScenarioDate_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles ScenarioDate_BarEditItem.EditValueChanged

        'rd = Me.BusinessDate_BarEditItem.EditValue.ToString
        'rdsql = rd.ToString("yyyyMMdd")
    End Sub


    Private Sub bbi_Close_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbi_Close.ItemClick
        Me.Close()
    End Sub

#Region "CHANGE_DEFAULT_VALUES"
    Private Sub LGD_GST_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LGD_GST_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the LGD Multiplicator default value for General Stress Test  be changed to " & Me.LGD_GST_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLGDmultiplicator As Double = Me.LGD_GST_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] drop constraint [DF_ScenarioAnalyze_GeneralStressTest_Date_LGD_mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] add constraint [DF_ScenarioAnalyze_GeneralStressTest_Date_LGD_mod] default (" & Str(DefaultValueLGDmultiplicator) & ") for [LGD_mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("LGD Multiplicator default value for General Stress Test has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub Colleration_GST_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Colleration_GST_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Colleration increase default value for General Stress Test  be changed to " & Me.Colleration_GST_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueCollerationIncrease As Double = Me.Colleration_GST_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] drop constraint [DF_ScenarioAnalyze_GeneralStressTest_Date_R_Colleration_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] add constraint [DF_ScenarioAnalyze_GeneralStressTest_Date_R_Colleration_Mod] default (" & Str(DefaultValueCollerationIncrease) & ") for [R_Colleration_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Colleration increase default value for General Stress Test has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub ObligorRate_Mod_GST_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ObligorRate_Mod_GST_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Obligor rate notches default value for General Stress Test  be changed to " & Me.ObligorRate_Mod_GST_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueObligorRateNotches As Double = Me.ObligorRate_Mod_GST_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] drop constraint [DF_ScenarioAnalyze_GeneralStressTest_Date_PD_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] add constraint [DF_ScenarioAnalyze_GeneralStressTest_Date_PD_Mod] default (" & Str(DefaultValueObligorRateNotches) & ") for [ObligorRate_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Obligor rate notches default value for General Stress Test has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

#End Region

#Region "GRIDVIEW STYLES and PRINT-EXPORT"

    Private Sub Print_Export_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Print_Export_bbi.ItemClick

        If Not LayoutControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink_SingleDate.CreateDocument()
        PrintableComponentLink_SingleDate.ShowPreview()
        SplashScreenManager.CloseForm(False)


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
        Dim reportfooter As String = "General Stress Test" & "  " & "for Business Date: " & CDate(Me.ScenarioDate_BarEditItem.EditValue.ToString)
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



#End Region



    Private Sub UL_Data_Excel_BarbuttonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UL_Data_Excel_BarbuttonItem.ItemClick
        XtraMessageBox.SmartTextWrap = True
        If XtraMessageBox.Show("Should the current stress test data for the Expected-Unexpected Loss and Granularity adjustment be loaded to Excel file with formulas?", "LOAD DATA TO EXCEL FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for " & CDate(Me.ScenarioDate_BarEditItem.EditValue.ToString))

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
            rd = Me.ScenarioDate_BarEditItem.EditValue.ToString
            rdsql = rd.ToString("yyyyMMdd")
            '***********************************************************************
            '*******EXCEL FILES DIRECTORY************
            '+++++++++++++++++++++++++++++++++++++++++++++++++++
            OpenSqlConnections()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_STRESS_TEST_GENERAL' 
                                and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' 
                                and IdABTEILUNGSCODE_NAME='EDP'  
                                and [PARAMETER STATUS]='Y'"
            ExcelFileName = cmd.ExecuteScalar
            '***********************************************************************
            CloseSqlConnections()

            QueryText = "Select  * from [SQL_PARAMETER_DETAILS_SECOND] where Id_SQL_Parameters_Details 
                     in (Select ID from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('GeneralStressTest_EL_UL_GA_ExcelFile_creation') 
                    and  Id_SQL_Parameters in ('EXCEL_FILES_CREATION'))"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                OpenSqlConnections()
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
                CloseSqlConnections()
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("There are no parameters in EXCEL_FILE_CREATION/GeneralStressTest_EL_UL_GA_ExcelFile_creation", "No parameters found", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            c.Text = "General Stress Test - Expected,Unexpected Loss and Granularity adjustment for " & CDate(Me.ScenarioDate_BarEditItem.EditValue.ToString)
            c.SpreadsheetControl1.ReadOnly = True

            workbook = c.SpreadsheetControl1.Document
            Using stream As New FileStream(ExcelFileName, FileMode.Open)
                workbook.LoadDocument(stream, DocumentFormat.OpenXml)
            End Using

            'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)
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