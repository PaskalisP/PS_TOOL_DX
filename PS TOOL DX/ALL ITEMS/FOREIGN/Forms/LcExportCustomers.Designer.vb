<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LcExportCustomers
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Label3 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim ID_lbl As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LcExportCustomers))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.EXPORT_LC_CUSTOMERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LcDataset = New PS_TOOL_DX.LcDataset()
        Me.ExportLc_Conditions_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionCyclus1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.colConditionType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionPercent1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNotes3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CustomerNotes_RepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colIdExportLcCustomers1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionMin1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionMax1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ExportLc_BankDetails_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountConnection1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SettlementStatusRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colAccountHolder1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBAN_CCY1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBAN_NR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBIC1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox7 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colNotes4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdExportLcCustomers3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExportLc_Customers_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerAddress1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerAddress2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerZipCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerFon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerFax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerWebsite = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactPerson1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactPerson2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLcAdviceEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BICCODERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CurrencyRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.AmountRepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ClientName_lbl = New System.Windows.Forms.Label()
        Me.EXPORT_LC_CUSTOMERSTableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_CUSTOMERSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager()
        Me.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter()
        Me.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter()
        Me.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ViewEdit_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Print_Export_GridView_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.City_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.CustomerID_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.CustomerName_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Name2_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Adress2_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ZipCode_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Tel_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Fax_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Email_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Web_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.Contact1_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.Contact2_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LC_Advice_Email_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.Notes_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.Save_SimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ShowAllCustomers_SimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.CUSTOMER_INFOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.CUSTOMER_INFOTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.CUSTOMER_INFOTableAdapter()
        Me.TableAdapterManager1 = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.M8_AdviceCharges_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.ClientNrOCBS_GridLookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Conditions_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colConditionName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colConditionCyclus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colConditionPercent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colConditionMin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colConditionMax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNotes2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colIdExportLcCustomers = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox4 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.DiscountConditions_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankDetails_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccountConnection = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox5 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colAccountHolder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colIBAN_CCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colIBAN_NR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colBIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox6 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colNotes1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colIdExportLcCustomers2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemDateEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemMemoExEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExportCollectionConditions_GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox3 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox8 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox9 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemDateEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemTextEdit10 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ExportCollection_Conditions_BaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Label3 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        ID_lbl = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label19 = New System.Windows.Forms.Label()
        CType(Me.EXPORT_LC_CUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLc_Conditions_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerNotes_RepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLc_BankDetails_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLc_Customers_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.City_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerID_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Name2_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Adress2_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZipCode_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tel_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fax_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Email_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Web_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Contact1_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Contact2_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LC_Advice_Email_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Notes_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUSTOMER_INFOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.M8_AdviceCharges_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientNrOCBS_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Conditions_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiscountConditions_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankDetails_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportCollectionConditions_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit4.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportCollection_Conditions_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(90, 49)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(44, 14)
        Label3.TabIndex = 4
        Label3.Text = "Name:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(2, 71)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(132, 14)
        Label1.TabIndex = 6
        Label1.Text = "Name 2 / Address 1:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(62, 94)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(72, 14)
        Label2.TabIndex = 8
        Label2.Text = "Address 2:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(70, 118)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(64, 14)
        Label4.TabIndex = 10
        Label4.Text = "Zip Code:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(99, 142)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(35, 14)
        Label5.TabIndex = 12
        Label5.Text = "City:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(112, 24)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(25, 14)
        Label6.TabIndex = 0
        Label6.Text = "ID:"
        '
        'ID_lbl
        '
        ID_lbl.AutoSize = True
        ID_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "ID", True))
        ID_lbl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ID_lbl.Location = New System.Drawing.Point(144, 24)
        ID_lbl.Name = "ID_lbl"
        ID_lbl.Size = New System.Drawing.Size(21, 14)
        ID_lbl.TabIndex = 1
        ID_lbl.Text = "ID"
        '
        'EXPORT_LC_CUSTOMERSBindingSource
        '
        Me.EXPORT_LC_CUSTOMERSBindingSource.DataMember = "EXPORT_LC_CUSTOMERS"
        Me.EXPORT_LC_CUSTOMERSBindingSource.DataSource = Me.LcDataset
        '
        'LcDataset
        '
        Me.LcDataset.DataSetName = "LcDataset"
        Me.LcDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(368, 21)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(88, 14)
        Label7.TabIndex = 2
        Label7.Text = "Customer ID:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(102, 167)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(32, 14)
        Label8.TabIndex = 14
        Label8.Text = "Tel.:"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(100, 193)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(35, 14)
        Label9.TabIndex = 16
        Label9.Text = "Fax.:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(83, 219)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(51, 14)
        Label10.TabIndex = 18
        Label10.Text = "E-Mail.:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label11.Location = New System.Drawing.Point(91, 471)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(42, 14)
        Label11.TabIndex = 24
        Label11.Text = "Web.:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label12.Location = New System.Drawing.Point(61, 496)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(72, 14)
        Label12.TabIndex = 26
        Label12.Text = "Contact 1:"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.Location = New System.Drawing.Point(62, 560)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(72, 14)
        Label13.TabIndex = 28
        Label13.Text = "Contact 2:"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label14.Location = New System.Drawing.Point(29, 244)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(105, 14)
        Label14.TabIndex = 20
        Label14.Text = "LC Advice Email:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label15.Location = New System.Drawing.Point(70, 622)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(46, 14)
        Label15.TabIndex = 37
        Label15.Text = "Notes:"
        '
        'Label16
        '
        Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label16.AutoSize = True
        Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label16.Location = New System.Drawing.Point(766, 23)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(158, 14)
        Label16.TabIndex = 30
        Label16.Text = "Client Nr. (Core System):"
        '
        'Label19
        '
        Label19.AutoSize = True
        Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label19.Location = New System.Drawing.Point(31, 313)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(103, 70)
        Label19.TabIndex = 22
        Label19.Text = "LC Advice via " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DTAEA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Advising Banks " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Charges" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Field M8):"
        Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ExportLc_Conditions_BaseView
        '
        Me.ExportLc_Conditions_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID3, Me.colConditionName1, Me.colConditionCyclus1, Me.colConditionType, Me.colConditionPercent1, Me.colNotes3, Me.colIdExportLcCustomers1, Me.colConditionMin1, Me.colConditionMax1})
        Me.ExportLc_Conditions_BaseView.GridControl = Me.GridControl2
        Me.ExportLc_Conditions_BaseView.Name = "ExportLc_Conditions_BaseView"
        Me.ExportLc_Conditions_BaseView.OptionsBehavior.ReadOnly = True
        Me.ExportLc_Conditions_BaseView.OptionsView.ColumnAutoWidth = False
        Me.ExportLc_Conditions_BaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportLc_Conditions_BaseView.OptionsView.ShowGroupPanel = False
        Me.ExportLc_Conditions_BaseView.ViewCaption = "Export LC Conditions"
        '
        'colID3
        '
        Me.colID3.FieldName = "ID"
        Me.colID3.Name = "colID3"
        '
        'colConditionName1
        '
        Me.colConditionName1.Caption = "Condition Name"
        Me.colConditionName1.FieldName = "ConditionName"
        Me.colConditionName1.Name = "colConditionName1"
        Me.colConditionName1.Visible = True
        Me.colConditionName1.VisibleIndex = 0
        Me.colConditionName1.Width = 185
        '
        'colConditionCyclus1
        '
        Me.colConditionCyclus1.Caption = "Cyclus"
        Me.colConditionCyclus1.ColumnEdit = Me.RepositoryItemImageComboBox2
        Me.colConditionCyclus1.FieldName = "ConditionCyclus"
        Me.colConditionCyclus1.Name = "colConditionCyclus1"
        Me.colConditionCyclus1.Visible = True
        Me.colConditionCyclus1.VisibleIndex = 1
        Me.colConditionCyclus1.Width = 122
        '
        'RepositoryItemImageComboBox2
        '
        Me.RepositoryItemImageComboBox2.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox2.AutoHeight = False
        Me.RepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.RepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("RECURRENT", "R", 21), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NON-RECURRENT", "N", 20)})
        Me.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2"
        Me.RepositoryItemImageComboBox2.SmallImages = Me.ImageCollection1
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "DisplayDetail.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "DisplayAll.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "NonValid.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "Valid.ico")
        Me.ImageCollection1.Images.SetKeyName(5, "Report.ico")
        Me.ImageCollection1.Images.SetKeyName(6, "Paid.ico")
        Me.ImageCollection1.Images.SetKeyName(7, "Pending.ico")
        Me.ImageCollection1.InsertGalleryImage("paste_16x16.png", "images/edit/paste_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/paste_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "paste_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 9)
        Me.ImageCollection1.Images.SetKeyName(9, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("delete_16x16.png", "images/edit/delete_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_16x16.png"), 10)
        Me.ImageCollection1.Images.SetKeyName(10, "delete_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 11)
        Me.ImageCollection1.Images.SetKeyName(11, "save_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("grid_16x16.png", "images/grid/grid_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/grid/grid_16x16.png"), 12)
        Me.ImageCollection1.Images.SetKeyName(12, "grid_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("find_16x16.png", "images/find/find_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/find_16x16.png"), 13)
        Me.ImageCollection1.Images.SetKeyName(13, "find_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 14)
        Me.ImageCollection1.Images.SetKeyName(14, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 15)
        Me.ImageCollection1.Images.SetKeyName(15, "cancel_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(16, "refreshallpivottable_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(17, "download_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(18, "percentstyle_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(19, "number_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(20, "stop_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(21, "recurrence_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(22, "insertpagebreaks_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(23, "stretch_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(24, "Internal.png")
        Me.ImageCollection1.Images.SetKeyName(25, "External.png")
        '
        'colConditionType
        '
        Me.colConditionType.FieldName = "ConditionType"
        Me.colConditionType.Name = "colConditionType"
        '
        'colConditionPercent1
        '
        Me.colConditionPercent1.Caption = "Percentage"
        Me.colConditionPercent1.DisplayFormat.FormatString = "p4"
        Me.colConditionPercent1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colConditionPercent1.FieldName = "ConditionPercent"
        Me.colConditionPercent1.Name = "colConditionPercent1"
        Me.colConditionPercent1.Visible = True
        Me.colConditionPercent1.VisibleIndex = 2
        Me.colConditionPercent1.Width = 87
        '
        'colNotes3
        '
        Me.colNotes3.ColumnEdit = Me.CustomerNotes_RepositoryItemMemoExEdit
        Me.colNotes3.FieldName = "Notes"
        Me.colNotes3.Name = "colNotes3"
        Me.colNotes3.Visible = True
        Me.colNotes3.VisibleIndex = 5
        '
        'CustomerNotes_RepositoryItemMemoExEdit
        '
        Me.CustomerNotes_RepositoryItemMemoExEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CustomerNotes_RepositoryItemMemoExEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerNotes_RepositoryItemMemoExEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CustomerNotes_RepositoryItemMemoExEdit.Appearance.Options.UseBackColor = True
        Me.CustomerNotes_RepositoryItemMemoExEdit.Appearance.Options.UseForeColor = True
        Me.CustomerNotes_RepositoryItemMemoExEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CustomerNotes_RepositoryItemMemoExEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerNotes_RepositoryItemMemoExEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CustomerNotes_RepositoryItemMemoExEdit.AppearanceFocused.Options.UseBackColor = True
        Me.CustomerNotes_RepositoryItemMemoExEdit.AppearanceFocused.Options.UseForeColor = True
        Me.CustomerNotes_RepositoryItemMemoExEdit.AutoHeight = False
        Me.CustomerNotes_RepositoryItemMemoExEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CustomerNotes_RepositoryItemMemoExEdit.Name = "CustomerNotes_RepositoryItemMemoExEdit"
        Me.CustomerNotes_RepositoryItemMemoExEdit.PopupFormSize = New System.Drawing.Size(600, 500)
        Me.CustomerNotes_RepositoryItemMemoExEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colIdExportLcCustomers1
        '
        Me.colIdExportLcCustomers1.FieldName = "IdExportLcCustomers"
        Me.colIdExportLcCustomers1.Name = "colIdExportLcCustomers1"
        '
        'colConditionMin1
        '
        Me.colConditionMin1.Caption = "Min."
        Me.colConditionMin1.DisplayFormat.FormatString = "c2"
        Me.colConditionMin1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colConditionMin1.FieldName = "ConditionMin"
        Me.colConditionMin1.Name = "colConditionMin1"
        Me.colConditionMin1.Visible = True
        Me.colConditionMin1.VisibleIndex = 3
        '
        'colConditionMax1
        '
        Me.colConditionMax1.Caption = "Max."
        Me.colConditionMax1.DisplayFormat.FormatString = "c2"
        Me.colConditionMax1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colConditionMax1.FieldName = "ConditionMax"
        Me.colConditionMax1.Name = "colConditionMax1"
        Me.colConditionMax1.Visible = True
        Me.colConditionMax1.VisibleIndex = 4
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.EXPORT_LC_CUSTOMERSBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Hint = "Add new Maturity"
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Hint = "Save"
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Hint = "Delete Maturity"
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, True, "Add new Customer", "AddNewCustomer")})
        GridLevelNode1.LevelTemplate = Me.ExportLc_Conditions_BaseView
        GridLevelNode1.RelationName = "FK_EXPORT_LC_CUSTOMERS_Conditions_EXPORT_LC_CUSTOMERS"
        GridLevelNode2.LevelTemplate = Me.ExportLc_BankDetails_BaseView
        GridLevelNode2.RelationName = "FK_EXPORT_LC_CUSTOMERS_BankDetails_EXPORT_LC_CUSTOMERS"
        GridLevelNode3.LevelTemplate = Me.ExportCollection_Conditions_BaseView
        GridLevelNode3.RelationName = "FK_EXPORT_LC_CUSTOMERS_CollectionConditions_EXPORT_LC_CUSTOMERS"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1, GridLevelNode2, GridLevelNode3})
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.ExportLc_Customers_BaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SettlementStatusRepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.BICCODERepositoryItemTextEdit, Me.CurrencyRepositoryItemLookUpEdit1, Me.RepositoryItemDateEdit1, Me.CustomerNotes_RepositoryItemMemoExEdit, Me.AmountRepositoryItemTextEdit2, Me.RepositoryItemImageComboBox7})
        Me.GridControl2.Size = New System.Drawing.Size(1574, 20)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExportLc_BankDetails_BaseView, Me.ExportLc_Customers_BaseView, Me.ExportLc_Conditions_BaseView, Me.ExportCollection_Conditions_BaseView})
        '
        'ExportLc_BankDetails_BaseView
        '
        Me.ExportLc_BankDetails_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID4, Me.colAccountConnection1, Me.colAccountHolder1, Me.colIBAN_CCY1, Me.colIBAN_NR1, Me.colBIC1, Me.colBankName1, Me.colStatus1, Me.colNotes4, Me.colIdExportLcCustomers3})
        Me.ExportLc_BankDetails_BaseView.GridControl = Me.GridControl2
        Me.ExportLc_BankDetails_BaseView.Name = "ExportLc_BankDetails_BaseView"
        Me.ExportLc_BankDetails_BaseView.OptionsBehavior.ReadOnly = True
        Me.ExportLc_BankDetails_BaseView.OptionsView.ColumnAutoWidth = False
        Me.ExportLc_BankDetails_BaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportLc_BankDetails_BaseView.ViewCaption = "Bank Details"
        '
        'colID4
        '
        Me.colID4.FieldName = "ID"
        Me.colID4.Name = "colID4"
        '
        'colAccountConnection1
        '
        Me.colAccountConnection1.Caption = "Account Connection"
        Me.colAccountConnection1.ColumnEdit = Me.SettlementStatusRepositoryItemImageComboBox1
        Me.colAccountConnection1.FieldName = "AccountConnection"
        Me.colAccountConnection1.Name = "colAccountConnection1"
        Me.colAccountConnection1.Visible = True
        Me.colAccountConnection1.VisibleIndex = 0
        Me.colAccountConnection1.Width = 133
        '
        'SettlementStatusRepositoryItemImageComboBox1
        '
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.Options.UseBackColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.Appearance.Options.UseForeColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.SettlementStatusRepositoryItemImageComboBox1.AutoHeight = False
        Me.SettlementStatusRepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("INTERNAL", "I", 22), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EXTERNAL", "E", 23)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Name = "SettlementStatusRepositoryItemImageComboBox1"
        Me.SettlementStatusRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colAccountHolder1
        '
        Me.colAccountHolder1.Caption = "Account Holder"
        Me.colAccountHolder1.FieldName = "AccountHolder"
        Me.colAccountHolder1.Name = "colAccountHolder1"
        Me.colAccountHolder1.Visible = True
        Me.colAccountHolder1.VisibleIndex = 1
        Me.colAccountHolder1.Width = 211
        '
        'colIBAN_CCY1
        '
        Me.colIBAN_CCY1.AppearanceCell.Options.UseTextOptions = True
        Me.colIBAN_CCY1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIBAN_CCY1.Caption = "Currency"
        Me.colIBAN_CCY1.FieldName = "IBAN_CCY"
        Me.colIBAN_CCY1.Name = "colIBAN_CCY1"
        Me.colIBAN_CCY1.Visible = True
        Me.colIBAN_CCY1.VisibleIndex = 2
        '
        'colIBAN_NR1
        '
        Me.colIBAN_NR1.Caption = "Account / IBAN Nr."
        Me.colIBAN_NR1.FieldName = "IBAN_NR"
        Me.colIBAN_NR1.Name = "colIBAN_NR1"
        Me.colIBAN_NR1.Visible = True
        Me.colIBAN_NR1.VisibleIndex = 3
        Me.colIBAN_NR1.Width = 206
        '
        'colBIC1
        '
        Me.colBIC1.Caption = "BIC"
        Me.colBIC1.FieldName = "BIC"
        Me.colBIC1.Name = "colBIC1"
        Me.colBIC1.Visible = True
        Me.colBIC1.VisibleIndex = 4
        Me.colBIC1.Width = 114
        '
        'colBankName1
        '
        Me.colBankName1.Caption = "Bank Name"
        Me.colBankName1.FieldName = "BankName"
        Me.colBankName1.Name = "colBankName1"
        Me.colBankName1.Visible = True
        Me.colBankName1.VisibleIndex = 5
        Me.colBankName1.Width = 278
        '
        'colStatus1
        '
        Me.colStatus1.Caption = "Status"
        Me.colStatus1.ColumnEdit = Me.RepositoryItemImageComboBox7
        Me.colStatus1.FieldName = "Status"
        Me.colStatus1.Name = "colStatus1"
        Me.colStatus1.Visible = True
        Me.colStatus1.VisibleIndex = 6
        '
        'RepositoryItemImageComboBox7
        '
        Me.RepositoryItemImageComboBox7.AutoHeight = False
        Me.RepositoryItemImageComboBox7.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox7.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "Y", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "N", 15)})
        Me.RepositoryItemImageComboBox7.Name = "RepositoryItemImageComboBox7"
        Me.RepositoryItemImageComboBox7.SmallImages = Me.ImageCollection1
        '
        'colNotes4
        '
        Me.colNotes4.ColumnEdit = Me.CustomerNotes_RepositoryItemMemoExEdit
        Me.colNotes4.FieldName = "Notes"
        Me.colNotes4.Name = "colNotes4"
        Me.colNotes4.Visible = True
        Me.colNotes4.VisibleIndex = 7
        '
        'colIdExportLcCustomers3
        '
        Me.colIdExportLcCustomers3.FieldName = "IdExportLcCustomers"
        Me.colIdExportLcCustomers3.Name = "colIdExportLcCustomers3"
        '
        'ExportLc_Customers_BaseView
        '
        Me.ExportLc_Customers_BaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExportLc_Customers_BaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExportLc_Customers_BaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExportLc_Customers_BaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExportLc_Customers_BaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExportLc_Customers_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCustomerName, Me.colCustomerAddress1, Me.colCustomerAddress2, Me.colCustomerZipCode, Me.colCustomerCity, Me.colCustomerCountry, Me.colCustomerFon, Me.colCustomerFax, Me.colCustomerEmail, Me.colCustomerWebsite, Me.colContactPerson1, Me.colContactPerson2, Me.colLcAdviceEmail, Me.colNotes, Me.colCustomerID})
        Me.ExportLc_Customers_BaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExportLc_Customers_BaseView.GridControl = Me.GridControl2
        Me.ExportLc_Customers_BaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Nothing, "Total: {0:n2}", 0R)})
        Me.ExportLc_Customers_BaseView.Name = "ExportLc_Customers_BaseView"
        Me.ExportLc_Customers_BaseView.NewItemRowText = "Add new EXPORT LC Maturity"
        Me.ExportLc_Customers_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLc_Customers_BaseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLc_Customers_BaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExportLc_Customers_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.ExportLc_Customers_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExportLc_Customers_BaseView.OptionsFind.AlwaysVisible = True
        Me.ExportLc_Customers_BaseView.OptionsNavigation.AutoFocusNewRow = True
        Me.ExportLc_Customers_BaseView.OptionsPrint.PrintDetails = True
        Me.ExportLc_Customers_BaseView.OptionsSelection.MultiSelect = True
        Me.ExportLc_Customers_BaseView.OptionsView.ColumnAutoWidth = False
        Me.ExportLc_Customers_BaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ExportLc_Customers_BaseView.OptionsView.ShowAutoFilterRow = True
        Me.ExportLc_Customers_BaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.ExportLc_Customers_BaseView.OptionsView.ShowFooter = True
        Me.ExportLc_Customers_BaseView.PaintStyleName = "Skin"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colCustomerName
        '
        Me.colCustomerName.Caption = "Name"
        Me.colCustomerName.FieldName = "CustomerName"
        Me.colCustomerName.Name = "colCustomerName"
        Me.colCustomerName.OptionsColumn.AllowEdit = False
        Me.colCustomerName.OptionsColumn.ReadOnly = True
        Me.colCustomerName.Visible = True
        Me.colCustomerName.VisibleIndex = 1
        Me.colCustomerName.Width = 364
        '
        'colCustomerAddress1
        '
        Me.colCustomerAddress1.Caption = "Address1"
        Me.colCustomerAddress1.FieldName = "CustomerAddress1"
        Me.colCustomerAddress1.Name = "colCustomerAddress1"
        Me.colCustomerAddress1.OptionsColumn.AllowEdit = False
        Me.colCustomerAddress1.OptionsColumn.ReadOnly = True
        Me.colCustomerAddress1.Width = 186
        '
        'colCustomerAddress2
        '
        Me.colCustomerAddress2.Caption = "Address2"
        Me.colCustomerAddress2.FieldName = "CustomerAddress2"
        Me.colCustomerAddress2.Name = "colCustomerAddress2"
        Me.colCustomerAddress2.OptionsColumn.AllowEdit = False
        Me.colCustomerAddress2.OptionsColumn.ReadOnly = True
        Me.colCustomerAddress2.Width = 113
        '
        'colCustomerZipCode
        '
        Me.colCustomerZipCode.Caption = "Zip Code"
        Me.colCustomerZipCode.FieldName = "CustomerZipCode"
        Me.colCustomerZipCode.Name = "colCustomerZipCode"
        Me.colCustomerZipCode.OptionsColumn.AllowEdit = False
        Me.colCustomerZipCode.OptionsColumn.ReadOnly = True
        Me.colCustomerZipCode.Width = 80
        '
        'colCustomerCity
        '
        Me.colCustomerCity.Caption = "City"
        Me.colCustomerCity.FieldName = "CustomerCity"
        Me.colCustomerCity.Name = "colCustomerCity"
        Me.colCustomerCity.OptionsColumn.AllowEdit = False
        Me.colCustomerCity.OptionsColumn.ReadOnly = True
        Me.colCustomerCity.Visible = True
        Me.colCustomerCity.VisibleIndex = 2
        Me.colCustomerCity.Width = 204
        '
        'colCustomerCountry
        '
        Me.colCustomerCountry.Caption = "Country"
        Me.colCustomerCountry.FieldName = "CustomerCountry"
        Me.colCustomerCountry.Name = "colCustomerCountry"
        Me.colCustomerCountry.OptionsColumn.AllowEdit = False
        Me.colCustomerCountry.OptionsColumn.ReadOnly = True
        Me.colCustomerCountry.Width = 152
        '
        'colCustomerFon
        '
        Me.colCustomerFon.Caption = "Tel."
        Me.colCustomerFon.FieldName = "CustomerFon"
        Me.colCustomerFon.Name = "colCustomerFon"
        Me.colCustomerFon.OptionsColumn.AllowEdit = False
        Me.colCustomerFon.OptionsColumn.ReadOnly = True
        Me.colCustomerFon.Visible = True
        Me.colCustomerFon.VisibleIndex = 3
        Me.colCustomerFon.Width = 142
        '
        'colCustomerFax
        '
        Me.colCustomerFax.Caption = "Fax"
        Me.colCustomerFax.FieldName = "CustomerFax"
        Me.colCustomerFax.Name = "colCustomerFax"
        Me.colCustomerFax.OptionsColumn.AllowEdit = False
        Me.colCustomerFax.OptionsColumn.ReadOnly = True
        Me.colCustomerFax.Visible = True
        Me.colCustomerFax.VisibleIndex = 4
        Me.colCustomerFax.Width = 143
        '
        'colCustomerEmail
        '
        Me.colCustomerEmail.Caption = "E-Mail"
        Me.colCustomerEmail.FieldName = "CustomerEmail"
        Me.colCustomerEmail.Name = "colCustomerEmail"
        Me.colCustomerEmail.OptionsColumn.AllowEdit = False
        Me.colCustomerEmail.OptionsColumn.ReadOnly = True
        Me.colCustomerEmail.Visible = True
        Me.colCustomerEmail.VisibleIndex = 5
        Me.colCustomerEmail.Width = 165
        '
        'colCustomerWebsite
        '
        Me.colCustomerWebsite.Caption = "Web"
        Me.colCustomerWebsite.FieldName = "CustomerWebsite"
        Me.colCustomerWebsite.Name = "colCustomerWebsite"
        Me.colCustomerWebsite.OptionsColumn.AllowEdit = False
        Me.colCustomerWebsite.OptionsColumn.ReadOnly = True
        Me.colCustomerWebsite.Visible = True
        Me.colCustomerWebsite.VisibleIndex = 6
        Me.colCustomerWebsite.Width = 203
        '
        'colContactPerson1
        '
        Me.colContactPerson1.Caption = "Contact Person 1"
        Me.colContactPerson1.FieldName = "ContactPerson1"
        Me.colContactPerson1.Name = "colContactPerson1"
        Me.colContactPerson1.OptionsColumn.AllowEdit = False
        Me.colContactPerson1.OptionsColumn.ReadOnly = True
        Me.colContactPerson1.Width = 132
        '
        'colContactPerson2
        '
        Me.colContactPerson2.Caption = "Contact Person 2"
        Me.colContactPerson2.FieldName = "ContactPerson2"
        Me.colContactPerson2.Name = "colContactPerson2"
        Me.colContactPerson2.OptionsColumn.AllowEdit = False
        Me.colContactPerson2.OptionsColumn.ReadOnly = True
        '
        'colLcAdviceEmail
        '
        Me.colLcAdviceEmail.Caption = "LC Advice Email"
        Me.colLcAdviceEmail.FieldName = "LcAdviceEmail"
        Me.colLcAdviceEmail.Name = "colLcAdviceEmail"
        Me.colLcAdviceEmail.OptionsColumn.AllowEdit = False
        Me.colLcAdviceEmail.OptionsColumn.ReadOnly = True
        Me.colLcAdviceEmail.Width = 118
        '
        'colNotes
        '
        Me.colNotes.ColumnEdit = Me.CustomerNotes_RepositoryItemMemoExEdit
        Me.colNotes.FieldName = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.OptionsColumn.ReadOnly = True
        Me.colNotes.Visible = True
        Me.colNotes.VisibleIndex = 7
        '
        'colCustomerID
        '
        Me.colCustomerID.Caption = "Customer ID"
        Me.colCustomerID.FieldName = "CustomerID"
        Me.colCustomerID.Name = "colCustomerID"
        Me.colCustomerID.OptionsColumn.AllowEdit = False
        Me.colCustomerID.OptionsColumn.ReadOnly = True
        Me.colCustomerID.Visible = True
        Me.colCustomerID.VisibleIndex = 0
        Me.colCustomerID.Width = 97
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'BICCODERepositoryItemTextEdit
        '
        Me.BICCODERepositoryItemTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BICCODERepositoryItemTextEdit.Appearance.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.BICCODERepositoryItemTextEdit.Appearance.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseBackColor = True
        Me.BICCODERepositoryItemTextEdit.AppearanceFocused.Options.UseForeColor = True
        Me.BICCODERepositoryItemTextEdit.AutoHeight = False
        Me.BICCODERepositoryItemTextEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.BICCODERepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.BICCODERepositoryItemTextEdit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic
        Me.BICCODERepositoryItemTextEdit.Mask.EditMask = "([A-Z]){6}([0-9A-Z]){2}([0-9A-Z]{3})"
        Me.BICCODERepositoryItemTextEdit.Mask.IgnoreMaskBlank = False
        Me.BICCODERepositoryItemTextEdit.Name = "BICCODERepositoryItemTextEdit"
        '
        'CurrencyRepositoryItemLookUpEdit1
        '
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.Appearance.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencyRepositoryItemLookUpEdit1.AutoHeight = False
        Me.CurrencyRepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyRepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CurrencyRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.CurrencyRepositoryItemLookUpEdit1.DisplayMember = "CURRENCY CODE"
        Me.CurrencyRepositoryItemLookUpEdit1.Name = "CurrencyRepositoryItemLookUpEdit1"
        Me.CurrencyRepositoryItemLookUpEdit1.NullText = ""
        Me.CurrencyRepositoryItemLookUpEdit1.ValueMember = "CURRENCY CODE"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.ShowWeekNumbers = True
        '
        'AmountRepositoryItemTextEdit2
        '
        Me.AmountRepositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AmountRepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.AmountRepositoryItemTextEdit2.AutoHeight = False
        Me.AmountRepositoryItemTextEdit2.DisplayFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit2.EditFormat.FormatString = "n2"
        Me.AmountRepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountRepositoryItemTextEdit2.Mask.EditMask = "n2"
        Me.AmountRepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.AmountRepositoryItemTextEdit2.Name = "AmountRepositoryItemTextEdit2"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(768, 515)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(166, 14)
        Me.Label20.TabIndex = 35
        Me.Label20.Text = "Discount Conditions Text:"
        '
        'ClientName_lbl
        '
        Me.ClientName_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClientName_lbl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerInternalClientName", True))
        Me.ClientName_lbl.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClientName_lbl.ForeColor = System.Drawing.Color.Aqua
        Me.ClientName_lbl.Location = New System.Drawing.Point(1158, 24)
        Me.ClientName_lbl.Name = "ClientName_lbl"
        Me.ClientName_lbl.Size = New System.Drawing.Size(445, 18)
        Me.ClientName_lbl.TabIndex = 32
        Me.ClientName_lbl.Text = "ClientName:"
        '
        'EXPORT_LC_CUSTOMERSTableAdapter
        '
        Me.EXPORT_LC_CUSTOMERSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_SWIFT_MESSAGESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter = Me.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter
        Me.TableAdapterManager.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter = Me.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter
        Me.TableAdapterManager.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter = Me.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter
        Me.TableAdapterManager.EXPORT_LC_CUSTOMERSTableAdapter = Me.EXPORT_LC_CUSTOMERSTableAdapter
        Me.TableAdapterManager.EXPORT_LC_MT700_ApplNameAddressTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_BD_TableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_RMTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_Settlements_ApplNameAddressTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_Settlements_ChargesTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_SettlementsTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter
        '
        Me.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter.ClearBeforeFill = True
        '
        'EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter
        '
        Me.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter.ClearBeforeFill = True
        '
        'EXPORT_LC_CUSTOMERS_ConditionsTableAdapter
        '
        Me.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter.ClearBeforeFill = True
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl2
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ViewEdit_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_GridView_btn)
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 797)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1615, 64)
        Me.LayoutControl1.TabIndex = 19
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ViewEdit_btn
        '
        Me.ViewEdit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ViewEdit_btn.ImageOptions.ImageIndex = 0
        Me.ViewEdit_btn.Location = New System.Drawing.Point(1446, 12)
        Me.ViewEdit_btn.Name = "ViewEdit_btn"
        Me.ViewEdit_btn.Size = New System.Drawing.Size(140, 22)
        Me.ViewEdit_btn.StyleController = Me.LayoutControl1
        Me.ViewEdit_btn.TabIndex = 10
        Me.ViewEdit_btn.Text = "Edit SSIS"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(124, 69)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(804, 535)
        Me.GridControl1.TabIndex = 10
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'Print_Export_GridView_btn
        '
        Me.Print_Export_GridView_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Print_Export_GridView_btn.ImageOptions.ImageIndex = 2
        Me.Print_Export_GridView_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Print_Export_GridView_btn.Location = New System.Drawing.Point(12, 12)
        Me.Print_Export_GridView_btn.Name = "Print_Export_GridView_btn"
        Me.Print_Export_GridView_btn.Size = New System.Drawing.Size(174, 22)
        Me.Print_Export_GridView_btn.StyleController = Me.LayoutControl1
        Me.Print_Export_GridView_btn.TabIndex = 9
        Me.Print_Export_GridView_btn.Text = "Print or Export"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(908, 539)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1598, 70)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(419, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1013, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Print_Export_GridView_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(178, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(178, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(241, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1432, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1578, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ViewEdit_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1434, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(144, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'City_TextEdit
        '
        Me.City_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerCity", True))
        Me.City_TextEdit.Location = New System.Drawing.Point(141, 139)
        Me.City_TextEdit.Name = "City_TextEdit"
        Me.City_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.City_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.City_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.City_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.City_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.City_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.City_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.City_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.City_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.City_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City_TextEdit.Size = New System.Drawing.Size(582, 20)
        Me.City_TextEdit.TabIndex = 13
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Mandatory Field"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.City_TextEdit, ConditionValidationRule1)
        '
        'CustomerID_TextEdit
        '
        Me.CustomerID_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerID", True))
        Me.CustomerID_TextEdit.Location = New System.Drawing.Point(462, 18)
        Me.CustomerID_TextEdit.Name = "CustomerID_TextEdit"
        Me.CustomerID_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerID_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CustomerID_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.CustomerID_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.CustomerID_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CustomerID_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerID_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CustomerID_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CustomerID_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CustomerID_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CustomerID_TextEdit.Properties.Mask.EditMask = "[0-9]+"
        Me.CustomerID_TextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.CustomerID_TextEdit.Properties.MaxLength = 23
        Me.CustomerID_TextEdit.Properties.ReadOnly = True
        Me.CustomerID_TextEdit.Size = New System.Drawing.Size(260, 20)
        Me.CustomerID_TextEdit.TabIndex = 3
        Me.CustomerID_TextEdit.TabStop = False
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Mandatory Field"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.CustomerID_TextEdit, ConditionValidationRule2)
        '
        'CustomerName_TextEdit
        '
        Me.CustomerName_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerName", True))
        Me.CustomerName_TextEdit.Location = New System.Drawing.Point(140, 46)
        Me.CustomerName_TextEdit.Name = "CustomerName_TextEdit"
        Me.CustomerName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerName_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.CustomerName_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.CustomerName_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.CustomerName_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CustomerName_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CustomerName_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CustomerName_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CustomerName_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CustomerName_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CustomerName_TextEdit.Size = New System.Drawing.Size(583, 20)
        Me.CustomerName_TextEdit.TabIndex = 5
        '
        'Name2_TextEdit
        '
        Me.Name2_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerAddress1", True))
        Me.Name2_TextEdit.Location = New System.Drawing.Point(141, 68)
        Me.Name2_TextEdit.Name = "Name2_TextEdit"
        Me.Name2_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name2_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Name2_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Name2_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Name2_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Name2_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Name2_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Name2_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Name2_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Name2_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Name2_TextEdit.Size = New System.Drawing.Size(582, 20)
        Me.Name2_TextEdit.TabIndex = 7
        '
        'Adress2_TextEdit
        '
        Me.Adress2_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerAddress2", True))
        Me.Adress2_TextEdit.Location = New System.Drawing.Point(141, 91)
        Me.Adress2_TextEdit.Name = "Adress2_TextEdit"
        Me.Adress2_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Adress2_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Adress2_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Adress2_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Adress2_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Adress2_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Adress2_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Adress2_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Adress2_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Adress2_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Adress2_TextEdit.Size = New System.Drawing.Size(582, 20)
        Me.Adress2_TextEdit.TabIndex = 9
        '
        'ZipCode_TextEdit
        '
        Me.ZipCode_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerZipCode", True))
        Me.ZipCode_TextEdit.Location = New System.Drawing.Point(140, 115)
        Me.ZipCode_TextEdit.Name = "ZipCode_TextEdit"
        Me.ZipCode_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ZipCode_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.ZipCode_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.ZipCode_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ZipCode_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ZipCode_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ZipCode_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ZipCode_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ZipCode_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ZipCode_TextEdit.Size = New System.Drawing.Size(179, 20)
        Me.ZipCode_TextEdit.TabIndex = 11
        '
        'Tel_TextEdit
        '
        Me.Tel_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerFon", True))
        Me.Tel_TextEdit.Location = New System.Drawing.Point(141, 164)
        Me.Tel_TextEdit.Name = "Tel_TextEdit"
        Me.Tel_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tel_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Tel_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Tel_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Tel_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Tel_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Tel_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Tel_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Tel_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Tel_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Tel_TextEdit.Properties.MaxLength = 255
        Me.Tel_TextEdit.Size = New System.Drawing.Size(582, 20)
        Me.Tel_TextEdit.TabIndex = 15
        '
        'Fax_TextEdit
        '
        Me.Fax_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerFax", True))
        Me.Fax_TextEdit.Location = New System.Drawing.Point(141, 190)
        Me.Fax_TextEdit.Name = "Fax_TextEdit"
        Me.Fax_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fax_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Fax_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Fax_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Fax_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Fax_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Fax_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Fax_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Fax_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Fax_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Fax_TextEdit.Properties.MaxLength = 255
        Me.Fax_TextEdit.Size = New System.Drawing.Size(582, 20)
        Me.Fax_TextEdit.TabIndex = 17
        '
        'Email_TextEdit
        '
        Me.Email_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerEmail", True))
        Me.Email_TextEdit.Location = New System.Drawing.Point(140, 216)
        Me.Email_TextEdit.Name = "Email_TextEdit"
        Me.Email_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Email_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Email_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Email_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Email_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Email_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Email_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Email_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Email_TextEdit.Properties.MaxLength = 255
        Me.Email_TextEdit.Size = New System.Drawing.Size(584, 20)
        Me.Email_TextEdit.TabIndex = 19
        '
        'Web_TextEdit
        '
        Me.Web_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerWebsite", True))
        Me.Web_TextEdit.Location = New System.Drawing.Point(140, 468)
        Me.Web_TextEdit.Name = "Web_TextEdit"
        Me.Web_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Web_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Web_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.Web_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Web_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Web_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Web_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Web_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Web_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Web_TextEdit.Properties.MaxLength = 255
        Me.Web_TextEdit.Size = New System.Drawing.Size(583, 20)
        Me.Web_TextEdit.TabIndex = 25
        '
        'Contact1_MemoEdit
        '
        Me.Contact1_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "ContactPerson1", True))
        Me.Contact1_MemoEdit.Location = New System.Drawing.Point(140, 494)
        Me.Contact1_MemoEdit.Name = "Contact1_MemoEdit"
        Me.Contact1_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contact1_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Contact1_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.Contact1_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Contact1_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Contact1_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Contact1_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Contact1_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Contact1_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Contact1_MemoEdit.Size = New System.Drawing.Size(583, 56)
        Me.Contact1_MemoEdit.TabIndex = 27
        '
        'Contact2_MemoEdit
        '
        Me.Contact2_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "ContactPerson2", True))
        Me.Contact2_MemoEdit.Location = New System.Drawing.Point(140, 556)
        Me.Contact2_MemoEdit.Name = "Contact2_MemoEdit"
        Me.Contact2_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contact2_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Contact2_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.Contact2_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Contact2_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Contact2_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Contact2_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Contact2_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Contact2_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Contact2_MemoEdit.Size = New System.Drawing.Size(583, 54)
        Me.Contact2_MemoEdit.TabIndex = 29
        '
        'LC_Advice_Email_MemoEdit
        '
        Me.LC_Advice_Email_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "LcAdviceEmail", True))
        Me.LC_Advice_Email_MemoEdit.Location = New System.Drawing.Point(141, 244)
        Me.LC_Advice_Email_MemoEdit.Name = "LC_Advice_Email_MemoEdit"
        Me.LC_Advice_Email_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LC_Advice_Email_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.LC_Advice_Email_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.LC_Advice_Email_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.LC_Advice_Email_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.LC_Advice_Email_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.LC_Advice_Email_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.LC_Advice_Email_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.LC_Advice_Email_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.LC_Advice_Email_MemoEdit.Size = New System.Drawing.Size(584, 60)
        Me.LC_Advice_Email_MemoEdit.TabIndex = 21
        '
        'Notes_MemoEdit
        '
        Me.Notes_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "Notes", True))
        Me.Notes_MemoEdit.Location = New System.Drawing.Point(140, 621)
        Me.Notes_MemoEdit.Name = "Notes_MemoEdit"
        Me.Notes_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Notes_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.Notes_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Notes_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Notes_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Notes_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Notes_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Notes_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Notes_MemoEdit.Size = New System.Drawing.Size(585, 82)
        Me.Notes_MemoEdit.TabIndex = 38
        '
        'Save_SimpleButton
        '
        Me.Save_SimpleButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_SimpleButton.ImageOptions.ImageIndex = 11
        Me.Save_SimpleButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.Save_SimpleButton.Location = New System.Drawing.Point(141, 709)
        Me.Save_SimpleButton.Name = "Save_SimpleButton"
        Me.Save_SimpleButton.Size = New System.Drawing.Size(153, 22)
        Me.Save_SimpleButton.StyleController = Me.LayoutControl1
        Me.Save_SimpleButton.TabIndex = 39
        Me.Save_SimpleButton.Text = "Save"
        '
        'ShowAllCustomers_SimpleButton
        '
        Me.ShowAllCustomers_SimpleButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowAllCustomers_SimpleButton.ImageOptions.ImageIndex = 12
        Me.ShowAllCustomers_SimpleButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.ShowAllCustomers_SimpleButton.Location = New System.Drawing.Point(314, 709)
        Me.ShowAllCustomers_SimpleButton.Name = "ShowAllCustomers_SimpleButton"
        Me.ShowAllCustomers_SimpleButton.Size = New System.Drawing.Size(153, 22)
        Me.ShowAllCustomers_SimpleButton.StyleController = Me.LayoutControl1
        Me.ShowAllCustomers_SimpleButton.TabIndex = 40
        Me.ShowAllCustomers_SimpleButton.Text = "Show all Customers"
        '
        'CUSTOMER_INFOBindingSource
        '
        Me.CUSTOMER_INFOBindingSource.DataMember = "CUSTOMER_INFO"
        Me.CUSTOMER_INFOBindingSource.DataSource = Me.PSTOOLDataset
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CUSTOMER_INFOTableAdapter
        '
        Me.CUSTOMER_INFOTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager1.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager1.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager1.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.BANKTableAdapter = Nothing
        Me.TableAdapterManager1.CalendarTableAdapter = Nothing
        Me.TableAdapterManager1.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager1.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager1.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager1.CUSTOMER_INFOTableAdapter = Me.CUSTOMER_INFOTableAdapter
        Me.TableAdapterManager1.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager1.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager1.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager1.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager1.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTS_BAISTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTS_NEWGTableAdapter = Nothing
        Me.TableAdapterManager1.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager1.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager1.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager1.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager1.OWN_CURRENCIESTableAdapter = Nothing
        Me.TableAdapterManager1.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager1.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager1.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager1.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager1.SSISTableAdapter = Nothing
        Me.TableAdapterManager1.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'M8_AdviceCharges_MemoEdit
        '
        Me.M8_AdviceCharges_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "LcAdviceChargesDTAEA", True))
        Me.M8_AdviceCharges_MemoEdit.Location = New System.Drawing.Point(140, 310)
        Me.M8_AdviceCharges_MemoEdit.Name = "M8_AdviceCharges_MemoEdit"
        Me.M8_AdviceCharges_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.M8_AdviceCharges_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.M8_AdviceCharges_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.M8_AdviceCharges_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.M8_AdviceCharges_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.M8_AdviceCharges_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.M8_AdviceCharges_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.M8_AdviceCharges_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.M8_AdviceCharges_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.M8_AdviceCharges_MemoEdit.Size = New System.Drawing.Size(437, 152)
        Me.M8_AdviceCharges_MemoEdit.TabIndex = 23
        '
        'ClientNrOCBS_GridLookUpEdit
        '
        Me.ClientNrOCBS_GridLookUpEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClientNrOCBS_GridLookUpEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerInternalClientNr", True))
        Me.ClientNrOCBS_GridLookUpEdit.EditValue = ""
        Me.ClientNrOCBS_GridLookUpEdit.Location = New System.Drawing.Point(926, 20)
        Me.ClientNrOCBS_GridLookUpEdit.Name = "ClientNrOCBS_GridLookUpEdit"
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Appearance.Options.UseForeColor = True
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ClientNrOCBS_GridLookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ClientNrOCBS_GridLookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ClientNrOCBS_GridLookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ClientNrOCBS_GridLookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ClientNrOCBS_GridLookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ClientNrOCBS_GridLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ClientNrOCBS_GridLookUpEdit.Properties.DataSource = Me.CUSTOMER_INFOBindingSource
        Me.ClientNrOCBS_GridLookUpEdit.Properties.DisplayMember = "ClientNo"
        Me.ClientNrOCBS_GridLookUpEdit.Properties.NullText = ""
        Me.ClientNrOCBS_GridLookUpEdit.Properties.PopupFormSize = New System.Drawing.Size(800, 400)
        Me.ClientNrOCBS_GridLookUpEdit.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.ClientNrOCBS_GridLookUpEdit.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1})
        Me.ClientNrOCBS_GridLookUpEdit.Properties.ValueMember = "ClientNo"
        Me.ClientNrOCBS_GridLookUpEdit.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        Me.ClientNrOCBS_GridLookUpEdit.Size = New System.Drawing.Size(226, 22)
        Me.ClientNrOCBS_GridLookUpEdit.TabIndex = 31
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsBehavior.AllowIncrementalSearch = True
        Me.SearchLookUpEdit1View.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.SearchLookUpEdit1View.OptionsFind.AlwaysVisible = True
        Me.SearchLookUpEdit1View.OptionsFind.SearchInPreview = True
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ColumnAutoWidth = False
        Me.SearchLookUpEdit1View.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.SearchLookUpEdit1View.OptionsView.ShowAutoFilterRow = True
        Me.SearchLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.SearchLookUpEdit1View.OptionsView.ShowFooter = True
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.FieldName = "ClientNo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 150
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Client Type"
        Me.GridColumn3.FieldName = "ClientType"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 101
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "ID Type"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "ID No"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "ID_TYPE_2"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "ID_NO_2"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Client Name"
        Me.GridColumn8.FieldName = "English Name"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 422
        '
        'GridColumn9
        '
        Me.GridColumn9.FieldName = "ESTABLISH_DATE"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        '
        'GridColumn15
        '
        Me.GridColumn15.FieldName = "Joint Account"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        '
        'GridColumn16
        '
        Me.GridColumn16.FieldName = "ACCOUNT_OFFICER_NAME"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        '
        'GridColumn17
        '
        Me.GridColumn17.FieldName = "Chinese Name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        '
        'GridColumn18
        '
        Me.GridColumn18.FieldName = "LEGAL_STATUS"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "CLIENT_OPEN_DATE"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "CLIENT_RISK"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        '
        'GridColumn21
        '
        Me.GridColumn21.FieldName = "City"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "COUNTRY_OF_REGISTRATION"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        '
        'GridColumn23
        '
        Me.GridColumn23.FieldName = "SHORT_NAME"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.OptionsColumn.ReadOnly = True
        '
        'GridColumn24
        '
        Me.GridColumn24.FieldName = "Internal Type"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.OptionsColumn.ReadOnly = True
        '
        'GridColumn25
        '
        Me.GridColumn25.FieldName = "OIC No"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        '
        'GridColumn26
        '
        Me.GridColumn26.FieldName = "RiskCountry"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.OptionsColumn.ReadOnly = True
        '
        'GridColumn27
        '
        Me.GridColumn27.FieldName = "Open Date"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.OptionsColumn.ReadOnly = True
        '
        'GridColumn28
        '
        Me.GridColumn28.FieldName = "Teller"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        Me.GridColumn28.OptionsColumn.ReadOnly = True
        '
        'GridColumn29
        '
        Me.GridColumn29.FieldName = "OIC_BR"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        '
        'GridColumn30
        '
        Me.GridColumn30.FieldName = "COUNTRY_OF_RESIDENCE"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        '
        'GridColumn31
        '
        Me.GridColumn31.FieldName = "INSTITUTION_SECTOR_CODE"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        '
        'GridColumn32
        '
        Me.GridColumn32.FieldName = "INDUSTRIAL_CLASS_LOCAL"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        '
        'GridColumn33
        '
        Me.GridColumn33.FieldName = "INDUSTRIAL_CLASS_LOCAL_NAME"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.OptionsColumn.ReadOnly = True
        '
        'GridColumn34
        '
        Me.GridColumn34.FieldName = "INDUSTRIAL_CLASS_CN"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        '
        'GridColumn35
        '
        Me.GridColumn35.FieldName = "FINANCIAL_BACKGROUND"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.OptionsColumn.ReadOnly = True
        '
        'GridColumn36
        '
        Me.GridColumn36.FieldName = "BUSINESS_GROUP"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.OptionsColumn.ReadOnly = True
        '
        'GridColumn37
        '
        Me.GridColumn37.FieldName = "CREDIT_AGENCY"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.OptionsColumn.ReadOnly = True
        '
        'GridColumn38
        '
        Me.GridColumn38.FieldName = "credit rating"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsColumn.AllowEdit = False
        Me.GridColumn38.OptionsColumn.ReadOnly = True
        '
        'GridColumn39
        '
        Me.GridColumn39.FieldName = "CLOSE_DATE"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.AllowEdit = False
        Me.GridColumn39.OptionsColumn.ReadOnly = True
        '
        'GridColumn40
        '
        Me.GridColumn40.FieldName = "ADDRESS_NO01"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.AllowEdit = False
        Me.GridColumn40.OptionsColumn.ReadOnly = True
        '
        'GridColumn41
        '
        Me.GridColumn41.FieldName = "ADDRESS_TYPE01"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.OptionsColumn.ReadOnly = True
        '
        'GridColumn42
        '
        Me.GridColumn42.FieldName = "ADDRESS1"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.OptionsColumn.ReadOnly = True
        '
        'GridColumn43
        '
        Me.GridColumn43.FieldName = "ADDRESS2"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.OptionsColumn.ReadOnly = True
        '
        'GridColumn44
        '
        Me.GridColumn44.FieldName = "ADDRESS3"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.OptionsColumn.ReadOnly = True
        '
        'GridColumn45
        '
        Me.GridColumn45.FieldName = "ADDRESS4"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.OptionsColumn.ReadOnly = True
        '
        'GridColumn46
        '
        Me.GridColumn46.FieldName = "ADDRESS_NO02"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        Me.GridColumn46.OptionsColumn.ReadOnly = True
        '
        'GridColumn47
        '
        Me.GridColumn47.FieldName = "ADDRESS5"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.AllowEdit = False
        Me.GridColumn47.OptionsColumn.ReadOnly = True
        '
        'GridColumn48
        '
        Me.GridColumn48.FieldName = "ADDRESS6"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.OptionsColumn.ReadOnly = True
        '
        'GridColumn49
        '
        Me.GridColumn49.FieldName = "ADDRESS_TYPE02"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.OptionsColumn.ReadOnly = True
        '
        'GridColumn50
        '
        Me.GridColumn50.FieldName = "RegisterOfCommerceDate"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.AllowEdit = False
        Me.GridColumn50.OptionsColumn.ReadOnly = True
        '
        'GridColumn51
        '
        Me.GridColumn51.FieldName = "RegisterOfCommerceNr"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.AllowEdit = False
        Me.GridColumn51.OptionsColumn.ReadOnly = True
        '
        'GridColumn52
        '
        Me.GridColumn52.FieldName = "BeneficialOwner"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.OptionsColumn.AllowEdit = False
        Me.GridColumn52.OptionsColumn.ReadOnly = True
        '
        'GridColumn53
        '
        Me.GridColumn53.FieldName = "BusinessSector"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.AllowEdit = False
        Me.GridColumn53.OptionsColumn.ReadOnly = True
        '
        'GridColumn54
        '
        Me.GridColumn54.FieldName = "ListingSanctionListPEP"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.OptionsColumn.AllowEdit = False
        Me.GridColumn54.OptionsColumn.ReadOnly = True
        '
        'GridColumn55
        '
        Me.GridColumn55.FieldName = "FATCA_Status"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.OptionsColumn.AllowEdit = False
        Me.GridColumn55.OptionsColumn.ReadOnly = True
        '
        'GridColumn56
        '
        Me.GridColumn56.FieldName = "PurposeOfAccount"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.OptionsColumn.AllowEdit = False
        Me.GridColumn56.OptionsColumn.ReadOnly = True
        '
        'GridColumn57
        '
        Me.GridColumn57.FieldName = "ResidenceOperationHighRiskCountry"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.OptionsColumn.AllowEdit = False
        Me.GridColumn57.OptionsColumn.ReadOnly = True
        '
        'GridColumn58
        '
        Me.GridColumn58.FieldName = "SourceOfFunding"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.OptionsColumn.AllowEdit = False
        Me.GridColumn58.OptionsColumn.ReadOnly = True
        '
        'GridColumn59
        '
        Me.GridColumn59.FieldName = "OnlineBanking"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.OptionsColumn.AllowEdit = False
        Me.GridColumn59.OptionsColumn.ReadOnly = True
        '
        'GridColumn60
        '
        Me.GridColumn60.FieldName = "AnticipadedBusinessVolume"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.OptionsColumn.AllowEdit = False
        Me.GridColumn60.OptionsColumn.ReadOnly = True
        '
        'GridColumn61
        '
        Me.GridColumn61.FieldName = "FundingNornalActivities"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.OptionsColumn.AllowEdit = False
        Me.GridColumn61.OptionsColumn.ReadOnly = True
        '
        'GridColumn62
        '
        Me.GridColumn62.FieldName = "FundingNormalActivitiesSpecify"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.OptionsColumn.AllowEdit = False
        Me.GridColumn62.OptionsColumn.ReadOnly = True
        '
        'GridColumn63
        '
        Me.GridColumn63.FieldName = "ClientDocsDirectory"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.OptionsColumn.AllowEdit = False
        Me.GridColumn63.OptionsColumn.ReadOnly = True
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Status"
        Me.GridColumn64.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.GridColumn64.FieldName = "colClientStatusUnbound"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.OptionsColumn.ReadOnly = True
        Me.GridColumn64.UnboundExpression = "Iif([CLOSE_DATE] != ?,1  ,0 )"
        Me.GridColumn64.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 2
        Me.GridColumn64.Width = 80
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("ACTIVE", "0", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "1", 15)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'GridControl3
        '
        Me.GridControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.DataSource = Me.FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.Hint = "Add new Condition"
        Me.GridControl3.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl3.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Hint = "Save"
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl3.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl3.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Hint = "Delete Maturity"
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl3.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl3.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, False, "Add new Condition", "AddNewCondition"), New DevExpress.XtraEditors.NavigatorCustomButton(-1, 15, True, True, "Delete Condition", "DeleteCondition")})
        Me.GridControl3.Location = New System.Drawing.Point(770, 285)
        Me.GridControl3.MainView = Me.Conditions_GridView
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox3, Me.RepositoryItemImageComboBox4, Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit3, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemDateEdit2, Me.RepositoryItemMemoExEdit1, Me.RepositoryItemTextEdit4, Me.RepositoryItemComboBox1})
        Me.GridControl3.Size = New System.Drawing.Size(835, 225)
        Me.GridControl3.TabIndex = 34
        Me.GridControl3.UseEmbeddedNavigator = True
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Conditions_GridView})
        '
        'FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource
        '
        Me.FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource.DataMember = "FK_EXPORT_LC_CUSTOMERS_Conditions_EXPORT_LC_CUSTOMERS"
        Me.FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource.DataSource = Me.EXPORT_LC_CUSTOMERSBindingSource
        '
        'Conditions_GridView
        '
        Me.Conditions_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.Conditions_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.Conditions_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.Conditions_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.Conditions_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.Conditions_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID2, Me.colConditionName, Me.colConditionCyclus, Me.colConditionPercent, Me.colConditionMin, Me.colConditionMax, Me.colNotes2, Me.colIdExportLcCustomers})
        Me.Conditions_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.Conditions_GridView.GridControl = Me.GridControl3
        Me.Conditions_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Nothing, "Total: {0:n2}", 0R)})
        Me.Conditions_GridView.Name = "Conditions_GridView"
        Me.Conditions_GridView.NewItemRowText = "Add new Condition"
        Me.Conditions_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.Conditions_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.Conditions_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.Conditions_GridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.Conditions_GridView.OptionsCustomization.AllowRowSizing = True
        Me.Conditions_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.Conditions_GridView.OptionsNavigation.AutoFocusNewRow = True
        Me.Conditions_GridView.OptionsSelection.MultiSelect = True
        Me.Conditions_GridView.OptionsView.ColumnAutoWidth = False
        Me.Conditions_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Conditions_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.Conditions_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.Conditions_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.Conditions_GridView.OptionsView.ShowGroupPanel = False
        Me.Conditions_GridView.OptionsView.ShowViewCaption = True
        Me.Conditions_GridView.PaintStyleName = "Skin"
        Me.Conditions_GridView.ViewCaption = "Export LC Conditions"
        '
        'colID2
        '
        Me.colID2.FieldName = "ID"
        Me.colID2.Name = "colID2"
        Me.colID2.OptionsColumn.AllowEdit = False
        Me.colID2.OptionsColumn.ReadOnly = True
        '
        'colConditionName
        '
        Me.colConditionName.Caption = "Condition Name"
        Me.colConditionName.ColumnEdit = Me.RepositoryItemComboBox1
        Me.colConditionName.FieldName = "ConditionName"
        Me.colConditionName.Name = "colConditionName"
        Me.colConditionName.OptionsEditForm.ColumnSpan = 2
        Me.colConditionName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colConditionName.Visible = True
        Me.colConditionName.VisibleIndex = 0
        Me.colConditionName.Width = 310
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Akkreditivprovision", "Kurierkosten", "Fremde Spesen"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'colConditionCyclus
        '
        Me.colConditionCyclus.Caption = "Cyclus"
        Me.colConditionCyclus.ColumnEdit = Me.RepositoryItemImageComboBox3
        Me.colConditionCyclus.FieldName = "ConditionCyclus"
        Me.colConditionCyclus.Name = "colConditionCyclus"
        Me.colConditionCyclus.OptionsEditForm.StartNewRow = True
        Me.colConditionCyclus.OptionsEditForm.UseEditorColRowSpan = False
        Me.colConditionCyclus.Visible = True
        Me.colConditionCyclus.VisibleIndex = 1
        Me.colConditionCyclus.Width = 138
        '
        'RepositoryItemImageComboBox3
        '
        Me.RepositoryItemImageComboBox3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox3.AutoHeight = False
        Me.RepositoryItemImageComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox3.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("RECURRENT", "R", 21), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NON-RECURRENT", "N", 20)})
        Me.RepositoryItemImageComboBox3.Name = "RepositoryItemImageComboBox3"
        Me.RepositoryItemImageComboBox3.SmallImages = Me.ImageCollection1
        '
        'colConditionPercent
        '
        Me.colConditionPercent.Caption = "Percentage"
        Me.colConditionPercent.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.colConditionPercent.DisplayFormat.FormatString = "p4"
        Me.colConditionPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colConditionPercent.FieldName = "ConditionPercent"
        Me.colConditionPercent.Name = "colConditionPercent"
        Me.colConditionPercent.OptionsEditForm.StartNewRow = True
        Me.colConditionPercent.Visible = True
        Me.colConditionPercent.VisibleIndex = 2
        Me.colConditionPercent.Width = 92
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatString = "p4"
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatString = "p4"
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Mask.EditMask = "p4"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'colConditionMin
        '
        Me.colConditionMin.Caption = "Min."
        Me.colConditionMin.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.colConditionMin.DisplayFormat.FormatString = "c2"
        Me.colConditionMin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colConditionMin.FieldName = "ConditionMin"
        Me.colConditionMin.Name = "colConditionMin"
        Me.colConditionMin.Visible = True
        Me.colConditionMin.VisibleIndex = 3
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit3.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatString = "c2"
        Me.RepositoryItemTextEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.EditFormat.FormatString = "c2"
        Me.RepositoryItemTextEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit3.Mask.EditMask = "c2"
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'colConditionMax
        '
        Me.colConditionMax.Caption = "Max."
        Me.colConditionMax.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.colConditionMax.DisplayFormat.FormatString = "c2"
        Me.colConditionMax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colConditionMax.FieldName = "ConditionMax"
        Me.colConditionMax.Name = "colConditionMax"
        Me.colConditionMax.OptionsEditForm.UseEditorColRowSpan = False
        Me.colConditionMax.Visible = True
        Me.colConditionMax.VisibleIndex = 4
        '
        'colNotes2
        '
        Me.colNotes2.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colNotes2.FieldName = "Notes"
        Me.colNotes2.Name = "colNotes2"
        Me.colNotes2.OptionsEditForm.StartNewRow = True
        Me.colNotes2.Visible = True
        Me.colNotes2.VisibleIndex = 5
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.PopupFormSize = New System.Drawing.Size(600, 500)
        Me.RepositoryItemMemoExEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'colIdExportLcCustomers
        '
        Me.colIdExportLcCustomers.FieldName = "IdExportLcCustomers"
        Me.colIdExportLcCustomers.Name = "colIdExportLcCustomers"
        Me.colIdExportLcCustomers.OptionsColumn.AllowEdit = False
        Me.colIdExportLcCustomers.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemImageComboBox4
        '
        Me.RepositoryItemImageComboBox4.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox4.AutoHeight = False
        Me.RepositoryItemImageComboBox4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox4.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.RepositoryItemImageComboBox4.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PERECENTAGE", "P", 18), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FIXED", "F", 19)})
        Me.RepositoryItemImageComboBox4.Name = "RepositoryItemImageComboBox4"
        Me.RepositoryItemImageComboBox4.SmallImages = Me.ImageCollection1
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit1.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemLookUpEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemLookUpEdit1.Appearance.Options.UseForeColor = True
        Me.RepositoryItemLookUpEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemLookUpEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemLookUpEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit1.DisplayMember = "CURRENCY CODE"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.NullText = ""
        Me.RepositoryItemLookUpEdit1.ValueMember = "CURRENCY CODE"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemDateEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemDateEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        Me.RepositoryItemDateEdit2.ShowWeekNumbers = True
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit4.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.MaxLength = 50
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        Me.RepositoryItemTextEdit4.NullValuePrompt = "Enter Condition Name"
        Me.RepositoryItemTextEdit4.NullValuePromptShowForEmptyValue = True
        '
        'DiscountConditions_MemoEdit
        '
        Me.DiscountConditions_MemoEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DiscountConditions_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "DiscontConditions", True))
        Me.DiscountConditions_MemoEdit.Location = New System.Drawing.Point(771, 532)
        Me.DiscountConditions_MemoEdit.Name = "DiscountConditions_MemoEdit"
        Me.DiscountConditions_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiscountConditions_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.DiscountConditions_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.DiscountConditions_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.DiscountConditions_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.DiscountConditions_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.DiscountConditions_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.DiscountConditions_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.DiscountConditions_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.DiscountConditions_MemoEdit.Size = New System.Drawing.Size(834, 42)
        Me.DiscountConditions_MemoEdit.TabIndex = 36
        '
        'GridControl4
        '
        Me.GridControl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl4.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl4.DataSource = Me.FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource
        Me.GridControl4.EmbeddedNavigator.Buttons.Append.Hint = "Add new Condition"
        Me.GridControl4.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl4.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.Hint = "Save"
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl4.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl4.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.Hint = "Delete Maturity"
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl4.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl4.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, False, "Add new Condition", "AddNewCondition"), New DevExpress.XtraEditors.NavigatorCustomButton(-1, 15, True, True, "Delete Bank Detail", "DeleteBankDetail")})
        Me.GridControl4.Location = New System.Drawing.Point(769, 49)
        Me.GridControl4.MainView = Me.BankDetails_GridView
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox5, Me.RepositoryItemImageComboBox6, Me.RepositoryItemTextEdit5, Me.RepositoryItemTextEdit6, Me.RepositoryItemLookUpEdit2, Me.RepositoryItemDateEdit3, Me.RepositoryItemMemoExEdit2, Me.RepositoryItemTextEdit7, Me.RepositoryItemComboBox2, Me.RepositoryItemMemoEdit1})
        Me.GridControl4.Size = New System.Drawing.Size(835, 218)
        Me.GridControl4.TabIndex = 33
        Me.GridControl4.UseEmbeddedNavigator = True
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BankDetails_GridView})
        '
        'FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource
        '
        Me.FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource.DataMember = "FK_EXPORT_LC_CUSTOMERS_BankDetails_EXPORT_LC_CUSTOMERS"
        Me.FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource.DataSource = Me.EXPORT_LC_CUSTOMERSBindingSource
        '
        'BankDetails_GridView
        '
        Me.BankDetails_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.BankDetails_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.BankDetails_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BankDetails_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BankDetails_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BankDetails_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colAccountConnection, Me.colAccountHolder, Me.colIBAN_CCY, Me.colIBAN_NR, Me.colBIC, Me.colBankName, Me.colStatus, Me.colNotes1, Me.colIdExportLcCustomers2})
        Me.BankDetails_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BankDetails_GridView.GridControl = Me.GridControl4
        Me.BankDetails_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Nothing, "Total: {0:n2}", 0R)})
        Me.BankDetails_GridView.Name = "BankDetails_GridView"
        Me.BankDetails_GridView.NewItemRowText = "Add new Bank Details"
        Me.BankDetails_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BankDetails_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.BankDetails_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.BankDetails_GridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.BankDetails_GridView.OptionsCustomization.AllowRowSizing = True
        Me.BankDetails_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.BankDetails_GridView.OptionsNavigation.AutoFocusNewRow = True
        Me.BankDetails_GridView.OptionsSelection.MultiSelect = True
        Me.BankDetails_GridView.OptionsView.ColumnAutoWidth = False
        Me.BankDetails_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.BankDetails_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.BankDetails_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.BankDetails_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.BankDetails_GridView.OptionsView.ShowGroupPanel = False
        Me.BankDetails_GridView.OptionsView.ShowViewCaption = True
        Me.BankDetails_GridView.PaintStyleName = "Skin"
        Me.BankDetails_GridView.ViewCaption = "Customers Bank Details"
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'colAccountConnection
        '
        Me.colAccountConnection.Caption = "Account Connection"
        Me.colAccountConnection.ColumnEdit = Me.RepositoryItemImageComboBox5
        Me.colAccountConnection.FieldName = "AccountConnection"
        Me.colAccountConnection.Name = "colAccountConnection"
        Me.colAccountConnection.Visible = True
        Me.colAccountConnection.VisibleIndex = 0
        Me.colAccountConnection.Width = 126
        '
        'RepositoryItemImageComboBox5
        '
        Me.RepositoryItemImageComboBox5.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox5.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox5.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox5.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox5.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox5.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox5.AutoHeight = False
        Me.RepositoryItemImageComboBox5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox5.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("INTERNAL", "I", 24), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("EXTERNAL", "E", 25)})
        Me.RepositoryItemImageComboBox5.Name = "RepositoryItemImageComboBox5"
        Me.RepositoryItemImageComboBox5.SmallImages = Me.ImageCollection1
        '
        'colAccountHolder
        '
        Me.colAccountHolder.Caption = "Account Holder"
        Me.colAccountHolder.ColumnEdit = Me.RepositoryItemTextEdit7
        Me.colAccountHolder.FieldName = "AccountHolder"
        Me.colAccountHolder.Name = "colAccountHolder"
        Me.colAccountHolder.OptionsEditForm.ColumnSpan = 3
        Me.colAccountHolder.OptionsEditForm.StartNewRow = True
        Me.colAccountHolder.OptionsEditForm.UseEditorColRowSpan = False
        Me.colAccountHolder.Visible = True
        Me.colAccountHolder.VisibleIndex = 1
        Me.colAccountHolder.Width = 236
        '
        'RepositoryItemTextEdit7
        '
        Me.RepositoryItemTextEdit7.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit7.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit7.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit7.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit7.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit7.AutoHeight = False
        Me.RepositoryItemTextEdit7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit7.MaxLength = 100
        Me.RepositoryItemTextEdit7.Name = "RepositoryItemTextEdit7"
        Me.RepositoryItemTextEdit7.NullValuePromptShowForEmptyValue = True
        '
        'colIBAN_CCY
        '
        Me.colIBAN_CCY.Caption = "Currency"
        Me.colIBAN_CCY.ColumnEdit = Me.RepositoryItemComboBox2
        Me.colIBAN_CCY.FieldName = "IBAN_CCY"
        Me.colIBAN_CCY.Name = "colIBAN_CCY"
        Me.colIBAN_CCY.OptionsEditForm.StartNewRow = True
        Me.colIBAN_CCY.OptionsEditForm.UseEditorColRowSpan = False
        Me.colIBAN_CCY.Visible = True
        Me.colIBAN_CCY.VisibleIndex = 2
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"EUR", "USD", "GBP", "CHF", "CNY", "HKD"})
        Me.RepositoryItemComboBox2.MaxLength = 3
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'colIBAN_NR
        '
        Me.colIBAN_NR.Caption = "Account/IBAN Nr."
        Me.colIBAN_NR.ColumnEdit = Me.RepositoryItemTextEdit6
        Me.colIBAN_NR.FieldName = "IBAN_NR"
        Me.colIBAN_NR.Name = "colIBAN_NR"
        Me.colIBAN_NR.OptionsEditForm.ColumnSpan = 2
        Me.colIBAN_NR.OptionsEditForm.StartNewRow = True
        Me.colIBAN_NR.OptionsEditForm.UseEditorColRowSpan = False
        Me.colIBAN_NR.Visible = True
        Me.colIBAN_NR.VisibleIndex = 3
        Me.colIBAN_NR.Width = 279
        '
        'RepositoryItemTextEdit6
        '
        Me.RepositoryItemTextEdit6.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit6.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit6.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit6.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit6.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit6.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit6.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit6.AutoHeight = False
        Me.RepositoryItemTextEdit6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit6.MaxLength = 40
        Me.RepositoryItemTextEdit6.Name = "RepositoryItemTextEdit6"
        '
        'colBIC
        '
        Me.colBIC.ColumnEdit = Me.RepositoryItemTextEdit5
        Me.colBIC.FieldName = "BIC"
        Me.colBIC.Name = "colBIC"
        Me.colBIC.OptionsEditForm.StartNewRow = True
        Me.colBIC.Visible = True
        Me.colBIC.VisibleIndex = 4
        Me.colBIC.Width = 141
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit5.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit5.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit5.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit5.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit5.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit5.AutoHeight = False
        Me.RepositoryItemTextEdit5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit5.Mask.EditMask = "[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}"
        Me.RepositoryItemTextEdit5.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        '
        'colBankName
        '
        Me.colBankName.Caption = "Bank Name"
        Me.colBankName.ColumnEdit = Me.RepositoryItemTextEdit7
        Me.colBankName.FieldName = "BankName"
        Me.colBankName.Name = "colBankName"
        Me.colBankName.OptionsColumn.ReadOnly = True
        Me.colBankName.OptionsEditForm.ColumnSpan = 3
        Me.colBankName.OptionsEditForm.StartNewRow = True
        Me.colBankName.OptionsEditForm.UseEditorColRowSpan = False
        Me.colBankName.Visible = True
        Me.colBankName.VisibleIndex = 5
        Me.colBankName.Width = 328
        '
        'colStatus
        '
        Me.colStatus.ColumnEdit = Me.RepositoryItemImageComboBox6
        Me.colStatus.FieldName = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.OptionsEditForm.StartNewRow = True
        Me.colStatus.Visible = True
        Me.colStatus.VisibleIndex = 6
        Me.colStatus.Width = 106
        '
        'RepositoryItemImageComboBox6
        '
        Me.RepositoryItemImageComboBox6.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox6.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox6.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox6.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox6.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox6.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox6.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox6.AutoHeight = False
        Me.RepositoryItemImageComboBox6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox6.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.RepositoryItemImageComboBox6.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("VALID", "Y", 14), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("CLOSED", "N", 15)})
        Me.RepositoryItemImageComboBox6.Name = "RepositoryItemImageComboBox6"
        Me.RepositoryItemImageComboBox6.SmallImages = Me.ImageCollection1
        '
        'colNotes1
        '
        Me.colNotes1.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.colNotes1.FieldName = "Notes"
        Me.colNotes1.Name = "colNotes1"
        Me.colNotes1.Visible = True
        Me.colNotes1.VisibleIndex = 7
        Me.colNotes1.Width = 95
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'colIdExportLcCustomers2
        '
        Me.colIdExportLcCustomers2.FieldName = "IdExportLcCustomers"
        Me.colIdExportLcCustomers2.Name = "colIdExportLcCustomers2"
        Me.colIdExportLcCustomers2.OptionsColumn.AllowEdit = False
        Me.colIdExportLcCustomers2.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemLookUpEdit2.Appearance.Options.UseBackColor = True
        Me.RepositoryItemLookUpEdit2.Appearance.Options.UseForeColor = True
        Me.RepositoryItemLookUpEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemLookUpEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemLookUpEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit2.DisplayMember = "CURRENCY CODE"
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.NullText = ""
        Me.RepositoryItemLookUpEdit2.ValueMember = "CURRENCY CODE"
        '
        'RepositoryItemDateEdit3
        '
        Me.RepositoryItemDateEdit3.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemDateEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemDateEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit3.AutoHeight = False
        Me.RepositoryItemDateEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit3.Name = "RepositoryItemDateEdit3"
        Me.RepositoryItemDateEdit3.ShowWeekNumbers = True
        '
        'RepositoryItemMemoExEdit2
        '
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit2.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit2.AutoHeight = False
        Me.RepositoryItemMemoExEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit2.Name = "RepositoryItemMemoExEdit2"
        Me.RepositoryItemMemoExEdit2.PopupFormSize = New System.Drawing.Size(600, 500)
        Me.RepositoryItemMemoExEdit2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'GridControl5
        '
        Me.GridControl5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl5.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl5.DataSource = Me.FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource
        Me.GridControl5.EmbeddedNavigator.Buttons.Append.Hint = "Add new Condition"
        Me.GridControl5.EmbeddedNavigator.Buttons.Append.ImageIndex = 9
        Me.GridControl5.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl5.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl5.EmbeddedNavigator.Buttons.EndEdit.Hint = "Save"
        Me.GridControl5.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 11
        Me.GridControl5.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl5.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl5.EmbeddedNavigator.Buttons.Remove.Hint = "Delete Maturity"
        Me.GridControl5.EmbeddedNavigator.Buttons.Remove.ImageIndex = 10
        Me.GridControl5.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl5.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, True, False, "Add new Condition", "AddNewCondition"), New DevExpress.XtraEditors.NavigatorCustomButton(-1, 15, True, True, "Delete Condition", "DeleteCondition")})
        Me.GridControl5.Location = New System.Drawing.Point(771, 578)
        Me.GridControl5.MainView = Me.ExportCollectionConditions_GridView
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox8, Me.RepositoryItemImageComboBox9, Me.RepositoryItemTextEdit8, Me.RepositoryItemTextEdit9, Me.RepositoryItemLookUpEdit3, Me.RepositoryItemDateEdit4, Me.RepositoryItemMemoExEdit3, Me.RepositoryItemTextEdit10, Me.RepositoryItemComboBox3})
        Me.GridControl5.Size = New System.Drawing.Size(835, 202)
        Me.GridControl5.TabIndex = 41
        Me.GridControl5.UseEmbeddedNavigator = True
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExportCollectionConditions_GridView})
        '
        'FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource
        '
        Me.FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource.DataMember = "FK_EXPORT_LC_CUSTOMERS_CollectionConditions_EXPORT_LC_CUSTOMERS"
        Me.FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource.DataSource = Me.EXPORT_LC_CUSTOMERSBindingSource
        '
        'ExportCollectionConditions_GridView
        '
        Me.ExportCollectionConditions_GridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ExportCollectionConditions_GridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ExportCollectionConditions_GridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.ExportCollectionConditions_GridView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ExportCollectionConditions_GridView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.ExportCollectionConditions_GridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67})
        Me.ExportCollectionConditions_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ExportCollectionConditions_GridView.GridControl = Me.GridControl5
        Me.ExportCollectionConditions_GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Nothing, "Total: {0:n2}", 0R)})
        Me.ExportCollectionConditions_GridView.Name = "ExportCollectionConditions_GridView"
        Me.ExportCollectionConditions_GridView.NewItemRowText = "Add new Condition"
        Me.ExportCollectionConditions_GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportCollectionConditions_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportCollectionConditions_GridView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExportCollectionConditions_GridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace
        Me.ExportCollectionConditions_GridView.OptionsCustomization.AllowRowSizing = True
        Me.ExportCollectionConditions_GridView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExportCollectionConditions_GridView.OptionsNavigation.AutoFocusNewRow = True
        Me.ExportCollectionConditions_GridView.OptionsSelection.MultiSelect = True
        Me.ExportCollectionConditions_GridView.OptionsView.ColumnAutoWidth = False
        Me.ExportCollectionConditions_GridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportCollectionConditions_GridView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.ExportCollectionConditions_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.ExportCollectionConditions_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ExportCollectionConditions_GridView.OptionsView.ShowGroupPanel = False
        Me.ExportCollectionConditions_GridView.OptionsView.ShowViewCaption = True
        Me.ExportCollectionConditions_GridView.PaintStyleName = "Skin"
        Me.ExportCollectionConditions_GridView.ViewCaption = "Export Collection Conditions"
        '
        'GridColumn10
        '
        Me.GridColumn10.FieldName = "ID"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Condition Name"
        Me.GridColumn11.ColumnEdit = Me.RepositoryItemComboBox3
        Me.GridColumn11.FieldName = "ConditionName"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsEditForm.ColumnSpan = 2
        Me.GridColumn11.OptionsEditForm.UseEditorColRowSpan = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 310
        '
        'RepositoryItemComboBox3
        '
        Me.RepositoryItemComboBox3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox3.AutoHeight = False
        Me.RepositoryItemComboBox3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox3.Items.AddRange(New Object() {"Akkreditivprovision", "Kurierkosten", "Fremde Spesen"})
        Me.RepositoryItemComboBox3.Name = "RepositoryItemComboBox3"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Cyclus"
        Me.GridColumn12.ColumnEdit = Me.RepositoryItemImageComboBox8
        Me.GridColumn12.FieldName = "ConditionCyclus"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsEditForm.StartNewRow = True
        Me.GridColumn12.OptionsEditForm.UseEditorColRowSpan = False
        Me.GridColumn12.Width = 138
        '
        'RepositoryItemImageComboBox8
        '
        Me.RepositoryItemImageComboBox8.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox8.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox8.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox8.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox8.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox8.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox8.AutoHeight = False
        Me.RepositoryItemImageComboBox8.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox8.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("RECURRENT", "R", 21), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NON-RECURRENT", "N", 20)})
        Me.RepositoryItemImageComboBox8.Name = "RepositoryItemImageComboBox8"
        Me.RepositoryItemImageComboBox8.SmallImages = Me.ImageCollection1
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Percentage"
        Me.GridColumn13.ColumnEdit = Me.RepositoryItemTextEdit8
        Me.GridColumn13.DisplayFormat.FormatString = "p4"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "ConditionPercent"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsEditForm.StartNewRow = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        Me.GridColumn13.Width = 92
        '
        'RepositoryItemTextEdit8
        '
        Me.RepositoryItemTextEdit8.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit8.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit8.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit8.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit8.AutoHeight = False
        Me.RepositoryItemTextEdit8.DisplayFormat.FormatString = "p4"
        Me.RepositoryItemTextEdit8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit8.EditFormat.FormatString = "p4"
        Me.RepositoryItemTextEdit8.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit8.Mask.EditMask = "p4"
        Me.RepositoryItemTextEdit8.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit8.Name = "RepositoryItemTextEdit8"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Min."
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemTextEdit9
        Me.GridColumn14.DisplayFormat.FormatString = "c2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "ConditionMin"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 2
        '
        'RepositoryItemTextEdit9
        '
        Me.RepositoryItemTextEdit9.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit9.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit9.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit9.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit9.AutoHeight = False
        Me.RepositoryItemTextEdit9.DisplayFormat.FormatString = "c2"
        Me.RepositoryItemTextEdit9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit9.EditFormat.FormatString = "c2"
        Me.RepositoryItemTextEdit9.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit9.Mask.EditMask = "c2"
        Me.RepositoryItemTextEdit9.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit9.Name = "RepositoryItemTextEdit9"
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "Max."
        Me.GridColumn65.ColumnEdit = Me.RepositoryItemTextEdit9
        Me.GridColumn65.DisplayFormat.FormatString = "c2"
        Me.GridColumn65.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn65.FieldName = "ConditionMax"
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.OptionsEditForm.UseEditorColRowSpan = False
        Me.GridColumn65.Visible = True
        Me.GridColumn65.VisibleIndex = 3
        '
        'GridColumn66
        '
        Me.GridColumn66.ColumnEdit = Me.RepositoryItemMemoExEdit3
        Me.GridColumn66.FieldName = "Notes"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.OptionsEditForm.StartNewRow = True
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 4
        '
        'RepositoryItemMemoExEdit3
        '
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemMemoExEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemMemoExEdit3.AutoHeight = False
        Me.RepositoryItemMemoExEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit3.Name = "RepositoryItemMemoExEdit3"
        Me.RepositoryItemMemoExEdit3.PopupFormSize = New System.Drawing.Size(600, 500)
        Me.RepositoryItemMemoExEdit3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'GridColumn67
        '
        Me.GridColumn67.FieldName = "IdExportLcCustomers"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.OptionsColumn.AllowEdit = False
        Me.GridColumn67.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemImageComboBox9
        '
        Me.RepositoryItemImageComboBox9.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox9.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox9.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox9.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemImageComboBox9.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemImageComboBox9.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemImageComboBox9.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemImageComboBox9.AutoHeight = False
        Me.RepositoryItemImageComboBox9.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox9.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.RepositoryItemImageComboBox9.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PERECENTAGE", "P", 18), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("FIXED", "F", 19)})
        Me.RepositoryItemImageComboBox9.Name = "RepositoryItemImageComboBox9"
        Me.RepositoryItemImageComboBox9.SmallImages = Me.ImageCollection1
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit3.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemLookUpEdit3.Appearance.Options.UseBackColor = True
        Me.RepositoryItemLookUpEdit3.Appearance.Options.UseForeColor = True
        Me.RepositoryItemLookUpEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemLookUpEdit3.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemLookUpEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemLookUpEdit3.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemLookUpEdit3.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit3.DisplayMember = "CURRENCY CODE"
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.NullText = ""
        Me.RepositoryItemLookUpEdit3.ValueMember = "CURRENCY CODE"
        '
        'RepositoryItemDateEdit4
        '
        Me.RepositoryItemDateEdit4.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit4.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit4.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit4.Appearance.Options.UseBackColor = True
        Me.RepositoryItemDateEdit4.Appearance.Options.UseForeColor = True
        Me.RepositoryItemDateEdit4.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit4.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemDateEdit4.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemDateEdit4.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemDateEdit4.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemDateEdit4.AutoHeight = False
        Me.RepositoryItemDateEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit4.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemDateEdit4.Name = "RepositoryItemDateEdit4"
        Me.RepositoryItemDateEdit4.ShowWeekNumbers = True
        '
        'RepositoryItemTextEdit10
        '
        Me.RepositoryItemTextEdit10.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit10.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit10.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit10.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit10.Appearance.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit10.Appearance.Options.UseBackColor = True
        Me.RepositoryItemTextEdit10.Appearance.Options.UseFont = True
        Me.RepositoryItemTextEdit10.Appearance.Options.UseForeColor = True
        Me.RepositoryItemTextEdit10.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit10.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit10.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.RepositoryItemTextEdit10.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit10.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit10.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemTextEdit10.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit10.AutoHeight = False
        Me.RepositoryItemTextEdit10.MaxLength = 50
        Me.RepositoryItemTextEdit10.Name = "RepositoryItemTextEdit10"
        Me.RepositoryItemTextEdit10.NullValuePrompt = "Enter Condition Name"
        Me.RepositoryItemTextEdit10.NullValuePromptShowForEmptyValue = True
        '
        'ExportCollection_Conditions_BaseView
        '
        Me.ExportCollection_Conditions_BaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn68, Me.GridColumn69, Me.GridColumn70, Me.GridColumn71, Me.GridColumn72, Me.GridColumn73, Me.GridColumn74, Me.GridColumn75, Me.GridColumn76})
        Me.ExportCollection_Conditions_BaseView.GridControl = Me.GridControl2
        Me.ExportCollection_Conditions_BaseView.Name = "ExportCollection_Conditions_BaseView"
        Me.ExportCollection_Conditions_BaseView.OptionsBehavior.ReadOnly = True
        Me.ExportCollection_Conditions_BaseView.OptionsView.ColumnAutoWidth = False
        Me.ExportCollection_Conditions_BaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExportCollection_Conditions_BaseView.OptionsView.ShowGroupPanel = False
        Me.ExportCollection_Conditions_BaseView.ViewCaption = "Export Collection Conditions"
        '
        'GridColumn68
        '
        Me.GridColumn68.FieldName = "ID"
        Me.GridColumn68.Name = "GridColumn68"
        '
        'GridColumn69
        '
        Me.GridColumn69.Caption = "Condition Name"
        Me.GridColumn69.FieldName = "ConditionName"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 0
        Me.GridColumn69.Width = 185
        '
        'GridColumn70
        '
        Me.GridColumn70.Caption = "Cyclus"
        Me.GridColumn70.ColumnEdit = Me.RepositoryItemImageComboBox2
        Me.GridColumn70.FieldName = "ConditionCyclus"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 1
        Me.GridColumn70.Width = 122
        '
        'GridColumn71
        '
        Me.GridColumn71.FieldName = "ConditionType"
        Me.GridColumn71.Name = "GridColumn71"
        '
        'GridColumn72
        '
        Me.GridColumn72.Caption = "Percentage"
        Me.GridColumn72.DisplayFormat.FormatString = "p4"
        Me.GridColumn72.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn72.FieldName = "ConditionPercent"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 2
        Me.GridColumn72.Width = 87
        '
        'GridColumn73
        '
        Me.GridColumn73.ColumnEdit = Me.CustomerNotes_RepositoryItemMemoExEdit
        Me.GridColumn73.FieldName = "Notes"
        Me.GridColumn73.Name = "GridColumn73"
        Me.GridColumn73.Visible = True
        Me.GridColumn73.VisibleIndex = 5
        '
        'GridColumn74
        '
        Me.GridColumn74.FieldName = "IdExportLcCustomers"
        Me.GridColumn74.Name = "GridColumn74"
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "Min."
        Me.GridColumn75.DisplayFormat.FormatString = "c2"
        Me.GridColumn75.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn75.FieldName = "ConditionMin"
        Me.GridColumn75.Name = "GridColumn75"
        Me.GridColumn75.Visible = True
        Me.GridColumn75.VisibleIndex = 3
        '
        'GridColumn76
        '
        Me.GridColumn76.Caption = "Max."
        Me.GridColumn76.DisplayFormat.FormatString = "c2"
        Me.GridColumn76.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn76.FieldName = "ConditionMax"
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.Visible = True
        Me.GridColumn76.VisibleIndex = 4
        '
        'LcExportCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1615, 861)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.ShowAllCustomers_SimpleButton)
        Me.Controls.Add(Me.Save_SimpleButton)
        Me.Controls.Add(Me.Notes_MemoEdit)
        Me.Controls.Add(Label15)
        Me.Controls.Add(Me.LC_Advice_Email_MemoEdit)
        Me.Controls.Add(Label14)
        Me.Controls.Add(Me.Contact2_MemoEdit)
        Me.Controls.Add(Label13)
        Me.Controls.Add(Me.Contact1_MemoEdit)
        Me.Controls.Add(Label12)
        Me.Controls.Add(Me.Web_TextEdit)
        Me.Controls.Add(Me.Email_TextEdit)
        Me.Controls.Add(Me.Fax_TextEdit)
        Me.Controls.Add(Me.Tel_TextEdit)
        Me.Controls.Add(Label11)
        Me.Controls.Add(Label10)
        Me.Controls.Add(Label9)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.CustomerID_TextEdit)
        Me.Controls.Add(Label7)
        Me.Controls.Add(ID_lbl)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.City_TextEdit)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.ZipCode_TextEdit)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Me.Adress2_TextEdit)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.Name2_TextEdit)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.CustomerName_TextEdit)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label16)
        Me.Controls.Add(Me.M8_AdviceCharges_MemoEdit)
        Me.Controls.Add(Label19)
        Me.Controls.Add(Me.ClientNrOCBS_GridLookUpEdit)
        Me.Controls.Add(Me.GridControl3)
        Me.Controls.Add(Me.DiscountConditions_MemoEdit)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ClientName_lbl)
        Me.Controls.Add(Me.GridControl4)
        Me.Controls.Add(Me.GridControl5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "LcExportCustomers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FOREIGN DEPT. CUSTOMERS"
        CType(Me.EXPORT_LC_CUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLc_Conditions_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerNotes_RepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLc_BankDetails_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLc_Customers_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.City_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerID_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerName_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Name2_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Adress2_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZipCode_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tel_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fax_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Email_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Web_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Contact1_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Contact2_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LC_Advice_Email_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Notes_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUSTOMER_INFOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.M8_AdviceCharges_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientNrOCBS_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Conditions_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiscountConditions_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankDetails_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportCollectionConditions_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit4.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportCollection_Conditions_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LcDataset As PS_TOOL_DX.LcDataset
    Friend WithEvents EXPORT_LC_CUSTOMERSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EXPORT_LC_CUSTOMERSTableAdapter As PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_CUSTOMERSTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ViewEdit_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExportLc_Customers_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerAddress1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerAddress2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerZipCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerFon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerFax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCustomerWebsite As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContactPerson1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContactPerson2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLcAdviceEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SettlementStatusRepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BICCODERepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CurrencyRepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CustomerNotes_RepositoryItemMemoExEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents AmountRepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ExportLc_Conditions_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Print_Export_GridView_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colCustomerID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents CustomerName_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Name2_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Adress2_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ZipCode_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents City_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CustomerID_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Tel_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Fax_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Email_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Web_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Contact1_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Contact2_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LC_Advice_Email_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Notes_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Save_SimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ShowAllCustomers_SimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents CUSTOMER_INFOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CUSTOMER_INFOTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.CUSTOMER_INFOTableAdapter
    Friend WithEvents TableAdapterManager1 As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents M8_AdviceCharges_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ClientNrOCBS_GridLookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Conditions_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemImageComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemImageComboBox4 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FKEXPORTLCCUSTOMERSConditionsEXPORTLCCUSTOMERSBindingSource As BindingSource
    Friend WithEvents EXPORT_LC_CUSTOMERS_ConditionsTableAdapter As LcDatasetTableAdapters.EXPORT_LC_CUSTOMERS_ConditionsTableAdapter
    Friend WithEvents colID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionCyclus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionPercent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNotes2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdExportLcCustomers As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents colConditionMin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionMax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiscountConditions_MemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents colID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionCyclus1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionPercent1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNotes3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdExportLcCustomers1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionMin1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colConditionMax1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BankDetails_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemImageComboBox5 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemImageComboBox6 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemDateEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemTextEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FKEXPORTLCCUSTOMERSBankDetailsEXPORTLCCUSTOMERSBindingSource As BindingSource
    Friend WithEvents EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter As LcDatasetTableAdapters.EXPORT_LC_CUSTOMERS_BankDetailsTableAdapter
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountConnection As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBAN_CCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBAN_NR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNotes1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents colIdExportLcCustomers2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ClientName_lbl As Label
    Friend WithEvents ExportLc_BankDetails_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountConnection1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBAN_CCY1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIBAN_NR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBIC1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatus1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemImageComboBox7 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colNotes4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdExportLcCustomers3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountHolder1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccountHolder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExportCollectionConditions_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemComboBox3 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemImageComboBox8 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemTextEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemMemoExEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents RepositoryItemImageComboBox9 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemDateEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemTextEdit10 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FKEXPORTLCCUSTOMERSCollectionConditionsEXPORTLCCUSTOMERSBindingSource As BindingSource
    Friend WithEvents EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter As LcDatasetTableAdapters.EXPORT_LC_CUSTOMERS_CollectionConditionsTableAdapter
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label20 As Label
    Friend WithEvents ExportCollection_Conditions_BaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
End Class
