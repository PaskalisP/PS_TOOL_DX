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

    Dim OCBS_Temp_Directory As String = ""
    Dim ODAS_Temp_Directory As String = ""
    Dim BAIS_Temp_Directory As String = ""


    Dim BAISDirectory As String = "" 'OCBS FILE DIRECTORY
    Dim BAISFileNewDirectory As String = "" 'NEW DIRECTORY FOR OCBS FILE


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

    Dim CurrentExecutingProcedure As String = Nothing

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
    Dim CURRENT_LAST_IMPORTED_BAIS_FILE As Double = Nothing

    Dim MaxProcDate As Date
    Dim BAIS_Date As Date
    Dim SqlBAISDate As String = ""
    Dim MM_Tradedate As String = Nothing
    Dim FX_Tradedate As String = Nothing

    Dim MaxExchangeRateDate As Date
    Dim MaxExchangeRateDateSql As String

    Dim BIC_DIR_FILE As String = ""
    Dim BicFileDirectoryImport As String = ""
    Dim BANK_DIR_PLUS_FILE As String = ""
    Dim BankDirPlusFileDirectoryImport As String = ""
    Dim BIC_PLUS_DIR_FILE As String = ""
    Dim BicPlusFileDirectoryImport As String = ""
    Dim SEPA_DIR_FILE As String = ""
    Dim SepaFileDirectoryImport As String = ""
    Dim SEPA_FULL_DIR_FILE As String = ""
    Dim SepaFullFileDirectoryImport As String = ""
    Dim BLZ_DIR_FILE As String = ""
    Dim BlzFileDirectoryImport As String = ""
    Dim CUST_INFO_DIR_FILE As String = ""
    Dim CustInfoFileDirectoryImport As String = ""
    Dim CUST_ACC_INFO_DIR_FILE As String = ""
    Dim CustAccInfoFileDirectoryImport As String = ""
    Dim ODAS_REMMITANCE_PAY_FILE As String = ""
    Dim OdasRemmitanceFileDirectoryImport As String = ""
    Dim GMPS_PAY_FILE As String = ""
    Dim GMPSFileDirectoryImport As String = ""
    Dim ECB_RATES_FILE As String = ""
    Dim ECB_RATES_FileDirectoryImport As String = ""
    Dim MULTIBANK_KONVERTER_KONTOINHABER_FILE As String = ""
    Dim MULTIBANK_KONVERTER_Kontoinhaber_FileDirectoryImport As String = ""
    Dim T2_DIR_FILE As String = ""
    Dim T2FileDirectoryImport As String = ""
    Dim T2_XML_DIR_FILE As String = ""
    Dim T2_XML_FileDirectoryImport As String = ""
    Dim FX_DIR_FILE As String = ""
    Dim FXFileDirectoryImport As String = ""
    Dim IBAN_PLUS_FULL_DIR As String = ""
    Dim IbanPlusFullDirectoryImport As String = ""
    Dim IBAN_STRUCTURE_FULL_DIR As String = ""
    Dim IbanStructureFullDirectoryImport As String = ""
    Dim HOLIDAYS_DATA_DIR As String = ""
    Dim HolidaysDataImport As String = ""
    Dim OWN_FX_DEALS_DIR As String = ""
    Dim OwnFxDealsUpdate As String = ""
    Dim BAIS_FILE_DIR As String = ""
    Dim BaisFilesImport As String = ""
    Dim BaisFileName As String = ""
    Dim OPICS_CUST_UPDATE_FILE_DIR As String = ""
    Dim OpicsCustUpdateFilesImport As String = ""
    Dim OpicsCustUpdateFileName As String = ""
    Dim DAILY_BALANCE_SHEET_DIR As String = ""
    Dim DailyBalanceSheetImport As String = ""
    Dim DAILY_BALANCE_SHEET__DETAIL_DIR As String = ""
    Dim DailyBalanceSheetDetailImport As String = ""
    Dim TRIAL_BALANCE_AVERAGE_222_DIR As String = ""
    Dim TrialBalanceAverage222Import As String = ""
    Dim OPICS_MM_DEALS_DIR As String = ""
    Dim OpicsMMDealsImport As String = ""
    Dim OPICS_FX_DEALS_DIR As String = ""
    Dim OpicsFXDealsImport As String = ""
    Dim ACCRUED_INTEREST_ANALYSIS_DIR As String = ""
    Dim AccruedInterestAnalysisImport As String = ""
    Dim USER_PERMISSIONS_DIR As String = ""
    Dim UserPermissionsImport As String = ""
    Dim INVENTAR_EXCEL_IMPORT_DIR As String = ""
    Dim InventarExcelImport As String = ""
    Dim MIFIR_IMPORT_DIR As String = ""
    Dim MifirImport As String = ""

    Dim dir As New List(Of String)
    Dim dir_BaisFiles As New List(Of String)
    Dim dir_OpicsFiles As New List(Of String)
    Dim dir_MM_OpicsFiles As New List(Of String)
    Dim dir_FX_OpicsFiles As New List(Of String)
    Dim dir_UserPermissionsFiles As New List(Of String)

    Dim folderDlg As New FolderBrowserDialog

    Friend WithEvents BgwBicDirectory As BackgroundWorker
    Friend WithEvents BgwBankDirectoryPlus As BackgroundWorker
    Friend WithEvents BgwBicPlusDirectory As BackgroundWorker
    Friend WithEvents BgwSepaDirectory As BackgroundWorker
    Friend WithEvents BgwSepaFullDirectory As BackgroundWorker
    Friend WithEvents BgwBlzDirectory As BackgroundWorker
    Friend WithEvents BgwCustInfoDirectory As BackgroundWorker
    Friend WithEvents BgwCustAccInfoDirectory As BackgroundWorker
    Friend WithEvents BgwOdasRemmitancePayDirectory As BackgroundWorker
    Friend WithEvents BgwGMPSPayDirectory As BackgroundWorker
    Friend WithEvents BgwEcbRatesDirectory As BackgroundWorker
    Friend WithEvents BgwMultibankKonverterKontoinhaberDirectoty As BackgroundWorker
    Friend WithEvents BgwT2Directory As BackgroundWorker
    Friend WithEvents BgwT2_XML_Directory As BackgroundWorker
    Friend WithEvents BgwFxDeals As BackgroundWorker
    Friend WithEvents BgwIbanFullDirectory As BackgroundWorker
    Friend WithEvents BgwIbanStructureFullDirectory As BackgroundWorker
    Friend WithEvents BgwHolidayData As BackgroundWorker
    Friend WithEvents BgwOwnFxDealsUpdate As BackgroundWorker

    Friend WithEvents BgwBaisFiles As BackgroundWorker
    Friend WithEvents BgwOpicsCustUpdateFiles As BackgroundWorker
    Friend WithEvents BgwOpicsMMDeals As BackgroundWorker
    Friend WithEvents BgwOpicsFXDeals As BackgroundWorker

    Friend WithEvents BgwDailyBalanceSheet As BackgroundWorker
    Friend WithEvents BgwDailyBalanceSheetDetail As BackgroundWorker
    Friend WithEvents BgwTriallBalanceAverage222 As BackgroundWorker
    Friend WithEvents BgwAccruedInterestAnalysis As BackgroundWorker
    Friend WithEvents BgwUserPermissions As BackgroundWorker
    Friend WithEvents BgwInventarExcel As BackgroundWorker
    Friend WithEvents BgwMifir As BackgroundWorker

    Private bgws As New List(Of BackgroundWorker)()
    Dim IDNrRowValue As Integer



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
        cmd.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        OpenSqlConnections()
        MaxProcDate = cmd.ExecuteScalar
        'Get SSIS Directory
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE [PARAMETER1]='SSIS_Directory' AND [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SSIS_DIRECTORY'"
        SSISDirectory = cmd.ExecuteScalar()
        'Special Case - Get OPICS new Directory
        CloseSqlConnections()

        'Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxProcDate)
        Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)

    End Sub

    Private Sub bbiReload_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReload.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("MANUAL IMPORT PROCEDURES")
        Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub Add_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Add_bbi.ItemClick
        Me.MANUAL_IMPORTSBindingSource.EndEdit()
        ManualImportProcedures_BasicView.AddNewRow()

    End Sub

    Private Sub Save_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Save_bbi.ItemClick
        Try
            If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Me.Validate()
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Delete_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Delete_bbi.ItemClick
        Try
            Me.MANUAL_IMPORTSBindingSource.EndEdit()
            Dim row As System.Data.DataRow = ManualImportProcedures_BasicView.GetDataRow(ManualImportProcedures_BasicView.FocusedRowHandle)
            Dim ProcName As String = row(1)
            Dim ID_ProcName As String = row(0)
            If XtraMessageBox.Show("Should the manual Import Procedure: " & ProcName & " be deleted?", "DELETE MANUAL IMPORT PROCEDURE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                'Get Max Date
                cmd.CommandText = "DELETE FROM [MANUAL IMPORTS] where [ID]='" & ID_ProcName & "'"
                OpenSqlConnections()
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
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        If Me.ManualImportProcedures_BasicView.IsNewItemRow(Me.ManualImportProcedures_BasicView.FocusedRowHandle) = True Then
            Me.ManualImportProcedures_BasicView.Columns.ColumnByFieldName("ProcName").OptionsColumn.ReadOnly = False
        Else
            Me.ManualImportProcedures_BasicView.Columns.ColumnByFieldName("ProcName").OptionsColumn.ReadOnly = True
        End If
    End Sub


    Private Sub ManualImportProcedures_BasicView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles ManualImportProcedures_BasicView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ManualImportProcedures_BasicView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles ManualImportProcedures_BasicView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


    Private Sub ManualImportProcedures_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ManualImportProcedures_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles ManualImportProcedures_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub MANUALImportEvents_BasicView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MANUALImportEvents_BasicView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub MANUALImportEvents_BasicView_ShownEditor(sender As Object, e As EventArgs) Handles MANUALImportEvents_BasicView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ManualImportProcedures_BasicView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles ManualImportProcedures_BasicView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim PROC_NAME As GridColumn = View.Columns("ProcName")
        Dim FILE_NAME As GridColumn = View.Columns("FileName")
        Dim FILE_DIR_IMPORT As GridColumn = View.Columns("FileDirImport")

        Dim ProcName As String = View.GetRowCellValue(e.RowHandle, colProcName).ToString
        Dim FileName As String = View.GetRowCellValue(e.RowHandle, colFileName).ToString
        Dim FileDirImport As String = View.GetRowCellValue(e.RowHandle, colFileDirImport).ToString

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
        If FileName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(FILE_DIR_IMPORT, "The File Directory Import must not be empty")
            e.ErrorText = "The File Directory Import must not be empty"
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


    Private Sub StartImportButtonEdit_Click(sender As Object, e As EventArgs) Handles StartImportButtonEdit.Click
        'Get the File import Directory if its present
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BIC DIRECTORY" Then
            BicFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            BIC_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "SEPA DIRECTORY" Then
            SepaFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            SEPA_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "SEPA FULL DIRECTORY" Then
            SepaFullFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            SEPA_FULL_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BLZ DIRECTORY" Then
            BlzFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            BLZ_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER INFO" Then
            CustInfoFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            CUST_INFO_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER ACC INFO" Then
            CustAccInfoFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            CUST_ACC_INFO_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ODAS REMMITANCE" Then
            OdasRemmitanceFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            ODAS_REMMITANCE_PAY_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "GMPS PAYMENTS" Then
            GMPSFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            GMPS_PAY_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ECB DAILY RATES" Then
            ECB_RATES_FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            'ECB_RATES_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "MULTIBANK KONVERTER KONTOINHABER" Then
            MULTIBANK_KONVERTER_Kontoinhaber_FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            MULTIBANK_KONVERTER_KONTOINHABER_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TARGET2 DIRECTORY" Then
            T2FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            T2_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TARGET2 XML DIRECTORY" Then
            T2_XML_FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            T2_XML_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ODAS FX DEALS" Then
            FXFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            FX_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BIC PLUS DIRECTORY" Then
            BicPlusFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            BIC_PLUS_DIR_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BANK DIRECTORY PLUS" Then
            BankDirPlusFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            BANK_DIR_PLUS_FILE = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "IBAN PLUS DIRECTORY" Then
            IbanPlusFullDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            IBAN_PLUS_FULL_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "IBAN STRUCTURE DIRECTORY" Then
            IbanStructureFullDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            IBAN_STRUCTURE_FULL_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "HOLIDAYS" Then
            HolidaysDataImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            HOLIDAYS_DATA_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "OWN FX DEALS" Then
            OwnFxDealsUpdate = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            OWN_FX_DEALS_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BAIS FILES" Then
            BaisFilesImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            BAIS_FILE_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER UPDATE OPICS" Then
            OpicsCustUpdateFilesImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            OPICS_CUST_UPDATE_FILE_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "OPICS MM-FX DEALS" Then
            OpicsMMDealsImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            OPICS_MM_DEALS_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If


        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "DAILY BALANCE SHEET" Then
            DailyBalanceSheetImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            DAILY_BALANCE_SHEET_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "DAILY BALANCE SHEET DETAILS" Then
            DailyBalanceSheetDetailImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            DAILY_BALANCE_SHEET__DETAIL_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TRIAL BALANCE AVERAGE 222" Then
            TrialBalanceAverage222Import = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            TRIAL_BALANCE_AVERAGE_222_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ACCRUED INTEREST ANALYSIS" Then
            AccruedInterestAnalysisImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            ACCRUED_INTEREST_ANALYSIS_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "USER PERMISSIONS IMPORT" Then
            UserPermissionsImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            USER_PERMISSIONS_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "NEW INVENTORY" Then
            InventarExcelImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            INVENTAR_EXCEL_IMPORT_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "MIFIR IMPORT" Then
            MifirImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            MIFIR_IMPORT_DIR = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colCurrentFileName)
        End If

        'IMPORT BIC DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BIC DIRECTORY" And BicFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new BIC DIRECTORY be imported?", "IMPORT BIC DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwBicDirectory = New BackgroundWorker
                bgws.Add(BgwBicDirectory)
                BgwBicDirectory.WorkerReportsProgress = True
                BgwBicDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT SEPA DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "SEPA DIRECTORY" And SepaFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new SEPA DIRECTORY be imported?", "IMPORT SEPA DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwSepaDirectory = New BackgroundWorker
                bgws.Add(BgwSepaDirectory)
                BgwSepaDirectory.WorkerReportsProgress = True
                BgwSepaDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT SEPA FULL DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "SEPA FULL DIRECTORY" And SepaFullFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new SEPA FULL DIRECTORY be imported?", "IMPORT SEPA FULL DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwSepaFullDirectory = New BackgroundWorker
                bgws.Add(BgwSepaFullDirectory)
                BgwSepaFullDirectory.WorkerReportsProgress = True
                BgwSepaFullDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT BLZ DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BLZ DIRECTORY" And BlzFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new BLZ DIRECTORY be imported?", "IMPORT BLZ DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwBlzDirectory = New BackgroundWorker
                bgws.Add(BgwBlzDirectory)
                BgwBlzDirectory.WorkerReportsProgress = True
                BgwBlzDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT CUSTOMER INFO
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER INFO" And CustInfoFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new CUSTOMER INFO Data be imported?", "IMPORT CUSTOMER INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwCustInfoDirectory = New BackgroundWorker
                bgws.Add(BgwCustInfoDirectory)
                BgwCustInfoDirectory.WorkerReportsProgress = True
                BgwCustInfoDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT CUSTOMER ACC INFO
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER ACC INFO" And CustAccInfoFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new CUSTOMER ACCOUNT INFO Data be imported?", "IMPORT CUSTOMER ACC INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwCustAccInfoDirectory = New BackgroundWorker
                bgws.Add(BgwCustAccInfoDirectory)
                BgwCustAccInfoDirectory.WorkerReportsProgress = True
                BgwCustAccInfoDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT ODAS REMMITANCE
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ODAS REMMITANCE" And OdasRemmitanceFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the ODAS Remmitance Payment File be imported?", "IMPORT ODAS REMMITANCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwOdasRemmitancePayDirectory = New BackgroundWorker
                bgws.Add(BgwOdasRemmitancePayDirectory)
                BgwOdasRemmitancePayDirectory.WorkerReportsProgress = True
                BgwOdasRemmitancePayDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT GMPS PAYMENTS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "GMPS PAYMENTS" And GMPSFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the GMPS Payment File(s) be imported?", "IMPORT GMPS PAYMENTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwGMPSPayDirectory = New BackgroundWorker
                bgws.Add(BgwGMPSPayDirectory)
                BgwGMPSPayDirectory.WorkerReportsProgress = True
                BgwGMPSPayDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT ECB RATES
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ECB DAILY RATES" And ECB_RATES_FileDirectoryImport <> "" Then
            If MessageBox.Show("Should the today's ECB RATES be imported?", "IMPORT ECB RATES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwEcbRatesDirectory = New BackgroundWorker
                bgws.Add(BgwEcbRatesDirectory)
                BgwEcbRatesDirectory.WorkerReportsProgress = True
                BgwEcbRatesDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT MULTIBANK KONVERTER KONTOINHABER
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "MULTIBANK KONVERTER KONTOINHABER" And MULTIBANK_KONVERTER_Kontoinhaber_FileDirectoryImport <> "" Then
            If MessageBox.Show("Should the MULTIBANK KONVERTER KONTOINHABER File be imported?", "IMPORT MULTIBANK KONVERTER KONTOINHABER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwMultibankKonverterKontoinhaberDirectoty = New BackgroundWorker
                bgws.Add(BgwMultibankKonverterKontoinhaberDirectoty)
                BgwMultibankKonverterKontoinhaberDirectoty.WorkerReportsProgress = True
                BgwMultibankKonverterKontoinhaberDirectoty.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT T2 DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TARGET2 DIRECTORY" And T2FileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new TARGET2 DIRECTORY be imported?", "IMPORT TARGET2 DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwT2Directory = New BackgroundWorker
                bgws.Add(BgwT2Directory)
                BgwT2Directory.WorkerReportsProgress = True
                BgwT2Directory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT T2 XML DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TARGET2 XML DIRECTORY" And T2FileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new TARGET2 XML DIRECTORY be imported?", "IMPORT TARGET2 XML DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwT2_XML_Directory = New BackgroundWorker
                bgws.Add(BgwT2_XML_Directory)
                BgwT2_XML_Directory.WorkerReportsProgress = True
                BgwT2_XML_Directory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'ODAS FX DEALS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ODAS FX DEALS" And FXFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the ODAS FX DEALS be imported?", "IMPORT ODAS FX DEALS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwFxDeals = New BackgroundWorker
                bgws.Add(BgwFxDeals)
                BgwFxDeals.WorkerReportsProgress = True
                BgwFxDeals.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If

        'IMPORT BIC PLUS DIRECTORY-BIC HISTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BIC PLUS DIRECTORY" And BicPlusFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new BIC PLUS DIRECTORY be imported?", "IMPORT BIC PLUS DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwBicPlusDirectory = New BackgroundWorker
                bgws.Add(BgwBicPlusDirectory)
                BgwBicPlusDirectory.WorkerReportsProgress = True
                BgwBicPlusDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If

        'IMPORT BANK PLUS DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BANK DIRECTORY PLUS" And BankDirPlusFileDirectoryImport <> "" Then
            If MessageBox.Show("Should the new BANK DIRECTORY PLUS be imported?", "IMPORT BANK DIRECTORY PLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwBankDirectoryPlus = New BackgroundWorker
                bgws.Add(BgwBankDirectoryPlus)
                BgwBankDirectoryPlus.WorkerReportsProgress = True
                BgwBankDirectoryPlus.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT IBAN PLUS DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "IBAN PLUS DIRECTORY" And IbanPlusFullDirectoryImport <> "" Then
            If MessageBox.Show("Should the new IBAN PLUS DIRECTORY be imported?", "IMPORT IBAN PLUS DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwIbanFullDirectory = New BackgroundWorker
                bgws.Add(BgwIbanFullDirectory)
                BgwIbanFullDirectory.WorkerReportsProgress = True
                BgwIbanFullDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT IBAN STRUCTURE DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "IBAN STRUCTURE DIRECTORY" And IbanStructureFullDirectoryImport <> "" Then
            If MessageBox.Show("Should the new IBAN STRUCTURE DIRECTORY be imported?", "IMPORT IBAN STRUCTURE DIRECTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwIbanStructureFullDirectory = New BackgroundWorker
                bgws.Add(BgwIbanStructureFullDirectory)
                BgwIbanStructureFullDirectory.WorkerReportsProgress = True
                BgwIbanStructureFullDirectory.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT HOLIDAYS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "HOLIDAYS" And HolidaysDataImport <> "" Then
            If MessageBox.Show("Should the new HOLIDAYS File be imported?", "IMPORT HOLIDAYS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwHolidayData = New BackgroundWorker
                bgws.Add(BgwHolidayData)
                BgwHolidayData.WorkerReportsProgress = True
                BgwHolidayData.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'UPDATE OWN FX DEALS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "OWN FX DEALS" And OwnFxDealsUpdate <> "" Then
            If MessageBox.Show("Should our own FX Deals for the Liquidity Management be updated in Table FX DAILY REVALUATION ?", "UPDATE OWN FX DEALS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwOwnFxDealsUpdate = New BackgroundWorker
                bgws.Add(BgwOwnFxDealsUpdate)
                BgwOwnFxDealsUpdate.WorkerReportsProgress = True
                BgwOwnFxDealsUpdate.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT BAIS FILES
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BAIS FILES" And BaisFilesImport <> "" Then
            If MessageBox.Show("Should the BAIS Files be imported?", "IMPORT BAIS Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                BaisFilesImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                dir_BaisFiles.Clear()
                Dim Folder As New IO.DirectoryInfo(BaisFilesImport)
                For Each File As IO.FileInfo In Folder.GetFiles("*_CCB.csv*", IO.SearchOption.TopDirectoryOnly)
                    dir_BaisFiles.Add(File.ToString)

                Next
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwBaisFiles = New BackgroundWorker
                bgws.Add(BgwBaisFiles)
                BgwBaisFiles.WorkerReportsProgress = True
                BgwBaisFiles.RunWorkerAsync()

            Else
                Exit Sub
            End If
        End If
        'CUSTOMER UPDATE OPICS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER UPDATE OPICS" And OpicsCustUpdateFilesImport <> "" Then
            If MessageBox.Show("Should the related OPICS Files be imported in order to update the Tables" & vbNewLine & "CUSTOMER_INFO and the FX DAILY REVALUATION with OWN DEALS?", "IMPORT OPICS CUSTOMER Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                OpicsCustUpdateFilesImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                dir_OpicsFiles.Clear()

                If Directory.Exists(OpicsCustUpdateFilesImport) Then

                    Dim Folder As New IO.DirectoryInfo(OpicsCustUpdateFilesImport)
                    For Each File As IO.FileInfo In Folder.GetFiles("*.DAT*", IO.SearchOption.TopDirectoryOnly)
                        dir_OpicsFiles.Add(File.ToString)

                    Next
                    Me.MANUAL_IMPORTSBindingSource.EndEdit()
                    Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                    'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    Me.GridControl1.Enabled = False
                    Me.RibbonPageGroup1.Enabled = False
                    Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                    Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                    Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                    Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                    Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                    Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                    BgwOpicsCustUpdateFiles = New BackgroundWorker
                    bgws.Add(BgwOpicsCustUpdateFiles)
                    BgwOpicsCustUpdateFiles.WorkerReportsProgress = True
                    BgwOpicsCustUpdateFiles.RunWorkerAsync()

                Else
                    MessageBox.Show("Directory: " & OpicsCustUpdateFilesImport & " does not exist!", "UNABLE TO IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If

        'OPICS MM IMPORT
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "OPICS MM-FX DEALS" And OpicsMMDealsImport <> "" Then
            If MessageBox.Show("Should the OPICS MM and FX Deals be imported?", "IMPORT OPICS MM+FX DEALS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwOpicsMMDeals = New BackgroundWorker
                bgws.Add(BgwOpicsMMDeals)
                BgwOpicsMMDeals.WorkerReportsProgress = True
                BgwOpicsMMDeals.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If


        'IMPORT DAILY BALANCE SHEET
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "DAILY BALANCE SHEET" And DailyBalanceSheetImport <> "" Then
            If MessageBox.Show("Should the DAILY BALANCE SHEET be imported?", "IMPORT DAILY BALANCE SHEET", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwDailyBalanceSheet = New BackgroundWorker
                bgws.Add(BgwDailyBalanceSheet)
                BgwDailyBalanceSheet.WorkerReportsProgress = True
                BgwDailyBalanceSheet.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT DAILY BALANCE SHEET
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "DAILY BALANCE SHEET DETAILS" And DailyBalanceSheetDetailImport <> "" Then
            If MessageBox.Show("Should the DAILY BALANCE SHEET DETAILS be imported?", "IMPORT DAILY BALANCE SHEET DETAILS ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwDailyBalanceSheetDetail = New BackgroundWorker
                bgws.Add(BgwDailyBalanceSheetDetail)
                BgwDailyBalanceSheetDetail.WorkerReportsProgress = True
                BgwDailyBalanceSheetDetail.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT TRIAL BALANCE AVERAGE 222
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TRIAL BALANCE AVERAGE 222" And TrialBalanceAverage222Import <> "" Then
            If MessageBox.Show("Should the TRIAL BALANCE AVERAGE 222 Report be imported?", "TRIAL BALANCE AVERAGE 222 Report ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwTriallBalanceAverage222 = New BackgroundWorker
                bgws.Add(BgwTriallBalanceAverage222)
                BgwTriallBalanceAverage222.WorkerReportsProgress = True
                BgwTriallBalanceAverage222.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT ACCRUD INTEREST ANALYIS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ACCRUED INTEREST ANALYSIS" And AccruedInterestAnalysisImport <> "" Then
            If MessageBox.Show("Should the ACCRUED INTEREST ANALYSIS Report be imported?", "ACCRUED INTEREST ANALYSIS Report ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwAccruedInterestAnalysis = New BackgroundWorker
                bgws.Add(BgwAccruedInterestAnalysis)
                BgwAccruedInterestAnalysis.WorkerReportsProgress = True
                BgwAccruedInterestAnalysis.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT USER PERMISSIONS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "USER PERMISSIONS IMPORT" And UserPermissionsImport <> "" Then
            If MessageBox.Show("Should the USER PERMISSIONS Reports be imported?", "USER PERMISSIONS IMPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwUserPermissions = New BackgroundWorker
                bgws.Add(BgwUserPermissions)
                BgwUserPermissions.WorkerReportsProgress = True
                BgwUserPermissions.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT NEW INVENTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "NEW INVENTORY" And InventarExcelImport <> "" Then
            If MessageBox.Show("Should new Inventory from Excel File be imported?", "IMPORT NEW INVENTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwInventarExcel = New BackgroundWorker
                bgws.Add(BgwInventarExcel)
                BgwInventarExcel.WorkerReportsProgress = True
                BgwInventarExcel.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If
        'IMPORT MIFIR
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "MIFIR IMPORT" And MifirImport <> "" Then
            If MessageBox.Show("Should the new MIFIR File be imported?", "IMPORT MIFIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                Me.GridControl1.Enabled = False
                Me.RibbonPageGroup1.Enabled = False
                Me.LayoutControlGroup3.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Always
                Me.LayoutControlItem_ProgressPanel.Text = "Executing import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ProgressPanel1.Caption = "Start import procedure: " & Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName).ToString
                Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = True
                Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = False
                BgwMifir = New BackgroundWorker
                bgws.Add(BgwMifir)
                BgwMifir.WorkerReportsProgress = True
                BgwMifir.RunWorkerAsync()
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub SelectFileButtonEdit_Click(sender As Object, e As EventArgs) Handles SelectFileButtonEdit.Click
        'IMPORT BIC DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BIC DIRECTORY" Then
            With XtraOpenFileDialog1
                BicFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = BicFileDirectoryImport
                .FileName = ""
                .Title = "Import new BIC Directory"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    BIC_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT SEPA DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "SEPA DIRECTORY" Then
            With XtraOpenFileDialog1
                SepaFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Csv Files (*.csv;*.CSV)|*.csv;*.CSV"
                .DefaultExt = "csv"
                .FilterIndex = 1
                .InitialDirectory = SepaFileDirectoryImport
                .FileName = ""
                .Title = "Import new SEPA Directory"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    SEPA_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT SEPA FULL DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "SEPA FULL DIRECTORY" Then
            With XtraOpenFileDialog1
                SepaFullFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "XML Files (*.xml;*.XML)|*.xml;*.XML"
                .DefaultExt = "xml"
                .FilterIndex = 1
                .InitialDirectory = SepaFullFileDirectoryImport
                .FileName = ""
                .Title = "Import new SEPA Full Directory"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    SEPA_FULL_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT BLZ DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BLZ DIRECTORY" Then
            With XtraOpenFileDialog1
                BlzFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = CustInfoFileDirectoryImport
                .FileName = ""
                .Title = "Import new BLZ DIRECTORY"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    BLZ_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT CUSTOMER INFO
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER INFO" Then
            With XtraOpenFileDialog1
                CustInfoFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = CustInfoFileDirectoryImport
                .FileName = ""
                .Title = "Import new CUSTOMER INFO"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    CUST_INFO_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT CUSTOMER ACC INFO
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER ACC INFO" Then
            With XtraOpenFileDialog1
                CustAccInfoFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = CustAccInfoFileDirectoryImport
                .FileName = ""
                .Title = "Import new CUSTOMER ACC INFO"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    CUST_ACC_INFO_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT ODAS REMMITANCE
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ODAS REMMITANCE" Then
            With XtraOpenFileDialog1
                OdasRemmitanceFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = CustInfoFileDirectoryImport
                .FileName = ""
                .Title = "Import ODAS Remmitance Payment File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    ODAS_REMMITANCE_PAY_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT GMPS PAYMENTS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "GMPS PAYMENTS" Then
            With XtraOpenFileDialog1
                GMPSFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = GMPSFileDirectoryImport
                .FileName = ""
                .Title = "Import GMPS Payments"
                .RestoreDirectory = True
                .Multiselect = True

                dir.Clear()

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    For Each f As String In XtraOpenFileDialog1.FileNames
                        dir.Add(f)
                        Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                        GMPS_PAY_FILE = Me.XtraOpenFileDialog1.FileName
                    Next
                End If

            End With
        End If

        'ECB RATES IMPORTED FROM ECB WEBSITE
        'Nothing

        'MULTIBANK KONVERTER KONTOINHABER
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "MULTIBANK KONVERTER KONTOINHABER" Then
            With XtraOpenFileDialog1
                MULTIBANK_KONVERTER_Kontoinhaber_FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = MULTIBANK_KONVERTER_Kontoinhaber_FileDirectoryImport
                .FileName = ""
                .Title = "Import new MULTIBANK KONVERTER KONTOINHABER"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    MULTIBANK_KONVERTER_KONTOINHABER_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT TARGET2 DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TARGET2 DIRECTORY" Then
            With XtraOpenFileDialog1
                T2FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "ORIG Files (*.orig;*.ORIG)|*.orig;*.ORIG"
                .DefaultExt = "ORIG"
                .FilterIndex = 1
                .InitialDirectory = T2FileDirectoryImport
                .FileName = ""
                .Title = "Import new Target2 Directory"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    T2_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT TARGET2 XML DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TARGET2 XML DIRECTORY" Then
            With XtraOpenFileDialog1
                T2FileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "XML Files (*.xml;*.XML)|*.xml;*.XML"
                .DefaultExt = "xml"
                .FilterIndex = 1
                .InitialDirectory = T2_XML_FileDirectoryImport
                .FileName = ""
                .Title = "Import new Target2 XML Directory"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    T2_XML_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT ODAS FX DEALS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ODAS FX DEALS" Then
            With XtraOpenFileDialog1
                FXFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xlsx"
                .FilterIndex = 1
                .InitialDirectory = FXFileDirectoryImport
                .FileName = ""
                .Title = "Import ODAS FX DEALS File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    FX_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT BIC PLUS DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BIC PLUS DIRECTORY" Then
            With XtraOpenFileDialog1
                BicPlusFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = BicPlusFileDirectoryImport
                .FileName = ""
                .Title = "Import BIC PLUS File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    BIC_PLUS_DIR_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT BANK DIRECTORY PLUS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BANK DIRECTORY PLUS" Then
            With XtraOpenFileDialog1
                BankDirPlusFileDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = BankDirPlusFileDirectoryImport
                .FileName = ""
                .Title = "Import BANK DIRECTORY PLUS File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    BANK_DIR_PLUS_FILE = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT IBAN FULL DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "IBAN PLUS DIRECTORY" Then
            With XtraOpenFileDialog1
                IbanPlusFullDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = IbanPlusFullDirectoryImport
                .FileName = ""
                .Title = "Import IBAN PLUS DIRECTORY File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    IBAN_PLUS_FULL_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT IBAN STRUCTURE DIRECTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "IBAN STRUCTURE DIRECTORY" Then
            With XtraOpenFileDialog1
                IbanStructureFullDirectoryImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = IbanStructureFullDirectoryImport
                .FileName = ""
                .Title = "Import IBAN STRUCTURE DIRECTORY File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    IBAN_STRUCTURE_FULL_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT HOLIDAYS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "HOLIDAYS" Then
            With XtraOpenFileDialog1
                HolidaysDataImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Text Files (*.txt)|*.txt"
                .DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = HolidaysDataImport
                .FileName = ""
                .Title = "Import new HOLIDAY DATA"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    HOLIDAYS_DATA_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'UPDATE OWN FX DEALS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "OWN FX DEALS" Then
            With XtraOpenFileDialog1
                OwnFxDealsUpdate = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = OwnFxDealsUpdate
                .FileName = ""
                .Title = "Update own FX Deals in FX DAILY REVALUATION Table"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    OWN_FX_DEALS_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT BAIS FILES
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "BAIS FILES" Then
            'No Action - All BAIS Files are selected from the Import Button

        End If

        'CUSTOMER UPDATE OPICS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "CUSTOMER UPDATE OPICS" Then
            'No Action - All OPICS Files are selected from the Import Button
            Dim folderDlg As New FolderBrowserDialog
            folderDlg.ShowNewFolderButton = False
            folderDlg.SelectedPath = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
            If (folderDlg.ShowDialog() = DialogResult.OK) Then
                Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, folderDlg.SelectedPath & "\")
                Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colFileDirImport, folderDlg.SelectedPath & "\")
                Me.Validate()
                Me.MANUAL_IMPORTSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.EDPDataSet)
                Me.MANUAL_IMPORTSTableAdapter.Fill(Me.EDPDataSet.MANUAL_IMPORTS)
            End If
        End If

        'OPICS MM DEALS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "OPICS MM-FX DEALS" Then
            With XtraOpenFileDialog1
                OpicsMMDealsImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = OpicsMMDealsImport
                .FileName = ""
                .Title = "Import OPICS MM-FX DEALS"
                .RestoreDirectory = True
                .Multiselect = True

                dir_MM_OpicsFiles.Clear()

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    For Each f As String In XtraOpenFileDialog1.FileNames
                        dir_MM_OpicsFiles.Add(f)
                        Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                        MM_Tradedate = System.IO.Path.GetFileName(Me.XtraOpenFileDialog1.FileName)
                        OPICS_MM_DEALS_DIR = Me.XtraOpenFileDialog1.FileName
                    Next
                End If
            End With
        End If



        'IMPORT DAILY BALANCE SHEET
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "DAILY BALANCE SHEET" Then
            With XtraOpenFileDialog1
                DailyBalanceSheetImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = DailyBalanceSheetImport
                .FileName = ""
                .Title = "Import DAILY BALANCE SHEET"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    DAILY_BALANCE_SHEET_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT DAILY BALANCE SHEET
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "DAILY BALANCE SHEET DETAILS" Then
            With XtraOpenFileDialog1
                DailyBalanceSheetDetailImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = DailyBalanceSheetDetailImport
                .FileName = ""
                .Title = "Import DAILY BALANCE SHEET DETAILS"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    DAILY_BALANCE_SHEET__DETAIL_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT TRIAL BALANCE AVERAGE 222
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "TRIAL BALANCE AVERAGE 222" Then
            With XtraOpenFileDialog1
                TrialBalanceAverage222Import = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = TrialBalanceAverage222Import
                .FileName = ""
                .Title = "Import TRIAL BALANCE AVERAGE 222"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    TRIAL_BALANCE_AVERAGE_222_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT ACCRUED INTEREST ANALYSIS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "ACCRUED INTEREST ANALYSIS" Then
            With XtraOpenFileDialog1
                AccruedInterestAnalysisImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = AccruedInterestAnalysisImport
                .FileName = ""
                .Title = "Import ACCRUED INTEREST ANALYSIS"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    ACCRUED_INTEREST_ANALYSIS_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If

        'IMPORT USER PERMISIONS
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "USER PERMISSIONS IMPORT" Then
            With XtraOpenFileDialog1
                UserPermissionsImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx;*.csv"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = UserPermissionsImport
                .FileName = ""
                .Title = "Import User Permissions"
                .RestoreDirectory = True
                .Multiselect = True

                dir_UserPermissionsFiles.Clear()

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    For Each f As String In XtraOpenFileDialog1.FileNames
                        dir_UserPermissionsFiles.Add(f)
                        Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                        USER_PERMISSIONS_DIR = Me.XtraOpenFileDialog1.FileName
                    Next
                End If
            End With
        End If

        'IMPORT NEW INVENTORY
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "NEW INVENTORY" Then
            With XtraOpenFileDialog1
                InventarExcelImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = InventarExcelImport
                .FileName = ""
                .Title = "Import new Inventory from Excel File"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    INVENTAR_EXCEL_IMPORT_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
        'IMPORT MIFIR
        If Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colProcName) = "MIFIR IMPORT" Then
            With XtraOpenFileDialog1
                MifirImport = Me.ManualImportProcedures_BasicView.GetFocusedRowCellValue(colFileDirImport)
                .Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx"
                .DefaultExt = "xls"
                .FilterIndex = 1
                .InitialDirectory = MifirImport
                .FileName = ""
                .Title = "Import new MIFIR Report"
                .RestoreDirectory = True
                .Multiselect = False

                If Me.XtraOpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Me.ManualImportProcedures_BasicView.SetFocusedRowCellValue(colCurrentFileName, Me.XtraOpenFileDialog1.FileName)
                    MIFIR_IMPORT_DIR = Me.XtraOpenFileDialog1.FileName
                End If
            End With
        End If
    End Sub

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

#Region "IMPORT CUSTOMER INFO"
    Private Sub BgwCustInfoDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwCustInfoDirectory.DoWork
        Try
            If File.Exists(CUST_INFO_DIR_FILE) = True Then
                OpenSqlConnections()

                cmd.CommandTimeout = 50000

                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(CUST_INFO_DIR_FILE, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                worksheet.Rows.Remove(0, 4)
                worksheet.UnMergeCells(worksheet.Range("A:A"))
                worksheet.Cells("A1").Value = "ClientNr"
                worksheet.Cells("E1").Value = "FI_Client"
                worksheet.Cells("H1").Value = "ClientName"
                worksheet.Cells("K1").Value = "Status"
                worksheet.Cells("N1").Value = "OpenDate"
                worksheet.Cells("Q1").Value = "LegalStatus"
                worksheet.Cells("T1").Value = "CountryRegistration"
                worksheet.Cells("U1").Value = "CountryRisk"
                worksheet.Cells("V1").Value = "CountryResidence"
                worksheet.Cells("W1").Value = "IndustrialClassLocal"
                worksheet.Cells("X1").Value = "IndustrialClassChina"
                worksheet.Cells("Y1").Value = "ClosedDate"
                worksheet.Cells("AB1").Value = "IS_Code"
                worksheet.Cells("AE1").Value = "EstablishedDate"
                worksheet.Cells("AH1").Value = "ID_Type"
                worksheet.Cells("AK1").Value = "ID_No"
                worksheet.Cells("AN1").Value = "TaxRegistrationCertificate"
                worksheet.Cells("AQ1").Value = "AccountOfficerNr"
                worksheet.Cells("AT1").Value = "AccountOfficer"
                worksheet.Cells("AW1").Value = "AccountingCentre"
                worksheet.Cells("AZ1").Value = "RegistrationAddressCountry"
                worksheet.Cells("BC1").Value = "RegistrationAddressStateCode"
                worksheet.Cells("BF1").Value = "RegistrationAddressPostalCode"
                worksheet.Cells("BI1").Value = "RegistrationAddress1"
                worksheet.Cells("BL1").Value = "RegistrationAddress2"
                worksheet.Cells("BO1").Value = "RegistrationAddress3"
                worksheet.Cells("BR1").Value = "RegistrationAddress4"
                worksheet.Cells("BU1").Value = "RegistrationAddress5"
                worksheet.Cells("BX1").Value = "RegistrationAddress6"
                worksheet.Cells("CA1").Value = "CorrespondentAddressCountry"
                worksheet.Cells("CD1").Value = "CorrespondentAddressStateCode"
                worksheet.Cells("CG1").Value = "CorrespondentAddressPostalCode"
                worksheet.Cells("CJ1").Value = "CorrespondentAddress1"
                worksheet.Cells("CM1").Value = "CorrespondentAddress2"
                worksheet.Cells("CP1").Value = "CorrespondentAddress3"
                worksheet.Cells("CS1").Value = "CorrespondentAddress4"
                worksheet.Cells("CV1").Value = "CorrespondentAddress5"
                worksheet.Cells("CY1").Value = "CorrespondentAddress6"
                worksheet.Name = "Sheet1"
                workbook.SaveDocument(CUST_INFO_DIR_FILE, DocumentFormat.Xlsx)


                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_CUSTOMER_INFO') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_CUSTOMER_INFO')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<CUST_INFO_DIR_FILE>", CUST_INFO_DIR_FILE)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1"))
                            Me.BgwCustInfoDirectory.ReportProgress(i, dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwCustInfoDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_CUSTOMER_INFO! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_CUSTOMER_INFO! Parameter Status is Invalid!!", "CUSTOMER INFO IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If

                CloseSqlConnections()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & CUST_INFO_DIR_FILE)
                Me.BgwCustInfoDirectory.ReportProgress(80, "Delete File: " & CUST_INFO_DIR_FILE)
                File.Delete(CUST_INFO_DIR_FILE)
                'SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER INFO IMPORT finished")
                Me.BgwCustInfoDirectory.ReportProgress(90, "CUSTOMER INFO IMPORT finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwCustInfoDirectory.ReportProgress(30, "Unable to Import the new CUSTOMER INFO! File does not exist!")
                MessageBox.Show("Unable to Import the new CUSTOMER INFO! File does not exist!", "CUSTOMER INFO IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwCustInfoDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwCustInfoDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwCustInfoDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','CUSTOMER INFO IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','CUSTOMER INFO IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwCustInfoDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwCustInfoDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwCustInfoDirectory, e)
        'SplashScreenManager.CloseForm(False)

    End Sub

#End Region

#Region "IMPORT ODAS FX DEALS"
    Private Sub BgwFxDeals_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwFxDeals.DoWork

        Try
            If File.Exists(FX_DIR_FILE) = True Then
                OpenSqlConnections()
                Dim NewFX_File As String = "\\ccb-pstool-new\Apps\PS TOOL DX File Imports\FX_ALL.xlsx"
                My.Computer.FileSystem.CopyFile(FX_DIR_FILE, NewFX_File, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                Dim attributes As FileAttributes
                attributes = File.GetAttributes(NewFX_File)
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly)
                File.SetAttributes(NewFX_File, attributes)

                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(NewFX_File, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)

                worksheet.Cells("A1").Value = "BatchDate"
                worksheet.Cells("B1").Value = "SubBranch"
                worksheet.Cells("C1").Value = "ClientNo"
                worksheet.Cells("D1").Value = "ClientName"
                worksheet.Cells("E1").Value = "ContractNo"
                worksheet.Cells("F1").Value = "ProductCode"
                worksheet.Cells("G1").Value = "SPOT_FWD_SW_FLG"
                worksheet.Cells("H1").Value = "AccountingCenter"
                worksheet.Cells("I1").Value = "B/S"
                worksheet.Cells("J1").Value = "FarNear"
                worksheet.Cells("K1").Value = "Status"
                worksheet.Cells("L1").Value = "InputDate"
                worksheet.Cells("M1").Value = "StartDate"
                worksheet.Cells("N1").Value = "EndDate"
                worksheet.Cells("O1").Value = "DealCurrency"
                worksheet.Cells("P1").Value = "DealAmount"
                worksheet.Cells("Q1").Value = "CCY_B"
                worksheet.Cells("R1").Value = "AMT_B"
                worksheet.Cells("S1").Value = "CCY_S"
                worksheet.Cells("T1").Value = "AMT_S"
                worksheet.Cells("U1").Value = "ExchangeRate"
                worksheet.Cells("V1").Value = "FixingDate(NDF)"
                worksheet.Cells("W1").Value = "FixingRate(NDF)"
                worksheet.Cells("X1").Value = "SWAP_Contract_Nr"
                worksheet.Cells("Y1").Value = "Remarks"
                worksheet.Cells("Z1").Value = "Broker"
                worksheet.Cells("AA1").Value = "Portfolio"
                worksheet.Cells("AB1").Value = "NetReceive(NDF)"
                worksheet.Cells("AC1").Value = "NetPay(NDF)"
                worksheet.Cells("AD1").Value = "OffshoreOnshoreIndicator"
                worksheet.Name = "Sheet1"
                workbook.SaveDocument(NewFX_File, DocumentFormat.Xlsx)


                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_ODAS_FX_DEALS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_ODAS_FX_DEALS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<NewFX_File>", NewFX_File)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i).Item("SQL_Name_1"))
                            Me.BgwFxDeals.ReportProgress(i, dt.Rows.Item(i).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwFxDeals.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_ODAS_FX_DEALS! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_ODAS_FX_DEALS! Parameter Status is Invalid!!", "ODAS FX DEALS IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If

                CloseSqlConnections()
                'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & NewFX_File)
                Me.BgwFxDeals.ReportProgress(80, "Delete File: " & NewFX_File)
                File.Delete(NewFX_File)
                'SplashScreenManager.Default.SetWaitFormCaption("ODAS FX DEALS import finished")
                Me.BgwFxDeals.ReportProgress(90, "ODAS FX DEALS import finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwFxDeals.ReportProgress(30, "Unable to Import ODAS FX DEALS! File does not exist!")
                MessageBox.Show("Unable to Import ODAS FX DEALS! File does not exist!", "ODAS FX DEALS IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwFxDeals.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try

    End Sub

    Private Sub BgwFxDeals_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwFxDeals.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','ODAS FX DEALS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ODAS FX DEALS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','ODAS FX DEALS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ODAS FX DEALS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwFxDeals_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwFxDeals.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwFxDeals, e)
        'SplashScreenManager.CloseForm(False)


    End Sub


#End Region

#Region "OPICS MM + FX DEALS"
    Private Sub BgwOpicsMMDeals_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOpicsMMDeals.DoWork
        Try
            If dir_MM_OpicsFiles.Count > 0 Then
                For i = 0 To dir_MM_OpicsFiles.Count - 1
                    OPICS_MM_DEALS_DIR = dir_MM_OpicsFiles.Item(i).ToString

                    OpenSqlConnections()
                    Dim ExcelFileName As String = OPICS_MM_DEALS_DIR
                    Dim MM_ExcelFileName As String = System.IO.Path.GetFileName(ExcelFileName)
                    If File.Exists(ExcelFileName) = True And MM_ExcelFileName.StartsWith("MM_") = True Then

                        'Get Trade Date from FileName
                        Dim rdsql As String = Mid(MM_ExcelFileName, 4, 8) 'Defined as TRADE DATE

                        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_OPICS_MM_DEALS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                        Dim ParameterStatus As String = cmd.ExecuteScalar
                        If ParameterStatus = "Y" Then
                            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_OPICS_MM_DEALS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i1 = 0 To dt.Rows.Count - 1
                                SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<ExcelFileName>", ExcelFileName)
                                SqlCommandText2 = SqlCommandText1.ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText2
                                If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                    'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                    Me.BgwOpicsMMDeals.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        Else
                            'SplashScreenManager.CloseForm(False)
                            Me.BgwOpicsMMDeals.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_OPICS_MM_DEALS! Parameter Status is Invalid!!")
                            MessageBox.Show("Unable to execute Import Procedure:IMPORT_OPICS_MM_DEALS! Parameter Status is Invalid!!", "OPICS MM DEALS IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return

                        End If



                        Me.BgwOpicsMMDeals.ReportProgress(100, "Import procedure: OPICS MM finished sucesfully")
                        'SplashScreenManager.Default.SetWaitFormCaption("Import procedure: Import procedure: OPICS MM finished sucesfully")

                        File.Delete(OPICS_MM_DEALS_DIR)

                    ElseIf File.Exists(ExcelFileName) = True And MM_ExcelFileName.StartsWith("FX_") = True Then

                        'Get Trade Date from FileName
                        Dim rdsql As String = Mid(MM_ExcelFileName, 4, 8) 'Defined as TRADE DATE

                        cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_OPICS_FX_DEALS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                        Dim ParameterStatus As String = cmd.ExecuteScalar
                        If ParameterStatus = "Y" Then
                            QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_OPICS_FX_DEALS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                            da = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt = New System.Data.DataTable()
                            da.Fill(dt)
                            For i1 = 0 To dt.Rows.Count - 1
                                SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<ExcelFileName>", ExcelFileName)
                                SqlCommandText2 = SqlCommandText1.ToString.Replace("<RiskDate>", rdsql)
                                cmd.CommandText = SqlCommandText2
                                If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                    'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                    Me.BgwOpicsMMDeals.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                    cmd.ExecuteNonQuery()
                                End If
                            Next
                        Else
                            'SplashScreenManager.CloseForm(False)
                            Me.BgwOpicsMMDeals.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_OPICS_FX_DEALS! Parameter Status is Invalid!!")
                            MessageBox.Show("Unable to execute Import Procedure:IMPORT_OPICS_FX_DEALS! Parameter Status is Invalid!!", "OPICS FX DEALS IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return

                        End If



                        Me.BgwOpicsMMDeals.ReportProgress(100, "Import procedure: OPICS FX finished sucesfully")
                        'SplashScreenManager.Default.SetWaitFormCaption("Import procedure: Import procedure: OPICS FX finished sucesfully")

                        File.Delete(OPICS_MM_DEALS_DIR)


                    Else
                        Me.BgwOpicsMMDeals.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                        MessageBox.Show("File does not exist in Import Directory - File Name:" & ExcelFileName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                    CloseSqlConnections()
                Next
            End If

        Catch ex As Exception
            Me.BgwOpicsMMDeals.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub

        End Try
    End Sub

    Private Sub BgwOpicsMMDeals_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOpicsMMDeals.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','OPICS MM-FX IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "OPICS MM-FX IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','OPICS MM-FX IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "OPICS MM-FX IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwOpicsMMDeals_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOpicsMMDeals.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwOpicsMMDeals, e)
        'SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "MIFIR IMPORT"
    Private Sub BgwMifir_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwMifir.DoWork
        Try
            If File.Exists(MIFIR_IMPORT_DIR) = True Then
                OpenSqlConnections()
                'SplashScreenManager.Default.SetWaitFormCaption("Reformating MIFIR Excel File")
                Me.BgwMifir.ReportProgress(60, "Reformating MIFIR Excel File")
                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                workbook.LoadDocument(MIFIR_IMPORT_DIR, DocumentFormat.Xlsx)
                Dim worksheet As Worksheet = workbook.Worksheets(0)
                worksheet.Rows.Remove(0, 4)
                worksheet.Columns.Remove(0)
                worksheet.Cells("A1").Value = "ReportStatus"
                worksheet.Cells("B1").Value = "TradeDate"
                worksheet.Cells("C1").Value = "ValueDate"
                worksheet.Cells("D1").Value = "FixingDate"
                worksheet.Cells("E1").Value = "ClientOrderID"
                worksheet.Cells("F1").Value = "FxAllID"
                worksheet.Cells("G1").Value = "TradingVenueTransactionIdentificationCode"
                worksheet.Cells("H1").Value = "CustomerUSI"
                worksheet.Cells("I1").Value = "ProviderUSI"
                worksheet.Cells("J1").Value = "Product"
                worksheet.Cells("K1").Value = "OrderType"
                worksheet.Cells("L1").Value = "Status"
                worksheet.Cells("M1").Value = "FixingTime"
                worksheet.Cells("N1").Value = "FixingSeries"
                worksheet.Cells("O1").Value = "CustBS"
                worksheet.Cells("P1").Value = "CustTradeSide"
                worksheet.Cells("Q1").Value = "CustomerName"
                worksheet.Cells("R1").Value = "CustTrader"
                worksheet.Cells("S1").Value = "Account"
                worksheet.Cells("T1").Value = "AccountLongName"
                worksheet.Cells("U1").Value = "CCYPair"
                worksheet.Cells("V1").Value = "NotionalCCY"
                worksheet.Cells("W1").Value = "Notional"
                worksheet.Cells("X1").Value = "ContraCCY"
                worksheet.Cells("Y1").Value = "ContraAmount"
                worksheet.Cells("Z1").Value = "PriceTreasury"
                worksheet.Cells("AA1").Value = "FwdPts"
                worksheet.Cells("AB1").Value = "AllIn"
                worksheet.Cells("AC1").Value = "ComplexTradeID"
                worksheet.Cells("AD1").Value = "CARStatus"
                worksheet.Cells("AE1").Value = "CARSubmitID"
                worksheet.Cells("AF1").Value = "CARTime"
                worksheet.Cells("AG1").Value = "ExecutionWithinTheFirm"
                worksheet.Cells("AH1").Value = "ISIN"
                worksheet.Cells("AI1").Value = "CFICodeForTheInstrument"
                worksheet.Cells("AJ1").Value = "WaiverIndicator"
                worksheet.Cells("AK1").Value = "MTFExecutionTime"
                worksheet.Cells("AL1").Value = "LiqVenue"
                worksheet.Cells("AM1").Value = "Capacity"
                worksheet.Cells("AN1").Value = "NPFT"
                worksheet.Cells("AO1").Value = "SEC_FIN"
                worksheet.Cells("AP1").Value = "CustomerLEI"
                worksheet.Cells("AQ1").Value = "AccountLEI"
                worksheet.Cells("AR1").Value = "ProviderLEI"
                worksheet.Cells("AS1").Value = "DateTimeOfferToDeal"
                worksheet.Cells("AT1").Value = "TransmissionOfOrderIndicator"
                worksheet.Cells("AU1").Value = "LiquidityProvisionActivity"
                worksheet.Cells("AV1").Value = "DateTimeOrderSubmission"
                worksheet.Cells("AW1").Value = "VenueTreasury"
                worksheet.Cells("AX1").Value = "DateReceiptOrder"
                worksheet.Name = "Sheet1"
                workbook.SaveDocument(MIFIR_IMPORT_DIR, DocumentFormat.Xlsx)


                'Check if Excel File contains Data with no ISIN for the last business day
                cmd.CommandText = "DECLARE @RISKDATE Datetime SET @RISKDATE=(select CAST(CAST(CAST(FileName AS INT) AS VARCHAR(8)) AS DATETIME) from FILES_IMPORT where SYSTEM_NAME in ('OCBS'))  SELECT COUNT(*) FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & MIFIR_IMPORT_DIR & ";', 'SELECT * FROM [Sheet1$]') where  [ISIN] is  NULL and  [Product] in ('SWAP') and Convert(datetime,[TradeDate],104)=@RISKDATE"
                If cmd.ExecuteScalar = 0 Then
                    cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_MIFIR') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                    Dim ParameterStatus As String = cmd.ExecuteScalar
                    If ParameterStatus = "Y" Then
                        QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_MIFIR')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i1 = 0 To dt.Rows.Count - 1
                            SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<MIFIR_IMPORT_DIR>", MIFIR_IMPORT_DIR)
                            cmd.CommandText = SqlCommandText1
                            If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                Me.BgwMifir.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        'SplashScreenManager.CloseForm(False)
                        Me.BgwMifir.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_MIFIR! Parameter Status is Invalid!!")
                        MessageBox.Show("Unable to execute Import Procedure:IMPORT_MIFIR! Parameter Status is Invalid!!", "MIFIR IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub

                    End If
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwMifir.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_MIFIR! File contains SWAP Deals with no ISIN!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_MIFIR! File contains SWAP Deals with no ISIN!!", "MIFIR IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                CloseSqlConnections()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & MIFIR_IMPORT_DIR)
                Me.BgwMifir.ReportProgress(80, "Delete File: " & MIFIR_IMPORT_DIR)
                File.Delete(MIFIR_IMPORT_DIR)
                'SplashScreenManager.Default.SetWaitFormCaption("MIFIR IMPORT finished")
                Me.BgwMifir.ReportProgress(90, "MIFIR IMPORT finished")

            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwMifir.ReportProgress(30, "Unable to Import the new MIFIR File! File does not exist!")
                MessageBox.Show("Unable to Import the new MIFIR File! File does not exist!", "MIFIR IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwMifir.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            CloseSqlConnections()
            Exit Sub
        End Try
    End Sub

    Private Sub BgwMifir_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwMifir.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','MIFIR IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "MIFIR IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','MIFIR IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "MIFIR IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwMifir_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwMifir.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwMifir, e)
        'SplashScreenManager.CloseForm(False)

    End Sub
#End Region

#Region "IMPORT BIC DIRECTORY"
    Private Sub BgwBicDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBicDirectory.DoWork
        Try

            OpenSqlConnections()
            'cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('BIC_DIRECTORY_NEW_TXT_FILE') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
            'Dim BIC_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar


            'If File.Exists(BIC_DIRECTORY_NEW_TXT_FILE) = True Then
            '    File.Delete(BIC_DIRECTORY_NEW_TXT_FILE)
            'End If
            'Dim sr As New System.IO.StreamReader(BIC_DIR_FILE)
            'Dim sr1 As System.IO.StreamWriter
            'sr1 = My.Computer.FileSystem.OpenTextFileWriter(BIC_DIRECTORY_NEW_TXT_FILE, True)

            'Dim TAG As String = ""
            'Dim MODIFICATION_FLAG As String = ""
            'Dim BIC_CODE As String = ""
            'Dim BRANCH_CODE As String = ""
            'Dim INSTITUTION_NAME As String = ""
            'Dim BRANCH_INFORMATION As String = ""
            'Dim CITY_HEADING As String = ""
            'Dim SUBTYPE_INDICATION As String = ""
            'Dim VALUE_ADDED_SERVICES As String = ""
            'Dim EXTRA_INFO As String = ""
            'Dim PHYSICAL_ADDRESS_1 As String = ""
            'Dim PHYSICAL_ADDRESS_2 As String = ""
            'Dim PHYSICAL_ADDRESS_3 As String = ""
            'Dim PHYSICAL_ADDRESS_4 As String = ""
            'Dim LOCATION As String = ""
            'Dim COUNTRY_NAME As String = ""
            'Dim POB_NUMBER As String = ""
            'Dim POB_LOCATION As String = ""
            'Dim POB_COUNTRY_NAME As String = ""
            'Dim USER As String = ""
            'Dim VALID As String = ""

            'Dim Zeileninhalt As String = ""
            ''Dim Arr() As String




            'SplashScreenManager.Default.SetWaitFormCaption("Creating file: " & BIC_DIRECTORY_NEW_TXT_FILE)
            'Me.BgwBicDirectory.ReportProgress(30, "Creating file: " & BIC_DIRECTORY_NEW_TXT_FILE)
            'Do While Not sr.EndOfStream
            '    Zeileninhalt = sr.ReadLine().Replace(",", " ")
            '    'Arr = Zeileninhalt.Split(" ")

            '    'Datum = DateSerial(Microsoft.VisualBasic.Right(Arr(0), 4), Mid(Arr(0), 3, 2), Microsoft.VisualBasic.Left(Arr(0), 2))
            '    TAG = Microsoft.VisualBasic.Left(Zeileninhalt, 2)
            '    MODIFICATION_FLAG = Mid(Zeileninhalt, 3, 1)
            '    BIC_CODE = Mid(Zeileninhalt, 4, 8)
            '    BRANCH_CODE = Mid(Zeileninhalt, 12, 3)
            '    INSTITUTION_NAME = Mid(Zeileninhalt, 15, 105).Replace("'", "")
            '    BRANCH_INFORMATION = Mid(Zeileninhalt, 119, 70).Replace("'", "")
            '    CITY_HEADING = Mid(Zeileninhalt, 190, 35).Replace("'", "")
            '    SUBTYPE_INDICATION = Mid(Zeileninhalt, 225, 4).Replace("'", "")
            '    VALUE_ADDED_SERVICES = Mid(Zeileninhalt, 229, 60).Replace("'", "")
            '    EXTRA_INFO = Mid(Zeileninhalt, 289, 34).Replace("'", "")
            '    PHYSICAL_ADDRESS_1 = Mid(Zeileninhalt, 324, 35).Replace("'", "")
            '    PHYSICAL_ADDRESS_2 = Mid(Zeileninhalt, 359, 35).Replace("'", "")
            '    PHYSICAL_ADDRESS_3 = Mid(Zeileninhalt, 394, 35).Replace("'", "")
            '    PHYSICAL_ADDRESS_4 = Mid(Zeileninhalt, 429, 35).Replace("'", "")
            '    LOCATION = Mid(Zeileninhalt, 464, 105).Replace("'", "")
            '    COUNTRY_NAME = Mid(Zeileninhalt, 569, 70).Replace("'", "")
            '    POB_NUMBER = Mid(Zeileninhalt, 639, 35).Replace("'", "")
            '    POB_LOCATION = Mid(Zeileninhalt, 674, 70).Replace("'", "")
            '    POB_COUNTRY_NAME = Mid(Zeileninhalt, 779, 70).Replace("'", "")

            '    sr1.WriteLine(TAG & "," & MODIFICATION_FLAG & "," & BIC_CODE & "," & BRANCH_CODE & "," & INSTITUTION_NAME & "," & BRANCH_INFORMATION & "," & CITY_HEADING & "," & SUBTYPE_INDICATION & "," & VALUE_ADDED_SERVICES & "," & EXTRA_INFO & "," & PHYSICAL_ADDRESS_1 & "," & PHYSICAL_ADDRESS_2 & "," & PHYSICAL_ADDRESS_3 & "," & PHYSICAL_ADDRESS_4 & "," & LOCATION & "," & COUNTRY_NAME & "," & POB_NUMBER & "," & POB_LOCATION & "," & POB_COUNTRY_NAME)

            'Loop

            'sr.Close()
            'sr1.Close()

            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_BIC_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
            Dim ParameterStatus As String = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_BIC_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i1 = 0 To dt.Rows.Count - 1
                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<BIC_DIRECTORY_TXT_FILE>", BIC_DIR_FILE)
                    cmd.CommandText = SqlCommandText1
                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                        Me.BgwBicDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwBicDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_BIC_DIRECTORY! Parameter Status is Invalid!!")
                MessageBox.Show("Unable to execute Import Procedure:IMPORT_BIC_DIRECTORY! Parameter Status is Invalid!!", "BIC DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If

            CloseSqlConnections()
            '*********************************************************************************************************
            'File.Delete(BIC_DIRECTORY_NEW_TXT_FILE)

            Me.BgwBicDirectory.ReportProgress(100, "BIC DIRECTORY IMPORT FINISHED")
            'SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwBicDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwBicDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBicDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','BIC DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BIC DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','BIC DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()

            TextImportFileRow = Now & "  " & "BIC DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)

            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwBicDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBicDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwBicDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT SEPA DIRECTORY"
    Private Sub BgwSepaDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSepaDirectory.DoWork
        Try
            If File.Exists(SEPA_DIR_FILE) = True Then
                OpenSqlConnections()
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_SEPA_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_SEPA_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<SEPA_DIR_FILE>", SEPA_DIR_FILE)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwSepaDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwSepaDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_SEPA_DIRECTORY! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_SEPA_DIRECTORY! Parameter Status is Invalid!!", "SEPA DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If
                CloseSqlConnections()

                'File.Delete(SEPA_DIR_FILE)
                'SplashScreenManager.Default.SetWaitFormCaption("SEPA DIRECTORY IMPORT finished")
                Me.BgwSepaDirectory.ReportProgress(30, "SEPA DIRECTORY IMPORT finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwSepaDirectory.ReportProgress(30, "Unable to Import the new SEPA DIRECTORY! File does not exist!")
                MessageBox.Show("Unable to Import the new SEPA DIRECTORY! File does not exist!", "SEPA DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwSepaDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSepaDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwSepaDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','SEPA DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "SEPA DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','SEPA DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "SEPA DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwSepaDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSepaDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwSepaDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT SEPA FULL DIRECTORY"
    Private Sub BgwSepaFullDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSepaFullDirectory.DoWork
        Try
            If File.Exists(SEPA_FULL_DIR_FILE) = True Then
                OpenSqlConnections()
                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_SEPA_FULL_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_SEPA_FULL_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<SEPA_FULL_DIR_FILE>", SEPA_FULL_DIR_FILE)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwSepaFullDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwSepaFullDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_SEPA_FULL_DIRECTORY! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_SEPA_FULL_DIRECTORY! Parameter Status is Invalid!!", "SEPA DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If

                CloseSqlConnections()
                'SplashScreenManager.Default.SetWaitFormCaption("SEPA FULL DIRECTORY IMPORT finished")
                Me.BgwSepaFullDirectory.ReportProgress(30, "SEPA FULL DIRECTORY IMPORT finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwSepaFullDirectory.ReportProgress(30, "Unable to Import the new SEPA FULL DIRECTORY! File does not exist!")
                MessageBox.Show("Unable to Import the new SEPA FULL DIRECTORY! File does not exist!", "SEPA FULL DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwSepaFullDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwSepaFullDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwSepaFullDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','SEPA FULL DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "SEPA FULL DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','SEPA FULL DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "SEPA FULL DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwSepaFullDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSepaFullDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwSepaFullDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT BLZ DIRECTORY"
    Private Sub BgwBlzDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBlzDirectory.DoWork
        Try
            OpenSqlConnections()
            cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('BLZ_DIRECTORY_NEW_TXT_FILE') 
                                and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
            Dim BLZ_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar

            If File.Exists(BLZ_DIRECTORY_NEW_TXT_FILE) = True Then
                File.Delete(BLZ_DIRECTORY_NEW_TXT_FILE)
            End If
            Dim DefaultEncoding As Encoding = Encoding.Default
            Dim sr As New System.IO.StreamReader(BLZ_DIR_FILE, DefaultEncoding)

            Dim sr1 As System.IO.StreamWriter
            sr1 = My.Computer.FileSystem.OpenTextFileWriter(BLZ_DIRECTORY_NEW_TXT_FILE, True)

            Dim Bankleitzahl As String = ""
            Dim Merkmal As String = ""
            Dim Bezeichnung As String = ""
            Dim Postleitzahl As String = ""
            Dim Ort As String = ""
            Dim Kurzbezeichnung As String = ""
            Dim InstitutsnummerPAN As String = ""
            Dim BIC As String = ""
            Dim Pruefzifferberechnungsmethode As String = ""
            Dim DatensatzNr As String = ""
            Dim Aenderungskennzeichen As String = ""
            Dim BLZ_Loeschung As String = ""
            Dim NachfolgeBLZ As String = ""
            Dim IBAN_Regel As String = ""


            Dim Zeileninhalt As String = ""
            'Dim Arr() As String


            'SplashScreenManager.Default.SetWaitFormCaption("Creating file: " & BLZ_DIRECTORY_NEW_TXT_FILE)
            Me.BgwBlzDirectory.ReportProgress(30, "Creating file: " & BLZ_DIRECTORY_NEW_TXT_FILE)
            Do While Not sr.EndOfStream
                Zeileninhalt = sr.ReadLine().Replace(",", " ")


                Bankleitzahl = Microsoft.VisualBasic.Left(Zeileninhalt, 8)
                Merkmal = Mid(Zeileninhalt, 9, 1)
                Bezeichnung = Mid(Zeileninhalt, 10, 58)
                Postleitzahl = Mid(Zeileninhalt, 68, 5)
                Ort = Mid(Zeileninhalt, 73, 35).Replace("'", "")
                Kurzbezeichnung = Mid(Zeileninhalt, 108, 27).Replace("'", "")
                InstitutsnummerPAN = Mid(Zeileninhalt, 135, 5).Replace("'", "")
                BIC = Mid(Zeileninhalt, 140, 11).Replace("'", "")
                Pruefzifferberechnungsmethode = Mid(Zeileninhalt, 151, 2).Replace("'", "")
                DatensatzNr = Mid(Zeileninhalt, 153, 6).Replace("'", "")
                Aenderungskennzeichen = Mid(Zeileninhalt, 159, 1).Replace("'", "")
                BLZ_Loeschung = Mid(Zeileninhalt, 160, 1).Replace("'", "")
                NachfolgeBLZ = Mid(Zeileninhalt, 161, 8).Replace("'", "")
                IBAN_Regel = Mid(Zeileninhalt, 169, 6).Replace("'", "")


                sr1.WriteLine(Bankleitzahl.ToUpper & "|" & Merkmal.ToUpper & "|" & Bezeichnung.ToUpper & "|" & Postleitzahl.ToUpper & "|" & Ort.ToUpper & "|" & Kurzbezeichnung.ToUpper & "|" & InstitutsnummerPAN.ToUpper & "|" & BIC.ToUpper & "|" & Pruefzifferberechnungsmethode.ToUpper & "|" & DatensatzNr.ToUpper & "|" & Aenderungskennzeichen.ToUpper & "|" & BLZ_Loeschung.ToUpper & "|" & NachfolgeBLZ.ToUpper & "|" & IBAN_Regel.ToUpper)

            Loop

            sr.Close()
            sr1.Close()

            'SplashScreenManager.Default.SetWaitFormCaption("Replace German Characters")
            Me.BgwBlzDirectory.ReportProgress(30, "Replace German Characters")
            My.Computer.FileSystem.WriteAllText(BLZ_DIRECTORY_NEW_TXT_FILE, My.Computer.FileSystem.ReadAllText(BLZ_DIRECTORY_NEW_TXT_FILE).Replace("Ü", "UE"), False)
            My.Computer.FileSystem.WriteAllText(BLZ_DIRECTORY_NEW_TXT_FILE, My.Computer.FileSystem.ReadAllText(BLZ_DIRECTORY_NEW_TXT_FILE).Replace("Ä", "AE"), False)
            My.Computer.FileSystem.WriteAllText(BLZ_DIRECTORY_NEW_TXT_FILE, My.Computer.FileSystem.ReadAllText(BLZ_DIRECTORY_NEW_TXT_FILE).Replace("Ö", "OE"), False)
            My.Computer.FileSystem.WriteAllText(BLZ_DIRECTORY_NEW_TXT_FILE, My.Computer.FileSystem.ReadAllText(BLZ_DIRECTORY_NEW_TXT_FILE).Replace("ß", "SS"), False)


            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_BLZ_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
            Dim ParameterStatus As String = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_BLZ_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i1 = 0 To dt.Rows.Count - 1
                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<BLZ_DIRECTORY_NEW_TXT_FILE>", BLZ_DIRECTORY_NEW_TXT_FILE)
                    cmd.CommandText = SqlCommandText1
                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                        Me.BgwBlzDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwBlzDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_BLZ_DIRECTORY! Parameter Status is Invalid!!")
                MessageBox.Show("Unable to execute Import Procedure:IMPORT_BLZ_DIRECTORY! Parameter Status is Invalid!!", "BLZ IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If


            CloseSqlConnections()
            'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BLZ_DIRECTORY_NEW_TXT_FILE)
            Me.BgwBlzDirectory.ReportProgress(30, "Delete File: " & BLZ_DIRECTORY_NEW_TXT_FILE)
            'File.Delete(BLZ_DIR_FILE)
            File.Delete(BLZ_DIRECTORY_NEW_TXT_FILE)
            'SplashScreenManager.Default.SetWaitFormCaption("BLZ DIRECTORY IMPORT finished")
            Me.BgwBlzDirectory.ReportProgress(30, "BLZ DIRECTORY IMPORT finished")
            'Else
            'SplashScreenManager.CloseForm(False)
            'Me.BgwBlzDirectory.ReportProgress(30, "Unable to Import the new BLZ DIRECTORY! File does not exist!")
            'MessageBox.Show("Unable to Import the new BLZ DIRECTORY! File does not exist!", "BLZ DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Exit Sub
            'End If
        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwBlzDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwBlzDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBlzDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','BLZ DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "BLZ DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','BLZ DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "BLZ DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwBlzDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBlzDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwBlzDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "IMPORT CUSTOMER ACC INFO"
    Private Sub BgwCustAccInfoDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwCustAccInfoDirectory.DoWork
        Try
            If File.Exists(CUST_ACC_INFO_DIR_FILE) = True Then
                CloseSqlConnections()
                'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_CUSTOMER_ACC_INFO_Temp")
                Me.BgwCustAccInfoDirectory.ReportProgress(40, "Create Temporary Table:CUSTOMER_INFO_Temp")
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_CUSTOMER_ACC_INFO_Temp' AND xtype='U')  CREATE TABLE [#Temp_CUSTOMER_ACC_INFO_Temp]([ODAS_BRANCH] [nvarchar](255) NULL,[Client Account] [nvarchar](255) NULL,[Account Status] [nvarchar](255) NULL,[ProductCode] [nvarchar](255) NULL,[Currency Status] [nvarchar](255) NULL,[Deal Currency] [nvarchar](255) NULL,[LEDGER_BALANCE] [nvarchar](255) NULL,[ClientNo] [nvarchar](255) NULL,[English Name] [nvarchar](255) NULL,[Country] [nvarchar](255) NULL,[PRD_TYPE] [nvarchar](255) NULL,[OPEN_DATE] [nvarchar](255) NULL,[CLOSE_DATE] [nvarchar](255) NULL,[AVAILABLE_BALANCE] [nvarchar](255) NULL,[AccountingCenter] [nvarchar](255) NULL,[BRANCH2] [nvarchar](255) NULL,[Column 16] [nvarchar](255) NULL) ELSE DELETE FROM [#Temp_CUSTOMER_ACC_INFO_Temp]"
                cmd.ExecuteNonQuery()
                'Import Data to Temp Table
                'SplashScreenManager.Default.SetWaitFormCaption("Import Data to #Temp_CUSTOMER_ACC_INFO_Temp")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Import Data to #Temp_CUSTOMER_ACC_INFO_Temp")
                cmd.CommandText = "BULK INSERT  [#Temp_CUSTOMER_ACC_INFO_Temp] FROM '" & CUST_ACC_INFO_DIR_FILE & "' with (FIRSTROW = 2,fieldterminator = '|')"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Set CLOSE_DATE to NULL if CLOSE_DATE is 0 in Table #Temp_CUSTOMER_ACC_INFO_Temp")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Set CLOSE_DATE to NULL if CLOSE_DATE is 0 in Table #Temp_CUSTOMER_ACC_INFO_Temp")
                cmd.CommandText = "UPDATE [#Temp_CUSTOMER_ACC_INFO_Temp] SET [CLOSE_DATE]=NULL where [CLOSE_DATE]='0'"
                cmd.ExecuteNonQuery()
                'Alter Table
                'SplashScreenManager.Default.SetWaitFormCaption("Alter Table #Temp_CUSTOMER_ACC_INFO_Temp for OPEN_DATE and CLOSE_DATE")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Alter Table #Temp_CUSTOMER_ACC_INFO_Temp for OPEN_DATE and CLOSE_DATE")
                cmd.CommandText = "ALTER TABLE [#Temp_CUSTOMER_ACC_INFO_Temp] ALTER COLUMN [OPEN_DATE] datetime"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ALTER TABLE [#Temp_CUSTOMER_ACC_INFO_Temp] ALTER COLUMN [CLOSE_DATE] datetime"
                cmd.ExecuteNonQuery()
                'Update data in CUSTOMER_ACCOUNTS
                'SplashScreenManager.Default.SetWaitFormCaption("Update Data to CUSTOMER_ACCOUNTS from #Temp_CUSTOMER_ACC_INFO_Temp")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update Data to CUSTOMER_ACCOUNTS from #Temp_CUSTOMER_ACC_INFO_Temp")
                cmd.CommandText = "UPDATE A SET A.[Account Status]=B.[Account Status], A.[English Name]=B.[English Name], A.[ProductCode]=B.[ProductCode], A.[Currency Status]=B.[Currency Status],A.[Country]=B.[Country],A.[PRD_TYPE]=B.[PRD_TYPE],A.[OPEN_DATE]=B.[OPEN_DATE],A.[CLOSE_DATE]=B.[CLOSE_DATE] from [CUSTOMER_ACCOUNTS] A INNER JOIN [#Temp_CUSTOMER_ACC_INFO_Temp] B ON A.[Client Account]=B.[Client Account]"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Delete from #Temp_CUSTOMER_ACC_INFO_Temp if Data allready presenjt in Table CUSTOMER_ACCOUNTS")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Delete from #Temp_CUSTOMER_ACC_INFO_Temp if Data allready presenjt in Table CUSTOMER_ACCOUNTS")
                cmd.CommandText = "DELETE  FROM [#Temp_CUSTOMER_ACC_INFO_Temp] where [Client Account] in (Select [Client Account] from [CUSTOMER_ACCOUNTS])"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Insert New data in Table CUSTOMER_ACCOUNTS")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert New data in Table CUSTOMER_ACCOUNTS")
                cmd.CommandText = "INSERT INTO [CUSTOMER_ACCOUNTS] ([ClientNo],[Client Account],[Deal Currency],[Account Status],[English Name],[ProductCode],[Currency Status],[Country],[PRD_TYPE],[OPEN_DATE],[CLOSE_DATE]) SELECT [ClientNo],[Client Account],[Deal Currency],[Account Status],[English Name],[ProductCode],[Currency Status],[Country],[PRD_TYPE],[OPEN_DATE],[CLOSE_DATE] from [#Temp_CUSTOMER_ACC_INFO_Temp]"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Update CLIENT ACCOUNT DOMESTIC")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update CLIENT ACCOUNT DOMESTIC")
                cmd.CommandText = "UPDATE [CUSTOMER_ACCOUNTS] SET [ClientAccountDomestic]=RIGHT([Client Account],10) where [ClientAccountDomestic] is NULL"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Update CLIENT IBAN NR")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update CLIENT IBAN NR")
                QueryText = "Select  '50310900'+[ClientAccountDomestic]+'131400' as BBAN,[ClientAccountDomestic] as ClientAccount from [CUSTOMER_ACCOUNTS] where [IBAN] is NULL"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim IBANCHECKDIGIT As String = Nothing
                    Dim ClientAccount As String = dt.Rows.Item(i).Item("ClientAccount")
                    Dim BBAN As Decimal = dt.Rows.Item(i).Item("BBAN")
                    Dim Modulo97 As Decimal = BBAN Mod 97
                    Dim CheckNumber As Decimal = 98 - Modulo97

                    If CheckNumber < 10 Then
                        IBANCHECKDIGIT = "DE0" & CheckNumber
                        cmd.CommandText = "UPDATE [CUSTOMER_ACCOUNTS] SET [IBAN]= '" & IBANCHECKDIGIT & "' +'50310900'+ [ClientAccountDomestic] WHERE [ClientAccountDomestic]= '" & ClientAccount & "'"
                        cmd.ExecuteNonQuery()
                    Else
                        IBANCHECKDIGIT = "DE" & CheckNumber
                        cmd.CommandText = "UPDATE [CUSTOMER_ACCOUNTS] SET [IBAN]= '" & IBANCHECKDIGIT & "' +'50310900'+ [ClientAccountDomestic] WHERE [ClientAccountDomestic]= '" & ClientAccount & "'"
                        cmd.ExecuteNonQuery()
                    End If
                Next
                'SplashScreenManager.Default.SetWaitFormCaption("Update ClientType in CUSTOMER_ACCOUNTS")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update ClientType in CUSTOMER_ACCOUNTS")
                cmd.CommandText = "UPDATE A SET A.[ClientType]=B.ClientType from CUSTOMER_ACCOUNTS A INNER JOIN CUSTOMER_INFO B on A.ClientNo=B.ClientNo"
                cmd.ExecuteNonQuery()

                'SplashScreenManager.Default.SetWaitFormCaption("DROP Table #Temp_CUSTOMER_ACC_INFO_Temp")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "DROP Table #Temp_CUSTOMER_ACC_INFO_Temp")
                cmd.CommandText = "DROP TABLE [#Temp_CUSTOMER_ACC_INFO_Temp]"
                cmd.ExecuteNonQuery()

                'SplashScreenManager.Default.SetWaitFormCaption("Update Data in Table: CLIENTS_ACCOUNTS")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update Data in Table: CLIENTS_ACCOUNTS")
                cmd.CommandText = "UPDATE A SET A.[Account Status]=B.[Account Status], A.[English Name]=B.[English Name], A.[ProductCode]=B.[ProductCode], A.[Currency Status]=B.[Currency Status],A.[ClientAccountDomestic]=B.[ClientAccountDomestic],A.[Online]=B.[Online],A.[IBAN]=B.[IBAN],A.[Country]=B.[Country],A.[PRD_TYPE]=B.[PRD_TYPE],A.[OPEN_DATE]=B.[OPEN_DATE],A.[CLOSE_DATE]=B.[CLOSE_DATE] from [CLIENTS_ACCOUNTS] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Client Account]=B.[Client Account]"
                cmd.ExecuteNonQuery()

                'Get Clients folder creation directory
                cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('CLIENTS_DOCS_FOLDER') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
                Dim CLIENTS_DOCS_FOLDER As String = cmd.ExecuteScalar
                'CREATE FOLDERS AND SUBFOLDERS FOR NEW CUSTOMERS
                'SplashScreenManager.Default.SetWaitFormCaption("Create Document Folders and Subfolders for new Clients")
                Me.BgwCustAccInfoDirectory.ReportProgress(75, "Create Document Folders and Subfolders for new Clients")
                QueryText = "Select [ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('C - COMPANY') and [ClientNo] in (Select [ClientNo] from [CUSTOMER_ACCOUNTS] where [ProductCode] in ('DDPCUR01','DDPCUR02')) and [ClientNo] not in (Select [ClientNo] from [CLIENTS])"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientNr As String = dt.Rows.Item(i).Item("ClientNo")
                    'SplashScreenManager.Default.SetWaitFormCaption("Create Document Folders and Subfolders for Client Nr.: " & ClientNr)
                    Me.BgwCustAccInfoDirectory.ReportProgress(75, "Create Document Folders and Subfolders for Client Nr.: " & ClientNr)
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\ACCOUNT_OPENNING_DOCUMENTS'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\AUTHORIZED_SIGNATURES_(VALID)'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\AUTHORIZED_SIGNATURES_(INVALID)'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\CERTIFICATE_OF_REGISTRATION'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\CORRESPONDENCE_WITH_CUSTOMER'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\PASSPORTS_VISA_ID_COPIES'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "EXEC master.dbo.xp_cmdshell 'MD " & CLIENTS_DOCS_FOLDER & ClientNr & "\X_DOCUMENTS'"
                    cmd.ExecuteNonQuery()
                Next

                'SplashScreenManager.Default.SetWaitFormCaption("INSERT NEW CLIENTS in Table:CLIENTS")
                Me.BgwCustAccInfoDirectory.ReportProgress(75, "INSERT NEW CLIENTS in Table:CLIENTS")
                cmd.CommandText = "INSERT INTO [CLIENTS]([ClientNo],[ClientType],[ID Type],[ID No],[ID_TYPE_2],[ID_NO_2],[English Name],[ESTABLISH_DATE],[Joint Account],[ACCOUNT_OFFICER_NAME],[Chinese Name],[LEGAL_STATUS],[CLIENT_OPEN_DATE],[CLIENT_RISK],[City],[COUNTRY_OF_REGISTRATION],[SHORT_NAME],[Internal Type],[OIC No],[RiskCountry],[Open Date],[Teller],[OIC_BR],[COUNTRY_OF_RESIDENCE],[INSTITUTION_SECTOR_CODE],[INDUSTRIAL_CLASS_LOCAL],[INDUSTRIAL_CLASS_LOCAL_NAME],[INDUSTRIAL_CLASS_CN],[FINANCIAL_BACKGROUND],[BUSINESS_GROUP],[CREDIT_AGENCY],[credit rating],[CLOSE_DATE],[ADDRESS_NO01],[ADDRESS_TYPE01],[ADDRESS1],[ADDRESS2],[ADDRESS3],[ADDRESS4],[ADDRESS_NO02],[ADDRESS5],[ADDRESS6],[ADDRESS_TYPE02],[ClientDocsDirectory])SELECT [ClientNo],[ClientType ],[ID Type],[ID No],[ID_TYPE_2],[ID_NO_2],[English Name],[ESTABLISH_DATE],[Joint Account],[ACCOUNT_OFFICER_NAME],[Chinese Name],[LEGAL_STATUS],[CLIENT_OPEN_DATE],[CLIENT_RISK],[City],[COUNTRY_OF_REGISTRATION],[SHORT_NAME],[Internal Type],[OIC No],[RiskCountry],[Open Date],[Teller],[OIC_BR],[COUNTRY_OF_RESIDENCE],[INSTITUTION_SECTOR_CODE],[INDUSTRIAL_CLASS_LOCAL],[INDUSTRIAL_CLASS_LOCAL_NAME],[INDUSTRIAL_CLASS_CN],[FINANCIAL_BACKGROUND],[BUSINESS_GROUP],[CREDIT_AGENCY],[credit rating],[CLOSE_DATE],[ADDRESS_NO01],[ADDRESS_TYPE01],[ADDRESS1],[ADDRESS2],[ADDRESS3],[ADDRESS4],[ADDRESS_NO02],[ADDRESS5],[ADDRESS6],[ADDRESS_TYPE02],'\\CCB-PSTOOL\Apps\CLIENTS\'+[ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('C - COMPANY') and [ClientNo] in (Select [ClientNo] from [CUSTOMER_ACCOUNTS] where [ProductCode] in ('DDPCUR01','DDPCUR02')) and [ClientNo] not in (Select [ClientNo] from [CLIENTS]) "
                cmd.ExecuteNonQuery()

                'SplashScreenManager.Default.SetWaitFormCaption("Insert AML Classification Parameters for new Clients")
                Me.BgwCustAccInfoDirectory.ReportProgress(75, "Insert AML Classification Parameters for new Clients")
                QueryText = "Select [ClientNo] from [CUSTOMER_INFO] where [ClientType] in ('C - COMPANY') and [ClientNo] in (Select [ClientNo] from [CUSTOMER_ACCOUNTS] where [ProductCode] in ('DDPCUR01','DDPCUR02')) and [ClientNo] not in (Select distinct [Id_ClientNo] from [CLIENTS_AML_CLASSIFIC])"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim ClientNr As String = dt.Rows.Item(i).Item("ClientNo")
                    cmd.CommandText = "INSERT INTO [CLIENTS_AML_CLASSIFIC] ([Classification_Type],[Classification_DescriptScore],[Id_ClientNo]) Select [SQL_Name_1],CAST([SQL_Command_1] as varchar(4000)),'" & ClientNr & "' from [SQL_PARAMETER_DETAILS] where [Id_SQL_Parameters]='AML_RISK_CLASSIFICATION' order by ID asc"
                    cmd.ExecuteNonQuery()
                Next


                'SplashScreenManager.Default.SetWaitFormCaption("Insert New Data in Table: CLIENTS_ACCOUNTS")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert New Data in Table: CLIENTS_ACCOUNTS")
                cmd.CommandText = "INSERT INTO [CLIENTS_ACCOUNTS] ([ClientNo],[Client Account],[Deal Currency],[ClientAccountDomestic],[IBAN],[Online],[Account Status],[English Name],[ProductCode],[Currency Status],[Country],[PRD_TYPE],[OPEN_DATE],[CLOSE_DATE],[Id_ClientNo]) SELECT [ClientNo],[Client Account],[Deal Currency],[ClientAccountDomestic],[IBAN],[Online],[Account Status],[English Name],[ProductCode],[Currency Status],[Country],[PRD_TYPE],[OPEN_DATE],[CLOSE_DATE],[ClientNo] from [CUSTOMER_ACCOUNTS] where [ProductCode] in ('DDPCUR01','DDPCUR02') and [Client Account] not in (Select [Client Account] from [CLIENTS_ACCOUNTS] where [ProductCode] in ('DDPCUR01','DDPCUR02')) "
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Insert New Data in Table: CLIENTS_ACCOUNTS_VOLUMES after removing the old one-Stored Procedure:CLIENTS_ACCOUNTS_VOLUMES_CALCULATE")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert New Data in Table: CLIENTS_ACCOUNTS_VOLUMES after removing the old one-Stored Procedure:CLIENTS_ACCOUNTS_VOLUMES_CALCULATE")
                'cmd.CommandText = "DELETE FROM [CLIENTS_ACCOUNTS_VOLUMES]"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "INSERT INTO [CLIENTS_ACCOUNTS_VOLUMES]([DateOnFirstMonth],[AccountNo],[ClientNo],[MonthDate],[YearDate],[MonthNr],[Monthsname],[AnzahlIncomings],[IncomingSum],[AverageIncomingMonth],[AnzahlOutgoings],[OutgoingSum],[AverageOutgoingMonth],[Id_ClientAccount]) Select A.FirtsDayMonth,CAST(LTRIM(STR(A.[AccountNo],12)) AS NVARCHAR(12)),A.[ClientNo],A.MonthDate,A.YearDate,A.MonthNr,A.Monthsname,A.AnzahlIncomings,A.IncomingSum,Round(A.IncomingSum/A.AnzahlIncomings,2) as AverageIncomingMonth,B.AnzahlOutgoings,B.OutgoingSum,Round(B.OutgoingSum/B.AnzahlOutgoings,2) as AverageOutgoingMonth,CAST(LTRIM(STR(A.[AccountNo],12)) AS NVARCHAR(12)) from (SELECT [AccountNo],[ClientNo],CAST(MONTH(GL_Rep_Date) AS VARCHAR(2)) + '.' + CAST(YEAR(GL_Rep_Date) AS VARCHAR(4)) AS MonthDate,DATEPART(Year, GL_Rep_Date) as YearDate,DATEPART(Month, GL_Rep_Date)as MonthNr, Count([IdNr]) as AnzahlIncomings,SUM(AmountInEuro) AS IncomingSum,DATENAME(month, [GL_Rep_Date]) as Monthsname,DATEADD(mm, DATEDIFF(mm,0,[GL_Rep_Date]),0) as FirtsDayMonth FROM [CUSTOMER_VOLUMES] WHERE [AccountNo] in (Select [Client Account] from [CLIENTS_ACCOUNTS]) and [Description] is not NULL and [AmountInEuro]>0 GROUP BY [AccountNo],[ClientNo],DATEPART(Year, GL_Rep_Date),DATEPART(Month, GL_Rep_Date),CAST(MONTH(GL_Rep_Date) AS VARCHAR(2)) + '.' + CAST(YEAR(GL_Rep_Date) AS VARCHAR(4)),DATENAME(month, GL_Rep_Date),DATEADD(mm, DATEDIFF(mm,0,[GL_Rep_Date]),0)) as A LEFT JOIN(SELECT [AccountNo],[ClientNo],CAST(MONTH(GL_Rep_Date) AS VARCHAR(2)) + '.' + CAST(YEAR(GL_Rep_Date) AS VARCHAR(4)) AS MonthDate,DATEPART(Year, GL_Rep_Date) as YearDate,DATEPART(Month, GL_Rep_Date)as MonthNr, Count([IdNr]) as AnzahlOutgoings,SUM(AmountInEuro) AS OutgoingSum,DATENAME(month, [GL_Rep_Date]) as Monthsname FROM [CUSTOMER_VOLUMES] WHERE [AccountNo] in (Select [Client Account] from [CLIENTS_ACCOUNTS]) and [Description] is not NULL and [AmountInEuro]<0 GROUP BY [AccountNo],[ClientNo],DATEPART(Year, GL_Rep_Date),DATEPART(Month, GL_Rep_Date),CAST(MONTH(GL_Rep_Date) AS VARCHAR(2)) + '.' + CAST(YEAR(GL_Rep_Date) AS VARCHAR(4)),DATENAME(month, GL_Rep_Date)) as B ON A.MonthDate=B.MonthDate and A.[AccountNo]=B.[AccountNo] order by A.YearDate desc, A.MonthNr desc"
                'cmd.ExecuteNonQuery()
                'cmd.CommandText = "Select [AnzahlIncomings],[IncomingSum],[AverageIncomingMonth],[AnzahlOutgoings],[OutgoingSum],[AverageOutgoingMonth] from [CLIENTS_ACCOUNTS_VOLUMES] begin Update [CLIENTS_ACCOUNTS_VOLUMES] set [AnzahlIncomings]=0 where [AnzahlIncomings] is NULL end begin Update [CLIENTS_ACCOUNTS_VOLUMES] set [IncomingSum]=0 where [IncomingSum] is NULL end begin Update [CLIENTS_ACCOUNTS_VOLUMES] set [AverageIncomingMonth]=0 where [AverageIncomingMonth] is NULL end begin Update [CLIENTS_ACCOUNTS_VOLUMES] set [AnzahlOutgoings]=0 where [AnzahlOutgoings] is NULL end begin Update [CLIENTS_ACCOUNTS_VOLUMES] set [OutgoingSum]=0 where [OutgoingSum] is NULL end begin Update [CLIENTS_ACCOUNTS_VOLUMES] set [AverageOutgoingMonth]=0 where [AverageOutgoingMonth] is NULL end"
                'cmd.ExecuteNonQuery()
                cmd.CommandText = "EXEC [CLIENTS_ACCOUNTS_VOLUMES_CALCULATE]"
                cmd.ExecuteNonQuery()




                'If MessageBox.Show("Should the table EAEG_KUNDEN_KONTEN be updated with new Data?" & vbNewLine & vbNewLine & "This procedure will take a few minutes!", "UPDATE EAEG KUNDEN KONTEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                'EAEG DATEN
                'Import GiroKonten

                'SplashScreenManager.Default.SetWaitFormCaption("Insert new GIROKONTEN in EAEG_KUNDEN_KONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert new GIROKONTEN in EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "INSERT INTO [EAEG_KUNDEN_KONTEN]([B2_OrdnungskennzeichenId],[C2_Kontonummer],[C6_Kontoerröfnung],[C7_Kontoart],[ClosingDate],[AccountStatus],[ProductType],[C8_Währung])SELECT[ClientNo],REPLACE(LTRIM(REPLACE([ClientAccountDomestic], '0', ' ')), ' ', '0'),[OPEN_DATE],'KK',[CLOSE_DATE],[Account Status],[ProductCode],[Deal Currency] from [CUSTOMER_ACCOUNTS] where [ProductCode] in('DDPCUR01','DDPCUR02') and REPLACE(LTRIM(REPLACE([ClientAccountDomestic], '0', ' ')), ' ', '0') not in (Select [C2_Kontonummer] from [EAEG_KUNDEN_KONTEN]) and [ClientNo] in (Select [B2_Ordnungskennzeichen] from [EAEG_KUNDEN_STAMM])"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("UPDATE DATA in EAEG_KUNDEN_KONTEN for existing GIROKONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "UPDATE DATA in EAEG_KUNDEN_KONTEN for existing Accounts")
                cmd.CommandText = "UPDATE A SET A.[ClosingDate]=B.[CLOSE_DATE],A.[AccountStatus]=B.[Account Status],A.[Kontoname]=B.[English Name] from [EAEG_KUNDEN_KONTEN] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[C2_Kontonummer]=REPLACE(LTRIM(REPLACE(B.[ClientAccountDomestic], '0', ' ')), ' ', '0')"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Set C13_LetzteZinsfaelligkeit in EAEG_KUNDEN_KONTEN for Active GIROKONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Set C13_LetzteZinsfaelligkeit in EAEG_KUNDEN_KONTEN for Active GIROKONTEN")
                cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [C13_LetzteZinsfaelligkeit]=DATEADD(d,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE()),0)) where [AccountStatus]='A - ACTIVE' and [C7_Kontoart]='KK'"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Set Closing Date to 31.12.9999 for Active GIROKONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Set Closing Date to 31.12.9999 for Active GIROKONTEN")
                cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [ClosingDate]='99991231' where [AccountStatus]='A - ACTIVE' and [C7_Kontoart]='KK'"
                cmd.ExecuteNonQuery()
                'Import Festgelder
                'SplashScreenManager.Default.SetWaitFormCaption("Insert new TIME DEPOSITS in EAEG_KUNDEN_KONTEN-C6_Kontoerröfnung=StartDate if StartDate=Current Interest Coupon Period Start Date")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert new TIME DEPOSITS in EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "INSERT INTO [EAEG_KUNDEN_KONTEN]([B2_OrdnungskennzeichenId],[C2_Kontonummer],[C6_Kontoerröfnung],[C7_Kontoart],[ClosingDate],[C14_Endfaelligkeit],[ProductType],[C8_Währung])SELECT[Counterparty No],[Contract],[Start Date],'FG',[Final Maturity Date],[Final Maturity Date],[Product Type],[Org Ccy] from [ACCRUED INTEREST ANALYSIS] where [Product Type] in('MMFCUD','MMPVCU') and [Start Date]=[Current Interest Coupon Period Start Date] and [Contract] not in (Select [C2_Kontonummer] from [EAEG_KUNDEN_KONTEN]) and [Counterparty No] in (Select [B2_Ordnungskennzeichen] from [EAEG_KUNDEN_STAMM] where [EAEG_Valid]='Y')"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Insert new TIME DEPOSITS in EAEG_KUNDEN_KONTEN-C6_Kontoerröfnung=TradeDate if StartDate<>Current Interest Coupon Period Start Date")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert new TIME DEPOSITS in EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "INSERT INTO [EAEG_KUNDEN_KONTEN]([B2_OrdnungskennzeichenId],[C2_Kontonummer],[C6_Kontoerröfnung],[C7_Kontoart],[ClosingDate],[C14_Endfaelligkeit],[ProductType],[C8_Währung])SELECT[Counterparty No],[Contract],[Trade Date],'FG',[Final Maturity Date],[Final Maturity Date],[Product Type],[Org Ccy] from [ACCRUED INTEREST ANALYSIS] where [Product Type] in('MMFCUD','MMPVCU') and [Start Date]<>[Current Interest Coupon Period Start Date] and [Contract] not in (Select [C2_Kontonummer] from [EAEG_KUNDEN_KONTEN]) and [Counterparty No] in (Select [B2_Ordnungskennzeichen] from [EAEG_KUNDEN_STAMM] where [EAEG_Valid]='Y')"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Delete duplicates in EAEG_KUNDEN_KONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Delete duplicates in EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "DELETE  FROM [EAEG_KUNDEN_KONTEN] where [ID] not in (Select Min([ID]) from [EAEG_KUNDEN_KONTEN] group by [C2_Kontonummer])"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Insert Assets in EAEG_KUNDEN_KONTEN only if Customer Accounts are KK and/or FG")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Insert Assets in EAEG_KUNDEN_KONTEN only if Customer Accounts are KK and/or FG")
                QueryText = "SELECT [B2_OrdnungskennzeichenId] FROM [EAEG_KUNDEN_KONTEN] where [C7_Kontoart] in ('KK','FG') GROUP BY [B2_OrdnungskennzeichenId]"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim StammNr As String = dt.Rows.Item(i).Item("B2_OrdnungskennzeichenId")
                    cmd.CommandText = "INSERT INTO [EAEG_KUNDEN_KONTEN]([B2_OrdnungskennzeichenId],[C2_Kontonummer],[C6_Kontoerröfnung],[C7_Kontoart],[ClosingDate],[C14_Endfaelligkeit],[ProductType],[C8_Währung])SELECT[Counterparty No],[Contract],[Trade Date],'Darlehen',[Final Maturity Date],[Final Maturity Date],[Product Type],[Org Ccy] from [ACCRUED INTEREST ANALYSIS] where [Class] in('Assets') and [Contract] not in (Select [C2_Kontonummer] from [EAEG_KUNDEN_KONTEN]) and [Counterparty No]='" & StammNr & "'"
                    cmd.ExecuteNonQuery()
                Next
                'SplashScreenManager.Default.SetWaitFormCaption("Delete duplicates in EAEG_KUNDEN_KONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Delete duplicates in EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "DELETE  FROM [EAEG_KUNDEN_KONTEN] where [ID] not in (Select Min([ID]) from [EAEG_KUNDEN_KONTEN] group by [C2_Kontonummer])"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Set C5_AnzahlKontoinhaber to 1 for all EAEG_KUNDEN_KONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Set C5_AnzahlKontoinhaber to 1 for all EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [C5_AnzahlKontoinhaber]=1" 'where [C5_AnzahlKontoinhaber] is NULL"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Set C16_Zinsmethode for all EAEG_KUNDEN_KONTEN")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Set C16_Zinsmethode for all EAEG_KUNDEN_KONTEN")
                cmd.CommandText = "SELECT [C7_Kontoart] from [EAEG_KUNDEN_KONTEN] Begin UPDATE [EAEG_KUNDEN_KONTEN] SET [C16_Zinsmethode]='01' where [C7_Kontoart] in ('KK','FG') and [C8_Währung] not in ('GBP') and [C16_Zinsmethode] is NULL  end Begin UPDATE [EAEG_KUNDEN_KONTEN] SET [C16_Zinsmethode]='02' where [C7_Kontoart] in ('KK','FG') and [C8_Währung] in ('GBP') and [C16_Zinsmethode] is NULL end"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Update Kontoname in EAEG_KUNDEN_KONTEN from CUSTOMER_INFO")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update Kontoname in EAEG_KUNDEN_KONTEN from CUSTOMER_INFO")
                cmd.CommandText = "UPDATE A set A.[Kontoname]=B.[English Name] from [EAEG_KUNDEN_KONTEN] A INNER JOIN [CUSTOMER_INFO] B On A.[B2_OrdnungskennzeichenId]=B.[ClientNo] where A.[Kontoname] is NULL"
                cmd.ExecuteNonQuery()
                '++++++++++++++++++++++++++++++++++++++++++
                'Letzte Zinsfälligkeit bei Festgelder
                'Wenn START Date=Cupon Interest Start Date -->Erste Zinsfälligkeit
                'Wenn START Date<>Cupon Interest Start Date dan Zinsfälligkeit=Cupon Interest Start Date
                '++++++++++++++++++++++++++++++++++++++++++++++
                'SPEZIELLE STATEMENTS FÜR VERSCHLÜSSELUNGEN
                'SplashScreenManager.Default.SetWaitFormCaption("Set C21_WeitereZustandsverschluesselungen_Pos2=Y where Product Type=MMPVCU (Verpfändete und abgetretene Guthaben)")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Set C21_WeitereZustandsverschluesselungen_Pos2=Y where Product Type=MMPVCU (Verpfändete und abgetretene Guthaben)")
                cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [C21_WeitereZustandsverschluesselungen_Pos2]='Y' where [ProductType]='MMPVCU'"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Update Field C20_GESAMT and C21_GESAMT based on Stored Procedure:EAEG_KUNDENKONTEN_C20_C21_AUSSCHLUSS")
                Me.BgwCustAccInfoDirectory.ReportProgress(60, "Update Field C20_GESAMT and C21_GESAMT based on Stored Procedure:EAEG_KUNDENKONTEN_C20_C21_AUSSCHLUSS")
                cmd.CommandText = "EXEC [EAEG_KUNDENKONTEN_C20_C21_AUSSCHLUSS]"
                cmd.ExecuteNonQuery()

                'End If

                CloseSqlConnections()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete Text File: " & CUST_ACC_INFO_DIR_FILE)
                Me.BgwCustAccInfoDirectory.ReportProgress(80, "Delete Text File: " & CUST_ACC_INFO_DIR_FILE)
                File.Delete(CUST_ACC_INFO_DIR_FILE)
                'SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER ACC INFO IMPORT finished")
                Me.BgwCustAccInfoDirectory.ReportProgress(90, "CUSTOMER ACC INFO IMPORT finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwCustAccInfoDirectory.ReportProgress(30, "Unable to Import the new CUSTOMER ACCOUNT INFO! File does not exist!")
                MessageBox.Show("Unable to Import the new CUSTOMER ACCOUNT INFO! File does not exist!", "CUSTOMER ACC INFO IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwCustAccInfoDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwCustAccInfoDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwCustAccInfoDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','CUSTOMER ACC INFO IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "CUSTOMER ACC INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','CUSTOMER ACC INFO IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "CUSTOMER ACC INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwCustAccInfoDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwCustAccInfoDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwCustAccInfoDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "IMPORT ODAS REMMITANCE"
    Private Sub BgwOdasRemmitancePayDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOdasRemmitancePayDirectory.DoWork

        Try
            If File.Exists(ODAS_REMMITANCE_PAY_FILE) = True Then
                OpenSqlConnections()
                'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_ODAS_REMMITANCE_Temp")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(40, "Create Temporary Table:#Temp_ODAS_REMMITANCE_Temp")

                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ODAS_REMMITANCE_Temp' AND xtype='U') DROP TABLE [#Temp_ODAS_REMMITANCE_Temp]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ODAS_REMMITANCE_Temp' AND xtype='U')  CREATE TABLE [#Temp_ODAS_REMMITANCE_Temp]([EM00KEY0] [nvarchar](255) NULL,[EM00KEY1] [nvarchar](255) NULL,[EM00KEY2] [nvarchar](255) NULL,[Client Account] [nvarchar](255) NULL,[OURTRANREFNO] [nvarchar](255) NULL,[INWARDOUTWARD] [nvarchar](255) NULL,[METHOD] [nvarchar](255) NULL,[RECEIVERID] [nvarchar](255) NULL,[RECEIVERNAME] [nvarchar](255) NULL,[RECEIVERBRANCH] [nvarchar](255) NULL,[RECEIVERSWIFT] [nvarchar](255) NULL,[SENDERCORBKID] [nvarchar](255) NULL,[SENDERCORRNAME] [nvarchar](255) NULL,[SENDERCORRBR] [nvarchar](255) NULL,[SENDERCORRST] [nvarchar](255) NULL,[RECRCORRID] [nvarchar](255) NULL,[RECRCORRNAME] [nvarchar](255) NULL,[RECRCORRBR] [nvarchar](255) NULL,[RECRCORRSWIFT] [nvarchar](255) NULL,[ACWITHINSTID] [nvarchar](255) NULL,[ACWITHINSTNA] [nvarchar](255) NULL,[ACWITHINSTBR] [nvarchar](255) NULL,[ACWITHINSTST] [nvarchar](255) NULL,[BENEFACNO] [nvarchar](255) NULL,[BENEFCUSTID] [nvarchar](255) NULL,[BENEFCUSTNAME] [nvarchar](255) NULL,[BENEFCUSTBR] [nvarchar](255) NULL,[BENEFCUSTADR1] [nvarchar](255) NULL,[BENEFCUSTADR2] [nvarchar](255) NULL,[DETOFCHARGE] [nvarchar](255) NULL,[SETOREINFO] [nvarchar](255) NULL,[TRANSACTIONDATE] [nvarchar](20) NULL,[VALUEDATE] [nvarchar](20) NULL,[CURRENCYCODE] [nvarchar](255) NULL,[Deal Amount] [nvarchar](50) NULL,[HANDLINGFEE] [nvarchar](50) NULL,[ORDERCUSTID] [nvarchar](255) NULL,[ORDERCUSTNAME] [nvarchar](255) NULL,[ORDERCUSTBR] [nvarchar](255) NULL,[ORDERCUSTADD1] [nvarchar](255) NULL,[ORDERCUSTADD2] [nvarchar](255) NULL,[ORDERCUSTADD3] [nvarchar](255) NULL,[SWIFTINREF] [nvarchar](255) NULL,[HOLDFUNC] [nvarchar](255) NULL,[Column 44] [nvarchar](255) NULL) ELSE DELETE FROM [#Temp_ODAS_REMMITANCE_Temp]"
                cmd.ExecuteNonQuery()
                'Import Data to Temp Table
                'SplashScreenManager.Default.SetWaitFormCaption("Import Data to #Temp_ODAS_REMMITANCE_Temp")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(60, "Import Data to #Temp_ODAS_REMMITANCE_Temp")
                cmd.CommandText = "BULK INSERT  [#Temp_ODAS_REMMITANCE_Temp] FROM '" & ODAS_REMMITANCE_PAY_FILE & "' with (FIRSTROW = 2,fieldterminator = '|')"
                cmd.ExecuteNonQuery()
                'Alter Table 
                'SplashScreenManager.Default.SetWaitFormCaption("ALTER Column TRANSACTIONDATE to Datetime")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(60, "ALTER Column TRANSACTIONDATE to Datetime")
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ALTER COLUMN [TRANSACTIONDATE] datetime"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("ALTER Column VALUEDATE to Datetime")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(60, "ALTER Column VALUEDATE to Datetime")
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ALTER COLUMN [VALUEDATE] datetime"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("ALTER Column Deal Amount to float")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(60, "ALTER Column Deal Amount to float")
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ALTER COLUMN [Deal Amount] float"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("ALTER Column HANDLINGFEE to float")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(60, "ALTER Column HANDLINGFEE to float")
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ALTER COLUMN [HANDLINGFEE] float"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Insert new Columns in Temporary Table:ID,EXCHANGE_RATE,Deal Amount Euro and Default Values")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(60, "Insert new Columns in Temporary Table:ID,EXCHANGE_RATE,Deal Amount Euro")
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ADD [ID] [int] IDENTITY(1,1) NOT NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ADD [EXCHANGE_RATE] float "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] add default (0) for [EXCHANGE_RATE]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] ADD [Deal Amount Euro] float "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ALTER TABLE [#Temp_ODAS_REMMITANCE_Temp] add default (0) for [Deal Amount Euro] "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [#Temp_ODAS_REMMITANCE_Temp] SET [Deal Amount Euro]=0,[EXCHANGE_RATE]=0"
                cmd.ExecuteNonQuery()

                'Exchange Rates definieren(NICHT EURO)
                'SplashScreenManager.Default.SetWaitFormCaption("Define Exchange Rates for Currency not in EURO based on TRANSACTIONDATE")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Define Exchange Rates for Currency not in EURO based on TRANSACTIONDATE")
                cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [#Temp_ODAS_REMMITANCE_Temp] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[TRANSACTIONDATE]=B.[EXCHANGE RATE DATE]  where A.[CURRENCYCODE]=B.[CURRENCY CODE] and A.[EXCHANGE_RATE]=0"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Define Exchange Rates for Currency not in EURO based on VALUEDATE")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Define Exchange Rates for Currency not in EURO based on VALUEDATE")
                cmd.CommandText = "UPDATE A SET A.[EXCHANGE_RATE]=B.[MIDDLE RATE] FROM [#Temp_ODAS_REMMITANCE_Temp] A INNER JOIN [EXCHANGE RATES OCBS] B ON A.[VALUEDATE]=B.[EXCHANGE RATE DATE]  where A.[CURRENCYCODE]=B.[CURRENCY CODE] and A.[EXCHANGE_RATE]=0"
                cmd.ExecuteNonQuery()
                'Exchange Rates definieren(EURO)
                'SplashScreenManager.Default.SetWaitFormCaption("Define Exchange Rates for Currency in EURO")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Define Exchange Rates for Currency in EURO")
                cmd.CommandText = "UPDATE [#Temp_ODAS_REMMITANCE_Temp] SET [EXCHANGE_RATE]=1 where [CURRENCYCODE]='EUR' and [EXCHANGE_RATE]=0"
                cmd.ExecuteNonQuery()
                'Calculate Payment Amount in EURO
                'SplashScreenManager.Default.SetWaitFormCaption("Calculate Payment Amount in EURO")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Calculate Payment Amount in EURO")
                cmd.CommandText = "UPDATE [#Temp_ODAS_REMMITANCE_Temp] SET [Deal Amount Euro]=Round([Deal Amount]/[EXCHANGE_RATE],2) where  [Deal Amount Euro]=0 and [EXCHANGE_RATE]<>0"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Insert Data to ODAS REMMITANCES")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Insert Data to ODAS REMMITANCES")
                cmd.CommandText = "INSERT INTO [ODAS REMMITANCES]([EM00KEY0],[EM00KEY1],[EM00KEY2],[Client Account],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORBKID],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[Deal Amount],[EXCHANGE_RATE],[Deal Amount Euro],[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC])SELECT [EM00KEY0],[EM00KEY1],[EM00KEY2],[Client Account],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERID],[RECEIVERNAME],[RECEIVERBRANCH],[RECEIVERSWIFT],[SENDERCORBKID],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTBR],[BENEFCUSTADR1],[BENEFCUSTADR2],[DETOFCHARGE],[SETOREINFO],[TRANSACTIONDATE],[VALUEDATE],[CURRENCYCODE],[Deal Amount],[EXCHANGE_RATE],[Deal Amount Euro],[HANDLINGFEE],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTBR],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[SWIFTINREF],[HOLDFUNC] from [#Temp_ODAS_REMMITANCE_Temp]"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Delete only Duplicate Payments in ODAS REMMITANCES comparing with EM00KEY0-Payment Reference")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Delete only Duplicate Payments in ODAS REMMITANCES comparing with EM00KEY0-Payment Reference")
                cmd.CommandText = "DELETE  FROM [ODAS REMMITANCES] where [ID] not in (Select Min([ID]) from [ODAS REMMITANCES] group by [EM00KEY0])"
                cmd.ExecuteNonQuery()

                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '++++++++++++++++++ CODE FOR ANTIMONEY LAUNDERING PAYMENTS AND ITEMS+++++++++++++++++++++++++
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-Select only relevant Data")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "Insert Data to ODAS REMMITANCES")
                cmd.CommandText = "DELETE from [#Temp_ODAS_REMMITANCE_Temp] where [METHOD] not like '%103'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [#Temp_ODAS_REMMITANCE_Temp] where [INWARDOUTWARD]='I'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from [#Temp_ODAS_REMMITANCE_Temp] where  [EM00KEY1] like '//%'"
                cmd.ExecuteNonQuery()
                'RICHTIGE STAMM NR DEFINIEREN BASIEREND AUF ACCOUNT NR.
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID based on Client Account")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID based on Client Account")
                cmd.CommandText = "UPDATE A SET A.[ORDERCUSTID]=B.[ClientNo] from  [#Temp_ODAS_REMMITANCE_Temp] A INNER JOIN [CUSTOMER_ACCOUNTS] B ON A.[Client Account]=B.[Client Account] where A.[Client Account] is not NULL"
                cmd.ExecuteNonQuery()
                'RICHTIGE STAMM NR DEFINIEREN
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID-Set Customer ID to 678... if OORDERCUSTID like 670")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID-Set Customer ID to 678... if OORDERCUSTID like 670")
                cmd.CommandText = "UPDATE [#Temp_ODAS_REMMITANCE_Temp] SET [ORDERCUSTID]='678' + SUBSTRING([Client Account],7,5) where [ORDERCUSTID] like '670%'"
                cmd.ExecuteNonQuery()
                'STAMM NR DEFINIEREN wenn STAMMNR nur '678' ist basierent auf Customer Name
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID if Customer ID=678")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID if Customer ID=678")
                cmd.CommandText = "UPDATE [#Temp_ODAS_REMMITANCE_Temp] SET  [ORDERCUSTID]=(Select   [ClientNo] from   [CUSTOMER_INFO] where UPPER([#Temp_ODAS_REMMITANCE_Temp].[ORDERCUSTNAME])=[CUSTOMER_INFO].[English Name]) where [ORDERCUSTID]='678'"
                cmd.ExecuteNonQuery()
                'STAMM NR DEFINIEREN wenn STAMMNR NULL ist basierent auf Customer Name
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID if CustomerID is NULL")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "ANTIMONEY LAUNDERING PAYMENTS-Define correct Customer ID if CustomerID is NULL")
                cmd.CommandText = "UPDATE [#Temp_ODAS_REMMITANCE_Temp] SET   [ORDERCUSTID]=(Select   [ClientNo] from   [CUSTOMER_INFO] where UPPER([#Temp_ODAS_REMMITANCE_Temp].[ORDERCUSTNAME])=[CUSTOMER_INFO].[English Name]) where [ORDERCUSTID] is NULL"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "DELETE FROM  [#Temp_ODAS_REMMITANCE_Temp] WHERE [ORDERCUSTID] like '6788%'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM  [#Temp_ODAS_REMMITANCE_Temp] WHERE [ORDERCUSTID] is NULL"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE from  [#Temp_ODAS_REMMITANCE_Temp] where   [ORDERCUSTID] in (Select   [ClientNo] from   [CUSTOMER_INFO] where  [ClientNo]='67803022')"
                cmd.ExecuteNonQuery()
                '++++++++++AUSWAHL DER ZAHLUNGEN (MINDESTENS 5 STÜCK pro Tag pro Kunde)++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-INSERT TO TABLE: PAYMENTS ITEMS")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "ANTIMONEY LAUNDERING PAYMENTS-INSERT TO TABLE: PAYMENTS ITEMS")
                QueryText = "SELECT  [TRANSACTIONDATE],  [ORDERCUSTID]  from   [#Temp_ODAS_REMMITANCE_Temp] GROUP BY [TRANSACTIONDATE],  [ORDERCUSTID]"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim rd As Date = dt.Rows.Item(i).Item("TRANSACTIONDATE").ToString
                    Dim rdsql As String = rd.ToString("yyyy-MM-dd")
                    QueryText = "Select * from [#Temp_ODAS_REMMITANCE_Temp] where [ORDERCUSTID] in (Select [ORDERCUSTID] from   [#Temp_ODAS_REMMITANCE_Temp] where   [TRANSACTIONDATE]='" & rdsql & "' and [ORDERCUSTID]='" & dt.Rows.Item(i).Item("ORDERCUSTID") & "' GROUP BY [ORDERCUSTID] HAVING Count([ID])>=5) and [TRANSACTIONDATE]='" & rdsql & "' and [ORDERCUSTID]='" & dt.Rows.Item(i).Item("ORDERCUSTID") & "'"
                    da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    For y = 0 To dt1.Rows.Count - 1
                        If dt1.Rows.Item(y).Item("EM00KEY0").ToString <> "" Then
                            cmd.CommandText = "INSERT INTO [ANTIMONEY_LAUND_PAYMENTS_ITEMS] ([ACWITHINSTBR],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTADR1],[BENEFCUSTADR2],[BENEFCUSTBR],[BENEFCUSTID],[BENEFCUSTNAME],[Client Account],[CURRENCYCODE],[Deal Amount],[Deal Amount Euro],[DETOFCHARGE],[EM00KEY0], [EM00KEY1],[EM00KEY2],[HANDLINGFEE],[HOLDFUNC],[INWARDOUTWARD],[METHOD],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[ORDERCUSTBR],[ORDERCUSTID],[ORDERCUSTNAME],[OURTRANREFNO],[RECEIVERBRANCH],[RECEIVERID] ,[RECEIVERNAME],[RECEIVERSWIFT],[RECRCORRBR],[RECRCORRID],[RECRCORRNAME],[RECRCORRSWIFT],[SENDERCORBKID],[SENDERCORRBR], [SENDERCORRNAME],[SENDERCORRST],[SETOREINFO],[SWIFTINREF],[TRANSACTIONDATE],[VALUEDATE]) SELECT [ACWITHINSTBR],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTADR1],[BENEFCUSTADR2],[BENEFCUSTBR],[BENEFCUSTID],[BENEFCUSTNAME],[Client Account],[CURRENCYCODE],[Deal Amount],[Deal Amount Euro],[DETOFCHARGE],[EM00KEY0], [EM00KEY1],[EM00KEY2],[HANDLINGFEE],[HOLDFUNC],[INWARDOUTWARD],[METHOD],[ORDERCUSTADD1],[ORDERCUSTADD2],[ORDERCUSTADD3],[ORDERCUSTBR],[ORDERCUSTID],[ORDERCUSTNAME],[OURTRANREFNO],[RECEIVERBRANCH],[RECEIVERID] ,[RECEIVERNAME],[RECEIVERSWIFT],[RECRCORRBR],[RECRCORRID],[RECRCORRNAME],[RECRCORRSWIFT],[SENDERCORBKID],[SENDERCORRBR], [SENDERCORRNAME],[SENDERCORRST],[SETOREINFO],[SWIFTINREF],[TRANSACTIONDATE],[VALUEDATE] FROM [#Temp_ODAS_REMMITANCE_Temp] where  [EM00KEY0]='" & dt1.Rows.Item(y).Item("EM00KEY0") & "'"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Next
                cmd.CommandText = "DELETE  FROM [ANTIMONEY_LAUND_PAYMENTS_ITEMS] where [ID] not in (Select Min([ID]) from [ANTIMONEY_LAUND_PAYMENTS_ITEMS] group by [EM00KEY0])"
                cmd.ExecuteNonQuery()
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '++++++++++AUSWAHL DER ZAHLUNGEN (Insgesamt AB 10000 EURO pro Tag und Pro Kunde)++++++++++++
                'SplashScreenManager.Default.SetWaitFormCaption("ANTIMONEY LAUNDERING PAYMENTS-INSERT TO TABLE: PAYMENTS AMOUNTS")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "ANTIMONEY LAUNDERING PAYMENTS-INSERT TO TABLE: PAYMENTS AMOUNTS")
                QueryText = "SELECT  [TRANSACTIONDATE],  [ORDERCUSTID]  from   [#Temp_ODAS_REMMITANCE_Temp] GROUP BY [TRANSACTIONDATE],  [ORDERCUSTID]"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim rd As Date = dt.Rows.Item(i).Item("TRANSACTIONDATE").ToString
                    Dim rdsql As String = rd.ToString("yyyy-MM-dd")
                    QueryText = "Select * from [#Temp_ODAS_REMMITANCE_Temp] where [ORDERCUSTID] in (Select [ORDERCUSTID] from   [#Temp_ODAS_REMMITANCE_Temp] where   [TRANSACTIONDATE]='" & rdsql & "' and [ORDERCUSTID]='" & dt.Rows.Item(i).Item("ORDERCUSTID") & "' GROUP BY [ORDERCUSTID] HAVING Sum([Deal Amount Euro])>=10000) and [TRANSACTIONDATE]='" & rdsql & "' and [ORDERCUSTID]='" & dt.Rows.Item(i).Item("ORDERCUSTID") & "'"
                    da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt1 = New DataTable()
                    da1.Fill(dt1)
                    For y = 0 To dt1.Rows.Count - 1
                        If dt1.Rows.Item(y).Item("EM00KEY0").ToString <> "" Then
                            cmd.CommandText = "INSERT INTO [ANTIMONEY_LAUND_PAYMENTS_AMOUNTS] ([EM00KEY0],[Client Account],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERBRANCH],[RECEIVERID],[RECEIVERNAME],[RECEIVERSWIFT],[SENDERCORBKID],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTBR],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTADR1],[BENEFCUSTADR2],[DETOFCHARGE],[SETOREINFO],[CURRENCYCODE],[TRANSACTIONDATE],[VALUEDATE],[Deal Amount],[EXCHANGE_RATE],[Deal Amount Euro],[HANDLINGFEE],[ORDERCUSTBR],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTADD1],[ORDERCUSTADD2],[HOLDFUNC],[ORDERCUSTADD3],[SWIFTINREF]) SELECT [EM00KEY0],[Client Account],[EM00KEY1],[EM00KEY2],[OURTRANREFNO],[INWARDOUTWARD],[METHOD],[RECEIVERBRANCH],[RECEIVERID],[RECEIVERNAME],[RECEIVERSWIFT],[SENDERCORBKID],[SENDERCORRNAME],[SENDERCORRBR],[SENDERCORRST],[RECRCORRID],[RECRCORRNAME],[RECRCORRBR],[RECRCORRSWIFT],[ACWITHINSTID],[ACWITHINSTNA],[ACWITHINSTBR],[ACWITHINSTST],[BENEFACNO],[BENEFCUSTBR],[BENEFCUSTID],[BENEFCUSTNAME],[BENEFCUSTADR1],[BENEFCUSTADR2],[DETOFCHARGE],[SETOREINFO],[CURRENCYCODE],[TRANSACTIONDATE],[VALUEDATE],[Deal Amount],[EXCHANGE_RATE],[Deal Amount Euro],[HANDLINGFEE],[ORDERCUSTBR],[ORDERCUSTID],[ORDERCUSTNAME],[ORDERCUSTADD1],[ORDERCUSTADD2],[HOLDFUNC],[ORDERCUSTADD3],[SWIFTINREF] FROM [#Temp_ODAS_REMMITANCE_Temp] where  [EM00KEY0]='" & dt1.Rows.Item(y).Item("EM00KEY0") & "'"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Next
                cmd.CommandText = "DELETE  FROM [ANTIMONEY_LAUND_PAYMENTS_AMOUNTS] where [ID] not in (Select Min([ID]) from [ANTIMONEY_LAUND_PAYMENTS_AMOUNTS] group by [EM00KEY0])"
                cmd.ExecuteNonQuery()
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                'SplashScreenManager.Default.SetWaitFormCaption("DROP TABLE #Temp_ODAS_REMMITANCE_Temp")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(75, "DROP TABLE #Temp_ODAS_REMMITANCE_Temp")
                cmd.CommandText = "DROP TABLE [#Temp_ODAS_REMMITANCE_Temp]"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete Text File: " & ODAS_REMMITANCE_PAY_FILE)
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(80, "Delete Text File: " & ODAS_REMMITANCE_PAY_FILE)
                File.Delete(ODAS_REMMITANCE_PAY_FILE)
                'SplashScreenManager.Default.SetWaitFormCaption("ODAS REMMITANCE IMPORT finished")
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(90, "ODAS REMMITANCE IMPORT finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwOdasRemmitancePayDirectory.ReportProgress(30, "Unable to Import ODAS REMMITANCE! File does not exist!")
                MessageBox.Show("Unable to Import ODAS REMMITANCE! File does not exist!", "ODAS REMMITANCE IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwOdasRemmitancePayDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try

    End Sub

    Private Sub BgwOdasRemmitancePayDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOdasRemmitancePayDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','ODAS REMMITANCE IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ODAS REMMITANCE IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','ODAS REMMITANCE IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ODAS REMMITANCE IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwOdasRemmitancePayDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOdasRemmitancePayDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwOdasRemmitancePayDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT GMPS PAYMENTS"
    Private Sub BgwGMPSPayDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwGMPSPayDirectory.DoWork
        OpenSqlConnections()
        cmd.CommandTimeout = 50000

        Try
            If dir.Count > 0 Then
                For i = 0 To dir.Count - 1
                    GMPS_PAY_FILE = dir.Item(i).ToString

                    If File.Exists(GMPS_PAY_FILE) = True Then
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import with File: " & GMPS_PAY_FILE)
                        Me.BgwGMPSPayDirectory.ReportProgress(40, "Start Import with File: " & GMPS_PAY_FILE)

                        EXCELL = CreateObject("Excel.Application")
                        xlWorkBook = EXCELL.Workbooks.Open(GMPS_PAY_FILE)
                        xlWorksheet1 = xlWorkBook.Worksheets(1)
                        EXCELL.Visible = False

                        'IMPORT INCOMING PAYMENTS-CUSTOMER or BANK TRANSFER
                        If xlWorksheet1.Range("A1").Value = "Bank Transfer" Then
                            'SplashScreenManager.Default.SetWaitFormCaption("Define GMPS PAYMENT INCOMING as :" & xlWorksheet1.Range("A1").Value)
                            Me.BgwGMPSPayDirectory.ReportProgress(40, "Define GMPS PAYMENT INCOMING as :" & xlWorksheet1.Range("A1").Value)
                            'Rows delete
                            xlWorksheet1.Rows("1:2").delete()

                            xlWorksheet1.Range("A1").Value = "IncomingDate"
                            xlWorksheet1.Range("B1").Value = "ValueDate"
                            xlWorksheet1.Range("C1").Value = "OurReference"
                            xlWorksheet1.Range("D1").Value = "MessageSender"
                            xlWorksheet1.Range("E1").Value = "ReferenceNo"
                            xlWorksheet1.Range("F1").Value = "Currency"
                            xlWorksheet1.Range("G1").Value = "Amount"
                            xlWorksheet1.Range("H1").Value = "OriginalOrderingCustomer"
                            xlWorksheet1.Range("I1").Value = "OriginalOrderingInstitution"
                            xlWorksheet1.Range("J1").Value = "AccountOfInstitution"
                            xlWorksheet1.Range("K1").Value = "BeneficiaryBank"
                            xlWorksheet1.Range("L1").Value = "ReceiverBICofConstructMessage"
                            xlWorksheet1.Range("M1").Value = "PAYMENT_CODE"
                            xlWorksheet1.Range("N1").Value = "SenderToReceiverInformation"
                            xlWorksheet1.Range("O1").Value = "ProcessedBy"



                            EXCELL.DisplayAlerts = False
                            xlWorkBook.SaveAs(GMPS_PAY_FILE, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                            EXCELL.DisplayAlerts = True
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


                            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                            Dim ParameterStatus1 As String = cmd.ExecuteScalar
                            If ParameterStatus1 = "Y" Then
                                QueryText = "  Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('Incoming_Bank_Transfer') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS'))) and Status in ('Y') order by SQL_Float_1 asc"
                                da = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt = New System.Data.DataTable()
                                da.Fill(dt)
                                For i1 = 0 To dt.Rows.Count - 1
                                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<GMPS_PAY_FILE>", GMPS_PAY_FILE)
                                    cmd.CommandText = SqlCommandText1
                                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        Me.BgwGMPSPayDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        cmd.ExecuteNonQuery()
                                    End If
                                Next
                            Else
                                'SplashScreenManager.CloseForm(False)
                                Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!")
                                MessageBox.Show("Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                Return

                            End If

                            'SplashScreenManager.Default.SetWaitFormCaption("Delete GMPS File: " & GMPS_PAY_FILE)
                            Me.BgwGMPSPayDirectory.ReportProgress(80, "Delete GMPS File: " & GMPS_PAY_FILE)
                            File.Delete(GMPS_PAY_FILE)
                            'SplashScreenManager.Default.SetWaitFormCaption("GMPS PAYMENTS IMPORT INCOMING finished")
                            Me.BgwGMPSPayDirectory.ReportProgress(90, "GMPS PAYMENTS IMPORT INCOMING finished")
                            'Save the last imported Payment File
                            Me.MANUAL_IMPORTSBindingSource.EndEdit()
                            Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)

                        ElseIf xlWorksheet1.Range("A1").Value = "Customer Transfer" Then
                            'SplashScreenManager.Default.SetWaitFormCaption("Define GMPS PAYMENT INCOMING as :" & xlWorksheet1.Range("A1").Value)
                            Me.BgwGMPSPayDirectory.ReportProgress(40, "Define GMPS PAYMENT INCOMING as :" & xlWorksheet1.Range("A1").Value)
                            'Rows delete
                            xlWorksheet1.Rows("1:2").delete()

                            xlWorksheet1.Range("A1").Value = "IncomingDate"
                            xlWorksheet1.Range("B1").Value = "ValueDate"
                            xlWorksheet1.Range("C1").Value = "OurReference"
                            xlWorksheet1.Range("D1").Value = "MessageSender"
                            xlWorksheet1.Range("E1").Value = "ReferenceNo"
                            xlWorksheet1.Range("F1").Value = "Currency"
                            xlWorksheet1.Range("G1").Value = "Amount"
                            xlWorksheet1.Range("H1").Value = "OriginalOrderingCustomer"
                            xlWorksheet1.Range("I1").Value = "OriginalOrderingInstitution"
                            xlWorksheet1.Range("J1").Value = "AccountOfInstitution"
                            xlWorksheet1.Range("K1").Value = "BeneficiaryCustomer" '
                            xlWorksheet1.Range("L1").Value = "DetailsOfCharges" '
                            xlWorksheet1.Range("M1").Value = "Commission"
                            xlWorksheet1.Range("N1").Value = "ReceiverBICofConstructMessage" '
                            xlWorksheet1.Range("O1").Value = "PAYMENT_CODE" '
                            xlWorksheet1.Range("P1").Value = "ProcessedBy"
                            xlWorksheet1.Range("Q1").Value = "PrivateFlag"
                            xlWorksheet1.Range("R1").Value = "RemittanceInformation"
                            xlWorksheet1.Range("S1").Value = "SenderToReceiverInformation"

                            EXCELL.DisplayAlerts = False
                            xlWorkBook.SaveAs(GMPS_PAY_FILE, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                            EXCELL.DisplayAlerts = True
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


                            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                            Dim ParameterStatus2 As String = cmd.ExecuteScalar
                            If ParameterStatus2 = "Y" Then
                                QueryText = "Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('Incoming_Customer_Transfer') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS'))) and Status in ('Y') order by SQL_Float_1 asc"
                                da = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt = New System.Data.DataTable()
                                da.Fill(dt)
                                For i1 = 0 To dt.Rows.Count - 1
                                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<GMPS_PAY_FILE>", GMPS_PAY_FILE)
                                    cmd.CommandText = SqlCommandText1
                                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        Me.BgwGMPSPayDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        cmd.ExecuteNonQuery()
                                    End If
                                Next
                            Else
                                'SplashScreenManager.CloseForm(False)
                                Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!")
                                MessageBox.Show("Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                Return

                            End If


                            'SplashScreenManager.Default.SetWaitFormCaption("Delete GMPS File: " & GMPS_PAY_FILE)
                            Me.BgwGMPSPayDirectory.ReportProgress(80, "Delete GMPS File: " & GMPS_PAY_FILE)
                            File.Delete(GMPS_PAY_FILE)
                            'SplashScreenManager.Default.SetWaitFormCaption("GMPS PAYMENTS IMPORT INCOMING finished")
                            Me.BgwGMPSPayDirectory.ReportProgress(90, "GMPS PAYMENTS IMPORT INCOMING finished")
                            'Save the last imported Payment File
                            Me.MANUAL_IMPORTSBindingSource.EndEdit()
                            Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)

                        ElseIf xlWorksheet1.Range("A1").Value.ToString.StartsWith("Inward Remittance Report") = True Then
                            'SplashScreenManager.Default.SetWaitFormCaption("Define GMPS PAYMENT INCOMING as :" & xlWorksheet1.Range("A1").Value)
                            Me.BgwGMPSPayDirectory.ReportProgress(40, "Define GMPS PAYMENT INCOMING as :" & xlWorksheet1.Range("A1").Value)
                            'Rows delete
                            xlWorksheet1.Rows("1:1").delete()

                            xlWorksheet1.Range("A1").Value = "Message_Type"
                            xlWorksheet1.Range("B1").Value = "Our_Reference"
                            xlWorksheet1.Range("C1").Value = "Sender_BIC"
                            xlWorksheet1.Range("D1").Value = "Receiver_BIC"
                            xlWorksheet1.Range("E1").Value = "Incoming_Date"
                            xlWorksheet1.Range("F1").Value = "Currency"
                            xlWorksheet1.Range("G1").Value = "Amount"
                            xlWorksheet1.Range("H1").Value = "Value_Date"
                            xlWorksheet1.Range("I1").Value = "Reference_20"
                            xlWorksheet1.Range("J1").Value = "Reference_21"
                            xlWorksheet1.Range("K1").Value = "OrderingCustomersAccNo"
                            xlWorksheet1.Range("L1").Value = "OrderingCustomer"
                            xlWorksheet1.Range("M1").Value = "OrderingInstitutionsAccNo"
                            xlWorksheet1.Range("N1").Value = "OrderingInstitutionBIC"
                            xlWorksheet1.Range("O1").Value = "BeneficiaryCustomersAccNo"
                            xlWorksheet1.Range("P1").Value = "BeneficiaryCustomer"
                            xlWorksheet1.Range("Q1").Value = "DetailsOfCharges"
                            xlWorksheet1.Range("R1").Value = "BeneficiaryBankAccNo"
                            xlWorksheet1.Range("S1").Value = "BeneficiaryBankBIC"
                            xlWorksheet1.Range("T1").Value = "ProcessingQueue"
                            xlWorksheet1.Range("U1").Value = "ACK_State"
                            xlWorksheet1.Range("V1").Value = "ProcessedBy"
                            xlWorksheet1.Range("W1").Value = "PrivateFlag"
                            xlWorksheet1.Range("X1").Value = "RemittanceInformation"
                            xlWorksheet1.Range("Y1").Value = "SenderToReceiverInformation"

                            xlWorksheet1.Name = "INWARD_REMITANCE_GMPS"

                            EXCELL.DisplayAlerts = False
                            xlWorkBook.SaveAs(GMPS_PAY_FILE, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                            EXCELL.DisplayAlerts = True
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

                            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                            Dim ParameterStatus3 As String = cmd.ExecuteScalar
                            If ParameterStatus3 = "Y" Then
                                QueryText = "  Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('Inward_Remittance') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS'))) and Status in ('Y') order by SQL_Float_1 asc"
                                da = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt = New System.Data.DataTable()
                                da.Fill(dt)
                                For i1 = 0 To dt.Rows.Count - 1
                                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<GMPS_PAY_FILE>", GMPS_PAY_FILE)
                                    cmd.CommandText = SqlCommandText1
                                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        Me.BgwGMPSPayDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        cmd.ExecuteNonQuery()
                                    End If
                                Next
                            Else
                                'SplashScreenManager.CloseForm(False)
                                Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!")
                                MessageBox.Show("Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                Return

                            End If

                            'SplashScreenManager.Default.SetWaitFormCaption("Delete GMPS File: " & GMPS_PAY_FILE)
                            Me.BgwGMPSPayDirectory.ReportProgress(80, "Delete GMPS File: " & GMPS_PAY_FILE)
                            File.Delete(GMPS_PAY_FILE)
                            'SplashScreenManager.Default.SetWaitFormCaption("GMPS INWARD REMMITANCE Import finished")
                            Me.BgwGMPSPayDirectory.ReportProgress(90, "GMPS INWARD REMMITANCE Import finished")
                            'Save the last imported Payment File
                            Me.MANUAL_IMPORTSBindingSource.EndEdit()
                            Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)



                            'OUTGOINGS
                        ElseIf xlWorksheet1.Range("A1").Value.ToString.StartsWith("Outward Remittance Report") = True Then
                            'SplashScreenManager.Default.SetWaitFormCaption("Define GMPS PAYMENT OUTGOING as :" & xlWorksheet1.Range("A1").Value)
                            Me.BgwGMPSPayDirectory.ReportProgress(90, "Define GMPS PAYMENT OUTGOING as :" & xlWorksheet1.Range("A1").Value)
                            'Rows delete
                            xlWorksheet1.Rows("1:1").delete()

                            'Add by WYQ; Time:01.04.2022; Content: the imported file add one column "Send Type"   of  "Outward Remittance Report"， Delete this  column
                            'xlWorksheet1.Columns(2).Delete()
                            'Old File
                            If xlWorksheet1.Range("B1").Value = "Register Date" Then
                                xlWorksheet1.Columns("B:B").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                                xlWorksheet1.Range("A1").Value = "MTTYPE"
                                xlWorksheet1.Range("B1").Value = "SendType"
                                xlWorksheet1.Range("C1").Value = "RegisterDate"
                                xlWorksheet1.Range("D1").Value = "SenderReference"
                                xlWorksheet1.Range("E1").Value = "OurReference"
                                xlWorksheet1.Range("H1").Value = "ValueDate"
                                xlWorksheet1.Range("I1").Value = "SenderBIC"
                                xlWorksheet1.Range("J1").Value = "Sender52BIC"
                                xlWorksheet1.Range("K1").Value = "ReceivingBankBIC"
                                xlWorksheet1.Range("L1").Value = "ReceivingBankCountryCode"
                                xlWorksheet1.Range("M1").Value = "TransactionType"
                                xlWorksheet1.Range("N1").Value = "OrderingCustomersAccountServicingInstitution"
                                xlWorksheet1.Range("O1").Value = "OrderingCustomersAccNo"
                                xlWorksheet1.Range("P1").Value = "OrderingCustomer"
                                xlWorksheet1.Range("Q1").Value = "IntermediaryInstitutionBIC"
                                xlWorksheet1.Range("R1").Value = "IntermediaryInstitutionAccNo"
                                xlWorksheet1.Range("S1").Value = "IntermediaryInstitutionName"
                                xlWorksheet1.Range("T1").Value = "AccountPayeeBIC"
                                xlWorksheet1.Range("U1").Value = "AccountOfInstitutionAccNo"
                                xlWorksheet1.Range("V1").Value = "AccountPayeeNameAddress"
                                xlWorksheet1.Range("W1").Value = "BeneficiaryBankBIC"
                                xlWorksheet1.Range("X1").Value = "BeneficiaryBankAccNo"
                                xlWorksheet1.Range("Y1").Value = "BeneficiaryBankName"
                                xlWorksheet1.Range("Z1").Value = "BeneficiaryCustomerBIC"
                                xlWorksheet1.Range("AA1").Value = "BeneficiaryCustomerAccNo"
                                xlWorksheet1.Range("AB1").Value = "BeneficiaryCustomerNameAddress"
                                xlWorksheet1.Range("AC1").Value = "DetailsOfCharges"
                                xlWorksheet1.Range("AD1").Value = "RemittanceInformation"
                                xlWorksheet1.Range("AE1").Value = "SenderToReceiverInformation"
                                xlWorksheet1.Range("AF1").Value = "PayStartTime"
                                xlWorksheet1.Range("AG1").Value = "DebitTransactionsSigns"
                                xlWorksheet1.Range("AH1").Value = "ProcessingQueue"
                                xlWorksheet1.Range("AJ1").Value = "ACK_State"
                                xlWorksheet1.Range("AK1").Value = "ProcessedBy"
                                xlWorksheet1.Range("AL1").Value = "PrivateFlag"
                            ElseIf xlWorksheet1.Range("B1").Value = "Send Type" Then 'New File with SendType
                                xlWorksheet1.Range("A1").Value = "MTTYPE"
                                xlWorksheet1.Range("B1").Value = "SendType"
                                xlWorksheet1.Range("C1").Value = "RegisterDate"
                                xlWorksheet1.Range("D1").Value = "SenderReference"
                                xlWorksheet1.Range("E1").Value = "OurReference"
                                xlWorksheet1.Range("H1").Value = "ValueDate"
                                xlWorksheet1.Range("I1").Value = "SenderBIC"
                                xlWorksheet1.Range("J1").Value = "Sender52BIC"
                                xlWorksheet1.Range("K1").Value = "ReceivingBankBIC"
                                xlWorksheet1.Range("L1").Value = "ReceivingBankCountryCode"
                                xlWorksheet1.Range("M1").Value = "TransactionType"
                                xlWorksheet1.Range("N1").Value = "OrderingCustomersAccountServicingInstitution"
                                xlWorksheet1.Range("O1").Value = "OrderingCustomersAccNo"
                                xlWorksheet1.Range("P1").Value = "OrderingCustomer"
                                xlWorksheet1.Range("Q1").Value = "IntermediaryInstitutionBIC"
                                xlWorksheet1.Range("R1").Value = "IntermediaryInstitutionAccNo"
                                xlWorksheet1.Range("S1").Value = "IntermediaryInstitutionName"
                                xlWorksheet1.Range("T1").Value = "AccountPayeeBIC"
                                xlWorksheet1.Range("U1").Value = "AccountOfInstitutionAccNo"
                                xlWorksheet1.Range("V1").Value = "AccountPayeeNameAddress"
                                xlWorksheet1.Range("W1").Value = "BeneficiaryBankBIC"
                                xlWorksheet1.Range("X1").Value = "BeneficiaryBankAccNo"
                                xlWorksheet1.Range("Y1").Value = "BeneficiaryBankName"
                                xlWorksheet1.Range("Z1").Value = "BeneficiaryCustomerBIC"
                                xlWorksheet1.Range("AA1").Value = "BeneficiaryCustomerAccNo"
                                xlWorksheet1.Range("AB1").Value = "BeneficiaryCustomerNameAddress"
                                xlWorksheet1.Range("AC1").Value = "DetailsOfCharges"
                                xlWorksheet1.Range("AD1").Value = "RemittanceInformation"
                                xlWorksheet1.Range("AE1").Value = "SenderToReceiverInformation"
                                xlWorksheet1.Range("AF1").Value = "PayStartTime"
                                xlWorksheet1.Range("AG1").Value = "DebitTransactionsSigns"
                                xlWorksheet1.Range("AH1").Value = "ProcessingQueue"
                                xlWorksheet1.Range("AJ1").Value = "ACK_State"
                                xlWorksheet1.Range("AK1").Value = "ProcessedBy"
                                xlWorksheet1.Range("AL1").Value = "PrivateFlag"
                            End If


                            xlWorksheet1.Name = "OUTGOING_PAYMENTS"



                            EXCELL.DisplayAlerts = False
                            xlWorkBook.SaveAs(GMPS_PAY_FILE, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                            EXCELL.DisplayAlerts = True
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

                            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                            Dim ParameterStatus4 As String = cmd.ExecuteScalar
                            If ParameterStatus4 = "Y" Then
                                QueryText = "  Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('Outward_Remittance') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS'))) and Status in ('Y') order by SQL_Float_1 asc"
                                da = New SqlDataAdapter(QueryText.Trim(), conn)
                                dt = New System.Data.DataTable()
                                da.Fill(dt)
                                For i1 = 0 To dt.Rows.Count - 1
                                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<GMPS_PAY_FILE>", GMPS_PAY_FILE)
                                    cmd.CommandText = SqlCommandText1
                                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        Me.BgwGMPSPayDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                                        cmd.ExecuteNonQuery()
                                    End If
                                Next
                            Else
                                'SplashScreenManager.CloseForm(False)
                                Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!")
                                MessageBox.Show("Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                Return

                            End If


                            'SplashScreenManager.Default.SetWaitFormCaption("Delete GMPS File: " & GMPS_PAY_FILE)
                            Me.BgwGMPSPayDirectory.ReportProgress(80, "Delete GMPS File: " & GMPS_PAY_FILE)
                            File.Delete(GMPS_PAY_FILE)
                            'SplashScreenManager.Default.SetWaitFormCaption("GMPS PAYMENTS IMPORT OUTGOING finished")
                            Me.BgwGMPSPayDirectory.ReportProgress(90, "GMPS PAYMENTS IMPORT OUTGOING finished")
                            'Save the last imported Payment File
                            Me.MANUAL_IMPORTSBindingSource.EndEdit()
                            Me.MANUAL_IMPORTSTableAdapter.Update(Me.EDPDataSet.MANUAL_IMPORTS)
                        Else
                            'SplashScreenManager.CloseForm(False)
                            Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to Import GMPS PAYMENT FILE! Fileformat is wrong!")
                            MessageBox.Show("Unable to Import GMPS PAYMENT FILE! Fileformat is wrong!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        'SplashScreenManager.CloseForm(False)
                        Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to Import GMPS PAYMENT FILE! File does not exist!")
                        MessageBox.Show("Unable to Import GMPS PAYMENT FILE! File does not exist!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub

                    End If


                Next

            End If


            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
            Dim ParameterStatus As String = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "  Select * from SQL_PARAMETER_DETAILS_THIRD where Id_SQL_Parameters_Details in (Select ID from [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('Update_Payment_Tables') and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_GMPS_PAYMENTS'))) and Status in ('Y') order by SQL_Float_1 asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i1 = 0 To dt.Rows.Count - 1
                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<GMPS_PAY_FILE>", GMPS_PAY_FILE)
                    cmd.CommandText = SqlCommandText1
                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                        Me.BgwGMPSPayDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwGMPSPayDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!")
                MessageBox.Show("Unable to execute Import Procedure:IMPORT_GMPS_PAYMENTS! Parameter Status is Invalid!!", "GMPS PAYMENT IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If


            'FINISH
            'SplashScreenManager.Default.SetWaitFormCaption("GMPS Payments Import finished!")
            Me.BgwGMPSPayDirectory.ReportProgress(35, "GMPS Payments Import finished!")

            CloseSqlConnections()
        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwGMPSPayDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try

        CloseSqlConnections()


    End Sub

    Private Sub BgwGMPSPayDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwGMPSPayDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','GMPS PAYMENTS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "GMPS PAYMENTS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','GMPS PAYMENTS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "GMPS PAYMENTS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwGMPSPayDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwGMPSPayDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwGMPSPayDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT ECB RATES"
    Private Sub BgwEcbRatesDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwEcbRatesDirectory.DoWork
        Dim outArray(1, 1) As String
        Dim rd As Date
        Dim rdsql As String = Nothing
        Dim currStr As String = Nothing
        Dim currVstr As String = Nothing
        Dim rate As Double = 0
        Dim ECB_RATES_XML_FILE As String = Me.ECB_RATES_FileDirectoryImport

        Try
            OpenSqlConnections()

            Dim xmlreader As New Xml.XmlTextReader(ECB_RATES_XML_FILE)
            'SplashScreenManager.Default.SetWaitFormCaption("Start downloading ECB Rates from : " & ECB_RATES_XML_FILE)
            Me.BgwEcbRatesDirectory.ReportProgress(40, "Start downloading ECB Rates from : " & ECB_RATES_XML_FILE)

            With xmlreader
                While .Read
                    If .Name <> "" Then

                        If .Name = "gesmes:name" Then currStr = .ReadString()

                        For i As Integer = 0 To .AttributeCount - 1
                            If .Name = "Cube" Then

                                ' Prüfen, ob ein Attribut, dann Wert lesen
                                If .AttributeCount = 1 Then
                                    .MoveToAttribute("time")
                                    rd = DateTime.Parse(.Value).ToShortDateString
                                    rdsql = rd.ToString("yyyMMdd")
                                    'SplashScreenManager.Default.SetWaitFormCaption("ECB Rates Date: " & rd)
                                    Me.BgwEcbRatesDirectory.ReportProgress(40, "ECB Rates Date : " & rd)
                                    cmd.CommandText = "DELETE FROM [EXCHANGE RATES ECB] where [EXCHANGE RATE DATE]='" & rdsql & "'"
                                    cmd.ExecuteNonQuery()

                                End If

                                ' Prüfen, ob zwei Attribute, dann Wechselkurs lesen
                                If .AttributeCount = 2 Then
                                    currStr = "" : currVstr = ""
                                    .MoveToAttribute("currency")
                                    currStr = .Value
                                    .MoveToAttribute("rate")
                                    currVstr = .Value.Replace(".", ",")
                                    rate = currVstr
                                    Console.WriteLine(currStr & "  " & rate)
                                    'SplashScreenManager.Default.SetWaitFormCaption(currStr & "  " & rate)
                                    Me.BgwEcbRatesDirectory.ReportProgress(40, currStr & "  " & rate)

                                    'SplashScreenManager.Default.SetWaitFormCaption("Import ECB Exchange Rates in Table")
                                    Me.BgwEcbRatesDirectory.ReportProgress(40, "Import ECB Exchange Rates in Table")
                                    cmd.CommandText = "INSERT INTO [EXCHANGE RATES ECB]([CURRENCY CODE],[CURRENCY RATE],[EXCHANGE RATE DATE]) Values('" & currStr & "'," & Str(rate) & ",'" & rdsql & "')"
                                    cmd.ExecuteNonQuery()

                                    'RATE NAME DEFINE
                                    'SplashScreenManager.Default.SetWaitFormCaption("Define Currency Names in Table")
                                    Me.BgwEcbRatesDirectory.ReportProgress(40, "Define Currency Names in Table")
                                    cmd.CommandText = "UPDATE A SET A.[CURRENCY NAME]=B.[CURRENCY NAME] from [EXCHANGE RATES ECB] A INNER JOIN [CURRENCIES] B on A.[CURRENCY CODE]=B.[CURRENCY CODE] where A.[CURRENCY NAME] is NULL"
                                    cmd.ExecuteNonQuery()


                                End If

                            End If

                        Next
                    End If
                End While
            End With

            'SplashScreenManager.Default.SetWaitFormCaption("ECB Rates import finished")
            Me.BgwEcbRatesDirectory.ReportProgress(40, "ECB Rates import finished")

            CloseSqlConnections()

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwEcbRatesDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try

    End Sub

    Private Sub BgwEcbRatesDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwEcbRatesDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','ECB RATES IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ECB RATES IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','ECB RATES IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ECB RATES IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwEcbRatesDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwEcbRatesDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwEcbRatesDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "MULTIBANK KONVERTER KONTOINHABER"
    Private Sub BgwMultibankKonverterKontoinhaberDirectoty_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwMultibankKonverterKontoinhaberDirectoty.DoWork
        Try
            If File.Exists(MULTIBANK_KONVERTER_KONTOINHABER_FILE) = True Then
                'SplashScreenManager.Default.SetWaitFormCaption("Start reformating the related Excel File")
                EXCELL = CreateObject("Excel.Application")
                xlWorkBook = EXCELL.Workbooks.Open(MULTIBANK_KONVERTER_KONTOINHABER_FILE)
                xlWorksheet1 = xlWorkBook.Worksheets("Sheet1")
                EXCELL.Visible = False
                xlWorksheet1.Range("A1").Value = "KontoNr"
                xlWorksheet1.Range("D1").Value = "GueltBeginn"
                xlWorksheet1.Range("E1").Value = "GueltEnde"
                xlWorksheet1.Range("F1").Value = "Geloescht"
                xlWorksheet1.Range("A:A").NumberFormat = "@"
                xlWorksheet1.Range("B:B").NumberFormat = "#0"
                xlWorksheet1.Range("D:E").NumberFormat = "yyyymmdd"
                xlWorksheet1.Range("I:I").NumberFormat = "yyyymmdd"
                xlWorksheet1.Range("M:M").NumberFormat = "yyyymmdd"
                xlWorksheet1.Range("O:O").NumberFormat = "yyyymmdd"
                EXCELL.Application.DisplayAlerts = False
                xlWorkBook.SaveAs(MULTIBANK_KONVERTER_KONTOINHABER_FILE, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
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

                OpenSqlConnections()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete current Data in EAEG_KontenPersonen")
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Delete current Data in EAEG_KontenPersonen")
                cmd.CommandText = "DELETE  FROM [EAEG_KontenPersonen]"
                cmd.ExecuteNonQuery()

                'SplashScreenManager.Default.SetWaitFormCaption("Start import Data from the related Excel File")
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Start import Data from the related Excel File")
                'Ausführen SSI
                'SplashScreenManager.Default.SetWaitFormCaption("Start SSI ImportKontoinhaber")
                'Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Start SSI ImportKontoinhaber")
                'pkg = app.LoadPackage(SSISDirectory & "ImportKontoinhaber.dtsx", Nothing)
                'pkg.Execute()
                cmd.CommandText = "INSERT INTO [EAEG_KontenPersonen]([KontoNr],[LfdNr],[Art],[GueltBeginn],[GueltEnde],[Geloescht],[Nachname],[Vorname],[Geburtsdatum],[Anschrift],[BaFin melden],[Angelegt von],[Angelegt am],[Geändert von],[Geändert am],[Altbestand übernommen])  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & MULTIBANK_KONVERTER_KONTOINHABER_FILE & ";','SELECT [KontoNr],[LfdNr],[Art],[GueltBeginn],[GueltEnde],[Geloescht],[Nachname],[Vorname],[Geburtsdatum],[Anschrift],[BaFin melden],[Angelegt von],[Angelegt am],[Geändert von],[Geändert am],[Altbestand übernommen] FROM [Sheet1$]')"
                cmd.ExecuteNonQuery()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete leading Zeros in C2_Kontonummer")
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Delete leading Zeros in C2_Kontonummer")
                cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [C2_Kontonummer]=REPLACE(LTRIM(REPLACE([C2_Kontonummer], '0', ' ')), ' ', '0') where [C2_Kontonummer] like '0%'"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Update C5_ANZAHL_KONTOINHABER in [EAEG_KUNDEN_KONTEN]")
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Update C5_ANZAHL_KONTOINHABER in [EAEG_KUNDEN_KONTEN]")
                QueryText = "SELECT [KontoNr],Count([Art]) as AnzahlKontoinhaber FROM [EAEG_KontenPersonen] where [Art]='Inhaber' and [Geloescht]='Nein' and [GueltEnde]='99991231' GROUP BY [KontoNr]"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New DataTable()
                da.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    Dim AnzahlKontoinhaber As Double = dt.Rows.Item(i).Item("AnzahlKontoinhaber")
                    Dim KontoNr As String = dt.Rows.Item(i).Item("KontoNr")
                    cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [C5_AnzahlKontoinhaber]=" & Str(AnzahlKontoinhaber) & " where [C2_Kontonummer]='" & KontoNr & "'"
                    cmd.ExecuteNonQuery()
                Next

                cmd.CommandText = "UPDATE [EAEG_KUNDEN_KONTEN] SET [C5_AnzahlKontoinhaber]=1" 'where [C5_AnzahlKontoinhaber] is NULL"
                cmd.ExecuteNonQuery()

                CloseSqlConnections()

                'SplashScreenManager.Default.SetWaitFormCaption("Delete Excel File: " & MULTIBANK_KONVERTER_KONTOINHABER_FILE)
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Delete Excel File: " & MULTIBANK_KONVERTER_KONTOINHABER_FILE)
                File.Delete(MULTIBANK_KONVERTER_KONTOINHABER_FILE)
                'SplashScreenManager.Default.SetWaitFormCaption("MULTIBANK KONVERTER KONTOINHABER IMPORT finished")
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "MULTIBANK KONVERTER KONTOINHABER IMPORT finished")
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(30, "Unable to Import MULTIBANK KONVERTER KONTOINHABER! File does not exist!")
                MessageBox.Show("Unable to Import MULTIBANK KONVERTER KONTOINHABER! File does not exist!", "MULTIBANK KONVERTER KONTOINHABER IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwMultibankKonverterKontoinhaberDirectoty.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwMultibankKonverterKontoinhaberDirectoty_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwMultibankKonverterKontoinhaberDirectoty.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','MULTIBANK KONVERTER KONTOINHABER IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "MULTIBANK KONVERTER KONTOINHABER IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','MULTIBANK KONVERTER KONTOINHABER IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "MULTIBANK KONVERTER KONTOINHABER IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwMultibankKonverterKontoinhaberDirectoty_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwMultibankKonverterKontoinhaberDirectoty.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwMultibankKonverterKontoinhaberDirectoty, e)
        'SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "IMPORT TARGET2 DIRECTORY"
    Private Sub BgwT2Directory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwT2Directory.DoWork
        Try
            OpenSqlConnections()
            cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('T2_DIRECTORY_NEW_TXT_FILE') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
            Dim T2_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar


            If File.Exists(T2_DIRECTORY_NEW_TXT_FILE) = True Then
                File.Delete(T2_DIRECTORY_NEW_TXT_FILE)
            End If
            Dim sr As New System.IO.StreamReader(T2_DIR_FILE)
            Dim sr1 As System.IO.StreamWriter
            sr1 = My.Computer.FileSystem.OpenTextFileWriter(T2_DIRECTORY_NEW_TXT_FILE, True)

            Dim BIC As String = ""
            Dim ADRESSEE As String = ""
            Dim ACCOUNT_HOLDER As String = ""
            Dim INSTITUTION_NAME As String = ""
            Dim CITY_HEADING As String = ""
            Dim NATIONAL_SORTING_CODE As String = ""
            Dim MAIN_BIC_FLAG As String = ""
            Dim TYPE_OF_CHANGE As String = ""
            Dim VALID_FROM As String = ""
            Dim VALID_TILL As String = ""
            Dim PARTICIPATION_TYPE As String = ""
            Dim RESERVE As String = ""


            Dim Zeileninhalt As String = ""
            'Dim Arr() As String


            'SplashScreenManager.Default.SetWaitFormCaption("Creating file: " & T2_DIRECTORY_NEW_TXT_FILE)
            Me.BgwT2Directory.ReportProgress(30, "Creating file: " & T2_DIRECTORY_NEW_TXT_FILE)
            Do While Not sr.EndOfStream
                Zeileninhalt = sr.ReadLine().Replace(",", " ")
                'Arr = Zeileninhalt.Split(" ")

                'Datum = DateSerial(Microsoft.VisualBasic.Right(Arr(0), 4), Mid(Arr(0), 3, 2), Microsoft.VisualBasic.Left(Arr(0), 2))
                BIC = Microsoft.VisualBasic.Left(Zeileninhalt, 11)
                ADRESSEE = Mid(Zeileninhalt, 12, 11)
                ACCOUNT_HOLDER = Mid(Zeileninhalt, 23, 11)
                INSTITUTION_NAME = Mid(Zeileninhalt, 34, 105)
                CITY_HEADING = Mid(Zeileninhalt, 139, 35)
                NATIONAL_SORTING_CODE = Mid(Zeileninhalt, 174, 15)
                MAIN_BIC_FLAG = Mid(Zeileninhalt, 189, 1)
                TYPE_OF_CHANGE = Mid(Zeileninhalt, 190, 1)
                VALID_FROM = Mid(Zeileninhalt, 191, 8)
                VALID_TILL = Mid(Zeileninhalt, 199, 8)
                PARTICIPATION_TYPE = Mid(Zeileninhalt, 207, 2)
                RESERVE = Mid(Zeileninhalt, 209, 23)


                sr1.WriteLine(BIC & "," & ADRESSEE & "," & ACCOUNT_HOLDER & "," & INSTITUTION_NAME & "," & CITY_HEADING & "," & NATIONAL_SORTING_CODE & "," & MAIN_BIC_FLAG & "," & TYPE_OF_CHANGE & "," & VALID_FROM & "," & VALID_TILL & "," & PARTICIPATION_TYPE & "," & RESERVE)

            Loop

            sr.Close()
            sr1.Close()


            '*********************************************************************************************************
            '***********IMPORT T2 DIRECTORY TO SQL SERVER CCB-DB*****************************************************
            '*********************************************************************************************************
            'SplashScreenManager.Default.SetWaitFormCaption("File:" & T2_DIRECTORY_NEW_TXT_FILE & " has being created")
            Me.BgwT2Directory.ReportProgress(40, "File:" & T2_DIRECTORY_NEW_TXT_FILE & " has being created")

            'SplashScreenManager.Default.SetWaitFormCaption("IMPORT NEW TARGET2 DIRECTORY from file: " & T2_DIRECTORY_NEW_TXT_FILE)
            Me.BgwT2Directory.ReportProgress(40, "IMPORT NEW TARGET2 DIRECTORY from file: " & T2_DIRECTORY_NEW_TXT_FILE)

            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_TARGET2_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
            Dim ParameterStatus As String = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_TARGET2_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i1 = 0 To dt.Rows.Count - 1
                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<T2_DIRECTORY_NEW_TXT_FILE>", T2_DIRECTORY_NEW_TXT_FILE)
                    cmd.CommandText = SqlCommandText1
                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                        Me.BgwT2Directory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwT2Directory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_TARGET2_DIRECTORY! Parameter Status is Invalid!!")
                MessageBox.Show("Unable to execute Import Procedure:IMPORT_TARGET2_DIRECTORY! Parameter Status is Invalid!!", "TARGET2 DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If



            CloseSqlConnections()

            '*********************************************************************************************************
            'SplashScreenManager.Default.SetWaitFormCaption("Delete file: " & T2_DIRECTORY_NEW_TXT_FILE)
            Me.BgwT2Directory.ReportProgress(40, "Delete file: " & T2_DIRECTORY_NEW_TXT_FILE)
            File.Delete(T2_DIRECTORY_NEW_TXT_FILE)

            Me.BgwT2Directory.ReportProgress(100, "T2 DIRECTORY IMPORT FINISHED")
            'SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            CloseSqlConnections()
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwT2Directory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwT2Directory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwT2Directory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','TARGET2 DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "TARGET2 DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','TARGET2 DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "TARGET2 DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwT2Directory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwT2Directory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwT2Directory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT TARGET2 XML DIRECTORY"
    Private Sub BgwT2_XML_Directory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwT2_XML_Directory.DoWork
        Try
            If File.Exists(T2_XML_DIR_FILE) = True Then
                OpenSqlConnections()

                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_TARGET2_XML_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_TARGET2_XML_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<T2_DIRECTORY_XML_FILE>", T2_XML_DIR_FILE)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwT2_XML_Directory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwT2_XML_Directory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_TARGET2_XML_DIRECTORY! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_TARGET2_XML_DIRECTORY! Parameter Status is Invalid!!", "TARGET2 XML DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If


                CloseSqlConnections()

                '*********************************************************************************************************
                'File.Delete(BIC_PLUS_DIR_FILE)

                Me.BgwT2_XML_Directory.ReportProgress(100, "TARGET2 XML DIRECTORY IMPORT FINISHED")
                'SplashScreenManager.CloseForm(False)
            End If
        Catch ex As Exception
            CloseSqlConnections()
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwT2_XML_Directory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwT2_XML_Directory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwT2_XML_Directory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','TARGET2 XML DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "TARGET2 XML DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','TARGET2 XML DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "TARGET2 XML DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwT2_XML_Directory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwT2_XML_Directory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwT2_XML_Directory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT BIC PLUS"
    Private Sub BgwBicPlusDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBicPlusDirectory.DoWork
        Try
            If File.Exists(BIC_PLUS_DIR_FILE) = True Then
                OpenSqlConnections()

                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_BIC_PLUS_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_BIC_PLUS_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<BIC_PLUS_DIR_FILE>", BIC_PLUS_DIR_FILE)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwBicPlusDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwBicPlusDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_BIC_PLUS_DIRECTORY! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_BIC_PLUS_DIRECTORY! Parameter Status is Invalid!!", "BIC PLUS DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If


                CloseSqlConnections()

                '*********************************************************************************************************
                'File.Delete(BIC_PLUS_DIR_FILE)

                Me.BgwBicPlusDirectory.ReportProgress(100, "BIC PLUS DIRECTORY IMPORT FINISHED")
                'SplashScreenManager.CloseForm(False)
            End If
        Catch ex As Exception
            CloseSqlConnections()
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwBicPlusDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwBicPlusDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBicPlusDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','BIC PLUS DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "BIC PLUS DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','BIC PLUS DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "BIC PLUS DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwBicPlusDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBicPlusDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwBicPlusDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT BANK DIRECTORY PLUS"
    Private Sub BgwBankDirectoryPlus_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBankDirectoryPlus.DoWork
        Try
            If File.Exists(BANK_DIR_PLUS_FILE) = True Then
                OpenSqlConnections()

                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_BANK_DIRECTORY_PLUS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_BANK_DIRECTORY_PLUS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<BANK_DIR_PLUS_FILE>", BANK_DIR_PLUS_FILE)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwBankDirectoryPlus.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwBankDirectoryPlus.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_BANK_DIRECTORY_PLUS! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_BANK_DIRECTORY_PLUS! Parameter Status is Invalid!!", "BANK DIRECTORY PLUS IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If


                CloseSqlConnections()

                '*********************************************************************************************************
                'File.Delete(BIC_PLUS_DIR_FILE)

                Me.BgwBankDirectoryPlus.ReportProgress(100, "BANK DIRECTORY PLUS IMPORT FINISHED")
                'SplashScreenManager.CloseForm(False)
            End If
        Catch ex As Exception
            CloseSqlConnections()
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwBankDirectoryPlus.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwBankDirectoryPlus_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBankDirectoryPlus.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','BANK DIRECTORY PLUS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "BANK DIRECTORY PLUS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','BANK DIRECTORY PLUS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "BANK DIRECTORY PLUS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwBankDirectoryPlus_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBankDirectoryPlus.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwBankDirectoryPlus, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT IBAN PLUS DIRECTORY"
    Private Sub BgwIbanFullDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwIbanFullDirectory.DoWork
        Try
            If File.Exists(IBAN_PLUS_FULL_DIR) = True Then
                OpenSqlConnections()

                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_IBAN_PLUS_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_IBAN_PLUS_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<IBAN_PLUS_FULL_DIR>", IBAN_PLUS_FULL_DIR)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwIbanFullDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwIbanFullDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_IBAN_PLUS_DIRECTORY! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_IBAN_PLUS_DIRECTORY! Parameter Status is Invalid!!", "IBAN PLUS DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If

                CloseSqlConnections()

                '*********************************************************************************************************
                'File.Delete(BIC_PLUS_DIR_FILE)

                Me.BgwIbanFullDirectory.ReportProgress(100, "IBAN DIRECTORY PLUS IMPORT FINISHED")
                'SplashScreenManager.CloseForm(False)
            End If
        Catch ex As Exception
            CloseSqlConnections()
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwIbanFullDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwIbanFullDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwIbanFullDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','IBAN DIRECTORY PLUS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "IBAN DIRECTORY PLUS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','IBAN DIRECTORY PLUS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "IBAN DIRECTORY PLUS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwIbanFullDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwIbanFullDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwIbanFullDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT IBAN STRUCTURE DIRECTORY"
    Private Sub BgwIbanStructureFullDirectory_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwIbanStructureFullDirectory.DoWork
        Try
            If File.Exists(IBAN_STRUCTURE_FULL_DIR) = True Then
                OpenSqlConnections()

                cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_IBAN_STRUCTURE_DIRECTORY') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
                Dim ParameterStatus As String = cmd.ExecuteScalar
                If ParameterStatus = "Y" Then
                    QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_IBAN_STRUCTURE_DIRECTORY')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    For i1 = 0 To dt.Rows.Count - 1
                        SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<IBAN_STRUCTURE_FULL_DIR>", IBAN_STRUCTURE_FULL_DIR)
                        cmd.CommandText = SqlCommandText1
                        If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                            'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                            Me.BgwIbanStructureFullDirectory.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Else
                    'SplashScreenManager.CloseForm(False)
                    Me.BgwIbanStructureFullDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_IBAN_STRUCTURE_DIRECTORY! Parameter Status is Invalid!!")
                    MessageBox.Show("Unable to execute Import Procedure:IMPORT_IBAN_STRUCTURE_DIRECTORY! Parameter Status is Invalid!!", "IBAN STRUCTURE DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return

                End If

                CloseSqlConnections()
                '*********************************************************************************************************
                'File.Delete(BIC_PLUS_DIR_FILE)

                Me.BgwIbanStructureFullDirectory.ReportProgress(100, "IBAN STRUCTURE DIRECTORY IMPORT FINISHED")
                'SplashScreenManager.CloseForm(False)
            End If
        Catch ex As Exception
            CloseSqlConnections()
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwIbanStructureFullDirectory.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwIbanStructureFullDirectory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwIbanStructureFullDirectory.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','IBAN STRUCTURE DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "IBAN STRUCTURE DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','IBAN STRUCTURE DIRECTORY IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "IBAN STRUCTURE DIRECTORY IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwIbanStructureFullDirectory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwIbanStructureFullDirectory.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwIbanStructureFullDirectory, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT HOLIDAYS"

    Private Sub BgwHolidayData_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwHolidayData.DoWork
        Try
            OpenSqlConnections()

            cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('HOLIDAY_DIRECTORY_NEW_TXT_FILE') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
            Dim HOLIDAY_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar

            If File.Exists(HOLIDAY_DIRECTORY_NEW_TXT_FILE) = True Then
                File.Delete(HOLIDAY_DIRECTORY_NEW_TXT_FILE)
            End If
            FileCopy(HOLIDAYS_DATA_DIR, HOLIDAY_DIRECTORY_NEW_TXT_FILE)

            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS] where  [SQL_Name_1] in ('IMPORT_HOLIDAYS') and [Id_SQL_Parameters] in ('MANUAL_IMPORTS')"
            Dim ParameterStatus As String = cmd.ExecuteScalar
            If ParameterStatus = "Y" Then
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_SECOND]  where [Id_SQL_Parameters_Details] in (Select [ID] from SQL_PARAMETER_DETAILS where SQL_Name_1 in ('IMPORT_HOLIDAYS')) and [SQL_Command_1] is not NULL  and [Status] in ('Y') order by [SQL_Float_1] asc"
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                For i1 = 0 To dt.Rows.Count - 1
                    SqlCommandText1 = dt.Rows.Item(i1).Item("SQL_Command_1").ToString.Replace("<HOLIDAY_DIRECTORY_NEW_TXT_FILE>", HOLIDAY_DIRECTORY_NEW_TXT_FILE)
                    cmd.CommandText = SqlCommandText1
                    If dt.Rows.Item(i1).Item("SQL_Name_1") <> "" Then
                        'SplashScreenManager.Default.SetWaitFormCaption(dt.Rows.Item(i1).Item("SQL_Name_1"))
                        Me.BgwHolidayData.ReportProgress(i1, dt.Rows.Item(i1).Item("SQL_Name_1"))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                'SplashScreenManager.CloseForm(False)
                Me.BgwIbanStructureFullDirectory.ReportProgress(30, "Unable to execute Import Procedure:IMPORT_HOLIDAYS! Parameter Status is Invalid!!")
                MessageBox.Show("Unable to execute Import Procedure:IMPORT_HOLIDAYS! Parameter Status is Invalid!!", "HOLIDAYS IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return

            End If



            CloseSqlConnections()

            'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & HOLIDAY_DIRECTORY_NEW_TXT_FILE)
            Me.BgwHolidayData.ReportProgress(30, "Delete File: " & HOLIDAY_DIRECTORY_NEW_TXT_FILE)
            File.Delete(HOLIDAY_DIRECTORY_NEW_TXT_FILE)
            'SplashScreenManager.Default.SetWaitFormCaption("HOLIDAYS IMPORT finished")
            Me.BgwHolidayData.ReportProgress(30, "HOLIDAYS IMPORT finished")
            'Else
            'SplashScreenManager.CloseForm(False)
            'Me.BgwBlzDirectory.ReportProgress(30, "Unable to Import the new BLZ DIRECTORY! File does not exist!")
            'MessageBox.Show("Unable to Import the new BLZ DIRECTORY! File does not exist!", "BLZ DIRECTORY IMPORT FAILLED", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Exit Sub
            'End If
        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwHolidayData.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub
        End Try
    End Sub

    Private Sub BgwHolidayData_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwHolidayData.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','HOLIDAY DATA IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "HOLIDAY DATA IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','HOLIDAY DATA IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "HOLIDAY DATA IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwHolidayData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwHolidayData.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwHolidayData, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "UPDATE OWN FX DEALS"
    Private Sub BgwOwnFxDealsUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOwnFxDealsUpdate.DoWork
        Try
            'SplashScreenManager.Default.SetWaitFormCaption("Start updating own FX Deals")
            OpenSqlConnections()
            Me.BgwOwnFxDealsUpdate.ReportProgress(1, "Start updating own FX Deals")

            'cmd.CommandText = "UPDATE A SET A.[OwnDeal] = 'Y' FROM [FX DAILY REVALUATION] A INNER JOIN OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & OWN_FX_DEALS_DIR & ";', 'SELECT BusinessDate, ContractNo FROM [Sheet1$]') B ON A.[ContractNr] = B.ContractNo AND A.[RiskDate] = B.BusinessDate and A.[DealStatus]='U'"
            cmd.CommandText = "UPDATE A SET A.[OwnDeal] = 'Y' FROM [FX DAILY REVALUATION] A INNER JOIN OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & OWN_FX_DEALS_DIR & ";', 'SELECT ContractNo FROM [Sheet1$]') B ON A.[ContractNr] = B.ContractNo AND A.[DealStatus]='U' and A.[OwnDeal] = 'N'"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & OWN_FX_DEALS_DIR & ";','SELECT Count(*) FROM [Sheet1$]')"
            'SplashScreenManager.Default.SetWaitFormCaption(cmd.ExecuteScalar & " FX Deals updated")
            Me.BgwOwnFxDealsUpdate.ReportProgress(1, cmd.ExecuteScalar & " FX Deals updated")
            CloseSqlConnections()


        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwOwnFxDealsUpdate.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
        End Try


    End Sub

    Private Sub BgwOwnFxDealsUpdate_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOwnFxDealsUpdate.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','OWN FX DEALS UPDATE','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "OWN FX DEALS UPDATE" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','OWN FX DEALS UPDATE','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "OWN FX DEALS UPDATE" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwOwnFxDealsUpdate_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOwnFxDealsUpdate.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwOwnFxDealsUpdate, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT BAIS FILES"
    Private Sub BgwBaisFiles_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwBaisFiles.DoWork
        For i = 0 To dir_BaisFiles.Count - 1
            Dim BaisFileName As String = dir_BaisFiles(i).ToString
            Select Case BaisFileName
                Case Is = "GSTIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS GSTIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS GSTIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_GSTIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GSTIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GSTIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GSTIFF_Temp]([GSTIFF_MDANT] [nvarchar](50) NULL,[GSTIFF_FILNR] [nvarchar](50) NULL,[GSTIFF_MODUL] [nvarchar](50) NULL,[GSTIFF_KDNRH] [nvarchar](50) NULL,[GSTIFF_KTONR] [nvarchar](50) NULL,[GSTIFF_GSREF] [nvarchar](50) NULL,[GSTIFF_BEZNG] [nvarchar](50) NULL,[GSTIFF_KOART] [nvarchar](50) NULL,[GSTIFF_BILKT] [nvarchar](50) NULL,[GSTIFF_GSKLA] [nvarchar](50) NULL,[GSTIFF_SUKLA] [nvarchar](50) NULL,[GSTIFF_GSART] [nvarchar](50) NULL,[GSTIFF_ULFZT] [nvarchar](50) NULL,[GSTIFF_WHISO] [nvarchar](50) NULL,[GSTIFF_VERKZ] [nvarchar](50) NULL,[GSTIFF_SLDKZ] [nvarchar](50) NULL,[GSTIFF_KZREV] [nvarchar](50) NULL,[GSTIFF_WPKNZ] [nvarchar](50) NULL,[GSTIFF_WPBFN] [nvarchar](50) NULL,[GSTIFF_HBKZN] [nvarchar](50) NULL,[GSTIFF_ZWRIS] [nvarchar](50) NULL,[GSTIFF_KZLST] [nvarchar](50) NULL,[GSTIFF_HAFIN] [nvarchar](50) NULL,[GSTIFF_WESTA] [nvarchar](50) NULL,[GSTIFF_BEZNR] [nvarchar](50) NULL,[GSTIFF_DXVND] [nvarchar](50) NULL,[GSTIFF_DXBSD] [nvarchar](50) NULL,[GSTIFF_MRLFZ] [nvarchar](50) NULL,[GSTIFF_AUSFL] [nvarchar](50) NULL,[GSTIFF_DXAUD] [nvarchar](50) NULL,[GSTIFF_RANGF] [nvarchar](50) NULL,[GSTIFF_KZUEV] [nvarchar](50) NULL,[GSTIFF_KFRIS] [nvarchar](50) NULL,[GSTIFF_DXZAP] [nvarchar](50) NULL,[GSTIFF_KZVSG] [nvarchar](50) NULL,[GSTIFF_KZKRU] [nvarchar](50) NULL,[GSTIFF_KONSB] [nvarchar](50) NULL,[GSTIFF_RISGR] [nvarchar](50) NULL,[GSTIFF_KONSK] [nvarchar](50) NULL,[GSTIFF_WPKNR] [nvarchar](50) NULL,[GSTIFF_GSARE] [nvarchar](50) NULL,[GSTIFF_PRDKT] [nvarchar](50) NULL,[GSTIFF_WHIFX] [nvarchar](50) NULL,[GSTIFF_HFZGP] [nvarchar](50) NULL,[GSTIFF_AFREF] [nvarchar](50) NULL,[GSTIFF_KZAKL] [nvarchar](50) NULL,[GSTIFF_KONSR] [nvarchar](50) NULL,[GSTIFF_FREI1] [nvarchar](50) NULL,[GSTIFF_FREI2] [nvarchar](50) NULL,[GSTIFF_FREI3] [nvarchar](50) NULL,[GSTIFF_FREI4] [nvarchar](50) NULL,[GSTIFF_FREI5] [nvarchar](50) NULL,[GSTIFF_LOEKZ] [nvarchar](50) NULL,[GSTIFF_IFNAM] [nvarchar](50) NULL,[GSTIFF_DXIFD] [datetime] NULL) ELSE DELETE FROM [#Temp_BAIS_GSTIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import GSTIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import GSTIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GSTIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_GSTIFF with the same Date in Column:GSTIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_GSTIFF with the same Date in Column:GSTIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GSTIFF] where [GSTIFF_DXIFD] in (Select distinct [GSTIFF_DXIFD] from [#Temp_BAIS_GSTIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_GSTIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GSTIFF")
                        cmd.CommandText = "INSERT INTO [BAIS_GSTIFF]([GSTIFF_MDANT],[GSTIFF_FILNR],[GSTIFF_MODUL],[GSTIFF_KDNRH],[GSTIFF_KTONR],[GSTIFF_GSREF],[GSTIFF_BEZNG],[GSTIFF_KOART],[GSTIFF_BILKT],[GSTIFF_GSKLA],[GSTIFF_SUKLA],[GSTIFF_GSART],[GSTIFF_ULFZT],[GSTIFF_WHISO],[GSTIFF_VERKZ],[GSTIFF_SLDKZ],[GSTIFF_KZREV],[GSTIFF_WPKNZ],[GSTIFF_WPBFN],[GSTIFF_HBKZN],[GSTIFF_ZWRIS],[GSTIFF_KZLST],[GSTIFF_HAFIN],[GSTIFF_WESTA],[GSTIFF_BEZNR],[GSTIFF_DXVND],[GSTIFF_DXBSD],[GSTIFF_MRLFZ],[GSTIFF_AUSFL],[GSTIFF_DXAUD],[GSTIFF_RANGF],[GSTIFF_KZUEV],[GSTIFF_KFRIS],[GSTIFF_DXZAP],[GSTIFF_KZVSG],[GSTIFF_KZKRU],[GSTIFF_KONSB],[GSTIFF_RISGR],[GSTIFF_KONSK],[GSTIFF_WPKNR],[GSTIFF_GSARE],[GSTIFF_PRDKT],[GSTIFF_WHIFX],[GSTIFF_HFZGP],[GSTIFF_AFREF],[GSTIFF_KZAKL],[GSTIFF_KONSR],[GSTIFF_FREI1],[GSTIFF_FREI2],[GSTIFF_FREI3],[GSTIFF_FREI4],[GSTIFF_FREI5],[GSTIFF_LOEKZ],[GSTIFF_IFNAM],[GSTIFF_DXIFD]) Select * from [#Temp_BAIS_GSTIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GSTIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS GSTIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS GSTIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GSTSLF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS GSTSLF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS GSTSLF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_GSTSLF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GSTSLF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GSTSLF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GSTSLF_Temp]([GSTSLF_MDANT] [nvarchar](50) NULL,[GSTSLF_MODUL] [nvarchar](50) NULL,[GSTSLF_KDNRH] [nvarchar](50) NULL,[GSTSLF_KTONR] [nvarchar](50) NULL,[GSTSLF_GSREF] [nvarchar](50) NULL,[GSTSLF_SLDUB] [float] NULL,[GSTSLF_DISPO] [nvarchar](50) NULL,[GSTSLF_DXDVD] [nvarchar](50) NULL,[GSTSLF_DXDBD] [nvarchar](50) NULL,[GSTSLF_ABGBT] [float] NULL,[GSTSLF_GKBTR] [nvarchar](50) NULL,[GSTSLF_FAIRV] [nvarchar](50) NULL,[GSTSLF_IFNAM] [nvarchar](50) NULL,[GSTSLF_DXIFD] [nvarchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_GSTSLF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import GSTSLF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import GSTSLF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GSTSLF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN GSTSLF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN GSTSLF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_GSTSLF_Temp] ALTER COLUMN [GSTSLF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_GSTSLF with the same Date in Column:GSTSLF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_GSTSLF with the same Date in Column:GSTSLF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GSTSLF] where [GSTSLF_DXIFD] in (Select distinct [GSTSLF_DXIFD] from [#Temp_BAIS_GSTSLF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_GSTSLF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GSTSLF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_GSTSLF]([GSTSLF_MDANT],[GSTSLF_MODUL],[GSTSLF_KDNRH],[GSTSLF_KTONR],[GSTSLF_GSREF],[GSTSLF_SLDUB],[GSTSLF_DISPO],[GSTSLF_DXDVD],[GSTSLF_DXDBD],[GSTSLF_ABGBT],[GSTSLF_GKBTR],[GSTSLF_FAIRV],[GSTSLF_IFNAM],[GSTSLF_DXIFD]) Select * from [#Temp_BAIS_GSTSLF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GSTSLF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS GSTSLF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS GSTSLF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "KGCIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS KGCIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS KGCIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:BAIS_GKCIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KGCIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KGCIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KGCIFF_Temp]([KGCIFF_MDANT] [varchar](50) NULL,[KGCIFF_MODUL] [varchar](50) NULL,[KGCIFF_KDNRH] [varchar](50) NULL,[KGCIFF_KTONR] [varchar](50) NULL,[KGCIFF_GSREF] [varchar](50) NULL,[KGCIFF_ACCNR] [varchar](50) NULL,[KGCIFF_PTYPI] [varchar](50) NULL,[KGCIFF_CURCD] [varchar](50) NULL,[KGCIFF_DXBEW] [varchar](50) NULL,[KGCIFF_ERART] [varchar](50) NULL,[KGCIFF_HOEHE] [varchar](50) NULL,[KGCIFF_SALDO] [varchar](50) NULL,[KGCIFF_TILGA] [varchar](50) NULL,[KGCIFF_ZINSA] [varchar](50) NULL,[KGCIFF_WHISO] [varchar](50) NULL,[KGCIFF_IFNAM] [varchar](50) NULL,[KGCIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_KGCIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import KGCIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import KGCIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KGCIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN KGCIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN KGCIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KGCIFF_Temp] ALTER COLUMN [KGCIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN KGCIFF_DXBEW to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN KGCIFF_DXBEW to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KGCIFF_Temp] ALTER COLUMN [KGCIFF_DXBEW] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_KGCIFF with the same Date in Column:KGCIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_KGCIFF with the same Date in Column:KGCIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KGCIFF] where [KGCIFF_DXIFD] in (Select distinct [KGCIFF_DXIFD] from [#Temp_BAIS_KGCIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_GSTSLF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GSTSLF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KGCIFF]([KGCIFF_MDANT],[KGCIFF_MODUL],[KGCIFF_KDNRH],[KGCIFF_KTONR],[KGCIFF_GSREF],[KGCIFF_ACCNR],[KGCIFF_PTYPI],[KGCIFF_CURCD],[KGCIFF_DXBEW],[KGCIFF_ERART],[KGCIFF_HOEHE],[KGCIFF_SALDO],[KGCIFF_TILGA],[KGCIFF_ZINSA],[KGCIFF_WHISO],[KGCIFF_IFNAM],[KGCIFF_DXIFD]) Select * from [#Temp_BAIS_KGCIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KGCIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS KGCIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS KGCIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "KNEIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS KNEIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS KNEIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_KNEIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KNEIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KNEIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KNEIFF_Temp]([KNEIFF_MDANT] [varchar](50) NULL,[KNEIFF_FILNR] [varchar](50) NULL,[KNEIFF_KDNRH] [varchar](50) NULL,[KNEIFF_KURZN] [varchar](50) NULL,[KNEIFF_NAME1] [varchar](50) NULL,[KNEIFF_NAME2] [varchar](50) NULL,[KNEIFF_NAME3] [varchar](50) NULL,[KNEIFF_PLZOR] [varchar](50) NULL,[KNEIFF_PLZNR] [varchar](50) NULL,[KNEIFF_STRAS] [varchar](50) NULL,[KNEIFF_DXGEB] [varchar](50) NULL,[KNEIFF_WSGSI] [varchar](50) NULL,[KNEIFF_BRNCH] [varchar](50) NULL,[KNEIFF_WSBIS] [varchar](50) NULL,[KNEIFF_BRNZU] [varchar](50) NULL,[KNEIFF_SLDSL] [varchar](50) NULL,[KNEIFF_RLDSL] [varchar](50) NULL,[KNEIFF_LDRIS] [varchar](50) NULL,[KNEIFF_BONIT] [varchar](50) NULL,[KNEIFF_GRPKZ] [varchar](50) NULL,[KNEIFF_KZLST] [varchar](50) NULL,[KNEIFF_KZPER] [varchar](50) NULL,[KNEIFF_UMMIO] [varchar](50) NULL,[KNEIFF_AUSFL] [varchar](50) NULL,[KNEIFF_DXAUD] [varchar](50) NULL,[KNEIFF_ORGSL] [varchar](50) NULL,[KNEIFF_RISGR] [varchar](50) NULL,[KNEIFF_KGBID] [varchar](50) NULL,[KNEIFF_ANRKZ] [varchar](50) NULL,[KNEIFF_ESAKZ] [varchar](50) NULL,[KNEIFF_NACES] [varchar](50) NULL,[KNEIFF_LENID] [varchar](50) NULL,[KNEIFF_WSCRR] [varchar](50) NULL,[KNEIFF_AVCKZ] [varchar](50) NULL,[KNEIFF_FREI1] [varchar](50) NULL,[KNEIFF_FREI2] [varchar](50) NULL,[KNEIFF_FREI3] [varchar](50) NULL,[KNEIFF_FREI4] [varchar](50) NULL,[KNEIFF_FREI5] [varchar](50) NULL,[KNEIFF_LOEKZ] [varchar](50) NULL,[KNEIFF_IFNAM] [varchar](50) NULL,[KNEIFF_DXIFD] [varchar](50) NULL)  ELSE DELETE FROM [#Temp_BAIS_KNEIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import KNEIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import KNEIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KNEIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN KNEIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN KNEIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KNEIFF_Temp] ALTER COLUMN [KNEIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_KNEIFF with the same Date in Column:KNEIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_KNEIFF with the same Date in Column:KNEIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KNEIFF] where [KNEIFF_DXIFD] in (Select distinct [KNEIFF_DXIFD] from [#Temp_BAIS_KNEIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_KNEIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNEIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KNEIFF]([KNEIFF_MDANT],[KNEIFF_FILNR],[KNEIFF_KDNRH],[KNEIFF_KURZN],[KNEIFF_NAME1],[KNEIFF_NAME2],[KNEIFF_NAME3],[KNEIFF_PLZOR],[KNEIFF_PLZNR],[KNEIFF_STRAS],[KNEIFF_DXGEB],[KNEIFF_WSGSI],[KNEIFF_BRNCH],[KNEIFF_WSBIS],[KNEIFF_BRNZU],[KNEIFF_SLDSL],[KNEIFF_RLDSL],[KNEIFF_LDRIS],[KNEIFF_BONIT],[KNEIFF_GRPKZ],[KNEIFF_KZLST],[KNEIFF_KZPER],[KNEIFF_UMMIO],[KNEIFF_AUSFL],[KNEIFF_DXAUD],[KNEIFF_ORGSL],[KNEIFF_RISGR],[KNEIFF_KGBID],[KNEIFF_ANRKZ],[KNEIFF_ESAKZ],[KNEIFF_NACES],[KNEIFF_LENID],[KNEIFF_WSCRR],[KNEIFF_AVCKZ],[KNEIFF_FREI1],[KNEIFF_FREI2],[KNEIFF_FREI3],[KNEIFF_FREI4],[KNEIFF_FREI5],[KNEIFF_LOEKZ],[KNEIFF_IFNAM],[KNEIFF_DXIFD]) Select * from [#Temp_BAIS_KNEIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KNEIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS KNEIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS KNEIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "KNVIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS KNVIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS KNVIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_KNVIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KNVIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KNVIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KNVIFF_Temp]([KNVIFF_MDANK] [varchar](50) NULL,[KNVIFF_MDANT] [varchar](50) NULL,[KNVIFF_KNZNR] [varchar](50) NULL,[KNVIFF_MDAN2] [varchar](50) NULL,[KNVIFF_KDNRH] [varchar](50) NULL,[KNVIFF_KNEKZ] [varchar](50) NULL,[KNVIFF_GRDZF] [varchar](50) NULL,[KNVIFF_ZUSKZ] [varchar](50) NULL,[KNVIFF_GBRKZ] [varchar](50) NULL,[KNVIFF_MEANT] [varchar](50) NULL,[KNVIFF_HFBES] [varchar](50) NULL,[KNVIFF_ANERL] [varchar](50) NULL,[KNVIFF_BETXT] [varchar](50) NULL,[KNVIFF_FREI1] [varchar](50) NULL,[KNVIFF_FREI2] [varchar](50) NULL,[KNVIFF_FREI3] [varchar](50) NULL,[KNVIFF_LOEKZ] [varchar](50) NULL,[KNVIFF_IFNAM] [varchar](50) NULL,[KNVIFF_DXIFD] [varchar](50) NULL)  ELSE DELETE FROM [#Temp_BAIS_KNVIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import KNVIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import KNVIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KNVIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN KNVIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN KNVIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KNVIFF_Temp] ALTER COLUMN [KNVIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_KNVIFF with the same Date in Column:KNVIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_KNVIFF with the same Date in Column:KNVIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KNVIFF] where [KNVIFF_DXIFD] in (Select distinct [KNVIFF_DXIFD] from [#Temp_BAIS_KNVIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_KNVIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNVIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KNVIFF]([KNVIFF_MDANK],[KNVIFF_MDANT],[KNVIFF_KNZNR],[KNVIFF_MDAN2],[KNVIFF_KDNRH],[KNVIFF_KNEKZ],[KNVIFF_GRDZF],[KNVIFF_ZUSKZ],[KNVIFF_GBRKZ],[KNVIFF_MEANT],[KNVIFF_HFBES],[KNVIFF_ANERL],[KNVIFF_BETXT],[KNVIFF_FREI1],[KNVIFF_FREI2],[KNVIFF_FREI3],[KNVIFF_LOEKZ],[KNVIFF_IFNAM],[KNVIFF_DXIFD]) Select * from [#Temp_BAIS_KNVIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KNVIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS KNVIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS KNVIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                    '++++++Only delete file -File is filed with data from PS TOOL
                Case Is = "KRKIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try

                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try
                    '+++++++++++++++++++

                Case Is = "KSRIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS KSRIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS KSRIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_KSRIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_KSRIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_KSRIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_KSRIFF_Temp]([KSRIFF_RKLIF] [varchar](50) NULL,[KSRIFF_RAGEN] [varchar](50) NULL,[KSRIFF_RATYP] [varchar](50) NULL,[KSRIFF_KZHFW] [varchar](50) NULL,[KSRIFF_RATEX] [varchar](50) NULL,[KSRIFF_DXRAT] [varchar](50) NULL,[KSRIFF_LDISO] [varchar](50) NULL,[KSRIFF_IFNAM] [varchar](50) NULL,[KSRIFF_DXIFD] [varchar](50) NULL)  ELSE DELETE FROM [#Temp_BAIS_KSRIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import KSRIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import KSRIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_KSRIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN KSRIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN KSRIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KSRIFF_Temp] ALTER COLUMN [KSRIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN KSRIFF_DXRAT to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN KSRIFF_DXRAT to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_KSRIFF_Temp] ALTER COLUMN [KSRIFF_DXRAT] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_KSRIFF with the same Date in Column:KSRIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_KSRIFF with the same Date in Column:KSRIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_KSRIFF] where [KSRIFF_DXIFD] in (Select distinct [KSRIFF_DXIFD] from [#Temp_BAIS_KSRIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_KNVIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNVIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_KSRIFF]([KSRIFF_RKLIF],[KSRIFF_RAGEN],[KSRIFF_RATYP],[KSRIFF_KZHFW],[KSRIFF_RATEX],[KSRIFF_DXRAT],[KSRIFF_LDISO],[KSRIFF_IFNAM],[KSRIFF_DXIFD]) Select * from [#Temp_BAIS_KSRIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_KSRIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS KSRIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS KSRIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "LQGIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS LQGIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS LQGIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_LQGIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_LQGIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_LQGIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_LQGIFF_Temp]([LQGIFF_MDANT] [varchar](50) NULL,[LQGIFF_MODUL] [varchar](50) NULL,[LQGIFF_KDNRH] [varchar](50) NULL,[LQGIFF_KTONR] [varchar](50) NULL,[LQGIFF_GSREF] [varchar](50) NULL,[LQGIFF_EINLS] [varchar](50) NULL,[LQGIFF_KUNDG] [varchar](50) NULL,[LQGIFF_KUNBT] [varchar](50) NULL,[LQGIFF_EINTY] [varchar](50) NULL,[LQGIFF_BESFI] [varchar](50) NULL,[LQGIFF_RSFFK] [varchar](50) NULL,[LQGIFF_DXBES] [varchar](50) NULL,[LQGIFF_MWSIC] [varchar](50) NULL,[LQGIFF_WHMWS] [varchar](50) NULL,[LQGIFF_ANZKI] [varchar](50) NULL,[LQGIFF_KZABL] [varchar](50) NULL,[LQGIFF_DXBEL] [varchar](50) NULL,[LQGIFF_HOEBL] [varchar](50) NULL,[LQGIFF_WHGBL] [varchar](50) NULL,[LQGIFF_NOMBT] [varchar](50) NULL,[LQGIFF_HAWHG] [varchar](50) NULL,[LQGIFF_KUDIV] [varchar](50) NULL,[LQGIFF_QKRLA] [varchar](50) NULL,[LQGIFF_LIQQU] [varchar](50) NULL,[LQGIFF_KZLCI] [varchar](50) NULL,[LQGIFF_KZFAZ] [varchar](50) NULL,[LQGIFF_LCRK1] [varchar](50) NULL,[LQGIFF_LCRK2] [varchar](50) NULL,[LQGIFF_NSFRK] [varchar](50) NULL,[LQGIFF_CAPIF] [varchar](50) NULL,[LQGIFF_IFNAM] [varchar](50) NULL,[LQGIFF_DXIFD] [varchar](50) NULL)   ELSE DELETE FROM [#Temp_BAIS_LQGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import LQGIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import LQGIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_LQGIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN LQGIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN LQGIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_LQGIFF_Temp] ALTER COLUMN [LQGIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_LQGIFF with the same Date in Column:LQGIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_LQGIFF with the same Date in Column:LQGIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_LQGIFF] where [LQGIFF_DXIFD] in (Select distinct [LQGIFF_DXIFD] from [#Temp_BAIS_LQGIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_KNVIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_KNVIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_LQGIFF]([LQGIFF_MDANT],[LQGIFF_MODUL],[LQGIFF_KDNRH],[LQGIFF_KTONR],[LQGIFF_GSREF],[LQGIFF_EINLS],[LQGIFF_KUNDG],[LQGIFF_KUNBT],[LQGIFF_EINTY],[LQGIFF_BESFI],[LQGIFF_RSFFK],[LQGIFF_DXBES],[LQGIFF_MWSIC],[LQGIFF_WHMWS],[LQGIFF_ANZKI],[LQGIFF_KZABL],[LQGIFF_DXBEL],[LQGIFF_HOEBL],[LQGIFF_WHGBL],[LQGIFF_NOMBT],[LQGIFF_HAWHG],[LQGIFF_KUDIV],[LQGIFF_QKRLA],[LQGIFF_LIQQU],[LQGIFF_KZLCI],[LQGIFF_KZFAZ],[LQGIFF_LCRK1],[LQGIFF_LCRK2],[LQGIFF_NSFRK],[LQGIFF_CAPIF],[LQGIFF_IFNAM],[LQGIFF_DXIFD]) Select * from [#Temp_BAIS_LQGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_LQGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS LQGIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS LQGIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "MKUIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS MKUIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS MKUIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_MKUIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_MKUIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_MKUIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_MKUIFF_Temp]([MKUIFF_MDANT] [varchar](50) NULL,[MKUIFF_WPKNR] [varchar](50) NULL,[MKUIFF_HAWHG] [varchar](50) NULL,[MKUIFF_PREIS] [varchar](50) NULL,[MKUIFF_PREI2] [varchar](50) NULL,[MKUIFF_BEWAB] [varchar](50) NULL,[MKUIFF_BWALA] [varchar](50) NULL,[MKUIFF_CLEAN] [varchar](50) NULL,[MKUIFF_IFNAM] [varchar](50) NULL,[MKUIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_MKUIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import MKUIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import MKUIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_MKUIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN MKUIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN MKUIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_MKUIFF_Temp] ALTER COLUMN [MKUIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_MKUIFF with the same Date in Column:MKUIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_MKUIFF with the same Date in Column:MKUIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_MKUIFF] where [MKUIFF_DXIFD] in (Select distinct [MKUIFF_DXIFD] from [#Temp_BAIS_MKUIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_MKUIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_MKUIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_MKUIFF]([MKUIFF_MDANT],[MKUIFF_WPKNR],[MKUIFF_HAWHG],[MKUIFF_PREIS],[MKUIFF_PREI2],[MKUIFF_BEWAB],[MKUIFF_BWALA],[MKUIFF_CLEAN],[MKUIFF_IFNAM],[MKUIFF_DXIFD]) Select * from [#Temp_BAIS_MKUIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_MKUIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS MKUIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS MKUIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "ZUSIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS ZUSIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS ZUSIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_ZUSIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_ZUSIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_ZUSIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_ZUSIFF_Temp]([ZUSIFF_MDANT] [varchar](50) NULL,[ZUSIFF_FILNR] [varchar](50) NULL,[ZUSIFF_KDNRH] [varchar](50) NULL,[ZUSIFF_ZUREF] [varchar](50) NULL,[ZUSIFF_ZUART] [varchar](50) NULL,[ZUSIFF_KRART] [varchar](50) NULL,[ZUSIFF_MODUL] [varchar](50) NULL,[ZUSIFF_KTONR] [varchar](50) NULL,[ZUSIFF_GSREF] [varchar](50) NULL,[ZUSIFF_ZUEXU] [varchar](50) NULL,[ZUSIFF_WHRGE] [varchar](50) NULL,[ZUSIFF_DXZGA] [varchar](50) NULL,[ZUSIFF_DXVNE] [varchar](50) NULL,[ZUSIFF_DXBSE] [varchar](50) NULL,[ZUSIFF_KZREV] [varchar](50) NULL,[ZUSIFF_KZUNW] [varchar](50) NULL,[ZUSIFF_KZABR] [varchar](50) NULL,[ZUSIFF_WLKKZ] [varchar](50) NULL,[ZUSIFF_KNZZU] [varchar](50) NULL,[ZUSIFF_ZOEKZ] [varchar](50) NULL,[ZUSIFF_KGZUO] [varchar](50) NULL,[ZUSIFF_ZUTYP] [varchar](50) NULL,[ZUSIFF_AUSFL] [varchar](50) NULL,[ZUSIFF_DXAUD] [varchar](50) NULL,[ZUSIFF_KOART] [varchar](50) NULL,[ZUSIFF_GSART] [varchar](50) NULL,[ZUSIFF_RISGR] [varchar](50) NULL,[ZUSIFF_KZUKU] [varchar](50) NULL,[ZUSIFF_ERHGE] [varchar](50) NULL,[ZUSIFF_GSARE] [varchar](50) NULL,[ZUSIFF_HAFIN] [varchar](50) NULL,[ZUSIFF_PRDKT] [varchar](50) NULL,[ZUSIFF_INABU] [varchar](50) NULL,[ZUSIFF_KZAKL] [varchar](50) NULL,[ZUSIFF_FREI1] [varchar](50) NULL,[ZUSIFF_FREI2] [varchar](50) NULL,[ZUSIFF_FREI3] [varchar](50) NULL,[ZUSIFF_FREI4] [varchar](50) NULL,[ZUSIFF_FREI5] [varchar](50) NULL,[ZUSIFF_LOEKZ] [varchar](50) NULL,[ZUSIFF_IFNAM] [varchar](50) NULL,[ZUSIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_ZUSIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import ZUSIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import ZUSIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_ZUSIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN ZUSIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN ZUSIFF_DXZGA to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXZGA to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXZGA] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN ZUSIFF_DXVNE to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXVNE to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXVNE] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN ZUSIFF_DXBSE to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN ZUSIFF_DXBSE to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_ZUSIFF_Temp] ALTER COLUMN [ZUSIFF_DXBSE] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_ZUSIFF with the same Date in Column:ZUSIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_ZUSIFF with the same Date in Column:ZUSIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_ZUSIFF] where [ZUSIFF_DXIFD] in (Select distinct [ZUSIFF_DXIFD] from [#Temp_BAIS_ZUSIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_ZUSIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_ZUSIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_ZUSIFF]([ZUSIFF_MDANT],[ZUSIFF_FILNR],[ZUSIFF_KDNRH],[ZUSIFF_ZUREF],[ZUSIFF_ZUART],[ZUSIFF_KRART],[ZUSIFF_MODUL],[ZUSIFF_KTONR],[ZUSIFF_GSREF],[ZUSIFF_ZUEXU],[ZUSIFF_WHRGE],[ZUSIFF_DXZGA],[ZUSIFF_DXVNE],[ZUSIFF_DXBSE],[ZUSIFF_KZREV],[ZUSIFF_KZUNW],[ZUSIFF_KZABR],[ZUSIFF_WLKKZ],[ZUSIFF_KNZZU],[ZUSIFF_ZOEKZ],[ZUSIFF_KGZUO],[ZUSIFF_ZUTYP],[ZUSIFF_AUSFL],[ZUSIFF_DXAUD],[ZUSIFF_KOART],[ZUSIFF_GSART],[ZUSIFF_RISGR],[ZUSIFF_KZUKU],[ZUSIFF_ERHGE],[ZUSIFF_GSARE],[ZUSIFF_HAFIN],[ZUSIFF_PRDKT],[ZUSIFF_INABU],[ZUSIFF_KZAKL],[ZUSIFF_FREI1],[ZUSIFF_FREI2],[ZUSIFF_FREI3],[ZUSIFF_FREI4],[ZUSIFF_FREI5],[ZUSIFF_LOEKZ],[ZUSIFF_IFNAM],[ZUSIFF_DXIFD]) Select * from [#Temp_BAIS_ZUSIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_ZUSIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS ZUSIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS ZUSIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GAKIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS GAKIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS GAKIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_GAKIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GAKIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GAKIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GAKIFF_Temp]([GAKIFF_MDANT] [varchar](50) NULL,[GAKIFF_GARFN] [varchar](50) NULL,[GAKIFF_FILNR] [varchar](50) NULL,[GAKIFF_GARTG] [varchar](50) NULL,[GAKIFF_GARTI] [varchar](50) NULL,[GAKIFF_HBKZN] [varchar](50) NULL,[GAKIFF_DXVND] [varchar](50) NULL,[GAKIFF_DXBSD] [varchar](50) NULL,[GAKIFF_GABTR] [varchar](50) NULL,[GAKIFF_VWTER] [varchar](50) NULL,[GAKIFF_WHISO] [varchar](50) NULL,[GAKIFF_GSPRZ] [varchar](50) NULL,[GAKIFF_MODUL] [varchar](50) NULL,[GAKIFF_KDNRG] [varchar](50) NULL,[GAKIFF_KTONR] [varchar](50) NULL,[GAKIFF_GSREF] [varchar](50) NULL,[GAKIFF_DEPNR] [varchar](50) NULL,[GAKIFF_KZBVK] [varchar](50) NULL,[GAKIFF_BEBTR] [varchar](50) NULL,[GAKIFF_VEBTR] [varchar](50) NULL,[GAKIFF_VORBT] [varchar](50) NULL,[GAKIFF_OLDSL] [varchar](50) NULL,[GAKIFF_SIGAR] [varchar](50) NULL,[GAKIFF_KRRFN] [varchar](50) NULL,[GAKIFF_HCMPV] [varchar](50) NULL,[GAKIFF_HCWHG] [varchar](50) NULL,[GAKIFF_LIQUD] [varchar](50) NULL,[GAKIFF_RSKFZ] [varchar](50) NULL,[GAKIFF_KZANR] [varchar](50) NULL,[GAKIFF_KZSUB] [varchar](50) NULL,[GAKIFF_KZZWB] [varchar](50) NULL,[GAKIFF_FREI1] [varchar](50) NULL,[GAKIFF_FREI2] [varchar](50) NULL,[GAKIFF_FREI3] [varchar](50) NULL,[GAKIFF_FREI4] [varchar](50) NULL,[GAKIFF_FREI5] [varchar](50) NULL,[GAKIFF_LOEKZ] [varchar](50) NULL,[GAKIFF_IFNAM] [varchar](50) NULL,[GAKIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_GAKIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import GAKIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import GAKIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GAKIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN GAKIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN GAKIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_GAKIFF_Temp] ALTER COLUMN [GAKIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_GAKIFF with the same Date in Column:GAKIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_GAKIFF with the same Date in Column:GAKIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GAKIFF] where [GAKIFF_DXIFD] in (Select distinct [GAKIFF_DXIFD] from [#Temp_BAIS_GAKIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_GAKIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GAKIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_GAKIFF]([GAKIFF_MDANT],[GAKIFF_GARFN],[GAKIFF_FILNR],[GAKIFF_GARTG],[GAKIFF_GARTI],[GAKIFF_HBKZN],[GAKIFF_DXVND],[GAKIFF_DXBSD],[GAKIFF_GABTR],[GAKIFF_VWTER],[GAKIFF_WHISO],[GAKIFF_GSPRZ],[GAKIFF_MODUL],[GAKIFF_KDNRG],[GAKIFF_KTONR],[GAKIFF_GSREF],[GAKIFF_DEPNR],[GAKIFF_KZBVK],[GAKIFF_BEBTR],[GAKIFF_VEBTR],[GAKIFF_VORBT],[GAKIFF_OLDSL],[GAKIFF_SIGAR],[GAKIFF_KRRFN],[GAKIFF_HCMPV],[GAKIFF_HCWHG],[GAKIFF_LIQUD],[GAKIFF_RSKFZ],[GAKIFF_KZANR],[GAKIFF_KZSUB],[GAKIFF_KZZWB],[GAKIFF_FREI1],[GAKIFF_FREI2],[GAKIFF_FREI3],[GAKIFF_FREI4],[GAKIFF_FREI5],[GAKIFF_LOEKZ],[GAKIFF_IFNAM],[GAKIFF_DXIFD]) Select * from [#Temp_BAIS_GAKIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GAKIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS GAKIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS GAKIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "GAGIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS GAGIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS GAGIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_GAGIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_GAGIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_GAGIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_GAGIFF_Temp]([GAGIFF_MDANT] [varchar](50) NULL,[GAGIFF_GARFN] [varchar](50) NULL,[GAGIFF_MODUL] [varchar](50) NULL,[GAGIFF_KDNRH] [varchar](50) NULL,[GAGIFF_GKRKT] [varchar](50) NULL,[GAGIFF_GSREF] [varchar](50) NULL,[GAGIFF_GLFDN] [varchar](50) NULL,[GAGIFF_HCKRA] [varchar](50) NULL,[GAGIFF_KZSUB] [varchar](50) NULL,[GAGIFF_KZZWB] [varchar](50) NULL,[GAGIFF_FREI1] [varchar](50) NULL,[GAGIFF_FREI2] [varchar](50) NULL,[GAGIFF_FREI3] [varchar](50) NULL,[GAGIFF_LOEKZ] [varchar](50) NULL,[GAGIFF_IFNAM] [varchar](50) NULL,[GAGIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_GAGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import GAGIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import GAGIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_GAGIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN GAGIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN GAGIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_GAGIFF_Temp] ALTER COLUMN [GAGIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'Set Correct Value in Field GAGIFF_IFNAM 
                        'SplashScreenManager.Default.SetWaitFormCaption("Set Correct Value in Field GAGIFF_IFNAM")
                        Me.BgwBaisFiles.ReportProgress(40, "Set Correct Value in Field GAGIFF_IFNAM")
                        cmd.CommandText = "UPDATE [#Temp_BAIS_GAGIFF_Temp] SET [GAGIFF_IFNAM]='GAGIFF'"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_GAGIFF with the same Date in Column:GAGIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_GAGIFF with the same Date in Column:GAGIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_GAGIFF] where [GAGIFF_DXIFD] in (Select distinct [GAGIFF_DXIFD] from [#Temp_BAIS_GAGIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_GAGIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_GAGIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_GAGIFF]([GAGIFF_MDANT],[GAGIFF_GARFN],[GAGIFF_MODUL],[GAGIFF_KDNRH],[GAGIFF_GKRKT],[GAGIFF_GSREF],[GAGIFF_GLFDN],[GAGIFF_HCKRA],[GAGIFF_KZSUB],[GAGIFF_KZZWB],[GAGIFF_FREI1],[GAGIFF_FREI2],[GAGIFF_FREI3],[GAGIFF_LOEKZ],[GAGIFF_IFNAM],[GAGIFF_DXIFD]) Select * from [#Temp_BAIS_GAGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_GAGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS GAGIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS GAGIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "LQKIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS LQKIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS LQKIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_LQKIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_LQKIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_LQKIFF_Temp' AND xtype='U') CREATE TABLE [#Temp_BAIS_LQKIFF_Temp]([LQKIFF_MDANT] [varchar](50) NULL,[LQKIFF_KDNRH] [varchar](50) NULL,[LQKIFF_LQSEK] [varchar](50) NULL,[LQKIFF_OBBTG] [varchar](50) NULL,[LQKIFF_KZGBZ] [varchar](50) NULL,[LQKIFF_IFNAM] [varchar](50) NULL,[LQKIFF_DXIFD] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BAIS_LQKIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import LQKIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import LQKIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_LQKIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("ALTER COLUMN LQKIFF_DXIFD to Datetime")
                        Me.BgwBaisFiles.ReportProgress(40, "ALTER COLUMN LQKIFF_DXIFD to Datetime")
                        cmd.CommandText = "ALTER TABLE [#Temp_BAIS_LQKIFF_Temp] ALTER COLUMN [LQKIFF_DXIFD] datetime"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_LQKIFF with the same Date in Column:LQKIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_LQKIFF with the same Date in Column:LQKIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_LQKIFF] where [LQKIFF_DXIFD] in (Select distinct [LQKIFF_DXIFD] from [#Temp_BAIS_LQKIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_LQKIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_LQKIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_LQKIFF]([LQKIFF_MDANT],[LQKIFF_KDNRH],[LQKIFF_LQSEK],[LQKIFF_OBBTG],[LQKIFF_KZGBZ],[LQKIFF_IFNAM],[LQKIFF_DXIFD]) Select * from [#Temp_BAIS_LQKIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_LQKIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS LQKIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS LQKIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                Case Is = "WHGIFF_CCB.csv"
                    BAIS_FILE_DIR = BaisFilesImport & BaisFileName
                    Try
                        'SplashScreenManager.Default.SetWaitFormCaption("Start Import: BAIS WHGIFF")
                        Me.BgwBaisFiles.ReportProgress(10, "Start Import: BAIS WHGIFF")
                        OpenSqlConnections()
                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:#Temp_BAIS_WHGIFF_Temp")
                        Me.BgwBaisFiles.ReportProgress(20, "Create Temporary Table:#Temp_BAIS_WHGIFF_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BAIS_WHGIFF_Temp' AND xtype='U') CREATE TABLE [dbo].[#Temp_BAIS_WHGIFF_Temp]([WHGIFF_MDANT] [varchar](50) NULL,[WHGIFF_WHISO] [varchar](50) NULL,[WHGIFF_WNAME] [varchar](50) NULL,[WHGIFF_WSLZB] [varchar](50) NULL,[WHGIFF_WEINH] [varchar](50) NULL,[WHGIFF_WKLEH] [varchar](50) NULL,[WHGIFF_WNKST] [varchar](50) NULL,[WHGIFF_WSTAT] [varchar](50) NULL,[WHGIFF_MKURS] [float] NULL,[WHGIFF_DXEGK] [datetime] NULL,[WHGIFF_IFNAM] [varchar](50) NULL,[WHGIFF_DXIFD] [datetime] NULL) ELSE DELETE FROM [#Temp_BAIS_WHGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Import WHGIFF File to Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(30, "Import WHGIFF File to Temporary Table")
                        cmd.CommandText = "BULK INSERT  [#Temp_BAIS_WHGIFF_Temp] FROM '" & BAIS_FILE_DIR & "' with (FIRSTROW = 2,fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete all data from BAIS_WHGIFF with the same Date in Column:WHGIFF_DXIFD")
                        Me.BgwBaisFiles.ReportProgress(40, "Delete all data from BAIS_WHGIFF with the same Date in Column:WHGIFF_DXIFD")
                        cmd.CommandText = "DELETE from [BAIS_WHGIFF] where [WHGIFF_DXIFD] in (Select distinct [WHGIFF_DXIFD] from [#Temp_BAIS_WHGIFF_Temp])"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Insert Data from Temporary Table to BAIS_LQKIFF")
                        Me.BgwBaisFiles.ReportProgress(50, "Insert Data from Temporary Table to BAIS_LQKIFF")
                        cmd.CommandText = "INSERT INTO [dbo].[BAIS_WHGIFF]([WHGIFF_MDANT],[WHGIFF_WHISO],[WHGIFF_WNAME],[WHGIFF_WSLZB],[WHGIFF_WEINH],[WHGIFF_WKLEH],[WHGIFF_WNKST],[WHGIFF_WSTAT],[WHGIFF_MKURS],[WHGIFF_DXEGK],[WHGIFF_IFNAM],[WHGIFF_DXIFD]) SELECT * from [#Temp_BAIS_WHGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Drop Temporary Table")
                        Me.BgwBaisFiles.ReportProgress(60, "Drop Temporary Table")
                        cmd.CommandText = "DROP Table [#Temp_BAIS_WHGIFF_Temp]"
                        cmd.ExecuteNonQuery()
                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & BAIS_FILE_DIR)
                        Me.BgwBaisFiles.ReportProgress(70, "Delete File: " & BAIS_FILE_DIR)
                        File.Delete(BAIS_FILE_DIR)
                        'SplashScreenManager.Default.SetWaitFormCaption("BAIS WHGIFF IMPORT finished")
                        Me.BgwBaisFiles.ReportProgress(80, "BAIS WHGIFF IMPORT finished")
                        CloseSqlConnections()

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwBaisFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

            End Select
        Next


    End Sub

    Private Sub BgwBaisFiles_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwBaisFiles.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','" & BaisFileName & "','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & BaisFileName & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & BaisFileName & "','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & BaisFileName & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwBaisFiles_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwBaisFiles.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwBaisFiles, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "CUSTOMER UPDATE OPICS"
    Private Sub BgwOpicsCustUpdateFiles_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwOpicsCustUpdateFiles.DoWork
        Try
            For i = 0 To dir_OpicsFiles.Count - 1
                Dim OpicsCustUpdateFileName As String = dir_OpicsFiles(i).ToString

                If OpicsCustUpdateFileName.StartsWith("OPICS_TO_ODAS_CUST_").ToString = True Then

                    Try

                        OpenSqlConnections()

                        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('OPICS_CUST_DIRECTORY_NEW_TXT_FILE') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
                        Dim OPICS_CUST_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar

                        OPICS_CUST_UPDATE_FILE_DIR = OpicsCustUpdateFilesImport & OpicsCustUpdateFileName

                        If File.Exists(OPICS_CUST_DIRECTORY_NEW_TXT_FILE) = True Then
                            File.Delete(OPICS_CUST_DIRECTORY_NEW_TXT_FILE)
                        End If
                        Dim sr As New System.IO.StreamReader(OPICS_CUST_UPDATE_FILE_DIR)
                        Dim sr1 As System.IO.StreamWriter
                        sr1 = My.Computer.FileSystem.OpenTextFileWriter(OPICS_CUST_DIRECTORY_NEW_TXT_FILE, True)

                        Dim CUSTOMER_NR As String = ""
                        Dim CUSTOMER_CODE As String = ""
                        Dim BIC_CODE As String = ""

                        Dim Zeileninhalt As String = ""
                        'Dim Arr() As String

                        SplashScreenManager.Default.SetWaitFormCaption("Creating file: " & OPICS_CUST_DIRECTORY_NEW_TXT_FILE)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(30, "Creating file: " & OPICS_CUST_DIRECTORY_NEW_TXT_FILE)
                        Do While Not sr.EndOfStream
                            Zeileninhalt = sr.ReadLine().Replace("|@|", " ")
                            'Arr = Zeileninhalt.Split(" ")

                            'Datum = DateSerial(Microsoft.VisualBasic.Right(Arr(0), 4), Mid(Arr(0), 3, 2), Microsoft.VisualBasic.Left(Arr(0), 2))
                            CUSTOMER_NR = Microsoft.VisualBasic.Left(Zeileninhalt, 11)
                            CUSTOMER_CODE = Mid(Zeileninhalt, 13, 10)
                            BIC_CODE = Mid(Zeileninhalt, 24, 11)

                            sr1.WriteLine(CUSTOMER_NR & "|" & CUSTOMER_CODE & "|" & BIC_CODE)

                        Loop

                        sr.Close()
                        sr1.Close()


                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:OPICS_CUST_Temp")
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Create Temporary Table:OPICS_CUST_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUST_Temp' AND xtype='U') CREATE TABLE [dbo].[OPICS_CUST_Temp]([OpicsCustomerNr] [nvarchar](50) NULL,[OpicsCustomerCode] [nvarchar](50) NULL,[OpicsCustomerBIC] [nvarchar](50) NULL) ELSE DELETE FROM [OPICS_CUST_Temp]"
                        cmd.ExecuteNonQuery()
                        'Import Data to Temp Table
                        'SplashScreenManager.Default.SetWaitFormCaption("Import Data to Temp Table")
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Import Data to Temp Table")
                        cmd.CommandText = "BULK INSERT  [dbo].[OPICS_CUST_Temp] FROM '" & OPICS_CUST_DIRECTORY_NEW_TXT_FILE & "' with (fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        CloseSqlConnections()

                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & OPICS_CUST_DIRECTORY_NEW_TXT_FILE)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Delete File: " & OPICS_CUST_DIRECTORY_NEW_TXT_FILE)
                        File.Delete(OPICS_CUST_DIRECTORY_NEW_TXT_FILE)

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                End If


                If OpicsCustUpdateFileName.StartsWith("OPICS_TO_ODAS_CUSI_").ToString = True Then

                    Try
                        OpenSqlConnections()

                        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('OPICS_CUSI_DIRECTORY_NEW_TXT_FILE') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
                        Dim OPICS_CUSI_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar

                        OPICS_CUST_UPDATE_FILE_DIR = OpicsCustUpdateFilesImport & OpicsCustUpdateFileName

                        If File.Exists(OPICS_CUSI_DIRECTORY_NEW_TXT_FILE) = True Then
                            File.Delete(OPICS_CUSI_DIRECTORY_NEW_TXT_FILE)
                        End If
                        Dim sr As New System.IO.StreamReader(OPICS_CUST_UPDATE_FILE_DIR)
                        Dim sr1 As System.IO.StreamWriter
                        sr1 = My.Computer.FileSystem.OpenTextFileWriter(OPICS_CUSI_DIRECTORY_NEW_TXT_FILE, True)

                        Dim CUSTOMER_NR As String = ""
                        Dim CUSTOMER_CODE As String = ""
                        Dim OCBS_CLIENT_NR As String = ""

                        Dim Zeileninhalt As String = ""
                        'Dim Arr() As String

                        'SplashScreenManager.Default.SetWaitFormCaption("Creating file: " & OPICS_CUSI_DIRECTORY_NEW_TXT_FILE)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(30, "Creating file: " & OPICS_CUSI_DIRECTORY_NEW_TXT_FILE)
                        Do While Not sr.EndOfStream
                            Zeileninhalt = sr.ReadLine().Replace("|@|", " ")
                            'Arr = Zeileninhalt.Split(" ")

                            'Datum = DateSerial(Microsoft.VisualBasic.Right(Arr(0), 4), Mid(Arr(0), 3, 2), Microsoft.VisualBasic.Left(Arr(0), 2))
                            CUSTOMER_NR = Microsoft.VisualBasic.Left(Zeileninhalt, 10)
                            CUSTOMER_CODE = Mid(Zeileninhalt, 12, 10)
                            OCBS_CLIENT_NR = Mid(Zeileninhalt, 23, 10)

                            sr1.WriteLine(CUSTOMER_NR & "|" & CUSTOMER_CODE & "|" & OCBS_CLIENT_NR)

                        Loop

                        sr.Close()
                        sr1.Close()


                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:OPICS_CUSI_Temp")
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Create Temporary Table:OPICS_CUSI_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUSI_Temp' AND xtype='U') CREATE TABLE [dbo].[OPICS_CUSI_Temp]([OpicsCustomerNr] [nvarchar](50) NULL,[OpicsBranchCode] [nvarchar](50) NULL,[OcbsCustomerNr] [nvarchar](50) NULL) ELSE DELETE FROM [OPICS_CUSI_Temp]"
                        cmd.ExecuteNonQuery()
                        'Import Data to Temp Table
                        'SplashScreenManager.Default.SetWaitFormCaption("Import Data to Temp Table")
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Import Data to Temp Table")
                        cmd.CommandText = "BULK INSERT  [dbo].[OPICS_CUSI_Temp] FROM '" & OPICS_CUSI_DIRECTORY_NEW_TXT_FILE & "' with (fieldterminator = '|')"
                        cmd.ExecuteNonQuery()

                        CloseSqlConnections()

                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & OPICS_CUSI_DIRECTORY_NEW_TXT_FILE)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Delete File: " & OPICS_CUSI_DIRECTORY_NEW_TXT_FILE)
                        File.Delete(OPICS_CUSI_DIRECTORY_NEW_TXT_FILE)

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                End If


                If OpicsCustUpdateFileName.StartsWith("OPICS_TO_ODAS_FXDH_").ToString = True Then

                    Try
                        OpenSqlConnections()
                        cmd.CommandText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1] in ('OPICS_FXDH_DIRECTORY_NEW_TXT_FILE') and [PARAMETER STATUS] in ('Y') and [IdABTEILUNGSPARAMETER]='MANUAL_IMPORT' and [IdABTEILUNGSCODE_NAME]='EDP'"
                        Dim OPICS_FXDH_DIRECTORY_NEW_TXT_FILE As String = cmd.ExecuteScalar

                        OPICS_CUST_UPDATE_FILE_DIR = OpicsCustUpdateFilesImport & OpicsCustUpdateFileName

                        If File.Exists(OPICS_FXDH_DIRECTORY_NEW_TXT_FILE) = True Then
                            File.Delete(OPICS_FXDH_DIRECTORY_NEW_TXT_FILE)
                        End If
                        Dim sr As New System.IO.StreamReader(OPICS_CUST_UPDATE_FILE_DIR)
                        Dim sr1 As System.IO.StreamWriter
                        sr1 = My.Computer.FileSystem.OpenTextFileWriter(OPICS_FXDH_DIRECTORY_NEW_TXT_FILE, True)

                        Dim BRANCH_NR As String = ""
                        Dim FX_DEAL_NR As String = ""
                        Dim F1 As String = ""
                        Dim OWN_SWAP_MARK As String = ""
                        Dim F2 As String = ""

                        Dim Zeileninhalt As String = ""
                        'Dim Arr() As String

                        'SplashScreenManager.Default.SetWaitFormCaption("Creating file: " & OPICS_FXDH_DIRECTORY_NEW_TXT_FILE)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(30, "Creating file: " & OPICS_FXDH_DIRECTORY_NEW_TXT_FILE)
                        Do While Not sr.EndOfStream
                            Zeileninhalt = sr.ReadLine().Replace("|@|", " ")
                            'Arr = Zeileninhalt.Split(" ")

                            'Datum = DateSerial(Microsoft.VisualBasic.Right(Arr(0), 4), Mid(Arr(0), 3, 2), Microsoft.VisualBasic.Left(Arr(0), 2))
                            BRANCH_NR = Microsoft.VisualBasic.Left(Zeileninhalt, 2)
                            FX_DEAL_NR = Mid(Zeileninhalt, 3, 10)
                            F1 = Mid(Zeileninhalt, 11, 186)
                            OWN_SWAP_MARK = Mid(Zeileninhalt, 200, 16)


                            'MsgBox(BRANCH_NR & "  " & FX_DEAL_NR & "  " & OWN_SWAP_MARK)

                            sr1.WriteLine(BRANCH_NR & "|" & FX_DEAL_NR & "|" & OWN_SWAP_MARK)

                        Loop

                        sr.Close()
                        sr1.Close()


                        'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Table:OPICS_FXDH_Temp")
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Create Temporary Table:OPICS_FXDH_Temp")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_FXDH_Temp' AND xtype='U') CREATE TABLE [dbo].[OPICS_FXDH_Temp]([BRANCH_NR] [nvarchar](50) NULL,[FX_DEAL_NR] [nvarchar](50) NULL,[OWN_SWAP_MARK] [nvarchar](50) NULL) ELSE DELETE FROM [OPICS_FXDH_Temp]"
                        cmd.ExecuteNonQuery()
                        'Import Data to Temp Table
                        'SplashScreenManager.Default.SetWaitFormCaption("Import Data to Temp Table")
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Import Data to Temp Table")
                        cmd.CommandText = "BULK INSERT  [dbo].[OPICS_FXDH_Temp] FROM '" & OPICS_FXDH_DIRECTORY_NEW_TXT_FILE & "' with (fieldterminator = '|')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [OPICS_FXDH_Temp] SET [FX_DEAL_NR]=LTRIM(RTRIM([FX_DEAL_NR])),[OWN_SWAP_MARK]=LTRIM(RTRIM(SUBSTRING([OWN_SWAP_MARK],1,15)))"
                        cmd.ExecuteNonQuery()

                        CloseSqlConnections()

                        'SplashScreenManager.Default.SetWaitFormCaption("Delete File: " & OPICS_FXDH_DIRECTORY_NEW_TXT_FILE)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Delete File: " & OPICS_FXDH_DIRECTORY_NEW_TXT_FILE)
                        File.Delete(OPICS_FXDH_DIRECTORY_NEW_TXT_FILE)

                    Catch ex As Exception
                        'SplashScreenManager.CloseForm(False)
                        CloseSqlConnections()
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.BgwOpicsCustUpdateFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
                    End Try

                End If

                'UPDATE RELATED DATA IN CUSTOMER_INFO
                'SplashScreenManager.Default.SetWaitFormCaption("Update related Data to Table:CUSTOMER_INFO")
                Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Update related Data to Table:CUSTOMER_INFO")
                OpenSqlConnections()
                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUST_Temp' AND xtype='U') and EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUSI_Temp' AND xtype='U') UPDATE A set A.[OpicsCustomerNr]=B.[OpicsCustomerNr],A.[OpicsCustomerCode]=C.[OpicsCustomerCode]from CUSTOMER_INFO A INNER JOIN [OPICS_CUSI_Temp] B on A.ClientNo=B.[OcbsCustomerNr] INNER JOIN [OPICS_CUST_Temp] C on B.[OpicsCustomerNr]=C.[OpicsCustomerNr] where B.[OpicsBranchCode] in ('OCBS21')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUST_Temp' AND xtype='U') and EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUSI_Temp' AND xtype='U') UPDATE A set A.[BIC11]=C.[OpicsCustomerBIC] from CUSTOMER_INFO A INNER JOIN [OPICS_CUSI_Temp] B on A.ClientNo=B.[OcbsCustomerNr] INNER JOIN [OPICS_CUST_Temp] C on B.[OpicsCustomerNr]=C.[OpicsCustomerNr] where B.[OpicsBranchCode] in ('OCBS21') and A.[BIC11] is NULL"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Mark OWN DEALS to Table:FX DAILY REVALUATION")
                Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Mark OWN DEALS to Table:FX DAILY REVALUATION")
                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_FXDH_Temp' AND xtype='U') UPDATE A SET A.OwnDeal='Y' from [FX DAILY REVALUATION] A INNER JOIN [OPICS_FXDH_Temp] B on A.ContractNr=B.[FX_DEAL_NR] where A.DealStatus in ('U') and B.[OWN_SWAP_MARK] in ('BFTSWPFUD')"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("Delete Temporary Tables OPICS_CUST_Temp,OPICS_CUSI_Temp and OPICS_FXDH_Temp")
                Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "Delete Temporary Tables OPICS_CUST_Temp,OPICS_CUSI_Temp and OPICS_FXDH_Temp")
                cmd.CommandText = "DISABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUST_Temp' AND xtype='U') DROP TABLE [OPICS_CUST_Temp] "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_CUSI_Temp' AND xtype='U') DROP TABLE [OPICS_CUSI_Temp] "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='OPICS_FXDH_Temp' AND xtype='U') DROP TABLE [OPICS_FXDH_Temp] "
                cmd.ExecuteNonQuery()
                cmd.CommandText = "ENABLE TRIGGER [TR_ProtectCriticalTables] ON DATABASE"
                cmd.ExecuteNonQuery()
                'SplashScreenManager.Default.SetWaitFormCaption("CUSTOMER UPDATE OPICS finished")
                Me.BgwOpicsCustUpdateFiles.ReportProgress(40, "CUSTOMER UPDATE OPICS finished")
                CloseSqlConnections()
            Next

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            CloseSqlConnections()
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BgwOpicsCustUpdateFiles.ReportProgress(0, "ERROR+++" & ex.Message.Replace("'", ""))
            Exit Sub

        End Try
    End Sub

    Private Sub BgwOpicsCustUpdateFiles_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwOpicsCustUpdateFiles.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','" & OpicsCustUpdateFileName & "','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & OpicsCustUpdateFileName & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','" & OpicsCustUpdateFileName & "','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & OpicsCustUpdateFileName & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwOpicsCustUpdateFiles_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwOpicsCustUpdateFiles.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwOpicsCustUpdateFiles, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT DAILY BALANCE SHEET"
    Private Sub BgwDailyBalanceSheet_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwDailyBalanceSheet.DoWork
        Try
            OpenSqlConnections()
            Dim ExcelFileName As String = DAILY_BALANCE_SHEET_DIR
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
                Dim rd As Date
                rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                Dim rdsql As String = rd.ToString("yyyyMMdd")

                'Blatt 1 - Datumsformat einfügen für Report Date
                Dim rd1 As Date
                xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                rd1 = xlWorksheet1.Range("C1").Value
                Dim rd1sql As String = rd1.ToString("yyyyMMdd")

                xlWorksheet1.Rows("1:4").delete()
                'Unmerge Cells
                xlWorksheet1.Columns("A:A").unMerge()

                'Datum einfügen wo daten vorhanden sind
                Me.BgwDailyBalanceSheet.ReportProgress(3, "Insert Report Date if Column 1 is not NULL")
                'SplashScreenManager.Default.SetWaitFormCaption("Insert Report Date if Column 1 is not NULL")
                For i = 2 To 500
                    If xlWorksheet1.Cells(i, 1).value <> "" Then 'Wenn Type nicht leer ist!
                        xlWorksheet1.Cells(i, 4).Value = rd
                        xlWorksheet1.Cells(i, 5).Value = rd1
                    End If
                Next i

                'Nicht relevante Daten löschen
                Me.BgwDailyBalanceSheet.ReportProgress(4, "Delete Rows if Column 2=AI-D-313")
                'SplashScreenManager.Default.SetWaitFormCaption("Delete Rows if Column 2=AI-D-313")
                For i = 2 To 5000
                    If xlWorksheet1.Cells(i, 2).value = "AI-D-313" Then 'Wenn Type nicht leer ist!
                        xlWorksheet1.Rows(i).Delete()
                    End If
                Next i


                'Nicht relevante Daten löschen
                Me.BgwDailyBalanceSheet.ReportProgress(5, "Delete Rows if Column 2 is NULL")
                'SplashScreenManager.Default.SetWaitFormCaption("Delete Rows if Column 2 is NULL")
                For i = 2 To 5000
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

                Me.BgwDailyBalanceSheet.ReportProgress(6, "Excel File: " & DAILY_BALANCE_SHEET_DIR & " reformated sucesfully")
                'SplashScreenManager.Default.SetWaitFormCaption("Excel File: " & DAILY_BALANCE_SHEET_DIR & " reformated sucesfully")

                'Prüfen ob daten vorhanden sind DETAILS TABELLE
                cmd.CommandText = "DELETE FROM [DailyBalanceSheets] Where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwDailyBalanceSheet.ReportProgress(7, "Insert Data to Table: DAILY BALANCE SHEETS ")
                'SplashScreenManager.Default.SetWaitFormCaption("Insert Data to Table: DAILY BALANCE SHEETS ")
                cmd.CommandText = "INSERT INTO [DailyBalanceSheets]([GL_Item],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [GL_Item],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate] FROM [Sheet1$]')"
                cmd.ExecuteNonQuery()
                'Count Imported Rows
                cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$]')"
                Me.BgwDailyBalanceSheet.ReportProgress(7, cmd.ExecuteScalar & " rows imported in DailyBalanceSheets")


                Me.BgwDailyBalanceSheet.ReportProgress(8, "Update Field:GL_ITEM_NR in DailyBalanceSheet")
                'SplashScreenManager.Default.SetWaitFormCaption("Update Field:GL_ITEM_NR in DailyBalanceSheet")
                cmd.CommandText = "UPDATE [DailyBalanceSheets] SET [GL_Item_Number]=REPLACE([GL_Item],'I','') where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()



                '######################################################################################
                'RILIBI CODES MATCHING
                '######################################################################################
                Me.BgwDailyBalanceSheet.ReportProgress(8, "Matching Rilibi Codes")
                'SplashScreenManager.Default.SetWaitFormCaption("Matching Rilibi Codes")
                cmd.CommandText = "UPDATE A set A.[RilibiCode]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_MATCHING' and [PARAMETER STATUS] ='Y')B ON A.[GL_Item_Number]=B.[PARAMETER1]  where A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                Me.BgwDailyBalanceSheet.ReportProgress(8, "Matching Rilibi Names")
                'SplashScreenManager.Default.SetWaitFormCaption("Matching Rilibi Names")
                cmd.CommandText = "UPDATE A set A.[RilibiName]=B.S from   [DailyBalanceSheets] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='RILIBI_CODES' and [PARAMETER STATUS] ='Y')B ON A.[RilibiCode]=B.[PARAMETER1] where A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


                Me.BgwDailyBalanceSheet.ReportProgress(100, "Import procedure: DAILY BALANCE SHEET finished sucesfully")
                'SplashScreenManager.Default.SetWaitFormCaption("Import procedure: DAILY BALANCE SHEET finished sucesfully")

                File.Delete(DAILY_BALANCE_SHEET_DIR)
            Else
                Me.BgwDailyBalanceSheet.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)

            End If

            CloseSqlConnections()

        Catch ex As Exception
            Me.BgwDailyBalanceSheet.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub

        End Try
    End Sub

    Private Sub BgwDailyBalanceSheet_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwDailyBalanceSheet.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','DAILY BALANCE SHEET IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "DAILY BALANCE SHEET IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','DAILY BALANCE SHEET IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "DAILY BALANCE SHEET IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwDailyBalanceSheet_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwDailyBalanceSheet.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwDailyBalanceSheet, e)
        'SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "IMPORT DAILY BALANCE SHEET DETAILS"
    Private Sub BgwDailyBalanceSheetDetail_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwDailyBalanceSheetDetail.DoWork
        Try
            OpenSqlConnections()
            Dim ExcelFileName As String = DAILY_BALANCE_SHEET__DETAIL_DIR
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
                Dim rd As Date
                rd = DateSerial(Microsoft.VisualBasic.Right(xlWorksheet1.Range("E3").Value, 4), Mid(xlWorksheet1.Range("E3").Value, 11, 2), Mid(xlWorksheet1.Range("E3").Value, 8, 2))
                Dim rdsql As String = rd.ToString("yyyyMMdd")

                'Blatt 1 - Datumsformat einfügen für Report Date
                Dim rd1 As Date
                xlWorksheet1.Range("C1").NumberFormat = "yyyymmdd"
                rd1 = xlWorksheet1.Range("C1").Value
                Dim rd1sql As String = rd1.ToString("yyyyMMdd")

                xlWorksheet1.Rows("1:4").delete()
                'Unmerge Cells
                xlWorksheet1.Columns("A:A").unMerge()

                'Datum einfügen wo daten vorhanden sind
                Me.BgwDailyBalanceSheetDetail.ReportProgress(3, "Insert Report Date if Column 5 is not NULL")
                'SplashScreenManager.Default.SetWaitFormCaption("Insert Report Date if Column 5 is not NULL")

                For i = 2 To 5000
                    If xlWorksheet1.Cells(i, 5).value <> "" Then 'Wenn Type nicht leer ist!
                        xlWorksheet1.Cells(i, 10).Value = rd
                        xlWorksheet1.Cells(i, 11).Value = rd1
                    End If
                Next i

                'Nicht relevante Daten löschen
                Me.BgwDailyBalanceSheetDetail.ReportProgress(4, "Delete Rows if Column 2=AI-D-312")
                'SplashScreenManager.Default.SetWaitFormCaption("Delete Rows if Column 2=AI-D-312")
                For i = 2 To 5000
                    If xlWorksheet1.Cells(i, 2).value = "AI-D-312" Then 'Wenn Type nicht leer ist!
                        xlWorksheet1.Rows(i).Delete()
                    End If
                Next i

                'Nicht relevante Daten löschen
                Me.BgwDailyBalanceSheetDetail.ReportProgress(5, "Delete Rows if Column 5 is NULL")
                'SplashScreenManager.Default.SetWaitFormCaption("Delete Rows if Column 5 is NULL")
                For i = 2 To 5000
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

                Me.BgwDailyBalanceSheetDetail.ReportProgress(6, "Excel File: " & DAILY_BALANCE_SHEET__DETAIL_DIR & "reformated sucesfully")


                'Prüfen ob daten vorhanden sind DETAILS TABELLE
                cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] Where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwDailyBalanceSheetDetail.ReportProgress(7, "Insert Data to Table: DAILY BALANCE DETAIL SHEETS ")
                'SplashScreenManager.Default.SetWaitFormCaption("Insert Data to Table: DAILY BALANCE DETAIL SHEETS ")
                cmd.CommandText = "INSERT INTO [DailyBalanceDetailsSheets]([GL_Item],[ReleatedAccountNr],[GL_Account_Nr],[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [GL_Item],[ReleatedAccountNr],LTRIM(RTRIM([GL_Account_Nr])),[GL_Account_Name],[Orig_CUR],[Orig_Balance],[Balance_EUR_CR],[Balance_EUR_DR],[Total_Balance],[BSDate],[RepDate] FROM [Sheet1$] where [GL_Account_Nr] is not NULL ')"
                cmd.ExecuteNonQuery()
                'Count Imported Rows
                cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where [GL_Account_Nr] is not NULL')"
                Me.BgwDailyBalanceSheetDetail.ReportProgress(7, cmd.ExecuteScalar & " rows imported in DailyBalanceDetailsSheets")



                Me.BgwDailyBalanceSheetDetail.ReportProgress(8, "Update Field:GL_Item_Number in Table Daily Balance Details Sheets")
                'SplashScreenManager.Default.SetWaitFormCaption("Update Field:GL_Item_Number in Table Daily Balance Details Sheets")
                cmd.CommandText = "Update [DailyBalanceDetailsSheets] set [GL_Item_Number]=REPLACE([GL_Item],'I','') where [BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                '######################################################################################
                'GL ART Matching
                '######################################################################################
                Me.BgwDailyBalanceSheetDetail.ReportProgress(8, "Matching GL Art for each Balance Sheet and PL Sheet Item")
                cmd.CommandText = "Select * from [DailyBalanceDetailsSheets] where [BSDate]='" & rdsql & "' begin update [DailyBalanceDetailsSheets] set [GL_Art]='Activa' where [GL_Item_Number]<=2998 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Activa - Off Balance' where [GL_Item_Number]>=8000 and [GL_Item_Number]<=8999 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Passiva' where [GL_Item_Number]>=3000 and [GL_Item_Number]<=4998 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Passiva - Off Balance' where [GL_Item_Number]>=9000 and [GL_Item_Number]<=9999 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Profit + Loss - Income' where [GL_Item_Number]>=5000 and [GL_Item_Number]<=6998 and [BSDate]='" & rdsql & "' end begin update [DailyBalanceDetailsSheets] set [GL_Art]='Profit + Loss - Expenses' where [GL_Item_Number]>=7000 and [GL_Item_Number]<=7998 and [BSDate]='" & rdsql & "' end"
                cmd.ExecuteNonQuery()

                Me.BgwDailyBalanceSheetDetail.ReportProgress(8, "Update Field:IdBalanceSheets,RilibiCode,RilibiName based on GL_ITEM in Table Daily Balance Sheets")
                'SplashScreenManager.Default.SetWaitFormCaption("Update Field:IdBalanceSheets,RilibiCode,RilibiName based on GL_ITEM in Table Daily Balance Sheets")
                cmd.CommandText = "UPDATE A set A.[IdBalanceSheets]=B.[ID],A.[RilibiCode]=B.[RilibiCode],A.[RilibiName]=B.[RilibiName] from [DailyBalanceDetailsSheets] A INNER JOIN [DailyBalanceSheets] B ON A.[GL_Item]=B.[GL_Item] where A.[BSDate]=B.[BSDate] and A.[BSDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwDailyBalanceSheetDetail.ReportProgress(8, "Delete all data if GL Account Nr is NULL")
                'SplashScreenManager.Default.SetWaitFormCaption("Delete all data if GL Account Nr is NULL")
                cmd.CommandText = "DELETE FROM [DailyBalanceDetailsSheets] where [IdBalanceSheets] is NULL"
                cmd.ExecuteNonQuery()

                Me.BgwDailyBalanceSheetDetail.ReportProgress(100, "Import procedure: DAILY BALANCE DETAIL SHEET finished sucesfully")
                'SplashScreenManager.Default.SetWaitFormCaption("Import procedure: DAILY BALANCE DETAIL SHEET finished sucesfully")

                File.Delete(DAILY_BALANCE_SHEET__DETAIL_DIR)
            Else
                Me.BgwDailyBalanceSheetDetail.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                MessageBox.Show("File does not exist in Import Directory - File Name:" & ExcelFileName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            CloseSqlConnections()

        Catch ex As Exception
            Me.BgwDailyBalanceSheetDetail.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub

        End Try
    End Sub

    Private Sub BgwDailyBalanceSheetDetail_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwDailyBalanceSheetDetail.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','DAILY BALANCE SHEET DETAILS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "DAILY BALANCE SHEET DETAILS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','DAILY BALANCE SHEET DETAILS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "DAILY BALANCE SHEET DETAILS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwDailyBalanceSheetDetail_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwDailyBalanceSheetDetail.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwDailyBalanceSheetDetail, e)
        'SplashScreenManager.CloseForm(False)
    End Sub
#End Region

#Region "IMPORT TRIAL BALANCE AVERAGE 222"
    Private Sub BgwTriallBalanceAverage222_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwTriallBalanceAverage222.DoWork
        Try
            Dim rd As Date
            Dim rdsql As String = Nothing
            OpenSqlConnections()
            Dim ExcelFileName As String = TRIAL_BALANCE_AVERAGE_222_DIR
            If File.Exists(ExcelFileName) = True Then
                'Excel Datei Öffnen und Datenformat ändern
                EXCELL = CreateObject("Excel.Application")
                xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                EXCELL.Visible = False
                Me.BgwTriallBalanceAverage222.ReportProgress(30, "Define Report Date from Worksheet:Trial Balance_rate-1")
                'SplashScreenManager.Default.SetWaitFormCaption("Define Report Date from Worksheet:Trial Balance_rate-1")

                xlWorksheet1.Range("B5").NumberFormat = "yyyyMMdd"
                rd = xlWorksheet1.Range("B5").Value
                rdsql = rd.ToString("yyyyMMdd")
                Me.BgwTriallBalanceAverage222.ReportProgress(40, "Reformating Worksheet Nr.3")
                'SplashScreenManager.Default.SetWaitFormCaption("Reformating Worksheet Nr.3")
                xlWorksheet1 = xlWorkBook.Worksheets(3) 'Worksheet 3 - Report Data
                xlWorksheet1.Range("A2").Value = "AccountNo"
                xlWorksheet1.Range("B2").Value = "AccountName"
                xlWorksheet1.Range("D2").Value = "USDequEUR"
                xlWorksheet1.Range("E2").Value = "OtherCurrequEUR"
                xlWorksheet1.Range("F2").Value = "Totals"
                xlWorksheet1.Range("A:A").NumberFormat = "#0"
                'First Row delete
                xlWorksheet1.Rows("1:1").delete()

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
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                Me.BgwTriallBalanceAverage222.ReportProgress(70, "Delete Data in Table TRIAL_BALANCE_222 with RepDate: " & rd)
                'SplashScreenManager.Default.SetWaitFormCaption("Delete Data in Table TRIAL_BALANCE_222 with RepDate: " & rd)
                cmd.CommandText = "DELETE FROM [TRIAL_BALANCE_222] Where [RepDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                'Daten importieren 
                Me.BgwTriallBalanceAverage222.ReportProgress(80, "Start Import Data to table")
                'SplashScreenManager.Default.SetWaitFormCaption("Start Import Data to table")
                cmd.CommandText = "INSERT INTO [TRIAL_BALANCE_222]([AccountNo],[AccountName],[EUR],[USDequEUR],[OtherCurrequEUR],[Totals],[RepDate]) SELECT [AccountNo],[AccountName],[EUR],[USDequEUR],[OtherCurrequEUR],[Totals],'" & rdsql & "' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [页面2-3$]')"
                cmd.ExecuteNonQuery()
                'Count Imported Rows
                cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [页面2-3$]')"
                Me.BgwTriallBalanceAverage222.ReportProgress(7, cmd.ExecuteScalar & " rows imported in TRIAL_BALANCE_222")

                cmd.CommandText = "DELETE FROM [TRIAL_BALANCE_222] where [Totals] is NULL and [RepDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [TRIAL_BALANCE_222] where [AccountName] is NULL and [RepDate]='" & rdsql & "' "
                cmd.ExecuteNonQuery()
                Me.BgwTriallBalanceAverage222.ReportProgress(10, "The Excel File: " & ExcelFileName & " has being imported to Table:TRIAL_BALANCE_222")
                'SplashScreenManager.Default.SetWaitFormCaption("The Excel File: " & ExcelFileName & " has being imported to Table:TRIAL_BALANCE_222")
                'File Delete
                File.Delete(TRIAL_BALANCE_AVERAGE_222_DIR)
            Else
                Me.BgwTriallBalanceAverage222.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                'SplashScreenManager.CloseForm(False)
                MessageBox.Show("File does not exist in Import Directory - File Name:" & ExcelFileName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


            CloseSqlConnections()

        Catch ex As Exception
            Me.BgwTriallBalanceAverage222.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub
        End Try
    End Sub

    Private Sub BgwTriallBalanceAverage222_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwTriallBalanceAverage222.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','TRIAL BALANCE AVERAGE 222 IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "TRIAL BALANCE AVERAGE 222 IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','TRIAL BALANCE AVERAGE 222 IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "TRIAL BALANCE AVERAGE 222 IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwTriallBalanceAverage222_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwTriallBalanceAverage222.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwTriallBalanceAverage222, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "IMPORT ACCRUED INTEREST ANALYSIS"
    Private Sub BgwAccruedInterestAnalysis_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwAccruedInterestAnalysis.DoWork
        Try
            Dim rd As Date
            Dim rdsql As String = Nothing
            Dim rd1 As Date
            Dim rdsql1 As String
            OpenSqlConnections()
            Dim ExcelFileName As String = ACCRUED_INTEREST_ANALYSIS_DIR
            If File.Exists(ExcelFileName) = True Then
                'Excel Datei Öffnen und Datenformat ändern
                EXCELL = CreateObject("Excel.Application")
                xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                EXCELL.Visible = False

                Me.BgwAccruedInterestAnalysis.ReportProgress(40, "Reformating Worksheet")
                'SplashScreenManager.Default.SetWaitFormCaption("Reformating Worksheet")

                xlWorksheet1.Range("B6").Value = "ContractType"
                xlWorksheet1.Range("C6").Value = "ProductType"
                xlWorksheet1.Range("D6").Value = "GlMasterAccountType"
                xlWorksheet1.Range("E6").Value = "Contract"
                xlWorksheet1.Range("F6").Value = "CounterpartyName"
                xlWorksheet1.Range("G6").Value = "CounterpartyNo"
                xlWorksheet1.Range("H6").Value = "TradeDate"
                xlWorksheet1.Range("I6").Value = "StartDate"
                xlWorksheet1.Range("J6").Value = "FinalMaturityDate"
                xlWorksheet1.Range("K6").Value = "OrgCcy"
                xlWorksheet1.Range("L6").Value = "PrincipalOrgCur"
                xlWorksheet1.Range("M6").Value = "PrincipalEurEquivalent"
                xlWorksheet1.Range("N6").Value = "CurrentInterestRate"
                xlWorksheet1.Range("O6").Value = "CurrentInterestCouponPeriodStartDate"
                xlWorksheet1.Range("P6").Value = "CurrentInterestCouponPeriodEndDate"
                xlWorksheet1.Range("Q6").Value = "AccruedInterestCouponOrgCcy"
                xlWorksheet1.Range("R6").Value = "AccruedInterestCouponEUREqu"
                xlWorksheet1.Range("S6").Value = "InterestCouponAmountOrgCcy"
                xlWorksheet1.Range("T6").Value = "InterestCouponAmountEUREqu"

                xlWorksheet1.Range("U6").Value = "RiskDate"
                xlWorksheet1.Range("V6").Value = "RepDate"
                xlWorksheet1.Range("W6").Value = "RepMonth"
                xlWorksheet1.Range("X6").Value = "CheckingDate"
                xlWorksheet1.Columns("U:V").numberformat = "yyyymmdd"
                xlWorksheet1.Columns("W:W").numberformat = "yyyymm"
                xlWorksheet1.Columns("X:X").numberformat = "yyyymmdd"

                Me.BgwAccruedInterestAnalysis.ReportProgress(30, "Define Report Date from Worksheet")
                'SplashScreenManager.Default.SetWaitFormCaption("Define Report Date from Worksheet")

                'Dim newmakdate As String = Replace(Trim(Replace(xlWorksheet1.Range("B3").Value, "As of  ", "")), "-", "")
                'newmakdate = RTrim(LTrim(Replace(newmakdate, " ", "")))
                Dim TempString As String = xlWorksheet1.Range("B3").Value
                Dim newmakdate As String = getNumeric(TempString)


                Me.BgwAccruedInterestAnalysis.ReportProgress(3, "Define Checking Date")
                'Risk Date definieren
                rd = DateSerial(Microsoft.VisualBasic.Right(newmakdate, 4), Microsoft.VisualBasic.Mid(newmakdate, 3, 2), Microsoft.VisualBasic.Left(newmakdate, 2))

                rdsql = rd.ToString("yyyy-MM-dd")
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

                xlWorksheet1.Columns("H:J").numberformat = "yyyymmdd"
                xlWorksheet1.Columns("O:P").numberformat = "yyyymmdd"
                'Rows delete
                xlWorksheet1.Rows("1:5").delete()
                'Unmerge Cells
                xlWorksheet1.Columns("A:A").unMerge()
                'Rename Worksheet
                xlWorksheet1.Name = "Sheet1"

                EXCELL.Application.DisplayAlerts = False
                xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook)
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

                'Alte Daten im IMPORT DATATABLE löschen
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name=#Temp_IMPORT_ACCRUED_INTEREST_Temp AND xtype='U') CREATE TABLE [#Temp_IMPORT_ACCRUED_INTEREST_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[Class] [nvarchar](255) NULL,[Contract Type] [nvarchar](255) NULL,[Product Type] [nvarchar](255) NULL,[GL Master / Account Type] [nvarchar](255) NULL,[Contract] [nvarchar](255) NULL,[Counterparty Name] [nvarchar](255) NULL,[Counterparty No] [nvarchar](255) NULL,[Trade Date][datetime] NULL,[Start Date][datetime] NULL,[Final Maturity Date][datetime] NULL,[Org Ccy] [nvarchar](255) NULL,[Principal (Org  Ccy)] [float] NULL,[Principal (EUR Equivalent)] [float] NULL,[Current Interest Rate] [float] NULL,[Current Interest Coupon Period Start Date][datetime] NULL,[Current Interest Coupon Period End Date][datetime] NULL,[Accrued Interest Coupon Org Ccy] [float] NULL,[Accrued Interest Coupon EUR Equ] [float] NULL,[Interest Coupon amount Org Ccy] [float] NULL,[Interest Coupon Amount EUR Equ] [float] NULL,[Riskdate][datetime] NULL,[RepDate] [datetime] NULL,[RepMonth] [datetime] NULL,[CheckingDate] [datetime] NULL) ELSE DELETE FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp]"
                cmd.ExecuteNonQuery()
                '******************************************************

                cmd.CommandText = "INSERT INTO [#Temp_IMPORT_ACCRUED_INTEREST_Temp]  SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT [Class],[ContractType],[ProductType],[GlMasterAccountType],[Contract],[CounterpartyName],[CounterpartyNo],[TradeDate],[StartDate],[FinalMaturityDate],[OrgCcy],[PrincipalOrgCur],[PrincipalEurEquivalent],[CurrentInterestRate],[CurrentInterestCouponPeriodStartDate],[CurrentInterestCouponPeriodEndDate],[AccruedInterestCouponOrgCcy],[AccruedInterestCouponEUREqu],[InterestCouponAmountOrgCcy],[InterestCouponAmountEUREqu],[Riskdate],[RepDate],[RepMonth],[CheckingDate] FROM [Sheet1$]')"
                cmd.ExecuteNonQuery()
                'Count Imported Rows
                cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$]')"
                Me.BgwAccruedInterestAnalysis.ReportProgress(7, cmd.ExecuteScalar & " rows imported in #Temp_IMPORT_ACCRUED_INTEREST_Temp")

                Me.BgwAccruedInterestAnalysis.ReportProgress(7, "Set RiskDate and RepDate in #Temp_IMPORT_ACCRUED_INTEREST_Temp")
                cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] SET [Riskdate]='" & rdsql & "',[RepDate]= '" & rdsql1 & "'"
                cmd.ExecuteNonQuery()
                Me.BgwAccruedInterestAnalysis.ReportProgress(7, "Set RepMonth in #Temp_IMPORT_ACCRUED_INTEREST_Temp: If RiskDate<>RepDate then RepMonth:01. of RepDate else 01. of RiskDate")
                cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] SET [RepMonth]=CASE when [Riskdate]<>[RepDate] then DATEADD(m, DATEDIFF(m, 0, [RepDate]), 0) when [Riskdate]=[RepDate] then DATEADD(m, DATEDIFF(m, 0, [Riskdate]), 0) end"
                cmd.ExecuteNonQuery()
                Me.BgwAccruedInterestAnalysis.ReportProgress(7, "Set CheckingDate in #Temp_IMPORT_ACCRUED_INTEREST_Temp:01. of next Month from RepMonth")
                cmd.CommandText = "UPDATE [#Temp_IMPORT_ACCRUED_INTEREST_Temp] SET [CheckingDate]=DATEADD(m, DATEDIFF(m, -1, [RepMonth]), 0)"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [Class] like '*%' and [Riskdate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()

                Me.BgwAccruedInterestAnalysis.ReportProgress(7, "ACCRUED INTEREST imported sucessfully")

                '#Temp_IMPORT_ACCRUED_INTEREST_Temp to ACCRUED INTEREST ANALYSIS Table
                cmd.CommandText = "DELETE FROM [ACCRUED INTEREST ANALYSIS] where [Datadate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO [ACCRUED INTEREST ANALYSIS]  SELECT  [Class],[Contract Type],[Product Type],[GL Master / Account Type],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Org Ccy],[Principal (Org  Ccy)],[Principal (EUR Equivalent)],[Current Interest Rate],[Current Interest Coupon Period Start Date],[Current Interest Coupon Period End Date],[Accrued Interest Coupon Org Ccy],[Accrued Interest Coupon EUR Equ],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate] FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [#Temp_IMPORT_ACCRUED_INTEREST_Temp].[Riskdate] not in (Select [Datadate] from [ACCRUED INTEREST ANALYSIS])"
                cmd.ExecuteNonQuery()
                Me.BgwAccruedInterestAnalysis.ReportProgress(7, "ACCRUED INTEREST  imported sucessfully in Table ACCRUED INTEREST ANALYSIS")




                'Update MAK REPORT with the Accrued Interests
                cmd.CommandText = "UPDATE A set A.[Accrued Interest]=B.[Accrued Interest Coupon EUR Equ] from [MAK REPORT ALL DATA] A INNER JOIN [ACCRUED INTEREST ANALYSIS] B ON A.[Contract Collateral ID]=B.[Contract] where A.[RiskDate]=B.[Datadate] and B.[Datadate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE [MAK REPORT ALL DATA] SET [Accrued Interest]=0 where [Accrued Interest] is NULL and [RiskDate]='" & rdsql & "'"
                cmd.ExecuteNonQuery()


                'Importierte Daten wenn Contract Type=SECUR löschen+++KEINE ZINSEN aus SECURITIES in Z14/Z15
                Me.BgwAccruedInterestAnalysis.ReportProgress(6, "Delete Securities (SECUR) from the imported Data")
                cmd.CommandText = "DELETE  FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] Where [Contract Type]='SECUR'"
                cmd.ExecuteNonQuery()
                'Prüfen ob daten vorhanden sind
                Me.BgwAccruedInterestAnalysis.ReportProgress(6, "Checking if data allready imported to Table")
                cmd.CommandText = "SELECT distinct [AIARasof] FROM [AWVz1415RelevantData] Where [AIARasof]='" & rdsql & "'"
                Dim t As String = cmd.ExecuteScalar()
                If IsNothing(t) = False Then
                    Me.BgwAccruedInterestAnalysis.ReportProgress(6, "Data allready are imported to Table - No further action will be executed")
                Else
                    Me.BgwAccruedInterestAnalysis.ReportProgress(8, "Insert Data in AWVz1415RelevantData Table")
                    If rd.ToString("MM.yyyy") <> rd1.ToString("MM.yyyy") Then
                        'Neuanlage in AWV z1415 Relevant Data
                        cmd.CommandText = "INSERT INTO [AWVz1415RelevantData]([Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[OrigCCY],[Interest Coupon Amount OrigCCY],[Interest Coupon Amount EUR Equ],[AIARasof],[AIARrepdate],[CheckingDate],[IdZ14Z15Meldemonat])Select [Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Org Ccy],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[CheckingDate],[RepMonth] FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [Current Interest Coupon Period End Date]<[CheckingDate]"
                        cmd.ExecuteNonQuery()
                    ElseIf rd.ToString("MM.yyyy") = rd1.ToString("MM.yyyy") Then
                        cmd.CommandText = "INSERT INTO [AWVz1415RelevantData]([Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[OrigCCY],[Interest Coupon Amount OrigCCY],[Interest Coupon Amount EUR Equ],[AIARasof],[AIARrepdate],[CheckingDate],[IdZ14Z15Meldemonat])Select [Class],[Contract],[Counterparty Name],[Counterparty No],[Trade Date],[Start Date],[Final Maturity Date],[Current Interest Coupon Period End Date],[Org Ccy],[Interest Coupon amount Org Ccy],[Interest Coupon Amount EUR Equ],[Riskdate],[RepDate],[CheckingDate],[RepMonth] FROM [#Temp_IMPORT_ACCRUED_INTEREST_Temp] where [Current Interest Coupon Period End Date]<[CheckingDate] and [Contract] not in (Select [Contract] from [AWVz1415RelevantData])"
                        cmd.ExecuteNonQuery()
                    End If

                    '##############################################################
                    Me.BgwAccruedInterestAnalysis.ReportProgress(9, "Matching Country Codes with Customers Info Table")
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
                    Me.BgwAccruedInterestAnalysis.ReportProgress(9, "Handling Negative Interests-Set Internal Info=Negative Interest where  Interest Coupon Amount EUR Equ<0")
                    cmd.CommandText = "Update [AWVz1415RelevantData] set [InternalInfo]='Negative Interest' where [Interest Coupon Amount EUR Equ]<0 and [AIARasof]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '#######################################################################################

                    'Prüfen ob daten vorhanden sind
                    Dim MeldeMonatSql As String = MeldeMonat.ToString("yyyy-MM-dd")
                    cmd.CommandText = "SELECT distinct [Z14Z15MeldeMonat] FROM [AWVz14z15] Where [Z14Z15MeldeMonat]='" & MeldeMonatSql & "'"
                    Dim t1 As String = cmd.ExecuteScalar()

                    If IsNothing(t1) = True Then
                        Me.BgwAccruedInterestAnalysis.ReportProgress(10, "Insert into AWVz14 Table")
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

                        '######################################################################################################
                        'Füllen der Z15
                        'Länder und Währungen
                        Me.BgwAccruedInterestAnalysis.ReportProgress(11, "Insert into AWVz15 Table")
                        cmd.CommandText = "INSERT INTO [AWVz15]([COUNTRY CODE],[COUNTRY NAME],[LANDKZ],[COUNTRY NAME DE])Select[COUNTRY CODE],[COUNTRY NAME],[LANDKZ BUBA],[COUNTRY NAME DE]FROM [COUNTRIES]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [AWVz15] SET [CLASS]='LIABILITIES',[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' where [IdZ14Z15Meldemonat] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz15] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [AWVz15] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                        cmd.ExecuteNonQuery()


                    Else
                        'Summen für AZW Z14 und Z15 auf NULL Stellen
                        Me.BgwAccruedInterestAnalysis.ReportProgress(12, "Set CountrySumAmount to zero")
                        cmd.CommandText = "UPDATE [AWVz14] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [AWVz15] SET [CountrySumAmount]=0 where [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "' "
                        cmd.ExecuteNonQuery()
                        Me.BgwAccruedInterestAnalysis.ReportProgress(12, "Recalculate Country Sums for AWVz14")
                        cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz14] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Assets' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [AWVz14] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                        cmd.ExecuteNonQuery()
                        Me.BgwAccruedInterestAnalysis.ReportProgress(12, "Recalculate Country Sums for AWVz15")
                        cmd.CommandText = "UPDATE A SET A.[CountrySumAmount]=B.S from [AWVz15] A INNER JOIN (Select [CountryCode],SUM([Interest Coupon Amount EUR Equ]) as S from [AWVz1415RelevantData] where [Class]='Liabilities' and [IdZ14Z15Meldemonat]= '" & MeldeMonatSql & "' GROUP BY [CountryCode])B on A.[COUNTRY CODE]=B.CountryCode where A.[IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [AWVz15] set [CountrySumAmount]=0 where [CountrySumAmount] is NULL and [IdZ14Z15Meldemonat]='" & MeldeMonatSql & "'"
                        cmd.ExecuteNonQuery()

                    End If

                End If


                'löschen der IMPORT Tabelle
                cmd.CommandText = "DROP TABLE [#Temp_IMPORT_ACCRUED_INTEREST_Temp]"
                cmd.ExecuteNonQuery()

                'File Delete
                File.Delete(ACCRUED_INTEREST_ANALYSIS_DIR)
            Else
                Me.BgwAccruedInterestAnalysis.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                'SplashScreenManager.CloseForm(False)
                MessageBox.Show("File does not exist in Import Directory - File Name:" & ExcelFileName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            CloseSqlConnections()

        Catch ex As Exception
            Me.BgwAccruedInterestAnalysis.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub
        End Try
    End Sub

    Private Sub BgwAccruedInterestAnalysis_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwAccruedInterestAnalysis.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','ACCRUED INTEREST ANALYSIS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ACCRUED INTEREST ANALYSIS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','ACCRUED INTEREST ANALYSIS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "ACCRUED INTEREST ANALYSIS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwAccruedInterestAnalysis_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwAccruedInterestAnalysis.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwAccruedInterestAnalysis, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "USER PERMISSIONS IMPORT"
    Private Sub BgwUserPermissions_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwUserPermissions.DoWork
        Try

            If dir_UserPermissionsFiles.Count > 0 Then
                OpenSqlConnections()
                cmd.CommandTimeout = 60000

                'Create Temporary Tables
                Me.BgwUserPermissions.ReportProgress(40, "Create Temporary Tables in SQL Server")
                'SplashScreenManager.Default.SetWaitFormCaption("Create Temporary Tables in SQL Server")

                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ActiveDirectoryUsersBankSystems_Temp' AND xtype='U') CREATE TABLE [#Temp_ActiveDirectoryUsersBankSystems_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[System] [nvarchar](100) NULL,[UserID] [nvarchar](200) NULL,[UserName] [nvarchar](100) NULL,[UserLoginName] [nvarchar](100) NULL,[UserLevel] [nvarchar](100) NULL,[UserTypeCode] [nvarchar](100) NULL,[UserStatus] [nvarchar](100) NULL) ELSE DELETE FROM [#Temp_ActiveDirectoryUsersBankSystems_Temp]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp' AND xtype='U') CREATE TABLE [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[System] [nvarchar](50) NULL,[UserID] [nvarchar](200) NULL,[FunctionOperationType] [nvarchar](255) NULL,[FunctionRoleCode] [nvarchar](255) NULL,[EffectiveDate] [datetime] NULL,[ExpiryDate] [datetime] NULL,[FunctionRoleOperation_ID] [nvarchar](255) NULL) ELSE DELETE FROM [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_BaisBenutzerRollen_Temp' AND xtype='U') CREATE TABLE [#Temp_BaisBenutzerRollen_Temp]([Benutzer] [varchar](50) NULL,[Name] [varchar](50) NULL,[Gruppe] [varchar](50) NULL,[Abteilung   Org Einheit] [varchar](50) NULL,[Benutzerrolle] [varchar](50) NULL,[Rollenbezeichnung] [varchar](50) NULL,[Column 6] [varchar](50) NULL) ELSE DELETE FROM [#Temp_BaisBenutzerRollen_Temp]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ODAS_User_Advanced_Temp' AND xtype='U') CREATE TABLE [#Temp_ODAS_User_Advanced_Temp]([User NO#] [float] NULL,[Channel name] [nvarchar](255) NULL,[User Name] [nvarchar](255) NULL,[User Id] [nvarchar](255) NULL,[Institutions management level] [nvarchar](255) NULL,[User Level] [nvarchar](255) NULL) ELSE DELETE FROM [#Temp_ODAS_User_Advanced_Temp]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ODAS_User_Static_Temp' AND xtype='U') CREATE TABLE [#Temp_ODAS_User_Static_Temp]([User No#] [float] NULL,[Login type] [nvarchar](255) NULL,[Branch Name] [nvarchar](255) NULL,[User Name] [nvarchar](255) NULL,[User ID] [nvarchar](255) NULL,[Office phone] [nvarchar](255) NULL,[Mobile phone] [nvarchar](255) NULL,[Email] [nvarchar](255) NULL,[User status] [nvarchar](255) NULL)  ELSE DELETE FROM [#Temp_ODAS_User_Static_Temp]"
                cmd.ExecuteNonQuery()
                For y = 0 To dir_UserPermissionsFiles.Count - 1
                    USER_PERMISSIONS_DIR = dir_UserPermissionsFiles.Item(y).ToString

                    Dim ExcelFileName As String = USER_PERMISSIONS_DIR
                    Dim ExcelFileNameOnly As String = System.IO.Path.GetFileName(ExcelFileName)

                    If File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString = "ALLADGroupsUsers.csv" = True Then
                        Me.BgwUserPermissions.ReportProgress(40, "File: ALLADGroupsUsers.csv exists - Import Active Directory Users and Groups")
                        'SplashScreenManager.Default.SetWaitFormCaption("File: ALLADGroupsUsers.csv exists - Import Active Directory Users and Groups")
                        cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_ActiveDirectoryUsers_Temp' AND xtype='U') CREATE TABLE [#Temp_ActiveDirectoryUsers_Temp]([AD_Group_Name] [nvarchar](50) NULL,[Member_Name] [nvarchar](50) NULL,[AccountStatus] [nvarchar](50) NULL) ELSE DELETE FROM [#Temp_ActiveDirectoryUsers_Temp]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "BULK INSERT  [#Temp_ActiveDirectoryUsers_Temp] FROM '" & USER_PERMISSIONS_DIR & "' with (FIRSTROW = 2,fieldterminator = ';')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [ActiveDirectoryUsers]([Member_Name],[AccountStatus]) Select distinct [Member_Name],[AccountStatus] from [#Temp_ActiveDirectoryUsers_Temp] where [Member_Name] not in (Select [Member_Name] from [ActiveDirectoryUsers]) and [AD_Group_Name] in ('Domänen-Benutzer')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = " UPDATE A SET A.[AccountStatus]=B.[AccountStatus] from [ActiveDirectoryUsers] A INNER JOIN [#Temp_ActiveDirectoryUsers_Temp] B on A.[Member_Name]=B.[Member_Name] and B.[AccountStatus] not in ('n.a.')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO [ActiveDirectoryGroups]([AD_Group_Name],[Member_Name],[AccountStatus]) Select [AD_Group_Name],[Member_Name],[AccountStatus] from [#Temp_ActiveDirectoryUsers_Temp] where [AD_Group_Name]+[Member_Name] not in (Select [AD_Group_Name]+[Member_Name] from [ActiveDirectoryGroups]) and [AccountStatus] not in ('n.a.') and [Member_Name] in (Select [Member_Name] from [ActiveDirectoryUsers])"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = " UPDATE A SET A.[Id_ActiveDirectoryUser]=B.[ID] from [ActiveDirectoryGroups] A INNER JOIN [ActiveDirectoryUsers] B on A.[Member_Name]=B.[Member_Name] where A.[Id_ActiveDirectoryUser] is NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = " UPDATE A SET A.[AccountStatus]=B.[AccountStatus] from [ActiveDirectoryGroups] A INNER JOIN [#Temp_ActiveDirectoryUsers_Temp] B on A.[AD_Group_Name]+ A.[Member_Name]=B.[AD_Group_Name] + B.[Member_Name]"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "DROP TABLE [#Temp_ActiveDirectoryUsers_Temp]"
                        cmd.ExecuteNonQuery()

                        QueryText = "Select * from [ActiveDirectoryUsers] where [ID] not in (Select [Id_ActiveDirectoryUser] from [ActiveDirectoryUsersBankSystems])"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            Dim ID As Integer = dt.Rows.Item(i).Item("ID")
                            cmd.CommandText = "INSERT INTO [ActiveDirectoryUsersBankSystems] ([System],[Id_ActiveDirectoryUser]) Select [PARAMETER2]," & ID & " from [PARAMETER] where [PARAMETER1]='BankSystem' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='BANK_SYSTEMS' order by ID asc"
                            cmd.ExecuteNonQuery()
                        Next

                        QueryText = "Select [PARAMETER2] from [PARAMETER] where [PARAMETER1]='BankSystem' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='BANK_SYSTEMS' and [PARAMETER2] not in (Select [System] from [ActiveDirectoryUsersBankSystems])"
                        da = New SqlDataAdapter(QueryText.Trim(), conn)
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        For i = 0 To dt.Rows.Count - 1
                            Dim System As String = dt.Rows.Item(i).Item("PARAMETER2")

                            QueryText = "Select [Id_ActiveDirectoryUser] from [ActiveDirectoryUsersBankSystems] where [System] not in ('" & System & "') GROUP BY [Id_ActiveDirectoryUser]"
                            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
                            dt1 = New System.Data.DataTable()
                            da1.Fill(dt1)
                            For x = 0 To dt1.Rows.Count - 1
                                Dim ID As Integer = dt1.Rows.Item(x).Item("Id_ActiveDirectoryUser")
                                cmd.CommandText = "INSERT INTO [ActiveDirectoryUsersBankSystems] ([System],[Id_ActiveDirectoryUser]) Values ('" & System & "'," & ID & ")"
                                cmd.ExecuteNonQuery()
                            Next
                        Next
                        'File.Delete(USER_PERMISSIONS_DIR)

                        'OCBS-GMPS IMPORT OLD CODE
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString = "GMPS OCBS User Permissions.xlsx" Then
                        'Me.BgwUserPermissions.ReportProgress(40, "File: GMPS OCBS User Permissions.xlsx exists - Import OCBS and GMPS Users and Permissions")
                        'SplashScreenManager.Default.SetWaitFormCaption("File: GMPS OCBS User Permissions.xlsx exists - Import OCBS and GMPS Users and Permissions")
                        'cmd.CommandText = "INSERT INTO [dbo].[#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus])SELECT 'OCBS' as 'System',LTRIM(RTRIM(A.[      User ID   ])) as 'UserID',A.[User Name(Local)] as 'UserName',LTRIM(RTRIM(A.[      User ID   ])) as 'UserLoginName',A.[User Level] as 'UserLevel',A.[User Type] as 'UserTypeCode',A.[User Status] as 'UserStatus' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [OCBS_Users$]')A  UNION ALL SELECT 'GMPS' as 'System',LTRIM(RTRIM(A.[Userid])) as 'UserID',A.[User Name] as 'UserName',A.[User Nickname] as 'UserLoginName',A.[User Rating] as 'UserLevel',A.[Department Code] as 'UserTypeCode',A.[Active Flag] as 'UserStatus' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [GMPS_Users$]')A  where [Processed by] like 'DEFF%'"
                        'cmd.ExecuteNonQuery()
                        'cmd.CommandText = "INSERT INTO [dbo].[#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([System],[UserID],[FunctionOperationType],[FunctionRoleCode],[EffectiveDate],[ExpiryDate]) SELECT 'OCBS' as 'System',[Access ID] as 'UserID',[Privilege Type] as 'FunctionOperationType',[Role Code] as 'FunctionRoleCode',Convert(datetime,right([Effective Date],4) + SUBSTRING([Effective Date],4,2)+LEFT([Effective Date],2)) as 'EfectiveDate',Convert(datetime,right([Expiry Date],4) + SUBSTRING([Expiry Date],4,2)+LEFT([Expiry Date],2)) as 'ExpiryDate' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [OCBS_User_Perm$]')A where [Access Type] in ('T - USER') UNION ALL SELECT 'GMPS' as 'System',LTRIM(RTRIM(F1)) as 'UserID',F2 as 'FunctionOperationType',F3 as 'FunctionRoleCode',NULL as 'EffectiveDate',NULL as 'ExpiryDate' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=NO;Database=" & ExcelFileName & ";','SELECT * FROM [GMPS_User_Perm$]') where [F1] like '%DEFF%' and [F1] not like '%DEFFR%'"
                        'cmd.ExecuteNonQuery()
                        'File.Delete(USER_PERMISSIONS_DIR)

                        'OCBS
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("OCBS_Users") = True Then
                        '    Me.BgwUserPermissions.ReportProgress(40, "File: OCBS_Users.xls exists - Import OCBS Users")
                        '    SplashScreenManager.Default.SetWaitFormCaption("File: OCBS_Users.xls exists - Import OCBS Users")
                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus])SELECT 'OCBS' as 'System',LTRIM(RTRIM([      User ID   ])) as 'UserID',[User Name(Local)] as 'UserName',LTRIM(RTRIM([      User ID   ])) as 'UserLoginName',[User Level] as 'UserLevel',[User Type] as 'UserTypeCode',[User Status] as 'UserStatus' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet0$]')"
                        '    cmd.ExecuteNonQuery()
                        '    File.Delete(USER_PERMISSIONS_DIR)
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("OCBS_User_Roles.") = True Then
                        '    Me.BgwUserPermissions.ReportProgress(40, "File: OCBS_User_Roles.xls exists - Import OCBS_User_Roles")
                        '    SplashScreenManager.Default.SetWaitFormCaption("File: OCBS_User_Roles.xls exists - Import User_Roles")
                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([System],[UserID],[FunctionOperationType],[FunctionRoleCode],[EffectiveDate],[ExpiryDate]) SELECT 'OCBS' as 'System',[Access ID] as 'UserID',[Privilege Type] as 'FunctionOperationType',[Role Code] as 'FunctionRoleCode',Convert(datetime,right([Effective Date],4) + SUBSTRING([Effective Date],4,2)+LEFT([Effective Date],2)) as 'EfectiveDate',Convert(datetime,right([Expiry Date],4) + SUBSTRING([Expiry Date],4,2)+LEFT([Expiry Date],2)) as 'ExpiryDate' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet0$]')A where [Access Type] in ('T - USER')"
                        '    cmd.ExecuteNonQuery()
                        '    File.Delete(USER_PERMISSIONS_DIR)
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("OCBS_User_Roles_Authorization") = True Then
                        '    Me.BgwUserPermissions.ReportProgress(40, "File: OCBS_User_Roles_Authorization.xls exists - Import OCBS_User_Roles_Authorization")
                        '    SplashScreenManager.Default.SetWaitFormCaption("File: OCBS_User_Roles_Authorization.xls exists - Import OCBS_User_Roles_Authorization")
                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([System],[UserID],[FunctionOperationType],[FunctionRoleCode],[EffectiveDate],[ExpiryDate]) SELECT 'OCBS' as 'System',[Access ID] as 'UserID',[Privilege Type] as 'FunctionOperationType',[Role Code] as 'FunctionRoleCode',Convert(datetime,right([Effective Date],4) + SUBSTRING([Effective Date],4,2)+LEFT([Effective Date],2)) as 'EfectiveDate',Convert(datetime,right([Expiry Date],4) + SUBSTRING([Expiry Date],4,2)+LEFT([Expiry Date],2)) as 'ExpiryDate' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet0$]')A where [Access Type] in ('T - USER')"
                        '    cmd.ExecuteNonQuery()
                        '    File.Delete(USER_PERMISSIONS_DIR)

                        'NGS
                    ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("NGS_User") = True Then
                        Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                        workbook.LoadDocument(ExcelFileName, DocumentFormat.Xls)
                        Dim worksheet As Worksheet = workbook.Worksheets(0)
                        worksheet.Cells("A1").Value = "UserNumber"
                        worksheet.Cells("B1").Value = "UserName"
                        worksheet.Cells("C1").Value = "UserStatus"
                        worksheet.Cells("D1").Value = "UserType"
                        worksheet.Cells("E1").Value = "InstitutionNr"
                        worksheet.Cells("F1").Value = "InstitutionName"
                        worksheet.Cells("G1").Value = "InstitutionEnglishName"
                        worksheet.Cells("H1").Value = "PostNumber"
                        worksheet.Cells("I1").Value = "PostName"
                        worksheet.Cells("J1").Value = "PostEnglishName"
                        worksheet.Cells("K1").Value = "PostOwnerInstitutionNumber"
                        worksheet.Cells("L1").Value = "PostOwnerInstitution"
                        worksheet.Cells("M1").Value = "PostOwnerInstitutionEnglishName"
                        worksheet.Cells("N1").Value = "LockState"
                        worksheet.Cells("O1").Value = "PostEffectiveDate"
                        worksheet.Cells("P1").Value = "RoleNumber"
                        worksheet.Cells("Q1").Value = "RoleName"
                        worksheet.Cells("R1").Value = "RoleEnglishName"
                        worksheet.Cells("S1").Value = "RoleEffectiveDate"
                        worksheet.Cells("T1").Value = "RolesInComponent"
                        workbook.SaveDocument(ExcelFileName, DocumentFormat.Xls)
                        Me.BgwUserPermissions.ReportProgress(40, "File: NGS_User.xls exists - Import NGS Users")
                        'SplashScreenManager.Default.SetWaitFormCaption("File: NGS_User.xls exists - Import NGS Users")
                        cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus])SELECT 'NGS' as 'System',[UserNumber], dbo.GetStringPartByDelimeter([UserName],'_',1) as 'User Name', dbo.GetStringPartByDelimeter([UserName],'_',1) as 'User Login Name','USER' as 'UserLevel',[UserType] as 'UserTypeCode',[UserStatus] FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [1$]') where LEN([InstitutionEnglishName])<>0 and [UserNumber] not in ('75207921') and 'NGS'+[UserNumber] not in (Select system+UserID from #Temp_ActiveDirectoryUsersBankSystems_Temp where system in ('NGS')) GROUP BY [UserNumber],[UserName],[UserType],[UserStatus]"
                        cmd.ExecuteNonQuery()
                        Me.BgwUserPermissions.ReportProgress(40, "File: NGS_User.xls exists - Import NGS User Permissions")
                        'SplashScreenManager.Default.SetWaitFormCaption("File: NGS_User.xls exists - Import NGS User Permissions")
                        cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([System],[UserID],[FunctionOperationType],[FunctionRoleCode],[EffectiveDate],[ExpiryDate]) SELECT 'NGS',UserNumber,PostNumber + ' - ' + PostEnglishName,RoleNumber + ' - ' + RoleEnglishName, convert(datetime,PostEffectiveDate,112),NULL FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [1$]') where LEN([InstitutionEnglishName])<>0 and [UserNumber] not in ('75207921') and 'NGS'+UserNumber+PostNumber + ' - ' + PostEnglishName+RoleNumber + ' - ' + RoleEnglishName not in (Select [System]+[UserID]+[FunctionOperationType]+[FunctionRoleCode] from [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp] where System in ('NGS'))"
                        cmd.ExecuteNonQuery()
                        File.Delete(USER_PERMISSIONS_DIR)

                        'GMPS
                    ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("GMPS_Users") = True Then
                        Me.BgwUserPermissions.ReportProgress(40, "File: GMPS_Users.xls exists - Import GMPS_Users")
                        'SplashScreenManager.Default.SetWaitFormCaption("File: GMPS_Users.xls exists - Import GMPS_Users")
                        cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus]) SELECT 'GMPS' as 'System',LTRIM(RTRIM(A.[Userid])) as 'UserID',A.[User Name] as 'UserName',A.[User Nickname] as 'UserLoginName',A.[User Rating] as 'UserLevel',A.[Department Code] as 'UserTypeCode',A.[Active Flag] as 'UserStatus' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]')A  where [Processed by] like 'DEFF%'"
                        cmd.ExecuteNonQuery()
                        File.Delete(USER_PERMISSIONS_DIR)
                    ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("GMPS_User_Permissions") = True Then
                        Me.BgwUserPermissions.ReportProgress(40, "File: GMPS_User_Permissions.xls exists - Import GMPS_User_Permissions.xls")
                        'SplashScreenManager.Default.SetWaitFormCaption("File: GMPS_User_Permissions.xls exists - Import GMPS_User_Permissions.xls")
                        cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([System],[UserID],[FunctionOperationType],[FunctionRoleCode],[EffectiveDate],[ExpiryDate])SELECT 'GMPS' as 'System',LTRIM(RTRIM(F1)) as 'UserID',F2 as 'FunctionOperationType',F3 as 'FunctionRoleCode',NULL as 'EffectiveDate',NULL as 'ExpiryDate' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=NO;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]') where [F1] like '%DEFF%' and [F1] not like '%DEFFR%'"
                        cmd.ExecuteNonQuery()
                        File.Delete(USER_PERMISSIONS_DIR)

                        'ODAS
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("ODAS_User") = True Then  ' = "ODAS_User.xlsx" Then
                        '    Me.BgwUserPermissions.ReportProgress(40, "File: ODAS_User.xlsx exists - Import ODAS Users and Permissions")
                        '    SplashScreenManager.Default.SetWaitFormCaption("File: ODAS_User.xlsx exists - Import ODAS Users and Permissions")
                        '    cmd.CommandText = "INSERT INTO [#Temp_ODAS_User_Advanced_Temp]([User NO#],[Channel name],[User Name],[User Id],[Institutions management level],[User Level]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [ODAS_User_Advanced$]')"
                        '    cmd.ExecuteNonQuery()
                        '    cmd.CommandText = "INSERT INTO [#Temp_ODAS_User_Static_Temp]([User No#],[Login type],[Branch Name],[User Name],[User ID],[Office phone],[Mobile phone],[Email],[User status]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [ODAS_User_Static$]')"
                        '    cmd.ExecuteNonQuery()

                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus])Select A.[Channel name],A.[User Id],A.[User Name],LTRIM(RTRIM(STR(A.[User NO#],18))),A.[User Level],A.[Institutions management level]+'  ' + B.[Login type] as 'UserTypeCode',B.[User status] from [#Temp_ODAS_User_Advanced_Temp] A INNER JOIN [#Temp_ODAS_User_Static_Temp] B on A.[User NO#]=B.[User No#]"
                        '    cmd.ExecuteNonQuery()
                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus])Select 'ODAS' as 'System',[User No#],[User Name],LTRIM(RTRIM(STR([User No#],18))),NULL as 'UserLevel',[Login type],[User status] from [#Temp_ODAS_User_Static_Temp] where [User No#] not in (Select [User NO#] from [#Temp_ODAS_User_Advanced_Temp])"
                        '    cmd.ExecuteNonQuery()
                        '    File.Delete(USER_PERMISSIONS_DIR)

                        'BAIS
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString = "BaisBenutzerRollen.csv" Then
                        '    Me.BgwUserPermissions.ReportProgress(40, "File: BaisBenutzerRollen.csv exists - Import BAIS Users")
                        '    SplashScreenManager.Default.SetWaitFormCaption("File:File: BaisBenutzerRollen.csv exists - Import BAIS Users")
                        '    cmd.CommandText = "BULK INSERT  [#Temp_BaisBenutzerRollen_Temp] FROM '" & USER_PERMISSIONS_DIR & "' with (FIRSTROW = 2,fieldterminator = ';')"
                        '    cmd.ExecuteNonQuery()
                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus]) SELECT 'BAIS' as 'System',LTRIM(RTRIM([Benutzer])) as 'UserID',[Name] as 'UserName',LTRIM(RTRIM([Benutzer])) as 'UserLoginName',[Gruppe] + ' - ' + [Benutzerrolle] as 'UserLevel',[Rollenbezeichnung] as 'UserTypeCode','Active' as 'UserStatus' FROM [#Temp_BaisBenutzerRollen_Temp]"
                        '    cmd.ExecuteNonQuery()
                        '    File.Delete(USER_PERMISSIONS_DIR)
                        'ElseIf File.Exists(ExcelFileName) = True AndAlso ExcelFileNameOnly.ToString.StartsWith("BRECHFUser") = True Then   ' = "BRECHFUser.xls" Then
                        '    Me.BgwUserPermissions.ReportProgress(40, "File: BRECHFUser.xls exists - Import BAIS Users and Permissions")
                        '    SplashScreenManager.Default.SetWaitFormCaption("File: BRECHFUser.xls exists - Import BAIS Users and Permissions")
                        '    'Excel Datei Öffnen und Datenformat ändern
                        '    EXCELL = CreateObject("Excel.Application")
                        '    xlWorkBook = EXCELL.Workbooks.Open(ExcelFileName)
                        '    xlWorksheet1 = xlWorkBook.Worksheets(1) 'Worksheet 1 - Definition Report Datum
                        '    EXCELL.Visible = False

                        '    If xlWorksheet1.Range("A1").Value = "BRECHFUser" Then

                        '        Me.BgwUserPermissions.ReportProgress(40, "Reformating Worksheet")
                        '        SplashScreenManager.Default.SetWaitFormCaption("Reformating Worksheet")

                        '        'Rows delete
                        '        xlWorksheet1.Rows("1:12").delete()
                        '        ' Neue Zeile für PERIOD einfügen
                        '        xlWorksheet1.Columns("A:A").Insert(Microsoft.Office.Interop.Excel.XlDirection.xlToRight)
                        '        xlWorksheet1.Range("A1").Value = "BenutzerName"

                        '        xlWorksheet1.Columns("A:D").numberformat = "@"

                        '        For i = 1 To 50000
                        '            If IsNumeric(xlWorksheet1.Cells(i, 2).value) = False AndAlso xlWorksheet1.Cells(i, 2).value <> "" Then
                        '                Dim UserName As String = xlWorksheet1.Cells(i, 3).value
                        '                SplashScreenManager.Default.SetWaitFormCaption("Get User Name: " & UserName & " from BRECHFUser.xls")
                        '                xlWorksheet1.Cells(i + 1, 1).Value = UserName
                        '            End If

                        '        Next
                        '        For i = 2 To 50000
                        '            If xlWorksheet1.Cells(i, 1).value <> "" AndAlso xlWorksheet1.Cells(i + 1, 1).value = "" AndAlso xlWorksheet1.Cells(i, 3).value <> "" Then
                        '                SplashScreenManager.Default.SetWaitFormCaption("Add User Name in BRECHFUser.xls -  Cell A" & i + 1)
                        '                xlWorksheet1.Cells(i + 1, 1).value = xlWorksheet1.Cells(i, 1).value
                        '            End If
                        '        Next
                        '        xlWorksheet1.Range("C1").Value = "BenutzerRole"
                        '        xlWorksheet1.Columns("B:B").delete(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft)

                        '        'Rename Worksheet
                        '        xlWorksheet1.Name = "Sheet1"

                        '    End If

                        '    EXCELL.Application.DisplayAlerts = False
                        '    xlWorkBook.SaveAs(ExcelFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal)
                        '    EXCELL.Application.DisplayAlerts = True
                        '    xlWorkBook.Close()

                        '    EXCELL.Quit()
                        '    EXCELL = Nothing

                        '    'Excel Instanz beenden
                        '    Dim procs() As Process = Process.GetProcessesByName("EXCEL")
                        '    Dim i1 As Short
                        '    i1 = 0
                        '    For i1 = 0 To (procs.Length - 1)
                        '        procs(i1).Kill()
                        '    Next i1
                        '    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                        '    'cmd.CommandText = "INSERT INTO [dbo].[#Temp_ActiveDirectoryUsersBankSystems_Temp]([System],[UserID],[UserName],[UserLoginName],[UserLevel],[UserTypeCode],[UserStatus]) SELECT 'BAIS' as 'System',LTRIM(RTRIM(A.[BenutzerName])) as 'UserID',NULL as 'UserName',LTRIM(RTRIM(A.[BenutzerName])) as 'UserLoginName',NULL as 'UserLevel',NULL as 'UserTypeCode','Active' as 'UserStatus' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]')A where [Berechtigung]='J' GROUP BY [BenutzerName]"
                        '    'cmd.ExecuteNonQuery()
                        '    cmd.CommandText = "INSERT INTO [#Temp_ActiveDirectoryUsersBankSystemsPermissions_Temp]([System],[UserID],[FunctionOperationType],[FunctionRoleCode],[EffectiveDate],[ExpiryDate]) SELECT 'BAIS' as 'System',[BenutzerName] as 'UserID',NULL as 'FunctionOperationType',[BenutzerRole] as 'FunctionRoleCode',NULL as 'EfectiveDate',Convert(datetime,'99991231') as 'ExpiryDate' FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$]')A where [Berechtigung]='J' "
                        '    cmd.ExecuteNonQuery()

                        '    'File Delete
                        '    File.Delete(USER_PERMISSIONS_DIR)
                    Else

                        Me.BgwUserPermissions.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                        'SplashScreenManager.CloseForm(False)
                        MessageBox.Show("File does not exist in Import Directory - File Name:" & ExcelFileName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Next
                Me.BgwUserPermissions.ReportProgress(40, "Execute SQL Stored Procedure:USER_SYSTEMS_PERMISSIONS" & vbNewLine & " Imports BAIS,MULTIBANK and SIRON Users and Permissions")
                'SplashScreenManager.Default.SetWaitFormCaption("Execute SQL Stored Procedure:USER_SYSTEMS_PERMISSIONS" & vbNewLine & " Imports BAIS,MULTIBANK and SIRON Users and Permissions")
                cmd.CommandText = "exec [USER_SYSTEMS_PERMISSIONS] "
                cmd.ExecuteNonQuery()


                Me.BgwUserPermissions.ReportProgress(40, "USER PERMISSIONS IMPORT finished")
                'SplashScreenManager.Default.SetWaitFormCaption("USER PERMISSIONS IMPORT finished")

                CloseSqlConnections()

            End If



        Catch ex As Exception
            Me.BgwUserPermissions.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub
        End Try

    End Sub

    Private Sub BgwUserPermissions_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwUserPermissions.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','USER PERMISSIONS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "USER PERMISSIONS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','USER PERMISSIONS IMPORT','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "USER PERMISSIONS IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwUserPermissions_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwUserPermissions.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwUserPermissions, e)
        'SplashScreenManager.CloseForm(False)
    End Sub

