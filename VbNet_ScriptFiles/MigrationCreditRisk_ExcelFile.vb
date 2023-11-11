Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Spreadsheet

Public Class CREDIT_MIGRATION_RISK_DETAILS_WORKSHEET
    Inherits System.Windows.Forms.Form

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

conn.ConnectionString = "Data Source=DESKTOP-SLJQ4B6;Initial Catalog=PS TOOL DX Live;Integrated Security=True;Connection Timeout=60"
cmd.Connection = conn
cmd.CommandTimeout = 60000

cmd.Connection.Open()

'Set Dates
Dim rdString as String="30.06.2023"
Dim rd As Date = CDate(rdString)
Dim rdsql as String="20230630"


Dim workbook As New DevExpress.Spreadsheet.Workbook()
workbook.LoadDocument("C:\PS TOOL DX\EXCEL FILES\CreditMigrationRisk.xlsx", DevExpress.Spreadsheet.DocumentFormat.Xlsx)
Dim worksheets As WorksheetCollection = workbook.Worksheets
Dim Ws_TOTALS As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Totals")
Dim Ws_GROUPS As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Groups")
Dim Ws_DETAILS As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Details")

'Clear all contents
Ws_DETAILS.Clear(Ws_DETAILS("A1:AZ20000"))
Ws_DETAILS.DefinedNames.Clear()

Ws_GROUPS.Clear(Ws_GROUPS("A1:AZ10000"))
Ws_GROUPS.DefinedNames.Clear()

Ws_TOTALS.Clear(Ws_TOTALS("A1:AZ10000"))
Ws_TOTALS.DefinedNames.Clear()

'WsMatrixCalc.Clear(WsMatrixCalc("A1:AZ10000"))
'WsMatrixCalc.Columns.UnGroup(0, 5000, True)
'WsMatrixCalc.Rows.UnGroup(0, 5000, True)
'WsMatrixCalc.DefinedNames.Clear()

workbook.Worksheets.ActiveWorksheet = workbook.Worksheets("Totals")

'Credit Migration Risk TOTALS - First Load
Ws_TOTALS.MergeCells(Ws_TOTALS.Range("A1:C1"))
Ws_TOTALS.Cells("A1").Value = "Credit Migration Risk calculation on Business Date:"
Ws_TOTALS.Cells("D1").Value = rdString
Ws_TOTALS.Cells("D1").Fill.BackgroundColor = Color.LightBlue
Dim cell As Cell = Ws_TOTALS.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right

'Credit Migration Risk Columns
Ws_TOTALS.MergeCells(Ws_TOTALS.Range("A3:C3"))
Ws_TOTALS.Cells("A3").Value = "Credit Migration Risk:"
Ws_TOTALS.Cells("A3").Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right
Ws_TOTALS.Cells("D3").Fill.BackgroundColor=Color.LightBlue
Ws_TOTALS.Range("A3:D3").Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)
Ws_TOTALS.Cells("A3").Fill.BackgroundColor=Color.Yellow
Ws_TOTALS.Range("A3:D3").Font.Size = 12
Ws_TOTALS.Range("A3:D3").Font.FontStyle = SpreadsheetFontStyle.Bold

'Parameters for the GA calculation
Ws_TOTALS.MergeCells(Ws_TOTALS.Range("B5:G5"))
Ws_TOTALS.Cells("B5").Value = "Parameters for the GA calculation"
Cell = Ws_TOTALS.Cells("B5")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
'Fill Parameters
QueryText = "SELECT TOP 1 [LevelOfConfidence] as 'Level of Confidence',[p_alpha_Value],[b_beta_value],[nu_Value] as '(γ) nü',[Delta] as '(δ) delta',[Gamma_inv] as 'GAMMA INVERSE' FROM [CreditMigrationRisk_Totals] where RiskDate='" & rdsql &"'" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
Ws_TOTALS.Import(dt, True, 5, 1)

Ws_TOTALS.Range("B6:G7").Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)
Ws_TOTALS.Range("B6:G6").Fill.BackgroundColor=Color.Yellow

