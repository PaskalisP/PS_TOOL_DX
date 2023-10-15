Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Spreadsheet

Public Class PORTFOLIO_CREDIT_SPREAD_RISK_DETAILS_WORKSHEET
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
cmd.Connection.Open()

'Set Dates
Dim rdString as String="30.06.2023"
Dim rd As Date = CDate(rdString)
Dim rdsql as String="20230630"


Dim workbook As New DevExpress.Spreadsheet.Workbook()
workbook.LoadDocument("C:\PS TOOL DX\EXCEL FILES\PortfolioCreditSpreadRisk.xlsx", DevExpress.Spreadsheet.DocumentFormat.Xlsx)
Dim worksheets As WorksheetCollection = workbook.Worksheets
Dim worksheet As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Parameter")
Dim WsCorl As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Correlations")
Dim WsCalc As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("Result")

' Delete the "MatrixCalculations" worksheet from the workbook. 
workbook.Worksheets.Remove(workbook.Worksheets("MatrixCalculations"))
workbook.Worksheets.Insert(1, "MatrixCalculations")
Dim WsMatrixCalc As DevExpress.Spreadsheet.Worksheet = workbook.Worksheets("MatrixCalculations")

worksheet.Clear(worksheet("A1:AZ10000"))
worksheet.DefinedNames.Clear()

WsCorl.Clear(WsCorl("A1:AZ10000"))
WsCorl.DefinedNames.Clear()

WsCalc.Clear(WsCalc("A1:AZ10000"))
WsCalc.DefinedNames.Clear()

WsMatrixCalc.Clear(WsMatrixCalc("A1:AZ10000"))
WsMatrixCalc.Columns.UnGroup(0, 5000, True)
WsMatrixCalc.Rows.UnGroup(0, 5000, True)
WsMatrixCalc.DefinedNames.Clear()

workbook.Worksheets.ActiveWorksheet = workbook.Worksheets("Result")


'RISK WEIGHT PARAMETERS
worksheet.MergeCells(worksheet.Range("A1:G1"))
Worksheet.Cells("A1").Value = "Risk Weight - Rating Class - Sector"
Dim cell As Cell = worksheet.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center


QueryText = "SELECT [ParameterNr] as 'Nr.',[ParameterNameGeneral] as 'General Parameter Name',[ParameterName1] as 'Rating Class',[ParameterName2] as 'Sector',[ParameterValue1] as 'Segment',[ParameterValue2] as 'Risk Weight',[ParameterStatus] FROM [Parameter_CreditSpreadRisk_References] where [ParameterStatus] in ('Y') and ParameterNameGeneral in ('Risk_Weight_by_Issuer_Rating_Class_and_Sector') Order by ParameterNr asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
worksheet.Import(dt, True, 1, 0)

Dim RiskWeight_DETAILS_LastRow As Integer = 0
If dt.Rows.Count > 0 Then
RiskWeight_DETAILS_LastRow = dt.Rows.Count + 2
End If


Dim RiskWeightRange as CellRange=worksheet.Range("A3:G"& RiskWeight_DETAILS_LastRow)
RiskWeightRange.Name="RiskWeight_Parameters"

Dim RiskWeightRangeBorders as CellRange=worksheet.Range("A1:G"& RiskWeight_DETAILS_LastRow)
RiskWeightRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim RiskWeightHeaders as CellRange=worksheet.Range("A2:G2")
RiskWeightHeaders.Fill.BackgroundColor=Color.LightBlue

Dim RiskWeightValues as CellRange=worksheet.Range("F3:F"& RiskWeight_DETAILS_LastRow)
RiskWeightValues.NumberFormat="#,##"

dt.reset()
RiskWeight_DETAILS_LastRow=0
'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

