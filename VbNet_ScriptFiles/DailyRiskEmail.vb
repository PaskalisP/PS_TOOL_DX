Imports System.Text
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.Spreadsheet
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop.outlook

Public Class DAILY_RISK_CONTROLLING_EMAIL
    Inherits System.Windows.Forms.Form

Const TabelleStart As String = "<HTML><BODY><TABLE BORDER='1' CELLSPACING='0' CELLPADDING='1'>"
Const TabelleEnde As String = "</TABLE></BODY></HTML>"
Const ZelleStart As String = "<TD WIDTH=""300"" ALIGN=""RIGHT"">"
Const ZelleStartBackgroundBlue As String = "<TD WIDTH=""300"" ALIGN=""RIGHT"" bgcolor=""#2B3856"">"
Const ZelleStartZahl As String = "<TD WIDTH=""150"" ALIGN=""RIGHT"">"
Const ZelleStartResult As String = "<TD WIDTH=""150"" ALIGN=""RIGHT"">"
Const ZelleEnde As String = "</TD>"

Const ZweiteTabelleStart As String = "<HTML><BODY><TABLE BORDER='1' CELLSPACING='0' CELLPADDING='1'>"
Const ZweiteTabelleEnde As String = "</TABLE></BODY></HTML>"

Private Shared Sub VB_ScriptForExecution()

Dim conndt As New SqlConnection
Dim da As New SqlDataAdapter
Dim dt As New System.Data.DataTable
Dim da1 As New SqlDataAdapter
Dim dt1 As New System.Data.DataTable
Dim da2 As New SqlDataAdapter
Dim dt2 As New System.Data.DataTable
Dim da3 As New SqlDataAdapter
Dim dt3 As New System.Data.DataTable
Dim QueryText As String = Nothing

Dim conn As New SqlConnection
Dim cmd As New SqlCommand

Dim CrystalRepDir As String = ""
Dim ReportExpFile As String = "" 
Dim ReportExpRefiFile As String = ""

Dim EItem As Microsoft.Office.Interop.Outlook.MailItem


conn.ConnectionString = "Data Source=DESKTOP-SLJQ4B6;Initial Catalog=PS TOOL DX Live;Integrated Security=True;Connection Timeout=60"
cmd.Connection = conn
cmd.Connection.Open()
cmd.CommandTimeout = 60000



'Set Dates
Dim rdString as String="30.06.2023"
Dim rd As Date = CDate(rdString)
Dim rdsql as String="20230630"

Dim DateCurrent As New CrystalDecisions.Shared.ParameterValues()
Dim DateFirst As New CrystalDecisions.Shared.ParameterValues
Dim ValueCurrent As New CrystalDecisions.Shared.ParameterDiscreteValue() 'Fieldvalue für das letzte Datum
Dim ValueFirst As New CrystalDecisions.Shared.ParameterDiscreteValue 'Fieldvalue für das erste Datum
ValueCurrent.Value = rd
ValueFirst.Value = DateAdd(DateInterval.Day, -90, rd)
DateCurrent.Add(ValueCurrent)
DateFirst.Add(ValueFirst)

'***********************************************************************
'*******CRYSTAL REPORTS DIRECTORY************
'+++++++++++++++++++++++++++++++++++++++++++++++++++
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
CrystalRepDir = cmd.ExecuteScalar
'***********************************************************************

'Ordner für exportierte Reports erstellen
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_GM_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_GM'"
ReportExpFile = cmd.ExecuteScalar
If System.IO.Directory.Exists(ReportExpFile) = True Then
   System.IO.Directory.Delete(ReportExpFile, True)
End If
If Not System.IO.Directory.Exists(ReportExpFile) Then
   System.IO.Directory.CreateDirectory(ReportExpFile)
End If

'INTEREST RATE RISK REPORT
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('INT_RATE_RISK_REP')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim INT_RATE_RISK_REP_ReportStatus As String = cmd.ExecuteScalar
If INT_RATE_RISK_REP_ReportStatus = "Y" Then
Dim IRR_DATE_Da As New SqlDataAdapter("Select * from [RATERISK DATE] where RateRiskDate='" & rdsql & "' ", conn)
Dim IRR_TOTALS_Da As New SqlDataAdapter("Select * from [RATERISK TOTALS] where [RISK DATE]='" & rdsql & "'", conn)
Dim REPORTINGdataset As New DataSet("REPORTING")
IRR_DATE_Da.Fill(REPORTINGdataset, "RATERISK DATE")
IRR_TOTALS_Da.Fill(REPORTINGdataset, "RATERISK TOTALS")
Dim CrDailyRiskTables As New ReportDocument
CrDailyRiskTables.Load(CrystalRepDir & "\INT_RATE_RISK_REP_Zinsschoks200bps.rpt")
CrDailyRiskTables.SetDataSource(REPORTINGdataset)
CrDailyRiskTables.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrDailyRiskTables.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\INTEREST RATE RISK_" & rdsql & ".pdf")
End If
'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

