﻿Imports System
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


Public Class Securities_Our

    Private BS_SecuritiesStatus As BindingSource
    Private BS_SectorSecurity As BindingSource
    Private BS_SectorCountry As BindingSource
    Private BS_Currency As BindingSource
    Private BS_All_Customers As BindingSource
    Private BS_Segment As BindingSource
    Private BS_CurveType As BindingSource

    Dim NewSec As New Securities_AddNewSecurity()


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

    Private Sub SECURITIES_OURBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.SECURITIES_OURBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)

    End Sub

    Private Sub Securities_Our_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Try
        '    '***********Save Changes****************
        '    If Me.SECURITIESDataset.HasChanges = True Then
        '        If MessageBox.Show("Should the Changes in our Securities be saved?", "SAVE CHANGES", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
        '            Me.Validate()
        '            Me.SECURITIES_OURBindingSource.EndEdit()
        '            Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)
        '        Else
        '            e.Cancel = False
        '        End If
        '    End If
        '    '****************************************
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    e.Cancel = True
        'End Try
    End Sub

    Private Sub Securities_Our_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Cancel_bbi.PerformClick()
        End If
    End Sub

    Private Sub Securities_Our_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LayoutControl1.Dock = DockStyle.Fill

        'AddHandler GridControl2.EmbeddedNavigator.ButtonClick, AddressOf GridControl2_EmbeddedNavigator_ButtonClick

        Me.LayoutControl1.Dock = DockStyle.Fill
        SECURITIES_STATUS_initData()
        SECURITIES_STATUS_InitLookUp()
        ALL_CUSTOMERS_initData()
        ALL_CUSTOMERS_InitLookUp()
        SECTOR_SECURITY_initData()
        SECTOR_SECURITY_InitLookUp()
        SECTOR_COUNTRY_initData()
        SECTOR_COUNTRY_InitLookUp()
        CURRENCIES_initData()
        CURRENCIES_InitLookUp()
        SEGMENT_RISK_WEIGHT_initData()
        SEGMENT_RISK_WEIGHT_InitLookUp()
        CURVE_TYPE_initData()
        CURVE_TYPE_InitLookUp()

        Me.SecuritiesStatus_BarEditItem.EditValue = CType(BS_SecuritiesStatus.Current, DataRowView).Item(0)

    End Sub

    Private Sub SECURITIES_STATUS_initData()
        Dim objCMD1 As SqlCommand = New SqlCommand("DECLARE @SELECTION_TABLE Table([ID] int IDENTITY(1,1) NOT NULL
                                                    ,[STATUS] nvarchar(max) NULL)
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT [STATUS]
                                                    FROM [SECURITIES_OUR]
                                                    WHERE STATUS is not NULL
                                                    GROUP BY STATUS
                                                    ORDER BY STATUS asc
                                                    INSERT INTO @SELECTION_TABLE
                                                    SELECT 'ALL' as 'STATUS'
                                                    select STATUS from @SELECTION_TABLE order by ID asc", conn)
        objCMD1.CommandTimeout = 50000
        Dim dbSecuritiesStatus As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        Try

            dbSecuritiesStatus.Fill(ds, "SECURITIES_STATUS")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_SecuritiesStatus = New BindingSource(ds, "SECURITIES_STATUS")
    End Sub
    Private Sub SECURITIES_STATUS_InitLookUp()
        Me.SecurityStatus_SearchLookUpEdit.DataSource = BS_SecuritiesStatus
        Me.SecurityStatus_SearchLookUpEdit.DisplayMember = "STATUS"
        Me.SecurityStatus_SearchLookUpEdit.ValueMember = "STATUS"
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

    Private Sub SEGMENT_RISK_WEIGHT_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [Parameter_CreditSpreadRisk_References] where  [ParameterNameGeneral] in ('Risk_Weight_by_Issuer_Rating_Class_and_Sector') and [ParameterStatus] in ('Y') order by ParameterNr asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbSegment As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbSegment.Fill(ds, "SEGMENT") 'NOSTRO_ACC_RECONCILIATIONS

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_Segment = New BindingSource(ds, "SEGMENT") 'NOSTRO_ACC_RECONCILIATIONS
    End Sub
    Private Sub SEGMENT_RISK_WEIGHT_InitLookUp()
        Me.Segment_SearchLookUpEdit.Properties.DataSource = BS_Segment
        Me.Segment_SearchLookUpEdit.Properties.DisplayMember = "ParameterValue1"
        Me.Segment_SearchLookUpEdit.Properties.ValueMember = "ParameterValue1"
    End Sub

    Private Sub CURVE_TYPE_initData()

        Dim objCMD1 As SqlCommand = New SqlCommand("SELECT * FROM [Parameter_CreditSpreadRisk_References] where  [ParameterNameGeneral] in ('Curve_Type') and [ParameterStatus] in ('Y') order by ParameterNr asc", conn)
        objCMD1.CommandTimeout = 5000
        Dim dbCurveType As SqlDataAdapter = New SqlDataAdapter(objCMD1)

        Dim ds As DataSet = New DataSet()
        'Dim dbLastReconciliations As SqlDataAdapter = New SqlDataAdapter("Select AccountNr_Internal as 'Nostro Account',CCY_IB as 'Currency',AccountName_Internal as 'Nostro Account Name',Max(ReconcileDate) as 'Last Reconcile Date' from NOSTRO_ACC_RECONCILIATIONS GROUP BY AccountNr_Internal,AccountName_Internal,CCY_IB order by  'Last Reconcile Date' desc", conn) '
        Try

            dbCurveType.Fill(ds, "CURVE_TYPE")

        Catch ex As System.Exception
            MsgBox(ex.Message)

        End Try
        BS_CurveType = New BindingSource(ds, "CURVE_TYPE")
    End Sub
    Private Sub CURVE_TYPE_InitLookUp()
        Me.CurveType_SearchLookUpEdit.Properties.DataSource = BS_CurveType
        Me.CurveType_SearchLookUpEdit.Properties.DisplayMember = "ParameterName1"
        Me.CurveType_SearchLookUpEdit.Properties.ValueMember = "ParameterName1"
    End Sub

    Private Sub CALCULATE_PAID_AMOUNTS()
        Dim PrincipalAmountOrigCur As Double = 0
        Dim PrincipalAmountEuro As Double = 0
        Dim PurchasePrice As Double = 1
        Dim AmountPaidOrigCur As Double = 0
        Dim AmountPaidEur As Double = 0
        Dim ExchangeRate As Double = 1
        If IsNumeric(Me.PrincipalAmount_TextEdit.Text) = True Then
            PrincipalAmountOrigCur = Me.PrincipalAmount_TextEdit.Text
        End If
        If IsNumeric(Me.PrincipalAmountEUR_TextEdit.Text) = True Then
            PrincipalAmountEuro = Me.PrincipalAmountEUR_TextEdit.Text
        End If
        If IsNumeric(Me.PurchasePrice_TextEdit.Text) = True Then
            PurchasePrice = Me.PurchasePrice_TextEdit.Text
        End If
        If IsNumeric(Me.ExchangeRate_TextEdit.Text) = True Then
            ExchangeRate = Me.ExchangeRate_TextEdit.Text
        End If
        AmountPaidOrigCur = Math.Round((PrincipalAmountOrigCur * PurchasePrice) / 100, 2)
        AmountPaidEur = Math.Round((PrincipalAmountEuro * PurchasePrice * ExchangeRate) / 100, 2)
        Me.AmountPaidOrigCur_TextEdit.Text = AmountPaidOrigCur
        Me.AmountPaidEuro_TextEdit.Text = AmountPaidEur

    End Sub


    Private Sub SecuritiesStatus_BarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles SecuritiesStatus_BarEditItem.EditValueChanged
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        If Me.SecuritiesStatus_BarEditItem.EditValue.ToString = "ALL" Then
            Me.SECURITIES_OURTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_OUR)
            Me.SecuritiesBaseView.ClearColumnsFilter()
        ElseIf Me.SecuritiesStatus_BarEditItem.EditValue.ToString <> "ALL" Then
            Me.SECURITIES_OURTableAdapter.FillBySecurityStatus(Me.SECURITIESDataset.SECURITIES_OUR, Me.SecuritiesStatus_BarEditItem.EditValue.ToString)
            Me.SecuritiesBaseView.ClearColumnsFilter()
        End If
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub SecurityStatus_SearchLookUpEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles SecurityStatus_SearchLookUpEdit.ButtonClick
        If e.Button.Tag = 2 Then
            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            If Me.SecuritiesStatus_BarEditItem.EditValue.ToString = "ALL" Then
                Me.SECURITIES_OURTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_OUR)
                Me.SecuritiesBaseView.ClearColumnsFilter()
            ElseIf Me.SecuritiesStatus_BarEditItem.EditValue.ToString <> "ALL" Then
                Me.SECURITIES_OURTableAdapter.FillBySecurityStatus(Me.SECURITIESDataset.SECURITIES_OUR, Me.SecuritiesStatus_BarEditItem.EditValue.ToString)
                Me.SecuritiesBaseView.ClearColumnsFilter()
            End If
            SplashScreenManager.CloseForm(False)
        End If
    End Sub

    Private Sub AddNewSecurity_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles AddNewSecurity_bbi.ItemClick
        Try

            Dim dxOK_NewSec As New DevExpress.XtraEditors.SimpleButton
            With dxOK_NewSec
                .Text = "Save new Security"
                .Height = 22
                .Width = 192
                .ImageList = NewSec.ImageCollection1
                .ImageIndex = 7
                .Location = New System.Drawing.Point(16, 614)
            End With

            NewSec.Controls.Add(dxOK_NewSec)
            NewSec.AddNewSecurity_btn.Visible = False

            AddHandler dxOK_NewSec.Click, AddressOf dxOK_NewSec_click

            NewSec.ShowDialog()

            'Code example for LayoutControlItem
            'NewDP.LayoutControlItem3.BeginInit()
            'Dim tempC As Control = NewDP.LayoutControlItem3.Control
            'NewDP.LayoutControlItem3.Control = dxOK_NewDP
            'tempC.Parent = Nothing
            'NewDP.LayoutControlItem3.EndInit()

        Catch ex As System.Exception
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End Try
    End Sub

    Private Sub dxOK_NewSec_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If NewSec.DxValidationProvider1.Validate() = True Then
            Try
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                Dim s As String = LTrim(RTrim(NewSec.ContractNr_TextEdit.Text))

                cmd.CommandText = "SELECT Count([ContractNrOCBS]) from [SECURITIES_OUR] where [ContractNrOCBS]='" & s & "'"
                Dim Result As Double = cmd.ExecuteScalar

                If Result = 0 Then
                    If MessageBox.Show("Should the Security contract be added to the Database?", "NEW SECURITY CONTRACT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                        Dim TRADE_DATE As Date = NewSec.Trade_DateEdit.EditValue
                        Dim START_DATE As Date = NewSec.Start_DateEdit.EditValue
                        Dim MATURITY_DATE As Date = NewSec.Maturity_DateEdit.EditValue

                        Dim PRINCIPAL_AMOUNT As Double = NewSec.PrincipalAmount_TextEdit.Text
                        Dim PRINCIPAL_EUR_AMOUNT As Double = NewSec.PrincipalAmountEUR_TextEdit.Text
                        Dim PURCHASE_PRICE As Double = NewSec.PurchasePrice_TextEdit.Text
                        Dim AMT_PAID_ORG As Double = NewSec.AmountPaidOrigCur_TextEdit.Text
                        Dim AMT_PAID_EUR As Double = NewSec.AmountPaidEuro_TextEdit.Text
                        Dim EXCHANGE_RATE As Double = NewSec.ExchangeRate_TextEdit.Text
                        Dim CONTRACT_NR As Double = NewSec.ContractNr_TextEdit.Text
                        Dim SEKTOR As Double = NewSec.Sektor_SearchLookUpEdit.Text
                        Dim SWAP_PRICE As Double = NewSec.SWAP_Price_TextEdit.Text
                        Dim FIXED_RATE_COUPON As Double = NewSec.FloatingRateCoupon_TextEdit.Text
                        Dim FLOATING_RATE_SPREAD As Double = NewSec.FloatingSpread_TextEdit.Text
                        Dim SEGMENT As Double = NewSec.Segment_SearchLookUpEdit.Text
                        Dim RISKWEIGHT_BP As Double = NewSec.RiskWeightBP_TextEdit.Text

                        cmd.CommandText = "INSERT INTO [SECURITIES_OUR]
                                          ([ISIN]
                                            ,[ClientNr]
                                            ,[SecurityName]
                                            ,[Currency]
                                            ,[PrincipalOrigAmt]
                                            ,[PrincipalEuroAmt]
                                            ,[Purchase_Price]
                                            ,[Amt_Paid]
                                            ,[Amt_Paid_Eur]
                                            ,ExchangeRate
                                            ,[ContractNrOCBS]
                                            ,[AssetType]
                                            ,[TradeDate]
                                            ,[StartDate]
                                            ,[MaturityDate]
                                            ,[Sektor]
                                            ,[SektorDescription]
                                            ,[SektorCountry]
                                            ,[Segment]
                                            ,[RatingClass]
                                            ,[Sector_RatingClass]
                                            ,[RiskWeight_BP]
                                            ,[CurveType]
                                            ,[CurveTypeDescription]
                                            ,[RIC]
                                            ,[Swap_Price]
                                            ,[industry]
                                            ,[Fixed rate coupon]
                                            ,[Floating(leg) spread ]
                                            ,[purchasing yield]
                                            ,[bond type]
                                            ,[with swap or not]
                                            ,[Moody-Rating]
                                            ,[S & P]
                                            ,[Fitch-Rating]
                                            ,[LastAction]
                                            ,[LastUpdateUser]
                                            ,[LastUpdateDate])
                                           VALUES
                                            (@ISIN
                                            ,@ClientNr
                                            ,@SecurityName
                                            ,@Currency
                                            ,@PrincipalOrigAmt
                                            ,@PrincipalEuroAmt
                                            ,@Purchase_Price
                                            ,@Amt_Paid
                                            ,@Amt_Paid_Eur
                                            ,@ExchangeRate
                                            ,@ContractNrOCBS
                                            ,@AssetType
                                            ,@TradeDate
                                            ,@StartDate
                                            ,@MaturityDate
                                            ,@Sektor
                                            ,@SektorDescription
                                            ,@SektorCountry
                                            ,@Segment
                                            ,@RatingClass
                                            ,@Sector_RatingClass
                                            ,@RiskWeight_BP
                                            ,@CurveType
                                            ,@CurveTypeDescription
                                            ,@RIC
                                            ,@Swap_Price
                                            ,@Industry
                                            ,@Fixed_rate_coupon
                                            ,@Floating_spread
                                            ,@purchasing_yield
                                            ,@bond_type
                                            ,@Swap_or_Not
                                            ,@Moody_Rating
                                            ,@SP,@Fitch_Rating
                                            ,@LastAction
                                            ,@LastUpdateUser
                                            ,@LastUpdateDate)"
                        cmd.Parameters.Add("@ISIN", SqlDbType.NVarChar).Value = NewSec.SecIsinCode_TextEdit.Text
                        cmd.Parameters.Add("@ClientNr", SqlDbType.NVarChar).Value = NewSec.ClientSearch_GridLookUpEdit.Text
                        cmd.Parameters.Add("@SecurityName", SqlDbType.NVarChar).Value = NewSec.ClientName_TextEdit.Text
                        cmd.Parameters.Add("@Currency", SqlDbType.NVarChar).Value = NewSec.Currency_SearchLookUpEdit.Text
                        cmd.Parameters.Add("@PrincipalOrigAmt", SqlDbType.Float).Value = PRINCIPAL_AMOUNT
                        cmd.Parameters.Add("@PrincipalEuroAmt", SqlDbType.Float).Value = PRINCIPAL_EUR_AMOUNT
                        cmd.Parameters.Add("@Purchase_Price", SqlDbType.Float).Value = PURCHASE_PRICE
                        cmd.Parameters.Add("@Amt_Paid", SqlDbType.Float).Value = AMT_PAID_ORG
                        cmd.Parameters.Add("@Amt_Paid_Eur", SqlDbType.Float).Value = AMT_PAID_EUR
                        cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = EXCHANGE_RATE
                        cmd.Parameters.Add("@ContractNrOCBS", SqlDbType.Float).Value = CONTRACT_NR
                        cmd.Parameters.Add("@AssetType", SqlDbType.NVarChar).Value = NewSec.AssetType_ImageComboBoxEdit.Text
                        cmd.Parameters.Add("@TradeDate", SqlDbType.DateTime).Value = TRADE_DATE
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = START_DATE
                        cmd.Parameters.Add("@MaturityDate", SqlDbType.DateTime).Value = MATURITY_DATE
                        cmd.Parameters.Add("@Sektor", SqlDbType.Float).Value = SEKTOR
                        cmd.Parameters.Add("@SektorDescription", SqlDbType.NVarChar).Value = NewSec.Sektor_Description_lbl.Text
                        cmd.Parameters.Add("@SektorCountry", SqlDbType.NVarChar).Value = NewSec.SektoCountry_SearchLookUpEdit.Text
                        cmd.Parameters.Add("@Segment", SqlDbType.Float).Value = SEGMENT
                        cmd.Parameters.Add("@RatingClass", SqlDbType.NVarChar).Value = NewSec.RatingClass_TextEdit.Text
                        cmd.Parameters.Add("@Sector_RatingClass", SqlDbType.NVarChar).Value = NewSec.RatingClass_TextEdit.Text
                        cmd.Parameters.Add("@RiskWeight_BP", SqlDbType.Float).Value = RISKWEIGHT_BP
                        cmd.Parameters.Add("@CurveType", SqlDbType.NVarChar).Value = NewSec.CurveType_SearchLookUpEdit.Text
                        cmd.Parameters.Add("@CurveTypeDescription", SqlDbType.NVarChar).Value = NewSec.CurveType_Description_lbl.Text
                        cmd.Parameters.Add("@RIC", SqlDbType.NVarChar).Value = NewSec.RIC_TextEdit.Text
                        cmd.Parameters.Add("@Fixed_rate_coupon", SqlDbType.Float).Value = FIXED_RATE_COUPON
                        cmd.Parameters.Add("@Swap_Price", SqlDbType.Float).Value = SWAP_PRICE
                        cmd.Parameters.Add("@Industry", SqlDbType.NVarChar).Value = NewSec.Industry_TextEdit.Text
                        cmd.Parameters.Add("@Floating_spread", SqlDbType.Float).Value = FLOATING_RATE_SPREAD
                        cmd.Parameters.Add("@purchasing_yield", SqlDbType.NVarChar).Value = NewSec.PurchasingYield_TextEdit.Text
                        cmd.Parameters.Add("@bond_type", SqlDbType.NVarChar).Value = NewSec.BondType_TextEdit.Text
                        cmd.Parameters.Add("@Swap_or_Not", SqlDbType.NVarChar).Value = NewSec.WithSwapNo_TextEdit.Text
                        cmd.Parameters.Add("@Moody_Rating", SqlDbType.NVarChar).Value = NewSec.MoodysRating_TextEdit.Text
                        cmd.Parameters.Add("@SP", SqlDbType.NVarChar).Value = NewSec.SP_Rating_TextEdit.Text
                        cmd.Parameters.Add("@Fitch_Rating", SqlDbType.NVarChar).Value = NewSec.FitchRating_TextEdit.Text
                        cmd.Parameters.Add("@LastAction", SqlDbType.NVarChar).Value = "ADD"
                        cmd.Parameters.Add("@LastUpdateUser", SqlDbType.NVarChar).Value = CurrentUserWindowsID
                        cmd.Parameters.Add("@LastUpdateDate", SqlDbType.DateTime).Value = Now
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()

                        NewSec.Close()
                        Me.SECURITIES_OURTableAdapter.FillBySecurityStatus(Me.SECURITIESDataset.SECURITIES_OUR, Me.SecuritiesStatus_BarEditItem.EditValue.ToString)
                    Else
                        Return
                    End If

                Else
                    XtraMessageBox.Show("There is alleady an Security with the same Contract Nr. in the Database", "DUPLICATE CONTRACT NR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()

                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return
            End Try
        End If

    End Sub

    Private Sub SaveChanges_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SaveChanges_bbi.ItemClick
        Try
            If Me.DxValidationProvider1.Validate() = True Then
                Me.LastAction_lbl.Text = "UPDATE"
                Me.LastUpdateUser_lbl.Text = CurrentUserWindowsID
                Me.LastUpdateDate_lbl.Text = Now
                Me.SECURITIES_OURBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.SECURITIESDataset)
                Me.LayoutControl1.Visible = True
                Me.RibbonPageGroup1.Visible = True
                If Me.SecuritiesStatus_BarEditItem.EditValue.ToString = "ALL" Then
                    Me.SECURITIES_OURTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_OUR)
                ElseIf Me.SecuritiesStatus_BarEditItem.EditValue.ToString <> "ALL" Then
                    Me.SECURITIES_OURTableAdapter.FillBySecurityStatus(Me.SECURITIESDataset.SECURITIES_OUR, Me.SecuritiesStatus_BarEditItem.EditValue.ToString)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return

        End Try
    End Sub

    Private Sub Cancel_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Cancel_bbi.ItemClick
        Me.SECURITIES_OURBindingSource.CancelEdit()
        Me.SECURITIESDataset.RejectChanges()
        Me.DxValidationProvider1.ValidationMode = DXErrorProvider.ValidationMode.Manual
        Dim controls As IList(Of Control) = DxValidationProvider1.GetInvalidControls()
        While controls.Count > 0
            DxValidationProvider1.RemoveControlError(controls(controls.Count - 1))
        End While
        Me.LayoutControl1.Visible = True
        Me.RibbonPageGroup1.Visible = True
        If Me.SecuritiesStatus_BarEditItem.EditValue.ToString = "ALL" Then
            Me.SECURITIES_OURTableAdapter.Fill(Me.SECURITIESDataset.SECURITIES_OUR)
        ElseIf Me.SecuritiesStatus_BarEditItem.EditValue.ToString <> "ALL" Then
            Me.SECURITIES_OURTableAdapter.FillBySecurityStatus(Me.SECURITIESDataset.SECURITIES_OUR, Me.SecuritiesStatus_BarEditItem.EditValue.ToString)
        End If

    End Sub

    Private Sub SecuritiesBaseView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles SecuritiesBaseView.CellValueChanged
        If e.Column.Caption = "Client Nr." Then
            Dim row As System.Data.DataRow = SecuritiesBaseView.GetDataRow(SecuritiesBaseView.FocusedRowHandle)
            Dim ClientNr As String = row(27)
            Dim ClientName As String = Nothing
            OpenSqlConnections()
            cmd.CommandText = "SELECT [English Name] from [CUSTOMER_INFO] where [ClientNo]='" & ClientNr & "' and [CLOSE_DATE] is NULL"
            If IsNothing(cmd.ExecuteScalar) = False Then
                ClientName = cmd.ExecuteScalar

                row(2) = ClientName

            Else
                row(2) = ""
                XtraMessageBox.Show("Client Nr. " & row(27) & " not found or deleted", "CLIENT NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            CloseSqlConnections()
        End If


        If e.Column.Caption = "Purchase Price" Then
            Dim row As System.Data.DataRow = SecuritiesBaseView.GetDataRow(SecuritiesBaseView.FocusedRowHandle)
            If IsNumeric(row(4)) = True And IsNumeric(row(5)) = True And IsNumeric(row(14)) = True Then
                row(15) = Math.Round(row(4) * row(14) / 100, 2)
            Else
                XtraMessageBox.Show("Please input the purchase price of the Security", "NO PURCHASE PRICE ENTERED", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                row(15) = ""
                Return

            End If
        End If

    End Sub

    Private Sub SecuritiesBaseView_DoubleClick(sender As Object, e As EventArgs) Handles SecuritiesBaseView.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        'Dim rowHandle As Integer = view.FocusedRowHandle
        'Dim ClientNr As String = view.GetRowCellValue(rowHandle, "ClientNr")
        'Dim Sektor As String = view.GetRowCellValue(rowHandle, "Sektor")
        'Dim SektoCountry As String = view.GetRowCellValue(rowHandle, "SektorCountry")

        If view.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            ALL_CUSTOMERS_initData()
            ALL_CUSTOMERS_InitLookUp()
            SECTOR_SECURITY_initData()
            SECTOR_SECURITY_InitLookUp()
            SECTOR_COUNTRY_initData()
            SECTOR_COUNTRY_InitLookUp()
            CURRENCIES_initData()
            CURRENCIES_InitLookUp()
            SEGMENT_RISK_WEIGHT_initData()
            SEGMENT_RISK_WEIGHT_InitLookUp()
            CURVE_TYPE_initData()
            CURVE_TYPE_InitLookUp()
            Me.LayoutControl1.Visible = False
            Me.DxValidationProvider1.ValidationMode = DXErrorProvider.ValidationMode.Auto
            Me.RibbonPageGroup1.Visible = False
            Me.SaveChanges_bbi.Visibility = BarItemVisibility.Always
            Me.Cancel_bbi.Visibility = BarItemVisibility.Always
            'Me.ClientSearch_GridLookUpEdit.Text = ClientNr
            'Me.Sektor_SearchLookUpEdit.Text = Sektor
            'Me.SektoCountry_SearchLookUpEdit.Text = SektoCountry
        End If
    End Sub

    Private Sub SecuritiesBaseView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles SecuritiesBaseView.InvalidRowException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub SecuritiesBaseView_InvalidValueException(sender As Object, e As InvalidValueExceptionEventArgs) Handles SecuritiesBaseView.InvalidValueException
        'Display Error in column
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
        'Show the message with the error text specified 
        MessageBox.Show(e.ErrorText, "Field Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub SecuritiesBaseView_RowStyle(sender As Object, e As RowStyleEventArgs) Handles SecuritiesBaseView.RowStyle
        If e.RowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            e.Appearance.BackColor = SystemColors.InactiveCaptionText
        End If
    End Sub

    Private Sub SecuritiesBaseView_ShownEditor(sender As Object, e As EventArgs) Handles SecuritiesBaseView.ShownEditor
        Dim view As GridView = CType(sender, GridView)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            view.ActiveEditor.Properties.Appearance.BackColor = Color.Yellow
            view.ActiveEditor.Properties.Appearance.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SecuritiesBaseView_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles SecuritiesBaseView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim ISIN_NR As GridColumn = View.Columns("ISIN")
        Dim CLIENT_NR As GridColumn = View.Columns("ClientNr")
        Dim SECURITY_NAME As GridColumn = View.Columns("SecurityName")
        Dim CURRENCY As GridColumn = View.Columns("Currency")
        Dim PRINCIPAL_ORIG_AMT As GridColumn = View.Columns("PrincipalOrigAmt")
        Dim PRINCIPAL_EURO_AMT As GridColumn = View.Columns("PrincipalEuroAmt")
        Dim PURCHASE_PRICE As GridColumn = View.Columns("Purchase_Price")
        Dim CONTRACT_OCBS As GridColumn = View.Columns("ContractNrOCBS")
        Dim ASSETS_TYPE As GridColumn = View.Columns("AssetType")
        Dim TRADE_DATE As GridColumn = View.Columns("TradeDate")
        Dim START_DATE As GridColumn = View.Columns("StartDate")
        Dim MATURITY_DATE As GridColumn = View.Columns("MaturityDate")
        Dim SEKTOR As GridColumn = View.Columns("Sektor")
        Dim SEKTOR_COUNTRY As GridColumn = View.Columns("SektorCountry")
        Dim STATUS As GridColumn = View.Columns("Status")

        Dim IsinNr As String = View.GetRowCellValue(e.RowHandle, colISIN).ToString
        Dim ClientNr As String = View.GetRowCellValue(e.RowHandle, colClientNr).ToString
        Dim SecurityName As String = View.GetRowCellValue(e.RowHandle, colSecurityName).ToString
        Dim CUR As String = View.GetRowCellValue(e.RowHandle, colCurrency).ToString
        Dim PrincipalOriginalAmt As String = View.GetRowCellValue(e.RowHandle, colPrincipalOrigAmt).ToString
        Dim PrincipalEuroAmt As String = View.GetRowCellValue(e.RowHandle, colPrincipalEuroAmt).ToString
        Dim ContractOCBS As String = View.GetRowCellValue(e.RowHandle, colContractNrOCBS).ToString
        Dim PricePurchase As String = View.GetRowCellValue(e.RowHandle, colPurchase_Price).ToString
        Dim AssetsType As String = View.GetRowCellValue(e.RowHandle, colAssetType).ToString
        Dim TradeDate As String = View.GetRowCellValue(e.RowHandle, colTradeDate).ToString
        Dim StartDate As String = View.GetRowCellValue(e.RowHandle, colStartDate).ToString
        Dim MaturityDate As String = View.GetRowCellValue(e.RowHandle, colMaturityDate).ToString
        Dim Sector As String = View.GetRowCellValue(e.RowHandle, colSektor).ToString
        Dim SectorCountry As String = View.GetRowCellValue(e.RowHandle, colSektorCountry).ToString
        Dim StatusSec As String = View.GetRowCellValue(e.RowHandle, colSTATUS).ToString

        If IsinNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ISIN_NR, "The ISIN Nr must not be empty")
            e.ErrorText = "The ISIN Nr must not be empty"
        End If
        If ClientNr = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CLIENT_NR, "The Client Nr must not be empty")
            e.ErrorText = "The Client Nr must not be empty"
        End If
        If SecurityName = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SECURITY_NAME, "The Security Name must not be empty")
            e.ErrorText = "The Security Name must not be empty"
        End If
        If CUR = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CURRENCY, "The Currency must not be empty")
            e.ErrorText = "The Currency must not be empty"
        End If
        If PrincipalOriginalAmt = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PRINCIPAL_ORIG_AMT, "The Amount must not be empty")
            e.ErrorText = "The Amount must not be empty"
        End If
        If PrincipalEuroAmt = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PRINCIPAL_EURO_AMT, "The Amount must not be empty")
            e.ErrorText = "The Amount must not be empty"
        End If
        If PricePurchase = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(PURCHASE_PRICE, "The Purchase Price must not be empty")
            e.ErrorText = "The Purchase Price must not be empty"
        End If
        If ContractOCBS = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(CONTRACT_OCBS, "The OCBS Contract Nr. must not be empty")
            e.ErrorText = "The OCBS Contract Nr. must not be empty"
        End If
        If AssetsType = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(ASSETS_TYPE, "The Assets Type must not be empty")
            e.ErrorText = "The Assets Type must not be empty"
        End If
        If TradeDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(TRADE_DATE, "The Trade Date must not be empty")
            e.ErrorText = "The Trade Date must not be empty"
        End If
        If StartDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(START_DATE, "The Start Date must not be empty")
            e.ErrorText = "The Start Date must not be empty"
        End If
        If MaturityDate = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(MATURITY_DATE, "The Maturity Date must not be empty")
            e.ErrorText = "The Maturity Date must not be empty"
        End If
        If Sector = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SEKTOR, "The Sektor must not be empty")
            e.ErrorText = "The Sektor must not be empty"
        End If
        If SectorCountry = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(SEKTOR_COUNTRY, "The Sektor Country must not be empty")
            e.ErrorText = "The Sektor Country must not be empty"
        End If
        If StatusSec = "" Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(STATUS, "The Status of the Security must not be empty")
            e.ErrorText = "The Status of the Security must not be empty"
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
        Dim reportfooter As String = "OUR SECURITIES - " & Me.SecuritiesStatus_BarEditItem.EditValue.ToString & " - " & "Printed on: " & Now
        e.Graph.DrawString(reportfooter, New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 20))
    End Sub


    Private Sub LayoutControl1_VisibleChanged(sender As Object, e As EventArgs) Handles LayoutControl1.VisibleChanged
        If Me.LayoutControl1.Visible = False Then
            Me.SaveChanges_bbi.Visibility = BarItemVisibility.Always
            Me.Cancel_bbi.Visibility = BarItemVisibility.Always
            If Me.Status_ImageComboBoxEdit.Text = "EXPIRED" Then
                Me.DxValidationProvider1.ValidationMode = DXErrorProvider.ValidationMode.Manual
                For Each c As Control In Me.GroupControl1.Controls
                    If c.GetType Is GetType(DevExpress.XtraEditors.TextEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.TextEdit).Properties.ReadOnly = True
                    End If
                    If c.GetType Is GetType(DevExpress.XtraEditors.ImageComboBoxEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.ImageComboBoxEdit).Properties.ReadOnly = True
                    End If
                    If c.GetType Is GetType(DevExpress.XtraEditors.DateEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.DateEdit).Properties.ReadOnly = True
                    End If
                    If c.GetType Is GetType(DevExpress.XtraEditors.SearchLookUpEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.SearchLookUpEdit).Properties.ReadOnly = True
                    End If
                Next
                For Each c As Control In Me.GroupControl2.Controls
                    If c.GetType Is GetType(DevExpress.XtraEditors.SearchLookUpEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.SearchLookUpEdit).Properties.ReadOnly = False
                    End If
                Next
                'Me.GroupControl1.Enabled = False
            Else

                Me.DxValidationProvider1.ValidationMode = DXErrorProvider.ValidationMode.Auto
                For Each c As Control In Me.GroupControl1.Controls
                    If c.GetType Is GetType(DevExpress.XtraEditors.TextEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.TextEdit).Properties.ReadOnly = False
                    End If
                    If c.GetType Is GetType(DevExpress.XtraEditors.ImageComboBoxEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.ImageComboBoxEdit).Properties.ReadOnly = False
                    End If
                    If c.GetType Is GetType(DevExpress.XtraEditors.DateEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.DateEdit).Properties.ReadOnly = False
                    End If
                    If c.GetType Is GetType(DevExpress.XtraEditors.SearchLookUpEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.SearchLookUpEdit).Properties.ReadOnly = False
                    End If
                Next
                For Each c As Control In Me.GroupControl2.Controls
                    If c.GetType Is GetType(DevExpress.XtraEditors.SearchLookUpEdit) Then
                        DirectCast(c, DevExpress.XtraEditors.SearchLookUpEdit).Properties.ReadOnly = False
                    End If
                Next
                'Me.GroupControl1.Enabled = True
            End If
        ElseIf Me.LayoutControl1.Visible = True Then
            Me.SaveChanges_bbi.Visibility = BarItemVisibility.Never
            Me.Cancel_bbi.Visibility = BarItemVisibility.Never
        End If
    End Sub

    Private Sub ClientSearch_GridLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ClientSearch_GridLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
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
        End If

    End Sub

    Private Sub Sektor_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Sektor_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.Sektor_SearchLookUpEdit.EditValue.ToString <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim SectorRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.Sektor_Description_lbl.Text = SectorRow("SQL_Name_2").ToString

            Else
                Me.Sektor_Description_lbl.Text = ""
            End If
        End If

    End Sub

    Private Sub Segment_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles Segment_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.Segment_SearchLookUpEdit.EditValue.ToString <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim SegmentRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.RatingClass_TextEdit.Text = SegmentRow("ParameterName1").ToString
                Me.SectorRW_TextEdit.Text = SegmentRow("ParameterName2").ToString
                Me.RiskWeightBP_TextEdit.Text = SegmentRow("ParameterValue2").ToString
            Else
                Me.RatingClass_TextEdit.Text = ""
                Me.SectorRW_TextEdit.Text = ""
                Me.RiskWeightBP_TextEdit.Text = ""
            End If
        End If
    End Sub

    Private Sub CurveType_SearchLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CurveType_SearchLookUpEdit.EditValueChanged
        If Me.LayoutControl1.Visible = False Then
            If Me.CurveType_SearchLookUpEdit.EditValue.ToString <> "" Then

                Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
                Dim CurveTypeRow As DataRowView = CType(editor.Properties.GetRowByKeyValue(editor.EditValue), DataRowView)
                Me.CurveType_Description_lbl.Text = CurveTypeRow("ParameterName2").ToString

            Else
                Me.CurveType_Description_lbl.Text = ""

            End If
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

    Private Sub ExchangeRate_TextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ExchangeRate_TextEdit.EditValueChanged
        CALCULATE_PAID_AMOUNTS()
    End Sub

    Private Sub PrintExport_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PrintExport_bbi.ItemClick
        If Me.LayoutControl1.Visible = True Then
            If Not GridControl2.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error")
                Return
            End If
            ' Opens the Preview window. 
            'GridControl1.ShowPrintPreview()

            SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
            PrintableComponentLink1.CreateDocument()
            PrintableComponentLink1.ShowPreview()
            SplashScreenManager.CloseForm(False)
        ElseIf Me.LayoutControl1.Visible = False Then
            Dim AllSecuritiesDs As New SECURITIESDataset
            Dim AllSecuritiesAdapter As New SECURITIESDatasetTableAdapters.SECURITIES_OURTableAdapter
            AllSecuritiesAdapter.FillByContractNr(AllSecuritiesDs.SECURITIES_OUR, Me.ContractNr_TextEdit.Text)
            Dim report As New SecurityContractSingle
            report.DataSource = AllSecuritiesDs
            report.DataMember = AllSecuritiesDs.SECURITIES_OUR.TableName
            Dim c As New DevReportViewer
            c.Text = "Security Contract: " & Me.ContractNr_TextEdit.Text
            c.MdiParent = Me.MdiParent
            c.DocumentViewer1.DocumentSource = report
            c.Show()
        End If

    End Sub

    Private Sub Close_bbi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Close_bbi.ItemClick
        Me.SECURITIES_OURBindingSource.CancelEdit()
        Me.SECURITIESDataset.RejectChanges()
        Me.DxValidationProvider1.ValidationMode = DXErrorProvider.ValidationMode.Manual
        Dim controls As IList(Of Control) = DxValidationProvider1.GetInvalidControls()
        While controls.Count > 0
            DxValidationProvider1.RemoveControlError(controls(controls.Count - 1))
        End While
        Me.Close()

    End Sub


End Class