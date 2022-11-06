Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text
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
Imports GemBox.Spreadsheet
Imports DevExpress.Compression
Imports Ionic.Zip


Public Class OdasImport

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
    Dim SqlCommandText1 As String = Nothing
    Dim SqlCommandText2 As String = Nothing
    Dim SqlCommandText3 As String = Nothing

    Dim ParameterStatus As String = Nothing
    Dim HasDataResult As String = Nothing
    Dim SqlCommandText As String = Nothing

    Dim CrystalRepDir As String = ""
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
    Private dt2 As New DataTable
    Private da3 As New SqlDataAdapter
    Private dt3 As New DataTable
    Dim ex As Integer
    Dim OdasAutomatedImport_btn_clicked As Boolean = False 'Button for Automated Import
    Dim OdasSelectedFileImport_btn_clicked As Boolean = False 'Button for single File import
    Dim OdasImportFromTill_btn_clicked As Boolean = False
    Dim CURRENT_LAST_IMPORTED_ODAS_FILE As Double = Nothing

    Dim MaxProcDate As Date

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim EMAIL_USERS As String = Nothing

    Dim pathToZipArchive As String = Nothing
    Dim currentArchive As ZipArchive
    Dim item As ZipItem

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

    'Change the Current ODAS File in Form
    Public Sub Change_COIF()
        Me.CurrentOdasImportFile.Text = COIF
    End Sub

    'Change the Last ODAS Import File in Form
    Public Sub Change_LOIF()
        Me.LastOdasImportFile.Text = LOIF
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

    'Show Progress in a ODAS Excel File with 5000 Rows
    Public Sub PROGRESS_ODAS_MAX5()
        Me.ODASProgressBar.Maximum = 5000
    End Sub

    'Show Progress in a ODAS Excel File with 10000 Rows
    Public Sub PROGRESS_ODAS_MAX10()
        Me.ODASProgressBar.Maximum = 10000
    End Sub

    'Show Progress in a ODAS Excel File-Progress Bar
    Public Sub PROGRESS_ODAS_EXCEL()
        Me.ODASProgressBar.Increment(1)
        If Me.ODASProgressBar.Value = Me.ODASProgressBar.Maximum Then
            Me.ODASProgressBar.Value = 0
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
    Function IsLastDay(ByVal myDate As Date) As Boolean
        Return myDate.Day = Date.DaysInMonth(myDate.Year, myDate.Month)
    End Function
#End Region