'TENOR PARAMETERS
worksheet.MergeCells(worksheet.Range("I1:O1"))
Worksheet.Cells("I1").Value = "Tenor"
Cell = worksheet.Cells("I1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center


QueryText = "SELECT [ParameterNr] as 'Nr.',[ParameterNameGeneral] as 'General Parameter Name',[ParameterName1] as 'Tenor Period',[ParameterName2] as 'Tenor Period Description',[ParameterValue1] as 'Min',[ParameterValue2] as 'Max',[ParameterStatus] FROM [Parameter_CreditSpreadRisk_References] where [ParameterStatus] in ('Y') and ParameterNameGeneral in ('Tenor') Order by ParameterNr asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
worksheet.Import(dt, True, 1, 8)

Dim DETAILS_LastRow As Integer = 0
If dt.Rows.Count > 0 Then
DETAILS_LastRow = dt.Rows.Count + 2
End If


Dim TenorRange as CellRange=worksheet.Range("I3:O" & DETAILS_LastRow)
TenorRange.Name="Tenor_Parameters"

Dim TenorRangeBorders as CellRange=worksheet.Range("I1:O"& DETAILS_LastRow)
TenorRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim TenorHeaders as CellRange=worksheet.Range("I2:O2")
TenorHeaders.Fill.BackgroundColor=Color.LightBlue

Dim TenorValues as CellRange=worksheet.Range("M3:N"& DETAILS_LastRow)
TenorValues.NumberFormat="0.00"


dt.reset()
Dim TenorDetails_LastRow as integer=DETAILS_LastRow
DETAILS_LastRow=0
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

'CORRELATIONS BETWEEN 2 RISK POSITIONS
worksheet.MergeCells(worksheet.Range("I" & TenorDetails_LastRow+2 &":O" & TenorDetails_LastRow+2))
Worksheet.Cells("I" & TenorDetails_LastRow+2).Value = "Correlation between two risk positions"
Cell = worksheet.Cells("I" & TenorDetails_LastRow+2)
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

QueryText = "SELECT [ParameterNr] as 'Nr.',[ParameterNameGeneral] as 'General Parameter Name',[ParameterName1] as 'Correlation Type',[ParameterName2] as 'Correlation Type Description',[ParameterValue1] as 'Same',[ParameterValue2] as 'Not Same',[ParameterStatus] FROM [Parameter_CreditSpreadRisk_References] where [ParameterStatus] in ('Y') and ParameterNameGeneral in ('Correlation_between_two_risk_positions') Order by ParameterNr asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
worksheet.Import(dt, True, TenorDetails_LastRow+2, 8)

If dt.Rows.Count > 0 Then
DETAILS_LastRow = TenorDetails_LastRow+3 +  dt.Rows.Count
End If

Dim CorrelationRiskPositionsRange as CellRange=worksheet.Range("I" & TenorDetails_LastRow + 4 &":O" & DETAILS_LastRow)
CorrelationRiskPositionsRange.Name="CorrelationRiskPositions_Parameters"

Dim CorrelationRiskPositionsBorders as CellRange=worksheet.Range("I" & TenorDetails_LastRow + 2 &":O" & DETAILS_LastRow)
CorrelationRiskPositionsBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim CorrelationRiskPositionsHeaders as CellRange=worksheet.Range("I10:O10")
CorrelationRiskPositionsHeaders.Fill.BackgroundColor=Color.LightBlue

Dim CorrelationRiskPositionsValues as CellRange=worksheet.Range("M11:N"& DETAILS_LastRow)
CorrelationRiskPositionsValues.NumberFormat="0.00 %"


dt.reset()
Dim CorrelationRiskPositions_LastRow as integer=DETAILS_LastRow
DETAILS_LastRow=0

'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'CURVE TYPES
worksheet.MergeCells(worksheet.Range("I" & CorrelationRiskPositions_LastRow+2 &":M" & CorrelationRiskPositions_LastRow+2))
Worksheet.Cells("I" & CorrelationRiskPositions_LastRow+2).Value = "Curve Types"
Cell = worksheet.Cells("I" & CorrelationRiskPositions_LastRow+2)
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

QueryText = "SELECT [ParameterNr] as 'Nr.',[ParameterNameGeneral] as 'General Parameter Name',[ParameterName1] as 'Curve Type',[ParameterName2] as 'Curve Type Description',[ParameterStatus] FROM [Parameter_CreditSpreadRisk_References] where [ParameterStatus] in ('Y') and ParameterNameGeneral in ('Curve_Type') Order by ParameterNr asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
worksheet.Import(dt, True, CorrelationRiskPositions_LastRow+2, 8)

If dt.Rows.Count > 0 Then
DETAILS_LastRow = CorrelationRiskPositions_LastRow+3 +  dt.Rows.Count
End If

Dim CurveTypeRange as CellRange=worksheet.Range("I" & CorrelationRiskPositions_LastRow + 4 &":M" & DETAILS_LastRow)
CurveTypeRange.Name="CurveType_Parameters"

Dim CurveTypeRangeBorders as CellRange=worksheet.Range("I" & CorrelationRiskPositions_LastRow + 2 &":M" & DETAILS_LastRow)
CurveTypeRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim CurveTypeHeaders as CellRange=worksheet.Range("I16:M16")
CurveTypeHeaders.Fill.BackgroundColor=Color.LightBlue


dt.reset()
Dim CurveType_LastRow as integer=DETAILS_LastRow
DETAILS_LastRow=0
'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'SCALING PARAMETERS
worksheet.MergeCells(worksheet.Range("I" & CurveType_LastRow+2 &":M" & CurveType_LastRow+2))
Worksheet.Cells("I" & CurveType_LastRow+2).Value = "Scaling Parameter Levels"
Cell = worksheet.Cells("I" & CurveType_LastRow+2)
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

QueryText = "SELECT [ParameterNr] as 'Nr.',[ParameterNameGeneral] as 'General Parameter Name',[ParameterName1] as 'Scaling Level',[ParameterValue1] as 'Level Value',[ParameterStatus] FROM [Parameter_CreditSpreadRisk_References] where [ParameterStatus] in ('Y') and ParameterNameGeneral in ('Scaling_Parameter_Levels') Order by ParameterNr asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
worksheet.Import(dt, True, CurveType_LastRow+2, 8)

If dt.Rows.Count > 0 Then
DETAILS_LastRow = CurveType_LastRow+3 +  dt.Rows.Count
End If

Dim ScalingParameterRange as CellRange=worksheet.Range("I" & CurveType_LastRow + 4 &":M" & DETAILS_LastRow)
ScalingParameterRange.Name="Scaling_Level_Parameters"

Dim ScalingParameterRangeBorders as CellRange=worksheet.Range("I" & CurveType_LastRow + 2 &":M" & DETAILS_LastRow)
ScalingParameterRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim ScalingHeaders as CellRange=worksheet.Range("I22:M22")
ScalingHeaders.Fill.BackgroundColor=Color.LightBlue


dt.reset()
DETAILS_LastRow=0

'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
worksheet.MergeCells(worksheet.Range("Q1:AG1"))
Worksheet.Cells("Q1").Value = "Segments Correlations"
Cell = worksheet.Cells("Q1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

QueryText = "SELECT [SeqNr] as 'Sequence Correlations',[SeqNr1] as '1',[SeqNr2] as '2',[SeqNr3] as '3',[SeqNr4] as '4',[SeqNr5] as '5',[SeqNr6] as '6',[SeqNr7] as '7',[SeqNr8] as '8',[SeqNr9] as '9',[SeqNr10] as '10',[SeqNr11] as '11',[SeqNr12] as '12',[SeqNr13] as '13',[SeqNr14] as '14',[SeqNr15] as '15',[SeqNr16] as '16' FROM [Parameter_CreditSpreadRisk_Correlations] ORDER BY SeqNr asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
worksheet.Import(dt, True, 1, 16)

worksheet.Cells("R2").SetValueFromText("1", True)
worksheet.Cells("S2").SetValueFromText("2", True)
worksheet.Cells("T2").SetValueFromText("3", True)
worksheet.Cells("U2").SetValueFromText("4", True)
worksheet.Cells("V2").SetValueFromText("5", True)
worksheet.Cells("W2").SetValueFromText("6", True)
worksheet.Cells("X2").SetValueFromText("7", True)
worksheet.Cells("Y2").SetValueFromText("8", True)
worksheet.Cells("Z2").SetValueFromText("9", True)
worksheet.Cells("AA2").SetValueFromText("10", True)
worksheet.Cells("AB2").SetValueFromText("11", True)
worksheet.Cells("AC2").SetValueFromText("12", True)
worksheet.Cells("AD2").SetValueFromText("13", True)
worksheet.Cells("AE2").SetValueFromText("14", True)
worksheet.Cells("AF2").SetValueFromText("15", True)
worksheet.Cells("AG2").SetValueFromText("16", True)


If dt.Rows.Count > 0 Then
DETAILS_LastRow = dt.Rows.Count + 2
End If


Dim SegmentsCorrelationsRange as CellRange=worksheet.Range("Q2:AG"& DETAILS_LastRow)
SegmentsCorrelationsRange.Name="SegmentsCorrelations_Parameters"

Dim SegmentCorrelationBorders as CellRange=worksheet.Range("Q1:AG"& DETAILS_LastRow)
SegmentCorrelationBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim SegmentCorrelationHeaders as CellRange=worksheet.Range("Q2:AG2")
SegmentCorrelationHeaders.Fill.BackgroundColor=Color.LightBlue

Dim SegmentCorrelationRows as CellRange=worksheet.Range("Q2:Q"& DETAILS_LastRow)
SegmentCorrelationRows.Fill.BackgroundColor=Color.LightBlue

Dim SegmentCorrelationValues as CellRange=worksheet.Range("R3:AG"& DETAILS_LastRow)
SegmentCorrelationValues.NumberFormat="0.00 %"


dt.reset()
DETAILS_LastRow=0

Dim worksheet_TotalRange as CellRange=worksheet.Range("A1:AZ20000")
worksheet_TotalRange.AutoFitColumns()


'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'CORRELATIONS DATA
WsCorl.MergeCells(WsCorl.Range("A1:N1"))
WsCorl.Cells("A1").Value = "Correlation Data for " & rd
Cell = WsCorl.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 14 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
Dim cellA1_Corl_Borders As DevExpress.Spreadsheet.Borders = cell.Borders
cellA1_Corl_Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

QueryText = "SELECT [EMMITENT_A] ,[EMMITENT_B],[ISIN_A],[ISIN_B],[TENOR_A],[TENOR_B],[CURVE_A],[CURVE_B],[SEGMENT_A],[SEGMENT_B],[Correlation_Name] as K_Name,[Correlation_Tenor] as K_Tenor,[Correlation_Basis] as K_Basis,[CorrelationValue] FROM [CreditSpreadRisk_SingleAssetsCorrelation] where RiskDate='" & rdsql &"' order by ID asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
WsCorl.Import(dt, True, 1, 0)

Dim CorrelationsData_DETAILS_LastRow as integer=0
If dt.Rows.Count > 0 Then
CorrelationsData_DETAILS_LastRow = dt.Rows.Count + 2
End If

Dim CorrelationsDataRange as CellRange=WsCorl.Range("A3:N"& CorrelationsData_DETAILS_LastRow)
CorrelationsDataRange.Name="CorrelationData"

Dim CorrelationsDataBorders as CellRange=WsCorl.Range("A1:N"& CorrelationsData_DETAILS_LastRow)
CorrelationsDataBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim CorrelationsDataHeaders as CellRange=WsCorl.Range("A2:N2")
CorrelationsDataHeaders.Fill.BackgroundColor=Color.LightBlue

Dim CorrelationsDataValues as CellRange=WsCorl.Range("K3:N"& CorrelationsData_DETAILS_LastRow)
CorrelationsDataValues.NumberFormat="0.00 %"


dt.reset()

Dim WsCorl_TotalRange as CellRange=WsCorl.Range("A1:AZ20000")
WsCorl_TotalRange.AutoFitColumns()


'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'MATRIX CALCULATIONS
'Single Asset x Correlation Value
WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A1:H1"))
WsMatrixCalc.Cells("A1").Value = "Single Asset x Correlation Value for " & rd
Cell = WsMatrixCalc.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 14 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
Dim WsMatrixCalc_cellA1Borders As DevExpress.Spreadsheet.Borders = cell.Borders
WsMatrixCalc_cellA1Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

QueryText = "SELECT [RowNr],[ColNr],[FieldName2] as ISINS,[FieldValue1] as SingleAssetRisk,[FieldName5] as ISIN_A,[FieldName7] as ISIN_B,[FieldValue2] as CorrelationValue,[ResultFieldValue] as MidVec FROM [CreditSpreadRisk_MatrixCorrelationCalculations] where [CalculationDescription] in ('Calculation_Single_Asset_MidVec') and [RiskDate]='" & rdsql & "' order by ID asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
WsMatrixCalc.Import(dt, True, 1, 0)

Dim SingleAsset_CorrelationValue_DETAILS_LastRow as integer=0
If dt.Rows.Count > 0 Then
SingleAsset_CorrelationValue_DETAILS_LastRow = dt.Rows.Count + 2
End If

Dim SingleAsset_CorrelationValueRange as CellRange=WsMatrixCalc.Range("A2:H"& SingleAsset_CorrelationValue_DETAILS_LastRow)
SingleAsset_CorrelationValueRange.Name="SingleAsset_CorrelationValue"

Dim SingleAsset_CorrelationValueBorders as CellRange=WsMatrixCalc.Range("A1:H"& SingleAsset_CorrelationValue_DETAILS_LastRow)
SingleAsset_CorrelationValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim SingleAsset_CorrelationValueHeaders as CellRange=WsMatrixCalc.Range("A2:H2")
SingleAsset_CorrelationValueHeaders.Fill.BackgroundColor=Color.LightBlue

Dim WsMatrixCalc_SingleAssetDataValues as CellRange=WsMatrixCalc.Range("D3:D"& SingleAsset_CorrelationValue_DETAILS_LastRow)
WsMatrixCalc_SingleAssetDataValues.NumberFormat="#,##"

Dim WsMatrixCalc_CorrelationsDataValues as CellRange=WsMatrixCalc.Range("G3:G"& SingleAsset_CorrelationValue_DETAILS_LastRow)
WsMatrixCalc_CorrelationsDataValues.NumberFormat="0.00 %"

Dim WsMatrixCalc_MidVecValues as CellRange=WsMatrixCalc.Range("H3:H"& SingleAsset_CorrelationValue_DETAILS_LastRow)
WsMatrixCalc_MidVecValues.NumberFormat="#,##"

Dim subtotalColumnsList As New List(Of Integer)()
subtotalColumnsList.Add(7)
WsMatrixCalc.Subtotal(SingleAsset_CorrelationValueRange, 4, subtotalColumnsList, 9, "Total")

Dim WsMatrixCalc_DataRange As CellRange = WsMatrixCalc.GetUsedRange()
Dim WsMatrixCalc_LastRowIndex As Integer = WsMatrixCalc_DataRange.BottomRowIndex

dt.reset()

'Single Segment x MidVec
WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +3 &":G" & WsMatrixCalc_LastRowIndex+3))
WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex +3).Value = "Single Segment x MidVec for " & rd
Cell = WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex +3)
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 14 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
Dim WsMatrixCalc_cellA2Borders As DevExpress.Spreadsheet.Borders = cell.Borders
WsMatrixCalc_cellA2Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