'Calculation GAMMA_INV
Ws_TOTALS.Cells("G7").Formula="=GAMMAINV(B7;C7;1/D7)"
'Calculation delta
Ws_TOTALS.Cells("F7").Formula="=(G7-1)*(C7+(1-C7)/(G7))"
'Set Name to LevelOfConfidence
Ws_TOTALS.Cells("B7").Name="LevelOfConfidence"
'Set Name to GammaInv
Ws_TOTALS.Cells("G7").Name="GammaInverse"
'Set Name to nü Value
Ws_TOTALS.Cells("E7").Name="nu_Value"
'Set Name to Delta Value
Ws_TOTALS.Cells("F7").Name="Delta_Value"


dt.reset()

'Fill Parameters
QueryText = "SELECT [DowngradeStatus],[SumEL] as 'Expected Loss',[SumUL] as 'Unexpected Loss',[SummeFinalEADTotalSum],[K_Value],[SumGA_rel],[SumGA_Total] as 'Granularity Approach',[TotalRisk],[RiskAdjustment] as 'Risk Adjustment (BASIS)',[TotalRisk_Adjusted],[ImpactOnTotalRisk],[Propability],[ExpectedValue] FROM [CreditMigrationRisk_Totals] where RiskDate='" & rdsql &"' order by ID asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
Ws_TOTALS.Import(dt, True, 8, 0)

Dim Ws_TOTALS_LastRow As Integer = 0
If dt.Rows.Count > 0 Then
Ws_TOTALS_LastRow = dt.Rows.Count + 9
End If

Dim Ws_TOTALS_RangeBorders as CellRange=Ws_TOTALS.Range("A9:M"& Ws_TOTALS_LastRow)
Ws_TOTALS_RangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim Ws_TOTALS_Headers as CellRange=Ws_TOTALS.Range("A9:M9")
Ws_TOTALS_Headers.Fill.BackgroundColor=Color.LightBlue

Ws_TOTALS.Range("B10:D"& Ws_TOTALS_LastRow).NumberFormat="#,##0.00"
Ws_TOTALS.Range("E10:F"& Ws_TOTALS_LastRow).NumberFormat="0.0000000000"
Ws_TOTALS.Range("G10:K"& Ws_TOTALS_LastRow).NumberFormat="#,##0.00"
Ws_TOTALS.Range("L10:L"& Ws_TOTALS_LastRow).NumberFormat="0.00 %"
Ws_TOTALS.Range("M10:M"& Ws_TOTALS_LastRow).NumberFormat="#,##0.00"
Ws_TOTALS.Cells("D3").NumberFormat="#,##0.00"


'Credit risk Details -Excpected Loss
Ws_DETAILS.MergeCells(Ws_DETAILS.Range("A1:C1"))
Ws_DETAILS.Cells("A1").Value = "Credit Risk Details - Expected Loss calculation (for all Downgrade Notches) on Business Date:"
Ws_DETAILS.Cells("D1").Value = rdString
Cell = Ws_DETAILS.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right

Ws_DETAILS.Range("A1:AD1").Fill.BackgroundColor = Color.Yellow

QueryText = "SELECT A.DowngradeStatus, A.[ClientGroup],A.[ClientGroupName],A.[Obligor Rate] as 'Obligor Grade',A.[Client No],A.[Counterparty/Issuer/Collateral Name],A.[Contract Collateral ID],B.BusinessType,A.[Contract Type],A.[Product Type],A.[GL Master / Account Type],'Maturity Date'=Case when A.[Maturity Date] is NULL then '99991231' else A.[Maturity Date] end,A.[Remaining Year(s) to Maturity],A.[Org Ccy],A.[Credit Outstanding (Org Ccy)],A.[Credit Outstanding (EUR Equ)],A.[NetCreditOutstandingAmountEUR],A.[InternalInfo],A.[PD],A.[(1-ER)],A.[Credit Risk Amount(EUR Equ)],A.[NetCredit Risk Amount(EUR Equ)],A.[(1-ER_45)],A.[CreditRiskAmountEUREquER45],A.[NetCreditRiskAmountEUREquER45],A.[CoreDefinition],A.[MaturityWithoutCapFloor],A.[EaDweigthedMaturityWithoutCapFloor],A.[PDxFinalEaD],A.[LGDfinalEaDweighted] from CreditMigrationRisk_Details A INNER JOIN [CREDIT RISK] B on A.[Contract Collateral ID]=B.[Contract Collateral ID] and A.RiskDate=B.RiskDate and A.[Org Ccy]=B.[Org Ccy] and A.[Credit Outstanding (Org Ccy)]=B.[Credit Outstanding (Org Ccy)] where A.[RiskDate]='" & rdsql &"' order by A.ID asc, A.ClientGroup" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
Ws_DETAILS.Import(dt, True, 1, 0)

