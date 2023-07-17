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
Imports System.Linq
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports ICSharpCode.SharpZipLib.Tar
Imports ICSharpCode.SharpZipLib.Core



Public Class OcbsImport

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""

    Dim OdasDirectory As String = "" 'ODAS FILE DIRECTORY
    Dim OdasFileNewDirectory As String = "" 'NEW DIRECTORY FOR ODAS FILE
    Dim OCBSDirectory As String = "" 'OCBS FILE DIRECTORY
    Dim OCBSFileNewDirectory As String = "" 'NEW DIRECTORY FOR OCBS FILE

    Dim HasDataResult As String = Nothing

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

    Dim ex As Integer
    Dim OcbsAutomatedImport_btn_clicked As Boolean = False 'Button for Automated Import
    Dim OcbsSelectedFileImport_btn_clicked As Boolean = False 'Button for single File import
    Dim OcbsImportFromTill_btn_clicked As Boolean = False
    Dim OcbsImportManual_btn_clicked As Boolean = False
    Dim CURRENT_LAST_IMPORTED_OCBS_FILE As Double = Nothing

    Dim MaxProcDate As Date

    Dim EMAIL_USERS As String = Nothing

    'Update Form
    'Heutiges Datum ermitteln und in Zahl unformatieren
    Dim CurDate As Date = Today
    Dim CurDateSql As String = CurDate.ToString("yyyyMMdd")
    Private CurrentImportProcedureTextEdit As New TextEdit()
    Dim ID_Selected As Integer = 0
    Dim GetFocusedRow As Integer = 0
    Private ConvertWorkbook As IWorkbook
    Private bgws As New List(Of BackgroundWorker)()

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

    Private Sub OcbsImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        OpenSqlConnections()
        'Get Max Date
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        MaxProcDate = cmd.ExecuteScalar
        'Get SSIS Directory
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='SSIS_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SSIS_DIRECTORY'"
        SSISDirectory = cmd.ExecuteScalar()
        CloseSqlConnections()

        QueryText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='IMPORT_ERRORS_EMAIL'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
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


#Region "SPECIAL_FUNCTIONS"

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub

    'Change the Current OCBS File in Form
    Public Sub Change_COBIF()
        Me.CurrentOcbsImportFile.Text = COBIF
    End Sub

    'Change the Last OCBS Import File in Form
    Public Sub Change_LOBIF()
        Me.LastOcbsImportFile.Text = LOBIF
    End Sub
    'Change Current Procedure in Form
    'Public Sub Change_CURRENT_PROC()
    '    Me.CURRENT_PROCEDURE_Text.Text = CURRENT_PROC
    'End Sub
    'Clear Current Procedure in Form
    'Public Sub Clear_CURRENT_PROC()
    '    Me.CURRENT_PROCEDURE_Text.Text = ""
    'End Sub

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

    Public Sub ExtractTGZ(ByVal gzArchiveName As String, ByVal destFolder As String)

        Dim inStream As Stream = File.OpenRead(gzArchiveName)
        Dim gzipStream As Stream = New GZipInputStream(inStream)

        Dim tarArchive As TarArchive = TarArchive.CreateInputTarArchive(gzipStream)
        tarArchive.ExtractContents(destFolder)
        tarArchive.Close()

        gzipStream.Close()
        inStream.Close()
    End Sub

#End Region

