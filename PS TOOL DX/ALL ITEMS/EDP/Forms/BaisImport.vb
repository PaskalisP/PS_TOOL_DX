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
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports ICSharpCode.SharpZipLib.Tar
Imports ICSharpCode.SharpZipLib.Core



Public Class BaisImport

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""

   
    Dim BAISDirectory As String = "" 'OCBS FILE DIRECTORY
    Dim BAISFileNewDirectory As String = "" 'NEW DIRECTORY FOR OCBS FILE


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

    Dim ex As Integer
    Dim BaisAutomatedImport_btn_clicked As Boolean = False 'Button for Automated Import
    Dim BaisSelectedFileImport_btn_clicked As Boolean = False 'Button for single File import
    Dim BaisImportFromTill_btn_clicked As Boolean = False
    Dim BaisImportManual_btn_clicked As Boolean = False
    Dim CURRENT_LAST_IMPORTED_BAIS_FILE As Double = Nothing

    Dim MaxProcDate As Date
    Dim BAIS_Date As Date
    Dim SqlBAISDate As String = ""

    'Heutiges Datum ermitteln und in Zahl unformatieren
    Dim CurDate As Date = Today
    Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")
    Dim ID_Selected As Integer = 0
    Dim GetFocusedRow As Integer = 0
    Private ConvertWorkbook As IWorkbook




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


    Private Sub BaisImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        OpenSqlConnections()
        MaxProcDate = cmd.ExecuteScalar
        CloseSqlConnections()

        Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
        Me.IMPORT_EVENTSTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        'Add new Procedure
        If e.Button.Tag = "AddProc" Then
            Try
                Me.BAISFORMSIMPORTPROCEDURESBindingSource.EndEdit()
                Me.OcbsImportProcedures_BasicView.AddNewRow()
                Me.OcbsImportProcedures_BasicView.ShowEditForm()
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on add new Procedure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Add delete Procedure
        If e.Button.Tag = "DeleteProc" Then
            If XtraMessageBox.Show(CType("Should the Procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be deleted? ", String), "DELETE PROCEDURE", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Delete Procedure")
                    OpenSqlConnections()
                    cmd.CommandText = "DELETE FROM [BAISFORMS_IMPORT_PROCEDURES] where ID=" & ID_Selected & ""
                    cmd.ExecuteNonQuery()
                    'Reset LfdNr
                    cmd.CommandText = "UPDATE A SET A.LfdNr=B.rn from [BAISFORMS_IMPORT_PROCEDURES] A INNER JOIN 
                                       (SELECT row_number() over (order by LfdNr asc) as rn,ID
                                       from  [BAISFORMS_IMPORT_PROCEDURES])B On A.ID=B.ID"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                    SplashScreenManager.CloseForm(False)
                Catch ex As Exception
                    CloseSqlConnections()
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try

            End If
        End If

        'Add delete Procedure
        If e.Button.Tag = "Reload" Then

            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Reload procedures")
                Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)
                Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try

        End If


        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.BAISFORMSIMPORTPROCEDURESBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BAISFORMSIMPORTPROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Activate all Procedures
        If e.Button.Tag = "ActivateProcs" Then
            Try
                If XtraMessageBox.Show("Should all current mandatory Procedures be activated", "ACTIVATE CURRENT MANDATORY PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [BAISFORMS_IMPORT_PROCEDURES] SET [Valid]='Y' where [Importance] in ('MANDATORY')"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Activate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BAISFORMSIMPORTPROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Deactivate all Procedures
        If e.Button.Tag = "DeactivateProcs" Then
            Try
                If XtraMessageBox.Show("Should all current Procedures be Deactivated", "DEACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [BAISFORMS_IMPORT_PROCEDURES] SET [Valid]='N'"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Deactivate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BAISFORMSIMPORTPROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If
        'Terminate OCBS Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwBAISimport.IsBusy = True Then
                If XtraMessageBox.Show("Should the executed BAISForm import procedures be terminated?", "TERMINATE BAIS IMPORTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwBAISimport.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("BAIS Imports termination is requested..." & vbNewLine & "Please wait until the current BAISform Import operations are finished!")
                End If
            End If
        End If

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
        BaisImportManual_btn_clicked = False
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
        BaisImportManual_btn_clicked = False
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
        BaisImportManual_btn_clicked = False
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

    Public Shared Function RemoveAttribute(ByVal attributes As FileAttributes, ByVal attributesToRemove As FileAttributes) As FileAttributes
        Return attributes And (Not attributesToRemove)
    End Function

    'Extracts all files from a Tar File
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
        CurrentSystemExecuting = "BAISFORMS"
        Me.BgwBAISimport.ReportProgress(10, "Locate the BAISForms Current and Temp Directory")
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
        BAISDirectory = cmd.ExecuteScalar()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
        BAISFileNewDirectory = cmd.ExecuteScalar()
        CloseSqlConnections()

        '***********AUTOMATED BAIS IMPORT****************
        If BaisAutomatedImport_btn_clicked = True Then

            Try
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAISForms Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Dim dt_NGS_Folders As New DataTable
                dt_NGS_Folders.Rows.Clear()
                Dim dt_NGS_Row As DataRow
                dt_NGS_Folders.Columns.Add("FileName", GetType(String))

                If Directory.Exists(BAISDirectory) Then
                    Dim dir As New DirectoryInfo(BAISDirectory)
                    Dim directories As DirectoryInfo() = dir.GetDirectories()
                    For Each directory As DirectoryInfo In directories
                        dt_NGS_Row = dt_NGS_Folders.NewRow
                        dt_NGS_Row("FileName") = directory.Name
                        dt_NGS_Folders.Rows.Add(dt_NGS_Row)
                    Next
                End If

                OpenSqlConnections()
                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles 
                                   CREATE TABLE #Temp_DataFiles (ID int IDENTITY(1,1),FileName nvarchar(255) NULL)"
                cmd.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAISForms File Names in Table: #Temp_DataFiles")
                For Each dr As DataRow In dt_NGS_Folders.Rows
                    Dim sc As New SqlCommand("INSERT INTO #Temp_DataFiles ([FileName])" &
                                            " VALUES (@column1)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.ExecuteNonQuery()
                Next
                Me.BgwBAISimport.ReportProgress(30, "Set FileName as numbers in table: #Temp_DataFiles")
                cmd.CommandText = "UPDATE #Temp_DataFiles SET FileName=[dbo].[fn_StripCharacters](FileName, '^0-9')"
                cmd.ExecuteNonQuery()

                'clear datatable
                dt_NGS_Folders.Clear()
                dt_NGS_Folders.Rows.Clear()

                Me.BgwBAISimport.ReportProgress(45, "Delete from Table: #Temp_DataFiles where FileName <= Last NGS Import File: " & Me.LastBaisImportFile.Text)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName]<='" & Me.LastBaisImportFile.Text & "'"
                cmd.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(50, "Delete from Table: #Temp_DataFiles where FileName >= Current Date: " & CurDateSql)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName]>='" & CurDateSql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(50, "Select all File Names for Import")
                QueryText = "SELECT [FileName] FROM [#Temp_DataFiles] ORDER BY [FileName] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwBAISimport.ReportProgress(50, "Determine the next BAISForms File for Import...Please wait...")
                If dt.Rows.Count > 0 Then
                    For m = 0 To dt.Rows.Count - 1
                        CBAIF = 0
                        CBAIF = dt.Rows.Item(m).Item("FileName")
                        rd = DateSerial(Microsoft.VisualBasic.Left(CBAIF, 4), Mid(CBAIF, 5, 2), Microsoft.VisualBasic.Right(CBAIF, 2))
                        rdsql = rd.ToString("yyyyMMdd")
                        If Me.BgwBAISimport.CancellationPending = False Then
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_CBAIF))
                            '*******************************************************************************
                            Dim LCBAIF As String = CBAIF

                            If Not Directory.Exists(BAISFileNewDirectory) Then
                                Directory.CreateDirectory(BAISFileNewDirectory)
                            ElseIf Directory.Exists(BAISFileNewDirectory) Then
                                Directory.Delete(BAISFileNewDirectory, True)
                                Directory.CreateDirectory(BAISFileNewDirectory)
                            End If

                            '+++++++++++++++++++++++++++++++++++++++
                            Me.BgwBAISimport.ReportProgress(60, "BAISForms File for Import: " & "  " & CBAIF & " is ready")
                            Me.BgwBAISimport.ReportProgress(70, "Starting the BAISForms Import procedures...")


                            BAISFORMS_IMPORT_PROCEDURES()

                            CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"

                            'Erstellten Ordner wieder löschen
                            Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                            If Directory.Exists(BAISFileNewDirectory) Then
                                Directory.Delete(BAISFileNewDirectory, True)
                            End If

                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwBAISimport.ReportProgress(90, "Set as Last imported BAIS File Name: " & "  " & CBAIF)
                            cmd.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CBAIF & "' WHERE [SYSTEM_NAME] in ('BAIS_Forms')"
                            cmd.ExecuteNonQuery()

                            LBAIF = CBAIF
                            Me.LastBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_LBAIF))
                            CBAIF = Nothing
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Clear_CBAIF))

                            'Füllen des Table adapters
                            Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwBAISimport.ReportProgress(95, "BAISForms File Import: " & " " & LCBAIF & " " & "is finished ...")
                            Me.BgwBAISimport.ReportProgress(100, "BAISForms Import finished ...")
                            CURRENT_PROC = Nothing

                        ElseIf Me.BgwBAISimport.CancellationPending = True Then
                            Me.BgwBAISimport.ReportProgress(100, "BAISForms Imports are terminated after user request!")
                            e.Cancel = True

                        End If

                    Next m
                End If

                'Löschen der Temporären Tabelen für den NGS Import
                Me.BgwBAISimport.ReportProgress(100, "Delete Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()

            Catch ex As System.Exception
                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAISForms file: " & " " & Me.CurrentBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwBAISimport.CancelAsync()
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If
            End Try
            '*****************************************************************************
        End If


        '****************SELECTED BAIS FILE IMPORT************************************
        If BaisSelectedFileImport_btn_clicked = True Then
            Try
                CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"
                'Ermitteln der directory und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAISForms Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                OpenSqlConnections()
                If Directory.Exists(BAISDirectory) Then
                    Dim BaisFileName As String = Me.SelectedBaisImportFile.Text 'File for Import
                    CBAIF = 0
                    CBAIF = CDbl(BaisFileName)
                    'Define Business Date based on the BAIS File Name
                    rd = DateSerial(Microsoft.VisualBasic.Left(CBAIF, 4), Mid(CBAIF, 5, 2), Microsoft.VisualBasic.Right(CBAIF, 2))
                    rdsql = rd.ToString("yyyyMMdd")

                    If Not Directory.Exists(BAISFileNewDirectory) Then
                        Directory.CreateDirectory(BAISFileNewDirectory)
                    ElseIf Directory.Exists(BAISFileNewDirectory) Then
                        Directory.Delete(BAISFileNewDirectory, True)
                        Directory.CreateDirectory(BAISFileNewDirectory)
                    End If

                    '+++++++++++++++++++++++++++++++++++++++
                    Me.BgwBAISimport.ReportProgress(60, "BAISForms File for Import: " & "  " & CBAIF & " is ready")
                    Me.BgwBAISimport.ReportProgress(70, "Starting the BAISForms Import procedures...")


                    BAISFORMS_IMPORT_PROCEDURES()

                    CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"

                    '++++++++++++++++++++++++++++++++++++++++++++++
                    'Erstellten Ordner wieder löschen
                    Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                    If Directory.Exists(BAISFileNewDirectory) Then
                        Directory.Delete(BAISFileNewDirectory, True)
                    End If

                    Me.BgwBAISimport.ReportProgress(95, "BAISForms File Import: " & " " & BaisFileName & " " & "is finished ...")
                    Me.BgwBAISimport.ReportProgress(100, "BAISForms Import finished ...")
                    CURRENT_PROC = Nothing

                Else
                    MessageBox.Show("BAISForms File: " & SelectedBaisImportFile.Text & " does not exists!", "BAISFORMS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                CloseSqlConnections()


            Catch ex As Exception

                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAISForms File: " & " " & Me.SelectedBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub

            Finally
                Me.BgwBAISimport.CancelAsync()
                'Directory Löschen
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If

            End Try
        End If
        '***********************************************************************************************

        '***********************BAIS IMPORT FROM...TILL*************************
        If BaisImportFromTill_btn_clicked = True Then
            Try
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAISForms Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                Dim dt_NGS_Folders As New DataTable
                dt_NGS_Folders.Rows.Clear()
                Dim dt_NGS_Row As DataRow
                dt_NGS_Folders.Columns.Add("FileName", GetType(String))

                If Directory.Exists(BAISDirectory) Then
                    Dim dir As New DirectoryInfo(BAISDirectory)
                    Dim directories As DirectoryInfo() = dir.GetDirectories()
                    For Each directory As DirectoryInfo In directories
                        dt_NGS_Row = dt_NGS_Folders.NewRow
                        dt_NGS_Row("FileName") = directory.Name
                        dt_NGS_Folders.Rows.Add(dt_NGS_Row)
                    Next
                End If

                OpenSqlConnections()
                Me.BgwBAISimport.ReportProgress(25, "Create Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles 
                                   CREATE TABLE #Temp_DataFiles (ID int IDENTITY(1,1),FileName nvarchar(255) NULL)"
                cmd.ExecuteNonQuery()
                Me.BgwBAISimport.ReportProgress(30, "Insert BAISForms File Names in Table: #Temp_DataFiles")
                For Each dr As DataRow In dt_NGS_Folders.Rows
                    Dim sc As New SqlCommand("INSERT INTO #Temp_DataFiles ([FileName])" &
                                            " VALUES (@column1)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.ExecuteNonQuery()
                Next
                Me.BgwBAISimport.ReportProgress(30, "Set FileName as numbers in table: #Temp_DataFiles")
                cmd.CommandText = "UPDATE #Temp_DataFiles SET FileName=[dbo].[fn_StripCharacters](FileName, '^0-9')"
                cmd.ExecuteNonQuery()

                'clear datatable
                dt_NGS_Folders.Clear()
                dt_NGS_Folders.Rows.Clear()

                Me.BgwBAISimport.ReportProgress(45, "Delete from Table: #Temp_DataFiles where FileName <= Last NGS Import File: " & Me.LastBaisImportFile.Text)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName] NOT BETWEEN '" & Me.BaisImportFileFrom.Text & "' and '" & Me.BaisImportFileTill.Text & "'"
                cmd.ExecuteNonQuery()

                Me.BgwBAISimport.ReportProgress(50, "Select all File Names for Import")
                QueryText = "SELECT [FileName] FROM [#Temp_DataFiles] ORDER BY [FileName] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwBAISimport.ReportProgress(50, "Determine the next BAISForms File for Import...Please wait...")
                If dt.Rows.Count > 0 Then
                    For m = 0 To dt.Rows.Count - 1
                        CBAIF = 0
                        CBAIF = dt.Rows.Item(m).Item("FileName")
                        rd = DateSerial(Microsoft.VisualBasic.Left(CBAIF, 4), Mid(CBAIF, 5, 2), Microsoft.VisualBasic.Right(CBAIF, 2))
                        rdsql = rd.ToString("yyyyMMdd")
                        If Me.BgwBAISimport.CancellationPending = False Then
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_CBAIF))
                            '*******************************************************************************
                            Dim LCBAIF As String = CBAIF

                            If Not Directory.Exists(BAISFileNewDirectory) Then
                                Directory.CreateDirectory(BAISFileNewDirectory)
                            ElseIf Directory.Exists(BAISFileNewDirectory) Then
                                Directory.Delete(BAISFileNewDirectory, True)
                                Directory.CreateDirectory(BAISFileNewDirectory)
                            End If

                            '+++++++++++++++++++++++++++++++++++++++
                            Me.BgwBAISimport.ReportProgress(60, "BAISForms File for Import: " & "  " & CBAIF & " is ready")
                            Me.BgwBAISimport.ReportProgress(70, "Starting the BAISForms Import procedures...")


                            BAISFORMS_IMPORT_PROCEDURES()

                            CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"

                            'Erstellten Ordner wieder löschen
                            Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                            If Directory.Exists(BAISFileNewDirectory) Then
                                Directory.Delete(BAISFileNewDirectory, True)
                            End If

                            LBAIF = CBAIF
                            Me.LastBaisImportFile.BeginInvoke(New ChangeText(AddressOf Change_LBAIF))
                            CBAIF = Nothing
                            Me.CurrentBaisImportFile.BeginInvoke(New ChangeText(AddressOf Clear_CBAIF))

                            'Füllen des Table adapters
                            Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwBAISimport.ReportProgress(95, "BAISForms File Import: " & " " & LCBAIF & " " & "is finished ...")
                            Me.BgwBAISimport.ReportProgress(100, "BAISForms Import finished ...")
                            CURRENT_PROC = Nothing

                        ElseIf Me.BgwBAISimport.CancellationPending = True Then
                            Me.BgwBAISimport.ReportProgress(100, "BAISForms Imports are terminated after user request!")
                            e.Cancel = True

                        End If

                    Next m
                End If

                'Löschen der Temporären Tabelen für den NGS Import
                Me.BgwBAISimport.ReportProgress(100, "Delete Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()

            Catch ex As System.Exception
                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAISForms file: " & " " & Me.CurrentBaisImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwBAISimport.CancelAsync()
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If
            End Try
            '*****************************************************************************
        End If


        '+++++++++++++++++++++++++++++BAIS IMPORT MANUAL from BUTTON+++++++++++++++++++++++++
        If BaisImportManual_btn_clicked = True Then
            Try
                CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS_MANUAL"
                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwBAISimport.ReportProgress(20, "BAISForms Directory - Current: " & BAISDirectory & " - Temporary: " & BAISFileNewDirectory)

                OpenSqlConnections()
                If Directory.Exists(BAISDirectory) Then
                    'Define Business Date based on the BAIS File Name
                    rd = rd_Entered
                    rdsql = rd.ToString("yyyyMMdd")

                    If Not Directory.Exists(BAISFileNewDirectory) Then
                        Directory.CreateDirectory(BAISFileNewDirectory)
                    ElseIf Directory.Exists(BAISFileNewDirectory) Then
                        Directory.Delete(BAISFileNewDirectory, True)
                        Directory.CreateDirectory(BAISFileNewDirectory)
                    End If

                    '+++++++++++++++++++++++++++++++++++++++
                    Me.BgwBAISimport.ReportProgress(60, "BAISForms File for Import: " & "  " & CBAIF & " is ready")
                    Me.BgwBAISimport.ReportProgress(70, "Starting the BAISForms Import procedures...")


                    'PROCEDUREN
                    BAISFORMS_IMPORT_PROCEDURES_MANUAL()

                    CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS_MANUAL"

                    '++++++++++++++++++++++++++++++++++++++++++++++
                    'Erstellten Ordner wieder löschen
                    Me.BgwBAISimport.ReportProgress(85, "Delete Directory: " & "  " & BAISFileNewDirectory)
                    If Directory.Exists(BAISFileNewDirectory) Then
                        Directory.Delete(BAISFileNewDirectory, True)
                    End If

                    Me.BgwBAISimport.ReportProgress(95, "BAISForms File Import: " & " " & CBAIF.ToString & " " & "is finished ...")
                    Me.BgwBAISimport.ReportProgress(100, "BAISForms Import finished ...")
                    CURRENT_PROC = Nothing

                Else
                    MessageBox.Show("BAISForms File: " & CBAIF & " does not exists!", "BAISFORMS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                CloseSqlConnections()


            Catch ex As Exception

                Me.BgwBAISimport.ReportProgress(0, "ERROR +++Import Procedure for BAIS INTERFACE File: " & " " & CBAIF.ToString & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub

            Finally
                Me.BgwBAISimport.CancelAsync()
                'Directory Löschen
                If Directory.Exists(BAISFileNewDirectory) = True Then
                    Directory.Delete(BAISFileNewDirectory, True)
                End If

            End Try
        End If


    End Sub

    Private Sub BgwBAISimport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBAISimport.ProgressChanged
        Me.EVENTSloadtext.Text = e.UserState
        Me.BAISProgressBar.Value = e.ProgressPercentage
        Me.CURRENT_PROCEDURE_Text.Text = CURRENT_PROC

        OpenEVENT_SqlConnection()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName])  
                                    Values('" & Me.EVENTSloadtext.Text & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','BAIS FORMS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BAIS FORMS" & "  " & Me.EVENTSloadtext.Text & "  " & CURRENT_PROC
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','BAIS FORMS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BAIS FORMS" & "  " & Me.EVENTSloadtext.Text & "  " & CURRENT_PROC
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        CloseEVENT_SqlConnection()


        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub BgwBAISimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBAISimport.RunWorkerCompleted
        CurrentSystemExecuting = Nothing
        ENABLE_FINISH_IMPORT()
        Me.LayoutControlGroup2.Visibility = LayoutVisibility.Always
        Me.SelectedBaisImportFile.Text = ""
        Me.BaisImportFileFrom.Text = ""
        Me.BaisImportFileTill.Text = ""
        'Set Button Click as default to False
        BaisAutomatedImport_btn_clicked = False
        BaisSelectedFileImport_btn_clicked = False
        BaisImportFromTill_btn_clicked = False
        BaisImportManual_btn_clicked = False
        Me.FILES_IMPORTTableAdapter.FillByBAIS_Forms(Me.EDPDataSet.FILES_IMPORT)

        CloseSqlConnections()

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

#Region "MANUAL IMPORTS FROM BUTTON"

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
        'e.Form.CancelButton.DialogResult = DialogResult.None
        e.Form.CloseBox = False
        If e.Form.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If
        If e.Form.DialogResult = DialogResult.OK Then
            Exit Sub
        End If
    End Sub

    Private Sub StartImport_RepositoryItemButtonEdit_Click(sender As Object, e As EventArgs) Handles StartImport_RepositoryItemButtonEdit.Click

        If OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colValid) = "Y" Then
            If OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colRequestBusinessDate) = "Y" Then
                ' initialize a new XtraInputBoxArgs instance
                Dim args As New XtraInputBoxArgs()
                ' set required Input Box options
                args.Caption = "Enter the Business Date for the procedure execution"
                args.Prompt = "Business Date"
                args.DefaultButtonIndex = 0
                AddHandler args.Showing, AddressOf Args_Showing
                ' initialize a DateEdit editor with custom settings
                Dim editor As New DateEdit()
                editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
                editor.Properties.Mask.EditMask = "yyyyMMdd"
                args.Editor = editor
                ' a default DateEdit value
                args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                ' display an Input Box with the custom editor

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                End If
                If IsDate(obj) = True Then
                    rd_Entered = CDate(obj)
                    rdsql_Entered = rd_Entered.ToString("yyyyMMdd")
                    CBAIF = CDbl(rdsql_Entered)

                    If XtraMessageBox.Show("Should the BAISForms Import Procedure: " & OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) & " be executed for Business Date: " & rd_Entered & " ?", "Start BAISForms manual Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        BaisAutomatedImport_btn_clicked = False
                        BaisSelectedFileImport_btn_clicked = False
                        BaisImportFromTill_btn_clicked = False
                        BaisImportManual_btn_clicked = True

                        Me.LayoutControlGroup2.Visibility = LayoutVisibility.Never
                        DISABLE_START_IMPORT()
                        If Me.BgwBAISimport.IsBusy = False Then
                            Me.BgwBAISimport.RunWorkerAsync()
                        End If
                    End If


                End If
            Else
                Return
            End If

        Else
            XtraMessageBox.Show("The selected procedure is not valid!" & vbNewLine & "Please change the Status of this procedure!", "PROCEDURE NOT VALID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return

        End If ' Request Business Date



    End Sub


#End Region

    Private Sub BAISFORMS_IMPORT_PROCEDURES()
        Me.BgwBAISimport.ReportProgress(50, "Select all valid procedures")
        QueryText = "SELECT * FROM [BAISFORMS_IMPORT_PROCEDURES] where [Valid] in ('Y') ORDER BY [LfdNr] asc"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For p = 0 To dt1.Rows.Count - 1
                Dim ProcedureName As String = dt1.Rows.Item(p).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = ProcedureName & " for file " & CBAIF.ToString
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(p).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(p).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(p).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(p).Item("FileConvertion")


                Me.BgwBAISimport.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters_Details]
                             in (SELECT ID from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('BAIS_FORMS_IMPORT') 
                             and [Id_SQL_Parameters] in ('BAIS'))"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwBAISimport.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        Dim FolderNameImport As String = dt1.Rows.Item(p).Item("FolderNameImport")
                        Dim FileNameImport As String = dt1.Rows.Item(p).Item("FileNameImport")
                        'Replace folder and fileName with COBIF
                        FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", CBAIF.ToString)
                        FileNameImport = FileNameImport.Replace("<YYYYMMDD>", CBAIF.ToString)
                        Me.BgwBAISimport.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                        Me.BgwBAISimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        'Check if file is zip/rar for extraction
                        If FileExtraction = "Y" Then
                            Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                            If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an zip/rar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                        For Each item As ZipItem In archive
                                            If String.Compare(item.Name.Trim, FileNameImport.Trim) = 0 Then
                                                item.Extract(BAISFileNewDirectory, True)
                                                Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & BAISFileNewDirectory)
                                            End If
                                        Next item
                                    End Using
                                Else
                                    Me.BgwBAISimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an tar.gz archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    ExtractTGZ(FolderNameImport, BAISFileNewDirectory)
                                    Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & BAISFileNewDirectory)
                                Else
                                    Me.BgwBAISimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            Else
                                Me.BgwBAISimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " is not recognited as archive file")
                                Exit Sub
                            End If
                        ElseIf FileExtraction = "N" Then
                            'Set correct directory format for the imported files
                            BAISFileNewDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                            BAISFileNewDirectory = cmd.ExecuteScalar()
                            Me.BgwBAISimport.ReportProgress(50, "Set Import directory to:" & BAISFileNewDirectory & "\")
                            Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " will copied to directory:" & BAISFileNewDirectory & "\")
                            File.Copy(Path.Combine(FolderNameImport, FileNameImport), Path.Combine(BAISFileNewDirectory & "\", FileNameImport), True)
                        End If

                        'Set correct directory format for the imported files
                        BAISFileNewDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                        BAISFileNewDirectory = cmd.ExecuteScalar()
                        Me.BgwBAISimport.ReportProgress(50, "Set Import directory to:" & BAISFileNewDirectory & "\")
                        BAISFileNewDirectory = BAISFileNewDirectory & "\"

                        'Remove all file attributes
                        Me.BgwBAISimport.ReportProgress(50, "Remove all Attributes from file:" & FileNameImport)
                        SetAttr(BAISFileNewDirectory & FileNameImport, vbNormal)


                        'FileConvertion
                        If FileConvertion <> "N" Then
                            Select Case FileConvertion
                                Case = "XLS_TO_XLSX"
                                    Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                        Me.BgwBAISimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(BAISFileNewDirectory & FileNameImport)
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(BAISFileNewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(BAISFileNewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                        Me.BgwBAISimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                                Case = "CSV_TO_XLSX"
                                    Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                        Me.BgwBAISimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(BAISFileNewDirectory & FileNameImport)
                                        ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(BAISFileNewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(BAISFileNewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                        Me.BgwBAISimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                            End Select
                        End If

                        'Start checking and executing SQL Parameters
                        Me.BgwBAISimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_THIRD] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwBAISimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            Dim CUR_FILE_DIR_IMPORT As String = BAISFileNewDirectory & FileNameImport
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwBAISimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            Exit Sub
                        End If

                    ElseIf ExectutionType = "SCRIPT" Then
                        Me.BgwBAISimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwBAISimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_THIRD] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwBAISimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwBAISimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            Exit Sub
                        End If

                    End If
                Else
                    Me.BgwBAISimport.ReportProgress(50, "WARNING +++ Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT")
                    Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            Next
        End If





    End Sub

    Private Sub BAISFORMS_IMPORT_PROCEDURES_MANUAL()
        Me.BgwBAISimport.ReportProgress(50, "Select all valid procedures")
        QueryText = "SELECT * FROM [BAISFORMS_IMPORT_PROCEDURES] where ID=" & ID_Selected & " and [Valid] in ('Y')"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For p = 0 To dt1.Rows.Count - 1
                Dim ProcedureName As String = dt1.Rows.Item(p).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = ProcedureName & " for file " & CBAIF.ToString
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(p).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(p).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(p).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(p).Item("FileConvertion")


                Me.BgwBAISimport.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters_Details]
                             in (SELECT ID from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('BAIS_FORMS_IMPORT') 
                             and [Id_SQL_Parameters] in ('BAIS'))"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwBAISimport.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        Dim FolderNameImport As String = dt1.Rows.Item(p).Item("FolderNameImport")
                        Dim FileNameImport As String = dt1.Rows.Item(p).Item("FileNameImport")
                        'Replace folder and fileName with COBIF
                        FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", CBAIF.ToString)
                        FileNameImport = FileNameImport.Replace("<YYYYMMDD>", CBAIF.ToString)
                        Me.BgwBAISimport.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                        Me.BgwBAISimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        'Check if file is zip/rar for extraction
                        If FileExtraction = "Y" Then
                            Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                            If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an zip/rar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                        For Each item As ZipItem In archive
                                            If String.Compare(item.Name.Trim, FileNameImport.Trim) = 0 Then
                                                item.Extract(BAISFileNewDirectory, True)
                                                Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & BAISFileNewDirectory)
                                            End If
                                        Next item
                                    End Using
                                Else
                                    Me.BgwBAISimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an tar.gz archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwBAISimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    ExtractTGZ(FolderNameImport, BAISFileNewDirectory)
                                    Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & BAISFileNewDirectory)
                                Else
                                    Me.BgwBAISimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            Else
                                Me.BgwBAISimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " is not recognited as archive file")
                                Exit Sub
                            End If
                        ElseIf FileExtraction = "N" Then
                            'Set correct directory format for the imported files
                            BAISFileNewDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                            BAISFileNewDirectory = cmd.ExecuteScalar()
                            Me.BgwBAISimport.ReportProgress(50, "Set Import directory to:" & BAISFileNewDirectory & "\")
                            Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " will copied to directory:" & BAISFileNewDirectory & "\")
                            File.Copy(Path.Combine(FolderNameImport, FileNameImport), Path.Combine(BAISFileNewDirectory & "\", FileNameImport), True)
                        End If

                        'Set correct directory format for the imported files
                        BAISFileNewDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='BAIS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='BAIS_IMPORT'"
                        BAISFileNewDirectory = cmd.ExecuteScalar()
                        Me.BgwBAISimport.ReportProgress(50, "Set Import directory to:" & BAISFileNewDirectory & "\")
                        BAISFileNewDirectory = BAISFileNewDirectory & "\"

                        'Remove all file attributes
                        Me.BgwBAISimport.ReportProgress(50, "Remove all Attributes from file:" & FileNameImport)
                        SetAttr(BAISFileNewDirectory & FileNameImport, vbNormal)


                        'FileConvertion
                        If FileConvertion <> "N" Then
                            Select Case FileConvertion
                                Case = "XLS_TO_XLSX"
                                    Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                        Me.BgwBAISimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(BAISFileNewDirectory & FileNameImport)
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(BAISFileNewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(BAISFileNewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                        Me.BgwBAISimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                                Case = "CSV_TO_XLSX"
                                    Me.BgwBAISimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                        Me.BgwBAISimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(BAISFileNewDirectory & FileNameImport)
                                        ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(BAISFileNewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(BAISFileNewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                        Me.BgwBAISimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                            End Select
                        End If

                        'Start checking and executing SQL Parameters
                        Me.BgwBAISimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_THIRD] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwBAISimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            Dim CUR_FILE_DIR_IMPORT As String = BAISFileNewDirectory & FileNameImport
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwBAISimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            Exit Sub
                        End If

                    ElseIf ExectutionType = "SCRIPT" Then
                        Me.BgwBAISimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwBAISimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_THIRD] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwBAISimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwBAISimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwBAISimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT/" & ProcedureName)
                            Exit Sub
                        End If

                    End If
                Else
                    Me.BgwBAISimport.ReportProgress(50, "WARNING +++ Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/BAIS/BAIS_FORMS_IMPORT")
                    Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "BAISFORMS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            Next
        End If





    End Sub



    Private Sub OcbsImportProcedures_BasicView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles OcbsImportProcedures_BasicView.EditFormPrepared
        'Dim view As GridView = TryCast(sender, GridView)
        'CurrentImportProcedureTextEdit = TryCast(e.BindableControls(colProcName), TextEdit)

        If e.BindableControls(OcbsImportProcedures_BasicView.FocusedColumn) IsNot Nothing Then
            e.FocusField(OcbsImportProcedures_BasicView.FocusedColumn)
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles OcbsImportProcedures_BasicView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastUpdateDate"), Now)
        Me.GridControl1.EmbeddedNavigator.Buttons.DoClick(Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit)
    End Sub

    Private Sub OcbsImportProcedures_BasicView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles OcbsImportProcedures_BasicView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ExectutionType"), "IMPORT")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileExtraction"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("RequestBusinessDate"), "Y")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileConvertion"), "N")
    End Sub

    Private Sub OcbsImportProcedures_BasicView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles OcbsImportProcedures_BasicView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentDataView As DataView = TryCast((TryCast(sender, GridView)).DataSource, DataView)
            If view.FocusedColumn.FieldName = "LfdNr" Then
                Dim currentCode As String = e.Value.ToString()
                For i As Integer = 0 To OcbsImportProcedures_BasicView.DataRowCount - 1
                    If i <> view.FocusedRowHandle Then
                        If currentCode.Equals(view.GetRowCellValue(i, colLfdNr).ToString) = True Then
                            e.ErrorText = "Duplicate Parameter Value detected in Field:LfdNr."
                            e.Valid = False
                            Exit For
                        End If
                    End If

                Next
            End If
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles OcbsImportProcedures_BasicView.RowCellClick
        ID_Selected = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            ID_Selected = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
        If e.Column.FieldName = "LfdNr" OrElse e.Column.FieldName = "Importance" Then
            view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
        Else
            view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles OcbsImportProcedures_BasicView.FocusedRowChanged
        ID_Selected = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            ID_Selected = CInt(view.GetRowCellValue(rowHandle, colID))
        End If
        If view.FocusedColumn.FieldName = "LfdNr" OrElse view.FocusedColumn.FieldName = "Importance" Then
            view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
        Else
            view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_FocusedColumnChanged(sender As Object, e As FocusedColumnChangedEventArgs) Handles OcbsImportProcedures_BasicView.FocusedColumnChanged
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedColumn.FieldName = "LfdNr" OrElse view.FocusedColumn.FieldName = "Importance" Then
            view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
        Else
            view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles OcbsImportProcedures_BasicView.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.ProceduresGridviewPopupMenu.ShowPopup(GridControl1.PointToScreen(e.Point))
            End If
        End If
    End Sub


    Private Sub ProcedureDuplicateNextPosition_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ProcedureDuplicateNextPosition_bbi.ItemClick
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show("Should the current procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be duplicated in the next row?", "DUPLICATE PROCEDURE - NEXT ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Starting procedure duplication in the next row")

                OpenSqlConnections()
                cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                   DECLARE @CURRENT_USER Nvarchar(50)='<CurrentUser>'
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [BAISFORMS_IMPORT_PROCEDURES] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
												DECLARE @DUBLICATE_ID int=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                              
                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                
                                                INSERT INTO [BAISFORMS_IMPORT_PROCEDURES]
                                                           ([LfdNr]
                                                           ,[ProcName]
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,[LastAction]
                                                           ,[LastUpdateUser]
                                                           ,[LastUpdateDate])
                                                SELECT		[LfdNr]+1
														   ,@Procedure_Name_New
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,'DUPLICATED'
                                                           ,@CURRENT_USER
                                                           ,GETDATE()
                                                FROM [BAISFORMS_IMPORT_PROCEDURES] where ID=@ID_A


                                                SET @DUBLICATE_NR=(select [LfdNr] from [BAISFORMS_IMPORT_PROCEDURES]
                                                where ID not in (Select Min(ID) from [BAISFORMS_IMPORT_PROCEDURES] 
												group by [LfdNr]))

												
                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR

                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[LfdNr] from [BAISFORMS_IMPORT_PROCEDURES] 
                                                where ID in (Select Min(ID) from [BAISFORMS_IMPORT_PROCEDURES] 
												where [LfdNr]=@DUBLICATE_NR)

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[LfdNr]+@NEW_RUNNING_NR from [BAISFORMS_IMPORT_PROCEDURES]
                                                where ID in (Select Min(ID) from [BAISFORMS_IMPORT_PROCEDURES] 
												where [LfdNr] >=@DUBLICATE_NR
                                                group by [LfdNr]) order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[LfdNr]=B.Number from [BAISFORMS_IMPORT_PROCEDURES] A INNER JOIN @ID_4 B on A.ID=B.ID "
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                focusedView.RefreshData()
                focusedView.FocusedRowHandle = GetFocusedRow

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ProcedureDuplicateNewPosition_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles ProcedureDuplicateNewPosition_bbi.ItemClick
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        Dim rowHandle As Integer = focusedView.FocusedRowHandle
        GetFocusedRow = focusedView.FocusedRowHandle

        If XtraMessageBox.Show("Should the current procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be duplicated in a new row?", "DUPLICATE PROCEDURE - NEW ROW", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Starting procedure duplication in a new row")

                OpenSqlConnections()
                cmd.CommandText = "DECLARE @ID_A int=<ID_to_DUPLICATE>
                                   DECLARE @CURRENT_USER Nvarchar(50)='<CurrentUser>'
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [BAISFORMS_IMPORT_PROCEDURES] where ID=@ID_A)
                                                DECLARE @MAX_LFD_NR float=(Select MAX(LfdNr) from [BAISFORMS_IMPORT_PROCEDURES])
												
                                                INSERT INTO [BAISFORMS_IMPORT_PROCEDURES]
                                                           ([LfdNr]
                                                           ,[ProcName]
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,[LastAction]
                                                           ,[LastUpdateUser]
                                                           ,[LastUpdateDate])
                                                SELECT		@MAX_LFD_NR+1
														   ,@Procedure_Name_New
                                                           ,[Valid]
                                                           ,[Importance]
                                                           ,[InternalNotes]
                                                           ,[FolderNameImport]
                                                           ,[FileNameImport]
                                                           ,[ExectutionType]
                                                           ,[FileExtraction]
                                                           ,[RequestBusinessDate]
                                                           ,[FileConvertion]
                                                           ,'DUPLICATED'
                                                           ,@CURRENT_USER
                                                           ,GETDATE()
                                                FROM [BAISFORMS_IMPORT_PROCEDURES] where ID=@ID_A"
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.BAISFORMS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.BAISFORMS_IMPORT_PROCEDURES)
                focusedView.RefreshData()
                focusedView.FocusedRowHandle = GetFocusedRow

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BAISImportEvents_BasicView_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles BAISImportEvents_BasicView.CustomDrawCell
        Dim AlertImage As Image = Me.ImageCollection1.Images.Item(21)
        Dim OkImage As Image = Me.ImageCollection1.Images.Item(14)
        Dim ErrorImage As Image = Me.ImageCollection1.Images.Item(20)
        If e.Column.FieldName = "Event" And e.RowHandle >= 0 Then
            'e.Cache.DrawImage(If(Convert.ToString(e.CellValue).StartsWith("ERROR") = True, Image1, Image2), e.Bounds.Location)
            'e.Handled = True

            e.DefaultDraw()

            Dim xPos As Integer = (((e.Bounds.Location.X + e.Bounds.Width) - AlertImage.Width) - 2)
            Dim yPos As Integer = (e.Bounds.Location.Y + 1)
            Dim imagePoint As Point = New Point(xPos, yPos)

            If Convert.ToString(e.CellValue).StartsWith("Unable") Then
                e.Cache.DrawImage(AlertImage, imagePoint)
            ElseIf Convert.ToString(e.CellValue).StartsWith("WARNING") Then
                e.Cache.DrawImage(AlertImage, imagePoint)
            ElseIf Convert.ToString(e.CellValue).StartsWith("ERROR") Then
                e.Cache.DrawImage(ErrorImage, imagePoint)
            Else
                e.Cache.DrawImage(OkImage, imagePoint)
            End If
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OcbsImportProcedures_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim LFD_NR As GridColumn = View.Columns("LfdNr")
        Dim PROC_NAME As GridColumn = View.Columns("ProcName")
        Dim FOLDER_NAME_IMPORT As GridColumn = View.Columns("FolderNameImport")
        Dim FILE_NAME_IMPORT As GridColumn = View.Columns("FileNameImport")
        Dim PROC_VALIDITY As GridColumn = View.Columns("Valid")
        Dim IMPORTANCE_STATUS As GridColumn = View.Columns("Importance")
        Dim EXECUTION_TYPE As GridColumn = View.Columns("ExectutionType")
        Dim FILE_EXTRACTION As GridColumn = View.Columns("FileExtraction")
        Dim REQUEST_BUSINESS_DATE As GridColumn = View.Columns("RequestBusinessDate")
        Dim FILE_CONVERTION As GridColumn = View.Columns("FileConvertion")

        Dim LfdNr As String = View.GetRowCellValue(e.RowHandle, colLfdNr).ToString
        Dim ProcName As String = View.GetRowCellValue(e.RowHandle, colProcName).ToString
        Dim FolderNameImport As String = View.GetRowCellValue(e.RowHandle, colFolderNameImport).ToString
        Dim FileNameImport As String = View.GetRowCellValue(e.RowHandle, colFileNameImport).ToString
        Dim ProcValidity As String = View.GetRowCellValue(e.RowHandle, colValid).ToString
        Dim ImportanceStatus As String = View.GetRowCellValue(e.RowHandle, colImportance).ToString
        Dim ExecutionType As String = View.GetRowCellValue(e.RowHandle, colExectutionType).ToString
        Dim FileExtraction As String = View.GetRowCellValue(e.RowHandle, colFileExtraction).ToString
        Dim RequestBusinessDate As String = View.GetRowCellValue(e.RowHandle, colRequestBusinessDate).ToString
        Dim FileConvertion As String = View.GetRowCellValue(e.RowHandle, colFileConvertion).ToString

        If LfdNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(LFD_NR, "The Procedure Nr. must not be empty")
            e.ErrorText = "The Procedure Nr. must not be empty"
        End If
        If ProcName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_NAME, "The Procedure Name must not be empty")
            e.ErrorText = "The Procedure Name must not be empty"
        End If
        If ExecutionType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(EXECUTION_TYPE, "The Execution Type must not be empty")
            e.ErrorText = "The Execution Type must not be empty"
        End If
        If FolderNameImport = "" And ExecutionType = "IMPORT" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FOLDER_NAME_IMPORT, "The Folder Name for import must not be empty if the Execution Type is IMPORT")
            e.ErrorText = "The Folder Name for import must not be empty if the Execution Type is IMPORT"
        End If
        If FileNameImport = "" And ExecutionType = "IMPORT" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_NAME_IMPORT, "The File Name for import must not be empty if the Execution Type is IMPORT")
            e.ErrorText = "The File Name for import must not be empty if the Execution Type is IMPORT"
        End If
        If ProcValidity = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_VALIDITY, "The Validity  must not be empty")
            e.ErrorText = "The Validity  must not be empty"
        End If
        If ImportanceStatus = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(IMPORTANCE_STATUS, "The Importance Status  must not be empty")
            e.ErrorText = "The Importance Status  must not be empty"
        End If
    End Sub


End Class