'DAILY RISK TABLES REPORT
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DAILY_RISK_TABLES')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim DAILY_RISK_TABLES_ReportStatus As String = cmd.ExecuteScalar
If DAILY_RISK_TABLES_ReportStatus = "Y" Then
Dim MAK_ALLDa As New SqlDataAdapter("SELECT * FROM [MAK ALL] where [RiskDate]='" & rdsql & "'", conn)
Dim DAILY_RISK_TABLESdataset As New DataSet("DAILY_RISK_TABLES")
MAK_ALLDa.Fill(DAILY_RISK_TABLESdataset, "MAK_ALL")
Dim CrDailyRiskTables As New ReportDocument
CrDailyRiskTables.Load(CrystalRepDir & "\DAILY_RISK_TABLES.rpt")
CrDailyRiskTables.SetDataSource(DAILY_RISK_TABLESdataset)
CrDailyRiskTables.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrDailyRiskTables.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY RISK TABLES_" & rdsql & ".pdf")
End If
'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 'BUSINESS TYPES - SUM
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('BusinessTypes_CreditPortfolio_SUM')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim BusinessTypes_CreditPortfolio_SUM_ReportStatus As String = cmd.ExecuteScalar
If BusinessTypes_CreditPortfolio_SUM_ReportStatus = "Y" Then
Dim BT_Sums_Da As New SqlDataAdapter("SELECT * FROM [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'", conn)
Dim BT_Sums_dataset As New DataSet("BusinessTypesCreditPortfolioLive")
BT_Sums_Da.Fill(BT_Sums_dataset, "BusinessTypesCreditPortfolioLive")
Dim CrBusinessTypesSum As New ReportDocument
CrBusinessTypesSum.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolio.rpt")
CrBusinessTypesSum.SetDataSource(BT_Sums_dataset)
CrBusinessTypesSum.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent) 
CrBusinessTypesSum.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\BUSINESS TYPES-CREDIT PORTFOLIO (SUM)_" & rdsql & ".pdf")
End If
'+++++++++++++++++++++++++++++++++++++++++++++++++
 'BUSINESS TYPES - Details
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('BusinessTypes_CreditPortfolioDetails')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim BusinessTypes_CreditPortfolioDetails_ReportStatus As String = cmd.ExecuteScalar
If BusinessTypes_CreditPortfolioDetails_ReportStatus = "Y" Then
Dim BT_Details_Da As New SqlDataAdapter("SELECT * FROM [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'", conn)
Dim BT_Details_dataset As New DataSet("BusinessTypesCreditPortfolioDetails")
BT_Details_Da.Fill(BT_Details_dataset, "BusinessTypesCreditPortfolioDetails")
Dim CrBusinessTypesDetails As New ReportDocument
CrBusinessTypesDetails.Load(CrystalRepDir & "\BusinessTypes_CreditPortfolioDetails.rpt")
CrBusinessTypesDetails.SetDataSource(BT_Details_dataset)
CrBusinessTypesDetails.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrBusinessTypesDetails.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\BUSINESS TYPES-CREDIT PORTFOLIO (DETAILS)_" & rdsql & ".pdf")
End If
'+++++++++++++++++++++++++++++++++++++
 'RISK LIMIT DAILY CONTROL
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('RISK_LIMIT_DAILY_CONTROL_REP')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim RISK_LIMIT_DAILY_CONTROL_REP_ReportStatus As String = cmd.ExecuteScalar
If RISK_LIMIT_DAILY_CONTROL_REP_ReportStatus = "Y" Then
Dim RLDC_Da As New SqlDataAdapter("SELECT * FROM [RISK LIMIT DAILY CONTROL]  ORDER BY [RLDC Date] desc", conn)
Dim RLDC_dataset As New DataSet("RISK LIMIT DAILY CONTROL")
RLDC_Da.Fill(RLDC_dataset, "RISK LIMIT DAILY CONTROL")
Dim CrRepRiskLimitDailyControl As New ReportDocument
CrRepRiskLimitDailyControl.Load(CrystalRepDir & "\RISK_LIMIT_DAILY_CONTROL_REP.rpt")
CrRepRiskLimitDailyControl.SetDataSource(RLDC_dataset)
CrRepRiskLimitDailyControl.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK LIMIT DAILY CONTROL.pdf")
End If
'++++++++++++++++++++++++++++++++++++
'DAILY RISK CHART REPORT
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('DAILY_RISK_CHART')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim DAILY_RISK_CHART_ReportStatus As String = cmd.ExecuteScalar
If DAILY_RISK_CHART_ReportStatus = "Y" Then
Dim RLDC_Da As New SqlDataAdapter("SELECT * FROM [RISK LIMIT DAILY CONTROL] ORDER BY [RLDC Date] desc", conn)
Dim RLDC_dataset As New DataSet("RISK LIMIT DAILY CONTROL")
RLDC_Da.Fill(RLDC_dataset, "RISK LIMIT DAILY CONTROL")
Dim CrRepDailyRiskChart As New ReportDocument
CrRepDailyRiskChart.Load(CrystalRepDir & "\DAILY_RISK_CHART.rpt")
CrRepDailyRiskChart.SetDataSource(RLDC_dataset)
CrRepDailyRiskChart.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateFirst)
CrRepDailyRiskChart.DataDefinition.ParameterFields(1).ApplyCurrentValues(DateCurrent)
CrRepDailyRiskChart.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY RISK CHART REPORT_" & rdsql & ".pdf")
End If
'++++++++++++++++++++++++++++++++++++
'RISK BEARING CAPACITY CHART
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('RISK_BEARING_CAPACITY_CHART')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim RISK_BEARING_CAPACITY_CHART_ReportStatus As String = cmd.ExecuteScalar
If RISK_BEARING_CAPACITY_CHART_ReportStatus = "Y" Then
Dim CrRepRiskBearingCapacityChart As New ReportDocument
Dim RLDC_Da As New SqlDataAdapter("SELECT * FROM [RISK LIMIT DAILY CONTROL] ORDER BY [RLDC Date] desc", conn)
Dim RLDC_dataset As New DataSet("RISK LIMIT DAILY CONTROL")
RLDC_Da.Fill(RLDC_dataset, "RISK LIMIT DAILY CONTROL")
CrRepRiskBearingCapacityChart.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_CHART.rpt")
CrRepRiskBearingCapacityChart.SetDataSource(RLDC_dataset)
CrRepRiskBearingCapacityChart.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateFirst)
CrRepRiskBearingCapacityChart.DataDefinition.ParameterFields(1).ApplyCurrentValues(DateCurrent)
CrRepRiskBearingCapacityChart.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY CHART REPORT.pdf")
End If
'+++++++++++++++++++++++++
'OBLIGO LIABILITY SURPLUS
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('ObligoLiabilitySurplus')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim ObligoLiabilitySurplus_ReportStatus As String = cmd.ExecuteScalar
If ObligoLiabilitySurplus_ReportStatus = "Y" Then
Dim CrRepObligoLiabilitySurplus As New ReportDocument
Dim ObligoLiabilitiesDa As New SqlDataAdapter("SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]='" & rdsql & "'", conn)
Dim ObligoLiabilitiesDataset As New DataSet("OBLIGO_REPORTING")
ObligoLiabilitiesDa.Fill(ObligoLiabilitiesDataset, "OBLIGO_SURPLUS_DETAILS")
CrRepObligoLiabilitySurplus.Load(CrystalRepDir & "\ObligoLiabilitySurplusNew.rpt")
CrRepObligoLiabilitySurplus.SetDataSource(ObligoLiabilitiesDataset)
CrRepObligoLiabilitySurplus.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrRepObligoLiabilitySurplus.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\OBLIGO LIABILITY SURPLUS REPORT_" & rdsql & ".pdf")
End If
'++++++++++++++++++++++++
'RISK BEARING CAPACITY CASH PLEDGE
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('RISK_BEARING_CAPACITY_TOTAL')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim RISK_BEARING_CAPACITY_TOTAL_ReportStatus As String = cmd.ExecuteScalar
If RISK_BEARING_CAPACITY_TOTAL_ReportStatus = "Y" Then
Dim RiskBearingCapacity_Da As New SqlDataAdapter("SELECT * FROM [RISK_BEARING_CAPACITY_CALCULATIONS] where [RiskDate]='" & rdsql & "'", conn)
Dim RiskBearingCapacityDataset As New DataSet("RBC")
RiskBearingCapacity_Da.Fill(RiskBearingCapacityDataset, "RISK_BEARING_CAPACITY_CALCULATIONS")
Dim CrRepRiskBearingCapacityCashPledge As New ReportDocument
CrRepRiskBearingCapacityCashPledge.Load(CrystalRepDir & "\RISK_BEARING_CAPACITY_TOTAL.rpt")
CrRepRiskBearingCapacityCashPledge.SetDataSource(RiskBearingCapacityDataset)
CrRepRiskBearingCapacityCashPledge.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrRepRiskBearingCapacityCashPledge.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\RISK BEARING CAPACITY_" & rdsql & ".pdf")
End If
'++++++++++++++++++++++++++++++++++++
'++++++++++++++++++++++++++++++++++++
'USD EXCHANGE RATE MONITORING
cmd.CommandText = "SELECT [PARAMETER STATUS] FROM [PARAMETER] WHERE [PARAMETER1] in ('USD_ExchangeRate_Monitoring')  AND [IdABTEILUNGSPARAMETER] in ('EMAIL_GM_REPORTS')"
Dim USD_ExchangeRate_Monitoring_ReportStatus As String = cmd.ExecuteScalar
If USD_ExchangeRate_Monitoring_ReportStatus = "Y" Then
cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EXCHANGE RATES MONITORING' AND xtype='U')  CREATE TABLE [EXCHANGE RATES MONITORING]([ID] [int] IDENTITY(1,1) NOT NULL,[OrigID] [int] NULL,[CURRENCY CODE] [nvarchar](255) NULL,[MIDDLE RATE] [float] NULL,[YESTERDAYS_RATE] [float] NULL,[COMPARED_WITH_YESTERDAY] [float] NULL,[COMPARED_WITH_YESTERDAY_PERCENT] [float] NULL,[CHANGES_WITHIN_WEEK] [float] NULL,[CHANGES_WITHIN_MONTH] [float] NULL,[EXCHANGE RATE DATE] [datetime] NULL) ELSE DELETE FROM [EXCHANGE RATES MONITORING]"
cmd.ExecuteNonQuery()
cmd.CommandText = "INSERT INTO [EXCHANGE RATES MONITORING](OrigID,[CURRENCY CODE],[MIDDLE RATE],[EXCHANGE RATE DATE]) select [ID],[CURRENCY CODE],[MIDDLE RATE],[EXCHANGE RATE DATE] from [EXCHANGE RATES OCBS] where [CURRENCY CODE]='USD' and [EXCHANGE RATE DATE]>=dateadd(month,-1,'" & rdsql & "') and [EXCHANGE RATE DATE]<=(Select max([EXCHANGE RATE DATE]) from [EXCHANGE RATES OCBS]) order by [EXCHANGE RATE DATE] asc"
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
ExchangeRateMonitoringDa.Fill(USD_Rate_Monitoring_Dataset, "EXCHANGE_RATES_MONITORING")
Dim CrExchangeRatesMonitoring As New ReportDocument
CrExchangeRatesMonitoring.Load(CrystalRepDir & "\EXCHANGE_RATE_MONITORING.rpt")
CrExchangeRatesMonitoring.SetDataSource(USD_Rate_Monitoring_Dataset)
CrExchangeRatesMonitoring.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\MONITORING OF EXCHANGE RATE (EUR-USD)_" & rdsql & ".pdf")
cmd.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
cmd.ExecuteNonQuery()
cmd.CommandText = "DROP TABLE [EXCHANGE RATES MONITORING]"
cmd.ExecuteNonQuery()
cmd.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
cmd.ExecuteNonQuery()
End if
'+++++++++++++++++++++++++++++++++++
'SELECT FILES FROM RELATED BAIS DIRECTORY
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
Dim BAISDirectory As String = cmd.ExecuteScalar()
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_FILENAME_BEGINS' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
Dim BAIS_NAME_BEGINS As String = cmd.ExecuteScalar()
QueryText = "SELECT * FROM [PARAMETER] WHERE  [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_GM_BAIS_FILES'"
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New DataTable()
da.Fill(dt)
If dt.Rows.Count > 0 Then
For i as integer = 0 To dt.Rows.Count - 1
Dim BaisFileFullName As String = BAISDirectory & BAIS_NAME_BEGINS & "20230930" & dt.Rows.Item(i).Item("PARAMETER2")
FileCopy(BaisFileFullName, ReportExpFile & dt.Rows.Item(i).Item("PARAMETER1"))
Dim FileName as String=Path.GetFileNameWithoutExtension(ReportExpFile & dt.Rows.Item(i).Item("PARAMETER1"))
Dim FileExtension as string=Path.getExtension(ReportExpFile & dt.Rows.Item(i).Item("PARAMETER1"))
Dim NewFileName as string=FileName & "_20230930" & FileExtension
My.Computer.FileSystem.renameFile(ReportExpFile & dt.Rows.Item(i).Item("PARAMETER1"), NewfileName)
Next
End If
dt.reset()


        'GET THE EMAIL RECEIVERS_TO
        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_TO As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            EMAIL_TO += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        dt.reset()

        'GET THE EMAIL RECEIVERS_CC
        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS_CC'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_CC As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            EMAIL_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        dt.reset()

        'GET THE EMAIL RECEIVERS_BCC
        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_GM_RECEIVERS_BCC'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Dim EMAIL_BCC As String = ""
        For i As Integer= 0 To dt.Rows.Count - 1
            EMAIL_BCC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        Next
        dt.reset()

