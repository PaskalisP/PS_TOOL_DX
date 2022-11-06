Imports System
Imports System.Text
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports System.Collections.Generic
Imports System.Diagnostics
Imports DevExpress.XtraEditors
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports Microsoft.SqlServer
Imports Microsoft.SqlServer.Server.DataAccessKind
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlTypes
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports DevExpress.Compression
Imports Ionic.Zip

Public Class PSTOOL_IMPORTS

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""

    Dim OdasDirectory As String = "" 'ODAS FILE DIRECTORY
    Dim OdasFileNewDirectory As String = "" 'NEW DIRECTORY FOR ODAS FILE
    Dim OCBSDirectory As String = "" 'OCBS FILE DIRECTORY
    Dim OCBSFileNewDirectory As String = "" 'NEW DIRECTORY FOR OCBS FILE

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEVENT As New SqlConnection
    Dim cmdEVENT As New SqlCommand
    'Oledb Connection for ODAS
    Dim connODAS As New SqlConnection
    Dim cmdODAS As New SqlCommand
    'Oledb Connection for OCBS
    Dim connOCBS As New SqlConnection
    Dim cmdOCBS As New SqlCommand

    Dim CrystalRepDir As String = ""
    Dim ReportExpFile As String = "" 'Directory for the report creation REFINANCING_MATURITY_LIST
    Dim ReportExpRefiFile As String = ""

    Dim EXCELL As New Microsoft.Office.Interop.Excel.Application
    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    Dim xlWorksheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem

    Dim newCulture As System.Globalization.CultureInfo
    Dim OldCulture As System.Globalization.CultureInfo

    
    Dim SSISDirectory As String = Nothing

    Dim COIF As Double = Nothing 'CurrentImportODASFile
    Dim LOIF As Double = Nothing ' LastImportedODASFile
    Dim COBIF As Double = Nothing 'CurrentImportOCBSFile
    Dim LOBIF As Double = Nothing ' LastImportedOCBSFile
    Dim COIFN As String = ""
    Dim CURRENT_PROC As String = Nothing

    Delegate Sub ChangeText()

    Private QueryText As String = ""
    Private conndt As New SqlConnection
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable
    Private da3 As New SqlDataAdapter
    Private dt3 As New DataTable
    Dim ex As Integer

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim EMAIL_USERS As String = Nothing
    Dim HasDataResult As String = Nothing


    Dim CurrentClientProcedure As String = Nothing

    Dim MaxProcDate As Date
    Dim CheckingDate As Date
    Dim CheckingDateSql As String = Nothing
    Dim LastDayCurrentMonth As Date
    Dim FirstDayOverNextMonth As Date

    Dim wck As Double = 0
    Dim summeAM1 As Double = 0
    Dim summeAM2 As Double = 0

    Dim sumCreditRiskAmountEUR As Double = 0
    Dim sumCreditOutstandingEURequ As Double = 0
    Dim sumMAKEuroEquivalent As Double = 0
    Dim sumdifference As Double = 0
    Dim sumNetCreditRiskAmountEUR As Double = 0
    Dim sumNetCreditRiskAmountEUR45 As Double = 0
    Dim BadRefinaceSoldFounded As Double = 0
    Dim SumPledgedVariableDepositsCustomer As Double = 0

    Dim pathToZipArchive As String = Nothing
    Dim currentArchive As ZipArchive
    Dim item As ZipItem

    Sub New()
        InitSkins()
        InitializeComponent()


    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("Sharp Plus")

    End Sub


    Private Sub ODASLastProcFileBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ODASLastProcFileBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub


#Region "SPECIAL FUNTIONS"
    ' Gesamten Inhalt eines Ordners kopieren
    Public Sub CopyFolder(ByVal sSrcPath As String, ByVal sDestPath As String, Optional ByVal bSubFolder As Boolean = True, Optional ByVal bOverWrite As Boolean = True)

        ' Falls Zielordner nicht existiert, jetzt erstellen
        If Not System.IO.Directory.Exists(sDestPath) Then
            System.IO.Directory.CreateDirectory(sDestPath)
        End If

        ' zunächst alle Dateien des Quell-Ordners ermitteln
        ' und kopieren
        Dim sFiles() As String = System.IO.Directory.GetFiles(sSrcPath)
        Dim sFile As String
        For i As Integer = 0 To sFiles.Length - 1
            ' Falls Datei im Zielordner bereits existiert, nur 
            ' kopieren, wenn Parameter "bOverWrite" auf True 
            ' festgelegt ist
            sFile = sFiles(i).Substring(sFiles(i).LastIndexOf("\") + 1)
            If bOverWrite Or Not System.IO.File.Exists(sDestPath & "\" & sFile) Then
                System.IO.File.Copy(sFiles(i), sDestPath & "\" & sFile, True)
            End If
        Next i

        If bSubFolder Then
            ' jetzt alle Unterordner ermitteln und die CopyFolder-Funktion
            ' rekursiv aufrufen
            Dim sDirs() As String = System.IO.Directory.GetDirectories(sSrcPath)
            Dim sDir As String
            For i As Integer = 0 To sDirs.Length - 1
                If sDirs(i) <> sDestPath Then
                    sDir = sDirs(i).Substring(sDirs(i).LastIndexOf("\") + 1)
                    CopyFolder(sDirs(i), sDestPath & "\" & sDir, True, bOverWrite)
                End If
            Next i
        End If
    End Sub

    Private Function GetFirstDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtFrom As DateTime = dtDate
        dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1))
        Return dtFrom
    End Function


    Private Function GetLastDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtTo As New DateTime(dtDate.Year, dtDate.Month, 1)
        dtTo = dtTo.AddMonths(1)
        dtTo = dtTo.AddDays(-(dtTo.Day))
        Return dtTo
    End Function

    'Change the Current ODAS File in Form
    Public Sub Change_COIF()
        Me.CurrentOdasImportFile.Text = COIF
    End Sub
    'Change the Current OCBS File in Form
    Public Sub Change_COBIF()
        Me.CurrentOcbsImportFile.Text = COBIF
    End Sub
    'Change the Last ODAS Import File in Form
    Public Sub Change_LOIF()
        Me.LastOdasImportFile.Text = LOIF
    End Sub
    'Change the Last OCBS Import File in Form
    Public Sub Change_LOBIF()
        Me.LastOcbsImportFile.Text = LOBIF
    End Sub
    'Change Current Procedure in Form
    Public Sub Change_CURRENT_PROC()
        Me.CURRENT_PROCEDURE_Text.Text = CURRENT_PROC
    End Sub
    'Clear Current Procedure in Form
    Public Sub Clear_CURRENT_PROC()
        Me.CURRENT_PROCEDURE_Text.Text = ""
    End Sub
    'Clear Current ODAS Import File in Form
    Public Sub Clear_COIF()
        Me.CurrentOdasImportFile.Text = ""
        Me.CURRENT_PROCEDURE_Text.Text = ""
    End Sub
    'Clear Current OCBS Import File in Form
    Public Sub Clear_COBIF()
        Me.CurrentOcbsImportFile.Text = ""
        Me.CURRENT_PROCEDURE_Text.Text = ""
    End Sub
    'Show Progress in a ODAS Excel File with 5000 Rows
    Public Sub PROGRESS_ODAS_MAX5()
        Me.ODASProgressBar.Maximum = 5000
    End Sub
    'Show Progress in a OCBS Excel File with 5000 Rows
    Public Sub PROGRESS_OCBS_MAX5()
        Me.OCBSProgressBar.Maximum = 5000
    End Sub
    'Show Progress in a ODAS Excel File with 10000 Rows
    Public Sub PROGRESS_ODAS_MAX10()
        Me.ODASProgressBar.Maximum = 10000
    End Sub
    'Show Progress in a OCBS Excel File with 10000 Rows
    Public Sub PROGRESS_OCBS_MAX10()
        Me.OCBSProgressBar.Maximum = 10000
    End Sub
    'Show Progress in a ODAS Excel File-Progress Bar
    Public Sub PROGRESS_ODAS_EXCEL()
        Me.ODASProgressBar.Increment(1)
        If Me.ODASProgressBar.Value = Me.ODASProgressBar.Maximum Then
            Me.ODASProgressBar.Value = 0
        End If
    End Sub
    'Show Progress in a OCBS Excel File-Progress Bar
    Public Sub PROGRESS_OCBS_EXCEL()
        Me.OCBSProgressBar.Increment(1)
        If Me.OCBSProgressBar.Value = Me.OCBSProgressBar.Maximum Then
            Me.OCBSProgressBar.Value = 0
        End If
    End Sub

    Private Sub Unziped()

    End Sub

#End Region

    Private Sub PSTOOL_IMPORTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Excel Instanz beenden
        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
        Dim i1 As Short
        i1 = 0
        For i1 = 0 To (procs.Length - 1)
            procs(i1).Kill()
        Next i1
        '**********************************************************

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT
        connODAS.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdODAS.Connection = connODAS
        connOCBS.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdOCBS.Connection = connOCBS

        'Get SSIS Directory
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='SSIS_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SSIS_DIRECTORY'"
        cmd.Connection.Open()
        SSISDirectory = cmd.ExecuteScalar()
        cmd.Connection.Close()
        '*********************************************************
        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        '***********************************************************************
        '*******IMPORT EVENTS DIRECTORY*************
        '*******************************************
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='IMPORT EVENTS DIRECTORY' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        ImportEventsDirectory = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        '************** EMAIL RECEIVERS FOR ERRORS********************
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='IMPORT_ERRORS_EMAIL'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
            Next
        End If
        '***********************************************************************



        Me.OCBSLastProcFileTableAdapter.Fill(Me.PSTOOLDataset.OCBSLastProcFile)
        Me.ODASLastProcFileTableAdapter.Fill(Me.PSTOOLDataset.ODASLastProcFile)

        If Me.BgwODASimport.IsBusy = False Then
            Me.BgwODASimport.RunWorkerAsync()
        End If


    End Sub

    
#Region "ODAS BACKGROUNDWORKER"

    Private Sub BgwODASimport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwODASimport.DoWork

        Try
            Me.BgwODASimport.ReportProgress(10, "Locate the ODAS Current and Temp Directory...")
            'Ermitteln der Directories
            cmdODAS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='ODAS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='ODAS_IMPORT'"
            cmdODAS.Connection.Open()
            OdasDirectory = cmdODAS.ExecuteScalar()
            cmdODAS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='ODAS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='ODAS_IMPORT'"
            OdasFileNewDirectory = cmdODAS.ExecuteScalar()

            Me.BgwODASimport.ReportProgress(20, "ODAS Directories - Current: " & OdasDirectory & " - Temporary: " & OdasFileNewDirectory)

            Me.BgwODASimport.ReportProgress(25, "Create Temporary Table: ODASFilesTemp")
            cmdODAS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ODASFilesTemp' AND xtype='U') CREATE TABLE ODASFilesTemp (id int IDENTITY(1,1),ODASsubdirectories nvarchar(512),depth int) ELSE DELETE FROM [ODASFilesTemp] "
            cmdODAS.ExecuteNonQuery()
            Me.BgwODASimport.ReportProgress(30, "Insert ODAS File in Table: ODASFilesTemp")
            cmdODAS.CommandText = "INSERT [ODASFilesTemp] ([ODASsubdirectories],[depth]) EXEC master..xp_dirtree '" & OdasDirectory & "'"
            cmdODAS.ExecuteNonQuery()
            Me.BgwODASimport.ReportProgress(35, "Create Temporary Table: ODAS FILES")
            cmdODAS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ODAS FILES' AND xtype='U') CREATE TABLE [ODAS FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[FileName] [float] NULL,[FileFullName] [nvarchar](255) NULL) ELSE DELETE FROM [ODAS FILES] "
            cmdODAS.ExecuteNonQuery()
            Me.BgwODASimport.ReportProgress(40, "Insert in Table: ODAS FILES from Table: ODASFilesTemp")
            cmdODAS.CommandText = "INSERT INTO [ODAS FILES] ([FileName],[FileFullName]) Select Cast([ODASsubdirectories] as float),'" & OdasDirectory & "'+ [ODASsubdirectories] from [ODASFilesTemp]"
            cmdODAS.ExecuteNonQuery()
            Me.BgwODASimport.ReportProgress(45, "Delete from Table: ODAS FILES where FileName < Last Odas Import File: " & Me.LastOdasImportFile.Text)
            cmdODAS.CommandText = "DELETE FROM [ODAS FILES] where [FileName]<'" & Me.LastOdasImportFile.Text & "'"
            cmdODAS.ExecuteNonQuery()

            Me.QueryText = "SELECT [FileName],[FileFullName]  FROM [ODAS FILES]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)

            Me.BgwODASimport.ReportProgress(50, "Select the next ODAS File for Import")
            For m = 0 To dt.Rows.Count - 1
                Me.QueryText = "Select  [FileName] as NextFileNameforimport,[FileFullName] as NextFileFullName from [ODAS FILES] where [FileName] in (SELECT min([FileName])FROM [ODAS FILES] where [FileName]>(Select [FileName] from [ODASLastProcFile]))"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    COIF = dt1.Rows.Item(0).Item("NextFileNameforimport")
                    'Define Business Date based on the COIF
                    Dim BTD As String = COIF
                    rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                    rdsql = rd.ToString("yyyyMMdd")
                    '**************************************************************************
                    Me.CurrentOdasImportFile.BeginInvoke(New ChangeText(AddressOf Change_COIF))
                    Me.BgwODASimport.ReportProgress(55, "Next ODAS File for Import: " & COIF)
                    'Current ODAS File for Import-Insert in the Events Journal after finishing the current ODAS Import
                    Dim LCOIF As String = COIF
                    Dim OdasFileFullName As String = dt1.Rows.Item(0).Item("NextFileFullName")
                    'Löschen des Ordners in ODAS FILES
                    Me.BgwODASimport.ReportProgress(60, "Delete from ODAS FILES the File: " & COIF)
                    cmdODAS.CommandText = "DELETE  FROM [ODAS FILES] where [FileName]='" & COIF & "'"
                    cmdODAS.ExecuteNonQuery()

                    '**************************************************************************
                    'TEST UNZIP DEVEXPRESS
                    If Directory.Exists(OdasFileNewDirectory) Then
                        Directory.Delete(OdasFileNewDirectory, True)
                    End If
                    Directory.CreateDirectory(OdasFileNewDirectory)
                    pathToZipArchive = OdasFileFullName & "\EOD_ODAS_REPORT_67800000000_" & COIF & "" & ".zip"
                    '+++++++++
                    'currentArchive = ZipArchive.Read(pathToZipArchive)
                    'For Each item As ZipItem In currentArchive
                    'If item.Name = "int_rate_risk_all-en.xls" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "fristen_dtl-en.xls" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "cs_d_1006-en.xlsx" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "cs_d_2029-en.xlsx" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "credit_risk-en.xls" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "mak-en.xls" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "acc_int_analysis-en.xls" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "ts_d_1047-en.xlsx" Then
                    'item.Extract(OdasFileNewDirectory)
                    'ElseIf item.Name = "hobr_sum-en.xls" Then
                    'item.Extract(OdasFileNewDirectory)
                    'End If
                    'Next item
                    '**********
                    Using zip As ZipFile = ZipFile.Read(pathToZipArchive)
                        Dim z As ZipEntry
                        For Each z In zip
                            If z.FileName.EndsWith(".xls") = True OrElse z.FileName.EndsWith(".xlsx") = True Then
                                z.Extract(OdasFileNewDirectory, ExtractExistingFileAction.OverwriteSilently)
                            End If
                        Next
                    End Using

                    '***************************************************************************

                    ' Ordner einschl. aller Unterordner kopieren
                    'Me.BgwODASimport.ReportProgress(65, "Copy Folder:" & OdasFileFullName & " to " & OdasFileNewDirectory)
                    'CopyFolder(OdasFileFullName, OdasFileNewDirectory)
                    'DATEI ENTZIPPEN
                    'Dim file As String = OdasFileNewDirectory & "\EOD_ODAS_REPORT_67800000000_" & COIF & "" & ".zip"
                    'Me.BgwODASimport.ReportProgress(70, "Start unzip File: " & "  " & file)
                    'ENTZIPPEN+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Dim cu As New ClassUnzip(file, Path.Combine(Path.GetDirectoryName(file), "ODAS_unzip_folder"))
                    'AddHandler cu.UnzipFinishd, AddressOf Unziped
                    'cu.UnzipNow()
                    'Directory von wo das Programm auf die jeweiligen Dateien zugreift
                    'ODAS_Temp_Directory = OdasFileNewDirectory & "\ODAS_unzip_folder"

                    Me.BgwODASimport.ReportProgress(75, "ODAS File for Import: " & "  " & CurrentOdasImportFile.Text & " is ready")
                    Me.BgwODASimport.ReportProgress(80, "Starting the ODAS Import procedures...")

                    '++++++++PROZESSE+++++++++++++
                    ODAS_IMPORT_PROCEDURES()

                    '++++++++++++++++++++++++++++++++++++++++++++++
                    'Erstellten Ordner wieder löschen
                    Me.BgwODASimport.ReportProgress(85, "Delete Directory: " & "  " & OdasFileNewDirectory)
                    Directory.Delete(OdasFileNewDirectory, True)

                    'Ordner als Bearbeitet einsetzen (LOIF)
                    Me.BgwODASimport.ReportProgress(90, "Set as  Last imported ODAS File Name: " & "  " & COIF)
                    cmdODAS.CommandText = "UPDATE [ODASLastProcFile] SET [FileName]='" & COIF & "' WHERE [ID]=1"
                    cmdODAS.ExecuteNonQuery()

                    LOIF = COIF
                    Me.LastOdasImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOIF))
                    COIF = Nothing
                    Me.CurrentOdasImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COIF))



                    Me.ODASLastProcFileTableAdapter.Fill(Me.PSTOOLDataset.ODASLastProcFile)

                    Me.BgwODASimport.ReportProgress(95, "ODAS File Import: " & " " & LCOIF & " " & "is finished ...")
                    Me.BgwODASimport.ReportProgress(100, "ODAS Import finished ...")
                End If
            Next m
            cmdODAS.CommandText = "DROP TABLE [ODASFilesTemp]"
            cmdODAS.ExecuteNonQuery()
            cmdODAS.CommandText = "DROP TABLE [ODAS FILES]"
            cmdODAS.ExecuteNonQuery()

            If cmdODAS.Connection.State = ConnectionState.Open Then
                cmdODAS.Connection.Close()
            End If

        Catch ex As Exception

            Me.BgwODASimport.ReportProgress(0, "ERROR +++Import Procedure for ODAS File: " & " " & Me.CurrentOdasImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
            Exit Sub

        Finally
            Me.BgwODASimport.CancelAsync()
            'Directory Löschen
            If Directory.Exists(OdasFileNewDirectory) = True Then
                Directory.Delete(OdasFileNewDirectory, True)
            End If
            'Excel Instanz beenden
            Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            Dim i1 As Short
            i1 = 0
            For i1 = 0 To (procs.Length - 1)
                procs(i1).Kill()
            Next i1

        End Try

    End Sub

    Private Sub BgwODASimport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwODASimport.ProgressChanged
        Me.EVENTSloadtext.Text = e.UserState
        Me.ODASProgressBar.Value = e.ProgressPercentage


        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & Me.EVENTSloadtext.Text & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','ODAS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ODAS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','ODAS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ODAS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            '***************************************************
            'Dim myBuilder As New StringBuilder
            'Dim headers As String = "On " & Today & " the following import error have being occured in ODAS Imports:" & vbNewLine
            'Dim Footer As String = "(Please check the error and restart the related import procedure)" & vbNewLine
            'Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
            'Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
            'Dim outApp As Microsoft.Office.Interop.Outlook.Application

            'outApp = New Microsoft.Office.Interop.Outlook.Application

            'NSpace = outApp.GetNamespace("MAPI")
            'Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
            'EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
            'EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

            'EItem.To = EMAIL_USERS

            'EItem.Subject = "PS TOOL - ODAS IMPORT ERROR on " & " " & Today

            'EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

            'myBuilder.Append("ERROR: " & ex.Message.ToString.Replace("'", " ") & "  Procedure Name: " & Me.CURRENT_PROCEDURE_Text.Text & " System: ODAS" & vbNewLine)


            'Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

            'EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
            'EItem.Send()
            '**************************************
            Exit Try
        End Try
        cmdEVENT.Connection.Close()
    End Sub

    Private Sub BgwODASimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwODASimport.RunWorkerCompleted
        Me.ODASProgressBar.Value = 0
        If Me.BgwOCBSimport.IsBusy = False Then
            Me.BgwOCBSimport.RunWorkerAsync()
        End If
    End Sub

#End Region

    Private Sub ODAS_IMPORT_PROCEDURES()
        Me.ODAS_IMPORT_INTEREST_RATE_RISK()
        Me.ODAS_IMPORT_FX_POSITION()
        Me.ODAS_IMPORT_BILANZ_NONE_CPD_ACCOUNTS()
        Me.ODAS_COPY_FRISTEN()
        Me.ODAS_IMPORT_FRISTEN()
        Me.ODAS_IMPORT_CREDIT_RISK_MAK_REPORT()
        Me.ODAS_IMPORT_ACCRUED_INTEREST_ANALYSIS()
        Me.ODAS_IMPORT_FOREIGN_EXCHANGE_DAILY_REVALUATION()
        Me.ODAS_IMPORT_OBLIGO_LIABILITIES_SURPLUS()

    End Sub

#Region "ODAS IMPORTS"

    Private Sub ODAS_IMPORT_INTEREST_RATE_RISK()
        Try

            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "INTEREST RATE RISK"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='INTEREST RATE RISK' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwODASimport.ReportProgress(1, "Starting Procedure: INTEREST RATE RISK")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\int_rate_risk_all-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\int_rate_risk_all-en.xls"

                If File.Exists(ExcelFileName) = True Then
                    Me.BgwODASimport.ReportProgress(2, "Import File:int_rate_risk_all-en.xls...Please wait...")
                    Try
                        'Dateiendung anzeigen
                        Dim ExcelFileNameExt As String
                        Dim fi As New IO.FileInfo(ExcelFileName)
                        ExcelFileNameExt = fi.Extension

                        'Excel Datei Öffnen und Datenformat ändern
                        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
                        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                        EXCELL = CreateObject("Excel.Application")
                        xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                        xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                        EXCELL.Visible = False

                        Me.BgwODASimport.ReportProgress(3, "Changing Column Names-(J9=CURRENCY)-(U9=DATA DATE)-(V9=RISK DATE)")
                        xlWorksheet1.Range("J9").Value = "CURRENCY"
                        'xlWorksheet1.Range("U9").Value = "DATA DATE"
                        'xlWorksheet1.Range("V9").Value = "RISK DATE"
                        'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("B4").Value, 4), Mid(xlWorksheet1.Range("B4").Value, 11, 2), Mid(xlWorksheet1.Range("B4").Value, 8, 2))
                        'rdsql = rd.ToString("yyyy-MM-dd")
                        Me.BgwODASimport.ReportProgress(4, "Defined RiskDate" & "  " & rdsql)

                        'Währung + Datum einfügen wo daten vorhanden sind
                        'Wenn Contract/Account nicht leer sind 
                        'Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Input Risk date")
                        'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                        'Dim i As Integer
                        'For i = 10 To 5000
                        'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        'If xlWorksheet1.Cells(i, 4).value <> "" Then 'Wenn Type nicht leer ist!
                        'xlWorksheet1.Cells(i, 21).Value = xlWorksheet1.Range("A2").Value
                        'xlWorksheet1.Cells(i, 22).Value = rd
                        'End If
                        'Next i
                        'Blatt 1 - Datumsformat einfügen

                        'xlWorksheet1.Columns("U:V").numberformat = "m/d/yyyy"
                        xlWorksheet1.Columns("U:V").numberformat = "yyyy-MM-dd"

                        ' Neue Zeile für PERIOD einfügen
                        xlWorksheet1.Columns("A:A").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                        xlWorksheet1.Range("A9").Value = "PERIOD"


                        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        Dim p1 As String = "<= 1 Month"
                        Dim p2 As String = "1 - 3 Months"
                        Dim p3 As String = "3 - 6 Months"
                        Dim p4 As String = "6 - 12 Months"
                        Dim p5 As String = "1 - 2 Years"
                        Dim p6 As String = "2 - 3 Years"
                        Dim p7 As String = "3 - 4 Years"
                        Dim p8 As String = "4 - 5 Years"
                        Dim p9 As String = "5 - 7 Years"
                        Dim p10 As String = "7 - 10 Years"
                        Dim p11 As String = "10 - 15 Years"
                        Dim p12 As String = "15 - 20 Years"
                        Dim p13 As String = "> 20 Years"

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Input correct period format")
                        For i = 10 To 5000
                            Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                            '<=1 month net positions:
                            If xlWorksheet1.Cells(i, 10).value = "<= 1 month net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p1
                            End If
                            '1 - 3 months net positions:
                            If xlWorksheet1.Cells(i, 10).value = "1 - 3 months net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p2
                            End If
                            '3 - 6 months net positions:
                            If xlWorksheet1.Cells(i, 10).value = "3 - 6 months net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p3
                            End If
                            '6 - 12 months net positions:
                            If xlWorksheet1.Cells(i, 10).value = "6 - 12 months net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p4
                            End If
                            '1 - 2 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "1 - 2 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p5
                            End If
                            '2 - 3 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "2 - 3 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p6
                            End If
                            '3 - 4 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "3 - 4 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p7
                            End If
                            '4 - 5 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "4 - 5 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p8
                            End If
                            '5 - 7 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "5 - 7 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p9
                            End If
                            '7 - 10 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "7 - 10 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p10
                            End If
                            '10 - 15 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "10 - 15 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p11
                            End If
                            '15 - 20 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "15 - 20 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p12
                            End If
                            '> 20 years net positions:
                            If xlWorksheet1.Cells(i, 10).value = "> 20 years net positions:" Then
                                xlWorksheet1.Cells(i, 1).Value = p13
                            End If
                        Next i


                        'Einfügen der Perioden auf die jeweiligen leerzeilen
                        Dim q As Integer      ' counter for the position in the series
                        q = 10

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:<= 1 Month")
                        Dim AC As Microsoft.Office.Interop.Excel.Range ' <= 1 Month
                        AC = xlWorksheet1.Range("A1:A5000").Find("<= 1 Month")
                        If AC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p1
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p1
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:1 - 3 Months")
                        Dim BC As Microsoft.Office.Interop.Excel.Range '1 - 3 Months
                        BC = xlWorksheet1.Range("A1:A5000").Find("1 - 3 Months") ' Der Bereich mit den Numerischen Daten
                        If BC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p2
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p2
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:3 - 6 Months")
                        Dim CC As Microsoft.Office.Interop.Excel.Range '3 - 6 Months
                        CC = xlWorksheet1.Range("A1:A5000").Find("3 - 6 Months") ' Der Bereich mit den Numerischen Daten
                        If CC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p3
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p3
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:6 - 12 Months")
                        Dim DC As Microsoft.Office.Interop.Excel.Range '6 - 12 Months
                        DC = xlWorksheet1.Range("A1:A5000").Find("6 - 12 Months") ' Der Bereich mit den Numerischen Daten
                        If DC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p4
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p4
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:1 - 2 Years")
                        Dim EC As Microsoft.Office.Interop.Excel.Range '1 - 2 Years
                        EC = xlWorksheet1.Range("A1:A5000").Find("1 - 2 Years") ' Der Bereich mit den Numerischen Daten
                        If EC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p5
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p5
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:2 - 3 Years")
                        Dim FC As Microsoft.Office.Interop.Excel.Range '2 - 3 Years
                        FC = xlWorksheet1.Range("A1:A5000").Find("2 - 3 Years") ' Der Bereich mit den Numerischen Daten
                        If FC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p6
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p6
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:3 - 4 Years")
                        Dim GC As Microsoft.Office.Interop.Excel.Range '3 - 4 Years
                        GC = xlWorksheet1.Range("A1:A5000").Find("3 - 4 Years") ' Der Bereich mit den Numerischen Daten
                        If GC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p7
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p7
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:4 - 5 Years")
                        Dim HC As Microsoft.Office.Interop.Excel.Range '4 - 5 Years
                        HC = xlWorksheet1.Range("A1:A5000").Find("4 - 5 Years") ' Der Bereich mit den Numerischen Daten
                        If HC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p8
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p8
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:5 - 7 Years")
                        Dim IC As Microsoft.Office.Interop.Excel.Range '5 - 7 Years
                        IC = xlWorksheet1.Range("A1:A5000").Find("5 - 7 Years") ' Der Bereich mit den Numerischen Daten
                        If IC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p9
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p9
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:7 - 10 Years")
                        Dim JC As Microsoft.Office.Interop.Excel.Range '7 - 10 Years
                        JC = xlWorksheet1.Range("A1:A5000").Find("7 - 10 Years") ' Der Bereich mit den Numerischen Daten
                        If JC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p10
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p10
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:10 - 15 Years")
                        Dim KC As Microsoft.Office.Interop.Excel.Range '10 - 15 Years
                        KC = xlWorksheet1.Range("A1:A5000").Find("10 - 15 Years") ' Der Bereich mit den Numerischen Daten
                        If KC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p11
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p11
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:15 - 20 Years")
                        Dim LC As Microsoft.Office.Interop.Excel.Range '15 - 20 Years
                        LC = xlWorksheet1.Range("A1:A5000").Find("15 - 20 Years") ' Der Bereich mit den Numerischen Daten
                        If LC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p12
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p12
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:> 20 Years")
                        Dim MC As Microsoft.Office.Interop.Excel.Range '15 - 20 Years
                        MC = xlWorksheet1.Range("A1:A5000").Find("> 20 Years") ' Der Bereich mit den Numerischen Daten
                        If MC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p13
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 5).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p13
                                End If
                                q = q + 1
                            Loop
                        End If

                        xlWorksheet1.Rows("1:8").delete()


                        'Unmerge Cells
                        xlWorksheet1.Columns("B:B").unMerge()

                        'zwischensumme löschen
                        'Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Delete Subtotals")
                        'For i = 1 To 5000
                        'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        'If Trim(xlWorksheet1.Cells(i, 5).value) = "" Then
                        'xlWorksheet1.Rows(i).Delete()
                        'End If
                        'If Trim(xlWorksheet1.Cells(i, 2).value) = "" Then
                        'xlWorksheet1.Rows(i).Delete()
                        'End If
                        'If Trim(xlWorksheet1.Cells(i, 1).value) = "" Then
                        'xlWorksheet1.Rows(i).Delete()
                        'End If
                        'Next


                        'Blatt 1 - Leere spalten löschen
                        xlWorksheet1.Columns("N:U").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        'Blatt 1 - Datumsformat einfügen
                        xlWorksheet1.Columns("H:I").numberformat = "yyyy-MM-dd"
                        xlWorksheet1.Range("E1").Value = "Contract/Account"
                        'Dim xlData As String = xlWorksheet1.Range("A1").Value



                        EXCELL.Application.DisplayAlerts = False
                        xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1

                        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        'Excel_Test()
                        'MsgBox("OK")


                        Me.BgwODASimport.ReportProgress(21, "Delete Same data")

                        'Alle weiteren Daten mit dem Aktuellen RiskDate(rd) löschen
                        'cmd.CommandText = "DELETE  FROM [RATERISK DETAILS] WHERE [RISK DATE]='" & rdsql & "'"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE  FROM [RATERISK DETAILS ALL DATA] WHERE [RISK DATE]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'cmd.CommandText = "DELETE  FROM [RATERISK TOTALS] WHERE [RISK DATE]='" & rdsql & "'"
                        'cmd.ExecuteNonQuery()
                        'cmd.CommandText = "DELETE  FROM [RATERISK DATE] WHERE [RateRiskDate]='" & rdsql & "'"
                        'cmd.ExecuteNonQuery()
                        'cmd.CommandText = "DELETE  FROM [RATERISK DELETIONS] WHERE [RISK DATE]='" & rdsql & "'"
                        'cmd.ExecuteNonQuery()
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        'If xlData <> "" Then
                        '++++++++++++++++++++++++++++++++++++++++++
                        'DETAILS
                        Try
                            Me.BgwODASimport.ReportProgress(22, "Create temporary Table IMPORT RATERISK DETAILS")
                            'Alte Daten im IMPORT DATATABLE löschen
                            cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='IMPORT RATERISK DETAILS' AND xtype='U') CREATE TABLE [dbo].[IMPORT RATERISK DETAILS]([ID] [int] IDENTITY(1,1) NOT NULL,[Contract Type] [nvarchar](255) NULL,[PERIOD] [nvarchar](255) NULL,[GLMaster / Account Type] [nvarchar](255) NULL,[ProductType] [nvarchar](255) NULL,[Contract/Account] [nvarchar](255) NULL,[Counterparty/Issuer] [nvarchar](255) NULL,[Next EventDate][datetime] NULL,[Next EventType] [nvarchar](255) NULL,[Final Maturity Date] [datetime] NULL,[CURRENCY] [nvarchar](255) NULL,[Type] [nvarchar](255) NULL,[Principal Amount/Value Balance] [float] NULL,[Principal Amount/Value Balance(EUR Equ)] [float] NULL,[RISK DATE][datetime] NULL) ELSE DELETE FROM [IMPORT RATERISK DETAILS]"
                            cmd.ExecuteNonQuery()

                            '******************************************************
                            'Ausführen SSI-Daten importieren 
                            'Me.BgwODASimport.ReportProgress(23, "Start SSI for Import InterestRateRiskAll")
                            'pkg = app.LoadPackage(SSISDirectory & "InterestRateRiskAll.dtsx", Nothing)
                            'pkgResults = pkg.Execute()
                            'Me.BgwODASimport.ReportProgress(23, "INTEREST RATE RISK SSI Result:" & pkgResults.ToString())
                            '******************************************************
                            Me.BgwODASimport.ReportProgress(22, "Import Data from Excel Sheet where CURRENCY is not NULL")
                            cmd.CommandText = "INSERT INTO [IMPORT RATERISK DETAILS] ([Contract Type],[PERIOD],[GLMaster / Account Type],[ProductType],[Contract/Account],[Counterparty/Issuer],[Next EventDate],[Next EventType],[Final Maturity Date],[CURRENCY],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)])   SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Contract Type],[PERIOD],[GLMaster / Account Type],[ProductType],[Contract/Account],[Counterparty/Issuer],[Next EventDate],[Next EventType],[Final Maturity Date],[CURRENCY],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)] FROM [Sheet1$] where [CURRENCY] is not NULL')"
                            cmd.ExecuteNonQuery()
                            Me.BgwODASimport.ReportProgress(22, "Input Risk Date in IMPORT RATERISK DETAILS")
                            cmd.CommandText = "UPDATE [IMPORT RATERISK DETAILS] SET [RISK DATE]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()

                            Me.BgwODASimport.ReportProgress(22, "RATERISK DETAILS imported sucessfully")

                            Me.BgwODASimport.ReportProgress(24, "Insert Data in Table RATERISK DETAILS ALL DATA")
                            'Prüfen ob daten vorhanden sind
                            'cmd.CommandText = "SELECT distinct [RISK DATE] FROM [RATERISK DETAILS] Where [RISK DATE]='" & rdsql & "'"
                            'Dim t As String = cmd.ExecuteScalar()
                            'If IsNothing(t) = False Then
                            'Wenn daten vorhanden "Do Nothing"
                            'Else
                            Try
                                'Neuanlage in RISK DETAILS
                                'cmd.CommandText = "INSERT INTO [RATERISK DETAILS]([CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[DATA DATE],[RISK DATE],[IdRateRiskDate])Select[CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[DATA DATE],[RISK DATE],[RISK DATE]FROM [IMPORT RATERISK DETAILS]"
                                'cmd.ExecuteNonQuery()
                                cmd.CommandText = "INSERT INTO [RATERISK DETAILS ALL DATA]([CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[RISK DATE],[IdRateRiskDate])Select[CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[RISK DATE],[RISK DATE]FROM [IMPORT RATERISK DETAILS]"
                                cmd.ExecuteNonQuery()
                                'löschen der IMPORT Tabelle
                                cmd.CommandText = "DROP TABLE [IMPORT RATERISK DETAILS]"
                                cmd.ExecuteNonQuery()

                            Catch ex As System.Exception
                                Me.BgwODASimport.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))

                            End Try
                            'End If
                            '++++++++++++++++++++++++++++++++++++++++++++++++++

                        Catch ex As Exception
                            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                        End Try




                    Catch ex As Exception
                        Me.BgwODASimport.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
                    End Try

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If



                Me.BgwODASimport.ReportProgress(100, "Import procedure: INTEREST RATE RISK is finished sucesfully")

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure:INTEREST RATE RISK is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As System.Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try


    End Sub

    Private Sub ODAS_COPY_FRISTEN()
        Try
            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "COPY FRISTEN"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))



            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='COPY FRISTEN' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwODASimport.ReportProgress(1, "Starting procedure: COPY FRISTEN")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\fristen_dtl-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\fristen_dtl-en.xls"

                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(2, "Copy: fristen_dtl-en.xls on directory...\\CCB-DATEN\EDP_Department\FRISTEN...Please wait...")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                    EXCELL.Visible = False

                    'Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("B3").Value, "As of", "")), "-", "")
                    'Report Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))
                    'rdsql = rd.ToString("yyyy-MM-dd")

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs("\\CCB-DATEN\EDP_Department\FRISTEN\Fristen " & rdsql & ".xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault)
                    Me.BgwODASimport.ReportProgress(3, "File saved in directory as " & " " & "Fristen " & rdsql & ".xlsx")
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1
                    Me.BgwODASimport.ReportProgress(100, "Import procedure: COPY FRISTEN finished")
                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If

            Else

                Me.BgwODASimport.ReportProgress(0, "+++Import Procedure: COPY FRISTEN is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try

    End Sub

    Private Sub ODAS_IMPORT_FX_POSITION()
        Try
            Dim rdfx As Date 'FX POSITION DATE DIFFERS FROM THE CURRENT BUSINESS DATE
            Dim rdsqlfx As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "FX POSITION"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))



            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='FX POSITION' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(1, "Starting import procedure: FX POSITION")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\cs_d_1006-en.xlsx"
                ExcelFileName = OdasFileNewDirectory & "\cs_d_1006-en.xlsx"

                If File.Exists(ExcelFileName) = True Then


                    Me.BgwODASimport.ReportProgress(2, "Importing: cs_d_1006-en.xlsx...Please wait...")

                    'Dateiendung anzeigen
                    'Dim ExcelFileNameExt As String
                    'Dim fi As New IO.FileInfo(ExcelFileName)
                    'ExcelFileNameExt = fi.Extension

                    'Excel Datei Öffnen und Datenformat ändern
                    'EXCELL = CreateObject("Excel.Application")
                    'xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    'xlWorksheet1 = xlWorkBook.Worksheets(1)
                    'EXCELL.Visible = False

                    'Unmerge Cells
                    'xlWorksheet1.Columns("A:A").unMerge()

                    'Dim fxp As Double = 0 ' FX POSITION IN USD
                    'rd = DateSerial(Microsoft.VisualBasic.Right(Trim(xlWorksheet1.Range("H3").Value), 4), Mid(Trim(xlWorksheet1.Range("H3").Value), 57, 2), Mid(Trim(xlWorksheet1.Range("H3").Value), 54, 2)) 'DATUM DER FX POSITION
                    'rdsql = rd.ToString("yyyy-MM-dd")
                    'For i = 1 To 100
                    'If Trim(xlWorksheet1.Cells(i, 1).Value) = "Adjusted sum of net long / short position" Then
                    'fxp = xlWorksheet1.Cells(i, 7).Value
                    'End If
                    'Next i
                    Me.BgwODASimport.ReportProgress(3, "Find: Adjusted sum of net long / short position row and select value from Column 7")
                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")
                    Dim ef As ExcelFile = ExcelFile.Load(ExcelFileName)
                    Dim sheet As ExcelWorksheet
                    sheet = ef.Worksheets(0)
                    rdfx = DateSerial(Microsoft.VisualBasic.Right(sheet.Cells("A1").Value, 4), Mid(sheet.Cells("A1").Value, 4, 2), Microsoft.VisualBasic.Left(sheet.Cells("A1").Value, 2)) 'DATUM DER FX POSITION
                    rdsqlfx = rd.ToString("yyyy-MM-dd")
                    Dim fxp As Double = 0
                    For i = 0 To 100
                        If Trim(sheet.Cells(i, 0).Value) = "Adjusted sum of net long / short position" Then
                            fxp = sheet.Cells(i, 6).Value
                        End If
                    Next i



                    'EXCELL.Application.DisplayAlerts = False
                    'xlWorkBook.Close()
                    'EXCELL.Quit()
                    'EXCELL = Nothing
                    'Excel Instanz beenden
                    'Dim procs1() As Process = Process.GetProcessesByName("EXCEL")
                    'Dim i1 As Short
                    'i1 = 0
                    'For i1 = 0 To (procs1.Length - 1)
                    'procs1(i1).Kill()
                    'Next i1

                    Me.BgwODASimport.ReportProgress(4, "Insert FX POSITION to the RISK LIMIT DAILY CONTROL Table")
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsqlfx & "'"
                    Dim t As String = cmd.ExecuteScalar
                    If IsNothing(t) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Treasury FX position]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsqlfx & "'"
                        cmd.ExecuteScalar()
                    End If
                    If IsNothing(t) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsqlfx & "')"
                        cmd.ExecuteScalar()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Treasury FX position]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsqlfx & "'"
                        cmd.ExecuteScalar()
                    End If
                    Me.BgwODASimport.ReportProgress(100, "Import procedure: FX POSITION finished sucesfully")
                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: FX POSITION is not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub

    Private Sub ODAS_IMPORT_BILANZ_NONE_CPD_ACCOUNTS()
        Try

            Dim rd As Date
            Dim rd1 As Date
            Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "BILANZ(NONE CPD ACCOUNTS)"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='BILANZ(NONE CPD ACCOUNTS)' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then


                Me.BgwODASimport.ReportProgress(1, "Starting import:BILANZ(NONE CPD ACCOUNTS)")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\cs_d_2029-en.xlsx"
                ExcelFileName = OdasFileNewDirectory & "\cs_d_2029-en.xlsx"

                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(2, "Import:cs_d_2029-en.xlsx...Please wait...")

                    Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
                    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension

                    Dim Filename As String = System.IO.Path.GetFileName(ExcelFileName) 'NAME DER DATEI

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    'Unmerge Cells
                    xlWorksheet1.Columns("A:I").unMerge()

                    'Es wird nur Customer_Type=C aufsummiert alles andere wird auf 0 gesetzt
                    Me.BgwODASimport.ReportProgress(3, "Reformat Excel file: Set Euro Amount=0 if Customer_Type is not C or Customer Id=6783999 (Pauschalwertberichtigungen)")
                    Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                    For i = 3 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 5).Value) = "F" OrElse Trim(xlWorksheet1.Cells(i, 2).Value) = "67839999" Then
                            xlWorksheet1.Cells(i, 9).Value = 0
                        End If
                    Next i

                    'Datum des Reports
                    Me.BgwODASimport.ReportProgress(4, "Reformat Excel file: Insert Risk Date")
                    For i = 3 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If IsDate(Trim(xlWorksheet1.Cells(i, 1).Value)) = True Then
                            rd1 = xlWorksheet1.Cells(i, 1).Value
                        End If
                    Next i
                    rd = DateAdd(DateInterval.Day, -1, rd1)
                    rdsql = rd.ToString("yyyy-MM-dd")

                    ' Summe der Spalte I
                    Me.BgwODASimport.ReportProgress(5, "Reformat Excel file: Calculate sum of Column I")
                    Dim fxp As Double = 0
                    For i = 3 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        fxp += xlWorksheet1.Cells(i, 9).Value
                    Next i

                    'EINFÜGEN IN RISK LIMIT DAILY CONTROL
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar
                    If IsNothing(t) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Bank Bilanz]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If
                    If IsNothing(t) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                        cmd.ExecuteScalar()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Bank Bilanz]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11



                    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI 'Curent Culture-Problemlösung bei SQL SERVER 2012

                    Me.BgwODASimport.ReportProgress(100, "Import procedure:BILANZ(NONE CPD ACCOUNTS) is finished sucesfully")
                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: BILANZ(NONE CPD ACCOUNTS) is not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub

    Private Sub ODAS_IMPORT_CREDIT_RISK_MAK_REPORT()
        Try

            'Dim rd As Date
            'Dim rd1 As Date
            'Dim rdsql As String
            'Dim rdsql1 As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "CREDIT RISK AND MAK"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='CREDIT RISK AND MAK' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(1, "Start import procedure:CREDIT RISK AND MAK")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\credit_risk-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\credit_risk-en.xls"

                If File.Exists(ExcelFileName) = True Then


                    Me.BgwODASimport.ReportProgress(2, "Import:credit_risk-en.xls...Please wait...")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension

                    Dim Filename As String = System.IO.Path.GetFileName(ExcelFileName) 'NAME DER DATEI


                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")

                    EXCELL.Visible = False

                    xlWorksheet1.Range("H6").Value = "Contract Collateral ID"
                    xlWorksheet1.Range("N6").Value = "PD"
                    xlWorksheet1.Range("O6").Value = "(1-ER)"
                    'xlWorksheet1.Range("Q6").Value = "RiskDate"
                    'xlWorksheet1.Range("R6").Value = "RepDate"
                    xlWorksheet1.Columns("Q:R").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("I:I").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("B4").Value, 4), Mid(xlWorksheet1.Range("B4").Value, 11, 2), Mid(xlWorksheet1.Range("B4").Value, 8, 2))
                    'rdsql = rd.ToString("yyyy-MM-dd")

                    'Blatt 1 - Datumsformat einfügen für Report Date
                    'xlWorksheet1.Range("A2").NumberFormat = "yyyymmdd"
                    'rd1 = xlWorksheet1.Range("A2").Value

                    xlWorksheet1.Rows("1:5").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()

                    Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                    'Datum einfügen wo daten vorhanden sind
                    'Me.BgwODASimport.ReportProgress(3, "Reformat excel file: Input Risk Date")
                    'Dim i As Integer
                    'For i = 2 To 5000
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                    'If xlWorksheet1.Cells(i, 2).value <> "" Then 'Wenn Type nicht leer ist!
                    'xlWorksheet1.Cells(i, 17).Value = rd
                    'xlWorksheet1.Cells(i, 18).Value = rd1
                    'End If
                    'Next i

                    Me.BgwODASimport.ReportProgress(4, "Reformat excel file: Delete Rows with..Obligor Rate Subtotal, Percentage, Summary ")
                    For i = 3 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 1).value) = "Obligor Rate Subtotal" Then
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If Trim(xlWorksheet1.Cells(i, 1).value) = "Percentage" Then
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If Trim(xlWorksheet1.Cells(i, 1).value) = "Summary" Then
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next

                    'Obligor Rate
                    Me.BgwODASimport.ReportProgress(4, "Reformat excel file: Get Obligor Rate")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 1).value = "" And xlWorksheet1.Cells(i, 6).Value <> "" Then
                            xlWorksheet1.Cells(i, 1).value = xlWorksheet1.Cells(i - 1, 1).value
                        End If
                    Next

                    'Me.BgwODASimport.ReportProgress(4, "Reformat excel file: Delete Blanck Rows")
                    'For i = 2 To 5000
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                    'If Trim(xlWorksheet1.Cells(i, 2).value) = "" Then
                    'xlWorksheet1.Rows(i).Delete()
                    'End If
                    'If Trim(xlWorksheet1.Cells(i, 17).value) = "" Then
                    'xlWorksheet1.Rows(i).Delete()
                    'End If
                    'If Trim(xlWorksheet1.Cells(i, 6).value) = "" Then
                    'xlWorksheet1.Rows(i).Delete()
                    'End If
                    'Next


                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1

                    Me.BgwODASimport.ReportProgress(3, ExcelFileName & " " & "reformated succesfully")

                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwODASimport.ReportProgress(3, "Delete all previus Data from CREDIT RISK ALL DATA and MAK REPORT ALL DATA")
                    'Daten mit dem aktuellen rd datum löschen
                    'cmd.CommandText = "DELETE from [StressTestsLiveDetails] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE  FROM [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE  FROM [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE FROM [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE  FROM [CREDIT RISK] where [DateMakCrTotals]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE  FROM [CREDIT RISK ALL DATA] where [DateMakCrTotals]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE  FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE  FROM [MAK REPORT ALL DATA] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'cmd.CommandText = "DELETE FROM [MAK CR TOTALS] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    'Alte Daten im IMPORT DATATABLE löschen
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='IMPORT CREDIT RISK' AND xtype='U') CREATE TABLE [IMPORT CREDIT RISK]([ID] [int] IDENTITY(1,1) NOT NULL,[Obligor Rate] [nvarchar](255) NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Account Type] [nvarchar](255) NULL,[Counterparty/Issuer/Collateral Name] [nvarchar](255) NULL,[Client No] [nvarchar](255) NULL,[Contract Collateral ID] [nvarchar](255) NULL,[Maturity Date] [datetime] NULL,[Remaining Year(s) to Maturity] [float] NULL,[Org Ccy] [nvarchar](255) NULL,[Credit Outstanding (Org Ccy)] [float] NULL,[Credit Outstanding (EUR Equ)] [float] NULL,[PD] [float] NULL,[(1-ER)] [float] NULL,[Credit Risk Amount(EUR Equ)] [float] NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [IMPORT CREDIT RISK]"
                    cmd.ExecuteNonQuery()
                    '******************************************************
                    'Start SSIs
                    'Me.BgwODASimport.ReportProgress(4, "Start SSI for Import Credit Risk")
                    'pkg = app.LoadPackage(SSISDirectory & "CreditRisk.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(5, "SSI Result for CREDIT RISK import:" & pkgResults.ToString())
                    '*******************************************************
                    cmd.CommandText = "INSERT INTO [IMPORT CREDIT RISK]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)] FROM [Sheet1$] where [Org Ccy] is not NULL')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [IMPORT CREDIT RISK] SET [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(5, "CREDIT RISK imported sucessfully")

                    'Import in CREDIT RISK ALL DATA before deleting specific Data
                    'Me.BgwODASimport.ReportProgress(5, "Import in CREDIT RISK ALL DATA before deleting specific Data")
                    'cmd.CommandText = "Delete FROM [CREDIT RISK ALL DATA] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [CREDIT RISK ALL DATA]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[RiskDate],[DateMakCrTotals])Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[RiskDate],[RiskDate] FROM [IMPORT CREDIT RISK]"
                    cmd.ExecuteNonQuery()
                    'Import neue Client Nr in CUSTOMER RATINGS
                    Me.BgwODASimport.ReportProgress(6, "Import new Clients in CUSTOMER RATINGS")
                    cmd.CommandText = "INSERT INTO [CUSTOMER_RATING] ([ClientNo],[ClientName])Select distinct [Client No],[Counterparty/Issuer/Collateral Name] FROM [CREDIT RISK ALL DATA] B where B.[Client No] not in (Select [ClientNo] from [CUSTOMER_RATING]) and B.[Contract Type]<>'LIMIT' "
                    cmd.ExecuteNonQuery()
                    'löschen der IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [IMPORT CREDIT RISK]"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(6, "Import beendet:credit_risk-en.xls")

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If

                'MAK REPORT
                'ExcelFileName = Me.ODAS_Temp_Directory & "\mak-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\mak-en.xls"
                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(7, "Starte Import:mak-en.xls")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                    EXCELL.Visible = False

                    xlWorksheet1.Range("K7").Value = "Contract Collateral ID"
                    'xlWorksheet1.Range("R7").Value = "RiskDate"
                    'xlWorksheet1.Range("S7").Value = "RepDate"
                    'Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("B3").Value, "As of", "")), "-", "")


                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))
                    'rdsql = rd.ToString("yyyy-MM-dd")

                    xlWorksheet1.Range("A2").NumberFormat = "yyyymmdd"
                    'rd1 = xlWorksheet1.Range("A2").Value
                    'rdsql1 = rd1.ToString("yyyy-MM-dd")

                    xlWorksheet1.Columns("R:S").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("L:M").numberformat = "yyyymmdd"

                    'Rows delete
                    xlWorksheet1.Rows("1:6").delete()
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                    'Me.BgwODASimport.ReportProgress(7, "Reformat Excel File: Insert Risk Date")
                    'For i = 2 To 5000
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                    'If xlWorksheet1.Cells(i, 1).value <> "" Then 'Wenn Total Net Positions nicht leer ist!
                    'xlWorksheet1.Cells(i, 18).Value = rd
                    'xlWorksheet1.Cells(i, 19).Value = rd1
                    'End If
                    'Next i

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1

                    Me.BgwODASimport.ReportProgress(8, ExcelFileName & "  " & "reformated succesfully")


                    'Alte Daten im IMPORT DATATABLE löschen
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='IMPORT MAK REPORT' AND xtype='U') CREATE TABLE [dbo].[IMPORT MAK REPORT]([ID] [int] IDENTITY(1,1) NOT NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Account Type] [nvarchar](255) NULL,[Counterparty/Issuer/Collateral Provider] [nvarchar](255) NULL,[Client No] [nvarchar](255) NULL,[Country of Risk] [nvarchar](255) NULL,[Country of Residence] [nvarchar](255) NULL,[Industry(HO)] [nvarchar](255) NULL,[Client Group] [nvarchar](255) NULL,[Contract Collateral ID] [nvarchar](255) NULL,[Start Date] [datetime] NULL,[Maturity Date][datetime] NULL,[Org Ccy] [nvarchar](255) NULL,[Credit Exposure] [float] NULL,[Accrued Interest] [float] NULL,[Euro Equivalent] [float] NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [IMPORT MAK REPORT]"
                    cmd.ExecuteNonQuery()
                    '*****************************************
                    'Start Import via SSI
                    'Me.BgwODASimport.ReportProgress(9, "Start SSI for Import MAK Report")
                    'pkg = app.LoadPackage(SSISDirectory & "MAK.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(10, "SSI Result for MAK Report:" & pkgResults.ToString())
                    'Me.BgwODASimport.ReportProgress(10, "Import:mak-en.xls is finished")
                    '*****************************************
                    cmd.CommandText = "INSERT INTO [IMPORT MAK REPORT]([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent] FROM [Sheet1$] where [Org Ccy] is not NULL')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [IMPORT MAK REPORT] SET [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(10, "MAK REPORT imported sucessfully")

                    'Import in MAK REPORT ALL DATA before deleting specific Data
                    'Me.BgwODASimport.ReportProgress(5, "Import in MAK REPORT ALL DATA before deleting specific Data")
                    'cmd.CommandText = "Delete FROM [MAK REPORT ALL DATA] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [MAK REPORT ALL DATA]([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[DateMakCrTotals])Select [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RiskDate] FROM [IMPORT MAK REPORT]"
                    cmd.ExecuteNonQuery()
                    'löschen der MAK IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [IMPORT MAK REPORT]"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(100, "Import procedure:CREDIT RISK AND MAK finished sucesfully")

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: CREDIT RISK AND MAK is not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub ODAS_IMPORT_FRISTEN()
        Try

            'Dim rd As Date
            'Dim rd1 As Date
            'Dim rdsql As String
            'Dim rdsql1 As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT FRISTEN"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT FRISTEN' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwODASimport.ReportProgress(1, "Starte import:IMPORT FRISTEN")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\fristen_dtl-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\fristen_dtl-en.xls"


                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(2, "Import:fristen_dtl-en.xls...Bitte warten...")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension
                    Dim Filename As String = System.IO.Path.GetFileName(ExcelFileName) 'NAME DER DATEI
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                    EXCELL.Visible = False

                    xlWorksheet1.Range("B5").Value = "ContractType"
                    xlWorksheet1.Range("C5").Value = "ProductType"
                    xlWorksheet1.Range("D5").Value = "GL_Master_Account_Type"
                    xlWorksheet1.Range("E5").Value = "Contract"
                    xlWorksheet1.Range("F5").Value = "Counterparty_Name"
                    xlWorksheet1.Range("G5").Value = "Counterparty_No"
                    xlWorksheet1.Range("H5").Value = "TradeDate"
                    xlWorksheet1.Range("I5").Value = "StartDate"
                    xlWorksheet1.Range("J5").Value = "Final_Maturity_Date"
                    xlWorksheet1.Range("K5").Value = "Current_Interest_Rate"
                    xlWorksheet1.Range("L5").Value = "EventDate"
                    xlWorksheet1.Range("M5").Value = "EventType"
                    xlWorksheet1.Range("N5").Value = "MonthToEvent"
                    xlWorksheet1.Range("O5").Value = "YearToEvent"
                    xlWorksheet1.Range("P5").Value = "AmountType"
                    xlWorksheet1.Range("Q5").Value = "OrgCcy"
                    xlWorksheet1.Range("R5").Value = "OrgCcyAmount"
                    xlWorksheet1.Range("S5").Value = "EURequ"
                    'xlWorksheet1.Range("T5").Value = "RiskDate"
                    'xlWorksheet1.Range("U5").Value = "RepDate"
                    'xlWorksheet1.Columns("T:U").numberformat = "m/d/yyyy"


                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("B3").Value, 4), Mid(xlWorksheet1.Range("B3").Value, 11, 2), Mid(xlWorksheet1.Range("B3").Value, 8, 2))
                    'rdsql = rd.ToString("yyyy-MM-dd")
                    'Checking Date definieren
                    Dim CheckingDate As Date = DateAdd("m", 1, rd)
                    Dim CheckingDateSql As String
                    CheckingDate = DateSerial(CheckingDate.Year, CheckingDate.Month, CheckingDate.Day + 1) 'Plus einen Tag im Checking Date
                    CheckingDateSql = CheckingDate.ToString("yyyy-MM-dd")

                    Dim LastDayCurrentMonth As Date = DateSerial(rd.Year, rd.Month, 1).AddMonths(1).AddDays(-1)
                    Dim FirstDayOverNextMonth As Date = rd.AddDays((rd.Day - 1) * -1).AddMonths(2) ' Übernächstzer Monat
                    'Wenn Tagesdatum gleich datum des letzten Monatstages
                    If rd = LastDayCurrentMonth Then
                        CheckingDate = FirstDayOverNextMonth
                    End If

                    'Blatt 1 - Datumsformat einfügen für Report Date
                    xlWorksheet1.Range("A1").NumberFormat = "m/d/yyyy"
                    'rd1 = xlWorksheet1.Range("A1").Value
                    'rdsql1 = rd1.ToString("yyyy-MM-dd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    'xlWorksheet1.Columns("A:A").unMerge()

                    'Datum einfügen wo daten vorhanden sind
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX10))
                    'Me.BgwODASimport.ReportProgress(3, "Reformat Excel file: Insert Risk date")
                    'Dim i As Integer
                    'For i = 2 To 10000
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                    'If xlWorksheet1.Cells(i, 2).value <> "" Then 'Wenn Type nicht leer ist!
                    'xlWorksheet1.Cells(i, 20).Value = rd
                    'xlWorksheet1.Cells(i, 21).Value = rd1
                    'End If
                    'Next i

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1


                    'Vorhandene Daten löschen
                    cmd.CommandText = "DELETE  FROM [FRISTEN] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    'Daten Importieren
                    'Me.BgwODASimport.ReportProgress(4, "Start SSI for Import FRISTEN")
                    'pkg = app.LoadPackage(SSISDirectory & "FRISTEN.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(5, "SSI Result for FRISTEN import:" & pkgResults.ToString())
                    cmd.CommandText = "INSERT INTO [FRISTEN]([Class],[ContractType],[ProductType],[GL_Master_Account_Type],[Contract],[Counterparty_Name],[Counterparty_No],[TradeDate],[StartDate],[Final_Maturity_Date],[Current_Interest_Rate],[EventDate],[EventType],[AmountType],[MonthToEvent],[YearToEvent],[EURequ],[OrgCcy],[OrgCcyAmount],[RiskDate])SELECT [Class],[ContractType],[ProductType],[GL_Master_Account_Type],[Contract],[Counterparty_Name],[Counterparty_No],[TradeDate],[StartDate],[Final_Maturity_Date],[Current_Interest_Rate],[EventDate],[EventType],[AmountType],[MonthToEvent],[YearToEvent],[EURequ],[OrgCcy],[OrgCcyAmount],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Class],[ContractType],[ProductType],[GL_Master_Account_Type],[Contract],[Counterparty_Name],[Counterparty_No],[TradeDate],[StartDate],[Final_Maturity_Date],[Current_Interest_Rate],[EventDate],[EventType],[AmountType],[MonthToEvent],[YearToEvent],[EURequ],[OrgCcy],[OrgCcyAmount] FROM [Sheet1$] where [OrgCcy] is not NULL')"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(5, "FRISTEN imported sucessfully")
                    Me.BgwODASimport.ReportProgress(100, "Import procedure: FRISTEN IMPORT finished sucesfully")

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: FRISTEN IMPORT is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub

    Private Sub ODAS_IMPORT_ACCRUED_INTEREST_ANALYSIS()
        Try

            'Dim rd As Date
            Dim rd1 As Date
            'Dim rdsql As String
            Dim rdsql1 As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT ACCRUED INTEREST ANALYSIS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='ACCRUED INTEREST ANALYSIS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(1, "Start import:ACCRUED INTEREST ANALYSIS")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\acc_int_analysis-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\acc_int_analysis-en.xls"

                If File.Exists(ExcelFileName) = True Then
                    Me.BgwODASimport.ReportProgress(2, "Import:acc_int_analysis-en.xls...Please wait...")
                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                    EXCELL.Visible = False

                    xlWorksheet1.Range("E6").Value = "Contract"
                    xlWorksheet1.Range("O6").Value = "Current Interest Coupon Period Start Date"
                    xlWorksheet1.Range("P6").Value = "Current Interest Coupon Period End Date"
                    xlWorksheet1.Range("Q6").Value = "Accrued Interest Coupon Org Ccy"
                    xlWorksheet1.Range("R6").Value = "Accrued Interest Coupon EUR Equ"
                    xlWorksheet1.Range("S6").Value = "Interest Coupon amount Org Ccy"
                    xlWorksheet1.Range("T6").Value = "Interest Coupon Amount EUR Equ"

                    xlWorksheet1.Range("U6").Value = "RiskDate"
                    xlWorksheet1.Range("V6").Value = "RepDate"
                    xlWorksheet1.Range("W6").Value = "RepMonth"
                    xlWorksheet1.Range("X6").Value = "CheckingDate"
                    xlWorksheet1.Columns("U:V").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("W:W").numberformat = "yyyymm"
                    xlWorksheet1.Columns("X:X").numberformat = "yyyymmdd"

                    Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("B3").Value, "As of", "")), "-", "")
                    Me.BgwODASimport.ReportProgress(3, "Define Checking Date")
                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))
                    'rdsql = rd.ToString("yyyy-MM-dd")
                    'report Date definieren
                    xlWorksheet1.Range("A1").NumberFormat = "yyyymmdd"
                    rd1 = xlWorksheet1.Range("A1").Value
                    rdsql1 = rd1.ToString("yyyy-MM-dd")
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Reporting Month definieren (Data Date und Report Date)
                    Dim MeldeMonat As Date
                    Dim MeldeMonatSingle As String = ""
                    Dim MeldeMonatName As String = ""

                    If rd.ToString("MM.yyyy") <> rd1.ToString("MM.yyyy") Then
                        MeldeMonat = rd1.ToString("MM.yyyy")
                        MeldeMonatSingle = rd1.ToString("MM")
                        MeldeMonatName = rd1.ToString("MMMM yyyy")
                    ElseIf rd.ToString("MM.yyyy") = rd1.ToString("MM.yyyy") Then
                        MeldeMonat = rd.ToString("MM.yyyy")
                        MeldeMonatSingle = rd.ToString("MM")
                        MeldeMonatName = rd.ToString("MMMM yyyy")
                    End If
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Checking Date definieren
                    Dim CheckingDate As Date
                    Select Case MeldeMonatSingle
                        Case "01"
                            CheckingDate = "01.02." & rd.ToString("yyyy")
                        Case "02"
                            CheckingDate = "01.03." & rd.ToString("yyyy")
                        Case "03"
                            CheckingDate = "01.04." & rd.ToString("yyyy")
                        Case "04"
                            CheckingDate = "01.05." & rd.ToString("yyyy")
                        Case "05"
                            CheckingDate = "01.06." & rd.ToString("yyyy")
                        Case "06"
                            CheckingDate = "01.07." & rd.ToString("yyyy")
                        Case "07"
                            CheckingDate = "01.08." & rd.ToString("yyyy")
                        Case "08"
                            CheckingDate = "01.09." & rd.ToString("yyyy")
                        Case "09"
                            CheckingDate = "01.10." & rd.ToString("yyyy")
                        Case "10"
                            CheckingDate = "01.11." & rd.ToString("yyyy")
                        Case "11"
                            CheckingDate = "01.12." & rd.ToString("yyyy")
                        Case "12"
                            Dim rdny As Date = DateAdd(DateInterval.Year, 1, rd)
                            CheckingDate = "01.01." & rdny.ToString("yyyy")
                    End Select
                    Me.BgwODASimport.ReportProgress(4, "Checking Date defined: " & "  " & CheckingDate)

                    xlWorksheet1.Columns("H:J").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("O:P").numberformat = "yyyymmdd"
                    'Rows delete
                    xlWorksheet1.Rows("1:5").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()


                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwODASimport.ReportProgress(5, "Insert Risk Date, Report Date, MeldeMonat and Checking Date in Excel File")
                    Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                    'Dim i As Integer
                    For Me.ex = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(ex, 2).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(ex, 21).Value = rd
                            xlWorksheet1.Cells(ex, 22).Value = rd1
                            xlWorksheet1.Cells(ex, 23).Value = MeldeMonat
                            xlWorksheet1.Cells(ex, 24).Value = CheckingDate
                        Else
                            xlWorksheet1.Rows(ex).Delete()
                        End If
                    Next ex

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1


                    'Alte Daten im IMPORT DATATABLE löschen
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='IMPORT ACCRUED INTEREST' AND xtype='U') CREATE TABLE [dbo].[IMPORT ACCRUED INTEREST]([ID] [int] IDENTITY(1,1) NOT NULL,[Class] [nvarchar](255) NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[Counterparty Name] [nvarchar](255) NULL,[Counterparty No] [nvarchar](255) NULL,[Trade Date][datetime] NULL,[Start Date][datetime] NULL,[Final Maturity Date][datetime] NULL,[Org Ccy] [nvarchar](255) NULL,[Principal (Org  Ccy)] [float] NULL,[Principal (EUR Equivalent)] [float] NULL,[Current Interest Rate] [float] NULL,[Current Interest Coupon Period Start Date][datetime] NULL,[Current Interest Coupon Period End Date][datetime] NULL,[Accrued Interest Coupon Org Ccy] [float] NULL,[Accrued Interest Coupon EUR Equ] [float] NULL,[Interest Coupon amount Org Ccy] [float] NULL,[Interest Coupon Amount EUR Equ] [float] NULL,[Riskdate][datetime] NULL,[RepDate] [datetime] NULL,[RepMonth] [datetime] NULL,[CheckingDate] [datetime] NULL) ELSE DELETE FROM [IMPORT ACCRUED INTEREST]"
                    cmd.ExecuteNonQuery()
                    '******************************************************

                    'Start SSIs
                    'Me.BgwODASimport.ReportProgress(6, "Start SSI for Import ACCRUED INTEREST ANALYSIS")
                    'pkg = app.LoadPackage(SSISDirectory & "AccruedInterestAnalysis.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(7, "SSI Result for ACCRUED INTEREST ANALYSIS import:" & pkgResults.ToString())
                    '*******************************************************
                    cmd.CommandText = "INSERT INTO [IMPORT ACCRUED INTEREST]  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[RepMonth],[CheckingDate] FROM [Sheet1$]')"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(7, "ACCRUED INTEREST imported sucessfully")

                    'Import Accrued Interest to ACCRUED INTEREST ANALYSIS Table
                    cmd.CommandText = "INSERT INTO [ACCRUED INTEREST ANALYSIS]  SELECT  [Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate] FROM [IMPORT ACCRUED INTEREST] where [IMPORT ACCRUED INTEREST].[Riskdate] not in (Select [Datadate] from [ACCRUED INTEREST ANALYSIS])"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(7, "ACCRUED INTEREST  imported sucessfully in Table ACCRUED INTEREST ANALYSIS")

                    'Update MAK REPORT with the Accrued Interests
                    cmd.CommandText = "UPDATE A set A.[Accrued Interest]=B.[Accrued Interest Coupon EUR Equ] from [MAK REPORT ALL DATA] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[Contract Collateral ID]=B.[Contract] where A.[RiskDate]=B.[Datadate] and B.[Datadate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [MAK REPORT ALL DATA] SET [Accrued Interest]=0 where [Accrued Interest] is NULL and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    '***********************************************************************
                    'SECURITIES TEST CODE
                    'Me.BgwODASimport.ReportProgress(7, "Import to SECURITIES INTEREST")
                    'cmd.CommandText = "INSERT INTO [dbo].[SECURITIES INTEREST]([Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate]) Select [Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate] FROM [IMPORT ACCRUED INTEREST] where [Contract Type]='SECUR'"
                    'cmd.ExecuteNonQuery()
                    '***********************************************************************

                    'Importierte Daten wenn Contract Type=SECUR löschen+++KEINE ZINSEN aus SECURITIES in Z14/Z15
                    Me.BgwODASimport.ReportProgress(6, "Delete Securities (SECUR) from the imported Data")
                    cmd.CommandText = "DELETE  FROM [IMPORT ACCRUED INTEREST] Where [Contract Type]='SECUR'"
                    cmd.ExecuteNonQuery()
                    'Prüfen ob daten vorhanden sind
                    Me.BgwODASimport.ReportProgress(6, "Checking if data allready imported to Table")
                    cmd.CommandText = "SELECT distinct [AIARasof] FROM [AWVz1415RelevantData] Where [AIARasof]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                        Me.BgwODASimport.ReportProgress(6, "Data allready are imported to Table - No further action will be executed")
                    Else
                        Me.BgwODASimport.ReportProgress(8, "Insert Data in AWVz1415RelevantData Table")
                        If rd.ToString("MM.yyyy") <> rd1.ToString("MM.yyyy") Then
                            'Neuanlage in AWV z1415 Relevant Data
                            cmd.CommandText = "INSERT INTO [AWVz1415RelevantData]([Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Interest Coupon Amount EUR Equ],[AIARasof],[AIARrepdate],[CheckingDate],[IdZ14Z15Meldemonat])Select [Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[CheckingDate],[RepMonth] FROM [IMPORT ACCRUED INTEREST] where [Current Interest Coupon Period End Date]<[CheckingDate]"
                            cmd.ExecuteNonQuery()
                        ElseIf rd.ToString("MM.yyyy") = rd1.ToString("MM.yyyy") Then
                            cmd.CommandText = "INSERT INTO [AWVz1415RelevantData]([Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Interest Coupon Amount EUR Equ],[AIARasof],[AIARrepdate],[CheckingDate],[IdZ14Z15Meldemonat])Select [Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[CheckingDate],[RepMonth] FROM [IMPORT ACCRUED INTEREST] where [Current Interest Coupon Period End Date]<[CheckingDate] and [Contract] not in (Select [Contract] from [AWVz1415RelevantData])"
                            cmd.ExecuteNonQuery()
                        End If

                        '##############################################################
                        Me.BgwODASimport.ReportProgress(9, "Matching Country Codes with Customers Info Table")
                        'MATCHING DER LÄNDERCODES MIT CLIENT LIST
                        cmd.CommandText = "UPDATE [AWVz1415RelevantData] SET [CountryCode]=B.[COUNTRY_OF_RESIDENCE] from [AWVz1415RelevantData] A INNER JOIN [CUSTOMER_INFO] B ON A.[Counterparty No]=B.[ClientNo] where A.[AIARasof]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                        '#######################################################################################
                        'N/A wenn kein Land angezeigt ist
                        cmd.CommandText = "UPDATE [AWVz1415RelevantData] SET [CountryCode]='N/A' where [CountryCode] is NULL"
                        cmd.ExecuteNonQuery()
                        'Prüfen ob daten vorhanden sind
                        Dim MeldeMonatSql As String = MeldeMonat.ToString("yyyy-MM-dd")
                        cmd.CommandText = "SELECT distinct [Z14Z15MeldeMonat] FROM [AWVz14z15] Where [Z14Z15MeldeMonat]='" & MeldeMonatSql & "'"
                        Dim t1 As String = cmd.ExecuteScalar()

                        If IsNothing(t1) = True Then
                            Me.BgwODASimport.ReportProgress(10, "Insert into AWVz14 Table")
                            'Neuanlage in ACCRUED INTEREST
                            cmd.CommandText = "INSERT INTO [AWVz14z15]([Z14Z15MeldeMonat],[Z14Z15MeldeMonatName],[USER],[IdBank]) Values('" & MeldeMonatSql & "','" & MeldeMonatName & "','" & "imported from " & " " & SystemInformation.UserName & " on " & " " & Today & "','3') "
                            cmd.ExecuteNonQuery()
                            '######################################################################################################
                            'Füllen der Z14
                            'Länder und Währungen
                            cmd.CommandText = "INSERT INTO [AWVz14]([COUNTRY CODE],[COUNTRY NAME],[LANDKZ],[COUNTRY NAME DE])Select[COUNTRY CODE],[COUNTRY NAME],[LANDKZ BUBA],[COUNTRY NAME DE]FROM [COUNTRIES]"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [AWVz14] SET [CLASS]='ASSETS',[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' where [IdZ14Z15Meldemonat] is NULL"
                            cmd.ExecuteNonQuery()

                            Me.QueryText = "select * from [AWVz14]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                cmd.ExecuteNonQuery()
                            Next

                            '######################################################################################################
                            'Füllen der Z15
                            'Länder und Währungen
                            Me.BgwODASimport.ReportProgress(11, "Insert into AWVz15 Table")
                            cmd.CommandText = "INSERT INTO [AWVz15]([COUNTRY CODE],[COUNTRY NAME],[LANDKZ],[COUNTRY NAME DE])Select[COUNTRY CODE],[COUNTRY NAME],[LANDKZ BUBA],[COUNTRY NAME DE]FROM [COUNTRIES]"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [AWVz15] SET [CLASS]='LIABILITIES',[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' where [IdZ14Z15Meldemonat] is NULL"
                            cmd.ExecuteNonQuery()

                            Me.QueryText = "select * from [AWVz15]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                cmd.ExecuteNonQuery()
                            Next
                            '######################################################################################################

                        Else
                            'Summen für AZW Z14 und Z15 auf NULL Stellen
                            Me.BgwODASimport.ReportProgress(12, "Set CountrySumAmount to zero")
                            cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' "
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' "
                            cmd.ExecuteNonQuery()

                            'Berechnen SUMME AWVz14
                            Me.BgwODASimport.ReportProgress(13, "Re-Insert into AWVz14 Table")
                            Me.QueryText = "select * from [AWVz14]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                cmd.ExecuteNonQuery()
                            Next

                            'Berechnen SUMME AWVz15
                            Me.BgwODASimport.ReportProgress(14, "Re-Insert into AWVz15 Table")
                            Me.QueryText = "select * from [AWVz15]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                cmd.ExecuteNonQuery()
                            Next
                        End If
                    End If

                    'löschen der IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [IMPORT ACCRUED INTEREST]"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(100, "Import procedure:IMPORT ACCRUED INTEREST ANALYSIS finished sucesfully")
                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: ACCRUED INTEREST ANALYSIS ist not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub ODAS_IMPORT_FOREIGN_EXCHANGE_DAILY_REVALUATION()
        Try

            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "FX DAILY REVALUATION"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='FX DAILY REVALUATION' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(1, "Start import procedure:FX DAILY REVALUATION")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\ts_d_1047-en.xlsx"
                ExcelFileName = OdasFileNewDirectory & "\ts_d_1047-en.xlsx"

                If File.Exists(ExcelFileName) = True Then


                    Me.BgwODASimport.ReportProgress(2, "Import:ts_d_1047-en.xlsx...Please wait...")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension

                    Dim Filename As String = System.IO.Path.GetFileName(ExcelFileName) 'NAME DER DATEI

                    'Culture Ändern
                    'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
                    'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)

                    EXCELL.Visible = False


                    'Risk Date definieren
                    'Dim ExtractDate As String = Microsoft.VisualBasic.Right(xlWorksheet1.Range("I3").Value, 10)
                    'rd = DateSerial(Microsoft.VisualBasic.Right(ExtractDate, 4), Mid(ExtractDate, 4, 2), Microsoft.VisualBasic.Left(ExtractDate, 2))
                    'rdsql = rd.ToString("yyyy-MM-dd")

                    'Unmerge Cells
                    xlWorksheet1.Columns("A:P").unMerge()
                    xlWorksheet1.Rows("1:4").delete()


                    xlWorksheet1.Range("B3").Value = "Contract Type"
                    xlWorksheet1.Range("C3").Value = "Product Type"
                    xlWorksheet1.Range("D3").Value = "InputDate"
                    xlWorksheet1.Range("E3").Value = "Val Date/Mat Date"
                    xlWorksheet1.Range("G3").Value = "Buy CCY/Sell CCY"
                    xlWorksheet1.Range("H3").Value = "Buy Amount/Sell Amount"
                    xlWorksheet1.Range("I3").Value = "Exchange Rate"
                    xlWorksheet1.Range("J3").Value = "Reval Buy Rate/Reval Sell rate"
                    xlWorksheet1.Range("K3").Value = "Reval Buy Amount/Reval Sell Amount"
                    xlWorksheet1.Range("L3").Value = "PL EUR"
                    xlWorksheet1.Range("M3").Value = "PL in EUR Equ"
                    xlWorksheet1.Range("N3").Value = "NPV Discount Rate"
                    xlWorksheet1.Range("P3").Value = "Type"
                    'xlWorksheet1.Columns("Q:R").numberformat = "yyyymmdd"
                    'xlWorksheet1.Columns("I:I").numberformat = "yyyymmdd"

                    'Blatt 1 - Datumsformat einfügen für Report Date
                    'xlWorksheet1.Range("A2").NumberFormat = "yyyymmdd"
                    'rd1 = xlWorksheet1.Range("A2").Value
                    xlWorksheet1.Rows("1:2").delete()

                    xlWorksheet1.Columns("K:K").numberformat = "#,##0.00"

                    Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                    Dim i As Integer
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 2).value) = "GLBL" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Cells with Value:Unrealized and Realized ")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 13).value) = "Unrealized" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                        If Trim(xlWorksheet1.Cells(i, 15).value) = "Realized" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next

                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Cells with Containing Value:Subtotal ")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 10).value).Contains("Subtotal").ToString = True Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "DeleteRows if  Cells with Value:Subtotal :")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 10).value) = "Subtotal :" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Cells end with Value:P/L :")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 10).value).EndsWith("P/L :").ToString = True Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Cells with Value:Dealer P/L :")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 10).value) = "Dealer P/L :" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Cells with Value://")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 5).value) = "/ /" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Column E Cells with Value://")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        Dim Test As String = xlWorksheet1.Cells(i, 5).value
                        If Test = "/ /" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next

                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Column J Cells are not numeric")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If IsNumeric(xlWorksheet1.Cells(i, 10).value) = False Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Rerun command:Delete Cells if Column J Cells are not numeric")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If IsNumeric(xlWorksheet1.Cells(i, 10).value) = False Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Cells with Value ContractNo")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 1).value = "Contractno" Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Column G Cells are  numeric")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If IsNumeric(xlWorksheet1.Cells(i, 7).value) = True Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Column K Cells are not  numeric")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If IsNumeric(xlWorksheet1.Cells(i, 11).value) = False Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Rerun command: Delete Rows if Column K Cells are not  numeric")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If IsNumeric(xlWorksheet1.Cells(i, 11).value) = False Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next
                    Me.BgwODASimport.ReportProgress(4, "Delete Rows if Column K Cells are equal 0")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 11).value = 0 Then
                            xlWorksheet1.Rows(i).EntireRow.Delete()
                        End If
                    Next


                    Me.BgwODASimport.ReportProgress(4, "Convert to Date from Format dd/MM/yyyy to dd.MM.yyyy - Column E")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 8).value <> 0 Then
                            Dim CheckString As String = xlWorksheet1.Cells(i, 5).value
                            If CheckString.Contains("/") = True Then
                                Dim ConvertedDate As Date = DateSerial(Microsoft.VisualBasic.Right(CheckString, 4), Microsoft.VisualBasic.Mid(CheckString, 4, 2), Microsoft.VisualBasic.Left(CheckString, 2))
                                xlWorksheet1.Cells(i, 5).value = ConvertedDate
                            End If
                        End If
                    Next

                    Me.BgwODASimport.ReportProgress(4, "Change and Add column Names")
                    xlWorksheet1.Range("A1").Value = "ContractNr"
                    xlWorksheet1.Range("B1").Value = "ContractType"
                    xlWorksheet1.Range("C1").Value = "ProductType"
                    xlWorksheet1.Columns("F:F").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                    xlWorksheet1.Range("E1").Value = "ValueDate"
                    xlWorksheet1.Range("F1").Value = "MaturityDate"
                    xlWorksheet1.Range("G1").Value = "DealSellBuy"
                    xlWorksheet1.Columns("I:I").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                    xlWorksheet1.Range("H1").Value = "BuyCCY"
                    xlWorksheet1.Range("I1").Value = "SellCCY"
                    xlWorksheet1.Columns("K:K").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                    xlWorksheet1.Range("J1").Value = "BuyAmount"
                    xlWorksheet1.Range("K1").Value = "SellAmount"
                    xlWorksheet1.Columns("N:N").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                    xlWorksheet1.Range("M1").Value = "RevalBuyRate"
                    xlWorksheet1.Range("N1").Value = "RevalSellRate"
                    xlWorksheet1.Columns("P:P").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                    xlWorksheet1.Range("O1").Value = "RevalBuyAmount"
                    xlWorksheet1.Range("P1").Value = "RevalSellAmount"
                    xlWorksheet1.Range("Q1").Value = "PL_EUR"
                    xlWorksheet1.Range("R1").Value = "PL_inEUR_Equ"
                    xlWorksheet1.Range("S1").Value = "NPV"
                    xlWorksheet1.Columns("T:T").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                    xlWorksheet1.Range("T1").Value = "DiscountRate"
                    xlWorksheet1.Range("U1").Value = "DealStatus"
                    xlWorksheet1.Range("V1").Value = "DealType"
                    xlWorksheet1.Range("W1").Value = "RiskDate"



                    Me.BgwODASimport.ReportProgress(4, "Insert from Cell under")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 4).value <> "" Then
                            'Insert Maturity Date
                            xlWorksheet1.Cells(i, 6).value = xlWorksheet1.Cells(i + 1, 5).value
                            'Insert Sell Currency
                            xlWorksheet1.Cells(i, 9).value = xlWorksheet1.Cells(i + 1, 8).value
                            'Insert Sell Amount
                            xlWorksheet1.Cells(i, 11).value = xlWorksheet1.Cells(i + 1, 10).value
                            'Insert RevalCellRate
                            xlWorksheet1.Cells(i, 14).value = xlWorksheet1.Cells(i + 1, 13).value
                            'Insert RevalCellAmount
                            xlWorksheet1.Cells(i, 16).value = xlWorksheet1.Cells(i + 1, 15).value
                            'Insert Discount Rate
                            xlWorksheet1.Cells(i, 20).value = xlWorksheet1.Cells(i + 1, 19).value
                            xlWorksheet1.Rows(i + 1).delete()
                        End If
                    Next




                    Me.BgwODASimport.ReportProgress(4, "Convert to Date from Format dd/MM/yyyy to dd.MM.yyyy - Column D")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 4).value <> "" Then
                            Dim CheckStringInputDate As String = xlWorksheet1.Cells(i, 4).value
                            If CheckStringInputDate.Contains("/") = True Then
                                Dim ConvertedDateInputDate As Date = DateSerial(Microsoft.VisualBasic.Right(CheckStringInputDate, 4), Microsoft.VisualBasic.Mid(CheckStringInputDate, 4, 2), Microsoft.VisualBasic.Left(CheckStringInputDate, 2))
                                xlWorksheet1.Cells(i, 4).value = ConvertedDateInputDate
                            End If
                        End If
                    Next



                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwODASimport.ReportProgress(4, "Reformat excel file: Input Risk Date")
                    For i = 2 To 5000
                        Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                        If xlWorksheet1.Cells(i, 8).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 23).Value = rd
                        End If
                    Next i

                    xlWorksheet1.Columns("D:F").numberformat = "yyyyMMdd"
                    xlWorksheet1.Columns("W:W").numberformat = "yyyyMMdd"
                    'Change Worksheet Name from Chinese to English
                    Me.BgwODASimport.ReportProgress(4, "Rename excel Sheet in: FxDailyReval")
                    xlWorksheet1.Name = "FxDailyReval"



                    Dim ExcelFileNameNew As String = ""
                    'ExcelFileNameNew = Me.ODAS_Temp_Directory & "\ts_d_1047-en.xls"
                    ExcelFileNameNew = OdasFileNewDirectory & "\ts_d_1047-en.xls"
                    Me.BgwODASimport.ReportProgress(4, "Save excel Sheet as: " & ExcelFileNameNew)

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1

                    'System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='IMPORT FX DAILY REVALUATION' AND xtype='U') CREATE TABLE [IMPORT FX DAILY REVALUATION]([ID] [int] IDENTITY(1,1) NOT NULL,[ContractNr] [nvarchar](255) NULL,[ContractType] [nvarchar](255) NULL,[ProductType] [nvarchar](255) NULL,[InputDate] [datetime] NULL,[ValueDate] [datetime] NULL,[MaturityDate] [datetime] NULL,[DealSellBuy] [nvarchar](255) NULL,[BuyCCY] [nvarchar](255) NULL,[BuyAmount] [float] NULL,[SellCCY] [nvarchar](255) NULL,[SellAmount] [float] NULL,[Exchange Rate] [float] NULL,[RevalBuyRate] [float] NULL,[RevalSellRate] [float] NULL,[RevalBuyAmount] [float] NULL,[RevalSellAmount] [float] NULL,[PL_EUR] [float] NULL,[PL_inEUR_Equ] [float] NULL,[NPV] [float] NULL,[DiscountRate] [float] NULL,[DealStatus] [nvarchar](255) NULL,[DealType] [nvarchar](255) NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [IMPORT FX DAILY REVALUATION]"
                    cmd.ExecuteNonQuery()
                    '******************************************************

                    cmd.CommandText = "INSERT INTO [IMPORT FX DAILY REVALUATION]([ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate] FROM [FxDailyReval$]')"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(5, "FX DAILY REVALUATION imported in Temporary Table")

                    'Me.BgwODASimport.ReportProgress(6, "DELETE FROM IMPORT FX DAILY REVALUATION where Deal Type is not FW and SW")
                    'cmd.CommandText = "DELETE FROM [IMPORT FX DAILY REVALUATION] WHERE [DealType] not in ('FW', 'SW')"
                    'cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(7, "Delete all previus Data for the same Date")
                    'Daten mit dem aktuellen rd datum löschen
                    cmd.CommandText = "DELETE from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(8, "Insert into FX DAILY REVALUATION")
                    cmd.CommandText = "INSERT INTO [FX DAILY REVALUATION]([ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate])Select [ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate] FROM [IMPORT FX DAILY REVALUATION]"
                    cmd.ExecuteNonQuery()

                    'löschen der IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [IMPORT FX DAILY REVALUATION]"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(9, "Match Client Nr and Client Name from Contract Nr in FX DAILY REVALUATION")
                    cmd.CommandText = "UPDATE A set A.[ClientNo]=B.[ClientNo] , A.[ClientName]=B.[ClientName],A.[MatchingContractNr]=B.[MatchingContractNr] FROM [FX DAILY REVALUATION] A INNER JOIN [FX DAILY REVALUATION] B ON A.[ContractNr]=B.[ContractNr] where A.[ClientNo] is NULL "
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(9, "Match Client Nr and Client Name from Contract Nr in CREDIT RISK ALL DATA REPORT")
                    cmd.CommandText = "UPDATE A set A.[ClientNo]=B.[Client No] , A.[ClientName]=B.[Counterparty/Issuer/Collateral Name] FROM [FX DAILY REVALUATION] A INNER JOIN [CREDIT RISK ALL DATA] B ON A.[ContractNr]=B.[Contract Collateral ID] where A.[ClientNo] is NULL"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(9, "Match Client Nr and Client Name from Contract in FRISTEN REPORT")
                    cmd.CommandText = "UPDATE A set A.[ClientNo]=B.[Counterparty_No] , A.[ClientName]=B.[Counterparty_Name] FROM [FX DAILY REVALUATION] A INNER JOIN [FRISTEN] B ON A.[ContractNr]=B.[Contract] where A.[ClientNo] is NULL"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(9, "Match Client Nr and Client Name from Contract in FX ALL")
                    cmd.CommandText = "UPDATE A set A.[ClientNo]=B.[OCBS_CI_NO] , A.[ClientName]=B.[ClientName] FROM [FX DAILY REVALUATION] A INNER JOIN [FX ALL] B ON A.[ContractNr]=B.[ContractNo] where A.[ClientNo] is NULL"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(9, "Update OwnDeal based on the data from previous Dates")
                    cmd.CommandText = "UPDATE A SET A.[OwnDeal] = 'Y' FROM [FX DAILY REVALUATION] A INNER JOIN (Select [ContractNr] from [FX DAILY REVALUATION] where [OwnDeal]='Y' and [RiskDate]<'" & rdsql & "') B ON A.[ContractNr] = B.ContractNr AND A.[DealStatus]='U' and A.[OwnDeal] = 'N' and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
                Me.BgwODASimport.ReportProgress(100, "Import procedure:FX DAILY REVALUATION finished sucesfully")

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: FX DAILY REVALUATION ist not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub
    Private Sub MATCHING_FX_DEALS()
        Dim rdsql As String = "" 'Default
        '***************MATURITY DATE*******************
        '****************************************************************************************
        Me.BgwODASimport.ReportProgress(10, "Match Deals if DealSellBuy is S based on maturity Date")
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=15 and [DealSellBuy]='S' and [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=7 and [DealSellBuy]='B' and [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)

        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim DealSellBuyS As String = dt.Rows.Item(i).Item("DealSellBuy")
            Dim MaturityDateS As String = dt.Rows.Item(i).Item("MaturityDate")
            Dim BuyCurS As String = dt.Rows.Item(i).Item("BuyCCY")
            Dim SellCurS As String = dt.Rows.Item(i).Item("SellCCY")
            For y = 0 To dt1.Rows.Count - 1
                Dim ContractNr As String = dt1.Rows.Item(y).Item("ContractNr")
                Dim DealSellBuyB As String = dt1.Rows.Item(y).Item("DealSellBuy")
                Dim MaturityDateB As String = dt1.Rows.Item(y).Item("MaturityDate")
                Dim BuyCurB As String = dt1.Rows.Item(y).Item("BuyCCY")
                Dim SellCurB As String = dt1.Rows.Item(y).Item("SellCCY")
                If MaturityDateS = MaturityDateB And BuyCurS = SellCurB And SellCurS = BuyCurB Then
                    cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [MatchingContractNr]='" & ContractNr & "' where [ID]='" & ID & "' and [MatchingContractNr] is NULL"
                    cmd.ExecuteNonQuery()
                End If
            Next
        Next
        '*******************************************************************************************
        '****************************************************************************************
        Me.BgwODASimport.ReportProgress(20, "Match Deals if DealSellBuy is B based on maturity Date")
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=15 and [DealSellBuy]='B' and [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=7 and [DealSellBuy]='S' and [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)

        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim DealSellBuyS As String = dt.Rows.Item(i).Item("DealSellBuy")
            Dim MaturityDateS As String = dt.Rows.Item(i).Item("MaturityDate")
            Dim BuyCurS As String = dt.Rows.Item(i).Item("BuyCCY")
            Dim SellCurS As String = dt.Rows.Item(i).Item("SellCCY")
            For y = 0 To dt1.Rows.Count - 1
                Dim ContractNr As String = dt1.Rows.Item(y).Item("ContractNr")
                Dim DealSellBuyB As String = dt1.Rows.Item(y).Item("DealSellBuy")
                Dim MaturityDateB As String = dt1.Rows.Item(y).Item("MaturityDate")
                Dim BuyCurB As String = dt1.Rows.Item(y).Item("BuyCCY")
                Dim SellCurB As String = dt1.Rows.Item(y).Item("SellCCY")
                If MaturityDateS = MaturityDateB And BuyCurS = SellCurB And SellCurS = BuyCurB Then
                    cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [MatchingContractNr]='" & ContractNr & "' where [ID]='" & ID & "' and [MatchingContractNr] is NULL"
                    cmd.ExecuteNonQuery()
                End If
            Next
        Next
        '*******************************************************************************************

        '**************INPUT DATE*********************************************
        '****************************************************************************************
        Me.BgwODASimport.ReportProgress(10, "Match Deals if DealSellBuy is S based on Input Date")
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=15 and [DealSellBuy]='S' and [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=7 and [DealSellBuy]='B' and [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)

        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim DealSellBuyS As String = dt.Rows.Item(i).Item("DealSellBuy")
            Dim InputDateS As String = dt.Rows.Item(i).Item("InputDate")
            Dim BuyCurS As String = dt.Rows.Item(i).Item("BuyCCY")
            Dim SellCurS As String = dt.Rows.Item(i).Item("SellCCY")
            For y = 0 To dt1.Rows.Count - 1
                Dim ContractNr As String = dt1.Rows.Item(y).Item("ContractNr")
                Dim DealSellBuyB As String = dt1.Rows.Item(y).Item("DealSellBuy")
                Dim InputDateB As String = dt1.Rows.Item(y).Item("InputDate")
                Dim BuyCurB As String = dt1.Rows.Item(y).Item("BuyCCY")
                Dim SellCurB As String = dt1.Rows.Item(y).Item("SellCCY")
                If InputDateS = InputDateB And BuyCurS = SellCurB And SellCurS = BuyCurB Then
                    cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [MatchingContractNr]='" & ContractNr & "' where [ID]='" & ID & "' and [MatchingContractNr] is NULL"
                    cmd.ExecuteNonQuery()
                End If
            Next
        Next
        '*******************************************************************************************
        '****************************************************************************************
        Me.BgwODASimport.ReportProgress(20, "Match Deals if DealSellBuy is B based on Input Date")
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=15 and [DealSellBuy]='B' and [RiskDate]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        Me.QueryText = "select * from [FX DAILY REVALUATION]  where LEN([ContractNr])=7 and [DealSellBuy]='S' and [RiskDate]='" & rdsql & "'"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)

        For i = 0 To dt.Rows.Count - 1
            Dim ID As String = dt.Rows.Item(i).Item("ID")
            Dim DealSellBuyS As String = dt.Rows.Item(i).Item("DealSellBuy")
            Dim InputDateS As String = dt.Rows.Item(i).Item("InputDate")
            Dim BuyCurS As String = dt.Rows.Item(i).Item("BuyCCY")
            Dim SellCurS As String = dt.Rows.Item(i).Item("SellCCY")
            For y = 0 To dt1.Rows.Count - 1
                Dim ContractNr As String = dt1.Rows.Item(y).Item("ContractNr")
                Dim DealSellBuyB As String = dt1.Rows.Item(y).Item("DealSellBuy")
                Dim InputDateB As String = dt1.Rows.Item(y).Item("InputDate")
                Dim BuyCurB As String = dt1.Rows.Item(y).Item("BuyCCY")
                Dim SellCurB As String = dt1.Rows.Item(y).Item("SellCCY")
                If InputDateS = InputDateB And BuyCurS = SellCurB And SellCurS = BuyCurB Then
                    cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET [MatchingContractNr]='" & ContractNr & "' where [ID]='" & ID & "' and [MatchingContractNr] is NULL"
                    cmd.ExecuteNonQuery()
                End If
            Next
        Next
        '*******************************************************************************************


        Me.BgwODASimport.ReportProgress(30, "Update all details for matched contract types")
        cmd.CommandText = "UPDATE A SET A.[MatchingClientNo]=B.[ClientNo],A.[MatchingClientName]=B.[ClientName],A.[MatchingContractType]=B.[ContractType],A.[MatchingProductType]=B.[ProductType],A.[MatchingInputDate]=B.[InputDate],A.[MatchingValueDate]=B.[ValueDate],A.[MatchingMaturityDate]=B.[MaturityDate],A.[MatchingDealSellBuy]=B.[DealSellBuy],A.[MatchingBuyCCY]=B.[BuyCCY],A.[MatchingBuyAmount]=B.[BuyAmount],A.[MatchingSellCCY]=B.[SellCCY],A.[MatchingSellAmount]=B.[SellAmount],A.[MatchingExchange Rate]=B.[Exchange Rate],A.[MatchingRevalBuyRate]=B.[RevalBuyRate],A.[MatchingRevalSellRate]=B.[RevalSellRate],A.[MatchingRevalBuyAmount]=B.[RevalBuyAmount],A.[MatchingRevalSellAmount]=B.[RevalSellAmount],A.[Matching_PL_EUR]=B.[PL_EUR],A.[Matching_PL_inEUR_Equ]=B.[PL_inEUR_Equ],A.[MatchingNPV]=B.[NPV],A.[MatchingDiscountRate]=B.[DiscountRate],A.[MatchingDealStatus]=B.[DealStatus],A.[MatchingDealType]=B.[DealType] from [FX DAILY REVALUATION] A INNER JOIN [FX DAILY REVALUATION] B ON A.[MatchingContractNr]=B.[ContractNr] where A.[MatchingContractNr] is not NULL and A.[RiskDate]='" & rdsql & "'"
        cmd.ExecuteNonQuery()

        Me.BgwODASimport.ReportProgress(40, "Delete non related Data")
        Me.QueryText = "select [MatchingContractNr] from [FX DAILY REVALUATION]  where  [RiskDate]='" & rdsql & "' and [MatchingContractNr] is not NULL"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            cmd.CommandText = "DELETE FROM [FX DAILY REVALUATION]  where [ContractNr]='" & dt.Rows.Item(i).Item("MatchingContractNr") & "'"
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub ODAS_IMPORT_OBLIGO_LIABILITIES_SURPLUS()

        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT OBLIGO LIABILITIES SURPLUS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='OBLIGO LIABILITIES SURPLUS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(10, "Start import: OBLIGO LIABILITIES SURPLUS")
                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\hobr_sum-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\hobr_sum-en.xls"

                Me.BgwODASimport.ReportProgress(20, "Get Value from Range (E6) from file: hobr_sum-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    'Datum des Reports-Immer erste Zeile
                    'Dim rd As Date = xlWorksheet1.Range("A6").Value
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")
                    'Betrag Liabilities surplus
                    Dim fxp As Double = xlWorksheet1.Range("E6").Value

                    'EINFÜGEN IN RISK LIMIT DAILY CONTROL
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar
                    If IsNothing(t) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[CCBINFO Obligo Liability surplus]='" & Str(fxp) & "',[CCBINFO Obligo Liability surplus Default]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    ElseIf IsNothing(t) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                        cmd.ExecuteScalar()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]='" & Str(fxp) & "',[CCBINFO Obligo Liability surplus Default]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11
                    Me.BgwODASimport.ReportProgress(99, "Value Range (E6) from File:\hobr_sum-en.xls has being imported")
                    Me.BgwODASimport.ReportProgress(100, "Import procedure:OBLIGO LIABILITIES SURPLUS is finished sucesfully")

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure:OBLIGO LIABILITIES SURPLUS is not VALID+++")
            End If
            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub





#End Region



#Region "OCBS BACKGROUNDWORKER"
    Private Sub BgwOCBSimport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOCBSimport.DoWork
        Try
            Me.BgwOCBSimport.ReportProgress(10, "Locate the OCBS Current and Temp Directory")

            'Heutiges Datum ermitteln und in Zahl unformatieren
            Dim CurDate As Date = Today
            Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")


            cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
            cmdOCBS.Connection.Open()
            OCBSDirectory = cmdOCBS.ExecuteScalar()
            cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
            OCBSFileNewDirectory = cmdOCBS.ExecuteScalar()

            'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
            Me.BgwOCBSimport.ReportProgress(20, "OCBS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

            Me.BgwOCBSimport.ReportProgress(25, "Create Temporary Table: OCBSFilesTemp")
            cmdOCBS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OCBSFilesTemp' AND xtype='U') CREATE TABLE OCBSFilesTemp (id int IDENTITY(1,1),OCBSsubdirectories nvarchar(512)) ELSE DELETE FROM [OCBSFilesTemp] "
            cmdOCBS.ExecuteNonQuery()
            Me.BgwOCBSimport.ReportProgress(30, "Insert OCBS File in Table: OCBSFilesTemp")
            cmdOCBS.CommandText = "INSERT [OCBSFilesTemp] ([OCBSsubdirectories]) EXEC master..xp_subdirs '" & OCBSDirectory & "'"
            cmdOCBS.ExecuteNonQuery()
            Me.BgwOCBSimport.ReportProgress(35, "Create Temporary Table: OCBS FILES")
            cmdOCBS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OCBS FILES' AND xtype='U') CREATE TABLE [OCBS FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[FileName] [float] NULL,[FileFullName] [nvarchar](255) NULL) ELSE DELETE FROM [OCBS FILES] "
            cmdOCBS.ExecuteNonQuery()
            Me.BgwOCBSimport.ReportProgress(40, "Insert in Table: OCBS FILES from Table: OCBSFilesTemp")
            cmdOCBS.CommandText = "INSERT INTO [OCBS FILES] ([FileName],[FileFullName]) Select Cast([OCBSsubdirectories] as float),'" & OCBSDirectory & "'+ [OCBSsubdirectories] from [OCBSFilesTemp]"
            cmdOCBS.ExecuteNonQuery()
            Me.BgwOCBSimport.ReportProgress(45, "Delete from Table: OCBS FILES where FileName < Last OCBS Import File: " & Me.LastOcbsImportFile.Text)
            cmdOCBS.CommandText = "DELETE FROM [OCBS FILES] where [FileName]<'" & Me.LastOcbsImportFile.Text & "'"
            cmdOCBS.ExecuteNonQuery()
            Me.BgwOCBSimport.ReportProgress(50, "Delete from Table: OCBS FILES where FileName >= Current Date: " & CurDateSql)
            cmdOCBS.CommandText = "DELETE FROM [OCBS FILES] where [FileName]>='" & CurDateSql & "'"
            cmdOCBS.ExecuteNonQuery()


            Me.QueryText = "SELECT [FileName],[FileFullName]  FROM [OCBS FILES]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            Me.BgwOCBSimport.ReportProgress(50, "Determine the next OCBS File for Import...Please wait...")

            For m = 0 To dt.Rows.Count - 1
                Me.QueryText = "Select  [FileName] as NextFileNameforimport,[FileFullName] as NextFileFullName from [OCBS FILES] where [FileName] in (SELECT min([FileName])FROM [OCBS FILES] where [FileName]>(Select [FileName] from [OCBSLastProcFile]))"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    COBIF = dt1.Rows.Item(0).Item("NextFileNameforimport")
                    'Define Business Date based on the COIF
                    Dim BTD As String = COBIF
                    rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                    rdsql = rd.ToString("yyyyMMdd")
                    '**************************************************************************
                    Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_COBIF))
                    'Current OCBS File for Import-Insert in the Events Journal after finishing the current OCBS Import
                    Dim LCOBIF As String = COBIF
                    Dim OCBSFileFullName As String = dt1.Rows.Item(0).Item("NextFileFullName")
                    'Löschen der Daten in OCBS FILES
                    Me.BgwOCBSimport.ReportProgress(60, "Delete from OCBS FILES the File: " & COBIF)
                    cmdOCBS.CommandText = "DELETE  FROM [OCBS FILES] where [FileName]='" & COBIF & "'"
                    cmdOCBS.ExecuteNonQuery()
                    ' Ordner einschl. aller Unterordner kopieren
                    Me.BgwOCBSimport.ReportProgress(65, "Copy Folder:" & OCBSFileFullName & " to " & OCBSFileNewDirectory)
                    CopyFolder(OCBSFileFullName, OCBSFileNewDirectory)
                    'OCBS Directory with all files for Import
                    OCBS_Temp_Directory = OCBSFileNewDirectory & "\general\99999999999"
                    Me.BgwOCBSimport.ReportProgress(60, "OCBS File for Import: " & "  " & COBIF & " is ready")
                    Me.BgwOCBSimport.ReportProgress(70, "Starting the OCBS Import procedures...")

                    'PROCEDUREN
                    OCBS_IMPORT_PROCEDURES()

                    'Erstellten Ordner wieder löschen
                    Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                    Directory.Delete(OCBSFileNewDirectory, True)
                    'Ordner als Bearbeitet einsetzen (LOBIF)
                    Me.BgwOCBSimport.ReportProgress(90, "Set as Last imported OCBS File Name: " & "  " & COBIF)
                    cmdOCBS.CommandText = "UPDATE [OCBSLastProcFile] SET[FileName]='" & COBIF & "' WHERE [ID]=1"
                    cmdOCBS.ExecuteNonQuery()

                    LOBIF = COBIF
                    Me.LastOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOBIF))
                    COBIF = Nothing
                    Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COBIF))

                    'Füllen des Table adapters

                    Me.OCBSLastProcFileTableAdapter.Fill(Me.PSTOOLDataset.OCBSLastProcFile)

                    Me.BgwOCBSimport.ReportProgress(95, "OCBS File Import: " & " " & LCOBIF & " " & "is finished ...")
                    Me.BgwOCBSimport.ReportProgress(100, "OCBS Import finished ...")
                End If
            Next m
            'Löschen der Temporären Tabelen für den OCBS Import
            cmdOCBS.CommandText = "DROP TABLE [OCBSFilesTemp]"
            cmdOCBS.ExecuteNonQuery()
            cmdOCBS.CommandText = "DROP TABLE [OCBS FILES]"
            cmdOCBS.ExecuteNonQuery()

            If cmdOCBS.Connection.State = ConnectionState.Open Then
                cmdOCBS.Connection.Close()
            End If

        Catch ex As System.Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for OCBS file: " & " " & Me.CurrentOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
            Exit Sub
        Finally
            Me.BgwOCBSimport.CancelAsync()
            If Directory.Exists(OCBSFileNewDirectory) = True Then
                Directory.Delete(OCBSFileNewDirectory, True)
            End If
            'Excel Instanz beenden
            Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            Dim i1 As Short
            i1 = 0
            For i1 = 0 To (procs.Length - 1)
                procs(i1).Kill()
            Next i1
        End Try
    End Sub

    Private Sub BgwOCBSimport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOCBSimport.ProgressChanged
        Me.EVENTSloadtext.Text = e.UserState
        Me.OCBSProgressBar.Value = e.ProgressPercentage

        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & Me.EVENTSloadtext.Text & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','OCBS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "OCBS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & ex.Message.ToString.Replace("'", " ") & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','OCBS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "OCBS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            '***************************************************
            'Dim myBuilder As New StringBuilder
            'Dim headers As String = "On " & Today & "the following import error have being occured in OCBS Imports:" & vbNewLine
            'Dim Footer As String = "(Please check the error and restart the related import procedure)" & vbNewLine
            'Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
            'Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
            'Dim outApp As Microsoft.Office.Interop.Outlook.Application

            'outApp = New Microsoft.Office.Interop.Outlook.Application

            'NSpace = outApp.GetNamespace("MAPI")
            'Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
            'EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
            'EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

            'EItem.To = EMAIL_USERS

            'EItem.Subject = "PS TOOL - OCBS IMPORT ERROR on " & " " & Today

            'EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

            'myBuilder.Append("ERROR: " & ex.Message.ToString.Replace("'", " ") & "  Procedure Name: " & Me.CURRENT_PROCEDURE_Text.Text & "System: OCBS" & vbNewLine)


            'Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

            'EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
            'EItem.Send()
            '**************************************
            Exit Try
        End Try
        cmdEVENT.Connection.Close()
    End Sub

    Private Sub BgwOCBSimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOCBSimport.RunWorkerCompleted
        Me.OCBSProgressBar.Value = 0
        If Me.BgwClientRun.IsBusy = False Then
            Me.BgwClientRun.RunWorkerAsync()
        End If


    End Sub
#End Region

    Private Sub OCBS_IMPORT_PROCEDURES()

        'Me.OCBS_IMPORT_OBLIGO_LIABILITIES_SURPLUS()
        Me.OCBS_IMPORT_PROFIT_LOSS_RESULT()
        Me.OCBS_IMPORT_EXPOSURE_REPORT()
        Me.OCBS_IMPORT_EXCHANGE_RATES_OCBS()
        Me.OCBS_IMPORT_INTEREST_ON_ACCOUNT_DE()
        Me.OCBS_IMPORT_INTEREST_TIME_DEPOSIT_DE()
        Me.OCBS_IMPORT_DAILY_BALANCE_SHEETS()
        Me.OCBS_IMPORT_DAILY_BALANCE_DETAILS_SHEETS()
        Me.OCBS_IMPORT_DAILY_BALANCE_DETAILS_SHEETS_2()
        Me.OCBS_IMPORT_TIME_DEPOSIT_OUTSTANDING_CLIENT_DEALS()
        Me.OCBS_IMPORT_TRIAL_BALANCE_218()
        Me.OCBS_IMPORT_CL_DRAWDOWN_OUTSTANDING_LN_D_004()
        Me.OCBS_IMPORT_NOSTRO_BALANCES()
        'Me.OCBS_IMPORT_NOSTRO_VOLUMES()
        Me.OCBS_IMPORT_ALL_VOLUMES()
        Me.OCBS_IMPORT_PROFIT_LOSS_VOLUMES()
        Me.OCBS_IMPORT_DIVERSE_VOLUMES()
        Me.OCBS_IMPORT_CUSTOMER_VOLUMES()
        Me.OCBS_IMPORT_SUSPENCE_BALANCES()
        Me.OCBS_IMPORT_CUSTOMER_VOSTRO_VOLUMES()
        Me.OCBS_IMPORT_LETTER_OF_CREDITS()
        Me.OCBS_IMPORT_GL_ACCOUNTS()
        Me.OCBS_IMPORT_GUARANTEE_EXPOSURE()


    End Sub

#Region "OCBS IMPORTS"


    Private Sub OCBS_IMPORT_OBLIGO_LIABILITIES_SURPLUS() 'NON VALID-IMPORT THROUGH ODAS

        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT OBLIGO LIABILITIES SURPLUS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='OBLIGO LIABILITIES SURPLUS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then

                Me.BgwOCBSimport.ReportProgress(10, "Start import: OBLIGO LIABILITIES SURPLUS")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-317 - OBLIGO Report (Amount in EUR)-en.xls"
                Me.BgwOCBSimport.ReportProgress(20, "Get Value from Range (E6) from file: AI-D-317 - OBLIGO Report (Amount in EUR)-en.xls)")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    'Datum des Reports-Immer erste Zeile
                    'Dim rd As Date = xlWorksheet1.Range("A6").Value
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")
                    'Betrag Liabilities surplus
                    Dim fxp As Double = xlWorksheet1.Range("E6").Value

                    'EINFÜGEN IN RISK LIMIT DAILY CONTROL
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar
                    If IsNothing(t) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[CCBINFO Obligo Liability surplus]='" & Str(fxp) & "',[CCBINFO Obligo Liability surplus Default]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    ElseIf IsNothing(t) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                        cmd.ExecuteScalar()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]='" & Str(fxp) & "',[CCBINFO Obligo Liability surplus Default]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11
                    Me.BgwOCBSimport.ReportProgress(99, "Value Range (E6) from File:\AI-D-317 - OBLIGO Report (Amount in EUR)-en.xls) has being imported")
                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure:OBLIGO LIABILITIES SURPLUS is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File:\AI-D-317 - OBLIGO Report (Amount in EUR)-en.xls) does not exist+++")
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import procedure:OBLIGO LIABILITIES SURPLUS is not VALID+++")
            End If
            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub 'NON VALID-IMPORT THROUGH OODAS

    Private Sub OCBS_IMPORT_PROFIT_LOSS_RESULT()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT PROFIT LOSS RESULT"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='PROFIT LOSS RESULT' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import: PROFIT LOSS RESULT")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-316 - P L development-en.xls"
                Me.BgwOCBSimport.ReportProgress(20, "Get Value from Range (B7) from File: ...\AI-D-316 - P L development-en.xls)")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False
                    'Datum des Reports-Immer erste Zeile
                    'Dim rd As Date = xlWorksheet1.Range("A7").Value
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")
                    'Betrag Liabilities surplus
                    Dim fxp As Double = xlWorksheet1.Range("B7").Value
                    'EINFÜGEN IN RISK LIMIT DAILY CONTROL
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar
                    If IsNothing(t) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PL Result]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    ElseIf IsNothing(t) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                        cmd.ExecuteScalar()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PL Result]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11

                    Me.BgwOCBSimport.ReportProgress(99, "Value Range (E6) from File:\AI-D-316 - P L development-en.xls has being imported")
                    Me.BgwOCBSimport.ReportProgress(100, "Import Procedure:PROFIT LOSS RESULT is finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure:PROFIT LOSS RESULT is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub

    Private Sub OCBS_IMPORT_EXPOSURE_REPORT()
        Try

            'Dim rd As Date
            Dim rd1 As Date
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT EXPOSURE REPORT"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='EXPOSURE REPORT' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import: EXPOSURE REPORT")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\CL-D-005 - Exception Report (Exposure) - All-en.xls"
                Me.BgwOCBSimport.ReportProgress(20, "Import File: ...\CL-D-005 - Exception Report (Exposure) - All-en.xls)")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(25, "Check if Data are available in the Exception Report!")
                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("C6").Value <> "" Then
                        Me.BgwOCBSimport.ReportProgress(35, "Data are available - Start reformating the Excel File...Please wait...")
                        xlWorksheet1.Range("B5").Value = "ClientNo"
                        xlWorksheet1.Range("C5").Value = "ClientName"
                        xlWorksheet1.Range("F5").Value = "LimitNo"
                        xlWorksheet1.Range("K5").Value = "LimitAmountFC"
                        xlWorksheet1.Range("L5").Value = "ExposureFC"
                        xlWorksheet1.Range("M5").Value = "ExcessFC"
                        xlWorksheet1.Range("N5").Value = "TopLimitNo"
                        xlWorksheet1.Range("R5").Value = "LimitAmountEUR"
                        xlWorksheet1.Range("S5").Value = "ExposureEUR"
                        xlWorksheet1.Range("T5").Value = "ExcessEUR"
                        xlWorksheet1.Range("V5").Value = "LimitAmountL"
                        xlWorksheet1.Range("W5").Value = "ExposureL"
                        xlWorksheet1.Range("X5").Value = "ExcessL"
                        xlWorksheet1.Range("Y5").Value = "RiskDate"
                        xlWorksheet1.Range("Z5").Value = "RepDate"

                        xlWorksheet1.Columns("Y:Z").numberformat = "yyyymmdd"

                        'Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        'report Date definieren
                        xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                        rd1 = xlWorksheet1.Range("C1").Value
                        Dim rd1sql As String = rd1.ToString("yyyyMMdd")
                        'Rows delete
                        xlWorksheet1.Rows("1:4").delete()
                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        'Datum einfügen wo daten vorhanden sind
                        Me.BgwOCBSimport.ReportProgress(45, "Input Risk Date in the Excel File from row 2 to 5000...Please wait...")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                        For i = 2 To 5000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If xlWorksheet1.Cells(i, 2).value <> "" Then 'Wenn Type nicht leer ist!
                                xlWorksheet1.Cells(i, 25).Value = rd
                                xlWorksheet1.Cells(i, 26).Value = rd1
                            End If
                        Next i

                        EXCELL.Application.DisplayAlerts = False
                        xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing
                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1

                        Me.BgwOCBSimport.ReportProgress(55, "Excel File reformated sucesfully...")
                        'Prüfen ob daten vorhanden sind
                        Me.BgwOCBSimport.ReportProgress(56, "Check if same data are available in the EXCEPTION REPORT Table")
                        cmd.CommandText = "SELECT distinct [RiskDate] FROM [EXCEPTION REPORT] Where [RiskDate]='" & rdsql & "'"
                        Dim t As String = cmd.ExecuteScalar()
                        If IsNothing(t) = False Then
                            Me.BgwOCBSimport.ReportProgress(57, "Same Data are deleted")
                            'Vorhandene Daten löschen
                            cmd.CommandText = "DELETE  FROM [EXCEPTION REPORT] Where [RiskDate]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(58, "Import Excel File to the EXCEPTION REPORT Table")
                            'Daten importieren 
                            cmd.CommandText = "INSERT INTO [EXCEPTION REPORT] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]')"
                            cmd.ExecuteNonQuery()
                            'Summe Excess ermitteln
                            Me.BgwOCBSimport.ReportProgress(59, "Select sum of the Exception Amount")
                            cmd.CommandText = "SELECT sum([ExcessEUR]) FROM [EXCEPTION REPORT] Where [RiskDate]='" & rdsql & "'"
                            Dim excEUR As Double = cmd.ExecuteScalar()
                            'Summ Excess an Haupttabelle weitergeben
                            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                            Me.BgwOCBSimport.ReportProgress(60, "Insert sum of the Exception Amount in the DAILY RISK LIMIT CONTROL Table")
                            Dim t1 As String = cmd.ExecuteScalar
                            If IsNothing(t1) = False Then
                                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[ExcessAmount]='" & Str(excEUR) & "' WHERE [RLDC Date]='" & rdsql & "'"
                                cmd.ExecuteScalar()
                            ElseIf IsNothing(t1) = True Then
                                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                                cmd.ExecuteScalar()
                                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [ExcessAmount]='" & Str(excEUR) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                                cmd.ExecuteScalar()
                            End If
                        Else
                            Me.BgwOCBSimport.ReportProgress(58, "Import Excel File to the EXCEPTION REPORT Table")
                            'Daten importieren 
                            cmd.CommandText = "INSERT INTO [EXCEPTION REPORT] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]')"
                            cmd.ExecuteNonQuery()
                            'Summe Excess ermitteln
                            cmd.CommandText = "SELECT sum([ExcessEUR]) FROM [EXCEPTION REPORT] Where [RiskDate]='" & rdsql & "'"
                            Dim excEUR As Double = cmd.ExecuteScalar()
                            'Summ Excess an Haupttabelle weitergeben
                            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                            Dim t1 As String = cmd.ExecuteScalar
                            If IsNothing(t1) = False Then
                                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[ExcessAmount]='" & Str(excEUR) & "' WHERE [RLDC Date]='" & rdsql & "'"
                                cmd.ExecuteScalar()
                            ElseIf IsNothing(t1) = True Then
                                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                                cmd.ExecuteScalar()
                                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [ExcessAmount]='" & Str(excEUR) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                                cmd.ExecuteScalar()
                            End If
                        End If
                    Else

                        Me.BgwOCBSimport.ReportProgress(35, "No Data are available - The Excess Amount in RISK LIMIT DAILY CONTROL is Zero")
                        'Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        'report Date definieren
                        xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                        rd1 = xlWorksheet1.Range("C1").Value
                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        'Summ Excess an Haupttabelle weitergeben
                        cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"

                        Dim t1 As String = cmd.ExecuteScalar
                        If IsNothing(t1) = False Then
                            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[ExcessAmount]=0 WHERE [RLDC Date]='" & rdsql & "'"
                            cmd.ExecuteScalar()
                        ElseIf IsNothing(t1) = True Then
                            cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                            cmd.ExecuteScalar()
                            cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [ExcessAmount]=0,[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                            cmd.ExecuteScalar()
                        End If
                    End If
                    Me.BgwOCBSimport.ReportProgress(100, "Import Procedure: EXPOSURE REPORT finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(10, "+++Import Procedure: EXPOSURE REPORT is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_EXCHANGE_RATES_OCBS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "EXCHANGE RATES OCBS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='EXCHANGE RATES OCBS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import: EXCHANGE RATES OCBS")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-218 - Trial Balance (consolidated)-en.xlwa"

                Me.BgwOCBSimport.ReportProgress(20, "Import File: ...\AI-D-218 - Trial Balance (consolidated)-en.xlwa)-Sheet:Rate-2")

                If File.Exists(ExcelFileName) = True Then

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Rate-2")
                    EXCELL.Visible = False
                    'Dim rd As Date
                    Dim rd1 As Date
                    'Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                    'Exchange Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")
                    'report creation Date definieren
                    xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                    rd1 = xlWorksheet1.Range("C1").Value

                    xlWorksheet1.Range("A8").Value = "CURRENCY CODE"
                    xlWorksheet1.Range("D8").Value = "MIDDLE RATE"

                    'Rows delete
                    xlWorksheet1.Rows("1:7").delete()
                    xlWorksheet1.Columns("B:C").delete()
                    xlWorksheet1.Columns("C:C").delete()

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1

                    'Delete Exchange Rates with the same Date
                    Me.BgwOCBSimport.ReportProgress(30, "Delete Exchange Rates with the same Exchange Rate Date")
                    cmd.CommandText = "DELETE from [EXCHANGE RATES OCBS] where [EXCHANGE RATE DATE]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    'Create EXCHANGE RATES IMPORT
                    Me.BgwOCBSimport.ReportProgress(40, "Create Exchange Rate import Table")
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='IMPORT EXCHANGE RATES OCBS' AND xtype='U') CREATE TABLE [IMPORT EXCHANGE RATES OCBS]([CURRENCY CODE] [nvarchar](255) NULL,[CURRENCY NAME][nvarchar](255) NULL,[ID] [int] IDENTITY(1,1) NOT NULL,[MIDDLE RATE] [float] NULL) ELSE DELETE FROM [IMPORT EXCHANGE RATES OCBS] "
                    cmd.ExecuteNonQuery()
                    'Importieren in dem SQL SERVER
                    Me.BgwOCBSimport.ReportProgress(50, "Import Exchange rates to the Temporary Import Table")
                    cmd.CommandText = "INSERT INTO [IMPORT EXCHANGE RATES OCBS] ([CURRENCY CODE],[MIDDLE RATE]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Rate-2$]')"
                    cmd.ExecuteNonQuery()
                    'Nicht relevante Währungen in Import Tabelle löschen
                    Me.BgwOCBSimport.ReportProgress(60, "Delete Exchange Rate if Currency is not OWN_CURRENCY")
                    cmd.CommandText = "DELETE FROM [IMPORT EXCHANGE RATES OCBS] WHERE [IMPORT EXCHANGE RATES OCBS].[CURRENCY CODE] NOT IN (Select [OWN_CURRENCIES].[CURRENCY CODE] from [OWN_CURRENCIES])"
                    cmd.ExecuteNonQuery()
                    'Currency Name importieren
                    Me.BgwOCBSimport.ReportProgress(70, "Update Currency Name in the Temporary Import Table ")
                    cmd.CommandText = "UPDATE [IMPORT EXCHANGE RATES OCBS] SET [IMPORT EXCHANGE RATES OCBS].[CURRENCY NAME]=(Select [OWN_CURRENCIES].[CURRENCY NAME] from [OWN_CURRENCIES] where [IMPORT EXCHANGE RATES OCBS].[CURRENCY CODE]=[OWN_CURRENCIES].[CURRENCY CODE])"
                    cmd.ExecuteNonQuery()
                    'Neuanlage EXCHANGE RATES OCBS
                    Me.BgwOCBSimport.ReportProgress(80, "Insert Exchange Rates to the Table:EXCHANGE RATES OCBS from the Temporary Import Table ")
                    cmd.CommandText = "INSERT INTO [EXCHANGE RATES OCBS] ([CURRENCY CODE],[CURRENCY NAME],[MIDDLE RATE]) select [CURRENCY CODE],[CURRENCY NAME],[MIDDLE RATE] from [IMPORT EXCHANGE RATES OCBS] where [CURRENCY CODE]<>'EUR' and [CURRENCY NAME] is not NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [EXCHANGE RATES OCBS] SET [EXCHANGE RATE DATE]='" & rdsql & "' where [EXCHANGE RATE DATE] is NULL"
                    cmd.ExecuteNonQuery()
                    'SPREAD ERMITTELN
                    Me.BgwOCBSimport.ReportProgress(85, "Determine the Spread for each Currency")
                    cmd.CommandText = "UPDATE [EXCHANGE RATES OCBS] SET [EXCHANGE RATES OCBS].[SPREAD]=(Select [OWN_CURRENCIES].[SPREAD] FROM [OWN_CURRENCIES] where [EXCHANGE RATES OCBS].[CURRENCY CODE]=[OWN_CURRENCIES].[CURRENCY CODE]) where [EXCHANGE RATES OCBS].[SPREAD] is NULL"
                    cmd.ExecuteNonQuery()
                    'OFFERED RATE + MONEY RATE ERMITTELN
                    Me.BgwOCBSimport.ReportProgress(90, "Determine the Offered and Money Rate for each Currency")
                    cmd.CommandText = "UPDATE [EXCHANGE RATES OCBS]  SET [OFFERED RATE]=[MIDDLE RATE]+[SPREAD] , [MONEY RATE]=[MIDDLE RATE]-[SPREAD] where [EXCHANGE RATE DATE]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Löschen EXCHANGE RATES IMPORT
                    Me.BgwOCBSimport.ReportProgress(95, "Drop the Temporary Import Table")
                    cmd.CommandText = "DROP TABLE [IMPORT EXCHANGE RATES OCBS]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(100, "OCBS Exchange Rates imported sucesfully")
                    '*************************************************************************


                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: EXCHANGE RATES OCBS ist not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_INTEREST_ON_ACCOUNT_DE()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT' and [Valid]='Y'"
            cmd.Connection.Open()
            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import: ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                Me.BgwOCBSimport.ReportProgress(2, "Import Excel File: ...\AI-D-249 - General Ledger Journal List-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(3, "Check If data are available!Range D2 must start with General Ledger Journal List ...")
                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                        Me.BgwOCBSimport.ReportProgress(4, "Start reformation of the Excel File...Please wait...")
                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("F1").Value = "ValDate"
                        xlWorksheet1.Range("H1").Value = "Account"
                        xlWorksheet1.Range("I1").Value = "Contract"
                        xlWorksheet1.Range("J1").Value = "Product"
                        xlWorksheet1.Range("N1").Value = "DB"
                        xlWorksheet1.Range("P1").Value = "Customer"
                        xlWorksheet1.Range("AB1").Value = "Remark"
                        xlWorksheet1.Range("AC1").Value = "ValYear"
                        xlWorksheet1.Range("AD1").Value = "IdErtragJahr"
                        xlWorksheet1.Columns("AC:AD").numberformat = "#,##0"
                        xlWorksheet1.Range("AE1").Value = "KapertstG"
                        xlWorksheet1.Range("AF1").Value = "Soli"
                        xlWorksheet1.Columns("AE:AF").numberformat = "#,##0.00"
                        xlWorksheet1.Range("AG1").Value = "CustomerName"
                        xlWorksheet1.Range("AH1").Value = "RegistrationCountry"
                        xlWorksheet1.Range("AI1").Value = "IdValueCustomer"
                        xlWorksheet1.Range("AJ1").Value = "IdZinsertragsMonat"
                        xlWorksheet1.Columns("AJ:AJ").numberformat = "@"

                        Me.BgwOCBSimport.ReportProgress(5, "Check if GL/AC No=23009212 and Amount<0 and delete the relevant rows...")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX10))
                        For i = 2 To 10000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Len(xlWorksheet1.Cells(i, 5).value) = "23009212" And xlWorksheet1.Cells(i, 13).value < 0 Then
                                xlWorksheet1.Rows(i).Delete()
                            End If
                        Next

                        Me.BgwOCBSimport.ReportProgress(5, "Check if Customer Nr in Column 16 is not NULL and determine Interest Payment Year and Month...Delete all other rows...")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX10))
                        For i = 2 To 10000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Len(xlWorksheet1.Cells(i, 16).value) > 0 Then ' wenn Client No größer NULL ist
                                Dim yd As Double = Microsoft.VisualBasic.Right(xlWorksheet1.Cells(i, 6).value, 4)
                                Dim zm As Date = xlWorksheet1.Cells(i, 6).value
                                xlWorksheet1.Cells(i, 29).Value = yd
                                xlWorksheet1.Cells(i, 30).Value = yd
                                xlWorksheet1.Cells(i, 35).Value = xlWorksheet1.Cells(i, 6).Value & xlWorksheet1.Cells(i, 8).Value
                                xlWorksheet1.Cells(i, 36).Value = zm.ToString("MMMM yyyy")
                            Else
                                xlWorksheet1.Rows(i).Delete()
                            End If
                        Next i

                        xlWorksheet1.Columns("A:E").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("B:B").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("E:E").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("H:H").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("I:S").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                        '*********CHECK IF CUSTOMER NUMBER EXISTS IN TABLE:ZINSERTRAG KDBASIC********************
                        '********If not exists insert each Customer Nr. to Table:ZINSERTRAG KDBASIC**************
                        '****************************************************************************************
                        Me.BgwOCBSimport.ReportProgress(6, "Check if Customer Nr is in Table:ZINSERTRAG KDBASIC and insert if not...")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX10))
                        For i = 2 To 10000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Len(xlWorksheet1.Cells(i, 8).value) > 0 Then
                                Dim KDSTAMM As Double = xlWorksheet1.Cells(i, 8).Value
                                'Prüfen ob KUNDEN STAMM vorhanden sind
                                cmd.CommandText = "SELECT distinct [KDSTAMM] FROM [ZINSERTRAG KDBASIC] Where [KDSTAMM]='" & KDSTAMM & "'"
                                Dim kd As String = cmd.ExecuteScalar()
                                If IsNothing(kd) = False Then
                                Else
                                    'Neuanlage KUNDENSTAMM
                                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KDBASIC]([KDSTAMM],[IdBank])VALUES('" & Str(KDSTAMM) & "','3')"
                                    cmd.ExecuteNonQuery()
                                End If
                            End If
                        Next i
                        '*******************************************************************************************

                        Me.BgwOCBSimport.ReportProgress(7, "Define ERTRAGSJAHR and ERTRAGSMONAT in Format 01.ERTRAGSMONAT.ERTRAGSJAHR")
                        'Ertragsjahr/Ertragsmonat definieren
                        Dim ERTRAGSJAHR As Double = xlWorksheet1.Range("J2").Value
                        Dim ERTRAGSMONAT As String = xlWorksheet1.Range("Q2").Value

                        Dim idem As Date
                        If ERTRAGSMONAT.StartsWith("Januar") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 1, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("Februar") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 2, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("März") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 3, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("April") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 4, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("Mai") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 5, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("Juni") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 6, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("Juli") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 7, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("August") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 8, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("September") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 9, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("Oktober") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 10, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("November") = True Then
                            idem = DateSerial(ERTRAGSJAHR, 11, 1)
                        ElseIf ERTRAGSMONAT.StartsWith("Dezember") = True Then
                            'idem = DateSerial(ERTRAGSJAHR, 3, 1)
                            idem = DateSerial(ERTRAGSJAHR, 12, 1)
                        End If

                        xlWorksheet1.Columns("A:A").numberformat = "yyyymmdd"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\INTEREST_ON_ACCOUNT.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()
                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        'Prüfen ob ERTRAGSJAHR vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(8, "Check if ZINSERTRAGSJAHR " & ERTRAGSJAHR & " in Table ZINSERTRAG KUNDEN JAHR present is")
                        cmd.CommandText = "SELECT distinct [ErtragsJahr] FROM [ZINSERTRAG KUNDEN JAHR] Where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                        Dim t As String = cmd.ExecuteScalar()
                        If IsNothing(t) = False Then
                        Else
                            Me.BgwOCBSimport.ReportProgress(9, "New insert ZINSERTRAGSJAHR: " & ERTRAGSJAHR)
                            'Neuanlage ERTRAGSJAHR
                            cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN JAHR]([ErtragsJahr],[IdBank])VALUES('" & ERTRAGSJAHR & "','3')"
                            cmd.ExecuteNonQuery()
                        End If


                        'Prüfen ob ERTRAGSMONAT vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(10, "Check if ZINSERTRAGSMONAT " & ERTRAGSMONAT & " is present in Table ZINSERTRAG KUNDEN MONAT ")
                        cmd.CommandText = "SELECT distinct [Zinsertragsmonat] FROM [ZINSERTRAG KUNDEN MONAT] Where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                        Dim t1 As String = cmd.ExecuteScalar()
                        If IsNothing(t1) = False Then
                        Else
                            Me.BgwOCBSimport.ReportProgress(11, "New insert ZINSERTRAGSMONAT: " & ERTRAGSMONAT)
                            'Neuanlage ZINSERTRAG KUNDEN MONAT
                            cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN MONAT]([Zinsertragsmonat],[IdZinsertragJahr],[ZinsertragsmonatDATE])VALUES('" & ERTRAGSMONAT & "','" & ERTRAGSJAHR & "','" & idem & "')"
                            cmd.ExecuteNonQuery()
                        End If

                        Me.BgwOCBSimport.ReportProgress(12, "Start Import to the Temporary Table: ZINSERTRAG KUNDEN DETAILS TEMP")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ZINSERTRAG KUNDEN DETAILS TEMP' AND xtype='U') CREATE TABLE [dbo].[ZINSERTRAG KUNDEN DETAILS TEMP]([ID] [int] IDENTITY(1,1) NOT NULL,[ValDateFrom] [datetime] NULL,[ValDate] [datetime] NULL,[Customer] [nvarchar](255) NULL,[ValYear] [float] NULL,[CustomerName] [nvarchar](255) NULL,[Account] [nvarchar](255) NULL,[RegistrationCountry] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[CCY] [nvarchar](255) NULL,[Product] [nvarchar](255) NULL,[Amount] [float] NULL,[ExchangeRate] [float] NULL,[AmountEuro] [float] NULL,[DB] [nvarchar](255) NULL,[KapertstG] [float] NULL,[Remark] [nvarchar](255) NULL,[Soli] [float] NULL,[KAPISTPFLICHTIG] [nvarchar](255) NULL,[BUNDESLAND] [nvarchar](255) NULL,[IdValueCustomer] [nvarchar](255) NULL,[IdZinsertragsMonat] [nvarchar](255) NULL,[IdErtragJahr] [float] NULL) ELSE DELETE FROM [ZINSERTRAG KUNDEN DETAILS TEMP] "
                        cmd.ExecuteNonQuery()
                        'In temporäre Tabelle einfügen
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS TEMP] ([ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()

                        Me.BgwOCBSimport.ReportProgress(13, "Start Sub Process for the anual Payments Statistic (ZVSTA) insert Data in Table: KUNDEN INTEREST ON AC")
                        '*******************************************************************************************************************************************
                        '*****SUB PROZEDUR - Einfügen der Zinserträge in der Tabelle KUNDEN INTEREST ON AC- für die ZAHLUNGSVERKEHRSSTATISTIK***********************
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        'FÜR ZAHLUNGSVERKEHRSSTATISTIK
                        'In KUNDEN INTEREST ON ACCOUNT einfügen
                        cmd.CommandText = "INSERT INTO [KUNDEN INTEREST ON AC] ([ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN wenn kein INTEREST ON AC
                        Me.BgwOCBSimport.ReportProgress(14, "Delete from Table: KUNDEN INTEREST ON AC where Remark not like INTEREST ON A/C% ")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                        cmd.ExecuteNonQuery()
                        'CUSTOMER NAME-REGISTRATION COUNTRY EINFÜGEN
                        Me.BgwOCBSimport.ReportProgress(15, "Update Customer Registration country in Table: KUNDEN INTEREST ON AC from Table CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [KUNDEN INTEREST ON AC] A  INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo]"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                        Me.BgwOCBSimport.ReportProgress(16, "Delete from Table:KUNDEN INTEREST ON AC if Customer Name is NULL")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [CustomerName] IS NULL"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER NEGATIVEN WERTE
                        Me.BgwOCBSimport.ReportProgress(17, "Delete from Table:KUNDEN INTEREST ON AC if Field (DB)=D")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [DB] IN ('D')"
                        cmd.ExecuteNonQuery()
                        'Exchange Rate
                        Me.BgwOCBSimport.ReportProgress(18, "Set Exchange Rates in Table: KUNDEN INTEREST ON AC")
                        cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                        cmd.ExecuteNonQuery()
                        'cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [KUNDEN INTEREST ON AC].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [KUNDEN INTEREST ON AC].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [KUNDEN INTEREST ON AC] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(19, "Calculate all Amounts in EURO")
                        cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(20, "Delete Duplicates from KUNDEN INTEREST ON AC - Field: IdValueCustomer")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [ID] not in (Select Min([ID]) from [KUNDEN INTEREST ON AC] group by [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(21, "End Sub Process for the anual Payments Statistic (ZVSTA)")
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        '***************************************************************************************************************
                        '*************ZINSERTRÄGE EINFÜGEN******************************************************************************
                        '*******Überprüfen ob Kunde Kapitalertragssteuerpflichtig ist und berechnungen durchführen**********************
                        '***************************************************************************************************************
                        'LÖSCHEN wenn kein INTEREST ON AC
                        Me.BgwOCBSimport.ReportProgress(22, "Start Insert Data to the Table: ZINSERTRAG KUNDEN DETAILS")
                        Me.BgwOCBSimport.ReportProgress(23, "Delete from  ZINSERTRAG KUNDEN DETAILS TEMP where Remark not like INTEREST ON A/C")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS TEMP] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN wenn kein KUNDENSTAMM vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(24, "Delete from  ZINSERTRAG KUNDEN DETAILS TEMP where Customer like NULL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS TEMP] where [Customer] is NULL"
                        cmd.ExecuteNonQuery()
                        'In live Tabelle einfügen
                        Me.BgwOCBSimport.ReportProgress(25, "Insert Data to Table: ZINSERTRAG KUNDEN DETAILS ")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS] ([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr]) SELECT [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr] FROM [ZINSERTRAG KUNDEN DETAILS TEMP]"
                        cmd.ExecuteNonQuery()
                        'Temptabelle löschen
                        cmd.CommandText = "DROP TABLE [ZINSERTRAG KUNDEN DETAILS TEMP]"
                        cmd.ExecuteNonQuery()
                        'SET DEFAULT VALUES=0 to EXCHANGE RATE,AmountEuro,KapertstG,Soli
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]=0 where [ExchangeRate] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]=0 where [AmountEuro] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0 where [KapertstG] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]=0 where [Soli] is NULL"
                        cmd.ExecuteNonQuery()
                        'CUSTOMER NAME-REGISTRATION COUNTRY EINFÜGEN
                        Me.BgwOCBSimport.ReportProgress(26, "Update Customer Name and Registration country in Table: ZINSERTRAG KUNDEN DETAILS from Table CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo] where B.[ClientType] NOT IN ('F - FINANCIAL')"
                        cmd.ExecuteNonQuery()
                        'ÜBERPRPFEBN VON Tabelle ZINSERTRAG KDBASIC ob Kunde Kapitalertragssteuerpflichtig ist
                        Me.BgwOCBSimport.ReportProgress(26, "Update Field: KAPISTPFLICHTIG in Table: ZINSERTRAG KUNDEN DETAILS from Table ZINSERTRAG KDBASIC")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]=B.[KDSTAMM]"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                        Me.BgwOCBSimport.ReportProgress(27, "Delete from Table: ZINSERTRAG KUNDEN DETAILS where Customer Name is NULL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [CustomerName] IS NULL"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN ALLER FINACIAL INSTITUTIONS
                        Me.BgwOCBSimport.ReportProgress(28, "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Customer Type= F-FINACIAL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [Customer] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType]='F - FINANCIAL')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER GEBIETS AUSLÄNDER
                        Me.BgwOCBSimport.ReportProgress(29, "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Registration Country not DE")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [RegistrationCountry] NOT IN ('DE')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER NEGATIVEN WERTE
                        Me.BgwOCBSimport.ReportProgress(30, "Delete from Table:ZINSERTRAG KUNDEN DETAILS if Field (DB)=D")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [DB] IN ('D')"
                        cmd.ExecuteNonQuery()
                        'Exchange Rate für EUR übergeben
                        Me.BgwOCBSimport.ReportProgress(31, "Set Exchange Rates in Table: ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                        cmd.ExecuteNonQuery()
                        'Exchange Rates importieren
                        'cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [ZINSERTRAG KUNDEN DETAILS].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [ZINSERTRAG KUNDEN DETAILS].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(32, "Calculate all Amounts in EURO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(33, "Delete Duplicates from ZINSERTRAG KUNDEN DETAILS - Field: IdValueCustomer")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KUNDEN DETAILS] group by [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragsteuer berechnen
                        Me.BgwOCBSimport.ReportProgress(34, "Calculate Kapitalertragssteuer in  ZINSERTRAG KUNDEN DETAILS - Parameter:MELDEWESEN/KAPITALERTRAGSTEUER_SATZ")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= [AmountEuro]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='KAPITALERTRAGSTEUER_SATZ') where [KapertstG]=0"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragssteuer auf null wenn KapitaSteuerbetrag<1
                        Me.BgwOCBSimport.ReportProgress(35, "Set Kapitalertragssteuer to 0 if Calculated Kapitalertragssteuer <1 in  ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= 0 where [KapertstG] < 1"
                        cmd.ExecuteNonQuery()
                        'Soli berechnen
                        Me.BgwOCBSimport.ReportProgress(36, "Calculate Solidaritätsbeitrag in  ZINSERTRAG KUNDEN DETAILS - - Parameter:MELDEWESEN/SOLI_SATZ")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]= [KapertstG]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='SOLI_SATZ') where [Soli]=0"
                        cmd.ExecuteNonQuery()
                        'BUNDESLAND für Gesamt Kunden und Details einfügen
                        Me.BgwOCBSimport.ReportProgress(37, "Determine BUNDESLAND in  ZINSERTRAG KDBASIC,ZINSERTRAG KUNDEN DETAILS and ZINSERTRAG KDDETAIL ")
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [BUNDESLAND]=B.[BUNDESLAND]  from [ZINSERTRAG KDBASIC] A INNER JOIN [PLZ_BUNDESLAND] B ON A.[KDPLZ]= B.[PLZ] where A.[KDPLZ] is not NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KDBASIC] A INNER JOIN [PLZ_BUNDESLAND] B ON A.[KDPLZ]= '0'+ B.[PLZ] where A.[KDPLZ] is not NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KUNDEN DETAILS] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]= B.[KDSTAMM] where A.[BUNDESLAND] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDDETAIL] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]= B.[KDSTAMM] where A.[BUNDESLAND] is NULL"
                        cmd.ExecuteNonQuery()
                        'Leerzeichen in Kundenname löschen
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [KDNAME1]=RTRIM([KDNAME1]),[KDNAME2]=RTRIM([KDNAME2])"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDDETAIL] SET [CustomerName]=RTRIM([CustomerName])"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragssteuer + Soli auf 0 stellen wenn KAPISTEUERPFLICHT ist N
                        Me.BgwOCBSimport.ReportProgress(37, "Set Solidaritätsbeitrag + Kapitalertragsteuer to 0 if KAPITALSTEUERPFLICHTIG is N")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDDETAIL] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()

                        'SUMMEN BERECHEN ERTRAGSMONAT
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(38, "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN MONAT")
                        cmd.CommandText = "Select Sum([KapertstG]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                        Dim km As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            km = cmd.ExecuteScalar
                        Else
                            km = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeKapErSt]= '" & Str(km) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                        cmd.ExecuteNonQuery()
                        'Soli
                        cmd.CommandText = "Select Sum([Soli]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                        Dim sm As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            sm = cmd.ExecuteScalar
                        Else
                            sm = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeSoli]= '" & Str(sm) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                        cmd.ExecuteNonQuery()


                        'SUMMEN BERECHEN ERTRAGSJAHR
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(39, "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN JAHR")
                        cmd.CommandText = "Select Sum([SummeKapErSt]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                        Dim ky As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            ky = cmd.ExecuteScalar
                        Else
                            ky = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeKapErSt]= '" & Str(ky) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                        cmd.ExecuteNonQuery()
                        'Soli
                        cmd.CommandText = "Select Sum([SummeSoli]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                        Dim sy As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            sy = cmd.ExecuteScalar
                        Else
                            sy = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeSoli]= '" & Str(sy) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                        cmd.ExecuteNonQuery()


                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        'Füllen der Tabelle ZINSERTRAG KDDETAIL
                        Me.BgwOCBSimport.ReportProgress(40, "Fill Table: ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KDDETAIL]([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[IdKDSTAMM])Select [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[Customer] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(41, "Delete Duplicates in Table: ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDDETAIL] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KDDETAIL] GROUP BY [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        'Update Zinsertrag, Kapi-Soli basierend auf [ZINSERTRAG KUNDEN DETAILS]
                        Me.BgwOCBSimport.ReportProgress(41, "Update Data in ZINSERTRAG KDDETAIL based on [IdValueCustomer] from [ZINSERTRAG KUNDEN DETAILS]")
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[ExchangeRate],A.[AmountEuro]=B.[AmountEuro],A.[KapertstG]=B.[KapertstG],A.[Soli]=B.[Soli],A.[KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG]  FROM [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[IdValueCustomer]=B.[IdValueCustomer]"
                        cmd.ExecuteNonQuery()
                        'Löschen in Tabelle ZINSERTRAG KDBASIC wenn keine Daten für IDSTAMM gibt
                        Me.BgwOCBSimport.ReportProgress(42, "Delete from Table: ZINSERTRAG KDBASIC where KDSTAMM not in Table ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDBASIC] where [KDSTAMM] NOT IN (Select [IdKDSTAMM] from [ZINSERTRAG KDDETAIL])"
                        cmd.ExecuteNonQuery()
                        'Namen der Kunden in der Tabelle ZINSERTRAG KDBASIC einfügen
                        Me.BgwOCBSimport.ReportProgress(43, "Update Customer Name in Table: ZINSERTRAG KDBASIC from CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KDNAME1]=B.[English Name] from [ZINSERTRAG KDBASIC] A INNER JOIN [CUSTOMER_INFO] B ON A.[KDSTAMM]=B.[ClientNo]"
                        cmd.ExecuteNonQuery()


                        '?????????????????NEUANLAUF KAPISTPFLICHTIG???????????????????
                        Me.BgwOCBSimport.ReportProgress(44, "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KDDETAIL] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(45, "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()


                        'SUMMEN BERECHEN ERTRAGSMONAT
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(46, "Recalculate Sum Kapitalertragssteuer in Table: ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "Select Sum([KapertstG]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                        Dim km1 As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            km1 = cmd.ExecuteScalar
                        Else
                            km1 = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeKapErSt]= '" & Str(km1) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                        cmd.ExecuteNonQuery()
                        'Soli
                        Me.BgwOCBSimport.ReportProgress(47, "Recalculate Sum Solidaritätsbeitrag in Table: ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "Select Sum([Soli]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                        Dim sm1 As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            sm1 = cmd.ExecuteScalar
                        Else
                            sm1 = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeSoli]= '" & Str(sm1) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                        cmd.ExecuteNonQuery()

                        'SUMMEN BERECHEN ERTRAGSJAHR
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(48, "Recalculate Sum Kapitalertragssteuer in Table: ZINSERTRAG KUNDEN JAHR")
                        cmd.CommandText = "Select Sum([SummeKapErSt]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                        Dim ky1 As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            ky1 = cmd.ExecuteScalar
                        Else
                            ky1 = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeKapErSt]= '" & Str(ky1) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                        cmd.ExecuteNonQuery()
                        'Soli
                        Me.BgwOCBSimport.ReportProgress(49, "Recalculate Sum Solidaritätsbeitrag in Table: ZINSERTRAG KUNDEN JAHR")
                        cmd.CommandText = "Select Sum([SummeSoli]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                        Dim sy1 As Double = 0
                        If cmd.ExecuteScalar IsNot DBNull.Value Then
                            sy1 = cmd.ExecuteScalar
                        Else
                            sy1 = 0
                        End If
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeSoli]= '" & Str(sy1) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(50, "Import Procedure:ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT finished sucesfully")
                    Else
                        MsgBox("ERROR+++Invalid Format!", MsgBoxStyle.Exclamation, "IMPORT ABORTED")

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(10, "+++Import Procedure:ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT is not VALID+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_INTEREST_TIME_DEPOSIT_DE()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "ZINSERTRAEGE KUNDEN-TIME DEPOSITS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='ZINSERTRAEGE KUNDEN-TIME DEPOSITS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import: ZINSERTRAEGE KUNDEN-TIME DEPOSITS")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\TD-D-002 - Time Deposit Outstanding Client Deals Report -Start-en.xls"
                Me.BgwOCBSimport.ReportProgress(2, "Import Excel File: ...\TD-D-002 - Time Deposit Outstanding Client Deals Report -Start-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(3, "Check if data available-Range D2")
                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("Time Deposit Outstanding Client Deals Report -Start") = True Then
                        Me.BgwOCBSimport.ReportProgress(4, "Reformate the Excel File...Please wait...")

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:4").delete()
                        xlWorksheet1.Range("A1").Value = "Remark"
                        xlWorksheet1.Range("E1").Value = "Customer"
                        xlWorksheet1.Range("I1").Value = "CCY"
                        xlWorksheet1.Range("K1").Value = "ValDate"
                        xlWorksheet1.Range("H1").Value = "ValDateFrom"
                        xlWorksheet1.Range("R1").Value = "Amount"
                        xlWorksheet1.Range("W1").Value = "Product"
                        xlWorksheet1.Range("Y1").Value = "DB"
                        xlWorksheet1.Range("Z1").Value = "ValYear"
                        xlWorksheet1.Range("AA1").Value = "IdErtragJahr"
                        xlWorksheet1.Columns("Z:AA").numberformat = "#,##0"
                        xlWorksheet1.Range("AB1").Value = "KapertstG"
                        xlWorksheet1.Range("AC1").Value = "Soli"
                        xlWorksheet1.Columns("AB:AC").numberformat = "#,##0.00"
                        xlWorksheet1.Range("AD1").Value = "CustomerName"
                        xlWorksheet1.Range("AE1").Value = "RegistrationCountry"
                        xlWorksheet1.Range("AF1").Value = "IdValueCustomer"
                        xlWorksheet1.Range("AG1").Value = "IdZinsertragsMonat"
                        xlWorksheet1.Columns("AG:AG").numberformat = "@"

                        'Dateformat to SQL
                        xlWorksheet1.Columns("K:K").numberformat = "yyyymmdd"
                        xlWorksheet1.Columns("H:H").numberformat = "yyyymmdd"

                        Me.BgwOCBSimport.ReportProgress(5, "Check if Customer Nr in Column 5 is not NULL and determine Interest Payment Year and Month...Delete all other rows...")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                        For i = 2 To 5000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Len(xlWorksheet1.Cells(i, 5).value) > 0 Then
                                Dim yd As Double = Microsoft.VisualBasic.Right(xlWorksheet1.Cells(i, 11).value, 4)
                                Dim zm As Date = xlWorksheet1.Cells(i, 11).value
                                xlWorksheet1.Cells(i, 25).Value = "C"
                                xlWorksheet1.Cells(i, 26).Value = yd
                                xlWorksheet1.Cells(i, 27).Value = yd
                                xlWorksheet1.Cells(i, 32).Value = xlWorksheet1.Cells(i, 11).Value & xlWorksheet1.Cells(i, 3).Value
                                xlWorksheet1.Cells(i, 33).Value = zm.ToString("MMMM yyyy")
                            Else
                                xlWorksheet1.Rows(i).Delete()
                            End If
                        Next i

                        xlWorksheet1.Columns("B:D").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("C:D").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("G:L").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("E:E").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("G:J").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("H:H").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                        'Nicht relevante Daten löschen
                        Me.BgwOCBSimport.ReportProgress(6, "Delete not relevant data")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                        For i = 2 To 5000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Trim(xlWorksheet1.Cells(i, 5).value) = "" Then
                                xlWorksheet1.Rows(i).Delete()
                            End If
                        Next

                        Me.BgwOCBSimport.ReportProgress(7, "Define ERTRAGSMONAT and ERTRAGSJAHR in Format 01.ERTRAGSMONAT.ERTRAGSJAHR-Check if ERTRAGSJAHR and ERTRAGSMONAT present is in Tables: ZINSERTRAG KUNDEN JAHR and ZINSERTRAG KUNDEN MONAT ")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                        For i = 2 To 5000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Len(xlWorksheet1.Cells(i, 5).value) > 0 Then
                                'Prüfen ob Ertragsjahr/Ertragsmonat vorhanden ist
                                'Ertragsjahr/Ertragsmonat definieren
                                Dim ERTRAGSJAHR As Double = xlWorksheet1.Cells(i, 9).Value
                                Dim ERTRAGSMONAT As String = xlWorksheet1.Cells(i, 16).Value
                                Dim KDSTAMM As Double = xlWorksheet1.Cells(i, 2).Value
                                Dim idem As Date
                                If ERTRAGSMONAT.StartsWith("Januar") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 1, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("Februar") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 2, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("März") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 3, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("April") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 4, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("Mai") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 5, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("Juni") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 6, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("Juli") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 7, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("August") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 8, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("September") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 9, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("Oktober") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 10, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("November") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 11, 1)
                                ElseIf ERTRAGSMONAT.StartsWith("Dezember") = True Then
                                    idem = DateSerial(ERTRAGSJAHR, 12, 1)
                                End If

                                'Prüfen ob ERTRAGSJAHR vorhanden sind
                                cmd.CommandText = "SELECT distinct [ErtragsJahr] FROM [ZINSERTRAG KUNDEN JAHR] Where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                                Dim t As String = cmd.ExecuteScalar()
                                If IsNothing(t) = False Then
                                Else
                                    'Neuanlage ERTRAGSJAHR
                                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN JAHR]([ErtragsJahr],[IdBank])VALUES('" & ERTRAGSJAHR & "','3')"
                                    cmd.ExecuteNonQuery()
                                End If

                                'Prüfen ob ERTRAGSMONAT vorhanden sind
                                cmd.CommandText = "SELECT distinct [Zinsertragsmonat] FROM [ZINSERTRAG KUNDEN MONAT] Where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                                Dim t1 As String = cmd.ExecuteScalar()
                                If IsNothing(t1) = False Then
                                Else
                                    'Neuanlage ERTRAGSMONAT
                                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN MONAT]([Zinsertragsmonat],[IdZinsertragJahr],[ZinsertragsmonatDATE])VALUES('" & ERTRAGSMONAT & "','" & ERTRAGSJAHR & "','" & idem & "')"
                                    cmd.ExecuteNonQuery()
                                End If

                                'Prüfen ob KUNDEN STAMM vorhanden sind
                                cmd.CommandText = "SELECT distinct [KDSTAMM] FROM [ZINSERTRAG KDBASIC] Where [KDSTAMM]='" & KDSTAMM & "'"
                                Dim kd As String = cmd.ExecuteScalar()
                                If IsNothing(kd) = False Then
                                Else
                                    'Neuanlage KUNDENSTAMM
                                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KDBASIC]([KDSTAMM],[IdBank])VALUES('" & KDSTAMM & "','3')"
                                    cmd.ExecuteNonQuery()
                                End If
                            End If
                        Next

                        Dim ExcelFileNewName As String = "" 'Selbe Datei wird auch für OCBS_IMPORT_TIME_DEPOSIT_OUTSTANDING_CLIENT_DEALS gebraucht
                        ExcelFileNewName = Me.OCBS_Temp_Directory & "\TD-D-002 - Time Deposit Outstanding Client Deals Report -Start-en-Modified.xls"
                        EXCELL.Application.DisplayAlerts = False
                        xlWorkBook.SaveAs(ExcelFileNewName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(8, "Excel File reformated sucesfully")

                        'Einfügen in ZINSERTRAG KUNDEN DETAILS
                        Me.BgwOCBSimport.ReportProgress(9, "Start Import in the Table:ZINSERTRAG KUNDEN DETAILS ")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS] ([Remark],[Customer],[ValDateFrom],[CCY],[ValDate],[Amount],[Product],[DB],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNewName & ";','SELECT * FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                        'SET DEFAULT VALUES=0 to EXCHANGE RATE,AmountEuro,KapertstG,Soli
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]=0 where [ExchangeRate] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]=0 where [AmountEuro] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0 where [KapertstG] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]=0 where [Soli] is NULL"
                        cmd.ExecuteNonQuery()
                        'CUSTOMER NAME-REGISTRATION COUNTRY EINFÜGEN
                        Me.BgwOCBSimport.ReportProgress(10, "Update Customer Name and Registration country in Table: ZINSERTRAG KUNDEN DETAILS from Table CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo] where B.[ClientType] NOT IN ('F - FINANCIAL')"
                        cmd.ExecuteNonQuery()
                        'ÜBERPRPFEBN VON Tabelle ZINSERTRAG KDBASIC ob Kunde Kapitalertragssteuerpflichtig ist
                        Me.BgwOCBSimport.ReportProgress(10, "Update Field: KAPISTPFLICHTIG in Table: ZINSERTRAG KUNDEN DETAILS from Table ZINSERTRAG KDBASIC")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]=B.[KDSTAMM]"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                        Me.BgwOCBSimport.ReportProgress(11, "Delete from Table: ZINSERTRAG KUNDEN DETAILS where Customer Name is NULL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [CustomerName] IS NULL"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN ALLER CCB'S
                        Me.BgwOCBSimport.ReportProgress(12, "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Customer Type=F-FINANCIAL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [Customer] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType]='F - FINANCIAL')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER GEBIETS AUSLÄNDER
                        Me.BgwOCBSimport.ReportProgress(13, "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Registration Country not DE")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [RegistrationCountry] NOT IN ('DE')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER NEGATIVEN WERTE
                        Me.BgwOCBSimport.ReportProgress(14, "Delete from Table:ZINSERTRAG KUNDEN DETAILS if Field (DB)=D")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [DB] IN ('D')"
                        cmd.ExecuteNonQuery()
                        'Exchange Rate für EUR übergeben
                        Me.BgwOCBSimport.ReportProgress(15, "Set Exchange Rates in Table: ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                        cmd.ExecuteNonQuery()
                        'Exchange Rates importieren
                        'cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [ZINSERTRAG KUNDEN DETAILS].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [ZINSERTRAG KUNDEN DETAILS].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(16, "Calculate all Amounts in EURO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(17, "Delete Duplicates from ZINSERTRAG KUNDEN DETAILS - Field: IdValueCustomer")
                        cmd.CommandText = "DELETE FROM [ZINSERTRAG KUNDEN DETAILS] WHERE [ID] not in (SELECT  Min([ID]) from [ZINSERTRAG KUNDEN DETAILS] GROUP BY [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragsteuer berechnen
                        Me.BgwOCBSimport.ReportProgress(18, "Calculate Kapitalertragssteuer in  ZINSERTRAG KUNDEN DETAILS - Parameter:MELDEWESEN\KAPITALERTRAGSTEUER_SATZ")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= [AmountEuro]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='KAPITALERTRAGSTEUER_SATZ') where [KapertstG]=0"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragssteuer auf null wenn KapitaSteuerbetrag<1
                        Me.BgwOCBSimport.ReportProgress(19, "Set Kapitalertragssteuer to 0 if Calculated Kapitalertragssteuer <1 in  ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= 0 where [KapertstG] < 1"
                        cmd.ExecuteNonQuery()
                        'Soli berechnen
                        Me.BgwOCBSimport.ReportProgress(20, "Calculate Solidaritätsbeitrag in  ZINSERTRAG KUNDEN DETAILS  - Parameter:MELDEWESEN\SOLI_SATZ")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]= [KapertstG]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='SOLI_SATZ') where [Soli]=0"
                        cmd.ExecuteNonQuery()
                        'BUNDESLAND für Gesamt Kunden und Details einfügen
                        Me.BgwOCBSimport.ReportProgress(21, "Determine BUNDESLAND in  ZINSERTRAG KDBASIC,ZINSERTRAG KUNDEN DETAILS and ZINSERTRAG KDDETAIL ")
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [BUNDESLAND]=B.[BUNDESLAND]  from [ZINSERTRAG KDBASIC] A INNER JOIN [PLZ_BUNDESLAND] B ON A.[KDPLZ]= B.[PLZ] where A.[KDPLZ] is not NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KDBASIC] A INNER JOIN [PLZ_BUNDESLAND] B ON A.[KDPLZ]= '0'+ B.[PLZ] where A.[KDPLZ] is not NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KUNDEN DETAILS] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]= B.[KDSTAMM] where A.[BUNDESLAND] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE   [ZINSERTRAG KDDETAIL] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]= B.[KDSTAMM] where A.[BUNDESLAND] is NULL"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragssteuer + Soli auf 0 stellen wenn KAPISTEUERPFLICHT ist N
                        Me.BgwOCBSimport.ReportProgress(21, "Set Solidaritätsbeitrag + Kapitalertragsteuer to 0 if KAPITALSTEUERPFLICHTIG is N")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDDETAIL] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()

                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        'Löschen in Tabelle ZINSERTRAG KUNDEN MONAT wenn keine Daten für IdZinseertragsMonat gibt
                        Me.BgwOCBSimport.ReportProgress(22, "Delete in Table ZINSERTRAG KUNDEN MONAT if IdZinsertragsmonat NULL is ")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN MONAT] where [Zinsertragsmonat] NOT IN (Select [IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS])"
                        cmd.ExecuteNonQuery()
                        'Löschen in Tabelle ZINSERTRAG KUNDEN JAHR wenn keine Daten für IdZinsertragJahr gibt
                        Me.BgwOCBSimport.ReportProgress(23, "Delete in Table ZINSERTRAG KUNDEN JAHR if IdZinsertragsjahr NULL is ")
                        cmd.CommandText = "DELETE FROM [ZINSERTRAG KUNDEN JAHR] where [ErtragsJahr] NOT IN (Select [IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT])"
                        cmd.ExecuteNonQuery()
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        'Geamtsummen berechenn
                        Me.BgwOCBSimport.ReportProgress(24, "Recalculate Sum Kapitalertragssteuer and Soli...Please wait...")
                        Me.QueryText = "SELECT distinct[IdZinsertragsMonat] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For m = 0 To dt.Rows.Count - 1
                            Dim ERTRAGSMONAT As String = dt.Rows.Item(m).Item("IdZinsertragsMonat")
                            'SUMMEN BERECHEN ERTRAGSMONAT
                            'Kapitalertragssteuer
                            cmd.CommandText = "Select Sum([KapertstG]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                            Dim km As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                km = cmd.ExecuteScalar
                            Else
                                km = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeKapErSt]= '" & Str(km) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                            cmd.ExecuteNonQuery()

                            'Soli
                            cmd.CommandText = "Select Sum([Soli]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                            Dim sm As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                sm = cmd.ExecuteScalar
                            Else
                                sm = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeSoli]= '" & Str(sm) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                            cmd.ExecuteNonQuery()
                        Next m



                        Me.QueryText = "SELECT distinct[IdErtragJahr] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For j = 0 To dt.Rows.Count - 1
                            Dim ERTRAGSJAHR As String = dt.Rows.Item(j).Item("IdErtragJahr")
                            'SUMMEN BERECHEN ERTRAGSJAHR
                            'Kapitalertragssteuer
                            cmd.CommandText = "Select Sum([SummeKapErSt]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                            Dim ky As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                ky = cmd.ExecuteScalar
                            Else
                                ky = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeKapErSt]= '" & Str(ky) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                            cmd.ExecuteNonQuery()
                            'Soli
                            cmd.CommandText = "Select Sum([SummeSoli]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                            Dim sy As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                sy = cmd.ExecuteScalar
                            Else
                                sy = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeSoli]= '" & Str(sy) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                            cmd.ExecuteNonQuery()
                        Next


                        'Füllen der Tabelle ZINSERTRAG KDDETAIL
                        Me.BgwOCBSimport.ReportProgress(50, "Fill table ZINSERTRAG KDBASIC and ZINSERTRAG KDDETAIL...Pleae wait...")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KDDETAIL]([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[IdKDSTAMM])Select [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[Customer] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(51, "Delete Duplicates in ZINSERTRAG KDDETAIL - IdValueCustomer")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDDETAIL] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KDDETAIL] GROUP BY [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        'Update Zinsertrag, Kapi-Soli basierend auf [ZINSERTRAG KUNDEN DETAILS]
                        Me.BgwOCBSimport.ReportProgress(51, "Update Data in ZINSERTRAG KDDETAIL based on [IdValueCustomer] from [ZINSERTRAG KUNDEN DETAILS]")
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[ExchangeRate],A.[AmountEuro]=B.[AmountEuro],A.[KapertstG]=B.[KapertstG],A.[Soli]=B.[Soli],A.[KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG]  FROM [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[IdValueCustomer]=B.[IdValueCustomer]"
                        cmd.ExecuteNonQuery()
                        'Löschen in Tabelle ZINSERTRAG KDBASIC wenn keine Daten für IDSTAMM gibt
                        Me.BgwOCBSimport.ReportProgress(52, "Delete from ZINSERTRAG KDBASIC where IdKDSTAMM not in ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDBASIC] where [KDSTAMM] NOT IN (Select [IdKDSTAMM] from [ZINSERTRAG KDDETAIL])"
                        cmd.ExecuteNonQuery()


                        'Namen der Kunden in der Tabelle ZINSERTRAG KDBASIC einfügen
                        Me.BgwOCBSimport.ReportProgress(53, "Update Customer Name in ZINSERTRAG KDBASIC from Table CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KDNAME1]=B.[English Name] from [ZINSERTRAG KDBASIC] A INNER JOIN [CUSTOMER_INFO] B ON A.[KDSTAMM]=B.[ClientNo]"
                        cmd.ExecuteNonQuery()

                        'NEUANLAUF KAPISTPFLICHTIG
                        '?????????????????NEUANLAUF KAPISTPFLICHTIG???????????????????
                        Me.BgwOCBSimport.ReportProgress(54, "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KDDETAIL] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(55, "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()



                        Me.BgwOCBSimport.ReportProgress(80, "Second Recalculation Sum Kapitalertragssteuer and Soli...Please wait...")
                        Me.QueryText = "SELECT distinct[IdZinsertragsMonat] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For m = 0 To dt.Rows.Count - 1
                            Dim ERTRAGSMONAT As String = dt.Rows.Item(m).Item("IdZinsertragsMonat")
                            'SUMMEN BERECHEN ERTRAGSMONAT
                            'Kapitalertragssteuer
                            cmd.CommandText = "Select Sum([KapertstG]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                            Dim km As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                km = cmd.ExecuteScalar
                            Else
                                km = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeKapErSt]= '" & Str(km) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                            cmd.ExecuteNonQuery()

                            'Soli
                            cmd.CommandText = "Select Sum([Soli]) from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y'"
                            Dim sm As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                sm = cmd.ExecuteScalar
                            Else
                                sm = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN MONAT] SET [SummeSoli]= '" & Str(sm) & "' where [Zinsertragsmonat]='" & ERTRAGSMONAT & "'"
                            cmd.ExecuteNonQuery()
                        Next m

                        Me.QueryText = "SELECT distinct[IdErtragJahr] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        For j = 0 To dt.Rows.Count - 1
                            Dim ERTRAGSJAHR As String = dt.Rows.Item(j).Item("IdErtragJahr")
                            'SUMMEN BERECHEN ERTRAGSJAHR
                            'Kapitalertragssteuer
                            cmd.CommandText = "Select Sum([SummeKapErSt]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                            Dim ky As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                ky = cmd.ExecuteScalar
                            Else
                                ky = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeKapErSt]= '" & Str(ky) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                            cmd.ExecuteNonQuery()
                            'Soli
                            cmd.CommandText = "Select Sum([SummeSoli]) from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "'"
                            Dim sy As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                sy = cmd.ExecuteScalar
                            Else
                                sy = 0
                            End If
                            cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN JAHR] SET [SummeSoli]= '" & Str(sy) & "' where [ErtragsJahr]='" & ERTRAGSJAHR & "'"
                            cmd.ExecuteNonQuery()
                        Next
                        Me.BgwOCBSimport.ReportProgress(100, "Import Procedure:ZINSERTRAEGE KUNDEN-TIME DEPOSITS is finished sucesfully")
                    Else
                        MsgBox("ERROR+++Invalid Format!", MsgBoxStyle.Exclamation, "IMPORT ABORTED")

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:ZINSERTRAEGE KUNDEN-TIME DEPOSITS is not VALID+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try

    End Sub

    Private Sub OCBS_IMPORT_DAILY_BALANCE_SHEETS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "DAILY BALANCE SHEET"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='DAILY BALANCE SHEET' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import: DAILY BALANCE SHEET")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-313 - Balance Sheet-en.xls"

                Me.BgwOCBSimport.ReportProgress(2, "Reformate Excel File:\AI-D-313 - Balance Sheet-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Range("A5").Value = "GL_Item"
                    xlWorksheet1.Range("B5").Value = "GL_Item_Name"
                    xlWorksheet1.Range("C5").Value = "BalanceEUREqu"
                    xlWorksheet1.Range("D5").Value = "BSDate"
                    xlWorksheet1.Range("E5").Value = "RepDate"
                    xlWorksheet1.Columns("D:E").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")

                    'Blatt 1 - Datumsformat einfügen für Report Date
                    Dim rd1 As Date
                    xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                    rd1 = xlWorksheet1.Range("C1").Value
                    Dim rd1sql As String = rd1.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()

                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwOCBSimport.ReportProgress(3, "Insert Report Date if Column 1 is not NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 1).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 4).Value = rd
                            xlWorksheet1.Cells(i, 5).Value = rd1
                        End If
                    Next i

                    'Nicht relevante Daten löschen
                    Me.BgwOCBSimport.ReportProgress(4, "Delete Rows if Column 2=AI-D-313")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 2).value = "AI-D-313" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i


                    'Nicht relevante Daten löschen
                    Me.BgwOCBSimport.ReportProgress(5, "Delete Rows if Column 2 is NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 2).value = "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i


                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11

                    Me.BgwOCBSimport.ReportProgress(6, "Excel File:\AI-D-313 - Balance Sheet-en.xls reformated sucesfully")


                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    cmd.CommandText = "SELECT distinct [BSDate] FROM [DailyBalanceSheets] Where [BSDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                    Else
                        Me.BgwOCBSimport.ReportProgress(7, "Insert Data to Table: DAILY BALANCE SHEETS ")
                        cmd.CommandText = "INSERT INTO [DailyBalanceSheets]([GL_Item],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [GL_Item],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate] FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                    End If

                    Me.BgwOCBSimport.ReportProgress(8, "Update Field:GL_ITEM_NR in DailyBalanceSheet")
                    cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [GL_Item_Number]=REPLACE([GL_Item],'I','') where [BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    '######################################################################################
                    'GL ITEM NUMMER DEFINIEREN
                    '######################################################################################
                    'Me.BgwOCBSimport.ReportProgress(8, "Update Field:GL_ITEM_NR in DailyBalanceSheets only with Numeric GL ITEMS")
                    'Me.QueryText = "select [GL_Item] from [DailyBalanceSheets] where isnumeric([GL_Item])<>0 and [BSDate]='" & rdsql & "'"
                    'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    'dt = New DataTable()
                    'da.Fill(dt)
                    'For i = 0 To dt.Rows.Count - 1
                    'Dim GLNR As Double = dt.Rows.Item(i).Item("GL_Item")
                    'cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [GL_Item_Number]='" & Str(GLNR) & "' where [GL_Item]='" & GLNR & "' and [BSDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'Next
                    '######################################################################################
                    'GL ITEM NUMMER DEFINIEREN FÜR NON NUMMERIC GL ITEMS (Accrued Interest)
                    '######################################################################################
                    'Me.BgwOCBSimport.ReportProgress(8, "Update Field:GL_ITEM_NR in DailyBalanceSheets with Accrued Interest GL ITEMS")
                    'Me.QueryText = "select * from [DailyBalanceSheets] where isnumeric([GL_Item])=0 and [BSDate]='" & rdsql & "'"
                    'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    'dt = New DataTable()
                    'da.Fill(dt)
                    'For i = 0 To dt.Rows.Count - 1
                    'If Len(dt.Rows.Item(i).Item("GL_Item")) = 4 Then
                    'Dim GLNRSTR As String = dt.Rows.Item(i).Item("GL_Item")
                    'Dim GLNR As Double = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("GL_Item"), 3)
                    'cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [GL_Item_Number]='" & Str(GLNR) & "' where [GL_Item]='" & GLNRSTR & "' and [BSDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'ElseIf Len(dt.Rows.Item(i).Item("GL_Item")) = 5 Then
                    'Dim GLNRSTR As String = dt.Rows.Item(i).Item("GL_Item")
                    'Dim GLNR As Double = Microsoft.VisualBasic.Left(dt.Rows.Item(i).Item("GL_Item"), 4)
                    'cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [GL_Item_Number]='" & Str(GLNR) & "' where [GL_Item]='" & GLNRSTR & "' and [BSDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    'End If
                    'Next

                    '######################################################################################
                    'RILIBI CODES MATCHING
                    '######################################################################################
                    Me.BgwOCBSimport.ReportProgress(8, "Matching Rilibi Codes")
                    cmd.CommandText = "UPDATE A set A.[RilibiCode]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_MATCHING' and [PARAMETER STATUS] ='Y')B ON A.[GL_Item_Number]=B.[PARAMETER1]  where A.[BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(8, "Matching Rilibi Names")
                    cmd.CommandText = "UPDATE A set A.[RilibiName]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_CODES' and [PARAMETER STATUS] ='Y')B ON A.[RilibiCode]=B.[PARAMETER1] where A.[BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()


                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: DAILY BALANCE SHEET finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure:DAILY BALANCE SHEET is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_DAILY_BALANCE_DETAILS_SHEETS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "DAILY BALANCE DETAIL SHEET"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='DAILY BALANCE DETAIL SHEET' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import: DAILY BALANCE DETAIL SHEET")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-312 - Balance Sheet Detail-en.xls"

                Me.BgwOCBSimport.ReportProgress(2, "Reformate Excel File:\AI-D-312 - Balance Sheet Detail-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Range("A5").Value = "GL_Item"
                    xlWorksheet1.Range("B5").Value = "ReleatedAccountNr"
                    xlWorksheet1.Range("C5").Value = "GL_Account_Nr"
                    xlWorksheet1.Range("D5").Value = "GL_Account_Name"
                    xlWorksheet1.Range("E5").Value = "Orig_CUR"
                    xlWorksheet1.Range("F5").Value = "Orig_Balance"
                    xlWorksheet1.Range("G5").Value = "Balance_EUR_CR"
                    xlWorksheet1.Range("H5").Value = "Balance_EUR_DR"
                    xlWorksheet1.Range("I5").Value = "Total_Balance"
                    xlWorksheet1.Range("J5").Value = "BSDate"
                    xlWorksheet1.Range("K5").Value = "RepDate"
                    xlWorksheet1.Columns("J:K").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")

                    'Blatt 1 - Datumsformat einfügen für Report Date
                    Dim rd1 As Date
                    xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                    rd1 = xlWorksheet1.Range("C1").Value
                    Dim rd1sql As String = rd1.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()

                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwOCBSimport.ReportProgress(3, "Insert Report Date if Column 5 is not NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 5).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 10).Value = rd
                            xlWorksheet1.Cells(i, 11).Value = rd1
                        End If
                    Next i

                    'Nicht relevante Daten löschen
                    Me.BgwOCBSimport.ReportProgress(4, "Delete Rows if Column 2=AI-D-312")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 2).value = "AI-D-312" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    'Nicht relevante Daten löschen
                    Me.BgwOCBSimport.ReportProgress(5, "Delete Rows if Column 5 is NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 5).value = "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i


                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11

                    Me.BgwOCBSimport.ReportProgress(6, "Excel File:\AI-D-312 - Balance Sheet Detail-en.xls reformated sucesfully")


                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    cmd.CommandText = "SELECT distinct [BSDate] FROM [DailyBalanceDetailsSheets] Where [BSDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                    Else
                        Me.BgwOCBSimport.ReportProgress(7, "Insert Data to Table: DAILY BALANCE DETAIL SHEETS ")
                        cmd.CommandText = "INSERT INTO [DailyBalanceDetailsSheets]([GL_Item],[ReleatedAccountNr],[GL_Account_Nr],[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [GL_Item],[ReleatedAccountNr],LTRIM(RTRIM([GL_Account_Nr])),[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate] FROM [Sheet1$] where [GL_Account_Nr] is not NULL ')"
                        cmd.ExecuteNonQuery()
                    End If

                    Me.BgwOCBSimport.ReportProgress(8, "Update Field:GL_Item_Number in Table Daily Balance Details Sheets")
                    cmd.CommandText = "Update [DailyBalanceDetailsSheets] set [GL_Item_Number]=REPLACE([GL_Item],'I','') where [BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(8, "Update Field:IdBalanceSheets,RilibiCode,RilibiName based on GL_ITEM in Table Daily Balance Sheets")
                    cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID],A.[RilibiCode]=B.[RilibiCode],A.[RilibiName]=B.[RilibiName] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(8, "Delete all data if GL Account Nr is NULL")
                    cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where [IdBalanceSheets] is NULL"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: DAILY BALANCE DETAIL SHEET finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure:DAILY BALANCE DETAIL SHEET is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_DAILY_BALANCE_DETAILS_SHEETS_2()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "DAILY BALANCE DETAIL SHEET 2"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='DAILY BALANCE DETAIL SHEET 2' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import: DAILY BALANCE DETAIL SHEET 2")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-314 - Balance Sheet Detail 2-en.xls"
                Me.BgwOCBSimport.ReportProgress(2, "Reformate Excel File:\AI-D-314 - Balance Sheet Detail 2-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Range("A5").Value = "GL_Item"
                    xlWorksheet1.Range("B5").Value = "ReleatedAccountNr"
                    xlWorksheet1.Range("C5").Value = "GL_Account_Nr"
                    xlWorksheet1.Range("D5").Value = "GL_Account_Name"
                    xlWorksheet1.Range("E5").Value = "Orig_CUR"
                    xlWorksheet1.Range("F5").Value = "Orig_Balance"
                    xlWorksheet1.Range("G5").Value = "Balance_EUR_CR"
                    xlWorksheet1.Range("H5").Value = "Balance_EUR_DR"
                    xlWorksheet1.Range("I5").Value = "Total_Balance"
                    xlWorksheet1.Range("J5").Value = "BSDate"
                    xlWorksheet1.Range("K5").Value = "RepDate"
                    xlWorksheet1.Columns("J:K").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")

                    'Blatt 1 - Datumsformat einfügen für Report Date
                    Dim rd1 As Date
                    xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                    rd1 = xlWorksheet1.Range("C1").Value
                    Dim rd1sql As String = rd1.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()

                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwOCBSimport.ReportProgress(3, "Insert Report Date if Column 5 is not NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 5).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 10).Value = rd
                            xlWorksheet1.Cells(i, 11).Value = rd1
                        End If
                    Next i

                    'Nicht relevante Daten löschen
                    Me.BgwOCBSimport.ReportProgress(4, "Delete Rows if Column 2=AI-D-312")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 2).value = "AI-D-312" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    'Nicht relevante Daten löschen
                    Me.BgwOCBSimport.ReportProgress(5, "Delete Rows if Column 5 is NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 5).value = "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i


                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11

                    Me.BgwOCBSimport.ReportProgress(6, "Excel File:\AI-D-314 - Balance Sheet Detail 2-en.xls reformated sucesfully")


                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    cmd.CommandText = "SELECT distinct [BSDate] FROM [DailyBalanceDetailsSheets2] Where [BSDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                    Else
                        Me.BgwOCBSimport.ReportProgress(7, "Insert Data to Table: DAILY BALANCE DETAIL SHEETS 2 ")
                        cmd.CommandText = "INSERT INTO [DailyBalanceDetailsSheets2]([GL_Item],[ReleatedAccountNr],[GL_Account_Nr],[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [GL_Item],[ReleatedAccountNr],LTRIM(RTRIM([GL_Account_Nr])),[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate] FROM [Sheet1$] where [GL_Account_Nr] is not NULL ')"
                        cmd.ExecuteNonQuery()
                    End If


                    'Me.BgwOCBSimport.ReportProgress(8, "Update Field:IdBalanceSheets based on GL_ITEM in Table Daily Balance Sheets")
                    'cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()

                    'Me.BgwOCBSimport.ReportProgress(8, "Delete all data if GL Account Nr is NULL")
                    'cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where [IdBalanceSheets] is NULL"
                    'cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: DAILY BALANCE DETAIL SHEET 2 finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure:DAILY BALANCE DETAIL SHEET 2 is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_TIME_DEPOSIT_OUTSTANDING_CLIENT_DEALS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "TIME DEPOSIT OUTSTANDING CLIENT DEALS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            'Dim rdsql As String = ""

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='TIME DEPOSIT OUTSTANDING CLIENT DEALS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: TIME DEPOSIT OUTSTANDING CLIENT DEALS")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\TD-D-002 - Time Deposit Outstanding Client Deals Report -Start-en.xls"
                Me.BgwOCBSimport.ReportProgress(2, "Reformating Excel File:\TD-D-002 - Time Deposit Outstanding Client Deals Report -Start-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Range("C5").Value = "Contract No"
                    xlWorksheet1.Range("D5").Value = "Serial No"
                    xlWorksheet1.Range("E5").Value = "Client No"
                    xlWorksheet1.Range("N5").Value = "Cost Of Fund"
                    xlWorksheet1.Range("O5").Value = "Interest Spread"
                    xlWorksheet1.Range("P5").Value = "Rate Variation"
                    xlWorksheet1.Range("Q5").Value = "Contract Rate"
                    xlWorksheet1.Range("Y5").Value = "RepDate"
                    xlWorksheet1.Columns("Y:Y").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("G:H").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("K:L").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'rdsql = rd.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()

                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwOCBSimport.ReportProgress(3, "Insert Date if the column 5 is not NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 5).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 25).Value = rd
                        End If
                    Next i
                    Me.BgwOCBSimport.ReportProgress(4, "Delete Row if column 1 lenght=0")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If Len(xlWorksheet1.Cells(i, 1).value) = 0 Then
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11
                    Me.BgwOCBSimport.ReportProgress(5, "Excel File:TD-D-002 - Time Deposit Outstanding Client Deals Report -Start-en.xls reformated sucesfully")

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    cmd.CommandText = "SELECT distinct [RepDate] FROM [TIME DEP OUTST CLIENT DEALS] Where [RepDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                    Else
                        Me.BgwOCBSimport.ReportProgress(6, "Start import to Table: TIME DEP OUTST CLIENT DEALS")
                        cmd.CommandText = "INSERT INTO [TIME DEP OUTST CLIENT DEALS]([Product Name],[Booking Centre],[Contract No],[Serial No],[Client No],[Client Short Name],[Trade Date],[Value Date],[Currency],[Principal],[Maturity Date],[Final Maturity Date],[Tenor],[Cost Of Fund],[Interest Spread],[Rate Variation],[Contract Rate],[Total Interest],[Accrual Interest],[Principal Plus Interest],[IS Day],[IS Frequency],[Product Code],[Maturity Instruction],[RepDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                        'Löschen der leeren Zellen
                        Me.BgwOCBSimport.ReportProgress(7, "Delete from TIME DEP OUTST CLIENT DEALS where Booking Centre is NULL")
                        cmd.CommandText = "DELETE  FROM [TIME DEP OUTST CLIENT DEALS] where  [Booking Centre] is NULL"
                        cmd.ExecuteNonQuery()
                        'IdBank(einfügen)
                        Me.BgwOCBSimport.ReportProgress(8, "Insert IdBank  in TIME DEP OUTST CLIENT DEALS")
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [IdBank]='3' where [IdBank] is NULL"
                        cmd.ExecuteNonQuery()
                        'Set Exchange Rates
                        Me.BgwOCBSimport.ReportProgress(8, "Set Exchange Rates in TIME DEP OUTST CLIENT DEALS")
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [ExchangeRate]=1 where [Currency]='EUR' and [ExchangeRate]=0 and  [RepDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [TIME DEP OUTST CLIENT DEALS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[RepDate]=B.[EXCHANGE RATE DATE] where A.[Currency]=B.[CURRENCY CODE] and A.[ExchangeRate]=0 and  A.[RepDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                        'Calculate Principal+Interest in EURO
                        Me.BgwOCBSimport.ReportProgress(8, "Calculate Principal plus Interest in EUR")
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [PrincipalPlusInterestEUR]=Round([Principal Plus Interest]/[ExchangeRate],2) where [PrincipalPlusInterestEUR]=0 and [RepDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                    End If



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

                    Me.BgwOCBSimport.ReportProgress(9, "Check if Parameter:EMAIL_REFI is Valid - For the creation of the Refinances Email")
                    cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_REFI'"
                    Dim EMAIL_REFI_Valid As String = cmd.ExecuteScalar

                    If EMAIL_REFI_Valid = "Y" Then
                        Me.BgwOCBSimport.ReportProgress(10, "Parameter:EMAIL_REFI is valid-Start Report and email creation")
                        'REPORT GENERIERUNG
                        'Create Dataset
                        Me.BgwOCBSimport.ReportProgress(11, "Create Dataset as Datasource for the Crystal report:REFINANCING_MATURITY_LIST")
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
                        Me.BgwOCBSimport.ReportProgress(12, "Create Directory for the creation of the Report in pdf")
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_REFI_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_REFI'"
                        ReportExpRefiFile = cmd.ExecuteScalar
                        'Select EMAIL RECEIVERS
                        Me.BgwOCBSimport.ReportProgress(12, "Collect Email Receivers")
                        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_REFI_RECEIVERS'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        Dim EMAIL_USERS As String = ""
                        For i = 0 To dt.Rows.Count - 1
                            EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                        Next
                        dt.Clear()
                        'CC to
                        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_REFI_RECEIVERS_CC'"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        Dim EMAIL_USERS_CC As String = ""
                        For i = 0 To dt.Rows.Count - 1
                            EMAIL_USERS_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                        Next



                        If NextDay.ToString("dddd") = "Samstag" Then
                            '*********************************************************************************************************************************
                            Me.BgwOCBSimport.ReportProgress(13, "Create Email for Maturities on Monday " & SamstagNextMonday)
                            'MATURITIES ON MONDAY
                            Me.QueryText = "SELECT * FROM [TIME DEP OUTST CLIENT DEALS] where [Product Name] like '%REFINANC%' and [Maturity Date]='" & SamstagNextMondaySql & "' and [RepDate] in (SELECT distinct Max([RepDate]) FROM [TIME DEP OUTST CLIENT DEALS])"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            If dt.Rows.Count > 0 Then
                                Dim headers As String = "On Monday (" & SamstagNextMonday & ") , following refinance sold funded will be matured:" & vbNewLine
                                Dim Footer As String = "(Please see also the attached pdf file with all refinance maturities)" & vbNewLine

                                myBuilder.Append("Contract No:     " & "Client No:  " & "Client Name:                    " & "Maturity Date: " & " Principal Amount + Interest :" & vbNewLine)


                                For i = 0 To dt.Rows.Count - 1
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
                                Me.BgwOCBSimport.ReportProgress(14, "Email for Maturities on Monday has being sended")
                            End If
                            '*********************************************************************************************************************************

                            '*********************************************************************************************************************************
                            'MATURITIES ON TUESDAY
                            Me.BgwOCBSimport.ReportProgress(15, "Create Email for Maturities on Tuesday " & SamstagNextTuesday)
                            Me.QueryText = "SELECT * FROM [TIME DEP OUTST CLIENT DEALS] where [Product Name] like '%REFINANC%' and [Maturity Date]='" & SamstagNextTuesdaySql & "' and [RepDate] in (SELECT distinct Max([RepDate]) FROM [TIME DEP OUTST CLIENT DEALS])"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)

                            If dt.Rows.Count > 0 Then

                                Dim headers As String = "On Tuesday (" & SamstagNextTuesday & ") , following refinance sold funded will be matured:" & vbNewLine
                                Dim Footer As String = "(Please see also the attached pdf file with all refinance maturities)" & vbNewLine

                                myBuilderTuesday.Append("Contract No:     " & "Client No:  " & "Client Name:                    " & "Maturity Date: " & " Principal Amount + Interest :" & vbNewLine)

                                For i = 0 To dt.Rows.Count - 1
                                    Dim CapitalPlusInterest As Double = dt.Rows.Item(i).Item("Principal Plus Interest")
                                    myBuilderTuesday.Append(dt.Rows.Item(i).Item("Contract No") & "  " & dt.Rows.Item(i).Item("Client No") & "    " & dt.Rows.Item(i).Item("Client Short Name") & "  " & dt.Rows.Item(i).Item("Maturity Date") & "      " & dt.Rows.Item(i).Item("Currency") & "  " & FormatNumber(CapitalPlusInterest, 2) & vbNewLine)
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

                                EItem.Subject = "MATURED REFINANCES on " & " " & SamstagNextTuesday

                                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

                                Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

                                EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilderTuesday.ToString & vbNewLine & Footer
                                EItem.Send()
                                Directory.Delete(ReportExpRefiFile, True)
                                Me.BgwOCBSimport.ReportProgress(16, "Email for Maturities on Tuesday has being sended")
                            End If
                            '*************************************************************************************************************************

                        ElseIf NextDay.ToString("dddd") <> "Sonntag" AndAlso NextDay.ToString("dddd") <> "Samstag" Then
                            Me.BgwOCBSimport.ReportProgress(17, "Create Email for Maturities")
                            Me.QueryText = "SELECT * FROM [TIME DEP OUTST CLIENT DEALS] where [Product Name] like '%REFINANC%' and [Maturity Date]='" & NextDaySql & "' and [RepDate]='" & MaxRepDateSql & "'"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)

                            If dt.Rows.Count > 0 Then

                                Dim headers As String = "Tomorrow (" & NextDay & "), following refinance sold funded will be matured:" & vbNewLine
                                Dim Footer As String = "(Please see also the attached pdf file with all refinance maturities)" & vbNewLine

                                myBuilder.Append("Contract No:     " & "Client No:  " & "Client Name:                    " & "Maturity Date: " & " Principal Amount + Interest :" & vbNewLine)

                                For i = 0 To dt.Rows.Count - 1
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

                                EItem.Subject = "MATURED REFINANCES on " & " " & NextDay

                                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

                                Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

                                EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
                                EItem.Send()
                                Directory.Delete(ReportExpRefiFile, True)
                                Me.BgwOCBSimport.ReportProgress(18, "Email for Maturities has being sended")
                            End If
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(11, "Parameter:EMAIL_REFI is not valid-No Email Creation")
                    End If
                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: TIME DEPOSIT OUTSTANDING CLIENT DEALS is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:TIME DEPOSIT OUTSTANDING CLIENT DEALS is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_ALL_VOLUMES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT ALL VOLUMES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT ALL VOLUMES' and [Valid]='Y'"
            cmd.Connection.Open()
            cmd.CommandTimeout = 500

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT ALL VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then

                        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("H1").Value = "AccountNo"
                        xlWorksheet1.Range("N1").Value = "DR_CR"
                        xlWorksheet1.Range("O1").Value = "GroupNo"
                        xlWorksheet1.Range("P1").Value = "ClientNo"
                        xlWorksheet1.Range("T1").Value = "ChequeNo"
                        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\ALL_VOLUMES.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        '*************IMPORT ALL VOLUMES************************
                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table ALL_VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [ALL_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim AVDate As String = cmd.ExecuteScalar()

                        If AVDate = "" Then
                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(7, "Start entries Import to table")
                            cmd.CommandText = "INSERT INTO [ALL_VOLUMES] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL"
                            cmd.ExecuteNonQuery()
                            'VolumeDate einfügen in importierten daten
                            Me.BgwOCBSimport.ReportProgress(8, "Insert defined Booking date")
                            cmd.CommandText = "UPDATE [ALL_VOLUMES] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            'UPDATE GL ACCOUNT NAMES IN ALL VOLUMES
                            Me.BgwOCBSimport.ReportProgress(9, "Update General Ledger Account Names from Table: GENERAL LEDGER ACCOUNTS")
                            cmd.CommandText = "UPDATE A SET A.[GL_AC_No_Name]=B.[GL_AC_Name] FROM [ALL_VOLUMES] A INNER JOIN [GENERAL LEDGER ACCOUNTS] B ON A.[GL_AC_No]=B.[GL_AC_No] where A.[GL_AC_No_Name] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(10, "Insert Exchange rates for all entries in all Currencies")
                            cmd.CommandText = "UPDATE A SET A.[Exchange_Rate]=B.[MIDDLE RATE] FROM [ALL_VOLUMES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[CCY]=B.[CURRENCY CODE]  where B.[EXCHANGE RATE DATE]='" & rdsql & "' and A.[GL_Rep_Date]='" & rdsql & "' and A.[CCY] not in ('EUR') and A.[AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [ALL_VOLUMES] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(11, "Calculate Amounts in Euro")
                            cmd.CommandText = "UPDATE [ALL_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT ALL VOLUMES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table ALL_VOLUMES")

                        End If

                        'Import Daily Accruals in ACCRUED INTEREST VOSTRO DEPOSITS
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table ACCRUED INTEREST VOSTRO DEPOSITS")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [ACCRUED INTEREST VOSTRO DEPOSITS] where [GL_Rep_Date]='" & rdsql & "' "
                        AVDate = cmd.ExecuteScalar
                        If AVDate = "" Then
                            Me.BgwOCBSimport.ReportProgress(7, "Start entries Import to table ACCRUED INTEREST VOSTRO DEPOSITS")
                            cmd.CommandText = "INSERT INTO [ACCRUED INTEREST VOSTRO DEPOSITS]([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]) Select [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] from [ALL_VOLUMES] where [Product Type] in ('DDPVOS02','DDPVOS03') and [Description] like '%DAILY ACCRUAL%' and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table ACCRUED INTEREST VOSTRO DEPOSITS")
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT ALL VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_PROFIT_LOSS_VOLUMES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT PROFIT and LOSS VOLUMES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT PROFIT and LOSS VOLUMES' and [Valid]='Y'"
            cmd.Connection.Open()
            cmd.CommandTimeout = 60000


            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT PROFIT and LOSS VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then

                        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("H1").Value = "AccountNo"
                        xlWorksheet1.Range("N1").Value = "DR_CR"
                        xlWorksheet1.Range("O1").Value = "GroupNo"
                        xlWorksheet1.Range("P1").Value = "ClientNo"
                        xlWorksheet1.Range("T1").Value = "ChequeNo"
                        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\PL_VOLUMES.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        '*************IMPORT PROFIT and LOSS VOLUMES************************
                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table PROFIT and LOSS VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim VDate As String = cmd.ExecuteScalar()

                        If VDate = "" Then
                            Me.BgwOCBSimport.ReportProgress(7, "Prepare to import the new Profit and Loss Volumes")
                            'Maximum GL_Rep_Date definieren
                            Me.BgwOCBSimport.ReportProgress(8, "Define the Maximum Booking Date in the Table PROFIT and LOSS VOLUMES ")
                            cmd.CommandText = "SELECT MAX([GL_Rep_Date]) from [PROFIT and LOSS VOLUMES]"
                            Dim LastCBDate As Date = cmd.ExecuteScalar()
                            Dim LastCBDatesql As String = LastCBDate.ToString("yyyyMMdd")

                            'OPENING BALANCES GL ITEM definieren
                            Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balances of the Profit and Loss GL Items to the Table PROFIT and LOSS VOLUMES ")
                            cmd.CommandText = "INSERT INTO [PROFIT and LOSS VOLUMES] ([BatchNo],[Value Date],[CCY],[AmountInEuro],[Exchange_Rate],[GL_Rep_Date],[GL_Item_Nr]) Select 'GL ITEM OPENING BALANCE','" & rdsql & "','EUR',[AmountInEuro],'1','" & rdsql & "',[GL_Item_Nr] from [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & LastCBDatesql & "' and [BatchNo]='GL ITEM CLOSING BALANCE' GROUP BY [GL_Item_Nr],[AmountInEuro]"
                            cmd.ExecuteNonQuery()
                            'OPENING BALANCES OCBS Accounts definieren
                            Me.BgwOCBSimport.ReportProgress(10, "Insert Opening Balances of mapped Profit and Loss General Ledger OCBS Accounts to the Table PROFIT and LOSS VOLUMES ")
                            cmd.CommandText = "INSERT INTO [PROFIT and LOSS VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]) Select 'OPENING BALANCE OCBS ACC.','" & rdsql & "',[CCY],[Amount],[GL_AC_No],'" & rdsql & "',[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] from [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & LastCBDatesql & "' and [BatchNo]='CLOSING BALANCE OCBS ACC.' GROUP BY [GL_AC_No],[CCY],[Amount],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]"
                            cmd.ExecuteNonQuery()
                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(11, "Start Import entries to table")
                            cmd.CommandText = "INSERT INTO [PROFIT and LOSS VOLUMES] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL"
                            cmd.ExecuteNonQuery()
                            'VolumeDate einfügen in importierten daten
                            Me.BgwOCBSimport.ReportProgress(12, "Insert defined Booking date")
                            cmd.CommandText = "UPDATE [PROFIT and LOSS VOLUMES] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            'Maping der GL Items 
                            Me.BgwOCBSimport.ReportProgress(13, "Start mapping of the General Ledger items in Table: PROFIT and LOSS VOLUMES")
                            'cmd.CommandText = "UPDATE [PROFIT and LOSS VOLUMES] SET [GL_Item_Nr]=(Select [GL_ITEM_Mapped] from [PROFIT and LOSS MAPPING] where [PROFIT and LOSS VOLUMES].[GL_AC_No]=[PROFIT and LOSS MAPPING].[GL_ACC_Nr]),[GL_AC_No_Name]=(Select [GL_ACC_Name] from [PROFIT and LOSS MAPPING] where [PROFIT and LOSS VOLUMES].[GL_AC_No]=[PROFIT and LOSS MAPPING].[GL_ACC_Nr]) where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE')"
                            'cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE A SET A.[GL_Item_Nr]=B.[GL_ITEM_Mapped],A.[GL_AC_No_Name]=B.[GL_ACC_Name]  from [PROFIT and LOSS VOLUMES] A INNER JOIN [PROFIT and LOSS MAPPING] B ON  A.[GL_AC_No]=B.[GL_ACC_Nr]  where A.[GL_Rep_Date]='" & rdsql & "' and A.[BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE')"
                            cmd.ExecuteNonQuery()
                            'Exchange Rates definieren(ALLE WÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(14, "Insert Exchange Rates in Table: PROFIT and LOSS VOLUMES")
                            cmd.CommandText = "Select * from [PROFIT and LOSS VOLUMES]  where [GL_Rep_Date]='" & rdsql & "' begin update A SET A.[Exchange_Rate]=B.[MIDDLE RATE] from [PROFIT and LOSS VOLUMES]  A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[CCY]=B.[CURRENCY CODE] where A.[GL_Rep_Date]='" & rdsql & "' and B.[EXCHANGE RATE DATE]='" & rdsql & "' and [AmountInEuro] is NULL end begin update [PROFIT and LOSS VOLUMES] SET [Exchange_Rate]=1 where [CCY]='EUR' and [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL end"
                            cmd.ExecuteNonQuery()

                            'AmountinEuro definieren
                            Me.BgwOCBSimport.ReportProgress(15, "Calculate Amount in Euro for all entries in Table: PROFIT and LOSS VOLUMES")
                            cmd.CommandText = "UPDATE [PROFIT and LOSS VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE') and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            'Nicht relevante Daten löschen
                            Me.BgwOCBSimport.ReportProgress(16, "Delete not relevant entries from the Table: PROFIT and LOSS VOLUMES (GL_ITEM_Nr is NULL)")
                            cmd.CommandText = "DELETE FROM [PROFIT and LOSS VOLUMES] where [GL_Item_Nr] is NULL"
                            cmd.ExecuteNonQuery()
                            'Letzten Saldo ermitteln und einfügen OCBS ACCOUNTS (ALLE WÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(17, "Calculate Closing Balances for all mapped GL OCBS Accounts in all Own Currencies")
                            cmd.CommandText = "INSERT INTO [PROFIT and LOSS VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name]) SELECT 'CLOSING BALANCE OCBS ACC.','" & rdsql & "',A.[CURRENCY CODE],0,0,B.[GL_ACC_Nr],'" & rdsql & "',B.[GL_ITEM_Mapped],B.[GL_ACC_Name] FROM [OWN_CURRENCIES] A,[PROFIT and LOSS MAPPING] B where B.[GL_ACC_Nr] in (Select [GL_AC_No] from [PROFIT and LOSS VOLUMES])GROUP BY A.[CURRENCY CODE],B.[GL_ACC_Nr],B.[GL_ITEM_Mapped],B.[GL_ACC_Name]"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(18, "Insert Exchange Rates")
                            cmd.CommandText = "Select * from [PROFIT and LOSS VOLUMES]  where [GL_Rep_Date]='" & rdsql & "' begin update A SET A.[Exchange_Rate]=B.[MIDDLE RATE] from [PROFIT and LOSS VOLUMES]  A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[CCY]=B.[CURRENCY CODE] where A.[GL_Rep_Date]='" & rdsql & "' and B.[EXCHANGE RATE DATE]='" & rdsql & "' and [AmountInEuro] is NULL end begin update [PROFIT and LOSS VOLUMES] SET [Exchange_Rate]=1 where [CCY]='EUR' and [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL end"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(19, "Calculate Sum(Amount) for GL Accounts")
                            cmd.CommandText = "UPDATE A SET A.[Amount]=B.S from [PROFIT and LOSS VOLUMES] A INNER JOIN (Select [GL_AC_No],[CCY],Sum([Amount]) as S from [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & rdsql & "' group by [GL_AC_No],[CCY]) B on A.[GL_AC_No]=B.[GL_AC_No] where A.[GL_Rep_Date]='" & rdsql & "' and A.[CCY]=B.[CCY] and [BatchNo] in ('CLOSING BALANCE OCBS ACC.')"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(20, "Calculate Sum(AmountinEURO) for GL Accounts")
                            cmd.CommandText = "UPDATE [PROFIT and LOSS VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('CLOSING BALANCE OCBS ACC.') and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()

                            'Closing Balance PROFIT and LOSS GL ITEMS ermitteln 
                            Me.BgwOCBSimport.ReportProgress(21, "Calculate Closing Balances for all Profit and Loss General Ledger Items-Compare GL ITEMS Balance with Balance from the Daily Balance Sheet")
                            cmd.CommandText = "INSERT INTO [PROFIT and LOSS VOLUMES] ([BatchNo],[Value Date],[CCY],[Exchange_Rate],[GL_Rep_Date],[GL_Item_Nr]) SELECT  'GL ITEM CLOSING BALANCE','" & rdsql & "','EUR',1,'" & rdsql & "',[GL_Item_Nr] FROM [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('CLOSING BALANCE OCBS ACC.') GROUP BY [GL_Item_Nr] "
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(22, "Calculate Sum(AmountinEURO) for GL Items")
                            cmd.CommandText = "UPDATE A SET A.[AmountInEuro]=B.S from [PROFIT and LOSS VOLUMES] A INNER JOIN (Select [GL_Item_Nr],Sum([AmountInEuro]) as S from [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [BatchNo]='CLOSING BALANCE OCBS ACC.'  group by [GL_Item_Nr]) B on A.[GL_Item_Nr]=B.[GL_Item_Nr] where A.[GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('GL ITEM CLOSING BALANCE')"
                            cmd.ExecuteNonQuery()

                            Me.BgwOCBSimport.ReportProgress(23, "Delete Items in GL BALANCE RECONCILE")
                            cmd.CommandText = "DELETE  from [GL BALANCES RECONCILE] where [BalanceDate]='" & rdsql & "' and [GL_ITEM] in (Select [GL_Item_Nr] FROM [PROFIT and LOSS VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('GL ITEM CLOSING BALANCE'))"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(24, "Insert Items in GL BALANCE RECONCILE")
                            cmd.CommandText = "INSERT INTO [GL BALANCES RECONCILE] ([GL_ITEM],[BalanceInSQL],[BalanceDate]) Select [GL_Item_Nr],[AmountInEuro],[GL_Rep_Date] from [PROFIT and LOSS VOLUMES] where [BatchNo] in ('GL ITEM CLOSING BALANCE') and  [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(25, "Update BalanceInPL in GL BALANCE RECONCILE")
                            cmd.CommandText = "UPDATE A SET A.[BalanceInPL]=B.[BalanceEUREqu] from [GL BALANCES RECONCILE] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_ITEM]=B.[GL_Item] where A.[BalanceDate]='" & rdsql & "' and B.[BSDate]='" & rdsql & "' "
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(26, "Update GL Items Names in GL BALANCE RECONCILE")
                            cmd.CommandText = "UPDATE [GL BALANCES RECONCILE] SET [GL_ITEM_NAME]=B.[GL_Item_Name] from [GL BALANCES RECONCILE] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_ITEM]=B.[GL_Item] where A.[BalanceDate]=B.[BSDate] and A.[GL_ITEM_NAME] is NULL and A.[BalanceDate]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [GL BALANCES RECONCILE] SET [Difference]=[BalanceInSQL] - [BalanceInPL]  where [Difference] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [GL BALANCES RECONCILE] SET [Difference]=Round([Difference],2) where [Difference]<>0"
                            cmd.ExecuteNonQuery()

                            'Alle OPENING+ CLOSING BALANCES mit 0 löschen
                            Me.BgwOCBSimport.ReportProgress(27, "Delete all Opening and Closing Balances in Table: PROFIT and LOSS VOLUMES where Amount is Zero")
                            'cmdsql.CommandText = "DELETE FROM [PS TOOL].[dbo].[PL_VOLUMES] where [BatchNo] like '%BALANCE' and [AmountInEuro]=0 and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.CommandText = "DELETE FROM [PROFIT and LOSS VOLUMES] where [AmountInEuro]=0 and [GL_Rep_Date]='" & rdsql & "' and [BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE','CLOSING BALANCE OCBS ACC.','OPENING BALANCE OCBS ACC.')"
                            cmd.ExecuteNonQuery()
                            'DR_CR definieren und update nach CLOSING BALANCE
                            Me.BgwOCBSimport.ReportProgress(28, "Update DR_CR Field in Table: PROFIT and LOSS VOLUMES")
                            cmd.CommandText = "SELECT [Amount] from [PROFIT and LOSS VOLUMES] where [DR_CR] is NULL and [GL_Rep_Date]='" & rdsql & "' Begin UPDATE [PROFIT and LOSS VOLUMES] set[DR_CR]='D' where [AmountInEuro]<0 end Begin UPDATE [PROFIT and LOSS VOLUMES] set[DR_CR]='C' where [AmountInEuro]>0 end Begin UPDATE [PROFIT and LOSS VOLUMES] set[DR_CR]='Z' where [AmountInEuro]=0 end"
                            cmd.ExecuteNonQuery()

                            Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT PROFIT and LOSS VOLUMES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table PROFIT and LOSS VOLUMES")

                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT PROFIT and LOSS VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_DIVERSE_VOLUMES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT DIVERSE VOLUMES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT DIVERSE VOLUMES' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT DIVERSE VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then

                        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("H1").Value = "AccountNo"
                        xlWorksheet1.Range("N1").Value = "DR_CR"
                        xlWorksheet1.Range("O1").Value = "GroupNo"
                        xlWorksheet1.Range("P1").Value = "ClientNo"
                        xlWorksheet1.Range("T1").Value = "ChequeNo"
                        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\DIVERSE_VOLUMES.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table DIVERSE VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim VDate As String = cmd.ExecuteScalar()
                        If VDate = "" Then
                            Me.BgwOCBSimport.ReportProgress(7, "Prepare to import the new Diverse Volumes")
                            'Maximum GL_Rep_Date definieren
                            cmd.CommandText = "SELECT MAX([GL_Rep_Date]) from [DIVERSE_VOLUMES]"
                            Dim LastCBDate As Date = cmd.ExecuteScalar()
                            Dim LastCBDatesql As String = LastCBDate.ToString("yyyyMMdd")
                            'OPENING BALANCES GL ITEM definieren
                            Me.BgwOCBSimport.ReportProgress(8, "Insert Opening Ledger Balances of the Diverse GL Items to the Table DIVERSE VOLUMES ")
                            cmd.CommandText = "INSERT INTO [DIVERSE_VOLUMES] ([BatchNo],[Value Date],[CCY],[AmountInEuro],[Exchange_Rate],[GL_Rep_Date],[GL_Item_Nr]) Select 'GL ITEM OPENING BALANCE','" & rdsql & "','EUR',[AmountInEuro],'1','" & rdsql & "',[GL_Item_Nr] from [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & LastCBDatesql & "' and [BatchNo]='GL ITEM CLOSING BALANCE' GROUP BY [GL_Item_Nr],[AmountInEuro]"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Balances of the Diverse GL OCBS Accounts to the Table DIVERSE VOLUMES ")
                            cmd.CommandText = "INSERT INTO [DIVERSE_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]) Select 'OPENING BALANCE OCBS ACC.','" & rdsql & "',[CCY],[Amount],[GL_AC_No],'" & rdsql & "',[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] from [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & LastCBDatesql & "' and [BatchNo]='CLOSING BALANCE OCBS ACC.' GROUP BY [GL_AC_No],[CCY],[Amount],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]"
                            cmd.ExecuteNonQuery()
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Importieren in dem SQL SERVER Tabelle [OTHER_VOLUMES]
                            Me.BgwOCBSimport.ReportProgress(11, "Start Import entries to table")
                            cmd.CommandText = "INSERT INTO [DIVERSE_VOLUMES] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL"
                            cmd.ExecuteNonQuery()
                            'VolumeDate einfügen in importierten daten
                            Me.BgwOCBSimport.ReportProgress(12, "Insert defined Booking date")
                            cmd.CommandText = "UPDATE [DIVERSE_VOLUMES] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            'Maping der GL Items 
                            Me.BgwOCBSimport.ReportProgress(13, "Start mapping of the General Ledger items in Table: DIVERSE VOLUMES")
                            cmd.CommandText = "UPDATE A SET A.[GL_Item_Nr]=B.[GL_ITEM_Mapped],A.[GL_AC_No_Name]=B.[GL_ACC_Name]  from [DIVERSE_VOLUMES] A INNER JOIN [DIVERSE_MAPPING] B ON  A.[GL_AC_No]=B.[GL_ACC_Nr]  where A.[GL_Rep_Date]='" & rdsql & "' and A.[BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE')"
                            cmd.ExecuteNonQuery()
                            'Exchange Rates definieren
                            Me.BgwOCBSimport.ReportProgress(14, "Insert Exchange Rates in Table: DIVERSE VOLUMES")
                            cmd.CommandText = "Select * from [DIVERSE_VOLUMES]  where [GL_Rep_Date]='" & rdsql & "' begin update A SET A.[Exchange_Rate]=B.[MIDDLE RATE] from [DIVERSE_VOLUMES]  A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[CCY]=B.[CURRENCY CODE] where A.[GL_Rep_Date]='" & rdsql & "' and B.[EXCHANGE RATE DATE]='" & rdsql & "' and [AmountInEuro] is NULL end begin update [DIVERSE_VOLUMES] SET [Exchange_Rate]=1 where [CCY]='EUR' and [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL end"
                            cmd.ExecuteNonQuery()
                            'AmountinEuro definieren
                            Me.BgwOCBSimport.ReportProgress(15, "Calculate Amount in Euro for all entries in Table: DIVERSE VOLUMES")
                            cmd.CommandText = "UPDATE [DIVERSE_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE') and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            'Nicht relevante Daten löschen
                            Me.BgwOCBSimport.ReportProgress(16, "Delete not relevant entries from the Table: DIVERSE VOLUMES (GL_ITEM_Nr is NULL)")
                            cmd.CommandText = "DELETE FROM [DIVERSE_VOLUMES] where [GL_Item_Nr] is NULL"
                            cmd.ExecuteNonQuery()
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen OCBS ACCOUNTS (FREMDWÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(17, "Calculate Closing Balances for all mapped GL OCBS Accounts in all Own Currencies")
                            cmd.CommandText = "INSERT INTO [DIVERSE_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name]) SELECT 'CLOSING BALANCE OCBS ACC.','" & rdsql & "',A.[CURRENCY CODE],0,0,B.[GL_ACC_Nr],'" & rdsql & "',B.[GL_ITEM_Mapped],B.[GL_ACC_Name] FROM [OWN_CURRENCIES] A,[DIVERSE_MAPPING] B where B.[GL_ACC_Nr] in (Select [GL_AC_No] from [DIVERSE_VOLUMES])GROUP BY A.[CURRENCY CODE],B.[GL_ACC_Nr],B.[GL_ITEM_Mapped],B.[GL_ACC_Name]"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(18, "Insert Exchange Rates")
                            cmd.CommandText = "Select * from [DIVERSE_VOLUMES]  where [GL_Rep_Date]='" & rdsql & "' begin update A SET A.[Exchange_Rate]=B.[MIDDLE RATE] from [DIVERSE_VOLUMES]  A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[CCY]=B.[CURRENCY CODE] where A.[GL_Rep_Date]='" & rdsql & "' and B.[EXCHANGE RATE DATE]='" & rdsql & "' and [AmountInEuro] is NULL end begin update [DIVERSE_VOLUMES] SET [Exchange_Rate]=1 where [CCY]='EUR' and [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL end"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(19, "Calculate Sum(Amount) for GL Accounts")
                            cmd.CommandText = "UPDATE A SET A.[Amount]=B.S from [DIVERSE_VOLUMES] A INNER JOIN (Select [GL_AC_No],[CCY],Sum([Amount]) as S from [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' group by [GL_AC_No],[CCY]) B on A.[GL_AC_No]=B.[GL_AC_No] where A.[GL_Rep_Date]='" & rdsql & "' and A.[CCY]=B.[CCY] and [BatchNo] in ('CLOSING BALANCE OCBS ACC.')"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(20, "Calculate Sum(AmountinEURO) for GL Accounts")
                            cmd.CommandText = "UPDATE [DIVERSE_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('CLOSING BALANCE OCBS ACC.') and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()



                            'CLOSING BALANCES GL ITEM definieren
                            Me.BgwOCBSimport.ReportProgress(20, "Calculate Closing Balances for all Diverse General Ledger Items-Compare GL ITEMS Balance with Balance from the Daily Balance Sheet")
                            cmd.CommandText = "INSERT INTO [DIVERSE_VOLUMES] ([BatchNo],[Value Date],[CCY],[Exchange_Rate],[GL_Rep_Date],[GL_Item_Nr]) SELECT  'GL ITEM CLOSING BALANCE','" & rdsql & "','EUR',1,'" & rdsql & "',[GL_Item_Nr] FROM [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('CLOSING BALANCE OCBS ACC.') GROUP BY [GL_Item_Nr] "
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(21, "Calculate Sum(AmountinEURO) for GL Items")
                            cmd.CommandText = "UPDATE A SET A.[AmountInEuro]=B.S from [DIVERSE_VOLUMES] A INNER JOIN (Select [GL_Item_Nr],Sum([AmountInEuro]) as S from [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [BatchNo]='CLOSING BALANCE OCBS ACC.'  group by [GL_Item_Nr]) B on A.[GL_Item_Nr]=B.[GL_Item_Nr] where A.[GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('GL ITEM CLOSING BALANCE')"
                            cmd.ExecuteNonQuery()

                            Me.BgwOCBSimport.ReportProgress(23, "Delete Items in GL BALANCE RECONCILE")
                            cmd.CommandText = "DELETE  from [GL BALANCES RECONCILE] where [BalanceDate]='" & rdsql & "' and [GL_ITEM] in (Select [GL_Item_Nr] FROM [DIVERSE_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] in ('GL ITEM CLOSING BALANCE'))"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(24, "Insert Items in GL BALANCE RECONCILE")
                            cmd.CommandText = "INSERT INTO [GL BALANCES RECONCILE] ([GL_ITEM],[BalanceInSQL],[BalanceDate]) Select [GL_Item_Nr],[AmountInEuro],[GL_Rep_Date] from [DIVERSE_VOLUMES] where [BatchNo] in ('GL ITEM CLOSING BALANCE') and  [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(25, "Update BalanceInPL in GL BALANCE RECONCILE")
                            cmd.CommandText = "UPDATE A SET A.[BalanceInPL]=B.[BalanceEUREqu] from [GL BALANCES RECONCILE] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_ITEM]=B.[GL_Item] where A.[BalanceDate]='" & rdsql & "' and B.[BSDate]='" & rdsql & "' "
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(26, "Update GL Items Names in GL BALANCE RECONCILE")
                            cmd.CommandText = "UPDATE [GL BALANCES RECONCILE] SET [GL_ITEM_NAME]=B.[GL_Item_Name] from [GL BALANCES RECONCILE] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_ITEM]=B.[GL_Item] where A.[BalanceDate]=B.[BSDate] and A.[GL_ITEM_NAME] is NULL and A.[BalanceDate]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [GL BALANCES RECONCILE] SET [Difference]=[BalanceInSQL] - [BalanceInPL]  where [Difference] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [GL BALANCES RECONCILE] SET [Difference]=Round([Difference],2) where [Difference]<>0"
                            cmd.ExecuteNonQuery()

                            'Alle OPENING+ CLOSING BALANCES mit 0 löschen
                            Me.BgwOCBSimport.ReportProgress(27, "Delete all Opening and Closing Balances in Table: DIVERSE VOLUMES where Amount is Zero")
                            cmd.CommandText = "DELETE FROM [DIVERSE_VOLUMES] where [AmountInEuro]=0 and [GL_Rep_Date]='" & rdsql & "' and [BatchNo] not in ('GL ITEM CLOSING BALANCE','GL ITEM OPENING BALANCE','CLOSING BALANCE OCBS ACC.','OPENING BALANCE OCBS ACC.')"
                            cmd.ExecuteNonQuery()
                            'DR_CR definieren und update nach CLOSING BALANCE
                            Me.BgwOCBSimport.ReportProgress(28, "Update DR_CR Field in Table: DIVERSE VOLUMES")
                            cmd.CommandText = "SELECT [Amount] from [DIVERSE_VOLUMES] where [DR_CR] is NULL and [GL_Rep_Date]='" & rdsql & "' Begin UPDATE [DIVERSE_VOLUMES] set[DR_CR]='D' where [AmountInEuro]<0 end Begin UPDATE [DIVERSE_VOLUMES] set[DR_CR]='C' where [AmountInEuro]>0 end Begin UPDATE [DIVERSE_VOLUMES] set[DR_CR]='Z' where [AmountInEuro]=0 end"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT DIVERSE VOLUMES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table DIVERSE VOLUMES")

                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT DIVERSE VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_CUSTOMER_VOLUMES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT CUSTOMER VOLUMES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT CUSTOMER VOLUMES' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT CUSTOMER VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("H1").Value = "AccountNo"
                        xlWorksheet1.Range("N1").Value = "DR_CR"
                        xlWorksheet1.Range("O1").Value = "GroupNo"
                        xlWorksheet1.Range("P1").Value = "ClientNo"
                        xlWorksheet1.Range("T1").Value = "ChequeNo"
                        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\CUSTOMER_VOLUMES.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        'xlWorkBook.SaveAs("C:\Volumes.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        'Prüfen ob Zinsabgrenzungen GIROKONTEN vorhanden sind
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [ACCRUED INTEREST DEMAND DEPOSITS] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim ZDate As String = cmd.ExecuteScalar
                        If ZDate = "" Then
                            'IMPORTIEREN ZINSABGRENZUNGEN FÜR GIROKONTEN
                            Me.BgwOCBSimport.ReportProgress(6, "Start Import entries to table")
                            cmd.CommandText = "INSERT INTO [ACCRUED INTEREST DEMAND DEPOSITS] ([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],' " & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & rdsql & "') and [GL_AC_No] in ('25109212','17200212') and [Product Type] in ('DDPCUR01','DDPCUR02') and  [Description] not like 'INTEREST%'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(6, "Update Event Typein Table ACCRUED INTEREST DEMAND DEPOSITS")
                            cmd.CommandText = "BEGIN UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [Event Type]='DR',[DR_CR]='D' where [Amount]<0 END BEGIN UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [Event Type]='CR',[DR_CR]='C' where [Amount]>=0 END"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(6, "Insert Exchange Rates in Table: ACCRUED INTEREST DEMAND DEPOSITS")
                            cmd.CommandText = "UPDATE A  SET A.[Exchange_Rate]=B.[MIDDLE RATE] FROM [ACCRUED INTEREST DEMAND DEPOSITS] A INNER JOIN [EXCHANGE RATES OCBS] B ON  A.[GL_Rep_Date]=B.[EXCHANGE RATE DATE] where A.[CCY]=B.[CURRENCY CODE] and  A.[GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(6, "Calculate Amount in Euro for all entries in Table: ACCRUED INTEREST DEMAND DEPOSITS")
                            cmd.CommandText = "UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE A set A.[GL_AC_No_Name]=B.[English Name] from [ACCRUED INTEREST DEMAND DEPOSITS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where  [GL_AC_No_Name] is NULL"
                            cmd.ExecuteNonQuery()
                        End If

                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table CUSTOMER VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim VDate As String = cmd.ExecuteScalar()
                        If VDate = "" Then
                            Me.BgwOCBSimport.ReportProgress(7, "Prepare to import the new Customer Volumes")
                            'Maximum GL_Rep_Date definieren
                            cmd.CommandText = "SELECT MAX([GL_Rep_Date]) from [CUSTOMER_VOLUMES]"
                            Dim LastCBDate As Date = cmd.ExecuteScalar()
                            Dim LastCBDateSql As String = LastCBDate.ToString("yyyyMMdd")
                            'OPENNING BALANCES CUSTOMER ACCOUNTS
                            Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balances to the Table CUSTOMER VOLUMES")
                            QueryText = "SELECT  [IdNr],[BatchNo],[GL_AC_No],[Value Date],[AccountNo],[CCY],[Amount],[DR_CR],[GL_Rep_Date],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] FROM [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & LastCBDateSql & "' and [BatchNo]='CLOSING BALANCE' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & LastCBDateSql & "')"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                'Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balance for Customer Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro])Values('OPENING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(dt.Rows.Item(i).Item("Amount")) & "," & Str(dt.Rows.Item(i).Item("GL_AC_No")) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "','" & dt.Rows.Item(i).Item("GL_AC_No_Name") & "'," & Str(dt.Rows.Item(i).Item("Exchange_Rate")) & "," & Str(dt.Rows.Item(i).Item("AmountInEuro")) & ")"
                                cmd.ExecuteNonQuery()
                            Next
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(11, "Start Import entries to table")
                            cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],' " & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & rdsql & "') and [GL_AC_No]='23009212' and [BatchNo] like '0%'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(12, "Insert defined Booking date")
                            'VolumeDate einfügen in importierten daten
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            'UPDATE CUSTOMER ACCOUNT NAMES IN CUSTOMER_VOLUMES
                            Me.BgwOCBSimport.ReportProgress(13, "Update Customer Account Names in Table CUSTOMER_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name],[Product Type]=B.[ProductCode] from [CUSTOMER_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account]"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(14, "Update Event Typein Table CUSTOMER_VOLUMES")
                            cmd.CommandText = "BEGIN UPDATE [CUSTOMER_VOLUMES] SET [Event Type]='DR',[DR_CR]='D' where [Amount]<0 END BEGIN UPDATE [CUSTOMER_VOLUMES] SET [Event Type]='CR',[DR_CR]='C' where [Amount]>=0 END"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(14, "Insert Exchange Rates in Table: CUSTOMER_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] SET [Exchange_Rate]=(Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [CUSTOMER_VOLUMES].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]='" & rdsql & "') where [GL_Rep_Date]='" & rdsql & "' and [CCY]<>'EUR' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(15, "Calculate Amount in Euro for all entries in Table: CUSTOMER_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()

                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(17, "Calculate Closing Balances for all Customer Accounts (Not EURO)")
                            QueryText = "SELECT Distinct([AccountNo]),[CCY] from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY] not in ('EUR') "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                'Me.BgwOCBSimport.ReportProgress(18, "Calculating Closing Ledger Balance for Customer Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                Dim a As Double
                                Dim b As Double
                                Dim c As Double
                                Dim d1 As Double 'New Amount in Euro
                                'Exchange Rate
                                cmd.CommandText = "Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [EXCHANGE RATES OCBS].[CURRENCY CODE]='" & dt.Rows.Item(i).Item("CCY") & "' and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]='" & rdsql & "'"
                                c = cmd.ExecuteScalar
                                cmd.CommandText = "SELECT SUM([Amount]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    a = cmd.ExecuteScalar
                                    'Summe Amount in Euro
                                    cmd.CommandText = "SELECT SUM([AmountInEuro]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                    b = cmd.ExecuteScalar
                                    d1 = Math.Round(a / c, 2) 'Neu berechneter Betrag in Euro
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'23009212','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                Else
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "','0','0'," & Str(c) & ",'23009212','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(19, "Calculate Closing Balances for all Customer Accounts (in EURO)")
                            QueryText = "SELECT Distinct([AccountNo]),[CCY] from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY] in ('EUR') "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                'Me.BgwOCBSimport.ReportProgress(19, "Calculating Closing Ledger Balance for Customer Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                Dim a As Double
                                Dim b As Double
                                Dim c As Double = 1
                                Dim d1 As Double 'New Amount in Euro
                                cmd.CommandText = "SELECT SUM([Amount]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    a = cmd.ExecuteScalar
                                    'Summe Amount in Euro
                                    cmd.CommandText = "SELECT SUM([AmountInEuro]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                    b = cmd.ExecuteScalar
                                    d1 = Math.Round(a / c, 2) 'Neu berechneter Betrag in Euro
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'23009212','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                Else
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "','0','0'," & Str(c) & ",'23009212','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            Me.BgwOCBSimport.ReportProgress(20, "Update Client Name in Table CUSTOMER_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name],[Product Type]=B.[ProductCode] from [CUSTOMER_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where [GL_Rep_Date]='" & rdsql & "' and [GL_AC_No_Name] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(50, "Delete from Table CUSTOMER_VOLUMES where Product Type is not Current Account ")
                            cmd.CommandText = "DELETE FROM [CUSTOMER_VOLUMES]  where [Product Type] not in ('DDPCUR01','DDPCUR02') and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(20, "Extract PAYMENT REFERENCE in CUSTOMER_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] SET [PaymentReference]=Substring([Description],0,16) where ([Description] like 'DEI%' or [Description] like 'DEO%') and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()

                            '****************************************************************************************************************
                            'Calculate Sum of Demand Deposits (CUSTOMERS)
                            Me.BgwOCBSimport.ReportProgress(60, "Calculate Sum of Customer Demand Deposits")
                            cmd.CommandText = "Select sum([AmountInEuro]) from   [CUSTOMER_VOLUMES] where   [BatchNo]='CLOSING BALANCE' and [AmountInEuro]>0 and [GL_Rep_Date]='" & rdsql & "'"
                            Dim fxp As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                fxp = cmd.ExecuteScalar
                            Else
                                fxp = 0
                            End If
                            'EINFÜGEN IN RISK LIMIT DAILY CONTROL
                            Me.BgwOCBSimport.ReportProgress(70, "Insert Sum of Customer Demand Deposits in RISK LIMIT DAILY CONTROL")
                            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                            Dim t As String = cmd.ExecuteScalar
                            If IsNothing(t) = False Then
                                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Bank Bilanz]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsql & "'"
                                cmd.ExecuteNonQuery()
                            End If
                            If IsNothing(t) = True Then
                                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Bank Bilanz]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                                cmd.ExecuteNonQuery()
                            End If
                            '*********************************************************************************************************************

                            Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT CUSTOMER VOLUMES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table CUSTOMER_VOLUMES")
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT CUSTOMER VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_SUSPENCE_BALANCES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT SUSPENCE BALANCES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT SUSPENCE BALANCES' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT SUSPENCE BALANCES")

                cmd.CommandText = "SELECT Max([ID]) FROM [SUSPENCE_BALANCES] WHERE [BalanceDate]='" & rdsql & "'"

                'Dim AV As String = cmd.ExecuteScalar
                If cmd.ExecuteScalar Is DBNull.Value Then

                    Dim ExcelFileName As String = ""
                    ExcelFileName = Me.OCBS_Temp_Directory & "\DD-D-025 - Suspense Account Balance Exception Report-en.xls"
                    If File.Exists(ExcelFileName) = True Then
                        Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \DD-D-025 - Suspense Account Balance Exception Report-en.xls")
                        'Excel Datei Öffnen und Datenformat ändern
                        EXCELL = CreateObject("Excel.Application")
                        xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                        xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                        EXCELL.Visible = False

                        'Prüfen ob Daten vorhanden sind
                        If xlWorksheet1.Range("D2").Value.ToString.StartsWith("Suspense Account Balance Exception Report") = True Then

                            Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                            'Unmerge Cells
                            xlWorksheet1.Columns("A:A").unMerge()
                            xlWorksheet1.Rows("1:4").delete()
                            xlWorksheet1.Range("A1").Value = "Suspence_Acc_Nr"
                            xlWorksheet1.Range("B1").Value = "Suspence_Acc_Name"
                            xlWorksheet1.Range("C1").Value = "Currency"
                            xlWorksheet1.Range("D1").Value = "Ledger_Balance"

                            EXCELL.Application.DisplayAlerts = False
                            Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\SUSPENCE_BALANCES.xls"
                            xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                            EXCELL.Application.DisplayAlerts = True
                            xlWorkBook.Close()

                            EXCELL.Quit()
                            EXCELL = Nothing

                            'Excel Instanz beenden
                            Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                            Dim i1 As Short
                            i1 = 0
                            For i1 = 0 To (procs.Length - 1)
                                procs(i1).Kill()
                            Next i1
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            Me.BgwOCBSimport.ReportProgress(5, "Excel File: \DD-D-025 - Suspense Account Balance Exception Report-en.xls reformated sucesfully")

                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(7, "Start entries Import to table")
                            cmd.CommandText = "INSERT INTO [SUSPENCE_BALANCES]([Suspence_Acc_Nr],[Suspence_Acc_Name],[Currency],[Ledger_Balance],[BalanceDate]) SELECT [Suspence_Acc_Nr],[Suspence_Acc_Name],[Currency],[Ledger_Balance],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Suspence_Acc_Nr],[Suspence_Acc_Name],[Currency],[Ledger_Balance] FROM [Sheet1$] where [Account Centre] is not NULL') "
                            cmd.ExecuteNonQuery()
                            'UPDATE GL ACCOUNT NAMES IN ALL VOLUMES
                            Me.BgwOCBSimport.ReportProgress(9, "Update General Ledger Account Names from Table: GENERAL LEDGER ACCOUNTS")
                            cmd.CommandText = "UPDATE A SET A.[Suspence_Acc_Name]=B.[English Name],A.[ClientNr]=B.[ClientNo] from [SUSPENCE_BALANCES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Suspence_Acc_Nr]=B.[Client Account] where A.[Currency]=B.[Deal Currency] and A.[BalanceDate]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(10, "Insert Exchange rates for all entries in all Currencies")
                            cmd.CommandText = "UPDATE A SET A.[Exchange_Rate]=B.[MIDDLE RATE] FROM [SUSPENCE_BALANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[Currency]=B.[CURRENCY CODE]  where B.[EXCHANGE RATE DATE]='" & rdsql & "' and A.[BalanceDate]='" & rdsql & "' and A.[Currency] not in ('EUR')"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [SUSPENCE_BALANCES] SET [Exchange_Rate]='1' where [BalanceDate]='" & rdsql & "' and [Currency]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(11, "Calculate Amounts in Euro")
                            cmd.CommandText = "UPDATE [SUSPENCE_BALANCES] SET [Ledger_Balance_EUR]=Round([Ledger_Balance]/Exchange_Rate,2) where [BalanceDate]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(12, "IMPORT SUSPENCE BALANACES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                    End If

                Else
                    Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table SUSPENCE_BALANCES")
                End If

            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT SUSPENCE BALANCES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_CUSTOMER_VOSTRO_VOLUMES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT CUSTOMER VOSTRO VOLUMES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd.Connection.Open()
            cmd.CommandTimeout = 60000

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT CUSTOMER VOSTRO VOLUMES' and [Valid]='Y'"
            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT CUSTOMER VOSTRO VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("H1").Value = "AccountNo"
                        xlWorksheet1.Range("N1").Value = "DR_CR"
                        xlWorksheet1.Range("O1").Value = "GroupNo"
                        xlWorksheet1.Range("P1").Value = "ClientNo"
                        xlWorksheet1.Range("T1").Value = "ChequeNo"
                        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\CUSTOMER_VOSTRO_VOLUMES.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table CUSTOMER VOSTRO VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim VDate As String = cmd.ExecuteScalar()
                        If VDate = "" Then
                            Me.BgwOCBSimport.ReportProgress(7, "Prepare to import the new Customer Vostro Volumes")
                            'Maximum GL_Rep_Date definieren
                            cmd.CommandText = "SELECT MAX([GL_Rep_Date]) from [CUSTOMER_VOSTRO_VOLUMES]"
                            Dim LastCBDate As Date = cmd.ExecuteScalar()
                            Dim LastCBDateSql As String = LastCBDate.ToString("yyyyMMdd")
                            'OPENNING BALANCES CUSTOMER ACCOUNTS
                            Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balances to the Table CUSTOMER VOSTRO VOLUMES")
                            QueryText = "SELECT  [IdNr],[BatchNo],[GL_AC_No],[Value Date],[AccountNo],[CCY],[Amount],[DR_CR],[GL_Rep_Date],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] FROM [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & LastCBDateSql & "' and [BatchNo]='CLOSING BALANCE' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & LastCBDateSql & "')"
                            'da = New SqlDataAdapter(QueryText.Trim(), conn)
                            '******************************************************************
                            'New Test Code
                            Dim da As SqlDataAdapter
                            Dim objCMD As SqlCommand = New SqlCommand(QueryText.Trim(), conn)
                            objCMD.CommandTimeout = 5000
                            da = New SqlDataAdapter(objCMD)
                            'da.SelectCommand = objCMD
                            '*******************************************************************
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balance for Vostro Customer Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro])Values('OPENING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(dt.Rows.Item(i).Item("Amount")) & "," & Str(dt.Rows.Item(i).Item("GL_AC_No")) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "','" & dt.Rows.Item(i).Item("GL_AC_No_Name") & "'," & Str(dt.Rows.Item(i).Item("Exchange_Rate")) & "," & Str(dt.Rows.Item(i).Item("AmountInEuro")) & ")"
                                cmd.ExecuteNonQuery()
                            Next
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'NEW CODE
                            'cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]) Select 'OPENING BALANCE','" & rdsql & "',[CCY],[Amount],[GL_AC_No],'" & rdsql & "',[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & LastCBDateSql & "' and [BatchNo]='CLOSING BALANCE' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & LastCBDateSql & "') GROUP BY [AccountNo],[AmountInEuro],[CCY],[Amount],[GL_AC_No],[GL_AC_No_Name],[Exchange_Rate]"
                            'cmd.ExecuteNonQuery()


                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(11, "Start Import entries to table")
                            cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES]([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date] FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & rdsql & "') and [GL_AC_No] in ('22009211','22010211','27010213','27012213')"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(12, "Insert defined Booking date")
                            'VolumeDate einfügen in importierten daten
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            'UPDATE CUSTOMER ACCOUNT NAMES IN CUSTOMER_VOLUMES
                            Me.BgwOCBSimport.ReportProgress(13, "Update Customer Account Names in Table CUSTOMER_VOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name],[Product Type]=B.[ProductCode] from [CUSTOMER_VOSTRO_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account]"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(14, "Update Event Type in Table CUSTOMER_VOSTRO_VOLUMES")
                            cmd.CommandText = "BEGIN UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [Event Type]='DR',[DR_CR]='D' where [Amount]<0 END BEGIN UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [Event Type]='CR',[DR_CR]='C' where [Amount]>=0 END"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(14, "Insert Exchange Rates in Table: CUSTOMER_VOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [Exchange_Rate]=(Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [CUSTOMER_VOSTRO_VOLUMES].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]='" & rdsql & "') where [GL_Rep_Date]='" & rdsql & "' and [CCY]<>'EUR' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(15, "Calculate Amount in Euro for all entries in Table: CUSTOMER_VOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()

                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(17, "Calculate Closing Balances for all Vostro Customer Accounts (Not EURO)")
                            QueryText = "SELECT Distinct([AccountNo]),[CCY] from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY] not in ('EUR') "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                Me.BgwOCBSimport.ReportProgress(18, "Calculating Closing Ledger Balance for Vostro Customer Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                Dim a As Double
                                Dim b As Double
                                Dim c As Double
                                Dim d1 As Double 'New Amount in Euro
                                'Exchange Rate
                                cmd.CommandText = "Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [EXCHANGE RATES OCBS].[CURRENCY CODE]='" & dt.Rows.Item(i).Item("CCY") & "' and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]='" & rdsql & "'"
                                c = cmd.ExecuteScalar
                                cmd.CommandText = "SELECT SUM([Amount]) from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    a = cmd.ExecuteScalar
                                    'Summe Amount in Euro
                                    cmd.CommandText = "SELECT SUM([AmountInEuro]) from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                    b = cmd.ExecuteScalar
                                    d1 = Math.Round(a / c, 2) 'Neu berechneter Betrag in Euro
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                Else
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "','0','0'," & Str(c) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (EURO)
                            Me.BgwOCBSimport.ReportProgress(19, "Calculate Closing Balances for all Customer Vostro Accounts (in EURO)")
                            QueryText = "SELECT Distinct([AccountNo]),[CCY] from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY] in ('EUR') "
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                Me.BgwOCBSimport.ReportProgress(19, "Calculating Closing Ledger Balance for Customer Vostro Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                Dim a As Double
                                Dim b As Double
                                Dim c As Double = 1
                                Dim d1 As Double 'New Amount in Euro
                                cmd.CommandText = "SELECT SUM([Amount]) from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    a = cmd.ExecuteScalar
                                    'Summe Amount in Euro
                                    cmd.CommandText = "SELECT SUM([AmountInEuro]) from [CUSTOMER_VOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CCY") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("AccountNo") & "'"
                                    b = cmd.ExecuteScalar
                                    d1 = Math.Round(a / c, 2) 'Neu berechneter Betrag in Euro
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                Else
                                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "','0','0'," & Str(c) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            Me.BgwOCBSimport.ReportProgress(20, "Update Client Name in Table CUSTOMER_VOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name],[Product Type]=B.[ProductCode] from [CUSTOMER_VOSTRO_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where [GL_Rep_Date]='" & rdsql & "' and [GL_AC_No_Name] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(50, "Delete from Table CUSTOMER_VOSTRO_VOLUMES where Product Type is not Current Account ")
                            cmd.CommandText = "DELETE FROM [CUSTOMER_VOSTRO_VOLUMES]  where [Product Type] not in ('DDPVOS02','DDPVOS03') and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(20, "Extract PAYMENT REFERENCE in CUSTOMER_VOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [PaymentReference]=Substring([Description],0,16) where ([Description] like 'DEI%' or [Description] like 'DEO%') and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT CUSTOMER VOSTRO VOLUMES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table CUSTOMER_VOSTRO_VOLUMES")
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT CUSTOMER VOSTRO VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_NOSTRO_VOLUMES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT NOSTRO VOLUMES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT NOSTRO VOLUMES' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: IMPORT NOSTRO VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("H1").Value = "AccountNo"
                        xlWorksheet1.Range("N1").Value = "DR_CR"
                        xlWorksheet1.Range("O1").Value = "GroupNo"
                        xlWorksheet1.Range("P1").Value = "ClientNo"
                        xlWorksheet1.Range("T1").Value = "ChequeNo"
                        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\NOSTRO_VOLUMES.xls"
                        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        EXCELL.Application.DisplayAlerts = True
                        xlWorkBook.Close()

                        EXCELL.Quit()
                        EXCELL = Nothing

                        'Excel Instanz beenden
                        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        Dim i1 As Short
                        i1 = 0
                        For i1 = 0 To (procs.Length - 1)
                            procs(i1).Kill()
                        Next i1
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table NOSTRO VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [NOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim VDate As String = cmd.ExecuteScalar()
                        If VDate = "" Then
                            Me.BgwOCBSimport.ReportProgress(7, "Prepare to import the new Nostro Volumes")
                            'Maximum GL_Rep_Date definieren
                            cmd.CommandText = "SELECT MAX([GL_Rep_Date]) from [NOSTRO_VOLUMES]"
                            Dim LastCBDate As Date = cmd.ExecuteScalar()
                            Dim LastCBDateSql As String = LastCBDate.ToString("yyyyMMdd")
                            'OPENNING BALANCES CUSTOMER ACCOUNTS
                            Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balances to the Table NOSTRO VOLUMES")
                            QueryText = "SELECT  [IdNr],[BatchNo],[GL_AC_No],[Value Date],[AccountNo],[CCY],[Amount],[DR_CR],[GL_Rep_Date],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] FROM [NOSTRO_VOLUMES] where [GL_Rep_Date]='" & LastCBDateSql & "' and [BatchNo]='CLOSING LEDGER BALANCE'"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balance for Nostro Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                                cmd.CommandText = "INSERT INTO [NOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro])Values('OPENING LEDGER BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(dt.Rows.Item(i).Item("Amount")) & "," & Str(dt.Rows.Item(i).Item("GL_AC_No")) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "','" & dt.Rows.Item(i).Item("GL_AC_No_Name") & "'," & Str(dt.Rows.Item(i).Item("Exchange_Rate")) & "," & Str(dt.Rows.Item(i).Item("AmountInEuro")) & ")"
                                cmd.ExecuteNonQuery()
                            Next
                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(11, "Start Import entries to table NOSTRO VOLUMES")
                            cmd.CommandText = "INSERT INTO [NOSTRO_VOLUMES] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [NOSTRO_VOLUMES$]') where [Accounting Centre] is not NULL and [AccountNo] in (Select [INTERNAL ACCOUNT] from [SSIS]) and [GL_AC_No] in (Select [GL_CODE] from [SSIS]) "
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(12, "Insert defined Booking date")
                            'VolumeDate einfügen in importierten daten
                            cmd.CommandText = "UPDATE [NOSTRO_VOLUMES] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                            cmd.ExecuteNonQuery()
                            'UPDATE CUSTOMER ACCOUNT NAMES IN CUSTOMER_VOLUMES
                            Me.BgwOCBSimport.ReportProgress(13, "Update Nostro Account Names in Table NOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE A SET A.[GL_AC_No_Name]=B.[CORRESPONDENT NAME] from [NOSTRO_VOLUMES] A INNER JOIN [SSIS] B ON A.[AccountNo]=B.[INTERNAL ACCOUNT] where A.[GL_AC_No_Name] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(14, "REVERSE Debit/Credit Entry for all Nostro Accounts Volumes")
                            cmd.CommandText = "UPDATE [NOSTRO_VOLUMES] SET [Amount]=[Amount]*(-1) where [GL_Rep_Date]='" & rdsql & "' and [BatchNo] not like '%BALANCE%'"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "BEGIN UPDATE [NOSTRO_VOLUMES] SET [Event Type]='DR',[DR_CR]='D' where [Amount]<0 END BEGIN UPDATE [NOSTRO_VOLUMES] SET [Event Type]='CR',[DR_CR]='C' where [Amount]>=0 END"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(14, "Import Exchange Rates in Table NOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE A SET A.[Exchange_Rate]=B.[MIDDLE RATE] from [NOSTRO_VOLUMES] A INNER JOIN [EXCHANGE RATES OCBS] B ON B.[EXCHANGE RATE DATE]='" & rdsql & "' where A.[CCY]=B.[CURRENCY CODE] and  A.[GL_Rep_Date]='" & rdsql & "' and A.[CCY]<>'EUR' and A.[AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [NOSTRO_VOLUMES] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(15, "Calculate Amount in Euro for all entries in Table: NOSTRO_VOLUMES")
                            cmd.CommandText = "UPDATE [NOSTRO_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()

                            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(17, "Calculate Closing Ledger Balances for all Nostro Accounts (Not EURO)")
                            QueryText = "SELECT * FROM [SSIS] where [INTERNAL ACCOUNT] in (Select [AccountNo] from [NOSTRO_VOLUMES]) and [CURRENCY CODE] not in ('EUR')"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                Me.BgwOCBSimport.ReportProgress(18, "Calculating Closing Ledger Balance for Nostro Account:" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "  Currency: " & dt.Rows.Item(i).Item("CURRENCY CODE"))
                                Dim a As Double
                                Dim b As Double
                                Dim c As Double
                                Dim d1 As Double 'New Amount in Euro
                                'Exchange Rate
                                cmd.CommandText = "Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [EXCHANGE RATES OCBS].[CURRENCY CODE]='" & dt.Rows.Item(i).Item("CURRENCY CODE") & "' and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]='" & rdsql & "'"
                                c = cmd.ExecuteScalar
                                cmd.CommandText = "SELECT SUM([Amount]) from [NOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CURRENCY CODE") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "'"
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    a = cmd.ExecuteScalar
                                    'Summe Amount in Euro
                                    cmd.CommandText = "SELECT SUM([AmountInEuro]) from [NOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CURRENCY CODE") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "'"
                                    b = cmd.ExecuteScalar
                                    d1 = Math.Round(a / c, 2) 'Neu berechneter Betrag in Euro
                                    cmd.CommandText = "INSERT INTO [NOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name])Values('CLOSING LEDGER BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CURRENCY CODE") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'" & dt.Rows.Item(i).Item("GL_CODE") & "','" & rdsql & "','" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "','" & dt.Rows.Item(i).Item("CORRESPONDENT NAME") & "')"
                                    cmd.ExecuteScalar()
                                Else
                                    cmd.CommandText = "INSERT INTO [NOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name])Values('CLOSING LEDGER BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CURRENCY CODE") & "','0','0'," & Str(c) & ",'" & dt.Rows.Item(i).Item("GL_CODE") & "','" & rdsql & "','" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "','" & dt.Rows.Item(i).Item("CORRESPONDENT NAME") & "')"
                                    cmd.ExecuteScalar()
                                End If
                            Next
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                            'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                            Me.BgwOCBSimport.ReportProgress(19, "Calculate Closing Balances for all Nostro Accounts (in EURO)")
                            QueryText = "SELECT * FROM [SSIS] where [INTERNAL ACCOUNT] in (Select [AccountNo] from [NOSTRO_VOLUMES]) and [CURRENCY CODE] in ('EUR')"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                            For i = 0 To dt.Rows.Count - 1
                                Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                                Me.BgwOCBSimport.ReportProgress(19, "Calculating Closing Ledger Balance for Nostro Account:" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "  Currency: " & dt.Rows.Item(i).Item("CURRENCY CODE"))
                                Dim a As Double
                                Dim b As Double
                                Dim c As Double = 1
                                Dim d1 As Double 'New Amount in Euro
                                cmd.CommandText = "SELECT SUM([Amount]) from [NOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CURRENCY CODE") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "'"
                                If cmd.ExecuteScalar IsNot DBNull.Value Then
                                    a = cmd.ExecuteScalar
                                    'Summe Amount in Euro
                                    cmd.CommandText = "SELECT SUM([AmountInEuro]) from [NOSTRO_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' and [CCY]='" & dt.Rows.Item(i).Item("CURRENCY CODE") & "' and [AccountNo]='" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "'"
                                    b = cmd.ExecuteScalar
                                    d1 = Math.Round(a / c, 2) 'Neu berechneter Betrag in Euro
                                    cmd.CommandText = "INSERT INTO [NOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name])Values('CLOSING LEDGER BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CURRENCY CODE") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'" & dt.Rows.Item(i).Item("GL_CODE") & "','" & rdsql & "','" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "','" & dt.Rows.Item(i).Item("CORRESPONDENT NAME") & "')"
                                    cmd.ExecuteScalar()
                                Else
                                    cmd.CommandText = "INSERT INTO [NOSTRO_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name])Values('CLOSING LEDGER BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CURRENCY CODE") & "','0','0'," & Str(c) & ",'" & dt.Rows.Item(i).Item("GL_CODE") & "','" & rdsql & "','" & dt.Rows.Item(i).Item("INTERNAL ACCOUNT") & "','" & dt.Rows.Item(i).Item("CORRESPONDENT NAME") & "')"
                                    cmd.ExecuteScalar()
                                End If
                            Next
                            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                            Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT NOSTRO VOLUMES finished sucesfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table NOSTRO_VOLUMES")
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT NOSTRO VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_NOSTRO_BALANCES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT NOSTRO BALANCES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT NOSTRO BALANCES' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import procedure: IMPORT NOSTRO BALANCES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\IB-D-001 - Nostro Balance List-en.xls"
                Me.BgwOCBSimport.ReportProgress(20, "Reformating Excel File: \IB-D-001 - Nostro Balance List-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Range("H5").Value = "BalanceDate"
                    xlWorksheet1.Columns("H:H").numberformat = "yyyymmdd"
                    'Balance  Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("D:D").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwOCBSimport.ReportProgress(30, "Insert Balance Date to each Row in Excel File where Nostro Account is not NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 100
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 1).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 7).Value = rd
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11
                    Me.BgwOCBSimport.ReportProgress(35, "Excel File: \IB-D-001 - Nostro Balance List-en.xls reformated sucesfully")

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(40, "Check if Nostro Balances allready exist in Table NOSTRO BALANCES")
                    cmd.CommandText = "SELECT distinct [BalanceDate] FROM [NOSTRO BALANCES] Where [BalanceDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                        '+++++++++
                    Else
                        Me.BgwOCBSimport.ReportProgress(45, "Start Import NOSTRO BALANCES to table")
                        cmd.CommandText = "INSERT INTO [NOSTRO BALANCES]([Currency],[Nostro Code],[Nostro Name],[GL Code],[Ledger Balance],[Value Balance],[BalanceDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Currency],[Nostro Code],[Nostro Name],[GL Code],[Ledger Balance],[Value Balance],[BalanceDate] FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                        'Exchange Rates importieren
                        Me.BgwOCBSimport.ReportProgress(55, "Insert Exchange Rates in Table: NOSTRO BALANCES")
                        cmd.CommandText = "UPDATE [NOSTRO BALANCES] SET [Exchange_Rate]= 1 WHERE [Currency]='EUR' and [Exchange_Rate] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [NOSTRO BALANCES] SET [Exchange_Rate]=(Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [NOSTRO BALANCES].[Currency]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]=[NOSTRO BALANCES].[BalanceDate]) where [Exchange_Rate] is NULL"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(60, "Calculate Balances in Euro for all Nostro Accounts")
                        cmd.CommandText = "UPDATE [NOSTRO BALANCES] SET [Ledger Balance EUR]= [Ledger Balance]/[Exchange_Rate],[Value Balance EUR]= [Value Balance]/[Exchange_Rate]  where [Ledger Balance EUR] is NULL"
                        cmd.ExecuteNonQuery()
                        '+++++++NEW CODE+++++++++++
                        QueryText = "SELECT [PARAMETER1],[PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_NOSTRO_ACCOUNTS' GROUP BY [PARAMETER1],[PARAMETER2]"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            For i = 0 To dt.Rows.Count - 1
                                QueryText = "SELECT TOP 2 * FROM [NOSTRO BALANCES] where [Nostro Code] in ('" & dt.Rows.Item(i).Item("PARAMETER2").ToString & "') order by [IdNr] desc"
                                da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt1 = New DataTable()
                                da1.Fill(dt1)

                                Dim F_Balance As Double = dt1.Rows.Item(0).Item("Value Balance EUR")
                                Dim L_Balance As Double = dt1.Rows.Item(1).Item("Value Balance EUR")

                                If F_Balance > 1500000 AndAlso L_Balance > 1500000 Then

                                    'EMAIL NOSTRO RECEIVERS Parameter prüfen
                                    Me.BgwOCBSimport.ReportProgress(65, "Check if Parameter:EMAIL_NOSTRO_RECEIVERS are Valid")
                                    cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_NOSTRO_RECEIVERS'"
                                    Dim result As String = cmd.ExecuteScalar
                                    If result = "Y" Then
                                        Me.BgwOCBSimport.ReportProgress(70, "Parameter:EMAIL_NOSTRO_RECEIVERS is Valid - Check Nostro Balances in Euro and create E-Mail")
                                        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_NOSTRO_RECEIVERS'"
                                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                                        dt3 = New DataTable()
                                        da3.Fill(dt3)

                                        Dim EMAIL_USERS As String = ""
                                        For i1 = 0 To dt3.Rows.Count - 1
                                            EMAIL_USERS += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                                        Next
                                        dt3.Clear()

                                        'CC to
                                        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_NOSTRO_RECEIVERS_CC'"
                                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                                        dt3 = New DataTable()
                                        da3.Fill(dt3)
                                        Dim EMAIL_USERS_CC As String = ""
                                        For i1 = 0 To dt3.Rows.Count - 1
                                            EMAIL_USERS_CC += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                                        Next

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

                                        EItem.Subject = "Nostro Account " & dt.Rows.Item(i).Item("PARAMETER1").ToString.ToUpper & "  Account Nr." & dt.Rows.Item(i).Item("PARAMETER2") & " closing Value Balance higher than EUR 1.500.000,00 in the last 2 Business Days"
                                        EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain
                                        Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"
                                        Dim EMAIL_TEXT As String = ""
                                        Dim myBuilder As New StringBuilder
                                        Me.BgwOCBSimport.ReportProgress(85, "Nostro Balance " & dt.Rows.Item(i).Item("PARAMETER1") & "  Account Nr." & dt.Rows.Item(i).Item("PARAMETER2") & " over EUR 1.500.000,00")

                                        EMAIL_TEXT = "Nostro Balance " & dt.Rows.Item(i).Item("PARAMETER1").ToString.ToUpper & "  Account Nr." & dt.Rows.Item(i).Item("PARAMETER2") & " in the last 2 Business Days"
                                        myBuilder.Append("Balance Date:     " & "Value Balance in EURO:  " & vbNewLine)
                                        For y = 0 To dt1.Rows.Count - 1
                                            Dim Balance As Double = dt1.Rows.Item(y).Item("Value Balance EUR")
                                            Dim BalanceDate As Date = dt1.Rows.Item(y).Item("BalanceDate")
                                            myBuilder.Append(BalanceDate.ToString("dd.MM.yyyy") & "        " & FormatNumber(Balance, 2) & vbNewLine)
                                        Next
                                        EItem.Body = StrBody1 & vbNewLine & vbNewLine & EMAIL_TEXT & vbNewLine & vbNewLine & myBuilder.ToString
                                        EItem.Send()

                                    Else
                                        Me.BgwOCBSimport.ReportProgress(95, "Parameter:EMAIL_NOSTRO_RECEIVERS is not Valid")
                                    End If

                                End If
                            Next
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "There are no Nostro Accounts in Parameter:REPORT\EMAIL_NOSTRO_ACCOUNTS")
                        End If

                        Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT NOSTRO BALANCES finished sucesfully")

                    End If

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT NOSTRO BALANCES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_TRIAL_BALANCE_218()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT TRIAL BALANCE 218"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            Dim rd1 As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT TRIAL BALANCE 218' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import procedure: IMPORT TRIAL BALANCE 218")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-218 - Trial Balance (consolidated)-en.xlwa"
                Me.BgwOCBSimport.ReportProgress(20, "Reformating Excel File: \AI-D-218 - Trial Balance (consolidated)-en.xlwa")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(30, "Define Report Date from Worksheet:Trial Balance_rate-1")
                    'Report Date definieren
                    xlWorksheet1.Range("B5").NumberFormat = "yyyymmdd"
                    'rd = xlWorksheet1.Range("B5").Value
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")
                    'report creation Date definieren
                    xlWorksheet1.Range("C1").NumberFormat = "yyyyMMdd"
                    rd1 = xlWorksheet1.Range("C1").Value
                    Dim rd1sql As String = rd1.ToString("yyyyMMdd")
                    Me.BgwOCBSimport.ReportProgress(40, "Reformating Worksheet:Trial Balance-3")
                    xlWorksheet1 = xlWorkBook.Worksheets(3) 'Worksheet 3 - Report Data
                    xlWorksheet1.Range("A2").Value = "AccountNo"
                    xlWorksheet1.Range("B2").Value = "AccountName"
                    xlWorksheet1.Range("D2").Value = "USDequEUR"
                    xlWorksheet1.Range("E2").Value = "OtherCurrequEUR"
                    xlWorksheet1.Range("F2").Value = "Totals"
                    xlWorksheet1.Range("G2").Value = "RepDate"
                    xlWorksheet1.Range("H2").Value = "RepCreationDate"
                    xlWorksheet1.Range("A:A").NumberFormat = "#0"
                    xlWorksheet1.Range("G:H").NumberFormat = "yyyyMMdd"
                    'Rows delete
                    xlWorksheet1.Rows("1:1").delete()
                    'Insert ReportDate and ReportcreationDate
                    Me.BgwOCBSimport.ReportProgress(50, "Insert Report Date and Report Creation Date if Account Name is not NULL- Delete all other Rows-Rows 2 to 5000")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 2).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 7).Value = rd
                            xlWorksheet1.Cells(i, 8).Value = rd1
                        Else
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If xlWorksheet1.Cells(i, 2).value = "AI-D-218" Then
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\TRIALBALANCE_218_Formated.xls"
                    xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    'xlWorkBook.SaveAs("C:\TRIALBALANCE_218_Formated.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwOCBSimport.ReportProgress(60, "Excel File: \AI-D-218 - Trial Balance (consolidated)-en.xlwa reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    Me.BgwOCBSimport.ReportProgress(70, "Check if Data allready exist in Table:TRIAL_BALANCE_218")
                    cmd.CommandText = "SELECT distinct [RepDate] FROM [TRIAL_BALANCE_218] Where [RepDate]='" & rdsql & "'"
                    Dim t2 As String = cmd.ExecuteScalar()
                    If IsNothing(t2) = False Then
                        Me.BgwOCBSimport.ReportProgress(100, "Data allready exist in Table:TRIAL_BALANCE_218-Import aborted")
                    Else
                        'Daten importieren 
                        Me.BgwOCBSimport.ReportProgress(80, "Start Import Data to table")
                        cmd.CommandText = "INSERT INTO [TRIAL_BALANCE_218] SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Trial Balance-3$]')"
                        cmd.ExecuteNonQuery()
                        'Datum nochmals einfügen wenn leer
                        Me.BgwOCBSimport.ReportProgress(90, "Insert ReportDate and ReportCreationDate if Fields are NULL")
                        cmd.CommandText = "UPDATE [TRIAL_BALANCE_218] SET [RepDate]='" & rdsql & "', [RepCreationDate]='" & rd1sql & "' where [RepDate] is NULL"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(10, "Import procedure: IMPORT TRIAL BALANCE 218 is finished sucesfully")
                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT TRIAL BALANCE 218 is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_CL_DRAWDOWN_OUTSTANDING_LN_D_004()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT CL DRAWDON OUTSTANDING"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            Dim rd1 As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT CL DRAWDON OUTSTANDING' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import procedure: IMPORT CL DRAWDON OUTSTANDING")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\LN-D-004 - CL Drawdown Outstanding Report(Started)-en.xls"
                Me.BgwOCBSimport.ReportProgress(20, "Reformating Excel File: \LN-D-004 - CL Drawdown Outstanding Report(Started)-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(30, "Define Report Date and Report Creation date")
                    'Report Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")
                    'report creation Date definieren
                    xlWorksheet1.Range("C1").NumberFormat = "yyyyMMdd"
                    rd1 = xlWorksheet1.Range("C1").Value
                    Dim rd1sql As String = rd1.ToString("yyyyMMdd")
                    Me.BgwOCBSimport.ReportProgress(40, "Reformating Excel File: \LN-D-004 - CL Drawdown Outstanding Report(Started)-en.xls")
                    'Rows delete
                    xlWorksheet1.Rows("1:4").delete()
                    xlWorksheet1.Range("C1").Value = "Contract No"
                    xlWorksheet1.Range("D1").Value = "Commitment No"
                    xlWorksheet1.Range("N1").Value = "AccIntTo-Date"
                    xlWorksheet1.Range("O1").Value = "DefIntTo-Date"
                    xlWorksheet1.Range("P1").Value = "Overdue Int To-Date"
                    xlWorksheet1.Range("R1").Value = "Overdue Int Rate"
                    xlWorksheet1.Range("AD1").Value = "Base rate (ie Cost of Fund Rate)"
                    xlWorksheet1.Range("AG1").Value = "Revolving_Non Revolving flag"
                    xlWorksheet1.Range("AH1").Value = "Client No"
                    xlWorksheet1.Range("AI1").Value = "GL Master No"
                    xlWorksheet1.Range("AN1").Value = "RepDate"
                    xlWorksheet1.Range("AO1").Value = "RepCreationDate"
                    xlWorksheet1.Range("F:J").NumberFormat = "yyyyMMdd"
                    xlWorksheet1.Range("AN:AO").NumberFormat = "yyyyMMdd"

                    'Insert ReportDate and ReportcreationDate
                    Me.BgwOCBSimport.ReportProgress(50, "For Row 2 to 10000-Insert Report Date and Report Creation Date if Account Name is not NULL- Delete all other Rows")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX10))
                    For i = 2 To 10000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 34).value <> "" Then 'Wenn Client nicht leer ist!
                            xlWorksheet1.Cells(i, 40).Value = rd
                            xlWorksheet1.Cells(i, 41).Value = rd1
                        Else
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\LN_D_004_Formated.xls"
                    xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwOCBSimport.ReportProgress(60, "Excel File: \LN-D-004 - CL Drawdown Outstanding Report(Started)-en.xls reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    Me.BgwOCBSimport.ReportProgress(70, "Check if Data allready exist in Table:CL_DRAWDON_OUTSTANDING")
                    cmd.CommandText = "SELECT distinct [RepDate] FROM [CL_DRAWDOWN_OUTSTANDING] Where [RepDate]='" & rdsql & "'"
                    Dim t2 As String = cmd.ExecuteScalar()
                    If IsNothing(t2) = False Then
                        Me.BgwOCBSimport.ReportProgress(100, "Data allready exist in Table:CL_DRAWDON_OUTSTANDING-Import aborted")
                    Else
                        'Daten importieren 
                        Me.BgwOCBSimport.ReportProgress(80, "Start Import Data to table")
                        cmd.CommandText = "INSERT INTO [CL_DRAWDOWN_OUTSTANDING] ([Product Type],[Currency],[Contract No],[Commitment No],[Counterparty],[Contract Start Date],[Start Date],[Maturity Date],[Next Rollover],[Commitment Expiry Date],[Outstanding Principal],[Overdue Principal],[Total Interest],[AccIntTo-Date],[DefIntTo-Date],[Overdue Int To-Date],[Interest Rate],[Overdue Int Rate],[Booking Centre],[Purpose],[A/C Officer],[A/C Centre],[Trx Officer 1],[Trx Officer 2],[Trx Officer 3],[Trx Centre 1],[Trx Centre 2],[Trx Centre 3],[Our Receive A/C],[Base rate (ie Cost of Fund Rate)],[Premium rate],[Add on rate],[Revolving_Non Revolving flag],[Client No],[GL Master No],[Product Type Code],[Loan Classification],[Loan Classification - Regulatory],[Loan Classification - HO],[RepDate],[RepCreationDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                        'Datum nochmals einfügen wenn leer
                        Me.BgwOCBSimport.ReportProgress(90, "Insert ReportDate and ReportCreationDate if Fields are NULL")
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [RepDate]='" & rdsql & "', [RepCreationDate]='" & rd1sql & "' where [RepDate] is NULL"
                        cmd.ExecuteNonQuery()
                        'Nicht relevante Zeilen löschen
                        Me.BgwOCBSimport.ReportProgress(90, "Delete rows with no Client Nr.")
                        cmd.CommandText = "DELETE FROM [CL_DRAWDOWN_OUTSTANDING] where [Client No] is NULL and [RepDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'Importieren Exchange Rates
                        Me.BgwOCBSimport.ReportProgress(95, "Insert Exchange Rates")
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [Exchange_rate]= 1 WHERE [Currency]='EUR' and [Exchange_rate] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [Exchange_rate]=(Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [CL_DRAWDOWN_OUTSTANDING].[Currency]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]=[CL_DRAWDOWN_OUTSTANDING].[RepDate]) where [Exchange_rate] is NULL"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(98, "Calculate Outstanding Principal in Euro ")
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [Outstanding Principal EUR]= [Outstanding Principal]/[Exchange_rate]  where [Outstanding Principal EUR] is NULL"
                        cmd.ExecuteNonQuery()

                        Me.BgwOCBSimport.ReportProgress(10, "Import procedure: IMPORT CL DRAWDON OUTSTANDING is finished sucesfully")
                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT CL DRAWDON OUTSTANDING is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_LETTER_OF_CREDITS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT LETTER OF CREDITS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT LETTER OF CREDITS' and [Valid]='Y'"
            cmd.Connection.Open()
            cmd.CommandTimeout = 60000

            If cmd.ExecuteScalar > 0 Then
                '+++++++++++++++++++++++++++++++++++++++
                'old Code with SSI
                'Me.BgwOCBSimport.ReportProgress(1, "DROP Table:MT700 Temp IF EXISTS")
                'cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='MT700 Temp' AND xtype='U') DROP TABLE [MT700 Temp]"
                'cmd.ExecuteNonQuery()
                'In temporäre Tabelle einfügen
                'Ausführen SSI
                'Me.BgwOCBSimport.ReportProgress(2, "Start SSI for MT700 to MT700 Temp")
                'pkg = app.LoadPackage(SSISDirectory & "IMPORT MT700.dtsx", Nothing)
                'pkg.Execute()
                'Me.BgwOCBSimport.ReportProgress(3, "IMPORT MT700.dtsx Result:" & pkg.ExecutionResult.ToString())
                'Delete not relevant Data
                'cmd.CommandText = "DELETE FROM [MT700 Temp] where [MT] not in ('MT700')"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "DELETE FROM [MT700 Temp] where [M31C] is NULL"
                'cmd.ExecuteNonQuery()
                'Import in EXPORT LC DETAILS ALL
                'Me.BgwOCBSimport.ReportProgress(4, "Insert to Table:EXPORT LC DETAILS ALL")
                'cmd.CommandText = "INSERT INTO [EXPORT LC DETAILS ALL] ([BENEFNAME],[SENDER BIC],[M40A],[M20],[OURREF],[M31C],[M44C],[M31D_Date],[M31D_Country],[M50_1],[M50_2],[M50_3],[M50_4],[M39A],[CCY],[M32B]) SELECT UPPER([M59_1]),[SENDER],[M40A],[M20],[L_C],[M31C],[M44C],[M31D_Date],[M31D_Country],UPPER([M50_1]),UPPER([M50_2]),UPPER([M50_3]),UPPER([M50_4]),[M39A],[CCY],[M32B] FROM [MT700 Temp] where  [M31C]>'20121231' and [M20] not in (SELECT [M20] from [EXPORT LC DETAILS ALL])"
                'cmd.ExecuteNonQuery()
                '+++++++++++++++++++++++++++++++++++++++++

                'NEW CODE after Live of Export LC Module
                Me.BgwOCBSimport.ReportProgress(4, "Insert data from Table:EXPORT_LC_MT700 to Table:EXPORT LC DETAILS ALL where Date of Issue>20121231")
                cmd.CommandText = "INSERT INTO [EXPORT LC DETAILS ALL] ([BENEFNAME],[SENDER BIC],[M40A],[M20],[OURREF],[M31C],[M31D_Date],[M31D_Country],[M50_1],[CCY],[M32B]) SELECT UPPER([Beneficiary]),[SenderBIC],[LC_Form],[LC_Nr],[OurReference],[DateOfIssue],[M31D_Date],[M31D_Country],UPPER([Applicant]),[LC_Currency],[LC_Amount] FROM [EXPORT_LC_MT700] where  [DateOfIssue]>'20121231' and [LC_Nr] not in (SELECT [M20] from [EXPORT LC DETAILS ALL])"
                cmd.ExecuteNonQuery()


                'Import in EXPORT LC DETAILS ALL
                'Me.BgwOCBSimport.ReportProgress(4, "Drop Temporary Table:MT700 Temp")
                'cmd.CommandText = "DROP TABLE [MT700 Temp]"
                'cmd.ExecuteNonQuery()
                'Update Field IdLCMonth
                Me.BgwOCBSimport.ReportProgress(5, "Update Field IdLCMonth in Table:EXPORT LC DETAILS ALL")
                'Erster Tag des Monats
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [IdLCMonth]=DATEADD(MONTH, DATEDIFF(MONTH, 0, [M31C]), 0) Where [IdLCMonth] is NULL "
                cmd.ExecuteNonQuery()
                'Update Sender Name and Branch...BIC11
                Me.BgwOCBSimport.ReportProgress(6, "Update Sender Name and Branch from BIC DIRECTORY...BIC11")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[BRANCH INFORMATION]+B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON Left(A.[SENDER BIC],8)=B.[BIC CODE] where Right(A.[SENDER BIC],3)=B.[BRANCH CODE] and A.[SENDERNAME] is NULL and B.[BRANCH INFORMATION] is not NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON Left(A.[SENDER BIC],8)=B.[BIC CODE] where Right(A.[SENDER BIC],3)=B.[BRANCH CODE] and A.[SENDERNAME] is NULL and A.[SENDER BRANCH] is NULL"
                cmd.ExecuteNonQuery()
                'Update Sender Name and Branch...BIC8
                Me.BgwOCBSimport.ReportProgress(7, "Update Sender Name and Branch from BIC DIRECTORY...BIC8")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[BRANCH INFORMATION]+B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON A.[SENDER BIC]=B.[BIC CODE] where B.[BRANCH CODE]='XXX' and Len(A.[SENDER BIC])=8 and A.[SENDERNAME] is NULL and B.[BRANCH INFORMATION] is not NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON A.[SENDER BIC]=B.[BIC CODE] where B.[BRANCH CODE]='XXX' and Len(A.[SENDER BIC])=8 and A.[SENDERNAME] is NULL and A.[SENDER BRANCH] is NULL"
                cmd.ExecuteNonQuery()
                'Update Exchange Rate
                Me.BgwOCBSimport.ReportProgress(8, "Update Exchange Rate-Currency EURO")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [EXCHANGE RATE]= 1 WHERE [CCY]='EUR'"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(9, "Select Max Exchange Rate Date - GROUP BY Month")
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
                Me.BgwOCBSimport.ReportProgress(10, "Update Exchange Rates-Foreign Currencies")
                cmd.CommandText = "UPDATE A  SET A.[EXCHANGE RATE]=B.[MIDDLE RATE] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [EXCHANGE RATES OCBS] B On A.[EXCHANGE_RATE_DATE]=B.[EXCHANGE RATE DATE] where A.[CCY]=B.[CURRENCY CODE] and A.[CCY] not in ('EUR')"
                cmd.ExecuteNonQuery()
                'Calculate LC Amounts in EURO
                Me.BgwOCBSimport.ReportProgress(11, "Calculate LC Amounts in EURO")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [AMTEUR]=Round([M32B]/[EXCHANGE RATE],2)"
                cmd.ExecuteNonQuery()
                'Insert into EXPORT LC MONTH
                Me.BgwOCBSimport.ReportProgress(12, "Insert into EXPORT LC MONTH")
                cmd.CommandText = "INSERT INTO [EXPORT LC MONTH] ([LC Month],IdLCYear) Select distinct [IdLCMonth],DATEADD(YEAR, DATEDIFF(YEAR, 0, [IdLCMonth]), 0) from [EXPORT LC DETAILS ALL] WHERE [IdLCMonth] not in (Select  [LC Month] from   [EXPORT LC MONTH])"
                cmd.ExecuteNonQuery()
                'Insert into EXPORT LC YEAR
                Me.BgwOCBSimport.ReportProgress(13, "Insert into EXPORT LC YEAR")
                cmd.CommandText = "INSERT INTO [EXPORT LC YEAR] ([LC Year]) Select distinct [IdLCYear] from [EXPORT LC MONTH] WHERE [IdLCYear] not in (Select  [LC Year] from   [EXPORT LC YEAR])"
                cmd.ExecuteNonQuery()
                'Select LC Amt Sum,LC Items for Each Month
                'Me.BgwOCBSimport.ReportProgress(13, "Select LC Amt Sum,LC Items for Each Month")
                'QueryText = "Select sum([AMTEUR]) as SumLCAmt,Count([ID])as LCItems,[IdLCMonth] from   [EXPORT LC DETAILS ALL] GROUP BY Month([IdLCMonth]),[IdLCMonth]"
                'da = New SqlDataAdapter(QueryText.Trim(), conn)
                'dt = New DataTable()
                'da.Fill(dt)
                'Dim LC_Items As Double = 0
                'Dim LC_Amounts As Double = 0
                'Me.BgwOCBSimport.ReportProgress(13, "Insert Sums and Items in EXPORT LC MONTH")
                'For i = 0 To dt.Rows.Count - 1
                'Dim LcMonth As Date = FormatDateTime(dt.Rows.Item(i).Item("IdLCMonth"), DateFormat.ShortDate)
                'Dim LcMonthSql As String = LcMonth.ToString("yyyyMMdd")
                'LC_Items = dt.Rows.Item(i).Item("LCItems")
                'LC_Amounts = dt.Rows.Item(i).Item("SumLCAmt")
                'cmd.CommandText = "UPDATE [EXPORT LC MONTH] SET [LC Items]=" & Str(LC_Items) & ",[LC Amounts]=" & Str(LC_Amounts) & " where [LC Month]='" & LcMonthSql & "'"
                'cmd.ExecuteNonQuery()
                'Next
                Me.BgwOCBSimport.ReportProgress(13, "Select LC Amt Sum,LC Items for Each Month and Update Table EXPORT LC MONTH")
                cmd.CommandText = "UPDATE A SET A.[LC Items]=B.LCItems,A.[LC Amounts]=B.SumLCAmt from [EXPORT LC MONTH] A INNER JOIN (Select sum([AMTEUR]) as SumLCAmt,Count([ID])as LCItems,[IdLCMonth] from   [EXPORT LC DETAILS ALL] GROUP BY Month([IdLCMonth]),[IdLCMonth])B on A.[LC Month]=B.[IdLCMonth]"
                cmd.ExecuteNonQuery()


                'Select Sum of Volumes from PROFIT AND LOSS VOLUMES
                Me.BgwOCBSimport.ReportProgress(14, "Select Sum of Volumes from PROFIT AND LOSS VOLUMES")
                'QueryText = "Select Max([GL_Rep_Date]) as MaxBookingDate,Month(Max([GL_Rep_Date]))as MaxMonth,Year(Max([GL_Rep_Date]))as MaxYear,DATEADD(MONTH, DATEDIFF(MONTH, 0, Max([GL_Rep_Date])), 0)   as MaxMonthYear from [PROFIT and LOSS VOLUMES] where [BatchNo] in ('CLOSING BALANCE OCBS ACC.') and [GL_AC_No] in ('53208300','53211306') GROUP BY Month([GL_Rep_Date])"
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
                        Me.BgwOCBSimport.ReportProgress(15, "Update Earnings")
                        cmd.CommandText = "UPDATE [EXPORT LC MONTH] SET [LC Earnings]=" & Str(SumAmtBalance) & " where [LC Month]='" & MinBDsql & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next
                Me.BgwOCBSimport.ReportProgress(50, "Import in Tabelle EXPORT LC YEAR")
                cmd.CommandText = "INSERT INTO [EXPORT LC YEAR] ([LC Year]) Select distinct [IdLCYear] from [EXPORT LC MONTH] WHERE [IdLCYear] not in (Select  [LC Year] from   [EXPORT LC YEAR])"
                cmd.ExecuteNonQuery()
                'Me.BgwOCBSimport.ReportProgress(70, "Select LC Amt Sum,LC Items for Each Year")
                'QueryText = "Select sum([LC Amounts]) as SumLCAmt,Sum([LC Items])as LCItems, Sum([LC Earnings])as LCEarnings,Year([IdLCYear]) as LCYear from   [EXPORT LC MONTH] GROUP BY Year([IdLCYear]),Year([IdLCYear])"
                'da = New SqlDataAdapter(QueryText.Trim(), conn)
                'dt = New DataTable()
                'da.Fill(dt)
                'Dim LcItems As Double = 0
                'Dim SumLCAmt As Double = 0
                'Dim LcEarnings As Double = 0
                'Me.BgwOCBSimport.ReportProgress(90, "Insert Sums and Items in EXPORT LC YEAR")
                'For i = 0 To dt.Rows.Count - 1
                'LcItems = dt.Rows.Item(i).Item("LCItems")
                'SumLCAmt = dt.Rows.Item(i).Item("SumLCAmt")
                'LcEarnings = dt.Rows.Item(i).Item("LCEarnings")
                'cmd.CommandText = "UPDATE [EXPORT LC YEAR] SET [LC Items]=" & Str(LcItems) & ",[LC Amounts]=" & Str(SumLCAmt) & " ,[LC Earnings]=" & Str(LcEarnings) & " where Year([LC Year])='" & dt.Rows.Item(i).Item("LCYear") & "'"
                'cmd.ExecuteNonQuery()
                'Next
                Me.BgwOCBSimport.ReportProgress(70, "Select LC Amt Sum,LC Items for Each Year and Update Table EXPORT LC YEAR")
                cmd.CommandText = "UPDATE A SET A.[LC Items]=B.LCItems,A.[LC Amounts]=B.SumLCAmt,A.[LC Earnings]=B.LCEarnings from [EXPORT LC YEAR] A INNER JOIN (Select sum([LC Amounts]) as SumLCAmt,Sum([LC Items])as LCItems, Sum([LC Earnings])as LCEarnings,[IdLCYear],Year([IdLCYear]) as LCYear from   [EXPORT LC MONTH] GROUP BY [IdLCYear],Year([IdLCYear]),Year([IdLCYear]))B on A.[LC Year]=B.[IdLCYear]"
                cmd.ExecuteNonQuery()


                Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT LETTER OF CREDITS finished sucesfully")
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure:IMPORT LETTER OF CREDITS is not VALID+++")
            End If


            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_GL_ACCOUNTS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT GL ACCOUNTS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT GL ACCOUNTS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import procedure: IMPORT GL ACCOUNTS")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-101 - Chart of Account Listing-en.xls"
                Me.BgwOCBSimport.ReportProgress(20, "Reformating Excel File: \AI-D-101 - Chart of Account Listing-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False
                    'Rows delete
                    xlWorksheet1.Rows("1:4").delete()
                    xlWorksheet1.Columns("A:C").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                    xlWorksheet1.Range("A1").Value = "GL_AC_No"
                    xlWorksheet1.Range("B1").Value = "GL_AC_Name"
                    xlWorksheet1.Range("A:A").NumberFormat = "#0"


                    Me.BgwOCBSimport.ReportProgress(30, "Delete blank Rows-Rows 2 to 5000")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 1).value) = "" Then 'Wenn leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If Trim(xlWorksheet1.Cells(i, 2).value) = "" Then 'Wenn leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If IsNumeric(xlWorksheet1.Cells(i, 1).value) = False Then 'Wenn leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\ChartAccountListing_Formated.xls"
                    xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    'xlWorkBook.SaveAs("C:\TRIALBALANCE_218_Formated.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwOCBSimport.ReportProgress(40, "Excel File: \AI-D-101 - Chart of Account Listing-en.xls reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    'Daten importieren 
                    Me.BgwOCBSimport.ReportProgress(60, "Start Update GL_ACCOUNTS Table from Excel File: AI-D-101 - Chart of Account Listing-en.xls")
                    cmd.CommandText = "INSERT INTO [GL_ACCOUNTS]([GL_AC_No],[GL_AC_Name]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [GL_AC_No],[GL_AC_Name] FROM [Sheet1$]') T2 where T2.[GL_AC_No] not in (Select[GL_AC_No] from [GL_ACCOUNTS]) "
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(65, "Import: ChartAccountListing_Formated.xls is finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If

                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-102 - Chart of Account Parameter Listing-en.xls"
                Me.BgwOCBSimport.ReportProgress(70, "Reformating Excel File: \AI-D-102 - Chart of Account Parameter Listing-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False
                    'Rows delete
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()
                    xlWorksheet1.Rows("1:4").delete()
                    xlWorksheet1.Columns("A:A").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    xlWorksheet1.Columns("B:B").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    xlWorksheet1.Columns("C:C").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                    xlWorksheet1.Range("A1").Value = "GL_AC_Range_From"
                    xlWorksheet1.Range("B1").Value = "GL_AC_Range_Till"
                    xlWorksheet1.Range("A:B").NumberFormat = "#0"


                    Me.BgwOCBSimport.ReportProgress(75, "Delete blank Rows-Rows 2 to 5000")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 5000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If Trim(xlWorksheet1.Cells(i, 1).value) = "" Then 'Wenn leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If Trim(xlWorksheet1.Cells(i, 2).value) = "" Then 'Wenn leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                        If IsNumeric(xlWorksheet1.Cells(i, 1).value) = False Then 'Wenn leer ist!
                            xlWorksheet1.Rows(i).Delete()
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\ChartAccountParameters_Formated.xls"
                    xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    'xlWorkBook.SaveAs("C:\ChartAccountParameters_Formated.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()

                    EXCELL.Quit()
                    EXCELL = Nothing

                    'Excel Instanz beenden
                    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i1 As Short
                    i1 = 0
                    For i1 = 0 To (procs.Length - 1)
                        procs(i1).Kill()
                    Next i1
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwOCBSimport.ReportProgress(80, "Excel File: \AI-D-102 - Chart of Account Parameter Listing-en.xls reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    Me.BgwOCBSimport.ReportProgress(85, "Update GL Account Table with related Descriptions and Ranges from Excel File:AI-D-102 - Chart of Account Parameter Listing-en.xls")
                    'Daten importieren 
                    cmd.CommandText = "UPDATE [GL_ACCOUNTS] SET [Description]=T2.[Description],[GL_AC_Range_From]=T2.[GL_AC_Range_From],[GL_AC_Range_Till]=T2.[GL_AC_Range_Till] from (SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]')) T2 where [GL_ACCOUNTS].[GL_AC_No]>=T2.[GL_AC_Range_From] and [GL_ACCOUNTS].[GL_AC_No]<=T2.[GL_AC_Range_Till]"
                    cmd.ExecuteNonQuery()
                    'Leerzeichen Löschen
                    Me.BgwOCBSimport.ReportProgress(90, "Delete whitespaces in Description Column")
                    cmd.CommandText = "UPDATE [GL_ACCOUNTS] SET [Description]= LTRIM([Description])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(90, "Delete Blank GL ACCOUNTS")
                    cmd.CommandText = "DELETE FROM [GL_ACCOUNTS] WHERE [GL_AC_No] is NULL"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT GL ACCOUNTS finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If

            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT GL ACCOUNTS is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_GUARANTEE_EXPOSURE()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "GUARANTEE_EXPOSURE"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            'Dim rdsql As String = ""

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='GUARANTEE EXPOSURE REPORT' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: GUARANTEE EXPOSURE REPORT")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\LN-D-014 - Guarantee Exposure Report-en.xls"
                Me.BgwOCBSimport.ReportProgress(2, "Reformating Excel File:\LN-D-014 - Guarantee Exposure Report-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Range("A5").Value = "ClientName"
                    xlWorksheet1.Range("B5").Value = "ClientNo"
                    xlWorksheet1.Range("D5").Value = "CommitmentNr"
                    xlWorksheet1.Range("E5").Value = "GuaranteeNo"
                    xlWorksheet1.Range("F5").Value = "GuaranteeType"
                    xlWorksheet1.Range("G5").Value = "LC_Nr"
                    xlWorksheet1.Range("H5").Value = "LC_Nature"
                    xlWorksheet1.Range("I5").Value = "IssuingDate"
                    xlWorksheet1.Range("J5").Value = "ExpiryDate"
                    xlWorksheet1.Range("K5").Value = "CUR"
                    xlWorksheet1.Range("L5").Value = "LC_Amount"
                    xlWorksheet1.Range("S5").Value = "RiskDate"
                    xlWorksheet1.Columns("I:J").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("S:S").numberformat = "yyyymmdd"


                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'rdsql = rd.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    'xlWorksheet1.Columns("A:A").unMerge()

                    'Datum einfügen wo daten vorhanden sind
                    Me.BgwOCBSimport.ReportProgress(3, "Insert Date if the column 1 is not NULL")
                    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    For i = 2 To 1000
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                        If xlWorksheet1.Cells(i, 1).value <> "" Then 'Wenn Type nicht leer ist!
                            xlWorksheet1.Cells(i, 19).Value = rd
                        End If
                    Next i

                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs11() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i11 As Short
                    i11 = 0
                    For i11 = 0 To (procs11.Length - 1)
                        procs11(i11).Kill()
                    Next i11
                    Me.BgwOCBSimport.ReportProgress(5, "Excel File:LN-D-014 - Guarantee Exposure Report-en.xls reformated successfully")

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(5, "Delete Data in GUARANTEE_EXPOSURE with same Date")
                    cmd.CommandText = "DELETE FROM [GUARANTEE_EXPOSURE] Where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(6, "Start import to Table: GUARANTEE_EXPOSURE")
                    cmd.CommandText = "INSERT INTO [GUARANTEE_EXPOSURE]([ClientName],[ClientNo],[CommitmentNr],[GuaranteeNo],[GuaranteeType],[LC_Nr],[LC_Nature],[IssuingDate],[ExpiryDate],[CUR],[LC_Amount],[Remark1],[Remark2],[Remark3],[Remark4],[Remark5],[RiskDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [ClientName],[ClientNo],[CommitmentNr],[GuaranteeNo],[GuaranteeType],[LC_Nr],[LC_Nature],[IssuingDate],[ExpiryDate],[CUR],[LC_Amount],[Remark1],[Remark2],[Remark3],[Remark4],[Remark5],[RiskDate] FROM [Sheet1$]')"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: GUARANTEE EXPOSURE REPORT is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:GUARANTEE EXPOSURE REPORT is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub





#End Region



#Region "CLIENT BACKGROUNDWORKER"
    Private Sub BgwClientRun_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwClientRun.DoWork
        Try
            If IsDate(rd) = True AndAlso rd > DateSerial(2000, 12, 31) Then 'rd must be a valid Date
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Connection.Open()
                cmd.CommandTimeout = 500

                Me.BgwClientRun.ReportProgress(50, "Starting PS TOOL Client for " & rd)

                'PROCEDURES
                INTEREST_RATE_RISK_CALCULATION()
                CREDIT_RISK_MAK_CALCULATION()
                NEW_CREDIT_BUSINESS()
                FX_CREDIT_EQUIV_CALCULATION()
                UNEXPECTED_LOSS_CALCULATION()
                DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION()
                BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION()
                BUSINESS_TYPE_LIABILITIES_CALCULATION()
                'STRESS_TESTS_CALCULATION() ' +++++++INACTIVE+++++++++
                RLDC_UPDATE()
                LOAN_EXPOSURE_CORPORATES()
                STRESS_TESTS_HEAD_OFFICE_CALCULATION()
                FORMBLATT_BALANCE_CALCULATION()

                Me.BgwClientRun.ReportProgress(100, "Finishing PS TOOL Client for " & rd)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If

        Catch ex As Exception
            Me.BgwClientRun.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try
    End Sub

    Private Sub BgwClientRun_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwClientRun.ProgressChanged
        Dim ClientEvent As String = e.UserState

        cmdEVENT.Connection.Open()
        cmdEVENT.CommandTimeout = 500
        Try
            cmdEVENT.CommandText = "INSERT INTO [CLIENT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & ClientEvent & "','" & CurrentClientProcedure & "','PS TOOL CLIENT')"
            cmdEVENT.ExecuteNonQuery()
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [CLIENT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & CurrentClientProcedure & "','PS TOOL CLIENT')"
            cmdEVENT.ExecuteNonQuery()
            '***************************************************
            Dim myBuilder As New StringBuilder
            Dim headers As String = "On " & Today & "the following import error have being occured in PS TOOL Client Process:" & vbNewLine
            Dim Footer As String = "(Please check the error and restart PS TOOL Client)" & vbNewLine
            Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
            Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
            Dim outApp As Microsoft.Office.Interop.Outlook.Application

            outApp = New Microsoft.Office.Interop.Outlook.Application

            NSpace = outApp.GetNamespace("MAPI")
            Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
            EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
            EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

            EItem.To = EMAIL_USERS

            EItem.Subject = "PS TOOL - CLIENT ERROR on " & " " & Today

            EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

            myBuilder.Append("ERROR: " & ex.Message.ToString.Replace("'", " ") & "  Procedure Name: " & CurrentClientProcedure & "System: PS TOOL CLIENT" & vbNewLine)


            Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

            EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
            EItem.Send()
            '**************************************
            Exit Try
        End Try
        cmdEVENT.Connection.Close()
    End Sub

    Private Sub BgwClientRun_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwClientRun.RunWorkerCompleted
        'Application.Exit()
        Me.Close()

    End Sub

#End Region

#Region "CLIENT PROCEDURES"
    Private Sub INTEREST_RATE_RISK_CALCULATION()
        'INTEREST RATE RISK
        CurrentClientProcedure = "INTEREST RATE RISK"
        Me.BgwClientRun.ReportProgress(2, "Current Date for Client execution: " & rd)
        cmd.CommandText = "SELECT [RISK DATE] FROM [RATERISK DETAILS ALL DATA] WHERE [RISK DATE]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            Me.BgwClientRun.ReportProgress(3, "Delete all data in Interest Rate Risk Tables for: " & rd)
            cmd.CommandText = "DELETE  FROM [RATERISK DETAILS] WHERE [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE  FROM [RATERISK TOTALS] WHERE [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE  FROM [RATERISK DATE] WHERE [RateRiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE  FROM [RATERISK DELETIONS] WHERE [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(4, "Insert Data in RATERISK DETAILS from Table RATERISK DETAILS ALL DATA for: " & rd)
            cmd.CommandText = "INSERT INTO [RATERISK DETAILS]([CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[DATA DATE],[RISK DATE],[IdRateRiskDate])Select[CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[DATA DATE],[RISK DATE],[RISK DATE]FROM [RATERISK DETAILS ALL DATA] where [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(4, "Delete Contract type=DDPCIAL (Pauschalwertberichtigung) in RATERISK DETAILS  for: " & rd)
            cmd.CommandText = "DELETE FROM [RATERISK DETAILS] where [RISK DATE]='" & rdsql & "' and [ProductType] in ('DDPCIAL')"
            cmd.ExecuteNonQuery()

            Me.BgwClientRun.ReportProgress(5, "Insert Data in RATERISK DELETIONS where  [Next EventType]=ST and [Next EventDate]>" & rd)
            cmd.CommandText = "INSERT INTO [RATERISK DELETIONS]([PERIOD],[CURRENCY],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[DATA DATE],[RISK DATE]) Select [PERIOD],[CURRENCY],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[DATA DATE],[RISK DATE] from [RATERISK DETAILS] where [RISK DATE]='" & rdsql & "' and [Next EventType]='ST' and [Next EventDate]>[RISK DATE]"
            cmd.ExecuteNonQuery()
            'Daten auf NULL stellen
            Me.BgwClientRun.ReportProgress(6, "Set [Principal Amount/Value Balance(EUR Equ)]= 0 and [Next EventType]=ST-Modified in RATERISK DETAILS where  [Next EventType]=ST and [Next EventDate]>" & rd)
            cmd.CommandText = "UPDATE [RATERISK DETAILS] SET [Principal Amount/Value Balance]= 0, [Principal Amount/Value Balance(EUR Equ)]= 0,[Next EventType]='ST-Modified'  where [RISK DATE]='" & rdsql & "' and [Next EventType]='ST' and [Next EventDate]>[RISK DATE]"
            cmd.ExecuteNonQuery()
            '******************************SPEZIALFALL THYSSEN****************************
            '*****************************************************************************
            '678100000750000 in CNY (1-3 Months)
            '678100000730000 in USD (3-6 Months)
            'PERIOD für Relevante Contracts auf 1-2 Years ändern
            Me.BgwClientRun.ReportProgress(7, "Special Case THYSSEN - Set [PERIOD]=1 - 2 Years in RATERISK DETAILS where  [Contract/Account] in (678100000750000,678100000730000) for " & rd)
            cmd.CommandText = "UPDATE [RATERISK DETAILS] SET [PERIOD]='1 - 2 Years' where [Contract/Account] in ('678100000750000','678100000730000') and [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '*****************************************************************************
            'Working Capital importieren - Working Capital des Letzten Datensatzes (NEU)
            Me.BgwClientRun.ReportProgress(8, "Select last Value of Working Capital from last RATERISK DATE")
            cmd.CommandText = "Select [Working Capital] from [RATERISK DATE] where [RateRiskDate]=(Select Max([RateRiskDate]) from [RATERISK DATE])"
            wck = Math.Round(cmd.ExecuteScalar, 0)
            'Neuanlage in RISK DATES
            Me.BgwClientRun.ReportProgress(9, "Insert New Risk Date and Working Capital in  RATERISK DATE for: " & rd)
            cmd.CommandText = "INSERT INTO [RATERISK DATE]([RateRiskDate],[Working Capital],[USER],[IdBank]) Values('" & rdsql & "','" & Str(wck) & "','" & "imported from " & " " & SystemInformation.UserName & " on " & " " & Today & "','3') "
            cmd.ExecuteNonQuery()
            'IMPORT IN RATERISK TOTALS
            Me.BgwClientRun.ReportProgress(10, "Insert new Data in RATERISK TOTALS for: " & rd)
            cmd.CommandText = "INSERT INTO [RATERISK TOTALS] ([CURRENCY],[Period],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[RISK DATE],[IdRateRiskDate]) SELECT [CURRENCY],[PERIOD],sum(PB),sum(EQB),[RISK DATE],[RISK DATE] from (Select [CURRENCY],[PERIOD],[RISK DATE],sum([Principal Amount/Value Balance]) as PB,sum([Principal Amount/Value Balance(EUR Equ)]) as EQB FROM [RATERISK DETAILS] where [RISK DATE]='" & rdsql & "' and [Type]='Assets' GROUP BY [CURRENCY],[PERIOD],[RISK DATE] Union All Select [CURRENCY],[PERIOD],[RISK DATE],sum([Principal Amount/Value Balance])*(-1) as PB ,sum([Principal Amount/Value Balance(EUR Equ)])*(-1) as EQB FROM [RATERISK DETAILS] where [RISK DATE]='" & rdsql & "' and [Type]='Liabilities' GROUP BY [CURRENCY],[PERIOD],[RISK DATE] Union All Select [CURRENCY],[PERIOD],[RISK DATE],sum([Principal Amount/Value Balance]) as PB,sum([Principal Amount/Value Balance(EUR Equ)]) as EQB FROM [RATERISK DETAILS] where [RISK DATE]='" & rdsql & "' and [Type]='Long positions' GROUP BY [CURRENCY],[PERIOD],[RISK DATE] Union All Select [CURRENCY],[PERIOD],[RISK DATE],sum([Principal Amount/Value Balance])*(-1) as PB,sum([Principal Amount/Value Balance(EUR Equ)])*(-1) as EQB FROM [RATERISK DETAILS] where [RISK DATE]='" & rdsql & "' and [Type]='Short positions' GROUP BY [CURRENCY],[PERIOD],[RISK DATE])GW  GROUP BY [CURRENCY],[PERIOD],[RISK DATE]"
            cmd.ExecuteNonQuery()
            'Update WEIGHTING FACTORS in RATERISK TOTALS
            Me.BgwClientRun.ReportProgress(11, "Update WEIGHTING FACTORS in RATERISK TOTALS for: " & rd)
            cmd.CommandText = "UPDATE A SET A.[WF1]=B.[WF-200],A.[WF2]=B.[WF+200],A.[WF3]=B.[WF+50],A.[WF4]=B.[WF-100],A.[WF10]=B.[WF],A.[WF20]=B.[WF20],A.[WF25]=B.[WF25],A.[WFHUMP]=B.[WFHUMP],A.[WF_TWIST1]=B.[WF_TWIST1],A.[WF_TWIST2]=B.[WF_TWIST2] from [RATERISK TOTALS] A INNER JOIN [RATERISK BC WF] B ON A.[Period]=B.[Period] where [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update WEIGHTING FACTORS in RATERISK TOTALS
            Me.BgwClientRun.ReportProgress(12, "Update WEIGHTING FACTORS AMOUNTS in RATERISK TOTALS for: " & rd)
            cmd.CommandText = "UPDATE [RATERISK TOTALS]  SET [AM1]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF1]/100,2),[AM2]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF2]/100,2),[AM3]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF3]/100,2),[AM4]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF4]/100,2),[AM10]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF10]/100,2),[AM20]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF20]/100,2),[AM25]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF25]/100,2),[AMHUMP]=Round([Principal Amount/Value Balance(EUR Equ)]*[WFHUMP]/100,2),[AM_TWIST1]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF_TWIST1]/100,2),[AM_TWIST2]=Round([Principal Amount/Value Balance(EUR Equ)]*[WF_TWIST2]/100,2) where [RISK DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '#####################################################################################
            'INTEREST RATE RISK AMOUNT (WEIGHTING FACTOR 15) WITHOUT SECURITIES
            '#####################################################################################
            'Me.BgwClientRun.ReportProgress(13, "Update Principal Amount/Value Balance(EUR Equ)withoutSECUR in RATERISK TOTALS for: " & rd)
            'Me.QueryText = "select sum([Principal Amount/Value Balance(EUR Equ)]) as SUMME,[PERIOD],[CURRENCY] from [RATERISK DETAILS]  where [RISK DATE]='" & rdsql & "' and [Contract Type]='SECUR' GROUP BY [PERIOD],[CURRENCY]"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For y = 0 To dt.Rows.Count - 1
            'Principal Amount (EURO) without SECUR update
            'cmd.CommandText = "UPDATE [RATERISK TOTALS] SET [Principal Amount/Value Balance(EUR Equ)withoutSECUR]= ABS([Principal Amount/Value Balance(EUR Equ)]) - " & Str(dt.Rows.Item(y).Item("SUMME")) & " where [Period]='" & dt.Rows.Item(y).Item("PERIOD") & "' and [CURRENCY]='" & dt.Rows.Item(y).Item("CURRENCY") & "' and [RISK DATE]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'Next
            'cmd.CommandText = "UPDATE [RATERISK TOTALS] SET [AM15]= Round([WF15]*[Principal Amount/Value Balance(EUR Equ)withoutSECUR]/100,2)  where [Principal Amount/Value Balance(EUR Equ)withoutSECUR] is not NULL and [RISK DATE]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            '#######################################################################################
            'SUMME
            'Me.BgwClientRun.ReportProgress(14, "Get SUM(AM1) and SUM(AM2) in RATERISK TOTALS for: " & rd)
            'cmd.CommandText = "SELECT sum([AM1]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "'"
            'summeAM1 = cmd.ExecuteScalar()
            'cmd.CommandText = "SELECT sum([AM2]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "'"
            'summeAM2 = cmd.ExecuteScalar()
            Me.BgwClientRun.ReportProgress(15, "Get SUM(AM1) and SUM(AM2) from  RATERISK TOTALS and Calculate INTEREST RATE RISK for: " & rd)
            cmd.CommandText = "UPDATE [RATERISK DATE] SET [SumAM1]=(SELECT sum([AM1]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "'), [SumAM2]=(SELECT sum([AM2]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "'), [Position/Capital]=ABS(Round((SELECT sum([AM2]) from [RATERISK TOTALS] Where [IdRateRiskDate]='" & rdsql & "')/[Working Capital]*100,2))  where [RateRiskDate]='" & rdsql & "'"
            cmd.ExecuteScalar()
            'Interest Rate Risk - ABSOLUTE NUMBER
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=ABS([Position/Capital]) where [RateRiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()

            'NEUBERECHNUNG DES INTEREST RATE RISKS nach den EIGENMITTEL KAPITAL
            'Einfügen des Eigenmittel Kapitals in RATERISK DATE
            cmd.CommandText = "SELECT [OwnCapitalBAIS] from [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql & "'"
            Dim RLDC_WorkingCapital As Double = cmd.ExecuteScalar
            If RLDC_WorkingCapital <> 0 Then
                Me.BgwClientRun.ReportProgress(60, "Insert BAIS EIGENMITTEL CAPITAL in RATE RISK (INTERST RATE RISK)")
                cmd.CommandText = "UPDATE [RATERISK DATE] SET [Working Capital]='" & Str(RLDC_WorkingCapital) & "'  WHERE [RateRiskDate]='" & rdsql & "'"
                cmd.ExecuteScalar()
                'Neuberechnung der Interest rate risk
                Me.BgwClientRun.ReportProgress(65, "Recalculate INTEREST RATE RISK")
                cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=ABS(Round([SumAM2]/[Working Capital]*100,2))  WHERE [RateRiskDate]='" & rdsql & "'"
                cmd.ExecuteScalar()

                'Neuberechnung der Interest rate risk
                Me.BgwClientRun.ReportProgress(67, "Insert EIGENMITTEL CAPITAL in MAK CR TOTALS")
                cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [WorkingCapital]='" & Str(RLDC_WorkingCapital) & "'  WHERE [RiskDate]='" & rdsql & "'"
                cmd.ExecuteScalar()

                'EINFÜGEN Neuberechnete INTEREST RATE RISK in RISK LIMIT DAILY CONTROL
                Me.BgwClientRun.ReportProgress(70, "Insert Recalculated INTEREST RATE RISK in RISK LIMIT DAILY CONTROL")
                cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                Dim t1 As String = cmd.ExecuteScalar
                If IsNothing(t1) = False Then
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Interest rate risk]=(SELECT [Position/Capital] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & rdsql & "') WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
                If IsNothing(t1) = True Then
                    cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Interest rate risk]) Values('" & rdsql & "',(SELECT [Position/Capital] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & rdsql & "'))"
                    cmd.ExecuteScalar()
                End If
            End If
        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If


        Me.BgwClientRun.ReportProgress(16, "INTEREST RATE RISK calculation finished for: " & rd)

    End Sub

    Private Sub CREDIT_RISK_MAK_CALCULATION()
        'CREDIT RISK + MAK
        CurrentClientProcedure = "CREDIT RISK and MAK"
        'Daten mit dem aktuellen rd datum löschen
        cmd.CommandText = "SELECT [DateMakCrTotals] FROM [CREDIT RISK ALL DATA] where [DateMakCrTotals]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            Me.BgwClientRun.ReportProgress(1, "Delete all Data from CREDIT RISK for " & rd)
            cmd.CommandText = "DELETE  FROM [CREDIT RISK] where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(1, "Delete all Data from MAK REPORT for " & rd)
            cmd.CommandText = "DELETE  FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(1, "Delete all Data from MAK CR TOTALS for " & rd)
            cmd.CommandText = "DELETE FROM [MAK CR TOTALS] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Neuanlage in MAK CREDIT RISK DATES
            Me.BgwClientRun.ReportProgress(2, "Insert new Risk Date in MAK CR TOTALS")
            cmd.CommandText = "INSERT INTO [MAK CR TOTALS]([RiskDate],[USER],[IdBank]) Values('" & rdsql & "','" & "imported from " & " " & SystemInformation.UserName & " on " & " " & Today & "','3') "
            cmd.ExecuteNonQuery()
            'Neuanlage in CREDIT RISK
            Me.BgwClientRun.ReportProgress(3, "Insert Data in CREDIT RISK for " & rd)
            cmd.CommandText = "INSERT INTO [CREDIT RISK]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[RiskDate],[RepDate],[DateMakCrTotals])Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[RiskDate],[RepDate],[RiskDate] FROM [CREDIT RISK ALL DATA] where [DateMakCrTotals]='" & rdsql & "' and [Contract Type] not in ('FXD','FXMK','LIMIT')"
            cmd.ExecuteNonQuery()
            'Neuanlage in MAK REPORT
            Me.BgwClientRun.ReportProgress(4, "Insert Data in MAK REPORT for " & rd)
            cmd.CommandText = "INSERT INTO [MAK REPORT]([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RepDate],[DateMakCrTotals])Select [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RepDate],[RiskDate] FROM [MAK REPORT ALL DATA] where [DateMakCrTotals]='" & rdsql & "' and [Contract Type] not in ('FXD','FXMK','LIMIT')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(5, "Update INDUSTRIAL CLASS LOCAL in MAK REPORT for " & rd)
            cmd.CommandText = "Update A set A.[IndustrialClassLocalCode]=B.[INDUSTRIAL_CLASS_LOCAL],A.[IndustrialClassLocalCodeName]=B.[INDUSTRIAL_CLASS_LOCAL_NAME] FROM [MAK REPORT] A INNER JOIN [CUSTOMER_INFO] B ON A.[Client No]=B.[ClientNo] where A.[IndustrialClassLocalCode] is NULL and A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Einfügen des WORKING CAPITALS von RATERISK DATE
            Me.BgwClientRun.ReportProgress(6, "Insert Working Capital from RATERISK DATE in MAK CR TOTALS for " & rd)
            cmd.CommandText = "UPDATE[MAK CR TOTALS] SET [WorkingCapital]=(Select [Working Capital] from [RATERISK DATE]  WHERE [RateRiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Me.BgwClientRun.ReportProgress(7, "Define SPCODE=Industry(HO), LBCODE=Counterparty/Issuer/Collateral Provider in MAK REPORT for " & rd)
            'Anfrage des SPCODES,LBCODES und SPCODES
            cmd.CommandText = "UPDATE[MAK REPORT] SET [SPCODE]=[Industry(HO)],[LBCODE]=[Counterparty/Issuer/Collateral Provider] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(7, "Define SPCODE from Parameter:MAKREPSPCODE")
            cmd.CommandText = "UPDATE A SET A.[SPCODE]=B.S from [MAK REPORT] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='MAKREPSPCODE' and [PARAMETER STATUS] ='Y')B ON A.[Counterparty/Issuer/Collateral Provider] like B.[PARAMETER1] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(7, "Define LBCODE from Parameter:MAKREPLBCODE")
            cmd.CommandText = "UPDATE A SET A.[LBCODE]=B.S from [MAK REPORT] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='MAKREPLBCODE' and [PARAMETER STATUS] ='Y')B ON A.[Counterparty/Issuer/Collateral Provider] like B.[PARAMETER1] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('MAKREPSPCODE') and [PARAMETER STATUS]='Y'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'Dim sr As String = dt.Rows.Item(i).Item("PARAMETER1") & "%"
            'cmd.CommandText = "UPDATE[MAK REPORT] SET [SPCODE]='" & dt.Rows.Item(i).Item("PARAMETER2") & "' where [RiskDate]='" & rdsql & "' and [Counterparty/Issuer/Collateral Provider] like '" & sr & "'"
            'cmd.ExecuteNonQuery()
            'Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('MAKREPLBCODE') and [PARAMETER STATUS]='Y'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'Dim sr As String = dt.Rows.Item(i).Item("PARAMETER1") & "%"
            'cmd.CommandText = "UPDATE[MAK REPORT] SET [LBCODE]='" & dt.Rows.Item(i).Item("PARAMETER2") & "' where [RiskDate]='" & rdsql & "' and [Counterparty/Issuer/Collateral Provider] like '" & sr & "'"
            'cmd.ExecuteNonQuery()
            'Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'CUSTOMER TYPE IN MAK REPORT DEFINIEREN
            Me.BgwClientRun.ReportProgress(8, "Define CUSTOMER TYPE in MAK REPORT for " & rd)
            cmd.CommandText = "UPDATE [MAK REPORT] set [CUSTOMER TYPE]=B.[ClientType] from [MAK REPORT] A INNER JOIN [CUSTOMER_INFO] B ON A.[Client No]=B.[ClientNo] where A.[CUSTOMER TYPE] is NULL and  A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Me.BgwClientRun.ReportProgress(9, "Define CLIENT GROUP NAME from Parameter REPORT/CLIENT_GROUP_DEFINE")
            cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.S from [CUSTOMER_RATING] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='CLIENT_GROUP_DEFINE' and [PARAMETER STATUS] ='Y')B ON A.[ClientGroup]=B.[PARAMETER1]"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(10, "Define SUB CLIENT GROUP NAME from Parameter REPORT/SUB_CLIENT_GROUP_DEFINE")
            cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.NewClientGroup, A.[ClientGroupName]=B.ClientGroupName from [CUSTOMER_RATING] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as ClientGroupName , [PARAMETER INFO] as NewClientGroup from [PARAMETER] where [IdABTEILUNGSPARAMETER]='SUB_CLIENT_GROUP_DEFINE' and [PARAMETER STATUS] ='Y')B ON A.[ClientNo]=B.[PARAMETER1]"
            cmd.ExecuteNonQuery()

            'Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('CLIENT_GROUP_DEFINE') and [PARAMETER STATUS]='Y'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            ' Dim ClientGroup As String = dt.Rows.Item(i).Item("PARAMETER1")
            ' Dim ClientGroupName As String = dt.Rows.Item(i).Item("PARAMETER2")
            'cmd.CommandText = "UPDATE [CUSTOMER_RATING] SET [ClientGroupName]='" & ClientGroupName & "' where [ClientGroup]= '" & ClientGroup & "'"
            'cmd.ExecuteNonQuery()
            'Next
            'Me.BgwClientRun.ReportProgress(10, "Define SUB CLIENT GROUP NAME from Parameter REPORT/SUB_CLIENT_GROUP_DEFINE")
            'Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('SUB_CLIENT_GROUP_DEFINE') and [PARAMETER STATUS]='Y'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'Dim ClientNo As String = dt.Rows.Item(i).Item("PARAMETER1")
            'Dim ClientGroupName As String = dt.Rows.Item(i).Item("PARAMETER2")
            'Dim NewClientGroup As String = dt.Rows.Item(i).Item("PARAMETER INFO")
            'cmd.CommandText = "UPDATE [CUSTOMER_RATING] SET [ClientGroup]='" & NewClientGroup & "',[ClientGroupName]='" & ClientGroupName & "' where [ClientNo]= '" & ClientNo & "'"
            'cmd.ExecuteNonQuery()
            'Next

            Me.BgwClientRun.ReportProgress(11, "Set CLIENT GROUP=0 if CLIENT GROUP is Null")
            cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]='0' where [ClientGroup] is NULL "
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(11, "Set CLIENT GROUP=CLIENT NO if CLIENT GROUP=0")
            cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]=[ClientNo]  where [ClientGroup]='0'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(11, "Define CLIENT GROUP NAME if is NULL")
            cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroupName]=[ClientName] where [ClientGroupName] is NULL "
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(11, "Modify CLIENT GROUP in MAK REPORT based on CUSTOMER RATING")
            cmd.CommandText = "UPDATE A SET A.[Client Group]=B.[ClientGroup] from [MAK REPORT] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()


            Me.BgwClientRun.ReportProgress(12, "Set Obligor Rate,PD,ER,Credit Risk Amount(EUR),Net Credit Risk Amount (EUR) to NULL")
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [Obligor Rate]='U',PD=0,[(1-ER)]=0,[Credit Risk Amount(EUR Equ)]=0,[NetCredit Risk Amount(EUR Equ)]=0 where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update Obligor Grates from Customer Ratings
            Me.BgwClientRun.ReportProgress(13, "Update Obligor Grates,PD,ER,CLIENT GROUP,CLIENT GROUP NAME and all relevant ratings from CUSTOMER RATING Table")
            cmd.CommandText = "UPDATE A SET A.[Obligor Rate]=B.[Rating],A.[PD]=B.[PD],A.[(1-ER)]=B.[ER_25],A.[(1-ER_45)]=B.[ER_45],A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MoodysRating]=B.[MoodysRating],A.[FitchRating]=B.[FitchRating],A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] FROM [CREDIT RISK] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] WHERE A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()


            'SPECIAL FALL LGD 20 % in specific Product and Business Types
            Me.BgwClientRun.ReportProgress(16, "Check SQL PARAMETER STATUS for SQL PARAMETER:CREDIT_RISK_LGD_20_SPECIAL")
            cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='CREDIT_RISK_LGD_20_SPECIAL'"
            Dim CreditRiskLGD20_Special_Result As String = cmd.ExecuteScalar
            If CreditRiskLGD20_Special_Result = "Y" Then
                Me.BgwClientRun.ReportProgress(16, "SQL PARAMETER: CREDIT_RISK_LGD_20_SPECIAL is VALID - Execute SQL Commands for CREDIT_RISK_LGD_20_SPECIAL")
                Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS]  where [Id_SQL_Parameters] in ('CREDIT_RISK_LGD_20_SPECIAL')"
                da2 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt2 = New System.Data.DataTable()
                da2.Fill(dt2)
                For i = 0 To dt2.Rows.Count - 1
                    Dim SqlCommandText As String = dt2.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                    cmd.CommandText = SqlCommandText
                    cmd.ExecuteNonQuery()
                Next
            Else
                Me.BgwClientRun.ReportProgress(16, "SQL PARAMETER: CREDIT_RISK_LGD_20_SPECIAL is INVALID - No Further Action")
            End If


            'Calculating CreditRiskAmount again
            Me.BgwClientRun.ReportProgress(17, "Calculating Credit Risk Amount (Expected Loss)  based on the new PD,ER for defined Obligor Grates (Not U and CA)")
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [Credit Risk Amount(EUR Equ)]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER)],2),[CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [Obligor Rate] not in ('U','CA')"
            cmd.ExecuteNonQuery()


            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'CASH PLEDGE - CREDIT RISK
            Me.BgwClientRun.ReportProgress(18, "Define Cashpledge in CREDIT RISK")
            Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y' and [ValidTill]>= '" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                Me.QueryText = "select * from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                For y = 0 To dt1.Rows.Count - 1
                    Dim CreditOutstandingEURequ As Double = dt1.Rows.Item(y).Item("Credit Outstanding (EUR Equ)")
                    If CreditOutstandingEURequ < CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = CashPledgeAmount - CreditOutstandingEURequ
                    ElseIf CreditOutstandingEURequ > CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]='" & Str(CreditOutstandingEURequ - CashPledgeAmount) & "',[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = 0
                    ElseIf CreditOutstandingEURequ = CashPledgeAmount Then
                        cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                        cmd.ExecuteNonQuery()
                        CashPledgeAmount = 0
                    End If
                Next
            Next
            'Credit Risk Outstanding Amount auf NetCreditRiskOutstandingAmount stellen wenn InternalInfo<>CASHPLEDGE
            Me.BgwClientRun.ReportProgress(19, "Set NetCreditOutstandingAmountEUR=Credit Risk Amount(EUR Equ) where InternalInfo not CASHPLEDGE")
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] Where [RiskDate]='" & rdsql & "' and [InternalInfo] not in ('CASHPLEDGE')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(20, "Recalculating Credit Risk Amount (Expected Loss) again based on the new PD,ER for defined Obligor Grates (Not U and CA)")
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [Credit Risk Amount(EUR Equ)]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER)],2),[CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [Obligor Rate] not in ('U','CA')"
            cmd.ExecuteNonQuery()

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Me.BgwClientRun.ReportProgress(21, "Calculating the Credit Risk Amount(EUR) SUM from CREDIT RISK Table")
            'Summe des Credit Risk Amounts(EUR Equ)
            'cmd.CommandText = "SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'"
            'sumCreditRiskAmountEUR = cmd.ExecuteScalar
            'Füllen des Feldes CREDIT RISK in Tabelle MAK CR TOTALS
            'Me.BgwClientRun.ReportProgress(22, "Inserting the Credit Risk Amount(EUR) SUM in MAK CR TOTALS Table")
            'cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRisk]='" & Str(sumCreditRiskAmountEUR) & "' WHERE [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(22, "Calculating the Credit Risk Amount(EUR) SUM from CREDIT RISK Table and Inserting the Credit Risk Amount(EUR) SUM in MAK CR TOTALS Table")
            cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRisk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "') WHERE [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Übernahme der Summen von Credit Outstanding(EUR Equ)(CREDIT RISK REPORT) und EuroEquivalent(MAK REPORT) in CR_MAK_TOTALS
            'Me.BgwClientRun.ReportProgress(23, "Calculating the Credit Outstanding (EUR Equ) SUM from CREDIT RISK Table")
            'cmd.CommandText = "SELECT Sum([Credit Outstanding (EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'"
            'sumCreditOutstandingEURequ = cmd.ExecuteScalar
            'Me.BgwClientRun.ReportProgress(24, "Calculating the Euro Equivalent SUM from MAK REPORT Table")
            'cmd.CommandText = "SELECT Sum([Euro Equivalent]) FROM [MAK REPORT] WHERE [RiskDate]='" & rdsql & "'"
            'sumMAKEuroEquivalent = cmd.ExecuteScalar
            'sumdifference = sumCreditOutstandingEURequ - sumMAKEuroEquivalent
            'Füllen der felder in Tabelle CR_MAK_TOTALS
            'Me.BgwClientRun.ReportProgress(25, "Inserting of the Credit Outstanding (EUR Equ) SUM,Euro Equivalent SUM and their calculated difference in MAK CR TOTALS Table")
            'cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditOutstandingEURequ]='" & Str(sumCreditOutstandingEURequ) & "',[SumEuroEquivalent]='" & Str(sumMAKEuroEquivalent) & "',[SumsDifference]='" & Str(sumdifference) & "' WHERE [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(25, "Calculating the Credit Outstanding (EUR Equ) SUM from CREDIT RISK Table,the Euro Equivalent SUM from MAK REPORT Table and Inserting of the Credit Outstanding (EUR Equ) SUM,Euro Equivalent SUM and their calculated difference in MAK CR TOTALS Table")
            cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditOutstandingEURequ]=(SELECT Sum([Credit Outstanding (EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'),[SumEuroEquivalent]=(SELECT Sum([Euro Equivalent]) FROM [MAK REPORT] WHERE [RiskDate]='" & rdsql & "'),[SumsDifference]=(SELECT Sum([Credit Outstanding (EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "')- (SELECT Sum([Euro Equivalent]) FROM [MAK REPORT] WHERE [RiskDate]='" & rdsql & "') WHERE [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Summe des Credit Risk Amounts(EUR Equ)
            'Me.BgwClientRun.ReportProgress(26, "Calculating the NetCredit Risk Amount(EUR Equ) SUM from CREDIT RISK Table")
            'cmd.CommandText = "SELECT Sum([NetCredit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'"
            'sumNetCreditRiskAmountEUR = cmd.ExecuteScalar
            '********************************************************************************************************************************
            'Me.BgwClientRun.ReportProgress(27, "Calculating the NetCreditRiskAmountEUREquER45 SUM from CREDIT RISK Table")
            'cmd.CommandText = "SELECT Sum([NetCreditRiskAmountEUREquER45]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'"
            'sumNetCreditRiskAmountEUR45 = cmd.ExecuteScalar
            'Me.BgwClientRun.ReportProgress(28, "Inserting of the NetCredit Risk Amount(EUR Equ) and  NetCreditRiskAmountEUREquER45 SUM in MAK CR TOTALS Table")
            'Füllen des Feldes CREDIT RISK in Tabelle MAK CR TOTALS
            'cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRiskCashpledge]='" & Str(sumNetCreditRiskAmountEUR) & "',[SumCreditRiskCashpledge45]='" & Str(sumNetCreditRiskAmountEUR45) & "' WHERE [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(28, "Calculating the NetCredit Risk Amount(EUR Equ) SUM from CREDIT RISK Table ,the NetCreditRiskAmountEUREquER45 SUM from CREDIT RISK Table and Inserting of the NetCredit Risk Amount(EUR Equ) and  NetCreditRiskAmountEUREquER45 SUM in MAK CR TOTALS Table")
            cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRiskCashpledge]=(SELECT Sum([NetCredit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'),[SumCreditRiskCashpledge45]=(SELECT Sum([NetCreditRiskAmountEUREquER45]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "') WHERE [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If

    End Sub

    Private Sub NEW_CREDIT_BUSINESS()
        CurrentClientProcedure = "NEW CREDIT BUSINESS"
        cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            Me.BgwClientRun.ReportProgress(1, "Delete all Data in NEW CREDIT BUSINESS for " & rd)
            cmd.CommandText = "DELETE  FROM [NEW CREDIT BUSINESS] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(36, "Inserting New Credit Business in NEW CREDIT BUSINESS Table after comparing Table with MAK REPORT Table")
            cmd.CommandText = "INSERT INTO   [NEW CREDIT BUSINESS] ([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[SPCODE],[LBCODE],[STRCODE],[BTCODE],[CUSTOMER TYPE],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RepDate],[DateMakCrTotals]) select [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[SPCODE],[LBCODE],[STRCODE],[BTCODE],[CUSTOMER TYPE] ,[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RepDate],[DateMakCrTotals] from   [MAK REPORT] where  [RiskDate]='" & rdsql & "' and [Contract Collateral ID] not in (Select [Contract Collateral ID] from [NEW CREDIT BUSINESS])"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(37, "Update Product Type Name in New Credit Business Table")
            cmd.CommandText = "UPDATE A SET A.[ProductTypeName]=B.[Product Type Name] FROM [NEW CREDIT BUSINESS] A INNER JOIN [ProductType] B ON A.[Product Type]=B.[Product Type] where A.[ProductTypeName] is NULL "
            cmd.ExecuteNonQuery()
        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If
    End Sub

    Private Sub FX_CREDIT_EQUIV_CALCULATION()
        CurrentClientProcedure = "FX CREDIT EQUIVALENT CALCULATION"
        Me.BgwClientRun.ReportProgress(1, "Start the FX CREDIT EQUIVELANT CALCULATION for " & rd)
        cmd.CommandText = "SELECT [RiskDate] FROM [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            cmd.CommandText = "DELETE  FROM [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE  FROM [FX CREDIT EQUIVALENT Basic] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Import Data in details
            Me.BgwClientRun.ReportProgress(2, "Insert Data in FX CREDIT EQUIVALENT Details from FX DAILY REVALUATION where DealType in (FW,SW) and MaturityDate > RiskDate for " & rd)
            cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Details]([Class],[ContractType],[ProductType],[Contract],[Counterparty_Name],[Counterparty_No],[TradeDate],[StartDate],[Final_Maturity_Date],[AmountType],[OrgCcy],[OrgCcyAmount],[RiskDate],[RepDate])SELECT [DealType],[ContractType],[ProductType],[ContractNr],[ClientName],[ClientNo],[InputDate],[ValueDate],[MaturityDate],'Bank Buy Amount',[BuyCCY],[BuyAmount],[RiskDate],[RiskDate] from [FX DAILY REVALUATION] where [DealType] in ('FW','SW') and [MaturityDate]>[RiskDate] and [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update Client Group in Details
            Me.BgwClientRun.ReportProgress(3, "Update Client Group Nr. and client Group Name in FX CREDIT EQUIVALENT Details from CUSTOMER_RATING")
            cmd.CommandText = "UPDATE A SET A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [CUSTOMER_RATING] B ON A.[Counterparty_No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update Client Group in Details
            Me.BgwClientRun.ReportProgress(4, "Set Client Group and Name to UNDEFINED if Client Nr is NULL")
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] SET [ClientGroup]=999999,[ClientGroupName]='UNDEFINED GROUP' where [Counterparty_No] is NULL and [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(5, "Set Client Group=Client Nr in FX CREDIT EQUIVALENT Details where Client Group is NULL")
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] SET [ClientGroup]=[Counterparty_No],[ClientGroupName]=[Counterparty_Name]  where [ClientGroup] is NULL and [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update OCBS Exchange Rates-Last working day
            Me.BgwClientRun.ReportProgress(6, "Update Exchange Rates in FX CREDIT EQUIVALENT Details")
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] set [ExchangeRate]=1 where [OrgCcy]='EUR' and [ExchangeRate] is NULL and [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[ExchangeRate] is NULL and B.[EXCHANGE RATE DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Calculate EuroEquivelant
            Me.BgwClientRun.ReportProgress(7, "Calculate Euro Equivalent nominal amount in FX CREDIT EQUIVALENT Details")
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] set [EURequ]=Round([OrgCcyAmount]/[ExchangeRate],2) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteScalar()
            'Import Data in Basic
            Me.BgwClientRun.ReportProgress(8, "Import Data in FX CREDIT EQUIVALENT Basic")
            cmd.CommandText = "INSERT INTO [FX CREDIT EQUIVALENT Basic]([RiskDate],[ClientGroup])select [RiskDate],[ClientGroup] from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [RiskDate],[ClientGroup]"
            cmd.ExecuteNonQuery()
            'Update Client Group Name
            Me.BgwClientRun.ReportProgress(9, "Update Client Group Name in FX CREDIT EQUIVALENT Basic")
            cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [FX CREDIT EQUIVALENT Basic] A INNER JOIN [FX CREDIT EQUIVALENT Details] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details
            Me.BgwClientRun.ReportProgress(10, "Update IdFX_CRED_EQU_BASIC in FX CREDIT EQUIVALENT Details")
            cmd.CommandText = "UPDATE A set A.[IdFX_CRED_EQU_BASIC]=B.[ID] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [FX CREDIT EQUIVALENT Basic] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]=B.[RiskDate] and A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update PD,LGD,Obligor Rate in FX CREDIT EQUIVALENT Details
            Me.BgwClientRun.ReportProgress(11, "Update PD,LGD,Obligor Rate in FX CREDIT EQUIVALENT Details")
            cmd.CommandText = "UPDATE A SET A.[PD]=B.[PD],A.[LGD]=B.[ER_45],A.[Obligor Rate]=B.[Rating] from [FX CREDIT EQUIVALENT Details] A INNER JOIN [CUSTOMER_RATING] B ON A.[Counterparty_No]=B.[ClientNo] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update MonthsToEventStartDay
            Me.BgwClientRun.ReportProgress(12, "Update MonthsToEventStartDay in FX CREDIT EQUIVALENT Details")
            'OLD CODE
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [MonthToEventStartDate]=(Case when DATENAME(dw,[Final_Maturity_Date])='Monday' then DATEDIFF(day,[StartDate],[Final_Maturity_Date])-2 else DATEDIFF(day,[StartDate],[Final_Maturity_Date])end) where  [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate= If Trade Date=Start Date then Start Date + 2")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when [TradeDate]=[StartDate] then DATEADD(day,2,[StartDate])else [StartDate] end) where  [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()

            'NEW CODE
            'Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate= If Trade Date=Start Date and Start Date in THURSDAY or FRIDAY then Start Date + 4")
            'Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate= If Trade Date=Start Date and Start Date not in THURSDAY or FRIDAY then Start Date + 2")
            'Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate= If Trade Date<>Start Date then Start Date")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when [TradeDate]=[StartDate] and DATENAME(dw,[StartDate]) in ('Thursday','Friday')then DATEADD(day,4,[StartDate])when [TradeDate]=[StartDate] and DATENAME(dw,[StartDate]) not in ('Thursday','Friday')then DATEADD(day,2,[StartDate])else [StartDate] end) where  [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            'Me.BgwClientRun.ReportProgress(12, "Modify ModifiedStartDate= If Saturday then + 2 Days and If Sunday then + 1")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when DATENAME(dw,[ModifiedStartDate]) in ('Sunday') then DATEADD(day,1,[ModifiedStartDate])when DATENAME(dw,[ModifiedStartDate]) in ('Saturday') then DATEADD(day,2,[ModifiedStartDate])else [ModifiedStartDate]end) where  [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate= If Trade Date=Start Date then StartDate + Next Business Day (SQL Function=GetNextWorkingDate) + 1 ELSE StartDate")
            cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when [TradeDate]=[StartDate] then dbo.GetNextWorkingDay([StartDate])+1 else [StartDate] end) where  [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(12, "Modify ModifiedStartDate= If Saturday then + 2 Days and If Sunday then + 1")
            cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=(Case when DATENAME(dw,[ModifiedStartDate]) in ('Sunday') then DATEADD(day,1,[ModifiedStartDate])when DATENAME(dw,[ModifiedStartDate]) in ('Saturday') then DATEADD(day,2,[ModifiedStartDate])else [ModifiedStartDate]end) where  [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(12, "Update ModifiedStartDate= If Modified Start Date is HOLIDAY then GetNextWorkingDate ELSE ModifiedStartDate")
            cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [ModifiedStartDate]=dbo.GetNextWorkingDay([ModifiedStartDate]) where  [RiskDate]='" & rdsql & "' and [ModifiedStartDate] in (Select [CalendarDate] from [Calendar] where [HolidayType] in ('H'))"
            cmd.ExecuteNonQuery()
            'Me.BgwClientRun.ReportProgress(12, "Update MonthToEventStartDate= If FinalMaturityDate is MONDAY then - 3 Days")
            'cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [MonthToEventStartDate]=(Case when DATENAME(dw,[Final_Maturity_Date]) in ('Monday') then DATEDIFF(day,[ModifiedStartDate],[Final_Maturity_Date])-3 else DATEDIFF(day,[ModifiedStartDate],[Final_Maturity_Date])end) where  [RiskDate]='" & rdsql & "'"
            'cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(12, "Update Modified_FinalMaturityDate=If Final_Maturity_Date is MONDAY then - 3 Days else Final_Maturity_Date")
            cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [Modified_Final_Maturity_Date]=(Case when DATENAME(dw,[Final_Maturity_Date]) in ('Monday') then [Final_Maturity_Date]-3 else [Final_Maturity_Date] end)  where  [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(12, "Update MonthToEventStartDate to Years(NOT CONSIDERING LEAP YEARS)")
            cmd.CommandText = "Update [FX CREDIT EQUIVALENT Details] set [MonthToEventStartDate]=dbo.yearDiff([Modified_Final_Maturity_Date],[ModifiedStartDate]) where  [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            'Update Percent Calculation in FX CREDIT EQUIVALENT Details (NEW)
            Me.BgwClientRun.ReportProgress(13, "Update Percent Calculation in FX CREDIT EQUIVALENT Details where Modified Start Date <= Business Date and Modified Final Maturity Date <> Working Date")
            'cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.02 where [MonthToEventStartDate]<=365 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.05 where [MonthToEventStartDate]>365 and [MonthToEventStartDate]<=730 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "'end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.08 where [MonthToEventStartDate]>730 and [MonthToEventStartDate]<=1095 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.11 where [MonthToEventStartDate]>1095 and [MonthToEventStartDate]<=1460 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.14 where [MonthToEventStartDate]>1460 and [MonthToEventStartDate]<=1825 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.17 where [MonthToEventStartDate]>1825 and [MonthToEventStartDate]<=2190 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.20 where [MonthToEventStartDate]>2190 and [MonthToEventStartDate]<=2555 and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end"
            'cmd.ExecuteNonQuery()
            'cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.02 where [MonthToEventStartDate]<=365 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.05 where [MonthToEventStartDate]>365 and [MonthToEventStartDate]<=730 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "'end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.08 where [MonthToEventStartDate]>730 and [MonthToEventStartDate]<=1095 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.11 where [MonthToEventStartDate]>1095 and [MonthToEventStartDate]<=1460 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.14 where [MonthToEventStartDate]>1460 and [MonthToEventStartDate]<=1825 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.17 where [MonthToEventStartDate]>1825 and [MonthToEventStartDate]<=2190 and [Final_Maturity_Date]<> '" & rdsql & "' and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.20 where [MonthToEventStartDate]>2190 and [MonthToEventStartDate]<=2555 and [ModifiedStartDate]<= '" & rdsql & "' and [Final_Maturity_Date]<> '" & rdsql & "'  and [RiskDate]='" & rdsql & "' end"
            'cmd.ExecuteNonQuery()
            cmd.CommandText = "SELECT * FROM [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.02 where [MonthToEventStartDate]<=1 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.05 where [MonthToEventStartDate]>1 and [MonthToEventStartDate]<=2 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "'end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.08 where [MonthToEventStartDate]>2 and [MonthToEventStartDate]<=3 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.11 where [MonthToEventStartDate]>3 and [MonthToEventStartDate]<=4 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.14 where [MonthToEventStartDate]>4 and [MonthToEventStartDate]<=5 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.17 where [MonthToEventStartDate]>5 and [MonthToEventStartDate]<=6 and [Modified_Final_Maturity_Date]<> '" & rdsql & "' and [ModifiedStartDate]<= '" & rdsql & "' and [RiskDate]='" & rdsql & "' end begin update [FX CREDIT EQUIVALENT Details] set [PercentCalculation]=0.20 where [MonthToEventStartDate]>6 and [MonthToEventStartDate]<=7 and [ModifiedStartDate]<= '" & rdsql & "' and [Modified_Final_Maturity_Date]<> '" & rdsql & "'  and [RiskDate]='" & rdsql & "' end"
            cmd.ExecuteNonQuery()
            'Update EURequCalculated in FX CREDIT EQUIVALENT Details and CreditRiskAmountER
            Me.BgwClientRun.ReportProgress(14, "Update EURequCalculated  and CreditRiskAmountER in FX CREDIT EQUIVALENT Details")
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] set [EURequCalculated]=[EURequ]*[PercentCalculation] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX CREDIT EQUIVALENT Details] SET [CreditRiskAmountER]=[EURequCalculated]*[PD]*[LGD] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Update Sum Fields in FX CREDIT EQUIVALENT Basic
            Me.BgwClientRun.ReportProgress(15, "Update Sum Fields in FX CREDIT EQUIVALENT Basic")
            cmd.CommandText = "UPDATE A SET A.[SumEURequ]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequ]) as S from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmount]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountTill1Jear]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [PercentCalculation]=0.02 and [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver1Till2Years]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [PercentCalculation]=0.05 and [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditEquivelantAmountOver2Years]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([EURequCalculated]) as S from [FX CREDIT EQUIVALENT Details] where [PercentCalculation]=0.08 and [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[CreditRiskAmountSUM]=B.S from [FX CREDIT EQUIVALENT Basic] A INNER JOIN (Select [IdFX_CRED_EQU_BASIC],Sum([CreditRiskAmountER]) as S from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' group by [IdFX_CRED_EQU_BASIC]) B on A.[ID]=B.[IdFX_CRED_EQU_BASIC] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            'Calculation of the Own Deals revaluation
            cmd.CommandText = "UPDATE A SET A.[SpotBuyRate]=B.[MIDDLE RATE] FROM [FX DAILY REVALUATION] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[BuyCCY]=B.[CURRENCY CODE] AND A.[RiskDate]=B.[EXCHANGE RATE DATE] and B.[EXCHANGE RATE DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[SpotSellRate]=B.[MIDDLE RATE] FROM [FX DAILY REVALUATION] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[SellCCY]=B.[CURRENCY CODE] AND A.[RiskDate]=B.[EXCHANGE RATE DATE] and B.[EXCHANGE RATE DATE]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[TradeBuyRate]=B.[MIDDLE RATE] FROM [FX DAILY REVALUATION] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[BuyCCY]=B.[CURRENCY CODE] AND A.[InputDate]=B.[EXCHANGE RATE DATE] and A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[TradeSellRate]=B.[MIDDLE RATE] FROM [FX DAILY REVALUATION] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[SellCCY]=B.[CURRENCY CODE] AND A.[InputDate]=B.[EXCHANGE RATE DATE] and A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [SpotBuyRate]=1,[TradeBuyRate]=1 where [BuyCCY]='EUR' and [RiskDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [SpotSellRate]=1,[TradeSellRate]=1 where [SellCCY]='EUR' and [RiskDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            'Berechnungen
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [TradeDateBuySellAmount]=Round(([BuyAmount]/[TradeBuyRate])-([SellAmount]/[TradeSellRate]),2) where [RiskDate]='" & rdsql & "' and [OwnDeal]='Y'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [AmortizationToRiskDate]=Round((([TradeDateBuySellAmount]/Datediff(day,[InputDate],[MaturityDate])) * Datediff(day,[InputDate],[RiskDate]+1)),2) where [RiskDate]='" & rdsql & "' and [OwnDeal]='Y'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [Buy2Buy1Amount]=Round(([BuyAmount]/[SpotBuyRate])-([BuyAmount]/[TradeBuyRate]),2) where [RiskDate]='" & rdsql & "'  and [OwnDeal]='Y'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [Sell2Sell1Amount]=Round(([SellAmount]/[SpotSellRate])-([SellAmount]/[TradeSellRate]),2) where [RiskDate]='" & rdsql & "'  and [OwnDeal]='Y'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [FX DAILY REVALUATION] SET  [IDW_Amount]=Round(([BuyAmount]/[SpotBuyRate])-([SellAmount]/[SpotSellRate]),2)-[TradeDateBuySellAmount] where [RiskDate]='" & rdsql & "' and [OwnDeal]='Y'"
            cmd.ExecuteNonQuery()

        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If
        Me.BgwClientRun.ReportProgress(16, "The daily FX CREDIT EQUIVELANT CALCULATION is finished")
    End Sub

    Private Sub UNEXPECTED_LOSS_CALCULATION()
        CurrentClientProcedure = "UNEXPECTED LOSS CALCULATION"
        Me.BgwClientRun.ReportProgress(1, "Start UNEXPECTED LOSS Calculation for " & rd)
        cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'INSERT RELEVANT FX DEALS IN CREDIT RISK
            cmd.CommandText = "INSERT INTO [CREDIT RISK]([Obligor Rate],[Contract Type],[Product Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER_45)],[RiskDate],[RepDate],[DateMakCrTotals],[ClientGroup],[ClientGroupName]) Select [Obligor Rate],[ContractType],[ProductType],[Counterparty_Name],[Counterparty_No],[Contract],[Final_Maturity_Date],[OrgCcy],[OrgCcyAmount],[EURequ],[EURequCalculated],'FX DEAL',[PD],[LGD],[RiskDate],[RepDate],[RiskDate],[ClientGroup],[ClientGroupName] from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' and  [PD]<>0"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A SET A.[(1-ER)]=B.[ER_25],A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MoodysRating]=B.[MoodysRating],A.[FitchRating]=B.[FitchRating] FROM [CREDIT RISK] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] WHERE A.[RiskDate]='" & rdsql & "' and A.[InternalInfo]='FX DEAL' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [Credit Risk Amount(EUR Equ)]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER)],2),[CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [InternalInfo]='FX DEAL' "
            cmd.ExecuteNonQuery()

            '*******SPLITING CCB GROUP**********
            Me.BgwClientRun.ReportProgress(10, "Update ClientGroupN and ClientGroupNameN (Parameter:REPORTS/CCB_INDIVIDUAL_GROUP) in CREDIT RISK")
            Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('CCB_INDIVIDUAL_GROUP') and [PARAMETER STATUS]='Y'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim sr As String = dt.Rows.Item(i).Item("PARAMETER1") & "%"
                cmd.CommandText = "UPDATE [CREDIT RISK] SET [ClientGroupN]='" & dt.Rows.Item(i).Item("PARAMETER2") & "',[ClientGroupNameN]='" & dt.Rows.Item(i).Item("PARAMETER INFO") & "' where [RiskDate]='" & rdsql & "' and [Counterparty/Issuer/Collateral Name] like '" & sr & "'"
                cmd.ExecuteNonQuery()
            Next
            Me.BgwClientRun.ReportProgress(80, "Set defaults in Individual Client Group")
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [ClientGroupN]=[ClientGroup],[ClientGroupNameN]=[ClientGroupName] where [RiskDate]='" & rdsql & "' and [ClientGroupN] is NULL "
            cmd.ExecuteNonQuery()


            'Calculation in CREDIT RISK
            'Define MaturityWithoutCapFloor in CREDIT RISK
            Me.BgwClientRun.ReportProgress(16, "Define MaturityWithoutCapFloor in CREDIT RISK")
            Dim NextHalfYearDate As Date = DateAdd(DateInterval.Month, 6, rd)
            Me.QueryText = "select * from [CREDIT RISK] where [RiskDate]='" & rdsql & "' and [Maturity Date] is not NULL"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ID As String = dt.Rows.Item(i).Item("ID")
                Dim MaturityDate As Date = dt.Rows.Item(i).Item("Maturity Date")
                Dim DiffernceRiskDateMaturityDate As Double = 0
                If MaturityDate = DateSerial(9999, 12, 31) Then
                    DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, NextHalfYearDate) / 365.25, 2)
                    cmd.CommandText = "UPDATE [CREDIT RISK] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                    cmd.ExecuteNonQuery()
                Else
                    DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, MaturityDate) / 365.25, 2)
                    cmd.CommandText = "UPDATE [CREDIT RISK] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next


            Me.BgwClientRun.ReportProgress(2, "Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted in CREDIT RISK for " & rd)
            cmd.CommandText = "UPDATE [CREDIT RISK] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2) where  [RiskDate]='" & rdsql & "' and [PD]<>0"
            cmd.ExecuteNonQuery()
            'UNEXPECTED LOSS
            Me.BgwClientRun.ReportProgress(3, "Insert Risk Date in UNEXPECTED_LOSS_DATE Table for " & rd)
            cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS_DATE](RiskDate) Values('" & rdsql & "')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(4, "Insert Client Group,Risk Date from CREDIT RISK in UNEXPECTED LOSS Table grouped by Client Group and RiskDate for " & rd)
            cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS]([ClientGroup],[RiskDate]) SELECT [ClientGroupN],[RiskDate] from [CREDIT RISK] where [RiskDate]='" & rdsql & "' GROUP BY [ClientGroupN],[RiskDate]"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(5, "Update Client Group Name in UNEXPECTED LOSS Table")
            cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupNameN] from [UNEXPECTED_LOSS] A INNER JOIN [CREDIT RISK] B ON A.[ClientGroup]=B.[ClientGroupN] where A.[RiskDate]='" & rdsql & "' and B.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(6, "Insert relevant Data to UNEXPECTED_LOSS_Details")
            Me.QueryText = "Select [ID],[ClientGroup] from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "' "
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ID As Double = dt.Rows.Item(i).Item("ID")
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[EaDweigthedMaturityWithoutCapFloor],[PDxFinalEaD],[LGDfinalEaDweighted],[RiskDate],[IdClientGroup]) SELECT B.[Obligor Rate],B.[Contract Type],B.[Product Type],B.[GL Master / Account Type],B.[Counterparty/Issuer/Collateral Name],B.[Client No],B.[Contract Collateral ID],B.[Maturity Date],B.[Remaining Year(s) to Maturity],B.[Org Ccy],B.[Credit Outstanding (Org Ccy)],B.[Credit Outstanding (EUR Equ)],B.[NetCreditOutstandingAmountEUR],B.[InternalInfo],B.[PD],B.[(1-ER)],B.[Credit Risk Amount(EUR Equ)],B.[NetCredit Risk Amount(EUR Equ)],B.[(1-ER_45)],B.[CreditRiskAmountEUREquER45],B.[NetCreditRiskAmountEUREquER45],B.[CoreDefinition],B.[ClientGroupN],B.[ClientGroupNameN],B.[MaturityWithoutCapFloor],B.[EaDweigthedMaturityWithoutCapFloor],B.[PDxFinalEaD],B.[LGDfinalEaDweighted],B.[RiskDate]," & Str(ID) & " from [CREDIT RISK] B where B.[ClientGroupN]='" & ClientGroup & "' and B.[RiskDate]='" & rdsql & "' and B.[PD]<>0"
                cmd.ExecuteNonQuery()
            Next


            Me.BgwClientRun.ReportProgress(7, "Update SubBorrowersCounter in UNEXPECTED LOSS Table from CREDIT RISK where PD<>0")
            Me.QueryText = "Select Count([ClientGroupN]) as SubBorrowerCount,[ClientGroupN] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0  GROUP BY [ClientGroupN]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroupN")
                Dim SubBorrowerCount As Double = dt.Rows.Item(i).Item("SubBorrowerCount")
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [SubBorrowersCounter]=" & Str(SubBorrowerCount) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
            Next
            Me.BgwClientRun.ReportProgress(8, "Update FinalEadTotalSum,LGD,PD_EaD_weigthed in UNEXPECTED LOSS Table from CREDIT RISK  where PD<>0 and Contract Type <>LIMIT")
            Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroupN] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0  GROUP BY [ClientGroupN]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroupN")
                Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
                If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                End If
                Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
                cmd.CommandText = "Select [FinalEadTotalSum] from [UNEXPECTED_LOSS] where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
                Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
                If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                    Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                End If
            Next
            Me.BgwClientRun.ReportProgress(9, "Update PD_3bps_floor in UNEXPECTED LOSS Table")
            Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' GROUP BY [ClientGroup],[PD_EaD_weighted]"
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
                    'MsgBox("Greater" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                Else
                    MaxNumber = CheckNumber
                    'MsgBox("Less" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                End If
                Dim SecondNumber As Double = 0
                If PD_EaD_weighted = 0 Then
                    SecondNumber = 0
                    'MsgBox("Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                Else
                    SecondNumber = 1
                    'MsgBox("Not Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                End If
                Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
                'MsgBox("PD_3bpsfloor " & PD_3bps_floor)
                'Get IndicatorOfFloor
                Dim IndicatorOfFloor As Double = 0
                Dim difference As Double = PD_3bps_floor - PD_EaD_weighted
                'MsgBox(difference)
                If difference > 0 Then
                    IndicatorOfFloor = 1
                Else
                    IndicatorOfFloor = 0
                End If
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "'"
                cmd.ExecuteNonQuery()
            Next
            Me.BgwClientRun.ReportProgress(10, "Update MaturityEADweigthed in UNEXPECTED LOSS Table")
            Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroupN] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0  GROUP BY [ClientGroupN]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroupN")
                Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
                cmd.CommandText = "Select [FinalEadTotalSum] from [UNEXPECTED_LOSS] where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
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
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
            Next
            Me.BgwClientRun.ReportProgress(11, "Update R_CoefficientOfColleration and b_MaturityAdjustment in UNEXPECTED LOSS Table")
            Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "'  GROUP BY [ClientGroup],[PD_3bps_floor]"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                Dim PDminus As Double = PD * (-50)
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where  [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                cmd.ExecuteNonQuery()
                'Set b_MaturityAdjustment to 0 if NULL
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [b_MaturityAdjustment]=0 where  [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment] is NULL"
                cmd.ExecuteNonQuery()
            Next
            'Get LevelOfConfidence from UNEXPTECTED_LOSS_DATE
            Me.BgwClientRun.ReportProgress(12, "Get LEVEL OF CONFIDENCE from UNEXPECTED LOSS DATE Table")
            cmd.CommandText = "Select [LevelOfConfidence] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
            Dim LevelOfConfidence As Double = cmd.ExecuteScalar

            Me.BgwClientRun.ReportProgress(13, "Update RW_RiskWeightedExposure and UL_UnexpectedLoss in UNEXPECTED LOSS Table")
            Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment]<>0"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim ID As String = dt.Rows.Item(i).Item("ID")
                Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
                Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
                Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
                Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
                'Get First Part of Formula
                cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "' "
                Dim FirstPartFormulaRW = cmd.ExecuteScalar
                'Get Second Part of Formula
                cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "'"
                Dim SecondPartFormulaRW = cmd.ExecuteScalar
                Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
                cmd.ExecuteNonQuery()
            Next
            Me.BgwClientRun.ReportProgress(14, "Update Sum Unexpected Loss in UNEXPECTED LOSS DATE Table")
            cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "' and [InternalInfo]='FX DEAL'"
            cmd.ExecuteNonQuery()


            'GRANULARITY APPROACH
            CurrentClientProcedure = "GRANULARITY APPROACH CALCULATION"
            Me.BgwClientRun.ReportProgress(1, "Start GRANULARITY APPROACH Calculation for " & rd)
            Me.BgwClientRun.ReportProgress(2, "Calculate s_i Value for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS] set [s_i]=Round([FinalEadTotalSum]/(select Sum([FinalEadTotalSum]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'),10) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Calculate K_i Value for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS] set [K_i]=(select Case [FinalEadTotalSum] when 0 then 0 else Round([UL_UnexpectedLoss]/[FinalEadTotalSum],10) end) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(4, "Calculate R_i Value for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS] set [R_i]=Round([LGD]*[PD_3bps_floor],10) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(5, "Calculate VLGD_i Value for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS] set [VLGD_i]=Round((select nu_Value from UNEXPECTED_LOSS_DATE where [RiskDate]='" & rdsql & "')*[LGD]*(1-[LGD]),10) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(6, "Calculate C_i Value for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS] set [C_i]=(Power([LGD],2)+[VLGD_i])/[LGD] where [RiskDate]='" & rdsql & "' and [LGD]<>0"
            cmd.ExecuteNonQuery()

            Me.BgwClientRun.ReportProgress(7, "Calculate GAMMAINV for " & rd)
            Me.QueryText = "Select * from [UNEXPECTED_LOSS_DATE]  Where [RiskDate]='" & rdsql & "'"
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



            Me.BgwClientRun.ReportProgress(8, "Calculate DELTA Value for " & rd)
            Dim DELTA_VALUE As Double = Math.Round((GAMMA_INV - 1) * (p_alpha_Value + (1 - p_alpha_Value) / (GAMMA_INV)), 10)
            Me.BgwClientRun.ReportProgress(9, "Update DELTA Value and GAMMAINV for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS_DATE] set [Gamma_inv]=" & Str(GAMMA_INV) & ",[Delta]=" & Str(DELTA_VALUE) & " where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(10, "Calculate and Insert K_Value for " & rd)
            cmd.CommandText = "Update [UNEXPECTED_LOSS_DATE] set [K_Value]= (Select Round(Sum([s_i]*[K_i]),10) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
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

            Me.BgwClientRun.ReportProgress(10, "Calculate GA_n Value for " & rd)
            Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [LGD]<>0"
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

                cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [GA_n]=" & Str(TOTAL_CALCULATION) & " where [ID]=" & IDNR & ""
                cmd.ExecuteNonQuery()

            Next
            Me.BgwClientRun.ReportProgress(10, "Calculate and Insert Sum GA_rel Value for " & rd)
            cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumGA_rel]=(Select Round(Sum([GA_n])/(Select 2*[K_Value] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'),10) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            Me.BgwClientRun.ReportProgress(10, "Calculate and Insert Sum GA_Total Value for " & rd)
            cmd.CommandText = "Select Sum([FinalEadTotalSum]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
            Dim SummeFinalEADTotalSum As Double = cmd.ExecuteScalar
            cmd.CommandText = "Select [SumGA_rel] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
            Dim SummeGArel As Double = cmd.ExecuteScalar
            Dim SummeGA_Total As Decimal = Math.Round(SummeGArel * SummeFinalEADTotalSum, 2)
            cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumGA_Total]='" & Str(SummeGA_Total) & "' where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If

    End Sub

    Private Sub DAILY_ART13_KWG_CHINESE_BANKS_CALCULATION()
        CurrentClientProcedure = "ART.13 KWG CHINESE BANKS CALCULATION"
        Me.BgwClientRun.ReportProgress(1, "Start Artikel 13 KWG for Chinesse Banks calculation")
        cmd.CommandText = "SELECT [RiskDate] FROM [MAK REPORT] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            cmd.CommandText = "DELETE  FROM [Daily_Art13_Kwg_ChineseBanks] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(10, "Insert only CCB Banks Guarantees (MAK REPORT) where Country of Risk is CHINA and HONG KONG - SPCODE is CCBG")
            cmd.CommandText = "INSERT INTO [Daily_Art13_Kwg_ChineseBanks]([Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate])Select [Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate] from [MAK REPORT] where [RiskDate]='" & rdsql & "' and [Contract Type]='CLGU' and [Country of Risk] in ('CN','HK') and [Industry(HO)]='J' and [SPCODE] in ('CCBG')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(10, "Insert Nostro Account from MAK REPORT where Client Nr. in PARAMETERS/REPORT/ARTIKEL 13 NOSTRO ACCOUNTS")
            cmd.CommandText = "INSERT INTO [Daily_Art13_Kwg_ChineseBanks]([Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate])Select [Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate] from [MAK REPORT] where [RiskDate]='" & rdsql & "' and [Contract Type]='NOSTRO' and [Client No] in (Select [PARAMETER2] from [PARAMETER] where [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='ARTIKEL 13 NOSTRO ACCOUNTS')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(20, "Insert all Data from other Banks (MAK REPORT) where Country of Risk is CHINA and HONG KONG and SPCODE is not CCBG")
            cmd.CommandText = "INSERT INTO [Daily_Art13_Kwg_ChineseBanks]([Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate])Select [Contract Type],[Product Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate] from [MAK REPORT] where [RiskDate]='" & rdsql & "' and [Country of Risk] in ('CN','HK') and [Industry(HO)]='J' and [SPCODE] not in ('CCBG')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(30, "Update ContractTypeName from ContractType Table")
            cmd.CommandText = "UPDATE A SET A.[ContractTypeName]=B.[Contract Type Name(English)] from [Daily_Art13_Kwg_ChineseBanks] A INNER JOIN [ContractType] B ON A.[Contract Type]=B.[Contract Type]"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(40, "Insert Data from FX CREDIT EQUIVALENT Calculation where Client Group is 1000")
            cmd.CommandText = "INSERT INTO [Daily_Art13_Kwg_ChineseBanks]([Contract Type],[Product Type],[ContractTypeName],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate])Select [ContractType],[ProductType],'FX CREDIT EQUIVALENT',[Counterparty_Name],[Counterparty_No],[ClientGroup],[Contract],[OrgCcy],[OrgCcyAmount],[EURequCalculated],[RiskDate] from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' and [ClientGroup] in ('1000')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(40, "Insert Data from FX CREDIT EQUIVALENT Calculation where Risk Country is CHINA and HONG KONG and Contract Collateral Id not in Daily_Art13_Kwg_ChineseBanks")
            cmd.CommandText = "INSERT INTO [Daily_Art13_Kwg_ChineseBanks]([Contract Type],[Product Type],[ContractTypeName],[Counterparty/Issuer/Collateral Provider],[Client No],[Client Group],[Contract Collateral ID],[Org Ccy],[Credit Exposure],[Euro Equivalent],[RiskDate])Select [ContractType],[ProductType],'FX CREDIT EQUIVALENT',[Counterparty_Name],[Counterparty_No],[ClientGroup],[Contract],[OrgCcy],[OrgCcyAmount],[EURequCalculated],[RiskDate] from [FX CREDIT EQUIVALENT Details] where [RiskDate]='" & rdsql & "' and [Counterparty_No] in (Select [ClientNo] from [CUSTOMER_INFO] where [RiskCountry] in ('CN','HK') and [INDUSTRIAL_CLASS_CN] in ('J')) and [Contract] not in (Select [Contract Collateral ID]  from [Daily_Art13_Kwg_ChineseBanks] where [RiskDate]='" & rdsql & "')"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(50, "Delete Data if EurEquivalent is 0")
            cmd.CommandText = "DELETE  FROM [Daily_Art13_Kwg_ChineseBanks] where [RiskDate]='" & rdsql & "' and [Euro Equivalent]=0"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(60, "Update Client Group Name")
            cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [Daily_Art13_Kwg_ChineseBanks] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client Group]=B.[ClientGroup] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(70, "Update Individual Client Group (Parameter:REPORT\CCB_INDIVIDUAL_GROUP)")
            cmd.CommandText = "UPDATE A SET A.[IndividualClientGroup]=B.S, A.[IndividualNameClientGroup]=B.N from [Daily_Art13_Kwg_ChineseBanks] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S,[PARAMETER INFO] as N from [PARAMETER] where [IdABTEILUNGSPARAMETER]='CCB_INDIVIDUAL_GROUP' and [PARAMETER STATUS] ='Y')B ON A.[Counterparty/Issuer/Collateral Provider]  like B.[PARAMETER1] where A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(40, "Remove from EuroEquivalent the accrued interests only for Product Type is FORFTDL")
            cmd.CommandText = "UPDATE A SET A.[Euro Equivalent]=A.[Euro Equivalent]-B.[Accrued Interest] from [Daily_Art13_Kwg_ChineseBanks] A INNER JOIN [MAK REPORT] B ON A.[Contract Collateral ID]=B.[Contract Collateral ID] where A.[RiskDate]=B.[RiskDate] and B.[RiskDate]='" & rdsql & "' and A.[Product Type] in ('FORFTDL')"
            cmd.ExecuteNonQuery()
            'Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('CCB_INDIVIDUAL_GROUP') and [PARAMETER STATUS]='Y'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'Dim sr As String = dt.Rows.Item(i).Item("PARAMETER1") & "%"
            'cmd.CommandText = "UPDATE[Daily_Art13_Kwg_ChineseBanks] SET [IndividualClientGroup]='" & dt.Rows.Item(i).Item("PARAMETER2") & "',[IndividualNameClientGroup]='" & dt.Rows.Item(i).Item("PARAMETER INFO") & "' where [RiskDate]='" & rdsql & "' and [Counterparty/Issuer/Collateral Provider] like '" & sr & "'"
            'cmd.ExecuteNonQuery()
            'Next
            Me.BgwClientRun.ReportProgress(80, "Set defaults in Individual Client Group")
            cmd.CommandText = "UPDATE [Daily_Art13_Kwg_ChineseBanks] SET [IndividualClientGroup]=[Client Group],[IndividualNameClientGroup]=[ClientGroupName] where [RiskDate]='" & rdsql & "' and [IndividualClientGroup] is NULL "
            cmd.ExecuteNonQuery()
        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If
        Me.BgwClientRun.ReportProgress(90, "Artikel 13 KWG for Chinesse Banks calculation finished")
    End Sub

    Private Sub BUSINESS_TYPE_CREDIT_PORTFOLIO_CALCULATION()
        CurrentClientProcedure = "BUSINESS TYPES-CREDIT PORTFOLIO CALCULATION"
        Me.BgwClientRun.ReportProgress(1, "Start Business Types-Credit Portfolio calculation")
        cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            cmd.CommandText = "DELETE  FROM [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(2, "Insert SQL Commands in BusinessTypesCreditPortfolioLive from SQL PARAMETER:BUSINESS TYPES - CREDIT PORTFOLIO")
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'BUSINESS TYPES - Einfügen der SQL Befehle am neuen Tag
            'Neuanlage in BusinessTypesCreditPortfolioLive
            'cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [BusinesType],[SQLBusinessTypeDetails],'" & rdsql & "' FROM [BusinessTypesCreditPortfolioTemp]"
            'cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [SQL_Name_1],[SQL_Command_1],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='BUSINESS TYPES - CREDIT PORTFOLIO'"
            cmd.ExecuteNonQuery()
            'Ersetzen der <Risk Date> mit gültigen Risk Datum
            cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [SQLBusinessTypeDetails]= REPLACE([SQLBusinessTypeDetails],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Anwenden der SQL Befehle
            Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Credit Portfolio")
            Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDetails")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDetails")
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Execute SQL Commands for Sum
            Me.BgwClientRun.ReportProgress(3, "Update Summary in AmountBusinessType, NetCreditRiskAmountER1 and NetCreditRiskAmountER2")
            cmd.CommandText = "UPDATE A SET A.[AmountBusinessType]=B.ABT, A.[NetCreditRiskAmountER1]=B.NCR1, A.[NetCreditRiskAmountER2]=B.NCR2 from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Sum([Credit Outstanding (EUR Equ)]) as ABT,Sum([NetCredit Risk Amount(EUR Equ)]) as NCR1, Sum([NetCreditRiskAmountEUREquER45]) as NCR2 FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive])B on A.[ID]=B.[IdBusinessTypeLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Execute SQL Commands for Clients Count
            Me.BgwClientRun.ReportProgress(3, "Update Clients Count Field - Distinct Client Nr for each Business Type")
            cmd.CommandText = "UPDATE A SET A.[ClientsCount]=B.ClientsCount from [BusinessTypesCreditPortfolioLive] A INNER JOIN  (SELECT [IdBusinessTypeLive],Count(distinct [Client No]) as ClientsCount FROM [BusinessTypesCreditPortfolioDetails] GROUP BY [IdBusinessTypeLive],[BusinessTypeName])B on A.[ID]=B.[IdBusinessTypeLive] WHERE A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Me.BgwClientRun.ReportProgress(3, "Execute Summary SQL Commands in Business Types Credit Portfolio")
            'Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
            'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            'dt = New System.Data.DataTable()
            'da.Fill(dt)
            'For i = 0 To dt.Rows.Count - 1
            'If dt.Rows.Item(i).Item("BusinesType") <> "" Then
            'Sum Credit Risk Amount
            'cmd.CommandText = "Select sum([Credit Outstanding (EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim BusinessTypeAmount As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'BusinessTypeAmount = cmd.ExecuteScalar * 1
            'Else
            'BusinessTypeAmount = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'Sume Net Credit Risk Amount ER1
            'cmd.CommandText = "Select sum([NetCredit Risk Amount(EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim NetCreditRiskAmountER1 As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'NetCreditRiskAmountER1 = cmd.ExecuteScalar * 1
            'Else
            'NetCreditRiskAmountER1 = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER1]='" & Str(NetCreditRiskAmountER1) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'Sume Net Credit Risk Amount ER2
            'cmd.CommandText = "Select sum([NetCreditRiskAmountEUREquER45]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
            'Dim NetCreditRiskAmountER2 As Double = 0
            'If cmd.ExecuteScalar IsNot DBNull.Value Then
            'NetCreditRiskAmountER2 = cmd.ExecuteScalar * 1
            'Else
            'NetCreditRiskAmountER2 = 0
            'End If
            'cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER2]='" & Str(NetCreditRiskAmountER2) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
            'cmd.ExecuteNonQuery()
            'End If
            'Next
            Me.BgwClientRun.ReportProgress(3, "Update Expected Loss Value in UNEXPECTED_LOSS_DATE Table")
            cmd.CommandText = "UPDATE A SET A.[SumEL]=B.S from [UNEXPECTED_LOSS_DATE] A INNER JOIN  (SELECT [DateMakCrTotals],Sum([NetCreditRiskAmountER2]) as S FROM [BusinessTypesCreditPortfolioLive] GROUP BY [DateMakCrTotals])B on A.[RiskDate]=B.[DateMakCrTotals]  WHERE A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Set Business Type in CREDIT RISK and MAK REPORT to NULL")
            cmd.CommandText = "Update [CREDIT RISK] SET [BusinessType]=NULL where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [MAK REPORT] SET [BusinessType]=NULL where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Update Business Type in CREDIT RISK and MAK REPORT based on BusinessTypesCreditPortfolioDetails")
            cmd.CommandText = "Update A SET A.[BusinessType]=B.[BusinessTypeName] from [CREDIT RISK] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B ON A.[RiskDate]=B.[RiskDate] where A.[Contract Collateral ID]=B.[Contract Collateral ID] and A.[Client No]=B.[Client No] and A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A SET A.[BusinessType]=B.[BusinessTypeName] from [MAK REPORT] A INNER JOIN [BusinessTypesCreditPortfolioDetails] B ON A.[RiskDate]=B.[RiskDate] where A.[Contract Collateral ID]=B.[Contract Collateral ID] and A.[Client No]=B.[Client No] and A.[RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If
        Me.BgwClientRun.ReportProgress(5, "Business Types-Credit Portfolio calculation finished")
    End Sub

    Private Sub BUSINESS_TYPE_LIABILITIES_CALCULATION()
        CurrentClientProcedure = "BUSINESS TYPES-LIABILITIES CALCULATION"
        Me.BgwClientRun.ReportProgress(1, "Start Business Types-Liabilities calculation")
        cmd.CommandText = "SELECT [RiskDate] FROM [CREDIT RISK] where [RiskDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            cmd.CommandText = "DELETE  FROM [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [BusinessTypesLiabilitiesLive] where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(2, "Insert SQL Commands in BusinessTypesLiabilitiesLive from SQL PARAMETER:BUSINESS TYPES - LIABILITIES")
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'BUSINESS TYPES - Einfügen der SQL Befehle am neuen Tag
            'Neuanlage in BusinessTypesCreditPortfolioLive
            'cmd.CommandText = "INSERT INTO [BusinessTypesCreditPortfolioLive]([BusinesType],[SQLBusinessTypeDetails],[DateMakCrTotals])Select [BusinesType],[SQLBusinessTypeDetails],'" & rdsql & "' FROM [BusinessTypesCreditPortfolioTemp]"
            'cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [BusinessTypesLiabilitiesLive]([BusinesType],[SQLBusinessType],[DateMakCrTotals])Select [SQL_Name_1],[SQL_Command_1],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='BUSINESS TYPES - LIABILITIES' order by [SQL_Float_1] asc"
            cmd.ExecuteNonQuery()
            'Ersetzen der <Risk Date> mit gültigen Risk Datum
            cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesLive] SET [SQLBusinessType]= REPLACE([SQLBusinessType],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Anwenden der SQL Befehle
            Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Types Liabilities")
            Me.QueryText = "select * from [BusinessTypesLiabilitiesLive] where [DateMakCrTotals]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessType")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                    Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Business Type " & dt.Rows.Item(i).Item("BusinesType").ToString.Replace("'", ""))
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessType")
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Delete Duplicates
            Me.BgwClientRun.ReportProgress(3, "Delete Duplicates")
            cmd.CommandText = "DELETE FROM [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "' and [ID] not in (Select Min([ID]) from [BusinessTypesLiabilitiesDetails] where [RiskDate]='" & rdsql & "' group by [Contract Collateral ID])"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Set Contract Type SUSPENCE ACCOUNT if Product Type is DDPSUP01")
            cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesDetails] set [Contract Type]='SUSPENCE ACCOUNT' where [Product Type] in ('DDPSUP01') and [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Execute SQL Commands for Clients Count
            Me.BgwClientRun.ReportProgress(3, "Update Clients Count Field - Distinct Client Nr for each Business Type")
            cmd.CommandText = "UPDATE A SET A.[ClientsCount]=B.ClientsCount from [BusinessTypesLiabilitiesLive] A INNER JOIN  (SELECT [IdBusinessTypeLiabilitiesLive],Count(distinct [Client No]) as ClientsCount FROM [BusinessTypesLiabilitiesDetails] GROUP BY [IdBusinessTypeLiabilitiesLive],[BusinessTypeName])B on A.[ID]=B.[IdBusinessTypeLiabilitiesLive] WHERE A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Update OrgTotalAmount")
            cmd.CommandText = "Update 	[BusinessTypesLiabilitiesDetails] set [OrgTotalAmount]=[OrgPrincipalAmount]+[OrgInterestAmount] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Update Exchange Rates")
            cmd.CommandText = "Update A set A.[ExchangeRate]=B.[MIDDLE RATE] from [BusinessTypesLiabilitiesDetails] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[OrgCcy]=B.[CURRENCY CODE] where A.[RiskDate]='" & rdsql & "' and A.[RiskDate]=B.[EXCHANGE RATE DATE]"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Update all amounts in EURO")
            cmd.CommandText = "Update [BusinessTypesLiabilitiesDetails] set [PrincipalAmountEUR]=Round([OrgPrincipalAmount]/[ExchangeRate],2),[InterestAmountEUR]=Round([OrgInterestAmount]/[ExchangeRate],2) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Update all TOTALS")
            cmd.CommandText = "Update [BusinessTypesLiabilitiesDetails] set [TotalAmountEUR]=[PrincipalAmountEUR]+[InterestAmountEUR] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Execute SQL Commands for Sum
            Me.BgwClientRun.ReportProgress(3, "Update Summary in AmountBusinessType, Interests and TOTALS")
            cmd.CommandText = "UPDATE A SET A.[AmountBusinessTypePrincipalEUR]=B.ABT, A.[AmountBusinessTypeInterestEUR]=B.NCR1, A.[AmountBusinessTypeTOTAL_EUR]=B.NCR2 from [BusinessTypesLiabilitiesLive] A INNER JOIN  (SELECT [IdBusinessTypeLiabilitiesLive],Sum([PrincipalAmountEUR]) as ABT,Sum([InterestAmountEUR]) as NCR1, Sum([TotalAmountEUR]) as NCR2 FROM [BusinessTypesLiabilitiesDetails] GROUP BY [IdBusinessTypeLiabilitiesLive])B on A.[ID]=B.[IdBusinessTypeLiabilitiesLive]  WHERE A.[DateMakCrTotals]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(3, "Update Contract Collateral ID -RTRIM-LTRIM-Delete Blancks")
            cmd.CommandText = "UPDATE [BusinessTypesLiabilitiesDetails] set [Contract Collateral ID]=RTRIM(LTRIM([Contract Collateral ID])) where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If
        Me.BgwClientRun.ReportProgress(5, "Business Types-Credit Portfolio calculation finished")
    End Sub

    Private Sub STRESS_TESTS_CALCULATION()
        CurrentClientProcedure = "STRESS TEST CALCULATION"
        Me.BgwClientRun.ReportProgress(1, "Start Stress Test calculation")
        cmd.CommandText = "DELETE from [StressTestsLiveDetails] where [RiskDate]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "DELETE  FROM [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        'Insert new Data to StressTestsLive Table
        Me.BgwClientRun.ReportProgress(2, "Insert SQL Commands  in StressTestsLive Table")
        'Einfügen der SQL Befehle für STRESS TESTS
        'Neuanlage in StressTestsLive
        cmd.CommandText = "INSERT INTO [StressTestsLive]([BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount])Select [BusinesType],[PDunderStress],[SQLBusinessTypeDefinition],[SQLBusinessTypeAmount] FROM [StressTestsTemp]"
        cmd.ExecuteNonQuery()
        'Einfügen des RiskDatums
        cmd.CommandText = "UPDATE [StressTestsLive] SET[DateMakCrTotals]='" & rdsql & "' where [DateMakCrTotals] is NULL"
        cmd.ExecuteNonQuery()
        'Ersetzen der <Risk Date> mit gültigen Risk Datum
        cmd.CommandText = "UPDATE [StressTestsLive] SET [SQLBusinessTypeDefinition]= REPLACE([SQLBusinessTypeDefinition],'<RiskDate>','" & rdsql & "'),[SQLBusinessTypeAmount]=REPLACE([SQLBusinessTypeAmount],'<RiskDate>','" & rdsql & "') where [DateMakCrTotals]='" & rdsql & "'"
        cmd.ExecuteNonQuery()
        'Ausführen SQL Befehle für STRESS TESTS-SQL Business Type Definition-Fill StressTestDetails
        Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands  in StressTestsLive Table (Business Type Definition)")
        Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDefinition")
                cmd.ExecuteScalar()
            End If
        Next
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'Set StressNewAmount=EuroEquivalent in StressTestsLive Details
        Me.BgwClientRun.ReportProgress(4, "Set StressNewAmount=EuroEquivalent in StressTestsLive Details Table")
        cmd.CommandText = "UPDATE [StressTestsLiveDetails]  SET [StressNewAmount]=[Euro Equivalent] Where [RiskDate]='" & rdsql & "'"
        cmd.ExecuteScalar()
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'INTERNAL GUARANTESS DEFINIEREN
        Me.BgwClientRun.ReportProgress(5, "Define INTERNAL GUARANTEES in StressTestsLiveDetails Table and Set StressNewAmount=0")
        Me.QueryText = "select * from [INTERNAL GUARANTEES]  where [Valid]='Y'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='INTERNAL GUARANTEE',[StressNewAmount]=0 Where [RiskDate]='" & rdsql & "'  and [Contract Collateral ID]='" & dt.Rows.Item(i).Item("ContractCollateralID") & "'"
            cmd.ExecuteScalar()
        Next
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'CASH PLEDGE DEFINIEREN-SQL
        Me.BgwClientRun.ReportProgress(6, "Define Cashpledge in StressTestsLiveDetails Table")
        Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
            cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [InternalCode]='CASHCOVER' Where [RiskDate]='" & rdsql & "'  and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
            cmd.ExecuteScalar()
            Me.QueryText = "select * from [StressTestsLiveDetails]  Where [RiskDate]='" & rdsql & "' and [InternalCode]='CASHCOVER' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "'"
            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            For y = 0 To dt1.Rows.Count - 1
                Dim EuroEquivalent As Double = dt1.Rows.Item(y).Item("Euro Equivalent")
                If EuroEquivalent < CashPledgeAmount Then
                    cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                    cmd.ExecuteScalar()
                    CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                ElseIf EuroEquivalent > CashPledgeAmount Then
                    cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]='" & Str(EuroEquivalent - CashPledgeAmount) & "' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                    cmd.ExecuteScalar()
                    CashPledgeAmount = CashPledgeAmount - EuroEquivalent
                ElseIf EuroEquivalent = CashPledgeAmount Then
                    cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [StressNewAmount]=0 Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "'"
                    cmd.ExecuteScalar()
                    CashPledgeAmount = 0
                End If
            Next
        Next
        '*************************************************************************************************
        'Update PDAmount
        Me.BgwClientRun.ReportProgress(7, "Calculate PDAmount in StressTestsLiveDetails Table")
        cmd.CommandText = "UPDATE [StressTestsLiveDetails] SET [PDAmount]=[StressNewAmount]*[StressPercent] Where [RiskDate]='" & rdsql & "'"
        cmd.ExecuteScalar()
        '*************************************************************************************************
        'Ausführen SQL Befehle für STRESS TESTS-SQL Business Type Amount
        Me.BgwClientRun.ReportProgress(8, "Execute SQL Commands for Sums in StressTestsLive Table")
        Me.QueryText = "select * from [StressTestsLive] where [DateMakCrTotals]='" & rdsql & "'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeAmount")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeAmount")
                Dim BusinessTypeAmount As Double = 0
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    BusinessTypeAmount = cmd.ExecuteScalar * 1
                Else
                    BusinessTypeAmount = 0
                End If
                cmd.CommandText = "UPDATE [StressTestsLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                cmd.ExecuteNonQuery()
            End If
        Next
        Me.BgwClientRun.ReportProgress(9, "Stress Tests execution finished")
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    End Sub 'NOT ACTIVE

    Private Sub RLDC_UPDATE()
        CurrentClientProcedure = "UPDATE RLDC"
        'ÜBERNAHME IN RISK LIMIT DAILY CONTROL
        Me.BgwClientRun.ReportProgress(50, "Start Updating RISK LIMIT DAILY CONTROL with the calculated values for " & rd)
        cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
        If cmd.ExecuteScalar IsNot DBNull.Value Then
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'INTEREST RATE RISK
            Dim irr As Double = 0
            Dim isr As Double = 0
            Dim da As New SqlDataAdapter
            Dim dt As New System.Data.DataTable
            Me.QueryText = "SELECT [Position/Capital],[SumAM2] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            irr = dt.Rows.Item(0).Item("Position/Capital")
            isr = dt.Rows.Item(0).Item("SumAM2") 'wird nicht mehr in RISK LIMIT DAILY CONTROL Importiert
            'Übernahme der Summe AM3 (50%)
            'Dim SAM3 As Double = 0
            'cmd.CommandText = "SELECT ABS(Sum([AM3])) from [RATERISK TOTALS] where [RISK DATE]='" & rdsql & "'"
            'SAM3 = cmd.ExecuteScalar
            'Übernahme der Summe von Min. +/- 50 bps, HUMP,TWIST1 und TWIST2
            Dim SAM3 As Double = 0
            Me.BgwClientRun.ReportProgress(30, "Select Sum as Interest Rate Risk Amount from Minimum +/- 50 bps, HUMP,TWIST1,TWIST2 Grouped by Currency from RATERISK TOTALS")
            cmd.CommandText = "Select ABS(Sum(z.A)) from (SELECT [CURRENCY],MIN(x.a)A FROM (SELECT [CURRENCY],Sum([AM3]) a from [RATERISK TOTALS] where [IdRateRiskDate]='" & rdsql & "' GROUP BY [CURRENCY] UNION SELECT [CURRENCY],Sum([AM3])*-1 a from [RATERISK TOTALS] where [IdRateRiskDate]='" & rdsql & "' GROUP BY [CURRENCY] UNION SELECT [CURRENCY],sum([AMHUMP]) a from [RATERISK TOTALS] where [IdRateRiskDate]='" & rdsql & "' GROUP BY [CURRENCY] UNION SELECT [CURRENCY],Sum([AM_TWIST1]) a from [RATERISK TOTALS] where [IdRateRiskDate]='" & rdsql & "' GROUP BY [CURRENCY] UNION SELECT [CURRENCY],Sum([AM_TWIST2]) a from [RATERISK TOTALS] where[IdRateRiskDate] ='" & rdsql & "' GROUP BY [CURRENCY]) x GROUP BY [CURRENCY])z"
            SAM3 = cmd.ExecuteScalar
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'OBLIGO LIABILITY SURPLUS CALCULATION
            Me.BgwClientRun.ReportProgress(8, "Recalculating OBLIGO LIABILITY SURPLUS-Get Sum Principal+Interest (EUR) where Product Name is REFINANCE SOLD FUNDED and Client No in 67820185,67820386 from TIME DEP OUTST CLIENT DEALS ")
            If rd <= DateSerial(2013, 12, 31) Then
                cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='REFINANCE SOLD FUNDED' and [Client No] in ('67820185','67820279','67820386') and [RepDate]='" & rdsql & "'"
            ElseIf rd > DateSerial(2013, 12, 31) And rd <= DateSerial(2014, 12, 31) Then
                cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='REFINANCE SOLD FUNDED' and [Client No] in ('67820185','67820386') and [RepDate]='" & rdsql & "'"
            ElseIf rd > DateSerial(2014, 12, 31) Then
                cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='REFINANCE SOLD FUNDED' and [Client No] in ('0') and [RepDate]='" & rdsql & "'"
            End If
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                BadRefinaceSoldFounded = cmd.ExecuteScalar
            Else
                BadRefinaceSoldFounded = 0
            End If
            Me.BgwClientRun.ReportProgress(8, "Recalculating OBLIGO LIABILITY SURPLUS-Get Sum Principal+Interest (EUR) where Product Name is PLEDGED VARIABLE DEPOSITS-CUSTOMER from TIME DEP OUTST CLIENT DEALS ")
            cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='PLEDGED VARIABLE DEPOSITS-CUSTOMER' and [RepDate]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                SumPledgedVariableDepositsCustomer = cmd.ExecuteScalar
            Else
                SumPledgedVariableDepositsCustomer = 0
            End If
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Me.BgwClientRun.ReportProgress(30, "Update RISK LIMIT DAILY CONTROL - Interest Rate Risk and Interest Risk Amount from RATERISK DATE")
            Me.BgwClientRun.ReportProgress(30, "Update RISK LIMIT DAILY CONTROL - CreditRiskCashpledge from BusinessTypesCreditPortfolioLive (Sum of NetCreditRiskAmountER2)")
            Me.BgwClientRun.ReportProgress(30, "Update RISK LIMIT DAILY CONTROL - Unexpected Loss , Granularity Approach (Concentration Risk Amount) and Operational Risk Incidents (Maximum Amount)")
            Me.BgwClientRun.ReportProgress(30, "Update RISK LIMIT DAILY CONTROL - BadRefinanceSoldFunded and SumPledgeVariableDepositsCustomer")
            Me.BgwClientRun.ReportProgress(30, "Update RISK LIMIT DAILY CONTROL - CCBINFO Obligo Liability surplus and CCBINFO Obligo Liability surplus Risk Subtotal")

            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Interest rate risk]=" & Str(irr) & ",[Interest risk]=" & Str(SAM3) & " WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditRiskCashPledge]=B.S from [RISK LIMIT DAILY CONTROL] A INNER JOIN  (SELECT [DateMakCrTotals],Sum([NetCreditRiskAmountER2]) as S FROM [BusinessTypesCreditPortfolioLive] GROUP BY [DateMakCrTotals])B on A.[RLDC Date]=B.[DateMakCrTotals]  WHERE A.[RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'NOT RELEVANT ANYMORE+++CREDIT RISK WITHOUT CASH PLEDGE (and without FX) 20% ++++
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Credit Risk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "') WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[UnexpectedLossAmount]=(SELECT Round([SumUL]/1000,0) FROM [UNEXPECTED_LOSS_DATE] WHERE [RiskDate]='" & rdsql & "'),[ConcentrationRiskAmount]=(SELECT Round([SumGA_Total]/1000,0) FROM [UNEXPECTED_LOSS_DATE] WHERE [RiskDate]='" & rdsql & "'),[OperationalRiskIncidents]=(SELECT Max([ExtentOfDamage]) FROM [SCHADENSFALL] where [EventDate]<='" & rdsql & "') WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Obligo Liability Surplus
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [BadRefinanceSoldFunded]=" & Str(BadRefinaceSoldFounded) & ",[SumPledgeVariableDepositsCustomer]=" & Str(SumPledgedVariableDepositsCustomer) & " where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[SumPledgeVariableDepositsCustomer]+[RetainedEarnings],[CCBINFO Obligo Liability surplus Risk Subtotal]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[RetainedEarnings] where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Fx Revaluation Difference between OCBS and IDW
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PLdifferenceOCBS_IDW]=(SELECT Sum([AmortizationToRiskDate])+Sum([IDW_Amount])-Sum([PL_inEUR_Equ]) FROM [FX DAILY REVALUATION] WHERE [RiskDate]='" & rdsql & "' and [OwnDeal]='Y' ) WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'PL recalculated
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PLrecalculated]=[PL Result]+[PLdifferenceOCBS_IDW] WHERE [RLDC Date]='" & rdsql & "' and [PL Result] is not NULL"
                cmd.ExecuteNonQuery()
            End If
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Interest rate risk]=" & Str(irr) & ",[Interest risk]=" & Str(SAM3) & ",[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE A SET A.[CreditRiskCashPledge]=B.S from [RISK LIMIT DAILY CONTROL] A INNER JOIN  (SELECT [DateMakCrTotals],Sum([NetCreditRiskAmountER2]) as S FROM [BusinessTypesCreditPortfolioLive] GROUP BY [DateMakCrTotals])B on A.[RLDC Date]=B.[DateMakCrTotals]  WHERE A.[RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'NOT RELEVANT ANYMORE+++CREDIT RISK WITHOUT CASH PLEDGE (and without FX) 20% ++++
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Credit Risk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'),[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[UnexpectedLossAmount]=(SELECT Round([SumUL]/1000,0) FROM [UNEXPECTED_LOSS_DATE] WHERE [RiskDate]='" & rdsql & "'),[ConcentrationRiskAmount]=(SELECT Round([SumGA_Total]/1000,0) FROM [UNEXPECTED_LOSS_DATE] WHERE [RiskDate]='" & rdsql & "'),[OperationalRiskIncidents]=(SELECT Max([ExtentOfDamage]) FROM [SCHADENSFALL] where [EventDate]<='" & rdsql & "') WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Obligo Liability Surplus
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [BadRefinanceSoldFunded]=" & Str(BadRefinaceSoldFounded) & ",[SumPledgeVariableDepositsCustomer]=" & Str(SumPledgedVariableDepositsCustomer) & " where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[SumPledgeVariableDepositsCustomer]+[RetainedEarnings],[CCBINFO Obligo Liability surplus Risk Subtotal]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[RetainedEarnings] where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Fx Revaluation Difference between OCBS and IDW
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PLdifferenceOCBS_IDW]=(SELECT Sum([AmortizationToRiskDate])+Sum([IDW_Amount])-Sum([PL_inEUR_Equ]) FROM [FX DAILY REVALUATION] WHERE [RiskDate]='" & rdsql & "' and [OwnDeal]='Y' ) WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'PL recalculated
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [PLrecalculated]=[PL Result]+[PLdifferenceOCBS_IDW] WHERE [RLDC Date]='" & rdsql & "' and [PL Result] is not NULL"
                cmd.ExecuteNonQuery()
            End If

            'RECALCULATING RISK BEARING CAPACITY
            Me.BgwClientRun.ReportProgress(8, "Recalculating RISK BEARING CAPACITY for " & rd)
            Dim s1 As Double = 0
            Dim s2 As Double = 0
            Dim RBC As Double = 0
            Dim MaxOperationalRisk As Double = 0
            If rd < DateSerial(2014, 1, 1) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+[Operational risk]+[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "select sum([Dotation capital]-[Minimum capital requirement]+round([PL Result]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]="
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]="
                    cmd.ExecuteScalar()
                End If
            ElseIf rd >= DateSerial(2014, 1, 1) AndAlso rd <= DateSerial(2014, 6, 30) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum([Dotation capital]-[Minimum capital requirement]+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2014, 6, 30) AndAlso rd <= DateSerial(2014, 12, 4) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum([Dotation capital]-[Minimum capital requirement]+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            ElseIf rd > DateSerial(2014, 12, 4) Then
                cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                If cmd.ExecuteScalar IsNot DBNull.Value Then
                    cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "')B"
                    MaxOperationalRisk = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s1 = cmd.ExecuteScalar
                    cmd.CommandText = "Select sum([Dotation capital]-[Minimum capital requirement] - ([Minimum capital requirement]*0.3)+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    s2 = cmd.ExecuteScalar
                    RBC = (s1 / s2) * 100
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteScalar()
                End If
            End If

            'TRAFFIC LIGHT SYSTEM
            cmd.CommandText = "SELECT [Currency risk] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                Me.BgwClientRun.ReportProgress(8, "Recalculating TRAFFIC LIGHT SYSTEM for " & rd)
                cmd.CommandText = "Delete from [RBC_TRAFFIC_LIGHT_SYSTEM] where [RiskDate] ='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [RBC_TRAFFIC_LIGHT_SYSTEM]([RiskCategory],[RelativeAllocationPercent],[SQLCommand],[RiskDate])Select [SQL_Name_1],[SQL_Float_1],[SQL_Command_1],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='TRAFFIC LIGHTS SYSTEM'"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [SQLCommand]= REPLACE([SQLCommand],'<RiskDate>','" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in RBC_TRAFFIC_LIGHT_SYSTEM")
                Me.QueryText = "select * from [RBC_TRAFFIC_LIGHT_SYSTEM] where [RiskDate] ='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    cmd.CommandText = dt.Rows.Item(i).Item("SQLCommand")
                    Dim Amount As Double = cmd.ExecuteScalar
                    cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [RiskCategoryFullAmount]=' " & Str(Amount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                Next
                cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [PilarIamount]=(Select Round(sum([Dotation capital]-[Minimum capital requirement]-Round([Minimum capital requirement]*0.3,0)+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]),0) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [RelativeAllocationAmount]=Round([PilarIamount]*[RelativeAllocationPercent],0) where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "BEGIN UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [TrafficLightResult]='Less' where [RiskCategoryFullAmount]/[RelativeAllocationAmount]<=0.8 and [RiskDate]='" & rdsql & "' END BEGIN UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [TrafficLightResult]='Middle' where [RiskCategoryFullAmount]/[RelativeAllocationAmount]>0.8 and [RiskCategoryFullAmount]/[RelativeAllocationAmount]<=1  and [RiskDate]='" & rdsql & "' END BEGIN UPDATE [RBC_TRAFFIC_LIGHT_SYSTEM] SET [TrafficLightResult]='Over' where [RiskCategoryFullAmount]/[RelativeAllocationAmount]>1 and [RiskDate]='" & rdsql & "' END"
                cmd.ExecuteNonQuery()
            End If
        Else
            Me.BgwClientRun.ReportProgress(70, "Unable to Update - Key Data (Currency Risk) are missing for Risk Date: " & rd)
        End If

        Me.BgwClientRun.ReportProgress(100, "RISK LIMIT DAIYL CONTROL update finished for " & rd)

    End Sub

    Private Sub STRESS_TESTS_HEAD_OFFICE_CALCULATION()

        CurrentClientProcedure = "STRESS TEST HEAD OFFICE CALCULATION"

        cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
        HasDataResult = cmd.ExecuteScalar
        If IsNothing(HasDataResult) = False Then
            cmd.CommandText = "DELETE  FROM [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            'Checking Date definieren
            CheckingDate = DateAdd("m", 1, rd)

            CheckingDate = DateSerial(CheckingDate.Year, CheckingDate.Month, CheckingDate.Day + 1) 'Plus einen Tag im Checking Date
            CheckingDateSql = CheckingDate.ToString("yyyy-MM-dd")

            LastDayCurrentMonth = DateSerial(rd.Year, rd.Month, 1).AddMonths(1).AddDays(-1)
            FirstDayOverNextMonth = rd.AddDays((rd.Day - 1) * -1).AddMonths(2) ' Übernächstzer Monat
            'Wenn Tagesdatum gleich datum des letzten Monatstages
            If rd = LastDayCurrentMonth Then
                CheckingDate = FirstDayOverNextMonth
            End If

            'STRESS TEST LIQUIDITY HEAD OFFICE SCENARIO
            'Erstellen des Risk datums
            Me.BgwClientRun.ReportProgress(6, "Insert new Risk Date")
            cmd.CommandText = "INSERT INTO [StressTestsLiquidHO] ([StressDate]) Values ('" & rdsql & "')"
            cmd.ExecuteNonQuery()

            'Einfügen der Temp daten in die Live Tabelle
            Me.BgwClientRun.ReportProgress(7, "Insert Temp SQL Commands in the Live Table")
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=B.[CashPlacementBUBA_ACCD_SQL],[CashPlacementBUBA_CFNM_SQL]=B.[CashPlacementBUBA_CFNM_SQL],[LossUnderStressCashPlacementBUBA]=B.[LossUnderStressCashPlacementBUBA],[PlacementToBanksInclIC_ACCD_SQL]=B.[PlacementToBanksInclIC_ACCD_SQL],[PlacementsToBanksInclIC_CFNM_SQL]=B.[PlacementsToBanksInclIC_CFNM_SQL],[LossUnderStressPlacementsToBanksInclIC]=B.[LossUnderStressPlacementsToBanksInclIC],[DebtClaimToCustomersInclCCB_ACCD_SQL]=B.[DebtClaimToCustomersInclCCB_ACCD_SQL],[DebtClaimToCustomersInclCCB_CFNM_SQL]=B.[DebtClaimToCustomersInclCCB_CFNM_SQL],[LossUnderStressDebtClaimToCustomersInclCCB]=B.[LossUnderStressDebtClaimToCustomersInclCCB],[Investments_Securities_ACCD_SQL]=B.[Investments_Securities_ACCD_SQL],[Investments_Securities_CFNM_SQL]=B.[Investments_Securities_CFNM_SQL],[LossUnderStressInvestments_Securities]=B.[LossUnderStressInvestments_Securities],[OtherAssets_ACCD_SQL]=B.[OtherAssets_ACCD_SQL],[OtherAssets_CFNM_SQL]=B.[OtherAssets_CFNM_SQL],[LossUnderStressInvestments_OtherAssets]=B.[LossUnderStressInvestments_OtherAssets],[BorrowFromBUBA_SQL]=B.[BorrowFromBUBA_SQL],[BorrowFromBUBA_CFNM_SQL]=B.[BorrowFromBUBA_CFNM_SQL],[LossUnderStressInvestments_BorrowFromBUBA]=B.[LossUnderStressInvestments_BorrowFromBUBA],[DepositFromBanksInclIC_SQL]=B.[DepositFromBanksInclIC_SQL],[DepositFromBanksInclIC_CFNM_SQL]=B.[DepositFromBanksInclIC_CFNM_SQL],[LossUnderStressInvestments_DepositFromBanksInclIC]=B.[LossUnderStressInvestments_DepositFromBanksInclIC],[DepositFromCustomers_SQL]=B.[DepositFromCustomers_SQL],[DepositFromCustomers_CFNM_SQL]=B.[DepositFromCustomers_CFNM_SQL],[LossUnderStressInvestments_DepositFromCustomers]=B.[LossUnderStressInvestments_DepositFromCustomers] from [StressTestsLiquidHO] A,[StressTestLiquid_Temp] B where A.[StressDate]='" & rdsql & "' and B.[ID]=1"
            cmd.ExecuteNonQuery()

            'Replace RiskDate and CheckingDate with Valid sql Date
            Me.BgwClientRun.ReportProgress(8, "Replace <RiskDate> and <CheckingDate> with the current Risk date in the Live Table")
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]= REPLACE([CashPlacementBUBA_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD_SQL]=REPLACE([CashPlacementBUBA_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]= REPLACE([CashPlacementBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM_SQL]=REPLACE([CashPlacementBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]= REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD_SQL]=REPLACE([PlacementToBanksInclIC_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]= REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM_SQL]=REPLACE([PlacementsToBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]= REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD_SQL]=REPLACE([DebtClaimToCustomersInclCCB_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]= REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM_SQL]=REPLACE([DebtClaimToCustomersInclCCB_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]= REPLACE([Investments_Securities_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD_SQL]=REPLACE([Investments_Securities_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]= REPLACE([Investments_Securities_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM_SQL]=REPLACE([Investments_Securities_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]= REPLACE([OtherAssets_ACCD_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD_SQL]=REPLACE([OtherAssets_ACCD_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]= REPLACE([OtherAssets_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM_SQL]=REPLACE([OtherAssets_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]= REPLACE([BorrowFromBUBA_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_SQL]=REPLACE([BorrowFromBUBA_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]= REPLACE([BorrowFromBUBA_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM_SQL]=REPLACE([BorrowFromBUBA_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]= REPLACE([DepositFromBanksInclIC_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_SQL]=REPLACE([DepositFromBanksInclIC_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]= REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM_SQL]=REPLACE([DepositFromBanksInclIC_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]= REPLACE([DepositFromCustomers_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_SQL]=REPLACE([DepositFromCustomers_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]= REPLACE([DepositFromCustomers_CFNM_SQL],'<RiskDate>','" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM_SQL]=REPLACE([DepositFromCustomers_CFNM_SQL],'<CheckDate>','" & CheckingDateSql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

            'SQL Befehle ausführen
            Me.BgwClientRun.ReportProgress(9, "Execute SQL Commands in the Live Table")
            Me.QueryText = "select * from [StressTestsLiquidHO] where [StressDate]='" & rdsql & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute CashPlacementBUBA_ACCD_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute CashPlacementBUBA_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("CashPlacementBUBA_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [CashPlacementBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute PlacementToBanksInclIC_ACCD_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("PlacementToBanksInclIC_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementToBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute PlacementsToBanksInclIC_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("PlacementsToBanksInclIC_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [PlacementsToBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute DebtClaimToCustomersInclCCB_ACCD_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute DebtClaimToCustomersInclCCB_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("DebtClaimToCustomersInclCCB_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DebtClaimToCustomersInclCCB_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute Investments_Securities_ACCD_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute Investments_Securities_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("Investments_Securities_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [Investments_Securities_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute OtherAssets_ACCD_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_ACCD_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute OtherAssets_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("OtherAssets_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [OtherAssets_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute BorrowFromBUBA_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute BorrowFromBUBA_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("BorrowFromBUBA_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [BorrowFromBUBA_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute DepositFromBanksInclIC_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute DepositFromBanksInclIC_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromBanksInclIC_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromBanksInclIC_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute DepositFromCustomers_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_ACCD]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
                If IsDBNull(dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")) = False Then
                    Me.BgwClientRun.ReportProgress(9, "Execute DepositFromCustomers_CFNM_SQL in the Live Table")
                    cmd.CommandText = dt.Rows.Item(i).Item("DepositFromCustomers_CFNM_SQL")
                    Dim SqlAmount As Double = 0
                    If cmd.ExecuteScalar IsNot DBNull.Value Then
                        SqlAmount = cmd.ExecuteScalar * 1
                    Else
                        SqlAmount = 0
                    End If
                    cmd.CommandText = "UPDATE [StressTestsLiquidHO] SET [DepositFromCustomers_CFNM]='" & Str(SqlAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next


            'Summen erstellen
            'CASH INFLOW-ACCOUNT BALANCE
            Me.BgwClientRun.ReportProgress(10, "Update CASH INFLOW-ACCOUNT BALANCE  in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_ACCD]=CASE when (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_ACCD]+[PlacementToBanksInclIC_ACCD]+[DebtClaimToCustomersInclCCB_ACCD]+[Investments_Securities_ACCD]+[OtherAssets_ACCD])from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH INFLOW-CASH FLOW WITHIN NEXT MONTH
            Me.BgwClientRun.ReportProgress(11, "Update CASH INFLOW-CASH FLOW WITHIN NEXT MONTH  in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_INFLOW_CFNM]=CASE when (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CashPlacementBUBA_CFNM]+[PlacementsToBanksInclIC_CFNM]+[DebtClaimToCustomersInclCCB_CFNM]+[Investments_Securities_CFNM]+[OtherAssets_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH OUTFLOW-ACCOUNT BALANCE
            Me.BgwClientRun.ReportProgress(12, "Update CASH OUTFLOW-ACCOUNT BALANCE  in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_ACCD]=CASE when (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_ACCD]+[DepositFromBanksInclIC_ACCD]+[DepositFromCustomers_ACCD]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH
            Me.BgwClientRun.ReportProgress(13, "Update CASH OUTFLOW-CASH FLOW WITHIN NEXT MONTH in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [CASH_OUTFLOW_CFNM]=CASE when (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([BorrowFromBUBA_CFNM]+[DepositFromBanksInclIC_CFNM]+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'ADDITIONAL CASH FLOW UNDER STRESS
            Me.BgwClientRun.ReportProgress(14, "Update AddCashOutflowunderStress_CashPlacementBUBA in the Live Table")
            '1
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_CashPlacementBUBA]=Case when (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressCashPlacementBUBA]*[CashPlacementBUBA_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '2
            Me.BgwClientRun.ReportProgress(15, "Update AddCashOutflowunderStress_PlacementsToBanksInclIC in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_PlacementsToBanksInclIC]= Case when (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressPlacementsToBanksInclIC]*[PlacementsToBanksInclIC_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '3
            Me.BgwClientRun.ReportProgress(16, "Update AddCashOutflowunderStress_DebtClaimToCustomersInclCCB in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]=Case when (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressDebtClaimToCustomersInclCCB]*[DebtClaimToCustomersInclCCB_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '4
            Me.BgwClientRun.ReportProgress(17, "Update AddCashOutflowunderStress_Investments_Securities in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_Investments_Securities]=Case when (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_Securities]*[Investments_Securities_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            '5
            Me.BgwClientRun.ReportProgress(18, "Update AddCashOutflowunderStress_OtherAssets in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_OtherAssets]=Case when (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "')<>0 then (Select [LossUnderStressInvestments_OtherAssets]*[OtherAssets_CFNM]*(-1) where [StressDate]='" & rdsql & "') else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '6
            Me.BgwClientRun.ReportProgress(19, "Update AddCashOutflowunderStress_BorrowFromBUBA in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_BorrowFromBUBA]=Case when ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')* (select[LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([BorrowFromBUBA_ACCD]*(-1)+[BorrowFromBUBA_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_BorrowFromBUBA]*(-1) where [StressDate]='" & rdsql & "'))else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '7
            Me.BgwClientRun.ReportProgress(20, "Update AddCashOutflowunderStress_DepositFromBanksInclIC in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromBanksInclIC]= Case when ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromBanksInclIC_ACCD]*(-1)+[DepositFromBanksInclIC_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(select [LossUnderStressInvestments_DepositFromBanksInclIC]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            '8
            Me.BgwClientRun.ReportProgress(21, "Update AddCashOutflowunderStress_DepositFromCustomers in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [AddCashOutflowunderStress_DepositFromCustomers]= Case when ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "'))<>0 then ((Select Sum([DepositFromCustomers_ACCD]*(-1)+[DepositFromCustomers_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')*(Select [LossUnderStressInvestments_DepositFromCustomers]*(-1) where [StressDate]='" & rdsql & "')) else 0 end where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()


            'Restliche Summen Berechnen
            Me.BgwClientRun.ReportProgress(22, "Update LIQUIDITY_DEMAND_OVERPLUS_CFNM in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_CFNM]=Case when (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "')<>0 then (Select Sum([CASH_INFLOW_CFNM]+[CASH_OUTFLOW_CFNM]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') else 0 end  where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'Liquidity Demand/Liquidity Overplus ADD. CASH OUTFLOW
            Me.BgwClientRun.ReportProgress(23, "Update LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]=(Select Sum([AddCashOutflowunderStress_CashPlacementBUBA]+[AddCashOutflowunderStress_PlacementsToBanksInclIC]+[AddCashOutflowunderStress_DebtClaimToCustomersInclCCB]+[AddCashOutflowunderStress_Investments_Securities]+[AddCashOutflowunderStress_OtherAssets]+[AddCashOutflowunderStress_BorrowFromBUBA]+[AddCashOutflowunderStress_DepositFromBanksInclIC]+[AddCashOutflowunderStress_DepositFromCustomers]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            'TOTAL LIQUIDITY
            Me.BgwClientRun.ReportProgress(24, "Update TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS in the Live Table")
            cmd.CommandText = "UPDATE  [StressTestsLiquidHO] set [TOTAL_LIQUIDITY_DEMAND_OVERPLUS_UNDER_STRESS]=(Select Sum([LIQUIDITY_DEMAND_OVERPLUS_CFNM]+[LIQUIDITY_DEMAND_OVERPLUS_AddCashOutflowunderStress]) from [StressTestsLiquidHO]  where [StressDate]='" & rdsql & "') where [StressDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()

        ElseIf IsNothing(HasDataResult) = True Then
            Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
        End If


    End Sub

    Private Sub LOAN_EXPOSURE_CORPORATES()
        CurrentClientProcedure = "LOAN EXPOSURE CORPORATES"
        Me.BgwClientRun.ReportProgress(50, "Start calculate the Loan Exposures for Corporate Customers on " & rd)
        cmd.CommandText = "SELECT [CapitalForSolvV] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
        Dim CapitalForSolv As Double = cmd.ExecuteScalar
        If CapitalForSolv <> 0 Then
            Me.BgwClientRun.ReportProgress(50, "Delete previus Data in LARGE_LOANS_EXPOSURE for " & rd)
            cmd.CommandText = "DELETE from [LARGE_LOANS_EXPOSURE] where [RiskDate]='" & rdsql & "'"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(50, "Insert relevant Data from CREDIT RISK on " & rd)
            cmd.CommandText = "INSERT INTO [LARGE_LOANS_EXPOSURE]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[ClientGroup],[ClientGroupName],[BusinessType],[RiskDate]) Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[ClientGroup],[ClientGroupName],[BusinessType],[RiskDate] from [CREDIT RISK] where [RiskDate]='" & rdsql & "' and [Contract Type] not in ('SECUR') and [Client No] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('C - COMPANY'))"
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(50, "Update Exchange Rates on " & rd)
            cmd.CommandText = "UPDATE A SET A.[ExchangeRateCurrent]=B.[MIDDLE RATE] from [LARGE_LOANS_EXPOSURE] A INNER JOIN [EXCHANGE RATES OCBS] B on A.[RiskDate]=B.[EXCHANGE RATE DATE] where A.[Org Ccy]=B.[CURRENCY CODE] and A.[RiskDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(50, "Get CapitalForSolv on " & rd)
            cmd.CommandText = "UPDATE A SET A.[CapitalForSolvV]=B.[CapitalForSolvV] from [LARGE_LOANS_EXPOSURE] A INNER JOIN [RISK LIMIT DAILY CONTROL] B on A.[RiskDate]=B.[RLDC Date] where A.[RiskDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            Me.BgwClientRun.ReportProgress(50, "Calculate Exposure Limits on " & rd)
            cmd.CommandText = "UPDATE [LARGE_LOANS_EXPOSURE] SET [ExposureAmountMAX]=[CapitalForSolvV]*0.25 where [RiskDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE [LARGE_LOANS_EXPOSURE] SET [ExposureAmountMIN]=[ExposureAmountMAX]*0.9 where [RiskDate]='" & rdsql & "' "
            cmd.ExecuteNonQuery()
        Else
            Me.BgwClientRun.ReportProgress(70, "Unable to calculate the Loan Exposures for Corporate Customers - Key Data (CapitalForSolvV) are missing for Risk Date: " & rd)
        End If

    End Sub

    Private Sub FORMBLATT_BALANCE_CALCULATION()
        CurrentClientProcedure = "FORMBLATT BILANZ CALCULATION"
        cmd.CommandText = "SELECT [SQL_Parameter_Status] FROM [SQL_PARAMETER] where  [SQL_Parameter_Name]='FORMBLATT BILANZ'"
        Dim ParameterStatus As String = cmd.ExecuteScalar
        If ParameterStatus = "Y" Then
            Me.BgwClientRun.ReportProgress(1, "Start Formblatt Bilanz Calculation")
            cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
            HasDataResult = cmd.ExecuteScalar
            If IsNothing(HasDataResult) = False Then
                'UPDATE RILIBI CODES AND NAMES
                Me.BgwClientRun.ReportProgress(8, "Update Rilibi Codes in DailyBalanceSheets")
                cmd.CommandText = "UPDATE A set A.[RilibiCode]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_MATCHING' and [PARAMETER STATUS] ='Y')B ON A.[GL_Item_Number]=B.[PARAMETER1]  where A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Update Rilibi Names DailyBalanceSheets")
                cmd.CommandText = "UPDATE A set A.[RilibiName]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_CODES' and [PARAMETER STATUS] ='Y')B ON A.[RilibiCode]=B.[PARAMETER1] where A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Update Rilibi Codes and Names DailyBalanceDetailSheet")
                cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID],A.[RilibiCode]=B.[RilibiCode],A.[RilibiName]=B.[RilibiName] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Delete Current Data from Formblatt_BILANZ_Details ")
                cmd.CommandText = "DELETE  FROM [Formblatt_BILANZ_Details] where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(8, "Delete Current Data from Formblatt_BILANZ_TOTALS ")
                cmd.CommandText = "DELETE FROM [Formblatt_BILANZ_TOTALS] where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(2, "Insert SQL Commands in Formblatt_BILANZ_TOTALS")
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'FORMBLATT BILANZ - Einfügen der SQL Befehle am neuen Tag
                cmd.CommandText = "INSERT INTO [Formblatt_BILANZ_TOTALS]([Bilanzposition],[Bilanzposition_ID],[BilanzpositionArt],[SQLcommandCurrentDate],[SQLcommandLastYear],[RiskDate])Select [SQL_Name_1],[SQL_Float_1],[SQL_Name_2],[SQL_Command_1],[SQL_Command_2],'" & rdsql & "' FROM [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='FORMBLATT BILANZ' ORDER BY [SQL_Float_1] asc"
                cmd.ExecuteNonQuery()
                'Ersetzen der <Risk Date> mit gültigen Risk Datum
                cmd.CommandText = "UPDATE [Formblatt_BILANZ_TOTALS] SET [SQLcommandCurrentDate]= REPLACE([SQLcommandCurrentDate],'<RiskDate>','" & rdsql & "'),[SQLcommandLastYear]= REPLACE([SQLcommandLastYear],'<RiskDate>','" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Anwenden der SQL Befehle
                Me.BgwClientRun.ReportProgress(3, "Execute SQL Commands in Formblatt_BILANZ_TOTALS")
                Me.QueryText = "select * from [Formblatt_BILANZ_TOTALS] where [RiskDate]='" & rdsql & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQLcommandCurrentDate")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("SQLcommandCurrentDate")
                        cmd.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows.Item(i).Item("SQLcommandLastYear")) = False Then
                        cmd.CommandText = dt.Rows.Item(i).Item("SQLcommandLastYear")
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'Execute SQL Commands for Sum
                Me.BgwClientRun.ReportProgress(3, "Update Summary Unterpositionen")
                cmd.CommandText = "UPDATE A SET A.[AmountCurrentDate_UP]=B.ABT from [Formblatt_BILANZ_TOTALS] A INNER JOIN  (SELECT [IdFormblattBALANCE_TOTALS],Sum([Total_Balance]) as ABT  FROM [Formblatt_BILANZ_Details] GROUP BY [IdFormblattBALANCE_TOTALS])B on A.[ID]=B.[IdFormblattBALANCE_TOTALS]  WHERE A.[RiskDate]='" & rdsql & "' and A.[BilanzpositionArt] not in ('AKTIVA','PASSIVA')"
                cmd.ExecuteNonQuery()
                Me.BgwClientRun.ReportProgress(3, "Update Summary Gesamtpositionen")
                cmd.CommandText = "UPDATE A SET A.[AmountCurrentDate]=B.ABT from [Formblatt_BILANZ_TOTALS] A INNER JOIN  (SELECT [IdFormblattBALANCE_TOTALS],Sum([Total_Balance]) as ABT  FROM [Formblatt_BILANZ_Details] GROUP BY [IdFormblattBALANCE_TOTALS])B on A.[ID]=B.[IdFormblattBALANCE_TOTALS]  WHERE A.[RiskDate]='" & rdsql & "' and A.[BilanzpositionArt] in ('AKTIVA','PASSIVA')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE [Formblatt_BILANZ_TOTALS] SET [AmountCurrentDate_UP]=NULL where [AmountCurrentDate_UP]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [Formblatt_BILANZ_TOTALS] SET [AmountCurrentDate]=NULL where [AmountCurrentDate]=0 and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


            ElseIf IsNothing(HasDataResult) = True Then
                Me.BgwClientRun.ReportProgress(70, "There are no Data for Risk Date: " & rd)
            End If
            Me.BgwClientRun.ReportProgress(5, "FORMBLATT BILANZ CALCULATION finished")
        Else
            Me.BgwClientRun.ReportProgress(5, "FORMBLATT BILANZ SQL PARAMETER STATUS is Invalid")
        End If

    End Sub

#End Region

End Class