QueryText = "SELECT [RowNr],[ColNr],[FieldName2] as ISIN,[FieldValue1] as SEGMENT,[FieldValue2] as SingleAssetRisk,[FieldValue4] as SumMidVec,[ResultFieldValue] as SingleSegmentMidVec FROM [CreditSpreadRisk_MatrixCorrelationCalculations] where CalculationDescription in ('Calculation_Single_Segment_MidVec') and [RiskDate]='" & rdsql & "' order by ID asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
WsMatrixCalc.Import(dt, True, WsMatrixCalc_LastRowIndex +3, 0)

Dim SingleSegment_MidVecValue_DETAILS_LastRow as integer=0
If dt.Rows.Count > 0 Then
SingleSegment_MidVecValue_DETAILS_LastRow = WsMatrixCalc_LastRowIndex +3 + dt.Rows.Count + 2
End If


Dim SingleSegment_MidVecValueRange as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":G" & SingleSegment_MidVecValue_DETAILS_LastRow-1)
SingleSegment_MidVecValueRange.Name="SingleSegment_MidVec"

Dim SingleSegment_MidVecValueBorders as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":G" & SingleSegment_MidVecValue_DETAILS_LastRow-1)
SingleSegment_MidVecValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim SingleSegment_MidVecValueHeaders as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":G" & WsMatrixCalc_LastRowIndex +4)
SingleSegment_MidVecValueHeaders.Fill.BackgroundColor=Color.LightBlue

