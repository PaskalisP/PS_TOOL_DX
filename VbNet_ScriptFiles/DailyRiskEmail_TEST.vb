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

Public Shared Sub VB_ScriptForExecution()

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

Dim crTableLogOnInfo As CrystalDecisions.Shared.TableLogOnInfo
Dim crConnectionInfo As New ConnectionInfo()

Dim conn As New SqlConnection
Dim cmd As New SqlCommand

Dim CrystalRepDir As String = ""
Dim ReportExpFile As String = "" 
Dim ReportExpRefiFile As String = ""

Dim EItem As Microsoft.Office.Interop.Outlook.MailItem


conn.ConnectionString = "Data Source=DESKTOP-SLJQ4B6;Initial Catalog=PS TOOL DX Live;Integrated Security=True;Connection Timeout=60000"
cmd.Connection = conn
cmd.Connection.Open()
cmd.CommandTimeout = 60000
'Set the new database connection information with integrated security for Crystal Reports
crConnectionInfo.ServerName = "DESKTOP-SLJQ4B6"
crConnectionInfo.DatabaseName = "PS TOOL DX Live"
crConnectionInfo.IntegratedSecurity = True ' Set integrated security to True

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
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y'"
CrystalRepDir = cmd.ExecuteScalar
'***********************************************************************
'Ordner für exportierte Reports
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_GM_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_GM'"
ReportExpFile = cmd.ExecuteScalar

'Ordner für exportierte Reports erstellen
cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_GM_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_GM'"
ReportExpFile = cmd.ExecuteScalar
If System.IO.Directory.Exists(ReportExpFile) = True Then
   System.IO.Directory.Delete(ReportExpFile, True)
End If
If Not System.IO.Directory.Exists(ReportExpFile) Then
   System.IO.Directory.CreateDirectory(ReportExpFile)
End If

Dim MAK_ALLDa As New SqlDataAdapter("SELECT * FROM [MAK ALL] where [RiskDate]='" & rdsql & "'", conn)
Dim DAILY_RISK_TABLESdataset As New DataSet("DAILY_RISK_TABLES")
MAK_ALLDa.Fill(DAILY_RISK_TABLESdataset, "MAK_ALL")
Dim CrDailyRiskTables As New ReportDocument
CrDailyRiskTables.Load(CrystalRepDir & "\DAILY_RISK_TABLES.rpt")
'Loop through the tables in the report and update the connection
For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In CrDailyRiskTables.Database.Tables
    crTableLogOnInfo = crTable.LogOnInfo
    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
    crTable.ApplyLogOnInfo(crTableLogOnInfo)
Next
CrDailyRiskTables.SetDataSource(DAILY_RISK_TABLESdataset)
CrDailyRiskTables.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrDailyRiskTables.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY RISK TABLES_" & rdsql & ".pdf")



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

