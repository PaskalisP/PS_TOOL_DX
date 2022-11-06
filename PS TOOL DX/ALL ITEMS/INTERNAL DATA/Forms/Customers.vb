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
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class Customers

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable

    Dim CrystalRepDir As String = Nothing

    Private BS_National_Identifiers As BindingSource
    Private BS_NACE_Branch_Codes As BindingSource
    Private BS_Instutional_Sector_Codes As BindingSource
    Private BS_Legal_Codes As BindingSource
    Private BS_Legal_Proceedings As BindingSource
    Private BS_Enterprise_Size As BindingSource
    Private BS_All_Customers As BindingSource

    Dim Details_Default_View As String = Nothing
    Dim ClientNrSearch As String = Nothing
    Dim ResidenceCountryEU_Member As String = Nothing

    Dim CustomerNewAdd As New CustomersAdd()
    Dim CustomerContractVG As New AllContractsAccountsVG()
    Dim CustomerVG As New CustomersVG()

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

    Private Sub Customers_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Me.LayoutControl1.Visible = False Then
            If e.KeyCode = Keys.Escape AndAlso fExtendedEditModeAnaCredit = False Then

                'Update Changes
                Try
                  
                    Me.CUSTOMER_INFOBindingSource.CancelEdit()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    Me.LayoutControl1.Visible = True
                    GridControl2.MainView = CustomerBaseView
                    Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                    ''''''
                    Dim view As GridView = CustomerBaseView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    view.FocusedRowHandle = focusedRow
                    '''''''''''''
                    GridControl2.UseEmbeddedNavigator = True
                    Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                    Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                    CustomerViews_btn.Text = strShowExtendedMode
                    CustomerViews_btn.ImageIndex = 8
                    fExtendedEditMode = (GridControl2.MainView Is CustomerDetailView)

                    '***********************************************************************
                Catch ex As Exception

                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            ElseIf e.KeyCode = Keys.Escape AndAlso fExtendedEditModeAnaCredit = True Then
                Try
                   
                    Me.CUSTOMER_INFOBindingSource.CancelEdit()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    Me.LayoutControl1.Visible = True
                    GridControl2.MainView = CustomerAnaCreditBaseView

                    ''''''
                    Dim view As GridView = CustomerAnaCreditBaseView
                    Dim focusedRow As Integer = view.FocusedRowHandle
                    Me.GridControl2.BeginUpdate()
                    Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                    view.RefreshData()
                    Me.GridControl2.EndUpdate()
                    view.FocusedRowHandle = focusedRow
                    '''''''''''''
                    GridControl2.UseEmbeddedNavigator = True
                    Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                    Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                    AnaCreditCustomerViews_btn.Text = strHideExtendedModeAnaCredit
                    AnaCreditCustomerViews_btn.ImageIndex = 14
                    fExtendedEditModeAnaCredit = True
                Catch ex As Exception
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End Try
            End If
        End If

        If Me.LayoutControl1.Visible = True Then
            If e.KeyCode = Keys.F5 Then
                Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
            End If
            If e.KeyCode = Keys.F7 Then
                Me.AnaCreditCustomerViews_btn.PerformClick()
            End If
        ElseIf Me.LayoutControl1.Visible = False Then
            If e.KeyCode = Keys.F5 Then
                Me.SaveChanges_btn.PerformClick()
            End If
        End If

    End Sub

    Private Sub Customers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.LayoutControl1.Dock = DockStyle.Fill
        Me.ClientSearch_GridLookUpEdit.Visible = False

        AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn

        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [PARAMETER1]='Customers_Detail_View' and [PARAMETER STATUS]='Y' and [IdABTEILUNGSPARAMETER]='DEFAULT_FORM_VIEWS' and [IdABTEILUNGSCODE_NAME]='EDP'"
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        Details_Default_View = cmd.ExecuteScalar
        cmd.CommandText = "SELECT [PARAMETER2] FROM [PARAMETER] where [IdABTEILUNGSPARAMETER]='CRYSTAL_REP_DIR' and [PARAMETER STATUS]='Y' "
        CrystalRepDir = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If



        Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)

        'Gridcontrol2 - CUSTOMERS
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        GridControl2.MainView = CustomerBaseView
        CustomerBaseView.ForceDoubleClick = True
        AddHandler CustomerBaseView.DoubleClick, AddressOf CustomerBaseView_DoubleClick
        AddHandler CustomerDetailView.MouseDown, AddressOf CustomerDetailView_MouseDown
        AddHandler CustomerViews_btn.Click, AddressOf CustomerViews_btn_Click
        CustomerDetailView.OptionsBehavior.AutoFocusCardOnScrolling = True
        CustomerDetailView.OptionsBehavior.AllowSwitchViewModes = False

    End Sub

