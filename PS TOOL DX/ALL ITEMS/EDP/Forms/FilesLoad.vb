Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Text
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
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraTreeList
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.Office.Utils
Imports DevExpress.XtraRichEdit.Services
Imports PS_TOOL_DX.RichEditSyntaxSample
Imports DevExpress.XtraTreeList.ViewInfo
Imports DevExpress.Spreadsheet

Public Class FilesLoad

    Dim FIRST_FILE As String = Nothing
    Dim FIRST_FILE_NAME As String = Nothing
    Dim FIRST_FILE_EXTENSION As String = Nothing
    Dim FIRST_FILE_SHEET As String = Nothing

    Dim SECOND_FILE As String = Nothing
    Dim SECOND_FILE_NAME As String = Nothing
    Dim SECOND_FILE_EXTENSION As String = Nothing
    Dim SECOND_FILE_SHEET As String = Nothing

    Dim SelectedColumn As String = Nothing

    Private Sub FilesLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub FilesLoad_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.BbiExecuteSqlCommand.PerformClick()
        End If

    End Sub

    Private Sub FilesLoad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If BgwSqlExecute.IsBusy Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub DISABLE_CONTROLS_ON_SQL_EXECUTION()
        Me.bbiFirstFile.Enabled = False
        Me.SqlExecute_LayoutControlGroup.Visibility = LayoutVisibility.Always
        Me.RibbonPageGroup2.Visible = False
        Me.RibbonPageGroup3.Visible = False
        Me.RibbonPageGroup4.Visible = False
    End Sub

    Private Sub ENABLE_CONTROLS_ON_SQL_EXECUTION()
        Me.SqlExecute_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup3.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.bbiFirstFile.Enabled = True
    End Sub

    Private Sub BbiExecuteSqlCommand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiExecuteSqlCommand.ItemClick
        If Me.bbiFirstFile.Text <> "" Then
            'EXCEL
            If FIRST_FILE_EXTENSION.ToUpper.StartsWith(".XLS") Then
                'If XtraMessageBox.Show(CType("Should the File: " & FIRST_FILE_NAME & " be loaded? ", String), "EXCEL FILE LOAD", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Try
                        DISABLE_CONTROLS_ON_SQL_EXECUTION()
                        BgwSqlExecute.RunWorkerAsync()
                    Catch ex As Exception
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                'End If
            End If
            'CSV
            If FIRST_FILE_EXTENSION.ToUpper.StartsWith(".CSV") Then
                If Me.CsvFieldseparator_File1_cmb.EditValue.ToString <> "" Then
                    'If XtraMessageBox.Show(CType("Should the File: " & FIRST_FILE_NAME & " be loaded? ", String), "CSV FILE LOAD", buttons:=MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Question, defaultButton:=MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Try
                            DISABLE_CONTROLS_ON_SQL_EXECUTION()
                            BgwSqlCsvExecute.RunWorkerAsync()
                        Catch ex As Exception
                            ENABLE_CONTROLS_ON_SQL_EXECUTION()
                            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return
                        End Try
                    'End If
                Else
                    XtraMessageBox.Show("Please set the Fieldterminator for the csv files", "MISSING FIELDTERMINATOR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                End If

            End If

        End If

    End Sub

    Private Sub BgwSqlExecute_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSqlExecute.DoWork

        Try
            OpenSqlConnections()
            Me.BgwSqlExecute.ReportProgress(10, "Execute Excel file comparison")
            Me.BgwSqlExecute.ReportProgress(10, "Check validity of SQL Parameter:SEVERAL SELECTIONS\LOAD_EXCEL_CSV_FILES\EXCEL_FILES_LOAD")
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('EXCEL_FILES_LOAD') 
                                and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LOAD_EXCEL_CSV_FILES'))"
            Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
            If ParameterStatus = "Y" Then
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD]  where [Id_SQL_Parameters_Details] 
                            in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where SQL_Name_1 in ('EXCEL_FILES_LOAD')) and [SQL_Command_1] is not NULL  
                            and [Status] in ('Y') order by [SQL_Float_1] asc"
                daSqlFileCompare = New SqlDataAdapter(QueryText.Trim(), conn)
                dtSqlFileCompare = New System.Data.DataTable()
                daSqlFileCompare.Fill(dtSqlFileCompare)
                For i = 0 To dtSqlFileCompare.Rows.Count - 1
                    SqlCommandText = dtSqlFileCompare.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE1>", Me.bbiFirstFile.Text)
                    If FIRST_FILE_SHEET <> Nothing Then
                        SqlCommandText = SqlCommandText.ToString.Replace("<ExcelSheet1>", FIRST_FILE_SHEET)
                    End If
                    cmd.CommandText = SqlCommandText
                    If dtSqlFileCompare.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                        Me.BgwSqlExecute.ReportProgress(10, dtSqlFileCompare.Rows.Item(i).Item("SQL_Name_1").ToString & " - SQL Procedure:LOAD_EXCEL_CSV_FILES\EXCEL_FILES_LOAD - Nr.: " & dtSqlFileCompare.Rows.Item(i).Item("SQL_Float_1").ToString)
                        'cmd.ExecuteNonQuery()
                        System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                        da1SqlFileCompare = New SqlDataAdapter(SqlCommandText.Trim(), conn)
                        da1SqlFileCompare.SelectCommand.CommandTimeout = 50000
                        dt1SqlFileCompare = New DataTable()
                        da1SqlFileCompare.Fill(dt1SqlFileCompare)
                    End If
                Next
                CloseSqlConnections()

            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            Me.BgwSqlExecute.CancelAsync()
        End Try
    End Sub

    Private Sub BgwSqlExecute_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwSqlExecute.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        OpenSqlConnections()
        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) 
                                Values(GETDATE(),@Event,'LOAD_EXCEL_CSV_FILES','EXCEL_FILES_LOAD','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) 
                                Values(GETDATE(),@ErrorMessage,'LOAD_EXCEL_CSV_FILES','EXCEL_FILES_LOAD','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
    End Sub

    Private Sub BgwSqlExecute_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSqlExecute.RunWorkerCompleted
        CloseSqlConnections()
        ENABLE_CONTROLS_ON_SQL_EXECUTION()
        If e.Cancelled = False Then
            If dt1SqlFileCompare IsNot Nothing AndAlso dt1SqlFileCompare.Rows.Count > 0 Then
                Try
                    Me.GridControl1.BeginUpdate()
                    Me.GridControl1.DataSource = Nothing
                    'Me.GridControl1.Refresh()
                    Me.GridControl1.DataSource = dt1SqlFileCompare
                    Me.GridControl1.ForceInitialize()
                    Me.Gridview1.PopulateColumns()
                    Me.Gridview1.BestFitColumns()
                    Me.GridControl1.RefreshDataSource()

                    Me.GridControl1.EndUpdate()
                    'dt1SqlFileCompare.Reset()
                    Dim bis As Double = System.Environment.TickCount
                    'SplashScreenManager.CloseForm(False)

                Catch ex As Exception
                    'SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End Try
            Else
                Me.GridControl1.BeginUpdate()
                Me.GridControl1.DataSource = Nothing
                'Me.GridControl1.Refresh()
                Me.GridControl1.DataSource = dt1SqlFileCompare
                Me.GridControl1.ForceInitialize()
                Me.Gridview1.PopulateColumns()
                Me.Gridview1.BestFitColumns()
                Me.GridControl1.RefreshDataSource()
                Me.GridControl1.EndUpdate()
                'dt1SqlFileCompare.Reset()
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("Your SQL Query results with no Data", "NO DATA FOR THIS QUERY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            Me.GridControl1.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            'Me.GridControl1.DataSource = dt1SqlFileCompare
            Me.GridControl1.ForceInitialize()
            Me.Gridview1.PopulateColumns()
            Me.Gridview1.BestFitColumns()
            Me.GridControl1.RefreshDataSource()
            Me.GridControl1.EndUpdate()
        End If

    End Sub

    Private Sub BbiPrintExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiPrintExport.ItemClick
        If Me.Gridview1.RowCount > 0 Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                PrintableComponentLink1.CreateDocument()
                PrintableComponentLink1.ShowPreview()
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
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
        Dim reportfooter As String = "Loaded File: " & Me.bbiFirstFile.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub



    Private Sub BbiNewSqlQueryForm_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiNewSqlQueryForm.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("EXCEL/CSV Files load")
        ' Place code here
        Dim c As New FilesLoad
        c.MdiParent = Me.MdiParent

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BbiClearCurrentSqlCommand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClearCurrentSqlCommand.ItemClick
        Me.bbiFirstFile.ResetText()
        Me.CsvFieldseparator_File1_LayoutControlItem.Visibility = LayoutVisibility.Never

    End Sub

    Private Sub BbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClose.ItemClick
        Me.Close()

    End Sub

    Private Sub bbiFirstFile_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles bbiFirstFile.ButtonClick
        If e.Button.Tag Is "OpenFirstFile" Then
            With OpenFileDialog1
                If Me.bbiFirstFile.Text = "" Then
                    .Filter = "Excel Files|*.xls;*.xlsx|Comma separated Value Files|*.csv;*.CSV"
                ElseIf Me.bbiFirstFile.Text.ToUpper.ToString.EndsWith(".XLS") Or Me.bbiFirstFile.Text.ToUpper.ToString.EndsWith(".XLSX") Then
                    .Filter = "Excel Files|*.xls;*.xlsx"
                ElseIf Me.bbiFirstFile.Text.ToUpper.ToString.EndsWith(".CSV") Then
                    .Filter = "Comma separated Value Files|*.csv;*.CSV"
                End If
                .FilterIndex = 1
                '.InitialDirectory = "C:\"
                .RestoreDirectory = True
                .FileName = ""
                .Title = "Select File"
                If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If IsNothing(Me.OpenFileDialog1.FileName) = False Then
                        Me.bbiFirstFile.Text = Me.OpenFileDialog1.FileName
                        FIRST_FILE = Me.bbiFirstFile.Text
                        FIRST_FILE_EXTENSION = System.IO.Path.GetExtension(Me.OpenFileDialog1.FileName)
                        FIRST_FILE_NAME = System.IO.Path.GetFileName(Me.OpenFileDialog1.FileName)
                        Select Case FIRST_FILE_EXTENSION
                            Case ".xls", ".xlsx"
                                Dim workbook As Workbook = New DevExpress.Spreadsheet.Workbook()
                                workbook.LoadDocument(Me.OpenFileDialog1.FileName, DevExpress.Spreadsheet.DocumentFormat.Xlsx)
                                Dim worksheet As Worksheet = workbook.Worksheets(0)
                                FIRST_FILE_SHEET = worksheet.Name
                            Case ".csv", ".CSV"
                                Me.CsvFieldseparator_File1_LayoutControlItem.Visibility = LayoutVisibility.Always
                                Me.CsvFieldseparator_File1_cmb.EditValue = Me.CsvFieldseparator_File1_cmb.Properties.Items(1).ToString
                        End Select
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Gridview1_MouseDown(sender As Object, e As MouseEventArgs) Handles Gridview1.MouseDown
        Dim focusedView As GridView = CType(GridControl1.FocusedView, GridView)
        If focusedView.RowCount > 0 Then
            Dim ghi As GridHitInfo = focusedView.CalcHitInfo(e.Location)
            If ghi.InColumn Then
                SelectedColumn = ghi.Column.Name
                'MessageBox.Show(SelectedColumn)
            End If

        End If
    End Sub

    Private Sub Gridview1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles Gridview1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim ColumnMenu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = CType(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu)

            Dim menuItem_DisplayDate As New DevExpress.Utils.Menu.DXMenuItem("DateFormat", New EventHandler(AddressOf MyMenuItem_DisplayDate), ImageCollection1.Images(0))
            Dim menuItem_DisplayNumericN0 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N0", New EventHandler(AddressOf MyMenuItem_DisplayNumericN0), ImageCollection1.Images(1))
            Dim menuItem_DisplayNumericN1 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N1", New EventHandler(AddressOf MyMenuItem_DisplayNumericN1), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN2 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N2", New EventHandler(AddressOf MyMenuItem_DisplayNumericN2), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN3 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N3", New EventHandler(AddressOf MyMenuItem_DisplayNumericN3), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN4 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N4", New EventHandler(AddressOf MyMenuItem_DisplayNumericN4), ImageCollection1.Images(2))
            Dim menuItem_DisplayNumericN5 As New DevExpress.Utils.Menu.DXMenuItem("NumericFormat-N5", New EventHandler(AddressOf MyMenuItem_DisplayNumericN5), ImageCollection1.Images(2))


            menuItem_DisplayDate.Tag = e.Menu
            menuItem_DisplayNumericN0.Tag = e.Menu
            menuItem_DisplayNumericN1.Tag = e.Menu
            menuItem_DisplayNumericN2.Tag = e.Menu
            menuItem_DisplayNumericN3.Tag = e.Menu
            menuItem_DisplayNumericN4.Tag = e.Menu
            menuItem_DisplayNumericN5.Tag = e.Menu

            ColumnMenu.Items.Add(menuItem_DisplayDate)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN0)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN1)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN2)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN3)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN4)
            ColumnMenu.Items.Add(menuItem_DisplayNumericN5)

        End If
    End Sub

    Private Sub MyMenuItem_DisplayDate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                col.DisplayFormat.FormatString = "d"
            End If
        Next

    End Sub

    Private Sub MyMenuItem_DisplayNumericN0(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n0"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n1"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n2"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n3"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n4"
            End If
        Next
    End Sub
    Private Sub MyMenuItem_DisplayNumericN5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each col As GridColumn In Gridview1.Columns
            If col.Name.ToString = SelectedColumn Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "n5"
            End If
        Next
    End Sub

    Private Sub BgwSqlCsvExecute_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSqlCsvExecute.DoWork
        Try
            Me.BgwSqlCsvExecute.ReportProgress(10, "Execute csv file loading")
            Me.BgwSqlCsvExecute.ReportProgress(10, "Check validity of SQL Parameter:SEVERAL SELECTIONS\LOAD_EXCEL_CSV_FILES\CSV_FILES_LOAD")
            OpenSqlConnections()
            cmd.CommandText = "SELECT [Status] FROM [SQL_PARAMETER_DETAILS_SECOND] where  [SQL_Name_1] in ('CSV_FILES_LOAD') 
                                and [Id_SQL_Parameters_Details] in (SELECT [ID] FROM [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LOAD_EXCEL_CSV_FILES'))"
            Dim ParameterStatus As String = cmd.ExecuteScalar.ToString
            If ParameterStatus = "Y" Then
                QueryText = "Select * from [SQL_PARAMETER_DETAILS_THIRD]  where [Id_SQL_Parameters_Details] 
                            in (Select [ID] from [SQL_PARAMETER_DETAILS_SECOND] where SQL_Name_1 in ('CSV_FILES_LOAD')) and [SQL_Command_1] is not NULL  
                            and [Status] in ('Y') order by [SQL_Float_1] asc"
                daSqlFileCompare = New SqlDataAdapter(QueryText.Trim(), conn)
                dtSqlFileCompare = New System.Data.DataTable()
                daSqlFileCompare.Fill(dtSqlFileCompare)
                For i = 0 To dtSqlFileCompare.Rows.Count - 1
                    SqlCommandText = dtSqlFileCompare.Rows.Item(i).Item("SQL_Command_1").ToString.Replace("<IMPORT_DIR_FILE1>", Me.bbiFirstFile.Text).ToString.Replace("<FIELDTERMINATOR_1>", Me.CsvFieldseparator_File1_cmb.EditValue.ToString)
                    cmd.CommandText = SqlCommandText
                    If dtSqlFileCompare.Rows.Item(i).Item("SQL_Name_1").ToString <> "" Then
                        Me.BgwSqlCsvExecute.ReportProgress(10, dtSqlFileCompare.Rows.Item(i).Item("SQL_Name_1").ToString & " - SQL Procedure:LOAD_EXCEL_CSV_FILES\CSV_FILES_LOAD - Nr.: " & dtSqlFileCompare.Rows.Item(i).Item("SQL_Float_1").ToString)
                        cmd.ExecuteNonQuery()
                        System.Threading.Thread.Sleep(ExecutingSQLThreadSleep)
                        da1SqlFileCompare = New SqlDataAdapter(SqlCommandText.Trim(), conn)
                        da1SqlFileCompare.SelectCommand.CommandTimeout = 50000
                        dt1SqlFileCompare = New DataTable()
                        da1SqlFileCompare.Fill(dt1SqlFileCompare)
                    End If
                Next
                CloseSqlConnections()

            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            Me.BgwSqlExecute.CancelAsync()
        End Try
    End Sub

    Private Sub BgwSqlCsvExecute_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwSqlCsvExecute.ProgressChanged
        Me.ProgressPanel1.Caption = e.UserState.ToString
        OpenSqlConnections()
        Try
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) 
                                Values(GETDATE(),@Event,'LOAD_EXCEL_CSV_FILES','CSV_FILES_LOAD','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@Event", SqlDbType.NVarChar).Value = e.UserState.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
        Catch ex As Exception
            cmd1.CommandText = "INSERT INTO [Events_Journal] ([ProcDate],[Event],[ProcName],[SystemName],[SystemUser]) 
                                Values(GETDATE(),@Event,'LOAD_EXCEL_CSV_FILES','CSV_FILES_LOAD','" & CurrentUserWindowsID & "')"
            cmd1.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar).Value = "ERROR +++ " & ex.Message.ToString
            cmd1.ExecuteNonQuery()
            cmd1.Parameters.Clear()
            'TextImportFileRow = Now & "  " & "CUSTOMER INFO IMPORT" & "  " & e.UserState & "  " & "MANUAL IMPORTS"
            'System.IO.File.AppendAllText(ImportEventsDirectory, TextImportFileRow & vbCrLf)
            Exit Try
        End Try
    End Sub

    Private Sub BgwSqlCsvExecute_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSqlCsvExecute.RunWorkerCompleted
        CloseSqlConnections()
        ENABLE_CONTROLS_ON_SQL_EXECUTION()
        If e.Cancelled = False Then
            If dt1SqlFileCompare IsNot Nothing AndAlso dt1SqlFileCompare.Rows.Count > 0 Then
                Try
                    Me.GridControl1.BeginUpdate()
                    Me.GridControl1.DataSource = Nothing
                    'Me.GridControl1.Refresh()
                    Me.GridControl1.DataSource = dt1SqlFileCompare
                    Me.GridControl1.ForceInitialize()
                    Me.Gridview1.PopulateColumns()
                    Me.Gridview1.BestFitColumns()
                    Me.GridControl1.RefreshDataSource()

                    Me.GridControl1.EndUpdate()
                    'dt1SqlFileCompare.Reset()
                    Dim bis As Double = System.Environment.TickCount
                    'SplashScreenManager.CloseForm(False)

                Catch ex As Exception
                    'SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End Try
            Else
                Me.GridControl1.BeginUpdate()
                Me.GridControl1.DataSource = Nothing
                'Me.GridControl1.Refresh()
                Me.GridControl1.DataSource = dt1SqlFileCompare
                Me.GridControl1.ForceInitialize()
                Me.Gridview1.PopulateColumns()
                Me.Gridview1.BestFitColumns()
                Me.GridControl1.RefreshDataSource()
                Me.GridControl1.EndUpdate()
                'dt1SqlFileCompare.Reset()
                'SplashScreenManager.CloseForm(False)
                'MessageBox.Show("Your SQL Query results with no Data", "NO DATA FOR THIS QUERY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            Me.GridControl1.BeginUpdate()
            Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.ForceInitialize()
            Me.Gridview1.PopulateColumns()
            Me.Gridview1.BestFitColumns()
            Me.GridControl1.RefreshDataSource()
            Me.GridControl1.EndUpdate()
            'dt1SqlFileCompare.Reset()
            'SplashScreenManager.CloseForm(False)
        End If

    End Sub


End Class