Dim WsMatrixCalc_SingleSegment_MidVecDataValues as CellRange=WsMatrixCalc.Range("E" & WsMatrixCalc_LastRowIndex +4 &":G" & SingleSegment_MidVecValue_DETAILS_LastRow-1)
WsMatrixCalc_SingleSegment_MidVecDataValues.NumberFormat="#,##"

Dim subtotalColumnsList1 As New List(Of Integer)()
subtotalColumnsList1.Add(6) 'Subtotals claculated for column:G
WsMatrixCalc.Subtotal(SingleSegment_MidVecValueBorders, 3, subtotalColumnsList1, 9, "Total")

WsMatrixCalc_DataRange= WsMatrixCalc.GetUsedRange()
WsMatrixCalc_LastRowIndex= WsMatrixCalc_DataRange.BottomRowIndex

dt.reset()

'Segment Risk x MidVec
WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +3 &":G" & WsMatrixCalc_LastRowIndex+3))
WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex +3).Value = "Segment Risk x MidVec for " & rd
Cell = WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex +3)
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 14 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
Dim WsMatrixCalc_cellA3Borders As DevExpress.Spreadsheet.Borders = cell.Borders
WsMatrixCalc_cellA3Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

QueryText = "SELECT [RowNr],[ColNr],[FieldValue1] as SEGMENT_A,[FieldValue2] as SEGMENT_B,[FieldValue3] as Segment_Risk,[FieldValue6] as Segment_Correlation,[ResultFieldValue] as Segment_Risk_MidVec FROM [CreditSpreadRisk_MatrixCorrelationCalculations] where CalculationDescription in ('Calculation_Segment_Risk_MidVec') and [RiskDate]='" & rdsql & "' order by ID asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
WsMatrixCalc.Import(dt, True, WsMatrixCalc_LastRowIndex +3, 0)