#Region "GRIDVIEWS_DEFAULT_SETTINGS"

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        'Add new Procedure
        If e.Button.Tag = "AddProc" Then
            Try
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
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
                    cmd.CommandText = "DELETE FROM [OCBS IMPORT PROCEDURES] where ID=" & ID_Selected & ""
                    cmd.ExecuteNonQuery()
                    'Reset LfdNr
                    cmd.CommandText = "UPDATE A SET A.LfdNr=B.rn from [OCBS IMPORT PROCEDURES] A INNER JOIN 
                                       (SELECT row_number() over (order by LfdNr asc) as rn,ID
                                       from  [OCBS IMPORT PROCEDURES])B On A.ID=B.ID"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
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
                Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
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
                Me.OCBS_IMPORT_PROCEDURESBindingSource.EndEdit()
                If Me.EDPDataSet.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                        Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                    Else
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Activate all Procedures
        If e.Button.Tag = "ActivateProcs" Then
            Try
                If XtraMessageBox.Show("Should all current mandatory Procedures be activated", "ACTIVATE CURRENT MANDATORY PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [OCBS IMPORT PROCEDURES] SET [Valid]='Y' where [Importance] in ('MANDATORY')"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Activate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If

        'Deactivate all Procedures
        If e.Button.Tag = "DeactivateProcs" Then
            Try
                If XtraMessageBox.Show("Should all current Procedures be Deactivated", "DEACTIVATE CURRENT PROCEDURES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    OpenSqlConnections()
                    cmd.CommandText = "UPDATE [OCBS IMPORT PROCEDURES] SET [Valid]='N'"
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()
                    Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Deactivate current Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.OCBS_IMPORT_PROCEDURESBindingSource.CancelEdit()
                Me.EDPDataSet.RejectChanges()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                Exit Sub
            End Try
        End If
        'Terminate OCBS Backgroundworker
        If e.Button.Tag = "Terminate" Then
            If Me.BgwOCBSimport.IsBusy = True Then
                If XtraMessageBox.Show("Should the OCBS import procedures be terminated?", "TERMINATE NGS IMPORTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.BgwOCBSimport.CancelAsync()
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("OCBS Imports termination is requested..." & vbNewLine & "Please wait until the current NGS Import operations are finished!")
                End If
            End If
        End If

    End Sub
    Private Sub OcbsImportProcedures_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles OcbsImportProcedures_BasicView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub OcbsImportProcedures_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles OcbsImportProcedures_BasicView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Print_Export_OCBS_ImportProcedures_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_OCBS_ImportProcedures_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
            If XtraMessageBox.Show("Should the NGS File Nr. " & LastOcbsImportFile.Text & " be saved as Last Imported NGS file", "CHANGE THE LAST IMPORTED NGS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Dim LastOCBSImportFile As Double = Me.LastOcbsImportFile.Text
                Me.FILES_IMPORTBindingSource.EndEdit()
                Me.FILES_IMPORTTableAdapter.UpdateOCBS_LastImportFile(LastOCBSImportFile)
                Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)
            Else
                Me.FILES_IMPORTBindingSource.CancelEdit()
                Exit Sub
            End If
        Else
            XtraMessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub

        End If
    End Sub

    Private Sub LastOcbsImportFile_Leave(sender As Object, e As EventArgs) Handles LastOcbsImportFile.Leave
        If IsNumeric(LastOcbsImportFile.Text) = False OrElse Len(LastOcbsImportFile.Text) <> 8 Then
            XtraMessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.FILES_IMPORTBindingSource.CancelEdit()
            Exit Sub
        End If
    End Sub
    Private Sub SelectedOcbsImportFile_Leave(sender As Object, e As EventArgs) Handles SelectedOcbsImportFile.Leave
        If Me.SelectedOcbsImportFile.Text <> "" Then
            If IsNumeric(SelectedOcbsImportFile.Text) = False OrElse Len(SelectedOcbsImportFile.Text) <> 8 Then
                XtraMessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.SelectedOcbsImportFile.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OcbsImportFileFrom_Leave(sender As Object, e As EventArgs) Handles OcbsImportFileFrom.Leave
        If Me.OcbsImportFileFrom.Text <> "" Then
            If IsNumeric(OcbsImportFileFrom.Text) = False OrElse Len(OcbsImportFileFrom.Text) <> 8 Then
                XtraMessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.OcbsImportFileFrom.Text = ""
                Exit Sub
            End If
        End If

    End Sub

    Private Sub OcbsImportFileTill_Leave(sender As Object, e As EventArgs) Handles OcbsImportFileTill.Leave
        If Me.OcbsImportFileTill.Text <> "" Then
            If IsNumeric(OcbsImportFileTill.Text) = False OrElse Len(OcbsImportFileTill.Text) <> 8 Then
                XtraMessageBox.Show("The indicated NGS Filename is not correct!", "NGS FILENAME NOT CORRECT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.OcbsImportFileTill.Text = ""
                Exit Sub
            End If
        End If

    End Sub


    Private Sub OcbsAutomatedImport_btn_Click(sender As Object, e As EventArgs) Handles OcbsAutomatedImport_btn.Click
        OcbsAutomatedImport_btn_clicked = True
        OcbsSelectedFileImport_btn_clicked = False
        OcbsImportFromTill_btn_clicked = False
        OcbsImportManual_btn_clicked = False
        If Me.LastOcbsImportFile.Text <> "" Then
            If XtraMessageBox.Show("Should the automated NGS Fileimport be executed?", "AUTOMATED IMPORT NGS FILES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
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
        OcbsImportManual_btn_clicked = False
        If Me.SelectedOcbsImportFile.Text <> "" Then
            If XtraMessageBox.Show("Should the NGS Filename " & SelectedOcbsImportFile.Text & " be imported?", "IMPORT NGS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                DISABLE_START_IMPORT()
                If Me.BgwOCBSimport.IsBusy = False Then
                    Me.BgwOCBSimport.RunWorkerAsync()
                End If
            End If
        Else
            XtraMessageBox.Show("Please enter a file nr.!", "NO FILE NR ENTERED", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
    End Sub

    Private Sub OcbsFromTillImport_btn_Click(sender As Object, e As EventArgs) Handles OcbsFromTillImport_btn.Click
        OcbsImportFromTill_btn_clicked = True
        OcbsAutomatedImport_btn_clicked = False
        OcbsSelectedFileImport_btn_clicked = False
        OcbsImportManual_btn_clicked = False
        If Me.OcbsImportFileFrom.Text <> "" AndAlso Me.OcbsImportFileTill.Text <> "" Then
            Dim n1 As Double = Me.OcbsImportFileFrom.Text
            Dim n2 As Double = Me.OcbsImportFileTill.Text
            If n2 >= n1 Then
                If XtraMessageBox.Show("Should the NGS Import start with Filename " & n1 & " and finish with Filename " & n2, "IMPORT NGS FILE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    DISABLE_START_IMPORT()
                    If Me.BgwOCBSimport.IsBusy = False Then
                        CURRENT_LAST_IMPORTED_OCBS_FILE = Me.LastOcbsImportFile.Text
                        Me.BgwOCBSimport.RunWorkerAsync()
                    End If
                End If
            Else
                XtraMessageBox.Show("The last Filename is earlier than the first Filename!", "WRONG FILENAMES IMPORT ORDER", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If
    End Sub
#End Region

#Region "OCBS_IMPORT_BACKGROUNDWORKER"
    Private Sub BgwOCBSimport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOCBSimport.DoWork
        CurrentSystemExecuting = "NGS"
        'Get Current data directory and temporary directory
        Me.BgwOCBSimport.ReportProgress(10, "Locate the NGS Current and Temp Directory")
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_CUR_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
        OCBSDirectory = cmd.ExecuteScalar()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
        OCBSFileNewDirectory = cmd.ExecuteScalar()
        CloseSqlConnections()

        '***********AUTOMATED NGS IMPORT****************
        If OcbsAutomatedImport_btn_clicked = True Then

            Try
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "NGS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

                Dim dt_NGS_Folders As New DataTable
                dt_NGS_Folders.Rows.Clear()
                Dim dt_NGS_Row As DataRow
                dt_NGS_Folders.Columns.Add("FileName", GetType(String))

                If Directory.Exists(OCBSDirectory) Then
                    Dim dir As New DirectoryInfo(OCBSDirectory)
                    Dim directories As DirectoryInfo() = dir.GetDirectories()
                    For Each directory As DirectoryInfo In directories
                        dt_NGS_Row = dt_NGS_Folders.NewRow
                        dt_NGS_Row("FileName") = directory.Name
                        dt_NGS_Folders.Rows.Add(dt_NGS_Row)
                    Next
                End If

                OpenSqlConnections()
                Me.BgwOCBSimport.ReportProgress(25, "Create Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles 
                                   CREATE TABLE #Temp_DataFiles (ID int IDENTITY(1,1),FileName nvarchar(255) NULL)"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(30, "Insert NGS File Names in Table: #Temp_DataFiles")
                For Each dr As DataRow In dt_NGS_Folders.Rows
                    Dim sc As New SqlCommand("INSERT INTO #Temp_DataFiles ([FileName])" &
                                            " VALUES (@column1)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.ExecuteNonQuery()
                Next

                'clear datatable
                dt_NGS_Folders.Clear()
                dt_NGS_Folders.Rows.Clear()


                Me.BgwOCBSimport.ReportProgress(45, "Delete from Table: #Temp_DataFiles where FileName <= Last NGS Import File: " & Me.LastOcbsImportFile.EditValue.ToString)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName]<='" & Me.LastOcbsImportFile.EditValue.ToString & "'"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(50, "Delete from Table: #Temp_DataFiles where FileName >= Current Date: " & CurDateSql)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName]>='" & CurDateSql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwOCBSimport.ReportProgress(50, "Select all File Names for Import")
                QueryText = "SELECT [FileName] FROM [#Temp_DataFiles] ORDER BY [FileName] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwOCBSimport.ReportProgress(50, "Determine the next NGS File for Import...Please wait...")
                If dt.Rows.Count > 0 Then
                    For m = 0 To dt.Rows.Count - 1
                        COBIF = 0
                        COBIF = dt.Rows.Item(m).Item("FileName")
                        'Define Business Date based on the COBIF
                        Dim BTD As String = COBIF
                        rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                        rdsql = rd.ToString("yyyyMMdd")
                        '**************************************************************************
                        If Me.BgwOCBSimport.CancellationPending = False Then
                            Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_COBIF))
                            'Current OCBS File for Import-Insert in the Events Journal after finishing the current OCBS Import
                            Dim LCOBIF As String = COBIF
                            Me.BgwOCBSimport.ReportProgress(85, "Create Directory: " & "  " & OCBSFileNewDirectory)
                            If Not Directory.Exists(OCBSFileNewDirectory) Then
                                Directory.CreateDirectory(OCBSFileNewDirectory)
                            ElseIf Directory.Exists(OCBSFileNewDirectory) Then
                                Directory.Delete(OCBSFileNewDirectory, True)
                                Directory.CreateDirectory(OCBSFileNewDirectory)
                            End If

                            Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & COBIF & " is ready")
                            Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")

                            'PROCEDUREN
                            OCBS_IMPORT_PROCEDURES()

                            'CURRENT_PROC = Nothing
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                            CURRENT_PROC = "NGS_IMPORT_ACTIONS"
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                            'Erstellten Ordner wieder löschen
                            Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                            If Directory.Exists(OCBSFileNewDirectory) = True Then
                                Directory.Delete(OCBSFileNewDirectory, True)
                            End If
                            'Ordner als Bearbeitet einsetzen (LOBIF)
                            Me.BgwOCBSimport.ReportProgress(90, "Set as Last imported NGS File Name: " & "  " & COBIF)
                            cmd.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & COBIF & "' WHERE [SYSTEM_NAME] in ('OCBS','NGS')"
                            cmd.ExecuteNonQuery()

                            LOBIF = COBIF
                            Me.LastOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOBIF))
                            COBIF = Nothing
                            Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COBIF))

                            'Füllen des Table adapters
                            Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & LCOBIF & " " & "is finished ...")
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")
                            CURRENT_PROC = Nothing
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))

                        ElseIf Me.BgwOCBSimport.CancellationPending = True Then
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Imports are terminated after user request!")
                            e.Cancel = True
                        End If


                    Next m
                End If


                'Löschen der Temporären Tabelen für den NGS Import
                Me.BgwOCBSimport.ReportProgress(100, "Delete Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()

            Catch ex As System.Exception
                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS file: " & " " & Me.CurrentOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwOCBSimport.CancelAsync()
                If Directory.Exists(OCBSFileNewDirectory) = True Then
                    Directory.Delete(OCBSFileNewDirectory, True)
                End If
            End Try
            '*****************************************************************************
        End If


        '****************SELECTED NGS FILE IMPORT************************************
        If OcbsSelectedFileImport_btn_clicked = True Then
            Try

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)
                OpenSqlConnections()
                If Directory.Exists(OCBSDirectory) = True Then
                    'Define Business Date based on the NGS File Name
                    COBIF = SelectedOcbsImportFile.Text
                    Dim BTD As String = COBIF
                    rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                    rdsql = rd.ToString("yyyyMMdd")
                    '**************************************************************************
                    If Me.BgwOCBSimport.CancellationPending = False Then
                        Me.BgwOCBSimport.ReportProgress(85, "Create Directory: " & "  " & OCBSFileNewDirectory)
                        If Not Directory.Exists(OCBSFileNewDirectory) Then
                            Directory.CreateDirectory(OCBSFileNewDirectory)
                        End If

                        Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & COBIF & " is ready")
                        Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")

                        'PROCEDUREN
                        OCBS_IMPORT_PROCEDURES()

                        'CURRENT_PROC = Nothing
                        'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                        CURRENT_PROC = "NGS_IMPORT_ACTIONS"
                        'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                        'Erstellten Ordner wieder löschen
                        Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                        If Not Directory.Exists(OCBSFileNewDirectory) Then
                            Directory.CreateDirectory(OCBSFileNewDirectory)
                        ElseIf Directory.Exists(OCBSFileNewDirectory) Then
                            Directory.Delete(OCBSFileNewDirectory, True)
                            Directory.CreateDirectory(OCBSFileNewDirectory)
                        End If

                        'Füllen des Table adapters
                        Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                        Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & COBIF & " " & "is finished ...")
                        Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")
                        CURRENT_PROC = Nothing
                        'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))

                    ElseIf Me.BgwOCBSimport.CancellationPending = True Then
                        'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                        Me.BgwOCBSimport.ReportProgress(100, "NGS Imports are terminated after user request!")
                        e.Cancel = True
                    End If

                Else
                    XtraMessageBox.Show("NGS File: " & SelectedOcbsImportFile.Text & " does not exists!", "NGS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                CloseSqlConnections()

            Catch ex As Exception

                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS File: " & " " & Me.SelectedOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub

            Finally
                Me.BgwOCBSimport.CancelAsync()
                If Directory.Exists(OCBSFileNewDirectory) = True Then
                    Directory.Delete(OCBSFileNewDirectory, True)
                End If
            End Try
        End If
        '***********************************************************************************************

        '***********************OCBS IMPORT FROM...TILL*************************
        If OcbsImportFromTill_btn_clicked = True Then
            Try
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "NGS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

                Dim dt_NGS_Folders As New DataTable
                dt_NGS_Folders.Rows.Clear()
                Dim dt_NGS_Row As DataRow
                dt_NGS_Folders.Columns.Add("FolderName", GetType(String))

                If Directory.Exists(OCBSDirectory) Then
                    Dim dir As New DirectoryInfo(OCBSDirectory)
                    Dim directories As DirectoryInfo() = dir.GetDirectories()
                    For Each directory As DirectoryInfo In directories
                        dt_NGS_Row = dt_NGS_Folders.NewRow
                        dt_NGS_Row("FolderName") = directory.Name
                        dt_NGS_Folders.Rows.Add(dt_NGS_Row)
                    Next
                End If

                OpenSqlConnections()
                Me.BgwOCBSimport.ReportProgress(25, "Create Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles 
                                   CREATE TABLE #Temp_DataFiles (ID int IDENTITY(1,1),FileName nvarchar(255) NULL)"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(30, "Insert NGS File Names in Table: #Temp_DataFiles")
                For Each dr As DataRow In dt_NGS_Folders.Rows
                    Dim sc As New SqlCommand("INSERT INTO #Temp_DataFiles ([FileName])" &
                                            " VALUES (@column1)", conn)
                    sc.Parameters.AddWithValue("@column1", dr.Item(0))
                    sc.ExecuteNonQuery()
                Next

                'clear datatable
                dt_NGS_Folders.Clear()
                dt_NGS_Folders.Rows.Clear()


                Me.BgwOCBSimport.ReportProgress(45, "Delete from Table: OCBS FILES where FileName NOT BETWEEN " & Me.OcbsImportFileFrom.Text & " and " & Me.OcbsImportFileTill.Text)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName] NOT BETWEEN'" & Me.OcbsImportFileFrom.Text & "' and '" & Me.OcbsImportFileTill.Text & "'"
                cmd.ExecuteNonQuery()
                Me.BgwOCBSimport.ReportProgress(50, "Delete from Table: #Temp_DataFiles where FileName >= Current Date: " & CurDateSql)
                cmd.CommandText = "DELETE FROM #Temp_DataFiles where [FileName]>='" & CurDateSql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwOCBSimport.ReportProgress(50, "Select all File Names for Import")
                QueryText = "SELECT [FileName] FROM [#Temp_DataFiles] ORDER BY [FileName] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                Me.BgwOCBSimport.ReportProgress(50, "Determine the next NGS File for Import...Please wait...")
                If dt.Rows.Count > 0 Then
                    For m = 0 To dt.Rows.Count - 1
                        COBIF = 0
                        COBIF = dt.Rows.Item(m).Item("FileName")
                        'Define Business Date based on the COBIF
                        Dim BTD As String = COBIF
                        rd = DateSerial(Microsoft.VisualBasic.Left(BTD, 4), Mid(BTD, 5, 2), Microsoft.VisualBasic.Right(BTD, 2))
                        rdsql = rd.ToString("yyyyMMdd")
                        '**************************************************************************
                        If Me.BgwOCBSimport.CancellationPending = False Then
                            Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_COBIF))
                            'Current OCBS File for Import-Insert in the Events Journal after finishing the current OCBS Import
                            Dim LCOBIF As String = COBIF
                            Me.BgwOCBSimport.ReportProgress(85, "Create Directory: " & "  " & OCBSFileNewDirectory)
                            If Not Directory.Exists(OCBSFileNewDirectory) Then
                                Directory.CreateDirectory(OCBSFileNewDirectory)
                            ElseIf Directory.Exists(OCBSFileNewDirectory) Then
                                Directory.Delete(OCBSFileNewDirectory, True)
                                Directory.CreateDirectory(OCBSFileNewDirectory)
                            End If

                            Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & COBIF & " is ready")
                            Me.BgwOCBSimport.ReportProgress(70, "Starting the NGS Import procedures...")

                            'PROCEDUREN
                            OCBS_IMPORT_PROCEDURES()

                            'CURRENT_PROC = Nothing
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                            CURRENT_PROC = "NGS_IMPORT_ACTIONS"
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                            'Erstellten Ordner wieder löschen
                            Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                            If Directory.Exists(OCBSFileNewDirectory) = True Then
                                Directory.Delete(OCBSFileNewDirectory, True)
                            End If
                            ''Ordner als Bearbeitet einsetzen (LOBIF)
                            'Me.BgwOCBSimport.ReportProgress(90, "Set as Last imported NGS File Name: " & "  " & COBIF)
                            'cmd.CommandText = "UPDATE [FILES_IMPORT] SET [FileName]='" & COBIF & "' WHERE [SYSTEM_NAME] in ('OCBS','NGS')"
                            'cmd.ExecuteNonQuery()

                            LOBIF = COBIF
                            Me.LastOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Change_LOBIF))
                            COBIF = Nothing
                            Me.CurrentOcbsImportFile.BeginInvoke(New ChangeText(AddressOf Clear_COBIF))

                            'Füllen des Table adapters
                            Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                            Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & LCOBIF & " " & "is finished ...")
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")
                            CURRENT_PROC = Nothing
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))

                        ElseIf Me.BgwOCBSimport.CancellationPending = True Then
                            'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))
                            Me.BgwOCBSimport.ReportProgress(100, "NGS Imports are terminated after user request!")
                            e.Cancel = True
                        End If


                    Next m
                End If


                'Löschen der Temporären Tabelen für den NGS Import
                Me.BgwOCBSimport.ReportProgress(100, "Delete Temporary Table: #Temp_DataFiles")
                cmd.CommandText = "IF OBJECT_ID('tempdb..#Temp_DataFiles') IS NOT NULL DROP TABLE #Temp_DataFiles"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()

            Catch ex As System.Exception
                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS file: " & " " & Me.CurrentOcbsImportFile.Text & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub
            Finally
                Me.BgwOCBSimport.CancelAsync()
                If Directory.Exists(OCBSFileNewDirectory) = True Then
                    Directory.Delete(OCBSFileNewDirectory, True)
                End If
            End Try
        End If
        '***********************************************************************

        '+++++++++++++++++++OCBS Selected import via Gridview Button
        If OcbsImportManual_btn_clicked = True Then
            Try
                CURRENT_PROC = "NGS_IMPORT_ACTIONS_MANUAL"
                'Ermitteln der OCBS Ordner und einfügen der einzelnen Datei Namen in die Datenbank
                Me.BgwOCBSimport.ReportProgress(20, "NGS Directories - Current: " & OCBSDirectory & " - Temporary: " & OCBSFileNewDirectory)

                Dim OcbsFileFullName As String = OCBSDirectory & COBIF.ToString 'Full File Directory
                Dim OcbsFileName As String = COBIF.ToString 'File for Import

                OpenSqlConnections()
                If Directory.Exists(OcbsFileFullName) = True Then
                    'Define Business Date based on the OdasFileName
                    rd = rd_Entered
                    rdsql = rd.ToString("yyyyMMdd")
                    '**************************************************************************
                    Me.BgwOCBSimport.ReportProgress(85, "Create Directory: " & "  " & OCBSFileNewDirectory)
                    If Not Directory.Exists(OCBSFileNewDirectory) Then
                        Directory.CreateDirectory(OCBSFileNewDirectory)
                    ElseIf Directory.Exists(OCBSFileNewDirectory) Then
                        Directory.Delete(OCBSFileNewDirectory, True)
                        Directory.CreateDirectory(OCBSFileNewDirectory)
                    End If

                    Me.BgwOCBSimport.ReportProgress(60, "NGS File for Import: " & "  " & COBIF & " is ready")
                    Me.BgwOCBSimport.ReportProgress(70, "Starting the selected NGS procedure...")

                    'PROCEDUREN
                    OCBS_IMPORT_PROCEDURES_MANUAL()

                    'CURRENT_PROC = Nothing
                    'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                    CURRENT_PROC = "NGS_IMPORT_ACTIONS_MANUAL"
                    'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                    'Erstellten Ordner wieder löschen
                    Me.BgwOCBSimport.ReportProgress(85, "Delete Directory: " & "  " & OCBSFileNewDirectory)
                    If Directory.Exists(OCBSFileNewDirectory) = True Then
                        Directory.Delete(OCBSFileNewDirectory, True)
                    End If

                    'Füllen des Table adapters
                    Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)

                    Me.BgwOCBSimport.ReportProgress(95, "NGS File Import: " & " " & COBIF.ToString & " " & "is finished ...")
                    Me.BgwOCBSimport.ReportProgress(100, "NGS Import finished ...")
                    CURRENT_PROC = Nothing
                    'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                Else
                    XtraMessageBox.Show("NGS File: " & COBIF.ToString & " does not exists!", "NGS FILE NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                CloseSqlConnections()


            Catch ex As Exception
                Me.BgwOCBSimport.ReportProgress(0, "ERROR +++Import Procedure for NGS File: " & " " & COBIF.ToString & " " & "is canceled ..." & " " & ex.Message.ToString.Replace("'", " "))
                Exit Sub

            Finally
                Me.BgwOCBSimport.CancelAsync()
                'Directory Löschen
                If Directory.Exists(OCBSFileNewDirectory) = True Then
                    Directory.Delete(OCBSFileNewDirectory, True)
                End If

            End Try

        End If


    End Sub

    Private Sub BgwOCBSimport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOCBSimport.ProgressChanged
        Me.EVENTSloadtext.Text = e.UserState
        Me.OCBSProgressBar.Value = e.ProgressPercentage
        Me.CURRENT_PROCEDURE_Text.Text = CURRENT_PROC
        Dim stackFrame As New Diagnostics.StackFrame()
        Dim rtnName As String = stackFrame.GetMethod.Name.ToString()
        rtnName = rtnName & stackFrame.GetMethod.DeclaringType.FullName.ToString()

        OpenEVENT_SqlConnection()
        cmdEVENT.CommandTimeout = 500
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('" & Me.EVENTSloadtext.Text & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','NGS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "NGS" & "  " & Me.EVENTSloadtext.Text & "  " & CURRENT_PROC
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','NGS')"
            cmdEVENT.ExecuteNonQuery()
            '***************************************************
            TextImportFileRow = Now & "  " & "NGS" & "  " & Me.EVENTSloadtext.Text & "  " & CURRENT_PROC
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        CloseEVENT_SqlConnection()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByOCBSDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()

    End Sub

    Private Sub BgwOCBSimport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOCBSimport.RunWorkerCompleted
        ENABLE_FINISH_IMPORT()
        CurrentSystemExecuting = Nothing
        Me.XtraTabControl1.TabPages(0).PageVisible = True
        Me.FILES_IMPORTTableAdapter.FillByOCBS(Me.EDPDataSet.FILES_IMPORT)
        Me.SelectedOcbsImportFile.Text = ""
        Me.OcbsImportFileFrom.Text = ""
        Me.OcbsImportFileTill.Text = ""
        'Set Button Click as default to False
        OcbsAutomatedImport_btn_clicked = False
        OcbsSelectedFileImport_btn_clicked = False
        OcbsImportFromTill_btn_clicked = False
        OcbsImportManual_btn_clicked = False

        CloseSqlConnections()

        Dim f As New GlobalClass
        f.NewImportEventsFolder()



    End Sub

#End Region


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
                    COBIF = CDbl(rdsql_Entered)

                    If XtraMessageBox.Show("Should the NGS Import Procedure: " & OcbsImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) & " be executed for Business Date: " & rd_Entered & " ?", "Start NGS manual Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        OcbsImportFromTill_btn_clicked = False
                        OcbsAutomatedImport_btn_clicked = False
                        OcbsSelectedFileImport_btn_clicked = False
                        OcbsImportManual_btn_clicked = True

                        Me.XtraTabControl1.TabPages(0).PageVisible = False
                        DISABLE_START_IMPORT()
                        If Me.BgwOCBSimport.IsBusy = False Then
                            Me.BgwOCBSimport.RunWorkerAsync()
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


    Private Sub OcbsImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BgwOCBSimport.IsBusy = True Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub OCBS_IMPORT_PROCEDURES()

        Me.BgwOCBSimport.ReportProgress(50, "Select all valid procedures")
        QueryText = "SELECT * FROM [OCBS IMPORT PROCEDURES] where [Valid] in ('Y') ORDER BY [LfdNr] asc"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For p = 0 To dt1.Rows.Count - 1
                Dim ProcedureName As String = dt1.Rows.Item(p).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = ProcedureName & " for file " & COBIF.ToString
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(p).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(p).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(p).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(p).Item("FileConvertion")


                Me.BgwOCBSimport.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/NGS_IMPORTS")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters] in ('NGS_IMPORTS')"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwOCBSimport.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/NGS_IMPORTS")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        Dim FolderNameImport As String = dt1.Rows.Item(p).Item("FolderNameImport")
                        Dim FileNameImport As String = dt1.Rows.Item(p).Item("FileNameImport")
                        'Replace folder and fileName with COBIF
                        FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", COBIF.ToString)
                        FileNameImport = FileNameImport.Replace("<YYYYMMDD>", COBIF.ToString)
                        Me.BgwOCBSimport.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                        Me.BgwOCBSimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        'Check if file is zip/rar for extraction
                        If FileExtraction = "Y" Then
                            Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                            If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is a zip/rar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                        For Each item As ZipItem In archive
                                            If String.Compare(item.Name.Trim, FileNameImport.Trim) = 0 Then
                                                item.Extract(OCBSFileNewDirectory, True)
                                                Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & OCBSFileNewDirectory)
                                            End If
                                        Next item
                                    End Using
                                Else
                                    Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Continue For
                                    'Exit Sub
                                End If
                            ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is a tar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    ExtractTGZ(FolderNameImport, OCBSFileNewDirectory)
                                    Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & OCBSFileNewDirectory)
                                Else
                                    Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Continue For
                                    'Exit Sub
                                End If
                            Else
                                Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " is not recognited as archive file")
                                Continue For
                                'Exit Sub
                            End If
                        ElseIf FileExtraction = "N" Then
                            'Set correct directory format for the imported files
                            OCBSFileNewDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                            OCBSFileNewDirectory = cmd.ExecuteScalar()
                            Me.BgwOCBSimport.ReportProgress(50, "Set Import directory to:" & OCBSFileNewDirectory & "\")
                            Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " will copied to directory:" & OCBSFileNewDirectory & "\")
                            If File.Exists(Path.Combine(FolderNameImport, FileNameImport)) Then
                                File.Copy(Path.Combine(FolderNameImport, FileNameImport), Path.Combine(OCBSFileNewDirectory & "\", FileNameImport), True)
                            Else
                                Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                Continue For
                                'Exit Sub
                            End If

                        End If

                        'Set correct directory format for the imported files
                        OCBSFileNewDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        OCBSFileNewDirectory = cmd.ExecuteScalar()
                        Me.BgwOCBSimport.ReportProgress(50, "Set Import directory to:" & OCBSFileNewDirectory & "\")
                        OCBSFileNewDirectory = OCBSFileNewDirectory & "\"


                        'FileConvertion
                        If FileConvertion <> "N" Then
                            If File.Exists(FolderNameImport) Then
                                Select Case FileConvertion
                                    Case = "XLS_TO_XLSX"
                                        Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                        If FileNameImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                            Me.BgwOCBSimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                            If ConvertWorkbook Is Nothing Then
                                                ConvertWorkbook = New Workbook()
                                            End If
                                            ConvertWorkbook.LoadDocument(OCBSFileNewDirectory & FileNameImport)
                                            Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(OCBSFileNewDirectory & FileNameImport)
                                            Dim pathString As String = Path.Combine(OCBSFileNewDirectory, FileNameForConvertion)
                                            Dim resultFilePath As String = String.Empty

                                            resultFilePath = pathString & ".xlsx"
                                            If File.Exists(resultFilePath) Then
                                                File.Delete(resultFilePath)
                                            End If
                                            ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                            ConvertWorkbook = Nothing
                                            FileNameImport = FileNameImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                            Me.BgwOCBSimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                        End If
                                    Case = "CSV_TO_XLSX"
                                        Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                        If FileNameImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                            Me.BgwOCBSimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                            If ConvertWorkbook Is Nothing Then
                                                ConvertWorkbook = New Workbook()
                                            End If
                                            ConvertWorkbook.LoadDocument(OCBSFileNewDirectory & FileNameImport)
                                            ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                            Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(OCBSFileNewDirectory & FileNameImport)
                                            Dim pathString As String = Path.Combine(OCBSFileNewDirectory, FileNameForConvertion)
                                            Dim resultFilePath As String = String.Empty

                                            resultFilePath = pathString & ".xlsx"
                                            If File.Exists(resultFilePath) Then
                                                File.Delete(resultFilePath)
                                            End If
                                            ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                            ConvertWorkbook = Nothing
                                            FileNameImport = FileNameImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                            Me.BgwOCBSimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                        End If
                                End Select
                            Else
                                Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                Continue For
                                'Exit Sub
                            End If
                        End If

                        If File.Exists(Path.Combine(OCBSFileNewDirectory, FileNameImport)) Then
                            'Start checking and executing SQL Parameters
                            Me.BgwOCBSimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                            da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt3 = New DataTable()
                            da3.Fill(dt3)
                            If dt3.Rows.Count > 0 Then
                                Me.BgwOCBSimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                                Dim CUR_FILE_DIR_IMPORT As String = OCBSFileNewDirectory & FileNameImport
                                For s = 0 To dt3.Rows.Count - 1
                                    ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                    If ScriptType = "SQL" Then
                                        SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                        cmd.CommandText = SqlCommandText
                                        Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                        cmd.ExecuteNonQuery()
                                    ElseIf ScriptType = "VB" Then
                                        Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                        Dim entry As String = "VB_ScriptForExecution"
                                        If code = "" Then Return
                                        If entry = "" Then entry = "VB_ScriptForExecution"
                                        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                        Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                        engine.Run()
                                    End If

                                Next
                            Else
                                Me.BgwOCBSimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                                Continue For
                                'Exit Sub
                            End If
                        Else
                            Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & OCBSFileNewDirectory & "-" & FileNameImport & " not exists")
                            Continue For
                            'Exit Sub
                        End If

                    ElseIf ExectutionType = "SCRIPT" Then
                            Me.BgwOCBSimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwOCBSimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwOCBSimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwOCBSimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            Continue For
                            'Exit Sub
                        End If

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(50, "WARNING +++ Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/NGS_IMPORTS")
                    Continue For
                    'Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "NGS_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))


            Next
        End If

    End Sub

    Private Sub OCBS_IMPORT_PROCEDURES_MANUAL()

        Me.BgwOCBSimport.ReportProgress(50, "Select the relevant procedure")
        QueryText = "SELECT * FROM [OCBS IMPORT PROCEDURES] where ID=" & ID_Selected & " and [Valid] in ('Y') ORDER BY [LfdNr] asc"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        dt1 = New DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            For p = 0 To dt1.Rows.Count - 1
                Dim ProcedureName As String = dt1.Rows.Item(p).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = ProcedureName & " for file " & COBIF.ToString
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(p).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(p).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(p).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(p).Item("FileConvertion")


                Me.BgwOCBSimport.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/NGS_IMPORTS")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters] in ('NGS_IMPORTS')"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwOCBSimport.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/NGS_IMPORTS")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        Dim FolderNameImport As String = dt1.Rows.Item(p).Item("FolderNameImport")
                        Dim FileNameImport As String = dt1.Rows.Item(p).Item("FileNameImport")
                        'Replace folder and fileName with COBIF
                        FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", COBIF.ToString)
                        FileNameImport = FileNameImport.Replace("<YYYYMMDD>", COBIF.ToString)
                        Me.BgwOCBSimport.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                        Me.BgwOCBSimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        'Check if file is zip/rar for extraction
                        If FileExtraction = "Y" Then
                            Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                            If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an zip/rar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                        For Each item As ZipItem In archive
                                            If String.Compare(item.Name.Trim, FileNameImport.Trim) = 0 Then
                                                item.Extract(OCBSFileNewDirectory, True)
                                                Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & OCBSFileNewDirectory)
                                            End If
                                        Next item
                                    End Using
                                Else
                                    Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " is an tar archive file")
                                'Check if File exists
                                If File.Exists(FolderNameImport) Then
                                    Me.BgwOCBSimport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " exists")
                                    ExtractTGZ(FolderNameImport, OCBSFileNewDirectory)
                                    Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " extracted in Directory:" & OCBSFileNewDirectory)
                                Else
                                    Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " not exists")
                                    Exit Sub
                                End If
                            Else
                                Me.BgwOCBSimport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & FileNameImport & " is not recognited as archive file")
                                Exit Sub
                            End If
                        ElseIf FileExtraction = "N" Then
                            'Set correct directory format for the imported files
                            OCBSFileNewDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                            OCBSFileNewDirectory = cmd.ExecuteScalar()
                            Me.BgwOCBSimport.ReportProgress(50, "Set Import directory to:" & OCBSFileNewDirectory & "\")
                            Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " will copied to directory:" & OCBSFileNewDirectory & "\")
                            File.Copy(Path.Combine(FolderNameImport, FileNameImport), Path.Combine(OCBSFileNewDirectory & "\", FileNameImport), True)

                        End If

                        'Set correct directory format for the imported files
                        OCBSFileNewDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='OCBS_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        OCBSFileNewDirectory = cmd.ExecuteScalar()
                        Me.BgwOCBSimport.ReportProgress(50, "Set Import directory to:" & OCBSFileNewDirectory & "\")
                        OCBSFileNewDirectory = OCBSFileNewDirectory & "\"


                        'FileConvertion
                        If FileConvertion <> "N" Then
                            Select Case FileConvertion
                                Case = "XLS_TO_XLSX"
                                    Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                        Me.BgwOCBSimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(OCBSFileNewDirectory & FileNameImport)
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(OCBSFileNewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(OCBSFileNewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                        Me.BgwOCBSimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                                Case = "CSV_TO_XLSX"
                                    Me.BgwOCBSimport.ReportProgress(50, "File:" & FileNameImport & " marked for convertion: " & FileConvertion)
                                    If FileNameImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                        Me.BgwOCBSimport.ReportProgress(50, "Start converting File:" & FileNameImport & " from: " & FileConvertion)
                                        If ConvertWorkbook Is Nothing Then
                                            ConvertWorkbook = New Workbook()
                                        End If
                                        ConvertWorkbook.LoadDocument(OCBSFileNewDirectory & FileNameImport)
                                        ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                        Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(OCBSFileNewDirectory & FileNameImport)
                                        Dim pathString As String = Path.Combine(OCBSFileNewDirectory, FileNameForConvertion)
                                        Dim resultFilePath As String = String.Empty

                                        resultFilePath = pathString & ".xlsx"
                                        If File.Exists(resultFilePath) Then
                                            File.Delete(resultFilePath)
                                        End If
                                        ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                        ConvertWorkbook = Nothing
                                        FileNameImport = FileNameImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                        Me.BgwOCBSimport.ReportProgress(50, "File converted to:" & FileNameImport)
                                    End If
                            End Select
                        End If

                        'Start checking and executing SQL Parameters
                        Me.BgwOCBSimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwOCBSimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            Dim CUR_FILE_DIR_IMPORT As String = OCBSFileNewDirectory & FileNameImport
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwOCBSimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            Exit Sub
                        End If

                    ElseIf ExectutionType = "SCRIPT" Then
                        Me.BgwOCBSimport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwOCBSimport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwOCBSimport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwOCBSimport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwOCBSimport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            Exit Sub
                        End If

                    End If
                Else
                    Me.BgwOCBSimport.ReportProgress(50, "WARNING +++ Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/NGS_IMPORTS")
                    Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                CURRENT_PROC = "NGS_IMPORT_ACTIONS"
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
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [OCBS IMPORT PROCEDURES] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
												DECLARE @DUBLICATE_ID int=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                              
                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                
                                                INSERT INTO [OCBS IMPORT PROCEDURES]
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
                                                FROM [OCBS IMPORT PROCEDURES] where ID=@ID_A


                                                SET @DUBLICATE_NR=(select [LfdNr] from [OCBS IMPORT PROCEDURES]
                                                where ID not in (Select Min(ID) from [OCBS IMPORT PROCEDURES] 
												group by [LfdNr]))

												
                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR

                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[LfdNr] from [OCBS IMPORT PROCEDURES] 
                                                where ID in (Select Min(ID) from [OCBS IMPORT PROCEDURES] 
												where [LfdNr]=@DUBLICATE_NR)

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[LfdNr]+@NEW_RUNNING_NR from [OCBS IMPORT PROCEDURES]
                                                where ID in (Select Min(ID) from [OCBS IMPORT PROCEDURES] 
												where [LfdNr] >=@DUBLICATE_NR
                                                group by [LfdNr]) order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[LfdNr]=B.Number from [OCBS IMPORT PROCEDURES] A INNER JOIN @ID_4 B on A.ID=B.ID "
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
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
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [OCBS IMPORT PROCEDURES] where ID=@ID_A)
                                                DECLARE @MAX_LFD_NR float=(Select MAX(LfdNr) from [OCBS IMPORT PROCEDURES])
												
                                                INSERT INTO [OCBS IMPORT PROCEDURES]
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
                                                FROM [OCBS IMPORT PROCEDURES] where ID=@ID_A"
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.OCBS_IMPORT_PROCEDURESTableAdapter.Fill(Me.EDPDataSet.OCBS_IMPORT_PROCEDURES)
                focusedView.RefreshData()
                focusedView.FocusedRowHandle = GetFocusedRow

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub OCBSImportEvents_BasicView_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles OCBSImportEvents_BasicView.CustomDrawCell
        Dim AlertImage As Image = Me.ImageCollection1.Images.Item(23)
        Dim OkImage As Image = Me.ImageCollection1.Images.Item(9)
        Dim ErrorImage As Image = Me.ImageCollection1.Images.Item(22)
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


End Class