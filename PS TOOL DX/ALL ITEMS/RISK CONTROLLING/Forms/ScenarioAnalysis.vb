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
Imports DevExpress.SpreadsheetSource


Public Class ScenarioAnalysis

    Dim CrystalRepDir As String = ""

    Dim excel As Microsoft.Office.Interop.Excel.Application
    Dim instance As Microsoft.Office.Interop.Excel.WorksheetFunction

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable


    Dim ExcelFileName As String = Nothing

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet

    Dim GeneralStressTestsDetailsViewCaption As String = Nothing
    Dim ConcentrationRiskCHINAViewCaption As String = Nothing
    Dim ConcentrationRiskFIViewCaption As String = Nothing

    Friend WithEvents BgwExcelLoad_General As BackgroundWorker
    Friend WithEvents BgwExcelLoad_CN As BackgroundWorker
    Friend WithEvents BgwExcelLoad_FI As BackgroundWorker


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

    Private Sub SCENARIO_ANALYZES_DATEBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SCENARIO_ANALYZES_DATEBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ScenarioAnalysisDataset)

    End Sub

    Private Sub ScenarioAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        OpenSqlConnections()
        CrystalRepDir = cmd.ExecuteScalar
        CloseSqlConnections()
        '***********************************************************************
        'Bind Combobox

        Me.AnalysisDate_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RiskDate' from [UNEXPECTED_LOSS_DATE] ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.AnalysisDate_Comboedit.Properties.Items.Add(row("RiskDate"))
            End If
        Next
        'If dt.Rows.Count > 0 Then
        'Me.AnalysisDate_Comboedit.Text = dt.Rows.Item(0).Item("RiskDate")
        'End If

        LOAD_ANALYSIS_DATA()



    End Sub

    Private Sub LOAD_ANALYSIS_DATA()
        Me.ScenarioAnalyze_GeneralStressTest_DetailsALLTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_DetailsALL)
        Me.ScenarioAnalyze_GeneralStressTest_DetailsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_Details)
        Me.ScenarioAnalyze_GeneralStressTest_TotalsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_Totals)
        Me.ScenarioAnalyze_GeneralStressTest_DateTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_Date)
        Me.ScenarioAnalyze_ConcentrationRiskCHINA_DetailsALLTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_DetailsALL)
        Me.ScenarioAnalyze_ConcentrationRiskCHINA_DetailsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_Details)
        Me.ScenarioAnalyze_ConcentrationRiskCHINA_TotalsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_Totals)
        Me.ScenarioAnalyze_ConcentrationRiskCHINA_DateTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_Date)
        Me.ScenarioAnalyze_ConcentrationRiskTBA_DetailsAllTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_DetailsAll)
        Me.ScenarioAnalyze_ConcentrationRiskTBA_DetailsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_Details)
        Me.ScenarioAnalyze_ConcentrationRiskTBA_TotalsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_Totals)
        Me.ScenarioAnalyze_ConcentrationRiskTBA_DateTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_Date)
        Me.SCENARIO_ANALYZES_DATETableAdapter.Fill(Me.ScenarioAnalysisDataset.SCENARIO_ANALYZES_DATE)
    End Sub

    Private Sub LoadData_btn_Click(sender As Object, e As EventArgs) Handles LoadData_btn.Click
        If IsDate(Me.AnalysisDate_Comboedit.Text) = True Then
            If MessageBox.Show("Should the Data for " & Me.AnalysisDate_Comboedit.Text & " be loaded?" & vbNewLine & vbNewLine & "ATTENTION! ALL SCENARIO ANALYSIS RESULTS WILL BE DELETED!", "DATA LOAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    rd = Me.AnalysisDate_Comboedit.Text
                    rdsql = rd.ToString("yyyyMMdd")

                    OpenSqlConnections()
                    cmd.CommandTimeout = 5000
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete all current Data in SCENARIO ANALYZES")
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskCHINA_Details]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskTBA_Details]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_GeneralStressTest_Details]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_GeneralStressTest_Totals]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskCHINA_Date]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskTBA_Date]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [ScenarioAnalyze_GeneralStressTest_Date]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE from [SCENARIO_ANALYZES_DATE]"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Import Data from UNEXPECTED LOSS Table")
                    cmd.CommandText = "INSERT INTO [ScenarioAnalyze_GeneralStressTest_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '
                    cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskCHINA_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "' and [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [RiskCountry] in ('CN'))"
                    cmd.ExecuteNonQuery()
                    '
                    cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskTBA_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "' and [ClientGroup] not in ('1000') and [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('F - FINANCIAL'))"
                    cmd.ExecuteNonQuery()
                    '
                    SplashScreenManager.Default.SetWaitFormCaption("Set as Scenario Analysis date " & rd)
                    cmd.CommandText = "INSERT INTO [SCENARIO_ANALYZES_DATE]([ScenarioAnalyzesDate])VALUES('" & rdsql & "')"
                    cmd.ExecuteNonQuery()
                    'Insert Live Results
                    cmd.CommandText = "UPDATE [SCENARIO_ANALYZES_DATE] SET [SumEL_Live]=(Select [SumEL] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'),[SumUL_Live]=(Select [SumUL] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'),[SumGA_Live]=(Select [SumGA_Total] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskCHINA_Date]([RiskDate],[IdDate])Select [ScenarioAnalyzesDate],[ID] from [SCENARIO_ANALYZES_DATE]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskTBA_Date]([RiskDate],[IdDate])Select [ScenarioAnalyzesDate],[ID] from [SCENARIO_ANALYZES_DATE]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ScenarioAnalyze_GeneralStressTest_Date]([RiskDate],[IdDate])Select [ScenarioAnalyzesDate],[ID] from [SCENARIO_ANALYZES_DATE]"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    SplashScreenManager.Default.SetWaitFormCaption("Load Scenario Analysis date " & rd)
                    'Load all data
                    Me.ScenarioAnalyze_GeneralStressTest_DetailsALLTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_DetailsALL)
                    Me.ScenarioAnalyze_GeneralStressTest_DetailsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_Details)
                    Me.ScenarioAnalyze_GeneralStressTest_DateTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_GeneralStressTest_Date)
                    Me.ScenarioAnalyze_ConcentrationRiskCHINA_DetailsALLTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_DetailsALL)
                    Me.ScenarioAnalyze_ConcentrationRiskCHINA_DetailsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_Details)
                    Me.ScenarioAnalyze_ConcentrationRiskCHINA_DateTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskCHINA_Date)
                    Me.ScenarioAnalyze_ConcentrationRiskTBA_DetailsAllTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_DetailsAll)
                    Me.ScenarioAnalyze_ConcentrationRiskTBA_DetailsTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_Details)
                    Me.ScenarioAnalyze_ConcentrationRiskTBA_DateTableAdapter.Fill(Me.ScenarioAnalysisDataset.ScenarioAnalyze_ConcentrationRiskTBA_Date)
                    Me.SCENARIO_ANALYZES_DATETableAdapter.Fill(Me.ScenarioAnalysisDataset.SCENARIO_ANALYZES_DATE)

                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    SplashScreenManager.CloseForm(False)
                    CloseSqlConnections()

                    Exit Sub
                End Try
            End If
        End If
    End Sub



    Private Sub ScenarioAnalysisDate_lbl_TextChanged(sender As Object, e As EventArgs) Handles ScenarioAnalysisDate_lbl.TextChanged
        If Me.ScenarioAnalysisDate_lbl.Text <> "" Then
            Me.ExecuteScenarioAnalysis_btn.Visible = True
        Else
            Me.ExecuteScenarioAnalysis_btn.Visible = False
        End If
    End Sub

    Private Sub ExecuteScenarioAnalysis_btn_Click(sender As Object, e As EventArgs) Handles ExecuteScenarioAnalysis_btn.Click
        If MessageBox.Show("Should the Scenario Analyis for " & Me.ScenarioAnalysisDate_lbl.Text & " be executed?" & vbNewLine & vbNewLine & "ATTENTION! ALL SCENARIO ANALYSIS RESULTS WILL BE DELETED!", "EXECUTE SCENARIO ANALYSIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                rd = Me.ScenarioAnalysisDate_lbl.Text
                rdsql = rd.ToString("yyyyMMdd")

                Me.Validate()
                Me.SCENARIO_ANALYZES_DATEBindingSource.EndEdit()
                'Me.ScenarioAnalyze_GeneralStressTest_DateBindingSource.EndEdit()
                'Me.ScenarioAnalyze_ConcentrationRiskCHINA_DateBindingSource.EndEdit()
                'Me.ScenarioAnalyze_ConcentrationRiskTBA_DateBindingSource.EndEdit()

                'Me.TableAdapterManager.UpdateAll(Me.ScenarioAnalysisDataset)


                OpenSqlConnections()
                cmd.CommandTimeout = 5000
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'Update Parameters for each Scenario
                SplashScreenManager.Default.SetWaitFormCaption("Update Parameters for each Scenario")
                cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Date] set [LGD_mod]=@LGD_mod, [R_Colleration_Mod]=@R_Colleration_Mod,[ObligorRate_Mod]=@ObligorRate_Mod,LevelOfConfidence=@LevelOfConfidence,[SumEL]=0,[SumUL]=0,[SumGA_rel]=0,[SumGA_Total]=0"
                cmd.Parameters.Add("@LGD_mod", SqlDbType.Float).Value = Me.LGD_GST_SpinEdit.EditValue
                cmd.Parameters.Add("@R_Colleration_Mod", SqlDbType.Float).Value = Me.Colleration_GST_SpinEdit.EditValue
                cmd.Parameters.Add("@ObligorRate_Mod", SqlDbType.Float).Value = Me.ObligorRate_Mod_GST_SpinEdit.EditValue
                cmd.Parameters.Add("@LevelOfConfidence", SqlDbType.Float).Value = Me.LevelConfidence_General_SpinEdit.EditValue
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] set [LGD_mod]=@LGD_mod, [R_Colleration_Mod]=@R_Colleration_Mod,[ObligorRate_Mod]=@ObligorRate_Mod,LevelOfConfidence=@LevelOfConfidence ,[SumEL]=0,[SumUL]=0,[SumGA_rel]=0,[SumGA_Total]=0"
                cmd.Parameters.Add("@LGD_mod", SqlDbType.Float).Value = Me.LGD_CHINA_SpinEdit.EditValue
                cmd.Parameters.Add("@R_Colleration_Mod", SqlDbType.Float).Value = Me.Colleration_CHINA_SpinEdit.EditValue
                cmd.Parameters.Add("@ObligorRate_Mod", SqlDbType.Float).Value = Me.ObligorRate_Mod_CHINA_SpinEdit.EditValue
                cmd.Parameters.Add("@LevelOfConfidence", SqlDbType.Float).Value = Me.LevelConfidence_China_SpinEdit.EditValue
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Date] set [LGD_mod]=@LGD_mod, [R_Colleration_Mod]=@R_Colleration_Mod,[ObligorRate_Mod]=@ObligorRate_Mod ,LevelOfConfidence=@LevelOfConfidence ,[SumEL]=0,[SumUL]=0,[SumGA_rel]=0,[SumGA_Total]=0"
                cmd.Parameters.Add("@LGD_mod", SqlDbType.Float).Value = Me.LGD_FI_SpinEdit.EditValue
                cmd.Parameters.Add("@R_Colleration_Mod", SqlDbType.Float).Value = Me.Colleration_FI_SpinEdit.EditValue
                cmd.Parameters.Add("@ObligorRate_Mod", SqlDbType.Float).Value = Me.ObligorRate_Mod_FI_SpinEdit.EditValue
                cmd.Parameters.Add("@LevelOfConfidence", SqlDbType.Float).Value = Me.LevelConfidence_Financial_SpinEdit.EditValue
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                SplashScreenManager.Default.SetWaitFormCaption("Delete all relevant Data in SCENARIO ANALYZES for " & rd)
                cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskCHINA_Details]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskTBA_Details]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [ScenarioAnalyze_GeneralStressTest_Details]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [ScenarioAnalyze_GeneralStressTest_Totals]"
                cmd.ExecuteNonQuery()

                SplashScreenManager.Default.SetWaitFormCaption("Import Data from UNEXPECTED LOSS Table for " & rd)
                cmd.CommandText = "INSERT INTO [ScenarioAnalyze_GeneralStressTest_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                '
                cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskCHINA_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "' and [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [RiskCountry] in ('CN'))"
                cmd.ExecuteNonQuery()
                '
                cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskTBA_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "' and [ClientGroup] not in ('1000') and [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('F - FINANCIAL'))"
                cmd.ExecuteNonQuery()
                '
                SplashScreenManager.Default.SetWaitFormCaption("Execute Scenario Analysis for " & rd)


                GENERAL_STRESS_TEST()
                CONCENTRATION_RISK_CHINA()
                CONCENTRATION_RISK_FI()



                CloseSqlConnections()

                LOAD_ANALYSIS_DATA()
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                MessageBox.Show(ex.Message & vbNewLine & ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()

                Exit Sub
            End Try
        End If
    End Sub

    Private Sub GENERAL_STRESS_TEST()
        SplashScreenManager.Default.SetWaitFormCaption("Execute Scenario Analysis for General Stress Test")
        'GENERAL STRESS TEST-EXPECTED LOSS
        SplashScreenManager.Default.SetWaitFormCaption("Modify Obligor Rate for General Stress Test based on the Obligor Rate notches")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Details] set [Obligor Rate]=Convert(float,[Obligor Rate]) + (Select [ObligorRate_Mod] from [ScenarioAnalyze_GeneralStressTest_Date])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Details] set [Obligor Rate]='19' where Convert(float,[Obligor Rate])>19"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update PD for General Stress Test based on the new Obligor Rate")
        cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[CoreDefinition]=B.[CoreDefinition] FROM [ScenarioAnalyze_GeneralStressTest_Details] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update LGD for General Stress Test based on the LGD Multiplier")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Details] set [(1-ER_45)]=[(1-ER_45)]* (Select [LGD_mod] from [ScenarioAnalyze_GeneralStressTest_Date])"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate Expected Loss for General Stress Test")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Details] SET [CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update Expected Loss for General Stress Test in ScenarioAnalyze_GeneralStressTest_Date")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Date] SET [SumEL]=(Select Sum([NetCreditRiskAmountEUREquER45]) from [ScenarioAnalyze_GeneralStressTest_Details])"
        cmd.ExecuteNonQuery()
        'GENERAL STRESS TEST-UNEXPECTED LOSS
        SplashScreenManager.Default.SetWaitFormCaption("Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted for General Stress Tests")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Details] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Delete previus Data in ScenarioAnalyze_GeneralStressTest_Totals for General Stress Tests")
        cmd.CommandText = "DELETE FROM [ScenarioAnalyze_GeneralStressTest_Totals]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Insert Data to ScenarioAnalyze_GeneralStressTest_Totals for General Stress Tests")
        cmd.CommandText = "INSERT INTO [ScenarioAnalyze_GeneralStressTest_Totals]([ClientGroup],[RiskDate]) SELECT [ClientGroup],[RiskDate] from [ScenarioAnalyze_GeneralStressTest_Details] GROUP BY [ClientGroup],[RiskDate]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [ScenarioAnalyze_GeneralStressTest_Totals] A INNER JOIN [ScenarioAnalyze_GeneralStressTest_Details] B ON A.[ClientGroup]=B.[ClientGroup]"
        cmd.ExecuteNonQuery()



        SplashScreenManager.Default.SetWaitFormCaption("Update [IdDate] in ScenarioAnalyze_GeneralStressTest_Totals for General Stress Tests")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [IdDate]=(Select [ID] from [ScenarioAnalyze_GeneralStressTest_Date])"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update IdClientGroup in ScenarioAnalyze_GeneralStressTest_Details for General Stress Tests ")
        cmd.CommandText = "UPDATE A set A.[IdClientGroup]=B.[ID] from [ScenarioAnalyze_GeneralStressTest_Details] A INNER JOIN [ScenarioAnalyze_GeneralStressTest_Totals] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update SubBorrowersCounter in ScenarioAnalyze_GeneralStressTest_Totals for General Stress Tests")
        cmd.CommandText = "UPDATE A SET A.[SubBorrowersCounter]=B.S from [ScenarioAnalyze_GeneralStressTest_Totals] A INNER JOIN (Select [ClientGroup],Count([IdClientGroup]) as S from [ScenarioAnalyze_GeneralStressTest_Details] GROUP BY [ClientGroup]) B on A.[ClientGroup]=B.[ClientGroup]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update FinalEadTotalSum,LGD,PD_EaD_weigthed in ScenarioAnalyze_GeneralStressTest_Totals Table from ScenarioAnalyze_GeneralStressTest_Details")
        Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroup] from [ScenarioAnalyze_GeneralStressTest_Details] GROUP BY [ClientGroup]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
            If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            End If
            Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
            cmd.CommandText = "Select [FinalEadTotalSum] from [ScenarioAnalyze_GeneralStressTest_Totals] where [ClientGroup]='" & ClientGroup & "' "
            Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
            Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
            Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
            If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            End If
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update PD_3bps_floor in ScenarioAnalyze_GeneralStressTest_Totals")
        Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [ScenarioAnalyze_GeneralStressTest_Totals] GROUP BY [ClientGroup],[PD_EaD_weighted]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim PD_EaD_weighted As Double = dt.Rows.Item(i).Item("PD_EaD_weighted")
            Dim CheckNumber As Double = 0.0003
            Dim MaxNumber As Double = 0
            'Get PD_3bps_floor
            If PD_EaD_weighted > CheckNumber Then
                MaxNumber = PD_EaD_weighted
            Else
                MaxNumber = CheckNumber
            End If
            Dim SecondNumber As Double = 0
            If PD_EaD_weighted = 0 Then
                SecondNumber = 0
            Else
                SecondNumber = 1
            End If
            Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
            'Get IndicatorOfFloor
            Dim IndicatorOfFloor As Double = 0
            Dim difference As Double = PD_3bps_floor - PD_EaD_weighted

            If difference > 0 Then
                IndicatorOfFloor = 1
            Else
                IndicatorOfFloor = 0
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where  [ClientGroup]='" & ClientGroup & "'"
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update MaturityEADweigthed in ScenarioAnalyze_GeneralStressTest_Totals")
        Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroup] from [ScenarioAnalyze_GeneralStressTest_Details]  Where  [PD]<>0  GROUP BY [ClientGroup]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
            cmd.CommandText = "Select [FinalEadTotalSum] from [ScenarioAnalyze_GeneralStressTest_Totals] where [ClientGroup]='" & ClientGroup & "'"
            Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
            Dim Variable1 As Double = SumEaDweigthedMaturityWithoutCapFloor / FinalEadTotalSum
            Dim CheckNumber As Double = 5
            Dim Variable2 As Double = 0
            If Variable1 > 5 Then
                Variable2 = 5
            Else
                Variable2 = Variable1
            End If
            Dim Variable3 As Double = 0
            If Variable2 > 1 Then
                Variable3 = Variable2
            Else
                Variable3 = 1
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "'"
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update R_CoefficientOfColleration and b_MaturityAdjustment in ScenarioAnalyze_GeneralStressTest_Totals")
        Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [ScenarioAnalyze_GeneralStressTest_Totals]  GROUP BY [ClientGroup],[PD_3bps_floor]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
            If PD = 0 Then
                PD = 1
            End If
            Dim PDminus As Double = PD * (-50)
            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where   [ClientGroup]='" & ClientGroup & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [ClientGroup]='" & ClientGroup & "' "
            cmd.ExecuteNonQuery()
            'Set b_MaturityAdjustment to 0 if NULL
            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [b_MaturityAdjustment]=0 where  [b_MaturityAdjustment] is NULL"
            cmd.ExecuteNonQuery()
        Next
        'INCREASE CORRELATION
        SplashScreenManager.Default.SetWaitFormCaption("Increase R_CoefficientOfColleration in ScenarioAnalyze_GeneralStressTest_Totals according to Parameter")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [R_CoefficientOfColleration]=[R_CoefficientOfColleration]*(Select Case when [R_Colleration_Mod]<>0 then [R_Colleration_Mod] else 0 end  from [ScenarioAnalyze_GeneralStressTest_Date])+[R_CoefficientOfColleration]"
        cmd.ExecuteNonQuery()
        'Get LevelOfConfidence from ScenarioAnalyze_GeneralStressTest_Date
        SplashScreenManager.Default.SetWaitFormCaption("Get LEVEL OF CONFIDENCE fromScenarioAnalyze_GeneralStressTest_Date")
        cmd.CommandText = "Select [LevelOfConfidence] from [ScenarioAnalyze_GeneralStressTest_Date]"
        Dim LevelOfConfidence As Double = cmd.ExecuteScalar
        SplashScreenManager.Default.SetWaitFormCaption("Update RW_RiskWeightedExposure and UL_UnexpectedLoss in ScenarioAnalyze_GeneralStressTest_Totals")
        Me.QueryText = "Select * from [ScenarioAnalyze_GeneralStressTest_Totals]  Where [b_MaturityAdjustment]<>0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
            Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
            Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
            If PD = 0 Then
                PD = 1
            End If
            Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
            Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
            'Check if PD<>1 then execute Formula otherwise if PD=1 then it goes to error
            If PD <> 1 Then
                'Get First Part of Formula
                cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [ScenarioAnalyze_GeneralStressTest_Totals] where [ID]='" & ID & "' "
                Dim FirstPartFormulaRW = cmd.ExecuteScalar
                'Get Second Part of Formula
                cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [ScenarioAnalyze_GeneralStressTest_Totals] where [ID]='" & ID & "'"
                Dim SecondPartFormulaRW = cmd.ExecuteScalar
                Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            ElseIf PD = 1 Then
                cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [RW_RiskWeightedExposure]=0 where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            End If
            'Calculate Unexpected Loss
            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update Sum Unexpected Loss in ScenarioAnalyze_GeneralStressTest_Date")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Date] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [ScenarioAnalyze_GeneralStressTest_Totals])"
        cmd.ExecuteNonQuery()
        'GENERAL STRESS TEST-GRANULARITY APPROACH
        SplashScreenManager.Default.SetWaitFormCaption("Start GRANULARITY APPROACH Calculation")
        SplashScreenManager.Default.SetWaitFormCaption("Calculate s_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Totals] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [ScenarioAnalyze_GeneralStressTest_Totals]),10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate K_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Totals] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate R_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Totals] set [R_i]=Round([LGD]*[PD_3bps_floor],10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate VLGD_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Totals] set [VLGD_i]=Round((select nu_Value from [ScenarioAnalyze_GeneralStressTest_Date])*[LGD]*(1-[LGD]),10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate C_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Totals] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [LGD]<>0"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate GAMMAINV")
        Me.QueryText = "Select * from [ScenarioAnalyze_GeneralStressTest_Date]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Dim p_alpha_Value As Double = dt.Rows.Item(0).Item("p_alpha_Value")
        Dim b_beta_Value As Double = dt.Rows.Item(0).Item("b_beta_value")
        Dim ConfidenceLevelUL As Double = dt.Rows.Item(0).Item("LevelOfConfidence")
        Dim b_beta_Value_Calculated As Double = 1 / b_beta_Value

        'excel = New Microsoft.Office.Interop.Excel.Application
        'instance = excel.WorksheetFunction

        'Dim GAMMA_INV As Double = Math.Round(instance.GammaInv(ConfidenceLevelUL, p_alpha_Value, b_beta_Value_Calculated), 10)

        'Excel Instanz beenden
        'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
        'Dim i1 As Short
        'i1 = 0
        'For i1 = 0 To (procs.Length - 1)
        'procs(i1).Kill()
        'Next i1

        Dim workbook As New DevExpress.Spreadsheet.Workbook()
        Dim worksheets As WorksheetCollection = workbook.Worksheets
        Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets(0)

        worksheet.Range("A1").NumberFormat = "#0.00"
        worksheet.Range("A2").NumberFormat = "#0.00"
        worksheet.Range("A3").NumberFormat = "#0.00"
        worksheet.Range("A4").NumberFormat = "#0.0000000000"
        worksheet.Range("A1").Value = ConfidenceLevelUL
        worksheet.Range("A2").Value = p_alpha_Value
        worksheet.Range("A3").Value = b_beta_Value_Calculated
        worksheet.Range("A4").Formula = "=ROUND(GAMMAINV(A1;A2;A3);10)"
        Dim GAMMA_INV As Double = worksheet.Range("A4").Value.NumericValue

        SplashScreenManager.Default.SetWaitFormCaption("Calculate DELTA Value")
        Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
        SplashScreenManager.Default.SetWaitFormCaption("Update DELTA Value and GAMMAINV")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Date] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & ""
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert K_Value")
        cmd.CommandText = "Update [ScenarioAnalyze_GeneralStressTest_Date] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [ScenarioAnalyze_GeneralStressTest_Totals])"
        cmd.ExecuteNonQuery()

        Dim s_i As Decimal = 0
        Dim C_i As Decimal = 0
        Dim K_i As Decimal = 0
        Dim R_i As Decimal = 0
        Dim LGD_i As Decimal = 0
        Dim VLGD_i As Decimal = 0
        Dim CALCULATION_1 As Decimal = 0
        Dim CALCULATION_2 As Decimal = 0
        Dim CALCULATION_3 As Decimal = 0
        Dim TOTAL_CALCULATION As Decimal = 0

        SplashScreenManager.Default.SetWaitFormCaption("Calculate GA_n Value")
        Me.QueryText = "Select * from [ScenarioAnalyze_GeneralStressTest_Totals]  Where [LGD]<>0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim IDNR As Double = dt.Rows.Item(i).Item("ID")
            s_i = dt.Rows.Item(i).Item("s_i")
            C_i = dt.Rows.Item(i).Item("C_i")
            K_i = dt.Rows.Item(i).Item("K_i")
            R_i = dt.Rows.Item(i).Item("R_i")
            LGD_i = dt.Rows.Item(i).Item("LGD")
            VLGD_i = dt.Rows.Item(i).Item("VLGD_i")
            Dim DELTA_VALUE_R As Decimal = Math.Round(DELTA_VALUE, 9)

            Dim PowerS_i As Decimal = Math.Round(s_i ^ 2, 12)
            Dim Calculation_A As Decimal = Math.Round(DELTA_VALUE_R * C_i * (K_i + R_i), 12)
            Dim Calculation_B As Decimal = Math.Round(DELTA_VALUE_R * (K_i + R_i) ^ 2, 12)
            Dim PowerVLGD As Decimal = VLGD_i ^ 2
            Dim PowerLGD As Decimal = LGD_i ^ 2
            Dim Calculation_C As Decimal = Math.Round(PowerVLGD / PowerLGD, 12)
            Dim Calculation_D As Decimal = Calculation_A + Calculation_B * Calculation_C

            CALCULATION_1 = Math.Round(Calculation_D, 12)
            CALCULATION_2 = Math.Round(K_i * (C_i + 2 * (K_i + R_i) * Calculation_C), 12)
            CALCULATION_3 = CALCULATION_1 - CALCULATION_2

            TOTAL_CALCULATION = Math.Round(PowerS_i * CALCULATION_3, 12)

            cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Totals] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_rel Value")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Date] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [ScenarioAnalyze_GeneralStressTest_Date]),10) from [ScenarioAnalyze_GeneralStressTest_Totals])"
        cmd.ExecuteNonQuery()

        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_Total Value")
        cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [ScenarioAnalyze_GeneralStressTest_Totals]"
        Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
        cmd.CommandText = "Select [SumGA_rel] from [ScenarioAnalyze_GeneralStressTest_Date]"
        Dim SummeGArel As Double = cmd.ExecuteScalar
        Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
        cmd.CommandText = "UPDATE [ScenarioAnalyze_GeneralStressTest_Date] SET [SumGA_Total]='" & Str(SummeGA_Total) & "'"
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub CONCENTRATION_RISK_CHINA()
        SplashScreenManager.Default.SetWaitFormCaption("Execute Scenario Analysis for Concentration Risk CHINA")
        'CONCENTRATION RISK CHINA-EXPECTED LOSS
        SplashScreenManager.Default.SetWaitFormCaption("Modify Obligor Rate for Concentration Risk CHINA based on the Obligor Rate notches")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Details] set [Obligor Rate]=Convert(float,[Obligor Rate]) + (Select [ObligorRate_Mod] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Details] set [Obligor Rate]='19' where Convert(float,[Obligor Rate])>19"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update PD for Concentration Risk CHINA based on the new Obligor Rate")
        cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[CoreDefinition]=B.[CoreDefinition] FROM [ScenarioAnalyze_ConcentrationRiskCHINA_Details] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update LGD for Concentration Risk CHINA based on the LGD Multiplier")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Details] set [(1-ER_45)]=[(1-ER_45)]* (Select [LGD_mod] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date])"
        cmd.ExecuteNonQuery()
        'Insert Customers with Country of RISK not CHINA (Rest Customers)
        SplashScreenManager.Default.SetWaitFormCaption("Insert the rest of the Customers(Country of Risk IS NOT China)")
        cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskCHINA_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "' and [Client No] not in (Select [ClientNo] from [CUSTOMER_INFO] where [RiskCountry] in ('CN'))"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate Expected Loss for Concentration Risk CHINA")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Details] SET [CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update Expected Loss for Concentration Risk CHINA in ScenarioAnalyze_GeneralStressTest_Date")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] SET [SumEL]=(Select Sum([NetCreditRiskAmountEUREquER45]) from [ScenarioAnalyze_ConcentrationRiskCHINA_Details])"
        cmd.ExecuteNonQuery()
        'CONCENTRATION RISK CHINA-UNEXPECTED LOSS
        SplashScreenManager.Default.SetWaitFormCaption("Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted for Concentration Risk CHINA")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Details] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Delete previus Data in ScenarioAnalyze_GeneralStressTest_Totals for Concentration Risk CHINA")
        cmd.CommandText = "DELETE FROM [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Insert Data to ScenarioAnalyze_GeneralStressTest_Totals for Concentration Risk CHINA")
        cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]([ClientGroup],[RiskDate]) SELECT [ClientGroup],[RiskDate] from [ScenarioAnalyze_ConcentrationRiskCHINA_Details] GROUP BY [ClientGroup],[RiskDate]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] A INNER JOIN [ScenarioAnalyze_ConcentrationRiskCHINA_Details] B ON A.[ClientGroup]=B.[ClientGroup]"
        cmd.ExecuteNonQuery()


        SplashScreenManager.Default.SetWaitFormCaption("Update [IdDate] in ScenarioAnalyze_GeneralStressTest_Totals for Concentration Risk CHINA")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [IdDate]=(Select [ID] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date])"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update IdClientGroup in ScenarioAnalyze_GeneralStressTest_Details for Concentration Risk CHINA ")
        cmd.CommandText = "UPDATE A set A.[IdClientGroup]=B.[ID] from [ScenarioAnalyze_ConcentrationRiskCHINA_Details] A INNER JOIN [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update SubBorrowersCounter in ScenarioAnalyze_GeneralStressTest_Totals for Concentration Risk CHINA")
        cmd.CommandText = "UPDATE A SET A.[SubBorrowersCounter]=B.S from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] A INNER JOIN (Select [ClientGroup],Count([IdClientGroup]) as S from [ScenarioAnalyze_ConcentrationRiskCHINA_Details] GROUP BY [ClientGroup]) B on A.[ClientGroup]=B.[ClientGroup]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update FinalEadTotalSum,LGD,PD_EaD_weigthed in ScenarioAnalyze_ConcentrationRiskCHINA_Totals Table from ScenarioAnalyze_ConcentrationRiskCHINA_Details")
        Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskCHINA_Details] where [PD]<>0 GROUP BY [ClientGroup]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
            If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            End If
            Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
            cmd.CommandText = "Select [FinalEadTotalSum] from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] where [ClientGroup]='" & ClientGroup & "' "
            Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
            Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
            Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
            If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            End If
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update PD_3bps_floor in ScenarioAnalyze_ConcentrationRiskCHINA_Totals")
        Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] GROUP BY [ClientGroup],[PD_EaD_weighted]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim PD_EaD_weighted As Double = dt.Rows.Item(i).Item("PD_EaD_weighted")
            Dim CheckNumber As Double = 0.0003
            Dim MaxNumber As Double = 0
            'Get PD_3bps_floor
            If PD_EaD_weighted > CheckNumber Then
                MaxNumber = PD_EaD_weighted
            Else
                MaxNumber = CheckNumber
            End If
            Dim SecondNumber As Double = 0
            If PD_EaD_weighted = 0 Then
                SecondNumber = 0
            Else
                SecondNumber = 1
            End If
            Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
            'Get IndicatorOfFloor
            Dim IndicatorOfFloor As Double = 0
            Dim difference As Double = PD_3bps_floor - PD_EaD_weighted

            If difference > 0 Then
                IndicatorOfFloor = 1
            Else
                IndicatorOfFloor = 0
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where  [ClientGroup]='" & ClientGroup & "'"
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update MaturityEADweigthed in ScenarioAnalyze_ConcentrationRiskCHINA_Totals")
        Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskCHINA_Details]  Where  [PD]<>0  GROUP BY [ClientGroup]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
            cmd.CommandText = "Select [FinalEadTotalSum] from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] where [ClientGroup]='" & ClientGroup & "'"
            Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
            Dim Variable1 As Double = SumEaDweigthedMaturityWithoutCapFloor / FinalEadTotalSum
            Dim CheckNumber As Double = 5
            Dim Variable2 As Double = 0
            If Variable1 > 5 Then
                Variable2 = 5
            Else
                Variable2 = Variable1
            End If
            Dim Variable3 As Double = 0
            If Variable2 > 1 Then
                Variable3 = Variable2
            Else
                Variable3 = 1
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "'"
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update R_CoefficientOfColleration and b_MaturityAdjustment in ScenarioAnalyze_ConcentrationRiskCHINA_Totals")
        Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]  GROUP BY [ClientGroup],[PD_3bps_floor]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
            If PD = 0 Then
                PD = 1
            End If
            Dim PDminus As Double = PD * (-50)
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where   [ClientGroup]='" & ClientGroup & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [ClientGroup]='" & ClientGroup & "' "
            cmd.ExecuteNonQuery()
            'Set b_MaturityAdjustment to 0 if NULL
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [b_MaturityAdjustment]=0 where  [b_MaturityAdjustment] is NULL"
            cmd.ExecuteNonQuery()
        Next
        'INCREASE CORRELATION
        SplashScreenManager.Default.SetWaitFormCaption("Increase R_CoefficientOfColleration (Only for Country of Risk=CHINA) in ScenarioAnalyze_ConcentrationRiskCHINA_Totals according to Parameter")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [R_CoefficientOfColleration]=[R_CoefficientOfColleration]*(Select Case when [R_Colleration_Mod]<>0 then [R_Colleration_Mod] else 0 end from [ScenarioAnalyze_ConcentrationRiskCHINA_Date])+[R_CoefficientOfColleration] where [ClientGroup] in (Select [ClientGroup] from [ScenarioAnalyze_ConcentrationRiskCHINA_Details] where [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [RiskCountry] in ('CN')))"
        cmd.ExecuteNonQuery()
        'Get LevelOfConfidence from ScenarioAnalyze_GeneralStressTest_Date
        SplashScreenManager.Default.SetWaitFormCaption("Get LEVEL OF CONFIDENCE from ScenarioAnalyze_ConcentrationRiskCHINA_Date")
        cmd.CommandText = "Select [LevelOfConfidence] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date]"
        Dim LevelOfConfidence As Double = cmd.ExecuteScalar
        SplashScreenManager.Default.SetWaitFormCaption("Update RW_RiskWeightedExposure and UL_UnexpectedLoss in ScenarioAnalyze_ConcentrationRiskCHINA_Totals")
        Me.QueryText = "Select * from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]  Where [b_MaturityAdjustment]<>0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
            Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
            Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
            If PD = 0 Then
                PD = 1
            End If
            Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
            Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
            'Check if PD<>1 then execute Formula otherwise if PD=1 then it goes to error
            If PD <> 1 Then
                'Get First Part of Formula
                cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] where [ID]='" & ID & "' "
                Dim FirstPartFormulaRW = cmd.ExecuteScalar
                'Get Second Part of Formula
                cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] where [ID]='" & ID & "'"
                Dim SecondPartFormulaRW = cmd.ExecuteScalar
                Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            ElseIf PD = 1 Then
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [RW_RiskWeightedExposure]=0 where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update Sum Unexpected Loss in ScenarioAnalyze_ConcentrationRiskCHINA_Date")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals])"
        cmd.ExecuteNonQuery()
        'CONCENTRATION RISK CHINA-GRANULARITY APPROACH
        SplashScreenManager.Default.SetWaitFormCaption("Start GRANULARITY APPROACH Calculation")
        SplashScreenManager.Default.SetWaitFormCaption("Calculate s_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]),10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate K_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate R_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] set [R_i]=Round([LGD]*[PD_3bps_floor],10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate VLGD_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] set [VLGD_i]=Round((select nu_Value from [ScenarioAnalyze_ConcentrationRiskCHINA_Date])*[LGD]*(1-[LGD]),10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate C_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [LGD]<>0"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate GAMMAINV")
        Me.QueryText = "Select * from [ScenarioAnalyze_ConcentrationRiskCHINA_Date]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Dim p_alpha_Value As Double = dt.Rows.Item(0).Item("p_alpha_Value")
        Dim b_beta_Value As Double = dt.Rows.Item(0).Item("b_beta_value")
        Dim ConfidenceLevelUL As Double = dt.Rows.Item(0).Item("LevelOfConfidence")
        Dim b_beta_Value_Calculated As Double = 1 / b_beta_Value

        'excel = New Microsoft.Office.Interop.Excel.Application
        'instance = excel.WorksheetFunction

        'Dim GAMMA_INV As Double = Math.Round(instance.GammaInv(ConfidenceLevelUL, p_alpha_Value, b_beta_Value_Calculated), 10)

        'Excel Instanz beenden
        'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
        'Dim i1 As Short
        'i1 = 0
        'For i1 = 0 To (procs.Length - 1)
        'procs(i1).Kill()
        'Next i1

        Dim workbook As New DevExpress.Spreadsheet.Workbook()
        Dim worksheets As WorksheetCollection = workbook.Worksheets
        Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets(0)

        worksheet.Range("A1").NumberFormat = "#0.00"
        worksheet.Range("A2").NumberFormat = "#0.00"
        worksheet.Range("A3").NumberFormat = "#0.00"
        worksheet.Range("A4").NumberFormat = "#0.0000000000"
        worksheet.Range("A1").Value = ConfidenceLevelUL
        worksheet.Range("A2").Value = p_alpha_Value
        worksheet.Range("A3").Value = b_beta_Value_Calculated
        worksheet.Range("A4").Formula = "=ROUND(GAMMAINV(A1;A2;A3);10)"
        Dim GAMMA_INV As Double = worksheet.Range("A4").Value.NumericValue

        SplashScreenManager.Default.SetWaitFormCaption("Calculate DELTA Value")
        Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
        SplashScreenManager.Default.SetWaitFormCaption("Update DELTA Value and GAMMAINV")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Date] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & ""
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert K_Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskCHINA_Date] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals])"
        cmd.ExecuteNonQuery()

        Dim s_i As Decimal = 0
        Dim C_i As Decimal = 0
        Dim K_i As Decimal = 0
        Dim R_i As Decimal = 0
        Dim LGD_i As Decimal = 0
        Dim VLGD_i As Decimal = 0
        Dim CALCULATION_1 As Decimal = 0
        Dim CALCULATION_2 As Decimal = 0
        Dim CALCULATION_3 As Decimal = 0
        Dim TOTAL_CALCULATION As Decimal = 0

        SplashScreenManager.Default.SetWaitFormCaption("Calculate GA_n Value")
        Me.QueryText = "Select * from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]  Where [LGD]<>0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim IDNR As Double = dt.Rows.Item(i).Item("ID")
            s_i = dt.Rows.Item(i).Item("s_i")
            C_i = dt.Rows.Item(i).Item("C_i")
            K_i = dt.Rows.Item(i).Item("K_i")
            R_i = dt.Rows.Item(i).Item("R_i")
            LGD_i = dt.Rows.Item(i).Item("LGD")
            VLGD_i = dt.Rows.Item(i).Item("VLGD_i")
            Dim DELTA_VALUE_R As Decimal = Math.Round(DELTA_VALUE, 9)

            Dim PowerS_i As Decimal = Math.Round(s_i ^ 2, 12)
            Dim Calculation_A As Decimal = Math.Round(DELTA_VALUE_R * C_i * (K_i + R_i), 12)
            Dim Calculation_B As Decimal = Math.Round(DELTA_VALUE_R * (K_i + R_i) ^ 2, 12)
            Dim PowerVLGD As Decimal = VLGD_i ^ 2
            Dim PowerLGD As Decimal = LGD_i ^ 2
            Dim Calculation_C As Decimal = Math.Round(PowerVLGD / PowerLGD, 12)
            Dim Calculation_D As Decimal = Calculation_A + Calculation_B * Calculation_C

            CALCULATION_1 = Math.Round(Calculation_D, 12)
            CALCULATION_2 = Math.Round(K_i * (C_i + 2 * (K_i + R_i) * Calculation_C), 12)
            CALCULATION_3 = CALCULATION_1 - CALCULATION_2

            TOTAL_CALCULATION = Math.Round(PowerS_i * CALCULATION_3, 12)

            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_rel Value")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date]),10) from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals])"
        cmd.ExecuteNonQuery()

        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_Total Value")
        cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [ScenarioAnalyze_ConcentrationRiskCHINA_Totals]"
        Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
        cmd.CommandText = "Select [SumGA_rel] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date]"
        Dim SummeGArel As Double = cmd.ExecuteScalar
        Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] SET [SumGA_Total]='" & Str(SummeGA_Total) & "'"
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub CONCENTRATION_RISK_FI()
        SplashScreenManager.Default.SetWaitFormCaption("Execute Scenario Analysis for Concentration Risk FINANCIAL INSTITUTIONS")
        'CONCENTRATION RISK CHINA-EXPECTED LOSS
        SplashScreenManager.Default.SetWaitFormCaption("Modify Obligor Rate for Concentration Risk FINANCIAL INSTITUTIONS based on the Obligor Rate notches")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Details] set [Obligor Rate]=Convert(float,[Obligor Rate]) + (Select [ObligorRate_Mod] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Details] set [Obligor Rate]='19' where Convert(float,[Obligor Rate])>19"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update PD for Concentration Risk FINANCIAL INSTITUTIONS based on the new Obligor Rate")
        cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[CoreDefinition]=B.[CoreDefinition] FROM [ScenarioAnalyze_ConcentrationRiskTBA_Details] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update LGD for Concentration Risk FINANCIAL INSTITUTIONS based on the LGD Multiplier")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Details] set [(1-ER_45)]=[(1-ER_45)]* (Select [LGD_mod] from [ScenarioAnalyze_ConcentrationRiskTBA_Date])"
        cmd.ExecuteNonQuery()
        'Insert Rest Customers
        SplashScreenManager.Default.SetWaitFormCaption("Insert the rest of the Customers")
        cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskTBA_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[RiskDate] from [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "' and [Contract Collateral ID] not in (Select [Contract Collateral ID] from [ScenarioAnalyze_ConcentrationRiskTBA_Details] where [RiskDate]='" & rdsql & "')"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate Expected Loss for Concentration Risk FINANCIAL INSTITUTIONS")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Details] SET [CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update Expected Loss for Concentration Risk FINANCIAL INSTITUTIONS in ScenarioAnalyze_ConcentrationRiskTBA_Date")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Date] SET [SumEL]=(Select Sum([NetCreditRiskAmountEUREquER45]) from [ScenarioAnalyze_ConcentrationRiskTBA_Details])"
        cmd.ExecuteNonQuery()
        'CONCENTRATION RISK FI-UNEXPECTED LOSS
        SplashScreenManager.Default.SetWaitFormCaption("Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted for Concentration Risk FINANCIAL INSTITUTIONS")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Details] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Delete previus Data in ScenarioAnalyze_ConcentrationRiskTBA_Totals for Concentration Risk FINANCIAL INSTITUTIONS")
        cmd.CommandText = "DELETE FROM [ScenarioAnalyze_ConcentrationRiskTBA_Totals]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Insert Data to ScenarioAnalyze_ConcentrationRiskTBA_Totals for Concentration Risk FINANCIAL INSTITUTIONS")
        cmd.CommandText = "INSERT INTO [ScenarioAnalyze_ConcentrationRiskTBA_Totals]([ClientGroup],[RiskDate]) SELECT [ClientGroup],[RiskDate] from [ScenarioAnalyze_ConcentrationRiskTBA_Details] GROUP BY [ClientGroup],[RiskDate]"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] A INNER JOIN [ScenarioAnalyze_ConcentrationRiskTBA_Details] B ON A.[ClientGroup]=B.[ClientGroup]"
        cmd.ExecuteNonQuery()


        SplashScreenManager.Default.SetWaitFormCaption("Update [IdDate] in ScenarioAnalyze_ConcentrationRiskTBA_Totals for Concentration Risk FINANCIAL INSTITUTIONS")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [IdDate]=(Select [ID] from [ScenarioAnalyze_ConcentrationRiskTBA_Date])"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update IdClientGroup in ScenarioAnalyze_ConcentrationRiskTBA_Details for Concentration Risk FINANCIAL INSTITUTIONS ")
        cmd.CommandText = "UPDATE A set A.[IdClientGroup]=B.[ID] from [ScenarioAnalyze_ConcentrationRiskTBA_Details] A INNER JOIN [ScenarioAnalyze_ConcentrationRiskTBA_Totals] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update SubBorrowersCounter in ScenarioAnalyze_ConcentrationRiskTBA_Totals for Concentration Risk FINANCIAL INSTITUTIONS")
        cmd.CommandText = "UPDATE A SET A.[SubBorrowersCounter]=B.S from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] A INNER JOIN (Select [ClientGroup],Count([IdClientGroup]) as S from [ScenarioAnalyze_ConcentrationRiskTBA_Details] GROUP BY [ClientGroup]) B on A.[ClientGroup]=B.[ClientGroup]"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Update FinalEadTotalSum,LGD,PD_EaD_weigthed in ScenarioAnalyze_ConcentrationRiskTBA_Totals Table from ScenarioAnalyze_ConcentrationRiskTBA_Details")
        Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskTBA_Details] where [PD]<>0 GROUP BY [ClientGroup]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
            If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            End If
            Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
            cmd.CommandText = "Select [FinalEadTotalSum] from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] where [ClientGroup]='" & ClientGroup & "' "
            Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
            Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
            Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
            If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            End If
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update PD_3bps_floor in ScenarioAnalyze_ConcentrationRiskTBA_Totals")
        Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] GROUP BY [ClientGroup],[PD_EaD_weighted]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim PD_EaD_weighted As Double = dt.Rows.Item(i).Item("PD_EaD_weighted")
            Dim CheckNumber As Double = 0.0003
            Dim MaxNumber As Double = 0
            'Get PD_3bps_floor
            If PD_EaD_weighted > CheckNumber Then
                MaxNumber = PD_EaD_weighted
            Else
                MaxNumber = CheckNumber
            End If
            Dim SecondNumber As Double = 0
            If PD_EaD_weighted = 0 Then
                SecondNumber = 0
            Else
                SecondNumber = 1
            End If
            Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
            'Get IndicatorOfFloor
            Dim IndicatorOfFloor As Double = 0
            Dim difference As Double = PD_3bps_floor - PD_EaD_weighted

            If difference > 0 Then
                IndicatorOfFloor = 1
            Else
                IndicatorOfFloor = 0
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where  [ClientGroup]='" & ClientGroup & "'"
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update MaturityEADweigthed in ScenarioAnalyze_ConcentrationRiskTBA_Totals")
        Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskTBA_Details]  Where  [PD]<>0  GROUP BY [ClientGroup]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
            cmd.CommandText = "Select [FinalEadTotalSum] from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] where [ClientGroup]='" & ClientGroup & "'"
            Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
            Dim Variable1 As Double = SumEaDweigthedMaturityWithoutCapFloor / FinalEadTotalSum
            Dim CheckNumber As Double = 5
            Dim Variable2 As Double = 0
            If Variable1 > 5 Then
                Variable2 = 5
            Else
                Variable2 = Variable1
            End If
            Dim Variable3 As Double = 0
            If Variable2 > 1 Then
                Variable3 = Variable2
            Else
                Variable3 = 1
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "'"
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update R_CoefficientOfColleration and b_MaturityAdjustment in ScenarioAnalyze_ConcentrationRiskTBA_Totals")
        Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]  GROUP BY [ClientGroup],[PD_3bps_floor]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
            Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
            If PD = 0 Then
                PD = 1
            End If
            Dim PDminus As Double = PD * (-50)
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where   [ClientGroup]='" & ClientGroup & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [ClientGroup]='" & ClientGroup & "' "
            cmd.ExecuteNonQuery()
            'Set b_MaturityAdjustment to 0 if NULL
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [b_MaturityAdjustment]=0 where  [b_MaturityAdjustment] is NULL"
            cmd.ExecuteNonQuery()
        Next
        'INCREASE CORRELATION
        SplashScreenManager.Default.SetWaitFormCaption("Increase R_CoefficientOfColleration (Only for Country of Risk=CHINA) in ScenarioAnalyze_ConcentrationRiskTBA_Totals according to Parameter")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [R_CoefficientOfColleration]=[R_CoefficientOfColleration]*(Select Case when [R_Colleration_Mod]<>0 then [R_Colleration_Mod] else 0 end from [ScenarioAnalyze_ConcentrationRiskTBA_Date])+[R_CoefficientOfColleration] where [ClientGroup] in (Select [ClientGroup] from [ScenarioAnalyze_ConcentrationRiskTBA_Details] where [ClientGroup] not in ('1000') and [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('F - FINANCIAL')))"
        cmd.ExecuteNonQuery()
        'Get LevelOfConfidence from ScenarioAnalyze_GeneralStressTest_Date
        SplashScreenManager.Default.SetWaitFormCaption("Get LEVEL OF CONFIDENCE from ScenarioAnalyze_ConcentrationRiskTBA_Date")
        cmd.CommandText = "Select [LevelOfConfidence] from [ScenarioAnalyze_ConcentrationRiskTBA_Date]"
        Dim LevelOfConfidence As Double = cmd.ExecuteScalar
        SplashScreenManager.Default.SetWaitFormCaption("Update RW_RiskWeightedExposure and UL_UnexpectedLoss in ScenarioAnalyze_ConcentrationRiskTBA_Totals")
        Me.QueryText = "Select * from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]  Where [b_MaturityAdjustment]<>0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
            Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
            Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
            If PD = 0 Then
                PD = 1
            End If
            Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
            Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
            'Check if PD<>1 then execute Formula otherwise if PD=1 then it goes to error
            If PD <> 1 Then
                'Get First Part of Formula
                cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] where [ID]='" & ID & "' "
                Dim FirstPartFormulaRW = cmd.ExecuteScalar
                'Get Second Part of Formula
                cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [ScenarioAnalyze_ConcentrationRiskTBA_Totals] where [ID]='" & ID & "'"
                Dim SecondPartFormulaRW = cmd.ExecuteScalar
                Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()

            ElseIf PD = 1 Then
                cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [RW_RiskWeightedExposure]=0 where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            End If
            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Update Sum Unexpected Loss in ScenarioAnalyze_ConcentrationRiskTBA_Date")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Date] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [ScenarioAnalyze_ConcentrationRiskTBA_Totals])"
        cmd.ExecuteNonQuery()
        'CONCENTRATION RISK CHINA-GRANULARITY APPROACH
        SplashScreenManager.Default.SetWaitFormCaption("Start GRANULARITY APPROACH Calculation")
        SplashScreenManager.Default.SetWaitFormCaption("Calculate s_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Totals] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]),10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate K_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Totals] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate R_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Totals] set [R_i]=Round([LGD]*[PD_3bps_floor],10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate VLGD_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Totals] set [VLGD_i]=Round((select nu_Value from [ScenarioAnalyze_ConcentrationRiskTBA_Date])*[LGD]*(1-[LGD]),10)"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate C_i Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Totals] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [LGD]<>0"
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate GAMMAINV")
        Me.QueryText = "Select * from [ScenarioAnalyze_ConcentrationRiskTBA_Date]"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        Dim p_alpha_Value As Double = dt.Rows.Item(0).Item("p_alpha_Value")
        Dim b_beta_Value As Double = dt.Rows.Item(0).Item("b_beta_value")
        Dim ConfidenceLevelUL As Double = dt.Rows.Item(0).Item("LevelOfConfidence")
        Dim b_beta_Value_Calculated As Double = 1 / b_beta_Value

        'excel = New Microsoft.Office.Interop.Excel.Application
        'instance = excel.WorksheetFunction

        'Dim GAMMA_INV As Double = Math.Round(instance.GammaInv(ConfidenceLevelUL, p_alpha_Value, b_beta_Value_Calculated), 10)

        'Excel Instanz beenden
        'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
        'Dim i1 As Short
        'i1 = 0
        'For i1 = 0 To (procs.Length - 1)
        'procs(i1).Kill()
        'Next i1

        Dim workbook As New DevExpress.Spreadsheet.Workbook()
        Dim worksheets As WorksheetCollection = workbook.Worksheets
        Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets(0)

        worksheet.Range("A1").NumberFormat = "#0.00"
        worksheet.Range("A2").NumberFormat = "#0.00"
        worksheet.Range("A3").NumberFormat = "#0.00"
        worksheet.Range("A4").NumberFormat = "#0.0000000000"
        worksheet.Range("A1").Value = ConfidenceLevelUL
        worksheet.Range("A2").Value = p_alpha_Value
        worksheet.Range("A3").Value = b_beta_Value_Calculated
        worksheet.Range("A4").Formula = "=ROUND(GAMMAINV(A1;A2;A3);10)"
        Dim GAMMA_INV As Double = worksheet.Range("A4").Value.NumericValue

        SplashScreenManager.Default.SetWaitFormCaption("Calculate DELTA Value")
        Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
        SplashScreenManager.Default.SetWaitFormCaption("Update DELTA Value and GAMMAINV")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Date] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & ""
        cmd.ExecuteNonQuery()
        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert K_Value")
        cmd.CommandText = "Update [ScenarioAnalyze_ConcentrationRiskTBA_Date] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [ScenarioAnalyze_ConcentrationRiskTBA_Totals])"
        cmd.ExecuteNonQuery()

        Dim s_i As Decimal = 0
        Dim C_i As Decimal = 0
        Dim K_i As Decimal = 0
        Dim R_i As Decimal = 0
        Dim LGD_i As Decimal = 0
        Dim VLGD_i As Decimal = 0
        Dim CALCULATION_1 As Decimal = 0
        Dim CALCULATION_2 As Decimal = 0
        Dim CALCULATION_3 As Decimal = 0
        Dim TOTAL_CALCULATION As Decimal = 0

        SplashScreenManager.Default.SetWaitFormCaption("Calculate GA_n Value")
        Me.QueryText = "Select * from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]  Where [LGD]<>0"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim IDNR As Double = dt.Rows.Item(i).Item("ID")
            s_i = dt.Rows.Item(i).Item("s_i")
            C_i = dt.Rows.Item(i).Item("C_i")
            K_i = dt.Rows.Item(i).Item("K_i")
            R_i = dt.Rows.Item(i).Item("R_i")
            LGD_i = dt.Rows.Item(i).Item("LGD")
            VLGD_i = dt.Rows.Item(i).Item("VLGD_i")
            Dim DELTA_VALUE_R As Decimal = Math.Round(DELTA_VALUE, 9)

            Dim PowerS_i As Decimal = Math.Round(s_i ^ 2, 12)
            Dim Calculation_A As Decimal = Math.Round(DELTA_VALUE_R * C_i * (K_i + R_i), 12)
            Dim Calculation_B As Decimal = Math.Round(DELTA_VALUE_R * (K_i + R_i) ^ 2, 12)
            Dim PowerVLGD As Decimal = VLGD_i ^ 2
            Dim PowerLGD As Decimal = LGD_i ^ 2
            Dim Calculation_C As Decimal = Math.Round(PowerVLGD / PowerLGD, 12)
            Dim Calculation_D As Decimal = Calculation_A + Calculation_B * Calculation_C

            CALCULATION_1 = Math.Round(Calculation_D, 12)
            CALCULATION_2 = Math.Round(K_i * (C_i + 2 * (K_i + R_i) * Calculation_C), 12)
            CALCULATION_3 = CALCULATION_1 - CALCULATION_2

            TOTAL_CALCULATION = Math.Round(PowerS_i * CALCULATION_3, 12)

            cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Totals] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
            cmd.ExecuteNonQuery()
        Next
        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_rel Value")
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Date] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [ScenarioAnalyze_ConcentrationRiskTBA_Date]),10) from [ScenarioAnalyze_ConcentrationRiskTBA_Totals])"
        cmd.ExecuteNonQuery()

        SplashScreenManager.Default.SetWaitFormCaption("Calculate and Insert Sum GA_Total Value")
        cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [ScenarioAnalyze_ConcentrationRiskTBA_Totals]"
        Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
        cmd.CommandText = "Select [SumGA_rel] from [ScenarioAnalyze_ConcentrationRiskTBA_Date]"
        Dim SummeGArel As Double = cmd.ExecuteScalar
        Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
        cmd.CommandText = "UPDATE [ScenarioAnalyze_ConcentrationRiskTBA_Date] SET [SumGA_Total]='" & Str(SummeGA_Total) & "'"
        cmd.ExecuteNonQuery()
    End Sub

