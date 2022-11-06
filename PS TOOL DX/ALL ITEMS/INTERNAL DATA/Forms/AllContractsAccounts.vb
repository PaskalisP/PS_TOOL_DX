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
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraGrid.Columns
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
'Imports DevExpress.XtraEditors.Controls
Public Class AllContractsAccounts

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Private BS_ContractsAll As BindingSource
    Private BS_Type_Of_Instrument As BindingSource
    Private BS_AmortizationType As BindingSource
    Private BS_FiduciaryInstrument As BindingSource
    Private BS_InterestRateType As BindingSource
    Private BS_ReferenceRate As BindingSource
    Private BS_InterestRateResetFrequency As BindingSource
    Private BS_PaymentFrequency As BindingSource
    Private BS_ProjectFinance As BindingSource
    Private BS_Purpose As BindingSource
    Private BS_Recourse As BindingSource
    Private BS_RepaymentRights As BindingSource
    Private BS_DefaultStatus As BindingSource
    Private BS_TypeOfSecurization As BindingSource
    Private BS_AccountingClassificationInstruments As BindingSource
    Private BS_PerformingStatusInstrument As BindingSource
    Private BS_StatusForbearance As BindingSource
    Private BS_CounterpartyRole As BindingSource
    Private BS_SourcesEncumbrance As BindingSource

    Dim ContractNrSearch As String = Nothing
    Dim CustomersVerticalGrid As New CustomersVG()
    Dim CustomerContractVG As New AllContractsAccountsVG()


    Public Class ControlDisabledValidationRule
        Inherits ConditionValidationRule
        Public Overrides Function CanValidate(control As Control) As Boolean
            Return MyBase.CanValidate(control) AndAlso control.Enabled
        End Function
    End Class

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

    Private Sub AllContractsAccounts_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If Me.LayoutControl1.Visible = True Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load all Data!")
                Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS)
                SplashScreenManager.CloseForm(False)
            End If

        End If
        If e.KeyCode = Keys.Escape Then
            If Me.LayoutControl1.Visible = False Then
                Me.Cancel_btn.PerformClick()
            End If
        End If
    End Sub

    Private Sub AllContractsAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LayoutControl1.Dock = DockStyle.Fill
        'Me.LayoutControl1.Visible = False
        Me.LayoutControlItem3.Visibility = LayoutVisibility.Always

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS)
        Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST)

        AddHandler AllCustomerContracts_GridControl.EmbeddedNavigator.ButtonClick, AddressOf AllCustomerContracts_GridControl_EmbeddedNavigator_ButtonClick

        ALL_CONTRACTS_initData()
        ALL_CONTRACTS_InitLookUp()
        INSTRUMENT_TYPE_initData()
        INSTRUMENT_TYPE_InitLookUp()
        AMORTIZATION_TYPE_initData()
        AMORTIZATION_TYPE_InitLookUp()
        FIDUCIARY_INSTRUMENT_initData()
        FIDUCIARY_INSTRUMENT_InitLookUp()
        INTEREST_RATE_TYPE_initData()
        INTEREST_RATE_TYPE_InitLookUp()
        REFERENCE_RATE_initData()
        REFERENCE_RATE_InitLookUp()
        INTEREST_RATE_RESET_FREQ_initData()
        INTEREST_RATE_RESET_FREQ_InitLookUp()
        PAYMENT_FREQ_initData()
        PAYMENT_FREQ_InitLookUp()
        PROJECT_FINANCE_LOAN_initData()
        PROJECT_FINANCE_LOAN_InitLookUp()
        PURPOSE_initData()
        PURPOSE_InitLookUp()
        RECOURSE_initData()
        RECOURSE_InitLookUp()
        REPAYMENT_RIGHTS_initData()
        REPAYMENT_RIGHTS_InitLookUp()
        DEFAULT_STATUS_initData()
        DEFAULT_STATUS_InitLookUp()
        TYPE_OF_SECURIZATION_initData()
        TYPE_OF_SECURIZATION_InitLookUp()
        ACCOUNTING_CLASSIFICATION_initData()
        ACCOUNTING_CLASSIFICATION_InitLookUp()
        PERFORMING_STATUS_initData()
        PERFORMING_STATUS_InitLookUp()
        STATUS_FORBEARANCE_initData()
        STATUS_FORBEARANCE_InitLookUp()
        COUNTERPARTY_ROLE_initData()
        COUNTERPARTY_ROLE_InitLookUp()
        SOURCES_ENCUMBRANCE_initData()
        SOURCES_ENCUMBRANCE_InitLookUp()
    End Sub

    Private Sub AllCustomerContracts_GridControl_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Try
            Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTBindingSource.EndEdit()
            Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTTableAdapter.Update(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST)
            XtraMessageBox.Show("Changes in Contracts Value Adjustments are saved!", "CHANGES SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR ON SAVING VALUE ADJUSTMENTS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ALL_CUSTOMER_CONTRACTS_LOAD()
        Me.GridControl2.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [ALL_CONTRACTS_ACCOUNTS] where [ClientNr]<>'0' order by [ID] desc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.GridControl2.DataSource = Nothing
                    Me.GridControl2.DataSource = objDataTable
                    Me.GridControl2.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub Customer_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Customer_Print_Export_btn.Click
        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
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
            pinfoBrick = e.Graph.DrawPageInfo(PageInfo.DateTime, "Printed: {0:F}", e.Graph.ForeColor, r, BorderSide.None)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(sender As Object, e As CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        Dim reportfooter As String = "ALL CUSTOMERS CONTRACTS/ACCOUNTS" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

#Region "GRIDVIEWS DEFAULT STYLES"
    Private Sub ContractNr_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ContractNr_Gridview.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ContractNr_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles ContractNr_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AllCustomerContracts_GridView_DoubleClick(sender As Object, e As EventArgs) Handles AllCustomerContracts_GridView.DoubleClick
        'Dim ea As DevExpress.Utils.DXMouseEventArgs = TryCast(e, DevExpress.Utils.DXMouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        'Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)


        If view.IsFilterRow(view.FocusedRowHandle) = True Then
            Return
            'ElseIf info.InRow OrElse info.InRowCell Then
            '    Me.LayoutControl1.Visible = False
            '    Me.ContractSearch_GridLookUpEdit.Text = Me.ContractNr_TextEdit.Text
            '    ANACREDIT_CONTRACT_FIELDS()
        Else
            Me.LayoutControl1.Visible = False
            Me.ContractSearch_GridLookUpEdit.Text = Me.ContractNr_TextEdit.Text
            ANACREDIT_CONTRACT_FIELDS()
        End If



    End Sub
    Private Sub AllCustomerContracts_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AllCustomerContracts_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AllCustomerContracts_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AllCustomerContracts_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AccClassificInstrum_Gridview_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AccClassificInstrum_Gridview.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AccClassificInstrum_Gridview_ShownEditor(sender As Object, e As EventArgs) Handles AccClassificInstrum_Gridview.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub AmortizationType_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AmortizationType_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub AmortizationType_GridView_ShownEditor(sender As Object, e As EventArgs) Handles AmortizationType_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub DefaultStatus_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles DefaultStatus_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub DefaultStatus_GridView_ShownEditor(sender As Object, e As EventArgs) Handles DefaultStatus_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub FiduciaryInstrument_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles FiduciaryInstrument_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub FiduciaryInstrument_GridView_ShownEditor(sender As Object, e As EventArgs) Handles FiduciaryInstrument_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub InterestRateResetFrequency_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles InterestRateResetFrequency_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub InterestRateResetFrequency_GridView_ShownEditor(sender As Object, e As EventArgs) Handles InterestRateResetFrequency_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub InterestRateType_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles InterestRateType_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub InterestRateType_GridView_ShownEditor(sender As Object, e As EventArgs) Handles InterestRateType_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PaymentFrequency_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PaymentFrequency_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PaymentFrequency_GridView_ShownEditor(sender As Object, e As EventArgs) Handles PaymentFrequency_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub PerformingStatus_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles PerformingStatus_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub PerformingStatus_GridView_ShownEditor(sender As Object, e As EventArgs) Handles PerformingStatus_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ProjectFinanceLoan_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ProjectFinanceLoan_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ProjectFinanceLoan_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ProjectFinanceLoan_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Purpose_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Purpose_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Purpose_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Purpose_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub Recourse_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Recourse_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Recourse_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Recourse_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub ReferenceRate_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ReferenceRate_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub ReferenceRate_GridView_ShownEditor(sender As Object, e As EventArgs) Handles ReferenceRate_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub RepaymentRights_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles RepaymentRights_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub RepaymentRights_GridView_ShownEditor(sender As Object, e As EventArgs) Handles RepaymentRights_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub StatusForbearance_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles StatusForbearance_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub StatusForbearance_GridView_ShownEditor(sender As Object, e As EventArgs) Handles StatusForbearance_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TypeOfInstrument_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TypeOfInstrument_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TypeOfInstrument_GridView_ShownEditor(sender As Object, e As EventArgs) Handles TypeOfInstrument_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub TypeOfSecurization_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles TypeOfSecurization_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub TypeOfSecurization_GridView_ShownEditor(sender As Object, e As EventArgs) Handles TypeOfSecurization_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub SourceEncumbrance_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SourceEncumbrance_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SourceEncumbrance_GridView_ShownEditor(sender As Object, e As EventArgs) Handles SourceEncumbrance_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

#End Region

#Region "SELECTION_DATA_LOAD"

    Private Sub ALL_CONTRACTS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [Contract_Account],[ClientNr],[ClientName],[BusinessType],[Valid],[IsAnaCredit] FROM [ALL_CONTRACTS_ACCOUNTS] where [ClientNr]<>'0' order by [ID] desc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbAllContracts As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbAllContracts.Fill(ds, "ALL_CONTRACTS_ACCOUNTS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_ContractsAll = New BindingSource(ds, "ALL_CONTRACTS_ACCOUNTS")
    End Sub

    Private Sub ALL_CONTRACTS_InitLookUp()
        Me.ContractSearch_GridLookUpEdit.Properties.DataSource = BS_ContractsAll
        Me.ContractSearch_GridLookUpEdit.Properties.DisplayMember = "Contract_Account"
        Me.ContractSearch_GridLookUpEdit.Properties.ValueMember = "Contract_Account"
    End Sub

    Private Sub INSTRUMENT_TYPE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('TYPE_OF_INSTRUMENT')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbInstrumentType As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbInstrumentType.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Type_Of_Instrument = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub INSTRUMENT_TYPE_InitLookUp()
        Me.TypeOfInstrument_SearchLookUpEdit.Properties.DataSource = BS_Type_Of_Instrument
        Me.TypeOfInstrument_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.TypeOfInstrument_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub AMORTIZATION_TYPE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('AMORTISATION_TYPE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbAmortizationType As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbAmortizationType.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_AmortizationType = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub AMORTIZATION_TYPE_InitLookUp()
        Me.AmortizationType_SearchLookUpEdit.Properties.DataSource = BS_AmortizationType
        Me.AmortizationType_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.AmortizationType_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub FIDUCIARY_INSTRUMENT_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('FIDUCIARY_INSTRUMENT')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbFiduciaryInstrument As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbFiduciaryInstrument.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_FiduciaryInstrument = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub FIDUCIARY_INSTRUMENT_InitLookUp()
        Me.FiduciaryInstrument_SearchLookUpEdit.Properties.DataSource = BS_FiduciaryInstrument
        Me.FiduciaryInstrument_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.FiduciaryInstrument_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub INTEREST_RATE_TYPE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('INTEREST_RATE_TYPE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbInterestRateType As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbInterestRateType.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_InterestRateType = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub INTEREST_RATE_TYPE_InitLookUp()
        Me.InterestRateType_SearchLookUpEdit.Properties.DataSource = BS_InterestRateType
        Me.InterestRateType_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.InterestRateType_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub REFERENCE_RATE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('REFERENCE_RATE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbReferenceRate As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbReferenceRate.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_ReferenceRate = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub REFERENCE_RATE_InitLookUp()
        Me.ReferenceRate_SearchLookUpEdit.Properties.DataSource = BS_ReferenceRate
        Me.ReferenceRate_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.ReferenceRate_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub INTEREST_RATE_RESET_FREQ_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('INTEREST_RATE_RESET_FREQUENCY')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbInterestRateResetFreq As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbInterestRateResetFreq.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_InterestRateResetFrequency = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub INTEREST_RATE_RESET_FREQ_InitLookUp()
        Me.InterestRateResFreq_SearchLookUpEdit.Properties.DataSource = BS_InterestRateResetFrequency
        Me.InterestRateResFreq_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.InterestRateResFreq_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub PAYMENT_FREQ_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('PAYMENT_FREQUENCY')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbPaymentFreq As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbPaymentFreq.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_PaymentFrequency = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub PAYMENT_FREQ_InitLookUp()
        Me.PaymentFreq_SearchLookUpEdit.Properties.DataSource = BS_PaymentFrequency
        Me.PaymentFreq_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.PaymentFreq_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub PROJECT_FINANCE_LOAN_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('PROJECT_FINANCE_LOAN')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbProjectFinanceLoan As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbProjectFinanceLoan.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_ProjectFinance = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub PROJECT_FINANCE_LOAN_InitLookUp()
        Me.ProjectFinance_SearchLookUpEdit.Properties.DataSource = BS_ProjectFinance
        Me.ProjectFinance_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.ProjectFinance_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub PURPOSE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('PURPOSE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbPurpose As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbPurpose.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Purpose = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub PURPOSE_InitLookUp()
        Me.Purpose_SearchLookUpEdit.Properties.DataSource = BS_Purpose
        Me.Purpose_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.Purpose_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub RECOURSE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('RECOURSE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbRecourse As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbRecourse.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Recourse = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub RECOURSE_InitLookUp()
        Me.Recourse_SearchLookUpEdit.Properties.DataSource = BS_Recourse
        Me.Recourse_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.Recourse_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub REPAYMENT_RIGHTS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('REPAYMENT_RIGHTS')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbRepaymentRights As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbRepaymentRights.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_RepaymentRights = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub REPAYMENT_RIGHTS_InitLookUp()
        Me.RepaymentRights_SearchLookUpEdit.Properties.DataSource = BS_RepaymentRights
        Me.RepaymentRights_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.RepaymentRights_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub DEFAULT_STATUS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('DEFAULT_STATUS')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbDefaultStatus As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbDefaultStatus.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_DefaultStatus = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub DEFAULT_STATUS_InitLookUp()
        Me.DefaultStatus_SearchLookUpEdit.Properties.DataSource = BS_DefaultStatus
        Me.DefaultStatus_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.DefaultStatus_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub TYPE_OF_SECURIZATION_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('TYPE_OF_SECURISATION')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbTypeOfSecurization As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbTypeOfSecurization.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_TypeOfSecurization = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub TYPE_OF_SECURIZATION_InitLookUp()
        Me.TypeOfSecurization_SearchLookUpEdit.Properties.DataSource = BS_TypeOfSecurization
        Me.TypeOfSecurization_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.TypeOfSecurization_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub ACCOUNTING_CLASSIFICATION_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('CLASSIFICATION_OF_INSTRUMENTS'))  and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbClassificationInstruments As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbClassificationInstruments.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_AccountingClassificationInstruments = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub ACCOUNTING_CLASSIFICATION_InitLookUp()
        Me.AccountingClassifInstruments_SearchLookUpEdit.Properties.DataSource = BS_AccountingClassificationInstruments
        Me.AccountingClassifInstruments_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.AccountingClassifInstruments_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub PERFORMING_STATUS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('PERFORMING_STATUS_INSTRUMENT')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbPerformingStatus As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbPerformingStatus.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_PerformingStatusInstrument = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub PERFORMING_STATUS_InitLookUp()
        Me.PerformingStatusInstrument_SearchLookUpEdit.Properties.DataSource = BS_PerformingStatusInstrument
        Me.PerformingStatusInstrument_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.PerformingStatusInstrument_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub STATUS_FORBEARANCE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('STATUS_FORBEARANCE_RENEGOTIATION')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbStatusForbearance As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbStatusForbearance.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_StatusForbearance = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub STATUS_FORBEARANCE_InitLookUp()
        Me.StatusForbearance_SearchLookUpEdit.Properties.DataSource = BS_StatusForbearance
        Me.StatusForbearance_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.StatusForbearance_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub COUNTERPARTY_ROLE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('COUNTERPARTY_ROLE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbCounterpartyRole As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbCounterpartyRole.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_CounterpartyRole = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub COUNTERPARTY_ROLE_InitLookUp()
        Me.CounterpartyRole_SearchLookUpEdit.Properties.DataSource = BS_CounterpartyRole
        Me.CounterpartyRole_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.CounterpartyRole_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub SOURCES_ENCUMBRANCE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('SOURCES_OF_ENCUMBRANCE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbSourcesEncumbrance As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()

        Try

            dbSourcesEncumbrance.Fill(ds, "SQL_PARAMETER_DETAILS_SECOND")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_SourcesEncumbrance = New BindingSource(ds, "SQL_PARAMETER_DETAILS_SECOND")
    End Sub

    Private Sub SOURCES_ENCUMBRANCE_InitLookUp()
        Me.SourcesOfEncumbrance_SearchLookUpEdit.Properties.DataSource = BS_SourcesEncumbrance
        Me.SourcesOfEncumbrance_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.SourcesOfEncumbrance_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

#End Region



    Private Sub ANACREDIT_CONTRACT_FIELDS()
        If Me.LayoutControl1.Visible = False Then
            If Me.AnaCreditCustomer_ImageComboBoxEdit.EditValue.ToString = "Y" AndAlso Me.Valid_ImageComboBoxEdit.EditValue.ToString = "Y" Then
                GroupControl2.Enabled = True
                GroupControl3.Enabled = True
                GroupControl4.Enabled = True
                GroupControl5.Enabled = True
                GroupControl6.Enabled = True
                GroupControl7.Enabled = True
                GroupControl9.Enabled = True
                GroupControl12.Enabled = True
                GroupControl13.Enabled = True
                GroupControl14.Enabled = True
                GroupControl15.Enabled = True
                GroupControl16.Enabled = True
                'GroupControl17.Enabled = True
                GroupControl18.Enabled = True
                GroupControl19.Enabled = True
                GroupControl20.Enabled = True
                If Me.InterestRateType_SearchLookUpEdit.EditValue = "V" Then
                    Me.ReferenceRate_SearchLookUpEdit.ReadOnly = False
                    Me.Spread_TextEdit.ReadOnly = False
                    Me.InterestRateCap_TextEdit.ReadOnly = False
                    Me.InterestRateFloor_TextEdit5.ReadOnly = False
                Else
                    Me.ReferenceRate_SearchLookUpEdit.ReadOnly = True
                    Me.Spread_TextEdit.ReadOnly = True
                    Me.InterestRateCap_TextEdit.ReadOnly = True
                    Me.InterestRateFloor_TextEdit5.ReadOnly = True
                End If
            Else

                GroupControl2.Enabled = False
                GroupControl3.Enabled = False
                GroupControl4.Enabled = False
                GroupControl5.Enabled = False
                GroupControl6.Enabled = False
                GroupControl7.Enabled = False
                GroupControl9.Enabled = False
                GroupControl12.Enabled = False
                GroupControl13.Enabled = False
                GroupControl14.Enabled = False
                GroupControl15.Enabled = False
                GroupControl16.Enabled = False
                'GroupControl17.Enabled = False
                GroupControl18.Enabled = False
                GroupControl19.Enabled = False
                GroupControl20.Enabled = False
                Me.SyndicContractIdent_TextEdit.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub ANACREDIT_CONTRACTS_ADD_VALIDATION()
        If Me.BusinessType_TextEdit.Text = "SYNDICATED LOANS" Then
            'Me.SyndicContractIdent_TextEdit.ReadOnly = False
            'Dim SyndicatedContractIdentifierValidationRule As New ConditionValidationRule()
            'SyndicatedContractIdentifierValidationRule.ConditionOperator = ConditionOperator.IsNotBlank
            'SyndicatedContractIdentifierValidationRule.ErrorText = "Field is mandatory for AnaCredit Reporting!"
            'SyndicatedContractIdentifierValidationRule.ErrorType = ErrorType.Critical
            'DxValidationProvider1.SetValidationRule(SyndicContractIdent_TextEdit, SyndicatedContractIdentifierValidationRule)
        Else
            'DxValidationProvider1.SetValidationRule(SyndicContractIdent_TextEdit, Nothing)
            'Me.SyndicContractIdent_TextEdit.ReadOnly = True
        End If
        'Set no empty Validation rule
        Dim notEmptyValidationRule As New ConditionValidationRule()
        notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank
        notEmptyValidationRule.ErrorText = "Field is mandatory for AnaCredit Reporting!"
        notEmptyValidationRule.ErrorType = ErrorType.Critical
        'Set higher then Zero Validation Rule
        Dim higherZeroValidationRule As New ConditionValidationRule()
        higherZeroValidationRule.ConditionOperator = ConditionOperator.Greater
        higherZeroValidationRule.Value1 = 0
        higherZeroValidationRule.ErrorText = "Field is mandatory for AnaCredit Reporting!" & vbNewLine & "Must be higher than zero!"
        higherZeroValidationRule.ErrorType = ErrorType.Critical
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        DxValidationProvider1.SetValidationRule(TypeOfInstrument_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(AmortizationType_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(FiduciaryInstrument_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(InterestRateType_SearchLookUpEdit, notEmptyValidationRule)
        If Me.InterestRateType_SearchLookUpEdit.EditValue = "V" Then
            DxValidationProvider1.SetValidationRule(ReferenceRate_SearchLookUpEdit, notEmptyValidationRule)
            DxValidationProvider1.SetValidationRule(InterestRateCap_TextEdit, notEmptyValidationRule)
            DxValidationProvider1.SetValidationRule(InterestRateFloor_TextEdit5, notEmptyValidationRule)
        Else
            DxValidationProvider1.SetValidationRule(ReferenceRate_SearchLookUpEdit, Nothing)
            DxValidationProvider1.SetValidationRule(InterestRateCap_TextEdit, Nothing)
            DxValidationProvider1.SetValidationRule(InterestRateFloor_TextEdit5, Nothing)
        End If
        DxValidationProvider1.SetValidationRule(InterestRateResFreq_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(PaymentFreq_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(ProjectFinance_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Purpose_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(Recourse_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(RepaymentRights_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(DefaultStatus_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(DefaultStatusDate_DateEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(TypeOfSecurization_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(AccountingClassifInstruments_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(PerformingStatusInstrument_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(DatePerformingStatus_DateEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(StatusForbearance_SearchLookUpEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(DateForbearanceStatus_DateEdit, notEmptyValidationRule)
        DxValidationProvider1.SetValidationRule(CounterpartyRole_SearchLookUpEdit, notEmptyValidationRule)
    End Sub

    Private Sub ANACREDIT_CONTRACTS_REMOVE_VALIDATION()
        DxValidationProvider1.SetValidationRule(SyndicContractIdent_TextEdit, Nothing)
        DxValidationProvider1.SetValidationRule(TypeOfInstrument_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(AmortizationType_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(FiduciaryInstrument_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(InterestRateType_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(ReferenceRate_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(InterestRateCap_TextEdit, Nothing)
        DxValidationProvider1.SetValidationRule(InterestRateFloor_TextEdit5, Nothing)
        DxValidationProvider1.SetValidationRule(InterestRateResFreq_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(PaymentFreq_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(ProjectFinance_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Purpose_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(Recourse_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(RepaymentRights_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(DefaultStatus_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(DefaultStatusDate_DateEdit, Nothing)
        DxValidationProvider1.SetValidationRule(TypeOfSecurization_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(AccountingClassifInstruments_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(PerformingStatusInstrument_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(DatePerformingStatus_DateEdit, Nothing)
        DxValidationProvider1.SetValidationRule(StatusForbearance_SearchLookUpEdit, Nothing)
        DxValidationProvider1.SetValidationRule(DateForbearanceStatus_DateEdit, Nothing)
        DxValidationProvider1.SetValidationRule(CounterpartyRole_SearchLookUpEdit, Nothing)
    End Sub

    Private Sub ALL_CONTRACTS_ACCOUNTSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ALL_CONTRACTS_ACCOUNTSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AllContractsAccountsDataSet)

    End Sub

    Private Sub KEV_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles KEV_RepositoryItemImageComboBox.EditValueChanged
        If AllCustomerContracts_GridView.IsFilterRow(AllCustomerContracts_GridView.FocusedRowHandle) = False Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating...Please wait... ")
                Threading.Thread.Sleep(200)
                AllCustomerContracts_GridView.PostEditor()
                Me.Validate()
                Me.ALL_CONTRACTS_ACCOUNTSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AllContractsAccountsDataSet)
                '***********************************************************************
                Dim view As GridView = AllCustomerContracts_GridView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub ContractSearch_GridLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ContractSearch_GridLookUpEdit.ButtonClick
        If e.Button.Caption = "Report" Then
            If Me.ContractSearch_GridLookUpEdit.Text <> "" AndAlso IsNumeric(Me.ContractSearch_GridLookUpEdit.Text) = True Then
                Me.ALL_CONTRACTS_ACCOUNTSBindingSource.CancelEdit()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                ContractNrSearch = Me.ContractSearch_GridLookUpEdit.Text
                SplashScreenManager.Default.SetWaitFormCaption("Create Report for Contract Nr.: " & ContractNrSearch)
                Me.ContractSearch_GridLookUpEdit.Text = ContractNrSearch
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If

                Dim CUSTOMER_CONTRACTS_Da As New SqlDataAdapter("Select * from ALL_CONTRACTS_ACCOUNTS where [Contract_Account]='" & ContractNrSearch & "' ", conn)
                Dim CUSTOMER_CONTRACTS_Dataset As New DataSet("ALL_CONTRACTS_ACCOUNTS")
                CUSTOMER_CONTRACTS_Da.Fill(CUSTOMER_CONTRACTS_Dataset, "ALL_CONTRACTS_ACCOUNTS")

                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\ContractInfo.rpt")
                CrRep.SetDataSource(CUSTOMER_CONTRACTS_Dataset)

                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = ContractNrSearch
                myParams.ParameterFieldName = "ClientNr"
                myParams.CurrentValues.Add(myValue)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Data Report for Contract Nr. " & ContractNrSearch
                c.CrystalReportViewer1.ParameterFieldInfo = New ParameterFields
                c.CrystalReportViewer1.ParameterFieldInfo.Add(myParams)
                c.CrystalReportViewer1.ReportSource = CrRep
                c.CrystalReportViewer1.ShowParameterPanelButton = False
                c.CrystalReportViewer1.ShowRefreshButton = False
                c.CrystalReportViewer1.ShowGroupTreeButton = False
                c.CrystalReportViewer1.Zoom(85)
                SplashScreenManager.CloseForm(False)
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End If
        End If
    End Sub





    Private Sub ContractSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ContractSearch_GridLookUpEdit.EditValueChanged
        If Me.ContractSearch_GridLookUpEdit.Text <> "" AndAlso IsNumeric(Me.ContractSearch_GridLookUpEdit.Text) = True Then
            Me.ALL_CONTRACTS_ACCOUNTSBindingSource.CancelEdit()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            ContractNrSearch = Me.ContractSearch_GridLookUpEdit.Text
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for Contract Nr.: " & ContractNrSearch)
            Me.ContractSearch_GridLookUpEdit.Text = ContractNrSearch
            Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.FillByContractNr(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS, ContractNrSearch)
            Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST)
            INSTRUMENT_TYPE_initData()
            INSTRUMENT_TYPE_InitLookUp()
            AMORTIZATION_TYPE_initData()
            AMORTIZATION_TYPE_InitLookUp()
            FIDUCIARY_INSTRUMENT_initData()
            FIDUCIARY_INSTRUMENT_InitLookUp()
            INTEREST_RATE_TYPE_initData()
            INTEREST_RATE_TYPE_InitLookUp()
            REFERENCE_RATE_initData()
            REFERENCE_RATE_InitLookUp()
            INTEREST_RATE_RESET_FREQ_initData()
            INTEREST_RATE_RESET_FREQ_InitLookUp()
            PAYMENT_FREQ_initData()
            PAYMENT_FREQ_InitLookUp()
            PROJECT_FINANCE_LOAN_initData()
            PROJECT_FINANCE_LOAN_InitLookUp()
            PURPOSE_initData()
            PURPOSE_InitLookUp()
            RECOURSE_initData()
            RECOURSE_InitLookUp()
            REPAYMENT_RIGHTS_initData()
            REPAYMENT_RIGHTS_InitLookUp()
            DEFAULT_STATUS_initData()
            DEFAULT_STATUS_InitLookUp()
            TYPE_OF_SECURIZATION_initData()
            TYPE_OF_SECURIZATION_InitLookUp()
            ACCOUNTING_CLASSIFICATION_initData()
            ACCOUNTING_CLASSIFICATION_InitLookUp()
            PERFORMING_STATUS_initData()
            PERFORMING_STATUS_InitLookUp()
            STATUS_FORBEARANCE_initData()
            STATUS_FORBEARANCE_InitLookUp()
            COUNTERPARTY_ROLE_initData()
            COUNTERPARTY_ROLE_InitLookUp()
            SOURCES_ENCUMBRANCE_initData()
            SOURCES_ENCUMBRANCE_InitLookUp()
            ANACREDIT_CONTRACT_FIELDS()
            ANACREDIT_CONTRACTS_REMOVE_VALIDATION()

            SplashScreenManager.CloseForm(False)
        End If
    End Sub

#Region "SEARCH LOOKUPEDITS VALUE CHANGED"

    Private Sub TypeOfInstrument_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TypeOfInstrument_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If TypeOfInstrument_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.TypeOfInstrumentDescr_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.TypeOfInstrumentDescr_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub AmortizationType_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AmortizationType_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If AmortizationType_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.AmortizationTypeDescr_lbl.Text = EditRow("SQL_Name_2").ToString

                If AmortizationType_SearchLookUpEdit.EditValue = "4" Then
                    Me.EndDateOfInterestPaymentOnlyPeriodDateEdit.ReadOnly = True
                    Me.EndDateOfInterestPaymentOnlyPeriodDateEdit.EditValue = Me.MaturityDate_DateEdit.EditValue
                Else
                    Me.EndDateOfInterestPaymentOnlyPeriodDateEdit.EditValue = DBNull.Value
                    Me.EndDateOfInterestPaymentOnlyPeriodDateEdit.ReadOnly = False

                End If

            Else
                Me.AmortizationTypeDescr_lbl.Text = ""
                Me.EndDateOfInterestPaymentOnlyPeriodDateEdit.EditValue = DBNull.Value
                Me.EndDateOfInterestPaymentOnlyPeriodDateEdit.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub FiduciaryInstrument_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles FiduciaryInstrument_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If FiduciaryInstrument_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.FiduciaryInstrumentDescr_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.FiduciaryInstrumentDescr_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub InterestRateType_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles InterestRateType_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If InterestRateType_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.InterestRateTypeDesc_lbl.Text = EditRow("SQL_Name_2").ToString

                If InterestRateType_SearchLookUpEdit.EditValue = "V" Then
                    Me.ReferenceRate_SearchLookUpEdit.ReadOnly = False
                    Me.Spread_TextEdit.ReadOnly = False
                Else
                    Me.ReferenceRate_SearchLookUpEdit.EditValue = DBNull.Value
                    Me.ReferenceRate_SearchLookUpEdit.ReadOnly = True
                    Me.Spread_TextEdit.EditValue = "0"
                    Me.Spread_TextEdit.ReadOnly = True
                End If

            Else
                Me.InterestRateTypeDesc_lbl.Text = ""
                Me.ReferenceRate_SearchLookUpEdit.EditValue = DBNull.Value
                Me.Spread_TextEdit.EditValue = 0
            End If

            If IsNumeric(Me.InterestRate_TextEdit.EditValue) = True And IsNumeric(Me.Spread_TextEdit.EditValue) = True And Me.InterestRateType_SearchLookUpEdit.Text = "V" Then
                'Dim InterestRate As Double = Me.InterestRate_TextEdit.EditValue
                'Dim Spread As Double = Me.Spread_TextEdit.EditValue
                Me.InterestRateCap_TextEdit.ReadOnly = False
                Me.InterestRateFloor_TextEdit5.ReadOnly = False
            Else
                Me.Spread_TextEdit.EditValue = "0"
                Me.InterestRateCap_TextEdit.EditValue = "0"
                Me.InterestRateFloor_TextEdit5.EditValue = "0"
                Me.InterestRateCap_TextEdit.ReadOnly = True
                Me.InterestRateFloor_TextEdit5.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub ReferenceRate_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ReferenceRate_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If ReferenceRate_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.ReferenceRateDescr_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.ReferenceRateDescr_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub InterestRateResFreq_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles InterestRateResFreq_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If InterestRateResFreq_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.InterestRateResetFreq_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.InterestRateResetFreq_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub PaymentFreq_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PaymentFreq_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If PaymentFreq_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.PaymentFrequencyDescr_lbl.Text = EditRow("SQL_Name_2").ToString

                'Calculate Average Interest
                Dim PaymentFrequency As String = PaymentFreq_SearchLookUpEdit.Text
                Dim InterestRate As Double = 0
                Dim AverageInterestRate As Double = 0
                If Me.InterestRate_TextEdit.EditValue.ToString <> "" AndAlso Me.InterestRate_TextEdit.EditValue <> 0 Then
                    InterestRate = Me.InterestRate_TextEdit.EditValue / 100
                    Select Case PaymentFrequency
                        Case Is = "M"
                            AverageInterestRate = Math.Pow((1 + InterestRate / 1), 1) - 1
                            Me.AverageInterestRate_SpinEdit.EditValue = AverageInterestRate * 100
                        Case Is = "Q"
                            AverageInterestRate = Math.Pow((1 + InterestRate / 3), 3) - 1
                            Me.AverageInterestRate_SpinEdit.EditValue = AverageInterestRate * 100
                        Case Is = "S"
                            AverageInterestRate = Math.Pow((1 + InterestRate / 6), 6) - 1
                            Me.AverageInterestRate_SpinEdit.EditValue = AverageInterestRate * 100
                        Case Is = "A"
                            AverageInterestRate = Math.Pow((1 + InterestRate / 12), 12) - 1
                            Me.AverageInterestRate_SpinEdit.EditValue = AverageInterestRate * 100
                        Case Else
                            Me.AverageInterestRate_SpinEdit.EditValue = Me.InterestRate_TextEdit.EditValue
                    End Select
                Else
                    Me.AverageInterestRate_SpinEdit.EditValue = 0
                End If
            Else
                Me.PaymentFrequencyDescr_lbl.Text = ""
                Me.AverageInterestRate_SpinEdit.EditValue = 0
            End If



        End If
    End Sub


    Private Sub ProjectFinance_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ProjectFinance_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If ProjectFinance_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.ProjectFinanceDesc_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.ProjectFinanceDesc_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub Purpose_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Purpose_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Purpose_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.Purpose_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.Purpose_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub Recourse_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Recourse_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Recourse_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.RecourseDescrip_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.RecourseDescrip_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub RepaymentRights_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles RepaymentRights_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If RepaymentRights_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.RepaymRightsDescr_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.RepaymRightsDescr_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub DefaultStatus_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DefaultStatus_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If DefaultStatus_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.DefaultStatusDesc_lbl.Text = EditRow("SQL_Name_2").ToString
                If DefaultStatus_SearchLookUpEdit.Text <> "N" Then
                    'Me.DefaultStatusDate_DateEdit.ReadOnly = False
                    If IsDate(Me.DefaultStatusDate_DateEdit.Text) = False Then
                        Me.DefaultStatusDate_DateEdit.Text = Today
                    End If
                ElseIf Me.DefaultStatus_SearchLookUpEdit.Text = "N" Then
                    If IsDate(Me.InputDate_DateEdit.Text) = True Then
                        Me.DefaultStatusDate_DateEdit.Text = Me.InputDate_DateEdit.Text
                        'Me.DefaultStatusDate_DateEdit.ReadOnly = True
                    Else
                        Me.DefaultStatusDate_DateEdit.EditValue = DBNull.Value
                        'Me.DefaultStatusDate_DateEdit.ReadOnly = True
                    End If

                End If

            Else
                Me.DefaultStatusDesc_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub TypeOfSecurization_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TypeOfSecurization_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If TypeOfSecurization_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.TypeOfSecurizationDescr_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.TypeOfSecurizationDescr_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub AccountingClassifInstruments_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AccountingClassifInstruments_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If AccountingClassifInstruments_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.AccountingClassifInstrumentsDescrip_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.AccountingClassifInstrumentsDescrip_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub PerformingStatusInstrument_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PerformingStatusInstrument_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If PerformingStatusInstrument_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.PerformingStatusInstrumentDescr_lbl.Text = EditRow("SQL_Name_2").ToString
                Me.DatePerformingStatus_DateEdit.ReadOnly = False
                If IsDate(Me.DatePerformingStatus_DateEdit.Text) = False Then
                    Me.DatePerformingStatus_DateEdit.Text = Me.InputDate_DateEdit.Text
                End If
            Else
                Me.PerformingStatusInstrumentDescr_lbl.Text = ""
                Me.DatePerformingStatus_DateEdit.EditValue = DBNull.Value
                Me.DatePerformingStatus_DateEdit.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub StatusForbearance_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles StatusForbearance_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If StatusForbearance_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.StatusForbearance_lbl.Text = EditRow("SQL_Name_2").ToString
                Me.DateForbearanceStatus_DateEdit.ReadOnly = False
                If IsDate(Me.DateForbearanceStatus_DateEdit.Text) = False Then
                    Me.DateForbearanceStatus_DateEdit.Text = Me.InputDate_DateEdit.Text
                End If
            Else
                Me.StatusForbearance_lbl.Text = ""
                Me.DateForbearanceStatus_DateEdit.EditValue = DBNull.Value
                Me.DateForbearanceStatus_DateEdit.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub CounterpartyRole_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CounterpartyRole_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If CounterpartyRole_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.CounterpartyRoleDescription_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.CounterpartyRoleDescription_lbl.Text = ""

            End If
        End If
    End Sub

    Private Sub SourcesOfEncumbrance_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SourcesOfEncumbrance_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If SourcesOfEncumbrance_SearchLookUpEdit.Text <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim EditRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.SourcesEncumbranceDescription_lbl.Text = EditRow("SQL_Name_2").ToString

            Else
                Me.SourcesEncumbranceDescription_lbl.Text = ""

            End If
        End If
    End Sub

#End Region

    Private Sub DetailView_btn_Click(sender As Object, e As EventArgs) Handles DetailView_btn.Click
        If Me.AllCustomerContracts_GridView.IsFilterRow(Me.AllCustomerContracts_GridView.FocusedRowHandle) = True Then
            Return
        Else
            Me.LayoutControl1.Visible = False
            Me.ContractSearch_GridLookUpEdit.Text = Me.ContractNr_TextEdit.Text
            ANACREDIT_CONTRACT_FIELDS()
        End If

    End Sub

    Private Sub SaveChanges_btn_Click(sender As Object, e As EventArgs) Handles SaveChanges_btn.Click
        Try
            If Me.AnaCreditCustomer_ImageComboBoxEdit.EditValue.ToString = "Y" AndAlso Me.Valid_ImageComboBoxEdit.EditValue.ToString = "Y" Then
                ANACREDIT_CONTRACTS_ADD_VALIDATION()
                Me.XtraTabControl2.SelectedTabPageIndex = 1
                Me.XtraTabControl2.SelectedTabPageIndex = 0
            Else
                ANACREDIT_CONTRACTS_REMOVE_VALIDATION()
            End If
            If Me.DxValidationProvider1.Validate() = True Then
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Updating Contract")
                Me.AnaCreditRepValid_ImageComboBoxEdit.EditValue = "Y"
                Me.ALL_CONTRACTS_ACCOUNTSBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.AllContractsAccountsDataSet)
                '*****************************************************
                'Update Validity Status in AnaCredit Contracts Table
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "UPDATE A SET A.AnaCredit_Valid=B.AnaCredit_Valid from ANACREDIT_CONTRACTS A INNER JOIN ALL_CONTRACTS_ACCOUNTS B on A.Contract_Account=B.Contract_Account where B.Contract_Account='" & Me.ContractNr_TextEdit.EditValue & "' and B.IsAnaCredit in ('Y')"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                '*****************************************************
                Me.LayoutControl1.Visible = True
                GridControl2.MainView = AllCustomerContracts_GridView

                ''''''
                Dim view As GridView = AllCustomerContracts_GridView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS)
                Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                SplashScreenManager.CloseForm(False)
            Else
                XtraMessageBox.Show("At least one mandatory Field is empty!" & vbNewLine & "Please check in Tab:" & vbNewLine & "BASIC DATA FOR INSTRUMENTS" & vbNewLine & "ADDITIONAL DATA FOR INSTRUMENTS!", "EMPTY MANDATORY FIELDS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub

            End If

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.Message, "ERROR ON SAVING", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub

        End Try

    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Load Contracts List")
        ANACREDIT_CONTRACTS_REMOVE_VALIDATION()
        Me.ALL_CONTRACTS_ACCOUNTSBindingSource.CancelEdit()
        Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTBindingSource.CancelEdit()
        Me.LayoutControl1.Visible = True
        GridControl2.MainView = AllCustomerContracts_GridView

        ''''''
        Dim view As GridView = AllCustomerContracts_GridView
        Dim focusedRow As Integer = view.FocusedRowHandle
        Me.GridControl2.BeginUpdate()
        Me.ALL_CONTRACTS_ACCOUNTSTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS)
        Me.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUSTTableAdapter.Fill(Me.AllContractsAccountsDataSet.ALL_CONTRACTS_ACCOUNTS_VALUE_ADJUST)
        view.RefreshData()
        Me.GridControl2.EndUpdate()
        view.FocusedRowHandle = focusedRow
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub ToolTipController1_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles ToolTipController1.HyperlinkClick
        Dim process As New Process()
        process.StartInfo.FileName = (e.Link)
        process.StartInfo.Verb = "open"
        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        Try
            process.Start()
        Catch
        End Try

    End Sub

    Private Sub Spread_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Spread_TextEdit.EditValueChanged
        'If Me.LayoutControl1.Visible = False Then
        '    If IsNumeric(Me.InterestRate_TextEdit.EditValue) = True And IsNumeric(Me.Spread_TextEdit.EditValue) = True And Me.InterestRateType_SearchLookUpEdit.Text = "V" Then
        '        Dim InterestRate As Double = Me.InterestRate_TextEdit.EditValue
        '        Dim Spread As Double = Me.Spread_TextEdit.EditValue
        '        Me.InterestRateCap_TextEdit.Text = InterestRate
        '        Me.InterestRateFloor_TextEdit5.Text = InterestRate - Spread
        '    Else
        '        Me.Spread_TextEdit.EditValue = "0"
        '        Me.InterestRateCap_TextEdit.EditValue = "0"
        '        Me.InterestRateFloor_TextEdit5.EditValue = "0"
        '    End If

        'End If


    End Sub


    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim ValueAdjustmentType As GridColumn = View.Columns("ValueAdjustmentType")
        Dim ValueAdjustmentCurrency As GridColumn = View.Columns("ValueAdjustmentCurrency")
        Dim ValueAdjustmentAmount As GridColumn = View.Columns("ValueAdjustmentAmount")
        Dim ValueAdjustmentDate As GridColumn = View.Columns("ValueAdjustmentDate")
        Dim ValueAdjustmentDateTill As GridColumn = View.Columns("ValueAdjustmentDateTill")

        Dim TYPE As String = View.GetRowCellValue(e.RowHandle, colValueAdjustmentType).ToString
        Dim CCY As String = View.GetRowCellValue(e.RowHandle, colValueAdjustmentCurrency).ToString
        Dim AMOUNT As String = View.GetRowCellValue(e.RowHandle, colValueAdjustmentAmount).ToString
        Dim DD As String = View.GetRowCellValue(e.RowHandle, colValueAdjustmentDate).ToString
        Dim DD_TILL As String = View.GetRowCellValue(e.RowHandle, colValueAdjustmentDateTill).ToString

        If TYPE = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ValueAdjustmentType, "The Type must not be empty")
            e.ErrorText = "The Type must not be empty"
        End If
        If CCY = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ValueAdjustmentCurrency, "The Currency must not be empty")
            e.ErrorText = "The Currency  must not be empty"
        End If
        If AMOUNT = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ValueAdjustmentAmount, "The Amount must not be empty")
            e.ErrorText = "The Amount must not be empty"
        End If
        If DD = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ValueAdjustmentDate, "The Date From must not be empty")
            e.ErrorText = "The Date From must not be empty"
        End If
        If DD_TILL = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ValueAdjustmentDateTill, "The Date Till must not be empty")
            e.ErrorText = "The Date Till must not be empty"
        End If
    End Sub

    Private Sub AmountPastDue_SpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AmountPastDue_SpinEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            Dim n As Double = Me.AmountPastDue_SpinEdit.EditValue
            If n > 0 Then
                Me.DatePastDue_DateEdit.EditValue = Today
            ElseIf n = 0 Then
                Me.DatePastDue_DateEdit.EditValue = DBNull.Value

            End If
        End If
    End Sub





    Private Sub ClientNr_TextEdit_DoubleClick(sender As Object, e As EventArgs) Handles ClientNr_TextEdit.DoubleClick
        If Me.LayoutControl1.Visible = False Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                GLOBAL_CLIENT_NR = ClientNr_TextEdit.EditValue
                SplashScreenManager.CloseForm(False)
                Me.CustomersVerticalGrid.Text = "Details for Client Nr. " & ClientNr_TextEdit.EditValue
                Me.CustomersVerticalGrid.ShowDialog()

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try



        End If
    End Sub

    Private Sub ContractNr_TextEdit_DoubleClick(sender As Object, e As EventArgs) Handles ContractNr_TextEdit.DoubleClick
        If Me.LayoutControl1.Visible = False Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Customer Details...")
                GLOBAL_CLIENT_NR = ClientNr_TextEdit.EditValue
                GLOBAL_CONTRACT_NR = Me.ContractNr_TextEdit.EditValue
                SplashScreenManager.CloseForm(False)
                Me.CustomerContractVG.Text = "Details for Contract Nr. " & Me.ContractNr_TextEdit.EditValue
                Me.CustomerContractVG.ShowDialog()

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try



        End If
    End Sub
End Class