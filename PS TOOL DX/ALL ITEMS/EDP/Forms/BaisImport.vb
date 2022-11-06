Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
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
Imports DevExpress.Spreadsheet



Public Class BaisImport

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""

   
    Dim BAISDirectory As String = "" 'OCBS FILE DIRECTORY
    Dim BAISFileNewDirectory As String = "" 'NEW DIRECTORY FOR OCBS FILE

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim connEVENT As New SqlConnection
    Dim cmdEVENT As New SqlCommand
    'Oledb Connection for OCBS
    Dim connBAIS As New SqlConnection
    Dim cmdBAIS As New SqlCommand


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
    Dim BaisAutomatedImport_btn_clicked As Boolean = False 'Button for Automated Import
    Dim BaisSelectedFileImport_btn_clicked As Boolean = False 'Button for single File import
    Dim BaisImportFromTill_btn_clicked As Boolean = False
    Dim CURRENT_LAST_IMPORTED_BAIS_FILE As Double = Nothing

    Dim MaxProcDate As Date
    Dim BAIS_Date As Date
    Dim SqlBAISDate As String = ""




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

    

#Region "SPECIAL_FUNCTIONS"

    'Change the Current  File in Form
    Public Sub Change_CBAIF()
        Me.CurrentBaisImportFile.Text = CBAIF
    End Sub

    'Change the Last  Import File in Form
    Public Sub Change_LBAIF()
        Me.LastBaisImportFile.Text = LBAIF
    End Sub
    'Change Current Procedure in Form
    Public Sub Change_CURRENT_PROC()
        Me.CURRENT_PROCEDURE_Text.Text = CURRENT_PROC
    End Sub
    'Clear Current Procedure in Form
    Public Sub Clear_CURRENT_PROC()
        Me.CURRENT_PROCEDURE_Text.Text = ""
    End Sub

    'Clear Current  Import File in Form
    Public Sub Clear_CBAIF()
        Me.CurrentBaisImportFile.Text = ""
        Me.CURRENT_PROCEDURE_Text.Text = ""
    End Sub

    'Show Progress in a  Excel File with 5000 Rows
    Public Sub PROGRESS_OCBS_MAX5()
        Me.BAISProgressBar.Maximum = 5000
    End Sub

    'Show Progress in a  Excel File with 10000 Rows
    Public Sub PROGRESS_OCBS_MAX10()
        Me.BAISProgressBar.Maximum = 10000
    End Sub

    'Show Progress in a  Excel File-Progress Bar
    Public Sub PROGRESS_OCBS_EXCEL()
        Me.BAISProgressBar.Increment(1)
        If Me.BAISProgressBar.Value = Me.BAISProgressBar.Maximum Then
            Me.BAISProgressBar.Value = 0
        End If
    End Sub


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

    Public Function ReadLine(ByVal filename As String, _
     ByVal line As Integer) As String

        Try
            Dim lines As String() = My.Computer.FileSystem.ReadAllText( _
              filename, System.Text.Encoding.Default).Split(vbCrLf)

            If line > 0 Then
                ' n-te Zeile vom Anfang der Textdatei
                Return lines(line - 1)
            ElseIf line < 0 Then
                ' n-te Zeile beginnend am Ende der Textdatei
                Return lines(lines.Length + line - 1)
            Else
                ' ungültige Zeilennummer
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

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
    Private Sub Unziped()

    End Sub
#End Region

#Region "GRIDVIEWS_DEFAULT_SETTINGS"
    Private Sub BAISImportEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles BAISImportEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub BAISImportEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles BAISImportEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_ImportEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ImportEvents_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
        Dim reportfooter As String = "BAIS IMPORT EVENTS"
e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
#End Region

#Region "ENABLE_DISABLE_CONTROLS_BY_IMPORT"
    Private Sub DISABLE_START_IMPORT()
        'Set Import settings
        Me.BAISProgressBar.Visible = True
        BaisSelectedImport_btn.Enabled = False
        BaisAutomatedImport_btn.Enabled = False
        BaisFromTillImport_btn.Enabled = False
        LastBaisImportFile.Enabled = False
        SelectedBaisImportFile.Enabled = False
        BaisImportFileFrom.Enabled = False
        BaisImportFileTill.Enabled = False

    End Sub

    Private Sub ENABLE_FINISH_IMPORT()
        Me.EVENTSloadtext.Text = ""
        Me.BAISProgressBar.Value = 0
        Me.BAISProgressBar.Visible = False
        BaisSelectedImport_btn.Enabled = True
        BaisAutomatedImport_btn.Enabled = True
        BaisFromTillImport_btn.Enabled = True
        LastBaisImportFile.Enabled = True
        SelectedBaisImportFile.Enabled = True
        BaisImportFileFrom.Enabled = True
        BaisImportFileTill.Enabled = True
    End Sub
#End Region

#Region "BUTTONS_AND_EDITORS_EVENTS"
    Private Sub LastBaisImportFile_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LastBaisImportFile.ButtonClick
        If IsNumeric(LastBaisImportFile.Text) = True And Len(LastBaisImportFile.Text) = 8 Then
            If MessageBox.Show("Should the BAISForms File Nr. " & LastBaisImportFile.Text & " be saved as Last Imported BAIS file", "CHANGE THE LAST IMPORTED BAISForms FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Dim LastBAISFORMSImportFile As Double = Me.LastBaisImportFile.Text
                Me.FILES_IMPORTBindingSource.EndEdit()
                Me.FILES_IMPORTTableAdapter.UpdateBAIS_Forms_LastImportFile(LastBAISFORMSImportFile)
                Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)
            Else
                Me.FILES_IMPORTBindingSource.CancelEdit()
                Exit Sub
            End If
        Else
            MessageBox.Show("The indicated BAISForms Filename is not correct!", "BAISForms FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub

        End If
    End Sub

    Private Sub LastBaisImportFile_Leave(sender As Object, e As EventArgs) Handles LastBaisImportFile.Leave
        If IsNumeric(LastBaisImportFile.Text) = False OrElse Len(LastBaisImportFile.Text) <> 8 Then
            MessageBox.Show("The indicated BAISforms Filename is not correct!", "BAISForms FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub
        End If
    End Sub
    Private Sub SelectedBaisImportFile_Leave(sender As Object, e As EventArgs) Handles SelectedBaisImportFile.Leave
        If Me.SelectedBaisImportFile.Text <> "" Then
            If IsNumeric(SelectedBaisImportFile.Text) = False OrElse Len(SelectedBaisImportFile.Text) <> 8 Then
                MessageBox.Show("The indicated BAISForms Filename is not correct!", "BAISForms FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.SelectedBaisImportFile.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OcbsImportFileFrom_Leave(sender As Object, e As EventArgs) Handles BaisImportFileFrom.Leave
        If Me.BaisImportFileFrom.Text <> "" Then
            If IsNumeric(BaisImportFileFrom.Text) = False OrElse Len(BaisImportFileFrom.Text) <> 8 Then
                MessageBox.Show("The indicated BAISForms Filename is not correct!", "BAISForms FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.BaisImportFileFrom.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub BaisImportFileTill_Leave(sender As Object, e As EventArgs) Handles BaisImportFileTill.Leave
        If Me.BaisImportFileTill.Text <> "" Then
            If IsNumeric(BaisImportFileTill.Text) = False OrElse Len(BaisImportFileTill.Text) <> 8 Then
                MessageBox.Show("The indicated BAISForms Filename is not correct!", "BAISForms FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.BaisImportFileTill.Text = ""
                Exit Sub
            End If
        End If

    End Sub


    Private Sub BaisAutomatedImport_btn_Click(sender As Object, e As EventArgs) Handles BaisAutomatedImport_btn.Click
        BaisAutomatedImport_btn_clicked = True
        BaisSelectedFileImport_btn_clicked = False
        BaisImportFromTill_btn_clicked = False
        If Me.LastBaisImportFile.Text <> "" Then
            If MessageBox.Show("Should the automated BAIS Fileimport be executed?", "AUTOMATED IMPORT BAIS FILES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwBAISimport.IsBusy = False Then
                    Me.BgwBAISimport.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub BaisSelectedImport_btn_Click(sender As Object, e As EventArgs) Handles BaisSelectedImport_btn.Click
        BaisSelectedFileImport_btn_clicked = True
        BaisAutomatedImport_btn_clicked = False
        BaisImportFromTill_btn_clicked = False
        If Me.SelectedBaisImportFile.Text <> "" Then
            If MessageBox.Show("Should the BAIS Filename " & SelectedBaisImportFile.Text & " be imported?", "IMPORT BAIS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwBAISimport.IsBusy = False Then
                    Me.BgwBAISimport.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub BaisFromTillImport_btn_Click(sender As Object, e As EventArgs) Handles BaisFromTillImport_btn.Click
        BaisImportFromTill_btn_clicked = True
        BaisAutomatedImport_btn_clicked = False
        BaisSelectedFileImport_btn_clicked = False

        If Me.BaisImportFileFrom.Text <> "" AndAlso Me.BaisImportFileTill.Text <> "" Then
            Dim n1 As Double = Me.BaisImportFileFrom.Text
            Dim n2 As Double = Me.BaisImportFileTill.Text
            If n2 >= n1 Then
                If MessageBox.Show("Should the BAIS Import start with Filename " & n1 & " and finish with Filename " & n2, "IMPORT BAIS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_IMPORT()
                    If Me.BgwBAISimport.IsBusy = False Then
                        CURRENT_LAST_IMPORTED_BAIS_FILE = Me.LastBaisImportFile.Text
                        Me.BgwBAISimport.RunWorkerAsync()
                    End If
                End If
            Else
                MessageBox.Show("The last Filename is earlier than the first Filename!", "WRONG FILENAMES IMPORT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub
#End Region

    Private Sub MakeFolderWritable(ByVal Folder As String)
        If IsFolderReadOnly(Folder) Then
            Dim oDir As New System.IO.DirectoryInfo(Folder)
            oDir.Attributes = oDir.Attributes And Not IO.FileAttributes.ReadOnly
        End If
    End Sub
    Private Function IsFolderReadOnly(ByVal Folder As String) As Boolean
        Dim oDir As New System.IO.DirectoryInfo(Folder)
        Return ((oDir.Attributes And IO.FileAttributes.ReadOnly) > 0)
    End Function

    Public Sub RemoveReadOnlyAttributes(ByVal folder As String)
        ' Remove attribute on individual files
        For Each filename As String In My.Computer.FileSystem.GetFiles(folder)
            System.IO.File.SetAttributes(filename, IO.FileAttributes.Normal)
        Next

        ' Recursively call this routine on all subfolders
        For Each foldername As String In My.Computer.FileSystem.GetDirectories(folder)
            RemoveReadOnlyAttributes(foldername)
        Next
    End Sub

#Region "BAIS_IMPORT_BACKGROUNDWORKER"
    Private Sub BgwBAISimport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBAISimport.DoWork

        '***********AUTOMATED BAIS IMPORT****************
        If BaisAutomatedImport_btn_clicked = True Then

            Try
                Me.BgwBAISimport.ReportProgress(10, "Locate the BAIS Current and Temp Directory")

                'Heutiges Datum ermitteln und in Zahl unformatieren
                Dim CurDate As Date = Today
                Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                cmdBAIS.Connection.Open()
                BAISDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                BAISFileNewDirectory = cmdBAIS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAIS Directories - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: BAIS FILES")
                cmdBAIS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BAIS FILES' AND xtype='U') CREATE TABLE [BAIS FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[FileNameNumber] [float] NULL,[FileNameText] [nvarchar](255) NULL,[FileFullName] [nvarchar](255) NULL) ELSE DELETE FROM [BAIS FILES] "
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAIS Files in Table: BAIS FILES")
                cmdBAIS.CommandText = "INSERT [BAIS FILES] ([FileFullName]) EXEC master..xp_subdirs '" & BAISDirectory & "'"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(31, "Delete from BAIS FILES where FileFullName not like...BAISform...")
                cmdBAIS.CommandText = "DELETE FROM [BAIS FILES] where [FileFullName] not like 'BAISform%'"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(32, "Update Field FileNameText with the 8 last Characters from FileFullName")
                cmdBAIS.CommandText = "UPDATE [BAIS FILES] SET [FileNameText]=RIGHT([FileFullName],8)"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(33, "Update FileNameNumber and FileFullName in BAIS FILES")
                cmdBAIS.CommandText = "UPDATE [BAIS FILES] SET [FileNameNumber]= CASE WHEN ISNUMERIC(FileNameText)=1 THEN CAST([FileNameText] as float) else 0 end,[FileFullName]='" & BAISDirectory & "' + [FileFullName]"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(40, "Delete from BAIS FILES where FileNameNumber=0")
                cmdBAIS.CommandText = "DELETE from [BAIS FILES] where [FileNameNumber]=0"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(45, "Delete from Table: BAIS FILES where FileNameNumber < Last BAIS Import File: " & Me.LastBaisImportFile.Text)
                cmdBAIS.CommandText = "DELETE FROM [BAIS FILES] where [FileNameNumber]<'" & Me.LastBaisImportFile.Text & "'"
                cmdBAIS.ExecuteNonQuery()


                Me.QueryText = "SELECT [FileNameNumber],[FileFullName]  FROM [BAIS FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwBAISimport.ReportProgress(50, "Determine the next BAIS File for Import...Please wait...")

                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileNameNumber] as NextFileNameforimport,[FileFullName] as NextFileFullName from [BAIS FILES] where [FileNameNumber] in (SELECT min([FileNameNumber])FROM [BAIS FILES] where [FileNameNumber]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('BAIS_Forms')))"
                    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then

                        CBAIF = dt1.Rows.Item(0).Item("NextFileNameforimport")
                        BAIS_Date = DateSerial(Microsoft.VisualBasic.Left(CBAIF, 4), Mid(CBAIF, 5, 2), Microsoft.VisualBasic.Right(CBAIF, 2))
                        SqlBAISDate = BAIS_Date.ToString("yyyyMMdd")
                        If Me.BgwBAISimport.CancellationPending = False Then
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_CBAIF))
                            '*******************************************************************************
                            Dim LCBAIF As String = CBAIF
                            Dim BAISFileFullName As String = dt1.Rows.Item(0).Item("NextFileFullName")
                            'Löschen der Daten in BAIS Files
                            Me.BgwBAISimport.ReportProgress(60, "Delete from BAIS FILES the File: " & CBAIF)
                            cmdBAIS.CommandText = "DELETE  FROM [BAIS FILES] where [FileNameNumber]='" & CBAIF & "'"
                            cmdBAIS.ExecuteNonQuery()
                            '++++Remove Read Only Attributes from the Original BAIS Folder
                            RemoveReadOnlyAttributes(BAISFileFullName)
                            ' Ordner einschl. aller Unterordner kopieren
                            Me.BgwBAISimport.ReportProgress(65, "Copy Folder:" & BAISFileFullName & " to " & BAISFileNewDirectory)
                            CopyFolder(BAISFileFullName, BAISFileNewDirectory)
                            '++++++++Set Temporary BAIS Folder from Read Only to Writable


                            '+++++++++++++++++++++++++++++++++++++++
                            Me.BgwBAISimport.ReportProgress(60, "BAIS File for Import: " & "  " & CBAIF & " is ready")
                            Me.BgwBAISimport.ReportProgress(70, "Starting the BAIS Import procedures...")

                            'PROCEDUREN
                            If CBAIF <= 20140911 Then
                                BAIS_IMPORT_PROCEDURES()
                            ElseIf CBAIF > 20140911 And CBAIF <= 20160929 Then
                                BAIS_IMPORT_PROCEDURES_NEW()
                            ElseIf CBAIF > 20160929 And CBAIF <= 20171231 Then
                                BAIS_IMPORT_PROCEDURES_FROM_30092016()
                            ElseIf CBAIF > 20171231 And CBAIF <= 20180325 Then
                                BAIS_IMPORT_PROCEDURES_FROM_01012018()
                            ElseIf CBAIF > 20180325 Then
                                BAIS_IMPORT_PROCEDURES_FROM_26003018()
                            End If


                            'Erstellten Ordner wieder löschen
                            Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                            Directory.Delete(BAISFileNewDirectory, True)
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwBAISimport.ReportProgress(90, "Set as Last imported BAIS File Name: " & "  " & CBAIF)
                            cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CBAIF & "' WHERE [SYSTEM_NAME] in ('BAIS_Forms')"
                            cmdBAIS.ExecuteNonQuery()

                            LBAIF = CBAIF
                            Me.LastBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_LBAIF))
                            CBAIF = Nothing
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Clear_CBAIF))

                            'Füllen des Table adapters

                            Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwBAISimport.ReportProgress(95, "BAIS File Import: " & " " & LCBAIF & " " & "is finished ...")
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Import finished ...")
                        ElseIf Me.BgwBAISimport.CancellationPending = True Then
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Imports are terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                        End If

                    End If
                Next m
                'Löschen der Temporären Tabelen für den BAIS Import
                cmdBAIS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "DROP TABLE [BAIS FILES]"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()

                If cmdBAIS.Connection.State = ConnectionState.Open Then
                    cmdBAIS.Connection.Close()
                End If

            Catch ex As System.Exception
                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS file: " & " " & Me.CurrentBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwBAISimport.CancelAsync()
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If
                'Excel Instanz beenden
                'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                'Dim i1 As Short
                'i1 = 0
                'For i1 = 0 To (procs.Length - 1)
                'procs(i1).Kill()
                'Next i1
            End Try
            '*****************************************************************************
        End If


        '****************SELECTED BAIS FILE IMPORT************************************
        If BaisSelectedFileImport_btn_clicked = True Then
            Try
                Me.BgwBAISimport.ReportProgress(10, "Locate the BAIS Current and Temp Directory")

                'Heutiges Datum ermitteln und in Zahl unformatieren
                Dim CurDate As Date = Today
                Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                cmdBAIS.Connection.Open()
                BAISDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                BAISFileNewDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_FILENAME_BEGINS' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                Dim BAIS_NAME_BEGINS As String = cmdBAIS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "OCBS Directories - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Dim BaisFileFullName As String = BAISDirectory & BAIS_NAME_BEGINS & Me.SelectedBaisImportFile.Text 'Full File Directory
                Dim BaisFileName As String = Me.SelectedBaisImportFile.Text 'File for Import

                If Directory.Exists(BaisFileFullName) = True Then
                    BAIS_Date = DateSerial(Microsoft.VisualBasic.Left(BaisFileName, 4), Mid(BaisFileName, 5, 2), Microsoft.VisualBasic.Right(BaisFileName, 2))
                    SqlBAISDate = BAIS_Date.ToString("yyyyMMdd")
                    Dim BaisDateNr As Double = BAIS_Date.ToString("yyyyMMdd")
                    CBAIF = BaisDateNr
                    '++++Remove Read Only Attributes from the Original BAIS Folder
                    RemoveReadOnlyAttributes(BaisFileFullName)
                    ' Ordner einschl. aller Unterordner kopieren
                    Me.BgwBAISimport.ReportProgress(65, "Copy Folder:" & BaisFileFullName & " to " & BAISFileNewDirectory)
                    CopyFolder(BaisFileFullName, BAISFileNewDirectory)
                    '++++++++Set Temporary BAIS Folder from Read Only to Writable
                    'SetAttr(BAISFileNewDirectory, FileAttribute.ReadOnly)
                    'SetAttr(BAISFileNewDirectory, FileAttribute.Normal)
                    '+++++++++++++++++++++++++++++++++++++++
                    Me.BgwBAISimport.ReportProgress(60, "BAIS File for Import: " & "  " & BaisFileName & " is ready")
                    Me.BgwBAISimport.ReportProgress(70, "Starting the BAIS Import procedures...")


                    'PROCEDUREN
                    If CBAIF <= 20140911 Then
                        BAIS_IMPORT_PROCEDURES()
                    ElseIf CBAIF > 20140911 And CBAIF <= 20160929 Then
                        BAIS_IMPORT_PROCEDURES_NEW()
                    ElseIf CBAIF > 20160929 And CBAIF <= 20171231 Then
                        BAIS_IMPORT_PROCEDURES_FROM_30092016()
                    ElseIf CBAIF > 20171231 And CBAIF <= 20180325 Then
                        BAIS_IMPORT_PROCEDURES_FROM_01012018()
                    ElseIf CBAIF > 20180325 Then
                        BAIS_IMPORT_PROCEDURES_FROM_26003018()
                    End If

                    '++++++++++++++++++++++++++++++++++++++++++++++
                    'Erstellten Ordner wieder löschen
                    Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                    Directory.Delete(BAISFileNewDirectory, True)

                    Me.BgwBAISimport.ReportProgress(95, "BAIS File Import: " & " " & BaisFileName & " " & "is finished ...")
                    Me.BgwBAISimport.ReportProgress(100, "BAIS Import finished ...")

                Else
                    MessageBox.Show("BAIS File: " & SelectedBaisImportFile.Text & " does not exists!", "BAIS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                If cmdBAIS.Connection.State = ConnectionState.Open Then
                    cmdBAIS.Connection.Close()
                End If

            Catch ex As Exception

                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS File: " & " " & Me.SelectedBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub

            Finally
                Me.BgwBAISimport.CancelAsync()
                'Directory Löschen
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If

                'Excel Instanz beenden
                'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                'Dim i1 As Short
                'i1 = 0
                'For i1 = 0 To (procs.Length - 1)
                'procs(i1).Kill()
                'Next i1

            End Try
        End If
        '***********************************************************************************************

        '***********************BAIS IMPORT FROM...TILL*************************
        If BaisImportFromTill_btn_clicked = True Then
            Try
                Me.BgwBAISimport.ReportProgress(10, "Locate the BAIS Current and Temp Directory")

                'Heutiges Datum ermitteln und in Zahl unformatieren
                Dim CurDate As Date = Today
                Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                cmdBAIS.Connection.Open()
                BAISDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                BAISFileNewDirectory = cmdBAIS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAIS Directories - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: BAIS FILES")
                cmdBAIS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BAIS FILES' AND xtype='U') CREATE TABLE [BAIS FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[FileNameNumber] [float] NULL,[FileNameText] [nvarchar](255) NULL,[FileFullName] [nvarchar](255) NULL) ELSE DELETE FROM [BAIS FILES] "
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAIS Files in Table: BAIS FILES")
                cmdBAIS.CommandText = "INSERT [BAIS FILES] ([FileFullName]) EXEC master..xp_subdirs '" & BAISDirectory & "'"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(31, "Delete from BAIS FILES where FileFullName not like...BAISform...")
                cmdBAIS.CommandText = "DELETE FROM [BAIS FILES] where [FileFullName] not like 'BAISform%'"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(32, "Update Field FileNameText with the 8 last Characters from FileFullName")
                cmdBAIS.CommandText = "UPDATE [BAIS FILES] SET [FileNameText]=RIGHT([FileFullName],8)"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(33, "Update FileNameNumber and FileFullName in BAIS FILES")
                cmdBAIS.CommandText = "UPDATE [BAIS FILES] SET [FileNameNumber]= CASE WHEN ISNUMERIC(FileNameText)=1 THEN CAST([FileNameText] as float) else 0 end,[FileFullName]='" & BAISDirectory & "' + [FileFullName]"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(40, "Delete from BAIS FILES where FileNameNumber=0")
                cmdBAIS.CommandText = "DELETE from [BAIS FILES] where [FileNameNumber]=0"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(45, "Delete from Table: BAIS FILES where FileName NOT BETWEEN " & Me.BaisImportFileFrom.Text & " and " & Me.BaisImportFileTill.Text)
                cmdBAIS.CommandText = "DELETE FROM [BAIS FILES] where [FileNameNumber] NOT BETWEEN '" & Me.BaisImportFileFrom.Text & "' and '" & Me.BaisImportFileTill.Text & "'"
                cmdBAIS.ExecuteNonQuery()
                'set temporary LastImportedBAISfile and load
                Me.BgwBAISimport.ReportProgress(46, "Set as Temporary Last Imported BAIS File Name:20010101")
                cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & 20010101 & "' WHERE [SYSTEM_NAME] in ('BAIS_Forms')"
                cmdBAIS.ExecuteNonQuery()

                Me.QueryText = "SELECT [FileNameNumber],[FileFullName]  FROM [BAIS FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwBAISimport.ReportProgress(50, "Determine the next BAIS File for Import...Please wait...")

                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileNameNumber] as NextFileNameforimport,[FileFullName] as NextFileFullName from [BAIS FILES] where [FileNameNumber] in (SELECT min([FileNameNumber])FROM [BAIS FILES] where [FileNameNumber]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('BAIS_Forms')))"
                    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        CBAIF = dt1.Rows.Item(0).Item("NextFileNameforimport")
                        BAIS_Date = DateSerial(Microsoft.VisualBasic.Left(CBAIF, 4), Mid(CBAIF, 5, 2), Microsoft.VisualBasic.Right(CBAIF, 2))
                        SqlBAISDate = BAIS_Date.ToString("yyyyMMdd")

                        If Me.BgwBAISimport.CancellationPending = False Then

                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_CBAIF))
                            '*******************************************************************************
                            Dim LCBAIF As String = CBAIF
                            Dim BAISFileFullName As String = dt1.Rows.Item(0).Item("NextFileFullName")
                            'Löschen der Daten in BAIS Files
                            Me.BgwBAISimport.ReportProgress(60, "Delete from BAIS FILES the File: " & CBAIF)
                            cmdBAIS.CommandText = "DELETE  FROM [BAIS FILES] where [FileNameNumber]='" & CBAIF & "'"
                            cmdBAIS.ExecuteNonQuery()
                            '++++Remove Read Only Attributes from the Original BAIS Folder
                            RemoveReadOnlyAttributes(BAISFileFullName)
                            ' Ordner einschl. aller Unterordner kopieren
                            Me.BgwBAISimport.ReportProgress(65, "Copy Folder:" & BAISFileFullName & " to " & BAISFileNewDirectory)
                            CopyFolder(BAISFileFullName, BAISFileNewDirectory)
                            '++++++++Set Temporary BAIS Folder from Read Only to Writable
                            'SetAttr(BAISFileNewDirectory, FileAttribute.ReadOnly)
                            'SetAttr(BAISFileNewDirectory, FileAttribute.Normal)
                            '+++++++++++++++++++++++++++++++++++++++
                            Me.BgwBAISimport.ReportProgress(60, "BAIS File for Import: " & "  " & CBAIF & " is ready")
                            Me.BgwBAISimport.ReportProgress(70, "Starting the BAIS Import procedures...")

                            'PROCEDUREN
                            If CBAIF <= 20140911 Then
                                BAIS_IMPORT_PROCEDURES()
                            ElseIf CBAIF > 20140911 And CBAIF <= 20160929 Then
                                BAIS_IMPORT_PROCEDURES_NEW()
                            ElseIf CBAIF > 20160929 And CBAIF <= 20171231 Then
                                BAIS_IMPORT_PROCEDURES_FROM_30092016()
                            ElseIf CBAIF > 20171231 And CBAIF <= 20180325 Then
                                BAIS_IMPORT_PROCEDURES_FROM_01012018()
                            ElseIf CBAIF > 20180325 Then
                                BAIS_IMPORT_PROCEDURES_FROM_26003018()
                            End If

                            'Erstellten Ordner wieder löschen
                            Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                            Directory.Delete(BAISFileNewDirectory, True)
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwBAISimport.ReportProgress(90, "Set as Last imported BAIS File Name: " & "  " & CBAIF)
                            cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CBAIF & "' WHERE [SYSTEM_NAME] in ('BAIS_Forms')"
                            cmdBAIS.ExecuteNonQuery()

                            LBAIF = CBAIF
                            Me.LastBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_LBAIF))
                            CBAIF = Nothing
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Clear_CBAIF))

                            'Füllen des Table adapters

                            Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwBAISimport.ReportProgress(95, "BAIS File Import: " & " " & LCBAIF & " " & "is finished ...")
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Import finished ...")
                        ElseIf Me.BgwBAISimport.CancellationPending = True Then
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Imports are terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                        End If
                    End If

                Next m
                'Löschen der Temporären Tabelen für den BAIS Import
                cmdBAIS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "DROP TABLE [BAIS FILES]"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                'Set as last BAIS imported file Name the first BAIS file name
                cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CURRENT_LAST_IMPORTED_BAIS_FILE & "' WHERE [SYSTEM_NAME] in ('BAIS_Forms')"
                cmdBAIS.ExecuteNonQuery()


                If cmdBAIS.Connection.State = ConnectionState.Open Then
                    cmdBAIS.Connection.Close()
                End If

            Catch ex As System.Exception
                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS file: " & " " & Me.CurrentBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwBAISimport.CancelAsync()
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If
                'Excel Instanz beenden
                'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                'Dim i1 As Short
                'i1 = 0
                'For i1 = 0 To (procs.Length - 1)
                'procs(i1).Kill()
                'Next i1
            End Try
            '*****************************************************************************
        End If
    End Sub

    Private Sub BgwBAISimport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBAISimport.ProgressChanged
        Me.EVENTSloadtext.Text = e.UserState
        Me.BAISProgressBar.Value = e.ProgressPercentage

        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & Me.EVENTSloadtext.Text & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','BAIS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BAIS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','BAIS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BAIS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByBAISDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub BgwBAISimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBAISimport.RunWorkerCompleted
        ENABLE_FINISH_IMPORT()
        Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)
        Me.SelectedBaisImportFile.Text = ""
        Me.BaisImportFileFrom.Text = ""
        Me.BaisImportFileTill.Text = ""
        'Set Button Click as default to False
        BaisAutomatedImport_btn_clicked = False
        BaisSelectedFileImport_btn_clicked = False
        BaisImportFromTill_btn_clicked = False

        If cmdBAIS.Connection.State = ConnectionState.Open Then
            cmdBAIS.Connection.Close()
        End If

        Dim f As New GlobalClass
        f.NewImportEventsFolder()

    End Sub