Dim SegmentRisk_MidVecValue_DETAILS_LastRow as integer=0
If dt.Rows.Count > 0 Then
SegmentRisk_MidVecValue_DETAILS_LastRow = WsMatrixCalc_LastRowIndex +3 + dt.Rows.Count + 2
End If

Dim SegmentRisk_MidVecValueRange as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":G" & SegmentRisk_MidVecValue_DETAILS_LastRow-1)
SegmentRisk_MidVecValueRange.Name="SegmentRisk_MidVec"

Dim SegmentRisk_MidVecValueBorders as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":G" & SegmentRisk_MidVecValue_DETAILS_LastRow-1)
SegmentRisk_MidVecValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim SegmentRisk_MidVecValueHeaders as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":G" & WsMatrixCalc_LastRowIndex +4)
SegmentRisk_MidVecValueHeaders.Fill.BackgroundColor=Color.LightBlue

Dim WsMatrixCalc_SegmentRisk_MidVecDataValues as CellRange=WsMatrixCalc.Range("E" & WsMatrixCalc_LastRowIndex +4 &":G" & SegmentRisk_MidVecValue_DETAILS_LastRow-1)
WsMatrixCalc_SegmentRisk_MidVecDataValues.NumberFormat="#,##"

Dim WsMatrixCalc_SegmentRisk_SegmentDataValues as CellRange=WsMatrixCalc.Range("F" & WsMatrixCalc_LastRowIndex +4 &":F" & SegmentRisk_MidVecValue_DETAILS_LastRow-1)
WsMatrixCalc_SegmentRisk_SegmentDataValues.NumberFormat="0.00 %"