QueryText = "SELECT * FROM [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql & "'"
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New DataTable()
da.Fill(dt)
Dim ProfitLossResult As Double = dt.Rows.Item(0).Item("PL Result")
Dim BUBA_InterestAmount As Double = dt.Rows.Item(0).Item("BUBA_InterestAmount")
Dim HGB_PL_Calculated As Double = dt.Rows.Item(0).Item("HGB_PL_Calculated")
Dim ObligoLiabilitySurplusHGB As Double = dt.Rows.Item(0).Item("CCBINFO Obligo Liability surplus")
Dim ObligoLiabilitySurplusRiskSubtotal As Double = dt.Rows.Item(0).Item("CCBINFO Obligo Liability surplus Risk Subtotal")
Dim FX_Position As Double = dt.Rows.Item(0).Item("Treasury FX position")
Dim CAR_Value As Double = dt.Rows.Item(0).Item("Bank SolvV") / 100
Dim CapitalRatio_T1 As Double = dt.Rows.Item(0).Item("CapitalRatio_T1") / 100
Dim CoreCapital As Double = dt.Rows.Item(0).Item("Core capital")
Dim CapitalForSolva As Double = dt.Rows.Item(0).Item("CapitalForSolvV")
Dim OwnFunds As Double = dt.Rows.Item(0).Item("OwnCapitalBAIS")
Dim MinCapitalReq As Double = dt.Rows.Item(0).Item("Minimum capital requirement")
Dim BilanzCustDeposit As Double = dt.Rows.Item(0).Item("Bank Bilanz")
Dim CreditRisk As Double = dt.Rows.Item(0).Item("Credit Risk")
Dim CreditRiskCP As Double = dt.Rows.Item(0).Item("CreditRiskCashPledge")
Dim InterestRateRisk As Double = dt.Rows.Item(0).Item("Interest rate risk") / 100
Dim InterestRateRiskMinus200 As Double = dt.Rows.Item(0).Item("InterestRateRisk_Minus200bps") / 100
Dim InterestRateRiskPlus200 As Double = dt.Rows.Item(0).Item("InterestRateRisk_Plus200bps") / 100
Dim InterestRateRiskAmount50bps As Double = dt.Rows.Item(0).Item("Interest risk")
Dim CurrencyRisk As Double = dt.Rows.Item(0).Item("Currency risk")
Dim OperationalRisk As Double = dt.Rows.Item(0).Item("Operational risk")
Dim LiquidityRisk As Double = dt.Rows.Item(0).Item("Liquidity risk")
Dim RiskBearingCapacity As Double = dt.Rows.Item(0).Item("RiskBearingCapacityCashPledge")
Dim LCR_Ratio As Double = dt.Rows.Item(0).Item("LCR_Ratio")
Dim OCBS_IDW_Difference As Double = dt.Rows.Item(0).Item("PLdifferenceOCBS_IDW")
Dim OCBS_IDW_INTERN_Difference As Double = dt.Rows.Item(0).Item("PLdifferenceOCBS_IDW_INTERN")
Dim FX_DAILY_EVALUATION As Double = dt.Rows.Item(0).Item("FX_Evaluation_Temp")
Dim ProfitLossRecalculated As Double = dt.Rows.Item(0).Item("PLrecalculated")
Dim Kapitalerhaltungspuffer As Double = dt.Rows.Item(0).Item("KapitalerhaltungsPuffer")
Dim AntizyklischerKapitalpuffer As Double = dt.Rows.Item(0).Item("AntizyklischerKapitalPuffer")
Dim LeverageRatio_BAIS As Double = dt.Rows.Item(0).Item("LeverageRatio_BAIS")
Dim NSFRRatio_BAIS As Double = dt.Rows.Item(0).Item("NSFRRatio_BAIS")

dt.reset()

'Balance Sheet Totals
cmd.CommandText = "SELECT Sum([BalanceEUREqu]) FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "' and [GL_Item]='4999'"
Dim BalanceTotal As Double = cmd.ExecuteScalar
'CCB GUARANTEES
cmd.CommandText = "SELECT Sum([LC_Amount]) FROM [GUARANTEE_EXPOSURE] where ([ClientName] like 'CHINA CONSTRUCTION%' or [ClientName] like 'CCB%') and [RiskDate]='" & rdsql & "'"
Dim CCB_Guarantees_Amount As Double = 0
If cmd.ExecuteScalar IsNot System.DBNull.Value Then
    CCB_Guarantees_Amount = FormatNumber(cmd.ExecuteScalar, 2)
End If
'CCB FX CREDIT EQUIVA. AMOUNT
cmd.CommandText = "SELECT [CreditEquivelantAmount] as s FROM [FX CREDIT EQUIVALENT Basic] where [ClientGroup]='1000' and [RiskDate]='" & rdsql & "'"
Dim CCB_Credit_Equiv_Amount As Double = 0
If cmd.ExecuteScalar IsNot System.DBNull.Value Then
    CCB_Credit_Equiv_Amount = FormatNumber(cmd.ExecuteScalar, 2)
End If
'ELIGIBLE CAPITAL FOR LARGE LOANS
Dim EligibleCapitalLargeLoans As Double = 0
cmd.CommandText = "Select [CapitalForSolvV] from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & rdsql & "' GROUP BY [CapitalForSolvV]"
If cmd.ExecuteScalar IsNot System.DBNull.Value Then
    EligibleCapitalLargeLoans = FormatNumber(cmd.ExecuteScalar, 2)