#Region "GRIDVIEWS_DEFAULT_SETTINGS"

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.ODAS_IMPORT_PROCEDURESBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ODAS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Activate all Procedures
        If e.Button.Tag = "ActivateProcs" Then
            Try
                If MessageBox.Show("Should all current Procedures be activated", "ACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    cmd.CommandText = "UPDATE [ODAS IMPORT PROCEDURES] SET [Valid]='Y' where [Importance] in ('MANDATORY')"
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Activate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ODAS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Deactivate all Procedures
        If e.Button.Tag = "DeactivateProcs" Then
            Try
                If MessageBox.Show("Should all current Procedures be Deactivated", "DEACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    cmd.CommandText = "UPDATE [ODAS IMPORT PROCEDURES] SET [Valid]='N'"
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Deactivate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ODAS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Terminate all Procedures
        If e.Button.Tag = "Terminate" Then
            If Me.BgwODASimport.IsBusy = True Then
                If MessageBox.Show("Should the ODAS import procedures be terminated?", "TERMINATE ODAS IMPORTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwODASimport.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("ODAS Imports termination is requested..." & vbNewLine & "Please wait until the current ODAS Import operations are finished!")
                End If
            End If
        End If

    End Sub
    Private Sub OdasImportProcedures_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles OdasImportProcedures_BasicView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OdasImportProcedures_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles OdasImportProcedures_BasicView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OdasImportProcedures_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OdasImportProcedures_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OdasImportProcedures_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles OdasImportProcedures_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ODASImportEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ODASImportEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ODASImportEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ODASImportEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OdasImportProcedures_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OdasImportProcedures_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PROC_NAME As GridColumn = View.Columns("ProcName")
        Dim PROC_VALIDITY As GridColumn = View.Columns("Valid")
        Dim IMPORTANCE_STATUS As GridColumn = View.Columns("Importance")

        Dim ProcName As String = View.GetRowCellValue(e.RowHandle, colProcName).ToString
        Dim ProcValidity As String = View.GetRowCellValue(e.RowHandle, colValid).ToString
        Dim ImportanceStatus As String = View.GetRowCellValue(e.RowHandle, colImportance).ToString

        If ProcName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_NAME, "The Procedure Name must not be empty")
            e.ErrorText = "The Procedure Name must not be empty"
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

    Private Sub Print_Export_ODAS_ImportProcedures_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ODAS_ImportProcedures_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
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
        Dim reportfooter As String = "ODAS IMPORT PROCEDURES"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_ImportEvents_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_ImportEvents_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalFooterArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalFooterArea
        Dim pinfoBrick As PageInfoBrick, r As RectangleF, iSize As Size
        Try
            iSize = e.Graph.MeasureString(String.Format("Printed: {0:F}M", DateTime.Now)).ToSize
            r = New RectangleF(New PointF(e.Graph.ClientPageSize.Width - iSize.Width, 0), iSize)
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, DevExpress.XtraPrinting.BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink2_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink2.CreateMarginalHeaderArea
        Dim reportfooter As String = "IMPORT EVENTS"

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub
#End Region

#Region "ENABLE_DISABLE_CONTROLS_BY_IMPORT"
    Private Sub DISABLE_START_IMPORT()
        'Set Import settings
        Me.ODASProgressBar.Visible = True
        OdasSelectedImport_btn.Enabled = False
        OdasAutomatedImport_btn.Enabled = False
        OdasFromTillImport_btn.Enabled = False
        LastOdasImportFile.Enabled = False
        SelectedOdasImportFile.Enabled = False
        OdasImportFileFrom.Enabled = False
        OdasImportFileTill.Enabled = False
        'Cancel all Excel applications
        'Excel Instanz beenden
        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
        Dim i1 As Short
        i1 = 0
        For i1 = 0 To (procs.Length - 1)
            procs(i1).Kill()
        Next i1
        '*********************************
    End Sub

    Private Sub ENABLE_FINISH_IMPORT()
        Me.EVENTSloadtext.Text = ""
        Me.ODASProgressBar.Value = 0
        Me.ODASProgressBar.Visible = False
        OdasSelectedImport_btn.Enabled = True
        OdasAutomatedImport_btn.Enabled = True
        OdasFromTillImport_btn.Enabled = True
        LastOdasImportFile.Enabled = True
        SelectedOdasImportFile.Enabled = True
        OdasImportFileFrom.Enabled = True
        OdasImportFileTill.Enabled = True
    End Sub
#End Region

#Region "BUTTONS_AND_EDITORS_EVENTS"
    Private Sub LastOdasImportFile_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LastOdasImportFile.ButtonClick
        If IsNumeric(LastOdasImportFile.Text) = True And Len(LastOdasImportFile.Text) = 8 Then
            If MessageBox.Show("Should the ODAS File Nr. " & LastOdasImportFile.Text & " be saved as Last Imported ODAS file", "CHANGE THE LAST IMPORTED ODAS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Dim LastODASImportFile As Double = Me.LastOdasImportFile.Text
                Me.FILES_IMPORTBindingSource.EndEdit()
                Me.FILES_IMPORTTableAdapter.UpdateODAS_LastImportFile(LastODASImportFile)
                Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)
            Else
                Me.FILES_IMPORTBindingSource.CancelEdit()
                Exit Sub
            End If
        Else
            MessageBox.Show("The indicated ODAS Filename is not correct!", "ODAS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub

        End If
    End Sub

    Private Sub LastOdasImportFile_Leave(sender As Object, e As EventArgs) Handles LastOdasImportFile.Leave
        If IsNumeric(LastOdasImportFile.Text) = False OrElse Len(LastOdasImportFile.Text) <> 8 Then
            MessageBox.Show("The indicated ODAS Filename is not correct!", "ODAS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub
        End If
    End Sub
    Private Sub SelectedOdasImportFile_Leave(sender As Object, e As EventArgs) Handles SelectedOdasImportFile.Leave
        If Me.SelectedOdasImportFile.Text <> "" Then
            If IsNumeric(SelectedOdasImportFile.Text) = False OrElse Len(SelectedOdasImportFile.Text) <> 8 Then
                MessageBox.Show("The indicated ODAS Filename is not correct!", "ODAS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.SelectedOdasImportFile.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OdasImportFileFrom_Leave(sender As Object, e As EventArgs) Handles OdasImportFileFrom.Leave
        If Me.OdasImportFileFrom.Text <> "" Then
            If IsNumeric(OdasImportFileFrom.Text) = False OrElse Len(OdasImportFileFrom.Text) <> 8 Then
                MessageBox.Show("The indicated ODAS Filename is not correct!", "ODAS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.OdasImportFileFrom.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OdasImportFileTill_Leave(sender As Object, e As EventArgs) Handles OdasImportFileTill.Leave
        If Me.OdasImportFileTill.Text <> "" Then
            If IsNumeric(OdasImportFileTill.Text) = False OrElse Len(OdasImportFileTill.Text) <> 8 Then
                MessageBox.Show("The indicated ODAS Filename is not correct!", "ODAS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.OdasImportFileTill.Text = ""
                Exit Sub
            End If
        End If

    End Sub


    Private Sub OdasAutomatedImport_btn_Click(sender As Object, e As EventArgs) Handles OdasAutomatedImport_btn.Click
        OdasAutomatedImport_btn_clicked = True
        OdasSelectedFileImport_btn_clicked = False
        OdasImportFromTill_btn_clicked = False
        If Me.LastOdasImportFile.Text <> "" Then
            If MessageBox.Show("Should the automated ODAS Fileimport be executed?" & vbNewLine & vbNewLine & "ATTENTION!!! - PLEASE SAVE & CLOSE ALL OPEN EXCEL FILES BEFORE START THE IMPORT", "AUTOMATED IMPORT ODAS FILES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwODASimport.IsBusy = False Then
                    Me.BgwODASimport.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub OdasSelectedImport_btn_Click(sender As Object, e As EventArgs) Handles OdasSelectedImport_btn.Click
        OdasSelectedFileImport_btn_clicked = True
        OdasAutomatedImport_btn_clicked = False
        OdasImportFromTill_btn_clicked = False
        If Me.SelectedOdasImportFile.Text <> "" Then
            If MessageBox.Show("Should the ODAS Filename " & SelectedOdasImportFile.Text & " be imported?" & vbNewLine & vbNewLine & "ATTENTION!!! - PLEASE SAVE & CLOSE ALL OPEN EXCEL FILES BEFORE START THE IMPORT", "IMPORT ODAS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwODASimport.IsBusy = False Then
                    Me.BgwODASimport.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub OdasFromTillImport_btn_Click(sender As Object, e As EventArgs) Handles OdasFromTillImport_btn.Click
        OdasImportFromTill_btn_clicked = True
        OdasAutomatedImport_btn_clicked = False
        OdasSelectedFileImport_btn_clicked = False

        If Me.OdasImportFileFrom.Text <> "" AndAlso Me.OdasImportFileTill.Text <> "" Then
            Dim n1 As Double = Me.OdasImportFileFrom.Text
            Dim n2 As Double = Me.OdasImportFileTill.Text
            If n2 >= n1 Then
                If MessageBox.Show("Should the ODAS Import start with Filename " & n1 & " and finish with Filename " & n2 & vbNewLine & vbNewLine & "ATTENTION!!! - PLEASE SAVE & CLOSE ALL OPEN EXCEL FILES BEFORE START THE IMPORT", "IMPORT ODAS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_IMPORT()
                    If Me.BgwODASimport.IsBusy = False Then
                        CURRENT_LAST_IMPORTED_ODAS_FILE = Me.LastOdasImportFile.Text
                        Me.BgwODASimport.RunWorkerAsync()
                    End If
                End If
            Else
                MessageBox.Show("The last Filename is earlier than the first Filename!", "WRONG FILENAMES IMPORT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub
#End Region

#Region "ODAS_IMPORT_BACKGROUNDWORKER"
    Private Sub BgwODASimport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwODASimport.DoWork

        '***********AUTOMATED ODAS IMPORT****************
        If OdasAutomatedImport_btn_clicked = True Then
            Try
                Me.BgwODASimport.ReportProgress(10, "Locate the ODAS Current and Temp Directory...")

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
                    Me.QueryText = "Select  [FileName] as NextFileNameforimport,[FileFullName] as NextFileFullName from [ODAS FILES] where [FileName] in (SELECT min([FileName])FROM [ODAS FILES] where [FileName]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('ODAS')))"
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
                        If Me.BgwODASimport.CancellationPending = False Then
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
                            pathToZipArchive = OdasFileFullName & "\EOD_ODAS_REPORT_DC007_" & COIF & "" & ".zip"
                            '++++++++++++++++++++++++++++++++++++++++++++
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
                            '++++++++++++++++++++++++++++++++++++++++++
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
                            cmdODAS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & COIF & "' WHERE [SYSTEM_NAME] in ('ODAS')"
                            cmdODAS.ExecuteNonQuery()

                            LOIF = COIF
                            Me.LastOdasImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOIF))
                            COIF = Nothing
                            Me.CurrentOdasImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COIF))


                            Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwODASimport.ReportProgress(95, "ODAS File Import: " & " " & LCOIF & " " & "is finished ...")
                            Me.BgwODASimport.ReportProgress(100, "ODAS Import finished ...")
                        ElseIf Me.BgwODASimport.CancellationPending = True Then
                            Me.BgwODASimport.ReportProgress(100, "ODAS Imports are terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                        End If
                    End If

                Next m
                cmdODAS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdODAS.ExecuteNonQuery()
                cmdODAS.CommandText = "DROP TABLE [ODASFilesTemp]"
                cmdODAS.ExecuteNonQuery()
                cmdODAS.CommandText = "DROP TABLE [ODAS FILES]"
                cmdODAS.ExecuteNonQuery()
                cmdODAS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
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
        End If
        '*****************************************************************************


        '****************SELECTED ODAS FILE IMPORT************************************
        If OdasSelectedFileImport_btn_clicked = True Then
            Try
                Me.BgwODASimport.ReportProgress(10, "Locate the ODAS Current and Temp Directory...")
                'Ermitteln der Directories

                cmdODAS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='ODAS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='ODAS_IMPORT'"
                cmdODAS.Connection.Open()
                OdasDirectory = cmdODAS.ExecuteScalar()
                cmdODAS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='ODAS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='ODAS_IMPORT'"
                OdasFileNewDirectory = cmdODAS.ExecuteScalar()

                Me.BgwODASimport.ReportProgress(20, "ODAS Directories - Current: " & OdasDirectory & " - Temporary: " & OdasFileNewDirectory)

                Dim OdasFileFullName As String = OdasDirectory & Me.SelectedOdasImportFile.Text 'Full File Directory
                Dim OdasFileName As String = Me.SelectedOdasImportFile.Text 'File for Import

                If Directory.Exists(OdasFileFullName) = True Then
                    'Me.CurrentOdasImportFile.BeginInvoke(New ChangeText(AddressOf Change_COIF))
                    Me.BgwODASimport.ReportProgress(55, "Next ODAS File for Import: " & OdasFileName)
                    'Current ODAS File for Import-Insert in the Events Journal after finishing the current ODAS Import
                    'Define Business Date based on the OdasFileName
                    Dim BTD As String = OdasFileName
                    rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                    rdsql = rd.ToString("yyyyMMdd")
                    '**************************************************************************
                    'TEST UNZIP DEVEXPRESS
                    If Directory.Exists(OdasFileNewDirectory) Then
                        Directory.Delete(OdasFileNewDirectory, True)
                    End If
                    Directory.CreateDirectory(OdasFileNewDirectory)
                    pathToZipArchive = OdasFileFullName & "\EOD_ODAS_REPORT_DC007_" & OdasFileName & "" & ".zip"
                    '++++++++++++++++
                    'currentArchive = ZipArchive.Read(pathToZipArchive)
                    'For Each item As ZipItem In currentArchive
                    'If item.Name.EndsWith(".xls") = True OrElse item.Name.EndsWith(".xlsx") = True Then
                    'item.Extract(OdasFileNewDirectory)
                    'End If

                    'Next item
                    '+++++++++++++++++

                    Using zip As ZipFile = ZipFile.Read(pathToZipArchive)
                        Dim z As ZipEntry
                        For Each z In zip
                            If z.FileName.EndsWith(".xls") = True OrElse z.FileName.EndsWith(".xlsx") = True Then
                                z.Extract(OdasFileNewDirectory, ExtractExistingFileAction.OverwriteSilently)
                            End If
                        Next
                    End Using
                    


            'Try
            'currentArchive = ZipArchive.Read(pathToZipArchive)
            'Catch
            'XtraMessageBox.Show(Me, "Arvhive cannot be opened", "Error")
            'Return
            'End Try

            '***************************************************************************

            ' Ordner einschl. aller Unterordner kopieren
            'Me.BgwODASimport.ReportProgress(65, "Copy Folder:" & OdasFileFullName & " to " & OdasFileNewDirectory)
            'CopyFolder(OdasFileFullName, OdasFileNewDirectory)
            'DATEI ENTZIPPEN
            'Dim file As String = OdasFileNewDirectory & "\EOD_ODAS_REPORT_67800000000_" & OdasFileName & "" & ".zip"
            'Me.BgwODASimport.ReportProgress(70, "Start unzip File: " & "  " & file)
            'ENTZIPPEN+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'Dim cu As New ClassUnzip(file, Path.Combine(Path.GetDirectoryName(file), "ODAS_unzip_folder"))
            'AddHandler cu.UnzipFinishd, AddressOf Unziped
            'cu.UnzipNow()
            'Directory von wo das Programm auf die jeweiligen Dateien zugreift
            'ODAS_Temp_Directory = OdasFileNewDirectory & "\ODAS_unzip_folder"

            Me.BgwODASimport.ReportProgress(75, "ODAS File for Import: " & "  " & OdasFileName & " is ready")
            Me.BgwODASimport.ReportProgress(80, "Starting the ODAS Import procedures...")

            '++++++++PROZESSE+++++++++++++
            ODAS_IMPORT_PROCEDURES()

            '++++++++++++++++++++++++++++++++++++++++++++++
            'Erstellten Ordner wieder löschen
            Me.BgwODASimport.ReportProgress(85, "Delete Directory: " & "  " & OdasFileNewDirectory)
            Directory.Delete(OdasFileNewDirectory, True)

            Me.BgwODASimport.ReportProgress(95, "ODAS File Import: " & " " & OdasFileName & " " & "is finished ...")
            Me.BgwODASimport.ReportProgress(100, "ODAS Import finished ...")

        Else
            MessageBox.Show("ODAS File: " & SelectedOdasImportFile.Text & " does not exists!", "ODAS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

        If cmdODAS.Connection.State = ConnectionState.Open Then
            cmdODAS.Connection.Close()
        End If

            Catch ex As Exception

            Me.BgwODASimport.ReportProgress(0, "ERROR +++Import Procedure for ODAS File: " & " " & Me.SelectedOdasImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
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
        End If
        '***********************************************************************************************

        '***********************ODAS IMPORT FROM...TILL*************************
        If OdasImportFromTill_btn_clicked = True Then
            Try
                Me.BgwODASimport.ReportProgress(10, "Locate the ODAS Current and Temp Directory...")

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
                Me.BgwODASimport.ReportProgress(45, "Delete from Table: ODAS FILES where FileName NOT BETWEEN " & Me.OdasImportFileFrom.Text & " and " & Me.OdasImportFileTill.Text)
                cmdODAS.CommandText = "DELETE FROM [ODAS FILES] where [FileName] NOT BETWEEN'" & Me.OdasImportFileFrom.Text & "' and '" & Me.OdasImportFileTill.Text & "'"
                cmdODAS.ExecuteNonQuery()
                'set temporary LastImportedODASfile and load
                Me.BgwODASimport.ReportProgress(46, "Set as Temporary Last Imported ODAS File Name:20010101")
                cmdODAS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & 20010101 & "' WHERE [SYSTEM_NAME] in ('ODAS')"
                cmdODAS.ExecuteNonQuery()
                Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)

                Me.QueryText = "SELECT [FileName],[FileFullName]  FROM [ODAS FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)

                Me.BgwODASimport.ReportProgress(50, "Select the next ODAS File for Import")
                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileName] as NextFileNameforimport,[FileFullName] as NextFileFullName from [ODAS FILES] where [FileName] in (SELECT min([FileName])FROM [ODAS FILES] where [FileName]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('ODAS')))"
                    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        COIF = dt1.Rows.Item(0).Item("NextFileNameforimport")
                        Me.CurrentOdasImportFile.BeginInvoke(New ChangeText(AddressOf Change_COIF))
                        Me.BgwODASimport.ReportProgress(55, "Next ODAS File for Import: " & COIF)
                        'Current ODAS File for Import-Insert in the Events Journal after finishing the current ODAS Import
                        Dim LCOIF As String = COIF
                        'Define Business Date based on the COIF
                        Dim BTD As String = COIF
                        rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                        rdsql = rd.ToString("yyyyMMdd")
                        '**************************************************************************
                        If Me.BgwODASimport.CancellationPending = False Then

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
                            'pathToZipArchive = OdasFileFullName & "\EOD_ODAS_REPORT_67800000000_" & COIF & "" & ".zip"
                            pathToZipArchive = OdasFileFullName & "\EOD_ODAS_REPORT_DC007_" & COIF & "" & ".zip"

                            '++++++++++++++++++++++++++++++++++++++++++++
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
                            '++++++++++++++++++++++++++++++++++++++++++
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
                            cmdODAS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & COIF & "' WHERE [SYSTEM_NAME] in ('ODAS')"
                            cmdODAS.ExecuteNonQuery()

                            LOIF = COIF
                            Me.LastOdasImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOIF))
                            COIF = Nothing
                            Me.CurrentOdasImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COIF))


                            Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwODASimport.ReportProgress(95, "ODAS File Import: " & " " & LCOIF & " " & "is finished ...")
                            Me.BgwODASimport.ReportProgress(100, "ODAS Import finished ...")
                        ElseIf Me.BgwODASimport.CancellationPending = True Then
                            Me.BgwODASimport.ReportProgress(100, "ODAS Imports are terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                        End If
                    End If

                Next m
                cmdODAS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdODAS.ExecuteNonQuery()
                cmdODAS.CommandText = "DROP TABLE [ODASFilesTemp]"
                cmdODAS.ExecuteNonQuery()
                cmdODAS.CommandText = "DROP TABLE [ODAS FILES]"
                cmdODAS.ExecuteNonQuery()
                cmdODAS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdODAS.ExecuteNonQuery()
                'Set as last ODAS imported file Name the first ODAS file name
                cmdODAS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CURRENT_LAST_IMPORTED_ODAS_FILE & "' WHERE [SYSTEM_NAME] in ('ODAS')"
                cmdODAS.ExecuteNonQuery()
                Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)


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
        End If
        '***********************************************************************
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
            '***************************************************
            TextImportFileRow = Now & "  " & "ODAS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

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
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByODASDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub BgwODASimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwODASimport.RunWorkerCompleted
        ENABLE_FINISH_IMPORT()
        Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)
        Me.SelectedOdasImportFile.Text = ""
        Me.OdasImportFileFrom.Text = ""
        Me.OdasImportFileTill.Text = ""
        'Set Button Click as default to False
        OdasAutomatedImport_btn_clicked = False
        OdasSelectedFileImport_btn_clicked = False
        OdasImportFromTill_btn_clicked = False

        If cmdODAS.Connection.State = ConnectionState.Open Then
            cmdODAS.Connection.Close()
        End If

        Dim f As New GlobalClass
        f.NewImportEventsFolder()
    End Sub

#End Region

    Private Sub OdasImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwODASimport.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub OdasImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT
        cmdEVENT.CommandTimeout = 60000

        connODAS.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdODAS.Connection = connODAS
        cmdODAS.CommandTimeout = 60000

        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        cmd.Connection.Open()
        MaxProcDate = cmd.ExecuteScalar
        'Get SSIS Directory
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='SSIS_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SSIS_DIRECTORY'"
        SSISDirectory = cmd.ExecuteScalar()
        cmd.Connection.Close()

        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='IMPORT_ERRORS_EMAIL'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
            Next
        End If



        Me.IMPORT_EVENTSTableAdapter.FillByODASDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.ODAS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.ODAS_IMPORT_PROCEDURES)
        Me.FILES_IMPORTTableAdapter.FillByODAS(Me.EDPDataSet.FILES_IMPORT)

    End Sub

    Private Sub ODAS_IMPORT_PROCEDURES()
        Me.ODAS_IMPORT_INTEREST_RATE_RISK_NEW()
        Me.ODAS_IMPORT_FINRECON_DETAILS()
        Me.ODAS_IMPORT_DAILY_BALANCE_SHEETS() 'NG
        Me.ODAS_IMPORT_MOVEMENTS_DETAILS()


    End Sub

    Private Sub ODAS_IMPORT_INTEREST_RATE_RISK_OLD()
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
                            Me.BgwODASimport.ReportProgress(22, "Create temporary Table: #Temp_IMPORT_RATERISK_DETAILS")
                            'Alte Daten im IMPORT DATATABLE löschen
                            cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_RATERISK_DETAILS' AND xtype='U') CREATE TABLE [#Temp_IMPORT_RATERISK_DETAILS]([ID] [int] IDENTITY(1,1) NOT NULL,[Contract Type] [nvarchar](255) NULL,[PERIOD] [nvarchar](255) NULL,[GLMaster / Account Type] [nvarchar](255) NULL,[ProductType] [nvarchar](255) NULL,[Contract/Account] [nvarchar](255) NULL,[Counterparty/Issuer] [nvarchar](255) NULL,[Next EventDate][datetime] NULL,[Next EventType] [nvarchar](255) NULL,[Final Maturity Date] [datetime] NULL,[CURRENCY] [nvarchar](255) NULL,[Type] [nvarchar](255) NULL,[Principal Amount/Value Balance] [float] NULL,[Principal Amount/Value Balance(EUR Equ)] [float] NULL,[RISK DATE][datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_RATERISK_DETAILS]"
                            cmd.ExecuteNonQuery()

                            '******************************************************
                            'Ausführen SSI-Daten importieren 
                            'Me.BgwODASimport.ReportProgress(23, "Start SSI for Import InterestRateRiskAll")
                            'pkg = app.LoadPackage(SSISDirectory & "InterestRateRiskAll.dtsx", Nothing)
                            'pkgResults = pkg.Execute()
                            'Me.BgwODASimport.ReportProgress(23, "INTEREST RATE RISK SSI Result:" & pkgResults.ToString())
                            '******************************************************
                            Me.BgwODASimport.ReportProgress(22, "Import Data from Excel Sheet where CURRENCY is not NULL")
                            cmd.CommandText = "INSERT INTO [#Temp_IMPORT_RATERISK_DETAILS] ([Contract Type],[PERIOD],[GLMaster / Account Type],[ProductType],[Contract/Account],[Counterparty/Issuer],[Next EventDate],[Next EventType],[Final Maturity Date],[CURRENCY],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)])   SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Contract Type],[PERIOD],[GLMaster / Account Type],[ProductType],[Contract/Account],[Counterparty/Issuer],[Next EventDate],[Next EventType],[Final Maturity Date],[CURRENCY],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)] FROM [Sheet1$] where [CURRENCY] is not NULL')"
                            cmd.ExecuteNonQuery()
                            'Count Imported Rows
                            cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [CURRENCY] is not NULL')"
                            Me.BgwODASimport.ReportProgress(22, cmd.ExecuteScalar & " rows imported in IMPORT RATERISK DETAILS")

                            Me.BgwODASimport.ReportProgress(22, "Input Risk Date in IMPORT RATERISK DETAILS")
                            cmd.CommandText = "UPDATE [#Temp_IMPORT_RATERISK_DETAILS] SET [RISK DATE]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()

                            '*********************************************************************************
                            'Insert New Items Data to Table ALL_CONTRACTS_ACCOUNTS
                            Me.BgwODASimport.ReportProgress(22, "Import New Contracts/Accounts to Table:ALL_CONTRACTS_ACCOUNTS")
                            cmd.CommandText = "INSERT INTO [dbo].[ALL_CONTRACTS_ACCOUNTS] ([Contract_Account]) Select dbo.fn_StripCharacters([Contract/Account],'^0-9') from [#Temp_IMPORT_RATERISK_DETAILS] where  dbo.fn_StripCharacters([Contract/Account],'^0-9') not in (Select [Contract_Account] from [ALL_CONTRACTS_ACCOUNTS]) GROUP BY dbo.fn_StripCharacters([Contract/Account],'^0-9')"
                            cmd.ExecuteNonQuery()
                            '*********************************************************************************

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
                                cmd.CommandText = "INSERT INTO [RATERISK DETAILS ALL DATA]([CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[RISK DATE],[IdRateRiskDate])Select[CURRENCY],[PERIOD],[Contract Type],[ProductType],[GLMaster / Account Type],[Contract/Account],[Counterparty/Issuer],[Next EventType],[Next EventDate],[Final Maturity Date],[Type],[Principal Amount/Value Balance],[Principal Amount/Value Balance(EUR Equ)],[RISK DATE],[RISK DATE]FROM [#Temp_IMPORT_RATERISK_DETAILS]"
                                cmd.ExecuteNonQuery()
                                'löschen der IMPORT Tabelle
                                cmd.CommandText = "DROP TABLE [#Temp_IMPORT_RATERISK_DETAILS]"
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

    Private Sub ODAS_IMPORT_INTEREST_RATE_RISK_NEW()
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
                Me.BgwODASimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Starting Procedure: INTEREST RATE RISK")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\int_rate_risk_all-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\int_rate_risk_all-en.xls"

                If File.Exists(ExcelFileName) = True Then
                    Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import File:int_rate_risk_all-en.xls...Please wait...")

                    'Dateiendung anzeigen
                    Dim ExcelFileNameExt As String
                    Dim fi As New IO.FileInfo(ExcelFileName)
                    ExcelFileNameExt = fi.Extension

                    ' ''Excel Datei Öffnen und Datenformat ändern
                    Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
                    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                    EXCELL.Visible = False

                    xlWorksheet1.Columns("A:A").unMerge()
                    xlWorksheet1.Rows("1:8").delete()
                    'Blatt 1 - Leere spalten löschen
                    xlWorksheet1.Columns("M:T").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    'Blatt 1 - Datumsformat einfügen
                    xlWorksheet1.Columns("G:H").numberformat = "yyyy-MM-dd"
                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Changing Column Names-(J9=CURRENCY)-(U9=DATA DATE)-(V9=RISK DATE)")
                    xlWorksheet1.Range("D1").Value = "Contract/Account"
                    xlWorksheet1.Range("J1").Value = "CURRENCY"

                    Me.BgwODASimport.ReportProgress(4, "Procedure:" & CURRENT_PROC & " - " & "Defined RiskDate" & "  " & rdsql)

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

                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('INTEREST RATE RISK') and [Id_SQL_Parameters] in ('ODAS_IMPORTS')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('INTEREST RATE RISK')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i1 = 0 To dt.Rows.Count - 1
                            SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<ExcelFileName>", ExcelFileName)
                            SqlCommandText2 = SqlCommandText1.ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText2
                            If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                Me.BgwODASimport.ReportProgress(i1, "Procedure:" & CURRENT_PROC & " - " & dt.Rows.Item(i1).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                        Me.BgwODASimport.ReportProgress(100, "Import procedure: INTEREST RATE RISK is finished sucesfully")
                    Else
                        Me.BgwODASimport.ReportProgress(0, "+++Import procedure SQL Parameter: INTEREST RATE RISK are not Valid+++")

                    End If


                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ Procedure: " & CURRENT_PROC & " - " & "File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure:INTEREST RATE RISK is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As System.Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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

                    '++++++++++++++++++++++++++++++++++++++++++++++++++
                    'OLD CODE
                    'Me.BgwODASimport.ReportProgress(3, "Find: Adjusted sum of net long / short position row and select value from Column 7")
                    'SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")
                    'Dim ef As ExcelFile = ExcelFile.Load(ExcelFileName)
                    'Dim sheet As ExcelWorksheet
                    'sheet = ef.Worksheets(0)
                    'rdfx = DateSerial(Microsoft.VisualBasic.Right(sheet.Cells("A1").Value, 4), Mid(sheet.Cells("A1").Value, 4, 2), Microsoft.VisualBasic.Left(sheet.Cells("A1").Value, 2)) 'DATUM DER FX POSITION
                    'rdsqlfx = rd.ToString("yyyy-MM-dd")
                    'MsgBox(rdsqlfx)
                    'Dim fxp As Double = 0
                    'For i = 0 To 100
                    'If Trim(sheet.Cells(i, 0).Value) = "Adjusted sum of net long / short position" Then
                    'fxp = sheet.Cells(i, 6).Value
                    'End If
                    'Next i
                    '++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwODASimport.ReportProgress(3, "Find: Adjusted sum of net long / short position row and select value from Column 7")
                    Dim fxp As Double = 0
                    cmd.CommandText = "IF OBJECT_ID('tempdb..#FX_POSITION') IS NOT NULL drop table #FX_POSITION"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SELECT * INTO #FX_POSITION FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=NO;Database=" & ExcelFileName & ";','SELECT * FROM [页面1_1$]')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "Select CONVERT(Datetime,RIGHT(REPLACE(LTRIM(RTRIM(RIGHT([F8],10))),'/',''),4)+Substring(REPLACE(LTRIM(RTRIM(RIGHT([F8],10))),'/',''),3,2)+LEFT(REPLACE(LTRIM(RTRIM(RIGHT([F8],10))),'/',''),2)) from  #FX_POSITION where F8 is not NULL and F8 not like 'Agreed%'"
                    rdfx = cmd.ExecuteScalar
                    rdsqlfx = rdfx.ToString("yyyyMMdd")
                    cmd.CommandText = "Select convert(float,REPLACE([F6],',','')) from #FX_POSITION where [F1]='Adjusted sum of net long / short position'"
                    fxp = cmd.ExecuteScalar
                    cmd.CommandText = "IF OBJECT_ID('tempdb..#FX_POSITION') IS NOT NULL drop table #FX_POSITION"
                    cmd.ExecuteNonQuery()


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
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_CREDIT_RISK' AND xtype='U') CREATE TABLE [#Temp_IMPORT_CREDIT_RISK]([ID] [int] IDENTITY(1,1) NOT NULL,[Obligor Rate] [nvarchar](255) NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Account Type] [nvarchar](255) NULL,[Counterparty/Issuer/Collateral Name] [nvarchar](255) NULL,[Client No] [nvarchar](255) NULL,[Contract Collateral ID] [nvarchar](255) NULL,[Maturity Date] [datetime] NULL,[Remaining Year(s) to Maturity] [float] NULL,[Org Ccy] [nvarchar](255) NULL,[Credit Outstanding (Org Ccy)] [float] NULL,[Credit Outstanding (EUR Equ)] [float] NULL,[PD] [float] NULL,[(1-ER)] [float] NULL,[Credit Risk Amount(EUR Equ)] [float] NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_CREDIT_RISK]"
                    cmd.ExecuteNonQuery()
                    '******************************************************
                    'Start SSIs
                    'Me.BgwODASimport.ReportProgress(4, "Start SSI for Import Credit Risk")
                    'pkg = app.LoadPackage(SSISDirectory & "CreditRisk.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(5, "SSI Result for CREDIT RISK import:" & pkgResults.ToString())
                    '*******************************************************
                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_CREDIT_RISK]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)] FROM [Sheet1$] where [Org Ccy] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [Org Ccy] is not NULL')"
                    Me.BgwODASimport.ReportProgress(22, cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_CREDIT_RISK")

                    cmd.CommandText = "UPDATE [#Temp_IMPORT_CREDIT_RISK] SET [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(5, "CREDIT RISK imported sucessfully")

                    'Import in CREDIT RISK ALL DATA before deleting specific Data
                    'Me.BgwODASimport.ReportProgress(5, "Import in CREDIT RISK ALL DATA before deleting specific Data")
                    'cmd.CommandText = "Delete FROM [CREDIT RISK ALL DATA] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [CREDIT RISK ALL DATA]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[RiskDate],[DateMakCrTotals])Select [Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[RiskDate],[RiskDate] FROM [#Temp_IMPORT_CREDIT_RISK]"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(6, "In [CREDIT RISK ALL DATA] Set Obligor Grate to -No Rating- if Obligor Grate is U")
                    cmd.CommandText = "UPDATE [CREDIT RISK ALL DATA] SET [Obligor Rate]='No Rating' where [Obligor Rate] in ('U') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    'Import neue Client Nr in CUSTOMER RATINGS
                    'Me.BgwODASimport.ReportProgress(6, "Import new Clients in CUSTOMER RATINGS")
                    'cmd.CommandText = "INSERT INTO [CUSTOMER_RATING] ([ClientNo],[ClientName])Select distinct [Client No],[Counterparty/Issuer/Collateral Name] FROM [CREDIT RISK ALL DATA] B where B.[Client No] not in (Select [ClientNo] from [CUSTOMER_RATING]) and B.[Contract Type]<>'LIMIT' "
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "UPDATE A SET A.[ClientType]=B.[ClientType] from [CUSTOMER_RATING] A INNER JOIN [CUSTOMER_INFO] B ON A.[ClientNo]=B.[ClientNo]"
                    'cmd.ExecuteNonQuery()
                    'Me.BgwODASimport.ReportProgress(6, "Import new Clients in CUSTOMER_RATING_DETAILS")
                    'cmd.CommandText = "INSERT INTO [CUSTOMER_RATING_DETAILS]([ClientNo],[ClientName],[RatingType],[Rating],[CoreDefinition],[PD],[Valid_From],[Valid_Till],[IDNr])SELECT [ClientNo],[ClientName],'INTERNAL' as 'RatingType','U',NULL,0 as 'PD','" & rdsql & "' as 'Valid_From','99991231' as 'Valid_Till',[ID] FROM [CUSTOMER_RATING] where [ClientNo] not in (Select [ClientNo] from CUSTOMER_RATING_DETAILS where [RatingType] in ('INTERNAL'))"
                    'cmd.ExecuteNonQuery()
                    'cmd.CommandText = "INSERT INTO [CUSTOMER_RATING_DETAILS]([ClientNo],[ClientName],[RatingType],[Rating],[CoreDefinition],[PD],[Valid_From],[Valid_Till],[IDNr])SELECT [ClientNo],[ClientName],'EXTERNAL' as 'RatingType','U',NULL,0 as 'PD','" & rdsql & "' as 'Valid_From','99991231' as 'Valid_Till',[ID] FROM [CUSTOMER_RATING] where [ClientNo] not in (Select [ClientNo] from CUSTOMER_RATING_DETAILS where [RatingType] in ('EXTERNAL'))"
                    'cmd.ExecuteNonQuery()
                    '++++++GENERATE EMAIL FOR NEW CUSTOMERS WITHOUT RATING (No Rating - U)
                    'Me.BgwODASimport.ReportProgress(9, "Check if Parameter:EMAIL_CUSTOMERS_RATINGS is Valid - For the creation of the Customer Ratings Email")
                    'cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_CUSTOMERS_RATINGS'"
                    'Dim EMAIL_CUSTOMERS_RATINGS_Valid As String = cmd.ExecuteScalar
                    'If EMAIL_CUSTOMERS_RATINGS_Valid = "Y" Then
                    '    Me.BgwODASimport.ReportProgress(10, "Parameter:EMAIL_CUSTOMERS_RATINGS is valid-Start Email creation")

                    '    CREATE EMAIL And SEND
                    '    Dim myBuilder As New StringBuilder

                    '    Select EMAIL RECEIVERS
                    '    Me.BgwODASimport.ReportProgress(12, "Collect Email Receivers")
                    '    Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [PARAMETER1] in ('Receiver_Direct') and [IdABTEILUNGSPARAMETER]='EMAIL_CUSTOMERS_RATINGS'"
                    '    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    '    dt = New DataTable()
                    '    da.Fill(dt)
                    '    Dim EMAIL_USERS As String = ""
                    '    For i = 0 To dt.Rows.Count - 1
                    '        EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                    '    Next
                    '    dt.Clear()
                    '    CC to
                    '    Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [PARAMETER1] in ('Receiver_CC') and [IdABTEILUNGSPARAMETER]='EMAIL_CUSTOMERS_RATINGS'"
                    '    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    '    dt = New DataTable()
                    '    da.Fill(dt)
                    '    Dim EMAIL_USERS_CC As String = ""
                    '    For i = 0 To dt.Rows.Count - 1
                    '        EMAIL_USERS_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                    '    Next




                    '    *********************************************************************************************************************************
                    '    Me.BgwODASimport.ReportProgress(13, "Check if there is new Customer in CUSTOMER_RATING with Undefined Rating")
                    '    RATINGS WITH NO VALIDITY
                    '    Me.QueryText = "Select [ClientNo],LEFT(LTRIM(RTRIM(ClientName)),21) as 'ClientName' from [CUSTOMER_RATING] where [Rating] in ('U')"
                    '    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    '    dt = New DataTable()
                    '    dt.Clear()
                    '    da.Fill(dt)
                    '    If dt.Rows.Count > 0 Then
                    '        Dim headers As String = "For the following Customer no Ratings have being defined yet!" & vbNewLine
                    '        Dim Footer As String = "(Please define Ratings for the a.m. customer immediately)" & vbNewLine

                    '        myBuilder.Append("Client No:     " & "Client Name:                          " & vbNewLine)


                    '        For i = 0 To dt.Rows.Count - 1

                    '            myBuilder.Append(dt.Rows.Item(i).Item("ClientNo") & "       " & dt.Rows.Item(i).Item("ClientName") & vbNewLine)
                    '        Next



                    '        Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
                    '        Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
                    '        Dim outApp As Microsoft.Office.Interop.Outlook.Application

                    '        outApp = New Microsoft.Office.Interop.Outlook.Application

                    '        NSpace = outApp.GetNamespace("MAPI")
                    '        Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
                    '        EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                    '        EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

                    '        EItem.To = EMAIL_USERS
                    '        EItem.CC = EMAIL_USERS_CC


                    '        EItem.Subject = "CUSTOMERS WITH NO RATING INDICATED on " & rd

                    '        EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

                    '        Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

                    '        EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
                    '        EItem.Send()

                    '        Me.BgwODASimport.ReportProgress(14, "Email for Customers with no indicated rating has being send")
                    '        End If
                    'End If

                    '*********************************************************************************************************************************

                    'löschen der IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [#Temp_IMPORT_CREDIT_RISK]"
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

                    'Rows delete
                    xlWorksheet1.Rows("1:6").delete()
                    xlWorksheet1.Columns("R:S").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("L:M").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("O:Q").numberformat = "#,##0.00"
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
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_MAK_REPORT' AND xtype='U') CREATE TABLE [#Temp_IMPORT_MAK_REPORT]([ID] [int] IDENTITY(1,1) NOT NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Account Type] [nvarchar](255) NULL,[Counterparty/Issuer/Collateral Provider] [nvarchar](255) NULL,[Client No] [nvarchar](255) NULL,[Country of Risk] [nvarchar](255) NULL,[Country of Residence] [nvarchar](255) NULL,[Industry(HO)] [nvarchar](255) NULL,[Client Group] [nvarchar](255) NULL,[Contract Collateral ID] [nvarchar](255) NULL,[Start Date] [datetime] NULL,[Maturity Date][datetime] NULL,[Org Ccy] [nvarchar](255) NULL,[Credit Exposure] [float] NULL,[Accrued Interest] [float] NULL,[Euro Equivalent] [float] NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_MAK_REPORT]"
                    cmd.ExecuteNonQuery()
                    '*****************************************
                    'Start Import via SSI
                    'Me.BgwODASimport.ReportProgress(9, "Start SSI for Import MAK Report")
                    'pkg = app.LoadPackage(SSISDirectory & "MAK.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(10, "SSI Result for MAK Report:" & pkgResults.ToString())
                    'Me.BgwODASimport.ReportProgress(10, "Import:mak-en.xls is finished")
                    '*****************************************
                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_MAK_REPORT]([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent] FROM [Sheet1$] where [Org Ccy] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [Org Ccy] is not NULL')"
                    Me.BgwODASimport.ReportProgress(22, cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_MAK_REPORT")

                    cmd.CommandText = "UPDATE [#Temp_IMPORT_MAK_REPORT] SET [RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(10, "MAK REPORT imported sucessfully")

                    'Import in MAK REPORT ALL DATA before deleting specific Data
                    'Me.BgwODASimport.ReportProgress(5, "Import in MAK REPORT ALL DATA before deleting specific Data")
                    'cmd.CommandText = "Delete FROM [MAK REPORT ALL DATA] where [RiskDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [MAK REPORT ALL DATA]([Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[DateMakCrTotals])Select [Contract Type],[Product Type],[GL Master / Account Type],[Account Type],[Counterparty/Issuer/Collateral Provider],[Client No],[Country of Risk],[Country of Residence],[Industry(HO)],[Client Group],[Contract Collateral ID],[Start Date],[Maturity Date],[Org Ccy],[Credit Exposure],[Accrued Interest],[Euro Equivalent],[RiskDate],[RiskDate] FROM [#Temp_IMPORT_MAK_REPORT]"
                    cmd.ExecuteNonQuery()

                    'löschen der MAK IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [#Temp_IMPORT_MAK_REPORT]"
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
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [OrgCcy] is not NULL')"
                    Me.BgwODASimport.ReportProgress(2, cmd.ExecuteScalar & " rows imported in FRISTEN")
                    
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

                Me.BgwODASimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import:ACCRUED INTEREST ANALYSIS")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\acc_int_analysis-en.xls"
                ExcelFileName = OdasFileNewDirectory & "\acc_int_analysis-en.xls"

                If File.Exists(ExcelFileName) = True Then
                    Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import:acc_int_analysis-en.xls...Please wait...")
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
                    'Dim TempString As String = xlWorksheet1.Range("B3").Value
                    'Dim newmakdate As String = getNumeric(TempString)

                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Define Checking Date")
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
                    'Dim CheckingDate As Date
                    'Select Case MeldeMonatSingle
                    'Case "01"
                    'CheckingDate = "01.02." & rd.ToString("yyyy")
                    'Case "02"
                    'CheckingDate = "01.03." & rd.ToString("yyyy")
                    'Case "03"
                    'CheckingDate = "01.04." & rd.ToString("yyyy")
                    'Case "04"
                    'CheckingDate = "01.05." & rd.ToString("yyyy")
                    'Case "05"
                    'CheckingDate = "01.06." & rd.ToString("yyyy")
                    'Case "06"
                    'CheckingDate = "01.07." & rd.ToString("yyyy")
                    'Case "07"
                    'CheckingDate = "01.08." & rd.ToString("yyyy")
                    'Case "08"
                    'CheckingDate = "01.09." & rd.ToString("yyyy")
                    'Case "09"
                    'CheckingDate = "01.10." & rd.ToString("yyyy")
                    'Case "10"
                    'CheckingDate = "01.11." & rd.ToString("yyyy")
                    'Case "11"
                    'CheckingDate = "01.12." & rd.ToString("yyyy")
                    'Case "12"
                    'Dim rdny As Date = DateAdd(DateInterval.Year, 1, rd)
                    'CheckingDate = "01.01." & rdny.ToString("yyyy")
                    'End Select
                    'Me.BgwODASimport.ReportProgress(4, "Checking Date defined: " & "  " & CheckingDate)
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    xlWorksheet1.Columns("H:J").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("O:P").numberformat = "yyyymmdd"
                    'Rows delete
                    xlWorksheet1.Rows("1:5").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()


                    'Datum einfügen wo daten vorhanden sind
                    'Me.BgwODASimport.ReportProgress(5, "Insert Risk Date, Report Date, MeldeMonat and Checking Date in Excel File")
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_MAX5))
                    'For Me.ex = 2 To 5000
                    'Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                    'If xlWorksheet1.Cells(ex, 2).value <> "" Then 'Wenn Type nicht leer ist!
                    'xlWorksheet1.Cells(ex, 21).Value = rd
                    'xlWorksheet1.Cells(ex, 22).Value = rd1
                    'xlWorksheet1.Cells(ex, 23).Value = MeldeMonat
                    'xlWorksheet1.Cells(ex, 24).Value = CheckingDate
                    'Else
                    'xlWorksheet1.Rows(ex).Delete()
                    'End If
                    'Next ex

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
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_ACCRUED_INTEREST_Temp' AND xtype='U') CREATE TABLE [#Temp_IMPORT_ACCRUED_INTEREST_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[Class] [nvarchar](255) NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[Counterparty Name] [nvarchar](255) NULL,[Counterparty No] [nvarchar](255) NULL,[Trade Date][datetime] NULL,[Start Date][datetime] NULL,[Final Maturity Date][datetime] NULL,[Org Ccy] [nvarchar](255) NULL,[Principal (Org  Ccy)] [float] NULL,[Principal (EUR Equivalent)] [float] NULL,[Current Interest Rate] [float] NULL,[Current Interest Coupon Period Start Date][datetime] NULL,[Current Interest Coupon Period End Date][datetime] NULL,[Accrued Interest Coupon Org Ccy] [float] NULL,[Accrued Interest Coupon EUR Equ] [float] NULL,[Interest Coupon amount Org Ccy] [float] NULL,[Interest Coupon Amount EUR Equ] [float] NULL,[Riskdate][datetime] NULL,[RepDate] [datetime] NULL,[RepMonth] [datetime] NULL,[CheckingDate] [datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp]"
                    cmd.ExecuteNonQuery()
                    '******************************************************

                    'Start SSIs
                    'Me.BgwODASimport.ReportProgress(6, "Start SSI for Import ACCRUED INTEREST ANALYSIS")
                    'pkg = app.LoadPackage(SSISDirectory & "AccruedInterestAnalysis.dtsx", Nothing)
                    'pkgResults = pkg.Execute()
                    'Me.BgwODASimport.ReportProgress(7, "SSI Result for ACCRUED INTEREST ANALYSIS import:" & pkgResults.ToString())
                    '*******************************************************
                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_ACCRUED_INTEREST_Temp]  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[RepMonth],[CheckingDate] FROM [Sheet1$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$]')"
                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_ACCRUED_INTEREST_Temp")

                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Set RiskDate and RepDate in #Temp_IMPORT_ACCRUED_INTEREST_Temp")
                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] SET [Riskdate]='" & rdsql & "',[RepDate]= '" & rdsql1 & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Set RepMonth in #Temp_IMPORT_ACCRUED_INTEREST_Temp: If RiskDate<>RepDate then RepMonth:01. of RepDate else 01. of RiskDate")
                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] SET [RepMonth]=CASE when [Riskdate]<>[RepDate] then DATEADD(m, DATEDIFF(m, 0, [RepDate]), 0) when [Riskdate]=[RepDate] then DATEADD(m, DATEDIFF(m, 0, [Riskdate]), 0) end"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Set CheckingDate in #Temp_IMPORT_ACCRUED_INTEREST_Temp:01. of next Month from RepMonth")
                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] SET [CheckingDate]=DATEADD(m, DATEDIFF(m, -1, [RepMonth]), 0)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [Class] like '*%' and [Riskdate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] set [Accrued Interest Coupon Org Ccy]=0 where [Accrued Interest Coupon Org Ccy] is NULL and [Riskdate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] set [Accrued Interest Coupon EUR Equ]=0 where [Accrued Interest Coupon EUR Equ] is NULL and [Riskdate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] set [Interest Coupon amount Org Ccy]=0 where [Interest Coupon amount Org Ccy] is NULL and [Riskdate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] set [Interest Coupon Amount EUR Equ]=0 where [Interest Coupon Amount EUR Equ] is NULL and [Riskdate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "ACCRUED INTEREST imported sucessfully")

                    'Import Accrued Interest to ACCRUED INTEREST ANALYSIS Table
                    cmd.CommandText = "DELETE FROM [ACCRUED INTEREST ANALYSIS] where [Datadate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ACCRUED INTEREST ANALYSIS]([Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Datadate])  SELECT  [Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate] FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [#Temp_IMPORT_ACCRUED_INTEREST_Temp].[Riskdate] not in (Select [Datadate] from [ACCRUED INTEREST ANALYSIS])"
                    cmd.ExecuteNonQuery()
                    Me.BgwODASimport.ReportProgress(7, "ACCRUED INTEREST  imported sucessfully in Table ACCRUED INTEREST ANALYSIS")


                    If rd < DateSerial(2017, 5, 26) Then
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
                        Me.BgwODASimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Delete Securities (SECUR) from the imported Data")
                        cmd.CommandText = "DELETE  FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] Where [Contract Type]='SECUR'"
                        cmd.ExecuteNonQuery()
                        'Prüfen ob daten vorhanden sind
                        Me.BgwODASimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Checking if data allready imported to Table")
                        cmd.CommandText = "SELECT distinct [AIARasof] FROM [AWVz1415RelevantData] Where [AIARasof]='" & rdsql & "'"
                        Dim t As String = cmd.ExecuteScalar()
                        If IsNothing(t) = False Then
                            Me.BgwODASimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Data allready are imported to Table - No further action will be executed")
                        Else
                            Me.BgwODASimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Insert Data in AWVz1415RelevantData Table")
                            If rd.ToString("MM.yyyy") <> rd1.ToString("MM.yyyy") Then
                                'Neuanlage in AWV z1415 Relevant Data
                                cmd.CommandText = "INSERT INTO [AWVz1415RelevantData]([Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[OrigCCY],[Interest Coupon Amount OrigCCY],[Interest Coupon Amount EUR Equ],[AIARasof],[AIARrepdate],[CheckingDate],[IdZ14Z15Meldemonat])Select [Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Org Ccy],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[CheckingDate],[RepMonth] FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [Current Interest Coupon Period End Date]<[CheckingDate]"
                                cmd.ExecuteNonQuery()
                            ElseIf rd.ToString("MM.yyyy") = rd1.ToString("MM.yyyy") Then
                                cmd.CommandText = "INSERT INTO [AWVz1415RelevantData]([Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[OrigCCY],[Interest Coupon Amount OrigCCY],[Interest Coupon Amount EUR Equ],[AIARasof],[AIARrepdate],[CheckingDate],[IdZ14Z15Meldemonat])Select [Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Org Ccy],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[CheckingDate],[RepMonth] FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [Current Interest Coupon Period End Date]<[CheckingDate] and [Contract] not in (Select [Contract] from [AWVz1415RelevantData])"
                                cmd.ExecuteNonQuery()
                            End If

                            '##############################################################
                            Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Matching Country Codes with Customers Info Table")
                            'MATCHING DER LÄNDERCODES MIT CLIENT LIST
                            cmd.CommandText = "UPDATE [AWVz1415RelevantData] SET [CountryCode]=B.[COUNTRY_OF_RESIDENCE] from [AWVz1415RelevantData] A INNER JOIN [CUSTOMER_INFO] B ON A.[Counterparty No]=B.[ClientNo] where A.[AIARasof]='" & rdsql & "' "
                            cmd.ExecuteNonQuery()
                            '#######################################################################################
                            'N/A wenn kein Land angezeigt ist
                            cmd.CommandText = "UPDATE [AWVz1415RelevantData] SET [CountryCode]='N/A' where [CountryCode] is NULL"
                            cmd.ExecuteNonQuery()
                            '#######################################################################################
                            'MATCHING DER LÄNDERCODES MIT CLIENT LIST nur bei Country Code=N/A
                            cmd.CommandText = "UPDATE [AWVz1415RelevantData] SET [CountryCode]=B.[COUNTRY_OF_RESIDENCE] from [AWVz1415RelevantData] A INNER JOIN [CUSTOMER_INFO] B ON A.[Counterparty No]=B.[ClientNo] where A.[CountryCode]='N/A'"
                            cmd.ExecuteNonQuery()
                            '#######################################################################################
                            'Handling der Negativen Zinsen
                            Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Handling Negative Interests-Set Internal Info=Negative Interest where  Interest Coupon Amount EUR Equ<0")
                            cmd.CommandText = "Update [AWVz1415RelevantData] set [InternalInfo]='Negative Interest' where [Interest Coupon Amount EUR Equ]<0 and [AIARasof]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            '#######################################################################################

                            'Prüfen ob daten vorhanden sind
                            Dim MeldeMonatSql As String = MeldeMonat.ToString("yyyy-MM-dd")
                            cmd.CommandText = "SELECT distinct [Z14Z15MeldeMonat] FROM [AWVz14z15] Where [Z14Z15MeldeMonat]='" & MeldeMonatSql & "'"
                            Dim t1 As String = cmd.ExecuteScalar()

                            If IsNothing(t1) = True Then
                                Me.BgwODASimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Insert into AWVz14 Table")
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
                                cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz14] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Assets' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [AWVz14] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                'Me.QueryText = "select * from [AWVz14]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                'dt = New DataTable()
                                'da.Fill(dt)
                                'For i = 0 To dt.Rows.Count - 1
                                'cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                'cmd.ExecuteNonQuery()
                                'Next

                                '######################################################################################################
                                'Füllen der Z15
                                'Länder und Währungen
                                Me.BgwODASimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Insert into AWVz15 Table")
                                cmd.CommandText = "INSERT INTO [AWVz15]([COUNTRY CODE],[COUNTRY NAME],[LANDKZ],[COUNTRY NAME DE])Select[COUNTRY CODE],[COUNTRY NAME],[LANDKZ BUBA],[COUNTRY NAME DE]FROM [COUNTRIES]"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [AWVz15] SET [CLASS]='LIABILITIES',[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' where [IdZ14Z15Meldemonat] is NULL"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz15] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [AWVz15] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                'Me.QueryText = "select * from [AWVz15]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                'dt = New DataTable()
                                'da.Fill(dt)
                                'For i = 0 To dt.Rows.Count - 1
                                'cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                'cmd.ExecuteNonQuery()
                                'Next
                                '######################################################################################################

                            Else
                                'Summen für AZW Z14 und Z15 auf NULL Stellen
                                Me.BgwODASimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Set CountrySumAmount to zero")
                                cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' "
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' "
                                cmd.ExecuteNonQuery()
                                Me.BgwODASimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Country Sums for AWVz14")
                                cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz14] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Assets' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [AWVz14] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                Me.BgwODASimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Country Sums for AWVz15")
                                cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz15] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                cmd.CommandText = "UPDATE [AWVz15] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                cmd.ExecuteNonQuery()
                                'Berechnen SUMME AWVz14
                                'Me.BgwODASimport.ReportProgress(13, "Re-Insert into AWVz14 Table")
                                'Me.QueryText = "select * from [AWVz14]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                'dt = New DataTable()
                                'da.Fill(dt)
                                'For i = 0 To dt.Rows.Count - 1
                                'cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Assets'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                'cmd.ExecuteNonQuery()
                                'Next

                                'Berechnen SUMME AWVz15
                                'Me.BgwODASimport.ReportProgress(14, "Re-Insert into AWVz15 Table")
                                'Me.QueryText = "select * from [AWVz15]  where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                                'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                                'dt = New DataTable()
                                'da.Fill(dt)
                                'For i = 0 To dt.Rows.Count - 1
                                'cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=CASE when (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "')<>0 then (SELECT SUM([Interest Coupon Amount EUR Equ]) from [AWVz1415RelevantData] where [Class]='Liabilities'  and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' AND [CountryCode]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "') else 0 end where  [COUNTRY CODE]= '" & dt.Rows.Item(i).Item("COUNTRY CODE") & "' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' "
                                'cmd.ExecuteNonQuery()
                                'Next
                            End If
                        End If

                    End If



                        'löschen der IMPORT Tabelle
                        cmd.CommandText = "DROP TABLE [#Temp_IMPORT_ACCRUED_INTEREST_Temp]"
                        cmd.ExecuteNonQuery()
                        Me.BgwODASimport.ReportProgress(100, "Import procedure:IMPORT ACCRUED INTEREST ANALYSIS finished sucesfully")
                    Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - " & "File does Not exist in Import Directory - File Name: " & ExcelFileName)
                End If
                Else
                    Me.BgwODASimport.ReportProgress(0, "+++Import procedure: ACCRUED INTEREST ANALYSIS ist not Valid+++")

                End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub 'SEE ALSO UPDATE_AWVz14z15 in RUN CLIENT-EXECUTED ONLY IN SCHEDULED TASK

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
            cmd.CommandTimeout = 50000

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

                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_FX_DAILY_REVALUATION' AND xtype='U') CREATE TABLE [#Temp_IMPORT_FX_DAILY_REVALUATION]([ID] [int] IDENTITY(1,1) NOT NULL,[ContractNr] [nvarchar](255) NULL,[ContractType] [nvarchar](255) NULL,[ProductType] [nvarchar](255) NULL,[InputDate] [datetime] NULL,[ValueDate] [datetime] NULL,[MaturityDate] [datetime] NULL,[DealSellBuy] [nvarchar](255) NULL,[BuyCCY] [nvarchar](255) NULL,[BuyAmount] [float] NULL,[SellCCY] [nvarchar](255) NULL,[SellAmount] [float] NULL,[Exchange Rate] [float] NULL,[RevalBuyRate] [float] NULL,[RevalSellRate] [float] NULL,[RevalBuyAmount] [float] NULL,[RevalSellAmount] [float] NULL,[PL_EUR] [float] NULL,[PL_inEUR_Equ] [float] NULL,[NPV] [float] NULL,[DiscountRate] [float] NULL,[DealStatus] [nvarchar](255) NULL,[DealType] [nvarchar](255) NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_FX_DAILY_REVALUATION]"
                    cmd.ExecuteNonQuery()
                    '******************************************************

                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_FX_DAILY_REVALUATION]([ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate] FROM [FxDailyReval$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [FxDailyReval$]')"
                    Me.BgwODASimport.ReportProgress(5, cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_FX_DAILY_REVALUATION")

                    Me.BgwODASimport.ReportProgress(5, "FX DAILY REVALUATION imported in Temporary Table")

                    'Me.BgwODASimport.ReportProgress(6, "DELETE FROM IMPORT FX DAILY REVALUATION where Deal Type is not FW and SW")
                    'cmd.CommandText = "DELETE FROM [IMPORT FX DAILY REVALUATION] WHERE [DealType] not in ('FW', 'SW')"
                    'cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(7, "Delete all previus Data for the same Date")
                    'Daten mit dem aktuellen rd datum löschen
                    cmd.CommandText = "DELETE from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(8, "Insert into FX DAILY REVALUATION")
                    cmd.CommandText = "INSERT INTO [FX DAILY REVALUATION]([ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate])Select [ContractNr],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[BuyAmount],[SellCCY],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalSellRate],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[RiskDate] FROM [#Temp_IMPORT_FX_DAILY_REVALUATION]"
                    cmd.ExecuteNonQuery()

                    'löschen der IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [#Temp_IMPORT_FX_DAILY_REVALUATION]"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(9, "Match Client Nr and Client Name from Contract Nr in FX DAILY REVALUATION")
                    cmd.CommandText = "UPDATE A set A.[ClientNo]=B.[ClientNo] , A.[ClientName]=B.[ClientName] FROM [FX DAILY REVALUATION] A INNER JOIN [FX DAILY REVALUATION] B ON A.[ContractNr]=B.[ContractNr] where A.[ClientNo] is NULL "
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

                    Me.BgwODASimport.ReportProgress(9, "Update Modified_Final_Maturity_Date in FX DAILY REVALUATION Case when Monday then minus 3 Days otherwise Maturity Date Value")
                    cmd.CommandText = "UPDATE [FX DAILY REVALUATION] set [Modified_Final_Maturity_Date]=(Case when DATENAME(dw,[MaturityDate]) in ('Monday') then [MaturityDate]-3 else [MaturityDate] end) where  [RiskDate]='" & rdsql & "'"
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

    Private Sub ODAS_IMPORT_OBLIGO_LIABILITIES_SURPLUS_DETAILS()
        Try

            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "OBLIGO LIABILITIES SURPLUS DETAILS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='OBLIGO LIABILITIES SURPLUS DETAILS' and [Valid]='Y'"
            cmd.Connection.Open()

            Dim ExcelFileName As String = ""

            If cmd.ExecuteScalar > 0 Then
                Me.BgwODASimport.ReportProgress(1, "Starting Procedure: IMPORT OBLIGO LIABILITIES SURPLUS DETAILS")

                ExcelFileName = OdasFileNewDirectory & "\hobr_dtl-en.xls"

                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(2, "Import File:hobr_dtl-en.xls.xls...Please wait...")
                    Try
                        'Dateiendung anzeigen
                        Dim ExcelFileNameExt As String
                        Dim fi As New IO.FileInfo(ExcelFileName)
                        ExcelFileNameExt = fi.Extension



                        EXCELL = CreateObject("Excel.Application")
                        xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                        xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                        EXCELL.Visible = True

                        Me.BgwODASimport.ReportProgress(3, "Changing Column Names")
                        xlWorksheet1.Range("B5").Value = "ContractType"
                        xlWorksheet1.Range("C5").Value = "ProductType"
                        xlWorksheet1.Range("D5").Value = "GL_Master"
                        xlWorksheet1.Range("E5").Value = "Contract_Account"
                        xlWorksheet1.Range("F5").Value = "IS_Code"
                        xlWorksheet1.Range("G5").Value = "ClientNr"
                        xlWorksheet1.Range("H5").Value = "Counterparty_Issuer"
                        xlWorksheet1.Range("I5").Value = "TradeDate"
                        xlWorksheet1.Range("J5").Value = "StartDate"
                        xlWorksheet1.Range("K5").Value = "FinalMaturityDate"
                        xlWorksheet1.Range("L5").Value = "OrgCur"
                        xlWorksheet1.Range("M5").Value = "OrgCurAmount"
                        xlWorksheet1.Range("N5").Value = "OrgEurAmount"

                        Me.BgwODASimport.ReportProgress(4, "Defined RiskDate" & "  " & rdsql)


                        xlWorksheet1.Columns("I:K").numberformat = "yyyyMMdd"
                        xlWorksheet1.Columns("A:A").unMerge()

                        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        Dim p1 As String = "Assets"
                        Dim p2 As String = "Assets-Sold"
                        Dim p3 As String = "Fix-Liabilities"
                        Dim p4 As String = "Nonfix-Liabilities"


                        'Einfügen der Perioden auf die jeweiligen leerzeilen
                        Dim q As Integer      ' counter for the position in the series
                        q = 6

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:<= 1 Month")
                        Dim AC As Microsoft.Office.Interop.Excel.Range ' <= 1 Month
                        AC = xlWorksheet1.Range("A1:A2000").Find("Assets")
                        If AC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p2
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 2).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p1
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:1 - 3 Months")
                        Dim BC As Microsoft.Office.Interop.Excel.Range '1 - 3 Months
                        BC = xlWorksheet1.Range("A1:A2000").Find("Assets-Sold") ' Der Bereich mit den Numerischen Daten
                        If BC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p3
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 2).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p2
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:3 - 6 Months")
                        Dim CC As Microsoft.Office.Interop.Excel.Range '3 - 6 Months
                        CC = xlWorksheet1.Range("A1:A2000").Find("Fix-Liabilities") ' Der Bereich mit den Numerischen Daten
                        If CC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 1).Value = p4
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 2).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p3
                                End If
                                q = q + 1
                            Loop
                        End If

                        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:6 - 12 Months")
                        Dim DC As Microsoft.Office.Interop.Excel.Range '6 - 12 Months
                        DC = xlWorksheet1.Range("A1:A2000").Find("Nonfix-Liabilities") ' Der Bereich mit den Numerischen Daten
                        If DC Is Nothing Then

                        Else
                            Do Until xlWorksheet1.Cells(q, 2).Value = ""
                                Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
                                If xlWorksheet1.Cells(q, 1).Value = "" And xlWorksheet1.Cells(q, 2).Value <> "" Then
                                    xlWorksheet1.Cells(q, 1).Value = p4
                                End If
                                q = q + 1
                            Loop
                        End If


                        xlWorksheet1.Rows("1:4").delete()



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

                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                        Me.BgwODASimport.ReportProgress(21, "Delete Same data")
                        cmd.CommandText = "DELETE  FROM [OBLIGO_SURPLUS_DETAILS] WHERE [RiskDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()


                        Me.BgwODASimport.ReportProgress(22, "Import Data from Excel Sheet where Class is not NULL")
                        cmd.CommandText = "INSERT INTO [OBLIGO_SURPLUS_DETAILS] ([Class],[ContractType],[ProductType],[GL_Master],[Contract_Account],[IS_Code],[ClientNr],[Counterparty_Issuer],[TradeDate],[StartDate],[FinalMaturityDate],[OrgCur],[OrgCurAmount],[OrgEurAmount])   SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Class],[ContractType],[ProductType],[GL_Master],[Contract_Account],[IS_Code],[ClientNr],[Counterparty_Issuer],[TradeDate],[StartDate],[FinalMaturityDate],[OrgCur],[OrgCurAmount],[OrgEurAmount] FROM [Sheet1$] where [Class] is not NULL')"
                        cmd.ExecuteNonQuery()
                        'Count Imported Rows
                        cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [Class] is not NULL')"
                        Me.BgwODASimport.ReportProgress(22, cmd.ExecuteScalar & " rows imported in OBLIGO_SURPLUS_DETAILS")

                        Me.BgwODASimport.ReportProgress(22, "Input Risk Date in OBLIGO_SURPLUS_DETAILS")
                        cmd.CommandText = "UPDATE [OBLIGO_SURPLUS_DETAILS] SET [RiskDate]='" & rdsql & "' where [RiskDate] is NULL"
                        cmd.ExecuteNonQuery()

                        Me.BgwODASimport.ReportProgress(22, "OBLIGO_SURPLUS_DETAILS imported sucessfully")


                    Catch ex As System.Exception
                        Me.BgwODASimport.ReportProgress(24, "ERROR " & ex.Message.Replace("'", ""))
                    End Try
                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If


                Me.BgwODASimport.ReportProgress(100, "Import procedure: OBLIGO_SURPLUS_DETAILS is finished sucesfully")

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure:OBLIGO_SURPLUS_DETAILS is not VALID+++")

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

    Private Sub ODAS_IMPORT_FINRECON_DETAILS()
        Try

            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "FINRECON DETAILS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='FINRECON DETAILS' and [Valid]='Y'"
            cmd.Connection.Open()
            cmd.CommandTimeout = 50000

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure:FINRECON DETAILS")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\ts_d_1047-en.xlsx"
                ExcelFileName = OdasFileNewDirectory & "\finrecon_dtl-en.xls"

                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import:finrecon_dtl-en.xls...Please wait...")

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
                    xlWorksheet1.Columns("A:A").unMerge()
                    xlWorksheet1.Rows("1:5").delete()

                    xlWorksheet1.Range("A1").Value = "Entity"
                    xlWorksheet1.Range("B1").Value = "Source_System"
                    xlWorksheet1.Range("C1").Value = "Contract_Nr"
                    xlWorksheet1.Range("D1").Value = "Serial_Nr"
                    xlWorksheet1.Range("E1").Value = "GL_Number"
                    xlWorksheet1.Range("F1").Value = "GL_Acc_Name"
                    xlWorksheet1.Range("G1").Value = "GL_Groups"
                    xlWorksheet1.Range("H1").Value = "Group_Client_Nr"
                    xlWorksheet1.Range("I1").Value = "Group_Client_Name"
                    xlWorksheet1.Range("J1").Value = "Consolidated_Group_Client_Nr"
                    xlWorksheet1.Range("K1").Value = "Consolidated_Group_Client_Name"
                    xlWorksheet1.Range("L1").Value = "Client_Nr"
                    xlWorksheet1.Range("M1").Value = "Client_Name"
                    xlWorksheet1.Range("N1").Value = "ContractType"
                    xlWorksheet1.Range("O1").Value = "ProductType"
                    xlWorksheet1.Range("P1").Value = "ContractType_Definition"
                    xlWorksheet1.Range("Q1").Value = "Master_Nr"
                    xlWorksheet1.Range("R1").Value = "Accounting_Centre "
                    xlWorksheet1.Range("S1").Value = "InputDate"
                    xlWorksheet1.Range("T1").Value = "OriginalStartDate"
                    xlWorksheet1.Range("U1").Value = "StartDate"
                    xlWorksheet1.Range("V1").Value = "MaturityDate"
                    xlWorksheet1.Range("W1").Value = "FinalMaturityDate"
                    xlWorksheet1.Range("X1").Value = "LastCouponDate"
                    xlWorksheet1.Range("Y1").Value = "NextCouponDate"
                    xlWorksheet1.Range("Z1").Value = "InterestRate"

                    xlWorksheet1.Range("AA1").Value = "Amount_ID"
                    xlWorksheet1.Range("AB1").Value = "CCY"
                    xlWorksheet1.Range("AC1").Value = "Amount"
                    xlWorksheet1.Range("AD1").Value = "Amount_Equ"
                    xlWorksheet1.Range("AE1").Value = "Accrued_Interest"
                    xlWorksheet1.Range("AF1").Value = "Accrued_Interest_EUR"
                    xlWorksheet1.Range("AG1").Value = "Dr_Cr_Indicator"
                    xlWorksheet1.Range("AH1").Value = "IS_code"
                    xlWorksheet1.Range("AI1").Value = "Connected_Status"
                    xlWorksheet1.Range("AJ1").Value = "ResidenceCountry"
                    xlWorksheet1.Range("AK1").Value = "OriginalCountry"
                    xlWorksheet1.Range("AL1").Value = "RiskCountry"
                    xlWorksheet1.Range("AM1").Value = "CountryRating_RiskCountry"
                    xlWorksheet1.Range("AN1").Value = "RegistrationCountry"
                    xlWorksheet1.Range("AO1").Value = "CityCode"
                    xlWorksheet1.Range("AP1").Value = "ClientType"
                    xlWorksheet1.Range("AQ1").Value = "InternalClientType"
                    xlWorksheet1.Range("AR1").Value = "FI_Client_Type"
                    xlWorksheet1.Range("AS1").Value = "ID_Nr_Type2"
                    xlWorksheet1.Range("AT1").Value = "ID_Nr_2"
                    xlWorksheet1.Range("AU1").Value = "Industrial_Classification_Local"
                    xlWorksheet1.Range("AV1").Value = "Industrial_Classification_Others"
                    xlWorksheet1.Range("AW1").Value = "Purpose_of_loan"
                    xlWorksheet1.Range("AX1").Value = "Industrial_Classification_HO"
                    xlWorksheet1.Range("AY1").Value = "Client_Credit_Rating_Agency_1"
                    xlWorksheet1.Range("AZ1").Value = "Client_Credit_Rating1"

                    xlWorksheet1.Range("BA1").Value = "Client_Credit_Rating_Agency2"
                    xlWorksheet1.Range("BB1").Value = "Client_Credit_Rating2"
                    xlWorksheet1.Range("BC1").Value = "Loan_Credit_Rating_Long"
                    xlWorksheet1.Range("BD1").Value = "Loan_Credit_Rating_Short"
                    xlWorksheet1.Range("BE1").Value = "Pay_Receive_Indicator"
                    xlWorksheet1.Range("BF1").Value = "Payment_Method"
                    xlWorksheet1.Range("BG1").Value = "Far_Near_Indicator"
                    xlWorksheet1.Range("BH1").Value = "Purchase_Sale"
                    xlWorksheet1.Range("BI1").Value = "Investment_Type"
                    xlWorksheet1.Range("BJ1").Value = "Interest_Plan"
                    xlWorksheet1.Range("BK1").Value = "FacilityType"
                    xlWorksheet1.Range("BL1").Value = "DrawStartDate"
                    xlWorksheet1.Range("BM1").Value = "DrawEndDate"
                    xlWorksheet1.Range("BN1").Value = "Tenor"
                    xlWorksheet1.Range("BO1").Value = "IS_Code_Description"
                    xlWorksheet1.Range("BP1").Value = "Limit_Nr"
                    xlWorksheet1.Range("BQ1").Value = "Limit_Code"
                    xlWorksheet1.Range("BR1").Value = "Limit_Type"
                    xlWorksheet1.Range("BS1").Value = "Swap_Market_Value"
                    xlWorksheet1.Range("BT1").Value = "FI_Market_Value"
                    xlWorksheet1.Range("BU1").Value = "FI_Market_Value_EUR"
                    xlWorksheet1.Range("BV1").Value = "Interest_Rate_Type"
                    xlWorksheet1.Range("BW1").Value = "RateCode"
                    xlWorksheet1.Range("BX1").Value = "Spread_Rate"
                    xlWorksheet1.Range("BY1").Value = "Exchange_Rate"
                    xlWorksheet1.Range("BZ1").Value = "Original_Maturity"

                    xlWorksheet1.Range("CA1").Value = "Remaining_Maturity"
                    xlWorksheet1.Range("CB1").Value = "Collective_Impairment_Amount"
                    xlWorksheet1.Range("CC1").Value = "Individual_Impairment_Amount"
                    xlWorksheet1.Range("CD1").Value = "Total_Interest_Amount_OrgCCY"
                    xlWorksheet1.Range("CE1").Value = "Total_Interest_AmountEUR"
                    xlWorksheet1.Range("CF1").Value = "Class"

                    xlWorksheet1.Columns("S:Y").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("BL:BM").numberformat = "yyyymmdd"
                    xlWorksheet1.Columns("AC:AF").numberformat = "#,##0.00"
                    xlWorksheet1.Columns("BS:BU").numberformat = "#,##0.00"
                    xlWorksheet1.Columns("BZ:CE").numberformat = "#,##0.00"
                    xlWorksheet1.Columns("BX:BY").numberformat = "#,##0.000000"
                    

                    'Dim ExcelFileNameNew As String = ""
                    'ExcelFileNameNew = OdasFileNewDirectory & "\FINRECON_NEW.xls"
                    'Me.BgwODASimport.ReportProgress(4, "Save excel Sheet as: " & ExcelFileNameNew)

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


                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON DETAILS') and [Id_SQL_Parameters] in ('ODAS_IMPORTS')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FINRECON DETAILS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i1 = 0 To dt.Rows.Count - 1
                            SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<ExcelFileName>", ExcelFileName)
                            SqlCommandText2 = SqlCommandText1.ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText2
                            If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                Me.BgwODASimport.ReportProgress(i1, "Procedure:" & CURRENT_PROC & " - " & dt.Rows.Item(i1).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        Me.BgwODASimport.ReportProgress(0, "+++Import procedure SQL Parameter: FINRECON DETAILS are not Valid+++")

                    End If



                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "FINRECON-UPDATE DATA"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_DATA_UPDATE') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS/FINRECON_DATA_UPDATE")
                        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FINRECON_DATA_UPDATE')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText
                            If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    End If


                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "FINRECON-AWVz14z15"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_AWVz14z15') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - FINRECON - AWVz14z15")
                        cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_AWVz14z15') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If



                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "FINRECON PROFIT+LOSS"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_PROFIT_LOSS') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - FINRECON - FINRECON PROFT +LOSS")
                        cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_PROFIT_LOSS') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If


                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "FINRECON - ACCRUED INTEREST ANALYSIS"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_ACCRUEDS_ANALYSIS') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - FINRECON - ACCRUED INTEREST ANALYSIS")
                        cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FINRECON_ACCRUEDS_ANALYSIS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If

                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "FINRECON - OBLIGO SURPLUS"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_OBLIGO_SURPLUS') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - FINRECON - OBLIGO SURPLUS")
                        cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_OBLIGO_SURPLUS') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If

                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "FINRECON - CUSTOMER RATING"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('FINRECON_CUSTOMER_RATING') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - FINRECON - CUSTOMER RATING")
                        cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('FINRECON_CUSTOMER_RATING')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - " & "File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
                Me.BgwODASimport.ReportProgress(100, "Import procedure:FINRECON DETAILS finished sucesfully")

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: FINRECON DETAILS ist not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub ODAS_IMPORT_DAILY_BALANCE_SHEETS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "DAILY BALANCE SHEET"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='DAILY BALANCE SHEET' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwODASimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import: DAILY BALANCE SHEET")
                Dim ExcelFileName As String = ""
                Dim ExcelFileDetailsName As String = ""
                ExcelFileName = OdasFileNewDirectory & "\de_bal_sheet_sum-en.xls"
                ExcelFileDetailsName = OdasFileNewDirectory & "\de_bal_sheet_dtl-en.xls"

                Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Check if files exist: " & ExcelFileName & " and " & ExcelFileDetailsName)

                If File.Exists(ExcelFileName) = True AndAlso File.Exists(ExcelFileDetailsName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Reformate Excel File:\de_bal_sheet_sum-en.xls")

                    xlWorksheet1.Range("A7").Value = "GL_Item"
                    xlWorksheet1.Range("B7").Value = "GL_Item_Name"
                    xlWorksheet1.Range("C7").Value = "BalanceEUREqu"
                    xlWorksheet1.Range("D7").Value = "BSDate"
                    xlWorksheet1.Range("E7").Value = "RepDate"
                    xlWorksheet1.Columns("D:E").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")

                    xlWorksheet1.Rows("1:6").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()


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

                    Me.BgwODASimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Excel File:\de_bal_sheet_sum-en.xls reformated sucesfully")

                    Me.BgwODASimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Delete Current Data in DailyBalanceSheets-DailyBalanceDetailsSheets for " & rd)
                    cmd.CommandText = "DELETE FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] Where [BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Dim RepDate As Date = DateAdd(DateInterval.Day, 1, rd)
                    Dim SqlRepDate As String = RepDate.ToString("yyyyMMdd")

                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Insert Data to Table: DAILY BALANCE SHEETS ")
                    cmd.CommandText = "INSERT INTO [DailyBalanceSheets]([GL_Item],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate]) SELECT [GL_Item],[GL_Item_Name],[BalanceEUREqu],'" & rdsql & "','" & SqlRepDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [GL_Item],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate] FROM [Sheet1$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$]')"
                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in DailyBalanceSheets")

                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "DAILY_BALANCE_SHEET_UPDATES"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('DAILY_BALANCE_SHEET_UPDATES') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - DAILY_BALANCE_SHEET_UPDATES")
                        cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceSheets] where [BSDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DAILY_BALANCE_SHEET_UPDATES')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If

                    Me.BgwODASimport.ReportProgress(100, "Import procedure: DAILY BALANCE SHEET finished sucesfully")


                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'IMPORT DAILY BALANCE SHEET DETAILS
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "DAILY BALANCE SHEET DETAILS"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileDetailsName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Reformate Excel File:\de_bal_sheet_dtl-en.xls")

                    xlWorksheet1.Range("A5").Value = "GL_Item"
                    xlWorksheet1.Range("B5").Value = "ReleatedAccountNr"
                    xlWorksheet1.Range("C5").Value = "IS_Code"
                    xlWorksheet1.Range("D5").Value = "InputDate"
                    xlWorksheet1.Range("E5").Value = "StartDate"
                    xlWorksheet1.Range("F5").Value = "EndDate"
                    xlWorksheet1.Range("G5").Value = "NextRepricingDate"
                    xlWorksheet1.Columns("D:G").numberformat = "yyyymmdd"

                    xlWorksheet1.Range("H5").Value = "GL_Account_Nr"
                    xlWorksheet1.Range("I5").Value = "GL_Account_Name"
                    xlWorksheet1.Range("J5").Value = "Orig_CUR"
                    xlWorksheet1.Range("K5").Value = "Orig_Balance"
                    xlWorksheet1.Range("L5").Value = "Balance_EUR_CR"
                    xlWorksheet1.Range("M5").Value = "Balance_EUR_DR"
                    xlWorksheet1.Range("N5").Value = "Total_Balance"

                    xlWorksheet1.Range("O5").Value = "BSDate"
                    xlWorksheet1.Range("P5").Value = "RepDate"
                    xlWorksheet1.Columns("O:P").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")



                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()



                    EXCELL.Application.DisplayAlerts = False
                    xlWorkBook.SaveAs(ExcelFileDetailsName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                    EXCELL.Application.DisplayAlerts = True
                    xlWorkBook.Close()
                    EXCELL.Quit()
                    EXCELL = Nothing
                    'Excel Instanz beenden
                    Dim procs22() As Process = Process.GetProcessesByName("EXCEL")
                    Dim i22 As Short
                    i22 = 0
                    For i22 = 0 To (procs22.Length - 1)
                        procs22(i22).Kill()
                    Next i22

                    Me.BgwODASimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Excel File:\de_bal_sheet_dtl-en.xls reformated sucesfully")

                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Insert Data to Table: DAILY BALANCE DETAIL SHEETS ")

                    cmd.CommandText = "INSERT INTO [DailyBalanceDetailsSheets]([GL_Item],[ReleatedAccountNr],[IS_Code],[InputDate],[StartDate],[EndDate],[NextRepricingDate],[GL_Account_Nr],[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate]) SELECT [GL_Item],[ReleatedAccountNr],[IS_Code],[InputDate],[StartDate],[EndDate],[NextRepricingDate],LTRIM(RTRIM([GL_Account_Nr])),[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],'" & rdsql & "','" & SqlRepDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileDetailsName & ";','SELECT * FROM [Sheet1$] where [GL_Account_Nr]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileDetailsName & ";','SELECT Count(*) FROM [Sheet1$] where [GL_Account_Nr] is not NULL')"
                    Me.BgwODASimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in DailyBalanceDetailsSheets")


                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "DAILY_BALANCE_SHEET_DETAILS_UPDATES"
                    Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('DAILY_BALANCE_SHEET_DETAILS_UPDATES') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    ParameterStatus = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwODASimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start SEVERAL SELECTIONS - DAILY_BALANCE_SHEET_DETAILS_UPDATES")
                        cmd.CommandText = "SELECT [BSDate] FROM [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "'"
                        HasDataResult = cmd.ExecuteScalar
                        If IsNothing(HasDataResult) = False Then
                            Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('DAILY_BALANCE_SHEET_DETAILS_UPDATES')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                    Me.BgwODASimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands in : " & dt.Rows.Item(i).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        End If
                    End If

                    Me.BgwODASimport.ReportProgress(100, "Import procedure: DAILY BALANCE DETAIL SHEET finished sucesfully")


                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - " & "File does not exist in Import Directory - File Name:" & ExcelFileName & " or File Name: " & ExcelFileDetailsName)

                End If



            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import Procedure:DAILY BALANCE SHEET is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub ODAS_IMPORT_DAILY_BALANCE_DETAILS_SHEETS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "DAILY BALANCE DETAIL SHEET"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='DAILY BALANCE DETAIL SHEET' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwODASimport.ReportProgress(1, "Start import: DAILY BALANCE DETAIL SHEET")
                Dim ExcelFileName As String = ""
                ExcelFileName = OdasFileNewDirectory & "\de_bal_sheet_dtl-en.xls"



                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    Me.BgwODASimport.ReportProgress(2, "Reformate Excel File:\de_bal_sheet_dtl-en.xls")

                    xlWorksheet1.Range("A5").Value = "GL_Item"
                    xlWorksheet1.Range("B5").Value = "ReleatedAccountNr"
                    xlWorksheet1.Range("C5").Value = "IS_Code"
                    xlWorksheet1.Range("D5").Value = "InputDate"
                    xlWorksheet1.Range("E5").Value = "StartDate"
                    xlWorksheet1.Range("F5").Value = "EndDate"
                    xlWorksheet1.Range("G5").Value = "NextRepricingDate"
                    xlWorksheet1.Columns("D:G").numberformat = "yyyymmdd"

                    xlWorksheet1.Range("H5").Value = "GL_Account_Nr"
                    xlWorksheet1.Range("I5").Value = "GL_Account_Name"
                    xlWorksheet1.Range("J5").Value = "Orig_CUR"
                    xlWorksheet1.Range("K5").Value = "Orig_Balance"
                    xlWorksheet1.Range("L5").Value = "Balance_EUR_CR"
                    xlWorksheet1.Range("M5").Value = "Balance_EUR_DR"
                    xlWorksheet1.Range("N5").Value = "Total_Balance"

                    xlWorksheet1.Range("O5").Value = "BSDate"
                    xlWorksheet1.Range("P5").Value = "RepDate"
                    xlWorksheet1.Columns("O:P").numberformat = "yyyymmdd"

                    'Risk Date definieren
                    'rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                    'Dim rdsql As String = rd.ToString("yyyyMMdd")



                    xlWorksheet1.Rows("1:4").delete()
                    'Unmerge Cells
                    xlWorksheet1.Columns("A:A").unMerge()



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

                    Me.BgwODASimport.ReportProgress(6, "Excel File:\de_bal_sheet_dtl-en.xls reformated sucesfully")



                    Dim IntagibleAssetsBefore As Double = 0
                    Dim IntagibleAssetsAfter As Double = 0
                    Dim IntagibleDifference As Double = 0

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    cmd.CommandText = "SELECT distinct [BSDate] FROM [DailyBalanceDetailsSheets] Where [BSDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                    Else
                        Dim RepDate As Date = DateAdd(DateInterval.Day, 1, rd)
                        Dim SqlRepDate As String = RepDate.ToString("yyyyMMdd")
                        cmd.CommandText = "Select [Total_Balance] from [DailyBalanceDetailsSheets] where [GL_Account_Nr] in ('19531000','187107') and BSDate in (select max([BSDate]) from DailyBalancedetailsSheets)"
                        IntagibleAssetsBefore = cmd.ExecuteScalar
                        Me.BgwODASimport.ReportProgress(7, "Insert Data to Table: DAILY BALANCE DETAIL SHEETS ")
                        cmd.CommandText = "INSERT INTO [DailyBalanceDetailsSheets]([GL_Item],[ReleatedAccountNr],[IS_Code],[InputDate],[StartDate],[EndDate],[NextRepricingDate],[GL_Account_Nr],[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate]) SELECT [GL_Item],[ReleatedAccountNr],[IS_Code],[InputDate],[StartDate],[EndDate],[NextRepricingDate],LTRIM(RTRIM([GL_Account_Nr])),[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],'" & rdsql & "','" & SqlRepDate & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [GL_Account_Nr]')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where [GL_Account_Nr] is NULL and [BSDate]='" & rdsql & "' "
                        'Count Imported Rows
                        cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [GL_Account_Nr] is not NULL')"
                        Me.BgwODASimport.ReportProgress(7, cmd.ExecuteScalar & " rows imported in DailyBalanceDetailsSheets")

                        Me.BgwODASimport.ReportProgress(7, "Check Balances for GL Account Nr.19531000,187107 ")
                        cmd.CommandText = "Select [Total_Balance] from [DailyBalanceDetailsSheets] where [GL_Account_Nr] in ('19531000','187107') and BSDate in (select max([BSDate]) from DailyBalancedetailsSheets)"
                        IntagibleAssetsAfter = cmd.ExecuteScalar
                        If IntagibleAssetsBefore <> IntagibleAssetsAfter Then
                            IntagibleDifference = IntagibleAssetsBefore - IntagibleAssetsAfter
                            cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_INTANGIBLE_ASSETS'"
                            Dim result As String = cmd.ExecuteScalar
                            If result = "Y" Then
                                Me.BgwODASimport.ReportProgress(70, "Parameter:EMAIL_INTANGIBLE_ASSETS is Valid")
                                QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_INTANGIBLE_ASSETS'"
                                da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt3 = New DataTable()
                                da3.Fill(dt3)

                                Dim EMAIL_USERS As String = ""
                                For i1 = 0 To dt3.Rows.Count - 1
                                    EMAIL_USERS += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                                Next
                                dt3.Clear()


                                Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
                                Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
                                Dim outApp As Microsoft.Office.Interop.Outlook.Application


                                outApp = New Microsoft.Office.Interop.Outlook.Application

                                NSpace = outApp.GetNamespace("MAPI")
                                Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
                                EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                                EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

                                EItem.To = EMAIL_USERS

                                EItem.Subject = "GL Account Nr.187107 (Accumulated depreciation - Software Cost) Balance has being changed on  " & rd
                                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain
                                Dim StrBody1 As String = "******This is an automated E-Mail, generated from the PS TOOL Application!******"
                                Dim EMAIL_TEXT As String = ""
                                Dim myBuilder As New StringBuilder

                                EMAIL_TEXT = "GL Account Nr.187107 (Accumulated depreciation - Software Cost) Balance is changed durring the last two business days " & vbNewLine & vbNewLine & "Forelast Balance (€): " & Format(IntagibleAssetsBefore, "#,##0.00") & vbNewLine & "Last Balance (€):" & Format(IntagibleAssetsAfter, "#,##0.00") & vbNewLine & "Difference:" & Format(IntagibleDifference, "#,##0.00")

                                EItem.Body = StrBody1 & vbNewLine & vbNewLine & EMAIL_TEXT & vbNewLine & vbNewLine
                                EItem.Display()

                            End If

                        End If
                    End If

                    Me.BgwODASimport.ReportProgress(8, "Update Field:GL_Item_Number in Table Daily Balance Details Sheets")
                    cmd.CommandText = "Update [DailyBalanceDetailsSheets] set [GL_Item_Number]=REPLACE([GL_Item],'I','') where [BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.GL_Account_Name=B.GL_AC_Name from DailyBalanceDetailsSheets A INNER JOIN GL_ACCOUNTS B on A.GL_Account_Nr=B.NG_GL_AC_No where A.BSDate='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    '######################################################################################
                    'GL ART Matching
                    '######################################################################################
                    Me.BgwODASimport.ReportProgress(8, "Matching GL Art for each Balance Sheet and PL Sheet Item")
                    cmd.CommandText = "Select * from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "' begin update [DailyBalanceDetailsSheets] set [GL_Art]='Activa' where [GL_Item_Number]<=2998 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Activa - Off Balance' where [GL_Item_Number]>=8000 and [GL_Item_Number]<=8999 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Passiva' where [GL_Item_Number]>=3000 and [GL_Item_Number]<=4998 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Passiva - Off Balance' where [GL_Item_Number]>=9000 and [GL_Item_Number]<=9999 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Profit + Loss - Income' where [GL_Item_Number]>=5000 and [GL_Item_Number]<=6998 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Profit + Loss - Expenses' where [GL_Item_Number]>=7000 and [GL_Item_Number]<=7998 and [BSDate]='" & rdsql & "' end"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(8, "Update Field:IdBalanceSheets,RilibiCode,RilibiName based on GL_ITEM in Table Daily Balance Sheets")
                    cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID],A.[RilibiCode]=B.[RilibiCode],A.[RilibiName]=B.[RilibiName] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(8, "Delete all data if GL Account Nr is NULL")
                    cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where [IdBalanceSheets] is NULL"
                    cmd.ExecuteNonQuery()

                    Me.BgwODASimport.ReportProgress(100, "Import procedure: DAILY BALANCE DETAIL SHEET finished sucesfully")

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import Procedure:DAILY BALANCE DETAIL SHEET is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub ODAS_IMPORT_MOVEMENTS_DETAILS()
        Try

            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "MOVEMENTS DETAILS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [ODAS IMPORT PROCEDURES] WHERE [ProcName]='MOVEMENTS DETAILS' and [Valid]='Y'"
            cmd.Connection.Open()
            cmd.CommandTimeout = 50000

            If cmd.ExecuteScalar > 0 Then

                Me.BgwODASimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure:MOVEMENTS DETAILS")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\ts_d_1047-en.xlsx"
                ExcelFileName = OdasFileNewDirectory & "\movement_dtl-en.xls"

                If File.Exists(ExcelFileName) = True Then

                    Me.BgwODASimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import:movement_dtl-en.xls...Please wait...")

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
                    'xlWorksheet1.Columns("A:A").unMerge()
                    xlWorksheet1.Rows("1:3").delete()

                    xlWorksheet1.Range("A1").Value = "Class"
                    xlWorksheet1.Range("B1").Value = "Category"
                    xlWorksheet1.Range("C1").Value = "ContractType"
                    xlWorksheet1.Range("D1").Value = "ProductType"
                    xlWorksheet1.Range("E1").Value = "GL_Master"
                    xlWorksheet1.Range("F1").Value = "Contract"
                    xlWorksheet1.Range("G1").Value = "ClientNr"
                    xlWorksheet1.Range("H1").Value = "ClientName"
                    xlWorksheet1.Range("I1").Value = "AmountType"
                    xlWorksheet1.Range("J1").Value = "Amount"
                    xlWorksheet1.Range("K1").Value = "EventType"



                    'Dim ExcelFileNameNew As String = ""
                    'ExcelFileNameNew = OdasFileNewDirectory & "\FINRECON_NEW.xls"
                    'Me.BgwODASimport.ReportProgress(4, "Save excel Sheet as: " & ExcelFileNameNew)

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

                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('MOVEMENTS DETAILS') and [Id_SQL_Parameters] in ('ODAS_IMPORTS')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('MOVEMENTS DETAILS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i1 = 0 To dt.Rows.Count - 1
                            SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<ExcelFileName>", ExcelFileName)
                            SqlCommandText2 = SqlCommandText1.ToString.Replace("<RiskDate>", rdsql)
                            cmd.CommandText = SqlCommandText2
                            If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                Me.BgwODASimport.ReportProgress(i1, "Procedure:" & CURRENT_PROC & " - " & dt.Rows.Item(i1).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        Me.BgwODASimport.ReportProgress(0, "+++Import procedure SQL Parameter: MOVEMENTS DETAILS are not Valid+++")

                    End If

                Else
                    Me.BgwODASimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - " & "File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
                Me.BgwODASimport.ReportProgress(100, "Import procedure:MOVEMENTS DETAILS finished sucesfully")

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            Else
                Me.BgwODASimport.ReportProgress(0, "+++Import procedure: MOVEMENTS DETAILS ist not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwODASimport.ReportProgress(0, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub Excel_Test()
        '**********TEST ***********


        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
        workbook.LoadDocument("C:\int_rate_risk_all-en.xlsx", DocumentFormat.Xlsx)
        Dim sheet As Worksheet = workbook.Worksheets("Sheet1")

        Me.BgwODASimport.ReportProgress(3, "Changing Column Names-(J9=CURRENCY)-(U9=DATA DATE)-(V9=RISK DATE)")
        sheet.Cells("J9").Value = "CURRENCY"
        sheet.Cells("U9").Value = "DATA DATE"
        sheet.Cells("V9").Value = "RISK DATE"
        sheet.Cells("D9").Value = "Contract/Account"


        'Währung + Datum einfügen wo daten vorhanden sind
        'Wenn Contract/Account nicht leer sind 
        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Input Risk date")


        ' Neue Zeile für PERIOD einfügen

        sheet.Columns("A").Insert()
        sheet.Cells("A9").Value = "PERIOD"


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

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Input correct period format")
        For i = 9 To 5000
            Me.ODASProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_ODAS_EXCEL))
            '<=1 month net positions:
            If sheet.Cells(i, 9).Value.TextValue = "<= 1 month net positions:" Then
                sheet.Cells(i, 0).Value = p1
            End If
            '1 - 3 months net positions:
            If sheet.Cells(i, 9).Value.TextValue = "1 - 3 months net positions:" Then
                sheet.Cells(i, 0).Value = p2
            End If
            '3 - 6 months net positions:
            If sheet.Cells(i, 9).Value.TextValue = "3 - 6 months net positions:" Then
                sheet.Cells(i, 0).Value = p3
            End If
            '6 - 12 months net positions:
            If sheet.Cells(i, 9).Value.TextValue = "6 - 12 months net positions:" Then
                sheet.Cells(i, 0).Value = p4
            End If
            '1 - 2 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "1 - 2 years net positions:" Then
                sheet.Cells(i, 0).Value = p5
            End If
            '2 - 3 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "2 - 3 years net positions:" Then
                sheet.Cells(i, 0).Value = p6
            End If
            '3 - 4 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "3 - 4 years net positions:" Then
                sheet.Cells(i, 0).Value = p7
            End If
            '4 - 5 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "4 - 5 years net positions:" Then
                sheet.Cells(i, 0).Value = p8
            End If
            '5 - 7 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "5 - 7 years net positions:" Then
                sheet.Cells(i, 0).Value = p9
            End If
            '7 - 10 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "7 - 10 years net positions:" Then
                sheet.Cells(i, 0).Value = p10
            End If
            '10 - 15 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "10 - 15 years net positions:" Then
                sheet.Cells(i, 0).Value = p11
            End If
            '15 - 20 years net positions:
            If sheet.Cells(i, 9).Value.TextValue = "15 - 20 years net positions:" Then
                sheet.Cells(i, 0).Value = p12
            End If
        Next i


        'Einfügen der Perioden auf die jeweiligen leerzeilen
        Dim q As Integer = 9
        Dim options As New SearchOptions()
        options.MatchCase = True
        Dim foundCells As IEnumerable(Of Cell)


        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:<= 1 Month")
        foundCells = sheet.Range("A1:A5000").Search(p1, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p1
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p1
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:1 - 3 Months")
        foundCells = sheet.Range("A1:A5000").Search(p2, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p2
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p2
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:3 - 6 Months")
        foundCells = sheet.Range("A1:A5000").Search(p3, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p3
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p3
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:6 - 12 Months")
        foundCells = sheet.Range("A1:A5000").Search(p4, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p4
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p4
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:1 - 2 Years")
        foundCells = sheet.Range("A1:A5000").Search(p5, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p5
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p5
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:2 - 3 Years")
        foundCells = sheet.Range("A1:A5000").Search(p6, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p6
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p6
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:3 - 4 Years")
        foundCells = sheet.Range("A1:A5000").Search(p7, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p7
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p7
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:4 - 5 Years")
        foundCells = sheet.Range("A1:A5000").Search(p8, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p8
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p8
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:5 - 7 Years")
        foundCells = sheet.Range("A1:A5000").Search(p9, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p9
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p9
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:7 - 10 Years")
        foundCells = sheet.Range("A1:A5000").Search(p10, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p10
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p10
                End If
                q = q + 1
            Loop
        End If

        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:10 - 15 Years")
        foundCells = sheet.Range("A1:A5000").Search(p11, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p11
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p11
                End If
                q = q + 1
            Loop
        End If



        Me.BgwODASimport.ReportProgress(5, "Reformating Excel File from Row 10 to 5000-Find:15 - 20 Years")
        foundCells = sheet.Range("A1:A5000").Search(p12, options)
        If foundCells Is Nothing Then

        Else
            Do Until sheet.Cells(q, 0).Value.TextValue = p12
                If sheet.Cells(q, 0).Value.TextValue = "" Then
                    sheet.Cells(q, 0).Value = p12
                End If
                q = q + 1
            Loop
        End If



        sheet.Rows.Remove(0, 7)
        'sheet.Columns("B:B").UnMerge()
        'sheet.Columns("N:U").Delete()


        workbook.SaveDocument("C:\DevExpressTestExcel.xlsx", DocumentFormat.Xlsx)



        '**************
    End Sub

    Private Sub ERRORS_EMAIL_ODAS()

        '**************************************************************************************
        ''****************************Generate E-Mail for errors*******************************
        '**************************************************************************************
        Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='IMPORT_ERRORS_EMAIL'"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Dim EMAIL_USERS As String = ""
            For i = 0 To dt.Rows.Count - 1
                EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
            Next
            dt.Clear()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd.CommandText = "Select Max([ID]) from [IMPORT EVENTS] where [Event] like 'ERROR%' and  [SystemName] in ('ODAS')"
            cmd.Connection.Open()
            Dim maxid As Double = cmd.ExecuteScalar()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Dim myBuilder As New StringBuilder

            Me.QueryText = "SELECT * FROM [IMPORT EVENTS] where [ID]=" & maxid & "  order by ID desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim ErrorDate As Date = dt.Rows.Item(0).Item("ProcDate")
                Dim headers As String = "On " & ErrorDate & "the following import error have being occured in ODAS Imports:" & vbNewLine
                Dim Footer As String = "(Please check the error and restart the related import procedure)" & vbNewLine


                For i = 0 To dt.Rows.Count - 1
                    myBuilder.Append("ID: " & dt.Rows.Item(i).Item("ID") & "  Error Text: " & dt.Rows.Item(i).Item("Event") & "  Procedure Name: " & dt.Rows.Item(i).Item("ProcName") & " System: " & dt.Rows.Item(i).Item("SystemName") & vbNewLine)
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

                EItem.Subject = "PS TOOL - ODAS IMPORT ERROR on " & " " & ErrorDate

                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

                Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

                EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
                EItem.Send()

            End If
        End If
        '*******************************************************************************************
    End Sub



End Class