#End Region



    Private Sub BaisImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwBAISimport.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub BaisImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT

        connBAIS.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdBAIS.Connection = connBAIS

        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        cmd.Connection.Open()
        MaxProcDate = cmd.ExecuteScalar
        cmd.Connection.Close()

        Me.IMPORT_EVENTSTableAdapter.FillByBAISDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Terminate OCBS Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwBAISimport.IsBusy = True Then
                If MessageBox.Show("Should the BAIS import procedures be terminated?", "TERMINATE BAIS IMPORTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwBAISimport.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS Imports termination is requested..." & vbNewLine & "Please wait until the current BAIS Import operations are finished!")
                End If
            End If
        End If
    End Sub

    Private Sub BAIS_IMPORT_PROCEDURES()
        Try

            Dim extractorXLS As New XLSExtractor
            Dim extractorCSV As New CSVExtractor

            Dim SOLVA As Double = 0
            Dim CURRENCY_RISK As Double = 0
            Dim DOTATION_CAPITAL As Double = 0
            Dim CORE_CAPITAL As Double = 0
            Dim EIGENMITTEL_CAPITAL As Double = 0
            Dim LIQUID_LV_FULL As Double = 0
            Dim LIQUID_LV_1_to_3_MONTHS As Double = 0
            Dim LIQUID_LV_3_to_6_MONTHS As Double = 0
            Dim LIQUID_LV_6_to_12_MONTHS As Double = 0
            Dim LIQUIDITY_RISK As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT_STAGE2 As Double = 0
            Dim OPERATIONAL_RISK As Double = 0

            ' Create an instance of a workbook.
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()

            'SELECT DATA FROM FILE <EUEB.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_EUEB_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            cmd.Connection.Open()
            Dim EUEB_XLS As String = cmd.ExecuteScalar
            Dim EUEB_XLS_FILE As String = BAISFileNewDirectory & EUEB_XLS
            Me.BgwBAISimport.ReportProgress(1, "Start Selecting Data from Excel File " & EUEB_XLS_FILE)
            If File.Exists(EUEB_XLS_FILE) = True Then

                workbook.LoadDocument(EUEB_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("EUEB")

                Me.BgwBAISimport.ReportProgress(2, "Select SOLVA from Cell E234 ")
                SOLVA = worksheet.Range("E234").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(3, "Select DOTATION CAPITAL from Cell E23 ")
                DOTATION_CAPITAL = worksheet.Range("E23").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(4, "Select CORE CAPITAL from Cell E136 ")
                CORE_CAPITAL = worksheet.Range("E136").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(5, "Select EIGENMITTEL CAPITAL from Cell E18 and multiply with 1000 ")
                EIGENMITTEL_CAPITAL = worksheet.Range("E18").Value.NumericValue * 1000
                Me.BgwBAISimport.ReportProgress(6, "Select MINIMUM CAPITAL REQUIREMENT from Cell E161")
                MINIMUM_CAPITAL_REQUIREMENT = worksheet.Range("E161").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(7, "Select MINIMUM CAPITAL REQUIREMENT STAGE2 from Cell E165")
                MINIMUM_CAPITAL_REQUIREMENT_STAGE2 = worksheet.Range("E165").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(7, "Select CURRENCY RISK from Cell E210")
                CURRENCY_RISK = worksheet.Range("E210").Value.NumericValue



            End If

            'SELECT DATA FROM FILE <MKRFW.PDF> - CURRENCY RISK now from EUEB.XLS Cell E221
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRFW_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim MKRFW_PDF As String = cmd.ExecuteScalar
            'Dim MKRFW_PDF_FILE As String = BAISFileNewDirectory & MKRFW_PDF
            'Me.BgwBAISimport.ReportProgress(8, "Start Selecting Data from Pdf File " & MKRFW_PDF_FILE)
            'If File.Exists(MKRFW_PDF_FILE) = True Then
            'extractorXLS.LoadDocumentFromFile(MKRFW_PDF_FILE)
            'extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\MKRFWoutput.xls")
            '***************************************
            'Excel Instanz beenden
            'Dim procs1() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i11 As Short
            'i11 = 0
            'For i11 = 0 To (procs1.Length - 1)
            'procs1(i11).Kill()
            'Next i11
            '***************************************
            'Dim MKRFW_XLS_FILE As String = BAISFileNewDirectory & "\MKRFWoutput.xls"
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(MKRFW_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("Page 1")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(8, "Select CURRENCY RISK-Value from the last not blank cell in column J ")
            'Dim Lastvalidrow As Double = 0 'Letzte nicht leere Zelle
            'Last not empty cell in Column D
            'Lastvalidrow = xlWorksheet1.Range("F100").End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).Row
            'CURRENCY_RISK = xlWorksheet1.Cells(Lastvalidrow, 10).value

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If

            'SELECT DATA FROM FILE <LV2.PDF>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LIQV_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LIQV_PDF As String = cmd.ExecuteScalar
            Dim LIQV_PDF_FILE As String = BAISFileNewDirectory & LIQV_PDF
            If File.Exists(LIQV_PDF_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(9, "Start Selecting Data from Pdf File " & LIQV_PDF_FILE)
                extractorXLS.LoadDocumentFromFile(LIQV_PDF_FILE)
                extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\LV2output.xls")
                extractorXLS.Reset()

                Dim LIQV_XLS_FILE As String = BAISFileNewDirectory & "\LV2output.xls"
                Me.BgwBAISimport.ReportProgress(10, "Select from Excle File " & LIQV_XLS_FILE)


                workbook.LoadDocument(LIQV_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("Page 2")

                'LIQUID LV
                'Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell D23")
                'LIQUID_LV_FULL = worksheet.Range("D23").Value.NumericValue
                'OTHER LIQUIDITY PERIODS
                'Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell E26")
                'LIQUID_LV_1_to_3_MONTHS = worksheet.Range("E26").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell F26")
                'LIQUID_LV_3_to_6_MONTHS = worksheet.Range("F26").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell G26")
                'LIQUID_LV_6_to_12_MONTHS = worksheet.Range("G26").Value.NumericValue
                '*****************************************

                'LIQUID LV
                Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell F26")
                LIQUID_LV_FULL = worksheet.Range("F26").Value.NumericValue
                'OTHER LIQUIDITY PERIODS
                Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell H30")
                LIQUID_LV_1_to_3_MONTHS = worksheet.Range("H30").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell I30")
                LIQUID_LV_3_to_6_MONTHS = worksheet.Range("I30").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell J30")
                LIQUID_LV_6_to_12_MONTHS = worksheet.Range("J30").Value.NumericValue
                '*****************************************

            End If

            'SELECT DATA FROM FILE <EOPR.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_EOPR_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim EOPR_XLS As String = cmd.ExecuteScalar
            Dim EOPR_XLS_FILE As String = BAISFileNewDirectory & EOPR_XLS
            Me.BgwBAISimport.ReportProgress(15, "Start Selecting Data from Excel  File " & EOPR_XLS_FILE)
            If File.Exists(EOPR_XLS_FILE) = True Then

                workbook.LoadDocument(EOPR_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("EOPR")

                Me.BgwBAISimport.ReportProgress(16, "Select OPERATIONAL RISK from Cell J11")
                OPERATIONAL_RISK = worksheet.Range("J11").Value.NumericValue

            End If




            'INSERT DATA in RISK LIMIT DAILY CONTROL
            Me.BgwBAISimport.ReportProgress(50, "Insert selected Data in RISK LIMIT DAILY CONTROL")
            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Bank SolvV]='" & Str(SOLVA) & "',[Currency risk]='" & Str(CURRENCY_RISK) & "',[Dotation capital]='" & Str(DOTATION_CAPITAL) & "',[Core capital]='" & Str(CORE_CAPITAL) & "',[Bank Liquid LV]='" & Str(LIQUID_LV_FULL) & "',[Liquid1M3M]='" & Str(LIQUID_LV_1_to_3_MONTHS) & "',[Liquid3M6M]='" & Str(LIQUID_LV_3_to_6_MONTHS) & "',[Liquid6M12M]='" & Str(LIQUID_LV_6_to_12_MONTHS) & "',[Liquidity risk]='" & Str(LIQUIDITY_RISK) & "',[Minimum capital requirement]='" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "',[Minimum capital requirementSTAGE2]='" & Str(MINIMUM_CAPITAL_REQUIREMENT_STAGE2) & "',[Operational risk]='" & Str(OPERATIONAL_RISK) & "',[OwnCapitalBAIS]='" & Str(EIGENMITTEL_CAPITAL) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteScalar()
            End If
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Bank SolvV],[Currency risk],[Dotation capital],[Core capital],[Bank Liquid LV],[Liquid1M3M],[Liquid3M6M],[Liquid6M12M],[Liquidity risk],[Minimum capital requirement],[Minimum capital requirementSTAGE2],[Operational risk],[OwnCapitalBAIS],[IdBank]) Values('" & SqlBAISDate & "','" & Str(CURRENCY_RISK) & "','" & Str(DOTATION_CAPITAL) & "','" & Str(CORE_CAPITAL) & "','" & Str(LIQUID_LV_FULL) & "','" & Str(LIQUID_LV_1_to_3_MONTHS) & "','" & Str(LIQUID_LV_3_to_6_MONTHS) & "','" & Str(LIQUID_LV_6_to_12_MONTHS) & "','" & Str(LIQUIDITY_RISK) & "','" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "','" & Str(MINIMUM_CAPITAL_REQUIREMENT_STAGE2) & "','" & Str(OPERATIONAL_RISK) & "','" & Str(EIGENMITTEL_CAPITAL) & "','3')"
                cmd.ExecuteScalar()
            End If


            'NEUBERECHNUNG DES INTEREST RATE RISKS nach den EIGENMITTEL KAPITAL
            'Einfügen des Eigenmittel Kapitals in RATERISK DATE
            'Me.BgwBAISimport.ReportProgress(60, "Insert EIGENMITTEL CAPITAL in RATE RISK (INTERST RATE RISK)")
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Working Capital]='" & Str(EIGENMITTEL_CAPITAL) & "'  WHERE [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'Neuberechnung der Interest rate risk
            'Me.BgwBAISimport.ReportProgress(65, "Recalculate INTEREST RATE RISK")
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=Round([SumAM2]/[Working Capital]*100,2)  WHERE [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'Interest Rate Risk - ABSOLUTE NUMBER
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=[Position/Capital]*(-1) where [Position/Capital]<0  and [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteNonQuery()

            'Neuberechnung der Interest rate risk
            'Me.BgwBAISimport.ReportProgress(67, "Insert EIGENMITTEL CAPITAL in MAK CR TOTALS")
            'cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [WorkingCapital]='" & Str(EIGENMITTEL_CAPITAL) & "'  WHERE [RiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()

            'EINFÜGEN Neuberechnete INTEREST RATE RISK in RISK LIMIT DAILY CONTROL
            'Me.BgwBAISimport.ReportProgress(70, "Insert Recalculated INTEREST RATE RISK in RISK LIMIT DAILY CONTROL")
            'cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            'Dim t1 As String = cmd.ExecuteScalar
            'If IsNothing(t1) = False Then
            'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Interest rate risk]=(SELECT [Position/Capital] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & SqlBAISDate & "') WHERE [RLDC Date]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'End If
            'If IsNothing(t1) = True Then
            'cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Interest rate risk]) Values('" & SqlBAISDate & "',(SELECT [Position/Capital] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & SqlBAISDate & "'))"
            'cmd.ExecuteScalar()
            'End If

            'Calculating the RISK BEARING CAPACITY
            'Me.BgwBAISimport.ReportProgress(90, "Calculate RISK BEARING CAPACITY in RISK LIMIT DAILY CONTROL")
            'Dim s1 As Double = 0
            'cmd.CommandText = "select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+[Operational risk]+[Liquidity risk]+EssentialInquantifiableRisksBufferZone) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            's1 = cmd.ExecuteScalar
            'Dim s2 As Double = 0
            'cmd.CommandText = "select sum([Dotation capital]-[Minimum capital requirement]+round([PL Result]/1000,0)+[HGB340F]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            's2 = cmd.ExecuteScalar
            'Dim RBC As Double = (s1 / s2) * 100
            'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub

    Private Sub BAIS_IMPORT_PROCEDURES_NEW()
        Try

            Dim extractorXLS As New XLSExtractor
            Dim extractorCSV As New CSVExtractor

            Dim SOLVA As Double = 0
            Dim CapitalRatio_T1 As Double = 0
            Dim CapitalRatio_Total As Double = 0
            Dim CURRENCY_RISK As Double = 0
            Dim DOTATION_CAPITAL As Double = 0
            Dim DOTATION_CAPITAL_FULL As Double = 0
            Dim CORE_CAPITAL As Double = 0
            Dim EIGENMITTEL_CAPITAL As Double = 0
            Dim LIQUID_LV_FULL As Double = 0
            Dim LIQUID_LV_1_to_3_MONTHS As Double = 0
            Dim LIQUID_LV_3_to_6_MONTHS As Double = 0
            Dim LIQUID_LV_6_to_12_MONTHS As Double = 0
            Dim LIQUIDITY_RISK As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT_STAGE2 As Double = 0
            Dim OPERATIONAL_RISK As Double = 0
            Dim OPERATIONAL_RISK_FULL As Double = 0
            Dim LCR_RATIO As Double = 0
            Dim CVA_RISK As Double = 0 'Credit Valuation Adjustment Risk
            Dim RiskWeightedExposures As Double = 0
            Dim RiskWeigthedAmount_Total As Double = 0
            Dim MARKET_RISK As Double = 0
            Dim OTHER_POSITIONS As Double = 0
            Dim RETAINED_EARNING As Double = 0
            Dim OTHER_INTAGIBLE_ASSETS As Double = 0
            Dim ANTIZYKLISCHER_KAPITAL_PUFFER As Double = 0
            Dim KAPITALERHALTUNGSPUFFER As Double = 0
            ' Create an instance of a workbook.
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()

            'TEST
            'WORKBOOK LCRDROUT
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDROUT_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'cmd.Connection.Open()
            'Dim LCRDROUT_XLS As String = cmd.ExecuteScalar
            'Dim LCRDROUT_XLS_FILE As String = BAISFileNewDirectory & LCRDROUT_XLS
            'If File.Exists(LCRDROUT_XLS_FILE) = True Then
            'workbook.LoadDocument(LCRDROUT_XLS_FILE, DocumentFormat.Xls)
            'Dim worksheet As Worksheet = workbook.Worksheets("LCRDROUT_CTOTL")
            'Dim bd As Date = worksheet.Cells("H4").Value.TextValue
            'Change File
            'worksheet.Cells("C10").Value = "Row_ID"
            'worksheet.Cells("E10").Value = "Amount"
            'worksheet.Cells("F10").Value = "Market_Value_collateral_extended"
            'worksheet.Cells("G10").Value = "Value_Collateral_Extended_Article_9"
            'worksheet.Cells("H10").Value = "Standard_Weight"
            'worksheet.Cells("I10").Value = "Applicable_Weight"
            'worksheet.Cells("J10").Value = "Outflow"
            'worksheet.DeleteCells(worksheet.Range("B2:J8"), DeleteMode.ShiftCellsUp)
            'worksheet.DeleteCells(worksheet.Range("B1:J1"), DeleteMode.ShiftCellsUp)
            'worksheet.Cells("B116").UnMerge()
            'worksheet.DeleteCells(worksheet.Range("B116:J116"), DeleteMode.ShiftCellsUp)
            'workbook.SaveDocument(BAISFileNewDirectory & LCRDROUT_XLS, DocumentFormat.Xls)
            'MsgBox("stop")
            'End If



            'SELECT DATA FROM FILE <CA1.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA1_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            cmd.Connection.Open()
            Dim CA1_XLS As String = cmd.ExecuteScalar
            Dim CA1_XLS_FILE As String = BAISFileNewDirectory & CA1_XLS
            Me.BgwBAISimport.ReportProgress(1, "Start Selecting Data from Excel File " & CA1_XLS_FILE)
            If File.Exists(CA1_XLS_FILE) = True Then

                workbook.LoadDocument(CA1_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA1")

                Me.BgwBAISimport.ReportProgress(2, "Select DOTATION CAPITAL,CORE CAPITAL from Cell F12")
                DOTATION_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                CORE_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                DOTATION_CAPITAL_FULL = worksheet.Cells("F12").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(2, "Select EIGENMITTEL CAPITAL from Cell F9 ")
                EIGENMITTEL_CAPITAL = worksheet.Cells("F9").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(2, "Select RETAINED EARNINGS from Cell F21-F22 and OTHER INTAGIBLE ASSETS from Cell F42-F43 multiply by (-1) ")
                For i = 8 To 100
                    If worksheet.Cells(i, 3).DisplayText = "Retained earnings" Then
                        RETAINED_EARNING = worksheet.Cells(i, 5).Value.NumericValue
                    End If
                    If worksheet.Cells(i, 3).DisplayText = "(-) Other intangible assets" Then
                        OTHER_INTAGIBLE_ASSETS = worksheet.Cells(i, 5).Value.NumericValue * (-1)
                    End If
                Next
            End If


            'SELECT DATA FROM FILE <CA2.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA2_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA2_XLS As String = cmd.ExecuteScalar
            Dim CA2_XLS_FILE As String = BAISFileNewDirectory & CA2_XLS
            Me.BgwBAISimport.ReportProgress(3, "Start Selecting Data from Excel File " & CA2_XLS_FILE)
            If File.Exists(CA2_XLS_FILE) = True Then

                workbook.LoadDocument(CA2_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA2")

                Me.BgwBAISimport.ReportProgress(4, "Select Total RISK WEIGHTED AMOUNT from Cell F9")
                RiskWeigthedAmount_Total = worksheet.Range("F9").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(4, "Select MINIMUM CAPITAL REQUIREMENT from Cell F9 und multiply with 0.08 ,divided by 1000 ")
                MINIMUM_CAPITAL_REQUIREMENT = Math.Round(worksheet.Range("F9").Value.NumericValue * 0.08 / 1000, 2)
                Me.BgwBAISimport.ReportProgress(5, "Select CURRENCY RISK from Cell F59 und multiply with 0.08 ,divided by 1000 ")
                CURRENCY_RISK = Math.Round(worksheet.Range("F59").Value.NumericValue * 0.08 / 1000, 0)
                Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell F59 - Full amount ")
                MARKET_RISK = worksheet.Range("F59").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66, multiply by 0.08 ,divided by 1000")
                OPERATIONAL_RISK = Math.Round(worksheet.Range("F66").Value.NumericValue * 0.08 / 1000, 0)
                Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66 - Full Amount")
                OPERATIONAL_RISK_FULL = worksheet.Range("F66").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(6, "Select CREDIT VALUATION ADJUSTMENT RISK (CVA) from Cell F71 ,Full Amount")
                CVA_RISK = worksheet.Range("F71").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(6, "Select RISK WEIGHTED EXPOSURES from Cell F12 - Full Amount")
                RiskWeightedExposures = worksheet.Range("F12").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(6, "Select OTHER POSITIONS from Cell F30 - Full Amount")
                OTHER_POSITIONS = worksheet.Range("F30").Value.NumericValue
                '*****************************************
            End If


            'SELECT DATA FROM FILE <CA3.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA3_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA3_XLS As String = cmd.ExecuteScalar
            Dim CA3_XLS_FILE As String = BAISFileNewDirectory & CA3_XLS
            Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & CA3_XLS_FILE)
            If File.Exists(CA3_XLS_FILE) = True Then

                workbook.LoadDocument(CA3_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA3")

                Me.BgwBAISimport.ReportProgress(6, "Select SOLVA-CAPITAL ADEQUACY RATIO from Cell F13")
                SOLVA = worksheet.Range("F13").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_T1 (Kernkapital ratio) from Cell F11")
                CapitalRatio_T1 = worksheet.Range("F11").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_Total (CET1 Capital ratio) from Cell F9")
                CapitalRatio_Total = worksheet.Range("F9").Value.NumericValue

            End If

            'SELECT DATA FROM FILE <CA4.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA4_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA4_XLS As String = cmd.ExecuteScalar
            Dim CA4_XLS_FILE As String = BAISFileNewDirectory & CA4_XLS
            Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & CA4_XLS_FILE)
            If File.Exists(CA4_XLS_FILE) = True Then

                workbook.LoadDocument(CA4_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA4")

                If worksheet.Range("G113").Value.NumericValue > 0 Then
                    Me.BgwBAISimport.ReportProgress(6, "Select Capital conservation buffer from Cell G113")
                    KAPITALERHALTUNGSPUFFER = worksheet.Range("G113").Value.NumericValue
                    Me.BgwBAISimport.ReportProgress(6, "Select Institution specific countercyclical capital buffer from Cell G115")
                    ANTIZYKLISCHER_KAPITAL_PUFFER = worksheet.Range("G115").Value.NumericValue
                End If

            End If



            'SELECT DATA FROM FILE <LCRCALC.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRCALC_XLS As String = cmd.ExecuteScalar
            Dim LCRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRCALC_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCRCALC_XLS_FILE)
            If File.Exists(LCRCALC_XLS_FILE) = True Then

                workbook.LoadDocument(LCRCALC_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRCALC_CTOTL")

                Me.BgwBAISimport.ReportProgress(8, "Select LCR RATIO - Sheet LCRCALC_CTOTL from Cell D186")
                LCR_RATIO = worksheet.Range("D186").Value.NumericValue

                'Wenn LCRCALC nur in PDF dann nach dem ExtractorXLS- LCR Wert befindet sich 
                'in Page 10 - Zeile D3
            End If

            'SELECT DATA FROM FILE <LCRIN.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRIN_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRIN_XLS As String = cmd.ExecuteScalar
            Dim LCRIN_XLS_FILE As String = BAISFileNewDirectory & LCRIN_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCRIN_XLS_FILE)
            If File.Exists(LCRIN_XLS_FILE) = True Then
                workbook.LoadDocument(LCRIN_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRIN_CTOTL")

                'Delete current Data
                cmd.CommandText = "Delete from [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()

                Dim RowNr As String = Nothing
                Dim LegalReference As String = Nothing
                Dim Amount As Double = 0
                Dim Inflow As Double = 0
                For i = 10 To 200
                    If worksheet.Cells(i, 1).DisplayText = "020" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Inflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_IN_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "070" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Inflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_IN_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "090" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Inflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_IN_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "980" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Inflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_IN_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                Next

            End If

            'SELECT DATA FROM FILE <LCROUT.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCROUT_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCROUT_XLS As String = cmd.ExecuteScalar
            Dim LCROUT_XLS_FILE As String = BAISFileNewDirectory & LCROUT_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCROUT_XLS_FILE)
            If File.Exists(LCROUT_XLS_FILE) = True Then
                workbook.LoadDocument(LCROUT_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCROUT_CTOTL")

                'Delete current Data
                cmd.CommandText = "Delete from [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()

                Dim RowNr As String = Nothing
                Dim LegalReference As String = Nothing
                Dim Amount As Double = 0
                Dim Outflow As Double = 0
                For i = 10 To 300
                    If worksheet.Cells(i, 1).DisplayText = "1000" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1060" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1070" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1110" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1120" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1130" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1230" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1280" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "1330" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Outflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Outflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Outflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                Next

            End If

            'SELECT DATA FROM FILE <LCRLA.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRLA_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRLA_XLS As String = cmd.ExecuteScalar
            Dim LCRLA_XLS_FILE As String = BAISFileNewDirectory & LCRLA_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCRLA_XLS_FILE)
            If File.Exists(LCRLA_XLS_FILE) = True Then
                workbook.LoadDocument(LCRLA_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRLA_CTOTL")

                'Delete current Data
                cmd.CommandText = "Delete from [LCR_LA_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()

                Dim RowNr As String = Nothing
                Dim LegalReference As String = Nothing
                Dim Amount As Double = 0
                Dim Inflow As Double = 0
                For i = 8 To 200
                    If worksheet.Cells(i, 1).DisplayText = "010" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 7).Value.NumericValue
                        Inflow = worksheet.Cells(i, 7).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_LA_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "020" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 7).Value.NumericValue
                        Inflow = worksheet.Cells(i + 1, 7).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_LA_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "040" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i, 4).DisplayText
                        Amount = worksheet.Cells(i, 5).Value.NumericValue
                        Inflow = worksheet.Cells(i, 6).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_LA_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                    If worksheet.Cells(i, 1).DisplayText = "190" Then
                        RowNr = worksheet.Cells(i, 1).DisplayText
                        LegalReference = worksheet.Cells(i - 1, 4).DisplayText
                        Amount = worksheet.Cells(i, 7).Value.NumericValue
                        Inflow = worksheet.Cells(i, 8).Value.NumericValue
                        cmd.CommandText = "INSERT INTO [LCR_LA_BAIS]([RiskDate],[RowNr],[LegalReference],[Amount],[Inflow]) Values('" & SqlBAISDate & "','" & RowNr & "','" & LegalReference & "','" & Str(Amount) & "','" & Str(Inflow) & "')"
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'MINDESTRESERVE CALCULATION
                Me.BgwBAISimport.ReportProgress(9, "Calculate Minimal Rerserve in Bundesbank ")
                cmd.CommandText = "UPDATE [LCR_LA_BAIS] set [MindestReserveBUBA]=Round([Amount]-[Inflow],0) where [RowNr] in ('020') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
            End If

            'SELECT DATA FROM FILE <LV2.PDF>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LIQV_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LIQV_PDF As String = cmd.ExecuteScalar
            Dim LIQV_PDF_FILE As String = BAISFileNewDirectory & LIQV_PDF
            If File.Exists(LIQV_PDF_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(9, "Start Selecting Data from Pdf File " & LIQV_PDF_FILE)
                extractorXLS.LoadDocumentFromFile(LIQV_PDF_FILE)
                extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\LV2output.xls")
                extractorXLS.Reset() 'Ends extractor and releases the Document


                Dim LIQV_XLS_FILE As String = BAISFileNewDirectory & "\LV2output.xls"
                Me.BgwBAISimport.ReportProgress(10, "Select from Excel File " & LIQV_XLS_FILE)

                workbook.LoadDocument(LIQV_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("Page 2")


                'LIQUID LV
                'Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell D23")
                'LIQUID_LV_FULL = worksheet.Range("D23").Value.NumericValue
                'OTHER LIQUIDITY PERIODS
                'Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell E26")
                'LIQUID_LV_1_to_3_MONTHS = worksheet.Range("E26").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell F26")
                'LIQUID_LV_3_to_6_MONTHS = worksheet.Range("F26").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell G26")
                'LIQUID_LV_6_to_12_MONTHS = worksheet.Range("G26").Value.NumericValue
                '*****************************************

                'LIQUID LV
                Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell F26")
                LIQUID_LV_FULL = worksheet.Range("F26").Value.NumericValue
                'OTHER LIQUIDITY PERIODS
                Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell G30")
                LIQUID_LV_1_to_3_MONTHS = worksheet.Range("G30").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell H30")
                LIQUID_LV_3_to_6_MONTHS = worksheet.Range("H30").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell I30")
                LIQUID_LV_6_to_12_MONTHS = worksheet.Range("I30").Value.NumericValue
                '*****************************************



            End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            'Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(15, "Start Selecting Data from Excel  File " & MKRSAFX_XLS_FILE)
            'If File.Exists(MKRSAFX_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(MKRSAFX_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("MKRSAFX")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(16, "Select CURRENCY RISK from Cell S13")
            'CURRENCY_RISK = Math.Round(xlWorksheet1.Range("S13").Value / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If

            'SELECT DATA FROM FILE <CROPR.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CROPR_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim CROPR_XLS As String = cmd.ExecuteScalar
            'Dim CROPR_XLS_FILE As String = BAISFileNewDirectory & CROPR_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(17, "Start Selecting Data from Excel  File " & CROPR_XLS_FILE)
            'If File.Exists(CROPR_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(CROPR_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("CROPR")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(18, "Select OPERATIONAL RISK from Cell K12, multiply by 0.08")
            'OPERATIONAL_RISK = Math.Round(xlWorksheet1.Range("K12").Value * 0.08 / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If


            'Only for check reasons
            'MsgBox("[RLDC Date]=" & SqlBAISDate & "[Bank SolvV]=" & Str(SOLVA) & "[Currency risk]=" & Str(CURRENCY_RISK) & "[Dotation capital]=" & Str(DOTATION_CAPITAL) & "[DotationCapitalFull]" & Str(DOTATION_CAPITAL_FULL) & "[Core capital]=" & Str(CORE_CAPITAL) & "[Bank Liquid LV]=" & Str(LIQUID_LV_FULL) & "[Liquid1M3M]=" & Str(LIQUID_LV_1_to_3_MONTHS) & "[Liquid3M6M]=" & Str(LIQUID_LV_3_to_6_MONTHS) & "[Liquid6M12M]=" & Str(LIQUID_LV_6_to_12_MONTHS) & "[Liquidity risk]=" & Str(LIQUIDITY_RISK) & "[Minimum capital requirement]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[Minimum capital requirementSTAGE2]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[LCR_Ratio]=" & Str(LCR_RATIO) & "[Operational risk]=" & Str(OPERATIONAL_RISK) & "[CVA_Risk]=" & Str(CVA_RISK) & "[RiskWeightedExposures]=" & Str(RiskWeightedExposures) & "[MarketRiskPosition]=" & Str(MARKET_RISK) & "[OtherPositionsBAIS]=" & Str(OTHER_POSITIONS) & "[OperationalRiskPosition]=" & Str(OPERATIONAL_RISK_FULL) & "[RetainedEarningsBAIS]=" & Str(RETAINED_EARNING) & "[OtherIntagibleAssetsBAIS]=" & Str(OTHER_INTAGIBLE_ASSETS) & "[OwnCapitalBAIS]=" & Str(EIGENMITTEL_CAPITAL))

            'INSERT DATA in RISK LIMIT DAILY CONTROL
            Me.BgwBAISimport.ReportProgress(50, "Insert selected Data in RISK LIMIT DAILY CONTROL")
            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Bank SolvV]='" & Str(SOLVA) & "',[Currency risk]='" & Str(CURRENCY_RISK) & "',[Dotation capital]='" & Str(DOTATION_CAPITAL) & "',[DotationCapitalFull]='" & Str(DOTATION_CAPITAL_FULL) & "',[Core capital]='" & Str(CORE_CAPITAL) & "',[Bank Liquid LV]='" & Str(LIQUID_LV_FULL) & "',[Liquid1M3M]='" & Str(LIQUID_LV_1_to_3_MONTHS) & "',[Liquid3M6M]='" & Str(LIQUID_LV_3_to_6_MONTHS) & "',[Liquid6M12M]='" & Str(LIQUID_LV_6_to_12_MONTHS) & "',[Liquidity risk]='" & Str(LIQUIDITY_RISK) & "',[Minimum capital requirement]='" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "',[Minimum capital requirementSTAGE2]='" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "',[LCR_Ratio]='" & Str(LCR_RATIO) & "',[Operational risk]='" & Str(OPERATIONAL_RISK) & "', [CVA_Risk]='" & Str(CVA_RISK) & "',[RiskWeightedExposures]='" & Str(RiskWeightedExposures) & "' ,[MarketRiskPosition]='" & Str(MARKET_RISK) & "' ,[OtherPositionsBAIS]='" & Str(OTHER_POSITIONS) & "',[OperationalRiskPosition]='" & Str(OPERATIONAL_RISK_FULL) & "',[RetainedEarningsBAIS]='" & Str(RETAINED_EARNING) & "',[OtherIntagibleAssetsBAIS]='" & Str(OTHER_INTAGIBLE_ASSETS) & "',[OwnCapitalBAIS]='" & Str(EIGENMITTEL_CAPITAL) & "',[AntizyklischerKapitalPuffer]='" & Str(ANTIZYKLISCHER_KAPITAL_PUFFER) & "',[KapitalerhaltungsPuffer]='" & Str(KAPITALERHALTUNGSPUFFER) & "',[RiskWeigthedAmount_Total]='" & Str(RiskWeigthedAmount_Total) & "',[CapitalRatio_T1]='" & Str(CapitalRatio_T1) & "',[CapitalRatio_Total]='" & Str(CapitalRatio_Total) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
            End If
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Bank SolvV],[Currency risk],[Dotation capital],[DotationCapitalFull],[Core capital],[Bank Liquid LV],[Liquid1M3M],[Liquid3M6M],[Liquid6M12M],[Liquidity risk],[Minimum capital requirement],[Minimum capital requirementSTAGE2],[LCR_Ratio],[Operational risk],[CVA_Risk],[RiskWeightedExposures],[MarketRiskPosition],[OtherPositionsBAIS],[OperationalRiskPosition],[RetainedEarningsBAIS],[OtherIntagibleAssetsBAIS],[OwnCapitalBAIS],[AntizyklischerKapitalPuffer],[KapitalerhaltungsPuffer],[RiskWeigthedAmount_Total],[CapitalRatio_T1],[CapitalRatio_Total],[IdBank]) Values('" & SqlBAISDate & "','" & Str(SOLVA) & "','" & Str(CURRENCY_RISK) & "','" & Str(DOTATION_CAPITAL) & "','" & Str(DOTATION_CAPITAL_FULL) & "','" & Str(CORE_CAPITAL) & "','" & Str(LIQUID_LV_FULL) & "','" & Str(LIQUID_LV_1_to_3_MONTHS) & "','" & Str(LIQUID_LV_3_to_6_MONTHS) & "','" & Str(LIQUID_LV_6_to_12_MONTHS) & "','" & Str(LIQUIDITY_RISK) & "','" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "','" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "','" & Str(LCR_RATIO) & "','" & Str(OPERATIONAL_RISK) & "','" & Str(CVA_RISK) & "','" & Str(RiskWeightedExposures) & "','" & Str(MARKET_RISK) & "','" & Str(OTHER_POSITIONS) & "' ,'" & Str(OPERATIONAL_RISK_FULL) & "','" & Str(RETAINED_EARNING) & "','" & Str(OTHER_INTAGIBLE_ASSETS) & "','" & Str(EIGENMITTEL_CAPITAL) & "','" & Str(ANTIZYKLISCHER_KAPITAL_PUFFER) & "','" & Str(KAPITALERHALTUNGSPUFFER) & "','" & Str(RiskWeigthedAmount_Total) & "','" & Str(CapitalRatio_T1) & "','" & Str(CapitalRatio_Total) & "','3')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
            End If

            'UPDATE ITEM NAMES in LCR_IN, LCR_OUT, LCR_LA
            Me.BgwBAISimport.ReportProgress(60, "Update Items in LCR_IN,LCR_OUT and LCR_LA")
            cmd.CommandText = "UPDATE A set A.[Item]=B.S from [LCR_IN_BAIS] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='LCR_IN_ITEMS' and [PARAMETER STATUS] ='Y')B ON A.[RowNr]=B.[PARAMETER1]  where A.[RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A set A.[Item]=B.S from [LCR_OUT_BAIS] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='LCR_OUT_ITEMS' and [PARAMETER STATUS] ='Y')B ON A.[RowNr]=B.[PARAMETER1]  where A.[RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "UPDATE A set A.[Item]=B.S from [LCR_LA_BAIS] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='LCR_LA_ITEMS' and [PARAMETER STATUS] ='Y')B ON A.[RowNr]=B.[PARAMETER1]  where A.[RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()

            'UPDATE ITEM NAMES in LCR_IN, LCR_OUT, LCR_LA
            Me.BgwBAISimport.ReportProgress(60, "Update Factors in LCR_IN,LCR_OUT and LCR_LA")
            cmd.CommandText = "Update [LCR_IN_BAIS] set [Factor]=Round([Inflow]/[Amount],2) where [RiskDate]='" & SqlBAISDate & "' and [Amount]<>0 and [Inflow]<>0"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [LCR_OUT_BAIS] set [Factor]=Round([Outflow]/[Amount],2) where [RiskDate]='" & SqlBAISDate & "' and [Amount]<>0 and [Outflow]<>0"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update [LCR_LA_BAIS] set [Factor]=Round([Inflow]/[Amount],2) where [RiskDate]='" & SqlBAISDate & "' and [Amount]=[Inflow] and [Amount]<>0 and [Inflow]<>0"
            cmd.ExecuteNonQuery()

            'Update sums
            Me.BgwBAISimport.ReportProgress(60, "Insert and Update Sums in LCR_Overview")
            cmd.CommandText = "Delete from [LCR_Overview] where [RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [LCR_Overview] ([RiskDate]) Values ('" & SqlBAISDate & "')"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A set A.[SumInflow]=B.S from [LCR_Overview] A INNER JOIN (Select Sum([Inflow]) as S,[RiskDate] from [LCR_IN_BAIS] GROUP BY [RiskDate])B on A.[RiskDate]=B.RiskDate where A.[RiskDate]= '" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A set A.[SumOutflow]=B.S from [LCR_Overview] A INNER JOIN (Select Sum([Outflow]) as S,[RiskDate] from [LCR_OUT_BAIS] GROUP BY [RiskDate])B on A.[RiskDate]=B.RiskDate where A.[RiskDate]= '" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Update A set A.[SumLA]=B.S from [LCR_Overview] A INNER JOIN (Select Sum([Inflow]) as S,[RiskDate] from [LCR_LA_BAIS] GROUP BY [RiskDate])B on A.[RiskDate]=B.RiskDate where A.[RiskDate]= '" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            'NEUBERECHNUNG DES INTEREST RATE RISKS nach den EIGENMITTEL KAPITAL
            'Einfügen des Eigenmittel Kapitals in RATERISK DATE
            'Me.BgwBAISimport.ReportProgress(60, "Insert EIGENMITTEL CAPITAL in RATE RISK (INTERST RATE RISK)")
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Working Capital]='" & Str(EIGENMITTEL_CAPITAL) & "'  WHERE [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Working Capital]=Round([Working Capital],0)  WHERE [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'Neuberechnung der Interest rate risk
            'Me.BgwBAISimport.ReportProgress(65, "Recalculate INTEREST RATE RISK")
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=Round([SumAM2]/[Working Capital]*100,2)  WHERE [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'Interest Rate Risk - ABSOLUTE NUMBER
            'cmd.CommandText = "UPDATE [RATERISK DATE] SET [Position/Capital]=[Position/Capital]*(-1) where [Position/Capital]<0  and [RateRiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteNonQuery()

            'Neuberechnung der Interest rate risk
            'Me.BgwBAISimport.ReportProgress(67, "Insert EIGENMITTEL CAPITAL in MAK CR TOTALS")
            'cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [WorkingCapital]='" & Str(EIGENMITTEL_CAPITAL) & "'  WHERE [RiskDate]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()

            'EINFÜGEN Neuberechnete INTEREST RATE RISK in RISK LIMIT DAILY CONTROL
            'Me.BgwBAISimport.ReportProgress(70, "Insert Recalculated INTEREST RATE RISK in RISK LIMIT DAILY CONTROL")
            'cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            'Dim t1 As String = cmd.ExecuteScalar
            'If IsNothing(t1) = False Then
            'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Interest rate risk]=(SELECT [Position/Capital] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & SqlBAISDate & "') WHERE [RLDC Date]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()
            'End If
            'If IsNothing(t1) = True Then
            'cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Interest rate risk]) Values('" & SqlBAISDate & "',(SELECT [Position/Capital] FROM [RATERISK DATE] WHERE [RateRiskDate]='" & SqlBAISDate & "'))"
            'cmd.ExecuteScalar()
            'End If

            'Calculating the RISK BEARING CAPACITY
            'Dim s1 As Double = 0
            'Dim s2 As Double = 0
            'Dim RBC As Double = 0
            'Dim MaxOperationalRisk As Double = 0

            'Me.BgwBAISimport.ReportProgress(90, "Select Maximum Value between BAIS OPERATIONAL RISK and ExtendOfDamage Amount in Incidents Table")
            'cmd.CommandText = "Select Max(OperationalRisk) from (Select [Operational risk] as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "' Union All Select Round([OperationalRiskIncidents]/1000,0) as OperationalRisk FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "')B"
            'MaxOperationalRisk = cmd.ExecuteScalar

            'Me.BgwBAISimport.ReportProgress(90, "Calculate RISK BEARING CAPACITY in RISK LIMIT DAILY CONTROL")
            'If BAIS_Date < DateSerial(2014, 9, 30) Then
            'cmd.CommandText = "Select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+round([Interest risk]/1000,0)+[Currency risk]+ " & MaxOperationalRisk & " +[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            's1 = cmd.ExecuteScalar
            'cmd.CommandText = "Select sum([Dotation capital]-[Minimum capital requirement]+round([PLdefault]/1000,0)+[HGB340F]-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            's2 = cmd.ExecuteScalar
            'Else
            'cmd.CommandText = "select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+[Operational risk]+[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            's1 = cmd.ExecuteScalar
            'cmd.CommandText = "select sum([Dotation capital]-[Minimum capital requirement]+round([PLdefault]/1000,0)-[EssentialInquantifiableRisksBufferZone]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            's2 = cmd.ExecuteScalar
            'End If

            'RBC = (s1 / s2) * 100
            'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
            'cmd.ExecuteScalar()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try

    End Sub

    Private Sub BAIS_IMPORT_PROCEDURES_FROM_30092016()
        Try

            Dim extractorXLS As New XLSExtractor
            Dim extractorCSV As New CSVExtractor

            Dim SOLVA As Double = 0
            Dim CapitalRatio_T1 As Double = 0
            Dim CapitalRatio_Total As Double = 0
            Dim CURRENCY_RISK As Double = 0
            Dim DOTATION_CAPITAL As Double = 0
            Dim DOTATION_CAPITAL_FULL As Double = 0
            Dim CORE_CAPITAL As Double = 0
            Dim EIGENMITTEL_CAPITAL As Double = 0
            Dim LIQUID_LV_FULL As Double = 0
            Dim LIQUID_LV_1_to_3_MONTHS As Double = 0
            Dim LIQUID_LV_3_to_6_MONTHS As Double = 0
            Dim LIQUID_LV_6_to_12_MONTHS As Double = 0
            Dim LIQUIDITY_RISK As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT_STAGE2 As Double = 0
            Dim OPERATIONAL_RISK As Double = 0
            Dim OPERATIONAL_RISK_FULL As Double = 0
            Dim LCRDR_LiquidityBuffer As Double = 0
            Dim LCRDR_NetLiquidityOutflow As Double = 0
            Dim LCR_RATIO As Double = 0
            Dim CVA_RISK As Double = 0 'Credit Valuation Adjustment Risk
            Dim RiskWeightedExposures As Double = 0
            Dim RiskWeigthedAmount_Total As Double = 0
            Dim MARKET_RISK As Double = 0
            Dim OTHER_POSITIONS As Double = 0
            Dim RETAINED_EARNING As Double = 0
            Dim OTHER_INTAGIBLE_ASSETS As Double = 0
            Dim ANTIZYKLISCHER_KAPITAL_PUFFER As Double = 0
            Dim KAPITALERHALTUNGSPUFFER As Double = 0
            ' Create an instance of a workbook.
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            'Dim attributes As FileAttributes

            'WORKBOOK LCRDROUT
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDROUT_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDROUT_XLS As String = cmd.ExecuteScalar
            Dim LCRDROUT_XLS_FILE As String = BAISFileNewDirectory & LCRDROUT_XLS
            If File.Exists(LCRDROUT_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDROUT_XLS_FILE)
                'attributes = File.GetAttributes(LCRDROUT_XLS_FILE)
                'attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)

                workbook.LoadDocument(LCRDROUT_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDROUT_CTOTL")
                Dim bd As Date = worksheet.Cells("H4").Value.TextValue
                'Change File
                worksheet.Rows(0).Visible = True
                worksheet.Columns(0).Visible = True
                'worksheet.Rows(0).Delete()
                'worksheet.Columns(0).Delete()
                'worksheet.UnMergeCells(worksheet.Range("A1:J8"))
                worksheet.DeleteCells(worksheet.Range("A1:J8"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A1:J1"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A115:K115"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Market_Value_collateral_extended"
                worksheet.Cells("G1").Value = "Value_Collateral_Extended_Article_9"
                worksheet.Cells("H1").Value = "Standard_Weight"
                worksheet.Cells("I1").Value = "Applicable_Weight"
                worksheet.Cells("J1").Value = "Outflow"
                workbook.SaveDocument(BAISFileNewDirectory & LCRDROUT_XLS, DocumentFormat.Xls)


                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDROUT_XLS

                cmd.CommandText = "DELETE FROM [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow] FROM [LCRDROUT_CTOTL$]')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "' and [Item] is NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDROUT_XLS_FILE)

            End If

            'WORKBOOK LCRDRIN
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRIN_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRIN_XLS As String = cmd.ExecuteScalar
            Dim LCRDRIN_XLS_FILE As String = BAISFileNewDirectory & LCRDRIN_XLS
            If File.Exists(LCRDRIN_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRIN_XLS_FILE)
                'attributes = File.GetAttributes(LCRDRIN_XLS_FILE)
                'attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)

                workbook.LoadDocument(LCRDRIN_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRIN_CTOTL")
                Dim bd As Date = worksheet.Cells("F4").Value.TextValue
                'Change File

                worksheet.UnMergeCells(worksheet.Range("A1:T9"))
                worksheet.DeleteCells(worksheet.Range("A1:T11"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Amount_1"
                worksheet.Cells("G1").Value = "Amount_2"
                worksheet.Cells("H1").Value = "Market_Value"
                worksheet.Cells("I1").Value = "Market_Value_1"
                worksheet.Cells("J1").Value = "Market_Value_2"
                worksheet.Cells("K1").Value = "Standard_Weight"
                worksheet.Cells("L1").Value = "Applicable_Weight"
                worksheet.Cells("M1").Value = "Applicable_Weight_1"
                worksheet.Cells("N1").Value = "Applicable_Weight_2"
                worksheet.Cells("O1").Value = "ValueCollateralReceived"
                worksheet.Cells("P1").Value = "ValueCollateralReceived_1"
                worksheet.Cells("Q1").Value = "ValueCollateralReceived_2"
                worksheet.Cells("R1").Value = "Inflow"
                worksheet.Cells("S1").Value = "Inflow_1"
                worksheet.Cells("T1").Value = "Inflow_2"

                worksheet.Cells("B46").UnMerge()
                worksheet.DeleteCells(worksheet.Range("A46:T46"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A:A"), DeleteMode.EntireColumn)
                workbook.SaveDocument(BAISFileNewDirectory & LCRDRIN_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRIN_XLS

                cmd.CommandText = "DELETE FROM [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_IN_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2] FROM [LCRDRIN_CTOTL$]')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "' and [Item] is NULL"
                cmd.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRIN_XLS_FILE)

            End If


            'WORKBOOK LCRDRLA
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRLA_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRLA_XLS As String = cmd.ExecuteScalar
            Dim LCRDRLA_XLS_FILE As String = BAISFileNewDirectory & LCRDRLA_XLS
            If File.Exists(LCRDRLA_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRLA_XLS_FILE)
                workbook.LoadDocument(LCRDRLA_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRLA_CTOTL")
                Dim bd As Date = worksheet.Cells("G4").Value.TextValue
                'Change File
                worksheet.Rows(0).Visible = True
                worksheet.Columns(0).Visible = True
                'worksheet.Rows(0).Delete()
                'worksheet.Columns(0).Delete()
                worksheet.UnMergeCells(worksheet.Range("A1:H9"))
                worksheet.DeleteCells(worksheet.Range("A9:H9"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A1:H7"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Standard_Weight"
                worksheet.Cells("G1").Value = "Applicable_Weight"
                worksheet.Cells("H1").Value = "ValueAccArt9"

                worksheet.Cells("B49").UnMerge()
                worksheet.DeleteCells(worksheet.Range("A49:H49"), DeleteMode.ShiftCellsUp)
                workbook.SaveDocument(BAISFileNewDirectory & LCRDRLA_XLS, DocumentFormat.Xls)


                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRLA_XLS

                cmd.CommandText = "DELETE FROM [LCR_LA_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_LA_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[Inflow],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[ValueAccArt9],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[ValueAccArt9] FROM [LCRDRLA_CTOTL$]')"
                cmd.ExecuteNonQuery()
                'MINDESTRESERVE CALCULATION
                Me.BgwBAISimport.ReportProgress(9, "Calculate Minimal Rerserve in Bundesbank ")
                cmd.CommandText = "UPDATE A SET A.[MindestReserveBUBA]=Round(ABS(B.[Total_Balance]) - A.[Inflow],0) from [LCR_LA_BAIS] A INNER JOIN [DailyBalanceDetailsSheets] B on A.RiskDate=B.BSDate where A.RowNr in ('050') and B.[GL_Item] in ('20') and A.[RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRLA_XLS_FILE)
            End If

            'WORKBOOK LCRDRCALC
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim LCRDRCALC_XLS As String = cmd.ExecuteScalar
            'Dim LCRDRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRDRCALC_XLS
            'If File.Exists(LCRDRCALC_XLS_FILE) = True Then
            'workbook.LoadDocument(LCRDRCALC_XLS_FILE, DocumentFormat.Xls)
            'Dim worksheet As Worksheet = workbook.Worksheets("LCRDRCALC_CTOTL")
            'Dim bd As Date = worksheet.Cells("F4").Value.TextValue
            'Change File
            'worksheet.UnMergeCells(worksheet.Range("A1:B11"))
            'worksheet.DeleteCells(worksheet.Range("A1:F8"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A2:F3"), DeleteMode.EntireRow)
            'worksheet.UnMergeCells(worksheet.Range("A1:E42"))
            'Worksheet.Cells("C1").Value = "Row_ID"
            'worksheet.Cells("E1").Value = "Amount"
            'Worksheet.DeleteCells(Worksheet.Range("A5:F5"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A31:F31"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A39:F39"), DeleteMode.EntireRow)
            'workbook.SaveDocument(BAISFileNewDirectory & LCRDRCALC_XLS, DocumentFormat.Xls)
            'Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRCALC_XLS
            'End If


            'SELECT DATA FROM FILE <LCRDRCALC>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRCALC_XLS As String = cmd.ExecuteScalar
            Dim LCRDRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRDRCALC_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCRDRCALC_XLS_FILE)
            If File.Exists(LCRDRCALC_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRCALC_XLS_FILE)
                workbook.LoadDocument(LCRDRCALC_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRCALC_CTOTL")

                Me.BgwBAISimport.ReportProgress(8, "Select LCRDR Liquidity Buffer - Sheet LCRDRCALC_CTOTL from Cell E12")
                LCRDR_LiquidityBuffer = worksheet.Range("E12").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(8, "Select LCRDR Net Liquidty Outflow - Sheet LCRDRCALC_CTOTL from Cell E13")
                LCRDR_NetLiquidityOutflow = worksheet.Range("E13").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(8, "Select LCR RATIO - Sheet LCRDRCALC_CTOTL from Cell E14")
                LCR_RATIO = Math.Round(worksheet.Range("E14").Value.NumericValue / 100, 2)
                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRCALC_XLS_FILE)
            End If



            'SELECT DATA FROM FILE <CA1.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA1_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA1_XLS As String = cmd.ExecuteScalar
            Dim CA1_XLS_FILE As String = BAISFileNewDirectory & CA1_XLS
            If File.Exists(CA1_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & CA1_XLS_FILE)
                workbook.LoadDocument(CA1_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA1")

                'Me.BgwBAISimport.ReportProgress(2, "Select DOTATION CAPITAL,CORE CAPITAL from Cell F12")
                'DOTATION_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                'CORE_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                'DOTATION_CAPITAL_FULL = worksheet.Cells("F12").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(2, "Select EIGENMITTEL CAPITAL from Cell F9 ")
                'EIGENMITTEL_CAPITAL = worksheet.Cells("F9").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(2, "Select RETAINED EARNINGS from Cell F21-F22 and OTHER INTAGIBLE ASSETS from Cell F42-F43 multiply by (-1) ")
                'For i = 8 To 100
                'If worksheet.Cells(i, 3).DisplayText = "Retained earnings" Then
                'RETAINED_EARNING = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "(-) Other intangible assets" Then
                'OTHER_INTAGIBLE_ASSETS = worksheet.Cells(i, 5).Value.NumericValue * (-1)
                'End If
                'Next

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA1_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA1_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA1') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA1' as 'ExcelFile',Rows,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA1$]')"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & CA1_XLS_FILE)

            End If


            'SELECT DATA FROM FILE <CA2.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA2_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA2_XLS As String = cmd.ExecuteScalar
            Dim CA2_XLS_FILE As String = BAISFileNewDirectory & CA2_XLS
            If File.Exists(CA2_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA2_XLS_FILE)
                workbook.LoadDocument(CA2_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA2")

                'Me.BgwBAISimport.ReportProgress(4, "Select Total RISK WEIGHTED AMOUNT from Cell F9")
                'RiskWeigthedAmount_Total = worksheet.Range("F9").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(4, "Select MINIMUM CAPITAL REQUIREMENT from Cell F9 und multiply with 0.08 ,divided by 1000 ")
                'MINIMUM_CAPITAL_REQUIREMENT = Math.Round(worksheet.Range("F9").Value.NumericValue * 0.08 / 1000, 2)
                '--Me.BgwBAISimport.ReportProgress(5, "Select CURRENCY RISK from Cell F59 und multiply with 0.08 ,divided by 1000 ")
                '--CURRENCY_RISK = Math.Round(worksheet.Range("F59").Value.NumericValue * 0.08 / 1000, 0) 'No Data since BAIS 1.23
                '--Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell F59 - Full amount ")
                '--MARKET_RISK = worksheet.Range("F59").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66, multiply by 0.08 ,divided by 1000")
                'OPERATIONAL_RISK = Math.Round(worksheet.Range("F66").Value.NumericValue * 0.08 / 1000, 0)
                'Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66 - Full Amount")
                'OPERATIONAL_RISK_FULL = worksheet.Range("F66").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CREDIT VALUATION ADJUSTMENT RISK (CVA) from Cell F71 ,Full Amount")
                'CVA_RISK = worksheet.Range("F71").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select RISK WEIGHTED EXPOSURES from Cell F12 - Full Amount")
                'RiskWeightedExposures = worksheet.Range("F12").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select OTHER POSITIONS from Cell F30 - Full Amount")
                'OTHER_POSITIONS = worksheet.Range("F30").Value.NumericValue
                '*****************************************

                'For i = 8 To 100
                'If worksheet.Cells(i, 3).DisplayText = "TOTAL RISK EXPOSURE AMOUNT FOR OPERATIONAL RISK (OpR )" Then
                'OPERATIONAL_RISK = Math.Round(worksheet.Cells(i, 5).Value.NumericValue * 0.08 / 1000, 0)
                'OPERATIONAL_RISK_FULL = worksheet.Cells(i, 5).Value.NumericValue
                'MsgBox(OPERATIONAL_RISK)
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "TOTAL RISK EXPOSURE AMOUNT FOR CREDIT VALUATION ADJUSTMENT" Then
                'CVA_RISK = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "RISK WEIGHTED EXPOSURE AMOUNTS FOR CREDIT, COUNTERPARTY CREDIT AND DILUTION RISKS AND FREE DELIVERIES" Then
                'RiskWeightedExposures = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "Other items" Then
                'OTHER_POSITIONS = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'Next

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA2_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA2_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA2') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA2' as 'ExcelFile',Rows,Item,Label,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA2$]')"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA2_XLS_FILE)

            End If


            'SELECT DATA FROM FILE <CA3.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA3_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA3_XLS As String = cmd.ExecuteScalar
            Dim CA3_XLS_FILE As String = BAISFileNewDirectory & CA3_XLS

            If File.Exists(CA3_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA3_XLS_FILE)
                workbook.LoadDocument(CA3_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA3")

                'Me.BgwBAISimport.ReportProgress(6, "Select SOLVA-CAPITAL ADEQUACY RATIO from Cell F13")
                'SOLVA = worksheet.Range("F13").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_T1 (Kernkapital ratio) from Cell F11")
                'CapitalRatio_T1 = worksheet.Range("F11").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_Total (CET1 Capital ratio) from Cell F9")
                'CapitalRatio_Total = worksheet.Range("F9").Value.NumericValue

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA3_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA3_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA3') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA3' as 'ExcelFile',Rows,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA3$]') where Item is not NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA3_XLS_FILE)

            End If

            'SELECT DATA FROM FILE <CA4.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA4_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA4_XLS As String = cmd.ExecuteScalar
            Dim CA4_XLS_FILE As String = BAISFileNewDirectory & CA4_XLS
            Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & CA4_XLS_FILE)
            If File.Exists(CA4_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA4_XLS_FILE)
                workbook.LoadDocument(CA4_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA4")

                'If worksheet.Range("G113").Value.NumericValue > 0 Then
                'Me.BgwBAISimport.ReportProgress(6, "Select Capital conservation buffer from Cell G113")
                'KAPITALERHALTUNGSPUFFER = worksheet.Range("G113").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select Institution specific countercyclical capital buffer from Cell G115")
                'ANTIZYKLISCHER_KAPITAL_PUFFER = worksheet.Range("G115").Value.NumericValue
                'End If


                'Import all File Data
                worksheet.Cells("G8").Value = "Amount"
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA4_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA4_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA4') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA4' as 'ExcelFile',Row,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA4$]') where Item is not NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA4_XLS_FILE)
            End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS

            If File.Exists(MKRSAFX_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & MKRSAFX_XLS)
                workbook.LoadDocument(MKRSAFX_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("MKRSAFX")

                If worksheet.Range("S13").Value.NumericValue <> 0 Then
                    Me.BgwBAISimport.ReportProgress(6, "Select Currency Risk Amount from Cell S13 und multiply with 0.08 ,divided by 1000")
                    CURRENCY_RISK = Math.Round(worksheet.Range("S13").Value.NumericValue * 0.08 / 1000, 0)
                    Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell S13 - Full amount ")
                    MARKET_RISK = worksheet.Range("S13").Value.NumericValue
                End If
                Me.BgwBAISimport.ReportProgress(5, "End Selecting Data from Excel File " & MKRSAFX_XLS)
            End If



            'SELECT DATA FROM FILE <LV2.PDF>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LIQV_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LIQV_PDF As String = cmd.ExecuteScalar
            Dim LIQV_PDF_FILE As String = BAISFileNewDirectory & LIQV_PDF
            If File.Exists(LIQV_PDF_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(9, "Start Selecting Data from Pdf File " & LIQV_PDF_FILE)
                extractorXLS.LoadDocumentFromFile(LIQV_PDF_FILE)
                extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\LV2output.xls")
                extractorXLS.Reset() 'Ends extractor and releases the Document


                Dim LIQV_XLS_FILE As String = BAISFileNewDirectory & "\LV2output.xls"
                Me.BgwBAISimport.ReportProgress(10, "Select from Excel File " & LIQV_XLS_FILE)

                workbook.LoadDocument(LIQV_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("Page 2")


                'LIQUID LV
                'Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell D23")
                'LIQUID_LV_FULL = worksheet.Range("D23").Value.NumericValue
                'OTHER LIQUIDITY PERIODS
                'Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell E26")
                'LIQUID_LV_1_to_3_MONTHS = worksheet.Range("E26").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell F26")
                'LIQUID_LV_3_to_6_MONTHS = worksheet.Range("F26").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell G26")
                'LIQUID_LV_6_to_12_MONTHS = worksheet.Range("G26").Value.NumericValue
                '*****************************************

                'LIQUID LV
                Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell F26")
                LIQUID_LV_FULL = worksheet.Range("F26").Value.NumericValue
                'OTHER LIQUIDITY PERIODS
                If worksheet.Range("G30").Value.IsEmpty = False Then
                    Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell G30")
                    LIQUID_LV_1_to_3_MONTHS = worksheet.Range("G30").Value.NumericValue
                    Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell H30")
                    LIQUID_LV_3_to_6_MONTHS = worksheet.Range("H30").Value.NumericValue
                    Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell I30")
                    LIQUID_LV_6_to_12_MONTHS = worksheet.Range("I30").Value.NumericValue
                    '*****************************************
                ElseIf worksheet.Range("G30").Value.IsEmpty = True Then
                    Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell H30")
                    LIQUID_LV_1_to_3_MONTHS = worksheet.Range("H30").Value.NumericValue
                    Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell I30")
                    LIQUID_LV_3_to_6_MONTHS = worksheet.Range("I30").Value.NumericValue
                    Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell J30")
                    LIQUID_LV_6_to_12_MONTHS = worksheet.Range("J30").Value.NumericValue
                    '*****************************************
                End If


                Me.BgwBAISimport.ReportProgress(9, "End Selecting Data from Pdf File " & LIQV_PDF_FILE)

            End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            'Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(15, "Start Selecting Data from Excel  File " & MKRSAFX_XLS_FILE)
            'If File.Exists(MKRSAFX_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(MKRSAFX_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("MKRSAFX")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(16, "Select CURRENCY RISK from Cell S13")
            'CURRENCY_RISK = Math.Round(xlWorksheet1.Range("S13").Value / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If

            'SELECT DATA FROM FILE <CROPR.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CROPR_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim CROPR_XLS As String = cmd.ExecuteScalar
            'Dim CROPR_XLS_FILE As String = BAISFileNewDirectory & CROPR_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(17, "Start Selecting Data from Excel  File " & CROPR_XLS_FILE)
            'If File.Exists(CROPR_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(CROPR_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("CROPR")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(18, "Select OPERATIONAL RISK from Cell K12, multiply by 0.08")
            'OPERATIONAL_RISK = Math.Round(xlWorksheet1.Range("K12").Value * 0.08 / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If


            'Only for check reasons
            'MsgBox("[RLDC Date]=" & SqlBAISDate & "[Bank SolvV]=" & Str(SOLVA) & "[Currency risk]=" & Str(CURRENCY_RISK) & "[Dotation capital]=" & Str(DOTATION_CAPITAL) & "[DotationCapitalFull]" & Str(DOTATION_CAPITAL_FULL) & "[Core capital]=" & Str(CORE_CAPITAL) & "[Bank Liquid LV]=" & Str(LIQUID_LV_FULL) & "[Liquid1M3M]=" & Str(LIQUID_LV_1_to_3_MONTHS) & "[Liquid3M6M]=" & Str(LIQUID_LV_3_to_6_MONTHS) & "[Liquid6M12M]=" & Str(LIQUID_LV_6_to_12_MONTHS) & "[Liquidity risk]=" & Str(LIQUIDITY_RISK) & "[Minimum capital requirement]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[Minimum capital requirementSTAGE2]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[LCR_Ratio]=" & Str(LCR_RATIO) & "[Operational risk]=" & Str(OPERATIONAL_RISK) & "[CVA_Risk]=" & Str(CVA_RISK) & "[RiskWeightedExposures]=" & Str(RiskWeightedExposures) & "[MarketRiskPosition]=" & Str(MARKET_RISK) & "[OtherPositionsBAIS]=" & Str(OTHER_POSITIONS) & "[OperationalRiskPosition]=" & Str(OPERATIONAL_RISK_FULL) & "[RetainedEarningsBAIS]=" & Str(RETAINED_EARNING) & "[OtherIntagibleAssetsBAIS]=" & Str(OTHER_INTAGIBLE_ASSETS) & "[OwnCapitalBAIS]=" & Str(EIGENMITTEL_CAPITAL))

            'INSERT DATA in RISK LIMIT DAILY CONTROL
            Me.BgwBAISimport.ReportProgress(50, "Insert selected Data in RISK LIMIT DAILY CONTROL")
            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Currency risk]='" & Str(CURRENCY_RISK) & "',[Bank Liquid LV]='" & Str(LIQUID_LV_FULL) & "',[Liquid1M3M]='" & Str(LIQUID_LV_1_to_3_MONTHS) & "',[Liquid3M6M]='" & Str(LIQUID_LV_3_to_6_MONTHS) & "',[Liquid6M12M]='" & Str(LIQUID_LV_6_to_12_MONTHS) & "',[Liquidity risk]='" & Str(LIQUIDITY_RISK) & "',[LCR_Ratio]='" & Str(LCR_RATIO) & "',[MarketRiskPosition]='" & Str(MARKET_RISK) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                'cmd.ExecuteNonQuery()
            End If
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Currency risk],[Bank Liquid LV],[Liquid1M3M],[Liquid3M6M],[Liquid6M12M],[Liquidity risk],[LCR_Ratio],[MarketRiskPosition],[IdBank]) Values('" & SqlBAISDate & "','" & Str(CURRENCY_RISK) & "','" & Str(LIQUID_LV_FULL) & "','" & Str(LIQUID_LV_1_to_3_MONTHS) & "','" & Str(LIQUID_LV_3_to_6_MONTHS) & "','" & Str(LIQUID_LV_6_to_12_MONTHS) & "','" & Str(LIQUIDITY_RISK) & "','" & Str(LCR_RATIO) & "','" & Str(MARKET_RISK) & "','3')"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                'cmd.ExecuteNonQuery()
            End If


            'Update sums
            Me.BgwBAISimport.ReportProgress(60, "Insert and Update Sums in LCR_Overview")
            cmd.CommandText = "Delete from [LCR_Overview] where [RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [LCR_Overview] ([RiskDate],[LCRDR_LiquidityBuffer],[LCRDR_NetLiquidityOutflow]) Values ('" & SqlBAISDate & "','" & Str(LCRDR_LiquidityBuffer) & "','" & Str(LCRDR_NetLiquidityOutflow) & "')"
            cmd.ExecuteNonQuery()

            'Checkings in BAIS IMPORT
            If CURRENCY_RISK = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CURRENCY RISK is NULL-Please check BAIS Forms!")
            End If
            If LIQUID_LV_FULL = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO is NULL-Please check BAIS Forms!")
            End If
            If LIQUID_LV_1_to_3_MONTHS = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (1 to 3 Months) is NULL-Please check BAIS Forms!")
            End If
            If LIQUID_LV_3_to_6_MONTHS = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (3 to 6 Months) is NULL-Please check BAIS Forms!")
            End If
            If LIQUID_LV_6_to_12_MONTHS = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (6 to 12 Months) is NULL-Please check BAIS Forms!")
            End If
            If LCR_RATIO = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LCR RATIO is NULL-Please check BAIS Forms!")
            End If
            If MARKET_RISK = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - MARKET RISK is NULL-Please check BAIS Forms!")
            End If

            Me.QueryText = "SELECT * FROM [RISK LIMIT DAILY CONTROL] WHERE  [RLDC Date]='" & SqlBAISDate & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Item(0).Item("Dotation capital") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - DOTATION CAPITAL is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OwnCapitalBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OWN CAPITAL is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RetainedEarningsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RETAINED EARNINGS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OtherIntagibleAssetsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OTHER INTAGIBLE ASSETS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RiskWeigthedAmount_Total") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RISK WEIGHTED AMOUNT is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("Operational risk") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OPERATIONAL RISK is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("CVA_Risk") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CREDIT VALUE ADJUSTMENT RISK is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RiskWeightedExposures") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RISK WEIGHTED EXPOSURE is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OtherPositionsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OTHER POSITIONS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("Bank SolvV") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CAPITAL ADEQUACY RATIO is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("CapitalRatio_T1") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CAPITAL RATIO (T1) is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("KapitalerhaltungsPuffer") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - KAPITALERHALTUNGSPUFFER is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("AntizyklischerKapitalPuffer") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - ANTIZYKLISCHER KAPITALPUFFER is NULL-Please check BAIS Forms!")
                End If
            End If


            Me.BgwBAISimport.ReportProgress(60, "Execute Stored Procedure:BAIS_UPDATES_CLIENT_DATA")
            cmd.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
            cmd.ExecuteNonQuery()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub BAIS_IMPORT_PROCEDURES_FROM_01012018()
        Try

            Dim extractorXLS As New XLSExtractor
            Dim extractorCSV As New CSVExtractor

            Dim SOLVA As Double = 0
            Dim CapitalRatio_T1 As Double = 0
            Dim CapitalRatio_Total As Double = 0
            Dim CURRENCY_RISK As Double = 0
            Dim DOTATION_CAPITAL As Double = 0
            Dim DOTATION_CAPITAL_FULL As Double = 0
            Dim CORE_CAPITAL As Double = 0
            Dim EIGENMITTEL_CAPITAL As Double = 0
            'Dim LIQUID_LV_FULL As Double = 0
            'Dim LIQUID_LV_1_to_3_MONTHS As Double = 0
            'Dim LIQUID_LV_3_to_6_MONTHS As Double = 0
            'Dim LIQUID_LV_6_to_12_MONTHS As Double = 0
            Dim LIQUIDITY_RISK As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT_STAGE2 As Double = 0
            Dim OPERATIONAL_RISK As Double = 0
            Dim OPERATIONAL_RISK_FULL As Double = 0
            Dim LCRDR_LiquidityBuffer As Double = 0
            Dim LCRDR_NetLiquidityOutflow As Double = 0
            Dim LCR_RATIO As Double = 0
            Dim CVA_RISK As Double = 0 'Credit Valuation Adjustment Risk
            Dim RiskWeightedExposures As Double = 0
            Dim RiskWeigthedAmount_Total As Double = 0
            Dim MARKET_RISK As Double = 0
            Dim OTHER_POSITIONS As Double = 0
            Dim RETAINED_EARNING As Double = 0
            Dim OTHER_INTAGIBLE_ASSETS As Double = 0
            Dim ANTIZYKLISCHER_KAPITAL_PUFFER As Double = 0
            Dim KAPITALERHALTUNGSPUFFER As Double = 0
            ' Create an instance of a workbook.
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If

            'Dim attributes As FileAttributes

            'WORKBOOK LCRDROUT
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDROUT_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDROUT_XLS As String = cmd.ExecuteScalar
            Dim LCRDROUT_XLS_FILE As String = BAISFileNewDirectory & LCRDROUT_XLS
            If File.Exists(LCRDROUT_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDROUT_XLS_FILE)
                'attributes = File.GetAttributes(LCRDROUT_XLS_FILE)
                'attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)

                workbook.LoadDocument(LCRDROUT_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDROUT_CTOTL")
                Dim bd As Date = worksheet.Cells("H4").Value.TextValue
                'Change File
                worksheet.Rows(0).Visible = True
                worksheet.Columns(0).Visible = True
                'worksheet.Rows(0).Delete()
                'worksheet.Columns(0).Delete()
                'worksheet.UnMergeCells(worksheet.Range("A1:J8"))
                worksheet.DeleteCells(worksheet.Range("A1:J8"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A1:J1"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A115:K115"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Market_Value_collateral_extended"
                worksheet.Cells("G1").Value = "Value_Collateral_Extended_Article_9"
                worksheet.Cells("H1").Value = "Standard_Weight"
                worksheet.Cells("I1").Value = "Applicable_Weight"
                worksheet.Cells("J1").Value = "Outflow"
                workbook.SaveDocument(BAISFileNewDirectory & LCRDROUT_XLS, DocumentFormat.Xls)


                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDROUT_XLS

                cmd.CommandText = "DELETE FROM [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow] FROM [LCRDROUT_CTOTL$]')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "' and [Item] is NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDROUT_XLS_FILE)

            End If

            'WORKBOOK LCRDRIN
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRIN_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRIN_XLS As String = cmd.ExecuteScalar
            Dim LCRDRIN_XLS_FILE As String = BAISFileNewDirectory & LCRDRIN_XLS
            If File.Exists(LCRDRIN_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRIN_XLS_FILE)
                'attributes = File.GetAttributes(LCRDRIN_XLS_FILE)
                'attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)

                workbook.LoadDocument(LCRDRIN_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRIN_CTOTL")
                Dim bd As Date = worksheet.Cells("F4").Value.TextValue
                'Change File

                worksheet.UnMergeCells(worksheet.Range("A1:T9"))
                worksheet.DeleteCells(worksheet.Range("A1:T11"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Amount_1"
                worksheet.Cells("G1").Value = "Amount_2"
                worksheet.Cells("H1").Value = "Market_Value"
                worksheet.Cells("I1").Value = "Market_Value_1"
                worksheet.Cells("J1").Value = "Market_Value_2"
                worksheet.Cells("K1").Value = "Standard_Weight"
                worksheet.Cells("L1").Value = "Applicable_Weight"
                worksheet.Cells("M1").Value = "Applicable_Weight_1"
                worksheet.Cells("N1").Value = "Applicable_Weight_2"
                worksheet.Cells("O1").Value = "ValueCollateralReceived"
                worksheet.Cells("P1").Value = "ValueCollateralReceived_1"
                worksheet.Cells("Q1").Value = "ValueCollateralReceived_2"
                worksheet.Cells("R1").Value = "Inflow"
                worksheet.Cells("S1").Value = "Inflow_1"
                worksheet.Cells("T1").Value = "Inflow_2"

                worksheet.Cells("B46").UnMerge()
                worksheet.DeleteCells(worksheet.Range("A46:T46"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A:A"), DeleteMode.EntireColumn)
                workbook.SaveDocument(BAISFileNewDirectory & LCRDRIN_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRIN_XLS

                cmd.CommandText = "DELETE FROM [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_IN_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2] FROM [LCRDRIN_CTOTL$]')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "' and [Item] is NULL"
                cmd.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRIN_XLS_FILE)

            End If


            'WORKBOOK LCRDRLA
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRLA_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRLA_XLS As String = cmd.ExecuteScalar
            Dim LCRDRLA_XLS_FILE As String = BAISFileNewDirectory & LCRDRLA_XLS
            If File.Exists(LCRDRLA_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRLA_XLS_FILE)
                workbook.LoadDocument(LCRDRLA_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRLA_CTOTL")
                Dim bd As Date = worksheet.Cells("G4").Value.TextValue
                'Change File
                worksheet.Rows(0).Visible = True
                worksheet.Columns(0).Visible = True
                'worksheet.Rows(0).Delete()
                'worksheet.Columns(0).Delete()
                worksheet.UnMergeCells(worksheet.Range("A1:H9"))
                worksheet.DeleteCells(worksheet.Range("A9:H9"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A1:H7"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Standard_Weight"
                worksheet.Cells("G1").Value = "Applicable_Weight"
                worksheet.Cells("H1").Value = "ValueAccArt9"

                worksheet.Cells("B49").UnMerge()
                worksheet.DeleteCells(worksheet.Range("A49:H49"), DeleteMode.ShiftCellsUp)
                workbook.SaveDocument(BAISFileNewDirectory & LCRDRLA_XLS, DocumentFormat.Xls)


                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRLA_XLS

                cmd.CommandText = "DELETE FROM [LCR_LA_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_LA_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[Inflow],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[ValueAccArt9],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[ValueAccArt9] FROM [LCRDRLA_CTOTL$]')"
                cmd.ExecuteNonQuery()
                'MINDESTRESERVE CALCULATION
                Me.BgwBAISimport.ReportProgress(9, "Calculate Minimal Rerserve in Bundesbank ")
                cmd.CommandText = "UPDATE A SET A.[MindestReserveBUBA]=Round(ABS(B.[Total_Balance]) - A.[Inflow],0) from [LCR_LA_BAIS] A INNER JOIN [DailyBalanceDetailsSheets] B on A.RiskDate=B.BSDate where A.RowNr in ('050') and B.[GL_Item] in ('20') and A.[RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRLA_XLS_FILE)
            End If

            'WORKBOOK LCRDRCALC
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim LCRDRCALC_XLS As String = cmd.ExecuteScalar
            'Dim LCRDRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRDRCALC_XLS
            'If File.Exists(LCRDRCALC_XLS_FILE) = True Then
            'workbook.LoadDocument(LCRDRCALC_XLS_FILE, DocumentFormat.Xls)
            'Dim worksheet As Worksheet = workbook.Worksheets("LCRDRCALC_CTOTL")
            'Dim bd As Date = worksheet.Cells("F4").Value.TextValue
            'Change File
            'worksheet.UnMergeCells(worksheet.Range("A1:B11"))
            'worksheet.DeleteCells(worksheet.Range("A1:F8"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A2:F3"), DeleteMode.EntireRow)
            'worksheet.UnMergeCells(worksheet.Range("A1:E42"))
            'Worksheet.Cells("C1").Value = "Row_ID"
            'worksheet.Cells("E1").Value = "Amount"
            'Worksheet.DeleteCells(Worksheet.Range("A5:F5"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A31:F31"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A39:F39"), DeleteMode.EntireRow)
            'workbook.SaveDocument(BAISFileNewDirectory & LCRDRCALC_XLS, DocumentFormat.Xls)
            'Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRCALC_XLS
            'End If


            'SELECT DATA FROM FILE <LCRDRCALC>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRCALC_XLS As String = cmd.ExecuteScalar
            Dim LCRDRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRDRCALC_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCRDRCALC_XLS_FILE)
            If File.Exists(LCRDRCALC_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRCALC_XLS_FILE)
                workbook.LoadDocument(LCRDRCALC_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRCALC_CTOTL")

                Me.BgwBAISimport.ReportProgress(8, "Select LCRDR Liquidity Buffer - Sheet LCRDRCALC_CTOTL from Cell E12")
                LCRDR_LiquidityBuffer = worksheet.Range("E12").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(8, "Select LCRDR Net Liquidty Outflow - Sheet LCRDRCALC_CTOTL from Cell E13")
                LCRDR_NetLiquidityOutflow = worksheet.Range("E13").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(8, "Select LCR RATIO - Sheet LCRDRCALC_CTOTL from Cell E14")
                LCR_RATIO = Math.Round(worksheet.Range("E14").Value.NumericValue / 100, 2)
                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRCALC_XLS_FILE)
            End If



            'SELECT DATA FROM FILE <CA1.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA1_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA1_XLS As String = cmd.ExecuteScalar
            Dim CA1_XLS_FILE As String = BAISFileNewDirectory & CA1_XLS
            If File.Exists(CA1_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & CA1_XLS_FILE)
                workbook.LoadDocument(CA1_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA1")

                'Me.BgwBAISimport.ReportProgress(2, "Select DOTATION CAPITAL,CORE CAPITAL from Cell F12")
                'DOTATION_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                'CORE_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                'DOTATION_CAPITAL_FULL = worksheet.Cells("F12").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(2, "Select EIGENMITTEL CAPITAL from Cell F9 ")
                'EIGENMITTEL_CAPITAL = worksheet.Cells("F9").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(2, "Select RETAINED EARNINGS from Cell F21-F22 and OTHER INTAGIBLE ASSETS from Cell F42-F43 multiply by (-1) ")
                'For i = 8 To 100
                'If worksheet.Cells(i, 3).DisplayText = "Retained earnings" Then
                'RETAINED_EARNING = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "(-) Other intangible assets" Then
                'OTHER_INTAGIBLE_ASSETS = worksheet.Cells(i, 5).Value.NumericValue * (-1)
                'End If
                'Next

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA1_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA1_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA1') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA1' as 'ExcelFile',Rows,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA1$]')"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & CA1_XLS_FILE)

            End If


            'SELECT DATA FROM FILE <CA2.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA2_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA2_XLS As String = cmd.ExecuteScalar
            Dim CA2_XLS_FILE As String = BAISFileNewDirectory & CA2_XLS
            If File.Exists(CA2_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA2_XLS_FILE)
                workbook.LoadDocument(CA2_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA2")

                'Me.BgwBAISimport.ReportProgress(4, "Select Total RISK WEIGHTED AMOUNT from Cell F9")
                'RiskWeigthedAmount_Total = worksheet.Range("F9").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(4, "Select MINIMUM CAPITAL REQUIREMENT from Cell F9 und multiply with 0.08 ,divided by 1000 ")
                'MINIMUM_CAPITAL_REQUIREMENT = Math.Round(worksheet.Range("F9").Value.NumericValue * 0.08 / 1000, 2)
                '--Me.BgwBAISimport.ReportProgress(5, "Select CURRENCY RISK from Cell F59 und multiply with 0.08 ,divided by 1000 ")
                '--CURRENCY_RISK = Math.Round(worksheet.Range("F59").Value.NumericValue * 0.08 / 1000, 0) 'No Data since BAIS 1.23
                '--Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell F59 - Full amount ")
                '--MARKET_RISK = worksheet.Range("F59").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66, multiply by 0.08 ,divided by 1000")
                'OPERATIONAL_RISK = Math.Round(worksheet.Range("F66").Value.NumericValue * 0.08 / 1000, 0)
                'Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66 - Full Amount")
                'OPERATIONAL_RISK_FULL = worksheet.Range("F66").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CREDIT VALUATION ADJUSTMENT RISK (CVA) from Cell F71 ,Full Amount")
                'CVA_RISK = worksheet.Range("F71").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select RISK WEIGHTED EXPOSURES from Cell F12 - Full Amount")
                'RiskWeightedExposures = worksheet.Range("F12").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select OTHER POSITIONS from Cell F30 - Full Amount")
                'OTHER_POSITIONS = worksheet.Range("F30").Value.NumericValue
                '*****************************************

                'For i = 8 To 100
                'If worksheet.Cells(i, 3).DisplayText = "TOTAL RISK EXPOSURE AMOUNT FOR OPERATIONAL RISK (OpR )" Then
                'OPERATIONAL_RISK = Math.Round(worksheet.Cells(i, 5).Value.NumericValue * 0.08 / 1000, 0)
                'OPERATIONAL_RISK_FULL = worksheet.Cells(i, 5).Value.NumericValue
                'MsgBox(OPERATIONAL_RISK)
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "TOTAL RISK EXPOSURE AMOUNT FOR CREDIT VALUATION ADJUSTMENT" Then
                'CVA_RISK = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "RISK WEIGHTED EXPOSURE AMOUNTS FOR CREDIT, COUNTERPARTY CREDIT AND DILUTION RISKS AND FREE DELIVERIES" Then
                'RiskWeightedExposures = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "Other items" Then
                'OTHER_POSITIONS = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'Next

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA2_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA2_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA2') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA2' as 'ExcelFile',Rows,Item,Label,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA2$]')"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA2_XLS_FILE)

            End If


            'SELECT DATA FROM FILE <CA3.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA3_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA3_XLS As String = cmd.ExecuteScalar
            Dim CA3_XLS_FILE As String = BAISFileNewDirectory & CA3_XLS

            If File.Exists(CA3_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA3_XLS_FILE)
                workbook.LoadDocument(CA3_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA3")

                'Me.BgwBAISimport.ReportProgress(6, "Select SOLVA-CAPITAL ADEQUACY RATIO from Cell F13")
                'SOLVA = worksheet.Range("F13").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_T1 (Kernkapital ratio) from Cell F11")
                'CapitalRatio_T1 = worksheet.Range("F11").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_Total (CET1 Capital ratio) from Cell F9")
                'CapitalRatio_Total = worksheet.Range("F9").Value.NumericValue

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA3_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA3_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA3') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA3' as 'ExcelFile',Rows,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA3$]') where Item is not NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA3_XLS_FILE)

            End If

            'SELECT DATA FROM FILE <CA4.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA4_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA4_XLS As String = cmd.ExecuteScalar
            Dim CA4_XLS_FILE As String = BAISFileNewDirectory & CA4_XLS
            Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & CA4_XLS_FILE)
            If File.Exists(CA4_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA4_XLS_FILE)
                workbook.LoadDocument(CA4_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA4")

                'If worksheet.Range("G113").Value.NumericValue > 0 Then
                'Me.BgwBAISimport.ReportProgress(6, "Select Capital conservation buffer from Cell G113")
                'KAPITALERHALTUNGSPUFFER = worksheet.Range("G113").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select Institution specific countercyclical capital buffer from Cell G115")
                'ANTIZYKLISCHER_KAPITAL_PUFFER = worksheet.Range("G115").Value.NumericValue
                'End If


                'Import all File Data
                worksheet.Cells("G8").Value = "Amount"
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA4_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA4_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA4') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA4' as 'ExcelFile',Row,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA4$]') where Item is not NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA4_XLS_FILE)
            End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS

            If File.Exists(MKRSAFX_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & MKRSAFX_XLS)
                workbook.LoadDocument(MKRSAFX_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("MKRSAFX")

                If worksheet.Range("S13").Value.NumericValue <> 0 Then
                    Me.BgwBAISimport.ReportProgress(6, "Select Currency Risk Amount from Cell S13 und multiply with 0.08 ,divided by 1000")
                    CURRENCY_RISK = Math.Round(worksheet.Range("S13").Value.NumericValue * 0.08 / 1000, 0)
                    Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell S13 - Full amount ")
                    MARKET_RISK = worksheet.Range("S13").Value.NumericValue
                End If
                Me.BgwBAISimport.ReportProgress(5, "End Selecting Data from Excel File " & MKRSAFX_XLS)
            End If



            'SELECT DATA FROM FILE <LV2.PDF>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LIQV_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim LIQV_PDF As String = cmd.ExecuteScalar
            'Dim LIQV_PDF_FILE As String = BAISFileNewDirectory & LIQV_PDF
            'If File.Exists(LIQV_PDF_FILE) = True Then
            '    Me.BgwBAISimport.ReportProgress(9, "Start Selecting Data from Pdf File " & LIQV_PDF_FILE)
            '    extractorXLS.LoadDocumentFromFile(LIQV_PDF_FILE)
            '    extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\LV2output.xls")
            '    extractorXLS.Reset() 'Ends extractor and releases the Document


            '    Dim LIQV_XLS_FILE As String = BAISFileNewDirectory & "\LV2output.xls"
            '    Me.BgwBAISimport.ReportProgress(10, "Select from Excel File " & LIQV_XLS_FILE)

            '    workbook.LoadDocument(LIQV_XLS_FILE, DocumentFormat.Xls)
            '    Dim worksheet As Worksheet = workbook.Worksheets("Page 2")


            '    'LIQUID LV
            '    'Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell D23")
            '    'LIQUID_LV_FULL = worksheet.Range("D23").Value.NumericValue
            '    'OTHER LIQUIDITY PERIODS
            '    'Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell E26")
            '    'LIQUID_LV_1_to_3_MONTHS = worksheet.Range("E26").Value.NumericValue
            '    'Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell F26")
            '    'LIQUID_LV_3_to_6_MONTHS = worksheet.Range("F26").Value.NumericValue
            '    'Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell G26")
            '    'LIQUID_LV_6_to_12_MONTHS = worksheet.Range("G26").Value.NumericValue
            '    '*****************************************

            '    'LIQUID LV
            '    Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell F26")
            '    LIQUID_LV_FULL = worksheet.Range("F26").Value.NumericValue
            '    'OTHER LIQUIDITY PERIODS
            '    If worksheet.Range("G30").Value.IsEmpty = False Then
            '        Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell G30")
            '        LIQUID_LV_1_to_3_MONTHS = worksheet.Range("G30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell H30")
            '        LIQUID_LV_3_to_6_MONTHS = worksheet.Range("H30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell I30")
            '        LIQUID_LV_6_to_12_MONTHS = worksheet.Range("I30").Value.NumericValue
            '        '*****************************************
            '    ElseIf worksheet.Range("G30").Value.IsEmpty = True Then
            '        Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell H30")
            '        LIQUID_LV_1_to_3_MONTHS = worksheet.Range("H30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell I30")
            '        LIQUID_LV_3_to_6_MONTHS = worksheet.Range("I30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell J30")
            '        LIQUID_LV_6_to_12_MONTHS = worksheet.Range("J30").Value.NumericValue
            '        '*****************************************
            '    End If


            '    Me.BgwBAISimport.ReportProgress(9, "End Selecting Data from Pdf File " & LIQV_PDF_FILE)

            'End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            'Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(15, "Start Selecting Data from Excel  File " & MKRSAFX_XLS_FILE)
            'If File.Exists(MKRSAFX_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(MKRSAFX_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("MKRSAFX")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(16, "Select CURRENCY RISK from Cell S13")
            'CURRENCY_RISK = Math.Round(xlWorksheet1.Range("S13").Value / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If

            'SELECT DATA FROM FILE <CROPR.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CROPR_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim CROPR_XLS As String = cmd.ExecuteScalar
            'Dim CROPR_XLS_FILE As String = BAISFileNewDirectory & CROPR_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(17, "Start Selecting Data from Excel  File " & CROPR_XLS_FILE)
            'If File.Exists(CROPR_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(CROPR_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("CROPR")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(18, "Select OPERATIONAL RISK from Cell K12, multiply by 0.08")
            'OPERATIONAL_RISK = Math.Round(xlWorksheet1.Range("K12").Value * 0.08 / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If


            'Only for check reasons
            'MsgBox("[RLDC Date]=" & SqlBAISDate & "[Bank SolvV]=" & Str(SOLVA) & "[Currency risk]=" & Str(CURRENCY_RISK) & "[Dotation capital]=" & Str(DOTATION_CAPITAL) & "[DotationCapitalFull]" & Str(DOTATION_CAPITAL_FULL) & "[Core capital]=" & Str(CORE_CAPITAL) & "[Bank Liquid LV]=" & Str(LIQUID_LV_FULL) & "[Liquid1M3M]=" & Str(LIQUID_LV_1_to_3_MONTHS) & "[Liquid3M6M]=" & Str(LIQUID_LV_3_to_6_MONTHS) & "[Liquid6M12M]=" & Str(LIQUID_LV_6_to_12_MONTHS) & "[Liquidity risk]=" & Str(LIQUIDITY_RISK) & "[Minimum capital requirement]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[Minimum capital requirementSTAGE2]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[LCR_Ratio]=" & Str(LCR_RATIO) & "[Operational risk]=" & Str(OPERATIONAL_RISK) & "[CVA_Risk]=" & Str(CVA_RISK) & "[RiskWeightedExposures]=" & Str(RiskWeightedExposures) & "[MarketRiskPosition]=" & Str(MARKET_RISK) & "[OtherPositionsBAIS]=" & Str(OTHER_POSITIONS) & "[OperationalRiskPosition]=" & Str(OPERATIONAL_RISK_FULL) & "[RetainedEarningsBAIS]=" & Str(RETAINED_EARNING) & "[OtherIntagibleAssetsBAIS]=" & Str(OTHER_INTAGIBLE_ASSETS) & "[OwnCapitalBAIS]=" & Str(EIGENMITTEL_CAPITAL))

            'INSERT DATA in RISK LIMIT DAILY CONTROL
            Me.BgwBAISimport.ReportProgress(50, "Insert selected Data in RISK LIMIT DAILY CONTROL")
            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Currency risk]='" & Str(CURRENCY_RISK) & "',[Liquidity risk]='" & Str(LIQUIDITY_RISK) & "',[LCR_Ratio]='" & Str(LCR_RATIO) & "',[MarketRiskPosition]='" & Str(MARKET_RISK) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                'cmd.ExecuteNonQuery()
            End If
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Currency risk],[Liquidity risk],[LCR_Ratio],[MarketRiskPosition],[IdBank]) Values('" & SqlBAISDate & "','" & Str(CURRENCY_RISK) & "','" & Str(LIQUIDITY_RISK) & "','" & Str(LCR_RATIO) & "','" & Str(MARKET_RISK) & "','3')"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                'cmd.ExecuteNonQuery()
            End If


            'Update sums
            Me.BgwBAISimport.ReportProgress(60, "Insert and Update Sums in LCR_Overview")
            cmd.CommandText = "Delete from [LCR_Overview] where [RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [LCR_Overview] ([RiskDate],[LCRDR_LiquidityBuffer],[LCRDR_NetLiquidityOutflow]) Values ('" & SqlBAISDate & "','" & Str(LCRDR_LiquidityBuffer) & "','" & Str(LCRDR_NetLiquidityOutflow) & "')"
            cmd.ExecuteNonQuery()

            'Checkings in BAIS IMPORT
            If CURRENCY_RISK = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CURRENCY RISK is NULL-Please check BAIS Forms!")
            End If
            'If LIQUID_LV_FULL = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO is NULL-Please check BAIS Forms!")
            'End If
            'If LIQUID_LV_1_to_3_MONTHS = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (1 to 3 Months) is NULL-Please check BAIS Forms!")
            'End If
            'If LIQUID_LV_3_to_6_MONTHS = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (3 to 6 Months) is NULL-Please check BAIS Forms!")
            'End If
            'If LIQUID_LV_6_to_12_MONTHS = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (6 to 12 Months) is NULL-Please check BAIS Forms!")
            'End If
            If LCR_RATIO = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LCR RATIO is NULL-Please check BAIS Forms!")
            End If
            If MARKET_RISK = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - MARKET RISK is NULL-Please check BAIS Forms!")
            End If

            Me.QueryText = "SELECT * FROM [RISK LIMIT DAILY CONTROL] WHERE  [RLDC Date]='" & SqlBAISDate & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Item(0).Item("Dotation capital") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - DOTATION CAPITAL is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OwnCapitalBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OWN CAPITAL is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RetainedEarningsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RETAINED EARNINGS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OtherIntagibleAssetsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OTHER INTAGIBLE ASSETS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RiskWeigthedAmount_Total") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RISK WEIGHTED AMOUNT is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("Operational risk") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OPERATIONAL RISK is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("CVA_Risk") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CREDIT VALUE ADJUSTMENT RISK is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RiskWeightedExposures") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RISK WEIGHTED EXPOSURE is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OtherPositionsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OTHER POSITIONS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("Bank SolvV") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CAPITAL ADEQUACY RATIO is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("CapitalRatio_T1") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CAPITAL RATIO (T1) is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("KapitalerhaltungsPuffer") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - KAPITALERHALTUNGSPUFFER is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("AntizyklischerKapitalPuffer") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - ANTIZYKLISCHER KAPITALPUFFER is NULL-Please check BAIS Forms!")
                End If
            End If


            Me.BgwBAISimport.ReportProgress(60, "Execute Stored Procedure:BAIS_UPDATES_CLIENT_DATA")
            cmd.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
            cmd.ExecuteNonQuery()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub BAIS_IMPORT_PROCEDURES_FROM_26003018()
        Try

            Dim extractorXLS As New XLSExtractor
            Dim extractorCSV As New CSVExtractor

            Dim SOLVA As Double = 0
            Dim CapitalRatio_T1 As Double = 0
            Dim CapitalRatio_Total As Double = 0
            Dim CURRENCY_RISK As Double = 0
            Dim DOTATION_CAPITAL As Double = 0
            Dim DOTATION_CAPITAL_FULL As Double = 0
            Dim CORE_CAPITAL As Double = 0
            Dim EIGENMITTEL_CAPITAL As Double = 0
            'Dim LIQUID_LV_FULL As Double = 0
            'Dim LIQUID_LV_1_to_3_MONTHS As Double = 0
            'Dim LIQUID_LV_3_to_6_MONTHS As Double = 0
            'Dim LIQUID_LV_6_to_12_MONTHS As Double = 0
            Dim LIQUIDITY_RISK As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT As Double = 0
            Dim MINIMUM_CAPITAL_REQUIREMENT_STAGE2 As Double = 0
            Dim OPERATIONAL_RISK As Double = 0
            Dim OPERATIONAL_RISK_FULL As Double = 0
            Dim LCRDR_LiquidityBuffer As Double = 0
            Dim LCRDR_NetLiquidityOutflow As Double = 0
            Dim LCR_RATIO As Double = 0
            Dim CVA_RISK As Double = 0 'Credit Valuation Adjustment Risk
            Dim RiskWeightedExposures As Double = 0
            Dim RiskWeigthedAmount_Total As Double = 0
            Dim MARKET_RISK As Double = 0
            Dim OTHER_POSITIONS As Double = 0
            Dim RETAINED_EARNING As Double = 0
            Dim OTHER_INTAGIBLE_ASSETS As Double = 0
            Dim ANTIZYKLISCHER_KAPITAL_PUFFER As Double = 0
            Dim KAPITALERHALTUNGSPUFFER As Double = 0
            ' Create an instance of a workbook.
            Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandTimeout = 50000
            'Dim attributes As FileAttributes

            'WORKBOOK LCRDROUT
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDROUT_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDROUT_XLS As String = cmd.ExecuteScalar
            Dim LCRDROUT_XLS_FILE As String = BAISFileNewDirectory & LCRDROUT_XLS
            If File.Exists(LCRDROUT_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDROUT_XLS_FILE)
                'attributes = File.GetAttributes(LCRDROUT_XLS_FILE)
                'attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)

                workbook.LoadDocument(LCRDROUT_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDROUT_CTOTL")
                Dim bd As Date = worksheet.Cells("H4").Value.TextValue
                'Change File
                worksheet.Rows(0).Visible = True
                worksheet.Columns(0).Visible = True
                'worksheet.Rows(0).Delete()
                'worksheet.Columns(0).Delete()
                'worksheet.UnMergeCells(worksheet.Range("A1:J8"))
                worksheet.DeleteCells(worksheet.Range("A1:J8"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A1:J1"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A115:K115"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Market_Value_collateral_extended"
                worksheet.Cells("G1").Value = "Value_Collateral_Extended_Article_9"
                worksheet.Cells("H1").Value = "Standard_Weight"
                worksheet.Cells("I1").Value = "Applicable_Weight"
                worksheet.Cells("J1").Value = "Outflow"
                workbook.SaveDocument(BAISFileNewDirectory & LCRDROUT_XLS, DocumentFormat.Xls)


                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDROUT_XLS

                cmd.CommandText = "DELETE FROM [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_OUT_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Market_Value_collateral_extended],[Value_Collateral_Extended_Article_9],[Standard_Weight],[Applicable_Weight],[Outflow] FROM [LCRDROUT_CTOTL$]')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [LCR_OUT_BAIS] where [RiskDate]='" & SqlBAISDate & "' and [Item] is NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDROUT_XLS_FILE)

            End If

            'WORKBOOK LCRDRIN
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRIN_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRIN_XLS As String = cmd.ExecuteScalar
            Dim LCRDRIN_XLS_FILE As String = BAISFileNewDirectory & LCRDRIN_XLS
            If File.Exists(LCRDRIN_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRIN_XLS_FILE)
                'attributes = File.GetAttributes(LCRDRIN_XLS_FILE)
                'attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)

                workbook.LoadDocument(LCRDRIN_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRIN_CTOTL")
                Dim bd As Date = worksheet.Cells("F4").Value.TextValue
                'Change File

                worksheet.UnMergeCells(worksheet.Range("A1:T9"))
                worksheet.DeleteCells(worksheet.Range("A1:T11"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Amount_1"
                worksheet.Cells("G1").Value = "Amount_2"
                worksheet.Cells("H1").Value = "Market_Value"
                worksheet.Cells("I1").Value = "Market_Value_1"
                worksheet.Cells("J1").Value = "Market_Value_2"
                worksheet.Cells("K1").Value = "Standard_Weight"
                worksheet.Cells("L1").Value = "Applicable_Weight"
                worksheet.Cells("M1").Value = "Applicable_Weight_1"
                worksheet.Cells("N1").Value = "Applicable_Weight_2"
                worksheet.Cells("O1").Value = "ValueCollateralReceived"
                worksheet.Cells("P1").Value = "ValueCollateralReceived_1"
                worksheet.Cells("Q1").Value = "ValueCollateralReceived_2"
                worksheet.Cells("R1").Value = "Inflow"
                worksheet.Cells("S1").Value = "Inflow_1"
                worksheet.Cells("T1").Value = "Inflow_2"

                worksheet.Cells("B46").UnMerge()
                worksheet.DeleteCells(worksheet.Range("A46:T46"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A:A"), DeleteMode.EntireColumn)
                workbook.SaveDocument(BAISFileNewDirectory & LCRDRIN_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRIN_XLS

                cmd.CommandText = "DELETE FROM [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_IN_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Amount_1],[Amount_2],[Market_Value],[Market_Value_1],[Market_Value_2],[Standard_Weight],[Applicable_Weight],[Applicable_Weight_1],[Applicable_Weight_2],[ValueCollateralReceived],[ValueCollateralReceived_1],[ValueCollateralReceived_2],[Inflow],[Inflow_1],[Inflow_2] FROM [LCRDRIN_CTOTL$]')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [LCR_IN_BAIS] where [RiskDate]='" & SqlBAISDate & "' and [Item] is NULL"
                cmd.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRIN_XLS_FILE)

            End If


            'WORKBOOK LCRDRLA
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRLA_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRLA_XLS As String = cmd.ExecuteScalar
            Dim LCRDRLA_XLS_FILE As String = BAISFileNewDirectory & LCRDRLA_XLS
            If File.Exists(LCRDRLA_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRLA_XLS_FILE)
                workbook.LoadDocument(LCRDRLA_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRLA_CTOTL")
                Dim bd As Date = worksheet.Cells("G4").Value.TextValue
                'Change File
                worksheet.Rows(0).Visible = True
                worksheet.Columns(0).Visible = True
                'worksheet.Rows(0).Delete()
                'worksheet.Columns(0).Delete()
                worksheet.UnMergeCells(worksheet.Range("A1:H9"))
                worksheet.DeleteCells(worksheet.Range("A9:H9"), DeleteMode.ShiftCellsUp)
                worksheet.DeleteCells(worksheet.Range("A1:H7"), DeleteMode.ShiftCellsUp)

                worksheet.Cells("C1").Value = "Row_ID"
                worksheet.Cells("E1").Value = "Amount"
                worksheet.Cells("F1").Value = "Standard_Weight"
                worksheet.Cells("G1").Value = "Applicable_Weight"
                worksheet.Cells("H1").Value = "ValueAccArt9"

                worksheet.Cells("B49").UnMerge()
                worksheet.DeleteCells(worksheet.Range("A49:H49"), DeleteMode.ShiftCellsUp)
                workbook.SaveDocument(BAISFileNewDirectory & LCRDRLA_XLS, DocumentFormat.Xls)


                Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRLA_XLS

                cmd.CommandText = "DELETE FROM [LCR_LA_BAIS] where [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [LCR_LA_BAIS] ([RowNr],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[Inflow],[RiskDate]) SELECT [Row],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[ValueAccArt9],'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Row],[Row_ID],[Item],[Amount],[Standard_Weight],[Applicable_Weight],[ValueAccArt9] FROM [LCRDRLA_CTOTL$]')"
                cmd.ExecuteNonQuery()
                'MINDESTRESERVE CALCULATION
                Me.BgwBAISimport.ReportProgress(9, "Calculate Minimal Rerserve in Bundesbank ")
                cmd.CommandText = "UPDATE A SET A.[MindestReserveBUBA]=Round(ABS(B.[Total_Balance]) - A.[Inflow],0) from [LCR_LA_BAIS] A INNER JOIN [DailyBalanceDetailsSheets] B on A.RiskDate=B.BSDate where A.RowNr in ('050') and B.[GL_Item] in ('20') and A.[RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRLA_XLS_FILE)
            End If

            'WORKBOOK LCRDRCALC
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim LCRDRCALC_XLS As String = cmd.ExecuteScalar
            'Dim LCRDRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRDRCALC_XLS
            'If File.Exists(LCRDRCALC_XLS_FILE) = True Then
            'workbook.LoadDocument(LCRDRCALC_XLS_FILE, DocumentFormat.Xls)
            'Dim worksheet As Worksheet = workbook.Worksheets("LCRDRCALC_CTOTL")
            'Dim bd As Date = worksheet.Cells("F4").Value.TextValue
            'Change File
            'worksheet.UnMergeCells(worksheet.Range("A1:B11"))
            'worksheet.DeleteCells(worksheet.Range("A1:F8"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A2:F3"), DeleteMode.EntireRow)
            'worksheet.UnMergeCells(worksheet.Range("A1:E42"))
            'Worksheet.Cells("C1").Value = "Row_ID"
            'worksheet.Cells("E1").Value = "Amount"
            'Worksheet.DeleteCells(Worksheet.Range("A5:F5"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A31:F31"), DeleteMode.EntireRow)
            'worksheet.DeleteCells(worksheet.Range("A39:F39"), DeleteMode.EntireRow)
            'workbook.SaveDocument(BAISFileNewDirectory & LCRDRCALC_XLS, DocumentFormat.Xls)
            'Dim ExcelFileNameNew As String = BAISFileNewDirectory & LCRDRCALC_XLS
            'End If


            'SELECT DATA FROM FILE <LCRDRCALC>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LCRDRCALC_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim LCRDRCALC_XLS As String = cmd.ExecuteScalar
            Dim LCRDRCALC_XLS_FILE As String = BAISFileNewDirectory & LCRDRCALC_XLS
            Me.BgwBAISimport.ReportProgress(7, "Start Selecting Data from Excel File " & LCRDRCALC_XLS_FILE)
            If File.Exists(LCRDRCALC_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & LCRDRCALC_XLS_FILE)
                workbook.LoadDocument(LCRDRCALC_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("LCRDRCALC_CTOTL")

                Me.BgwBAISimport.ReportProgress(8, "Select LCRDR Liquidity Buffer - Sheet LCRDRCALC_CTOTL from Cell E12")
                LCRDR_LiquidityBuffer = worksheet.Range("E12").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(8, "Select LCRDR Net Liquidty Outflow - Sheet LCRDRCALC_CTOTL from Cell E13")
                LCRDR_NetLiquidityOutflow = worksheet.Range("E13").Value.NumericValue
                Me.BgwBAISimport.ReportProgress(8, "Select LCR RATIO - Sheet LCRDRCALC_CTOTL from Cell E14")
                LCR_RATIO = Math.Round(worksheet.Range("E14").Value.NumericValue / 100, 2)
                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & LCRDRCALC_XLS_FILE)
            End If



            'SELECT DATA FROM FILE <CA1.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA1_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA1_XLS As String = cmd.ExecuteScalar
            Dim CA1_XLS_FILE As String = BAISFileNewDirectory & CA1_XLS
            If File.Exists(CA1_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(7, "Start Selecting and importing Data from Excel File " & CA1_XLS_FILE)
                workbook.LoadDocument(CA1_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA1")

                'Me.BgwBAISimport.ReportProgress(2, "Select DOTATION CAPITAL,CORE CAPITAL from Cell F12")
                'DOTATION_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                'CORE_CAPITAL = Math.Round(worksheet.Cells("F12").Value.NumericValue / 1000, 0)
                'DOTATION_CAPITAL_FULL = worksheet.Cells("F12").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(2, "Select EIGENMITTEL CAPITAL from Cell F9 ")
                'EIGENMITTEL_CAPITAL = worksheet.Cells("F9").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(2, "Select RETAINED EARNINGS from Cell F21-F22 and OTHER INTAGIBLE ASSETS from Cell F42-F43 multiply by (-1) ")
                'For i = 8 To 100
                'If worksheet.Cells(i, 3).DisplayText = "Retained earnings" Then
                'RETAINED_EARNING = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "(-) Other intangible assets" Then
                'OTHER_INTAGIBLE_ASSETS = worksheet.Cells(i, 5).Value.NumericValue * (-1)
                'End If
                'Next

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA1_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA1_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA1') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA1' as 'ExcelFile',Rows,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA1$]')"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(7, "End Selecting and importing Data from Excel File " & CA1_XLS_FILE)

            End If


            'SELECT DATA FROM FILE <CA2.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA2_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA2_XLS As String = cmd.ExecuteScalar
            Dim CA2_XLS_FILE As String = BAISFileNewDirectory & CA2_XLS
            If File.Exists(CA2_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA2_XLS_FILE)
                workbook.LoadDocument(CA2_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA2")

                'Me.BgwBAISimport.ReportProgress(4, "Select Total RISK WEIGHTED AMOUNT from Cell F9")
                'RiskWeigthedAmount_Total = worksheet.Range("F9").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(4, "Select MINIMUM CAPITAL REQUIREMENT from Cell F9 und multiply with 0.08 ,divided by 1000 ")
                'MINIMUM_CAPITAL_REQUIREMENT = Math.Round(worksheet.Range("F9").Value.NumericValue * 0.08 / 1000, 2)
                '--Me.BgwBAISimport.ReportProgress(5, "Select CURRENCY RISK from Cell F59 und multiply with 0.08 ,divided by 1000 ")
                '--CURRENCY_RISK = Math.Round(worksheet.Range("F59").Value.NumericValue * 0.08 / 1000, 0) 'No Data since BAIS 1.23
                '--Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell F59 - Full amount ")
                '--MARKET_RISK = worksheet.Range("F59").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66, multiply by 0.08 ,divided by 1000")
                'OPERATIONAL_RISK = Math.Round(worksheet.Range("F66").Value.NumericValue * 0.08 / 1000, 0)
                'Me.BgwBAISimport.ReportProgress(6, "Select OPERATIONAL RISK from Cell F66 - Full Amount")
                'OPERATIONAL_RISK_FULL = worksheet.Range("F66").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CREDIT VALUATION ADJUSTMENT RISK (CVA) from Cell F71 ,Full Amount")
                'CVA_RISK = worksheet.Range("F71").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select RISK WEIGHTED EXPOSURES from Cell F12 - Full Amount")
                'RiskWeightedExposures = worksheet.Range("F12").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select OTHER POSITIONS from Cell F30 - Full Amount")
                'OTHER_POSITIONS = worksheet.Range("F30").Value.NumericValue
                '*****************************************

                'For i = 8 To 100
                'If worksheet.Cells(i, 3).DisplayText = "TOTAL RISK EXPOSURE AMOUNT FOR OPERATIONAL RISK (OpR )" Then
                'OPERATIONAL_RISK = Math.Round(worksheet.Cells(i, 5).Value.NumericValue * 0.08 / 1000, 0)
                'OPERATIONAL_RISK_FULL = worksheet.Cells(i, 5).Value.NumericValue
                'MsgBox(OPERATIONAL_RISK)
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "TOTAL RISK EXPOSURE AMOUNT FOR CREDIT VALUATION ADJUSTMENT" Then
                'CVA_RISK = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "RISK WEIGHTED EXPOSURE AMOUNTS FOR CREDIT, COUNTERPARTY CREDIT AND DILUTION RISKS AND FREE DELIVERIES" Then
                'RiskWeightedExposures = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'If worksheet.Cells(i, 3).DisplayText = "Other items" Then
                'OTHER_POSITIONS = worksheet.Cells(i, 5).Value.NumericValue
                'End If
                'Next

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA2_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA2_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA2') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA2' as 'ExcelFile',Rows,Item,Label,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA2$]')"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA2_XLS_FILE)

            End If


            'SELECT DATA FROM FILE <CA3.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA3_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA3_XLS As String = cmd.ExecuteScalar
            Dim CA3_XLS_FILE As String = BAISFileNewDirectory & CA3_XLS

            If File.Exists(CA3_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA3_XLS_FILE)
                workbook.LoadDocument(CA3_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA3")

                'Me.BgwBAISimport.ReportProgress(6, "Select SOLVA-CAPITAL ADEQUACY RATIO from Cell F13")
                'SOLVA = worksheet.Range("F13").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_T1 (Kernkapital ratio) from Cell F11")
                'CapitalRatio_T1 = worksheet.Range("F11").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select CapitalRatio_Total (CET1 Capital ratio) from Cell F9")
                'CapitalRatio_Total = worksheet.Range("F9").Value.NumericValue

                'Import all File Data
                worksheet.DeleteCells(worksheet.Range("A1:G7"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA3_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA3_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA3') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA3' as 'ExcelFile',Rows,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA3$]') where Item is not NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA3_XLS_FILE)

            End If

            'SELECT DATA FROM FILE <CA4.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CA4_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim CA4_XLS As String = cmd.ExecuteScalar
            Dim CA4_XLS_FILE As String = BAISFileNewDirectory & CA4_XLS
            Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & CA4_XLS_FILE)
            If File.Exists(CA4_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(3, "Start Selecting and Importing Data from Excel File " & CA4_XLS_FILE)
                workbook.LoadDocument(CA4_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("CA4")

                'If worksheet.Range("G113").Value.NumericValue > 0 Then
                'Me.BgwBAISimport.ReportProgress(6, "Select Capital conservation buffer from Cell G113")
                'KAPITALERHALTUNGSPUFFER = worksheet.Range("G113").Value.NumericValue
                'Me.BgwBAISimport.ReportProgress(6, "Select Institution specific countercyclical capital buffer from Cell G115")
                'ANTIZYKLISCHER_KAPITAL_PUFFER = worksheet.Range("G115").Value.NumericValue
                'End If


                'Import all File Data
                worksheet.Cells("G9").Value = "Amount"
                worksheet.DeleteCells(worksheet.Range("A1:G8"), DeleteMode.ShiftCellsUp)
                worksheet.Columns(0).Delete()
                workbook.SaveDocument(BAISFileNewDirectory & CA4_XLS, DocumentFormat.Xls)

                Dim ExcelFileNameNew As String = BAISFileNewDirectory & CA4_XLS

                cmd.CommandText = "DELETE FROM [CA_BAIS_DATA] where [BAIS_CA_File] in ('CA4') and [RiskDate]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [CA_BAIS_DATA]([BAIS_CA_File],[RowsID],[ID_ID],[Item],[Amount],[RiskDate]) SELECT 'CA4' as 'ExcelFile',Row,ID,Item,'Amount'=Case when Amount is not NULL then Amount else 0 end,'" & SqlBAISDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [CA4$]') where Item is not NULL"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(3, "End Selecting and Importing Data from Excel File " & CA4_XLS_FILE)
            End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS

            If File.Exists(MKRSAFX_XLS_FILE) = True Then
                Me.BgwBAISimport.ReportProgress(5, "Start Selecting Data from Excel File " & MKRSAFX_XLS)
                workbook.LoadDocument(MKRSAFX_XLS_FILE, DocumentFormat.Xls)
                Dim worksheet As Worksheet = workbook.Worksheets("MKRSAFX")

                If worksheet.Range("S13").Value.NumericValue <> 0 Then
                    Me.BgwBAISimport.ReportProgress(6, "Select Currency Risk Amount from Cell S13 und multiply with 0.08 ,divided by 1000")
                    CURRENCY_RISK = Math.Round(worksheet.Range("S13").Value.NumericValue * 0.08 / 1000, 0)
                    Me.BgwBAISimport.ReportProgress(5, "Select MARKET RISK from Cell S13 - Full amount ")
                    MARKET_RISK = worksheet.Range("S13").Value.NumericValue
                End If
                Me.BgwBAISimport.ReportProgress(5, "End Selecting Data from Excel File " & MKRSAFX_XLS)
            End If


            'Select Data from BISTA - H Formular
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_BISTA_H_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim BISTA_H_PDF As String = cmd.ExecuteScalar
            'Dim BISTA_H_PDF_FILE As String = BAISFileNewDirectory & BISTA_H_PDF
            'If File.Exists(BISTA_H_PDF_FILE) = True Then
            '    Me.BgwBAISimport.ReportProgress(9, "Start Selecting Data from Pdf File " & BISTA_H_PDF_FILE)
            '    extractorXLS.LoadDocumentFromFile(BISTA_H_PDF_FILE)
            '    extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\BISTA_H_output.xls")
            '    extractorXLS.Reset() 'Ends extractor and releases the Document

            '    Dim BISTA_H_XLS_FILE As String = BAISFileNewDirectory & "\BISTA_H_output.xls"
            '    workbook.LoadDocument(BISTA_H_XLS_FILE, DocumentFormat.Xls)
            '    Dim worksheet As Worksheet = workbook.Worksheets("Page 2")
            '    worksheet.ClearContents(worksheet("A1:X1"))
            '    workbook.SaveDocument(BISTA_H_XLS_FILE, DocumentFormat.Xls)
            '    'MINDESTRESERVE CALCULATION
            '    Me.BgwBAISimport.ReportProgress(9, "Update Minimal Bundesbank Rerserve from BAIS BISTA Form:H-Blatt2-Zeile 280")
            '    cmd.CommandText = "UPDATE [LCR_LA_BAIS] SET [MindestReserveBUBA]=(SELECT CONVERT(float,REPLACE(F10,'.','')) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & BISTA_H_XLS_FILE & ";','SELECT * FROM [Page 2$]') where F9 in ('280')) where RowNr in ('050') and [RiskDate]='" & SqlBAISDate & "'"
            '    cmd.ExecuteNonQuery()

            '    Me.BgwBAISimport.ReportProgress(5, "End Selecting Data from Excel File " & BISTA_H_PDF_FILE)

            'End If


            'SELECT DATA FROM FILE <LV2.PDF>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_LIQV_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim LIQV_PDF As String = cmd.ExecuteScalar
            'Dim LIQV_PDF_FILE As String = BAISFileNewDirectory & LIQV_PDF
            'If File.Exists(LIQV_PDF_FILE) = True Then
            '    Me.BgwBAISimport.ReportProgress(9, "Start Selecting Data from Pdf File " & LIQV_PDF_FILE)
            '    extractorXLS.LoadDocumentFromFile(LIQV_PDF_FILE)
            '    extractorXLS.SaveToXLSFile(BAISFileNewDirectory & "\LV2output.xls")
            '    extractorXLS.Reset() 'Ends extractor and releases the Document


            '    Dim LIQV_XLS_FILE As String = BAISFileNewDirectory & "\LV2output.xls"
            '    Me.BgwBAISimport.ReportProgress(10, "Select from Excel File " & LIQV_XLS_FILE)

            '    workbook.LoadDocument(LIQV_XLS_FILE, DocumentFormat.Xls)
            '    Dim worksheet As Worksheet = workbook.Worksheets("Page 2")


            '    'LIQUID LV
            '    'Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell D23")
            '    'LIQUID_LV_FULL = worksheet.Range("D23").Value.NumericValue
            '    'OTHER LIQUIDITY PERIODS
            '    'Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell E26")
            '    'LIQUID_LV_1_to_3_MONTHS = worksheet.Range("E26").Value.NumericValue
            '    'Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell F26")
            '    'LIQUID_LV_3_to_6_MONTHS = worksheet.Range("F26").Value.NumericValue
            '    'Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell G26")
            '    'LIQUID_LV_6_to_12_MONTHS = worksheet.Range("G26").Value.NumericValue
            '    '*****************************************

            '    'LIQUID LV
            '    Me.BgwBAISimport.ReportProgress(11, "Select BANK LIQUIDITY from Page2-Cell F26")
            '    LIQUID_LV_FULL = worksheet.Range("F26").Value.NumericValue
            '    'OTHER LIQUIDITY PERIODS
            '    If worksheet.Range("G30").Value.IsEmpty = False Then
            '        Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell G30")
            '        LIQUID_LV_1_to_3_MONTHS = worksheet.Range("G30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell H30")
            '        LIQUID_LV_3_to_6_MONTHS = worksheet.Range("H30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell I30")
            '        LIQUID_LV_6_to_12_MONTHS = worksheet.Range("I30").Value.NumericValue
            '        '*****************************************
            '    ElseIf worksheet.Range("G30").Value.IsEmpty = True Then
            '        Me.BgwBAISimport.ReportProgress(12, "Select LIQUIDITY 1 to 3 Months from Page2-Cell H30")
            '        LIQUID_LV_1_to_3_MONTHS = worksheet.Range("H30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(13, "Select LIQUIDITY 3 to 6 Months from Page2-Cell I30")
            '        LIQUID_LV_3_to_6_MONTHS = worksheet.Range("I30").Value.NumericValue
            '        Me.BgwBAISimport.ReportProgress(14, "Select LIQUIDITY 6 to 12 Months from Page2-Cell J30")
            '        LIQUID_LV_6_to_12_MONTHS = worksheet.Range("J30").Value.NumericValue
            '        '*****************************************
            '    End If


            '    Me.BgwBAISimport.ReportProgress(9, "End Selecting Data from Pdf File " & LIQV_PDF_FILE)

            'End If

            'SELECT DATA FROM FILE <MKRSAFX.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_MKRSAFX_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim MKRSAFX_XLS As String = cmd.ExecuteScalar
            'Dim MKRSAFX_XLS_FILE As String = BAISFileNewDirectory & MKRSAFX_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(15, "Start Selecting Data from Excel  File " & MKRSAFX_XLS_FILE)
            'If File.Exists(MKRSAFX_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(MKRSAFX_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("MKRSAFX")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(16, "Select CURRENCY RISK from Cell S13")
            'CURRENCY_RISK = Math.Round(xlWorksheet1.Range("S13").Value / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If

            'SELECT DATA FROM FILE <CROPR.XLS>
            'cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CROPR_FILE_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
            'Dim CROPR_XLS As String = cmd.ExecuteScalar
            'Dim CROPR_XLS_FILE As String = BAISFileNewDirectory & CROPR_XLS
            'MsgBox(EOPR_XLS & "   " & EOPR_XLS_FILE)
            'Me.BgwBAISimport.ReportProgress(17, "Start Selecting Data from Excel  File " & CROPR_XLS_FILE)
            'If File.Exists(CROPR_XLS_FILE) = True Then
            'Excel Datei Öffnen und Datenformat ändern
            'EXCELL = CreateObject("Excel.Application")
            'xlWorkBook = EXCELL.Workbooks.Open(CROPR_XLS_FILE)
            'xlWorksheet1 = xlWorkBook.Worksheets("CROPR")
            'EXCELL.Visible = False
            'Me.BgwBAISimport.ReportProgress(18, "Select OPERATIONAL RISK from Cell K12, multiply by 0.08")
            'OPERATIONAL_RISK = Math.Round(xlWorksheet1.Range("K12").Value * 0.08 / 1000, 0)

            '*****************************************
            'Excel beenden
            'EXCELL.DisplayAlerts = False
            'xlWorkBook.Close(False)
            'xlWorkBook = Nothing
            'EXCELL.DisplayAlerts = True
            'EXCELL.Quit()
            'EXCELL = Nothing
            'Excel Instanz beenden
            'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
            'Dim i1 As Short
            'i1 = 0
            'For i1 = 0 To (procs.Length - 1)
            'procs(i1).Kill()
            'Next i1
            '********************************************
            'End If


            'Only for check reasons
            'MsgBox("[RLDC Date]=" & SqlBAISDate & "[Bank SolvV]=" & Str(SOLVA) & "[Currency risk]=" & Str(CURRENCY_RISK) & "[Dotation capital]=" & Str(DOTATION_CAPITAL) & "[DotationCapitalFull]" & Str(DOTATION_CAPITAL_FULL) & "[Core capital]=" & Str(CORE_CAPITAL) & "[Bank Liquid LV]=" & Str(LIQUID_LV_FULL) & "[Liquid1M3M]=" & Str(LIQUID_LV_1_to_3_MONTHS) & "[Liquid3M6M]=" & Str(LIQUID_LV_3_to_6_MONTHS) & "[Liquid6M12M]=" & Str(LIQUID_LV_6_to_12_MONTHS) & "[Liquidity risk]=" & Str(LIQUIDITY_RISK) & "[Minimum capital requirement]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[Minimum capital requirementSTAGE2]=" & Str(MINIMUM_CAPITAL_REQUIREMENT) & "[LCR_Ratio]=" & Str(LCR_RATIO) & "[Operational risk]=" & Str(OPERATIONAL_RISK) & "[CVA_Risk]=" & Str(CVA_RISK) & "[RiskWeightedExposures]=" & Str(RiskWeightedExposures) & "[MarketRiskPosition]=" & Str(MARKET_RISK) & "[OtherPositionsBAIS]=" & Str(OTHER_POSITIONS) & "[OperationalRiskPosition]=" & Str(OPERATIONAL_RISK_FULL) & "[RetainedEarningsBAIS]=" & Str(RETAINED_EARNING) & "[OtherIntagibleAssetsBAIS]=" & Str(OTHER_INTAGIBLE_ASSETS) & "[OwnCapitalBAIS]=" & Str(EIGENMITTEL_CAPITAL))

            'INSERT DATA in RISK LIMIT DAILY CONTROL
            Me.BgwBAISimport.ReportProgress(50, "Insert selected Data in RISK LIMIT DAILY CONTROL")
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & SqlBAISDate & "'"
            Dim t As String = cmd.ExecuteScalar
            If IsNothing(t) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Currency risk]='" & Str(CURRENCY_RISK) & "',[Liquidity risk]='" & Str(LIQUIDITY_RISK) & "',[LCR_Ratio]='" & Str(LCR_RATIO) & "',[MarketRiskPosition]='" & Str(MARKET_RISK) & "' WHERE [RLDC Date]='" & SqlBAISDate & "'"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                'cmd.ExecuteNonQuery()
            End If
            If IsNothing(t) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Currency risk],[Liquidity risk],[LCR_Ratio],[MarketRiskPosition],[IdBank]) Values('" & SqlBAISDate & "','" & Str(CURRENCY_RISK) & "','" & Str(LIQUIDITY_RISK) & "','" & Str(LCR_RATIO) & "','" & Str(MARKET_RISK) & "','3')"
                cmd.ExecuteNonQuery()
                'cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] set [CapitalForSolvV]=[DotationCapitalFull]+[RetainedEarningsBAIS]-[OtherIntagibleAssetsBAIS] where [DotationCapitalFull] is not NULL and [RLDC Date]='" & SqlBAISDate & "'"
                'cmd.ExecuteNonQuery()
            End If


            'Update sums
            Me.BgwBAISimport.ReportProgress(60, "Insert and Update Sums in LCR_Overview")
            cmd.CommandText = "Delete from [LCR_Overview] where [RiskDate]='" & SqlBAISDate & "'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "INSERT INTO [LCR_Overview] ([RiskDate],[LCRDR_LiquidityBuffer],[LCRDR_NetLiquidityOutflow]) Values ('" & SqlBAISDate & "','" & Str(LCRDR_LiquidityBuffer) & "','" & Str(LCRDR_NetLiquidityOutflow) & "')"
            cmd.ExecuteNonQuery()

            'Checkings in BAIS IMPORT
            If CURRENCY_RISK = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CURRENCY RISK is NULL-Please check BAIS Forms!")
            End If
            'If LIQUID_LV_FULL = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO is NULL-Please check BAIS Forms!")
            'End If
            'If LIQUID_LV_1_to_3_MONTHS = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (1 to 3 Months) is NULL-Please check BAIS Forms!")
            'End If
            'If LIQUID_LV_3_to_6_MONTHS = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (3 to 6 Months) is NULL-Please check BAIS Forms!")
            'End If
            'If LIQUID_LV_6_to_12_MONTHS = 0 Then
            '    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LIQUIDITY RATIO (6 to 12 Months) is NULL-Please check BAIS Forms!")
            'End If
            If LCR_RATIO = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - LCR RATIO is NULL-Please check BAIS Forms!")
            End If
            If MARKET_RISK = 0 Then
                Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - MARKET RISK is NULL-Please check BAIS Forms!")
            End If

            Me.QueryText = "SELECT * FROM [RISK LIMIT DAILY CONTROL] WHERE  [RLDC Date]='" & SqlBAISDate & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If dt.Rows.Item(0).Item("Dotation capital") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - DOTATION CAPITAL is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OwnCapitalBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OWN CAPITAL is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RetainedEarningsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RETAINED EARNINGS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OtherIntagibleAssetsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OTHER INTAGIBLE ASSETS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RiskWeigthedAmount_Total") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RISK WEIGHTED AMOUNT is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("Operational risk") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OPERATIONAL RISK is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("CVA_Risk") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CREDIT VALUE ADJUSTMENT RISK is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("RiskWeightedExposures") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - RISK WEIGHTED EXPOSURE is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("OtherPositionsBAIS") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - OTHER POSITIONS is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("Bank SolvV") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CAPITAL ADEQUACY RATIO is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("CapitalRatio_T1") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - CAPITAL RATIO (T1) is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("KapitalerhaltungsPuffer") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - KAPITALERHALTUNGSPUFFER is NULL-Please check BAIS Forms!")
                End If
                If dt.Rows.Item(0).Item("AntizyklischerKapitalPuffer") = 0 Then
                    Me.BgwBAISimport.ReportProgress(0, "ERROR+++ BAIS - ANTIZYKLISCHER KAPITALPUFFER is NULL-Please check BAIS Forms!")
                End If
            End If


            'Me.BgwBAISimport.ReportProgress(60, "Execute Stored Procedure:BAIS_UPDATES_CLIENT_DATA")
            'cmd.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
            'cmd.ExecuteNonQuery()

            Me.BgwBAISimport.ReportProgress(3, "Execute BAIS_UPDATES_CLIENT_DATA commands in SQL Procedures Parameter/BAIS ")
            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('BAIS_UPDATES_CLIENT_DATA')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            For i = 0 To dt.Rows.Count - 1
                Dim SqlCommandText As String = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", SqlBAISDate)
                cmd.CommandText = SqlCommandText
                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                    BgwBAISimport.ReportProgress(3, "Execute: " & dt.Rows.Item(i).Item("SQL_Name_1"))
                    cmd.ExecuteNonQuery()
                End If
            Next

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

        Catch ex As Exception
            Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Public Shared Function RemoveAttribute(ByVal attributes As FileAttributes, ByVal attributesToRemove As FileAttributes) As FileAttributes
        Return attributes And (Not attributesToRemove)
    End Function

End Class