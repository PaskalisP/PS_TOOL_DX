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
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.Spreadsheet
Imports GemBox.Spreadsheet
Imports DevExpress.Compression
Imports Ionic.Zip
Public Class OcbsImport

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""

    Dim OdasDirectory As String = "" 'ODAS FILE DIRECTORY
    Dim OdasFileNewDirectory As String = "" 'NEW DIRECTORY FOR ODAS FILE
    Dim OCBSDirectory As String = "" 'OCBS FILE DIRECTORY
    Dim OCBSFileNewDirectory As String = "" 'NEW DIRECTORY FOR OCBS FILE

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim SqlCommandText As String = Nothing
    Dim HasDataResult As String = Nothing

    Dim connEVENT As New SqlConnection
    Dim cmdEVENT As New SqlCommand
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
    Dim ACTIVE_PROC As String = ""

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
    Dim OcbsAutomatedImport_btn_clicked As Boolean = False 'Button for Automated Import
    Dim OcbsSelectedFileImport_btn_clicked As Boolean = False 'Button for single File import
    Dim OcbsImportFromTill_btn_clicked As Boolean = False
    Dim CURRENT_LAST_IMPORTED_OCBS_FILE As Double = Nothing

    Dim MaxProcDate As Date

    Dim rd As Date
    Dim rdsql As String = Nothing
    Dim EMAIL_USERS As String = Nothing

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
    Private Sub OCBS_IMPORT_PROCEDURESBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.OCBS_IMPORT_PROCEDURESBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

#Region "SPECIAL_FUNCTIONS"

    'Change the Current OCBS File in Form
    Public Sub Change_COBIF()
        Me.CurrentOcbsImportFile.Text = COBIF
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

    'Clear Current OCBS Import File in Form
    Public Sub Clear_COBIF()
        Me.CurrentOcbsImportFile.Text = ""
        Me.CURRENT_PROCEDURE_Text.Text = ""
    End Sub

    'Show Progress in a OCBS Excel File with 5000 Rows
    Public Sub PROGRESS_OCBS_MAX5()
        Me.OCBSProgressBar.Maximum = 5000
    End Sub

    'Show Progress in a OCBS Excel File with 10000 Rows
    Public Sub PROGRESS_OCBS_MAX10()
        Me.OCBSProgressBar.Maximum = 10000
    End Sub

    'Show Progress in a OCBS Excel File-Progress Bar
    Public Sub PROGRESS_OCBS_EXCEL()
        Me.OCBSProgressBar.Increment(1)
        If Me.OCBSProgressBar.Value = Me.OCBSProgressBar.Maximum Then
            Me.OCBSProgressBar.Value = 0
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
                Me.OCBS_IMPORT_PROCEDURESBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Activate all Procedures
        If e.Button.Tag = "ActivateProcs" Then
            Try
                If MessageBox.Show("Should all current Procedures be activated", "ACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    cmd.CommandText = "UPDATE [OCBS IMPORT PROCEDURES] SET [Valid]='Y' where [Importance] in ('MANDATORY')"
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Activate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Deactivate all Procedures
        If e.Button.Tag = "DeactivateProcs" Then
            Try
                If MessageBox.Show("Should all current Procedures be Deactivated", "DEACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    cmd.CommandText = "UPDATE [OCBS IMPORT PROCEDURES] SET [Valid]='N'"
                    cmd.Connection.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Deactivate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If
        'Terminate OCBS Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwOCBSimport.IsBusy = True Then
                If MessageBox.Show("Should the OCBS import procedures be terminated?", "TERMINATE OCBS IMPORTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwOCBSimport.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("OCBS Imports termination is requested..." & vbNewLine & "Please wait until the current OCBS Import operations are finished!")
                End If
            End If
        End If

    End Sub
    Private Sub OcbsImportProcedures_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles OcbsImportProcedures_BasicView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OcbsImportProcedures_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles OcbsImportProcedures_BasicView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OcbsImportProcedures_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OcbsImportProcedures_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles OcbsImportProcedures_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub OCBSImportEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles OCBSImportEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub OCBSImportEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles OCBSImportEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub OcbsImportProcedures_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles OcbsImportProcedures_BasicView.ValidateRow
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

    Private Sub Print_Export_OCBS_ImportProcedures_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_OCBS_ImportProcedures_Gridview_btn.Click
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
        Dim reportfooter As String = "NGS IMPORT PROCEDURES"

        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 100)
        e.Graph.DrawString(reportfooter, Color.Navy, rec, DevExpress.XtraPrinting.BorderSide.None)
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
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub
#End Region

#Region "ENABLE_DISABLE_CONTROLS_BY_IMPORT"
    Private Sub DISABLE_START_IMPORT()
        'Set Import settings
        Me.OCBSProgressBar.Visible = True
        OcbsSelectedImport_btn.Enabled = False
        OcbsAutomatedImport_btn.Enabled = False
        OcbsFromTillImport_btn.Enabled = False
        LastOcbsImportFile.Enabled = False
        SelectedOcbsImportFile.Enabled = False
        OcbsImportFileFrom.Enabled = False
        OcbsImportFileTill.Enabled = False
        'Cancel all Excel applications
        'Excel Instanz beenden
        'Dim procs() As Process = Process.GetProcessesByName("EXCEL")
        'Dim i1 As Short
        'i1 = 0
        'For i1 = 0 To (procs.Length - 1)
        '    procs(i1).Kill()
        'Next i1
        '*********************************
    End Sub

    Private Sub ENABLE_FINISH_IMPORT()
        Me.EVENTSloadtext.Text = ""
        Me.OCBSProgressBar.Value = 0
        Me.OCBSProgressBar.Visible = False
        OcbsSelectedImport_btn.Enabled = True
        OcbsAutomatedImport_btn.Enabled = True
        OcbsFromTillImport_btn.Enabled = True
        LastOcbsImportFile.Enabled = True
        SelectedOcbsImportFile.Enabled = True
        OcbsImportFileFrom.Enabled = True
        OcbsImportFileTill.Enabled = True
    End Sub
#End Region

#Region "BUTTONS_AND_EDITORS_EVENTS"
    Private Sub LastOcbsImportFile_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LastOcbsImportFile.ButtonClick
        If IsNumeric(LastOcbsImportFile.Text) = True And Len(LastOcbsImportFile.Text) = 8 Then
            If MessageBox.Show("Should the NGS File Nr. " & LastOcbsImportFile.Text & " be saved as Last Imported NGS file", "CHANGE THE LAST IMPORTED NGS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim LastOCBSImportFile As Double = Me.LastOcbsImportFile.Text
                Me.FILES_IMPORTBindingSource.EndEdit()
                Me.FILES_IMPORTTableAdapter.UpdateOCBS_LastImportFile(LastOCBSImportFile)
                Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)
            Else
                Me.FILES_IMPORTBindingSource.CancelEdit()
                Exit Sub
            End If
        Else
            MessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub

        End If
    End Sub

    Private Sub LastOcbsImportFile_Leave(sender As Object, e As EventArgs) Handles LastOcbsImportFile.Leave
        If IsNumeric(LastOcbsImportFile.Text) = False OrElse Len(LastOcbsImportFile.Text) <> 8 Then
            MessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub
        End If
    End Sub
    Private Sub SelectedOcbsImportFile_Leave(sender As Object, e As EventArgs) Handles SelectedOcbsImportFile.Leave
        If Me.SelectedOcbsImportFile.Text <> "" Then
            If IsNumeric(SelectedOcbsImportFile.Text) = False OrElse Len(SelectedOcbsImportFile.Text) <> 8 Then
                MessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.SelectedOcbsImportFile.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OcbsImportFileFrom_Leave(sender As Object, e As EventArgs) Handles OcbsImportFileFrom.Leave
        If Me.OcbsImportFileFrom.Text <> "" Then
            If IsNumeric(OcbsImportFileFrom.Text) = False OrElse Len(OcbsImportFileFrom.Text) <> 8 Then
                MessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.OcbsImportFileFrom.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OcbsImportFileTill_Leave(sender As Object, e As EventArgs) Handles OcbsImportFileTill.Leave
        If Me.OcbsImportFileTill.Text <> "" Then
            If IsNumeric(OcbsImportFileTill.Text) = False OrElse Len(OcbsImportFileTill.Text) <> 8 Then
                MessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.OcbsImportFileTill.Text = ""
                Exit Sub
            End If
        End If

    End Sub


    Private Sub OcbsAutomatedImport_btn_Click(sender As Object, e As EventArgs) Handles OcbsAutomatedImport_btn.Click
        OcbsAutomatedImport_btn_clicked = True
        OcbsSelectedFileImport_btn_clicked = False
        OcbsImportFromTill_btn_clicked = False
        If Me.LastOcbsImportFile.Text <> "" Then
            If MessageBox.Show("Should the automated NGS Fileimport be executed?" & vbNewLine & vbNewLine & "ATTENTION!!! - PLEASE SAVE & CLOSE ALL OPEN EXCEL FILES BEFORE START THE IMPORT", "AUTOMATED IMPORT NGS FILES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwOCBSimport.IsBusy = False Then
                    Me.BgwOCBSimport.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub OcbsSelectedImport_btn_Click(sender As Object, e As EventArgs) Handles OcbsSelectedImport_btn.Click
        OcbsSelectedFileImport_btn_clicked = True
        OcbsAutomatedImport_btn_clicked = False
        OcbsImportFromTill_btn_clicked = False
        If Me.SelectedOcbsImportFile.Text <> "" Then
            If MessageBox.Show("Should the NGS Filename " & SelectedOcbsImportFile.Text & " be imported?" & vbNewLine & vbNewLine & "ATTENTION!!! - PLEASE SAVE & CLOSE ALL OPEN EXCEL FILES BEFORE START THE IMPORT", "IMPORT NGS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwOCBSimport.IsBusy = False Then
                    Me.BgwOCBSimport.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub OcbsFromTillImport_btn_Click(sender As Object, e As EventArgs) Handles OcbsFromTillImport_btn.Click
        OcbsImportFromTill_btn_clicked = True
        OcbsAutomatedImport_btn_clicked = False
        OcbsSelectedFileImport_btn_clicked = False

        If Me.OcbsImportFileFrom.Text <> "" AndAlso Me.OcbsImportFileTill.Text <> "" Then
            Dim n1 As Double = Me.OcbsImportFileFrom.Text
            Dim n2 As Double = Me.OcbsImportFileTill.Text
            If n2 >= n1 Then
                If MessageBox.Show("Should the NGS Import start with Filename " & n1 & " and finish with Filename " & n2 & vbNewLine & vbNewLine & "ATTENTION!!! - PLEASE SAVE & CLOSE ALL OPEN EXCEL FILES BEFORE START THE IMPORT", "IMPORT NGS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_IMPORT()
                    If Me.BgwOCBSimport.IsBusy = False Then
                        CURRENT_LAST_IMPORTED_OCBS_FILE = Me.LastOcbsImportFile.Text
                        Me.BgwOCBSimport.RunWorkerAsync()
                    End If
                End If
            Else
                MessageBox.Show("The last Filename is earlier than the first Filename!", "WRONG FILENAMES IMPORT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub
#End Region

#Region "OCBS_IMPORT_BACKGROUNDWORKER"
    Private Sub BgwOCBSimport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOCBSimport.DoWork

        '***********AUTOMATED OCBS IMPORT****************
        If OcbsAutomatedImport_btn_clicked = True Then

            Try
                Me.BgwOCBSimport.ReportProgress(10, "Locate the NGS Current and Temp Directory")

                'Heutiges Datum ermitteln und in Zahl unformatieren
                Dim CurDate As Date = Today
                Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                cmdOCBS.Connection.Open()
                OCBSDirectory = cmdOCBS.ExecuteScalar()
                cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                OCBSFileNewDirectory = cmdOCBS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

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
                Me.BgwOCBSimport.ReportProgress(45, "Delete from Table: OCBS FILES where FileName < Last NGS Import File: " & Me.LastOcbsImportFile.Text)
                cmdOCBS.CommandText = "DELETE FROM [OCBS FILES] where [FileName]<'" & Me.LastOcbsImportFile.Text & "'"
                cmdOCBS.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(50, "Delete from Table: OCBS FILES where FileName >= Current Date: " & CurDateSql)
                cmdOCBS.CommandText = "DELETE FROM [OCBS FILES] where [FileName]>='" & CurDateSql & "'"
                cmdOCBS.ExecuteNonQuery()


                Me.QueryText = "SELECT [FileName],[FileFullName]  FROM [OCBS FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwOCBSimport.ReportProgress(50, "Determine the next NGS File for Import...Please wait...")

                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileName] as NextFileNameforimport,[FileFullName] as NextFileFullName from [OCBS FILES] where [FileName] in (SELECT min([FileName])FROM [OCBS FILES] where [FileName]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('OCBS','NGS')))"
                    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        COBIF = dt1.Rows.Item(0).Item("NextFileNameforimport")
                        'Define Business Date based on the COBIF
                        Dim BTD As String = COBIF
                        rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                        rdsql = rd.ToString("yyyyMMdd")
                        '**************************************************************************
                        If Me.BgwOCBSimport.CancellationPending = False Then
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
                            OCBS_Temp_Directory = OCBSFileNewDirectory

                            Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & COBIF & " is ready")
                            Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")

                            'PROCEDUREN
                            OCBS_IMPORT_PROCEDURES()

                            'Erstellten Ordner wieder löschen
                            Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                            Directory.Delete(OCBSFileNewDirectory, True)
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwOCBSimport.ReportProgress(90, "Set as Last imported NGS File Name: " & "  " & COBIF)
                            cmdOCBS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & COBIF & "' WHERE [SYSTEM_NAME] in ('OCBS','NGS')"
                            cmdOCBS.ExecuteNonQuery()

                            LOBIF = COBIF
                            Me.LastOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOBIF))
                            COBIF = Nothing
                            Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COBIF))

                            'Füllen des Table adapters

                            Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & LCOBIF & " " & "is finished ...")
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")
                        ElseIf Me.BgwOCBSimport.CancellationPending = True Then
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Imports are terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                        End If

                    End If
                Next m
                'Löschen der Temporären Tabelen für den OCBS Import
                cmdOCBS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdOCBS.ExecuteNonQuery()
                cmdOCBS.CommandText = "DROP TABLE [OCBSFilesTemp]"
                cmdOCBS.ExecuteNonQuery()
                cmdOCBS.CommandText = "DROP TABLE [OCBS FILES]"
                cmdOCBS.ExecuteNonQuery()
                cmdOCBS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdOCBS.ExecuteNonQuery()

                If cmdOCBS.Connection.State = ConnectionState.Open Then
                    cmdOCBS.Connection.Close()
                End If

            Catch ex As System.Exception
                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS file: " & " " & Me.CurrentOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
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
            '*****************************************************************************
        End If


        '****************SELECTED OCBS FILE IMPORT************************************
        If OcbsSelectedFileImport_btn_clicked = True Then
            Try
                Me.BgwOCBSimport.ReportProgress(10, "Locate the NGS Current and Temp Directory")

                'Heutiges Datum ermitteln und in Zahl unformatieren
                Dim CurDate As Date = Today
                Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                cmdOCBS.Connection.Open()
                OCBSDirectory = cmdOCBS.ExecuteScalar()
                cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                OCBSFileNewDirectory = cmdOCBS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

                Dim OcbsFileFullName As String = OCBSDirectory & Me.SelectedOcbsImportFile.Text 'Full File Directory
                Dim OcbsFileName As String = Me.SelectedOcbsImportFile.Text 'File for Import

                If Directory.Exists(OcbsFileFullName) = True Then
                    'Define Business Date based on the OdasFileName
                    Dim BTD As String = OcbsFileName
                    rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                    rdsql = rd.ToString("yyyyMMdd")
                    '**************************************************************************
                    ' Ordner einschl. aller Unterordner kopieren
                    Me.BgwOCBSimport.ReportProgress(65, "Copy Folder:" & OcbsFileFullName & " to " & OCBSFileNewDirectory)
                    CopyFolder(OcbsFileFullName, OCBSFileNewDirectory)
                    'OCBS Directory with all files for Import
                    OCBS_Temp_Directory = OCBSFileNewDirectory
                    Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & OcbsFileName & " is ready")
                    Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")

                    '++++++++PROZESSE+++++++++++++
                    OCBS_IMPORT_PROCEDURES()

                    '++++++++++++++++++++++++++++++++++++++++++++++
                    'Erstellten Ordner wieder löschen
                    'Erstellten Ordner wieder löschen
                    Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                    Directory.Delete(OCBSFileNewDirectory, True)

                    Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & OcbsFileName & " " & "is finished ...")
                    Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")

                Else
                    MessageBox.Show("NGS File: " & SelectedOcbsImportFile.Text & " does not exists!", "NGS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                If cmdOCBS.Connection.State = ConnectionState.Open Then
                    cmdOCBS.Connection.Close()
                End If

            Catch ex As Exception

                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS File: " & " " & Me.SelectedOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub

            Finally
                Me.BgwOCBSimport.CancelAsync()
                'Directory Löschen
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
        End If
        '***********************************************************************************************

        '***********************OCBS IMPORT FROM...TILL*************************
        If OcbsImportFromTill_btn_clicked = True Then
            Try
                Me.BgwOCBSimport.ReportProgress(10, "Locate the NGS Current and Temp Directory")

                'Heutiges Datum ermitteln und in Zahl unformatieren
                Dim CurDate As Date = Today
                Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                cmdOCBS.Connection.Open()
                OCBSDirectory = cmdOCBS.ExecuteScalar()
                cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                OCBSFileNewDirectory = cmdOCBS.ExecuteScalar()

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

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
                Me.BgwOCBSimport.ReportProgress(45, "Delete from Table: OCBS FILES where FileName NOT BETWEEN " & Me.OcbsImportFileFrom.Text & " and " & Me.OcbsImportFileTill.Text)
                cmdOCBS.CommandText = "DELETE FROM [OCBS FILES] where [FileName] NOT BETWEEN'" & Me.OcbsImportFileFrom.Text & "' and '" & Me.OcbsImportFileTill.Text & "'"
                cmdOCBS.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(50, "Delete from Table: OCBS FILES where FileName >= Current Date: " & CurDateSql)
                cmdOCBS.CommandText = "DELETE FROM [OCBS FILES] where [FileName]>='" & CurDateSql & "'"
                cmdOCBS.ExecuteNonQuery()
                'set temporary LastImportedODASfile and load
                Me.BgwOCBSimport.ReportProgress(50, "Set as Temporary Last Imported NGS File Name:20010101")
                cmdOCBS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & 20010101 & "' WHERE [SYSTEM_NAME] in ('OCBS','NGS')"
                cmdOCBS.ExecuteNonQuery()
                Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                Me.QueryText = "SELECT [FileName],[FileFullName]  FROM [OCBS FILES]"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwOCBSimport.ReportProgress(50, "Determine the next NGS File for Import...Please wait...")

                For m = 0 To dt.Rows.Count - 1
                    Me.QueryText = "Select  [FileName] as NextFileNameforimport,[FileFullName] as NextFileFullName from [OCBS FILES] where [FileName] in (SELECT min([FileName])FROM [OCBS FILES] where [FileName]>(Select [FileName] from [FILES_IMPORT] where [SYSTEM_NAME] in ('OCBS','NGS')))"
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
                        If Me.BgwOCBSimport.CancellationPending = False Then
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
                            OCBS_Temp_Directory = OCBSFileNewDirectory
                            Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & COBIF & " is ready")
                            Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")

                            'PROCEDUREN
                            OCBS_IMPORT_PROCEDURES()

                            'Erstellten Ordner wieder löschen
                            Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                            Directory.Delete(OCBSFileNewDirectory, True)
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwOCBSimport.ReportProgress(90, "Set as Last imported NGS File Name: " & "  " & COBIF)
                            cmdOCBS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & COBIF & "' WHERE [SYSTEM_NAME] in ('OCBS','NGS')"
                            cmdOCBS.ExecuteNonQuery()

                            LOBIF = COBIF
                            Me.LastOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOBIF))
                            COBIF = Nothing
                            Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COBIF))

                            'Füllen des Table adapters

                            Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & LCOBIF & " " & "is finished ...")
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")

                        ElseIf Me.BgwOCBSimport.CancellationPending = True Then
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Imports are terminated after user request!")
                            e.Cancel = True
                            SplashScreenManager.CloseForm(False)
                        End If

                    End If
                Next m

                'Löschen der Temporären Tabelen für den OCBS Import
                cmdOCBS.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdOCBS.ExecuteNonQuery()
                cmdOCBS.CommandText = "DROP TABLE [OCBSFilesTemp]"
                cmdOCBS.ExecuteNonQuery()
                cmdOCBS.CommandText = "DROP TABLE [OCBS FILES]"
                cmdOCBS.ExecuteNonQuery()
                cmdOCBS.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmdOCBS.ExecuteNonQuery()
                'Set as last OCBS imported file Name the first OCBS file name
                cmdOCBS.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & CURRENT_LAST_IMPORTED_OCBS_FILE & "' WHERE [SYSTEM_NAME] in ('OCBS','NGS')"
                cmdOCBS.ExecuteNonQuery()
                Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                If cmdOCBS.Connection.State = ConnectionState.Open Then
                    cmdOCBS.Connection.Close()
                End If

            Catch ex As System.Exception
                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS file: " & " " & Me.CurrentOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
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
            '*****************************************************************************
        End If
        '***********************************************************************
    End Sub

    Private Sub BgwOCBSimport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOCBSimport.ProgressChanged
        Me.EVENTSloadtext.Text = e.UserState
        Me.OCBSProgressBar.Value = e.ProgressPercentage

        Dim stackFrame As New Diagnostics.StackFrame()
        Dim rtnName As String = stackFrame.GetMethod.Name.ToString()
        rtnName = rtnName & stackFrame.GetMethod.DeclaringType.FullName.ToString()

        cmdEVENT.Connection.Open()
        cmdEVENT.CommandTimeout = 500
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & Me.EVENTSloadtext.Text & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','NGS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "NGS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & Me.CURRENT_PROCEDURE_Text.Text & "','NGS')"
            cmdEVENT.ExecuteNonQuery()
            '***************************************************
            TextImportFileRow = Now & "  " & "NGS" & "  " & Me.EVENTSloadtext.Text & "  " & Me.CURRENT_PROCEDURE_Text.Text
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

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
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByOCBSDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub BgwOCBSimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOCBSimport.RunWorkerCompleted
        ENABLE_FINISH_IMPORT()
        Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)
        Me.SelectedOcbsImportFile.Text = ""
        Me.OcbsImportFileFrom.Text = ""
        Me.OcbsImportFileTill.Text = ""
        'Set Button Click as default to False
        OcbsAutomatedImport_btn_clicked = False
        OcbsSelectedFileImport_btn_clicked = False
        OcbsImportFromTill_btn_clicked = False

        If cmdOCBS.Connection.State = ConnectionState.Open Then
            cmdOCBS.Connection.Close()
        End If

        Dim f As New GlobalClass
        f.NewImportEventsFolder()



    End Sub

#End Region


#Region "MANUAL IMPORTS FROM BUTTON"
    Private Sub StartImport_RepositoryItemButtonEdit_Click(sender As Object, e As EventArgs) Handles StartImport_RepositoryItemButtonEdit.Click
        If Me.SelectedOcbsImportFile.Text <> "" Then
            If OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colValid) = "Y" Then
                DISABLE_START_IMPORT()
                If MessageBox.Show("Should the NGS Import Procedure: " & OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) & " be executed?", "Start NGS manual Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Locate the NGS Current and Temp Directory")
                        Me.BgwOCBSimport.ReportProgress(10, "Locate the NGS Current and Temp Directory")

                        'Heutiges Datum ermitteln und in Zahl unformatieren
                        Dim CurDate As Date = Today
                        Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")

                        cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        cmdOCBS.Connection.Open()
                        OCBSDirectory = cmdOCBS.ExecuteScalar()
                        cmdOCBS.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        OCBSFileNewDirectory = cmdOCBS.ExecuteScalar()

                        'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                        Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)
                        SplashScreenManager.Default.SetWaitFormCaption("NGS Directories - Current: " & OCBSDirectory & vbNewLine & " - Temporary: " & OCBSFileNewDirectory)

                        Dim OcbsFileFullName As String = OCBSDirectory & Me.SelectedOcbsImportFile.Text 'Full File Directory
                        Dim OcbsFileName As String = Me.SelectedOcbsImportFile.Text 'File for Import

                        If Directory.Exists(OcbsFileFullName) = True Then
                            'Define Business Date based on the OdasFileName
                            Dim BTD As String = OcbsFileName
                            rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                            rdsql = rd.ToString("yyyyMMdd")
                            '**************************************************************************
                            ' Ordner einschl. aller Unterordner kopieren
                            Me.BgwOCBSimport.ReportProgress(65, "Copy Folder:" & OcbsFileFullName & " to " & OCBSFileNewDirectory)
                            SplashScreenManager.Default.SetWaitFormCaption("Copy Folder:" & OcbsFileFullName & " to " & OCBSFileNewDirectory)
                            CopyFolder(OcbsFileFullName, OCBSFileNewDirectory)
                            'OCBS Directory with all files for Import
                            OCBS_Temp_Directory = OCBSFileNewDirectory
                            Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & OcbsFileName & " is ready")
                            SplashScreenManager.Default.SetWaitFormCaption("NGS File for Import: " & "  " & OcbsFileName & " is ready")
                            Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")
                            SplashScreenManager.Default.SetWaitFormCaption("Starting the NGS Import procedures...")

                            '++++++++PROZESSE+++++++++++++
                            Dim CurrentProcedure As String = OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colProcName)
                            SplashScreenManager.Default.SetWaitFormCaption("Executing Import Procedure:" & vbNewLine & CurrentProcedure)
                            Select Case CurrentProcedure
                                Case = "EXCHANGE RATES NEWG"
                                    Me.OCBS_IMPORT_EXCHANGE_RATES_OCBS()
                                Case = "ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT"
                                    Me.OCBS_IMPORT_INTEREST_ON_ACCOUNT_DE_NEW()
                                Case = "ZINSERTRAEGE KUNDEN-TIME DEPOSITS"
                                    Me.OCBS_IMPORT_INTEREST_TIME_DEPOSIT_DE_FINRECON()
                                Case = "TIME DEPOSIT OUTSTANDING CLIENT DEALS"
                                    Me.OCBS_IMPORT_TIME_DEPOSIT_OUTSTANDING_CLIENT_DEALS()
                                Case = "IMPORT TRIAL BALANCE 218"
                                    Me.OCBS_IMPORT_TRIAL_BALANCE_218()
                                Case = "IMPORT CL DRAWDON OUTSTANDING"
                                    Me.OCBS_IMPORT_CL_DRAWDOWN_OUTSTANDING()
                                Case = "IMPORT NOSTRO BALANCES"
                                    Me.OCBS_IMPORT_NOSTRO_BALANCES()
                                Case = "IMPORT ALL VOLUMES"
                                    Me.OCBS_IMPORT_ALL_VOLUMES()
                                Case = "IMPORT CUSTOMER VOLUMES"
                                    Me.OCBS_IMPORT_CUSTOMER_VOLUMES()
                                Case = "GUARANTEE EXPOSURE REPORT"
                                    Me.OCBS_IMPORT_GUARANTEE_EXPOSURE()
                                Case = "IMPORT SUSPENCE BALANCES"
                                    Me.OCBS_IMPORT_SUSPENCE_BALANCES()
                                Case = "IMPORT TRIAL BALANCE 217"
                                    Me.OCBS_IMPORT_TRIAL_BALANCE_217()
                                Case = "FX DAILY REVALUATION"
                                    Me.OCBS_IMPORT_FOREIGN_EXCHANGE_DAILY_REVALUATION()
                                Case = "IMPORT TRIAL BALANCE 222"
                                    Me.OCBS_IMPORT_TRIAL_BALANCE_222()
                                Case = "IMPORT CUSTOMER BALANCES"
                                    Me.OCBS_IMPORT_CUSTOMER_BALANCES()
                                Case = "ACCOUNTS OPENED CLOSED"
                                    Me.OCBS_OPENED_CLOSED_ACCOUNTS()
                                Case = "CL COMMITMENTS"
                                    Me.OCBS_IMPORT_CL_COMMITMENTS()
                                Case = "GMPS INTERFACE IREMFM"
                                    Me.GMPS_IMPORT_IREMFM()
                                Case = "GMPS INTERFACE REMIFM"
                                    Me.GMPS_IMPORT_REMIFM()
                                Case = "GMPS INTERFACE CREMFM"
                                    Me.GMPS_IMPORT_CREMFM()
                            End Select


                            '++++++++++++++++++++++++++++++++++++++++++++++
                            'Erstellten Ordner wieder löschen
                            'Erstellten Ordner wieder löschen
                            Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                            SplashScreenManager.Default.SetWaitFormCaption("Delete Directory: " & "  " & OCBSFileNewDirectory)
                            Directory.Delete(OCBSFileNewDirectory, True)

                            Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & OcbsFileName & " " & "is finished ...")
                            SplashScreenManager.Default.SetWaitFormCaption("NGS File Import: " & " " & OcbsFileName & " " & "is finished ...")
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")
                            SplashScreenManager.Default.SetWaitFormCaption("NGS Import finished ...")
                            SplashScreenManager.CloseForm(False)
                        Else
                            MessageBox.Show("NGS File: " & SelectedOcbsImportFile.Text & " does not exists!", "NGS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            ENABLE_FINISH_IMPORT()
                        End If

                        If cmdOCBS.Connection.State = ConnectionState.Open Then
                            cmdOCBS.Connection.Close()
                        End If

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS File: " & " " & Me.SelectedOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                        ENABLE_FINISH_IMPORT()
                        Exit Sub

                    Finally
                        Me.BgwOCBSimport.CancelAsync()
                        'Directory Löschen
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
                Else
                    Return

                End If
                ENABLE_FINISH_IMPORT()
            Else
                MessageBox.Show("The selected Import procedure is not valid!" & vbNewLine & "Please change the Status of the Import procedure!", "IMPORT PROCEDURE NOT VALID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        Else
            MessageBox.Show("Please enter the related Filename in Field: NGS File for Import" & vbNewLine & "in order to start with the Import procedure!", "NGS File for Import is empty!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        '***********************************************************************************************

    End Sub

#End Region


    Private Sub OcbsImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwOCBSimport.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub OcbsImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        connEVENT.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdEVENT.Connection = connEVENT
        cmdEVENT.CommandTimeout = 60000

        connOCBS.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmdOCBS.Connection = connOCBS
        cmdOCBS.CommandTimeout = 60000

       

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************
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

        Me.IMPORT_EVENTSTableAdapter.FillByOCBSDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)
        Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)

    End Sub

    Private Sub OCBS_IMPORT_PROCEDURES()

        Me.OCBS_IMPORT_FOREIGN_EXCHANGE_DAILY_REVALUATION()
        Me.OCBS_IMPORT_EXCHANGE_RATES_OCBS()
        Me.OCBS_IMPORT_INTEREST_TIME_DEPOSIT_DE_FINRECON()
        Me.OCBS_IMPORT_TIME_DEPOSIT_OUTSTANDING_CLIENT_DEALS()
        Me.OCBS_IMPORT_TRIAL_BALANCE_218()
        Me.OCBS_IMPORT_TRIAL_BALANCE_217()
        Me.OCBS_IMPORT_TRIAL_BALANCE_222()
        Me.OCBS_IMPORT_CL_DRAWDOWN_OUTSTANDING()
        Me.OCBS_IMPORT_CL_COMMITMENTS()
        Me.OCBS_IMPORT_NOSTRO_BALANCES()
        Me.OCBS_OPENED_CLOSED_ACCOUNTS()
        Me.OCBS_IMPORT_CUSTOMER_BALANCES()
        Me.OCBS_IMPORT_ALL_VOLUMES()
        Me.OCBS_IMPORT_INTEREST_ON_ACCOUNT_DE_NEW()
        Me.OCBS_IMPORT_CUSTOMER_VOLUMES()
        Me.OCBS_IMPORT_SUSPENCE_BALANCES()
        Me.OCBS_IMPORT_CUSTOMER_VOSTRO_VOLUMES()
        'Me.OCBS_IMPORT_LETTER_OF_CREDITS()
        Me.OCBS_IMPORT_GUARANTEE_EXPOSURE()
        Me.GMPS_IMPORT_IREMFM()
        Me.GMPS_IMPORT_REMIFM()
        Me.GMPS_IMPORT_CREMFM()
        'Me.OCBS_CUSTOMER_RATINGS_CHECK()
        'Me.Test()




    End Sub



    Private Sub OCBS_IMPORT_FOREIGN_EXCHANGE_DAILY_REVALUATION()
        Try

            'Dim rd As Date
            'Dim rdsql As String
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "FX DAILY REVALUATION"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='FX DAILY REVALUATION' and [Valid]='Y'"
            cmd.Connection.Open()
            cmd.CommandTimeout = 50000

            If cmd.ExecuteScalar > 0 Then

                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure:FX DAILY REVALUATION")

                Dim ExcelFileName As String = ""
                'ExcelFileName = Me.ODAS_Temp_Directory & "\ts_d_1047-en.xlsx"
                ExcelFileName = Me.OCBS_Temp_Directory & "\TS_D_1047_710030000_" & rdsql & ".xlsx"

                If File.Exists(ExcelFileName) = True Then


                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import:TS_D_1047_710030000_" & rdsql & ".xlsx")

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
                    xlWorksheet1.Rows("1:3").delete()
                    xlWorksheet1.Columns("C:C").delete()


                    xlWorksheet1.Range("B1").Value = "Br"
                    xlWorksheet1.Range("C1").Value = "ContractNr"
                    xlWorksheet1.Range("D1").Value = "ContractType"
                    xlWorksheet1.Range("E1").Value = "ProductType"
                    xlWorksheet1.Range("F1").Value = "ClientNo"
                    xlWorksheet1.Range("G1").Value = "ClientName"
                    xlWorksheet1.Range("H1").Value = "ClientShortName"
                    xlWorksheet1.Range("I1").Value = "InputDate"
                    xlWorksheet1.Range("J1").Value = "ValueDate"
                    xlWorksheet1.Range("K1").Value = "MaturityDate"
                    xlWorksheet1.Range("L1").Value = "DealSellBuy"
                    xlWorksheet1.Range("M1").Value = "BuyCCY"
                    xlWorksheet1.Range("N1").Value = "SellCCY"
                    xlWorksheet1.Range("O1").Value = "BuyAmount"
                    xlWorksheet1.Range("P1").Value = "SellAmount"

                    xlWorksheet1.Range("Q1").Value = "Exchange Rate"
                    xlWorksheet1.Range("R1").Value = "RevalBuyRate"
                    xlWorksheet1.Range("S1").Value = "RevalBuyRate_1"
                    xlWorksheet1.Range("T1").Value = "RevalSellRate"
                    xlWorksheet1.Range("U1").Value = "RevalSellRate_1"
                    xlWorksheet1.Range("V1").Value = "RevalBuyAmount"
                    xlWorksheet1.Range("W1").Value = "RevalSellAmount"
                    xlWorksheet1.Range("X1").Value = "PL_EUR"
                    xlWorksheet1.Range("Y1").Value = "NPV"
                    xlWorksheet1.Range("Z1").Value = "DiscountRate"
                    xlWorksheet1.Range("AA1").Value = "DealStatus"
                    xlWorksheet1.Range("AB1").Value = "DealType"
                    xlWorksheet1.Range("AC1").Value = "NearRate"
                    xlWorksheet1.Range("AD1").Value = "FarRate"
                    xlWorksheet1.Range("AE1").Value = "RevalCCY"
                    xlWorksheet1.Range("AF1").Value = "PL_CCY"
                    xlWorksheet1.Range("AG1").Value = "PL_inEUR_Equ"
                    xlWorksheet1.Range("AH1").Value = "OBU_DBU"

                    xlWorksheet1.Columns("O:Z").numberformat = "#,##0.0000000000"
                    xlWorksheet1.Columns("AC:AD").numberformat = "#,##0.0000000000"
                    xlWorksheet1.Columns("AG:AG").numberformat = "#,##0.0000000000"

                    'Change Worksheet Name from Chinese to English
                    Me.BgwOCBSimport.ReportProgress(4, "Procedure:" & CURRENT_PROC & " - " & "Rename excel Sheet in: FxDailyReval")
                    xlWorksheet1.Name = "FxDailyReval"



                    Dim ExcelFileNameNew As String = ""
                    'ExcelFileNameNew = Me.ODAS_Temp_Directory & "\ts_d_1047-en.xls"
                    ExcelFileNameNew = OCBS_Temp_Directory & "\ts_d_1047-en.xls"
                    Me.BgwOCBSimport.ReportProgress(4, "Procedure:" & CURRENT_PROC & " - " & "Save excel Sheet as: " & ExcelFileNameNew)

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

                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_FX_DAILY_REVALUATION' AND xtype='U') CREATE TABLE [#Temp_IMPORT_FX_DAILY_REVALUATION]([ID] [int] IDENTITY(1,1) NOT NULL,[Branch] [nvarchar](50) NULL,[Br] [nvarchar](50) NULL,[ContractNr] [nvarchar](255) NULL,[ClientNo] [nvarchar](255) NULL,[ClientName] [nvarchar](255) NULL,[ClientShortName] [nvarchar](255) NULL,[ContractType] [nvarchar](255) NULL,[ProductType] [nvarchar](255) NULL,[InputDate] [datetime] NULL,[ValueDate] [datetime] NULL,[MaturityDate] [datetime] NULL,[DealSellBuy] [nvarchar](255) NULL,[BuyCCY] [nvarchar](255) NULL,[SellCCY] [nvarchar](255) NULL,[BuyAmount] [float] NULL,[SellAmount] [float] NULL,[Exchange Rate] [float] NULL,[RevalBuyRate] [float] NULL,[RevalBuyRate_1] [float] NULL,[RevalSellRate] [float] NULL,[RevalSellRate_1] [float] NULL,[RevalBuyAmount] [float] NULL,[RevalSellAmount] [float] NULL,[PL_EUR] [float] NULL,[PL_inEUR_Equ] [float] NULL,[NPV] [float] NULL,[DiscountRate] [float] NULL,[DealStatus] [nvarchar](255) NULL,[DealType] [nvarchar](255) NULL,[NearRate] [float] NULL,[FarRate] [float] NULL,[RevalCCY] [nvarchar](50) NULL,[PL_CCY] [nvarchar](50) NULL,[OBU_DBU] [nvarchar](50) NULL,[OwnDeal] [nvarchar](1) NULL,[RiskDate] [datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_FX_DAILY_REVALUATION]"
                    cmd.ExecuteNonQuery()
                    '******************************************************

                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_FX_DAILY_REVALUATION]([Branch],[Br],[ContractNr],[ClientNo],[ClientName],[ClientShortName],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[SellCCY],[BuyAmount],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalBuyRate_1],[RevalSellRate],[RevalSellRate_1],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[NearRate],[FarRate],[RevalCCY],[PL_CCY],[OBU_DBU],[RiskDate])  SELECT [Branch],[Br],[ContractNr],[ClientNo],[ClientName],[ClientShortName],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[SellCCY],[BuyAmount],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalBuyRate_1],[RevalSellRate],[RevalSellRate_1],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[NearRate],[FarRate],[RevalCCY],[PL_CCY],[OBU_DBU],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [FxDailyReval$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [FxDailyReval$]')"
                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_FX_DAILY_REVALUATION")

                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "FX DAILY REVALUATION imported in Temporary Table")

                    'Me.BgwODASimport.ReportProgress(6, "DELETE FROM IMPORT FX DAILY REVALUATION where Deal Type is not FW and SW")
                    'cmd.CommandText = "DELETE FROM [IMPORT FX DAILY REVALUATION] WHERE [DealType] not in ('FW', 'SW')"
                    'cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Delete all previus Data for the same Date")
                    'Daten mit dem aktuellen rd datum löschen
                    cmd.CommandText = "DELETE from [FX DAILY REVALUATION] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Insert into FX DAILY REVALUATION")
                    cmd.CommandText = "INSERT INTO [FX DAILY REVALUATION]([Branch],[Br],[ContractNr],[ClientNo],[ClientName],[ClientShortName],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[SellCCY],[BuyAmount],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalBuyRate_1],[RevalSellRate],[RevalSellRate_1],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[NearRate],[FarRate],[RevalCCY],[PL_CCY],[OBU_DBU],[RiskDate])Select [Branch],[Br],[ContractNr],[ClientNo],[ClientName],[ClientShortName],[ContractType],[ProductType],[InputDate],[ValueDate],[MaturityDate],[DealSellBuy],[BuyCCY],[SellCCY],[BuyAmount],[SellAmount],[Exchange Rate],[RevalBuyRate],[RevalBuyRate_1],[RevalSellRate],[RevalSellRate_1],[RevalBuyAmount],[RevalSellAmount],[PL_EUR],[PL_inEUR_Equ],[NPV],[DiscountRate],[DealStatus],[DealType],[NearRate],[FarRate],[RevalCCY],[PL_CCY],[OBU_DBU],[RiskDate] FROM [#Temp_IMPORT_FX_DAILY_REVALUATION]"
                    cmd.ExecuteNonQuery()

                    'löschen der IMPORT Tabelle
                    cmd.CommandText = "DROP TABLE [#Temp_IMPORT_FX_DAILY_REVALUATION]"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Match Client Nr and Client Name from Contract Nr in FX DAILY REVALUATION")
                    cmd.CommandText = "UPDATE A set A.[ClientNo]=B.[ClientNo] , A.[ClientName]=B.[English Name] FROM [FX DAILY REVALUATION] A INNER JOIN [CUSTOMER_INFO] B ON A.[ClientNo]=B.[OpicsCustomerNr] where LEN(A.[ClientNo])=10 and A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Update OwnDeal based on the data from previous Dates")
                    cmd.CommandText = "UPDATE A SET A.[OwnDeal] = 'Y' FROM [FX DAILY REVALUATION] A INNER JOIN (Select [ContractNr] from [FX DAILY REVALUATION] where [OwnDeal]='Y' and [RiskDate]<'" & rdsql & "') B ON A.[ContractNr] = B.ContractNr AND A.[DealStatus]='U' and A.[OwnDeal] = 'N' and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Update Modified_Final_Maturity_Date in FX DAILY REVALUATION Case when Monday then minus 3 Days otherwise Maturity Date Value")
                    cmd.CommandText = "UPDATE [FX DAILY REVALUATION] set [Modified_Final_Maturity_Date]=(Case when DATENAME(dw,[MaturityDate]) in ('Monday') then [MaturityDate]-3 else [MaturityDate] end) where  [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
                Me.BgwOCBSimport.ReportProgress(100, "Import procedure:FX DAILY REVALUATION finished sucesfully")

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If

            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import procedure: FX DAILY REVALUATION ist not Valid+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_EXCHANGE_RATES_OCBS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "EXCHANGE RATES NEWG"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='EXCHANGE RATES NEWG' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Start import: EXCHANGE RATES OCBS")

                Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read("\\ccb-nft\NFT_DATA\SMIS_REPORT_ALL_" & rdsql & "_710030000.zip")
                    Dim z As Ionic.Zip.ZipEntry
                    For Each z In zip
                        If z.FileName.EndsWith(".xls") = True OrElse z.FileName.EndsWith(".xlsx") = True Then
                            z.Extract(Me.OCBS_Temp_Directory, ExtractExistingFileAction.OverwriteSilently)
                        End If
                    Next
                End Using

                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-218_" & rdsql & "_710030000_tbl.xls"

                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Import File: ...\AI-D-218_" & rdsql & "_710030000_tbl.xls-Sheet:Rate-2")

                If File.Exists(ExcelFileName) = True Then

                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets("Rate-2")
                    EXCELL.Visible = False
                   
                    
                    'Rows delete
                    xlWorksheet1.Rows("1:7").delete()
                    xlWorksheet1.Range("A1").Value = "CURRENCY CODE"
                    xlWorksheet1.Range("C1").Value = "MIDDLE RATE"
                    xlWorksheet1.Columns("B:B").delete()


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
                    Me.BgwOCBSimport.ReportProgress(30, "Procedure:" & CURRENT_PROC & " - " & "Delete Exchange Rates with the same Exchange Rate Date")
                    cmd.CommandText = "DELETE from [EXCHANGE RATES OCBS] where [EXCHANGE RATE DATE]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    'Create EXCHANGE RATES IMPORT
                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Create Exchange Rate import Table:#Temp_IMPORT_EXCHANGE_RATES_OCBS")
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_EXCHANGE_RATES_OCBS' AND xtype='U') CREATE TABLE [#Temp_IMPORT_EXCHANGE_RATES_OCBS]([CURRENCY CODE] [nvarchar](255) NULL,[CURRENCY NAME][nvarchar](255) NULL,[ID] [int] IDENTITY(1,1) NOT NULL,[MIDDLE RATE] [float] NULL) ELSE DELETE FROM [#Temp_IMPORT_EXCHANGE_RATES_OCBS] "
                    cmd.ExecuteNonQuery()
                    'Importieren in dem SQL SERVER
                    Me.BgwOCBSimport.ReportProgress(50, "Procedure:" & CURRENT_PROC & " - " & "Import Exchange rates to the Temporary Import Table:#Temp_IMPORT_EXCHANGE_RATES_OCBS")
                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_EXCHANGE_RATES_OCBS] ([CURRENCY CODE],[MIDDLE RATE]) SELECT [CURRENCY CODE],ROUND(1/[MIDDLE RATE],5) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Rate-2$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Rate-2$]')"
                    Me.BgwOCBSimport.ReportProgress(59, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_EXCHANGE_RATES_OCBS")

                    'Nicht relevante Währungen in Import Tabelle löschen
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Delete Exchange Rate if Currency is not OWN_CURRENCY")
                    cmd.CommandText = "DELETE FROM [#Temp_IMPORT_EXCHANGE_RATES_OCBS] WHERE [#Temp_IMPORT_EXCHANGE_RATES_OCBS].[CURRENCY CODE] NOT IN (Select [OWN_CURRENCIES].[CURRENCY CODE] from [OWN_CURRENCIES])"
                    cmd.ExecuteNonQuery()
                    'Currency Name importieren
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Update Currency Name in the Temporary Import Table ")
                    cmd.CommandText = "UPDATE A SET A.[CURRENCY NAME]=B.[CURRENCY NAME] from [#Temp_IMPORT_EXCHANGE_RATES_OCBS] A INNER JOIN [OWN_CURRENCIES] B ON A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                    cmd.ExecuteNonQuery()
                    'Neuanlage EXCHANGE RATES OCBS
                    Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange Rates to the Table:EXCHANGE RATES OCBS from the Temporary Import Table ")
                    cmd.CommandText = "INSERT INTO [EXCHANGE RATES OCBS] ([CURRENCY CODE],[CURRENCY NAME],[MIDDLE RATE],[EXCHANGE RATE DATE]) select [CURRENCY CODE],[CURRENCY NAME],[MIDDLE RATE],'" & rdsql & "' from [#Temp_IMPORT_EXCHANGE_RATES_OCBS] where [CURRENCY CODE] not in ('EUR') and [CURRENCY NAME] is not NULL"
                    cmd.ExecuteNonQuery()
                    'SPREAD ERMITTELN
                    Me.BgwOCBSimport.ReportProgress(85, "Procedure:" & CURRENT_PROC & " - " & "Determine the Spread for each Currency")
                    cmd.CommandText = "UPDATE A SET A.[SPREAD]=B.[SPREAD] from [EXCHANGE RATES OCBS] A INNER JOIN  [OWN_CURRENCIES] B ON A.[CURRENCY CODE]=B.[CURRENCY CODE] where A.[SPREAD] is NULL and A.[EXCHANGE RATE DATE]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'OFFERED RATE + MONEY RATE ERMITTELN
                    Me.BgwOCBSimport.ReportProgress(90, "Procedure:" & CURRENT_PROC & " - " & "Determine the Offered and Money Rate for each Currency")
                    cmd.CommandText = "UPDATE [EXCHANGE RATES OCBS]  SET [OFFERED RATE]=[MIDDLE RATE]+[SPREAD] , [MONEY RATE]=[MIDDLE RATE]-[SPREAD] where [EXCHANGE RATE DATE]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Löschen EXCHANGE RATES IMPORT
                    Me.BgwOCBSimport.ReportProgress(95, "Procedure:" & CURRENT_PROC & " - " & "Drop the Temporary Import Table")
                    cmd.CommandText = "DROP TABLE [#Temp_IMPORT_EXCHANGE_RATES_OCBS]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "NEWG Exchange Rates imported sucesfully")
                    '*************************************************************************


                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: EXCHANGE RATES NEWG ist not Valid+++")
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
                Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import Excel File: ...\AI-D-249 - General Ledger Journal List-en.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Check If data are available!Range D2 must start with General Ledger Journal List ...")
                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                        Me.BgwOCBSimport.ReportProgress(4, "Procedure:" & CURRENT_PROC & " - " & "Start reformation of the Excel File...Please wait...")
                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:6").delete()
                        xlWorksheet1.Range("E1").Value = "GL_ACC_NR"
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

                       
                        xlWorksheet1.Columns("A:D").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("C:C").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("F:F").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("I:I").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                        xlWorksheet1.Columns("J:T").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                      
                        xlWorksheet1.Columns("B:B").numberformat = "yyyymmdd"

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



                        Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Start Import to the Temporary Table: #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP' AND xtype='U') CREATE TABLE [dbo].[#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]([ID] [int] IDENTITY(1,1) NOT NULL,[GL_ACC_NR] float NULL,[ValDateFrom] [datetime] NULL,[ValDate] [datetime] NULL,[Customer] [nvarchar](255) NULL,[ValYear] [float] NULL,[CustomerName] [nvarchar](255) NULL,[Account] [nvarchar](255) NULL,[RegistrationCountry] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[CCY] [nvarchar](255) NULL,[Product] [nvarchar](255) NULL,[Amount] [float] NULL,[ExchangeRate] [float] NULL,[AmountEuro] [float] NULL,[DB] [nvarchar](255) NULL,[KapertstG] [float] NULL,[Remark] [nvarchar](255) NULL,[Soli] [float] NULL,[KAPISTPFLICHTIG] [nvarchar](255) NULL,[BUNDESLAND] [nvarchar](255) NULL,[IdValueCustomer] [nvarchar](255) NULL,[IdZinsertragsMonat] [nvarchar](255) NULL,[IdErtragJahr] [float] NULL) ELSE DELETE FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] "
                        cmd.ExecuteNonQuery()
                        'In temporäre Tabelle einfügen
                        cmd.CommandText = "INSERT INTO [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] ([GL_ACC_NR],[ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]')"
                        cmd.ExecuteNonQuery()
                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        cmd.CommandText = "DELETE FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Customer] is NULL"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Check if GL/AC No=23009212 and Amount<0 and delete the relevant rows...")
                        cmd.CommandText = "DELETE FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [GL_ACC_NR]='23009212' and [Amount]<0"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Determine Interest Payment Year and Month...after seting Language in German")
                        cmd.CommandText = "SET LANGUAGE German"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] SET [ValYear]=DATEPART(Year,[ValDate]),[IdErtragJahr]=DATEPART(Year,[ValDate]),[IdValueCustomer]=CONVERT(VARCHAR(10), [ValDate], 104)+[Account],[IdZinsertragsMonat]=DATENAME(MONTH, [ValDate])+ ' ' + LTRIM(RTRIM(STR(DATEPART(Year,[ValDate]),4,0)))"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "SET LANGUAGE English"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Check if Customer Nr is in Table:ZINSERTRAG KDBASIC and insert if not...")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KDBASIC]([KDSTAMM],[IdBank]) SELECT distinct [Customer],'3' FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] Where [Customer] not in (Select [KDSTAMM] from [ZINSERTRAG KDBASIC])"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Check if ZINSERTRAGSJAHR in Table ZINSERTRAG KUNDEN JAHR")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN JAHR]([ErtragsJahr],[IdBank]) SELECT DISTINCT DATEPART(Year,[ValDate]),'3' from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where DATEPART(Year,[ValDate]) not in  (Select [ErtragsJahr] from  [ZINSERTRAG KUNDEN JAHR])"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Check if ZINSERTRAGSMONAT in Table ZINSERTRAG KUNDEN MONAT ")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN MONAT]([Zinsertragsmonat],[IdZinsertragJahr],[ZinsertragsmonatDATE]) SELECT DISTINCT [IdZinsertragsMonat],[IdErtragJahr],DATEADD(month, DATEDIFF(month, 0, [ValDate]), 0) from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [IdZinsertragsMonat] not in (Select [Zinsertragsmonat] from [ZINSERTRAG KUNDEN MONAT])"
                        cmd.ExecuteNonQuery()



                        Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Define ERTRAGSJAHR and ERTRAGSMONAT")
                        Dim ERTRAGSJAHR As Double = 0 'Column J:ValYear
                        Dim ERTRAGSMONAT As String = Nothing 'Column Q:IdZinsertragsMonat
                        cmd.CommandText = "SELECT DISTINCT [IdErtragJahr] from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                        ERTRAGSJAHR = cmd.ExecuteScalar
                        cmd.CommandText = "SELECT DISTINCT [IdZinsertragsMonat] from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                        ERTRAGSMONAT = cmd.ExecuteScalar

                        Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Start Sub Process for the anual Payments Statistic (ZVSTA) insert Data in Table: KUNDEN INTEREST ON AC")
                        '*******************************************************************************************************************************************
                        '*****SUB PROZEDUR - Einfügen der Zinserträge in der Tabelle KUNDEN INTEREST ON AC- für die ZAHLUNGSVERKEHRSSTATISTIK***********************
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                        'FÜR ZAHLUNGSVERKEHRSSTATISTIK
                        'In KUNDEN INTEREST ON ACCOUNT einfügen
                        cmd.CommandText = "INSERT INTO [KUNDEN INTEREST ON AC] ([ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT [ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat] from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN wenn kein INTEREST ON AC
                        Me.BgwOCBSimport.ReportProgress(14, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: KUNDEN INTEREST ON AC where Remark not like INTEREST ON A/C% ")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                        cmd.ExecuteNonQuery()
                        'CUSTOMER NAME-REGISTRATION COUNTRY EINFÜGEN
                        Me.BgwOCBSimport.ReportProgress(15, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Registration country in Table: KUNDEN INTEREST ON AC from Table CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [KUNDEN INTEREST ON AC] A  INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo]"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                        Me.BgwOCBSimport.ReportProgress(16, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table:KUNDEN INTEREST ON AC if Customer Name is NULL")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [CustomerName] IS NULL"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER NEGATIVEN WERTE
                        Me.BgwOCBSimport.ReportProgress(17, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table:KUNDEN INTEREST ON AC if Field (DB)=D")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [DB] IN ('D')"
                        cmd.ExecuteNonQuery()
                        'Exchange Rate
                        Me.BgwOCBSimport.ReportProgress(18, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in Table: KUNDEN INTEREST ON AC")
                        cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                        cmd.ExecuteNonQuery()
                        'cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [KUNDEN INTEREST ON AC].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [KUNDEN INTEREST ON AC].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [KUNDEN INTEREST ON AC] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(19, "Procedure:" & CURRENT_PROC & " - " & "Calculate all Amounts in EURO")
                        cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from KUNDEN INTEREST ON AC - Field: IdValueCustomer")
                        cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [ID] not in (Select Min([ID]) from [KUNDEN INTEREST ON AC] group by [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(21, "Procedure:" & CURRENT_PROC & " - " & "End Sub Process for the anual Payments Statistic (ZVSTA)")
                        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        '***************************************************************************************************************
                        '*************ZINSERTRÄGE EINFÜGEN******************************************************************************
                        '*******Überprüfen ob Kunde Kapitalertragssteuerpflichtig ist und berechnungen durchführen**********************
                        '***************************************************************************************************************
                        'LÖSCHEN wenn kein INTEREST ON AC
                        Me.BgwOCBSimport.ReportProgress(22, "Procedure:" & CURRENT_PROC & " - " & "Start Insert Data to the Table: ZINSERTRAG KUNDEN DETAILS")
                        Me.BgwOCBSimport.ReportProgress(23, "Procedure:" & CURRENT_PROC & " - " & "Delete from  #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP where Remark not like INTEREST ON A/C")
                        cmd.CommandText = "DELETE  FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN wenn kein KUNDENSTAMM vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(24, "Procedure:" & CURRENT_PROC & " - " & "Delete from  #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP where Customer like NULL")
                        cmd.CommandText = "DELETE  FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Customer] is NULL"
                        cmd.ExecuteNonQuery()
                        'In live Tabelle einfügen
                        Me.BgwOCBSimport.ReportProgress(25, "Procedure:" & CURRENT_PROC & " - " & "Insert Data to Table: ZINSERTRAG KUNDEN DETAILS ")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS] ([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr]) SELECT [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr] FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                        cmd.ExecuteNonQuery()
                        'Temptabelle löschen
                        cmd.CommandText = "DROP TABLE [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
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
                        Me.BgwOCBSimport.ReportProgress(26, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Name and Registration country in Table: ZINSERTRAG KUNDEN DETAILS from Table CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo] where B.[ClientType] NOT IN ('F - FINANCIAL')"
                        cmd.ExecuteNonQuery()
                        'ÜBERPRPFEBN VON Tabelle ZINSERTRAG KDBASIC ob Kunde Kapitalertragssteuerpflichtig ist
                        Me.BgwOCBSimport.ReportProgress(26, "Procedure:" & CURRENT_PROC & " - " & "Update Field: KAPISTPFLICHTIG in Table: ZINSERTRAG KUNDEN DETAILS from Table ZINSERTRAG KDBASIC")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]=B.[KDSTAMM]"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                        Me.BgwOCBSimport.ReportProgress(27, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS where Customer Name is NULL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [CustomerName] IS NULL"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN ALLER FINACIAL INSTITUTIONS
                        Me.BgwOCBSimport.ReportProgress(28, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Customer Type= F-FINACIAL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [Customer] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType]='F - FINANCIAL')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER GEBIETS AUSLÄNDER
                        Me.BgwOCBSimport.ReportProgress(29, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Registration Country not DE")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [RegistrationCountry] NOT IN ('DE')"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN DER NEGATIVEN WERTE
                        Me.BgwOCBSimport.ReportProgress(30, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table:ZINSERTRAG KUNDEN DETAILS if Field (DB)=D")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [DB] IN ('D')"
                        cmd.ExecuteNonQuery()
                        'Exchange Rate für EUR übergeben
                        Me.BgwOCBSimport.ReportProgress(31, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in Table: ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                        cmd.ExecuteNonQuery()
                        'Exchange Rates importieren
                        'cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [ZINSERTRAG KUNDEN DETAILS].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [ZINSERTRAG KUNDEN DETAILS].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                        'cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(32, "Procedure:" & CURRENT_PROC & " - " & "Calculate all Amounts in EURO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(33, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from ZINSERTRAG KUNDEN DETAILS - Field: IdValueCustomer")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KUNDEN DETAILS] group by [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragsteuer berechnen
                        Me.BgwOCBSimport.ReportProgress(34, "Procedure:" & CURRENT_PROC & " - " & "Calculate Kapitalertragssteuer in  ZINSERTRAG KUNDEN DETAILS - Parameter:MELDEWESEN/KAPITALERTRAGSTEUER_SATZ")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=FLOOR([AmountEuro]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='KAPITALERTRAGSTEUER_SATZ')) where [KapertstG]=0"
                        cmd.ExecuteNonQuery()
                        'Kapitalertragssteuer auf null wenn KapitaSteuerbetrag<1
                        Me.BgwOCBSimport.ReportProgress(35, "Procedure:" & CURRENT_PROC & " - " & "Set Kapitalertragssteuer to 0 if Calculated Kapitalertragssteuer <1 in  ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= 0 where [KapertstG] < 1"
                        cmd.ExecuteNonQuery()
                        'Soli berechnen
                        Me.BgwOCBSimport.ReportProgress(36, "Procedure:" & CURRENT_PROC & " - " & "Calculate Solidaritätsbeitrag in  ZINSERTRAG KUNDEN DETAILS - - Parameter:MELDEWESEN/SOLI_SATZ")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]= [KapertstG]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='SOLI_SATZ') where [Soli]=0"
                        cmd.ExecuteNonQuery()
                        'BUNDESLAND für Gesamt Kunden und Details einfügen
                        Me.BgwOCBSimport.ReportProgress(37, "Procedure:" & CURRENT_PROC & " - " & "Determine BUNDESLAND in  ZINSERTRAG KDBASIC,ZINSERTRAG KUNDEN DETAILS and ZINSERTRAG KDDETAIL ")
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
                        Me.BgwOCBSimport.ReportProgress(37, "Procedure:" & CURRENT_PROC & " - " & "Set Solidaritätsbeitrag + Kapitalertragsteuer to 0 if KAPITALSTEUERPFLICHTIG is N")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDDETAIL] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()

                        'SUMMEN BERECHEN ERTRAGSMONAT
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(38, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN MONAT")
                        cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN MONAT] A INNER JOIN (Select Sum([KapertstG]) as K,Sum([Soli]) as S,[IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y' GROUP BY [IdZinsertragsMonat])B on A.Zinsertragsmonat=B.IdZinsertragsMonat"
                        cmd.ExecuteNonQuery()

                        'SUMMEN BERECHEN ERTRAGSJAHR
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(39, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN JAHR")
                        cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN JAHR] A INNER JOIN (Select Sum([SummeKapErSt]) as K,Sum(SummeSoli) as S,[IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "' GROUP BY [IdZinsertragJahr])B on A.[ErtragsJahr]=B.[IdZinsertragJahr]"
                        cmd.ExecuteNonQuery()


                        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        'Füllen der Tabelle ZINSERTRAG KDDETAIL
                        Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Fill Table: ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KDDETAIL]([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[IdKDSTAMM])Select [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[Customer] FROM [ZINSERTRAG KUNDEN DETAILS]"
                        cmd.ExecuteNonQuery()
                        'Duplikate Löschen 
                        Me.BgwOCBSimport.ReportProgress(41, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates in Table: ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDDETAIL] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KDDETAIL] GROUP BY [IdValueCustomer])"
                        cmd.ExecuteNonQuery()
                        'Update Zinsertrag, Kapi-Soli basierend auf [ZINSERTRAG KUNDEN DETAILS]
                        Me.BgwOCBSimport.ReportProgress(41, "Procedure:" & CURRENT_PROC & " - " & "Update Data in ZINSERTRAG KDDETAIL based on [IdValueCustomer] from [ZINSERTRAG KUNDEN DETAILS]")
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[ExchangeRate],A.[AmountEuro]=B.[AmountEuro],A.[KapertstG]=B.[KapertstG],A.[Soli]=B.[Soli],A.[KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG]  FROM [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[IdValueCustomer]=B.[IdValueCustomer]"
                        cmd.ExecuteNonQuery()
                        'Löschen in Tabelle ZINSERTRAG KDBASIC wenn keine Daten für IDSTAMM gibt
                        Me.BgwOCBSimport.ReportProgress(42, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KDBASIC where KDSTAMM not in Table ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDBASIC] where [KDSTAMM] NOT IN (Select [IdKDSTAMM] from [ZINSERTRAG KDDETAIL])"
                        cmd.ExecuteNonQuery()
                        'Namen der Kunden in der Tabelle ZINSERTRAG KDBASIC einfügen
                        Me.BgwOCBSimport.ReportProgress(43, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Name in Table: ZINSERTRAG KDBASIC from CUSTOMER_INFO")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KDNAME1]=B.[English Name] from [ZINSERTRAG KDBASIC] A INNER JOIN [CUSTOMER_INFO] B ON A.[KDSTAMM]=B.[ClientNo]"
                        cmd.ExecuteNonQuery()


                        '?????????????????NEUANLAUF KAPISTPFLICHTIG???????????????????
                        Me.BgwOCBSimport.ReportProgress(44, "Procedure:" & CURRENT_PROC & " - " & "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KDDETAIL")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KDDETAIL] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(45, "Procedure:" & CURRENT_PROC & " - " & "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                        cmd.ExecuteNonQuery()


                        'SUMMEN BERECHEN ERTRAGSMONAT
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(46, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer in Table: ZINSERTRAG KUNDEN DETAILS")
                        cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN MONAT] A INNER JOIN (Select Sum([KapertstG]) as K,Sum([Soli]) as S,[IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y' GROUP BY [IdZinsertragsMonat])B on A.Zinsertragsmonat=B.IdZinsertragsMonat"
                        cmd.ExecuteNonQuery()

                        'SUMMEN BERECHEN ERTRAGSJAHR
                        'Kapitalertragssteuer
                        Me.BgwOCBSimport.ReportProgress(48, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer in Table: ZINSERTRAG KUNDEN JAHR")
                        cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN JAHR] A INNER JOIN (Select Sum([SummeKapErSt]) as K,Sum(SummeSoli) as S,[IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "' GROUP BY [IdZinsertragJahr])B on A.[ErtragsJahr]=B.[IdZinsertragJahr]"
                        cmd.ExecuteNonQuery()
                        Me.BgwOCBSimport.ReportProgress(50, "Procedure:" & CURRENT_PROC & " - " & "Import Procedure:ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT finished sucesfully")
                    Else
                        MsgBox("ERROR+++Invalid Format!", MsgBoxStyle.Exclamation, "IMPORT ABORTED")

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

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

    Private Sub OCBS_IMPORT_INTEREST_ON_ACCOUNT_DE_NEW()
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
                Me.BgwOCBSimport.ReportProgress(1, "Start: ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT")
                cmd.CommandText = "SELECT COUNT([ID]) from [CUSTOMER_ACC_BALANCES] where [BalanceDate]='" & rdsql & "'" 'Check if Data Present
                Dim Result As Double = cmd.ExecuteScalar

                If Result > 0 Then

                    Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Start Import to the Temporary Table: #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP")
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP' AND xtype='U') CREATE TABLE [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]([ID] [int] IDENTITY(1,1) NOT NULL,[GL_ACC_NR] float NULL,[ValDateFrom] [datetime] NULL,[ValDate] [datetime] NULL,[Customer] [nvarchar](255) NULL,[ValYear] [float] NULL,[CustomerName] [nvarchar](255) NULL,[Account] [nvarchar](255) NULL,[RegistrationCountry] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[CCY] [nvarchar](255) NULL,[Product] [nvarchar](255) NULL,[Amount] [float] NULL,[ExchangeRate] [float] NULL,[AmountEuro] [float] NULL,[DB] [nvarchar](255) NULL,[KapertstG] [float] NULL,[Remark] [nvarchar](255) NULL,[Soli] [float] NULL,[KAPISTPFLICHTIG] [nvarchar](255) NULL,[BUNDESLAND] [nvarchar](255) NULL,[IdValueCustomer] [nvarchar](255) NULL,[IdZinsertragsMonat] [nvarchar](255) NULL,[IdErtragJahr] [float] NULL) ELSE DELETE FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] "
                    cmd.ExecuteNonQuery()
                    'In temporäre Tabelle einfügen
                    cmd.CommandText = "INSERT INTO [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] ([GL_ACC_NR],[ValDate],[Account],[CCY],[Amount],[Customer],[Remark],[CustomerName]) SELECT NULL, BalanceDate,[AccountNo],Currency,[CR_Interest],[ClientNo],'INTEREST ON A/C',ClientName FROM CUSTOMER_ACC_BALANCES where BalanceDate='" & rdsql & "' and  [CR_Interest]>0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Determine Interest Payment Year and Month...after seting Language in German")
                    cmd.CommandText = "SET LANGUAGE German"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] SET [ValYear]=DATEPART(Year,[ValDate]),[IdErtragJahr]=DATEPART(Year,[ValDate]),[IdValueCustomer]=CONVERT(VARCHAR(10), [ValDate], 104)+[Account],[IdZinsertragsMonat]=DATENAME(MONTH, [ValDate])+ ' ' + LTRIM(RTRIM(STR(DATEPART(Year,[ValDate]),4,0)))"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SET LANGUAGE English"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Check if Customer Nr is in Table:ZINSERTRAG KDBASIC and insert if not...")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KDBASIC]([KDSTAMM],[IdBank]) SELECT distinct [Customer],'3' FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] Where [Customer] not in (Select [KDSTAMM] from [ZINSERTRAG KDBASIC])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Check if ZINSERTRAGSJAHR in Table ZINSERTRAG KUNDEN JAHR")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN JAHR]([ErtragsJahr],[IdBank]) SELECT DATEPART(Year,[ValDate]),'3' from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where DATEPART(Year,[ValDate]) not in  (Select [ErtragsJahr] from  [ZINSERTRAG KUNDEN JAHR])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Check if ZINSERTRAGSMONAT in Table ZINSERTRAG KUNDEN MONAT ")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN MONAT]([Zinsertragsmonat],[IdZinsertragJahr],[ZinsertragsmonatDATE]) SELECT DISTINCT [IdZinsertragsMonat],[IdErtragJahr],DATEADD(month, DATEDIFF(month, 0, [ValDate]), 0) from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [IdZinsertragsMonat] not in (Select [Zinsertragsmonat] from [ZINSERTRAG KUNDEN MONAT])"
                    cmd.ExecuteNonQuery()



                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Define ERTRAGSJAHR and ERTRAGSMONAT")
                    Dim ERTRAGSJAHR As Double = 0 'Column J:ValYear
                    Dim ERTRAGSMONAT As String = Nothing 'Column Q:IdZinsertragsMonat
                    cmd.CommandText = "SELECT DISTINCT [IdErtragJahr] from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                    ERTRAGSJAHR = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT DISTINCT [IdZinsertragsMonat] from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                    ERTRAGSMONAT = cmd.ExecuteScalar

                    Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Start Sub Process for the anual Payments Statistic (ZVSTA) insert Data in Table: KUNDEN INTEREST ON AC")
                    '*******************************************************************************************************************************************
                    '*****SUB PROZEDUR - Einfügen der Zinserträge in der Tabelle KUNDEN INTEREST ON AC- für die ZAHLUNGSVERKEHRSSTATISTIK***********************
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'FÜR ZAHLUNGSVERKEHRSSTATISTIK
                    'In KUNDEN INTEREST ON ACCOUNT einfügen
                    cmd.CommandText = "INSERT INTO [KUNDEN INTEREST ON AC] ([ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT [ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat] from [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN wenn kein INTEREST ON AC
                    Me.BgwOCBSimport.ReportProgress(14, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: KUNDEN INTEREST ON AC where Remark not like INTEREST ON A/C% ")
                    cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                    cmd.ExecuteNonQuery()
                    'CUSTOMER NAME-REGISTRATION COUNTRY EINFÜGEN
                    Me.BgwOCBSimport.ReportProgress(15, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Registration country in Table: KUNDEN INTEREST ON AC from Table CUSTOMER_INFO")
                    cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [KUNDEN INTEREST ON AC] A  INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo]"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                    Me.BgwOCBSimport.ReportProgress(16, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table:KUNDEN INTEREST ON AC if Customer Name is NULL")
                    cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [CustomerName] IS NULL"
                    cmd.ExecuteNonQuery()
                    'Exchange Rate
                    Me.BgwOCBSimport.ReportProgress(18, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in Table: KUNDEN INTEREST ON AC")
                    cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                    cmd.ExecuteNonQuery()
                    'cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [KUNDEN INTEREST ON AC].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [KUNDEN INTEREST ON AC].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [KUNDEN INTEREST ON AC] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                    cmd.ExecuteNonQuery()
                    'UMRECHNUNG
                    Me.BgwOCBSimport.ReportProgress(19, "Procedure:" & CURRENT_PROC & " - " & "Calculate all Amounts in EURO")
                    cmd.CommandText = "UPDATE [KUNDEN INTEREST ON AC] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                    cmd.ExecuteNonQuery()
                    'Duplikate Löschen 
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from KUNDEN INTEREST ON AC - Field: IdValueCustomer")
                    cmd.CommandText = "DELETE  FROM [KUNDEN INTEREST ON AC] where [ID] not in (Select Min([ID]) from [KUNDEN INTEREST ON AC] group by [IdValueCustomer])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(21, "Procedure:" & CURRENT_PROC & " - " & "End Sub Process for the anual Payments Statistic (ZVSTA)")
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '***************************************************************************************************************
                    '*************ZINSERTRÄGE EINFÜGEN******************************************************************************
                    '*******Überprüfen ob Kunde Kapitalertragssteuerpflichtig ist und berechnungen durchführen**********************
                    '***************************************************************************************************************
                    'LÖSCHEN wenn kein INTEREST ON AC
                    Me.BgwOCBSimport.ReportProgress(22, "Procedure:" & CURRENT_PROC & " - " & "Start Insert Data to the Table: ZINSERTRAG KUNDEN DETAILS")
                    Me.BgwOCBSimport.ReportProgress(23, "Procedure:" & CURRENT_PROC & " - " & "Delete from  #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP where Remark not like INTEREST ON A/C")
                    cmd.CommandText = "DELETE  FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN wenn kein KUNDENSTAMM vorhanden ist
                    Me.BgwOCBSimport.ReportProgress(24, "Procedure:" & CURRENT_PROC & " - " & "Delete from  #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP where Customer like NULL")
                    cmd.CommandText = "DELETE  FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Customer] is NULL"
                    cmd.ExecuteNonQuery()
                    'In live Tabelle einfügen
                    Me.BgwOCBSimport.ReportProgress(25, "Procedure:" & CURRENT_PROC & " - " & "Insert Data to Table: ZINSERTRAG KUNDEN DETAILS ")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS] ([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr]) SELECT [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr] FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                    cmd.ExecuteNonQuery()
                    'Temptabelle löschen
                    cmd.CommandText = "DROP TABLE [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
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
                    Me.BgwOCBSimport.ReportProgress(26, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Name and Registration country in Table: ZINSERTRAG KUNDEN DETAILS from Table CUSTOMER_INFO")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo] where B.[ClientType] NOT IN ('F - FINANCIAL')"
                    cmd.ExecuteNonQuery()
                    'ÜBERPRPFEBN VON Tabelle ZINSERTRAG KDBASIC ob Kunde Kapitalertragssteuerpflichtig ist
                    Me.BgwOCBSimport.ReportProgress(26, "Procedure:" & CURRENT_PROC & " - " & "Update Field: KAPISTPFLICHTIG in Table: ZINSERTRAG KUNDEN DETAILS from Table ZINSERTRAG KDBASIC")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]=B.[KDSTAMM]"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                    Me.BgwOCBSimport.ReportProgress(27, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS where Customer Name is NULL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [CustomerName] IS NULL"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN ALLER FINACIAL INSTITUTIONS
                    Me.BgwOCBSimport.ReportProgress(28, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Customer Type= F-FINACIAL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [Customer] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType]='F - FINANCIAL')"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN DER GEBIETS AUSLÄNDER
                    Me.BgwOCBSimport.ReportProgress(29, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Registration Country not DE")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [RegistrationCountry] NOT IN ('DE')"
                    cmd.ExecuteNonQuery()
                    'Exchange Rate für EUR übergeben
                    Me.BgwOCBSimport.ReportProgress(31, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in Table: ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                    cmd.ExecuteNonQuery()
                    'Exchange Rates importieren
                    'cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [ZINSERTRAG KUNDEN DETAILS].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [ZINSERTRAG KUNDEN DETAILS].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                    cmd.ExecuteNonQuery()
                    'UMRECHNUNG
                    Me.BgwOCBSimport.ReportProgress(32, "Procedure:" & CURRENT_PROC & " - " & "Calculate all Amounts in EURO")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                    cmd.ExecuteNonQuery()
                    'Duplikate Löschen 
                    Me.BgwOCBSimport.ReportProgress(33, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from ZINSERTRAG KUNDEN DETAILS - Field: IdValueCustomer")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KUNDEN DETAILS] group by [IdValueCustomer])"
                    cmd.ExecuteNonQuery()
                    'Kapitalertragsteuer berechnen
                    Me.BgwOCBSimport.ReportProgress(34, "Procedure:" & CURRENT_PROC & " - " & "Calculate Kapitalertragssteuer in  ZINSERTRAG KUNDEN DETAILS - Parameter:MELDEWESEN/KAPITALERTRAGSTEUER_SATZ")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=FLOOR([AmountEuro]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='KAPITALERTRAGSTEUER_SATZ')) where [KapertstG]=0"
                    cmd.ExecuteNonQuery()
                    'Kapitalertragssteuer auf null wenn KapitaSteuerbetrag<1
                    Me.BgwOCBSimport.ReportProgress(35, "Procedure:" & CURRENT_PROC & " - " & "Set Kapitalertragssteuer to 0 if Calculated Kapitalertragssteuer <1 in  ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= 0 where [KapertstG] < 1"
                    cmd.ExecuteNonQuery()
                    'Soli berechnen
                    Me.BgwOCBSimport.ReportProgress(36, "Procedure:" & CURRENT_PROC & " - " & "Calculate Solidaritätsbeitrag in  ZINSERTRAG KUNDEN DETAILS - - Parameter:MELDEWESEN/SOLI_SATZ")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]= [KapertstG]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='SOLI_SATZ') where [Soli]=0"
                    cmd.ExecuteNonQuery()
                    'BUNDESLAND für Gesamt Kunden und Details einfügen
                    Me.BgwOCBSimport.ReportProgress(37, "Procedure:" & CURRENT_PROC & " - " & "Determine BUNDESLAND in  ZINSERTRAG KDBASIC,ZINSERTRAG KUNDEN DETAILS and ZINSERTRAG KDDETAIL ")
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
                    Me.BgwOCBSimport.ReportProgress(37, "Procedure:" & CURRENT_PROC & " - " & "Set Solidaritätsbeitrag + Kapitalertragsteuer to 0 if KAPITALSTEUERPFLICHTIG is N")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDDETAIL] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()

                    'SUMMEN BERECHEN ERTRAGSMONAT
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(38, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN MONAT")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN MONAT] A INNER JOIN (Select Sum([KapertstG]) as K,Sum([Soli]) as S,[IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y' GROUP BY [IdZinsertragsMonat])B on A.Zinsertragsmonat=B.IdZinsertragsMonat"
                    cmd.ExecuteNonQuery()

                    'SUMMEN BERECHEN ERTRAGSJAHR
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(39, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN JAHR")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN JAHR] A INNER JOIN (Select Sum([SummeKapErSt]) as K,Sum(SummeSoli) as S,[IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "' GROUP BY [IdZinsertragJahr])B on A.[ErtragsJahr]=B.[IdZinsertragJahr]"
                    cmd.ExecuteNonQuery()


                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    'Füllen der Tabelle ZINSERTRAG KDDETAIL
                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Fill Table: ZINSERTRAG KDDETAIL")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KDDETAIL]([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[IdKDSTAMM])Select [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[Customer] FROM [ZINSERTRAG KUNDEN DETAILS]"
                    cmd.ExecuteNonQuery()
                    'Duplikate Löschen 
                    Me.BgwOCBSimport.ReportProgress(41, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates in Table: ZINSERTRAG KDDETAIL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDDETAIL] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KDDETAIL] GROUP BY [IdValueCustomer])"
                    cmd.ExecuteNonQuery()
                    'Update Zinsertrag, Kapi-Soli basierend auf [ZINSERTRAG KUNDEN DETAILS]
                    Me.BgwOCBSimport.ReportProgress(41, "Procedure:" & CURRENT_PROC & " - " & "Update Data in ZINSERTRAG KDDETAIL based on [IdValueCustomer] from [ZINSERTRAG KUNDEN DETAILS]")
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[ExchangeRate],A.[AmountEuro]=B.[AmountEuro],A.[KapertstG]=B.[KapertstG],A.[Soli]=B.[Soli],A.[KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG]  FROM [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[IdValueCustomer]=B.[IdValueCustomer]"
                    cmd.ExecuteNonQuery()
                    'Löschen in Tabelle ZINSERTRAG KDBASIC wenn keine Daten für IDSTAMM gibt
                    Me.BgwOCBSimport.ReportProgress(42, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KDBASIC where KDSTAMM not in Table ZINSERTRAG KDDETAIL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDBASIC] where [KDSTAMM] NOT IN (Select [IdKDSTAMM] from [ZINSERTRAG KDDETAIL])"
                    cmd.ExecuteNonQuery()
                    'Namen der Kunden in der Tabelle ZINSERTRAG KDBASIC einfügen
                    Me.BgwOCBSimport.ReportProgress(43, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Name in Table: ZINSERTRAG KDBASIC from CUSTOMER_INFO")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KDNAME1]=B.[English Name] from [ZINSERTRAG KDBASIC] A INNER JOIN [CUSTOMER_INFO] B ON A.[KDSTAMM]=B.[ClientNo]"
                    cmd.ExecuteNonQuery()


                    '?????????????????NEUANLAUF KAPISTPFLICHTIG???????????????????
                    Me.BgwOCBSimport.ReportProgress(44, "Procedure:" & CURRENT_PROC & " - " & "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KDDETAIL")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KDDETAIL] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(45, "Procedure:" & CURRENT_PROC & " - " & "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()


                    'SUMMEN BERECHEN ERTRAGSMONAT
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(46, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer in Table: ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN MONAT] A INNER JOIN (Select Sum([KapertstG]) as K,Sum([Soli]) as S,[IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y' GROUP BY [IdZinsertragsMonat])B on A.Zinsertragsmonat=B.IdZinsertragsMonat"
                    cmd.ExecuteNonQuery()

                    'SUMMEN BERECHEN ERTRAGSJAHR
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(48, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer in Table: ZINSERTRAG KUNDEN JAHR")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN JAHR] A INNER JOIN (Select Sum([SummeKapErSt]) as K,Sum(SummeSoli) as S,[IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "' GROUP BY [IdZinsertragJahr])B on A.[ErtragsJahr]=B.[IdZinsertragJahr]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(50, "Import Procedure:ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "Procedure:" & CURRENT_PROC & " - " & "There are no Data in Table:ALL_VOLUMES for Business Date: " & rd)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(10, "+++Import Procedure:ZINSERTRAEGE KUNDEN-INTEREST ON ACCOUNT is not VALID+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(0, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_INTEREST_TIME_DEPOSIT_DE_FINRECON()
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
                
                cmd.CommandText = "SELECT [RiskDate] FROM [FINRECON_NG] where [RiskDate]='" & rdsql & "'"
                Dim HasDataResult As String = cmd.ExecuteScalar
                If IsNothing(HasDataResult) = False Then


                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Create Temporary Table:#Temp_ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ZINSERTRAG KUNDEN DETAILS' AND xtype='U') CREATE TABLE [#Temp_ZINSERTRAG KUNDEN DETAILS]([ID] [int] IDENTITY(1,1) NOT NULL,[ValDateFrom] [datetime] NULL,[ValDate] [datetime] NULL,[Customer] [nvarchar](255) NULL,[ValYear] [float] NULL,[CustomerName] [nvarchar](255) NULL,[Account] [nvarchar](255) NULL,[RegistrationCountry] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[CCY] [nvarchar](255) NULL,[Product] [nvarchar](255) NULL,[Amount] [float] NULL,[ExchangeRate] [float] NULL,[AmountEuro] [float] NULL,[DB] [nvarchar](255) NULL,[KapertstG] [float] NULL,[Remark] [nvarchar](255) NULL,[Soli] [float] NULL,[KAPISTPFLICHTIG] [nvarchar](255) NULL,[BUNDESLAND] [nvarchar](255) NULL,[IdValueCustomer] [nvarchar](255) NULL,[IdZinsertragsMonat] [nvarchar](255) NULL,[IdErtragJahr] [float] NULL,[CustomerM] [nvarchar](50) NULL)  ELSE DELETE FROM [#Temp_ZINSERTRAG KUNDEN DETAILS]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start Import in the Table:#Temp_ZINSERTRAG KUNDEN DETAILS ")
                    cmd.CommandText = "INSERT INTO [#Temp_ZINSERTRAG KUNDEN DETAILS] ([Remark],[Account],[Customer],[ValDateFrom],[CCY],[ValDate],[Amount],[Product],[CustomerName],[RegistrationCountry]) SELECT ContractType_Definition,Contract_Nr_Clear,Client_Nr,StartDate,CCY,MaturityDate,Total_Interest_Amount_OrgCCY,ProductType,Client_Name,RegistrationCountry FROM FINRECON_NG where RiskDate='" & rdsql & "' and ContractType_Definition like 'Time Deposit%' and ClientType in ('C - COMPANY') and Amount_ID in ('PA')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [#Temp_ZINSERTRAG KUNDEN DETAILS] ([Remark],[Account],[Customer],[ValDateFrom],[CCY],[ValDate],[Amount],[Product],[CustomerName],[RegistrationCountry]) SELECT ContractType_Definition,Contract_Nr_Clear,Client_Nr,StartDate,CCY,MaturityDate,Total_Interest_Amount_OrgCCY,ProductType,Client_Name,RegistrationCountry FROM FINRECON_NG where RiskDate='" & rdsql & "' and ContractType_Definition like 'Money Market Deposit%' and ClientType in ('C - COMPANY') and Amount_ID in ('PA')"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM [#Temp_ZINSERTRAG KUNDEN DETAILS] where Customer is NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SET LANGUAGE German"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_ZINSERTRAG KUNDEN DETAILS] SET [ValYear]=DATEPART(Year,[ValDate]),[IdErtragJahr]=DATEPART(Year,[ValDate]),[IdValueCustomer]=CONVERT(VARCHAR(10), [ValDate], 104)+[Account],[IdZinsertragsMonat]=DATENAME(MONTH, [ValDate])+ ' ' + LTRIM(RTRIM(STR(DATEPART(Year,[ValDate]),4,0)))"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SET LANGUAGE English"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Check if Customer Nr is in Table:ZINSERTRAG KDBASIC and insert if not...")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KDBASIC]([KDSTAMM],[IdBank]) SELECT distinct [Customer],'3' FROM [#Temp_ZINSERTRAG KUNDEN DETAILS] Where [Customer] not in (Select [KDSTAMM] from [ZINSERTRAG KDBASIC])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Check if ZINSERTRAGSJAHR in Table ZINSERTRAG KUNDEN JAHR")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN JAHR]([ErtragsJahr],[IdBank]) SELECT DISTINCT DATEPART(Year,[ValDate]),'3' from [#Temp_ZINSERTRAG KUNDEN DETAILS] where DATEPART(Year,[ValDate]) not in  (Select [ErtragsJahr] from  [ZINSERTRAG KUNDEN JAHR])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Check if ZINSERTRAGSMONAT in Table ZINSERTRAG KUNDEN MONAT ")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN MONAT]([Zinsertragsmonat],[IdZinsertragJahr],[ZinsertragsmonatDATE]) SELECT DISTINCT [IdZinsertragsMonat],[IdErtragJahr],DATEADD(month, DATEDIFF(month, 0, [ValDate]), 0) from [#Temp_ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat] not in (Select [Zinsertragsmonat] from [ZINSERTRAG KUNDEN MONAT])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Insert ZINSERTRAGSMONAT in Table ZINSERTRAG KUNDEN MONAT despite the fact that no related contracts are present ")
                    cmd.CommandText = "SET LANGUAGE German"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN MONAT]([Zinsertragsmonat],SummeKapErSt,SummeSoli,[IdZinsertragJahr],[ZinsertragsmonatDATE]) SELECT DISTINCT DATENAME(MONTH, '" & rdsql & "')+ ' ' + LTRIM(RTRIM(STR(DATEPART(Year,'" & rdsql & "'),4,0))), 0,0,DATEPART(Year, '" & rdsql & "'),'" & rdsql & "' where DATENAME(MONTH, '" & rdsql & "')+ ' ' + LTRIM(RTRIM(STR(DATEPART(Year,'" & rdsql & "'),4,0))) not in (Select [Zinsertragsmonat] from [ZINSERTRAG KUNDEN MONAT])"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SET LANGUAGE English"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Define ERTRAGSJAHR and ERTRAGSMONAT")
                    Dim ERTRAGSJAHR As Double = 0 'Column J:ValYear
                    Dim ERTRAGSMONAT As String = Nothing 'Column Q:IdZinsertragsMonat
                    cmd.CommandText = "SELECT DISTINCT [IdErtragJahr] from [#Temp_ZINSERTRAG KUNDEN DETAILS]"
                    ERTRAGSJAHR = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT DISTINCT [IdZinsertragsMonat] from [#Temp_ZINSERTRAG KUNDEN DETAILS]"
                    ERTRAGSMONAT = cmd.ExecuteScalar

                    'Einfügen in ZINSERTRAG KUNDEN DETAILS
                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Start Import in the Table:ZINSERTRAG KUNDEN DETAILS ")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS] ([Remark],[Customer],[ValDateFrom],[CCY],[ValDate],[Amount],[Product],[DB],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT [Remark],[Customer],[ValDateFrom],[CCY],[ValDate],[Amount],[Product],[DB],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat] FROM [#Temp_ZINSERTRAG KUNDEN DETAILS]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Drop Table:#Temp_ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "DROP TABLE [#Temp_ZINSERTRAG KUNDEN DETAILS]"
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
                    Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Name and Registration country in Table: ZINSERTRAG KUNDEN DETAILS from Table CUSTOMER_INFO")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [CustomerName]=B.[English Name],[RegistrationCountry]=B.[COUNTRY_OF_REGISTRATION] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [CUSTOMER_INFO] B ON A.[Customer]=B.[ClientNo] where B.[ClientType] NOT IN ('F - FINANCIAL')"
                    cmd.ExecuteNonQuery()
                    'ÜBERPRPFEBN VON Tabelle ZINSERTRAG KDBASIC ob Kunde Kapitalertragssteuerpflichtig ist
                    Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Update Field: KAPISTPFLICHTIG in Table: ZINSERTRAG KUNDEN DETAILS from Table ZINSERTRAG KDBASIC")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]=B.[KDSTAMM]"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN WENN KEIN  KUNDENNAME GEFUNDEN WURDE
                    Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS where Customer Name is NULL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [CustomerName] IS NULL"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN ALLER CCB'S
                    Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Customer Type=F-FINANCIAL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [Customer] in (Select [ClientNo] from [CUSTOMER_INFO] where [ClientType]='F - FINANCIAL')"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN DER GEBIETS AUSLÄNDER
                    Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table: ZINSERTRAG KUNDEN DETAILS if Registration Country not DE")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [RegistrationCountry] NOT IN ('DE')"
                    cmd.ExecuteNonQuery()
                    'LÖSCHEN DER NEGATIVEN WERTE
                    Me.BgwOCBSimport.ReportProgress(14, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table:ZINSERTRAG KUNDEN DETAILS if Field (DB)=D")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN DETAILS] where [DB] IN ('D')"
                    cmd.ExecuteNonQuery()
                    'Exchange Rate für EUR übergeben
                    Me.BgwOCBSimport.ReportProgress(15, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in Table: ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= 1 WHERE [CCY]='EUR'"
                    cmd.ExecuteNonQuery()
                    'Exchange Rates importieren
                    'cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [ExchangeRate]= (Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] WHERE [ZINSERTRAG KUNDEN DETAILS].[CCY]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [ZINSERTRAG KUNDEN DETAILS].[ValDate]=[EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]) where [ExchangeRate]=0"
                    'cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[ValDate]=B.[EXCHANGE RATE DATE] WHERE A.[CCY]=B.[CURRENCY CODE] and A.[ExchangeRate]=0"
                    cmd.ExecuteNonQuery()
                    'UMRECHNUNG
                    Me.BgwOCBSimport.ReportProgress(16, "Procedure:" & CURRENT_PROC & " - " & "Calculate all Amounts in EURO")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [AmountEuro]= [Amount]/[ExchangeRate] where [AmountEuro]=0 and [ExchangeRate]<>0"
                    cmd.ExecuteNonQuery()
                    'Duplikate Löschen 
                    Me.BgwOCBSimport.ReportProgress(17, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from ZINSERTRAG KUNDEN DETAILS - Field: IdValueCustomer")
                    cmd.CommandText = "DELETE FROM [ZINSERTRAG KUNDEN DETAILS] WHERE [ID] not in (SELECT  Min([ID]) from [ZINSERTRAG KUNDEN DETAILS] GROUP BY [IdValueCustomer])"
                    cmd.ExecuteNonQuery()
                    'Kapitalertragsteuer berechnen
                    Me.BgwOCBSimport.ReportProgress(18, "Procedure:" & CURRENT_PROC & " - " & "Calculate Kapitalertragssteuer in  ZINSERTRAG KUNDEN DETAILS - Parameter:MELDEWESEN\KAPITALERTRAGSTEUER_SATZ")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=FLOOR([AmountEuro]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='KAPITALERTRAGSTEUER_SATZ')) where [KapertstG]=0"
                    cmd.ExecuteNonQuery()
                    'Kapitalertragssteuer auf null wenn KapitaSteuerbetrag<1
                    Me.BgwOCBSimport.ReportProgress(19, "Procedure:" & CURRENT_PROC & " - " & "Set Kapitalertragssteuer to 0 if Calculated Kapitalertragssteuer <1 in  ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]= 0 where [KapertstG] < 1"
                    cmd.ExecuteNonQuery()
                    'Soli berechnen
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Calculate Solidaritätsbeitrag in  ZINSERTRAG KUNDEN DETAILS  - Parameter:MELDEWESEN\SOLI_SATZ")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [Soli]= [KapertstG]*(Select [NPARAMETER1] from [PARAMETER] where [PARAMETER1]='SOLI_SATZ') where [Soli]=0"
                    cmd.ExecuteNonQuery()
                    'BUNDESLAND für Gesamt Kunden und Details einfügen
                    Me.BgwOCBSimport.ReportProgress(21, "Procedure:" & CURRENT_PROC & " - " & "Determine BUNDESLAND in  ZINSERTRAG KDBASIC,ZINSERTRAG KUNDEN DETAILS and ZINSERTRAG KDDETAIL ")
                    cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [BUNDESLAND]=B.[BUNDESLAND]  from [ZINSERTRAG KDBASIC] A INNER JOIN [PLZ_BUNDESLAND] B ON A.[KDPLZ]= B.[PLZ] where A.[KDPLZ] is not NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE   [ZINSERTRAG KDBASIC] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KDBASIC] A INNER JOIN [PLZ_BUNDESLAND] B ON A.[KDPLZ]= '0'+ B.[PLZ] where A.[KDPLZ] is not NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE   [ZINSERTRAG KUNDEN DETAILS] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KUNDEN DETAILS] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]= B.[KDSTAMM] where A.[BUNDESLAND] is NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE   [ZINSERTRAG KDDETAIL] SET [BUNDESLAND]=B.[BUNDESLAND] from [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KDBASIC] B ON A.[Customer]= B.[KDSTAMM] where A.[BUNDESLAND] is NULL"
                    cmd.ExecuteNonQuery()
                    'Kapitalertragssteuer + Soli auf 0 stellen wenn KAPISTEUERPFLICHT ist N
                    Me.BgwOCBSimport.ReportProgress(21, "Procedure:" & CURRENT_PROC & " - " & "Set Solidaritätsbeitrag + Kapitalertragsteuer to 0 if KAPITALSTEUERPFLICHTIG is N")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KUNDEN DETAILS] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDDETAIL] SET [KapertstG]=0,[Soli]=0 where [KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Löschen in Tabelle ZINSERTRAG KUNDEN MONAT wenn keine Daten für IdZinseertragsMonat gibt
                    'Me.BgwOCBSimport.ReportProgress(22, "Delete in Table ZINSERTRAG KUNDEN MONAT if IdZinsertragsmonat NULL is ")
                    'cmd.CommandText = "DELETE  FROM [ZINSERTRAG KUNDEN MONAT] where [Zinsertragsmonat] NOT IN (Select [IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS])"
                    'cmd.ExecuteNonQuery()
                    'Löschen in Tabelle ZINSERTRAG KUNDEN JAHR wenn keine Daten für IdZinsertragJahr gibt
                    'Me.BgwOCBSimport.ReportProgress(23, "Delete in Table ZINSERTRAG KUNDEN JAHR if IdZinsertragsjahr NULL is ")
                    'cmd.CommandText = "DELETE FROM [ZINSERTRAG KUNDEN JAHR] where [ErtragsJahr] NOT IN (Select [IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT])"
                    'cmd.ExecuteNonQuery()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    'Geamtsummen berechenn
                    Me.BgwOCBSimport.ReportProgress(24, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli...Please wait...")
                    'SUMMEN BERECHEN ERTRAGSMONAT
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(38, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN MONAT")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN MONAT] A INNER JOIN (Select Sum([KapertstG]) as K,Sum([Soli]) as S,[IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y' GROUP BY [IdZinsertragsMonat])B on A.Zinsertragsmonat=B.IdZinsertragsMonat"
                    cmd.ExecuteNonQuery()
                    'SUMMEN BERECHEN ERTRAGSJAHR
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(39, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN JAHR")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN JAHR] A INNER JOIN (Select Sum([SummeKapErSt]) as K,Sum(SummeSoli) as S,[IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "' GROUP BY [IdZinsertragJahr])B on A.[ErtragsJahr]=B.[IdZinsertragJahr]"
                    cmd.ExecuteNonQuery()


                    'Füllen der Tabelle ZINSERTRAG KDDETAIL
                    Me.BgwOCBSimport.ReportProgress(50, "Procedure:" & CURRENT_PROC & " - " & "Fill table ZINSERTRAG KDBASIC and ZINSERTRAG KDDETAIL...Pleae wait...")
                    cmd.CommandText = "INSERT INTO [ZINSERTRAG KDDETAIL]([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[IdKDSTAMM])Select [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr],[Customer] FROM [ZINSERTRAG KUNDEN DETAILS]"
                    cmd.ExecuteNonQuery()
                    'Duplikate Löschen 
                    Me.BgwOCBSimport.ReportProgress(51, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates in ZINSERTRAG KDDETAIL - IdValueCustomer")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDDETAIL] where [ID] not in (Select Min([ID]) from [ZINSERTRAG KDDETAIL] GROUP BY [IdValueCustomer])"
                    cmd.ExecuteNonQuery()
                    'Update Zinsertrag, Kapi-Soli basierend auf [ZINSERTRAG KUNDEN DETAILS]
                    Me.BgwOCBSimport.ReportProgress(51, "Procedure:" & CURRENT_PROC & " - " & "Update Data in ZINSERTRAG KDDETAIL based on [IdValueCustomer] from [ZINSERTRAG KUNDEN DETAILS]")
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[ExchangeRate],A.[AmountEuro]=B.[AmountEuro],A.[KapertstG]=B.[KapertstG],A.[Soli]=B.[Soli],A.[KAPISTPFLICHTIG]=B.[KAPISTPFLICHTIG]  FROM [ZINSERTRAG KDDETAIL] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[IdValueCustomer]=B.[IdValueCustomer]"
                    cmd.ExecuteNonQuery()
                    'Löschen in Tabelle ZINSERTRAG KDBASIC wenn keine Daten für IDSTAMM gibt
                    Me.BgwOCBSimport.ReportProgress(52, "Procedure:" & CURRENT_PROC & " - " & "Delete from ZINSERTRAG KDBASIC where IdKDSTAMM not in ZINSERTRAG KDDETAIL")
                    cmd.CommandText = "DELETE  FROM [ZINSERTRAG KDBASIC] where [KDSTAMM] NOT IN (Select [IdKDSTAMM] from [ZINSERTRAG KDDETAIL])"
                    cmd.ExecuteNonQuery()


                    'Namen der Kunden in der Tabelle ZINSERTRAG KDBASIC einfügen
                    Me.BgwOCBSimport.ReportProgress(53, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Name in ZINSERTRAG KDBASIC from Table CUSTOMER_INFO")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KDNAME1]=B.[English Name] from [ZINSERTRAG KDBASIC] A INNER JOIN [CUSTOMER_INFO] B ON A.[KDSTAMM]=B.[ClientNo]"
                    cmd.ExecuteNonQuery()

                    'NEUANLAUF KAPISTPFLICHTIG
                    '?????????????????NEUANLAUF KAPISTPFLICHTIG???????????????????
                    Me.BgwOCBSimport.ReportProgress(54, "Procedure:" & CURRENT_PROC & " - " & "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KDDETAIL")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KDDETAIL] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(55, "Procedure:" & CURRENT_PROC & " - " & "Update KAPISTPFLICHTIG in Table: ZINSERTRAG KDBASIC from ZINSERTRAG KUNDEN DETAILS")
                    cmd.CommandText = "UPDATE [ZINSERTRAG KDBASIC] SET [KAPISTPFLICHTIG]='N' from [ZINSERTRAG KDBASIC] A INNER JOIN [ZINSERTRAG KUNDEN DETAILS] B ON A.[KDSTAMM]=B.[Customer] where A.[KAPISTPFLICHTIG]='N'"
                    cmd.ExecuteNonQuery()



                    Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Second Recalculation Sum Kapitalertragssteuer and Soli...Please wait...")
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(38, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN MONAT")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN MONAT] A INNER JOIN (Select Sum([KapertstG]) as K,Sum([Soli]) as S,[IdZinsertragsMonat] from [ZINSERTRAG KUNDEN DETAILS] where [IdZinsertragsMonat]='" & ERTRAGSMONAT & "' and [KAPISTPFLICHTIG]='Y' GROUP BY [IdZinsertragsMonat])B on A.Zinsertragsmonat=B.IdZinsertragsMonat"
                    cmd.ExecuteNonQuery()
                    'SUMMEN BERECHEN ERTRAGSJAHR
                    'Kapitalertragssteuer
                    Me.BgwOCBSimport.ReportProgress(39, "Procedure:" & CURRENT_PROC & " - " & "Recalculate Sum Kapitalertragssteuer and Soli in Table: ZINSERTRAG KUNDEN JAHR")
                    cmd.CommandText = "UPDATE A SET A.[SummeKapErSt]=B.K,A.SummeSoli=B.S from [ZINSERTRAG KUNDEN JAHR] A INNER JOIN (Select Sum([SummeKapErSt]) as K,Sum(SummeSoli) as S,[IdZinsertragJahr] from [ZINSERTRAG KUNDEN MONAT] where [IdZinsertragJahr]='" & ERTRAGSJAHR & "' GROUP BY [IdZinsertragJahr])B on A.[ErtragsJahr]=B.[IdZinsertragJahr]"
                    cmd.ExecuteNonQuery()


                    Me.BgwOCBSimport.ReportProgress(100, "Import Procedure:ZINSERTRAEGE KUNDEN-TIME DEPOSITS is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "Procedure:" & CURRENT_PROC & " - " & "FINRECON_NG Data missing for Business Date :" & rd)
                End If

            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:ZINSERTRAEGE KUNDEN-TIME DEPOSITS is not VALID+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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
                ExcelFileName = Me.OCBS_Temp_Directory & "\A0181FT02_DC0070000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File:\A0181FT02_DC0070000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Rows("1:3").delete()
                    xlWorksheet1.Columns("I:I").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    xlWorksheet1.Range("A1").Value = "Product Name"
                    xlWorksheet1.Range("B1").Value = "Booking Centre"
                    xlWorksheet1.Range("C1").Value = "Contract No"
                    xlWorksheet1.Range("D1").Value = "Serial No"
                    xlWorksheet1.Range("E1").Value = "Client No"
                    'xlWorksheet1.Range("F1").Value = "Client No"
                    'xlWorksheet1.Range("G1").Value = "Cost Of Fund"
                    xlWorksheet1.Range("H1").Value = "Client Short Name"
                    xlWorksheet1.Range("I1").Value = "Trade Date"
                    xlWorksheet1.Range("J1").Value = "Value Date"
                    xlWorksheet1.Range("K1").Value = "Currency"
                    xlWorksheet1.Range("L1").Value = "Principal"
                    xlWorksheet1.Range("M1").Value = "Maturity Date"
                    xlWorksheet1.Range("N1").Value = "Final Maturity Date"
                    xlWorksheet1.Range("O1").Value = "Tenor"
                    xlWorksheet1.Range("P1").Value = "Contract Rate"
                    xlWorksheet1.Range("Q1").Value = "Total Interest"
                    xlWorksheet1.Range("R1").Value = "Accrual Interest"
                    xlWorksheet1.Range("S1").Value = "Principal Plus Interest"
                    xlWorksheet1.Range("T1").Value = "IS Day"
                    xlWorksheet1.Range("U1").Value = "IS Frequency"
                    xlWorksheet1.Range("V1").Value = "Product Code"
                    xlWorksheet1.Range("W1").Value = "AccountingCentre"
                    xlWorksheet1.Range("X1").Value = "Officer"
                    xlWorksheet1.Name = "Sheet1"



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
                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Excel File:A0181FT02_DC0070000_" & rdsql & ".xlsx reformated sucesfully")

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    cmd.CommandText = "SELECT distinct [RepDate] FROM [TIME DEP OUTST CLIENT DEALS] Where [RepDate]='" & rdsql & "'"
                    Dim t As String = cmd.ExecuteScalar()
                    If IsNothing(t) = False Then
                    Else
                        Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Start import to Table: TIME DEP OUTST CLIENT DEALS")
                        cmd.CommandText = "INSERT INTO [TIME DEP OUTST CLIENT DEALS]([Product Name],[Booking Centre],[Contract No],[Serial No],[Client No],[Client Short Name],[Trade Date],[Value Date],[Currency],[Principal],[Maturity Date],[Final Maturity Date],[Tenor],[Contract Rate],[Total Interest],[Accrual Interest],[Principal Plus Interest],[IS Day],[IS Frequency],[Product Code],[AccountingCentre],[RepDate]) SELECT [Product Name],[Booking Centre],REPLACE([Contract No],'/','000'),[Serial No],[Client No],[Client Short Name],CONVERT(Datetime,[Trade Date],104),CONVERT(Datetime,[Value Date],104),[Currency],[Principal],CONVERT(Datetime,[Maturity Date],104),'Final Maturity Date'=CASE when [Final Maturity Date] is not NULL then CONVERT(Datetime,[Final Maturity Date],104) else NULL END,[Tenor],[Contract Rate],[Total Interest],[Accrual Interest],[Principal Plus Interest],[IS Day],[IS Frequency],[Product Code],[AccountingCentre],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [Contract No] is not NULL')"
                        cmd.ExecuteNonQuery()
                        'Count Imported Rows
                        cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [Contract No] is not NULL')"
                        Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in TIME DEP OUTST CLIENT DEALS")
                        'Löschen der leeren Zellen
                        Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Delete from TIME DEP OUTST CLIENT DEALS where Booking Centre is NULL")
                        cmd.CommandText = "DELETE  FROM [TIME DEP OUTST CLIENT DEALS] where  [Booking Centre] is NULL"
                        cmd.ExecuteNonQuery()
                        'IdBank(einfügen)
                        Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Insert IdBank  in TIME DEP OUTST CLIENT DEALS")
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [IdBank]='3' where [IdBank] is NULL"
                        cmd.ExecuteNonQuery()
                        'Set Exchange Rates
                        Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in TIME DEP OUTST CLIENT DEALS")
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [ExchangeRate]=1 where [Currency]='EUR' and [ExchangeRate]=0 and  [RepDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [TIME DEP OUTST CLIENT DEALS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[RepDate]=B.[EXCHANGE RATE DATE] where A.[Currency]=B.[CURRENCY CODE] and A.[ExchangeRate]=0 and  A.[RepDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                        'Calculate Principal in EURO
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [PrincipalEUR]=Round([Principal]/[ExchangeRate],2) where [Principal] <>0 and [RepDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'Calculate Accrueds in EURO
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [AccrualInterestEUR]=Round([Accrual Interest]/[ExchangeRate],2) where [Accrual Interest] <>0 and [RepDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'Calculate Total Interest in EURO
                        cmd.CommandText = "UPDATE [TIME DEP OUTST CLIENT DEALS] SET [TotalInterestEUR]=Round([Total Interest]/[ExchangeRate],2) where [Total Interest] <>0 and [RepDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                        'Calculate Principal+Interest in EURO
                        Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Calculate Principal plus Interest in EUR")
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

                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Check if Parameter:EMAIL_REFI is Valid - For the creation of the Refinances Email")
                    cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_REFI'"
                    Dim EMAIL_REFI_Valid As String = cmd.ExecuteScalar

                    If EMAIL_REFI_Valid = "Y" Then
                        Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Parameter:EMAIL_REFI is valid-Start Report and email creation")
                        'REPORT GENERIERUNG
                        'Create Dataset
                        Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Create Dataset as Datasource for the Crystal report:REFINANCING_MATURITY_LIST")
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
                        Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Create Directory for the creation of the Report in pdf")
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='EMAIL_REFI_REPORTS_TEMP_FILE' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='EMAIL_REFI'"
                        ReportExpRefiFile = cmd.ExecuteScalar
                        'Select EMAIL RECEIVERS
                        Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Collect Email Receivers")
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
                            Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Create Email for Maturities on Monday " & SamstagNextMonday)
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
                                Me.BgwOCBSimport.ReportProgress(14, "Procedure:" & CURRENT_PROC & " - " & "Email for Maturities on Monday has being sended")
                            End If
                            '*********************************************************************************************************************************

                            '*********************************************************************************************************************************
                            'MATURITIES ON TUESDAY
                            Me.BgwOCBSimport.ReportProgress(15, "Procedure:" & CURRENT_PROC & " - " & "Create Email for Maturities on Tuesday " & SamstagNextTuesday)
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
                                Me.BgwOCBSimport.ReportProgress(16, "Procedure:" & CURRENT_PROC & " - " & "Email for Maturities on Tuesday has being sended")
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
                                Me.BgwOCBSimport.ReportProgress(18, "Procedure:" & CURRENT_PROC & " - " & "Email for Maturities has being sended")
                            End If
                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(11, "Parameter:EMAIL_REFI is not valid-No Email Creation")
                    End If
                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: TIME DEPOSIT OUTSTANDING CLIENT DEALS is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:TIME DEPOSIT OUTSTANDING CLIENT DEALS is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_IMPORT_CL_COMMITMENTS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "CL COMMITMENTS"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            'Dim rdsql As String = ""

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='CL COMMITMENTS' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: CL COMMITMENTS")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\LN-D-001_710030000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File:\LN-D-001_710030000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Rows("1:4").delete()
                    xlWorksheet1.Range("A:A").Delete()
                    xlWorksheet1.Range("A1").Value = "ContractNr"
                    xlWorksheet1.Range("B1").Value = "ContractLotNr"
                    xlWorksheet1.Range("C1").Value = "CommitmentType"
                    xlWorksheet1.Range("D1").Value = "ProductType"
                    xlWorksheet1.Range("E1").Value = "CCY"
                    xlWorksheet1.Range("F1").Value = "ClientName"
                    xlWorksheet1.Range("G1").Value = "SigningDate"
                    xlWorksheet1.Range("H1").Value = "StartDate"
                    xlWorksheet1.Range("I1").Value = "MaturityDate"
                    xlWorksheet1.Range("J1").Value = "AvailabilityEndDate"
                    xlWorksheet1.Range("K1").Value = "CommitmentAmount"
                    xlWorksheet1.Range("L1").Value = "UndrawnAmount"
                    xlWorksheet1.Range("M1").Value = "UnavailableAmount"
                    xlWorksheet1.Range("N1").Value = "Purpose"
                    xlWorksheet1.Range("O1").Value = "BookingCentre"
                    xlWorksheet1.Range("P1").Value = "AC_Officer"
                    xlWorksheet1.Range("Q1").Value = "AC_Centre"
                    xlWorksheet1.Range("R1").Value = "TrxOfficer"
                    xlWorksheet1.Range("S1").Value = "TrxCentre"
                    xlWorksheet1.Range("T1").Value = "ContractStatus"
                    xlWorksheet1.Range("U1").Value = "OBU_DBU"
                    xlWorksheet1.Range("V1").Value = "SynLoanIndicator"
                    xlWorksheet1.Range("W1").Value = "OCBS_Contract_Nr"
                    xlWorksheet1.Range("X1").Value = "CommitmentIndicator"
                    xlWorksheet1.Columns("L:N").numberformat = "#,##0.00"
                    xlWorksheet1.Name = "Sheet1"



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
                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Excel File:LN-D-001_710030000_" & rdsql & ".xlsx reformated sucesfully")

                    Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Delete current data in CL_COMMITMENTS")
                    cmd.CommandText = "DELETE  FROM [CL_COMMITMENTS] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Start import to Table: CL_COMMITMENTS")
                    cmd.CommandText = "INSERT INTO [CL_COMMITMENTS]([ContractNr],[ContractLotNr],[CommitmentType],[ProductType],[CCY],[ClientName],[SigningDate],[StartDate],[MaturityDate],[AvailabilityEndDate],[CommitmentAmount],[UndrawnAmount],[UnavailableAmount],[Purpose],[BookingCentre],[AC_Officer],[AC_Centre],[TrxOfficer],[TrxCentre],[ContractStatus],[OBU_DBU],[SynLoanIndicator],[OCBS_Contract_Nr],[CommitmentIndicator],[RiskDate]) SELECT [ContractNr],[ContractLotNr],[CommitmentType],[ProductType],[CCY],[ClientName],[SigningDate],[StartDate],[MaturityDate],[AvailabilityEndDate],[CommitmentAmount],[UndrawnAmount],[UnavailableAmount],[Purpose],[BookingCentre],[AC_Officer],[AC_Centre],[TrxOfficer],[TrxCentre],[ContractStatus],[OBU_DBU],[SynLoanIndicator],[OCBS_Contract_Nr],[CommitmentIndicator],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [ContractNr] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [ContractNr] is not NULL')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in CL_COMMITMENTS")
                    'Update ContractNr Clear
                    Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Update ContractNr Clear")
                    cmd.CommandText = "UPDATE [CL_COMMITMENTS] SET [ContractNrClear]=dbo.fn_StripCharacters([ContractLotNr],'^0-9') where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Update Client Nr
                    Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Update Client Nr.")
                    cmd.CommandText = "UPDATE A SET A.[ClientNr]=B.Client_Nr from [CL_COMMITMENTS] A INNER JOIN FINRECON_NG B on A.[ContractNrClear]=B.Contract_Nr_Clear and A.RiskDate=B.RiskDate  where A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Set Exchange Rates
                    Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Set Exchange Rates in CL_COMMITMENTS")
                    cmd.CommandText = "UPDATE A SET A.[ExchangeRate]=B.[MIDDLE RATE] FROM [CL_COMMITMENTS] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[RiskDate]=B.[EXCHANGE RATE DATE] where A.[CCY]=B.[CURRENCY CODE]  and  A.[RiskDate]='" & rdsql & "' "
                    cmd.ExecuteNonQuery()
                    'Calculate Amounts in EURO
                    cmd.CommandText = "UPDATE [CL_COMMITMENTS] SET [CommitmentAmountEUR]=Round([CommitmentAmount]/[ExchangeRate],2) where [CommitmentAmount] <>0 and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [CL_COMMITMENTS] SET [UndrawnAmountEUR]=Round([UndrawnAmount]/[ExchangeRate],2) where [UndrawnAmount] <>0 and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [CL_COMMITMENTS] SET [UnavailableAmountEUR]=Round([UnavailableAmount]/[ExchangeRate],2) where [UnavailableAmount] <>0 and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Import procedure: CL COMMITMENTS is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:CL COMMITMENTS is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT ALL VOLUMES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249_710030000_" & rdsql & ".xlsx"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Start reformating Excel File: AI-D-249_710030000_" & rdsql & ".xlsx")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("K3").Value.ToString.StartsWith("General Ledger Journal List") = True Then

                        'Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                        'Risk Date definieren
                        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                        Me.BgwOCBSimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Booking Date defined as " & rd)

                        'Unmerge Cells
                        xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:7").delete()
                        xlWorksheet1.Range("A1").Value = "BatchNo"
                        xlWorksheet1.Range("B1").Value = "SequenceNo"
                        xlWorksheet1.Range("C1").Value = "GL Book"
                        xlWorksheet1.Range("D1").Value = "Accounting Centre"
                        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                        xlWorksheet1.Range("F1").Value = "Value Date"
                        xlWorksheet1.Range("G1").Value = "AccountNo"
                        xlWorksheet1.Range("H1").Value = "Contract Type"
                        xlWorksheet1.Range("I1").Value = "Product Type"
                        xlWorksheet1.Range("J1").Value = "Event Type"
                        xlWorksheet1.Range("K1").Value = "CCY"
                        xlWorksheet1.Range("L1").Value = "Amount"
                        xlWorksheet1.Range("M1").Value = "DR_CR"
                        xlWorksheet1.Range("N1").Value = "GroupNo"
                        xlWorksheet1.Range("O1").Value = "ClientNo"
                        xlWorksheet1.Range("P1").Value = "Portfolio Code"
                        xlWorksheet1.Range("Q1").Value = "Reference Code"
                        xlWorksheet1.Range("R1").Value = "ChequeNo"
                        xlWorksheet1.Range("S1").Value = "AP"
                        xlWorksheet1.Range("T1").Value = "TRN Accounting Centre"
                        xlWorksheet1.Range("U1").Value = "Checker ID"
                        xlWorksheet1.Range("V1").Value = "Channel"
                        xlWorksheet1.Range("W1").Value = "Other System Key"
                        xlWorksheet1.Range("X1").Value = "Generated Type"
                        xlWorksheet1.Range("Y1").Value = "Reversal Flag"
                        xlWorksheet1.Range("Z1").Value = "Description"
                        'xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                        'xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                        'xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                        'xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                        'xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                        'xlWorksheet1.Range("AG1").Value = "AmountInEuro"
                        'xlWorksheet1.Range("AH1").Value = "ClientName"
                        xlWorksheet1.Name = "Sheet1"


                        EXCELL.Application.DisplayAlerts = False
                        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\ALL_VOLUMES.xlsx"
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
                        Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                        '*************IMPORT ALL VOLUMES************************
                        'Prüfen on Volume Date vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Check if entries allready exist in Table ALL_VOLUMES")
                        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [ALL_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                        Dim AVDate As String = cmd.ExecuteScalar()

                        If AVDate = "" Then
                            'Importieren in dem SQL SERVER
                            Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Start entries Import to table")
                            cmd.CommandText = "INSERT INTO [ALL_VOLUMES]([System],[BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT 'NEWG',[BatchNo],[SequenceNo],[GL Book],[Accounting Centre],'GL_AC_No'=CASE when ISNUMERIC([GL_AC_No])=1 then [GL_AC_No] else 0 end ,[Value Date],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL"
                            cmd.ExecuteNonQuery()
                            'Count Imported Rows
                            cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [Sheet1$] where [Accounting Centre] is not NULL')"
                            Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in ALL_VOLUMES")


                            'UPDATE GL ACCOUNT NAMES IN ALL VOLUMES
                            Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Update General Ledger Account Names from Table: GL_ACCOUNTS_NEWG")
                            cmd.CommandText = "UPDATE A SET A.[GL_AC_No_Name]=B.[NEWG_GL_ACC_Name] FROM [ALL_VOLUMES] A INNER JOIN [GL_ACCOUNTS_NEWG] B ON LTRIM(RTRIM(STR(A.[GL_AC_No],50,0)))=B.[NEWG_GL_ACC_Nr] where A.[GL_AC_No_Name] is NULL and A.[GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Reverse Debit Sign based on the DR_CR Value")
                            cmd.CommandText = "UPDATE [ALL_VOLUMES] SET Amount=Case when DR_CR in ('D') then ABS(Amount) *(-1) when DR_CR in ('C') then ABS(Amount) END where [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange rates for all entries in all Currencies")
                            cmd.CommandText = "UPDATE A SET A.[Exchange_Rate]=B.[MIDDLE RATE] FROM [ALL_VOLUMES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[CCY]=B.[CURRENCY CODE]  where B.[EXCHANGE RATE DATE]='" & rdsql & "' and A.[GL_Rep_Date]='" & rdsql & "' and A.[CCY] not in ('EUR') and A.[AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE [ALL_VOLUMES] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Calculate Amounts in Euro")
                            cmd.CommandText = "UPDATE [ALL_VOLUMES] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Update Client Name")
                            cmd.CommandText = "UPDATE A Set A.ClientName=B.[English Name] from ALL_VOLUMES A INNER JOIN CUSTOMER_INFO B on A.ClientNo=B.ClientNo where A.ClientNo is not NULL and A.[GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Update Nostro Accounts")
                            cmd.CommandText = "Update ALL_VOLUMES set AccountNo=LEFT(AccountNo,10) where LEFT(AccountNo,10) in (Select [INTERNAL ACCOUNT] from SSIS) and [GL_Rep_Date]='" & rdsql & "'"
                            cmd.ExecuteNonQuery()
                            Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Import procedure: IMPORT ALL VOLUMES finished successfully")
                        Else
                            Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Entries allready exist in Table ALL_VOLUMES")

                        End If

                        'Import Daily Accruals in ACCRUED INTEREST VOSTRO DEPOSITS
                        'Me.BgwOCBSimport.ReportProgress(6, "Check if entries allready exist in Table ACCRUED INTEREST VOSTRO DEPOSITS")
                        'cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [ACCRUED INTEREST VOSTRO DEPOSITS] where [GL_Rep_Date]='" & rdsql & "' "
                        'AVDate = cmd.ExecuteScalar
                        'If AVDate = "" Then
                        '    Me.BgwOCBSimport.ReportProgress(7, "Start entries Import to table ACCRUED INTEREST VOSTRO DEPOSITS")
                        '    cmd.CommandText = "INSERT INTO [ACCRUED INTEREST VOSTRO DEPOSITS]([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro]) Select [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date],[GL_Item_Nr],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] from [ALL_VOLUMES] where [Product Type] in ('DDPVOS02','DDPVOS03') and [Description] like '%DAILY ACCRUAL%' and [GL_Rep_Date]='" & rdsql & "'"
                        '    cmd.ExecuteNonQuery()
                        'Else
                        '    Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table ACCRUED INTEREST VOSTRO DEPOSITS")
                        'End If

                        'Create EMAIL Notification if Booking Entries are present in OCBS Account Nr.52401700 (Bundesbank Interests)
                        Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Check if booking entries are present in GL Account Nr.510001")
                        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='BUBA_INTERESTS_BOOKING_ACCOUNT' and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER] in ('BUBA_INTEREST_BOOKINGS')"
                        Dim BubaInterestsBookingAccount As String = cmd.ExecuteScalar
                        cmd.CommandText = "Select Count([IdNr]) from [ALL_VOLUMES] where [GL_AC_No] in (' " & BubaInterestsBookingAccount & "') and [GL_Rep_Date]='" & rdsql & "'"
                        Dim BubaBookingResult As Double = cmd.ExecuteScalar
                        If BubaBookingResult > 0 Then
                            QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1] in ('BUBA_INTERESTS_BOOKING_NOTIFICATION_EMAIL_RECEIVER_TO') and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER] in ('BUBA_INTEREST_BOOKINGS')"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Dim EMAIL_USERS As String = ""
                            For i = 0 To dt.Rows.Count - 1
                                EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                            Next
                            dt.Clear()

                            QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1] in ('BUBA_INTERESTS_BOOKING_NOTIFICATION_EMAIL_RECEIVER_CC') and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER] in ('BUBA_INTEREST_BOOKINGS')"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New DataTable()
                            da.Fill(dt)
                            Dim EMAIL_USERS_CC As String = ""
                            For i = 0 To dt.Rows.Count - 1
                                EMAIL_USERS_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
                            Next
                            dt.Clear()

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

                            EItem.Subject = "Booking Entries fund in the NEWG GL Account Nr. " & BubaInterestsBookingAccount & " (Int Rec - Nostro - Central bank) on " & rd
                            EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain
                            Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"
                            Dim StrBody2 As String = "In order to calculate the correct unbooked BUNDESBANK Interests," & vbNewLine _
                                                     & "please check with Accounting Dept. if a.m. booking(s) are related to Central Banks adviced/accrued Negative/Positive Interests " & vbNewLine _
                                                     & "and set under PS TOOL -->" & vbNewLine _
                                                     & "Module: ACCOUNTING-->Mindestreserve (BUNDESBANK) + Interests-->Column:<Booked Mark for Accrueds from Accounting> as <Marked> for the specific Amount"
                            Dim EMAIL_TEXT As String = ""
                            Dim myBuilder As New StringBuilder

                            EMAIL_TEXT = "The following Booking entries where fund in the GL Account: " & BubaInterestsBookingAccount & " on " & rd
                            myBuilder.Append("Booking Date:     " & "Value Date:      " & "Booked Amount:      " & "Booking Description:  " & vbNewLine)
                            QueryText = "Select [GL_Rep_Date],[Value Date],[CCY],[Amount],[Description] from [ALL_VOLUMES] where [GL_AC_No] in (' " & BubaInterestsBookingAccount & "') and [GL_Rep_Date]='" & rdsql & "'"
                            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt1 = New DataTable()
                            da1.Fill(dt1)
                            For y = 0 To dt1.Rows.Count - 1
                                Dim BookingDate As Date = dt1.Rows.Item(y).Item("GL_Rep_Date")
                                Dim ValueDate As Date = dt1.Rows.Item(y).Item("Value Date")
                                Dim CCY As String = dt1.Rows.Item(y).Item("CCY")
                                Dim BookedAmount As Double = dt1.Rows.Item(y).Item("Amount")
                                Dim BookingDescription As String = dt1.Rows.Item(y).Item("Description")
                                myBuilder.Append(BookingDate.ToString("dd.MM.yyyy") & "            " & ValueDate.ToString("dd.MM.yyyy") & "        " & FormatNumber(BookedAmount, 2) & "                " & BookingDescription & vbNewLine)
                            Next
                            EItem.Body = StrBody1 & vbNewLine & vbNewLine & EMAIL_TEXT & vbNewLine & vbNewLine & myBuilder.ToString & vbNewLine & vbNewLine & StrBody2
                            'EItem.Display()
                            EItem.Send()

                        End If
                    Else
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++ Procedure:" & CURRENT_PROC & " - Wrong Format in Excel File")
                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT ALL VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT CUSTOMER VOLUMES")
                'Dim ExcelFileName As String = ""
                'ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                'If File.Exists(ExcelFileName) = True Then
                '    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                '    'Excel Datei Öffnen und Datenformat ändern
                '    EXCELL = CreateObject("Excel.Application")
                '    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                '    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                '    EXCELL.Visible = False

                '    'Prüfen ob Daten vorhanden sind
                '    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                '        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                '        'Risk Date definieren
                '        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                '        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                '        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                '        'Unmerge Cells
                '        xlWorksheet1.Columns("A:A").unMerge()
                '        xlWorksheet1.Rows("1:6").delete()
                '        xlWorksheet1.Range("A1").Value = "BatchNo"
                '        xlWorksheet1.Range("B1").Value = "SequenceNo"
                '        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                '        xlWorksheet1.Range("H1").Value = "AccountNo"
                '        xlWorksheet1.Range("N1").Value = "DR_CR"
                '        xlWorksheet1.Range("O1").Value = "GroupNo"
                '        xlWorksheet1.Range("P1").Value = "ClientNo"
                '        xlWorksheet1.Range("T1").Value = "ChequeNo"
                '        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                '        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                '        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                '        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                '        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                '        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                '        EXCELL.Application.DisplayAlerts = False
                '        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\CUSTOMER_VOLUMES.xls"
                '        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                '        'xlWorkBook.SaveAs("C:\Volumes.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                '        EXCELL.Application.DisplayAlerts = True
                '        xlWorkBook.Close()

                '        EXCELL.Quit()
                '        EXCELL = Nothing

                '        'Excel Instanz beenden
                '        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                '        Dim i1 As Short
                '        i1 = 0
                '        For i1 = 0 To (procs.Length - 1)
                '            procs(i1).Kill()
                '        Next i1
                '        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

                '        'Prüfen ob Zinsabgrenzungen GIROKONTEN vorhanden sind
                '        cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [ACCRUED INTEREST DEMAND DEPOSITS] where [GL_Rep_Date]='" & rdsql & "' "
                '        Dim ZDate As String = cmd.ExecuteScalar
                '        If ZDate = "" Then
                '            'IMPORTIEREN ZINSABGRENZUNGEN FÜR GIROKONTEN
                '            Me.BgwOCBSimport.ReportProgress(6, "Start Import entries to table")
                '            cmd.CommandText = "INSERT INTO [ACCRUED INTEREST DEMAND DEPOSITS] ([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],' " & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]') where [Accounting Centre] is not NULL and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & rdsql & "') and [GL_AC_No] in ('25109212','17200212') and [Product Type] in ('DDPCUR01','DDPCUR02') and  [Description] not like 'INTEREST%'"
                '            cmd.ExecuteNonQuery()
                '            cmd.CommandText = "UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [GL_Rep_Date]='" & rdsql & "' where [GL_Rep_Date] is NULL"
                '            cmd.ExecuteNonQuery()
                '            Me.BgwOCBSimport.ReportProgress(6, "Update Event Typein Table ACCRUED INTEREST DEMAND DEPOSITS")
                '            cmd.CommandText = "BEGIN UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [Event Type]='DR',[DR_CR]='D' where [Amount]<0 END BEGIN UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [Event Type]='CR',[DR_CR]='C' where [Amount]>=0 END"
                '            cmd.ExecuteNonQuery()
                '            Me.BgwOCBSimport.ReportProgress(6, "Insert Exchange Rates in Table: ACCRUED INTEREST DEMAND DEPOSITS")
                '            cmd.CommandText = "UPDATE A  SET A.[Exchange_Rate]=B.[MIDDLE RATE] FROM [ACCRUED INTEREST DEMAND DEPOSITS] A INNER JOIN [EXCHANGE RATES OCBS] B ON  A.[GL_Rep_Date]=B.[EXCHANGE RATE DATE] where A.[CCY]=B.[CURRENCY CODE] and  A.[GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                '            cmd.ExecuteNonQuery()
                '            cmd.CommandText = "UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [Exchange_Rate]='1' where [GL_Rep_Date]='" & rdsql & "' and [CCY]='EUR'"
                '            cmd.ExecuteNonQuery()
                '            Me.BgwOCBSimport.ReportProgress(6, "Calculate Amount in Euro for all entries in Table: ACCRUED INTEREST DEMAND DEPOSITS")
                '            cmd.CommandText = "UPDATE [ACCRUED INTEREST DEMAND DEPOSITS] SET [AmountInEuro]=Round([Amount]/Exchange_Rate,2) where [GL_Rep_Date]='" & rdsql & "' and [AmountInEuro] is NULL"
                '            cmd.ExecuteNonQuery()
                '            cmd.CommandText = "UPDATE A set A.[GL_AC_No_Name]=B.[English Name] from [ACCRUED INTEREST DEMAND DEPOSITS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where  [GL_AC_No_Name] is NULL"
                '            cmd.ExecuteNonQuery()
                '        End If

                'Prüfen on Volume Date vorhanden ist
                Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Check if entries allready exist in Table CUSTOMER VOLUMES")
                cmd.CommandText = "SELECT distinct([GL_Rep_Date]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & rdsql & "' "
                Dim VDate As String = cmd.ExecuteScalar()
                If VDate = "" Then
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Prepare to import the new Customer Volumes")
                    'Maximum GL_Rep_Date definieren
                    cmd.CommandText = "SELECT MAX([GL_Rep_Date]) from [CUSTOMER_VOLUMES] where [GL_Rep_Date]<'" & rdsql & "'"
                    Dim LastCBDate As Date = cmd.ExecuteScalar()
                    Dim LastCBDateSql As String = LastCBDate.ToString("yyyyMMdd")
                    'OPENNING BALANCES CUSTOMER ACCOUNTS
                    Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Insert Opening Ledger Balances to the Table CUSTOMER VOLUMES")
                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro])SELECT  'OPENING BALANCE','" & rdsql & "',[CCY],[Amount],[GL_AC_No],'" & rdsql & "',[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] FROM [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & LastCBDateSql & "' and [BatchNo]='CLOSING BALANCE' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & LastCBDateSql & "')"
                    cmd.ExecuteNonQuery()

                    'QueryText = "SELECT  [IdNr],[BatchNo],[GL_AC_No],[Value Date],[AccountNo],[CCY],[Amount],[DR_CR],[GL_Rep_Date],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro] FROM [CUSTOMER_VOLUMES] where [GL_Rep_Date]='" & LastCBDateSql & "' and [BatchNo]='CLOSING BALANCE' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & LastCBDateSql & "')"
                    'da = New SqlDataAdapter(QueryText.Trim(), conn)
                    'dt = New DataTable()
                    'da.Fill(dt)
                    'Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX5))
                    'For i = 0 To dt.Rows.Count - 1
                    '    Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                    '    'Me.BgwOCBSimport.ReportProgress(9, "Insert Opening Ledger Balance for Customer Account:" & dt.Rows.Item(i).Item("AccountNo") & "  Currency: " & dt.Rows.Item(i).Item("CCY"))
                    '    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[GL_AC_No],[GL_Rep_Date],[AccountNo],[GL_AC_No_Name],[Exchange_Rate],[AmountInEuro])Values('OPENING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(dt.Rows.Item(i).Item("Amount")) & "," & Str(dt.Rows.Item(i).Item("GL_AC_No")) & ",'" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "','" & dt.Rows.Item(i).Item("GL_AC_No_Name") & "'," & Str(dt.Rows.Item(i).Item("Exchange_Rate")) & "," & Str(dt.Rows.Item(i).Item("AmountInEuro")) & ")"
                    '    cmd.ExecuteNonQuery()
                    'Next
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Importieren in dem SQL SERVER
                    Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Start Import entries to table")
                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],Exchange_Rate,AmountInEuro,[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],Exchange_Rate,AmountInEuro,[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],GL_Rep_Date FROM ALL_VOLUMES where GL_Rep_Date='" & rdsql & "' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & rdsql & "') and [GL_AC_No] in ('220164') and ClientNo not like 'Z%'"
                    cmd.ExecuteNonQuery()
                    'UPDATE CUSTOMER ACCOUNT NAMES IN CUSTOMER_VOLUMES
                    Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Update Customer Account Names in Table CUSTOMER_VOLUMES")
                    cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name] from [CUSTOMER_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where A.GL_Rep_Date='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Me.BgwOCBSimport.ReportProgress(14, "Update Event Typein Table CUSTOMER_VOLUMES")
                    'cmd.CommandText = "BEGIN UPDATE [CUSTOMER_VOLUMES] SET [Event Type]='DR',[DR_CR]='D' where [Amount]<0 END BEGIN UPDATE [CUSTOMER_VOLUMES] SET [Event Type]='CR',[DR_CR]='C' where [Amount]>=0 END"
                    'cmd.ExecuteNonQuery()


                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                    Me.BgwOCBSimport.ReportProgress(17, "Procedure:" & CURRENT_PROC & " - " & "Calculate Closing Balances for all Customer Accounts (Not EURO)")
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
                            cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'220164','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                            cmd.ExecuteNonQuery()
                        Else
                            cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "','0','0'," & Str(c) & ",'220164','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Letzten Saldo ermitteln und einfügen CUSTOMER ACCOUNTS (FREMDWÄHRUNGEN)
                    Me.BgwOCBSimport.ReportProgress(19, "Procedure:" & CURRENT_PROC & " - " & "Calculate Closing Balances for all Customer Accounts (in EURO)")
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
                            cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "'," & Str(a) & "," & Str(d1) & "," & Str(c) & ",'220164','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                            cmd.ExecuteNonQuery()
                        Else
                            cmd.CommandText = "INSERT INTO [CUSTOMER_VOLUMES] ([BatchNo],[Value Date],[CCY],[Amount],[AmountInEuro],[Exchange_Rate],[GL_AC_No],[GL_Rep_Date],[AccountNo])Values('CLOSING BALANCE','" & rdsql & "','" & dt.Rows.Item(i).Item("CCY") & "','0','0'," & Str(c) & ",'220164','" & rdsql & "','" & dt.Rows.Item(i).Item("AccountNo") & "')"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Update Client Name in Table CUSTOMER_VOLUMES")
                    cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name],[Product Type]=B.[ProductCode] from [CUSTOMER_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where [GL_Rep_Date]='" & rdsql & "' and [GL_AC_No_Name] is NULL"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(50, "Procedure:" & CURRENT_PROC & " - " & "Delete from Table CUSTOMER_VOLUMES where Product Type is not Current Account ")
                    cmd.CommandText = "DELETE FROM [CUSTOMER_VOLUMES]  where [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where ProductCode in ('DDPCUR01','DDPCUR02')) and [GL_Rep_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Update Description in CUSTOMER VOLUMES")
                    cmd.CommandText = "UPDATE A SET A.Description=B.Description from CUSTOMER_VOLUMES A INNER JOIN ALL_VOLUMES B on A.BatchNo=B.BatchNo and A.GL_Rep_Date=B.GL_Rep_Date where B.Description is not NULL and A.GL_Rep_Date='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Extract PAYMENT REFERENCE in CUSTOMER_VOLUMES")
                    cmd.CommandText = "UPDATE [CUSTOMER_VOLUMES] SET [PaymentReference]=LTRIM(RTRIM(Substring([Description],0,16))) where ([Description] like 'DEI%' or [Description] like 'DEO%') and [GL_Rep_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Update Product Type Description")
                    cmd.CommandText = "UPDATE A SET A.[ProductTypeDescription]=B.[Product Type Name] from [CUSTOMER_VOLUMES] A INNER JOIN ProductType B on A.[Product Type]=B.[Product Type] where A.[GL_Rep_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Update Value Balance from CUSTOMER ACC BALANCES")
                    cmd.CommandText = "UPDATE A SET A.[AmountValueBalance]=B.ValueBalance,A.AmountInEuro_ValueBalance=B.ValueBalanceEUR from [CUSTOMER_VOLUMES] A INNER JOIN CUSTOMER_ACC_BALANCES B on REPLACE(LTRIM(REPLACE(STR(A.AccountNo,10,0), '0', ' ')), ' ', '0')=REPLACE(LTRIM(REPLACE(B.AccountNo, '0', ' ')), ' ', '0') and A.GL_Rep_Date=B.BalanceDate where A.[GL_Rep_Date]='" & rdsql & "' and A.BatchNo in ('CLOSING BALANCE')"
                    cmd.ExecuteNonQuery()
                    '****************************************************************************************************************
                    Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Check Balances in CUSTOMER VOLUMES-SQL Parameter:SEVERAL SELECTIONS/Customer_Balances_Check")
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('Customer_Balances_Check') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start Customer Balances check for " & rd)
                        Me.BgwOCBSimport.ReportProgress(3, "Procedure:" & CURRENT_PROC & " - " & "Execute SQL Commands for SEVERAL SELECTIONS/Customer_Balances_Check")
                        Me.QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('Customer_Balances_Check') and [Id_SQL_Parameters] in ('SEVERAL SELECTIONS')"
                            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i = 0 To dt.Rows.Count - 1
                                SqlCommandText = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText
                                If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                                Me.BgwOCBSimport.ReportProgress(3, "Execute Customer Balances check")
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                    Else
                        Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "SEVERAL SELECTIONS/Customer_Balances_Check PARAMETER STATUS is Invalid")
                    End If
                    ''Calculate Sum of Demand Deposits (CUSTOMERS)
                    'Me.BgwOCBSimport.ReportProgress(60, "Calculate Sum of Customer Demand Deposits")
                    'cmd.CommandText = "Select sum([AmountInEuro]) from   [CUSTOMER_VOLUMES] where   [BatchNo]='CLOSING BALANCE' and [AmountInEuro]>0 and [GL_Rep_Date]='" & rdsql & "'"
                    'Dim fxp As Double = 0
                    'If cmd.ExecuteScalar IsNot DBNull.Value Then
                    '    fxp = cmd.ExecuteScalar
                    'Else
                    '    fxp = 0
                    'End If
                    ''EINFÜGEN IN RISK LIMIT DAILY CONTROL
                    'Me.BgwOCBSimport.ReportProgress(70, "Insert Sum of Customer Demand Deposits in RISK LIMIT DAILY CONTROL")
                    'cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    'Dim t As String = cmd.ExecuteScalar
                    'If IsNothing(t) = False Then
                    '    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Bank Bilanz]='" & Str(fxp) & "' WHERE [RLDC Date]='" & rdsql & "'"
                    '    cmd.ExecuteNonQuery()
                    'End If
                    'If IsNothing(t) = True Then
                    '    cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                    '    cmd.ExecuteNonQuery()
                    '    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Bank Bilanz]='" & Str(fxp) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                    '    cmd.ExecuteNonQuery()
                    'End If
                    ''*********************************************************************************************************************
                    'Me.BgwOCBSimport.ReportProgress(90, "Update +/- Interest Ammounts in Table: KUNDEN INTEREST only for Customer Accounts")
                    'cmd.CommandText = "Update A Set A.[AmountEuro]=B.[AmountInEuro] from [KUNDEN INTEREST ON AC] A INNER JOIN [CUSTOMER_VOLUMES] B ON A.[Account]=B.[AccountNo] and A.[ValDate]=B.[GL_Rep_Date] and ABS(A.[AmountEuro])=ABS(B.[AmountInEuro])"
                    'cmd.ExecuteNonQuery()


                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT CUSTOMER VOLUMES finished successfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Entries allready exist in Table CUSTOMER_VOLUMES")
                End If
                'Else
                '    Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                'End If
                '    Else
                'Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                '    End If
                'Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT CUSTOMER VOLUMES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT SUSPENCE BALANCES")
                'Importieren in dem SQL SERVER
                Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Delete Suspence Balances for " & rd)
                cmd.CommandText = "DELETE FROM [SUSPENCE_BALANCES] where BalanceDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Count Imported Rows
                Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Insert Suspence Balances from Daily Balance Details Sheet for " & rd)
                cmd.CommandText = "INSERT INTO [SUSPENCE_BALANCES]([Currency],[Suspence_Acc_Nr],[Ledger_Balance],[BalanceDate],Exchange_Rate,[Ledger_Balance_EUR])SELECT Orig_CUR,ReleatedAccountNr,Orig_Balance,BSDate,1,Total_Balance from DailyBalanceDetailsSheets where BSDate='" & rdsql & "' and ReleatedAccountNr is not NULL and LEN(ReleatedAccountNr)=27 and LEFT(ReleatedAccountNr,2)='71' GROUP BY ReleatedAccountNr,Orig_CUR,Orig_Balance,BSDate,Total_Balance"
                Me.BgwOCBSimport.ReportProgress(7, cmd.ExecuteScalar & " rows imported in SUSPENCE_BALANCES")

                'UPDATE GL ACCOUNT NAMES IN ALL VOLUMES
                Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Update Suspence Acc.Name,Client Nr. from Table: CUSTOMER_ACCOUNTS")
                cmd.CommandText = "Update A SET A.ClientNr=B.ClientNo,A.Suspence_Acc_Name=B.[English Name] from SUSPENCE_BALANCES A INNER JOIN CUSTOMER_ACCOUNTS B on A.Suspence_Acc_Nr=B.[Client Account] where BalanceDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange rates for all entries in all Currencies")
                cmd.CommandText = "Update A SET A.Exchange_Rate=B.[MIDDLE RATE] from SUSPENCE_BALANCES A INNER JOIN [EXCHANGE RATES OCBS] B on A.Currency=B.[CURRENCY CODE] and A.BalanceDate=B.[EXCHANGE RATE DATE] where A.BalanceDate='" & rdsql & "'"
                cmd.ExecuteNonQuery()
               


                'cmd.CommandText = "SELECT Max([ID]) FROM [SUSPENCE_BALANCES] WHERE [BalanceDate]='" & rdsql & "'"
                ''Dim AV As String = cmd.ExecuteScalar
                'If cmd.ExecuteScalar Is DBNull.Value Then

                '    Dim ExcelFileName As String = ""
                '    ExcelFileName = Me.OCBS_Temp_Directory & "\A1051R771_DC0070000_" & rdsql & ".xlsx"
                '    If File.Exists(ExcelFileName) = True Then
                '        Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \A1051R771_DC0070000_" & rdsql & ".xlsx")
                '        'Excel Datei Öffnen und Datenformat ändern
                '        EXCELL = CreateObject("Excel.Application")
                '        xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                '        xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                '        EXCELL.Visible = False

                '        'Prüfen ob Daten vorhanden sind
                '        If xlWorksheet1.Range("A1").Value.ToString.StartsWith("Internal Account Balance Report") = True Then

                '            Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                '            'Unmerge Cells
                '            xlWorksheet1.Columns("A:A").unMerge()
                '            xlWorksheet1.Rows("1:2").delete()
                '            xlWorksheet1.Range("A1").Value = "Suspence_Acc_Nr"
                '            xlWorksheet1.Range("B1").Value = "Suspence_Acc_Name"
                '            xlWorksheet1.Range("C1").Value = "Balance Direction"
                '            xlWorksheet1.Range("D1").Value = "Ledger_Balance"
                '            xlWorksheet1.Name = "Sheet1"

                '            EXCELL.Application.DisplayAlerts = False
                '            Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\SUSPENCE_BALANCES.xls"
                '            xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                '            EXCELL.Application.DisplayAlerts = True
                '            xlWorkBook.Close()

                '            EXCELL.Quit()
                '            EXCELL = Nothing

                '            'Excel Instanz beenden
                '            Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                '            Dim i1 As Short
                '            i1 = 0
                '            For i1 = 0 To (procs.Length - 1)
                '                procs(i1).Kill()
                '            Next i1
                '            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '            Me.BgwOCBSimport.ReportProgress(5, "Excel File: \DD-D-025 - Suspense Account Balance Exception Report-en.xls reformated sucesfully")

                '            'Importieren in dem SQL SERVER
                '            Me.BgwOCBSimport.ReportProgress(7, "Start entries Import to table")
                '            cmd.CommandText = "INSERT INTO [SUSPENCE_BALANCES]([Suspence_Acc_Nr],[Suspence_Acc_Name],[Ledger_Balance],[BalanceDate]) SELECT [Suspence_Acc_Nr],[Suspence_Acc_Name],[Ledger_Balance],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Suspence_Acc_Nr],[Suspence_Acc_Name],[Ledger_Balance] FROM [Sheet1$] where Suspence_Acc_Nr is not NULL') "
                '            cmd.ExecuteNonQuery()
                '            'Count Imported Rows
                '            cmd.CommandText = "SELECT Count(*) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Suspence_Acc_Nr],[Suspence_Acc_Name],[Ledger_Balance] FROM [Sheet1$] where Suspence_Acc_Nr is not NULL')"
                '            Me.BgwOCBSimport.ReportProgress(7, cmd.ExecuteScalar & " rows imported in SUSPENCE_BALANCES")

                '            'UPDATE GL ACCOUNT NAMES IN ALL VOLUMES
                '            Me.BgwOCBSimport.ReportProgress(9, "Update Suspence Acc.Name,Client Nr. from Table: CUSTOMER_ACCOUNTS")
                '            cmd.CommandText = "UPDATE A SET A.[Suspence_Acc_Name]=B.[English Name],A.[ClientNr]=B.[ClientNo],A.[Currency]=B.[Deal Currency] from [SUSPENCE_BALANCES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Suspence_Acc_Nr]=B.[Client Account] where  A.[BalanceDate]='" & rdsql & "'"
                '            cmd.ExecuteNonQuery()
                '            Me.BgwOCBSimport.ReportProgress(10, "Insert Exchange rates for all entries in all Currencies")
                '            cmd.CommandText = "UPDATE A SET A.[Exchange_Rate]=B.[MIDDLE RATE] FROM [SUSPENCE_BALANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[Currency]=B.[CURRENCY CODE]  where B.[EXCHANGE RATE DATE]='" & rdsql & "' and A.[BalanceDate]='" & rdsql & "' and A.[Currency] not in ('EUR')"
                '            cmd.ExecuteNonQuery()
                '            cmd.CommandText = "UPDATE [SUSPENCE_BALANCES] SET [Exchange_Rate]='1' where [BalanceDate]='" & rdsql & "' and [Currency]='EUR'"
                '            cmd.ExecuteNonQuery()
                '            Me.BgwOCBSimport.ReportProgress(11, "Calculate Amounts in Euro")
                '            cmd.CommandText = "UPDATE [SUSPENCE_BALANCES] SET [Ledger_Balance_EUR]=Round([Ledger_Balance]/Exchange_Rate,2) where [BalanceDate]='" & rdsql & "'"
                '            cmd.ExecuteNonQuery()


                '            '+++++++NEW CODE+++++++++++
                '            'QueryText = "SELECT * FROM [SUSPENCE_BALANCES] where [Suspence_Acc_Nr] in (SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SUSPENCE_ACC_EMAIL' and  [PARAMETER1]='Account') and [Ledger_Balance_EUR]<0 and [BalanceDate]='" & rdsql & "' order by [ID] desc"
                '            'da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                '            'dt1 = New DataTable()
                '            'da1.Fill(dt1)

                '            'If IsNothing(dt1) = False AndAlso dt1.Rows.Count > 0 Then

                '            '    'EMAIL NOSTRO RECEIVERS Parameter prüfen
                '            '    Me.BgwOCBSimport.ReportProgress(65, "Check if Parameter:SUSPENCE_ACC_EMAIL are Valid")
                '            '    cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='SUSPENCE_ACC_EMAIL'"
                '            '    Dim result As String = cmd.ExecuteScalar
                '            '    If result = "Y" Then
                '            '        Me.BgwOCBSimport.ReportProgress(70, "Parameter:SUSPENCE_ACC_EMAIL is Valid - Check Suspence Balances in Euro and create E-Mail")
                '            '        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='SUSPENCE_ACC_EMAIL' and  [PARAMETER1]='Email'"
                '            '        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                '            '        dt3 = New DataTable()
                '            '        da3.Fill(dt3)

                '            '        Dim EMAIL_USERS As String = ""
                '            '        For i1 = 0 To dt3.Rows.Count - 1
                '            '            EMAIL_USERS += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                '            '        Next
                '            '        dt3.Clear()


                '            '        Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
                '            '        Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
                '            '        Dim outApp As Microsoft.Office.Interop.Outlook.Application


                '            '        outApp = New Microsoft.Office.Interop.Outlook.Application

                '            '        NSpace = outApp.GetNamespace("MAPI")
                '            '        Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
                '            '        EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                '            '        EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

                '            '        EItem.To = EMAIL_USERS


                '            '        EItem.Subject = "Credit Department Suspence Accounts with closing Ledger Balance < 0 on " & rd
                '            '        EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain
                '            '        Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"
                '            '        Dim EMAIL_TEXT As String = ""
                '            '        Dim myBuilder As New StringBuilder

                '            '        EMAIL_TEXT = "Credit Department Suspence Accounts with closing Ledger Balance < 0 on " & rd
                '            '        myBuilder.Append("Suspence Account:     " & "Ledger Balance in EURO:  " & vbNewLine)
                '            '        For y = 0 To dt1.Rows.Count - 1
                '            '            Dim Balance As Double = dt1.Rows.Item(y).Item("Ledger_Balance")
                '            '            Dim SuspenceAcc As String = dt1.Rows.Item(y).Item("Suspence_Acc_Nr")
                '            '            myBuilder.Append(SuspenceAcc & "               " & FormatNumber(Balance, 2) & vbNewLine)
                '            '        Next
                '            '        EItem.Body = StrBody1 & vbNewLine & vbNewLine & EMAIL_TEXT & vbNewLine & vbNewLine & myBuilder.ToString
                '            '        EItem.Display()

                '            '        'EItem.Send()

                '            '    Else
                '            '        Me.BgwOCBSimport.ReportProgress(95, "Parameter:SUSPENCE_ACC_EMAIL  is not Valid")
                '            '    End If



                '            'Else
                '            '    Me.BgwOCBSimport.ReportProgress(100, "There are no Suspence Accounts in Parameter:CREDIT\SUSPENCE_ACC_EMAIL")
                '            'End If


                '            Me.BgwOCBSimport.ReportProgress(12, "IMPORT SUSPENCE BALANACES finished sucesfully")
                '        Else
                '            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                '        End If


                '    Else

                '        Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                '    End If


                '    Else
                '        Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table SUSPENCE_BALANCES")
                '    End If

                Else
                    Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT SUSPENCE BALANCES is not Valid+++")
                End If


                Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_SUSPENCE_BALANCES_NEW()
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

                cmd.CommandText = "DELETE FROM [SUSPENCE_BALANCES] WHERE [BalanceDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                'Dim AV As String = cmd.ExecuteScalar


                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\DD-D-060 - Suspense Account Balance-en.xls"
                If File.Exists(ExcelFileName) = True Then
                    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \DD-D-060 - Suspense Account Balance-en.xls")
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                    EXCELL.Visible = False

                    'Prüfen ob Daten vorhanden sind
                    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("Suspense Account Balance") = True Then

                        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                        'Unmerge Cells
                        'xlWorksheet1.Columns("A:A").unMerge()
                        xlWorksheet1.Rows("1:4").delete()
                        xlWorksheet1.Range("B1").Value = "Suspence_Acc_Nr"
                        xlWorksheet1.Range("C1").Value = "Suspence_Acc_Name"
                        xlWorksheet1.Range("D1").Value = "Currency"
                        xlWorksheet1.Range("K1").Value = "Ledger_Balance"

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
                        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \DD-D-060 - Suspense Account Balance-en.xls")

                        'Importieren in dem SQL SERVER
                        Me.BgwOCBSimport.ReportProgress(7, "Start entries Import to table")
                        cmd.CommandText = "INSERT INTO [SUSPENCE_BALANCES]([Suspence_Acc_Nr],[Currency],[Ledger_Balance],[BalanceDate]) SELECT [Suspence_Acc_Nr],[Currency],[Ledger_Balance],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Suspence_Acc_Nr],[Currency],[Ledger_Balance] FROM [Sheet1$] where [Ledger_Balance] is not NULL') "
                        cmd.ExecuteNonQuery()
                        'Count Imported Rows
                        cmd.CommandText = "SELECT Count(*) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [Suspence_Acc_Nr],[Suspence_Acc_Name],[Currency],[Ledger_Balance] FROM [Sheet1$] where [Ledger_Balance] is not NULL')"
                        Me.BgwOCBSimport.ReportProgress(7, cmd.ExecuteScalar & " rows imported in SUSPENCE_BALANCES")

                        'UPDATE GL ACCOUNT NAMES IN ALL VOLUMES
                        cmd.CommandText = "DELETE FROM [SUSPENCE_BALANCES] where [Suspence_Acc_Nr] is NULL and [BalanceDate]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()

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
                        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++ Procedure:" & CURRENT_PROC & " - Wrong Format in Excel File")
                    End If


                Else

                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
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
    End Sub 'TEST----------------------------

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
                'Dim ExcelFileName As String = ""
                'ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-249 - General Ledger Journal List-en.xls"
                'If File.Exists(ExcelFileName) = True Then
                '    Me.BgwOCBSimport.ReportProgress(2, "Start reformating Excel File: \AI-D-249 - General Ledger Journal List-en.xls")
                '    'Excel Datei Öffnen und Datenformat ändern
                '    EXCELL = CreateObject("Excel.Application")
                '    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                '    xlWorksheet1 = xlWorkBook.Worksheets.Item(1)
                '    EXCELL.Visible = False

                '    'Prüfen ob Daten vorhanden sind
                '    If xlWorksheet1.Range("D2").Value.ToString.StartsWith("General Ledger Journal List") = True Then
                '        Dim VolumeDate As String = Replace(Trim(Replace(xlWorksheet1.Range("E3").Value, "As Of", "")), "/", "")
                '        'Risk Date definieren
                '        'rd = DateSerial(Microsoft.VisualBasic.Right(VolumeDate, 4), Mid(VolumeDate, 3, 2), Microsoft.VisualBasic.Left(VolumeDate, 2))
                '        'Dim rdsql As String = rd.ToString("yyyyMMdd")
                '        Me.BgwOCBSimport.ReportProgress(3, "Booking Date defined as " & rd)

                '        'Unmerge Cells
                '        xlWorksheet1.Columns("A:A").unMerge()
                '        xlWorksheet1.Rows("1:6").delete()
                '        xlWorksheet1.Range("A1").Value = "BatchNo"
                '        xlWorksheet1.Range("B1").Value = "SequenceNo"
                '        xlWorksheet1.Range("E1").Value = "GL_AC_No"
                '        xlWorksheet1.Range("H1").Value = "AccountNo"
                '        xlWorksheet1.Range("N1").Value = "DR_CR"
                '        xlWorksheet1.Range("O1").Value = "GroupNo"
                '        xlWorksheet1.Range("P1").Value = "ClientNo"
                '        xlWorksheet1.Range("T1").Value = "ChequeNo"
                '        xlWorksheet1.Range("AC1").Value = "GL_Rep_Date"
                '        xlWorksheet1.Columns("AC:AC").numberformat = "yyyymmdd"
                '        xlWorksheet1.Range("AD1").Value = "GL_Item_Nr"
                '        xlWorksheet1.Range("AE1").Value = "GL_AC_No_Name"
                '        xlWorksheet1.Range("AF1").Value = "Exchange_Rate"
                '        xlWorksheet1.Range("AG1").Value = "AmountInEuro"

                '        EXCELL.Application.DisplayAlerts = False
                '        Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\CUSTOMER_VOSTRO_VOLUMES.xls"
                '        xlWorkBook.SaveAs(ExcelFileNameNew, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                '        EXCELL.Application.DisplayAlerts = True
                '        xlWorkBook.Close()

                '        EXCELL.Quit()
                '        EXCELL = Nothing

                '        'Excel Instanz beenden
                '        Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                '        Dim i1 As Short
                '        i1 = 0
                '        For i1 = 0 To (procs.Length - 1)
                '            procs(i1).Kill()
                '        Next i1
                '        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '        Me.BgwOCBSimport.ReportProgress(5, "Excel File: \AI-D-249 - General Ledger Journal List-en.xls reformated sucesfully")

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
                    cmd.CommandText = "INSERT INTO [CUSTOMER_VOSTRO_VOLUMES]([BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],Exchange_Rate,AmountInEuro,[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date]) SELECT [BatchNo],[SequenceNo],[GL Book],[Accounting Centre],[GL_AC_No],[Value Date],[Transaction Time],[AccountNo],[Contract Type],[Product Type],[Event Type],[CCY],[Amount],Exchange_Rate,AmountInEuro,[DR_CR],[GroupNo],[ClientNo],[Portfolio Code],[Narrative Code],[Reference Code],[ChequeNo],[AP],[TRN Accounting Centre],[Checker ID],[Channel],[Other System Key],[Generated Type],[Reversal Flag],[Description],[GL_Rep_Date] FROM ALL_VOLUMES where GL_Rep_Date='" & rdsql & "' and [AccountNo] not in (Select [Client Account] from [CUSTOMER_ACCOUNTS] where [CLOSE_DATE]<'" & rdsql & "') and [GL_AC_No] in ('201074')"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(12, "Insert defined Booking date")
                    'UPDATE CUSTOMER ACCOUNT NAMES IN CUSTOMER_VOLUMES
                    Me.BgwOCBSimport.ReportProgress(13, "Update Customer Account Names in Table CUSTOMER_VOSTRO_VOLUMES")
                    cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name] from [CUSTOMER_VOSTRO_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account]"
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
                    cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] set [ClientNo]=B.[ClientNo], [GL_AC_No_Name]=B.[English Name] from [CUSTOMER_VOSTRO_VOLUMES] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[AccountNo]=B.[Client Account] where [GL_Rep_Date]='" & rdsql & "' and [GL_AC_No_Name] is NULL"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(20, "Extract PAYMENT REFERENCE in CUSTOMER_VOSTRO_VOLUMES")
                    cmd.CommandText = "UPDATE [CUSTOMER_VOSTRO_VOLUMES] SET [PaymentReference]=Substring([Description],0,16) where ([Description] like 'DEI%' or [Description] like 'DEO%') and [GL_Rep_Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(20, "Update Value Balance from CUSTOMER ACC BALANCES")
                    cmd.CommandText = "UPDATE A SET A.[AmountValueBalance]=B.ValueBalance,A.AmountInEuro_ValueBalance=B.ValueBalanceEUR from CUSTOMER_VOSTRO_VOLUMES A INNER JOIN CUSTOMER_ACC_BALANCES B on REPLACE(LTRIM(REPLACE(STR(A.AccountNo,10,0), '0', ' ')), ' ', '0')=REPLACE(LTRIM(REPLACE(B.AccountNo, '0', ' ')), ' ', '0') and A.GL_Rep_Date=B.BalanceDate where A.[GL_Rep_Date]='" & rdsql & "' and A.BatchNo in ('CLOSING BALANCE')"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT CUSTOMER VOSTRO VOLUMES finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(100, "Entries allready exist in Table CUSTOMER_VOSTRO_VOLUMES")
                End If


                'Else
                '    Me.BgwOCBSimport.ReportProgress(100, "ERROR+++Wrong Format in Excel File")
                'End If
                '    Else
                'Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                '    End If
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
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT NOSTRO BALANCES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\IB_R001_DC0070000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \IB_R001_DC0070000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Rows("1:4").delete()
                    'xlWorksheet1.Columns("D:F").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    xlWorksheet1.Range("A1").Value = "Currency"
                    xlWorksheet1.Range("B1").Value = "Nostro Code"
                    xlWorksheet1.Range("C1").Value = "Nostro Name"
                    xlWorksheet1.Range("D1").Value = "AccountStatus"
                    xlWorksheet1.Range("E1").Value = "TheirAccountNo"
                    xlWorksheet1.Range("F1").Value = "AC_Type"
                    xlWorksheet1.Range("G1").Value = "Value Balance"
                    xlWorksheet1.Name = "Sheet1"


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
                    Me.BgwOCBSimport.ReportProgress(35, "Procedure:" & CURRENT_PROC & " - " & "Excel File: \IB_R001_DC0070000_" & rdsql & ".xlsx")

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Delete current Data in Table NOSTRO BALANCES")
                    cmd.CommandText = "DELETE FROM [NOSTRO BALANCES] Where [BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(45, "Procedure:" & CURRENT_PROC & " - " & "Start Import NOSTRO BALANCES to table")
                    cmd.CommandText = "INSERT INTO [NOSTRO BALANCES]([Currency],[Nostro Code],[Nostro Name],[Value Balance],[Ledger Balance],[BalanceDate]) SELECT [Currency],[Nostro Code],[Nostro Name],[Value Balance],0,'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Currency],[Nostro Code],[Nostro Name],[Value Balance] FROM [Sheet1$] where [Currency] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count([Currency]) FROM [Sheet1$]')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in NOSTRO BALANCES")

                    'Exchange Rates importieren
                    Me.BgwOCBSimport.ReportProgress(55, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange Rates in Table: NOSTRO BALANCES")
                    cmd.CommandText = "UPDATE [NOSTRO BALANCES] SET [Exchange_Rate]= 1 WHERE [Currency]='EUR' and [Exchange_Rate] is NULL and [BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A Set A.[Exchange_Rate]=B.[MIDDLE RATE] from [NOSTRO BALANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[Currency]=B.[CURRENCY CODE] and B.[EXCHANGE RATE DATE]=A.[BalanceDate] where A.[Exchange_Rate] is NULL and A.[BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'UMRECHNUNG
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Calculate Balances in Euro for all Nostro Accounts")
                    cmd.CommandText = "UPDATE [NOSTRO BALANCES] SET [Ledger Balance EUR]= 0,[Value Balance EUR]= [Value Balance]/[Exchange_Rate]  where [BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()


                    '----IMPORT NEW NOSTRO ACCOUNTS or UPDATE Current
                    'Create IMPORT NOSTRO ACCOUNTS
                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Create Nostro Account import Table:#Temp_IMPORT_NOSTRO_ACCOUNTS")
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_IMPORT_NOSTRO_ACCOUNTS' AND xtype='U') CREATE TABLE [#Temp_IMPORT_NOSTRO_ACCOUNTS]([ID] [int] IDENTITY(1,1) NOT NULL,[NostroCode] [nvarchar](255) NULL,[Currency] [nvarchar](255) NULL,[NostroName] [nvarchar](255) NULL,[AccountStatus] [nvarchar](255) NULL,[TheirAccountNo] [nvarchar](255) NULL,[AC_Type] [nvarchar](255) NULL)  ELSE DELETE FROM [#Temp_IMPORT_NOSTRO_ACCOUNTS] "
                    cmd.ExecuteNonQuery()
                    'Importieren in dem SQL SERVER
                    Me.BgwOCBSimport.ReportProgress(50, "Procedure:" & CURRENT_PROC & " - " & "Import Nostro Accounts to the Temporary Import Table:#Temp_IMPORT_NOSTRO_ACCOUNTS")
                    cmd.CommandText = "INSERT INTO [#Temp_IMPORT_NOSTRO_ACCOUNTS] ([Currency],[NostroCode],[NostroName],[AccountStatus],[TheirAccountNo],[AC_Type]) SELECT dbo.RemoveAllSpaces([Currency]),dbo.RemoveAllSpaces([Nostro Code]),LEFT([Nostro Name],255),dbo.RemoveAllSpaces([AccountStatus]),dbo.RemoveAllSpaces([TheirAccountNo]),dbo.RemoveAllSpaces([AC_Type]) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [Currency] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(Currency) FROM [Sheet1$] where [Nostro Code] is not NULL')"
                    Me.BgwOCBSimport.ReportProgress(22, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_NOSTRO_ACCOUNTS")
                    'Neuanlage NOSTRO ACCOUNT
                    Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Insert new NOSTRO Account to the Table:SSIS from the #Temp_IMPORT_NOSTRO_ACCOUNTS ")
                    cmd.CommandText = "INSERT INTO [SSIS] ([CURRENCY CODE],[INTERNAL ACCOUNT],[NOSTRO_NAME],[CORRESPONDENT NAME],[EXTERNAL ACCOUNT],[AC_Type]) select [Currency],[NostroCode],[NostroName],[AccountStatus],[TheirAccountNo],[AC_Type] from [#Temp_IMPORT_NOSTRO_ACCOUNTS] where [NostroCode] not in (Select [INTERNAL ACCOUNT] from [SSIS])"
                    cmd.ExecuteNonQuery()
                    'Updates
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Update specific Fields in SSIS from Temporary Table")
                    cmd.CommandText = "UPDATE A SET A.[NOSTRO_NAME]=B.[NostroName] from [SSIS] A INNER JOIN [#Temp_IMPORT_NOSTRO_ACCOUNTS] B on A.[INTERNAL ACCOUNT]=B.[NostroCode]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Update Nostro Validity from Temporary Table")
                    cmd.CommandText = "UPDATE A SET A.[VALID]='N' from [SSIS] A INNER JOIN [#Temp_IMPORT_NOSTRO_ACCOUNTS] B on A.[INTERNAL ACCOUNT]=B.[NostroCode] where B.[AccountStatus] not in ('Normal')"
                    cmd.ExecuteNonQuery()
                    'Currency Name aktualisieren
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Update Currency Name in SSIS ")
                    cmd.CommandText = "UPDATE A SET A.[CURRENCY NAME]=B.[CURRENCY NAME] from [SSIS] A INNER JOIN [OWN_CURRENCIES] B ON A.[CURRENCY CODE]=B.[CURRENCY CODE]"
                    cmd.ExecuteNonQuery()
                    'Löschen IMPORT NOSTRO ACCOUNTS
                    Me.BgwOCBSimport.ReportProgress(95, "Procedure:" & CURRENT_PROC & " - " & "Drop the Temporary Import Table")
                    cmd.CommandText = "DROP TABLE [#Temp_IMPORT_NOSTRO_ACCOUNTS]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Nostro Accounts imported sucesfully")
                    '*************************************************************************************

                    cmd.CommandText = "EXEC msdb.dbo.sp_start_job 'EMAIL_NOSTRO_BALANCES_CHECK'"
                    cmd.ExecuteNonQuery()

                    ''+++++++NEW CODE+++++++++++
                    'QueryText = "SELECT [PARAMETER1],[PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_NOSTRO_ACCOUNTS' GROUP BY [PARAMETER1],[PARAMETER2]"
                    'da = New SqlDataAdapter(QueryText.Trim(), conn)
                    'dt = New DataTable()
                    'da.Fill(dt)
                    'If dt.Rows.Count > 0 Then
                    '    For i = 0 To dt.Rows.Count - 1
                    '        QueryText = "SELECT TOP 2 * FROM [NOSTRO BALANCES] where [Nostro Code] in ('" & dt.Rows.Item(i).Item("PARAMETER2").ToString & "') order by [IdNr] desc"
                    '        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                    '        dt1 = New DataTable()
                    '        da1.Fill(dt1)

                    '        Dim F_Balance As Double = dt1.Rows.Item(0).Item("Value Balance EUR")
                    '        Dim L_Balance As Double = dt1.Rows.Item(1).Item("Value Balance EUR")

                    '        If F_Balance > 1500000 AndAlso L_Balance > 1500000 Then

                    '            'EMAIL NOSTRO RECEIVERS Parameter prüfen
                    '            Me.BgwOCBSimport.ReportProgress(65, "Check if Parameter:EMAIL_NOSTRO_RECEIVERS are Valid")
                    '            cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_NOSTRO_RECEIVERS'"
                    '            Dim result As String = cmd.ExecuteScalar
                    '            If result = "Y" Then
                    '                Me.BgwOCBSimport.ReportProgress(70, "Parameter:EMAIL_NOSTRO_RECEIVERS is Valid - Check Nostro Balances in Euro and create E-Mail")
                    '                QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_NOSTRO_RECEIVERS'"
                    '                da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                    '                dt3 = New DataTable()
                    '                da3.Fill(dt3)

                    '                Dim EMAIL_USERS As String = ""
                    '                For i1 = 0 To dt3.Rows.Count - 1
                    '                    EMAIL_USERS += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                    '                Next
                    '                dt3.Clear()

                    '                'CC to
                    '                QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='EMAIL_NOSTRO_RECEIVERS_CC'"
                    '                da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                    '                dt3 = New DataTable()
                    '                da3.Fill(dt3)
                    '                Dim EMAIL_USERS_CC As String = ""
                    '                For i1 = 0 To dt3.Rows.Count - 1
                    '                    EMAIL_USERS_CC += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                    '                Next

                    '                Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
                    '                Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
                    '                Dim outApp As Microsoft.Office.Interop.Outlook.Application


                    '                outApp = New Microsoft.Office.Interop.Outlook.Application

                    '                NSpace = outApp.GetNamespace("MAPI")
                    '                Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
                    '                EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                    '                EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

                    '                EItem.To = EMAIL_USERS
                    '                EItem.CC = EMAIL_USERS_CC

                    '                EItem.Subject = "Nostro Account " & dt.Rows.Item(i).Item("PARAMETER1").ToString.ToUpper & "  Account Nr." & dt.Rows.Item(i).Item("PARAMETER2") & " closing Value Balance higher than EUR 1.500.000,00 in the last 2 Business Days"
                    '                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain
                    '                Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"
                    '                Dim EMAIL_TEXT As String = ""
                    '                Dim myBuilder As New StringBuilder
                    '                Me.BgwOCBSimport.ReportProgress(85, "Nostro Balance " & dt.Rows.Item(i).Item("PARAMETER1") & "  Account Nr." & dt.Rows.Item(i).Item("PARAMETER2") & " over EUR 1.500.000,00")

                    '                EMAIL_TEXT = "Nostro Balance " & dt.Rows.Item(i).Item("PARAMETER1").ToString.ToUpper & "  Account Nr." & dt.Rows.Item(i).Item("PARAMETER2") & " in the last 2 Business Days"
                    '                myBuilder.Append("Balance Date:     " & "Value Balance in EURO:  " & vbNewLine)
                    '                For y = 0 To dt1.Rows.Count - 1
                    '                    Dim Balance As Double = dt1.Rows.Item(y).Item("Value Balance EUR")
                    '                    Dim BalanceDate As Date = dt1.Rows.Item(y).Item("BalanceDate")
                    '                    myBuilder.Append(BalanceDate.ToString("dd.MM.yyyy") & "        " & FormatNumber(Balance, 2) & vbNewLine)
                    '                Next
                    '                EItem.Body = StrBody1 & vbNewLine & vbNewLine & EMAIL_TEXT & vbNewLine & vbNewLine & myBuilder.ToString
                    '                EItem.Send()

                    '            Else
                    '                Me.BgwOCBSimport.ReportProgress(95, "Parameter:EMAIL_NOSTRO_RECEIVERS is not Valid")
                    '            End If

                    '        End If
                    '    Next
                    'Else
                    '    Me.BgwOCBSimport.ReportProgress(100, "There are no Nostro Accounts in Parameter:REPORT\EMAIL_NOSTRO_ACCOUNTS")
                    'End If

                        Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT NOSTRO BALANCES finished sucesfully")



                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT NOSTRO BALANCES is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_OPENED_CLOSED_ACCOUNTS()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "ACCOUNTS OPENED CLOSED"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='ACCOUNTS OPENED CLOSED' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: ACCOUNTS OPENED CLOSED")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\A0181FS07_DC0070000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \A0181FS07_DC0070000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Rows("1:4").delete()
                    'xlWorksheet1.Columns("C:D").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    'xlWorksheet1.Range("A1").Value = "ClientNo"
                    'xlWorksheet1.Range("B1").Value = "ClientName"
                    'xlWorksheet1.Range("C1").Value = "AccountNo"
                    'xlWorksheet1.Range("D1").Value = "AccountType"
                    'xlWorksheet1.Range("E1").Value = "Currency"
                    'xlWorksheet1.Range("F1").Value = "AvailableBalance"
                    'xlWorksheet1.Range("G1").Value = "LedgerBalance"
                    'xlWorksheet1.Range("H1").Value = "ValueBalance"
                    'xlWorksheet1.Range("I1").Value = "CR_Interest"
                    'xlWorksheet1.Range("J1").Value = "DR_Interest"
                    'xlWorksheet1.Columns("F:J").numberformat = "#,##0.00"
                    'xlWorksheet1.Name = "Sheet1"
                    xlWorksheet1 = xlWorkBook.Worksheets(2)
                    xlWorksheet1.Rows("1:4").delete()

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
                    'Me.BgwOCBSimport.ReportProgress(35, "Excel File: \A0181FS15_DC0070000_" & rdsql & ".xlsx")
                    'cmd.CommandText = "DELETE FROM [CUSTOMER_ACC_BALANCES] where [BalanceDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()

                    'Me.BgwOCBSimport.ReportProgress(45, "Start Import CUSTOMER BALANCES to table")
                    'cmd.CommandText = "INSERT INTO [CUSTOMER_ACC_BALANCES]([ClientNo],[ClientName],[AccountNo],[AccountType],[Currency],[AvailableBalance],[LedgerBalance],[ValueBalance],CR_Interest,DR_Interest,[BalanceDate]) SELECT [ClientNo],UPPER([ClientName]),[AccountNo],[AccountType],[Currency],[AvailableBalance],[LedgerBalance],[ValueBalance],CR_Interest,DR_Interest,'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]') where ISNUMERIC([ClientNo])=1"
                    'cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT Count(*) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [OPENED_1$]') where ISNUMERIC([Account no])=1"
                    Dim Acc_Opened As Double = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT Count(*) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [CLOSED_2$]') where ISNUMERIC([Account no])=1"
                    Dim Acc_Closed As Double = cmd.ExecuteScalar
                    If Acc_Opened <> 0 Then
                        Me.BgwOCBSimport.ReportProgress(45, "Procedure:" & CURRENT_PROC & " - " & "Insert " & Acc_Opened & " new Current Accounts to table CUSTOMER_ACCOUNTS")
                        cmd.CommandText = "INSERT INTO [CUSTOMER_ACCOUNTS]([ClientNo],[Client Account],[ClientAccountDomestic],[Deal Currency],[Account Status],[Online],[English Name],[Currency Status],[OPEN_DATE])SELECT [Client No#],[Account no],[Account no],[CCY],'A - ACTIVE','N',[Account Name],'O - OPEN',[Date Account Opened] FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [OPENED_1$]') where ISNUMERIC([Account no])=1 and [Account no] not in (Select [Client Account] from CUSTOMER_ACCOUNTS)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Acc_Closed <> 0 Then
                        Me.BgwOCBSimport.ReportProgress(45, "Procedure:" & CURRENT_PROC & " - " & "Set Account Status to CLOSED for " & Acc_Closed & " Current Accounts to table CUSTOMER_ACCOUNTS")
                        cmd.CommandText = "UPDATE A SET A.[Account Status]='C - CLOSE',A.[Currency Status]='C - CLOSE',A.CLOSE_DATE=B.[Date Account Closed] FROM CUSTOMER_ACCOUNTS A INNER JOIN OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & ExcelFileName & ";', 'SELECT * FROM [CLOSED_2$]') B ON A.[Client Account] = B.[Account no] and A.ClientNo=B.[Client No#] where ISNUMERIC([Account no])=1 and [Account no] in (Select [Client Account] from CUSTOMER_ACCOUNTS)"
                        cmd.ExecuteNonQuery()
                        'cmd.CommandText = "EXEC msdb.dbo.sp_start_job 'Open_Closed_Accounts'"
                        'cmd.ExecuteNonQuery()
                    End If

                    'Me.BgwOCBSimport.ReportProgress(7, cmd.ExecuteScalar & " rows imported in CUSTOMER BALANCES")
                    ''Exchange Rates importieren
                    'Me.BgwOCBSimport.ReportProgress(55, "Insert Exchange Rates in Table: CUSTOMER BALANCES")
                    'cmd.CommandText = "UPDATE A Set A.[ExchangeRate]=B.[MIDDLE RATE] from [CUSTOMER_ACC_BALANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[Currency]=B.[CURRENCY CODE] and B.[EXCHANGE RATE DATE]=A.[BalanceDate] where  A.[BalanceDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()
                    ''UMRECHNUNG
                    'Me.BgwOCBSimport.ReportProgress(60, "Calculate Balances in Euro for all  Accounts")
                    'cmd.CommandText = "UPDATE [CUSTOMER_ACC_BALANCES] SET [AvailableBalanceEUR]=ROUND([AvailableBalance]/[ExchangeRate],2),[LedgerBalanceEUR]=ROUND([LedgerBalance]/[ExchangeRate],2),[ValueBalanceEUR]=ROUND([ValueBalance]/[ExchangeRate],2),[CR_InterestEUR]= ROUND([CR_Interest]/[ExchangeRate],2),[DR_InterestEUR]=ROUND([DR_Interest]/[ExchangeRate],2)  where [BalanceDate]='" & rdsql & "'"
                    'cmd.ExecuteNonQuery()


                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: ACCOUNTS OPENED CLOSED finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: ACCOUNTS OPENED CLOSED is not Valid+++")
            End If

            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_CUSTOMER_BALANCES()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT CUSTOMER BALANCES"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT CUSTOMER BALANCES' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT CUSTOMER BALANCES")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\A0181FS15_DC0070000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \A0181FS15_DC0070000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Rows("1:3").delete()
                    xlWorksheet1.Columns("C:E").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)
                    xlWorksheet1.Range("A1").Value = "ClientNo"
                    xlWorksheet1.Range("B1").Value = "ClientName"
                    xlWorksheet1.Range("C1").Value = "AccountNo"
                    xlWorksheet1.Range("D1").Value = "AccountType"
                    xlWorksheet1.Range("E1").Value = "Currency"
                    xlWorksheet1.Range("F1").Value = "AvailableBalance"
                    xlWorksheet1.Range("G1").Value = "LedgerBalance"
                    xlWorksheet1.Range("H1").Value = "ValueBalance"
                    xlWorksheet1.Range("I1").Value = "CR_Interest"
                    xlWorksheet1.Range("J1").Value = "DR_Interest"
                    xlWorksheet1.Columns("F:J").numberformat = "#,##0.00"
                    xlWorksheet1.Name = "Sheet1"

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
                    Me.BgwOCBSimport.ReportProgress(35, "Procedure:" & CURRENT_PROC & " - " & "Excel File: \A0181FS15_DC0070000_" & rdsql & ".xlsx")
                    cmd.CommandText = "DELETE FROM [CUSTOMER_ACC_BALANCES] where [BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(45, "Procedure:" & CURRENT_PROC & " - " & "Start Import CUSTOMER BALANCES to table")
                    cmd.CommandText = "INSERT INTO [CUSTOMER_ACC_BALANCES]([ClientNo],[ClientName],[AccountNo],[AccountType],[Currency],[AvailableBalance],[LedgerBalance],[ValueBalance],CR_Interest,DR_Interest,[BalanceDate]) SELECT [ClientNo],UPPER([ClientName]),[AccountNo],[AccountType],[Currency],[AvailableBalance],[LedgerBalance],[ValueBalance],CR_Interest,DR_Interest,'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]') where ISNUMERIC([ClientNo])=1"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count([Currency]) FROM [Sheet1$]')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in CUSTOMER BALANCES")
                    'Exchange Rates importieren
                    Me.BgwOCBSimport.ReportProgress(55, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange Rates in Table: CUSTOMER BALANCES")
                    cmd.CommandText = "UPDATE A Set A.[ExchangeRate]=B.[MIDDLE RATE] from [CUSTOMER_ACC_BALANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[Currency]=B.[CURRENCY CODE] and B.[EXCHANGE RATE DATE]=A.[BalanceDate] where  A.[BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'UMRECHNUNG
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Calculate Balances in Euro for all  Accounts")
                    cmd.CommandText = "UPDATE [CUSTOMER_ACC_BALANCES] SET [AvailableBalanceEUR]=ROUND([AvailableBalance]/[ExchangeRate],2),[LedgerBalanceEUR]=ROUND([LedgerBalance]/[ExchangeRate],2),[ValueBalanceEUR]=ROUND([ValueBalance]/[ExchangeRate],2),[CR_InterestEUR]= ROUND([CR_Interest]/[ExchangeRate],2),[DR_InterestEUR]=ROUND([DR_Interest]/[ExchangeRate],2)  where [BalanceDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                       

                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: IMPORT CUSTOMER BALANCES finished sucesfully")
                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure: IMPORT CUSTOMER BALANCES is not Valid+++")
            End If

            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT TRIAL BALANCE 218' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT TRIAL BALANCE 218")

                Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read("\\ccb-nft\NFT_DATA\SMIS_REPORT_ALL_" & rdsql & "_710030000.zip")
                    Dim z As Ionic.Zip.ZipEntry
                    For Each z In zip
                        If z.FileName.EndsWith(".xls") = True OrElse z.FileName.EndsWith(".xlsx") = True Then
                            z.Extract(Me.OCBS_Temp_Directory, ExtractExistingFileAction.OverwriteSilently)
                        End If
                    Next
                End Using

                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-218_" & rdsql & "_710030000_tbl.xls"

                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Import File: ...\AI-D-218_" & rdsql & "_710030000_tbl.xls")



                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \AI-D-218_" & rdsql & "_710030000_tbl.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False

                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Reformating Worksheet:Page-3")
                    xlWorksheet1 = xlWorkBook.Worksheets(3) 'Worksheet 3 - Report Data
                    xlWorksheet1.Rows("1:1").delete()
                    xlWorksheet1.Range("A1").Value = "AccountNo"
                    xlWorksheet1.Range("B1").Value = "AccountName"
                    xlWorksheet1.Range("C1").Value = "EUR"
                    xlWorksheet1.Range("D1").Value = "USDequEUR"
                    xlWorksheet1.Range("E1").Value = "CNYequEUR"
                    xlWorksheet1.Range("F1").Value = "OtherCurrequEUR"
                    xlWorksheet1.Range("G1").Value = "Totals"
                   


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
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Excel File: \AI-D-218_" & rdsql & "_710030000_tbl.xls reformated sucesfully")
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Delete existing Data in Table:TRIAL_BALANCE_218")
                    cmd.CommandText = "DELETE FROM [TRIAL_BALANCE_218] Where [RepDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Daten importieren 
                    Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Start Import Data to table")
                    cmd.CommandText = "INSERT INTO [TRIAL_BALANCE_218]([AccountNo],[AccountName],[EUR],[USDequEUR],[CNYequEUR],[OtherCurrequEUR],[Totals],[RepDate]) SELECT 'AccountNo'=Case when ISNUMERIC([AccountNo])=1 then [AccountNo] else NULL end,[AccountName],[EUR],[USDequEUR],[CNYequEUR],[OtherCurrequEUR],[Totals],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [AccountNo],[AccountName],[EUR],[USDequEUR],[CNYequEUR],[OtherCurrequEUR],[Totals] FROM [Page-3$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [Page-3$]')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in TRIAL_BALANCE_218")

                    Me.BgwOCBSimport.ReportProgress(10, "Import procedure: IMPORT TRIAL BALANCE 218 is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT TRIAL BALANCE 218 is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_TRIAL_BALANCE_217()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT TRIAL BALANCE 217"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT TRIAL BALANCE 217' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT TRIAL BALANCE 217")

                Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read("\\ccb-nft\NFT_DATA\SMIS_REPORT_ALL_" & rdsql & "_710030000.zip")
                    Dim z As Ionic.Zip.ZipEntry
                    For Each z In zip
                        If z.FileName.EndsWith(".xls") = True OrElse z.FileName.EndsWith(".xlsx") = True Then
                            z.Extract(Me.OCBS_Temp_Directory, ExtractExistingFileAction.OverwriteSilently)
                        End If
                    Next
                End Using

                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-217_" & rdsql & "_710030000_tbl.xls"


                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \AI-D-217_" & rdsql & "_710030000_tbl.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(30, "Procedure:" & CURRENT_PROC & " - " & "Define Report Date from Worksheet:Page-3")


                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Reformating Worksheet:Page-3")
                    xlWorksheet1 = xlWorkBook.Worksheets(3) 'Worksheet 3 - Report Data
                    xlWorksheet1.Rows("1:1").delete()
                    xlWorksheet1.Range("A1").Value = "AccountNo"
                    xlWorksheet1.Range("B1").Value = "AccountName"
                    xlWorksheet1.Range("C1").Value = "CCY"
                    xlWorksheet1.Range("D1").Value = "PreviousMonth"
                    xlWorksheet1.Range("E1").Value = "CurrentMonth"
                    xlWorksheet1.Range("F1").Value = "YTD_Total"
                    xlWorksheet1.Range("G1").Value = "Rate"
                    xlWorksheet1.Range("H1").Value = "YTD_Total_EUR _equ"
                   

                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\TRIALBALANCE_217_Formated.xls"
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
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Excel File: \AI-D-217_" & rdsql & "_710030000_tbl.xls reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Check if Data allready exist in Table:TRIAL_BALANCE_217 and delete them")
                    cmd.CommandText = "DELETE FROM [TRIAL_BALANCE_217] Where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Start Import Data to table")
                    cmd.CommandText = "INSERT INTO [TRIAL_BALANCE_217] ([AccountNo],[AccountName],[CCY],[PreviousMonth],[CurrentMonth],[YTD_Total],[Rate],[YTD_Total_EUR _equ],[RiskDate])SELECT 'AccountNo'=Case when ISNUMERIC([AccountNo])=1 then [AccountNo] else NULL end,[AccountName],[CCY],[PreviousMonth],[CurrentMonth],[YTD_Total],[Rate],[YTD_Total_EUR _equ],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [AccountNo],[AccountName],[CCY],[PreviousMonth],[CurrentMonth],[YTD_Total],[Rate],[YTD_Total_EUR _equ] FROM [Page-3$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [Page-3$]')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in TRIAL_BALANCE_217")


                    Me.BgwOCBSimport.ReportProgress(90, "Procedure:" & CURRENT_PROC & " - " & "Update GL Art and GL Item Number from DailyBalanceSheetDetails")
                    cmd.CommandText = "Update A Set A.GL_Art=B.GL_Art,A.GL_Item_Number=B.GL_Item_Number from [TRIAL_BALANCE_217] A INNER JOIN DailyBalanceDetailsSheets B ON A.AccountNo=B.GL_Account_Nr and A.CCY=B.Orig_CUR and A.RiskDate=B.BSDate where A.RiskDate='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(10, "Import procedure: IMPORT TRIAL BALANCE 217 is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                        Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT TRIAL BALANCE 217 is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_TRIAL_BALANCE_222()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT TRIAL BALANCE 222"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT TRIAL BALANCE 222' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT TRIAL BALANCE 222")

                Using zip As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read("\\ccb-nft\NFT_DATA\SMIS_REPORT_ALL_" & rdsql & "_710030000.zip")
                    Dim z As Ionic.Zip.ZipEntry
                    For Each z In zip
                        If z.FileName.EndsWith(".xls") = True OrElse z.FileName.EndsWith(".xlsx") = True Then
                            z.Extract(Me.OCBS_Temp_Directory, ExtractExistingFileAction.OverwriteSilently)
                        End If
                    Next
                End Using

                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\AI-D-222_" & rdsql & "_710030000_tbl.xls"


                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \AI-D-222_" & rdsql & "_710030000_tbl.xls")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False
                    Me.BgwOCBSimport.ReportProgress(30, "Procedure:" & CURRENT_PROC & " - " & "Define Report Date from Worksheet:Page-3")


                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Reformating Worksheet:Page-3")
                    xlWorksheet1 = xlWorkBook.Worksheets(3) 'Worksheet 3 - Report Data
                    xlWorksheet1.Rows("1:1").delete()
                    xlWorksheet1.Range("A1").Value = "AccountNo"
                    xlWorksheet1.Range("B1").Value = "AccountName"
                    xlWorksheet1.Range("D1").Value = "USDequEUR"
                    xlWorksheet1.Range("E1").Value = "OtherCurrequEUR"
                    xlWorksheet1.Range("F1").Value = "Totals"


                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\TRIALBALANCE_222_Formated.xls"
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
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Excel File: \AI-D-222_" & rdsql & "_710030000_tbl.xls reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Check if Data allready exist in Table:TRIAL_BALANCE_222 and delete them")
                    cmd.CommandText = "DELETE FROM [TRIAL_BALANCE_222] Where [RepDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Start Import Data to table")
                    cmd.CommandText = "INSERT INTO [TRIAL_BALANCE_222] ([AccountNo],[AccountName],[EUR],[USDequEUR],[OtherCurrequEUR],[Totals],[RepDate])SELECT 'AccountNo'=Case when ISNUMERIC([AccountNo])=1 then [AccountNo] else NULL end,[AccountName],[EUR],[USDequEUR],[OtherCurrequEUR],[Totals],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT [AccountNo],[AccountName],[EUR],[USDequEUR],[OtherCurrequEUR],[Totals] FROM [Page-3$]')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [Page-3$]')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in TRIAL_BALANCE_222")




                    Me.BgwOCBSimport.ReportProgress(10, "Import procedure: IMPORT TRIAL BALANCE 222 is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)
                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT TRIAL BALANCE 222 is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub OCBS_IMPORT_CL_DRAWDOWN_OUTSTANDING()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "IMPORT CL DRAWDON OUTSTANDING"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

           
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='IMPORT CL DRAWDON OUTSTANDING' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: IMPORT CL DRAWDON OUTSTANDING")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\A021198D0_DC0070000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(20, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \A021198D0_DC0070000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                    EXCELL.Visible = False

                    Me.BgwOCBSimport.ReportProgress(40, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File: \A021198D0_DC0070000_" & rdsql & ".xlsx")
                    'Rows delete
                    xlWorksheet1.Rows("1:4").delete()
                    xlWorksheet1.Range("A1").Value = "Product Type"
                    xlWorksheet1.Range("B1").Value = "Product Type Code"
                    xlWorksheet1.Range("C1").Value = "Offshore_Onshore"
                    xlWorksheet1.Range("D1").Value = "CreditContractNr"
                    xlWorksheet1.Range("E1").Value = "ShareCode"
                    xlWorksheet1.Range("F1").Value = "ProductSerialNr"
                    xlWorksheet1.Range("G1").Value = "Currency"
                    xlWorksheet1.Range("H1").Value = "Commitment No"
                    xlWorksheet1.Range("I1").Value = "Contract No"
                    xlWorksheet1.Range("J1").Value = "ContractType"
                    xlWorksheet1.Range("K1").Value = "Counterparty"
                    xlWorksheet1.Range("L1").Value = "Client No"
                    'xlWorksheet1.Range("M1").Value = "RepDate"
                    'xlWorksheet1.Range("N1").Value = "RepCreationDate"
                    xlWorksheet1.Range("O1").Value = "Contract Start Date"
                    xlWorksheet1.Range("P1").Value = "Start Date"
                    xlWorksheet1.Range("Q1").Value = "Maturity Date"
                    xlWorksheet1.Range("R1").Value = "Next Rollover"
                    xlWorksheet1.Range("S1").Value = "Commitment Expiry Date"
                    xlWorksheet1.Range("T1").Value = "Outstanding Principal"
                    xlWorksheet1.Range("U1").Value = "Overdue Principal"
                    xlWorksheet1.Range("V1").Value = "Interest Rate"
                    xlWorksheet1.Range("W1").Value = "NetYieldRate"
                    xlWorksheet1.Range("X1").Value = "Total Interest"
                    xlWorksheet1.Range("Y1").Value = "AccIntTo-Date"
                    xlWorksheet1.Range("Z1").Value = "DefIntTo-Date"
                    xlWorksheet1.Range("AA1").Value = "Overdue Int To-Date"
                    xlWorksheet1.Range("AB1").Value = "OverdueIntT0_Date"
                    xlWorksheet1.Range("AC1").Value = "TotalDiscountInterest"
                    xlWorksheet1.Range("AD1").Value = "InterestAmortized"
                    xlWorksheet1.Range("AE1").Value = "InterestNotAmortized"
                    xlWorksheet1.Range("AF1").Value = "Booking Centre"
                    xlWorksheet1.Range("AG1").Value = "Purpose"
                    'xlWorksheet1.Range("AH1").Value = "Overdue Int Rate"
                    'xlWorksheet1.Range("AI1").Value = "Base rate (ie Cost of Fund Rate)"
                    'xlWorksheet1.Range("AJ1").Value = "Revolving_Non Revolving flag"
                    'xlWorksheet1.Range("AK1").Value = "Client No"
                    'xlWorksheet1.Range("AL1").Value = "GL Master No"
                    'xlWorksheet1.Range("AM1").Value = "RepDate"
                    'xlWorksheet1.Range("AN1").Value = "RepCreationDate"
                    'xlWorksheet1.Range("AO1").Value = "RepCreationDate"
                    xlWorksheet1.Range("AP1").Value = "Our Receive A/C"
                    xlWorksheet1.Range("AQ1").Value = "Base rate (ie Cost of Fund Rate)"
                    xlWorksheet1.Range("AR1").Value = "Add on rate"
                    xlWorksheet1.Range("AS1").Value = "Revolving_Non Revolving flag"
                    xlWorksheet1.Range("AT1").Value = "Commited_Uncommited"
                    xlWorksheet1.Range("AU1").Value = "Syndication_Bilateral"
                    xlWorksheet1.Range("AV1").Value = "GL Master No"
                    xlWorksheet1.Range("AW1").Value = "NextRepricingDate"
                    xlWorksheet1.Range("AX1").Value = "InterestBaseMemo"
                    'xlWorksheet1.Range("AY1").Value = "RepCreationDate"
                    'xlWorksheet1.Range("AZ1").Value = "RepCreationDate"
                    'xlWorksheet1.Range("BA1").Value = "RepCreationDate"
                    xlWorksheet1.Columns("T:AE").numberformat = "#,##0.000000"
                    xlWorksheet1.Columns("AC:AE").numberformat = "#,##0.00"
                    xlWorksheet1.Columns("AH:AN").numberformat = "#,##0.00"
                    xlWorksheet1.Columns("AQ:AR").numberformat = "#,##0.000000"
                    xlWorksheet1.Name = "Sheet1"

                    EXCELL.Application.DisplayAlerts = False
                    Dim ExcelFileNameNew As String = Me.OCBS_Temp_Directory & "\CL_DRAWDOWN_Formated.xlsx"
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
                    Me.BgwOCBSimport.ReportProgress(60, "Procedure:" & CURRENT_PROC & " - " & "Excel File: A021198D0_DC0070000_" & rdsql & ".xlsx reformated sucesfully")
                    'Prüfen ob daten vorhanden sind (in IMPORT TABELLE)
                    Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Check if Data allready exist in Table:CL_DRAWDON_OUTSTANDING")
                    cmd.CommandText = "SELECT distinct [RepDate] FROM [CL_DRAWDOWN_OUTSTANDING] Where [RepDate]='" & rdsql & "'"
                    Dim t2 As String = cmd.ExecuteScalar()
                    If IsNothing(t2) = False Then
                        Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Data allready exist in Table:CL_DRAWDON_OUTSTANDING-Import aborted")
                    Else
                        'Daten importieren 
                        Me.BgwOCBSimport.ReportProgress(80, "Procedure:" & CURRENT_PROC & " - " & "Start Import Data to table")
                        cmd.CommandText = "INSERT INTO [CL_DRAWDOWN_OUTSTANDING] ([Product Type],[Product Type Code],[Offshore_Onshore],[CreditContractNr],[ShareCode],[ProductSerialNr],[Currency],[Commitment No],[Contract No],[ContractType],[Counterparty],[Client No],[Contract Start Date],[Start Date],[Maturity Date],[Next Rollover],[Commitment Expiry Date],[Outstanding Principal],[Overdue Principal],[Interest Rate],[NetYieldRate],[Total Interest],[AccIntTo-Date],[DefIntTo-Date],[Overdue Int To-Date],[OverdueIntT0_Date],[TotalDiscountInterest],[InterestAmortized],[InterestNotAmortized],[Purpose],[Our Receive A/C],[Base rate (ie Cost of Fund Rate)],[Add on rate],[Revolving_Non Revolving flag],[Commited_Uncommited],[Syndication_Bilateral],[GL Master No],[NextRepricingDate],[InterestBaseMemo],[Booking Centre],[RepDate]) SELECT [Product Type],[Product Type Code],[Offshore_Onshore],[CreditContractNr],[ShareCode],[ProductSerialNr],[Currency],[Commitment No],[Contract No],[ContractType],[Counterparty],[Client No],CONVERT(Datetime,[Contract Start Date],104),CONVERT(Datetime,[Start Date],104),CONVERT(Datetime,[Maturity Date],104),'Next Rollover'=CASE when [Next Rollover] is not NULL then CONVERT(Datetime,[Next Rollover],104) else NULL end,CONVERT(Datetime,[Commitment Expiry Date],104),CONVERT(Float,[Outstanding Principal]),CONVERT(Float,[Overdue Principal]),CONVERT(Float,[Interest Rate]),CONVERT(Float,[NetYieldRate]),CONVERT(Float,[Total Interest]),CONVERT(Float,[AccIntTo-Date]),CONVERT(Float,[DefIntTo-Date]),CONVERT(Float,[Overdue Int To-Date]),CONVERT(Float,[OverdueIntT0_Date]),CONVERT(Float,[TotalDiscountInterest]),CONVERT(Float,[InterestAmortized]),CONVERT(Float,[InterestNotAmortized]),[Purpose],[Our Receive A/C],CONVERT(Float,[Base rate (ie Cost of Fund Rate)]),CONVERT(Float,[Add on rate]),[Revolving_Non Revolving flag],[Commited_Uncommited],[Syndication_Bilateral],[GL Master No],'NextRepricingDate'=CASE when [NextRepricingDate] is not NULL then CONVERT(Datetime,[NextRepricingDate],104) else NULL end,[InterestBaseMemo],[Booking Centre],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$] where [InterestBaseMemo] is not NULL')"
                        cmd.ExecuteNonQuery()
                        'Count Imported Rows
                        cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT Count(*) FROM [Sheet1$] where [InterestBaseMemo] is not NULL')"
                        Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in CL_DRAWDOWN_OUTSTANDING")

                        'Importieren Exchange Rates
                        Me.BgwOCBSimport.ReportProgress(95, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange Rates")
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [Exchange_rate]= 1 WHERE [Currency]='EUR' and [Exchange_rate] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [Exchange_rate]=(Select [MIDDLE RATE] from [EXCHANGE RATES OCBS] where [CL_DRAWDOWN_OUTSTANDING].[Currency]=[EXCHANGE RATES OCBS].[CURRENCY CODE] and [EXCHANGE RATES OCBS].[EXCHANGE RATE DATE]=[CL_DRAWDOWN_OUTSTANDING].[RepDate]) where [Exchange_rate] is NULL"
                        cmd.ExecuteNonQuery()
                        'UMRECHNUNG
                        Me.BgwOCBSimport.ReportProgress(98, "Procedure:" & CURRENT_PROC & " - " & "Calculate Outstanding Principal in Euro ")
                        cmd.CommandText = "UPDATE [CL_DRAWDOWN_OUTSTANDING] SET [Outstanding Principal EUR]= [Outstanding Principal]/[Exchange_rate]  where [Outstanding Principal EUR] is NULL"
                        cmd.ExecuteNonQuery()

                        If IsLastDay(rd) = True Then
                            'EMAIL an CREDIT DEPARTMENT for ROLLOVER till end next Month
                            Me.BgwOCBSimport.ReportProgress(65, "Procedure:" & CURRENT_PROC & " - " & "Check if Parameter:CL_ROLLOVER_EMAIL are Valid")
                            cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='CL_ROLLOVER_EMAIL'"
                            Dim result As String = cmd.ExecuteScalar
                            If result = "Y" Then
                                Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Create Directory for the creation of the Report in pdf")
                                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='CL_Rollover_Report_Temp_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='CL_ROLLOVER_REPORT_DIRECTORY'"
                                ReportExpFile = cmd.ExecuteScalar

                                'Me.BgwOCBSimport.ReportProgress(70, "Parameter:CL_ROLLOVER_EMAIL is Valid")
                                'QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='CL_ROLLOVER_EMAIL'"
                                'da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                                'dt3 = New DataTable()
                                'da3.Fill(dt3)

                                'Dim EMAIL_USERS As String = ""
                                'For i1 = 0 To dt3.Rows.Count - 1
                                '    EMAIL_USERS += dt3.Rows.Item(i1).Item("PARAMETER2") & ";"
                                'Next
                                'dt3.Clear()


                                'Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
                                'Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
                                'Dim outApp As Microsoft.Office.Interop.Outlook.Application


                                'outApp = New Microsoft.Office.Interop.Outlook.Application

                                'NSpace = outApp.GetNamespace("MAPI")
                                'Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
                                'EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                                'EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

                                'EItem.To = EMAIL_USERS

                                'Temporary Directory creation
                                System.IO.Directory.CreateDirectory(ReportExpFile)

                                Dim CL_Drawdown_Rollover_Da As New SqlDataAdapter("Select * from [CL_DRAWDOWN_OUTSTANDING] where [Product Type] in ('SYNDICATED FIXED TERM LN DRAWDOWN','BILATERAL FIXED TERM LN') and [RepDate]='" & rdsql & "' and [Next Rollover]<=DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,'" & rdsql & "')+2,0)) order by [Next Rollover] asc", conn)
                                Dim CL_Drawdown_Rollover_Dataset As New DataSet("CL_DRAWDOWN_ROLLOVER")
                                CL_Drawdown_Rollover_Da.Fill(CL_Drawdown_Rollover_Dataset, "CL_DRAWDOWN_OUTSTANDING")
                                Dim Cr_DrawdownRollover As New ReportDocument
                                Cr_DrawdownRollover.Load(CrystalRepDir & "\CL_DRAWDOWN_MONTHLY_ROLLOVER.rpt")
                                Cr_DrawdownRollover.SetDataSource(CL_Drawdown_Rollover_Dataset)
                                Cr_DrawdownRollover.ExportToDisk(ExportFormatType.PortableDocFormat, ReportExpFile & "\CL_DRAWDOWN_MONTHLY_NEXT_ROLLOVER.pdf")

                                cmd.CommandText = "EXEC msdb.dbo.sp_start_job 'EMAIL_CL_DRAWDOWN_ROLLOVER'"
                                cmd.ExecuteNonQuery()

                                'EItem.Attachments.Add(ReportExpFile & "\CL_DRAWDOWN_MONTHLY_NEXT_ROLLOVER.pdf")
                                'EItem.Subject = "CL Drawdown rollover till the end of next Month based on data from " & rd
                                'EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain
                                'Dim StrBody1 As String = "******This is an automated E-Mail, generated from the PS TOOL Application!******"
                                'Dim EMAIL_TEXT As String = ""
                                'Dim myBuilder As New StringBuilder

                                'EMAIL_TEXT = "CL Drawdown rollover till the end of next Month based on data from " & rd & vbNewLine & vbNewLine & " SEE ATTACHED REPORT: CL_DRAWDOWN_MONTHLY_ROLLOVER.pdf"

                                'EItem.Body = StrBody1 & vbNewLine & vbNewLine & EMAIL_TEXT & vbNewLine & vbNewLine
                                'EItem.Display()

                                'EItem.Send()
                                Directory.Delete(ReportExpFile, True)
                            Else
                                Me.BgwOCBSimport.ReportProgress(95, "Parameter:SUSPENCE_ACC_EMAIL  is not Valid")
                            End If
                        End If

                        Me.BgwOCBSimport.ReportProgress(10, "Import procedure: IMPORT CL DRAWDON OUTSTANDING is finished sucesfully")
                        End If

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(0, "+++Import Procedure: IMPORT CL DRAWDON OUTSTANDING is not Valid+++")
            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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
                Me.BgwOCBSimport.ReportProgress(4, "Procedure:" & CURRENT_PROC & " - " & "Insert data from Table:EXPORT_LC_MT700 to Table:EXPORT LC DETAILS ALL where Date of Issue>20121231")
                cmd.CommandText = "INSERT INTO [EXPORT LC DETAILS ALL] ([BENEFNAME],[SENDER BIC],[M40A],[M20],[OURREF],[M31C],[M31D_Date],[M31D_Country],[M50_1],[CCY],[M32B]) SELECT UPPER([Beneficiary]),[SenderBIC],[LC_Form],[LC_Nr],[OurReference],[DateOfIssue],[M31D_Date],[M31D_Country],UPPER([Applicant]),[LC_Currency],[LC_Amount] FROM [EXPORT_LC_MT700] where  [DateOfIssue]>'20121231' and [LC_Nr] not in (SELECT [M20] from [EXPORT LC DETAILS ALL])"
                cmd.ExecuteNonQuery()


                'Import in EXPORT LC DETAILS ALL
                'Me.BgwOCBSimport.ReportProgress(4, "Drop Temporary Table:MT700 Temp")
                'cmd.CommandText = "DROP TABLE [MT700 Temp]"
                'cmd.ExecuteNonQuery()
                'Update Field IdLCMonth
                Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Update Field IdLCMonth in Table:EXPORT LC DETAILS ALL")
                'Erster Tag des Monats
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [IdLCMonth]=DATEADD(MONTH, DATEDIFF(MONTH, 0, [M31C]), 0) Where [IdLCMonth] is NULL "
                cmd.ExecuteNonQuery()
                'Update Sender Name and Branch...BIC11
                Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Update Sender Name and Branch from BIC DIRECTORY...BIC11")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[BRANCH INFORMATION]+B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON Left(A.[SENDER BIC],8)=B.[BIC CODE] where Right(A.[SENDER BIC],3)=B.[BRANCH CODE] and A.[SENDERNAME] is NULL and B.[BRANCH INFORMATION] is not NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON Left(A.[SENDER BIC],8)=B.[BIC CODE] where Right(A.[SENDER BIC],3)=B.[BRANCH CODE] and A.[SENDERNAME] is NULL and A.[SENDER BRANCH] is NULL"
                cmd.ExecuteNonQuery()
                'Update Sender Name and Branch...BIC8
                Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & "Update Sender Name and Branch from BIC DIRECTORY...BIC8")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[BRANCH INFORMATION]+B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON A.[SENDER BIC]=B.[BIC CODE] where B.[BRANCH CODE]='XXX' and Len(A.[SENDER BIC])=8 and A.[SENDERNAME] is NULL and B.[BRANCH INFORMATION] is not NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [SENDERNAME]= B.[INSTITUTION NAME],[SENDER BRANCH]=B.[CITY HEADING] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [BIC DIRECTORY] B ON A.[SENDER BIC]=B.[BIC CODE] where B.[BRANCH CODE]='XXX' and Len(A.[SENDER BIC])=8 and A.[SENDERNAME] is NULL and A.[SENDER BRANCH] is NULL"
                cmd.ExecuteNonQuery()
                'Update Exchange Rate
                Me.BgwOCBSimport.ReportProgress(8, "Procedure:" & CURRENT_PROC & " - " & "Update Exchange Rate-Currency EURO")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [EXCHANGE RATE]= 1 WHERE [CCY]='EUR'"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(9, "Procedure:" & CURRENT_PROC & " - " & "Select Max Exchange Rate Date - GROUP BY Month")
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
                Me.BgwOCBSimport.ReportProgress(10, "Procedure:" & CURRENT_PROC & " - " & "Update Exchange Rates-Foreign Currencies")
                cmd.CommandText = "UPDATE A  SET A.[EXCHANGE RATE]=B.[MIDDLE RATE] FROM [EXPORT LC DETAILS ALL] A INNER JOIN [EXCHANGE RATES OCBS] B On A.[EXCHANGE_RATE_DATE]=B.[EXCHANGE RATE DATE] where A.[CCY]=B.[CURRENCY CODE] and A.[CCY] not in ('EUR')"
                cmd.ExecuteNonQuery()
                'Calculate LC Amounts in EURO
                Me.BgwOCBSimport.ReportProgress(11, "Procedure:" & CURRENT_PROC & " - " & "Calculate LC Amounts in EURO")
                cmd.CommandText = "UPDATE [EXPORT LC DETAILS ALL] SET [AMTEUR]=Round([M32B]/[EXCHANGE RATE],2)"
                cmd.ExecuteNonQuery()
                'Insert into EXPORT LC MONTH
                Me.BgwOCBSimport.ReportProgress(12, "Procedure:" & CURRENT_PROC & " - " & "Insert into EXPORT LC MONTH")
                cmd.CommandText = "INSERT INTO [EXPORT LC MONTH] ([LC Month],IdLCYear) Select distinct [IdLCMonth],DATEADD(YEAR, DATEDIFF(YEAR, 0, [IdLCMonth]), 0) from [EXPORT LC DETAILS ALL] WHERE [IdLCMonth] not in (Select  [LC Month] from   [EXPORT LC MONTH])"
                cmd.ExecuteNonQuery()
                'Insert into EXPORT LC YEAR
                Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Insert into EXPORT LC YEAR")
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
                Me.BgwOCBSimport.ReportProgress(13, "Procedure:" & CURRENT_PROC & " - " & "Select LC Amt Sum,LC Items for Each Month and Update Table EXPORT LC MONTH")
                cmd.CommandText = "UPDATE A SET A.[LC Items]=B.LCItems,A.[LC Amounts]=B.SumLCAmt from [EXPORT LC MONTH] A INNER JOIN (Select sum([AMTEUR]) as SumLCAmt,Count([ID])as LCItems,[IdLCMonth] from   [EXPORT LC DETAILS ALL] GROUP BY Month([IdLCMonth]),[IdLCMonth])B on A.[LC Month]=B.[IdLCMonth]"
                cmd.ExecuteNonQuery()


                'Select Sum of Volumes from PROFIT AND LOSS VOLUMES
                Me.BgwOCBSimport.ReportProgress(14, "Procedure:" & CURRENT_PROC & " - " & "Select Sum of Volumes from PROFIT AND LOSS VOLUMES")
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
                        Me.BgwOCBSimport.ReportProgress(15, "Procedure:" & CURRENT_PROC & " - " & "Update Earnings")
                        cmd.CommandText = "UPDATE [EXPORT LC MONTH] SET [LC Earnings]=" & Str(SumAmtBalance) & " where [LC Month]='" & MinBDsql & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next
                Me.BgwOCBSimport.ReportProgress(50, "Procedure:" & CURRENT_PROC & " - " & "Import in Tabelle EXPORT LC YEAR")
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
                Me.BgwOCBSimport.ReportProgress(70, "Procedure:" & CURRENT_PROC & " - " & "Select LC Amt Sum,LC Items for Each Year and Update Table EXPORT LC YEAR")
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
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
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
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: GUARANTEE EXPOSURE REPORT")
                Dim ExcelFileName As String = ""
                ExcelFileName = Me.OCBS_Temp_Directory & "\A021198G0_DC0070000_" & rdsql & ".xlsx"
                Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Reformating Excel File:\A021198G0_DC0070000_" & rdsql & ".xlsx")

                If File.Exists(ExcelFileName) = True Then
                    'Excel Datei Öffnen und Datenformat ändern
                    EXCELL = CreateObject("Excel.Application")
                    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                    xlWorksheet1 = xlWorkBook.Worksheets(1)
                    EXCELL.Visible = False

                    xlWorksheet1.Rows("1:3").delete()
                    xlWorksheet1.Range("A1").Value = "ClientName"
                    xlWorksheet1.Range("B1").Value = "ClientNo"
                    xlWorksheet1.Range("C1").Value = "SigningDate"
                    xlWorksheet1.Range("D1").Value = "ContractNr"
                    xlWorksheet1.Range("E1").Value = "CommitmentNr"
                    xlWorksheet1.Range("F1").Value = "GuaranteeType"
                    xlWorksheet1.Range("G1").Value = "Offshore_Onshore"
                    xlWorksheet1.Range("H1").Value = "GuaranteeNo"
                    xlWorksheet1.Range("I1").Value = "ProductTypeCode"
                    xlWorksheet1.Range("J1").Value = "LC_Nature"
                    xlWorksheet1.Range("K1").Value = "IssuingDate"
                    xlWorksheet1.Range("L1").Value = "ExpiryDate"
                    xlWorksheet1.Range("M1").Value = "CUR"
                    xlWorksheet1.Range("N1").Value = "LC_Amount"
                    xlWorksheet1.Range("O1").Value = "AC_Centre"
                    xlWorksheet1.Range("P1").Value = "Remark"
                    xlWorksheet1.Range("Q1").Value = "HandledBy"
                    xlWorksheet1.Name = "Sheet1"

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
                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Excel File:\A021198G0_DC0070000_" & rdsql & ".xlsx reformated successfully")

                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(5, "Procedure:" & CURRENT_PROC & " - " & "Delete Data in GUARANTEE_EXPOSURE with same Date")
                    cmd.CommandText = "DELETE FROM [GUARANTEE_EXPOSURE] Where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(6, "Procedure:" & CURRENT_PROC & " - " & "Start import to Table: GUARANTEE_EXPOSURE")
                    cmd.CommandText = "INSERT INTO [GUARANTEE_EXPOSURE]([ClientName],[ClientNo],[SigningDate],[ContractNr],[CommitmentNr],[GuaranteeNo],[GuaranteeType],[Offshore_Onshore],[ProductTypeCode],[LC_Nr],[LC_Nature],[IssuingDate],[ExpiryDate],[CUR],[LC_Amount],[Remark1],[RiskDate]) SELECT [ClientName],[ClientNo],[SigningDate],[ContractNr],[CommitmentNr],[GuaranteeNo],[GuaranteeType],[Offshore_Onshore],[ProductTypeCode],[GuaranteeNo],[LC_Nature],[IssuingDate],[ExpiryDate],[CUR],[LC_Amount],[Remark],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [ContractNr] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Count Imported Rows
                    cmd.CommandText = "SELECT Count(*) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [ContractNr] FROM [Sheet1$] where [ContractNr] is not NULL')"
                    Me.BgwOCBSimport.ReportProgress(7, "Procedure:" & CURRENT_PROC & " - " & cmd.ExecuteScalar & " rows imported in GUARANTEE_EXPOSURE")

                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: GUARANTEE EXPOSURE REPORT is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & ExcelFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:GUARANTEE EXPOSURE REPORT is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub GMPS_IMPORT_IREMFM()

        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "GMPS_INTERFACE_IREMFM"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            'Dim rdsql As String = ""

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='GMPS INTERFACE IREMFM' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: GMPS INTERFACE IREMFM")
                Dim DatFileName As String = ""
                If rd >= DateSerial(2018, 2, 1) Then
                    DatFileName = "\\ccb-nft\e$\INTERFACE\GMPS\" & rdsql & "\A0333_SAFEID_DC0070000_IREMFM_ADD_" & rdsql & "_0001.dat"
                ElseIf rd < DateSerial(2018, 2, 1) Then
                    DatFileName = "\\ccb-nft\e$\INTERFACE\GMPS\" & rdsql & "\A0333_130043_DC0070000_IREMFM_ADD_" & rdsql & "_0001.dat"
                End If
                Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import Dat File: " & DatFileName)

                If File.Exists(DatFileName) = True Then

                    cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_GMPS_IREMFM' AND xtype='U') DROP TABLE [#Temp_GMPS_IREMFM]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_GMPS_IREMFM' AND xtype='U') CREATE TABLE [#Temp_GMPS_IREMFM]([Column 0] [varchar](255) NULL,[Column 1] [varchar](255) NULL,[Column 2] [varchar](255) NULL,[Column 3] [varchar](255) NULL,[Column 4] [varchar](255) NULL,[Column 5] [varchar](255) NULL,[Column 6] [varchar](255) NULL,[Column 7] [varchar](255) NULL,[Column 8] [varchar](255) NULL,[Column 9] [varchar](255) NULL,[Column 10] [varchar](255) NULL,[Column 11] [varchar](255) NULL,[Column 12] [varchar](255) NULL,[Column 13] [varchar](255) NULL,[Column 14] [varchar](255) NULL,[Column 15] [varchar](255) NULL,[Column 16] [varchar](255) NULL,[Column 17] [varchar](255) NULL,[Column 18] [varchar](255) NULL,[Column 19] [varchar](255) NULL,[Column 20] [varchar](255) NULL,[Column 21] [varchar](255) NULL,[Column 22] [varchar](255) NULL,[Column 23] [varchar](255) NULL,[Column 24] [varchar](255) NULL,[Column 25] [varchar](255) NULL,[Column 26] [varchar](255) NULL,[Column 27] [varchar](255) NULL,[Column 28] [varchar](255) NULL,[Column 29] [varchar](255) NULL,[Column 30] [varchar](255) NULL,[Column 31] [varchar](255) NULL,[Column 32] [varchar](255) NULL,[Column 33] [varchar](255) NULL,[Column 34] [varchar](255) NULL,[Column 35] [varchar](255) NULL,[Column 36] [varchar](255) NULL,[Column 37] [varchar](255) NULL,[Column 38] [varchar](255) NULL,[Column 39] [varchar](255) NULL,[Column 40] [varchar](255) NULL,[Column 41] [varchar](255) NULL,[Column 42] [varchar](255) NULL,[Column 43] [varchar](255) NULL,[Column 44] [varchar](255) NULL,[Column 45] [varchar](255) NULL,[Column 46] [varchar](255) NULL,[Column 47] [varchar](255) NULL,[Column 48] [varchar](255) NULL,[Column 49] [varchar](255) NULL,[Column 50] [varchar](255) NULL,[Column 51] [varchar](255) NULL,[Column 52] [varchar](255) NULL,[Column 53] [varchar](255) NULL,[Column 54] [varchar](255) NULL,[Column 55] [varchar](255) NULL,[Column 56] [varchar](255) NULL,[Column 57] [varchar](255) NULL,[Column 58] [varchar](255) NULL,[Column 59] [varchar](255) NULL,[Column 60] [varchar](255) NULL,[Column 61] [varchar](255) NULL,[Column 62] [varchar](255) NULL,[Column 63] [varchar](255) NULL,[Column 64] [varchar](255) NULL,[Column 65] [varchar](255) NULL,[Column 66] [varchar](255) NULL,[Column 67] [varchar](255) NULL,[Column 68] [varchar](255) NULL,[Column 69] [varchar](255) NULL,[Column 70] [varchar](255) NULL,[Column 71] [varchar](255) NULL,[Column 72] [varchar](255) NULL,[Column 73] [varchar](255) NULL,[Column 74] [varchar](255) NULL,[Column 75] [varchar](255) NULL,[Column 76] [varchar](255) NULL,[Column 77] [varchar](255) NULL,[Column 78] [varchar](255) NULL,[Column 79] [varchar](255) NULL,[Column 80] [varchar](255) NULL,[Column 81] [varchar](255) NULL,[Column 82] [varchar](255) NULL,[Column 83] [varchar](255) NULL,[Column 84] [varchar](255) NULL,[Column 85] [varchar](255) NULL,[Column 86] [varchar](255) NULL,[Column 87] [varchar](255) NULL,[Column 88] [varchar](255) NULL,[Column 89] [varchar](255) NULL,[Column 90] [varchar](255) NULL,[Column 91] [varchar](255) NULL,[Column 92] [varchar](255) NULL,[Column 93] [varchar](255) NULL,[Column 94] [varchar](255) NULL,[Column 95] [varchar](255) NULL,[Column 96] [varchar](255) NULL,[Column 97] [varchar](255) NULL,[Column 98] [varchar](255) NULL,[Column 99] [varchar](255) NULL,[Column 100] [varchar](255) NULL,[Column 101] [varchar](255) NULL,[Column 102] [varchar](255) NULL,[Column 103] [varchar](255) NULL,[Column 104] [varchar](255) NULL,[Column 105] [varchar](255) NULL,[Column 106] [varchar](255) NULL,[Column 107] [varchar](255) NULL,[Column 108] [varchar](255) NULL,[Column 109] [varchar](255) NULL,[Column 110] [varchar](255) NULL,[Column 111] [varchar](255) NULL,[Column 112] [varchar](255) NULL,[Column 113] [varchar](255) NULL,[Column 114] [varchar](255) NULL,[Column 115] [varchar](255) NULL,[Column 116] [varchar](255) NULL,[Column 117] [varchar](255) NULL,[Column 118] [varchar](255) NULL,[Column 119] [varchar](255) NULL,[Column 120] [varchar](255) NULL,[Column 121] [varchar](255) NULL,[Column 122] [varchar](255) NULL,[Column 123] [varchar](255) NULL,[Column 124] [varchar](255) NULL,[Column 125] [varchar](255) NULL,[Column 126] [varchar](255) NULL,[Column 127] [varchar](255) NULL,[Column 128] [varchar](255) NULL,[Column 129] [varchar](255) NULL,[Column 130] [varchar](255) NULL,[Column 131] [varchar](255) NULL,[Column 132] [varchar](255) NULL,[Column 133] [varchar](255) NULL,[Column 134] [varchar](255) NULL,[Column 135] [varchar](255) NULL,[Column 136] [varchar](255) NULL,[Column 137] [varchar](255) NULL,[Column 138] [varchar](255) NULL,[Column 139] [varchar](255) NULL,[Column 140] [varchar](255) NULL,[Column 141] [varchar](255) NULL,[Column 142] [varchar](255) NULL,[Column 143] [varchar](255) NULL,[Column 144] [varchar](255) NULL,[Column 145] [varchar](255) NULL,[Column 146] [varchar](255) NULL,[Column 147] [varchar](255) NULL,[Column 148] [varchar](255) NULL,[Column 149] [varchar](255) NULL,[Column 150] [varchar](255) NULL,[Column 151] [varchar](255) NULL,[Column 152] [varchar](255) NULL,[Column 153] [varchar](255) NULL,[Column 154] [varchar](255) NULL,[Column 155] [varchar](255) NULL,[Column 156] [varchar](255) NULL,[Column 157] [varchar](255) NULL,[Column 158] [varchar](255) NULL,[Column 159] [varchar](255) NULL,[Column 160] [varchar](255) NULL,[Column 161] [varchar](255) NULL,[Column 162] [varchar](255) NULL,[Column 163] [varchar](255) NULL,[Column 164] [varchar](255) NULL,[Column 165] [varchar](255) NULL,[Column 166] [varchar](255) NULL,[Column 167] [varchar](255) NULL,[Column 168] [varchar](255) NULL,[Column 169] [varchar](255) NULL,[Column 170] [varchar](255) NULL,[Column 171] [varchar](255) NULL,[Column 172] [varchar](255) NULL,[Column 173] [varchar](255) NULL,[Column 174] [varchar](255) NULL,[Column 175] [varchar](255) NULL,[Column 176] [varchar](255) NULL,[Column 177] [varchar](255) NULL,[Column 178] [varchar](255) NULL,[Column 179] [varchar](255) NULL,[Column 180] [varchar](255) NULL,[Column 181] [varchar](255) NULL,[Column 182] [varchar](255) NULL,[Column 183] [varchar](255) NULL,[Column 184] [varchar](255) NULL,[Column 185] [varchar](255) NULL,[Column 186] [varchar](255) NULL,[Column 187] [varchar](255) NULL,[Column 188] [varchar](255) NULL,[Column 189] [varchar](255) NULL,[Column 190] [varchar](255) NULL,[Column 191] [varchar](255) NULL,[Column 192] [varchar](255) NULL,[Column 193] [varchar](255) NULL,[Column 194] [varchar](255) NULL,[Column 195] [varchar](255) NULL,[Column 196] [varchar](255) NULL,[Column 197] [varchar](255) NULL,[Column 198] [varchar](255) NULL,[Column 199] [varchar](255) NULL,[Column 200] [varchar](255) NULL,[Column 201] [varchar](255) NULL,[Column 202] [varchar](255) NULL,[Column 203] [varchar](255) NULL,[Column 204] [varchar](255) NULL,[Column 205] [varchar](255) NULL,[Column 206] [varchar](255) NULL,[Column 207] [varchar](255) NULL,[Column 208] [varchar](255) NULL,[Column 209] [varchar](255) NULL,[Column 210] [varchar](255) NULL,[Column 211] [varchar](255) NULL,[Column 212] [varchar](255) NULL,[Column 213] [varchar](255) NULL,[Column 214] [varchar](255) NULL,[Column 215] [varchar](255) NULL,[Column 216] [varchar](255) NULL,[Column 217] [varchar](255) NULL,[Column 218] [varchar](255) NULL,[Column 219] [varchar](255) NULL,[Column 220] [varchar](255) NULL,[Column 221] [varchar](255) NULL,[Column 222] [varchar](255) NULL,[Column 223] [varchar](255) NULL,[Column 224] [varchar](255) NULL,[Column 225] [varchar](255) NULL,[Column 226] [varchar](255) NULL,[Column 227] [varchar](255) NULL,[Column 228] [varchar](255) NULL,[Column 229] [varchar](255) NULL,[Column 230] [varchar](255) NULL,[Column 231] [varchar](255) NULL,[Column 232] [varchar](255) NULL,[Column 233] [varchar](255) NULL,[Column 234] [varchar](255) NULL,[Column 235] [varchar](255) NULL,[Column 236] [varchar](255) NULL,[Column 237] [varchar](255) NULL,[Column 238] [varchar](255) NULL,[Column 239] [varchar](255) NULL,[Column 240] [varchar](255) NULL,[Column 241] [varchar](255) NULL,[Column 242] [varchar](255) NULL,[Column 243] [varchar](255) NULL,[Column 244] [varchar](255) NULL,[Column 245] [varchar](255) NULL,[Column 246] [varchar](255) NULL,[Column 247] [varchar](255) NULL,[Column 248] [varchar](255) NULL,[Column 249] [varchar](255) NULL,[Column 250] [varchar](255) NULL,[Column 251] [varchar](255) NULL,[Column 252] [varchar](255) NULL,[Column 253] [varchar](255) NULL,[Column 254] [varchar](255) NULL,[Column 255] [varchar](255) NULL,[Column 256] [varchar](255) NULL,[Column 257] [varchar](255) NULL,[Column 258] [varchar](255) NULL,[Column 259] [varchar](255) NULL,[Column 260] [varchar](255) NULL,[Column 261] [varchar](255) NULL,[Column 262] [varchar](255) NULL,[Column 263] [varchar](255) NULL,[Column 264] [varchar](255) NULL,[Column 265] [varchar](255) NULL,[Column 266] [varchar](255) NULL) ELSE DELETE FROM [#Temp_GMPS_IREMFM]"
                    cmd.ExecuteNonQuery()
                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import Dat File: " & DatFileName)
                    cmd.CommandText = "BULK INSERT  [#Temp_GMPS_IREMFM] FROM '" & DatFileName & "' with (FIRSTROW = 1,fieldterminator = '|')"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Add ID to Temporary Table")
                    cmd.CommandText = "ALTER TABLE [#Temp_GMPS_IREMFM] ADD [ID] [int] IDENTITY(1,1) NOT NULL"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates in Temporary Table")
                    cmd.CommandText = "DELETE FROM [#Temp_GMPS_IREMFM] where [ID] not in (Select Min([ID]) from [#Temp_GMPS_IREMFM] group by [Column 0])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Insert Data to GMPS_IREMFM from Temporary Table")
                    cmd.CommandText = "INSERT INTO [GMPS_IREMFM]([EM00KEY0],[EM00KEY1],[EM00KEY2],[EM00KEY3],[EM00KEY4],[RECORDTYPE],[OURTRANREFNO],[EVENTNUMBER],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[RECEIVERTELEX],[RELATEDREF],[TRANSACTIONDATE],[VALUEDATE],[RETURNDATE],[CURRENCYCODE],[USDEQURATE],[AMOUNT],[HANDLINGFEE],[CABLECHARGE],[POSTAGECHARGE],[TOTALSETTLEAMT],[TOTALDISHONAMT],[NETAMOUNT],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[ORDERCUSTCTY],[ORDERCUSTSWIFT],[ORDERCUSTTELEX],[ORDERINGINSTID],[ORDERINGINSTNM],[ORDERINGINSTBR],[ORDERINGINSTST],[ORDERINGINSTTX],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[RECRCORRTELEX],[INTERMEDIARYID],[INTERMEDIARYNM],[INTERMEDIARYBR],[INTERMEDIARYST],[INTERMEDIARYTX],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTA1],[ACWITHINSTA2],[ACWITHINSST],[BENEINSTAC],[BENEINSTID],[BENEINSTNAME],[BENEINSTBRANCH],[BENEINSTADDR1],[BENEINSTADDR2],[BENEINSTADDR3],[BENEINSTSWIFT],[BENEINSTTELEX],[BENEFICIARYID],[BENEFICIARYNAME],[BENEFICIARYBR],[BENEFICIARYADR1],[BENEFICIARYADR2],[BENEFICIARYADR3],[BENEFICIARYST],[BENEFICIARYTLX],[BENEFICIARYAC],[PAYMENTDETAILS],[BKTOBKINFORM],[BKTOBKINF202],[SETTLEDCHEQUE_MessageSource],[DISHONCHEQUE],[USERID],[SYSTEMDATE],[REPORTNAME],[REPORTBR],[SWIFTINREF],[REPORTREF],[DETAILSOFCHG],[CHARGECODE],[CHARGEDETAILS],[BANKOPERCODE],[INSTRUCTIONCODE],[TXTYPECODE],[INSTRUCTEDCCY],[INSTRUCTEDAMT],[EXCHANGERATE],[SENDINGINSTIT1],[SENDINGINSTIT2],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[THIRDREIMNAME],[THIRDREIMBR],[THIRDREIMST],[SENDERCCY],[SENDERAMT],[RECVRCCY],[RECVRAMT],[CHATSBANKCODE],[FUNDINGACCOUNT],[VOUCHERREF],[ACWITHINSTLOC],[FIELD111],[PARASET],[PARAC],[ENTRYTYPE],[FILETYPE],[HOLDUSER],[HOLDDATE],[HOLDFUNC],[STATUS],[RELCODE],[RELUSER],[VOUCHERNO],[TFHOLDMARK],[UPDATEUSER],[UPDATADATE],[CALSAVENO],[CLSTATUS],[CHECKCODE],[CHECKUSER],[REVFILLER],[Feecurr],[Column 266])SELECT [Column 0] as 'EM00KEY0',[Column 2]as 'EM00KEY1',[Column 4]as 'EM00KEY2',[Column 6]as 'EM00KEY3',[Column 8]as 'EM00KEY4',[Column 10] as 'RECORDTYPE',[Column 12] as 'OURTRANREFNO',[Column 14] as 'EVENTNUMBER',[Column 16] as 'INWARDOUTWARD','METHOD'=Case when [Column 18]='1' then 'MT103' when [Column 18]='2' then 'MT202COV' when [Column 18]='3' then 'MT910' when [Column 18]='4' then 'MT210' when [Column 18]='5' then 'MT202' when [Column 18]='6' then 'TGT202COV' when [Column 18]='7' then 'TGT103' when [Column 18]='8' then 'TGT202' when [Column 18]='9' then 'TGT910' when [Column 18]='A' then 'EMZ103' when [Column 18]='B' then 'SEPA103' end,[column 20] as 'RECEIVERID',[column 22] as 'RECEIVERNAME',[Column 24] as 'RECEIVERBRANCH',[Column 26] as 'RECEIVERSWIFT',[Column 28] as 'RECEIVERTELEX',[Column 30] as 'RELATEDREF',Convert(datetime,[column 32]) as 'TRANSACTIONDATE',Convert(datetime,[column 34]) as 'VALUEDATE',Convert(datetime,[column 36]) as 'RETURNDATE',[Column 38] as 'CURRENCYCODE',[Column 40] as 'USDEQURATE',Case when ISNUMERIC([Column 42])=1 and LEN([Column 42])<=2 then convert(float,'0' + '.' + RIGHT([Column 42],2))when ISNUMERIC([Column 42])=1 and LEN([Column 42])=3 then convert(float,LEFT([Column 42],1) + '.' + RIGHT([Column 42],2))when ISNUMERIC([Column 42])=1 and LEN([Column 42])>3 then convert(float,LEFT([Column 42],len([Column 42])-2) + '.' + RIGHT([Column 42],2)) else 0 end as 'AMOUNT',Case when ISNUMERIC([Column 44])=1 and LEN([Column 44])<=2 then convert(float,'0' + '.' + RIGHT([Column 44],2))when ISNUMERIC([Column 44])=1 and LEN([Column 44])=3 then convert(float,LEFT([Column 44],1) + '.' + RIGHT([Column 44],2))when ISNUMERIC([Column 44])=1 and LEN([Column 44])>3 then convert(float,LEFT([Column 44],len([Column 44])-2) + '.' + RIGHT([Column 44],2)) else 0 end as 'HANDLINGFEE',Case when ISNUMERIC([Column 46])=1 and LEN([Column 46])<=2 then convert(float,'0' + '.' + RIGHT([Column 46],2))when ISNUMERIC([Column 46])=1 and LEN([Column 46])=3 then convert(float,LEFT([Column 46],1) + '.' + RIGHT([Column 46],2))when ISNUMERIC([Column 46])=1 and LEN([Column 46])>3 then convert(float,LEFT([Column 46],len([Column 46])-2) + '.' + RIGHT([Column 46],2)) else 0 end as 'CABLECHARGE',Case when ISNUMERIC([Column 48])=1 and LEN([Column 48])<=2 then convert(float,'0' + '.' + RIGHT([Column 48],2))when ISNUMERIC([Column 48])=1 and LEN([Column 48])=3 then convert(float,LEFT([Column 48],1) + '.' + RIGHT([Column 48],2))when ISNUMERIC([Column 48])=1 and LEN([Column 48])>3 then convert(float,LEFT([Column 48],len([Column 48])-2) + '.' + RIGHT([Column 48],2)) else 0 end as 'POSTAGECHARGE',Case when ISNUMERIC([Column 50])=1 and LEN([Column 50])<=2 then convert(float,'0' + '.' + RIGHT([Column 50],2))when ISNUMERIC([Column 50])=1 and LEN([Column 50])=3 then convert(float,LEFT([Column 50],1) + '.' + RIGHT([Column 50],2))when ISNUMERIC([Column 50])=1 and LEN([Column 50])>3 then convert(float,LEFT([Column 50],len([Column 50])-2) + '.' + RIGHT([Column 50],2)) else 0 end as 'TOTALSETTLEAMT',Case when ISNUMERIC([Column 52])=1 and LEN([Column 52])<=2 then convert(float,'0' + '.' + RIGHT([Column 52],2))when ISNUMERIC([Column 52])=1 and LEN([Column 52])=3 then convert(float,LEFT([Column 52],1) + '.' + RIGHT([Column 52],2))when ISNUMERIC([Column 52])=1 and LEN([Column 52])>3 then convert(float,LEFT([Column 52],len([Column 52])-2) + '.' + RIGHT([Column 52],2)) else 0 end as 'TOTALDISHONAMT',Case when ISNUMERIC([Column 54])=1 and LEN([Column 54])<=2 then convert(float,'0' + '.' + RIGHT([Column 54],2))when ISNUMERIC([Column 54])=1 and LEN([Column 54])=3 then convert(float,LEFT([Column 54],1) + '.' + RIGHT([Column 54],2))when ISNUMERIC([Column 54])=1 and LEN([Column 54])>3 then convert(float,LEFT([Column 54],len([Column 54])-2) + '.' + RIGHT([Column 54],2)) else 0 end as 'NETAMOUNT',[Column 56] as 'ORDERCUSTID',[Column 58] as 'ORDERCUSTNAME',[Column 60] as 'ORDERCUSTBR',[Column 62] as 'ORDERCUSTADD1',[Column 64] as 'ORDERCUSTADD2',[Column 66] as 'ORDERCUSTADD3',[Column 68] as 'ORDERCUSTCTY',[Column 70] as 'ORDERCUSTSWIFT',[Column 72] as 'ORDERCUSTTELEX',[Column 74] as 'ORDERINGINSTID',[Column 76] as 'ORDERINGINSTNM',[Column 78] as 'ORDERINGINSTBR',[Column 80] as 'ORDERINGINSTST',[Column 82] as 'ORDERINGINSTTX',[Column 84] as 'RECRCORRID',[Column 86] as 'RECRCORRNAME',[Column 88] as 'RECRCORRBR',[Column 90] as 'RECRCORRSWIFT',[Column 92] as 'RECRCORRTELEX',[Column 94] as 'INTERMEDIARYID',[Column 96] as 'INTERMEDIARYNM',[Column 98] as 'INTERMEDIARYBR',[Column 100] as 'INTERMEDIARYST',[Column 102] as 'INTERMEDIARYTX',[Column 104] as 'ACWITHINSTID',[Column 106] as 'ACWITHINSTNA',[Column 108] as 'ACWITHINSTBR',[Column 110] as 'ACWITHINSTA1',[Column 112] as 'ACWITHINSTA2',[Column 114] as 'ACWITHINSST',[Column 116] as 'BENEINSTAC',[Column 118] as 'BENEINSTID',[Column 120] as 'BENEINSTNAME',[Column 122] as 'BENEINSTBRANCH',[Column 124] as 'BENEINSTADDR1',[Column 126] as 'BENEINSTADDR2',[Column 128] as 'BENEINSTADDR3',[Column 130] as 'BENEINSTSWIFT',[Column 132] as 'BENEINSTTELEX',[Column 134] as 'BENEFICIARYID',[Column 136] as 'BENEFICIARYNAME',[Column 138] as 'BENEFICIARYBR',[Column 140] as 'BENEFICIARYADR1',[Column 142] as 'BENEFICIARYADR2',[Column 144] as 'BENEFICIARYADR3',[Column 146] as 'BENEFICIARYST',[Column 148] as 'BENEFICIARYTLX',[Column 150] as 'BENEFICIARYAC',[Column 152] as 'PAYMENTDETAILS',[Column 154] as 'BKTOBKINFORM',[Column 156] as 'BKTOBKINF202',[Column 158] as 'SETTLEDCHEQUE',[Column 160] as 'DISHONCHEQUE',[Column 162] as 'USERID',Convert(datetime,[column 164]) as 'SYSTEMDATE',[Column 166] as 'REPORTNAME',[Column 168] as 'REPORTBR',[column 170] as 'SWIFTINREF',[Column 172] as 'REPORTREF',[Column 174] as 'DETAILSOFCHG',[Column 176] as 'CHARGECODE',[Column 178] as 'CHARGEDETAILS',[Column 180] as 'BANKOPERCODE',[Column 182] as 'INSTRUCTIONCODE',[Column 184] as 'TXTYPECODE',[Column 186] as 'INSTRUCTEDCCY',[Column 188] as 'INSTRUCTEDAMT',[Column 190] as 'EXCHANGERATE',[Column 192] as 'SENDINGINSTIT1',[Column 194] as 'SENDINGINSTIT2',[Column 196] as 'SENDERCORRNAME',[Column 198] as 'SENDERCORRBR',[Column 200] as 'SENDERCORRST',[Column 202] as 'THIRDREIMNAME',[Column 204] as 'THIRDREIMBR',[Column 206] as 'THIRDREIMST',[Column 208] as 'SENDERCCY',Case when ISNUMERIC([Column 210])=1 and LEN([Column 210])<=2 then convert(float,'0' + '.' + RIGHT([Column 210],2))when ISNUMERIC([Column 210])=1 and LEN([Column 210])=3 then convert(float,LEFT([Column 210],1) + '.' + RIGHT([Column 210],2))when ISNUMERIC([Column 210])=1 and LEN([Column 210])>3 then convert(float,LEFT([Column 210],len([Column 210])-2) + '.' + RIGHT([Column 210],2)) else 0 end as 'SENDERAMT',[Column 212] as 'RECVRCCY',Case when ISNUMERIC([Column 214])=1 and LEN([Column 214])<=2 then convert(float,'0' + '.' + RIGHT([Column 214],2))when ISNUMERIC([Column 214])=1 and LEN([Column 214])=3 then convert(float,LEFT([Column 214],1) + '.' + RIGHT([Column 214],2))when ISNUMERIC([Column 214])=1 and LEN([Column 214])>3 then convert(float,LEFT([Column 214],len([Column 214])-2) + '.' + RIGHT([Column 214],2)) else 0 end as 'RECVRAMT',[Column 216] as 'CHATSBANKCODE',[Column 218] as 'FUNDINGACCOUNT',[Column 220] as 'VOUCHERREF',[Column 222] as 'ACWITHINSTLOC',[Column 224] as 'FIELD111',[Column 226] as 'PARASET',[Column 228] as 'PARAC',[Column 230]  as 'ENTRYTYPE',[Column 232] as 'FILETYPE',[Column 234]  as 'HOLDUSER',Convert(datetime,[column 236]) as 'HOLDDATE',[Column 238] as 'HOLDFUNC',[Column 240] as 'STATUS',[Column 242] as 'RELCODE',[Column 244] as 'RELUSER',[Column 246] as 'VOUCHERNO',[Column 248] as 'TFHOLDMARK',[Column 250] as 'UPDATEUSER',Convert(datetime,[column 252]) as 'UPDATADATE',[Column 254] as 'CALSAVENO',[Column 256] as 'CLSTATUS',[Column 258] as 'CHECKCODE',[Column 260] as 'CHECKUSER',[Column 262] as 'REVFILLER',[Column 264] as 'Feecurr',[Column 266] FROM [#Temp_GMPS_IREMFM] where [Column 0] not in (Select EM00KEY0 from GMPS_IREMFM)"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Drop Temporary Table")
                    cmd.CommandText = "DROP TABLE [#Temp_GMPS_IREMFM]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from GMPS_IREMFM")
                    cmd.CommandText = "DELETE FROM [GMPS_IREMFM] where [ID] not in (Select Min([ID]) from [GMPS_IREMFM] group by [EM00KEY0])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Insert Data from GMPS_IREMFM to ODAS REMMITANCES")
                    cmd.CommandText = "INSERT INTO [ODAS REMMITANCES]([EM00KEY0],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[PAYMENTDETAILS],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[Deal Amount],[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC])SELECT [EM00KEY0],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],ACWITHINSST,BENEFICIARYAC,BENEFICIARYID,BENEFICIARYNAME,BENEFICIARYBR,BENEFICIARYADR1,BENEFICIARYADR2,PAYMENTDETAILS,DETAILSOFCHG,BKTOBKINFORM,[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],AMOUNT,[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC] from GMPS_IREMFM where EM00KEY0 not in (Select [EM00KEY0] from [ODAS REMMITANCES])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange Rates to ODAS REMMITANCES")
                    cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [ODAS REMMITANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[TRANSACTIONDATE]=B.[EXCHANGE RATE DATE]  and A.[CURRENCYCODE]=B.[CURRENCY CODE] where A.[CURRENCYCODE] not in ('EUR') and A.[Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [ODAS REMMITANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.VALUEDATE=B.[EXCHANGE RATE DATE]  and A.[CURRENCYCODE]=B.[CURRENCY CODE] where A.[CURRENCYCODE] not in ('EUR') and A.[Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Calculate Deal Amount Euro in ODAS REMMITANCES")
                    cmd.CommandText = "UPDATE [ODAS REMMITANCES] SET [Deal Amount Euro]=Round([Deal Amount]/[EXCHANGE_RATE],2) where  [Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Delete duplicates in ODAS REMMITANCES based on Field:EM00KEY0")
                    cmd.CommandText = "DELETE  FROM [ODAS REMMITANCES] where [ID] not in (Select Min([ID]) from [ODAS REMMITANCES] group by [EM00KEY0])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: GMPS INTERFACE IREMFM is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & DatFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:GMPS INTERFACE IREMFM is not VALID+++")

            End If
                Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
       

    End Sub

    Private Sub GMPS_IMPORT_REMIFM()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "GMPS_INTERFACE_REMIFM"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            'Dim rdsql As String = ""

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='GMPS INTERFACE REMIFM' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Start import procedure: GMPS INTERFACE REMIFM")
                Dim DatFileName As String = ""
                If rd >= DateSerial(2018, 2, 1) Then
                    DatFileName = "\\ccb-nft\e$\INTERFACE\GMPS\" & rdsql & "\A0333_SAFEID_DC0070000_REMIFM_ADD_" & rdsql & "_0001.dat"
                ElseIf rd < DateSerial(2018, 2, 1) Then
                    DatFileName = "\\ccb-nft\e$\INTERFACE\GMPS\" & rdsql & "\A0333_130043_DC0070000_REMIFM_ADD_" & rdsql & "_0001.dat"
                End If
                Me.BgwOCBSimport.ReportProgress(2, "Import Dat File: " & DatFileName)

                If File.Exists(DatFileName) = True Then

                    cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_GMPS_REMIFM' AND xtype='U') DROP TABLE [#Temp_GMPS_REMIFM]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_GMPS_REMIFM' AND xtype='U') CREATE TABLE [#Temp_GMPS_REMIFM]([Column 0] [varchar](255) NULL,[Column 1] [varchar](255) NULL,[Column 2] [varchar](255) NULL,[Column 3] [varchar](255) NULL,[Column 4] [varchar](255) NULL,[Column 5] [varchar](255) NULL,[Column 6] [varchar](255) NULL,[Column 7] [varchar](255) NULL,[Column 8] [varchar](255) NULL,[Column 9] [varchar](255) NULL,[Column 10] [varchar](255) NULL,[Column 11] [varchar](255) NULL,[Column 12] [varchar](255) NULL,[Column 13] [varchar](255) NULL,[Column 14] [varchar](255) NULL,[Column 15] [varchar](255) NULL,[Column 16] [varchar](255) NULL,[Column 17] [varchar](255) NULL,[Column 18] [varchar](255) NULL,[Column 19] [varchar](255) NULL,[Column 20] [varchar](255) NULL,[Column 21] [varchar](255) NULL,[Column 22] [varchar](255) NULL,[Column 23] [varchar](255) NULL,[Column 24] [varchar](255) NULL,[Column 25] [varchar](255) NULL,[Column 26] [varchar](255) NULL,[Column 27] [varchar](255) NULL,[Column 28] [varchar](255) NULL,[Column 29] [varchar](255) NULL,[Column 30] [varchar](255) NULL,[Column 31] [varchar](255) NULL,[Column 32] [varchar](255) NULL,[Column 33] [varchar](255) NULL,[Column 34] [varchar](255) NULL,[Column 35] [varchar](255) NULL,[Column 36] [varchar](255) NULL,[Column 37] [varchar](255) NULL,[Column 38] [varchar](255) NULL,[Column 39] [varchar](255) NULL,[Column 40] [varchar](255) NULL,[Column 41] [varchar](255) NULL,[Column 42] [varchar](255) NULL,[Column 43] [varchar](255) NULL,[Column 44] [varchar](255) NULL,[Column 45] [varchar](255) NULL,[Column 46] [varchar](255) NULL,[Column 47] [varchar](255) NULL,[Column 48] [varchar](255) NULL,[Column 49] [varchar](255) NULL,[Column 50] [varchar](255) NULL,[Column 51] [varchar](255) NULL,[Column 52] [varchar](255) NULL,[Column 53] [varchar](255) NULL,[Column 54] [varchar](255) NULL,[Column 55] [varchar](255) NULL,[Column 56] [varchar](255) NULL,[Column 57] [varchar](255) NULL,[Column 58] [varchar](255) NULL,[Column 59] [varchar](255) NULL,[Column 60] [varchar](255) NULL,[Column 61] [varchar](255) NULL,[Column 62] [varchar](255) NULL,[Column 63] [varchar](255) NULL,[Column 64] [varchar](255) NULL,[Column 65] [varchar](255) NULL,[Column 66] [varchar](255) NULL,[Column 67] [varchar](255) NULL,[Column 68] [varchar](255) NULL,[Column 69] [varchar](255) NULL,[Column 70] [varchar](255) NULL,[Column 71] [varchar](255) NULL,[Column 72] [varchar](255) NULL,[Column 73] [varchar](255) NULL,[Column 74] [varchar](255) NULL,[Column 75] [varchar](255) NULL,[Column 76] [varchar](255) NULL,[Column 77] [varchar](255) NULL,[Column 78] [varchar](255) NULL,[Column 79] [varchar](255) NULL,[Column 80] [varchar](255) NULL,[Column 81] [varchar](255) NULL,[Column 82] [varchar](255) NULL,[Column 83] [varchar](255) NULL,[Column 84] [varchar](255) NULL,[Column 85] [varchar](255) NULL,[Column 86] [varchar](255) NULL,[Column 87] [varchar](255) NULL,[Column 88] [varchar](255) NULL,[Column 89] [varchar](255) NULL,[Column 90] [varchar](255) NULL,[Column 91] [varchar](255) NULL,[Column 92] [varchar](255) NULL,[Column 93] [varchar](255) NULL,[Column 94] [varchar](255) NULL,[Column 95] [varchar](255) NULL,[Column 96] [varchar](255) NULL,[Column 97] [varchar](255) NULL,[Column 98] [varchar](255) NULL,[Column 99] [varchar](255) NULL,[Column 100] [varchar](255) NULL,[Column 101] [varchar](255) NULL,[Column 102] [varchar](255) NULL,[Column 103] [varchar](255) NULL,[Column 104] [varchar](255) NULL,[Column 105] [varchar](255) NULL,[Column 106] [varchar](255) NULL,[Column 107] [varchar](255) NULL,[Column 108] [varchar](255) NULL,[Column 109] [varchar](255) NULL,[Column 110] [varchar](255) NULL,[Column 111] [varchar](255) NULL,[Column 112] [varchar](255) NULL,[Column 113] [varchar](255) NULL,[Column 114] [varchar](255) NULL,[Column 115] [varchar](255) NULL,[Column 116] [varchar](255) NULL,[Column 117] [varchar](255) NULL,[Column 118] [varchar](255) NULL,[Column 119] [varchar](255) NULL,[Column 120] [varchar](255) NULL,[Column 121] [varchar](255) NULL,[Column 122] [varchar](255) NULL,[Column 123] [varchar](255) NULL,[Column 124] [varchar](255) NULL,[Column 125] [varchar](255) NULL,[Column 126] [varchar](255) NULL,[Column 127] [varchar](255) NULL,[Column 128] [varchar](255) NULL,[Column 129] [varchar](255) NULL,[Column 130] [varchar](255) NULL,[Column 131] [varchar](255) NULL,[Column 132] [varchar](255) NULL,[Column 133] [varchar](255) NULL,[Column 134] [varchar](255) NULL,[Column 135] [varchar](255) NULL,[Column 136] [varchar](255) NULL,[Column 137] [varchar](255) NULL,[Column 138] [varchar](255) NULL,[Column 139] [varchar](255) NULL,[Column 140] [varchar](255) NULL,[Column 141] [varchar](255) NULL,[Column 142] [varchar](255) NULL,[Column 143] [varchar](255) NULL,[Column 144] [varchar](255) NULL,[Column 145] [varchar](255) NULL,[Column 146] [varchar](255) NULL,[Column 147] [varchar](255) NULL,[Column 148] [varchar](255) NULL,[Column 149] [varchar](255) NULL,[Column 150] [varchar](255) NULL,[Column 151] [varchar](255) NULL,[Column 152] [varchar](255) NULL,[Column 153] [varchar](255) NULL,[Column 154] [varchar](255) NULL,[Column 155] [varchar](255) NULL,[Column 156] [varchar](255) NULL,[Column 157] [varchar](255) NULL,[Column 158] [varchar](255) NULL,[Column 159] [varchar](255) NULL,[Column 160] [varchar](255) NULL,[Column 161] [varchar](255) NULL,[Column 162] [varchar](255) NULL,[Column 163] [varchar](255) NULL,[Column 164] [varchar](255) NULL,[Column 165] [varchar](255) NULL,[Column 166] [varchar](255) NULL,[Column 167] [varchar](255) NULL,[Column 168] [varchar](255) NULL,[Column 169] [varchar](255) NULL,[Column 170] [varchar](255) NULL,[Column 171] [varchar](255) NULL,[Column 172] [varchar](255) NULL,[Column 173] [varchar](255) NULL,[Column 174] [varchar](255) NULL,[Column 175] [varchar](255) NULL,[Column 176] [varchar](255) NULL,[Column 177] [varchar](255) NULL,[Column 178] [varchar](255) NULL,[Column 179] [varchar](255) NULL,[Column 180] [varchar](255) NULL,[Column 181] [varchar](255) NULL,[Column 182] [varchar](255) NULL,[Column 183] [varchar](255) NULL,[Column 184] [varchar](255) NULL,[Column 185] [varchar](255) NULL,[Column 186] [varchar](255) NULL,[Column 187] [varchar](255) NULL,[Column 188] [varchar](255) NULL,[Column 189] [varchar](255) NULL,[Column 190] [varchar](255) NULL,[Column 191] [varchar](255) NULL,[Column 192] [varchar](255) NULL,[Column 193] [varchar](255) NULL,[Column 194] [varchar](255) NULL,[Column 195] [varchar](255) NULL,[Column 196] [varchar](255) NULL,[Column 197] [varchar](255) NULL,[Column 198] [varchar](255) NULL,[Column 199] [varchar](255) NULL,[Column 200] [varchar](255) NULL,[Column 201] [varchar](255) NULL,[Column 202] [varchar](255) NULL,[Column 203] [varchar](255) NULL,[Column 204] [varchar](255) NULL,[Column 205] [varchar](255) NULL,[Column 206] [varchar](255) NULL,[Column 207] [varchar](255) NULL,[Column 208] [varchar](255) NULL,[Column 209] [varchar](255) NULL,[Column 210] [varchar](255) NULL,[Column 211] [varchar](255) NULL,[Column 212] [varchar](255) NULL,[Column 213] [varchar](255) NULL,[Column 214] [varchar](255) NULL,[Column 215] [varchar](255) NULL,[Column 216] [varchar](255) NULL,[Column 217] [varchar](255) NULL,[Column 218] [varchar](255) NULL,[Column 219] [varchar](255) NULL,[Column 220] [varchar](255) NULL,[Column 221] [varchar](255) NULL,[Column 222] [varchar](255) NULL,[Column 223] [varchar](255) NULL,[Column 224] [varchar](255) NULL,[Column 225] [varchar](255) NULL,[Column 226] [varchar](255) NULL,[Column 227] [varchar](255) NULL,[Column 228] [varchar](255) NULL,[Column 229] [varchar](255) NULL,[Column 230] [varchar](255) NULL,[Column 231] [varchar](255) NULL,[Column 232] [varchar](255) NULL,[Column 233] [varchar](255) NULL,[Column 234] [varchar](255) NULL,[Column 235] [varchar](255) NULL,[Column 236] [varchar](255) NULL,[Column 237] [varchar](255) NULL,[Column 238] [varchar](255) NULL,[Column 239] [varchar](255) NULL,[Column 240] [varchar](255) NULL,[Column 241] [varchar](255) NULL,[Column 242] [varchar](255) NULL,[Column 243] [varchar](255) NULL,[Column 244] [varchar](255) NULL,[Column 245] [varchar](255) NULL,[Column 246] [varchar](255) NULL,[Column 247] [varchar](255) NULL,[Column 248] [varchar](255) NULL,[Column 249] [varchar](255) NULL,[Column 250] [varchar](255) NULL,[Column 251] [varchar](255) NULL,[Column 252] [varchar](255) NULL,[Column 253] [varchar](255) NULL,[Column 254] [varchar](255) NULL,[Column 255] [varchar](255) NULL,[Column 256] [varchar](255) NULL,[Column 257] [varchar](255) NULL,[Column 258] [varchar](255) NULL,[Column 259] [varchar](255) NULL,[Column 260] [varchar](255) NULL,[Column 261] [varchar](255) NULL,[Column 262] [varchar](255) NULL,[Column 263] [varchar](255) NULL,[Column 264] [varchar](255) NULL,[Column 265] [varchar](255) NULL,[Column 266] [varchar](255) NULL,[Column 267] [varchar](255) NULL,[Column 268] [varchar](255) NULL,[Column 269] [varchar](255) NULL,[Column 270] [varchar](255) NULL,[Column 271] [varchar](255) NULL,[Column 272] [varchar](255) NULL,[Column 273] [varchar](255) NULL,[Column 274] [varchar](255) NULL,[Column 275] [varchar](255) NULL,[Column 276] [varchar](255) NULL,[Column 277] [varchar](255) NULL,[Column 278] [varchar](255) NULL,[Column 279] [varchar](255) NULL,[Column 280] [varchar](255) NULL,[Column 281] [varchar](255) NULL,[Column 282] [varchar](255) NULL,[Column 283] [varchar](255) NULL,[Column 284] [varchar](255) NULL,[Column 285] [varchar](255) NULL,[Column 286] [varchar](255) NULL,[Column 287] [varchar](255) NULL,[Column 288] [varchar](255) NULL)"
                    cmd.ExecuteNonQuery()
                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(2, "Import Dat File: " & DatFileName)
                    cmd.CommandText = "BULK INSERT  [#Temp_GMPS_REMIFM] FROM '" & DatFileName & "' with (FIRSTROW = 1,fieldterminator = '|')"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Add ID to Temporary Table")
                    cmd.CommandText = "ALTER TABLE [#Temp_GMPS_REMIFM] ADD [ID] [int] IDENTITY(1,1) NOT NULL"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Delete Duplicates in Temporary Table")
                    cmd.CommandText = "DELETE FROM [#Temp_GMPS_REMIFM] where [ID] not in (Select Min([ID]) from [#Temp_GMPS_REMIFM] group by [Column 0])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Insert Data to GMPS_IREMFM from Temporary Table")
                    cmd.CommandText = "INSERT INTO [GMPS_REMIFM]([EM00KEY0],[EM00KEY1],[EM00KEY2],[EM00KEY3],[EM00KEY4],[RECORDTYPE],[REMITTANCEREF],[EVENTNUMBER],[INOUTINTERBR],[TRANSACTIONDATE],[VALUEDATE],[DRCRDATE],[METHOD],[DDCONO],[BENEREIMBKID],[BENEREIMBKNM],[BENEREIMBKBR],[BENEREIMBKAD1],[BENEREIMBKAD2],[BENEREIMBKAD3],[BENEREIMBKCTY],[BENEREIMBKTLX_MessageSource],[BENEREIMSWIFT_TAG52_57],[BENEREIMBKREF],[BRANCHACNO],[RECERCORRID],[RECERCORRNAME],[RECERCORRBR],[RECERCORRADD1],[RECERCORRADD2],[RECERCORRADD3],[RECERCORRCTY],[RECERTLXNO_MessageType],[RECERSWIFT_TAG54],[REMITTERSID],[REMITTERSNAME],[REMITTERSADD1],[REMITTERSADD2],[REMITTERSADD3],[REMITTERSREF],[REMITTERSACNO_TAG50_ACC],[TOFMBKCHATSID],[TOFMBKNAME],[FROMBANKREFNO],[BENEACNO],[BENEFICIARYID],[BENEFICIARYNAME],[BENEFICIARYADD1],[BENEFICIARYADD2],[BENEFICIARYADD3],[ACWITHINTRMBK],[TRANSACTIONCCY],[TRANSACTIONAMT],[FROMINWARDREMI],[CORRBANKCHARGE],[TOTALPROCEEDS],[DRCRCURRENCY],[NETCHARGEAMT],[USDEQURATE],[SELLINGRATE],[BUYINGRATE],[NETAMOUNT],[CHARGEINLIEU],[TIERAMTUSD1],[TIERAMTUSD2],[TIERAMTUSD3],[INLIEUAMT1],[INLIEUAMT2],[INLIEUAMT3],[INLIEURATE1],[INLIEURATE2],[INLIEURATE3],[TOTALINLIEU],[INLIEUCOMCHG],[CORRBANKFEE],[HANDLINGFEE],[CABLECHARGES],[POSTAGE],[CREDITCLIENTFG],[OUTWARDREMIT],[DRCRAMOUNT],[RELATEDREF],[PAYMENTDETAILS],[BKTOBKINFO],[USERID],[SYSTEMDATE],[REMITCONTROLFG],[HKDEQUAMOUNT],[SWIFTINREF],[ORDERCUSTNAME],[ORDERCUSTADD],[REVENUE1AC],[REVENUE1CCY],[REVENUE1AMT],[REVENUE2AC],[REVENUE2CCY],[REVENUE2AMT],[SWFIIBSREF],[REMITTERSADD4],[BENEFICIARYADD4],[ORDERINGBKID],[ORDERINGBKNAME],[ORDERINGBKADD1],[ORDERINGBKADD2],[ORDERINGBKSWIF],[SENDERCORBKID],[SENDERCORBKNA],[SENDERCORBKBR],[SENDERCORBKSW],[ACINSTITID],[ACINSTITNAME],[ACINSTITBR],[ACINSTITADD1],[ACINSTITADD2],[ACINSTITSWIFT],[EXCHANGERATE],[SETTLEDCCY],[SETTLEDAMOUNT],[TRANSACTIONREF],[OURBRANCHID],[OURBRANCHNAME_MessageReceiver],[DOCUMENTTYPE],[FIELD122],[PARASET],[PARAC],[ENTRYTYPE],[FILETYPE],[HOLDUSER],[HOLDDATE],[HOLDFUNC_SENDER_BIC],[STATUS],[RELCODE],[RELUSER],[VOUCHERNO],[TFHOLDMARK],[UPDATEUSER],[UPDATADATE],[CALSAVENO],[CLSTATUS],[CHECKCODE],[CHECKUSER],[REVFILLER],[EXCHGRATE],[Feecurr],[Column 288])SELECT [Column 0] as 'EM00KEY0',[Column 2]as 'EM00KEY1',[Column 4]as 'EM00KEY2',[Column 6]as 'EM00KEY3',[Column 8]as 'EM00KEY4',[Column 10] as 'RECORDTYPE',[Column 12] as 'REMITTANCEREF',[Column 14] as 'EVENTNUMBER',[Column 16] as 'INOUTINTERBR',Convert(datetime,[column 18]) as 'TRANSACTIONDATE',Convert(datetime,[column 20]) as 'VALUEDATE',Convert(datetime,[column 22]) as 'DRCRDATE',[Column 24] as 'METHOD',[Column 26] as 'DDCONO',[Column 28] as 'BENEREIMBKID',[Column 30] as 'BENEREIMBKNM',[Column 32] as 'BENEREIMBKBR',[Column 34] as 'BENEREIMBKAD1',[Column 36] as 'BENEREIMBKAD2',[Column 38] as 'BENEREIMBKAD3',[Column 40] as 'BENEREIMBKCTY',UPPER([Column 42]) as 'BENEREIMBKTLX-Message Source',[Column 44] as 'BENEREIMSWIFT-TAG52/57',[Column 46] as 'BENEREIMBKREF',[Column 48] as 'BRANCHACNO',[Column 50] as 'RECERCORRID',[Column 52] as 'RECERCORRNAME',[Column 54] as 'RECERCORRBR',[Column 56] as 'RECERCORRADD1',[Column 58] as 'RECERCORRADD2',[Column 60] as 'RECERCORRADD3',[Column 62] as 'RECERCORRCTY',[Column 64] as 'RECERTLXNO-MessageType',[Column 66] as 'RECERSWIFT-TAG54',UPPER([Column 68]) as 'REMITTERSID',UPPER([Column 70]) as 'REMITTERSNAME',UPPER([Column 72]) as 'REMITTERSADD1',UPPER([Column 74]) as 'REMITTERSADD2',UPPER([Column 76]) as 'REMITTERSADD3',[Column 78] as 'REMITTERSREF',[Column 80] as 'REMITTERSACNO-TAG50-ACC',[Column 82] as 'TOFMBKCHATSID',[Column 84] as 'TOFMBKNAME',[Column 86] as 'FROMBANKREFNO',UPPER([Column 88]) as 'BENEACNO',UPPEr([Column 90]) as 'BENEFICIARYID',UPPER([Column 92]) as 'BENEFICIARYNAME',UPPER([Column 94]) as 'BENEFICIARYADD1',UPPER([Column 96]) as 'BENEFICIARYADD2',UPPER([Column 98]) as 'BENEFICIARYADD3',[Column 100] as 'ACWITHINTRMBK',[Column 102] as 'TRANSACTIONCCY',Case when ISNUMERIC([Column 104])=1 and LEN([Column 104])<=2 then convert(float,'0' + '.' + RIGHT([Column 104],2))when ISNUMERIC([Column 104])=1 and LEN([Column 104])=3 then convert(float,LEFT([Column 104],1) + '.' + RIGHT([Column 104],2))when ISNUMERIC([Column 104])=1 and LEN([Column 104])>3 then convert(float,LEFT([Column 104],len([Column 104])-2) + '.' + RIGHT([Column 104],2)) else 0 end as 'TRANSACTIONAMT',Case when ISNUMERIC([Column 106])=1 and LEN([Column 106])<=2 then convert(float,'0' + '.' + RIGHT([Column 106],2))when ISNUMERIC([Column 106])=1 and LEN([Column 106])=3 then convert(float,LEFT([Column 106],1) + '.' + RIGHT([Column 106],2))when ISNUMERIC([Column 106])=1 and LEN([Column 106])>3 then convert(float,LEFT([Column 106],len([Column 106])-2) + '.' + RIGHT([Column 106],2)) else 0 end as 'FROMINWARDREMI',Case when ISNUMERIC([Column 108])=1 and LEN([Column 108])<=2 then convert(float,'0' + '.' + RIGHT([Column 108],2))when ISNUMERIC([Column 108])=1 and LEN([Column 108])=3 then convert(float,LEFT([Column 108],1) + '.' + RIGHT([Column 108],2))when ISNUMERIC([Column 108])=1 and LEN([Column 108])>3 then convert(float,LEFT([Column 108],len([Column 108])-2) + '.' + RIGHT([Column 108],2)) else 0 end as 'CORRBANKCHARGE',Case when ISNUMERIC([Column 110])=1 and LEN([Column 110])<=2 then convert(float,'0' + '.' + RIGHT([Column 110],2))when ISNUMERIC([Column 110])=1 and LEN([Column 110])=3 then convert(float,LEFT([Column 110],1) + '.' + RIGHT([Column 110],2))when ISNUMERIC([Column 110])=1 and LEN([Column 110])>3 then convert(float,LEFT([Column 110],len([Column 110])-2) + '.' + RIGHT([Column 110],2)) else 0 end as 'TOTALPROCEEDS',[Column 114] as 'DRCRCURRENCY',Case when ISNUMERIC([Column 112])=1 and LEN([Column 112])<=2 then convert(float,'0' + '.' + RIGHT([Column 112],2))when ISNUMERIC([Column 112])=1 and LEN([Column 112])=3 then convert(float,LEFT([Column 112],1) + '.' + RIGHT([Column 112],2))when ISNUMERIC([Column 112])=1 and LEN([Column 112])>3 then convert(float,LEFT([Column 112],len([Column 112])-2) + '.' + RIGHT([Column 112],2)) else 0 end as 'NETCHARGEAMT',0 as 'USDEQURATE',[Column 118] as 'SELLINGRATE',[Column 120] as 'BUYINGRATE',Case when ISNUMERIC([Column 122])=1 and LEN([Column 122])<=2 then convert(float,'0' + '.' + RIGHT([Column 122],2))when ISNUMERIC([Column 122])=1 and LEN([Column 122])=3 then convert(float,LEFT([Column 122],1) + '.' + RIGHT([Column 122],2))when ISNUMERIC([Column 122])=1 and LEN([Column 122])>3 then convert(float,LEFT([Column 122],len([Column 122])-2) + '.' + RIGHT([Column 122],2)) else 0 end as 'NETAMOUNT',[Column 124] as 'CHARGEINLIEU',[Column 126] as 'TIERAMTUSD1',[Column 128] as 'TIERAMTUSD2',[Column 130] as 'TIERAMTUSD3',[Column 132] as 'INLIEUAMT1',[Column 134] as 'INLIEUAMT2',[Column 136] as 'INLIEUAMT3',[Column 138] as 'INLIEURATE1',[Column 140] as 'INLIEURATE2',[Column 142] as 'INLIEURATE3',[Column 144] as 'TOTALINLIEU',[Column 146] as 'INLIEUCOMCHG',[Column 148] as 'CORRBANKFEE',Case when ISNUMERIC([Column 150])=1 and LEN([Column 150])<=2 then convert(float,'0' + '.' + RIGHT([Column 150],2))when ISNUMERIC([Column 150])=1 and LEN([Column 150])=3 then convert(float,LEFT([Column 150],1) + '.' + RIGHT([Column 150],2))when ISNUMERIC([Column 150])=1 and LEN([Column 150])>3 then convert(float,LEFT([Column 150],len([Column 150])-2) + '.' + RIGHT([Column 150],2)) else 0 end as 'HANDLINGFEE',Case when ISNUMERIC([Column 152])=1 and LEN([Column 152])<=2 then convert(float,'0' + '.' + RIGHT([Column 152],2))when ISNUMERIC([Column 152])=1 and LEN([Column 152])=3 then convert(float,LEFT([Column 152],1) + '.' + RIGHT([Column 152],2))when ISNUMERIC([Column 152])=1 and LEN([Column 152])>3 then convert(float,LEFT([Column 152],len([Column 152])-2) + '.' + RIGHT([Column 152],2)) else 0 end as 'CABLECHARGES',Case when ISNUMERIC([Column 154])=1 and LEN([Column 154])<=2 then convert(float,'0' + '.' + RIGHT([Column 154],2))when ISNUMERIC([Column 154])=1 and LEN([Column 154])=3 then convert(float,LEFT([Column 154],1) + '.' + RIGHT([Column 154],2))when ISNUMERIC([Column 154])=1 and LEN([Column 154])>3 then convert(float,LEFT([Column 154],len([Column 154])-2) + '.' + RIGHT([Column 154],2)) else 0 end as 'POSTAGE',[Column 156] as 'CREDITCLIENTFG',Case when ISNUMERIC([Column 158])=1 and LEN([Column 158])<=2 then convert(float,'0' + '.' + RIGHT([Column 158],2))when ISNUMERIC([Column 158])=1 and LEN([Column 158])=3 then convert(float,LEFT([Column 158],1) + '.' + RIGHT([Column 158],2))when ISNUMERIC([Column 158])=1 and LEN([Column 158])>3 then convert(float,LEFT([Column 158],len([Column 158])-2) + '.' + RIGHT([Column 158],2)) else 0 end as 'OUTWARDREMIT',Case  when ISNUMERIC([Column 160])=1 and LEN([Column 160])>3 then convert(float,LEFT([Column 160],len([Column 160])-2) + '.' + RIGHT([Column 160],2)) else [Column 160] end as 'DRCRAMOUNT',[Column 162] as 'RELATEDREF',UPPER([Column 164]) as 'PAYMENTDETAILS',[Column 166] as 'BKTOBKINFO',[Column 168] as 'USERID',Convert(datetime,[column 170]) as 'SYSTEMDATE',[Column 172] as 'REMITCONTROLFG',Case when ISNUMERIC([Column 174])=1 and LEN([Column 174])<=2 then convert(float,'0' + '.' + RIGHT([Column 174],2))when ISNUMERIC([Column 174])=1 and LEN([Column 174])=3 then convert(float,LEFT([Column 174],1) + '.' + RIGHT([Column 174],2))when ISNUMERIC([Column 174])=1 and LEN([Column 174])>3 then convert(float,LEFT([Column 174],len([Column 174])-2) + '.' + RIGHT([Column 174],2)) else 0 end as 'HKDEQUAMOUNT',[Column 176] as 'SWIFTINREF',UPPER([Column 178]) as 'ORDERCUSTNAME',UPPER([Column 180]) as 'ORDERCUSTADD',[Column 182] as 'REVENUE1AC',[Column 184] as 'REVENUE1CCY',[Column 186] as 'REVENUE1AMT',[Column 188] as 'REVENUE2AC',[Column 190] as 'REVENUE2CCY',[Column 192] as 'REVENUE2AMT',[Column 194] as 'SWFIIBSREF',[Column 196] as 'REMITTERSADD4',UPPER([Column 198]) as 'BENEFICIARYADD4',[Column 200] as 'ORDERINGBKID',[Column 202] as 'ORDERINGBKNAME',[Column 204] as 'ORDERINGBKADD1',[Column 206] as 'ORDERINGBKADD2',[Column 208] as 'ORDERINGBKSWIF',[Column 210] as 'SENDERCORBKID',[Column 212] as 'SENDERCORBKNA',[Column 214] as 'SENDERCORBKBR',[Column 216] as 'SENDERCORBKSW',[Column 218] as 'ACINSTITID',[Column 220] as 'ACINSTITNAME',[Column 222] as 'ACINSTITBR',[Column 224] as 'ACINSTITADD1',[Column 226] as 'ACINSTITADD2',[Column 228] as 'ACINSTITSWIFT',0 as 'EXCHANGERATE',[Column 232] as 'SETTLEDCCY',Case when ISNUMERIC([Column 234])=1 and LEN([Column 234])<=2 then convert(float,'0' + '.' + RIGHT([Column 234],2))when ISNUMERIC([Column 234])=1 and LEN([Column 234])=3 then convert(float,LEFT([Column 234],1) + '.' + RIGHT([Column 234],2))when ISNUMERIC([Column 234])=1 and LEN([Column 234])>3 then convert(float,LEFT([Column 234],len([Column 234])-2) + '.' + RIGHT([Column 234],2)) else 0 end as 'SETTLEDAMOUNT',[Column 236] as 'TRANSACTIONREF',[Column 238] as 'OURBRANCHID',[Column 240] as 'OURBRANCHNAME-MessageReceiver',[Column 242] as 'DOCUMENTTYPE',[Column 244] as 'FIELD122',[Column 246] as 'PARASET',[Column 248] as 'PARAC',[Column 250] as 'ENTRYTYPE',[Column 252] as 'FILETYPE',[Column 254] as 'HOLDUSER',[Column 256] as 'HOLDDATE',[Column 258] as 'HOLDFUNC-SENDER BIC',[Column 260] as 'STATUS',[Column 262] as 'RELCODE',[Column 264] as 'RELUSER',[Column 266] as 'VOUCHERNO',[Column 268] as 'TFHOLDMARK',[Column 270] as 'UPDATEUSER',Convert(datetime,[column 272]) as 'UPDATADATE',[Column 274] as 'CALSAVENO',[Column 276] as 'CLSTATUS',[Column 278] as 'CHECKCODE',[Column 280] as 'CHECKUSER',[Column 282] as 'REVFILLER',0 as 'EXCHGRATE',[Column 286] as 'Feecurr',[Column 288] FROM [#Temp_GMPS_REMIFM] where [Column 0] not in (Select EM00KEY0 from GMPS_REMIFM)"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Drop Temporary Table")
                    cmd.CommandText = "DROP TABLE [#Temp_GMPS_REMIFM]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Delete Duplicates from GMPS_REMIFM")
                    cmd.CommandText = "DELETE FROM [GMPS_REMIFM] where [ID] not in (Select Min([ID]) from [GMPS_REMIFM] group by [EM00KEY0])"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(2, "Insert Data from GMPS_REMIFM (Incoming) to ODAS REMMITANCES")
                    cmd.CommandText = "INSERT INTO [ODAS REMMITANCES]([EM00KEY0],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[PAYMENTDETAILS],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[Deal Amount],[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC])SELECT [EM00KEY0],[EM00KEY1],[EM00KEY2],REMITTANCEREF,INOUTINTERBR,'METHOD'=Case when BENEREIMBKTLX_MessageSource in ('TARGET2 MESSAGE') then 'TGT103' when BENEREIMBKTLX_MessageSource in ('SEPA MESSAGE') then 'SCT103' when BENEREIMBKTLX_MessageSource in ('MAINLAND MESSAGE') then 'MT103+IBRS103' else 'MT103' end,NULL,'CHINA CONSTRACTION BANK','FRANKFURT','PCBCDEFFXXX',NULL,NULL,NULL,NULL,'CHINA CONSTRACTION BANK','FRANKFURT','PCBCDEFFXXX',NULL,NULL,NULL,NULL,BENEACNO,BENEFICIARYID,BENEFICIARYNAME,NULL,BENEFICIARYADD1,BENEFICIARYADD2,PAYMENTDETAILS,REVFILLER,NULL,[TRANSACTIONDATE],[VALUEDATE],TRANSACTIONCCY,TRANSACTIONAMT,[HANDLINGFEE],NULL,REMITTERSNAME,NULL,REMITTERSADD1,REMITTERSADD2,REMITTERSADD3,[SWIFTINREF],HOLDFUNC_SENDER_BIC from GMPS_REMIFM where INOUTINTERBR in ('I') and EM00KEY0 not in (Select [EM00KEY0] from [ODAS REMMITANCES])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Insert Data from GMPS_REMIFM (Outgoing) to ODAS REMMITANCES")
                    cmd.CommandText = "INSERT INTO [ODAS REMMITANCES]([EM00KEY0],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[PAYMENTDETAILS],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[Deal Amount],[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC])SELECT [EM00KEY0],[EM00KEY1],[EM00KEY2],REMITTANCEREF,INOUTINTERBR,'METHOD'=Case when BENEREIMBKTLX_MessageSource in ('TARGET2 MESSAGE') then 'TGT103' when BENEREIMBKTLX_MessageSource in ('SEPA MESSAGE') then 'SCT103' when BENEREIMBKTLX_MessageSource in ('MAINLAND MESSAGE') then 'MT103+IBRS103' else 'MT103' end,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,BENEREIMSWIFT_TAG52_57,ACINSTITNAME,ACINSTITBR,NULL,BENEACNO,BENEFICIARYID,BENEFICIARYNAME,NULL,BENEFICIARYADD1,BENEFICIARYADD2,PAYMENTDETAILS,REVFILLER,NULL,[TRANSACTIONDATE],[VALUEDATE],TRANSACTIONCCY,TRANSACTIONAMT,[HANDLINGFEE],REMITTERSID,REMITTERSNAME,NULL,REMITTERSADD1,REMITTERSADD2,REMITTERSADD3,[SWIFTINREF],HOLDFUNC_SENDER_BIC from GMPS_REMIFM where INOUTINTERBR in ('O') and EM00KEY0 not in (Select [EM00KEY0] from [ODAS REMMITANCES])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Insert Exchange Rates to ODAS REMMITANCES")
                    cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [ODAS REMMITANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[TRANSACTIONDATE]=B.[EXCHANGE RATE DATE]  and A.[CURRENCYCODE]=B.[CURRENCY CODE] where A.[CURRENCYCODE] not in ('EUR') and A.[Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [ODAS REMMITANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.VALUEDATE=B.[EXCHANGE RATE DATE]  and A.[CURRENCYCODE]=B.[CURRENCY CODE] where A.[CURRENCYCODE] not in ('EUR') and A.[Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Calculate Deal Amount Euro in ODAS REMMITANCES")
                    cmd.CommandText = "UPDATE [ODAS REMMITANCES] SET [Deal Amount Euro]=Round([Deal Amount]/[EXCHANGE_RATE],2) where  [Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Delete duplicates in ODAS REMMITANCES based on Field:EM00KEY0")
                    cmd.CommandText = "DELETE  FROM [ODAS REMMITANCES] where [ID] not in (Select Min([ID]) from [ODAS REMMITANCES] group by [EM00KEY0])"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(100, "Import procedure: GMPS INTERFACE REMIFM is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & DatFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:GMPS INTERFACE REMIFM is not VALID+++")

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

    Private Sub GMPS_IMPORT_CREMFM()
        Try
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            CURRENT_PROC = "GMPS_INTERFACE_CREMFM"
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

            'Dim rd As Date
            'Dim rdsql As String = ""

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If

            cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='GMPS INTERFACE CREMFM' and [Valid]='Y'"
            cmd.Connection.Open()

            If cmd.ExecuteScalar > 0 Then
                Me.BgwOCBSimport.ReportProgress(1, "Procedure:" & CURRENT_PROC & " - " & "Start import procedure: GMPS INTERFACE CREMFM")
                Dim DatFileName As String = ""
                If rd >= DateSerial(2018, 2, 1) Then
                    DatFileName = "\\ccb-nft\e$\INTERFACE\GMPS\" & rdsql & "\A0333_SAFEID_DC0070000_CREMFM_ADD_" & rdsql & "_0001.dat"
                ElseIf rd < DateSerial(2018, 2, 1) Then
                    DatFileName = "\\ccb-nft\e$\INTERFACE\GMPS\" & rdsql & "\A0333_130043_DC0070000_CREMFM_ADD_" & rdsql & "_0001.dat"
                End If
                Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import Dat File: " & DatFileName)

                If File.Exists(DatFileName) = True Then

                    cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_GMPS_CREMFM' AND xtype='U') DROP TABLE [#Temp_GMPS_CREMFM]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_GMPS_CREMFM' AND xtype='U') CREATE TABLE [#Temp_GMPS_CREMFM]([Column 0] [varchar](255) NULL,[Column 1] [varchar](255) NULL,[Column 2] [varchar](255) NULL,[Column 3] [varchar](255) NULL,[Column 4] [varchar](255) NULL,[Column 5] [varchar](255) NULL,[Column 6] [varchar](255) NULL,[Column 7] [varchar](255) NULL,[Column 8] [varchar](255) NULL,[Column 9] [varchar](255) NULL,[Column 10] [varchar](255) NULL,[Column 11] [varchar](255) NULL,[Column 12] [varchar](255) NULL,[Column 13] [varchar](255) NULL,[Column 14] [varchar](255) NULL,[Column 15] [varchar](255) NULL,[Column 16] [varchar](255) NULL,[Column 17] [varchar](255) NULL,[Column 18] [varchar](255) NULL,[Column 19] [varchar](255) NULL,[Column 20] [varchar](255) NULL,[Column 21] [varchar](255) NULL,[Column 22] [varchar](255) NULL,[Column 23] [varchar](255) NULL,[Column 24] [varchar](255) NULL,[Column 25] [varchar](255) NULL,[Column 26] [varchar](255) NULL,[Column 27] [varchar](255) NULL,[Column 28] [varchar](255) NULL,[Column 29] [varchar](255) NULL,[Column 30] [varchar](255) NULL,[Column 31] [varchar](255) NULL,[Column 32] [varchar](255) NULL,[Column 33] [varchar](255) NULL,[Column 34] [varchar](255) NULL,[Column 35] [varchar](255) NULL,[Column 36] [varchar](255) NULL,[Column 37] [varchar](255) NULL,[Column 38] [varchar](255) NULL,[Column 39] [varchar](255) NULL,[Column 40] [varchar](255) NULL,[Column 41] [varchar](255) NULL,[Column 42] [varchar](255) NULL,[Column 43] [varchar](255) NULL,[Column 44] [varchar](255) NULL,[Column 45] [varchar](255) NULL,[Column 46] [varchar](255) NULL,[Column 47] [varchar](255) NULL,[Column 48] [varchar](255) NULL,[Column 49] [varchar](255) NULL,[Column 50] [varchar](255) NULL,[Column 51] [varchar](255) NULL,[Column 52] [varchar](255) NULL,[Column 53] [varchar](255) NULL,[Column 54] [varchar](255) NULL,[Column 55] [varchar](255) NULL,[Column 56] [varchar](255) NULL,[Column 57] [varchar](255) NULL,[Column 58] [varchar](255) NULL,[Column 59] [varchar](255) NULL,[Column 60] [varchar](255) NULL,[Column 61] [varchar](255) NULL,[Column 62] [varchar](255) NULL,[Column 63] [varchar](255) NULL,[Column 64] [varchar](255) NULL,[Column 65] [varchar](255) NULL,[Column 66] [varchar](255) NULL,[Column 67] [varchar](255) NULL,[Column 68] [varchar](255) NULL,[Column 69] [varchar](255) NULL,[Column 70] [varchar](255) NULL,[Column 71] [varchar](255) NULL,[Column 72] [varchar](255) NULL,[Column 73] [varchar](255) NULL,[Column 74] [varchar](255) NULL,[Column 75] [varchar](255) NULL,[Column 76] [varchar](255) NULL,[Column 77] [varchar](255) NULL,[Column 78] [varchar](255) NULL,[Column 79] [varchar](255) NULL,[Column 80] [varchar](255) NULL,[Column 81] [varchar](255) NULL,[Column 82] [varchar](255) NULL,[Column 83] [varchar](255) NULL,[Column 84] [varchar](255) NULL,[Column 85] [varchar](255) NULL,[Column 86] [varchar](255) NULL,[Column 87] [varchar](255) NULL,[Column 88] [varchar](255) NULL,[Column 89] [varchar](255) NULL,[Column 90] [varchar](255) NULL,[Column 91] [varchar](255) NULL,[Column 92] [varchar](255) NULL,[Column 93] [varchar](255) NULL,[Column 94] [varchar](255) NULL,[Column 95] [varchar](255) NULL,[Column 96] [varchar](255) NULL,[Column 97] [varchar](255) NULL,[Column 98] [varchar](255) NULL,[Column 99] [varchar](255) NULL,[Column 100] [varchar](255) NULL,[Column 101] [varchar](255) NULL,[Column 102] [varchar](255) NULL,[Column 103] [varchar](255) NULL,[Column 104] [varchar](255) NULL,[Column 105] [varchar](255) NULL,[Column 106] [varchar](255) NULL,[Column 107] [varchar](255) NULL,[Column 108] [varchar](255) NULL,[Column 109] [varchar](255) NULL,[Column 110] [varchar](255) NULL,[Column 111] [varchar](255) NULL,[Column 112] [varchar](255) NULL,[Column 113] [varchar](255) NULL,[Column 114] [varchar](255) NULL,[Column 115] [varchar](255) NULL,[Column 116] [varchar](255) NULL,[Column 117] [varchar](255) NULL,[Column 118] [varchar](255) NULL,[Column 119] [varchar](255) NULL,[Column 120] [varchar](255) NULL,[Column 121] [varchar](255) NULL,[Column 122] [varchar](255) NULL,[Column 123] [varchar](255) NULL,[Column 124] [varchar](255) NULL,[Column 125] [varchar](255) NULL,[Column 126] [varchar](255) NULL,[Column 127] [varchar](255) NULL,[Column 128] [varchar](255) NULL,[Column 129] [varchar](255) NULL,[Column 130] [varchar](255) NULL,[Column 131] [varchar](255) NULL,[Column 132] [varchar](255) NULL,[Column 133] [varchar](255) NULL,[Column 134] [varchar](255) NULL,[Column 135] [varchar](255) NULL,[Column 136] [varchar](255) NULL,[Column 137] [varchar](255) NULL,[Column 138] [varchar](255) NULL,[Column 139] [varchar](255) NULL,[Column 140] [varchar](255) NULL,[Column 141] [varchar](255) NULL,[Column 142] [varchar](255) NULL,[Column 143] [varchar](255) NULL,[Column 144] [varchar](255) NULL,[Column 145] [varchar](255) NULL,[Column 146] [varchar](255) NULL,[Column 147] [varchar](255) NULL,[Column 148] [varchar](255) NULL,[Column 149] [varchar](255) NULL,[Column 150] [varchar](255) NULL,[Column 151] [varchar](255) NULL,[Column 152] [varchar](255) NULL,[Column 153] [varchar](255) NULL,[Column 154] [varchar](255) NULL,[Column 155] [varchar](255) NULL,[Column 156] [varchar](255) NULL,[Column 157] [varchar](255) NULL,[Column 158] [varchar](255) NULL,[Column 159] [varchar](255) NULL,[Column 160] [varchar](255) NULL,[Column 161] [varchar](255) NULL,[Column 162] [varchar](255) NULL,[Column 163] [varchar](255) NULL,[Column 164] [varchar](255) NULL,[Column 165] [varchar](255) NULL,[Column 166] [varchar](255) NULL,[Column 167] [varchar](255) NULL,[Column 168] [varchar](255) NULL,[Column 169] [varchar](255) NULL,[Column 170] [varchar](255) NULL,[Column 171] [varchar](255) NULL,[Column 172] [varchar](255) NULL,[Column 173] [varchar](255) NULL,[Column 174] [varchar](255) NULL,[Column 175] [varchar](255) NULL,[Column 176] [varchar](255) NULL,[Column 177] [varchar](255) NULL,[Column 178] [varchar](255) NULL,[Column 179] [varchar](255) NULL,[Column 180] [varchar](255) NULL,[Column 181] [varchar](255) NULL,[Column 182] [varchar](255) NULL,[Column 183] [varchar](255) NULL,[Column 184] [varchar](255) NULL,[Column 185] [varchar](255) NULL,[Column 186] [varchar](255) NULL,[Column 187] [varchar](255) NULL,[Column 188] [varchar](255) NULL,[Column 189] [varchar](255) NULL,[Column 190] [varchar](255) NULL,[Column 191] [varchar](255) NULL,[Column 192] [varchar](255) NULL,[Column 193] [varchar](255) NULL,[Column 194] [varchar](255) NULL,[Column 195] [varchar](255) NULL,[Column 196] [varchar](255) NULL,[Column 197] [varchar](255) NULL,[Column 198] [varchar](255) NULL,[Column 199] [varchar](255) NULL,[Column 200] [varchar](255) NULL,[Column 201] [varchar](255) NULL,[Column 202] [varchar](255) NULL,[Column 203] [varchar](255) NULL,[Column 204] [varchar](255) NULL,[Column 205] [varchar](255) NULL,[Column 206] [varchar](255) NULL,[Column 207] [varchar](255) NULL,[Column 208] [varchar](255) NULL,[Column 209] [varchar](255) NULL,[Column 210] [varchar](255) NULL,[Column 211] [varchar](255) NULL,[Column 212] [varchar](255) NULL,[Column 213] [varchar](255) NULL,[Column 214] [varchar](255) NULL,[Column 215] [varchar](255) NULL,[Column 216] [varchar](255) NULL,[Column 217] [varchar](255) NULL,[Column 218] [varchar](255) NULL,[Column 219] [varchar](255) NULL,[Column 220] [varchar](255) NULL,[Column 221] [varchar](255) NULL,[Column 222] [varchar](255) NULL,[Column 223] [varchar](255) NULL,[Column 224] [varchar](255) NULL,[Column 225] [varchar](255) NULL,[Column 226] [varchar](255) NULL,[Column 227] [varchar](255) NULL,[Column 228] [varchar](255) NULL,[Column 229] [varchar](255) NULL,[Column 230] [varchar](255) NULL,[Column 231] [varchar](255) NULL,[Column 232] [varchar](255) NULL,[Column 233] [varchar](255) NULL,[Column 234] [varchar](255) NULL,[Column 235] [varchar](255) NULL,[Column 236] [varchar](255) NULL,[Column 237] [varchar](255) NULL,[Column 238] [varchar](255) NULL,[Column 239] [varchar](255) NULL,[Column 240] [varchar](255) NULL,[Column 241] [varchar](255) NULL,[Column 242] [varchar](255) NULL,[Column 243] [varchar](255) NULL,[Column 244] [varchar](255) NULL,[Column 245] [varchar](255) NULL,[Column 246] [varchar](255) NULL,[Column 247] [varchar](255) NULL,[Column 248] [varchar](255) NULL,[Column 249] [varchar](255) NULL,[Column 250] [varchar](255) NULL,[Column 251] [varchar](255) NULL,[Column 252] [varchar](255) NULL,[Column 253] [varchar](255) NULL,[Column 254] [varchar](255) NULL,[Column 255] [varchar](255) NULL,[Column 256] [varchar](255) NULL,[Column 257] [varchar](255) NULL,[Column 258] [varchar](255) NULL,[Column 259] [varchar](255) NULL,[Column 260] [varchar](255) NULL,[Column 261] [varchar](255) NULL,[Column 262] [varchar](255) NULL,[Column 263] [varchar](255) NULL,[Column 264] [varchar](255) NULL,[Column 265] [varchar](255) NULL,[Column 266] [varchar](255) NULL,[Column 267] [varchar](255) NULL,[Column 268] [varchar](255) NULL,[Column 269] [varchar](255) NULL,[Column 270] [varchar](255) NULL,[Column 271] [varchar](255) NULL,[Column 272] [varchar](255) NULL,[Column 273] [varchar](255) NULL,[Column 274] [varchar](255) NULL,[Column 275] [varchar](255) NULL,[Column 276] [varchar](255) NULL,[Column 277] [varchar](255) NULL,[Column 278] [varchar](255) NULL,[Column 279] [varchar](255) NULL,[Column 280] [varchar](255) NULL,[Column 281] [varchar](255) NULL,[Column 282] [varchar](255) NULL,[Column 283] [varchar](255) NULL,[Column 284] [varchar](255) NULL,[Column 285] [varchar](255) NULL,[Column 286] [varchar](255) NULL,[Column 287] [varchar](255) NULL,[Column 288] [varchar](255) NULL,[Column 289] [varchar](255) NULL,[Column 290] [varchar](255) NULL,[Column 291] [varchar](255) NULL,[Column 292] [varchar](255) NULL,[Column 293] [varchar](255) NULL,[Column 294] [varchar](255) NULL,[Column 295] [varchar](255) NULL,[Column 296] [varchar](255) NULL,[Column 297] [varchar](255) NULL,[Column 298] [varchar](255) NULL,[Column 299] [varchar](255) NULL,[Column 300] [varchar](255) NULL,[Column 301] [varchar](255) NULL,[Column 302] [varchar](255) NULL) ON [PRIMARY]"
                    cmd.ExecuteNonQuery()
                    'Prüfen ob daten vorhanden sind DETAILS TABELLE
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Import Dat File: " & DatFileName)
                    cmd.CommandText = "BULK INSERT  [#Temp_GMPS_CREMFM] FROM '" & DatFileName & "' with (FIRSTROW = 1,fieldterminator = '|')"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Add ID to Temporary Table")
                    cmd.CommandText = "ALTER TABLE [#Temp_GMPS_CREMFM] ADD [ID] [int] IDENTITY(1,1) NOT NULL"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates in Temporary Table")
                    cmd.CommandText = "DELETE FROM [#Temp_GMPS_CREMFM] where [ID] not in (Select Min([ID]) from [#Temp_GMPS_CREMFM] group by [Column 0])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Insert Data to GMPS_IREMFM from Temporary Table")
                    cmd.CommandText = "INSERT INTO [GMPS_CREMFM]([EM00KEY0],[EM00KEY1],[EM00KEY2],[EM00KEY3],[EM00KEY4],[RECORDTYPE],[OURTRANREFNO],[EVENTNUMBER],[INWARDOUTWARD],[METHOD],[MT100],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[RECEIVERTELEX],[ORDERINGCUSTID],[ORDERINGCUSTNA],[ORDERINGCUSTBR],[ORDERINGCUSTA1],[ORDERINGCUSTST],[ORDERINGCUSTTX],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[INTERMEDIARYID],[INTERMEDIARYNA],[INTERMEDIARYBR],[INTERMEDIARYST],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[BENEFCUSTSWFIT],[BENEFCUSTTELEX],[DETOFPAYMENT],[DETOFCHARGE],[SETOREINFO],[CHATS],[ORDERINGBANKID],[ORDERINGBANKNA],[ORDERINGBANKBR],[ORDERINGBANKST],[ORDERINGBANKTX],[ORDERINGREF],[RELATEDREF],[CHATSRELREF],[PAYMENTCODE],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[USDEQURATE],[AMOUNT],[CHARGEINLIEU],[TIERAMTUSD1],[TIERAMTUSD2],[INLIEUAMT1],[INLIEUAMT2],[INLIEURATE1],[INLIEURATE2],[TOTALINLIEU],[INLIEUCOMMCHG],[HANDLINGFEE],[DRCRCURRENCY],[NETAMOUNT],[SENDINGAID],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[ORDERCUSTCTY],[ACWINSTID],[ACWINSTNAME],[ACWINSTBR],[ACWINSTBRN],[BENEFICIARYAID],[BENEFICIARYAC],[BENEFICIARYID],[BENEFICIARYNAME],[BENEFICIARYBR],[BENEFICIARYADR1],[BENEFICIARYADR2],[BENEFICIARYST],[BENEFICIARYTLX],[PAYMENTDETAILS],[BKTOBKINFORM],[USERID],[SYSTEMDATE],[REPORTNAME],[REPORTBR],[REPORTADDRESS1],[REPORTADDRESS2],[SWIFTINREF],[CHATSBANKID],[RECEIVINGPARTY],[SENDINGPARTY],[PAYMENTDETLN1],[BANKOPERCODE],[INSTRUCTIONCODE],[TXTYPECODE],[INSTRUCTEDCCY],[INSTRUCTEDAMT],[EXCHANGERATE],[SENDINGINSTIT1],[SENDINGINSTIT2],[THIRDREIMNAME],[THIRDREIMBR],[THIRDREIMST],[SENDERCCY],[SENDERAMT],[RECVRCCY],[RECVRAMT],[ORDERSHORTNAME],[ACWITHINSTLOC],[FIELD126],[PARASET],[PARAC],[ENTRYTYPE],[FILETYPE],[HOLDUSER],[HOLDDATE],[HOLDFUNC],[STATUS],[RELCODE],[RELUSER],[VOUCHERNO],[TFHOLDMARK],[UPDATEUSER],[UPDATADATE],[CALSAVENO],[CLSTATUS],[CHECKCODE],[CHECKUSER],[REVFILLER],[EXCHGRATE],[sourceID],[Feecurr],[cablecharge],[Postage],[Column 302])SELECT [Column 0] as 'EM00KEY0',[Column 2]as 'EM00KEY1',[Column 4]as 'EM00KEY2',[Column 6]as 'EM00KEY3',[Column 8]as 'EM00KEY4',[Column 10] as 'RECORDTYPE',[Column 12] as 'OURTRANREFNO',[Column 14] as 'EVENTNUMBER',[Column 16] as 'INWARDOUTWARD','METHOD'=Case when [Column 18]='1' then 'MT202+MT103' when [Column 18]='2' then 'MT103' when [Column 18]='3' then 'MT202' when [Column 18]='4' then 'MT202COV' when [Column 18]='5' then 'MT202COV+MT103' when [Column 18]='6' then 'TGT103' when [Column 18]='7' then 'TGT202' when [Column 18]='8' then 'TGT202+MT103' when [Column 18]='9' then 'TGT202COV' when [Column 18]='A' then 'TGT202COV+MT103'when [Column 18]='B' then 'EMZ103-DD' end,[column 20] as 'MT100',[column 22] as 'RECEIVERID',[column 24] as 'RECEIVERNAME',[Column 26] as 'RECEIVERBRANCH',[Column 28] as 'RECEIVERSWIFT',[Column 30] as 'RECEIVERTELEX',UPPER([Column 32]) as 'ORDERINGCUSTID',UPPER([Column 34]) as 'ORDERINGCUSTNA',UPPER([Column 36]) as 'ORDERINGCUSTBR',UPPER([Column 38]) as 'ORDERINGCUSTA1',UPPER([Column 40]) as 'ORDERINGCUSTST',UPPER([Column 42]) as 'ORDERINGCUSTTX',[Column 44] as 'SENDERCORRNAME',[Column 46] as 'SENDERCORRBR',[Column 48] as 'SENDERCORRST',[Column 50] as 'RECRCORRID',[Column 52] as 'RECRCORRNAME',[Column 54] as 'RECRCORRBR',[Column 56] as 'RECRCORRSWIFT',[Column 58] as 'INTERMEDIARYID',[Column 60] as 'INTERMEDIARYNA',[Column 62] as 'INTERMEDIARYBR',[Column 64] as 'INTERMEDIARYST',[Column 66] as 'ACWITHINSTID',[Column 68] as 'ACWITHINSTNA',[Column 70] as 'ACWITHINSTBR',[Column 72] as 'ACWITHINSTST',UPPER([Column 74]) as 'BENEFACNO',UPPER([Column 76]) as 'BENEFCUSTID',UPPER([Column 78]) as 'BENEFCUSTNAME',UPPER([Column 80]) as 'BENEFCUSTBR',UPPER([Column 82]) as 'BENEFCUSTADR1',UPPER([Column 84]) as 'BENEFCUSTADR2',[Column 86] as 'BENEFCUSTSWFIT',[Column 88] as 'BENEFCUSTTELEX',[Column 90] as 'DETOFPAYMENT','DETOFCHARGE'=Case when [Column 92] in ('1') then 'BEN' when [Column 92] in ('2') then 'OUR' when  [Column 92] in ('3') then 'SHA' end ,[Column 94] as 'SETOREINFO',[Column 96] as 'CHATS',[Column 98] as 'ORDERINGBANKID',[Column 100] as 'ORDERINGBANKNA',[Column 102] as 'ORDERINGBANKBR',[Column 104] as 'ORDERINGBANKST',[Column 106] as 'ORDERINGBANKTX',[Column 108] as 'ORDERINGREF',[Column 110] as 'RELATEDREF',[Column 112] as 'CHATSRELREF',[Column 114] as 'PAYMENTCODE',Convert(datetime,[column 116]) as 'TRANSACTIONDATE',Convert(datetime,[column 118]) as 'VALUEDATE',[Column 120] as 'CURRENCYCODE',[Column 122] as 'USDEQURATE',Case when ISNUMERIC([Column 124])=1 and LEN([Column 124])<=2 then convert(float,'0' + '.' + RIGHT([Column 124],2))when ISNUMERIC([Column 124])=1 and LEN([Column 124])=3 then convert(float,LEFT([Column 124],1) + '.' + RIGHT([Column 124],2))when ISNUMERIC([Column 124])=1 and LEN([Column 124])>3 then convert(float,LEFT([Column 124],len([Column 124])-2) + '.' + RIGHT([Column 124],2)) else 0 end as 'AMOUNT',Case when ISNUMERIC([Column 126])=1 and LEN([Column 126])<=2 then convert(float,'0' + '.' + RIGHT([Column 126],2))when ISNUMERIC([Column 126])=1 and LEN([Column 126])=3 then convert(float,LEFT([Column 126],1) + '.' + RIGHT([Column 126],2))when ISNUMERIC([Column 126])=1 and LEN([Column 126])>3 then convert(float,LEFT([Column 126],len([Column 126])-2) + '.' + RIGHT([Column 126],2)) else 0 end as 'CHARGEINLIEU',Case when ISNUMERIC([Column 128])=1 and LEN([Column 128])<=2 then convert(float,'0' + '.' + RIGHT([Column 128],2))when ISNUMERIC([Column 128])=1 and LEN([Column 128])=3 then convert(float,LEFT([Column 128],1) + '.' + RIGHT([Column 128],2))when ISNUMERIC([Column 128])=1 and LEN([Column 128])>3 then convert(float,LEFT([Column 128],len([Column 128])-2) + '.' + RIGHT([Column 128],2)) else 0 end as 'TIERAMTUSD1',Case when ISNUMERIC([Column 130])=1 and LEN([Column 130])<=2 then convert(float,'0' + '.' + RIGHT([Column 130],2))when ISNUMERIC([Column 130])=1 and LEN([Column 130])=3 then convert(float,LEFT([Column 130],1) + '.' + RIGHT([Column 130],2))when ISNUMERIC([Column 130])=1 and LEN([Column 130])>3 then convert(float,LEFT([Column 130],len([Column 130])-2) + '.' + RIGHT([Column 130],2)) else 0 end as 'TIERAMTUSD2',Case when ISNUMERIC([Column 132])=1 and LEN([Column 132])<=2 then convert(float,'0' + '.' + RIGHT([Column 132],2))when ISNUMERIC([Column 132])=1 and LEN([Column 132])=3 then convert(float,LEFT([Column 132],1) + '.' + RIGHT([Column 132],2))when ISNUMERIC([Column 132])=1 and LEN([Column 132])>3 then convert(float,LEFT([Column 132],len([Column 132])-2) + '.' + RIGHT([Column 132],2)) else 0 end as 'INLIEUAMT1',Case when ISNUMERIC([Column 134])=1 and LEN([Column 134])<=2 then convert(float,'0' + '.' + RIGHT([Column 134],2))when ISNUMERIC([Column 134])=1 and LEN([Column 134])=3 then convert(float,LEFT([Column 134],1) + '.' + RIGHT([Column 134],2))when ISNUMERIC([Column 134])=1 and LEN([Column 134])>3 then convert(float,LEFT([Column 134],len([Column 134])-2) + '.' + RIGHT([Column 134],2)) else 0 end as 'INLIEUAMT2',[Column 136] as 'INLIEURATE1',[Column 138] as 'INLIEURATE2',Case when ISNUMERIC([Column 140])=1 and LEN([Column 140])<=2 then convert(float,'0' + '.' + RIGHT([Column 140],2))when ISNUMERIC([Column 140])=1 and LEN([Column 140])=3 then convert(float,LEFT([Column 140],1) + '.' + RIGHT([Column 140],2))when ISNUMERIC([Column 140])=1 and LEN([Column 140])>3 then convert(float,LEFT([Column 140],len([Column 140])-2) + '.' + RIGHT([Column 140],2)) else 0 end as 'TOTALINLIEU',Case when ISNUMERIC([Column 142])=1 and LEN([Column 142])<=2 then convert(float,'0' + '.' + RIGHT([Column 142],2))when ISNUMERIC([Column 142])=1 and LEN([Column 142])=3 then convert(float,LEFT([Column 142],1) + '.' + RIGHT([Column 142],2))when ISNUMERIC([Column 142])=1 and LEN([Column 142])>3 then convert(float,LEFT([Column 142],len([Column 142])-2) + '.' + RIGHT([Column 142],2)) else 0 end as 'INLIEUCOMMCHG',Case when ISNUMERIC([Column 144])=1 and LEN([Column 144])<=2 then convert(float,'0' + '.' + RIGHT([Column 144],2))when ISNUMERIC([Column 144])=1 and LEN([Column 144])=3 then convert(float,LEFT([Column 144],1) + '.' + RIGHT([Column 144],2))when ISNUMERIC([Column 144])=1 and LEN([Column 144])>3 then convert(float,LEFT([Column 144],len([Column 144])-2) + '.' + RIGHT([Column 144],2)) else 0 end as 'HANDLINGFEE',[Column 146] as 'DRCRCURRENCY',Case when ISNUMERIC([Column 148])=1 and LEN([Column 148])<=2 then convert(float,'0' + '.' + RIGHT([Column 148],2))when ISNUMERIC([Column 148])=1 and LEN([Column 148])=3 then convert(float,LEFT([Column 148],1) + '.' + RIGHT([Column 148],2))when ISNUMERIC([Column 148])=1 and LEN([Column 148])>3 then convert(float,LEFT([Column 148],len([Column 148])-2) + '.' + RIGHT([Column 148],2)) else 0 end as 'NETAMOUNT',[Column 150] as 'SENDINGAID',UPPER([Column 152]) as 'ORDERCUSTID',UPPER([Column 154]) as 'ORDERCUSTNAME',UPPER([Column 156]) as 'ORDERCUSTBR',UPPER([Column 158]) as 'ORDERCUSTADD1',UPPER([Column 160]) as 'ORDERCUSTADD2',UPPER([Column 162]) as 'ORDERCUSTADD3',UPPER([Column 164]) as 'ORDERCUSTCTY',[Column 166] as 'ACWINSTID',[Column 168] as 'ACWINSTNAME',[column 170] as 'ACWINSTBR',[Column 172] as 'ACWINSTBRN',UPPER([Column 174]) as 'BENEFICIARYAID',UPPER([Column 176]) as 'BENEFICIARYAC',UPPER([Column 178]) as 'BENEFICIARYID',UPPER([Column 180]) as 'BENEFICIARYNAME',UPPER([Column 182]) as 'BENEFICIARYBR',UPPER([Column 184]) as 'BENEFICIARYADR1',UPPER([Column 186]) as 'BENEFICIARYADR2',UPPER([Column 188]) as 'BENEFICIARYST',[Column 190] as 'BENEFICIARYTLX',[Column 192] as 'PAYMENTDETAILS',[Column 194] as 'BKTOBKINFORM',[Column 196] as 'USERID',Convert(datetime,[column 198]) as 'SYSTEMDATE',[Column 200] as 'REPORTNAME',[Column 202] as 'REPORTBR',[Column 204] as 'REPORTADDRESS1',[Column 206] as 'REPORTADDRESS2',[Column 208] as 'SWIFTINREF',[Column 210] as 'CHATSBANKID',[Column 212] as 'RECEIVINGPARTY',[Column 214] as 'SENDINGPARTY',[Column 216] as 'PAYMENTDETLN1',[Column 218] as 'BANKOPERCODE',[Column 220] as 'INSTRUCTIONCODE',[Column 222] as 'TXTYPECODE',[Column 224] as 'INSTRUCTEDCCY',Case when ISNUMERIC([Column 226])=1 and LEN([Column 226])<=2 then convert(float,'0' + '.' + RIGHT([Column 226],2))when ISNUMERIC([Column 226])=1 and LEN([Column 226])=3 then convert(float,LEFT([Column 226],1) + '.' + RIGHT([Column 226],2))when ISNUMERIC([Column 226])=1 and LEN([Column 226])>3 then convert(float,LEFT([Column 226],len([Column 226])-2) + '.' + RIGHT([Column 226],2)) else 0 end as 'INSTRUCTEDAMT',[Column 228] as 'EXCHANGERATE',[Column 230]  as 'SENDINGINSTIT1',[Column 232] as 'SENDINGINSTIT2',[Column 234]  as 'THIRDREIMNAME',[Column 236] as 'THIRDREIMBR',[Column 238] as 'THIRDREIMST',[Column 240] as 'SENDERCCY',Case when ISNUMERIC([Column 242])=1 and LEN([Column 242])<=2 then convert(float,'0' + '.' + RIGHT([Column 242],2))when ISNUMERIC([Column 242])=1 and LEN([Column 242])=3 then convert(float,LEFT([Column 242],1) + '.' + RIGHT([Column 242],2))when ISNUMERIC([Column 242])=1 and LEN([Column 242])>3 then convert(float,LEFT([Column 242],len([Column 242])-2) + '.' + RIGHT([Column 242],2)) else 0 end as 'SENDERAMT',[Column 244] as 'RECVRCCY',Case when ISNUMERIC([Column 246])=1 and LEN([Column 246])<=2 then convert(float,'0' + '.' + RIGHT([Column 246],2))when ISNUMERIC([Column 246])=1 and LEN([Column 246])=3 then convert(float,LEFT([Column 246],1) + '.' + RIGHT([Column 246],2))when ISNUMERIC([Column 246])=1 and LEN([Column 246])>3 then convert(float,LEFT([Column 246],len([Column 246])-2) + '.' + RIGHT([Column 246],2)) else 0 end as 'RECVRAMT',[Column 248] as 'ORDERSHORTNAME',[Column 250] as 'ACWITHINSTLOC',[Column 252] as 'FIELD126',[Column 254] as 'PARASET',[Column 256] as 'PARAC',[Column 258] as 'ENTRYTYPE',[Column 260] as 'FILETYPE',[Column 262] as 'HOLDUSER',Convert(datetime,[column 264]) as 'HOLDDATE',[Column 266] as 'HOLDFUNC',[Column 268] as 'STATUS',[Column 270] as 'RELCODE',[Column 272] as 'RELUSER',[Column 274] as 'VOUCHERNO',[Column 276] as 'TFHOLDMARK',[Column 278] as 'UPDATEUSER',Convert(datetime,[column 280]) as 'UPDATADATE',[Column 282] as 'CALSAVENO',[Column 284] as 'CLSTATUS',[Column 286] as 'CHECKCODE',[Column 288] as 'CHECKUSER',[Column 290] as 'REVFILLER',[Column 292] as 'EXCHGRATE',[Column 294] as 'sourceID',[Column 296] as 'Feecurr',Case when ISNUMERIC([Column 298])=1 and LEN([Column 298])<=2 then convert(float,'0' + '.' + RIGHT([Column 298],2))when ISNUMERIC([Column 298])=1 and LEN([Column 298])=3 then convert(float,LEFT([Column 298],1) + '.' + RIGHT([Column 298],2))when ISNUMERIC([Column 298])=1 and LEN([Column 298])>3 then convert(float,LEFT([Column 298],len([Column 298])-2) + '.' + RIGHT([Column 298],2)) else 0 end as 'cablecharge',Case when ISNUMERIC([Column 300])=1 and LEN([Column 300])<=2 then convert(float,'0' + '.' + RIGHT([Column 300],2))when ISNUMERIC([Column 300])=1 and LEN([Column 300])=3 then convert(float,LEFT([Column 300],1) + '.' + RIGHT([Column 300],2))when ISNUMERIC([Column 300])=1 and LEN([Column 300])>3 then convert(float,LEFT([Column 300],len([Column 300])-2) + '.' + RIGHT([Column 300],2)) else 0 end as 'Postage',[Column 302] FROM [#Temp_GMPS_CREMFM] where [Column 0] not in (Select EM00KEY0 from GMPS_CREMFM)"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Drop Temporary Table")
                    cmd.CommandText = "DROP TABLE [#Temp_GMPS_CREMFM]"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Delete Duplicates from GMPS_CREMFM")
                    cmd.CommandText = "DELETE FROM [GMPS_CREMFM] where [ID] not in (Select Min([ID]) from [GMPS_CREMFM] group by [EM00KEY0])"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Insert Data from GMPS_CREMFM to ODAS REMMITANCES")
                    cmd.CommandText = "INSERT INTO [ODAS REMMITANCES]([EM00KEY0],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[PAYMENTDETAILS],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[Deal Amount],[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC])SELECT [EM00KEY0],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[DETOFPAYMENT],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],AMOUNT,[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC] from GMPS_CREMFM where EM00KEY0 not in (Select [EM00KEY0] from [ODAS REMMITANCES])"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Insert Exchange Rates to ODAS REMMITANCES")
                    cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [ODAS REMMITANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[TRANSACTIONDATE]=B.[EXCHANGE RATE DATE]  and A.[CURRENCYCODE]=B.[CURRENCY CODE] where A.[CURRENCYCODE] not in ('EUR') and A.[Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [ODAS REMMITANCES] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.VALUEDATE=B.[EXCHANGE RATE DATE]  and A.[CURRENCYCODE]=B.[CURRENCY CODE] where A.[CURRENCYCODE] not in ('EUR') and A.[Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Calculate Deal Amount Euro in ODAS REMMITANCES")
                    cmd.CommandText = "UPDATE [ODAS REMMITANCES] SET [Deal Amount Euro]=Round([Deal Amount]/[EXCHANGE_RATE],2) where  [Deal Amount Euro]=0"
                    cmd.ExecuteNonQuery()
                    Me.BgwOCBSimport.ReportProgress(2, "Procedure:" & CURRENT_PROC & " - " & "Delete duplicates in ODAS REMMITANCES based on Field:EM00KEY0")
                    cmd.CommandText = "DELETE  FROM [ODAS REMMITANCES] where [ID] not in (Select Min([ID]) from [ODAS REMMITANCES] group by [EM00KEY0])"
                    cmd.ExecuteNonQuery()

                    Me.BgwOCBSimport.ReportProgress(100, "Procedure:" & CURRENT_PROC & " - " & "Import procedure: GMPS INTERFACE CREMFM is finished sucesfully")

                Else
                    Me.BgwOCBSimport.ReportProgress(0, "ERROR+++ Procedure:" & CURRENT_PROC & " - File does not exist in Import Directory - File Name:" & DatFileName)

                End If
            Else
                Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:GMPS INTERFACE CREMFM is not VALID+++")

            End If
            Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & "Procedure:" & CURRENT_PROC & " - " & ex.Message.Replace("'", ""))
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            Exit Sub

        End Try
    End Sub

    Private Sub OCBS_CUSTOMER_RATINGS_CHECK()
        '    Try
        '        Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
        '        CURRENT_PROC = "CUSTOMER_RATINGS_VALIDITY_CHECK"
        '        Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

        '        'Dim rd As Date
        '        'Dim rdsql As String = ""

        '        If cmd.Connection.State = ConnectionState.Open Then
        '            cmd.Connection.Close()
        '        End If

        '        cmd.CommandText = "SELECT [ID] FROM [OCBS IMPORT PROCEDURES] WHERE [ProcName]='CUSTOMER_RATINGS_VALIDITY_CHECK' and [Valid]='Y'"
        '        cmd.Connection.Open()

        '        If cmd.ExecuteScalar > 0 Then
        '            Me.BgwOCBSimport.ReportProgress(1, "Start checking procedure: CUSTOMER_RATINGS_VALIDITY_CHECK")

        '            'CREATE EMAIL and SEND
        '            Dim myBuilder As New StringBuilder
        '            Dim myBuilderNextMonth As New StringBuilder
        '            Dim dd As Date = Today
        '            Dim ddSql As String = dd.ToString("yyyyMMdd")
        '            Dim ValidityTillNextMonth As Date = DateAdd(DateInterval.Month, 1, dd)
        '            Dim ValidityTillNextMonthSql As String = ValidityTillNextMonth.ToString("yyyyMMdd")


        '            Me.BgwOCBSimport.ReportProgress(9, "Check if Parameter:EMAIL_CUSTOMERS_RATINGS is Valid - For the creation of the Customer Ratings Email")
        '            cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER STATUS] from [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='EMAIL_CUSTOMERS_RATINGS'"
        '            Dim EMAIL_CUSTOMERS_RATINGS_Valid As String = cmd.ExecuteScalar

        '            If EMAIL_CUSTOMERS_RATINGS_Valid = "Y" Then
        '                Me.BgwOCBSimport.ReportProgress(10, "Parameter:EMAIL_CUSTOMERS_RATINGS is valid-Start Email creation")

        '                'Select EMAIL RECEIVERS
        '                Me.BgwOCBSimport.ReportProgress(12, "Collect Email Receivers")
        '                Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [PARAMETER1] in ('Receiver_Direct') and [IdABTEILUNGSPARAMETER]='EMAIL_CUSTOMERS_RATINGS'"
        '                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        '                dt = New DataTable()
        '                da.Fill(dt)
        '                Dim EMAIL_USERS As String = ""
        '                For i = 0 To dt.Rows.Count - 1
        '                    EMAIL_USERS += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        '                Next
        '                dt.Clear()
        '                'CC to
        '                Me.QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [PARAMETER1] in ('Receiver_CC') and [IdABTEILUNGSPARAMETER]='EMAIL_CUSTOMERS_RATINGS'"
        '                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        '                dt = New DataTable()
        '                da.Fill(dt)
        '                Dim EMAIL_USERS_CC As String = ""
        '                For i = 0 To dt.Rows.Count - 1
        '                    EMAIL_USERS_CC += dt.Rows.Item(i).Item("PARAMETER2") & ";"
        '                Next




        '                '*********************************************************************************************************************************
        '                Me.BgwOCBSimport.ReportProgress(13, "Check if Customer Ratings are not longer Valid on " & dd)
        '                'RATINGS WITH NO VALIDITY
        '                Me.QueryText = "Select A.ClientNo,LEFT(LTRIM(RTRIM(A.ClientName)),21) as 'ClientName',A.RatingType,A.Valid_From,A.Valid_Till from CUSTOMER_RATING_DETAILS A INNER JOIN (Select ClientNo,Max(Valid_Till) as 'MaxValidity' from CUSTOMER_RATING_DETAILS where ClientNo in (Select [ClientNo] from CUSTOMER_RATING where [Valid]='Y') and RatingType in ('INTERNAL','EXTERNAL') GROUP BY ClientNo) B on A.ClientNo=B.ClientNo and A.Valid_Till=B.MaxValidity where B.MaxValidity<'" & ddSql & "'"
        '                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        '                dt = New DataTable()
        '                dt.Clear()
        '                da.Fill(dt)
        '                If dt.Rows.Count > 0 Then
        '                    Dim headers As String = "The following Customer ratings are not valid as from: " & dd & vbNewLine
        '                    Dim Footer As String = "(Please validate the a.m. customer ratings immediately)" & vbNewLine

        '                    myBuilder.Append("Client No:     " & "Client Name:                          " & "Rating Type:     " & "Valid from: " & "    Valid till: " & vbNewLine)


        '                    For i = 0 To dt.Rows.Count - 1
        '                        Dim Valid_From As Date = dt.Rows.Item(i).Item("Valid_From")
        '                        Dim Valid_From_String As String = Valid_From.ToString("dd.MM.yyyy")
        '                        Dim Valid_Till As Date = dt.Rows.Item(i).Item("Valid_Till")
        '                        Dim Valid_Till_String As String = Valid_Till.ToString("dd.MM.yyyy")
        '                        myBuilder.Append(dt.Rows.Item(i).Item("ClientNo") & "       " & dt.Rows.Item(i).Item("ClientName") & "   " & dt.Rows.Item(i).Item("RatingType") & "         " & Valid_From_String & "      " & Valid_Till_String & vbNewLine)
        '                    Next



        '                    Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
        '                    Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
        '                    Dim outApp As Microsoft.Office.Interop.Outlook.Application

        '                    outApp = New Microsoft.Office.Interop.Outlook.Application

        '                    NSpace = outApp.GetNamespace("MAPI")
        '                    Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
        '                    EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
        '                    EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh

        '                    EItem.To = EMAIL_USERS
        '                    EItem.CC = EMAIL_USERS_CC


        '                    EItem.Subject = "ACTIVE CUSTOMERS WITH NO VALID RATING on " & dd

        '                    EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

        '                    Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

        '                    EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
        '                    EItem.Send()

        '                    Me.BgwOCBSimport.ReportProgress(14, "Email for Customers with no valid rating has being sended")
        '                End If
        '                '*********************************************************************************************************************************

        '                '*********************************************************************************************************************************
        '                'RATINGS WITH VALIDITY till next Month
        '                Me.BgwOCBSimport.ReportProgress(15, "Check for Ratings with Validity on  " & ValidityTillNextMonth)
        '                Me.QueryText = "Select A.ClientNo,LEFT(LTRIM(RTRIM(A.ClientName)),21) as 'ClientName',A.RatingType,A.Valid_From,A.Valid_Till from CUSTOMER_RATING_DETAILS A INNER JOIN (Select ClientNo,Max(Valid_Till) as 'MaxValidity' from CUSTOMER_RATING_DETAILS where ClientNo in (Select [ClientNo] from CUSTOMER_RATING where [Valid]='Y') and RatingType in ('INTERNAL','EXTERNAL') GROUP BY ClientNo) B on A.ClientNo=B.ClientNo and A.Valid_Till=B.MaxValidity where B.MaxValidity='" & ValidityTillNextMonthSql & "'"
        '                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        '                dt = New DataTable()
        '                dt.Clear()
        '                da.Fill(dt)

        '                If dt.Rows.Count > 0 Then

        '                    Dim headers As String = "The following Customer ratings are  valid till : " & ValidityTillNextMonth & vbNewLine
        '                    Dim Footer As String = "(Please validate the a.m. customer ratings)" & vbNewLine

        '                    myBuilderNextMonth.Append("Client No:     " & "Client Name:                          " & "Rating Type:     " & "Valid from: " & "    Valid till: " & vbNewLine)


        '                    For i = 0 To dt.Rows.Count - 1
        '                        Dim Valid_From As Date = dt.Rows.Item(i).Item("Valid_From")
        '                        Dim Valid_From_String As String = Valid_From.ToString("dd.MM.yyyy")
        '                        Dim Valid_Till As Date = dt.Rows.Item(i).Item("Valid_Till")
        '                        Dim Valid_Till_String As String = Valid_Till.ToString("dd.MM.yyyy")
        '                        myBuilderNextMonth.Append(dt.Rows.Item(i).Item("ClientNo") & "       " & dt.Rows.Item(i).Item("ClientName") & "   " & dt.Rows.Item(i).Item("RatingType") & "         " & Valid_From_String & "      " & Valid_Till_String & vbNewLine)
        '                    Next



        '                    Dim NSpace As Microsoft.Office.Interop.Outlook.NameSpace
        '                    Dim Folder As Microsoft.Office.Interop.Outlook.MAPIFolder
        '                    Dim outApp As Microsoft.Office.Interop.Outlook.Application

        '                    outApp = New Microsoft.Office.Interop.Outlook.Application

        '                    NSpace = outApp.GetNamespace("MAPI")
        '                    Folder = NSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail)
        '                    EItem = Folder.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
        '                    EItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh
        '                    EItem.To = EMAIL_USERS
        '                    EItem.CC = EMAIL_USERS_CC


        '                    EItem.Subject = "ACTIVE CUSTOMERS WITH VALID RATING till " & ValidityTillNextMonth

        '                    EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

        '                    Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

        '                    EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilderNextMonth.ToString & vbNewLine & Footer
        '                    EItem.Send()

        '                    Me.BgwOCBSimport.ReportProgress(16, "Email for Customers with valid rating till " & ValidityTillNextMonth & " has being sended")
        '                End If
        '                '*************************************************************************************************************************
        '                Me.BgwOCBSimport.ReportProgress(100, "Import procedure: CUSTOMER_RATINGS_VALIDITY_CHECK is finished sucesfully")
        '            Else
        '                Me.BgwOCBSimport.ReportProgress(11, "Parameter:EMAIL_CUSTOMERS_RATINGS is not valid-No Email Creation")

        '            End If
        '        Else
        '            Me.BgwOCBSimport.ReportProgress(100, "+++Import Procedure:CUSTOMER_RATINGS_VALIDITY_CHECK is not VALID+++")

        '        End If



        '        Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
        '        If cmd.Connection.State = ConnectionState.Open Then
        '            cmd.Connection.Close()
        '        End If
        '    Catch ex As Exception
        '        Me.BgwOCBSimport.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
        '        If cmd.Connection.State = ConnectionState.Open Then
        '            cmd.Connection.Close()
        '        End If
        '        Exit Sub

        '    End Try
    End Sub 'DEACTIVATED-NOT IN USE

    Private Sub Test()
        QueryText = "SELECT  distinct([RepDate]) FROM [TIME DEP OUTST CLIENT DEALS] where [RepDate]>'20131231'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        dt = New DataTable()
        da.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim rd As Date = FormatDateTime(dt.Rows.Item(i).Item("RepDate"), DateFormat.ShortDate)
            Dim rdsql As String = rd.ToString("yyyyMMdd")
            Dim BadRefinaceSoldFounded As Double = 0
            Dim SumPledgedVariableDepositsCustomer As Double = 0
            cmd.Connection.Open()
            cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='REFINANCE SOLD FUNDED' and [Client No] in ('67820185','67820386') and [RepDate]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                BadRefinaceSoldFounded = cmd.ExecuteScalar
            Else
                BadRefinaceSoldFounded = 0
            End If
            cmd.CommandText = "SELECT Sum([PrincipalPlusInterestEUR]) from [TIME DEP OUTST CLIENT DEALS] where [Product Name]='PLEDGED VARIABLE DEPOSITS-CUSTOMER' and [RepDate]='" & rdsql & "'"
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                SumPledgedVariableDepositsCustomer = cmd.ExecuteScalar
            Else
                SumPledgedVariableDepositsCustomer = 0
            End If
            'EINFÜGEN IN RISK LIMIT DAILY CONTROL
            cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
            Dim t1 As String = cmd.ExecuteScalar
            If IsNothing(t1) = False Then
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [BadRefinanceSoldFunded]=" & Str(BadRefinaceSoldFounded) & ",[SumPledgeVariableDepositsCustomer]=" & Str(SumPledgedVariableDepositsCustomer) & " where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[SumPledgeVariableDepositsCustomer]+[RetainedEarnings] where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            ElseIf IsNothing(t1) = True Then
                cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [BadRefinanceSoldFunded]=" & Str(BadRefinaceSoldFounded) & ",[SumPledgeVariableDepositsCustomer]=" & Str(SumPledgedVariableDepositsCustomer) & ",[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CCBINFO Obligo Liability surplus]=[CCBINFO Obligo Liability surplus Default]-[BadRefinanceSoldFunded]+[SumPledgeVariableDepositsCustomer]+[RetainedEarnings] where [RLDC Date]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
            End If
            cmd.Connection.Close()
        Next



    End Sub

    Private Sub ERRORS_EMAIL_OCBS()
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
            cmdEVENT.CommandText = "Select Max([ID]) from [IMPORT EVENTS] where [Event] like 'ERROR%' and [SystemName] in ('OCBS')"
            Dim maxid As Double = cmdEVENT.ExecuteScalar()
            Dim myBuilder As New StringBuilder

            Me.QueryText = "SELECT * FROM [IMPORT EVENTS] where [ID]=" & maxid & "  order by ID desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim ErrorDate As Date = dt.Rows.Item(0).Item("ProcDate")
                Dim headers As String = "On " & ErrorDate & "the following import error have being occured in OCBS Imports:" & vbNewLine
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

                EItem.Subject = "PS TOOL - OCBS IMPORT ERROR on " & " " & ErrorDate

                EItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatPlain

                Dim StrBody1 As String = "******This is a automated E-Mail, generated from the PS TOOL Application!******"

                EItem.Body = StrBody1 & vbNewLine & vbNewLine & headers & vbNewLine & myBuilder.ToString & vbNewLine & Footer
                EItem.Send()

            End If
        End If
        '*******************************************************************************************
    End Sub




#Region "OLD IMPORT CODES"
    Private Sub OCBS_IMPORT_INTEREST_ON_ACCOUNT_DE_OLD()
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

                        Me.BgwOCBSimport.ReportProgress(5, "Check if Customer Nr in Column 16 (P) - ClientNr is not NULL and determine Interest Payment Year and Month...Delete all other rows...")
                        Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_MAX10))
                        For i = 2 To 10000
                            Me.OCBSProgressBar.BeginInvoke(New ChangeText(AddressOf PROGRESS_OCBS_EXCEL))
                            If Len(xlWorksheet1.Cells(i, 16).value) > 0 Then ' wenn Client No größer NULL ist
                                Dim yd As Double = Microsoft.VisualBasic.Right(xlWorksheet1.Cells(i, 6).value, 4) 'Column F:Value Date only YEAR
                                Dim zm As Date = xlWorksheet1.Cells(i, 6).value 'Column F:Value Date
                                xlWorksheet1.Cells(i, 29).Value = yd 'Column AC-ValYear
                                xlWorksheet1.Cells(i, 30).Value = yd 'Column AD IdErtragJahr
                                xlWorksheet1.Cells(i, 35).Value = xlWorksheet1.Cells(i, 6).Value & xlWorksheet1.Cells(i, 8).Value 'Column AI=IdValueCustomer-->Column F:ValueDate + Column H:Account Nr.
                                xlWorksheet1.Cells(i, 36).Value = zm.ToString("MMMM yyyy") 'Column AJ=Column F: Value Date in Format MMMM yyyy
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
                        Dim ERTRAGSJAHR As Double = xlWorksheet1.Range("J2").Value 'Column J:ValYear
                        Dim ERTRAGSMONAT As String = xlWorksheet1.Range("Q2").Value 'Column Q:IdZinsertragsMonat
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

                        Me.BgwOCBSimport.ReportProgress(12, "Start Import to the Temporary Table: #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP' AND xtype='U') CREATE TABLE [dbo].[#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]([ID] [int] IDENTITY(1,1) NOT NULL,[ValDateFrom] [datetime] NULL,[ValDate] [datetime] NULL,[Customer] [nvarchar](255) NULL,[ValYear] [float] NULL,[CustomerName] [nvarchar](255) NULL,[Account] [nvarchar](255) NULL,[RegistrationCountry] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[CCY] [nvarchar](255) NULL,[Product] [nvarchar](255) NULL,[Amount] [float] NULL,[ExchangeRate] [float] NULL,[AmountEuro] [float] NULL,[DB] [nvarchar](255) NULL,[KapertstG] [float] NULL,[Remark] [nvarchar](255) NULL,[Soli] [float] NULL,[KAPISTPFLICHTIG] [nvarchar](255) NULL,[BUNDESLAND] [nvarchar](255) NULL,[IdValueCustomer] [nvarchar](255) NULL,[IdZinsertragsMonat] [nvarchar](255) NULL,[IdErtragJahr] [float] NULL) ELSE DELETE FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] "
                        cmd.ExecuteNonQuery()
                        'In temporäre Tabelle einfügen
                        cmd.CommandText = "INSERT INTO [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] ([ValDate],[Account],[Contract],[Product],[CCY],[Amount],[DB],[Customer],[Remark],[ValYear],[IdErtragJahr],[KapertstG],[Soli],[CustomerName],[RegistrationCountry],[IdValueCustomer],[IdZinsertragsMonat]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileNameNew & ";','SELECT * FROM [Sheet1$]')"
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
                        Me.BgwOCBSimport.ReportProgress(23, "Delete from  #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP where Remark not like INTEREST ON A/C")
                        cmd.CommandText = "DELETE  FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Remark] NOT LIKE 'INTEREST ON A/C%'"
                        cmd.ExecuteNonQuery()
                        'LÖSCHEN wenn kein KUNDENSTAMM vorhanden ist
                        Me.BgwOCBSimport.ReportProgress(24, "Delete from  #Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP where Customer like NULL")
                        cmd.CommandText = "DELETE  FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP] where [Customer] is NULL"
                        cmd.ExecuteNonQuery()
                        'In live Tabelle einfügen
                        Me.BgwOCBSimport.ReportProgress(25, "Insert Data to Table: ZINSERTRAG KUNDEN DETAILS ")
                        cmd.CommandText = "INSERT INTO [ZINSERTRAG KUNDEN DETAILS] ([ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr]) SELECT [ValDateFrom],[ValDate],[Customer],[ValYear],[CustomerName],[Account],[RegistrationCountry],[Contract],[CCY],[Product],[Amount],[ExchangeRate],[AmountEuro],[DB],[KapertstG],[Remark],[Soli],[KAPISTPFLICHTIG],[BUNDESLAND],[IdValueCustomer],[IdZinsertragsMonat],[IdErtragJahr] FROM [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
                        cmd.ExecuteNonQuery()
                        'Temptabelle löschen
                        cmd.CommandText = "DROP TABLE [#Temp_ZINSERTRAG_KUNDEN_DETAILS_TEMP]"
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
#End Region


    Private Sub LastOcbsImportFile_EditValueChanged(sender As Object, e As EventArgs) Handles LastOcbsImportFile.EditValueChanged

    End Sub


End Class