Dim Ws_DETAILS_LastRow As Integer = 0
If dt.Rows.Count > 0 Then
Ws_DETAILS_LastRow = dt.Rows.Count + 2
End If

Dim Ws_DETAILS_RangeBorders as CellRange=Ws_DETAILS.Range("A2:AD"& Ws_DETAILS_LastRow)
Ws_DETAILS_RangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim Ws_DETAILS_Headers as CellRange=Ws_DETAILS.Range("A2:AD2")
Ws_DETAILS_Headers.Fill.BackgroundColor=Color.LightBlue

Ws_DETAILS.Range("O3:Q"& Ws_DETAILS_LastRow).NumberFormat="#,##0.00"
Ws_DETAILS.Range("X3:Y"& Ws_DETAILS_LastRow).NumberFormat="#,##0.00"
Ws_DETAILS.Range("AB3:AD"& Ws_DETAILS_LastRow).NumberFormat="#,##0.00"
Ws_DETAILS.Range("D3:D"& Ws_DETAILS_LastRow).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

Dim Ws_DETAILS_X As CellRange = Ws_DETAILS.Range("X3:X" & Ws_DETAILS_LastRow)
Ws_DETAILS_X.Formula = "=Q3*S3*W3"
Dim Ws_DETAILS_Y As CellRange = Ws_DETAILS.Range("Y3:Y" & Ws_DETAILS_LastRow)
Ws_DETAILS_Y.Formula = "=Q3*S3*W3"
Dim Ws_DETAILS_AA As CellRange = Ws_DETAILS.Range("AA3:AA" & Ws_DETAILS_LastRow)
Ws_DETAILS_AA.Formula = "=ROUND((IF(OR(EXACT(L3;DATE(9999;12;31));ISBLANK(L3));DATEDIF($D$1;DATE(YEAR($D$1);MONTH($D$1)+6;DAY($D$1));""d"");DATEDIF($D$1;L3;""d"")))/365,25;2)"
Dim Ws_DETAILS_AB As CellRange = Ws_DETAILS.Range("AB3:AB" & Ws_DETAILS_LastRow)
Ws_DETAILS_AB.Formula = "=Q3*AA3"
Dim Ws_DETAILS_AC As CellRange = Ws_DETAILS.Range("AC3:AC" & Ws_DETAILS_LastRow)
Ws_DETAILS_AC.Formula = "=Q3*S3"
Dim Ws_DETAILS_AD As CellRange = Ws_DETAILS.Range("AD3:AD" & Ws_DETAILS_LastRow)
Ws_DETAILS_AD.Formula = "=Q3*W3"

Dim Ws_DETAILS_TotalRange as CellRange=Ws_DETAILS.Range("A1:AZ20000")
Ws_DETAILS_TotalRange.AutoFitColumns()

dt.reset()
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

'Credit Risk Totals - Unexpected Loss calculation
Ws_GROUPS.MergeCells(Ws_GROUPS.Range("A1:C1"))
Ws_GROUPS.Cells("A1").Value = "Credit Risk Details - Unexpected Loss calculation (for all Downgrade Notches) on Business Date:"
Ws_GROUPS.Cells("D1").Value = rdString
Cell = Ws_GROUPS.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right

Ws_GROUPS.Range("A1:T1").Fill.BackgroundColor = Color.Yellow

QueryText = "SELECT [DowngradeStatus] ,[ClientGroup], [ClientGroupName], [SubBorrowersCounter], [FinalEadTotalSum], [LGD],[PD_EaD_weighted], [PD_3bps_floor], [IndicatorOfFloor], [MaturityEADweigthed], [R_CoefficientOfColleration],[b_MaturityAdjustment],[RW_RiskWeightedExposure],[UL_UnexpectedLoss],[s_i],[K_i],[R_i],[VLGD_i],[C_i],[GA_n] FROM CreditMigrationRisk_Groups where RiskDate='" & rdsql &"' order by CASE when DowngradeStatus in ('BASIS') then 1 when DowngradeStatus not in ('BASIS') then dbo.fn_StripCharacters(DowngradeStatus, '^0-9') *1  end"
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
Ws_GROUPS.Import(dt, True, 1, 0)