#Region "ADD NEW FINANCIAL CUSTOMER"
    Private Sub GridControl2_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        'Activate all Procedures
        If e.Button.Tag = "AddNewCustomer" Then
            'Me.LayoutControl1.Visible = False
            'Me.ClientNr_TextEdit.Focus()
            Try

                Dim dxOK_NewCustomer As New DevExpress.XtraEditors.SimpleButton
                With dxOK_NewCustomer
                    .Text = "Add new Customer"
                    .Height = 23
                    .Width = 135
                    .ImageList = CustomerNewAdd.ImageCollection1
                    .ImageIndex = 5
                    .Location = New System.Drawing.Point(12, 247)
                    .TabIndex = 20
                    .TabStop = True
                End With

                CustomerNewAdd.Controls.Add(dxOK_NewCustomer)
                CustomerNewAdd.AddNewCustomer_btn.Visible = False

                AddHandler dxOK_NewCustomer.Click, AddressOf dxOK_NewCustomer_click

                CustomerNewAdd.ClientNr_TextEdit.Focus()
                CustomerNewAdd.CCB_Group_ImageComboBoxEdit.SelectedIndex = 2
                CustomerNewAdd.CCB_Group_OwnID_ImageComboBoxEdit.SelectedIndex = 2
                CustomerNewAdd.CIC_Group_ImageComboBoxEdit.SelectedIndex = 2
                CustomerNewAdd.ShowDialog()


            Catch ex As System.Exception
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End If
    End Sub

    Private Sub dxOK_NewCustomer_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If CustomerNewAdd.ClientNr_TextEdit.Text <> "" AndAlso CustomerNewAdd.OPICS_Client_Code_TextEdit.Text <> "" AndAlso CustomerNewAdd.OPICS_Client_Nr_TextEdit.Text <> "" AndAlso CustomerNewAdd.ClientName_TextEdit.Text <> "" AndAlso CustomerNewAdd.BIC_CODE_TextEdit.Text <> "" AndAlso CustomerNewAdd.BIC_CODE_lbl.Text <> "" AndAlso CustomerNewAdd.CCB_Group_ImageComboBoxEdit.SelectedIndex <> 2 AndAlso CustomerNewAdd.CCB_Group_OwnID_ImageComboBoxEdit.SelectedIndex <> 2 AndAlso CustomerNewAdd.CIC_Group_ImageComboBoxEdit.SelectedIndex <> 2 AndAlso CustomerNewAdd.CustomerType_ImageComboBoxEdit.EditValue <> "" Then
                Dim CLIENT_NR As String = CustomerNewAdd.ClientNr_TextEdit.Text
                cmd.CommandText = "SELECT [ClientNo] FROM [CUSTOMER_INFO] where [ClientNo]='" & CLIENT_NR & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    XtraMessageBox.Show("The Client Nr.: " & CLIENT_NR & " is allready present!" & vbNewLine & vbNewLine & "Please check your input!", "CLIENT NR ALLREADY PRESENT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else 'VALIDITY OK
                    If XtraMessageBox.Show("Should the Client Nr.: " & CLIENT_NR & vbNewLine & "Name: " & CustomerNewAdd.ClientName_TextEdit.Text & vbNewLine & "be inserted to the Customer Datatable?", "ADDING NEW CUSTOMER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        If cmd.Connection.State = ConnectionState.Closed Then
                            cmd.Connection.Open()
                        End If
                        cmd.CommandText = "INSERT INTO [CUSTOMER_INFO]([ClientNo],[ClientType],[English Name],[Chinese Name],[BIC11],[BIC11_NAME],[LEI_CODE],[OpicsCustomerCode],[OpicsCustomerNr],[CCB_Group],[CCB_Group_OwnID],[CIC_Group]) VALUES ('" & CustomerNewAdd.ClientNr_TextEdit.Text & "','" & CustomerType & "','" & CustomerNewAdd.ClientName_TextEdit.Text & "','" & CustomerNewAdd.ClientName_TextEdit.Text & "','" & CustomerNewAdd.BIC_CODE_TextEdit.Text & "','" & CustomerNewAdd.BIC_CODE_lbl.Text & "','" & CustomerNewAdd.LEI_Code_TextEdit.Text & "','" & CustomerNewAdd.OPICS_Client_Code_TextEdit.Text & "','" & CustomerNewAdd.OPICS_Client_Nr_TextEdit.Text & "','" & CCB_Group & "','" & CCB_Group_Own_ID & "','" & CIC_Group & "')"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE [CUSTOMER_INFO] SET [OpicsCustomerCode]=LTRIM(RTRIM([OpicsCustomerCode])) where [ClientNo]='" & CLIENT_NR & "'"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE A SET A.BLZ=B.NATIONAL_ID from CUSTOMER_INFO A INNER JOIN BIC_DIRECTORY_PLUS B on A.BIC11=B.BIC11 where LEN(A.BIC11)=11 and A.BIC11 is not NULL and LEN(B.BIC11)=11 and B.BIC11 is not NULL and SUBSTRING(A.BIC11,5,2) in ('DE') and A.[ClientNo]='" & CLIENT_NR & "'"
                        cmd.ExecuteNonQuery()
                        'DEFINE CCB GROUP for CUSTOMER
                        'cmd.CommandText = "UPDATE A SET A.[CCB_Group]='Y' from [CUSTOMER_INFO] A INNER JOIN (Select [PARAMETER1],[PARAMETER2] as S from [PARAMETER] where [IdABTEILUNGSPARAMETER]='MAKREPSPCODE' and [PARAMETER2] in ('CCBG') and [PARAMETER STATUS] ='Y')B ON A.[English Name] like B.[PARAMETER1] where A.[ClientType] in ('F - FINANCIAL') and A.[ClientNo]='" & CustomerNewAdd.ClientNr_TextEdit.Text & "'"
                        'cmd.ExecuteNonQuery()
                        If cmd.Connection.State = ConnectionState.Open Then
                            cmd.Connection.Close()
                        End If
                        CustomerNewAdd.ClientNr_TextEdit.Text = Nothing
                        CustomerNewAdd.OPICS_Client_Code_TextEdit.Text = Nothing
                        CustomerNewAdd.OPICS_Client_Nr_TextEdit.Text = Nothing
                        CustomerNewAdd.ClientName_TextEdit.Text = Nothing
                        CustomerNewAdd.BIC_CODE_TextEdit.Text = Nothing
                        CustomerNewAdd.BIC_CODE_lbl.Text = Nothing
                        CustomerNewAdd.LEI_Code_TextEdit.Text = Nothing
                        CustomerNewAdd.Close()
                        Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                        XtraMessageBox.Show("The Client Nr.: " & CLIENT_NR & " is imported to the Customers Datatable!", "CLIENT NR ADDED", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                    Else
                        Exit Sub
                    End If
                End If
            Else
                XtraMessageBox.Show(" The following Fields are mandatory:" & vbNewLine & "Client Nr." & vbNewLine & "Client Type" & vbNewLine & "OPICS Client Code" & vbNewLine & "OPICS Client Nr." & vbNewLine & "Client Name" & vbNewLine & "CCB Group" & vbNewLine & "CCB Group (Own ID)" & vbNewLine & "CIC Group" & vbNewLine & "BIC Code" & vbNewLine & vbNewLine & "Please check your inputs!", "MANDATORY FIELDS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CUSTOMER_INFOBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CUSTOMER_INFOBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)

    End Sub

#End Region

#Region "CUSTOMER_CHANGE_VIEWS"
    Private fExtendedEditMode As Boolean = False
    Private strHideExtendedMode As String = "Save Changes and View List"
    Private strShowExtendedMode As String = "View/Modify Details"
    Protected Sub HideDetail(ByVal rowHandle As Integer)
        'Update Changes
        Try
            CustomerDetailView.PostEditor()
            Me.Validate()
            Me.CUSTOMER_INFOBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
            '***********************************************************************
        Catch ex As Exception
            CustomerDetailView.HideEditor()
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        GridControl2.MainView.PostEditor()
        Dim datasourceRowIndex As Integer = CustomerDetailView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CustomerBaseView
        SynchronizeOrdersView(datasourceRowIndex)
        ''''''
        Dim view As GridView = CustomerBaseView
        Dim focusedRow As Integer = view.FocusedRowHandle
        Me.GridControl2.BeginUpdate()
        Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
        view.RefreshData()
        Me.GridControl2.EndUpdate()
        view.FocusedRowHandle = focusedRow
        '''''''''''''
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        CustomerViews_btn.Text = strShowExtendedMode
        CustomerViews_btn.ImageIndex = 8
        fExtendedEditMode = (GridControl2.MainView Is CustomerDetailView)
        Me.ClientSearch_GridLookUpEdit.Visible = False
    End Sub
    Protected Sub ShowDetail(ByVal rowHandle As Integer)
        Dim datasourceRowIndex As Integer = CustomerBaseView.GetDataSourceRowIndex(rowHandle)
        GridControl2.MainView = CustomerDetailView
        SynchronizeOrdersDetailView(datasourceRowIndex)
        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        CustomerViews_btn.Text = strHideExtendedMode
        CustomerViews_btn.ImageIndex = 9
        fExtendedEditMode = (GridControl2.MainView Is CustomerDetailView)
        Me.ClientSearch_GridLookUpEdit.Visible = False
    End Sub
    Protected Sub SynchronizeOrdersView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CustomerBaseView.GetRowHandle(dataSourceRowIndex)
        CustomerBaseView.FocusedRowHandle = rowHandle
    End Sub
    Protected Sub SynchronizeOrdersDetailView(ByVal dataSourceRowIndex As Integer)
        Dim rowHandle As Integer = CustomerDetailView.GetRowHandle(dataSourceRowIndex)
        CustomerDetailView.VisibleRecordIndex = CustomerDetailView.GetVisibleIndex(rowHandle)
        CustomerDetailView.FocusedRowHandle = dataSourceRowIndex
    End Sub

    Protected Sub CustomerBaseView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        If Details_Default_View = "O" Then
            Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)
            Dim hi As GridHitInfo = CustomerBaseView.CalcHitInfo(ea.Location)
            If hi.InRow Then
                ShowDetail(hi.RowHandle)
            End If

        Else

            ''''''''''''''''''''''''''''
            '''''''''NEW SCRIPT'''''''''
            ''''''''''''''''''''''''''''
            If Me.CustomerBaseView.IsFilterRow(Me.CustomerBaseView.FocusedRowHandle) = True OrElse Me.CustomerAnaCreditBaseView.IsFilterRow(Me.CustomerAnaCreditBaseView.FocusedRowHandle) = True Then
                Return
            Else
                Me.LayoutControl1.Visible = False
                'Get National Identifiers based on the Country of Residence
                NATIONAL_IDENTIFIERS_initData()
                NATIONAL_IDENTIFIERS_InitLookUp()
                'NACE_BRANCH_CODES_initData()
                'NACE_BRANCH_CODES_InitLookUp()
                'INSTITUT_SECTOR_CODES_initData()
                'INSTITUT_SECTOR_CODES_InitLookUp()
                LEGAL_CODES_initData()
                LEGAL_CODES_InitLookUp()
                LEGAL_PROCEEDINGS_initData()
                LEGAL_PROCEEDINGS_InitLookUp()
                ENTERPRISE_SIZE_initData()
                ENTERPRISE_SIZE_InitLookUp()
                NACE_BRANCH_CODES_initData()
                NACE_BRANCH_CODES_InitLookUp()
                ALL_CUSTOMER_CONTRACTS_LOAD()
                GROUP_DETAILS_LOAD()
                LOAD_ALL_RATINGS()
                ALL_CUSTOMERS_initData()
                ALL_CUSTOMERS_InitLookUp()
                Me.ClientSearch_GridLookUpEdit.Text = Me.ClientNr_TextEdit.Text
                Me.ClientSearch_GridLookUpEdit.Visible = True
                PERSONAL_CUSTOMERS_FIELDS_VISIBILITY()
                ANACREDIT_CLIENTS_FIELDS_REQUIRED()
            End If
        End If

    End Sub
    Protected Sub CustomerDetailView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            Dim hi As LayoutViewHitInfo = CustomerDetailView.CalcHitInfo(e.Location)
            If hi.InCard Then
                'HideDetail(hi.RowHandle)
                Dim datasourceRowIndex As Integer = CustomerDetailView.GetDataSourceRowIndex(hi.RowHandle)
                GridControl2.MainView = CustomerBaseView
                SynchronizeOrdersView(datasourceRowIndex)
                ''''''
                Dim view As GridView = CustomerBaseView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                '''''''''''''
                GridControl2.UseEmbeddedNavigator = True
                Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                CustomerViews_btn.Text = strShowExtendedMode
                CustomerViews_btn.ImageIndex = 8
                fExtendedEditMode = (GridControl2.MainView Is CustomerDetailView)
            End If
        End If
    End Sub
    Protected Sub CustomerViews_btn_Click(ByVal sender As Object, ByVal e As EventArgs)
        
        If Details_Default_View = "O" Then
            If fExtendedEditMode Then
                HideDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            Else
                ShowDetail((TryCast(GridControl2.MainView, ColumnView)).FocusedRowHandle)
            End If

        Else

            ''''''''''''''''''''''''''''
            '''''''''NEW SCRIPT'''''''''
            ''''''''''''''''''''''''''''
            If Me.CustomerBaseView.IsFilterRow(Me.CustomerBaseView.FocusedRowHandle) = True OrElse Me.CustomerAnaCreditBaseView.IsFilterRow(Me.CustomerAnaCreditBaseView.FocusedRowHandle) = True Then
                Return
            Else
                Me.LayoutControl1.Visible = False
                'Get National Identifiers based on the Country of Residence
                NATIONAL_IDENTIFIERS_initData()
                NATIONAL_IDENTIFIERS_InitLookUp()
                'NACE_BRANCH_CODES_initData()
                'NACE_BRANCH_CODES_InitLookUp()
                'INSTITUT_SECTOR_CODES_initData()
                'INSTITUT_SECTOR_CODES_InitLookUp()
                LEGAL_CODES_initData()
                LEGAL_CODES_InitLookUp()
                LEGAL_PROCEEDINGS_initData()
                LEGAL_PROCEEDINGS_InitLookUp()
                ENTERPRISE_SIZE_initData()
                ENTERPRISE_SIZE_InitLookUp()
                NACE_BRANCH_CODES_initData()
                NACE_BRANCH_CODES_InitLookUp()
                ALL_CUSTOMER_CONTRACTS_LOAD()
                GROUP_DETAILS_LOAD()
                ALL_CUSTOMERS_initData()
                ALL_CUSTOMERS_InitLookUp()
                Me.ClientSearch_GridLookUpEdit.Text = Me.ClientNr_TextEdit.Text
                Me.ClientSearch_GridLookUpEdit.Visible = True
                PERSONAL_CUSTOMERS_FIELDS_VISIBILITY()
                ANACREDIT_CLIENTS_FIELDS_REQUIRED()
            End If
        End If

    End Sub
#End Region

#Region "ANACREDIT_CUSTOMER_CHANGE_VIEWS"
    Private fExtendedEditModeAnaCredit As Boolean = False
    Private strHideExtendedModeAnaCredit As String = "View Default Details"
    Private strShowExtendedModeAnaCredit As String = "View Additional Details"

    Private Sub HideViewAnaCredit()

        GridControl2.MainView = CustomerBaseView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()

        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        AnaCreditCustomerViews_btn.Text = strShowExtendedModeAnaCredit
        AnaCreditCustomerViews_btn.ImageIndex = 13
        fExtendedEditModeAnaCredit = False

    End Sub
    Private Sub ShowViewAnaCredit()

        GridControl2.MainView = CustomerAnaCreditBaseView
        Me.GridControl1.ForceInitialize()
        Me.GridControl1.RefreshDataSource()

        GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        AnaCreditCustomerViews_btn.Text = strHideExtendedModeAnaCredit
        AnaCreditCustomerViews_btn.ImageIndex = 14
        fExtendedEditModeAnaCredit = True

    End Sub

   

    Private Sub CustomerAnaCreditBaseView_DoubleClick(sender As Object, e As EventArgs) Handles CustomerAnaCreditBaseView.DoubleClick
        Me.LayoutControl1.Visible = False
        'Get National Identifiers based on the Country of Residence
        NATIONAL_IDENTIFIERS_initData()
        NATIONAL_IDENTIFIERS_InitLookUp()
        'NACE_BRANCH_CODES_initData()
        'NACE_BRANCH_CODES_InitLookUp()
        'INSTITUT_SECTOR_CODES_initData()
        'INSTITUT_SECTOR_CODES_InitLookUp()
        LEGAL_CODES_initData()
        LEGAL_CODES_InitLookUp()
        LEGAL_PROCEEDINGS_initData()
        LEGAL_PROCEEDINGS_InitLookUp()
        ENTERPRISE_SIZE_initData()
        ENTERPRISE_SIZE_InitLookUp()
        NACE_BRANCH_CODES_initData()
        NACE_BRANCH_CODES_InitLookUp()
        ALL_CUSTOMER_CONTRACTS_LOAD()
        GROUP_DETAILS_LOAD()
        ALL_CUSTOMERS_initData()
        ALL_CUSTOMERS_InitLookUp()
        Me.ClientSearch_GridLookUpEdit.Text = Me.ClientNr_TextEdit.Text
        Me.ClientSearch_GridLookUpEdit.Visible = True
        PERSONAL_CUSTOMERS_FIELDS_VISIBILITY()
        ANACREDIT_CLIENTS_FIELDS_REQUIRED()

    End Sub

    Private Sub AnaCreditCustomerViews_btn_Click(sender As Object, e As EventArgs) Handles AnaCreditCustomerViews_btn.Click

        If fExtendedEditModeAnaCredit = True Then
            HideViewAnaCredit()
        ElseIf fExtendedEditModeAnaCredit = False Then
            ShowViewAnaCredit()
        End If
    End Sub
#End Region

#Region "PERSONAL CUSTOMERS FIELDS VISIBILITY"

    Private Sub PERSONAL_CUSTOMERS_FIELDS_VISIBILITY()
        Dim BISTA_Values As New List(Of String)(New String() {"221", "222", "223"})
        If Me.AnaCreditCustomer_ImageComboBoxEdit.EditValue.ToString = "N" Then
            If Me.IndustrialClassLocal_TextEdit5.Text.StartsWith("97") = True Or BISTA_Values.Contains(Me.SectorBISTA_TextEdit.Text) = True Then
                GroupControl5.Enabled = False
                GroupControl6.Enabled = False
                GroupControl7.Enabled = False
                GroupControl8.Enabled = False
                GroupControl9.Enabled = False
                GroupControl10.Enabled = False
                GroupControl11.Enabled = False
            ElseIf Me.IndustrialClassLocal_TextEdit5.Text.StartsWith("97") = False Or BISTA_Values.Contains(Me.SectorBISTA_TextEdit.Text) = False Then
                If Me.EU_Country_ImageComboBoxEdit.EditValue.ToString = "Y" Then
                    GroupControl5.Enabled = True
                    GroupControl6.Enabled = True
                    GroupControl7.Enabled = True
                    GroupControl8.Enabled = True
                    GroupControl9.Enabled = True
                    GroupControl10.Enabled = True
                    GroupControl11.Enabled = True
                    Me.EnterpriseSize_DateEdit.Enabled = True
                    Me.EmployeesNumber_SpinEdit1.Enabled = True
                    Me.EnterpriseBalanceSheet_SpinEdit.Enabled = True
                    Me.EnterpriseAnnualTurnover_SpinEdit.Enabled = True
                ElseIf Me.EU_Country_ImageComboBoxEdit.EditValue.ToString = "N" Then
                    GroupControl5.Enabled = True
                    GroupControl6.Enabled = True
                    GroupControl7.Enabled = True
                    GroupControl8.Enabled = True
                    GroupControl9.Enabled = True
                    GroupControl10.Enabled = False
                    GroupControl11.Enabled = True
                    Me.EnterpriseSize_DateEdit.Enabled = False
                    Me.EmployeesNumber_SpinEdit1.Enabled = False
                    Me.EnterpriseBalanceSheet_SpinEdit.Enabled = False
                    Me.EnterpriseAnnualTurnover_SpinEdit.Enabled = False
                End If
            End If
        End If

    End Sub

#End Region

#Region "ANACREDIT CLIENTS FIELDS REQUIRED"
    Private Sub ANACREDIT_CLIENTS_FIELDS_REQUIRED()
        If Me.AnaCreditCustomer_ImageComboBoxEdit.EditValue.ToString = "Y" Then
            If Me.EU_Country_ImageComboBoxEdit.EditValue.ToString = "Y" Then
                GroupControl5.Enabled = True
                GroupControl6.Enabled = True
                GroupControl7.Enabled = True
                GroupControl8.Enabled = True
                GroupControl9.Enabled = True
                GroupControl10.Enabled = True
                GroupControl11.Enabled = True
                Me.EnterpriseSize_DateEdit.Enabled = True
                Me.EmployeesNumber_SpinEdit1.Enabled = True
                Me.EnterpriseBalanceSheet_SpinEdit.Enabled = True
                Me.EnterpriseAnnualTurnover_SpinEdit.Enabled = True
            ElseIf Me.EU_Country_ImageComboBoxEdit.EditValue.ToString = "N" Then
                GroupControl5.Enabled = True
                GroupControl6.Enabled = True
                GroupControl7.Enabled = True
                GroupControl8.Enabled = True
                GroupControl9.Enabled = True
                GroupControl10.Enabled = False
                GroupControl11.Enabled = True
                Me.EnterpriseSize_DateEdit.Enabled = False
                Me.EmployeesNumber_SpinEdit1.Enabled = False
                Me.EnterpriseBalanceSheet_SpinEdit.Enabled = False
                Me.EnterpriseAnnualTurnover_SpinEdit.Enabled = False
            End If
        End If


    End Sub
#End Region

#Region "GRIDVIEW STYLES"

    Private Sub CustomerBaseView_ColumnFilterChanged(sender As Object, e As EventArgs) Handles CustomerBaseView.ColumnFilterChanged
        Dim view As GridView = DirectCast(sender, GridView)
        CustomerAnaCreditBaseView.ActiveFilterCriteria = view.ActiveFilterCriteria
    End Sub
    Private Sub CustomerBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CustomerAnaCreditBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerAnaCreditBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerAnaCreditBaseView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerAnaCreditBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub CustomerAnaCreditBaseView_ColumnFilterChanged(sender As Object, e As EventArgs) Handles CustomerAnaCreditBaseView.ColumnFilterChanged
        Dim view As GridView = DirectCast(sender, GridView)
        CustomerBaseView.ActiveFilterCriteria = view.ActiveFilterCriteria
    End Sub

  

    Private Sub NationalIdentifiers_SearchLookUpEditView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NationalIdentifiers_SearchLookUpEditView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub NationalIdentifiers_SearchLookUpEditView_ShownEditor(sender As Object, e As EventArgs) Handles NationalIdentifiers_SearchLookUpEditView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub NACE_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles NACE_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub NACE_GridView_ShownEditor(sender As Object, e As EventArgs) Handles NACE_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub LegalForm_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LegalForm_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LegalForm_GridView_ShownEditor(sender As Object, e As EventArgs) Handles LegalForm_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub LegalProceedingsStatus_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles LegalProceedingsStatus_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub LegalProceedingsStatus_GridView_ShownEditor(sender As Object, e As EventArgs) Handles LegalProceedingsStatus_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Enterprise_Size_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles Enterprise_Size_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub Enterprise_Size_GridView_ShownEditor(sender As Object, e As EventArgs) Handles Enterprise_Size_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
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
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SearchLookUpEdit1View_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SearchLookUpEdit1View.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SearchLookUpEdit1View_ShownEditor(sender As Object, e As EventArgs) Handles SearchLookUpEdit1View.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GroupDetails_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GroupDetails_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub GroupDetails_GridView_ShownEditor(sender As Object, e As EventArgs) Handles GroupDetails_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CustomerRating_GridView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles CustomerRating_GridView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub CustomerRating_GridView_ShownEditor(sender As Object, e As EventArgs) Handles CustomerRating_GridView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

#End Region


    Private Sub Customer_Print_Export_btn_Click(sender As Object, e As EventArgs) Handles Customer_Print_Export_btn.Click

        If Not GridControl2.IsPrintingAvailable Then
            XtraMessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
            Return
        End If
        ' Opens the Preview window. 
        'GridControl1.ShowPrintPreview()
        If CustomerViews_btn.Text = "View/Modify Details" Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        Else
            Me.CustomerDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = False
            Me.CustomerDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = False
            Me.CustomerDetailView.OptionsPrint.PrintSelectedCardsOnly = True
            Me.CustomerDetailView.OptionsPrint.PrintCardCaption = True
            Me.CustomerDetailView.OptionsPrint.AllowCancelPrintExport = True
            Me.CustomerDetailView.OptionsPrint.ShowPrintExportProgress = True
            'Me.CustomerDetailView.ShowPrintPreview()
            PreviewPrintableComponent(GridControl2, GridControl2.LookAndFeel)
            Me.CustomerDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
            Me.CustomerDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True


        End If
    End Sub

    Private Sub PreviewPrintableComponent(component As IPrintable, lookAndFeel As UserLookAndFeel)
        Dim link As New PrintableComponentLink() With { _
            .PrintingSystemBase = New PrintingSystem(), _
            .Component = component, _
            .Landscape = True, _
            .PaperKind = Printing.PaperKind.A4, _
            .Margins = New Printing.Margins(20, 90, 20, 20) _
        }
        ' Show the report. 
        link.PrintingSystem.Document.AutoFitToPagesWidth = 1
        link.ShowRibbonPreview(lookAndFeel)

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
        Dim reportfooter As String = "CUSTOMERS" & "   " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub

    Private Sub CustomerDetailView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles CustomerDetailView.CellValueChanged
        If CustomerDetailView.FocusedColumn.FieldName = "BIC11" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT LTRIM(RTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',LTRIM(RTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_NAME_1, dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                    'Get LEI CODE
                    cmd.CommandText = "SELECT [ISO_LEI_CODE] from BIC_DIRECTORY_PLUS where BIC11='" & BICCODE & "' and [ISO_LEI_CODE] is not NULL"
                    Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt1 As New DataTable
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        CustomerDetailView.SetRowCellValue(e.RowHandle, colLEI_CODE_1, dt1.Rows.Item(0).Item("ISO_LEI_CODE"))
                    End If
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_NAME_1, "")
                    CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_1, "")
                End If
            End If
        End If
    End Sub

    Private Sub CustomerDetailView_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles CustomerDetailView.CellValueChanging
        If CustomerDetailView.FocusedColumn.FieldName = "BIC11" Then
            'Get the currently edited value 
            Dim BICCODE As String = Convert.ToString(e.Value)
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT LTRIM(RTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',LTRIM(RTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_NAME_1, dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                    'Get LEI CODE
                    cmd.CommandText = "SELECT [ISO_LEI_CODE] from BIC_DIRECTORY_PLUS where BIC11='" & BICCODE & "' and [ISO_LEI_CODE] is not NULL"
                    Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt1 As New DataTable
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        CustomerDetailView.SetRowCellValue(e.RowHandle, colLEI_CODE_1, dt1.Rows.Item(0).Item("ISO_LEI_CODE"))
                    End If
                Else
                    XtraMessageBox.Show("BIC CODE not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_NAME_1, "")
                    CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_1, "")
                End If
            End If
        End If
    End Sub

    Private Sub BIC_RepositoryItemTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BIC_RepositoryItemTextEdit.EditValueChanged
        'Try
        'CustomerDetailView.PostEditor()
        'Me.Validate()
        'Me.CUSTOMER_INFOBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Catch ex As Exception
        'CustomerDetailView.HideEditor()
        'XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
    End Sub

    Private Sub LEI_RepositoryItemTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LEI_RepositoryItemTextEdit.EditValueChanged
        'Try
        'CustomerDetailView.PostEditor()
        'Me.Validate()
        'Me.CUSTOMER_INFOBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Catch ex As Exception
        'CustomerDetailView.HideEditor()
        'XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
    End Sub

    Private Sub CCB_Group_RepositoryItemImageComboBox_EditValueChanged(sender As Object, e As EventArgs) Handles CCB_Group_RepositoryItemImageComboBox.EditValueChanged
        'Try
        'CustomerDetailView.PostEditor()
        'Me.Validate()
        'Me.CUSTOMER_INFOBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
        '***********************************************************************
        'Catch ex As Exception
        'CustomerDetailView.HideEditor()
        'XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Exit Sub
        'End Try
    End Sub

    Private Sub BIC_Code_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BIC_Code_TextEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            'Get the currently edited value 
            'Dim BICCODE As String = Convert.ToString(e.Value)
            Dim BICCODE As String = Me.BIC_Code_TextEdit.Text
            'Specify validation criteria 
            If Len(BICCODE) = 11 Then
                cmd.CommandText = "SELECT LTRIM(RTRIM([INSTITUTION NAME])) as 'INSTITUTION NAME',LTRIM(RTRIM([CITY HEADING])) as 'CITY HEADING' FROM [BIC DIRECTORY] where [BIC11]='" & BICCODE & "' "
                Dim da As New SqlDataAdapter(cmd.CommandText, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    'CustomerDetailView.SetRowCellValue(e.RowHandle, colBIC11_NAME_1, dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING"))
                    Me.BIC_Code_Name_lbl.Text = dt.Rows.Item(0).Item("INSTITUTION NAME") & " , " & dt.Rows.Item(0).Item("CITY HEADING")
                    'Get LEI CODE
                    cmd.CommandText = "SELECT [ISO_LEI_CODE] from BIC_DIRECTORY_PLUS where BIC11='" & BICCODE & "' and [ISO_LEI_CODE] is not NULL"
                    Dim da1 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt1 As New DataTable
                    da1.Fill(dt1)
                    If dt1.Rows.Count > 0 Then
                        'CustomerDetailView.SetRowCellValue(e.RowHandle, colLEI_CODE_1, dt1.Rows.Item(0).Item("ISO_LEI_CODE"))
                        Me.LEI_Code_TextEdit.Text = dt1.Rows.Item(0).Item("ISO_LEI_CODE")
                    End If
                    'Get BLZ
                    cmd.CommandText = "SELECT LEFT(NATIONAL_ID,8) as 'NATIONAL_ID' from BIC_DIRECTORY_PLUS where BIC11='" & BICCODE & "' and NATIONAL_ID is not NULL and SUBSTRING(BIC11,5,2) in ('DE')"
                    Dim da2 As New SqlDataAdapter(cmd.CommandText, conn)
                    Dim dt2 As New DataTable
                    da2.Fill(dt2)
                    If dt2.Rows.Count > 0 Then
                        Me.BLZ_TextEdit.Text = dt2.Rows.Item(0).Item("NATIONAL_ID")
                    End If
                Else
                    XtraMessageBox.Show("BIC not fund", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    BIC_Code_TextEdit.Text = ""
                    Me.BIC_Code_Name_lbl.Text = ""

                End If
            ElseIf Len(BICCODE) <> 11 Then
                Me.BIC_Code_TextEdit.Text = ""
                Me.BIC_Code_Name_lbl.Text = ""
            End If
        End If

    End Sub

    Private Sub NATIONAL_IDENTIFIERS_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_1] in ('" & Me.CountryOfResidence_TextEdit.Text & "','*','OTHER','Any') and [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('NATIONAL_IDENTIFIERS')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbNationalIdentifiers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbNationalIdentifiers.Fill(ds, "NATIONAL_IDENTIFIERS") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_National_Identifiers = New BindingSource(ds, "NATIONAL_IDENTIFIERS") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub NATIONAL_IDENTIFIERS_InitLookUp()
        Me.NationalIdentifiers_SearchLookUpEdit.Properties.DataSource = BS_National_Identifiers
        Me.NationalIdentifiers_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_3"
        Me.NationalIdentifiers_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_3"
    End Sub

    Private Sub NACE_BRANCH_CODES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('DEFAULT_STATUS')) and [Status] in ('Y')  order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbNace_Branch_Codes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbNace_Branch_Codes.Fill(ds, "DEFAULT_STATUS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_NACE_Branch_Codes = New BindingSource(ds, "DEFAULT_STATUS")
    End Sub

    Private Sub NACE_BRANCH_CODES_InitLookUp()
        Me.NACE_SearchLookUpEdit.Properties.DataSource = BS_NACE_Branch_Codes
        Me.NACE_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.NACE_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub INSTITUT_SECTOR_CODES_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('INSTITUTIONAL_SECTOR')) and [Status] in ('Y')  order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbInsti_Sector_Codes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbInsti_Sector_Codes.Fill(ds, "INSTI_SECTOR_CODES")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Instutional_Sector_Codes = New BindingSource(ds, "INSTI_SECTOR_CODES")
    End Sub

    Private Sub INSTITUT_SECTOR_CODES_InitLookUp()
        Me.NACE_SearchLookUpEdit.Properties.DataSource = BS_Instutional_Sector_Codes
        Me.NACE_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.NACE_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub LEGAL_CODES_initData()
        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        End If
        cmd.CommandText = "Select 'EU_MEMBER_STATE'=Case when (Select COUNTRY_OF_RESIDENCE from CUSTOMER_INFO where ClientNo='" & Me.ClientNr_TextEdit.Text & "') in (Select [COUNTRY CODE] from COUNTRIES where [EU EEA] in ('EU')) then 'Y' else 'N' end"
        ResidenceCountryEU_Member = cmd.ExecuteScalar
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        If ResidenceCountryEU_Member = "Y" Then
            Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_3] in ('" & Me.CountryOfResidence_TextEdit.Text & "','*','any EU country') and [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LEGAL_FORMS')) and [Status] in ('Y') order by ID asc", conn)
            objCMD1.CommandTimeout = 5000
            Dim dbLegal_Codes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

            Dim ds As DataSet = New DataSet()
            'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
            Try

                dbLegal_Codes.Fill(ds, "LEGAL_CODES")

            Catch ex As System.Exception
                MsgBox(ex.Message)

            End Try
            BS_Legal_Codes = New BindingSource(ds, "LEGAL_CODES")
        ElseIf ResidenceCountryEU_Member = "N" Then
            Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [SQL_Name_3] in ('any extra EU country','*') and [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LEGAL_FORMS')) and [Status] in ('Y') order by ID asc", conn)
            objCMD1.CommandTimeout = 5000
            Dim dbLegal_Codes As SqlDataAdapter = New SqlDataAdapter(objCMD1)

            Dim ds As DataSet = New DataSet()
            'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
            Try

                dbLegal_Codes.Fill(ds, "LEGAL_CODES")

            Catch ex As System.Exception
                MsgBox(ex.Message)

            End Try
            BS_Legal_Codes = New BindingSource(ds, "LEGAL_CODES")
        End If

    End Sub

    Private Sub LEGAL_CODES_InitLookUp()
        Me.LegalForm_SearchLookUpEdit.Properties.DataSource = BS_Legal_Codes
        Me.LegalForm_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.LegalForm_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub LEGAL_PROCEEDINGS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('LEGAL_PROCEEDINGS_STATUS')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbLegal_Proceedings As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbLegal_Proceedings.Fill(ds, "LEGAL_PROCEEDINGS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Legal_Proceedings = New BindingSource(ds, "LEGAL_PROCEEDINGS")
    End Sub

    Private Sub LEGAL_PROCEEDINGS_InitLookUp()
        Me.LegalProceedingsStatus_SearchLookUpEdit.Properties.DataSource = BS_Legal_Proceedings
        Me.LegalProceedingsStatus_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.LegalProceedingsStatus_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub ENTERPRISE_SIZE_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('ENTERPRISE_SIZE')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbEnterprise_Size As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbEnterprise_Size.Fill(ds, "ENTERPRISE_SIZE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Enterprise_Size = New BindingSource(ds, "ENTERPRISE_SIZE")
    End Sub

    Private Sub ENTERPRISE_SIZE_InitLookUp()
        Me.EnterpriseSize_SearchLookUpEdit.Properties.DataSource = BS_Enterprise_Size
        Me.EnterpriseSize_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.EnterpriseSize_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub ALL_CUSTOMERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [ClientNo],[ClientNoM],[ClientType],[English Name],[CLOSE_DATE],[AnaCredit_Customer] FROM [CUSTOMER_INFO] ORDER BY CASE WHEN CLOSE_DATE IS NULL THEN 1 WHEN CLOSE_DATE IS NOT NULL THEN 2 END, ClientNo", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbAllCustomers As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbAllCustomers.Fill(ds, "ALL_CUSTOMERS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_All_Customers = New BindingSource(ds, "ALL_CUSTOMERS")
    End Sub

    Private Sub ALL_CUSTOMERS_InitLookUp()
        Me.ClientSearch_GridLookUpEdit.Properties.DataSource = BS_All_Customers
        Me.ClientSearch_GridLookUpEdit.Properties.DisplayMember = "ClientNo"
        Me.ClientSearch_GridLookUpEdit.Properties.ValueMember = "ClientNo"
    End Sub

    Private Sub ALL_CUSTOMER_CONTRACTS_LOAD()
        Me.AllCustomerContracts_GridControl.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [ALL_CONTRACTS_ACCOUNTS] where [ClientNr]='" & Me.ClientNr_TextEdit.Text & "' order by [ID] desc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.AllCustomerContracts_GridControl.DataSource = Nothing
                    Me.AllCustomerContracts_GridControl.DataSource = objDataTable
                    Me.AllCustomerContracts_GridControl.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub SINGLE_CUSTOMER_CONTRACTS_LOAD()
        Me.AllCustomerContracts_GridControl.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [ALL_CONTRACTS_ACCOUNTS] where [ClientNr]='" & ClientNrSearch & "' order by [ID] desc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.AllCustomerContracts_GridControl.DataSource = Nothing
                    Me.AllCustomerContracts_GridControl.DataSource = objDataTable
                    Me.AllCustomerContracts_GridControl.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub GROUP_DETAILS_LOAD()
        Me.Grouping_GridControl.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT * FROM [GROUP_CLIENT_DETAILS] where [ClientNr]='" & ClientNrSearch & "' Order by [ID] asc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.Grouping_GridControl.DataSource = Nothing
                    Me.Grouping_GridControl.DataSource = objDataTable
                    Me.Grouping_GridControl.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub LOAD_ALL_RATINGS()
        Me.CustomerRating_GridControl.DataSource = Nothing
        Try
            Using sqlConn As New SqlConnection(My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT  A.[ID],A.[ClientNo],B.ClientType,B.Valid,B.[ClientName],A.[RatingType],A.[Rating],A.[PD],A.[LGD],A.[CoreDefinition],A.[Valid_From],A.[Valid_Till],A.[IDNr] FROM [CUSTOMER_RATING_DETAILS] A INNER JOIN [CUSTOMER_RATING] B on A.[IDNr]=B.[ID] and A.[ClientNo]=B.[ClientNo] where A.[ClientNo]='" & ClientNrSearch & "' order by A.[IDNr] desc"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim objDataReader As SqlDataReader = sqlCmd.ExecuteReader()
                    Dim objDataTable As New DataTable()
                    objDataTable.Load(objDataReader)
                    Me.CustomerRating_GridControl.DataSource = Nothing
                    Me.CustomerRating_GridControl.DataSource = objDataTable
                    Me.CustomerRating_GridControl.ForceInitialize()
                    sqlConn.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub LayoutControl1_VisibleChanged(sender As Object, e As EventArgs) Handles LayoutControl1.VisibleChanged
        If Me.LayoutControl1.Visible = False Then
            'Get Client Status
            If IsDate(Me.ClosingDate_DateEdit.Text) = True Then
                Me.ClientStatus_lbl.Text = "CLOSED"
                Me.ClientStatus_lbl.BackColor = Color.Red
                Me.ClientStatus_lbl.ForeColor = Color.White
            ElseIf IsDate(Me.ClosingDate_DateEdit.Text) = False Then
                Me.ClientStatus_lbl.Text = "ACTIVE"
                Me.ClientStatus_lbl.BackColor = Color.Green
                Me.ClientStatus_lbl.ForeColor = Color.White
            End If
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                Me.NationalIdentifier_TextEdit.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub NationalIdentifiers_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NationalIdentifiers_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                'Dim view As GridView = NationalIdentifiers_SearchLookUpEdit.Properties.View
                'Dim rowHandle As Integer = view.FocusedRowHandle
                'Me.National_Identifier_Type_Description_lbl.Text = view.GetRowCellValue(rowHandle, "SQL_Name_4")

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim NationalIdentifiersRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.National_Identifier_Type_Description_lbl.Text = NationalIdentifiersRow("SQL_Name_4").ToString
                Me.NationalIdentifier_TextEdit.ReadOnly = False
                'If Me.NationalIdentifier_TextEdit.Text = "" Then
                '    Me.NationalIdentifier_TextEdit.Focus()
                'End If
                'Me.NationalIdentifierType_Other_TextEdit.Text = NationalIdentifiersRow("SQL_Name_3").ToString

                'NO NEEDED ANYMORE Me.NationalIdentifierType_Other_TextEdit
                If Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("GEN_") = True Then
                    '    Me.NationalIdentifierType_Other_TextEdit.ReadOnly = False
                    'Else
                    '    Me.NationalIdentifierType_Other_TextEdit.Text = ""
                    '    Me.NationalIdentifierType_Other_TextEdit.ReadOnly = True
                End If
                'ElseIf Me.NationalIdentifiers_SearchLookUpEdit.Text = "" Then
                'Me.National_Identifier_Type_Description_lbl.Text = ""
                'End If



            Else

                Me.National_Identifier_Type_Description_lbl.Text = ""
                'Me.NationalIdentifierType_Other_TextEdit.Text = ""
                Me.NationalIdentifier_TextEdit.Text = ""
                'Me.NationalIdentifierType_Other_TextEdit.ReadOnly = True
                Me.NationalIdentifier_TextEdit.ReadOnly = True
            End If
        End If

    End Sub

    Private Sub NationalIdentifier_TextEdit_GotFocus(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.GotFocus
        If Me.LayoutControl1.Visible = False Then
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                'SET MASK FOR GERMAN IDENTIFIER
                Dim GermanIdentifier As String = Me.NationalIdentifiers_SearchLookUpEdit.Text.ToString
                Select Case GermanIdentifier
                    Case "DE_HRA_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(HRA)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_HRB_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(HRB)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_PR_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(PR)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_VR_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(VR)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case "DE_GNR_CD"
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.RegEx
                        Me.NationalIdentifier_TextEdit.Properties.Mask.IgnoreMaskBlank = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                        Me.NationalIdentifier_TextEdit.Properties.Mask.EditMask = "(GnR)\d{1,6}[A-Z]{0,3}-[A-Z0-9]{5}"
                    Case Else
                        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
                End Select
            Else
                Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = False
                Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
            End If
        End If

    End Sub

    Private Sub NationalIdentifier_TextEdit_Leave(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.Leave
        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = False
        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
        If Me.NationalIdentifier_TextEdit.Text = "" Then
            Me.NationalIdentifiers_SearchLookUpEdit.Text = ""
        End If
    End Sub

    Private Sub NationalIdentifier_TextEdit_LostFocus(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.LostFocus
        Me.NationalIdentifier_TextEdit.Properties.Mask.UseMaskAsDisplayFormat = False
        Me.NationalIdentifier_TextEdit.Properties.Mask.MaskType = Mask.MaskType.None
        If Me.NationalIdentifier_TextEdit.Text = "" Then
            Me.NationalIdentifiers_SearchLookUpEdit.Text = ""
        End If
    End Sub

    Private Sub NationalIdentifier_TextEdit_TextChanged(sender As Object, e As EventArgs) Handles NationalIdentifier_TextEdit.TextChanged
      
    End Sub


    Private Sub NACE_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NACE_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.NACE_SearchLookUpEdit.Text <> "" Then
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim NACE_Brance_Code_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.DefaultStatus_Description_lbl.Text = NACE_Brance_Code_Row("SQL_Name_2").ToString
                If Me.NACE_SearchLookUpEdit.Text <> "N" Then
                    Me.DateOfDefault_DateEdit.ReadOnly = False
                    If IsDate(Me.DateOfDefault_DateEdit.Text) = False Then
                        Me.DateOfDefault_DateEdit.Text = Today
                    End If

                ElseIf Me.NACE_SearchLookUpEdit.Text = "N" Then
                    Me.DateOfDefault_DateEdit.EditValue = DBNull.Value
                    Me.DateOfDefault_DateEdit.ReadOnly = True

                End If

            ElseIf Me.NACE_SearchLookUpEdit.Text = "" Then
                Me.DefaultStatus_Description_lbl.Text = ""
                Me.DateOfDefault_DateEdit.EditValue = DBNull.Value
                Me.DateOfDefault_DateEdit.ReadOnly = True
            End If
        End If

    End Sub

    Private Sub LegalForm_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LegalForm_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.LegalForm_SearchLookUpEdit.Text <> "" AndAlso Me.LegalForm_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim LEGAL_FORM_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.LegalFormDescription_lbl.Text = LEGAL_FORM_Row("SQL_Name_4").ToString
                '    Me.LegalFormOther_TextEdit.Text = ""
                '    Me.LegalFormOther_TextEdit.ReadOnly = True
                'ElseIf Me.LegalForm_SearchLookUpEdit.Text = "" Or Me.LegalForm_SearchLookUpEdit.Text.StartsWith("-").ToString = True Then
                '    Me.LegalFormDescription_lbl.Text = ""
                '    Me.LegalFormOther_TextEdit.ReadOnly = False
            Else
                Me.LegalFormDescription_lbl.Text = ""
            End If
        End If

    End Sub


    Private Sub LegalProceedingsStatus_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LegalProceedingsStatus_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.LegalProceedingsStatus_SearchLookUpEdit.Text <> "" Then
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim LEGAL_PROCEEDINGS_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.LegalProceedingsStatusDescription_lbl.Text = LEGAL_PROCEEDINGS_Row("SQL_Name_2").ToString
                If Me.LegalProceedingsStatus_SearchLookUpEdit.Text <> "N" Then
                    Me.LegalProceedings_DateEdit.ReadOnly = False
                    If IsDate(Me.LegalProceedings_DateEdit.Text) = False Then
                        Me.LegalProceedings_DateEdit.Text = Today
                    End If

                ElseIf Me.LegalProceedingsStatus_SearchLookUpEdit.Text = "N" Then
                    Me.LegalProceedings_DateEdit.EditValue = DBNull.Value
                    Me.LegalProceedings_DateEdit.ReadOnly = True

                End If
            ElseIf Me.LegalProceedingsStatus_SearchLookUpEdit.Text = "" Then
                Me.LegalProceedingsStatusDescription_lbl.Text = ""
            End If
        End If

    End Sub

    Private Sub EnterpriseSize_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles EnterpriseSize_SearchLookUpEdit.EditValueChanged

        If Me.LayoutControl1.Visible = False Then
            If Me.EnterpriseSize_SearchLookUpEdit.Text <> "" Then
                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim ENTERPRISE_SIZE_Row As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.Enterprise_Size_Description_lbl.Text = ENTERPRISE_SIZE_Row("SQL_Name_2").ToString
                Me.EnterpriseSize_DateEdit.ReadOnly = False
                If IsDate(Me.EnterpriseSize_DateEdit.Text) = False Then
                    Me.EnterpriseSize_DateEdit.Text = Today
                End If

            ElseIf Me.EnterpriseSize_SearchLookUpEdit.Text = "" Then
                Me.Enterprise_Size_Description_lbl.Text = ""
                Me.EnterpriseSize_DateEdit.EditValue = DBNull.Value
                Me.EnterpriseSize_DateEdit.ReadOnly = True
            End If
        End If

    End Sub

    Private Sub SaveChanges_btn_Click(sender As Object, e As EventArgs) Handles SaveChanges_btn.Click
        'Update Changes
        If Me.NationalIdentifier_TextEdit.Text = "" Then
            Me.NationalIdentifiers_SearchLookUpEdit.Text = ""
        End If
        If fExtendedEditModeAnaCredit = False Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Update Database with the last changes")
                Me.Validate()
                Me.CUSTOMER_INFOBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                '++++++++++++++++++++++++++++++++++++++++++++++++++++
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "exec [ANACREDIT_SINGLE_CUSTOMER_VALIDATE] @CLIENTNR='" & Me.ClientNr_TextEdit.Text & "'"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.LayoutControl1.Visible = True
                GridControl2.MainView = CustomerBaseView

                ''''''
                Dim view As GridView = CustomerBaseView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                '''''''''''''
                GridControl2.UseEmbeddedNavigator = True
                Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                CustomerViews_btn.Text = strShowExtendedMode
                CustomerViews_btn.ImageIndex = 8
                fExtendedEditMode = (GridControl2.MainView Is CustomerDetailView)
                SplashScreenManager.CloseForm(False)
                '***********************************************************************
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        ElseIf fExtendedEditModeAnaCredit = True Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Update Database with the last changes")
                Me.Validate()
                Me.CUSTOMER_INFOBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.PSTOOLDataset)
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandText = "exec [ANACREDIT_SINGLE_CUSTOMER_VALIDATE] @CLIENTNR='" & Me.ClientNr_TextEdit.Text & "'"
                cmd.ExecuteNonQuery()
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.LayoutControl1.Visible = True
                GridControl2.MainView = CustomerAnaCreditBaseView


                ''''''
                Dim view As GridView = CustomerAnaCreditBaseView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                '''''''''''''
                GridControl2.UseEmbeddedNavigator = True
                Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                AnaCreditCustomerViews_btn.Text = strHideExtendedModeAnaCredit
                AnaCreditCustomerViews_btn.ImageIndex = 14
                fExtendedEditModeAnaCredit = True
                SplashScreenManager.CloseForm(False)
            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
           
        End If


    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
       
        'Cancel Changes
        If fExtendedEditModeAnaCredit = False Then
            Try

                Me.CUSTOMER_INFOBindingSource.CancelEdit()
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.LayoutControl1.Visible = True
                GridControl2.MainView = CustomerBaseView

                ''''''
                Dim view As GridView = CustomerBaseView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                '''''''''''''
                GridControl2.UseEmbeddedNavigator = True
                Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                CustomerViews_btn.Text = strShowExtendedMode
                CustomerViews_btn.ImageIndex = 8
                fExtendedEditMode = (GridControl2.MainView Is CustomerDetailView)

                '***********************************************************************
            Catch ex As Exception

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        ElseIf fExtendedEditModeAnaCredit = True Then
            Try
                Me.CUSTOMER_INFOBindingSource.CancelEdit()
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Me.LayoutControl1.Visible = True
                GridControl2.MainView = CustomerAnaCreditBaseView

                ''''''
                Dim view As GridView = CustomerAnaCreditBaseView
                Dim focusedRow As Integer = view.FocusedRowHandle
                Me.GridControl2.BeginUpdate()
                Me.CUSTOMER_INFOTableAdapter.Fill(Me.PSTOOLDataset.CUSTOMER_INFO)
                view.RefreshData()
                Me.GridControl2.EndUpdate()
                view.FocusedRowHandle = focusedRow
                '''''''''''''
                GridControl2.UseEmbeddedNavigator = True
                Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
                Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
                AnaCreditCustomerViews_btn.Text = strHideExtendedModeAnaCredit
                AnaCreditCustomerViews_btn.ImageIndex = 14
                fExtendedEditModeAnaCredit = True
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If

    End Sub

    Private Sub ClientSearch_GridLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ClientSearch_GridLookUpEdit.ButtonClick
        If e.Button.Tag = "PrintReport" Then
            If Me.ClientSearch_GridLookUpEdit.Text <> "" AndAlso IsNumeric(Me.ClientSearch_GridLookUpEdit.Text) = True Then
                Me.CUSTOMER_INFOBindingSource.CancelEdit()
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                ClientNrSearch = Me.ClientSearch_GridLookUpEdit.Text
                SplashScreenManager.Default.SetWaitFormCaption("Create Basic Data Report for Customer Nr.: " & ClientNrSearch)

                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                Dim CUSTOMER_INFO_Da As New SqlDataAdapter("Select * from CUSTOMER_INFO where ClientNo='" & ClientNrSearch & "' ", conn)
                Dim CUSTOMER_INFO_Dataset As New DataSet("CUSTOMER_INFO")
                CUSTOMER_INFO_Da.Fill(CUSTOMER_INFO_Dataset, "CUSTOMER_INFO")
                Dim CUSTOMER_CONTRACTS_Da As New SqlDataAdapter("Select * from ALL_CONTRACTS_ACCOUNTS where ClientNr='" & ClientNrSearch & "' ", conn)
                Dim CUSTOMER_CONTRACTS_Dataset As New DataSet("ALL_CONTRACTS_ACCOUNTS")
                CUSTOMER_CONTRACTS_Da.Fill(CUSTOMER_CONTRACTS_Dataset, "ALL_CONTRACTS_ACCOUNTS")
                Dim CUSTOMER_RATINGS_Da As New SqlDataAdapter("Select * from CUSTOMER_RATING_DETAILS where [ClientNo]='" & ClientNrSearch & "' ", conn)
                Dim CUSTOMER_RATINGS_Dataset As New DataSet("CUSTOMER_RATING_DETAILS")
                CUSTOMER_RATINGS_Da.Fill(CUSTOMER_RATINGS_Dataset, "CUSTOMER_RATING_DETAILS")
                Dim CUSTOMER_GROUPS_Da As New SqlDataAdapter("Select * from GROUP_CLIENT_DETAILS where [ClientNr]='" & ClientNrSearch & "' ", conn)
                Dim CUSTOMER_GROUPS_Dataset As New DataSet("GROUP_CLIENT_DETAILS")
                CUSTOMER_GROUPS_Da.Fill(CUSTOMER_GROUPS_Dataset, "GROUP_CLIENT_DETAILS")
                Dim CrRep As New ReportDocument
                CrRep.Load(CrystalRepDir & "\CustomerInfo.rpt")
                CrRep.SetDataSource(CUSTOMER_INFO_Dataset)
                CrRep.Subreports.Item("All_Contracts").SetDataSource(CUSTOMER_CONTRACTS_Dataset)
                CrRep.Subreports.Item("CustomerRatings").SetDataSource(CUSTOMER_RATINGS_Dataset)
                CrRep.Subreports.Item("CustomerGroups").SetDataSource(CUSTOMER_GROUPS_Dataset)
                Dim myValue As ParameterDiscreteValue = New ParameterDiscreteValue
                Dim myParams As ParameterField = New ParameterField
                myValue.Value = ClientNrSearch
                myParams.ParameterFieldName = "ClientNr"
                myParams.CurrentValues.Add(myValue)
                Dim c As New CrystalReportsForm
                c.MdiParent = Me.MdiParent
                c.Show()
                c.WindowState = FormWindowState.Maximized
                c.Text = "Basic Data Report for Customer Nr. " & ClientNrSearch
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


    Private Sub ClientSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.EditValueChanged
        If Me.ClientSearch_GridLookUpEdit.Text <> "" AndAlso IsNumeric(Me.ClientSearch_GridLookUpEdit.Text) = True Then
            Me.CUSTOMER_INFOBindingSource.CancelEdit()
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            ClientNrSearch = Me.ClientSearch_GridLookUpEdit.Text
            SplashScreenManager.Default.SetWaitFormCaption("Load Data for Customer Nr.: " & ClientNrSearch)
            Me.ClientSearch_GridLookUpEdit.Text = ClientNrSearch
            Me.CUSTOMER_INFOTableAdapter.FillByClientNr(Me.PSTOOLDataset.CUSTOMER_INFO, ClientNrSearch)
            NATIONAL_IDENTIFIERS_initData()
            NATIONAL_IDENTIFIERS_InitLookUp()
            LEGAL_CODES_initData()
            LEGAL_CODES_InitLookUp()
            LEGAL_PROCEEDINGS_initData()
            LEGAL_PROCEEDINGS_InitLookUp()
            ENTERPRISE_SIZE_initData()
            ENTERPRISE_SIZE_InitLookUp()
            NACE_BRANCH_CODES_initData()
            NACE_BRANCH_CODES_InitLookUp()
            SINGLE_CUSTOMER_CONTRACTS_LOAD()
            GROUP_DETAILS_LOAD()
            LOAD_ALL_RATINGS()
            'Get Client Status
            If IsDate(Me.ClosingDate_DateEdit.Text) = True Then
                Me.ClientStatus_lbl.Text = "CLOSED"
                Me.ClientStatus_lbl.BackColor = Color.Red
                Me.ClientStatus_lbl.ForeColor = Color.White
            ElseIf IsDate(Me.ClosingDate_DateEdit.Text) = False Then
                Me.ClientStatus_lbl.Text = "ACTIVE"
                Me.ClientStatus_lbl.BackColor = Color.Green
                Me.ClientStatus_lbl.ForeColor = Color.White
            End If
            PERSONAL_CUSTOMERS_FIELDS_VISIBILITY()
            ANACREDIT_CLIENTS_FIELDS_REQUIRED()
            If Me.NationalIdentifiers_SearchLookUpEdit.Text <> "" AndAlso Me.NationalIdentifiers_SearchLookUpEdit.Text.StartsWith("-").ToString = False Then
                Me.NationalIdentifier_TextEdit.ReadOnly = False
            End If
            SplashScreenManager.CloseForm(False)
        End If
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

    Private Sub XtraTabControl2_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles XtraTabControl2.SelectedPageChanged
        If Me.XtraTabControl2.SelectedTabPage Is Me.ADDITIONAL_DATAXtraTabPage Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PERSONAL_CUSTOMERS_FIELDS_VISIBILITY()
            ANACREDIT_CLIENTS_FIELDS_REQUIRED()
            SplashScreenManager.CloseForm(False)
        End If
    End Sub





    Private Sub AllCustomerContracts_GridView_DoubleClick(sender As Object, e As EventArgs) Handles AllCustomerContracts_GridView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then

            Dim ContractNr As String = view.GetRowCellValue(view.FocusedRowHandle, "Contract_Account").ToString
                If IsNothing(ContractNr) = False And IsNumeric(ContractNr) = True Then
                    Try
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Load Contract Details...")
                    GLOBAL_CLIENT_NR = Me.ClientNr_TextEdit.EditValue
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

    End Sub

    Private Sub MergedFromClientNr_TextEdit_DoubleClick(sender As Object, e As EventArgs) Handles MergedFromClientNr_TextEdit.DoubleClick
        If Me.MergedFromClientNr_TextEdit.Text <> Nothing Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Merged From...Customer Details...")
                GLOBAL_CLIENT_NR = Me.MergedFromClientNr_TextEdit.EditValue

                SplashScreenManager.CloseForm(False)
                Me.CustomerVG.Text = "Details for (Merged From) Client Nr. " & Me.MergedFromClientNr_TextEdit.EditValue
                Me.CustomerVG.ShowDialog()

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
    End Sub

    Private Sub MergedToClientNr_TextEdit_DoubleClick(sender As Object, e As EventArgs) Handles MergedToClientNr_TextEdit.DoubleClick
        If Me.MergedToClientNr_TextEdit.Text <> Nothing Then
            Try
                SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Load Merged To...Customer Details...")
                GLOBAL_CLIENT_NR = Me.MergedToClientNr_TextEdit.EditValue

                SplashScreenManager.CloseForm(False)
                Me.CustomerVG.Text = "Details for (Merged To) Client Nr. " & Me.MergedToClientNr_TextEdit.EditValue
                Me.CustomerVG.ShowDialog()

            Catch ex As Exception
                SplashScreenManager.CloseForm(False)
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If
    End Sub
End Class