#Region "PRINT_EXPORT_BUTTONS"
    Private Sub Print_Export_GridviewGeneral_Totals_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridviewGeneral_Totals_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
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
        Dim reportfooter As String = "SCENARIO ANALYSIS - GENERAL STRESS TESTS (Totals) " & "   " & "on: " & Me.ScenarioAnalysisDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub PrintExport_GENERAL_DetailsView_btn_Click(sender As Object, e As EventArgs) Handles PrintExport_GENERAL_DetailsView_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "SCENARIO ANALYSIS - GENERAL STRESS TESTS (Details) " & "   " & "on: " & Me.ScenarioAnalysisDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_GridviewCHINA_Totals_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridviewCHINA_Totals_btn.Click
        If Not GridControl5.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink3.CreateDocument()
        PrintableComponentLink3.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink3_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink3.CreateMarginalHeaderArea
        Dim reportfooter As String = "SCENARIO ANALYSIS - CONCENTRATION RISK CHINA (Totals) " & "   " & "on: " & Me.ScenarioAnalysisDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_GridviewCHINA_Details_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_GridviewCHINA_Details_btn.Click
        If Not GridControl6.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink4.CreateDocument()
        PrintableComponentLink4.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink4_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink4.CreateMarginalHeaderArea
        Dim reportfooter As String = "SCENARIO ANALYSIS - CONCENTRATION RISK CHINA (Details) " & "    " & "on: " & Me.ScenarioAnalysisDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ConcentrationRiskFI_Totals_Print_btn_Click(sender As Object, e As EventArgs) Handles ConcentrationRiskFI_Totals_Print_btn.Click
        If Not GridControl3.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink5.CreateDocument()
        PrintableComponentLink5.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink5_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink5.CreateMarginalHeaderArea
        Dim reportfooter As String = "SCENARIO ANALYSIS - CONCENTRATION RISK FINANCIAL INSTITUTIONS without CCB (TOTALS) " & "   " & "on: " & Me.ScenarioAnalysisDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub ConcentrationRiskFI_Details_Print_btn_Click(sender As Object, e As EventArgs) Handles ConcentrationRiskFI_Details_Print_btn.Click
        If Not GridControl4.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink6.CreateDocument()
        PrintableComponentLink6.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink6_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink6.CreateMarginalHeaderArea
        Dim reportfooter As String = "SCENARIO ANALYSIS - CONCENTRATION RISK FINANCIAL INSTITUTIONS without CCB (DETAILS) " & "   " & "on: " & Me.ScenarioAnalysisDate_lbl.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#End Region

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

    Private Sub LGD_CHINA_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LGD_CHINA_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the LGD Multiplicator default value for Concentration Risk CHINA  be changed to " & Me.LGD_CHINA_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLGDmultiplicator As Double = Me.LGD_CHINA_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_LGDmod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] add constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_LGDmod] default (" & Str(DefaultValueLGDmultiplicator) & ") for [LGD_mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("LGD Multiplicator default value for Concentration Risk CHINA has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub Colleration_CHINA_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Colleration_CHINA_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Colleration increase default value for Concentration Risk CHINA  be changed to " & Me.Colleration_CHINA_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueCollerationIncrease As Double = Me.Colleration_CHINA_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_R_CollerationMod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] add constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_R_CollerationMod] default (" & Str(DefaultValueCollerationIncrease) & ") for [R_Colleration_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Colleration increase default value for Concentration Risk CHINA  has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub ObligorRate_Mod_CHINA_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ObligorRate_Mod_CHINA_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Obligor rate notches default value for Concentration Risk CHINA  be changed to " & Me.ObligorRate_Mod_CHINA_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueObligorRateNotches As Double = Me.ObligorRate_Mod_CHINA_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_PD_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] add constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_PD_Mod] default (" & Str(DefaultValueObligorRateNotches) & ") for [ObligorRate_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Obligor rate notches default value for Concentration Risk CHINA has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub LGD_FI_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LGD_FI_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the LGD Multiplicator default value for Concentration Risk FINANCIAL INSTITUTIONS  be changed to " & Me.LGD_FI_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLGDmultiplicator As Double = Me.LGD_FI_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskTBA_Date_LGD_mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] add constraint [DF_ScenarioAnalyze_ConcentrationRiskTBA_Date_LGD_mod] default (" & Str(DefaultValueLGDmultiplicator) & ") for [LGD_mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("LGD Multiplicator default value for Concentration Risk FINANCIAL INSTITUTIONS has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub


    Private Sub Colleration_FI_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Colleration_FI_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Colleration increase default value for Concentration Risk FINANCIAL INSTITUTION  be changed to " & Me.Colleration_FI_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueCollerationIncrease As Double = Me.Colleration_FI_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskTBA_Date_R_Colleration_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] add constraint [DF_ScenarioAnalyze_ConcentrationRiskTBA_Date_R_Colleration_Mod] default (" & Str(DefaultValueCollerationIncrease) & ") for [R_Colleration_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Colleration increase default value for Concentration Risk FINANCIAL INSTITUTIONS  has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub ObligorRate_Mod_FI_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ObligorRate_Mod_FI_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Obligor rate notches default value for Concentration Risk FINANCIAL INSTITUTIONS  be changed to " & Me.ObligorRate_Mod_FI_SpinEdit.Text, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueObligorRateNotches As Double = Me.ObligorRate_Mod_FI_SpinEdit.Text
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskTBA_Date_PD_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] add constraint [DF_ScenarioAnalyze_ConcentrationRiskTBA_Date_PD_Mod] default (" & Str(DefaultValueObligorRateNotches) & ") for [ObligorRate_Mod]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Obligor rate notches default value for Concentration Risk FINANCIAL INSTITUTION has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub LevelConfidence_China_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelConfidence_China_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Level of confidence default value in Concentration Risk for China be changed to " & Me.LevelConfidence_China_SpinEdit.EditValue.ToString, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelofConfidence As Double = Me.LevelConfidence_China_SpinEdit.EditValue
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] drop constraint [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskCHINA_Date] ADD  CONSTRAINT [DF_ScenarioAnalyze_ConcentrationRiskCHINA_Date_LevelOfConfidence]  default (" & Str(DefaultValueLevelofConfidence) & ") FOR [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Level of confidence default value for Concentration Risk for China has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub LevelConfidence_Financial_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelConfidence_Financial_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Level of confidence default value in Concentration Risk for Financial Institutions  be changed to " & Me.LevelConfidence_Financial_SpinEdit.EditValue.ToString, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelofConfidence As Double = Me.LevelConfidence_Financial_SpinEdit.EditValue
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] drop constraint [DF_ScenarioAnalyze_Concentrationrisk_Date_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_ConcentrationRiskTBA_Date] ADD  CONSTRAINT [DF_ScenarioAnalyze_Concentrationrisk_Date_LevelOfConfidence]  default (" & Str(DefaultValueLevelofConfidence) & ") FOR [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Level of confidence default value for Concentration Risk in Financial institutions has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub

    Private Sub LevelConfidence_General_SpinEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LevelConfidence_General_SpinEdit.ButtonClick
        If e.Button.Tag = "ChangeStandardValue" Then
            If MessageBox.Show("Should the Level of confidence default value in GENERAL STRESS TEST  be changed to " & Me.LevelConfidence_General_SpinEdit.EditValue.ToString, "CHANGE DEFAULT VALUE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim DefaultValueLevelofConfidence As Double = Me.LevelConfidence_General_SpinEdit.EditValue
                    OpenSqlConnections()
                    cmd.CommandText = "DISABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] drop constraint [DF_ScenarioAnalyze_GeneralStressTest_Totals_LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [ScenarioAnalyze_GeneralStressTest_Date] ADD  CONSTRAINT [DF_ScenarioAnalyze_GeneralStressTest_Totals_LevelOfConfidence]  default (" & Str(DefaultValueLevelofConfidence) & ") FOR [LevelOfConfidence]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ENABLE TRIGGER TR_ProtectCriticalTables ON DATABASE"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    MessageBox.Show("Level of confidence default value for GENERAL STRESS TEST has being changed!", "DEFAULT VALUE CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As System.Exception
                    CloseSqlConnections()
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Try
                End Try
            End If
        End If
    End Sub


#End Region

#Region "GRIDVIEWS_ROW_STYLES"

    Private Sub GeneralStressTest_TOTALS_BasicView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GeneralStressTest_TOTALS_BasicView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "GeneralStressTest_TOTALS_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GeneralStressTestsDetailsViewCaption = "General Stress Test details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.GeneralStressTestTOTALS_DetailView.ViewCaption = GeneralStressTestsDetailsViewCaption
        End If
    End Sub

    Private Sub GeneralStressTest_TOTALS_BasicView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles GeneralStressTest_TOTALS_BasicView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "GeneralStressTest_TOTALS_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GeneralStressTestsDetailsViewCaption = "General Stress Test details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.GeneralStressTestTOTALS_DetailView.ViewCaption = GeneralStressTestsDetailsViewCaption
        End If
    End Sub

    Private Sub GeneralStressTest_TOTALS_BasicView_RowClick(sender As Object, e As RowClickEventArgs) Handles GeneralStressTest_TOTALS_BasicView.RowClick
        If Me.GridControl1.FocusedView.Name = "GeneralStressTest_TOTALS_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            GeneralStressTestsDetailsViewCaption = "General Stress Test details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.GeneralStressTestTOTALS_DetailView.ViewCaption = GeneralStressTestsDetailsViewCaption
        End If
    End Sub
    Private Sub GeneralStressTest_TOTALS_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GeneralStressTest_TOTALS_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GeneralStressTest_TOTALS_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles GeneralStressTest_TOTALS_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GeneralStressTestTOTALS_DetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GeneralStressTestTOTALS_DetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GeneralStressTestTOTALS_DetailView_ShownEditor(sender As Object, e As EventArgs) Handles GeneralStressTestTOTALS_DetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GeneralStressTest_AllDetailsView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GeneralStressTest_AllDetailsView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub GeneralStressTest_AllDetailsView_ShownEditor(sender As Object, e As EventArgs) Handles GeneralStressTest_AllDetailsView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Totals_BasicView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ConcentrationRisk_CHINA_Totals_BasicView.MasterRowExpanded
        If Me.GridControl5.FocusedView.Name = "ConcentrationRisk_CHINA_Totals_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ConcentrationRiskCHINAViewCaption = "Concentration Risk (CHINA) details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.ConcentrationRisk_CHINA_Details_BasicView.ViewCaption = ConcentrationRiskCHINAViewCaption
        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Totals_BasicView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ConcentrationRisk_CHINA_Totals_BasicView.MasterRowExpanding
        If Me.GridControl5.FocusedView.Name = "ConcentrationRisk_CHINA_Totals_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ConcentrationRiskCHINAViewCaption = "Concentration Risk (CHINA) details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.ConcentrationRisk_CHINA_Details_BasicView.ViewCaption = ConcentrationRiskCHINAViewCaption
        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Totals_BasicView_RowClick(sender As Object, e As RowClickEventArgs) Handles ConcentrationRisk_CHINA_Totals_BasicView.RowClick
        If Me.GridControl5.FocusedView.Name = "ConcentrationRisk_CHINA_Totals_BasicView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ConcentrationRiskCHINAViewCaption = "Concentration Risk (CHINA) details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.ConcentrationRisk_CHINA_Details_BasicView.ViewCaption = ConcentrationRiskCHINAViewCaption
        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Totals_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ConcentrationRisk_CHINA_Totals_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Totals_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ConcentrationRisk_CHINA_Totals_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Details_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ConcentrationRisk_CHINA_Details_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_Details_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ConcentrationRisk_CHINA_Details_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_DetailsAll_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ConcentrationRisk_CHINA_DetailsAll_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ConcentrationRisk_CHINA_DetailsAll_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ConcentrationRisk_CHINA_DetailsAll_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ConcentrationRisk_FI_AllDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ConcentrationRisk_FI_AllDetails_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ConcentrationRisk_FI_AllDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ConcentrationRisk_FI_AllDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Details_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ConcentrationRisk_FI_Details_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Details_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ConcentrationRisk_FI_Details_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Totals_GridView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ConcentrationRisk_FI_Totals_GridView.MasterRowExpanded
        If Me.GridControl3.FocusedView.Name = "ConcentrationRisk_FI_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ConcentrationRiskFIViewCaption = "Concentration Risk (FINANCIAL INSTITUTION) details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.ConcentrationRisk_FI_Details_GridView.ViewCaption = ConcentrationRiskFIViewCaption
        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Totals_GridView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ConcentrationRisk_FI_Totals_GridView.MasterRowExpanding
        If Me.GridControl3.FocusedView.Name = "ConcentrationRisk_FI_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ConcentrationRiskFIViewCaption = "Concentration Risk (FINANCIAL INSTITUTION) details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.ConcentrationRisk_FI_Details_GridView.ViewCaption = ConcentrationRiskFIViewCaption
        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Totals_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles ConcentrationRisk_FI_Totals_GridView.RowClick
        If Me.GridControl3.FocusedView.Name = "ConcentrationRisk_FI_Totals_GridView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ConcentrationRiskFIViewCaption = "Concentration Risk (FINANCIAL INSTITUTION) details for Customer Group: " & view.GetFocusedRowCellValue("ClientGroupName").ToString & "  (" & view.GetFocusedRowCellValue("ClientGroup").ToString & ")"
            Me.ConcentrationRisk_FI_Details_GridView.ViewCaption = ConcentrationRiskFIViewCaption
        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Totals_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ConcentrationRisk_FI_Totals_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ConcentrationRisk_FI_Totals_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ConcentrationRisk_FI_Totals_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub
#End Region

    

#Region "EXCEL FILE - GENERAL STRESS TEST"
    Private Sub LoadExcelFile_General_btn_Click(sender As Object, e As EventArgs) Handles LoadExcelFile_General_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for General Stress Tests - Risk Date:" & Me.ScenarioAnalysisDate_lbl.Text)

            BgwExcelLoad_General = New BackgroundWorker
            BgwExcelLoad_General.WorkerReportsProgress = True
            BgwExcelLoad_General.RunWorkerAsync()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwExcelLoad_General_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad_General.DoWork
        Dim rd As Date = Me.ScenarioAnalysisDate_lbl.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")

        Me.QueryText = "SELECT [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)]/(Select [LGD_mod] from [ScenarioAnalyze_GeneralStressTest_Date]) as 'ModifiedLGD',0 as 'New_LGD',0 as 'CreditRiskAmountEUREquER45',0 as 'NetCreditRiskAmountEUREquER45',[CoreDefinition],[ClientGroup],[ClientGroupName],0 as 'MaturityWithoutCapFloor',0 as 'EaDweigthedMaturityWithoutCapFloor',0 as 'PDxFinalEaD',0 as 'LGDfinalEaDweighted' from [ScenarioAnalyze_GeneralStressTest_Details] where [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)

        Me.QueryText = "SELECT [ClientGroup],[ClientGroupName],0 as 'SubBorrowersCounter',0 as 'FinalEadTotalSum',[LGD] FROM  [ScenarioAnalyze_GeneralStressTest_Totals] where [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)

        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_STRESS_TEST_GENERAL' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()


        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with basic Parameters for the Stress Test General Calculation")
        'Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        Dim workbook As New Workbook()

        workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim worksheet1 As Worksheet = workbook.Worksheets(1)



        'STRESS TEST PARAMETER
        Dim LGDx As Double = Me.LGD_GST_SpinEdit.Text
        workbook.Worksheets(0).Cells("H4").Value = LGDx
        Dim ColerationIncrease As Double = Me.Colleration_GST_SpinEdit.EditValue
        workbook.Worksheets(0).Cells("H5").Value = ColerationIncrease
        Dim ObligorRateNoches As Double = Me.ObligorRate_Mod_GST_SpinEdit.Text
        workbook.Worksheets(0).Cells("H6").Value = ObligorRateNoches
        Dim LevelOfConfidence As Double = Me.LevelConfidence_General_SpinEdit.Text
        workbook.Worksheets(0).Cells("L6").Value = LevelOfConfidence
        'Stress Test Values
        'Dim ExpectedLoss_Test As Double = Me.ExpectedLoss_GST_TextEdit.Text
        'workbook.Worksheets(0).Cells("C5").Value = ExpectedLoss_Test
        'Dim UnexpectedLoss_Test As Double = Me.UnexpectedLoss_GST_TextEdit.Text
        'workbook.Worksheets(0).Cells("D5").Value = UnexpectedLoss_Test
        'Dim GA_Test As Double = Me.Granularity_GST_TextEdit.Text
        'workbook.Worksheets(0).Cells("E5").Value = GA_Test
        'Production Values
        Dim ExpectedLoss_Prod As Double = Me.ExpectedLoss_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("C6").Value = ExpectedLoss_Prod
        Dim UnexpectedLoss_Prod As Double = Me.UnexpectedLoss_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("D6").Value = UnexpectedLoss_Prod
        Dim GA_Prod As Double = Me.Granularity_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("E6").Value = GA_Prod

        'FILL DETAILS
        workbook.Worksheets.ActiveWorksheet = worksheet1
        workbook.Worksheets(1).Cells("A1").Value = "General Stress Test Details - Calculation Expected/Unexpected Loss and Granularity approach for Business Date: "
        workbook.Worksheets(1).Cells("F1").Value = rd
        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet1.ClearContents(worksheet1("A3:AC10000"))
        '+++++++++++++++++++++++++++++

       
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - DETAILS WORKSHEET")
        worksheet1.Import(dt1, False, 2, 0)

        Dim DETAILS_LastRow As Integer = 0
        If dt1.Rows.Count > 0 Then
            DETAILS_LastRow = dt1.Rows.Count + 2

            Dim RangeDETAILS_T As CellRange = worksheet1.Range("T3:T" & DETAILS_LastRow)
            RangeDETAILS_T.Formula = "=S3*Totals!$H$4"
            Dim RangeDETAILS_U As CellRange = worksheet1.Range("U3:U" & DETAILS_LastRow)
            RangeDETAILS_U.Formula = "=M3*O3*T3"
            Dim RangeDETAILS_V As CellRange = worksheet1.Range("V3:V" & DETAILS_LastRow)
            RangeDETAILS_V.Formula = "=M3*O3*T3"
            Dim RangeDETAILS_Z As CellRange = worksheet1.Range("Z3:Z" & DETAILS_LastRow)
            RangeDETAILS_Z.Formula = "=ROUND((IF(OR(EXACT(H3;DATE(9999;12;31));ISBLANK(H3));DATEDIF($F$1;DATE(YEAR($F$1);MONTH($F$1)+6;DAY($F$1));""d"");DATEDIF($F$1;H3;""d"")))/365,25;2)"
            Dim RangeDETAILS_AA As CellRange = worksheet1.Range("AA3:AA" & DETAILS_LastRow)
            RangeDETAILS_AA.Formula = "=M3*Z3"
            Dim RangeDETAILS_AB As CellRange = worksheet1.Range("AB3:AB" & DETAILS_LastRow)
            RangeDETAILS_AB.Formula = "=M3*O3"
            Dim RangeDETAILS_AC As CellRange = worksheet1.Range("AC3:AC" & DETAILS_LastRow)
            RangeDETAILS_AC.Formula = "=M3*T3"
        End If


        'FILL TOTALS
        workbook.Worksheets(0).Cells("A2").Value = "General Stress Test - Calculation Expected/Unexpected Loss and Granularity approach for Business Date: " & rd
        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet.ClearContents(worksheet("A9:T10000"))


        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - TOTALS WORKSHEET")
        worksheet.Import(dt, False, 8, 0)

        Dim TOTALS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            TOTALS_LastRow = dt.Rows.Count + 8

            Dim RangeTOTALS_C As CellRange = worksheet.Range("C9:C" & TOTALS_LastRow)
            RangeTOTALS_C.Formula = "=COUNTIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9)"
            Dim RangeTOTALS_D As CellRange = worksheet.Range("D9:D" & TOTALS_LastRow)
            RangeTOTALS_D.Formula = "=SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$M$3:$M$" & DETAILS_LastRow & ")"
            Dim RangeTOTALS_F As CellRange = worksheet.Range("F9:F" & TOTALS_LastRow)
            RangeTOTALS_F.Formula = "=IF(ISERROR((SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D9);0;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D9)"
            Dim RangeTOTALS_G As CellRange = worksheet.Range("G9:G" & TOTALS_LastRow)
            RangeTOTALS_G.Formula = "=MAX(F9;0,0003)*IF(EXACT(0;F9);0;1)"
            Dim RangeTOTALS_H As CellRange = worksheet.Range("H9:H" & TOTALS_LastRow)
            RangeTOTALS_H.Formula = "=IF(G9-F9>0;1;0)"
            Dim RangeTOTALS_I As CellRange = worksheet.Range("I9:I" & TOTALS_LastRow)
            RangeTOTALS_I.Formula = "=IF(ISERROR(MAX(1;MIN(5;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D9)));""n.a."";" & "MAX(1;MIN(5;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D9)))"
            Dim RangeTOTALS_J As CellRange = worksheet.Range("J9:J" & TOTALS_LastRow)
            RangeTOTALS_J.Formula = "=0,12*((1-EXP(-50*G9))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*G9))/(1-EXP(-50))))"
            Dim RangeTOTALS_K As CellRange = worksheet.Range("K9:K" & TOTALS_LastRow)
            RangeTOTALS_K.Formula = "=J9*$H$5+J9"
            Dim RangeTOTALS_L As CellRange = worksheet.Range("L9:L" & TOTALS_LastRow)
            RangeTOTALS_L.Formula = "=IF(ISERROR((0,11852-0,05478*LN(G9))^2);""n.a."";" & "(0,11852-0,05478*LN(G9))^2)"
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Calulate Fisrt Columns O and P to get K* Value
            Dim RangeTOTALS_O As CellRange = worksheet.Range("O9:O" & TOTALS_LastRow)
            RangeTOTALS_O.Formula = "=D9/SUM($D$9:$D$" & TOTALS_LastRow & ")"
            Dim RangeTOTALS_P As CellRange = worksheet.Range("P9:P" & TOTALS_LastRow)
            RangeTOTALS_P.Formula = "=IF(ISERROR(N9/D9);0;N9/D9)"
            worksheet.Cells("L3").Formula = "=SUMPRODUCT(O9:O" & TOTALS_LastRow & ";P9:P" & TOTALS_LastRow & ")"
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim RangeTOTALS_M As CellRange = worksheet.Range("M9:M" & TOTALS_LastRow)
            RangeTOTALS_M.Formula = "=IF(ISERROR((E9*NORMDIST(  (1/(1-K9))^0,5    *   NORMINV(G9;0;1)    +    (K9/(1-K9))^0,5  *  NORMINV($L$6;0;1);0;1;TRUE)   - E9*G9   )*( (1+(K9-2,5)*L9) / (1-1,5*L9)  )*12,5*1,06);""n.a."";" & " (E9*NORMDIST(  (1/(1-K9))^0,5    *   NORMINV(G9;0;1)    +    (K9/(1-K9))^0,5  *  NORMINV($L$6;0;1);0;1;TRUE)   - E9*G9   )*( (1+(I9-2,5)*L9) / (1-1,5*L9)  )*12,5*1,06)"
            Dim RangeTOTALS_N As CellRange = worksheet.Range("N9:N" & TOTALS_LastRow)
            RangeTOTALS_N.Formula = "=IF(ISERROR(M9*D9*0,08);0;M9*D9*0,08)"
            Dim RangeTOTALS_Q As CellRange = worksheet.Range("Q9:Q" & TOTALS_LastRow)
            RangeTOTALS_Q.Formula = "=E9*G9"
            Dim RangeTOTALS_R As CellRange = worksheet.Range("R9:R" & TOTALS_LastRow)
            RangeTOTALS_R.Formula = "=$J$4*E9*(1-E9)"
            Dim RangeTOTALS_S As CellRange = worksheet.Range("S9:S" & TOTALS_LastRow)
            RangeTOTALS_S.Formula = "=IF(ISERROR((E9^2+R9)/E9);0;(E9^2+R9)/E9)"
            Dim RangeTOTALS_T As CellRange = worksheet.Range("T9:T" & TOTALS_LastRow)
            RangeTOTALS_T.Formula = "=IF(ISERROR(O9^2*(($J$6*S9*(P9 + Q9) +$J$6*(P9 + Q9)^2 *(R9^2)/(E9^2))-P9*(S9+2*(P9 + Q9)*(R9^2)/(E9^2))));0;O9^2*(($J$6*S9*(P9 + Q9)+$J$6*(P9 + Q9)^2*(R9^2)/(E9^2))-P9*(S9+2*(P9 + Q9)*(R9^2)/(E9^2))))"
            '*****************************************
            worksheet.Cells("T8").Formula = "=SUM(T9:T" & TOTALS_LastRow & ")/(2*$L$3)"
            '+++++++++++++++++++++++++++++++++++++++++
            'Calculate Results
            'Expected Loss
            worksheet.Cells("C5").Formula = "=SUM(Details!V3:V" & DETAILS_LastRow & ")"
            'Unexpected Loss
            worksheet.Cells("D5").Formula = "=SUM(N9:N" & TOTALS_LastRow & ")"
            'Granularity Approach
            worksheet.Cells("E5").Formula = "=T8*SUM(D9:D" & TOTALS_LastRow & ")"
        End If


        'Dim range1 As CellRange = worksheet.Range("A:AC")
        'Dim rangeFormatting1 As DevExpress.Spreadsheet.Formatting = range1.BeginUpdateFormatting()
        'rangeFormatting1.Font.Color = Color.Black
        'rangeFormatting1.Fill.BackgroundColor = Color.White
        'range1.EndUpdateFormatting(rangeFormatting1)

        'Dim range As CellRange = worksheet1.Range("A:AC")
        'Dim rangeFormatting As DevExpress.Spreadsheet.Formatting = range.BeginUpdateFormatting()
        'rangeFormatting.Font.Color = Color.Black
        'rangeFormatting.Fill.BackgroundColor = Color.White
        'range.EndUpdateFormatting(rangeFormatting)

        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
    End Sub

    Private Sub BgwExcelLoad_General_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad_General.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized

        c.Text = "General Stress Test - Excel File calculation"
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.Xlsx)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "EXCEL FILE - CHINA STRESS TEST"
    Private Sub LoadExcelFile_CN_btn_Click(sender As Object, e As EventArgs) Handles LoadExcelFile_CN_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for Stress Tests CHINA - Risk Date:" & Me.ScenarioAnalysisDate_lbl.Text)

            BgwExcelLoad_CN = New BackgroundWorker
            BgwExcelLoad_CN.WorkerReportsProgress = True
            BgwExcelLoad_CN.RunWorkerAsync()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwExcelLoad_CN_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad_CN.DoWork
        Dim rd As Date = Me.ScenarioAnalysisDate_lbl.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_STRESS_TEST_CHINA' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with basic Parameters for the Stress Test CHINA Calculation")
        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim worksheet1 As Worksheet = workbook.Worksheets(1)

        Dim LGDx As Double = Me.LGD_CHINA_SpinEdit.Text
        workbook.Worksheets(0).Cells("H4").Value = LGDx
        Dim ColerationIncrease As Double = Me.Colleration_CHINA_SpinEdit.EditValue
        workbook.Worksheets(0).Cells("H5").Value = ColerationIncrease
        Dim ObligorRateNoches As Double = Me.ObligorRate_Mod_CHINA_SpinEdit.Text
        workbook.Worksheets(0).Cells("H6").Value = ObligorRateNoches
        Dim LevelOfConfidence As Double = Me.LevelConfidence_General_SpinEdit.Text
        workbook.Worksheets(0).Cells("L6").Value = LevelOfConfidence
        'Stress Test Values
        'Dim ExpectedLoss_Test As Double = Me.ExpectedLoss_CHINA_TextEdit.Text
        'workbook.Worksheets(0).Cells("C5").Value = ExpectedLoss_Test
        'Dim UnexpectedLoss_Test As Double = Me.UnexpectedLoss_CHINA_TextEdit.Text
        'workbook.Worksheets(0).Cells("D5").Value = UnexpectedLoss_Test
        'Dim GA_Test As Double = Me.Granularity_CHINA_TextEdit.Text
        'workbook.Worksheets(0).Cells("E5").Value = GA_Test
        'Production Values
        Dim ExpectedLoss_Prod As Double = Me.ExpectedLoss_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("C6").Value = ExpectedLoss_Prod
        Dim UnexpectedLoss_Prod As Double = Me.UnexpectedLoss_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("D6").Value = UnexpectedLoss_Prod
        Dim GA_Prod As Double = Me.Granularity_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("E6").Value = GA_Prod


        'FILL DETAILS
        workbook.Worksheets(1).Cells("A1").Value = "CHINA Stress Test Details - Calculation Expected/Unexpected Loss and Granularity approach for Business Date:"
        workbook.Worksheets(1).Cells("F1").Value = rd
        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet1.ClearContents(worksheet1("A3:AC10000"))
        '+++++++++++++++++++++++++++++
        Me.QueryText = "SELECT A.[Obligor Rate],A.[Contract Type],A.[Product Type],B.RiskCountry,A.[Counterparty/Issuer/Collateral Name],A.[Client No],A.[Contract Collateral ID],A.[Maturity Date],A.[Remaining Year(s) to Maturity],A.[Org Ccy],A.[Credit Outstanding (Org Ccy)],A.[Credit Outstanding (EUR Equ)],A.[NetCreditOutstandingAmountEUR],A.[InternalInfo],A.[PD],A.[(1-ER)],A.[Credit Risk Amount(EUR Equ)],A.[NetCredit Risk Amount(EUR Equ)],A.[(1-ER_45)]/(Select [LGD_mod] from [ScenarioAnalyze_ConcentrationRiskCHINA_Date]) as 'ModifiedLGD',0 as 'New_LGD',0 as 'CreditRiskAmountEUREquER45',0 as 'NetCreditRiskAmountEUREquER45',A.[CoreDefinition],A.[ClientGroup],A.[ClientGroupName],0 as 'MaturityWithoutCapFloor',0 as 'EaDweigthedMaturityWithoutCapFloor',0 as 'PDxFinalEaD',0 as 'LGDfinalEaDweighted' from [ScenarioAnalyze_ConcentrationRiskCHINA_Details] A INNER JOIN CUSTOMER_INFO B on A.[Client No]=B.ClientNo where [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - DETAILS WORKSHEET")
        worksheet1.Import(dt1, False, 2, 0)

        Dim DETAILS_LastRow As Integer = 0
        If dt1.Rows.Count > 0 Then
            DETAILS_LastRow = dt1.Rows.Count + 2

            Dim RangeDETAILS_T As CellRange = worksheet1.Range("T3:T" & DETAILS_LastRow)
            RangeDETAILS_T.Formula = "=S3*Totals!$H$4"
            Dim RangeDETAILS_U As CellRange = worksheet1.Range("U3:U" & DETAILS_LastRow)
            RangeDETAILS_U.Formula = "=M3*O3*T3"
            Dim RangeDETAILS_V As CellRange = worksheet1.Range("V3:V" & DETAILS_LastRow)
            RangeDETAILS_V.Formula = "=M3*O3*T3"
            Dim RangeDETAILS_Z As CellRange = worksheet1.Range("Z3:Z" & DETAILS_LastRow)
            RangeDETAILS_Z.Formula = "=ROUND((IF(OR(EXACT(H3;DATE(9999;12;31));ISBLANK(H3));DATEDIF($F$1;DATE(YEAR($F$1);MONTH($F$1)+6;DAY($F$1));""d"");DATEDIF($F$1;H3;""d"")))/365,25;2)"
            Dim RangeDETAILS_AA As CellRange = worksheet1.Range("AA3:AA" & DETAILS_LastRow)
            RangeDETAILS_AA.Formula = "=M3*Z3"
            Dim RangeDETAILS_AB As CellRange = worksheet1.Range("AB3:AB" & DETAILS_LastRow)
            RangeDETAILS_AB.Formula = "=M3*O3"
            Dim RangeDETAILS_AC As CellRange = worksheet1.Range("AC3:AC" & DETAILS_LastRow)
            RangeDETAILS_AC.Formula = "=M3*T3"
        End If

        'FILL TOTALS
        workbook.Worksheets(0).Cells("A2").Value = "CHINA Stress Test - Calculation Expected/Unexpected Loss and Granularity approach for Business Date: " & rd
        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet.ClearContents(worksheet("A9:T10000"))

        Me.QueryText = "SELECT [ClientGroup],[ClientGroupName],0 as 'SubBorrowersCounter',0 as 'FinalEadTotalSum',[LGD] FROM  [ScenarioAnalyze_ConcentrationRiskCHINA_Totals] where [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - TOTALS WORKSHEET")
        worksheet.Import(dt, False, 8, 0)

        Dim TOTALS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            TOTALS_LastRow = dt.Rows.Count + 8



            Dim RangeTOTALS_C As CellRange = worksheet.Range("C9:C" & TOTALS_LastRow)
            RangeTOTALS_C.Formula = "=COUNTIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9)"
            Dim RangeTOTALS_D As CellRange = worksheet.Range("D9:D" & TOTALS_LastRow)
            RangeTOTALS_D.Formula = "=SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$M$3:$M$" & DETAILS_LastRow & ")"
            Dim RangeTOTALS_F As CellRange = worksheet.Range("F9:F" & TOTALS_LastRow)
            RangeTOTALS_F.Formula = "=IF(ISERROR((SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D9);0;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D9)"
            Dim RangeTOTALS_G As CellRange = worksheet.Range("G9:G" & TOTALS_LastRow)
            RangeTOTALS_G.Formula = "=MAX(F9;0,0003)*IF(EXACT(0;F9);0;1)"
            Dim RangeTOTALS_H As CellRange = worksheet.Range("H9:H" & TOTALS_LastRow)
            RangeTOTALS_H.Formula = "=IF(G9-F9>0;1;0)"
            Dim RangeTOTALS_I As CellRange = worksheet.Range("I9:I" & TOTALS_LastRow)
            RangeTOTALS_I.Formula = "=IF(ISERROR(MAX(1;MIN(5;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D9)));""n.a."";" & "MAX(1;MIN(5;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D9)))"
            Dim RangeTOTALS_J As CellRange = worksheet.Range("J9:J" & TOTALS_LastRow)
            RangeTOTALS_J.Formula = "=0,12*((1-EXP(-50*G9))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*G9))/(1-EXP(-50))))"
            Dim RangeTOTALS_K As CellRange = worksheet.Range("K9:K" & TOTALS_LastRow)
            RangeTOTALS_K.Formula = "=IF(E9<>0,45;J9*$H$5+J9;J9)"
            Dim RangeTOTALS_L As CellRange = worksheet.Range("L9:L" & TOTALS_LastRow)
            RangeTOTALS_L.Formula = "=IF(ISERROR((0,11852-0,05478*LN(G9))^2);""n.a."";" & "(0,11852-0,05478*LN(G9))^2)"
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Calulate Fisrt Columns O and P to get K* Value
            Dim RangeTOTALS_O As CellRange = worksheet.Range("O9:O" & TOTALS_LastRow)
            RangeTOTALS_O.Formula = "=D9/SUM($D$9:$D$" & TOTALS_LastRow & ")"
            Dim RangeTOTALS_P As CellRange = worksheet.Range("P9:P" & TOTALS_LastRow)
            RangeTOTALS_P.Formula = "=IF(ISERROR(N9/D9);0;N9/D9)"
            worksheet.Cells("L3").Formula = "=SUMPRODUCT(O9:O" & TOTALS_LastRow & ";P9:P" & TOTALS_LastRow & ")"
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim RangeTOTALS_M As CellRange = worksheet.Range("M9:M" & TOTALS_LastRow)
            RangeTOTALS_M.Formula = "=IF(ISERROR((E9*NORMDIST(  (1/(1-K9))^0,5    *   NORMINV(G9;0;1)    +    (K9/(1-K9))^0,5  *  NORMINV($L$6;0;1);0;1;TRUE)   - E9*G9   )*( (1+(K9-2,5)*L9) / (1-1,5*L9)  )*12,5*1,06);""n.a."";" & " (E9*NORMDIST(  (1/(1-K9))^0,5    *   NORMINV(G9;0;1)    +    (K9/(1-K9))^0,5  *  NORMINV($L$6;0;1);0;1;TRUE)   - E9*G9   )*( (1+(I9-2,5)*L9) / (1-1,5*L9)  )*12,5*1,06)"
            Dim RangeTOTALS_N As CellRange = worksheet.Range("N9:N" & TOTALS_LastRow)
            RangeTOTALS_N.Formula = "=IF(ISERROR(M9*D9*0,08);0;M9*D9*0,08)"
            Dim RangeTOTALS_Q As CellRange = worksheet.Range("Q9:Q" & TOTALS_LastRow)
            RangeTOTALS_Q.Formula = "=E9*G9"
            Dim RangeTOTALS_R As CellRange = worksheet.Range("R9:R" & TOTALS_LastRow)
            RangeTOTALS_R.Formula = "=$J$4*E9*(1-E9)"
            Dim RangeTOTALS_S As CellRange = worksheet.Range("S9:S" & TOTALS_LastRow)
            RangeTOTALS_S.Formula = "=IF(ISERROR((E9^2+R9)/E9);0;(E9^2+R9)/E9)"
            Dim RangeTOTALS_T As CellRange = worksheet.Range("T9:T" & TOTALS_LastRow)
            RangeTOTALS_T.Formula = "=IF(ISERROR(O9^2*(($J$6*S9*(P9 + Q9) +$J$6*(P9 + Q9)^2 *(R9^2)/(E9^2))-P9*(S9+2*(P9 + Q9)*(R9^2)/(E9^2))));0;O9^2*(($J$6*S9*(P9 + Q9)+$J$6*(P9 + Q9)^2*(R9^2)/(E9^2))-P9*(S9+2*(P9 + Q9)*(R9^2)/(E9^2))))"
            '*****************************************
            worksheet.Cells("T8").Formula = "=SUM(T9:T" & TOTALS_LastRow & ")/(2*$L$3)"
            '+++++++++++++++++++++++++++++++++++++++++
            'Calculate Results
            'Expected Loss
            worksheet.Cells("C5").Formula = "=SUM(Details!V3:V" & DETAILS_LastRow & ")"
            'Unexpected Loss
            worksheet.Cells("D5").Formula = "=SUM(N9:N" & TOTALS_LastRow & ")"
            'Granularity Approach
            worksheet.Cells("E5").Formula = "=T8*SUM(D9:D" & TOTALS_LastRow & ")"
        End If



        'Dim range1 As CellRange = worksheet.Range("A:AC")
        'Dim rangeFormatting1 As DevExpress.Spreadsheet.Formatting = range1.BeginUpdateFormatting()
        'rangeFormatting1.Font.Color = Color.Black
        'rangeFormatting1.Fill.BackgroundColor = Color.White
        'range1.EndUpdateFormatting(rangeFormatting1)

        'Dim range As CellRange = worksheet1.Range("A:AC")
        'Dim rangeFormatting As DevExpress.Spreadsheet.Formatting = range.BeginUpdateFormatting()
        'rangeFormatting.Font.Color = Color.Black
        'rangeFormatting.Fill.BackgroundColor = Color.White
        'range.EndUpdateFormatting(rangeFormatting)

        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
    End Sub

    Private Sub BgwExcelLoad_CN_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad_CN.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized

        c.Text = "CHINA Stress Test - Excel File calculation"
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.Xlsx)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "EXCEL FILE - FINANCIAL INSITUTIONS STRESS TEST"
    Private Sub LoadExcelFile_FI_btn_Click(sender As Object, e As EventArgs) Handles LoadExcelFile_FI_btn.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File for Stress Tests FINANCIAL INSTITUTIONS - Risk Date:" & Me.ScenarioAnalysisDate_lbl.Text)

            BgwExcelLoad_FI = New BackgroundWorker
            BgwExcelLoad_FI.WorkerReportsProgress = True
            BgwExcelLoad_FI.RunWorkerAsync()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try
    End Sub

    Private Sub BgwExcelLoad_FI_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwExcelLoad_FI.DoWork
        Dim rd As Date = Me.ScenarioAnalysisDate_lbl.Text
        Dim rdsql As String = rd.ToString("yyyyMMdd")
        '***********************************************************************
        '*******EXCEL FILES DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='EXCEL_FILES_DIR_STRESS_TEST_FI' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        ExcelFileName = cmd.ExecuteScalar
        '***********************************************************************
        cmd.Connection.Close()

        SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with basic Parameters for the Stress Test FINANCIAL INSTITUTIONS Calculation")
        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument(ExcelFileName, DocumentFormat.Xlsx)
        Dim worksheet As Worksheet = workbook.Worksheets(0)
        Dim worksheet1 As Worksheet = workbook.Worksheets(1)

        Dim LGDx As Double = Me.LGD_FI_SpinEdit.Text
        workbook.Worksheets(0).Cells("H4").Value = LGDx
        Dim ColerationIncrease As Double = Me.Colleration_FI_SpinEdit.EditValue
        workbook.Worksheets(0).Cells("H5").Value = ColerationIncrease
        Dim ObligorRateNoches As Double = Me.ObligorRate_Mod_FI_SpinEdit.Text
        workbook.Worksheets(0).Cells("H6").Value = ObligorRateNoches
        Dim LevelOfConfidence As Double = Me.LevelConfidence_General_SpinEdit.Text
        workbook.Worksheets(0).Cells("L6").Value = LevelOfConfidence
        'Stress Test Values
        'Dim ExpectedLoss_Test As Double = Me.ExpectedLoss_FI_TextEdit.Text
        'workbook.Worksheets(0).Cells("C5").Value = ExpectedLoss_Test
        'Dim UnexpectedLoss_Test As Double = Me.UnexpectedLoss_FI_TextEdit.Text
        'workbook.Worksheets(0).Cells("D5").Value = UnexpectedLoss_Test
        'Dim GA_Test As Double = Me.Granularity_FI_TextEdit.Text
        'workbook.Worksheets(0).Cells("E5").Value = GA_Test
        'Production Values
        Dim ExpectedLoss_Prod As Double = Me.ExpectedLoss_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("C6").Value = ExpectedLoss_Prod
        Dim UnexpectedLoss_Prod As Double = Me.UnexpectedLoss_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("D6").Value = UnexpectedLoss_Prod
        Dim GA_Prod As Double = Me.Granularity_Live_TextEdit.Text
        workbook.Worksheets(0).Cells("E6").Value = GA_Prod

        'FILL DETAILS
        workbook.Worksheets(1).Cells("A1").Value = "FINANCIAL INSTITUTIONS Stress Test Details - Calculation Expected/Unexpected Loss and Granularity approach for Business Date:"
        workbook.Worksheets(1).Cells("F1").Value = rd
        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet1.ClearContents(worksheet1("A3:AC10000"))

        '+++++++++++++++++++++++++++++
        Me.QueryText = "SELECT [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)]/(Select [LGD_mod] from [ScenarioAnalyze_ConcentrationRiskTBA_Date]) as 'ModifiedLGD',0 as 'New_LGD',0 as 'CreditRiskAmountEUREquER45',0 as 'NetCreditRiskAmountEUREquER45',[CoreDefinition],[ClientGroup],[ClientGroupName],0 as 'MaturityWithoutCapFloor',0 as 'EaDweigthedMaturityWithoutCapFloor',0 as 'PDxFinalEaD',0 as 'LGDfinalEaDweighted' from [ScenarioAnalyze_ConcentrationRiskTBA_Details] where [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - DETAILS WORKSHEET")
        worksheet1.Import(dt1, False, 2, 0)

        Dim DETAILS_LastRow As Integer = 0
        If dt1.Rows.Count > 0 Then
            DETAILS_LastRow = dt1.Rows.Count + 2

            Dim RangeDETAILS_T As CellRange = worksheet1.Range("T3:T" & DETAILS_LastRow)
            RangeDETAILS_T.Formula = "=S3*Totals!$H$4"
            Dim RangeDETAILS_U As CellRange = worksheet1.Range("U3:U" & DETAILS_LastRow)
            RangeDETAILS_U.Formula = "=M3*O3*T3"
            Dim RangeDETAILS_V As CellRange = worksheet1.Range("V3:V" & DETAILS_LastRow)
            RangeDETAILS_V.Formula = "=M3*O3*T3"
            Dim RangeDETAILS_Z As CellRange = worksheet1.Range("Z3:Z" & DETAILS_LastRow)
            RangeDETAILS_Z.Formula = "=ROUND((IF(OR(EXACT(H3;DATE(9999;12;31));ISBLANK(H3));DATEDIF($F$1;DATE(YEAR($F$1);MONTH($F$1)+6;DAY($F$1));""d"");DATEDIF($F$1;H3;""d"")))/365,25;2)"
            Dim RangeDETAILS_AA As CellRange = worksheet1.Range("AA3:AA" & DETAILS_LastRow)
            RangeDETAILS_AA.Formula = "=M3*Z3"
            Dim RangeDETAILS_AB As CellRange = worksheet1.Range("AB3:AB" & DETAILS_LastRow)
            RangeDETAILS_AB.Formula = "=M3*O3"
            Dim RangeDETAILS_AC As CellRange = worksheet1.Range("AC3:AC" & DETAILS_LastRow)
            RangeDETAILS_AC.Formula = "=M3*T3"
        End If

        'FILL TOTALS
        workbook.Worksheets(0).Cells("A2").Value = "FINANCIAL INSTITUTIONS Stress Test - Calculation Expected/Unexpected Loss and Granularity approach for Business Date: " & rd
        SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
        worksheet.ClearContents(worksheet("A9:T10000"))

        Me.QueryText = "SELECT [ClientGroup],[ClientGroupName],0 as 'SubBorrowersCounter',0 as 'FinalEadTotalSum',[LGD] FROM  [ScenarioAnalyze_ConcentrationRiskTBA_Totals] where [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File - TOTALS WORKSHEET")
        worksheet.Import(dt, False, 8, 0)

        Dim TOTALS_LastRow As Integer = 0
        If dt.Rows.Count > 0 Then
            TOTALS_LastRow = dt.Rows.Count + 8



            Dim RangeTOTALS_C As CellRange = worksheet.Range("C9:C" & TOTALS_LastRow)
            RangeTOTALS_C.Formula = "=COUNTIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9)"
            Dim RangeTOTALS_D As CellRange = worksheet.Range("D9:D" & TOTALS_LastRow)
            RangeTOTALS_D.Formula = "=SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$M$3:$M$" & DETAILS_LastRow & ")"
            Dim RangeTOTALS_F As CellRange = worksheet.Range("F9:F" & TOTALS_LastRow)
            RangeTOTALS_F.Formula = "=IF(ISERROR((SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D9);0;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AB$3:$AB$" & DETAILS_LastRow & "))/D9)"
            Dim RangeTOTALS_G As CellRange = worksheet.Range("G9:G" & TOTALS_LastRow)
            RangeTOTALS_G.Formula = "=MAX(F9;0,0003)*IF(EXACT(0;F9);0;1)"
            Dim RangeTOTALS_H As CellRange = worksheet.Range("H9:H" & TOTALS_LastRow)
            RangeTOTALS_H.Formula = "=IF(G9-F9>0;1;0)"
            Dim RangeTOTALS_I As CellRange = worksheet.Range("I9:I" & TOTALS_LastRow)
            RangeTOTALS_I.Formula = "=IF(ISERROR(MAX(1;MIN(5;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D9)));""n.a."";" & "MAX(1;MIN(5;(SUMIF(Details!$X$3:$X$" & DETAILS_LastRow & ";A9;Details!$AA$3:$AA$" & DETAILS_LastRow & "))/D9)))"
            Dim RangeTOTALS_J As CellRange = worksheet.Range("J9:J" & TOTALS_LastRow)
            RangeTOTALS_J.Formula = "=0,12*((1-EXP(-50*G9))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*G9))/(1-EXP(-50))))"
            Dim RangeTOTALS_K As CellRange = worksheet.Range("K9:K" & TOTALS_LastRow)
            RangeTOTALS_K.Formula = "=IF(E9<>0,45;J9*$H$5+J9;J9)"
            Dim RangeTOTALS_L As CellRange = worksheet.Range("L9:L" & TOTALS_LastRow)
            RangeTOTALS_L.Formula = "=IF(ISERROR((0,11852-0,05478*LN(G9))^2);""n.a."";" & "(0,11852-0,05478*LN(G9))^2)"
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Calulate Fisrt Columns O and P to get K* Value
            Dim RangeTOTALS_O As CellRange = worksheet.Range("O9:O" & TOTALS_LastRow)
            RangeTOTALS_O.Formula = "=D9/SUM($D$9:$D$" & TOTALS_LastRow & ")"
            Dim RangeTOTALS_P As CellRange = worksheet.Range("P9:P" & TOTALS_LastRow)
            RangeTOTALS_P.Formula = "=IF(ISERROR(N9/D9);0;N9/D9)"
            worksheet.Cells("L3").Formula = "=SUMPRODUCT(O9:O" & TOTALS_LastRow & ";P9:P" & TOTALS_LastRow & ")"
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim RangeTOTALS_M As CellRange = worksheet.Range("M9:M" & TOTALS_LastRow)
            RangeTOTALS_M.Formula = "=IF(ISERROR((E9*NORMDIST(  (1/(1-K9))^0,5    *   NORMINV(G9;0;1)    +    (K9/(1-K9))^0,5  *  NORMINV($L$6;0;1);0;1;TRUE)   - E9*G9   )*( (1+(K9-2,5)*L9) / (1-1,5*L9)  )*12,5*1,06);""n.a."";" & " (E9*NORMDIST(  (1/(1-K9))^0,5    *   NORMINV(G9;0;1)    +    (K9/(1-K9))^0,5  *  NORMINV($L$6;0;1);0;1;TRUE)   - E9*G9   )*( (1+(I9-2,5)*L9) / (1-1,5*L9)  )*12,5*1,06)"
            Dim RangeTOTALS_N As CellRange = worksheet.Range("N9:N" & TOTALS_LastRow)
            RangeTOTALS_N.Formula = "=IF(ISERROR(M9*D9*0,08);0;M9*D9*0,08)"
            Dim RangeTOTALS_Q As CellRange = worksheet.Range("Q9:Q" & TOTALS_LastRow)
            RangeTOTALS_Q.Formula = "=E9*G9"
            Dim RangeTOTALS_R As CellRange = worksheet.Range("R9:R" & TOTALS_LastRow)
            RangeTOTALS_R.Formula = "=$J$4*E9*(1-E9)"
            Dim RangeTOTALS_S As CellRange = worksheet.Range("S9:S" & TOTALS_LastRow)
            RangeTOTALS_S.Formula = "=IF(ISERROR((E9^2+R9)/E9);0;(E9^2+R9)/E9)"
            Dim RangeTOTALS_T As CellRange = worksheet.Range("T9:T" & TOTALS_LastRow)
            RangeTOTALS_T.Formula = "=IF(ISERROR(O9^2*(($J$6*S9*(P9 + Q9) +$J$6*(P9 + Q9)^2 *(R9^2)/(E9^2))-P9*(S9+2*(P9 + Q9)*(R9^2)/(E9^2))));0;O9^2*(($J$6*S9*(P9 + Q9)+$J$6*(P9 + Q9)^2*(R9^2)/(E9^2))-P9*(S9+2*(P9 + Q9)*(R9^2)/(E9^2))))"
            '*****************************************
            worksheet.Cells("T8").Formula = "=SUM(T9:T" & TOTALS_LastRow & ")/(2*$L$3)"
            '+++++++++++++++++++++++++++++++++++++++++
            'Calculate Results
            'Expected Loss
            worksheet.Cells("C5").Formula = "=SUM(Details!V3:V" & DETAILS_LastRow & ")"
            'Unexpected Loss
            worksheet.Cells("D5").Formula = "=SUM(N9:N" & TOTALS_LastRow & ")"
            'Granularity Approach
            worksheet.Cells("E5").Formula = "=T8*SUM(D9:D" & TOTALS_LastRow & ")"
        End If

        'Dim range1 As CellRange = worksheet.Range("A:AC")
        'Dim rangeFormatting1 As DevExpress.Spreadsheet.Formatting = range1.BeginUpdateFormatting()
        'rangeFormatting1.Font.Color = Color.Black
        'rangeFormatting1.Fill.BackgroundColor = Color.White
        'range1.EndUpdateFormatting(rangeFormatting1)

        'Dim range As CellRange = worksheet1.Range("A:AC")
        'Dim rangeFormatting As DevExpress.Spreadsheet.Formatting = range.BeginUpdateFormatting()
        'rangeFormatting.Font.Color = Color.Black
        'rangeFormatting.Fill.BackgroundColor = Color.White
        'range.EndUpdateFormatting(rangeFormatting)

        workbook.SaveDocument(ExcelFileName, DocumentFormat.OpenXml)
    End Sub

    Private Sub BgwExcelLoad_FI_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwExcelLoad_FI.RunWorkerCompleted
        Dim c As New ExcelForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized

        c.Text = "FINANCIAL INSTITUTIONS Stress Test - Excel File calculation"
        c.SpreadsheetControl1.ReadOnly = True

        workbook = c.SpreadsheetControl1.Document
        Using stream As New FileStream(ExcelFileName, FileMode.Open)
            workbook.LoadDocument(stream, DocumentFormat.Xlsx)
        End Using

        'worksheet = c.SpreadsheetControl1.Document.Worksheets(0)


        SplashScreenManager.CloseForm(False)
    End Sub