Dim Ws_GROUPS_LastRow As Integer = 0
If dt.Rows.Count > 0 Then
Ws_GROUPS_LastRow = dt.Rows.Count + 2
End If

Dim Ws_GROUPS_RangeBorders as CellRange=Ws_GROUPS.Range("A2:T"& Ws_GROUPS_LastRow)
Ws_GROUPS_RangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim Ws_GROUPS_Headers as CellRange=Ws_GROUPS.Range("A2:T2")
Ws_GROUPS_Headers.Fill.BackgroundColor=Color.LightBlue

Ws_GROUPS.Range("E3:E"& Ws_GROUPS_LastRow).NumberFormat="#,##0.00"
Ws_GROUPS.Range("G3:H"& Ws_GROUPS_LastRow).NumberFormat="0.00000"
Ws_GROUPS.Range("N3:N"& Ws_GROUPS_LastRow).NumberFormat="#,##0.00"
Ws_GROUPS.Range("O3:P"& Ws_GROUPS_LastRow).NumberFormat="0.0000000000"
Ws_GROUPS.Range("T3:T"& Ws_GROUPS_LastRow).NumberFormat="0.000000000000"
Ws_GROUPS.Range("D3:D"& Ws_GROUPS_LastRow).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

Dim Ws_GROUPS_D As CellRange = Ws_GROUPS.Range("D3:D" & Ws_GROUPS_LastRow)
Ws_GROUPS_D.Formula = "=COUNTIFS(Details!$B$3:$B$" & Ws_DETAILS_LastRow &";B3;Details!$A$3:$A$"& Ws_DETAILS_LastRow &";A3)"

Dim Ws_GROUPS_E As CellRange = Ws_GROUPS.Range("E3:E" & Ws_GROUPS_LastRow)
Ws_GROUPS_E.Formula = "=SUMIFS(Details!$Q$3:$Q$" & Ws_DETAILS_LastRow &";Details!$B$3:$B$" & Ws_DETAILS_LastRow &";B3;Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A3)" 

Dim Ws_GROUPS_G As CellRange = Ws_GROUPS.Range("G3:G" & Ws_GROUPS_LastRow)
Ws_GROUPS_G.Formula = "=IF(ISERROR(SUMIFS(Details!$AC$3:$AC$" & Ws_DETAILS_LastRow &";Details!$B$3:$B$" & Ws_DETAILS_LastRow &";B3;Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A3))/E3;0;SUMIFS(Details!$AC$3:$AC$" & Ws_DETAILS_LastRow &";Details!$B$3:$B$" & Ws_DETAILS_LastRow &";B3;Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A3))/E3"

Dim Ws_GROUPS_H As CellRange = Ws_GROUPS.Range("H3:H" & Ws_GROUPS_LastRow)
Ws_GROUPS_H.Formula = "=MAX(G3;0,0003)*IF(EXACT(0;G3);0;1)"

Dim Ws_GROUPS_I As CellRange = Ws_GROUPS.Range("I3:I" & Ws_GROUPS_LastRow)
Ws_GROUPS_I.Formula = "=IF(H3-G3>0;1;0)" 

Dim Ws_GROUPS_J As CellRange = Ws_GROUPS.Range("J3:J" & Ws_GROUPS_LastRow)
Ws_GROUPS_J.Formula = "=IF(ISERROR(MAX(1;MIN(5;(SUMIFS(Details!$AB$3:$AB$" & Ws_DETAILS_LastRow &";Details!$B$3:$B$" & Ws_DETAILS_LastRow &";B3;Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A3))/E3)));""n.a."";MAX(1;MIN(5;(SUMIFS(Details!$AB$3:$AB$" & Ws_DETAILS_LastRow &";Details!$B$3:$B$" & Ws_DETAILS_LastRow &";B3;Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A3))/E3)))"

Dim Ws_GROUPS_K As CellRange = Ws_GROUPS.Range("K3:K" & Ws_GROUPS_LastRow)
Ws_GROUPS_K.Formula = "=0,12*((1-EXP(-50*H3))/(1-EXP(-50)))+0,24*(1-((1-EXP(-50*H3))/(1-EXP(-50))))" 

