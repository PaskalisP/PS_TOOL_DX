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
CrDailyRiskTables.Load(CrystalRepDir & "\DAILY_RISK_TABLES_TEST.rpt")
CrDailyRiskTables.SetDataSource(DAILY_RISK_TABLESdataset)
CrDailyRiskTables.DataDefinition.ParameterFields(0).ApplyCurrentValues(DateCurrent)
CrDailyRiskTables.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\DAILY RISK TABLES_" & rdsql & ".pdf")
End If
'++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


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