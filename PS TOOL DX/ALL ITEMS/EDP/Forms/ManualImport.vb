Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml.XmlReader
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
Imports DevExpress.XtraBars.Alerter
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
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports System.Net
Imports System.Net.NetworkInformation
Imports DevExpress.Compression
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports ICSharpCode.SharpZipLib.Tar
Imports ICSharpCode.SharpZipLib.Core




'*****************************************
'Class Name: ManualImport
'Version: V1.0.0.0
'Version Explanation:
'Author: CCBFF
'Email: info@ccbff.de
'Creation Time:
'Content:
'Function:
'Description:
'Modify log:  
'    1. Add by WYQ; Time:01.04.2022; Content: the imported file add one column "Send Type"   of  "Outward Remittance Report"， Delete this  column

'******************************************

Public Class ManualImport

    Dim EXCELL As New Microsoft.Office.Interop.Excel.Application
    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    Dim xlWorksheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Dim WithEvents EItem As Microsoft.Office.Interop.Outlook.MailItem

    Dim newCulture As System.Globalization.CultureInfo
    Dim OldCulture As System.Globalization.CultureInfo


    Dim SSISDirectory As String = Nothing

    Dim CurrentExecutingProcedure As String = Nothing

    Dim CBAIF As Double = Nothing 'CurrentImportBAISFile
    Dim LBAIF As Double = Nothing ' LastImportedBAISFile
    Dim COIFN As String = ""
    Dim CURRENT_PROC As String = Nothing
    Dim ACTIVE_PROC As String = ""

    Delegate Sub ChangeText()

    Dim MaxProcDate As Date
    Dim dir As New List(Of String)


    Dim folderDlg As New FolderBrowserDialog

    Private bgws As New List(Of BackgroundWorker)()
    Dim IDNrRowValue As Integer
    'New
    Dim ID_Selected As Integer = 0
    Dim GetFocusedRow As Integer = 0
    Dim SelectedFilesDir As New List(Of String)
    Private ConvertWorkbook As IWorkbook
    Dim ManualImportDirectory As String = Nothing
    Dim OriginalFileDirectory As String = Nothing
    Dim CurrentFileForImport As String = Nothing
    Dim OriginalSelectedFileForImport As String = Nothing
    Dim OriginalFileForDeletionStatus As String = Nothing
    Dim CUR_FILE_DIR_IMPORT As String = Nothing
    Friend WithEvents BgwFilesImport As BackgroundWorker



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

    Private Sub MANUAL_IMPORTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MANUAL_IMPORTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)

    End Sub

    Private Sub ManualImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Get Max Date
        OpenSqlConnections()
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        MaxProcDate = cmd.ExecuteScalar
        'Get SSIS Directory
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='SSIS_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SSIS_DIRECTORY'"
        SSISDirectory = cmd.ExecuteScalar()
        'Special Case - Get OPICS new Directory
        CloseSqlConnections()

        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)



    End Sub


    Private Sub bbiReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("MANUAL IMPORT PROCEDURES")
        Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
        'Get Max Date
        OpenSqlConnections()
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        MaxProcDate = cmd.ExecuteScalar
        CloseSqlConnections()
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Add_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Add_bbi.ItemClick
        Try
            Me.MANUAL_IMPORTSBindingSource.CancelEdit()
            ManualImportProcedures_BasicView.AddNewRow()
            ManualImportProcedures_BasicView.ShowEditForm()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on add new Procedure", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Save_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Save_bbi.ItemClick
        Try
            'If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Me.Validate()
            Me.MANUAL_IMPORTSBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
            Dim view As GridView = ManualImportProcedures_BasicView
            Dim focusedRow As Integer = view.FocusedRowHandle
            Me.GridControl1.BeginUpdate()
            Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
            view.RefreshData()
            Me.GridControl1.EndUpdate()
            view.FocusedRowHandle = focusedRow
            'End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Delete_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Delete_bbi.ItemClick
        Try
            Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
            Me.MANUAL_IMPORTSBindingSource.EndEdit()
            'Dim row As System.Data.DataRow = ManualImportProcedures_BasicView.GetDataRow(ManualImportProcedures_BasicView.FocusedRowHandle)
            'Dim ProcName As String = row(1)
            'Dim ID_ProcName As String = row(0)
            If XtraMessageBox.Show("Should the manual Import Procedure: " & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & " be deleted?", "DELETE MANUAL IMPORT PROCEDURE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                OpenSqlConnections()
                cmd.CommandText = "DELETE FROM [MANUAL IMPORTS] where [ID]=" & ID_Selected & ""
                cmd.ExecuteNonQuery()
                'Reset ProcNr
                cmd.CommandText = "UPDATE A SET A.ProcNr=B.rn from [MANUAL IMPORTS] A INNER JOIN 
                                       (SELECT row_number() over (order by ProcNr asc) as rn,ID
                                       from  [MANUAL IMPORTS])B On A.ID=B.ID"
                cmd.ExecuteNonQuery()
                CloseSqlConnections()
                Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Preview_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Preview_bbi.ItemClick
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub Close_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Close_bbi.ItemClick
        Me.Close()
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

    Public Sub ExtractTGZ(ByVal gzArchiveName As String, ByVal destFolder As String)

        Dim inStream As Stream = File.OpenRead(gzArchiveName)
        Dim gzipStream As Stream = New GZipInputStream(inStream)

        Dim tarArchive As TarArchive = tarArchive.CreateInputTarArchive(gzipStream)
        tarArchive.ExtractContents(destFolder)
        tarArchive.Close()

        gzipStream.Close()
        inStream.Close()
    End Sub

    Private Sub End_Excel_App(datestart As Date, dateEnd As Date)
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")
        For Each Process As Process In xlp
            If Process.StartTime >= datestart And Process.StartTime <= dateEnd Then
                Process.Kill()
                Exit For
            End If
        Next
    End Sub

#End Region

#Region "GRIDVIEWS_DEFAULT_SETTINGS"
    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                'If Me.EDPDataSet.HasChanges = True Then
                If MessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                    Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        If e.Button.Tag = "Remove" Then
            If ManualImportProcedures_BasicView.RowCount > 0 Then
                Dim row As System.Data.DataRow = ManualImportProcedures_BasicView.GetDataRow(ManualImportProcedures_BasicView.FocusedRowHandle)
                Dim ProcName As String = row(1)
                Dim ID_ProcName As String = row(0)
                If MessageBox.Show("Should the manual Import Procedure: " & ProcName & " be deleted?", "DELETE MANUAL IMPORT PROCEDURE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'Get Max Date
                    cmd.CommandText = "DELETE FROM [MANUAL IMPORTS] where [ID]='" & ID_ProcName & "'"
                    OpenSqlConnections()
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()

                    Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
                Else
                    e.Handled = True
                End If
            End If
        End If

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            Try
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Dim row As System.Data.DataRow = ManualImportProcedures_BasicView.GetDataRow(ManualImportProcedures_BasicView.FocusedRowHandle)
                Dim ProcName As String = row(1)
                Dim ID_ProcName As String = row(0)
                If MessageBox.Show("Should the manual Import Procedure: " & ProcName & " be deleted?", "DELETE MANUAL IMPORT PROCEDURE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'Get Max Date
                    cmd.CommandText = "DELETE FROM [MANUAL IMPORTS] where [ID]='" & ID_ProcName & "'"
                    OpenSqlConnections()
                    cmd.ExecuteNonQuery()
                    CloseSqlConnections()

                    'Dim ProcNameDelete As EDPDataSet.MANUAL_IMPORTSRow
                    'ProcNameDelete = EDPDataSet.MANUAL_IMPORTS.FindByID(ID_ProcName)
                    'ProcNameDelete.Delete()
                    'ManualImportProcedures_BasicView.DeleteSelectedRows()
                    'GridControl1.Update()
                    'Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)

                    Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles ManualImportProcedures_BasicView.FocusedRowChanged
        ID_Selected = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            ID_Selected = CInt(view.GetRowCellValue(rowHandle, colID))
            If view.FocusedColumn.FieldName = "ProcNr" OrElse view.FocusedColumn.FieldName = "CurrentFileName" Then
                view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
            Else
                view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplaceHideCurrentRow
            End If
        End If

        'If Me.ManualImportProcedures_BasicView.IsNewItemRow(Me.ManualImportProcedures_BasicView.FocusedRowHandle) = True Then
        '    Me.ManualImportProcedures_BasicView.Columns.ColumnByFieldName("ProcName").OptionsColumn.ReadOnly = False
        'Else
        '    Me.ManualImportProcedures_BasicView.Columns.ColumnByFieldName("ProcName").OptionsColumn.ReadOnly = True
        'End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_FocusedColumnChanged(sender As Object, e As FocusedColumnChangedEventArgs) Handles ManualImportProcedures_BasicView.FocusedColumnChanged
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.FocusedColumn.FieldName = "ProcNr" OrElse view.FocusedColumn.FieldName = "CurrentFileName" Then
                view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
            Else
                view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplaceHideCurrentRow
            End If
        End If

    End Sub

    Private Sub ManualImportProcedures_BasicView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles ManualImportProcedures_BasicView.RowCellClick
        ID_Selected = 0
        Dim view As GridView = TryCast(sender, GridView)
        Dim rowHandle As Integer = view.FocusedRowHandle
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            ID_Selected = CInt(view.GetRowCellValue(rowHandle, colID))
            If e.Column.FieldName = "ProcNr" OrElse e.Column.FieldName = "CurrentFileName" Then
                view.OptionsBehavior.EditingMode = GridEditingMode.Inplace
            Else
                view.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplaceHideCurrentRow
            End If
        End If

    End Sub

    Private Sub ManualImportProcedures_BasicView_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles ManualImportProcedures_BasicView.EditFormPrepared
        If e.BindableControls(ManualImportProcedures_BasicView.FocusedColumn) IsNot Nothing Then
            e.FocusField(ManualImportProcedures_BasicView.FocusedColumn)
        End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ManualImportProcedures_BasicView.InvalidRowException
        'Display Error in column
        'e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        'XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ManualImportProcedures_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles ManualImportProcedures_BasicView.InvalidValueException
        'Display Error in column
        'e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        'XtraMessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ManualImportProcedures_BasicView_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles ManualImportProcedures_BasicView.RowUpdated
        Dim View As GridView = CType(sender, GridView)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastAction"), "Modification")
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastImportUser"), CurrentUserWindowsID)
        View.SetRowCellValue(View.FocusedRowHandle, View.Columns("LastImportDate"), Now)
        Me.Save_bbi.PerformClick()

        'Me.GridControl1.EmbeddedNavigator.Buttons.DoClick(Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit)
    End Sub

    Private Sub SelectFileButtonEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SelectFileButtonEdit.EditValueChanged
        ManualImportProcedures_BasicView.PostEditor() 'save the cell value to a data source
        'ManualImportProcedures_BasicView.UpdateCurrentRow() 'update the row and raise the RowUpdated event
    End Sub

    Private Sub RepositoryItemSpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        ManualImportProcedures_BasicView.PostEditor() 'save the cell value to a data source
        'ManualImportProcedures_BasicView.UpdateCurrentRow() 'update the row and raise the RowUpdated event
    End Sub

    Private Sub ManualImportProcedures_BasicView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles ManualImportProcedures_BasicView.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ExectutionType"), "IMPORT")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileExtraction"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("RequestBusinessDate"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileConvertion"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("Multiselect"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("DeleteFileAfterImport"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("Importance"), "N")
        view.SetRowCellValue(e.RowHandle, view.Columns("FileExtraction"), "N")
    End Sub

    Private Sub ManualImportProcedures_BasicView_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles ManualImportProcedures_BasicView.ValidatingEditor
        'Check for Duplicate Value
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Dim currentDataView As DataView = TryCast((TryCast(sender, GridView)).DataSource, DataView)
            If view.FocusedColumn.FieldName = "ProcNr" Then
                Dim currentCode As String = e.Value.ToString()
                For i As Integer = 0 To ManualImportProcedures_BasicView.DataRowCount - 1
                    If i <> view.FocusedRowHandle Then
                        If currentCode.Equals(view.GetRowCellValue(i, colProcNr).ToString) = True Then
                            e.ErrorText = "Duplicate Parameter Value detected in Field:ProcNr."
                            e.Valid = False
                            Exit For
                        End If
                    End If

                Next
            End If
            If view.FocusedColumn.FieldName = "ProcName" Then
                Dim currentCode As String = e.Value.ToString()
                For i As Integer = 0 To ManualImportProcedures_BasicView.DataRowCount - 1
                    If i <> view.FocusedRowHandle Then
                        If currentCode.Equals(view.GetRowCellValue(i, colProcName).ToString) = True Then
                            e.ErrorText = "Duplicate Parameter Value detected in Field:ProcName."
                            e.Valid = False
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ManualImportProcedures_BasicView.RowStyle
        'Set Backcolor to Filter row
        'If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    e.Appearance.BackColor = SystemColors.InactiveCaptionText

        'End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ManualImportProcedures_BasicView.ShownEditor
        'Dim view As GridView = CType(sender, GridView)
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
        '    view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        'End If
    End Sub

    Private Sub MANUALImportEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MANUALImportEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        'If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    e.Appearance.BackColor = SystemColors.InactiveCaptionText

        'End If
    End Sub

    Private Sub MANUALImportEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles MANUALImportEvents_BasicView.ShownEditor
        'Dim view As GridView = CType(sender, GridView)
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
        '    view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        'End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ManualImportProcedures_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PROC_NR As GridColumn = View.Columns("ProcNr")
        Dim PROC_NAME As GridColumn = View.Columns("ProcName")
        Dim FILE_NAME As GridColumn = View.Columns("FileName")
        Dim FILE_DIR_IMPORT As GridColumn = View.Columns("CurrentFileName")
        Dim MULTISELECT_FILES As GridColumn = View.Columns("Multiselect")
        Dim DELETE_AFTER_IMPORT As GridColumn = View.Columns("DeleteFileAfterImport")
        Dim REQUEST_BUSINESS_DATE As GridColumn = View.Columns("RequestBusinessDate")
        Dim FILE_CONVERTION As GridColumn = View.Columns("FileConvertion")
        Dim EXECUTION_TYPE As GridColumn = View.Columns("ExectutionType")
        Dim FILE_EXTRACTION As GridColumn = View.Columns("FileExtraction")

        Dim ProcNr As String = View.GetRowCellValue(e.RowHandle, colProcNr).ToString
        Dim ProcName As String = View.GetRowCellValue(e.RowHandle, colProcName).ToString
        Dim FileName As String = View.GetRowCellValue(e.RowHandle, colFileName).ToString
        Dim FileDirImport As String = View.GetRowCellValue(e.RowHandle, colCurrentFileName).ToString
        Dim Multiselect As String = View.GetRowCellValue(e.RowHandle, colMultiselect).ToString
        Dim DeleteFileAfterImport As String = View.GetRowCellValue(e.RowHandle, colDeleteFileAfterImport).ToString
        Dim RequestBusinessDate As String = View.GetRowCellValue(e.RowHandle, colRequestBusinessDate).ToString
        Dim FileConvertion As String = View.GetRowCellValue(e.RowHandle, colFileConvertion).ToString
        Dim ExecutionType As String = View.GetRowCellValue(e.RowHandle, colExectutionType).ToString
        Dim FileExtraction As String = View.GetRowCellValue(e.RowHandle, colFileExtraction).ToString

        If ProcNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_NR, "The Procedure Nr. must not be empty")
            e.ErrorText = "The Procedure Nr. must not be empty"
        End If
        If ProcName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PROC_NAME, "The Procedure Name must not be empty")
            e.ErrorText = "The Procedure Name must not be empty"
        End If
        If FileName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_NAME, "The File Name  must not be empty")
            e.ErrorText = "The File Name must not be empty"
        End If
        If FileDirImport = "" And ExecutionType = "IMPORT" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_DIR_IMPORT, "The File Directory Import must not be empty")
            e.ErrorText = "The File Directory Import must not be empty"
        End If
        If Multiselect = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(MULTISELECT_FILES, "The Multiselect Files option must not be empty")
            e.ErrorText = "The Multiselect Files option must not be empty"
        End If
        If DeleteFileAfterImport = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(DELETE_AFTER_IMPORT, "The Delete File after import option must not be empty")
            e.ErrorText = "The Delete File after import option must not be empty"
        End If
        If RequestBusinessDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(REQUEST_BUSINESS_DATE, "The Request Business Date option must not be empty")
            e.ErrorText = "The Request Business Date option must not be empty"
        End If
        If FileConvertion = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_CONVERTION, "The File Convertion option must not be empty")
            e.ErrorText = "The File Convertion option must not be empty"
        End If
        If ExecutionType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(EXECUTION_TYPE, "The Execution Type must not be empty")
            e.ErrorText = "The Execution Type must not be empty"
        End If
        If FileExtraction = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_EXTRACTION, "The File Extraction option must not be empty")
            e.ErrorText = "The File Extraction option must not be empty"
        End If
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
        Dim reportfooter As String = "MANUAL IMPORT PROCEDURES"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
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

    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

    End Sub


    Private Sub ManualImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bgws.Count > 0 Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub SelectFileButtonEdit_Click(sender As Object, e As EventArgs) Handles SelectFileButtonEdit.Click
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        Dim view As GridView = Me.GridControl1.FocusedView
        Dim focusedRow As Integer = view.FocusedRowHandle

        'Select files from the specific directory based on the file path
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colExectutionType) = "IMPORT" Then
            With XtraOpenFileDialog1
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|Text Files (*.txt)|*.txt|Csv Files (*.csv;*.CSV)|*.csv;*.CSV|XML Files (*.xml;*.XML)|*.xml;*.XML|ORIG Files (*.orig;*.ORIG)|*.orig;*.ORIG|All Files|*.*"
                .FilterIndex = 1
                If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                    .InitialDirectory = "C:\"
                Else
                    .InitialDirectory = Path.GetDirectoryName(Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName))
                End If
                .FileName = Nothing
                .Title = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcNr) & " - " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName)
                .RestoreDirectory = True
                Dim Multiselection As String = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colMultiselect)
                Select Case Multiselection
                    Case = "Y"
                        .Multiselect = True
                    Case Else
                        .Multiselect = False
                End Select
                SelectedFilesDir.Clear()
                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    For Each SelectedFile As String In XtraOpenFileDialog1.FileNames
                        SelectedFilesDir.Add(SelectedFile)
                        Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    Next
                End If
            End With
        End If




    End Sub

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
    Private Sub StartImportButtonEdit_Click(sender As Object, e As EventArgs) Handles StartImportButtonEdit.Click
        'IMPORT FILES
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colExectutionType) = "IMPORT" Then
            If SelectedFilesDir.Count > 0 Then
                If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colRequestBusinessDate) = "Y" Then
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
                    editor.Properties.Mask.EditMask = "dd.MM.yyyy"
                    args.Editor = editor
                    ' a default DateEdit value
                    args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                    ' display an Input Box with the custom editor

                    Dim obj = XtraInputBox.Show(args)
                    If obj Is Nothing Then
                        Exit Sub
                    End If
                    If IsDate(obj) = True Then
                        rd = CDate(obj)
                        rdsql = rd.ToString("yyyyMMdd")
                    Else
                        Exit Sub
                    End If
                End If

                If XtraMessageBox.Show("Should the selected procedure be executed?", Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Me.MANUAL_IMPORTSBindingSource.EndEdit()
                    Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                    OriginalFileForDeletionStatus = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colDeleteFileAfterImport)
                    OriginalSelectedFileForImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
                    'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    'Me.GridControl1.Enabled = False
                    Me.RibbonPageGroup1.Enabled = False
                    Me.XtraTabControl1.SelectedTabPageIndex = 1
                    Me.XtraTabControl1.TabPages(0).PageVisible = False
                    Me.LayoutControlGroup5.Visibility = LayoutVisibility.Always
                    Me.EmptySpaceItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                    Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                    'Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                    'Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                    CurrentSystemExecuting = "MANUAL_IMPORTS"
                    BgwFilesImport = New BackgroundWorker
                    bgws.Add(BgwFilesImport)
                    BgwFilesImport.WorkerReportsProgress = True
                    BgwFilesImport.RunWorkerAsync()
                Else
                    Exit Sub
                End If
            Else
                XtraMessageBox.Show("There are no selected files for import" & vbNewLine & "Please select first the relevant files for import!", "UNABLE TO PROCEED WITH THE IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If

        End If


        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'WEB-SCRIPT
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colExectutionType) <> "IMPORT" Then
            If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colRequestBusinessDate) = "Y" Then
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
                editor.Properties.Mask.EditMask = "dd.MM.yyyy"
                args.Editor = editor
                ' a default DateEdit value
                args.DefaultResponse = Today 'Date.Now.Date.AddDays(0)
                ' display an Input Box with the custom editor

                Dim obj = XtraInputBox.Show(args)
                If obj Is Nothing Then
                    Exit Sub
                End If
                If IsDate(obj) = True Then
                    rd = CDate(obj)
                    rdsql = rd.ToString("yyyyMMdd")
                Else
                    Exit Sub
                End If
            End If

            If XtraMessageBox.Show("Should the selected procedure be executed?", Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                OriginalFileForDeletionStatus = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colDeleteFileAfterImport)
                OriginalSelectedFileForImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileName)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                'Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.XtraTabControl1.SelectedTabPageIndex = 1
                Me.XtraTabControl1.TabPages(0).PageVisible = False
                Me.LayoutControlGroup5.Visibility = LayoutVisibility.Always
                Me.EmptySpaceItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                'Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                'Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                CurrentSystemExecuting = "MANUAL_IMPORTS"
                BgwFilesImport = New BackgroundWorker
                bgws.Add(BgwFilesImport)
                BgwFilesImport.WorkerReportsProgress = True
                BgwFilesImport.RunWorkerAsync()
            Else
                Exit Sub
            End If

        End If


    End Sub

    Private Sub BgwFilesImport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwFilesImport.DoWork

        'Get Current data directory and temporary directory
        Me.BgwFilesImport.ReportProgress(10, "Locate the Manual Imports Temp Directory")
        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='MANUAL_IMPORT_TEMP_DIR' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
        ManualImportDirectory = cmd.ExecuteScalar()
        CloseSqlConnections()

        Try
            OpenSqlConnections()
            CurrentSystemExecuting = "MANUAL_IMPORTS"
            CURRENT_PROC = "MANUAL_IMPORT_ACTIONS"
            Me.BgwFilesImport.ReportProgress(85, "Create import Directory: " & "  " & ManualImportDirectory)
            If Not Directory.Exists(ManualImportDirectory) Then
                Directory.CreateDirectory(ManualImportDirectory)
            ElseIf Directory.Exists(ManualImportDirectory) Then
                Directory.Delete(ManualImportDirectory, True)
                Directory.CreateDirectory(ManualImportDirectory)
            End If

            IMPORT_PROCEDURES_MANUAL_FILES()

            Me.BgwFilesImport.ReportProgress(85, "Delete import Directory: " & "  " & ManualImportDirectory)
            If Directory.Exists(ManualImportDirectory) Then
                Directory.Delete(ManualImportDirectory, True)
            End If

            If OriginalFileForDeletionStatus = "Y" AndAlso OriginalSelectedFileForImport <> "" Then
                Me.BgwFilesImport.ReportProgress(85, "Delete file: " & "  " & OriginalSelectedFileForImport)
                File.Delete(OriginalSelectedFileForImport)
            End If

            Me.BgwFilesImport.ReportProgress(85, "Manual import procedure: " & CURRENT_PROC & " executed successfully!")

            CloseSqlConnections()


        Catch ex As System.Exception
            Me.BgwFilesImport.ReportProgress(0, "ERROR +++" & " " & ex.Message.ToString.Replace("'", " "))
            Exit Sub
        Finally
            Me.BgwFilesImport.CancelAsync()
            If Directory.Exists(ManualImportDirectory) Then
                Directory.Delete(ManualImportDirectory, True)
            End If
        End Try

    End Sub

    Private Sub BgwFilesImport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwFilesImport.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('" & e.UserState & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & CURRENT_PROC & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcDate],[ProcName],[SystemName]) 
                                    Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "',(SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))),'" & CURRENT_PROC & "','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & CURRENT_PROC & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        ''See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwFilesImport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwFilesImport.RunWorkerCompleted
        'Me.GridControl1.Enabled = True
        SelectedFilesDir.Clear()

        Me.RibbonPageGroup1.Enabled = True
        Me.XtraTabControl1.TabPages(0).PageVisible = True

        Me.LayoutControlGroup5.Visibility = LayoutVisibility.Never
        Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colLastImportDate, Today)
        Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colLastImportTime, Now.ToShortTimeString)
        Me.MANUAL_IMPORTSBindingSource.EndEdit()
        Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
        Dim view As GridView = ManualImportProcedures_BasicView
        Dim focusedRow As Integer = view.FocusedRowHandle
        Me.GridControl1.BeginUpdate()
        Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
        view.RefreshData()
        Me.GridControl1.EndUpdate()
        view.FocusedRowHandle = focusedRow
        'Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        'Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwFilesImport, e)
        'SplashScreenManager.CloseForm(False)
    End Sub


    Private Sub IMPORT_PROCEDURES_MANUAL_FILES()
        CurrentSystemExecuting = "MANUAL_IMPORTS"
        'Files Import
        If SelectedFilesDir.Count > 0 Then

            Me.BgwFilesImport.ReportProgress(50, "Select the relevant manual procedure")
            QueryText = "SELECT * FROM [MANUAL IMPORTS] where ID=" & ID_Selected & " ORDER BY [ProcNr] asc"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            dt1 = New DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                Dim ProcedureName As String = dt1.Rows.Item(0).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))


                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(0).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(0).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(0).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(0).Item("FileConvertion")


                Me.BgwFilesImport.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/MANUAL_IMPORTS")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwFilesImport.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/MANUAL_IMPORTS")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "IMPORT" Then
                        For i = 0 To SelectedFilesDir.Count - 1
                            OriginalFileDirectory = SelectedFilesDir.Item(i).ToString 'Fulle file directory
                            CurrentFileForImport = Path.GetFileName(SelectedFilesDir.Item(i).ToString) ' File Name with extension
                            CURRENT_PROC = ProcedureName & " for file " & CurrentFileForImport
                            CurrentProcedureName = ProcedureName
                            Dim FolderNameImport As String = dt1.Rows.Item(0).Item("CurrentFileName")
                            Dim FileNameImport As String = OriginalFileDirectory
                            'Replace folder and fileName with rdsql if its not NULL
                            If rdsql <> Nothing Then
                                FolderNameImport = FolderNameImport.Replace("<YYYYMMDD>", rdsql)
                                FileNameImport = FileNameImport.Replace("<YYYYMMDD>", rdsql)
                            End If
                            Me.BgwFilesImport.ReportProgress(50, "Folder/File for import:" & FolderNameImport & "-" & FileNameImport)
                            Me.BgwFilesImport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                            'Check if file is zip/rar for extraction
                            If FileExtraction = "Y" Then
                                CurrentFileForImport = FileNameImport
                                Me.BgwFilesImport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & FileNameImport & " marked for extraction")
                                If FolderNameImport.ToUpper.EndsWith(".ZIP") = True OrElse FolderNameImport.ToUpper.EndsWith(".RAR") = True Then
                                    Me.BgwFilesImport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " is an zip/rar archive file")
                                    'Check if File exists
                                    If File.Exists(FolderNameImport) Then
                                        Me.BgwFilesImport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " exists")
                                        Using archive As ZipArchive = ZipArchive.Read(FolderNameImport)
                                            For Each item As ZipItem In archive
                                                If String.Compare(item.Name.Trim, CurrentFileForImport.Trim) = 0 Then
                                                    item.Extract(ManualImportDirectory, True)
                                                    Me.BgwFilesImport.ReportProgress(50, "File:" & CurrentFileForImport & " extracted in Directory:" & ManualImportDirectory)
                                                End If
                                            Next item
                                        End Using
                                    Else
                                        Me.BgwFilesImport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " not exists")
                                        Exit Sub
                                    End If
                                ElseIf FolderNameImport.ToUpper.EndsWith(".TAR.GZ") = True Then
                                    Me.BgwFilesImport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " is an tar archive file")
                                    'Check if File exists
                                    If File.Exists(FolderNameImport) Then
                                        Me.BgwFilesImport.ReportProgress(50, "Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " exists")
                                        ExtractTGZ(FolderNameImport, ManualImportDirectory)
                                        Me.BgwFilesImport.ReportProgress(50, "File:" & CurrentFileForImport & " extracted in Directory:" & ManualImportDirectory)
                                    Else
                                        Me.BgwFilesImport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " not exists")
                                        Exit Sub
                                    End If
                                Else
                                    Me.BgwFilesImport.ReportProgress(50, "ERROR +++ Folder/File:" & FolderNameImport & "-" & CurrentFileForImport & " is not recognited as archive file")
                                    Exit Sub
                                End If
                            ElseIf FileExtraction = "N" Then
                                'Set correct directory format for the imported files
                                ManualImportDirectory = Nothing
                                cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='MANUAL_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                                ManualImportDirectory = cmd.ExecuteScalar()
                                Me.BgwFilesImport.ReportProgress(50, "Set Import directory to:" & ManualImportDirectory & "\")
                                Me.BgwFilesImport.ReportProgress(50, "File:" & CurrentFileForImport & " will copied to directory:" & ManualImportDirectory & "\")
                                File.Copy(OriginalFileDirectory, Path.Combine(ManualImportDirectory & "\", CurrentFileForImport), True)

                            End If

                            'Set correct directory format for the imported files
                            ManualImportDirectory = Nothing
                            cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='MANUAL_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                            ManualImportDirectory = cmd.ExecuteScalar()
                            Me.BgwFilesImport.ReportProgress(50, "Set Import directory to:" & ManualImportDirectory & "\")
                            ManualImportDirectory = ManualImportDirectory & "\"


                            'FileConvertion
                            If FileConvertion <> "N" Then
                                Select Case FileConvertion
                                    Case = "XLS_TO_XLSX"
                                        Me.BgwFilesImport.ReportProgress(50, "File:" & CurrentFileForImport & " marked for convertion: " & FileConvertion)
                                        If CurrentFileForImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                            Me.BgwFilesImport.ReportProgress(50, "Start converting File:" & CurrentFileForImport & " from: " & FileConvertion)
                                            If ConvertWorkbook Is Nothing Then
                                                ConvertWorkbook = New Workbook()
                                            End If
                                            ConvertWorkbook.LoadDocument(ManualImportDirectory & CurrentFileForImport)
                                            Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(ManualImportDirectory & CurrentFileForImport)
                                            Dim pathString As String = Path.Combine(ManualImportDirectory, FileNameForConvertion)
                                            Dim resultFilePath As String = String.Empty

                                            resultFilePath = pathString & ".xlsx"
                                            If File.Exists(resultFilePath) Then
                                                File.Delete(resultFilePath)
                                            End If
                                            ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                            ConvertWorkbook = Nothing
                                            CurrentFileForImport = CurrentFileForImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                            Me.BgwFilesImport.ReportProgress(50, "File converted to:" & CurrentFileForImport)
                                        End If
                                    Case = "WEBXLS_TO_XLSX"
                                        Me.BgwFilesImport.ReportProgress(50, "File:" & CurrentFileForImport & " marked for convertion: " & FileConvertion)
                                        If CurrentFileForImport.ToUpper.Trim.EndsWith(".XLS") = True Then
                                            Me.BgwFilesImport.ReportProgress(50, "Start converting File:" & CurrentFileForImport & " from: " & FileConvertion)
                                            '+++++++++++++++++++++++++++++++++++
                                            'StartDate for ExcelProcess
                                            Dim datestart As Date = Date.Now
                                            EXCELL = CreateObject("Excel.Application")
                                            xlWorkBook = EXCELL.Workbooks.Open(ManualImportDirectory & CurrentFileForImport)
                                            EXCELL.Visible = False
                                            EXCELL.DisplayAlerts = False
                                            xlWorkBook.SaveAs(ManualImportDirectory & CurrentFileForImport, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                                            EXCELL.DisplayAlerts = True
                                            xlWorkBook.Close()
                                            EXCELL.Quit()
                                            EXCELL = Nothing
                                            'EndDate for excel Process
                                            Dim dateEnd As Date = Date.Now
                                            End_Excel_App(datestart, dateEnd) ' This closes excel proces
                                            '+++++++++++++++++++++++++++++++++
                                            If ConvertWorkbook Is Nothing Then
                                                ConvertWorkbook = New Workbook()
                                            End If
                                            ConvertWorkbook.LoadDocument(ManualImportDirectory & CurrentFileForImport)
                                            Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(ManualImportDirectory & CurrentFileForImport)
                                            Dim pathString As String = Path.Combine(ManualImportDirectory, FileNameForConvertion)
                                            Dim resultFilePath As String = String.Empty

                                            resultFilePath = pathString & ".xlsx"
                                            If File.Exists(resultFilePath) Then
                                                File.Delete(resultFilePath)
                                            End If
                                            ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                            ConvertWorkbook = Nothing
                                            CurrentFileForImport = CurrentFileForImport.Replace(".xls", ".xlsx").ToString.Replace(".XLS", ".xlsx")
                                            Me.BgwFilesImport.ReportProgress(50, "File converted to:" & CurrentFileForImport)
                                        End If
                                    Case = "CSV_TO_XLSX"
                                        Me.BgwFilesImport.ReportProgress(50, "File:" & CurrentFileForImport & " marked for convertion: " & FileConvertion)
                                        If CurrentFileForImport.ToUpper.Trim.EndsWith(".CSV") = True Then
                                            Me.BgwFilesImport.ReportProgress(50, "Start converting File:" & CurrentFileForImport & " from: " & FileConvertion)
                                            If ConvertWorkbook Is Nothing Then
                                                ConvertWorkbook = New Workbook()
                                            End If
                                            ConvertWorkbook.LoadDocument(ManualImportDirectory & CurrentFileForImport)
                                            ConvertWorkbook.Worksheets(0).PrintOptions.FitToPage = True
                                            Dim FileNameForConvertion As String = Path.GetFileNameWithoutExtension(ManualImportDirectory & CurrentFileForImport)
                                            Dim pathString As String = Path.Combine(ManualImportDirectory, FileNameForConvertion)
                                            Dim resultFilePath As String = String.Empty

                                            resultFilePath = pathString & ".xlsx"
                                            If File.Exists(resultFilePath) Then
                                                File.Delete(resultFilePath)
                                            End If
                                            ConvertWorkbook.SaveDocument(resultFilePath, DocumentFormat.OpenXml)
                                            ConvertWorkbook = Nothing
                                            CurrentFileForImport = CurrentFileForImport.Replace(".csv", ".xlsx").ToString.Replace(".CSV", ".xlsx")
                                            Me.BgwFilesImport.ReportProgress(50, "File converted to:" & CurrentFileForImport)
                                        End If
                                End Select
                            End If

                            'Start checking and executing SQL Parameters
                            Me.BgwFilesImport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                            QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                            da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt3 = New DataTable()
                            da3.Fill(dt3)
                            If dt3.Rows.Count > 0 Then
                                Me.BgwFilesImport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                                CUR_FILE_DIR_IMPORT = Nothing
                                CUR_FILE_DIR_IMPORT = ManualImportDirectory & CurrentFileForImport
                                For s = 0 To dt3.Rows.Count - 1
                                    ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                    If ScriptType = "SQL" Then
                                        SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                        cmd.CommandText = SqlCommandText
                                        Me.BgwFilesImport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                        cmd.ExecuteNonQuery()
                                    ElseIf ScriptType = "VB" Then
                                        Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                        Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                        Dim entry As String = "VB_ScriptForExecution"
                                        If code = "" Then Return
                                        If entry = "" Then entry = "VB_ScriptForExecution"
                                        Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                        Me.BgwFilesImport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                        engine.Run()
                                    End If
                                Next
                                If File.Exists(CUR_FILE_DIR_IMPORT) Then
                                    File.Delete(CUR_FILE_DIR_IMPORT)
                                End If
                                If OriginalFileForDeletionStatus = "Y" Then
                                    Me.BgwFilesImport.ReportProgress(85, "Delete original file: " & "  " & OriginalFileDirectory)
                                    If File.Exists(OriginalFileDirectory) Then
                                        File.Delete(OriginalFileDirectory)
                                    End If
                                End If
                            Else
                                Me.BgwFilesImport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                                Exit Sub
                            End If
                        Next 'Next selected file in list
                    End If
                Else
                    Me.BgwFilesImport.ReportProgress(50, "WARNING +++ Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/MANUAL_IMPORTS")
                    Exit Sub
                End If


                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                'CURRENT_PROC = "MANUAL_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))



            End If






        End If

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        'WEB Import - SCRIPT Execution
        If SelectedFilesDir.Count = 0 Then
            Me.BgwFilesImport.ReportProgress(50, "Select the relevant manual procedure")
            QueryText = "SELECT * FROM [MANUAL IMPORTS] where ID=" & ID_Selected & " ORDER BY [ProcNr] asc"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            dt1 = New DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                Dim ProcedureName As String = dt1.Rows.Item(0).Item("ProcName")
                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))

                CurrentFileForImport = dt1.Rows.Item(0).Item("FileName")
                CURRENT_PROC = ProcedureName
                CurrentProcedureName = ProcedureName

                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))

                Dim ExectutionType As String = dt1.Rows.Item(0).Item("ExectutionType")
                Dim FileExtraction As String = dt1.Rows.Item(0).Item("FileExtraction")
                Dim RequestBusinessDate As String = dt1.Rows.Item(0).Item("RequestBusinessDate")
                Dim FileConvertion As String = dt1.Rows.Item(0).Item("FileConvertion")


                Me.BgwFilesImport.ReportProgress(50, "Check if procedure exists and is valid in SQL PARAMETERS/MANUAL_IMPORTS")
                QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS] where [Status] in ('Y') and LTRIM(RTRIM(SQL_Name_1))='" & ProcedureName.Trim & "'
                             and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                da2 = New SqlDataAdapter(QueryText.Trim(), conn)
                dt2 = New DataTable()
                da2.Fill(dt2)
                If dt2.Rows.Count > 0 Then
                    Me.BgwFilesImport.ReportProgress(50, "Procedure: " & ProcedureName & " exists and is valid in SQL PARAMETERS/MANUAL_IMPORTS")

                    Dim ParameterName_ID As Integer = dt2.Rows.Item(0).Item("ID")

                    'Check ExecutionType
                    If ExectutionType = "WEB" Then
                        Dim FileNameImport As String = dt1.Rows.Item(0).Item("FileName")
                        CURRENT_PROC = ProcedureName & " for file " & CurrentFileForImport
                        'Replace folder and fileName with rdsql if its not NULL
                        If rdsql <> Nothing Then
                            FileNameImport = FileNameImport.Replace("<YYYYMMDD>", rdsql)
                        End If
                        Me.BgwFilesImport.ReportProgress(50, "Web File for import:" & FileNameImport)
                        Me.BgwFilesImport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)


                        'Set correct directory format for the imported files
                        ManualImportDirectory = Nothing
                        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='MANUAL_IMPORT_TEMP_DIR' AND[PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='OCBS_IMPORT'"
                        ManualImportDirectory = cmd.ExecuteScalar()
                        Me.BgwFilesImport.ReportProgress(50, "Set Import directory to:" & ManualImportDirectory & "\")
                        ManualImportDirectory = ManualImportDirectory & "\"


                        'Start checking and executing SQL Parameters
                        Me.BgwFilesImport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwFilesImport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                            Dim CUR_FILE_DIR_IMPORT As String = CurrentFileForImport
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwFilesImport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE>", CUR_FILE_DIR_IMPORT).ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwFilesImport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If
                            Next
                            If OriginalFileForDeletionStatus = "Y" Then
                                Me.BgwFilesImport.ReportProgress(85, "Delete original file: " & "  " & OriginalFileDirectory)
                            End If
                        Else
                            Me.BgwFilesImport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                            Exit Sub
                        End If


                    ElseIf ExectutionType = "SCRIPT" Then
                        Me.BgwFilesImport.ReportProgress(50, "For procedure: " & ProcedureName & " the execution type is: " & ExectutionType)
                        Me.BgwFilesImport.ReportProgress(50, "Load and execute parameters from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                        QueryText = "SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Status] in ('Y') and ISNULL(SQL_Name_1,'')<>''
                                     and ISNULL(SQL_Command_1,'')<>'' and [Id_SQL_Parameters_Details]=" & ParameterName_ID & "
                                     ORDER BY [SQL_Float_1] asc"
                        da3 = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt3 = New DataTable()
                        da3.Fill(dt3)
                        If dt3.Rows.Count > 0 Then
                            Me.BgwFilesImport.ReportProgress(50, "Start executing parameters from SQL PARAMETERS/NGS_IMPORTS/" & ProcedureName)
                            For s = 0 To dt3.Rows.Count - 1
                                ScriptType = dt3.Rows.Item(s).Item("SQL_ScriptType_1").ToString
                                If ScriptType = "SQL" Then
                                    SqlCommandText = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<RiskDate>", rdsql)
                                    cmd.CommandText = SqlCommandText
                                    Me.BgwFilesImport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    cmd.ExecuteNonQuery()
                                ElseIf ScriptType = "VB" Then
                                    Dim code As String = dt3.Rows.Item(s).Item("SQL_Command_1").ToString.Replace("<rd>", rd).ToString.Replace("<rdsql>", rdsql).ToString.Replace("<SQL_SERVER>", TOOL_SQL_SERVER_ONLY).ToString.Replace("<SQL_DATABASE>", TOOL_SQL_DATABASE).Trim()
                                    Dim language As DynamicCompileAndRun.LanguageType = DynamicCompileAndRun.LanguageType.VB
                                    Dim entry As String = "VB_ScriptForExecution"
                                    If code = "" Then Return
                                    If entry = "" Then entry = "VB_ScriptForExecution"
                                    Dim engine As DynamicCompileAndRun.CompileEngine = New DynamicCompileAndRun.CompileEngine(code, language, entry)
                                    Me.BgwFilesImport.ReportProgress(s, dt3.Rows.Item(s).Item("SQL_Name_1") & " - Procedure:" & ProcedureName & " - Nr.: " & dt3.Rows.Item(s).Item("SQL_Float_1").ToString)
                                    engine.Run()
                                End If

                            Next
                        Else
                            Me.BgwFilesImport.ReportProgress(50, "WARNING +++ No valid parameters found from SQL PARAMETERS/MANUAL_IMPORTS/" & ProcedureName)
                            Exit Sub
                        End If

                    End If
                Else
                    Me.BgwFilesImport.ReportProgress(50, "WARNING +++ Procedure: " & ProcedureName & " not exists and/or is not valid in SQL PARAMETERS/MANUAL_IMPORTS")
                    Exit Sub
                End If

                'CURRENT_PROC = Nothing
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Clear_CURRENT_PROC))
                'CURRENT_PROC = "MANUAL_IMPORT_ACTIONS"
                'Me.CURRENT_PROCEDURE_Text.BeginInvoke(New ChangeText(AddressOf Change_CURRENT_PROC))



            End If

        End If


    End Sub

    Private Sub ManualImportProcedures_BasicView_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles ManualImportProcedures_BasicView.PopupMenuShowing
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle AndAlso view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                e.Allow = False
                Me.ProceduresGridviewPopupMenu.ShowPopup(GridControl1.PointToScreen(e.Point))
            End If
        End If
    End Sub

    Private Sub MANUALImportEvents_BasicView_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles MANUALImportEvents_BasicView.CustomDrawCell
        Dim AlertImage As Image = Me.ImageCollection1.Images.Item(23)
        Dim OkImage As Image = Me.ImageCollection1.Images.Item(14)
        Dim ErrorImage As Image = Me.ImageCollection1.Images.Item(15)
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
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [MANUAL IMPORTS] where ID=@ID_A)
                                                DECLARE @DUBLICATE_NR float=0
												DECLARE @DUBLICATE_ID int=0
                                                DECLARE @NEW_RUNNING_NR float=0
                                              
                                                DECLARE @ID_3 table (ID int NULL,Number float)
                                                DECLARE @ID_4 table (ID int NULL,Number float)

                                                
                                                INSERT INTO [MANUAL IMPORTS]
                                                           ([ProcNr]
														   ,[ProcName]
														   ,[FileName]
														   ,[FileDirImport]
														   ,[CurrentFileName]
														   ,[InternalNotes]
														   ,[Multiselect]
														   ,[DeleteFileAfterImport]
														   ,[RequestBusinessDate]
														   ,[FileConvertion]
														   ,[ExectutionType]
														   ,[FileExtraction]
														   ,[Importance]
														   ,[LastImportDate]
														   ,[LastImportTime]
														   ,[LastAction]
														   ,[LastImportUser])
                                                SELECT		[ProcNr]+1
														   ,@Procedure_Name_New
                                                           ,[FileName]
														   ,[FileDirImport]
														   ,[CurrentFileName]
														   ,[InternalNotes]
														   ,[Multiselect]
														   ,[DeleteFileAfterImport]
														   ,[RequestBusinessDate]
														   ,[FileConvertion]
														   ,[ExectutionType]
														   ,[FileExtraction]
														   ,[Importance]
														   ,GETDATE()
														   ,GETDATE()
                                                           ,'DUPLICATED'
                                                           ,@CURRENT_USER
                                                FROM [MANUAL IMPORTS] where ID=@ID_A


                                                SET @DUBLICATE_NR=(select [ProcNr] from [MANUAL IMPORTS]
                                                where ID not in (Select Min(ID) from [MANUAL IMPORTS] 
												group by [ProcNr]))

												
                                                IF @DUBLICATE_NR>0
                                                BEGIN
                                                SELECT @DUBLICATE_NR

                                                --Find equal Nr to @DUPLICATE
                                                INSERT INTO @ID_3
                                                (ID,Number)
                                                select ID,[ProcNr] from [MANUAL IMPORTS] 
                                                where ID in (Select Min(ID) from [MANUAL IMPORTS] 
												where [ProcNr]=@DUBLICATE_NR)

                                                SET @NEW_RUNNING_NR=@DUBLICATE_NR-(Select Number from @ID_3)
                                                IF @NEW_RUNNING_NR=0
                                                BEGIN
                                                SET @NEW_RUNNING_NR=1
                                                INSERT INTO @ID_4
                                                (ID,Number)
                                                Select ID,[ProcNr]+@NEW_RUNNING_NR from [MANUAL IMPORTS]
                                                where ID in (Select Min(ID) from [MANUAL IMPORTS] 
												where [ProcNr] >=@DUBLICATE_NR
                                                group by [ProcNr]) order by ID asc
                                                END
                                                END

                                                UPDATE A SET A.[ProcNr]=B.Number from [MANUAL IMPORTS] A INNER JOIN @ID_4 B on A.ID=B.ID"
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
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
                                                DECLARE @Procedure_Name_New nvarchar(100)='NEW_' + (Select ProcName from [MANUAL IMPORTS] where ID=@ID_A)
                                                DECLARE @MAX_LFD_NR float=(Select MAX(ProcNr) from [MANUAL IMPORTS])
												
                                                INSERT INTO [MANUAL IMPORTS]
                                                           ([ProcNr]
														   ,[ProcName]
														   ,[FileName]
														   ,[FileDirImport]
														   ,[CurrentFileName]
														   ,[InternalNotes]
														   ,[Multiselect]
														   ,[DeleteFileAfterImport]
														   ,[RequestBusinessDate]
														   ,[FileConvertion]
														   ,[ExectutionType]
														   ,[FileExtraction]
														   ,[Importance]
														   ,[LastImportDate]
														   ,[LastImportTime]
														   ,[LastAction]
														   ,[LastImportUser])
                                                SELECT		@MAX_LFD_NR+1
														   ,@Procedure_Name_New
                                                           ,[FileName]
														   ,[FileDirImport]
														   ,[CurrentFileName]
														   ,[InternalNotes]
														   ,[Multiselect]
														   ,[DeleteFileAfterImport]
														   ,[RequestBusinessDate]
														   ,[FileConvertion]
														   ,[ExectutionType]
														   ,[FileExtraction]
														   ,[Importance]
														   ,GETDATE()
														   ,GETDATE()
                                                           ,'DUPLICATED'
                                                           ,@CURRENT_USER
                                                FROM [MANUAL IMPORTS] where ID=@ID_A"
                cmd.CommandText = cmd.CommandText.ToString.Replace("<ID_to_DUPLICATE>", ID_Selected).Replace("<CurrentUser>", SystemInformation.UserName)
                cmd.CommandText = cmd.CommandText
                cmd.ExecuteNonQuery()
                SplashScreenManager.CloseForm(False)

                XtraMessageBox.Show("Procedure:" & focusedView.GetRowCellValue(focusedView.FocusedRowHandle, "ProcName") & vbNewLine & "successfull duplicated", "DUPLICATION FINISHED", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CloseSqlConnections()
                Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
                focusedView.RefreshData()
                focusedView.FocusedRowHandle = GetFocusedRow

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class