'Get figures for Email Body
QueryText = "SELECT * FROM [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql & "'"
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New DataTable()
da.Fill(dt)
Dim ProfitLossResult As Double = dt.Rows.Item(0).Item("PL Result")
Dim BUBA_InterestAmount As Double = dt.Rows.Item(0).Item("BUBA_InterestAmount")

'Profit/Loss
Dim ProfitLossBody_Value As String = ""
Dim ProfitLossBody_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Profit / Loss result (according to NGS market value approach for FX evaluation)</font></body></html>"
If ProfitLossResult > 0 Then
ProfitLossBody_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(ProfitLossResult, "#,##0.00 €") & "<br></font></body></html>"
ElseIf ProfitLossResult < 0 Then
ProfitLossBody_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(ProfitLossResult, "#,##0.00 €") & "<br></font></body></html>"
Else
ProfitLossBody_Value = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(ProfitLossResult, "#,##0.00 €") & "<br></font></body></html>"
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

Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
Dim outApp As Microsoft.Office.Interop.Outlook.Application

outApp = New Microsoft.Office.Interop.Outlook.Application

NSpace = outApp.GetNamespace("MAPI")
Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

EItem.To = EMAIL_TO
EItem.CC = EMAIL_CC
EItem.BCC=EMAIL_BCC
'EItem.Attachments.Add(ReportExpRefiFile & "\REFINANCING MATURITY LIST.pdf")

