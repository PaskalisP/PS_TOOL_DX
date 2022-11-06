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
Imports DevExpress.Compression
Imports Ionic.Zip
'Imports System.IO.Compression
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports ICSharpCode.SharpZipLib.Tar



Public Class BaisInterfaceImport

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""
    Dim pathToZipArchive As String = Nothing
    Dim dir_BaisFiles As New List(Of String)
   
    Dim BAISDirectory As String = "" 'BAIS FILE DIRECTORY
    Dim BAISFileNewDirectory As String = "" 'NEW DIRECTORY FOR BAIS FILE
    Dim BAISInterfaceFileTemplate As String = Nothing

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
    Public Sub PROGRESS_BAIS_MAX5()
        Me.BAISProgressBar.Maximum = 5000
    End Sub

    'Show Progress in a  Excel File with 10000 Rows
    Public Sub PROGRESS_BAIS_MAX10()
        Me.BAISProgressBar.Maximum = 10000
    End Sub

    'Show Progress in a  Excel File-Progress Bar
    Public Sub PROGRESS_BAIS_EXCEL()
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
            If MessageBox.Show("Should the BAIS Interface File Nr. " & LastBaisImportFile.Text & " be saved as Last Imported BAIS Interface file", "CHANGE THE LAST IMPORTED BAIS INTERFACE FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim LastBAISINTERFACEImportFile As Double = Me.LastBaisImportFile.Text
                Me.FILES_IMPORTBindingSource.EndEdit()
                Me.FILES_IMPORTTableAdapter.UpdateBAIS_LastImportFile(LastBAISINTERFACEImportFile)
                Me.FILES_IMPORTTableAdapter.FillByBAIS(Me.EDPDataSet.FILES_IMPORT)
            Else
                Me.FILES_IMPORTBindingSource.CancelEdit()
                Exit Sub
            End If
        Else
            MessageBox.Show("The indicated BAIS Interface Filename is not correct!", "BAIS Interface FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub

        End If
    End Sub

    Private Sub LastBaisImportFile_Leave(sender As Object, e As EventArgs) Handles LastBaisImportFile.Leave
        If IsNumeric(LastBaisImportFile.Text) = False OrElse Len(LastBaisImportFile.Text) <> 8 Then
            MessageBox.Show("The indicated BAIS Interface Filename is not correct!", "BAIS INTERFACE FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub
        End If
    End Sub
    Private Sub SelectedBaisImportFile_Leave(sender As Object, e As EventArgs) Handles SelectedBaisImportFile.Leave
        If Me.SelectedBaisImportFile.Text <> "" Then
            If IsNumeric(SelectedBaisImportFile.Text) = False OrElse Len(SelectedBaisImportFile.Text) <> 8 Then
                MessageBox.Show("The indicated BAIS Interface Filename is not correct!", "BAIS INTERFACE FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.SelectedBaisImportFile.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OcbsImportFileFrom_Leave(sender As Object, e As EventArgs) Handles BaisImportFileFrom.Leave
        If Me.BaisImportFileFrom.Text <> "" Then
            If IsNumeric(BaisImportFileFrom.Text) = False OrElse Len(BaisImportFileFrom.Text) <> 8 Then
                MessageBox.Show("The indicated BAIS Interface Filename is not correct!", "BAIS INTERFACE FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.BaisImportFileFrom.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub BaisImportFileTill_Leave(sender As Object, e As EventArgs) Handles BaisImportFileTill.Leave
        If Me.BaisImportFileTill.Text <> "" Then
            If IsNumeric(BaisImportFileTill.Text) = False OrElse Len(BaisImportFileTill.Text) <> 8 Then
                MessageBox.Show("The indicated BAIS Interface Filename is not correct!", "BAIS INTERFACE FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            If MessageBox.Show("Should the automated BAIS Interface Fileimport be executed?", "AUTOMATED IMPORT BAIS INTERFACE FILES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
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
            If MessageBox.Show("Should the BAIS Interface Filename " & SelectedBaisImportFile.Text & " be imported?", "IMPORT BAIS INTERFACE FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
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
                If MessageBox.Show("Should the BAIS Interface Import start with Filename " & n1 & " and finish with Filename " & n2, "IMPORT BAIS INTERFACE FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
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


    Public Sub ExtractTGZ(ByVal gzArchiveName As String, ByVal destFolder As String)

        Dim inStream As Stream = File.OpenRead(gzArchiveName)
        Dim gzipStream As Stream = New GZipInputStream(inStream)

        Dim tarArchive As TarArchive = TarArchive.CreateInputTarArchive(gzipStream)
        tarArchive.ExtractContents(destFolder)
        tarArchive.Close()

        gzipStream.Close()
        inStream.Close()
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

                If cmdBAIS.Connection.State = ConnectionState.Closed Then
                    cmdBAIS.Connection.Open()
                End If

                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISFileNewDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_FILE_TEMPLATE' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISInterfaceFileTemplate = cmdBAIS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAIS Interface Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BAIS_INTERFACE_FILES' AND xtype='U') CREATE TABLE [BAIS_INTERFACE_FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[FileNameNumber] [float] NULL,[FileNameText] [nvarchar](255) NULL,[FileFullName] [nvarchar](255) NULL) ELSE DELETE FROM [BAIS_INTERFACE_FILES] "
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: #Temp_BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_INTERFACE_FILES' AND xtype='U') CREATE TABLE [#Temp_BAIS_INTERFACE_FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[subdirectory] [nvarchar](255) NULL,[depth] float,[file] float NULL) ELSE DELETE FROM [#Temp_BAIS_INTERFACE_FILES] "
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAIS Files in Table: #Temp_BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "INSERT [#Temp_BAIS_INTERFACE_FILES] ([subdirectory],[depth],[file]) EXEC master..xp_dirtree '" & BAISDirectory & "',10,1"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAIS Files in Table: BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "INSERT INTO [BAIS_INTERFACE_FILES] (FileNameText) Select [subdirectory] from #Temp_BAIS_INTERFACE_FILES"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "DROP Table: #Temp_BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "DROP TABLE #Temp_BAIS_INTERFACE_FILES"
                cmdBAIS.ExecuteNonQuery()
                
                Me.BgwBAISimport.ReportProgress(33, "Update FileNameNumber and FileFullName in BAIS FILES")
                cmdBAIS.CommandText = "UPDATE [BAIS_INTERFACE_FILES] SET [FileNameNumber]= CASE WHEN ISNUMERIC(SUBSTRING([FileNameText],20,8))=1 THEN CAST(SUBSTRING([FileNameText],20,8) as float) else 0 end,[FileFullName]='" & BAISDirectory & "' + [FileNameText]"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(40, "Delete from BAIS FILES where FileNameNumber=0")
                cmdBAIS.CommandText = "DELETE from [BAIS_INTERFACE_FILES] where [FileNameNumber]=0"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(45, "Delete from Table: BAIS FILES where FileNameNumber < Last BAIS Import File: " & Me.LastBaisImportFile.Text)
                cmdBAIS.CommandText = "DELETE FROM [BAIS_INTERFACE_FILES] where [FileNameNumber]<'" & Me.LastBaisImportFile.Text & "'"
                cmdBAIS.ExecuteNonQuery()


                Me.QueryText = "SELECT [FileNameNumber],[FileFullName]  FROM [BAIS_INTERFACE_FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwBAISimport.ReportProgress(50, "Determine the next BAIS File for Import...Please wait...")

                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileNameNumber] as NextFileNameforimport,[FileFullName] as NextFileFullName,[FileNameText] as 'OriginalFileName' from [BAIS_INTERFACE_FILES] where [FileNameNumber] in (SELECT min([FileNameNumber])FROM [BAIS_INTERFACE_FILES] where [FileNameNumber]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('BAIS')))"
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
                            Dim BAISFileCopyNewDirectory As String = dt1.Rows.Item(0).Item("OriginalFileName")

                            'Löschen der Daten in BAIS Files
                            Me.BgwBAISimport.ReportProgress(60, "Delete from BAIS FILES the File: " & CBAIF)
                            cmdBAIS.CommandText = "DELETE  FROM [BAIS_INTERFACE_FILES] where [FileNameNumber]='" & CBAIF & "'"
                            cmdBAIS.ExecuteNonQuery()
                           
                            If Directory.Exists(BAISFileNewDirectory) Then
                                Directory.Delete(BAISFileNewDirectory, True)
                            End If
                            Directory.CreateDirectory(BAISFileNewDirectory)

                            Dim zipPath As String = BAISFileFullName 'Original Directory
                            Dim extractPath As String = BAISFileNewDirectory 'New Folder
                            ExtractTGZ(zipPath, extractPath)

                            '+++++++++++++++++++++++++++++++++++++++
                            Me.BgwBAISimport.ReportProgress(60, "BAIS Interface File for Import: " & "  " & CBAIF & " is ready")
                            Me.BgwBAISimport.ReportProgress(70, "Starting the BAIS Interface Import procedures...")


                            BAIS_INTERFACE_IMPORT_PROCEDURES()


                            'Erstellten Ordner wieder löschen
                            Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                            Directory.Delete(BAISFileNewDirectory, True)
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwBAISimport.ReportProgress(90, "Set as Last imported BAIS File Name: " & "  " & CBAIF)
                            cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CBAIF & "' WHERE [SYSTEM_NAME] in ('BAIS')"
                            cmdBAIS.ExecuteNonQuery()

                            LBAIF = CBAIF
                            Me.LastBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_LBAIF))
                            CBAIF = Nothing
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Clear_CBAIF))

                            'Füllen des Table adapters

                            Me.FILES_IMPORTTableAdapter.FillByBAIS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwBAISimport.ReportProgress(95, "BAIS Interface File Import: " & " " & LCBAIF & " " & "is finished ...")
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Interface Import finished ...")
                        ElseIf Me.BgwBAISimport.CancellationPending = True Then
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Interface Imports are terminated after user request!")
                            e.Cancel = True

                        End If

                    End If
                Next m
                'Löschen der Temporären Tabelen für den BAIS Import
                cmdBAIS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "DROP TABLE [BAIS_INTERFACE_FILES]"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(100, "Execute Stored Procedure:BAIS_UPDATES_CLIENT_DATA")
                cmdBAIS.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
                cmdBAIS.ExecuteNonQuery()

                If cmdBAIS.Connection.State = ConnectionState.Open Then
                    cmdBAIS.Connection.Close()
                End If

            Catch ex As System.Exception
                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS Interface file: " & " " & Me.CurrentBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
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

                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                cmdBAIS.Connection.Open()
                BAISDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISFileNewDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_FILE_TEMPLATE' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISInterfaceFileTemplate = cmdBAIS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAIS Interface Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Dim BaisFileFullName As String = BAISDirectory & BAISInterfaceFileTemplate.Replace("<Riskdate>", Me.SelectedBaisImportFile.Text) 'Full File Directory
                Dim BaisFileName As String = Me.SelectedBaisImportFile.Text 'File for Import


                If File.Exists(BaisFileFullName) = True Then
                    BAIS_Date = DateSerial(Microsoft.VisualBasic.Left(BaisFileName, 4), Mid(BaisFileName, 5, 2), Microsoft.VisualBasic.Right(BaisFileName, 2))
                    SqlBAISDate = BAIS_Date.ToString("yyyyMMdd")
                    Dim BaisDateNr As Double = BAIS_Date.ToString("yyyyMMdd")
                    CBAIF = BaisDateNr

                    If Directory.Exists(BAISFileNewDirectory) Then
                        Directory.Delete(BAISFileNewDirectory, True)
                    End If
                    Directory.CreateDirectory(BAISFileNewDirectory)

                    Dim zipPath As String = BaisFileFullName 'Original Directory
                    Dim extractPath As String = BAISFileNewDirectory 'New Folder
                    ExtractTGZ(zipPath, extractPath)
                    '+++++++++++++++++++++++++++++++++++++++
                    Me.BgwBAISimport.ReportProgress(60, "BAIS Interface File for Import: " & "  " & BaisFileName & " is ready")
                    Me.BgwBAISimport.ReportProgress(70, "Starting the BAIS Import procedures...")


                    'PROCEDUREN
                    BAIS_INTERFACE_IMPORT_PROCEDURES()

                    '++++++++++++++++++++++++++++++++++++++++++++++
                    'Erstellten Ordner wieder löschen
                    Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                    Directory.Delete(BAISFileNewDirectory, True)

                    Me.BgwBAISimport.ReportProgress(95, "BAIS Interface File Import: " & " " & BaisFileName & " " & "is finished ...")
                    Me.BgwBAISimport.ReportProgress(100, "BAIS Interface Import finished ...")

                Else
                    MessageBox.Show("BAIS Interface File: " & SelectedBaisImportFile.Text & " does not exists!", "BAIS INTERFACE FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                Me.BgwBAISimport.ReportProgress(100, "Execute Stored Procedure:BAIS_UPDATES_CLIENT_DATA")
                cmdBAIS.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
                cmdBAIS.ExecuteNonQuery()

                If cmdBAIS.Connection.State = ConnectionState.Open Then
                    cmdBAIS.Connection.Close()
                End If

            Catch ex As Exception

                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS INTERFACE File: " & " " & Me.SelectedBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
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

                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                cmdBAIS.Connection.Open()
                BAISDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISFileNewDirectory = cmdBAIS.ExecuteScalar()
                cmdBAIS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_INTERFACE_FILE_TEMPLATE' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_INTERFACE_IMPORT'"
                BAISInterfaceFileTemplate = cmdBAIS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAIS Interface Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='BAIS_INTERFACE_FILES' AND xtype='U') CREATE TABLE [BAIS_INTERFACE_FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[FileNameNumber] [float] NULL,[FileNameText] [nvarchar](255) NULL,[FileFullName] [nvarchar](255) NULL) ELSE DELETE FROM [BAIS_INTERFACE_FILES] "
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: #Temp_BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_INTERFACE_FILES' AND xtype='U') CREATE TABLE [#Temp_BAIS_INTERFACE_FILES]([ID] [int] IDENTITY(1,1) NOT NULL,[subdirectory] [nvarchar](255) NULL,[depth] float,[file] float NULL) ELSE DELETE FROM [#Temp_BAIS_INTERFACE_FILES] "
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAIS Files in Table: #Temp_BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "INSERT [#Temp_BAIS_INTERFACE_FILES] ([subdirectory],[depth],[file]) EXEC master..xp_dirtree '" & BAISDirectory & "',10,1"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAIS Files in Table: BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "INSERT INTO [BAIS_INTERFACE_FILES] (FileNameText) Select [subdirectory] from #Temp_BAIS_INTERFACE_FILES"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "DROP Table: #Temp_BAIS_INTERFACE_FILES")
                cmdBAIS.CommandText = "DROP TABLE #Temp_BAIS_INTERFACE_FILES"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(33, "Update FileNameNumber and FileFullName in BAIS FILES")
                cmdBAIS.CommandText = "UPDATE [BAIS_INTERFACE_FILES] SET [FileNameNumber]= CASE WHEN ISNUMERIC(SUBSTRING([FileNameText],20,8))=1 THEN CAST(SUBSTRING([FileNameText],20,8) as float) else 0 end,[FileFullName]='" & BAISDirectory & "' + [FileNameText]"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(40, "Delete from BAIS FILES where FileNameNumber=0")
                cmdBAIS.CommandText = "DELETE from [BAIS_INTERFACE_FILES] where [FileNameNumber]=0"
                cmdBAIS.ExecuteNonQuery()


                Me.BgwBAISimport.ReportProgress(45, "Delete from Table: BAIS FILES where FileName NOT BETWEEN " & Me.BaisImportFileFrom.Text & " and " & Me.BaisImportFileTill.Text)
                cmdBAIS.CommandText = "DELETE FROM [BAIS_INTERFACE_FILES] where [FileNameNumber] NOT BETWEEN '" & Me.BaisImportFileFrom.Text & "' and '" & Me.BaisImportFileTill.Text & "'"
                cmdBAIS.ExecuteNonQuery()
                'set temporary LastImportedBAISfile and load
                Me.BgwBAISimport.ReportProgress(46, "Set as Temporary Last Imported BAIS File Name:20010101")
                cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & 20010101 & "' WHERE [SYSTEM_NAME] in ('BAIS')"
                cmdBAIS.ExecuteNonQuery()

                Me.QueryText = "SELECT [FileNameNumber],[FileFullName]  FROM [BAIS_INTERFACE_FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwBAISimport.ReportProgress(50, "Determine the next BAIS File for Import...Please wait...")

                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileNameNumber] as NextFileNameforimport,[FileFullName] as NextFileFullName,[FileNameText] as 'OriginalFileName' from [BAIS_INTERFACE_FILES] where [FileNameNumber] in (SELECT min([FileNameNumber])FROM [BAIS_INTERFACE_FILES] where [FileNameNumber]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('BAIS')))"
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
                            Dim BAISFileCopyNewDirectory As String = dt1.Rows.Item(0).Item("OriginalFileName")

                            'Löschen der Daten in BAIS Files
                            Me.BgwBAISimport.ReportProgress(60, "Delete from BAIS FILES the File: " & CBAIF)
                            cmdBAIS.CommandText = "DELETE  FROM [BAIS_INTERFACE_FILES] where [FileNameNumber]='" & CBAIF & "'"
                            cmdBAIS.ExecuteNonQuery()

                            If Directory.Exists(BAISFileNewDirectory) Then
                                Directory.Delete(BAISFileNewDirectory, True)
                            End If
                            Directory.CreateDirectory(BAISFileNewDirectory)

                            Dim zipPath As String = BAISFileFullName 'Original Directory
                            Dim extractPath As String = BAISFileNewDirectory 'New Folder
                            ExtractTGZ(zipPath, extractPath)

                            '+++++++++++++++++++++++++++++++++++++++
                            Me.BgwBAISimport.ReportProgress(60, "BAIS Interface File for Import: " & "  " & CBAIF & " is ready")
                            Me.BgwBAISimport.ReportProgress(70, "Starting the BAIS Interface Import procedures...")


                            BAIS_INTERFACE_IMPORT_PROCEDURES()


                            'Erstellten Ordner wieder löschen
                            Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                            Directory.Delete(BAISFileNewDirectory, True)
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwBAISimport.ReportProgress(90, "Set as Last imported BAIS File Name: " & "  " & CBAIF)
                            cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CBAIF & "' WHERE [SYSTEM_NAME] in ('BAIS')"
                            cmdBAIS.ExecuteNonQuery()

                            LBAIF = CBAIF
                            Me.LastBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_LBAIF))
                            CBAIF = Nothing
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Clear_CBAIF))

                            'Füllen des Table adapters

                            Me.FILES_IMPORTTableAdapter.FillByBAIS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwBAISimport.ReportProgress(95, "BAIS Interface File Import: " & " " & LCBAIF & " " & "is finished ...")
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Interface Import finished ...")
                        ElseIf Me.BgwBAISimport.CancellationPending = True Then
                            Me.BgwBAISimport.ReportProgress(100, "BAIS Interface Imports are terminated after user request!")
                            e.Cancel = True

                        End If

                    End If

                Next m
                'Löschen der Temporären Tabelen für den BAIS Import
                cmdBAIS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "DROP TABLE [BAIS_INTERFACE_FILES]"
                cmdBAIS.ExecuteNonQuery()
                cmdBAIS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdBAIS.ExecuteNonQuery()
                'Set as last BAIS imported file Name the first BAIS file name
                cmdBAIS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CURRENT_LAST_IMPORTED_BAIS_FILE & "' WHERE [SYSTEM_NAME] in ('BAIS')"
                cmdBAIS.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(100, "Execute Stored Procedure:BAIS_UPDATES_CLIENT_DATA")
                cmdBAIS.CommandText = "exec [BAIS_UPDATES_CLIENT_DATA]"
                cmdBAIS.ExecuteNonQuery()

                If cmdBAIS.Connection.State = ConnectionState.Open Then
                    cmdBAIS.Connection.Close()
                End If

            Catch ex As System.Exception
                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS Interface file: " & " " & Me.CurrentBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
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
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & Me.EVENTSloadtext.Text & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','BAIS INTERFACE')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BAIS INTERFACE" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','BAIS INTERFACE')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BAIS INTERFACE" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByBAIS_INTERFACE(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
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

    Private Sub BaisInterfaceImportImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load



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

        Me.IMPORT_EVENTSTableAdapter.FillByBAIS_INTERFACE(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.FILES_IMPORTTableAdapter.FillByBAIS(Me.EDPDataSet.FILES_IMPORT)

    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Terminate OCBS Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwBAISimport.IsBusy = True Then
                If MessageBox.Show("Should the BAIS Interface import be terminated?", "TERMINATE BAIS INTERFACE IMPORTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwBAISimport.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS Imports termination is requested..." & vbNewLine & "Please wait until the current BAIS Import operations are finished!")
                End If
            End If
        End If
    End Sub

    Private Sub BAIS_INTERFACE_IMPORT_PROCEDURES()
        Dim fileEntries As String() = Directory.GetFiles(BAISFileNewDirectory & "\", "*.csv")
        ' Process the list of .txt files found in the directory. '
        Dim fileName As String

        For Each fileName In fileEntries
            dir_BaisFiles.Add(fileName)

        Next

        Dim BAIS_FILE_DIR As String = Nothing
        For i = 0 To dir_BaisFiles.Count - 1
            Dim BaisFileName As String = dir_BaisFiles(i).ToString
            BAIS_FILE_DIR = BaisFileName

            Select Case Microsoft.VisualBasic.Right(BaisFileName, 14)

                Case Is = "DVTIFF_CCB.csv"
                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS DVTIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_DVTIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_DVTIFF_Temp' AND xtype='U') CREATE TABLE [dbo].[#Temp_BAIS_DVTIFF_Temp]([DVTIFF_MDANT] [nvarchar](50) NULL,[DVTIFF_GSREF] [nvarchar](50) NULL,[DVTIFF_FILNR] [nvarchar](50) NULL,[DVTIFF_KDNRH] [nvarchar](50) NULL,[DVTIFF_DXABD] [datetime] NULL,[DVTIFF_GSKLA] [nvarchar](50) NULL,[DVTIFF_SUKLA] [nvarchar](50) NULL,[DVTIFF_DVART] [nvarchar](50) NULL,[DVTIFF_DXVAL] [datetime] NULL,[DVTIFF_DANWC] [nvarchar](50) NULL,[DVTIFF_DANBT] [float] NULL,[DVTIFF_DVKWC] [nvarchar](50) NULL,[DVTIFF_DVKBT] [float] NULL,[DVTIFF_HBKZN] [nvarchar](50) NULL,[DVTIFF_ZWRIS] [nvarchar](50) NULL,[DVTIFF_KBTRG] [nvarchar](50) NULL,[DVTIFF_PTEIN] [nvarchar](50) NULL,[DVTIFF_WHGKP] [nvarchar](50) NULL,[DVTIFF_BCHSW] [nvarchar](50) NULL,[DVTIFF_WHGBU] [nvarchar](50) NULL,[DVTIFF_URDEA] [nvarchar](50) NULL,[DVTIFF_NETKR] [nvarchar](50) NULL,[DVTIFF_KZCVA] [nvarchar](50) NULL,[DVTIFF_GSARE] [nvarchar](50) NULL,[DVTIFF_FAIRV] [nvarchar](50) NULL,[DVTIFF_DXVKT] [nvarchar](50) NULL,[DVTIFF_HFZGP] [nvarchar](50) NULL,[DVTIFF_AFREF] [nvarchar](50) NULL,[DVTIFF_RESE1] [nvarchar](50) NULL,[DVTIFF_RESE2] [nvarchar](50) NULL,[DVTIFF_FREI1] [datetime] NULL,[DVTIFF_FREI2] [nvarchar](50) NULL,[DVTIFF_FREI3] [nvarchar](50) NULL,[DVTIFF_LOEKZ] [nvarchar](50) NULL,[DVTIFF_IFNAM] [nvarchar](50) NULL,[DVTIFF_DXIFD] [datetime] NULL)  ELSE DELETE FROM [#Temp_BAIS_DVTIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import DVTIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_DVTIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_GSTIFF with the same Date in Column:GSTIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_DVTIFF] where [DVTIFF_DXIFD] in (Select distinct [DVTIFF_DXIFD] from [#Temp_BAIS_DVTIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_DVTIFF")
                        cmd.CommandText = "INSERT INTO [BAIS_DVTIFF]([DVTIFF_MDANT],[DVTIFF_GSREF],[DVTIFF_FILNR],[DVTIFF_KDNRH],[DVTIFF_DXABD],[DVTIFF_GSKLA],[DVTIFF_SUKLA],[DVTIFF_DVART] ,[DVTIFF_DXVAL],[DVTIFF_DANWC],[DVTIFF_DANBT],[DVTIFF_DVKWC],[DVTIFF_DVKBT],[DVTIFF_HBKZN],[DVTIFF_ZWRIS],[DVTIFF_KBTRG],[DVTIFF_PTEIN],[DVTIFF_WHGKP],[DVTIFF_BCHSW],[DVTIFF_WHGBU],[DVTIFF_URDEA],[DVTIFF_NETKR],[DVTIFF_KZCVA],[DVTIFF_GSARE],[DVTIFF_FAIRV],[DVTIFF_DXVKT],[DVTIFF_HFZGP],[DVTIFF_AFREF],[DVTIFF_RESE1],[DVTIFF_RESE2],[DVTIFF_FREI1],[DVTIFF_FREI2],[DVTIFF_FREI3],[DVTIFF_LOEKZ],[DVTIFF_IFNAM],[DVTIFF_DXIFD]) Select * from [#Temp_BAIS_DVTIFF_Temp]"
                        cmd.ExecuteNonQuery()


                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_DVTIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS DVTIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GSTIFF_CCB.csv"
                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS GSTIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GSTIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GSTIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GSTIFF_Temp]([GSTIFF_MDANT] [nvarchar](50) NULL,[GSTIFF_FILNR] [nvarchar](50) NULL,[GSTIFF_MODUL] [nvarchar](50) NULL,[GSTIFF_KDNRH] [nvarchar](50) NULL,[GSTIFF_KTONR] [nvarchar](50) NULL,[GSTIFF_GSREF] [nvarchar](50) NULL,[GSTIFF_BEZNG] [nvarchar](50) NULL,[GSTIFF_KOART] [nvarchar](50) NULL,[GSTIFF_BILKT] [nvarchar](50) NULL,[GSTIFF_GSKLA] [nvarchar](50) NULL,[GSTIFF_SUKLA] [nvarchar](50) NULL,[GSTIFF_GSART] [nvarchar](50) NULL,[GSTIFF_ULFZT] [nvarchar](50) NULL,[GSTIFF_WHISO] [nvarchar](50) NULL,[GSTIFF_VERKZ] [nvarchar](50) NULL,[GSTIFF_SLDKZ] [nvarchar](50) NULL,[GSTIFF_KZREV] [nvarchar](50) NULL,[GSTIFF_WPKNZ] [nvarchar](50) NULL,[GSTIFF_WPBFN] [nvarchar](50) NULL,[GSTIFF_HBKZN] [nvarchar](50) NULL,[GSTIFF_ZWRIS] [nvarchar](50) NULL,[GSTIFF_KZLST] [nvarchar](50) NULL,[GSTIFF_HAFIN] [nvarchar](50) NULL,[GSTIFF_WESTA] [nvarchar](50) NULL,[GSTIFF_BEZNR] [nvarchar](50) NULL,[GSTIFF_DXVND] [nvarchar](50) NULL,[GSTIFF_DXBSD] [nvarchar](50) NULL,[GSTIFF_MRLFZ] [nvarchar](50) NULL,[GSTIFF_AUSFL] [nvarchar](50) NULL,[GSTIFF_DXAUD] [nvarchar](50) NULL,[GSTIFF_RANGF] [nvarchar](50) NULL,[GSTIFF_KZUEV] [nvarchar](50) NULL,[GSTIFF_KFRIS] [nvarchar](50) NULL,[GSTIFF_DXZAP] [nvarchar](50) NULL,[GSTIFF_KZVSG] [nvarchar](50) NULL,[GSTIFF_KZKRU] [nvarchar](50) NULL,[GSTIFF_KONSB] [nvarchar](50) NULL,[GSTIFF_RISGR] [nvarchar](50) NULL,[GSTIFF_KONSK] [nvarchar](50) NULL,[GSTIFF_WPKNR] [nvarchar](50) NULL,[GSTIFF_GSARE] [nvarchar](50) NULL,[GSTIFF_PRDKT] [nvarchar](50) NULL,[GSTIFF_WHIFX] [nvarchar](50) NULL,[GSTIFF_HFZGP] [nvarchar](50) NULL,[GSTIFF_AFREF] [nvarchar](50) NULL,[GSTIFF_KZAKL] [nvarchar](50) NULL,[GSTIFF_KONSR] [nvarchar](50) NULL,[GSTIFF_FREI1] [nvarchar](50) NULL,[GSTIFF_FREI2] [nvarchar](50) NULL,[GSTIFF_FREI3] [nvarchar](50) NULL,[GSTIFF_FREI4] [nvarchar](50) NULL,[GSTIFF_FREI5] [nvarchar](50) NULL,[GSTIFF_LOEKZ] [nvarchar](50) NULL,[GSTIFF_IFNAM] [nvarchar](50) NULL,[GSTIFF_DXIFD] [datetime] NULL) ELSE DELETE FROM [#Temp_BAIS_GSTIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import GSTIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GSTIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_GSTIFF with the same Date in Column:GSTIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GSTIFF] where [GSTIFF_DXIFD] in (Select distinct [GSTIFF_DXIFD] from [#Temp_BAIS_GSTIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GSTIFF")
                        cmd.CommandText = "INSERT INTO [BAIS_GSTIFF]([GSTIFF_MDANT],[GSTIFF_FILNR],[GSTIFF_MODUL],[GSTIFF_KDNRH],[GSTIFF_KTONR],[GSTIFF_GSREF],[GSTIFF_BEZNG],[GSTIFF_KOART],[GSTIFF_BILKT],[GSTIFF_GSKLA],[GSTIFF_SUKLA],[GSTIFF_GSART],[GSTIFF_ULFZT],[GSTIFF_WHISO],[GSTIFF_VERKZ],[GSTIFF_SLDKZ],[GSTIFF_KZREV],[GSTIFF_WPKNZ],[GSTIFF_WPBFN],[GSTIFF_HBKZN],[GSTIFF_ZWRIS],[GSTIFF_KZLST],[GSTIFF_HAFIN],[GSTIFF_WESTA],[GSTIFF_BEZNR],[GSTIFF_DXVND],[GSTIFF_DXBSD],[GSTIFF_MRLFZ],[GSTIFF_AUSFL],[GSTIFF_DXAUD],[GSTIFF_RANGF],[GSTIFF_KZUEV],[GSTIFF_KFRIS],[GSTIFF_DXZAP],[GSTIFF_KZVSG],[GSTIFF_KZKRU],[GSTIFF_KONSB],[GSTIFF_RISGR],[GSTIFF_KONSK],[GSTIFF_WPKNR],[GSTIFF_GSARE],[GSTIFF_PRDKT],[GSTIFF_WHIFX],[GSTIFF_HFZGP],[GSTIFF_AFREF],[GSTIFF_KZAKL],[GSTIFF_KONSR],[GSTIFF_FREI1],[GSTIFF_FREI2],[GSTIFF_FREI3],[GSTIFF_FREI4],[GSTIFF_FREI5],[GSTIFF_LOEKZ],[GSTIFF_IFNAM],[GSTIFF_DXIFD]) Select * from [#Temp_BAIS_GSTIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=dbo.fn_StripCharacters([GSTIFF_GSREF],'^0-9') where [GSTIFF_MODUL] not in ('SK') and [GSTIFF_DXIFD]='" & SqlBAISDate & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Update [BAIS_GSTIFF] set [ReferenceClear]=LEFT([GSTIFF_GSREF],6) where [GSTIFF_MODUL] in ('SK') and [GSTIFF_DXIFD]='" & SqlBAISDate & "'"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GSTIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS GSTIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GSTSLF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS GSTSLF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GSTSLF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GSTSLF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GSTSLF_Temp]([GSTSLF_MDANT] [nvarchar](50) NULL,[GSTSLF_MODUL] [nvarchar](50) NULL,[GSTSLF_KDNRH] [nvarchar](50) NULL,[GSTSLF_KTONR] [nvarchar](50) NULL,[GSTSLF_GSREF] [nvarchar](50) NULL,[GSTSLF_SLDUB] [float] NULL,[GSTSLF_DISPO] [nvarchar](50) NULL,[GSTSLF_DXDVD] [nvarchar](50) NULL,[GSTSLF_DXDBD] [nvarchar](50) NULL,[GSTSLF_ABGBT] [float] NULL,[GSTSLF_GKBTR] [nvarchar](50) NULL,[GSTSLF_FAIRV] [nvarchar](50) NULL,[GSTSLF_IFNAM] [nvarchar](50) NULL,[GSTSLF_DXIFD] [nvarchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_GSTSLF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import GSTSLF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GSTSLF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN GSTSLF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_GSTSLF_Temp] ALTER COLUMN [GSTSLF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_GSTSLF with the same Date in Column:GSTSLF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GSTSLF] where [GSTSLF_DXIFD] in (Select distinct [GSTSLF_DXIFD] from [#Temp_BAIS_GSTSLF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GSTSLF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_GSTSLF]([GSTSLF_MDANT],[GSTSLF_MODUL],[GSTSLF_KDNRH],[GSTSLF_KTONR],[GSTSLF_GSREF],[GSTSLF_SLDUB],[GSTSLF_DISPO],[GSTSLF_DXDVD],[GSTSLF_DXDBD],[GSTSLF_ABGBT],[GSTSLF_GKBTR],[GSTSLF_FAIRV],[GSTSLF_IFNAM],[GSTSLF_DXIFD]) Select * from [#Temp_BAIS_GSTSLF_Temp]"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "Update [BAIS_GSTSLF] set [ReferenceClear]=dbo.fn_StripCharacters([GSTSLF_GSREF],'^0-9') where [GSTSLF_MODUL] not in ('SK') and [GSTSLF_DXIFD]='" & SqlBAISDate & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "Update [BAIS_GSTSLF] set [ReferenceClear]=LEFT([GSTSLF_GSREF],6) where [GSTSLF_MODUL] in ('SK') and [GSTSLF_DXIFD]='" & SqlBAISDate & "'"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GSTSLF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS GSTSLF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "KGCIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS KGCIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KGCIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KGCIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KGCIFF_Temp]([KGCIFF_MDANT] [varchar](50) NULL,[KGCIFF_MODUL] [varchar](50) NULL,[KGCIFF_KDNRH] [varchar](50) NULL,[KGCIFF_KTONR] [varchar](50) NULL,[KGCIFF_GSREF] [varchar](50) NULL,[KGCIFF_ACCNR] [varchar](50) NULL,[KGCIFF_PTYPI] [varchar](50) NULL,[KGCIFF_CURCD] [varchar](50) NULL,[KGCIFF_DXBEW] [varchar](50) NULL,[KGCIFF_ERART] [varchar](50) NULL,[KGCIFF_HOEHE] [varchar](50) NULL,[KGCIFF_SALDO] [varchar](50) NULL,[KGCIFF_TILGA] [varchar](50) NULL,[KGCIFF_ZINSA] [varchar](50) NULL,[KGCIFF_WHISO] [varchar](50) NULL,[KGCIFF_IFNAM] [varchar](50) NULL,[KGCIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_KGCIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import KGCIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KGCIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN KGCIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KGCIFF_Temp] ALTER COLUMN [KGCIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN KGCIFF_DXBEW to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KGCIFF_Temp] ALTER COLUMN [KGCIFF_DXBEW] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_KGCIFF with the same Date in Column:KGCIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KGCIFF] where [KGCIFF_DXIFD] in (Select distinct [KGCIFF_DXIFD] from [#Temp_BAIS_KGCIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GSTSLF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KGCIFF]([KGCIFF_MDANT],[KGCIFF_MODUL],[KGCIFF_KDNRH],[KGCIFF_KTONR],[KGCIFF_GSREF],[KGCIFF_ACCNR],[KGCIFF_PTYPI],[KGCIFF_CURCD],[KGCIFF_DXBEW],[KGCIFF_ERART],[KGCIFF_HOEHE],[KGCIFF_SALDO],[KGCIFF_TILGA],[KGCIFF_ZINSA],[KGCIFF_WHISO],[KGCIFF_IFNAM],[KGCIFF_DXIFD]) Select * from [#Temp_BAIS_KGCIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KGCIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS KGCIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "KNEIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS KNEIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KNEIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KNEIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KNEIFF_Temp]([KNEIFF_MDANT] [varchar](50) NULL,[KNEIFF_FILNR] [varchar](50) NULL,[KNEIFF_KDNRH] [varchar](50) NULL,[KNEIFF_KURZN] [varchar](50) NULL,[KNEIFF_NAME1] [varchar](50) NULL,[KNEIFF_NAME2] [varchar](50) NULL,[KNEIFF_NAME3] [varchar](50) NULL,[KNEIFF_PLZOR] [varchar](50) NULL,[KNEIFF_PLZNR] [varchar](50) NULL,[KNEIFF_STRAS] [varchar](50) NULL,[KNEIFF_DXGEB] [varchar](50) NULL,[KNEIFF_WSGSI] [varchar](50) NULL,[KNEIFF_BRNCH] [varchar](50) NULL,[KNEIFF_WSBIS] [varchar](50) NULL,[KNEIFF_BRNZU] [varchar](50) NULL,[KNEIFF_SLDSL] [varchar](50) NULL,[KNEIFF_RLDSL] [varchar](50) NULL,[KNEIFF_LDRIS] [varchar](50) NULL,[KNEIFF_BONIT] [varchar](50) NULL,[KNEIFF_GRPKZ] [varchar](50) NULL,[KNEIFF_KZLST] [varchar](50) NULL,[KNEIFF_KZPER] [varchar](50) NULL,[KNEIFF_UMMIO] [varchar](50) NULL,[KNEIFF_AUSFL] [varchar](50) NULL,[KNEIFF_DXAUD] [varchar](50) NULL,[KNEIFF_ORGSL] [varchar](50) NULL,[KNEIFF_RISGR] [varchar](50) NULL,[KNEIFF_KGBID] [varchar](50) NULL,[KNEIFF_ANRKZ] [varchar](50) NULL,[KNEIFF_ESAKZ] [varchar](50) NULL,[KNEIFF_NACES] [varchar](50) NULL,[KNEIFF_LENID] [varchar](50) NULL,[KNEIFF_WSCRR] [varchar](50) NULL,[KNEIFF_AVCKZ] [varchar](50) NULL,[KNEIFF_FREI1] [varchar](50) NULL,[KNEIFF_FREI2] [varchar](50) NULL,[KNEIFF_FREI3] [varchar](50) NULL,[KNEIFF_FREI4] [varchar](50) NULL,[KNEIFF_FREI5] [varchar](50) NULL,[KNEIFF_LOEKZ] [varchar](50) NULL,[KNEIFF_IFNAM] [varchar](50) NULL,[KNEIFF_DXIFD] [varchar](50) NULL)  ELSE DELETE FROM [#Temp_BAIS_KNEIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import KNEIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KNEIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN KNEIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KNEIFF_Temp] ALTER COLUMN [KNEIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_KNEIFF with the same Date in Column:KNEIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KNEIFF] where [KNEIFF_DXIFD] in (Select distinct [KNEIFF_DXIFD] from [#Temp_BAIS_KNEIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNEIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KNEIFF]([KNEIFF_MDANT],[KNEIFF_FILNR],[KNEIFF_KDNRH],[KNEIFF_KURZN],[KNEIFF_NAME1],[KNEIFF_NAME2],[KNEIFF_NAME3],[KNEIFF_PLZOR],[KNEIFF_PLZNR],[KNEIFF_STRAS],[KNEIFF_DXGEB],[KNEIFF_WSGSI],[KNEIFF_BRNCH],[KNEIFF_WSBIS],[KNEIFF_BRNZU],[KNEIFF_SLDSL],[KNEIFF_RLDSL],[KNEIFF_LDRIS],[KNEIFF_BONIT],[KNEIFF_GRPKZ],[KNEIFF_KZLST],[KNEIFF_KZPER],[KNEIFF_UMMIO],[KNEIFF_AUSFL],[KNEIFF_DXAUD],[KNEIFF_ORGSL],[KNEIFF_RISGR],[KNEIFF_KGBID],[KNEIFF_ANRKZ],[KNEIFF_ESAKZ],[KNEIFF_NACES],[KNEIFF_LENID],[KNEIFF_WSCRR],[KNEIFF_AVCKZ],[KNEIFF_FREI1],[KNEIFF_FREI2],[KNEIFF_FREI3],[KNEIFF_FREI4],[KNEIFF_FREI5],[KNEIFF_LOEKZ],[KNEIFF_IFNAM],[KNEIFF_DXIFD]) Select * from [#Temp_BAIS_KNEIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KNEIFF_Temp]"
                        cmd.ExecuteNonQuery()


                        Me.BgwBAISimport.ReportProgress(80, "BAIS KNEIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "KNVIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS KNVIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KNVIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KNVIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KNVIFF_Temp]([KNVIFF_MDANK] [varchar](50) NULL,[KNVIFF_MDANT] [varchar](50) NULL,[KNVIFF_KNZNR] [varchar](50) NULL,[KNVIFF_MDAN2] [varchar](50) NULL,[KNVIFF_KDNRH] [varchar](50) NULL,[KNVIFF_KNEKZ] [varchar](50) NULL,[KNVIFF_GRDZF] [varchar](50) NULL,[KNVIFF_ZUSKZ] [varchar](50) NULL,[KNVIFF_GBRKZ] [varchar](50) NULL,[KNVIFF_MEANT] [varchar](50) NULL,[KNVIFF_HFBES] [varchar](50) NULL,[KNVIFF_ANERL] [varchar](50) NULL,[KNVIFF_BETXT] [varchar](50) NULL,[KNVIFF_FREI1] [varchar](50) NULL,[KNVIFF_FREI2] [varchar](50) NULL,[KNVIFF_FREI3] [varchar](50) NULL,[KNVIFF_LOEKZ] [varchar](50) NULL,[KNVIFF_IFNAM] [varchar](50) NULL,[KNVIFF_DXIFD] [varchar](50) NULL)  ELSE DELETE FROM [#Temp_BAIS_KNVIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import KNVIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KNVIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN KNVIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KNVIFF_Temp] ALTER COLUMN [KNVIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_KNVIFF with the same Date in Column:KNVIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KNVIFF] where [KNVIFF_DXIFD] in (Select distinct [KNVIFF_DXIFD] from [#Temp_BAIS_KNVIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNVIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KNVIFF]([KNVIFF_MDANK],[KNVIFF_MDANT],[KNVIFF_KNZNR],[KNVIFF_MDAN2],[KNVIFF_KDNRH],[KNVIFF_KNEKZ],[KNVIFF_GRDZF],[KNVIFF_ZUSKZ],[KNVIFF_GBRKZ],[KNVIFF_MEANT],[KNVIFF_HFBES],[KNVIFF_ANERL],[KNVIFF_BETXT],[KNVIFF_FREI1],[KNVIFF_FREI2],[KNVIFF_FREI3],[KNVIFF_LOEKZ],[KNVIFF_IFNAM],[KNVIFF_DXIFD]) Select * from [#Temp_BAIS_KNVIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KNVIFF_Temp]"
                        cmd.ExecuteNonQuery()


                        Me.BgwBAISimport.ReportProgress(80, "BAIS KNVIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                    '++++++Only delete file -File is filed with data from PS TOOL
                Case Is = "KRKIFF_CCB.csv"

                    Try



                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try
                    '+++++++++++++++++++

                Case Is = "KSRIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS KSRIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KSRIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KSRIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KSRIFF_Temp]([KSRIFF_RKLIF] [varchar](50) NULL,[KSRIFF_RAGEN] [varchar](50) NULL,[KSRIFF_RATYP] [varchar](50) NULL,[KSRIFF_KZHFW] [varchar](50) NULL,[KSRIFF_RATEX] [varchar](50) NULL,[KSRIFF_DXRAT] [varchar](50) NULL,[KSRIFF_LDISO] [varchar](50) NULL,[KSRIFF_IFNAM] [varchar](50) NULL,[KSRIFF_DXIFD] [varchar](50) NULL)  ELSE DELETE FROM [#Temp_BAIS_KSRIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import KSRIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KSRIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN KSRIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KSRIFF_Temp] ALTER COLUMN [KSRIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN KSRIFF_DXRAT to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KSRIFF_Temp] ALTER COLUMN [KSRIFF_DXRAT] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_KSRIFF with the same Date in Column:KSRIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KSRIFF] where [KSRIFF_DXIFD] in (Select distinct [KSRIFF_DXIFD] from [#Temp_BAIS_KSRIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNVIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KSRIFF]([KSRIFF_RKLIF],[KSRIFF_RAGEN],[KSRIFF_RATYP],[KSRIFF_KZHFW],[KSRIFF_RATEX],[KSRIFF_DXRAT],[KSRIFF_LDISO],[KSRIFF_IFNAM],[KSRIFF_DXIFD]) Select * from [#Temp_BAIS_KSRIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KSRIFF_Temp]"
                        cmd.ExecuteNonQuery()


                        Me.BgwBAISimport.ReportProgress(80, "BAIS KSRIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "LQGIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS LQGIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_LQGIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_LQGIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_LQGIFF_Temp]([LQGIFF_MDANT] [varchar](50) NULL,[LQGIFF_MODUL] [varchar](50) NULL,[LQGIFF_KDNRH] [varchar](50) NULL,[LQGIFF_KTONR] [varchar](50) NULL,[LQGIFF_GSREF] [varchar](50) NULL,[LQGIFF_EINLS] [varchar](50) NULL,[LQGIFF_KUNDG] [varchar](50) NULL,[LQGIFF_KUNBT] [varchar](50) NULL,[LQGIFF_EINTY] [varchar](50) NULL,[LQGIFF_BESFI] [varchar](50) NULL,[LQGIFF_RSFFK] [varchar](50) NULL,[LQGIFF_DXBES] [varchar](50) NULL,[LQGIFF_MWSIC] [varchar](50) NULL,[LQGIFF_WHMWS] [varchar](50) NULL,[LQGIFF_ANZKI] [varchar](50) NULL,[LQGIFF_KZABL] [varchar](50) NULL,[LQGIFF_DXBEL] [varchar](50) NULL,[LQGIFF_HOEBL] [varchar](50) NULL,[LQGIFF_WHGBL] [varchar](50) NULL,[LQGIFF_NOMBT] [varchar](50) NULL,[LQGIFF_HAWHG] [varchar](50) NULL,[LQGIFF_KUDIV] [varchar](50) NULL,[LQGIFF_QKRLA] [varchar](50) NULL,[LQGIFF_LIQQU] [varchar](50) NULL,[LQGIFF_KZLCI] [varchar](50) NULL,[LQGIFF_KZFAZ] [varchar](50) NULL,[LQGIFF_LCRK1] [varchar](50) NULL,[LQGIFF_LCRK2] [varchar](50) NULL,[LQGIFF_NSFRK] [varchar](50) NULL,[LQGIFF_CAPIF] [varchar](50) NULL,[LQGIFF_IFNAM] [varchar](50) NULL,[LQGIFF_DXIFD] [varchar](50) NULL)   ELSE DELETE FROM [#Temp_BAIS_LQGIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import LQGIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_LQGIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN LQGIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_LQGIFF_Temp] ALTER COLUMN [LQGIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_LQGIFF with the same Date in Column:LQGIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_LQGIFF] where [LQGIFF_DXIFD] in (Select distinct [LQGIFF_DXIFD] from [#Temp_BAIS_LQGIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_LQGIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_LQGIFF]([LQGIFF_MDANT],[LQGIFF_MODUL],[LQGIFF_KDNRH],[LQGIFF_KTONR],[LQGIFF_GSREF],[LQGIFF_EINLS],[LQGIFF_KUNDG],[LQGIFF_KUNBT],[LQGIFF_EINTY],[LQGIFF_BESFI],[LQGIFF_RSFFK],[LQGIFF_DXBES],[LQGIFF_MWSIC],[LQGIFF_WHMWS],[LQGIFF_ANZKI],[LQGIFF_KZABL],[LQGIFF_DXBEL],[LQGIFF_HOEBL],[LQGIFF_WHGBL],[LQGIFF_NOMBT],[LQGIFF_HAWHG],[LQGIFF_KUDIV],[LQGIFF_QKRLA],[LQGIFF_LIQQU],[LQGIFF_KZLCI],[LQGIFF_KZFAZ],[LQGIFF_LCRK1],[LQGIFF_LCRK2],[LQGIFF_NSFRK],[LQGIFF_CAPIF],[LQGIFF_IFNAM],[LQGIFF_DXIFD]) Select * from [#Temp_BAIS_LQGIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_LQGIFF_Temp]"
                        cmd.ExecuteNonQuery()


                        Me.BgwBAISimport.ReportProgress(80, "BAIS LQGIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "MKUIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS MKUIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_MKUIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_MKUIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_MKUIFF_Temp]([MKUIFF_MDANT] [varchar](50) NULL,[MKUIFF_WPKNR] [varchar](50) NULL,[MKUIFF_HAWHG] [varchar](50) NULL,[MKUIFF_PREIS] [varchar](50) NULL,[MKUIFF_PREI2] [varchar](50) NULL,[MKUIFF_BEWAB] [varchar](50) NULL,[MKUIFF_BWALA] [varchar](50) NULL,[MKUIFF_CLEAN] [varchar](50) NULL,[MKUIFF_IFNAM] [varchar](50) NULL,[MKUIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_MKUIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import MKUIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_MKUIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN MKUIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_MKUIFF_Temp] ALTER COLUMN [MKUIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_MKUIFF with the same Date in Column:MKUIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_MKUIFF] where [MKUIFF_DXIFD] in (Select distinct [MKUIFF_DXIFD] from [#Temp_BAIS_MKUIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_MKUIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_MKUIFF]([MKUIFF_MDANT],[MKUIFF_WPKNR],[MKUIFF_HAWHG],[MKUIFF_PREIS],[MKUIFF_PREI2],[MKUIFF_BEWAB],[MKUIFF_BWALA],[MKUIFF_CLEAN],[MKUIFF_IFNAM],[MKUIFF_DXIFD]) Select * from [#Temp_BAIS_MKUIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Check for new Securities-Run SQL Job:")
                        cmd.CommandText = "EXEC msdb.dbo.sp_start_job 'NEW SECURITIES EMAIL'"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_MKUIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS MKUIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "ZUSIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS ZUSIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_ZUSIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_ZUSIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_ZUSIFF_Temp]([ZUSIFF_MDANT] [varchar](50) NULL,[ZUSIFF_FILNR] [varchar](50) NULL,[ZUSIFF_KDNRH] [varchar](50) NULL,[ZUSIFF_ZUREF] [varchar](50) NULL,[ZUSIFF_ZUART] [varchar](50) NULL,[ZUSIFF_KRART] [varchar](50) NULL,[ZUSIFF_MODUL] [varchar](50) NULL,[ZUSIFF_KTONR] [varchar](50) NULL,[ZUSIFF_GSREF] [varchar](50) NULL,[ZUSIFF_ZUEXU] [varchar](50) NULL,[ZUSIFF_WHRGE] [varchar](50) NULL,[ZUSIFF_DXZGA] [varchar](50) NULL,[ZUSIFF_DXVNE] [varchar](50) NULL,[ZUSIFF_DXBSE] [varchar](50) NULL,[ZUSIFF_KZREV] [varchar](50) NULL,[ZUSIFF_KZUNW] [varchar](50) NULL,[ZUSIFF_KZABR] [varchar](50) NULL,[ZUSIFF_WLKKZ] [varchar](50) NULL,[ZUSIFF_KNZZU] [varchar](50) NULL,[ZUSIFF_ZOEKZ] [varchar](50) NULL,[ZUSIFF_KGZUO] [varchar](50) NULL,[ZUSIFF_ZUTYP] [varchar](50) NULL,[ZUSIFF_AUSFL] [varchar](50) NULL,[ZUSIFF_DXAUD] [varchar](50) NULL,[ZUSIFF_KOART] [varchar](50) NULL,[ZUSIFF_GSART] [varchar](50) NULL,[ZUSIFF_RISGR] [varchar](50) NULL,[ZUSIFF_KZUKU] [varchar](50) NULL,[ZUSIFF_ERHGE] [varchar](50) NULL,[ZUSIFF_GSARE] [varchar](50) NULL,[ZUSIFF_HAFIN] [varchar](50) NULL,[ZUSIFF_PRDKT] [varchar](50) NULL,[ZUSIFF_INABU] [varchar](50) NULL,[ZUSIFF_KZAKL] [varchar](50) NULL,[ZUSIFF_FREI1] [varchar](50) NULL,[ZUSIFF_FREI2] [varchar](50) NULL,[ZUSIFF_FREI3] [varchar](50) NULL,[ZUSIFF_FREI4] [varchar](50) NULL,[ZUSIFF_FREI5] [varchar](50) NULL,[ZUSIFF_LOEKZ] [varchar](50) NULL,[ZUSIFF_IFNAM] [varchar](50) NULL,[ZUSIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_ZUSIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import ZUSIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_ZUSIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXZGA to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXZGA] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXVNE to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXVNE] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXBSE to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXBSE] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_ZUSIFF with the same Date in Column:ZUSIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_ZUSIFF] where [ZUSIFF_DXIFD] in (Select distinct [ZUSIFF_DXIFD] from [#Temp_BAIS_ZUSIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_ZUSIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_ZUSIFF]([ZUSIFF_MDANT],[ZUSIFF_FILNR],[ZUSIFF_KDNRH],[ZUSIFF_ZUREF],[ZUSIFF_ZUART],[ZUSIFF_KRART],[ZUSIFF_MODUL],[ZUSIFF_KTONR],[ZUSIFF_GSREF],[ZUSIFF_ZUEXU],[ZUSIFF_WHRGE],[ZUSIFF_DXZGA],[ZUSIFF_DXVNE],[ZUSIFF_DXBSE],[ZUSIFF_KZREV],[ZUSIFF_KZUNW],[ZUSIFF_KZABR],[ZUSIFF_WLKKZ],[ZUSIFF_KNZZU],[ZUSIFF_ZOEKZ],[ZUSIFF_KGZUO],[ZUSIFF_ZUTYP],[ZUSIFF_AUSFL],[ZUSIFF_DXAUD],[ZUSIFF_KOART],[ZUSIFF_GSART],[ZUSIFF_RISGR],[ZUSIFF_KZUKU],[ZUSIFF_ERHGE],[ZUSIFF_GSARE],[ZUSIFF_HAFIN],[ZUSIFF_PRDKT],[ZUSIFF_INABU],[ZUSIFF_KZAKL],[ZUSIFF_FREI1],[ZUSIFF_FREI2],[ZUSIFF_FREI3],[ZUSIFF_FREI4],[ZUSIFF_FREI5],[ZUSIFF_LOEKZ],[ZUSIFF_IFNAM],[ZUSIFF_DXIFD]) Select * from [#Temp_BAIS_ZUSIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_ZUSIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS ZUSIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GAKIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS GAKIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GAKIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GAKIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GAKIFF_Temp]([GAKIFF_MDANT] [varchar](50) NULL,[GAKIFF_GARFN] [varchar](50) NULL,[GAKIFF_FILNR] [varchar](50) NULL,[GAKIFF_GARTG] [varchar](50) NULL,[GAKIFF_GARTI] [varchar](50) NULL,[GAKIFF_HBKZN] [varchar](50) NULL,[GAKIFF_DXVND] [varchar](50) NULL,[GAKIFF_DXBSD] [varchar](50) NULL,[GAKIFF_GABTR] [varchar](50) NULL,[GAKIFF_VWTER] [varchar](50) NULL,[GAKIFF_WHISO] [varchar](50) NULL,[GAKIFF_GSPRZ] [varchar](50) NULL,[GAKIFF_MODUL] [varchar](50) NULL,[GAKIFF_KDNRG] [varchar](50) NULL,[GAKIFF_KTONR] [varchar](50) NULL,[GAKIFF_GSREF] [varchar](50) NULL,[GAKIFF_DEPNR] [varchar](50) NULL,[GAKIFF_KZBVK] [varchar](50) NULL,[GAKIFF_BEBTR] [varchar](50) NULL,[GAKIFF_VEBTR] [varchar](50) NULL,[GAKIFF_VORBT] [varchar](50) NULL,[GAKIFF_OLDSL] [varchar](50) NULL,[GAKIFF_SIGAR] [varchar](50) NULL,[GAKIFF_KRRFN] [varchar](50) NULL,[GAKIFF_HCMPV] [varchar](50) NULL,[GAKIFF_HCWHG] [varchar](50) NULL,[GAKIFF_LIQUD] [varchar](50) NULL,[GAKIFF_RSKFZ] [varchar](50) NULL,[GAKIFF_KZANR] [varchar](50) NULL,[GAKIFF_KZSUB] [varchar](50) NULL,[GAKIFF_KZZWB] [varchar](50) NULL,[GAKIFF_FREI1] [varchar](50) NULL,[GAKIFF_FREI2] [varchar](50) NULL,[GAKIFF_FREI3] [varchar](50) NULL,[GAKIFF_FREI4] [varchar](50) NULL,[GAKIFF_FREI5] [varchar](50) NULL,[GAKIFF_LOEKZ] [varchar](50) NULL,[GAKIFF_IFNAM] [varchar](50) NULL,[GAKIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_GAKIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import GAKIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GAKIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN GAKIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_GAKIFF_Temp] ALTER COLUMN [GAKIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_GAKIFF with the same Date in Column:GAKIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GAKIFF] where [GAKIFF_DXIFD] in (Select distinct [GAKIFF_DXIFD] from [#Temp_BAIS_GAKIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GAKIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_GAKIFF]([GAKIFF_MDANT],[GAKIFF_GARFN],[GAKIFF_FILNR],[GAKIFF_GARTG],[GAKIFF_GARTI],[GAKIFF_HBKZN],[GAKIFF_DXVND],[GAKIFF_DXBSD],[GAKIFF_GABTR],[GAKIFF_VWTER],[GAKIFF_WHISO],[GAKIFF_GSPRZ],[GAKIFF_MODUL],[GAKIFF_KDNRG],[GAKIFF_KTONR],[GAKIFF_GSREF],[GAKIFF_DEPNR],[GAKIFF_KZBVK],[GAKIFF_BEBTR],[GAKIFF_VEBTR],[GAKIFF_VORBT],[GAKIFF_OLDSL],[GAKIFF_SIGAR],[GAKIFF_KRRFN],[GAKIFF_HCMPV],[GAKIFF_HCWHG],[GAKIFF_LIQUD],[GAKIFF_RSKFZ],[GAKIFF_KZANR],[GAKIFF_KZSUB],[GAKIFF_KZZWB],[GAKIFF_FREI1],[GAKIFF_FREI2],[GAKIFF_FREI3],[GAKIFF_FREI4],[GAKIFF_FREI5],[GAKIFF_LOEKZ],[GAKIFF_IFNAM],[GAKIFF_DXIFD]) Select * from [#Temp_BAIS_GAKIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GAKIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS GAKIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GAGIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS GAGIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GAGIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GAGIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GAGIFF_Temp]([GAGIFF_MDANT] [varchar](50) NULL,[GAGIFF_GARFN] [varchar](50) NULL,[GAGIFF_MODUL] [varchar](50) NULL,[GAGIFF_KDNRH] [varchar](50) NULL,[GAGIFF_GKRKT] [varchar](50) NULL,[GAGIFF_GSREF] [varchar](50) NULL,[GAGIFF_GLFDN] [varchar](50) NULL,[GAGIFF_HCKRA] [varchar](50) NULL,[GAGIFF_KZSUB] [varchar](50) NULL,[GAGIFF_KZZWB] [varchar](50) NULL,[GAGIFF_FREI1] [varchar](50) NULL,[GAGIFF_FREI2] [varchar](50) NULL,[GAGIFF_FREI3] [varchar](50) NULL,[GAGIFF_LOEKZ] [varchar](50) NULL,[GAGIFF_IFNAM] [varchar](50) NULL,[GAGIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_GAGIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import GAGIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GAGIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN GAGIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_GAGIFF_Temp] ALTER COLUMN [GAGIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'Set Correct Value in Field GAGIFF_IFNAM 

                        Me.BgwBAISimport.ReportProgress(40, "Set Correct Value in Field GAGIFF_IFNAM")
                        cmd.CommandText = "UPDATE [#Temp_BAIS_GAGIFF_Temp] SET [GAGIFF_IFNAM]='GAGIFF'"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_GAGIFF with the same Date in Column:GAGIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GAGIFF] where [GAGIFF_DXIFD] in (Select distinct [GAGIFF_DXIFD] from [#Temp_BAIS_GAGIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GAGIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_GAGIFF]([GAGIFF_MDANT],[GAGIFF_GARFN],[GAGIFF_MODUL],[GAGIFF_KDNRH],[GAGIFF_GKRKT],[GAGIFF_GSREF],[GAGIFF_GLFDN],[GAGIFF_HCKRA],[GAGIFF_KZSUB],[GAGIFF_KZZWB],[GAGIFF_FREI1],[GAGIFF_FREI2],[GAGIFF_FREI3],[GAGIFF_LOEKZ],[GAGIFF_IFNAM],[GAGIFF_DXIFD]) Select * from [#Temp_BAIS_GAGIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS GAGIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "LQKIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS LQKIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_LQKIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_LQKIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_LQKIFF_Temp]([LQKIFF_MDANT] [varchar](50) NULL,[LQKIFF_KDNRH] [varchar](50) NULL,[LQKIFF_LQSEK] [varchar](50) NULL,[LQKIFF_OBBTG] [varchar](50) NULL,[LQKIFF_KZGBZ] [varchar](50) NULL,[LQKIFF_IFNAM] [varchar](50) NULL,[LQKIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_LQKIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import LQKIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_LQKIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "ALTER COLUMN LQKIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_LQKIFF_Temp] ALTER COLUMN [LQKIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_LQKIFF with the same Date in Column:LQKIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_LQKIFF] where [LQKIFF_DXIFD] in (Select distinct [LQKIFF_DXIFD] from [#Temp_BAIS_LQKIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_LQKIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_LQKIFF]([LQKIFF_MDANT],[LQKIFF_KDNRH],[LQKIFF_LQSEK],[LQKIFF_OBBTG],[LQKIFF_KZGBZ],[LQKIFF_IFNAM],[LQKIFF_DXIFD]) Select * from [#Temp_BAIS_LQKIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_LQKIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(80, "BAIS LQKIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "WHGIFF_CCB.csv"

                    Try

                        Me.BgwBAISimport.ReportProgress(10, "Start Import: BAIS WHGIFF")
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If

                        Me.BgwBAISimport.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_WHGIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_WHGIFF_Temp' AND xtype='U') CREATE TABLE [dbo].[#Temp_BAIS_WHGIFF_Temp]([WHGIFF_MDANT] [varchar](50) NULL,[WHGIFF_WHISO] [varchar](50) NULL,[WHGIFF_WNAME] [varchar](50) NULL,[WHGIFF_WSLZB] [varchar](50) NULL,[WHGIFF_WEINH] [varchar](50) NULL,[WHGIFF_WKLEH] [varchar](50) NULL,[WHGIFF_WNKST] [varchar](50) NULL,[WHGIFF_WSTAT] [varchar](50) NULL,[WHGIFF_MKURS] [float] NULL,[WHGIFF_DXEGK] [datetime] NULL,[WHGIFF_IFNAM] [varchar](50) NULL,[WHGIFF_DXIFD] [datetime] NULL) ELSE DELETE FROM [#Temp_BAIS_WHGIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(30, "Import WHGIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_WHGIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(40, "Delete all data from BAIS_WHGIFF with the same Date in Column:WHGIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_WHGIFF] where [WHGIFF_DXIFD] in (Select distinct [WHGIFF_DXIFD] from [#Temp_BAIS_WHGIFF_Temp])"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(50, "Insert Data from Temporary Table to BAIS_LQKIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_WHGIFF]([WHGIFF_MDANT],[WHGIFF_WHISO],[WHGIFF_WNAME],[WHGIFF_WSLZB],[WHGIFF_WEINH],[WHGIFF_WKLEH],[WHGIFF_WNKST],[WHGIFF_WSTAT],[WHGIFF_MKURS],[WHGIFF_DXEGK],[WHGIFF_IFNAM],[WHGIFF_DXIFD]) SELECT * from [#Temp_BAIS_WHGIFF_Temp]"
                        cmd.ExecuteNonQuery()

                        Me.BgwBAISimport.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_WHGIFF_Temp]"
                        cmd.ExecuteNonQuery()


                        Me.BgwBAISimport.ReportProgress(80, "BAIS WHGIFF IMPORT finished")
                        cmd.Connection.Close()

                    Catch ex As Exception

                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBAISimport.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

            End Select
        Next

    End Sub

   

    Public Shared Function RemoveAttribute(ByVal attributes As FileAttributes, ByVal attributesToRemove As FileAttributes) As FileAttributes
        Return attributes And (Not attributesToRemove)
    End Function

End Class