End If
Dim CCB_FX_CREDIT_TOTAL As Double = CCB_Guarantees_Amount + CCB_Credit_Equiv_Amount
Dim CCB_FX_CREDIT_TOTAL_PERCENT As Double = CCB_FX_CREDIT_TOTAL / EligibleCapitalLargeLoans
Dim LARGE_LOANS_EXPOSURE As Double = 0
cmd.CommandText = "Select [ExposureAmountMAX] from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & rdsql & "'"
LARGE_LOANS_EXPOSURE = cmd.ExecuteScalar
Dim Capital_plus_HGB340F As Double = 0
cmd.CommandText = "Select Sum(A.A) from (Select distinct([CapitalForSolvV]) as A from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & rdsql & "' Union All Select HGB340F*1000 as A from [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql & "')A"
Capital_plus_HGB340F = cmd.ExecuteScalar
Dim LARGE_LOANS_EXPOSURE_HGB340F As Double = System.Math.Round(Capital_plus_HGB340F * 0.25, 2)  
'SECURITIES DEPRECIATIONS
Dim SECURITIES_DEPRECIATIONS As Double = 0   
cmd.CommandText = "DECLARE @RISKDATE Datetime SET @RISKDATE='" & rdsql & "' DECLARE @BOND_IMPAIRMENT_LAST_YEAR float DECLARE @BOND_DEPRECIATION_ACTUAL float DECLARE @BOND_IMPAIRMENT_DIFFERENCE float DECLARE @SECURITIES_DEPRECIATION_RESULT float SET @BOND_IMPAIRMENT_LAST_YEAR=(Select ABS([SecuritiesDepreciations]) from [RISK LIMIT DAILY CONTROL] where [RLDC Date]=(select dateadd(DD, -1, dateadd(YY,datediff(yy,0,GETDATE()),0)))) SET @BOND_DEPRECIATION_ACTUAL=(Select [SecuritiesDepreciations] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]=@RISKDATE ) SET @BOND_IMPAIRMENT_DIFFERENCE=@BOND_IMPAIRMENT_LAST_YEAR+@BOND_DEPRECIATION_ACTUAL IF @BOND_IMPAIRMENT_DIFFERENCE>0 BEGIN SET @SECURITIES_DEPRECIATION_RESULT=0 END ELSE BEGIN SET @SECURITIES_DEPRECIATION_RESULT=@BOND_IMPAIRMENT_DIFFERENCE END Select @SECURITIES_DEPRECIATION_RESULT"
SECURITIES_DEPRECIATIONS = cmd.ExecuteScalar

'Recalculate P/L based on the 2 IDW Methods and BUBA Interests
Dim PL_After_BUBA As Double = ProfitLossResult + BUBA_InterestAmount
Dim PL_NewResult_Std_IDW As Double = PL_After_BUBA + OCBS_IDW_Difference
Dim PL_NewResult_Intern_IDW As Double = PL_After_BUBA + OCBS_IDW_INTERN_Difference
'---Additional Info for Profit/Loss
Dim AdditionalInfoText As String = Nothing
Dim AdditionalInfoAmount As Double = 0
QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DailyEmail_PL_AdditionalInfo')) and '" & rdsql & "' BETWEEN [SQL_Date1] and [SQL_Date2] and [Status] in ('Y')"
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
If dt.Rows.Count > 0 Then
AdditionalInfoText = dt.Rows.Item(0).Item("SQL_Name_1").ToString
AdditionalInfoAmount = CDbl(dt.Rows.Item(0).Item("SQL_Float_2").ToString)
End If
dt.reset()

Dim PL_NewResult_Intern_NEWG As Double = PL_NewResult_Intern_IDW + SECURITIES_DEPRECIATIONS + AdditionalInfoAmount 'Additional Amount to P/L

Dim PL_NewResult_HGB As Double = PL_After_BUBA + FX_DAILY_EVALUATION
Dim HGB_PL_After_BUBA As Double = HGB_PL_Calculated + BUBA_InterestAmount
'New format++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Dim PL_NewResult_afterImpairments As Double = PL_After_BUBA + SECURITIES_DEPRECIATIONS + AdditionalInfoAmount
PL_NewResult_Intern_IDW = PL_NewResult_afterImpairments + OCBS_IDW_INTERN_Difference
'*****************************************************************************
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
Dim ObligoLiabilitySurplusHGB_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Obligo Liability surplus (HGB)<br></font></body></html>"
Dim ObligoLiabilitySurplusHGB_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(ObligoLiabilitySurplusHGB, "#,##0.00 €") & "<br></font></body></html>"
'Capital Adequacy ratio
Dim TotalCapitalRatio_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Total capital ratio <br></font></body></html>"
Dim TotalCapitalRatio_Value As String = ""
If CAR_Value * 100 >= 15.5 And CAR_Value * 100 < 17.5 Then
TotalCapitalRatio_Value = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
ElseIf CAR_Value * 100 < 15.5 Then
TotalCapitalRatio_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
ElseIf CAR_Value * 100 >= 17.5 Then
TotalCapitalRatio_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CAR_Value, "#0.00 %") & "<br></font></body></html>"
End If
'Capital Adequacy ratio-Create CapitalRatio_T1 body
Dim CapitalRatio_T1_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
Dim CapitalRatio_T1_Text As String = Nothing
CapitalRatio_T1_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>T1 Capital ratio<br></font></body></html>"
If CapitalRatio_T1 * 100 >= 12.875 And CapitalRatio_T1 * 100 < 14.375 Then
CapitalRatio_T1_Amount = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
ElseIf CapitalRatio_T1 * 100 < 12.875 Then
CapitalRatio_T1_Amount = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
ElseIf CapitalRatio_T1 * 100 >= 14.375 Then
CapitalRatio_T1_Amount = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CapitalRatio_T1, "#0.00 %") & "<br></font></body></html>"
End If
'Core Capital - TIER 1 Capital
Dim Tier1Capital_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>TIER 1 Capital <br></font></body></html>"
Dim Tier1Capital_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CapitalForSolva, "#,##0.00 €") & "<br></font></body></html>"

