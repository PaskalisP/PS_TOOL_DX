Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mail
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
Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class DailyEmail

  
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEVENT As New SqlConnection
    Dim cmdEVENT As New SqlCommand
  
    Dim CrystalRepDir As String = ""
    Dim ReportExpFile As String = "" 'Directory for the report creation REFINANCING_MATURITY_LIST
    Dim ReportExpRefiFile As String = ""

    Dim EXCELL As New Microsoft.Office.Interop.Excel.Application
    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    Dim xlWorksheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem

    Dim newCulture As System.Globalization.CultureInfo
    Dim OldCulture As System.Globalization.CultureInfo

    'Dim pkg As New Microsoft.SqlServer.Dts.Runtime.Package
    'Dim app As New Microsoft.SqlServer.Dts.Runtime.Application
    'Dim pkgResults As Microsoft.SqlServer.Dts.Runtime.DTSExecResult
    Dim SSISDirectory As String = Nothing


    Dim CBAIF As Double = Nothing 'CurrentImportBAISFile
    Dim LBAIF As Double = Nothing ' LastImportedBAISFile
    Dim COIFN As String = ""
    Dim CURRENT_PROC As String = Nothing
    Dim ACTIVE_PROC As String = ""

    Delegate Sub ChangeText()

    Private QueryText As String = ""
    Private conndt As New SqlConnection
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Dim ex As Integer
   

    Dim MaxProcDate As Date
   

    Const TabelleStart As String = "<HTML><BODY><TABLE BORDER='1' CELLSPACING='0' CELLPADDING='1'>"
    Const TabelleEnde As String = "</TABLE></BODY></HTML>"
    Const ZelleStart As String = "<TD WIDTH=""300"" ALIGN=""RIGHT"">"
    Const ZelleStartBackgroundBlue As String = "<TD WIDTH=""300"" ALIGN=""RIGHT"" bgcolor=""#2B3856"">"
    Const ZelleStartZahl As String = "<TD WIDTH=""150"" ALIGN=""RIGHT"">"
    Const ZelleStartResult As String = "<TD WIDTH=""150"" ALIGN=""RIGHT"">"
    Const ZelleEnde As String = "</TD>"

    Const ZweiteTabelleStart As String = "<HTML><BODY><TABLE BORDER='1' CELLSPACING='0' CELLPADDING='1'>"
    Const ZweiteTabelleEnde As String = "</TABLE></BODY></HTML>"



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
    Private Sub IMPORT_EVENTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.IMPORT_EVENTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

#Region "GRIDVIEWS_DEFAULT_SETTINGS"
    Private Sub EmailEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles EmailEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub EmailEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles EmailEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_EmailEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_EmailEvents_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
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
        Dim reportfooter As String = "DAILY EMAIL CREATION EVENTS"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
