Imports System
Imports System.Configuration
Imports System.IO
Imports System.Xml
Imports System.Xml.XmlReader
Imports System.Xml.XmlTextWriter
Imports System.Xml.XmlTextReader
Imports System.Xml.XmlText
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Threading
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraGrid.Views.Layout.Drawing
Imports DevExpress.XtraLayout.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo
Imports System.Text
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraBars.Alerter
Imports DevExpress.Spreadsheet
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Configuration.ConfigurationManager
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports System.Drawing
Imports System.Security
Imports System.Security.Cryptography
Imports System.Reflection


'*****************************************
'Class Name: PSTOOL_MAIN_Form
'Version: V1.0.0.0
'Version Explanation:
'Author: CCBFF
'Email: info@ccbff.de
'Creation Time:
'Content:
'Function:
'Description:
'Modify log:  
'    1. Add by WYQ       ; Time:10.02.2022; Content: update for BAIS version 1.33
'    2. Add by WYQ       ; Time:03.03.2022; Content: update for Wertpapierstatistik
'    3. Add by WYQ       ; Time:10.06.2022; Content: update for BAIS version 1.34
'    4. Add by Siyao Chen; Time:12.12.2022; Content: update for BAIS version 1.35

'******************************************
Public Class PSTOOL_MAIN_Form

  

    Dim Cryptokey As String = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Public CRForm As CrystalReportsForm


    Dim n As Double = 0



    'Risk Controlling
    Dim DF_IRR_daily As New DatesForm 'Interest Rate risk
    Dim DF_IRR_dailyChart As New DatesForm 'Interest Rate risk Chart
    Dim DF_IRR_RB_daily As New DatesForm 'Interest Rate risk Amount Risk bearing capacity
    Dim DF_IRR_HUMP_daily As New DatesForm 'Interest Rate risk HUMP
    Dim DF_IRR_ZinsbindungChart As New DatesForm 'Interest Rate risk Zinsbindungschart
    Dim DF_IRR_NetPos_Reconcile As New DatesForm 'Interest Rate risk Net positions reconcile
    Dim DF_RiskTables_Daily As New DatesForm 'Daily Risk Tables
    Dim DF_LoansStructure_daily As New DatesForm 'Loans Structure Table
    Dim DF_RiskLimitDailyControl As New DatesForm 'Risk Limit Daily Control
    Dim DF_ObligoLiabilitySurplus As New DatesForm 'Obligo Liability Surplus
    Dim DF_RiskChart_daily As New DatesForm 'Daily Risk Chart
    Dim DF_CarChart_daily As New DatesForm 'Daily Car Chart
    Dim DF_LiquidityChart_Daily As New DatesForm 'Daily Liquidity Chart
    Dim DF_IndustrialDistributionRecon As New DatesForm 'Industrial Distribution reconciliation
    Dim DF_MaturityStructureRecon As New DatesForm 'Maturity Structure reconciliation
    Dim DF_BusinessTypesCreditPortfolioRecon As New DatesForm 'Business Types reconciliation
    Dim DF_CountriesLargeCreditExposureRecon As New DatesForm 'Countries Large Credit Exposure reconciliation
    Dim DF_RatingClasificationRecon As New DatesForm 'Countries Large Credit Exposure reconciliation
    Dim DF_RiskBearingCapacity_daily As New DatesForm 'Risk bearing capacity daily
    Dim DF_RiskBearingCapacity_Chartdaily As New DatesForm 'Risk bearing capacity Chart daily
    Dim DF_StressTestsBusinessTypes_daily As New DatesForm 'Stress Test Business Types daily
    Dim DF_StressTestsHOliquidity_daily As New DatesForm 'Stress Test Head Office liquidity daily
    Dim DF_CashFlowAnalysis_daily As New DatesForm 'Cash flow analysis daily
    Dim dxOK_CashFlowAnalysisDailyPrintDetailsCombo As New DevExpress.XtraEditors.ComboBoxEdit
    Dim DF_BusinessTypesCreditPortfolio As New DatesForm 'Business Types Credit Portfolio
    Dim PrintDetailsCashflowAnalysis As String = Nothing
    Dim DF_NewCreditBusiness As New DatesForm
    Dim DF_RefinancingMaturityList As New DatesForm
    Dim DF_Kwg13_ChineseBanks As New DatesForm
    Dim DF_Kwg13_NoneChineseBanks As New DatesForm
    Dim DF_LargeLoanExposureCorporates As New DatesForm
    Dim DF_TrafficLightsSystemRBC As New DatesForm
    Dim DF_LCR_Overview As New DatesForm

    'Accounting
    Dim DF_TimeDepositOutstandingClientDeals As New DatesForm
    Dim DF_FxCreditEquivalent As New DatesForm
    Dim DF_IrsCreditEquivalent As New DatesForm
    Dim DF_KapiSteuerMMKundenMonat As New AccDatesForm
    Dim DF_KapiSteuerKundeAlle As New AccDatesForm
    Dim DF_KapiSteuerKundeEinzeln As New AccDatesForm
    Dim DF_BalanceSheetReconciliation As New DatesForm
    Dim DF_ProfitLossReconcile As New DatesForm
    'Foreign
    Dim DF_ExportLCMonthlyStatistic As New DatesForm
    'Meldewesen
    Dim DF_AWVz4 As New DatesForm
    Dim DF_AWVz10 As New DatesForm
    Dim DF_AWVz11 As New DatesForm
    Dim DF_AWVz14z15 As New DatesForm
    Dim DF_KapiSoliMonatDetails As New AccDatesForm
    Dim DF_KapiSoliMonatMeldung As New AccDatesForm
    Dim DF_Wertpapierstatistik As New AccDatesForm
    Dim DF_Einlagensicherung As New AccDatesForm
    Dim DF_EinlagensicherungGesetzlich As New AccDatesForm
    Dim DATESFORM_EMPL_AVG As New AccDatesForm
    Dim DF_DevisenhandelumsatzStatistik As New DatesForm

    Dim objMutex As Mutex

    'For Allerts
    Dim UnratedCustomersTextEdit As New DevExpress.XtraEditors.TextEdit
    Dim OnlineAccountsDeletedTextEdit As New DevExpress.XtraEditors.TextEdit
    Dim ImportErrorsTextEdit As New DevExpress.XtraEditors.TextEdit
    Dim ImportErrorsOdasTextEdit As New DevExpress.XtraEditors.TextEdit
    Dim ImportErrorsOcbsTextEdit As New DevExpress.XtraEditors.TextEdit
    Dim EAEG_Kunden_AddresseNameValid_TextEdit As New DevExpress.XtraEditors.TextEdit
    Dim EAEG_Kunden_Geburtsdatum_TextEdit As New DevExpress.XtraEditors.TextEdit
    Dim DeactivatedUserStatus_TextEdit As New DevExpress.XtraEditors.TextEdit
    Dim NewUser_ActiveDirectory_TextEdit As New DevExpress.XtraEditors.TextEdit
    Dim GeneralInfo_TextEdit As New DevExpress.XtraEditors.TextEdit
    'Nostro Accounts Alerts
    Friend WithEvents Alert_NostroAccount As New AlertControl
    Friend WithEvents Timer_NostroAccount As New System.Windows.Forms.Timer
    Dim NostroAccount_TextEdit As New DevExpress.XtraEditors.TextEdit
    'Mindestreserve Alerts
    Friend WithEvents Alert_MindestReserveBUBA As New AlertControl
    Friend WithEvents Timer_MindestReserveBUBA As New System.Windows.Forms.Timer
    Dim MindestReserveBUBA_TextEdit As New DevExpress.XtraEditors.TextEdit
    'Target Holidays
    Friend WithEvents Alert_TargetHolidays As New AlertControl
    Friend WithEvents Timer_TargetHolidays As New System.Windows.Forms.Timer
    Dim TargetHolidays_TextEdit As New DevExpress.XtraEditors.TextEdit
    'All FX Deals Update
    Friend WithEvents Alert_UPDATE_FX_Deals_ALL As New AlertControl
    Dim FX_ALL_LAST_UPDATE_Date As Date
    Dim FX_ALL_AFTER_UPDATE_Date As Date
    Dim UPDATE_FX_Deals_ALL_TextEdit As New DevExpress.XtraEditors.TextEdit
    'New Customer
    Friend WithEvents Alert_NEW_CUSTOMER As New AlertControl
    Dim NewCustomer_TextEdit As New DevExpress.XtraEditors.TextEdit
    'New Currency
    Friend WithEvents Alert_NEW_CURRENCY As New AlertControl
    Dim NewCurrency_TextEdit As New DevExpress.XtraEditors.TextEdit
    'Balance Sheet Difference
    Friend WithEvents Alert_BS_DIFFERENCE As New AlertControl
    Dim BS_Difference_TextEdit As New DevExpress.XtraEditors.TextEdit
    'Client Groups Countries Nummeric
    Friend WithEvents Alert_GROUP_COUNTRIES_NUMMERIC As New AlertControl
    Dim GroupCountriesNummeric_TextEdit As New DevExpress.XtraEditors.TextEdit


    'Current Date
    Dim CurrentDate As Date = Today
    Dim CurrentDateSql As String = CurrentDate.ToString("yyyyMMdd")
    Dim LastOdasFileNumber As Double = 0
    Dim LastOcbsFileNumber As Double = 0
    Dim LastBaisInterfaceFileNumber As Double = 0
    Dim LastBaisFileNumber As Double = 0

    'EXCEL
    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet
    Dim ExcelFileName As String

    'SimpleButton at runtime
    Dim dxOK_IRRD As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IRRDC As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IRRD_RB As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IRRD_HUMP As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IRR_ZinsbindungChart As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IRR_NetRecon As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_DailyRiskTable As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_LoansStructure As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_RiskLimitDailyControl As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_ObligoLiabilitySurplus As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_DailyRiskChart As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_DailyCarChart As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_DailyLiquidityChart As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IndustrialDistributionRecon As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_MaturityStrutureRecon As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_BusinessTypesCreditPortfolioRecon As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_CountriesLargeCreditExposureRecon As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_RatingClasificationRecon As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_RiskBearingCapacityDaily As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_RiskBearingCapacityChartDaily As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_StressTestsLiquidityHODaily As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_BusinessTypesCreditPortfolio As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_CashFlowAnalysisDaily As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_NewCreditBusiness As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_RefinancingMaturityList As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_Kwg13_ChineseBanks As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_Kwg13_NoneChineseBanks As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_Kwg13_CentralGoverment As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_LargeLoanExposureCorporates As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_TrafficLightsSystemRBC As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_LCR_Overview As New DevExpress.XtraEditors.SimpleButton
    Dim dxOK_FxCreditEquivalent As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_IrsCreditEquivalent As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_TimeDepositOutDeals As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_KapiStMMkundenMonat As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_KapiStKundenAlleJahr As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_KapiStKundenEinzelnJahr As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_BalanceSheetReconciliation As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_ProfitLossReconciliation As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_ProfitLossExcelIDW As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_ExportLCmonthlyStatistic As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_AWVz4 As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_AWVz10 As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_AWVz11 As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_AWVz14z15 As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_KAPIMLD_REP As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_KAPIMLD As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_EMPL_AVG As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_VostroAccountsTransactionFees As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_ZVDL_Report As DevExpress.XtraEditors.SimpleButton
    Dim dxOK_CCB_Vostro_Buba_Balances As DevExpress.XtraEditors.SimpleButton



    Sub New()
        InitSkins()
        InitializeComponent()
        Me.InitSkinGallery()
        'SearchHelper.CreateSearchPanel(NavBarControl1, SearchCriteria.StartsWith)
       

    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("Sharp Plus")

    End Sub
    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)
    End Sub


#Region "FILTER NAVBAR"
    Private Sub FilterItems(ByVal searchString As String)
        'For Each group As NavBarGroup In NavBarControl1.Groups
        'If Group.GroupStyle <> NavBarGroupStyle.ControlContainer Then
        'Group.Visible = IsMatchFilter(Group, searchString)
        'End If

        'Next group

    End Sub


    Private Function IsMatchFilter(ByVal group As NavBarGroup, ByVal searchString As String) As Boolean
        'For Each link As NavBarItemLink In group.ItemLinks
        'If Link.Caption.ToLower().Contains(searchString.ToLower) Then
        'Return True
        'End If
        'Next link
        'Return False
    End Function

    Private Sub FindNavBar_txtEdit_EditValueChanged(sender As Object, e As EventArgs)
        '++++++FilterItems(Me.FindNavBar_txtEdit.Text.ToLower())
    End Sub

#End Region

    Private Sub PSTOOL_MAIN_Form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.SystemFilesTimer.Enabled = True
        Me.SystemFilesTimer.Start()
    End Sub


    Private Sub PSTOOL_MAIN_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim ep As New PAB.Util.EvalProvider
        'Dim objResult As Object = ep.Eval("MsgBox(" & "Stop" & ")")
        'Dim t As Type = objResult.GetType()
        'Dim Test As String = Convert.ToString(objResult)
        'MsgBox("Test")
        'TEST
        'If SystemInformation.UserName.ToString = "Papas" Then
        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'SplashScreenManager.Default.SetWaitFormCaption("Test")
        'System.Threading.Thread.Sleep(10000)
        'SplashScreenManager.CloseForm(False)
        'Application.Exit()
        'End If

        'Try

        Me.TreeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Advanced
        'Me.AccordionControl1.Visible = False

        AddHandler UnratedCustomersTextEdit.TextChanged, AddressOf HandleTextChanged_UnratedCustomersTextEdit
        AddHandler ImportErrorsTextEdit.TextChanged, AddressOf HandleTextChanged_ImportErrorsTextEdit
        AddHandler EAEG_Kunden_AddresseNameValid_TextEdit.TextChanged, AddressOf HandleTextChanged_EAEG_Kunden_AddresseNameValid_TextEdit
        AddHandler OnlineAccountsDeletedTextEdit.TextChanged, AddressOf HandleTextChanged_OnlineAccountsDeletedTextEdit
        AddHandler EAEG_Kunden_Geburtsdatum_TextEdit.TextChanged, AddressOf HandleTextChanged_EAEG_Kunden_Geburtsdatum_TextEdit
        AddHandler DeactivatedUserStatus_TextEdit.TextChanged, AddressOf HandleTextChanged_DeactivatedUserStatus_TextEdit
        AddHandler NewUser_ActiveDirectory_TextEdit.TextChanged, AddressOf HandleTextChanged_NewUser_ActiveDirectory_TextEdit
        AddHandler NostroAccount_TextEdit.TextChanged, AddressOf HandleTextChanged_NostroAccount_TextEdit
        AddHandler MindestReserveBUBA_TextEdit.TextChanged, AddressOf HandleTextChanged_MindestReserveBUBA_TextEdit
        AddHandler TargetHolidays_TextEdit.TextChanged, AddressOf HandleTextChanged_TargetHolidays_TextEdit
        AddHandler UPDATE_FX_Deals_ALL_TextEdit.TextChanged, AddressOf HandleTextChanged_UPDATE_FX_Deals_ALL_TextEdit
        AddHandler NewCustomer_TextEdit.TextChanged, AddressOf HandleTextChanged_NewCustomer_TextEdit
        AddHandler NewCurrency_TextEdit.TextChanged, AddressOf HandleTextChanged_NewCurrency_TextEdit
        AddHandler BS_Difference_TextEdit.TextChanged, AddressOf HandleTextChanged_BS_Difference_TextEdit
        AddHandler GroupCountriesNummeric_TextEdit.TextChanged, AddressOf HandleTextChanged_GroupCountriesNummeric_TextEdit
        'AddHandler GeneralInfo_TextEdit.TextChanged, AddressOf HandleTextChanged_GeneralInfo_TextEdit


        'Get Server Name and showing in Window Text
        CurrentUserWindowsID = SystemInformation.UserName
        Me.Text = My.Application.Info.Title & " - Server Instance: " & TOOL_SQL_SERVER & " - Database: " & TOOL_SQL_DATABASE


        '*********GET VERSION INFO*********
        '**********************************
        siInfo.Caption = String.Format(" Version {0}.{1:00} (c) CCBFF 2023 build {2} rev {3} Current User: {4}  - Session ID: {5}",
                                    My.Application.Info.Version.Major,
                                    My.Application.Info.Version.Minor,
                                    My.Application.Info.Version.Build,
                                    My.Application.Info.Version.Revision,
                                    SystemInformation.UserName,
                                    PSTOOL_SessionID)
        '******************************************************************************************


        Me.TreeList1.ExpandAll()

        Me.SystemFilesTimer.Enabled = True
        Me.SystemFilesTimer.Start()

        '**************************************************************************
        'Only for 1 Instance of the Application
        'objMutex = New Mutex(False, "PS TOOL DX")
        'If objMutex.WaitOne(0, False) = False Then
        '    objMutex.Close()
        '    objMutex = Nothing
        '    XtraMessageBox.Show("PS TOOL Application already running", "New instance of PS TOOL is not allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        '    End
        'ElseIf objMutex.WaitOne(0, False) = True Then
        OpenSqlConnections()
        'cmd.CommandText = "DELETE FROM [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "' and [SessionID]='" & PSTOOL_SessionID & "'"
        'cmd.ExecuteNonQuery()
        'cmd.CommandText = "INSERT INTO [CURRENT USERS] ([UserName],[Logged on]) Values ('" & SystemInformation.UserName & "', Getdate()) "
        'cmd.CommandText = "Select Count(ID) from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "' "
        'PSTOOL_SessionID = cmd.ExecuteScalar+1
        cmd.CommandText = "Select 'UserID'=Case when (Select Count(ID) from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "')=0 then 1 when (Select Count(ID) from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "')>0 then (Select Max(SessionID)+1 from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "') end"
        PSTOOL_SessionID = cmd.ExecuteScalar

        cmd.CommandText = "INSERT INTO [CURRENT USERS] ([UserName],[Logged on],[HostName],[IP_Address],[SessionID]) Values ('" & SystemInformation.UserName & "', Getdate() , (SELECT HOST_NAME()), (SELECT client_net_address FROM sys.dm_exec_connections WHERE session_id = @@SPID), " & Str(PSTOOL_SessionID) & ") "
        cmd.ExecuteNonQuery()
        'cmd.CommandText = "INSERT INTO [CURRENT USERS] ([UserName],[Logged on],[SessionID]) Select '" & SystemInformation.UserName & "', Getdate() , (Select 'SessionID'=Case when (Select Count([SessionID]) from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "')>0 then Count([SessionID])+1 else 1 end from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "')"
        'cmd.ExecuteNonQuery()
        'Get Last Date of FX ALL DEALS Update
        cmd.CommandText = "Select [LastImportDate] from [MANUAL IMPORTS] where [ProcName]='ODAS FX DEALS'"
        FX_ALL_LAST_UPDATE_Date = cmd.ExecuteScalar

        CloseSqlConnections()

        'End If
        '****************************************************************************



        If Me.Text.EndsWith("TEST") = True Then
            UserLookAndFeel.Default.SetSkinStyle("Blueprint")
            CurrentSkinName = "Blueprint"
            Me.iNewPSTOOL_Test_Session.Visibility = BarItemVisibility.Never
            'Me.BackgroundImage = LogoImageCollection.Images(4)
            'Me.BackgroundImageLayout = ImageLayout.Center

            '*********GET VERSION INFO with User Session ID*********
            '**********************************
            siInfo.Caption = String.Format(" Version {0}.{1:00} (c) CCBFF 2023 build {2} rev {3} Current User: {4} - Session ID: {5} - Environment: {6}",
                                       My.Application.Info.Version.Major,
                                       My.Application.Info.Version.Minor,
                                       My.Application.Info.Version.Build,
                                       My.Application.Info.Version.Revision,
                                       SystemInformation.UserName,
                                       PSTOOL_SessionID,
                                       "+++++++TEST+++++++")

            '**********************************
        Else
            UserLookAndFeel.Default.SetSkinStyle("Sharp Plus")
            CurrentSkinName = "Sharp Plus"
            'Me.BackgroundImage = LogoImageCollection.Images(6)
            'Me.BackgroundImageLayout = ImageLayout.Center

            '*********GET VERSION INFO with User Session ID*********
            '**********************************
            siInfo.Caption = String.Format(" Version {0}.{1:00} (c) CCBFF 2022 build {2} rev {3} Current User: {4} - Session ID: {5} - Environment: {6}",
                                       My.Application.Info.Version.Major,
                                       My.Application.Info.Version.Minor,
                                       My.Application.Info.Version.Build,
                                       My.Application.Info.Version.Revision,
                                       SystemInformation.UserName,
                                       PSTOOL_SessionID,
                                       "PRODUCTION")
            '**********************************
        End If


        Me.DocumentManager1.View = Me.NativeMdiView1

        'Catch ex As Exception
        'Application.Exit()
        'End Try





    End Sub

    Private Sub PSTOOL_MAIN_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If My.Computer.Network.IsAvailable = True AndAlso cmd.Connection.State <> ConnectionState.Broken Then
            e.Cancel = True
            For Each kf As Form In Me.MdiChildren
                If kf.Visible = True Then
                    XtraMessageBox.Show("Please close all opened windows before exit the PS TOOL Application", "UNABLE TO EXIT PS TOOL", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next
            e.Cancel = False
            Application.Exit()
        End If
        If My.Computer.Network.IsAvailable = False Or cmd.Connection.State <> ConnectionState.Broken Then

            e.Cancel = False
            Application.Exit()
        End If


        'Test Code
        'For i = Me.MdiChildren.Length - 1 To 0 Step -1
        'Me.MdiChildren(i).Close()
        'Next
        'Application.Exit()

    End Sub

    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer
    Private makel As String

    Private Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function

  

    Private Sub PSTOOL_MAIN_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Delete the content in Find Navigation Items and displays them all
        If e.KeyCode = Keys.Escape Then
            'Me.FindNavBar_txtEdit.Text = ""
        End If
        If e.KeyCode = Keys.F1 Then
           
            If ActiveMdiChild IsNot Nothing Then
                ActiveMdiChild.Close()
            Else
                Return
            End If

        End If
        If e.KeyCode = Keys.F4 Then
            For Each Element In Me.AccordionControl1.Elements
                Element.Expanded = False
            Next
        End If
    End Sub
    Private Sub SystemFilesTimer_Tick(sender As Object, e As EventArgs) Handles SystemFilesTimer.Tick
        If My.Computer.Network.IsAvailable = True AndAlso cmdSYSTEM.Connection.State <> ConnectionState.Broken Then
            Try
                OpenSYSTEM_SqlConnection()
                cmdSYSTEM.CommandText = "SELECT [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('ODAS')"

                LastOdasFileNumber = cmdSYSTEM.ExecuteScalar
                iLastOdasFile.Caption = "Last ODAS File: " & LastOdasFileNumber

                cmdSYSTEM.CommandText = "SELECT [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('OCBS','NGS')"
                LastOcbsFileNumber = cmdSYSTEM.ExecuteScalar
                iLastOcbsFile.Caption = "Last NGS  File: " & LastOcbsFileNumber

                cmdSYSTEM.CommandText = "SELECT [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('BAIS')"
                LastBaisInterfaceFileNumber = cmdSYSTEM.ExecuteScalar
                iLastBaisInterfaceFile.Caption = "Last BAIS Interface File: " & LastBaisInterfaceFileNumber

                cmdSYSTEM.CommandText = "SELECT [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('BAIS_Forms')"
                LastBaisFileNumber = cmdSYSTEM.ExecuteScalar
                iLastBaisFile.Caption = "Last BAISforms File:        " & LastBaisFileNumber


                '*******************************************************************
                '**********USER PERMISSIONS/DIRECTORIES*****************************
                '*******************************************************************
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='SUPERUSER' and [PARAMETER STATUS]='Y' "
                Dim SUPERUSER_Result As String = cmdSYSTEM.ExecuteScalar
                If SUPERUSER_Result <> "" Then
                    SUPER_USER = "Y"
                Else
                    SUPER_USER = "N"
                End If
                '******************************************************************
                '***********EDP USERS++++++++++++++++++++++++++++++++++++++++++++++
                '******************************************************************
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='EDP_USERS' and [PARAMETER STATUS]='Y' "
                Dim EDPResult As String = cmdSYSTEM.ExecuteScalar
                If EDPResult <> "" Then
                    EDP_USER = "Y"
                Else
                    EDP_USER = "N"
                End If
                '***********************************************************************
                '*******AML USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='AML_USER' and [PARAMETER STATUS]='Y' "
                Dim AMLResult As String = cmdSYSTEM.ExecuteScalar
                If AMLResult <> "" Then
                    AML_USER = "Y"
                Else
                    AML_USER = "N"
                End If
                '***********************************************************************
                '*******FOREIGN USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                         and [IdABTEILUNGSPARAMETER]='FOREIGN_USER' and [PARAMETER STATUS]='Y' "
                Dim FOREIGNResult As String = cmdSYSTEM.ExecuteScalar
                If FOREIGNResult <> "" Then
                    FOREIGN_USER = "Y"
                Else
                    FOREIGN_USER = "N"
                End If
                '***********************************************************************
                '*******ACCOUNTING USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='ACCOUNTING_USER' and [PARAMETER STATUS]='Y' "
                Dim ACCOUNTINGResult As String = cmdSYSTEM.ExecuteScalar
                If ACCOUNTINGResult <> "" Then
                    ACCOUNTING_USER = "Y"
                Else
                    ACCOUNTING_USER = "N"
                End If
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='NostroReconciliationTaskStatus' 
                                        and [IdABTEILUNGSPARAMETER]='NOSTRO_RECONCILIATION' and [PARAMETER STATUS]='Y' "
                ACCOUNTING_NOSTRO_RECONCILIATION_STATUS = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='SuspenceReconciliationTaskStatus' 
                                        and [IdABTEILUNGSPARAMETER]='SUSPENCE_RECONCILIATION' and [PARAMETER STATUS]='Y' "
                ACCOUNTING_SUSPENCE_RECONCILIATION_STATUS = cmdSYSTEM.ExecuteScalar
                '***********************************************************************
                '*******SECURITIES USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='SECURITIES_USER' and [PARAMETER STATUS]='Y' "
                Dim SECURITIESResult As String = cmdSYSTEM.ExecuteScalar
                If SECURITIESResult <> "" Then
                    SECURITIES_USER = "Y"
                Else
                    SECURITIES_USER = "N"
                End If
                '***********************************************************************
                '*******RISK CONTROLLING USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='RISKCONTROLLING_USER' and [PARAMETER STATUS]='Y' "
                Dim RISKCONTROLLINGResult As String = cmdSYSTEM.ExecuteScalar
                If RISKCONTROLLINGResult <> "" Then
                    RISKCONTROLLING_USER = "Y"
                Else
                    RISKCONTROLLING_USER = "N"
                End If
                '***********************************************************************
                '*******MELDEWESEN USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='MELDEWESEN_USER' and [PARAMETER STATUS]='Y' "
                Dim MELDEWESENResult As String = cmdSYSTEM.ExecuteScalar
                If MELDEWESENResult <> "" Then
                    MELDEWESEN_USER = "Y"
                Else
                    MELDEWESEN_USER = "N"
                End If
                '***********************************************************************
                '*******MANAGEMENT USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='MANAGEMENTUSERS' and [PARAMETER STATUS]='Y' "
                Dim MANAGEMENTResult As String = cmdSYSTEM.ExecuteScalar
                If MANAGEMENTResult <> "" Then
                    MANAGEMENT_USER = "Y"
                Else
                    MANAGEMENT_USER = "N"
                End If
                '***********************************************************************
                '*******EAEG USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                         and [IdABTEILUNGSPARAMETER]='EAEG_USERS' and [PARAMETER STATUS]='Y' "
                Dim EAEGResult As String = cmdSYSTEM.ExecuteScalar
                If EAEGResult <> "" Then
                    EAEG_USER = "Y"
                Else
                    EAEG_USER = "N"
                End If
                '***********************************************************************
                '*******TREASURY USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='TREASURY_USERS' and [PARAMETER STATUS]='Y' "
                Dim TREASURYResult As String = cmdSYSTEM.ExecuteScalar
                If TREASURYResult <> "" Then
                    TREASURY_USER = "Y"
                Else
                    TREASURY_USER = "N"
                End If
                '***********************************************************************
                '*******CREDIT USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                         and [IdABTEILUNGSPARAMETER]='CREDIT_USERS' and [PARAMETER STATUS]='Y' "
                Dim CREDITResult As String = cmdSYSTEM.ExecuteScalar
                If CREDITResult <> "" Then
                    CREDIT_USER = "Y"
                Else
                    CREDIT_USER = "N"
                End If
                '***********************************************************************
                '*******CLEARING USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='CLEARING_USER' and [PARAMETER STATUS]='Y' "
                Dim CLEARINGResult As String = cmdSYSTEM.ExecuteScalar
                If CLEARINGResult <> "" Then
                    CLEARING_USER = "Y"
                Else
                    CLEARING_USER = "N"
                End If
                '***********************************************************************
                '*******COMPLIANCE USER PERMISSION************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER2]='" & SystemInformation.UserName & "' 
                                        and [IdABTEILUNGSPARAMETER]='COMPLIANCE_USERS' and [PARAMETER STATUS]='Y' "
                Dim COMPLIANCEResult As String = cmdSYSTEM.ExecuteScalar
                If COMPLIANCEResult <> "" Then
                    COMPLIANCE_USER = "Y"
                Else
                    COMPLIANCE_USER = "N"
                End If
                '***********************************************************************
                '*******CRYSTAL REPORTS DIRECTORY************
                '+++++++++++++++++++++++++++++++++++++++++++++++++++
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
                CrystalRepDir = cmdSYSTEM.ExecuteScalar
                '***********************************************************************
                '*******IMPORT EVENTS DIRECTORY*************
                '*******************************************
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='PS_TOOL_Import_Events_Current_File' 
                                        and [IdABTEILUNGSPARAMETER]='IMPORT EVENTS DIRECTORY' and [PARAMETER STATUS]='Y' "
                ImportEventsDirectory = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='PSTOOL_ImportEventsDirectoryFolder' 
                                        and [IdABTEILUNGSPARAMETER]='IMPORT EVENTS DIRECTORY' and [PARAMETER STATUS]='Y' "
                ImportEventsDirectoryFolder = cmdSYSTEM.ExecuteScalar
                '***********************************************************************
                '*******EXCEL PARAMETER FILE******************************
                '*********************************************************
                cmdSYSTEM.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='PSTOOL_PARAMETERS_EXPORT' and [PARAMETER STATUS]='Y' "
                ExcelParameterFile = cmdSYSTEM.ExecuteScalar
                '************************************************************************
                '************************************************************************
                '************************************************************************
                '***********************************************************************
                '*******ALERTS STATUS******************************
                '*********************************************************
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='ACTIVE_DIRECTORY_NEW_USER_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                ACTIVE_DIRECTORY_NEW_USER_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='BUNDESBANK_RESERVE_END_DATE_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                BUNDESBANK_RESERVE_END_DATE_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='EAEG_KUNDEN_AENDERUNG_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                EAEG_KUNDEN_AENDERUNG_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='EAEG_KUNDEN_NEU_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                EAEG_KUNDEN_NEU_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='IMPORT_ERRORS_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                IMPORT_ERRORS_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='NOSTRO_ACC_WITHOUT_STATEMENT_INDICATION_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                NOSTRO_ACC_WITHOUT_STATEMENT_INDICATION_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='ONLINE_BANKING_ACCOUNTS_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                ONLINE_BANKING_ACCOUNTS_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='TARGET_HOLIDAY_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                TARGET_HOLIDAY_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='UNRATED_CUSTOMERS_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                UNRATED_CUSTOMERS_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='UPDATE_ODAS_FX_DEALS' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                UPDATE_ODAS_FX_DEALS = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='NEW_CUSTOMER_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                NEW_CUSTOMER_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='NEW_CURRENCY_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                NEW_CURRENCY_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='BALANCE_SHEET_DIFFERENCE_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                BS_DIFFERENCE_ALERT = cmdSYSTEM.ExecuteScalar
                cmdSYSTEM.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] where [PARAMETER1]='GROUP_COUNTRIES_NUMMERIC_ALERT' and  [IdABTEILUNGSPARAMETER]='ALERTS_STATUS'"
                GROUP_COUNTRIES_NUMMERIC_ALERT = cmdSYSTEM.ExecuteScalar

                'Unrated Customers
                cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [CUSTOMER_RATING] where [Rating]='U'"
                'iUnratedCustomers.Caption = "Unrated Customers: " & cmdSYSTEM.ExecuteScalar
                UnratedCustomersTextEdit.Text = cmdSYSTEM.ExecuteScalar
                OutstandingRatingAlert = cmdSYSTEM.ExecuteScalar


                'Active Online Accounts Deleted
                'cmdSYSTEM.CommandText = "EXEC [ACTIVE_ONLINE_DELETED_ACCOUNTS]"
                cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [CUSTOMER_ACCOUNTS] where [Account Status]='C - CLOSE' and [Online] in ('Y')"
                OnlineAccountsDeletedTextEdit.Text = cmdSYSTEM.ExecuteScalar

                'Keine PLZ oder BUNDESLAND in KUNDEN ZINSERTRÄGE
                'cmdSYSTEM.CommandText = "EXEC [KUNDEN_PLZ_BUNDESLAND]"
                cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [ZINSERTRAG KDBASIC] where [KDPLZ] is NULL or [BUNDESLAND] is NULL"
                KundenZinsenOhnePlzBundesland = cmdSYSTEM.ExecuteScalar

                'Deactivated User
                'cmdSYSTEM.CommandText = "EXEC [USER_STATUS_DEACTIVATED] @USERNAME='" & SystemInformation.UserName & "'"
                cmdSYSTEM.CommandText = "Select Count([ID]) from [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "' and [SessionStatus]='N' and [SessionID]='" & PSTOOL_SessionID & "'"
                DeactivatedUserStatus_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'Delete User Session Datarow in Database-CURRENT USERS
                cmdSYSTEM.CommandText = "DELETE from [CURRENT USERS] where  [SessionStatus] in ('L')"
                cmdSYSTEM.ExecuteNonQuery()


                'New User Active Directory
                cmdSYSTEM.CommandText = "Select Count(ID) from [ActiveDirectoryUsers] where [AccountStatus] in ('*ENABLED') and [NonPersonalUser]=0 and ([Surname] is NULL or [Name] is NULL or [Surname]='' or [Name]='' or Title is NULL)"
                NewUser_ActiveDirectory_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'NostroAccounts with no AccountStatementsIdentifier
                cmdSYSTEM.CommandText = "Select Count(*) from [SSIS] where ([AccountIdentifierStatement] is  NULL or AccountIdentifierStatement='') and [VALID]='Y'"
                NostroAccount_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'BUBA Mindestreserve Dates not defined
                cmdSYSTEM.CommandText = "With CTE as (Select Max([CalendarDate]) as 'MaxDate' from [Calendar] where MinReserveBUBA in ('Y')) Select Count(*) from CTE where GETDATE()>CTE.MaxDate"
                MindestReserveBUBA_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'Target Holidays
                cmdSYSTEM.CommandText = "With CTE as (Select Max([CalendarDate]) as 'MaxDate' from [Calendar] where [TargetHoliday] in ('H')) Select Count(*) from CTE where GETDATE()>CTE.MaxDate"
                TargetHolidays_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'ODAS FX Deals Update
                cmdSYSTEM.CommandText = "Select [LastImportDate] from [MANUAL IMPORTS] where [ProcName]='ODAS FX DEALS'"
                UPDATE_FX_Deals_ALL_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'New Currency
                cmdSYSTEM.CommandText = "SELECT COUNT([CURRENCY CODE]) FROM [SSIS] where [CURRENCY CODE] not in (Select [CURRENCY CODE] from OWN_CURRENCIES)"
                NewCurrency_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'Client Groups- Country of Residence is nummeric
                cmdSYSTEM.CommandText = "Select COUNT(B.S) from  (Select Count(ID) as S from GROUP_MASTER where ISNUMERIC(ClientCountryResidence)=1 UNION ALL Select Count(ID) as S from [GROUP_INTER] where ISNUMERIC(ClientCountryResidence)=1)B where B.S>0"
                GroupCountriesNummeric_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                'BAIS Version Nr.
                cmdSYSTEM.CommandText = "SELECT [NPARAMETER1] FROM [PARAMETER] where IdABTEILUNGSPARAMETER='BANK_SYSTEMS' and [PARAMETER2]='BAIS'"
                BAIS_VERSION_NR = cmdSYSTEM.ExecuteScalar


                If LastOdasFileNumber = LastOcbsFileNumber Then
                    'Dim rd As Date = DateSerial(Microsoft.VisualBasic.Left(LastOdasFileNumber, 4), Mid(LastOdasFileNumber, 5, 2), Microsoft.VisualBasic.Right(LastOdasFileNumber, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")

                    'Get ImportErrors ODAS
                    'cmdSYSTEM.CommandText = "EXEC [IMPORT_EVENTS_ALL_ERROR_COUNT]"
                    cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [IMPORT EVENTS] where [Event] like 'ERROR%' and [SystemName] in ('ODAS','OCBS','NGS')"
                    ImportErrorsTextEdit.Text = cmdSYSTEM.ExecuteScalar

                    'Addressenänderung oder Namensänderung in EAEG KUNDEN STAMM DATEN
                    'cmdSYSTEM.CommandText = "EXEC [EAEG_KUNDEN_ADDRESSE_VALID]"
                    cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [EAEG_KUNDEN_STAMM] where [Adresse_Valid]='N' and EAEG_Valid='Y' and [B2_Ordnungskennzeichen] IN (SELECT  [B2_OrdnungskennzeichenId] FROM [EAEG_KUNDEN_KONTEN])"
                    EAEG_Kunden_AddresseNameValid_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                    'Differenz zwischen Kunden PLZ in Steuerbescheinigung und EAEG
                    'cmdSYSTEM.CommandText = "EXEC [PLZ_STEUER_EAEG_DIFFERENCE]"
                    cmdSYSTEM.CommandText = "Select Count(A.ID) from [ZINSERTRAG KDBASIC] A INNER JOIN  [EAEG_KUNDEN_STAMM] B ON A.KDSTAMM=B.B2_Ordnungskennzeichen where A.[KDPLZ] <> B.[B9_Postleitzahl] and A.[KDPLZ] is not NULL and B.[B9_Postleitzahl] is not NULL"
                    KundenZinsenPLZ_EAEG = cmdSYSTEM.ExecuteScalar

                    'Keine PLZ bei EAEG Kunden - neuer Kunde
                    'cmdSYSTEM.CommandText = "EXEC [EAEG_KUNDEN_GEBURTSDATUM]"
                    cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [EAEG_KUNDEN_STAMM] WHERE  (EAEG_Valid = 'Y') AND (B7_SrasseUndHausnummer is NULL or B7_SrasseUndHausnummer='' or B10_Ort is NULL or B10_Ort='') AND (B2_Ordnungskennzeichen IN (SELECT  B2_OrdnungskennzeichenId FROM EAEG_KUNDEN_KONTEN))"
                    EAEG_Kunden_Geburtsdatum_TextEdit.Text = cmdSYSTEM.ExecuteScalar

                    'Neuer Kunde
                    cmdSYSTEM.CommandText = "SELECT Count([ID]) FROM [CUSTOMER_INFO] where [CCB_Group]='U' or [CCB_Group_OwnID]='U' or [CIC_Group]='U'"
                    NewCustomer_TextEdit.Text = cmdSYSTEM.ExecuteScalar
                    OutstandingNewCustomerAlert = cmdSYSTEM.ExecuteScalar

                    'Balance Sheet Difference
                    cmdSYSTEM.CommandText = " Select Count(ID) from [GeneralDataInfo] where [Description1] in ('BS_Difference') and ABS(Amount1)>=1 and [RiskDate] in (Select Max(RiskDate) from GeneralDataInfo)"
                    BS_Difference_TextEdit.Text = cmdSYSTEM.ExecuteScalar




                    Me.GeneralInfo_TextEdit.Text = "1"

                End If

                'Execute Threads for ODAS and OCBS--ONLY IF Form:PSTOOL_IMPORTS is present
                'cmdSYSTEM.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='PSTOOL_ImportUser' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='PSTOOL_IMPORTS_PARAMETER'"
                'Dim PSTOOL_IMPORT_USER As String = cmdSYSTEM.ExecuteScalar
                'If PSTOOL_IMPORT_USER <> "" AndAlso PSTOOL_IMPORT_USER = SystemInformation.UserName Then
                'Select Threads
                'QueryText = "Select  [PARAMETER2]  from   [PARAMETER] where [PARAMETER1] like 'PSTOOL_Import_Thread%' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='PSTOOL_IMPORTS_PARAMETER' ORDER BY [ID] Asc"
                'da = New SqlDataAdapter(QueryText.Trim(), conn)
                'dt = New DataTable()
                'da.Fill(dt)
                'If dt.Rows.Count > 0 Then
                'For i = 0 To dt.Rows.Count - 1
                'Dim ImportHour As Integer = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("PARAMETER2"), 2)
                'Dim ImportMinute As Integer = Microsoft.VisualBasic.Mid(dt.Rows.Item(i).Item("PARAMETER2"), 3, 2)
                'Dim ImportSecond As Integer = Microsoft.VisualBasic.Right(dt.Rows.Item(i).Item("PARAMETER2"), 2)
                'If Now.Hour = ImportHour And Now.Minute = ImportMinute And Now.Second = ImportSecond Then
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'SplashScreenManager.Default.SetWaitFormCaption("PS TOOL IMPORTS - Automatic Startup")
                ' Place code here
                'Dim c As New PSTOOL_IMPORTS

                'For Each kf As Form In Me.MdiChildren
                'If c.GetType Is kf.GetType Then
                'kf.Activate()
                'kf.WindowState = FormWindowState.Normal
                'SplashScreenManager.CloseForm(False)
                'Return
                'End If
                'Next
                'c.MdiParent = Me

                'c.Show()
                'c.WindowState = FormWindowState.Maximized
                'SplashScreenManager.CloseForm(False)
                'End If
                'Next
                'End If
                'End If





                CloseSYSTEM_SqlConnection()

            Catch ex As Exception
                Me.SystemFilesTimer.Enabled = False
                Me.SystemFilesTimer.Stop()

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'If cmdSYSTEM.Connection.State = ConnectionState.Open Then
                'cmdSYSTEM.Connection.Close()
                'End If


                Application.Exit()


            End Try
        End If

    End Sub

    Private Sub HandleTextChanged_DeactivatedUserStatus_TextEdit(sender As Object, e As EventArgs)
        If DeactivatedUserStatus_TextEdit.Text <> "0" Then
            Close_all_Forms_BarButtonItem.PerformClick()
            iExit.PerformClick()

        End If
    End Sub



    Private Sub Cascade_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Cascade_BarButtonItem.ItemClick
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub Tile_Horizontal_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Tile_Horizontal_BarButtonItem.ItemClick
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub Tile_Vertical_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Tile_Vertical_BarButtonItem.ItemClick
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub Close_all_Forms_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Close_all_Forms_BarButtonItem.ItemClick
        For i = Me.MdiChildren.Length - 1 To 0 Step -1
            Me.MdiChildren(i).Close()
        Next

    End Sub



#Region "SECURITIES ACCORDION ELEMENTS"
    Private Sub SECUR_OurSecurities_Element_Click(sender As Object, e As EventArgs) Handles SECUR_OurSecurities_Element.Click
        'Me.Ribbon.HideApplicationButtonContentControl()

        If SECURITIES_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("OUR SECURITIES")
            ' Place code here
            Dim c As New Securities_Our

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub SECUR_DailyPrice_Element_Click(sender As Object, e As EventArgs) Handles SECUR_DailyPrice_Element.Click
        If SECURITIES_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Securities daily market prices/modified durations")
            ' Place code here
            Dim c As New Securities_Dailyprice

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub SECUR_Bestand_Element_Click(sender As Object, e As EventArgs) Handles SECUR_Bestand_Element.Click
        If SECURITIES_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SECURITIES BESTAND")
            ' Place code here
            Dim c As New Securities_Bestand

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub SECUR_Bookings_Element_Click(sender As Object, e As EventArgs) Handles SECUR_Bookings_Element.Click
        If SECURITIES_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SECURITIES BOOKINGS")
            ' Place code here
            Dim c As New Securities_Bookings

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub



    Private Sub SECUR_Deprec_Apprec_Element_Click(sender As Object, e As EventArgs) Handles SECUR_Deprec_Apprec_Element.Click
        If SECURITIES_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SECURITIES DEPRECIATIONS")
            ' Place code here
            Dim c As New Securities_Depreciations

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub SECUR_LiquidityReserve_Element_Click(sender As Object, e As EventArgs) Handles SECUR_LiquidityReserve_Element.Click
        If SECURITIES_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SECURITIES LIQUIDITY RESERVE")
            ' Place code here
            Dim c As New Securities_LiquidityReserve

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub
#End Region

#Region "ACCOUNTING ACCORDION ELEMENTS"
    Private Sub ACCOUNT_HGB_GV_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_HGB_GV_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("HGB - Gewinn und Verlustrechnung")
            ' Place code here
            Dim c As New HGB_GV

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_HGB_BS_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_HGB_BS_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("HGB - Bilanz")
            ' Place code here
            Dim c As New HGB_BS

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_ChinesseReporting_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_ChinesseReporting_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CHINESE REPORTS")
            ' Place code here
            Dim c As New ChinesseReporting

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_FormblattBILANZ_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_FormblattBILANZ_Element.Click
        'If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
        '    XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'Else
        '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        '    SplashScreenManager.Default.SetWaitFormCaption("FORMBLATT BILANZ")
        '    ' Place code here
        '    Dim c As New FormblattBalanceTotals

        '    For Each kf As Form In Me.MdiChildren
        '        If c.GetType Is kf.GetType Then
        '            kf.Activate()
        '            kf.WindowState = FormWindowState.Normal
        '            SplashScreenManager.CloseForm(False)
        '            Return
        '        End If
        '    Next
        '    c.MdiParent = Me

        '    c.Show()
        '    c.WindowState = FormWindowState.Maximized
        '    SplashScreenManager.CloseForm(False)
        'End If
    End Sub

    Private Sub ACCOUNT_Rechnungslegung_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_Rechnungslegung_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("RECHNUNGSLEGUNG")
            ' Place code here
            Dim c As New Rechnungslegung

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_VerlustfreieBewertung_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_VerlustfreieBewertung_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("VERLUSTFREIE BEWERTUNG")
            ' Place code here
            Dim c As New Pivot_VerlustfreieBewertung

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_LoanTransactions_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_LoanTransactions_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("LOAN TRANSACTIONS")
            ' Place code here
            Dim c As New LoansBookings

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_MindestreserveBUBA_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_MindestreserveBUBA_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("MINIMAL RESERVE (DEUTSCHE BUNDESBANK)")
            ' Place code here
            Dim c As New Mindestreserve

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_Nostro_Reconciliations_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_Nostro_Reconciliations_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            If ACCOUNTING_NOSTRO_RECONCILIATION_STATUS = "N" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("NOSTRO ACCOUNTS RECONCILIATIONS")
                ' Place code here
                Dim c As New NostroReconciliations

                For Each kf As Form In Me.MdiChildren
                    If c.GetType Is kf.GetType Then
                        kf.Activate()
                        kf.WindowState = FormWindowState.Normal
                        SplashScreenManager.CloseForm(False)
                        Return
                    End If
                Next
                c.MdiParent = Me

                c.Show()
                c.WindowState = FormWindowState.Maximized
                SplashScreenManager.CloseForm(False)
            ElseIf ACCOUNTING_NOSTRO_RECONCILIATION_STATUS = "Y" Then
                XtraMessageBox.Show("The automatic Nostro Accounts Reconciliation procedure is running!" & vbNewLine & "Please wait 10 Minutes and try again to open this Form!", "PERMISSION DENIED - TASK IS RUNNING", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub ACCOUNT_Suspence_Reconciliations_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_Suspence_Reconciliations_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            If ACCOUNTING_SUSPENCE_RECONCILIATION_STATUS = "N" Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("SUSPENCE ACCOUNTS RECONCILIATIONS")
                ' Place code here
                Dim c As New SuspenceAccReconciliations

                For Each kf As Form In Me.MdiChildren
                    If c.GetType Is kf.GetType Then
                        kf.Activate()
                        kf.WindowState = FormWindowState.Normal
                        SplashScreenManager.CloseForm(False)
                        Return
                    End If
                Next
                c.MdiParent = Me

                c.Show()
                c.WindowState = FormWindowState.Maximized
                SplashScreenManager.CloseForm(False)
            ElseIf ACCOUNTING_SUSPENCE_RECONCILIATION_STATUS = "Y" Then
                XtraMessageBox.Show("The automatic Suspence Accounts Reconciliation procedure is running!" & vbNewLine & "Please wait 10 Minutes and try again to open this Form!", "PERMISSION DENIED - TASK IS RUNNING", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub


    Private Sub ACCOUNT_FX_CreditEquivalentCalc_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_FX_CreditEquivalentCalc_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("FX CREDIT EQUIVALENT CALCULATIONS")
            ' Place code here
            Dim c As New FxCreditEquivalentCalculation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_FX_DailyRevaluation_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_FX_DailyRevaluation_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("FX DAILY REVALUATION")
            ' Place code here
            Dim c As New FxDailyRevaluation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_FX_DailyRevaluationNew_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_FX_DailyRevaluationNew_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("FX DAILY REVALUATION")
            ' Place code here
            Dim c As New FxDailyRevaluationNew

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_InterestOnAccountDemand_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_InterestOnAccountDemand_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("WERTBERICHTIGUNGEN - Value Adjustments")
            ' Place code here
            Dim c As New InterestOnAccountALL

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_IRS_CreditEquivalentCalc_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_IRS_CreditEquivalentCalc_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("INTEREST RATE SWAPS Credit Equivalent Calculation")
            ' Place code here
            Dim c As New IrsCreditEquivalentCalculation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_Inventar_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_Inventar_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("INVENTAR")
            ' Place code here
            Dim c As New InventarGesamt

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_KundenSteuerbescheinigung_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_KundenSteuerbescheinigung_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("KUNDEN-STEUERBESCHEINIGUNGEN")
            ' Place code here
            Dim c As New SteuerbescheinigungKunden

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ACCOUNT_OnlineBanking_Element_Click(sender As Object, e As EventArgs) Handles ACCOUNT_OnlineBanking_Element.Click
        If ACCOUNTING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ONLINE BANKING")
            ' Place code here
            Dim c As New OnlineBanking

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
#End Region

#Region "RISK CONTROOLING ACCORDION ELEMENTS"
    Private Sub RISKCONTROL_BusinessTypesCreditPortfolio_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_BusinessTypesCreditPortfolio_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BUSINESS TYPES-CREDIT PORTFOLIO")
            ' Place code here
            Dim c As New BusinessTypes

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub RISKCONTROL_BusinessTypesLiabilities_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_BusinessTypesLiabilities_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BUSINESS TYPES-LIABILITIES")
            ' Place code here
            Dim c As New BusinessTypesLiabilities

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_AssetsLiabilities_Details_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_AssetsLiabilities_Details_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ASSETS and LIABILITIES Details")
            ' Place code here
            Dim c As New AssetsLiabilities_Details

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CAR_Calculation_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CAR_Calculation_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CAR (Capital Adequacy Ratio) CALCULATION")
            ' Place code here
            Dim c As New SolvCalculation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CashPledge_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CashPledge_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CASH PLEDGE")
            ' Place code here
            Dim c As New CashPledge

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CreditRiskMAK_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CreditRiskMAK_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CREDIT RISK + MAK REPORT")
            ' Place code here
            Dim c As New CreditRiskMak

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CreditSpreadRiskCalculation_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CreditSpreadRiskCalculation_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("PORTFOLIO CREDIT SPREAD RISK")
            ' Place code here
            Dim c As New CreditSpreadRiskCalc

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CurrencyRiskCalculation_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CurrencyRiskCalculation_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CURRENCY RISK CALCULATION")
            ' Place code here
            Dim c As New CurrencyRiskCalc

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CustomerRating_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CustomerRating_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER RATINGS")
            ' Place code here
            Dim c As New CustomerRating

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_EL_UL_GA_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_EL_UL_GA_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EXPECTED/UNEXPECTED LOSS and GRANULARITY APPROACH")
            ' Place code here
            Dim c As New UnexpectedLoss

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_IncidentsDatabase_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_IncidentsDatabase_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("INCIDENTS DATABASE (SCHADENSFALL DATENBANK)")
            ' Place code here
            Dim c As New IncidentsDatabase

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_InterestRateRisk_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_InterestRateRisk_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("INTEREST RATE RISK " & vbNewLine & "till 30.12.2018 - Calculation 1")
            ' Place code here
            Dim c As New InterestRateRisk

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_InterestRateRisk_Calc3_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_InterestRateRisk_Calc3_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("INTEREST RATE RISK " & vbNewLine & "as from 31.12.2018 - Calculation 3")
            ' Place code here
            Dim c As New InterestRateRiskCalc3

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_InterestRateRisk_Calc2_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_InterestRateRisk_Calc2_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("INTEREST RATE RISK AMOUNT" & vbNewLine & " for RISK BEARING CAPACITY " & vbNewLine & " as from 31.12.2018 - Calculation 2")
            ' Place code here
            Dim c As New InterestRateRiskCalc2

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_ObligorGratesRatting_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_ObligorGratesRatting_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("OBLIGOR GRATES + RATINGS")
            ' Place code here
            Dim c As New PD

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_RiskStrategyPlanningProcess_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_RiskStrategyPlanningProcess_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("RISK STRATEGY PLANNING PROCESS")
            ' Place code here
            Dim c As New RiskStrategyPlanningProcess

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_RLDC_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_RLDC_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("RISK LIMIT DAILY CONTROL")
            ' Place code here
            Dim c As New RiskLimitDailyControl

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                c.RiskLimitDailyControl_TotalView.Columns.ColumnByFieldName("Client_Lock").Visible = True
            ElseIf EDP_USER = "N" AndAlso SUPER_USER = "N" Then
                c.RiskLimitDailyControl_TotalView.Columns.ColumnByFieldName("Client_Lock").Visible = False
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_ScenarioAnalyzes_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_ScenarioAnalyzes_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SCENARIO ANALYZES")
            ' Place code here
            Dim c As New ScenarioAnalysis

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_StressTestHO_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_StressTestHO_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("STRESS TESTS HEAD OFFICE SCENARIO")
            ' Place code here
            Dim c As New StressTestsHO

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_WeightingFactors_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_WeightingFactors_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("WEIGHTING FACTORS / YIELD CURVES")
            ' Place code here
            Dim c As New WeightingFactors

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CreditSpreadRisk_Parameters_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CreditSpreadRisk_Parameters_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CREDIT SPREAD RISK - PARAMETERS")
            ' Place code here
            Dim c As New CreditSpreadRisk_Parameter_References

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub RISKCONTROL_CreditSpreadRisk_Correlations_Element_Click(sender As Object, e As EventArgs) Handles RISKCONTROL_CreditSpreadRisk_Correlations_Element.Click
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CREDIT SPREAD RISK - SEGMENT CORRELATIONS")
            ' Place code here
            Dim c As New CreditSpreadRisk_Correlations

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub


#End Region

#Region "EDP ACCORDION ELEMENTS"
    Private Sub EDP_GeneralInfo_Element_Click(sender As Object, e As EventArgs) Handles EDP_GeneralInfo_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("GENERAL DATA INFORMATION")
            ' Place code here
            Dim c As New GeneralInfoTiles
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Maximized
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_Audit_Element_Click(sender As Object, e As EventArgs) Handles EDP_Audit_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("AUDIT TABLE VALUES EVENTS")
            ' Place code here
            Dim c As New Audit
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_AuditDDL_Element_Click(sender As Object, e As EventArgs) Handles EDP_AuditDDL_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("AUDIT DATABASE EVENTS")
            ' Place code here
            Dim c As New AuditDDL
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_BAIS_INTERFACE_Element_Click(sender As Object, e As EventArgs) Handles EDP_BAIS_INTERFACE_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BAIS INTERFACE FILES IMPORT")
            ' Place code here
            Dim c As New BaisInterfaceImport

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Maximized
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_BAIS_Imports_Element_Click(sender As Object, e As EventArgs) Handles EDP_BAIS_Imports_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BAIS Forms IMPORTS")
            ' Place code here
            Dim c As New BaisImport

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub


    Private Sub EDP_BAISFiles_ALPHA_Test_Element_Click(sender As Object, e As EventArgs) Handles EDP_BAISFiles_ALPHA_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Select Case BAIS_VERSION_NR
                'Add by Siyao Chen; Time:09.12.2022; Content: update for BAIS version 1.35
                Case = 135
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS COMMON ALPHA FILES EXPORT (VERSION 1.35) - PRODUCTION")
                    Dim c As New BaisExportAlphaV135
                    For Each kf As Form In Me.MdiChildren
                        If c.GetType Is kf.GetType Then
                            kf.Activate()
                            kf.WindowState = FormWindowState.Normal
                            SplashScreenManager.CloseForm(False)
                            Return
                        End If
                    Next
                    c.MdiParent = Me

                    c.Show()
                    c.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)

                Case = 136
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS COMMON ALPHA FILES EXPORT (VERSION 1.36) - PRODUCTION")
                    Dim c As New BaisExportAlphaV136
                    For Each kf As Form In Me.MdiChildren
                        If c.GetType Is kf.GetType Then
                            kf.Activate()
                            kf.WindowState = FormWindowState.Normal
                            SplashScreenManager.CloseForm(False)
                            Return
                        End If
                    Next
                    c.MdiParent = Me

                    c.Show()
                    c.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)

            End Select



        End If
    End Sub

    Private Sub EDP_BAISFiles_AnaCredit_Element_Click(sender As Object, e As EventArgs) Handles EDP_BAISFiles_AnaCredit_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            Select Case BAIS_VERSION_NR
                'Add by WYQ; Time:12.12.2022; Content: update for BAIS version 1.35
                Case = 135
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS ANACREDIT FILES EXPORT (VERSION 1.35) - PRODUCTION")
                    Dim c As New BaisExportAnaCreditV135

                    For Each kf As Form In Me.MdiChildren
                        If c.GetType Is kf.GetType Then
                            kf.Activate()
                            kf.WindowState = FormWindowState.Normal
                            SplashScreenManager.CloseForm(False)
                            Return
                        End If
                    Next
                    c.MdiParent = Me

                    c.Show()
                    c.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)

                Case = 136
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS ANACREDIT FILES EXPORT (VERSION 1.36) - PRODUCTION")
                    Dim c As New BaisExportAnaCreditV136

                    For Each kf As Form In Me.MdiChildren
                        If c.GetType Is kf.GetType Then
                            kf.Activate()
                            kf.WindowState = FormWindowState.Normal
                            SplashScreenManager.CloseForm(False)
                            Return
                        End If
                    Next
                    c.MdiParent = Me

                    c.Show()
                    c.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
            End Select

        End If
    End Sub



    Private Sub EDP_DailyEmailRiskOverview_Element_Click(sender As Object, e As EventArgs) Handles EDP_DailyEmailRiskOverview_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("DAILY EMAIL FOR RISK OVERVIEW")
            ' Place code here
            Dim c As New DailyEmail

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_Debuger_Element_Click(sender As Object, e As EventArgs) Handles EDP_Debuger_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("DEBUGER AT RUNTIME")
            ' Place code here
            Dim c As New DebugRuntime
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_ImportEvents_Element_Click(sender As Object, e As EventArgs) Handles EDP_ImportEvents_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("IMPORT EVENTS")
            ' Place code here
            Dim c As New ImportEvents

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_ManualImports_Element_Click(sender As Object, e As EventArgs) Handles EDP_ManualImports_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("MANUAL IMPORTS")
            ' Place code here
            Dim c As New ManualImport

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_OCBS_Imports_Element_Click(sender As Object, e As EventArgs) Handles EDP_OCBS_Imports_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("NGS IMPORTS-PROCEDURES")
            ' Place code here
            Dim c As New OcbsImport

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_ODAS_Imports_Element_Click(sender As Object, e As EventArgs) Handles EDP_ODAS_Imports_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ODAS IMPORTS-PROCEDURES")
            ' Place code here
            Dim c As New OdasImport

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_OnlineBanking_Element_Click(sender As Object, e As EventArgs) Handles EDP_OnlineBanking_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Online Banking")
            ' Place code here
            Dim c As New OnlineBanking
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_PSTOOL_Client_Element_Click(sender As Object, e As EventArgs) Handles EDP_PSTOOL_Client_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("PS TOOL Client")
            ' Place code here
            Dim c As New RunClient
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_SQL_Parameters_Element_Click(sender As Object, e As EventArgs) Handles EDP_SQL_Parameters_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SQL PARAMETER")
            ' Place code here
            Dim c As New SqlParameter

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_SQL_Parameters_Tree_Element_Click(sender As Object, e As EventArgs) Handles EDP_SQL_Parameters_Tree_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SQL PARAMETER TREE")
            ' Place code here
            Dim c As New SqlParameterTree

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_SQL_Queries_Element_Click(sender As Object, e As EventArgs) Handles EDP_SQL_Queries_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SQL QUERIES")
            ' Place code here
            Dim c As New SqlServerQueries
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_VB_Script_Execute_Element_Click(sender As Object, e As EventArgs) Handles EDP_VB_Script_Execute_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("VB.NET Script execution")
            ' Place code here
            Dim c As New ExecuteVbCode
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub EDP_SQL_FilesCompare_Element_Click(sender As Object, e As EventArgs) Handles EDP_SQL_FilesCompare_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EXCEL/CSV Files compare")
            ' Place code here
            Dim c As New SqlFilesCompare
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_Users_Permissions_Element_Click(sender As Object, e As EventArgs) Handles EDP_Users_Permissions_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Active Directory - (Users - Groups - Permissions")
            ' Place code here
            Dim c As New UserDirectoryPermissions
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EDP_IDV_Inventar_Element_Click(sender As Object, e As EventArgs) Handles EDP_IDV_Inventar_Element.Click
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("IDV Inventar")
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            Dim IDV_Inventar_Excel_Sheet As String = Nothing
            cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='IDV_Inventar_Excel_File' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES_DIRECTORY' and [PARAMETER STATUS]='Y'"
            IDV_Inventar_Excel_Sheet = cmd.ExecuteScalar
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            ' Place code here
            Dim c As New ExcelForm
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "IDV Inventar "
            c.SpreadsheetControl1.ReadOnly = False

            workbookN = c.SpreadsheetControl1.Document
            Using stream As New FileStream(IDV_Inventar_Excel_Sheet, FileMode.Open)
                workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
            End Using


            SplashScreenManager.CloseForm(False)
        End If


    End Sub

#End Region

#Region "EAEG ACCORDION ELEMENTS"
    Private Sub EAEG_Datei_Element_Click(sender As Object, e As EventArgs) Handles EAEG_Datei_Element.Click
        If EAEG_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Lade EAEG - Version 4.1")
            ' Place code here
            Dim c As New EAEG_Datei_New

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub EAEG_StammDaten_Element_Click(sender As Object, e As EventArgs) Handles EAEG_StammDaten_Element.Click
        If EAEG_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Lade EAEG STAMMDATEN")
            ' Place code here
            Dim c As New EAEG_StammDaten

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
#End Region

#Region "ANTI-MONEY LAUNDERING ACCORDION ELEMENTS"


    Private Sub AML_PaymentsFive_PerDay_Element_Click(sender As Object, e As EventArgs) Handles AML_PaymentsFive_PerDay_Element.Click
        'If AML_USER = "N" AndAlso SUPER_USER = "N" Then
        '    XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'Else
        '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        '    SplashScreenManager.Default.SetWaitFormCaption("ANTI MONEY LAUNDERING - MIN. 5 CUSTOMER PAYMENTS PER DAY")
        '    ' Place code here
        '    Dim c As New AntiMoneyPaymentItems
        '    c.MdiParent = Me

        '    c.Show()
        '    c.WindowState = FormWindowState.Maximized
        '    SplashScreenManager.CloseForm(False)
        'End If
    End Sub

    Private Sub AML_PaymentsFrom_TenThsd_Element_Click(sender As Object, e As EventArgs) Handles AML_PaymentsFrom_TenThsd_Element.Click
        'If AML_USER = "N" AndAlso SUPER_USER = "N" Then
        '    XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'Else
        '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        '    SplashScreenManager.Default.SetWaitFormCaption("ANTI MONEY LAUNDERING - CUSTOMER PAYMENTS AS FROM 10.000,00 EUR")
        '    ' Place code here
        '    Dim c As New AntiMoneyAmounts
        '    c.MdiParent = Me

        '    c.Show()
        '    c.WindowState = FormWindowState.Maximized
        '    SplashScreenManager.CloseForm(False)
        'End If
    End Sub
#End Region

#Region "MELDEWESEN ACCORDION ELEMENTS"

#Region "WERTPAPIERSTATISTIK"
    Private Sub MELDW_Wertpapierstatistik_Element_Click(sender As Object, e As EventArgs) Handles MELDW_Wertpapierstatistik_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            Dim dxOK_WERTPAPIERSTAT As New DevExpress.XtraEditors.SimpleButton

            With dxOK_WERTPAPIERSTAT
                .Text = "OK"
                .Height = 23
                .Width = 75
                .ImageList = DF_Wertpapierstatistik.ImageCollection1
                .ImageIndex = 5
                .Location = New System.Drawing.Point(19, 203)
            End With

            DF_Wertpapierstatistik.Controls.Add(dxOK_WERTPAPIERSTAT)
            DF_Wertpapierstatistik.OK_btn.Visible = False
            DF_Wertpapierstatistik.LabelControl1.Visible = True
            DF_Wertpapierstatistik.LabelControl2.Visible = False
            DF_Wertpapierstatistik.LabelControl3.Visible = False
            DF_Wertpapierstatistik.ComboBoxEdit2.Visible = False
            DF_Wertpapierstatistik.ComboBoxEdit3.Visible = False

            AddHandler dxOK_WERTPAPIERSTAT.Click, AddressOf dxOK_WERTPAPIERSTAT_click

            DF_Wertpapierstatistik.Show()
            DF_Wertpapierstatistik.Text = "MONATLICHE WERTPAPIERSTATISTIK MELDUNNG AN BUNDESBANK"
            DF_Wertpapierstatistik.LabelControl1.Text = "Bitte wählen Sie das Datum für die Monatsmeldung"

            QueryText = "Select CONVERT(VARCHAR(10),A.LDate,104) as 'LiquidityDate' from (SELECT  [LiquidityDate] as 'LDate' FROM [SECURITIES_LIQUIDITYRESERVE] GROUP BY [LiquidityDate])A order by A.LDate desc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                If dt.Rows.Count > 0 Then
                    DF_Wertpapierstatistik.ComboBoxEdit1.Properties.Items.Add(row("LiquidityDate"))
                End If
            Next
            If dt.Rows.Count > 0 Then
                DF_Wertpapierstatistik.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("LiquidityDate")
            End If
        End If
    End Sub

    Private Sub dxOK_WERTPAPIERSTAT_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DF_Wertpapierstatistik.ComboBoxEdit1.Text) = True Then
            Dim d As Date = DF_Wertpapierstatistik.ComboBoxEdit1.Text
            DF_Wertpapierstatistik.Close()
            Dim XMLMELDETERMIN As String = d.ToString("yyMM")
            Dim Meldetermin As String = d.ToString("yyyy-MM")
            Dim rdsql As String = d.ToString("yyyyMMdd")

            'Create Crystal Report
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Statistik der Wertpapierinvestments für den " & Meldetermin)
            Dim WertpapierStatistikDa As New SqlDataAdapter("SELECT * FROM [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & rdsql & "'", conn)
            Dim WERTPAPIERSTATISTIKdataset As New DataSet("WERTPAPIERSTATISTIK")
            WertpapierStatistikDa.Fill(WERTPAPIERSTATISTIKdataset, "SECURITIES_LIQUIDITYRESERVE")
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\STATISTIK_WERTPAPIERINVESTMENTS.rpt")
            CrRep.SetDataSource(WERTPAPIERSTATISTIKdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Statistik der Wertpapierinvestments für den " & Meldetermin
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

            If XtraMessageBox.Show("Should the XML File for the Monthly Securities statistic report be generated ?", "XML FILE CREATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    'Bank Data load
                    Dim FIRMENNUMMER As String = Nothing
                    Dim BANKNAME As String = Nothing
                    Dim BANKSTRASSE As String = Nothing
                    Dim BANKPLZ As String = Nothing
                    Dim BANKORT As String = Nothing

                    QueryText = "Select * from [BANK]"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        FIRMENNUMMER = dt.Rows.Item(i).Item("BLZ Bank")
                        BANKNAME = dt.Rows.Item(i).Item("Name Bank") & " , " & dt.Rows.Item(i).Item("Branch Bank")
                        BANKSTRASSE = dt.Rows.Item(i).Item("Strasse Bank")
                        BANKPLZ = dt.Rows.Item(i).Item("PLZ Bank")
                        BANKORT = dt.Rows.Item(i).Item("Ort Bank")
                    Next

                    'Parameter Load
                    Dim XMLSAVEFILE As String = Nothing
                    Dim ABSENDERANREDE As String = Nothing
                    Dim ABSENDERVORNAME As String = Nothing
                    Dim ABSENDERZUNAME As String = Nothing
                    Dim ABSENDERABTEILUNG As String = Nothing
                    Dim ABSENDERTELEFON As String = Nothing
                    Dim ABSENDERFAX As String = Nothing
                    Dim ABSENDEREMAIL As String = Nothing
                    Dim ABSENDEREXTRANETID As String = Nothing

                    QueryText = "Select * from [PARAMETER] where [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='WPB_STAT'"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows.Item(i).Item("PARAMETER1") = "WPBXMLSAVE" Then
                            XMLSAVEFILE = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERANREDE" Then
                            ABSENDERANREDE = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERVORNAME" Then
                            ABSENDERVORNAME = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERZUNAME" Then
                            ABSENDERZUNAME = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERABTEILUNG" Then
                            ABSENDERABTEILUNG = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERTELEFON" Then
                            ABSENDERTELEFON = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDERFAX" Then
                            ABSENDERFAX = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDEREMAIL" Then
                            ABSENDEREMAIL = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                        If dt.Rows.Item(i).Item("PARAMETER1") = "ABSENDEREXTRANETID" Then
                            ABSENDEREXTRANETID = dt.Rows.Item(i).Item("PARAMETER2")
                        End If
                    Next

                    'XML DATEI erstellungsdatum un Zeitdefinieren
                    Dim ERSTELLUNGSDATUM As String = DateTime.Now.ToString("yyyy-MM-dd")
                    Dim ERSTELLUNGSZEIT As DateTime = Format(DateTime.Now, "hh:mm:ss")


                    Dim MyWriter As System.Xml.XmlWriter
                    Dim MySettings As New System.Xml.XmlWriterSettings
                    MySettings.Indent = True
                    MySettings.ConformanceLevel = ConformanceLevel.Auto
                    MySettings.IndentChars = "    "

                    MySettings.NewLineOnAttributes = False
                    MySettings.Encoding = System.Text.Encoding.GetEncoding("UTF-8")

                    MyWriter = System.Xml.XmlWriter.Create(XMLSAVEFILE & "\wpb" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml", MySettings)

                    With MyWriter

                        .WriteStartDocument()
                        .WriteStartElement("LIEFERUNG-WPINVEST", "http://www.bundesbank.de/statistik/wpinvest/v1")
                        .WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                        .WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.bundesbank.de/statistik/wpinvest/v1 BbkXmwWpInvest.xsd")
                        .WriteAttributeString("xmlns", "bbk", Nothing, "http://www.bundesbank.de/xmw/2003-01-01")
                        .WriteAttributeString("version", "1.0")
                        .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "-05:00")
                        .WriteAttributeString("stufe", "Produktion")
                        .WriteAttributeString("bereich", "Statistik")


                        'ELEMENT-ABSENDER
                        .WriteStartElement("bbk", "ABSENDER", "http://www.bundesbank.de/xmw/2003-01-01")
                        .WriteElementString("BLZ", Nothing, FIRMENNUMMER)
                        .WriteElementString("bbk", "NAME", Nothing, BANKNAME)
                        .WriteElementString("bbk", "STRASSE", Nothing, BANKSTRASSE)
                        .WriteElementString("bbk", "ORT", Nothing, BANKPLZ & " " & BANKORT)
                        .WriteElementString("bbk", "LAND", Nothing, "DE")
                        '##############################
                        'UNTERELEMENT-KONTAKT
                        .WriteStartElement("bbk", "KONTAKT", "http://www.bundesbank.de/xmw/2003-01-01")
                        .WriteElementString("bbk", "ANREDE", Nothing, ABSENDERANREDE)
                        .WriteElementString("bbk", "VORNAME", Nothing, ABSENDERVORNAME)
                        .WriteElementString("bbk", "ZUNAME", Nothing, ABSENDERZUNAME)
                        .WriteElementString("bbk", "ABTEILUNG", Nothing, ABSENDERABTEILUNG)
                        .WriteElementString("bbk", "TELEFON", Nothing, ABSENDERTELEFON)
                        .WriteElementString("bbk", "FAX", Nothing, ABSENDERFAX)
                        .WriteElementString("bbk", "EMAIL", Nothing, ABSENDEREMAIL)
                        .WriteElementString("bbk", "EXTRANET-ID", Nothing, ABSENDEREXTRANETID)
                        .WriteEndElement() 'KONTAKT
                        .WriteEndElement() 'ABSENDER
                        'MELDUNG ERSTELLZEIT
                        .WriteStartElement("MELDUNG")
                        .WriteAttributeString("erstellzeit", ERSTELLUNGSDATUM & "T" & ERSTELLUNGSZEIT & "-05:00")
                        '.WriteAttributeString("korrektur", "nein")
                        'MELDER
                        .WriteStartElement("bbk", "MELDER", "http://www.bundesbank.de/xmw/2003-01-01")
                        .WriteElementString("BLZ", Nothing, FIRMENNUMMER)
                        .WriteElementString("bbk", "NAME", Nothing, BANKNAME)
                        .WriteEndElement() 'MELDER
                        'MELDETERMIN
                        .WriteElementString("MELDETERMIN", Nothing, Meldetermin)

                        'FORMULAR KUNDENDEPOTS+++++++++++++++++++++
                        .WriteStartElement("FORMULAR")
                        .WriteStartElement("KUNDENDEPOTS")
                        .WriteElementString("S1100", 0)
                        .WriteElementString("S1215", 0)
                        .WriteElementString("S1225", 0)
                        .WriteElementString("S1228", 0)
                        .WriteElementString("S1230", 0)
                        .WriteElementString("S1240", 0)
                        .WriteElementString("S1251", 0)
                        .WriteElementString("S1252", 0)
                        .WriteElementString("S1261", 0)
                        .WriteElementString("S1262", 0)
                        .WriteElementString("S1270", 0)
                        .WriteElementString("S1280", 0)
                        .WriteElementString("S1290", 0)
                        .WriteElementString("S1311", 0)
                        .WriteElementString("S1312", 0)
                        .WriteElementString("S1313", 0)
                        .WriteElementString("S1314", 0)
                        .WriteElementString("S1400", 0)
                        .WriteElementString("S1500", 0)

                        .WriteEndElement()

                        'WERTPAPIERE+++++++++++++++++++++
                        .WriteStartElement("WERTPAPIERE")

                        'Modify by WYQ; Time:03.03.2022; Content: Change the SQL QueryText to support multi bonds with the same ISIN
                        'QueryText = "SELECT * FROM [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & rdsql & "'"
                        QueryText = "SELECT isin_code, ccy,'DE' as SektorCountry,ROUND(sum(PrincipalOrigAmt),0) as PrincipalOrigAmt,ROUND(sum(OCBS_Booked_Later),0) as OCBS_Booked_Later  FROM [SECURITIES_LIQUIDITYRESERVE] where [LiquidityDate]='" & rdsql & "' group by isin_code, ccy, SektorCountry"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            For i = 0 To dt.Rows.Count - 1
                                .WriteStartElement("WP")

                                .WriteStartElement("STAMM")
                                .WriteElementString("ISIN", dt.Rows.Item(i).Item("ISIN_Code"))
                                .WriteEndElement() 'Close STAMM

                                .WriteStartElement("BESTAND")
                                .WriteAttributeString("dim", dt.Rows.Item(i).Item("Ccy"))

                                .WriteStartElement("S1224")

                                .WriteStartElement("B")
                                .WriteAttributeString("l", dt.Rows.Item(i).Item("SektorCountry"))
                                .WriteValue(dt.Rows.Item(i).Item("PrincipalOrigAmt"))
                                .WriteEndElement()
                                .WriteStartElement("BW")
                                .WriteAttributeString("l", dt.Rows.Item(i).Item("SektorCountry"))
                                .WriteValue(dt.Rows.Item(i).Item("OCBS_Booked_Later"))
                                .WriteEndElement()

                                .WriteEndElement() 'Close S1224

                                .WriteEndElement() 'Close BESTAND

                                .WriteEndElement() 'close WP
                            Next
                        End If

                        .WriteEndElement()
                        .WriteEndElement()
                        '++++++++++++++++++++++++++++++++++
                        .WriteEndDocument()
                        .Close()

                    End With

                    If XtraMessageBox.Show("Following XML file has being generated: " & "wpb" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml" & vbNewLine _
                           & "and saved under the following directory:" & vbNewLine _
                    & XMLSAVEFILE & vbNewLine & vbNewLine _
                    & "Should the directory be opened?", "WPB XML File succesfully generated", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then

                        System.Diagnostics.Process.Start(XMLSAVEFILE)

                    End If

                    'VALIDIERUNG DER XML DATEI
                    Dim myDocument As New XmlDocument
                    myDocument.Load(XMLSAVEFILE & "\wpb" & FIRMENNUMMER & "_" & XMLMELDETERMIN & ".xml")
                    myDocument.Schemas.Add(Nothing, XMLSAVEFILE & "\BbkXmwWpInvest.xsd")
                    Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)
                    myDocument.Validate(eventHandler)

                    Exit Sub



                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        Else
            Exit Sub

        End If
    End Sub
#End Region

#Region "STATISTIK DEVISENHANDELUMSÄTZE-OTC DERIVATE 2016"
    Private Sub MELDW_Devisenhandel_OTC_Element_Click(sender As Object, e As EventArgs) Handles MELDW_Devisenhandel_OTC_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            Dim dxOK_DevisenhandelumsatzStatistik As New DevExpress.XtraEditors.SimpleButton
            With dxOK_DevisenhandelumsatzStatistik
                .Text = "OK"
                .Height = 23
                .Width = 75
                .ImageList = DF_DevisenhandelumsatzStatistik.ImageCollection1
                .ImageIndex = 5
                .Location = New System.Drawing.Point(29, 134)
            End With
            DF_DevisenhandelumsatzStatistik.Controls.Add(dxOK_DevisenhandelumsatzStatistik)
            DF_DevisenhandelumsatzStatistik.OK_btn.Visible = False

            AddHandler dxOK_DevisenhandelumsatzStatistik.Click, AddressOf dxOK_DevisenhandelumsatzStatistik_click

            DF_DevisenhandelumsatzStatistik.Show()
            DF_DevisenhandelumsatzStatistik.Text = "Statistik über Devisenhandelumsätze-OTC Derivate an Deutsche Bundesbank"
            DF_DevisenhandelumsatzStatistik.Text_lbl.Text = "Bitte wählen Sie das Datum für die Meldungserstellung (Version 2016)"
            With DF_DevisenhandelumsatzStatistik.DateEdit1
                .Properties.EditMask = "dd.MM.yyyy"
                .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                .Properties.Appearance.Options.UseTextOptions = True
                .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Text = Today.ToString("dd.MM.yyyy")
            End With
            With DF_DevisenhandelumsatzStatistik.DateEdit2
                .Properties.EditMask = "dd.MM.yyyy"
                .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                .Properties.Appearance.Options.UseTextOptions = True
                .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Text = Today.ToString("dd.MM.yyyy")
            End With
        End If

    End Sub

    Private Sub dxOK_DevisenhandelumsatzStatistik_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If IsDate(DF_DevisenhandelumsatzStatistik.DateEdit1.Text) = True AndAlso IsDate(DF_DevisenhandelumsatzStatistik.DateEdit2.Text) = True Then
                Dim Fd As Date = DF_DevisenhandelumsatzStatistik.DateEdit1.Text
                Dim Td As Date = DF_DevisenhandelumsatzStatistik.DateEdit2.Text
                DF_DevisenhandelumsatzStatistik.Close()
                Dim Frdsql As String = Fd.ToString("yyyyMMdd")
                Dim Trdsql As String = Td.ToString("yyyyMMdd")

                'Create Report
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Statistik über Devisenhandelumsätze" & vbNewLine & " und das Geschäft in OTC-Derivaten vom " & Fd & " bis " & Td)

                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='OTC_Derivate_Excel_Dir' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                ExcelFileName = cmd.ExecuteScalar
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(ExcelFileName, DocumentFormat.Xls)
                Dim Titel As Worksheet = workbook.Worksheets(0)
                Dim Hinweis As Worksheet = workbook.Worksheets(1)
                Dim Blatt1 As Worksheet = workbook.Worksheets(2)
                Dim Blatt2 As Worksheet = workbook.Worksheets(3)
                Dim Blatt3 As Worksheet = workbook.Worksheets(4)
                Dim Blatt4 As Worksheet = workbook.Worksheets(5)
                Dim Blatt5 As Worksheet = workbook.Worksheets(6)
                Dim Blatt6 As Worksheet = workbook.Worksheets(7)


                cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='DEVISENHANDELUMSAETZE_OTC_DERIVATE'"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then

                    'Clear contents
                    Blatt1.ClearContents(Blatt1("D30:M45"))

                    Blatt2.ClearContents(Blatt2("B11:K26"))
                    Blatt2.ClearContents(Blatt2("B30:K33"))
                    Blatt2.ClearContents(Blatt2("B39:K54"))
                    Blatt2.ClearContents(Blatt2("B58:K61"))

                    Blatt3.ClearContents(Blatt3("C14:L19"))
                    Blatt3.ClearContents(Blatt3("C21:L26"))
                    Blatt3.ClearContents(Blatt3("C38:L42"))

                    Blatt4.ClearContents(Blatt4("C16:K21"))
                    Blatt4.ClearContents(Blatt4("C23:K28"))
                    Blatt4.ClearContents(Blatt4("C30:K35"))
                    Blatt4.ClearContents(Blatt4("C37:K42"))

                    Blatt5.ClearContents(Blatt5("C14:L17"))
                    Blatt5.ClearContents(Blatt5("C19:L22"))
                    Blatt5.ClearContents(Blatt5("C24:L27"))
                    Blatt5.ClearContents(Blatt5("C29:L32"))
                    Blatt5.ClearContents(Blatt5("C34:L37"))
                    Blatt5.ClearContents(Blatt5("C44:K47"))

                    Blatt6.ClearContents(Blatt6("C17:J20"))
                    Blatt6.ClearContents(Blatt6("C22:J25"))
                    Blatt6.ClearContents(Blatt6("C27:J30"))
                    Blatt6.ClearContents(Blatt6("C32:J35"))
                    Blatt6.ClearContents(Blatt6("C37:J40"))


                    'Blatt1 Füllen
                    'Melderdaten
                    cmd.CommandText = "Select [Name Bank] + ' , ' + [Branch Bank] from [BANK]"
                    Dim Meldungsbank As String = cmd.ExecuteScalar
                    cmd.CommandText = "Select [Ort Bank] from [BANK]"
                    Dim MeldungsbankOrt As String = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Melder_Ansprechpartner' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim MelderName As String = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Melder_Telefon' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim MelderTelefon As String = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Melder_Email' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim MelderEmail As String = cmd.ExecuteScalar

                    Blatt1.Cells("D14").Value = Meldungsbank
                    Blatt1.Cells("K14").Value = MeldungsbankOrt
                    Blatt1.Cells("D16").Value = MelderName
                    Blatt1.Cells("K16").Value = MelderTelefon
                    Blatt1.Cells("D18").Value = MelderEmail

                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt1' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt1:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt1.Cells(ExcelCell).Value = n
                            Else
                                Blatt1.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt2 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt2' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt2:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt2.Cells(ExcelCell).Value = n
                            Else
                                Blatt2.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt3 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt3' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt3:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt3.Cells(ExcelCell).Value = n
                            Else
                                Blatt3.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt4 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt4' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt4:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt4.Cells(ExcelCell).Value = n
                            Else
                                Blatt4.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt5 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt5' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt5:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt5.Cells(ExcelCell).Value = n
                            Else
                                Blatt5.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt6 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt6' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt6:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt6.Cells(ExcelCell).Value = n
                            Else
                                Blatt6.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                End If

                workbook.SaveDocument(ExcelFileName, DocumentFormat.Xls)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                'Load Excel Workbook
                Dim c As New ExcelForm
                c.MdiParent = Me
                c.Show()
                c.WindowState = FormWindowState.Maximized

                c.Text = "Statistik über Devisenhandelsumsätze und das Geschäft in OTC-Derivaten (Version 2016)"
                c.SpreadsheetControl1.ReadOnly = True

                workbookN = c.SpreadsheetControl1.Document
                Using stream As New FileStream(ExcelFileName, FileMode.Open)
                    workbookN.LoadDocument(stream, DocumentFormat.Xls)
                End Using

                SplashScreenManager.CloseForm(False)


            Else
                Exit Sub

            End If

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR")
            'MsgBox(ex.InnerException)
            MsgBox(SqlCommandText)
        End Try
    End Sub
#End Region

#Region "STATISTIK DEVISENHANDELUMSÄTZE-OTC DERIVATE 2019"

    Private Sub MELDW_Devisenhandel_OTC_2019_Element_Click(sender As Object, e As EventArgs) Handles MELDW_Devisenhandel_OTC_2019_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            Dim dxOK_DevisenhandelumsatzStatistik2019 As New DevExpress.XtraEditors.SimpleButton
            With dxOK_DevisenhandelumsatzStatistik2019
                .Text = "OK"
                .Height = 23
                .Width = 75
                .ImageList = DF_DevisenhandelumsatzStatistik.ImageCollection1
                .ImageIndex = 5
                .Location = New System.Drawing.Point(29, 134)
            End With
            DF_DevisenhandelumsatzStatistik.Controls.Add(dxOK_DevisenhandelumsatzStatistik2019)
            DF_DevisenhandelumsatzStatistik.OK_btn.Visible = False

            AddHandler dxOK_DevisenhandelumsatzStatistik2019.Click, AddressOf dxOK_DevisenhandelumsatzStatistik2019_click

            DF_DevisenhandelumsatzStatistik.Show()
            DF_DevisenhandelumsatzStatistik.Text = "Statistik über Devisenhandelumsätze-OTC Derivate an Deutsche Bundesbank"
            DF_DevisenhandelumsatzStatistik.Text_lbl.Text = "Bitte wählen Sie das Datum für die Meldungserstellung (Version 2019)"
            With DF_DevisenhandelumsatzStatistik.DateEdit1
                .Properties.EditMask = "dd.MM.yyyy"
                .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                .Properties.Appearance.Options.UseTextOptions = True
                .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Text = Today.ToString("dd.MM.yyyy")
            End With
            With DF_DevisenhandelumsatzStatistik.DateEdit2
                .Properties.EditMask = "dd.MM.yyyy"
                .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                .Properties.Appearance.Options.UseTextOptions = True
                .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Text = Today.ToString("dd.MM.yyyy")
            End With
        End If
    End Sub

    Private Sub dxOK_DevisenhandelumsatzStatistik2019_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If IsDate(DF_DevisenhandelumsatzStatistik.DateEdit1.Text) = True AndAlso IsDate(DF_DevisenhandelumsatzStatistik.DateEdit2.Text) = True Then
                Dim Fd As Date = DF_DevisenhandelumsatzStatistik.DateEdit1.Text
                Dim Td As Date = DF_DevisenhandelumsatzStatistik.DateEdit2.Text
                DF_DevisenhandelumsatzStatistik.Close()
                Dim Frdsql As String = Fd.ToString("yyyyMMdd")
                Dim Trdsql As String = Td.ToString("yyyyMMdd")

                'Create Report
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Statistik über Devisenhandelumsätze" & vbNewLine & " und das Geschäft in OTC-Derivaten vom " & Fd & " bis " & Td)

                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='OTC_Derivate_2019_Excel_Dir' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                ExcelFileName = cmd.ExecuteScalar
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(ExcelFileName, DocumentFormat.Xls)
                Dim Titel As Worksheet = workbook.Worksheets(0)
                Dim Hinweis As Worksheet = workbook.Worksheets(1)
                Dim Blatt1 As Worksheet = workbook.Worksheets(2)
                Dim Blatt2 As Worksheet = workbook.Worksheets(3)
                Dim Blatt3 As Worksheet = workbook.Worksheets(4)
                Dim Blatt4 As Worksheet = workbook.Worksheets(5)
                Dim Blatt5 As Worksheet = workbook.Worksheets(6)



                cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='DEVISENHANDELUMSAETZE_OTC_DERIVATE_2019'"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then

                    'Clear contents
                    Blatt1.ClearContents(Blatt1("D30:M45"))

                    Blatt2.ClearContents(Blatt2("B11:K26"))
                    Blatt2.ClearContents(Blatt2("B30:K35"))
                    Blatt2.ClearContents(Blatt2("B41:K56"))
                    Blatt2.ClearContents(Blatt2("B60:K65"))

                    Blatt3.ClearContents(Blatt3("C14:L19"))
                    Blatt3.ClearContents(Blatt3("C31:L35"))

                    Blatt4.ClearContents(Blatt4("C16:K21"))
                    Blatt4.ClearContents(Blatt4("C23:K28"))
                    Blatt4.ClearContents(Blatt4("C30:K35"))
                    Blatt4.ClearContents(Blatt4("C37:K42"))

                    Blatt5.ClearContents(Blatt5("C17:I20"))
                    Blatt5.ClearContents(Blatt5("C22:I25"))
                    Blatt5.ClearContents(Blatt5("C27:I30"))
                    Blatt5.ClearContents(Blatt5("C32:I35"))
                    Blatt5.ClearContents(Blatt5("C37:I40"))


                    'Blatt1 Füllen
                    'Melderdaten
                    cmd.CommandText = "Select [Name Bank] + ' , ' + [Branch Bank] from [BANK]"
                    Dim Meldungsbank As String = cmd.ExecuteScalar
                    cmd.CommandText = "Select [Ort Bank] from [BANK]"
                    Dim MeldungsbankOrt As String = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Melder_Ansprechpartner' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim MelderName As String = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Melder_Telefon' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim MelderTelefon As String = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Melder_Email' and [IdABTEILUNGSPARAMETER]='OTC_DERIVATE_STATISTIK' and [PARAMETER STATUS]='Y' "
                    Dim MelderEmail As String = cmd.ExecuteScalar

                    Blatt1.Cells("D14").Value = Meldungsbank
                    Blatt1.Cells("K14").Value = MeldungsbankOrt
                    Blatt1.Cells("D16").Value = MelderName
                    Blatt1.Cells("K16").Value = MelderTelefon
                    Blatt1.Cells("D18").Value = MelderEmail

                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt1' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE_2019')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt 1:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt1.Cells(ExcelCell).Value = n
                            Else
                                Blatt1.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt2 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt2' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE_2019')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt 2:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)

                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt2.Cells(ExcelCell).Value = n
                            Else
                                Blatt2.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If



                    'Blatt3 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt3' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE_2019')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt 3:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt3.Cells(ExcelCell).Value = n
                            Else
                                Blatt3.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt4 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt4' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE_2019')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt 4:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt4.Cells(ExcelCell).Value = n
                            Else
                                Blatt4.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If

                    'Blatt5 Füllen
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1]='Blatt5' and [Id_SQL_Parameters] in ('DEVISENHANDELUMSAETZE_OTC_DERIVATE_2019')) and [SQL_Command_1] is not NULL and Status in ('Y')"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            Dim ExcelCell As String = dt.Rows.Item(i).Item("SQL_Name_1").ToString
                            SplashScreenManager.Default.SetWaitFormCaption("Ausführung Blatt 5:" & vbNewLine & dt.Rows.Item(i).Item("SQL_Name_2").ToString & vbNewLine & " von " & Fd & " bis " & Td)
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<FromRiskDate>", Frdsql)
                            SqlCommandText = SqlCommandText.Replace("<TillRiskDate>", Trdsql)
                            cmd.CommandText = SqlCommandText
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                n = cmd.ExecuteScalar
                                Blatt5.Cells(ExcelCell).Value = n
                            Else
                                Blatt5.Cells(ExcelCell).Value = 0
                            End If
                        Next
                    End If


                End If

                workbook.SaveDocument(ExcelFileName, DocumentFormat.Xls)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

                'Load Excel Workbook
                Dim c As New ExcelForm
                c.MdiParent = Me
                c.Show()
                c.WindowState = FormWindowState.Maximized

                c.Text = "Statistik über Devisenhandelsumsätze und das Geschäft in OTC-Derivaten (Version 2019)"
                c.SpreadsheetControl1.ReadOnly = True

                workbookN = c.SpreadsheetControl1.Document
                Using stream As New FileStream(ExcelFileName, FileMode.Open)
                    workbookN.LoadDocument(stream, DocumentFormat.Xls)
                End Using

                SplashScreenManager.CloseForm(False)


            Else
                Exit Sub

            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR")
            'MsgBox(ex.InnerException)
            MsgBox(SqlCommandText)
        End Try
    End Sub

#End Region

#Region "EINLAGENSICHERUNG (FREIWILIG)"

    Private Sub MELDW_Einlagensicherung_Freiwillig_Element_Click(sender As Object, e As EventArgs) Handles MELDW_Einlagensicherung_Freiwillig_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            Dim dxOK_EINLAGENSICHERUNG As New DevExpress.XtraEditors.SimpleButton

            With dxOK_EINLAGENSICHERUNG
                .Text = "OK"
                .Height = 23
                .Width = 75
                .ImageList = DF_Einlagensicherung.ImageCollection1
                .ImageIndex = 5
                .Location = New System.Drawing.Point(19, 203)
            End With

            DF_Einlagensicherung.Controls.Add(dxOK_EINLAGENSICHERUNG)
            DF_Einlagensicherung.OK_btn.Visible = False
            DF_Einlagensicherung.LabelControl1.Visible = True
            DF_Einlagensicherung.LabelControl2.Visible = False
            DF_Einlagensicherung.LabelControl3.Visible = False
            DF_Einlagensicherung.ComboBoxEdit2.Visible = False
            DF_Einlagensicherung.ComboBoxEdit3.Visible = False

            AddHandler dxOK_EINLAGENSICHERUNG.Click, AddressOf dxOK_EINLAGENSICHERUNG_click

            DF_Einlagensicherung.Show()
            DF_Einlagensicherung.Text = "EINLAGENSICHERUNG (FREIWILIG) - MONATLICHE MELDUNNG"
            DF_Einlagensicherung.LabelControl1.Text = "Bitte wählen Sie das Datum für die Monatsmeldung"

            QueryText = "Select CONVERT(VARCHAR(10),A.BLDate,104) as 'BSDate' from (SELECT  [BSDate] as 'BLDate' FROM [DailyBalanceSheets] GROUP BY [BSDate])A order by A.BLDate desc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                If dt.Rows.Count > 0 Then
                    DF_Einlagensicherung.ComboBoxEdit1.Properties.Items.Add(row("BSDate"))
                End If
            Next
            If dt.Rows.Count > 0 Then
                DF_Einlagensicherung.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("BSDate")
            End If
        End If
    End Sub

    Private Sub dxOK_EINLAGENSICHERUNG_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DF_Einlagensicherung.ComboBoxEdit1.Text) = True Then
            Dim d As Date = DF_Einlagensicherung.ComboBoxEdit1.Text
            DF_Einlagensicherung.Close()
            Dim rdsql As String = d.ToString("yyyyMMdd")
            'Select Data for Report
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EINLAGENSICHERUNG (FREIWILIG) - Select and calculate Data for " & d)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Calculations - Use SQL_Command_1")
            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EINLAGENSICHERUNG_REP_FREIWILLIG')) and [SQL_Name_1] not in ('SICHERUNGSGRENZE') and [SQL_Command_1] is not NULL and [Status] in ('Y') ORDER BY [SQL_Float_1] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("EINLAGENSICHERUNG (FREIWILIG): " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            Dim Sicherungsgrenze As Double = 0
            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EINLAGENSICHERUNG_REP_FREIWILLIG')) and [SQL_Name_1] in ('SICHERUNGSGRENZE') and '" & rdsql & "' BETWEEN [SQL_Date1] and [SQL_Date2] and [Status] in ('Y')"
            Sicherungsgrenze = cmd.ExecuteScalar
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            'cmd.CommandText = "Delete from [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]"
            'cmd.ExecuteNonQuery()
            ''Insert Term Deposits
            'cmd.CommandText = "INSERT INTO [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]([DepositAccount],[DepositType],[RiskDate]) Select [ReleatedAccountNr],'TERM DEPOSITS',[BSDate] from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "' and [GL_Item] in ('3540','3560','3580','3600','3620','3640')"
            'cmd.ExecuteNonQuery()
            ''Insert Balances and Validity
            'cmd.CommandText = "UPDATE A SET A.[DepositCustomerName]=B.[Counterparty Name], A.[DepositFrom]=B.[Start Date], A.[DepositTill]=B.[Final Maturity Date], A.[DepositAmountEUR]=ABS(B.[Principal (EUR Equivalent)])+ Case when B.[Accrued Interest Coupon EUR Equ] is not NULL then  B.[Accrued Interest Coupon EUR Equ] else 0 end from [EINLAGENSICHERUNG_MELDUNG_PRUFVERB] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[DepositAccount]=B.[Contract] where B.[Datadate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "INSERT INTO [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]([DepositAccount],[DepositType],[RiskDate],[DepositAmountEUR]) Select [ReleatedAccountNr],'DEMAND DEPOSITS',[BSDate],[Total_Balance] from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "' and [GL_Item] in ('3500') and [GL_Account_Nr] in ('23009212','220164')" 'and [Total_Balance]>(Select [NPARAMETER1] from [PARAMETER] where [IdABTEILUNGSPARAMETER]='EINLAGENSICHERUNG' and [PARAMETER1]='Sicherungsgrenze')"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE A SET A.[DepositCustomerName]=B.[English Name] from [EINLAGENSICHERUNG_MELDUNG_PRUFVERB] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[DepositAccount]=B.[Client Account] where A.[DepositCustomerName] is NULL"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "INSERT INTO [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]([DepositCustomerName],[DepositType],[RiskDate],[DepositAmountEUR]) Select 'OTHER DEMAND DEPOSITS','DEMAND DEPOSITS',[BSDate],Sum([Total_Balance]) from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "'and [GL_Item] in ('3500') and [ReleatedAccountNr] not in (Select [DepositAccount] from [EINLAGENSICHERUNG_MELDUNG_PRUFVERB] ) GROUP BY [BSDate]"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "UPDATE [EINLAGENSICHERUNG_MELDUNG_PRUFVERB] SET [DepositAmountEUR]=[DepositAmountEUR] + (Select Sum([Total_Balance]) from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "' and [GL_Item] in ('3500I'))  where [DepositCustomerName]='OTHER DEMAND DEPOSITS'"
            'cmd.ExecuteNonQuery()
            ''Select Parameters
            'Dim Sicherungsgrenze As Double = 0
            'If d <= DateSerial(2013, 12, 31) Then
            '    Sicherungsgrenze = 22122000
            'ElseIf d > DateSerial(2013, 12, 31) And d <= DateSerial(2015, 9, 16) Then
            '    Sicherungsgrenze = 14754000
            'ElseIf d > DateSerial(2015, 9, 16) Then
            '    cmd.CommandText = "Select [NPARAMETER1] from [PARAMETER] where [IdABTEILUNGSPARAMETER]='EINLAGENSICHERUNG' and [PARAMETER1]='SicherungsgrenzeFreiwilig'"
            '    Sicherungsgrenze = cmd.ExecuteScalar
            'End If

            'FILL DATASET
            Dim EinlagensicherungDa As New SqlDataAdapter("SELECT * FROM [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]", conn)
            Dim EINLAGENSICHERUNGdataset As New DataSet("EINLAGENSICHERUNG")
            EinlagensicherungDa.Fill(EINLAGENSICHERUNGdataset, "EINLAGENSICHERUNG_MELDUNG_PRUFVERB")
            'REPORT CREATION
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\EinlagensicherungPrufVerb.rpt")
            CrRep.SetDataSource(EINLAGENSICHERUNGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = Sicherungsgrenze
            myParams.ParameterFieldName = "Sicherungsgrenze"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Meldung zur Einlagensicherung (Freiwilig) für den " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
#End Region

#Region "EINLAGENSICHERUNG (GESETZLICH)"

    Private Sub MELDW_Einlagensicherung_Gesetzlich_Element_Click(sender As Object, e As EventArgs) Handles MELDW_Einlagensicherung_Gesetzlich_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            Dim dxOK_EINLAGENSICHERUNG_GESETZLICH As New DevExpress.XtraEditors.SimpleButton

            With dxOK_EINLAGENSICHERUNG_GESETZLICH
                .Text = "OK"
                .Height = 23
                .Width = 75
                .ImageList = DF_EinlagensicherungGesetzlich.ImageCollection1
                .ImageIndex = 5
                .Location = New System.Drawing.Point(19, 203)
            End With

            DF_EinlagensicherungGesetzlich.Controls.Add(dxOK_EINLAGENSICHERUNG_GESETZLICH)
            DF_EinlagensicherungGesetzlich.OK_btn.Visible = False
            DF_EinlagensicherungGesetzlich.LabelControl1.Visible = True
            DF_EinlagensicherungGesetzlich.LabelControl2.Visible = False
            DF_EinlagensicherungGesetzlich.LabelControl3.Visible = False
            DF_EinlagensicherungGesetzlich.ComboBoxEdit2.Visible = False
            DF_EinlagensicherungGesetzlich.ComboBoxEdit3.Visible = False

            AddHandler dxOK_EINLAGENSICHERUNG_GESETZLICH.Click, AddressOf dxOK_EINLAGENSICHERUNG_GESETZLICH_click

            DF_EinlagensicherungGesetzlich.Show()
            DF_EinlagensicherungGesetzlich.Text = "EINLAGENSICHERUNG (GESETZLICH) - MONATLICHE MELDUNNG"
            DF_EinlagensicherungGesetzlich.LabelControl1.Text = "Bitte wählen Sie das Datum für die Monatsmeldung"

            QueryText = "Select CONVERT(VARCHAR(10),A.BLDate,104) as 'BSDate' from (SELECT  [EAEG_Stichtag] as 'BLDate' FROM [EAEG_A_E_Satz_Version4] GROUP BY [EAEG_Stichtag])A order by A.BLDate desc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                If dt.Rows.Count > 0 Then
                    DF_EinlagensicherungGesetzlich.ComboBoxEdit1.Properties.Items.Add(row("BSDate"))
                End If
            Next
            If dt.Rows.Count > 0 Then
                DF_EinlagensicherungGesetzlich.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("BSDate")
            End If
        End If
    End Sub

    Private Sub dxOK_EINLAGENSICHERUNG_GESETZLICH_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DF_EinlagensicherungGesetzlich.ComboBoxEdit1.Text) = True Then
            Dim d As Date = DF_EinlagensicherungGesetzlich.ComboBoxEdit1.Text
            DF_EinlagensicherungGesetzlich.Close()
            Dim rdsql As String = d.ToString("yyyyMMdd")
            'Select Data for Report
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EINLAGENSICHERUNG (GESETZLICH) - Select related Data from EAEG File for " & d)
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Calculations - Use SQL_Command_1")
            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EINLAGENSICHERUNG_REP_GESETZLICH')) and [SQL_Name_1] not in ('SICHERUNGSGRENZE') and [SQL_Command_1] is not NULL and [Status] in ('Y') ORDER BY [SQL_Float_1] asc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    SplashScreenManager.Default.SetWaitFormCaption("EINLAGENSICHERUNG (GESETZLICH): " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next
            Dim Sicherungsgrenze As Double = 0
            cmd.CommandText = "Select [SQL_Float_1] from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('EINLAGENSICHERUNG_REP_GESETZLICH')) and [SQL_Name_1] in ('SICHERUNGSGRENZE') and '" & rdsql & "' BETWEEN [SQL_Date1] and [SQL_Date2] and [Status] in ('Y')"
            Sicherungsgrenze = cmd.ExecuteScalar
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            'FILL DATASET
            Dim EinlagensicherungDa As New SqlDataAdapter("SELECT * FROM [EINLAGENSICHERUNG_MELDUNG_PRUFVERB]", conn)
            Dim EINLAGENSICHERUNGdataset As New DataSet("EINLAGENSICHERUNG")
            EinlagensicherungDa.Fill(EINLAGENSICHERUNGdataset, "EINLAGENSICHERUNG_MELDUNG_PRUFVERB")
            'REPORT CREATION
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\EinlagensicherungPrufVerbGesetzlich.rpt")
            CrRep.SetDataSource(EINLAGENSICHERUNGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = Sicherungsgrenze
            myParams.ParameterFieldName = "Sicherungsgrenze"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Meldung zur Einlagensicherung (Gesetzlich) für den " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#End Region

    Private Sub MELDW_AWV_Element_Click(sender As Object, e As EventArgs) Handles MELDW_AWV_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("AWV Reports Z4,Z10,Z14-Z15")
            ' Place code here
            Dim c As New AWV

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_Kapitalertragstuer_Soli_Element_Click(sender As Object, e As EventArgs) Handles MELDW_Kapitalertragstuer_Soli_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Kapitalertragsteuer/Soli Meldungen")
            ' Place code here
            Dim c As New KapiSoliMeldungen

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_BISTA_HV11_HV21_Element_Click(sender As Object, e As EventArgs) Handles MELDW_BISTA_HV11_HV21_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BISTA (Bilanzstatistik) Aktiva-Passiva (HV11 - HV21)")
            ' Place code here
            Dim c As New Bista_HV11_HV21

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_BAIS_BISTA_Element_Click(sender As Object, e As EventArgs) Handles MELDW_BAIS_BISTA_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BAIS BISTA Query")
            ' Place code here
            Dim c As New BAIS_BISTA

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_AnaCredit_Contracts_Element_Click(sender As Object, e As EventArgs) Handles MELDW_AnaCredit_Contracts_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("AnaCredit Contracts + Customers")
            ' Place code here
            Dim c As New AnaCreditContracts

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_LCR_Details_Element_Click(sender As Object, e As EventArgs) Handles MELDW_LCR_Details_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("LCR Details")
            ' Place code here
            Dim c As New LCR_Details

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_LiqV_Details_Element_Click(sender As Object, e As EventArgs) Handles MELDW_LiqV_Details_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("LiqV Details")
            ' Place code here
            'Dim c As New LiqV_Details
            Dim c As New LiqV_Calc

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_AESS_Details_Element_Click(sender As Object, e As EventArgs) Handles MELDW_AESS_Details_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Assets Encumbrance Details")
            ' Place code here
            Dim c As New AssetsEncumbrance

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_CURRENCY_RISK_Element_Click(sender As Object, e As EventArgs) Handles MELDW_CURRENCY_RISK_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Currency Risk calculation")
            ' Place code here
            Dim c As New CurrencyRiskCalc

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_CAR_Element_Click(sender As Object, e As EventArgs) Handles MELDW_CAR_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CAR (Solva) calculation")
            ' Place code here
            Dim c As New SolvCalculation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub MELDW_NSFR_Details_Element_Click(sender As Object, e As EventArgs) Handles MELDW_NSFR_Details_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("NSFR Details calculation")
            ' Place code here
            Dim c As New Pivot_NSFR

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_LeverageRatio_Element_Click(sender As Object, e As EventArgs) Handles MELDW_LeverageRatio_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Leverage Ratio calculation")
            ' Place code here
            Dim c As New LeverageRatioCalculation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_AssetsLiabilities_Details_Element_Click(sender As Object, e As EventArgs) Handles MELDW_AssetsLiabilities_Details_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ASSETS and LIABILITIES Details")
            ' Place code here
            Dim c As New AssetsLiabilities_Details

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_ZvStatisticFrom2014_Element_Click(sender As Object, e As EventArgs) Handles MELDW_ZvStatisticFrom2014_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ZV STATISTIC as from 2014")
            ' Place code here
            Dim c As New ZvSta2014

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_ZvstatisticTill2013_Element_Click(sender As Object, e As EventArgs) Handles MELDW_ZvstatisticTill2013_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ZV STATISTIC till 2013")
            ' Place code here
            Dim c As New ZvSta2013

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ZvStatistik_Parameter_AccordionControlElement_Click(sender As Object, e As EventArgs) Handles ZvStatistik_Parameter_AccordionControlElement.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ZV STATISTIC PARAMETERS")
            ' Place code here
            Dim c As New ZvStatistikParameter

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ZvStatistik_PayCard_Parameter_AccordionControlElement_Click(sender As Object, e As EventArgs) Handles ZvStatistik_PayCard_Parameter_AccordionControlElement.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ZV STATISTIC PAYMENTS-CARDS Parameters")
            ' Place code here
            Dim c As New ZvStatistik_PayCard_Parameter

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ZvStatistik_Reporting_AccordionControlElement_Click(sender As Object, e As EventArgs) Handles ZvStatistik_Reporting_AccordionControlElement.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ZV STATISTIC REPORTING")
            ' Place code here
            Dim c As New ZvStatistikReporting

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub ZvStatistik_ValidityRules_AccordionControlElement_Click(sender As Object, e As EventArgs) Handles ZvStatistik_ValidityRules_AccordionControlElement.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ZV STATISTIC VALIDITY RULES")
            ' Place code here
            Dim c As New ZvStatistikValidityParameters

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_OPICS_MM_FX_Deals_Element_Click(sender As Object, e As EventArgs) Handles MELDW_OPICS_MM_FX_Deals_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("OPICS MM and FX Deals")
            ' Place code here
            Dim c As New OPICS_MM_FX

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_MM_STATISTIC_Element_Click(sender As Object, e As EventArgs) Handles MELDW_MM_STATISTIC_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Geldmarktstatistik (Money Market Statistic) for BUNDESBANK")
            ' Place code here
            Dim c As New MM_Statistic

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_AverageOfEmployes_Element_Click(sender As Object, e As EventArgs) Handles MELDW_AverageOfEmployes_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("AVERAGE OF EMPLOYES")
            ' Place code here
            Dim c As New EmployesAverage

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub MELDW_MIFIR_Element_Click(sender As Object, e As EventArgs) Handles MELDW_MIFIR_Element.Click
        If MELDEWESEN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("MIFIR Reporting")
            ' Place code here
            Dim c As New MIFIR

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#End Region

#Region "FOREIGN ACCORDION ELEMENTS"

    Private Sub FOREIGN_ExportLC_MT700_Element_Click(sender As Object, e As EventArgs) Handles FOREIGN_ExportLC_MT700_Element.Click
        If FOREIGN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EXPORT LC - PROCESSING")
            ' Place code here
            Dim c As New LcExportMT7

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FOREIGN_ExportLC_Customers_Element_Click(sender As Object, e As EventArgs) Handles FOREIGN_ExportLC_Customers_Element.Click
        If FOREIGN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("FOREIGN DEPT. CUSTOMERS")
            ' Place code here
            Dim c As New LcExportCustomers

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FOREIGN_ExportLC_Applicants_Element_Click(sender As Object, e As EventArgs) Handles FOREIGN_ExportLC_Applicants_Element.Click
        If FOREIGN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("FOREIGN BANKS AND COMPANIES")
            ' Place code here
            Dim c As New LcExportApplicants

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FOREIGN_ExportLC_Maturities_Element_Click(sender As Object, e As EventArgs) Handles FOREIGN_ExportLC_Maturities_Element.Click
        If FOREIGN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EXPORT LETTER OF CREDITS-MATURITY LIST")
            ' Place code here
            Dim c As New LcExportMaturities

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FOREIGN_IncomingSWIFT_Element_Click(sender As Object, e As EventArgs) Handles FOREIGN_IncomingSWIFT_Element.Click
        If FOREIGN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("SWIFT MESSAGES (INCOMING)")
            ' Place code here
            Dim c As New SwiftMessagesAll

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub FOREIGN_ExportCollection_Element_Click(sender As Object, e As EventArgs) Handles FOREIGN_ExportCollection_Element.Click
        If FOREIGN_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("EXPORT COLLECTION - PROCESSING")
            ' Place code here
            Dim c As New ExportCollection

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#End Region

#Region "COMPLIANCE ACCORDION ELEMENTS"
    Private Sub MGMNT_ManagementCommiteeMeetings_Element_Click(sender As Object, e As EventArgs) Handles MGMNT_ManagementCommiteeMeetings_Element.Click
        If COMPLIANCE_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("MULTIBANK - ACCOUNTS and PERSONS")
            ' Place code here
            Dim c As New MultibankKontenPersonen

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub
#End Region

#Region "CLEARING ACCORDION ELEMENTS"
    Private Sub CLEARING_ChequeCollection_Element_Click(sender As Object, e As EventArgs) Handles CLEARING_ChequeCollection_Element.Click
        If CLEARING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CHEQUE COLLECTIONS")
            ' Place code here
            Dim c As New ChequeCollections

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub CLEARING_ODASRemmitances_Element_Click(sender As Object, e As EventArgs) Handles CLEARING_ODASRemmitances_Element.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ODAS REMMITANCES")
        ' Place code here
        Dim c As New OdasRemmitances

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CLEARING_PaymentsIncoming_Element_Click(sender As Object, e As EventArgs) Handles CLEARING_PaymentsIncoming_Element.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("INCOMING PAYMENT ORDERS")
        ' Place code here
        Dim c As New GmpsPaymentsIn

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CLEARING_PaymentsOutgoing_Element_Click(sender As Object, e As EventArgs) Handles CLEARING_PaymentsOutgoing_Element.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("OUTGOING PAYMENT ORDERS")
        ' Place code here
        Dim c As New GmpsPaymentsOut

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CLEARING_ChargesRequests_Element_Click(sender As Object, e As EventArgs) Handles CLEARING_ChargesRequests_Element.Click
        If CLEARING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CHARGES REQUESTS MT191/991")
            ' Place code here
            Dim c As New ChargesRequests

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub AML_All_Cusomer_Payments_Element_Click(sender As Object, e As EventArgs) Handles AML_All_Cusomer_Payments_Element.Click

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CLEARING - ALL CUSTOMER PAYMENTS")
        ' Place code here
        Dim c As New AntiMoneyAllPaymentItems
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)

    End Sub
#End Region

#Region "CREDIT ACCORDION ELEMENTS"

    Private Sub Credit_CreditPortfolio_Element_Click(sender As Object, e As EventArgs) Handles Credit_CreditPortfolio_Element.Click
        If CREDIT_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BUSINESS TYPES-CREDIT PORTFOLIO")
            ' Place code here
            Dim c As New BusinessTypes

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub Credit_Liabilities_Element_Click(sender As Object, e As EventArgs) Handles Credit_Liabilities_Element.Click
        If CREDIT_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("BUSINESS TYPES-LIABILITIES")
            ' Place code here
            Dim c As New BusinessTypesLiabilities

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub CREDIT_LoansHO_MonthlyReport_Element_Click(sender As Object, e As EventArgs) Handles CREDIT_LoansHO_MonthlyReport_Element.Click
        If CREDIT_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Loans Report to Head Office")
            ' Place code here
            Dim c As New LoansMonthlyHO_Rep

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub CREDIT_LoanTransactions_Element_Click(sender As Object, e As EventArgs) Handles CREDIT_LoanTransactions_Element.Click
        If CREDIT_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Loans Report to Head Office")
            ' Place code here
            Dim c As New LoansBookings

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me
            c.LayoutControlGroup2.Visibility = LayoutVisibility.Never
            c.Show()
            c.Load_LiqV_Details_btn.PerformClick()
            c.LayoutControlItem9.Visibility = LayoutVisibility.Never
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub CREDIT_CustomerRating_Element_Click(sender As Object, e As EventArgs) Handles CREDIT_CustomerRating_Element.Click
        If CREDIT_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Customer Ratings")
            ' Place code here
            Dim c As New CustomerRating

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#End Region

#Region "TREASURY ACCORDION ELEMENTS"

    Private Sub TREAS_FX_Deals_All_Element_Click(sender As Object, e As EventArgs) Handles TREAS_FX_Deals_All_Element.Click
        If TREASURY_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("ALL FX DEALS")
            ' Place code here
            Dim c As New Fx_Deals_ALL

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub TREAS_FXDailyRevaluation_Element_Click(sender As Object, e As EventArgs) Handles TREAS_FXDailyRevaluation_Element.Click
        If TREASURY_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("FX DAILY REVALUATION")
            ' Place code here
            Dim c As New FxDailyRevaluation

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub TREAS_Projection_FX_CreditEquiv_Element_Click(sender As Object, e As EventArgs) Handles TREAS_Projection_FX_CreditEquiv_Element.Click
        If TREASURY_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("PROJECTION OF THE FX CREDIT EQUIV. AMOUNTS")
            ' Place code here
            Dim c As New FxCreditEquivalentCalculationRealTime

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#End Region

#Region "RIBON BUTTONS"
    Private Sub iNewPSTOOL_Session_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iNewPSTOOL_Session.ItemClick
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Starting new PS TOOL Session...")
            Thread.Sleep(2000)
            Process.Start(Application.StartupPath & "\PS TOOL DX.exe")
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

    End Sub

    Private Sub iNewPSTOOL_Test_Session_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iNewPSTOOL_Test_Session.ItemClick

        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Starting new PS TOOL Session (Test Environment)...")
            Thread.Sleep(2000)
            QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER STATUS] in ('Y') and IdABTEILUNGSPARAMETER in ('PS_TOOL_TEST_ENVIRONMENT_DIR') and IdABTEILUNGSCODE_NAME in ('EDP')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim PS_TOOL_Test_Directory As String = dt.Rows.Item(0).Item("PARAMETER2")
            Process.Start(PS_TOOL_Test_Directory)
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub iBankData_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iBankData.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("BANK DATA")
        Dim c As New Bank_Data
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub iConfiguration_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iConfiguration.ItemClick
        'Me.SystemFilesTimer.Stop()
        'Me.SystemFilesTimer.Enabled = False

        'Dim c As New PSTOOL_Login
        'c.ShowDialog()

        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CONFIGURATION")

            Dim c As New Configuration
            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Maximized
                    kf.TopMost = True
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me
            c.Show()
            c.TopMost = True
            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If


    End Sub

    Private Sub ClientMerge_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ClientMerge_BarButtonItem.ItemClick
        If EDP_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            Dim c As New CustomersMerge
            c.ShowDialog()
        End If



    End Sub

    Private Sub iBICDirectory_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iBICDirectory.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("BIC DIRECTORY")
        Dim c As New BIC_DIRECTORY
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iBICplusDirectory_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iBICplusDirectory.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("BANK PLUS DIRECTORY")
        Dim c As New BIC_DIRECTORY_PLUS
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BIC_History_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BIC_History_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("BIC HISTORY")
        Dim c As New BIC_HISTORY
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCustomers_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCustomers.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMERS")
        Dim c As New Customers
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CustomerGroups_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CustomerGroups_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER GROUPS")
        Dim c As New CustomerGrouping
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCustomerAccounts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCustomerAccounts.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DEMAND DEPOSIT ACCOUNTS")
        Dim c As New CustomerAccounts
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iAllContractsAccounts_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iAllContractsAccounts_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ALL CUSTOMERS CONTRACTS / ACCOUNTS")
        Dim c As New AllContractsAccounts
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iInternalCurrencies_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iInternalCurrencies.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("INTERNAL CURRENCIES")
        Dim c As New InternalCurrencies
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        c.Cancel_btn.Focus()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iSSI_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iSSI.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load all Nostro (LORO) Accounts")
        Dim c As New Ssis
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iClients_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iClients.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CORPORATE CLIENTS")
        Dim c As New Client
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iOCBSExchangeRates_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iOCBSExchangeRates.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("EXCHANGE RATES (Core System)")
        Dim c As New ExchangeRatesOCBS
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iIndustrialValuesOCBS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iIndustrialValuesOCBS.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Industrial Values and" & vbNewLine & "other Classifications (Core System - Local)")
        Dim c As New IndustrialValuesOCBS
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iContractTypesOCBS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iContractTypesOCBS.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CONTRACT TYPES (Core System)")
        Dim c As New ContractTypesOCBS
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iProductTypesOCBS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iProductTypesOCBS.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("PRODUCT TYPES (Core System)")
        Dim c As New ProductTypesOCBS
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCurrencyConverterOCBS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCurrencyConverterOCBS.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CURRENCY CONVERTER (Core System) Exchange Rates")
        Dim c As New CurrencyConverterOCBS
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCalendar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCalendar.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CALENDAR")
        Dim c As New Calendar
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iInterestCalculator_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iInterestCalculator.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("INTEREST CALCULATOR")
        Dim c As New InterestCalculator
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iIBANCalculator_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iIBANCalculator.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("IBAN CALCULATOR")
        Dim c As New IbanCalculateVerify
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCountries_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCountries.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("COUNTRIES")
        Dim c As New Countries
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCurrencies_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCurrencies.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CURRENCIES")
        Dim c As New Currencies
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iECBExchangeRates_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iECBExchangeRates.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ECB EXCHANGE RATES")
        Dim c As New ExchangeRatesECB
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCurrencyConverterECB_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCurrencyConverterECB.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ECB CURRENCY CONVERTER")
        Dim c As New CurrencyConverterECB
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iBLZ_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iBLZ.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("BLZ DIRECTORY")
        Dim c As New BLZ_DIRECTORY
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iSEPA_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iSEPA.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("SEPA DIRECTORY")
        Dim c As New SEPA_DIRECTORY
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iPLZ_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iPLZ.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("GERMAN ZIP CODES")
        Dim c As New German_ZIP_Codes
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub NUTS3_Codes_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles NUTS3_Codes_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("NUTS 3 CODES")
        Dim c As New Nuts3_Codes
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub JustizID_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles JustizID_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Justiz Register ID's - Germany")
        Dim c As New JustizRegisterID_DE
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iDailyBalanceSheets_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iDailyBalanceSheets.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DAILY BALANCE SHEETS")
        Dim c As New DailyBalanceSheets
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iDailyBalanceSheetsDetails_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iDailyBalanceSheetsDetails.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DAILY BALANCE SHEETS DETAILS")
        Dim c As New DailyBalanceSheetsDetails
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iDailyPLSheets_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iDailyPLSheets.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DAILY PROFIT + LOSS SHEETS")
        Dim c As New DailyProfitLossSheets
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iFristen_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iFristen.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DAILY FRISTEN REPORT (till 08.12.2017)")
        Dim c As New Fristen
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CashFlows_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CashFlows_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DAILY CASH FLOWS (as from 08.12.2017)")
        Dim c As New Cash_Flows
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iTrialBalance218_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iTrialBalance218.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("TRIAL BALANCE REPORTS")
        Dim c As New TrialBalance218
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iMakReport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iMakReport.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("MAK REPORT - (Original ODAS Report)")
        Dim c As New MAK
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iCreditRisk_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iCreditRisk.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CREDIT RISK REPORT - (Original ODAS Report)")
        Dim c As New CreditRisk
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iFinancialReconciliation_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iFinancialReconciliation.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("FINANCIAL RECONCILIATION")
        Dim c As New FinRecon
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ObligoLiabilities_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ObligoLiabilities_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("OBLIGO LIABILITIES SURPLUS")
        Dim c As New ObligoLiabilitySurplus
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iAccruedInterestAnalysis_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iAccruedInterestAnalysis.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ACCRUED INTEREST ANALYSIS")
        ' Place code here
        Dim c As New AccruedInterestAnalysis

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iExit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iExit.ItemClick
        Me.Close()

    End Sub

    Private Sub iGLAccounts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iGLAccounts.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("GENERAL LEDGER ACCOUNTS")
        Dim c As New GL_Accounts
        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Maximized
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.TopMost = True
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iOrgaChart_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iOrgaChart.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Organisation System")
        Try
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='ORGANIGRAM_DIR' "
            cmd.Connection.Open()
            Dim OrgaSystemDir As String = cmd.ExecuteScalar
            cmd.Connection.Close()

            'If File.Exists(OrgaSystemDir) = True Then
            Process.Start(OrgaSystemDir)
            SplashScreenManager.CloseForm(False)
            'Else
            'SplashScreenManager.CloseForm(False)
            'XtraMessageBox.Show("The Orga System Directory could not be fund!", "ORGA SYSTEM DIRECTORY FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Exit Sub
            'End If


        Catch ex As OleDb.OleDbException
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR ON LOADING ORGA CHART", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try
    End Sub

    Private Sub OCBSallPostingsBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBSallPostingsBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ALL POSTINGS IN OCBS GL ACCOUNTS")
        ' Place code here
        Dim c As New AllPostings

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBS_Postings_Search_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBS_Postings_Search_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ALL POSTINGS IN OCBS GL ACCOUNTS - Search Options")
        ' Place code here
        Dim c As New AllPostingsOCBS_Search

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub NEWGallPostingsBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles NEWGallPostingsBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ALL POSTINGS IN NGS GL ACCOUNTS")
        ' Place code here
        Dim c As New AllPostingsNEWG

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub NGS_Postings_Search_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles NGS_Postings_Search_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("ALL POSTINGS IN NGS GL ACCOUNTS - Search Options")
        ' Place code here
        Dim c As New AllPostingsNGS_Search

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBSinternalNostroBalancesBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBSinternalNostroBalancesBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("INTERNAL NOSTRO ACCOUNT BALANCES")
        ' Place code here
        Dim c As New InternalNostroBalances

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBSExternalNostroBalancesBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBSExternalNostroBalancesBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("EXTERNAL NOSTRO ACCOUNTS POSTINGS + BALANCES (MATCHED ACCOUNTS)")
        ' Place code here
        Dim c As New SwiftStatements

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBSExternalNostroBalancesAllBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBSExternalNostroBalancesAllBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("EXTERNAL NOSTRO ACCOUNTS POSTINGS + BALANCES (ALL EXTERNAL ACCOUNTS)")
        ' Place code here
        Dim c As New SwiftStatementsAll

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBSsuspenceBalancesBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBSsuspenceBalancesBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("SUSPENCE ACCOUNT BALANCES")
        ' Place code here
        Dim c As New SuspenceBalances

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBScustomerBalancesBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBScustomerBalancesBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMERS ACCOUNTS POSTINGS + BALANCES (OCBS - NGS)")
        ' Place code here
        Dim c As New CustomerBalances

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub CorporateCustomerBalancesNEWG_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CorporateCustomerBalancesNEWG_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMERS ACCOUNT BALANCES (NGS)")
        ' Place code here
        Dim c As New CustomerBalancesNEWG

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub OCBSvostroBalancesBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles OCBSvostroBalancesBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("VOSTRO ACCOUNT BALANCES (OCBS)")
        ' Place code here
        Dim c As New CustomerVostroBalances

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub VostroBalancesNEWG_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles VostroBalancesNEWG_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("VOSTRO ACCOUNT BALANCES (NGS)")
        ' Place code here
        Dim c As New CustomerVostroBalancesNEWG

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub T2DirectoryBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles T2DirectoryBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("TARGET2 DIRECTORY")
        ' Place code here
        Dim c As New T2_DIRECTORY

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iHolidays_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iHolidays.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("HOLIDAYS")
        ' Place code here
        Dim c As New Holidays

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iUnratedCustomers_ItemDoubleClick(sender As Object, e As ItemClickEventArgs) Handles iUnratedCustomers.ItemDoubleClick
        If RISKCONTROLLING_USER = "N" AndAlso SUPER_USER = "N" Then
            XtraMessageBox.Show("You are not authorized for this Form", "NO USER AUTHORIZATION", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER RATINGS")
            ' Place code here
            Dim c As New CustomerRating

            For Each kf As Form In Me.MdiChildren
                If c.GetType Is kf.GetType Then
                    kf.Activate()
                    kf.WindowState = FormWindowState.Normal
                    SplashScreenManager.CloseForm(False)
                    Return
                End If
            Next
            c.MdiParent = Me

            c.Show()
            c.CustomerRating_BaseView.ActiveFilterString = "[Rating]='U'"

            c.WindowState = FormWindowState.Maximized
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub PivotGrid_BS_Details_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PivotGrid_BS_Details_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Daily Balance Sheet - Details - PIVOT")
        ' Place code here
        Dim c As New Pivot_BS_Details

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PivotGrid_BS_Totals_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PivotGrid_BS_Totals_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Daily Balance Sheet - Totals - PIVOT")
        ' Place code here
        Dim c As New Pivot_BS_Totals

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Pivotgrid_FinRecon_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Pivotgrid_FinRecon_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Financial Reconciliation - PIVOT")
        ' Place code here
        Dim c As New Pivot_Finrecon

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Pivotgrid_ObligoLiabilitySurplusBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Pivotgrid_ObligoLiabilitySurplusBarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Obligo Liability Surplus - PIVOT")
        ' Place code here
        Dim c As New Pivot_ObligoLiabilitySurplus

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PivotGrid_Liquidity_Overview_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PivotGrid_Liquidity_Overview_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Liquidity Overview - PIVOT")
        ' Place code here
        Dim c As New Pivot_Liquidity_Overview

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PivotGrid_HGB_Positions_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PivotGrid_HGB_Positions_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("HGB Positions - PIVOT")
        ' Place code here
        Dim c As New Pivot_HGB_Positions

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PivotGrid_All_Postings_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PivotGrid_All_Postings_BarButtonItem.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("All Postings - PIVOT ... Please wait...")
        ' Place code here
        Dim c As New Pivot_All_Volumes

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub iHelp_ItemClick(sender As Object, e As ItemClickEventArgs) Handles iHelp.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='HELP_DOC_DIR' and [PARAMETER STATUS]='Y' "
        UserGuideFile = cmd.ExecuteScalar
        cmd.Connection.Close()

        System.Diagnostics.Process.Start(UserGuideFile)
        'Dim f As New PdfDevForm
        'f.MdiParent = Me.MdiParent
        'f.Show()
        'f.Text = "PS TOOL User Guide"
        'f.PdfViewer1.LoadDocument(UserGuideFile)
        'f.PdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub FullWindowModeBarCheckItem_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles FullWindowModeBarCheckItem.CheckedChanged
        If Me.FullWindowModeBarCheckItem.Checked = True Then
            Me.AccordionControl1.Visible = False

        Else
            Me.AccordionControl1.Visible = True
        End If
    End Sub

    Private Sub SingleTabbedViewModeBarCheckItem_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles SingleTabbedViewModeBarCheckItem.CheckedChanged
        If Me.SingleTabbedViewModeBarCheckItem.Checked = True Then
            Me.DocumentManager1.View = Me.TabbedView1
        Else
            Me.DocumentManager1.View = Me.NativeMdiView1

        End If
    End Sub

#End Region

#Region "TREELIST"
    Private Sub TreeList1_CustomDrawNodeCell(sender As Object, e As CustomDrawNodeCellEventArgs) Handles TreeList1.CustomDrawNodeCell
        'Backcolor filter cell
        If e.CellText = "" Then
            e.Appearance.BackColor = System.Drawing.Color.DimGray
            e.Appearance.BackColor2 = System.Drawing.Color.DimGray
        End If
    End Sub


    Private Sub TreeList1_DoubleClick(sender As Object, e As EventArgs) Handles TreeList1.DoubleClick

        Dim tree As TreeList = TryCast(sender, TreeList)
        Dim hi As TreeListHitInfo = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition))
        If hi.Node IsNot Nothing Then

            Dim NodeText As String = hi.Node.GetDisplayText(0)


            Select Case NodeText

                Case Is = "Interest Rate Risk (Daily)"
                    dxOK_IRRD = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IRRD
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IRR_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IRR_daily.Controls.Add(dxOK_IRRD)
                    'dxOK_IRRD.Visible = True
                    DF_IRR_daily.OK_btn.Visible = False
                    DF_IRR_daily.LabelControl1.Visible = False
                    DF_IRR_daily.LabelControl2.Visible = False
                    DF_IRR_daily.DateEdit2.Visible = False

                    AddHandler dxOK_IRRD.Click, AddressOf dxOK_IRRD_click

                    DF_IRR_daily.Show()
                    DF_IRR_daily.Text = "INTEREST RATE RISK REPORT CREATION"
                    DF_IRR_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_IRR_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Interest Rate Risk Chart"
                    dxOK_IRRDC = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IRRDC
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IRR_dailyChart.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IRR_dailyChart.Controls.Add(dxOK_IRRDC)
                    dxOK_IRRDC.Visible = True
                    DF_IRR_dailyChart.OK_btn.Visible = False

                    AddHandler dxOK_IRRDC.Click, AddressOf dxOK_IRRDC_click

                    DF_IRR_dailyChart.Show()
                    DF_IRR_dailyChart.Text = "INTEREST RATE RISK CHART CREATION"
                    DF_IRR_dailyChart.Text_lbl.Text = "Please input the Period for chart creation"
                    With DF_IRR_dailyChart.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_IRR_dailyChart.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Interest Rate Risk Amount for Risk bearing Capacity"
                    dxOK_IRRD_RB = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IRRD_RB
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IRR_RB_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IRR_RB_daily.Controls.Add(dxOK_IRRD_RB)
                    dxOK_IRRD_RB.Visible = True
                    DF_IRR_RB_daily.OK_btn.Visible = False
                    DF_IRR_RB_daily.LabelControl1.Visible = False
                    DF_IRR_RB_daily.LabelControl2.Visible = False
                    DF_IRR_RB_daily.DateEdit2.Visible = False

                    AddHandler dxOK_IRRD_RB.Click, AddressOf dxOK_IRRD_RB_click

                    DF_IRR_RB_daily.Show()
                    DF_IRR_RB_daily.Text = "INTEREST RATE RISK REPORT CREATION"
                    DF_IRR_RB_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_IRR_RB_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Interest Rate Risk (HUMP-TWIST1-TWIST2)"
                    dxOK_IRRD_HUMP = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IRRD_HUMP
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IRR_HUMP_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IRR_HUMP_daily.Controls.Add(dxOK_IRRD_HUMP)
                    dxOK_IRRD_HUMP.Visible = True
                    DF_IRR_HUMP_daily.OK_btn.Visible = False
                    DF_IRR_HUMP_daily.LabelControl1.Visible = False
                    DF_IRR_HUMP_daily.LabelControl2.Visible = False
                    DF_IRR_HUMP_daily.DateEdit2.Visible = False

                    AddHandler dxOK_IRRD_HUMP.Click, AddressOf dxOK_IRRD_HUMP_click

                    DF_IRR_HUMP_daily.Show()
                    DF_IRR_HUMP_daily.Text = "INTEREST RATE RISK REPORT CREATION"
                    DF_IRR_HUMP_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_IRR_HUMP_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Interest Rate Risk - Zinsbindungs Chart"
                    dxOK_IRR_ZinsbindungChart = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IRR_ZinsbindungChart
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IRR_ZinsbindungChart.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IRR_ZinsbindungChart.Controls.Add(dxOK_IRR_ZinsbindungChart)
                    dxOK_IRR_ZinsbindungChart.Visible = True
                    DF_IRR_ZinsbindungChart.OK_btn.Visible = False
                    DF_IRR_ZinsbindungChart.LabelControl1.Visible = False
                    DF_IRR_ZinsbindungChart.LabelControl2.Visible = False
                    DF_IRR_ZinsbindungChart.DateEdit2.Visible = False

                    AddHandler dxOK_IRR_ZinsbindungChart.Click, AddressOf dxOK_IRR_ZinsbindungChart_click

                    DF_IRR_ZinsbindungChart.Show()
                    DF_IRR_ZinsbindungChart.Text = "INTEREST RATE RISK ZINSBINDUNGS CHART CREATION"
                    DF_IRR_ZinsbindungChart.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_IRR_ZinsbindungChart.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Interest Rate Risk net Positions reconciliation"
                    dxOK_IRR_NetRecon = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IRR_NetRecon
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IRR_NetPos_Reconcile.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IRR_NetPos_Reconcile.Controls.Add(dxOK_IRR_NetRecon)
                    dxOK_IRR_NetRecon.Visible = True
                    DF_IRR_NetPos_Reconcile.OK_btn.Visible = False

                    AddHandler dxOK_IRR_NetRecon.Click, AddressOf dxOK_IRR_NetRecon_click

                    DF_IRR_NetPos_Reconcile.Show()
                    DF_IRR_NetPos_Reconcile.Text = "INTEREST RATE RISK NET POSITIONS RECONCILIATION"
                    DF_IRR_NetPos_Reconcile.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_IRR_NetPos_Reconcile.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_IRR_NetPos_Reconcile.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily Risk Tables"
                    dxOK_DailyRiskTable = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_DailyRiskTable
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RiskTables_Daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_RiskTables_Daily.Controls.Add(dxOK_DailyRiskTable)
                    dxOK_DailyRiskTable.Visible = True
                    DF_RiskTables_Daily.OK_btn.Visible = False
                    DF_RiskTables_Daily.LabelControl1.Visible = False
                    DF_RiskTables_Daily.LabelControl2.Visible = False
                    DF_RiskTables_Daily.DateEdit2.Visible = False

                    AddHandler dxOK_DailyRiskTable.Click, AddressOf dxOK_DailyRiskTable_click

                    DF_RiskTables_Daily.Show()
                    DF_RiskTables_Daily.Text = "DAILY RISK TABLES REPORT CREATION"
                    DF_RiskTables_Daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_RiskTables_Daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Loans Structure Table"
                    dxOK_LoansStructure = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_LoansStructure
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_LoansStructure_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_LoansStructure_daily.Controls.Add(dxOK_LoansStructure)
                    dxOK_LoansStructure.Visible = True
                    DF_LoansStructure_daily.OK_btn.Visible = False
                    DF_LoansStructure_daily.LabelControl1.Visible = False
                    DF_LoansStructure_daily.LabelControl2.Visible = False
                    DF_LoansStructure_daily.DateEdit2.Visible = False

                    AddHandler dxOK_LoansStructure.Click, AddressOf dxOK_LoansStructure_click

                    DF_LoansStructure_daily.Show()
                    DF_LoansStructure_daily.Text = "LOAN STRUCTURE REPORT CREATION"
                    DF_LoansStructure_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_LoansStructure_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Risk limit daily control"
                    dxOK_RiskLimitDailyControl = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_RiskLimitDailyControl
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RiskLimitDailyControl.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_RiskLimitDailyControl.Controls.Add(dxOK_RiskLimitDailyControl)
                    dxOK_RiskLimitDailyControl.Visible = True
                    DF_RiskLimitDailyControl.OK_btn.Visible = False

                    AddHandler dxOK_RiskLimitDailyControl.Click, AddressOf dxOK_RiskLimitDailyControl_click

                    DF_RiskLimitDailyControl.Show()
                    DF_RiskLimitDailyControl.Text = "RISK LIMIT DAILY CONTROL"
                    DF_RiskLimitDailyControl.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_RiskLimitDailyControl.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_RiskLimitDailyControl.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Obligo Liability Surplus"

                    dxOK_ObligoLiabilitySurplus = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_ObligoLiabilitySurplus
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ObligoLiabilitySurplus.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_ObligoLiabilitySurplus.Controls.Add(dxOK_ObligoLiabilitySurplus)
                    dxOK_ObligoLiabilitySurplus.Visible = True
                    DF_ObligoLiabilitySurplus.OK_btn.Visible = False
                    DF_ObligoLiabilitySurplus.LabelControl1.Visible = False
                    DF_ObligoLiabilitySurplus.LabelControl2.Visible = False
                    DF_ObligoLiabilitySurplus.DateEdit2.Visible = False

                    AddHandler dxOK_ObligoLiabilitySurplus.Click, AddressOf dxOK_ObligoLiabilitySurplus_click

                    DF_ObligoLiabilitySurplus.Show()
                    DF_ObligoLiabilitySurplus.Text = "OBLIGO LIABILITY SURPLUS"
                    DF_ObligoLiabilitySurplus.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_ObligoLiabilitySurplus.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily Risk Chart"
                    dxOK_DailyRiskChart = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_DailyRiskChart
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RiskChart_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_RiskChart_daily.Controls.Add(dxOK_DailyRiskChart)
                    dxOK_DailyRiskChart.Visible = True
                    DF_RiskChart_daily.OK_btn.Visible = False

                    AddHandler dxOK_DailyRiskChart.Click, AddressOf dxOK_DailyRiskChart_click

                    DF_RiskChart_daily.Show()
                    DF_RiskChart_daily.Text = "DAILY RISK CHART"
                    DF_RiskChart_daily.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_RiskChart_daily.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_RiskChart_daily.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily CAR Chart"
                    dxOK_DailyCarChart = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_DailyCarChart
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_CarChart_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_CarChart_daily.Controls.Add(dxOK_DailyCarChart)
                    dxOK_DailyCarChart.Visible = True
                    DF_CarChart_daily.OK_btn.Visible = False

                    AddHandler dxOK_DailyCarChart.Click, AddressOf dxOK_DailyCarChart_click

                    DF_CarChart_daily.Show()
                    DF_CarChart_daily.Text = "DAILY CAR CHART"
                    DF_CarChart_daily.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_CarChart_daily.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_CarChart_daily.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily Liquidity Chart"
                    dxOK_DailyLiquidityChart = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_DailyLiquidityChart
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_LiquidityChart_Daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_LiquidityChart_Daily.Controls.Add(dxOK_DailyLiquidityChart)
                    dxOK_DailyLiquidityChart.Visible = True
                    DF_LiquidityChart_Daily.OK_btn.Visible = False

                    AddHandler dxOK_DailyLiquidityChart.Click, AddressOf dxOK_DailyLiquidityChart_click

                    DF_LiquidityChart_Daily.Show()
                    DF_LiquidityChart_Daily.Text = "DAILY CAR CHART"
                    DF_LiquidityChart_Daily.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_LiquidityChart_Daily.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_LiquidityChart_Daily.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With


                Case Is = "Industrial Distribution reconciliation"
                    dxOK_IndustrialDistributionRecon = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IndustrialDistributionRecon
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IndustrialDistributionRecon.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_IndustrialDistributionRecon.Controls.Add(dxOK_IndustrialDistributionRecon)
                    dxOK_IndustrialDistributionRecon.Visible = True
                    DF_IndustrialDistributionRecon.OK_btn.Visible = False

                    AddHandler dxOK_IndustrialDistributionRecon.Click, AddressOf dxOK_IndustrialDistributionRecon_click

                    DF_IndustrialDistributionRecon.Show()
                    DF_IndustrialDistributionRecon.Text = "RECONCILIATION OF THE INDUSTRIAL DISTRIBUTION"
                    DF_IndustrialDistributionRecon.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_IndustrialDistributionRecon.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_IndustrialDistributionRecon.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Maturity Structure reconciliation"
                    dxOK_MaturityStrutureRecon = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_MaturityStrutureRecon
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_MaturityStructureRecon.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_MaturityStructureRecon.Controls.Add(dxOK_MaturityStrutureRecon)
                    dxOK_MaturityStrutureRecon.Visible = True
                    DF_MaturityStructureRecon.OK_btn.Visible = False

                    AddHandler dxOK_MaturityStrutureRecon.Click, AddressOf dxOK_MaturityStrutureRecon_click

                    DF_MaturityStructureRecon.Show()
                    DF_MaturityStructureRecon.Text = "RECONCILIATION OF THE MATURITY STRUCTURE"
                    DF_MaturityStructureRecon.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_MaturityStructureRecon.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_MaturityStructureRecon.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Business Types Credit Portfolio reconciliation"
                    dxOK_BusinessTypesCreditPortfolioRecon = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_BusinessTypesCreditPortfolioRecon
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_BusinessTypesCreditPortfolioRecon.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_BusinessTypesCreditPortfolioRecon.Controls.Add(dxOK_BusinessTypesCreditPortfolioRecon)
                    dxOK_BusinessTypesCreditPortfolioRecon.Visible = True
                    DF_BusinessTypesCreditPortfolioRecon.OK_btn.Visible = False

                    AddHandler dxOK_BusinessTypesCreditPortfolioRecon.Click, AddressOf dxOK_BusinessTypesCreditPortfolioRecon_click

                    DF_BusinessTypesCreditPortfolioRecon.Show()
                    DF_BusinessTypesCreditPortfolioRecon.Text = "RECONCILIATION OF THE BUSINESS TYPES-CREDIT PORTFOLIO"
                    DF_BusinessTypesCreditPortfolioRecon.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_BusinessTypesCreditPortfolioRecon.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_BusinessTypesCreditPortfolioRecon.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Countries with large credit exposure reconciliation"
                    dxOK_CountriesLargeCreditExposureRecon = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_CountriesLargeCreditExposureRecon
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_CountriesLargeCreditExposureRecon.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_CountriesLargeCreditExposureRecon.Controls.Add(dxOK_CountriesLargeCreditExposureRecon)
                    dxOK_CountriesLargeCreditExposureRecon.Visible = True
                    DF_CountriesLargeCreditExposureRecon.OK_btn.Visible = False

                    AddHandler dxOK_CountriesLargeCreditExposureRecon.Click, AddressOf dxOK_CountriesLargeCreditExposureRecon_click

                    DF_CountriesLargeCreditExposureRecon.Show()
                    DF_CountriesLargeCreditExposureRecon.Text = "RECONCILIATION FOR COUNTRIES WITH LARGE CREDIT EXPOSURE"
                    DF_CountriesLargeCreditExposureRecon.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_CountriesLargeCreditExposureRecon.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_CountriesLargeCreditExposureRecon.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Rating classifications reconciliation"
                    dxOK_RatingClasificationRecon = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_RatingClasificationRecon
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RatingClasificationRecon.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_RatingClasificationRecon.Controls.Add(dxOK_RatingClasificationRecon)
                    dxOK_RatingClasificationRecon.Visible = True
                    DF_RatingClasificationRecon.OK_btn.Visible = False

                    AddHandler dxOK_RatingClasificationRecon.Click, AddressOf dxOK_RatingClasificationRecon_click

                    DF_RatingClasificationRecon.Show()
                    DF_RatingClasificationRecon.Text = "RECONCILIATION FOR COUNTRIES WITH LARGE CREDIT EXPOSURE"
                    DF_RatingClasificationRecon.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_RatingClasificationRecon.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_RatingClasificationRecon.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Risk bearing capacity (Daily)"
                    dxOK_RiskBearingCapacityDaily = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_RiskBearingCapacityDaily
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RiskBearingCapacity_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_RiskBearingCapacity_daily.Controls.Add(dxOK_RiskBearingCapacityDaily)
                    dxOK_RiskBearingCapacityDaily.Visible = True
                    DF_RiskBearingCapacity_daily.OK_btn.Visible = False
                    DF_RiskBearingCapacity_daily.LabelControl1.Visible = False
                    DF_RiskBearingCapacity_daily.LabelControl2.Visible = False
                    DF_RiskBearingCapacity_daily.DateEdit2.Visible = False

                    AddHandler dxOK_RiskBearingCapacityDaily.Click, AddressOf dxOK_RiskBearingCapacityDaily_click

                    DF_RiskBearingCapacity_daily.Show()
                    DF_RiskBearingCapacity_daily.Text = "RISK BEARING CAPACITY REPORT CREATION"
                    DF_RiskBearingCapacity_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_RiskBearingCapacity_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Risk bearing capacity (Chart)"
                    dxOK_RiskBearingCapacityChartDaily = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_RiskBearingCapacityChartDaily
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RiskBearingCapacity_Chartdaily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_RiskBearingCapacity_Chartdaily.Controls.Add(dxOK_RiskBearingCapacityChartDaily)
                    dxOK_RiskBearingCapacityChartDaily.Visible = True
                    DF_RiskBearingCapacity_Chartdaily.OK_btn.Visible = False

                    AddHandler dxOK_RiskBearingCapacityChartDaily.Click, AddressOf dxOK_RiskBearingCapacityChartDaily_click

                    DF_RiskBearingCapacity_Chartdaily.Show()
                    DF_RiskBearingCapacity_Chartdaily.Text = "RISK BEARING CAPACITY CHART REPORT CREATION"
                    DF_RiskBearingCapacity_Chartdaily.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_RiskBearingCapacity_Chartdaily.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_RiskBearingCapacity_Chartdaily.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With



                Case Is = "Stress Tests - Liquidity Head office scenario"
                    dxOK_StressTestsLiquidityHODaily = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_StressTestsLiquidityHODaily
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_StressTestsHOliquidity_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_StressTestsHOliquidity_daily.Controls.Add(dxOK_StressTestsLiquidityHODaily)
                    dxOK_StressTestsLiquidityHODaily.Visible = True
                    DF_StressTestsHOliquidity_daily.OK_btn.Visible = False
                    DF_StressTestsHOliquidity_daily.LabelControl1.Visible = False
                    DF_StressTestsHOliquidity_daily.LabelControl2.Visible = False
                    DF_StressTestsHOliquidity_daily.DateEdit2.Visible = False

                    AddHandler dxOK_StressTestsLiquidityHODaily.Click, AddressOf dxOK_StressTestsLiquidityHODaily_click

                    DF_StressTestsHOliquidity_daily.Show()
                    DF_StressTestsHOliquidity_daily.Text = "STRESS TESTS - LIQUIDITY H.O. SCENARIO REPORT CREATION"
                    DF_StressTestsHOliquidity_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_StressTestsHOliquidity_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Business Types-Credit Portfolio"
                    dxOK_BusinessTypesCreditPortfolio = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_BusinessTypesCreditPortfolio
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_BusinessTypesCreditPortfolio.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_BusinessTypesCreditPortfolio.Controls.Add(dxOK_BusinessTypesCreditPortfolio)
                    dxOK_BusinessTypesCreditPortfolio.Visible = True
                    DF_BusinessTypesCreditPortfolio.OK_btn.Visible = False
                    DF_BusinessTypesCreditPortfolio.LabelControl1.Visible = False
                    DF_BusinessTypesCreditPortfolio.LabelControl2.Visible = False
                    DF_BusinessTypesCreditPortfolio.DateEdit2.Visible = False

                    AddHandler dxOK_BusinessTypesCreditPortfolio.Click, AddressOf dxOK_BusinessTypesCreditPortfolio_click

                    DF_BusinessTypesCreditPortfolio.Show()
                    DF_BusinessTypesCreditPortfolio.Text = "BUSINESS TYPES-CREDIT PORTFOLIO REPORT CREATION"
                    DF_BusinessTypesCreditPortfolio.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_BusinessTypesCreditPortfolio.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With


                Case Is = "Cashflow analysis"
                    dxOK_CashFlowAnalysisDaily = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_CashFlowAnalysisDaily
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_CashFlowAnalysis_daily.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_CashFlowAnalysis_daily.Controls.Add(dxOK_CashFlowAnalysisDaily)
                    dxOK_CashFlowAnalysisDaily.Visible = True
                    DF_CashFlowAnalysis_daily.OK_btn.Visible = False
                    DF_CashFlowAnalysis_daily.LabelControl1.Visible = False
                    DF_CashFlowAnalysis_daily.LabelControl2.Visible = False
                    DF_CashFlowAnalysis_daily.DateEdit2.Visible = False

                    With dxOK_CashFlowAnalysisDailyPrintDetailsCombo
                        .Height = 20
                        .Width = 299
                        .Location = New System.Drawing.Point(29, 102)
                        .Properties.Items.Add("Print Details")
                        .Properties.Items.Add("Do not print details")
                        .Properties.TextEditStyle = TextEditStyles.DisableTextEditor
                        .Text = "Do not print details"
                    End With
                    DF_CashFlowAnalysis_daily.Controls.Add(dxOK_CashFlowAnalysisDailyPrintDetailsCombo)
                    PrintDetailsCashflowAnalysis = dxOK_CashFlowAnalysisDailyPrintDetailsCombo.Text

                    AddHandler dxOK_CashFlowAnalysisDailyPrintDetailsCombo.TextChanged, AddressOf dxOK_CashFlowAnalysisDailyPrintDetailsCombo_TextChanged
                    AddHandler dxOK_CashFlowAnalysisDaily.Click, AddressOf dxOK_CashFlowAnalysisDaily_click

                    DF_CashFlowAnalysis_daily.Show()
                    DF_CashFlowAnalysis_daily.Text = "CASHFLOW ANALYSIS REPORT CREATION"
                    DF_CashFlowAnalysis_daily.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_CashFlowAnalysis_daily.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "New credit Business"
                    dxOK_NewCreditBusiness = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_NewCreditBusiness
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_NewCreditBusiness.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_NewCreditBusiness.Controls.Add(dxOK_NewCreditBusiness)
                    dxOK_NewCreditBusiness.Visible = True
                    DF_NewCreditBusiness.OK_btn.Visible = False

                    AddHandler dxOK_NewCreditBusiness.Click, AddressOf dxOK_NewCreditBusiness_click

                    DF_NewCreditBusiness.Show()
                    DF_NewCreditBusiness.Text = "NEW CREDIT BUSINESS REPORT CREATION"
                    DF_NewCreditBusiness.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_NewCreditBusiness.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_NewCreditBusiness.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Refinancing Maturity List"
                    dxOK_RefinancingMaturityList = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_RefinancingMaturityList
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_RefinancingMaturityList.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_RefinancingMaturityList.Controls.Add(dxOK_RefinancingMaturityList)
                    dxOK_RefinancingMaturityList.Visible = True
                    DF_RefinancingMaturityList.OK_btn.Visible = False
                    DF_RefinancingMaturityList.LabelControl1.Visible = False
                    DF_RefinancingMaturityList.LabelControl2.Visible = False
                    DF_RefinancingMaturityList.DateEdit2.Visible = False

                    AddHandler dxOK_RefinancingMaturityList.Click, AddressOf dxOK_RefinancingMaturityList_click

                    DF_RefinancingMaturityList.Show()
                    DF_RefinancingMaturityList.Text = "REFINANCING MATURITY LIST REPORT CREATION"
                    DF_RefinancingMaturityList.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_RefinancingMaturityList.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily Art.13 KWG for Chinese Banks report"
                    dxOK_Kwg13_ChineseBanks = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_Kwg13_ChineseBanks
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_Kwg13_ChineseBanks.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_Kwg13_ChineseBanks.Controls.Add(dxOK_Kwg13_ChineseBanks)
                    dxOK_Kwg13_ChineseBanks.Visible = True
                    DF_Kwg13_ChineseBanks.OK_btn.Visible = False
                    DF_Kwg13_ChineseBanks.LabelControl1.Visible = False
                    DF_Kwg13_ChineseBanks.LabelControl2.Visible = False
                    DF_Kwg13_ChineseBanks.DateEdit2.Visible = False

                    AddHandler dxOK_Kwg13_ChineseBanks.Click, AddressOf dxOK_Kwg13_ChineseBanks_click

                    DF_Kwg13_ChineseBanks.Show()
                    DF_Kwg13_ChineseBanks.Text = "Daily Art.13 KWG report creation for Chinese Banks"
                    DF_Kwg13_ChineseBanks.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_Kwg13_ChineseBanks.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily Art.13 KWG for None Chinese Banks report"
                    dxOK_Kwg13_NoneChineseBanks = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_Kwg13_NoneChineseBanks
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_Kwg13_NoneChineseBanks.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_Kwg13_NoneChineseBanks.Controls.Add(dxOK_Kwg13_NoneChineseBanks)
                    dxOK_Kwg13_NoneChineseBanks.Visible = True
                    DF_Kwg13_NoneChineseBanks.OK_btn.Visible = False
                    DF_Kwg13_NoneChineseBanks.LabelControl1.Visible = False
                    DF_Kwg13_NoneChineseBanks.LabelControl2.Visible = False
                    DF_Kwg13_NoneChineseBanks.DateEdit2.Visible = False

                    AddHandler dxOK_Kwg13_NoneChineseBanks.Click, AddressOf dxOK_Kwg13_NoneChineseBanks_click

                    DF_Kwg13_NoneChineseBanks.Show()
                    DF_Kwg13_NoneChineseBanks.Text = "Daily Art.13 KWG report creation for None Chinese Banks"
                    DF_Kwg13_NoneChineseBanks.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_Kwg13_NoneChineseBanks.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Daily Art.13 KWG for Central Goverment report"
                    dxOK_Kwg13_CentralGoverment = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_Kwg13_CentralGoverment
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_Kwg13_NoneChineseBanks.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_Kwg13_NoneChineseBanks.Controls.Add(dxOK_Kwg13_CentralGoverment)
                    dxOK_Kwg13_CentralGoverment.Visible = True
                    DF_Kwg13_NoneChineseBanks.OK_btn.Visible = False
                    DF_Kwg13_NoneChineseBanks.LabelControl1.Visible = False
                    DF_Kwg13_NoneChineseBanks.LabelControl2.Visible = False
                    DF_Kwg13_NoneChineseBanks.DateEdit2.Visible = False

                    AddHandler dxOK_Kwg13_CentralGoverment.Click, AddressOf dxOK_Kwg13_CentralGoverment_click

                    DF_Kwg13_NoneChineseBanks.Show()
                    DF_Kwg13_NoneChineseBanks.Text = "Daily Art.13 KWG report creation for None Chinese Banks"
                    DF_Kwg13_NoneChineseBanks.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_Kwg13_NoneChineseBanks.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Large Loan Exposure - Corporates"
                    dxOK_LargeLoanExposureCorporates = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_LargeLoanExposureCorporates
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_LargeLoanExposureCorporates.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_LargeLoanExposureCorporates.Controls.Add(dxOK_LargeLoanExposureCorporates)
                    dxOK_LargeLoanExposureCorporates.Visible = True
                    DF_LargeLoanExposureCorporates.OK_btn.Visible = False
                    DF_LargeLoanExposureCorporates.LabelControl1.Visible = False
                    DF_LargeLoanExposureCorporates.LabelControl2.Visible = False
                    DF_LargeLoanExposureCorporates.DateEdit2.Visible = False

                    AddHandler dxOK_LargeLoanExposureCorporates.Click, AddressOf dxOK_LargeLoanExposureCorporates_click

                    DF_LargeLoanExposureCorporates.Show()
                    DF_LargeLoanExposureCorporates.Text = "Large Loan Exposure - Corporates"
                    DF_LargeLoanExposureCorporates.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_LargeLoanExposureCorporates.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Traffic Lights System (Risk bearing Capacity)"
                    dxOK_TrafficLightsSystemRBC = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_TrafficLightsSystemRBC
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_TrafficLightsSystemRBC.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_TrafficLightsSystemRBC.Controls.Add(dxOK_TrafficLightsSystemRBC)
                    dxOK_TrafficLightsSystemRBC.Visible = True
                    DF_TrafficLightsSystemRBC.OK_btn.Visible = False
                    DF_TrafficLightsSystemRBC.LabelControl1.Visible = False
                    DF_TrafficLightsSystemRBC.LabelControl2.Visible = False
                    DF_TrafficLightsSystemRBC.DateEdit2.Visible = False

                    AddHandler dxOK_TrafficLightsSystemRBC.Click, AddressOf dxOK_TrafficLightsSystemRBC_click

                    DF_TrafficLightsSystemRBC.Show()
                    DF_TrafficLightsSystemRBC.Text = "Traffic Lights System (RBC)"
                    DF_TrafficLightsSystemRBC.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_TrafficLightsSystemRBC.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "LCR Overview"
                    dxOK_LCR_Overview = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_LCR_Overview
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_LCR_Overview.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_LCR_Overview.Controls.Add(dxOK_LCR_Overview)
                    dxOK_LCR_Overview.Visible = True
                    DF_LCR_Overview.OK_btn.Visible = False
                    DF_LCR_Overview.LabelControl1.Visible = False
                    DF_LCR_Overview.LabelControl2.Visible = False
                    DF_LCR_Overview.DateEdit2.Visible = False

                    AddHandler dxOK_LCR_Overview.Click, AddressOf dxOK_LCR_Overview_click

                    DF_LCR_Overview.Show()
                    DF_LCR_Overview.Text = "LCR Overview"
                    DF_LCR_Overview.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_LCR_Overview.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "CCB Vostro vs Nostro BuBa Balances"

                    dxOK_CCB_Vostro_Buba_Balances = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_CCB_Vostro_Buba_Balances
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ProfitLossReconcile.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_ProfitLossReconcile.Controls.Add(dxOK_CCB_Vostro_Buba_Balances)
                    DF_ProfitLossReconcile.OK_btn.Visible = False
                    dxOK_CCB_Vostro_Buba_Balances.Visible = True

                    AddHandler dxOK_CCB_Vostro_Buba_Balances.Click, AddressOf dxOK_CCB_Vostro_Buba_Balances_click

                    DF_ProfitLossReconcile.Show()
                    DF_ProfitLossReconcile.Text = "CCB Vostro Balances vs BuBa Nostro Balances"
                    DF_ProfitLossReconcile.Text_lbl.Text = "Please input the Period for Excel Sheet creation"
                    With DF_ProfitLossReconcile.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_ProfitLossReconcile.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With


                    '********************************************************************************************
                    '*************************ACCOUNTING REPORTS*************************************************
                    '********************************************************************************************
                Case Is = "FX Credit Equivalent Calculation"
                    dxOK_FxCreditEquivalent = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_FxCreditEquivalent
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_FxCreditEquivalent.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_FxCreditEquivalent.Controls.Add(dxOK_FxCreditEquivalent)
                    dxOK_FxCreditEquivalent.Visible = True
                    DF_FxCreditEquivalent.OK_btn.Visible = False
                    DF_FxCreditEquivalent.LabelControl1.Visible = False
                    DF_FxCreditEquivalent.LabelControl2.Visible = False
                    DF_FxCreditEquivalent.DateEdit2.Visible = False

                    AddHandler dxOK_FxCreditEquivalent.Click, AddressOf dxOK_FxCreditEquivalent_click

                    DF_FxCreditEquivalent.Show()
                    DF_FxCreditEquivalent.Text = "FX CREDIT EQUIVALENT REPORT CREATION"
                    DF_FxCreditEquivalent.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_FxCreditEquivalent.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Interest Rate Swap (IRS) Credit Equivalent Calculation"
                    dxOK_IrsCreditEquivalent = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_IrsCreditEquivalent
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_IrsCreditEquivalent.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_IrsCreditEquivalent.Controls.Add(dxOK_IrsCreditEquivalent)
                    dxOK_IrsCreditEquivalent.Visible = True
                    DF_IrsCreditEquivalent.OK_btn.Visible = False
                    DF_IrsCreditEquivalent.LabelControl1.Visible = False
                    DF_IrsCreditEquivalent.LabelControl2.Visible = False
                    DF_IrsCreditEquivalent.DateEdit2.Visible = False

                    AddHandler dxOK_IrsCreditEquivalent.Click, AddressOf dxOK_IrsCreditEquivalent_click

                    DF_IrsCreditEquivalent.Show()
                    DF_IrsCreditEquivalent.Text = "IRS CREDIT EQUIVALENT REPORT CREATION"
                    DF_IrsCreditEquivalent.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_IrsCreditEquivalent.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Time Deposit - Outstanding client Deals"
                    dxOK_TimeDepositOutDeals = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_TimeDepositOutDeals
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_TimeDepositOutstandingClientDeals.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_TimeDepositOutstandingClientDeals.Controls.Add(dxOK_TimeDepositOutDeals)
                    dxOK_TimeDepositOutDeals.Visible = True
                    DF_TimeDepositOutstandingClientDeals.OK_btn.Visible = False
                    DF_TimeDepositOutstandingClientDeals.LabelControl1.Visible = False
                    DF_TimeDepositOutstandingClientDeals.LabelControl2.Visible = False
                    DF_TimeDepositOutstandingClientDeals.DateEdit2.Visible = False

                    AddHandler dxOK_TimeDepositOutDeals.Click, AddressOf dxOK_TimeDepositOutDeals_click

                    DF_TimeDepositOutstandingClientDeals.Show()
                    DF_TimeDepositOutstandingClientDeals.Text = "TIME DEPOSIT OUTSTANDING CLIENT DEALS REPORT CREATION"
                    DF_TimeDepositOutstandingClientDeals.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_TimeDepositOutstandingClientDeals.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With



                Case Is = "Kapitalertragsteuer-Money Market Kunden-Monatlich"
                    If KundenZinsenOhnePlzBundesland = 0 Then
                        If KundenZinsenPLZ_EAEG = 0 Then

                            dxOK_KapiStMMkundenMonat = New DevExpress.XtraEditors.SimpleButton
                            With dxOK_KapiStMMkundenMonat
                                .Text = "OK"
                                .Height = 23
                                .Width = 75
                                .Location = New System.Drawing.Point(19, 203)
                                .ImageList = DF_KapiSteuerMMKundenMonat.ImageCollection1
                                .ImageIndex = 5
                            End With

                            DF_KapiSteuerMMKundenMonat.Controls.Add(dxOK_KapiStMMkundenMonat)
                            dxOK_KapiStMMkundenMonat.Visible = True
                            DF_KapiSteuerMMKundenMonat.OK_btn.Visible = False
                            DF_KapiSteuerMMKundenMonat.LabelControl1.Visible = True
                            DF_KapiSteuerMMKundenMonat.LabelControl2.Visible = False
                            DF_KapiSteuerMMKundenMonat.LabelControl3.Visible = False
                            DF_KapiSteuerMMKundenMonat.ComboBoxEdit2.Visible = False
                            DF_KapiSteuerMMKundenMonat.ComboBoxEdit3.Visible = False

                            AddHandler dxOK_KapiStMMkundenMonat.Click, AddressOf dxOK_KapiStMMkundenMonat_click

                            DF_KapiSteuerMMKundenMonat.Show()
                            DF_KapiSteuerMMKundenMonat.Text = "KAPITALERTRAGSTEUER-BESCHEINIGUNG für MM KUNDEN-Monatlich"
                            DF_KapiSteuerMMKundenMonat.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Bescheinigung"

                            QueryText = "select distinct([IdZinsertragsMonat]) from [ZINSERTRAG KDDETAIL] "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                DF_KapiSteuerMMKundenMonat.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                            Next
                            DF_KapiSteuerMMKundenMonat.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
                        Else
                            XtraMessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        XtraMessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If


                Case Is = "Alle Kunden - Jährlich"
                    If KundenZinsenOhnePlzBundesland = 0 Then
                        If KundenZinsenPLZ_EAEG = 0 Then

                            dxOK_KapiStKundenAlleJahr = New DevExpress.XtraEditors.SimpleButton
                            With dxOK_KapiStKundenAlleJahr
                                .Text = "OK"
                                .Height = 23
                                .Width = 75
                                .Location = New System.Drawing.Point(19, 203)
                                .ImageList = DF_KapiSteuerKundeAlle.ImageCollection1
                                .ImageIndex = 5
                            End With

                            DF_KapiSteuerKundeAlle.Controls.Add(dxOK_KapiStKundenAlleJahr)
                            dxOK_KapiStKundenAlleJahr.Visible = True
                            DF_KapiSteuerKundeAlle.OK_btn.Visible = False
                            DF_KapiSteuerKundeAlle.LabelControl1.Visible = True
                            DF_KapiSteuerKundeAlle.LabelControl2.Visible = True
                            DF_KapiSteuerKundeAlle.LabelControl3.Visible = False
                            DF_KapiSteuerKundeAlle.ComboBoxEdit2.Visible = True
                            DF_KapiSteuerKundeAlle.ComboBoxEdit3.Visible = False

                            AddHandler dxOK_KapiStKundenAlleJahr.Click, AddressOf dxOK_KapiStKundenAlleJahr_click

                            DF_KapiSteuerKundeAlle.Show()
                            DF_KapiSteuerKundeAlle.Text = "STEUERBESCHEINIGUNG für alle Kunden-Jährlich"
                            DF_KapiSteuerKundeAlle.LabelControl1.Text = "Bitte wählen Sie das Zinsertragsjahr für die Bescheinigung"
                            DF_KapiSteuerKundeAlle.LabelControl2.Text = "Sollen die Zeilen der Anlage KAP auch ausgedruckt werden"

                            QueryText = "select distinct([IdErtragJahr]) from [ZINSERTRAG KDDETAIL] ORDER BY [IdErtragJahr] desc  "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                DF_KapiSteuerKundeAlle.ComboBoxEdit1.Properties.Items.Add(row("IdErtragJahr"))
                            Next
                            DF_KapiSteuerKundeAlle.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdErtragJahr")

                            With DF_KapiSteuerKundeAlle.ComboBoxEdit2
                                .Properties.Items.Add("NEIN")
                                .Properties.Items.Add("JA")
                                .Text = "NEIN"
                            End With
                        Else
                            XtraMessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        XtraMessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Case Is = "Einzelner Kunde - Jährlich"
                    If KundenZinsenOhnePlzBundesland = 0 Then
                        If KundenZinsenPLZ_EAEG = 0 Then

                            dxOK_KapiStKundenEinzelnJahr = New DevExpress.XtraEditors.SimpleButton
                            With dxOK_KapiStKundenEinzelnJahr
                                .Text = "OK"
                                .Height = 23
                                .Width = 75
                                .Location = New System.Drawing.Point(19, 203)
                                .ImageList = DF_KapiSteuerKundeEinzeln.ImageCollection1
                                .ImageIndex = 5
                            End With

                            DF_KapiSteuerKundeEinzeln.Controls.Add(dxOK_KapiStKundenEinzelnJahr)
                            dxOK_KapiStKundenEinzelnJahr.Visible = True
                            DF_KapiSteuerKundeEinzeln.OK_btn.Visible = False
                            DF_KapiSteuerKundeEinzeln.LabelControl1.Visible = True
                            DF_KapiSteuerKundeEinzeln.LabelControl2.Visible = True
                            DF_KapiSteuerKundeEinzeln.LabelControl3.Visible = True
                            DF_KapiSteuerKundeEinzeln.ComboBoxEdit2.Visible = True
                            DF_KapiSteuerKundeEinzeln.ComboBoxEdit3.Visible = True

                            AddHandler dxOK_KapiStKundenEinzelnJahr.Click, AddressOf dxOK_KapiStKundenEinzelnJahr_click

                            DF_KapiSteuerKundeEinzeln.Show()
                            DF_KapiSteuerKundeEinzeln.Text = "STEUERBESCHEINIGUNG für einzelnen Kunden-Jährlich"
                            DF_KapiSteuerKundeEinzeln.LabelControl1.Text = "Bitte wählen Sie das Zinsertragsjahr für die Bescheinigung"
                            DF_KapiSteuerKundeEinzeln.LabelControl2.Text = "Bitte wählen Sie die Stamm Nr. des Kunden"
                            DF_KapiSteuerKundeEinzeln.LabelControl3.Text = "Sollen die Zeilen der Anlage KAP auch ausgedruckt werden"

                            QueryText = "select distinct([IdErtragJahr]) from [ZINSERTRAG KDDETAIL] ORDER BY [IdErtragJahr] desc  "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                DF_KapiSteuerKundeEinzeln.ComboBoxEdit1.Properties.Items.Add(row("IdErtragJahr"))
                            Next
                            DF_KapiSteuerKundeEinzeln.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdErtragJahr")

                            QueryText = "select distinct([IdKDSTAMM]),[CustomerName] from [ZINSERTRAG KDDETAIL] where [KAPISTPFLICHTIG]='Y'"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                DF_KapiSteuerKundeEinzeln.ComboBoxEdit2.Properties.Items.Add(row("IdKDSTAMM") & "  " & row("CustomerName"))
                            Next
                            DF_KapiSteuerKundeEinzeln.ComboBoxEdit2.Text = dt.Rows.Item(0).Item("IdKDSTAMM") & "  " & dt.Rows.Item(0).Item("CustomerName")

                            With DF_KapiSteuerKundeEinzeln.ComboBoxEdit3
                                .Properties.Items.Add("NEIN")
                                .Properties.Items.Add("JA")
                                .Text = "NEIN"
                            End With
                        Else
                            XtraMessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        XtraMessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If




                Case Is = "Balance Sheet Reconciliation"
                    dxOK_BalanceSheetReconciliation = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_BalanceSheetReconciliation
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_BalanceSheetReconciliation.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_BalanceSheetReconciliation.Controls.Add(dxOK_BalanceSheetReconciliation)
                    dxOK_BalanceSheetReconciliation.Visible = True
                    DF_BalanceSheetReconciliation.OK_btn.Visible = False

                    AddHandler dxOK_BalanceSheetReconciliation.Click, AddressOf dxOK_BalanceSheetReconciliation_click

                    DF_BalanceSheetReconciliation.Show()
                    DF_BalanceSheetReconciliation.Text = "BALANCE SHEET RECONCILIATION"
                    DF_BalanceSheetReconciliation.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_BalanceSheetReconciliation.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -2, Today)
                    End With
                    With DF_BalanceSheetReconciliation.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Balance Sheet Reconciliation"
                    dxOK_BalanceSheetReconciliation = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_BalanceSheetReconciliation
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_BalanceSheetReconciliation.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_BalanceSheetReconciliation.Controls.Add(dxOK_BalanceSheetReconciliation)
                    dxOK_BalanceSheetReconciliation.Visible = True
                    DF_BalanceSheetReconciliation.OK_btn.Visible = False

                    AddHandler dxOK_BalanceSheetReconciliation.Click, AddressOf dxOK_BalanceSheetReconciliation_click

                    DF_BalanceSheetReconciliation.Show()
                    DF_BalanceSheetReconciliation.Text = "BALANCE SHEET RECONCILIATION"
                    DF_BalanceSheetReconciliation.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_BalanceSheetReconciliation.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -2, Today)
                    End With
                    With DF_BalanceSheetReconciliation.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Profit and Loss Sheet Reconciliation"
                    dxOK_ProfitLossReconciliation = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_ProfitLossReconciliation
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ProfitLossReconcile.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_ProfitLossReconcile.Controls.Add(dxOK_ProfitLossReconciliation)
                    dxOK_ProfitLossReconciliation.Visible = True
                    DF_ProfitLossReconcile.OK_btn.Visible = False

                    AddHandler dxOK_ProfitLossReconciliation.Click, AddressOf dxOK_ProfitLossReconciliation_click

                    DF_ProfitLossReconcile.Show()
                    DF_ProfitLossReconcile.Text = "PROFIT and LOSS RECONCILIATION"
                    DF_ProfitLossReconcile.Text_lbl.Text = "Please input the Period for report creation"
                    With DF_ProfitLossReconcile.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -2, Today)
                    End With
                    With DF_ProfitLossReconcile.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "Profit/Loss Excel Sheet(IDW and Bundesbank Interests)"
                    dxOK_ProfitLossExcelIDW = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_ProfitLossExcelIDW
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ProfitLossReconcile.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_ProfitLossReconcile.Controls.Add(dxOK_ProfitLossExcelIDW)
                    dxOK_ProfitLossExcelIDW.Visible = True
                    DF_ProfitLossReconcile.OK_btn.Visible = False

                    AddHandler dxOK_ProfitLossExcelIDW.Click, AddressOf dxOK_ProfitLossExcelIDW_click

                    DF_ProfitLossReconcile.Show()
                    DF_ProfitLossReconcile.Text = "PROFIT/LOSS Excel Sheet (IDW and Bundesbank Interests)"
                    DF_ProfitLossReconcile.Text_lbl.Text = "Please input the Period for Excel Sheet creation"
                    With DF_ProfitLossReconcile.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -2, Today)
                    End With
                    With DF_ProfitLossReconcile.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With



                    '********************************************************************************************
                    '*************************FOREIGN REPORTS*************************************************
                    '********************************************************************************************
                Case Is = "Monthly Export Letter of Credits"
                    dxOK_ExportLCmonthlyStatistic = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_ExportLCmonthlyStatistic
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ExportLCMonthlyStatistic.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_ExportLCMonthlyStatistic.Controls.Add(dxOK_ExportLCmonthlyStatistic)
                    dxOK_ExportLCmonthlyStatistic.Visible = True
                    DF_ExportLCMonthlyStatistic.OK_btn.Visible = False
                    DF_ExportLCMonthlyStatistic.LabelControl1.Visible = False
                    DF_ExportLCMonthlyStatistic.LabelControl2.Visible = False
                    DF_ExportLCMonthlyStatistic.DateEdit2.Visible = False

                    AddHandler dxOK_ExportLCmonthlyStatistic.Click, AddressOf dxOK_ExportLCmonthlyStatistic_click

                    DF_ExportLCMonthlyStatistic.Show()
                    DF_ExportLCMonthlyStatistic.Text = "EXPORT LC - MONTHLY STATISTIC REPORT CREATION"
                    DF_ExportLCMonthlyStatistic.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_ExportLCMonthlyStatistic.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "MM.yyyy"
                        .Properties.EditFormat.FormatString = "MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With


                    '********************************************************************************************
                    '*************************MELDEWESEN*************************************************
                    '********************************************************************************************
                Case Is = "AWV Z4"
                    dxOK_AWVz4 = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_AWVz4
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_AWVz4.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_AWVz4.Controls.Add(dxOK_AWVz4)
                    dxOK_AWVz4.Visible = True
                    DF_AWVz4.OK_btn.Visible = False
                    DF_AWVz4.LabelControl1.Visible = False
                    DF_AWVz4.LabelControl2.Visible = False
                    DF_AWVz4.DateEdit2.Visible = False

                    AddHandler dxOK_AWVz4.Click, AddressOf dxOK_AWVz4_click

                    DF_AWVz4.Show()
                    DF_AWVz4.Text = "MONTHLY AWV Z4 REPORT CREATION"
                    DF_AWVz4.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_AWVz4.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "MM.yyyy"
                        .Properties.EditFormat.FormatString = "MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("MM.yyyy")
                        .EditValue = Today
                    End With

                Case Is = "AWV Z10"
                    dxOK_AWVz10 = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_AWVz10
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_AWVz10.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_AWVz10.Controls.Add(dxOK_AWVz10)
                    dxOK_AWVz10.Visible = True
                    DF_AWVz10.OK_btn.Visible = False
                    DF_AWVz10.LabelControl1.Visible = False
                    DF_AWVz10.LabelControl2.Visible = False
                    DF_AWVz10.DateEdit2.Visible = False

                    AddHandler dxOK_AWVz10.Click, AddressOf dxOK_AWVz10_click

                    DF_AWVz10.Show()
                    DF_AWVz10.Text = "MONTHLY AWV Z10 REPORT CREATION"
                    DF_AWVz10.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_AWVz10.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "MM.yyyy"
                        .Properties.EditFormat.FormatString = "MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("MM.yyyy")
                        .EditValue = Today
                    End With

                Case Is = "AWV Z11"
                    dxOK_AWVz11 = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_AWVz11
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_AWVz11.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_AWVz11.Controls.Add(dxOK_AWVz11)
                    dxOK_AWVz11.Visible = True
                    DF_AWVz11.OK_btn.Visible = False
                    DF_AWVz11.LabelControl1.Visible = False
                    DF_AWVz11.LabelControl2.Visible = False
                    DF_AWVz11.DateEdit2.Visible = False

                    AddHandler dxOK_AWVz11.Click, AddressOf dxOK_AWVz11_click

                    DF_AWVz11.Show()
                    DF_AWVz11.Text = "MONTHLY AWV Z11 REPORT CREATION"
                    DF_AWVz11.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_AWVz11.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "MM.yyyy"
                        .Properties.EditFormat.FormatString = "MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("MM.yyyy")
                        .EditValue = Today
                    End With

                Case Is = "AWV Z14-Z15"
                    dxOK_AWVz14z15 = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_AWVz14z15
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_AWVz14z15.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DF_AWVz14z15.Controls.Add(dxOK_AWVz14z15)
                    dxOK_AWVz14z15.Visible = True
                    DF_AWVz14z15.OK_btn.Visible = False
                    DF_AWVz14z15.LabelControl1.Visible = False
                    DF_AWVz14z15.LabelControl2.Visible = False
                    DF_AWVz14z15.DateEdit2.Visible = False

                    AddHandler dxOK_AWVz14z15.Click, AddressOf dxOK_AWVz14z15_click

                    DF_AWVz14z15.Show()
                    DF_AWVz14z15.Text = "MONTHLY AWV Z14-Z15 REPORT CREATION"
                    DF_AWVz14z15.Text_lbl.Text = "Please input the Date for the report creation"
                    With DF_AWVz14z15.DateEdit1
                        .Location = New Point(122, 74)
                        .Properties.EditMask = "MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "MM.yyyy"
                        .Properties.EditFormat.FormatString = "MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("MM.yyyy")
                        .EditValue = Today
                    End With

                Case Is = "Monatliche Kapitaletragsteuer (Details)"
                    If KundenZinsenOhnePlzBundesland = 0 Then
                        If KundenZinsenPLZ_EAEG = 0 Then

                            dxOK_KAPIMLD_REP = New DevExpress.XtraEditors.SimpleButton
                            With dxOK_KAPIMLD_REP
                                .Text = "OK"
                                .Height = 23
                                .Width = 75
                                .Location = New System.Drawing.Point(19, 203)
                                .ImageList = DF_KapiSoliMonatDetails.ImageCollection1
                                .ImageIndex = 5
                            End With

                            DF_KapiSoliMonatDetails.Controls.Add(dxOK_KAPIMLD_REP)
                            dxOK_KAPIMLD_REP.Visible = True
                            DF_KapiSoliMonatDetails.OK_btn.Visible = False
                            DF_KapiSoliMonatDetails.LabelControl1.Visible = True
                            DF_KapiSoliMonatDetails.LabelControl2.Visible = False
                            DF_KapiSoliMonatDetails.LabelControl3.Visible = False
                            DF_KapiSoliMonatDetails.ComboBoxEdit2.Visible = False
                            DF_KapiSoliMonatDetails.ComboBoxEdit3.Visible = False

                            AddHandler dxOK_KAPIMLD_REP.Click, AddressOf dxOK_KAPIMLD_REP_click

                            DF_KapiSoliMonatDetails.Show()
                            DF_KapiSoliMonatDetails.Text = "MONATLICHE KAPITALERTRAGSTEUER/SOLI DETAILS"
                            DF_KapiSoliMonatDetails.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Meldung"


                            'QueryText = "SELECT a.[IdZinsertragsMonat],a.[ValDate] FROM [ZINSERTRAG KUNDEN DETAILS] a JOIN (SELECT [IdZinsertragsMonat], min(ID) as id FROM [ZINSERTRAG KUNDEN DETAILS] GROUP BY [IdZinsertragsMonat]) b ON ( a.id = b.id ) GROUP BY a.[IdZinsertragsMonat],a.[ValDate] order by a.[ValDate] desc"
                            QueryText = "SELECT Zinsertragsmonat FROM [ZINSERTRAG KUNDEN MONAT] order by ZinsertragsmonatDATE desc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                'DF_KapiSoliMonatDetails.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                                DF_KapiSoliMonatDetails.ComboBoxEdit1.Properties.Items.Add(row("ZinsertragsMonat"))
                            Next
                            'DF_KapiSoliMonatDetails.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
                            DF_KapiSoliMonatDetails.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("ZinsertragsMonat")
                        Else
                            XtraMessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        XtraMessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Case Is = "Monatliche Kapitalertragsteuer Meldung an Finanzamt"
                    If KundenZinsenOhnePlzBundesland = 0 Then
                        If KundenZinsenPLZ_EAEG = 0 Then

                            dxOK_KAPIMLD = New DevExpress.XtraEditors.SimpleButton
                            With dxOK_KAPIMLD
                                .Text = "OK"
                                .Height = 23
                                .Width = 75
                                .Location = New System.Drawing.Point(19, 203)
                                .ImageList = DF_KapiSoliMonatMeldung.ImageCollection1
                                .ImageIndex = 5
                            End With

                            DF_KapiSoliMonatMeldung.Controls.Add(dxOK_KAPIMLD)
                            dxOK_KAPIMLD.Visible = True
                            DF_KapiSoliMonatMeldung.OK_btn.Visible = False
                            DF_KapiSoliMonatMeldung.LabelControl1.Visible = True
                            DF_KapiSoliMonatMeldung.LabelControl2.Visible = False
                            DF_KapiSoliMonatMeldung.LabelControl3.Visible = False
                            DF_KapiSoliMonatMeldung.ComboBoxEdit2.Visible = False
                            DF_KapiSoliMonatMeldung.ComboBoxEdit3.Visible = False

                            AddHandler dxOK_KAPIMLD.Click, AddressOf dxOK_KAPIMLD_click

                            DF_KapiSoliMonatMeldung.Show()
                            DF_KapiSoliMonatMeldung.Text = "MONATLICHE KAPITALERTRAGSTEUERANMELDUNG AN DAS FINANZAMT"
                            DF_KapiSoliMonatMeldung.LabelControl1.Text = "Bitte wählen Sie den Zinsertragsmonat für die Meldung"


                            'QueryText = "SELECT a.[IdZinsertragsMonat],a.[ValDate] FROM [ZINSERTRAG KUNDEN DETAILS] a JOIN (SELECT [IdZinsertragsMonat], min(ID) as id FROM [ZINSERTRAG KUNDEN DETAILS] GROUP BY [IdZinsertragsMonat]) b ON ( a.id = b.id ) GROUP BY a.[IdZinsertragsMonat],a.[ValDate] order by a.[ValDate] desc"
                            QueryText = "SELECT Zinsertragsmonat FROM [ZINSERTRAG KUNDEN MONAT] order by ZinsertragsmonatDATE desc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For Each row As DataRow In dt.Rows
                                'DF_KapiSoliMonatMeldung.ComboBoxEdit1.Properties.Items.Add(row("IdZinsertragsMonat"))
                                DF_KapiSoliMonatMeldung.ComboBoxEdit1.Properties.Items.Add(row("ZinsertragsMonat"))
                            Next
                            'DF_KapiSoliMonatMeldung.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("IdZinsertragsMonat")
                            DF_KapiSoliMonatMeldung.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("ZinsertragsMonat")
                        Else
                            XtraMessageBox.Show("Es sind " & KundenZinsenPLZ_EAEG & " Kunden mit unterschiedlicher PLZ in KUNDEN-STEUERBESCHEINIGUNGEN und EAEG Stammdaten" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten in KUNDEN-STEUERBESCHEINIGUNGEN!", "WIDERSPRÜCHLIGE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        XtraMessageBox.Show("Es sind " & KundenZinsenOhnePlzBundesland & " Kunden  ohne PLZ und/oder BUNDESLAND in der Tabelle KUNDEN-STEUERBESCHEINIGUNGEN" & vbNewLine & "Bitte ergänzen Sie die fehlenden Daten!", "FEHLENDE ANGABEN", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Case Is = "Average of Employees"

                    dxOK_EMPL_AVG = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_EMPL_AVG
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(19, 203)
                        .ImageList = DATESFORM_EMPL_AVG.ImageCollection1
                        .ImageIndex = 5
                    End With

                    DATESFORM_EMPL_AVG.Controls.Add(dxOK_EMPL_AVG)
                    dxOK_EMPL_AVG.Visible = True
                    DATESFORM_EMPL_AVG.OK_btn.Visible = False
                    DATESFORM_EMPL_AVG.LabelControl1.Visible = True
                    DATESFORM_EMPL_AVG.LabelControl2.Visible = False
                    DATESFORM_EMPL_AVG.LabelControl3.Visible = False
                    DATESFORM_EMPL_AVG.ComboBoxEdit2.Visible = False
                    DATESFORM_EMPL_AVG.ComboBoxEdit3.Visible = False

                    AddHandler dxOK_EMPL_AVG.Click, AddressOf dxOK_EMPL_AVG_click

                    DATESFORM_EMPL_AVG.Show()
                    DATESFORM_EMPL_AVG.Text = "Erstellung des Durchschnittlichen Mitarbeiterstandes"
                    DATESFORM_EMPL_AVG.LabelControl1.Text = "Bitte wählen Sie das Jahr aus für den Report"

                    QueryText = "select [JahrLfd] from [EMPLOYES YEAR AVERAGE] ORDER BY [JahrLfd] desc "
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For Each row As DataRow In dt.Rows
                        DATESFORM_EMPL_AVG.ComboBoxEdit1.Properties.Items.Add(row("JahrLfd"))
                    Next
                    DATESFORM_EMPL_AVG.ComboBoxEdit1.Text = dt.Rows.Item(0).Item("JahrLfd")



                    '********************************************************************************************
                    '*************************CLEARING*************************************************
                    '********************************************************************************************
                Case Is = "Vostro Accounts Transaction Fees"

                    dxOK_VostroAccountsTransactionFees = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_VostroAccountsTransactionFees
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ProfitLossReconcile.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_ProfitLossReconcile.Controls.Add(dxOK_VostroAccountsTransactionFees)
                    DF_ProfitLossReconcile.OK_btn.Visible = False
                    dxOK_VostroAccountsTransactionFees.Visible = True

                    AddHandler dxOK_VostroAccountsTransactionFees.Click, AddressOf dxOK_VostroAccountsTransactionFees_click

                    DF_ProfitLossReconcile.Show()
                    DF_ProfitLossReconcile.Text = "Vostro Accounts Transaction Fees"
                    DF_ProfitLossReconcile.Text_lbl.Text = "Please input the Period for Excel Sheet creation"
                    With DF_ProfitLossReconcile.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_ProfitLossReconcile.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

                Case Is = "ZVDL Report"

                    dxOK_ZVDL_Report = New DevExpress.XtraEditors.SimpleButton
                    With dxOK_ZVDL_Report
                        .Text = "OK"
                        .Height = 23
                        .Width = 75
                        .Location = New System.Drawing.Point(29, 134)
                        .ImageList = DF_ProfitLossReconcile.ImageCollection1
                        .ImageIndex = 5
                    End With
                    DF_ProfitLossReconcile.Controls.Add(dxOK_ZVDL_Report)
                    DF_ProfitLossReconcile.OK_btn.Visible = False
                    dxOK_ZVDL_Report.Visible = True

                    AddHandler dxOK_ZVDL_Report.Click, AddressOf dxOK_ZVDL_Report_click

                    DF_ProfitLossReconcile.Show()
                    DF_ProfitLossReconcile.Text = "ZVDL Report"
                    DF_ProfitLossReconcile.Text_lbl.Text = "Please input the Period for Excel Sheet creation"
                    With DF_ProfitLossReconcile.DateEdit1
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With
                    With DF_ProfitLossReconcile.DateEdit2
                        .Properties.EditMask = "dd.MM.yyyy"
                        .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
                        .Properties.EditFormat.FormatString = "dd.MM.yyyy"
                        .Properties.Appearance.Options.UseTextOptions = True
                        .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        .Text = Today.ToString("dd.MM.yyyy")
                        .EditValue = DateAdd(DateInterval.Day, -1, Today)
                    End With

            End Select
        End If
    End Sub


    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If TypeOf e.SelectedControl Is DevExpress.XtraTreeList.TreeList Then

            Dim tree As TreeList = CType(e.SelectedControl, TreeList)

            Dim hit As TreeListHitInfo = tree.CalcHitInfo(e.ControlMousePosition)

            If hit.HitInfoType = HitInfoType.Cell Then

                Dim NodeText As String = hit.Node.GetDisplayText(0)

                If NodeText = "Test12" Then
                    Dim cellInfo As Object = New TreeListCellToolTipInfo(hit.Node, hit.Column, Nothing)

                    Dim toolTip As String = "This is the Test 12"

                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip)
                Else

                    Dim cellInfo As Object = New TreeListCellToolTipInfo(hit.Node, hit.Column, Nothing)

                    Dim toolTip As String = String.Format("{0} (Column: {1}, Node ID: {2})", hit.Node(hit.Column), hit.Column.Caption, hit.Node.Id)

                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip)
                End If

            End If

        End If
    End Sub

#End Region

#Region "REPORTS CREATION FROM TREELIST"
#Region "RISK CONTROLLING TREELIST"
    'Risk Controlling
    Private Sub dxOK_IRRD_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '+++++++++OLD CODE+++++++++
        'Dim d As Date = DF_IRR_daily.DateEdit1.Text
        'DF_IRR_daily.Close()
        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk report for " & d)
        'Dim f As New InterestRateRisk
        'f.RATERISK_DETAILSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DETAILS, d)
        'f.RATERISK_DELETIONSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DELETIONS, d)
        'f.RATERISK_TOTALSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_TOTALS, d)
        'f.RATERISK_DATETableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DATE, d)
        'Dim CrRep As New ReportDocument
        'CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP.rpt")
        'CrRep.SetDataSource(f.RiskControllingDataSet)
        'Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        'Dim myParams As ParameterField = New ParameterField
        'myValue.Value = d
        'myParams.ParameterFieldName = "IDNR"
        'myParams.CurrentValues.Add(myValue)
        'Dim c As New CrystalReportsForm
        'c.MdiParent = Me
        'c.Show()
        'c.WindowState = FormWindowState.Maximized
        'c.Text = "Interest Rate risk report from " & d
        'c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        'c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        'c.CrystalReportViewer1.ReportSource = CrRep
        'c.CrystalReportViewer1.ShowParameterPanelButton = False
        'c.CrystalReportViewer1.ShowRefreshButton = False
        'c.CrystalReportViewer1.ShowGroupTreeButton = False
        'c.CrystalReportViewer1.Zoom(85)
        'SplashScreenManager.CloseForm(False)
        '**************************************************************
        Dim d As Date = DF_IRR_daily.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        'dxOK_IRRD.Visible = False
        dxOK_IRRD.Dispose()

        'DF_IRR_daily.Controls.Remove(dxOK_IRRD)
        DF_IRR_daily.Close()
        If d <= DateSerial(2018, 12, 30) Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk report for " & d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP.rpt")

            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)

            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Interest Rate risk report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            SetReportDb(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString, c.CrystalReportViewer1, CrRep)
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2018, 12, 30) Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk report for " & d)
            Dim IRR_DATE_Da As New SqlDataAdapter("Select * from [RATERISK DATE] where RateRiskDate='" & dsql & "' ", conn)
            Dim IRR_TOTALS_Da As New SqlDataAdapter("Select * from [RATERISK TOTALS] where [RISK DATE]='" & dsql & "' and [CalculationMethod]=3", conn)
            Dim IRR_DELETIONS_Da As New SqlDataAdapter("Select * from [RATERISK DELETIONS] where [RISK DATE]='" & dsql & "'", conn)
            Dim IRR_Dataset As New DataSet("IRR")
            IRR_DATE_Da.Fill(IRR_Dataset, "RATERISK DATE")
            IRR_TOTALS_Da.Fill(IRR_Dataset, "RATERISK TOTALS")
            IRR_DELETIONS_Da.Fill(IRR_Dataset, "RATERISK DELETIONS")

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP_Zinsschoks200bps.rpt")
            CrRep.SetDataSource(IRR_Dataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Interest Rate Risk report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub dxOK_IRRDC_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_IRR_dailyChart.DateEdit1.Text
        Dim d2 As Date = DF_IRR_dailyChart.DateEdit2.Text
        dxOK_IRRDC.Dispose()
        DF_IRR_dailyChart.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Interest rate risk chart from " & d1 & " till " & d2)

        Dim f As New InterestRateRisk
        f.RATERISK_DATETableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.RATERISK_DATE, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_REP_CHART.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FROM"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "TILL"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Interest rate risk chart report from " & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_IRRD_RB_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_IRR_RB_daily.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_IRRD_RB.Dispose()

        DF_IRR_RB_daily.Close()
        If d <= DateSerial(2018, 12, 30) Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk amount (RISK BEARING CAPACITY) report for " & d)
            Dim f As New InterestRateRisk
            f.RATERISK_DETAILSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DETAILS, d)
            f.RATERISK_DELETIONSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DELETIONS, d)
            f.RATERISK_TOTALSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_TOTALS, d)
            f.RATERISK_DATETableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DATE, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_BC_REP.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Interest Rate risk Amount (RISK BEARING CAPACITY) report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2018, 12, 30) Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk amount (RISK BEARING CAPACITY) report for " & d)
            Dim IRR_DATE_Da As New SqlDataAdapter("Select * from [RATERISK DATE] where RateRiskDate='" & dsql & "' ", conn)
            Dim IRR_TOTALS_Da As New SqlDataAdapter("Select * from [RATERISK TOTALS] where [RISK DATE]='" & dsql & "' and [CalculationMethod]=2", conn)
            Dim IRR_Dataset As New DataSet("IRR")
            IRR_DATE_Da.Fill(IRR_Dataset, "RATERISK DATE")
            IRR_TOTALS_Da.Fill(IRR_Dataset, "RATERISK TOTALS")
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_BC_REP_Calc2.rpt")
            CrRep.SetDataSource(IRR_Dataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "IDNR"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Interest Rate risk Amount (RISK BEARING CAPACITY) report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub dxOK_IRRD_HUMP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_IRR_HUMP_daily.DateEdit1.Text
        dxOK_IRRD_HUMP.Dispose()

        DF_IRR_HUMP_daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk report HUMP-TWIST1-TWIST2 for " & d)
        Dim f As New InterestRateRisk
        f.RATERISK_DETAILSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DETAILS, d)
        f.RATERISK_DELETIONSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DELETIONS, d)
        f.RATERISK_TOTALSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_TOTALS, d)
        f.RATERISK_DATETableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DATE, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_HUMP_REP.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "IDNR"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Interest Rate risk Amount report HUMP-TWIST1-TWIST2 from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_IRR_ZinsbindungChart_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_IRR_ZinsbindungChart.DateEdit1.Text
        dxOK_IRR_ZinsbindungChart.Dispose()
        DF_IRR_ZinsbindungChart.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk Zinsbindungs Chart report for " & d)
        Dim f As New InterestRateRisk
        f.RATERISK_TOTALSTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_TOTALS, d)
        f.RATERISK_DATETableAdapter.FillByRiskDate(f.RiskControllingDataSet.RATERISK_DATE, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\INT_RATE_RISK_ZINSBINDUNGS_CHART.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "IDNR"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Interest Rate risk Zinsbindungs Chart report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub


    Private Sub dxOK_IRR_NetRecon_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_IRR_NetPos_Reconcile.DateEdit1.Text
        Dim d2 As Date = DF_IRR_NetPos_Reconcile.DateEdit2.Text
        dxOK_IRR_NetRecon.Dispose()

        DF_IRR_NetPos_Reconcile.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Interest Rate risk net positions reconciliation between " & d1 & " and " & d2)

        Dim f As New InterestRateRisk
        f.RATERISK_DATETableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.RATERISK_DATE, d1, d2)
        f.RATERISK_TOTALSTableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.RATERISK_TOTALS, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\RATE_RISK_NET_POSITIONS_RECONCILE.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Interest Rate risk net positions reconciliation between " & d1 & " and " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_DailyRiskTable_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_RiskTables_Daily.DateEdit1.Text
        dxOK_DailyRiskTable.Dispose()

        DF_RiskTables_Daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Daily Risk Tables for " & d)
        Dim f As New CreditRiskMak
        f.INDUSTRY_VALUESTableAdapter.Fill(f.RiskControllingDataSet.INDUSTRY_VALUES)
        f.COUNTRIESTableAdapter.Fill(f.RiskControllingDataSet.COUNTRIES)
        f.ContractTypeTableAdapter.Fill(f.RiskControllingDataSet.ContractType)
        f.MAK_REPORTTableAdapter.FillByMakDate(f.RiskControllingDataSet.MAK_REPORT, d)
        f.CREDIT_RISKTableAdapter.FillByCreditRiskDate(f.RiskControllingDataSet.CREDIT_RISK, d)
        f.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(f.RiskControllingDataSet.MAK_CR_TOTALS, d)
        f.MAK_ALLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.MAK_ALL, d)
        f.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(f.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY_RISK_TABLES.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily Risk Tables from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_LoansStructure_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_LoansStructure_daily.DateEdit1.Text
        dxOK_LoansStructure.Dispose()
        DF_LoansStructure_daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Loan Structure Tables for " & d)
        Dim f As New CreditRiskMak
        'f.MAK_REPORTTableAdapter.FillByMakDate(f.RiskControllingDataSet.MAK_REPORT, d)
        'f.CREDIT_RISKTableAdapter.FillByCreditRiskDate(f.RiskControllingDataSet.CREDIT_RISK, d)
        f.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(f.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
        f.MAK_ALLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.MAK_ALL, d)
        f.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(f.RiskControllingDataSet.MAK_CR_TOTALS, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\LOAN STRUCTURE TABLE.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Loan Structure Table for " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_RiskLimitDailyControl_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_RiskLimitDailyControl.DateEdit1.Text
        Dim d2 As Date = DF_RiskLimitDailyControl.DateEdit2.Text
        dxOK_RiskLimitDailyControl.Dispose()

        DF_RiskLimitDailyControl.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Risk limit daily control report from" & d1 & " till " & d2)

        Dim f As New RiskLimitDailyControl
        f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\RISK_LIMIT_DAILY_CONTROL_DATES.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FROM"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "TILL"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Risk limit daily control from" & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_ObligoLiabilitySurplus_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_ObligoLiabilitySurplus.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_ObligoLiabilitySurplus.Dispose()

        DF_ObligoLiabilitySurplus.Close()
        If d <= DateSerial(2017, 6, 26) Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Obligo liability Surplus report for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            f.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter.FillByRepDate(f.RiskControllingDataSet.TIME_DEP_OUTST_CLIENT_DEALS, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\ObligoLiabilitySurplus.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Obligo Liability Surplus report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        Else
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Obligo liability Surplus report for " & d)
            Dim ObligoLiabilitiesDa As New SqlDataAdapter("SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            ObligoLiabilitiesDa.Fill(REPORTINGdataset, "OBLIGO_SURPLUS_DETAILS")
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\ObligoLiabilitySurplusNew.rpt")
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Obligo Liability Surplus report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub dxOK_DailyRiskChart_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_RiskChart_daily.DateEdit1.Text
        Dim d2 As Date = DF_RiskChart_daily.DateEdit2.Text
        dxOK_DailyRiskChart.Dispose()
        DF_RiskChart_daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating daily Risk chart from" & d1 & " till " & d2)

        Dim f As New RiskLimitDailyControl
        f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY_RISK_CHART.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "DateFrom"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "DateTill"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily risk chart from" & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_DailyCarChart_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_CarChart_daily.DateEdit1.Text
        Dim d2 As Date = DF_CarChart_daily.DateEdit2.Text
        Dim d1sql As String = d1.ToString("yyyyMMdd")
        Dim d2sql As String = d2.ToString("yyyyMMdd")
        dxOK_DailyCarChart.Dispose()
        DF_CarChart_daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating daily CAR chart from" & d1 & " till " & d2)

        Dim CAR_Da As New SqlDataAdapter("SELECT * FROM [SOLVV_PositionsTotals] where [CRSA_Position_Date] between '" & d1sql & "' and '" & d2sql & "' and [CRSA_Position_Date] in (Select [CRSA_Position_Date] from SOLVV_PositionsTotals where CRSA_Position in ('CRSA_ZRBZB') and CRSA_Position_OrigAmount<>0)", conn)
        Dim CARdataset As New DataSet("REPORTING")
        CAR_Da.Fill(CARdataset, "SOLVV_PositionsTotals")

        'Dim f As New RiskLimitDailyControl
        'f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d1, d2)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\CAR_CHART.rpt")
        CrRep.SetDataSource(CARdataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "DateFrom"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "DateTill"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily CAR chart from" & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(50)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_DailyLiquidityChart_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_LiquidityChart_Daily.DateEdit1.Text
        Dim d2 As Date = DF_LiquidityChart_Daily.DateEdit2.Text
        dxOK_DailyLiquidityChart.Dispose()
        DF_LiquidityChart_Daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating daily Liquidity chart from " & d1 & " till " & d2)

        Dim f As New RiskLimitDailyControl
        f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\LIQUIDITY_CHART.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "DateFrom"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "DateTill"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily Liquidity chart from " & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_IndustrialDistributionRecon_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_IndustrialDistributionRecon.DateEdit1.Text
        Dim d2 As Date = DF_IndustrialDistributionRecon.DateEdit2.Text
        dxOK_IndustrialDistributionRecon.Dispose()
        DF_IndustrialDistributionRecon.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Industrial distribution reconciliation on " & d1 & " and " & d2)

        Dim f As New CreditRiskMak
        f.MAK_ALLTableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.MAK_ALL, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY RISK TABLES IndustrialDistribReconcile.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Industrial distribution reconciliation on " & d1 & " and " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_MaturityStrutureRecon_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_MaturityStructureRecon.DateEdit1.Text
        Dim d2 As Date = DF_MaturityStructureRecon.DateEdit2.Text
        dxOK_MaturityStrutureRecon.Dispose()
        DF_MaturityStructureRecon.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating maturity structure reconciliation on " & d1 & " and " & d2)

        Dim f As New CreditRiskMak
        f.CREDIT_RISKTableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.CREDIT_RISK, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY RISK TABLES MaturityStructureReconcile.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Maturity structure reconciliation on " & d1 & " and " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_BusinessTypesCreditPortfolioRecon_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_BusinessTypesCreditPortfolioRecon.DateEdit1.Text
        Dim d2 As Date = DF_BusinessTypesCreditPortfolioRecon.DateEdit2.Text
        dxOK_BusinessTypesCreditPortfolioRecon.Dispose()
        DF_BusinessTypesCreditPortfolioRecon.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Business Types Credit portfolio reconciliation on " & d1 & " and " & d2)

        Dim f As New BusinessTypes
        f.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY RISK TABLES BusinesTypesReconcile.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Business Types Credit portfolio reconciliation on " & d1 & " and " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_CountriesLargeCreditExposureRecon_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_CountriesLargeCreditExposureRecon.DateEdit1.Text
        Dim d2 As Date = DF_CountriesLargeCreditExposureRecon.DateEdit2.Text
        dxOK_CountriesLargeCreditExposureRecon.Dispose()
        DF_CountriesLargeCreditExposureRecon.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Countries with large Credit Exposure reconciliation on " & d1 & " and " & d2)

        Dim f As New CreditRiskMak
        f.MAK_ALLTableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.MAK_ALL, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY RISK TABLES CountriesLargeCreditExpReconcile.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Countries with large Credit Exposure reconciliation on " & d1 & " and " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_RatingClasificationRecon_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_RatingClasificationRecon.DateEdit1.Text
        Dim d2 As Date = DF_RatingClasificationRecon.DateEdit2.Text
        dxOK_RatingClasificationRecon.Dispose()
        DF_RatingClasificationRecon.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Rating clasification reconciliation on " & d1 & " and " & d2)

        Dim f As New CreditRiskMak
        f.CREDIT_RISKTableAdapter.FillByRiskDateFromTill(f.RiskControllingDataSet.CREDIT_RISK, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DAILY RISK TABLES RatingClasificatReconcile.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Rating clasification reconciliation on " & d1 & " and " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_RiskBearingCapacityDaily_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_RiskBearingCapacity_daily.DateEdit1.Text
        dxOK_RiskBearingCapacityDaily.Dispose()
        If d < DateSerial(2014, 7, 1) Then
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGEold.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d >= DateSerial(2014, 7, 1) And d <= DateSerial(2014, 12, 4) Then
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2014, 12, 4) And d <= DateSerial(2016, 3, 30) Then
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from05122014.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2016, 3, 30) And d <= DateSerial(2016, 8, 7) Then
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from31032016.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2016, 8, 7) And d <= DateSerial(2016, 10, 26) Then
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from08082016.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2016, 10, 26) And d <= DateSerial(2016, 12, 31) Then
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim f As New RiskLimitDailyControl
            f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CASH_PLEDGE_from27102016.rpt")
            CrRep.SetDataSource(f.RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d >= DateSerial(2017, 1, 1) Then
            Dim dsql As String = d.ToString("yyyyMMdd")
            DF_RiskBearingCapacity_daily.Close()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing capacity for " & d)
            Dim RiskBearingCapacityCalculation_Da As New SqlDataAdapter("SELECT * FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [RiskDate]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            RiskBearingCapacityCalculation_Da.Fill(REPORTINGdataset, "RISK_BEARING_CAPACITY_CALCULATIONS")
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_TOTAL.rpt")
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Risk bearing Capacity report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub dxOK_RiskBearingCapacityChartDaily_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_RiskBearingCapacity_Chartdaily.DateEdit1.Text
        Dim d2 As Date = DF_RiskBearingCapacity_Chartdaily.DateEdit2.Text
        dxOK_RiskBearingCapacityChartDaily.Dispose()
        DF_RiskBearingCapacity_Chartdaily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Risk bearing Capacity Chart from " & d1 & " till " & d2)

        Dim f As New RiskLimitDailyControl
        f.RISK_LIMIT_DAILY_CONTROLTableAdapter.FillByRiskDate(f.RiskControllingDataSet.RISK_LIMIT_DAILY_CONTROL, d1, d2)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CHART.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FROM"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "TILL"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Risk bearing Capacity chart report from " & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_StressTestsLiquidityHODaily_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_StressTestsHOliquidity_daily.DateEdit1.Text
        dxOK_StressTestsLiquidityHODaily.Dispose()
        DF_StressTestsHOliquidity_daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Stress Test Liquidity HO scenario Report for " & d)
        Dim f As New StressTestsHO
        f.StressTestsLiquidHOTableAdapter.FillByStressDate(f.RiskControllingDataSet.StressTestsLiquidHO, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\StressTestsLiquidityHOscenario.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "StressTestDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Stress Test Liquidity HO scenario Report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_BusinessTypesCreditPortfolio_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_BusinessTypesCreditPortfolio.DateEdit1.Text
        dxOK_BusinessTypesCreditPortfolio.Dispose()
        DF_BusinessTypesCreditPortfolio.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Business Types-Credit Portfolio Report for " & d)
        Dim f As New BusinessTypes
        f.BusinessTypesCreditPortfolioDetailsTableAdapter.FillByRiskDate(f.RiskControllingDataSet.BusinessTypesCreditPortfolioDetails, d)
        f.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(f.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolio.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Business Types - Credit Portfolio Report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = True
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_CashFlowAnalysisDailyPrintDetailsCombo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintDetailsCashflowAnalysis = dxOK_CashFlowAnalysisDailyPrintDetailsCombo.Text


    End Sub
    Private Sub dxOK_CashFlowAnalysisDaily_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_CashFlowAnalysis_daily.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        PrintDetailsCashflowAnalysis = dxOK_CashFlowAnalysisDailyPrintDetailsCombo.Text
        dxOK_CashFlowAnalysisDailyPrintDetailsCombo.Properties.Items.Clear()
        dxOK_CashFlowAnalysisDaily.Dispose()
        DF_CashFlowAnalysis_daily.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Cashflow analysis Report for " & d)
        Dim f As New Fristen
        If d <= DateSerial(2017, 12, 8) Then
            f.FRISTENTableAdapter.FillByFristenDate(f.PSTOOLDataset.FRISTEN, d)
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\CASHFLOW_ANALYSIS.rpt")
            CrRep.SetDataSource(f.PSTOOLDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            Dim myParams1 As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            If PrintDetailsCashflowAnalysis = "Print Details" Then
                myValue1.Value = "Yes"
            Else
                myValue1.Value = "No"
            End If
            myParams1.ParameterFieldName = "DetailsPrint"
            myParams.CurrentValues.Add(myValue)
            myParams1.CurrentValues.Add(myValue1)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Cashflow analysis Report for " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d > DateSerial(2017, 12, 8) Then

            Dim CashFlowAnalysis_Da As New SqlDataAdapter("SELECT * FROM [CASH_FLOWS_FINRECON] where [RiskDate]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            CashFlowAnalysis_Da.Fill(REPORTINGdataset, "CASH_FLOWS_FINRECON")
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\CASHFLOW_ANALYSIS_NEWG.rpt")
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            Dim myParams1 As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            If PrintDetailsCashflowAnalysis = "Print Details" Then
                myValue1.Value = "Yes"
            Else
                myValue1.Value = "No"
            End If
            myParams1.ParameterFieldName = "DetailsPrint"
            myParams.CurrentValues.Add(myValue)
            myParams1.CurrentValues.Add(myValue1)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Cashflow analysis Report for " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = True
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If


    End Sub

    Private Sub dxOK_NewCreditBusiness_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_NewCreditBusiness.DateEdit1.Text
        Dim d2 As Date = DF_NewCreditBusiness.DateEdit2.Text
        dxOK_NewCreditBusiness.Dispose()
        DF_NewCreditBusiness.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating New Credit Business report from " & d1 & " till " & d2)

        Dim da As New RiskControllingBasicsDataSetTableAdapters.NEW_CREDIT_BUSINESSTableAdapter
        Dim f As New CustomerRating
        da.FillByRiskDateFromTill(f.RiskControllingBasicsDataSet.NEW_CREDIT_BUSINESS, d1, d2)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\NEW_CREDIT_BUSINESS.rpt")
        CrRep.SetDataSource(f.RiskControllingBasicsDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "DateFrom"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "DateTill"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "New Credit Business report from " & d1 & " till " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_RefinancingMaturityList_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_RefinancingMaturityList.DateEdit1.Text
        dxOK_RefinancingMaturityList.Dispose()
        DF_RefinancingMaturityList.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Refinancing Maturity List Report for " & d)
        Dim da As New RiskControllingDataSetTableAdapters.BANKTableAdapter
        Dim f As New RiskLimitDailyControl
        da.Fill(f.RiskControllingDataSet.BANK)
        f.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter.FillByRepDate(f.RiskControllingDataSet.TIME_DEP_OUTST_CLIENT_DEALS, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\REFINANCING_MATURITY_LIST.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "FDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Refinancing Maturity List Report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_Kwg13_ChineseBanks_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_Kwg13_ChineseBanks.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_Kwg13_ChineseBanks.Dispose()
        DF_Kwg13_ChineseBanks.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Art.13 KWG daily report (Chinese Banks) for " & d)

        Dim Daily_Art13_Kwg_ChineseBanks_Da As New SqlDataAdapter("SELECT * FROM [Daily_Art13_Kwg_ChineseBanks] where [RiskDate]='" & dsql & "'", conn)
        Dim REPORTINGdataset As New DataSet("REPORTING")
        Daily_Art13_Kwg_ChineseBanks_Da.Fill(REPORTINGdataset, "Daily_Art13_Kwg_ChineseBanks")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DailyArtikel13KWG_ChineseBanks.rpt")
        CrRep.SetDataSource(REPORTINGdataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily Art.13 KWG (Chinese Banks) for " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_Kwg13_NoneChineseBanks_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_Kwg13_NoneChineseBanks.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_Kwg13_NoneChineseBanks.Dispose()
        DF_Kwg13_NoneChineseBanks.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Art.13 KWG daily report (None Chinese Banks) for " & d)
        Dim Daily_Art13_Kwg_NoneChineseBanks_Da As New SqlDataAdapter("SELECT * FROM [Daily_Art13_Kwg_NoneChineseBanks] where [RiskDate]='" & dsql & "'", conn)
        Dim REPORTINGdataset As New DataSet("REPORTING")
        Daily_Art13_Kwg_NoneChineseBanks_Da.Fill(REPORTINGdataset, "Daily_Art13_Kwg_NoneChineseBanks")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DailyArtikel13KWG_NoneChineseBanks.rpt")
        CrRep.SetDataSource(REPORTINGdataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily Art.13 KWG (None Chinese Banks) for " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_Kwg13_CentralGoverment_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_Kwg13_NoneChineseBanks.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_Kwg13_CentralGoverment.Dispose()
        DF_Kwg13_NoneChineseBanks.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Art.13 KWG daily report (Central Goverment) for " & d)
        Dim Daily_Art13_Kwg_NoneChineseBanks_Da As New SqlDataAdapter("SELECT * FROM [Daily_Art13_Kwg_CentralGoverment] where [RiskDate]='" & dsql & "'", conn)
        Dim REPORTINGdataset As New DataSet("REPORTING")
        Daily_Art13_Kwg_NoneChineseBanks_Da.Fill(REPORTINGdataset, "Daily_Art13_Kwg_CentralGoverment")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\DailyArtikel13KWG_Central_Goverment.rpt")
        CrRep.SetDataSource(REPORTINGdataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Daily Art.13 KWG (Central Goverment) for " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_LargeLoanExposureCorporates_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_LargeLoanExposureCorporates.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_LargeLoanExposureCorporates.Dispose()
        DF_LargeLoanExposureCorporates.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Large Loan Exposure - Corporates Report for " & d)
        'Dim da As New RiskControllingBasicsDataSetTableAdapters.LargeLoanExposureCorporatesTableAdapter
        'Dim f As New PD
        'da.FillByRiskDate(f.RiskControllingBasicsDataSet.LargeLoanExposureCorporates, d)
        If d <= DateSerial(2018, 8, 1) Then
            Dim LargeLoanExposureCorporatesDa As New SqlDataAdapter("SELECT * FROM [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            LargeLoanExposureCorporatesDa.Fill(REPORTINGdataset, "LARGE_LOANS_EXPOSURE")

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\LARGE_LOAN_EXPOSURE_CORPORATES.rpt")
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Large Loan Exposure - Corporates on " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
        Else
            Dim LargeLoanExposureCorporatesDa As New SqlDataAdapter("SELECT * FROM [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & dsql & "'", conn)
            Dim RiskLimitDailyControlDa As New SqlDataAdapter("SELECT * FROM [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & dsql & "'", conn)
            Dim REPORTINGdataset As New DataSet("REPORTING")
            LargeLoanExposureCorporatesDa.Fill(REPORTINGdataset, "LARGE_LOANS_EXPOSURE")
            RiskLimitDailyControlDa.Fill(REPORTINGdataset, "RISK LIMIT DAILY CONTROL")
            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\LARGE_LOAN_EXPOSURE_CORPORATES_from_20180802.rpt")
            CrRep.SetDataSource(REPORTINGdataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Large Loan Exposure - Corporates on " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
        End If

        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_TrafficLightsSystemRBC_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_TrafficLightsSystemRBC.DateEdit1.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
        dxOK_TrafficLightsSystemRBC.Dispose()
        DF_TrafficLightsSystemRBC.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Traffic Lights System (RBC) Report for " & d)
        Dim TrafficLightsSystemDa As New SqlDataAdapter("SELECT * FROM [RBC_TRAFFIC_LIGHT_SYSTEM] where [RiskDate]='" & dsql & "'", conn)
        Dim REPORTINGdataset As New DataSet("REPORTING")
        TrafficLightsSystemDa.Fill(REPORTINGdataset, "RBC_TRAFFIC_LIGHT_SYSTEM")

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\TRAFIC_LIGHT_SYSTEM_MAXLOSS_LIMITS_RBC.rpt")
        CrRep.SetDataSource(REPORTINGdataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RiskDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Large Loan Exposure - Corporates on " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_LCR_Overview_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_LCR_Overview.DateEdit1.Text
        Dim d1 As Date = DateAdd(DateInterval.Day, -90, d)
        Dim dsql As String = d.ToString("yyyyMMdd")
        Dim d1sql As String = d1.ToString("yyyyMMdd")
        dxOK_LCR_Overview.Dispose()
        DF_LCR_Overview.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating LCR Overview Report for " & d)

        If d <= DateSerial(2016, 9, 29) Then
            'Data for current day
            Dim LCR_INFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]='" & dsql & "' ORDER BY ID asc ", conn)
            Dim LCR_OUTFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]='" & dsql & "' ORDER BY ID asc", conn)
            Dim LCR_LA_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_LA_BAIS] where [RiskDate]='" & dsql & "' ORDER BY ID asc", conn)
            Dim LCR_OVERVIEW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]='" & dsql & "'", conn)
            Dim LCR_OVERVIEW_CD_Dataset As New DataSet("LCR_OVERVIEW")
            LCR_INFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_IN_BAIS")
            LCR_OUTFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_OUT_BAIS")
            LCR_LA_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_LA_BAIS")
            LCR_OVERVIEW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_Overview")

            'Data for last 90 Days
            Dim LCR_INFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'  ", conn)
            Dim LCR_INFLOWDataset As New DataSet("LCR_INFLOW")
            LCR_INFLOW_Da.Fill(LCR_INFLOWDataset, "LCR_IN_BAIS")
            '
            Dim LCR_OUTFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
            Dim LCR_OUTFLOWDataset As New DataSet("LCR_OUTFLOW")
            LCR_OUTFLOW_Da.Fill(LCR_OUTFLOWDataset, "LCR_OUT_BAIS")
            '
            'Dim LCR_LA_Da As New SqlDataAdapter("SELECT * FROM [LCR_LA_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
            Dim LCR_LiquidityAssets_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
            Dim LCR_LiquidityAssetsDataset As New DataSet("LCR_LIQUIDITY_ASSETS")
            LCR_LiquidityAssets_Da.Fill(LCR_LiquidityAssetsDataset, "LCR_Overview")
            '
            'RISK LIMIT DAILY CONTROL-LCR Key Figure
            Dim LCR_RLDC_Da As New SqlDataAdapter("Select [RLDC Date],[LCR_Ratio] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='" & d1sql & "' and [RLDC Date]<='" & dsql & "'", conn)
            Dim LCR_RLDCDataset As New DataSet("LCR_RLDC")
            LCR_RLDC_Da.Fill(LCR_RLDCDataset, "RISK LIMIT DAILY CONTROL")


            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\LCR_Overview.rpt")
            CrRep.SetDataSource(LCR_OVERVIEW_CD_Dataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)

            'Unterbericht Datenbank setzen
            CrRep.Subreports.Item("LCR_Inflow_Chart.rpt").SetDataSource(LCR_INFLOWDataset)
            CrRep.Subreports.Item("LCR_Outflow_Chart.rpt").SetDataSource(LCR_OUTFLOWDataset)
            CrRep.Subreports.Item("LCR_Keys.rpt").SetDataSource(LCR_RLDCDataset)
            CrRep.Subreports.Item("LCR_LiquidityAssets_Chart.rpt").SetDataSource(LCR_LiquidityAssetsDataset)

            'Unterbericht Parameter setzen
            CrRep.SetParameterValue("RiskDateFrom", d1, "LCR_Inflow_Chart.rpt")
            CrRep.SetParameterValue("RiskDateTill", d, "LCR_Inflow_Chart.rpt")

            CrRep.SetParameterValue("RiskDateFrom_Outflow", d1, "LCR_Outflow_Chart.rpt")
            CrRep.SetParameterValue("RiskDateTill_Outflow", d, "LCR_Outflow_Chart.rpt")

            CrRep.SetParameterValue("RiskDateFrom", d1, "LCR_Keys.rpt")
            CrRep.SetParameterValue("RiskDateTill", d, "LCR_Keys.rpt")
            '
            CrRep.SetParameterValue("RiskDateFrom", d1, "LCR_LiquidityAssets_Chart.rpt")
            CrRep.SetParameterValue("RiskDateTill", d, "LCR_LiquidityAssets_Chart.rpt")

            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "LCR Overview on " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        ElseIf d >= DateSerial(2016, 9, 30) Then
            'Data for current day
            Dim LCR_INFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]='" & dsql & "' ORDER BY ID asc ", conn)
            Dim LCR_OUTFLOW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]='" & dsql & "' ORDER BY ID asc", conn)
            Dim LCR_LA_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_LA_BAIS] where [RiskDate]='" & dsql & "' ORDER BY ID asc", conn)
            Dim LCR_OVERVIEW_CD_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]='" & dsql & "'", conn)
            Dim LCR_OVERVIEW_CD_Dataset As New DataSet("LCR_OVERVIEW")
            LCR_INFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_IN_BAIS")
            LCR_OUTFLOW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_OUT_BAIS")
            LCR_LA_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_LA_BAIS")
            LCR_OVERVIEW_CD_Da.Fill(LCR_OVERVIEW_CD_Dataset, "LCR_Overview")

            'Data for last 90 Days
            Dim LCR_INFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_IN_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'  ", conn)
            Dim LCR_INFLOWDataset As New DataSet("LCR_INFLOW")
            LCR_INFLOW_Da.Fill(LCR_INFLOWDataset, "LCR_IN_BAIS")
            '
            Dim LCR_OUTFLOW_Da As New SqlDataAdapter("SELECT * FROM [LCR_OUT_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
            Dim LCR_OUTFLOWDataset As New DataSet("LCR_OUTFLOW")
            LCR_OUTFLOW_Da.Fill(LCR_OUTFLOWDataset, "LCR_OUT_BAIS")
            '
            'Dim LCR_LA_Da As New SqlDataAdapter("SELECT * FROM [LCR_LA_BAIS] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
            Dim LCR_LiquidityAssets_Da As New SqlDataAdapter("SELECT * FROM [LCR_Overview] where [RiskDate]>='" & d1sql & "' and [RiskDate]<='" & dsql & "'", conn)
            Dim LCR_LiquidityAssetsDataset As New DataSet("LCR_LIQUIDITY_ASSETS")
            LCR_LiquidityAssets_Da.Fill(LCR_LiquidityAssetsDataset, "LCR_Overview")
            '
            'RISK LIMIT DAILY CONTROL-LCR Key Figure
            Dim LCR_RLDC_Da As New SqlDataAdapter("Select [RLDC Date],[LCR_Ratio] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='" & d1sql & "' and [RLDC Date]<='" & dsql & "'", conn)
            Dim LCR_RLDCDataset As New DataSet("LCR_RLDC")
            LCR_RLDC_Da.Fill(LCR_RLDCDataset, "RISK LIMIT DAILY CONTROL")


            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\LCRDR_Overview.rpt")
            CrRep.SetDataSource(LCR_OVERVIEW_CD_Dataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RiskDate"
            myParams.CurrentValues.Add(myValue)

            'Unterbericht Datenbank setzen
            'CrRep.Subreports.Item("LCRDR_Inflow_Chart.rpt").SetDataSource(LCR_INFLOWDataset)
            'CrRep.Subreports.Item("LCRDR_Outflow_Chart.rpt").SetDataSource(LCR_OUTFLOWDataset)
            CrRep.Subreports.Item("LCRDR_Keys.rpt").SetDataSource(LCR_RLDCDataset)
            'CrRep.Subreports.Item("LCRDR_LiquidityAssets_Chart.rpt").SetDataSource(LCR_LiquidityAssetsDataset)

            'Unterbericht Parameter setzen
            'CrRep.SetParameterValue("RiskDateFrom", d1, "LCRDR_Inflow_Chart.rpt")
            'CrRep.SetParameterValue("RiskDateTill", d, "LCRDR_Inflow_Chart.rpt")

            'CrRep.SetParameterValue("RiskDateFrom_Outflow", d1, "LCRDR_Outflow_Chart.rpt")
            'CrRep.SetParameterValue("RiskDateTill_Outflow", d, "LCRDR_Outflow_Chart.rpt")

            CrRep.SetParameterValue("RiskDateFrom", d1, "LCRDR_Keys.rpt")
            CrRep.SetParameterValue("RiskDateTill", d, "LCRDR_Keys.rpt")
            '
            'CrRep.SetParameterValue("RiskDateFrom", d1, "LCRDR_LiquidityAssets_Chart.rpt")
            'CrRep.SetParameterValue("RiskDateTill", d, "LCRDR_LiquidityAssets_Chart.rpt")

            Dim c As New CrystalReportsForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "LCR Overview on " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub dxOK_CCB_Vostro_Buba_Balances_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim d1 As Date = DF_ProfitLossReconcile.DateEdit1.Text
        Dim d2 As Date = DF_ProfitLossReconcile.DateEdit2.Text
        Dim rdsql1 As String = d1.ToString("yyyyMMdd")
        Dim rdsql2 As String = d2.ToString("yyyyMMdd")

        dxOK_CCB_Vostro_Buba_Balances.Dispose()
        DF_ProfitLossReconcile.Close()



        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating CCB Vostro vs BubBa Nostro Balances Report from " & d1 & " till " & d2)
            SplashScreenManager.Default.SetWaitFormCaption("Creating CCB Vostro vs BubBa Nostro Balances Report" & vbNewLine & "Start loading Data to Excel File from " & d1 & " till " & d2)
            '+++++Get Excel File
            QueryText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='CCB_Vostro_Balances_Excel_File' and [IdABTEILUNGSPARAMETER]='EXCEL_FILES_DIRECTORY' and [PARAMETER STATUS]='Y'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim CCB_Vostro_Buba_Balances_ExcelFileName As String = dt.Rows(0).Item("PARAMETER2").ToString
            dt.Clear()

            '**********DATA LOAD***********
            '******************************
            'Balances Totals
            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('CCB_Vostro_Buba_Balances_Selection') and Status in ('Y')"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New System.Data.DataTable()
                da2.Fill(dt2)
            End If
            'Balances Details
            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('CCB_Vostro_Buba_Balances_Selection') and Status in ('Y')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_2").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt3 = New System.Data.DataTable()
                da3.Fill(dt3)
            End If


            SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with selected Data")
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
            workbook.LoadDocument(CCB_Vostro_Buba_Balances_ExcelFileName, DocumentFormat.Xlsx)
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            Dim worksheet1 As Worksheet = workbook.Worksheets(1)
            'workbook.Worksheets(0).Cells("D1").Value = rd
            'workbook.Worksheets(0).Cells("AD1").Value = NextWorkingDate

            SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
            worksheet.ClearContents(worksheet("A2:C60000"))
            worksheet1.ClearContents(worksheet1("A3:F60000"))
            'worksheet.ClearFormats(worksheet("A4:E60000"))
            'worksheet1.ClearFormats(worksheet1("A3:U60000"))

            SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
            worksheet.Import(dt2, False, 1, 0) 'Totals
            worksheet1.Import(dt3, False, 2, 0) 'Details

            'Dim ZVDL_Totals_LastDtRow As Integer = dt3.Rows.Count + 2
            'Dim ZVDL_Details_LastRow As Integer = dt2.Rows.Count + 2
            'Dim RangeZVDL_Totals_C As CellRange = worksheet.Range("C3:C" & ZVDL_Totals_LastDtRow) 'Trade Date Buy Sell Amount
            ''RangeZVDL_Totals_C.Formula = "=COUNTIF(Details!$D$3:$D$" & ZVDL_Details_LastRow & ";A4)"
            'Dim RangeZVDL_Totals_D As CellRange = worksheet.Range("D3:D" & ZVDL_Totals_LastDtRow) 'Trade Date Buy Sell Amount
            'RangeZVDL_Totals_D.Formula = "=COUNTIFS(Details!$D$3:$D$" & ZVDL_Details_LastRow & ";A3;Details!$W$3:$W$" & ZVDL_Details_LastRow & ";""=Y"")"
            'Dim RangeZVDL_Totals_E As CellRange = worksheet.Range("E3:E" & ZVDL_Totals_LastDtRow) 'Amortization to Risk Date
            'RangeZVDL_Totals_E.Formula = "=IF(C3<>0;D3/C3;0)"

            'Adding Summ Formulas at Runtime
            'Dim AddSumFormula As Integer = ZVDL_Totals_LastDtRow + 1
            'Dim ExcelCell As String = Nothing
            'Dim cell As DevExpress.Spreadsheet.Cell = Nothing
            'ExcelCell = "A" & AddSumFormula
            'workbook.Worksheets(0).Cells(ExcelCell).Value = "Sum"

            'ExcelCell = "C" & AddSumFormula
            'workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(C3:C" & ZVDL_Totals_LastDtRow & ")"
            'ExcelCell = "D" & AddSumFormula
            'workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(D3:D" & ZVDL_Totals_LastDtRow & ")"
            'ExcelCell = "E" & AddSumFormula
            'workbook.Worksheets(0).Cells(ExcelCell).Formula = "=IF(D" & AddSumFormula & "<>0;D" & AddSumFormula & "/C" & AddSumFormula & ";0)"

            'workbook.Worksheets(0).Cells("A1").Value = "ZVDL Report von:" & d1 & " bis " & d2
            workbook.Worksheets(1).Cells("A1").Value = "All Balances (EUR) from:" & d1 & " till " & d2
            'Save Excel File
            workbook.SaveDocument(CCB_Vostro_Buba_Balances_ExcelFileName, DocumentFormat.OpenXml)

            'Load Excel Form
            Dim c As New ExcelForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "CCB Vostro vs Buba Balances from " & d1 & " till " & d2
            c.SpreadsheetControl1.ReadOnly = True

            workbookN = c.SpreadsheetControl1.Document
            Using stream As New FileStream(CCB_Vostro_Buba_Balances_ExcelFileName, FileMode.Open)
                workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
            End Using


            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try


    End Sub


#End Region

#Region "ACCOUNTING TREELIST"
    'Accounting
    Private Sub dxOK_FxCreditEquivalent_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_FxCreditEquivalent.DateEdit1.Text
        dxOK_FxCreditEquivalent.Dispose()
        DF_FxCreditEquivalent.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating FX Credit Equivalent Report for " & d)

        Dim f As New FxCreditEquivalentCalculation
        f.FX_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(f.AccountingDataSet.FX_CREDIT_EQUIVALENT_Details, d)
        f.FX_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(f.AccountingDataSet.FX_CREDIT_EQUIVALENT_Basic, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\FX_CREDIT_EQUIV_CALC.rpt")
        CrRep.SetDataSource(f.AccountingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "FX Credit Equivalent Report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_IrsCreditEquivalent_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_IrsCreditEquivalent.DateEdit1.Text
        dxOK_IrsCreditEquivalent.Dispose()
        DF_IrsCreditEquivalent.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating IRS Credit Equivalent Report for " & d)

        Dim f As New IrsCreditEquivalentCalculation
        f.IRS_CREDIT_EQUIVALENT_DetailsTableAdapter.FillByRiskDate(f.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Details, d)
        f.IRS_CREDIT_EQUIVALENT_BasicTableAdapter.FillByRiskDate(f.AccountingDataSet.IRS_CREDIT_EQUIVALENT_Basic, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\INTEREST_RATE_SWAP_CREDIT_EQUIV_CALC.rpt")
        CrRep.SetDataSource(f.AccountingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "IRS Credit Equivalent Report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_TimeDepositOutDeals_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_TimeDepositOutstandingClientDeals.DateEdit1.Text
        dxOK_TimeDepositOutDeals.Dispose()
        DF_TimeDepositOutstandingClientDeals.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Time Deposit Outstanding Client Deals Report for " & d)

        Dim f As New RiskLimitDailyControl
        f.TIME_DEP_OUTST_CLIENT_DEALSTableAdapter.FillByRepDate(f.RiskControllingDataSet.TIME_DEP_OUTST_CLIENT_DEALS, d)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\Time_Deposit_Outstanding_Clients_Deals.rpt")
        CrRep.SetDataSource(f.RiskControllingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "FDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Time Deposit Outstanding Client Deals Report from " & d
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_KapiStMMkundenMonat_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsMonat As String = DF_KapiSteuerMMKundenMonat.ComboBoxEdit1.Text
        DF_KapiSteuerMMKundenMonat.ComboBoxEdit1.Properties.Items.Clear()
        dxOK_KapiStMMkundenMonat.Dispose()
        DF_KapiSteuerMMKundenMonat.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Kapitalertragsteuerbescheinigungen der MM Kunden für " & ZinsMonat)

        Dim f As New SteuerbescheinigungKunden
        f.ZINSERTRAG_KDDETAILTableAdapter.Fill(f.AccountingDataSet.ZINSERTRAG_KDDETAIL)
        f.ZINSERTRAG_KDBASICTableAdapter.Fill(f.AccountingDataSet.ZINSERTRAG_KDBASIC)
        f.BANKTableAdapter.Fill(f.AccountingDataSet.BANK)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_MM.rpt")
        'Dim r As New KD_BESCHEINIGUNG_KAPI_MM
        CrRep.SetDataSource(f.AccountingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ZinsMonat
        myParams.ParameterFieldName = "ZINS_MONAT"
        myParams.CurrentValues.Add(myValue)
        CrRep.SetParameterValue("ZINS_MONAT", ZinsMonat, "KD_BESCHEINIGUNG_KAPI_MM.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Kapitalertragsteuer MM Kunden für " & ZinsMonat
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_KapiStKundenAlleJahr_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsJahr As String = DF_KapiSteuerKundeAlle.ComboBoxEdit1.Text
        Dim Zeilen As String = DF_KapiSteuerKundeAlle.ComboBoxEdit2.Text
        DF_KapiSteuerKundeAlle.ComboBoxEdit1.Properties.Items.Clear()
        DF_KapiSteuerKundeAlle.ComboBoxEdit2.Properties.Items.Clear()
        dxOK_KapiStKundenAlleJahr.Dispose()
        DF_KapiSteuerKundeAlle.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Steuerbescheinigungen aller Kunden für das Jahr " & ZinsJahr)

        Dim f As New SteuerbescheinigungKunden
        f.ZINSERTRAG_KDDETAILTableAdapter.Fill(f.AccountingDataSet.ZINSERTRAG_KDDETAIL)
        f.ZINSERTRAG_KDBASICTableAdapter.Fill(f.AccountingDataSet.ZINSERTRAG_KDBASIC)
        f.BANKTableAdapter.Fill(f.AccountingDataSet.BANK)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_JAHR.rpt")
        CrRep.SetDataSource(f.AccountingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = ZinsJahr
        myParams.ParameterFieldName = "ZINS_JAHR"
        myParams.CurrentValues.Add(myValue)
        CrRep.SetParameterValue("ZEILEN", Zeilen, "KD_BESCHEINIGUNG_KAPI_JAHR.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Steuerbescheinigungen aller Kunden für das Jahr " & ZinsJahr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_KapiStKundenEinzelnJahr_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ZinsJahr As String = DF_KapiSteuerKundeEinzeln.ComboBoxEdit1.Text
        Dim Kunde As String = Microsoft.VisualBasic.Left(DF_KapiSteuerKundeEinzeln.ComboBoxEdit2.Text, 8)
        Dim Zeilen As String = DF_KapiSteuerKundeEinzeln.ComboBoxEdit3.Text
        DF_KapiSteuerKundeEinzeln.ComboBoxEdit1.Properties.Items.Clear()
        DF_KapiSteuerKundeEinzeln.ComboBoxEdit2.Properties.Items.Clear()
        DF_KapiSteuerKundeEinzeln.ComboBoxEdit3.Properties.Items.Clear()
        dxOK_KapiStKundenEinzelnJahr.Dispose()
        DF_KapiSteuerKundeEinzeln.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Steuerbescheinigungen aller Kunden für das Jahr " & ZinsJahr)

        Dim f As New SteuerbescheinigungKunden
        f.ZINSERTRAG_KDDETAILTableAdapter.Fill(f.AccountingDataSet.ZINSERTRAG_KDDETAIL)
        f.ZINSERTRAG_KDBASICTableAdapter.Fill(f.AccountingDataSet.ZINSERTRAG_KDBASIC)
        f.BANKTableAdapter.Fill(f.AccountingDataSet.BANK)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KD_BESCHEINIGUNG_KAPI_JAHR_Single.rpt")
        CrRep.SetDataSource(f.AccountingDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = ZinsJahr
        myParams.ParameterFieldName = "ZINS_JAHR"
        myValue1.Value = Kunde
        myParams1.ParameterFieldName = "KUNDE"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        CrRep.SetParameterValue("ZEILEN", Zeilen, "KD_BESCHEINIGUNG_KAPI_JAHR.rpt")
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Steuerbescheinigung Kunden Nr.: " & Kunde & " für das Jahr " & ZinsJahr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_BalanceSheetReconciliation_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_BalanceSheetReconciliation.DateEdit1.Text
        Dim d2 As Date = DF_BalanceSheetReconciliation.DateEdit2.Text
        dxOK_BalanceSheetReconciliation.Dispose()
        DF_BalanceSheetReconciliation.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Balance Sheet reconciliation on " & d1 & " to " & d2)


        Dim f As New DailyBalanceSheets
        f.DailyBalanceSheetsTableAdapter.FillByBSDateFromTill(f.PSTOOLDataset.DailyBalanceSheets, d1, d2)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\Balance Sheets Reconciliation.rpt")
        CrRep.SetDataSource(f.PSTOOLDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Balance Sheet reconciliation on " & d1 & " to " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_ProfitLossReconciliation_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_ProfitLossReconcile.DateEdit1.Text
        Dim d2 As Date = DF_ProfitLossReconcile.DateEdit2.Text
        dxOK_ProfitLossReconciliation.Dispose()
        DF_ProfitLossReconcile.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Profit and Loss reconciliation on " & d1 & " to " & d2)


        Dim f As New DailyBalanceSheets
        f.DailyBalanceSheetsTableAdapter.FillByBSDateFromTill(f.PSTOOLDataset.DailyBalanceSheets, d1, d2)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\Profit Loss Reconcile.rpt")
        CrRep.SetDataSource(f.PSTOOLDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Balance Sheet reconciliation on " & d1 & " to " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub dxOK_ProfitLossExcelIDW_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_ProfitLossReconcile.DateEdit1.Text
        Dim d2 As Date = DF_ProfitLossReconcile.DateEdit2.Text
        Dim rdsql1 As String = d1.ToString("yyyyMMdd")
        Dim rdsql2 As String = d2.ToString("yyyyMMdd")
        dxOK_ProfitLossExcelIDW.Dispose()
        DF_ProfitLossReconcile.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Check if Date till is present")
        QueryText = "Select Max([RLDC Date]) as 'MaxDate' from [RISK LIMIT DAILY CONTROL] where [PLdifferenceOCBS_IDW_INTERN] <>0 and Client_Lock=0"
        da4 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt4 = New System.Data.DataTable()
        da4.Fill(dt4)
        Dim MaxDate As Date = dt4.Rows(0).Item("MaxDate").ToString
        SplashScreenManager.CloseForm(False)
        If d2 > MaxDate Then
            XtraMessageBox.Show("The maximum Business date is  " & MaxDate & vbNewLine & "Please define your query till " & MaxDate, "TILL DATE HIGHER THAN MAXIMUM BUSINESS DATE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return
        End If


        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Profit/Loss Excel Sheet (IDW-Bundebank Interests) from " & d1 & " till " & d2)
            SplashScreenManager.Default.SetWaitFormCaption("Start loading Data to Excel File from " & d1 & " till " & d2)
            '+++++Get Excel File
            QueryText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='PL_Revaluation_Methods_Directory' and [IdABTEILUNGSPARAMETER]='IDW_OCBS_REVALUATION_DIFF' and [PARAMETER STATUS]='Y'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim PL_ExcelFileName As String = dt.Rows(0).Item("PARAMETER2").ToString
            dt.Clear()

            '**********DATA LOAD***********
            '******************************
            QueryText = "SELECT [RLDC Date],[PL Result],[BUBA_InterestAmount],0 as 'Profit_after_NagativeInterest',[PLdifferenceOCBS_IDW],0 as 'Profit_after_IDW',[PLdifferenceOCBS_IDW_INTERN] FROM [RISK LIMIT DAILY CONTROL] where [PLdifferenceOCBS_IDW_INTERN] <>0 and [RLDC Date]>='" & rdsql1 & "'and [RLDC Date]<='" & rdsql2 & "' and Client_Lock=0 order by [RLDC Date] desc"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)


            SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
            workbook.LoadDocument(PL_ExcelFileName, DocumentFormat.Xlsx)
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            'workbook.Worksheets(0).Cells("D1").Value = rd
            'workbook.Worksheets(0).Cells("AD1").Value = NextWorkingDate

            SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
            worksheet.ClearContents(worksheet("A2:H5000"))

            SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
            worksheet.Import(dt, False, 1, 0)

            Dim PL_IDW_LastDtRow As Integer = dt.Rows.Count + 1
            Dim RangePL_IDW_D As CellRange = worksheet.Range("D2:D" & PL_IDW_LastDtRow) 'Trade Date Buy Sell Amount
            RangePL_IDW_D.Formula = "=B2+C2"
            Dim RangePL_IDW_F As CellRange = worksheet.Range("F2:F" & PL_IDW_LastDtRow) 'Amortization to Risk Date
            RangePL_IDW_F.Formula = "=D2+E2"
            Dim RangePL_IDW_H As CellRange = worksheet.Range("H2:H" & PL_IDW_LastDtRow) 'Buy2Buy1Amount
            RangePL_IDW_H.Formula = "=D2+G2"


            'Save Excel File
            workbook.SaveDocument(PL_ExcelFileName, DocumentFormat.OpenXml)

            'Load Excel Form
            Dim c As New ExcelForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "Profit/Loss (IDW and Bundesbank Interests) results from " & d1 & " till " & d2
            c.SpreadsheetControl1.ReadOnly = True

            workbookN = c.SpreadsheetControl1.Document
            Using stream As New FileStream(PL_ExcelFileName, FileMode.Open)
                workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
            End Using


            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try


    End Sub

#End Region

#Region "FOREIGN TREELIST"
    'Foreign
    Private Sub dxOK_ExportLCmonthlyStatistic_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_ExportLCMonthlyStatistic.DateEdit1.Text
        Dim StringD As String = d.ToString("MMMM yyyy")
        Dim FirstDateYear As Date = DateSerial(d.Year, 1, 1)
        dxOK_ExportLCmonthlyStatistic.Dispose()
        DF_ExportLCMonthlyStatistic.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung der Statistik der Export Akkreditive für " & StringD)

        '************************************
        'EXPORT_LC_STATISTIC_GENERATE()
        '************************************

        Dim da As New ForeignDatasetTableAdapters.EXPORT_LC_DETAILS_ALLTableAdapter
        Dim da1 As New ForeignDatasetTableAdapters.EXPORT_LC_MONTHTableAdapter
        Dim da2 As New ForeignDatasetTableAdapters.EXPORT_LC_YEARTableAdapter
        Dim f As New LcExportMaturities
        da.Fill(f.ForeignDataset.EXPORT_LC_DETAILS_ALL)
        da1.Fill(f.ForeignDataset.EXPORT_LC_MONTH)
        da2.Fill(f.ForeignDataset.EXPORT_LC_YEAR)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\LC_EXPORT_STATISTIC_MONTH.rpt")
        CrRep.SetDataSource(f.ForeignDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "Month"
        myValue1.Value = FirstDateYear
        myParams1.ParameterFieldName = "Year"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Statistik der Export Akkreditive für " & StringD
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub EXPORT_LC_STATISTIC_GENERATE()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandTimeout = 60000
        cmd.CommandText = "INSERT INTO [EXPORT LC DETAILS ALL] ([BENEFNAME],[SENDER BIC],[M40A],[M20],[OURREF],[M31C],[M31D_Date],[M31D_Country],[M50_1],[CCY],[M32B]) SELECT UPPER([Beneficiary]),[SenderBIC],[LC_Form],[LC_Nr],[OurReference],[DateOfIssue],[M31D_Date],[M31D_Country],UPPER([Applicant]),[LC_Currency],[LC_Amount] FROM [EXPORT_LC_MT700] where  [DateOfIssue]>'20121231' and [LC_Nr] not in (SELECT [M20] from [EXPORT LC DETAILS ALL])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [IdLCMonth]=DATEADD(MONTH, DATEDIFF(MONTH, 0, [M31C]), 0) Where [IdLCMonth] is NULL "
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[BRANCH INFORMATION]+B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON Left(A.[SENDER BIC],8)=B.[BIC CODE] where Right(A.[SENDER BIC],3)=B.[BRANCH CODE] and A.[SENDERNAME] is NULL and B.[BRANCH INFORMATION] is not NULL"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON Left(A.[SENDER BIC],8)=B.[BIC CODE] where Right(A.[SENDER BIC],3)=B.[BRANCH CODE] and A.[SENDERNAME] is NULL and A.[SENDER BRANCH] is NULL"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[BRANCH INFORMATION]+B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON A.[SENDER BIC]=B.[BIC CODE] where B.[BRANCH CODE]='XXX' and Len(A.[SENDER BIC])=8 and A.[SENDERNAME] is NULL and B.[BRANCH INFORMATION] is not NULL"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON A.[SENDER BIC]=B.[BIC CODE] where B.[BRANCH CODE]='XXX' and Len(A.[SENDER BIC])=8 and A.[SENDERNAME] is NULL and A.[SENDER BRANCH] is NULL"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [EXCHANGE RATE]= 1 WHERE [CCY]='EUR'"
        cmd.ExecuteNonQuery()
        QueryText = "Select  Max([EXCHANGE RATE DATE]) as MaxExchangeDate,DATEADD(MONTH, DATEDIFF(MONTH, 0, Max([EXCHANGE RATE DATE])), 0) as MaxMonthYear from   [EXCHANGE RATES OCBS] where [EXCHANGE RATE DATE] is not NULL GROUP BY Month([EXCHANGE RATE DATE])"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim MaxExchangeDate As Date = dt.Rows.Item(i).Item("MaxExchangeDate")
            Dim MaxExchangeDateSql As String = MaxExchangeDate.ToString("yyyyMMdd")
            Dim MaxMonthYearDate As Date = dt.Rows.Item(i).Item("MaxMonthYear")
            Dim MaxMonthYearDateSql As String = MaxMonthYearDate.ToString("yyyyMMdd")
            'cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [EXCHANGE_RATE_DATE]= '" & MaxExchangeDateSql & "' WHERE REPLACE(RIGHT(CONVERT(VARCHAR(10), [M31C], 105), 7),'-','.')= '" & Microsoft.VisualBasic.Right(dt.Rows.Item(i).Item("MaxExchangeDate"), 7) & "'"
            cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [EXCHANGE_RATE_DATE]= '" & MaxExchangeDateSql & "' WHERE [IdLCMonth]= '" & MaxMonthYearDateSql & "'"
            cmd.ExecuteNonQuery()
        Next
        cmd.CommandText = "UPDATE A  SET A.[EXCHANGE RATE]=B.[MIDDLE RATE] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [EXCHANGE RATES OCBS] B On A.[EXCHANGE_RATE_DATE]=B.[EXCHANGE RATE DATE] where A.[CCY]=B.[CURRENCY CODE] and A.[CCY] not in ('EUR')"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [AMTEUR]=Round([M32B]/[EXCHANGE RATE],2)"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "INSERT INTO [EXPORT LC MONTH] ([LC Month],IdLCYear) Select distinct [IdLCMonth],DATEADD(YEAR, DATEDIFF(YEAR, 0, [IdLCMonth]), 0) from [EXPORT LC DETAILS ALL] WHERE [IdLCMonth] not in (Select  [LC Month] from   [EXPORT LC MONTH])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "INSERT INTO [EXPORT LC YEAR] ([LC Year]) Select distinct [IdLCYear] from [EXPORT LC MONTH] WHERE [IdLCYear] not in (Select  [LC Year] from   [EXPORT LC YEAR])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[LC Items]=B.LCItems,A.[LC Amounts]=B.SumLCAmt from [EXPORT LC MONTH] A INNER JOIN (Select sum([AMTEUR]) as SumLCAmt,Count([ID])as LCItems,[IdLCMonth] from   [EXPORT LC DETAILS ALL] GROUP BY Month([IdLCMonth]),[IdLCMonth])B on A.[LC Month]=B.[IdLCMonth]"
        cmd.ExecuteNonQuery()
        QueryText = "Exec [SUM_VOLUME_PROFIT_LOSS]"
        Dim mobjAdapter As New SqlDataAdapter
        Dim newCmd As SqlCommand = New SqlCommand(QueryText.Trim(), conn)
        mobjAdapter.SelectCommand = newCmd
        newCmd.CommandTimeout = 60000
        dt = New DataTable()
        mobjAdapter.Fill(dt)

        For i = 0 To dt.Rows.Count - 1
            'MsgBox(dt.Rows.Item(i).Item("MaxBookingDate") & "  " & dt.Rows.Item(i).Item("MaxMonthYear"))
            Dim MinBD As Date = FormatDateTime(dt.Rows.Item(i).Item("MaxMonthYear"), DateFormat.ShortDate)
            Dim MinBDsql As String = MinBD.ToString("yyyyMMdd")
            Dim MaxBD As Date = FormatDateTime(dt.Rows.Item(i).Item("MaxBookingDate"), DateFormat.ShortDate)
            Dim MaxBDsql As String = MaxBD.ToString("yyyyMMdd")
            Dim SumAmtBalance As Double = 0
            If MinBD <> MaxBD Then
                'cmd.CommandText = "Select Sum([AmountInEuro]) from [PROFIT and LOSS VOLUMES] where [Description] is not NULL and [Description] not like '%YEAR-END P&L TRANSFER%' and [CCY]='EUR' and [GL_AC_No] in ('53208300','53211306')  and [GL_Rep_Date]>='" & MinBDsql & "' and [GL_Rep_Date]<='" & MaxBDsql & "'"
                cmd.CommandText = "Exec [LC_EARNINGS] @MINDATE='" & MinBDsql & "',@MAXDATE='" & MaxBDsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    SumAmtBalance = cmd.ExecuteScalar
                Else
                    SumAmtBalance = 0
                End If
                cmd.CommandText = "UPDATE [EXPORT LC MONTH] SET [LC Earnings]=" & Str(SumAmtBalance) & " where [LC Month]='" & MinBDsql & "'"
                cmd.ExecuteNonQuery()
            End If
        Next
        cmd.CommandText = "INSERT INTO [EXPORT LC YEAR] ([LC Year]) Select distinct [IdLCYear] from [EXPORT LC MONTH] WHERE [IdLCYear] not in (Select  [LC Year] from   [EXPORT LC YEAR])"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "UPDATE A SET A.[LC Items]=B.LCItems,A.[LC Amounts]=B.SumLCAmt,A.[LC Earnings]=B.LCEarnings from [EXPORT LC YEAR] A INNER JOIN (Select sum([LC Amounts]) as SumLCAmt,Sum([LC Items])as LCItems, Sum([LC Earnings])as LCEarnings,[IdLCYear],Year([IdLCYear]) as LCYear from   [EXPORT LC MONTH] GROUP BY [IdLCYear],Year([IdLCYear]),Year([IdLCYear]))B on A.[LC Year]=B.[IdLCYear]"
        cmd.ExecuteNonQuery()
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
    End Sub
#End Region

#Region "MELDEWESEN TREELIST"
    'Meldewesen
    Private Sub dxOK_AWVz4_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_AWVz4.DateEdit1.Text
        Dim StringD As String = d.ToString("MMMM yyyy")
        dxOK_AWVz4.Dispose()
        DF_AWVz4.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z4 Report for " & StringD)

        Dim f As New AWV
        f.AWVz4TRANSITPOSTENTableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz4TRANSITPOSTEN, d)
        f.AWVz4DIRINVPOSTENTableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz4DIRINVPOSTEN, d)
        f.AWVz4DIKAPPOSTENTableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz4DIKAPPOSTEN, d)
        f.AWVz14z15TableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz14z15, d)
        f.BANKTableAdapter.Fill(f.MeldewesenDataSet.BANK)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_Z4.rpt")
        CrRep.SetDataSource(f.MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z4 on " & StringD
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub dxOK_AWVz10_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_AWVz10.DateEdit1.Text
        Dim StringD As String = d.ToString("MMMM yyyy")
        dxOK_AWVz10.Dispose()
        DF_AWVz10.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z10 Report for " & StringD)

        Dim f As New AWV
        f.AWVz10POSTENTableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz10POSTEN, d)
        f.AWVz14z15TableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz14z15, d)
        f.BANKTableAdapter.Fill(f.MeldewesenDataSet.BANK)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_Z10.rpt")
        CrRep.SetDataSource(f.MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z10 on " & StringD
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub dxOK_AWVz11_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_AWVz11.DateEdit1.Text
        Dim StringD As String = d.ToString("MMMM yyyy")
        dxOK_AWVz11.Dispose()
        DF_AWVz11.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z11 Report for " & StringD)

        Dim f As New AWV
        f.AWVz11POSTENTableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz11POSTEN, d)
        f.BANKTableAdapter.Fill(f.MeldewesenDataSet.BANK)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_Z11.rpt")
        CrRep.SetDataSource(f.MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = d
        myParams.ParameterFieldName = "RepDate"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z11 on " & StringD
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub dxOK_AWVz14z15_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date = DF_AWVz14z15.DateEdit1.Text
        Dim rdsql As String = d.ToString("yyyyMMdd")
        Dim StringD As String = d.ToString("MMMM yyyy")
        dxOK_AWVz14z15.Dispose()
        DF_AWVz14z15.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating AWV Z14-Z15 Report for " & StringD)

        Dim AWVz1415RelevantData_Da As New SqlDataAdapter("Select * from [AWVz1415RelevantData] where [IdZ14Z15Meldemonat]='" & rdsql & "' ", conn)
        Dim AWVz14z15_Da As New SqlDataAdapter("Select * from [AWVz14z15] where [Z14Z15MeldeMonat]='" & rdsql & "' ", conn)
        Dim AWVz14_Da As New SqlDataAdapter("Select * from [AWVz14] where [IdZ14Z15Meldemonat]='" & rdsql & "' ", conn)
        Dim AWVz15_Da As New SqlDataAdapter("Select * from [AWVz15] where [IdZ14Z15Meldemonat]='" & rdsql & "' ", conn)
        Dim Bank_Da As New SqlDataAdapter("Select * from [BANK]", conn)
        Dim AWV_Dataset As New DataSet("AWV")
        AWVz1415RelevantData_Da.Fill(AWV_Dataset, "AWVz1415RelevantData")
        AWVz14z15_Da.Fill(AWV_Dataset, "AWVz14z15")
        AWVz14_Da.Fill(AWV_Dataset, "AWVz14")
        AWVz15_Da.Fill(AWV_Dataset, "AWVz15")
        Bank_Da.Fill(AWV_Dataset, "BANK")

        'Dim f As New AWV
        'f.COUNTRIESTableAdapter1.Fill(f.MeldewesenDataSet.COUNTRIES)
        'f.AWVz15TableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz15, d)
        'f.AWVz1415RelevantDataTableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz1415RelevantData, d)
        'f.AWVz14TableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz14, d)
        'f.AWVz14z15TableAdapter.FillByReportMonth(f.MeldewesenDataSet.AWVz14z15, d)
        'f.BANKTableAdapter.Fill(f.MeldewesenDataSet.BANK)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AWV_z14_z15.rpt")
        'CrRep.SetDataSource(f.MeldewesenDataSet)
        CrRep.SetDataSource(AWV_Dataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = StringD
        myParams.ParameterFieldName = "RepMonth"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "AWV Z14-Z15 on " & StringD
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub dxOK_KAPIMLD_REP_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Zinsertragsmonatmeldung As String = DF_KapiSoliMonatDetails.ComboBoxEdit1.Text
        dxOK_KAPIMLD_REP.Dispose()
        DF_KapiSoliMonatDetails.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung des Reports für die Kapitalertragsteuer/Soli  " & Zinsertragsmonatmeldung)

        Dim f As New KapiSoliMeldungen
        f.ZINSERTRAG_KUNDEN_DETAILSTableAdapter.Fill(f.MeldewesenDataSet.ZINSERTRAG_KUNDEN_DETAILS)
        f.ZINSERTRAG_KUNDEN_MONATTableAdapter.Fill(f.MeldewesenDataSet.ZINSERTRAG_KUNDEN_MONAT)
        f.ZINSERTRAG_KUNDEN_JAHRTableAdapter.Fill(f.MeldewesenDataSet.ZINSERTRAG_KUNDEN_JAHR)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\KapiMeldungMonat.rpt")
        CrRep.SetDataSource(f.MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = Zinsertragsmonatmeldung
        myParams.ParameterFieldName = "MeldeMonat"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Kapitalertragsteuer/Soli für " & Zinsertragsmonatmeldung
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub dxOK_KAPIMLD_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Zinsertragsmonatmeldung As String = DF_KapiSoliMonatMeldung.ComboBoxEdit1.Text
        Dim MeldeJahr As String = Microsoft.VisualBasic.Right(Zinsertragsmonatmeldung, 4)
        dxOK_KAPIMLD.Dispose()
        DF_KapiSoliMonatMeldung.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung Kapitalertragsteueranmeldung für " & Zinsertragsmonatmeldung)
        'BANK DATEN empfangen
        Dim STEUERNUMMER As String = ""
        Dim BANKNAME As String = ""
        Dim BANKSTRASSE As String = ""
        Dim BANKPLZ As String = ""
        Dim BANKORT As String = ""

        QueryText = "select * from [BANK]"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        STEUERNUMMER = dt.Rows.Item(0).Item("SteuerNr")
        BANKNAME = dt.Rows.Item(0).Item("Name Bank") & "," & dt.Rows.Item(0).Item("Branch Bank")
        BANKSTRASSE = dt.Rows.Item(0).Item("Strasse Bank")
        BANKPLZ = dt.Rows.Item(0).Item("PLZ Bank")
        BANKORT = dt.Rows.Item(0).Item("Ort Bank")

        'FINANZAMT DATEN-PDF Remplate Empfangen
        Dim FINANZAMT_NAME As String = ""
        Dim FINANZAMT_STRASSE As String = ""
        Dim FINANZAMT_PLZ As String = ""
        Dim FINANZAMT_ORT As String = ""
        Dim PDF_TEMPLATE As String = ""
        Dim PDF_NEW_FILE As String = ""

        QueryText = "SELECT * FROM [PARAMETER] where  [IdABTEILUNGSPARAMETER]='KAPISTEUERMLD' and [PARAMETER STATUS]='Y' "
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim CheckParameter As String = dt.Rows.Item(i).Item("PARAMETER1")
            Dim RelevantParameter As String = dt.Rows.Item(i).Item("PARAMETER2")
            Select Case CheckParameter
                Case Is = "FINANZAMT_NAME"
                    FINANZAMT_NAME = RelevantParameter
                Case Is = "FINANZAMT_STRASSE"
                    FINANZAMT_STRASSE = RelevantParameter
                Case Is = "FINANZAMT_PLZ"
                    FINANZAMT_PLZ = RelevantParameter
                Case Is = "FINANZAMT_ORT"
                    FINANZAMT_ORT = RelevantParameter
                Case Is = "KAPIMELDUNG_TEMPLATE_DIR"
                    PDF_TEMPLATE = RelevantParameter
                Case Is = "KAPIMELDUNG_NEW_DIR"
                    PDF_NEW_FILE = RelevantParameter
            End Select
        Next

        Dim newFileSave As String = PDF_NEW_FILE & "\Kapitalertragsteueranmeldung_" & Zinsertragsmonatmeldung & ".pdf"
        Dim pdfReader As New PdfReader(PDF_TEMPLATE)
        Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFileSave, FileMode.Create))

        Dim pdfFormFields As AcroFields = pdfStamper.AcroFields


        'Füllen der Daten in allen seiten
        pdfFormFields.SetField("topmostSubform[0].Page1[0].MeldeJahr[0]", MeldeJahr)
        pdfFormFields.SetField("topmostSubform[0].Page1[0].Steuernummer[0]", STEUERNUMMER)
        Dim FINANZ_ALL As String = FINANZAMT_NAME & vbNewLine & FINANZAMT_STRASSE & vbNewLine & FINANZAMT_PLZ & "  " & FINANZAMT_ORT
        pdfFormFields.SetField("topmostSubform[0].Page1[0].Finanzamt[0]", FINANZ_ALL)
        Dim BANK_ALL As String = BANKNAME & vbNewLine & BANKSTRASSE & vbNewLine & BANKPLZ & "  " & BANKORT
        pdfFormFields.SetField("topmostSubform[0].Page1[0].Schuldner[0]", BANK_ALL)

        'Meldemonat definieren
        If Zinsertragsmonatmeldung.StartsWith("Januar") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Jan[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Februar") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Feb[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("März") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Maerz[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("April") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].April[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Mai") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Mai[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Juni") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Juni[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Juli") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Juli[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("August") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Aug[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("September") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Sept[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Oktober") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Okt[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("November") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Nov[0]", "1")
        ElseIf Zinsertragsmonatmeldung.StartsWith("Dezember") = True Then
            pdfFormFields.SetField("topmostSubform[0].Page1[0].Dez[0]", "1")
        End If

        'Zinsertraege
        Dim ZINSERTRAG As Double = 0
        cmd.CommandText = "SELECT Case when (Select sum([AmountEuro]) FROM [ZINSERTRAG KUNDEN DETAILS]  where [IdZinsertragsMonat]='" & Zinsertragsmonatmeldung & "' and [KAPISTPFLICHTIG]='Y' and [KapertstG] >0) is not NULL then (Select sum([AmountEuro]) FROM [ZINSERTRAG KUNDEN DETAILS]  where [IdZinsertragsMonat]='" & Zinsertragsmonatmeldung & "' and [KAPISTPFLICHTIG]='Y' and [KapertstG] >0) else 0 end"
        cmd.Connection.Open()
        ZINSERTRAG = cmd.ExecuteScalar
        'Kapitalertargssteuer + Soli
        Dim KAPI As Double = 0
        cmd.CommandText = "SELECT [SummeKapErSt] FROM [ZINSERTRAG KUNDEN MONAT]  where [Zinsertragsmonat]='" & Zinsertragsmonatmeldung & "'"
        KAPI = Math.Truncate(cmd.ExecuteScalar)
        cmd.Connection.Close()
        Dim SOLI As Double = 0
        SOLI = KAPI * 0.055

        pdfFormFields.SetField("topmostSubform[0].Page1[0].Zinsertraege[0]", Format(ZINSERTRAG, "#,##0.00"))
        pdfFormFields.SetField("topmostSubform[0].Page1[0].KAPIST[0]", Format(KAPI, "#,##0"))
        pdfFormFields.SetField("topmostSubform[0].Page1[0].SOLI[0]", Format(SOLI, "#,##0.00"))

        'Kapitalertragssteuer an Bundesländer
        QueryText = "Select Sum([KapertstG]) as Kapi_Sum,BUNDESLAND from  [ZINSERTRAG KUNDEN DETAILS] where IdZinsertragsMonat='" & Zinsertragsmonatmeldung & "' and [KAPISTPFLICHTIG]='Y' and [KapertstG] is not NULL GROUP BY [BUNDESLAND]"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            'Dim SumKAPI As Double = FormatNumber(dt.Rows.Item(i).Item("Kapi_Sum"), 2)
            Dim SumKAPI As Double = Math.Truncate(dt.Rows.Item(i).Item("Kapi_Sum"))

            If dt.Rows.Item(i).Item("BUNDESLAND") = "BADEN-WÜRTTEMBERG" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BW[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BAYERN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BAY[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BERLIN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BER[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BRANDENBURG" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BRAN[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "BREMEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].BREM[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "HAMBURG" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].HAM[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "HESSEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].HES[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "MECKLENBURG-VORPOMMERN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].MECK[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "NIEDERSACHSEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].NIEDER[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "NORDRHEIN-WESTFALEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].NORD[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "RHEINLAND-PFALZ" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].RHEIN[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SAARLAND" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SAAR[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SACHSEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SACH[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SACHSEN-ANHALT" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SACHAN[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "SCHLESWIG-HOLSTEIN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].SCHLESW[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "THÜRINGEN" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].THUR[0]", Format(SumKAPI, "#,##0"))
            ElseIf dt.Rows.Item(i).Item("BUNDESLAND") = "" And SumKAPI <> 0 Then
                pdfFormFields.SetField("topmostSubform[0].Page2[0].None[0]", Format(SumKAPI, "#,##0"))
            End If
        Next

        ' flatten the form to remove editting options, set it to false
        ' to leave the form open to subsequent manual edits
        pdfStamper.FormFlattening = True

        ' close the pdf
        pdfStamper.Close()


        'Dim c As New PdfForm
        'c.MdiParent = Me
        'c.Show()
        'c.AxAcroPDF1.Visible = False
        'c.Text = "Kapitalertragsteueranmeldung für " & Zinsertragsmonatmeldung
        'Dim AxAcroPDF1 As New AxAcroPDFLib.AxAcroPDF
        'c.Controls.Add(AxAcroPDF1)
        'AxAcroPDF1.Dock = DockStyle.Fill
        'AxAcroPDF1.Enabled = True
        'AxAcroPDF1.TabIndex = 0
        'AxAcroPDF1.src = newFileSave
        'AxAcroPDF1.setShowToolbar(True)
        'AxAcroPDF1.Refresh()
        'c.Refresh()
        'c.AxAcroPDF1.LoadFile(newFileSave)
        'c.AxAcroPDF1.Show()
        'c.AxAcroPDF1.Refresh()


        'New Code for Dev PdfViewer
        Dim f As New PdfDevForm
        f.MdiParent = Me
        f.Show()
        f.Text = "Kapitalertragsteueranmeldung für " & Zinsertragsmonatmeldung
        f.PdfViewer1.LoadDocument(newFileSave)
        f.PdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible


        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub dxOK_EMPL_AVG_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MeldeJahr As String = DATESFORM_EMPL_AVG.ComboBoxEdit1.Text
        DATESFORM_EMPL_AVG.ComboBoxEdit1.Properties.Items.Clear()
        dxOK_EMPL_AVG.Dispose()
        DATESFORM_EMPL_AVG.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Erstellung des Durchschnittlichen Mitarbeiterstandes für " & MeldeJahr)

        Dim f As New EmployesAverage
        f.EMPLOYES_YEAR_AVERAGETableAdapter.Fill(f.MeldewesenDataSet.EMPLOYES_YEAR_AVERAGE)
        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\AVERAGE_EMPLOYES.rpt")
        CrRep.SetDataSource(f.MeldewesenDataSet)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        myValue.Value = MeldeJahr
        myParams.ParameterFieldName = "IdNr"
        myParams.CurrentValues.Add(myValue)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Durchschnittlicher Mitarbeiterstand für " & MeldeJahr
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)

    End Sub

#End Region

#Region "CLEARING TREELIST"

    Private Sub dxOK_VostroAccountsTransactionFees_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim d1 As Date = DF_ProfitLossReconcile.DateEdit1.Text
        Dim d2 As Date = DF_ProfitLossReconcile.DateEdit2.Text
        Dim rdsql1 As String = d1.ToString("yyyyMMdd")
        Dim rdsql2 As String = d2.ToString("yyyyMMdd")

        dxOK_VostroAccountsTransactionFees.Dispose()
        DF_ProfitLossReconcile.Close()



        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Vostro Transactions Fees from " & d1 & " till " & d2)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Vostro Transactions Fees" & vbNewLine & "Start loading Data to Excel File from " & d1 & " till " & d2)
            '+++++Get Excel File
            QueryText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='VostroFeesExcelFile' and [IdABTEILUNGSPARAMETER]='VOSTRO' and [PARAMETER STATUS]='Y'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim VostroTransactionFees_ExcelFileName As String = dt.Rows(0).Item("PARAMETER2").ToString
            dt.Clear()

            '**********DATA LOAD***********
            '******************************
            'Transactions
            'QueryText = "SELECT DISTINCT accountno, [other system key] FROM ALL_VOLUMES WHERE [product type] in ('00133166','00133168','00133170') and GL_REP_Date >= '" & rdsql1 & "'  and  GL_REP_Date <='" & rdsql2 & "' and [TRN Accounting Centre]=710334005 and CCY in ('EUR')  and accountno not in ('710334005978314101006500001') ORDER BY accountno asc"
            'da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt1 = New System.Data.DataTable()
            'da1.Fill(dt1)
            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('Vostro_Transactions') and Status in ('Y')"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New System.Data.DataTable()
                da2.Fill(dt2)
            End If


            'Totals
            'QueryText = "SELECT A.AccountNo,B.[English Name] FROM ALL_VOLUMES A INNER JOIN CUSTOMER_ACCOUNTS B on A.AccountNo=B.[Client Account] WHERE [product type] in ('00133166','00133168','00133170') and GL_REP_Date >= '" & rdsql1 & "'  and  GL_REP_Date <='" & rdsql2 & "' and [TRN Accounting Centre]=710334005 and CCY in ('EUR')  and accountno not in ('710334005978314101006500001') GROUP BY AccountNo,[English Name]  ORDER BY accountno asc"
            'da = New SqlDataAdapter(QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('Vostro_Charges') and Status in ('Y')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt3 = New System.Data.DataTable()
                da3.Fill(dt3)
            End If

            SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
            workbook.LoadDocument(VostroTransactionFees_ExcelFileName, DocumentFormat.Xlsx)
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            Dim worksheet1 As Worksheet = workbook.Worksheets(1)
            'workbook.Worksheets(0).Cells("D1").Value = rd
            'workbook.Worksheets(0).Cells("AD1").Value = NextWorkingDate

            SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
            worksheet.ClearContents(worksheet("A2:E60000"))
            worksheet1.ClearContents(worksheet1("A2:B60000"))

            SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
            worksheet1.Import(dt2, False, 1, 0)
            worksheet.Import(dt3, False, 1, 0)

            Dim VostroTransactionFees_LastDtRow As Integer = dt3.Rows.Count + 1
            Dim DETAILS_LastRow As Integer = dt2.Rows.Count + 1
            Dim RangeVostroTransactionFees_C As CellRange = worksheet.Range("C2:C" & VostroTransactionFees_LastDtRow) 'Trade Date Buy Sell Amount
            RangeVostroTransactionFees_C.Formula = "=COUNTIF(Details!$A$2:$A$" & DETAILS_LastRow & ";A2)"
            Dim RangeVostroTransactionFees_D As CellRange = worksheet.Range("D2:D" & VostroTransactionFees_LastDtRow) 'Trade Date Buy Sell Amount
            RangeVostroTransactionFees_D.Formula = "=IF(A2=""1500100007"";0,8;1)"
            Dim RangeVostroTransactionFees_E As CellRange = worksheet.Range("E2:E" & VostroTransactionFees_LastDtRow) 'Amortization to Risk Date
            RangeVostroTransactionFees_E.Formula = "=C2*D2"

            'Adding Summ Formulas at Runtime
            Dim AddSumFormula As Integer = dt3.Rows.Count + 3
            Dim ExcelCell As String = Nothing
            Dim cell As DevExpress.Spreadsheet.Cell = Nothing
            ExcelCell = "A" & AddSumFormula
            workbook.Worksheets(0).Cells(ExcelCell).Value = "Sum"
            ExcelCell = "C" & AddSumFormula
            workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(C2:C" & VostroTransactionFees_LastDtRow & ")"
            ExcelCell = "E" & AddSumFormula
            workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(E2:E" & VostroTransactionFees_LastDtRow & ")"

            'Save Excel File
            workbook.SaveDocument(VostroTransactionFees_ExcelFileName, DocumentFormat.OpenXml)

            'Load Excel Form
            Dim c As New ExcelForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "Vostro Transactions Fees results from " & d1 & " till " & d2
            c.SpreadsheetControl1.ReadOnly = True

            workbookN = c.SpreadsheetControl1.Document
            Using stream As New FileStream(VostroTransactionFees_ExcelFileName, FileMode.Open)
                workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
            End Using


            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try


    End Sub

    Private Sub dxOK_ZVDL_Report_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim d1 As Date = DF_ProfitLossReconcile.DateEdit1.Text
        Dim d2 As Date = DF_ProfitLossReconcile.DateEdit2.Text
        Dim rdsql1 As String = d1.ToString("yyyyMMdd")
        Dim rdsql2 As String = d2.ToString("yyyyMMdd")

        dxOK_ZVDL_Report.Dispose()
        DF_ProfitLossReconcile.Close()

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Check if Payments present till " & d2)
        QueryText = "select Max(RegisterDate) as 'MaxDate' from [GMPS PAYMENTS OUT]"
        da4 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt4 = New System.Data.DataTable()
        da4.Fill(dt4)
        Dim MaxDate As Date = dt4.Rows(0).Item("MaxDate").ToString
        SplashScreenManager.CloseForm(False)
        If d2 > MaxDate Then
            XtraMessageBox.Show("The maximum Payments date is  " & MaxDate & vbNewLine & "Please define your query till " & MaxDate, "TILL DATE HIGHER THAN MAXIMUM PAYMENTS DATE", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return
        End If

        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating ZVDL Report from " & d1 & " till " & d2)
            SplashScreenManager.Default.SetWaitFormCaption("Creating ZVDL Report" & vbNewLine & "Start loading Data to Excel File from " & d1 & " till " & d2)
            '+++++Get Excel File
            QueryText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='ZVDL_Report_ExcelFile' and [IdABTEILUNGSPARAMETER]='ZVDL' and [PARAMETER STATUS]='Y'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            Dim ZVDL_Report_ExcelFileName As String = dt.Rows(0).Item("PARAMETER2").ToString
            dt.Clear()

            '**********DATA LOAD***********
            '******************************
            'Transactions
            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('ZVDL_Transactions') and Status in ('Y')"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)

            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New System.Data.DataTable()
                da2.Fill(dt2)
            End If
            'Totals
            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('ZVDL_Totals') and Status in ('Y')"
            da = New SqlDataAdapter(QueryText.Trim(), conn)

            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SqlCommandText = dt.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt3 = New System.Data.DataTable()
                da3.Fill(dt3)
            End If
            SplashScreenManager.Default.SetWaitFormCaption("Update Excel File with current Data for the Calculation")
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
            workbook.LoadDocument(ZVDL_Report_ExcelFileName, DocumentFormat.Xlsx)
            Dim worksheet As Worksheet = workbook.Worksheets(0)
            Dim worksheet1 As Worksheet = workbook.Worksheets(1)
            'workbook.Worksheets(0).Cells("D1").Value = rd
            'workbook.Worksheets(0).Cells("AD1").Value = NextWorkingDate

            SplashScreenManager.Default.SetWaitFormCaption("Clear Contents in Excel Cell Ranges before importing new Data")
            worksheet.ClearContents(worksheet("A3:E60000"))
            worksheet1.ClearContents(worksheet1("A3:X60000"))
            'worksheet.ClearFormats(worksheet("A4:E60000"))
            'worksheet1.ClearFormats(worksheet1("A3:U60000"))

            SplashScreenManager.Default.SetWaitFormCaption("Import new Data to Excel File")
            worksheet1.Import(dt2, False, 2, 0) 'Details
            worksheet.Import(dt3, False, 2, 0) 'Totals

            Dim ZVDL_Totals_LastDtRow As Integer = dt3.Rows.Count + 2
            Dim ZVDL_Details_LastRow As Integer = dt2.Rows.Count + 2
            Dim RangeZVDL_Totals_C As CellRange = worksheet.Range("C3:C" & ZVDL_Totals_LastDtRow) 'Trade Date Buy Sell Amount
            'RangeZVDL_Totals_C.Formula = "=COUNTIF(Details!$D$3:$D$" & ZVDL_Details_LastRow & ";A4)"
            Dim RangeZVDL_Totals_D As CellRange = worksheet.Range("D3:D" & ZVDL_Totals_LastDtRow) 'Trade Date Buy Sell Amount
            RangeZVDL_Totals_D.Formula = "=COUNTIFS(Details!$D$3:$D$" & ZVDL_Details_LastRow & ";A3;Details!$W$3:$W$" & ZVDL_Details_LastRow & ";""=Y"")"
            Dim RangeZVDL_Totals_E As CellRange = worksheet.Range("E3:E" & ZVDL_Totals_LastDtRow) 'Amortization to Risk Date
            RangeZVDL_Totals_E.Formula = "=IF(C3<>0;D3/C3;0)"

            'Adding Summ Formulas at Runtime
            Dim AddSumFormula As Integer = ZVDL_Totals_LastDtRow + 1
            Dim ExcelCell As String = Nothing
            Dim cell As DevExpress.Spreadsheet.Cell = Nothing
            'ExcelCell = "A" & AddSumFormula
            'workbook.Worksheets(0).Cells(ExcelCell).Value = "Sum"

            ExcelCell = "C" & AddSumFormula
            workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(C3:C" & ZVDL_Totals_LastDtRow & ")"
            ExcelCell = "D" & AddSumFormula
            workbook.Worksheets(0).Cells(ExcelCell).Formula = "=SUM(D3:D" & ZVDL_Totals_LastDtRow & ")"
            ExcelCell = "E" & AddSumFormula
            workbook.Worksheets(0).Cells(ExcelCell).Formula = "=IF(D" & AddSumFormula & "<>0;D" & AddSumFormula & "/C" & AddSumFormula & ";0)"

            workbook.Worksheets(0).Cells("A1").Value = "ZVDL Report von:" & d1 & " bis " & d2
            workbook.Worksheets(1).Cells("A1").Value = "Eingehende Zahlungen von:" & d1 & " bis " & d2
            'Save Excel File
            workbook.SaveDocument(ZVDL_Report_ExcelFileName, DocumentFormat.OpenXml)

            'Load Excel Form
            Dim c As New ExcelForm
            c.MdiParent = Me
            c.Show()
            c.WindowState = FormWindowState.Maximized

            c.Text = "ZVDL Report from " & d1 & " till " & d2
            c.SpreadsheetControl1.ReadOnly = True

            workbookN = c.SpreadsheetControl1.Document
            Using stream As New FileStream(ZVDL_Report_ExcelFileName, FileMode.Open)
                workbookN.LoadDocument(stream, DocumentFormat.Xlsx)
            End Using


            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Try
        End Try


    End Sub
#End Region

#End Region




    Private Sub PSTOOL_MAIN_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        objMutex = New Mutex(False, "PS TOOL DX")
        If objMutex.WaitOne(0, False) = True Then
            If cmd.Connection.State <> ConnectionState.Broken Then
                Try
                    OpenSqlConnections()
                    cmd.CommandText = "DELETE FROM [CURRENT USERS] where [UserName]='" & SystemInformation.UserName & "' and [SessionID]='" & PSTOOL_SessionID & "'"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    objMutex.Close()
                    objMutex = Nothing
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    XtraMessageBox.Show("PS TOOL will be closed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CloseSqlConnections()
                    Application.Exit()
                End Try
            End If
            If cmd.Connection.State = ConnectionState.Broken Then
                Try
                    XtraMessageBox.Show("PS TOOL will be closed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Application.Exit()
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    XtraMessageBox.Show("PS TOOL will be closed!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Application.Exit()
                End Try

            End If
        End If
    End Sub


#Region "ALLERT CONTROL - UNRATED CUSTOMERS"

    Private Sub AlertControl_UnratedCustomers_AlertClick(sender As Object, e As AlertClickEventArgs) Handles AlertControl_UnratedCustomers.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER RATINGS")
        ' Place code here
        Dim c As New CustomerRating

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.CustomerRating_BaseView.ActiveFilterString = "[Rating]='U'"

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub AlertControl_UnratedCustomers_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles AlertControl_UnratedCustomers.BeforeFormShow
        'e.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        'e.Location = New Point(1600, 1100)

    End Sub


    Private Sub AlertControl_UnratedCustomers_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_UnratedCustomers.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
        e.Buttons.CloseButton.Visible = False
    End Sub

    Private Sub HandleTextChanged_UnratedCustomersTextEdit(sender As Object, e As EventArgs)
        If UnratedCustomersTextEdit.Text <> "0" AndAlso UNRATED_CUSTOMERS_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Or RISKCONTROLLING_USER = "Y" Then
                Dim InfoText As String = "There are " & Me.UnratedCustomersTextEdit.Text & " Unrated Customers in the Customer Ratting Table"
                Dim info As AlertInfo = New AlertInfo("UNRATED CUSTOMERS FUND", InfoText)

                For Each Form As AlertForm In AlertControl_UnratedCustomers.AlertFormList
                    Form.Close()
                Next
                AlertControl_UnratedCustomers.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In AlertControl_UnratedCustomers.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

#End Region

#Region "ALERT CONTROL - IMPORT ERRORS"


    Private Sub HandleTextChanged_ImportErrorsTextEdit(sender As Object, e As EventArgs)

        If ImportErrorsTextEdit.Text <> "0" AndAlso IMPORT_ERRORS_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "There are " & Me.ImportErrorsTextEdit.Text & " import errors in ODAS/NGS Procedures.Please click on this Text to see the Import Events!"
                Dim info As AlertInfo = New AlertInfo("ODAS/NGS IMPORT ERRORS FUND", InfoText)
                For Each Form As AlertForm In AlertControl_ImportErrors.AlertFormList
                    Form.Close()
                Next
                For Each Form As AlertForm In AlertControl_ImportErrors.AlertFormList
                    Form.Close()
                Next
                AlertControl_ImportErrors.Show(Me, info)
            End If
        Else
            'Dim i As Integer
            'For i = 0 To AlertControl_ImportErrors.AlertFormList.Count - 1
            'AlertControl_ImportErrors.AlertFormList(i).Dispose()
            'Next
            For Each Form As AlertForm In AlertControl_ImportErrors.AlertFormList
                Form.Close()
            Next

        End If
    End Sub

    Private Sub AlertControl_ImportErrors_AlertClick(sender As Object, e As AlertClickEventArgs) Handles AlertControl_ImportErrors.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("IMPORT EVENTS")
        ' Place code here
        Dim c As New ImportEvents

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub AlertControl_ImportErrors_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles AlertControl_ImportErrors.BeforeFormShow
        'e.Location = New Point(1600, 1100)
    End Sub

    Private Sub AlertControl_ImportErrors_ButtonClick(sender As Object, e As AlertButtonClickEventArgs) Handles AlertControl_ImportErrors.ButtonClick

        If e.Button.Name = "DeleteErros_btn" Then
            If XtraMessageBox.Show("Should all Error Messages in Import Events be deleted?", "DELETION OF ERROR MESSAGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "DELETE FROM [IMPORT EVENTS] where  [Event] like 'ERROR%' and [SystemName] in ('ODAS','OCBS','NGS')"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If
        End If
    End Sub

    Private Sub AlertControl_ImportErrors_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_ImportErrors.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
        e.Buttons.CloseButton.Visible = False
    End Sub

#End Region

#Region "ALERT CONTROL - KUNDEN OHNE PLZ/BUNDESLAND"

    Private Sub HandleTextChanged_EAEG_Kunden_AddresseNameValid_TextEdit(sender As Object, e As EventArgs)
        If EAEG_Kunden_AddresseNameValid_TextEdit.Text <> "0" AndAlso EAEG_KUNDEN_AENDERUNG_ALERT = "Y" Then
            'Alerts only for EDP User
            If EAEG_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "Es wurden " & Me.EAEG_Kunden_AddresseNameValid_TextEdit.Text & " EAEG Kunden gefunden mit neuer Addresse bzw. neuen Namen"
                Dim info As AlertInfo = New AlertInfo("EAEG KUNDEN MIT NEUER ADDRESSE bzw. NEUEN NAMEN", InfoText)
                For Each Form As AlertForm In AlertControl_PLZ_Bundesland.AlertFormList
                    Form.Close()
                Next
                AlertControl_PLZ_Bundesland.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In AlertControl_PLZ_Bundesland.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub AlertControl_PLZ_Bundesland_AlertClick(sender As Object, e As AlertClickEventArgs) Handles AlertControl_PLZ_Bundesland.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("EAEG KUNDEN-STAMM DATEN")
        ' Place code here
        Dim c As New EAEG_StammDaten

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.EAEG_StammDaten_BaseView.ActiveFilterString = "[Adresse_Valid]='N' and [Status]='Y'"
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub AlertControl_PLZ_Bundesland_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_PLZ_Bundesland.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region ' FÜR ADDRESSENÄNDERUNG oder NAMENSÄNDERUNG BEI EAEG STAMM DATEN

#Region "ALERT CONTROL - ONLINE BANKING ACCOUNTS"

    Private Sub AlertControl_OnlineBanking_AlertClick(sender As Object, e As AlertClickEventArgs) Handles AlertControl_OnlineBanking.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER ACCOUNTS")
        ' Place code here
        Dim c As New CustomerAccounts

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.CustomerAccountsBaseView.ActiveFilterString = "[Account Status]='C - CLOSE' and [Online]='Y'"

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub HandleTextChanged_OnlineAccountsDeletedTextEdit(sender As Object, e As EventArgs)
        If OnlineAccountsDeletedTextEdit.Text <> "0" AndAlso ONLINE_BANKING_ACCOUNTS_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "Es wurden " & Me.OnlineAccountsDeletedTextEdit.Text & " gelöschte Konten gefunden mit aktiven Online Banking"
                Dim info As AlertInfo = New AlertInfo("GELÖSCHTE ONLINE KONTEN", InfoText)
                For Each Form As AlertForm In AlertControl_OnlineBanking.AlertFormList
                    Form.Close()
                Next
                AlertControl_OnlineBanking.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In AlertControl_OnlineBanking.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub AlertControl_OnlineBanking_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_OnlineBanking.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region

#Region "ALERT CONTROL _ EAEG KUNDEN STRASSE/PLZ"
    Private Sub HandleTextChanged_EAEG_Kunden_Geburtsdatum_TextEdit(sender As Object, e As EventArgs)
        If EAEG_Kunden_Geburtsdatum_TextEdit.Text <> "0" AndAlso EAEG_KUNDEN_NEU_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "Es wurden " & Me.EAEG_Kunden_Geburtsdatum_TextEdit.Text & " EAEG Kunden gefunden ohne Strasse/Ort"
                Dim info As AlertInfo = New AlertInfo("EAEG KUNDEN OHNE STRASSE/ORT", InfoText)
                For Each Form As AlertForm In AlertControl_EAEG_Kunden_Geburtsdatum.AlertFormList
                    Form.Close()
                Next
                AlertControl_EAEG_Kunden_Geburtsdatum.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In AlertControl_EAEG_Kunden_Geburtsdatum.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub AlertControl_EAEG_Kunden_Geburtsdatum_AlertClick(sender As Object, e As AlertClickEventArgs) Handles AlertControl_EAEG_Kunden_Geburtsdatum.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("EAEG Stamm Daten")
        ' Place code here
        Dim c As New EAEG_StammDaten

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.EAEG_StammDaten_BaseView.ActiveFilterString = "([B9_Postleitzahl] is NULL or [B9_Postleitzahl]='' or [B7_SrasseUndHausnummer] is NULL or [B7_SrasseUndHausnummer]='') and [Status]='Y'"

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub AlertControl_EAEG_Kunden_Geburtsdatum_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_EAEG_Kunden_Geburtsdatum.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region

#Region "ALERT CONTROL _ NEU USER ACTIVE DIRECTORY"
    Private Sub HandleTextChanged_NewUser_ActiveDirectory_TextEdit(sender As Object, e As EventArgs)
        If NewUser_ActiveDirectory_TextEdit.Text <> "0" AndAlso ACTIVE_DIRECTORY_NEW_USER_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "There are " & Me.NewUser_ActiveDirectory_TextEdit.Text & " new Personal Users in the Active Directory" & vbNewLine & "Please enter Title, Name and Surname"
                Dim info As AlertInfo = New AlertInfo("NEW PERSONAL USERS IN ACTIVE DIRECTORY", InfoText)
                For Each Form As AlertForm In AlertControl_NewUser_ActiveDirectory.AlertFormList
                    Form.Close()
                Next
                AlertControl_NewUser_ActiveDirectory.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In AlertControl_NewUser_ActiveDirectory.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub AlertControl_NewUser_ActiveDirectory_AlertClick(sender As Object, e As AlertClickEventArgs) Handles AlertControl_NewUser_ActiveDirectory.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Active Directory - New Personal Users")
        ' Place code here
        Dim c As New UserDirectoryPermissions

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.Users_TOTAL_GridView.ActiveFilterString = "[NonPersonalUser]=false And [AccountStatus]='*ENABLED' And ([Name] is NULL Or [Name]='' Or [Surname] is NULL Or [Surname]='' Or [Title] is NULL)"

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub



    Private Sub AlertControl_NewUser_ActiveDirectory_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_NewUser_ActiveDirectory.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region

#Region "ALERT CONTROL _ GENERAL INFO"
    Private Sub HandleTextChanged_GeneralInfo_TextEdit(sender As Object, e As EventArgs)
        If GeneralInfo_TextEdit.Text <> "0" Then
            'Create Info Datatable
            Dim GeneralInfoDate As Date = DateSerial(Microsoft.VisualBasic.Left(LastOdasFileNumber, 4), Mid(LastOdasFileNumber, 5, 2), Microsoft.VisualBasic.Right(LastOdasFileNumber, 2))
            Dim dtInfo = New DataTable()
            Dim dcID = New DataColumn("ID", GetType(Int32))
            Dim dcName = New DataColumn("Name", GetType(String))
            Dim dcAmount = New DataColumn("Amount", GetType(Double))
            dtInfo.Columns.Add(dcID)
            dtInfo.Columns.Add(dcName)
            dtInfo.Columns.Add(dcAmount)
            'Sum Activa
            QueryText = "Select Sum([BalanceEUREqu]) as SA from DailyBalanceSheets where [BSDate]='" & LastOdasFileNumber & "' and [GL_Item_Number]=2999"
            daInfo = New SqlDataAdapter(QueryText.Trim(), connSYSTEM)
            daInfo.Fill(dtInfo)
            dtInfo.Rows.Add(1, "Sum Activa", dtInfo.Rows.Item(0).Item("SA"))
            'Sum Passiva
            QueryText = "Select Sum([BalanceEUREqu]) as SP from DailyBalanceSheets where [BSDate]='" & LastOdasFileNumber & "' and [GL_Item_Number]=4999"
            Dim dainfo1 As SqlDataAdapter
            Dim dtInfo1 = New DataTable()
            dainfo1 = New SqlDataAdapter(QueryText.Trim(), connSYSTEM)
            dainfo1.Fill(dtInfo1)
            dtInfo.Rows.Add(2, "Sum Passiva", dtInfo1.Rows.Item(0).Item("SP"))
            'Difference
            QueryText = "Select Round(Sum(A.SA),2) as SP from (Select Sum([BalanceEUREqu]) as SA from DailyBalanceSheets where [BSDate]='" & LastOdasFileNumber & "'  and [GL_Item_Number]=2999 Union all Select Sum([BalanceEUREqu]) as SA from DailyBalanceSheets where [BSDate]='" & LastOdasFileNumber & "' and [GL_Item_Number]=4999)A"
            Dim dainfo2 As SqlDataAdapter
            Dim dtInfo2 = New DataTable()
            dainfo2 = New SqlDataAdapter(QueryText.Trim(), connSYSTEM)
            dainfo2.Fill(dtInfo2)
            dtInfo.Rows.Add(3, "Difference Activa/Passiva", dtInfo2.Rows.Item(0).Item("SP"))
            'Profit-Loss
            QueryText = "Select Round(Sum(A.SA),2) as SP from (Select Sum([BalanceEUREqu]) as SA from DailyBalanceSheets where [BSDate]='" & LastOdasFileNumber & "'  and [GL_Item_Number]>=5000 and [GL_Item_Number]<6998 Union all Select Sum([BalanceEUREqu]) as SA from DailyBalanceSheets where [BSDate]='" & LastOdasFileNumber & "' and [GL_Item_Number]>=7000 and [GL_Item_Number]<7998)A"
            Dim dainfo3 As SqlDataAdapter
            Dim dtInfo3 = New DataTable()
            dainfo3 = New SqlDataAdapter(QueryText.Trim(), connSYSTEM)
            dainfo3.Fill(dtInfo3)
            dtInfo.Rows.Add(4, "Profit-Loss", dtInfo3.Rows.Item(0).Item("SP"))


            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = ""
                daInfo.Fill(dtInfo)
                For i = 0 To dtInfo.Rows.Count - 1
                    If IsDBNull(dtInfo.Rows.Item(i).Item("Amount")) = False Then
                        Dim Amount As Double = dtInfo.Rows.Item(i).Item("Amount")
                        InfoText += dtInfo.Rows.Item(i).Item("Name") & "   " & FormatNumber(Amount, 2) & vbNewLine
                    End If


                Next
                Dim info As AlertInfo = New AlertInfo("GENERAL INFO for " & GeneralInfoDate, InfoText)
                For Each Form As AlertForm In AlertControl_General_Info.AlertFormList
                    Form.Close()
                Next
                AlertControl_General_Info.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In AlertControl_General_Info.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub AlertControl_General_Info_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles AlertControl_General_Info.BeforeFormShow
        'e.AlertForm.Size = New Size(500, 1000)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
    End Sub



    Private Sub AlertControl_General_Info_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles AlertControl_General_Info.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region

#Region "ALERT CONTROL _ NOSTRO ACCOUNT WITHOUT STATEMENT INDICATION"
    Private Sub HandleTextChanged_NostroAccount_TextEdit(sender As Object, e As EventArgs)
        If NostroAccount_TextEdit.Text <> "0" AndAlso NOSTRO_ACC_WITHOUT_STATEMENT_INDICATION_ALERT = "Y" Then
            QueryText = "Select * from [SSIS] where ([AccountIdentifierStatement] is  NULL or AccountIdentifierStatement='') and [VALID]='Y'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                Dim InfoText As String = "For the following Internal Nostro Accounts there's no Account Identifier Statement indicated!"
                Dim infoCustomer As String = ""
                For i = 0 To dt.Rows.Count - 1
                    infoCustomer += dt.Rows.Item(i).Item("NOSTRO_NAME") & "   " & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & vbNewLine
                Next
                Dim info As AlertInfo = New AlertInfo("Unknown Account Identifier Statement", InfoText & vbNewLine & infoCustomer & vbNewLine & vbNewLine & "Please input missing Data!")
                For Each Form As AlertForm In Alert_NostroAccount.AlertFormList
                    Form.Close()
                Next
                Alert_NostroAccount.Show(Me, info)

            End If
        Else
            For Each Form As AlertForm In Alert_NostroAccount.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_NostroAccount_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_NostroAccount.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Nostro (LORO) Accounts without Account Statement Identifier")
        ' Place code here
        Dim c As New Ssis

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.SSISBaseView.ActiveFilterString = "[VALID]='Y' and ([AccountIdentifierStatement] is NULL Or [AccountIdentifierStatement]='')"

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_NostroAccount_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_NostroAccount.BeforeFormShow
        e.AlertForm.Size = New Size(500, 500)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
    End Sub

    Private Sub Alert_NostroAccount_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_NostroAccount.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region

#Region "ALERT CONTROL _ END DATE BUNDESBANK RESERVE NOT DEFINED"
    Private Sub HandleTextChanged_MindestReserveBUBA_TextEdit(sender As Object, e As EventArgs)
        If MindestReserveBUBA_TextEdit.Text <> "0" AndAlso BUNDESBANK_RESERVE_END_DATE_ALERT = "Y" Then

            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "There's no Minimal Bundesbank Reserve Date defined for the future!"
                Dim infoCustomer As String = "The daily calculation of the total Interests in the Bundesbank Account is not executed!"

                Dim info As AlertInfo = New AlertInfo("Future Minimal Bundesbank Reserve Date is missing! ", InfoText & vbNewLine & infoCustomer & vbNewLine & vbNewLine & "Please define Date!")
                For Each Form As AlertForm In Alert_MindestReserveBUBA.AlertFormList
                    Form.Close()
                Next
                Alert_MindestReserveBUBA.Show(Me, info)
            End If


        Else

            For Each Form As AlertForm In Alert_MindestReserveBUBA.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_MindestReserveBUBA_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_MindestReserveBUBA.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Calendar")
        ' Place code here
        Dim c As New Calendar

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_MindestReserveBUBA_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_MindestReserveBUBA.BeforeFormShow
        e.AlertForm.Size = New Size(500, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly

    End Sub

    Private Sub Alert_MindestReserveBUBA_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_MindestReserveBUBA.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub
#End Region

#Region "ALERT CONTROL _ TARGET HOLIDAY NOT DEFINED"
    Private Sub HandleTextChanged_TargetHolidays_TextEdit(sender As Object, e As EventArgs)
        If TargetHolidays_TextEdit.Text <> "0" AndAlso TARGET_HOLIDAY_ALERT = "Y" Then

            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "There's no TARGET Holidays defined for the future!"
                Dim infoCustomer As String = "The definition of the TARGET Holidays are mandatory in order to get the correct TARGET working Days for several calculations!"

                Dim info As AlertInfo = New AlertInfo("Future TARGET Holidays are missing! ", InfoText & vbNewLine & infoCustomer & vbNewLine & vbNewLine & "Please define future TARGET Holidays!")
                For Each Form As AlertForm In Alert_TargetHolidays.AlertFormList
                    Form.Close()
                Next
                Alert_TargetHolidays.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In Alert_TargetHolidays.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_TargetHolidays_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_TargetHolidays.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Calendar")
        ' Place code here
        Dim c As New Calendar

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Normal
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_TargetHolidays_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_TargetHolidays.BeforeFormShow
        e.AlertForm.Size = New Size(500, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly

    End Sub

    Private Sub Alert_TargetHolidays_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_TargetHolidays.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub
#End Region

#Region "ALERT CONTROL _ UPDATE ODAS FX DEALS ALL"

    Private Sub HandleTextChanged_UPDATE_FX_Deals_ALL_TextEdit(sender As Object, e As EventArgs)
        If UPDATE_FX_Deals_ALL_TextEdit.Text <> "" AndAlso UPDATE_ODAS_FX_DEALS = "Y" Then
            FX_ALL_AFTER_UPDATE_Date = UPDATE_FX_Deals_ALL_TextEdit.Text
            If FX_ALL_LAST_UPDATE_Date <> FX_ALL_AFTER_UPDATE_Date Then
                'ALERT CONTROL SHOW IF FX DEALS ALL ARE UPDATED
                If TREASURY_USER = "Y" Then
                    Dim InfoText As String = "Attention: TREASURY DEPARTMENT!"
                    Dim infoCustomer As String = "The ODAS FX Deals list has being imported to the PS TOOL Database!"

                    Dim info As AlertInfo = New AlertInfo("ODAS FX Deals import on " & Today, InfoText & vbNewLine & infoCustomer & vbNewLine & vbNewLine & "Please check FX Deals for funding SWAPS and Pairs!!", Me.ImageCollection1.Images.Item(7))
                    For Each Form As AlertForm In Alert_UPDATE_FX_Deals_ALL.AlertFormList
                        Form.Close()
                    Next
                    Alert_UPDATE_FX_Deals_ALL.Show(Me, info)
                End If
            End If
        Else

            For Each Form As AlertForm In Alert_UPDATE_FX_Deals_ALL.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_UPDATE_FX_Deals_ALL_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_UPDATE_FX_Deals_ALL.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("All FX Deals")
        ' Place code here
        Dim c As New Fx_Deals_ALL

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                kf.TopMost = True
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_UPDATE_FX_Deals_ALL_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_UPDATE_FX_Deals_ALL.BeforeFormShow
        e.AlertForm.Size = New Size(300, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly



    End Sub

    Private Sub Alert_UPDATE_FX_Deals_ALL_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_UPDATE_FX_Deals_ALL.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region

#Region "ALERT CONTROL - NEW CUSTOMER"
    Private Sub HandleTextChanged_NewCustomer_TextEdit(sender As Object, e As EventArgs)
        If NewCustomer_TextEdit.Text <> "0" AndAlso NEW_CUSTOMER_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = "There are " & Me.NewCustomer_TextEdit.Text & " customer with mandatory fields undefined!" & vbNewLine & "Please set up the following undefined fields:" & vbNewLine & "1. CCB Group" & vbNewLine & "2. CCB Group (Subsidiary)" & vbNewLine & "3. CIC Group"
                Dim info As AlertInfo = New AlertInfo("CUSTOMERS MANDATORY FIELDS UNDEFINED", InfoText)
                For Each Form As AlertForm In Alert_NEW_CUSTOMER.AlertFormList
                    Form.Close()
                Next
                Alert_NEW_CUSTOMER.Show(Me, info)
            End If
        Else
            For Each Form As AlertForm In Alert_NEW_CUSTOMER.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_NEW_CUSTOMER_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_NEW_CUSTOMER.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMERS")
        ' Place code here
        Dim c As New Customers

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me

        c.Show()
        c.CustomerBaseView.ActiveFilterString = "[CCB_Group]='U' or [CCB_Group_OwnID]='U' or [CIC_Group]='U'"

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_NEW_CUSTOMER_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_NEW_CUSTOMER.BeforeFormShow
        e.AlertForm.Size = New Size(300, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly



    End Sub

    Private Sub Alert_NEW_CUSTOMER_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_NEW_CUSTOMER.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub


#End Region

#Region "ALERT CONTROL - NEW CURRENCY"
    Private Sub HandleTextChanged_NewCurrency_TextEdit(sender As Object, e As EventArgs)
        If NewCurrency_TextEdit.Text <> "0" AndAlso NEW_CURRENCY_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then
                Dim InfoText As String = ""
                Dim info As AlertInfo = New AlertInfo("", InfoText)

                QueryText = "SELECT A.[CURRENCY CODE],B.[CURRENCY NAME] FROM [SSIS] A INNER JOIN CURRENCIES B on A.[CURRENCY CODE]=B.[CURRENCY CODE] where A.[CURRENCY CODE] not in (Select [CURRENCY CODE] from OWN_CURRENCIES)"
                da = New SqlDataAdapter(QueryText.Trim(), connSYSTEM)
                dt = New System.Data.DataTable()
                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    InfoText = "New Nostro Account Currency not included in Internal Currencies"
                    Dim infoCurrency As String = ""
                    For i = 0 To dt.Rows.Count - 1
                        infoCurrency += dt.Rows.Item(i).Item("CURRENCY CODE") & "   " & dt.Rows.Item(i).Item("CURRENCY NAME") & vbNewLine
                    Next
                    info = New AlertInfo("New Nostro Account Currency", InfoText & vbNewLine & infoCurrency & vbNewLine & vbNewLine & "Please insert Currency in the Internal Currencies Form!")

                End If

                For Each Form As AlertForm In Alert_NEW_CURRENCY.AlertFormList
                    Form.Close()
                Next
                Alert_NEW_CURRENCY.Show(Me, info)

            End If
        Else
            For Each Form As AlertForm In Alert_NEW_CURRENCY.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_NEW_CURRENCY_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_NEW_CURRENCY.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("INTERNAL CURRENCIES")
        ' Place code here
        Dim c As New InternalCurrencies

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_NEW_CURRENCY_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_NEW_CURRENCY.BeforeFormShow
        e.AlertForm.Size = New Size(300, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly



    End Sub

    Private Sub Alert_NEW_CURRENCY_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_NEW_CURRENCY.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub


#End Region

#Region "ALERT CONTROL - BALANCE SHEET DIFFERENCE"
    Private Sub HandleTextChanged_BS_Difference_TextEdit(sender As Object, e As EventArgs)
        If BS_Difference_TextEdit.Text <> "0" AndAlso BS_DIFFERENCE_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Or ACCOUNTING_USER = "Y" Then
                Dim InfoText As String = ""
                Dim info As AlertInfo = New AlertInfo("", InfoText)

                QueryText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('BS_Difference') and [RiskDate] in (Select Max(RiskDate) from GeneralDataInfo)"
                da = New SqlDataAdapter(QueryText.Trim(), connSYSTEM)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                Dim BS_DIFFERENCE As Double = dt.Rows.Item(0).Item("Amount1")


                InfoText = "Balance Sheet Difference"
                Dim infoDifference As String = "There's a Balance Sheet Difference of" & vbNewLine & "EUR " & FormatNumber(BS_DIFFERENCE, 2)

                info.Image = Me.ImageCollection1.Images(11)
                info = New AlertInfo("Balance Sheet Difference on last Business Date", InfoText & vbNewLine & infoDifference & vbNewLine & vbNewLine & "Please check and correct the Balance Sheet Difference!")

                For Each Form As AlertForm In Alert_BS_DIFFERENCE.AlertFormList
                    Form.Close()
                Next
                Alert_BS_DIFFERENCE.Show(Me, info)

            End If
        Else
            For Each Form As AlertForm In Alert_BS_DIFFERENCE.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_BS_DIFFERENCE_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_BS_DIFFERENCE.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("DAILY BALANCE SHEET")
        ' Place code here
        Dim c As New DailyBalanceSheets

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_BS_DIFFERENCE_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_BS_DIFFERENCE.BeforeFormShow
        e.AlertForm.Size = New Size(300, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        'e.AlertForm.Info.Image = Me.ImageCollection1.Images(11)



    End Sub

    Private Sub Alert_BS_DIFFERENCE_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_BS_DIFFERENCE.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub


#End Region

#Region "ALERT CONTROL - CLIENT GROUP RESIDENCE COUNTRY NUMMERIC"
    Private Sub HandleTextChanged_GroupCountriesNummeric_TextEdit(sender As Object, e As EventArgs)
        If GroupCountriesNummeric_TextEdit.Text <> "0" AndAlso GROUP_COUNTRIES_NUMMERIC_ALERT = "Y" Then
            'Alerts only for EDP User
            If EDP_USER = "Y" Or SUPER_USER = "Y" Then

                Dim InfoText As String = "There is at least one Client Group with nummeric value in Country of Residence!!" & vbNewLine & "Please contact Credit Department for correction in BAIS as follows:" & vbNewLine & "Allways select Value in column:Eigendefinierter Länderschl."
                Dim info As AlertInfo = New AlertInfo("CLIENT GROUP COUNTRY OF RESIDENCE IS NUMMERIC", InfoText)

                For Each Form As AlertForm In Alert_GROUP_COUNTRIES_NUMMERIC.AlertFormList
                    Form.Close()
                Next
                Alert_GROUP_COUNTRIES_NUMMERIC.Show(Me, info)

            End If
        Else
            For Each Form As AlertForm In Alert_GROUP_COUNTRIES_NUMMERIC.AlertFormList
                Form.Close()
            Next
        End If
    End Sub

    Private Sub Alert_GROUP_COUNTRIES_NUMMERIC_AlertClick(sender As Object, e As AlertClickEventArgs) Handles Alert_GROUP_COUNTRIES_NUMMERIC.AlertClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER GROUPS")
        ' Place code here
        Dim c As New CustomerGrouping

        For Each kf As Form In Me.MdiChildren
            If c.GetType Is kf.GetType Then
                kf.Activate()
                kf.WindowState = FormWindowState.Normal
                SplashScreenManager.CloseForm(False)
                Return
            End If
        Next
        c.MdiParent = Me
        c.Show()

        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Alert_GROUP_COUNTRIES_NUMMERIC_BeforeFormShow(sender As Object, e As AlertFormEventArgs) Handles Alert_GROUP_COUNTRIES_NUMMERIC.BeforeFormShow
        e.AlertForm.Size = New Size(300, 200)
        e.AlertForm.AutoScroll = True
        e.AlertForm.AutoSize = True
        e.AlertForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        'e.AlertForm.Info.Image = Me.ImageCollection1.Images(11)



    End Sub

    Private Sub Alert_GROUP_COUNTRIES_NUMMERIC_FormLoad(sender As Object, e As AlertFormLoadEventArgs) Handles Alert_GROUP_COUNTRIES_NUMMERIC.FormLoad
        e.Buttons.PinButton.SetDown(True) 'Allert button shows allways
    End Sub

#End Region



    'Validation für XML Schema Datei
    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Select Case e.Severity
            Case XmlSeverityType.Error
                XtraMessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Debug.WriteLine("Error: {0}", e.Message)
            Case XmlSeverityType.Warning
                'Debug.WriteLine("Warning {0}", e.Message)
                'MsgBox("Warning {0}", e.Message, "WARNING")
                XtraMessageBox.Show(e.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Select
    End Sub

    Private Sub AccordionControl1_ElementClick(sender As Object, e As Navigation.ElementClickEventArgs) Handles AccordionControl1.ElementClick

    End Sub



    Private Sub AccordionControl1_FilterContent(sender As Object, e As Navigation.FilterContentEventArgs) Handles AccordionControl1.FilterContent
        'Dim FilterText As String = e.Element.Text.ToString
        Dim FilterText As String = Nothing
        If e.FilterValue <> "" Then
            FilterText = e.FilterValue.ToString
        End If

        If FilterText <> "" Then
            For Each element In AccordionControl1.Elements
                element.Expanded = True
                Me.AccordionControl1.ExpandElement(RISKCONTROL_BUSINESSTYPES_GROUP_Element)
                Me.AccordionControl1.ExpandElement(RISKCONTROL_PARAMETERS_GROUP_Element)
                Me.AccordionControl1.ExpandElement(MELDW_EINLAGENSICHERUNG_GROUP_Element)
                Me.AccordionControl1.ExpandElement(MELDW_ZV_STATISTIC_GROUP_Element)
                Me.AccordionControl1.ExpandElement(ACCOUNT_FXDEALS_GROUP_Element)
                Me.AccordionControl1.ExpandElement(EDP_DATA_IMPORT_GROUP_Element)
                Me.AccordionControl1.ExpandElement(EDP_BAISFiles_GROUP_Element)
                Me.AccordionControl1.ExpandElement(FOREIGN_EXPORT_LC_GROUP_Element)
                Me.AccordionControl1.ExpandElement(CLEARING_PAYMENT_ORDERS_GROUP_Element)
                Me.AccordionControl1.ExpandElement(TREAS_FX_DEALS_GROUP_Element)
                Me.AccordionControl1.ExpandElement(CREDIT_GROUP_Element)
            Next
        Else
            For Each Element In Me.AccordionControl1.Elements
                Element.Expanded = False
            Next
        End If

        'If FilterText = "" Then
        'For Each Element In Me.AccordionControl1.Elements
        'Element.Expanded = False
        'Next
        'End If

    End Sub

    Private Sub rgbiSkins_GalleryItemClick(sender As Object, e As GalleryItemClickEventArgs) Handles rgbiSkins.GalleryItemClick
        CurrentSkinName = e.Item.Caption.ToString
    End Sub


    Private Sub ribbonControl_Paint(sender As Object, e As PaintEventArgs) Handles ribbonControl.Paint

        Dim ribbonViewInfo As DevExpress.XtraBars.Ribbon.ViewInfo.RibbonViewInfo = ribbonControl.ViewInfo
        If ribbonViewInfo Is Nothing Then
            Return
        End If
        Dim panelViewInfo As DevExpress.XtraBars.Ribbon.ViewInfo.RibbonPanelViewInfo = ribbonViewInfo.Panel
        If panelViewInfo Is Nothing Then
            Return
        End If
        Dim bounds As System.Drawing.Rectangle = panelViewInfo.Bounds
        Dim minX As Integer = bounds.X
        Dim groups As DevExpress.XtraBars.Ribbon.ViewInfo.RibbonPageGroupViewInfoCollection = panelViewInfo.Groups
        If groups Is Nothing Then
            Return
        End If
        If groups.Count > 0 Then
            minX = groups(groups.Count - 1).Bounds.Right
        End If
        'Dim image As System.Drawing.Image = DevExpress.Utils.Frames.ApplicationCaption8_1.GetImageLogoEx(LookAndFeel)


        If Me.Text.EndsWith("CCB_PS_TOOL_TEST") = True OrElse Me.Text.Contains("CCB_PS_TOOL_TEST") Then
            Dim image As System.Drawing.Image = LogoImageCollection.Images(4)
            If bounds.Height < image.Height Then
                Return
            End If
            Dim offset As Integer = (bounds.Height - image.Height) / 2
            Dim width As Integer = image.Width + 15
            bounds.X = bounds.Width - width
            If bounds.X < minX Then
                Return
            End If
            bounds.Width = width
            bounds.Y += offset
            bounds.Height = image.Height
            e.Graphics.DrawImage(image, bounds.Location)
            'Text
            Dim str As StringFormat = StringFormat.GenericDefault
            str.Alignment = StringAlignment.Center
            Dim ribbon As RibbonControl = TryCast(sender, RibbonControl)
            Dim ri As RibbonViewInfo = ribbon.ViewInfo
            Dim fontSize As Integer = 40
            Dim boundsText As New System.Drawing.Rectangle(ri.Panel.Bounds.Left, (ri.Panel.Bounds.Top + ri.Panel.Bounds.Bottom - fontSize) / 2, ri.Panel.Bounds.Width, fontSize)
            e.Graphics.DrawString("PS TOOL TEST Environment", New System.Drawing.Font("Tahoma", fontSize, FontStyle.Bold), Brushes.Red, ri.Panel.Bounds, str)
            'TEST
            '' Create string to draw.
            'Dim drawString As [String] = "Sample Text"

            '' Create font and brush.
            'Dim drawFont As New System.Drawing.Font("Arial", 16)
            'Dim drawBrush As New SolidBrush(System.Drawing.Color.Red)

            '' Create rectangle for drawing.
            'Dim x As Single = 12.0F
            'Dim y As Single = 150.0F
            'width = 200.0F
            'Dim height As Single = 50.0F
            'Dim drawRect As New RectangleF(x, y, width, height)

            '' Draw rectangle to screen.
            'Dim blackPen As New Pen(System.Drawing.Color.Red)
            'e.Graphics.DrawRectangle(blackPen, x, y, width, height)

            '' Set format of string.
            'Dim drawFormat As New StringFormat
            'drawFormat.Alignment = StringAlignment.Center

            '' Draw string to screen.
            'e.Graphics.DrawString(drawString, drawFont, drawBrush, _
            'drawRect, drawFormat)

        Else

            Dim image As System.Drawing.Image = LogoImageCollection.Images(5)
            If bounds.Height < image.Height Then
                Return
            End If
            Dim offset As Integer = (bounds.Height - image.Height) / 2
            Dim width As Integer = image.Width + 15
            bounds.X = bounds.Width - width
            If bounds.X < minX Then
                Return
            End If
            bounds.Width = width
            bounds.Y += offset
            bounds.Height = image.Height
            e.Graphics.DrawImage(image, bounds.Location)
        End If



    End Sub


    Private Sub BarMdiChildrenListItem1_ListItemClick(sender As Object, e As ListItemClickEventArgs) Handles BarMdiChildrenListItem1.ListItemClick
        For i = Me.MdiChildren.Length - 1 To 0 Step -1
            If Me.MdiChildren(i).WindowState = FormWindowState.Minimized Then
                Me.MdiChildren(i).WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub


End Class