#End Region



    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl.Name = GridControl1.Name Then
            Dim view As GridView = TryCast(GridControl1.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "SubBorrowersCounter"
                        args.Contents.Text = "Count of the Client Group Contracts where PD<>0 and Contract Type<>LIMIT"
                    Case Is = "FinalEadTotalSum"
                        args.Contents.Text = "Sum of Net credit outstanding amount for each Client Group"
                    Case Is = "LGD"
                        args.Contents.Text = "from (ER1)"
                    Case Is = "PD_EaD_weighted"
                        args.Contents.Text = "PD*Net Credit outstanding Amount EUR for each client in Group/Total Sum Net Credit outstanding Amount for each Client Group"
                    Case Is = "PD_3bps_floor"
                        args.Contents.Text = "Max between (PD EaD weigthed and 0,0003) * (If (PD EaD weigthed)=0 then 0 else 1)"
                    Case Is = "IndicatorOfFloor"
                        args.Contents.Text = "If [PD (3bps floor)]-[PD (EaD weigthed)]>0 then 1 else 0"
                    Case Is = "MaturityEADweigthed"
                        args.Contents.Text = "Sum [EaD weighted maturity (without cap, floor)/final EaD (total sum)-> Variable 2: Minimum between Number:5 and Variable 1-> Maximum between 1 and Variable 2"
                    Case Is = "R_CoefficientOfColleration"
                        args.Contents.Text = "0,12*((1-EXP(-50*PD))/(1-EXP(-50)))" & vbNewLine & _
                            "+0,24*(1-((1-EXP(-50*PD))/(1-EXP(-50)))) where EXP=e=2.71828182845904"
                    Case Is = "b_MaturityAdjustment"
                        args.Contents.Text = "b=(0,11852-0,05478*Log(PD))^2"
                    Case Is = "RW_RiskWeightedExposure"
                        args.Contents.Text = "(LGD* NORMDIST((1/(1-R))^0,5*NORMINV(PD;0;1)+(R/(1-R))^0,5" & vbNewLine _
                                             & "* NORMINV(Level of confidence;0;1);0;1;TRUE)- LGD*PD)*((1+(Maturity(EaD weigthed)-2,5)*b) / (1-1,5*b))*12,5*1,06) " & vbNewLine _
                                             & "where NORMDIST=cumulative distribution function for a standard normal random variable x  and " & vbNewLine _
                                             & "NORMINV=inverse cumulative distribution function for a standard normal random variable "
                    Case Is = "UL_UnexpectedLoss"
                        args.Contents.Text = "RW*Final EaD*8,00%"
                    Case Is = "s_i"
                        args.Contents.Text = "Final EAD/Sum Final EaD"
                    Case Is = "K_i"
                        args.Contents.Text = "Unexpected Loss/Final EaD"
                    Case Is = "R_i"
                        args.Contents.Text = "LGD * PD"
                    Case Is = "VLGD_i"
                        args.Contents.Text = "(γ) nü value * LGD * (1 - LGD)"
                    Case Is = "C_i"
                        args.Contents.Text = "Power(LGD,2) + VLGD/LGD"
                    Case Is = "GA_n"
                        args.Contents.Text = "S_i^2*((Delta*C_i*(K_i+R_i) +Delta*(K_i+R_i)^2 * (VLGD^2)/(LGD^2) ) -K_i*(C_i+2* (K_i+R_i)*(VLGD^2)/(LGD^2))"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


        If e.SelectedControl.Name = GridControl5.Name Then
            Dim view As GridView = TryCast(GridControl5.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "SubBorrowersCounter"
                        args.Contents.Text = "Count of the Client Group Contracts where PD<>0 and Contract Type<>LIMIT"
                    Case Is = "FinalEadTotalSum"
                        args.Contents.Text = "Sum of Net credit outstanding amount for each Client Group"
                    Case Is = "LGD"
                        args.Contents.Text = "from (ER1)"
                    Case Is = "PD_EaD_weighted"
                        args.Contents.Text = "PD*Net Credit outstanding Amount EUR for each client in Group/Total Sum Net Credit outstanding Amount for each Client Group"
                    Case Is = "PD_3bps_floor"
                        args.Contents.Text = "Max between (PD EaD weigthed and 0,0003) * (If (PD EaD weigthed)=0 then 0 else 1)"
                    Case Is = "IndicatorOfFloor"
                        args.Contents.Text = "If [PD (3bps floor)]-[PD (EaD weigthed)]>0 then 1 else 0"
                    Case Is = "MaturityEADweigthed"
                        args.Contents.Text = "Sum [EaD weighted maturity (without cap, floor)/final EaD (total sum)-> Variable 2: Minimum between Number:5 and Variable 1-> Maximum between 1 and Variable 2"
                    Case Is = "R_CoefficientOfColleration"
                        args.Contents.Text = "0,12*((1-EXP(-50*PD))/(1-EXP(-50)))" & vbNewLine & _
                            "+0,24*(1-((1-EXP(-50*PD))/(1-EXP(-50)))) where EXP=e=2.71828182845904"
                    Case Is = "b_MaturityAdjustment"
                        args.Contents.Text = "b=(0,11852-0,05478*Log(PD))^2"
                    Case Is = "RW_RiskWeightedExposure"
                        args.Contents.Text = "(LGD* NORMDIST((1/(1-R))^0,5*NORMINV(PD;0;1)+(R/(1-R))^0,5" & vbNewLine _
                                             & "* NORMINV(Level of confidence;0;1);0;1;TRUE)- LGD*PD)*((1+(Maturity(EaD weigthed)-2,5)*b) / (1-1,5*b))*12,5*1,06) " & vbNewLine _
                                             & "where NORMDIST=cumulative distribution function for a standard normal random variable x  and " & vbNewLine _
                                             & "NORMINV=inverse cumulative distribution function for a standard normal random variable "
                    Case Is = "UL_UnexpectedLoss"
                        args.Contents.Text = "RW*Final EaD*8,00%"
                    Case Is = "s_i"
                        args.Contents.Text = "Final EAD/Sum Final EaD"
                    Case Is = "K_i"
                        args.Contents.Text = "Unexpected Loss/Final EaD"
                    Case Is = "R_i"
                        args.Contents.Text = "LGD * PD"
                    Case Is = "VLGD_i"
                        args.Contents.Text = "(γ) nü value * LGD * (1 - LGD)"
                    Case Is = "C_i"
                        args.Contents.Text = "Power(LGD,2) + VLGD/LGD"
                    Case Is = "GA_n"
                        args.Contents.Text = "S_i^2*((Delta*C_i*(K_i+R_i) +Delta*(K_i+R_i)^2 * (VLGD^2)/(LGD^2) ) -K_i*(C_i+2* (K_i+R_i)*(VLGD^2)/(LGD^2))"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


        If e.SelectedControl.Name = GridControl3.Name Then
            Dim view As GridView = TryCast(GridControl3.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "SubBorrowersCounter"
                        args.Contents.Text = "Count of the Client Group Contracts where PD<>0 and Contract Type<>LIMIT"
                    Case Is = "FinalEadTotalSum"
                        args.Contents.Text = "Sum of Net credit outstanding amount for each Client Group"
                    Case Is = "LGD"
                        args.Contents.Text = "from (ER1)"
                    Case Is = "PD_EaD_weighted"
                        args.Contents.Text = "PD*Net Credit outstanding Amount EUR for each client in Group/Total Sum Net Credit outstanding Amount for each Client Group"
                    Case Is = "PD_3bps_floor"
                        args.Contents.Text = "Max between (PD EaD weigthed and 0,0003) * (If (PD EaD weigthed)=0 then 0 else 1)"
                    Case Is = "IndicatorOfFloor"
                        args.Contents.Text = "If [PD (3bps floor)]-[PD (EaD weigthed)]>0 then 1 else 0"
                    Case Is = "MaturityEADweigthed"
                        args.Contents.Text = "Sum [EaD weighted maturity (without cap, floor)/final EaD (total sum)-> Variable 2: Minimum between Number:5 and Variable 1-> Maximum between 1 and Variable 2"
                    Case Is = "R_CoefficientOfColleration"
                        args.Contents.Text = "0,12*((1-EXP(-50*PD))/(1-EXP(-50)))" & vbNewLine & _
                            "+0,24*(1-((1-EXP(-50*PD))/(1-EXP(-50)))) where EXP=e=2.71828182845904"
                    Case Is = "b_MaturityAdjustment"
                        args.Contents.Text = "b=(0,11852-0,05478*Log(PD))^2"
                    Case Is = "RW_RiskWeightedExposure"
                        args.Contents.Text = "(LGD* NORMDIST((1/(1-R))^0,5*NORMINV(PD;0;1)+(R/(1-R))^0,5" & vbNewLine _
                                             & "* NORMINV(Level of confidence;0;1);0;1;TRUE)- LGD*PD)*((1+(Maturity(EaD weigthed)-2,5)*b) / (1-1,5*b))*12,5*1,06) " & vbNewLine _
                                             & "where NORMDIST=cumulative distribution function for a standard normal random variable x  and " & vbNewLine _
                                             & "NORMINV=inverse cumulative distribution function for a standard normal random variable "
                    Case Is = "UL_UnexpectedLoss"
                        args.Contents.Text = "RW*Final EaD*8,00%"
                    Case Is = "s_i"
                        args.Contents.Text = "Final EAD/Sum Final EaD"
                    Case Is = "K_i"
                        args.Contents.Text = "Unexpected Loss/Final EaD"
                    Case Is = "R_i"
                        args.Contents.Text = "LGD * PD"
                    Case Is = "VLGD_i"
                        args.Contents.Text = "(γ) nü value * LGD * (1 - LGD)"
                    Case Is = "C_i"
                        args.Contents.Text = "Power(LGD,2) + VLGD/LGD"
                    Case Is = "GA_n"
                        args.Contents.Text = "S_i^2*((Delta*C_i*(K_i+R_i) +Delta*(K_i+R_i)^2 * (VLGD^2)/(LGD^2) ) -K_i*(C_i+2* (K_i+R_i)*(VLGD^2)/(LGD^2))"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If


        If e.SelectedControl.Name = GridControl2.Name Then
            Dim view As GridView = TryCast(GridControl2.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "NetCreditOutstandingAmountEUR"
                        args.Contents.Text = "CASHPLEDGE Consideration"
                    Case Is = "MaturityWithoutCapFloor"
                        args.Contents.Text = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" & vbNewLine _
                                             & "else Maturity Date-RiskDate/365,25"
                    Case Is = "EaDweigthedMaturityWithoutCapFloor"
                        args.Contents.Text = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
                    Case Is = "PDxFinalEaD"
                        args.Contents.Text = "PD * Net Credit outstanding Amount EUR"
                    Case Is = "LGDfinalEaDweighted"
                        args.Contents.Text = "(ER2) * Net Credit Outstanding Amount EUR"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If

        If e.SelectedControl.Name = GridControl6.Name Then
            Dim view As GridView = TryCast(GridControl6.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "NetCreditOutstandingAmountEUR"
                        args.Contents.Text = "CASHPLEDGE Consideration"
                    Case Is = "MaturityWithoutCapFloor"
                        args.Contents.Text = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" & vbNewLine _
                                             & "else Maturity Date-RiskDate/365,25"
                    Case Is = "EaDweigthedMaturityWithoutCapFloor"
                        args.Contents.Text = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
                    Case Is = "PDxFinalEaD"
                        args.Contents.Text = "PD * Net Credit outstanding Amount EUR"
                    Case Is = "LGDfinalEaDweighted"
                        args.Contents.Text = "(ER2) * Net Credit Outstanding Amount EUR"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If

        If e.SelectedControl.Name = GridControl4.Name Then
            Dim view As GridView = TryCast(GridControl4.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InColumn Then
                e.Info = New DevExpress.Utils.ToolTipControlInfo(e.SelectedControl.Name, "Content", "Info")
                Dim SuperTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
                Dim args As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs()
                args.Title.Image = Me.ImageCollection1.Images.Item(10)
                Dim ColumnFieldName As String = info.Column.FieldName.ToString
                args.Title.Text = "Info"
                Select Case ColumnFieldName
                    Case Is = "NetCreditOutstandingAmountEUR"
                        args.Contents.Text = "CASHPLEDGE Consideration"
                    Case Is = "MaturityWithoutCapFloor"
                        args.Contents.Text = "If Maturity=31.12.9999 then Maturity=DateAdd(6 Months + Riskdate)-RiskDate/365,25" & vbNewLine _
                                             & "else Maturity Date-RiskDate/365,25"
                    Case Is = "EaDweigthedMaturityWithoutCapFloor"
                        args.Contents.Text = "Maturity (without cap, floor) * Net credit outstanding Amount EUR"
                    Case Is = "PDxFinalEaD"
                        args.Contents.Text = "PD * Net Credit outstanding Amount EUR"
                    Case Is = "LGDfinalEaDweighted"
                        args.Contents.Text = "(ER2) * Net Credit Outstanding Amount EUR"
                End Select

                SuperTip.Setup(args)
                e.Info.SuperTip = SuperTip

            End If

        End If

    End Sub


End Class