<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternalCurrencies
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalCurrencies))
        Me.PSTOOLDataset = New PS_TOOL_DX.PSTOOLDataset()
        Me.OWN_CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OWN_CURRENCIESTableAdapter = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.OWN_CURRENCIESTableAdapter()
        Me.TableAdapterManager = New PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Cancel_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.AddNewInternalCurrency_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.CurrencySpread_txt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.AcceptsDecimals_ComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.NacionalCurrency_ComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CurrencyName_lbl = New DevExpress.XtraEditors.LabelControl()
        Me.Currencies_LookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.CURRENCIESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EXTERNALDataset = New PS_TOOL_DX.EXTERNALDataset()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CURRENCIESTableAdapter = New PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.CurrenciesBaseView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCURRENCYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOWNCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.colACCEPTSDECIMALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSPREAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colLZB_CurrencyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemImageComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.CustomerAccountsDetailView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colID1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colClientNo1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colClientNo1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colClientAccount1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colClientAccount1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colDealCurrency1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colDealCurrency1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colAccountStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colAccountStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOnline1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOnline1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colEnglishName1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colEnglishName1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colProductCode1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colProductCode1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCurrencyStatus1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCurrencyStatus1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCountry1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCountry1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colPRD_TYPE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colPRD_TYPE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colOPEN_DATE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colOPEN_DATE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colCLOSE_DATE1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_colCLOSE_DATE1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.InternalCurrencies_Print_Export_btn = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.colNEWG_CurrencyCode = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OWN_CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencySpread_txt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AcceptsDecimals_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NacionalCurrency_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Currencies_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrenciesBaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerAccountsDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colClientNo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colClientAccount1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colDealCurrency1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colAccountStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOnline1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colEnglishName1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colProductCode1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCurrencyStatus1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCountry1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colPRD_TYPE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colOPEN_DATE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_colCLOSE_DATE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PSTOOLDataset
        '
        Me.PSTOOLDataset.DataSetName = "PSTOOLDataset"
        Me.PSTOOLDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OWN_CURRENCIESBindingSource
        '
        Me.OWN_CURRENCIESBindingSource.DataMember = "OWN_CURRENCIES"
        Me.OWN_CURRENCIESBindingSource.DataSource = Me.PSTOOLDataset
        '
        'OWN_CURRENCIESTableAdapter
        '
        Me.OWN_CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ABTEILUNGENTableAdapter = Nothing
        Me.TableAdapterManager.ABTEILUNGSPARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.ACCRUED_INTEREST_ANALYSISTableAdapter = Nothing
        Me.TableAdapterManager.ActivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANKTableAdapter = Nothing
        Me.TableAdapterManager.CalendarTableAdapter = Nothing
        Me.TableAdapterManager.ContractTypeTableAdapter = Nothing
        Me.TableAdapterManager.CREDIT_RISKTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.CUSTOMER_INFOTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceDetailsSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets1TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheets2TableAdapter = Nothing
        Me.TableAdapterManager.DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetExpensesTableAdapter = Nothing
        Me.TableAdapterManager.DailyPLSheetIncomeTableAdapter = Nothing
        Me.TableAdapterManager.EXCHANGE_RATES_OCBSTableAdapter = Nothing
        Me.TableAdapterManager.FRISTENTableAdapter = Nothing
        Me.TableAdapterManager.GL_ACCOUNTSTableAdapter = Nothing
        Me.TableAdapterManager.IndustrialClassLocalTableAdapter = Nothing
        Me.TableAdapterManager.INDUSTRY_VALUESTableAdapter = Nothing
        Me.TableAdapterManager.MAK_REPORTTableAdapter = Nothing
        Me.TableAdapterManager.OWN_CURRENCIESTableAdapter = Me.OWN_CURRENCIESTableAdapter
        Me.TableAdapterManager.PARAMETER_All_TableAdapter = Nothing
        Me.TableAdapterManager.PARAMETERTableAdapter = Nothing
        Me.TableAdapterManager.PassivaOffBalance_DailyBalanceSheetsTableAdapter = Nothing
        Me.TableAdapterManager.ProductTypeTableAdapter = Nothing
        Me.TableAdapterManager.SSISTableAdapter = Nothing
        Me.TableAdapterManager.TRIAL_BALANCE_218TableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.Cancel_btn)
        Me.GroupControl1.Controls.Add(Me.AddNewInternalCurrency_btn)
        Me.GroupControl1.Controls.Add(Me.CurrencySpread_txt)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.AcceptsDecimals_ComboBoxEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.NacionalCurrency_ComboBoxEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.CurrencyName_lbl)
        Me.GroupControl1.Controls.Add(Me.Currencies_LookUpEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(80, 93)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(817, 390)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "New Internal Currency"
        '
        'Cancel_btn
        '
        Me.Cancel_btn.ImageOptions.ImageIndex = 7
        Me.Cancel_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.Cancel_btn.Location = New System.Drawing.Point(525, 291)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_btn.TabIndex = 10
        Me.Cancel_btn.Text = "Cancel"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "DisplayDetail.ico")
        Me.ImageCollection1.Images.SetKeyName(1, "DisplayAll.ico")
        Me.ImageCollection1.Images.SetKeyName(2, "Print.ico")
        Me.ImageCollection1.Images.SetKeyName(3, "NonValid.ico")
        Me.ImageCollection1.Images.SetKeyName(4, "Valid.ico")
        Me.ImageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 5)
        Me.ImageCollection1.Images.SetKeyName(5, "add_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 6)
        Me.ImageCollection1.Images.SetKeyName(6, "apply_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 7)
        Me.ImageCollection1.Images.SetKeyName(7, "cancel_16x16.png")
        Me.ImageCollection1.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 8)
        Me.ImageCollection1.Images.SetKeyName(8, "save_16x16.png")
        '
        'AddNewInternalCurrency_btn
        '
        Me.AddNewInternalCurrency_btn.ImageOptions.ImageIndex = 5
        Me.AddNewInternalCurrency_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.AddNewInternalCurrency_btn.Location = New System.Drawing.Point(179, 291)
        Me.AddNewInternalCurrency_btn.Name = "AddNewInternalCurrency_btn"
        Me.AddNewInternalCurrency_btn.Size = New System.Drawing.Size(170, 23)
        Me.AddNewInternalCurrency_btn.TabIndex = 9
        Me.AddNewInternalCurrency_btn.Text = "Add new Internal Currency"
        '
        'CurrencySpread_txt
        '
        Me.CurrencySpread_txt.EditValue = "0,00000"
        Me.CurrencySpread_txt.Location = New System.Drawing.Point(387, 227)
        Me.CurrencySpread_txt.Name = "CurrencySpread_txt"
        Me.CurrencySpread_txt.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CurrencySpread_txt.Properties.Appearance.Options.UseFont = True
        Me.CurrencySpread_txt.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.CurrencySpread_txt.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrencySpread_txt.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CurrencySpread_txt.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.CurrencySpread_txt.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.CurrencySpread_txt.Properties.AppearanceFocused.Options.UseFont = True
        Me.CurrencySpread_txt.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.CurrencySpread_txt.Properties.DisplayFormat.FormatString = "n5"
        Me.CurrencySpread_txt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CurrencySpread_txt.Properties.EditFormat.FormatString = "n5"
        Me.CurrencySpread_txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CurrencySpread_txt.Properties.Mask.EditMask = "n5"
        Me.CurrencySpread_txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.CurrencySpread_txt.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.CurrencySpread_txt.Size = New System.Drawing.Size(100, 22)
        Me.CurrencySpread_txt.TabIndex = 8
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(258, 227)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(109, 16)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Currency Spread"
        '
        'AcceptsDecimals_ComboBoxEdit
        '
        Me.AcceptsDecimals_ComboBoxEdit.Location = New System.Drawing.Point(387, 182)
        Me.AcceptsDecimals_ComboBoxEdit.Name = "AcceptsDecimals_ComboBoxEdit"
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.AcceptsDecimals_ComboBoxEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcceptsDecimals_ComboBoxEdit.Properties.Appearance.Options.UseFont = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.AcceptsDecimals_ComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AcceptsDecimals_ComboBoxEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcceptsDecimals_ComboBoxEdit.Properties.Items.AddRange(New Object() {"Y", "N"})
        Me.AcceptsDecimals_ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.AcceptsDecimals_ComboBoxEdit.Size = New System.Drawing.Size(73, 22)
        Me.AcceptsDecimals_ComboBoxEdit.TabIndex = 6
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(256, 185)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(113, 16)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Accepts Decimals"
        '
        'NacionalCurrency_ComboBoxEdit
        '
        Me.NacionalCurrency_ComboBoxEdit.Location = New System.Drawing.Point(387, 155)
        Me.NacionalCurrency_ComboBoxEdit.Name = "NacionalCurrency_ComboBoxEdit"
        Me.NacionalCurrency_ComboBoxEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.NacionalCurrency_ComboBoxEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NacionalCurrency_ComboBoxEdit.Properties.Appearance.Options.UseFont = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.NacionalCurrency_ComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NacionalCurrency_ComboBoxEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NacionalCurrency_ComboBoxEdit.Properties.Items.AddRange(New Object() {"Y", "N"})
        Me.NacionalCurrency_ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.NacionalCurrency_ComboBoxEdit.Size = New System.Drawing.Size(73, 22)
        Me.NacionalCurrency_ComboBoxEdit.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(256, 155)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(115, 16)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "National Currency"
        '
        'CurrencyName_lbl
        '
        Me.CurrencyName_lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CurrencyName_lbl.Appearance.Options.UseFont = True
        Me.CurrencyName_lbl.Location = New System.Drawing.Point(390, 123)
        Me.CurrencyName_lbl.Name = "CurrencyName_lbl"
        Me.CurrencyName_lbl.Size = New System.Drawing.Size(0, 16)
        Me.CurrencyName_lbl.TabIndex = 2
        '
        'Currencies_LookUpEdit
        '
        Me.Currencies_LookUpEdit.Location = New System.Drawing.Point(387, 96)
        Me.Currencies_LookUpEdit.Name = "Currencies_LookUpEdit"
        Me.Currencies_LookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Currencies_LookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Options.UseFont = True
        Me.Currencies_LookUpEdit.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.Currencies_LookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Currencies_LookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY CODE", "CURRENCY CODE", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[True]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CURRENCY NAME", "CURRENCY NAME", 120, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[True])})
        Me.Currencies_LookUpEdit.Properties.DataSource = Me.CURRENCIESBindingSource
        Me.Currencies_LookUpEdit.Properties.DisplayMember = "CURRENCY CODE"
        Me.Currencies_LookUpEdit.Properties.NullText = "[Select]"
        Me.Currencies_LookUpEdit.Properties.ValueMember = "CURRENCY CODE"
        Me.Currencies_LookUpEdit.Size = New System.Drawing.Size(85, 22)
        Me.Currencies_LookUpEdit.TabIndex = 1
        '
        'CURRENCIESBindingSource
        '
        Me.CURRENCIESBindingSource.DataMember = "CURRENCIES"
        Me.CURRENCIESBindingSource.DataSource = Me.EXTERNALDataset
        '
        'EXTERNALDataset
        '
        Me.EXTERNALDataset.DataSetName = "EXTERNALDataset"
        Me.EXTERNALDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(276, 99)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Currency Code"
        '
        'CURRENCIESTableAdapter
        '
        Me.CURRENCIESTableAdapter.ClearBeforeFill = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.InternalCurrencies_Print_Export_btn)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1040, 149, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1162, 621)
        Me.LayoutControl1.TabIndex = 3
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.DataSource = Me.OWN_CURRENCIESBindingSource
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.ImageIndex = 5
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.ImageIndex = 8
        Me.GridControl2.EmbeddedNavigator.Buttons.ImageList = Me.ImageCollection1
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.Location = New System.Drawing.Point(12, 38)
        Me.GridControl2.MainView = Me.CurrenciesBaseView
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemImageComboBox1, Me.RepositoryItemImageComboBox2, Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1})
        Me.GridControl2.Size = New System.Drawing.Size(1138, 571)
        Me.GridControl2.TabIndex = 11
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CurrenciesBaseView, Me.CustomerAccountsDetailView, Me.GridView2})
        '
        'CurrenciesBaseView
        '
        Me.CurrenciesBaseView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.CurrenciesBaseView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.CurrenciesBaseView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.CurrenciesBaseView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.CurrenciesBaseView.Appearance.FocusedRow.Options.UseForeColor = True
        Me.CurrenciesBaseView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Cyan
        Me.CurrenciesBaseView.Appearance.GroupRow.Options.UseForeColor = True
        Me.CurrenciesBaseView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCURRENCYCODE, Me.colCURRENCYNAME, Me.colOWNCURRENCY, Me.colACCEPTSDECIMALS, Me.colSPREAD, Me.colLZB_CurrencyCode, Me.colNEWG_CurrencyCode, Me.colVALID})
        Me.CurrenciesBaseView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.CurrenciesBaseView.GridControl = Me.GridControl2
        Me.CurrenciesBaseView.Name = "CurrenciesBaseView"
        Me.CurrenciesBaseView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CurrenciesBaseView.OptionsBehavior.AllowIncrementalSearch = True
        Me.CurrenciesBaseView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CurrenciesBaseView.OptionsCustomization.AllowRowSizing = True
        Me.CurrenciesBaseView.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.CurrenciesBaseView.OptionsFind.AlwaysVisible = True
        Me.CurrenciesBaseView.OptionsSelection.MultiSelect = True
        Me.CurrenciesBaseView.OptionsView.ColumnAutoWidth = False
        Me.CurrenciesBaseView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CurrenciesBaseView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag
        Me.CurrenciesBaseView.OptionsView.ShowAutoFilterRow = True
        Me.CurrenciesBaseView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.CurrenciesBaseView.OptionsView.ShowFooter = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.OptionsColumn.ReadOnly = True
        '
        'colCURRENCYCODE
        '
        Me.colCURRENCYCODE.AppearanceCell.Options.UseTextOptions = True
        Me.colCURRENCYCODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCURRENCYCODE.FieldName = "CURRENCY CODE"
        Me.colCURRENCYCODE.Name = "colCURRENCYCODE"
        Me.colCURRENCYCODE.OptionsColumn.AllowEdit = False
        Me.colCURRENCYCODE.OptionsColumn.ReadOnly = True
        Me.colCURRENCYCODE.Visible = True
        Me.colCURRENCYCODE.VisibleIndex = 0
        Me.colCURRENCYCODE.Width = 122
        '
        'colCURRENCYNAME
        '
        Me.colCURRENCYNAME.FieldName = "CURRENCY NAME"
        Me.colCURRENCYNAME.Name = "colCURRENCYNAME"
        Me.colCURRENCYNAME.OptionsColumn.AllowEdit = False
        Me.colCURRENCYNAME.OptionsColumn.ReadOnly = True
        Me.colCURRENCYNAME.Visible = True
        Me.colCURRENCYNAME.VisibleIndex = 1
        Me.colCURRENCYNAME.Width = 415
        '
        'colOWNCURRENCY
        '
        Me.colOWNCURRENCY.AppearanceCell.Options.UseTextOptions = True
        Me.colOWNCURRENCY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOWNCURRENCY.Caption = "NATIONAL CURRENCY"
        Me.colOWNCURRENCY.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colOWNCURRENCY.FieldName = "OWN CURRENCY"
        Me.colOWNCURRENCY.Name = "colOWNCURRENCY"
        Me.colOWNCURRENCY.Visible = True
        Me.colOWNCURRENCY.VisibleIndex = 2
        Me.colOWNCURRENCY.Width = 81
        '
        'RepositoryItemImageComboBox1
        '
        Me.RepositoryItemImageComboBox1.AutoHeight = False
        Me.RepositoryItemImageComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageComboBox1.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("YES", "Y", 6), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NO", "N", 7)})
        Me.RepositoryItemImageComboBox1.Name = "RepositoryItemImageComboBox1"
        Me.RepositoryItemImageComboBox1.SmallImages = Me.ImageCollection1
        '
        'colACCEPTSDECIMALS
        '
        Me.colACCEPTSDECIMALS.AppearanceCell.Options.UseTextOptions = True
        Me.colACCEPTSDECIMALS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colACCEPTSDECIMALS.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colACCEPTSDECIMALS.FieldName = "ACCEPTS DECIMALS"
        Me.colACCEPTSDECIMALS.Name = "colACCEPTSDECIMALS"
        Me.colACCEPTSDECIMALS.Visible = True
        Me.colACCEPTSDECIMALS.VisibleIndex = 3
        Me.colACCEPTSDECIMALS.Width = 70
        '
        'colSPREAD
        '
        Me.colSPREAD.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colSPREAD.FieldName = "SPREAD"
        Me.colSPREAD.Name = "colSPREAD"
        Me.colSPREAD.Visible = True
        Me.colSPREAD.VisibleIndex = 4
        Me.colSPREAD.Width = 107
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemTextEdit1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemTextEdit1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "n5"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatString = "n5"
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "n5"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'colLZB_CurrencyCode
        '
        Me.colLZB_CurrencyCode.AppearanceCell.Options.UseTextOptions = True
        Me.colLZB_CurrencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colLZB_CurrencyCode.Caption = "LZB Currency Code"
        Me.colLZB_CurrencyCode.FieldName = "LZB_CurrencyCode"
        Me.colLZB_CurrencyCode.Name = "colLZB_CurrencyCode"
        Me.colLZB_CurrencyCode.OptionsColumn.AllowEdit = False
        Me.colLZB_CurrencyCode.OptionsColumn.ReadOnly = True
        Me.colLZB_CurrencyCode.Visible = True
        Me.colLZB_CurrencyCode.VisibleIndex = 5
        Me.colLZB_CurrencyCode.Width = 105
        '
        'colVALID
        '
        Me.colVALID.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colVALID.FieldName = "VALID"
        Me.colVALID.Name = "colVALID"
        Me.colVALID.Visible = True
        Me.colVALID.VisibleIndex = 7
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
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemComboBox1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.BackColor2 = System.Drawing.Color.Yellow
        Me.RepositoryItemComboBox1.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemComboBox1.AppearanceFocused.Options.UseForeColor = True
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {"Y", "N"})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'CustomerAccountsDetailView
        '
        Me.CustomerAccountsDetailView.CardMinSize = New System.Drawing.Size(615, 282)
        Me.CustomerAccountsDetailView.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colID1, Me.colClientNo1, Me.colClientAccount1, Me.colDealCurrency1, Me.colAccountStatus1, Me.colOnline1, Me.colEnglishName1, Me.colProductCode1, Me.colCurrencyStatus1, Me.colCountry1, Me.colPRD_TYPE1, Me.colOPEN_DATE1, Me.colCLOSE_DATE1})
        Me.CustomerAccountsDetailView.GridControl = Me.GridControl2
        Me.CustomerAccountsDetailView.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colID1})
        Me.CustomerAccountsDetailView.Name = "CustomerAccountsDetailView"
        Me.CustomerAccountsDetailView.OptionsBehavior.AllowExpandCollapse = False
        Me.CustomerAccountsDetailView.OptionsBehavior.AllowRuntimeCustomization = False
        Me.CustomerAccountsDetailView.OptionsBehavior.AllowSwitchViewModes = False
        Me.CustomerAccountsDetailView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CustomerAccountsDetailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.CustomerAccountsDetailView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.CustomerAccountsDetailView.OptionsCarouselMode.StretchCardToViewHeight = True
        Me.CustomerAccountsDetailView.OptionsCarouselMode.StretchCardToViewWidth = True
        Me.CustomerAccountsDetailView.OptionsCustomization.AllowFilter = False
        Me.CustomerAccountsDetailView.OptionsCustomization.AllowSort = False
        Me.CustomerAccountsDetailView.OptionsCustomization.ShowGroupHiddenItems = False
        Me.CustomerAccountsDetailView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.CustomerAccountsDetailView.OptionsFilter.AllowFilterEditor = False
        Me.CustomerAccountsDetailView.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.CustomerAccountsDetailView.OptionsFind.AllowFindPanel = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableCustomizeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableMultiColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableMultiRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnablePanButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.EnableSingleModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowCustomizeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowMultiColumnModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowMultiRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowPanButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowRowModeButton = False
        Me.CustomerAccountsDetailView.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewHeight = True
        Me.CustomerAccountsDetailView.OptionsSingleRecordMode.StretchCardToViewWidth = True
        Me.CustomerAccountsDetailView.OptionsView.ShowHeaderPanel = False
        Me.CustomerAccountsDetailView.TemplateCard = Me.LayoutViewCard1
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
        Me.layoutViewField_colID1.Size = New System.Drawing.Size(595, 240)
        Me.layoutViewField_colID1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colClientNo1
        '
        Me.colClientNo1.FieldName = "ClientNo"
        Me.colClientNo1.LayoutViewField = Me.layoutViewField_colClientNo1
        Me.colClientNo1.Name = "colClientNo1"
        Me.colClientNo1.OptionsColumn.AllowEdit = False
        Me.colClientNo1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colClientNo1
        '
        Me.layoutViewField_colClientNo1.EditorPreferredWidth = 82
        Me.layoutViewField_colClientNo1.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_colClientNo1.Name = "layoutViewField_colClientNo1"
        Me.layoutViewField_colClientNo1.Size = New System.Drawing.Size(173, 20)
        Me.layoutViewField_colClientNo1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colClientAccount1
        '
        Me.colClientAccount1.FieldName = "Client Account"
        Me.colClientAccount1.LayoutViewField = Me.layoutViewField_colClientAccount1
        Me.colClientAccount1.Name = "colClientAccount1"
        Me.colClientAccount1.OptionsColumn.AllowEdit = False
        Me.colClientAccount1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colClientAccount1
        '
        Me.layoutViewField_colClientAccount1.EditorPreferredWidth = 134
        Me.layoutViewField_colClientAccount1.Location = New System.Drawing.Point(0, 20)
        Me.layoutViewField_colClientAccount1.Name = "layoutViewField_colClientAccount1"
        Me.layoutViewField_colClientAccount1.Size = New System.Drawing.Size(225, 20)
        Me.layoutViewField_colClientAccount1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colDealCurrency1
        '
        Me.colDealCurrency1.FieldName = "Deal Currency"
        Me.colDealCurrency1.LayoutViewField = Me.layoutViewField_colDealCurrency1
        Me.colDealCurrency1.Name = "colDealCurrency1"
        Me.colDealCurrency1.OptionsColumn.AllowEdit = False
        Me.colDealCurrency1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colDealCurrency1
        '
        Me.layoutViewField_colDealCurrency1.EditorPreferredWidth = 47
        Me.layoutViewField_colDealCurrency1.Location = New System.Drawing.Point(0, 40)
        Me.layoutViewField_colDealCurrency1.Name = "layoutViewField_colDealCurrency1"
        Me.layoutViewField_colDealCurrency1.Size = New System.Drawing.Size(138, 20)
        Me.layoutViewField_colDealCurrency1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colAccountStatus1
        '
        Me.colAccountStatus1.ColumnEdit = Me.RepositoryItemImageComboBox1
        Me.colAccountStatus1.FieldName = "Account Status"
        Me.colAccountStatus1.LayoutViewField = Me.layoutViewField_colAccountStatus1
        Me.colAccountStatus1.Name = "colAccountStatus1"
        Me.colAccountStatus1.OptionsColumn.AllowEdit = False
        Me.colAccountStatus1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colAccountStatus1
        '
        Me.layoutViewField_colAccountStatus1.EditorPreferredWidth = 32
        Me.layoutViewField_colAccountStatus1.Location = New System.Drawing.Point(0, 60)
        Me.layoutViewField_colAccountStatus1.Name = "layoutViewField_colAccountStatus1"
        Me.layoutViewField_colAccountStatus1.Size = New System.Drawing.Size(123, 20)
        Me.layoutViewField_colAccountStatus1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colOnline1
        '
        Me.colOnline1.ColumnEdit = Me.RepositoryItemImageComboBox2
        Me.colOnline1.FieldName = "Online"
        Me.colOnline1.LayoutViewField = Me.layoutViewField_colOnline1
        Me.colOnline1.Name = "colOnline1"
        Me.colOnline1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        '
        'layoutViewField_colOnline1
        '
        Me.layoutViewField_colOnline1.EditorPreferredWidth = 32
        Me.layoutViewField_colOnline1.Location = New System.Drawing.Point(0, 80)
        Me.layoutViewField_colOnline1.Name = "layoutViewField_colOnline1"
        Me.layoutViewField_colOnline1.Size = New System.Drawing.Size(123, 20)
        Me.layoutViewField_colOnline1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colEnglishName1
        '
        Me.colEnglishName1.FieldName = "English Name"
        Me.colEnglishName1.LayoutViewField = Me.layoutViewField_colEnglishName1
        Me.colEnglishName1.Name = "colEnglishName1"
        Me.colEnglishName1.OptionsColumn.AllowEdit = False
        Me.colEnglishName1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colEnglishName1
        '
        Me.layoutViewField_colEnglishName1.EditorPreferredWidth = 487
        Me.layoutViewField_colEnglishName1.Location = New System.Drawing.Point(0, 100)
        Me.layoutViewField_colEnglishName1.Name = "layoutViewField_colEnglishName1"
        Me.layoutViewField_colEnglishName1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colEnglishName1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colProductCode1
        '
        Me.colProductCode1.FieldName = "ProductCode"
        Me.colProductCode1.LayoutViewField = Me.layoutViewField_colProductCode1
        Me.colProductCode1.Name = "colProductCode1"
        Me.colProductCode1.OptionsColumn.AllowEdit = False
        Me.colProductCode1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colProductCode1
        '
        Me.layoutViewField_colProductCode1.EditorPreferredWidth = 93
        Me.layoutViewField_colProductCode1.Location = New System.Drawing.Point(0, 120)
        Me.layoutViewField_colProductCode1.Name = "layoutViewField_colProductCode1"
        Me.layoutViewField_colProductCode1.Size = New System.Drawing.Size(184, 20)
        Me.layoutViewField_colProductCode1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colCurrencyStatus1
        '
        Me.colCurrencyStatus1.FieldName = "Currency Status"
        Me.colCurrencyStatus1.LayoutViewField = Me.layoutViewField_colCurrencyStatus1
        Me.colCurrencyStatus1.Name = "colCurrencyStatus1"
        Me.colCurrencyStatus1.OptionsColumn.AllowEdit = False
        Me.colCurrencyStatus1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCurrencyStatus1
        '
        Me.layoutViewField_colCurrencyStatus1.EditorPreferredWidth = 93
        Me.layoutViewField_colCurrencyStatus1.Location = New System.Drawing.Point(0, 140)
        Me.layoutViewField_colCurrencyStatus1.Name = "layoutViewField_colCurrencyStatus1"
        Me.layoutViewField_colCurrencyStatus1.Size = New System.Drawing.Size(184, 20)
        Me.layoutViewField_colCurrencyStatus1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colCountry1
        '
        Me.colCountry1.FieldName = "Country"
        Me.colCountry1.LayoutViewField = Me.layoutViewField_colCountry1
        Me.colCountry1.Name = "colCountry1"
        Me.colCountry1.OptionsColumn.AllowEdit = False
        Me.colCountry1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCountry1
        '
        Me.layoutViewField_colCountry1.EditorPreferredWidth = 487
        Me.layoutViewField_colCountry1.Location = New System.Drawing.Point(0, 160)
        Me.layoutViewField_colCountry1.Name = "layoutViewField_colCountry1"
        Me.layoutViewField_colCountry1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colCountry1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colPRD_TYPE1
        '
        Me.colPRD_TYPE1.Caption = "PRD TYPE"
        Me.colPRD_TYPE1.FieldName = "PRD_TYPE"
        Me.colPRD_TYPE1.LayoutViewField = Me.layoutViewField_colPRD_TYPE1
        Me.colPRD_TYPE1.Name = "colPRD_TYPE1"
        Me.colPRD_TYPE1.OptionsColumn.AllowEdit = False
        Me.colPRD_TYPE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colPRD_TYPE1
        '
        Me.layoutViewField_colPRD_TYPE1.EditorPreferredWidth = 487
        Me.layoutViewField_colPRD_TYPE1.Location = New System.Drawing.Point(0, 180)
        Me.layoutViewField_colPRD_TYPE1.Name = "layoutViewField_colPRD_TYPE1"
        Me.layoutViewField_colPRD_TYPE1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colPRD_TYPE1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colOPEN_DATE1
        '
        Me.colOPEN_DATE1.Caption = "OPEN DATE"
        Me.colOPEN_DATE1.FieldName = "OPEN_DATE"
        Me.colOPEN_DATE1.LayoutViewField = Me.layoutViewField_colOPEN_DATE1
        Me.colOPEN_DATE1.Name = "colOPEN_DATE1"
        Me.colOPEN_DATE1.OptionsColumn.AllowEdit = False
        Me.colOPEN_DATE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colOPEN_DATE1
        '
        Me.layoutViewField_colOPEN_DATE1.EditorPreferredWidth = 487
        Me.layoutViewField_colOPEN_DATE1.Location = New System.Drawing.Point(0, 200)
        Me.layoutViewField_colOPEN_DATE1.Name = "layoutViewField_colOPEN_DATE1"
        Me.layoutViewField_colOPEN_DATE1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colOPEN_DATE1.TextSize = New System.Drawing.Size(82, 13)
        '
        'colCLOSE_DATE1
        '
        Me.colCLOSE_DATE1.Caption = "CLOSE DATE"
        Me.colCLOSE_DATE1.FieldName = "CLOSE_DATE"
        Me.colCLOSE_DATE1.LayoutViewField = Me.layoutViewField_colCLOSE_DATE1
        Me.colCLOSE_DATE1.Name = "colCLOSE_DATE1"
        Me.colCLOSE_DATE1.OptionsColumn.AllowEdit = False
        Me.colCLOSE_DATE1.OptionsColumn.ReadOnly = True
        '
        'layoutViewField_colCLOSE_DATE1
        '
        Me.layoutViewField_colCLOSE_DATE1.EditorPreferredWidth = 487
        Me.layoutViewField_colCLOSE_DATE1.Location = New System.Drawing.Point(0, 220)
        Me.layoutViewField_colCLOSE_DATE1.Name = "layoutViewField_colCLOSE_DATE1"
        Me.layoutViewField_colCLOSE_DATE1.Size = New System.Drawing.Size(578, 20)
        Me.layoutViewField_colCLOSE_DATE1.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_colClientNo1, Me.layoutViewField_colClientAccount1, Me.layoutViewField_colDealCurrency1, Me.layoutViewField_colAccountStatus1, Me.layoutViewField_colOnline1, Me.layoutViewField_colEnglishName1, Me.layoutViewField_colProductCode1, Me.layoutViewField_colCurrencyStatus1, Me.layoutViewField_colCountry1, Me.layoutViewField_colPRD_TYPE1, Me.layoutViewField_colOPEN_DATE1, Me.layoutViewField_colCLOSE_DATE1})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
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
        'InternalCurrencies_Print_Export_btn
        '
        Me.InternalCurrencies_Print_Export_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InternalCurrencies_Print_Export_btn.ImageOptions.ImageIndex = 2
        Me.InternalCurrencies_Print_Export_btn.ImageOptions.ImageList = Me.ImageCollection1
        Me.InternalCurrencies_Print_Export_btn.Location = New System.Drawing.Point(12, 12)
        Me.InternalCurrencies_Print_Export_btn.Name = "InternalCurrencies_Print_Export_btn"
        Me.InternalCurrencies_Print_Export_btn.Size = New System.Drawing.Size(127, 22)
        Me.InternalCurrencies_Print_Export_btn.StyleController = Me.LayoutControl1
        Me.InternalCurrencies_Print_Export_btn.TabIndex = 9
        Me.InternalCurrencies_Print_Export_btn.Text = "Print or Export"
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
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.SimpleSeparator1, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1162, 621)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(234, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(785, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.InternalCurrencies_Print_Export_btn
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(131, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(131, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(103, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1"
        Me.SimpleSeparator1.Location = New System.Drawing.Point(1019, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(123, 26)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl2
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1142, 575)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
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
        'colNEWG_CurrencyCode
        '
        Me.colNEWG_CurrencyCode.AppearanceCell.Options.UseTextOptions = True
        Me.colNEWG_CurrencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colNEWG_CurrencyCode.Caption = "NEWG Currency Code"
        Me.colNEWG_CurrencyCode.FieldName = "NEWG_CurrencyCode"
        Me.colNEWG_CurrencyCode.Name = "colNEWG_CurrencyCode"
        Me.colNEWG_CurrencyCode.OptionsColumn.AllowEdit = False
        Me.colNEWG_CurrencyCode.OptionsColumn.ReadOnly = True
        Me.colNEWG_CurrencyCode.Visible = True
        Me.colNEWG_CurrencyCode.VisibleIndex = 6
        Me.colNEWG_CurrencyCode.Width = 96
        '
        'InternalCurrencies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(1162, 621)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InternalCurrencies"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Internal Currencies"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PSTOOLDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OWN_CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencySpread_txt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AcceptsDecimals_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NacionalCurrency_ComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Currencies_LookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CURRENCIESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EXTERNALDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrenciesBaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerAccountsDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colID1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colClientNo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colClientAccount1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colDealCurrency1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colAccountStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOnline1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colEnglishName1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colProductCode1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCurrencyStatus1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCountry1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colPRD_TYPE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colOPEN_DATE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_colCLOSE_DATE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PSTOOLDataset As PS_TOOL_DX.PSTOOLDataset
    Friend WithEvents OWN_CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OWN_CURRENCIESTableAdapter As PS_TOOL_DX.PSTOOLDatasetTableAdapters.OWN_CURRENCIESTableAdapter
    Friend WithEvents TableAdapterManager As PS_TOOL_DX.PSTOOLDatasetTableAdapters.TableAdapterManager
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Currencies_LookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EXTERNALDataset As PS_TOOL_DX.EXTERNALDataset
    Friend WithEvents CURRENCIESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CURRENCIESTableAdapter As PS_TOOL_DX.EXTERNALDatasetTableAdapters.CURRENCIESTableAdapter
    Friend WithEvents CurrencyName_lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents NacionalCurrency_ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents AcceptsDecimals_ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CurrencySpread_txt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Cancel_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AddNewInternalCurrency_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents CustomerAccountsDetailView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colID1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colClientNo1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colClientNo1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colClientAccount1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colClientAccount1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colDealCurrency1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colDealCurrency1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colAccountStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents RepositoryItemImageComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents layoutViewField_colAccountStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOnline1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents RepositoryItemImageComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents layoutViewField_colOnline1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colEnglishName1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colEnglishName1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colProductCode1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colProductCode1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCurrencyStatus1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCurrencyStatus1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCountry1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCountry1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colPRD_TYPE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colPRD_TYPE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colOPEN_DATE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colOPEN_DATE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents colCLOSE_DATE1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents layoutViewField_colCLOSE_DATE1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents CurrenciesBaseView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents InternalCurrencies_Print_Export_btn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCURRENCYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOWNCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colACCEPTSDECIMALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSPREAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents colLZB_CurrencyCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEWG_CurrencyCode As DevExpress.XtraGrid.Columns.GridColumn
End Class