#End Region

#Region "NEW INVENTORY IMPORT"

    Private Sub BgwInventarExcel_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwInventarExcel.DoWork
        Try
            OpenSqlConnections()
            Dim ExcelFileName As String = INVENTAR_EXCEL_IMPORT_DIR
            If File.Exists(ExcelFileName) = True Then
                'SplashScreenManager.Default.SetWaitFormCaption("Starting new Inventory Import from Excel File")
                Me.BgwInventarExcel.ReportProgress(30, "Starting new Inventory Import from Excel File")

                cmd.CommandText = "SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT Count(*) FROM [Sheet1$] where ([InventarNr] is not NULL or [Bezeichnung] is not NULL)')"
                Dim result As Double = cmd.ExecuteScalar
                If result > 0 Then
                    cmd.CommandText = "IF EXISTS (SELECT * FROM sysobjects WHERE name='#Temp_INVENTAR_ALL_ITEMS_Temp' AND xtype='U') DROP TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "CREATE TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp]([Inventarnummer] [nvarchar](255) NOT NULL,[Bezeichnung] [nvarchar](255) NOT NULL,[Seriennummer] [nvarchar](255) NULL,[Anschaffungsdatum] [datetime] NOT NULL,[Nettowert] [float] NOT NULL,[Anzahl] [float] NULL,[Monate] [float] NOT NULL,[Anschaffungswert] [float] NULL,[Kontonummer] [nvarchar](255) NOT NULL,[KontonummerAmount] [float] NULL,[Kontonummer_MWST] [nvarchar](255) NOT NULL,[Kontonummer_MWST_Amount] [float] NULL,[Kontonummer_Vorsteuer] [nvarchar](255) NOT NULL,[Kontonummer_Vorsteuer_Amount] [float] NULL,[MWST_Satz] [float] NOT NULL,[MWST_Rueck] [float] NULL,[Kostenstelle] [nvarchar](255) NOT NULL,[Bemerkung] [nvarchar](255) NULL) ON [PRIMARY]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_#Temp_INVENTAR_ALL_ITEMS_Temp_Anzahl]  DEFAULT (1) FOR [Anzahl]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_#Temp_INVENTAR_ALL_ITEMS_Temp_KontonummerAmount]  DEFAULT (0) FOR [KontonummerAmount]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_#Temp_INVENTAR_ALL_ITEMS_Temp_Kontonummer_MWST_Amount]  DEFAULT (0) FOR [Kontonummer_MWST_Amount]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp] ADD  CONSTRAINT [DF_#Temp_INVENTAR_ALL_ITEMS_Temp_Kontonummer_Vorsteuer_Amount]  DEFAULT (0) FOR [Kontonummer_Vorsteuer_Amount]"
                    cmd.ExecuteNonQuery()
                    'Import Data to Temporary Table
                    cmd.CommandText = "INSERT INTO [#Temp_INVENTAR_ALL_ITEMS_Temp] ([Inventarnummer],[Bezeichnung],[Seriennummer],[Anschaffungsdatum],[Nettowert],[Monate],[MWST_Satz],[Kontonummer],[Kontonummer_MWST],[Kontonummer_Vorsteuer],[Kostenstelle],[Bemerkung]) SELECT InventarNr,[Bezeichnung],[SerienNr],Anschafungsdatum,[NettoWert_EURO],AfA_Monate,MWSt_Satz,Kontonummer,Kontonummer_MWST,KontonummerVorsteuer,Kostenstelle,Bemerkung FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & ExcelFileName & ";','SELECT * FROM [Sheet1$] where [InventarNr] is not NULL')"
                    cmd.ExecuteNonQuery()
                    'Check Accounts
                    QueryText = "Select Distinct([Kontonummer]) as 'Kontonummer' from [#Temp_INVENTAR_ALL_ITEMS_Temp] where [Kontonummer] not in (Select [Konto] from [INVENTAR_KONTEN_MWST])"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim KONTEN As String = Nothing
                        For i = 0 To dt.Rows.Count - 1
                            KONTEN += dt.Rows.Item(i).Item("Kontonummer") & vbNewLine
                        Next
                        'SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Die folgenden Konten sind in der Datenbank nicht vorhanden:" & vbNewLine & KONTEN & vbNewLine & vbNewLine & "Bitte überprüfen Sie Ihre eingaben bzw. fügen Sie die o.a. Konten in die Datenbank ein!", "KONTEN NICHT VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                    End If
                    '+++++
                    QueryText = "Select Distinct([Kontonummer_MWST]) as 'Kontonummer' from [#Temp_INVENTAR_ALL_ITEMS_Temp] where [Kontonummer_MWST] not in (Select [Konto_MWSt] from [INVENTAR_KONTEN_MWST])"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim KONTEN As String = Nothing
                        For i = 0 To dt.Rows.Count - 1
                            KONTEN += dt.Rows.Item(i).Item("Kontonummer") & vbNewLine
                        Next
                        'SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Die folgenden MWSt Konten sind in der Datenbank nicht vorhanden:" & vbNewLine & KONTEN & vbNewLine & vbNewLine & "Bitte überprüfen Sie Ihre eingaben bzw. fügen Sie die o.a. Konten in die Datenbank ein!", "MWST KONTEN NICHT VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                    End If
                    '++++++
                    QueryText = "Select Distinct([Kontonummer_Vorsteuer]) as 'Kontonummer' from [#Temp_INVENTAR_ALL_ITEMS_Temp] where [Kontonummer_Vorsteuer] not in (Select [Konto_Vorsteuer] from [INVENTAR_KONTEN_MWST])"
                    da = New SqlDataAdapter(QueryText.Trim(), conn)
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim KONTEN As String = Nothing
                        For i = 0 To dt.Rows.Count - 1
                            KONTEN += dt.Rows.Item(i).Item("Kontonummer") & vbNewLine
                        Next
                        'SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Die folgenden Vorsteuer Konten sind in der Datenbank nicht vorhanden:" & vbNewLine & KONTEN & vbNewLine & vbNewLine & "Bitte überprüfen Sie Ihre eingaben bzw. fügen Sie die o.a. Konten in die Datenbank ein!", "VORSTEUER KONTEN NICHT VORHANDEN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                    End If
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '****************************************************************************

                    'CALCULATIONS
                    cmd.CommandText = "UPDATE [#Temp_INVENTAR_ALL_ITEMS_Temp] SET [MWST_Rueck]=(Select Distinct 'VS' = CASE WHEN EXISTS(Select [Vorsteuersatz] from [INVENTAR_VORSTEUER_SAETZE] where [Jahr]=DATEPART(Year,[Anschaffungsdatum])) then [Vorsteuersatz]else (SELECT [Vorsteuersatz] FROM [INVENTAR_VORSTEUER_SAETZE] Where [Jahr] IN (Select Max([Jahr]) from [INVENTAR_VORSTEUER_SAETZE])) end from [INVENTAR_VORSTEUER_SAETZE])"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_INVENTAR_ALL_ITEMS_Temp] SET [KontonummerAmount]=[Nettowert],[Kontonummer_MWST_Amount]=ROUND([Nettowert]*[MWST_Satz],2),[Kontonummer_Vorsteuer_Amount]=Round([Nettowert]*[MWST_Satz]*([MWST_Rueck]/100)*(-1),2)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE [#Temp_INVENTAR_ALL_ITEMS_Temp] SET [Anschaffungswert]=[KontonummerAmount]+[Kontonummer_MWST_Amount]+[Kontonummer_Vorsteuer_Amount]"
                    cmd.ExecuteNonQuery()

                    'IMPORT TO MAIN TABLE
                    cmd.CommandText = "INSERT INTO [INVENTAR_ALL_ITEMS]([Inventarnummer],[Bezeichnung],[Seriennummer],[Anschaffungsdatum],[Nettowert],[Anzahl],[Monate],[Anschaffungswert],[Kontonummer],[KontonummerAmount],[Kontonummer_MWST],[Kontonummer_MWST_Amount],[Kontonummer_Vorsteuer],[Kontonummer_Vorsteuer_Amount],[MWST_Satz],[MWST_Rueck],[Kostenstelle],[Bemerkung])SELECT [Inventarnummer],[Bezeichnung],[Seriennummer],[Anschaffungsdatum],[Nettowert],[Anzahl],[Monate],[Anschaffungswert],[Kontonummer],[KontonummerAmount],[Kontonummer_MWST],[Kontonummer_MWST_Amount],[Kontonummer_Vorsteuer],[Kontonummer_Vorsteuer_Amount],[MWST_Satz]*100,[MWST_Rueck],[Kostenstelle],[Bemerkung] FROM [#Temp_INVENTAR_ALL_ITEMS_Temp] where [Inventarnummer] not in (Select [Inventarnummer] from [INVENTAR_ALL_ITEMS])"
                    cmd.ExecuteNonQuery()

                    'DROP TEMPORARY TABLE
                    cmd.CommandText = "DROP TABLE [#Temp_INVENTAR_ALL_ITEMS_Temp]"
                    cmd.ExecuteNonQuery()

                    Me.BgwInventarExcel.ReportProgress(10, "The Excel File: " & ExcelFileName & " has being imported to Table:INVENTAR_ALL_ITEMS")
                    'SplashScreenManager.Default.SetWaitFormCaption("The Excel File: " & ExcelFileName & " has being imported to Table:INVENTAR_ALL_ITEMS")
                    'File Delete
                    File.Delete(INVENTAR_EXCEL_IMPORT_DIR)

                Else
                    'SplashScreenManager.CloseForm(False)
                    MessageBox.Show("The Excel Sheet has no Input!!" & vbNewLine & "Please input new Data to Excel Sheet!", "EXCEL SHEET HAS NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If

            Else
                Me.BgwInventarExcel.ReportProgress(0, "ERROR+++ File does not exist in Import Directory - File Name:" & ExcelFileName)
                'SplashScreenManager.CloseForm(False)
                MessageBox.Show("File does not exist in Import Directory - File Name:" & ExcelFileName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            CloseSqlConnections()

        Catch ex As Exception
            Me.BgwInventarExcel.ReportProgress(100, "ERROR+++" & ex.Message.Replace("'", ""))
            'SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseSqlConnections()
            Exit Sub
        End Try
    End Sub

    Private Sub BgwInventarExcel_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwInventarExcel.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        cmdEVENT.Connection.Open()
        Try
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('" & e.UserState & "','NEW INVENTORY','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "NEW INVENTORY" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As System.Exception
            cmdEVENT.CommandText = "INSERT INTO [IMPORT EVENTS] ([EVENT],[ProcName],[SystemName]) Values('ERROR +++ " & ex.Message.ToString.Replace("'", " ") & "','NEW INVENTORY','MANUAL IMPORTS')"
            cmdEVENT.ExecuteNonQuery()
            TextImportFileRow = Now & "  " & "NEW INVENTORY" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
        'Get Max Date
        cmdEVENT.CommandText = "SELECT MAX([ProcDate]) FROM [IMPORT EVENTS]"
        Dim MaxNewProcDate As Date = cmdEVENT.ExecuteScalar
        cmdEVENT.Connection.Close()
        'See events
        Me.IMPORT_EVENTSTableAdapter.FillByManualImportDate(Me.EDPDataSet.IMPORT_EVENTS, MaxNewProcDate)
        Me.GridControl2.Update()
    End Sub

    Private Sub BgwInventarExcel_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwInventarExcel.RunWorkerCompleted
        Me.GridControl1.Enabled = True
        Me.RibbonPageGroup1.Enabled = True
        Me.LayoutControlItem_ProgressPanel.Text = ""
        Me.LayoutControlItem_ProgressPanel.Visibility = LayoutVisibility.Never
        Me.LayoutControlGroup3.Visibility = LayoutVisibility.Never
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
        Me.ManualImportProcedures_BasicView.OptionsBehavior.ReadOnly = False
        Me.ManualImportProcedures_BasicView.OptionsBehavior.Editable = True
        Workers_Complete(BgwInventarExcel, e)
        'SplashScreenManager.CloseForm(False)
    End Sub









#End Region






End Class