Dim subtotalColumnsList2 As New List(Of Integer)()
subtotalColumnsList2.Add(6) 'Subtotals claculated for column:G
WsMatrixCalc.Subtotal(SegmentRisk_MidVecValueBorders, 2, subtotalColumnsList1, 9, "Total")

WsMatrixCalc_DataRange= WsMatrixCalc.GetUsedRange()
WsMatrixCalc_LastRowIndex= WsMatrixCalc_DataRange.BottomRowIndex

dt.reset()

'Final Calculation
WsMatrixCalc.MergeCells(WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +3 &":D" & WsMatrixCalc_LastRowIndex+3))
WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex +3).Value = "Final calculation for " & rd
Cell = WsMatrixCalc.Cells("A" & WsMatrixCalc_LastRowIndex +3)
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 14 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
Dim WsMatrixCalc_cellA4Borders As DevExpress.Spreadsheet.Borders = cell.Borders
WsMatrixCalc_cellA4Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

QueryText = "SELECT [Segment],[SegmentRisk],[SegmentRisk_MidVec],Produkt=0 FROM [CreditSpreadRisk_Segments] where RiskDate='" & rdsql &"' order by Segment asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
WsMatrixCalc.Import(dt, True, WsMatrixCalc_LastRowIndex +3, 0)

Dim FinalCalculation_DETAILS_LastRow as integer=0
If dt.Rows.Count > 0 Then
FinalCalculation_DETAILS_LastRow = WsMatrixCalc_LastRowIndex +3 + dt.Rows.Count + 2
End If

