Imports System.Text
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.Spreadsheet
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class TESTING
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
Dim ReportExpRefiFile as string=Nothing
Dim CrystalRepDir as string=Nothing
Dim EItem As Microsoft.Office.Interop.Outlook.MailItem

 Dim conn As New SqlConnection
 Dim cmd As New SqlCommand

conn.ConnectionString = "Data Source=DESKTOP-SLJQ4B6;Initial Catalog=PS TOOL DX Live;Integrated Security=True;Connection Timeout=60"
cmd.Connection = conn
cmd.Connection.Open()
'CREATE EMAIL and SEND
Dim myBuilder As New StringBuilder
Dim myBuilderTuesday As New StringBuilder
Dim dd As Date = Today
Dim NextDay As Date = DateAdd(DateInterval.Day, 1, dd)
Dim NextDaySql As String = NextDay.ToString("yyyyMMdd")
Dim SamstagNextMonday As Date = DateAdd(DateInterval.Day, 3, dd)
Dim SamstagNextMondaySql As String = SamstagNextMonday.ToString("yyyyMMdd")
Dim SamstagNextTuesday As Date = DateAdd(DateInterval.Day, 4, dd)
Dim SamstagNextTuesdaySql As String = SamstagNextTuesday.ToString("yyyyMMdd")
Dim SontagNextMonday As Date = DateAdd(DateInterval.Day, 1, dd)
Dim SantagNexMondaySql As String = SontagNextMonday.ToString("yyyyMMdd")

'Maximalen Report Date ermitteln
cmd.CommandText = "SELECT distinct Max([RepDate]) FROM [TIME DEP OUTST CLIENT DEALS]"
Dim MaxRepDate As Date = cmd.ExecuteScalar
Dim MaxRepDateSql As String = MaxRepDate.ToString("yyyyMMdd")

 cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
 CrystalRepDir = cmd.ExecuteScalar

cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_REFI'"
                    Dim EMAIL_REFI_Valid As String = cmd.ExecuteScalar
XtraMessageBox.show(EMAIL_REFI_Valid)

 If EMAIL_REFI_Valid = "Y" Then
                       
                        'REPORT GENERIERUNG
                        'Create Dataset
                        Dim RefiDa As New SqlDataAdapter("SELECT * FROM [TIME DEP OUTST CLIENT DEALS] where [RepDate] in (SELECT distinct Max([RepDate]) FROM [TIME DEP OUTST CLIENT DEALS])", conn)
                        Dim BankDa As New SqlDataAdapter("SELECT * FROM [BANK]", conn)
                        Dim REPORTINGdataset As New DataSet("REPORTING")
                        BankDa.FillSchema(REPORTINGdataset, SchemaType.Source, "BANK")
                        BankDa.Fill(REPORTINGdataset, "BANK")
                        Dim BankDt As DataTable = REPORTINGdataset.Tables("BANK")
                        RefiDa.FillSchema(REPORTINGdataset, SchemaType.Source, "TIME DEP OUTST CLIENT DEALS")
                        RefiDa.Fill(REPORTINGdataset, "TIME DEP OUTST CLIENT DEALS")
                        Dim RefiDt As DataTable = REPORTINGdataset.Tables("TIME DEP OUTST CLIENT DEALS")

                        'Ordner für exportierte Reports erstellen
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_REFI_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_REFI'"
                        ReportExpRefiFile = cmd.ExecuteScalar
                        'Select EMAIL RECEIVERS
                        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_REFI_RECEIVERS'"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        Dim EMAIL_USERS As String = ""
                        For i as integer= 0 To dt.Rows.Count - 1
                            EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                        Next
                        dt.Clear()
                        'CC to
                        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_REFI_RECEIVERS_CC'"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        Dim EMAIL_USERS_CC As String = ""
                        For i as integer = 0 To dt.Rows.Count - 1
                            EMAIL_USERS_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                        Next



                        'If NextDay.ToString("dddd") = "Samstag" Then
                            '*********************************************************************************************************************************
                            'MATURITIES ON MONDAY
                            QueryText = "SELECT * FROM [TIME DEP OUTST CLIENT DEALS] where [Product Name] like '%REFINANC%' and [Maturity Date]='" & SamstagNextMondaySql & "' and [RepDate] in (SELECT distinct Max([RepDate]) FROM [TIME DEP OUTST CLIENT DEALS])"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                Dim headers As String = "On Monday (" & SamstagNextMonday & ") , following refinance sold funded will be matured:" & vbNewLine
                                Dim Footer As String = "(Please see also the attached pdf file with all refinance maturities)" & vbNewLine

                                myBuilder.Append("Contract No:     " & "Client No:  " & "Client Name:                    " & "Maturity Date: " & " Principal Amount + Interest :" & vbNewLine)


                                For i as integer= 0 To dt.Rows.Count - 1
                                    Dim CapitalPlusInterest As Double = dt.Rows.Item(i).Item("Principal Plus Interest")
                                    myBuilder.Append(dt.Rows.Item(i).Item("Contract No") & "  " & dt.Rows.Item(i).Item("Client No") & "    " & dt.Rows.Item(i).Item("Client Short Name") & "  " & dt.Rows.Item(i).Item("Maturity Date") & "      " & dt.Rows.Item(i).Item("Currency") & "  " & FormatNumber(CapitalPlusInterest, 2) & vbNewLine)
                                Next

                                System.IO.Directory.CreateDirectory(ReportExpRefiFile)

                                'Report generieren
                                Dim CrRepRefinancingMaturityList As New ReportDocument
                                CrRepRefinancingMaturityList.Load(CrystalRepDir & "\REFINANCING_MATURITY_LIST.rpt")
                                Dim field As New CrystalDecisions.Shared.ParameterValues()
                                Dim value As New CrystalDecisions.Shared.ParameterDiscreteValue() 'Fieldvalue 
                                CrRepRefinancingMaturityList.SetDataSource(REPORTINGdataset)
                                value.Value = MaxRepDate
                                field.Add(value)
                                CrRepRefinancingMaturityList.DataDefinition.ParameterFields(0).ApplyCurrentValues(field)
                                CrRepRefinancingMaturityList.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpRefiFile & "\REFINANCING MATURITY LIST.pdf")

                                Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
                                Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
                                Dim outApp As Microsoft.Office.Interop.Outlook.Application

                                outApp = New Microsoft.Office.Interop.Outlook.Application

                                NSpace = outApp.GetNamespace("MAPI")
                                Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
                                EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                                EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

                                EItem.To = EMAIL_USERS
                                EItem.CC = EMAIL_USERS_CC
                                EItem.Attachments.Add(ReportExpRefiFile & "\REFINANCING MATURITY LIST.pdf")

                                EItem.Subject = "MATURED REFINANCES on " & " " & SamstagNextMonday

                                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

                                Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

                                EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
                                EItem.Send()
                                Directory.Delete(ReportExpRefiFile, True)
End If
End if
                            '*********************************************************************************************************************************


cmd.Connection.close()

       
    End Sub
End Class