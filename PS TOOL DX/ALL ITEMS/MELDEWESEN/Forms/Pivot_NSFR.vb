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
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Public Class Pivot_NSFR

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

    Dim query As New CustomSqlQuery()

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

    Private Sub Pivot_NSFR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = Nothing

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        'Bind Combobox
        Me.BS_DateFrom_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where [RLDC Date]>='20140101' and [PL Result] is not NULL  ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.BS_DateFrom_Comboedit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.BS_DateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If
        rd1 = Me.BS_DateFrom_Comboedit.Text
        rdsql1 = rd1.ToString("yyyyMMdd")



        'Try

        '    Me.QueryText = "Exec [NSFR_Details_Calc] @RISKDATE ='" & rdsql1 & "'"
        '    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        '    dt = New System.Data.DataTable()
        '    da.Fill(dt)
        '    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        '        Me.PivotGridControl1.DataSource = Nothing
        '        Me.PivotGridControl1.DataSource = dt
        '        Me.PivotGridControl1.ForceInitialize()
        '        Me.PivotGridControl1.BestFit()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Return
        'End Try





    End Sub

    Private Sub BS_DateFrom_Comboedit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BS_DateFrom_Comboedit.ButtonClick
        If e.Button.Tag = "Load" Then
            rd1 = Me.BS_DateFrom_Comboedit.Text
            rdsql1 = rd1.ToString("yyyyMMdd")

            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Calculate NSFR Details for " & rd1)
                Me.QueryText = "Exec [NSFR_Details_Calc] @RISKDATE ='" & rdsql1 & "'"
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
        Dim reportfooter As String = "NSFR Details on " & rd1
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
            SplashScreenManager.Default.SetWaitFormCaption("Load NSFR Details for " & rd1)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 1 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Liquidity Overview compared between " & rd1 & " and " & rd2)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        'If Me.TabbedControlGroup1.SelectedTabPage.Text = "All Business Dates" Then
        '    ActiveTabGroup = 0
        '    Me.LayoutControlGroup3.Text = "Liquidity Overview Data"
        '    Me.LayoutControlItem3.Text = "From"
        '    Me.LayoutControlItem4.Text = "Till"
        '    Me.LoadData_Dropdownbutton.Text = "Load Data"
        '    Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Always
        '    Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Always
        '    Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Always
        '    Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Never
        'ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Compare 2 Business Dates" Then
        '    ActiveTabGroup = 1
        '    Me.LayoutControlGroup3.Text = "Compare Liquidity Overview Data between"
        '    Me.LayoutControlItem3.Text = "Date 1"
        '    Me.LayoutControlItem4.Text = "Date 2"
        '    Me.LoadData_Dropdownbutton.Text = "Compare Data"
        '    Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Never
        '    Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Never
        '    Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Never
        '    Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Always
        'End If
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
                    Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName.StartsWith("Sum Principal") _
                    Or col.FieldName = "ValueAdjustment_EUR" Or col.FieldName = "AccruedInterest_EUR" _
                    Or col.FieldName = "Principal_EUR" Or col.FieldName = "TotalAmount_EUR" Then
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
        If e.Field.FieldName = "RowNr" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderRowNr"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderRowNr")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
        If e.Field.FieldName = "PeriodMaturityDate" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumnMaturity"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumnMaturity")
            e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
            e.Handled = True
        End If
    End Sub

    Private Sub PivotGridControl2_CustomFieldSort(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs) Handles PivotGridControl2.CustomFieldSort
        'If e.Field.FieldName = "Period" Then
        '    Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumn"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumn")
        '    e.Result = Comparer.[Default].Compare(orderValue1, orderValue2)
        '    e.Handled = True
        'End If
    End Sub




End Class