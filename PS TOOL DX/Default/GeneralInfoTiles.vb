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
Imports System.Diagnostics
Imports System.Collections.Generic
Imports Bytescout.PDFExtractor
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Spreadsheet
Public Class GeneralInfoTiles

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim workbook As IWorkbook
    Dim worksheet As Worksheet
    Dim workbookN As IWorkbook
    Dim worksheetN As Worksheet


    Dim rd As Date
    Dim rdsql As String = Nothing

    Dim FormShownStatus As Integer = 0

    'Checking Figures
    Dim SumActiva As Double = 0
    Dim SumPassiva As Double = 0
    Dim BalanceSheetDifference As Double = 0
    Dim Profit_Loss As Double = 0

    Dim FristenCount As Double = 0
    Dim FristenAssetsCount As Double = 0
    Dim FristenLiabilitiesCount As Double = 0
    Dim FristenOffBalanceLongCount As Double = 0
    Dim FristenOffBalanceShortCount As Double = 0
    Dim FristenOthersCount As Double = 0

    Dim AccruedInterestCount As Double = 0
    Dim AccruedInterestAssetsCount As Double = 0
    Dim AccruedInterestLiabilitiesCount As Double = 0

    Dim TrialBalanceConsolidatedCount As Double = 0
    Dim TrialBalanceSingleCount As Double = 0
    Dim TrialBalanceErrorsCount As Double = 0
    Dim TrialBalanceCurrentDate As Date
    Dim TrialBalanceLastDate As Date
    Dim TrialBalance_Assets_Current As Double = 0
    Dim TrialBalance_Assets_Last As Double = 0
    Dim TrialBalance_Assets_Difference As Double = 0
    Dim TrialBalance_Liabilities_Current As Double = 0
    Dim TrialBalance_Liabilities_Last As Double = 0
    Dim TrialBalance_Liabilities_Difference As Double = 0
    Dim TrialBalance_OI_Current As Double = 0 'Operating Income
    Dim TrialBalance_OI_Last As Double = 0
    Dim TrialBalance_OI_Difference As Double = 0
    Dim TrialBalance_NOI_Current As Double = 0 'Non -Operating Income
    Dim TrialBalance_NOI_Last As Double = 0
    Dim TrialBalance_NOI_Difference As Double = 0
    Dim TrialBalance_OE_Current As Double = 0 'Operating Expenses
    Dim TrialBalance_OE_Last As Double = 0
    Dim TrialBalance_OE_Difference As Double = 0
    Dim TrialBalance_ITE_Current As Double = 0 'Income Tax Expenses
    Dim TrialBalance_ITE_Last As Double = 0
    Dim TrialBalance_ITE_Difference As Double = 0
    Dim TrialBalance_NI_Current As Double = 0 'Net Income
    Dim TrialBalance_NI_Last As Double = 0
    Dim TrialBalance_NI_Difference As Double = 0

    Dim Profit_Loss_Compare_Parameter As Double = 0
    Dim Assets_Liabilities_Compare_Parameter As Double = 0


    Dim MakCount As Double = 0
    Dim MakSum As Double = 0
    Dim CreditRiskCount As Double = 0
    Dim CreditRiskSum As Double = 0
    Dim ContractTypesNoIncludedCount As Double = 0
    Dim ProductTypesNoIncludedCount As Double = 0

    Dim InterestRateRiskCount As Double = 0
    Dim ExchangeRatesCount As Double = 0
    Dim CL_DrawdownCount As Double = 0
    Dim AllBookingsCount As Double = 0

    Dim WorkingCapital As Double = 0
    Dim IRR_Rate As Double = 0
    Dim IRR_Amount As Double = 0

    Dim RBC As Double = 0

    Dim LiqV_BAIS As Double = 0
    Dim LiqV_PSTOOL As Double = 0
    Dim LCR_BAIS As Double = 0
    Dim CAR_BAIS As Double = 0
    Dim CAR_PSTOOL As Double = 0
    Dim FX_CCB_CRED_EQUIV As Double = 0
    Dim FX_CCB_CRED_EQUIV_PERCENT As Double = 0

    Dim CurrencyRisk_BAIS As Double = 0
    Dim CurrencyRisk_PSTOOL As Double = 0
    Dim OperationalRisk_BAIS As Double = 0
    Dim CreditRisk_PSTOOL As Double = 0
    Dim UL_PSTOOL As Double = 0
    Dim GA_PSTOOL As Double = 0
    Dim CVA_BAIS As Double = 0
    Dim CVA_PSTOOL As Double = 0

    Dim CORE_CAPITAL_BAIS As Double = 0
    Dim OWN_FUNDS_BAIS As Double = 0
    Dim MIN_CAP_BAIS As Double = 0
    Dim CAP_CONSERV_BUFFER_BAIS As Double = 0
    Dim CAP_INST_SPEC_BAIS As Double = 0
    Dim ELIGIBLE_CAPITAL_PSTOOL As Double = 0


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

    Private Sub GeneralInfoTiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar

        cmd.CommandText = "SELECT [NPARAMETER1] FROM [PARAMETER] where [PARAMETER1]='Profit_Loss_Compare' and [IdABTEILUNGSPARAMETER]='GENERAL_INFO_PARAMETER' and [PARAMETER STATUS]='Y' "
        Profit_Loss_Compare_Parameter = cmd.ExecuteScalar
        cmd.CommandText = "SELECT [NPARAMETER1] FROM [PARAMETER] where [PARAMETER1]='Assets_Liabilities_Compare' and [IdABTEILUNGSPARAMETER]='GENERAL_INFO_PARAMETER' and [PARAMETER STATUS]='Y' "
        Assets_Liabilities_Compare_Parameter = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.BusinessDate_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [GeneralDataInfo] GROUP BY [RiskDate]  ORDER BY [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BusinessDate_Comboedit.Properties.Items.Add(row("RLDC Date"))

            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BusinessDate_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        rd = Me.BusinessDate_Comboedit.Text
        rdsql = rd.ToString("yyyyMMdd")

        TrialBalanceCurrentDate = rd

        GET_GENERAL_INFO()
        FORMAT_GENERAL_INFO()

    End Sub

    Private Sub GET_GENERAL_INFO()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If

       

        '-------BALANCE SHEET CHECK -----------
        'Sum Activa
        'cmd.CommandText = "Select 'SUM_ACTIVA'= Case when (Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=2999) is not NULL then (Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=2999) else 0 end"
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Sum_Activa') and [RiskDate]='" & rdsql & "'"
        SumActiva = cmd.ExecuteScalar
        'Sum Passiva
        'cmd.CommandText = "Select 'SUM_PASSIVA'= Case when (Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=4999) is not NULL then (Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & rdsql & "' and [GL_Item_Number]=4999) else 0 end"
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Sum_Passiva') and [RiskDate]='" & rdsql & "'"
        SumPassiva = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('BS_Difference') and [RiskDate]='" & rdsql & "'"
        BalanceSheetDifference = cmd.ExecuteScalar
        'Profit-Loss
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Profit_Loss') and [RiskDate]='" & rdsql & "'"
        Profit_Loss = cmd.ExecuteScalar
        Dim Activa_element As TileItemElement = Me.BalanceSheet_TileItem.Elements(2)
        Activa_element.Text = FormatNumber(SumActiva, 2) & " €"
        Dim Passiva_element As TileItemElement = Me.BalanceSheet_TileItem.Elements(4)
        Passiva_element.Text = FormatNumber(SumPassiva, 2) & " €"
        Dim BalanceSheetDifference_element As TileItemElement = Me.BalanceSheet_TileItem.Elements(6)
        BalanceSheetDifference_element.Text = FormatNumber(BalanceSheetDifference, 2) & " €"
        Dim ProfitLoss_element As TileItemElement = Me.BalanceSheet_TileItem.Elements(8)
        ProfitLoss_element.Text = FormatNumber(Profit_Loss, 2) & " €"
        '--------------------------------------------------------------

        '------FRISTEN REPORT CHECK
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Fristen_Count_Total') and [RiskDate]='" & rdsql & "'"
        FristenCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Fristen_Assets_Count') and [RiskDate]='" & rdsql & "'"
        FristenAssetsCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Fristen_Liabilities_Count') and [RiskDate]='" & rdsql & "'"
        FristenLiabilitiesCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Fristen_OFF_BS_Short_Count') and [RiskDate]='" & rdsql & "'"
        FristenOffBalanceShortCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Fristen_OFF_BS_Long_Count') and [RiskDate]='" & rdsql & "'"
        FristenOffBalanceLongCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('Fristen_OTHERS_Count') and [RiskDate]='" & rdsql & "'"
        FristenOthersCount = cmd.ExecuteScalar
        Dim FristenAssetsCount_element As TileItemElement = Me.Fristen_TileItem.Elements(2)
        FristenAssetsCount_element.Text = FormatNumber(FristenAssetsCount, 0)
        Dim FristenLiabilitiesCount_element As TileItemElement = Me.Fristen_TileItem.Elements(4)
        FristenLiabilitiesCount_element.Text = FormatNumber(FristenLiabilitiesCount, 0)
        Dim FristenOffBalanceShortCount_element As TileItemElement = Me.Fristen_TileItem.Elements(6)
        FristenOffBalanceShortCount_element.Text = FormatNumber(FristenOffBalanceShortCount, 0)
        Dim FristenOffBalanceLongCount_element As TileItemElement = Me.Fristen_TileItem.Elements(8)
        FristenOffBalanceLongCount_element.Text = FormatNumber(FristenOffBalanceLongCount, 0)
        Dim FristenOthersCount_element As TileItemElement = Me.Fristen_TileItem.Elements(10)
        FristenOthersCount_element.Text = FormatNumber(FristenOthersCount, 0)
        '-------------------------------------------------------------

        '-----ACCRUED INTEREST ANALYSIS
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('AccruedInterest_Count_Total') and [RiskDate]='" & rdsql & "'"
        AccruedInterestCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('AccruedInterest_Assets_Count') and [RiskDate]='" & rdsql & "'"
        AccruedInterestAssetsCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('AccruedInterest_Liabilities_Count') and [RiskDate]='" & rdsql & "'"
        AccruedInterestLiabilitiesCount = cmd.ExecuteScalar
        Dim AccruedInterestAssetsCount_element As TileItemElement = Me.AccruedInterest_TileItem.Elements(2)
        AccruedInterestAssetsCount_element.Text = FormatNumber(AccruedInterestAssetsCount, 0)
        Dim AccruedInterestLiabilitiesCount_element As TileItemElement = Me.AccruedInterest_TileItem.Elements(4)
        AccruedInterestLiabilitiesCount_element.Text = FormatNumber(AccruedInterestLiabilitiesCount, 0)
        '-----------------------------------------

        '-----TRIAL BALANCE
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_Consolidated_Count') and [RiskDate]='" & rdsql & "'"
        TrialBalanceConsolidatedCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_Single_Count') and [RiskDate]='" & rdsql & "'"
        TrialBalanceSingleCount = cmd.ExecuteScalar
        Dim TrialBalanceConsolidatedCount_element As TileItemElement = Me.TrialBalance_TileItem.Frames(0).Elements(2)
        TrialBalanceConsolidatedCount_element.Text = FormatNumber(TrialBalanceConsolidatedCount, 0)
        Dim TrialBalanceSingleCount_element As TileItemElement = Me.TrialBalance_TileItem.Frames(0).Elements(4)
        TrialBalanceSingleCount_element.Text = FormatNumber(TrialBalanceSingleCount, 0)
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('System_Errors_Count') and [RiskDate]='" & rdsql & "'"
        TrialBalanceErrorsCount = cmd.ExecuteScalar
        Dim TrialBalanceErrorsCount_element As TileItemElement = Me.TrialBalance_TileItem.Frames(1).Elements(2)
        TrialBalanceErrorsCount_element.Text = FormatNumber(TrialBalanceErrorsCount, 0)
        'Trial Balance Compare
        cmd.CommandText = "Select [Date1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [RiskDate]='" & rdsql & "'"
        TrialBalanceLastDate = cmd.ExecuteScalar
        Dim TrialBalanceAssetsCurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(2).Elements(2)
        TrialBalanceAssetsCurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceAssetsLastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(2).Elements(3)
        TrialBalanceAssetsLastDate_element.Text = TrialBalanceLastDate
        'Assets
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Assets') and [RiskDate]='" & rdsql & "'"
        TrialBalance_Assets_Current = cmd.ExecuteScalar
        Dim TrialBalanceAssetsCurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(2).Elements(4)
        TrialBalanceAssetsCurrent_element.Text = FormatNumber(TrialBalance_Assets_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Assets') and [RiskDate]='" & rdsql & "'"
        TrialBalance_Assets_Last = cmd.ExecuteScalar
        Dim TrialBalanceAssetsLast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(2).Elements(5)
        TrialBalanceAssetsLast_element.Text = FormatNumber(TrialBalance_Assets_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Assets') and [RiskDate]='" & rdsql & "'"
        TrialBalance_Assets_Difference = cmd.ExecuteScalar
        Dim TrialBalanceAssetsDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(2).Elements(7)
        TrialBalanceAssetsDifference_element.Text = FormatNumber(TrialBalance_Assets_Difference, 2)
        'Liabilities
        Dim TrialBalanceLiabilitiesCurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(3).Elements(2)
        TrialBalanceLiabilitiesCurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceLiabilitiesLastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(3).Elements(3)
        TrialBalanceLiabilitiesLastDate_element.Text = TrialBalanceLastDate
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Liabilities') and [RiskDate]='" & rdsql & "'"
        TrialBalance_Liabilities_Current = cmd.ExecuteScalar
        Dim TrialBalanceLiabilitiesCurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(3).Elements(4)
        TrialBalanceLiabilitiesCurrent_element.Text = FormatNumber(TrialBalance_Liabilities_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Liabilities') and [RiskDate]='" & rdsql & "'"
        TrialBalance_Liabilities_Last = cmd.ExecuteScalar
        Dim TrialBalanceLiabilitiesLast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(3).Elements(5)
        TrialBalanceLiabilitiesLast_element.Text = FormatNumber(TrialBalance_Liabilities_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Liabilities') and [RiskDate]='" & rdsql & "'"
        TrialBalance_Liabilities_Difference = cmd.ExecuteScalar
        Dim TrialBalanceLiabilitiesDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(3).Elements(7)
        TrialBalanceLiabilitiesDifference_element.Text = FormatNumber(TrialBalance_Liabilities_Difference, 2)
        'Operating Income
        Dim TrialBalanceOICurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(4).Elements(2)
        TrialBalanceOICurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceOILastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(4).Elements(3)
        TrialBalanceOILastDate_element.Text = TrialBalanceLastDate
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Operating Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_OI_Current = cmd.ExecuteScalar
        Dim TrialBalanceOICurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(4).Elements(4)
        TrialBalanceOICurrent_element.Text = FormatNumber(TrialBalance_OI_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Operating Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_OI_Last = cmd.ExecuteScalar
        Dim TrialBalanceOILast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(4).Elements(5)
        TrialBalanceOILast_element.Text = FormatNumber(TrialBalance_OI_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Operating Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_OI_Difference = cmd.ExecuteScalar
        Dim TrialBalanceOIDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(4).Elements(7)
        TrialBalanceOIDifference_element.Text = FormatNumber(TrialBalance_OI_Difference, 2)
        'NonOperating Income
        Dim TrialBalanceNOICurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(5).Elements(2)
        TrialBalanceNOICurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceNOILastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(5).Elements(3)
        TrialBalanceNOILastDate_element.Text = TrialBalanceLastDate
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Non-Operating Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_NOI_Current = cmd.ExecuteScalar
        Dim TrialBalanceNOICurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(5).Elements(4)
        TrialBalanceNOICurrent_element.Text = FormatNumber(TrialBalance_NOI_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Non-Operating Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_NOI_Last = cmd.ExecuteScalar
        Dim TrialBalanceNOILast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(5).Elements(5)
        TrialBalanceNOILast_element.Text = FormatNumber(TrialBalance_NOI_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Non-Operating Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_NOI_Difference = cmd.ExecuteScalar
        Dim TrialBalanceNOIDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(5).Elements(7)
        TrialBalanceNOIDifference_element.Text = FormatNumber(TrialBalance_NOI_Difference, 2)
        'Operating Expenses
        Dim TrialBalanceOECurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(6).Elements(2)
        TrialBalanceOECurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceOELastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(6).Elements(3)
        TrialBalanceOELastDate_element.Text = TrialBalanceLastDate
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Operating Expenses') and [RiskDate]='" & rdsql & "'"
        TrialBalance_OE_Current = cmd.ExecuteScalar
        Dim TrialBalanceOECurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(6).Elements(4)
        TrialBalanceOECurrent_element.Text = FormatNumber(TrialBalance_OE_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Operating Expenses') and [RiskDate]='" & rdsql & "'"
        TrialBalance_OE_Last = cmd.ExecuteScalar
        Dim TrialBalanceOELast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(6).Elements(5)
        TrialBalanceOELast_element.Text = FormatNumber(TrialBalance_OE_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Operating Expenses') and [RiskDate]='" & rdsql & "'"
        TrialBalance_OE_Difference = cmd.ExecuteScalar
        Dim TrialBalanceOEDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(6).Elements(7)
        TrialBalanceOEDifference_element.Text = FormatNumber(TrialBalance_OE_Difference, 2)
        'Income Tax Expenses
        Dim TrialBalanceITECurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(7).Elements(2)
        TrialBalanceITECurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceITELastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(7).Elements(3)
        TrialBalanceITELastDate_element.Text = TrialBalanceLastDate
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Income Tax Expenses') and [RiskDate]='" & rdsql & "'"
        TrialBalance_ITE_Current = cmd.ExecuteScalar
        Dim TrialBalanceITECurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(7).Elements(4)
        TrialBalanceITECurrent_element.Text = FormatNumber(TrialBalance_ITE_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Income Tax Expenses') and [RiskDate]='" & rdsql & "'"
        TrialBalance_ITE_Last = cmd.ExecuteScalar
        Dim TrialBalanceITELast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(7).Elements(5)
        TrialBalanceITELast_element.Text = FormatNumber(TrialBalance_ITE_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Income Tax Expenses') and [RiskDate]='" & rdsql & "'"
        TrialBalance_ITE_Difference = cmd.ExecuteScalar
        Dim TrialBalanceITEDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(7).Elements(7)
        TrialBalanceITEDifference_element.Text = FormatNumber(TrialBalance_ITE_Difference, 2)
        'Net Income
        Dim TrialBalanceNICurrentDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(8).Elements(2)
        TrialBalanceNICurrentDate_element.Text = TrialBalanceCurrentDate
        Dim TrialBalanceNILastDate_element As TileItemElement = Me.TrialBalance_TileItem.Frames(8).Elements(3)
        TrialBalanceNILastDate_element.Text = TrialBalanceLastDate
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Net Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_NI_Current = cmd.ExecuteScalar
        Dim TrialBalanceNICurrent_element As TileItemElement = Me.TrialBalance_TileItem.Frames(8).Elements(4)
        TrialBalanceNICurrent_element.Text = FormatNumber(TrialBalance_NI_Current, 2)
        cmd.CommandText = "Select [Amount2] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Net Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_NI_Last = cmd.ExecuteScalar
        Dim TrialBalanceNILast_element As TileItemElement = Me.TrialBalance_TileItem.Frames(8).Elements(5)
        TrialBalanceNILast_element.Text = FormatNumber(TrialBalance_NI_Last, 2)
        cmd.CommandText = "Select [Amount3] from [GeneralDataInfo] where [Description1] in ('TrialBalance_GeneralInfo') and [Description2] in ('Total Net Income') and [RiskDate]='" & rdsql & "'"
        TrialBalance_NI_Difference = cmd.ExecuteScalar
        Dim TrialBalanceNIDifference_element As TileItemElement = Me.TrialBalance_TileItem.Frames(8).Elements(7)
        TrialBalanceNIDifference_element.Text = FormatNumber(TrialBalance_NI_Difference, 2)
        '-------------------------------------------------------------

        '--------MAK CREDIT RISK
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('MAK_Count') and [RiskDate]='" & rdsql & "'"
        MakCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('MAK_Sum') and [RiskDate]='" & rdsql & "'"
        MakSum = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CREDIT_RISK_Count') and [RiskDate]='" & rdsql & "'"
        CreditRiskCount = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CREDIT_RISK_Sum') and [RiskDate]='" & rdsql & "'"
        CreditRiskSum = cmd.ExecuteScalar
        Dim MakCount_element As TileItemElement = Me.Mak_Credit_TileItem.Elements(2)
        MakCount_element.Text = FormatNumber(MakCount, 0)
        Dim MakSum_element As TileItemElement = Me.Mak_Credit_TileItem.Elements(4)
        MakSum_element.Text = FormatNumber(MakSum, 2) & " €"
        Dim CreditRiskCount_element As TileItemElement = Me.Mak_Credit_TileItem.Elements(6)
        CreditRiskCount_element.Text = FormatNumber(CreditRiskCount, 0)
        Dim CreditRiskSum_element As TileItemElement = Me.Mak_Credit_TileItem.Elements(8)
        CreditRiskSum_element.Text = FormatNumber(CreditRiskSum, 2) & " €"
        'Contract Types Check
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('ContractTypes_Count') and [RiskDate]='" & rdsql & "'"
        ContractTypesNoIncludedCount = cmd.ExecuteScalar
        Dim ContractTypesNoIncludedCount_element As TileItemElement = Me.ContractProductTypes_TileItem.Frames(0).Elements(1)
        ContractTypesNoIncludedCount_element.Text = FormatNumber(ContractTypesNoIncludedCount, 0)
        'Product Types Check
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('ProductTypes_Count') and [RiskDate]='" & rdsql & "'"
        ProductTypesNoIncludedCount = cmd.ExecuteScalar
        Dim ProductTypesNoIncludedCount_element As TileItemElement = Me.ContractProductTypes_TileItem.Frames(1).Elements(1)
        ProductTypesNoIncludedCount_element.Text = FormatNumber(ProductTypesNoIncludedCount, 0)
        '----------------------------------------------------

        '----INTEREST RATE RISK
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('INTEREST_RATE_RISK_Count') and [RiskDate]='" & rdsql & "'"
        InterestRateRiskCount = cmd.ExecuteScalar
        Dim InterestRateRiskCount_element As TileItemElement = Me.SeveralTables_TileItem.Frames(0).Elements(2)
        InterestRateRiskCount_element.Text = FormatNumber(InterestRateRiskCount, 0)
        '----------------

        '---OCBS EXCHANGE RATES
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('OCBS_Exchange_Rates_Count') and [RiskDate]='" & rdsql & "'"
        ExchangeRatesCount = cmd.ExecuteScalar
        Dim ExchangeRatesCount_element As TileItemElement = Me.SeveralTables_TileItem.Frames(1).Elements(2)
        ExchangeRatesCount_element.Text = FormatNumber(ExchangeRatesCount, 0)
        '--------------------------

        '---CL DRAWDOWN
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CL_Drawdown_Count') and [RiskDate]='" & rdsql & "'"
        CL_DrawdownCount = cmd.ExecuteScalar
        Dim CL_DrawdownCount_element As TileItemElement = Me.SeveralTables_TileItem.Frames(2).Elements(2)
        CL_DrawdownCount_element.Text = FormatNumber(CL_DrawdownCount, 0)
        '--------------------------



        'INTEREST RATE RISK
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('WORKING_CAPITAL') and [RiskDate]='" & rdsql & "'"
        WorkingCapital = cmd.ExecuteScalar
        Dim WorkingCapital_element As TileItemElement = Me.InterestRateRisk_TileItem.Elements(3)
        WorkingCapital_element.Text = FormatNumber(WorkingCapital, 2) & " €"
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('IRR_Ratio') and [RiskDate]='" & rdsql & "'"
        IRR_Rate = cmd.ExecuteScalar
        Dim IRR_Rate_element As TileItemElement = Me.InterestRateRisk_TileItem.Elements(4)
        IRR_Rate_element.Text = FormatNumber(IRR_Rate, 2) & " %"
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('IRR_Amount') and [RiskDate]='" & rdsql & "'"
        IRR_Amount = cmd.ExecuteScalar
        Dim IRR_Amount_element As TileItemElement = Me.InterestRateRisk_TileItem.Elements(6)
        IRR_Amount_element.Text = FormatNumber(IRR_Amount, 2) & " €"

        'RISK BEARING CAPACITY
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('RBC') and [RiskDate]='" & rdsql & "'"
        RBC = cmd.ExecuteScalar
        Dim RBC_element As TileItemElement = Me.RiskBearingCapacity_TileItem.Elements(2)
        RBC_element.Text = FormatNumber(RBC, 2) & " %"

        'LIQV
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('LIQV_BAIS') and [RiskDate]='" & rdsql & "'"
        LiqV_BAIS = cmd.ExecuteScalar
        Dim LiqV_BAIS_element As TileItemElement = Me.LCR_LIQV_TileItem.Frames(0).Elements(2)

        If rd < DateSerial(2018, 1, 1) Then
            Me.LCR_LIQV_TileItem.Visible = True
            LiqV_BAIS_element.Text = FormatNumber(LiqV_BAIS, 2)
        Else
            Me.LCR_LIQV_TileItem.Visible = False
        End If


        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('LIQV_PSTOOL') and [RiskDate]='" & rdsql & "'"
        LiqV_PSTOOL = cmd.ExecuteScalar
        Dim LiqV_PSTOOL_element As TileItemElement = Me.LCR_LIQV_TileItem.Frames(1).Elements(2)
        LiqV_PSTOOL_element.Text = FormatNumber(LiqV_PSTOOL, 2)

        'LCR
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('LCR_BAIS') and [RiskDate]='" & rdsql & "'"
        LCR_BAIS = cmd.ExecuteScalar
        Dim LCR_BAIS_element As TileItemElement = Me.LCR_LIQV_TileItem.Frames(2).Elements(2)
        LCR_BAIS_element.Text = FormatNumber(LCR_BAIS, 2)

        'CAR
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CAR_BAIS') and [RiskDate]='" & rdsql & "'"
        CAR_BAIS = cmd.ExecuteScalar
        Dim CAR_BAIS_element As TileItemElement = Me.CAR_TileItem.Frames(0).Elements(3)
        CAR_BAIS_element.Text = FormatNumber(CAR_BAIS, 2) & " %"
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CAR_PSTOOL') and [RiskDate]='" & rdsql & "'"
        CAR_PSTOOL = cmd.ExecuteScalar
        Dim CAR_PSTOOL_element As TileItemElement = Me.CAR_TileItem.Frames(1).Elements(3)
        CAR_PSTOOL_element.Text = FormatNumber(CAR_PSTOOL, 2) & " %"

        'FX CCB CREDIT EQUIVALENT
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CCB_Guarantees_Amount') and [RiskDate]='" & rdsql & "'"
        Dim CCB_Guarantees_Amount As Double = 0
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            CCB_Guarantees_Amount = FormatNumber(cmd.ExecuteScalar, 2)
        End If
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('FX_CreditEquivelantAmount') and [RiskDate]='" & rdsql & "'"
        Dim CCB_Credit_Equiv_Amount As Double = 0
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            CCB_Credit_Equiv_Amount = FormatNumber(cmd.ExecuteScalar, 2)
        End If
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CORE_CAPITAL') and [RiskDate]='" & rdsql & "'"
        Dim Core_Capital As Double = cmd.ExecuteScalar
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('ELIGIBLE_CAPITAL') and [RiskDate]='" & rdsql & "'"
        ELIGIBLE_CAPITAL_PSTOOL = cmd.ExecuteScalar
        FX_CCB_CRED_EQUIV = CCB_Guarantees_Amount + CCB_Credit_Equiv_Amount
        If Core_Capital <> 0 Then
            FX_CCB_CRED_EQUIV_PERCENT = (FX_CCB_CRED_EQUIV / ELIGIBLE_CAPITAL_PSTOOL) * 100
        Else
            FX_CCB_CRED_EQUIV_PERCENT = 0
        End If
        Dim FX_CCB_CRED_EQUIV_element As TileItemElement = Me.FX_TileItem.Frames(0).Elements(3)
        FX_CCB_CRED_EQUIV_element.Text = FormatNumber(FX_CCB_CRED_EQUIV, 2) & " €"
        Dim FX_CCB_CRED_EQUIV_PERCENT_element As TileItemElement = Me.FX_TileItem.Frames(0).Elements(4)
        FX_CCB_CRED_EQUIV_PERCENT_element.Text = FormatNumber(FX_CCB_CRED_EQUIV_PERCENT, 2) & " %"
        '---------------------------------------------

        'Currency Risk BAIS
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CURRENCY_RISK_BAIS') and [RiskDate]='" & rdsql & "'"
        CurrencyRisk_BAIS = cmd.ExecuteScalar
        Dim CurrencyRisk_BAIS_element As TileItemElement = Me.Other_TileItem.Frames(0).Elements(2)
        CurrencyRisk_BAIS_element.Text = FormatNumber(CurrencyRisk_BAIS * 1000, 2) & " €"
        'Currency Risk PSTOOL
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CURRENCY_RISK_PSTOOL') and [RiskDate]='" & rdsql & "'"
        CurrencyRisk_PSTOOL = cmd.ExecuteScalar
        Dim CurrencyRisk_PSTOOL_element As TileItemElement = Me.Other_TileItem.Frames(1).Elements(2)
        CurrencyRisk_PSTOOL_element.Text = FormatNumber(Math.Round(CurrencyRisk_PSTOOL / 1000, 0) * 1000, 2) & " €"
        'Operational Risk BAIS
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('OPERATIONAL_RISK_BAIS') and [RiskDate]='" & rdsql & "'"
        OperationalRisk_BAIS = cmd.ExecuteScalar
        Dim OperationalRisk_BAIS_element As TileItemElement = Me.Other_TileItem.Frames(2).Elements(2)
        OperationalRisk_BAIS_element.Text = FormatNumber(OperationalRisk_BAIS * 1000, 2) & " €"
        'Credit Risk PS TOOL
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CREDIT_RISK_PSTOOL') and [RiskDate]='" & rdsql & "'"
        CreditRisk_PSTOOL = cmd.ExecuteScalar
        Dim CreditRisk_PSTOOL_element As TileItemElement = Me.Other_TileItem.Frames(3).Elements(2)
        CreditRisk_PSTOOL_element.Text = FormatNumber(CreditRisk_PSTOOL, 2) & " €"
        'Unexpected Loss
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('UL_PSTOOL') and [RiskDate]='" & rdsql & "'"
        UL_PSTOOL = cmd.ExecuteScalar
        Dim UL_PSTOOL_element As TileItemElement = Me.Other_TileItem.Frames(4).Elements(2)
        UL_PSTOOL_element.Text = FormatNumber(UL_PSTOOL, 2) & " €"
        'Granularity Approach
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('GA_PSTOOL') and [RiskDate]='" & rdsql & "'"
        GA_PSTOOL = cmd.ExecuteScalar
        Dim GA_PSTOOL_element As TileItemElement = Me.Other_TileItem.Frames(5).Elements(2)
        GA_PSTOOL_element.Text = FormatNumber(GA_PSTOOL, 2) & " €"
        'CVA BAIS-PSTOOL
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CVA_RISK_BAIS') and [RiskDate]='" & rdsql & "'"
        CVA_BAIS = cmd.ExecuteScalar
        Dim CVA_BAIS_element As TileItemElement = Me.Other_TileItem.Frames(6).Elements(2)
        CVA_BAIS_element.Text = FormatNumber(CVA_BAIS, 2) & " €"
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CVA_RISK_PSTOOL') and [RiskDate]='" & rdsql & "'"
        CVA_PSTOOL = cmd.ExecuteScalar
        Dim CVA_PSTOOL_element As TileItemElement = Me.Other_TileItem.Frames(6).Elements(4)
        CVA_PSTOOL_element.Text = FormatNumber(CVA_PSTOOL, 2) & " €"
        '------------------------------------------------------------------

        'CAPITAL RESULTS BAIS
        'Dotation Capital
        Dim Core_Capital_element As TileItemElement = Me.Capital_TileItem.Frames(0).Elements(2)
        Core_Capital_element.Text = FormatNumber(Core_Capital, 2) & " €"
        'Own Funds
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('OWN_FUNDS_BAIS') and [RiskDate]='" & rdsql & "'"
        OWN_FUNDS_BAIS = cmd.ExecuteScalar
        Dim OWN_FUNDS_BAIS_element As TileItemElement = Me.Capital_TileItem.Frames(1).Elements(2)
        OWN_FUNDS_BAIS_element.Text = FormatNumber(OWN_FUNDS_BAIS, 2) & " €"
        'Minimum Capital Requirement
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('MIN_REQ_FUNDS_BAIS') and [RiskDate]='" & rdsql & "'"
        MIN_CAP_BAIS = cmd.ExecuteScalar
        Dim MIN_CAP_BAIS_element As TileItemElement = Me.Capital_TileItem.Frames(2).Elements(2)
        MIN_CAP_BAIS_element.Text = FormatNumber(MIN_CAP_BAIS * 1000, 2) & " €"
        'Capital Conservation Bussfer
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('CAP_BUFFER_BAIS') and [RiskDate]='" & rdsql & "'"
        CAP_CONSERV_BUFFER_BAIS = cmd.ExecuteScalar
        Dim CAP_CONSERV_BUFFER_BAIS_element As TileItemElement = Me.Capital_TileItem.Frames(3).Elements(3)
        CAP_CONSERV_BUFFER_BAIS_element.Text = FormatNumber(CAP_CONSERV_BUFFER_BAIS, 2) & " €"
        'Antizkl.Kapital Buffer
        cmd.CommandText = "Select [Amount1] from [GeneralDataInfo] where [Description1] in ('ANTZ_BUFFER_BAIS') and [RiskDate]='" & rdsql & "'"
        CAP_INST_SPEC_BAIS = cmd.ExecuteScalar
        Dim CAP_INST_SPEC_BAIS_element As TileItemElement = Me.Capital_TileItem.Frames(4).Elements(3)
        CAP_INST_SPEC_BAIS_element.Text = FormatNumber(CAP_INST_SPEC_BAIS, 2) & " €"
        'Eligible Capital
        Dim Eligible_Capital_element As TileItemElement = Me.Capital_TileItem.Frames(5).Elements(2)
        Eligible_Capital_element.Text = FormatNumber(ELIGIBLE_CAPITAL_PSTOOL, 2) & " €"


        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If


    End Sub

    Private Sub FORMAT_GENERAL_INFO()
        'format Balance Sheet
        If Math.Abs(BalanceSheetDifference) > 1 Then
            Me.BalanceSheet_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.BalanceSheet_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        Else
            Me.BalanceSheet_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            Me.BalanceSheet_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        End If
        'Format Fristen
        If FristenCount = 0 Then
            Me.Fristen_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.Fristen_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf FristenAssetsCount = 0 OrElse FristenLiabilitiesCount = 0 OrElse FristenOffBalanceLongCount = 0 OrElse FristenOffBalanceShortCount = 0 Then
            Me.Fristen_TileItem.AppearanceItem.Normal.BackColor = Color.IndianRed
            Me.Fristen_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf FristenOthersCount <> 0 Then
            Me.Fristen_TileItem.AppearanceItem.Normal.BackColor = Color.Yellow
            Me.Fristen_TileItem.AppearanceItem.Normal.ForeColor = Color.Black
        Else
            Me.Fristen_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            Me.Fristen_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        End If
        'Format Accrued Interest
        If AccruedInterestCount = 0 Then
            Me.AccruedInterest_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.AccruedInterest_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        Else
            Me.AccruedInterest_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            Me.AccruedInterest_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        End If
        'Trial Balance
        If TrialBalanceConsolidatedCount = 0 OrElse TrialBalanceSingleCount = 0 Then
            'Me.TrialBalance_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            'Me.TrialBalance_TileItem.AppearanceItem.Normal.ForeColor = Color.White
            Me.TrialBalance_TileItem.Frames(0).Appearance.BackColor = Color.Red
            Me.TrialBalance_TileItem.Frames(0).Appearance.ForeColor = Color.White
        Else
            'Me.TrialBalance_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            'Me.TrialBalance_TileItem.AppearanceItem.Normal.ForeColor = Color.White
            Me.TrialBalance_TileItem.Frames(0).Appearance.BackColor = Color.Green
            Me.TrialBalance_TileItem.Frames(0).Appearance.ForeColor = Color.White
        End If
        If TrialBalanceErrorsCount <> 0 Then
            Me.TrialBalance_TileItem.Frames(1).Appearance.BackColor = Color.Red
            Me.TrialBalance_TileItem.Frames(1).Appearance.ForeColor = Color.White
        Else
            Me.TrialBalance_TileItem.Frames(1).Appearance.BackColor = Color.Green
            Me.TrialBalance_TileItem.Frames(1).Appearance.ForeColor = Color.White
        End If
        'Compare Profit Loss in Trial Balance
        Dim N1 As Double = Math.Round(Math.Abs(TrialBalance_NI_Difference) / Math.Abs(TrialBalance_NI_Last), 2)
        If N1 >= Profit_Loss_Compare_Parameter Then
            Me.TrialBalance_TileItem.Frames(8).Appearance.BackColor = Color.Red
            Me.TrialBalance_TileItem.Frames(8).Appearance.ForeColor = Color.White
        Else
            Me.TrialBalance_TileItem.Frames(8).Appearance.BackColor = Color.White
            Me.TrialBalance_TileItem.Frames(8).Appearance.ForeColor = Color.Navy
        End If
        'Compare Assets in Trial Balance
        Dim N2 As Double = Math.Round(Math.Abs(TrialBalance_Assets_Difference) / Math.Abs(TrialBalance_Assets_Last), 2)
        If N2 >= Assets_Liabilities_Compare_Parameter Then
            Me.TrialBalance_TileItem.Frames(2).Appearance.BackColor = Color.Red
            Me.TrialBalance_TileItem.Frames(2).Appearance.ForeColor = Color.White
        Else
            Me.TrialBalance_TileItem.Frames(2).Appearance.BackColor = Color.White
            Me.TrialBalance_TileItem.Frames(2).Appearance.ForeColor = Color.Navy
        End If
        'Compare Liabilities in Trial Balance
        Dim N3 As Double = Math.Round(Math.Abs(TrialBalance_Liabilities_Difference) / Math.Abs(TrialBalance_Liabilities_Last), 2)
        If N3 >= Assets_Liabilities_Compare_Parameter Then
            Me.TrialBalance_TileItem.Frames(3).Appearance.BackColor = Color.Red
            Me.TrialBalance_TileItem.Frames(3).Appearance.ForeColor = Color.White
        Else
            Me.TrialBalance_TileItem.Frames(3).Appearance.BackColor = Color.White
            Me.TrialBalance_TileItem.Frames(3).Appearance.ForeColor = Color.Navy
        End If
        'MAK-Credit Risk
        If MakCount = 0 OrElse CreditRiskCount = 0 Then
            Me.Mak_Credit_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.Mak_Credit_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf FormatNumber(MakSum, 2) <> FormatNumber(CreditRiskSum, 2) Then
            Me.Mak_Credit_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.Mak_Credit_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        Else
            Me.Mak_Credit_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            Me.Mak_Credit_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        End If
        If ContractTypesNoIncludedCount <> 0 Then
            Me.ContractProductTypes_TileItem.Frames(0).Appearance.BackColor = Color.Red
            Me.ContractProductTypes_TileItem.Frames(0).Appearance.ForeColor = Color.Black
        Else
            Me.ContractProductTypes_TileItem.Frames(0).Appearance.BackColor = Color.Green
            Me.ContractProductTypes_TileItem.Frames(0).Appearance.ForeColor = Color.White
        End If
        If ProductTypesNoIncludedCount <> 0 Then
            Me.ContractProductTypes_TileItem.Frames(1).Appearance.BackColor = Color.Green
            Me.ContractProductTypes_TileItem.Frames(1).Appearance.ForeColor = Color.White
        Else
            Me.ContractProductTypes_TileItem.Frames(1).Appearance.BackColor = Color.Green
            Me.ContractProductTypes_TileItem.Frames(1).Appearance.ForeColor = Color.White
        End If
        'Several Tables
        If InterestRateRiskCount = 0 Then
            Me.SeveralTables_TileItem.Frames(0).Appearance.BackColor = Color.Red
            Me.SeveralTables_TileItem.Frames(0).Appearance.ForeColor = Color.White
        Else
            Me.SeveralTables_TileItem.Frames(0).Appearance.BackColor = Color.Green
            Me.SeveralTables_TileItem.Frames(0).Appearance.ForeColor = Color.White
        End If
        If ExchangeRatesCount = 0 Then
            Me.SeveralTables_TileItem.Frames(1).Appearance.BackColor = Color.Red
            Me.SeveralTables_TileItem.Frames(1).Appearance.ForeColor = Color.White
        Else
            Me.SeveralTables_TileItem.Frames(1).Appearance.BackColor = Color.Green
            Me.SeveralTables_TileItem.Frames(1).Appearance.ForeColor = Color.White
        End If
        If CL_DrawdownCount = 0 Then
            Me.SeveralTables_TileItem.Frames(2).Appearance.BackColor = Color.Red
            Me.SeveralTables_TileItem.Frames(2).Appearance.ForeColor = Color.White
        Else
            Me.SeveralTables_TileItem.Frames(2).Appearance.BackColor = Color.Green
            Me.SeveralTables_TileItem.Frames(2).Appearance.ForeColor = Color.White
        End If


        'INTEREST RATE RISK
        If IRR_Rate <= 15 Then
            Me.InterestRateRisk_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            Me.InterestRateRisk_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf IRR_Rate > 15 And IRR_Rate <= 20 Then
            Me.InterestRateRisk_TileItem.AppearanceItem.Normal.BackColor = Color.DarkOrange
            Me.InterestRateRisk_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf IRR_Rate > 20 Then
            Me.InterestRateRisk_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.InterestRateRisk_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        End If

        'RISK BEARING CAPACITY
        If RBC <= 70 Then
            Me.RiskBearingCapacity_TileItem.AppearanceItem.Normal.BackColor = Color.Green
            Me.RiskBearingCapacity_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf RBC > 70 And RBC <= 90 Then
            Me.RiskBearingCapacity_TileItem.AppearanceItem.Normal.BackColor = Color.DarkOrange
            Me.RiskBearingCapacity_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        ElseIf RBC > 90 Then
            Me.RiskBearingCapacity_TileItem.AppearanceItem.Normal.BackColor = Color.Red
            Me.RiskBearingCapacity_TileItem.AppearanceItem.Normal.ForeColor = Color.White
        End If

        'LIQV
        If rd <= DateSerial(2015, 12, 31) Then
            If LiqV_BAIS < 0.6 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.Red
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf LiqV_BAIS >= 0.6 And LiqV_BAIS < 0.7 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.Brown
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf LiqV_BAIS >= 0.7 And LiqV_BAIS < 1 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf LiqV_BAIS >= 1 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.Green
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            End If
            'Ps Tool
            If LiqV_PSTOOL > 0 And LiqV_PSTOOL < 0.6 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.Red
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf LiqV_PSTOOL >= 0.6 And LiqV_PSTOOL < 0.7 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.Brown
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf LiqV_PSTOOL >= 0.7 And LiqV_PSTOOL < 1 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.DarkOrange
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf LiqV_PSTOOL >= 1 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.Green
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            End If
        ElseIf rd >= DateSerial(2016, 1, 1) Then
            If LiqV_BAIS < 0.7 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.Red
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf LiqV_BAIS >= 0.7 And LiqV_BAIS < 0.8 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.Brown
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf LiqV_BAIS >= 0.8 And LiqV_BAIS < 1 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf LiqV_BAIS >= 1 Then
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.BackColor = Color.Green
                Me.LCR_LIQV_TileItem.Frames(0).Appearance.ForeColor = Color.White
            End If
            If LiqV_PSTOOL > 0 And LiqV_PSTOOL < 0.7 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.Red
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf LiqV_PSTOOL >= 0.7 And LiqV_PSTOOL < 0.8 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.Brown
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf LiqV_PSTOOL >= 0.8 And LiqV_PSTOOL < 1 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.DarkOrange
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf LiqV_PSTOOL >= 1 Then
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.BackColor = Color.Green
                Me.LCR_LIQV_TileItem.Frames(1).Appearance.ForeColor = Color.White
            End If
        End If

        'LCR
        If rd <= DateSerial(2015, 12, 31) Then
            If LCR_BAIS < 0.6 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.Red
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            ElseIf LCR_BAIS >= 0.6 And LCR_BAIS <= 0.8 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.DarkOrange
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            ElseIf LCR_BAIS > 0.8 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.Green
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            End If
        ElseIf rd >= DateSerial(2016, 1, 1) Then
            If LCR_BAIS < 0.7 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.Red
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            ElseIf LCR_BAIS >= 0.7 And LCR_BAIS < 0.8 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.Brown
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            ElseIf LCR_BAIS >= 0.8 And LCR_BAIS < 1 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.DarkOrange
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            ElseIf LCR_BAIS > 0.8 Then
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.BackColor = Color.Green
                Me.LCR_LIQV_TileItem.Frames(2).Appearance.ForeColor = Color.White
            End If
        End If
        'CAR
        If rd <= DateSerial(2016, 3, 30) Then
            If rd <= DateSerial(2014, 12, 9) Then
                If CAR_BAIS >= 8.5 And CAR_BAIS < 9.5 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                ElseIf CAR_BAIS >= 8 And CAR_BAIS < 8.5 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Red
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                ElseIf CAR_BAIS < 8 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Crimson
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                ElseIf CAR_BAIS >= 9.5 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Green
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                End If
                'Ps Tool
                If CAR_PSTOOL >= 8.5 And CAR_PSTOOL < 9.5 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.DarkOrange
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                ElseIf CAR_PSTOOL >= 8 And CAR_PSTOOL < 8.5 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Red
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                ElseIf CAR_PSTOOL < 8 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Crimson
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                ElseIf CAR_PSTOOL >= 9.5 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Green
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                End If
            ElseIf rd >= DateSerial(2014, 12, 10) And rd <= DateSerial(2016, 3, 30) Then
                If CAR_BAIS >= 11.4 And CAR_BAIS < 13.4 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                ElseIf CAR_BAIS < 11.4 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Red
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                ElseIf CAR_BAIS >= 13.4 Then
                    Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Green
                    Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
                End If
                'ps tool
                If CAR_PSTOOL >= 11.4 And CAR_PSTOOL < 13.4 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.DarkOrange
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                ElseIf CAR_PSTOOL < 11.4 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Red
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                ElseIf CAR_PSTOOL >= 13.4 Then
                    Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Green
                    Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
                End If
            End If
        ElseIf rd >= DateSerial(2016, 3, 31) Then
            If CAR_BAIS >= 12.025 And CAR_BAIS < 14.025 Then
                Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf CAR_BAIS < 12.025 Then
                Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Red
                Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf CAR_BAIS >= 14.025 Then
                Me.CAR_TileItem.Frames(0).Appearance.BackColor = Color.Green
                Me.CAR_TileItem.Frames(0).Appearance.ForeColor = Color.White
            End If
            'Ps tool
            If CAR_PSTOOL >= 12.025 And CAR_PSTOOL < 14.025 Then
                Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.DarkOrange
                Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf CAR_PSTOOL < 12.025 Then
                Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Red
                Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
            ElseIf CAR_PSTOOL >= 14.025 Then
                Me.CAR_TileItem.Frames(1).Appearance.BackColor = Color.Green
                Me.CAR_TileItem.Frames(1).Appearance.ForeColor = Color.White
            End If
        End If

        'FX CREDIT EQUIVALENT
        If rd <= DateSerial(2017, 6, 20) Then
            If FX_CCB_CRED_EQUIV <= 75000000 Then
                Me.FX_TileItem.Frames(0).Appearance.BackColor = Color.Green
                Me.FX_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf FX_CCB_CRED_EQUIV > 75000000 And FX_CCB_CRED_EQUIV <= 90000000 Then
                Me.FX_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                Me.FX_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf FX_CCB_CRED_EQUIV > 90000000 Then
                Me.FX_TileItem.Frames(0).Appearance.BackColor = Color.Red
                Me.FX_TileItem.Frames(0).Appearance.ForeColor = Color.White
            End If
        ElseIf rd > DateSerial(2017, 6, 20) Then
            If FX_CCB_CRED_EQUIV <= 130000000 Then
                Me.FX_TileItem.Frames(0).Appearance.BackColor = Color.Green
                Me.FX_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf FX_CCB_CRED_EQUIV > 130000000 And FX_CCB_CRED_EQUIV <= 140000000 Then
                Me.FX_TileItem.Frames(0).Appearance.BackColor = Color.DarkOrange
                Me.FX_TileItem.Frames(0).Appearance.ForeColor = Color.White
            ElseIf FX_CCB_CRED_EQUIV > 140000000 Then
                Me.FX_TileItem.Frames(0).Appearance.BackColor = Color.Red
                Me.FX_TileItem.Frames(0).Appearance.ForeColor = Color.White
            End If
        End If

    End Sub

    Private Sub BusinessDate_Comboedit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BusinessDate_Comboedit.ButtonClick
        If e.Button.Caption = "Reload" Then
            If IsDate(BusinessDate_Comboedit.Text) = True Then ' And FormShownStatus = 1 Then
                Try
                    rd = Me.BusinessDate_Comboedit.Text
                    rdsql = rd.ToString("yyyyMMdd")
                    TrialBalanceCurrentDate = rd
                    Me.TileControl1.Visible = False
                    Me.TileControl2.Visible = False
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("General Data Information for " & rd)
                    GET_GENERAL_INFO()
                    FORMAT_GENERAL_INFO()
                    SplashScreenManager.CloseForm(False)
                    Me.TileControl1.Visible = True
                    Me.TileControl2.Visible = True
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

            End If
        End If
    End Sub

   

    Private Sub BusinessDate_Comboedit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BusinessDate_Comboedit.SelectedIndexChanged

        If IsDate(BusinessDate_Comboedit.Text) = True Then ' And FormShownStatus = 1 Then
            Try
                rd = Me.BusinessDate_Comboedit.Text
                rdsql = rd.ToString("yyyyMMdd")
                TrialBalanceCurrentDate = rd
                Me.TileControl1.Visible = False
                Me.TileControl2.Visible = False
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("General Data Information for " & rd)
                GET_GENERAL_INFO()
                FORMAT_GENERAL_INFO()
                SplashScreenManager.CloseForm(False)
                Me.TileControl1.Visible = True
                Me.TileControl2.Visible = True
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try

        End If
    End Sub

    Private Sub GeneralInfoTiles_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FormShownStatus = 1
    End Sub

    
End Class