Dim Ws_GROUPS_L As CellRange = Ws_GROUPS.Range("L3:L" & Ws_GROUPS_LastRow)
Ws_GROUPS_L.Formula = "=IF(ISERROR((0,11852-0,05478*LN(H3))^2);""n.a."";(0,11852-0,05478*LN(H3))^2)" 

Dim Ws_GROUPS_M As CellRange = Ws_GROUPS.Range("M3:M" & Ws_GROUPS_LastRow)
Ws_GROUPS_M.Formula = "=IF(ISERROR((F3*NORMDIST(  (1/(1-K3))^0,5    *   NORMINV(H3;0;1)    +    (K3/(1-K3))^0,5  *  NORMINV(Totals!LevelOfConfidence;0;1);0;1;TRUE)   - F3*H3   )*( (1+(J3-2,5)*L3) / (1-1,5*L3)  )*12,5*1,06);""n.a."";(F3*NORMDIST(  (1/(1-K3))^0,5    *   NORMINV(H3;0;1)    +    (K3/(1-K3))^0,5  *  NORMINV(Totals!LevelOfConfidence;0;1);0;1;TRUE)   - F3*H3   )*( (1+(J3-2,5)*L3) / (1-1,5*L3)  )*12,5*1,06)" 

Dim Ws_GROUPS_N As CellRange = Ws_GROUPS.Range("N3:N" & Ws_GROUPS_LastRow)
Ws_GROUPS_N.Formula = "=IF(ISERROR(M3*E3*0,08);0;M3*E3*0,08)" 

Dim Ws_GROUPS_O As CellRange = Ws_GROUPS.Range("O3:O" & Ws_GROUPS_LastRow)
Ws_GROUPS_O.Formula = "=E3/SUMIF(Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A3;Details!$Q$3:$Q$" & Ws_DETAILS_LastRow &")" 

Dim Ws_GROUPS_P As CellRange = Ws_GROUPS.Range("P3:P" & Ws_GROUPS_LastRow)
Ws_GROUPS_P.Formula = "=IF(ISERROR(N3/E3);0;N3/E3)" 

Dim Ws_GROUPS_Q As CellRange = Ws_GROUPS.Range("Q3:Q" & Ws_GROUPS_LastRow)
Ws_GROUPS_Q.Formula = "=F3*H3" 

Dim Ws_GROUPS_R As CellRange = Ws_GROUPS.Range("R3:R" & Ws_GROUPS_LastRow)
Ws_GROUPS_R.Formula = "=Totals!nu_Value*F3*(1-F3)" 

Dim Ws_GROUPS_S As CellRange = Ws_GROUPS.Range("S3:S" & Ws_GROUPS_LastRow)
Ws_GROUPS_S.Formula = "=IF(ISERROR((F3^2+R3)/F3);0;(F3^2+R3)/F3)" 

Dim Ws_GROUPS_T As CellRange = Ws_GROUPS.Range("T3:T" & Ws_GROUPS_LastRow)
Ws_GROUPS_T.Formula = "=IF(ISERROR(O3^2*((Totals!Delta_Value*S3*(P3+Q3) +Totals!Delta_Value*(P3+Q3)^2*(R3^2)/(F3^2))-P3*(S3+2*(P3+Q3)*(R3^2)/(F3^2))));0;O3^2*((Totals!Delta_Value*S3*(P3+Q3)+Totals!Delta_Value*(P3+Q3)^2*(R3^2)/(F3^2))-P3*(S3+2*(P3+Q3)*(R3^2)/(F3^2))))" 

Dim Ws_GROUPS_TotalRange as CellRange=Ws_GROUPS.Range("A1:T20000")
Ws_GROUPS_TotalRange.AutoFitColumns()

'Final calculations in TOTALS Sheet
Dim Ws_TOTALS_B As CellRange = Ws_TOTALS.Range("B10:B" & Ws_TOTALS_LastRow)
Ws_TOTALS_B.Formula = "=SUMIF(Details!$A$3:$A$" & Ws_DETAILS_LastRow &";A10;Details!$Y$3:$Y$" & Ws_DETAILS_LastRow &")" 

