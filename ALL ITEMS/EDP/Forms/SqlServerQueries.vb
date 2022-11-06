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
Imports DevExpress.XtraTreeList
Imports CrystalDecisions.Shared
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Public Class SqlServerQueries

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable


    Dim SQL_STATEMENT_DIR As String = ""
    Dim TreelistVisibility As Boolean

    Dim connectionParameters As New CustomStringConnectionParameters
    Dim ds As New SqlDataSource
    Dim query As New CustomSqlQuery()


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

    Private Sub SqlServerQueries_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler GridControl1.EmbeddedNavigator.ButtonClick, AddressOf GridControl1_EmbeddedNavigator_ButtonClick

        conn = New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
        conn.Open()

        connectionParameters = New CustomStringConnectionParameters(conn.ConnectionString)
        ds = New SqlDataSource(connectionParameters)


        cmd.Connection = conn
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] WHERE  [PARAMETER STATUS]='Y' AND [IdABTEILUNGSPARAMETER]='SQL_STATEMENT_DIR'"
        SQL_STATEMENT_DIR = cmd.ExecuteScalar()
        'Delete all data in Table:ALL_TABLE_COLUMNS
        cmd.CommandText = "DELETE FROM [ALL_TABLE_COLUMNS]"
        cmd.ExecuteNonQuery()
        'Insert all Data in ALL_TABLE_COLUMNS
        cmd.CommandText = "INSERT INTO [ALL_TABLE_COLUMNS]([TABLE_CATALOG],[TABLE_SCHEMA],[TABLE_NAME],[COLUMN_NAME],[ORDINAL_POSITION],[COLUMN_DEFAULT],[IS_NULLABLE],[DATA_TYPE],[CHARACTER_MAXIMUM_LENGTH],[CHARACTER_OCTET_LENGTH],[NUMERIC_PRECISION],[NUMERIC_PRECISION_RADIX],[NUMERIC_SCALE],[DATETIME_PRECISION],[CHARACTER_SET_CATALOG],[CHARACTER_SET_SCHEMA],[CHARACTER_SET_NAME],[COLLATION_CATALOG],[COLLATION_SCHEMA],[COLLATION_NAME],[DOMAIN_CATALOG],[DOMAIN_SCHEMA],[DOMAIN_NAME]) SELECT * FROM information_schema.Columns "
        cmd.ExecuteNonQuery()


        Me.ALL_TABLE_COLUMNSTableAdapter.Fill(Me.EDPDataSet.ALL_TABLE_COLUMNS)
        TreelistVisibility = True

    End Sub

    Private Sub GridControl1_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Print Grid
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Custom Then
            If e.Button.Hint.Contains("Print") = True Then
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
            If e.Button.Hint = "Show/Hide Tables" Then
                If TreelistVisibility = True Then
                    TreelistVisibility = False
                    Me.TreeList1.Visible = False
                ElseIf TreelistVisibility = False Then
                    TreelistVisibility = True
                    Me.TreeList1.Visible = True
                End If
            End If
        End If

    End Sub

    Private Sub TreeList1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeList1.MouseDoubleClick
        Dim node As DevExpress.XtraTreeList.Nodes.TreeListNode = TreeList1.FocusedNode
        Dim FocusedColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = TreeList1.FocusedColumn
        Dim result As String = [String].Empty
        For Each column As DevExpress.XtraTreeList.Columns.TreeListColumn In TreeList1.VisibleColumns
            'result = node.GetDisplayText(column)
            'result = node.GetValue(column)
            result = "[" & node.GetDisplayText(FocusedColumn) & "]"
        Next
        'MessageBox.Show(result)
        If Me.MemoEdit1.Text = "" Then
            Me.MemoEdit1.Text = result
        Else
            Me.MemoEdit1.Text = Me.MemoEdit1.Text & "  " & result
        End If
    End Sub

    Private Sub SqlExecute_btn_Click(sender As Object, e As EventArgs) Handles SqlExecute_btn.Click
        If Me.MemoEdit1.Text <> "" Then
            Dim von As Double = System.Environment.TickCount
            Dim s As String = Me.MemoEdit1.Text.ToUpper
            s.Trim()

            If (s.StartsWith("SELECT") And (s.IndexOf("INTO") < 0)) Or (s.StartsWith("TRANSFORM")) Or (s.StartsWith("SHAPE")) Or (s.StartsWith("EXECUTE")) Or (s.StartsWith("DECLARE")) Or (s.Contains("SELECT")) Then
                Try
                    If Me.BgwSqlExecute.IsBusy = False Then
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")

                        BgwSqlExecute.RunWorkerAsync()

                    End If

                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message)
                End Try
            ElseIf (s.StartsWith("DELETE")) Or (s.StartsWith("DROP TABLE")) Then
                If MsgBox("Your about to delete data/Table from the Database!!" & vbNewLine & "Should the command be processed?", MsgBoxStyle.YesNo, "DATA/TABLE DELETE COMMAND") = MsgBoxResult.Yes Then
                    Dim cmd As SqlCommand = New SqlCommand(Me.MemoEdit1.Text, conn)
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                        Dim i As Integer = cmd.ExecuteNonQuery

                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Betroffene Datensätze: " + i.ToString)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Exit Sub

                End If
            ElseIf (s.StartsWith("UPDATE")) Then
                If MsgBox("Your about to modify data in the Database Table!!" & vbNewLine & "Should the command be processed?", MsgBoxStyle.YesNo, "DATA UPDATE COMMAND") = MsgBoxResult.Yes Then
                    Dim cmd As SqlCommand = New SqlCommand(Me.MemoEdit1.Text, conn)
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                        Dim i As Integer = cmd.ExecuteNonQuery

                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show("Betroffene Datensätze: " + i.ToString)
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Exit Sub

                End If
            Else
                Dim cmd As SqlCommand = New SqlCommand(Me.MemoEdit1.Text, conn)
                Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Executing SQL Command...")
                    Dim i As Integer = cmd.ExecuteNonQuery

                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show("Betroffene Datensätze: " + i.ToString)
                Catch ex As Exception
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show(ex.Message)
                End Try


            End If

        End If
    End Sub

    Private Sub BgwSqlExecute_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwSqlExecute.DoWork
        Try
            da = New SqlDataAdapter(Me.MemoEdit1.Text.Trim(), conn)
            da.SelectCommand.CommandTimeout = 50000
            dt = New DataTable()
            da.Fill(dt)
           
            'query.Name = "customQuery1"
            'query.Sql = Me.MemoEdit1.Text.Trim()
            'ds.Queries.Add(query)
            'ds.Fill()

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MessageBox.Show(ex.Message, "ERROR in SQL QUERY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

        Finally
            Me.BgwSqlExecute.CancelAsync()


        End Try
    End Sub

    Private Sub BgwSqlExecute_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwSqlExecute.ProgressChanged


    End Sub

    Private Sub BgwSqlExecute_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwSqlExecute.RunWorkerCompleted
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Try
                Me.GridControl1.BeginUpdate()
                'Me.GridControl1.DataSource = Nothing
                'Me.GridControl1.Refresh()
                Me.GridControl1.DataSource = dt
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
                SplashScreenManager.CloseForm(False)

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        Else
            Me.GridControl1.BeginUpdate()
            'Me.GridControl1.DataSource = Nothing
            'Me.GridControl1.Refresh()
            Me.GridControl1.DataSource = dt
            Me.GridControl1.ForceInitialize()
            Me.Gridview1.PopulateColumns()
            Me.Gridview1.BestFitColumns()
            Me.GridControl1.RefreshDataSource()
            Me.GridControl1.EndUpdate()
            SplashScreenManager.CloseForm(False)
            'MessageBox.Show("Your SQL Query results with no Data", "NO DATA FOR THIS QUERY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If


    End Sub

    Private Sub SqlSave_btn_Click(sender As Object, e As EventArgs) Handles SqlSave_btn.Click
        If Me.MemoEdit1.Text <> "" Then
            With SaveFileDialog1
                .Filter = "Text Files|*.txt"
                SaveFileDialog1.DefaultExt = "txt"
                .FilterIndex = 1
                .InitialDirectory = SQL_STATEMENT_DIR
                .FileName = ""
                .Title = "Save current SQL Command"

                If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                    If IsNothing(Me.SaveFileDialog1.FileName) = False Then

                        My.Computer.FileSystem.WriteAllText(Me.SaveFileDialog1.FileName, Me.MemoEdit1.Text, False)

                    End If

                End If
            End With

        End If
    End Sub

    Private Sub SqlLoad_btn_Click(sender As Object, e As EventArgs) Handles SqlLoad_btn.Click
        With OpenFileDialog1
            .Filter = "Text Files|*.txt"
            .FilterIndex = 1
            .InitialDirectory = SQL_STATEMENT_DIR
            .FileName = ""
            .Title = "Load SQL Statement"
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                If IsNothing(Me.OpenFileDialog1.FileName) = False Then
                    Me.MemoEdit1.Text = My.Computer.FileSystem.ReadAllText(Me.OpenFileDialog1.FileName)
                End If
            End If
        End With
    End Sub

    Private Sub SqlClear_btn_Click(sender As Object, e As EventArgs) Handles SqlClear_btn.Click
        Me.MemoEdit1.Text = ""
    End Sub

    Private Sub Gridview1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Gridview1.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText

        End If
    End Sub

    Private Sub Gridview1_ShownEditor(sender As Object, e As EventArgs) Handles Gridview1.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub NewSqlQueryForm_btn_Click(sender As Object, e As EventArgs) Handles NewSqlQueryForm_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("SQL QUERIES")
        ' Place code here
        Dim c As New SqlServerQueries
        c.MdiParent = Me.MdiParent

        c.Show()
        c.WindowState = FormWindowState.Maximized
        SplashScreenManager.CloseForm(False)
    End Sub
End Class