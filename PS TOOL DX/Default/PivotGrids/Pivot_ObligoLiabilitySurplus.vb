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
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraPivotGrid

Public Class Pivot_ObligoLiabilitySurplus

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

    Private detailsDataGridView As New DataGridView()
    Private detailsBindingSource As New BindingSource()

    Dim RowHeaderText As String = Nothing
    Dim SqlCommandText As String = Nothing

    Dim SumAssets As Double = 0
    Dim SumAssets_Sold As Double = 0
    Dim SumLiabilities_Fix As Double = 0
    Dim SumLiabilities_Non_Fix As Double = 0

    Dim SumAssets_T As Double = 0
    Dim SumAssets_Sold_T As Double = 0
    Dim SumLiabilities_Fix_T As Double = 0
    Dim SumLiabilities_Non_Fix_T As Double = 0

    Dim ObligoLiabilityPrincipal As Double = 0
    Dim ObligoLIabilityTotal As Double = 0


    Dim CheckField1 As String = Nothing
    Dim CheckField2 As String = Nothing

    Dim SelectList As New SelectFromListForm1()


    'Public Class MyPivotGridLocalizer
    '    Inherits DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer

    '    Public Overrides Function GetLocalizedString(ByVal id As  _
    '         DevExpress.XtraPivotGrid.Localization.PivotGridStringId) As String

    '        If id = DevExpress.XtraPivotGrid.Localization.PivotGridStringId.GrandTotal Then
    '            Return "Obligo Liability Surplus"
    '        End If
    '        Return MyBase.GetLocalizedString(id)
    '    End Function
    'End Class

    Sub New()
        DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = New MyPivotGridLocalizer
        InitSkins()
        InitializeComponent()
        SkinManager.EnableMdiFormSkins()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(CurrentSkinName)
    End Sub

    Private Sub Pivot_ObligoLiabilitySurplus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = New MyPivotGridLocalizer

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        'Bind Combobox
        Me.BS_DateFrom_Comboedit.Properties.Items.Clear()
        Me.BS_DateTill_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),A.[RLDC Date],104) as 'RiskDate' from (Select [RLDC Date] from [RISK LIMIT DAILY CONTROL]  where [RLDC Date]>='20170526' UNION ALL Select [RLDC Date] from [RISK LIMIT DAILY CONTROL]  where [RLDC Date] in ('20161231','20170331'))A ORDER BY A.[RLDC Date] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BS_DateFrom_Comboedit.Properties.Items.Add(row("RiskDate"))
                Me.BS_DateTill_Comboedit.Properties.Items.Add(row("RiskDate"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BS_DateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RiskDate")
            Me.BS_DateTill_Comboedit.Text = dt.Rows.Item(0).Item("RiskDate")
        End If
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rd2 = Me.BS_DateTill_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")

        Try

            Me.QueryText = "SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]='" & rdsql1 & "'"
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

       

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
        Dim reportfooter As String = "Obligo Liability Surplus" 'from " & "   " & rd1 & " till  " & rd2
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
        Dim reportfooter As String = "Liquidity Overview compared between " & "   " & rd1 & " and  " & rd2
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Obligo Liability Surplus Data from " & rd1 & " till " & rd2)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        'If ActiveTabGroup = 1 Then
        '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        '    SplashScreenManager.Default.SetWaitFormCaption("Liquidity Overview compared between " & rd1 & " and " & rd2)
        '    PrintableComponentLink2.CreateDocument()
        '    PrintableComponentLink2.ShowPreview()
        '    SplashScreenManager.CloseForm(False)
        'End If

    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "All Business Dates" Then
            ActiveTabGroup = 0
            Me.LayoutControlGroup3.Text = "Obligo Liability Surplus"
            Me.LayoutControlItem3.Text = "From"
            Me.LayoutControlItem4.Text = "Till"
            Me.LoadData_Dropdownbutton.Text = "Load Data"
            Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Never
            'ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Compare 2 Business Dates" Then
            '    ActiveTabGroup = 1
            '    Me.LayoutControlGroup3.Text = "Compare Liquidity Overview Data between"
            '    Me.LayoutControlItem3.Text = "Date 1"
            '    Me.LayoutControlItem4.Text = "Date 2"
            '    Me.LoadData_Dropdownbutton.Text = "Compare Data"
            '    Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Never
            '    Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Never
            '    Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Always
        End If
    End Sub

    Private Sub PivotGridControl1_CellDoubleClick(sender As Object, e As DevExpress.XtraPivotGrid.PivotCellEventArgs) Handles PivotGridControl1.CellDoubleClick
        'MsgBox(RowHeaderText)
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

            c.GridControl2.EndUpdate()
            c.ShowDialog()

        Catch ex As Exception
            Return
            Xtramessagebox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
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

    Private Sub PivotGridControl1_CustomDrawFieldValue(sender As Object, e As PivotCustomDrawFieldValueEventArgs) Handles PivotGridControl1.CustomDrawFieldValue
        'RowHeaderText = e.Field.ToString


    End Sub

    Private Sub PivotGridControl1_CustomFieldSort(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs) Handles PivotGridControl1.CustomFieldSort
        If e.Field.FieldName = "PERIOD" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumn"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumn")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
        If e.Field.FieldName = "PERIOD_MaturityDate" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumnMaturity"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumnMaturity")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
    End Sub

    Private Sub PivotGridControl2_CustomFieldSort(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs) Handles PivotGridControl2.CustomFieldSort
        If e.Field.FieldName = "Period" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumn"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumn")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
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
                    SplashScreenManager.Default.SetWaitFormCaption("Load Obligo Liability Surplus Data from " & rd1 & " till " & rd2)
                  
                    Me.QueryText = "Select * from [OBLIGO_SURPLUS_DETAILS] where [RiskDate] BETWEEN '" & rdsql1 & "' AND '" & rdsql2 & "'"
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
                    Else
                        XtraMessageBox.Show("The selected Period is higher than 180 Days" & vbNewLine & "Please select Period equal or less 180 Days", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                End If

        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
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
                SplashScreenManager.Default.SetWaitFormCaption("Load Obligo Liability Surplus Data for " & rd1 & " and " & rd2)
                Me.QueryText = "Select * from [OBLIGO_SURPLUS_DETAILS] where [RiskDate] in ('" & rdsql1 & "','" & rdsql2 & "')"
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
            Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End If


    End Sub

    'Private Sub CompareData_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CompareData_BarButtonItem.ItemClick
    '    rd1 = Me.BS_DateFrom_Comboedit.Text
    '    rd2 = Me.BS_DateTill_Comboedit.Text
    '    rdsql1 = rd1.ToString("yyyyMMdd")
    '    rdsql2 = rd2.ToString("yyyyMMdd")
    '    If rd2 >= rd1 Then
    '        If ActiveTabGroup = 1 Then
    '            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '            SplashScreenManager.Default.SetWaitFormCaption("Compare Liquidity Overview  Data between " & rd1 & " and " & rd2)
    '            'Differences PivotGrid
    '            Me.QueryText = "Exec [Liquidity_Overview_Compare] @Min_Date ='" & rdsql1 & "', @Max_Date='" & rdsql2 & "'"
    '            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '            dt = New System.Data.DataTable()
    '            da.Fill(dt)
    '            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                Me.PivotGridControl2.DataSource = Nothing
    '                Me.PivotGridControl2.DataSource = dt
    '                Me.PivotGridControl2.ForceInitialize()
    '                Me.PivotGridField8.Caption = rd1.ToString("dd.MM.yyyy")
    '                Me.PivotGridField9.Caption = rd2.ToString("dd.MM.yyyy")
    '                Me.PivotGridControl1.BestFit()
    '            Else
    '                SplashScreenManager.CloseForm(False)
    '                XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                Return
    '            End If
    '            SplashScreenManager.CloseForm(False)
    '        End If

    '    Else
    '        Xtramessagebox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        Return
    '    End If
    'End Sub

   
    Private Sub PivotGridControl1_CustomSummary(sender As Object, e As PivotGridCustomSummaryEventArgs) Handles PivotGridControl1.CustomSummary

        SumAssets = 0
        SumAssets_Sold = 0
        SumLiabilities_Fix = 0
        SumLiabilities_Non_Fix = 0
        SumAssets_T = 0
        SumAssets_Sold_T = 0
        SumLiabilities_Fix_T = 0
        SumLiabilities_Non_Fix_T = 0

        Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
        For i As Integer = 0 To ds.RowCount - 1
            Dim row As PivotDrillDownDataRow = ds(i)

            ' Get the order's total sum.
            Dim OrgEurSum As Decimal = CDec(row(fieldOrgEurAmount))
            Dim TotalEurSum As Decimal = CDec(row(FieldTotalAmountEUR))
            Dim StringClass As String = CStr(row(FieldClass))
            If StringClass = "Assets" Then
                SumAssets += OrgEurSum
                SumAssets_T += TotalEurSum
            End If
            If StringClass = "Assets-Sold" Then
                SumAssets_Sold += OrgEurSum
                SumAssets_Sold_T += TotalEurSum
            End If
            If StringClass = "Fix-Liabilities" Then
                SumLiabilities_Fix += OrgEurSum
                SumLiabilities_Fix_T += TotalEurSum
            End If
            If StringClass = "Nonfix-Liabilities" Then
                SumLiabilities_Non_Fix += OrgEurSum
                SumLiabilities_Non_Fix_T += TotalEurSum
            End If
        Next i


        If ReferenceEquals(e.DataField, fieldOrgEurAmount) Then
            If ReferenceEquals(e.ColumnField, Nothing) OrElse ReferenceEquals(e.RowField, Nothing) Then
                'this is Grand Total cell
                e.CustomValue = Math.Abs(SumAssets - SumAssets_Sold - SumLiabilities_Fix - SumLiabilities_Non_Fix)
                Return
            End If
            Dim pivot As PivotGridControl = TryCast(sender, PivotGridControl)
            Dim lastRowFieldIndex As Integer = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.RowArea) - 1
            Dim lastColumnFieldIndex As Integer = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.ColumnArea) - 1
            If e.RowField.AreaIndex = lastRowFieldIndex AndAlso e.ColumnField.AreaIndex = lastColumnFieldIndex Then
                'this is Ordinary cell
                e.CustomValue = e.SummaryValue.Summary
            Else
                'this is Total cell
                'e.CustomValue = "Total"
                e.CustomValue = e.SummaryValue.Summary
            End If
        End If

        If ReferenceEquals(e.DataField, FieldAccruedInterestAmountEUR) Then
            If ReferenceEquals(e.ColumnField, Nothing) OrElse ReferenceEquals(e.RowField, Nothing) Then
                'this is Grand Total cell
                e.CustomValue = "-"
                Return
            End If
            Dim pivot As PivotGridControl = TryCast(sender, PivotGridControl)
            Dim lastRowFieldIndex As Integer = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.RowArea) - 1
            Dim lastColumnFieldIndex As Integer = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.ColumnArea) - 1
            If e.RowField.AreaIndex = lastRowFieldIndex AndAlso e.ColumnField.AreaIndex = lastColumnFieldIndex Then
                'this is Ordinary cell
                e.CustomValue = e.SummaryValue.Summary
            Else
                'this is Total cell
                'e.CustomValue = "Total"
                e.CustomValue = e.SummaryValue.Summary
            End If
        End If

        If ReferenceEquals(e.DataField, FieldTotalAmountEUR) Then
            If ReferenceEquals(e.ColumnField, Nothing) OrElse ReferenceEquals(e.RowField, Nothing) Then
                'this is Grand Total cell
                e.CustomValue = Math.Abs(SumAssets_T - SumAssets_Sold_T - SumLiabilities_Fix_T - SumLiabilities_Non_Fix_T)
                Return
            End If
            Dim pivot As PivotGridControl = TryCast(sender, PivotGridControl)
            Dim lastRowFieldIndex As Integer = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.RowArea) - 1
            Dim lastColumnFieldIndex As Integer = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.ColumnArea) - 1
            If e.RowField.AreaIndex = lastRowFieldIndex AndAlso e.ColumnField.AreaIndex = lastColumnFieldIndex Then
                'this is Ordinary cell
                e.CustomValue = e.SummaryValue.Summary
            Else
                'this is Total cell
                'e.CustomValue = "Total"
                e.CustomValue = e.SummaryValue.Summary
            End If
        End If

    End Sub

    Private Sub LoadDataFromList_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromList_BarButtonItem.ItemClick
        Try
            Me.QueryText = "Select CONVERT(VARCHAR(10),A.[RLDC Date],104) as 'RiskDate' from (Select [RLDC Date] from [RISK LIMIT DAILY CONTROL]  where [RLDC Date]>='20170526' UNION ALL Select [RLDC Date] from [RISK LIMIT DAILY CONTROL]  where [RLDC Date] in ('20161231','20170331'))A ORDER BY A.[RLDC Date] desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            da.SelectCommand.CommandTimeout = 60000
            dt = New System.Data.DataTable()
            da.Fill(dt)
            With SelectList.CheckedListBoxControl1
                .DataSource = dt
                .DisplayMember = "RiskDate"
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
            Me.SelectList.Text = "AVAILABLE BUSINESS DATES"
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
            Me.QueryText = "SELECT * FROM [OBLIGO_SURPLUS_DETAILS] where [RiskDate]  in ( " & SelectedDates & ")"
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