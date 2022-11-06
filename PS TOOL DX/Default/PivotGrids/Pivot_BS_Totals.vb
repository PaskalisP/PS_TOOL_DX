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
Imports Microsoft.Office.Interop.Excel
Imports DevExpress.Spreadsheet
Public Class Pivot_BS_Totals
    Dim conn As New SqlClient.SqlConnection
    Dim cmd As New SqlCommand

    Dim ActiveTabGroup As Double = 0

    Dim rdsql1 As String = Nothing
    Dim rdsql2 As String = Nothing
    Dim rd1 As Date
    Dim rd2 As Date
    Dim flrd As Date
    Dim flrdsql As String = Nothing

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New System.Data.DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New System.Data.DataTable
    Private da2 As New SqlDataAdapter
    Private dt2 As New System.Data.DataTable

    Dim SqlCommandText As String = Nothing

    Private detailsDataGridView As New DataGridView()
    Private detailsBindingSource As New BindingSource()

    Dim SelectList As New SelectFromListForm1()

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
    Private Sub Pivot_BS_Totals_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = Nothing

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        'Bind Combobox
        Me.BS_DateFrom_Comboedit.Properties.Items.Clear()
        Me.BS_DateTill_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL  ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BS_DateFrom_Comboedit.Properties.Items.Add(row("RLDC Date"))
                Me.BS_DateTill_Comboedit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BS_DateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
            Me.BS_DateTill_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")

        Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('BS_Totals_Fill_From_Till') and Status in ('Y')"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da1.SelectCommand.CommandTimeout = 60000
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
            Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)

            Me.QueryText = SqlCommandTextNew
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.PivotGridControl1.DataSource = Nothing
                Me.PivotGridControl1.DataSource = dt
                Me.PivotGridControl1.ForceInitialize()
                Me.PivotGridControl1.BestFit()
            End If
        End If

        'Forelast Date for Daily Balance Sheet
        Me.QueryText = "Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL and [RLDC Date]= (SELECT MAX([RLDC Date]) AS second FROM  [RISK LIMIT DAILY CONTROL] WHERE  [RLDC Date] < (SELECT MAX([RLDC Date]) AS first FROM  [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql1 & "'))"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            flrd = dt.Rows.Item(0).Item("RLDC Date")
            flrdsql = flrd.ToString("yyyyMMdd")
        End If

        Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('BS_Totals_Compare') and Status in ('Y')"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da1.SelectCommand.CommandTimeout = 60000
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<MinDate>", flrdsql)
            Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<MaxDate>", rdsql1)
            Me.QueryText = SqlCommandTextNew
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.PivotGridControl2.DataSource = Nothing
                Me.PivotGridControl2.DataSource = dt
                Me.PivotGridControl2.ForceInitialize()
                Me.PivotGridField8.Caption = flrd.ToString("dd.MM.yyyy")
                Me.PivotGridField9.Caption = rd2.ToString("dd.MM.yyyy")
                Me.PivotGridControl2.BestFit()
            End If

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
        Dim reportfooter As String = "Balance Sheet Totals" 'from " & "   " & rd1 & " till  " & rd2
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
        Dim reportfooter As String = "Balance Sheet Totals compared between " & "   " & rd1 & " and  " & rd2
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Totals from " & rd1 & " till " & rd2)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 1 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Balance Sheet Totals compared between " & rd1 & " and " & rd2)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "All Business Dates" Then
            ActiveTabGroup = 0
            Me.LayoutControlGroup3.Text = "Balance Sheets Data"
            Me.LayoutControlItem3.Text = "From"
            Me.LayoutControlItem4.Text = "Till"
            Me.LoadData_Dropdownbutton.Text = "Load Data"
            Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Never
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Compare 2 Business Dates" Then
            ActiveTabGroup = 1
            Me.LayoutControlGroup3.Text = "Compare Balance Sheets Data between"
            Me.LayoutControlItem3.Text = "Date 1"
            Me.LayoutControlItem4.Text = "Date 2"
            Me.LoadData_Dropdownbutton.Text = "Compare Data"
            Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Never
            Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Never
            Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Never
            Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Always
        End If
    End Sub

    Private Sub PivotGridControl1_CellDoubleClick(sender As Object, e As DevExpress.XtraPivotGrid.PivotCellEventArgs) Handles PivotGridControl1.CellDoubleClick
        Dim c As New DetailsPivot
        c.Text = "Pivot Cell Details"
        Try
            c.GridControl2.BeginUpdate()
            c.GridControl2.DataSource = e.CreateDrillDownDataSource()
            c.GridControl1.ForceInitialize()
            c.PivotDetailsBaseView.PopulateColumns()
            c.PivotDetailsBaseView.BestFitColumns()
            c.GridControl2.RefreshDataSource()

            For Each col As GridColumn In c.PivotDetailsBaseView.Columns
                If col.FieldName.StartsWith("Amount") Or col.Name.Contains("Sum") Or col.FieldName.Contains("Amount") _
                    Or col.FieldName.Contains("Interest") Or col.FieldName.Contains("Equivalent") _
                    Or col.FieldName.Contains("BalanceEUREqu") Or col.FieldName.Contains("Org Ccy") _
                    Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName = "Original TOTAL BALANCE" Or col.FieldName = "TOTAL BALANCE - EURO" Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"

                ElseIf col.FieldName.StartsWith("Time") Or col.FieldName.StartsWith("Transaction Time") Or col.FieldName.EndsWith("Time") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    col.DisplayFormat.FormatString = "HH:mm:ss"
                End If
            Next

            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try


        '++++++++OLD CODE+++++++
        ' Create a new form.
        'Dim form As Form = New Form
        'form.Text = "Records"

        ' Place a DataGrid control on the form.
        'Dim grid As DataGrid = New DataGrid
        'grid.Parent = form
        'grid.Dock = DockStyle.Fill
        'Get the recrd set associated with the current cell and bind it to the grid.
        'grid.DataSource = e.CreateDrillDownDataSource()

        'New Code
        'detailsDataGridView.Parent = form
        'detailsDataGridView.Dock = DockStyle.Fill
        'detailsBindingSource.DataSource = e.CreateDrillDownDataSource()
        'detailsDataGridView.DataSource = detailsBindingSource
        'detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'detailsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        'detailsDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText

        'form.SetBounds(1000, 1000, 1500, 700)
        'form.StartPosition = FormStartPosition.CenterScreen
        ' Display the form.
        'form.ShowDialog()

        'form.Dispose()

        'detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'detailsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    End Sub

    Private Sub PivotGridControl1_CustomDrawFieldHeader(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldHeaderEventArgs) Handles PivotGridControl1.CustomDrawFieldHeader
        If (Not e.Field.FilterValues.IsEmpty) AndAlso e.Info.State = DevExpress.Utils.Drawing.ObjectState.Normal Then
            e.Info.State = DevExpress.Utils.Drawing.ObjectState.Hot
        End If
    End Sub



    Private Sub LoadDataFromTill_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromTill_BarButtonItem.ItemClick
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then
            If ActiveTabGroup = 0 Then
                Dim DaysCount As Integer = DateDiff(DateInterval.Day, rd1, rd2)
                If DaysCount <= 180 Then
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Data from " & rd1 & " till " & rd2 & vbNewLine & "(SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/BS_Totals_Fill_From_Till)")

                    Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('BS_Totals_Fill_From_Till') and Status in ('Y')"
                    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    da1.SelectCommand.CommandTimeout = 60000
                    dt1 = New System.Data.DataTable()
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                        Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)

                        Me.QueryText = SqlCommandTextNew
                        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        da.SelectCommand.CommandTimeout = 60000
                        dt = New System.Data.DataTable()
                        da.Fill(dt)
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                            Me.PivotGridControl1.DataSource = Nothing
                            Me.PivotGridControl1.DataSource = dt
                            Me.PivotGridControl1.ForceInitialize()
                            Me.PivotGridControl1.BestFit()
                        End If
                        SplashScreenManager.CloseForm(False)

                    Else
                        SplashScreenManager.CloseForm(False)
                        MessageBox.Show("The SQL Command:SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/BS_Totals_Fill_From_Till is either deactivated or not present!", "NO SQL COMMAND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Else
                    XtraMessageBox.Show("The selected Period is higher than 180 Days" & vbNewLine & "Please select Period equal or less 180 Days", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
            End If

        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub LoadDataSelectedDate_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataSelectedDate_BarButtonItem.ItemClick
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then
            If ActiveTabGroup = 0 Then

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Data from " & rd1 & " till " & rd2)
                'Me.DailyBalanceDetailsSheetsTableAdapter.FillByBS_Dates(Me.PS_TOOL_DX_LiveDataSet.DailyBalanceDetailsSheets, rd1, rd2)
                Me.QueryText = "SELECT [ID],[GL_Item],[GL_Item_Number],[GL_Item_Name],[BalanceEUREqu],[BSDate],[RepDate],[IdBSDate],[RilibiCode],[RilibiName] FROM  [DailyBalanceSheets] WHERE BSDate in ('" & rdsql1 & "','" & rdsql2 & "')"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                da.SelectCommand.CommandTimeout = 60000
                dt = New System.Data.DataTable()
                da.Fill(dt)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Me.PivotGridControl1.DataSource = Nothing
                    Me.PivotGridControl1.DataSource = dt
                    Me.PivotGridControl1.ForceInitialize()
                    Me.PivotGridControl1.BestFit()
                End If
                SplashScreenManager.CloseForm(False)

            End If

        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub CompareData_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CompareData_BarButtonItem.ItemClick
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then
            If ActiveTabGroup = 1 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet Data from " & rd1 & " till " & rd2 & vbNewLine & "(SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/BS_Totals_Compare)")
                Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('BS_Totals_Compare') and Status in ('Y')"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                da1.SelectCommand.CommandTimeout = 60000
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<MinDate>", rdsql1)
                    Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<MaxDate>", rdsql2)
                    Me.QueryText = SqlCommandTextNew
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    da.SelectCommand.CommandTimeout = 60000
                    dt = New System.Data.DataTable()
                    da.Fill(dt)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Me.PivotGridControl2.DataSource = Nothing
                        Me.PivotGridControl2.DataSource = dt
                        Me.PivotGridControl2.ForceInitialize()
                        Me.PivotGridField8.Caption = rd1.ToString("dd.MM.yyyy")
                        Me.PivotGridField9.Caption = rd2.ToString("dd.MM.yyyy")
                        Me.PivotGridControl2.BestFit()
                    End If
                    SplashScreenManager.CloseForm(False)
                Else
                    SplashScreenManager.CloseForm(False)
                    MessageBox.Show("The SQL Command:SQL PROCEDURES PAREMETER/SEVERAL SELECTIONS/BS_Totals_Compare is either deactivated or not present!", "NO SQL COMMAND", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If

        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub LoadDataFromList_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromList_BarButtonItem.ItemClick
        Try
            Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL  ORDER BY [ID] desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            With SelectList.CheckedListBoxControl1
                .DataSource = dt
                .DisplayMember = "RLDC Date"
            End With

            Dim dxOK_SelectList As New DevExpress.XtraEditors.SimpleButton
            With dxOK_SelectList
                .Text = "Load Data from selected Dates"
                .Height = 23
                .Width = 185
                .ImageList = SelectList.ImageCollection1
                .ImageIndex = 10
                .Location = New System.Drawing.Point(211, 358)
            End With


            Me.SelectList.SimpleButton1.Visible = False
            Me.SelectList.Controls.Add(dxOK_SelectList)

            AddHandler dxOK_SelectList.Click, AddressOf dxOK_SelectList_click

            Me.SelectList.ListBoxControl1.Items.Clear()
            Me.SelectList.Text = "AVAILABLE BALANCE SHEET DATES"
            Me.SelectList.ShowDialog()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub dxOK_SelectList_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SelectList.ListBoxControl1.Items.Count > 0 Then
            Dim SelectedDates As String = Nothing
            Dim commaSeparatedDates As String = Nothing
            If SelectList.ListBoxControl1.Items.Count = 1 Then
                For i = 0 To SelectList.ListBoxControl1.Items.Count - 1
                    Dim d As Date = SelectList.ListBoxControl1.Items(i).ToString
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    SelectedDates = "'" & dsql & "'"
                Next
                'MsgBox(SelectedDates)
            ElseIf SelectList.ListBoxControl1.Items.Count > 1 Then
                Dim arr As String() = New String(SelectList.ListBoxControl1.Items.Count - 1) {}
                Dim DateArr As String() = New String(SelectList.ListBoxControl1.Items.Count - 1) {}
                For i = 0 To SelectList.ListBoxControl1.Items.Count - 1
                    Dim d As Date = SelectList.ListBoxControl1.Items(i).ToString
                    Dim dsql As String = d.ToString("yyyyMMdd")
                    DateArr(i) = d
                    arr(i) = "'" & dsql & "'"
                Next
                SelectedDates = String.Join(",", arr)
                commaSeparatedDates = String.Join(",", DateArr)
                'MsgBox(SelectedDates)

            End If

            SelectList.Close()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Balance Sheet  Data for " & commaSeparatedDates)
            Me.QueryText = "SELECT * FROM [DailyBalanceSheets] WHERE BSDate  in ( " & SelectedDates & ")"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.PivotGridControl1.DataSource = Nothing
                Me.PivotGridControl1.DataSource = dt
                Me.PivotGridControl1.ForceInitialize()
                Me.PivotGridControl1.BestFit()
            Else
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If
            SplashScreenManager.CloseForm(False)



        End If

    End Sub

End Class