'Core Capital - Eligible Capital for Large Loans
Dim EligibleCapital_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Eligible Capital <br></font></body></html>"
Dim EligibleCapital_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(EligibleCapitalLargeLoans, "#,##0.00 €") & "<br></font></body></html>"

'Own Funds
Dim StrBodyOwnFunds_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Own Funds<br></font></body></html>"
Dim StrBodyOwnFunds_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(OwnFunds, "#,##0.00 €") & "<br></font></body></html>"

'Minimum Capital Requirement
Dim MinimumCapitalRequirement_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Minimum Capital requirement<br></font></body></html>"
Dim MinimumCapitalRequirement_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(MinCapitalReq * 1000, "#,##0.00 €") & "<br></font></body></html>"

'LCR Ratio
Dim LcrRatio_Text As String = Nothing
Dim LcrRatio_Value As String = ""
LcrRatio_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>LCR Ratio (Delegated Act) <br><font color=""Blue"" size=1>(Info: Not less than 1,0)<br></font></body></html>"
If LCR_Ratio < 1 Then
LcrRatio_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf LCR_Ratio >= 1 And LCR_Ratio < 1.05 Then
LcrRatio_Value = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf LCR_Ratio >= 1.05 And LCR_Ratio < 1.1 Then
LcrRatio_Value = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf LCR_Ratio >= 1.1 Then
LcrRatio_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LCR_Ratio, "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
End If

