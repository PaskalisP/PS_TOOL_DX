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
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrintingLinks
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class DailyProfitLossSheets

    Dim CrystalRepDir As String = ""

    Dim DF_ProfitLossReconcile As New DatesForm

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim ActivaSum As Double = 0

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim ExpensesDetailViewCaption As String = Nothing
    Dim IncomeDetailsViewCaption As String = Nothing

    Public PSTOOL_Mainform As PSTOOL_MAIN_Form

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


    Private Sub DailyPLSheetExpensesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.DailyPLSheetExpensesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

    Private Sub DailyProfitLossSheets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PSTOOLDataset.DailyBalanceDetailsSheets' table. You can move, or remove it, as needed.
        'Me.DailyBalanceDetailsSheetsTableAdapter.Fill(Me.PSTOOLDataset.DailyBalanceDetailsSheets)
        'Get Max BSDate
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.FromDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[BSDate],104) as 'RLDC Date' from [DailyBalanceSheets] GROUP BY [BSDate] ORDER BY [BSDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.FromDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.FromDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        Dim d As Date = Me.FromDateEdit.Text
        Dim dsql As String = d.ToString("yyyyMMdd")
       

        'Load Balance Sheet
        'INCOME
        Me.DailyPLSheetIncomeTableAdapter.FillByIncomeDate(Me.PSTOOLDataset.DailyPLSheetIncome, d)
        'EXPENSES
        Me.DailyPLSheetExpensesTableAdapter.FillByExpenseDate(Me.PSTOOLDataset.DailyPLSheetExpenses, d)
        'Details
        Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
        'Sum Expenses
        cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=5000 and [GL_Item_Number]<6998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
        cmd.Connection.Open()
        Dim SumExpenses As Double = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SumExpensesTextEdit.Text = SumExpenses
        'Sum Income
        cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=7000 and [GL_Item_Number]<7998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
        cmd.Connection.Open()
        Dim SumIncome As Double = cmd.ExecuteScalar
        cmd.Connection.Close()
        Me.SumIncomesTextEdit.Text = SumIncome
       
        'difference
        Me.PLDifferenceTextEdit.Text = SumIncome + SumExpenses
        'Calculate Profit and Loss
        'If SumIncome > SumExpenses Then
        'Me.LayoutControlItem11.Text = "PROFIT"
        'ElseIf SumIncome < SumExpenses Then
        'Me.LayoutControlItem11.Text = "LOSS"
        'ElseIf SumIncome = SumExpenses Then
        'Me.LayoutControlItem11.Text = "PROFIT/LOSS"
        'End If

    End Sub

    Private Sub LoadPLSheets_btn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ExpensesBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles ExpensesBaseView.MasterRowExpanded
        If Me.GridControl1.FocusedView.Name = "ExpensesDetailView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ExpensesDetailViewCaption = "Expenses details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.ExpensesDetailView.ViewCaption = ExpensesDetailViewCaption
        End If
    End Sub

    Private Sub ExpensesBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles ExpensesBaseView.MasterRowExpanding
        If Me.GridControl1.FocusedView.Name = "ExpensesDetailView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ExpensesDetailViewCaption = "Expenses details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.ExpensesDetailView.ViewCaption = ExpensesDetailViewCaption
        End If
    End Sub

    Private Sub ExpensesBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles ExpensesBaseView.RowClick
        If Me.GridControl1.FocusedView.Name = "ExpensesDetailView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            ExpensesDetailViewCaption = "Expenses details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.ExpensesDetailView.ViewCaption = ExpensesDetailViewCaption
        End If
    End Sub

    Private Sub ExpensesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExpensesBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub IncomeBaseView_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles IncomeBaseView.MasterRowExpanded
        If Me.GridControl2.FocusedView.Name = "IncomeDetailsView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            IncomeDetailsViewCaption = "Income details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.IncomeDetailsView.ViewCaption = IncomeDetailsViewCaption
        End If
    End Sub

    Private Sub IncomeBaseView_MasterRowExpanding(sender As Object, e As MasterRowCanExpandEventArgs) Handles IncomeBaseView.MasterRowExpanding
        If Me.GridControl2.FocusedView.Name = "IncomeDetailsView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            IncomeDetailsViewCaption = "Income details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.IncomeDetailsView.ViewCaption = IncomeDetailsViewCaption
        End If
    End Sub

    Private Sub IncomeBaseView_RowClick(sender As Object, e As RowClickEventArgs) Handles IncomeBaseView.RowClick
        If Me.GridControl2.FocusedView.Name = "IncomeDetailsView" Then

            Dim view As GridView = DirectCast(sender, GridView)
            IncomeDetailsViewCaption = "Income details for GL Item: " & view.GetFocusedRowCellValue("GL_Item").ToString & "  (" & view.GetFocusedRowCellValue("GL_Item_Name").ToString & ")"
            Me.IncomeDetailsView.ViewCaption = IncomeDetailsViewCaption
        End If
    End Sub

    Private Sub IncomeBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IncomeBaseView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FromDateEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FromDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.DailyPLSheetIncomeBindingSource
            Me.GridControl2.DataSource = Me.DailyPLSheetExpensesBindingSource
            If IsDate(Me.FromDateEdit.Text) = True Then
                Dim d As Date = Me.FromDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")
                cmd.Connection.Open()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Profit + Loss Sheet Data for " & d)
                'Load Balance Sheet
                'INCOME
                Me.DailyPLSheetIncomeTableAdapter.FillByIncomeDate(Me.PSTOOLDataset.DailyPLSheetIncome, d)
                'EXPENSES
                Me.DailyPLSheetExpensesTableAdapter.FillByExpenseDate(Me.PSTOOLDataset.DailyPLSheetExpenses, d)
                'Details
                Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
                'Sum Expenses
                cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=5000 and [GL_Item_Number]<6998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
                Dim SumExpenses As Double = cmd.ExecuteScalar
                Me.SumExpensesTextEdit.Text = SumExpenses
                'Sum Income
                cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=7000 and [GL_Item_Number]<7998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
                Dim SumIncome As Double = cmd.ExecuteScalar
                Me.SumIncomesTextEdit.Text = SumIncome

                'difference
                Me.PLDifferenceTextEdit.Text = SumIncome + SumExpenses
                SplashScreenManager.CloseForm(False)
                cmd.Connection.Close()

            End If
        End If
    End Sub

    Private Sub FromDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FromDateEdit.KeyDown
        If IsDate(Me.FromDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.SumExpensesTextEdit.Text = 0
            Me.SumIncomesTextEdit.Text = 0
            Me.PLDifferenceTextEdit.Text = 0
        End If
    End Sub

    Private Sub DailyPLSheet_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles DailyPLSheet_Print_Export_btn.Click
        ' Create objects and define event handlers.
        Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
        AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
        Dim pcLink1 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink2 As PrintableComponentLink = New PrintableComponentLink()
        Dim linkMainReport As Link = New Link()
        AddHandler linkMainReport.CreateDetailArea, AddressOf linkMainReport_CreateDetailArea
        Dim linkGrid1Report As Link = New Link()
        AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
        Dim linkGrid2Report As Link = New Link()
        AddHandler linkGrid2Report.CreateDetailArea, AddressOf linkGrid2Report_CreateDetailArea

        ' Assign the controls to the printing links.
        pcLink1.Component = Me.GridControl2
        pcLink2.Component = Me.GridControl1

        ' Populate the collection of links in the composite link.
        ' The order of operations corresponds to the document structure.
        composLink.Links.Add(linkGrid1Report)
        composLink.Links.Add(pcLink1)
        composLink.Links.Add(linkMainReport)
        composLink.Links.Add(linkGrid2Report)
        composLink.Links.Add(pcLink2)

        composLink.Landscape = True
        composLink.PaperKind = Printing.PaperKind.A4

        ' Create the report and show the preview window.
        composLink.ShowPreviewDialog()
    End Sub

    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim reportfooter As String = "PROFIT + LOSS SHEET" & "  " & "from " & Me.FromDateEdit.Text & "  " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "EXPENSES"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates an interval between the grids and fills it with color.
    Private Sub linkMainReport_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Rect = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        tb.BackColor = Color.Gray
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates a text header for the second grid.
    Private Sub linkGrid2Report_CreateDetailArea(ByVal sender As Object, _
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "INCOME"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 0
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub PLSheetCR_btn_Click(sender As Object, e As EventArgs) Handles PLSheetCR_btn.Click
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating PROFIT + LOSS SHEET REPORT for " & Me.FromDateEdit.Text)
            Me.DailyBalanceSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceSheets, d)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\Profit and Loss Daily.rpt")
            CrRep.SetDataSource(PSTOOLDataset)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "FDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Profit + Loss Sheet Report from " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(75)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

    Private Sub ExpensesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles ExpensesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub IncomeBaseView_ShownEditor(sender As Object, e As EventArgs) Handles IncomeBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ReconciliationsPL_btn_Click(sender As Object, e As EventArgs) Handles ReconciliationsPL_btn.Click
        Dim dxOK_ProfitLossReconciliation As New DevExpress.XtraEditors.SimpleButton
        With dxOK_ProfitLossReconciliation
            .Text = "OK"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
        End With
        DF_ProfitLossReconcile.Controls.Add(dxOK_ProfitLossReconciliation)
        DF_ProfitLossReconcile.OK_btn.Visible = False

        AddHandler dxOK_ProfitLossReconciliation.Click, AddressOf dxOK_ProfitLossReconciliation_click

        DF_ProfitLossReconcile.Show()
        DF_ProfitLossReconcile.Text = "PROFIT and LOSS RECONCILIATION"
        DF_ProfitLossReconcile.Text_lbl.Text = "Please input the Period for report creation"
        With DF_ProfitLossReconcile.DateEdit1
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
        With DF_ProfitLossReconcile.DateEdit2
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With


    End Sub

    Private Sub dxOK_ProfitLossReconciliation_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d1 As Date = DF_ProfitLossReconcile.DateEdit1.Text
        Dim d2 As Date = DF_ProfitLossReconcile.DateEdit2.Text

        DF_ProfitLossReconcile.Close()
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Creating Profit and Loss reconciliation on " & d1 & " to " & d2)


        Dim f As New DailyProfitLossSheets
        f.DailyBalanceSheetsTableAdapter.FillByBSDateFromTill(f.PSTOOLDataset.DailyBalanceSheets, d1, d2)

        Dim CrRep As New ReportDocument
        CrRep.Load(CrystalRepDir & "\Profit Loss Reconcile.rpt")
        CrRep.SetDataSource(f.PSTOOLDataset)
        Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myValue1 As ParameterDiscreteValue = New ParameterDiscreteValue
        Dim myParams As ParameterField = New ParameterField
        Dim myParams1 As ParameterField = New ParameterField
        myValue.Value = d1
        myParams.ParameterFieldName = "FDate"
        myValue1.Value = d2
        myParams1.ParameterFieldName = "LDate"
        myParams.CurrentValues.Add(myValue)
        myParams1.CurrentValues.Add(myValue1)
        Dim c As New CrystalReportsForm
        c.MdiParent = Me.MdiParent
        c.Show()
        c.WindowState = FormWindowState.Maximized
        c.Text = "Balance Sheet reconciliation on " & d1 & " to " & d2
        c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
        c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams1)
        c.CrystalReportViewer1.ReportSource = CrRep
        c.CrystalReportViewer1.ShowParameterPanelButton = False
        c.CrystalReportViewer1.ShowRefreshButton = False
        c.CrystalReportViewer1.ShowGroupTreeButton = False
        c.CrystalReportViewer1.Zoom(85)
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PLDifferenceTextEdit_TextChanged(sender As Object, e As EventArgs) Handles PLDifferenceTextEdit.TextChanged
        If IsNothing(Me.PLDifferenceTextEdit.Text) = False Then
            Dim n As Double = Me.PLDifferenceTextEdit.Text
            If n > 0 Then
                Me.LayoutControlItem11.CustomizationFormText = "PROFIT"
            ElseIf n < 0 Then
                Me.LayoutControlItem11.CustomizationFormText = "LOSS"
            Else
                Me.LayoutControlItem11.CustomizationFormText = "PROFIT/LOSS"
            End If
        End If
    End Sub

    Private Sub ExpensesDetailView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ExpensesDetailView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ExpensesDetailView_ShownEditor(sender As Object, e As EventArgs) Handles ExpensesDetailView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub IncomeDetailsView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles IncomeDetailsView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub IncomeDetailsView_ShownEditor(sender As Object, e As EventArgs) Handles IncomeDetailsView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FromDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FromDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.DailyPLSheetIncomeBindingSource
        Me.GridControl2.DataSource = Me.DailyPLSheetExpensesBindingSource
        If IsDate(Me.FromDateEdit.Text) = True Then
            Dim d As Date = Me.FromDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
            cmd.Connection.Open()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Profit + Loss Sheet Data for " & d)
                'Load Balance Sheet
                'INCOME
                Me.DailyPLSheetIncomeTableAdapter.FillByIncomeDate(Me.PSTOOLDataset.DailyPLSheetIncome, d)
                'EXPENSES
                Me.DailyPLSheetExpensesTableAdapter.FillByExpenseDate(Me.PSTOOLDataset.DailyPLSheetExpenses, d)
                'Details
                Me.DailyBalanceDetailsSheetsTableAdapter.FillByBSDate(Me.PSTOOLDataset.DailyBalanceDetailsSheets, d)
                'Sum Expenses
                cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=5000 and [GL_Item_Number]<6998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
                Dim SumExpenses As Double = cmd.ExecuteScalar
                Me.SumExpensesTextEdit.Text = SumExpenses
                'Sum Income
                cmd.CommandText = "Select Sum([BalanceEUREqu]) from DailyBalanceSheets where [BSDate]='" & dsql & "' and [GL_Item_Number]>=7000 and [GL_Item_Number]<7998" ' and ISNUMERIC(Right([GL_Item_Name],2))=0"
                Dim SumIncome As Double = cmd.ExecuteScalar
                Me.SumIncomesTextEdit.Text = SumIncome

                'difference
                Me.PLDifferenceTextEdit.Text = SumIncome + SumExpenses
            SplashScreenManager.CloseForm(False)
            cmd.Connection.Close()

        End If
    End Sub

   

End Class