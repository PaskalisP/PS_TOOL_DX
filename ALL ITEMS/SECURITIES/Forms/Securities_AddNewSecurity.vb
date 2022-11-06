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
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing
Public Class Securities_AddNewSecurity

    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand

    Private QueryText As String = ""
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private da1 As New SqlDataAdapter
    Private dt1 As New DataTable

    Private BS_SectorSecurity As BindingSource
    Private BS_SectorCountry As BindingSource
    Private BS_Currency As BindingSource
    Private BS_All_Customers As BindingSource

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

    Private Sub Securities_AddNewSecurity_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Securities_AddNewSecurity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = My.Settings.PS_TOOL_DX_SQL_Client_ConnectionString
        cmd.Connection = conn
        ALL_CUSTOMERS_initData()
        ALL_CUSTOMERS_InitLookUp()
        SECTOR_SECURITY_initData()
        SECTOR_SECURITY_InitLookUp()
        SECTOR_COUNTRY_initData()
        SECTOR_COUNTRY_InitLookUp()
        CURRENCIES_initData()
        CURRENCIES_InitLookUp()

    End Sub

    Private Sub SECTOR_SECURITY_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [SQL_PARAMETER_DETAILS_SECOND] where  [Id_SQL_Parameters_Details] in (Select [ID] from [SQL_PARAMETER_DETAILS] where [SQL_Name_1] in ('SECTOR_SECURITY')) and [Status] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbSectorSecurity As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbSectorSecurity.Fill(ds, "SECTOR_SECURITY") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_SectorSecurity = New BindingSource(ds, "SECTOR_SECURITY") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub SECTOR_SECURITY_InitLookUp()
        Me.Sektor_SearchLookUpEdit.Properties.DataSource = BS_SectorSecurity
        Me.Sektor_SearchLookUpEdit.Properties.DisplayMember = "SQL_Name_1"
        Me.Sektor_SearchLookUpEdit.Properties.ValueMember = "SQL_Name_1"
    End Sub

    Private Sub SECTOR_COUNTRY_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [COUNTRIES] where  [VALID] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbSectorCountry As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbSectorCountry.Fill(ds, "COUNTRIES") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_SectorCountry = New BindingSource(ds, "COUNTRIES") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub SECTOR_COUNTRY_InitLookUp()
        Me.SektoCountry_SearchLookUpEdit.Properties.DataSource = BS_SectorCountry
        Me.SektoCountry_SearchLookUpEdit.Properties.DisplayMember = "COUNTRY CODE"
        Me.SektoCountry_SearchLookUpEdit.Properties.ValueMember = "COUNTRY CODE"
    End Sub

    Private Sub CURRENCIES_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [OWN_CURRENCIES] where  [VALID] in ('Y') order by ID asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbCurrency As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbCurrency.Fill(ds, "OWN_CURRENCIES") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Currency = New BindingSource(ds, "OWN_CURRENCIES") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub

    Private Sub CURRENCIES_InitLookUp()
        Me.Currency_SearchLookUpEdit.Properties.DataSource = BS_Currency
        Me.Currency_SearchLookUpEdit.Properties.DisplayMember = "CURRENCY CODE"
        Me.Currency_SearchLookUpEdit.Properties.ValueMember = "CURRENCY CODE"
    End Sub

    Private Sub ALL_CUSTOMERS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT [ClientNo],[ClientType],[English Name],[CLOSE_DATE] FROM [CUSTOMER_INFO] ORDER BY CASE WHEN CLOSE_DATE IS NULL THEN 1 WHEN CLOSE_DATE IS NOT NULL THEN 2 END, ClientNo", conn)
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

    Private Sub CALCULATE_PAID_AMOUNTS()
        Dim PrincipalAmountOrigCur As Double = 0
        Dim PrincipalAmountEuro As Double = 0
        Dim PurchasePrice As Double = 1
        Dim AmountPaidOrigCur As Double = 0
        Dim AmountPaidEur As Double = 0
        If IsNumeric(Me.PrincipalAmount_TextEdit.Text) = True Then
            PrincipalAmountOrigCur = Me.PrincipalAmount_TextEdit.Text
        End If
        If IsNumeric(Me.PrincipalAmountEUR_TextEdit.Text) = True Then
            PrincipalAmountEuro = Me.PrincipalAmountEUR_TextEdit.Text
        End If
        If IsNumeric(Me.PurchasePrice_TextEdit.Text) = True Then
            PurchasePrice = Me.PurchasePrice_TextEdit.Text
        End If
        AmountPaidOrigCur = Math.Round((PrincipalAmountOrigCur * PurchasePrice) / 100, 2)
        AmountPaidEur = Math.Round((PrincipalAmountEuro * PurchasePrice) / 100, 2)
        Me.AmountPaidOrigCur_TextEdit.Text = AmountPaidOrigCur
        Me.AmountPaidEuro_TextEdit.Text = AmountPaidEur

    End Sub

  

    Private Sub ClientSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.EditValueChanged
        If Me.ClientSearch_GridLookUpEdit.EditValue.ToString <> "" Then

            'SearchLookUpEdit1View
            'Dim view As GridView = ClientSearch_GridLookUpEdit.Properties.View
            'Dim rowHandle As Integer = view.FocusedRowHandle
            'Me.ClientName_TextEdit.Text = view.GetRowCellValue(rowHandle, "English Name")

            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim ClientRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.ClientName_TextEdit.Text = ClientRow("English Name").ToString

        Else
            Me.ClientName_TextEdit.Text = ""
        End If
    End Sub

    Private Sub Sektor_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Sektor_SearchLookUpEdit.EditValueChanged
        If Me.Sektor_SearchLookUpEdit.EditValue.ToString <> "" Then

            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim SectorRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.Sektor_Description_lbl.Text = SectorRow("SQL_Name_2").ToString

        Else
            Me.Sektor_Description_lbl.Text = ""
        End If
    End Sub

    Private Sub SektoCountry_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SektoCountry_SearchLookUpEdit.EditValueChanged
        If Me.SektoCountry_SearchLookUpEdit.EditValue.ToString <> "" Then

            Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            Dim SectorCountryRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
            Me.SektorCountry_Description_lbl.Text = SectorCountryRow("COUNTRY NAME").ToString

        Else
            Me.SektorCountry_Description_lbl.Text = ""
        End If
    End Sub

    Private Sub PrincipalAmount_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PrincipalAmount_TextEdit.EditValueChanged
        CALCULATE_PAID_AMOUNTS()
    End Sub

    Private Sub PrincipalAmountEUR_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PrincipalAmountEUR_TextEdit.EditValueChanged
        CALCULATE_PAID_AMOUNTS()
    End Sub

    Private Sub PurchasePrice_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PurchasePrice_TextEdit.EditValueChanged
        CALCULATE_PAID_AMOUNTS()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub
End Class