Dim Ws_TOTALS_C As CellRange = Ws_TOTALS.Range("C10:C" & Ws_TOTALS_LastRow)
Ws_TOTALS_C.Formula = "=SUMIF(Groups!$A$3:$A$" & Ws_GROUPS_LastRow &";A10;Groups!$N$3:$N$" & Ws_GROUPS_LastRow &")" 

Dim Ws_TOTALS_D As CellRange = Ws_TOTALS.Range("D10:D" & Ws_TOTALS_LastRow)
Ws_TOTALS_D.Formula = "=SUMIF(Groups!$A$3:$A$" & Ws_GROUPS_LastRow &";A10;Groups!$E$3:$E$" & Ws_GROUPS_LastRow &")" 

Dim Ws_TOTALS_E As CellRange = Ws_TOTALS.Range("E10:E" & Ws_TOTALS_LastRow)
Ws_TOTALS_E.Formula = "=SUMPRODUCT((Groups!$A$3:$A$" & Ws_GROUPS_LastRow &"=A10)*Groups!$O$3:Groups!$O$" & Ws_GROUPS_LastRow &"*Groups!$P$3:Groups!$P$" & Ws_GROUPS_LastRow &")" 

Dim Ws_TOTALS_F As CellRange = Ws_TOTALS.Range("F10:F" & Ws_TOTALS_LastRow)
Ws_TOTALS_F.Formula = "=IF(ISERROR(SUMIF(Groups!$A$3:$A$" & Ws_GROUPS_LastRow &";A10;Groups!$T$3:$T$" & Ws_GROUPS_LastRow &")/(2*E10));0;SUMIF(Groups!$A$3:$A$" & Ws_GROUPS_LastRow &";A10;Groups!$T$3:$T$" & Ws_GROUPS_LastRow &")/(2*E10))" 

Dim Ws_TOTALS_G As CellRange = Ws_TOTALS.Range("G10:G" & Ws_TOTALS_LastRow)
Ws_TOTALS_G.Formula = "=IF(ISERROR(SUMIF(Groups!$A$3:$A$" & Ws_GROUPS_LastRow &";A10;Groups!$E$3:$E$" & Ws_GROUPS_LastRow &")*F10);0;SUMIF(Groups!$A$3:$A$" & Ws_GROUPS_LastRow &";A10;Groups!$E$3:$E$" & Ws_GROUPS_LastRow &")*F10)"

Dim Ws_TOTALS_H As CellRange = Ws_TOTALS.Range("H10:H" & Ws_TOTALS_LastRow)
Ws_TOTALS_H.Formula = "=B10+C10+G10"

Dim Ws_TOTALS_I As CellRange = Ws_TOTALS.Range("I10:I" & Ws_TOTALS_LastRow)
Ws_TOTALS_I.Formula = "=SUMIFS(Details!$Y$3:$Y$" & Ws_DETAILS_LastRow &";Details!$A$3:$A$" & Ws_DETAILS_LastRow &";""BASIS"";Details!$S$3:$S$" & Ws_DETAILS_LastRow &";1)*(-1)"

Dim Ws_TOTALS_J As CellRange = Ws_TOTALS.Range("J10:J" & Ws_TOTALS_LastRow)
Ws_TOTALS_J.Formula = "=H10+I10"

Dim Ws_TOTALS_K As CellRange = Ws_TOTALS.Range("K10:K" & Ws_TOTALS_LastRow)
Ws_TOTALS_K.Formula = "=J10-$J$10"

Dim Ws_TOTALS_M As CellRange = Ws_TOTALS.Range("M10:M" & Ws_TOTALS_LastRow)
Ws_TOTALS_M.Formula = "=L10*K10"

'Calculation CREDIT MIGRATION RISK
Ws_TOTALS.Cells("D3").Formula="=SUM(M10:M" & Ws_TOTALS_LastRow &")"

Dim Ws_TOTALS_TotalRange as CellRange=Ws_TOTALS.Range("A1:AZ20000")
Ws_TOTALS_TotalRange.AutoFitColumns()


workbook.SaveDocument("C:\PS TOOL DX\EXCEL FILES\CreditMigrationRisk.xlsx", DevExpress.Spreadsheet.DocumentFormat.OpenXml)

cmd.Connection.close()



End Sub

End Class