#End Region


    Private Sub DailyEmail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwDailyRiskEmail.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub DailyEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT


        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************


        'GET THE EMAIL RECEIVERS_TO
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_TO As String = ""
        For i = 0 To dt.Rows.Count - 1
            EMAIL_TO += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        Me.To_MemoEdit.Text = EMAIL_TO
        dt.Clear()

        'GET THE EMAIL RECEIVERS_CC
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS_CC'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_CC As String = ""
        For i = 0 To dt.Rows.Count - 1
            EMAIL_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        Me.CC_MemoEdit.Text = EMAIL_CC
        dt.Clear()

        'GET THE EMAIL RECEIVERS_BCC
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS_BCC'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_BCC As String = ""
        For i = 0 To dt.Rows.Count - 1
            EMAIL_BCC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        Me.BCC_MemoEdit.Text = EMAIL_BCC
        dt.Clear()

        'Get the dates from RISK LIMIT DAILY CONTROL where Risk Bearing Capacity<>0
        Me.QueryText = "select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where [RiskBearingCapacityCashPledge]<>0 ORDER BY [RLDC Date] desc  "
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            Dim RLDCdate As Date = row("RLDC Date")
            Dim FormatedRLDCDate As String = RLDCdate.ToString("dd.MM.yyyy")
            Me.EmailCreationDate.Properties.Items.Add(FormatedRLDCDate)
        Next
        Me.EmailCreationDate.Text = dt.Rows.Item(0).Item("RLDC Date")

        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        cmd.Connection.Open()
        MaxProcDate = cmd.ExecuteScalar
        cmd.Connection.Close()

        Me.IMPORT_EVENTSTableAdapter.FillByDAILYRISKEMAILDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub EmailCreationDate_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles EmailCreationDate.ButtonClick
        If e.Button.Caption = "Create Email" Then
            cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_GM' and [IdABTEILUNGSCODE]='REPORT'"
            cmd.Connection.Open()
            Dim EMAIL_STATUS As String = cmd.ExecuteScalar
            cmd.Connection.Close()
            If EMAIL_STATUS = "Y" Then
                If XtraMessageBox.Show("Should the daily Risk Overview E-Mail be generated?", "DAILY RISK OVERVIEW EMAIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    cmd.CommandText = "SELECT [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('OCBS')"
                    cmd.Connection.Open()
                    Dim CheckText As String = cmd.ExecuteScalar
                    cmd.Connection.Close()

                    Dim CheckDate As Date = DateSerial(Microsoft.VisualBasic.Left(CheckText, 4), Microsoft.VisualBasic.Mid(CheckText, 5, 2), Microsoft.VisualBasic.Right(CheckText, 2))
                    Dim CheckEmailCreationDate As Date = Me.EmailCreationDate.Text

                    If CheckDate <> CheckEmailCreationDate Then
                        If XtraMessageBox.Show("The Email Creation Date differs from the last NGS import Date!" & vbNewLine & " Should the daily Risk Overview E-Mail be generated?", "DAILY RISK OVERVIEW EMAIL - DATES ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                            If Me.BgwDailyRiskEmail.IsBusy = False Then
                                Me.To_MemoEdit.Properties.ReadOnly = True
                                Me.CC_MemoEdit.Properties.ReadOnly = True
                                Me.BCC_MemoEdit.Properties.ReadOnly = True
                                Me.Subject_TextEdit.Text = "DAILY RISK CONTROL OVERVIEW on " & Me.EmailCreationDate.Text
                                Me.EMAILProgressBar.Visible = True
                                Me.EMAILProgressBar.Value = 0
                                Me.BgwDailyRiskEmail.RunWorkerAsync()
                            End If
                        Else
                            Exit Sub
                        End If
                    ElseIf CheckDate = CheckEmailCreationDate Then
                        If Me.BgwDailyRiskEmail.IsBusy = False Then
                            Me.To_MemoEdit.Properties.ReadOnly = True
                            Me.CC_MemoEdit.Properties.ReadOnly = True
                            Me.BCC_MemoEdit.Properties.ReadOnly = True
                            Me.Subject_TextEdit.Text = "DAILY RISK CONTROL OVERVIEW on " & Me.EmailCreationDate.Text
                            Me.EMAILProgressBar.Visible = True
                            Me.EMAILProgressBar.Value = 0
                            Me.BgwDailyRiskEmail.RunWorkerAsync()
                        End If
                    End If

                Else
                    Exit Sub

                End If

            Else
                XtraMessageBox.Show("The generation of the daily Risk E-mail is set to INVALID", "EMAIL GENERATION NOT POSSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If
        End If

    End Sub


    Private Sub BgwDailyRiskEmail_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwDailyRiskEmail.DoWork
        Try
            Me.BgwDailyRiskEmail.ReportProgress(1, "Start Daily Risk Control E-Mail creation on " & Me.EmailCreationDate.Text)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            'Ordner für exportierte Reports erstellen
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_GM_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_GM'"
            ReportExpFile = cmd.ExecuteScalar
            Me.BgwDailyRiskEmail.ReportProgress(5, "Create Temporary Report directory: " & ReportExpFile)
            System.IO.Directory.CreateDirectory(ReportExpFile)
            'EMAIL DATA DATE
            Dim EmailDataDate As Date = Me.EmailCreationDate.Text
            Dim SqlEmailDataDate As String = EmailDataDate.ToString("yyyy-MM-dd")
            Dim BaisRelatedFileNr As String = EmailDataDate.ToString("yyyyMMdd")
            'LOAD DATA
            Dim BANK As New Bank_Data
            Dim IRR As New InterestRateRisk
            Dim RLDC As New RiskLimitDailyControl
            Dim BT As New BusinessTypes
            Dim BTL As New BusinessTypesLiabilities
            Dim CRMK As New CreditRiskMak


            Dim STRESS_HO As New StressTestsHO
            Dim BALL_SHEET As New DailyBalanceSheets
            Dim PL_SHEET As New DailyProfitLossSheets
            Dim FX_CREDIT_EQUIV As New FxCreditEquivalentCalculation
            Dim IRS_CREDIT_EQUIV As New IrsCreditEquivalentCalculation
            '
            Me.BgwDailyRiskEmail.ReportProgress(6, "Load Bank Data")
            BANK.BANKTableAdapter.Fill(BANK.PSTOOLDataset.BANK)
            '
            Me.BgwDailyRiskEmail.ReportProgress(7, "Load Data from Dataset RISK CONTROLLING")
            IRR.RATERISK_DATETableAdapter.FillByRiskDate(IRR.RiskControllingDataSet.RATERISK_DATE, EmailDataDate)
            IRR.RATERISK_TOTALSTableAdapter.FillByRiskDate(IRR.RiskControllingDataSet.RATERISK_TOTALS, EmailDataDate)
            IRR.RATERISK_DETAILSTableAdapter.FillByRiskDate(IRR.RiskControllingDataSet.RATERISK_DETAILS, EmailDataDate)
            IRR.RATERISK_DELETIONSTableAdapter.FillByRiskDate(IRR.RiskControllingDataSet.RATERISK_DELETIONS, EmailDataDate)
            '
            RLDC.RISK_LIMIT_DAILY_CONTROLTableAdapter.Fill(RLDC.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL)
            RLDC.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter.FillByRepDate(RLDC.RiskControllingDataSet.TIME_DEP_OUTST_CLIENT_DEALS, EmailDataDate)
            '
            BT.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(BT.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, EmailDataDate)
            BT.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(BT.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, EmailDataDate)
            BTL.BusinessTypesLiabilitiesLiveTableAdapter.FillByBT_LIABLITIES_ALL(BTL.RiskControllingDataSet.BusinessTypesLiabilitiesLive, EmailDataDate)
            BTL.BusinessTypesLiabilitiesDetailsTableAdapter.FillByBT_LIABILITIES_DETAILS(BTL.RiskControllingDataSet.BusinessTypesLiabilitiesDetails, EmailDataDate)
            '
            CRMK.INDUSTRY_VALUESTableAdapter.Fill(CRMK.RiskControllingDataSet.INDUSTRY_VALUES)
            CRMK.COUNTRIESTableAdapter.Fill(CRMK.RiskControllingDataSet.COUNTRIES)
            CRMK.ContractTypeTableAdapter.Fill(CRMK.RiskControllingDataSet.ContractType)
            CRMK.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(CRMK.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, EmailDataDate)
            CRMK.MAK_REPORTTableAdapter.FillByMakDate(CRMK.RiskControllingDataSet.MAK_REPORT, EmailDataDate)
            CRMK.CREDIT_RISKTableAdapter.FillByCreditRiskDate(CRMK.RiskControllingDataSet.CREDIT_RISK, EmailDataDate)
            CRMK.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(CRMK.RiskControllingDataSet.MAK_CR_TOTALS, EmailDataDate)
            CRMK.MAK_ALLTableAdapter.FillByRiskDate(CRMK.RiskControllingDataSet.MAK_ALL, EmailDataDate)
            '
            'STRESS_HO.StressTestsLiquidHOTableAdapter.FillByStressDate(STRESS_HO.RiskControllingDataSet.StressTestsLiquidHO, EmailDataDate)
            '
            Me.BgwDailyRiskEmail.ReportProgress(7, "Load from Dataset PS TOOL Dataset-Daily Balance Sheets")
            BALL_SHEET.DailyBalanceSheetsTableAdapter.FillByBSDate(BALL_SHEET.PSTOOLDataset.DailyBalanceSheets, EmailDataDate)
            '
            PL_SHEET.DailyBalanceSheetsTableAdapter.FillByBSDate(PL_SHEET.PSTOOLDataset.DailyBalanceSheets, EmailDataDate)
            '
            Me.BgwDailyRiskEmail.ReportProgress(7, "Load from Dataset ACCOUNTING- FX Credit Equivelant Data")
            FX_CREDIT_EQUIV.FX_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(FX_CREDIT_EQUIV.AccountingDataSet.FX_CREDIT_EQUIVALENT_Details, EmailDataDate)
            FX_CREDIT_EQUIV.FX_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(FX_CREDIT_EQUIV.AccountingDataSet.FX_CREDIT_EQUIVALENT_Basic, EmailDataDate)
            '
            Me.BgwDailyRiskEmail.ReportProgress(7, "Load from Dataset ACCOUNTING- IRS Credit Equivelant Data")
            IRS_CREDIT_EQUIV.IRS_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(IRS_CREDIT_EQUIV.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Details, EmailDataDate)
            IRS_CREDIT_EQUIV.IRS_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(IRS_CREDIT_EQUIV.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Basic, EmailDataDate)
            '



            Me.BgwDailyRiskEmail.ReportProgress(10, "Start PDF Creation of the relevant Reports-Parameter:REPORT/EMAIL_GM_REPORTS/")
            'REPORTS CREATION
            Dim DateCurrent As New CrystalDecisions.Shared.ParameterValues()
            Dim DateFirst As New CrystalDecisions.Shared.ParameterValues
            Dim ValueCurrent As New CrystalDecisions.Shared.ParameterDiscreteValue() 'Fieldvalue für das letzte Datum
            Dim ValueFirst As New CrystalDecisions.Shared.ParameterDiscreteValue 'Fieldvalue für das erste Datum
            ValueCurrent.Value = EmailDataDate
            ValueFirst.Value = DateAdd(DateInterval.Day, -90, EmailDataDate)
            DateCurrent.Add(ValueCurrent)
            DateFirst.Add(ValueFirst)
            'Unterbericht Unterdrücken


            'DAILY RISK TABLES
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DAILY_RISK_TABLES')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DAILY_RISK_TABLES_ReportStatus As String = cmd.ExecuteScalar
            If DAILY_RISK_TABLES_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(15, "Create report DAILY RISK TABLES")
                Dim CrDailyRiskTables As New ReportDocument
                CrDailyRiskTables.Load(CrystalRepDir & "\DAILY_RISK_TABLES.rpt")
                CrDailyRiskTables.SetDataSource(CRMK.RiskControllingDataSet)
                CrDailyRiskTables.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrDailyRiskTables.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY RISK TABLES_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'BUSINESS TYPES - SUM
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('BusinessTypes_CreditPortfolio_SUM')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim BusinessTypes_CreditPortfolio_SUM_ReportStatus As String = cmd.ExecuteScalar
            If BusinessTypes_CreditPortfolio_SUM_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(16, "Create report BUSINESS TYPES-CREDIT PORTFOLIO (SUM)")
                Dim CrBusinessTypesSum As New ReportDocument
                CrBusinessTypesSum.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolio.rpt")
                CrBusinessTypesSum.SetDataSource(BT.RiskControllingDataSet)
                CrBusinessTypesSum.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrBusinessTypesSum.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\BUSINESS TYPES-CREDIT PORTFOLIO (SUM)_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'BUSINESS TYPES - Details
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('BusinessTypes_CreditPortfolioDetails')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim BusinessTypes_CreditPortfolioDetails_ReportStatus As String = cmd.ExecuteScalar
            If BusinessTypes_CreditPortfolioDetails_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(16, "Create report BUSINESS TYPES-CREDIT PORTFOLIO (DETAILS)")
                Dim CrBusinessTypesDetails As New ReportDocument
                CrBusinessTypesDetails.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolioDetails.rpt")
                CrBusinessTypesDetails.SetDataSource(BT.RiskControllingDataSet)
                CrBusinessTypesDetails.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrBusinessTypesDetails.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\BUSINESS TYPES-CREDIT PORTFOLIO (DETAILS)_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'BUSINESS TYPES LIABILITIES - SUM
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('BusinessTypes_Liabilities_SUM')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim BusinessTypes_Liabilities_SUM_ReportStatus As String = cmd.ExecuteScalar
            If BusinessTypes_Liabilities_SUM_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(16, "Create report BUSINESS TYPES-LIABILITIES (SUM)")
                Dim CrBusinessTypesLiabilitiesSum As New ReportDocument
                CrBusinessTypesLiabilitiesSum.Load(CrystalRepDir & "\BusinessTypes_Liabilities.rpt")
                CrBusinessTypesLiabilitiesSum.SetDataSource(BTL.RiskControllingDataSet)
                CrBusinessTypesLiabilitiesSum.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrBusinessTypesLiabilitiesSum.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\BUSINESS TYPES-LIABILITIES (SUM)_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'BUSINESS TYPES LIABILITIES - Details
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('BusinessTypes_LiabilitiesDetails')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim BusinessTypes_LiabilitiesDetails_ReportStatus As String = cmd.ExecuteScalar
            If BusinessTypes_LiabilitiesDetails_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(16, "Create report BUSINESS TYPES-LIABILITIES (DETAILS)")
                Dim CrBusinessTypesLiabilitiesDetails As New ReportDocument
                CrBusinessTypesLiabilitiesDetails.Load(CrystalRepDir & "\BusinessTypes_LiabilitiesDetails.rpt")
                CrBusinessTypesLiabilitiesDetails.SetDataSource(BTL.RiskControllingDataSet)
                CrBusinessTypesLiabilitiesDetails.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrBusinessTypesLiabilitiesDetails.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\BUSINESS TYPES-LIABILITIES (DETAILS)_" & BaisRelatedFileNr & ".pdf")
            End If


            'RISK LIMIT DAILY CONTROL
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('RISK_LIMIT_DAILY_CONTROL_REP')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim RISK_LIMIT_DAILY_CONTROL_REP_ReportStatus As String = cmd.ExecuteScalar
            If RISK_LIMIT_DAILY_CONTROL_REP_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(20, "Create report RISK LIMIT DAILY CONTROL")
                Dim CrRepRiskLimitDailyControl As New ReportDocument
                CrRepRiskLimitDailyControl.Load(CrystalRepDir & "\RISK_LIMIT_DAILY_CONTROL_REP.rpt")
                CrRepRiskLimitDailyControl.SetDataSource(RLDC.RiskControllingDataSet)
                CrRepRiskLimitDailyControl.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK LIMIT DAILY CONTROL.pdf")
            End If

            '
            'DAILY RISK CHART REPORT
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DAILY_RISK_CHART')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DAILY_RISK_CHART_ReportStatus As String = cmd.ExecuteScalar
            If DAILY_RISK_CHART_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(25, "Create report DAILY RISK CHART REPORT")
                Dim CrRepDailyRiskChart As New ReportDocument
                CrRepDailyRiskChart.Load(CrystalRepDir & "\DAILY_RISK_CHART.rpt")
                CrRepDailyRiskChart.SetDataSource(RLDC.RiskControllingDataSet)
                CrRepDailyRiskChart.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateFirst)
                CrRepDailyRiskChart.DataDefinition.ParameterFields(1).ApplyCurrentValues(DateCurrent)
                CrRepDailyRiskChart.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY RISK CHART REPORT_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'RISK BEARING CAPACITY CHART
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('RISK_BEARING_CAPACITY_CHART')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim RISK_BEARING_CAPACITY_CHART_ReportStatus As String = cmd.ExecuteScalar
            If RISK_BEARING_CAPACITY_CHART_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(30, "Create report RISK BEARING CAPACITY CHART")
                Dim CrRepRiskBearingCapacityChart As New ReportDocument
                CrRepRiskBearingCapacityChart.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CHART.rpt")
                CrRepRiskBearingCapacityChart.SetDataSource(RLDC.RiskControllingDataSet)
                CrRepRiskBearingCapacityChart.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateFirst)
                CrRepRiskBearingCapacityChart.DataDefinition.ParameterFields(1).ApplyCurrentValues(DateCurrent)
                CrRepRiskBearingCapacityChart.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY CHART REPORT.pdf")
            End If

            '
            'OBLIGO LIABILITY SURPLUS
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('ObligoLiabilitySurplus')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim ObligoLiabilitySurplus_ReportStatus As String = cmd.ExecuteScalar
            If ObligoLiabilitySurplus_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(30, "Create report OBLIGO LIABILITY SURPLUS")
                Dim CrRepObligoLiabilitySurplus As New ReportDocument
                If EmailDataDate <= DateSerial(2017, 6, 26) Then
                    CrRepObligoLiabilitySurplus.Load(CrystalRepDir & "\ObligoLiabilitySurplus.rpt")
                    CrRepObligoLiabilitySurplus.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepObligoLiabilitySurplus.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepObligoLiabilitySurplus.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\OBLIGO LIABILITY SURPLUS REPORT_" & BaisRelatedFileNr & ".pdf")
                Else
                    Dim ObligoLiabilitiesDa As New SqlDataAdapter("SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                    Dim ObligoLiabilitiesDataset As New DataSet("OBLIGO_REPORTING")
                    ObligoLiabilitiesDa.Fill(ObligoLiabilitiesDataset, "OBLIGO_SURPLUS_DETAILS")
                    CrRepObligoLiabilitySurplus.Load(CrystalRepDir & "\ObligoLiabilitySurplusNew.rpt")
                    CrRepObligoLiabilitySurplus.SetDataSource(ObligoLiabilitiesDataset)
                    CrRepObligoLiabilitySurplus.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepObligoLiabilitySurplus.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\OBLIGO LIABILITY SURPLUS REPORT_" & BaisRelatedFileNr & ".pdf")
                End If
            End If

            '
            'RISK BEARING CAPACITY CASH PLEDGE
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('RISK_BEARING_CAPACITY_TOTAL')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim RISK_BEARING_CAPACITY_TOTAL_ReportStatus As String = cmd.ExecuteScalar
            If RISK_BEARING_CAPACITY_TOTAL_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(35, "Create report RISK BEARING CAPACITY CASH PLEDGE")
                If EmailDataDate < DateSerial(2014, 7, 1) Then
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGEold.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate >= DateSerial(2014, 7, 1) And EmailDataDate <= DateSerial(2014, 12, 4) Then
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate > DateSerial(2014, 12, 4) And EmailDataDate <= DateSerial(2016, 3, 30) Then
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from05122014.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate > DateSerial(2016, 3, 30) And EmailDataDate <= DateSerial(2016, 8, 7) Then
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from31032016.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate > DateSerial(2016, 8, 7) And EmailDataDate <= DateSerial(2016, 10, 26) Then
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from08082016.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate > DateSerial(2016, 10, 26) And EmailDataDate <= DateSerial(2016, 12, 31) Then
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from27102016.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RLDC.RiskControllingDataSet)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate >= DateSerial(2017, 1, 1) Then
                    Dim RiskBearingCapacity_Da As New SqlDataAdapter("SELECT * FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                    Dim RiskBearingCapacityDataset As New DataSet("RBC")
                    RiskBearingCapacity_Da.Fill(RiskBearingCapacityDataset, "RISK_BEARING_CAPACITY_CALCULATIONS")
                    Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
                    CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_TOTAL.rpt")
                    CrRepRiskBearingCapacityCashPledge.SetDataSource(RiskBearingCapacityDataset)
                    CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & BaisRelatedFileNr & ".pdf")
                End If
            End If


            'INTEREST RATE RISK
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('INT_RATE_RISK_REP')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim INT_RATE_RISK_REP_ReportStatus As String = cmd.ExecuteScalar
            If INT_RATE_RISK_REP_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(40, "Create report INTEREST RATE RISK")
                If EmailDataDate < DateSerial(2018, 12, 31) Then
                    Dim CrRep As New ReportDocument
                    CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP.rpt")
                    CrRep.SetDataSource(IRR.RiskControllingDataSet)
                    CrRep.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRep.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\INTEREST RATE RISK_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate >= DateSerial(2018, 12, 31) Then
                    Dim IRR_DATE_Da As New SqlDataAdapter("Select * from [RATERISK DATE] where RateRiskDate='" & SqlEmailDataDate & "' ", conn)
                    Dim IRR_TOTALS_Da As New SqlDataAdapter("Select * from [RATERISK TOTALS] where [RISK DATE]='" & SqlEmailDataDate & "'", conn)

                    Dim IRR_Dataset As New DataSet("IRR")
                    IRR_DATE_Da.Fill(IRR_Dataset, "RATERISK DATE")
                    IRR_TOTALS_Da.Fill(IRR_Dataset, "RATERISK TOTALS")
                    Dim CrRep As New ReportDocument
                    CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP_Zinsschoks200bps.rpt")
                    CrRep.SetDataSource(IRR_Dataset)
                    CrRep.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRep.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\INTEREST RATE RISK_" & BaisRelatedFileNr & ".pdf")

                End If

            End If

                '
                'LIQUIDITY CHART
                'Me.BgwDailyRiskEmail.ReportProgress(45, "Create report LIQUIDITY CHART")
                'Dim Sfield As New CrystalDecisions.Shared.ParameterValues()
                'Dim SfieldFisrt As New CrystalDecisions.Shared.ParameterValues
                'Dim Svalue As New CrystalDecisions.Shared.ParameterDiscreteValue() 'Fieldvalue für das letzte Datum
                'Dim SvalueFisrt As New CrystalDecisions.Shared.ParameterDiscreteValue 'Fieldvalue für das erste Datum
                'Dim Quartal As Double = DatePart(DateInterval.Quarter, EmailDataDate)
                'Dim curYear As String = EmailDataDate.ToString("yyyy")
                'Select Case Quartal
                '    Case Is = 1
                '        SvalueFisrt.Value = DateSerial(curYear, 1, 1)
                '    Case Is = 2
                '        SvalueFisrt.Value = DateSerial(curYear, 4, 1)
                '    Case Is = 3
                '        SvalueFisrt.Value = DateSerial(curYear, 7, 1)
                '    Case Is = 4
                '        SvalueFisrt.Value = DateSerial(curYear, 10, 1)
                'End Select
                ''MsgBox(SvalueFisrt.Value)

                'Dim CrRepLiquidityChart As New ReportDocument
                'CrRepLiquidityChart.Load(CrystalRepDir & "\LIQUIDITY_CHART.rpt")
                'CrRepLiquidityChart.SetDataSource(RLDC.RiskControllingDataSet)
                'Svalue.Value = EmailDataDate
                'SfieldFisrt.Add(SvalueFisrt)
                'Sfield.Add(Svalue)
                ''MsgBox(Svalue.Value)
                'CrRepLiquidityChart.DataDefinition.ParameterFields(0).ApplyCurrentValues(SfieldFisrt)
                'CrRepLiquidityChart.DataDefinition.ParameterFields(1).ApplyCurrentValues(Sfield)
                'CrRepLiquidityChart.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY LIQUIDITY CHART - " & Quartal & ".Quarter.pdf")
                '
                'DAILY BALANCE SHEET
                cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DailyBalanceSheet')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DailyBalanceSheet_ReportStatus As String = cmd.ExecuteScalar
            If DailyBalanceSheet_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(50, "Create report DAILY BALANCE SHEET")
                Dim CrRepBalanceSheetDaily As New ReportDocument
                CrRepBalanceSheetDaily.Load(CrystalRepDir & "\Balance Sheet Daily.rpt")
                CrRepBalanceSheetDaily.SetDataSource(BALL_SHEET.PSTOOLDataset)
                CrRepBalanceSheetDaily.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepBalanceSheetDaily.PrintOptions.PaperSize = PaperSize.PaperA4
                CrRepBalanceSheetDaily.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY BALANCE SHEET_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'DAILY PROFIT + LOSS SHEET
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DailyProfitLossSheet')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DailyProfitLossSheet_ReportStatus As String = cmd.ExecuteScalar
            If DailyProfitLossSheet_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(55, "Create report DAILY PROFIT + LOSS SHEET")
                Dim CrRepProfitLossDaily As New ReportDocument
                CrRepProfitLossDaily.Load(CrystalRepDir & "\Profit and Loss Daily.rpt")
                CrRepProfitLossDaily.SetDataSource(PL_SHEET.PSTOOLDataset)
                CrRepProfitLossDaily.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepProfitLossDaily.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY PROFIT + LOSS SHEET_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'HGB Profit Loss
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('HGB_ProfitLoss')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim HGB_ProfitLoss_ReportStatus As String = cmd.ExecuteScalar
            If HGB_ProfitLoss_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report HGB - Profit Loss")
                Dim HGB_PL_Da As New SqlDataAdapter("SELECT * FROM [HGB_GV] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                Dim HGB_PL_dataset As New DataSet("HGB_GV")
                HGB_PL_Da.Fill(HGB_PL_dataset, "HGB_GV")
                Dim CrRepHGB_PL As New ReportDocument
                CrRepHGB_PL.Load(CrystalRepDir & "\HGB_GV_Daily.rpt")
                CrRepHGB_PL.SetDataSource(HGB_PL_dataset)
                CrRepHGB_PL.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepHGB_PL.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\HGB - Gewinn und Verlust Rechnung_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'HGB Bilanz
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('HGB_BalanceSheet')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim HGB_BalanceSheet_ReportStatus As String = cmd.ExecuteScalar
            If HGB_BalanceSheet_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report HGB - Bilanz")
                Dim HGB_BS_Da As New SqlDataAdapter("SELECT * FROM [HGB_BS] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                Dim HGB_BS_dataset As New DataSet("HGB_BS")
                HGB_BS_Da.Fill(HGB_BS_dataset, "HGB_BS")
                Dim CrRepHGB_BS As New ReportDocument
                CrRepHGB_BS.Load(CrystalRepDir & "\HGB_BILANZ_Daily.rpt")
                CrRepHGB_BS.SetDataSource(HGB_BS_dataset)
                CrRepHGB_BS.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepHGB_BS.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\HGB - Bilanz_" & BaisRelatedFileNr & ".pdf")
            End If


            'STRESS TESTS LIQUIDITY-HEAD OFFICE SCENARIO
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('StressTestLiquidityHeadOfficeScenario')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim StressTestLiquidityHeadOfficeScenario_ReportStatus As String = cmd.ExecuteScalar
            If StressTestLiquidityHeadOfficeScenario_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(60, "Create report STRESS TEST LIQUIDITY-HEAD OFFICE SCENARIO")
                Dim StressTestsLiquidHODa As New SqlDataAdapter("SELECT [StressDate],[CashPlacementBUBA_ACCD],[LiquidDemOver],[LiquidDemOverStressTest],[CashPlacementBUBA_CFNM],[LossUnderStressCashPlacementBUBA],[AddCashOutflowunderStress_CashPlacementBUBA],[PlacementToBanksInclIC_ACCD],[PlacementsToBanksInclIC_CFNM],[LossUnderStressPlacementsToBanksInclIC],[AddCashOutflowunderStress_PlacementsToBanksInclIC],[DebtClaimToCustomersInclCCB_ACCD],[DebtClaimToCustomersInclCCB_CFNM],[LossUnderStressDebtClaimToCustomersInclCCB],[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB],[Investments_Securities_ACCD],[Investments_Securities_CFNM],[LossUnderStressInvestments_Securities],[AddCashOutflowunderStress_Investments_Securities],[OtherAssets_ACCD],[OtherAssets_CFNM],[LossUnderStressInvestments_OtherAssets],[AddCashOutflowunderStress_OtherAssets],[CASH_INFLOW_ACCD],[CASH_INFLOW_CFNM],[BorrowFromBUBA_ACCD],[BorrowFromBUBA_CFNM],[LossUnderStressInvestments_BorrowFromBUBA],[AddCashOutflowunderStress_BorrowFromBUBA],[DepositFromBanksInclIC_ACCD],[DepositFromBanksInclIC_CFNM],[LossUnderStressInvestments_DepositFromBanksInclIC],[AddCashOutflowunderStress_DepositFromBanksInclIC],[DepositFromCustomers_ACCD],[DepositFromCustomers_CFNM],[LossUnderStressInvestments_DepositFromCustomers],[AddCashOutflowunderStress_DepositFromCustomers],[CASH_OUTFLOW_ACCD],[CASH_OUTFLOW_CFNM],[LIQUIDITY_DEMAND_OVERPLUS_CFNM],[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress],[TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS] FROM [StressTestsLiquidHO] where StressDate='" & SqlEmailDataDate & "'", conn)
                Dim StressTestsLiquidHOdataset As New DataSet("StressTestsLiquidHO")
                StressTestsLiquidHODa.Fill(StressTestsLiquidHOdataset, "StressTestsLiquidHO")
                Dim CrRepStressTestLiquidityHO As New ReportDocument
                CrRepStressTestLiquidityHO.Load(CrystalRepDir & "\StressTestsLiquidityHOscenario.rpt")
                CrRepStressTestLiquidityHO.SetDataSource(StressTestsLiquidHOdataset)
                CrRepStressTestLiquidityHO.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepStressTestLiquidityHO.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\STRESS TEST LIQUIDITY HEAD OFFICE SCENARIO.pdf")
            End If

            '**********************************************************************************************
            'OLD CODE
            'Dim CrRepStressTestLiquidityHO As New ReportDocument
            'CrRepStressTestLiquidityHO.Load(CrystalRepDir & "\StressTestsLiquidityHOscenario.rpt")
            'CrRepStressTestLiquidityHO.SetDataSource(STRESS_HO.RiskControllingDataSet)
            'CrRepStressTestLiquidityHO.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
            'CrRepStressTestLiquidityHO.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\STRESS TEST LIQUIDITY HEAD OFFICE SCENARIO.pdf")
            '*************************************************************************************************

            'FX CREDIT EQUIVALENT REPORT
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('FxCreditEquivalent')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim FxCreditEquivalent_ReportStatus As String = cmd.ExecuteScalar
            If FxCreditEquivalent_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report FX CREDIT EQUIVALENT DAILY CALCULATION")
                Dim CrRepFxCreditEquivCalculation As New ReportDocument
                CrRepFxCreditEquivCalculation.Load(CrystalRepDir & "\FX_CREDIT_EQUIV_CALC.rpt")
                'CrRepFxCreditEquivCalculation.SetDataSource(STRESS_HO.RiskControllingDataSet)
                CrRepFxCreditEquivCalculation.SetDataSource(FX_CREDIT_EQUIV.AccountingDataSet)
                CrRepFxCreditEquivCalculation.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepFxCreditEquivCalculation.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\FX CREDIT EQUIVALENT DAILY CALCULATION_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'IRS CREDIT EQUIVALENT REPORT
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('IRS_CreditEquivalent')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim IRS_CreditEquivalent_ReportStatus As String = cmd.ExecuteScalar
            If IRS_CreditEquivalent_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report IRS CREDIT EQUIVALENT DAILY CALCULATION")
                Dim CrRepIrsCreditEquivCalculation As New ReportDocument
                CrRepIrsCreditEquivCalculation.Load(CrystalRepDir & "\INTEREST_RATE_SWAP_CREDIT_EQUIV_CALC.rpt")
                'CrRepFxCreditEquivCalculation.SetDataSource(STRESS_HO.RiskControllingDataSet)
                CrRepIrsCreditEquivCalculation.SetDataSource(IRS_CREDIT_EQUIV.AccountingDataSet)
                CrRepIrsCreditEquivCalculation.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepIrsCreditEquivCalculation.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\INTEREST RATE SWAP CREDIT EQUIVALENT DAILY CALCULATION_" & BaisRelatedFileNr & ".pdf")
            End If


            'LARGE LOANS EXPOSURE - CORPORATES
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('LargeLoansExposure_Corporates')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim LargeLoansExposure_Corporates_ReportStatus As String = cmd.ExecuteScalar
            If LargeLoansExposure_Corporates_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report LARGE LOANS EXPOSURE - CORPORATES")
                'Dim daLLEC As New RiskControllingBasicsDataSetTableAdapters.LargeLoanExposureCorporatesTableAdapter
                'Dim f As New PD
                'daLLEC.FillByRiskDate(f.RiskControllingBasicsDataSet.LargeLoanExposureCorporates, EmailDataDate)
                If EmailDataDate < DateSerial(2018, 8, 2) Then
                    Dim LargeLoanExposureCorporatesDa As New SqlDataAdapter("SELECT * FROM [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                    Dim REPORTINGdataset As New DataSet("REPORTING")
                    LargeLoanExposureCorporatesDa.Fill(REPORTINGdataset, "LARGE_LOANS_EXPOSURE")
                    Dim CrRepLargeLoansExposureCorporates As New ReportDocument
                    CrRepLargeLoansExposureCorporates.Load(CrystalRepDir & "\LARGE_LOAN_EXPOSURE_CORPORATES.rpt")
                    CrRepLargeLoansExposureCorporates.SetDataSource(REPORTINGdataset)
                    CrRepLargeLoansExposureCorporates.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepLargeLoansExposureCorporates.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\LARGE LOAN EXPOSURE - CORPORATES_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate >= DateSerial(2018, 8, 2) Then
                    Dim LargeLoanExposureCorporatesDa As New SqlDataAdapter("SELECT * FROM [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                    Dim RiskLimitDailyControlDa As New SqlDataAdapter("SELECT * FROM [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & SqlEmailDataDate & "'", conn)
                    Dim REPORTINGdataset As New DataSet("REPORTING")
                    LargeLoanExposureCorporatesDa.Fill(REPORTINGdataset, "LARGE_LOANS_EXPOSURE")
                    RiskLimitDailyControlDa.Fill(REPORTINGdataset, "RISK LIMIT DAILY CONTROL")
                    Dim CrRepLargeLoansExposureCorporates As New ReportDocument
                    CrRepLargeLoansExposureCorporates.Load(CrystalRepDir & "\LARGE_LOAN_EXPOSURE_CORPORATES_from_20180802.rpt")
                    CrRepLargeLoansExposureCorporates.SetDataSource(REPORTINGdataset)
                    CrRepLargeLoansExposureCorporates.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    CrRepLargeLoansExposureCorporates.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\LARGE LOAN EXPOSURE - CORPORATES_" & BaisRelatedFileNr & ".pdf")
                End If
            End If

            '
            'ART.13 KWG CHINESSE BANKS
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DailyArtikel13KWG_ChineseBanks')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DailyArtikel13KWG_ChineseBanks_ReportStatus As String = cmd.ExecuteScalar
            If DailyArtikel13KWG_ChineseBanks_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report Art.13 KWG daily report (Chinese Banks)")
                Dim Art13KWGChinesseBanksDa As New SqlDataAdapter("SELECT * FROM [Daily_Art13_Kwg_ChineseBanks] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                Dim ArtKWGdataset As New DataSet("ARTKWG")
                Art13KWGChinesseBanksDa.Fill(ArtKWGdataset, "Daily_Art13_Kwg_ChineseBanks")
                Dim CrRepArt13KWGChinesseBanks As New ReportDocument
                CrRepArt13KWGChinesseBanks.Load(CrystalRepDir & "\DailyArtikel13KWG_ChineseBanks.rpt")
                CrRepArt13KWGChinesseBanks.SetDataSource(ArtKWGdataset)
                CrRepArt13KWGChinesseBanks.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepArt13KWGChinesseBanks.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DailyArtikel13KWG_ChineseBanks_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'ART.13 KWG NONE CHINESSE BANKS
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DailyArtikel13KWG_NoneChineseBanks')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DailyArtikel13KWG_NoneChineseBanks_ReportStatus As String = cmd.ExecuteScalar
            If DailyArtikel13KWG_NoneChineseBanks_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report Art.13 KWG daily report (None Chinese Banks)")
                Dim Art13KWGNoneChinesseBanksDa As New SqlDataAdapter("SELECT * FROM [Daily_Art13_Kwg_NoneChineseBanks] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                Dim ArtKWGNonedataset As New DataSet("ARTKWGNONE")
                Art13KWGNoneChinesseBanksDa.Fill(ArtKWGNonedataset, "Daily_Art13_Kwg_NoneChineseBanks")
                Dim CrRepArt13KWGNoneChinesseBanks As New ReportDocument
                CrRepArt13KWGNoneChinesseBanks.Load(CrystalRepDir & "\DailyArtikel13KWG_NoneChineseBanks.rpt")
                CrRepArt13KWGNoneChinesseBanks.SetDataSource(ArtKWGNonedataset)
                CrRepArt13KWGNoneChinesseBanks.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepArt13KWGNoneChinesseBanks.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DailyArtikel13KWG_NoneChineseBanks_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'ART.13 KWG CENTRAL GOVERMENT
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DailyArtikel13KWG_Central_Goverment')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim DailyArtikel13KWG_Central_Goverment_ReportStatus As String = cmd.ExecuteScalar
            If DailyArtikel13KWG_Central_Goverment_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report Art.13 KWG daily report (Central Goverment)")
                Dim Art13KWGCentralGovermentDa As New SqlDataAdapter("SELECT * FROM [Daily_Art13_Kwg_CentralGoverment] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                Dim Art13KWGCentralGovermentdataset As New DataSet("ARTKWGGOVERMENT")
                Art13KWGCentralGovermentDa.Fill(Art13KWGCentralGovermentdataset, "Daily_Art13_Kwg_CentralGoverment")
                Dim CrRepArt13CentralGoverment As New ReportDocument
                CrRepArt13CentralGoverment.Load(CrystalRepDir & "\DailyArtikel13KWG_Central_Goverment.rpt")
                CrRepArt13CentralGoverment.SetDataSource(Art13KWGCentralGovermentdataset)
                CrRepArt13CentralGoverment.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepArt13CentralGoverment.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DailyArtikel13KWG_Central_Goverment_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            'TRAFFIC LIGHTS SYSTEM
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('TraficLightsSystem')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim TraficLightsSystem_ReportStatus As String = cmd.ExecuteScalar
            If TraficLightsSystem_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report TRAFFIC LIGHTS SYSTEM")
                Dim TrafficLightsSystemDa As New SqlDataAdapter("SELECT * FROM [RBC_TRAFFIC_LIGHT_SYSTEM] where [RiskDate]='" & SqlEmailDataDate & "'", conn)
                Dim REPORTING_TLSdataset As New DataSet("REPORTING_TLS")
                TrafficLightsSystemDa.Fill(REPORTING_TLSdataset, "RBC_TRAFFIC_LIGHT_SYSTEM")
                Dim CrRepTrafficLightsSystem As New ReportDocument
                CrRepTrafficLightsSystem.Load(CrystalRepDir & "\TRAFIC_LIGHT_SYSTEM_MAXLOSS_LIMITS_RBC.rpt")
                CrRepTrafficLightsSystem.SetDataSource(REPORTING_TLSdataset)
                CrRepTrafficLightsSystem.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                CrRepTrafficLightsSystem.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\TRAFFIC LIGHTS SYSTEM (RBC)_" & BaisRelatedFileNr & ".pdf")
            End If

            '
            '
            'USD EXCHANGE RATE MONITORING
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('USD_ExchangeRate_Monitoring')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim USD_ExchangeRate_Monitoring_ReportStatus As String = cmd.ExecuteScalar
            If USD_ExchangeRate_Monitoring_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report USD EXCHANGE RATE MONITORING")
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EXCHANGE RATES MONITORING' AND xtype='U')  CREATE TABLE [EXCHANGE RATES MONITORING]([ID] [int] IDENTITY(1,1) NOT NULL,[OrigID] [int] NULL,[CURRENCY CODE] [nvarchar](255) NULL,[MIDDLE RATE] [float] NULL,[YESTERDAYS_RATE] [float] NULL,[COMPARED_WITH_YESTERDAY] [float] NULL,[COMPARED_WITH_YESTERDAY_PERCENT] [float] NULL,[CHANGES_WITHIN_WEEK] [float] NULL,[CHANGES_WITHIN_MONTH] [float] NULL,[EXCHANGE RATE DATE] [datetime] NULL) ELSE DELETE FROM [EXCHANGE RATES MONITORING]"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "ALTER TABLE [EXCHANGE RATES MONITORING] ADD  CONSTRAINT [DF_EXCHANGE RATES MONITORING_YESTERDAYS_RATE]  DEFAULT (0) FOR [YESTERDAYS_RATE]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "ALTER TABLE [EXCHANGE RATES MONITORING] ADD  CONSTRAINT [DF_EXCHANGE RATES MONITORING_COMPARED_WITH_YESTERDAY]  DEFAULT (0) FOR [COMPARED_WITH_YESTERDAY]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "ALTER TABLE [EXCHANGE RATES MONITORING] ADD  CONSTRAINT [DF_EXCHANGE RATES MONITORING_COMPARED_WITH_YESTERDAY_PERCENT]  DEFAULT (0) FOR [COMPARED_WITH_YESTERDAY_PERCENT]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "ALTER TABLE [EXCHANGE RATES MONITORING] ADD  CONSTRAINT [DF_EXCHANGE RATES MONITORING_CHANGES_WITHIN_WEEK]  DEFAULT (0) FOR [CHANGES_WITHIN_WEEK]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "ALTER TABLE [EXCHANGE RATES MONITORING] ADD  CONSTRAINT [DF_EXCHANGE RATES MONITORING_CHANGES_WITHIN_MONTH]  DEFAULT (0) FOR [CHANGES_WITHIN_MONTH]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "INSERT INTO [EXCHANGE RATES MONITORING](OrigID,[CURRENCY CODE],[MIDDLE RATE],[EXCHANGE RATE DATE]) select [ID],[CURRENCY CODE],[MIDDLE RATE],[EXCHANGE RATE DATE] from [EXCHANGE RATES OCBS] where [CURRENCY CODE]='USD' and MONTH([EXCHANGE RATE DATE])=MONTH(GETDATE()) and YEAR([EXCHANGE RATE DATE])=YEAR(GETDATE()) and [EXCHANGE RATE DATE]<=(Select max([EXCHANGE RATE DATE]) from [EXCHANGE RATES OCBS]) order by [EXCHANGE RATE DATE] asc"
                'cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [EXCHANGE RATES MONITORING](OrigID,[CURRENCY CODE],[MIDDLE RATE],[EXCHANGE RATE DATE]) select [ID],[CURRENCY CODE],[MIDDLE RATE],[EXCHANGE RATE DATE] from [EXCHANGE RATES OCBS] where [CURRENCY CODE]='USD' and [EXCHANGE RATE DATE]>=dateadd(month,-1,'" & SqlEmailDataDate & "') and [EXCHANGE RATE DATE]<=(Select max([EXCHANGE RATE DATE]) from [EXCHANGE RATES OCBS]) order by [EXCHANGE RATE DATE] asc"
                cmd.ExecuteNonQuery()
                cmd.CommandText = " UPDATE A SET A.[YESTERDAYS_RATE]=B.[MIDDLE RATE] from [EXCHANGE RATES MONITORING] A INNER JOIN [EXCHANGE RATES MONITORING] B ON A.[ID]=B.[ID]+1 where A.ID not in (Select min(ID) from [EXCHANGE RATES MONITORING])"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXCHANGE RATES MONITORING] set [COMPARED_WITH_YESTERDAY]=Round([MIDDLE RATE]-[YESTERDAYS_RATE],5) where ID not in (Select min(ID) from [EXCHANGE RATES MONITORING])"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXCHANGE RATES MONITORING] set [COMPARED_WITH_YESTERDAY_PERCENT]=Round(Round([MIDDLE RATE]-[YESTERDAYS_RATE],5)/[YESTERDAYS_RATE],4)*100 where ID not in (Select min(ID) from [EXCHANGE RATES MONITORING])"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXCHANGE RATES MONITORING] SET [CHANGES_WITHIN_WEEK]=(Select Sum([COMPARED_WITH_YESTERDAY_PERCENT]) from [EXCHANGE RATES MONITORING] where ID in (Select TOP 5 ID from [EXCHANGE RATES MONITORING] order by ID desc)) where ID in (Select max(ID) from [EXCHANGE RATES MONITORING])"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXCHANGE RATES MONITORING] SET [CHANGES_WITHIN_MONTH]=(Select Sum([COMPARED_WITH_YESTERDAY_PERCENT]) from [EXCHANGE RATES MONITORING] where ID in (Select TOP 31 ID from [EXCHANGE RATES MONITORING] order by ID desc)) where ID in (Select max(ID) from [EXCHANGE RATES MONITORING])"
                cmd.ExecuteNonQuery()
                Dim ExchangeRateMonitoringDa As New SqlDataAdapter("Select * from [EXCHANGE RATES MONITORING]", conn)
                Dim USD_Rate_Monitoring_Dataset As New DataSet("USD_RATE_MONITORING")
                ExchangeRateMonitoringDa.Fill(USD_Rate_Monitoring_Dataset, "EXCHANGE RATES MONITORING")
                Dim CrExchangeRatesMonitoring As New ReportDocument
                CrExchangeRatesMonitoring.Load(CrystalRepDir & "\EXCHANGE_RATE_MONITORING.rpt")
                CrExchangeRatesMonitoring.SetDataSource(USD_Rate_Monitoring_Dataset)
                CrExchangeRatesMonitoring.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\MONITORING OF EXCHANGE RATE (EUR-USD)_" & BaisRelatedFileNr & ".pdf")
                cmd.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DROP TABLE [EXCHANGE RATES MONITORING]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()
            End If

            '
            'LCR OVERVIEW
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('LCR_Overview')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim LCR_Overview_ReportStatus As String = cmd.ExecuteScalar
            If LCR_Overview_ReportStatus = "Y" Then
                Me.BgwDailyRiskEmail.ReportProgress(61, "Create report LCR Overview")
                If EmailDataDate <= DateSerial(2016, 9, 29) Then
                    Dim d As Date = Me.EmailCreationDate.Text
                    Dim d1 As Date = DateAdd(DateInterval.Day, -90, d)
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    Dim d1sql As String = d1.ToString("yyyyMMdd")
                    Dim LCR_INFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]='" & dsql & "' ", conn)
                    Dim LCR_OUTFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]='" & dsql & "'", conn)
                    Dim LCR_LA_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_LA_BAIS] where [RiskDate]='" & dsql & "'", conn)
                    Dim LCR_OVERVIEW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]='" & dsql & "'", conn)
                    Dim LCR_OVERVIEW_CD_Dataset As New DataSet("LCR_OVERVIEW")
                    LCR_INFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_IN_BAIS")
                    LCR_OUTFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_OUT_BAIS")
                    LCR_LA_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_LA_BAIS")
                    LCR_OVERVIEW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_Overview")
                    'LCR_IN_BAIS-Data for last 90 Days
                    Dim LCR_INFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'  ", conn)
                    Dim LCR_INFLOWDataset As New DataSet("LCR_INFLOW")
                    LCR_INFLOW_Da.Fill(LCR_INFLOWDataset, "LCR_IN_BAIS")
                    'LCR_OUT_BAIS-Data for last 90 Days
                    Dim LCR_OUTFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
                    Dim LCR_OUTFLOWDataset As New DataSet("LCR_OUTFLOW")
                    LCR_OUTFLOW_Da.Fill(LCR_OUTFLOWDataset, "LCR_OUT_BAIS")
                    'LCR_Overview Data for last 90 Days
                    Dim LCR_LiquidityAssets_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
                    Dim LCR_LiquidityAssetsDataset As New DataSet("LCR_LIQUIDITY_ASSETS")
                    LCR_LiquidityAssets_Da.Fill(LCR_LiquidityAssetsDataset, "LCR_Overview")
                    'RISK LIMIT DAILY CONTROL-LCR Key Figure
                    Dim LCR_RLDC_Da As New SqlDataAdapter("Select [RLDC Date],[LCR_Ratio] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='" & d1sql & "' and [RLDC Date]<='" & dsql & "'", conn)
                    Dim LCR_RLDCDataset As New DataSet("LCR_RLDC")
                    LCR_RLDC_Da.Fill(LCR_RLDCDataset, "RISK LIMIT DAILY CONTROL")
                    'Set Crystal Report
                    Dim CrRepLCR_Overview As New ReportDocument
                    CrRepLCR_Overview.Load(CrystalRepDir & "\LCR_Overview.rpt")
                    CrRepLCR_Overview.SetDataSource(LCR_OVERVIEW_CD_Dataset)
                    'Set first Parameter Value - MAIN REPORT
                    CrRepLCR_Overview.SetParameterValue("RiskDate", d)
                    'Unterbericht Datenbank setzen
                    CrRepLCR_Overview.Subreports.Item("LCR_Inflow_Chart.rpt").SetDataSource(LCR_INFLOWDataset)
                    CrRepLCR_Overview.Subreports.Item("LCR_Outflow_Chart.rpt").SetDataSource(LCR_OUTFLOWDataset)
                    CrRepLCR_Overview.Subreports.Item("LCR_Keys.rpt").SetDataSource(LCR_RLDCDataset)
                    CrRepLCR_Overview.Subreports.Item("LCR_LiquidityAssets_Chart.rpt").SetDataSource(LCR_LiquidityAssetsDataset)
                    'Apply current Value to Parameterfield - MAIN REPORT
                    CrRepLCR_Overview.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    'Unterbericht Parameter setzen
                    CrRepLCR_Overview.SetParameterValue("RiskDateFrom", d1, "LCR_Inflow_Chart.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateTill", d, "LCR_Inflow_Chart.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateFrom_Outflow", d1, "LCR_Outflow_Chart.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateTill_Outflow", d, "LCR_Outflow_Chart.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateFrom", d1, "LCR_Keys.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateTill", d, "LCR_Keys.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateFrom", d1, "LCR_LiquidityAssets_Chart.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateTill", d, "LCR_LiquidityAssets_Chart.rpt")
                    'Export Report to PDF
                    CrRepLCR_Overview.PrintOptions.PaperSize = PaperSize.PaperA4
                    CrRepLCR_Overview.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\LCR Overview_" & BaisRelatedFileNr & ".pdf")
                ElseIf EmailDataDate >= DateSerial(2016, 9, 30) Then
                    Dim d As Date = Me.EmailCreationDate.Text
                    Dim d1 As Date = DateAdd(DateInterval.Day, -90, d)
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    Dim d1sql As String = d1.ToString("yyyyMMdd")
                    Dim LCR_INFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]='" & dsql & "' ", conn)
                    Dim LCR_OUTFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]='" & dsql & "'", conn)
                    Dim LCR_LA_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_LA_BAIS] where [RiskDate]='" & dsql & "'", conn)
                    Dim LCR_OVERVIEW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]='" & dsql & "'", conn)
                    Dim LCR_OVERVIEW_CD_Dataset As New DataSet("LCR_OVERVIEW")
                    LCR_INFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_IN_BAIS")
                    LCR_OUTFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_OUT_BAIS")
                    LCR_LA_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_LA_BAIS")
                    LCR_OVERVIEW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_Overview")
                    'LCR_IN_BAIS-Data for last 90 Days
                    Dim LCR_INFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'  ", conn)
                    Dim LCR_INFLOWDataset As New DataSet("LCR_INFLOW")
                    LCR_INFLOW_Da.Fill(LCR_INFLOWDataset, "LCR_IN_BAIS")
                    'LCR_OUT_BAIS-Data for last 90 Days
                    Dim LCR_OUTFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
                    Dim LCR_OUTFLOWDataset As New DataSet("LCR_OUTFLOW")
                    LCR_OUTFLOW_Da.Fill(LCR_OUTFLOWDataset, "LCR_OUT_BAIS")
                    'LCR_Overview Data for last 90 Days
                    Dim LCR_LiquidityAssets_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
                    Dim LCR_LiquidityAssetsDataset As New DataSet("LCR_LIQUIDITY_ASSETS")
                    LCR_LiquidityAssets_Da.Fill(LCR_LiquidityAssetsDataset, "LCR_Overview")
                    'RISK LIMIT DAILY CONTROL-LCR Key Figure
                    Dim LCR_RLDC_Da As New SqlDataAdapter("Select [RLDC Date],[LCR_Ratio] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='" & d1sql & "' and [RLDC Date]<='" & dsql & "'", conn)
                    Dim LCR_RLDCDataset As New DataSet("LCR_RLDC")
                    LCR_RLDC_Da.Fill(LCR_RLDCDataset, "RISK LIMIT DAILY CONTROL")
                    'Set Crystal Report
                    Dim CrRepLCR_Overview As New ReportDocument
                    CrRepLCR_Overview.Load(CrystalRepDir & "\LCRDR_Overview.rpt")
                    CrRepLCR_Overview.SetDataSource(LCR_OVERVIEW_CD_Dataset)
                    'Set first Parameter Value - MAIN REPORT
                    CrRepLCR_Overview.SetParameterValue("RiskDate", d)
                    'Unterbericht Datenbank setzen
                    'CrRepLCR_Overview.Subreports.Item("LCRDR_Inflow_Chart.rpt").SetDataSource(LCR_INFLOWDataset)
                    'CrRepLCR_Overview.Subreports.Item("LCRDR_Outflow_Chart.rpt").SetDataSource(LCR_OUTFLOWDataset)
                    CrRepLCR_Overview.Subreports.Item("LCRDR_Keys.rpt").SetDataSource(LCR_RLDCDataset)
                    'CrRepLCR_Overview.Subreports.Item("LCRDR_LiquidityAssets_Chart.rpt").SetDataSource(LCR_LiquidityAssetsDataset)
                    'Apply current Value to Parameterfield - MAIN REPORT
                    CrRepLCR_Overview.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
                    'Unterbericht Parameter setzen
                    'CrRepLCR_Overview.SetParameterValue("RiskDateFrom", d1, "LCRDR_Inflow_Chart.rpt")
                    'CrRepLCR_Overview.SetParameterValue("RiskDateTill", d, "LCRDR_Inflow_Chart.rpt")
                    'CrRepLCR_Overview.SetParameterValue("RiskDateFrom_Outflow", d1, "LCRDR_Outflow_Chart.rpt")
                    'CrRepLCR_Overview.SetParameterValue("RiskDateTill_Outflow", d, "LCRDR_Outflow_Chart.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateFrom", d1, "LCRDR_Keys.rpt")
                    CrRepLCR_Overview.SetParameterValue("RiskDateTill", d, "LCRDR_Keys.rpt")
                    'CrRepLCR_Overview.SetParameterValue("RiskDateFrom", d1, "LCRDR_LiquidityAssets_Chart.rpt")
                    'CrRepLCR_Overview.SetParameterValue("RiskDateTill", d, "LCRDR_LiquidityAssets_Chart.rpt")
                    'Export Report to PDF
                    CrRepLCR_Overview.PrintOptions.PaperSize = PaperSize.PaperA4
                    CrRepLCR_Overview.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\LCR (Delegated Act) Overview_" & BaisRelatedFileNr & ".pdf")
                End If
            End If


            'LIQUIDITY RESERVE
            cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('SecuritiesLiquidityReserve')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
            Dim SecuritiesLiquidityReserve_ReportStatus As String = cmd.ExecuteScalar
            If SecuritiesLiquidityReserve_ReportStatus = "Y" Then
                Dim LiquidityReserveDa As New SqlDataAdapter("SELECT * FROM [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & SqlEmailDataDate & "'", conn)
                Dim LiquidityReserveDataset As New DataSet("SECURITIES_LIQUIDITYRESERVE")
                LiquidityReserveDa.Fill(LiquidityReserveDataset, "SECURITIES_LIQUIDITYRESERVE")
                Dim report As New LiquidityReserveXtraReport
                report.DataSource = LiquidityReserveDataset
                Me.QueryText = "SELECT * FROM [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & SqlEmailDataDate & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    report.ExportToPdf(ReportExpFile & "\Securities Liquidity Reserve_" & BaisRelatedFileNr & ".pdf")
                    dt.Clear()
                End If
            End If





            'SELECT FILES FROM RELATED BAIS DIRECTORY
            Me.BgwDailyRiskEmail.ReportProgress(65, "Select related BAIS Files")
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim BAISDirectory As String = cmd.ExecuteScalar()
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_FILENAME_BEGINS' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim BAIS_NAME_BEGINS As String = cmd.ExecuteScalar()
            Me.QueryText = "SELECT * FROM [PARAMETER] WHERE  [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_GM_BAIS_FILES'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    Dim BaisFileFullName As String = BAISDirectory & BAIS_NAME_BEGINS & BaisRelatedFileNr & dt.Rows.Item(i).Item("PARAMETER2")
                    FileCopy(BaisFileFullName, ReportExpFile & dt.Rows.Item(i).Item("PARAMETER1"))
                    Me.BgwDailyRiskEmail.ReportProgress(70, "Following BAIS File has being copied to directory: " & ReportExpFile & dt.Rows.Item(i).Item("PARAMETER1"))
                Next
            End If
            '
            'GET DATA FROM RISK LIMIT DAILY CONTROL for EMAIL BODY DISPLAY
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select related Data from RISK LIMIT DAILY CONTROL for display in E-Mail Body")
            Me.QueryText = "SELECT * FROM [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & SqlEmailDataDate & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Profit and Loss1")
            Dim ProfitLossResult As Double = dt.Rows.Item(0).Item("PL Result")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select BUBA_InterestAmount")
            Dim BUBA_InterestAmount As Double = dt.Rows.Item(0).Item("BUBA_InterestAmount")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select HGB_PL_Calculated")
            Dim HGB_PL_Calculated As Double = dt.Rows.Item(0).Item("HGB_PL_Calculated")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select CCBINFO Obligo Liability surplus")
            Dim ObligoLiabilitySurplusHGB As Double = dt.Rows.Item(0).Item("CCBINFO Obligo Liability surplus")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select CCBINFO Obligo Liability surplus Risk Subtotal")
            Dim ObligoLiabilitySurplusRiskSubtotal As Double = dt.Rows.Item(0).Item("CCBINFO Obligo Liability surplus Risk Subtotal")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Treasury FX position")
            Dim FX_Position As Double = dt.Rows.Item(0).Item("Treasury FX position")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select CAR:Bank SolvV/100 ")
            Dim CAR_Value As Double = dt.Rows.Item(0).Item("Bank SolvV") / 100
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select CapitalRatio_T1")
            Dim CapitalRatio_T1 As Double = dt.Rows.Item(0).Item("CapitalRatio_T1") / 100
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Core capital")
            Dim CoreCapital As Double = dt.Rows.Item(0).Item("Core capital")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select CapitalForSolvV")
            Dim CapitalForSolva As Double = dt.Rows.Item(0).Item("CapitalForSolvV")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select OwnCapitalBAIS")
            Dim OwnFunds As Double = dt.Rows.Item(0).Item("OwnCapitalBAIS")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Minimum capital requirement")
            Dim MinCapitalReq As Double = dt.Rows.Item(0).Item("Minimum capital requirement")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Bank Bilanz")
            'Dim LiquidLV As Double = dt.Rows.Item(0).Item("Bank Liquid LV") / 100
            Dim BilanzCustDeposit As Double = dt.Rows.Item(0).Item("Bank Bilanz")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Credit Risk")
            Dim CreditRisk As Double = dt.Rows.Item(0).Item("Credit Risk")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select CreditRiskCashPledge")
            Dim CreditRiskCP As Double = dt.Rows.Item(0).Item("CreditRiskCashPledge")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Interest rate risk")
            Dim InterestRateRisk As Double = dt.Rows.Item(0).Item("Interest rate risk") / 100
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select InterestRateRisk_Minus200bps")
            Dim InterestRateRiskMinus200 As Double = dt.Rows.Item(0).Item("InterestRateRisk_Minus200bps") / 100
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select InterestRateRisk_Plus200bps")
            Dim InterestRateRiskPlus200 As Double = dt.Rows.Item(0).Item("InterestRateRisk_Plus200bps") / 100
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Interest risk")
            Dim InterestRateRiskAmount50bps As Double = dt.Rows.Item(0).Item("Interest risk")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Currency risk")
            Dim CurrencyRisk As Double = dt.Rows.Item(0).Item("Currency risk")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Operational risk")
            Dim OperationalRisk As Double = dt.Rows.Item(0).Item("Operational risk")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Liquidity risk")
            Dim LiquidityRisk As Double = dt.Rows.Item(0).Item("Liquidity risk")
            Me.BgwDailyRiskEmail.ReportProgress(75, "RiskBearingCapacityCashPledge")
            'Dim MarketPriceRisk As Double = dt.Rows.Item(0).Item("Market price risk of securities")
            Dim RiskBearingCapacity As Double = dt.Rows.Item(0).Item("RiskBearingCapacityCashPledge")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select LCR_Ratio")
            Dim LCR_Ratio As Double = dt.Rows.Item(0).Item("LCR_Ratio")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select PLdifferenceOCBS_IDW")
            Dim OCBS_IDW_Difference As Double = dt.Rows.Item(0).Item("PLdifferenceOCBS_IDW")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select PLdifferenceOCBS_IDW_INTERN")
            Dim OCBS_IDW_INTERN_Difference As Double = dt.Rows.Item(0).Item("PLdifferenceOCBS_IDW_INTERN")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select FX_Evaluation_Temp")
            Dim FX_DAILY_EVALUATION As Double = dt.Rows.Item(0).Item("FX_Evaluation_Temp")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select PLrecalculated")
            Dim ProfitLossRecalculated As Double = dt.Rows.Item(0).Item("PLrecalculated")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select KapitalerhaltungsPuffer")
            Dim Kapitalerhaltungspuffer As Double = dt.Rows.Item(0).Item("KapitalerhaltungsPuffer")
            Me.BgwDailyRiskEmail.ReportProgress(75, "AntizyklischerKapitalPuffer")
            Dim AntizyklischerKapitalpuffer As Double = dt.Rows.Item(0).Item("AntizyklischerKapitalPuffer")
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Profit and Loss2")
            'Balance Sheet Totals
            cmd.CommandText = "SELECT Sum([BalanceEUREqu]) FROM [DailyBalanceSheets] where [BSDate]='" & SqlEmailDataDate & "' and [GL_Item]='4999'"
            Dim BalanceTotal As Double = cmd.ExecuteScalar
            'CCB GUARANTEES
            cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & SqlEmailDataDate & "'"
            Dim CCB_Guarantees_Amount As Double = 0
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                CCB_Guarantees_Amount = FormatNumber(cmd.ExecuteScalar, 2)
            End If
            'CCB FX CREDIT EQUIVA. AMOUNT
            cmd.CommandText = "SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic] where [ClientGroup]='1000' and [RiskDate]='" & SqlEmailDataDate & "'"
            Dim CCB_Credit_Equiv_Amount As Double = 0
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                CCB_Credit_Equiv_Amount = FormatNumber(cmd.ExecuteScalar, 2)
            End If
            'ELIGIBLE CAPITAL FOR LARGE LOANS
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Eligible Capital for Large Loans (Table:LARGE_LOANS_EXPOSURE)")
            Dim EligibleCapitalLargeLoans As Double = 0
            cmd.CommandText = "Select [CapitalForSolvV] from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & SqlEmailDataDate & "' GROUP BY [CapitalForSolvV]"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                EligibleCapitalLargeLoans = FormatNumber(cmd.ExecuteScalar, 2)
            End If
            Me.BgwDailyRiskEmail.ReportProgress(75, "Select Profit and Loss 3")
            'Spliting in Time Periods
            'Dim CCB_Credit_Equiv_Amount_in3M As Double = 0
            'Dim CCB_Credit_Equiv_Amount_in6M As Double = 0
            'Dim CCB_Credit_Equiv_Amount_in9M As Double = 0
            'Dim CCB_Credit_Equiv_Amount_in1Y As Double = 0
            'Dim CCB_Credit_Equiv_Amount_over1Y2Y As Double = 0
            'Dim CCB_Credit_Equiv_Amount_over2Y As Double = 0
            'cmd.CommandText = "SELECT Sum([EURequCalculated])FROM [FX CREDIT EQUIVALENT Details] where  [ClientGroup]=1000 and [MonthToEventStartDate]<=90 and [RiskDate]='" & SqlEmailDataDate & "'"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'CCB_Credit_Equiv_Amount_in3M = FormatNumber(cmd.ExecuteScalar, 2)
            'End If
            'cmd.CommandText = "SELECT Sum([EURequCalculated])FROM [FX CREDIT EQUIVALENT Details] where  [ClientGroup]=1000 and [MonthToEventStartDate]>90 and [MonthToEventStartDate]<=180 and [RiskDate]='" & SqlEmailDataDate & "'"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'CCB_Credit_Equiv_Amount_in6M = FormatNumber(cmd.ExecuteScalar, 2)
            'End If
            'cmd.CommandText = "SELECT Sum([EURequCalculated])FROM [FX CREDIT EQUIVALENT Details] where  [ClientGroup]=1000 and [MonthToEventStartDate]>180 and [MonthToEventStartDate]<=270 and [RiskDate]='" & SqlEmailDataDate & "'"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'CCB_Credit_Equiv_Amount_in9M = FormatNumber(cmd.ExecuteScalar, 2)
            'End If
            'cmd.CommandText = "SELECT Sum([EURequCalculated])FROM [FX CREDIT EQUIVALENT Details] where  [ClientGroup]=1000 and [MonthToEventStartDate]>270 and [MonthToEventStartDate]<=371 and [RiskDate]='" & SqlEmailDataDate & "'"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'CCB_Credit_Equiv_Amount_in1Y = FormatNumber(cmd.ExecuteScalar, 2)
            'End If
            'cmd.CommandText = "SELECT Sum([EURequCalculated])FROM [FX CREDIT EQUIVALENT Details] where  [ClientGroup]=1000 and [MonthToEventStartDate]>371 and [MonthToEventStartDate]<=742 and [RiskDate]='" & SqlEmailDataDate & "'"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'CCB_Credit_Equiv_Amount_over1Y2Y = FormatNumber(cmd.ExecuteScalar, 2)
            'End If
            'cmd.CommandText = "SELECT Sum([EURequCalculated])FROM [FX CREDIT EQUIVALENT Details] where  [ClientGroup]=1000 and [MonthToEventStartDate]>742 and [RiskDate]='" & SqlEmailDataDate & "'"
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'CCB_Credit_Equiv_Amount_over2Y = FormatNumber(cmd.ExecuteScalar, 2)
            'End If
            'CCB FX TOTAL
            Dim CCB_FX_CREDIT_TOTAL As Double = CCB_Guarantees_Amount + CCB_Credit_Equiv_Amount
            ' in percent with CORE CAPITAL
            Dim CCB_FX_CREDIT_TOTAL_PERCENT As Double = CCB_FX_CREDIT_TOTAL / EligibleCapitalLargeLoans
            'Dim CCB_FX_CREDIT_PERCENT_in3M As Double = Math.Round(CCB_Credit_Equiv_Amount_in3M / CoreCapital, 2) / 1000
            'Dim CCB_FX_CREDIT_PERCENT_in6M As Double = Math.Round(CCB_Credit_Equiv_Amount_in6M / CoreCapital, 2) / 1000
            'Dim CCB_FX_CREDIT_PERCENT_in9M As Double = Math.Round(CCB_Credit_Equiv_Amount_in9M / CoreCapital, 2) / 1000
            'Dim CCB_FX_CREDIT_PERCENT_in1Y As Double = Math.Round(CCB_Credit_Equiv_Amount_in1Y / CoreCapital, 2) / 1000
            'Dim CCB_FX_CREDIT_PERCENT_over1Y2Y As Double = Math.Round(CCB_Credit_Equiv_Amount_over1Y2Y / CoreCapital, 2) / 1000
            'Dim CCB_FX_CREDIT_PERCENT_over2Y As Double = Math.Round(CCB_Credit_Equiv_Amount_over2Y / CoreCapital, 2) / 1000
            'LARGE LOANS EXPOSURE
            Dim LARGE_LOANS_EXPOSURE As Double = 0
            cmd.CommandText = "Select [ExposureAmountMAX] from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & SqlEmailDataDate & "'"
            LARGE_LOANS_EXPOSURE = cmd.ExecuteScalar
            Dim Capital_plus_HGB340F As Double = 0
            cmd.CommandText = "Select Sum(A.A) from (Select distinct([CapitalForSolvV]) as A from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & SqlEmailDataDate & "' Union All Select HGB340F*1000 as A from [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & SqlEmailDataDate & "')A"
            Capital_plus_HGB340F = cmd.ExecuteScalar
            Dim LARGE_LOANS_EXPOSURE_HGB340F As Double = Math.Round(Capital_plus_HGB340F * 0.25, 2)

            'SECURITIES DEPRECIATIONS
            Dim SECURITIES_DEPRECIATIONS As Double = 0
            If EmailDataDate <= DateSerial(2018, 12, 31) Then
                cmd.CommandText = "Select Case when Sum(Actual_Depreciation)*(-1) is not NULL then Sum(Actual_Depreciation)*(-1) else 0 end 
                                   from SECURITIES_LIQUIDITYRESERVE 
                                   where LiquidityDate='" & SqlEmailDataDate & "'"
                SECURITIES_DEPRECIATIONS = cmd.ExecuteScalar
            Else
                cmd.CommandText = "DECLARE @RISKDATE Datetime
                                   SET @RISKDATE='" & SqlEmailDataDate & "'
                                   DECLARE @BOND_IMPAIRMENT_LAST_YEAR float
                                   DECLARE @BOND_DEPRECIATION_ACTUAL float
                                   DECLARE @BOND_IMPAIRMENT_DIFFERENCE float
                                   DECLARE @SECURITIES_DEPRECIATION_RESULT float

                                   SET @BOND_IMPAIRMENT_LAST_YEAR=(Select ABS([SecuritiesDepreciations]) from [RISK LIMIT DAILY CONTROL] where [RLDC Date]=(select dateadd(DD, -1, dateadd(YY,datediff(yy,0,GETDATE()),0))))
                                   SET @BOND_DEPRECIATION_ACTUAL=(Select [SecuritiesDepreciations] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]=@RISKDATE )
                                   SET @BOND_IMPAIRMENT_DIFFERENCE=@BOND_IMPAIRMENT_LAST_YEAR+@BOND_DEPRECIATION_ACTUAL
                                   IF @BOND_IMPAIRMENT_DIFFERENCE>0 
                                   BEGIN
                                   SET @SECURITIES_DEPRECIATION_RESULT=0
                                   END
                                   ELSE
                                   BEGIN
                                   SET @SECURITIES_DEPRECIATION_RESULT=@BOND_IMPAIRMENT_DIFFERENCE
                                   END

                                   Select @SECURITIES_DEPRECIATION_RESULT"
                SECURITIES_DEPRECIATIONS = cmd.ExecuteScalar
            End If

            '**********************************************************************
            'Recalculate P/L based on the 2 IDW Methods and BUBA Interests
            Dim PL_After_BUBA As Double = ProfitLossResult + BUBA_InterestAmount
            Dim PL_NewResult_Std_IDW As Double = PL_After_BUBA + OCBS_IDW_Difference
            Dim PL_NewResult_Intern_IDW As Double = PL_After_BUBA + OCBS_IDW_INTERN_Difference
            '---Additional Info for Profit/Loss
            Dim AdditionalInfoText As String = Nothing
            Dim AdditionalInfoAmount As Double = 0
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DailyEmail_PL_AdditionalInfo')) and '" & SqlEmailDataDate & "' BETWEEN [SQL_Date1] and [SQL_Date2] and [Status] in ('Y')"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                AdditionalInfoText = dt.Rows.Item(0).Item("SQL_Name_1").ToString
                AdditionalInfoAmount = CDbl(dt.Rows.Item(0).Item("SQL_Float_2").ToString)
            End If

            Dim PL_NewResult_Intern_NEWG As Double = PL_NewResult_Intern_IDW + SECURITIES_DEPRECIATIONS + AdditionalInfoAmount 'Additional Amount to P/L

            Dim PL_NewResult_HGB As Double = PL_After_BUBA + FX_DAILY_EVALUATION
            Dim HGB_PL_After_BUBA As Double = HGB_PL_Calculated + BUBA_InterestAmount
            'New format++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim PL_NewResult_afterImpairments As Double = PL_After_BUBA + SECURITIES_DEPRECIATIONS + AdditionalInfoAmount
            PL_NewResult_Intern_IDW = PL_NewResult_afterImpairments + OCBS_IDW_INTERN_Difference
            '*****************************************************************************


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            'EMAIL CREATION AND SEND
            Me.BgwDailyRiskEmail.ReportProgress(75, "Start creating the daily E-Mail")

            Dim OutlookMessage As Outlook.MailItem
            Dim AppOutlook As New Outlook.Application
            OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Dim objNS As Outlook._NameSpace = AppOutlook.Session
            Dim objFolder As Outlook.MAPIFolder
            objFolder = objNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts)



            'Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
            'Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
            'Dim outApp As Microsoft.Office.Interop.Outlook.Application


            'outApp = New Microsoft.Office.Interop.Outlook.Application

            'NSpace = outApp.GetNamespace("MAPI")
            'Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
            'EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
            'EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

            OutlookMessage.Importance = Outlook.OlImportance.olImportanceHigh

            'EItem.To = To_MemoEdit.Text
            OutlookMessage.To = To_MemoEdit.Text

            'EItem.CC = CC_MemoEdit.Text
            OutlookMessage.CC = CC_MemoEdit.Text

            'EItem.BCC = BCC_MemoEdit.Text
            OutlookMessage.BCC = BCC_MemoEdit.Text

            'EItem.Subject = "DAILY RISK CONTROL OVERVIEW on " & EmailDataDate
            OutlookMessage.Subject = "DAILY RISK CONTROL OVERVIEW on " & EmailDataDate

            'Attach all files in Email
            For Each File In System.IO.Directory.GetFiles(ReportExpFile)
                'EItem.Attachments.Add(File)
                OutlookMessage.Attachments.Add(File)
            Next File

            'EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatHTML

            Dim absatz As String = "<html><body><br><br></font></body></html>"

            Dim StrBody1 As String = "<html><body><font size=2>******This is an automated E-Mail, generated from the PS TOOL Application!******<br><br>"
            Dim StrBody2 As String = "<html><body><b><font color=""Blue"" size=2><U>Dear Colleagues,<br>" _
                                                                    + " <font color=""Blue""><U>for your information the daily risk control overview on " & EmailDataDate & " as follows:<U><br><br></font></body></html>"

            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Profit + Loss E-Mail body")
            'Profit/Loss
            Dim StrBody3 As String = ""
            Dim StrBody3_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Profit / Loss result (according to NGS market value approach for FX evaluation)</font></body></html>"
            If ProfitLossResult > 0 Then
                StrBody3 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(ProfitLossResult, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf ProfitLossResult < 0 Then
                StrBody3 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(ProfitLossResult, "#,##0.00 €") & "<br></font></body></html>"
            Else
                StrBody3 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(ProfitLossResult, "#,##0.00 €") & "<br></font></body></html>"
            End If
            'BUBA Interests
            Dim BUBA_Interest_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Unbooked Bundesbank Interest Amount </font></body></html>"
            Dim BUBA_Interest_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(BUBA_InterestAmount, "#,##0.00 €") & "<br></font></body></html>"
            If BUBA_InterestAmount > 0 Then
                BUBA_Interest_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(BUBA_InterestAmount, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf BUBA_InterestAmount < 0 Then
                BUBA_Interest_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(BUBA_InterestAmount, "#,##0.00 €") & "<br></font></body></html>"
            Else
                BUBA_Interest_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(BUBA_InterestAmount, "#,##0.00 €") & "<br></font></body></html>"
            End If
            'Profit/Loss after BUBA
            Dim PL_AfterBUBA_Text As String = "<html><body><b><font color=""White"" face=""calibri"" size=2>Profit/Loss after Bundesbank Interest Adjustment</font></body></html>"
            Dim PL_AfterBUBA_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            If PL_After_BUBA > 0 Then
                PL_AfterBUBA_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf PL_After_BUBA < 0 Then
                PL_AfterBUBA_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            Else
                PL_AfterBUBA_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            End If

            'Securities Depreciations
            Dim SecuritiesDepreciations_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Actual Depreciation in current Year</font></body></html>"
            Dim SecuritiesDepreciations_Value As String = ""
            If SECURITIES_DEPRECIATIONS > 0 Then
                SecuritiesDepreciations_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(SECURITIES_DEPRECIATIONS, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf PL_NewResult_Intern_IDW < 0 Then
                SecuritiesDepreciations_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(SECURITIES_DEPRECIATIONS, "#,##0.00 €") & "<br></font></body></html>"
            Else
                SecuritiesDepreciations_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(SECURITIES_DEPRECIATIONS, "#,##0.00 €") & "<br></font></body></html>"
            End If
            'Additional Infos on P/L
            Dim AdditionalInfoPL_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & AdditionalInfoText & "</font></body></html>"
            Dim AdditionalInfoPL_Value As String = ""
            If AdditionalInfoAmount > 0 Then
                AdditionalInfoPL_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(AdditionalInfoAmount, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf PL_NewResult_Intern_IDW < 0 Then
                AdditionalInfoPL_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(AdditionalInfoAmount, "#,##0.00 €") & "<br></font></body></html>"
            Else
                AdditionalInfoPL_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(AdditionalInfoAmount, "#,##0.00 €") & "<br></font></body></html>"
            End If
            'Profit and Loss after Impairment Provision
            Dim PL_NewResult_afterImpairments_Text As String = Nothing
            PL_NewResult_afterImpairments_Text = "<html><body><b><font color=""White"" face=""calibri"" size=2>Profit / Loss result (after a.m. Impairments)</font></body></html>"
            Dim PL_NewResult_afterImpairments_Value As String = ""
            If PL_NewResult_afterImpairments > 0 Then
                PL_NewResult_afterImpairments_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(PL_NewResult_afterImpairments, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf PL_NewResult_afterImpairments < 0 Then
                PL_NewResult_afterImpairments_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(PL_NewResult_afterImpairments, "#,##0.00 €") & "<br></font></body></html>"
            Else
                PL_NewResult_afterImpairments_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(PL_NewResult_afterImpairments, "#,##0.00 €") & "<br></font></body></html>"
            End If

            'IDW OCBS Difference Internal
            Dim OCBS_IDW_INTERN_Difference_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Difference between Modified IDW and NGS FX Revaluation</font></body></html>"
            Dim OCBS_IDW_INTERN_Difference_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(OCBS_IDW_INTERN_Difference, "#,##0.00 €") & "<br></font></body></html>"
            If OCBS_IDW_INTERN_Difference > 0 Then
                OCBS_IDW_INTERN_Difference_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(OCBS_IDW_INTERN_Difference, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf OCBS_IDW_INTERN_Difference < 0 Then
                OCBS_IDW_INTERN_Difference_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(OCBS_IDW_INTERN_Difference, "#,##0.00 €") & "<br></font></body></html>"
            Else
                OCBS_IDW_INTERN_Difference_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(OCBS_IDW_INTERN_Difference, "#,##0.00 €") & "<br></font></body></html>"
            End If
            'Profit and Loss recalculated IDW INTERNAL (After BUBA Interests)
            Dim PL_NewResult_Intern_IDW_Text As String = "<html><body><b><font color=""White"" face=""calibri"" size=2>Profit / Loss result (Recalculated) based on Modified IDW (Internal reference)</font></body></html>"
            Dim PL_NewResult_Intern_IDW_Value As String = ""
            If PL_NewResult_Intern_IDW > 0 Then
                PL_NewResult_Intern_IDW_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(PL_NewResult_Intern_IDW, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf PL_NewResult_Intern_IDW < 0 Then
                PL_NewResult_Intern_IDW_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(PL_NewResult_Intern_IDW, "#,##0.00 €") & "<br></font></body></html>"
            Else
                PL_NewResult_Intern_IDW_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(PL_NewResult_Intern_IDW, "#,##0.00 €") & "<br></font></body></html>"
            End If




            'Local GAAP Profit/Loss Result (before BUBA Interests)
            Dim StrBody3_2 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LOCAL GAAP PROFIT/LOSS<br><font color=""Blue"" size=2>(Info:HGB Profit/Loss before Bundesbank Interest Adjustment<br></font></body></html>"
            Dim StrBody3_22 As String = Nothing
            If HGB_PL_Calculated > 0 Then
                StrBody3_22 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(HGB_PL_Calculated, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf HGB_PL_Calculated < 0 Then
                StrBody3_22 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(HGB_PL_Calculated, "#,##0.00 €") & "<br></font></body></html>"
            Else
                StrBody3_22 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(HGB_PL_Calculated, "#,##0.00 €") & "<br></font></body></html>"
            End If
            'Local GAAP Profit/Loss Result (after BUBA Interests)
            Dim StrBody3_3 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LOCAL GAAP PROFIT/LOSS<br><font color=""Blue"" size=2>(Info:HGB Profit/Loss after Bundesbank Interest Adjustment<br></font></body></html>"
            Dim StrBody3_33 As String = ""
            If HGB_PL_After_BUBA > 0 Then
                StrBody3_33 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(HGB_PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            ElseIf HGB_PL_After_BUBA < 0 Then
                StrBody3_33 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(HGB_PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            Else
                StrBody3_33 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(HGB_PL_After_BUBA, "#,##0.00 €") & "<br></font></body></html>"
            End If


            'Obligo Liability Surplus
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Obligo liability Surplus E-Mail body")
            Dim StrBody4_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Obligo Liability surplus (HGB)<br></font></body></html>"
            Dim StrBody4 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(ObligoLiabilitySurplusHGB, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBodyText_OLS_RiskSubtotal As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Obligo Liability surplus (Risk Subtotal)<br></font></body></html>"
            'Dim StrBodyValue_OLS_RiskSubtotal As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(ObligoLiabilitySurplusRiskSubtotal, "#,##0.00 €") & "<br></font></body></html>"

            'FX Position
            'Me.BgwDailyRiskEmail.ReportProgress(75, "Create FX Position E-Mail body")
            'Dim StrBody5_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>FX Position<br></font></body></html>"
            'Dim StrBody5 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(FX_Position, "#,##0.00 $") & "<br></font></body></html>"

            'Capital Adequacy ratio
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create CAR E-Mail body")
            Dim StrBody6_1 As String = ""
            Dim StrBody6 As String = ""
            If EmailDataDate <= DateSerial(2016, 3, 30) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Capital Adequacy ratio <br><font color=""Blue"" size=1>(Info: Before 10.12.2014 not less than 8,00 %<br><font color=""Blue"" size=2>Since 10.12.2014 not less than 10,40 %)<br></font></body></html>"
                StrBody6 = ""
                If EmailDataDate <= DateSerial(2014, 12, 9) Then
                    If CAR_Value * 100 >= 8.5 And CAR_Value * 100 < 9.5 Then
                        StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    ElseIf CAR_Value * 100 >= 8 And CAR_Value * 100 < 8.5 Then
                        StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    ElseIf CAR_Value * 100 < 8 Then
                        StrBody6 = "<html><body><b><font color=""Crimson"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    ElseIf CAR_Value * 100 >= 9.5 Then
                        StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    End If
                ElseIf EmailDataDate >= DateSerial(2014, 12, 10) And EmailDataDate <= DateSerial(2016, 3, 30) Then
                    If CAR_Value * 100 >= 11.4 And CAR_Value * 100 < 13.4 Then
                        StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    ElseIf CAR_Value * 100 < 11.4 Then
                        StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    ElseIf CAR_Value * 100 >= 13.4 Then
                        StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                    End If
                End If
            ElseIf EmailDataDate >= DateSerial(2016, 3, 31) And EmailDataDate < DateSerial(2016, 8, 7) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Capital Adequacy ratio <br><font color=""Blue"" size=2>(Info: Since 10.12.2014 not less than 10,40 %<br><font color=""Blue"" size=2>Since 31.03.2016  additional 0,625 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 0,625 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 12.025 And CAR_Value * 100 < 14.025 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 12.025 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 14.025 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2016, 8, 7) And EmailDataDate < DateSerial(2016, 10, 27) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br><font color=""Blue"" size=2>(Info: Since 10.12.2014 not less than 10,40 %<br><font color=""Blue"" size=2>Since 31.03.2016  additional 0,625 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 0,625 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 12.025 And CAR_Value * 100 < 14.025 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 12.025 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 14.025 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2016, 10, 27) And EmailDataDate < DateSerial(2016, 11, 15) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br><font color=""Blue"" size=2>(Info: Since 27.10.2016 not less than 9,20 %<br><font color=""Blue"" size=2>Since 31.03.2016  additional 0,625 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 0,625 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 12.025 And CAR_Value * 100 < 14.025 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 12.025 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 14.025 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2016, 11, 15) And EmailDataDate < DateSerial(2017, 1, 1) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br><font color=""Blue"" size=2>(Info: Since 27.10.2016 not less than 9,20 %<br><font color=""Blue"" size=2>Since 31.03.2016  additional 0,625 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 0,625 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 10.825 And CAR_Value * 100 < 12.825 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 10.825 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 12.825 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2017, 1, 1) And EmailDataDate < DateSerial(2018, 1, 17) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br><font color=""Blue"" size=2>(Info: Since 27.10.2016 not less than 9,20 %<br><font color=""Blue"" size=2>Since 01.01.2017  additional 1,25 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 1,25 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 12.7 And CAR_Value * 100 < 14.7 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 12.7 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 14.7 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2018, 1, 17) And EmailDataDate < DateSerial(2019, 2, 22) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br><font color=""Blue"" size=2>(Info: Since 19.01.2018 not less than 9,50 %<br><font color=""Blue"" size=2>Since 17.01.2018  additional 1,875 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 1,875 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 12.7 And CAR_Value * 100 < 14.7 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 12.7 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 14.7 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2019, 2, 22) Then
                StrBody6_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br></font></body></html>"
                StrBody6 = ""
                If CAR_Value * 100 >= 15.5 And CAR_Value * 100 < 17.5 Then
                    StrBody6 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 < 15.5 Then
                    StrBody6 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                ElseIf CAR_Value * 100 >= 17.5 Then
                    StrBody6 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
                End If
            End If

            'Capital Adequacy ratio
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create CapitalRatio_T1 body")
            Dim CapitalRatio_T1_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
            Dim CapitalRatio_T1_Text As String = Nothing
            If EmailDataDate < DateSerial(2017, 1, 1) Then
                CapitalRatio_T1_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>T1 Capital ratio<br><font color=""Blue"" size=2>(Info: Since 27.10.2016 not less than 6,90 %<br><font color=""Blue"" size=2>Since 31.03.2016  additional 0,625 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 0,625 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                If CapitalRatio_T1 * 100 >= 8.275 And CapitalRatio_T1 * 100 < 9.775 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 < 8.275 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 >= 9.775 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2017, 1, 1) And EmailDataDate < DateSerial(2018, 1, 19) Then
                CapitalRatio_T1_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>T1 Capital ratio<br><font color=""Blue"" size=2>(Info: Since 27.10.2016 not less than 6,90 %<br><font color=""Blue"" size=2>Since 01.01.2017  additional 1,25 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 1,25 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                If CapitalRatio_T1 * 100 >= 10.15 And CapitalRatio_T1 * 100 < 11.65 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 < 10.15 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 >= 11.65 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2018, 1, 19) And EmailDataDate < DateSerial(2019, 2, 22) Then
                CapitalRatio_T1_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>T1 Capital ratio<br><font color=""Blue"" size=2>(Info: Since 19.01.2018 not less than 7,125 %<br><font color=""Blue"" size=2>Since 17.01.2018  additional 1,875 % for Capital conservation buffer<br><font color=""Blue"" size=2>plus max. 1,875 % for Institution specific countercyclical capital buffer)<br></font></body></html>"
                If CapitalRatio_T1 * 100 >= 10.15 And CapitalRatio_T1 * 100 < 11.65 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 < 10.15 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 >= 11.65 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2018, 2, 22) Then
                CapitalRatio_T1_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>T1 Capital ratio<br></font></body></html>"
                If CapitalRatio_T1 * 100 >= 12.875 And CapitalRatio_T1 * 100 < 14.375 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 < 12.875 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                ElseIf CapitalRatio_T1 * 100 >= 14.375 Then
                    CapitalRatio_T1_Amount = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
                End If
            End If




            'Core Capital - TIER 1 Capital
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Core Capital E-Mail body")
            Dim StrBody7_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>TIER 1 Capital <br></font></body></html>"
            Dim StrBody7 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CapitalForSolva, "#,##0.00 €") & "<br></font></body></html>"

            'Core Capital - Eligible Capital for Large Loans
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Eligible Capital for Large Loans E-Mail body")
            Dim EligibleCapital_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Eligible Capital <br></font></body></html>"
            Dim EligibleCapital_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(EligibleCapitalLargeLoans, "#,##0.00 €") & "<br></font></body></html>"

            'Own Funds
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Core Capital E-Mail body")
            Dim StrBodyOwnFunds_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Own Funds<br></font></body></html>"
            Dim StrBodyOwnFunds_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(OwnFunds, "#,##0.00 €") & "<br></font></body></html>"

            'Minimum Capital Requirement
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Minimum Capital requirement E-Mail body")
            Dim StrBody8_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Minimum Capital requirement<br></font></body></html>"
            Dim StrBody8 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(MinCapitalReq * 1000, "#,##0.00 €") & "<br></font></body></html>"

            'Liquidity
            'Me.BgwDailyRiskEmail.ReportProgress(75, "Create Liquidity E-Mail body")
            'Dim StrBody9_1 As String = Nothing
            'Dim StrBody9 As String = ""
            'Dim StrBody9_2 As String = ""
            'If EmailDataDate <= DateSerial(2015, 12, 31) Then
            '    StrBody9_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LiquidLV <br><font color=""Blue"" size=1>(Info: Not less than 0,6)<br></font></body></html>"
            '    If LiquidLV * 100 < 0.6 Then
            '        StrBody9 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>Violation<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 0.6 And LiquidLV * 100 < 0.7 Then
            '        StrBody9 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>Danger Violation<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 0.7 And LiquidLV * 100 < 1 Then
            '        StrBody9 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>Irrevocable lending limit is in use LiquidLV=1,0<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 1 Then
            '        StrBody9 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>Irrevocable lending limit is not in use<br></font></body></html>"
            '    End If
            'ElseIf EmailDataDate >= DateSerial(2016, 1, 1) And EmailDataDate <= DateSerial(2016, 12, 31) Then
            '    StrBody9_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LiquidLV <br><font color=""Blue"" size=1>(Info: Not less than 0,7)<br></font></body></html>"
            '    If LiquidLV * 100 < 0.7 Then
            '        StrBody9 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>Violation<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 0.7 And LiquidLV * 100 < 0.8 Then
            '        StrBody9 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>Danger Violation<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 0.8 And LiquidLV * 100 < 1 Then
            '        StrBody9 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>Irrevocable lending limit is in use LiquidLV=1,0<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 1 Then
            '        StrBody9 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>Irrevocable lending limit is not in use<br></font></body></html>"
            '    End If
            'ElseIf EmailDataDate >= DateSerial(2017, 1, 1) And EmailDataDate <= DateSerial(2017, 12, 31) Then
            '    StrBody9_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LiquidLV <br><font color=""Blue"" size=1>(Info: Not less than 0,8)<br></font></body></html>"
            '    If LiquidLV * 100 < 0.8 Then
            '        StrBody9 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>Violation<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 0.8 And LiquidLV * 100 < 0.9 Then
            '        StrBody9 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>Danger Violation<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 0.9 And LiquidLV * 100 < 1 Then
            '        StrBody9 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>Irrevocable lending limit is in use LiquidLV=1,0<br></font></body></html>"
            '    ElseIf LiquidLV * 100 >= 1 Then
            '        StrBody9 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LiquidLV * 100, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
            '        StrBody9_2 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>Irrevocable lending limit is not in use<br></font></body></html>"
            '    End If
            'End If


            'LCR Ratio
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create LCR Ratio E-Mail body")
            Dim StrBody24_1 As String = Nothing
            Dim StrBody24 As String = ""
            If EmailDataDate <= DateSerial(2015, 12, 31) Then
                StrBody24_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio <br><font color=""Blue"" size=1>(Info: Not less than 0,6)<br></font></body></html>"
                If LCR_Ratio < 0.6 Then
                    StrBody24 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.6 And LCR_Ratio <= 0.8 Then
                    StrBody24 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio > 0.8 Then
                    StrBody24 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2016, 1, 1) And EmailDataDate < DateSerial(2016, 9, 30) Then
                StrBody24_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio <br><font color=""Blue"" size=1>(Info: Not less than 0,7)<br></font></body></html>"
                If LCR_Ratio < 0.7 Then
                    StrBody24 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.7 And LCR_Ratio < 0.8 Then
                    StrBody24 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.8 And LCR_Ratio < 1 Then
                    StrBody24 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio > 0.8 Then
                    StrBody24 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2016, 9, 30) And EmailDataDate <= DateSerial(2016, 12, 31) Then
                StrBody24_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio (Delegated Act) <br><font color=""Blue"" size=1>(Info: Not less than 0,7)<br></font></body></html>"
                If LCR_Ratio < 0.7 Then
                    StrBody24 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.7 And LCR_Ratio < 0.8 Then
                    StrBody24 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.8 And LCR_Ratio < 1 Then
                    StrBody24 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1 Then
                    StrBody24 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2017, 1, 1) And EmailDataDate <= DateSerial(2018, 1, 18) Then
                StrBody24_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio (Delegated Act) <br><font color=""Blue"" size=1>(Info: Not less than 0,8)<br></font></body></html>"
                If LCR_Ratio < 0.8 Then
                    StrBody24 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.8 And LCR_Ratio < 0.9 Then
                    StrBody24 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 0.9 And LCR_Ratio < 1 Then
                    StrBody24 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1 Then
                    StrBody24 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2017, 1, 19) And EmailDataDate < DateSerial(2019, 2, 22) Then
                StrBody24_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio (Delegated Act) <br><font color=""Blue"" size=1>(Info: Not less than 1,0)<br></font></body></html>"
                If LCR_Ratio < 1 Then
                    StrBody24 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1 And LCR_Ratio < 1.1 Then
                    StrBody24 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1.1 And LCR_Ratio < 1.2 Then
                    StrBody24 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1.2 Then
                    StrBody24 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                End If
            ElseIf EmailDataDate >= DateSerial(2019, 2, 22) Then
                StrBody24_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio (Delegated Act) <br><font color=""Blue"" size=1>(Info: Not less than 1,0)<br></font></body></html>"
                If LCR_Ratio < 1 Then
                    StrBody24 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1 And LCR_Ratio < 1.05 Then
                    StrBody24 = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1.05 And LCR_Ratio < 1.1 Then
                    StrBody24 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                ElseIf LCR_Ratio >= 1.1 Then
                    StrBody24 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
                End If
            End If


            'Customer Demand Deposits
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Customer Demand Deposits E-Mail body")
            Dim StrBody10_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Customer demand deposits (without Suspense Acc.)<br></font></body></html>"
            Dim StrBody10 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(BilanzCustDeposit, "#,##0.00 €") & "<br></font></body></html>"

            'Credit Risk (with and without Cash pledge)
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Credit Risk (with and without Cash pledge) E-Mail body")
            Dim StrBody11_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Credit Risk <br><font color=""Blue"">(No Cash pledge consideration)<br></font></body></html>"
            Dim StrBody11 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CreditRisk, "#,##0.00 €") & "<br></font></body></html>"
            Dim StrBody111_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Credit Risk <br><font color=""Blue"" size=1>(LGD 45%)<br></font></body></html>"
            Dim StrBody111 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CreditRiskCP, "#,##0.00 €") & "<br></font></body></html>"

            'Interest Rate Risk
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Interest Rate Risk E-Mail body")
            Dim StrBody12_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk - ABSOLUTE HIGHEST FIGURE <br><font color=""Blue"" size=1>(Info: Not higher than 20,00 %)<br></font></body></html>"
            Dim StrBody12 As String = ""
            If InterestRateRisk * 100 <= 15 Then
                StrBody12 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(InterestRateRisk, "#0.00 %") & "<br></font></body></html>"
            ElseIf InterestRateRisk * 100 > 15 And InterestRateRisk * 100 <= 20 Then
                StrBody12 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(InterestRateRisk, "#0.00 %") & "<br></font></body></html>"
            ElseIf InterestRateRisk * 100 > 20 Then
                StrBody12 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(InterestRateRisk, "#0.00 %") & "<br></font></body></html>"
            End If
            Dim StrBody12_2 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk (- 200 bps) <br></font></body></html>"
            Dim StrBody12_2_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(InterestRateRiskMinus200, "#0.00 %") & "<br></font></body></html>"
            Dim StrBody12_3 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk (+ 200 bps) <br></font></body></html>"
            Dim StrBody12_3_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(InterestRateRiskPlus200, "#0.00 %") & "<br></font></body></html>"

            'Interest Rate Risk Amount (Weighting Factor 50%)
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Interest Rate Risk (WF 50%) E-Mail body")
            Dim StrBody13_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk Amount (RGB)<br></font></body></html>"
            Dim StrBody13 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(InterestRateRiskAmount50bps, "#,##0.00 €") & "<br></font></body></html>"

            'Currency Risk
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Currency Risk E-Mail body")
            Dim StrBody14_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Currency Risk<br></font></body></html>"
            Dim StrBody14 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CurrencyRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

            'Operational Risk
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Operational Risk E-Mail body")
            Dim StrBody15_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Operational Risk<br></font></body></html>"
            Dim StrBody15 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(OperationalRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

            'Liquidity Risk
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Liquidity Risk E-Mail body")
            Dim StrBody16_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Liquidity Risk<br></font></body></html>"
            Dim StrBody16 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(LiquidityRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

            'Market Price Risk of securities
            'Me.BgwDailyRiskEmail.ReportProgress(75, "Create Market Price Risk of Securities E-Mail body")
            'Dim StrBody17_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Market price risk of securities<br></font></body></html>"
            'Dim StrBody17 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(MarketPriceRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

            'CCB Guarantees Amount
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create CCB Guarantees Amount E-Mail body")
            Dim StrBody21_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB Guarantees Amount<br></font></body></html>"
            Dim StrBody21 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CCB_Guarantees_Amount, "#,##0.00 €") & "<br></font></body></html>"

            'CCB FX Credit Equivelant Amount
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create FX Credit Equivalent Amount body")
            Dim StrBody22_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB FX Credit Equiv. Amount<br></font></body></html>"
            Dim StrBody22 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CCB_Credit_Equiv_Amount, "#,##0.00 €") & "<br></font></body></html>"

            'CCB FX CREDIT TOTAL
            Dim StrBody23_1 As String = Nothing
            If EmailDataDate <= DateSerial(2017, 6, 20) Then
                StrBody23_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB FX Credit Equiv. Amount (incl. Guarantees)<br><font color=""Green"" size=1>(Info: <=75 Mio.€ NO MEASURES<br><font color=""DarkOrange"" size=1>>75 Mio.€ <=90 Mio.€ EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM<br><font color=""Red"" size=1>>90 Mio.€ NO TRANSACTIONS)<br></font></body></html>"
            ElseIf EmailDataDate > DateSerial(2017, 6, 20) Then
                StrBody23_1 = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB FX Credit Equiv. Amount (incl. Guarantees)<br><font color=""Green"" size=1>(Info: <=130 Mio.€ NO MEASURES<br><font color=""DarkOrange"" size=1>>130 Mio.€ <=140 Mio.€ EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM<br><font color=""Red"" size=1>>140 Mio.€ NO TRANSACTIONS)<br></font></body></html>"
            End If

            'Dim StrBody23_3 As String = "<html><body><b><font color=""Green"" size=1>(Info: <=75.000.000,00 NO MEASURES)<br><font color=""DarkOrange"" size=1>(>75.000.000,00 <=90.000.000,00 EVERY TRANSACTION NEEDS TO BE CONFIRMED BY GM)<br><font color=""Red"" size=1>(>90.000.000,00 NO TRANSACTIONS)<br></font></body></html>"
            Dim StrBody23 As String = ""
            Dim StrBody23_2 As String = ""
            If EmailDataDate <= DateSerial(2017, 6, 20) Then
                If CCB_FX_CREDIT_TOTAL <= 75000000 Then
                    StrBody23 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
                    StrBody23_2 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
                ElseIf CCB_FX_CREDIT_TOTAL > 75000000 And CCB_FX_CREDIT_TOTAL <= 90000000 Then
                    StrBody23 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
                    StrBody23_2 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
                ElseIf CCB_FX_CREDIT_TOTAL > 90000000 Then
                    StrBody23 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
                    StrBody23_2 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
                End If
            ElseIf EmailDataDate > DateSerial(2017, 6, 20) Then
                If CCB_FX_CREDIT_TOTAL <= 130000000 Then
                    StrBody23 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
                    StrBody23_2 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
                ElseIf CCB_FX_CREDIT_TOTAL > 130000000 And CCB_FX_CREDIT_TOTAL <= 140000000 Then
                    StrBody23 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
                    StrBody23_2 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
                ElseIf CCB_FX_CREDIT_TOTAL > 140000000 Then
                    StrBody23 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
                    StrBody23_2 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
                End If
            End If

            'in Periods
            '3 Months
            'Dim StrBody25_1 As String = "<html><body><b><font color=""Black"" face=""calibri"">duration up to 3 Months<br></font></body></html>"
            'Dim StrBody25 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_Credit_Equiv_Amount_in3M, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBody25_2 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_FX_CREDIT_PERCENT_in3M, "#0.00 %") & "<br></font></body></html>"
            '6 Months
            'Dim StrBody26_1 As String = "<html><body><b><font color=""Black"" face=""calibri"">duration over 3 Months up to 6 Months<br></font></body></html>"
            'Dim StrBody26 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_Credit_Equiv_Amount_in6M, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBody26_2 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_FX_CREDIT_PERCENT_in6M, "#0.00 %") & "<br></font></body></html>"
            '9 Months
            'Dim StrBody27_1 As String = "<html><body><b><font color=""Black"" face=""calibri"">duration over 6 Months up to 9 Months<br></font></body></html>"
            'Dim StrBody27 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_Credit_Equiv_Amount_in9M, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBody27_2 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_FX_CREDIT_PERCENT_in9M, "#0.00 %") & "<br></font></body></html>"
            '12 Months
            'Dim StrBody28_1 As String = "<html><body><b><font color=""Black"" face=""calibri"">duration over 9 Months up to 12 Months<br></font></body></html>"
            'Dim StrBody28 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_Credit_Equiv_Amount_in1Y, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBody28_2 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_FX_CREDIT_PERCENT_in1Y, "#0.00 %") & "<br></font></body></html>"
            'over 1 Yaer till 2 Years
            'Dim StrBody29_1 As String = "<html><body><b><font color=""Black"" face=""calibri"">duration over 1 Year up to 2 Years<br></font></body></html>"
            'Dim StrBody29 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_Credit_Equiv_Amount_over1Y2Y, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBody29_2 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_FX_CREDIT_PERCENT_over1Y2Y, "#0.00 %") & "<br></font></body></html>"
            'over 2 Years
            'Dim StrBody30_1 As String = "<html><body><b><font color=""Black"" face=""calibri"">duration over 2 Years<br></font></body></html>"
            'Dim StrBody30 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_Credit_Equiv_Amount_over2Y, "#,##0.00 €") & "<br></font></body></html>"
            'Dim StrBody30_2 As String = "<html><body><b><font color=""Black"" face=""calibri"">" & Format(CCB_FX_CREDIT_PERCENT_over2Y, "#0.00 %") & "<br></font></body></html>"

            'RISK BEARING CAPACITY - CASH PLEDGE
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Risk Bearing Capacity E-Mail body")
            Dim StrBody19_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>RISK BEARING CAPACITY <br><font color=""Blue"" size=1>(Info: Not higher than 90,00 %)"
            Dim StrBody19 As String = ""
            If RiskBearingCapacity <= 70 Then
                StrBody19 = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(RiskBearingCapacity / 100, "#0.00 %") & "<br></font></body></html>"
            ElseIf RiskBearingCapacity > 70 And RiskBearingCapacity <= 90 Then
                StrBody19 = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(RiskBearingCapacity / 100, "#0.00 %") & "<br></font></body></html>"
            ElseIf RiskBearingCapacity > 90 Then
                StrBody19 = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(RiskBearingCapacity / 100, "#0.00 %") & "<br></font></body></html>"
            End If

            'BALANCE SHEET SUM
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Balance Sheet Sum E-Mail body")
            Dim StrBody20_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>NGS Balance Sheet Sum<br></font></body></html>"
            Dim StrBody20 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(BalanceTotal, "#,##0.00 €") & "<br></font></body></html>"

            'KAPITALERHALTUNGSPUFFER
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Capital conservation buffer E-Mail body")
            Dim StrBodyCapitalConservationBuffer_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Capital conservation buffer<br></font></body></html>"
            Dim StrBodyCapitalConservationBuffer_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(Kapitalerhaltungspuffer, "#,##0.00 €") & "<br></font></body></html>"
            'ANTIZYKLISCHER KAPITAL PUFFER
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Institution specific countercyclical capital buffer E-Mail body")
            Dim StrBodyAntizyklischerKapitalBuffer_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Institution specific countercyclical capital buffer<br></font></body></html>"
            Dim StrBodyAntizyklischerKapitalBuffer_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(AntizyklischerKapitalpuffer, "#,##0.00 €") & "<br></font></body></html>"

            'LARGE LOANS EXPOSURE
            'Large Loans Exposure without HGB340F
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Large Loans Exposure without HGB340F E-Mail body")
            Dim StrBodyLargeLoansExposureNoHGB340F_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Large Loans Exposure Limit (not including HGB340F) for Corporates<br></font></body></html>"
            Dim StrBodyLargeLoansExposureNoHGB340F_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(LARGE_LOANS_EXPOSURE, "#,##0.00 €") & "<br></font></body></html>"
            'Large Loans Exposure with HGB340F
            Me.BgwDailyRiskEmail.ReportProgress(75, "Create Large Loans Exposure with HGB340F E-Mail body")
            Dim StrBodyLargeLoansExposureYesHGB340F_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=1.5>Large Loans Exposure Limit (including HGB340F) for Corporates<br></font></body></html>"
            Dim StrBodyLargeLoansExposureYesHGB340F_Memo As String = "<html><body><b><font color=""Blue"" face=""calibri"" size=1.5>Only in emergency cases after timely prior approval of Senior Management<br></font></body></html>"
            Dim StrBodyLargeLoansExposureYesHGB340F_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=1.5>" & Format(LARGE_LOANS_EXPOSURE_HGB340F, "#,##0.00 €") & "<br></font></body></html>"


            '& TabelleStart & ZelleStart & StrBody11_1 & ZelleEnde & ZelleStartZahl & StrBody11 & ZelleEnde & TabelleEnde _  (Credit Risk without Cash pledge)

            'EItem.HTMLBody = StrBody1 & StrBody2 _
            'Check if Additional Information for P/L is not nothing
            If AdditionalInfoText <> "" Then
                OutlookMessage.HTMLBody = StrBody1 & StrBody2 _
                         & TabelleStart & ZelleStart & StrBody3_1 & ZelleEnde & ZelleStartZahl & StrBody3 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & BUBA_Interest_Text & ZelleEnde & ZelleStartZahl & BUBA_Interest_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStartBackgroundBlue & PL_AfterBUBA_Text & ZelleEnde & ZelleStartZahl & PL_AfterBUBA_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & SecuritiesDepreciations_Text & ZelleEnde & ZelleStartZahl & SecuritiesDepreciations_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & AdditionalInfoPL_Text & ZelleEnde & ZelleStartZahl & AdditionalInfoPL_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStartBackgroundBlue & PL_NewResult_afterImpairments_Text & ZelleEnde & ZelleStartZahl & PL_NewResult_afterImpairments_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & OCBS_IDW_INTERN_Difference_Text & ZelleEnde & ZelleStartZahl & OCBS_IDW_INTERN_Difference_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStartBackgroundBlue & PL_NewResult_Intern_IDW_Text & ZelleEnde & ZelleStartZahl & PL_NewResult_Intern_IDW_Value & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody4_1 & ZelleEnde & ZelleStartZahl & StrBody4 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody10_1 & ZelleEnde & ZelleStartZahl & StrBody10 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody20_1 & ZelleEnde & ZelleStartZahl & StrBody20 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody7_1 & ZelleEnde & ZelleStartZahl & StrBody7 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & EligibleCapital_Text & ZelleEnde & ZelleStartZahl & EligibleCapital_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyOwnFunds_Text & ZelleEnde & ZelleStartZahl & StrBodyOwnFunds_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody8_1 & ZelleEnde & ZelleStartZahl & StrBody8 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody111_1 & ZelleEnde & ZelleStartZahl & StrBody111 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody13_1 & ZelleEnde & ZelleStartZahl & StrBody13 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody14_1 & ZelleEnde & ZelleStartZahl & StrBody14 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody15_1 & ZelleEnde & ZelleStartZahl & StrBody15 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody16_1 & ZelleEnde & ZelleStartZahl & StrBody16 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody21_1 & ZelleEnde & ZelleStartZahl & StrBody21 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody22_1 & ZelleEnde & ZelleStartZahl & StrBody22 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody23_1 & ZelleEnde & ZelleStartZahl & StrBody23 & ZelleEnde & ZelleStartZahl & StrBody23_2 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody6_1 & ZelleEnde & ZelleStartResult & StrBody6 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & CapitalRatio_T1_Text & ZelleEnde & ZelleStartResult & CapitalRatio_T1_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyCapitalConservationBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyCapitalConservationBuffer_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyAntizyklischerKapitalBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyAntizyklischerKapitalBuffer_Amount & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBodyLargeLoansExposureNoHGB340F_Text & ZelleEnde & ZelleStartResult & StrBodyLargeLoansExposureNoHGB340F_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyLargeLoansExposureYesHGB340F_Text & ZelleEnde & ZelleStartResult & StrBodyLargeLoansExposureYesHGB340F_Amount & ZelleEnde & ZelleStart & StrBodyLargeLoansExposureYesHGB340F_Memo & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody24_1 & ZelleEnde & ZelleStartResult & StrBody24 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody12_1 & ZelleEnde & ZelleStartResult & StrBody12 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody12_2 & ZelleEnde & ZelleStartResult & StrBody12_2_1 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody12_3 & ZelleEnde & ZelleStartResult & StrBody12_3_1 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody19_1 & ZelleEnde & ZelleStartResult & StrBody19 & ZelleEnde & TabelleEnde
            Else
                OutlookMessage.HTMLBody = StrBody1 & StrBody2 _
                         & TabelleStart & ZelleStart & StrBody3_1 & ZelleEnde & ZelleStartZahl & StrBody3 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & BUBA_Interest_Text & ZelleEnde & ZelleStartZahl & BUBA_Interest_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & PL_AfterBUBA_Text & ZelleEnde & ZelleStartZahl & PL_AfterBUBA_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & SecuritiesDepreciations_Text & ZelleEnde & ZelleStartZahl & SecuritiesDepreciations_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & PL_NewResult_afterImpairments_Text & ZelleEnde & ZelleStartZahl & PL_NewResult_afterImpairments_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & OCBS_IDW_INTERN_Difference_Text & ZelleEnde & ZelleStartZahl & OCBS_IDW_INTERN_Difference_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & PL_NewResult_Intern_IDW_Text & ZelleEnde & ZelleStartZahl & PL_NewResult_Intern_IDW_Value & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody4_1 & ZelleEnde & ZelleStartZahl & StrBody4 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody10_1 & ZelleEnde & ZelleStartZahl & StrBody10 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody20_1 & ZelleEnde & ZelleStartZahl & StrBody20 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody7_1 & ZelleEnde & ZelleStartZahl & StrBody7 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & EligibleCapital_Text & ZelleEnde & ZelleStartZahl & EligibleCapital_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyOwnFunds_Text & ZelleEnde & ZelleStartZahl & StrBodyOwnFunds_Value & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody8_1 & ZelleEnde & ZelleStartZahl & StrBody8 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody111_1 & ZelleEnde & ZelleStartZahl & StrBody111 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody13_1 & ZelleEnde & ZelleStartZahl & StrBody13 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody14_1 & ZelleEnde & ZelleStartZahl & StrBody14 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody15_1 & ZelleEnde & ZelleStartZahl & StrBody15 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody16_1 & ZelleEnde & ZelleStartZahl & StrBody16 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody21_1 & ZelleEnde & ZelleStartZahl & StrBody21 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody22_1 & ZelleEnde & ZelleStartZahl & StrBody22 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody23_1 & ZelleEnde & ZelleStartZahl & StrBody23 & ZelleEnde & ZelleStartZahl & StrBody23_2 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody6_1 & ZelleEnde & ZelleStartResult & StrBody6 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & CapitalRatio_T1_Text & ZelleEnde & ZelleStartResult & CapitalRatio_T1_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyCapitalConservationBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyCapitalConservationBuffer_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyAntizyklischerKapitalBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyAntizyklischerKapitalBuffer_Amount & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBodyLargeLoansExposureNoHGB340F_Text & ZelleEnde & ZelleStartResult & StrBodyLargeLoansExposureNoHGB340F_Amount & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBodyLargeLoansExposureYesHGB340F_Text & ZelleEnde & ZelleStartResult & StrBodyLargeLoansExposureYesHGB340F_Amount & ZelleEnde & ZelleStart & StrBodyLargeLoansExposureYesHGB340F_Memo & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody24_1 & ZelleEnde & ZelleStartResult & StrBody24 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody12_1 & ZelleEnde & ZelleStartResult & StrBody12 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody12_2 & ZelleEnde & ZelleStartResult & StrBody12_2_1 & ZelleEnde & TabelleEnde _
                          & TabelleStart & ZelleStart & StrBody12_3 & ZelleEnde & ZelleStartResult & StrBody12_3_1 & ZelleEnde & TabelleEnde _
                          & absatz _
                          & TabelleStart & ZelleStart & StrBody19_1 & ZelleEnde & ZelleStartResult & StrBody19 & ZelleEnde & TabelleEnde
            End If

            'Local GAAP P/L Before and after Bundesbank adjustment
            '& absatz _
            '& TabelleStart & ZelleStart & StrBody3_2 & ZelleEnde & ZelleStartZahl & StrBody3_22 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody3_3 & ZelleEnde & ZelleStartZahl & StrBody3_33 & ZelleEnde & TabelleEnde _


            '& TabelleStart & ZelleStart & StrBody9_1 & ZelleEnde & ZelleStartResult & StrBody9 & ZelleEnde & ZelleStartZahl & StrBody9_2 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody17_1 & ZelleEnde & ZelleStartZahl & StrBody17 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody25_1 & ZelleEnde & ZelleStartZahl & StrBody25 & ZelleEnde & ZelleStartZahl & StrBody25_2 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody26_1 & ZelleEnde & ZelleStartZahl & StrBody26 & ZelleEnde & ZelleStartZahl & StrBody26_2 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody27_1 & ZelleEnde & ZelleStartZahl & StrBody27 & ZelleEnde & ZelleStartZahl & StrBody27_2 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody28_1 & ZelleEnde & ZelleStartZahl & StrBody28 & ZelleEnde & ZelleStartZahl & StrBody28_2 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody29_1 & ZelleEnde & ZelleStartZahl & StrBody29 & ZelleEnde & ZelleStartZahl & StrBody29_2 & ZelleEnde & TabelleEnde _
            '& TabelleStart & ZelleStart & StrBody30_1 & ZelleEnde & ZelleStartZahl & StrBody30 & ZelleEnde & ZelleStartZahl & StrBody30_2 & ZelleEnde & TabelleEnde _

            Me.BgwDailyRiskEmail.ReportProgress(85, "E-Mail created and ready to send")
            If Me.SendEmail_CheckEdit.CheckState = CheckState.Checked Then
                'EItem.Send()
                OutlookMessage.Send()
                Me.BgwDailyRiskEmail.ReportProgress(90, "E-Mail send with sucess")
                Directory.Delete(ReportExpFile, True)
                Me.BgwDailyRiskEmail.ReportProgress(95, "Temporary Report directory deleted")
                Me.BgwDailyRiskEmail.ReportProgress(100, "Daily Risk Control E-Mail for " & Me.EmailCreationDate.Text & " finished")
            Else
                'EItem.Display()
                OutlookMessage.Display()
                Me.BgwDailyRiskEmail.ReportProgress(90, "E-Mail not sended yet")
                Directory.Delete(ReportExpFile, True)
                Me.BgwDailyRiskEmail.ReportProgress(95, "Temporary Report directory deleted")
                Me.BgwDailyRiskEmail.ReportProgress(100, "Daily Risk Control E-Mail for " & Me.EmailCreationDate.Text & " finished")
            End If

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try

    End Sub

    Private Sub BgwDailyRiskEmail_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwDailyRiskEmail.ProgressChanged

        Me.EMAILProgressBar.Value = e.ProgressPercentage

        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','','DAILY RISK EMAIL')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','','DAILY RISK EMAIL')"
            cmdEVENT.ExecuteNonQuery()
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByDAILYRISKEMAILDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwDailyRiskEmail_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwDailyRiskEmail.RunWorkerCompleted
        Me.To_MemoEdit.Properties.ReadOnly = False
        Me.CC_MemoEdit.Properties.ReadOnly = False
        Me.BCC_MemoEdit.Properties.ReadOnly = False
        Me.Subject_TextEdit.Text = ""
        Me.EMAILProgressBar.Visible = False

    End Sub

End Class