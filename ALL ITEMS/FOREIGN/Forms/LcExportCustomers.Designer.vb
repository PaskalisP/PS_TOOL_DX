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
        Dim Label17 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LcExportCustomers))
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.EXPORT_LC_CUSTOMERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LcDataset = New PS_TOOL_DX.LcDataset()
        Me.EXPORT_LC_CUSTOMERSTableAdapter = New PS_TOOL_DX.LcDatasetTableAdapters.EXPORT_LC_CUSTOMERSTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
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
        Me.CustomerNotes_RepositoryItemMemoExEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SettlementStatusRepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BICCODERepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CurrencyRepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.AmountRepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ExportLCMaturitiesDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colDocsSendOn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colDocsSendOn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colApplicantsBank1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colApplicantsBank1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOurReference1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOurReference1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrency1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrency1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAmount1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAmount1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colMaturity1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colMaturity1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colSettlementStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colSettlementStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colNotes1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colNotes1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.ExternalIBAN_TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ExternalBankName_MemoEdit = New DevExpress.XtraEditors.MemoEdit()
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
        Label17 = New System.Windows.Forms.Label()
        Label18 = New System.Windows.Forms.Label()
        Label19 = New System.Windows.Forms.Label()
        CType(Me.EXPORT_LC_CUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLc_Customers_BaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerNotes_RepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExportLCMaturitiesDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDocsSendOn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colApplicantsBank1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOurReference1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrency1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAmount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colMaturity1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colSettlementStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colNotes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.ExternalIBAN_TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExternalBankName_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.M8_AdviceCharges_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientNrOCBS_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label15.AutoSize = True
        Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label15.Location = New System.Drawing.Point(766, 176)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(46, 14)
        Label15.TabIndex = 36
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
        'Label17
        '
        Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label17.AutoSize = True
        Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label17.Location = New System.Drawing.Point(766, 71)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(95, 14)
        Label17.TabIndex = 32
        Label17.Text = "External IBAN:"
        '
        'Label18
        '
        Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label18.AutoSize = True
        Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label18.Location = New System.Drawing.Point(783, 94)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(78, 14)
        Label18.TabIndex = 34
        Label18.Text = "Bank Name:"
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
        'EXPORT_LC_CUSTOMERSTableAdapter
        '
        Me.EXPORT_LC_CUSTOMERSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ALL_SWIFT_MESSAGESTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EXPORT_LC_CUSTOMERSTableAdapter = Me.EXPORT_LC_CUSTOMERSTableAdapter
        Me.TableAdapterManager.EXPORT_LC_MT700_BD_TableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700_RMTableAdapter = Nothing
        Me.TableAdapterManager.EXPORT_LC_MT700TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.LcDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.ExportLc_Customers_BaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SettlementStatusRepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2, Me.RepositoryItemTextEdit1, Me.BICCODERepositoryItemTextEdit, Me.CurrencyRepositoryItemLookUpEdit1, Me.RepositoryItemDateEdit1, Me.CustomerNotes_RepositoryItemMemoExEdit, Me.AmountRepositoryItemTextEdit2})
        Me.GridControl2.Size = New System.Drawing.Size(1404, 684)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExportLc_Customers_BaseView, Me.ExportLCMaturitiesDetailView, Me.GridView2})
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
        Me.ExportLc_Customers_BaseView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", Nothing, "Total: {0:n2}", 0.0R)})
        Me.ExportLc_Customers_BaseView.Name = "ExportLc_Customers_BaseView"
        Me.ExportLc_Customers_BaseView.NewItemRowText = "Add new EXPORT LC Maturity"
        Me.ExportLc_Customers_BaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLc_Customers_BaseView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLc_Customers_BaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.ExportLc_Customers_BaseView.OptionsCustomization.AllowRowSizing = True
        Me.ExportLc_Customers_BaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.ExportLc_Customers_BaseView.OptionsFind.AlwaysVisible = True
        Me.ExportLc_Customers_BaseView.OptionsNavigation.AutoFocusNewRow = True
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
        Me.SettlementStatusRepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PENDING", "PENDING", 7), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PAID", "PAID", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("UNPAID", "UNPAID", 3)})
        Me.SettlementStatusRepositoryItemImageComboBox1.Name = "SettlementStatusRepositoryItemImageComboBox1"
        Me.SettlementStatusRepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'RepositoryItemImageComboBox2
        '
        Me.RepositoryItemImageComboBox2.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemImageComboBox2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemImageComboBox2.AutoHeight = False
        Me.RepositoryItemImageComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemImageComboBox2.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Y", 4), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "N", 3)})
        Me.RepositoryItemImageComboBox2.Name = "RepositoryItemImageComboBox2"
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
        Me.CurrencyRepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
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
        Me.AmountRepositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.Yellow
        Me.AmountRepositoryItemTextEdit2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.AmountRepositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseBackColor = True
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseFont = True
        Me.AmountRepositoryItemTextEdit2.Appearance.Options.UseForeColor = True
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
        'ExportLCMaturitiesDetailView
        '
        Me.ExportLCMaturitiesDetailView.CardMinSize = New System.Drawing.Size(741, 448)
        Me.ExportLCMaturitiesDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colDocsSendOn1, Me.colApplicantsBank1, Me.colOurReference1, Me.colCurrency1, Me.colAmount1, Me.colMaturity1, Me.colSettlementStatus1, Me.colNotes1})
        Me.ExportLCMaturitiesDetailView.GridControl = Me.GridControl2
        Me.ExportLCMaturitiesDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1})
        Me.ExportLCMaturitiesDetailView.Name = "ExportLCMaturitiesDetailView"
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.ExportLCMaturitiesDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.ExportLCMaturitiesDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.ExportLCMaturitiesDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.AllowFilter = False
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.AllowSort = False
        Me.ExportLCMaturitiesDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowFilterEditor = False
        Me.ExportLCMaturitiesDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.ExportLCMaturitiesDetailView.OptionsFind.AllowFindPanel = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.ExportLCMaturitiesDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.ExportLCMaturitiesDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.ExportLCMaturitiesDetailView.OptionsView.ShowHeaderPanel = False
        Me.ExportLCMaturitiesDetailView.TemplateCard = Me.LayoutViewCard1
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.LayoutViewField = Me.layoutViewField_colID1
        Me.colID1.Name = "colID1"
        Me.colID1.OptionsColumn.AllowEdit = False
        Me.colID1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colID1
        '
        Me.layoutViewField_colID1.EditorPreferredWidth = 20
        Me.layoutViewField_colID1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colID1.Name = "layoutViewField_colID1"
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(730, 180)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colDocsSendOn1
        '
        Me.colDocsSendOn1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colDocsSendOn1.FieldName = "DocsSendOn"
        Me.colDocsSendOn1.LayoutViewField = Me.layoutViewField_colDocsSendOn1
        Me.colDocsSendOn1.Name = "colDocsSendOn1"
        '
        'layoutViewField_colDocsSendOn1
        '
        Me.layoutViewField_colDocsSendOn1.EditorPreferredWidth = 90
        Me.layoutViewField_colDocsSendOn1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colDocsSendOn1.Name = "layoutViewField_colDocsSendOn1"
        Me.layoutViewField_colDocsSendOn1.Size = New System.Drawing.Size(189, 20)
        Me.layoutViewField_colDocsSendOn1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colApplicantsBank1
        '
        Me.colApplicantsBank1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colApplicantsBank1.FieldName = "ApplicantsBank"
        Me.colApplicantsBank1.LayoutViewField = Me.layoutViewField_colApplicantsBank1
        Me.colApplicantsBank1.Name = "colApplicantsBank1"
        '
        'layoutViewField_colApplicantsBank1
        '
        Me.layoutViewField_colApplicantsBank1.EditorPreferredWidth = 622
        Me.layoutViewField_colApplicantsBank1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colApplicantsBank1.Name = "layoutViewField_colApplicantsBank1"
        Me.layoutViewField_colApplicantsBank1.Size = New System.Drawing.Size(721, 20)
        Me.layoutViewField_colApplicantsBank1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colOurReference1
        '
        Me.colOurReference1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colOurReference1.FieldName = "OurReference"
        Me.colOurReference1.LayoutViewField = Me.layoutViewField_colOurReference1
        Me.colOurReference1.Name = "colOurReference1"
        '
        'layoutViewField_colOurReference1
        '
        Me.layoutViewField_colOurReference1.EditorPreferredWidth = 91
        Me.layoutViewField_colOurReference1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colOurReference1.Name = "layoutViewField_colOurReference1"
        Me.layoutViewField_colOurReference1.Size = New System.Drawing.Size(190, 20)
        Me.layoutViewField_colOurReference1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colCurrency1
        '
        Me.colCurrency1.ColumnEdit = Me.CurrencyRepositoryItemLookUpEdit1
        Me.colCurrency1.FieldName = "Currency"
        Me.colCurrency1.LayoutViewField = Me.layoutViewField_colCurrency1
        Me.colCurrency1.Name = "colCurrency1"
        '
        'layoutViewField_colCurrency1
        '
        Me.layoutViewField_colCurrency1.EditorPreferredWidth = 40
        Me.layoutViewField_colCurrency1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colCurrency1.Name = "layoutViewField_colCurrency1"
        Me.layoutViewField_colCurrency1.Size = New System.Drawing.Size(139, 20)
        Me.layoutViewField_colCurrency1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colAmount1
        '
        Me.colAmount1.ColumnEdit = Me.AmountRepositoryItemTextEdit2
        Me.colAmount1.FieldName = "Amount"
        Me.colAmount1.LayoutViewField = Me.layoutViewField_colAmount1
        Me.colAmount1.Name = "colAmount1"
        '
        'layoutViewField_colAmount1
        '
        Me.layoutViewField_colAmount1.EditorPreferredWidth = 123
        Me.layoutViewField_colAmount1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colAmount1.Name = "layoutViewField_colAmount1"
        Me.layoutViewField_colAmount1.Size = New System.Drawing.Size(222, 20)
        Me.layoutViewField_colAmount1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colMaturity1
        '
        Me.colMaturity1.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colMaturity1.FieldName = "Maturity"
        Me.colMaturity1.LayoutViewField = Me.layoutViewField_colMaturity1
        Me.colMaturity1.Name = "colMaturity1"
        '
        'layoutViewField_colMaturity1
        '
        Me.layoutViewField_colMaturity1.EditorPreferredWidth = 94
        Me.layoutViewField_colMaturity1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colMaturity1.Name = "layoutViewField_colMaturity1"
        Me.layoutViewField_colMaturity1.Size = New System.Drawing.Size(193, 20)
        Me.layoutViewField_colMaturity1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colSettlementStatus1
        '
        Me.colSettlementStatus1.ColumnEdit = Me.SettlementStatusRepositoryItemImageComboBox1
        Me.colSettlementStatus1.FieldName = "SettlementStatus"
        Me.colSettlementStatus1.LayoutViewField = Me.layoutViewField_colSettlementStatus1
        Me.colSettlementStatus1.Name = "colSettlementStatus1"
        '
        'layoutViewField_colSettlementStatus1
        '
        Me.layoutViewField_colSettlementStatus1.EditorPreferredWidth = 62
        Me.layoutViewField_colSettlementStatus1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colSettlementStatus1.Name = "layoutViewField_colSettlementStatus1"
        Me.layoutViewField_colSettlementStatus1.Size = New System.Drawing.Size(161, 20)
        Me.layoutViewField_colSettlementStatus1.TextSize = New System.Drawing.Size(90, 13)
        '
        'colNotes1
        '
        Me.colNotes1.ColumnEdit = Me.CustomerNotes_RepositoryItemMemoExEdit
        Me.colNotes1.FieldName = "Notes"
        Me.colNotes1.LayoutViewField = Me.layoutViewField_colNotes1
        Me.colNotes1.Name = "colNotes1"
        '
        'layoutViewField_colNotes1
        '
        Me.layoutViewField_colNotes1.EditorPreferredWidth = 622
        Me.layoutViewField_colNotes1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colNotes1.Name = "layoutViewField_colNotes1"
        Me.layoutViewField_colNotes1.Size = New System.Drawing.Size(721, 269)
        Me.layoutViewField_colNotes1.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colDocsSendOn1, Me.layoutViewField_colApplicantsBank1, Me.layoutViewField_colOurReference1, Me.layoutViewField_colCurrency1, Me.layoutViewField_colAmount1, Me.layoutViewField_colMaturity1, Me.layoutViewField_colSettlementStatus1, Me.layoutViewField_colNotes1})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ViewEdit_btn)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.Print_Export_GridView_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1428, 734)
        Me.LayoutControl1.TabIndex = 19
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ViewEdit_btn
        '
        Me.ViewEdit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ViewEdit_btn.ImageOptions.ImageIndex = 0
        Me.ViewEdit_btn.Location = New System.Drawing.Point(1292, 12)
        Me.ViewEdit_btn.Name = "ViewEdit_btn"
        Me.ViewEdit_btn.Size = New System.Drawing.Size(124, 22)
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
        Me.Print_Export_GridView_btn.Size = New System.Drawing.Size(155, 22)
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
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1428, 734)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(374, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(904, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Print_Export_GridView_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(159, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(159, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(215, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1278, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(2, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1408, 688)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ViewEdit_btn
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1280, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(128, 26)
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
        Me.City_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.CustomerName_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Name2_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Adress2_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ZipCode_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Tel_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Fax_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Email_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Web_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Contact1_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Contact2_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.LC_Advice_Email_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Notes_MemoEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Notes_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "Notes", True))
        Me.Notes_MemoEdit.Location = New System.Drawing.Point(768, 193)
        Me.Notes_MemoEdit.Name = "Notes_MemoEdit"
        Me.Notes_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.Notes_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.Notes_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.Notes_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Notes_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Notes_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Notes_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Notes_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Notes_MemoEdit.Size = New System.Drawing.Size(648, 417)
        Me.Notes_MemoEdit.TabIndex = 37
        '
        'Save_SimpleButton
        '
        Me.Save_SimpleButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Save_SimpleButton.ImageOptions.ImageIndex = 11
        Me.Save_SimpleButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.Save_SimpleButton.Location = New System.Drawing.Point(139, 626)
        Me.Save_SimpleButton.Name = "Save_SimpleButton"
        Me.Save_SimpleButton.Size = New System.Drawing.Size(153, 22)
        Me.Save_SimpleButton.StyleController = Me.LayoutControl1
        Me.Save_SimpleButton.TabIndex = 38
        Me.Save_SimpleButton.Text = "Save"
        '
        'ShowAllCustomers_SimpleButton
        '
        Me.ShowAllCustomers_SimpleButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowAllCustomers_SimpleButton.ImageOptions.ImageIndex = 12
        Me.ShowAllCustomers_SimpleButton.ImageOptions.ImageList = Me.ImageCollection1
        Me.ShowAllCustomers_SimpleButton.Location = New System.Drawing.Point(309, 626)
        Me.ShowAllCustomers_SimpleButton.Name = "ShowAllCustomers_SimpleButton"
        Me.ShowAllCustomers_SimpleButton.Size = New System.Drawing.Size(153, 22)
        Me.ShowAllCustomers_SimpleButton.StyleController = Me.LayoutControl1
        Me.ShowAllCustomers_SimpleButton.TabIndex = 39
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
        'ExternalIBAN_TextEdit
        '
        Me.ExternalIBAN_TextEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExternalIBAN_TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerExternalIBAN", True))
        Me.ExternalIBAN_TextEdit.Location = New System.Drawing.Point(867, 68)
        Me.ExternalIBAN_TextEdit.Name = "ExternalIBAN_TextEdit"
        Me.ExternalIBAN_TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExternalIBAN_TextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ExternalIBAN_TextEdit.Properties.Appearance.Options.UseFont = True
        Me.ExternalIBAN_TextEdit.Properties.Appearance.Options.UseForeColor = True
        Me.ExternalIBAN_TextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ExternalIBAN_TextEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ExternalIBAN_TextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ExternalIBAN_TextEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ExternalIBAN_TextEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ExternalIBAN_TextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ExternalIBAN_TextEdit.Size = New System.Drawing.Size(549, 20)
        Me.ExternalIBAN_TextEdit.TabIndex = 33
        '
        'ExternalBankName_MemoEdit
        '
        Me.ExternalBankName_MemoEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExternalBankName_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "CustomerExternalBANKNAME", True))
        Me.ExternalBankName_MemoEdit.Location = New System.Drawing.Point(867, 94)
        Me.ExternalBankName_MemoEdit.Name = "ExternalBankName_MemoEdit"
        Me.ExternalBankName_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExternalBankName_MemoEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua
        Me.ExternalBankName_MemoEdit.Properties.Appearance.Options.UseFont = True
        Me.ExternalBankName_MemoEdit.Properties.Appearance.Options.UseForeColor = True
        Me.ExternalBankName_MemoEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.ExternalBankName_MemoEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.ExternalBankName_MemoEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.ExternalBankName_MemoEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.ExternalBankName_MemoEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.ExternalBankName_MemoEdit.Size = New System.Drawing.Size(549, 60)
        Me.ExternalBankName_MemoEdit.TabIndex = 35
        '
        'M8_AdviceCharges_MemoEdit
        '
        Me.M8_AdviceCharges_MemoEdit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EXPORT_LC_CUSTOMERSBindingSource, "LcAdviceChargesDTAEA", True))
        Me.M8_AdviceCharges_MemoEdit.Location = New System.Drawing.Point(140, 310)
        Me.M8_AdviceCharges_MemoEdit.Name = "M8_AdviceCharges_MemoEdit"
        Me.M8_AdviceCharges_MemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ClientNrOCBS_GridLookUpEdit.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1})
        Me.ClientNrOCBS_GridLookUpEdit.Properties.ValueMember = "ClientNo"
        Me.ClientNrOCBS_GridLookUpEdit.Properties.View = Me.SearchLookUpEdit1View
        Me.ClientNrOCBS_GridLookUpEdit.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView
        Me.ClientNrOCBS_GridLookUpEdit.Size = New System.Drawing.Size(157, 22)
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
        Me.GridColumn2.FieldName = "ClientNo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 94
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
        'LcExportCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1428, 734)
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
        Me.Controls.Add(Me.ExternalBankName_MemoEdit)
        Me.Controls.Add(Label18)
        Me.Controls.Add(Me.ExternalIBAN_TextEdit)
        Me.Controls.Add(Label17)
        Me.Controls.Add(Label16)
        Me.Controls.Add(Me.M8_AdviceCharges_MemoEdit)
        Me.Controls.Add(Label19)
        Me.Controls.Add(Me.ClientNrOCBS_GridLookUpEdit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LcExportCustomers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EXPORT LC's - CUSTOMERS"
        CType(Me.EXPORT_LC_CUSTOMERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLc_Customers_BaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerNotes_RepositoryItemMemoExEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SettlementStatusRepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BICCODERepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmountRepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExportLCMaturitiesDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDocsSendOn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colApplicantsBank1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOurReference1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrency1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAmount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colMaturity1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colSettlementStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colNotes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.ExternalIBAN_TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExternalBankName_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.M8_AdviceCharges_MemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientNrOCBS_GridLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ExportLCMaturitiesDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colDocsSendOn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colDocsSendOn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colApplicantsBank1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colApplicantsBank1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOurReference1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOurReference1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrency1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrency1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAmount1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colAmount1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colMaturity1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colMaturity1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colSettlementStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colSettlementStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colNotes1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colNotes1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents ExternalIBAN_TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ExternalBankName_MemoEdit As DevExpress.XtraEditors.MemoEdit
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
End Class
