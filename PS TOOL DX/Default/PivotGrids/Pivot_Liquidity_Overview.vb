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

Public Class Pivot_Liquidity_Overview

    Dim ActiveTabGroup As Double = 0

    Dim rdsql1 As String = Nothing
    Dim rdsql2 As String = Nothing
    Dim rd1 As Date
    Dim rd2 As Date
    Dim flrd As Date
    Dim flrdsql As String = Nothing


    Private objDataTable As New System.Data.DataTable

    Private detailsDataGridView As New DataGridView()
    Private detailsBindingSource As New BindingSource()

    Dim RowHeaderText As String = Nothing
    Dim SqlCommandText As String = Nothing

    Dim query As New CustomSqlQuery()
    Private BS_All_BusinessDates As BindingSource


    Dim SelectList As New SelectFromListForm1()
    Dim str As New System.IO.MemoryStream()

    Private bgws As New List(Of BackgroundWorker)()
    Friend WithEvents BgwLoadFromTill As BackgroundWorker
    Friend WithEvents BgwLoadOnlyFromTill As BackgroundWorker
    Friend WithEvents BgwLoadSelection As BackgroundWorker
    Friend WithEvents BgwCompareDates As BackgroundWorker

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

    Private Sub Pivot_Liquidity_Overview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyPivotGridLocalizer.Active = Nothing

        OpenSqlConnections()
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where  [PARAMETER1]='PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR' 
                                           and [IdABTEILUNGSPARAMETER]='LAYOUTS_SAVE_DIRECTORY' and [IdABTEILUNGSCODE_NAME]='EDP' and [PARAMETER STATUS]='Y'"
        If IsDBNull(cmd.ExecuteScalar) = False Then
            PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR = CType(cmd.ExecuteScalar, String)
        End If
        CloseSqlConnections()


        ALL_BUSINESS_DATES_initData()
        ALL_BUSINESS_DATES_InitLookUp()

        Me.BS_DateFrom_BarEditItem.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString
        Me.BS_DateTill_BarEditItem.EditValue = CType(BS_All_BusinessDates.Current, DataRowView).Item(0).ToString

        rd1 = CDate(Me.BS_DateFrom_BarEditItem.EditValue.ToString)
        rd2 = CDate(Me.BS_DateTill_BarEditItem.EditValue.ToString)
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")



        'Bind Combobox
        'Me.BS_DateFrom_Comboedit.Properties.Items.Clear()
        'Me.BS_DateTill_Comboedit.Properties.Items.Clear()
        'Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL  ORDER BY [ID] desc"
        'da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        'da.SelectCommand.CommandTimeout = 60000
        'dt = New System.Data.DataTable()
        'da.Fill(dt)
        'For Each row As DataRow In dt.Rows
        '    If dt.Rows.Count > 0 Then
        '        Me.BS_DateFrom_Comboedit.Properties.Items.Add(row("RLDC Date"))
        '        Me.BS_DateTill_Comboedit.Properties.Items.Add(row("RLDC Date"))
        '    End If
        'Next
        'If dt.Rows.Count > 0 Then
        '    Me.BS_DateFrom_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        '    Me.BS_DateTill_Comboedit.Text = dt.Rows.Item(0).Item("RLDC Date")
        'End If
        'rd1 = Me.BS_DateFrom_Comboedit.Text
        'rd2 = Me.BS_DateTill_Comboedit.Text
        'rdsql1 = rd1.ToString("yyyyMMdd")
        'rdsql2 = rd2.ToString("yyyyMMdd")



        'Me.QueryText = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE]>='" & rdsql1 & "' and [RISK DATE]<='" & rdsql2 & "'"
        QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_FROM_TILL') and Status in ('Y')"
        da1 = New SqlDataAdapter(QueryText.Trim(), conn)
        da1.SelectCommand.CommandTimeout = 60000
        dt1 = New System.Data.DataTable()
        da1.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
            Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
            QueryText = SqlCommandTextNew
            da = New SqlDataAdapter(QueryText.Trim(), conn)
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

        'Get the current layout as default
        Me.PivotGridControl1.SaveLayoutToStream(str, PivotGridOptionsLayout.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Create Layout Save Folder directory (if not present)
        If IsDBNull(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR) = False AndAlso PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR <> "" Then
            Try
                If Not Directory.Exists(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR) Then
                    Directory.CreateDirectory(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR)
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "UNABLE TO CREATE LAYOUT SAVE DIRECTORY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Try
            End Try
        Else
            'XtraMessageBox.Show("Pivotgrid Layout save directory could not be created" & vbNewLine & "Check Parameter:EDP/LAYOUTS_SAVE_DIRECTORY", "UNABLE TO CREATE LAYOUT SAVE DIRECTORY", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If


        'Forelast Date for Daily Balance Sheet
        QueryText = "Select [RLDC Date] from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL and [RLDC Date]= (SELECT MAX([RLDC Date]) AS second FROM  [RISK LIMIT DAILY CONTROL] WHERE  [RLDC Date] < (SELECT MAX([RLDC Date]) AS first FROM  [RISK LIMIT DAILY CONTROL] where [RLDC Date]='" & rdsql1 & "'))"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            flrd = dt.Rows.Item(0).Item("RLDC Date")
            flrdsql = flrd.ToString("yyyyMMdd")
        End If

        Try

            QueryText = "Exec [Liquidity_Overview_Compare] @Min_Date ='" & flrdsql & "', @Max_Date='" & rdsql1 & "'"
            da = New SqlDataAdapter(QueryText.Trim(), conn)
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try

    End Sub

    Private Sub ALL_BUSINESS_DATES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL, [BUSINESS_DATE] varchar(10) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    Select CONVERT(VARCHAR(10),[RLDC Date],104) from [RISK LIMIT DAILY CONTROL] 
                                                    where  [PL Result] is not NULL  ORDER BY [ID] desc
                                                    SELECT BUSINESS_DATE  from @SELECTION_TABLE 
                                                    order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbBusinessDates As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbBusinessDates.Fill(ds, "BUSINESS_DATE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_BusinessDates = New BindingSource(ds, "BUSINESS_DATE")
    End Sub
    Private Sub ALL_BUSINESS_DATES_InitLookUp()
        Me.RepositoryItemSearchLookUpEdit1.DataSource = BS_All_BusinessDates
        Me.RepositoryItemSearchLookUpEdit1.DisplayMember = "BUSINESS_DATE"
        Me.RepositoryItemSearchLookUpEdit1.ValueMember = "BUSINESS_DATE"

        Me.RepositoryItemSearchLookUpEdit2.DataSource = BS_All_BusinessDates
        Me.RepositoryItemSearchLookUpEdit2.DisplayMember = "BUSINESS_DATE"
        Me.RepositoryItemSearchLookUpEdit2.ValueMember = "BUSINESS_DATE"

    End Sub





    Private Sub Workers_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()

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
        Dim reportfooter As String = "Liquidity Overview" 'from " & "   " & rd1 & " till  " & rd2
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



    Private Sub Print_Export_btn_Click(sender As Object, e As EventArgs)
        If ActiveTabGroup = 0 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Data from " & rd1 & " till " & rd2)
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
        If Me.TabbedControlGroup1.SelectedTabPage.Text = "All Business Dates" Then
            ActiveTabGroup = 0
            Me.BS_DateFrom_BarEditItem.Caption = "Date From:"
            Me.BS_DateTill_BarEditItem.Caption = "Date Till:"
            Me.LoadDataFromTill_Bbi.Visibility = BarItemVisibility.Always
            Me.LoadDataSelectedDate_Bbi.Visibility = BarItemVisibility.Always
            Me.LoadDataFromList_Bbi.Visibility = BarItemVisibility.Always
            Me.CompareData_Bbi.Visibility = BarItemVisibility.Never
            Me.RibbonPageGroup1.Text = "Liquidity Overview Data"
            'Me.LayoutControlGroup3.Text = "Liquidity Overview Data"
            'Me.LayoutControlItem3.Text = "From"
            'Me.LayoutControlItem4.Text = "Till"
            'Me.LoadData_Dropdownbutton.Text = "Load Data"
            'Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Always
            'Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Always
            'Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Always
            'Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Never
        ElseIf Me.TabbedControlGroup1.SelectedTabPage.Text = "Compare 2 Business Dates" Then
            ActiveTabGroup = 1
            Me.BS_DateFrom_BarEditItem.Caption = "Date 1:"
            Me.BS_DateTill_BarEditItem.Caption = "Date 2:"
            Me.LoadDataFromTill_Bbi.Visibility = BarItemVisibility.Never
            Me.LoadDataSelectedDate_Bbi.Visibility = BarItemVisibility.Never
            Me.LoadDataFromList_Bbi.Visibility = BarItemVisibility.Never
            Me.CompareData_Bbi.Visibility = BarItemVisibility.Always
            Me.RibbonPageGroup1.Text = "Compare Liquidity Overview Data between"

            'Me.LayoutControlGroup3.Text = "Compare Liquidity Overview Data between"
            'Me.LayoutControlItem3.Text = "Date 1"
            'Me.LayoutControlItem4.Text = "Date 2"
            'Me.LoadData_Dropdownbutton.Text = "Compare Data"
            'Me.LoadDataFromTill_BarButtonItem.Visibility = BarItemVisibility.Never
            'Me.LoadDataSelectedDate_BarButtonItem.Visibility = BarItemVisibility.Never
            'Me.LoadDataFromList_BarButtonItem.Visibility = BarItemVisibility.Never
            'Me.CompareData_BarButtonItem.Visibility = BarItemVisibility.Always
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
                    Or col.FieldName.Contains("EUR Equ") Or col.FieldName = "Principal" Or col.FieldName.StartsWith("Sum Principal") _
                    Or col.FieldName = "Original TOTAL BALANCE" Or col.FieldName = "TOTAL BALANCE - EURO" _
                    Or col.Caption = "Sum Principal + Accrueds (EUR)" Then
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
        If e.Field.FieldName = "PERIOD_ALMM_MaturityDate" Then
            Dim orderValue1 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex1, "OrderColumnMaturityALMM"), orderValue2 As Object = e.GetListSourceColumnValue(e.ListSourceRowIndex2, "OrderColumnMaturityALMM")
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


    'Private Sub LoadDataFromTill_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromTill_BarButtonItem.ItemClick
    '    rd1 = Me.BS_DateFrom_Comboedit.Text
    '    rd2 = Me.BS_DateTill_Comboedit.Text
    '    rdsql1 = rd1.ToString("yyyyMMdd")
    '    rdsql2 = rd2.ToString("yyyyMMdd")
    '    If rd2 >= rd1 Then
    '        If ActiveTabGroup = 0 Then
    '            'Dim DaysCount As Integer = DateDiff(DateInterval.Day, rd1, rd2)
    '            'If DaysCount <= 180 Then
    '            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '            SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Data from " & rd1 & " till " & rd2)
    '            'Me.QueryText = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE]>='" & rdsql1 & "' and [RISK DATE]<='" & rdsql2 & "'"
    '            Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_FROM_TILL') and Status in ('Y')"
    '            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '            da1.SelectCommand.CommandTimeout = 60000
    '            dt1 = New System.Data.DataTable()
    '            da1.Fill(dt1)
    '            If dt1.Rows.Count > 0 Then
    '                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
    '                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
    '                Me.QueryText = SqlCommandTextNew
    '                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '                da.SelectCommand.CommandTimeout = 60000
    '                dt = New System.Data.DataTable()
    '                da.Fill(dt)
    '                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                    Me.PivotGridControl1.DataSource = Nothing
    '                    Me.PivotGridControl1.DataSource = dt
    '                    Me.PivotGridControl1.ForceInitialize()
    '                    Me.PivotGridControl1.BestFit()
    '                Else
    '                    SplashScreenManager.CloseForm(False)
    '                    XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                    Return
    '                End If
    '                SplashScreenManager.CloseForm(False)
    '            End If

    '            'Else
    '            '    XtraMessageBox.Show("The selected Period is higher than 180 Days" & vbNewLine & "Please select Period equal or less 180 Days", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            '    Return
    '            'End If
    '            'Try
    '            '    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '            '    SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Data from " & rd1 & " till " & rd2)
    '            '    Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_FROM_TILL') and Status in ('Y')"
    '            '    da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '            '    dt1 = New System.Data.DataTable()
    '            '    da1.Fill(dt1)
    '            '    If dt1.Rows.Count > 0 Then
    '            '        Dim connectionParameters As New CustomStringConnectionParameters(conn.ConnectionString)
    '            '        Dim ds As New SqlDataSource(connectionParameters)
    '            '        query.Name = "customQuery1"
    '            '        query.Parameters.Add(New QueryParameter("F_Date", GetType(String), rdsql1))
    '            '        query.Parameters.Add(New QueryParameter("T_Date", GetType(String), rdsql2))
    '            '        query.Sql = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,'OrderColumnMaturity'=CASE WHEN [PERIOD_MaturityDate] = '<= 1 Month' THEN 1 WHEN [PERIOD_MaturityDate]= '1 - 3 Months' THEN 2 WHEN [PERIOD_MaturityDate] = '3 - 6 Months' THEN 3 WHEN [PERIOD_MaturityDate] = '6 - 12 Months' THEN 4 WHEN [PERIOD_MaturityDate] = '1 - 2 Years' THEN 5 WHEN [PERIOD_MaturityDate] = '2 - 3 Years' THEN 6 WHEN [PERIOD_MaturityDate] = '3 - 4 Years' THEN 7 WHEN [PERIOD_MaturityDate] = '4 - 5 Years' THEN 8 WHEN [PERIOD_MaturityDate] = '5 - 7 Years' THEN 9 WHEN [PERIOD_MaturityDate] = '7 - 10 Years' THEN 10 WHEN [PERIOD_MaturityDate] = '10 - 15 Years' THEN 11 WHEN [PERIOD_MaturityDate] = '15 - 20 Years' THEN 12 WHEN [PERIOD_MaturityDate] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[CIC_Group],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE]>='" & rdsql1 & "' and [RISK DATE]<='" & rdsql2 & "'"
    '            '        ds.Queries.Add(query)
    '            '        ds.Fill()
    '            '        Me.PivotGridControl1.DataSource = Nothing
    '            '        Me.PivotGridControl1.DataSource = ds
    '            '        Me.PivotGridControl1.DataMember = "customQuery1"
    '            '        Me.PivotGridControl1.ForceInitialize()
    '            '        Me.PivotGridControl1.BestFit()
    '            '        SplashScreenManager.CloseForm(False)
    '            '    End If

    '            'Catch ex As Exception
    '            '    SplashScreenManager.CloseForm(False)
    '            '    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            '    Return

    '            'End Try


    '        End If

    '    Else
    '        XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        Return

    '    End If

    'End Sub

    'Private Sub LoadDataSelectedDate_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataSelectedDate_BarButtonItem.ItemClick
    '    rd1 = Me.BS_DateFrom_Comboedit.Text
    '    rd2 = Me.BS_DateTill_Comboedit.Text
    '    rdsql1 = rd1.ToString("yyyyMMdd")
    '    rdsql2 = rd2.ToString("yyyyMMdd")
    '    If rd2 >= rd1 Then
    '        If ActiveTabGroup = 0 Then
    '            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '            SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Data for " & rd1 & " and " & rd2)
    '            'Me.QueryText = "SELECT A.[ID],A.[PERIOD],A.[PERIOD_Additional],A.[PERIOD_MaturityDate],A.[BusinessType],A.[Contract Type],A.[ProductType],A.[GLMaster / Account Type],A.[Contract/Account],A.[ClientNr],A.[Counterparty/Issuer],A.[StartDate],A.[Next EventType],A.[Next EventDate],A.[DaysToEventDate],A.[DaysToMaturity],A.[Final Maturity Date],A.[InterestRate],A.[InterestAmountOrigCur],A.[InterestAmountEuro],A.[Type],A.[CURRENCY],'Principal Amount (Orig CUR)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance]*(-1) else [Principal Amount/Value Balance] end,'Principal Amount (EUR Equ)'=Case when [Type] in ('Liabilities','Short positions') then [Principal Amount/Value Balance(EUR Equ)]*(-1) else [Principal Amount/Value Balance(EUR Equ)] end,[RISK DATE],'OrderColumn'=CASE WHEN [Period] = '<= 1 Month' THEN 1 WHEN [Period] = '1 - 3 Months' THEN 2 WHEN [Period] = '3 - 6 Months' THEN 3 WHEN [Period] = '6 - 12 Months' THEN 4 WHEN [Period] = '1 - 2 Years' THEN 5 WHEN [Period] = '2 - 3 Years' THEN 6 WHEN [Period] = '3 - 4 Years' THEN 7 WHEN [Period] = '4 - 5 Years' THEN 8 WHEN [Period] = '5 - 7 Years' THEN 9 WHEN [Period] = '7 - 10 Years' THEN 10 WHEN [Period] = '10 - 15 Years' THEN 11 WHEN [Period] = '15 - 20 Years' THEN 12 WHEN [Period] = '> 20 Years' THEN 13 END,A.AccruedInterestAmountEUR,A.AccruedInterestAmountOrigCur,A.[AverageDuration],B.[ClientType],B.[COUNTRY_OF_REGISTRATION],B.[COUNTRY_OF_RESIDENCE],B.[INDUSTRIAL_CLASS_CN],B.[CCB_Group],B.[CCB_Group_OwnID],B.[INDUSTRIAL_CLASS_LOCAL],B.[INDUSTRIAL_CLASS_LOCAL_NAME],C.[EU EEA],C.EWU,C.[LANDKZ BUBA],C.[COUNTRY NAME],'Is Bank'=Case when B.ClientType in ('F - FINANCIAL') then 'Bank' else 'No Bank' END FROM [RATERISK DETAILS] A INNER JOIN CUSTOMER_INFO B on A.ClientNr=B.ClientNo INNER JOIN [COUNTRIES] C on B.[COUNTRY_OF_RESIDENCE]=C.[COUNTRY CODE]   where [RISK DATE] in ('" & rdsql1 & "','" & rdsql2 & "')"
    '            Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_ONLY_IN_DATES') and Status in ('Y')"
    '            da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '            da1.SelectCommand.CommandTimeout = 60000
    '            dt1 = New System.Data.DataTable()
    '            da1.Fill(dt1)
    '            If dt1.Rows.Count > 0 Then
    '                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
    '                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
    '                Me.QueryText = SqlCommandTextNew
    '                da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '                da.SelectCommand.CommandTimeout = 60000
    '                dt = New System.Data.DataTable()
    '                da.Fill(dt)
    '                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                    Me.PivotGridControl1.DataSource = Nothing
    '                    Me.PivotGridControl1.DataSource = dt
    '                    Me.PivotGridControl1.ForceInitialize()
    '                    Me.PivotGridControl1.BestFit()
    '                Else
    '                    SplashScreenManager.CloseForm(False)
    '                    XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                    Return
    '                End If
    '                SplashScreenManager.CloseForm(False)

    '            End If
    '        Else
    '            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '            Return
    '        End If
    '    End If

    'End Sub

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
    '            da.SelectCommand.CommandTimeout = 60000
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

    'Private Sub LoadDataFromList_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromList_BarButtonItem.ItemClick
    '    Try
    '        Me.QueryText = "Select CONVERT(VARCHAR(10),[RLDC Date],104) as 'RLDC Date' from [RISK LIMIT DAILY CONTROL] where  [PL Result] is not NULL  ORDER BY [ID] desc"
    '        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '        dt = New System.Data.DataTable()
    '        da.Fill(dt)
    '        With SelectList.CheckedListBoxControl1
    '            .DataSource = dt
    '            .DisplayMember = "RLDC Date"
    '        End With

    '        Dim dxOK_SelectList As New DevExpress.XtraEditors.SimpleButton
    '        With dxOK_SelectList
    '            .Text = "Load Data from selected Dates"
    '            .Height = 23
    '            .Width = 185
    '            .ImageList = SelectList.ImageCollection1
    '            .ImageIndex = 10
    '            .Location = New System.Drawing.Point(211, 358)
    '        End With


    '        Me.SelectList.SimpleButton1.Visible = False
    '        Me.SelectList.Controls.Add(dxOK_SelectList)

    '        AddHandler dxOK_SelectList.Click, AddressOf dxOK_SelectList_click

    '        Me.SelectList.ListBoxControl1.Items.Clear()
    '        Me.SelectList.Text = "AVAILABLE BUSINESS DATES"
    '        Me.SelectList.ShowDialog()

    '    Catch ex As Exception
    '        XtraMessageBox.Show(ex.Message, "Wrong Search criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        Return
    '    End Try
    'End Sub

    'Private Sub dxOK_SelectList_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If SelectList.ListBoxControl1.Items.Count > 0 Then
    '        Dim SelectedDates As String = Nothing
    '        Dim commaSeparatedDates As String = Nothing
    '        If SelectList.ListBoxControl1.Items.Count = 1 Then
    '            For i = 0 To SelectList.ListBoxControl1.Items.Count - 1
    '                Dim d As Date = SelectList.ListBoxControl1.Items(i).ToString
    '                Dim dsql As String = d.ToString("yyyyMMdd")
    '                SelectedDates = "'" & dsql & "'"
    '            Next
    '            'MsgBox(SelectedDates)
    '        ElseIf SelectList.ListBoxControl1.Items.Count > 1 Then
    '            Dim arr As String() = New String(SelectList.ListBoxControl1.Items.Count - 1) {}
    '            Dim DateArr As String() = New String(SelectList.ListBoxControl1.Items.Count - 1) {}
    '            For i = 0 To SelectList.ListBoxControl1.Items.Count - 1
    '                Dim d As Date = SelectList.ListBoxControl1.Items(i).ToString
    '                Dim dsql As String = d.ToString("yyyyMMdd")
    '                DateArr(i) = d
    '                arr(i) = "'" & dsql & "'"
    '            Next
    '            SelectedDates = String.Join(",", arr)
    '            commaSeparatedDates = String.Join(",", DateArr)
    '            'MsgBox(SelectedDates)

    '        End If

    '        SelectList.Close()

    '        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
    '        SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Details Data for " & commaSeparatedDates)
    '        Me.QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_DATESLIST') and Status in ('Y')"
    '        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '        da1.SelectCommand.CommandTimeout = 60000
    '        dt1 = New System.Data.DataTable()
    '        da1.Fill(dt1)
    '        If dt1.Rows.Count > 0 Then
    '            SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<ListOfDates>", SelectedDates)
    '            Me.QueryText = SqlCommandText
    '            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
    '            da.SelectCommand.CommandTimeout = 60000
    '            dt = New System.Data.DataTable()
    '            da.Fill(dt)
    '            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '                Me.PivotGridControl1.DataSource = Nothing
    '                Me.PivotGridControl1.DataSource = dt
    '                Me.PivotGridControl1.ForceInitialize()
    '                Me.PivotGridControl1.BestFit()
    '            Else
    '                SplashScreenManager.CloseForm(False)
    '                XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '                Return
    '            End If
    '            SplashScreenManager.CloseForm(False)

    '        End If
    '        SplashScreenManager.CloseForm(False)



    '    End If

    'End Sub

    Private Sub bbiLoadLayout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLoadLayout.ItemClick
        If Directory.Exists(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR) Then
            Dim c As New LayoutTemplates
            c.GridControl1.DataSource = Fileinfo_To_DataTable(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR)
            c.Files_GridView.ViewCaption = "Load Report Template"
            c.LayoutControlItem1.Visibility = LayoutVisibility.Never

            If DevExpress.XtraEditors.XtraDialog.Show(c, "Report Templates - Liquidity Overview", MessageBoxButtons.OKCancel) = DialogResult.OK And c.Files_GridView.RowCount > 0 Then
                If c.FileFullPath_TextEdit.EditValue.ToString <> "" Then
                    Try
                        Me.PivotGridControl1.RestoreLayoutFromXml(c.FileFullPath_TextEdit.EditValue.ToString, PivotGridOptionsLayout.FullLayout)
                        Me.ReportTemplateName_BarStaticItem.Caption = c.FileName_TextEdit.EditValue.ToString
                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If

        Else
            XtraMessageBox.Show("Pivotgrid Layout load directory could not be fund!" & vbNewLine & "Check Parameter:EDP/LAYOUTS_SAVE_DIRECTORY", "LAYOUT LOAD DIRECTORY NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub bbiSaveLayout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiSaveLayout.ItemClick
        If Directory.Exists(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR) Then
            Dim c As New LayoutTemplates
            c.GridControl1.DataSource = Fileinfo_To_DataTable(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR)
            c.Files_GridView.ViewCaption = "Save Report Template"
            c.LayoutControlItem1.Visibility = LayoutVisibility.Always

            If DevExpress.XtraEditors.XtraDialog.Show(c, "Report Templates - Liquidity Overview", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                If c.FileName_TextEdit.EditValue.ToString <> "" Then
                    Try
                        Dim fileName As String = PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR & c.FileName_TextEdit.EditValue.ToString & ".xml"
                        If System.IO.File.Exists(fileName) Then
                            If XtraMessageBox.Show("Should the current report template be replaced?", "REPORT TEMPLATE ALLREADY EXISTS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
                                System.IO.File.Delete(fileName)
                                Me.PivotGridControl1.SaveLayoutToXml(fileName, PivotGridOptionsLayout.FullLayout)
                                XtraMessageBox.Show("Report Template: " & c.FileName_TextEdit.EditValue.ToString & " successfully saved!", "REPORT TEMPLATE SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.ReportTemplateName_BarStaticItem.Caption = c.FileName_TextEdit.EditValue.ToString
                            Else
                                Return
                            End If
                        Else
                            Me.PivotGridControl1.SaveLayoutToXml(fileName, PivotGridOptionsLayout.FullLayout)
                            XtraMessageBox.Show("Report Template: " & c.FileName_TextEdit.EditValue.ToString & " successfully saved!", "REPORT TEMPLATE SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.ReportTemplateName_BarStaticItem.Caption = c.FileName_TextEdit.EditValue.ToString
                        End If

                    Catch ex As Exception
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If

        Else
            XtraMessageBox.Show("Pivotgrid Layout save directory could not be fund!" & vbNewLine & "Check Parameter:EDP/LAYOUTS_SAVE_DIRECTORY", "LAYOUT SAVE DIRECTORY NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub bbiDeleteLayout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiDeleteLayout.ItemClick
        If Directory.Exists(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR) Then
            Dim c As New LayoutTemplates
            c.GridControl1.DataSource = Fileinfo_To_DataTable(PIVOTGRID_LIQUIDITY_OVERVIEW_LAYOUT_SAVE_DIR)
            c.Files_GridView.ViewCaption = "Delete Report Template"
            c.LayoutControlItem1.Visibility = LayoutVisibility.Never

            If DevExpress.XtraEditors.XtraDialog.Show(c, "Report Templates - Liquidity Overview", MessageBoxButtons.OKCancel) = DialogResult.OK And c.Files_GridView.RowCount > 0 Then
                If c.FileFullPath_TextEdit.EditValue.ToString <> "" Then
                    If XtraMessageBox.Show("Should the report template: " & c.FileName_TextEdit.EditValue.ToString & " be deleted?", "REPORT TEMPLATE DELETE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = vbYes Then
                        Try
                            System.IO.File.Delete(c.FileFullPath_TextEdit.EditValue.ToString)
                            XtraMessageBox.Show("Report Template: " & c.FileName_TextEdit.EditValue.ToString & " successfully deleted!", "REPORT TEMPLATE DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Catch ex As Exception
                            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Return
                        End Try
                    Else
                        Return
                    End If

                End If
            End If

        Else
            XtraMessageBox.Show("Pivotgrid Layout load directory could not be fund!" & vbNewLine & "Check Parameter:EDP/LAYOUTS_SAVE_DIRECTORY", "LAYOUT LOAD DIRECTORY NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub


    Private Sub bbiLoadDefaultLayout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiLoadDefaultLayout.ItemClick
        ' Load the saved layout.
        Me.PivotGridControl1.RestoreLayoutFromStream(str, PivotGridOptionsLayout.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Me.ReportTemplateName_BarStaticItem.Caption = "Default Layout"
    End Sub

    Private Sub LoadDataFromTill_Bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromTill_Bbi.ItemClick
        rd1 = CDate(Me.BS_DateFrom_BarEditItem.EditValue)
        rd2 = CDate(Me.BS_DateTill_BarEditItem.EditValue)
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
            BgwLoadFromTill = New BackgroundWorker
            bgws.Clear()
            bgws.Add(BgwLoadFromTill)
            BgwLoadFromTill.WorkerReportsProgress = True
            BgwLoadFromTill.RunWorkerAsync()


        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Dates criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub BgwLoadFromTill_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadFromTill.DoWork
        Try

            'Data reader
            'Using conn1 As New SqlConnection(conn.ConnectionString)
            '    Using cmd As New SqlCommand()
            '        cmd.Connection = conn1
            '        cmd.CommandText = "Select * from [WpInvest_Totals] where [RiskDate] between '" & rdsql1 & "' and '" & rdsql2 & "'"
            '        cmd.Connection.Open()


            '        Dim objDataReader As SqlDataReader = cmd.ExecuteReader()
            '        objDataTable.Clear()
            '        objDataTable.Load(objDataReader)

            '        cmd.Connection.Close()


            '    End Using
            'End Using


            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_FROM_TILL') and Status in ('Y')"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            da1.SelectCommand.CommandTimeout = 60000
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                da.SelectCommand.CommandTimeout = 60000
                dt = New System.Data.DataTable()
                da.Fill(dt)

            End If

        Catch ex As Exception

            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BgwLoadFromTill_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadFromTill.ProgressChanged

        Me.ProgressPanel1.Caption = e.UserState.ToString

    End Sub

    Private Sub BgwLoadFromTill_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadFromTill.RunWorkerCompleted
        Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.PivotGridControl1.DataSource = Nothing
            Me.PivotGridControl1.DataSource = dt
            Me.PivotGridControl1.ForceInitialize()
            Me.PivotGridControl1.BestFit()
        Else
            XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If


        Workers_Complete(BgwLoadFromTill, e)

    End Sub

    Private Sub LoadDataSelectedDate_Bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataSelectedDate_Bbi.ItemClick
        rd1 = CDate(Me.BS_DateFrom_BarEditItem.EditValue)
        rd2 = CDate(Me.BS_DateTill_BarEditItem.EditValue)
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then
            If ActiveTabGroup = 0 Then
                Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
                BgwLoadOnlyFromTill = New BackgroundWorker
                bgws.Clear()
                bgws.Add(BgwLoadOnlyFromTill)
                BgwLoadOnlyFromTill.WorkerReportsProgress = True
                BgwLoadOnlyFromTill.RunWorkerAsync()
            End If
        Else
                XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Dates criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub BgwLoadOnlyFromTill_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadOnlyFromTill.DoWork
        Try

            ''Data reader
            'Using conn1 As New SqlConnection(conn.ConnectionString)
            '    Using cmd As New SqlCommand()
            '        cmd.Connection = conn1
            '        cmd.CommandText = "Select * from [WpInvest_Totals] where [RiskDate] in ('" & rdsql1 & "' , '" & rdsql2 & "')"
            '        cmd.Connection.Open()
            '        Dim objDataReader As SqlDataReader = cmd.ExecuteReader()
            '        objDataTable.Clear()
            '        objDataTable.Load(objDataReader)
            '        cmd.Connection.Close()
            '    End Using
            'End Using



            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_ONLY_IN_DATES') and Status in ('Y')"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            da1.SelectCommand.CommandTimeout = 60000
                    dt1 = New System.Data.DataTable()
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<FromDate>", rdsql1)
                        Dim SqlCommandTextNew As String = SqlCommandText.ToString.Replace("<TillDate>", rdsql2)
                QueryText = SqlCommandTextNew
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                da.SelectCommand.CommandTimeout = 60000
                        dt = New System.Data.DataTable()
                        da.Fill(dt)

            End If

        Catch ex As Exception

            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BgwLoadOnlyFromTill_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadOnlyFromTill.ProgressChanged

        Me.ProgressPanel1.Caption = e.UserState.ToString

    End Sub

    Private Sub BgwLoadOnlyFromTill_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadOnlyFromTill.RunWorkerCompleted
        Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.PivotGridControl1.DataSource = Nothing
            Me.PivotGridControl1.DataSource = dt
            Me.PivotGridControl1.ForceInitialize()
            Me.PivotGridControl1.BestFit()
        Else
            XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        Workers_Complete(BgwLoadOnlyFromTill, e)

    End Sub



    Private Sub LoadDataFromList_Bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoadDataFromList_Bbi.ItemClick
        Dim c As New SelectFromList_XtraUserControl
        c.Name = "Liquidity Overview - Pivot"
        If DevExpress.XtraEditors.XtraDialog.Show(c, "Select Dates for Liquidity Overview", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            If SELECTED_DATES <> Nothing Then
                Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
                BgwLoadSelection = New BackgroundWorker
                bgws.Clear()
                bgws.Add(BgwLoadSelection)
                BgwLoadSelection.WorkerReportsProgress = True
                BgwLoadSelection.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub BgwLoadSelection_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwLoadSelection.DoWork
        Try

            'Data reader
            'Using conn1 As New SqlConnection(conn.ConnectionString)
            '    Using cmd As New SqlCommand()
            '        cmd.Connection = conn1
            '        cmd.CommandText = "Select * from [WpInvest_Totals] where [RiskDate] in (" & SELECTED_DATES & ") order by [RiskDate] asc"
            '        cmd.Connection.Open()


            '        Dim objDataReader As SqlDataReader = cmd.ExecuteReader()
            '        objDataTable.Clear()
            '        objDataTable.Load(objDataReader)

            '        cmd.Connection.Close()


            '    End Using
            'End Using

            QueryText = "Select * from SQL_PARAMETER_DETAILS where Id_SQL_Parameters in ('SEVERAL SELECTIONS') and SQL_Name_1 in ('LIQUIDITY_OVERVIEW_SELECTION_DATESLIST') and Status in ('Y')"
            da1 = New SqlDataAdapter(QueryText.Trim(), conn)
            da1.SelectCommand.CommandTimeout = 60000
            dt1 = New System.Data.DataTable()
            da1.Fill(dt1)
            If dt1.Rows.Count > 0 Then
                SqlCommandText = dt1.Rows.Item(0).Item("SQL_Command_1").ToString.Replace("<ListOfDates>", SELECTED_DATES)
                QueryText = SqlCommandText
                da = New SqlDataAdapter(QueryText.Trim(), conn)
                da.SelectCommand.CommandTimeout = 60000
                dt = New System.Data.DataTable()
                da.Fill(dt)


            End If


        Catch ex As Exception

            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BgwLoadSelection_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwLoadSelection.ProgressChanged

        Me.ProgressPanel1.Caption = e.UserState.ToString

    End Sub

    Private Sub BgwLoadSelection_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwLoadSelection.RunWorkerCompleted
        Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.PivotGridControl1.DataSource = Nothing
            Me.PivotGridControl1.DataSource = dt
            Me.PivotGridControl1.ForceInitialize()
            Me.PivotGridControl1.BestFit()
        Else
            XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If


        Workers_Complete(BgwLoadSelection, e)

    End Sub

    Private Sub CompareData_Bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CompareData_Bbi.ItemClick
        rd1 = CDate(Me.BS_DateFrom_BarEditItem.EditValue)
        rd2 = CDate(Me.BS_DateTill_BarEditItem.EditValue)
        rdsql1 = rd1.ToString("yyyyMMdd")
        rdsql2 = rd2.ToString("yyyyMMdd")
        If rd2 >= rd1 Then
            If ActiveTabGroup = 1 Then
                Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
                BgwCompareDates = New BackgroundWorker
                bgws.Clear()
                bgws.Add(BgwCompareDates)
                BgwCompareDates.WorkerReportsProgress = True
                BgwCompareDates.RunWorkerAsync()
            End If
        Else
            XtraMessageBox.Show("Please check your inputs" & vbNewLine & "The Date from... is higher than Date till...", "Wrong Dates criteria", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub BgwCompareDates_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwCompareDates.DoWork
        'Differences PivotGrid
        QueryText = "Exec [Liquidity_Overview_Compare] @Min_Date ='" & rdsql1 & "', @Max_Date='" & rdsql2 & "'"
        da = New SqlDataAdapter(QueryText.Trim(), conn)
        da.SelectCommand.CommandTimeout = 60000
        dt = New System.Data.DataTable()
        da.Fill(dt)
    End Sub

    Private Sub BgwCompareDates_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgwCompareDates.ProgressChanged

        Me.ProgressPanel1.Caption = e.UserState.ToString

    End Sub

    Private Sub BgwCompareDates_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwCompareDates.RunWorkerCompleted
        Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.PivotGridControl2.DataSource = Nothing
            Me.PivotGridControl2.DataSource = dt
            Me.PivotGridControl2.ForceInitialize()
            Me.PivotGridField8.Caption = rd1.ToString("dd.MM.yyyy")
            Me.PivotGridField9.Caption = rd2.ToString("dd.MM.yyyy")
            Me.PivotGridControl1.BestFit()
        Else
            XtraMessageBox.Show("No Data fund for the specified period!", "DATA NOT FUND", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If


        Workers_Complete(BgwCompareDates, e)

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbiPreview_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbiPreview.ItemClick
        If ActiveTabGroup = 0 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Load Liquidity Overview Data from " & rd1 & " till " & rd2)
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


End Class