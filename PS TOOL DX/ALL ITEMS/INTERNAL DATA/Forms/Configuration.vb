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
Imports DevExpress.XtraLayout.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Spreadsheet



Public Class Configuration
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim IdRowValue As String = "" 'ID Row Value for deletion
    Dim IDNrRowValue As Integer ' For PARAMETER deletion
    Dim ID_Nr_RowValue_All_Parameters As Integer
    Dim DepartmentsDetailView As DevExpress.XtraGrid.Views.Grid.GridView ' DetailView of the Departments - MasterView
    Dim DepartmentsParameterDetailView As DevExpress.XtraGrid.Views.Grid.GridView 'DetailView of the Departments Parameter - SecondView
    Dim row As System.Data.DataRow
    Dim row1 As System.Data.DataRow
    Dim QueryText As DevExpress.XtraEditors.TextEdit

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

    Private Sub Configuration_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
            Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
            Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
            Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
        End If
    End Sub


    Private Sub Configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick
        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
        Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
        Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
        Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save Changes
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Dim view As GridView = Me.GridControl1.FocusedView
            Dim focusedRow As Integer = view.FocusedRowHandle
            If Me.GridControl1.FocusedView.Name = "DepartmentsView" Then
                Try
                    Me.Validate()
                    Me.ABTEILUNGENBindingSource.EndEdit()
                    'If Me.PSTOOLDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                        Me.GridControl1.BeginUpdate()
                        Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                        Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                        Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                        Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                        view.RefreshData()
                        Me.GridControl1.EndUpdate()
                        view.FocusedRowHandle = focusedRow
                    Else
                        e.Handled = True
                    End If
                    'End If
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            ElseIf Me.GridControl1.FocusedView.Name = "DepartmentsParameterView" Then
                Try
                    Me.Validate()
                    Me.ABTEILUNGSPARAMETERBindingSource.EndEdit()
                    'If Me.PSTOOLDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                        Me.GridControl1.BeginUpdate()
                        Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                        view.RefreshData()
                        Me.GridControl1.EndUpdate()
                        view.FocusedRowHandle = focusedRow
                    Else
                        e.Handled = True
                    End If
                    'End If
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            ElseIf Me.GridControl1.FocusedView.Name = "ParameterView" Then
                Try
                    Me.Validate()
                    Me.PARAMETERBindingSource.EndEdit()
                    'If Me.PSTOOLDataset.HasChanges = True Then
                    If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                        Me.GridControl1.BeginUpdate()
                        Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                        Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                        view.RefreshData()
                        Me.GridControl1.EndUpdate()
                        view.FocusedRowHandle = focusedRow
                    Else
                        e.Handled = True
                    End If
                    'End If
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If

            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandText = "UPDATE A SET A.[IdABTEILUNGSCODE_NAME]=B.[IdABTEILUNGSCODE] from [PARAMETER] A INNER JOIN [ABTEILUNGSPARAMETER] B on A.[IdABTEILUNGSPARAMETER]=B.[ABTEILUNGSPARAMETER NAME]"
            cmd.ExecuteNonQuery()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End If


        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        If e.Button.Hint = "Delete" Then
            'Remove PARAMETER NAMES
            If Me.GridControl1.FocusedView.Name = "DepartmentsView" Then
                Dim row As System.Data.DataRow = DepartmentsView.GetDataRow(DepartmentsView.FocusedRowHandle)
                Dim h As Integer = FindRowHandleByRowObject(DepartmentsView, row)
                Dim cellvalue As String = row(1)
                Dim DepartmentName As String = row(2)
                If XtraMessageBox.Show("Should the Department: " & cellvalue & " and all its Department Parameters be deleted ?", "DELETE DEPARTMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Select ABTEILUNGSPARAMETER_NAME from ABTEILUNGSPARAMETER with the same Department Name
                    cmd.CommandText = "SELECT [ABTEILUNGSPARAMETER NAME] FROM [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='" & cellvalue & "'"
                    Dim Abteilungs_Parameter_Name As String = cmd.ExecuteNonQuery()
                    'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='" & Abteilungs_Parameter_Name & "'"
                    cmd.ExecuteNonQuery()
                    'Delete Abteilungen with the same ABTEILUNGS NAME 
                    cmd.CommandText = "DELETE  FROM [ABTEILUNGEN] where [ABTEILUNGS CODE]='" & cellvalue & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    'Me.DepartmentsView.DeleteSelectedRows()
                    'GridControl1.Update()
                    Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                    Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                    Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                    Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                Else
                    e.Handled = True
                End If
            ElseIf Me.GridControl1.FocusedView.Name = "DepartmentsParameterView" Then
                If XtraMessageBox.Show("Should the Department Parameter: " & IdRowValue & " be deleted ? ", "DELETE DEPARTMENT PARAMETER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='" & IdRowValue & "'"
                    cmd.ExecuteNonQuery()
                    'Delete AbteilungsParameter with the same ABTEILUNGSPARAMETER_NAME 
                    cmd.CommandText = "DELETE  FROM [ABTEILUNGSPARAMETER] where [ABTEILUNGSPARAMETER NAME]='" & IdRowValue & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    'Me.DepartmentsParameterView.DeleteSelectedRows()
                    'GridControl1.Update()
                    Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                    Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                    Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                    Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                Else
                    e.Handled = True
                End If
            ElseIf Me.GridControl1.FocusedView.Name = "ParameterView" Then
                'MsgBox(IdRowValue & "   " & IDNrRowValue)
                If XtraMessageBox.Show("Should the Parameter: " & IdRowValue & vbNewLine & "with ID: " & IDNrRowValue & " be deleted?", "DELETE PARAMETER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    'Dim ParameterDelete As PSTOOLDataset.PARAMETERRow
                    'ParameterDelete = PSTOOLDataset.PARAMETER.FindByID(IDNrRowValue)
                    'ParameterDelete.Delete()
                    'ParameterView.DeleteSelectedRows()
                    'GridControl1.Update()
                    'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Delete Parameter with the same [IdABTEILUNGSPARAMETER]
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [ID]='" & IDNrRowValue & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    'ParameterView.DeleteSelectedRows()
                    'GridControl1.Update()
                    Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                    Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                    Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                    Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                Else
                    e.Handled = True
                End If
                'Template Code:DELETE ROW in MASTER GRID VIEW
                'If Gridview is Masterview the rows can be deleted as follows
                'Dim row As System.Data.DataRow = DepartmentsView.GetDataRow(DepartmentsView.FocusedRowHandle)
                'Dim h As Integer = FindRowHandleByRowObject(DepartmentsView, row)
                'Dim cellvalue As String = row(1)
                'Dim DepartmentName As String = row(2)
                'If MsgBox("Should the Department " & DepartmentName & " be deleted ?", MsgBoxStyle.YesNo, "DELETE DEPARTMENT") = MsgBoxResult.Yes Then
                'Dim DepartmentDelete As PSTOOLDataset.ABTEILUNGENRow
                'DepartmentDelete = PSTOOLDataset.ABTEILUNGEN.FindByABTEILUNGS_CODE(cellvalue)
                'DepartmentDelete.Delete()
                'DepartmentsView.DeleteRow(h)
                'GridControl1.Update()
                'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                'Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                'Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                'Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                'Else
                'e.Handled = True
                'End If
            End If
        End If

        'Print Grid
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Custom Then
        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'PrintableComponentLink1.CreateDocument()
        'PrintableComponentLink1.ShowPreview()
        'SplashScreenManager.CloseForm(False)
        'End If

        If e.Button.Hint = "Print" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If


        If e.Button.Hint = "ExportToExcel" Then
            Try
                'Dim ExcelParameterFile = "\\CCB-DB\Apps\PSTOOL_Parameters_Export.xls"

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Start Export Parameters to Excel File :" & ExcelParameterFile)

                If File.Exists(ExcelParameterFile) = True Then
                    File.Delete(ExcelParameterFile)
                End If

                SplashScreenManager.Default.SetWaitFormCaption("Start creating specified Sheets in to Excel File :" & ExcelParameterFile)
                Dim workbook As New Workbook()
                workbook.Worksheets(0).Name = "ABTEILUNGEN"
                Dim worksheet As Worksheet = workbook.Worksheets("ABTEILUNGEN")
                worksheet.Cells("A1").Value = "ABTEILUNGS CODE"
                worksheet.Cells("B1").Value = "ABTEILUNGS NAME"
                worksheet.Cells("C1").Value = "ABTEILUNGSLEITER"
                worksheet.Cells("D1").Value = "ABTEILUNG TEL"
                worksheet.Cells("E1").Value = "ABTEILUNG FAX"
                worksheet.Cells("F1").Value = "ABTEILUNG E-MAIL"
                worksheet.Cells("G1").Value = "ABTEILUNG BEMERKUNGEN"
                worksheet.Cells("H1").Value = "ABTEILUNG EVENT JOURNAL"
                worksheet.Cells("I1").Value = "ABTEILUNG STATUS"
                worksheet.Cells("J1").Value = "CURRENT USER"
                worksheet.Cells("K1").Value = "Bearbeitungsstatus"
                worksheet.Cells("L1").Value = "IdBANK"

                workbook.Worksheets.Add("ABTEILUNGSPARAMETER")
                worksheet = workbook.Worksheets("ABTEILUNGSPARAMETER")
                worksheet.Cells("A1").Value = "ABTEILUNGSPARAMETER NAME"
                worksheet.Cells("B1").Value = "ABTEILUNGSPARAMETER STATUS"
                worksheet.Cells("C1").Value = "ABTEILUNGSPARAMETER INFO"
                worksheet.Cells("D1").Value = "IdABTEILUNGSCODE"

                workbook.Worksheets.Add("PARAMETER")
                worksheet = workbook.Worksheets("PARAMETER")
                worksheet.Cells("A1").Value = "PARAMETER1"
                worksheet.Cells("B1").Value = "PARAMETER2"
                worksheet.Cells("C1").Value = "PARAMETER STATUS"
                worksheet.Cells("D1").Value = "PARAMETER INFO"
                worksheet.Cells("E1").Value = "IdABTEILUNGSPARAMETER"
                worksheet.Cells("F1").Value = "NPARAMETER1"
                worksheet.Cells("G1").Value = "NPARAMETER2"
                worksheet.Cells("H1").Value = "DPARAMETER1"
                worksheet.Cells("I1").Value = "DPARAMETER2"

                workbook.SaveDocument(ExcelParameterFile)


                SplashScreenManager.Default.SetWaitFormCaption("Start exporting Parameter Data in to Excel File :" & ExcelParameterFile)
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & ExcelParameterFile & ";','SELECT * FROM [ABTEILUNGEN$]') select [ABTEILUNGS CODE],[ABTEILUNGS NAME],[ABTEILUNGSLEITER],[ABTEILUNG TEL],[ABTEILUNG FAX] ,[ABTEILUNG E-MAIL],[ABTEILUNG BEMERKUNGEN],[ABTEILUNG EVENT JOURNAL],[ABTEILUNG STATUS],[CURRENT USER],[Bearbeitungsstatus],[IdBANK] from [ABTEILUNGEN]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & ExcelParameterFile & ";','SELECT * FROM [ABTEILUNGSPARAMETER$]') select [ABTEILUNGSPARAMETER NAME],[ABTEILUNGSPARAMETER STATUS],[ABTEILUNGSPARAMETER INFO],[IdABTEILUNGSCODE] from [ABTEILUNGSPARAMETER]"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;Database=" & ExcelParameterFile & ";','SELECT * FROM [PARAMETER$]') select [PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[PARAMETER INFO],[IdABTEILUNGSPARAMETER],[NPARAMETER1],[NPARAMETER2],[DPARAMETER1],[DPARAMETER2] from [PARAMETER]"
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("PS TOOL Parameters are exported to the Excel File: " & ExcelParameterFile & " successfull !", "EXPORT STATUS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "Error on Parameters Excel Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

        End If


        If e.Button.Hint = "ImportFromExcel" Then
            Try
                If XtraMessageBox.Show("Should the Application Parameters be imported from the specified Excel File ?" & vbNewLine & vbNewLine & "+++ ATTENTION: The current Parameters will be deleted!!! +++ ", "IMPORT PSTOOL PARAMETERS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Dim PSTOOL_Parameter_Excel_File As String = Nothing
                    With OpenFileDialog1

                        .Filter = "Excel Files (*.xls;*.xls)|*.xls;*.xls"
                        .DefaultExt = "xls"
                        .FilterIndex = 1
                        .InitialDirectory = "\\CCB-DB\Apps"
                        .FileName = ""
                        .Title = "Import PS TOOL Parameters"
                        .RestoreDirectory = True
                        .Multiselect = False

                        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK And IsNothing(Me.OpenFileDialog1.FileName.ToString) = False Then
                            PSTOOL_Parameter_Excel_File = Me.OpenFileDialog1.FileName
                        End If
                    End With
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Start import Parameters from Excel File :" & vbNewLine & PSTOOL_Parameter_Excel_File)
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ABTEILUNGEN_Temp' AND xtype='U') CREATE TABLE [dbo].[ABTEILUNGEN_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[ABTEILUNGS CODE] [nvarchar](255) NOT NULL,[ABTEILUNGS NAME] [nvarchar](255) NULL,[ABTEILUNGSLEITER] [nvarchar](255) NULL,[ABTEILUNG TEL] [nvarchar](255) NULL,[ABTEILUNG FAX] [nvarchar](255) NULL,[ABTEILUNG E-MAIL] [nvarchar](255) NULL,[ABTEILUNG BEMERKUNGEN] [ntext] NULL,[ABTEILUNG EVENT JOURNAL] [ntext] NULL,[ABTEILUNG STATUS] [nvarchar](255) NULL,[CURRENT USER] [nvarchar](255) NULL,[Bearbeitungsstatus] [nvarchar](255) NULL,[IdBANK] [int] NULL) ELSE DELETE FROM [ABTEILUNGEN_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ABTEILUNGSPARAMETER_Temp' AND xtype='U') CREATE TABLE [dbo].[ABTEILUNGSPARAMETER_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[ABTEILUNGSPARAMETER NAME] [nvarchar](255) NOT NULL,[ABTEILUNGSPARAMETER STATUS] [nvarchar](255) NULL,[ABTEILUNGSPARAMETER INFO] [ntext] NULL,[IdABTEILUNGSCODE] [nvarchar](255) NULL) ELSE DELETE FROM [ABTEILUNGSPARAMETER_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PARAMETER_Temp' AND xtype='U') CREATE TABLE [dbo].[PARAMETER_Temp]([ID] [int] IDENTITY(1,1) NOT NULL,[PARAMETER1] [nvarchar](255) NULL,[PARAMETER2] [nvarchar](255) NULL,[PARAMETER STATUS] [nvarchar](255) NULL,[PARAMETER INFO] [ntext] NULL,[IdABTEILUNGSPARAMETER] [nvarchar](255) NULL,[NPARAMETER1] [float] NULL,[NPARAMETER2] [float] NULL,[DPARAMETER1] [Datetime] NULL,[DPARAMETER2] [Datetime] NULL) ELSE DELETE FROM [ABTEILUNGSPARAMETER_Temp]"
                    cmd.ExecuteNonQuery()
                    'Insert for ABTEILUNGEN
                    cmd.CommandText = "INSERT INTO [ABTEILUNGEN_Temp] ([ABTEILUNGS CODE],[ABTEILUNGS NAME],[ABTEILUNGSLEITER],[ABTEILUNG TEL],[ABTEILUNG FAX],[ABTEILUNG E-MAIL],[ABTEILUNG BEMERKUNGEN],[ABTEILUNG EVENT JOURNAL],[ABTEILUNG STATUS],[CURRENT USER],[Bearbeitungsstatus],[IdBANK]) SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & PSTOOL_Parameter_Excel_File & ";','SELECT [ABTEILUNGS CODE],[ABTEILUNGS NAME],[ABTEILUNGSLEITER],[ABTEILUNG TEL],[ABTEILUNG FAX],[ABTEILUNG E-MAIL],[ABTEILUNG BEMERKUNGEN],[ABTEILUNG EVENT JOURNAL],[ABTEILUNG STATUS],[CURRENT USER],[Bearbeitungsstatus],[IdBANK] FROM [ABTEILUNGEN$]')"
                    cmd.ExecuteNonQuery()
                    'Insert for ABTEILUNGSPARAMETER
                    cmd.CommandText = "INSERT INTO [ABTEILUNGSPARAMETER_Temp] ([ABTEILUNGSPARAMETER NAME],[ABTEILUNGSPARAMETER STATUS],[ABTEILUNGSPARAMETER INFO],[IdABTEILUNGSCODE])   SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & PSTOOL_Parameter_Excel_File & ";','SELECT [ABTEILUNGSPARAMETER NAME],[ABTEILUNGSPARAMETER STATUS],[ABTEILUNGSPARAMETER INFO],[IdABTEILUNGSCODE] FROM [ABTEILUNGSPARAMETER$]')"
                    cmd.ExecuteNonQuery()
                    'Insert for PARAMETER
                    cmd.CommandText = "INSERT INTO [PARAMETER_Temp] ([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[PARAMETER INFO],[IdABTEILUNGSPARAMETER],[NPARAMETER1],[NPARAMETER2],[DPARAMETER1],[DPARAMETER2])   SELECT * FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'EXCEL 12.0;HDR=YES;Database=" & PSTOOL_Parameter_Excel_File & ";','SELECT [PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[PARAMETER INFO],[IdABTEILUNGSPARAMETER],[NPARAMETER1],[NPARAMETER2],[DPARAMETER1],[DPARAMETER2] FROM [PARAMETER$]')"
                    cmd.ExecuteNonQuery()
                    'Delete current Parameters
                    cmd.CommandText = "DELETE FROM [ABTEILUNGEN]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM [ABTEILUNGSPARAMETER]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE FROM [PARAMETER]"
                    cmd.ExecuteNonQuery()
                    'Insert New Data
                    cmd.CommandText = "INSERT INTO [ABTEILUNGEN] ([ABTEILUNGS CODE],[ABTEILUNGS NAME],[ABTEILUNGSLEITER],[ABTEILUNG TEL],[ABTEILUNG FAX],[ABTEILUNG E-MAIL],[ABTEILUNG BEMERKUNGEN],[ABTEILUNG EVENT JOURNAL],[ABTEILUNG STATUS],[CURRENT USER],[Bearbeitungsstatus],[IdBANK]) SELECT [ABTEILUNGS CODE],[ABTEILUNGS NAME],[ABTEILUNGSLEITER],[ABTEILUNG TEL],[ABTEILUNG FAX],[ABTEILUNG E-MAIL],[ABTEILUNG BEMERKUNGEN],[ABTEILUNG EVENT JOURNAL],[ABTEILUNG STATUS],[CURRENT USER],[Bearbeitungsstatus],[IdBANK] FROM [ABTEILUNGEN_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [ABTEILUNGSPARAMETER] ([ABTEILUNGSPARAMETER NAME],[ABTEILUNGSPARAMETER STATUS],[ABTEILUNGSPARAMETER INFO],[IdABTEILUNGSCODE])  SELECT [ABTEILUNGSPARAMETER NAME],[ABTEILUNGSPARAMETER STATUS],[ABTEILUNGSPARAMETER INFO],[IdABTEILUNGSCODE] FROM [ABTEILUNGSPARAMETER_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO [PARAMETER] ([PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[PARAMETER INFO],[IdABTEILUNGSPARAMETER],[NPARAMETER1],[NPARAMETER2],[DPARAMETER1],[DPARAMETER2]) SELECT [PARAMETER1],[PARAMETER2],[PARAMETER STATUS],[PARAMETER INFO],[IdABTEILUNGSPARAMETER],[NPARAMETER1],[NPARAMETER2],[DPARAMETER1],[DPARAMETER2] FROM [PARAMETER_Temp]"
                    cmd.ExecuteNonQuery()
                    'Update IdABTEILUNGSCODE_NAME in PARAMETERS Table
                    cmd.CommandText = "UPDATE A SET A.[IdABTEILUNGSCODE_NAME]=B.[IdABTEILUNGSCODE] from [PARAMETER] A INNER JOIN [ABTEILUNGSPARAMETER] B on A.[IdABTEILUNGSPARAMETER]=B.[ABTEILUNGSPARAMETER NAME]"
                    cmd.ExecuteNonQuery()
                    'Delete Temporary Tables
                    cmd.CommandText = "DROP TABLE [ABTEILUNGEN_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DROP TABLE [ABTEILUNGSPARAMETER_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DROP TABLE [PARAMETER_Temp]"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()
                    Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                    Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                    Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                    Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                    SplashScreenManager.CloseForm(False)
                End If

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "Error on Parameters Excel Export", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If


    End Sub

    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Save
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.EndEdit Then
            Try
                Me.Validate()
                Me.PARAMETERBindingSource.EndEdit()
                Dim view As GridView = Me.GridControl1.FocusedView
                Dim focusedRow As Integer = view.FocusedRowHandle
                'If Me.PSTOOLDataset.HasChanges = True Then
                If XtraMessageBox.Show("Should the Changes be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                    Me.GridControl2.BeginUpdate()
                    Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                    Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                    Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                    Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                    view.RefreshData()
                    Me.GridControl2.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                Else
                    e.Handled = True
                End If
                'End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "Error on Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        'Delete Row
        'If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        If e.Button.Hint = "Delete Parameter" Then
            If XtraMessageBox.Show("Should the Parameter ID: " & ID_Nr_RowValue_All_Parameters & " be deleted?", "DELETE PARAMETER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                If ID_Nr_RowValue_All_Parameters <> 0 Then
                    If cmd.Connection.State = ConnectionState.Closed Then
                        cmd.Connection.Open()
                    End If
                    'Delete Parameter with the same [ID]
                    cmd.CommandText = "DELETE FROM [PARAMETER] where [ID]='" & ID_Nr_RowValue_All_Parameters & "'"
                    cmd.ExecuteNonQuery()
                    cmd.Connection.Close()

                    Me.PARAMETER_All_TableAdapter.Fill(Me.PSTOOLDataset.PARAMETER_All)
                    Me.PARAMETERTableAdapter.Fill(Me.PSTOOLDataset.PARAMETER)
                    Me.ABTEILUNGSPARAMETERTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGSPARAMETER)
                    Me.ABTEILUNGENTableAdapter.Fill(Me.PSTOOLDataset.ABTEILUNGEN)
                Else
                    Exit Sub
                End If

            Else
                e.Handled = True
            End If

        End If


        If e.Button.Hint = "PrintAllParameters" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub DepartmentsView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles DepartmentsView.FocusedRowChanged
        'If NewItemRow the DEPARTMENT CODE is not read only
        If Me.DepartmentsView.IsNewItemRow(Me.DepartmentsView.FocusedRowHandle) = True Then
            Me.DepartmentsView.Columns.ColumnByFieldName("ABTEILUNGS CODE").OptionsColumn.ReadOnly = False
        Else
            Me.DepartmentsView.Columns.ColumnByFieldName("ABTEILUNGS CODE").OptionsColumn.ReadOnly = True
        End If

    End Sub

    Private Sub DepartmentsView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles DepartmentsView.InvalidValueException
        'Do not perform any default action 
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        'Show the message with the error text specified 
        XtraMessagebox.Show(e.ErrorText, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

    End Sub


    Private Sub DepartmentsView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles DepartmentsView.MasterRowExpanded

        DepartmentsDetailView = DirectCast(DepartmentsView.GetDetailView(e.RowHandle, e.RelationIndex), DevExpress.XtraGrid.Views.Grid.GridView)
        Select Case e.RelationIndex
            Case 0 ' has Index

            Case Else 'Has no Index Yet
                row = DepartmentsDetailView.GetDataRow(DepartmentsDetailView.FocusedRowHandle)
                IdRowValue = row(1)
        End Select

    End Sub

    Private Function FindRowHandleByRowObject(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal row As Object) As Integer
        If Not row Is Nothing Then
            For i = 0 To view.DataRowCount - 1
                If row.Equals(view.GetRow(i)) Then
                    Return i
                End If
            Next
        End If
        Return DevExpress.XtraGrid.GridControl.InvalidRowHandle

    End Function

    Private Sub DepartmentsParameterView_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles DepartmentsParameterView.FocusedRowChanged
        'If NewItemRow the DEPARTMENT PARAMETER NAME is not read only
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            Me.DepartmentsParameterView.Columns.ColumnByFieldName("ABTEILUNGSPARAMETER NAME").OptionsColumn.ReadOnly = False
        Else
            Me.DepartmentsParameterView.Columns.ColumnByFieldName("ABTEILUNGSPARAMETER NAME").OptionsColumn.ReadOnly = True
        End If
    End Sub

   
    Private Sub DepartmentsDetailView_RowClick(sender As Object, e As RowClickEventArgs) Handles DepartmentsParameterView.RowClick
        If DepartmentsDetailView.IsNewItemRow(e.RowHandle) = False Then
            row = DepartmentsDetailView.GetDataRow(DepartmentsDetailView.FocusedRowHandle)
            IdRowValue = row(1)
        End If

        'MsgBox(DepartmentsDetailView.Columns(1).Caption & "   " & IdRowValue)
    End Sub

    Private Sub ParameterView_RowClick(sender As Object, e As RowClickEventArgs) Handles ParameterView.RowClick
        If ParameterView.IsNewItemRow(e.RowHandle) = False Then
            Dim view As GridView = DirectCast(sender, GridView)
            IdRowValue = view.GetFocusedRowCellValue("PARAMETER1").ToString
            IDNrRowValue = view.GetFocusedRowCellValue("ID")
        End If

    End Sub

    Private Sub DepartmentsView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles DepartmentsView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub


    Private Sub DepartmentsParameterView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles DepartmentsParameterView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ParameterView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ParameterView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    

    Private Sub Parameter_All_GridView_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles Parameter_All_GridView.RowCellClick
        Dim view As GridView = DirectCast(sender, GridView)
        ID_Nr_RowValue_All_Parameters = view.GetFocusedRowCellValue("ID")

    End Sub

    Private Sub Parameter_All_GridView_RowClick(sender As Object, e As RowClickEventArgs) Handles Parameter_All_GridView.RowClick
        Dim view As GridView = DirectCast(sender, GridView)
        ID_Nr_RowValue_All_Parameters = view.GetFocusedRowCellValue("ID")

    End Sub

   
    Private Sub Parameter_All_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Parameter_All_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

   
End Class