Dim FinalCalculationValueRange as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":D" & FinalCalculation_DETAILS_LastRow-1)
FinalCalculationValueRange.Name="FinalCalculation"

Dim FinalCalculationValueBorders as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":D" & FinalCalculation_DETAILS_LastRow-1)
FinalCalculationValueBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim FinalCalculationValueHeaders as CellRange=WsMatrixCalc.Range("A" & WsMatrixCalc_LastRowIndex +4 &":D" & WsMatrixCalc_LastRowIndex +4)
FinalCalculationValueHeaders.Fill.BackgroundColor=Color.LightBlue

Dim WsMatrixCalc_FinalCalculation_MidVecDataValues as CellRange=WsMatrixCalc.Range("B" & WsMatrixCalc_LastRowIndex +4 &":D" & FinalCalculation_DETAILS_LastRow-1)
WsMatrixCalc_FinalCalculation_MidVecDataValues.NumberFormat="#,##"

Dim WsMatrixCalc_TotalRange as CellRange=WsMatrixCalc.Range("A1:AZ20000")
WsMatrixCalc_TotalRange.AutoFitColumns()

'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

'Product Calculation
Dim FinalProduct_Range as CellRange=WsMatrixCalc.Range("D" & WsMatrixCalc_LastRowIndex +5 &":D" & FinalCalculation_DETAILS_LastRow-1)
FinalProduct_Range.Formula = "=B" & WsMatrixCalc_LastRowIndex +5 &"*C" & WsMatrixCalc_LastRowIndex +5 &""
FinalProduct_Range.NumberFormat="#,##"

'Product Sum Calculation
WsMatrixCalc.Cells("D" & FinalCalculation_DETAILS_LastRow &"").Formula = "=SUM(D" & WsMatrixCalc_LastRowIndex +5 &":D" & FinalCalculation_DETAILS_LastRow-1 & ")"
Cell = WsMatrixCalc.Cells("D" & FinalCalculation_DETAILS_LastRow &"")
cell.Font.Size = 11 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
cell.NumberFormat="#,##"
cell.Name="SEGMENT_RISK_TOTAL"

'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'RESULT
WsCalc.MergeCells(WsCalc.Range("A1:Q1"))
WsCalc.Cells("A1").Value = "Portfolio Credit Spread Risk Calculation for " & rd
Cell = WsCalc.Cells("A1")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 14 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
Dim cellA1Borders As DevExpress.Spreadsheet.Borders = cell.Borders
cellA1Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)


WsCalc.MergeCells(WsCalc.Range("A2:C2"))
WsCalc.Cells("A2").Value = "Securities Market Value (Sum)"
Cell = WsCalc.Cells("A2")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 12 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
WsCalc.MergeCells(WsCalc.Range("A3:C3"))


WsCalc.MergeCells(WsCalc.Range("D2:G2"))
WsCalc.Cells("D2").Value = "Segment Risk x MidVec (Total)"
Cell = WsCalc.Cells("D2")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 12 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
WsCalc.MergeCells(WsCalc.Range("D3:G3"))
WsCalc.Cells("D3").Formula="=MatrixCalculations!SEGMENT_RISK_TOTAL"
WsCalc.Cells("D3").NumberFormat="#,##"


Dim RangeA2_D3 as CellRange=WsCalc.Range("A2:G3")
RangeA2_D3.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)


WsCalc.MergeCells(WsCalc.Range("H2:L2"))
WsCalc.Cells("H2").Value = "Credit Spread Risk (Level1)"
Cell = WsCalc.Cells("H2")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 12 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold

WsCalc.MergeCells(WsCalc.Range("H3:L3"))
WsCalc.Cells("H3").Formula="=SQRT(D3)"
WsCalc.Cells("H3").NumberFormat="#,##"

WsCalc.MergeCells(WsCalc.Range("H4:L4"))
WsCalc.Cells("H4").Value = "relative to portfolio market value"
Cell = WsCalc.Cells("H4")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 12 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold
WsCalc.MergeCells(WsCalc.Range("H5:L5"))
WsCalc.Cells("H5").Formula="=H3/A3"
WsCalc.Cells("H5").NumberFormat="0.00 %"


WsCalc.MergeCells(WsCalc.Range("M2:Q2"))
WsCalc.Cells("M2").Value = "Credit Spread Risk (Level2)"
Cell = WsCalc.Cells("M2")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 12 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold

