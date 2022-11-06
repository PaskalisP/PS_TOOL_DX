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
Public Class CreditRiskMak

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Dim CrystalRepDir As String = ""

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Dim NewPD As Double = 0
    Dim NewER As Double = 0
    Dim NewER45 As Double = 0
    Dim NewCreditRiskAmount As Double = 0
    Dim NewNetCreditRiskAmount As Double = 0
    Dim NewCreditRiskAmount45 As Double = 0
    Dim NewNetCreditRiskAmount45 As Double = 0

    Dim DATES_FORM As New DatesForm
    Dim FDate As Date
    Dim LDate As Date

    Dim CustomersVerticalGrid As New CustomersVG()
    Dim CustomerContractVG As New AllContractsAccountsVG()



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

    Private Sub MAK_CR_TOTALSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.MAK_CR_TOTALSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.RiskControllingDataSet)

    End Sub

    Private Sub CreditRiskMak_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        '***********************************************************************
        '*******CRYSTAL REPORTS DIRECTORY************
        '+++++++++++++++++++++++++++++++++++++++++++++++++++
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        cmd.Connection.Open()
        CrystalRepDir = cmd.ExecuteScalar
        cmd.Connection.Close()
        '***********************************************************************

        'Bind Combobox
        Me.CreditRiskMakDateEdit.Properties.Items.Clear()
        Me.QueryText = "Select CONVERT(VARCHAR(10),[RiskDate],104) as 'RLDC Date' from [MAK CR TOTALS]  Order by [RiskDate] desc"
        da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
        dt = New System.Data.DataTable()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            If dt.Rows.Count > 0 Then
                Me.CreditRiskMakDateEdit.Properties.Items.Add(row("RLDC Date"))
            End If
        Next
        If dt.Rows.Count > 0 Then
            Me.CreditRiskMakDateEdit.Text = dt.Rows.Item(0).Item("RLDC Date")
        End If

        'Get 
        Dim MaxCreditMakDate As Date = Me.CreditRiskMakDateEdit.Text
        


        Me.MAK_REPORTTableAdapter.FillByMAK_FILL(Me.RiskControllingDataSet.MAK_REPORT, MaxCreditMakDate)
        Me.CREDIT_RISKTableAdapter.FillByCREDIT_RISK_FILL(Me.RiskControllingDataSet.CREDIT_RISK, MaxCreditMakDate)
        Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, MaxCreditMakDate)

        Me.CreditRisk_GridView.ExpandAllGroups()
        Me.MakGridView.ExpandAllGroups()


    End Sub

    Private Sub LoadCreditRiskMak_btn_Click(sender As Object, e As EventArgs) Handles LoadCreditRiskMak_btn.Click
       
    End Sub

    Private Sub CreditRiskMakDateEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles CreditRiskMakDateEdit.ButtonClick
        If e.Button.Caption = "Reload" Then
            Me.GridControl1.DataSource = Me.CREDIT_RISKBindingSource
            Me.GridControl2.DataSource = Me.MAK_REPORTBindingSource

            If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
                Dim d As Date = Me.CreditRiskMakDateEdit.Text
                Dim dsql As String = d.ToString("yyyyMMdd")

                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load data for " & d)
                'Load Credit Risk + MAK Data
                Me.MAK_REPORTTableAdapter.FillByMakDate(Me.RiskControllingDataSet.MAK_REPORT, d)
                Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.RiskControllingDataSet.CREDIT_RISK, d)
                Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, d)
                SplashScreenManager.CloseForm(False)

            End If

            Me.CreditRisk_GridView.ExpandAllGroups()
            Me.MakGridView.ExpandAllGroups()
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
        End If
    End Sub

    Private Sub CreditRiskMakDateEdit_Click(sender As Object, e As EventArgs) Handles CreditRiskMakDateEdit.Click
        If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub CreditRiskMakDateEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles CreditRiskMakDateEdit.KeyDown
        If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
            Me.GridControl1.DataSource = Nothing
            Me.GridControl2.DataSource = Nothing
            Me.LayoutControlItem7.Visibility = LayoutVisibility.Never
            Me.LayoutControlItem9.Visibility = LayoutVisibility.Never
        End If
    End Sub

    Private Sub CreditRiskMak_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If Me.CreditRisk_GridView.IsFindPanelVisible Then
        '    'FindControl foo = BT_CP_Totals_GridView.GridControl.Controls[0];
        '    Dim find As FindControl = TryCast(CreditRisk_GridView.GridControl.Controls.Find("FindControl", True)(0), FindControl)
        '    find.FindEdit.Focus()
        'Else
        '    CreditRisk_GridView.ShowFindPanel()
        'End If
    End Sub

    Private Sub CreditRisk_GridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CreditRisk_GridView.CellValueChanged

    End Sub

    Private Sub CreditRisk_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CreditRisk_GridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CreditRisk_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CreditRisk_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub MakGridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MakGridView.RowStyle
        'Set Backcolor to Filter row
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub MakGridView_ShownEditor(sender As Object, e As EventArgs) Handles MakGridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Print_Export_CreditRisk_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_CreditRisk_Gridview_btn.Click
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink1.CreateDocument()
        PrintableComponentLink1.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "CREDIT RISK report " & "   " & "on: " & Me.CreditRiskMakDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub Print_Export_MAK_Gridview_btn_Click(sender As Object, e As EventArgs) Handles Print_Export_MAK_Gridview_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        PrintableComponentLink2.CreateDocument()
        PrintableComponentLink2.ShowPreview()
        SplashScreenManager.CloseForm(False)
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
        Dim reportfooter As String = "MAK report " & "   " & "on: " & Me.CreditRiskMakDateEdit.Text
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

   
    Private Sub DailyRiskTable_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles DailyRiskTable_BarButtonItem.ItemClick
        If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
            Dim d As Date = Me.CreditRiskMakDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Daily Risk Table for " & Me.CreditRiskMakDateEdit.Text)

            'Select Data
            Me.INDUSTRY_VALUESTableAdapter.Fill(Me.RiskControllingDataSet.INDUSTRY_VALUES)
            Me.COUNTRIESTableAdapter.Fill(Me.RiskControllingDataSet.COUNTRIES)
            Me.ContractTypeTableAdapter.Fill(Me.RiskControllingDataSet.ContractType)
            Me.MAK_ALLTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.MAK_ALL, d)
            Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\DAILY_RISK_TABLES.rpt")
            'Dim r As New DAILY_RISK_TABLES
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Daily Risk Table on " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        End If

    End Sub

    Private Sub LoanStructureTable_BarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LoanStructureTable_BarButtonItem.ItemClick
        If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
            Dim d As Date = Me.CreditRiskMakDateEdit.Text
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Creating Loan structure Table for " & Me.CreditRiskMakDateEdit.Text)

            'Select Data
            Me.INDUSTRY_VALUESTableAdapter.Fill(Me.RiskControllingDataSet.INDUSTRY_VALUES)
            Me.COUNTRIESTableAdapter.Fill(Me.RiskControllingDataSet.COUNTRIES)
            Me.ContractTypeTableAdapter.Fill(Me.RiskControllingDataSet.ContractType)
            Me.MAK_ALLTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.MAK_ALL, d)
            Me.BusinessTypesCreditPortfolioLiveTableAdapter.FillByRiskDate(Me.RiskControllingDataSet.BusinessTypesCreditPortfolioLive, d)

            Dim CrRep As New ReportDocument
            CrRep.Load(CrystalRepDir & "\LOAN STRUCTURE TABLE.rpt")
            'Dim r As New LOAN_STRUCTURE_TABLE
            CrRep.SetDataSource(RiskControllingDataSet)
            Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim myParams As ParameterField = New ParameterField
            myValue.Value = d
            myParams.ParameterFieldName = "RepDate"
            myParams.CurrentValues.Add(myValue)
            Dim c As New CrystalReportsForm
            c.MdiParent = Me.MdiParent
            c.Show()
            c.WindowState = FormWindowState.Maximized
            c.Text = "Loan structure Table on " & d
            c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
            c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
            c.CrystalReportViewer1.ReportSource = CrRep
            c.CrystalReportViewer1.ShowParameterPanelButton = False
            c.CrystalReportViewer1.ShowRefreshButton = False
            c.CrystalReportViewer1.ShowGroupTreeButton = False
            c.CrystalReportViewer1.Zoom(85)
            SplashScreenManager.CloseForm(False)

        End If
    End Sub

   

    Private Sub NewObligorGrate_ComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewObligorGrate_ComboBoxEdit.SelectedIndexChanged
        If Me.NewObligorGrate_ComboBoxEdit.Text <> "" Then
            Dim NewObligorGrate As String = Me.NewObligorGrate_ComboBoxEdit.Text
           
            Me.QueryText = "SELECT * FROM [PD] WHERE [Obligor Grade]='" & NewObligorGrate & "'"
            da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
            dt = New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                NewPD = Convert.ToDouble(dt.Rows.Item(0).Item("PD"))
                NewER = Convert.ToDouble(dt.Rows.Item(0).Item("ER_25"))
                NewER45 = Convert.ToDouble(dt.Rows.Item(0).Item("ER_45"))
            End If
               
            Me.PD_txtEdit.Text = NewPD
            Me.ER_txtEdit.Text = NewER
            Me.ER_45_txtEdit.Text = NewER45
            'Calculating Credit Risk Amount (EURO)
            Me.CreditRiskAmountEUR_txtEdit.Text = Math.Round(Me.CreditOutEUR_txtEdit.Text * NewPD * NewER, 2)
            NewCreditRiskAmount = Math.Round(Me.CreditOutEUR_txtEdit.Text * NewPD * NewER, 2)
            Me.CreditRiskAmountEUR45_txtEdit.Text = Math.Round(Me.CreditOutEUR_txtEdit.Text * NewPD * NewER45, 2)
            NewCreditRiskAmount45 = Math.Round(Me.CreditOutEUR_txtEdit.Text * NewPD * NewER45, 2)
            'Calculating Net Credit Risk Amount (EURo)
            Dim row As System.Data.DataRow = Me.CreditRisk_GridView.GetDataRow(CreditRisk_GridView.FocusedRowHandle)
            Dim NetCreditOutstandingAmountEUR As Double = row(14)
            If NetCreditOutstandingAmountEUR <> 0 Then
                Me.NetCreditRiskAmountEUR_txtEdit.Text = Math.Round(NetCreditOutstandingAmountEUR * NewPD * NewER, 2)
                NewNetCreditRiskAmount = Math.Round(NetCreditOutstandingAmountEUR * NewPD * NewER, 2)
                Me.NetCreditRiskAmountEUR45_txtEdit.Text = Math.Round(NetCreditOutstandingAmountEUR * NewPD * NewER45, 2)
                NewNetCreditRiskAmount45 = Math.Round(NetCreditOutstandingAmountEUR * NewPD * NewER45, 2)
            Else
                Me.NetCreditRiskAmountEUR_txtEdit.Text = NewCreditRiskAmount
                NewNetCreditRiskAmount = NewCreditRiskAmount
                Me.NetCreditRiskAmountEUR45_txtEdit.Text = NewCreditRiskAmount45
                NewNetCreditRiskAmount45 = NewCreditRiskAmount45
            End If

           
        End If
    End Sub

    Private Sub RepositoryItemPopupContainerEdit1_Popup(sender As Object, e As EventArgs) Handles RepositoryItemPopupContainerEdit1.Popup
        Me.NewObligorGrate_ComboBoxEdit.Text = ""
        Dim row As System.Data.DataRow = Me.CreditRisk_GridView.GetDataRow(CreditRisk_GridView.FocusedRowHandle)
        Me.PD_txtEdit.Text = row(15)
        Me.ER_txtEdit.Text = row(16)
        Me.CreditRiskAmountEUR_txtEdit.Text = row(17)
        Me.NetCreditRiskAmountEUR_txtEdit.Text = row(18)

    End Sub

   
    Private Sub PopUpContainer_Cancel_btn_Click(sender As Object, e As EventArgs) Handles PopUpContainer_Cancel_btn.Click
        Dim edit As PopupContainerControl = PopupContainerControl1
        edit.OwnerEdit.CancelPopup()

    End Sub

    Private Sub ConfirmNewObligorGrate_btn_Click(sender As Object, e As EventArgs) Handles ConfirmNewObligorGrate_btn.Click

        If Me.NewObligorGrate_ComboBoxEdit.Text <> "" Then
            Dim d As Date = Me.CreditRiskMakDateEdit.Text
            Dim dsql As String = d.ToString("yyyy-MM-dd")


            'Set Fields to accept new Data
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("(1-ER)").OptionsColumn.ReadOnly = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("(1-ER)").OptionsColumn.AllowEdit = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("Credit Risk Amount(EUR Equ)").OptionsColumn.ReadOnly = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("Credit Risk Amount(EUR Equ)").OptionsColumn.AllowEdit = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCredit Risk Amount(EUR Equ)").OptionsColumn.ReadOnly = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCredit Risk Amount(EUR Equ)").OptionsColumn.AllowEdit = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("CreditRiskAmountEUREquER45").OptionsColumn.ReadOnly = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("CreditRiskAmountEUREquER45").OptionsColumn.AllowEdit = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCreditRiskAmountEUREquER45").OptionsColumn.ReadOnly = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCreditRiskAmountEUREquER45").OptionsColumn.AllowEdit = True

            With CreditRisk_GridView
                .SetRowCellValue(.FocusedRowHandle, colObligorRate, Me.NewObligorGrate_ComboBoxEdit.Text)
                .SetRowCellValue(.FocusedRowHandle, colPD, NewPD)
                .SetRowCellValue(.FocusedRowHandle, GridColumn11, NewER)
                .SetRowCellValue(.FocusedRowHandle, colER45, NewER45)
                .SetRowCellValue(.FocusedRowHandle, GridColumn12, NewCreditRiskAmount)
                .SetRowCellValue(.FocusedRowHandle, GridColumn13, NewNetCreditRiskAmount)
                .SetRowCellValue(.FocusedRowHandle, colCreditRiskAmountEUREqu45, NewCreditRiskAmount45)
                .SetRowCellValue(.FocusedRowHandle, colNetCreditRiskAmountEUREquER45, NewNetCreditRiskAmount45)
            End With
           
            'Set Fields to read only
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("PD").OptionsColumn.ReadOnly = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("PD").OptionsColumn.AllowEdit = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("(1-ER)").OptionsColumn.ReadOnly = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("(1-ER)").OptionsColumn.AllowEdit = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("Credit Risk Amount(EUR Equ)").OptionsColumn.ReadOnly = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("Credit Risk Amount(EUR Equ)").OptionsColumn.AllowEdit = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCredit Risk Amount(EUR Equ)").OptionsColumn.ReadOnly = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCredit Risk Amount(EUR Equ)").OptionsColumn.AllowEdit = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("CreditRiskAmountEUREquER45").OptionsColumn.ReadOnly = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("CreditRiskAmountEUREquER45").OptionsColumn.AllowEdit = False
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCreditRiskAmountEUREquER45").OptionsColumn.ReadOnly = True
            Me.CreditRisk_GridView.Columns.ColumnByFieldName("NetCreditRiskAmountEUREquER45").OptionsColumn.AllowEdit = False

            Me.CREDIT_RISKBindingSource.EndEdit()
            Try
                Me.CREDIT_RISKTableAdapter.Update(Me.RiskControllingDataSet.CREDIT_RISK)
                'Update CREDIT RISK
                cmd.CommandText = "UPDATE A SET A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MoodysRating]=B.[MoodysRating],A.[FitchRating]=B.[FitchRating] FROM [CREDIT RISK] A INNER JOIN [PD] B ON A.[Obligor Rate]=B.[Obligor Grade] WHERE A.[RiskDate]='" & dsql & "'"
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                'Füllen des Feldes CREDIT RISK und NET CREDIT RISK in Tabelle CR_MAK_TOTALS
                cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRisk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & dsql & "' and [Contract Type]<>'LIMIT') WHERE [RiskDate]='" & dsql & "'"
                cmd.ExecuteScalar()
                cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRiskCashpledge]=(SELECT Sum([NetCredit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & dsql & "' and [Contract Type]<>'LIMIT') WHERE [RiskDate]='" & dsql & "'"
                cmd.ExecuteScalar()
                '*******************************************************************************************************
                'UPDATE RISK LIMIT DAILY CONTROL
                cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & dsql & "'"
                Dim t As String = cmd.ExecuteScalar
                If IsNothing(t) = False Then
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Credit Risk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & dsql & "' and [Contract Type]<>'LIMIT'),[CreditRiskCashPledge]=(SELECT Sum([NetCredit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & dsql & "' and [Contract Type]<>'LIMIT') WHERE [RLDC Date]='" & dsql & "'"
                    cmd.ExecuteScalar()
                End If
                If IsNothing(t) = True Then
                    cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date],[Credit Risk],[CreditRiskCashPledge],[IdBank]) Values('" & dsql & "',(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & dsql & "' and [Contract Type]<>'LIMIT'),(SELECT Sum([NetCredit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & dsql & "' and [Contract Type]<>'LIMIT'),'3')"
                    cmd.ExecuteScalar()
                End If
                'Calculating the RISK BEARING CAPACITY
                Dim s1 As Double = 0
                cmd.CommandText = "select sum(round([CreditRiskCashPledge]/1000,0)+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+[Operational risk]+[Liquidity risk]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & dsql & "'"
                s1 = cmd.ExecuteScalar
                Dim s2 As Double = 0
                cmd.CommandText = "select sum([Dotation capital]-[Minimum capital requirement]+round([PL Result]/1000,0)) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & dsql & "'"
                s2 = cmd.ExecuteScalar
                Dim RBC As Double = (s1 / s2) * 100
                'MsgBox(s1 & "  " & s2 & "  " & RBC)
                cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & dsql & "'"
                cmd.ExecuteScalar()
                '********************************************************************************************************
                cmd.Connection.Close()
                'Load Credit Risk + MAK Data
                Me.MAK_REPORTTableAdapter.FillByMakDate(Me.RiskControllingDataSet.MAK_REPORT, d)
                Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.RiskControllingDataSet.CREDIT_RISK, d)
                Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, d)

            Catch ex As System.Exception
                MessageBox.Show(ex.Message, "ERROR ON SAVE DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try



        End If

    End Sub

    Private Sub RecalculateCreditRiskCurrentDateBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RecalculateCreditRiskCurrentDateBarButtonItem.ItemClick
        Try
            If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
                If MessageBox.Show("Should the Credit Risk be re-calculated for current Day?" & vbNewLine & vbNewLine & "Please note that this recalculation will affect the Unexpected loss Amount and also the Risk Bearing Capacity!!!" & vbNewLine & vbNewLine & "You wish to proceed with the recalculation?", "CREDIT RISK RE_CALCULATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                    Dim rd As Date = Me.CreditRiskMakDateEdit.Text
                    Dim rdsql As String = rd.ToString("yyyyMMdd")
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Recalculating Credit Risk for current Date")
                    cmd.Connection.Open()
                    SplashScreenManager.Default.SetWaitFormCaption("Delete Contract Types FXD and FXMK from CREDIT RISK and MAK REPORT for current Date")
                    cmd.CommandText = "DELETE  from [CREDIT RISK] where [Contract Type] in ('FXD','FXMK') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "DELETE  from [MAK REPORT] where [Contract Type] in ('FXD','FXMK') and [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Set all Data in Credit Risk to default for current Date")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [Obligor Rate]='U',PD=0,[(1-ER)]=0,[Credit Risk Amount(EUR Equ)]=0,[NetCredit Risk Amount(EUR Equ)]=0, [(1-ER_45)]=0,[NetCreditOutstandingAmountEUR]=NULL,[CreditRiskAmountEUREquER45]=NULL,[NetCreditRiskAmountEUREquER45]=NULL,[ClientGroup]=NULL,[ClientGroupName]=NULL where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'DEFINE CLIENT GROUP,CLIENT GROUP NAME IN CUSTOMER RATING
                    SplashScreenManager.Default.SetWaitFormCaption("Set CLIENT GROUP,CLIENT GROUP NAME to NULL")
                    cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]=NULL,[ClientGroupName]=NULL"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Define CLIENT GROUP,CLIENT GROUP NAME in CUSTOMER RATING from MAK ALL DATA")
                    cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]=B.[Client Group] from [CUSTOMER_RATING] A INNER JOIN [MAK REPORT] B ON A.[ClientNo]=B.[Client No]"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Define CLIENT GROUP NAME from Parameter REPORT/CLIENT_GROUP_DEFINE")
                    Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('CLIENT_GROUP_DEFINE') and [PARAMETER STATUS]='Y'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("PARAMETER1")
                        Dim ClientGroupName As String = dt.Rows.Item(i).Item("PARAMETER2")
                        cmd.CommandText = "UPDATE [CUSTOMER_RATING] SET [ClientGroupName]='" & ClientGroupName & "' where [ClientGroup]= '" & ClientGroup & "'"
                        cmd.ExecuteNonQuery()
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Define SUB CLIENT GROUP NAME from Parameter REPORT/SUB_CLIENT_GROUP_DEFINE")
                    Me.QueryText = "select * from [PARAMETER]  where [IdABTEILUNGSPARAMETER] in ('SUB_CLIENT_GROUP_DEFINE') and [PARAMETER STATUS]='Y'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientNo As String = dt.Rows.Item(i).Item("PARAMETER1")
                        Dim ClientGroupName As String = dt.Rows.Item(i).Item("PARAMETER2")
                        Dim NewClientGroup As String = dt.Rows.Item(i).Item("PARAMETER INFO")
                        cmd.CommandText = "UPDATE [CUSTOMER_RATING] SET [ClientGroup]='" & NewClientGroup & "',[ClientGroupName]='" & ClientGroupName & "' where [ClientNo]= '" & ClientNo & "'"
                        cmd.ExecuteNonQuery()
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Set CLIENT GROUP=0 if CLIENT GROUP is Null")
                    cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]=0 where [ClientGroup] is NULL "
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Set CLIENT GROUP=CLIENT NO if CLIENT GROUP=0")
                    cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroup]=[ClientNo] where [ClientGroup]=0"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Define CLIENT GROUP NAME if is NULL")
                    cmd.CommandText = "UPDATE [CUSTOMER_RATING] set [ClientGroupName]=[ClientName] where [ClientGroupName] is NULL "
                    cmd.ExecuteNonQuery()
                    '**********************************************************************************************************************
                    SplashScreenManager.Default.SetWaitFormCaption("Update PD,ER1,ER2 based on Customer Rating for current Date")
                    cmd.CommandText = "UPDATE A SET A.[Obligor Rate]=B.[Rating],A.[PD]=B.[PD],A.[(1-ER)]=B.[ER_25],A.[(1-ER_45)]=B.[ER_45],A.[CoreDefinition]=B.[CoreDefinition],A.[StandardPoorsRating]=B.[StandardPoorsRating],A.[MoodysRating]=B.[MoodysRating],A.[FitchRating]=B.[FitchRating],A.[ClientGroup]=B.[ClientGroup],A.[ClientGroupName]=B.[ClientGroupName] FROM [CREDIT RISK] A INNER JOIN [CUSTOMER_RATING] B ON A.[Client No]=B.[ClientNo] WHERE A.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Set ER1=20 % if Product Type CLCCTP and FRP for current Date")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [(1-ER)]=0.20 WHERE [RiskDate]='" & rdsql & "' and [Product Type] in ('CLCCTP','FRP')"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Set ER1=45 % if Contract Type SECUR for current Date")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [(1-ER)]=0.45 WHERE [RiskDate]='" & rdsql & "' and [Contract Type] in ('SECUR')"
                    cmd.ExecuteNonQuery()
                    'Define MaturityWithoutCapFloor in CREDIT RISK
                    SplashScreenManager.Default.SetWaitFormCaption("Define MaturityWithoutCapFloor in CREDIT RISK")
                    Dim NextHalfYearDate As Date = DateAdd(DateInterval.Month, 6, rd)
                    Me.QueryText = "select * from [CREDIT RISK] where [RiskDate]='" & rdsql & "' and [Maturity Date] is not NULL and [Contract Type] not in ('LIMIT')"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ID As String = dt.Rows.Item(i).Item("ID")
                        Dim MaturityDate As Date = dt.Rows.Item(i).Item("Maturity Date")
                        Dim DiffernceRiskDateMaturityDate As Double = 0
                        If MaturityDate = DateSerial(9999, 12, 31) Then
                            DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, NextHalfYearDate) / 365.25, 2)
                            cmd.CommandText = "UPDATE [CREDIT RISK] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                            cmd.ExecuteNonQuery()
                        Else
                            DiffernceRiskDateMaturityDate = Math.Round(DateDiff(DateInterval.Day, rd, MaturityDate) / 365.25, 2)
                            cmd.CommandText = "UPDATE [CREDIT RISK] Set [MaturityWithoutCapFloor]=" & Str(DiffernceRiskDateMaturityDate) & " where [ID]='" & ID & "'"
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Recalculate Credit Outstanding ER1 and ER2 for current Date")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [Credit Risk Amount(EUR Equ)]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER)],2),[CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [Obligor Rate] not in ('U','CA')"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Recalculate NetCreditOutstanding with Cash pledge consideration for current Date")
                    Me.QueryText = "select * from [CREDIT RISK CASH PLEDGE]  where [Valid]='Y'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim CashPledgeAmount As Double = dt.Rows.Item(i).Item("CashpledgeAmount")
                        Me.QueryText = "select * from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [Client No]='" & dt.Rows.Item(i).Item("CustomerNr") & "' and [Contract Type]<>'LIMIT'"
                        da1 = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                        dt1 = New DataTable()
                        da1.Fill(dt1)
                        For y = 0 To dt1.Rows.Count - 1
                            Dim CreditOutstandingEURequ As Double = dt1.Rows.Item(y).Item("Credit Outstanding (EUR Equ)")
                            If CreditOutstandingEURequ < CashPledgeAmount Then
                                'cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                'cmd.ExecuteScalar()
                                cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                cmd.ExecuteNonQuery()
                                CashPledgeAmount = CashPledgeAmount - CreditOutstandingEURequ
                            ElseIf CreditOutstandingEURequ > CashPledgeAmount Then
                                'cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]='" & Str(CreditOutstandingEURequ - CashPledgeAmount) & "',[NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                'cmd.ExecuteScalar()
                                'cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                'cmd.ExecuteScalar()
                                cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]='" & Str(CreditOutstandingEURequ - CashPledgeAmount) & "',[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                cmd.ExecuteNonQuery()
                                CashPledgeAmount = 0
                            ElseIf CreditOutstandingEURequ = CashPledgeAmount Then
                                'cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                'cmd.ExecuteScalar()
                                cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=0,[InternalInfo]='CASHPLEDGE' Where [ID]='" & dt1.Rows.Item(y).Item("ID") & "' and [Obligor Rate] not in ('U','CA')"
                                cmd.ExecuteNonQuery()
                                CashPledgeAmount = 0
                            End If
                        Next
                    Next
                    'Credit Risk Outstanding Amount auf NetCreditRiskOutstandingAmount stellen wenn InternalInfo<>CASHPLEDGE
                    SplashScreenManager.Default.SetWaitFormCaption("Set NetCreditOutstandingAmountEUR=Credit Risk Amount(EUR Equ) where InternalInfo not CASHPLEDGE")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [NetCreditOutstandingAmountEUR]=[Credit Outstanding (EUR Equ)] Where [RiskDate]='" & rdsql & "' and [InternalInfo] not in ('CASHPLEDGE')"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Recalculating Credit Risk Amount again based on the new PD,ER for definted Obligor Grates (Not U and CA)")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [Credit Risk Amount(EUR Equ)]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER)],2),[CreditRiskAmountEUREquER45]=Round([Credit Outstanding (EUR Equ)]*[PD]*[(1-ER_45)],2),[NetCredit Risk Amount(EUR Equ)]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER)],2),[NetCreditRiskAmountEUREquER45]=Round([NetCreditOutstandingAmountEUR]*[PD]*[(1-ER_45)],2) where [RiskDate]='" & rdsql & "' and [Obligor Rate] not in ('U','CA')"
                    cmd.ExecuteNonQuery()

                    SplashScreenManager.Default.SetWaitFormCaption("Delete Data in BusinessTypesCreditPortfolioDetails for current Date")
                    cmd.CommandText = "DELETE FROM [BusinessTypesCreditPortfolioDetails] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        If IsDBNull(dt.Rows.Item(i).Item("SQLBusinessTypeDetails")) = False And dt.Rows.Item(i).Item("BusinesType") <> "" Then
                            cmd.CommandText = dt.Rows.Item(i).Item("SQLBusinessTypeDetails")
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    'Execute SQL Commands for Sum
                    Me.QueryText = "select * from [BusinessTypesCreditPortfolioLive] where [DateMakCrTotals]='" & rdsql & "'"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        If dt.Rows.Item(i).Item("BusinesType") <> "" Then
                            'Sum Credit Risk Amount
                            cmd.CommandText = "Select sum([Credit Outstanding (EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                            Dim BusinessTypeAmount As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                BusinessTypeAmount = cmd.ExecuteScalar * 1
                            Else
                                BusinessTypeAmount = 0
                            End If
                            cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [AmountBusinessType]='" & Str(BusinessTypeAmount) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            'Sume Net Credit Risk Amount ER1
                            cmd.CommandText = "Select sum([NetCredit Risk Amount(EUR Equ)]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                            Dim NetCreditRiskAmountER1 As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                NetCreditRiskAmountER1 = cmd.ExecuteScalar * 1
                            Else
                                NetCreditRiskAmountER1 = 0
                            End If
                            cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER1]='" & Str(NetCreditRiskAmountER1) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                            'Sume Net Credit Risk Amount ER2
                            cmd.CommandText = "Select sum([NetCreditRiskAmountEUREquER45]) from [BusinessTypesCreditPortfolioDetails] where [IdBusinessTypeLive]='" & dt.Rows.Item(i).Item("ID") & "'"
                            Dim NetCreditRiskAmountER2 As Double = 0
                            If cmd.ExecuteScalar IsNot DBNull.Value Then
                                NetCreditRiskAmountER2 = cmd.ExecuteScalar * 1
                            Else
                                NetCreditRiskAmountER2 = 0
                            End If
                            cmd.CommandText = "UPDATE [BusinessTypesCreditPortfolioLive] SET [NetCreditRiskAmountER2]='" & Str(NetCreditRiskAmountER2) & "' where [ID]='" & dt.Rows.Item(i).Item("ID") & "'"
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Übernahme der Summe von Credit Risk Amount (EUR Equ) an RISK LIMIT DAILY CONTROL und SumCreditRisk in MAK_CR_TOTALS
                    SplashScreenManager.Default.SetWaitFormCaption("Update Credit Risk Sum for current Date")
                    Dim sumCreditRiskAmountEUR As Double = 0
                    'Summe des Credit Risk Amounts(EUR Equ)
                    cmd.CommandText = "SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT'"
                    sumCreditRiskAmountEUR = cmd.ExecuteScalar
                    'Füllen des Feldes CREDIT RISK in Tabelle MAK CR TOTALS
                    cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRisk]='" & Str(sumCreditRiskAmountEUR) & "' WHERE [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteScalar()

                    '*********************************************************************************
                    '***************************UNEXPECTED LOSS CALCULATION***************************
                    '*********************************************************************************
                    'Delete Data in Unexpected Loss Table
                    cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS_Details] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Delete Data in UNEXPECTED LOSS Table for " & rd)
                    cmd.CommandText = "DELETE FROM [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Insert Risk Date in UNEXPECTED LOSS DATE (Foreign Key violation)
                    SplashScreenManager.Default.SetWaitFormCaption("Insert RiskDate in UNEXPECTED LOSS DATE Table")
                    cmd.CommandText = "SELECT [RiskDate] FROM [UNEXPECTED_LOSS_DATE] WHERE [RiskDate]='" & rdsql & "'"
                    Dim Unexp As String = cmd.ExecuteScalar
                    If IsNothing(Unexp) = False Then
                    Else
                        cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS_DATE]([RiskDate]) Values('" & rdsql & "')"
                        cmd.ExecuteScalar()
                    End If
                    'Calculation in CREDIT RISK
                    SplashScreenManager.Default.SetWaitFormCaption("Update EaDweigthedMaturityWithoutCapFloor and LGDfinalEaDweighted in CREDIT RISK")
                    cmd.CommandText = "UPDATE [CREDIT RISK] SET [EaDweigthedMaturityWithoutCapFloor]=Round([MaturityWithoutCapFloor]*[NetCreditOutstandingAmountEUR],2),[LGDfinalEaDweighted]=Round([(1-ER_45)]*[NetCreditOutstandingAmountEUR],2),[PDxFinalEaD]=Round([PD]*[NetCreditOutstandingAmountEUR],2) where  [RiskDate]='" & rdsql & "' and [PD]<>0 and [Contract Type]<>'LIMIT' "
                    cmd.ExecuteNonQuery()
                    'UNEXPECTED LOSS
                    SplashScreenManager.Default.SetWaitFormCaption("Insert Client Group,Risk Date from CREDIT RISK in UNEXPECTED LOSS Table grouped by Client Group and RiskDate")
                    cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS]([ClientGroup],[RiskDate]) SELECT [ClientGroup],[RiskDate] from [CREDIT RISK] where [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT' GROUP BY [ClientGroup],[RiskDate]"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Insert relevant Data to UNEXPECTED_LOSS_Details")
                    Me.QueryText = "Select [ID],[ClientGroup] from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "' "
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ID As Double = dt.Rows.Item(i).Item("ID")
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                        cmd.CommandText = "INSERT INTO [UNEXPECTED_LOSS_Details]([Obligor Rate],[Contract Type],[Product Type],[GL Master / Account Type],[Counterparty/Issuer/Collateral Name],[Client No],[Contract Collateral ID],[Maturity Date],[Remaining Year(s) to Maturity],[Org Ccy],[Credit Outstanding (Org Ccy)],[Credit Outstanding (EUR Equ)],[NetCreditOutstandingAmountEUR],[InternalInfo],[PD],[(1-ER)],[Credit Risk Amount(EUR Equ)],[NetCredit Risk Amount(EUR Equ)],[(1-ER_45)],[CreditRiskAmountEUREquER45],[NetCreditRiskAmountEUREquER45],[CoreDefinition],[ClientGroup],[ClientGroupName],[MaturityWithoutCapFloor],[EaDweigthedMaturityWithoutCapFloor],[PDxFinalEaD],[LGDfinalEaDweighted],[RiskDate],[IdClientGroup]) SELECT B.[Obligor Rate],B.[Contract Type],B.[Product Type],B.[GL Master / Account Type],B.[Counterparty/Issuer/Collateral Name],B.[Client No],B.[Contract Collateral ID],B.[Maturity Date],B.[Remaining Year(s) to Maturity],B.[Org Ccy],B.[Credit Outstanding (Org Ccy)],B.[Credit Outstanding (EUR Equ)],B.[NetCreditOutstandingAmountEUR],B.[InternalInfo],B.[PD],B.[(1-ER)],B.[Credit Risk Amount(EUR Equ)],B.[NetCredit Risk Amount(EUR Equ)],B.[(1-ER_45)],B.[CreditRiskAmountEUREquER45],B.[NetCreditRiskAmountEUREquER45],B.[CoreDefinition],B.[ClientGroup],B.[ClientGroupName],B.[MaturityWithoutCapFloor],B.[EaDweigthedMaturityWithoutCapFloor],B.[PDxFinalEaD],B.[LGDfinalEaDweighted],B.[RiskDate]," & Str(ID) & " from [CREDIT RISK] B where B.[ClientGroup]='" & ClientGroup & "' and B.[RiskDate]='" & rdsql & "' and B.[PD]<>0 and B.[Contract Type]<>'LIMIT' "
                        cmd.ExecuteNonQuery()
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Update Client Group Name in UNEXPECTED LOSS Table")
                    cmd.CommandText = "UPDATE A SET A.[ClientGroupName]=B.[ClientGroupName] from [UNEXPECTED_LOSS] A INNER JOIN [CREDIT RISK] B ON A.[ClientGroup]=B.[ClientGroup] where A.[RiskDate]='" & rdsql & "' and B.[RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    SplashScreenManager.Default.SetWaitFormCaption("Update SubBorrowersCounter in UNEXPECTED LOSS Table from CREDIT RISK where PD<>0")
                    Me.QueryText = "Select Count([ClientGroup]) as SubBorrowerCount,[ClientGroup] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0 and [Contract Type]<>'LIMIT' GROUP BY [ClientGroup]"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                        Dim SubBorrowerCount As Double = dt.Rows.Item(i).Item("SubBorrowerCount")
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [SubBorrowersCounter]=" & Str(SubBorrowerCount) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Update FinalEadTotalSum,LGD,PD_EaD_weigthed in UNEXPECTED LOSS Table from CREDIT RISK  where PD<>0 and Contract Type <>LIMIT")
                    Me.QueryText = "Select Sum([NetCreditOutstandingAmountEUR]) as SumNetCreditOutstandingEURequ,Sum([LGDfinalEaDweighted]) as SumLGD,Sum([PDxFinalEaD]) as SumPDxFinalEaD,[ClientGroup] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0 and [Contract Type]<>'LIMIT' GROUP BY [ClientGroup]"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                        Dim SumNetCreditOutstandingEURequUNEXPECT As Double = dt.Rows.Item(i).Item("SumNetCreditOutstandingEURequ")
                        If SumNetCreditOutstandingEURequUNEXPECT <> 0 Then
                            cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [FinalEadTotalSum]=" & Str(SumNetCreditOutstandingEURequUNEXPECT) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                            cmd.ExecuteNonQuery()
                        End If
                        Dim SumLGD As Double = dt.Rows.Item(i).Item("SumLGD")
                        cmd.CommandText = "Select [FinalEadTotalSum] from [UNEXPECTED_LOSS] where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                        Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                        Dim LGD As Double = Math.Round(SumLGD / FinalEadTotalSum, 2)
                        Dim SumPDxFinalEaD As Double = dt.Rows.Item(i).Item("SumPDxFinalEaD")
                        If FinalEadTotalSum <> 0 AndAlso SumLGD <> 0 Then
                            Dim PD_EaD_weighted As Double = Math.Round(SumPDxFinalEaD / FinalEadTotalSum, 5)
                            cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [LGD]=" & Str(LGD) & ",[PD_EaD_weighted]=" & Str(PD_EaD_weighted) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Update PD_3bps_floor in UNEXPECTED LOSS Table")
                    Me.QueryText = "Select [PD_EaD_weighted],[ClientGroup] from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' GROUP BY [ClientGroup],[PD_EaD_weighted]"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                        Dim PD_EaD_weighted As Double = dt.Rows.Item(i).Item("PD_EaD_weighted")
                        Dim CheckNumber As Double = 0.0003
                        Dim MaxNumber As Double = 0
                        'Get PD_3bps_floor
                        If PD_EaD_weighted > CheckNumber Then
                            MaxNumber = PD_EaD_weighted
                            'MsgBox("Greater" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                        Else
                            MaxNumber = CheckNumber
                            'MsgBox("Less" & "  " & PD_EaD_weighted & "   " & CheckNumber & "   " & MaxNumber)
                        End If
                        Dim SecondNumber As Double = 0
                        If PD_EaD_weighted = 0 Then
                            SecondNumber = 0
                            'MsgBox("Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                        Else
                            SecondNumber = 1
                            'MsgBox("Not Equal 0" & "  " & PD_EaD_weighted & "   " & SecondNumber)
                        End If
                        Dim PD_3bps_floor As Double = MaxNumber * SecondNumber
                        'MsgBox("PD_3bpsfloor " & PD_3bps_floor)
                        'Get IndicatorOfFloor
                        Dim IndicatorOfFloor As Double = 0
                        Dim difference As Double = PD_3bps_floor - PD_EaD_weighted
                        'MsgBox(difference)
                        If difference > 0 Then
                            IndicatorOfFloor = 1
                        Else
                            IndicatorOfFloor = 0
                        End If
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [PD_3bps_floor]=" & Str(PD_3bps_floor) & ",[IndicatorOfFloor]=" & Str(IndicatorOfFloor) & " where [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "'"
                        cmd.ExecuteNonQuery()
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Update MaturityEADweigthed in UNEXPECTED LOSS Table")
                    Me.QueryText = "Select Sum([EaDweigthedMaturityWithoutCapFloor]) as SumEaDweigthedMaturityWithoutCapFloor,[ClientGroup] from [CREDIT RISK]  Where [RiskDate]='" & rdsql & "' and [PD]<>0 and [Contract Type]<>'LIMIT' GROUP BY [ClientGroup]"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                        Dim SumEaDweigthedMaturityWithoutCapFloor As Double = dt.Rows.Item(i).Item("SumEaDweigthedMaturityWithoutCapFloor")
                        cmd.CommandText = "Select [FinalEadTotalSum] from [UNEXPECTED_LOSS] where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                        Dim FinalEadTotalSum As Double = cmd.ExecuteScalar
                        Dim Variable1 As Double = SumEaDweigthedMaturityWithoutCapFloor / FinalEadTotalSum
                        Dim CheckNumber As Double = 5
                        Dim Variable2 As Double = 0
                        If Variable1 > 5 Then
                            Variable2 = 5
                        Else
                            Variable2 = Variable1
                        End If
                        Dim Variable3 As Double = 0
                        If Variable2 > 1 Then
                            Variable3 = Variable2
                        Else
                            Variable3 = 1
                        End If
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [MaturityEADweigthed]=" & Str(Variable3) & " where [ClientGroup]='" & ClientGroup & "' and [RiskDate]='" & rdsql & "' "
                        cmd.ExecuteNonQuery()
                    Next
                    SplashScreenManager.Default.SetWaitFormCaption("Update R_CoefficientOfColleration and b_MaturityAdjustment in UNEXPECTED LOSS Table")
                    Me.QueryText = "Select [PD_3bps_floor],[ClientGroup] from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "'  GROUP BY [ClientGroup],[PD_3bps_floor]"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ClientGroup As String = dt.Rows.Item(i).Item("ClientGroup")
                        Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                        Dim PDminus As Double = PD * (-50)
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [R_CoefficientOfColleration]=(SELECT 0.12 * (1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50))+0.24 * (1-(1- Power(2.71828182845904," & Str(PDminus) & ")/1-Power(2.71828182845904,-50)))) where  [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [b_MaturityAdjustment]=(SELECT Power(0.11852-0.05478 * Log(" & Str(PD) & ") ,2)) where  [RiskDate]='" & rdsql & "' and [ClientGroup]='" & ClientGroup & "' "
                        cmd.ExecuteNonQuery()
                        'Set b_MaturityAdjustment to 0 if NULL
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [b_MaturityAdjustment]=0 where  [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment] is NULL"
                        cmd.ExecuteNonQuery()
                    Next
                    'Get LevelOfConfidence from UNEXPTECTED_LOSS_DATE
                    SplashScreenManager.Default.SetWaitFormCaption("Get LEVEL OF CONFIDENCE from UNEXPECTED LOSS DATE Table")
                    cmd.CommandText = "Select [LevelOfConfidence] from [UNEXPECTED_LOSS_DATE] where [RiskDate]='" & rdsql & "'"
                    Dim LevelOfConfidence As Double = cmd.ExecuteScalar

                    SplashScreenManager.Default.SetWaitFormCaption("Update RW_RiskWeightedExposure and UL_UnexpectedLoss in UNEXPECTED LOSS Table")
                    Me.QueryText = "Select * from [UNEXPECTED_LOSS]  Where [RiskDate]='" & rdsql & "' and [b_MaturityAdjustment]<>0"
                    da = New SqlDataAdapter(Me.QueryText.Trim(), conn)
                    dt = New DataTable()
                    da.Fill(dt)
                    For i = 0 To dt.Rows.Count - 1
                        Dim ID As String = dt.Rows.Item(i).Item("ID")
                        Dim LGD As Double = dt.Rows.Item(i).Item("LGD")
                        Dim R As Double = dt.Rows.Item(i).Item("R_CoefficientOfColleration")
                        Dim PD As Double = dt.Rows.Item(i).Item("PD_3bps_floor")
                        Dim M As Double = dt.Rows.Item(i).Item("MaturityEADweigthed")
                        Dim b As Double = dt.Rows.Item(i).Item("b_MaturityAdjustment")
                        'Get First Part of Formula
                        cmd.CommandText = "SELECT " & Str(LGD) & "*dbo.GET_NORMSDIST_CALC((1/sqrt(1-" & Str(R) & ")* dbo.GET_NORMSINV_CALC(" & Str(PD) & ",1)+Sqrt(" & Str(R) & ")/Sqrt(1.0-" & Str(R) & ")*dbo.GET_NORMSINV_CALC(" & Str(LevelOfConfidence) & ",1))) -" & Str(LGD) & "*" & Str(PD) & "  as FirstPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "' "
                        Dim FirstPartFormulaRW = cmd.ExecuteScalar
                        'Get Second Part of Formula
                        cmd.CommandText = "select (1+(" & Str(M) & "-2.5)*" & Str(b) & ")/(1-1.5*" & Str(b) & ")*12.5*1.06 as SecondPartFormulaRW from [UNEXPECTED_LOSS] where [ID]='" & ID & "'"
                        Dim SecondPartFormulaRW = cmd.ExecuteScalar
                        Dim RW_Calculated As Double = FirstPartFormulaRW * SecondPartFormulaRW
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [RW_RiskWeightedExposure]=" & Str(RW_Calculated) & " where [ID]='" & ID & "' "
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [UNEXPECTED_LOSS] SET [UL_UnexpectedLoss]=Round([RW_RiskWeightedExposure]*[FinalEadTotalSum]*0.08,2) where [ID]='" & ID & "' "
                        cmd.ExecuteNonQuery()
                    Next
                    'Update Sume Unexpected Loss
                    SplashScreenManager.Default.SetWaitFormCaption("Update Sum Unexpected Loss in UNEXPECTED LOSS DATE Table")
                    cmd.CommandText = "UPDATE [UNEXPECTED_LOSS_DATE] SET [SumUL]=(Select Sum([UL_UnexpectedLoss]) from [UNEXPECTED_LOSS] where [RiskDate]='" & rdsql & "') where [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()



                    'Übernahme in RISK LIMIT DAILY CONTROL
                    'Prüfen ob Risk Date vorhanden ist
                    SplashScreenManager.Default.SetWaitFormCaption("Update Credit Risk Sum in RISK LIMIT DAILY CONTROL for current Date")
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t1 As String = cmd.ExecuteScalar
                    If IsNothing(t1) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[Credit Risk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT') WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If
                    If IsNothing(t1) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                        cmd.ExecuteScalar()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [Credit Risk]=(SELECT Sum([Credit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT'),[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    SplashScreenManager.Default.SetWaitFormCaption("Update Credit Outstanding Risk Sum for current Date")
                    'Übernahme der Summen von Credit Outstanding(EUR Equ)(CREDIT RISK REPORT) und EuroEquivalent(MAK REPORT) in CR_MAK_TOTALS
                    Dim sumCreditOutstandingEURequ As Double = 0
                    Dim sumMAKEuroEquivalent As Double = 0
                    Dim sumdifference As Double = 0
                    cmd.CommandText = "SELECT Sum([Credit Outstanding (EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "'"
                    sumCreditOutstandingEURequ = cmd.ExecuteScalar
                    cmd.CommandText = "SELECT Sum([Euro Equivalent]) FROM [MAK REPORT] WHERE [RiskDate]='" & rdsql & "'"
                    sumMAKEuroEquivalent = cmd.ExecuteScalar
                    sumdifference = sumCreditOutstandingEURequ - sumMAKEuroEquivalent
                    'Füllen der felder in Tabelle CR_MAK_TOTALS
                    cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditOutstandingEURequ]='" & Str(sumCreditOutstandingEURequ) & "',[SumEuroEquivalent]='" & Str(sumMAKEuroEquivalent) & "',[SumsDifference]='" & Str(sumdifference) & "' WHERE [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    'Übernahme der Summe von Credit Risk Amount (Cashpledge) an RISK LIMIT DAILY CONTROL und SumCreditRisk Cashpledge in MAK_CR_TOTALS
                    SplashScreenManager.Default.SetWaitFormCaption("Update Net Credit Risk Sum in RISK LIMIT DAILY CONTROL for current Date")
                    Dim sumNetCreditRiskAmountEUR As Double = 0
                    Dim sumNetCreditRiskAmountEUR45 As Double = 0
                    'Summe des Credit Risk Amounts(EUR Equ)

                    cmd.CommandText = "SELECT Sum([NetCredit Risk Amount(EUR Equ)]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT'"
                    sumNetCreditRiskAmountEUR = cmd.ExecuteScalar
                    '********************************************************************************************************************************

                    cmd.CommandText = "SELECT Sum([NetCreditRiskAmountEUREquER45]) FROM [CREDIT RISK] WHERE [RiskDate]='" & rdsql & "' and [Contract Type]<>'LIMIT'"
                    sumNetCreditRiskAmountEUR45 = cmd.ExecuteScalar

                    'Füllen des Feldes CREDIT RISK in Tabelle MAK CR TOTALS
                    cmd.CommandText = "UPDATE [MAK CR TOTALS] SET [SumCreditRiskCashpledge]='" & Str(sumNetCreditRiskAmountEUR) & "',[SumCreditRiskCashpledge45]='" & Str(sumNetCreditRiskAmountEUR45) & "' WHERE [RiskDate]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()
                    'Übernahme in RISK LIMIT DAILY CONTROL
                    'Prüfen ob Risk Date vorhanden ist
                    cmd.CommandText = "SELECT [RLDC Date] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t2 As String = cmd.ExecuteScalar
                    If IsNothing(t2) = False Then
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET[CreditRiskCashPledge]='" & Str(sumNetCreditRiskAmountEUR45) & "' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    If IsNothing(t2) = True Then
                        cmd.CommandText = "INSERT INTO [RISK LIMIT DAILY CONTROL]([RLDC Date]) Values('" & rdsql & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [CreditRiskCashPledge]='" & Str(sumNetCreditRiskAmountEUR45) & "',[IdBank]='3' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    'Set Unexpected loss
                    cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [UnexpectedLossAmount]=Round([CreditRiskCashPledge]/1000*[UnexpectedLossFactor],2),[ConcentrationRiskAmount]=Round([CreditRiskCashPledge]/1000*[ConcentrationRiskFactor],2) WHERE [RLDC Date]='" & rdsql & "'"
                    cmd.ExecuteNonQuery()

                    SplashScreenManager.Default.SetWaitFormCaption("Calculate RISK BEARING CAPACITY in RISK LIMIT DAILY CONTROL")
                    cmd.CommandText = "SELECT [RiskBearingCapacityCashPledge] FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                    Dim t3 As Double = cmd.ExecuteScalar
                    If t3 <> 0 Then
                        Dim s1 As Double = 0
                        cmd.CommandText = "select sum(round([CreditRiskCashPledge]/1000,0)+[UnexpectedLossAmount]+[ConcentrationRiskAmount]+[Market price risk of securities]+round([Interest risk]/1000,0)+[Currency risk]+[Operational risk]+[Liquidity risk]+EssentialInquantifiableRisksBufferZone) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                        s1 = cmd.ExecuteScalar
                        Dim s2 As Double = 0
                        cmd.CommandText = "select sum([Dotation capital]-[Minimum capital requirement]+round([PL Result]/1000,0)+[HGB340F]) FROM [RISK LIMIT DAILY CONTROL] WHERE [RLDC Date]='" & rdsql & "'"
                        s2 = cmd.ExecuteScalar
                        Dim RBC As Double = (s1 / s2) * 100
                        cmd.CommandText = "UPDATE [RISK LIMIT DAILY CONTROL] SET [RiskBearingCapacityCashPledge]='" & Str(RBC) & "' WHERE [RLDC Date]='" & rdsql & "'"
                        cmd.ExecuteScalar()
                    End If

                    cmd.Connection.Close()

                    SplashScreenManager.CloseForm(False)

                    Me.MAK_REPORTTableAdapter.FillByMakDate(Me.RiskControllingDataSet.MAK_REPORT, rd)
                    Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.RiskControllingDataSet.CREDIT_RISK, rd)
                    Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, rd)

                    Me.CreditRisk_GridView.ExpandAllGroups()
                    Me.MakGridView.ExpandAllGroups()

                End If
            Else
                Exit Sub
            End If
        Catch ex As System.Exception
            SplashScreenManager.CloseForm(False)
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub RecalculateCreditRiskSpecificPeriodBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles RecalculateCreditRiskSpecificPeriodBarButtonItem.ItemClick
        Dim dxOK As New DevExpress.XtraEditors.SimpleButton

        With dxOK
            .Text = "Start"
            .Height = 23
            .Width = 75
            .Location = New System.Drawing.Point(29, 134)
        End With

        DATES_FORM.Controls.Add(dxOK)
        DATES_FORM.OK_btn.Visible = False

        AddHandler dxOK.Click, AddressOf dxOK_click

        DATES_FORM.Show()
        DATES_FORM.Text = "Credit Risk recalculation"
        DATES_FORM.Text_lbl.Text = "Please input the Period for the Credit Risk recalculation"
        With DATES_FORM.DateEdit1
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With

        With DATES_FORM.DateEdit2
            .Properties.EditMask = "dd.MM.yyyy"
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.EditFormat.FormatString = "dd.MM.yyyy"
            .Properties.Appearance.Options.UseTextOptions = True
            .Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Text = Today.ToString("dd.MM.yyyy")
        End With
    End Sub

    Private Sub dxOK_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDate(DATES_FORM.DateEdit1.Text) = True And IsDate(DATES_FORM.DateEdit2.Text) = True Then
            FDate = DATES_FORM.DateEdit1.Text
            LDate = DATES_FORM.DateEdit2.Text
            If FDate <= FDate Then
                MessageBox.Show("No funtion yet", "NO FUNTION YET", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                MessageBox.Show("From Date should be less or equal to Till Date" & vbNewLine & "Please check your input!", "WRONG DATES INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub CreditRiskMakDateEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CreditRiskMakDateEdit.SelectedIndexChanged
        Me.GridControl1.DataSource = Me.CREDIT_RISKBindingSource
        Me.GridControl2.DataSource = Me.MAK_REPORTBindingSource

        If IsDate(Me.CreditRiskMakDateEdit.Text) = True Then
            Dim d As Date = Me.CreditRiskMakDateEdit.Text
            Dim dsql As String = d.ToString("yyyyMMdd")
           
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load data for " & d)
                'Load Credit Risk + MAK Data
                Me.MAK_REPORTTableAdapter.FillByMakDate(Me.RiskControllingDataSet.MAK_REPORT, d)
                Me.CREDIT_RISKTableAdapter.FillByCreditRiskDate(Me.RiskControllingDataSet.CREDIT_RISK, d)
                Me.MAK_CR_TOTALSTableAdapter.FillByMakCrTotalsDate(Me.RiskControllingDataSet.MAK_CR_TOTALS, d)
                SplashScreenManager.CloseForm(False)
         
        End If

        Me.CreditRisk_GridView.ExpandAllGroups()
        Me.MakGridView.ExpandAllGroups()
        Me.LayoutControlItem7.Visibility = LayoutVisibility.Always
        Me.LayoutControlItem9.Visibility = LayoutVisibility.Always
    End Sub

    Private Sub CreditRisk_GridView_DoubleClick(sender As Object, e As EventArgs) Handles CreditRisk_GridView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "Client No" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ClientNr) = False Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr
                        Me.CustomersVerticalGrid.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
            If view.FocusedColumn.FieldName = "Contract Collateral ID" Then
                Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract Collateral ID").ToString
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ContractNr) = False And IsNumeric(ContractNr) = True Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Contract Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        GLOBAL_CONTRACT_NR = ContractNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomerContractVG.Text = "Details for Contract Nr. " & ContractNr
                        Me.CustomerContractVG.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub MakGridView_DoubleClick(sender As Object, e As EventArgs) Handles MakGridView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            If view.FocusedColumn.FieldName = "Client No" Then
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ClientNr) = False Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr
                        Me.CustomersVerticalGrid.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
            If view.FocusedColumn.FieldName = "Contract Collateral ID" Then
                Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract Collateral ID").ToString
                Dim ClientNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Client No").ToString
                If IsNothing(ContractNr) = False And IsNumeric(ContractNr) = True Then
                    Try
                        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                        SplashScreenManager.Default.SetWaitFormCaption("Load Contract Details...")
                        GLOBAL_CLIENT_NR = ClientNr
                        GLOBAL_CONTRACT_NR = ContractNr
                        SplashScreenManager.CloseForm(False)
                        Me.CustomerContractVG.Text = "Details for Contract Nr. " & ContractNr
                        Me.CustomerContractVG.ShowDialog()
                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return
                    End Try
                End If
            End If
        End If
    End Sub
End Class