'NSFR Ratio BAIS
Dim NSFRRatio_Text As String = Nothing
Dim NSFRRatio_Value As String = ""
NSFRRatio_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>NSFR Ratio <br><font color=""Blue"" size=1>(Info: Not less than 1,0)<br></font></body></html>"
If NSFRRatio_BAIS  < 1 Then
NSFRRatio_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(NSFRRatio_BAIS , "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf NSFRRatio_BAIS  >= 1 And NSFRRatio_BAIS < 1.3 Then
NSFRRatio_Value = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(NSFRRatio_BAIS , "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf NSFRRatio_BAIS  >= 1.3 Then
NSFRRatio_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(NSFRRatio_BAIS , "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
End If


'Leverage Ratio BAIS
Dim LeverageRatio_Text As String = Nothing
Dim LeverageRatio_Value As String = ""
LeverageRatio_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Leverage Ratio <br><font color=""Blue"" size=1>(Info: Not less than 3,0)<br></font></body></html>"
If LeverageRatio_BAIS  < 3 Then
LeverageRatio_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(LeverageRatio_BAIS , "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf LeverageRatio_BAIS  >= 3 And LeverageRatio_BAIS < 4 Then
LeverageRatio_Value = "<html><body><b><font color=""Brown"" face=""calibri"" size=2>" & Format(LeverageRatio_BAIS , "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
ElseIf LeverageRatio_BAIS  >= 4 Then
LeverageRatio_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(LeverageRatio_BAIS , "#0.00") & "&nbsp;&nbsp;&nbsp;&nbsp;<br></font></body></html>"
End If


'Customer Demand Deposits
Dim CustomerDemandDeposits_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Customer demand deposits (without Suspense Acc.)<br></font></body></html>"
Dim CustomerDemandDeposits_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(BilanzCustDeposit, "#,##0.00 €") & "<br></font></body></html>"

'Credit Risk (with and without Cash pledge)
Dim StrBody11_1 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Credit Risk <br><font color=""Blue"">(No Cash pledge consideration)<br></font></body></html>"
Dim StrBody11 As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CreditRisk, "#,##0.00 €") & "<br></font></body></html>"
Dim CreditRiskCashPledge_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Credit Risk <br><font color=""Blue"" size=1>(LGD 45%)<br></font></body></html>"
Dim CreditRiskCashPledge_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CreditRiskCP, "#,##0.00 €") & "<br></font></body></html>"

'Interest Rate Risk
Dim InterestRateRiskFigure_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk - ABSOLUTE HIGHEST FIGURE <br><font color=""Blue"" size=1>(Info: Not higher than 20,00 %)<br></font></body></html>"
Dim InterestRateRiskFigure_Value As String = ""
If InterestRateRisk * 100 <= 15 Then
InterestRateRiskFigure_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(InterestRateRisk, "#0.00 %") & "<br></font></body></html>"
ElseIf InterestRateRisk * 100 > 15 And InterestRateRisk * 100 <= 20 Then
InterestRateRiskFigure_Value = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(InterestRateRisk, "#0.00 %") & "<br></font></body></html>"
ElseIf InterestRateRisk * 100 > 20 Then
InterestRateRiskFigure_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(InterestRateRisk, "#0.00 %") & "<br></font></body></html>"
End If
Dim InterestRateRiskMinus200bps_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk (- 200 bps) <br></font></body></html>"
Dim InterestRateRiskMinus200bps_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(InterestRateRiskMinus200, "#0.00 %") & "<br></font></body></html>"
Dim InterestRateRiskPlus200bps_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk (+ 200 bps) <br></font></body></html>"
Dim InterestRateRiskPlus200bps_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(InterestRateRiskPlus200, "#0.00 %") & "<br></font></body></html>"

'Interest Rate Risk Amount (Weighting Factor 50%)
Dim InterestRateRisk50bps_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Interest Rate Risk Amount (RGB)<br></font></body></html>"
Dim InterestRateRisk50bps_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(InterestRateRiskAmount50bps, "#,##0.00 €") & "<br></font></body></html>"

'Currency Risk
Dim CurrencyRisk_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Currency Risk<br></font></body></html>"
Dim CurrencyRisk_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CurrencyRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

'Operational Risk
Dim OperationalRisk_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Operational Risk<br></font></body></html>"
Dim OperationalRisk_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(OperationalRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

'Liquidity Risk
Dim LiquidityRisk_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Liquidity Risk<br></font></body></html>"
Dim LiquidityRisk_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(LiquidityRisk * 1000, "#,##0.00 €") & "<br></font></body></html>"

'CCB Guarantees Amount
Dim CcbGuaranteesAmount_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB Guarantees Amount<br></font></body></html>"
Dim CcbGuaranteesAmount_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CCB_Guarantees_Amount, "#,##0.00 €") & "<br></font></body></html>"

'CCB FX Credit Equivelant Amount
Dim CcbFxCreditEquivalentAmount_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB FX Credit Equiv. Amount<br><font color=""Blue"" size=1>(Info: Calculating by SA-CCR<br></font></body></html>"
Dim CcbFxCreditEquivalentAmount_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(CCB_Credit_Equiv_Amount, "#,##0.00 €") & "<br></font></body></html>"

'CCB FX CREDIT TOTAL
Dim CcbFxCreditEquivalentGuarantees_Text As String = Nothing
CcbFxCreditEquivalentGuarantees_Text = "<html><body><b><font color=""Black"" face=""calibri"" size=2>CCB FX Credit Equiv. Amount (incl. Guarantees)<br><font color=""Blue"" size=1>(Info: The large exposure to CIC is 150M)<br></font></body></html>"
Dim CcbFxCreditEquivalentGuarantees_Value As String = ""
Dim CcbFxCreditEquivalentGuarantees_AdditionalText As String = ""
If CCB_FX_CREDIT_TOTAL <= 130000000 Then
CcbFxCreditEquivalentGuarantees_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
CcbFxCreditEquivalentGuarantees_AdditionalText = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
ElseIf CCB_FX_CREDIT_TOTAL > 130000000 And CCB_FX_CREDIT_TOTAL <= 140000000 Then
CcbFxCreditEquivalentGuarantees_Value = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
CcbFxCreditEquivalentGuarantees_AdditionalText = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
ElseIf CCB_FX_CREDIT_TOTAL > 140000000 Then
CcbFxCreditEquivalentGuarantees_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL, "#,##0.00 €") & "<br></font></body></html>"
CcbFxCreditEquivalentGuarantees_AdditionalText = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(CCB_FX_CREDIT_TOTAL_PERCENT, "#0.00 %") & "<br></font></body></html>"
End If

'RISK BEARING CAPACITY - CASH PLEDGE
Dim RiskBearingCapacity_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>RISK BEARING CAPACITY <br><font color=""Blue"" size=1>(Info: Not higher than 90,00 %)"
Dim RiskBearingCapacity_Value As String = ""
If RiskBearingCapacity <= 70 Then
    RiskBearingCapacity_Value = "<html><body><b><font color=""Green"" face=""calibri"" size=2>" & Format(RiskBearingCapacity / 100, "#0.00 %") & "<br></font></body></html>"
ElseIf RiskBearingCapacity > 70 And RiskBearingCapacity <= 90 Then
    RiskBearingCapacity_Value = "<html><body><b><font color=""DarkOrange"" face=""calibri"" size=2>" & Format(RiskBearingCapacity / 100, "#0.00 %") & "<br></font></body></html>"
ElseIf RiskBearingCapacity > 90 Then
    RiskBearingCapacity_Value = "<html><body><b><font color=""Red"" face=""calibri"" size=2>" & Format(RiskBearingCapacity / 100, "#0.00 %") & "<br></font></body></html>"
End If

'BALANCE SHEET SUM
Dim BalanceSheetSum_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>NGS Balance Sheet Sum<br></font></body></html>"
Dim BalanceSheetSum_Value As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(BalanceTotal, "#,##0.00 €") & "<br></font></body></html>"

'KAPITALERHALTUNGSPUFFER
Dim StrBodyCapitalConservationBuffer_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Capital conservation buffer<br></font></body></html>"
Dim StrBodyCapitalConservationBuffer_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(Kapitalerhaltungspuffer, "#,##0.00 €") & "<br></font></body></html>"
'ANTIZYKLISCHER KAPITAL PUFFER
Dim StrBodyAntizyklischerKapitalBuffer_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Institution specific countercyclical capital buffer<br></font></body></html>"
Dim StrBodyAntizyklischerKapitalBuffer_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(AntizyklischerKapitalpuffer, "#,##0.00 €") & "<br></font></body></html>"

'LARGE LOANS EXPOSURE
'Large Loans Exposure without HGB340F
Dim StrBodyLargeLoansExposureNoHGB340F_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>Large Loans Exposure Limit<br><font color=""Blue"" size=1>(Info: 25% of Tier 1 Capital<br></font></body></html>"
Dim StrBodyLargeLoansExposureNoHGB340F_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=2>" & Format(LARGE_LOANS_EXPOSURE, "#,##0.00 €") & "<br></font></body></html>"
'Large Loans Exposure with HGB340F
Dim StrBodyLargeLoansExposureYesHGB340F_Text As String = "<html><body><b><font color=""Black"" face=""calibri"" size=1.5>Large Loans Exposure Limit (including HGB340F) for Corporates<br></font></body></html>"
Dim StrBodyLargeLoansExposureYesHGB340F_Memo As String = "<html><body><b><font color=""Blue"" face=""calibri"" size=1.5>Only in emergency cases after timely prior approval of Senior Management<br></font></body></html>"
Dim StrBodyLargeLoansExposureYesHGB340F_Amount As String = "<html><body><b><font color=""Black"" face=""calibri"" size=1.5>" & Format(LARGE_LOANS_EXPOSURE_HGB340F, "#,##0.00 €") & "<br></font></body></html>"


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

If AdditionalInfoText <> "" Then
EItem.HTMLBody = StrBody1 & StrBody2 _
& TabelleStart & ZelleStart & ProfitLossBody_Text & ZelleEnde & ZelleStartZahl & ProfitLossBody_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & BUBA_Interest_Text & ZelleEnde & ZelleStartZahl & BUBA_Interest_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStartBackgroundBlue & PL_AfterBUBA_Text & ZelleEnde & ZelleStartZahl & PL_AfterBUBA_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & AdditionalInfoPL_Text & ZelleEnde & ZelleStartZahl & AdditionalInfoPL_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & OCBS_IDW_INTERN_Difference_Text & ZelleEnde & ZelleStartZahl & OCBS_IDW_INTERN_Difference_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStartBackgroundBlue & PL_NewResult_Intern_IDW_Text & ZelleEnde & ZelleStartZahl & PL_NewResult_Intern_IDW_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & SecuritiesDepreciations_Text & ZelleEnde & ZelleStartZahl & SecuritiesDepreciations_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & ObligoLiabilitySurplusHGB_Text & ZelleEnde & ZelleStartZahl & ObligoLiabilitySurplusHGB_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CustomerDemandDeposits_Text & ZelleEnde & ZelleStartZahl & CustomerDemandDeposits_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & BalanceSheetSum_Text & ZelleEnde & ZelleStartZahl & BalanceSheetSum_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & Tier1Capital_Text & ZelleEnde & ZelleStartZahl & Tier1Capital_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & StrBodyOwnFunds_Text & ZelleEnde & ZelleStartZahl & StrBodyOwnFunds_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & MinimumCapitalRequirement_Text & ZelleEnde & ZelleStartZahl & MinimumCapitalRequirement_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CreditRiskCashPledge_Text & ZelleEnde & ZelleStartZahl & CreditRiskCashPledge_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & InterestRateRisk50bps_Text & ZelleEnde & ZelleStartZahl & InterestRateRisk50bps_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CurrencyRisk_Text & ZelleEnde & ZelleStartZahl & CurrencyRisk_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & OperationalRisk_Text & ZelleEnde & ZelleStartZahl & OperationalRisk_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & LiquidityRisk_Text & ZelleEnde & ZelleStartZahl & LiquidityRisk_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & CcbGuaranteesAmount_Text & ZelleEnde & ZelleStartZahl & CcbGuaranteesAmount_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CcbFxCreditEquivalentAmount_Text & ZelleEnde & ZelleStartZahl & CcbFxCreditEQuivalentAmount_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CcbFxCreditEquivalentGuarantees_Text & ZelleEnde & ZelleStartZahl & CcbFxCreditEquivalentGuarantees_Value & ZelleEnde & ZelleStartZahl & CcbFxCreditEquivalentGuarantees_AdditionalText & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & TotalCapitalRatio_Text & ZelleEnde & ZelleStartResult & TotalCapitalRatio_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CapitalRatio_T1_Text & ZelleEnde & ZelleStartResult & CapitalRatio_T1_Amount & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & StrBodyCapitalConservationBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyCapitalConservationBuffer_Amount & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & StrBodyAntizyklischerKapitalBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyAntizyklischerKapitalBuffer_Amount & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & StrBodyLargeLoansExposureNoHGB340F_Text & ZelleEnde & ZelleStartResult & StrBodyLargeLoansExposureNoHGB340F_Amount & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & LcrRatio_Text & ZelleEnde & ZelleStartResult & LcrRatio_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & NSFRRatio_Text & ZelleEnde & ZelleStartResult & NSFRRatio_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & LeverageRatio_Text & ZelleEnde & ZelleStartResult & LeverageRatio_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & InterestRateRiskFigure_Text & ZelleEnde & ZelleStartResult & InterestRateRiskFigure_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & InterestRateRiskMinus200bps_Text & ZelleEnde & ZelleStartResult & InterestRateRiskMinus200bps_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & InterestRateRiskPlus200bps_Text & ZelleEnde & ZelleStartResult & InterestRateRiskPlus200bps_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & RiskBearingCapacity_Text & ZelleEnde & ZelleStartResult & RiskBearingCapacity_Value & ZelleEnde & TabelleEnde
Else
EItem.HTMLBody = StrBody1 & StrBody2 _
& TabelleStart & ZelleStart & ProfitLossBody_Text & ZelleEnde & ZelleStartZahl & ProfitLossBody_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & BUBA_Interest_Text & ZelleEnde & ZelleStartZahl & BUBA_Interest_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & PL_AfterBUBA_Text & ZelleEnde & ZelleStartZahl & PL_AfterBUBA_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & OCBS_IDW_INTERN_Difference_Text & ZelleEnde & ZelleStartZahl & OCBS_IDW_INTERN_Difference_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & PL_NewResult_Intern_IDW_Text & ZelleEnde & ZelleStartZahl & PL_NewResult_Intern_IDW_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & SecuritiesDepreciations_Text & ZelleEnde & ZelleStartZahl & SecuritiesDepreciations_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & ObligoLiabilitySurplusHGB_Text & ZelleEnde & ZelleStartZahl & ObligoLiabilitySurplusHGB_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CustomerDemandDeposits_Text & ZelleEnde & ZelleStartZahl & CustomerDemandDeposits_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & BalanceSheetSum_Text & ZelleEnde & ZelleStartZahl & BalanceSheetSum_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & Tier1Capital_Text & ZelleEnde & ZelleStartZahl & Tier1Capital_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & StrBodyOwnFunds_Text & ZelleEnde & ZelleStartZahl & StrBodyOwnFunds_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & MinimumCapitalRequirement_Text & ZelleEnde & ZelleStartZahl & MinimumCapitalRequirement_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CreditRiskCashPledge_Text & ZelleEnde & ZelleStartZahl & CreditRiskCashPledge_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & InterestRateRisk50bps_Text & ZelleEnde & ZelleStartZahl & InterestRateRisk50bps_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CurrencyRisk_Text & ZelleEnde & ZelleStartZahl & CurrencyRisk_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & OperationalRisk_Text & ZelleEnde & ZelleStartZahl & OperationalRisk_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & LiquidityRisk_Text & ZelleEnde & ZelleStartZahl & LiquidityRisk_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & CcbGuaranteesAmount_Text & ZelleEnde & ZelleStartZahl & CcbGuaranteesAmount_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CcbFxCreditEquivalentAmount_Text & ZelleEnde & ZelleStartZahl & CcbFxCreditEQuivalentAmount_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CcbFxCreditEquivalentGuarantees_Text & ZelleEnde & ZelleStartZahl & CcbFxCreditEquivalentGuarantees_Value & ZelleEnde & ZelleStartZahl & CcbFxCreditEquivalentGuarantees_AdditionalText & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & TotalCapitalRatio_Text & ZelleEnde & ZelleStartResult & TotalCapitalRatio_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & CapitalRatio_T1_Text & ZelleEnde & ZelleStartResult & CapitalRatio_T1_Amount & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & StrBodyCapitalConservationBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyCapitalConservationBuffer_Amount & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & StrBodyAntizyklischerKapitalBuffer_Text & ZelleEnde & ZelleStartResult & StrBodyAntizyklischerKapitalBuffer_Amount & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & StrBodyLargeLoansExposureNoHGB340F_Text & ZelleEnde & ZelleStartResult & StrBodyLargeLoansExposureNoHGB340F_Amount & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & LcrRatio_Text & ZelleEnde & ZelleStartResult & LcrRatio_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & NSFRRatio_Text & ZelleEnde & ZelleStartResult & NSFRRatio_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & LeverageRatio_Text & ZelleEnde & ZelleStartResult & LeverageRatio_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & InterestRateRiskFigure_Text & ZelleEnde & ZelleStartResult & InterestRateRiskFigure_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & InterestRateRiskMinus200bps_Text & ZelleEnde & ZelleStartResult & InterestRateRiskMinus200bps_Value & ZelleEnde & TabelleEnde _
& TabelleStart & ZelleStart & InterestRateRiskPlus200bps_Text & ZelleEnde & ZelleStartResult & InterestRateRiskPlus200bps_Value & ZelleEnde & TabelleEnde _
& absatz _
& TabelleStart & ZelleStart & RiskBearingCapacity_Text & ZelleEnde & ZelleStartResult & RiskBearingCapacity_Value & ZelleEnde & TabelleEnde
End If


EItem.Display()

If System.IO.Directory.Exists(ReportExpFile) = True Then
   System.IO.Directory.Delete(ReportExpFile, True)
End If



cmd.Connection.close()

End Sub

Public Sub SetReportDb(ByVal ConnectionString As String,  ByVal reportDocument As ReportDocument)
        'Get SQL Server Details
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()

        builder.ConnectionString = ConnectionString


        Dim zServer As String = TryCast(builder("Data Source"), String)
        Dim zDatabase As String = TryCast(builder("Initial Catalog"), String)
        'Dim zUsername As String = TryCast(builder("User ID"), String)
        'Dim zPassword As String = TryCast(builder("Password"), String)

        Dim ciReportConnection As New ConnectionInfo

        ciReportConnection.ServerName = zServer
        ciReportConnection.DatabaseName = zDatabase
        ciReportConnection.IntegratedSecurity = True
        'ciReportConnection.UserID = zUsername
        'ciReportConnection.Password = zPassword

        'Assign data source details to tables

        For Each table As CrystalDecisions.CrystalReports.Engine.Table In reportDocument.Database.Tables
            table.LogOnInfo.ConnectionInfo = ciReportConnection
            table.ApplyLogOnInfo(table.LogOnInfo)
        Next

        For Each subrep As ReportDocument In reportDocument.Subreports
            For Each table As CrystalDecisions.CrystalReports.Engine.Table In subrep.Database.Tables
                table.LogOnInfo.ConnectionInfo = ciReportConnection
                table.ApplyLogOnInfo(table.LogOnInfo)
            Next
        Next

        reportDocument.VerifyDatabase()
        reportDocument.Refresh()
        End Sub

End Class