'Attach all files in Email
Dim File as string=Nothing
For Each File In System.IO.Directory.GetFiles(ReportExpFile)
     EItem.Attachments.Add(File)
Next File

EItem.Subject = "DAILY RISK CONTROL OVERVIEW on " & rd

EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML

Dim absatz As String = "<html><body><br><br></font></body></html>"
Dim StrBody1 As String = "<html><body><font size=2>******This is an automated E-Mail, generated from the PS TOOL Application!******<br><br>"
Dim StrBody2 As String = "<html><body><b><font color=""Blue"" size=2><U>Dear Colleagues,<br>" _
                          + " <font color=""Blue""><U>for your information the daily risk control overview on " & rd & " as follows:<U><br><br></font></body></html>"

EItem.HTMLBody = StrBody1 & StrBody2 _
                 & TabelleStart & ZelleStart & ProfitLossBody_Text & ZelleEnde & ZelleStartZahl & ProfitLossBody_Value & ZelleEnde & TabelleEnde _
                 & TabelleStart & ZelleStart & BUBA_Interest_Text & ZelleEnde & ZelleStartZahl & BUBA_Interest_Value & ZelleEnde & TabelleEnde
EItem.Display()

If System.IO.Directory.Exists(ReportExpFile) = True Then
   System.IO.Directory.Delete(ReportExpFile, True)
End If



cmd.Connection.close()

End Sub

End Class