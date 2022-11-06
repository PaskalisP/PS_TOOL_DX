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

Public Class Pivot_Finrecon

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

    Private Sub Pivot_Finrecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = Nothing

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        cmd.CommandTimeout = 60000

        'Bind Combobox
        Me.BS_DateFrom_Comboedit.Properties.Items.Clear()
        Me.BS_DateTill_Comboedit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL and [RLDC Date]>'20170525'  ORDER BY [ID] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
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



        'Me.QueryText = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE]>='" & rdsql1 & "' and [RISK DATE]<='" & rdsql2 & "'"
        Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('FINRECON_SELECTION_FROM_TILL') and Status in ('Y')"
        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
            Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
            Me.QueryText = SqlCommandTextNew
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
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
        dt = New System.Data.DataTable()
        da.Fill(dt)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            flrd = dt.Rows.Item(0).Item("RLDC Date")
            flrdsql = flrd.ToString("yyyyMMdd")
        End If

        Try

            Me.QueryText = "Exec [Finrecon_Compare] @Min_Date ='" & flrdsql & "', @Max_Date='" & rdsql1 & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New System.Data.DataTable()
            da.Fill(dt)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.PivotGridControl2.DataSource = Nothing
                Me.PivotGridControl2.DataSource = dt
                Me.PivotGridControl2.ForceInitialize()
                Me.PivotGridField8.Caption = flrd.ToString("dd.MM.yyyy") & " - Balance (in CCY)"
                Me.PivotGridField9.Caption = rd2.ToString("dd.MM.yyyy") & " - Balance (in CCY)"
                Me.PivotGridField7.Caption = flrd.ToString("dd.MM.yyyy") & " - Balance (in EUR)"
                Me.PivotGridField10.Caption = rd2.ToString("dd.MM.yyyy") & " - Balance (in EUR)"
                Me.PivotGridControl2.BestFit()
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
        Dim reportfooter As String = "Financial Reconciliation Data" 'from " & "   " & rd1 & " till  " & rd2
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
        Dim reportfooter As String = "Financial Reconciliation Data compared between " & "   " & rd1 & " and  " & rd2
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    

    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_btn.Click
        If ActiveTabGroup = 0 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Financial Reconciliation Data from " & rd1 & " till " & rd2)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If
        If ActiveTabGroup = 1 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Financial Reconciliation compared between " & rd1 & " and " & rd2)
            PrintableComponentLink2.CreateDocument()
            PrintableComponentLink2.ShowPreview()
            SplashScreenManager.CloseForm(False)
        End If

    End Sub

    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "All Business Dates" Then
            ActiveTabGroup = 0
            Me.LayoutControlGroup3.Text = "Financial Reconciliation Data"
            Me.LayoutControlItem3.Text = "From"
            Me.LayoutControlItem4.Text = "Till"
            Me.LoadData_Dropdownbutton.Text = "Load Data"
            Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Always
            Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Never
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Compare 2 Business Dates" Then
            ActiveTabGroup = 1
            Me.LayoutControlGroup3.Text = "Compare Financial Reconciliation Data between"
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
                    Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName.StartsWith("Sum Principal") Or col.FieldName = "Original TOTAL BALANCE" Or col.FieldName = "TOTAL BALANCE - EURO" Then
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
                'Dim DaysCount As Integer = DateDiff(DateInterval.Day, rd1, rd2)
                'If DaysCount <= 180 Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Financial Reconciliation Data from " & rd1 & " till " & rd2)
                Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('FINRECON_SELECTION_FROM_TILL') and Status in ('Y')"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                    Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                    Me.QueryText = SqlCommandTextNew
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
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

                'Else
                '    XtraMessageBox.Show("The selected Period is higher than 180 Days" & vbNewLine & "Please select Period equal or less 180 Days", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                '    Return
                'End If
                'Try
                '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                '    SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Data from " & rd1 & " till " & rd2)
                '    Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_FROM_TILL') and Status in ('Y')"
                '    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                '    dt1 = New System.Data.DataTable()
                '    da1.Fill(dt1)
                '    If dt1.Rows.Count > 0 Then
                '        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
                '        Dim ds As New SqlDataSource(connectionParameters)
                '        query.Name = "customQuery1"
                '        query.Parameters.Add(New QueryParameter("F_Date", GetType(String), rdsql1))
                '        query.Parameters.Add(New QueryParameter("T_Date", GetType(String), rdsql2))
                '        query.Sql = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,'OrderColumnMaturity'=CASE WHEN [PERIOD_MaturityDate] = '<= 1 Month' THEN 1 WHEN [PERIOD_MaturityDate]= '1 - 3 Months' THEN 2 WHEN [PERIOD_MaturityDate] = '3 - 6 Months' THEN 3 WHEN [PERIOD_MaturityDate] = '6 - 12 Months' THEN 4 WHEN [PERIOD_MaturityDate] = '1 - 2 Years' THEN 5 WHEN [PERIOD_MaturityDate] = '2 - 3 Years' THEN 6 WHEN [PERIOD_MaturityDate] = '3 - 4 Years' THEN 7 WHEN [PERIOD_MaturityDate] = '4 - 5 Years' THEN 8 WHEN [PERIOD_MaturityDate] = '5 - 7 Years' THEN 9 WHEN [PERIOD_MaturityDate] = '7 - 10 Years' THEN 10 WHEN [PERIOD_MaturityDate] = '10 - 15 Years' THEN 11 WHEN [PERIOD_MaturityDate] = '15 - 20 Years' THEN 12 WHEN [PERIOD_MaturityDate] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[CIC_Group],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE]>='" & rdsql1 & "' and [RISK DATE]<='" & rdsql2 & "'"
                '        ds.Queries.Add(query)
                '        ds.Fill()
                '        Me.PivotGridControl1.DataSource = Nothing
                '        Me.PivotGridControl1.DataSource = ds
                '        Me.PivotGridControl1.DataMember = "customQuery1"
                '        Me.PivotGridControl1.ForceInitialize()
                '        Me.PivotGridControl1.BestFit()
                '        SplashScreenManager.CloseForm(False)
                '    End If

                'Catch ex As Exception
                '    SplashScreenManager.CloseForm(False)
                '    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                '    Return

                'End Try


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
                SplashScreenManager.Default.SetWaitFormCaption("Load Finrecon Data for " & rd1 & " and " & rd2)
                'Me.QueryText = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE] in ('" & rdsql1 & "','" & rdsql2 & "')"
                Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('FINRECON_SELECTION_ONLY_IN_DATES') and Status in ('Y')"
                da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt1 = New System.Data.DataTable()
                da1.Fill(dt1)
                If dt1.Rows.Count > 0 Then
                    SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                    Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                    Me.QueryText = SqlCommandTextNew
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
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
                SplashScreenManager.Default.SetWaitFormCaption("Compare Financial Reconciliation  Data between " & rd1 & " and " & rd2)
                'Differences PivotGrid
                Me.QueryText = "Exec [Finrecon_Compare] @Min_Date ='" & rdsql1 & "', @Max_Date='" & rdsql2 & "'"
                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                dt = New System.Data.DataTable()
                da.Fill(dt)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Me.PivotGridControl2.DataSource = Nothing
                    Me.PivotGridControl2.DataSource = dt
                    Me.PivotGridControl2.ForceInitialize()
                    Me.PivotGridField8.Caption = rd1.ToString("dd.MM.yyyy") & " - Balance (in CCY)"
                    Me.PivotGridField9.Caption = rd2.ToString("dd.MM.yyyy") & " - Balance (in CCY)"
                    Me.PivotGridField7.Caption = rd1.ToString("dd.MM.yyyy") & " - Balance (in EUR)"
                    Me.PivotGridField10.Caption = rd2.ToString("dd.MM.yyyy") & " - Balance (in EUR)"
                    Me.PivotGridControl2.BestFit()
                Else
                    SplashScreenManager.CloseForm(False)
                    XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
                SplashScreenManager.CloseForm(False)
            End If

        Else
            Xtramessagebox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If
    End Sub

    Private Sub LoadDataFromList_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromList_BarButtonItem.ItemClick
        Try
            Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL and [RLDC Date]>'20170525' ORDER BY [ID] desc"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
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
            Me.SelectList.Text = "AVAILABLE FINRECON DATES"
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
            SplashScreenManager.Default.SetWaitFormCaption("Load Finrecon Data for " & commaSeparatedDates)
            Me.QueryText = "SELECT * FROM [FINRECON_NG] where [RiskDate] in ( " & SelectedDates & ")"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
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