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
Imports DevExpress.Utils

Public Class SqlServerQueries

    Dim CurrentTable As String = Nothing
    Dim SelectedColumn As String = Nothing

    Dim SQL_STATEMENT_DIR As String = ""
    Dim SqlFileName As String = Nothing
    Dim TreelistVisibility As Boolean

    Private Sub SqlServerQueries_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        QueryText = "select * from ALL_TABLE_COLUMNS where TABLE_NAME not in ('ALL_TABLE_COLUMNS') order by TABLE_NAME asc"
        da1SqlQueries = New SqlDataAdapter(QueryText.Trim(), conn)
        da1SqlQueries.SelectCommand.CommandTimeout = 60000
        dt1SqlQueries = New System.Data.DataTable()
        da1SqlQueries.Fill(dt1SqlQueries)
        If dt1SqlQueries IsNot Nothing AndAlso dt1SqlQueries.Rows.Count > 0 Then
            Me.TreeList1.DataSource = dt1SqlQueries
        End If


        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE  [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SQL_STATEMENT_DIR'"
        SQL_STATEMENT_DIR = CType(cmd.ExecuteScalar(), String)
        CloseSqlConnections()




    End Sub

    Private Sub Bts_TreelistVisibility_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles Bts_TreelistVisibility.CheckedChanged
        If Me.Bts_TreelistVisibility.Checked = False Then
            Me.TreeList1.Visible = False
            Me.Bts_TreelistVisibility.Caption = "Show Treelist"
        Else
            Me.TreeList1.Visible = True
            Me.Bts_TreelistVisibility.Caption = "Hide Treelist"
        End If
    End Sub

    Private Sub SqlServerQueries_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.BbiExecuteSqlCommand.PerformClick()
        End If
        If e.KeyCode = Keys.F7 Then
            Me.Bts_TreelistVisibility.PerformClick()

        End If
    End Sub

    Private Sub SqlServerQueries_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If BgwSqlExecute.IsBusy Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub DISABLE_CONTROLS_ON_SQL_EXECUTION()
        Me.SqlExecute_LayoutControlGroup.Visibility = LayoutVisibility.Always
        Me.RibbonPageGroup1.Visible = False
        Me.RibbonPageGroup2.Visible = False
        Me.RibbonPageGroup3.Visible = False
        Me.RibbonPageGroup4.Visible = False
        Me.RibbonPageGroup5.Visible = False
        Me.RichEditControl1.ReadOnly = True
    End Sub

    Private Sub ENABLE_CONTROLS_ON_SQL_EXECUTION()
        Me.SqlExecute_LayoutControlGroup.Visibility = LayoutVisibility.Never
        Me.RibbonPageGroup1.Visible = True
        Me.RibbonPageGroup2.Visible = True
        Me.RibbonPageGroup3.Visible = True
        Me.RibbonPageGroup4.Visible = True
        Me.RibbonPageGroup5.Visible = True
        Me.RichEditControl1.ReadOnly = False
    End Sub

    Private Sub BbiExecuteSqlCommand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiExecuteSqlCommand.ItemClick
        If Me.RichEditControl1.Text <> "" Then

            Me.GridControl1.DataSource = Nothing

            Dim von As Double = System.Environment.TickCount
            Dim s As String = Me.RichEditControl1.Text.ToUpper
            s.Trim()



            If (s.StartsWith("SELECT") And (s.IndexOf("INTO") < 0)) Or (s.StartsWith("TRANSFORM")) Or (s.StartsWith("SHAPE")) Or (s.StartsWith("EXECUTE")) Or (s.StartsWith("DECLARE")) Or (s.Contains("SELECT")) Then
                Try
                    If Me.BgwSqlExecute.IsBusy = False Then
                        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                        DISABLE_CONTROLS_ON_SQL_EXECUTION()
                        BgwSqlExecute.RunWorkerAsync()

                    End If

                Catch ex As Exception
                    'SplashScreenManager.CloseForm(False)
                    ENABLE_CONTROLS_ON_SQL_EXECUTION()
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End Try
            ElseIf (s.StartsWith("DELETE")) Then
                If XtraMessageBox.Show("Your about to delete data from the Database!!" & vbNewLine & "Should the command be processed?", "DATA DELETE COMMAND", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                    cmd = New SqlCommand(Me.RichEditControl1.Text, conn)
                    Try
                        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                        DISABLE_CONTROLS_ON_SQL_EXECUTION()
                        OpenSqlConnections()
                        Dim i As Integer = cmd.ExecuteNonQuery
                        CloseSqlConnections()

                        'SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("Affected records: " + i.ToString)
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                    Catch ex As Exception
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                        'SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    End Try
                Else
                    Exit Sub

                End If
            ElseIf (s.StartsWith("DROP TABLE")) Or (s.contains("DROP TABLE")) Or (s.EndsWith("DROP TABLE")) Then
                If XtraMessageBox.Show("Your about to drop Table from the Database!!" & vbNewLine & "Should the command be processed?", "DROP TABLE COMMAND", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                    cmd = New SqlCommand(Me.RichEditControl1.Text, conn)
                    Try
                        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                        DISABLE_CONTROLS_ON_SQL_EXECUTION()
                        OpenSqlConnections()
                        Dim i As Integer = cmd.ExecuteNonQuery
                        CloseSqlConnections()

                        'SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("Affected records: " + i.ToString)
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                        Me.bbiReloadTreeList.PerformClick()

                    Catch ex As Exception
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                        'SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    End Try
                Else
                    Exit Sub

                End If
            ElseIf (s.StartsWith("UPDATE")) Then
                If XtraMessageBox.Show("Your about to modify data in the Database Table!!" & vbNewLine & "Should the command be processed?", "DATA UPDATE COMMAND", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                    cmd = New SqlCommand(Me.RichEditControl1.Text, conn)
                    Try
                        'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        'SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                        DISABLE_CONTROLS_ON_SQL_EXECUTION()
                        OpenSqlConnections()
                        Dim i As Integer = cmd.ExecuteNonQuery
                        CloseSqlConnections()
                        'SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show("Affected records: " + i.ToString)
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                    Catch ex As Exception
                        ENABLE_CONTROLS_ON_SQL_EXECUTION()
                        'SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    End Try
                Else
                    Exit Sub

                End If
            Else
                cmd = New SqlCommand(Me.RichEditControl1.Text, conn)
                Try
                    'SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    'SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                    DISABLE_CONTROLS_ON_SQL_EXECUTION()
                    OpenSqlConnections()
                    Dim i As Integer = cmd.ExecuteNonQuery
                    CloseSqlConnections()
                    'SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("Affected records: " + i.ToString)
                    ENABLE_CONTROLS_ON_SQL_EXECUTION()
                Catch ex As Exception
                    ENABLE_CONTROLS_ON_SQL_EXECUTION()
                    'SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End Try


            End If

        End If

    End Sub

    Private Sub BgwSqlExecute_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSqlExecute.DoWork
        System.Threading.Thread.Sleep(1000)
        Try
            daSqlQueries = New SqlDataAdapter(Me.RichEditControl1.Text.Trim(), conn)
            daSqlQueries.SelectCommand.CommandTimeout = 50000
            dtSqlQueries = New DataTable()
            daSqlQueries.Fill(dtSqlQueries)

            'query.Name = "customQuery1"
            'query.Sql = Me.MemoEdit1.Text.Trim()
            'ds.Queries.Add(query)
            'ds.Fill()

        Catch ex As Exception
            'SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR in SQL QUERY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

        Finally
            Me.BgwSqlExecute.CancelAsync()


        End Try
    End Sub

    Private Sub BgwSqlExecute_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSqlExecute.RunWorkerCompleted
        ENABLE_CONTROLS_ON_SQL_EXECUTION()
        If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
            Try
                Me.GridControl1.BeginUpdate()
                'Me.GridControl1.DataSource = Nothing
                'Me.GridControl1.Refresh()
                Me.GridControl1.DataSource = dtSqlQueries
                Me.GridControl1.ForceInitialize()
                Me.Gridview1.PopulateColumns()
                Me.Gridview1.BestFitColumns()
                Me.GridControl1.RefreshDataSource()

                For Each col As GridColumn In Gridview1.Columns
                    If col.FieldName.StartsWith("Amount") Or col.FieldName.Contains("Amount") _
                         Or col.FieldName.Contains("Equivalent") _
                        Or col.FieldName.Contains("Credit Exposure") Or col.FieldName.Contains("Org Ccy") _
                        Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName = "Original TOTAL BALANCE" Or col.FieldName = "TOTAL BALANCE - EURO" Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "n2"

                    ElseIf col.FieldName.StartsWith("Time") Or col.FieldName.StartsWith("Transaction Time") Or col.FieldName.EndsWith("Time") Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        col.DisplayFormat.FormatString = "HH:mm:ss"
                    End If
                Next

                For Each col As GridColumn In Gridview1.Columns
                    If col.FieldName = "Interest Spread" Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "n8"
                    End If
                    If col.FieldName = "Current Interest Coupon Period Start Date" Or col.FieldName = "Current Interest Coupon Period End Date" Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        col.DisplayFormat.FormatString = "d"
                    End If
                Next

                Me.GridControl1.EndUpdate()
                Dim bis As Double = System.Environment.TickCount
                'SplashScreenManager.CloseForm(False)

            Catch ex As Exception
                'SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        Else
            Me.GridControl1.BeginUpdate()
            'Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dtSqlQueries
            Me.GridControl1.ForceInitialize()
            Me.Gridview1.PopulateColumns()
            Me.Gridview1.BestFitColumns()
            Me.GridControl1.RefreshDataSource()
            Me.GridControl1.EndUpdate()
            SplashScreenManager.CloseForm(False)
            'MessageBox.Show("Your SQL Query results with no Data", "NO DATA FOR THIS QUERY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If



    End Sub

    Private Sub BbiLoadSqlCommand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiLoadSqlCommand.ItemClick
        With OpenFileDialog1
            .Filter = "SQL Files|*.sql"
            .FilterIndex = 1
            .InitialDirectory = SQL_STATEMENT_DIR
            .FileName = ""
            .Title = "Load SQL Statement"
            If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If IsNothing(Me.OpenFileDialog1.FileName) = False Then
                    RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
                    Me.RichEditControl1.Text = My.Computer.FileSystem.ReadAllText(Me.OpenFileDialog1.FileName)
                    Me.SqlCommandSaved_BarStaticItem.Visibility = BarItemVisibility.Always
                    Me.SqlCommandSaved_BarStaticItem.Caption = "Loaded SQL Command: " & System.IO.Path.GetFileName(Me.OpenFileDialog1.FileName)
                    SqlFileName = System.IO.Path.GetFileName(Me.OpenFileDialog1.FileName)
                    Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = Color.Cyan
                End If
            End If
        End With
    End Sub



    Private Sub BbiSaveSqlCommand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiSaveSqlCommand.ItemClick
        If Me.RichEditControl1.Text <> "" Then
            With SaveFileDialog1
                .Filter = "SQL Files|*.sql"
                SaveFileDialog1.DefaultExt = "sql"
                .FilterIndex = 1
                .InitialDirectory = SQL_STATEMENT_DIR
                If Me.SqlCommandSaved_BarStaticItem.Caption <> "" Then
                    .FileName = SqlFileName
                Else
                    .FileName = ""
                End If

                .Title = "Save current SQL Command"

                If Me.SaveFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    If IsNothing(Me.SaveFileDialog1.FileName) = False Then

                        My.Computer.FileSystem.WriteAllText(Me.SaveFileDialog1.FileName, Me.RichEditControl1.Text, False)
                        Me.SqlCommandSaved_BarStaticItem.Visibility = BarItemVisibility.Always
                        Me.SqlCommandSaved_BarStaticItem.Caption = "Saved SQL Command: " & System.IO.Path.GetFileName(Me.SaveFileDialog1.FileName)
                        Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = Color.Cyan
                    End If

                End If
            End With

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
        Dim reportfooter As String = "SQL Query Result"
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub TreeList1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeList1.MouseDoubleClick
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = TreeList1.FocusedNode
        Dim FocusedColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = TreeList1.FocusedColumn
        Dim CurrentColumn As String = [String].Empty
        CurrentTable = [String].Empty
        For Each column As DevExpress.XtraTreeList.Columns.TreeListColumn In TreeList1.VisibleColumns
            'result = node.GetDisplayText(column)
            'result = node.GetValue(column)
            If TreeList1.FocusedColumn.Caption = "TABLE NAMES" Then
                CurrentTable = "[" & node.GetDisplayText(FocusedColumn) & "]"
            ElseIf TreeList1.FocusedColumn.Caption = "COLUMN NAMES" Then
                CurrentColumn = "[" & node.GetDisplayText(FocusedColumn) & "]"
            End If
        Next
        'MessageBox.Show(result)
        If Me.RichEditControl1.Text = "" And CurrentTable <> "" Then
            RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))
            Me.RichEditControl1.Text = "Select TOP 1000 * from " & CurrentTable
            BbiExecuteSqlCommand.PerformClick()
        ElseIf Me.RichEditControl1.Text <> "" And CurrentTable <> "" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & "  " & CurrentTable
        ElseIf Me.RichEditControl1.Text = "" And CurrentColumn <> "" Then
            Me.RichEditControl1.Text = CurrentColumn
        ElseIf Me.RichEditControl1.Text <> "" And CurrentColumn <> "" Then
            Me.RichEditControl1.Text = Me.RichEditControl1.Text & "  " & CurrentColumn
        End If
    End Sub

    Private Sub TreeList1_MouseClick(sender As Object, e As MouseEventArgs) Handles TreeList1.MouseClick
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = TreeList1.FocusedNode
        Dim FocusedColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = TreeList1.FocusedColumn
        If TreeList1.FocusedColumn.Caption = "TABLE NAMES" Then
            CurrentTable = node.GetDisplayText(FocusedColumn)
        End If

    End Sub

    Private Sub TreeList1_PopupMenuShowing(sender As Object, e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles TreeList1.PopupMenuShowing
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = TreeList1.FocusedNode
        Dim FocusedColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = TreeList1.FocusedColumn
        'If TreeList1.FocusedColumn.Caption = "TABLE NAMES" Then
        TreeList_PopupMenu.ShowPopup(TreeList1.PointToScreen(e.Point))
        'End If
    End Sub

    Private Sub BbiNewSqlQueryForm_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiNewSqlQueryForm.ItemClick
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("SQL QUERIES")
        ' Place code here
        Dim c As New SqlServerQueries
        c.MdiParent = Me.MdiParent

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BbiClearCurrentSqlCommand_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClearCurrentSqlCommand.ItemClick
        Me.RichEditControl1.Text = Nothing
        Me.SqlCommandSaved_BarStaticItem.Caption = ""
        Me.SqlCommandSaved_BarStaticItem.Visibility = BarItemVisibility.Never

    End Sub

    Private Sub BbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BbiClose.ItemClick
        Me.Close()

    End Sub



    Private Sub RichEditControl1_TextChanged(sender As Object, e As EventArgs) Handles RichEditControl1.TextChanged
        If Me.RichEditControl1.Text <> "" Then
            RichEditControl1.ReplaceService(Of ISyntaxHighlightService)(New CustomSyntaxHighlightService(RichEditControl1.Document))

        End If

    End Sub

    Private Sub bbiSearchReplace_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSearchReplace.ItemClick
        Me.RichEditControl1.ShowSearchForm()

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
        'If dtSqlQueries IsNot Nothing AndAlso dtSqlQueries.Rows.Count > 0 Then
        '    Dim view As GridView = TryCast(sender, GridView)
        '    If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '        Dim ghi As GridHitInfo = view.CalcHitInfo(e.Location)
        '        SelectedColumn = ghi.Column.Name
        '        MessageBox.Show(SelectedColumn)
        '    End If

        'End If

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


    Private Sub bbiReloadTreeList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiReloadTreeList.ItemClick
        If XtraMessageBox.Show("Should the Treelist be reloaded?", "RELOAD TREELIST", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
            Try
                OpenSqlConnections()
                cmd.CommandText = "DELETE FROM [ALL_TABLE_COLUMNS]
                                       TRUNCATE TABLE [ALL_TABLE_COLUMNS]

                                        INSERT INTO [ALL_TABLE_COLUMNS]
                                                    ([TABLE_CATALOG]
                                                    ,[TABLE_SCHEMA]
                                                    ,[TABLE_NAME]
                                                    ,[COLUMN_NAME]
                                                    ,[ORDINAL_POSITION]
                                                    ,[COLUMN_DEFAULT]
                                                    ,[IS_NULLABLE]
                                                    ,[DATA_TYPE]
                                                    ,[CHARACTER_MAXIMUM_LENGTH]
                                                    ,[CHARACTER_OCTET_LENGTH]
                                                    ,[NUMERIC_PRECISION]
                                                    ,[NUMERIC_PRECISION_RADIX]
                                                    ,[NUMERIC_SCALE]
                                                    ,[DATETIME_PRECISION]
                                                    ,[CHARACTER_SET_CATALOG]
                                                    ,[CHARACTER_SET_SCHEMA]
                                                    ,[CHARACTER_SET_NAME]
                                                    ,[COLLATION_CATALOG]
                                                    ,[COLLATION_SCHEMA]
                                                    ,[COLLATION_NAME]
                                                    ,[DOMAIN_CATALOG]
                                                    ,[DOMAIN_SCHEMA]
                                                    ,[DOMAIN_NAME]) 
                                         SELECT * FROM information_schema.Columns"
                cmd.ExecuteNonQuery()
                CloseSqlConnections()
                'Reload
                QueryText = "SELECT * from ALL_TABLE_COLUMNS where TABLE_NAME not in ('ALL_TABLE_COLUMNS') order by TABLE_NAME asc"
                da1SqlQueries = New SqlDataAdapter(QueryText.Trim(), conn)
                da1SqlQueries.SelectCommand.CommandTimeout = 60000
                dt1SqlQueries = New System.Data.DataTable()
                da1SqlQueries.Fill(dt1SqlQueries)
                If dt1SqlQueries IsNot Nothing AndAlso dt1SqlQueries.Rows.Count > 0 Then
                    Me.TreeList1.DataSource = dt1SqlQueries
                End If
            Catch ex As Exception
                CloseSqlConnections()
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If
    End Sub

    Private Sub RichEditControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichEditControl1.KeyDown
        If Me.SqlCommandSaved_BarStaticItem.Caption <> "" Then
            Me.SqlCommandSaved_BarStaticItem.Caption = "Loaded SQL Command: " & System.IO.Path.GetFileName(Me.OpenFileDialog1.FileName) & " - MODIFIED"
            Me.SqlCommandSaved_BarStaticItem.ItemAppearance.Normal.ForeColor = Color.Red
        End If
    End Sub
End Class