WsCalc.MergeCells(WsCalc.Range("M3:Q3"))
WsCalc.Cells("M3").Formula = "=H3*INDEX(Parameter!Scaling_Level_Parameters;2;4)/INDEX(Parameter!Scaling_Level_Parameters;1;4)"
WsCalc.Cells("M3").NumberFormat="#,##"

WsCalc.MergeCells(WsCalc.Range("M4:Q4"))
WsCalc.Cells("M4").Value = "relative to portfolio market value"
Cell = WsCalc.Cells("M4")
cell.Fill.BackgroundColor = Color.LightBlue
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 12 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold

WsCalc.MergeCells(WsCalc.Range("M5:Q5"))
WsCalc.Cells("M5").Formula="=M3/A3"
WsCalc.Cells("M5").NumberFormat="0.00 %"


Dim RangeH2_Q5 as CellRange=WsCalc.Range("H2:Q5")
RangeH2_Q5.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

'Load Bond Portfolio
WsCalc.MergeCells(WsCalc.Range("A7:M7"))
WsCalc.Cells("A7").Value = "Bond Portfolio on " & rd
Cell = WsCalc.Cells("A7")
cell.Fill.BackgroundColor = Color.Yellow
cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center
cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
cell.Font.Size = 11 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold


QueryText = "SELECT [ISIN],[EmmitentNr],[SecurityName],[Nominal],[MarketValueEUR],[ModifiedDuration],[CS01]=0,[Segment],[SpreadMovement],[Curve_Type],[SingleAssetRisk]=0,[K_Tenor],[MidVec] FROM [CreditSpreadRisk_BondPortfolio] where RiskDate='" & rdsql &"' order by ID asc" 
da = New SqlDataAdapter(QueryText.Trim(), conn)
dt = New System.Data.DataTable()
da.Fill(dt)
WsCalc.Import(dt, True, 7, 0)

Dim BondPortfolio_LastRow As Integer = 0

If dt.Rows.Count > 0 Then
BondPortfolio_LastRow = dt.Rows.Count + 2
End If


Dim BondPortfolioRangeBorders as CellRange=WsCalc.Range("A7:M"& BondPortfolio_LastRow+6)
BondPortfolioRangeBorders.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin)

Dim BondPortfolioHeaders as CellRange=WsCalc.Range("A8:M8")
BondPortfolioHeaders.Fill.BackgroundColor=Color.LightBlue

'Market Value
WsCalc.Cells("E" & BondPortfolio_LastRow+7 &"").Formula = "=SUM(E9:E" & BondPortfolio_LastRow+6 & ")"
Cell = WsCalc.Cells("E" & BondPortfolio_LastRow+7 &"")
cell.Font.Size = 11 
cell.Font.FontStyle = SpreadsheetFontStyle.Bold

Dim BondPortfolioTotalRange as CellRange=WsCalc.Range("D9:E"& BondPortfolio_LastRow+7)
BondPortfolioTotalRange.NumberFormat="#,##"

Dim MidVecTotalRange as CellRange=WsCalc.Range("M9:M"& BondPortfolio_LastRow+7)
MidVecTotalRange.NumberFormat="#,##"

WsCalc.Cells("A3").Formula = "=E" & BondPortfolio_LastRow+7 & ""
WsCalc.Cells("A3").NumberFormat="#,##"


'CS Calculation
Dim CS_Range as CellRange=WsCalc.Range("G9:G"& BondPortfolio_LastRow+6)
CS_Range.Formula = "=E9*F9*0,01%"
CS_Range.NumberFormat="#,##"

'Single Asset Risk
Dim SingleAssetRisk_Range as CellRange=WsCalc.Range("K9:K"& BondPortfolio_LastRow+6)
SingleAssetRisk_Range.Formula = "=G9*I9"
SingleAssetRisk_Range.NumberFormat="#,##"

Dim WsCalc_TotalRange as CellRange=WsCalc.Range("A1:AZ20000")
WsCalc_TotalRange.AutoFitColumns()





workbook.SaveDocument("C:\PS TOOL DX\EXCEL FILES\PortfolioCreditSpreadRisk.xlsx", DevExpress.Spreadsheet.DocumentFormat.OpenXml)

cmd.Connection.close()



End Sub

End Class